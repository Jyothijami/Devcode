using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MobileLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void btnsignin_Click(object sender, EventArgs e)
    {
        //if (System.Web.HttpContext.Current.Session["AlusoftSession"] != null)
        //{
        //    
        //}
        //else
        //{
        //System.Web.HttpContext.Current.Session["AlusoftSession"] = null;
        Alumil.Authentication Login = new Alumil.Authentication();
        phani.MessageBox.MessageBox.Show(this, Login.MobileLoginCheck(this, txtUserName.Text.Trim(), txtPassword.Text));
       // }
    }



}