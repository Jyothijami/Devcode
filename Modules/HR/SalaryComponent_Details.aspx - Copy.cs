using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_SalaryComponent_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();



        if (!IsPostBack)
        {
            if (Qid != "Add")
            {

                CategoryFill();

            }
        }
    }

    private void CategoryFill()
    {
        HR.Salary_Component objmaster = new HR.Salary_Component();
        if (objmaster.Salary_Component_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtComponentName.Text = objmaster.SalaryComName;
            txtDescription.Text = objmaster.Description;
            ddlstatus.SelectedItem.Value = objmaster.Type;
            txtMaximumAmount.Text = objmaster.MaxAmount;

        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                HR.Salary_Component objMaster = new HR.Salary_Component();
                objMaster.SalaryComName = txtComponentName.Text;
                objMaster.Description = txtDescription.Text;
                objMaster.Type = ddlstatus.SelectedItem.Value;
                objMaster.MaxAmount = txtMaximumAmount.Text;

                MessageBox.Notify(this, objMaster.Salary_Component_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
                Response.Redirect("~/Modules/HR/SalaryComponent.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                HR.Salary_Component objMaster = new HR.Salary_Component();
                objMaster.Salary_ComponentId = Request.QueryString["Cid"].ToString();
                objMaster.SalaryComName = txtComponentName.Text;
                objMaster.Description = txtDescription.Text;
                objMaster.Type = ddlstatus.SelectedItem.Value;
                objMaster.MaxAmount = txtMaximumAmount.Text;
               
                MessageBox.Notify(this, objMaster.Salary_Component_Update());


            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
                Response.Redirect("~/Modules/HR/SalaryComponent.aspx");
            }
        }

    }


    

}