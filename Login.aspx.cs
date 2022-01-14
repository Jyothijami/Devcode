using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Alumil;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsignin_Click(object sender, EventArgs e)
    {
        Alumil.Authentication Login = new Alumil.Authentication();
        phani.MessageBox.MessageBox.Show(this, Login.LoginCheck(this, txtUserName.Text.Trim(), txtPassword.Text));
    }
}