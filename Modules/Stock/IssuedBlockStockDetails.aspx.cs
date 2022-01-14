using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_IssuedBlockStockDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {

            SM.SalesOrder.SalesOrder_Select(ddlFromProject);
            SM.SalesOrder.SalesOrder_Select(ddlToProject);

            txtMrdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtMaterialreqestNo.Text = SCM.IssueBlockStockRealase.IssueBlockStockRealase_AutoGenCode();

            SCM.RequestBlockStockRealase.RequestBlockStockRealaseNo_SelectNotissued(ddlRequestedNo);

            HR.EmployeeMaster.EmployeeMaster_Select(ddlrequestedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            //ddlrequestedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
             
            ddlapprovedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            if (Qid != "Add")
            {
                SCM.RequestBlockStockRealase.RequestBlockStockRealaseNo_Select(ddlRequestedNo);
                GlassRequestFill();
            }
            
        }
    }

    private void GlassRequestFill()
    {
        SCM.IssueBlockStockRealase objmaster = new SCM.IssueBlockStockRealase();
        if (objmaster.IssueBlockStockRealase_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtMaterialreqestNo.Text = objmaster.IssueBlockNo;
            txtMrdate.Text = objmaster.IssueDate;



            ddlrequesttype.SelectedValue = objmaster.ReqPurpose;
            ddlrequestedby.SelectedValue = objmaster.RequestedBy;
            ddlapprovedby.SelectedValue = objmaster.ApprovedBy;

            ddlFromProject.SelectedValue = objmaster.FromSOId;
            ddlToProject.SelectedValue = objmaster.ToSoid;

            if (objmaster.RequestedBlockId != "0")
            {
                ddlRequestedNo.SelectedValue = objmaster.RequestedBlockId;
                ddlRequestedNo_SelectedIndexChanged(new object(), new System.EventArgs());

            }

           // ddlSono.SelectedValue = objmaster.SoId;
           // objmaster.GlassIssueDetails_Select(Request.QueryString["Cid"].ToString(), gvItems);

            General.GridBindwithCommand(GridView2, "SELECT UOM_SHORT_DESC,Color_Master.Color_Name, Material_Master.Material_Code, Uom_Master.UOM_LONG_DESC, Sales_Order.ProjectCode, Sales_Order_1.ProjectCode AS Expr1,  IssuedBlocked_Stock_Details.Issued_Block_Det_Id, IssuedBlocked_Stock_Details.IssuedBlock_Id, IssuedBlocked_Stock_Details.Item_Code,   IssuedBlocked_Stock_Details.Color_Id, IssuedBlocked_Stock_Details.Reqested_Qty,IssuedBlocked_Stock_Details.Issued_Qty, IssuedBlocked_Stock_Details.Remarks, IssuedBlocked_Stock_Details.FromSo_Id,  IssuedBlocked_Stock_Details.ToSo_Id, IssuedBlocked_Stock_Details.Length, Sales_Order_1.CustId, Sales_Order_1.CustSiteId FROM Sales_Order INNER JOIN  IssuedBlocked_Stock_Details INNER JOIN  Color_Master ON IssuedBlocked_Stock_Details.Color_Id = Color_Master.Color_Id INNER JOIN  Material_Master ON IssuedBlocked_Stock_Details.Item_Code = Material_Master.Material_Id INNER JOIN   Uom_Master ON Material_Master.UOM_Id = Uom_Master.UOM_ID ON Sales_Order.SalesOrder_Id = IssuedBlocked_Stock_Details.FromSo_Id INNER JOIN  Sales_Order AS Sales_Order_1 ON IssuedBlocked_Stock_Details.ToSo_Id = Sales_Order_1.SalesOrder_Id where IssuedBlocked_Stock_Details.IssuedBlock_Id  = '" + Request.QueryString["Cid"].ToString() + "'");

            


        }
    }
    protected void ddlRequestedNo_SelectedIndexChanged(object sender, EventArgs e)
    { 
        SCM.RequestBlockStockRealase obj = new SCM.RequestBlockStockRealase();
        if(obj.RequestBlockStockRelease_Select(ddlRequestedNo.SelectedItem.Value) > 0)
        {
            ddlFromProject.SelectedValue = obj.From_SO_Id;
            ddlToProject.SelectedValue = obj.To_SO_Id;
            ddlrequestedby.SelectedValue = obj.Prepared_By;

            General.GridBindwithCommand(GridView1, " SELECT  BlockedQty, UOM_SHORT_DESC,Color_Master.Color_Name, Material_Master.Material_Code, Uom_Master.UOM_LONG_DESC, Sales_Order.ProjectCode, Sales_Order_1.ProjectCode AS Expr1,  RequestBlockStock_Release_Details.RequestBlockRelase_Det_id, RequestBlockStock_Release_Details.RequestBlockRelase_Id, RequestBlockStock_Release_Details.ItemCode,   RequestBlockStock_Release_Details.ColorId, RequestBlockStock_Release_Details.ReqQty, RequestBlockStock_Release_Details.Remarks, RequestBlockStock_Release_Details.From_So_Id,  RequestBlockStock_Release_Details.To_So_Id, RequestBlockStock_Release_Details.Length, RequestBlockStock_Release_Details.BlockStockDetId, Sales_Order_1.CustId, Sales_Order_1.CustSiteId FROM Sales_Order INNER JOIN  RequestBlockStock_Release_Details INNER JOIN  Color_Master ON RequestBlockStock_Release_Details.ColorId = Color_Master.Color_Id INNER JOIN  Material_Master ON RequestBlockStock_Release_Details.ItemCode = Material_Master.Material_Id INNER JOIN   Uom_Master ON Material_Master.UOM_Id = Uom_Master.UOM_ID ON Sales_Order.SalesOrder_Id = RequestBlockStock_Release_Details.From_So_Id INNER JOIN  Sales_Order AS Sales_Order_1 ON RequestBlockStock_Release_Details.To_So_Id = Sales_Order_1.SalesOrder_Id where RequestBlockStock_Release_Details.RequestBlockRelase_Id = '" + ddlRequestedNo.SelectedItem.Value + "'");



        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SCM.IssueBlockStockRealase objMaster = new SCM.IssueBlockStockRealase();

            objMaster.IssueBlockNo = txtMaterialreqestNo.Text;
            objMaster.IssueDate = General.toMMDDYYYY(txtMrdate.Text);
            objMaster.ReqPurpose = ddlrequesttype.SelectedItem.Value;
            objMaster.ApprovedBy = ddlapprovedby.SelectedItem.Value;
            objMaster.RequestedBy = ddlrequestedby.SelectedItem.Value;
            objMaster.FromSOId = ddlFromProject.SelectedItem.Value;
            objMaster.ToSoid = ddlToProject.SelectedItem.Value;
            objMaster.RequestedBlockId = ddlRequestedNo.SelectedItem.Value;
            if (objMaster.IssueBlockStockRealase_Save() == "Data Saved Successfully")
            {
                foreach (GridViewRow gvRowOtherCorp in GridView1.Rows)
                {
                    objMaster.Itemcode = gvRowOtherCorp.Cells[13].Text;
                    objMaster.ColorId = gvRowOtherCorp.Cells[14].Text;
                    objMaster.Length = gvRowOtherCorp.Cells[4].Text;
                    TextBox Remarks = (TextBox)gvRowOtherCorp.FindControl("txtitemRemarks");
                    objMaster.Remarks = Remarks.Text;
                    objMaster.ReqQty = gvRowOtherCorp.Cells[5].Text;
                    TextBox qty = (TextBox)gvRowOtherCorp.FindControl("txtitemqty");
                    objMaster.IssuedQty = qty.Text;
                    objMaster.FromSOId = ddlFromProject.SelectedItem.Value;
                    objMaster.ToSoid = ddlToProject.SelectedItem.Value;
                    objMaster.Oldblockedqty = gvRowOtherCorp.Cells[15].Text;
                    objMaster.BlockStockDetId = gvRowOtherCorp.Cells[12].Text;
                    objMaster.IssueBlockStockRealase_Details_Save();


                    objMaster.Custid = gvRowOtherCorp.Cells[10].Text;
                    objMaster.SiteId = gvRowOtherCorp.Cells[11].Text;

                    if (objMaster.FromSOId != "0" && objMaster.ToSoid != "0")
                    {
                        objMaster.TransferBlockStockfrompartytoparty_Update();
                    }

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
            SCM.ClearControls(this);
            SCM.Dispose();
            Response.Redirect("~/Modules/Stock/IssuedBlockStock.aspx");
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;

            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;

        }
    }
}