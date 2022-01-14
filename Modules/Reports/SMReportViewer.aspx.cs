using CrystalDecisions.CrystalReports.Engine;
using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using System.Net;


public partial class Modules_REPORTS_SMReportViewer : System.Web.UI.Page
{
    string reportType; string mailAttachPath;
    private ReportDocument myRep = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        mailAttachPath = AppDomain.CurrentDomain.BaseDirectory + "mailattach\\";
        if (Request.QueryString["type"] != null)
        {
            reportType = Request.QueryString["type"].ToString();
        }

        RunReport();
    }

    private void RunReport()
    {
        string returnFileName = "";
        switch (reportType)
        {

            case "quot":
                {
                    SalesQuotationReport("SimpleQuatation - Basic", Request.QueryString["qno"].ToString());
                    break;
                }



            case "quotSummary":
                {
                    SalesQuotationReport("QuatationSummary", Request.QueryString["qno"].ToString());
                    break;
                }


            case "Compare":
                {
                    CompareSalesQuotationReport("Compare", Request.QueryString["qno"].ToString());
                    break;
                }



            case "quotColor":
                {
                    SalesQuotationReport("SimpleQuatation - Color", Request.QueryString["qno"].ToString());
                    break;
                }

            case "quotImage":
                {
                    SalesQuotationReport("SimpleQuatation - Image", Request.QueryString["qno"].ToString());
                    break;
                }

            case "quotDiscount":
                {
                    SalesQuotationReport("SimpleQuatation - Discount", Request.QueryString["qno"].ToString());
                    break;
                }

            case "quotSystemGlass":
                {
                    SalesQuotationReport("SimpleQuatation - SystemGlassPrice", Request.QueryString["qno"].ToString());
                    break;
                }



            case "RGP":
                {
                    RGP("RGP", Request.QueryString["qno"].ToString());
                    break;
                }

            case "NRGP":
                {
                    NRGP("NRGP", Request.QueryString["qno"].ToString());
                    break;
                }


            case "MRN":
                {
                    MRN("MRN", Request.QueryString["qno"].ToString());
                    break;
                }

            case "GlassRequest":
                {
                    GlassRequest("GlassRequest", Request.QueryString["qno"].ToString());
                    break;
                }


            case "IssueSlip":
                {
                    IssueSlip("IssueSlip", Request.QueryString["qno"].ToString());
                    break;
                }

            case "BlockRequest":
                {
                    BlockRequst("BlockRequest", Request.QueryString["qno"].ToString());
                    break;
                }


            case "BlockIssue":
                {
                    BlockIssue("BlockRequestRealase", Request.QueryString["qno"].ToString());
                    break;
                }

            case "Blukrequest":
                {
                    Blukrequest("BulkRequest", Request.QueryString["qno"].ToString());
                    break;
                }
            case "GlassIssue":
                {
                    GlassIssue("GlassTransfer", Request.QueryString["qno"].ToString());
                    break;
                }





            case "mATIssueSlip":
                {
                    mATIssueSlip("MattransferSlip", Request.QueryString["qno"].ToString());
                    break;
                }

            case "ToolsIssue":
                {
                    ToolsIssue("ToolsRequest", Request.QueryString["qno"].ToString());
                    break;
                }

            case "PurchaseOrder":
                {
                    PurchaseOrder("PurchaseOrder", Request.QueryString["qno"].ToString());


                    //returnFileName = mailAttachPath + "PurchaseOrder-" + Request.QueryString["qno"].ToString() + ".pdf";
                    //myRep.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, returnFileName);

                    //ClientScript.RegisterStartupScript(this.Page.GetType(), "popupOpener", "var popup=window.open('mailattach/'" + returnFileName + "'');popup.focus();", true);

                    //string FilePath = returnFileName;

                    //WebClient User = new WebClient();

                    //Byte[] FileBuffer = User.DownloadData(FilePath);

                    //if (FileBuffer != null)
                    //{

                    //    Response.ContentType = "application/pdf";

                    //    Response.AddHeader("content-length", FileBuffer.Length.ToString());

                    //    Response.BinaryWrite(FileBuffer);

                    //}



                    break;
                }



            case "FPurchaseOrder":
                {
                    PurchaseOrder("PurchaseOrder-G - Copy", Request.QueryString["qno"].ToString());

                    //PurchaseOrder("PurchaseOrder-G - Copy - Copy", Request.QueryString["qno"].ToString());

                    //returnFileName = mailAttachPath + "PurchaseOrder-" + Request.QueryString["qno"].ToString() + ".pdf";
                    //myRep.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, returnFileName);

                    //ClientScript.RegisterStartupScript(this.Page.GetType(), "popupOpener", "var popup=window.open('mailattach/'" + returnFileName + "'');popup.focus();", true);

                    //string FilePath = returnFileName;

                    //WebClient User = new WebClient();

                    //Byte[] FileBuffer = User.DownloadData(FilePath);

                    //if (FileBuffer != null)
                    //{

                    //    Response.ContentType = "application/pdf";

                    //    Response.AddHeader("content-length", FileBuffer.Length.ToString());

                    //    Response.BinaryWrite(FileBuffer);

                    //}



                    break;
                }



            case "GlassPurchaseOrder":
                {
                    PurchaseOrder("PurchaseOrder-Glass - Copy", Request.QueryString["qno"].ToString());


                    //returnFileName = mailAttachPath + "PurchaseOrder-" + Request.QueryString["qno"].ToString() + ".pdf";
                    //myRep.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, returnFileName);

                    //ClientScript.RegisterStartupScript(this.Page.GetType(), "popupOpener", "var popup=window.open('mailattach/'" + returnFileName + "'');popup.focus();", true);

                    //string FilePath = returnFileName;

                    //WebClient User = new WebClient();

                    //Byte[] FileBuffer = User.DownloadData(FilePath);

                    //if (FileBuffer != null)
                    //{

                    //    Response.ContentType = "application/pdf";

                    //    Response.AddHeader("content-length", FileBuffer.Length.ToString());

                    //    Response.BinaryWrite(FileBuffer);

                    //}



                    break;
                }



            case "Annexure":
                {
                    PurchaseOrder("Anexure1", Request.QueryString["qno"].ToString());
                    break;
                }

            case "PackingList":
                {
                    PackingList("PackingList", Request.QueryString["qno"].ToString());
                    break;
                }

            case "Indent":
                {
                    Indent("Indent", Request.QueryString["qno"].ToString());
                    break;
                }




            case "Stockview":
                {
                    Stockview("CrystalReport2");
                    break;
                }


            case "Payshet":
                {
                    Payshet("PayrollSheet", Request.QueryString["e"].ToString(), Request.QueryString["year"].ToString());
                    break;
                }
            case "Payslip":
                {

                    PaySlip("PaySlip_New", Request.QueryString["siid"].ToString(), Request.QueryString["e"].ToString(), Request.QueryString["year"].ToString());
                    break;
                }



            default:
                {
                    MessageBox.Show(this, "Under Construction");
                    break;
                }
        }
    }





    protected void Page_UnLoad(object sender, EventArgs e)
    {
        if (myRep != null)
        {
            myRep.Close();
            myRep.Dispose();
        }
    }



    #region PaySlip

    private void PaySlip(string ReportName, string siid, string e, string year)
    {
        try
        {
            myRep.Load(Server.MapPath("HR/" + ReportName + ".rpt"));



            SqlDataAdapter da1 = new SqlDataAdapter("Select * from V_ToGenerate_PaySlip", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Employee_Master ", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Employee_Details ", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Department_Master", DBConString.ConnectionString());
            SqlDataAdapter da5 = new SqlDataAdapter("Select * from Designation_Master", DBConString.ConnectionString());
            SqlDataAdapter da6 = new SqlDataAdapter("Select * from Company_Profile", DBConString.ConnectionString());
            SqlDataAdapter da7 = new SqlDataAdapter("Select * from V_getleavecount where Year (From_Date)=" + year + " and Month(from_date)=" + e + " ", DBConString.ConnectionString());


            AlumilDataSet rds = new AlumilDataSet();



            da1.Fill(rds, "V_ToGenerate_PaySlip");
            da2.Fill(rds, "Employee_Master");
            da3.Fill(rds, "Employee_Details");
            da4.Fill(rds, "Department_Master");
            da5.Fill(rds, "Designation_Master");
            da6.Fill(rds, "Company_Profile");
            da7.Fill(rds, "V_getleavecount");

            if (rds != null)
            {
                myRep.SetDataSource(rds);
                myRep.RecordSelectionFormula = "{V_ToGenerate_PaySlip.EMP_ID}=" + siid + "  and {V_ToGenerate_PaySlip.Month} = " + e + " and {V_ToGenerate_PaySlip.Year} = " + year + " ";

                CrystalReportViewer1.ReportSource = myRep;
                CrystalReportViewer1.RefreshReport();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }

    #endregion


    #region PaySheet

    private void Payshet(string ReportName, string e, string year)
    {
        try
        {
            myRep.Load(Server.MapPath("HR/" + ReportName + ".rpt"));
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from V_ToGenerate_PaySlip", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Employee_MAster where Status != 'Inactive' and EMP_CPID = 1  order by EMP_NO asc", DBConString.ConnectionString());
            SqlDataAdapter da5 = new SqlDataAdapter("Select * from Employee_Details", DBConString.ConnectionString());

            AlumilDataSet rds = new AlumilDataSet();

            da1.Fill(rds, "V_ToGenerate_PaySlip");
            da2.Fill(rds, "Employee_MAster");

            da5.Fill(rds, "Employee_Details");
            if (rds != null)
            {
                myRep.SetDataSource(rds);
                myRep.RecordSelectionFormula = " {V_ToGenerate_PaySlip.Month} = " + e + " and {V_ToGenerate_PaySlip.Year} = " + year + " ";

                CrystalReportViewer1.ReportSource = myRep;
                CrystalReportViewer1.RefreshReport();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }

    #endregion

    private void Stockview(string ReportName)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from Stockview2", DBConString.ConnectionString());
          


            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "Stockview2");
          


            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }

    private void Indent(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from IndentApproval", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from IndentApproval_Details ORDER BY InApproval_Det_Id ASC ", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Material_Master", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Color_Master", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Employee_Master", DBConString.ConnectionString());
            SqlDataAdapter da5 = new SqlDataAdapter("Select * from Uom_Master", DBConString.ConnectionString());
            SqlDataAdapter da6 = new SqlDataAdapter("Select * from Department_Master", DBConString.ConnectionString());
            SqlDataAdapter da7 = new SqlDataAdapter("Select * from Designation_Master", DBConString.ConnectionString());
            SqlDataAdapter da8 = new SqlDataAdapter("Select * from Employee_Details", DBConString.ConnectionString());


            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "IndentApproval");
            da1.Fill(rds, "IndentApproval_Details");
            da2.Fill(rds, "Material_Master");
            da3.Fill(rds, "Color_Master");
            da4.Fill(rds, "Employee_Master");
            da5.Fill(rds, "Uom_Master");
            da6.Fill(rds, "Department_Master");
            da7.Fill(rds, "Designation_Master");
            da8.Fill(rds, "Employee_Details");


            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{IndentApproval.IndentApproval_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }

    private void NRGP(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from NRGP", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from NRGP_Details  ORDER BY NRgp_Details_Id ASC", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Material_Master", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Color_Master", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Employee_Master", DBConString.ConnectionString());

            SqlDataAdapter da5 = new SqlDataAdapter("Select * from Sales_Order", DBConString.ConnectionString());
            SqlDataAdapter da6 = new SqlDataAdapter("Select * from Customer_Units", DBConString.ConnectionString());


            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "NRGP");
            da1.Fill(rds, "NRGP_Details");
            da2.Fill(rds, "Material_Master");
            da3.Fill(rds, "Color_Master");
            da4.Fill(rds, "Employee_Master");

            da5.Fill(rds, "Sales_Order");
            da6.Fill(rds, "Customer_Units");


            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{NRGP.NRGP_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }


    #region PackingList Report
    private void PackingList(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from Packing_List", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from PackingList_Details order by PL_Details_Id asc", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Material_Master", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Color_Master", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Customer_Units", DBConString.ConnectionString());




            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "Packing_List");
            da1.Fill(rds, "PackingList_Details");
            da2.Fill(rds, "Material_Master");
            da3.Fill(rds, "Color_Master");
            da4.Fill(rds, "Customer_Units");

            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{Packing_List.PackingList_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion

    #region PurchaseOrder Report
    private void PurchaseOrder(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from Supplier_Po_Master", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Supplier_Po_Details order by Sup_PO_Det_id asc", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Supplier_Master", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Material_Master", DBConString.ConnectionString());
         



            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "Supplier_Po_Master");
            da1.Fill(rds, "Supplier_Po_Details");
            da2.Fill(rds, "Supplier_Master");
            da3.Fill(rds, "Material_Master");


            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{Supplier_Po_Master.Sup_PO_Id}=" + QuotId + "  ";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion


    #region ToolsIssue Report
    private void ToolsIssue(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from Request_Tools", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Request_Tools_Details", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Material_Master", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Color_Master", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Table_Master", DBConString.ConnectionString());
            SqlDataAdapter da5 = new SqlDataAdapter("Select * from Employee_Master", DBConString.ConnectionString());
         


            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "Request_Tools");
            da1.Fill(rds, "Request_Tools_Details");
            da2.Fill(rds, "Material_Master");
            da3.Fill(rds, "Color_Master");
            da4.Fill(rds, "Table_Master");
            da5.Fill(rds, "Employee_Master");
           


            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{Request_Tools.Req_Tool_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion

    #region mATIssueSlip Report
    private void mATIssueSlip(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from Material_Issue", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Material_Issue_Details", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Material_Master", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Color_Master", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Uom_Master", DBConString.ConnectionString());
            SqlDataAdapter da5 = new SqlDataAdapter("Select * from Employee_Master", DBConString.ConnectionString());
            SqlDataAdapter da6 = new SqlDataAdapter("Select * from Customer_Units", DBConString.ConnectionString());



            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "Material_Issue");
            da1.Fill(rds, "Material_Issue_Details");
            da2.Fill(rds, "Material_Master");
            da3.Fill(rds, "Color_Master");
            da4.Fill(rds, "Uom_Master");
            da5.Fill(rds, "Employee_Master");
            da6.Fill(rds, "Customer_Units");


            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{Material_Issue.Issue_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion





    #region GlassRequest Report
    private void GlassRequest(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from Glass_Request", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from GlassRequest_Details", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Sales_Order", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Employee_Master", DBConString.ConnectionString());
          


            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "Glass_Request");
            da1.Fill(rds, "GlassRequest_Details");
            da2.Fill(rds, "Sales_Order");
            da3.Fill(rds, "Employee_Master");
          


            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{Glass_Request.GlasslRequest_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion



    #region GlassIssue Report
    private void GlassIssue(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from Glass_Issue", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from GlassIssue_Details", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Sales_Order", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Employee_Master", DBConString.ConnectionString());



            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "Glass_Issue");
            da1.Fill(rds, "GlassIssue_Details");
            da2.Fill(rds, "Sales_Order");
            da3.Fill(rds, "Employee_Master");



            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{Glass_Issue.Issue_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion





    #region IssueSlip Report
    private void IssueSlip(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from Request_Material_Issue", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Request_Material_Issue_Details", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Material_Master", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Color_Master", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Uom_Master", DBConString.ConnectionString());
            SqlDataAdapter da5 = new SqlDataAdapter("Select * from Employee_Master", DBConString.ConnectionString());
            SqlDataAdapter da6 = new SqlDataAdapter("Select * from Customer_Units", DBConString.ConnectionString());



            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "Request_Material_Issue");
            da1.Fill(rds, "Request_Material_Issue_Details");
            da2.Fill(rds, "Material_Master");
            da3.Fill(rds, "Color_Master");
            da4.Fill(rds, "Uom_Master");
            da5.Fill(rds, "Employee_Master");
            da6.Fill(rds, "Customer_Units");


            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{Request_Material_Issue.Req_Issue_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion



   

    #region BlockRequst Slip Report
    private void BlockRequst(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from RequestBlockStock_Release", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from RequestBlockStock_Release_Details", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Material_Master", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Color_Master", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Uom_Master", DBConString.ConnectionString());
            SqlDataAdapter da5 = new SqlDataAdapter("Select * from Employee_Master", DBConString.ConnectionString());
            SqlDataAdapter da6 = new SqlDataAdapter("Select * from Sales_Order", DBConString.ConnectionString());



            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "RequestBlockStock_Release");
            da1.Fill(rds, "RequestBlockStock_Release_Details");
            da2.Fill(rds, "Material_Master");
            da3.Fill(rds, "Color_Master");
            da4.Fill(rds, "Uom_Master");
            da5.Fill(rds, "Employee_Master");
            da6.Fill(rds, "Sales_Order");


            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{RequestBlockStock_Release.RequestBlockRelase_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion





    #region BlockIssue Slip Report
    private void BlockIssue(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from IssuedBlockStock", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from IssuedBlocked_Stock_Details", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Material_Master", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Color_Master", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Uom_Master", DBConString.ConnectionString());
            SqlDataAdapter da5 = new SqlDataAdapter("Select * from Employee_Master", DBConString.ConnectionString());
            SqlDataAdapter da6 = new SqlDataAdapter("Select * from Sales_Order", DBConString.ConnectionString());



            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "IssuedBlockStock");
            da1.Fill(rds, "IssuedBlocked_Stock_Details");
            da2.Fill(rds, "Material_Master");
            da3.Fill(rds, "Color_Master");
            da4.Fill(rds, "Uom_Master");
            da5.Fill(rds, "Employee_Master");
            da6.Fill(rds, "Sales_Order");


            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{IssuedBlockStock.IssueBlock_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion













    #region Bluckrequest Report
    private void Blukrequest(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from Request_Bulk_Production_Return", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Request_Bulk_Production_Return_Details", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Material_Master", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Color_Master", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Uom_Master", DBConString.ConnectionString());
            SqlDataAdapter da5 = new SqlDataAdapter("Select * from Employee_Master", DBConString.ConnectionString());
            SqlDataAdapter da6 = new SqlDataAdapter("Select * from Customer_Units", DBConString.ConnectionString());



            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "Request_Bulk_Production_Return");
            da1.Fill(rds, "Request_Bulk_Production_Return_Details");
            da2.Fill(rds, "Material_Master");
            da3.Fill(rds, "Color_Master");
            da4.Fill(rds, "Uom_Master");
            da5.Fill(rds, "Employee_Master");
            da6.Fill(rds, "Customer_Units");


            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{Request_Bulk_Production_Return.Request_ReturnIssue_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion


    #region MRN Report
    private void MRN(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from Supplier_PurchaseReceipt", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Supplier_PurchaseReceipt_Details", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Material_Master", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Color_Master", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Uom_Master", DBConString.ConnectionString());
            SqlDataAdapter da5 = new SqlDataAdapter("Select * from Employee_Master", DBConString.ConnectionString());
            SqlDataAdapter da6 = new SqlDataAdapter("Select * from Supplier_Po_Master", DBConString.ConnectionString());
            SqlDataAdapter da7 = new SqlDataAdapter("Select * from Supplier_Master", DBConString.ConnectionString());



            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "Supplier_PurchaseReceipt");
            da1.Fill(rds, "Supplier_PurchaseReceipt_Details");
            da2.Fill(rds, "Material_Master");
            da3.Fill(rds, "Color_Master");
            da4.Fill(rds, "Uom_Master");
            da5.Fill(rds, "Employee_Master");
            da6.Fill(rds, "Supplier_Po_Master");
            da7.Fill(rds, "Supplier_Master");


            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{Supplier_PurchaseReceipt.SPR_ID}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion

    #region RGP Report
    private void RGP(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));


            SqlDataAdapter da = new SqlDataAdapter("Select * from RGP", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from RGP_Details", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Material_Master", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Color_Master", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Employee_Master", DBConString.ConnectionString());
            SqlDataAdapter da5 = new SqlDataAdapter("Select * from Sales_Order", DBConString.ConnectionString());
            SqlDataAdapter da6 = new SqlDataAdapter("Select * from Customer_Units", DBConString.ConnectionString());



            AlumilDataSet rds = new AlumilDataSet();


            da.Fill(rds, "RGP");
            da1.Fill(rds, "RGP_Details");
            da2.Fill(rds, "Material_Master");
            da3.Fill(rds, "Color_Master");
            da4.Fill(rds, "Employee_Master");
            da5.Fill(rds, "Sales_Order");
            da6.Fill(rds, "Customer_Units");
         

            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{RGP.RGP_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion



    #region Sales Quotation Report
    private void SalesQuotationReport(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));

            SqlDataAdapter da = new SqlDataAdapter("Select * from Customer_Master", DBConString.ConnectionString());
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Customer_Units", DBConString.ConnectionString());
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Employee_Master", DBConString.ConnectionString());
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Quotation_Master", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Sales_QuotationDetails", DBConString.ConnectionString());

            SqlDataAdapter da5 = new SqlDataAdapter("Select * from Installation_Assistance_Template", DBConString.ConnectionString());
            SqlDataAdapter da6 = new SqlDataAdapter("Select * from PaymentTerms_Master", DBConString.ConnectionString());
            SqlDataAdapter da7 = new SqlDataAdapter("Select * from Sales_Damage_Template", DBConString.ConnectionString());

            SqlDataAdapter da8 = new SqlDataAdapter("Select * from Sales_Storage_Template", DBConString.ConnectionString());
            SqlDataAdapter da9 = new SqlDataAdapter("Select * from Sales_TermsConditions", DBConString.ConnectionString());
            SqlDataAdapter da10 = new SqlDataAdapter("Select * from Sales_Quatation_CalcChange", DBConString.ConnectionString());



            AlumilDataSet rds = new AlumilDataSet();

            da.Fill(rds, "Customer_Master");
            da1.Fill(rds, "Customer_Units");
            da2.Fill(rds, "Employee_Master");
            da3.Fill(rds, "Quotation_Master");
            da4.Fill(rds, "Sales_QuotationDetails");


            da5.Fill(rds, "Installation_Assistance_Template");
            da6.Fill(rds, "PaymentTerms_Master");
            da7.Fill(rds, "Sales_Damage_Template");
            da8.Fill(rds, "Sales_Storage_Template");
            da9.Fill(rds, "Sales_TermsConditions");
            da10.Fill(rds, "Sales_Quatation_CalcChange");

            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{Quotation_Master.Quotation_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;






            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion




    #region Sales Quotation Compare Report
    private void CompareSalesQuotationReport(string ReportName, string QuotId)
    {
        try
        {
            myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));

           
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Customer_Units", DBConString.ConnectionString());
         
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from Quotation_Master", DBConString.ConnectionString());
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from Sales_QuotationDetails", DBConString.ConnectionString());

           
            SqlDataAdapter da10 = new SqlDataAdapter("Select * from Sales_Quatation_CalcChange", DBConString.ConnectionString());



            AlumilDataSet rds = new AlumilDataSet();

          
            da1.Fill(rds, "Customer_Units");
         
            da3.Fill(rds, "Quotation_Master");
            da4.Fill(rds, "Sales_QuotationDetails");


         
            da10.Fill(rds, "Sales_Quatation_CalcChange");

            myRep.SetDataSource(rds);
            myRep.RecordSelectionFormula = "{Quotation_Master.Unit_Id}=" + QuotId + "";

            CrystalReportViewer1.ReportSource = myRep;

            //myRep.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Sales Quotation");
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
    }
    #endregion
    
    
    
    
    
    
    
    
    //#region StockProductCSK Report
    //private void StockProductCSK(string ReportName, string Customer, string from, string to)
    //{
    //    try
    //    {
    //        myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));

    //        SqlDataAdapter da = new SqlDataAdapter("Select * from SAPUCSK_StockCopy order by ProductId asc", DBConString.ConnectionString());
    //        SqlDataAdapter da1 = new SqlDataAdapter("Select * from Commodity_Master", DBConString.ConnectionString());
    //        Siddartha rds = new Siddartha();
    //        da.Fill(rds, "SAPUCSK_StockCopy");
    //        da1.Fill(rds, "Commodity_Master");
    //        myRep.SetDataSource(rds);
    //        myRep.RecordSelectionFormula = "{SAPUCSK_StockCopy.ProductId}=" + Customer + " and Date({SAPUCSK_StockCopy.StockCopy_date})>=#" + from + "# AND Date({SAPUCSK_StockCopy.StockCopy_date})<=#" + to + "# ";

    //        CrystalReportViewer1.ReportSource = myRep;
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(this, ex.Message.ToString());
    //    }
    //}
    //#endregion



    //#region DatecustomerPartyColdKolikuntla Report
    //private void DatecustomerPartyColdKolikuntla(string ReportName, string Customer, string from, string to)
    //{
    //    try
    //    {
    //        myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));

    //        SqlDataAdapter da = new SqlDataAdapter("Select * from SAPUCSK_Temporary_Receipt order by Tr_Id asc", DBConString.ConnectionString());
    //        SqlDataAdapter da1 = new SqlDataAdapter("Select * from SAPUCSK_Customer_Master", DBConString.ConnectionString());
    //        SqlDataAdapter da2 = new SqlDataAdapter("Select * from Commodity_Master", DBConString.ConnectionString());
    //        Siddartha rds = new Siddartha();
    //        da.Fill(rds, "SAPUCSK_Temporary_Receipt");
    //        da1.Fill(rds, "SAPUCSK_Customer_Master");
    //        da2.Fill(rds, "Commodity_Master");
    //        myRep.SetDataSource(rds);
    //        myRep.RecordSelectionFormula = "{SAPUCSK_Temporary_Receipt.Cust_Id}=" + Customer + " and Date({SAPUCSK_Temporary_Receipt.Rst_Date})>=#" + from + "# AND Date({SAPUCSK_Temporary_Receipt.Rst_Date})<=#" + to + "# ";

    //        CrystalReportViewer1.ReportSource = myRep;
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(this, ex.Message.ToString());
    //    }
    //}
    //#endregion


    //#region InwardDatecustomerPartyColdKolikuntla Report
    //private void InwardDatecustomerPartyColdKolikuntla(string ReportName, string Customer, string from, string to)
    //{
    //    try
    //    {
    //        myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));

    //        SqlDataAdapter da = new SqlDataAdapter("Select * from SAPUCSK_WarehouseReceipt order by Bond_Id asc", DBConString.ConnectionString());
    //        SqlDataAdapter da1 = new SqlDataAdapter("Select * from SAPUCSK_Customer_Master", DBConString.ConnectionString());
    //        SqlDataAdapter da2 = new SqlDataAdapter("Select * from Commodity_Master", DBConString.ConnectionString());
    //        Siddartha rds = new Siddartha();
    //        da.Fill(rds, "SAPUCSK_WarehouseReceipt");
    //        da1.Fill(rds, "SAPUCSK_Customer_Master");
    //        da2.Fill(rds, "Commodity_Master");
    //        myRep.SetDataSource(rds);
    //        myRep.RecordSelectionFormula = "{SAPUCSK_WarehouseReceipt.Cust_Id}=" + Customer + " and Date({SAPUCSK_WarehouseReceipt.Bond_Date})>=#" + from + "# AND Date({SAPUCSK_WarehouseReceipt.Bond_Date})<=#" + to + "# ";

    //        CrystalReportViewer1.ReportSource = myRep;
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(this, ex.Message.ToString());
    //    }
    //}
    //#endregion


    //#region CustomerOpen/Close
    //private void CustomerOpenClose(string ReportName, string Customer, string from, string to)
    //{
    //    try
    //    {
    //        myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));

    //        SqlDataAdapter da = new SqlDataAdapter("Select * from SAPUCSK_Temporary_Receipt order by Tr_Id asc", DBConString.ConnectionString());
    //        SqlDataAdapter da1 = new SqlDataAdapter("Select * from SAPUCSK_Customer_Master", DBConString.ConnectionString());
    //        SqlDataAdapter da2 = new SqlDataAdapter("Select * from Commodity_Master", DBConString.ConnectionString());
    //        Siddartha rds = new Siddartha();
    //        da.Fill(rds, "SAPUCSK_Temporary_Receipt");
    //        da1.Fill(rds, "SAPUCSK_Customer_Master");
    //        da2.Fill(rds, "Commodity_Master");
    //        myRep.SetDataSource(rds);
    //        myRep.RecordSelectionFormula = "{SAPUCSK_Temporary_Receipt.Account_Status}='" + Customer + "' and Date({SAPUCSK_Temporary_Receipt.Rst_Date})>=#" + from + "# AND Date({SAPUCSK_Temporary_Receipt.Rst_Date})<=#" + to + "# ";

    //        CrystalReportViewer1.ReportSource = myRep;
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(this, ex.Message.ToString());
    //    }
    //}
    //#endregion


    //#region CustomerWarehousereceipt Openclose Report
    //private void CustomerWarehousereceiptOpenClose(string ReportName, string Customer, string from, string to)
    //{
    //    try
    //    {
    //        myRep.Load(Server.MapPath("SM/" + ReportName + ".rpt"));

    //        SqlDataAdapter da = new SqlDataAdapter("Select * from SAPUCSK_WarehouseReceipt order by Bond_Id asc", DBConString.ConnectionString());
    //        SqlDataAdapter da1 = new SqlDataAdapter("Select * from SAPUCSK_Customer_Master", DBConString.ConnectionString());
    //        SqlDataAdapter da2 = new SqlDataAdapter("Select * from Commodity_Master", DBConString.ConnectionString());
    //        Siddartha rds = new Siddartha();
    //        da.Fill(rds, "SAPUCSK_WarehouseReceipt");
    //        da1.Fill(rds, "SAPUCSK_Customer_Master");
    //        da2.Fill(rds, "Commodity_Master");
    //        myRep.SetDataSource(rds);
    //        myRep.RecordSelectionFormula = "{SAPUCSK_WarehouseReceipt.Account_Status}='" + Customer + "' and Date({SAPUCSK_WarehouseReceipt.Bond_Date})>=#" + from + "# AND Date({SAPUCSK_WarehouseReceipt.Bond_Date})<=#" + to + "# ";

    //        CrystalReportViewer1.ReportSource = myRep;
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(this, ex.Message.ToString());
    //    }
    //}
    //#endregion


}