using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_ProfileLength_Master : System.Web.UI.Page
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
        Masters.LengthMaster objmaster = new Masters.LengthMaster();
        if (objmaster.LengthMaster_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtLength.Text = objmaster.Length;
            txtDescription.Text = objmaster.Description;
           
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.LengthMaster objMaster = new Masters.LengthMaster();
                objMaster.Length = txtLength.Text;
                objMaster.Description = txtDescription.Text;
                objMaster.LengthMaster_Save();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);

            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);

            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                Masters.LengthMaster objMaster = new Masters.LengthMaster();
                objMaster.Length = txtLength.Text;
                objMaster.Description = txtDescription.Text;
                objMaster.Id = Request.QueryString["Cid"].ToString();
              
                objMaster.LengthMaster_Update();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);

            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {
                Masters.ClearControls(this);

            }
        }
    }
}