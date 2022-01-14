using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_ColorDetails : System.Web.UI.Page
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
        Masters.ColorMaster objmaster = new Masters.ColorMaster();
        if (objmaster.Color_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtColorName.Text = objmaster.ColorName;
            txtDescription.Text = objmaster.Desc;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                Masters.ColorMaster objMaster = new Masters.ColorMaster();
                objMaster.ColorName = txtColorName.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.ColorMaster_Save());
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
                Masters.ColorMaster objMaster = new Masters.ColorMaster();
                objMaster.ColorId = Request.QueryString["Cid"].ToString();
                objMaster.ColorName = txtColorName.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.ColorMaster_Update());
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