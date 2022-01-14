using phani.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_ScarpStock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);
        if (!IsPostBack)
        {
            //General.GridBindwithCommand(hai,"select * from Supplier_PurchaseReceipt_Details,Material_Master,Plant_Master,StorageLocation_Master,Color_Master where Supplier_PurchaseReceipt_Details.MAT_ID = Material_Master.Material_Id and Supplier_PurchaseReceipt_Details.COLOR_ID = Color_Master.Color_Id and Supplier_PurchaseReceipt_Details.PLANT_ID = Plant_Master.Plant_Id and Supplier_PurchaseReceipt_Details.STORAGELOC_ID = StorageLocation_Master.StorageLoacation_Id and PO_REJECTED_QTY > 0");




            string chenna = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

            if (chenna == "1" || chenna == "30" || chenna == "7")
            {
                btnAddnew.Visible = true;
            }

            General.GridBindwithCommand(hai, "SELECT  Supplier_PurchaseReceipt.InvoiceNo,   Supplier_PurchaseReceipt_Details.SPR_DET_ID, Supplier_PurchaseReceipt_Details.PO_DET_COLOR, Supplier_PurchaseReceipt_Details.PO_DET_QTY, Supplier_PurchaseReceipt_Details.PO_RECEIVED_QTY, " +
                         "Supplier_PurchaseReceipt_Details.PO_REJECTED_QTY,Supplier_PurchaseReceipt_Details.PO_ACCEPTED_QTY, Supplier_PurchaseReceipt_Details.Remarks, Supplier_PurchaseReceipt_Details.Description , Supplier_PurchaseReceipt_Details.Lengthh, " +
                        " Material_Master.Material_Code , Color_Master.Color_Name, Sales_Order.ProjectCode, Supplier_PurchaseReceipt.SPR_NO, Supplier_PurchaseReceipt.SPR_DATE " +
"FROM  Supplier_PurchaseReceipt_Details INNER JOIN " +
                        " Material_Master ON Supplier_PurchaseReceipt_Details.MAT_ID = Material_Master.Material_Id INNER JOIN " +
                        " Color_Master ON Supplier_PurchaseReceipt_Details.COLOR_ID = Color_Master.Color_Id INNER JOIN " +
                        " Sales_Order ON Supplier_PurchaseReceipt_Details.SO_Id = Sales_Order.SalesOrder_Id INNER JOIN " +
                        " Supplier_PurchaseReceipt ON Supplier_PurchaseReceipt_Details.SPR_ID = Supplier_PurchaseReceipt.SPR_ID " +
"WHERE (Supplier_PurchaseReceipt_Details.PO_REJECTED_QTY > 0) and Supplier_PurchaseReceipt_Details.InStock != 'InTransit'");




        
        }
    }



    protected void btnAddnew_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/Modules/Stock/MRN_RejecedtoStock.aspx", false);
    }
    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           


            //  Label lblcou = (Label)GridView1.FindControl("Label1");
            // e.Row.Cells[7].Text = int.Parse(str+str1+str2).ToString() ;
            // string total = 0;


            //lblcou.Text = (Convert.ToDouble(e.Row.Cells[4].Text) + Convert.ToDouble(e.Row.Cells[5].Text) + Convert.ToDouble(e.Row.Cells[6].Text)).ToString();

            // lblcou.Text = total.ToString();

            // or you can try str == String.Empty in below condition as necessary.

            //string i = 0;


            //i =  (int.Parse(e.Row.Cells[6].Text) - int.Parse(e.Row.Cells[7].Text)).ToString();



            //if(i < 0)
            //{
            //    e.Row.Cells[8].Text = i.ToString();
            //}
            //else
            //{
            //    e.Row.Cells[8].Text = "0";
            //}
            //if (i > 0)
            //{
            //    e.Row.Cells[9].Text = i.ToString();
            //}
            //else
            //{
            //    e.Row.Cells[9].Text = "0";
            //}

            e.Row.Cells[9].Text = (Convert.ToDouble(e.Row.Cells[7].Text) - Convert.ToDouble(e.Row.Cells[8].Text)).ToString();

           





        }

    }
}