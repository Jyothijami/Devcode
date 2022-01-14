using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_Lead_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

        if (!IsPostBack)
        {
           
            txtleadno.Text = SM.Lead.Lead_AutoGenCode();
            HR.EmployeeMaster.EmployeeMaster_Select(ddlleadowner);
            Masters.LeadSource.LeadSource_Select(ddlSource);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlassignedto);
            Masters.Salutation.Salutation_Select(ddlSalutation);
            Masters.IndustryType.IndustryType_Select(ddlIndustry);
            Masters.CompanyProfile.Company_Select(ddlCompany);
            Masters.State.State_Select(ddlstate);
            Masters.City.City_Select(ddlCity);
            ddlleadowner.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            txtNextContactDate.Text = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            ddlCompany.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.CpId);

            txtleaddate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            
            if (Qid != "Add")
            {

                DepartmentFill();

            }
        }
    }

    private void DepartmentFill()
    {
        SM.Lead objmaster = new SM.Lead();
        if (objmaster.Lead_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            txtleadno.Text = objmaster.LeadNo;
            ddlstatus.SelectedItem.Text = objmaster.Status;
            txtPersonName.Text = objmaster.PersonName;
           // ddlgender.SelectedItem.Text = objmaster.Gender;
            txtorganzationName.Text = objmaster.OrganizationName;
            ddlSource.SelectedValue = objmaster.LeadSourceId;
            txtleaddate.Text = objmaster.LeadDate;
            txtEmailAddress.Text = objmaster.EmailId;
            ddlleadowner.SelectedValue = objmaster.LeadOwnerId;
            txtNextContactDate.Text = objmaster.NextContactDate;
            txtPhone.Text = objmaster.Phone;
            ddlSalutation.SelectedValue = objmaster.SalutaionId;
            txtMobileNO.Text = objmaster.MobileNO;
            txtFaxNo.Text = objmaster.Fax;
            ddlMarketSegment.SelectedItem.Text = objmaster.MarketSegment;
            ddlIndustry.SelectedValue = objmaster.IndustryId;
            ddlRequesttype.SelectedItem.Text = objmaster.Requesttype;
            ddlCompany.SelectedValue = objmaster.Cpid;
            ddlassignedto.SelectedValue = objmaster.NextContactBy;
            ddlstate.SelectedValue = objmaster.StateId;
            ddlstate_SelectedIndexChanged(new object(), new System.EventArgs());
            ddlCity.SelectedValue = objmaster.CityId;
            txtNotes.Text = objmaster.Notes;
            ddlpriority.SelectedItem.Text = objmaster.Prority;
            txtSubject.Text = objmaster.Subject;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                SM.Lead objmaster = new SM.Lead();
                objmaster.Status = ddlstatus.SelectedItem.Value;
                objmaster.PersonName = txtPersonName.Text;
                //objmaster.Gender = ddlgender.SelectedItem.Value;
                objmaster.OrganizationName = txtorganzationName.Text;
                objmaster.LeadSourceId = ddlSource.SelectedItem.Value;
                objmaster.EmailId = txtEmailAddress.Text;
                objmaster.LeadOwnerId = ddlleadowner.SelectedItem.Value;
                objmaster.NextContactDate = General.toMMDDYYYY(txtNextContactDate.Text);
                objmaster.NextContactBy = ddlassignedto.SelectedItem.Value;

                objmaster.Phone = txtPhone.Text;
                objmaster.SalutaionId = ddlSalutation.SelectedItem.Value;
                objmaster.MobileNO = txtMobileNO.Text;
                objmaster.Fax = txtFaxNo.Text;
                objmaster.MarketSegment = ddlMarketSegment.SelectedItem.Value;
                objmaster.IndustryId = ddlIndustry.SelectedItem.Value;

                objmaster.Requesttype = ddlRequesttype.SelectedItem.Value;

                objmaster.LeadNo = txtleadno.Text;
                objmaster.LeadDate = General.toMMDDYYYY(txtleaddate.Text);
                objmaster.Cpid = ddlCompany.SelectedItem.Value;

                objmaster.StateId = ddlstate.SelectedItem.Value;
                objmaster.CityId = ddlCity.SelectedItem.Value;

                objmaster.Notes = txtNotes.Text;
                objmaster.Prority = ddlpriority.SelectedItem.Text;
                objmaster.Subject = txtSubject.Text;


                MessageBox.Notify(this, objmaster.Lead_Save());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                SM.ClearControls(this);
                SM.Dispose();

               //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true); Response.Redirect("~/Modules/Sales/Lead.aspx");

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                SM.Lead objmaster = new SM.Lead();
                objmaster.Status = ddlstatus.SelectedItem.Value;
                objmaster.PersonName = txtPersonName.Text;
               // objmaster.Gender = ddlgender.SelectedItem.Value;
                objmaster.OrganizationName = txtorganzationName.Text;
                objmaster.LeadSourceId = ddlSource.SelectedItem.Value;
                objmaster.EmailId = txtEmailAddress.Text;
                objmaster.LeadOwnerId = ddlleadowner.SelectedItem.Value;
                objmaster.NextContactDate = General.toMMDDYYYY(txtNextContactDate.Text);
                objmaster.NextContactBy = ddlassignedto.SelectedItem.Value;

                objmaster.Phone = txtPhone.Text;
                objmaster.SalutaionId = ddlSalutation.SelectedItem.Value;
                objmaster.MobileNO = txtMobileNO.Text;
                objmaster.Fax = txtFaxNo.Text;
                objmaster.MarketSegment = ddlMarketSegment.SelectedItem.Value;
                objmaster.IndustryId = ddlIndustry.SelectedItem.Value;

                objmaster.Requesttype = ddlRequesttype.SelectedItem.Value;

                objmaster.LeadNo = txtleadno.Text;
                objmaster.LeadDate = General.toMMDDYYYY(txtleaddate.Text);
                objmaster.Cpid = ddlCompany.SelectedItem.Value;
                objmaster.StateId = ddlstate.SelectedItem.Value;
                objmaster.CityId = ddlCity.SelectedItem.Value;
                objmaster.LeadId = Request.QueryString["Cid"].ToString();

                objmaster.Notes = txtNotes.Text;
                objmaster.Prority = ddlpriority.SelectedItem.Text;
                objmaster.Subject = txtSubject.Text;
                MessageBox.Notify(this, objmaster.Lead_Update());
            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                SM.ClearControls(this);
                SM.Dispose();
              //  Response.Redirect("~/Modules/Sales/Lead.aspx");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
            }
        }
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.City.City_Select(ddlCity, ddlstate.SelectedItem.Value);
    }
}