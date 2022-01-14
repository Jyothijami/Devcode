using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Masters_Table_Details : System.Web.UI.Page
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
        Masters.TableMaster objmaster = new Masters.TableMaster();
        if (objmaster.TableMaster_Select(Request.QueryString["Cid"].ToString()) > 0)
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
                Masters.TableMaster objMaster = new Masters.TableMaster();
                objMaster.ColorName = txtColorName.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.TableMaster_Save());
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
                Masters.TableMaster objMaster = new Masters.TableMaster();
                objMaster.ColorId = Request.QueryString["Cid"].ToString();
                objMaster.ColorName = txtColorName.Text;
                objMaster.Desc = txtDescription.Text;
                MessageBox.Notify(this, objMaster.TableMaster_Update());
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