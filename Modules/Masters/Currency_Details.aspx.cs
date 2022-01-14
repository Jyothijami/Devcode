using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_Currency_Details : System.Web.UI.Page
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
        Masters.Currency objmaster = new Masters.Currency();
        if (objmaster.Currency_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtcurrencyName.Text = objmaster.CurName;
            txtDescription.Text = objmaster.CurDesc;
            txtcurrencyfullname.Text = objmaster.CurFullName;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.Currency objMaster = new Masters.Currency();
                objMaster.CurName = txtcurrencyName.Text;
                objMaster.CurFullName = txtcurrencyfullname.Text;

                objMaster.CurDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.Currency_Save());
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
                Masters.Currency objMaster = new Masters.Currency();
                objMaster.CurId = Request.QueryString["Cid"].ToString();
                objMaster.CurName = txtcurrencyName.Text;
                objMaster.CurFullName = txtcurrencyfullname.Text;

                objMaster.CurDesc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.Currency_Update());
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