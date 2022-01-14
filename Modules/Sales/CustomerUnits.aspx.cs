using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_CustomerUnits : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

        

        if (!IsPostBack)
        {
            CustomerFill();
            Masters.ArchitectMaster.ArchitectMaster_Select(ddlArchitect);
            General.GridBindwithCommand(hai, "Select * from Customer_Units,Architect_Master where Customer_Units.ARCNAME = Architect_Master.Architect_Id and CUST_ID = '" + Request.QueryString["Cid"].ToString() + "'");
            if (Qid != "Add")
            {

            }
        }
    }

    private void CustomerFill()
    {
        SM.CustomerMaster objmaster = new SM.CustomerMaster();
        if (objmaster.CustomerMaster_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Save";
            txtCompanyName.Text = objmaster.CompanyName;
            txtCustomerName.Text = objmaster.CustName;
            txtMobileNo.Text = objmaster.CustMobile;
            txtphoneno.Text = objmaster.custPhone;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                SM.CustomerMaster objMaster = new SM.CustomerMaster();
                objMaster.UnitName = txtCustomerUnitname.Text;
                objMaster.UnitAddress = txtunitaddress.Text;
                objMaster.NoofFloors = txtnooffloors.Text;
                objMaster.Winload = txtwinload.Text;
                objMaster.UnitContactPerson = txtsiteContactPerson.Text;
                objMaster.UnitMobileNo = txtSiteMobileNo.Text;
                objMaster.Custid = Request.QueryString["Cid"].ToString();

                objMaster.Arcname =ddlArchitect.SelectedItem.Value;
                objMaster.ArcMobile = txtarchitectMobileNo.Text;
                objMaster.Proname = txtprojectincargeperson.Text;
                objMaster.Promobile = txtprojectincargemobile.Text;

                objMaster.ContPerson2 = txtsitecontactperson2.Text;
                objMaster.ContPersonMobile2 = txtsitecontactmobile2.Text;

                objMaster.ContPerson3 = txtsitecontact3.Text;
                objMaster.ContPersonMobile3 = txtsitecontactmobile3.Text;

                objMaster.archiaddress = txtarchitectofficedetails.Text;
                objMaster.ArcEmail = txtarchitectemail.Text;
                objMaster.ProEmail = txtProjectIncargeEmail.Text;



                MessageBox.Notify(this, objMaster.CustomerUnitMaster_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
               // General.GridBindwithCommand(hai, "Select * from Customer_Units where CUST_ID = '" + Request.QueryString["Cid"].ToString() + "'");
                SM.Dispose();
                Response.Redirect("~/Modules/Sales/CustomerMaster.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                SM.CustomerMaster objMaster = new SM.CustomerMaster();
                objMaster.Custid = Request.QueryString["Cid"].ToString();
                objMaster.UnitName = txtCustomerUnitname.Text;
                objMaster.UnitAddress = txtunitaddress.Text;
                objMaster.NoofFloors = txtnooffloors.Text;
                objMaster.Winload = txtwinload.Text;
                objMaster.UnitContactPerson = txtsiteContactPerson.Text;
                objMaster.UnitMobileNo = txtSiteMobileNo.Text;
                objMaster.Unitid = hai.SelectedRow.Cells[0].Text;


                objMaster.Arcname = ddlArchitect.SelectedItem.Value;
                objMaster.ArcMobile = txtarchitectMobileNo.Text;
                objMaster.Proname = txtprojectincargeperson.Text;
                objMaster.Promobile = txtprojectincargemobile.Text;

                objMaster.ContPerson2 = txtsitecontactperson2.Text;
                objMaster.ContPersonMobile2 = txtsitecontactmobile2.Text;

                objMaster.ContPerson3 = txtsitecontact3.Text;
                objMaster.ContPersonMobile3 = txtsitecontactmobile3.Text;

                objMaster.archiaddress = txtarchitectofficedetails.Text;
                objMaster.ArcEmail = txtarchitectemail.Text;
                objMaster.ProEmail = txtProjectIncargeEmail.Text;

                MessageBox.Notify(this, objMaster.CustomerUnitMaster_Update());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

               // General.GridBindwithCommand(hai, "Select * from Customer_Units where CUST_ID = '" + Request.QueryString["Cid"].ToString() + "'");
                //txtnooffloors.Text = "";
                //txtwinload.Text = "";
                //txtunitaddress.Text = "";
                //txtCustomerUnitname.Text = "";

                //txtsiteContactPerson.Text = "";
                //txtSiteMobileNo.Text = "";

               // btnSave.Text = "Save";

                SM.Dispose();
                Response.Redirect("~/Modules/Sales/CustomerMaster.aspx");
            }
        }

    }
    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        LinkButton lbtnCompanyName;
        lbtnCompanyName = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnCompanyName.Parent.Parent;
        hai.SelectedIndex = gvRow.RowIndex;

        if (hai.SelectedIndex > -1)
        {
           
            
           SM.CustomerMaster obj = new SM.CustomerMaster();
            if(obj.CustomerUnitMaster_Select(hai.SelectedRow.Cells[0].Text) > 0)
            {

                txtunitaddress.Text =obj.UnitAddress;
                txtCustomerUnitname.Text = obj.UnitName;

                txtnooffloors.Text = obj.NoofFloors;
                txtwinload.Text = obj.Winload;
                txtSiteMobileNo.Text = obj.UnitMobileNo;
                txtsiteContactPerson.Text = obj.UnitContactPerson;


                ddlArchitect.SelectedValue = obj.Arcname;
                //txtarchitectMobileNo.Text = obj.ArcMobile;
                //txtprojectincargeperson.Text = obj.Proname;
                //txtprojectincargemobile.Text = obj.Promobile;
                ddlArchitect_SelectedIndexChanged(sender, e);

                txtsitecontactperson2.Text = obj.ContPerson2;
                txtsitecontactmobile2.Text = obj.ContPersonMobile2;

                txtsitecontact3.Text = obj.ContPerson3;
                txtsitecontactmobile3.Text = obj.ContPersonMobile3;
                txtarchitectofficedetails.Text = obj.archiaddress;
                txtarchitectemail.Text = obj.ArcEmail;
                txtProjectIncargeEmail.Text = obj.ProEmail;

            }

           






            btnSave.Text = "Update";
        }
        else
        {
            MessageBox.Show(this, "Please select atleast a Record");
        }
    }


    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        LinkButton lbtnRegionalMaster;
        lbtnRegionalMaster = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnRegionalMaster.Parent.Parent;
        hai.SelectedIndex = gvRow.RowIndex;

        if (hai.SelectedIndex > -1)
        {
            try
            {
                SM.CustomerMaster objSM = new SM.CustomerMaster();
                objSM.Unitid = hai.SelectedRow.Cells[0].Text;
                MessageBox.Notify(this, objSM.CustomerUnitMaster_Delete());
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                General.GridBindwithCommand(hai, "Select * from Customer_Units,Architect_Master where Customer_Units.ARCNAME = Architect_Master.Architect_Id and CUST_ID = '" + Request.QueryString["Cid"].ToString() + "'");
                SM.Dispose();
            }
        }
        else
        {
            MessageBox.Notify(this, "Please select atleast a Record");
        }
    }



    protected void ddlArchitect_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.ArchitectMaster objmaster = new Masters.ArchitectMaster();
        if (objmaster.ArchitectMaster_Select(ddlArchitect.SelectedItem.Value) > 0)
        {
           
            txtarchitectemail.Text = objmaster.Email;
            txtarchitectMobileNo.Text = objmaster.Mobile;
            txtarchitectofficedetails.Text = objmaster.Address;
        }
    }

    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;
        }
    }
}