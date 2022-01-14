using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using phani.MessageBox;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Modules_Stock_BlockFree : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);

        if (!IsPostBack)
        {
            hai.DataBind();
        }
    }
    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        LinkButton lbtnRegionalMaster;
        lbtnRegionalMaster = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnRegionalMaster.Parent.Parent;
        hai.SelectedIndex = gvRow.RowIndex;
        CheckBox ch = new CheckBox();
        ch = (CheckBox)gvRow.FindControl("chk");
        if (ch.Checked == true)
        {
            if (hai.SelectedIndex > -1)
            {
                try
                {
                    SCM.ReserveStock objSM = new SCM.ReserveStock();

                    objSM.ReserveDetid = hai.SelectedRow.Cells[0].Text;
                    objSM.CustID = gvRow.Cells[1].Text;
                    objSM.ProjectId = gvRow.Cells[2].Text;
                    objSM.Itemcode = gvRow.Cells[3].Text;
                    objSM.ColorId = gvRow.Cells[4].Text;
                    objSM.Length = gvRow.Cells[7].Text;
                    objSM.Totalqty = gvRow.Cells[8].Text;
                    TextBox qty = (TextBox)gvRow.FindControl("txtitemqty");
                    objSM.Qty = qty.Text;

                    TextBox remarks = (TextBox)gvRow.FindControl("txtitemRemarks");
                    objSM.Remarks = remarks.Text;

                    objSM.Indent_Reminder();

                    MessageBox.Show(this, objSM.ReserveBlockStock_Update());

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
        else
        {
            if (hai.SelectedIndex > -1)
            {
                try
                {
                    SCM.ReserveStock objSM = new SCM.ReserveStock();

                    objSM.ReserveDetid = hai.SelectedRow.Cells[0].Text;
                    TextBox qty = (TextBox)gvRow.FindControl("txtitemqty");
                    objSM.Qty = qty.Text;

                    TextBox remarks = (TextBox)gvRow.FindControl("txtitemRemarks");
                    objSM.Remarks = remarks.Text;

                    MessageBox.Show(this, objSM.ReserveBlockStock_Update());

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
        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("[USP_FreeBlock_Serach]", con);
        cmd.CommandType = CommandType.StoredProcedure;

        if (txtMaterialCode.Text != "")
        {
            cmd.Parameters.AddWithValue("@Item_Code", txtMaterialCode.Text);
        }
        if (txtCust.Text != "")
        {
            cmd.Parameters.AddWithValue("@CustName", txtCust.Text);
        }
        if (txtPrjtcode.Text != "")
        {
            cmd.Parameters.AddWithValue("@ProjectCode", txtPrjtcode.Text);
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        hai.DataSource = dt;
        hai.DataBind();
    }
}