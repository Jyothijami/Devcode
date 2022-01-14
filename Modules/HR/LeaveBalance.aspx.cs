using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_LeaveBalance : System.Web.UI.Page
{
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


        if (hai.SelectedIndex > -1)
        {
            try
            {


                HR.EmployeeCTC obj = new HR.EmployeeCTC();

                obj.EmpId = hai.SelectedRow.Cells[1].Text;

                TextBox causalleaves = (TextBox)gvRow.FindControl("txtcasualleaves");
                obj.CausalLeaves = causalleaves.Text;


                TextBox EarnedLeaves = (TextBox)gvRow.FindControl("txtearnedleaves");
                obj.EarnedLeaves = EarnedLeaves.Text;






                MessageBox.Show(this, obj.EmployeeLeaves_Save());








            }

            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                hai.DataBind();

            }

        }
        else
        {
            MessageBox.Notify(this, "Please select atleast a Record");
        }
    }

    protected void hai_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }
}