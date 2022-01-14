using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
public partial class Modules_Stock_GlassRequest : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {

            SM.SalesOrder.SalesOrder_Select(ddlPono);
            SM.SalesOrder.SalesOrder_Select(ddlToPono);

            txtMrdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtMaterialreqestNo.Text = SCM.RequestBlockStockRealase.RequestBlockStockRealase_AutoGenCode();
            txtrequireddate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            
            HR.EmployeeMaster.EmployeeMaster_Select(ddlrequestedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            ddlrequestedby .SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            //ddlapprovedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            if (Qid != "Add")
            {
                btnApprove.Visible = true;
                GlassRequestFill();
            }
            else
            {
                btnApprove.Visible = false;
            }
        }
    }
    private void GlassRequestFill()
    {
        SCM.RequestBlockStockRealase objmaster = new SCM.RequestBlockStockRealase();
        if (objmaster.RequestBlockStockRelease_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtMaterialreqestNo.Text = objmaster.RequestBlockStockRealase_No ;
            txtMrdate.Text = objmaster.Required_Date;
            ddlrequesttype.SelectedValue = objmaster.Request_Type ;
            ddlrequestedby.SelectedValue = objmaster.Prepared_By;
            ddlPono.SelectedValue = objmaster.From_SO_Id;
            ddlToPono.SelectedValue = objmaster.To_SO_Id;
            ddlapprovedby.SelectedValue = objmaster.Approved_By;
            txtrequireddate.Text = objmaster.Required_Date;

           // ddlPono_SelectedIndexChanged (new object(),new System .EventArgs ());


            General.GridBindwithCommand(GridView1, " SELECT   UOM_SHORT_DESC,Color_Master.Color_Name, Material_Master.Material_Code, Uom_Master.UOM_LONG_DESC, Sales_Order.ProjectCode, Sales_Order_1.ProjectCode AS Expr1,  RequestBlockStock_Release_Details.RequestBlockRelase_Det_id, RequestBlockStock_Release_Details.RequestBlockRelase_Id, RequestBlockStock_Release_Details.ItemCode,   RequestBlockStock_Release_Details.ColorId, RequestBlockStock_Release_Details.ReqQty, RequestBlockStock_Release_Details.Remarks, RequestBlockStock_Release_Details.From_So_Id,  RequestBlockStock_Release_Details.To_So_Id, RequestBlockStock_Release_Details.Length, RequestBlockStock_Release_Details.BlockStockDetId FROM Sales_Order INNER JOIN  RequestBlockStock_Release_Details INNER JOIN  Color_Master ON RequestBlockStock_Release_Details.ColorId = Color_Master.Color_Id INNER JOIN  Material_Master ON RequestBlockStock_Release_Details.ItemCode = Material_Master.Material_Id INNER JOIN   Uom_Master ON Material_Master.UOM_Id = Uom_Master.UOM_ID ON Sales_Order.SalesOrder_Id = RequestBlockStock_Release_Details.From_So_Id INNER JOIN  Sales_Order AS Sales_Order_1 ON RequestBlockStock_Release_Details.To_So_Id = Sales_Order_1.SalesOrder_Id where RequestBlockStock_Release_Details.RequestBlockRelase_Id = '" + Request.QueryString["Cid"].ToString() + "'");




            if (objmaster.Approved_By  != "0")
            {
                btnApprove.Visible = false;
                btnSave.Visible = false;

                string palash = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
                string chenna = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

                if (palash == "7" || chenna == "42" || palash == "0")
                {
                    btnSave.Visible = true;
                    btnApprove.Visible = true;
                }



            }
           // objmaster.RequestBlockStockReleaseDetails_Select(Request.QueryString["Cid"].ToString(), GridView1);

        }
    }
    protected void ddlPono_SelectedIndexChanged(object sender, EventArgs e)
    {


        //SCM.GlassPo obj = new SCM.GlassPo();

        //if (ddlPono.SelectedItem.Value != "0")
        //{
        //    obj.SupPoOrderQtybysoStock_Select(ddlPono.SelectedItem.Value, GridView1);

        //}

        //SqlCommand cmd = new SqlCommand("[USP_FreeBlock_Serach]", con);
        //cmd.CommandType = CommandType.StoredProcedure;


        //if (ddlPono.SelectedItem.Value != "0")
        //{
        //    cmd.Parameters.AddWithValue("@ProjectId", ddlPono.SelectedItem.Value);
        //}
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataTable dt = new DataTable();
        //da.Fill(dt);
        //hai.DataSource = dt;
        //hai.DataBind();



        General.GridBindwithCommand(hai, "SELECT  Stock_Block.Color_Id,Stock_Block.Item_Code, Stock_Block.BlockStock_Id, Sales_Order.SalesOrder_No, Color_Master.Color_Name, Material_Master.Material_Code, Material_Master.Description, Uom_Master.UOM_SHORT_DESC, Stock_Block.Length as blocklength,  Stock_Block.Qty, Stock_Block.Remarks, Sales_Order.ProjectCode, Customer_Master.CUST_NAME, Customer_Units.CUST_UNIT_NAME FROM Stock_Block LEFT OUTER JOIN Sales_Order ON Stock_Block.So_Id = Sales_Order.SalesOrder_Id LEFT OUTER JOIN Color_Master ON Stock_Block.Color_Id = Color_Master.Color_Id LEFT OUTER JOIN Material_Master ON Stock_Block.Item_Code = Material_Master.Material_Id LEFT OUTER JOIN Customer_Units ON Stock_Block.Project_Id = Customer_Units.CUST_UNIT_ID LEFT OUTER JOIN Customer_Master ON Stock_Block.Cust_Id = Customer_Master.CUST_ID LEFT OUTER JOIN Uom_Master ON Material_Master.UOM_Id = Uom_Master.UOM_ID  where Stock_Block.Qty > 0 and Stock_Block.So_Id ='" + ddlPono.SelectedItem.Value + "' order by BlockStock_Id asc ");

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
            SCM.RequestBlockStockRealase objMaster = new SCM.RequestBlockStockRealase();

            objMaster.RequestBlockStockRealase_No = txtMaterialreqestNo.Text;
            objMaster.Required_Date = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.Request_Type = ddlrequesttype.SelectedItem.Value;
            objMaster.Requested_date = General.toMMDDYYYY(txtrequireddate.Text);
            objMaster.Requested_for = ddlToPono.SelectedItem.Text;
            objMaster.From_SO_Id = ddlPono.SelectedItem.Value;
            objMaster.To_SO_Id = ddlToPono.SelectedItem.Value;
            objMaster.Status = "";
            objMaster.TermsCondition_Id = "0";
            objMaster.Prepared_By = ddlrequestedby.SelectedItem.Value;
            objMaster.Approved_By = ddlapprovedby.SelectedItem.Value;
            objMaster.RequestBlockStockRealase_Id = Request.QueryString["Cid"].ToString();

            if (objMaster.RequestBlockStockRelease_Update() == "Data Updated Successfully")
            {
                objMaster.RequestBlockStock_Release_Details_Delete(Request.QueryString["Cid"].ToString());
                foreach (GridViewRow gvrow in hai.Rows)
                {
                    TextBox recqty = (TextBox)gvrow.FindControl("txtitemqty");
                    objMaster.Reqqty = recqty.Text;
                    if (objMaster.Reqqty != "0")
                    {
                        objMaster.Itemcode = gvrow.Cells[9].Text;
                        objMaster.ColorId = gvrow.Cells[10].Text;
                        objMaster.Reqqty = recqty.Text;
                        TextBox Remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                        objMaster.Remarks = Remarks.Text;
                        objMaster.From_SO_Id = ddlPono.SelectedItem.Value;
                        objMaster.To_SO_Id = ddlToPono.SelectedItem.Value;
                        objMaster.blockedqty = gvrow.Cells[6].Text;
                        objMaster.Length = gvrow.Cells[5].Text;
                        objMaster.BlockDetId = gvrow.Cells[0].Text;
                        objMaster.RequestBlockStockRelease_Details_Save();

                    }
                }
                MessageBox.Show(this, "Data Saved Successfully");

            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Response.Redirect("~/Modules/Stock/RequestBlockStockL.aspx");
        }
    }

    private void po_Save()
    {
        try
        {
            SCM.RequestBlockStockRealase objMaster = new SCM.RequestBlockStockRealase();

            objMaster.RequestBlockStockRealase_No = txtMaterialreqestNo.Text;
            objMaster.Required_Date = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.Request_Type = ddlrequesttype.SelectedItem.Value;
            objMaster.Requested_date = General.toMMDDYYYY(txtrequireddate.Text);
            objMaster.Requested_for = ddlToPono.SelectedItem.Text;
            objMaster.From_SO_Id = ddlPono.SelectedItem.Value;
            objMaster.To_SO_Id = ddlToPono.SelectedItem.Value;
            objMaster.Status = "";
            objMaster.TermsCondition_Id = "0";
            objMaster.Prepared_By = ddlrequestedby.SelectedItem.Value;
            objMaster.Approved_By = ddlapprovedby.SelectedItem.Value;
            if (objMaster.RequestBlockStockRealase_Save() == "Data Saved Successfully")
            {
                objMaster.RequestBlockStock_Release_Details_Delete(objMaster.RequestBlockStockRealase_Id);
                foreach (GridViewRow gvrow in hai.Rows)
                {
                    TextBox recqty = (TextBox)gvrow.FindControl("txtitemqty");
                    objMaster.Reqqty = recqty.Text;
                    if (objMaster.Reqqty != "0" )
                    {
                        objMaster.Itemcode = gvrow.Cells[9].Text;
                        objMaster.ColorId = gvrow.Cells[10].Text;
                        objMaster.Reqqty = recqty.Text;
                        TextBox Remarks = (TextBox)gvrow.FindControl("txtitemRemarks");
                        objMaster.Remarks = Remarks.Text;
                        objMaster.From_SO_Id = ddlPono.SelectedItem.Value;
                        objMaster.To_SO_Id = ddlToPono.SelectedItem.Value;
                        objMaster.blockedqty = gvrow.Cells[6].Text;
                        objMaster.Length = gvrow.Cells[5].Text;
                        objMaster.BlockDetId = gvrow.Cells[0].Text;
                        objMaster.RequestBlockStockRelease_Details_Save();

                    }
                }
                MessageBox.Show(this, "Data Saved Successfully");

            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            Response.Redirect("~/Modules/Stock/RequestBlockStockL.aspx");
        }
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            SCM.RequestBlockStockRealase objSMSOApprove = new SCM.RequestBlockStockRealase();
            objSMSOApprove.RequestBlockStockRealase_Id = Request.QueryString["Cid"].ToString();
            objSMSOApprove.Approved_By  = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSMSOApprove.RequestBlockStockReleaseApprove_Update();

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Response.Redirect("~/Modules/Stock/RequestBlockStockL.aspx");
        }
    }

    
    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;

        }
    }
}