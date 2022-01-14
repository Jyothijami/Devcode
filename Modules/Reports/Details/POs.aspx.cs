using phani.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Reports_Details_POs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (Qid != "0")
        {
            General.GridBindwithCommand(hai, "SELECT        Supplier_Po_Master.CustomerNo, Supplier_Po_Master.Sup_PO_Id, Supplier_Po_Master.Sup_PO_No, Supplier_Po_Master.Sup_PO_Date, Supplier_Quotation_Master.Sup_Quo_No,"+ 
                         "Supplier_Quotation_Master.Sup_Quo_Date, Supplier_Master.SUP_NAME, Supplier_Master.SUP_MOBILE, Employee_Master.EMP_FIRST_NAME + '' + Employee_Master.EMP_LAST_NAME AS preparedby,"+ 
                         "Supplier_Po_Details.SO_Id, Material_Master.Material_Code, Color_Master.Color_Name, Supplier_Po_Details.Length, Supplier_Po_Details.ReqQty, Supplier_Po_Details.RemainingQty, "+
                         "Supplier_Po_Details.Amount"+
                         "FROM Supplier_Po_Master INNER JOIN"+
                         "Supplier_Master ON Supplier_Po_Master.Sup_Id = Supplier_Master.SUP_ID INNER JOIN"+
                         "Supplier_Quotation_Master ON Supplier_Po_Master.Matrequest_Id = Supplier_Quotation_Master.Sup_Quo_Id INNER JOIN"+
                         "Employee_Master ON Supplier_Po_Master.PreparedBy = Employee_Master.EMP_ID INNER JOIN"+
                         "Supplier_Po_Details ON Supplier_Po_Master.Sup_PO_Id = Supplier_Po_Details.Sup_PO_Id INNER JOIN"+
                         "Material_Master ON Supplier_Po_Details.ItemCode = Material_Master.Material_Id INNER JOIN"+
                         "Color_Master ON Supplier_Po_Details.Color_Id = Color_Master.Color_Id" +
                         "where Supplier_Po_Details.SO_Id = '" + Qid + "' ORDER BY Supplier_Po_Master.Sup_PO_Id DESC ");
        }
    }
}