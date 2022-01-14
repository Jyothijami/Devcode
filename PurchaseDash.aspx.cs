using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using phani.Classes;
using System.Globalization;

public partial class PurchaseDash : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            General.GridBindwithCommand(GridView2, "select * from DashBoard_Purchase,Sales_Order,Customer_Units where DashBoard_Purchase.So_Id = Sales_Order.SalesOrder_Id and Sales_Order.CustSiteId = Customer_Units.CUST_UNIT_ID");
        }
    }

   
    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = "Project";
        cell.BackColor = ColorTranslator.FromHtml("#000000");
        //cell.HorizontalAlign = HorizontalAlign.Center;
        cell.Attributes.CssStyle["text-align"] = "center";
        cell.ColumnSpan = 3;
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 2;
        cell.Text = "Shop Drawings";
        row.Controls.Add(cell);
        cell.Attributes.CssStyle["text-align"] = "center";

        cell = new TableHeaderCell();
        cell.ColumnSpan = 2;
        cell.Text = "Material Ordered Local";
        row.Controls.Add(cell);
        cell.Attributes.CssStyle["text-align"] = "center";
        cell = new TableHeaderCell();
        cell.ColumnSpan = 2;
        cell.Text = "Material Ordered Greece";
        row.Controls.Add(cell);
        cell.Attributes.CssStyle["text-align"] = "center";


        cell = new TableHeaderCell();
        cell.ColumnSpan = 2;
        cell.Text = "Glass Details";
        row.Controls.Add(cell);
        cell.Attributes.CssStyle["text-align"] = "center";
        cell = new TableHeaderCell();
        cell.ColumnSpan = 2;
        cell.Text = "Fabrication Details";
        row.Controls.Add(cell);
        cell.Attributes.CssStyle["text-align"] = "center";
        cell = new TableHeaderCell();
        cell.ColumnSpan = 2;
        cell.Text = "Installation Details";
        row.Controls.Add(cell);
        cell.Attributes.CssStyle["text-align"] = "center";
        row.BackColor = ColorTranslator.FromHtml("#9b1c31");
        row.ForeColor = ColorTranslator.FromHtml("#fff");
        GridView2.HeaderRow.Parent.Controls.AddAt(0, row);







    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[17].Visible = false;

        }



      

        if (e.Row.RowType == DataControlRowType.DataRow)

        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                #region ShopdrawingActual

                Label lblshopdrawingactual = (Label)e.Row.FindControl("lblShopDrawing_Actual");
                Label lblshopdrawingreceived = (Label)e.Row.FindControl("lblShopDrawing_Received");

                DateTime dtshopdrawingactual = DateTime.ParseExact(lblshopdrawingactual.Text, "dd/MM/yyyy", null);
                DateTime dtshopdrawingreceived = DateTime.ParseExact(lblshopdrawingreceived.Text, "dd/MM/yyyy", null);


                if (e.Row.Cells[4].Text != "01-01-1900")
                {

                    if (e.Row.Cells[5].Text == "")
                    {
                        DateTime dtToday = DateTime.Now;
                        TimeSpan t = dtshopdrawingactual - dtToday;
                        double noOfDays = t.TotalDays;


                        if (noOfDays < 2)
                        {
                            e.Row.Cells[5].Text = "";
                            e.Row.Cells[5].BackColor = Color.Red;
                        }
                        else if (noOfDays < 4)
                        {
                            e.Row.Cells[5].Text = "";
                            e.Row.Cells[5].BackColor = Color.Yellow;
                        }
                        else
                        {
                            e.Row.Cells[5].Text = "";
                            e.Row.Cells[5].BackColor = Color.Green;
                        }
                    }

                }
                #endregion


                #region MaterialOrderedLocal

                Label lblMaterialOrderedLocalactual = (Label)e.Row.FindControl("lblMaterialOrder_local_Actual");
                Label lblMaterialOrderedLocalreceived = (Label)e.Row.FindControl("lblMaterialOrder_Local_Received");

                DateTime dtMaterialOrderedLocalactual = DateTime.ParseExact(lblMaterialOrderedLocalactual.Text, "dd/MM/yyyy", null);
                DateTime dtMaterialOrderedLocalreceived = DateTime.ParseExact(lblMaterialOrderedLocalreceived.Text, "dd/MM/yyyy", null);


                if (e.Row.Cells[6].Text != "01-01-1900")
                {

                    if (e.Row.Cells[7].Text == "")
                    {
                        DateTime dtToday = DateTime.Now;
                        TimeSpan t = dtMaterialOrderedLocalactual - dtToday;
                        double noOfDays = t.TotalDays;


                        if (noOfDays < 2)
                        {
                            e.Row.Cells[7].Text = "";
                            e.Row.Cells[7].BackColor = Color.Red;
                        }
                        else if (noOfDays < 4)
                        {
                            e.Row.Cells[7].Text = "";
                            e.Row.Cells[7].BackColor = Color.Yellow;
                        }
                        else
                        {
                            e.Row.Cells[7].Text = "";
                            e.Row.Cells[7].BackColor = Color.Green;
                        }
                    }

                }
                #endregion




                #region MaterialOrderedGreece

                Label lblMaterialOrderedGreeceactual = (Label)e.Row.FindControl("lblMaterialOrder_Greece_Actual");
                Label lblMaterialOrderedGreecereceived = (Label)e.Row.FindControl("lblMaterialOrder_Greece_Received");

                DateTime dtMaterialOrderedGreeceactual = DateTime.ParseExact(lblMaterialOrderedGreeceactual.Text, "dd/MM/yyyy", null);
                DateTime dtMaterialOrderedGreecereceived = DateTime.ParseExact(lblMaterialOrderedGreecereceived.Text, "dd/MM/yyyy", null);


                if (e.Row.Cells[8].Text != "01-01-1900")
                {

                    if (e.Row.Cells[9].Text == "")
                    {
                        DateTime dtToday = DateTime.Now;
                        TimeSpan t = dtMaterialOrderedGreeceactual - dtToday;
                        double noOfDays = t.TotalDays;


                        if (noOfDays < 2)
                        {
                            e.Row.Cells[9].Text = "";
                            e.Row.Cells[9].BackColor = Color.Red;
                        }
                        else if (noOfDays < 4)
                        {
                            e.Row.Cells[9].Text = "";
                            e.Row.Cells[9].BackColor = Color.Yellow;
                        }
                        else
                        {
                            e.Row.Cells[9].Text = "";
                            e.Row.Cells[9].BackColor = Color.Green;
                        }
                    }

                }
                #endregion



                #region GlassDetails

                Label lblGlassOrder_Actual = (Label)e.Row.FindControl("lblGlassOrder_Actual");
                Label lblGlassorder_Received = (Label)e.Row.FindControl("lblGlassorder_Received");

                DateTime dtGlassOrder_Actual = DateTime.ParseExact(lblGlassOrder_Actual.Text, "dd/MM/yyyy", null);
                DateTime dtGlassorder_Received = DateTime.ParseExact(lblGlassorder_Received.Text, "dd/MM/yyyy", null);


                if (e.Row.Cells[10].Text != "01-01-1900")
                {

                    if (e.Row.Cells[11].Text == "")
                    {
                        DateTime dtToday = DateTime.Now;
                        TimeSpan t = dtGlassOrder_Actual - dtToday;
                        double noOfDays = t.TotalDays;


                        if (noOfDays < 2)
                        {
                            e.Row.Cells[11].Text = "";
                            e.Row.Cells[11].BackColor = Color.Red;
                        }
                        else if (noOfDays < 4)
                        {
                            e.Row.Cells[11].Text = "";
                            e.Row.Cells[11].BackColor = Color.Yellow;
                        }
                        else
                        {
                            e.Row.Cells[11].Text = "";
                            e.Row.Cells[11].BackColor = Color.Green;
                        }
                    }

                }
                #endregion

                #region FabricationDetails

                Label lblFabrication_Actual = (Label)e.Row.FindControl("lblFabrication_Actual");
                Label lblFabrication_Started = (Label)e.Row.FindControl("lblFabrication_Started");

                DateTime dtFabrication_Actual = DateTime.ParseExact(lblFabrication_Actual.Text, "dd/MM/yyyy", null);
                DateTime dtFabrication_Started = DateTime.ParseExact(lblFabrication_Started.Text, "dd/MM/yyyy", null);


                if (e.Row.Cells[12].Text != "01-01-1900")
                {

                    if (e.Row.Cells[13].Text == "")
                    {
                        DateTime dtToday = DateTime.Now;
                        TimeSpan t = dtFabrication_Actual - dtToday;
                        double noOfDays = t.TotalDays;


                        if (noOfDays < 2)
                        {
                            e.Row.Cells[13].Text = "";
                            e.Row.Cells[13].BackColor = Color.Red;
                        }
                        else if (noOfDays < 4)
                        {
                            e.Row.Cells[13].Text = "";
                            e.Row.Cells[13].BackColor = Color.Yellow;
                        }
                        else
                        {
                            e.Row.Cells[13].Text = "";
                            e.Row.Cells[13].BackColor = Color.Green;
                        }
                    }

                }
                #endregion





                #region InstallationDetails

                Label lblInstallation_Actual = (Label)e.Row.FindControl("lblInstallation_Actual");
                Label lblInstallation_Received = (Label)e.Row.FindControl("lblInstallation_Received");

                DateTime dtInstallation_Actual = DateTime.ParseExact(lblInstallation_Actual.Text, "dd/MM/yyyy", null);
                DateTime dtInstallation_Received = DateTime.ParseExact(lblInstallation_Received.Text, "dd/MM/yyyy", null);


                if (e.Row.Cells[14].Text != "01-01-1900")
                {

                    if (e.Row.Cells[15].Text == "")
                    {
                        DateTime dtToday = DateTime.Now;
                        TimeSpan t = dtInstallation_Actual - dtToday;
                        double noOfDays = t.TotalDays;


                        if (noOfDays < 2)
                        {
                            e.Row.Cells[15].Text = "";
                            e.Row.Cells[15].BackColor = Color.Red;
                        }
                        else if (noOfDays < 4)
                        {
                            e.Row.Cells[15].Text = "";
                            e.Row.Cells[15].BackColor = Color.Yellow;
                        }
                        else
                        {
                            e.Row.Cells[15].Text = "";
                            e.Row.Cells[15].BackColor = Color.Green;
                        }
                    }

                }
                #endregion
                //if(dtshopdrawingreceived = "")
                //{

                //}


                //DateTime dtToday = DateTime.Now;

                //if (dtToday > dtDB)
                //{

                //}


















            }



           

        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            Label colId = e.Row.FindControl("lblConfrimationdate") as Label;

            if (colId.Text == "01-01-1900")
            {
                e.Row.Cells[3].Text = "";
            }

            Label lblShopDrawing_Actual = e.Row.FindControl("lblShopDrawing_Actual") as Label;

            if (lblShopDrawing_Actual.Text == "01-01-1900")
            {
                e.Row.Cells[4].Text = "";
            }

            //Label lblShopDrawing_Received = e.Row.FindControl("lblShopDrawing_Received") as Label;

            //if (lblShopDrawing_Received.Text == "01-01-1900")
            //{
            //    e.Row.Cells[5].Text = "";
            //}

            Label lblMaterialOrder_local_Actual = e.Row.FindControl("lblMaterialOrder_local_Actual") as Label;

            if (lblMaterialOrder_local_Actual.Text == "01-01-1900")
            {
                e.Row.Cells[6].Text = "";
            }


            //Label lblMaterialOrder_Local_Received = e.Row.FindControl("lblMaterialOrder_Local_Received") as Label;



            //if (lblMaterialOrder_Local_Received.Text == "01-01-1900")
            //{
            //    e.Row.Cells[7].Text = "";
            //}

            Label lblMaterialOrder_Greece_Actual = e.Row.FindControl("lblMaterialOrder_Greece_Actual") as Label;

            if (lblMaterialOrder_Greece_Actual.Text == "01-01-1900")
            {
                e.Row.Cells[8].Text = "";
            }


            //Label lblMaterialOrder_Greece_Received = e.Row.FindControl("lblMaterialOrder_Greece_Received") as Label;

            //if (lblMaterialOrder_Greece_Received.Text == "01-01-1900")
            //{
            //    e.Row.Cells[9].Text = "";
            //}

            Label lblGlassOrder_Actual = e.Row.FindControl("lblGlassOrder_Actual") as Label;

            if (lblGlassOrder_Actual.Text == "01-01-1900")
            {
                e.Row.Cells[10].Text = "";
            }

            //Label lblGlassorder_Received = e.Row.FindControl("lblGlassorder_Received") as Label;



            //if (lblGlassorder_Received.Text == "01-01-1900")
            //{
            //    e.Row.Cells[11].Text = "";
            //}


            Label lblFabrication_Actual = e.Row.FindControl("lblFabrication_Actual") as Label;


            if (lblFabrication_Actual.Text == "01-01-1900")
            {
                e.Row.Cells[12].Text = "";
            }


            //Label lblFabrication_Started = e.Row.FindControl("lblFabrication_Started") as Label;


            //if (lblFabrication_Started.Text == "01-01-1900")
            //{
            //    e.Row.Cells[13].Text = "";
            //}

            Label lblInstallation_Actual = e.Row.FindControl("lblInstallation_Actual") as Label;


            if (lblInstallation_Actual.Text == "01-01-1900")
            {
                e.Row.Cells[14].Text = "";
            }

            //if (e.Row.Cells[15].Text == "01-01-1900")
            //{
            //    e.Row.Cells[15].Text = "";
            //}

        }
    }
}
