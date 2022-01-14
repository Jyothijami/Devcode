using phani.Classes;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Reports_CustomerProjectReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            SM.CustomerMaster.CustomerUnit_Select(ddlproject);
            SM.CustomerMaster.CustomerMaster_Select(ddlCustomer);
            SM.SalesOrder.SalesOrder_Select(ddlSoId);
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
      


        SCM.SupplierQuotation supqua = new SCM.SupplierQuotation();
        //if(supqua.SupplierQuotation_Select(lblIndappId.Text) > 0)
        //{
        //    lblPurquatationno.Text = supqua.QuotNo;
        //    lblpurquatationdate.Text = supqua.QuotDate;
        //    lblpurquatationid.Text = supqua.QuotId;
        //    lblPurchaseQuatationStatus.Text = "Created";
        //}
        //else
        //{
        //    lblPurchaseQuatationStatus.Text = "Not Created";
        //}


        //SCM.SupPo suppo = new SCM.SupPo();
        //if(suppo.SupPoSupQua_Select(lblpurquatationid.Text) > 0)
        //{
        //    lblPONo.Text = suppo.PONo;
        //    lblPOdate.Text = suppo.PoDate;
        //    lblPurchaseOrderid.Text = suppo.PoId;
        //    lblpurchaseorderStatus.Text = "PO Created";
        //}
        //else
        //{
        //    lblpurchaseorderStatus.Text = "Not Created";
        //}


        //SCM.PurchaseReceipt purrece = new SCM.PurchaseReceipt();
        //if(purrece.PurchaseReceiptPO_Select(lblPurchaseOrderid.Text) > 0)
        //{
        //        lblPurchaseReceiptNo.Text = purrece.SPrNo;
        //        lblPurchaseReceiptdate.Text = purrece.SPrDate;
        //        lblPurchasereceiptId.Text = purrece.SPrId;
        //        lblPurchaseReceiptStatus.Text = "Material Recieved";
        //}
        //else
        //{
        //    lblPurchaseReceiptStatus.Text = "Not Received";
        //}


        //SCM.MaterialIssue Matissue = new SCM.MaterialIssue();
        //if (Matissue.MaterialIssueSoId_Select(lblsoId.Text) > 0)
        //{
        //    lblMaterialissueno.Text = Matissue.IssueNo;
        //    lblMaterialissuedate.Text = Matissue.IssueDate;
        //    lblmaterialissueid.Text = Matissue.MaterialIssueId;
        //    lblMaterialIssuedStatus.Text = "Material Issued";
        //}
        //else
        //{
        //    lblPurchaseReceiptStatus.Text = "Production Not Started";
        //}

    }
    protected void ddlSoId_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesOrder obj = new SM.SalesOrder();
        if(obj.SalesOrder_Select(ddlSoId.SelectedItem.Value) > 0)
        {
            ddlCustomer.SelectedValue = obj.Custid;
            ddlproject.SelectedValue = obj.SiteId;



            lblEnquiryCount.Text = General.CountofRecordsWithQuery("select count(CUST_ID) from SalesEnquiry_Master where CUST_ID ='" + obj.Custid + "' ").ToString();
            General.GridBindwithCommand(gvEnquires, "select *,Cou = (select count(*) from Enquiry_FloorPlanDetails where Enquiry_FloorPlanDetails.ENQ_ID = SalesEnquiry_Master.ENQ_ID ),ENQ_NO+' '+REVISEDKEY as enno from SalesEnquiry_Master,Customer_Master where SalesEnquiry_Master.CUST_ID = Customer_Master.CUST_ID and SalesEnquiry_Master.CUST_ID ='"+ obj.Custid +"'");

            

            lblquationscount.Text = General.CountofRecordsWithQuery("select count(Cust_ID)  from Quotation_Master where Cust_ID ='" + obj.Custid + "' ").ToString();
            General.GridBindwithCommand(gvTotalQuatations, "SELECT Quotation_Master.Quotation_No + ' ' + Quotation_Master.RevisedKey AS QUOTNO,Quotation_Master.OptionKey , Quotation_Master.Quotation_Id, Quotation_Master.Quotation_No, Quotation_Master.Quotation_Date, Quotation_Master.Quotation_to, Quotation_Master.Valid_To, Quotation_Master.Enq_Id, Quotation_Master.Cust_ID, Quotation_Master.Unit_Id, Quotation_Master.SalesEmp_Id, Quotation_Master.PaymentTerms_Id, Quotation_Master.TermsCondtions_Id, Quotation_Master.Discount, Quotation_Master.Tax, Quotation_Master.GrandTotal, Quotation_Master.PreparedBy, Quotation_Master.ApprovedBy, Quotation_Master.RevisedKey, Quotation_Master.Status, Quotation_Master.InstallationTemp_Id, Quotation_Master.DamageTemp_Id, Quotation_Master.StorageTemp_Id, Quotation_Master.Specifications, Customer_Master.CUST_NAME, Employee_Master.EMP_FIRST_NAME, Customer_Units.CUST_UNIT_NAME FROM Customer_Master INNER JOIN Quotation_Master ON Customer_Master.CUST_ID = Quotation_Master.Cust_ID INNER JOIN Employee_Master ON Quotation_Master.PreparedBy = Employee_Master.EMP_ID INNER JOIN Customer_Units ON Quotation_Master.Unit_Id = Customer_Units.CUST_UNIT_ID where Quotation_Master.Cust_ID ='" + obj.Custid + "'");


            lblsalesorderstatus.Text = "Prepared";
            General.GridBindwithCommand(gvSalesorder, "SELECT Sales_Order.SalesOrder_Id,Sales_Order.ProjectCode, Sales_Order.SalesOrder_No, Sales_Order.SalesOrder_Date, Sales_Order.Delivery_Date, Sales_Order.PreparedBy, Sales_Order.Status, Employee_Master.EMP_FIRST_NAME, Customer_Master.CUST_NAME, Customer_Units.CUST_UNIT_NAME FROM Sales_Order INNER JOIN Employee_Master ON Sales_Order.PreparedBy = Employee_Master.EMP_ID INNER JOIN Customer_Master ON Sales_Order.CustId = Customer_Master.CUST_ID INNER JOIN Customer_Units ON Sales_Order.CustSiteId = Customer_Units.CUST_UNIT_ID where Sales_Order.SalesOrder_Id ='" + obj.SOID + "'");

            #region MaterialRqstIssue

            int IssReqCount = General.CountofRecordsWithQuery("select count(*) from Request_Material_Issue where SO_ID = '" + obj.SOID + "'");
            if (IssReqCount > 0)
            {
                lblNoOfIRs.Text = "Generated";
                lblNoOfIRscount.Text = IssReqCount.ToString();

            }
            else
            {
                lblNoOfIRs.Text = "Not Generated";
                lblNoOfIRs.Text = "0";
            }
            SqlCommand cmd1 = new SqlCommand("[USP_IssReq_Serach]", con);
            cmd1.CommandType = CommandType.StoredProcedure;

            if (ddlSoId.SelectedValue != "0")
            {
                cmd1.Parameters.AddWithValue("@SOID", ddlSoId.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvIssReq.DataSource = dt;
                gvIssReq.DataBind();
            }
            #endregion

            #region NRGPReqst

            int NRGPRqst = General.CountofRecordsWithQuery("select count(*) from NRGP_Request where Project = '" + obj.SOID + "'");
            if (NRGPRqst > 0)
            {
                lblNRGP .Text = "Generated";
                lblNRGPcount.Text = NRGPRqst.ToString();

            }
            else
            {
                lblNRGP.Text = "Not Generated";
                lblNRGPcount.Text = "0";
            }
            SqlCommand cmdNRGP = new SqlCommand("[USP_NRGPReq_Serach]", con);
            cmdNRGP.CommandType = CommandType.StoredProcedure;

            if (ddlSoId.SelectedValue != "0")
            {
                cmdNRGP.Parameters.AddWithValue("@SOID", ddlSoId.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmdNRGP);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvNRGPRqst.DataSource = dt;
                gvNRGPRqst.DataBind();
            }
            #endregion

            #region RGPReqst

            int RGPRqst = General.CountofRecordsWithQuery("select count(*) from RGP_Request where Project = '" + obj.SOID + "'");
            if (RGPRqst > 0)
            {
                lblRGPRqst.Text = "Generated";
                lblRGPRqstCount.Text = RGPRqst.ToString();

            }
            else
            {
                lblRGPRqst.Text = "Not Generated";
                lblRGPRqstCount.Text = "0";
            }
            SqlCommand cmdRGP = new SqlCommand("[USP_RGPReq_Serach]", con);
            cmdRGP.CommandType = CommandType.StoredProcedure;

            if (ddlSoId.SelectedValue != "0")
            {
                cmdRGP.Parameters.AddWithValue("@SOID", ddlSoId.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmdRGP);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvRGPRqst.DataSource = dt;
                gvRGPRqst.DataBind();
            }
            #endregion

            #region PLReqst

            int PLReqst = General.CountofRecordsWithQuery("select count(*) from Request_PackingList where SO_Id = '" + obj.SOID + "'");
            if (PLReqst > 0)
            {
                lblPLReq.Text = "Generated";
                lblPLReqCount.Text = PLReqst.ToString();

            }
            else
            {
                lblPLReq.Text = "Not Generated";
                lblPLReqCount.Text = "0";
            }
            SqlCommand cmdRPL = new SqlCommand("[USP_PackListReq_Serach]", con);
            cmdRPL.CommandType = CommandType.StoredProcedure;

            if (ddlSoId.SelectedValue != "0")
            {
                cmdRPL.Parameters.AddWithValue("@SOID", ddlSoId.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmdRPL);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvPLRqst.DataSource = dt;
                gvPLRqst.DataBind();
            }
            #endregion

            #region GlassReqst

            int GlassReqst = General.CountofRecordsWithQuery("select count(*) from Glass_Request where SO_Id = '" + obj.SOID + "'");
            if (GlassReqst > 0)
            {
                lblGlassRqst.Text = "Generated";
                lblGlassRqstCount.Text = GlassReqst.ToString();

            }
            else
            {
                lblGlassRqst.Text = "Not Generated";
                lblGlassRqstCount.Text = "0";
            }
            SqlCommand cmdGlassReqst = new SqlCommand("[USP_GlassRequest_Serach]", con);
            cmdGlassReqst.CommandType = CommandType.StoredProcedure;

            if (ddlSoId.SelectedValue != "0")
            {
                cmdGlassReqst.Parameters.AddWithValue("@SOID", ddlSoId.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmdGlassReqst);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvGlassRqst.DataSource = dt;
                gvGlassRqst.DataBind();
            }
            #endregion

            #region BOM
            int count = General.CountofRecordsWithQuery("select count(*) from SalesOrder_MaterialAnalysis where SO_ID = '" + obj.SOID + "'");
            if (count > 0)
            {
                lblbomstatus.Text = "Generated";
                lblbomcount.Text = count.ToString();

            }
            else
            {
                lblbomstatus.Text = "Not Generated";
                lblbomcount.Text = "0";
            }

            SqlCommand cmd = new SqlCommand("[USP_BOM_Serach]", con);
            cmd.CommandType = CommandType.StoredProcedure;

            if (ddlSoId.SelectedValue != "0")
            {
                cmd.Parameters.AddWithValue("@SOID", ddlSoId.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvbom.DataSource = dt;
                gvbom.DataBind();
            }
            #endregion

            #region MaterialIssue

            int MaterialIssue = General.CountofRecordsWithQuery("select count(*) from Material_Issue where SO_Id = '" + obj.SOID + "'");
            if (MaterialIssue > 0)
            {
                lblIssue.Text = "Generated";
                lblIssueCount.Text = MaterialIssue.ToString();

            }
            else
            {
                lblIssue.Text = "Not Generated";
                lblIssueCount.Text = "0";
            }
            SqlCommand cmdMIssue = new SqlCommand("[USP_MaterialIssue_Serach1]", con);
            cmdMIssue.CommandType = CommandType.StoredProcedure;

            if (ddlSoId.SelectedValue != "0")
            {
                cmdMIssue.Parameters.AddWithValue("@SOID", ddlSoId.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmdMIssue);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvIssue .DataSource = dt;
                gvIssue.DataBind();
            }
            #endregion

            #region NRGPIssue

            int NRGPIssue = General.CountofRecordsWithQuery("select count(*) from NRGP where ProjectId = '" + obj.SOID + "'");
            if (NRGPIssue > 0)
            {
                lblNRGPIssue.Text = "Generated";
                lblNRGPIssueCount.Text = NRGPIssue.ToString();

            }
            else
            {
                lblNRGPIssue.Text = "Not Generated";
                lblNRGPIssueCount.Text = "0";
            }
            General.GridBindwithCommand(gvIssNRGP, "SELECT * from NRGP where NRGP.ProjectId= '" + obj.SOID + "'");
            #endregion

            #region RGPIssue

            int RGPIssue = General.CountofRecordsWithQuery("select count(*) from RGP where ProjectId = '" + obj.SOID + "'");
            if (RGPIssue > 0)
            {
                lblRGPIssue.Text = "Generated";
                lblRGPIssueCount.Text = RGPIssue.ToString();

            }
            else
            {
                lblRGPIssue.Text = "Not Generated";
                lblRGPIssueCount.Text = "0";
            }
            General.GridBindwithCommand(gvIssRGP, "SELECT * from RGP where RGP.ProjectId= '" + obj.SOID + "'");
            #endregion

            #region PLIssue

            int PLIssue = General.CountofRecordsWithQuery("select count(*) from Packing_List where SO_Id = '" + obj.SOID + "'");
            if (PLIssue > 0)
            {
                lblPLIssue.Text = "Generated";
                lblPLIssueCount.Text = PLIssue.ToString();

            }
            else
            {
                lblPLIssue.Text = "Not Generated";
                lblPLIssueCount.Text = "0";
            }
            General.GridBindwithCommand(gvPLIssue, "SELECT * from Packing_List where SO_Id= '" + obj.SOID + "'");
            #endregion

            #region GlassIssue

            int GlassIssue = General.CountofRecordsWithQuery("select count(*) from Glass_Issue where SO_Id = '" + obj.SOID + "'");
            if (GlassIssue > 0)
            {
                lblGlassIssue.Text = "Generated";
                lblGlassIssueCount.Text = GlassIssue.ToString();

            }
            else
            {
                lblGlassIssue.Text = "Not Generated";
                lblGlassIssueCount.Text = "0";
            }
            SqlCommand cmdGlassIssue = new SqlCommand("[USP_GlassIssue_Serach]", con);
            cmdGlassIssue.CommandType = CommandType.StoredProcedure;

            if (ddlSoId.SelectedValue != "0")
            {
                cmdGlassIssue.Parameters.AddWithValue("@SOID", ddlSoId.SelectedItem.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmdGlassIssue);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvGlassIssue.DataSource = dt;
                gvGlassIssue.DataBind();
            }
            #endregion

            #region SOOperations

            int SOOperations = General.CountofRecordsWithQuery("select count(*) from Glass_Issue where SO_Id = '" + obj.SOID + "'");
            if (SOOperations > 0)
            {
                lblGlassIssue.Text = "Generated";
                lblGlassIssueCount.Text = SOOperations.ToString();

            }
            else
            {
                lblGlassIssue.Text = "Not Generated";
                lblGlassIssueCount.Text = "0";
            }
            SqlCommand cmdSOOperations = new SqlCommand("Select *, CONVERT(varchar, Start_Date, 3) as Startdate,CONVERT(varchar, End_Date, 3) as EndDate ,  'Window Code :'+ Code+' '+'Series :'+Series as Wincode from SO_Window_Operations,Sales_Order,SalesOrder_Details where SO_Window_Operations.So_Id = Sales_Order.SalesOrder_Id and SO_Window_Operations.So_Det_Id = SalesOrder_Details.SalesOrderDet_Id  and  Sales_Order.SalesOrder_Id =@SOID ", con);
            cmdSOOperations.CommandType = CommandType.Text;

            if (ddlSoId.SelectedValue != "0")
            {
                cmdSOOperations.Parameters.AddWithValue("@SOID", ddlSoId.SelectedItem.Value);

                SqlDataAdapter da = new SqlDataAdapter(cmdSOOperations);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvSOOperations.DataSource = dt;
                gvSOOperations.DataBind();
            }
            #endregion

            #region Indent

            lblindentscount.Text = General.CountofRecordsWithQuery("select count(SO_Id) from MaterialRequest where SO_Id = '" + obj.SOID + "'").ToString(); ;
            General.GridBindwithCommand(gvIndent, "SELECT *,EMP_FIRST_NAME+''+EMP_LAST_NAME as empname from MaterialRequest ,Employee_Master where MaterialRequest.Prepared_By = Employee_Master.EMP_ID and MaterialRequest.SO_Id ='" + obj.SOID + "'");

            #endregion





            General.GridBindwithCommand(gvpo, "SELECT        Supplier_Po_Master.CustomerNo, Supplier_Po_Master.Sup_PO_Id, Supplier_Po_Master.Sup_PO_No, Supplier_Po_Master.Sup_PO_Date, Supplier_Quotation_Master.Sup_Quo_No," +
                        " Supplier_Quotation_Master.Sup_Quo_Date, Supplier_Master.SUP_NAME, Supplier_Master.SUP_MOBILE, Employee_Master.EMP_FIRST_NAME + '' + Employee_Master.EMP_LAST_NAME AS preparedby," +
                        " Supplier_Po_Details.SO_Id, Material_Master.Material_Code, Color_Master.Color_Name, Supplier_Po_Details.Length, Supplier_Po_Details.ReqQty, Supplier_Po_Details.RemainingQty, " +
                        " Supplier_Po_Details.Amount " +
                        " FROM Supplier_Po_Master INNER JOIN " +
                        " Supplier_Master ON Supplier_Po_Master.Sup_Id = Supplier_Master.SUP_ID INNER JOIN " +
                        " Supplier_Quotation_Master ON Supplier_Po_Master.Matrequest_Id = Supplier_Quotation_Master.Sup_Quo_Id INNER JOIN " +
                        " Employee_Master ON Supplier_Po_Master.PreparedBy = Employee_Master.EMP_ID INNER JOIN " +
                        " Supplier_Po_Details ON Supplier_Po_Master.Sup_PO_Id = Supplier_Po_Details.Sup_PO_Id INNER JOIN " +
                        " Material_Master ON Supplier_Po_Details.ItemCode = Material_Master.Material_Id INNER JOIN " +
                        " Color_Master ON Supplier_Po_Details.Color_Id = Color_Master.Color_Id " +
                        " where Supplier_Po_Details.SO_Id = '" + obj.SOID + "' ORDER BY Supplier_Po_Master.Sup_PO_Id DESC ");





        }

    }
}