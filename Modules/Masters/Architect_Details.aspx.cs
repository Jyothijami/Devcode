using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_Architect_Details : System.Web.UI.Page
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
        Masters.ArchitectMaster objmaster = new Masters.ArchitectMaster();
        if (objmaster.ArchitectMaster_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtName.Text = objmaster.Name;
            txtAddress.Text = objmaster.Address;
            txtMoile.Text = objmaster.Mobile;
            txtEmail.Text = objmaster.Email;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.ArchitectMaster objMaster = new Masters.ArchitectMaster();
                objMaster.Name = txtName.Text;
                objMaster.Mobile = txtMoile.Text;
                objMaster.Email = txtEmail.Text;
                objMaster.Address = txtAddress.Text;
                objMaster.ArchitectMaster_Save();
              //  MessageBox.Show(this, );
               // ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "myalert", "var r = successalert(); if(r == true) var str= '/Architect.aspx'; location.href = str ;", true);
                 // ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "var r = alert('Data Updated Successfully'); if (r == true) var str= ''; window.location='" + Request.ApplicationPath + "Modules/Masters/Architect.aspx';", true);
              //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi().then(() => { window.location ='Architect.aspx'; });", true);


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
                Masters.ArchitectMaster objMaster = new Masters.ArchitectMaster();
                objMaster.Id = Request.QueryString["Cid"].ToString();
                objMaster.Name = txtName.Text;
                objMaster.Mobile = txtMoile.Text;
                objMaster.Email = txtEmail.Text;
                objMaster.Address = txtAddress.Text;
                objMaster.ArchitectMaster_Update();

                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Updated Successfully'); window.location.replace('~/Modules/Masters/Architect.aspx');", true);
              // ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "var r = alert('Data Updated Successfully'); if (r == true) var str= ''; window.location='" + Request.ApplicationPath + "Modules/Masters/Architect.aspx';", true);

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