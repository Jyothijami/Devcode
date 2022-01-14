using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_New_Leave_Application_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();


        if (!IsPostBack)
        {
            txtLaveappNo.Text = HR.Leave_Application.Leave_Application_AutoGenCode();
            HR.LeaveType.LeaveType_Select(ddlLeaveType);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlemployee);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlleaveapprover);


            HR.EmployeeMaster.EmployeeMasterHR_Select(ddlHR);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlHod);



            txtPostingDate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtfromdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txttodate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);




            txtELAvailable.Text = "0";
            txtCLAvailable.Text = "0";
            txtcasualleaveallocate.Text = "0";
            txtelleaveallocate.Text = "0";
            txtLopallocate.Text = "0";




            if (Qid != "Add")
            {

               
              
                CategoryFill();

            }

        }
    }

    private void CategoryFill()
    {
        HR.Leave_Application objmaster = new HR.Leave_Application();
        if (objmaster.Leave_Application_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtLaveappNo.Text = objmaster.LapNo;
            ddlLeaveType.SelectedValue = objmaster.LeavetypeId;
            ddlstatus.SelectedValue = objmaster.Status;
            txtfromdate.Text = objmaster.fromdate;
            txttodate.Text = objmaster.todate;
            txtReason.Text = objmaster.reason;


           if( objmaster.halfday == "Yes")
           {
               chkhalfday.Checked = true;
               halfdaydiv.Visible = true;
               
           }
           else
           {
               chkhalfday.Checked = false;
               halfdaydiv.Visible = false;
           }
           txthalfdaydate.Text = objmaster.halfdaydate;
           ddlemployee.SelectedValue = objmaster.empid;
           ddlemployee_SelectedIndexChanged(new object(), new System.EventArgs());


           ddlleaveapprover.SelectedValue = objmaster.LeaveapproverId;
           txtPostingDate.Text = objmaster.Postingdate;

            ddlHR.SelectedValue = objmaster.HrId;
            txtnoofdays.Text = objmaster.Noofdays;
            txtAddressonleave.Text = objmaster.addresswhileonleave;
            txtcasualleaveallocate.Text = objmaster.cl;
            txtelleaveallocate.Text = objmaster.el;
            txtLopallocate.Text = objmaster.lop;

            ddlhrStatus.SelectedValue = objmaster.HRstatus;
            ddlhodstatus.SelectedValue = objmaster.HodStatus;


            if (objmaster.HRstatus == "Open")
            {
                tblhr.Visible = true;
            }

            if (objmaster.HodStatus == "Open")
            {
                tblhod.Visible = true;
                tblhr.Visible = false;
            }

            




        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                HR.Leave_Application objMaster = new HR.Leave_Application();
                objMaster.LapNo = txtLaveappNo.Text;
                objMaster.LeavetypeId = ddlLeaveType.SelectedItem.Value;
                objMaster.Status = ddlstatus.SelectedItem.Value;
                objMaster.fromdate = phani.Classes.General.toMMDDYYYY(txtfromdate.Text);
                objMaster.todate = phani.Classes.General.toMMDDYYYY(txttodate.Text);
                objMaster.reason = txtReason.Text;

                if (chkhalfday.Checked == true)
                {
                    objMaster.halfday = "Yes";
                    objMaster.halfdaydate = phani.Classes.General.toMMDDYYYY(txthalfdaydate.Text);

                }
                else
                {
                    objMaster.halfday = "No";
                    objMaster.halfdaydate = DBNull.Value.ToString();
                }
                objMaster.empid = ddlemployee.SelectedItem.Value;
                objMaster.LeaveapproverId = ddlleaveapprover.SelectedItem.Value;
                objMaster.Postingdate = phani.Classes.General.toMMDDYYYY(txtPostingDate.Text);

                objMaster.HrId =  ddlHR.SelectedValue ;
                objMaster.Noofdays = txtnoofdays.Text;
                objMaster.addresswhileonleave= txtAddressonleave.Text;
                objMaster.cl = txtcasualleaveallocate.Text  ;
                objMaster.el =txtelleaveallocate.Text ;
                objMaster.lop = txtLopallocate.Text ;

                objMaster.HRstatus = ddlhrStatus.SelectedValue;
                objMaster.HodStatus = ddlhodstatus.SelectedValue;



                MessageBox.Show(this, objMaster.Leave_Application_Save());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                HR.Leave_Application objMaster = new HR.Leave_Application();
                objMaster.Leave_ApplicationId = Request.QueryString["Cid"].ToString();
                objMaster.LapNo = txtLaveappNo.Text;
                objMaster.LeavetypeId = ddlLeaveType.SelectedItem.Value;
                objMaster.Status = ddlstatus.SelectedItem.Value;
                objMaster.fromdate = phani.Classes.General.toMMDDYYYY(txtfromdate.Text);
                objMaster.todate = phani.Classes.General.toMMDDYYYY(txttodate.Text);
                objMaster.reason = txtReason.Text;

                if (chkhalfday.Checked == true)
                {
                    objMaster.halfday = "Yes";
                    objMaster.halfdaydate = phani.Classes.General.toMMDDYYYY(txthalfdaydate.Text);

                }
                else
                {
                    objMaster.halfday = "No";
                    objMaster.halfdaydate = DBNull.Value.ToString();
                }
                objMaster.empid = ddlemployee.SelectedItem.Value;
                objMaster.LeaveapproverId = ddlleaveapprover.SelectedItem.Value;
                objMaster.Postingdate = phani.Classes.General.toMMDDYYYY(txtPostingDate.Text);

                objMaster.HrId = ddlHR.SelectedValue;
                objMaster.Noofdays = txtnoofdays.Text;
                objMaster.addresswhileonleave = txtAddressonleave.Text;
                objMaster.cl = txtcasualleaveallocate.Text;
                objMaster.el = txtelleaveallocate.Text;
                objMaster.lop = txtLopallocate.Text;

                objMaster.HRstatus = ddlhrStatus.SelectedValue;
                objMaster.HodStatus = ddlhodstatus.SelectedValue;



                if(objMaster.HRstatus != "Open")
                {
                    objMaster.Leaves_Update(objMaster.empid, objMaster.cl, objMaster.el);
                }





                MessageBox.Show(this, objMaster.Leave_Application_Update());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {

                HR.ClearControls(this);
                HR.Dispose();
            }
        }

    }


    protected void ddlemployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        HR.EmployeeMaster obj = new HR.EmployeeMaster();

        if(obj.EmployeeMaster_Select(ddlemployee.SelectedItem.Value) > 0)
        {
            ddlleaveapprover.SelectedValue = obj.EmpReportingto;

        }

        HR.EmployeeCTC objc = new HR.EmployeeCTC();

        if(objc.EmployeeleavesAvailable_Select(ddlemployee.SelectedItem.Value) > 0 )
        {
            txtCLAvailable.Text = objc.CausalLeaves;
            txtELAvailable.Text = objc.EarnedLeaves;
        }


    }
}