using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_LeaveType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();



        if (!IsPostBack)
        {
            if (Qid != "Add")
            {



            }
        }
    }

    private void CategoryFill()
    {
        HR.LeaveType objmaster = new HR.LeaveType();
        if (objmaster.LeaveType_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtLeaveType.Text = objmaster.LeaveType_name;
            txtMaxDaysLeaveAllowed.Text = objmaster.MaxDay_Allowed;
           

            if(objmaster.ISCarryForword == "Yes")
            {
                chkiscarryforward.Checked = true;
            }

            if (objmaster.IsLeavewithoutPay == "Yes")
            {
                chkisleavewithoutpay.Checked = true;
            }
            if (objmaster.AllowNegitiveBalance == "Yes")
            {
                chkallownegativebalance.Checked = true;
            }
            if (objmaster.IncludeHolidayswithinLeaveasLeave == "Yes")
            {
                chkincludeholidaywithinleave.Checked = true;
            }


        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                HR.LeaveType objMaster = new HR.LeaveType();
                objMaster.LeaveType_name = txtLeaveType.Text;
                objMaster.MaxDay_Allowed = txtMaxDaysLeaveAllowed.Text;

                if (chkisleavewithoutpay.Checked)
                {
                    objMaster.IsLeavewithoutPay = "Yes";
                }
                else
                {
                    objMaster.IsLeavewithoutPay = "No";
                }

                if (chkiscarryforward.Checked)
                {
                    objMaster.ISCarryForword = "Yes";
                }
                else
                {
                    objMaster.ISCarryForword = "No";
                }

                if (chkisleavewithoutpay.Checked)
                {
                    objMaster.IsLeavewithoutPay = "Yes";
                }
                else
                {
                    objMaster.IsLeavewithoutPay = "No";
                }


                if (chkallownegativebalance.Checked)
                {
                    objMaster.AllowNegitiveBalance = "Yes";
                }
                else
                {
                    objMaster.AllowNegitiveBalance = "No";
                }

                if (chkincludeholidaywithinleave.Checked)
                {
                    objMaster.IncludeHolidayswithinLeaveasLeave = "Yes";
                }
                else
                {
                    objMaster.IncludeHolidayswithinLeaveasLeave = "No";
                }

                MessageBox.Show(this, objMaster.LeaveType_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
                Response.Redirect("~/Modules/HR/LeaveType.aspx");
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                HR.LeaveType objMaster = new HR.LeaveType();
                objMaster.LeaveTypeId = Request.QueryString["Cid"].ToString();
                objMaster.LeaveType_name = txtLeaveType.Text;
                objMaster.MaxDay_Allowed = txtMaxDaysLeaveAllowed.Text;

                if (chkisleavewithoutpay.Checked)
                {
                    objMaster.IsLeavewithoutPay = "Yes";
                }
                else
                {
                    objMaster.IsLeavewithoutPay = "No";
                }

                if (chkiscarryforward.Checked)
                {
                    objMaster.ISCarryForword = "Yes";
                }
                else
                {
                    objMaster.ISCarryForword = "No";
                }

                if (chkisleavewithoutpay.Checked)
                {
                    objMaster.IsLeavewithoutPay = "Yes";
                }
                else
                {
                    objMaster.IsLeavewithoutPay = "No";
                }


                if (chkallownegativebalance.Checked)
                {
                    objMaster.AllowNegitiveBalance = "Yes";
                }
                else
                {
                    objMaster.AllowNegitiveBalance = "No";
                }

                if (chkincludeholidaywithinleave.Checked)
                {
                    objMaster.IncludeHolidayswithinLeaveasLeave = "Yes";
                }
                else
                {
                    objMaster.IncludeHolidayswithinLeaveasLeave = "No";
                }
                MessageBox.Notify(this, objMaster.LeaveType_Update());


            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
                Response.Redirect("~/Modules/HR/LeaveType.aspx");
            }
        }

    }

}