using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_UserDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

        if (Qid != "Add")
        {

            Fill();

        }

        if (!IsPostBack)
        {

        }
    }

    private void Fill()
    {
        Masters.UserMaster objmaster = new Masters.UserMaster();
        if (objmaster.editdelete_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtUserName.Text = objmaster.uname;
        
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnSave.Text == "Save")
            {
                Masters.UserMaster obj = new Masters.UserMaster();
                MessageBox.Notify(this, obj.UserMaster_Save(txtUserName.Text, txtPassword.Text));

            }
            else if (btnSave.Text == "Update")
            {
                Masters.UserMaster obj = new Masters.UserMaster();
                MessageBox.Notify(this, obj.UserMaster_Update(int.Parse(Request.QueryString["Cid"].ToString()), txtUserName.Text,txtPassword.Text, txtCOnpassword.Text));

            }
           
            Masters.ClearControls(this);
        }
        catch (Exception ex)
        {
            MessageBox.Notify(this, ex.Message);
        }
    }
}