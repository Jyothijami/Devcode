using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_BlockTransferSO : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);

        if (!IsPostBack)
        {
            SM.SalesOrder.SalesOrderProjectcode_Select(txtPrjtcode);
            hai.DataBind();
        }
    }

    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlSo = (DropDownList)e.Row.FindControl("ddlSoId");
            SM.SalesOrder.SalesOrder_Select(ddlSo);
           
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        hai.DataSource = null;
        hai.DataBind();

        SqlCommand cmd = new SqlCommand("[USP_FreeBlock_Serach]", con);
        cmd.CommandType = CommandType.StoredProcedure;


        if (txtPrjtcode.SelectedItem.Value != "0")
        {
            cmd.Parameters.AddWithValue("@ProjectCode", txtPrjtcode.SelectedItem.Text);
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        hai.DataSource = dt;
        hai.DataBind();
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
                SCM.ReserveStock objSM = new SCM.ReserveStock();

                objSM.ReserveDetid = hai.SelectedRow.Cells[0].Text;
              

                TextBox remarks = (TextBox)gvRow.FindControl("txtitemRemarks");
                objSM.Remarks = remarks.Text;

                DropDownList so = (DropDownList)gvRow.FindControl("ddlSoId");
                objSM.Soid = so.SelectedItem.Value;

                if(objSM.Soid != "0")
                {
                    MessageBox.Show(this, objSM.ReserveBlockSOStock_Update());
                }
                else
                {
                    MessageBox.Show(this, "Please Select Sales order No to transfer");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                hai.DataBind();
                SCM.Dispose();
            }
        }
        else
        {
            MessageBox.Notify(this, "Please select atleast a Record");
        }
    }





    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        SCM.ReserveStock objSM = new SCM.ReserveStock();
        foreach (GridViewRow gvrow in hai.Rows)
        {

           // SCM.ReserveStock objSM = new SCM.ReserveStock();

            objSM.ReserveDetid = gvrow.Cells[0].Text;


            TextBox remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
            objSM.Remarks = remarks.Text;

            DropDownList so = (DropDownList)gvrow.FindControl("ddlSoId");
            objSM.Soid = so.SelectedItem.Value;

            if (objSM.Soid != "0")
            {
                MessageBox.Show(this, objSM.ReserveBlockSOStock_Update());



              //  objSM.BlockStock_Update2(objSM.Itemcode, objSM.Qty, objSM.ColorId, objSM.Length, objSM.Soid, objSM.ProjectId, objSM.Remarks);




            }
          

        }

        MessageBox.Show(this, "Data Updated Sucessfully");
        btnSearch_Click(sender, e);
    }
}