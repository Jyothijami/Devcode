using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_CustomerDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();

        if (!IsPostBack)
        {
            Designation_Fill();
            txtCustomerCode.Text = SM.CustomerMaster.CustomerMaster_AutoGenCode();
            if (Qid != "Add")
            {
                 
                DepartmentFill();

            }
        }
    }

    private void Designation_Fill()
    {
       // Masters.Designation.Designation_Select(ddlDesignation);
        Masters.Designation.Designation_Select(ddlcustdesignation);
        Masters.RegionalMaster.RegionalMaster_Select(ddlregion);
        Masters.Salutation.Salutation_Select(ddlTitle);
    }

    private void DepartmentFill()
    {
        SM.CustomerMaster objmaster = new SM.CustomerMaster();
        if (objmaster.CustomerMaster_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";

            ddlTitle.SelectedItem.Value = objmaster.custdear;
            txtCustomerCode.Text = objmaster.CustCode;
            txtCustomerName.Text = objmaster.CustName;
            txtCompanyName.Text = objmaster.CompanyName;
            //txtContactPerson.Text = objmaster.CustContactPerson;
            txtCustPhone.Text = objmaster.custPhone;
            txtCustMobileNo.Text = objmaster.CustMobile;
            txtCustFaxNo.Text = objmaster.Custfax;
            txtCustEmail.Text = objmaster.CustEmail;
            //txtpanno.Text = objmaster.CustPan;
            //txtgstno.Text = objmaster.Custgst;
            ddlcustdesignation.SelectedValue = objmaster.custdesgid;
            txtCustAddress.Text = objmaster.custaddress;
            //txtContactPerson.Text = objmaster.corpcontactperson;
            //txtPhoneNumber.Text = objmaster.corpphone;
            //txtMobileNo.Text = objmaster.corpmobile;
            //txtEmailId.Text = objmaster.corpemail;
            //txtCorporateAddress.Text = objmaster.corpaddress;
            //ddlDesignation.SelectedValue = objmaster.corpdesgid;
            //txtFaxNo.Text = objmaster.corpfax;
          
            txtrefbyname.Text = objmaster.refbyname;
            txtrefbymobileno.Text = objmaster.refbycontact;
            txtrefbyaddress.Text = objmaster.refbyaddress;

            //txtarchiaddress.Text = objmaster.archiaddress;
            //txtarchimobileno.Text = objmaster.archicontact;
            //txtarchiname.Text = objmaster.architectname;

            //txtsiteAddress.Text = objmaster.siteinchargeaddress;
            //txtsitecontactPerson.Text = objmaster.siteinchargename;
            //txtsitemobileno.Text = objmaster.siteinchargecontact;
           
          //  ddlcustdesignation.SelectedValue = objmaster.custdesgid;
        }
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            try
            {
                 SM.CustomerMaster objmaster = new SM.CustomerMaster();
                 objmaster.custdear = ddlTitle.SelectedItem.Value ;
                 objmaster.CustCode = txtCustomerCode.Text ;
                 objmaster.CustName = txtCustomerName.Text ;
                 objmaster.CompanyName = txtCompanyName.Text ;
                 objmaster.CustContactPerson = "1";
                 objmaster.custPhone = txtCustPhone.Text ;
                 objmaster.CustMobile = txtCustMobileNo.Text ;
                 objmaster.Custfax = txtCustFaxNo.Text ;
                 objmaster.CustEmail = txtCustEmail.Text ;
                 objmaster.CustPan = "1" ;
                 objmaster.Custgst = "1" ;
                 objmaster.custdesgid = ddlcustdesignation.SelectedItem.Value;
                 objmaster.custaddress = txtCustAddress.Text;
                 objmaster.corpcontactperson = "1";
                 objmaster.corpphone = "1";
                 objmaster.corpmobile = "1";
                 objmaster.corpemail = "1";
                 objmaster.corpaddress = "1";
                 objmaster.corpdesgid = "1";
                 objmaster.corpfax = "1";
                 objmaster.custdesgid = ddlcustdesignation.SelectedItem.Value;
                 objmaster.custstatus = "1";
                 objmaster.regid = ddlregion.SelectedItem.Value;

                  objmaster.refbyname = txtrefbyname.Text ;
                  objmaster.refbycontact = txtrefbymobileno.Text;
                  objmaster.refbyaddress = txtrefbyaddress.Text;

                  objmaster.archiaddress = "1";
                  objmaster.archicontact = "1";
                  objmaster.architectname = "1";

                  objmaster.siteinchargeaddress = "1";
                  objmaster.siteinchargename = "1";
                  objmaster.siteinchargecontact = "1";

                 MessageBox.Notify(this, objmaster.CustomerMaster_Save());

                 ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);



            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                Masters.ClearControls(this);
               
               // Response.Redirect("~/Modules/Sales/CustomerMaster.aspx",false);
            }
        }

        if (btnSave.Text == "Update")
        {
            try
            {
                SM.CustomerMaster objmaster = new SM.CustomerMaster();
                objmaster.custdear = ddlTitle.SelectedItem.Value;
                objmaster.CustCode = txtCustomerCode.Text;
                objmaster.CustName = txtCustomerName.Text;
                objmaster.CompanyName = txtCompanyName.Text;
                objmaster.CustContactPerson = "1";
                objmaster.custPhone = txtCustPhone.Text;
                objmaster.CustMobile = txtCustMobileNo.Text;
                objmaster.Custfax = txtCustFaxNo.Text;
                objmaster.CustEmail = txtCustEmail.Text;
                objmaster.CustPan = "1";
                objmaster.Custgst = "1";
                objmaster.custdesgid = ddlcustdesignation.SelectedItem.Value;
                objmaster.custaddress = txtCustAddress.Text;
                objmaster.corpcontactperson = "1";
                objmaster.corpphone = "1";
                objmaster.corpmobile = "1";
                objmaster.corpemail = "1";
                objmaster.corpaddress = "1";
                objmaster.corpdesgid = "1";
                objmaster.corpfax = "1";
                objmaster.custdesgid = ddlcustdesignation.SelectedItem.Value;
                objmaster.custstatus = "1";
                objmaster.regid = ddlregion.SelectedItem.Value;
                objmaster.refbyname = txtrefbyname.Text;
                objmaster.refbycontact = txtrefbymobileno.Text;
                objmaster.refbyaddress = txtrefbyaddress.Text;

                objmaster.archiaddress = "1";
                objmaster.archicontact = "1";
                objmaster.architectname = "1";

                objmaster.siteinchargeaddress = "1";
                objmaster.siteinchargename = "1";
                objmaster.siteinchargecontact ="1";

                objmaster.Custid = Request.QueryString["Cid"].ToString();
                MessageBox.Notify(this, objmaster.CustomerMaster_Update());

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);


            }
            catch (Exception ex)
            {
                MessageBox.Notify(this, ex.Message);
            }
            finally
            {

                Masters.ClearControls(this);
               
              //  Response.Redirect("~/Modules/Sales/CustomerMaster.aspx",false);
            }
        }

    }
}