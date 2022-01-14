using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;
using phani;
using phaniDAL;

#region Message Box
namespace phani.MessageBox
{
    public class MessageBox
    {
        public static void Show(Page page, string message)
        
        {
            string msg = "alert('" + message + "');";
            System.Web.UI.ScriptManager.RegisterStartupScript(page, page.GetType(), "MsgBox", msg, true);
        }
        public static void Show(UserControl page, string message)
        {
            string msg = "alert('" + message + "');";
            System.Web.UI.ScriptManager.RegisterStartupScript(page, page.GetType(), "MsgBox", msg, true);
        }


        public static void Notify(Page page,string message)
        {
            string msg = "$.jGrowl('" + message + "');";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(page, page.GetType(),  "jgrowlwarn",msg, true);

        }

        public static void hi(Page page,string message)
        {
            string js = "$.jGrowl('" + message + "', { sticky: true, theme: 'growl-success', header: 'Success!' });";
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "jgrowlwarn", js, true);
            //string js = "$.jGrowl('Hello world!');";
            //Page.ClientScript.RegisterStartupScript(typeof(string), "jgrowlwarn", js, true);
        }

    }
}
#endregion

namespace phani.Classes
{
    public class General
    {
        static DBManager dbManager = new DBManager(DataProvider.SqlServer, DBConString.ConnectionString());
        SqlConnection SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
        SqlCommand SqlCmd;
        DataSet ds;
        SqlDataAdapter SqlDap;
        SqlDataReader sdr;
        DataTable dt;
        int status;
        string strStatus;
        SqlTransaction trns;

        public General()
        { }
        private static int _returnIntValue;
        #region Auto Random Number Generator
        public string generatePass()
        {
            Random rdm1 = new Random(unchecked((int)DateTime.Now.Ticks));
            return (rdm1.Next()).ToString();
        }
        #endregion

        #region ClearALL
        public static void ClearControls(Control Parent)
        {
            if (Parent is TextBox)
                (Parent as TextBox).Text = "";
            else if (Parent is DropDownList)
                (Parent as DropDownList).ClearSelection();
            else if (Parent is ListBox)
                (Parent as ListBox).ClearSelection();
            else
                foreach (Control c in Parent.Controls)
                    ClearControls(c);
        }
        #endregion

        #region Number To Words Converter Class
        public class NumberToEnglish
        {

            public String changeNumericToWords(String numb)
            {
                return changeToWords(numb, false);
            }

            public String changeNumericToWords(double numb)
            {
                String num = numb.ToString();
                return changeToWords(num, false);
            }

            public String changeCurrencyToWords(String numb)
            {
                return changeToWords(numb, true);
            }

            public String changeCurrencyToWords(double numb)
            {
                return changeToWords(numb.ToString(), true);
            }

            private String changeToWords(String numb, bool isCurrency)
            {
                String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
                String endStr = (isCurrency) ? ("Only") : ("");
                try
                {
                    int decimalPlace = numb.IndexOf(".");
                    if (decimalPlace > 0)
                    {
                        wholeNo = numb.Substring(0, decimalPlace);
                        points = numb.Substring(decimalPlace + 1);
                        if (Convert.ToInt32(points) > 0)
                        {
                            andStr = (isCurrency) ? ("and") : ("point");// just to separate whole numbers from points/cents
                            endStr = (isCurrency) ? ("Cents " + endStr) : ("");
                            pointStr = translateCents(points);
                        }
                    }
                    val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
                }
                catch { ;}
                return val;
            }

            private String translateWholeNumber(String number)
            {
                string word = "";
                try
                {
                    bool beginsZero = false;//tests for 0XX
                    bool isDone = false;//test if already translated
                    double dblAmt = (Convert.ToDouble(number));
                    //if ((dblAmt > 0) && number.StartsWith("0"))
                    if (dblAmt > 0)
                    {//test for zero or digit zero in a nuemric
                        beginsZero = number.StartsWith("0");
                        int numDigits = number.Length;
                        int pos = 0;//store digit grouping
                        String place = "";//digit grouping name:hundres,thousand,etc...
                        switch (numDigits)
                        {
                            case 1://ones' range
                                word = ones(number);
                                isDone = true;
                                break;
                            case 2://tens' range
                                word = tens(number);
                                isDone = true;
                                break;
                            case 3://hundreds' range
                                pos = (numDigits % 3) + 1;
                                place = " Hundred ";
                                break;
                            case 4://thousands' range
                            case 5:
                            case 6:
                                pos = (numDigits % 4) + 1;
                                place = " Thousand ";
                                break;
                            case 7://millions' range
                            case 8:
                            case 9:
                                pos = (numDigits % 7) + 1;
                                place = " Million ";
                                break;
                            case 10://Billions's range
                                pos = (numDigits % 10) + 1;
                                place = " Billion ";
                                break;
                            //add extra case options for anything above Billion...
                            default:
                                isDone = true;
                                break;
                        }
                        if (!isDone)
                        {//if transalation is not done, continue...(Recursion comes in now!!)
                            word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));
                            //check for trailing zeros
                            if (beginsZero) word = " and " + word.Trim();
                        }
                        //ignore digit grouping names
                        if (word.Trim().Equals(place.Trim())) word = "";
                    }
                }
                catch { ;}
                return word.Trim();
            }

            private String tens(String digit)
            {
                int digt = Convert.ToInt32(digit);
                String name = null;
                switch (digt)
                {
                    case 10:
                        name = "Ten";
                        break;
                    case 11:
                        name = "Eleven";
                        break;
                    case 12:
                        name = "Twelve";
                        break;
                    case 13:
                        name = "Thirteen";
                        break;
                    case 14:
                        name = "Fourteen";
                        break;
                    case 15:
                        name = "Fifteen";
                        break;
                    case 16:
                        name = "Sixteen";
                        break;
                    case 17:
                        name = "Seventeen";
                        break;
                    case 18:
                        name = "Eighteen";
                        break;
                    case 19:
                        name = "Nineteen";
                        break;
                    case 20:
                        name = "Twenty";
                        break;
                    case 30:
                        name = "Thirty";
                        break;
                    case 40:
                        name = "Fourty";
                        break;
                    case 50:
                        name = "Fifty";
                        break;
                    case 60:
                        name = "Sixty";
                        break;
                    case 70:
                        name = "Seventy";
                        break;
                    case 80:
                        name = "Eighty";
                        break;
                    case 90:
                        name = "Ninety";
                        break;
                    default:
                        if (digt > 0)
                        {
                            name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                        }
                        break;
                }
                return name;
            }

            private String ones(String digit)
            {
                int digt = Convert.ToInt32(digit);
                String name = "";
                switch (digt)
                {
                    case 1:
                        name = "One";
                        break;
                    case 2:
                        name = "Two";
                        break;
                    case 3:
                        name = "Three";
                        break;
                    case 4:
                        name = "Four";
                        break;
                    case 5:
                        name = "Five";
                        break;
                    case 6:
                        name = "Six";
                        break;
                    case 7:
                        name = "Seven";
                        break;
                    case 8:
                        name = "Eight";
                        break;
                    case 9:
                        name = "Nine";
                        break;
                }
                return name;
            }

            private String translateCents(String cents)
            {
                String cts = "", digit = "", engOne = "";
                for (int i = 0; i < cents.Length; i++)
                {
                    digit = cents[i].ToString();
                    if (digit.Equals("0"))
                    {
                        engOne = "Zero";
                    }
                    else
                    {
                        engOne = ones(digit);
                    }
                    cts += " " + engOne;
                }
                return cts;
            }

        }
        #endregion





        public string GetColumnVal(string Query, string ColumnName)
        {
            string RetVal = "";
            using (SqlCmd = new SqlCommand(Query, SqlCon))
            {
                SqlCon.Open();
                sdr = SqlCmd.ExecuteReader();
                while (sdr.Read())
                {
                    RetVal = sdr[ColumnName].ToString();
                    break;
                }
                sdr.Close();
                SqlCon.Close();
            }

            return RetVal;
        }









        public static string IsDelete(string command)
        {
            string isdelete = string.Empty;
            
            try
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                dbManager.ExecuteReader(CommandType.Text, command);
                if (dbManager.DataReader.Read())
                {
                    isdelete = dbManager.DataReader[0].ToString();
                }
                dbManager.DataReader.Dispose();


            }
            catch (Exception ex)
            {

            }
            return isdelete;

        }
        public static string IsEdit(string command)
        {
           
            string isedit = string.Empty;

            try
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                dbManager.ExecuteReader(CommandType.Text, command);
                if (dbManager.DataReader.Read())
                {
                    isedit = dbManager.DataReader[0].ToString();
                }
                dbManager.DataReader.Dispose();


            }
            catch (Exception ex)
            {

            }
            return isedit;

        }

        #region GridBind with Statement
        public static void GridBindwithCommand(GridView gridview, string command)
        {
            dbManager.Open();
            dbManager.ExecuteReader(CommandType.Text, command);
            gridview.DataSource = dbManager.DataReader;
            gridview.DataBind();
           // gridview.HeaderRow.TableSection = TableRowSection.TableHeader;  

        }
        #endregion


        public static string toDDMMYYYY(string MMDDYYYY)
        {
            string[] date = MMDDYYYY.Split('/');
            return date[1] + "/" + date[0] + "/" + date[2];
        }
        public static string toMMDDYYYY(string DDMMYYYY)
        {
            if (!string.IsNullOrEmpty(DDMMYYYY))
            {
                string[] date = DDMMYYYY.Split('/');
                return date[1] + "/" + date[0] + "/" + date[2];
            }
            else
            {

            }
            {
                return "";
            }
        }
        static string contenttype,prefixfield;
        public static string GetRequiredPrefix(string TableName)
        {
            switch (TableName)
            {
                case "Customer_Master": prefixfield = "PF_CUSTOMERINFO"; break;
                case "Quotation_Master": prefixfield = "PF_SALESQUOTATION"; break;
                case "Sales_Order": prefixfield = "PF_SALESORDER"; break;
                case "SalesEnquiry_Master": prefixfield = "PF_SALESENQUIRY"; break;
                case "Delivery_Challan_Master": prefixfield = "PF_DELIVERYCHALLAN"; break;
                case "Sales_Invoice": prefixfield = "PF_SALESINVOICE"; break;
                case "Payments_Received": prefixfield = "PF_PAYMENTRECEIVED"; break;
                case "Indent_Master": prefixfield = "PF_INDENT"; break;
                case "Supplier_Po_Master": prefixfield = "PF_PURCHASEORDER"; break;
                case "OfferLetter": prefixfield = "PF_OFFERLETTER"; break;
                case "Supplier_PurchaseReceipt": prefixfield = "PF_PURCHASERECEIPT"; break;
                case "Bom": prefixfield = "PF_BOM"; break;
                case "ProductionOrder": prefixfield = "PF_PRODUCTIONORDER"; break;
                case "Material_Receipt": prefixfield = "PF_MATERIALRECEIPIT"; break;
                case "MaterialRequest": prefixfield = "PF_MATERIALREQUEST"; break;
                case "Lead": prefixfield = "PF_LEAD"; break;
                case "Supplier_Quotation_Master": prefixfield = "PF_SUPPLIERQUATATION"; break;
                case "Employee_Master": prefixfield = "PF_EMPMAS"; break;
                case "Leave_Application": prefixfield = "PF_LEAVEAPPLICATION"; break;
                case "SupplierRequest_Quotation_Master": prefixfield = "PF_REQQUOTATION"; break;
                case "GlassRequest_Quatation_Master": prefixfield = "PF_REQGLASSQUO"; break;
                case "Glass_Quatation_Master": prefixfield = "PF_GQUATATIONNO"; break;
                case "Glass_PO_Master": prefixfield = "PF_GPONO"; break;
                case "IndentApproval": prefixfield = "PF_INDENTAPPROVAL"; break;
                case "Request_Material_Issue": prefixfield = "PF_REQUESTMATERIAL"; break;
                case "Material_Issue": prefixfield = "PF_MATERIALISSUE"; break;
                case "RGP": prefixfield = "PF_RGP"; break;
                case "NRGP": prefixfield = "PF_NRGP"; break;
                case "RGP_Return": prefixfield = "PF_RETURNRGP"; break;
                case "NRGP_Return": prefixfield = "PF_RETURNNRGP"; break;
                case "Stock_Reserve": prefixfield = "PF_STOCKRESERVE"; break;



                case "RGP_Request": prefixfield = "PF_REQUESTRGP"; break;
                case "NRGP_Request": prefixfield = "PF_REQUESTNRGP"; break;

                case "Issue_Return": prefixfield = "PF_ISSUERETURN"; break;
                case "Packing_List": prefixfield = "PF_PACKINGLIST"; break;


                case "Request_Bulk_Production_Return": prefixfield = "PF_BLUKREQUEST"; break;

                case "BulkReturnMaterial": prefixfield = "PF_BULKREQUESTISSUE"; break;


                case "Request_PackingList": prefixfield = "PF_REQUESTPACKING"; break;

                case "Request_Tools": prefixfield = "PF_REQUESTTOOLS"; break;

                case "Glass_PurchaseReceipt": prefixfield = "PF_GLASSRECEIPT"; break;

                case "Glass_Request": prefixfield = "PF_GLASSREQUEST"; break;
                case "Glass_Issue": prefixfield = "PF_GLASSISSUE"; break;
                case "RequestBlockStock_Release": prefixfield = "PF_REQUESTBLOCKREALASE"; break;
                case "IssuedBlockStock": prefixfield = "PF_ISSUEDBLOCK"; break;

            }
            return prefixfield;
        }
        public static string GetContentType(string Extension)
        {

            switch (Extension)
            {

                case ".doc":

                    contenttype = "application/vnd.ms-word";

                    break;

                case ".docx":

                    contenttype = "application/vnd.ms-word";

                    break;

                case ".xls":

                    contenttype = "application/vnd.ms-excel";

                    break;

                case ".xlsx":

                    contenttype = "application/vnd.ms-excel";

                    break;

                case ".jpg":

                    contenttype = "image/jpg";

                    break;

                case ".png":

                    contenttype = "image/png";

                    break;

                case ".gif":

                    contenttype = "image/gif";

                    break;

                case ".pdf":

                    contenttype = "application/pdf";

                    break;

            }
            return contenttype;
        }

        #region Count of Records
        public static int CountofRecordsWithQuery(string command)
        {
            dbManager.Open();
            int _returnIntValue;
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, command).ToString());
            return _returnIntValue;
        }
        #endregion



        public static bool IsRecordExists1(string paraTableName, string paraFieldName, string paraFieldValue)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            bool check = false;
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT COUNT(*) FROM " + paraTableName + " WHERE " + paraFieldName + "='" + paraFieldValue + "'").ToString());
            if (_returnIntValue > 0)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }


        public void getCon()
        {
            if (SqlCon.State == ConnectionState.Closed)
            {
                SqlCon.Open();
            }
        }
        public DataSet ReturnDataSet(string Query)
        {
            try
            {
                //getCon();
                SqlDap = new SqlDataAdapter(Query, SqlCon);
                ds = new DataSet("DSResult");
                SqlDap.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return ErrorDataSet(ex.Message);
            }
            finally
            {
                SqlCon.Close();
                //  SqlCmd.Dispose();
                SqlDap.Dispose();
                ds.Dispose();
            }

        }
        public DataTable ReturnDataTable(string Query)
        {
            try
            {
                // getCon();

                SqlDap = new SqlDataAdapter(Query, SqlCon);
                ds = new DataSet("DSResult");
                SqlDap.Fill(ds);
                dt = new DataTable("DTResult");
                dt = ds.Tables[0];
                return dt;


            }
            catch (Exception ex)
            {
                return ErrorDataTable(ex.Message);
            }
            finally
            {
                SqlCon.Close();
                // SqlCmd.Dispose();
                SqlDap.Dispose();
                ds.Dispose();
            }
        }

        public string ReturnExecuteNoneQuery(string Query)
        {
            try
            {
                getCon();
                SqlCmd = new SqlCommand(Query, SqlCon);
                strStatus = SqlCmd.ExecuteNonQuery().ToString();
                return strStatus;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                SqlCon.Close();
                SqlCmd.Dispose();
            }
        }
        public string ReturnTransExecuteNoneQuery(string[] Query)
        {
            try
            {
                getCon();
                trns = SqlCon.BeginTransaction(IsolationLevel.ReadCommitted);


                // SqlCmd.Connection = SqlCon;
                for (int i = 0; i < Query.Length; i++)
                {
                    if (Query[i] != null)
                    {

                        SqlCmd = new SqlCommand(Query[i], SqlCon, trns);

                        //  SqlCmd.CommandText = Query[i];
                        strStatus = SqlCmd.ExecuteNonQuery().ToString();
                    }
                    else
                    {
                        break;
                    }
                }
                trns.Commit();
                return "1";
            }
            catch (Exception ex)
            {
                trns.Rollback();
                return ex.Message;
            }
            finally
            {
                if (SqlCon != null)
                    SqlCon.Close();
                if (SqlCmd != null)
                    SqlCmd.Dispose();
            }
        }

        public string ReturnExecuteScalar(string Query)
        {
            try
            {
                getCon();
                SqlCmd = new SqlCommand(Query, SqlCon);
                strStatus = SqlCmd.ExecuteScalar().ToString();
                return strStatus;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                SqlCon.Close();
                SqlCmd.Dispose();
            }
        }

        public DataSet ErrorDataSet(string ErrMsg)
        {
            try
            {
                DataTable dt = CreateDataTable();
                DataRow row = dt.NewRow();
                row["ErrMsg"] = ErrMsg;
                dt.Rows.Add(row);
                ds = new DataSet("ERRDS");
                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                ds.Dispose();
            }
        }
        public DataTable CreateDataTable()
        {
            try
            {
                dt = new DataTable("ERRDT");
                DataColumn myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = "ErrMsg";
                dt.Columns.Add(myDataColumn);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        public DataTable ErrorDataTable(string ErrMsg)
        {
            dt = CreateDataTable();
            DataRow row = dt.NewRow();
            row["ErrMsg"] = ErrMsg;
            dt.Rows.Add(row);
            return dt;

        }





    }
}





