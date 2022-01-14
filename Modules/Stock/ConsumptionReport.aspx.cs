using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using phani.Classes;
using Phani.Modules;
using phani.MessageBox;
public partial class Modules_Stock_ConsumptionReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);
        if(!IsPostBack)
        {
            SM.SalesOrder.SalesOrder_Select(ddlprojects);


          
        }
    }
    //protected void ddlprojects_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //if (ddlprojects.SelectedItem.Value != "0")
    //    //{
    //    //    General.GridBindwithCommand(GridView1, "select FORMAT (Material_Issue.Issue_Date, 'dd-MM-yy') as Dateissued  ,'Material Issue' as issued,ProjectCode,   Material_Code,Color_Name,Length,Issued_Qty,Material_Issue_Details.Remarks from Material_Issue_Details,Material_Master,Sales_Order,Color_Master,Material_Issue where  Sales_Order.SalesOrder_Id = Material_Issue_Details.So_Id and Material_Issue_Details.Item_Code = Material_Master.Material_Id and  Color_Master.Color_Id = Material_Issue_Details.Color_Id and   Material_Issue.Issue_Id = Material_Issue_Details.Issue_Id and  Material_Issue.So_Id = '" + ddlprojects.SelectedItem.Value + "' union  select FORMAT (  NRGP.NRgp_Date, 'dd-MM-yy') as Dateissued ,'NRGP' as issued, ProjectCode,  Material_Code,Color_Name,Length, qty,NRGP_Details.Remarks from NRGP_Details,Material_Master,Sales_Order,Color_Master,NRGP where Sales_Order.SalesOrder_Id = NRGP_Details.ProjectId and  NRGP_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = NRGP_Details.Color_Id and NRGP.NRGP_Id = NRGP_Details.NRgp_Id and NRGP.ProjectId = '" + ddlprojects.SelectedItem.Value + "' union  select  FORMAT (Packing_List.PackingList_Date, 'dd-MM-yy') as Dateissued  ,'Packing List' as issued,ProjectCode, Material_Code,Color_Name,Length,Qty,PackingList_Details.Remarks from PackingList_Details,Material_Master,Sales_Order,Color_Master,Packing_List where Sales_Order.SalesOrder_Id = PackingList_Details.SO_Id and  PackingList_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = PackingList_Details.Color_Id and Packing_List.PackingList_Id = PackingList_Details.PL_Id   and Packing_List.SO_Id = '" + ddlprojects.SelectedItem.Value + "' ");

    //    //}

      
    //    //if(ddlprojects.SelectedItem.Value != "0"   && txtfromdate.Text == "" && txttodate.Text == "")
    //    //{

    //    //    string from = txtfromdate.Text;
    //    //    string to = txttodate.Text;

    //    //    General.GridBindwithCommand(GridView1, "select FORMAT (Material_Issue.Issue_Date, 'dd-MM-yy') as Dateissued  ,'Material Issue' as issued,ProjectCode,   Material_Code,Color_Name,Length,Issued_Qty,Material_Issue_Details.Remarks from Material_Issue_Details,Material_Master,Sales_Order,Color_Master,Material_Issue where  Sales_Order.SalesOrder_Id = Material_Issue_Details.So_Id and Material_Issue_Details.Item_Code = Material_Master.Material_Id and  Color_Master.Color_Id = Material_Issue_Details.Color_Id and   Material_Issue.Issue_Id = Material_Issue_Details.Issue_Id and Material_Issue.Issue_Date between '" + from + "' and '" + to + "'   and  Material_Issue.So_Id = '" + ddlprojects.SelectedItem.Value + "' union  select FORMAT (  NRGP.NRgp_Date, 'dd-MM-yy') as Dateissued ,'NRGP' as issued, ProjectCode,  Material_Code,Color_Name,Length, qty,NRGP_Details.Remarks from NRGP_Details,Material_Master,Sales_Order,Color_Master,NRGP where Sales_Order.SalesOrder_Id = NRGP_Details.ProjectId and  NRGP_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = NRGP_Details.Color_Id and NRGP.NRGP_Id = NRGP_Details.NRgp_Id and NRGP.NRgp_Date between '" + from + "' and '" + to + "' and NRGP.ProjectId = '" + ddlprojects.SelectedItem.Value + "' union  select FORMAT (Packing_List.PackingList_Date, 'dd-MM-yy') as Dateissued  ,'Packing List' as issued,ProjectCode, Material_Code,Color_Name,Length,Qty,PackingList_Details.Remarks from PackingList_Details,Material_Master,Sales_Order,Color_Master,Packing_List where Sales_Order.SalesOrder_Id = PackingList_Details.SO_Id and  PackingList_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = PackingList_Details.Color_Id and Packing_List.PackingList_Id = PackingList_Details.PL_Id and Packing_List.PackingList_Date between '" + from + "' and '" + to + "'  and Packing_List.SO_Id = '" + ddlprojects.SelectedItem.Value + "'");
    //    //}
    //    //else
    //    //{
    //    //    General.GridBindwithCommand(GridView1, "select FORMAT (Material_Issue.Issue_Date, 'dd-MM-yy') as Dateissued  ,'Material Issue' as issued,ProjectCode,   Material_Code,Color_Name,Length,Issued_Qty,Material_Issue_Details.Remarks from Material_Issue_Details,Material_Master,Sales_Order,Color_Master,Material_Issue where  Sales_Order.SalesOrder_Id = Material_Issue_Details.So_Id and Material_Issue_Details.Item_Code = Material_Master.Material_Id and  Color_Master.Color_Id = Material_Issue_Details.Color_Id and   Material_Issue.Issue_Id = Material_Issue_Details.Issue_Id and  Material_Issue.So_Id = '" + ddlprojects.SelectedItem.Value + "' union  select FORMAT (  NRGP.NRgp_Date, 'dd-MM-yy') as Dateissued ,'NRGP' as issued, ProjectCode,  Material_Code,Color_Name,Length, qty,NRGP_Details.Remarks from NRGP_Details,Material_Master,Sales_Order,Color_Master,NRGP where Sales_Order.SalesOrder_Id = NRGP_Details.ProjectId and  NRGP_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = NRGP_Details.Color_Id and NRGP.NRGP_Id = NRGP_Details.NRgp_Id and NRGP.ProjectId = '" + ddlprojects.SelectedItem.Value + "' union  select  FORMAT (Packing_List.PackingList_Date, 'dd-MM-yy') as Dateissued  ,'Packing List' as issued,ProjectCode, Material_Code,Color_Name,Length,Qty,PackingList_Details.Remarks from PackingList_Details,Material_Master,Sales_Order,Color_Master,Packing_List where Sales_Order.SalesOrder_Id = PackingList_Details.SO_Id and  PackingList_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = PackingList_Details.Color_Id and Packing_List.PackingList_Id = PackingList_Details.PL_Id   and Packing_List.SO_Id = '" + ddlprojects.SelectedItem.Value + "' ");

    //    //}


    //}















    protected void btnfromto_Click(object sender, EventArgs e)
    {

        string from = txtfromdate.Text;
        string to = txttodate.Text;

        if (txtfromdate.Text == "" && txttodate.Text == "" && ddlprojects.SelectedItem.Value != "0")
        {
            General.GridBindwithCommand(GridView1, "select FORMAT (Material_Issue.Issue_Date, 'dd-MM-yy') as Dateissued  ,'Material Issue' as issued,ProjectCode,   Material_Code,Material_Master.Description,Color_Name,Length,Issued_Qty,Material_Issue_Details.Remarks from Material_Issue_Details,Material_Master,Sales_Order,Color_Master,Material_Issue where  Sales_Order.SalesOrder_Id = Material_Issue_Details.So_Id and Material_Issue_Details.Item_Code = Material_Master.Material_Id and  Color_Master.Color_Id = Material_Issue_Details.Color_Id and   Material_Issue.Issue_Id = Material_Issue_Details.Issue_Id and  Material_Issue.So_Id = '" + ddlprojects.SelectedItem.Value + "' union  select FORMAT (  NRGP.NRgp_Date, 'dd-MM-yy') as Dateissued ,'NRGP' as issued, ProjectCode,  Material_Code, Material_Master.Description,Color_Name,Length, qty,NRGP_Details.Remarks from NRGP_Details,Material_Master,Sales_Order,Color_Master,NRGP where Sales_Order.SalesOrder_Id = NRGP_Details.ProjectId and  NRGP_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = NRGP_Details.Color_Id and NRGP.NRGP_Id = NRGP_Details.NRgp_Id and NRGP.ProjectId = '" + ddlprojects.SelectedItem.Value + "' union  select  FORMAT (Packing_List.PackingList_Date, 'dd-MM-yy') as Dateissued  ,'Packing List' as issued,ProjectCode, Material_Code,Material_Master.Description,Color_Name,Length,Qty,PackingList_Details.Remarks from PackingList_Details,Material_Master,Sales_Order,Color_Master,Packing_List where Sales_Order.SalesOrder_Id = PackingList_Details.SO_Id and  PackingList_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = PackingList_Details.Color_Id and Packing_List.PackingList_Id = PackingList_Details.PL_Id   and Packing_List.SO_Id = '" + ddlprojects.SelectedItem.Value + "' ");

        }
        else if (txtfromdate.Text != "" && txttodate.Text != "" && ddlprojects.SelectedItem.Value == "0")
        {
            General.GridBindwithCommand(GridView1, "select FORMAT (Material_Issue.Issue_Date, 'dd-MM-yy') as Dateissued  ,'Material Issue' as issued,ProjectCode,   Material_Code,Material_Master.Description,Color_Name,Length,Issued_Qty,Material_Issue_Details.Remarks from Material_Issue_Details,Material_Master,Sales_Order,Color_Master,Material_Issue where  Sales_Order.SalesOrder_Id = Material_Issue_Details.So_Id and Material_Issue_Details.Item_Code = Material_Master.Material_Id and  Color_Master.Color_Id = Material_Issue_Details.Color_Id and   Material_Issue.Issue_Id = Material_Issue_Details.Issue_Id and Material_Issue.Issue_Date between '" + from + "' and '" + to + "'  union  select FORMAT (  NRGP.NRgp_Date, 'dd-MM-yy') as Dateissued ,'NRGP' as issued, ProjectCode,  Material_Code,Material_Master.Description,Color_Name,Length, qty,NRGP_Details.Remarks from NRGP_Details,Material_Master,Sales_Order,Color_Master,NRGP where Sales_Order.SalesOrder_Id = NRGP_Details.ProjectId and  NRGP_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = NRGP_Details.Color_Id and NRGP.NRGP_Id = NRGP_Details.NRgp_Id and NRGP.NRgp_Date between '" + from + "' and '" + to + "'  union  select    FORMAT (Packing_List.PackingList_Date, 'dd-MM-yy') as Dateissued  ,'Packing List' as issued,ProjectCode, Material_Code,Material_Master.Description,Color_Name,Length,Qty,PackingList_Details.Remarks from PackingList_Details,Material_Master,Sales_Order,Color_Master,Packing_List where Sales_Order.SalesOrder_Id = PackingList_Details.SO_Id and  PackingList_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = PackingList_Details.Color_Id and Packing_List.PackingList_Id = PackingList_Details.PL_Id and Packing_List.PackingList_Date between '" + from + "' and '" + to + "' ");
        }
        else if (txtfromdate.Text != "" && txttodate.Text != "" && ddlprojects.SelectedItem.Value != "0")
        {
            General.GridBindwithCommand(GridView1, "select FORMAT (Material_Issue.Issue_Date, 'dd-MM-yy') as Dateissued  ,'Material Issue' as issued,ProjectCode,   Material_Code,Material_Master.Description,Color_Name,Length,Issued_Qty,Material_Issue_Details.Remarks from Material_Issue_Details,Material_Master,Sales_Order,Color_Master,Material_Issue where  Sales_Order.SalesOrder_Id = Material_Issue_Details.So_Id and Material_Issue_Details.Item_Code = Material_Master.Material_Id and  Color_Master.Color_Id = Material_Issue_Details.Color_Id and   Material_Issue.Issue_Id = Material_Issue_Details.Issue_Id and Material_Issue.Issue_Date between '" + from + "' and '" + to + "'   and  Material_Issue.So_Id = '" + ddlprojects.SelectedItem.Value + "' union  select FORMAT (  NRGP.NRgp_Date, 'dd-MM-yy') as Dateissued ,'NRGP' as issued, ProjectCode,  Material_Code,Material_Master.Description,Color_Name,Length, qty,NRGP_Details.Remarks from NRGP_Details,Material_Master,Sales_Order,Color_Master,NRGP where Sales_Order.SalesOrder_Id = NRGP_Details.ProjectId and  NRGP_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = NRGP_Details.Color_Id and NRGP.NRGP_Id = NRGP_Details.NRgp_Id and NRGP.NRgp_Date between '" + from + "' and '" + to + "' and NRGP.ProjectId = '" + ddlprojects.SelectedItem.Value + "' union  select FORMAT (Packing_List.PackingList_Date, 'dd-MM-yy') as Dateissued  ,'Packing List' as issued,ProjectCode, Material_Code,Material_Master.Description,Color_Name,Length,Qty,PackingList_Details.Remarks from PackingList_Details,Material_Master,Sales_Order,Color_Master,Packing_List where Sales_Order.SalesOrder_Id = PackingList_Details.SO_Id and  PackingList_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = PackingList_Details.Color_Id and Packing_List.PackingList_Id = PackingList_Details.PL_Id and Packing_List.PackingList_Date between '" + from + "' and '" + to + "'  and Packing_List.SO_Id = '" + ddlprojects.SelectedItem.Value + "'");

        }

        else if (txtfromdate.Text == "" && txttodate.Text == "" && ddlprojects.SelectedItem.Value == "0")
        {
            MessageBox.Show(this, "Please enter from and to dates");
        }




        //if(txtfromdate.Text == "" && txttodate.Text == "")
        //{
        //    MessageBox.Show(this, "Please enter from and to dates");
        //}
        //else
        //{
        //    //string from = General.toMMDDYYYY(txtfromdate.Text);
        //    //string to = General.toMMDDYYYY(txttodate.Text);
          


        //    General.GridBindwithCommand(GridView1, "select FORMAT (Material_Issue.Issue_Date, 'dd-MM-yy') as Dateissued  ,'Material Issue' as issued,ProjectCode,   Material_Code,Color_Name,Length,Issued_Qty,Material_Issue_Details.Remarks from Material_Issue_Details,Material_Master,Sales_Order,Color_Master,Material_Issue where  Sales_Order.SalesOrder_Id = Material_Issue_Details.So_Id and Material_Issue_Details.Item_Code = Material_Master.Material_Id and  Color_Master.Color_Id = Material_Issue_Details.Color_Id and   Material_Issue.Issue_Id = Material_Issue_Details.Issue_Id and Material_Issue.Issue_Date between '" + from + "' and '" + to + "'  union  select FORMAT (  NRGP.NRgp_Date, 'dd-MM-yy') as Dateissued ,'NRGP' as issued, ProjectCode,  Material_Code,Color_Name,Length, qty,NRGP_Details.Remarks from NRGP_Details,Material_Master,Sales_Order,Color_Master,NRGP where Sales_Order.SalesOrder_Id = NRGP_Details.ProjectId and  NRGP_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = NRGP_Details.Color_Id and NRGP.NRGP_Id = NRGP_Details.NRgp_Id and NRGP.NRgp_Date between '" + from + "' and '" + to + "'  union  select    FORMAT (Packing_List.PackingList_Date, 'dd-MM-yy') as Dateissued  ,'Packing List' as issued,ProjectCode, Material_Code,Color_Name,Length,Qty,PackingList_Details.Remarks from PackingList_Details,Material_Master,Sales_Order,Color_Master,Packing_List where Sales_Order.SalesOrder_Id = PackingList_Details.SO_Id and  PackingList_Details.Item_Id = Material_Master.Material_Id and Color_Master.Color_Id = PackingList_Details.Color_Id and Packing_List.PackingList_Id = PackingList_Details.PL_Id and Packing_List.PackingList_Date between '" + from + "' and '" + to + "' ");

        //}

    }
}