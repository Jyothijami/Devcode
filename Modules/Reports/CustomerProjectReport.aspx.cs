using phani.Classes;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Reports_CustomerProjectReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            SM.CustomerMaster.CustomerMaster_Select(ddlCustomer);
        }
    }
    protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.CustomerMaster.CustomerUnit_Select(ddlproject, ddlCustomer.SelectedItem.Value);
    }

    protected void ddlproject_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesEnquiry obj = new SM.SalesEnquiry();
        SM.SalesQuotation obj1 = new SM.SalesQuotation();
        if(obj.SalesEnquiry_Select(ddlproject.SelectedItem.Value) > 0)
        {
            lblEnquiryStarted.Text = "";
            lblenquiryDate.Text = obj.EnqDate;
            lblenquiryNo.Text = obj.EnqNo;
            lblEnquiryStarted.Text = obj.status;
        }
        else
        {
            lblEnquiryStarted.Text = "Not Started";
        }

        if (obj1.SalesQuotationCust_Select(ddlproject.SelectedItem.Value) > 0)
        {
            lblQuatationStatus.Text = "";
            lblQuatationDate.Text = obj1.QuotDate;
            lblQuatationNo.Text = obj1.QuotNo;
            lblQuatationID.Text = obj1.QuotId;
            lblQuatationStatus.Text = obj1.Status;

            lblProjectName.Text = ddlproject.SelectedItem.Text;
            General.GridBindwithCommand(gvTotalQuatations, "SELECT Quotation_Master.Quotation_No + ' ' + Quotation_Master.RevisedKey AS QUOTNO, Quotation_Master.Quotation_Id, Quotation_Master.Quotation_No, Quotation_Master.Quotation_Date,  Quotation_Master.GrandTotal, Quotation_Master.Status from  Quotation_Master INNER JOIN Customer_Units ON Quotation_Master.Unit_Id = Customer_Units.CUST_UNIT_ID where Quotation_Master.Unit_Id ='" + ddlproject.SelectedItem.Value + "' ");
        }
        else
        {
            lblQuatationStatus.Text = "Not Started";
        }

        SM.SalesOrder obj2 = new SM.SalesOrder();
        if (obj2.SalesOrderCust_Select(lblQuatationID.Text) > 0)
        {
            lblSalesorderStatus.Text = "";
            lblSono.Text = obj2.SONO;
            lblSoDate.Text = obj2.SODATE;
            lblsoId.Text = obj2.SOID;
            lblSalesorderStatus.Text = obj2.Status;


            int count = General.CountofRecordsWithQuery("select count(*) from SalesOrder_MaterialAnalysis where SO_ID = '"+lblsoId.Text+"'");

            if(count > 0)
            {
                lblBomStatus.Text = "Generated";
                lblnoofmaterial.Text = count.ToString();
                int Countissued = General.CountofRecordsWithQuery("select count(Issued_Qty) from SalesOrder_MaterialAnalysis where SO_ID = '" + lblsoId.Text + "'");

                if(Countissued > 0)
                {
                    lblissuedmaterial.Text = Countissued.ToString();
                }
                else
                {
                    lblissuedmaterial.Text = "0";
                }

            }
            else
            {
                lblBomStatus.Text = "Not Generated";
            }

        }
        else
        {
            lblSalesorderStatus.Text = "Not Started";
        }


        SCM.MaterialRequest matreq = new SCM.MaterialRequest();
        if(matreq.MaterialRequestSo_Select(lblsoId.Text) > 0)
        {
            lblindentid.Text = matreq.MreqId;
            lblindentno.Text = matreq.MRno;
            lblindentdate.Text = matreq.Mrdate;
            lblIndentStatus.Text = "Indent Raised";
        }
        else
        {
            lblIndentStatus.Text = "Indent Not Raised";
        }

        SCM.IndentApproval indapp = new SCM.IndentApproval();
        if(indapp.IndentApprovalIndid_Select(lblindentid.Text) > 0)
        {
            lblIndapprvaldate.Text = indapp.IndappDate;
            lblIndapprvalno.Text = indapp.IndappNo;
            lblIndappId.Text = indapp.IndappId;
            lblIndentapprovalStatus.Text = "Indent Approved";
        }
        else
        {
            lblIndentapprovalStatus.Text = "Not Started";
        }

        SCM.SupplierQuotation supqua = new SCM.SupplierQuotation();
        if(supqua.SupplierQuotation_Select(lblIndappId.Text) > 0)
        {
            lblPurquatationno.Text = supqua.QuotNo;
            lblpurquatationdate.Text = supqua.QuotDate;
            lblpurquatationid.Text = supqua.QuotId;
            lblPurchaseQuatationStatus.Text = "Created";
        }
        else
        {
            lblPurchaseQuatationStatus.Text = "Not Created";
        }


        SCM.SupPo suppo = new SCM.SupPo();
        if(suppo.SupPoSupQua_Select(lblpurquatationid.Text) > 0)
        {
            lblPONo.Text = suppo.PONo;
            lblPOdate.Text = suppo.PoDate;
            lblPurchaseOrderid.Text = suppo.PoId;
            lblpurchaseorderStatus.Text = "PO Created";
        }
        else
        {
            lblpurchaseorderStatus.Text = "Not Created";
        }


        SCM.PurchaseReceipt purrece = new SCM.PurchaseReceipt();
        if(purrece.PurchaseReceiptPO_Select(lblPurchaseOrderid.Text) > 0)
        {
                lblPurchaseReceiptNo.Text = purrece.SPrNo;
                lblPurchaseReceiptdate.Text = purrece.SPrDate;
                lblPurchasereceiptId.Text = purrece.SPrId;
                lblPurchaseReceiptStatus.Text = "Material Recieved";
        }
        else
        {
            lblPurchaseReceiptStatus.Text = "Not Received";
        }


        SCM.MaterialIssue Matissue = new SCM.MaterialIssue();
        if (Matissue.MaterialIssueSoId_Select(lblsoId.Text) > 0)
        {
            lblMaterialissueno.Text = Matissue.IssueNo;
            lblMaterialissuedate.Text = Matissue.IssueDate;
            lblmaterialissueid.Text = Matissue.MaterialIssueId;
            lblMaterialIssuedStatus.Text = "Material Issued";
        }
        else
        {
            lblPurchaseReceiptStatus.Text = "Production Not Started";
        }

    }
}