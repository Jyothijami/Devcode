using phani.Classes;
using phani.MessageBox;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_OfferLetter_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            gvitems.DataBind();
            txtofferNo.Text = HR.OfferLetter.OfferLetter_AutoGenCode();
            Masters.Designation.Designation_Select(ddlDesignation);
            HR.JobApplicant.JobApplicant_Select(ddlJobApplicant);
            HR.OfferTerms.OfferTerms_Select(ddlofferterms);
            if (Qid != "Add")
            {

                CategoryFill();

            }
        }
       
    }


    private void CategoryFill()
    {
        HR.OfferLetter objmaster = new HR.OfferLetter();
        if (objmaster.OfferLetter_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            ddlJobApplicant.SelectedValue = objmaster.JobappId;
            txtOfferDate.Text = objmaster.offerdate;
            ddlstatus.SelectedValue = objmaster.Status;
            ddlDesignation.SelectedValue = objmaster.Designationid;
            txtTermsandConditions.Text = objmaster.Termsandconditions;
            txtofferNo.Text = objmaster.offerNo;

            objmaster.OfferLetterDetails_Select(Request.QueryString["Cid"].ToString(), gvitems);
        }
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            po_Save();
        }
        else if (btnSave.Text == "Update")
        {
            po_Update();
        }
    }

    private void po_Update()
    {
        try
        {
            HR.OfferLetter objMaster = new HR.OfferLetter();
            objMaster.OfferLetterId = Request.QueryString["Cid"].ToString();
            objMaster.offerNo = txtofferNo.Text;
            objMaster.offerdate = General.toMMDDYYYY(txtOfferDate.Text).ToString();
            objMaster.JobappId = ddlJobApplicant.SelectedItem.Value;
            objMaster.Status = ddlstatus.SelectedItem.Value;
            objMaster.Designationid = ddlDesignation.SelectedItem.Value;
            objMaster.Termsandconditions = txtTermsandConditions.Text;

            if (objMaster.OfferLetter_Update() == "Data Updated Successfully")
            {
               
                objMaster.OfferLetterDetails_Delete(objMaster.OfferLetterId);
                foreach (GridViewRow gvRowOtherCorp in gvitems.Rows)
                {
                    objMaster.offerterm = gvRowOtherCorp.Cells[1].Text;
                    objMaster.offerdescription = gvRowOtherCorp.Cells[2].Text;

                    objMaster.OfferLetterDetails_Save();
                }
            }
            MessageBox.Show(this, "Data Updated Successfully");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            HR.ClearControls(this);
            HR.Dispose();
            Response.Redirect("~/Modules/HR/OfferLetter.aspx");
        }
    }

    private void po_Save()
    {
        try
        {
            HR.OfferLetter objMaster = new HR.OfferLetter();

            objMaster.offerNo = txtofferNo.Text;
            objMaster.offerdate = General.toMMDDYYYY(txtOfferDate.Text).ToString();
            objMaster.JobappId = ddlJobApplicant.SelectedItem.Value;
            objMaster.Status = ddlstatus.SelectedItem.Value;
            objMaster.Designationid = ddlDesignation.SelectedItem.Value;
            objMaster.Termsandconditions = txtTermsandConditions.Text;
           

            if (objMaster.OfferLetter_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in gvitems.Rows)
                {
                    objMaster.offerterm = gvRowOtherCorp.Cells[1].Text;
                    objMaster.offerdescription = gvRowOtherCorp.Cells[2].Text;
                   
                    objMaster.OfferLetterDetails_Save();
                }
            }

            MessageBox.Show(this, "Data Saved Successfully");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            HR.ClearControls(this);
            HR.Dispose();
            Response.Redirect("~/Modules/HR/OfferLetter.aspx");
        }
    }









    protected void gvitems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvitems.Rows[e.RowIndex].Cells[1].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("OfferTerms");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);

        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["OfferTerms"] = gvrow.Cells[1].Text;
                    dr["Description"] = gvrow.Cells[2].Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
    }
    protected void btnAddnew_Click(object sender, EventArgs e)
    {
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("OfferTerms");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);

        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvitems.SelectedIndex > -1)
                {
                    if (gvrow.RowIndex == gvitems.SelectedRow.RowIndex)
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["OfferTerms"] = ddlofferterms.SelectedItem.Text;
                        dr["Description"] = txtDescription.Text;
                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["OfferTerms"] = gvrow.Cells[1].Text;
                        dr["Description"] = gvrow.Cells[2].Text;
                      
                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["OfferTerms"] = gvrow.Cells[1].Text;
                    dr["Description"] = gvrow.Cells[2].Text;
                 
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }

        if (gvitems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["OfferTerms"] = ddlofferterms.SelectedItem.Text;
            drnew["Description"] = txtDescription.Text;
          
            SalesOrderItems.Rows.Add(drnew);
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
        gvitems.SelectedIndex = -1;
        refresh();
    }

    private void refresh()
    {
        ddlofferterms.SelectedValue = "0";
        txtDescription.Text = "";
    }
}