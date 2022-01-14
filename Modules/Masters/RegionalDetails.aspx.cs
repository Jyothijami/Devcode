using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_RegionalDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

       

        if (!IsPostBack)
        {
            if (Qid != "Add")
            {

                DepartmentFill();

            }
        }
    }

    private void DepartmentFill()
    {
        Masters.RegionalMaster objmaster = new Masters.RegionalMaster();
        if (objmaster.Region_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtCategoryName.Text = objmaster.RegName;
            txtDescription.Text = objmaster.RegDesc;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.RegionalMaster objMaster = new Masters.RegionalMaster();
                objMaster.RegName = txtCategoryName.Text;
                objMaster.RegDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.RegionalMaster_Save());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                Masters.ClearControls(this);
                Masters.Dispose();
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                Masters.RegionalMaster objMaster = new Masters.RegionalMaster();
                objMaster.RegId = Request.QueryString["Cid"].ToString();
                objMaster.RegName = txtCategoryName.Text;
                objMaster.RegDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.RegionalMaster_Update());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                Masters.ClearControls(this);
                Masters.Dispose();
            }
        }

    }
}