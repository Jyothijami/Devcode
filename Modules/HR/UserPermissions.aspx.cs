using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_UserPermissions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Masters.DDLBindWithSelect(ddlUserName, "SELECT Emp_Id,UserName FROM User_Master");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            Masters.UserMaster obj = new Masters.UserMaster();
            obj.UserPermissions_Delete(int.Parse(ddlUserName.SelectedItem.Value));


            foreach (ListItem Permissions in cblPermissions.Items)
            {
                if (Permissions.Selected == true)
                {
                    obj.UserPermissions_Save(int.Parse(ddlUserName.SelectedItem.Value), Permissions.Value);

                }
            }
            string edit, delete;
            if (chkIsdelete.Checked == true)
            {
                delete = "1";
            }
            else
            {
                delete = "0";
            }
            if (chkIsedit.Checked == true)
            {
                edit = "1";
            }
            else
            {
                edit = "0";
            }
            obj.deleteedit_Update(int.Parse(ddlUserName.SelectedItem.Value), edit, delete);



            MessageBox.Show(this, "Data Saved");
            cblPermissions.ClearSelection();
            ddlUserName.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < cblPermissions.Items.Count; i++)
            {
                cblPermissions.Items[i].Selected = true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
    protected void btnUnselect_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < cblPermissions.Items.Count; i++)
            {
                cblPermissions.Items[i].Selected = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
    protected void ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            cblPermissions.ClearSelection();
            Masters.UserMaster obj = new Masters.UserMaster();
            DataTable dt = obj.UserPermissions_Select(int.Parse(ddlUserName.SelectedItem.Value));


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem currentCheckBox = cblPermissions.Items.FindByValue(dt.Rows[i][0].ToString());
                if (currentCheckBox != null)
                {
                    currentCheckBox.Selected = true;
                }
            }

            if (obj.editdelete_Select(ddlUserName.SelectedItem.Value) > 0)
            {
                if (obj.edit != "0")
                {
                    chkIsedit.Checked = true;
                }
                else
                {
                    chkIsedit.Checked = false;
                }
                if (obj.delete != "0")
                {
                    chkIsdelete.Checked = true;
                }
                else
                {
                    chkIsdelete.Checked = false;
                }
            }


        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }

    }
}