using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_EmployeeCTC : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());
    double amt;
    double Basic1 = 0;
    double Basic2 = 0;
    double Hra1 = 0;
    double Hra2 = 0;
    double ca1 = 0;
    double ca2 = 0;
    double mer1 = 0;
    double mer2 = 0;
    double Other1 = 0;
    double Other2 = 0;
    double GrossTotal1 = 0;
    double GrossTotal2 = 0;
    double Pf1 = 0;
    double Pf2 = 0;
    double esicd1 = 0;
    double esicd2 = 0;
    double Pt1 = 0;
    double Pt2 = 0;
    double ectotal1 = 0;
    double ectotal2 = 0;
    double gtd1 = 0;
    double gtd2 = 0;
    double pfb1 = 0;
    double pfb2 = 0;
    double esicb1 = 0;
    double esicb2 = 0;
    double accb1 = 0;
    double accb2 = 0;
    double bonusb1 = 0;
    double bonusb2 = 0;
    double totalb1 = 0;
    double totalb2 = 0;

    double CtcPm = 0;
    double CtcPa = 0;

    double NetPay = 0;



    protected void Page_Load(object sender, EventArgs e)
    {


       // txtbasicsalaryMonthly.Attributes.Add("onkeyup", "javascript:grosscalc();");

        if (!IsPostBack)
        {
           
            
            HR.EmployeeMaster.EmployeeMaster_Select(ddlEmployee);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            Masters.Designation.Designation_Select(ddlDesignation);
            Masters.Department.Department_Select(ddlDepartment);
            ddlpreparedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

        }
    }

    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        HR.EmployeeMaster obj = new HR.EmployeeMaster();
        if(obj.EmployeeMaster_Select(ddlEmployee.SelectedItem.Value) > 0)
        {
            ddlDesignation.SelectedValue = obj.DesgID;
            txtemployeeCode.Text = obj.Empseries;
            txtdoj.Text = obj.EmpDetDOJ;
            txtdob.Text = obj.EmpDOB;
            ddlDepartment.SelectedValue = obj.DeptID;
            txtage.Text = obj.GetAge(Convert.ToInt32(ddlEmployee.SelectedItem.Value)).ToString();
            txtGrossAmountYear.Text = obj.sALARY;

            amt = Convert.ToDouble(txtGrossAmountYear.Text);
            txtGrossAmount.Text = Math.Round((amt / 12)).ToString();





            HR.EmployeeCTC objctc = new HR.EmployeeCTC();
            if(objctc.EmployeeCTC_Select(ddlEmployee.SelectedItem.Value) > 0 )

            {
                txtbasicsalaryMonthly.Text = objctc.EarningsBasicSalary;
                txtbasicsalaryYearly.Text = (decimal.Parse(objctc.EarningsBasicSalary) * 12).ToString();

                txthouserentallowanceMonthly.Text = objctc.EarningsHouseRentallowance;
                txthouserentallowanceyearly.Text = (decimal.Parse(objctc.EarningsHouseRentallowance) * 12).ToString();

                txtConveyanceallowancemonthly.Text = objctc.EarningsCOnveyanceAllowance;
                txtconveyanceallowanceyearly.Text = (decimal.Parse(objctc.EarningsCOnveyanceAllowance) * 12).ToString();

                txtmedicalallowancemonthly.Text = objctc.EarningsMedicalAllowance;
                txtmedicalallowanceyearly.Text = (decimal.Parse(objctc.EarningsMedicalAllowance) * 12).ToString();


                txtotherallowancemonthly.Text = objctc.EarningsOtherAllowance;
                txtotherallowanceyearly.Text = (decimal.Parse(objctc.EarningsOtherAllowance) * 12).ToString();


                txtpfcontributionemployeemonthly.Text = objctc.StatutoryPfcontributions;
                txtpfcontributionemployeeyearly.Text = (decimal.Parse(objctc.StatutoryPfcontributions) * 12).ToString();

                txtesiccontributionemployeemonthly.Text = objctc.StatutoryEsicContribution;
                txtesiccontributionemployeeyearly.Text = (decimal.Parse(objctc.StatutoryEsicContribution) * 12).ToString();


                txtprofessionaltaxmonthly.Text = objctc.StatutoryProfessionaltax;
                txtprofessionaltaxYearly.Text = (decimal.Parse(objctc.StatutoryProfessionaltax) * 12).ToString();



                txtpfcontributionemployeermonthly.Text = objctc.StContributionpfconveyance;
                txtpfcontributionemployeerYearly.Text = (decimal.Parse(objctc.StContributionpfconveyance) * 12).ToString();


                txtesiccontributionemployeermonthly.Text = objctc.Stcontributionesicconveyance;
                txtesiccontributionemployeeryearly.Text = (decimal.Parse(objctc.Stcontributionesicconveyance) * 12).ToString();

                txtmonthlytotal.Text = objctc.Totalmonthly;
                txtyearlytotal.Text = (decimal.Parse(objctc.Totalmonthly) * 12).ToString();

                txttotalbmonthly.Text = objctc.Totalstatutorydeduction;
                txttotalbYearly.Text = (decimal.Parse(objctc.Totalstatutorydeduction) * 12).ToString();

                txttotalcmonthly.Text = objctc.TotalstatutoryContribution;
                txttotalcyearly.Text = (decimal.Parse(objctc.TotalstatutoryContribution) * 12).ToString();


                txttotalctcmonthly.Text = objctc.TotalCtc;
                txttotalctcyearly.Text = (decimal.Parse(objctc.TotalCtc) * 12).ToString();






             



                ddlpreparedby.SelectedValue = objctc.Preparedby;


            }





        }
    }












    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                HR.EmployeeCTC objMaster = new HR.EmployeeCTC();
                objMaster.EmpId = ddlEmployee.SelectedItem.Value;
                
                objMaster.EarningsBasicSalary =txtbasicsalaryMonthly.Text;
                objMaster.EarningsHouseRentallowance = txthouserentallowanceMonthly.Text;
                objMaster.EarningsCOnveyanceAllowance = txtConveyanceallowancemonthly.Text;
                objMaster.EarningsMedicalAllowance = txtmedicalallowancemonthly.Text;
                objMaster.EarningsOtherAllowance = txtotherallowancemonthly.Text;

                objMaster.StatutoryPfcontributions = txtpfcontributionemployeemonthly.Text;
                objMaster.StatutoryEsicContribution = txtesiccontributionemployeemonthly.Text;
                objMaster.StatutoryProfessionaltax = txtprofessionaltaxmonthly.Text;

                objMaster.StContributionpfconveyance = txtpfcontributionemployeermonthly.Text;
                objMaster.Stcontributionesicconveyance = txtesiccontributionemployeermonthly.Text;

                objMaster.Totalmonthly = txtmonthlytotal.Text;
                objMaster.Totalstatutorydeduction = txttotalbmonthly.Text;
                objMaster.TotalstatutoryContribution = txttotalcmonthly.Text;
                objMaster.TotalCtc = txttotalctcmonthly.Text;
                objMaster.Netsalary = txtnetsalarymonthly.Text;

                objMaster.Preparedby = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);

                MessageBox.Show(this, objMaster.EmployeeCTC_Save());
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

    protected void btnCalc_Click(object sender, EventArgs e)
    {
        if (txtGrossAmount.Text != "")
        {
            int sal = Convert.ToInt32(txtGrossAmount.Text);
            int age = Convert.ToInt32(txtage.Text);

            SqlCommand cmd = new SqlCommand("Usp_GetCTCAge", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@salary_fix", sal);
            cmd.Parameters.AddWithValue("@Age", age);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Basic1 = Convert.ToDouble(dt.Rows[0][0].ToString());
            txtbasicsalaryMonthly.Text = Math.Round(Basic1).ToString();
            Basic2 = Convert.ToDouble(txtbasicsalaryMonthly.Text);
            txtbasicsalaryYearly.Text = Math.Round(Basic2 * 12).ToString();

            Hra1 = Convert.ToDouble(dt.Rows[0][1].ToString());
            txthouserentallowanceMonthly.Text = Math.Round(Hra1).ToString();
            Hra2 = Convert.ToDouble(txthouserentallowanceMonthly.Text);
            txthouserentallowanceyearly.Text = Math.Round(Hra2 * 12).ToString();

            ca1 = Convert.ToDouble(dt.Rows[0][2].ToString());
            txtConveyanceallowancemonthly.Text = Math.Round(ca1).ToString();
            ca2 = Convert.ToDouble(txtConveyanceallowancemonthly.Text);
            txtconveyanceallowanceyearly.Text = Math.Round(ca2 * 12).ToString();

            mer1 = Convert.ToDouble(dt.Rows[0][3].ToString());
            txtmedicalallowancemonthly.Text = Math.Round(mer1).ToString();
            mer2 = Convert.ToDouble(txtmedicalallowancemonthly.Text);
            txtmedicalallowanceyearly.Text = Math.Round(mer2 * 12).ToString();

            Other1 = Convert.ToDouble(dt.Rows[0][4].ToString());
            txtotherallowancemonthly.Text = Math.Round(Other1).ToString();
            Other2 = Convert.ToDouble(txtotherallowancemonthly.Text);
            txtotherallowanceyearly.Text = Math.Round(Other2 * 12).ToString();

            GrossTotal1 = Convert.ToDouble(dt.Rows[0][5].ToString());
            txtmonthlytotal.Text = Math.Round(GrossTotal1).ToString();
            GrossTotal2 = Convert.ToDouble(txtmonthlytotal.Text);
            txtyearlytotal.Text = Math.Round(GrossTotal2 * 12).ToString();

            Pf1 = Convert.ToDouble(dt.Rows[0][6].ToString());
            txtpfcontributionemployeemonthly.Text = Math.Round(Pf1).ToString();
            Pf2 = Convert.ToDouble(txtpfcontributionemployeemonthly.Text);
            txtpfcontributionemployeeyearly.Text = Math.Round(Pf2 * 12).ToString();

            esicd1 = Convert.ToDouble(dt.Rows[0][7].ToString());
            txtesiccontributionemployeemonthly.Text = Math.Round(esicd1).ToString();
            esicd2 = Convert.ToDouble(txtesiccontributionemployeemonthly.Text);
            txtesiccontributionemployeeyearly.Text = Math.Round(esicd2 * 12).ToString();

            Pt1 = Convert.ToDouble(dt.Rows[0][8].ToString());
            txtprofessionaltaxmonthly.Text = Math.Round(Pt1).ToString();
            Pt2 = Convert.ToDouble(txtprofessionaltaxmonthly.Text);
            txtprofessionaltaxYearly.Text = Math.Round(Pt2 * 12).ToString();

            ectotal1 = Convert.ToDouble(dt.Rows[0][9].ToString());
            txttotalbmonthly.Text = Math.Round(ectotal1).ToString();
            ectotal2 = Convert.ToDouble(txttotalbmonthly.Text);
            txttotalbYearly.Text = Math.Round(ectotal2 * 12).ToString();

            gtd1 = Convert.ToDouble(dt.Rows[0][10].ToString());
            txtnetsalarymonthly.Text = Math.Round(gtd1).ToString();
            gtd2 = Convert.ToDouble(txtnetsalarymonthly.Text);
            txtnetsalaryYearly.Text = Math.Round(gtd2 * 12).ToString();

            pfb1 = Convert.ToDouble(dt.Rows[0][11].ToString());
            txtpfcontributionemployeermonthly.Text = Math.Round(pfb1).ToString();
            pfb2 = Convert.ToDouble(txtpfcontributionemployeermonthly.Text);
            txtpfcontributionemployeerYearly.Text = Math.Round(pfb2 * 12).ToString();

            esicb1 = Convert.ToDouble(dt.Rows[0][12].ToString());
            txtesiccontributionemployeermonthly.Text = Math.Round(esicb1).ToString();
            esicb2 = Convert.ToDouble(txtesiccontributionemployeermonthly.Text);
            txtesiccontributionemployeeryearly.Text = Math.Round(esicb2 * 12).ToString();

            //accb1 = Convert.ToDouble(dt.Rows[0][13].ToString());
            //txtACCB1.Text = Math.Round(accb1).ToString();
            //accb2 = Convert.ToDouble(txtACCB1.Text);
            //txtACCB2.Text = Math.Round(accb2 * 12).ToString();

            //bonusb1 = Convert.ToDouble(dt.Rows[0][14].ToString());
            //txtBONUSB1.Text = Math.Round(bonusb1).ToString();
            //bonusb2 = Convert.ToDouble(txtBONUSB1.Text);
            //txtBONUSB2.Text = Math.Round(bonusb2 * 12).ToString();

            totalb1 = Convert.ToDouble(dt.Rows[0][15].ToString());
            txttotalcmonthly.Text = Math.Round(totalb1).ToString();
            totalb2 = Convert.ToDouble(txttotalcmonthly.Text);
            txttotalcyearly.Text = Math.Round(totalb2 * 12).ToString();

            txttotalctcmonthly.Text = (GrossTotal2 + totalb2).ToString();
            CtcPa = Convert.ToDouble(txttotalctcmonthly.Text);
            txttotalctcyearly.Text = Math.Round(CtcPa * 12).ToString();








        }
    }
} 