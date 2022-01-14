using phani.Classes;
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

public partial class Modules_Production_SOOpertions : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SM.SalesOrder.SalesOrder_Select(ddlSoNo);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (ddlSoNo.SelectedValue != "0")
        {

            SqlCommand cmd = new SqlCommand("Select *, CONVERT(varchar, Start_Date, 3) as Startdate,CONVERT(varchar, End_Date, 3) as EndDate ,  'Window Code :'+ Code+' '+'Series :'+Series as Wincode from SO_Window_Operations,Sales_Order,SalesOrder_Details where SO_Window_Operations.So_Id = Sales_Order.SalesOrder_Id and SO_Window_Operations.So_Det_Id = SalesOrder_Details.SalesOrderDet_Id  and  Sales_Order.SalesOrder_Id =@SOID ", con);
            cmd.CommandType = CommandType.Text;

            if (ddlSoNo.SelectedValue != "0")
            {
                cmd.Parameters.AddWithValue("@SOID", ddlSoNo.SelectedItem.Value);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            hai.DataSource = dt;
            hai.DataBind();

        }
        else
        {
            MessageBox.Show(this, "Please Select Sales order No");
        }
    }
    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;
        }


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            //Select the Desinger in DropDownList
            DropDownList ddlPriority = (DropDownList)e.Row.FindControl("ddlPriority");
            string lblPriority = (e.Row.FindControl("lblPriority") as Label).Text;
            ddlPriority.Items.FindByValue(lblPriority).Selected = true;


            DropDownList ddlcutting = (DropDownList)e.Row.FindControl("ddlcutting");
            string lblCutting = (e.Row.FindControl("lblCutting") as Label).Text;
            ddlcutting.Items.FindByValue(lblCutting).Selected = true;

            DropDownList ddlFloding = (DropDownList)e.Row.FindControl("ddlFloding");
            string lblFloding = (e.Row.FindControl("lblFloding") as Label).Text;
            ddlFloding.Items.FindByValue(lblFloding).Selected = true;



            DropDownList ddlMachining = (DropDownList)e.Row.FindControl("ddlMachining");
            string lblMachining = (e.Row.FindControl("lblMachining") as Label).Text;
            ddlMachining.Items.FindByValue(lblMachining).Selected = true;

            DropDownList ddlPunching = (DropDownList)e.Row.FindControl("ddlPunching");
            string lblPunching = (e.Row.FindControl("lblPunching") as Label).Text;
            ddlPunching.Items.FindByValue(lblFloding).Selected = true;



            DropDownList ddlShearing = (DropDownList)e.Row.FindControl("ddlShearing");
            string lblShearing = (e.Row.FindControl("lblShearing") as Label).Text;
            ddlShearing.Items.FindByValue(lblShearing).Selected = true;



            DropDownList ddlStamping = (DropDownList)e.Row.FindControl("ddlStamping");
            string lblStamping = (e.Row.FindControl("lblStamping") as Label).Text;
            ddlStamping.Items.FindByValue(lblStamping).Selected = true;

            DropDownList ddlCasting = (DropDownList)e.Row.FindControl("ddlCasting");
            string lblCasting = (e.Row.FindControl("lblCasting") as Label).Text;
            ddlCasting.Items.FindByValue(lblCasting).Selected = true;



            DropDownList ddlWelding = (DropDownList)e.Row.FindControl("ddlWelding");
            string lblWelding = (e.Row.FindControl("lblWelding") as Label).Text;
            ddlWelding.Items.FindByValue(lblWelding).Selected = true;

            DropDownList ddlFinishing = (DropDownList)e.Row.FindControl("ddlFinishing");
            string lblFinishing = (e.Row.FindControl("lblFinishing") as Label).Text;
            ddlFinishing.Items.FindByValue(lblFinishing).Selected = true;




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
                SM.SalesOrder obj = new SM.SalesOrder();

                obj.SowId = hai.SelectedRow.Cells[0].Text;


                TextBox stratdate = (TextBox)gvRow.FindControl("txtstratdate");
                obj.SowStratdate = General.toMMDDYYYY(stratdate.Text);

                TextBox Enddate = (TextBox)gvRow.FindControl("txtenddate");
                obj.SowEnddate = General.toMMDDYYYY(Enddate.Text);

                DropDownList ddlPriority = (DropDownList)gvRow.FindControl("ddlPriority");
                obj.Priority = ddlPriority.SelectedItem.Value;

                DropDownList ddlcutting = (DropDownList)gvRow.FindControl("ddlcutting");
                obj.Cutting = ddlcutting.SelectedItem.Value;

                DropDownList ddlFloding = (DropDownList)gvRow.FindControl("ddlFloding");
                obj.Floding = ddlFloding.SelectedItem.Value;

                DropDownList ddlMachining = (DropDownList)gvRow.FindControl("ddlMachining");
                obj.Machinging = ddlMachining.SelectedItem.Value;


                DropDownList ddlPunching = (DropDownList)gvRow.FindControl("ddlPunching");
                obj.Punching = ddlPunching.SelectedItem.Value;

                DropDownList ddlShearing = (DropDownList)gvRow.FindControl("ddlShearing");
                obj.Shearing = ddlShearing.SelectedItem.Value;

                DropDownList ddlStamping = (DropDownList)gvRow.FindControl("ddlStamping");
                obj.Stamping = ddlStamping.SelectedItem.Value;

                DropDownList ddlCasting = (DropDownList)gvRow.FindControl("ddlCasting");
                obj.Casting = ddlCasting.SelectedItem.Value;

                DropDownList ddlWelding = (DropDownList)gvRow.FindControl("ddlWelding");
                obj.Welding = ddlWelding.SelectedItem.Value;


                DropDownList ddlFinishing = (DropDownList)gvRow.FindControl("ddlFinishing");
                obj.Finishing = ddlFinishing.SelectedItem.Value;

                MessageBox.Show(this, obj.WindowsOperationAssign_Update());






            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }

            finally
            {
                hai.DataBind();
                btnSearch_Click(sender, e);
            }
        }

        else
        {
            MessageBox.Show(this, "Please Select Record to Assign");
        }



    }
}