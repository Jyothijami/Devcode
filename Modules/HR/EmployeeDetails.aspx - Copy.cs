using phani.Classes;
using phani.MessageBox;
using System;
using System.Globalization;

public partial class Modules_HR_EmployeeDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            txtEmpSeries.Text = HR.EmployeeMaster.EmpSeries_AutoGenCode();
            txtDateOfAppointment.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtDateOfTermination.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            Department_Fill();
            Designation_Fill();
            EmployeeType_Fill();
            Company_Fill();
            emp_fill();
            txttds.Text = "0";
            txtsalary.Text = "0";
            gradefill();
            if (Qid != "Add")
            {
                Fill();
                tbluserdetails.Visible = false;
            }
        }
    }

    private void emp_fill()
    {
        HR.EmployeeMaster.EmployeeMaster_Select(ddlLeaveApprover);
    }

    private void gradefill()
    {
        Masters.GradeMaster.GradeMaster_Select(ddlGrade);
    }

    private void Fill()
    {
        try
        {
            HR.EmployeeMaster objEM = new HR.EmployeeMaster();
            if (objEM.EmployeeMaster_Select(Request.QueryString["Cid"].ToString()) > 0)
            {
                btnSave.Text = "Update";
                btnSave.Enabled = true;
                txtFirstName.Text = objEM.EmpFirstName;
                txtLastName.Text = objEM.EmpLastName;
                if (objEM.EmpGender == "Male")
                {
                    rbtMale.Checked = true;
                    rbtFemale.Checked = false;
                }
                else
                {
                    rbtFemale.Checked = true;
                    rbtMale.Checked = false;
                }
                txtAddress.Text = objEM.EmpAddress;
                txtCity.Text = objEM.EmpCity;
                txtDateOfBirth.Text = objEM.EmpDOB;
                txtEmail.Text = objEM.EmpEMail;
                txtMobileNo.Text = objEM.EmpMobile;
                txtPhoneNo.Text = objEM.EmpPhone;
                ddlDepartment.SelectedValue = objEM.DeptID;
                ddlDesignation.SelectedValue = objEM.DesgID;
                ddlEmployeeType.SelectedValue = objEM.EmpTypeID;
                ddlCompany.SelectedValue = objEM.CpId;
                //  ddlCompany_SelectedIndexChanged(sender, e);
                //  ddlLeaveApprover.SelectedValue = objEM.PlantId;
                txtDateOfAppointment.Text = objEM.EmpDetDOJ;
                txtDateOfTermination.Text = objEM.EmpDetDOT;
                txtUserName.Text = objEM.EMPUserName;
                txtEmpSeries.Text = objEM.Empseries;

                txtsalary.Text = objEM.sALARY;
                txttds.Text = objEM.TDS;
                txtBankaccountNo.Text = objEM.ACCOUNTNO;
                ddlGrade.SelectedValue = objEM.Grade;
                ddlLeaveApprover.SelectedValue = objEM.EmpReportingto;
                //txtPassword.Text = objEM.PASSWORD;
                //txtPassword.Visible = false;
                //lblpassowrd.Visible = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
        }
    }

    private void Company_Fill()
    {
        try
        {
            Masters.CompanyProfile.Company_Select(ddlCompany);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Masters.Dispose();
        }
    }

    private void EmployeeType_Fill()
    {
        try
        {
            Masters.EmployeeType.EmployeeType_Select(ddlEmployeeType);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Masters.Dispose();
        }
    }

    #region Department Fill

    public void Department_Fill()
    {
        try
        {
            Masters.Department.Department_Select(ddlDepartment);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Masters.Dispose();
        }
    }

    #endregion Department Fill

    #region Designation Fill

    public void Designation_Fill()
    {
        try
        {
            Masters.Designation.Designation_Select(ddlDesignation);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Masters.Dispose();
        }
    }

    #endregion Designation Fill

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            EmployeeMasterSave();
        }
        else if (btnSave.Text == "Update")
        {
            EmployeeMasterUpdate();
        }
    }

    private void EmployeeMasterUpdate()
    {
        try
        {
            HR.EmployeeMaster obj = new HR.EmployeeMaster();

            obj.EmpID = Request.QueryString["Cid"].ToString();
            obj.EmpFirstName = txtFirstName.Text;
            obj.EmpMiddleName = "-";
            obj.EmpLastName = txtLastName.Text;
            if (rbtMale.Checked == true)
            {
                obj.EmpGender = rbtMale.Text;
            }
            else
            {
                obj.EmpGender = rbtFemale.Text;
            }
            obj.EmpMobile = txtMobileNo.Text;
            obj.EmpDOB = phani.Classes.General.toMMDDYYYY(txtDateOfBirth.Text);
            obj.EmpEMail = txtEmail.Text;
            obj.EmpAddress = txtAddress.Text;
            obj.EmpCity = txtCity.Text;
            obj.EmpPhone = txtPhoneNo.Text;
            obj.DeptID = ddlDepartment.SelectedItem.Value;
            obj.DesgID = ddlDesignation.SelectedItem.Value;
            // obj.BranchId = ddlBranch.SelectedItem.Value;
            obj.EmpDetDOJ = phani.Classes.General.toMMDDYYYY(txtDateOfAppointment.Text);
            obj.EmpDetDOT = phani.Classes.General.toMMDDYYYY(txtDateOfTermination.Text);
            obj.EmpTypeID = ddlEmployeeType.SelectedItem.Value;
            // obj.tEmpPhoto = "xxx.jpeg";
            obj.EMPUserName = txtUserName.Text;
            obj.PASSWORD = txtPassword.Text;
            obj.CpId = ddlCompany.SelectedItem.Value;
            obj.PlantId = ddlLeaveApprover.SelectedItem.Value;
            obj.Empseries = txtEmpSeries.Text;

            obj.ACCOUNTNO = txtBankaccountNo.Text;
            obj.TDS = "0";
            obj.sALARY = txtsalary.Text;
            obj.Grade = ddlGrade.SelectedItem.Value;
            obj.Status = "Updated";


           

            obj.Employee_Update(obj.EmpID);

            //Masters.UserMaster objuser = new Masters.UserMaster();
            //objuser.UserMaster_Save(obj.EMPUserName, obj.PASSWORD);

            MessageBox.Show(this, "Data Updated Successfully");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            HR.ClearControls(this);
            HR.Dispose();
        }
    }

    #region EmployeeMasterSave

    private void EmployeeMasterSave()
    {
        int i = General.CountofRecordsWithQuery("select count(*) from Employee_Master where EMP_USERNAME = '" + txtUserName.Text + "' ");

        if (i == 0)
        {
            try
            {
                HR.EmployeeMaster obj = new HR.EmployeeMaster();

                obj.EmpFirstName = txtFirstName.Text;
                obj.EmpMiddleName = "-";
                obj.EmpLastName = txtLastName.Text;
                if (rbtMale.Checked == true)
                {
                    obj.EmpGender = rbtMale.Text;
                }
                else
                {
                    obj.EmpGender = rbtFemale.Text;
                }
                obj.EmpMobile = txtMobileNo.Text;
                obj.EmpDOB = phani.Classes.General.toMMDDYYYY(txtDateOfBirth.Text);
                obj.EmpEMail = txtEmail.Text;
                obj.EmpAddress = txtAddress.Text;
                obj.EmpCity = txtCity.Text;
                obj.EmpPhone = txtPhoneNo.Text;
                obj.DeptID = ddlDepartment.SelectedItem.Value;
                obj.DesgID = ddlDesignation.SelectedItem.Value;
                // obj.BranchId = ddlBranch.SelectedItem.Value;
                obj.EmpDetDOJ = phani.Classes.General.toMMDDYYYY(txtDateOfAppointment.Text);
                obj.EmpDetDOT = phani.Classes.General.toMMDDYYYY(txtDateOfTermination.Text);
                obj.EmpTypeID = ddlEmployeeType.SelectedItem.Value;

                obj.EMPUserName = txtUserName.Text;
                obj.PASSWORD = txtPassword.Text;
                obj.CpId = ddlCompany.SelectedItem.Value;
                obj.PlantId = ddlLeaveApprover.SelectedItem.Value;
                obj.Empseries = txtEmpSeries.Text;
                obj.ACCOUNTNO = txtBankaccountNo.Text;
                obj.TDS = "0";
                obj.sALARY = txtsalary.Text;
                obj.Grade = ddlGrade.SelectedItem.Value;

                obj.Status = "New";

                obj.tEmpPhoto = "0x";

                //if(FileUpload1.HasFile == true)
                //{
                //    Stream fs = FileUpload1.PostedFile.InputStream;
                //    BinaryReader br = new BinaryReader(fs);
                //    Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                //    obj.tEmpPhoto = Encoding.UTF8.GetString(bytes);
                //}
                //else
                //{
                //    obj.tEmpPhoto = System.Data.SqlTypes.SqlBinary.Null.ToString();
                //}

                //Masters.UserMaster objuser = new Masters.UserMaster();
                //objuser.UserMaster_Save(obj.EMPUserName, obj.PASSWORD);

                MessageBox.Show(this, obj.Empoyee_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString());
            }
            finally
            {
                HR.ClearControls(this);
                HR.Dispose();
                //Thread.Sleep(5000);
                Response.Redirect("~/Modules/HR/EmployeeMaster.aspx", true);
            }
        }
        else
        {
            MessageBox.Show(this, "Please Change UserName Its already Taken");
        }
    }

    #endregion EmployeeMasterSave
}