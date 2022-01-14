using phaniDAL;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for SM
/// </summary>

namespace Phani.Modules
{
    public class SM
    {
        private static int _returnIntValue;
        private static string _returnStringMessage, _commandText;

        public enum SMStatus { New = 0, Open = 1, Closed = 2, Cancelled = 3, Regret = 4, Revised = 5, }

        //  IDBManager dbManager = new DBManager(DataProvider.SqlServer);

        private static DBManager dbManager = new DBManager(DataProvider.SqlServer, DBConString.ConnectionString());

        public SM()
        { }

        //Method For Dispose
        public static void Dispose()
        {
            if (dbManager.Connection != null)
                dbManager.Dispose();
        }

        //Method For BeginTransaction
        public static void BeginTransaction()
        {
            dbManager.Open();
            dbManager.BeginTransaction();
        }

        //Method For CommitTransaction
        public static void CommitTransaction()
        {
            dbManager.CommitTransaction();
        }

        //Method For RollBackTransaction
        public static void RollBackTransaction()
        {
            dbManager.RollBackTransaction();
        }

        //Method for GridBind Fill
        private static void GridViewBind(GridView gv)
        {
            gv.DataSource = dbManager.DataReader;
            gv.DataBind();
            dbManager.DataReader.Close();
        }

        //Method for Checking a record exists or not with reference id
        private static bool IsRecordExists(string paraTableName, string paraFieldName, string paraFieldValue)
        {
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


        private static void SODropDownListBind(DropDownList ddl, string DataTextField, string DataValueField)
        {
            dbManager.Open();
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("NA", "0"));
            while (dbManager.DataReader.Read())
            {
                ddl.Items.Add(new ListItem(dbManager.DataReader[DataTextField].ToString(), dbManager.DataReader[DataValueField].ToString()));
            }
            dbManager.DataReader.Close();
            dbManager.Close();
        }



        private static bool IsRecordExists(string paraTableName, string paraFirstFieldName, string paraFirstFieldValue, string paraSecondFieldName, string paraSecondFieldValue)
        {
            bool check = false;
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT COUNT(*) FROM " + paraTableName + " WHERE " + paraFirstFieldName + "='" + paraFirstFieldValue + "' and " + paraSecondFieldName + "='" + paraSecondFieldValue + "'").ToString());
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

        //Method for deleting a record with a reference table name and id
        private static bool DeleteRecord(string paraTableName, string paraFieldName, string paraFieldValue)
        {
            bool check = false;
            try
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _returnIntValue = int.Parse(dbManager.ExecuteNonQuery(CommandType.Text, "DELETE FROM " + paraTableName + " WHERE " + paraFieldName + "='" + paraFieldValue + "'").ToString());
                if (_returnIntValue > 0)
                {
                    check = true;
                }
                else
                {
                    check = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is System.Data.SqlClient.SqlException)
                {
                    if ((ex as System.Data.SqlClient.SqlException).Number == 547)
                    {
                        //MessageBox.Show(this, "This Record cannot be deleted. It has been used as reference in other forms.........");
                        check = false;
                    }
                }
            }
            return check;
        }

        ///Method For deleting a record with id and invocie no
        ///
        private static bool DeleteRecord(string paraTableName, string paraFieldName, string paraFieldValue, string para2FieldName, string para2FieldValue)
        {
            bool check = false;
            try
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _returnIntValue = int.Parse(dbManager.ExecuteNonQuery(CommandType.Text, "DELETE FROM " + paraTableName + " WHERE " + paraFieldName + "='" + paraFieldValue + "' and " + para2FieldName + "='" + para2FieldValue + "'    ").ToString());
                if (_returnIntValue > 0)
                {
                    check = true;
                }
                else
                {
                    check = true;
                }
            }
            catch (Exception ex)
            {
                if (ex is System.Data.SqlClient.SqlException)
                {
                    if ((ex as System.Data.SqlClient.SqlException).Number == 547)
                    {
                        //MessageBox.Show(this, "This Record cannot be deleted. It has been used as reference in other forms.........");
                        check = false;
                    }
                }
            }
            return check;
        }

        //Method for clearing Textbox and Dropdown list and Listbox
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

        //Method for DropDownList Fill
        private static void DropDownListBind(DropDownList ddl, string DataTextField, string DataValueField)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("Select a Option", "0"));
            while (dbManager.DataReader.Read())
            {
                ddl.Items.Add(new ListItem(dbManager.DataReader[DataTextField].ToString(), dbManager.DataReader[DataValueField].ToString()));
            }
            dbManager.DataReader.Close();
        }

        //Method for Auto Generate Max Serial ID
        public static string AutoGenMaxId(string TableName, string FieldName)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(" + FieldName + "),0)+1 FROM " + TableName + "").ToString());
            return _returnIntValue.ToString();
        }

        //Method for Auto Generate Max Serial NO
        public static string AutoGenMaxNo(string TableName, string FieldName)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = "SELECT ISNULL(MAX(CONVERT(BIGINT,SUBSTRING(SUBSTRING(" + FieldName + ",0,LEN(" + FieldName + ")-5),CHARINDEX('-'," + FieldName + ")+1,LEN(SUBSTRING(" + FieldName + ",0,LEN(" + FieldName + ")-5))))),0)+1 FROM " + TableName + " WHERE SUBSTRING(" + FieldName + ",LEN(" + FieldName + ")-4,5)='" + CurrentFinancialYear() + "'";
            string numb = dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString();
            //dbManager.Dispose();
            return Prefix(TableName) + "-" + numb + "/" + CurrentFinancialYear();



            // return Prefix(TableName) + "/" + CurrentFinancialYear() + "/" + numb;

        }

        public static string Prefix(string TableName)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _returnStringMessage = dbManager.ExecuteScalar(CommandType.Text, "SELECT " + phani.Classes.General.GetRequiredPrefix(TableName) + " FROM Code_Prefix").ToString();
            //dbManager.Dispose();
            return _returnStringMessage.ToString();
        }

        //Method for to Get Current Financial Year
        public static string CurrentFinancialYear()
        {
            string year;
            if (dbManager.Transaction == null)
                dbManager.Open();
            year = dbManager.ExecuteScalar(CommandType.Text, "SELECT CP_CF_YEAR FROM [Company_Profile]").ToString();
            if (string.IsNullOrEmpty(year))
            {
                year = "0000";
            }

            return year;
        }

        public class CustomerMaster
        {
            public string Custid, CustCode, CustName, CompanyName, CustContactPerson, custPhone, CustMobile, Custfax, CustEmail, CustPan, Custgst, regid, custaddress, corpcontactperson, corpphone, corpmobile, corpemail, corpaddress, corpdesgid, corpfax, custstatus, custdear, custdesgid;

            public string refbyname, refbycontact, refbyaddress, architectname, archicontact, archiaddress, siteinchargename, siteinchargecontact, siteinchargeaddress;

            public string UnitName, UnitAddress, Unitid, NoofFloors, Winload, UnitContactPerson, UnitMobileNo;
            public bool UserNameInUse { get; set; }
            public CustomerMaster()
            { }

            public static string CustomerMaster_AutoGenCode()
            {
                return AutoGenMaxNo("Customer_Master", "CUST_CODE");
            }

            public string CustomerMaster_Save()
            {

                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Customer_Master]", "CUST_NAME", this.CustName) == false)
                {


                    this.CustCode = CustomerMaster_AutoGenCode();
                    this.Custid = AutoGenMaxId("[Customer_Master]", "CUST_ID");

                    _commandText = string.Format("INSERT INTO [Customer_Master] VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},'{12}','{13}','{14}','{15}','{16}','{17}',{18},'{19}','{20}','{21}',{22},'{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}')",
                   this.Custid, this.CustCode, this.CustName, this.CompanyName, this.CustContactPerson, this.custPhone, this.CustMobile, this.Custfax, this.CustEmail, this.CustPan, this.Custgst, this.regid, this.custaddress, this.corpcontactperson, this.corpphone, this.corpmobile, this.corpemail, this.corpaddress, this.corpdesgid, this.corpfax, this.custstatus, this.custdear, this.custdesgid, this.refbyname, this.refbycontact, this.refbyaddress, this.architectname, this.archicontact, this.archiaddress, this.siteinchargename, this.siteinchargecontact, this.siteinchargeaddress);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Customer Name Already Exists.";
                }
                return _returnStringMessage;
            }





            public string EnqCustomerMaster_Save()
            {

                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Customer_Master]", "CUST_NAME", this.CustName) == false)
                {
                    this.CustCode = CustomerMaster_AutoGenCode();
                    this.Custid = AutoGenMaxId("[Customer_Master]", "CUST_ID");
                    this.Unitid = AutoGenMaxId("[Customer_Units]", "CUST_UNIT_ID");

                    _commandText = string.Format("INSERT INTO [Customer_Master] VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},'{12}','{13}','{14}','{15}','{16}','{17}',{18},'{19}','{20}','{21}',{22},'{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}')",
                     this.Custid, this.CustCode, this.CustName, this.CompanyName, this.CustContactPerson, this.custPhone, this.CustMobile, this.Custfax, this.CustEmail, this.CustPan, this.Custgst, this.regid, this.custaddress, this.corpcontactperson, this.corpphone, this.corpmobile, this.corpemail, this.corpaddress, this.corpdesgid, this.corpfax, this.custstatus, this.custdear, this.custdesgid, this.refbyname, this.refbycontact, this.refbyaddress, this.architectname, this.archicontact, this.archiaddress, this.siteinchargename, this.siteinchargecontact, this.siteinchargeaddress);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                    _commandText = string.Format("INSERT INTO [Customer_Units] VALUES({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')",
                         this.Unitid, this.Custid, this.CustName, this.custaddress, "0", "0", this.CustName, this.CustMobile, "0", "0", this.CustName, this.CustMobile, "0", "0", "0", "0", "0", "0", "0");
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);



                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Customer Name Already Exists.";
                }
                return _returnStringMessage;
            }

            public string CustomerMaster_Update()
            {
                try
                {
                    dbManager.Open();
                    _commandText = string.Format("UPDATE [Customer_Master] SET CUST_NAME='{0}',CUST_COMPANY_NAME='{1}',CUST_CONTACT_PERSON='{2}',CUST_PHONE='{3}',CUST_MOBILE='{4}',CUST_FAX='{5}',CUST_EMAIL='{6}',CUST_PAN='{7}',CUST_GST='{8}',REG_ID={9},CUST_ADDRESS='{10}',CUST_CORP_CONTACT_PERSON='{11}',CUST_CORP_PHONE='{12}',CUST_CORP_MOBILE='{13}',CUST_CORP_EMAIL='{14}',CUST_CORP_ADDRESS='{15}',CUST_CORP_DESG_ID='{16}',CUST_CORP_FAX='{17}',CUST_STATUS='{18}',CUST_DEAR='{19}',CUST_DESG_ID={20},CUST_REF_BY_NAME='{21}',CUST_REF_BY_CONTACT='{22}',CUST_REF_BY_ADDRESS='{23}',CUST_ARCHITECT_NAME='{24}',CUST_ARCHITECT_CONTACT='{25}',CUST_ARCHITECT_ADDRESS='{26}',CUST_SITEINCHARGE_NAME='{27}',CUST_SITEINCHARGE_CONTACT='{28}',CUST_SITEINCHARGE_ADDRESS='{29}' where CUST_ID={30}", this.CustName, this.CompanyName, this.CustContactPerson, this.custPhone, this.CustMobile, this.Custfax, this.CustEmail, this.CustPan, this.Custgst, this.regid, this.custaddress, this.corpcontactperson, this.corpphone, this.corpmobile, this.corpemail, this.corpaddress, this.corpdesgid, this.corpfax, this.custstatus, this.custdear, this.custdesgid, this.refbyname, this.refbycontact, this.refbyaddress, this.architectname, this.archicontact, this.archiaddress, this.siteinchargename, this.siteinchargecontact, this.siteinchargeaddress, this.Custid);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                    return _returnStringMessage;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    SM.Dispose();
                }
            }

            public string CustomerMaster_Delete()
            {
                // SM.BeginTransaction();
                //if (DeleteRecord("[YANTRA_CUSTOMER_DET]", "CUST_ID", this.Custid) == true)
                //{
                if (DeleteRecord("[Customer_Units]", "CUST_ID", this.Custid) == true)
                {
                    if (DeleteRecord("[Customer_Master]", "CUST_ID", this.Custid) == true)
                    {
                        // SM.CommitTransaction();
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        // SM.RollBackTransaction();
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                }
                else
                {
                    // SM.RollBackTransaction();
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                //}
                //else
                //{
                //    SM.RollBackTransaction();
                //    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                //}
                return _returnStringMessage;
            }

            public static void CustomerMaster_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT CUST_COMPANY_NAME,CUST_ID FROM [Customer_Master] ORDER BY CUST_NAME");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "CUST_COMPANY_NAME", "CUST_ID");
                }
                //dbManager.Dispose();
            }


            public static void CustomerMasterQuatation_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT CUST_COMPANY_NAME,CUST_ID FROM   [Customer_Master] WHERE  EXISTS (SELECT 1 FROM   Quotation_Master WHERE  Quotation_Master.Cust_ID = [Customer_Master].CUST_ID)");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "CUST_COMPANY_NAME", "CUST_ID");
                }
                //dbManager.Dispose();
            }





            public static void CustomerUnit_Select(Control ControlForBind, string custid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Customer_Units] where  CUST_ID = '" + custid + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "CUST_UNIT_NAME", "CUST_UNIT_ID");
                }
            }

            public static void CustomerUnit_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT CUST_UNIT_NAME,CUST_UNIT_ID FROM [Customer_Units]");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "CUST_UNIT_NAME", "CUST_UNIT_ID");
                }
                //dbManager.Dispose();
            }










            public static void CustomerProjectUnit_Select(Control ControlForBind)
            {
                dbManager.Open();
                //_commandText = string.Format("SELECT CUST_UNIT_NAME+'/'+CUST_NAME as CUST_UNIT_NAME,CUST_UNIT_ID FROM [Customer_Units],Customer_Master where [Customer_Units].CUST_ID = Customer_Master.CUST_ID order by CUST_NAME");


                _commandText = string.Format("SELECT ProjectCode+'/'+CUST_UNIT_NAME as CUST_UNIT_NAME,SalesOrder_Id FROM [Customer_Units],Sales_Order where [Customer_Units].CUST_UNIT_ID = Sales_Order.CustSiteId order by ProjectCode desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "CUST_UNIT_NAME", "SalesOrder_Id");
                }
                //dbManager.Dispose();
            }
            public int CustomerMaster_Select(string CustomerId)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Customer_Master] where [Customer_Master].CUST_ID= " + CustomerId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.custaddress = dbManager.DataReader["CUST_ADDRESS"].ToString();
                    this.CompanyName = dbManager.DataReader["CUST_COMPANY_NAME"].ToString();
                    this.CustContactPerson = dbManager.DataReader["CUST_CONTACT_PERSON"].ToString();

                    this.CustCode = dbManager.DataReader["CUST_CODE"].ToString();
                    this.CustName = dbManager.DataReader["CUST_NAME"].ToString();

                    this.CustEmail = dbManager.DataReader["CUST_EMAIL"].ToString();
                    this.Custfax = dbManager.DataReader["CUST_FAX"].ToString();
                    this.regid = dbManager.DataReader["REG_ID"].ToString();

                    this.CustMobile = dbManager.DataReader["CUST_MOBILE"].ToString();
                    this.CustPan = dbManager.DataReader["CUST_PAN"].ToString();
                    this.custPhone = dbManager.DataReader["CUST_PHONE"].ToString();

                    this.corpcontactperson = dbManager.DataReader["CUST_CORP_CONTACT_PERSON"].ToString();
                    this.corpphone = dbManager.DataReader["CUST_CORP_PHONE"].ToString();
                    this.corpmobile = dbManager.DataReader["CUST_CORP_MOBILE"].ToString();
                    this.corpemail = dbManager.DataReader["CUST_CORP_EMAIL"].ToString();
                    this.corpaddress = dbManager.DataReader["CUST_CORP_ADDRESS"].ToString();

                    this.corpdesgid = dbManager.DataReader["CUST_CORP_DESG_ID"].ToString();
                    this.corpfax = dbManager.DataReader["CUST_CORP_FAX"].ToString();

                    this.custdear = dbManager.DataReader["CUST_DEAR"].ToString();
                    this.custdesgid = dbManager.DataReader["CUST_DESG_ID"].ToString();

                    this.refbyname = dbManager.DataReader["CUST_REF_BY_NAME"].ToString();
                    this.refbycontact = dbManager.DataReader["CUST_REF_BY_CONTACT"].ToString();
                    this.refbyaddress = dbManager.DataReader["CUST_REF_BY_ADDRESS"].ToString();

                    this.architectname = dbManager.DataReader["CUST_ARCHITECT_NAME"].ToString();
                    this.archicontact = dbManager.DataReader["CUST_ARCHITECT_CONTACT"].ToString();
                    this.archiaddress = dbManager.DataReader["CUST_ARCHITECT_ADDRESS"].ToString();

                    this.siteinchargename = dbManager.DataReader["CUST_SITEINCHARGE_NAME"].ToString();
                    this.siteinchargecontact = dbManager.DataReader["CUST_SITEINCHARGE_CONTACT"].ToString();
                    this.siteinchargeaddress = dbManager.DataReader["CUST_SITEINCHARGE_ADDRESS"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public int CustomerUnitMaster_Select(string UniId)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Customer_Units] where [Customer_Units].CUST_UNIT_ID= " + UniId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.UnitName = dbManager.DataReader["CUST_UNIT_NAME"].ToString();
                    this.UnitAddress = dbManager.DataReader["CUST_UNIT_ADDRESS"].ToString();
                    this.NoofFloors = dbManager.DataReader["CUST_NO_FlOORS"].ToString();
                    this.Winload = dbManager.DataReader["CUST_WINLOAD"].ToString();
                    this.UnitContactPerson = dbManager.DataReader["CUST_CONTACTPERSON"].ToString();
                    this.UnitMobileNo = dbManager.DataReader["CUST_MOBILE"].ToString();

                    this.Arcname = dbManager.DataReader["ARCNAME"].ToString();
                    this.ArcMobile = dbManager.DataReader["ARCMOBILE"].ToString();
                    this.Proname = dbManager.DataReader["PRONAME"].ToString();
                    this.Promobile = dbManager.DataReader["PROMOBILE"].ToString();

                    this.ContPerson2 = dbManager.DataReader["CUST_CONTACTPERSON2"].ToString();
                    this.ContPersonMobile2 = dbManager.DataReader["CUST_MOBILE2"].ToString();
                    this.ContPerson3 = dbManager.DataReader["CUST_CONTACTPERSON3"].ToString();
                    this.ContPersonMobile3 = dbManager.DataReader["CUST_MOBILE3"].ToString();

                    this.ArcAddress = dbManager.DataReader["ARCADDRESS"].ToString();
                    this.ArcEmail = dbManager.DataReader["ARCEMAIL"].ToString();
                    this.ProEmail = dbManager.DataReader["PROEMAIL"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string Arcname, ArcMobile, Proname, Promobile, ContPerson2, ContPersonMobile2, ContPerson3, ContPersonMobile3, ArcAddress, ArcEmail, ProEmail;

            public string CustomerUnitMaster_Save()
            {
                this.Unitid = AutoGenMaxId("[Customer_Units]", "CUST_UNIT_ID");

                dbManager.Open();
                _commandText = string.Format("INSERT INTO [Customer_Units] VALUES({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')",
               this.Unitid, this.Custid, this.UnitName, this.UnitAddress, this.NoofFloors, this.Winload, this.UnitContactPerson, this.UnitMobileNo, this.Arcname, this.ArcMobile, this.Proname, this.Promobile, this.ContPerson2, this.ContPersonMobile2, this.ContPerson3, this.ContPersonMobile3, this.ArcAddress, this.ArcEmail, this.ProEmail);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string CustomerUnitMaster_Delete()
            {
                if (DeleteRecord("[Customer_Units]", "CUST_UNIT_ID", this.Unitid) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }

                return _returnStringMessage;
            }

            public string CustomerUnitMaster_Update()
            {
                dbManager.Open();

                _commandText = string.Format("UPDATE [Customer_Units] SET CUST_ID={0},CUST_UNIT_NAME='{1}',CUST_UNIT_ADDRESS='{2}',CUST_NO_FlOORS='{3}',CUST_WINLOAD='{4}',CUST_CONTACTPERSON='{5}',CUST_MOBILE='{6}',ARCNAME={7},ARCMOBILE='{8}',PRONAME='{9}',PROMOBILE='{10}',CUST_CONTACTPERSON2='{11}',CUST_MOBILE2='{12}',CUST_CONTACTPERSON3='{13}',CUST_MOBILE3='{14}',ARCADDRESS='{15}',ARCEMAIL='{16}',PROEMAIL='{17}' WHERE CUST_UNIT_ID={18}", this.Custid, this.UnitName, this.UnitAddress, this.NoofFloors, this.Winload, this.UnitContactPerson, this.UnitMobileNo, this.Arcname, this.ArcMobile, this.Proname, this.Promobile, this.ContPerson2, this.ContPersonMobile2, this.ContPerson3, this.ContPersonMobile3, this.ArcAddress, this.ArcEmail, this.ProEmail, this.Unitid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }

                return _returnStringMessage;
            }
        }

        public class Lead
        {
            public string LeadId, Status, PersonName, Gender, OrganizationName, LeadSourceId, EmailId, LeadOwnerId, NextContactDate, NextContactBy, Phone, SalutaionId, MobileNO, Fax, MarketSegment, IndustryId, Requesttype, LeadNo, LeadDate, Cpid, StateId, CityId, Notes, Prority, Subject;

            public Lead()
            { }

            public static string Lead_AutoGenCode()
            {
                return AutoGenMaxNo("Lead", "Lead_No");
            }

            public string Lead_Save()
            {
                dbManager.Open();

                _commandText = string.Format("INSERT INTO [Lead] SELECT ISNULL(MAX(Lead_Id),0)+1,'{0}','{1}','{2}','{3}',{4},'{5}',{6},'{7}',{8},'{9}',{10},'{11}','{12}','{13}',{14},'{15}','{16}','{17}',{18},{19},{20},'{21}','{22}','{23}' FROM [Lead]", this.Status, this.PersonName, this.Gender, this.OrganizationName, this.LeadSourceId, this.EmailId, this.LeadOwnerId, this.NextContactDate, this.NextContactBy, this.Phone, this.SalutaionId, this.MobileNO, this.Fax, this.MarketSegment, this.IndustryId, this.Requesttype, this.LeadNo, this.LeadDate, this.Cpid, this.StateId, this.CityId, this.Notes, this.Prority, this.Subject);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }

                return _returnStringMessage;
            }

            public string Lead_Update()
            {
                dbManager.Open();

                _commandText = string.Format("UPDATE [Lead] SET Lead_Status='{0}',Person_Name='{1}',Gender='{2}',Organization_Name='{3}',LeadSource_Id={4},Email_Address='{5}',Lead_Owner={6},NextContact_Date='{7}',NextContactBy={8},Phone='{9}',Salutation_Id={10},MobileNo='{11}',Fax='{12}',MarketSegment='{13}',Industry_Id={14},RequestType='{15}',Lead_No='{16}',Lead_Date='{17}',Cp_Id={18},StateId={19},CityId={20},Notes='{21}',Proiroty='{22}',Subject='{23}' WHERE Lead_Id={24}", this.Status, this.PersonName, this.Gender, this.OrganizationName, this.LeadSourceId, this.EmailId, this.LeadOwnerId, this.NextContactDate, this.NextContactBy, this.Phone, this.SalutaionId, this.MobileNO, this.Fax, this.MarketSegment, this.IndustryId, this.Requesttype, this.LeadNo, this.LeadDate, this.Cpid, this.StateId, this.CityId, this.Notes, this.Prority, this.Subject, this.LeadId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }

                return _returnStringMessage;
            }

            public string Lead_Delete()
            {
                Masters.BeginTransaction();
                if (DeleteRecord("[Lead]", "Lead_Id", this.LeadId) == true)
                {
                    Masters.CommitTransaction();
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    Masters.RollBackTransaction();
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public static void Lead_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Lead] ORDER BY Lead_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Lead_No", "Lead_Id");
                }
            }

            public int Lead_Select(string Code)
            {
                dbManager.Open();
                try
                {
                    _commandText = string.Format("SELECT * FROM [Lead] where Lead_Id =" + Code + " ");

                    dbManager.ExecuteReader(CommandType.Text, _commandText);
                    if (dbManager.DataReader.Read())
                    {
                        this.Status = dbManager.DataReader["Lead_Status"].ToString();
                        this.PersonName = dbManager.DataReader["Person_Name"].ToString();
                        this.Gender = dbManager.DataReader["Gender"].ToString();

                        this.OrganizationName = dbManager.DataReader["Organization_Name"].ToString();
                        this.LeadSourceId = dbManager.DataReader["LeadSource_Id"].ToString();
                        this.EmailId = dbManager.DataReader["Email_Address"].ToString();

                        this.LeadOwnerId = dbManager.DataReader["Lead_Owner"].ToString();
                        this.NextContactDate = Convert.ToDateTime(dbManager.DataReader["NextContact_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        this.NextContactBy = dbManager.DataReader["NextContactBy"].ToString();

                        this.Phone = dbManager.DataReader["Phone"].ToString();
                        this.SalutaionId = dbManager.DataReader["Salutation_Id"].ToString();
                        this.MobileNO = dbManager.DataReader["MobileNo"].ToString();

                        this.Fax = dbManager.DataReader["Fax"].ToString();
                        this.MarketSegment = dbManager.DataReader["MarketSegment"].ToString();
                        this.IndustryId = dbManager.DataReader["Industry_Id"].ToString();

                        this.Requesttype = dbManager.DataReader["RequestType"].ToString();
                        this.LeadNo = dbManager.DataReader["Lead_No"].ToString();
                        this.LeadDate = dbManager.DataReader["Lead_Date"].ToString();
                        this.Cpid = dbManager.DataReader["Cp_Id"].ToString();

                        this.StateId = dbManager.DataReader["StateId"].ToString();
                        this.CityId = dbManager.DataReader["CityId"].ToString();


                        this.Prority = dbManager.DataReader["Proiroty"].ToString();
                        this.Notes = dbManager.DataReader["Notes"].ToString();
                        this.Subject = dbManager.DataReader["Subject"].ToString();

                        this.LeadDate = Convert.ToDateTime(dbManager.DataReader["Lead_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        _returnIntValue = 1;
                    }
                    else
                    {
                        _returnIntValue = 0;
                    }
                    dbManager.DataReader.Close();
                }
                catch
                {
                }
                finally
                {
                }
                return _returnIntValue;
            }
        }

        //Methods for Sales Quotation Form
        public class SalesQuotation
        {
            public string QuotId, QuotNo, QuotDate, Quotto, Validto, EnqId, CustId, UnitId, SalesEmpId, PaymentTermsId, TermsCondtionId, Discount, Tax, GrandTotal, Preparedby, Approvedby, Revisedkey, Status;

            public string QuoDetId, WindowCode, System, Description, Glass, Location, Mesh, ProfileColor, HardwareColor, Width, Height, Qty, TotalArea, ProfileCostEuro, GlassPrice, MeshPrice, RecractablePrice, MsInsertPrice, TotalAmount, ExtraGlassWidth, ExtraGlassHeight, ExtraGlassQty, ExtraGlassArea, ExtraGlassPrice, HardwarePrice;

            public string Quodocid, QuoDocdate, QuoDocRemarks, QuoDocuments;

            public string InstallationtempId, DamagetempId, StroageTempId, Specifications, DesignerId;

            public string Paymentterms, TermsCondtions, StrorageTerms, DamageTerms, Installationterms, Options;

            public SalesQuotation()
            {
            }

            public static string SalesQuotation_AutoGenCode()
            {
                return AutoGenMaxNo("Quotation_Master", "Quotation_No");
            }
            public string Qcid, EuroPrice, Freight, Customes, Insurance, Clearance, Wastage, Wallplugs, Silicon, Maskingtape, BackorRod, FabricationPersqf, FabricationPersqm, Installationpersft, InstallationPersqm, Margin, Siliconwidht, SiliconDepth;   // Master

            public string RevisedDate, AluminumColor, HardwarecolorItem, Windload;

            public string SalesQuotation_Save()
            {
                this.Revisedkey = "R0";
                this.Options = "O0";
                this.RevisedDate = this.QuotDate;
                this.QuotId = AutoGenMaxId("[Quotation_Master]", "Quotation_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Quotation_Master] SELECT ISNULL(MAX(Quotation_Id),0)+1,'{0}','{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},'{10}','{11}','{12}',{13},{14},'{15}','{16}',{17},{18},{19},'{20}',{21},'{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}' from Quotation_Master", this.QuotNo, this.QuotDate, this.Quotto, this.Validto, this.EnqId, this.CustId, this.UnitId, this.SalesEmpId, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby, this.Revisedkey, this.Status, this.InstallationtempId, this.DamagetempId, this.StroageTempId, this.Specifications, this.DesignerId, this.RevisedDate, this.AluminumColor, this.HardwarecolorItem, this.Windload, this.Paymentterms, this.TermsCondtions, this.StrorageTerms, this.DamageTerms, this.Installationterms, this.Options);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                _commandText = string.Format("INSERT INTO [Sales_Quatation_CalcChange] SELECT ISNULL(MAX(QuatationChang_Id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}' FROM [Sales_Quatation_CalcChange]", this.QuotId, this.EuroPrice, this.Freight, this.Customes, this.Insurance, this.Clearance, this.Wastage, this.Wallplugs, this.Silicon, this.Maskingtape, this.BackorRod, this.FabricationPersqf, this.FabricationPersqm, this.Installationpersft, this.InstallationPersqm, this.Margin, this.Siliconwidht, this.SiliconDepth);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                if (this.EnqId != "0")
                {
                    this.Status = "Open";
                    _commandText = string.Format("UPDATE [SalesEnquiry_Master] SET STATUS='{0}' WHERE ENQ_ID ={1}", this.Status, this.EnqId);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                }

                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public static string SalesQuotationStatus_Update(string Status, string QuotId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [Quotation_Master] SET Status='{0}' WHERE Quotation_Id='{1}'", Status, QuotId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesQuotationRevise_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();



                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(REPLACE(RevisedKey,'R','')),0)+1 FROM Quotation_Master WHERE Quotation_No LIKE '" + this.QuotNo + "%'").ToString());
                this.Revisedkey = "R" + _returnIntValue.ToString();

                // this.Status = "Revised";
                string HAI = "Revised";
                SalesQuotationStatus_Update(HAI, this.QuotId);

                this.QuotId = AutoGenMaxId("[Quotation_Master]", "Quotation_Id");

                _commandText = string.Format("INSERT INTO [Quotation_Master] SELECT ISNULL(MAX(Quotation_Id),0)+1,'{0}','{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},'{10}','{11}','{12}',{13},{14},'{15}','{16}',{17},{18},{19},'{20}',{21},'{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}' from Quotation_Master", this.QuotNo, this.QuotDate, this.Quotto, this.Validto, this.EnqId, this.CustId, this.UnitId, this.SalesEmpId, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby, this.Revisedkey, this.Status, this.InstallationtempId, this.DamagetempId, this.StroageTempId, this.Specifications, this.DesignerId, this.RevisedDate, this.AluminumColor, this.HardwarecolorItem, this.Windload, this.Paymentterms, this.TermsCondtions, this.StrorageTerms, this.DamageTerms, this.Installationterms, this.Options);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                _commandText = string.Format("INSERT INTO [Sales_Quatation_CalcChange] SELECT ISNULL(MAX(QuatationChang_Id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}' FROM [Sales_Quatation_CalcChange]", this.QuotId, this.EuroPrice, this.Freight, this.Customes, this.Insurance, this.Clearance, this.Wastage, this.Wallplugs, this.Silicon, this.Maskingtape, this.BackorRod, this.FabricationPersqf, this.FabricationPersqm, this.Installationpersft, this.InstallationPersqm, this.Margin, this.Siliconwidht, this.SiliconDepth);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                dbManager.Dispose();


                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;

            }

            public string SalesQuotation_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Quotation_Master] SET Quotation_Date='{0}',Quotation_to='{1}',Valid_To='{2}',Enq_Id={3},Cust_ID={4},Unit_Id={5},SalesEmp_Id={6},PaymentTerms_Id={7},TermsCondtions_Id={8},Discount='{9}',Tax='{10}',GrandTotal='{11}',PreparedBy={12},ApprovedBy={13},InstallationTemp_Id={14},DamageTemp_Id={15},StorageTemp_Id={16},Specifications='{17}',DesginerId={18},Aluminum_Color='{19}',Hardware_Color='{20}',Wind_Load='{21}',PaymentTerms='{22}',TermsCondtions='{23}',StorageTerms='{24}',DamageTerms='{25}',InstallationTerms='{26}',OptionKey='{27}' WHERE Quotation_Id={28}", this.QuotDate, this.Quotto, this.Validto, this.EnqId, this.CustId, this.UnitId, this.SalesEmpId, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby, this.InstallationtempId, this.DamagetempId, this.StroageTempId, this.Specifications, this.DesignerId, this.AluminumColor, this.HardwareColor, this.Windload, this.Paymentterms, this.TermsCondtions, this.StrorageTerms, this.DamageTerms, this.Installationterms, this.Options, this.QuotId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                _commandText = string.Format("UPDATE [Sales_Quatation_CalcChange] SET Euro_Price='{0}',Freight='{1}',Customs='{2}',Insurance='{3}',Clearance='{4}',Wastage='{5}',WallPlugs='{6}',Silicon='{7}',Maskingtape='{8}',BackorRod='{9}',FabricationPerSft='{10}',FabricationPerSqm='{11}',InstallationPerSft='{12}',InstallationPerSqm='{13}',Margin='{14}',Silicon_Width='{15}',Silicon_Depth='{16}' WHERE Quatation_Id={17}", this.EuroPrice, this.Freight, this.Customes, this.Insurance, this.Clearance, this.Wastage, this.Wallplugs, this.Silicon, this.Maskingtape, this.BackorRod, this.FabricationPersqf, this.FabricationPersqm, this.Installationpersft, this.InstallationPersqm, this.Margin, this.Siliconwidht, this.SiliconDepth, this.QuotId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);



                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }


            public string SalesQuotationDetailsImage_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Sales_QuotationDetails] SET Item_Image='{0}',ElevationView='{1}' WHERE QuotationDet_id ={2}", this.ItemImage, this.ElevationView, this.QuoDetId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }


            public string SalesQuotation_Delete(string QuotationId)
            {
                SM.BeginTransaction();
                if (DeleteRecord("[QuotationMaster_Details]", "Quotation_Id", QuotationId) == true)
                {
                    if (DeleteRecord("[Quotation_Master]", "Quotation_Id", QuotationId) == true)
                    {
                        SM.CommitTransaction();
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        SM.RollBackTransaction();
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                }
                else
                {
                    SM.RollBackTransaction();
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public string ItemImage, ElevationView;
            public string SalesQuotationDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Sales_QuotationDetails] SELECT ISNULL(MAX(QuotationDet_Id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},'{12}','{13}','{14}','{15}','{16}','{17}','{18}',{19},{20},{21},'{22}','{23}','{24}',{25},'{26}' FROM [Sales_QuotationDetails]", this.QuotId, this.WindowCode, this.System, this.Description, this.Glass, this.Location, this.Mesh, this.ProfileColor, this.HardwareColor, this.Width, this.Height, this.Qty, this.TotalArea, this.ProfileCostEuro, this.GlassPrice, this.MeshPrice, this.RecractablePrice, this.MsInsertPrice, this.TotalAmount, this.ExtraGlassWidth, this.ExtraGlassHeight, this.ExtraGlassQty, this.ExtraGlassArea, this.ExtraGlassPrice, this.HardwarePrice, this.ItemImage, this.ElevationView);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int SalesQuotationDetails_Delete(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Sales_QuotationDetails] WHERE Quotation_Id = {0}", QuotationId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int SalesQuotation_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Quotation_Master] WHERE Quotation_Master.Quotation_Id='" + QuotationId + "' ORDER BY [Quotation_Master].Quotation_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.QuotId = dbManager.DataReader["Quotation_Id"].ToString();
                    this.QuotNo = dbManager.DataReader["Quotation_No"].ToString();
                    this.QuotDate = Convert.ToDateTime(dbManager.DataReader["Quotation_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Quotto = dbManager.DataReader["Quotation_to"].ToString();
                    this.Validto = Convert.ToDateTime(dbManager.DataReader["Valid_To"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.EnqId = dbManager.DataReader["Enq_Id"].ToString();
                    this.CustId = dbManager.DataReader["Cust_ID"].ToString();
                    this.UnitId = dbManager.DataReader["Unit_Id"].ToString();
                    this.SalesEmpId = dbManager.DataReader["SalesEmp_Id"].ToString();
                    this.PaymentTermsId = dbManager.DataReader["PaymentTerms_Id"].ToString();
                    this.TermsCondtionId = dbManager.DataReader["TermsCondtions_Id"].ToString();
                    this.Discount = dbManager.DataReader["Discount"].ToString();
                    this.Tax = dbManager.DataReader["Tax"].ToString();
                    this.GrandTotal = dbManager.DataReader["GrandTotal"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();
                    this.Revisedkey = dbManager.DataReader["RevisedKey"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();

                    this.InstallationtempId = dbManager.DataReader["InstallationTemp_Id"].ToString();
                    this.DamagetempId = dbManager.DataReader["DamageTemp_Id"].ToString();
                    this.StroageTempId = dbManager.DataReader["StorageTemp_Id"].ToString();
                    this.Specifications = dbManager.DataReader["Specifications"].ToString();
                    this.DesignerId = dbManager.DataReader["DesginerId"].ToString();



                    this.AluminumColor = dbManager.DataReader["Aluminum_Color"].ToString();
                    this.HardwareColor = dbManager.DataReader["Hardware_Color"].ToString();
                    this.Windload = dbManager.DataReader["Wind_Load"].ToString();



                    this.Paymentterms = dbManager.DataReader["PaymentTerms"].ToString();
                    this.TermsCondtions = dbManager.DataReader["TermsCondtions"].ToString();
                    this.StrorageTerms = dbManager.DataReader["StorageTerms"].ToString();
                    this.DamageTerms = dbManager.DataReader["DamageTerms"].ToString();
                    this.Installationterms = dbManager.DataReader["InstallationTerms"].ToString();
                    this.Options = dbManager.DataReader["OptionKey"].ToString();


                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                dbManager.Close();
                return _returnIntValue;
            }



            public int SalesQuotationCust_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Quotation_Master] WHERE Quotation_Master.Unit_Id='" + QuotationId + "' ORDER BY [Quotation_Master].Quotation_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.QuotId = dbManager.DataReader["Quotation_Id"].ToString();
                    this.QuotNo = dbManager.DataReader["Quotation_No"].ToString();
                    this.QuotDate = Convert.ToDateTime(dbManager.DataReader["Quotation_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Quotto = dbManager.DataReader["Quotation_to"].ToString();
                    this.Validto = Convert.ToDateTime(dbManager.DataReader["Valid_To"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.EnqId = dbManager.DataReader["Enq_Id"].ToString();
                    this.CustId = dbManager.DataReader["Cust_ID"].ToString();
                    this.UnitId = dbManager.DataReader["Unit_Id"].ToString();
                    this.SalesEmpId = dbManager.DataReader["SalesEmp_Id"].ToString();
                    this.PaymentTermsId = dbManager.DataReader["PaymentTerms_Id"].ToString();
                    this.TermsCondtionId = dbManager.DataReader["TermsCondtions_Id"].ToString();
                    this.Discount = dbManager.DataReader["Discount"].ToString();
                    this.Tax = dbManager.DataReader["Tax"].ToString();
                    this.GrandTotal = dbManager.DataReader["GrandTotal"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();
                    this.Revisedkey = dbManager.DataReader["RevisedKey"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();

                    this.InstallationtempId = dbManager.DataReader["InstallationTemp_Id"].ToString();
                    this.DamagetempId = dbManager.DataReader["DamageTemp_Id"].ToString();
                    this.StroageTempId = dbManager.DataReader["StorageTemp_Id"].ToString();
                    this.Specifications = dbManager.DataReader["Specifications"].ToString();
                    this.DesignerId = dbManager.DataReader["DesginerId"].ToString();


                    this.Paymentterms = dbManager.DataReader["PaymentTerms"].ToString();
                    this.TermsCondtions = dbManager.DataReader["TermsCondtions"].ToString();
                    this.StrorageTerms = dbManager.DataReader["StorageTerms"].ToString();
                    this.DamageTerms = dbManager.DataReader["DamageTerms"].ToString();
                    this.Installationterms = dbManager.DataReader["InstallationTerms"].ToString();

                    this.Options = dbManager.DataReader["OptionKey"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                dbManager.Close();
                return _returnIntValue;
            }









            public string SalesQuotationApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                this.Status = "Open";
                _commandText = string.Format("UPDATE [Quotation_Master] SET ApprovedBy={0} WHERE Quotation_Id ={1}", this.Approvedby, this.QuotId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _commandText = string.Format("UPDATE [Quotation_Master] SET Status='{0}' WHERE Quotation_Id ={1}", this.Status, this.QuotId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesEnquiryStatus_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                this.Status = "Open";

                string es = "Close";

                _commandText = string.Format("UPDATE [SalesEnquiry_Master] SET STATUS='{0}' WHERE ENQ_ID ={1}", es, this.EnqId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }

            public void SalesQuotOrder_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [QuotationMaster_Details],[Material_Master] where QuotationMaster_Details.Material_Id=[Material_Master].Material_Id AND " +
                                               " [QuotationMaster_Details].Quotation_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Id");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Glass");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Mesh");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("Width");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Height");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Areasq");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SeriesID");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("Amount");
                SalesQuotationItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["Id"] = dbManager.DataReader["QuotationDet_Id"].ToString();
                    dr["Series"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();

                    dr["Mesh"] = dbManager.DataReader["Mesh"].ToString();
                    dr["Glass"] = dbManager.DataReader["Glass"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["Height"] = dbManager.DataReader["Height"].ToString();
                    dr["Qty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Areasq"] = dbManager.DataReader["AreaSqMt"].ToString();

                    dr["SeriesID"] = dbManager.DataReader["Material_Id"].ToString();

                    dr["Amount"] = dbManager.DataReader["Amount"].ToString();

                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }

            public void SalesQuotationDetails_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Sales_QuotationDetails] where " +
                                               " [Sales_QuotationDetails].Quotation_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("CodeNo");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Width");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("height");
                SalesQuotationItems.Columns.Add(col);
                //col = new DataColumn("SillHeight");
                //SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Glass");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Mesh");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ProfileColor");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("HardwareColor");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("TotalArea");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("TotalAmount");
                SalesQuotationItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["CodeNo"] = dbManager.DataReader["WindowCode"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["height"] = dbManager.DataReader["Height"].ToString();
                    dr["Series"] = dbManager.DataReader["System"].ToString();
                    dr["Qty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Glass"] = dbManager.DataReader["Glass"].ToString();
                    dr["Mesh"] = dbManager.DataReader["Mesh"].ToString();
                    dr["ProfileColor"] = dbManager.DataReader["ProfileColor"].ToString();
                    dr["HardwareColor"] = dbManager.DataReader["HardwareColor"].ToString();
                    dr["TotalArea"] = dbManager.DataReader["TotalArea"].ToString();
                    dr["TotalAmount"] = dbManager.DataReader["TotalAmount"].ToString();
                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }


            //New

            public void NewSalesQuotationDetails_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Sales_QuotationDetails] where " +
                                               " [Sales_QuotationDetails].Quotation_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("CodeNo");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("System");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Glass");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Location");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Mesh");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Width");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("height");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("TotalArea");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ProfileColor");
                SalesOrderItems.Columns.Add(col);
                //col = new DataColumn("ProfileColor");
                //SalesOrderItems.Columns.Add(col);
                col = new DataColumn("HardwareColor");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("UnitCostEuro");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemGlassPrice");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemMeshPrice");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemRecractablePrice");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemMSInsertPrice");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemExtraGlasswidth");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemExtraGlassheight");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemExtraGlassQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemExtraGlassArea");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemExtraGlassPrice");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemHardwarePrice");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("TotalAmount");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();

                    dr["CodeNo"] = dbManager.DataReader["WindowCode"].ToString();
                    dr["System"] = dbManager.DataReader["System"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Glass"] = dbManager.DataReader["Glass"].ToString();
                    dr["Location"] = dbManager.DataReader["Location"].ToString();
                    dr["Mesh"] = dbManager.DataReader["Mesh"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["height"] = dbManager.DataReader["Height"].ToString();
                    dr["Qty"] = dbManager.DataReader["Qty"].ToString();
                    dr["TotalArea"] = dbManager.DataReader["TotalArea"].ToString();
                    dr["ProfileColor"] = dbManager.DataReader["ProfileColor"].ToString();
                    dr["HardwareColor"] = dbManager.DataReader["HardwareColor"].ToString();
                    dr["UnitCostEuro"] = dbManager.DataReader["ProfileCostEuro"].ToString();
                    dr["ItemGlassPrice"] = dbManager.DataReader["GlassPrice"].ToString();
                    dr["ItemMeshPrice"] = dbManager.DataReader["MeshPrice"].ToString();
                    dr["ItemRecractablePrice"] = dbManager.DataReader["RecractablePrice"].ToString();
                    dr["ItemMSInsertPrice"] = dbManager.DataReader["MSInsertPrice"].ToString();
                    dr["ItemExtraGlasswidth"] = dbManager.DataReader["ExtraGlassWidth"].ToString();
                    dr["ItemExtraGlassheight"] = dbManager.DataReader["ExtraGlassHeight"].ToString();
                    dr["ItemExtraGlassQty"] = dbManager.DataReader["ExtraGlassQty"].ToString();
                    dr["ItemExtraGlassArea"] = dbManager.DataReader["ExtraGlassArea"].ToString();
                    dr["ItemExtraGlassPrice"] = dbManager.DataReader["ExtraGlassPrice"].ToString();
                    dr["ItemHardwarePrice"] = dbManager.DataReader["HardwarePrice"].ToString();
                    dr["TotalAmount"] = dbManager.DataReader["TotalAmount"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }
                dbManager.Close();
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }













            public static void SalesQuotation_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Quotation_Id,Quotation_No+' '+RevisedKey+'('+CUST_UNIT_NAME+')' AS QUOTNO FROM [Quotation_Master],Customer_Units where [Quotation_Master].Unit_Id = Customer_Units.CUST_UNIT_ID  ORDER BY Quotation_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "QUOTNO", "Quotation_Id");
                }
            }

            public static void CustSalesQuotation_Select(Control ControlForBind, string Custid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Quotation_Id,Quotation_No+' '+RevisedKey+'('+CUST_UNIT_NAME+')' AS QUOTNO FROM [Quotation_Master],Customer_Units where [Quotation_Master].Unit_Id = Customer_Units.CUST_UNIT_ID and Quotation_Master.Cust_ID  = '" + Custid + "' ORDER BY Quotation_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "QUOTNO", "Quotation_Id");
                }
            }


            public static void CustUnitSalesQuotation_Select(Control ControlForBind, string Custid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT top 1 Quotation_Id,Quotation_No+' '+RevisedKey+'('+CUST_UNIT_NAME+')' AS QUOTNO FROM [Quotation_Master],Customer_Units where [Quotation_Master].Unit_Id = Customer_Units.CUST_UNIT_ID and Quotation_Master.Unit_Id  = '" + Custid + "' ORDER BY Quotation_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "QUOTNO", "Quotation_Id");
                }
            }



            public string QuatationDocuments_Details_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Quatation_Documents] SELECT ISNULL(MAX(Quatation_Doc_Id),0)+1,'{0}','{1}','{2}',{3} FROM [Quatation_Documents]", this.QuoDocdate, this.QuoDocRemarks, this.QuoDocuments, this.QuotId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string QuatationDocumentsDetails_Delete(string Eleid)
            {
                if (DeleteRecord("[Quatation_Documents]", "Quatation_Doc_Id", Eleid) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }

                return _returnStringMessage;
            }









            public string SalesQuotationOptions_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();



                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(REPLACE(OptionKey,'O','')),0)+1 FROM Quotation_Master WHERE Quotation_No LIKE '" + this.QuotNo + "%'").ToString());
                this.Options = "O" + _returnIntValue.ToString();

                // this.Status = "Revised";
                //string HAI = "Revised";
                //SalesQuotationStatus_Update(HAI, this.QuotId);

                this.QuotId = AutoGenMaxId("[Quotation_Master]", "Quotation_Id");

                _commandText = string.Format("INSERT INTO [Quotation_Master] SELECT ISNULL(MAX(Quotation_Id),0)+1,'{0}','{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},'{10}','{11}','{12}',{13},{14},'{15}','{16}',{17},{18},{19},'{20}',{21},'{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}' from Quotation_Master", this.QuotNo, this.QuotDate, this.Quotto, this.Validto, this.EnqId, this.CustId, this.UnitId, this.SalesEmpId, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby, this.Revisedkey, this.Status, this.InstallationtempId, this.DamagetempId, this.StroageTempId, this.Specifications, this.DesignerId, this.RevisedDate, this.AluminumColor, this.HardwarecolorItem, this.Windload, this.Paymentterms, this.TermsCondtions, this.StrorageTerms, this.DamageTerms, this.Installationterms, this.Options);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                _commandText = string.Format("INSERT INTO [Sales_Quatation_CalcChange] SELECT ISNULL(MAX(QuatationChang_Id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}' FROM [Sales_Quatation_CalcChange]", this.QuotId, this.EuroPrice, this.Freight, this.Customes, this.Insurance, this.Clearance, this.Wastage, this.Wallplugs, this.Silicon, this.Maskingtape, this.BackorRod, this.FabricationPersqf, this.FabricationPersqm, this.Installationpersft, this.InstallationPersqm, this.Margin, this.Siliconwidht, this.SiliconDepth);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                dbManager.Dispose();


                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;

            }










            ///////// Old Data tables
            //public void SalesQuotOrder_Select(string QuotationId, GridView gv)
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();
            //    _commandText = string.Format("SELECT * FROM [QuotationMaster_Details],[Material_Master] where QuotationMaster_Details.Material_Id=[Material_Master].Material_Id AND " +
            //                                   " [QuotationMaster_Details].Quotation_Id=" + QuotationId + "");
            //    dbManager.ExecuteReader(CommandType.Text, _commandText);

            //    DataTable SalesQuotationItems = new DataTable();
            //    DataColumn col = new DataColumn();
            //    col = new DataColumn("Id");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Series");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Description");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Glass");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Mesh");
            //    SalesQuotationItems.Columns.Add(col);

            //    col = new DataColumn("Width");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Height");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Qty");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Areasq");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("SeriesID");
            //    SalesQuotationItems.Columns.Add(col);

            //    col = new DataColumn("Amount");
            //    SalesQuotationItems.Columns.Add(col);

            //    while (dbManager.DataReader.Read())
            //    {
            //        DataRow dr = SalesQuotationItems.NewRow();
            //        dr["Id"] = dbManager.DataReader["QuotationDet_Id"].ToString();
            //        dr["Series"] = dbManager.DataReader["Material_Code"].ToString();
            //        dr["Description"] = dbManager.DataReader["Description"].ToString();

            //        dr["Mesh"] = dbManager.DataReader["Mesh"].ToString();
            //        dr["Glass"] = dbManager.DataReader["Glass"].ToString();
            //        dr["Width"] = dbManager.DataReader["Width"].ToString();
            //        dr["Height"] = dbManager.DataReader["Height"].ToString();
            //        dr["Qty"] = dbManager.DataReader["Qty"].ToString();
            //        dr["Areasq"] = dbManager.DataReader["AreaSqMt"].ToString();

            //        dr["SeriesID"] = dbManager.DataReader["Material_Id"].ToString();

            //        dr["Amount"] = dbManager.DataReader["Amount"].ToString();

            //        SalesQuotationItems.Rows.Add(dr);
            //    }

            //    gv.DataSource = SalesQuotationItems;
            //    gv.DataBind();
            //}

            //public void SalesQuotationDetails_Select(string QuotationId, GridView gv)
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();
            //    _commandText = string.Format("SELECT * FROM [QuotationMaster_Details],[Material_Master] where QuotationMaster_Details.Material_Id=[Material_Master].Material_Id AND " +
            //                                   " [QuotationMaster_Details].Quotation_Id=" + QuotationId + "");
            //    dbManager.ExecuteReader(CommandType.Text, _commandText);

            //    DataTable SalesQuotationItems = new DataTable();
            //    DataColumn col = new DataColumn();
            //    col = new DataColumn("Series");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Description");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Glass");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Mesh");
            //    SalesQuotationItems.Columns.Add(col);

            //    col = new DataColumn("Width");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Height");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Qty");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Areasq");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("SeriesID");
            //    SalesQuotationItems.Columns.Add(col);

            //    col = new DataColumn("Amount");
            //    SalesQuotationItems.Columns.Add(col);

            //    while (dbManager.DataReader.Read())
            //    {
            //        DataRow dr = SalesQuotationItems.NewRow();
            //        dr["Series"] = dbManager.DataReader["Material_Code"].ToString();
            //        dr["Description"] = dbManager.DataReader["Description"].ToString();

            //        dr["Mesh"] = dbManager.DataReader["Mesh"].ToString();
            //        dr["Glass"] = dbManager.DataReader["Glass"].ToString();
            //        dr["Width"] = dbManager.DataReader["Width"].ToString();
            //        dr["Height"] = dbManager.DataReader["Height"].ToString();
            //        dr["Qty"] = dbManager.DataReader["Qty"].ToString();
            //        dr["Areasq"] = dbManager.DataReader["AreaSqMt"].ToString();

            //        dr["SeriesID"] = dbManager.DataReader["Material_Id"].ToString();

            //        dr["Amount"] = dbManager.DataReader["Amount"].ToString();

            //        SalesQuotationItems.Rows.Add(dr);
            //    }

            //    gv.DataSource = SalesQuotationItems;
            //    gv.DataBind();
            //}
        }

        //Methods for Sales Order Form
        public class SalesOrder
        {
            public string SOID, SONO, SODATE, Deliverydate, OrderType, CustPoNo, QUOID, Custid, SiteId, Purconditionsid, termsId, PREPAREDBY, APPROVEDBY, Status, ProjectCode;

            public string SoDetId, Code, Width, Height, Series, Quantity, Glass, Flyscreen, Profilecolor, Hardwarecolor, TotalArea, totalamount, itemdeliverydate, Bomstatus, BomDetId;


            public string BomQuantity, BomPu, BomBarlength, BomReqQty, BomUnit, BomDescription, BomColor, BomWeight, BomItemcode, BomItemcodeId, BomColorid, BomIssuedqty;

            public string SODocdate, SODocRemarks, SODocuments, SOtId;


            public string SowId, SowStratdate, SowEnddate, Priority, Cutting, Floding, Machinging, Punching, Shearing, Stamping, Casting, Welding, Finishing, option1, option2, option3, option4, Sowremarks;

            public string mumbaistockupdateon;


            public string AlumilSystem, Windowcolor, sohardwarecolor, sototalarea, totalqty, deliverycompletedate, Installationdate;



            public SalesOrder()
            {
            }

            public static string SalesOrder_AutoGenCode()
            {
                return AutoGenMaxNo("Sales_Order", "SalesOrder_No");
            }

            public string SalesOrder_Save()
            {
                this.SOID = AutoGenMaxId("[Sales_Order]", "SalesOrder_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();

                if (IsRecordExists("[Sales_Order]", "ProjectCode", this.ProjectCode) == false)
                {

                    _commandText = string.Format("INSERT INTO [Sales_Order] SELECT ISNULL(MAX(SalesOrder_Id),0)+1,'{0}','{1}','{2}','{3}','{4}',{5},{6},{7},'{8}','{9}',{10},{11},'{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}' from Sales_Order", this.SONO, this.SODATE, this.Deliverydate, this.OrderType, this.CustPoNo, this.QUOID, this.Custid, this.SiteId, this.Purconditionsid, this.termsId, this.PREPAREDBY, this.APPROVEDBY, this.Status, this.ProjectCode,this.AlumilSystem,this.Windowcolor,this.sohardwarecolor,this.sototalarea,this.totalqty,this.Installationdate);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                    if (this.QUOID != "0")
                    {
                        _commandText = string.Format("UPDATE [Quotation_Master] SET Status='Open' WHERE Quotation_Id ={0}", this.QUOID);
                        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    }


                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }


                }
                else
                {
                    _returnStringMessage = "Project Code Already Exists.";
                }
                return _returnStringMessage;
            }

            public string SalesOrder_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Sales_Order] SET SalesOrder_Date='{0}',Delivery_Date='{1}',OrderType='{2}',CustPurchaseorder='{3}',Quatation_Id={4},CustId={5},CustSiteId={6},PurchaseCondtions_Id='{7}',TermsCondtions_Id='{8}',PreparedBy={9},ApprovedBy={10},Status='{19}',ProjectCode='{11}',AlumilSystem='{12}',WindowColor='{13}',HardwareColor='{14}',TotalArea='{15}',TotalQty='{16}',InstallationCompletedate='{17}' WHERE SalesOrder_Id={18}", this.SODATE, this.Deliverydate, this.OrderType, this.CustPoNo, this.QUOID, this.Custid, this.SiteId, this.Purconditionsid, this.termsId, this.PREPAREDBY, this.APPROVEDBY, this.ProjectCode,this.AlumilSystem,this.Windowcolor,this.sohardwarecolor,this.sototalarea,this.totalqty,this.Installationdate, this.SOID, this.Status);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesOrder_Delete(string SOID)
            {
                if (DeleteRecord("[SalesOrder_Details]", "SalesOrder_Id", SOID) == true)
                {
                    if (DeleteRecord("[Sales_Order]", "SalesOrder_Id", SOID) == true)
                    {
                        // SM.CommitTransaction();
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        //  SM.RollBackTransaction();
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public string SalesOrderDetails_Save()
            {

                this.SoDetId = AutoGenMaxId("[SalesOrder_Details]", "SalesOrderDet_Id");

                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [SalesOrder_Details] SELECT ISNULL(MAX(SalesOrderDet_Id),0)+1,{0},'{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}' FROM [SalesOrder_Details]", this.SOID, this.Code, this.Series, this.Width, this.Height, this.Quantity, this.Glass, this.Flyscreen, this.Profilecolor, this.Hardwarecolor, this.TotalArea, this.totalamount, this.itemdeliverydate, this.Bomstatus);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);




                _commandText = string.Format("INSERT INTO [SO_Window_Operations] SELECT ISNULL(MAX(Sow_OperationId),0)+1,{0},{1},getdate(),getdate(),'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}' FROM [SO_Window_Operations]", this.SOID, this.SoDetId, "Low", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);



                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int SalesOrderDetails_Delete(string SOid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [SalesOrder_Details] WHERE SalesOrder_Id = {0}", SOid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }




            public int SalesOrderWindowOperation_Delete(string SOid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [SO_Window_Operations] WHERE So_Id = {0}", SOid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }




            public int BOMDetails_Delete(string SOid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [SalesOrder_MaterialAnalysis] WHERE SO_MATANA_ID = {0}", SOid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public string SalesOrderBOMDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [SalesOrder_MaterialAnalysis] SELECT ISNULL(MAX(SO_MATANA_ID),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},{11},{12} FROM [SalesOrder_MaterialAnalysis]", this.SOID, this.BomQuantity, this.BomPu, this.BomBarlength, this.BomReqQty, this.BomUnit, this.BomDescription, this.BomColor, this.BomWeight, this.BomItemcode, this.BomItemcodeId, this.BomColorid, this.BomIssuedqty);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int SalesOrderMaterialAnalysisDetails_Delete(string SOid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [SalesOrder_MaterialAnalysis] WHERE SO_ID = {0}", SOid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }



            public int MumbaiStockDetails_Delete()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [MumbaiStock]");
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }



            public int SalesOrder_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Sales_Order] WHERE Sales_Order.SalesOrder_Id='" + QuotationId + "' ORDER BY Sales_Order.SalesOrder_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SOID = dbManager.DataReader["SalesOrder_Id"].ToString();
                    this.SONO = dbManager.DataReader["SalesOrder_No"].ToString();
                    this.SODATE = Convert.ToDateTime(dbManager.DataReader["SalesOrder_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Deliverydate = Convert.ToDateTime(dbManager.DataReader["Delivery_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.OrderType = dbManager.DataReader["OrderType"].ToString();
                    this.CustPoNo = dbManager.DataReader["CustPurchaseorder"].ToString();
                    this.QUOID = dbManager.DataReader["Quatation_Id"].ToString();
                    this.Custid = dbManager.DataReader["CustId"].ToString();
                    this.SiteId = dbManager.DataReader["CustSiteId"].ToString();
                    this.Purconditionsid = dbManager.DataReader["PurchaseCondtions_Id"].ToString();
                    this.termsId = dbManager.DataReader["TermsCondtions_Id"].ToString();
                    this.PREPAREDBY = dbManager.DataReader["PreparedBy"].ToString();
                    this.APPROVEDBY = dbManager.DataReader["ApprovedBy"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();

                    this.ProjectCode = dbManager.DataReader["ProjectCode"].ToString();


                    this.AlumilSystem = dbManager.DataReader["AlumilSystem"].ToString();
                    this.Windowcolor = dbManager.DataReader["WindowColor"].ToString();
                    this.sohardwarecolor = dbManager.DataReader["HardwareColor"].ToString();
                    this.sototalarea = dbManager.DataReader["TotalArea"].ToString();
                    this.totalqty = dbManager.DataReader["TotalQty"].ToString();

                    if (dbManager.DataReader["TotalQty"].ToString() != "")
                    { 

                    this.Installationdate = Convert.ToDateTime(dbManager.DataReader["InstallationCompletedate"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    }
                    



                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public int SalesOrderCust_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Sales_Order] WHERE Sales_Order.Quatation_Id='" + QuotationId + "' ORDER BY Sales_Order.SalesOrder_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SOID = dbManager.DataReader["SalesOrder_Id"].ToString();
                    this.SONO = dbManager.DataReader["SalesOrder_No"].ToString();
                    this.SODATE = Convert.ToDateTime(dbManager.DataReader["SalesOrder_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Deliverydate = Convert.ToDateTime(dbManager.DataReader["Delivery_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.OrderType = dbManager.DataReader["OrderType"].ToString();
                    this.CustPoNo = dbManager.DataReader["CustPurchaseorder"].ToString();
                    this.QUOID = dbManager.DataReader["Quatation_Id"].ToString();
                    this.Custid = dbManager.DataReader["CustId"].ToString();
                    this.SiteId = dbManager.DataReader["CustSiteId"].ToString();
                    this.Purconditionsid = dbManager.DataReader["PurchaseCondtions_Id"].ToString();
                    this.termsId = dbManager.DataReader["TermsCondtions_Id"].ToString();
                    this.PREPAREDBY = dbManager.DataReader["PreparedBy"].ToString();
                    this.APPROVEDBY = dbManager.DataReader["ApprovedBy"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();
                    this.ProjectCode = dbManager.DataReader["ProjectCode"].ToString();


                    this.AlumilSystem = dbManager.DataReader["AlumilSystem"].ToString();
                    this.Windowcolor = dbManager.DataReader["WindowColor"].ToString();
                    this.sohardwarecolor = dbManager.DataReader["HardwareColor"].ToString();
                    this.sototalarea = dbManager.DataReader["TotalArea"].ToString();
                    this.totalqty = dbManager.DataReader["TotalQty"].ToString();
                    this.Installationdate = Convert.ToDateTime(dbManager.DataReader["InstallationCompletedate"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);



                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public int SalesOrderItem_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SalesOrder_Details] WHERE SalesOrderDet_Id='" + QuotationId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Code = dbManager.DataReader["Code"].ToString();
                    this.Width = dbManager.DataReader["Width"].ToString();
                    this.Height = dbManager.DataReader["Height"].ToString();
                    // this.StillHeight = dbManager.DataReader["StillHeight"].ToString();
                    this.Series = dbManager.DataReader["Series"].ToString();
                    this.Quantity = dbManager.DataReader["Quantity"].ToString();
                    this.Glass = dbManager.DataReader["Glass"].ToString();
                    this.Flyscreen = dbManager.DataReader["FlyScreen"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string SalesOrderApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [Sales_Order] SET ApprovedBy={0} WHERE SalesOrder_Id ={1}", this.APPROVEDBY, this.SOID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }


            public string MumbaiStockDetails_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [MumbaiStocksUpdates] SET MumbaiStock_Updatedon=getdate(),updatedby={0}", this.PREPAREDBY);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }


            public string SODocuments_Details_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [SalesOrder_Documents] SELECT ISNULL(MAX(SO_Doc_Id),0)+1,'{0}','{1}','{2}',{3} FROM [SalesOrder_Documents]", this.SODocdate, this.SODocRemarks, this.SODocuments, this.SOID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string SODocumentsDetails_Delete(string Eleid)
            {
                if (DeleteRecord("[SalesOrder_Documents]", "SO_Doc_Id", Eleid) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }

                return _returnStringMessage;
            }





            public string WindowsOperationAssign_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [SO_Window_Operations] SET priority='{0}',Cutting='{1}',Floding='{2}',Machining='{3}',Punching='{4}',Shearing='{5}',Stamping='{6}',Casting='{7}',Welding='{8}',Finishing='{9}',Start_Date='{10}',End_Date='{11}' WHERE Sow_OperationId={12}", this.Priority, this.Cutting, this.Floding, this.Machinging, this.Punching, this.Shearing, this.Stamping, this.Casting, this.Welding, this.Finishing, this.SowStratdate, this.SowEnddate, this.SowId);

                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }








            //public void SoBOM_Select(string QuotationId, GridView gv)
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();
            //    _commandText = string.Format("SELECT * FROM [SalesOrder_MaterialAnalysis] where [SalesOrder_MaterialAnalysis].SO_ID=" + QuotationId + "");
            //    dbManager.ExecuteReader(CommandType.Text, _commandText);

            //    DataTable SalesQuotationItems = new DataTable();
            //    DataColumn col = new DataColumn();

            //    col = new DataColumn("WindowCode");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Thickness");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Description");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Width");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Height");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Quantity");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Unit");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Area");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Weight");
            //    SalesQuotationItems.Columns.Add(col);


            //    while (dbManager.DataReader.Read())
            //    {
            //        DataRow dr = SalesQuotationItems.NewRow();
            //        dr["WindowCode"] = dbManager.DataReader["WindowCode"].ToString();
            //        dr["Thickness"] = dbManager.DataReader["Thickness"].ToString();
            //        dr["Description"] = dbManager.DataReader["Description"].ToString();
            //        dr["Width"] = dbManager.DataReader["Width"].ToString();
            //        dr["Height"] = dbManager.DataReader["Height"].ToString();
            //        dr["Quantity"] = dbManager.DataReader["Quantity"].ToString();
            //        dr["Unit"] = dbManager.DataReader["Unit"].ToString();
            //        dr["Area"] = dbManager.DataReader["Area"].ToString();
            //        dr["Weight"] = dbManager.DataReader["Weight"].ToString();

            //        SalesQuotationItems.Rows.Add(dr);
            //    }

            //    gv.DataSource = SalesQuotationItems;
            //    gv.DataBind();
            //}














            public void SoGlassEnquriy_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SalesOrder_GlassAnalysis] where [SalesOrder_GlassAnalysis].SO_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();

                col = new DataColumn("WindowCode");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Thickness");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Width");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Height");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Quantity");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Unit");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Area");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Weight");
                SalesQuotationItems.Columns.Add(col);


                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["WindowCode"] = dbManager.DataReader["WindowCode"].ToString();
                    dr["Thickness"] = dbManager.DataReader["Thickness"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["Height"] = dbManager.DataReader["Height"].ToString();
                    dr["Quantity"] = dbManager.DataReader["Quantity"].ToString();
                    dr["Unit"] = dbManager.DataReader["Unit"].ToString();
                    dr["Area"] = dbManager.DataReader["Area"].ToString();
                    dr["Weight"] = dbManager.DataReader["Weight"].ToString();

                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }


            public string GlassWindowcode, GlassThickness, GlassDescription, GlassWidth, Glassheight, GlassQuantity, GlassUnit, GlassArea, GlassWeight;

            public string SalesGlassEnquiryDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("INSERT INTO [SalesOrder_GlassAnalysis] SELECT ISNULL(MAX(SO_GlassAna_Id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}' FROM [SalesOrder_GlassAnalysis]", this.SOID, this.GlassWindowcode, this.GlassThickness, this.GlassDescription, this.GlassWidth, this.Glassheight, this.GlassQuantity, this.GlassUnit, this.GlassArea, this.GlassWeight);

                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int SalesGlassEnquiryDetails_Delete(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [SalesOrder_GlassAnalysis] WHERE SO_Id = {0}", QuotationId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }




            public void SalesOrderDetails_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SalesOrder_Details] where " +
                                               " [SalesOrder_Details].SalesOrder_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("CodeNo");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Width");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("height");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SillHeight");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Glass");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("FlyScreen");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("TotalAmount");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("DeliveryDate");
                SalesQuotationItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["CodeNo"] = dbManager.DataReader["Code"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["height"] = dbManager.DataReader["Height"].ToString();
                    dr["SillHeight"] = dbManager.DataReader["StillHeight"].ToString();
                    dr["Series"] = dbManager.DataReader["Series"].ToString();
                    dr["Qty"] = dbManager.DataReader["Quantity"].ToString();
                    dr["Glass"] = dbManager.DataReader["Glass"].ToString();
                    dr["FlyScreen"] = dbManager.DataReader["FlyScreen"].ToString();
                    dr["Amount"] = dbManager.DataReader["Amount"].ToString();
                    dr["TotalAmount"] = dbManager.DataReader["Total_Amount"].ToString();

                    dr["DeliveryDate"] = Convert.ToDateTime(dbManager.DataReader["Delivery_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }

            //public void SalesOrder_Select(string QuotationId, GridView gv)
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();
            //    _commandText = string.Format("SELECT * FROM [SalesOrder_Details],[Material_Master] where SalesOrder_Details.Material_Id=[Material_Master].Material_Id AND " +
            //                                   "[SalesOrder_Details].SalesOrder_Id=" + QuotationId + "");
            //    dbManager.ExecuteReader(CommandType.Text, _commandText);

            //    DataTable SalesQuotationItems = new DataTable();
            //    DataColumn col = new DataColumn();
            //    col = new DataColumn("Series");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Description");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Glass");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Mesh");
            //    SalesQuotationItems.Columns.Add(col);

            //    col = new DataColumn("Width");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Height");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Qty");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Areasq");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("SeriesID");
            //    SalesQuotationItems.Columns.Add(col);

            //    col = new DataColumn("Amount");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Id");
            //    SalesQuotationItems.Columns.Add(col);

            //    while (dbManager.DataReader.Read())
            //    {
            //        DataRow dr = SalesQuotationItems.NewRow();
            //        dr["Series"] = dbManager.DataReader["Material_Code"].ToString();
            //        dr["Description"] = dbManager.DataReader["Description"].ToString();
            //        dr["Mesh"] = dbManager.DataReader["Mesh"].ToString();
            //        dr["Glass"] = dbManager.DataReader["Glass"].ToString();
            //        dr["Width"] = dbManager.DataReader["Width"].ToString();
            //        dr["Height"] = dbManager.DataReader["Height"].ToString();
            //        dr["Qty"] = dbManager.DataReader["Qty"].ToString();
            //        dr["Areasq"] = dbManager.DataReader["AreaSqMt"].ToString();
            //        dr["SeriesID"] = dbManager.DataReader["Material_Id"].ToString();
            //        dr["Amount"] = dbManager.DataReader["Amount"].ToString();
            //        dr["Id"] = dbManager.DataReader["SalesOrderDet_Id"].ToString();
            //        SalesQuotationItems.Rows.Add(dr);
            //    }

            //    gv.DataSource = SalesQuotationItems;
            //    gv.DataBind();
            //}


            /// <summary>
            /// Sales order New Changed
            /// </summary>
            /// <param name="ControlForBind"></param>

            public void SalesOrderDetailsNew_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SalesOrder_Details] where " +
                                               " [SalesOrder_Details].SalesOrder_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("CodeNo");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Width");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("height");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Glass");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Mesh");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ProfileColor");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("HardwareColor");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("TotalArea");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("TotalAmount");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ItemDeliverydate");
                SalesQuotationItems.Columns.Add(col);
                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["CodeNo"] = dbManager.DataReader["Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Series"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["height"] = dbManager.DataReader["Height"].ToString();
                    dr["Qty"] = dbManager.DataReader["Quantity"].ToString();
                    dr["Glass"] = dbManager.DataReader["Glass"].ToString();
                    dr["Mesh"] = dbManager.DataReader["FlyScreen"].ToString();
                    dr["ProfileColor"] = dbManager.DataReader["ProfileColor"].ToString();
                    dr["HardwareColor"] = dbManager.DataReader["HardwareColor"].ToString();
                    dr["TotalArea"] = dbManager.DataReader["TotalArea"].ToString();
                    dr["TotalAmount"] = dbManager.DataReader["TotalAmount"].ToString();
                    dr["ItemDeliverydate"] = Convert.ToDateTime(dbManager.DataReader["Delivery_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }

            public static void SalesOrder_SelectNA(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT SalesOrder_Id,ProjectCode+'('+CUST_UNIT_NAME+')' as SoNo FROM [Sales_Order],Customer_Units where [Sales_Order].CustSiteId = Customer_Units.CUST_UNIT_ID  ORDER BY SalesOrder_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    SODropDownListBind(ControlForBind as DropDownList, "SoNo", "SalesOrder_Id");
                }
            }

            public static void SalesOrder_SelectNAp(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT SalesOrder_Id,ProjectCode as SoNo FROM [Sales_Order],Customer_Units where [Sales_Order].CustSiteId = Customer_Units.CUST_UNIT_ID  ORDER BY SalesOrder_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    SODropDownListBind(ControlForBind as DropDownList, "SoNo", "SalesOrder_Id");
                }
            }
            public static void SalesOrder_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT SalesOrder_Id,ProjectCode+'('+CUST_UNIT_NAME+')' as SoNo FROM [Sales_Order],Customer_Units where [Sales_Order].CustSiteId = Customer_Units.CUST_UNIT_ID  ORDER BY SalesOrder_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "SoNo", "SalesOrder_Id");
                }
            }



            public static void SalesOrder_Selectforblock(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT SalesOrder_Id,ProjectCode+'('+CUST_UNIT_NAME+')' as SoNo FROM [Sales_Order],Customer_Units where [Sales_Order].CustSiteId = Customer_Units.CUST_UNIT_ID and Status != 'Completed'  ORDER BY SalesOrder_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "SoNo", "SalesOrder_Id");
                }
            }











            public static void SalesOrderProjectcode_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT SalesOrder_Id,ProjectCode+'('+CUST_UNIT_NAME+')' as SoNo,ProjectCode FROM [Sales_Order],Customer_Units where [Sales_Order].CustSiteId = Customer_Units.CUST_UNIT_ID  ORDER BY SalesOrder_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "ProjectCode", "SalesOrder_Id");
                }
            }






            public static void SalesOrderItemWS_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SalesOrder_Details]  ORDER BY SalesOrder_Id ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Code", "SalesOrderDet_Id");
                }
            }

            public static void SalesOrderItem_Select(Control ControlForBind, string Soid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SalesOrder_Details] where SalesOrder_Id = '" + Soid + "' and BOM_Status != 'Yes'  ORDER BY SalesOrder_Id ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Code", "SalesOrderDet_Id");
                }
            }

            public static void SalesOrderItemBomStatus_Select(Control ControlForBind, string Soid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SalesOrder_Details] where SalesOrder_Id = '" + Soid + "' and BOM_Status = 'Yes'  ORDER BY SalesOrder_Id ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Code", "SalesOrderDet_Id");
                }
            }
        }

        //Methods for Delivery Challan
        public class DeliveryChallan
        {
            public string DcId, DcNo, DcDATE, Transportid, Lrno, Lrdate, Soid, PreparedBy, Approvedby, Custid, SiteId;

            public string DcDetId, Matid, Description, Mesh, Glass, Width, Height, Qty, Pickupid, Remarks;

            public DeliveryChallan()
            {
            }

            public static string DeliveryChallan_AutoGenCode()
            {
                return AutoGenMaxNo("Delivery_Challan_Master", "Dc_No");
            }

            public string DeliveryChallan_Save()
            {
                this.DcId = AutoGenMaxId("[Delivery_Challan_Master]", "Dc_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Delivery_Challan_Master] SELECT ISNULL(MAX(Dc_Id),0)+1,'{0}','{1}',{2},'{3}','{4}',{5},{6},{7},{8},{9} from Delivery_Challan_Master", this.DcNo, this.DcDATE, this.Transportid, this.Lrno, this.Lrdate, this.Soid, this.PreparedBy, this.Approvedby, this.Custid, this.SiteId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string DeliveryChallan_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Delivery_Challan_Master] SET Dc_Date='{0}',Transport_id={1},Lr_No='{2}',Lr_Date='{3}',So_Id={4},Preparedby={5},ApprovedBy={6},Cust_Id={7},Unit_Id={8} WHERE Dc_Id ={9}", this.DcDATE, this.Transportid, this.Lrno, this.Lrdate, this.Soid, this.PreparedBy, this.Approvedby, this.Custid, this.SiteId, this.DcId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string DeliveryChallan_Delete(string SOID)
            {
                if (DeleteRecord("[Delivery_Challan_Details]", "Dc_Id", SOID) == true)
                {
                    if (DeleteRecord("[Delivery_Challan_Master]", "Dc_Id", SOID) == true)
                    {
                        // SM.CommitTransaction();
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        //  SM.RollBackTransaction();
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public string DeliveryChallanDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Delivery_Challan_Details] SELECT ISNULL(MAX(Dc_Det_Id),0)+1,{0},{1},'{2}','{3}','{4}',{5},{6},{7},{8},'{9}' FROM [Delivery_Challan_Details]", this.DcId, this.Matid, this.Description, this.Mesh, this.Glass, this.Width, this.Height, this.Qty, this.Pickupid, this.Remarks);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int DeliveryChallanDetails_Delete(string SOid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Delivery_Challan_Details] WHERE Dc_Id = {0}", SOid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int DeliveryChallan_Select(string Dcid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Delivery_Challan_Master] WHERE Delivery_Challan_Master.Dc_Id='" + Dcid + "' ORDER BY Delivery_Challan_Master.Dc_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.DcId = dbManager.DataReader["Dc_Id"].ToString();
                    this.DcNo = dbManager.DataReader["Dc_No"].ToString();
                    this.DcDATE = Convert.ToDateTime(dbManager.DataReader["Dc_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Transportid = dbManager.DataReader["Transport_id"].ToString();
                    this.Lrdate = Convert.ToDateTime(dbManager.DataReader["Lr_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Lrno = dbManager.DataReader["Lr_No"].ToString();
                    this.Soid = dbManager.DataReader["So_Id"].ToString();
                    this.PreparedBy = dbManager.DataReader["Preparedby"].ToString();
                    this.SiteId = dbManager.DataReader["Unit_Id"].ToString();
                    this.Custid = dbManager.DataReader["Cust_Id"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string DeliveryChallanApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [Delivery_Challan_Master] SET ApprovedBy={0} WHERE Dc_Id ={1}", this.Approvedby, this.DcId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }

            public void DeliveryChallan_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Delivery_Challan_Details],[Material_Master],StorageLocation_Master where Delivery_Challan_Details.Mat_Id=[Material_Master].Material_Id AND " +
                                               "[Delivery_Challan_Details].Pickup_Id=[StorageLocation_Master].StorageLoacation_Id  AND [Delivery_Challan_Details].Dc_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Glass");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Mesh");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Width");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Height");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Location");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("LocationId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SeriesID");
                SalesQuotationItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["Series"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Code"].ToString();
                    dr["Mesh"] = dbManager.DataReader["Mesh"].ToString();

                    dr["Glass"] = dbManager.DataReader["Glass"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["Height"] = dbManager.DataReader["Height"].ToString();
                    dr["Qty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Location"] = dbManager.DataReader["StorageLocation_Name"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["LocationId"] = dbManager.DataReader["Pickup_Id"].ToString();
                    dr["SeriesID"] = dbManager.DataReader["Material_Id"].ToString();

                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }

            public static void DeliveryChallan_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Delivery_Challan_Master] ORDER BY Dc_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Dc_No", "Dc_Id");
                }
            }
        }

        //Methods for SalesInvoice
        public class SalesInvoice
        {
            public string SIId, SINo, SIdate, Duedate, Soid, PaymenttermsId, Remarks, Grandtotal, BalanceDue, Preparedby, Approvedby, Discount, Tax, CustId, UnitId;

            public string SIDetId, Matid, Description, Mesh, Glass, Width, Height, Qty, Areasqmt, Amount;

            public string Prid, Prno, Prdate, Pcustid, PUnitid, PSiid, Psiamount, amountreceived, paymodetype, Status;

            public SalesInvoice()
            {
            }

            public static string SalesInvoice_AutoGenCode()
            {
                return AutoGenMaxNo("Sales_Invoice", "Invoice_No");
            }

            public static string Prno_AutoGenCode()
            {
                return AutoGenMaxNo("Payments_Received", "PR_No");
            }

            public string SalesInvoice_Save()
            {
                this.SIId = AutoGenMaxId("[Sales_Invoice]", "Invoice_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Sales_Invoice] SELECT ISNULL(MAX(Invoice_Id),0)+1,'{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}',{8},{9},'{10}','{11}',{12},{13} from Sales_Invoice", this.SINo, this.SIdate, this.Duedate, this.Soid, this.PaymenttermsId, this.Remarks, this.Grandtotal, this.BalanceDue, this.Preparedby, this.Approvedby, this.Discount, this.Tax, this.CustId, this.UnitId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesInvoice_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Sales_Invoice] SET Invoice_Date='{0}',Invoice_DueDate='{1}',So_Id={2},PaymentTerms_Id={3},Remarks='{4}',GrandTotal='{5}',BalanceDue='{6}',PreparedBy={7},ApprovedBy={8},Discount='{9}',Tax='{10}',CustId={11},UnitId={12} WHERE Invoice_Id = {13}", this.SIdate, this.Duedate, this.Soid, this.PaymenttermsId, this.Remarks, this.Grandtotal, this.BalanceDue, this.Preparedby, this.Approvedby, this.Discount, this.Tax, this.CustId, this.UnitId, this.SIId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesInvoice_Delete(string SOID)
            {
                if (DeleteRecord("[Sales_Invoice_Details]", "Invoice_Id", SOID) == true)
                {
                    if (DeleteRecord("[Sales_Invoice]", "Invoice_Id", SOID) == true)
                    {
                        // SM.CommitTransaction();
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        //  SM.RollBackTransaction();
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public string SalesInvoiceDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Sales_Invoice_Details] SELECT ISNULL(MAX(InvoiceDet_Id),0)+1,{0},{1},'{2}','{3}','{4}',{5},{6},{7},'{8}','{9}' FROM [Sales_Invoice_Details]", this.SIId, this.Matid, this.Description, this.Mesh, this.Glass, this.Width, this.Height, this.Qty, this.Areasqmt, this.Amount);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int SalesInvoiceDetails_Delete(string SOid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Sales_Invoice_Details] WHERE Invoice_Id = {0}", SOid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public string CustomerName, UnitName, CustMobileno, UnitLocation;

            public int SalesInvoiceCU_Select(string Dcid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Sales_Invoice],Customer_Master,Customer_Units WHERE Sales_Invoice.CustId = Customer_Master.CUST_ID and Sales_Invoice.UnitId = Customer_Units.CUST_UNIT_ID and Sales_Invoice.Invoice_Id='" + Dcid + "' ORDER BY Sales_Invoice.Invoice_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SIId = dbManager.DataReader["Invoice_Id"].ToString();
                    this.SINo = dbManager.DataReader["Invoice_No"].ToString();
                    this.SIdate = Convert.ToDateTime(dbManager.DataReader["Invoice_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Soid = dbManager.DataReader["So_Id"].ToString();
                    this.Duedate = Convert.ToDateTime(dbManager.DataReader["Invoice_DueDate"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.PaymenttermsId = dbManager.DataReader["PaymentTerms_Id"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Grandtotal = dbManager.DataReader["GrandTotal"].ToString();
                    this.BalanceDue = dbManager.DataReader["BalanceDue"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();

                    this.Discount = dbManager.DataReader["Discount"].ToString();
                    this.Tax = dbManager.DataReader["Tax"].ToString();

                    this.CustId = dbManager.DataReader["CustId"].ToString();
                    this.UnitId = dbManager.DataReader["UnitId"].ToString();
                    this.CustomerName = dbManager.DataReader["CUST_NAME"].ToString();
                    this.CustMobileno = dbManager.DataReader["CUST_MOBILE"].ToString();
                    this.UnitName = dbManager.DataReader["CUST_UNIT_NAME"].ToString();
                    this.UnitLocation = dbManager.DataReader["CUST_UNIT_ADDRESS"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public int SalesInvoice_Select(string Dcid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Sales_Invoice] WHERE Sales_Invoice.Invoice_Id='" + Dcid + "' ORDER BY Sales_Invoice.Invoice_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SIId = dbManager.DataReader["Invoice_Id"].ToString();
                    this.SINo = dbManager.DataReader["Invoice_No"].ToString();
                    this.SIdate = Convert.ToDateTime(dbManager.DataReader["Invoice_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Soid = dbManager.DataReader["So_Id"].ToString();
                    this.Duedate = Convert.ToDateTime(dbManager.DataReader["Invoice_DueDate"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.PaymenttermsId = dbManager.DataReader["PaymentTerms_Id"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Grandtotal = dbManager.DataReader["GrandTotal"].ToString();
                    this.BalanceDue = dbManager.DataReader["BalanceDue"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();

                    this.Discount = dbManager.DataReader["Discount"].ToString();
                    this.Tax = dbManager.DataReader["Tax"].ToString();

                    this.CustId = dbManager.DataReader["CustId"].ToString();
                    this.UnitId = dbManager.DataReader["UnitId"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string SalesInvoiceApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [Sales_Invoice] SET ApprovedBy={0} WHERE Invoice_Id ={1}", this.Approvedby, this.SIId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }

            public void SalesInvoice_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Sales_Invoice_Details],[Material_Master] where Sales_Invoice_Details.Material_Id = [Material_Master].Material_Id AND " +
                                               " [Sales_Invoice_Details].Invoice_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Glass");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Mesh");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Width");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Height");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Areasq");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SeriesID");
                SalesQuotationItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["Series"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Mesh"] = dbManager.DataReader["Mesh"].ToString();
                    dr["Glass"] = dbManager.DataReader["Glass"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["Height"] = dbManager.DataReader["Height"].ToString();
                    dr["Qty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Areasq"] = dbManager.DataReader["AreaSqMt"].ToString();
                    dr["Amount"] = dbManager.DataReader["Amount"].ToString();
                    dr["SeriesID"] = dbManager.DataReader["Material_Id"].ToString();

                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }

            public static void SalesInvoice_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Sales_Invoice] ORDER BY Invoice_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Invoice_No", "Invoice_Id");
                }
            }

            public string PaymentReceived_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Payments_Received] SELECT ISNULL(MAX(PR_Id),0)+1,'{0}','{1}',{2},'{3}','{4}','{5}','{6}' FROM [Payments_Received]", this.Prno, this.Prdate, this.PSiid, this.Psiamount, this.amountreceived, this.paymodetype, this.Status);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _commandText = string.Format("UPDATE [Sales_Invoice] SET BalanceDue = {1}-{0} WHERE Invoice_Id ={2}", this.amountreceived, this.BalanceDue, this.PSiid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }
        }

        //Testing

        public class test
        {
            public string id, name, add;

            public test()
            {
            }

            public string test_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //  _commandText = string.Format("INSERT INTO [SalesEnquiry_Master] SELECT ISNULL(MAX(ENQ_ID),0)+1,'{0}','{1}',{2},{3},'{4}','{5}','{6}','{7}',{8},'{9}',{10},{11},{12},'{13}','{14}','{15}','{16}','{17}',{18},{19},{20},{21},'{22}','{23}' from SalesEnquiry_Master", this.EnqNo, this.EnqDate, this.CustId, this.UnitId, this.GlassSpecification, this.GlassReceiveddate, this.Glassthick, this.GlassRemarks, this.FinishColor, this.FinishReceiveddate, this.FinishProfile, this.FinishRemarks, this.ElevationReceiveddate, this.Elevationremarks, this.elevationDocuments, this.floorplanreceiveddate, this.floorplanremarks, this.floorplandocuments, this.salesinchargeid, this.designincargeid, this.preparedby, this.approvedby, this.revisedkey, this.status);
                _commandText = string.Format("INSERT INTO [Test] SELECT ISNULL(MAX(id),0)+1,'{0}','{1}'  from Test", this.name, this.add);

                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }
        }

        //mETHODS FOR sALES ENQUIRY

        public class SalesEnquiry
        {
            public string Enqid, EnqNo, EnqDate, CustId, UnitId, GlassSpecification, GlassReceiveddate, Glassthick, GlassRemarks, FinishColor, FinishReceiveddate, FinishProfile, FinishRemarks, ElevationReceiveddate, Elevationremarks, elevationDocuments, floorplanreceiveddate, floorplanremarks, floorplandocuments, salesinchargeid, designincargeid, preparedby, approvedby, revisedkey, status;

            public string Enqdetid, Codes, Width, Height, SillHeight, Qty, Glass, Flyscreen, ProfileFinish, Series;

            public string Specificaitons;

            public string NextContactById, NextContactDate, ToDiscuss;

            public string DetDescription, DetLocation, DetTotalArea, DetTotalAmount;

            public string Designstatus, estimationinchargeid, estimationStatus;

            public string productrequried, glassspecifications, glassthickness, glasscolorcode, powercoating, anodizing, woodeffect, archidrawingsattach, sitephotoattached;

            public string Archid, Source, Priority, Segment;

            public SalesEnquiry()
            {
            }

            public static string SalesEnquiry_AutoGenCode()
            {
                return AutoGenMaxNo("SalesEnquiry_Master", "ENQ_NO");
            }

            public string SalesEnquiry_Save()
            {
                this.revisedkey = "";
                this.Enqid = AutoGenMaxId("[SalesEnquiry_Master]", "ENQ_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //  _commandText = string.Format("INSERT INTO [SalesEnquiry_Master] SELECT ISNULL(MAX(ENQ_ID),0)+1,'{0}','{1}',{2},{3},'{4}','{5}','{6}','{7}',{8},'{9}',{10},{11},{12},'{13}','{14}','{15}','{16}','{17}',{18},{19},{20},{21},'{22}','{23}' from SalesEnquiry_Master", this.EnqNo, this.EnqDate, this.CustId, this.UnitId, this.GlassSpecification, this.GlassReceiveddate, this.Glassthick, this.GlassRemarks, this.FinishColor, this.FinishReceiveddate, this.FinishProfile, this.FinishRemarks, this.ElevationReceiveddate, this.Elevationremarks, this.elevationDocuments, this.floorplanreceiveddate, this.floorplanremarks, this.floorplandocuments, this.salesinchargeid, this.designincargeid, this.preparedby, this.approvedby, this.revisedkey, this.status);
                _commandText = string.Format("INSERT INTO [SalesEnquiry_Master] SELECT ISNULL(MAX(ENQ_ID),0)+1,'{0}','{1}',{2},{3},{4},{5},{6},{7},'{8}','{9}',{10},'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}' ,{23},'{24}','{25}',getdate(),{26},'{27}','{28}','{29}'  from SalesEnquiry_Master", this.EnqNo, this.EnqDate, this.CustId, this.UnitId, this.salesinchargeid, this.designincargeid, this.preparedby, this.approvedby, this.revisedkey, this.status, this.NextContactById, this.NextContactDate, this.ToDiscuss, this.Specificaitons, this.productrequried, this.glassspecifications, this.glassthickness, this.glasscolorcode, this.powercoating, this.anodizing, this.woodeffect, this.archidrawingsattach, this.sitephotoattached, this.estimationinchargeid, this.estimationStatus, this.Designstatus, this.Archid, this.Source, this.Priority, this.Segment);

                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesEnquiryRevise_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(REPLACE(REVISEDKEY,'R','')),0)+1 FROM SalesEnquiry_Master WHERE ENQ_NO LIKE '" + this.EnqNo + "%'").ToString());
                this.revisedkey = "R" + _returnIntValue.ToString();

                //SalesQuotationStatus_Update(SMStatus.Revised, this.QuotId);
                //this.status = "Revised";
                string HAI = "Close";
                SalesEnquriyStatus_Update(HAI, this.Enqid);

                this.Enqid = AutoGenMaxId("[SalesEnquiry_Master]", "ENQ_ID");

                //  _commandText = string.Format("INSERT INTO [SalesEnquiry_Master] SELECT ISNULL(MAX(ENQ_ID),0)+1,'{0}','{1}',{2},{3},'{4}','{5}','{6}','{7}',{8},'{9}',{10},{11},{12},'{13}','{14}','{15}','{16}','{17}',{18},{19},{20},{21},'{22}','{23}' from SalesEnquiry_Master", this.EnqNo, this.EnqDate, this.CustId, this.UnitId, this.GlassSpecification, this.GlassReceiveddate, this.Glassthick, this.GlassRemarks, this.FinishColor, this.FinishReceiveddate, this.FinishProfile, this.FinishRemarks, this.ElevationReceiveddate, this.Elevationremarks, this.elevationDocuments, this.floorplanreceiveddate, this.floorplanremarks, this.floorplandocuments, this.salesinchargeid, this.designincargeid, this.preparedby, this.approvedby, this.revisedkey, this.status);
                _commandText = string.Format("INSERT INTO [SalesEnquiry_Master] SELECT ISNULL(MAX(ENQ_ID),0)+1,'{0}','{1}',{2},{3},{4},{5},{6},{7},'{8}','{9}',{10},'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}' ,{23},'{24}','{25}',getdate(),{26},'{27}','{28}','{29}'  from SalesEnquiry_Master", this.EnqNo, this.EnqDate, this.CustId, this.UnitId, this.salesinchargeid, this.designincargeid, this.preparedby, this.approvedby, this.revisedkey, this.status, this.NextContactById, this.NextContactDate, this.ToDiscuss, this.Specificaitons, this.productrequried, this.glassspecifications, this.glassthickness, this.glasscolorcode, this.powercoating, this.anodizing, this.woodeffect, this.archidrawingsattach, this.sitephotoattached, this.estimationinchargeid, this.estimationStatus, this.Designstatus, this.Archid, this.Source, this.Priority, this.Segment);

                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Revised Successfully";
                }
                return _returnStringMessage;
            }
            public static string SalesEnquriyStatus_Update(string Status, string QuotId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [SalesEnquiry_Master] SET STATUS='{0}' WHERE ENQ_ID='{1}'", Status, QuotId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }


            public string SalesEnquirySpecifications_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [SalesEnquiry_Master] SET SPECIFICATIONS='{0}' WHERE ENQ_ID={1}", this.Specificaitons, this.Enqid);

                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesEnquiry_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //  _commandText = string.Format("UPDATE [SalesEnquiry_Master] SET ENQ_DATE='{0}',CUST_ID={1},UNIT_ID={2},GLASS_SPECIFICATIONS='{3}',GLASS_RECEIVEDDATE='{4}',GLASS_THICK='{5}',GLASS_REMARKS='{6}',FINISH_COLOR='{7}',FINISH_RECEIVEDDATE='{8}',FINISH_PROFILE='{9}',FINISH_REMARKS='{10}',ELEVATION_RECEIVEDDATE='{11}',ELEVATION_REMARKS='{12}',ELEVATION_DOCUMENTS='{13}',FLOORPLAN_RECEIVEDDATE='{14}',FLOORPLAN_REMARKS='{15}',FLOORPLAN_DOCUMENTS='{16}',SLAESINCHARGE_ID={17},DESIGNINCHARGE_ID={18},PREPAREDBY={19},APPROVEDBY={20},REVISEDKEY='{21}',STATUS='{22}' WHERE ENQ_ID={23}", this.EnqDate, this.CustId, this.UnitId, this.GlassSpecification, this.GlassReceiveddate, this.Glassthick, this.GlassRemarks, this.FinishColor, this.FinishReceiveddate, this.FinishProfile, this.FinishRemarks, this.ElevationReceiveddate, this.Elevationremarks, this.elevationDocuments, this.floorplanreceiveddate, this.floorplanremarks, this.floorplandocuments, this.salesinchargeid, this.designincargeid, this.preparedby, this.approvedby, this.revisedkey, this.status,this.Enqid);
                //_commandText = string.Format("UPDATE [SalesEnquiry_Master] SET ENQ_DATE='{0}',CUST_ID={1},UNIT_ID={2},SLAESINCHARGE_ID={3},DESIGNINCHARGE_ID={4},PREPAREDBY={5},APPROVEDBY={6},REVISEDKEY='{7}',STATUS='{8}',CONTACTBY_ID={9},CONTACT_DATE='{10}',TODISCUSS='{11}',PRODUCT_REQURIED='{12}',GLASSSPECIFICATION='{13}',GLASSTHICKNESS='{14}',GLASSCOLORCODE='{15}',POWERCOATING='{16}',ANODIZING='{17}',WOODEFFECT='{18}',ARCHIDRAWINGSATTACH='{19}',SITEPHOTOSATTACH='{20}',ArchId={21},Source='{22}',Priority='{23}',Segment='{24}' WHERE ENQ_ID={25}", this.EnqDate, this.CustId, this.UnitId, this.salesinchargeid, this.designincargeid, this.preparedby, this.approvedby, this.revisedkey, this.status, this.NextContactById, this.NextContactDate, this.ToDiscuss, this.productrequried, this.glassspecifications, this.glassthickness, this.glasscolorcode, this.powercoating, this.anodizing, this.woodeffect, this.archidrawingsattach, this.sitephotoattached,this.Archid,this.Source,this.Priority,this.Segment, this.Enqid);


                _commandText = string.Format("UPDATE [SalesEnquiry_Master] SET ENQ_DATE='{0}',CUST_ID={1},UNIT_ID={2},SLAESINCHARGE_ID={3},DESIGNINCHARGE_ID={4},PREPAREDBY={5},APPROVEDBY={6},CONTACTBY_ID={7},CONTACT_DATE='{8}',TODISCUSS='{9}',PRODUCT_REQURIED='{10}',GLASSSPECIFICATION='{11}',GLASSTHICKNESS='{12}',GLASSCOLORCODE='{13}',POWERCOATING='{14}',ANODIZING='{15}',WOODEFFECT='{16}',ARCHIDRAWINGSATTACH='{17}',SITEPHOTOSATTACH='{18}',ArchId={19},Source='{20}',Priority='{21}',Segment='{22}' WHERE ENQ_ID={23}", this.EnqDate, this.CustId, this.UnitId, this.salesinchargeid, this.designincargeid, this.preparedby, this.approvedby, this.NextContactById, this.NextContactDate, this.ToDiscuss, this.productrequried, this.glassspecifications, this.glassthickness, this.glasscolorcode, this.powercoating, this.anodizing, this.woodeffect, this.archidrawingsattach, this.sitephotoattached, this.Archid, this.Source, this.Priority, this.Segment, this.Enqid);



                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }







            public string AssignSalesEnquiry_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [SalesEnquiry_Master] SET DESIGNINCHARGE_ID='{0}',DesignerStatus='{1}',EstimatationInchargeId={2},EstimationStatus='{3}',STATUS='{4}' WHERE ENQ_ID={5}", this.designincargeid, this.Designstatus, this.estimationinchargeid, this.estimationStatus, this.status, this.Enqid);

                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }











            public string SalesEnquiry_Delete(string QuotationId)
            {
                SM.BeginTransaction();
                if (DeleteRecord("[SalesEnquiry_Details]", "ENQ_ID", QuotationId) == true)
                {
                    if (DeleteRecord("[SalesEnquiry_Master]", "ENQ_ID", QuotationId) == true)
                    {
                        SM.CommitTransaction();
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        SM.RollBackTransaction();
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                }
                else
                {
                    SM.RollBackTransaction();
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public string ElevationDetails_Delete(string Eleid)
            {
                if (DeleteRecord("[Enquiry_ElevationDetails]", "ELEVATION_ENQID", Eleid) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }

                return _returnStringMessage;
            }

            public string FloorPlanDetails_Delete(string Eleid)
            {
                if (DeleteRecord("[Enquiry_FloorPlanDetails]", "FLOORPLAN_ENQID", Eleid) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }

                return _returnStringMessage;
            }

            public string HardwareColor, InstallationCharges, SystemCost, Totalrmt, Totalrft, ElevationView;

            public string SalesEnquiryDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //    _commandText = string.Format("INSERT INTO [SalesEnquiry_Details] SELECT ISNULL(MAX(ENQ_DET_ID),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}',{17},{18},'{19}' FROM [SalesEnquiry_Details]", this.Enqid, this.Codes, this.Width, this.Height, this.SillHeight, this.Qty, this.Glass, this.Flyscreen, this.ProfileFinish, this.Series, this.DetDescription, this.DetLocation, this.DetTotalArea, this.DetTotalAmount, this.HardwareColor, this.InstallationCharges, this.SystemCost, this.Totalrmt, this.Totalrft, this.ElevationView);

                _commandText = string.Format("INSERT INTO [SalesEnquiry_Details] SELECT ISNULL(MAX(ENQ_DET_ID),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}' FROM [SalesEnquiry_Details]", this.Enqid, this.Codes, this.Width, this.Height, this.SillHeight, this.Qty, this.Glass, this.Flyscreen, this.ProfileFinish, this.Series, this.DetDescription, this.DetLocation, this.DetTotalArea, this.DetTotalAmount);

                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int SalesEnquiryDetails_Delete(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [SalesEnquiry_Details] WHERE ENQ_ID = {0}", QuotationId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public string SalesEnquiry_ElevationDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Enquiry_ElevationDetails] SELECT ISNULL(MAX(ELEVATION_ENQID),0)+1,'{0}','{1}','{2}',{3} FROM [Enquiry_ElevationDetails]", this.ElevationReceiveddate, this.Elevationremarks, this.elevationDocuments, this.Enqid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesEnquiry_FinishDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Enquiry_FinishDetails] SELECT ISNULL(MAX(FINISH_ENQID),0)+1,'{0}','{1}','{2}','{3}',{4} FROM [Enquiry_FinishDetails]", this.FinishColor, this.FinishReceiveddate, this.FinishProfile, this.FinishRemarks, this.Enqid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesEnquiry_FloorDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Enquiry_FloorPlanDetails] SELECT ISNULL(MAX(FLOORPLAN_ENQID),0)+1,'{0}','{1}','{2}',{3} FROM [Enquiry_FloorPlanDetails]", this.floorplanreceiveddate, this.floorplanremarks, this.floorplandocuments, this.Enqid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesEnquiry_GlassDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Enquiry_GlassDetails] SELECT ISNULL(MAX(ENQ_GLASSDETAILS_ID),0)+1,'{0}','{1}','{2}','{3}',{4} FROM [Enquiry_GlassDetails]", this.GlassSpecification, this.GlassReceiveddate, this.Glassthick, this.GlassRemarks, this.Enqid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int SalesEnquiry_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SalesEnquiry_Master] WHERE SalesEnquiry_Master.ENQ_ID='" + QuotationId + "' ORDER BY [SalesEnquiry_Master].ENQ_ID DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Enqid = dbManager.DataReader["ENQ_ID"].ToString();
                    this.EnqNo = dbManager.DataReader["ENQ_NO"].ToString();
                    this.EnqDate = Convert.ToDateTime(dbManager.DataReader["ENQ_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    // this.QuotDate = dbManager.DataReader["Quotation_Date"].ToString();

                    this.CustId = dbManager.DataReader["CUST_ID"].ToString();
                    this.UnitId = dbManager.DataReader["UNIT_ID"].ToString();
                    //this.GlassSpecification = dbManager.DataReader["GLASS_SPECIFICATIONS"].ToString();
                    //this.GlassReceiveddate = Convert.ToDateTime(dbManager.DataReader["GLASS_RECEIVEDDATE"].ToString()).ToString("dd/MM/yyyy");
                    //this.Glassthick = dbManager.DataReader["GLASS_THICK"].ToString();
                    //this.GlassRemarks = dbManager.DataReader["GLASS_REMARKS"].ToString();
                    //this.FinishColor = dbManager.DataReader["FINISH_COLOR"].ToString();
                    //this.FinishReceiveddate = Convert.ToDateTime(dbManager.DataReader["FINISH_RECEIVEDDATE"].ToString()).ToString("dd/MM/yyyy");
                    //this.FinishProfile = dbManager.DataReader["FINISH_PROFILE"].ToString();
                    //this.FinishRemarks = dbManager.DataReader["FINISH_REMARKS"].ToString();
                    //this.ElevationReceiveddate = dbManager.DataReader["ELEVATION_RECEIVEDDATE"].ToString();
                    //this.Elevationremarks = dbManager.DataReader["ELEVATION_REMARKS"].ToString();
                    //this.elevationDocuments = dbManager.DataReader["ELEVATION_DOCUMENTS"].ToString();
                    //this.floorplanreceiveddate = dbManager.DataReader["FLOORPLAN_RECEIVEDDATE"].ToString();
                    //this.floorplanremarks = dbManager.DataReader["FLOORPLAN_REMARKS"].ToString();
                    //this.floorplandocuments = dbManager.DataReader["FLOORPLAN_DOCUMENTS"].ToString();
                    this.salesinchargeid = dbManager.DataReader["SLAESINCHARGE_ID"].ToString();
                    this.designincargeid = dbManager.DataReader["DESIGNINCHARGE_ID"].ToString();
                    this.preparedby = dbManager.DataReader["PREPAREDBY"].ToString();
                    this.approvedby = dbManager.DataReader["APPROVEDBY"].ToString();

                    this.status = dbManager.DataReader["STATUS"].ToString();
                    this.NextContactById = dbManager.DataReader["CONTACTBY_ID"].ToString();
                    this.NextContactDate = Convert.ToDateTime(dbManager.DataReader["CONTACT_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.ToDiscuss = dbManager.DataReader["TODISCUSS"].ToString();
                    this.Specificaitons = dbManager.DataReader["SPECIFICATIONS"].ToString();


                    this.productrequried = dbManager.DataReader["PRODUCT_REQURIED"].ToString();
                    this.glassspecifications = dbManager.DataReader["GLASSSPECIFICATION"].ToString();
                    this.glassthickness = dbManager.DataReader["GLASSTHICKNESS"].ToString();
                    this.glasscolorcode = dbManager.DataReader["GLASSCOLORCODE"].ToString();


                    this.powercoating = dbManager.DataReader["POWERCOATING"].ToString();
                    this.anodizing = dbManager.DataReader["ANODIZING"].ToString();
                    this.woodeffect = dbManager.DataReader["WOODEFFECT"].ToString();
                    this.archidrawingsattach = dbManager.DataReader["ARCHIDRAWINGSATTACH"].ToString();
                    this.sitephotoattached = dbManager.DataReader["SITEPHOTOSATTACH"].ToString();

                    this.Archid = dbManager.DataReader["ArchId"].ToString();

                    this.Segment = dbManager.DataReader["Segment"].ToString();
                    this.Source = dbManager.DataReader["Source"].ToString();


                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }




            public int SalesEnquiryUnit_Select(string ProjectId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SalesEnquiry_Master] WHERE SalesEnquiry_Master.UNIT_ID='" + ProjectId + "' ORDER BY [SalesEnquiry_Master].ENQ_ID DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Enqid = dbManager.DataReader["ENQ_ID"].ToString();
                    this.EnqNo = dbManager.DataReader["ENQ_NO"].ToString();
                    this.EnqDate = Convert.ToDateTime(dbManager.DataReader["ENQ_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    // this.QuotDate = dbManager.DataReader["Quotation_Date"].ToString();

                    this.CustId = dbManager.DataReader["CUST_ID"].ToString();
                    this.UnitId = dbManager.DataReader["UNIT_ID"].ToString();
                    //this.GlassSpecification = dbManager.DataReader["GLASS_SPECIFICATIONS"].ToString();
                    //this.GlassReceiveddate = Convert.ToDateTime(dbManager.DataReader["GLASS_RECEIVEDDATE"].ToString()).ToString("dd/MM/yyyy");
                    //this.Glassthick = dbManager.DataReader["GLASS_THICK"].ToString();
                    //this.GlassRemarks = dbManager.DataReader["GLASS_REMARKS"].ToString();
                    //this.FinishColor = dbManager.DataReader["FINISH_COLOR"].ToString();
                    //this.FinishReceiveddate = Convert.ToDateTime(dbManager.DataReader["FINISH_RECEIVEDDATE"].ToString()).ToString("dd/MM/yyyy");
                    //this.FinishProfile = dbManager.DataReader["FINISH_PROFILE"].ToString();
                    //this.FinishRemarks = dbManager.DataReader["FINISH_REMARKS"].ToString();
                    //this.ElevationReceiveddate = dbManager.DataReader["ELEVATION_RECEIVEDDATE"].ToString();
                    //this.Elevationremarks = dbManager.DataReader["ELEVATION_REMARKS"].ToString();
                    //this.elevationDocuments = dbManager.DataReader["ELEVATION_DOCUMENTS"].ToString();
                    //this.floorplanreceiveddate = dbManager.DataReader["FLOORPLAN_RECEIVEDDATE"].ToString();
                    //this.floorplanremarks = dbManager.DataReader["FLOORPLAN_REMARKS"].ToString();
                    //this.floorplandocuments = dbManager.DataReader["FLOORPLAN_DOCUMENTS"].ToString();
                    this.salesinchargeid = dbManager.DataReader["SLAESINCHARGE_ID"].ToString();
                    this.designincargeid = dbManager.DataReader["DESIGNINCHARGE_ID"].ToString();
                    this.preparedby = dbManager.DataReader["PREPAREDBY"].ToString();
                    this.approvedby = dbManager.DataReader["APPROVEDBY"].ToString();

                    this.status = dbManager.DataReader["STATUS"].ToString();
                    this.NextContactById = dbManager.DataReader["CONTACTBY_ID"].ToString();
                    this.NextContactDate = Convert.ToDateTime(dbManager.DataReader["CONTACT_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.ToDiscuss = dbManager.DataReader["TODISCUSS"].ToString();
                    this.Specificaitons = dbManager.DataReader["SPECIFICATIONS"].ToString();


                    this.productrequried = dbManager.DataReader["PRODUCT_REQURIED"].ToString();
                    this.glassspecifications = dbManager.DataReader["GLASSSPECIFICATION"].ToString();
                    this.glassthickness = dbManager.DataReader["GLASSTHICKNESS"].ToString();
                    this.glasscolorcode = dbManager.DataReader["GLASSCOLORCODE"].ToString();


                    this.powercoating = dbManager.DataReader["POWERCOATING"].ToString();
                    this.anodizing = dbManager.DataReader["ANODIZING"].ToString();
                    this.woodeffect = dbManager.DataReader["WOODEFFECT"].ToString();
                    this.archidrawingsattach = dbManager.DataReader["ARCHIDRAWINGSATTACH"].ToString();
                    this.sitephotoattached = dbManager.DataReader["SITEPHOTOSATTACH"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }









            public int GlassDetails_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Enquiry_GlassDetails] WHERE Enquiry_GlassDetails.ENQ_ID='" + QuotationId + "' ORDER BY [Enquiry_GlassDetails].ENQ_ID DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.GlassSpecification = dbManager.DataReader["GLASS_SPECIFICATIONS"].ToString();
                    this.Glassthick = dbManager.DataReader["GLASS_THICK"].ToString();
                    this.GlassReceiveddate = Convert.ToDateTime(dbManager.DataReader["GLASS_RECEIVEDDATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.GlassRemarks = dbManager.DataReader["GLASS_REMARKS"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public int FinishDetails_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Enquiry_FinishDetails] WHERE Enquiry_FinishDetails.ENQ_ID='" + QuotationId + "' ORDER BY [Enquiry_FinishDetails].ENQ_ID DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.FinishColor = dbManager.DataReader["FINISH_COLOR"].ToString();
                    this.FinishProfile = dbManager.DataReader["FINISH_PROFILE"].ToString();
                    this.FinishReceiveddate = Convert.ToDateTime(dbManager.DataReader["FINISH_RECEIVEDDATE"].ToString()).ToString("dd/MM/yyyy");
                    this.FinishRemarks = dbManager.DataReader["FINISH_REMARKS"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string FinishDetails_Update()
            {
                dbManager.Open();

                _commandText = string.Format("UPDATE [Enquiry_FinishDetails] SET FINISH_COLOR='{0}',FINISH_RECEIVEDDATE='{1}',FINISH_PROFILE='{2}',FINISH_REMARKS='{3}' WHERE ENQ_ID ={4}", this.FinishColor, this.FinishReceiveddate, this.FinishProfile, this.FinishRemarks, this.Enqid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }

                return _returnStringMessage;
            }

            public string GlassDetails_Update()
            {
                dbManager.Open();

                _commandText = string.Format("UPDATE [Enquiry_GlassDetails] SET GLASS_SPECIFICATIONS='{0}',GLASS_RECEIVEDDATE='{1}',GLASS_THICK='{2}',GLASS_REMARKS='{3}' WHERE ENQ_ID ={4}", this.GlassSpecification, this.GlassReceiveddate, this.Glassthick, this.GlassRemarks, this.Enqid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }

                return _returnStringMessage;
            }

            public string SalesEnquiryApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [SalesEnquiry_Master] SET APPROVEDBY={0} WHERE ENQ_ID ={1}", this.approvedby, this.Enqid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }

            public void SalesEnquiry_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SalesEnquiry_Details] where [SalesEnquiry_Details].ENQ_ID=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();

                col = new DataColumn("CodeNo");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Width");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("height");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SillHeight");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Glass");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("FlyScreen");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ProfileFinish");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("DESCRIPTION");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("LOCATION");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("TOTALAREA");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("TOTALAMOUNT");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("EnqDetId");
                SalesQuotationItems.Columns.Add(col);

                //col = new DataColumn("HardwareColor");
                //SalesQuotationItems.Columns.Add(col);
                //col = new DataColumn("InstallationCharges");
                //SalesQuotationItems.Columns.Add(col);
                //col = new DataColumn("SystemCost");
                //SalesQuotationItems.Columns.Add(col);
                //col = new DataColumn("TotalRmt");
                //SalesQuotationItems.Columns.Add(col);
                //col = new DataColumn("TotalRft");
                //SalesQuotationItems.Columns.Add(col);
                //col = new DataColumn("ElevationView");
                //SalesQuotationItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["CodeNo"] = dbManager.DataReader["CODES"].ToString();
                    dr["Width"] = dbManager.DataReader["WIDTH"].ToString();
                    dr["height"] = dbManager.DataReader["HEIGHT"].ToString();
                    dr["SillHeight"] = dbManager.DataReader["SILLHEIGHT"].ToString();
                    dr["Qty"] = dbManager.DataReader["QTY"].ToString();
                    dr["Glass"] = dbManager.DataReader["GLASS"].ToString();
                    dr["FlyScreen"] = dbManager.DataReader["FLYSCREEN"].ToString();
                    dr["ProfileFinish"] = dbManager.DataReader["PROFILEFINISH"].ToString();
                    dr["Series"] = dbManager.DataReader["SERIES"].ToString();

                    dr["DESCRIPTION"] = dbManager.DataReader["DESCRIPTION"].ToString();
                    dr["LOCATION"] = dbManager.DataReader["LOCATION"].ToString();
                    dr["TOTALAREA"] = dbManager.DataReader["TOTALAREA"].ToString();
                    dr["TOTALAMOUNT"] = dbManager.DataReader["TOTALAMOUNT"].ToString();

                    dr["EnqDetId"] = dbManager.DataReader["ENQ_DET_ID"].ToString();

                    //dr["HardwareColor"] = dbManager.DataReader["HARDWARECOLOR"].ToString();
                    //dr["InstallationCharges"] = dbManager.DataReader["INSTALLATIONCHARGES"].ToString();
                    //dr["SystemCost"] = dbManager.DataReader["SYSTEMCOST"].ToString();
                    //dr["TotalRmt"] = dbManager.DataReader["TOTALRMT"].ToString();
                    //dr["TotalRft"] = dbManager.DataReader["TOTALRFT"].ToString();
                    //dr["ElevationView"] = dbManager.DataReader["ELEVATIONVIEW"].ToString();

                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }

            //public void SalesEnquiry_Select(string QuotationId, GridView gv)
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();
            //    _commandText = string.Format("SELECT * FROM [SalesEnquiry_Details] where [SalesEnquiry_Details].ENQ_ID=" + QuotationId + "");
            //    dbManager.ExecuteReader(CommandType.Text, _commandText);

            //    DataTable SalesQuotationItems = new DataTable();
            //    DataColumn col = new DataColumn();

            //    col = new DataColumn("CodeNo");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Width");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("height");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("SillHeight");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Series");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Qty");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("Glass");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("FlyScreen");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("ProfileFinish");
            //    SalesQuotationItems.Columns.Add(col);

            //    col = new DataColumn("DESCRIPTION");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("LOCATION");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("TOTALAREA");
            //    SalesQuotationItems.Columns.Add(col);
            //    col = new DataColumn("TOTALAMOUNT");
            //    SalesQuotationItems.Columns.Add(col);

            //    col = new DataColumn("EnqDetId");
            //    SalesQuotationItems.Columns.Add(col);

            //    while (dbManager.DataReader.Read())
            //    {
            //        DataRow dr = SalesQuotationItems.NewRow();
            //        dr["CodeNo"] = dbManager.DataReader["CODES"].ToString();
            //        dr["Width"] = dbManager.DataReader["WIDTH"].ToString();
            //        dr["height"] = dbManager.DataReader["HEIGHT"].ToString();
            //        dr["SillHeight"] = dbManager.DataReader["SILLHEIGHT"].ToString();
            //        dr["Qty"] = dbManager.DataReader["QTY"].ToString();
            //        dr["Glass"] = dbManager.DataReader["GLASS"].ToString();
            //        dr["FlyScreen"] = dbManager.DataReader["FLYSCREEN"].ToString();
            //        dr["ProfileFinish"] = dbManager.DataReader["PROFILEFINISH"].ToString();
            //        dr["Series"] = dbManager.DataReader["SERIES"].ToString();

            //        dr["DESCRIPTION"] = dbManager.DataReader["DESCRIPTION"].ToString();
            //        dr["LOCATION"] = dbManager.DataReader["LOCATION"].ToString();
            //        dr["TOTALAREA"] = dbManager.DataReader["TOTALAREA"].ToString();
            //        dr["TOTALAMOUNT"] = dbManager.DataReader["TOTALAMOUNT"].ToString();

            //        dr["EnqDetId"] = dbManager.DataReader["ENQ_DET_ID"].ToString();

            //        SalesQuotationItems.Rows.Add(dr);
            //    }

            //    gv.DataSource = SalesQuotationItems;
            //    gv.DataBind();
            //}

            public static void SalesEnquiry_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //_commandText = string.Format("SELECT ENQ_ID,ENQ_NO+' '+REVISEDKEY AS ENQNO FROM [SalesEnquiry_Master] ORDER BY ENQ_ID");

                _commandText = string.Format("SELECT ENQ_ID,ENQ_NO+' '+REVISEDKEY+'('+CUST_UNIT_NAME+')' AS ENQNO FROM [SalesEnquiry_Master],Customer_Units WHERE [SalesEnquiry_Master].UNIT_ID = Customer_Units.CUST_UNIT_ID ORDER BY ENQ_ID DESC");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "ENQNO", "ENQ_ID");
                }
                //dbManager.Dispose();
            }
        }

        //Methods For Customer Master Form
        //public class CustomerMaster
        //{
        //    public string CustId, CustCode, RegId, RegName, CustName, CompName, ContactPerson, Phone, Mobile,  Fax, Email, PANNo, Gst, LocalSTNo, SplInsrs, Address, Website, CorpContactPerson, CorpPhone, CorpMobile, CorpEmail, CorpAddress, DesgId, CorpDesgId, CorpFax, IsNewOrExisting;   //Customer Master
        //    public string CustDetId, CustCorpContactPerson, CustCorpPhone, CustCorpMobile, CustCorpEmail, CustCorpAddress, CustCorpDesgId, CustCorpFax;
        //    public string CustUnitId, CustUnitName, CustUnitAddress, UnitNo;

        //    public string acopyid, adate,  credit, debit,naration,invocieno;

        //    public CustomerMaster()
        //    { }

        //    public static string CustomerMaster_AutoGenCode()
        //    {
        //        //string _codePrefix = CurrentFinancialYear() + " ";
        //        //if (dbManager.Transaction == null)
        //        //    dbManager.Open();
        //        //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(CONVERT(BIGINT,REPLACE(CUST_CODE,LEFT(CUST_CODE,5),''))),0)+1 FROM [YANTRA_CUSTOMER_MAST]").ToString());
        //        //return _codePrefix + _returnIntValue;

        //        return AutoGenMaxNo("YANTRA_CUSTOMER_MAST", "CUST_CODE");
        //    }
        //    public string Targetamount, DealersPolicy;
        //    public string CustomerMaster_Save()
        //    {
        //        this.CustCode = CustomerMaster_AutoGenCode();
        //        this.CustId = AutoGenMaxId("[YANTRA_CUSTOMER_MAST]", "CUST_ID");
        //        this.acopyid = AutoGenMaxId("[SalesAccount_Copy]","acopy_id");
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [YANTRA_CUSTOMER_MAST] VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',{14},{15},'{16}','{17}','{18}','{19}','{20}','{21}','{22}',{23},{24},'{25}','{26}','{27}','{28}')",
        //       this.CustId, this.CustCode, this.CustName, this.CompName, this.ContactPerson, this.Phone, this.Mobile, this.Fax, this.Email, this.Website, this.PANNo, this.ECCNo, this.CSTNo, this.LocalSTNo, this.RegId, this.IndTypeId, this.Address, this.SplInsrs, this.CorpContactPerson, this.CorpPhone, this.CorpMobile, this.CorpEmail, this.CorpAddress, this.DesgId, this.CorpDesgId, this.CorpFax, this.IsNewOrExisting, this.Targetamount, this.DealersPolicy);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

        //        _commandText = string.Format("INSERT INTO [SalesAccount_Copy] VALUES({0},{1},'{2}','{3}','{4}','{5}','{6}')",
        //     this.acopyid,this.CustId, this.debit, this.credit, this.naration, this.adate,this.invocieno);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string CustomerMaster_Update()
        //    {
        //        try
        //        {
        //            dbManager.Open();
        //            _commandText = string.Format("UPDATE [YANTRA_CUSTOMER_MAST] SET CUST_NAME='{0}',CUST_COMPANY_NAME='{1}',CUST_CONTACT_PERSON='{2}',CUST_PHONE='{3}',CUST_MOBILE='{4}',CUST_FAX='{5}',CUST_EMAIL='{6}',CUST_WEBSITE='{7}',CUST_PAN='{8}',CUST_ECC='{9}',CUST_CST='{10}',CUST_LOCAL_ST_NO='{11}',REG_ID='{12}',IND_TYPE_ID='{13}',CUST_ADDRESS='{14}',CUST_SPL_INSTRS='{15}',CUST_CORP_CONTACT_PERSON='{16}',CUST_CORP_PHONE='{17}',CUST_CORP_MOBILE='{18}',CUST_CORP_EMAIL='{19}',CUST_CORP_ADDRESS='{20}',CUST_DESG_ID='{21}',CUST_CORP_DESG_ID='{22}',CUST_CORP_FAX='{23}',ISNEWOREXISTING='{24}',TARGETAMOUNT='{25}',DEALERSPOLICY = '{26}' WHERE CUST_ID={27}", this.CustName, this.CompName, this.ContactPerson, this.Phone, this.Mobile, this.Fax, this.Email, this.Website, this.PANNo, this.ECCNo, this.CSTNo, this.LocalSTNo, this.RegId, this.IndTypeId, this.Address, this.SplInsrs, this.CorpContactPerson, this.CorpPhone, this.CorpMobile, this.CorpEmail, this.CorpAddress, this.DesgId, this.CorpDesgId, this.CorpFax, this.IsNewOrExisting, this.Targetamount, this.DealersPolicy, this.CustId);
        //            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //            _returnStringMessage = string.Empty;
        //            if (_returnIntValue < 0 || _returnIntValue == 0)
        //            {
        //                _returnStringMessage = "Some Data Missing.";
        //            }
        //            else if (_returnIntValue > 0)
        //            {
        //                _returnStringMessage = "Data Updated Successfully";
        //            }
        //            return _returnStringMessage;
        //        }
        //        catch(Exception ex)
        //        {
        //            return ex.Message;
        //        }
        //        finally
        //        {
        //            SM.Dispose();
        //        }
        //    }

        //    public string CustomerMaster_Delete()
        //    {
        //        SM.BeginTransaction();
        //        if (DeleteRecord("[YANTRA_CUSTOMER_DET]", "CUST_ID", this.CustId) == true)
        //        {
        //            if (DeleteRecord("[YANTRA_CUSTOMER_UNITS]", "CUST_ID", this.CustId) == true)
        //            {
        //                if (DeleteRecord("[YANTRA_CUSTOMER_MAST]", "CUST_ID", this.CustId) == true)
        //                {
        //                    SM.CommitTransaction();
        //                    _returnStringMessage = "Data Deleted Successfully";
        //                }
        //                else
        //                {
        //                    SM.RollBackTransaction();
        //                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
        //                }
        //            }
        //            else
        //            {
        //                SM.RollBackTransaction();
        //                _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
        //            }
        //        }
        //        else
        //        {
        //            SM.RollBackTransaction();
        //            _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public static void CustomerMaster_Select(Control ControlForBind)
        //    {
        //        dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_MAST] ORDER BY CUST_COMPANY_NAME");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "CUST_COMPANY_NAME", "CUST_ID");
        //        }
        //    }

        //    public int CustomerMaster_Select(string CustomerId)
        //    {
        //        dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_MAST],[YANTRA_LKUP_INDUSTRY_TYPE],[YANTRA_LKUP_REGION] WHERE " +
        //            //" [YANTRA_CUSTOMER_MAST].CUST_ID=[YANTRA_CUSTOMER_UNITS].CUST_ID AND " +
        //                        " [YANTRA_CUSTOMER_MAST].IND_TYPE_ID=[YANTRA_LKUP_INDUSTRY_TYPE].IND_TYPE_ID AND " +
        //                        " [YANTRA_CUSTOMER_MAST].REG_ID=[YANTRA_LKUP_REGION].REG_ID  AND [YANTRA_CUSTOMER_MAST].CUST_ID= " + CustomerId);
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.Address = dbManager.DataReader["CUST_ADDRESS"].ToString();
        //            this.CompName = dbManager.DataReader["CUST_COMPANY_NAME"].ToString();
        //            this.ContactPerson = dbManager.DataReader["CUST_CONTACT_PERSON"].ToString();
        //            this.CSTNo = dbManager.DataReader["CUST_CST"].ToString();
        //            this.CustCode = dbManager.DataReader["CUST_CODE"].ToString();
        //            this.CustName = dbManager.DataReader["CUST_NAME"].ToString();
        //            this.ECCNo = dbManager.DataReader["CUST_ECC"].ToString();
        //            this.Email = dbManager.DataReader["CUST_EMAIL"].ToString();
        //            this.Fax = dbManager.DataReader["CUST_FAX"].ToString();
        //            this.IndTypeId = dbManager.DataReader["IND_TYPE_ID"].ToString();
        //            this.IndType = dbManager.DataReader["IND_TYPE"].ToString();
        //            this.LocalSTNo = dbManager.DataReader["CUST_LOCAL_ST_NO"].ToString();
        //            this.Mobile = dbManager.DataReader["CUST_MOBILE"].ToString();
        //            this.PANNo = dbManager.DataReader["CUST_PAN"].ToString();
        //            this.Phone = dbManager.DataReader["CUST_PHONE"].ToString();
        //            this.RegId = dbManager.DataReader["REG_ID"].ToString();
        //            this.RegName = dbManager.DataReader["REG_NAME"].ToString();
        //            this.SplInsrs = dbManager.DataReader["CUST_SPL_INSTRS"].ToString();
        //            this.Website = dbManager.DataReader["CUST_WEBSITE"].ToString();
        //            this.CorpContactPerson = dbManager.DataReader["CUST_CORP_CONTACT_PERSON"].ToString();
        //            this.CorpPhone = dbManager.DataReader["CUST_CORP_PHONE"].ToString();
        //            this.CorpMobile = dbManager.DataReader["CUST_CORP_MOBILE"].ToString();
        //            this.CorpEmail = dbManager.DataReader["CUST_CORP_EMAIL"].ToString();
        //            this.CorpAddress = dbManager.DataReader["CUST_CORP_ADDRESS"].ToString();
        //            this.DesgId = dbManager.DataReader["CUST_DESG_ID"].ToString();
        //            this.CorpDesgId = dbManager.DataReader["CUST_CORP_DESG_ID"].ToString();
        //            this.CorpFax = dbManager.DataReader["CUST_CORP_FAX"].ToString();
        //            this.IsNewOrExisting = dbManager.DataReader["ISNEWOREXISTING"].ToString();
        //            this.Targetamount = dbManager.DataReader["TARGETAMOUNT"].ToString();
        //            this.DealersPolicy = dbManager.DataReader["DEALERSPOLICY"].ToString();

        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        return _returnIntValue;
        //    }

        //    public int CustomerMasterUnitsDetailsEnquiry_Select(string CustomerId)
        //    {
        //        dbManager.Open();
        //        _commandText = string.Format("SELECT [YANTRA_CUSTOMER_MAST].CUST_ID, [YANTRA_CUSTOMER_MAST].CUST_NAME,[YANTRA_CUSTOMER_MAST].CUST_COMPANY_NAME,[YANTRA_CUSTOMER_UNITS].*,[YANTRA_CUSTOMER_DET].*,[YANTRA_LKUP_REGION].* " +
        //                                                        " FROM [YANTRA_CUSTOMER_MAST],[YANTRA_LKUP_INDUSTRY_TYPE],[YANTRA_LKUP_REGION],[YANTRA_CUSTOMER_UNITS],[YANTRA_CUSTOMER_DET],[YANTRA_ENQ_MAST] WHERE " +
        //                                                        " [YANTRA_ENQ_MAST].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID AND  [YANTRA_ENQ_MAST].CUST_DET_ID=[YANTRA_CUSTOMER_DET].CUST_DET_ID AND [YANTRA_ENQ_MAST].CUST_UNIT_ID=[YANTRA_CUSTOMER_UNITS].CUST_UNIT_ID AND " +
        //                                                        " [YANTRA_CUSTOMER_MAST].IND_TYPE_ID=[YANTRA_LKUP_INDUSTRY_TYPE].IND_TYPE_ID AND  [YANTRA_CUSTOMER_MAST].REG_ID=[YANTRA_LKUP_REGION].REG_ID AND " +
        //                                                        " [YANTRA_CUSTOMER_MAST].CUST_ID= " + CustomerId);
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.CustId = dbManager.DataReader["CUST_ID"].ToString();
        //            this.CustName = dbManager.DataReader["CUST_NAME"].ToString();
        //            this.CompName = dbManager.DataReader["CUST_COMPANY_NAME"].ToString();
        //            this.Address = dbManager.DataReader["CUST_UNIT_ADDRESS"].ToString();
        //            this.Email = dbManager.DataReader["CUST_CORP_EMAIL"].ToString();
        //            this.RegName = dbManager.DataReader["REG_NAME"].ToString();
        //            this.Phone = dbManager.DataReader["CUST_CORP_PHONE"].ToString();
        //            this.Mobile = dbManager.DataReader["CUST_CORP_MOBILE"].ToString();
        //            this.CustUnitName = dbManager.DataReader["CUST_UNIT_NAME"].ToString();

        //            ////this.ContactPerson = dbManager.DataReader["CUST_CONTACT_PERSON"].ToString();
        //            ////this.Fax = dbManager.DataReader["CUST_FAX"].ToString();
        //            ////this.IndTypeId = dbManager.DataReader["IND_TYPE_ID"].ToString();
        //            ////this.IndType = dbManager.DataReader["IND_TYPE"].ToString();
        //            ////this.CorpContactPerson = dbManager.DataReader["CUST_CORP_CONTACT_PERSON"].ToString();
        //            ////this.CorpPhone = dbManager.DataReader["CUST_CORP_PHONE"].ToString();
        //            ////this.CorpMobile = dbManager.DataReader["CUST_CORP_MOBILE"].ToString();
        //            ////this.CorpEmail = dbManager.DataReader["CUST_CORP_EMAIL"].ToString();
        //            ////this.CorpAddress = dbManager.DataReader["CUST_CORP_ADDRESS"].ToString();
        //            ////this.CorpDesgId = dbManager.DataReader["CUST_CORP_DESG_ID"].ToString();
        //            ////this.CorpFax = dbManager.DataReader["CUST_CORP_FAX"].ToString();

        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        return _returnIntValue;
        //    }
        //    public int CustomerMasterUnitsDetailsEnquiry_Select1(string CustomerId, string Customerunit)
        //    {
        //        dbManager.Open();
        //        _commandText = string.Format("SELECT [YANTRA_CUSTOMER_MAST].CUST_NAME,[YANTRA_CUSTOMER_MAST].CUST_COMPANY_NAME,[YANTRA_CUSTOMER_UNITS].*,[YANTRA_CUSTOMER_DET].*,[YANTRA_LKUP_REGION].* " +
        //                                                        " FROM [YANTRA_CUSTOMER_MAST],[YANTRA_LKUP_INDUSTRY_TYPE],[YANTRA_LKUP_REGION],[YANTRA_CUSTOMER_UNITS],[YANTRA_CUSTOMER_DET],[YANTRA_ENQ_MAST] WHERE " +
        //                                                        " [YANTRA_ENQ_MAST].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID AND  [YANTRA_ENQ_MAST].CUST_DET_ID=[YANTRA_CUSTOMER_DET].CUST_DET_ID AND [YANTRA_ENQ_MAST].CUST_UNIT_ID=[YANTRA_CUSTOMER_UNITS].CUST_UNIT_ID AND " +
        //                                                        " [YANTRA_CUSTOMER_MAST].IND_TYPE_ID=[YANTRA_LKUP_INDUSTRY_TYPE].IND_TYPE_ID AND [YANTRA_CUSTOMER_MAST].REG_ID=[YANTRA_LKUP_REGION].REG_ID AND " +
        //                                                        " [YANTRA_CUSTOMER_MAST].CUST_ID= " + CustomerId);
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.CustName = dbManager.DataReader["CUST_NAME"].ToString();
        //            this.CompName = dbManager.DataReader["CUST_COMPANY_NAME"].ToString();
        //            this.Address = dbManager.DataReader["CUST_UNIT_ADDRESS"].ToString();
        //            this.Email = dbManager.DataReader["CUST_CORP_EMAIL"].ToString();
        //            this.RegName = dbManager.DataReader["REG_NAME"].ToString();
        //            this.Phone = dbManager.DataReader["CUST_CORP_PHONE"].ToString();
        //            this.Mobile = dbManager.DataReader["CUST_CORP_MOBILE"].ToString();
        //            this.CustUnitName = dbManager.DataReader["CUST_UNIT_NAME"].ToString();

        //            ////this.ContactPerson = dbManager.DataReader["CUST_CONTACT_PERSON"].ToString();
        //            ////this.Fax = dbManager.DataReader["CUST_FAX"].ToString();
        //            ////this.IndTypeId = dbManager.DataReader["IND_TYPE_ID"].ToString();
        //            ////this.IndType = dbManager.DataReader["IND_TYPE"].ToString();
        //            ////this.CorpContactPerson = dbManager.DataReader["CUST_CORP_CONTACT_PERSON"].ToString();
        //            ////this.CorpPhone = dbManager.DataReader["CUST_CORP_PHONE"].ToString();
        //            ////this.CorpMobile = dbManager.DataReader["CUST_CORP_MOBILE"].ToString();
        //            ////this.CorpEmail = dbManager.DataReader["CUST_CORP_EMAIL"].ToString();
        //            ////this.CorpAddress = dbManager.DataReader["CUST_CORP_ADDRESS"].ToString();
        //            ////this.CorpDesgId = dbManager.DataReader["CUST_CORP_DESG_ID"].ToString();
        //            ////this.CorpFax = dbManager.DataReader["CUST_CORP_FAX"].ToString();

        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        return _returnIntValue;
        //    }

        //    public static void CustomerMasterAllDetails_Select(Control ControlForBind, string CustId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_MAST] where CUST_ID=" + CustId + "");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            (ControlForBind as DropDownList).Items.Clear();
        //            (ControlForBind as DropDownList).Items.Add(new ListItem("--", "0"));
        //            while (dbManager.DataReader.Read())
        //            {
        //                (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["CUST_CONTACT_PERSON"].ToString(), dbManager.DataReader["CUST_ID"].ToString()));
        //            }
        //            dbManager.DataReader.Close();
        //        }
        //        _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_DET] where CUST_ID=" + CustId + " ORDER BY CUST_CORP_CONTACT_PERSON");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            while (dbManager.DataReader.Read())
        //            {
        //                (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["CUST_CORP_CONTACT_PERSON"].ToString(), dbManager.DataReader["CUST_DET_ID"].ToString()));
        //            }
        //            dbManager.DataReader.Close();
        //        }
        //    }

        //    public string CustomerMasterDetails_Save()
        //    {
        //        if (this.CustUnitId == "delete")
        //        {
        //            _commandText = string.Format("DELETE FROM [YANTRA_CUSTOMER_DET] WHERE CUST_DET_ID='{0}'", this.CustDetId);
        //        }
        //        else if (this.CustDetId == "-")//Do Not Remove This Condition ... This Is Reference For Checking New Record Or Not
        //        {
        //            _commandText = string.Format("INSERT INTO [YANTRA_CUSTOMER_DET] SELECT ISNULL(MAX(CUST_DET_ID),0)+1,{0},'{1}','{2}','{3}','{4}','{5}',{6},'{7}',{8} FROM [YANTRA_CUSTOMER_DET]",
        //                                                                                             this.CustId, this.CustCorpContactPerson, this.CustCorpPhone, this.CustCorpMobile, this.CustCorpEmail, this.CustCorpAddress, this.CustCorpDesgId, this.CustCorpFax, this.CustUnitId);
        //        }
        //        else
        //        {
        //            _commandText = string.Format("UPDATE [YANTRA_CUSTOMER_DET] SET CUST_CORP_CONTACT_PERSON='{0}',CUST_CORP_PHONE='{1}',CUST_CORP_MOBILE='{2}',CUST_CORP_EMAIL='{3}',CUST_CORP_ADDRESS='{4}',CUST_CORP_DESG_ID={5},CUST_CORP_FAX='{6}',CUST_UNIT_ID={7}  WHERE CUST_DET_ID={8}",
        //                                                                                              this.CustCorpContactPerson, this.CustCorpPhone, this.CustCorpMobile, this.CustCorpEmail, this.CustCorpAddress, this.CustCorpDesgId, this.CustCorpFax, this.CustUnitId, this.CustDetId);
        //        }

        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public int CustomerMasterDetails_Delete(string CustomerId)
        //    {
        //        if (DeleteRecord("[YANTRA_CUSTOMER_DET]", "CUST_ID", CustomerId) == true)
        //        { _returnIntValue = 1; }
        //        else
        //        { _returnIntValue = 0; }
        //        return _returnIntValue;
        //    }

        //    public void CustomerMasterDetails_Select(string CustomerId, GridView gv)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_DET],[YANTRA_DESG_MAST],[YANTRA_CUSTOMER_UNITS] WHERE [YANTRA_CUSTOMER_DET].CUST_UNIT_ID=[YANTRA_CUSTOMER_UNITS].CUST_UNIT_ID AND [YANTRA_CUSTOMER_DET].CUST_CORP_DESG_ID=[YANTRA_DESG_MAST].DESG_ID AND [YANTRA_CUSTOMER_DET].CUST_ID=" + CustomerId + " AND [YANTRA_CUSTOMER_DET].CUST_UNIT_ID<>0");

        //        dbManager.ExecuteReader(CommandType.Text, _commandText);

        //        DataTable CustomerProducts = new DataTable();
        //        DataColumn col = new DataColumn();
        //        col = new DataColumn("UnitName");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("ContactPerson");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("Designation");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("Address");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("ContactNo1");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("ContactNo2");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("FaxNo");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("Email");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("DesignationId");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("CustUnitId");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("CustDetId");
        //        CustomerProducts.Columns.Add(col);

        //        while (dbManager.DataReader.Read())
        //        {
        //            DataRow dr = CustomerProducts.NewRow();

        //            dr["CustDetId"] = dbManager.DataReader["CUST_DET_ID"].ToString();
        //            dr["CustUnitId"] = dbManager.DataReader["CUST_UNIT_ID"].ToString();
        //            dr["UnitName"] = dbManager.DataReader["CUST_UNIT_NAME"].ToString();
        //            dr["ContactPerson"] = dbManager.DataReader["CUST_CORP_CONTACT_PERSON"].ToString();
        //            dr["DesignationId"] = dbManager.DataReader["CUST_CORP_DESG_ID"].ToString();
        //            dr["Designation"] = dbManager.DataReader["DESG_NAME"].ToString();
        //            dr["Address"] = dbManager.DataReader["CUST_CORP_ADDRESS"].ToString();
        //            dr["ContactNo1"] = dbManager.DataReader["CUST_CORP_PHONE"].ToString();
        //            dr["ContactNo2"] = dbManager.DataReader["CUST_CORP_MOBILE"].ToString();
        //            dr["FaxNo"] = dbManager.DataReader["CUST_CORP_FAX"].ToString();
        //            dr["Email"] = dbManager.DataReader["CUST_CORP_EMAIL"].ToString();
        //            CustomerProducts.Rows.Add(dr);
        //        }
        //        gv.DataSource = CustomerProducts;
        //        gv.DataBind();
        //    }

        //    public void CustomerMasterDetails_Select(string CustomerId, string CustUnitId, GridView gv)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        if (CustUnitId == "0")
        //        {
        //            _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_DET],[YANTRA_DESG_MAST] WHERE [YANTRA_CUSTOMER_DET].CUST_CORP_DESG_ID=[YANTRA_DESG_MAST].DESG_ID AND [YANTRA_CUSTOMER_DET].CUST_ID=" + CustomerId + " AND [YANTRA_CUSTOMER_DET].CUST_UNIT_ID=" + CustUnitId + "");
        //        }
        //        else
        //        {
        //            _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_DET],[YANTRA_DESG_MAST],[YANTRA_CUSTOMER_UNITS] WHERE [YANTRA_CUSTOMER_DET].CUST_UNIT_ID=[YANTRA_CUSTOMER_UNITS].CUST_UNIT_ID AND [YANTRA_CUSTOMER_DET].CUST_CORP_DESG_ID=[YANTRA_DESG_MAST].DESG_ID AND [YANTRA_CUSTOMER_DET].CUST_ID=" + CustomerId + " AND [YANTRA_CUSTOMER_DET].CUST_UNIT_ID=" + CustUnitId + "");
        //        }
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);

        //        DataTable CustomerProducts = new DataTable();
        //        DataColumn col = new DataColumn();
        //        col = new DataColumn("UnitName");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("ContactPerson");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("Designation");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("Address");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("ContactNo1");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("ContactNo2");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("FaxNo");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("Email");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("DesignationId");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("CustUnitId");
        //        CustomerProducts.Columns.Add(col);
        //        col = new DataColumn("CustDetId");
        //        CustomerProducts.Columns.Add(col);

        //        while (dbManager.DataReader.Read())
        //        {
        //            DataRow dr = CustomerProducts.NewRow();

        //            dr["CustDetId"] = dbManager.DataReader["CUST_DET_ID"].ToString();
        //            dr["CustUnitId"] = dbManager.DataReader["CUST_UNIT_ID"].ToString();
        //            if (CustUnitId != "0") { dr["UnitName"] = dbManager.DataReader["CUST_UNIT_NAME"].ToString(); }
        //            dr["ContactPerson"] = dbManager.DataReader["CUST_CORP_CONTACT_PERSON"].ToString();
        //            dr["DesignationId"] = dbManager.DataReader["CUST_CORP_DESG_ID"].ToString();
        //            dr["Designation"] = dbManager.DataReader["DESG_NAME"].ToString();
        //            dr["Address"] = dbManager.DataReader["CUST_CORP_ADDRESS"].ToString();
        //            dr["ContactNo1"] = dbManager.DataReader["CUST_CORP_PHONE"].ToString();
        //            dr["ContactNo2"] = dbManager.DataReader["CUST_CORP_MOBILE"].ToString();
        //            dr["FaxNo"] = dbManager.DataReader["CUST_CORP_FAX"].ToString();
        //            dr["Email"] = dbManager.DataReader["CUST_CORP_EMAIL"].ToString();
        //            CustomerProducts.Rows.Add(dr);
        //        }
        //        gv.DataSource = CustomerProducts;
        //        gv.DataBind();
        //    }

        //    public static void CustomerMasterDetails_Select(Control ControlForBind, string CustUnitId)
        //    {
        //        dbManager.Open();
        //        if (CustUnitId == "0")
        //        {
        //            _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_DET] where CUST_DET_ID<>0 ORDER BY CUST_CORP_CONTACT_PERSON");
        //        }
        //        else
        //        {
        //            _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_DET] where CUST_UNIT_ID=" + CustUnitId + " ORDER BY CUST_CORP_CONTACT_PERSON");
        //        }
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "CUST_CORP_CONTACT_PERSON", "CUST_DET_ID");
        //        }
        //    }

        //    public int CustomerMasterDetails_Select(string CustDetId)
        //    {
        //        if (CustDetId == "0") { _returnIntValue = 0; }
        //        else
        //        {
        //            if (dbManager.Transaction == null)
        //                dbManager.Open();
        //            _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_DET]  WHERE CUST_DET_ID='" + CustDetId + "' ORDER BY CUST_DET_ID DESC ");
        //            dbManager.ExecuteReader(CommandType.Text, _commandText);
        //            if (dbManager.DataReader.Read())
        //            {
        //                this.CustDetId = dbManager.DataReader["CUST_DET_ID"].ToString();
        //                this.CustCorpEmail = dbManager.DataReader["CUST_CORP_EMAIL"].ToString();
        //                this.CustCorpPhone = dbManager.DataReader["CUST_CORP_PHONE"].ToString();
        //                this.CustCorpMobile = dbManager.DataReader["CUST_CORP_MOBILE"].ToString();

        //                _returnIntValue = 1;
        //            }
        //            else
        //            {
        //                _returnIntValue = 0;
        //            }
        //        }
        //        return _returnIntValue;
        //    }

        //    public string CustomerUnits_Save()
        //    {
        //        if (this.CustUnitName == "delete")
        //        {
        //            _commandText = string.Format("DELETE FROM [YANTRA_CUSTOMER_UNITS] WHERE CUST_UNIT_ID='{0}'", this.CustUnitId);
        //        }
        //        else if (this.CustUnitId.Substring(0, 1) != "t")//Do Not Remove This Condition ... This Is Reference For Checking Neew Recoed Or Not
        //        {
        //            _commandText = string.Format("UPDATE [YANTRA_CUSTOMER_UNITS] SET CUST_UNIT_NAME='{0}',CUST_UNIT_ADDRESS='{1}' WHERE CUST_UNIT_ID='{2}'", this.CustUnitName, this.CustUnitAddress, this.CustUnitId);
        //        }
        //        else
        //        {
        //            this.CustUnitId = AutoGenMaxId("[YANTRA_CUSTOMER_UNITS]", "CUST_UNIT_ID");
        //            _commandText = string.Format("INSERT INTO [YANTRA_CUSTOMER_UNITS] VALUES({0},'{1}','{2}','{3}')", this.CustUnitId, this.CustId, this.CustUnitName, this.CustUnitAddress);
        //        }
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string CustomerUnits_Delete(string CustomerId)
        //    {
        //        if (DeleteRecord("[YANTRA_CUSTOMER_UNITS]", "CUST_ID", CustomerId) == true)
        //        {
        //            _returnStringMessage = "Data Deleted Successfully";
        //        }
        //        else
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public static void CustomerUnits_Select(Control ControlForBind, string CustomerId)
        //    {
        //        dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_UNITS] where CUST_ID=" + CustomerId + " ORDER BY CUST_UNIT_NAME");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "CUST_UNIT_NAME", "CUST_UNIT_ID");
        //        }
        //    }

        //    public void CustomerUnitDetails_Select(string CustomerId, GridView gv)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_UNITS] WHERE CUST_ID = " + CustomerId + "");

        //        dbManager.ExecuteReader(CommandType.Text, _commandText);

        //        DataTable CustomerUnits = new DataTable();
        //        DataColumn col = new DataColumn();
        //        //col = new DataColumn("unitno");
        //        //CustomerUnits.Columns.Add(col);
        //        col = new DataColumn("unitname");
        //        CustomerUnits.Columns.Add(col);
        //        col = new DataColumn("unitaddress");
        //        CustomerUnits.Columns.Add(col);
        //        col = new DataColumn("custunitid");
        //        CustomerUnits.Columns.Add(col);

        //        while (dbManager.DataReader.Read())
        //        {
        //            DataRow dr = CustomerUnits.NewRow();

        //            //dr["unitno"] = dbManager.DataReader["UNIT_NO"].ToString();
        //            dr["unitname"] = dbManager.DataReader["CUST_UNIT_NAME"].ToString();
        //            dr["unitaddress"] = dbManager.DataReader["CUST_UNIT_ADDRESS"].ToString();
        //            dr["custunitid"] = dbManager.DataReader["CUST_UNIT_ID"].ToString();
        //            CustomerUnits.Rows.Add(dr);
        //        }
        //        gv.DataSource = CustomerUnits;
        //        gv.DataBind();
        //    }

        //    public int CustomerUnits_Select(string CustUnitId)
        //    {
        //        if (CustUnitId == "0") { _returnIntValue = 0; }
        //        else
        //        {
        //            if (dbManager.Transaction == null)
        //                dbManager.Open();
        //            _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_UNITS]  WHERE CUST_UNIT_ID='" + CustUnitId + "' ORDER BY CUST_UNIT_ID DESC ");
        //            dbManager.ExecuteReader(CommandType.Text, _commandText);
        //            if (dbManager.DataReader.Read())
        //            {
        //                this.CustUnitId = dbManager.DataReader["CUST_UNIT_ID"].ToString();
        //                this.CustId = dbManager.DataReader["CUST_ID"].ToString();
        //                this.CustUnitName = dbManager.DataReader["CUST_UNIT_NAME"].ToString();
        //                this.CustUnitAddress = dbManager.DataReader["CUST_UNIT_ADDRESS"].ToString();

        //                _returnIntValue = 1;
        //            }
        //            else
        //            {
        //                _returnIntValue = 0;
        //            }
        //        }
        //        return _returnIntValue;
        //    }

        //    public static void TenderCustomerMaster_Select(Control ControlForBind)
        //    {
        //        dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_MAST] WHERE [YANTRA_CUSTOMER_MAST].CUST_ID IN( SELECT [YANTRA_ENQ_MAST].CUST_ID FROM [YANTRA_ENQ_MAST],[YANTRA_LKUP_ENQ_MODE] WHERE [YANTRA_ENQ_MAST].ENQM_ID=[YANTRA_LKUP_ENQ_MODE].ENQM_ID AND [YANTRA_LKUP_ENQ_MODE].ENQM_NAME='TENDER' AND [YANTRA_ENQ_MAST].ENQ_ID IN (SELECT ENQ_ID FROM [YANTRA_QUOT_MAST])) ORDER BY [YANTRA_CUSTOMER_MAST].CUST_COMPANY_NAME");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "CUST_COMPANY_NAME", "CUST_ID");
        //        }
        //    }

        //    public static void TenderCustomerUnits_Select(Control ControlForBind, string CustomerId)
        //    {
        //        dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST],[YANTRA_LKUP_ENQ_MODE],[YANTRA_CUSTOMER_UNITS] WHERE [YANTRA_ENQ_MAST].ENQM_ID=[YANTRA_LKUP_ENQ_MODE].ENQM_ID AND [YANTRA_ENQ_MAST].CUST_ID=[YANTRA_CUSTOMER_UNITS].CUST_ID AND [YANTRA_ENQ_MAST].CUST_UNIT_ID=[YANTRA_CUSTOMER_UNITS].CUST_UNIT_ID AND [YANTRA_CUSTOMER_UNITS].CUST_ID=" + CustomerId + " AND [YANTRA_LKUP_ENQ_MODE].ENQM_NAME='TENDER' AND [YANTRA_ENQ_MAST].ENQ_ID IN (SELECT ENQ_ID FROM [YANTRA_QUOT_MAST])ORDER BY [YANTRA_CUSTOMER_UNITS].CUST_UNIT_NAME");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "CUST_UNIT_NAME", "CUST_UNIT_ID");
        //        }
        //    }

        //}

        //Methods For Sales Enquiry Form
        //public class SalesEnquiry
        //{
        //    public string EnqId, EnqNo, EnqDate, CustId, CustName, EnqModeId, EnqModeName, EnqOrigBy, EnqOrigName, EnqRef, EnqFollowUp, EnqDeliveryDate, DespModeId, PromotionType, PromotionActivity, EnqPriority, EnqStatus, EnqDueDate, EnqDesc, CustUnitId, CustDetId, EnqSubTime, EnqOpeningDate, EnqOpeningTime, EnqDocCharges, EnqDocFavourof, EnqEMDCharges, EnqEMDFavourof, EnqTenderDate;
        //    public string EnqDetItemCode, EnqDetQty, EnqDetSpec, EnqDetRemarks, EnqDetPriority;

        //    public SalesEnquiry()
        //    {
        //    }

        //    //public static string SalesEnquiry_AutoGenCode()
        //    //{
        //    //    //string _codePrefix = CurrentFinancialYear() + " ";
        //    //    ////string _codePrefix = "ENQ/";
        //    //    //if (dbManager.Transaction == null)
        //    //    //    dbManager.Open();
        //    //    //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(CONVERT(BIGINT,SUBSTRING(SUBSTRING(ENQ_NO,0,LEN(ENQ_NO)-5),CHARINDEX('-',ENQ_NO)+1,LEN(SUBSTRING(ENQ_NO,0,LEN(ENQ_NO)-5))))),0)+1 FROM YANTRA_ENQ_MAST WHERE SUBSTRING(ENQ_NO,LEN(ENQ_NO)-4,5)='09-10'").ToString());
        //    //    //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(CONVERT(BIGINT,REPLACE(ENQ_NO,LEFT(ENQ_NO,5),''))),0)+1 FROM [YANTRA_ENQ_MAST]").ToString());
        //    //    ////_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(REPLACE(ENQ_NO,'" + _codePrefix + "','')),0)+1 FROM [YANTRA_ENQ_MAST]").ToString());
        //    //    //return _codePrefix + _returnIntValue;
        //    //    return AutoGenMaxNo("YANTRA_ENQ_MAST", "ENQ_NO");

        //    //}

        //    public string SalesEnquiry_Save()
        //    {
        //        //this.EnqNo = SalesEnquiry_AutoGenCode();
        //        this.EnqId = AutoGenMaxId("[YANTRA_ENQ_MAST]", "ENQ_ID");
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [YANTRA_ENQ_MAST] VALUES({0},'{1}','{2}',{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','','','','','{24}')", this.EnqId, this.EnqNo, this.EnqDate, this.CustId, this.EnqModeId, this.EnqOrigBy, this.EnqOrigName, this.EnqRef, this.EnqFollowUp, this.EnqDeliveryDate, this.PromotionType, this.PromotionActivity, this.EnqStatus, this.EnqDueDate, this.EnqDesc, this.CustUnitId, this.CustDetId, this.EnqSubTime, this.EnqOpeningDate, this.EnqOpeningTime, this.EnqDocCharges, this.EnqDocFavourof, this.EnqEMDCharges, this.EnqEMDFavourof, this.EnqTenderDate);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string SalesEnquiry_Update()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [YANTRA_ENQ_MAST] SET ENQ_DATE='{0}',CUST_ID={1},ENQM_ID={2},ENQ_ORIG_BY='{3}',ENQ_ORIG_NAME='{4}',ENQ_REFERENCE='{5}',ENQ_FOLLOWUP_CITERIA='{6}',ENQ_DELIVERY_DATE='{7}',PROMOTION_TYPE='{8}',PROMOTION_ACTIVITY='{9}',ENQ_STATUS='{10}',ENQ_DUE_DATE='{11}',ENQ_DESC='{12}',CUST_UNIT_ID={13},CUST_DET_ID={14},ENQ_SUB_TIME='{15}',ENQ_OPENING_DATE='{16}',ENQ_OPENING_TIME='{17}',ENQ_DOC_CHARGES='',ENQ_DOC_INFAVOUROF='',ENQ_EMD_CHARGES='',ENQ_EMD_INFAVOUROF='',ENQ_TENDER_DATE='{22}' WHERE ENQ_ID='{23}'", this.EnqDate, this.CustId, this.EnqModeId, this.EnqOrigBy, this.EnqOrigName, this.EnqRef, this.EnqFollowUp, this.EnqDeliveryDate, this.PromotionType, this.PromotionActivity, this.EnqStatus, this.EnqDueDate, this.EnqDesc, this.CustUnitId, this.CustDetId, this.EnqSubTime, this.EnqOpeningDate, this.EnqOpeningTime, this.EnqDocCharges, this.EnqDocFavourof, this.EnqEMDCharges, this.EnqEMDFavourof, this.EnqTenderDate, this.EnqId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    //public string SalesEnquiry_Delete(string EnquiryId)
        //    //{
        //    //    SM.BeginTransaction();
        //    //    if (Yantra.Authentication.GetEmployeeInSession(Yantra.Authentication.Logged_EMP_Details.UserType) == "Admin")
        //    //    {
        //    //        if (DeleteRecord("[YANTRA_ENQ_DET]", "ENQ_ID", EnquiryId) == true)
        //    //        {
        //    //            if (DeleteRecord("[YANTRA_ENQ_MAST]", "ENQ_ID", EnquiryId) == true)
        //    //            {
        //    //                SM.CommitTransaction();
        //    //                _returnStringMessage = "Data Deleted Successfully";
        //    //            }
        //    //            else
        //    //            {
        //    //                SM.RollBackTransaction();
        //    //                _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            SM.RollBackTransaction();
        //    //            _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        _returnStringMessage = "You dont have prevelege to delete the Record";
        //    //    }

        //    //    return _returnStringMessage;
        //    //}

        //    public string SalesEnquiryDetails_Save()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [YANTRA_ENQ_DET] SELECT ISNULL(MAX(ENQ_DET_ID),0)+1,{0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}' FROM [YANTRA_ENQ_DET]", this.EnqId, this.EnqDetItemCode, this.EnqDetQty, this.EnqDetSpec, this.EnqDetRemarks, this.EnqDetPriority, this.EnqDocCharges, this.EnqDocFavourof, this.EnqEMDCharges, this.EnqEMDFavourof);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public int SalesEnquiryDetails_Delete(string EnquiryId)
        //    {
        //        //if (dbManager.Transaction == null)
        //        //    dbManager.Open();
        //        //_commandText = string.Format("DELETE FROM [YANTRA_ENQ_DET] WHERE ENQ_ID={0}", EnquiryId);
        //        //_returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        if (DeleteRecord("[YANTRA_ENQ_DET]", "ENQ_ID", EnquiryId) == true)
        //        { _returnIntValue = 1; }
        //        else
        //        { _returnIntValue = 0; }
        //        return _returnIntValue;
        //    }

        //    public int SalesEnquiry_Select(string EnquiryId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST],[YANTRA_LKUP_ENQ_MODE],[YANTRA_CUSTOMER_MAST] WHERE [YANTRA_ENQ_MAST].ENQM_ID=[YANTRA_LKUP_ENQ_MODE].ENQM_ID AND " +
        //                                    "[YANTRA_ENQ_MAST].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID AND [YANTRA_ENQ_MAST].ENQ_ID='" + EnquiryId + "' ORDER BY [YANTRA_ENQ_MAST].ENQ_ID DESC ");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.EnqId = dbManager.DataReader["ENQ_ID"].ToString();
        //            this.EnqNo = dbManager.DataReader["ENQ_NO"].ToString();
        //            this.EnqDate = Convert.ToDateTime(dbManager.DataReader["ENQ_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.CustId = dbManager.DataReader["CUST_ID"].ToString();
        //            this.EnqModeId = dbManager.DataReader["ENQM_ID"].ToString();
        //            this.EnqModeName = dbManager.DataReader["ENQM_NAME"].ToString();
        //            this.EnqOrigBy = dbManager.DataReader["ENQ_ORIG_BY"].ToString();
        //            this.EnqOrigName = dbManager.DataReader["ENQ_ORIG_NAME"].ToString();
        //            this.EnqRef = dbManager.DataReader["ENQ_REFERENCE"].ToString();
        //            this.EnqFollowUp = dbManager.DataReader["ENQ_FOLLOWUP_CITERIA"].ToString();
        //            this.EnqDeliveryDate = Convert.ToDateTime(dbManager.DataReader["ENQ_DELIVERY_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.PromotionType = dbManager.DataReader["PROMOTION_TYPE"].ToString();
        //            this.PromotionActivity = dbManager.DataReader["PROMOTION_ACTIVITY"].ToString();
        //            this.EnqStatus = dbManager.DataReader["ENQ_STATUS"].ToString();
        //            this.EnqDueDate = Convert.ToDateTime(dbManager.DataReader["ENQ_DUE_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.EnqDesc = dbManager.DataReader["ENQ_DESC"].ToString();
        //            this.CustUnitId = dbManager.DataReader["CUST_UNIT_ID"].ToString();
        //            this.CustDetId = dbManager.DataReader["CUST_DET_ID"].ToString();
        //            this.EnqSubTime = dbManager.DataReader["ENQ_SUB_TIME"].ToString();
        //            this.EnqOpeningDate = Convert.ToDateTime(dbManager.DataReader["ENQ_OPENING_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.EnqOpeningTime = dbManager.DataReader["ENQ_OPENING_TIME"].ToString();
        //            //this.EnqDocCharges = dbManager.DataReader["ENQ_DOC_CHARGES"].ToString();
        //            //this.EnqDocFavourof = dbManager.DataReader["ENQ_DOC_INFAVOUROF"].ToString();
        //            this.EnqEMDCharges = dbManager.DataReader["ENQ_EMD_CHARGES"].ToString();
        //            //this.EnqEMDFavourof = dbManager.DataReader["ENQ_EMD_INFAVOUROF"].ToString();
        //            this.EnqTenderDate = dbManager.DataReader["ENQ_TENDER_DATE"].ToString();

        //            if (this.EnqSubTime == "1/1/1900 12:00:00 AM") { this.EnqSubTime = ""; } else { this.EnqSubTime = Convert.ToDateTime(this.EnqSubTime).ToShortTimeString(); }
        //            if (this.EnqOpeningTime == "1/1/1900 12:00:00 AM") { this.EnqOpeningTime = ""; } else { this.EnqOpeningTime = Convert.ToDateTime(this.EnqOpeningTime).ToShortTimeString(); }
        //            if (this.EnqTenderDate == "1/1/1900 12:00:00 AM") { this.EnqTenderDate = ""; } else { this.EnqTenderDate = Convert.ToDateTime(this.EnqTenderDate).ToString("dd/MM/yyyy"); }
        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        return _returnIntValue;
        //    }

        //    public static string SalesEnquiryStatus_Update(SMStatus Status, string EnqId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [YANTRA_ENQ_MAST] SET  ENQ_STATUS='{0}' WHERE ENQ_ID='{1}'", Status, EnqId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Status Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public void SalesEnquiryDetails_Select(string EnquiryId, GridView gv)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_DET],[YANTRA_ITEM_MAST],[YANTRA_LKUP_ITEM_TYPE],[YANTRA_LKUP_UOM] WHERE [YANTRA_ENQ_DET].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE AND " +
        //                                       "[YANTRA_ITEM_MAST].UOM_ID=[YANTRA_LKUP_UOM].UOM_ID AND [YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID=[YANTRA_ITEM_MAST].IT_TYPE_ID AND [YANTRA_ENQ_DET].ENQ_ID=" + EnquiryId + "");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);

        //        DataTable EnquiryInterestedProducts = new DataTable();
        //        DataColumn col = new DataColumn();
        //        col = new DataColumn("ItemCode");
        //        EnquiryInterestedProducts.Columns.Add(col);
        //        col = new DataColumn("ItemType");
        //        EnquiryInterestedProducts.Columns.Add(col);
        //        col = new DataColumn("ItemName");
        //        EnquiryInterestedProducts.Columns.Add(col);
        //        col = new DataColumn("UOM");
        //        EnquiryInterestedProducts.Columns.Add(col);
        //        col = new DataColumn("Quantity");
        //        EnquiryInterestedProducts.Columns.Add(col);
        //        col = new DataColumn("Specifications");
        //        EnquiryInterestedProducts.Columns.Add(col);
        //        col = new DataColumn("Remarks");
        //        EnquiryInterestedProducts.Columns.Add(col);
        //        col = new DataColumn("Priority");
        //        EnquiryInterestedProducts.Columns.Add(col);
        //        col = new DataColumn("ItemTypeId");
        //        EnquiryInterestedProducts.Columns.Add(col);
        //        col = new DataColumn("DocCharges");
        //        EnquiryInterestedProducts.Columns.Add(col);
        //        col = new DataColumn("DocInFavourOf");
        //        EnquiryInterestedProducts.Columns.Add(col);
        //        col = new DataColumn("EMDCharges");
        //        EnquiryInterestedProducts.Columns.Add(col);
        //        col = new DataColumn("EMDInFavourOf");
        //        EnquiryInterestedProducts.Columns.Add(col);

        //        while (dbManager.DataReader.Read())
        //        {
        //            DataRow dr = EnquiryInterestedProducts.NewRow();
        //            dr["ItemCode"] = dbManager.DataReader["ITEM_CODE"].ToString();
        //            dr["ItemName"] = dbManager.DataReader["ITEM_NAME"].ToString();
        //            dr["UOM"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
        //            dr["Quantity"] = dbManager.DataReader["ENQ_DET_QTY"].ToString();
        //            dr["Specifications"] = dbManager.DataReader["ENQ_DET_SPEC"].ToString();
        //            dr["Remarks"] = dbManager.DataReader["ENQ_DET_REMARKS"].ToString();
        //            dr["Priority"] = dbManager.DataReader["ENQ_DET_PRIORITY"].ToString();
        //            dr["ItemType"] = dbManager.DataReader["IT_TYPE"].ToString();
        //            dr["ItemTypeId"] = dbManager.DataReader["IT_TYPE_ID"].ToString();
        //            dr["DocCharges"] = dbManager.DataReader["ENQ_DOC_CHARGES"].ToString();
        //            dr["DocInFavourOf"] = dbManager.DataReader["ENQ_DOC_INFAVOUROF"].ToString();
        //            dr["EMDCharges"] = dbManager.DataReader["ENQ_EMD_CHARGES"].ToString();
        //            dr["EMDInFavourOf"] = dbManager.DataReader["ENQ_EMD_INFAVOUROF"].ToString();
        //            EnquiryInterestedProducts.Rows.Add(dr);
        //        }
        //        gv.DataSource = EnquiryInterestedProducts;
        //        gv.DataBind();
        //    }

        //    public static void SalesEnquiry_Select(Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST] ORDER BY ENQ_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "ENQ_NO", "ENQ_ID");
        //        }
        //    }

        //    public static void SalesEnquiry_Select(Control ControlForBind, string EmployeeId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT [YANTRA_ENQ_MAST].* FROM [YANTRA_ENQ_MAST] inner join [YANTRA_ENQ_ASSIGN_TASKS] on YANTRA_ENQ_ASSIGN_TASKS.ENQ_ID = YANTRA_ENQ_MAST.ENQ_ID inner join [YANTRA_EMPLOYEE_MAST] on [YANTRA_EMPLOYEE_MAST].EMP_ID=[YANTRA_ENQ_ASSIGN_TASKS].EMP_ID	where [YANTRA_ENQ_ASSIGN_TASKS].EMP_ID=" + EmployeeId + " ORDER BY [YANTRA_ENQ_MAST].ENQ_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "ENQ_NO", "ENQ_ID");
        //        }
        //    }

        //    public static void SalesEnquiryItemTypes_Select(string EnquiryId, Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT distinct([YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID),([YANTRA_LKUP_ITEM_TYPE].IT_TYPE) FROM [YANTRA_ENQ_DET],[YANTRA_LKUP_ITEM_TYPE],[YANTRA_ITEM_MAST] WHERE [YANTRA_ENQ_DET].ITEM_CODE in ([YANTRA_ITEM_MAST].ITEM_CODE) AND [YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID=[YANTRA_ITEM_MAST].IT_TYPE_ID AND  [YANTRA_ENQ_DET].ENQ_ID=" + EnquiryId + "");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "IT_TYPE", "IT_TYPE_ID");
        //        }
        //    }

        //    public static void SalesEnquiryItemNames_Select(string EnquiryId, string ItemTypeId, Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_DET],[YANTRA_LKUP_ITEM_TYPE],[YANTRA_ITEM_MAST] WHERE [YANTRA_ENQ_DET].ITEM_CODE in ([YANTRA_ITEM_MAST].ITEM_CODE) AND [YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID=[YANTRA_ITEM_MAST].IT_TYPE_ID AND [YANTRA_ENQ_DET].ENQ_ID=" + EnquiryId + " AND [YANTRA_ITEM_MAST].IT_TYPE_ID=" + ItemTypeId + "");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "ITEM_NAME", "ITEM_CODE");
        //        }
        //    }

        //    public static void SalesEnquiryTenderNo_Select(Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        //_commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST] ORDER BY ENQ_ID");
        //        _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST],[YANTRA_LKUP_ENQ_MODE] WHERE [YANTRA_ENQ_MAST].ENQM_ID=[YANTRA_LKUP_ENQ_MODE].ENQM_ID AND [YANTRA_LKUP_ENQ_MODE].ENQM_NAME='TENDER' ORDER BY [YANTRA_ENQ_MAST].ENQ_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "ENQ_REFERENCE", "ENQ_ID");
        //        }
        //    }

        //    public static void SalesEnquiryTenderNo_Select(Control ControlForBind, string CustId, string CustUnitId, string SaveButtonText)
        //    {
        //        //////////if (dbManager.Transaction == null)
        //        //////////    dbManager.Open();
        //        ////////////_commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST] ORDER BY ENQ_ID");
        //        //////////_commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST],[YANTRA_LKUP_ENQ_MODE] WHERE [YANTRA_ENQ_MAST].ENQM_ID=[YANTRA_LKUP_ENQ_MODE].ENQM_ID AND [YANTRA_LKUP_ENQ_MODE].ENQM_NAME='TENDER' ORDER BY [YANTRA_ENQ_MAST].ENQ_ID");
        //        //////////dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        //////////if (ControlForBind is DropDownList)
        //        //////////{
        //        //////////    DropDownListBind(ControlForBind as DropDownList, "ENQ_REFERENCE", "ENQ_ID");
        //        //////////}
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        if (SaveButtonText == "Save")
        //        {
        //            (ControlForBind as DropDownList).Enabled = true;
        //            (ControlForBind as DropDownList).Items.Clear();
        //            (ControlForBind as DropDownList).Items.Add(new ListItem("--", "0"));
        //            //_commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST] WHERE [YANTRA_ENQ_MAST].CUST_ID=" + CustId + " AND [YANTRA_ENQ_MAST].CUST_UNIT_ID=" + CustUnitId + " AND [YANTRA_ENQ_MAST].ENQ_ID IN 	(SELECT ENQ_ID FROM YANTRA_EMDS_RECEIVED WHERE EMDR_STATUS <> 'Cleared') AND [YANTRA_ENQ_MAST].ENQ_ID IN 	(SELECT ENQ_ID FROM [YANTRA_QUOT_MAST]) ORDER BY [YANTRA_ENQ_MAST].ENQ_ID");
        //            _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST] WHERE [YANTRA_ENQ_MAST].CUST_ID=" + CustId + " AND [YANTRA_ENQ_MAST].CUST_UNIT_ID=" + CustUnitId + " and [YANTRA_ENQ_MAST].ENQ_ID not in (SELECT ENQ_ID FROM YANTRA_EMDS_RECEIVED WHERE EMDR_STATUS = 'Cleared') AND [YANTRA_ENQ_MAST].ENQ_ID IN 	(SELECT ENQ_ID FROM [YANTRA_QUOT_MAST]) ORDER BY [YANTRA_ENQ_MAST].ENQ_ID");
        //            dbManager.ExecuteReader(CommandType.Text, _commandText);
        //            while (dbManager.DataReader.Read())
        //            {
        //                (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["ENQ_REFERENCE"].ToString(), dbManager.DataReader["ENQ_ID"].ToString()));
        //            }
        //            dbManager.DataReader.Close();

        //            _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST] WHERE [YANTRA_ENQ_MAST].CUST_ID=" + CustId + " AND [YANTRA_ENQ_MAST].CUST_UNIT_ID=" + CustUnitId + " AND [YANTRA_ENQ_MAST].ENQ_ID NOT IN 	(SELECT ENQ_ID FROM YANTRA_EMDS_RECEIVED) AND [YANTRA_ENQ_MAST].ENQ_ID IN 	(SELECT ENQ_ID FROM [YANTRA_QUOT_MAST]) ORDER BY [YANTRA_ENQ_MAST].ENQ_ID");
        //            dbManager.ExecuteReader(CommandType.Text, _commandText);
        //            while (dbManager.DataReader.Read())
        //            {
        //                (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["ENQ_REFERENCE"].ToString(), dbManager.DataReader["ENQ_ID"].ToString()));
        //            }
        //            dbManager.DataReader.Close();
        //        }
        //        else if (SaveButtonText == "Update")
        //        {
        //            (ControlForBind as DropDownList).Enabled = false;
        //            _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST],[YANTRA_LKUP_ENQ_MODE] WHERE [YANTRA_ENQ_MAST].ENQ_ID IN (SELECT ENQ_ID FROM [YANTRA_QUOT_MAST]) AND [YANTRA_ENQ_MAST].ENQM_ID=[YANTRA_LKUP_ENQ_MODE].ENQM_ID AND [YANTRA_LKUP_ENQ_MODE].ENQM_NAME='TENDER' AND [YANTRA_ENQ_MAST].CUST_UNIT_ID=" + CustUnitId + " ORDER BY [YANTRA_ENQ_MAST].ENQ_ID");
        //            dbManager.ExecuteReader(CommandType.Text, _commandText);
        //            if (ControlForBind is DropDownList)
        //            {
        //                DropDownListBind(ControlForBind as DropDownList, "ENQ_REFERENCE", "ENQ_ID");
        //            }
        //        }
        //        else if (SaveButtonText == "New")
        //        {
        //            (ControlForBind as DropDownList).Enabled = true;
        //            (ControlForBind as DropDownList).Items.Clear();
        //            (ControlForBind as DropDownList).Items.Add(new ListItem("--", "0"));
        //            //_commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST] WHERE [YANTRA_ENQ_MAST].CUST_ID=" + CustId + " AND [YANTRA_ENQ_MAST].ENQ_ID IN 	(SELECT ENQ_ID FROM YANTRA_EMDS_RECEIVED WHERE EMDR_STATUS <> 'Cleared') AND [YANTRA_ENQ_MAST].ENQ_ID IN 	(SELECT ENQ_ID FROM [YANTRA_QUOT_MAST]) ORDER BY [YANTRA_ENQ_MAST].ENQ_ID");
        //            _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST] WHERE [YANTRA_ENQ_MAST].CUST_ID=" + CustId + " and [YANTRA_ENQ_MAST].ENQ_ID not in (SELECT ENQ_ID FROM YANTRA_EMDS_RECEIVED WHERE EMDR_STATUS = 'Cleared') AND [YANTRA_ENQ_MAST].ENQ_ID IN 	(SELECT ENQ_ID FROM [YANTRA_QUOT_MAST]) ORDER BY [YANTRA_ENQ_MAST].ENQ_ID");
        //            dbManager.ExecuteReader(CommandType.Text, _commandText);
        //            while (dbManager.DataReader.Read())
        //            {
        //                (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["ENQ_REFERENCE"].ToString(), dbManager.DataReader["ENQ_ID"].ToString()));
        //            }
        //            dbManager.DataReader.Close();

        //            //_commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST] WHERE [YANTRA_ENQ_MAST].CUST_ID=" + CustId + " AND [YANTRA_ENQ_MAST].ENQ_ID NOT IN 	(SELECT ENQ_ID FROM YANTRA_EMDS_RECEIVED) AND [YANTRA_ENQ_MAST].ENQ_ID IN 	(SELECT ENQ_ID FROM [YANTRA_QUOT_MAST]) ORDER BY [YANTRA_ENQ_MAST].ENQ_ID");
        //            //dbManager.ExecuteReader(CommandType.Text, _commandText);
        //            //while (dbManager.DataReader.Read())
        //            //{
        //            //    (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["ENQ_REFERENCE"].ToString(), dbManager.DataReader["ENQ_ID"].ToString()));
        //            //}
        //            //dbManager.DataReader.Close();

        //        }

        //    }

        //    public static void SalesOrderByTender_Select(string EnquiryId, Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();

        //        _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST],[YANTRA_QUOT_MAST],[YANTRA_SO_MAST] WHERE  [YANTRA_QUOT_MAST].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID AND [YANTRA_SO_MAST].QUOT_ID=[YANTRA_QUOT_MAST].QUOT_ID AND [YANTRA_ENQ_MAST].ENQ_ID=" + EnquiryId + " ORDER BY [YANTRA_ENQ_MAST].ENQ_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "SO_NO", "SO_ID");
        //        }
        //    }
        //}

        ////Methods for Sales Quotation Form
        //public class SalesQuotation
        //{
        //    public string QuotId, QuotNo, QuotDate, EnqId, EnqNo, EnqDate, CustId, QuotDelivery, QuotPayTerms, QuotPackCharges, QuotExcise, QuotCST, QuotVAT, DespmId, QuotGuarantee, QuotTransCharges, QuotInsurance, QuotErrec, QuotJurisdiction, QuotValidity, QuotInspection, QuotOtherSpecs, QuotPOLog, QuotRespId, QuotSalespId, QuotPreparedBy, QuotCheckedBy, QuotApprovedBy, AssignTaskId, CurrencyId, RevisedKey, QuotDDNo, QuotDDDate, QuotBankName, QuotTotalEMDCharges, CustUnitId, CustDetId, QuotFOB, QuotCIF;
        //    public string QuotDetItemCode, QuotDetQty, QuotRate, QuotDetSpec, QuotDetRemarks, QuotDetPriority, QuotDetDisc, QuotDetSpPrice;
        //    public string QuotFollowUpDetId, FollowUpEmpId, FollowUpDesc, FollowUpDate, FollowUpTechDiss, FollowUpCommNegos, FollowUpCompExistance, FollowUpRemarks, FollowUpExpDate;
        //    public bool IsExpectedOrder;

        //    public SalesQuotation()
        //    {
        //    }

        //    public static string SalesQuotation_AutoGenCode()
        //    {
        //        //string _codePrefix = CurrentFinancialYear() + " ";
        //        ////string _codePrefix = "QUOT/";
        //        //if (dbManager.Transaction == null)
        //        //    dbManager.Open();
        //        //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(CONVERT(BIGINT,REPLACE(QUOT_NO,LEFT(QUOT_NO,5),''))),0)+1 FROM [YANTRA_QUOT_MAST]").ToString());
        //        ////_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(REPLACE(QUOT_NO,'" + _codePrefix + "','')),0)+1 FROM [YANTRA_QUOT_MAST]").ToString());
        //        //return _codePrefix + _returnIntValue;
        //        return AutoGenMaxNo("YANTRA_QUOT_MAST", "QUOT_NO");
        //    }

        //    public string SalesQuotation_Save()
        //    {
        //        this.RevisedKey = "";
        //        //this.QuotNo = SalesQuotation_AutoGenCode();
        //        this.QuotId = AutoGenMaxId("[YANTRA_QUOT_MAST]", "QUOT_ID");
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [YANTRA_QUOT_MAST] SELECT ISNULL(MAX(QUOT_ID),0)+1,'{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}',{18},{19},'{20}','{21}','{22}',{23},'{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}' FROM [YANTRA_QUOT_MAST]", this.QuotNo, this.QuotDate, this.EnqId, this.QuotDelivery, this.QuotPayTerms, this.QuotPackCharges, this.QuotExcise, this.QuotCST, this.DespmId, this.QuotGuarantee, this.QuotTransCharges, this.QuotInsurance, this.QuotErrec, this.QuotJurisdiction, this.QuotValidity, this.QuotInspection, this.QuotOtherSpecs, "New", this.QuotRespId, this.QuotSalespId, this.QuotPreparedBy, this.QuotCheckedBy, this.QuotApprovedBy, this.CurrencyId, this.RevisedKey, this.QuotVAT, this.QuotDDNo, this.QuotDDDate, this.QuotBankName, this.IsExpectedOrder, this.QuotTotalEMDCharges, this.QuotFOB, this.QuotCIF);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string SalesQuotationRevise_Save()
        //    {
        //        //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(REPLACE(QUOT_REVISED_KEY,'R','')),0)+1 FROM YANTRA_QUOT_MAST WHERE QUOT_ID=" + this.QuotId + "").ToString());
        //        _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(REPLACE(QUOT_REVISED_KEY,'R','')),0)+1 FROM YANTRA_QUOT_MAST WHERE QUOT_NO LIKE '" + this.QuotNo + "%'").ToString());
        //        this.RevisedKey = "R" + _returnIntValue.ToString();

        //        SalesQuotationStatus_Update(SMStatus.Revised, this.QuotId);

        //        this.QuotId = AutoGenMaxId("[YANTRA_QUOT_MAST]", "QUOT_ID");
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [YANTRA_QUOT_MAST] SELECT ISNULL(MAX(QUOT_ID),0)+1,'{0}','{1}',{2},'{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}',{18},{19},'{20}','{21}','{22}',{23},'{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}' FROM [YANTRA_QUOT_MAST]", this.QuotNo, this.QuotDate, this.EnqId, this.QuotDelivery, this.QuotPayTerms, this.QuotPackCharges, this.QuotExcise, this.QuotCST, this.DespmId, this.QuotGuarantee, this.QuotTransCharges, this.QuotInsurance, this.QuotErrec, this.QuotJurisdiction, this.QuotValidity, this.QuotInspection, this.QuotOtherSpecs, "New", this.QuotRespId, this.QuotSalespId, this.QuotPreparedBy, this.QuotCheckedBy, this.QuotApprovedBy, this.CurrencyId, this.RevisedKey, this.QuotVAT, this.QuotDDNo, this.QuotDDDate, this.QuotBankName, this.IsExpectedOrder, this.QuotTotalEMDCharges, this.QuotFOB, this.QuotCIF);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string SalesQuotation_Update()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [YANTRA_QUOT_MAST] SET QUOT_DATE='{0}',QUOT_DELIVERY='{1}',QUOT_PAY_TERM='{2}',QUOT_PACK_CHARGES='{3}',QUOT_EXCISE='{4}',QUOT_CST='{5}',DESPM_ID='{6}',QUOT_GUARANTEE='{7}',QUOT_TRANS_CHARGES='{8}',QUOT_INSURANCE='{9}',QUOT_EREC_COMM='{10}',QUOT_JURISDICTION='{11}',QUOT_VALIDITY='{12}',QUOT_INSPECTION='{13}',QUOT_OTHER_SPEC='{14}',QUOT_RESP_ID='{15}',QUOT_SALESP_ID='{16}',QUOT_PREPARED_BY='{17}',QUOT_CHECKED_BY='{18}',QUOT_APPROVED_BY='{19}',CURRENCY_ID={20},QUOT_VAT='{21}',QUOT_DD_NO='{22}',QUOT_DD_DATE='{23}',QUOT_BANK_NAME='{24}',IS_EXPECTED_ORDER='{25}',QUOT_EMD_CHARGES='{26}',QUOT_FOB='{27}',QUOT_CIF='{28}' WHERE QUOT_ID={29}", this.QuotDate, this.QuotDelivery, this.QuotPayTerms, this.QuotPackCharges, this.QuotExcise, this.QuotCST, this.DespmId, this.QuotGuarantee, this.QuotTransCharges, this.QuotInsurance, this.QuotErrec, this.QuotJurisdiction, this.QuotValidity, this.QuotInspection, this.QuotOtherSpecs, this.QuotRespId, this.QuotSalespId, this.QuotPreparedBy, this.QuotCheckedBy, this.QuotApprovedBy, this.CurrencyId, this.QuotVAT, this.QuotDDNo, this.QuotDDDate, this.QuotBankName, this.IsExpectedOrder, this.QuotTotalEMDCharges, this.QuotFOB, this.QuotCIF, this.QuotId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string SalesQuotation_Delete(string QuotationId)
        //    {
        //        SM.BeginTransaction();
        //        if (DeleteRecord("[YANTRA_QUOT_FOLLOWUP_DET]", "QUOT_ID", QuotationId) == true)
        //        {
        //            if (DeleteRecord("[YANTRA_QUOT_DET]", "QUOT_ID", QuotationId) == true)
        //            {
        //                if (DeleteRecord("[YANTRA_QUOT_MAST]", "QUOT_ID", QuotationId) == true)
        //                {
        //                    SM.CommitTransaction();
        //                    _returnStringMessage = "Data Deleted Successfully";
        //                }
        //                else
        //                {
        //                    SM.RollBackTransaction();
        //                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
        //                }
        //            }
        //            else
        //            {
        //                SM.RollBackTransaction();
        //                _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
        //            }
        //        }
        //        else
        //        {
        //            SM.RollBackTransaction();
        //            _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string SalesQuotationDetails_Save()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [YANTRA_QUOT_DET] SELECT ISNULL(MAX(QUOT_DET_ID),0)+1,{0},{1},'{2}','{3}','{4}','{5}' FROM [YANTRA_QUOT_DET]", this.QuotId, this.QuotDetItemCode, this.QuotDetQty, this.QuotRate, this.QuotDetDisc, this.QuotDetSpPrice);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public int SalesQuotationDetails_Delete(string QuotationId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("DELETE FROM [YANTRA_QUOT_DET] WHERE QUOT_ID={0}", QuotationId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        return _returnIntValue;
        //    }

        //    public static int IsSalesQuotationRaised(string EnquiryId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = "SELECT COUNT(*) FROM [YANTRA_QUOT_MAST] WHERE ENQ_ID=" + EnquiryId + "";
        //        _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString());
        //        return _returnIntValue;
        //    }

        //    public static int GetSalesQuotationId(string EnquiryId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = "SELECT QUOT_ID FROM [YANTRA_QUOT_MAST] WHERE ENQ_ID=" + EnquiryId + " ORDER BY QUOT_ID DESC";
        //        _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString());
        //        return _returnIntValue;
        //    }

        //    public int SalesQuotation_Select(string QuotationId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST],[YANTRA_LKUP_ENQ_MODE],[YANTRA_CUSTOMER_MAST],[YANTRA_QUOT_MAST]  WHERE [YANTRA_ENQ_MAST].ENQM_ID=[YANTRA_LKUP_ENQ_MODE].ENQM_ID AND [YANTRA_QUOT_MAST].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID AND" +
        //                                    " [YANTRA_ENQ_MAST].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID AND [YANTRA_QUOT_MAST].QUOT_ID='" + QuotationId + "' ORDER BY [YANTRA_QUOT_MAST].QUOT_ID DESC ");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.QuotId = dbManager.DataReader["QUOT_ID"].ToString();
        //            this.QuotNo = dbManager.DataReader["QUOT_NO"].ToString();
        //            this.QuotDate = Convert.ToDateTime(dbManager.DataReader["QUOT_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.EnqId = dbManager.DataReader["ENQ_ID"].ToString();
        //            this.EnqNo = dbManager.DataReader["ENQ_NO"].ToString();
        //            this.CustId = dbManager.DataReader["CUST_ID"].ToString();
        //            this.CustUnitId = dbManager.DataReader["CUST_UNIT_ID"].ToString();
        //            this.CustDetId = dbManager.DataReader["CUST_DET_ID"].ToString();
        //            this.QuotDelivery = dbManager.DataReader["QUOT_DELIVERY"].ToString();
        //            this.QuotPayTerms = dbManager.DataReader["QUOT_PAY_TERM"].ToString();
        //            this.QuotPackCharges = dbManager.DataReader["QUOT_PACK_CHARGES"].ToString();
        //            this.QuotExcise = dbManager.DataReader["QUOT_EXCISE"].ToString();
        //            this.QuotCST = dbManager.DataReader["QUOT_CST"].ToString();
        //            this.DespmId = dbManager.DataReader["DESPM_ID"].ToString();
        //            this.QuotGuarantee = dbManager.DataReader["QUOT_GUARANTEE"].ToString();
        //            this.QuotTransCharges = dbManager.DataReader["QUOT_TRANS_CHARGES"].ToString();
        //            this.QuotInsurance = dbManager.DataReader["QUOT_INSURANCE"].ToString();
        //            this.QuotErrec = dbManager.DataReader["QUOT_EREC_COMM"].ToString();
        //            this.QuotJurisdiction = dbManager.DataReader["QUOT_JURISDICTION"].ToString();
        //            this.QuotValidity = dbManager.DataReader["QUOT_VALIDITY"].ToString();
        //            this.QuotInspection = dbManager.DataReader["QUOT_INSPECTION"].ToString();
        //            this.QuotOtherSpecs = dbManager.DataReader["QUOT_OTHER_SPEC"].ToString();
        //            this.QuotPOLog = dbManager.DataReader["QUOT_PO_FLAG"].ToString();
        //            this.QuotRespId = dbManager.DataReader["QUOT_RESP_ID"].ToString();
        //            this.QuotSalespId = dbManager.DataReader["QUOT_SALESP_ID"].ToString();
        //            this.QuotPreparedBy = dbManager.DataReader["QUOT_PREPARED_BY"].ToString();
        //            this.QuotCheckedBy = dbManager.DataReader["QUOT_CHECKED_BY"].ToString();
        //            this.QuotApprovedBy = dbManager.DataReader["QUOT_APPROVED_BY"].ToString();
        //            this.CurrencyId = dbManager.DataReader["CURRENCY_ID"].ToString();
        //            this.QuotVAT = dbManager.DataReader["QUOT_VAT"].ToString();
        //            this.QuotDDNo = dbManager.DataReader["QUOT_DD_NO"].ToString();
        //            this.QuotDDDate = Convert.ToDateTime(dbManager.DataReader["QUOT_DD_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.QuotBankName = dbManager.DataReader["QUOT_BANK_NAME"].ToString();
        //            this.QuotTotalEMDCharges = dbManager.DataReader["QUOT_EMD_CHARGES"].ToString();
        //            this.QuotFOB = dbManager.DataReader["QUOT_FOB"].ToString();
        //            this.QuotCIF = dbManager.DataReader["QUOT_CIF"].ToString();
        //            this.IsExpectedOrder = bool.Parse(dbManager.DataReader["IS_EXPECTED_ORDER"].ToString());

        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        return _returnIntValue;
        //    }

        //    public string SalesQuotationFollowUp_Save()
        //    {
        //        this.QuotFollowUpDetId = AutoGenMaxId("[YANTRA_QUOT_FOLLOWUP_DET]", "QUOT_FOLLOWUP_DET_ID");
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT  INTO [YANTRA_QUOT_FOLLOWUP_DET] VALUES({0},{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}')", this.QuotFollowUpDetId, this.QuotId, this.FollowUpEmpId, this.FollowUpDesc, this.FollowUpDate, this.FollowUpTechDiss, this.FollowUpCommNegos, this.FollowUpCompExistance, this.FollowUpRemarks, this.FollowUpExpDate);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string SalesQuotationApprove_Update()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT  QUOT_PO_FLAG FROM [YANTRA_QUOT_MAST] WHERE QUOT_ID='{0}'", this.QuotId);
        //        if (dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString() == SMStatus.Closed.ToString() || dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString() == SMStatus.Cancelled.ToString())
        //        {
        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _commandText = string.Format("UPDATE [YANTRA_QUOT_MAST] SET QUOT_APPROVED_BY={0},QUOT_PO_FLAG='{1}' WHERE QUOT_ID='{2}'", this.QuotApprovedBy, SMStatus.Open, QuotId);
        //            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        }
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Status Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string SalesQuotationRegret_Update()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT  QUOT_PO_FLAG FROM [YANTRA_QUOT_MAST] WHERE QUOT_ID='{0}'", this.QuotId);
        //        if (dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString() == SMStatus.Closed.ToString() || dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString() == SMStatus.Cancelled.ToString())
        //        {
        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _commandText = string.Format("UPDATE [YANTRA_QUOT_MAST] SET QUOT_APPROVED_BY={0},QUOT_PO_FLAG='{1}' WHERE QUOT_ID='{2}'", this.QuotApprovedBy, SMStatus.Regret, QuotId);
        //            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        }
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Status Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public static string SalesQuotationStatus_Update(SMStatus Status, string QuotId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT  QUOT_PO_FLAG FROM [YANTRA_QUOT_MAST] WHERE QUOT_ID='{0}'", QuotId);
        //        if (dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString() == SMStatus.Closed.ToString() || dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString() == SMStatus.Cancelled.ToString())
        //        {
        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _commandText = string.Format("UPDATE [YANTRA_QUOT_MAST] SET QUOT_PO_FLAG='{0}' WHERE QUOT_ID='{1}'", Status, QuotId);
        //            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        }
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Status Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public void SalesQuotationDetails_Select(string QuotationId, GridView gv)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_QUOT_DET],[YANTRA_ITEM_MAST],[YANTRA_LKUP_UOM],[YANTRA_LKUP_ITEM_TYPE] WHERE [YANTRA_QUOT_DET].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE AND " +
        //                                       "[YANTRA_ITEM_MAST].UOM_ID=[YANTRA_LKUP_UOM].UOM_ID AND [YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID=[YANTRA_ITEM_MAST].IT_TYPE_ID AND [YANTRA_QUOT_DET].QUOT_ID=" + QuotationId + "");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);

        //        DataTable SalesQuotationItems = new DataTable();
        //        DataColumn col = new DataColumn();
        //        col = new DataColumn("ItemCode");
        //        SalesQuotationItems.Columns.Add(col);
        //        col = new DataColumn("ItemType");
        //        SalesQuotationItems.Columns.Add(col);
        //        col = new DataColumn("ItemName");
        //        SalesQuotationItems.Columns.Add(col);
        //        col = new DataColumn("UOM");
        //        SalesQuotationItems.Columns.Add(col);
        //        col = new DataColumn("Quantity");
        //        SalesQuotationItems.Columns.Add(col);
        //        col = new DataColumn("Rate");
        //        SalesQuotationItems.Columns.Add(col);
        //        col = new DataColumn("ItemTypeId");
        //        SalesQuotationItems.Columns.Add(col);
        //        col = new DataColumn("Discount");
        //        SalesQuotationItems.Columns.Add(col);
        //        col = new DataColumn("SpPrice");
        //        SalesQuotationItems.Columns.Add(col);

        //        while (dbManager.DataReader.Read())
        //        {
        //            DataRow dr = SalesQuotationItems.NewRow();
        //            dr["ItemCode"] = dbManager.DataReader["ITEM_CODE"].ToString();
        //            dr["ItemName"] = dbManager.DataReader["ITEM_NAME"].ToString();
        //            dr["UOM"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
        //            dr["Quantity"] = dbManager.DataReader["QUOT_DET_QTY"].ToString();
        //            dr["Rate"] = dbManager.DataReader["QUOT_RATE"].ToString();
        //            dr["ItemType"] = dbManager.DataReader["IT_TYPE"].ToString();
        //            dr["ItemTypeId"] = dbManager.DataReader["IT_TYPE_ID"].ToString();
        //            dr["Discount"] = dbManager.DataReader["QUOT_DISC"].ToString();
        //            dr["SpPrice"] = dbManager.DataReader["QUOT_SPPRICE"].ToString();
        //            SalesQuotationItems.Rows.Add(dr);
        //        }

        //        gv.DataSource = SalesQuotationItems;
        //        gv.DataBind();
        //    }

        //    public static void SalesQuotation_Select(Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT *,QUOT_NO+' '+QUOT_REVISED_KEY AS QUOTNO FROM [YANTRA_QUOT_MAST] ORDER BY QUOT_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "QUOTNO", "QUOT_ID");
        //        }
        //    }

        //    public static void SalesQuotation_Select(Control ControlForBind, int company_id)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = " SELECT *,QUOT_NO+' '+QUOT_REVISED_KEY AS QUOTNO FROM [YANTRA_QUOT_MAST] where  enq_id  in " +
        //                       " (select enq_id from yantra_enq_mast where cust_id =" + company_id + ")ORDER BY QUOT_ID";

        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "QUOTNO", "QUOT_ID");
        //        }
        //    }

        //    public static void SalesQuotation_Select(Control ControlForBind, string EmployeeId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT *,QUOT_NO+' '+QUOT_REVISED_KEY AS QUOTNO FROM [YANTRA_ENQ_MAST]  inner join [YANTRA_QUOT_MAST] on [YANTRA_ENQ_MAST].ENQ_ID=[YANTRA_QUOT_MAST].ENQ_ID left outer join [YANTRA_ENQ_ASSIGN_TASKS] on YANTRA_ENQ_ASSIGN_TASKS.ENQ_ID = YANTRA_ENQ_MAST.ENQ_ID left outer join [YANTRA_EMPLOYEE_MAST] FORASSIGN on FORASSIGN.EMP_ID=[YANTRA_ENQ_ASSIGN_TASKS].EMP_ID  where [YANTRA_ENQ_ASSIGN_TASKS].EMP_ID=" + EmployeeId + " ORDER BY QUOT_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "QUOTNO", "QUOT_ID");
        //        }
        //    }

        //    public int Get_Ids_Select(string QuotationId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST],[YANTRA_ENQ_ASSIGN_TASKS],[YANTRA_LKUP_ENQ_MODE],[YANTRA_CUSTOMER_MAST],[YANTRA_QUOT_MAST]  WHERE [YANTRA_ENQ_MAST].ENQM_ID=[YANTRA_LKUP_ENQ_MODE].ENQM_ID AND [YANTRA_QUOT_MAST].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID AND [YANTRA_ENQ_ASSIGN_TASKS].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID AND " +
        //                                    " [YANTRA_ENQ_MAST].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID AND [YANTRA_QUOT_MAST].QUOT_ID='" + QuotationId + "' ORDER BY [YANTRA_QUOT_MAST].QUOT_ID DESC ");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.QuotId = dbManager.DataReader["QUOT_ID"].ToString();
        //            this.AssignTaskId = dbManager.DataReader["ASSIGN_TASK_ID"].ToString();
        //            this.EnqId = dbManager.DataReader["ENQ_ID"].ToString();
        //            this.CustId = dbManager.DataReader["CUST_ID"].ToString();
        //            this.DespmId = dbManager.DataReader["DESPM_ID"].ToString();

        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        dbManager.DataReader.Close();
        //        return _returnIntValue;

        //    }

        //    public static void SalesQuotationItemTypes_Select(string QuotationId, Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT distinct([YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID),([YANTRA_LKUP_ITEM_TYPE].IT_TYPE) FROM [YANTRA_QUOT_DET],[YANTRA_LKUP_ITEM_TYPE],[YANTRA_ITEM_MAST] WHERE [YANTRA_QUOT_DET].ITEM_CODE in ([YANTRA_ITEM_MAST].ITEM_CODE) AND [YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID=[YANTRA_ITEM_MAST].IT_TYPE_ID AND  [YANTRA_QUOT_DET].QUOT_ID=" + QuotationId + "");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "IT_TYPE", "IT_TYPE_ID");
        //        }
        //    }

        //    public static void SalesQuotationItemNames_Select(string QuotationId, string ItemTypeId, Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_QUOT_DET],[YANTRA_LKUP_ITEM_TYPE],[YANTRA_ITEM_MAST] WHERE [YANTRA_QUOT_DET].ITEM_CODE in ([YANTRA_ITEM_MAST].ITEM_CODE) AND [YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID=[YANTRA_ITEM_MAST].IT_TYPE_ID AND [YANTRA_QUOT_DET].QUOT_ID=" + QuotationId + " AND [YANTRA_ITEM_MAST].IT_TYPE_ID=" + ItemTypeId + "");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "ITEM_NAME", "ITEM_CODE");
        //        }
        //    }

        //    public int TenderWithQuotationRaised_Select(string EnquiryId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT TOP 1 * FROM [YANTRA_ENQ_MAST],[YANTRA_LKUP_ENQ_MODE],[YANTRA_CUSTOMER_MAST],[YANTRA_QUOT_MAST] WHERE [YANTRA_ENQ_MAST].ENQM_ID=[YANTRA_LKUP_ENQ_MODE].ENQM_ID AND [YANTRA_ENQ_MAST].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID AND [YANTRA_LKUP_ENQ_MODE].ENQM_NAME='TENDER' AND [YANTRA_QUOT_MAST].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID AND  [YANTRA_ENQ_MAST].ENQ_ID='" + EnquiryId + "' ORDER BY [YANTRA_QUOT_MAST].QUOT_REVISED_KEY DESC");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.EnqId = dbManager.DataReader["ENQ_ID"].ToString();
        //            this.EnqNo = dbManager.DataReader["ENQ_NO"].ToString();
        //            this.EnqDate = Convert.ToDateTime(dbManager.DataReader["ENQ_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.CustId = dbManager.DataReader["CUST_ID"].ToString();
        //            this.QuotDDNo = dbManager.DataReader["QUOT_DD_NO"].ToString();
        //            this.QuotDDDate = Convert.ToDateTime(dbManager.DataReader["QUOT_DD_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.QuotBankName = dbManager.DataReader["QUOT_BANK_NAME"].ToString();
        //            this.QuotTotalEMDCharges = dbManager.DataReader["QUOT_EMD_CHARGES"].ToString();
        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        return _returnIntValue;
        //    }
        //}

        //Methods for Sales Assignments
        public class SalesAssignments
        {
            public string EnqId, EnqNo, EnqDate, EmpId, AssignTaskId, AssignTaskNo, AssingDate, DueDate, AssignRemarks, AssignStatus, CustId, EnqAssignFollowUpDet_Id, FollowUpEmpId, FollowUpDate, FollowUpDesc;

            public SalesAssignments()
            {
            }

            public static string SalesAssignments_AutoGenCode()
            {
                //string _codePrefix = CurrentFinancialYear() + " ";
                //if (dbManager.Transaction == null)
                //    dbManager.Open();
                //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(CONVERT(BIGINT,REPLACE(ASSIGN_TASK_NO,LEFT(ASSIGN_TASK_NO,5),''))),0)+1 FROM [YANTRA_ENQ_ASSIGN_TASKS]").ToString());
                ////_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(REPLACE(ASSIGN_TASK_NO,'" + _codePrefix + "','')),0)+1 FROM [YANTRA_ENQ_ASSIGN_TASKS]").ToString());
                //return _codePrefix + _returnIntValue;
                return AutoGenMaxNo("YANTRA_ENQ_ASSIGN_TASKS", "ASSIGN_TASK_NO");
            }

            public string SalesAssignments_Save()
            {
                this.AssignTaskNo = SalesAssignments_AutoGenCode();
                this.AssignTaskId = AutoGenMaxId("[YANTRA_ENQ_ASSIGN_TASKS]", "ASSIGN_TASK_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT  INTO [YANTRA_ENQ_ASSIGN_TASKS] VALUES({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}')", this.AssignTaskId, this.AssignTaskNo, this.EnqId, this.EmpId, this.AssingDate, this.DueDate, this.AssignRemarks, this.AssignStatus);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesAssignments_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_ENQ_ASSIGN_TASKS] SET  EMP_ID={0},ASSIGN_DATE='{1}',DUE_DATE='{2}',REMARKS='{3}' WHERE ENQ_ID={4}", this.EmpId, this.AssingDate, this.DueDate, this.AssignRemarks, this.EnqId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesAssignments_Delete(string AssignTaskId)
            {
                if (DeleteRecord("[YANTRA_ENQ_ASSIGN_TASKS]", "ASSIGN_TASK_ID", AssignTaskId) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public static string SalesAssignmentsStatus_Update(SMStatus Status, string AssignTaskId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_ENQ_ASSIGN_TASKS] SET  ASSIGN_STATUS='{0}' WHERE ASSIGN_TASK_ID='{1}'", Status, AssignTaskId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesAssignmentsFollowUp_Save()
            {
                this.EnqAssignFollowUpDet_Id = AutoGenMaxId("[YANTRA_ENQ_ASSIGN_FOLLOWUP_DET]", "ENQ_ASSIGN_FOLLOWUP_DET_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT  INTO [YANTRA_ENQ_ASSIGN_FOLLOWUP_DET] VALUES({0},{1},{2},'{3}','{4}')", this.EnqAssignFollowUpDet_Id, this.AssignTaskId, this.FollowUpEmpId, this.FollowUpDesc, this.FollowUpDate);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int SalesAssignments_Select(string EnquiryId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST],[YANTRA_ENQ_ASSIGN_TASKS],[YANTRA_CUSTOMER_MAST] WHERE [YANTRA_ENQ_MAST].ENQ_ID=[YANTRA_ENQ_ASSIGN_TASKS].ENQ_ID AND [YANTRA_CUSTOMER_MAST].CUST_ID= [YANTRA_ENQ_MAST].CUST_ID AND " +
                                            " [YANTRA_ENQ_MAST].ENQ_ID ='" + EnquiryId + "' ORDER BY [YANTRA_ENQ_ASSIGN_TASKS].ASSIGN_TASK_ID DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.AssignTaskId = dbManager.DataReader["ASSIGN_TASK_ID"].ToString();
                    this.AssignTaskNo = dbManager.DataReader["ASSIGN_TASK_NO"].ToString();
                    this.EnqId = dbManager.DataReader["ENQ_ID"].ToString();
                    this.EnqNo = dbManager.DataReader["ENQ_NO"].ToString();
                    this.EnqDate = Convert.ToDateTime(dbManager.DataReader["ENQ_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.EmpId = dbManager.DataReader["EMP_ID"].ToString();
                    this.AssingDate = Convert.ToDateTime(dbManager.DataReader["ASSIGN_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.DueDate = Convert.ToDateTime(dbManager.DataReader["DUE_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.AssignRemarks = dbManager.DataReader["REMARKS"].ToString();
                    this.AssignStatus = dbManager.DataReader["ASSIGN_STATUS"].ToString();
                    this.CustId = dbManager.DataReader["CUST_ID"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            //public int SalesAssignmentsFollowUp_Select(string AssignTaskId)
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();
            //    _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_ASSIGN_FOLLOWUP_DET],[YANTRA_ENQ_ASSIGN_TASKS] WHERE [YANTRA_ENQ_ASSIGN_FOLLOWUP_DET].ASSIGN_TASK_ID=[YANTRA_ENQ_ASSIGN_TASKS].ASSIGN_TASK_ID AND " +
            //                                " [YANTRA_ENQ_ASSIGN_TASKS].ASSIGN_TASK_ID ='" + AssignTaskId + "' ORDER BY [YANTRA_ENQ_ASSIGN_FOLLOWUP_DET].ENQ_ASSIGN_FOLLOWUP_DET_ID DESC ");
            //    dbManager.ExecuteReader(CommandType.Text, _commandText);
            //    if (dbManager.DataReader.Read())
            //    {
            //        this.AssignTaskId = dbManager.DataReader["ASSIGN_TASK_ID"].ToString();
            //        this.AssignTaskNo = dbManager.DataReader["ASSIGN_TASK_NO"].ToString();
            //        this.EnqId = dbManager.DataReader["ENQ_ID"].ToString();
            //        this.FollowUpEmpId = dbManager.DataReader["EMP_ID"].ToString();
            //        this.FollowUpDate = dbManager.DataReader["FU_DATE"].ToString();
            //        this.FollowUpDesc = dbManager.DataReader["FU_DESC"].ToString();
            //        _returnIntValue = 1;
            //    }
            //    else
            //    {
            //        _returnIntValue = 0;
            //    }
            //    return _returnIntValue;
            //}

            public static void SalesAssignments_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_ASSIGN_TASKS] ORDER BY ASSIGN_TASK_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "ASSIGN_TASK_NO", "ASSIGN_TASK_ID");
                }
            }
        }

        ////Methods For Sales Order Form
        //public class SalesOrder
        //{
        //    private DataSet ds;
        //    private DataTable dt;
        //    private SqlCommand SqlCmd;
        //    private SqlConnection SqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString.ToString());
        //    private SqlDataAdapter SqlDap;
        //    private int status;
        //    private string strStatus;
        //    private SqlTransaction trns;

        //    public string SOId, SONo, SODate, QuotId, QuotNo, CustId, SORespId, SOSalespId, SOPreparedBy, SOCheckedBy, SOApprovedBy, SOAcceptanceFlag, SODelivery, SOCurrencyTypeId, SOPackageCharges, SOPaymentTerms, SOCSTax, SOExciseDuty, SOGuarantee, DespmId, SOInsurance, SOTransportCharges, SOJurisdiction, SOErection, SOInspection, SOValidity, SOOtherSpec, EnqId, AssignTaskId, ContactName1, ContactPhone1, ContactEmail1, ContactName2, ContactPhone2, ContactEmail2, ConsignmentTo, InvoiceTo, ContactDesig1, ContactDesig2, SOAdvanceAmt, SOFLag, SOFiles, SOVAT, SOAccessories, SOExtraSpares, SOCustPONo, SOCustPODated, SOCSTNo, SOTINNo;
        //    public string SODetId, SOItemCode, SODetQty, SORate, SODetSpec, SODetRemarks, SODetPriority, SODetDeliveryStatus, DieId;
        //    public string itemcatid, itemsubid, cutlen, weightrange, totalweight, sectionid, CUSTID;
        //    public string SOUploadId, SOUploadFileName, SOUploadDate;

        //    public string CustomerName, Region, Address, Phone, Email, Mobile, CustomerCompany, CustomerAddress;

        //    public enum SOItemStatus { PartiallyDelivered = 0, Delivered = 1, }

        //    public SalesOrder()
        //    {
        //    }

        //    public static string SalesOrder_AutoGenCode()
        //    {
        //        return AutoGenMaxNo("YANTRA_SO_MAST", "SO_NO");
        //    }

        //    public string SalesOrder_Save()
        //    {
        //        //this.SONo = SalesOrder_AutoGenCode();
        //        this.SOId = AutoGenMaxId("[YANTRA_SO_MAST]", "SO_ID");
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [YANTRA_SO_MAST] SELECT ISNULL(MAX(SO_ID),0)+1,'{0}','{1}',{2},{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',{14},{15},'{16}','{17}','{18}','{19}',{20} FROM [YANTRA_SO_MAST]", this.SONo, this.SODate, this.SOPreparedBy, this.SOCheckedBy, this.SOApprovedBy, this.SOAcceptanceFlag, this.ContactName1, this.ContactPhone1, this.ContactEmail1, this.ContactName2, this.ContactPhone2, this.ContactEmail2, this.ConsignmentTo, this.InvoiceTo, this.ContactDesig1, this.ContactDesig2, this.SOCustPONo, this.SOCustPODated, this.SOCSTNo, this.SOTINNo, this.CUSTID);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string SalesOrder_Update()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [YANTRA_SO_MAST] SET SO_DATE='{0}',SO_PREPARED_BY='{1}',SO_CHECKED_BY='{2}',SO_APPROVED_BY='{3}',SO_CONTACT_NAME1='{4}',SO_CONTACT_PHONE1='{5}',SO_CONTACT_EMAIL1='{6}',SO_CONTACT_NAME2='{7}',SO_CONTACT_PHONE2='{8}',SO_CONTACT_EMAIL2='{9}',SO_CONSIGNMENT_TO='{10}',SO_INVOICE_TO='{11}',SO_DESIGNATION1={12},SO_DESIGNATION2={13},SO_CUST_PO_NO='{14}',SO_CUST_PO_DATED='{15}',SO_CST_NO='{16}',SO_TIN_NO='{17}',SO_CUST_ID = {18} WHERE SO_ID='{19}'", this.SODate, this.SOPreparedBy, this.SOCheckedBy, this.SOApprovedBy, this.ContactName1, this.ContactPhone1, this.ContactEmail1, this.ContactName2, this.ContactPhone2, this.ContactEmail2, this.ConsignmentTo, this.InvoiceTo, this.ContactDesig1, this.ContactDesig2, this.SOCustPONo, this.SOCustPODated, this.SOCSTNo, this.SOTINNo, this.CUSTID, this.SOId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string SalesOrder_Delete(string SalesOrderId)
        //    {
        //        SM.BeginTransaction();
        //        if (DeleteRecord("[YANTRA_SO_DET]", "SO_ID", SalesOrderId) == true)
        //        {
        //            if (DeleteRecord("[YANTRA_SO_MAST]", "SO_ID", SalesOrderId) == true)
        //            {
        //                SM.CommitTransaction();
        //                _returnStringMessage = "Data Deleted Successfully";
        //            }
        //            else
        //            {
        //                SM.RollBackTransaction();
        //                _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
        //            }
        //        }
        //        else
        //        {
        //            SM.RollBackTransaction();
        //            _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string SalesOrderDetails_Save()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [YANTRA_SO_DET] SELECT ISNULL(MAX(SO_DET_ID),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},{11} FROM [YANTRA_SO_DET]", this.SOId, this.itemcatid, this.itemsubid, this.SORate, this.SODetSpec, this.SODetRemarks, this.SODetPriority, this.cutlen, this.weightrange, this.totalweight, this.sectionid, this.DieId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public int SalesOrderDetails_Delete(string SalesOrderId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("DELETE FROM [YANTRA_SO_DET] WHERE SO_ID={0}", SalesOrderId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        return _returnIntValue;
        //    }

        //    public int SalesOrder_Select(string SalesOrderId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_CUSTOMER_MAST],[YANTRA_SO_MAST],YANTRA_LKUP_REGION WHERE  [YANTRA_SO_MAST].SO_CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID AND YANTRA_LKUP_REGION.REG_ID = YANTRA_CUSTOMER_MAST.REG_ID and [YANTRA_SO_MAST].SO_ID='" + SalesOrderId + "' ORDER BY [YANTRA_SO_MAST].SO_ID DESC ");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.SOId = dbManager.DataReader["SO_ID"].ToString();
        //            this.SONo = dbManager.DataReader["SO_NO"].ToString();
        //            this.SODate = Convert.ToDateTime(dbManager.DataReader["SO_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.CustId = dbManager.DataReader["CUST_ID"].ToString();

        //            this.SOPreparedBy = dbManager.DataReader["SO_PREPARED_BY"].ToString();
        //            this.SOCheckedBy = dbManager.DataReader["SO_CHECKED_BY"].ToString();
        //            this.SOApprovedBy = dbManager.DataReader["SO_APPROVED_BY"].ToString();
        //            this.SOAcceptanceFlag = dbManager.DataReader["SO_ACCEPTANCE_FLAG"].ToString();

        //            this.ContactName1 = dbManager.DataReader["SO_CONTACT_NAME1"].ToString();
        //            this.ContactPhone1 = dbManager.DataReader["SO_CONTACT_PHONE1"].ToString();
        //            this.ContactEmail1 = dbManager.DataReader["SO_CONTACT_EMAIL1"].ToString();
        //            this.ContactName2 = dbManager.DataReader["SO_CONTACT_NAME2"].ToString();
        //            this.ContactPhone2 = dbManager.DataReader["SO_CONTACT_PHONE2"].ToString();
        //            this.ContactEmail2 = dbManager.DataReader["SO_CONTACT_EMAIL2"].ToString();
        //            this.ConsignmentTo = dbManager.DataReader["SO_CONSIGNMENT_TO"].ToString();
        //            this.InvoiceTo = dbManager.DataReader["SO_INVOICE_TO"].ToString();
        //            this.ContactDesig1 = dbManager.DataReader["SO_DESIGNATION1"].ToString();
        //            this.ContactDesig2 = dbManager.DataReader["SO_DESIGNATION2"].ToString();

        //            this.CustomerName = dbManager.DataReader["CUST_NAME"].ToString();
        //            this.Mobile = dbManager.DataReader["CUST_MOBILE"].ToString();
        //            this.Phone = dbManager.DataReader["CUST_PHONE"].ToString();
        //            this.Region = dbManager.DataReader["REG_NAME"].ToString();
        //            this.Email = dbManager.DataReader["CUST_EMAIL"].ToString();
        //            this.Address = dbManager.DataReader["CUST_ADDRESS"].ToString();
        //            this.CustomerCompany = dbManager.DataReader["CUST_COMPANY_NAME"].ToString();
        //            this.CustomerAddress = dbManager.DataReader["CUST_ADDRESS"].ToString();
        //            this.SOCustPONo = dbManager.DataReader["SO_CUST_PO_NO"].ToString();
        //            this.SOCustPODated = Convert.ToDateTime(dbManager.DataReader["SO_CUST_PO_DATED"].ToString()).ToString("dd/MM/yyyy");
        //            if (this.SOCustPODated == "01/01/1900") { this.SOCustPODated = ""; }
        //            this.SOCSTNo = dbManager.DataReader["SO_CST_NO"].ToString();
        //            this.SOTINNo = dbManager.DataReader["SO_TIN_NO"].ToString();

        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        return _returnIntValue;
        //    }

        //    public DataTable ReturnDataTable(string Query)
        //    {
        //        DataTable table = new DataTable();
        //        try
        //        {
        //            this.SqlDap = new SqlDataAdapter(Query, this.SqlCon);
        //            this.ds = new DataSet();
        //            this.SqlDap.Fill(this.ds);
        //            table = this.ds.Tables[0];
        //        }
        //        catch
        //        {
        //            //table = this.ErrorDataTable(exception.Message);
        //        }
        //        finally
        //        {
        //            this.SqlCon.Close();
        //            this.SqlDap.Dispose();
        //            this.ds.Dispose();
        //        }
        //        return table;
        //    }

        //    public static string SalesOrderStatus_Update(SMStatus Status, string SOId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [YANTRA_SO_MAST] SET  SO_ACCEPTANCE_FLAG='{0}' WHERE SO_ID='{1}'", Status, SOId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Status Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public void SalesOrderDetails_Select(string SalesOrderId, GridView gv)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        //_commandText = string.Format("SELECT * FROM [YANTRA_ITEM_MASTER],[YANTRA_SO_DET],[YANTRA_LKUP_ITEM_TYPE],YANTRA_LKUP_ITEM_CATEGORY WHERE [YANTRA_SO_DET].Itemcategory_Id=[YANTRA_LKUP_ITEM_CATEGORY].ITEM_CATEGORY_ID AND " +
        //        //                               "[YANTRA_ITEM_MASTER].Item_Master_Id=[YANTRA_SO_DET].SECTION_ID AND [YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID=[YANTRA_SO_DET].ItemSubcategory_Id  AND [YANTRA_SO_DET].SO_ID=" + SalesOrderId);

        //        _commandText = string.Format("SELECT * FROM [YANTRA_ITEM_MASTER],[YANTRA_SO_DET],[YANTRA_LKUP_ITEM_TYPE],YANTRA_LKUP_ITEM_CATEGORY,Die_Room WHERE [YANTRA_SO_DET].Itemcategory_Id=[YANTRA_LKUP_ITEM_CATEGORY].ITEM_CATEGORY_ID AND " +
        //                                      "[YANTRA_ITEM_MASTER].Item_Master_Id=[YANTRA_SO_DET].SECTION_ID AND [YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID=[YANTRA_SO_DET].ItemSubcategory_Id  AND Die_Room.Die_id = YANTRA_SO_DET.DieId and [YANTRA_SO_DET].SO_ID=" + SalesOrderId);

        //        dbManager.ExecuteReader(CommandType.Text, _commandText);

        //        DataTable SalesOrderItems = new DataTable();
        //        DataColumn col = new DataColumn();
        //        col = new DataColumn("ItemCategory");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("ItemSubcategory");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Section");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Cutlength");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Description");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Weightrange");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("TotalWeight");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Price");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Priority");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Remarks");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("ItemCatId");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("ItemSubId");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("SectionId");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("DieId");
        //        SalesOrderItems.Columns.Add(col);

        //        while (dbManager.DataReader.Read())
        //        {
        //            DataRow dr = SalesOrderItems.NewRow();

        //            dr["ItemCategory"] = dbManager.DataReader["ITEM_CATEGORY_NAME"].ToString();
        //            dr["ItemSubcategory"] = dbManager.DataReader["IT_TYPE"].ToString();
        //            dr["Section"] = dbManager.DataReader["Die_Name"].ToString();
        //            dr["Cutlength"] = dbManager.DataReader["CUTLENGTH"].ToString();
        //            dr["Description"] = dbManager.DataReader["SO_DET_SPEC"].ToString();
        //            dr["Weightrange"] = dbManager.DataReader["WEIGHTRANGE"].ToString();
        //            dr["TotalWeight"] = dbManager.DataReader["TOTALWEIGHT"].ToString();
        //            dr["Price"] = dbManager.DataReader["SO_RATE"].ToString();
        //            dr["Priority"] = dbManager.DataReader["SO_DET_PRIORITY"].ToString();
        //            dr["Remarks"] = dbManager.DataReader["SO_DET_REMARKS"].ToString();
        //            dr["ItemCatId"] = dbManager.DataReader["Itemcategory_Id"].ToString();
        //            dr["ItemSubId"] = dbManager.DataReader["ItemSubcategory_Id"].ToString();
        //            dr["SectionId"] = dbManager.DataReader["SECTION_ID"].ToString();
        //            dr["DieId"] = dbManager.DataReader["DieId"].ToString();
        //            //dr["kiran"] = dbManager.DataReader["Die_Name"].ToString();

        //            SalesOrderItems.Rows.Add(dr);
        //        }

        //        gv.DataSource = SalesOrderItems;
        //        gv.DataBind();
        //    }

        //    public void ProductionDetails_Select(string SalesOrderId, GridView gv)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_SO_DET],YANTRA_SO_MAST,YANTRA_CUSTOMER_MAST where  [YANTRA_SO_DET].SO_ID=[YANTRA_SO_MAST].SO_ID AND " +
        //                                       "[YANTRA_SO_MAST].SO_CUST_ID =[YANTRA_CUSTOMER_MAST].CUST_ID AND [YANTRA_SO_DET].SO_ID=" + SalesOrderId);
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);

        //        DataTable SalesOrderItems = new DataTable();
        //        DataColumn col = new DataColumn();

        //        col = new DataColumn("CutLength");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Description");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("WT.Range");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Quantity");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("PartyName");
        //        SalesOrderItems.Columns.Add(col);

        //        while (dbManager.DataReader.Read())
        //        {
        //            DataRow dr = SalesOrderItems.NewRow();

        //            dr["CutLength"] = dbManager.DataReader["CUTLENGTH"].ToString();
        //            dr["Description"] = dbManager.DataReader["SO_DET_SPEC"].ToString();
        //            dr["WT.Range"] = dbManager.DataReader["WEIGHTRANGE"].ToString();
        //            dr["Quantity"] = dbManager.DataReader["TOTALWEIGHT"].ToString();
        //            dr["PartyName"] = dbManager.DataReader["CUST_NAME"].ToString();

        //            SalesOrderItems.Rows.Add(dr);
        //        }

        //        gv.DataSource = SalesOrderItems;
        //        gv.DataBind();
        //    }

        //    public static string SalesOrderDetailsItemStatus_Update(SOItemStatus Status, string SODetId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [YANTRA_SO_DET] SET  SO_DET_DELIVERY_STATUS='{0}' WHERE SO_DET_ID='{1}'", Status, SODetId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Status Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public static string SalesOrderDetailsItemStatusReset_Update(string SODetId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [YANTRA_SO_DET] SET  SO_DET_DELIVERY_STATUS='-' WHERE SO_DET_ID='{0}'", SODetId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Status Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string SalesOrderApprove_Update()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT  SO_ACCEPTANCE_FLAG FROM [YANTRA_SO_MAST] WHERE SO_ID='{0}'", this.SOId);
        //        if (dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString() == SMStatus.Closed.ToString() || dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString() == SMStatus.Cancelled.ToString())
        //        {
        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _commandText = string.Format("UPDATE [YANTRA_SO_MAST] SET SO_APPROVED_BY={0},SO_ACCEPTANCE_FLAG='{1}' WHERE SO_ID='{2}'", this.SOApprovedBy, SMStatus.Open, this.SOId);
        //            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        }
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Status Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public int Get_Ids_Select(string SalesOrderId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST],[YANTRA_ENQ_ASSIGN_TASKS],[YANTRA_LKUP_ENQ_MODE],[YANTRA_CUSTOMER_MAST],[YANTRA_QUOT_MAST],[YANTRA_SO_MAST]  WHERE [YANTRA_ENQ_MAST].ENQM_ID=[YANTRA_LKUP_ENQ_MODE].ENQM_ID AND [YANTRA_QUOT_MAST].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID AND [YANTRA_ENQ_ASSIGN_TASKS].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID AND " +
        //                                    "[YANTRA_ENQ_MAST].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID AND [YANTRA_SO_MAST].QUOT_ID=[YANTRA_QUOT_MAST].QUOT_ID AND [YANTRA_SO_MAST].SO_ID='" + SalesOrderId + "' ORDER BY [YANTRA_QUOT_MAST].QUOT_ID DESC ");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.SOId = dbManager.DataReader["SO_ID"].ToString();
        //            this.QuotId = dbManager.DataReader["QUOT_ID"].ToString();
        //            this.AssignTaskId = dbManager.DataReader["ASSIGN_TASK_ID"].ToString();
        //            this.EnqId = dbManager.DataReader["ENQ_ID"].ToString();
        //            this.CustId = dbManager.DataReader["CUST_ID"].ToString();
        //            this.DespmId = dbManager.DataReader["DESPM_ID"].ToString();

        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        dbManager.DataReader.Close();
        //        return _returnIntValue;

        //    }

        //    public static void SalesOrder_Select(Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_SO_MAST] ORDER BY SO_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "SO_NO", "SO_ID");
        //        }
        //    }

        //    public static void SalesOrderByCustomerId_Select(Control ControlForBind, string CustomerId, string CustUnitId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_SO_MAST],[YANTRA_QUOT_MAST],[YANTRA_ENQ_MAST] WHERE [YANTRA_SO_MAST].QUOT_ID=[YANTRA_QUOT_MAST].QUOT_ID AND [YANTRA_QUOT_MAST].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID and [YANTRA_ENQ_MAST].CUST_ID=" + CustomerId + " AND [YANTRA_ENQ_MAST].CUST_UNIT_ID=" + CustUnitId + " ORDER BY [YANTRA_SO_MAST].SO_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "SO_NO", "SO_ID");
        //        }
        //    }

        //    public static void SalesOrderForDelivery_Select(Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM YANTRA_SO_MAST WHERE SO_ID IN (SELECT SO_ID FROM YANTRA_SO_DET WHERE SO_DET_DELIVERY_STATUS <> 'DELIVERED') ORDER BY SO_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "SO_NO", "SO_ID");
        //        }
        //    }

        //    public static void SalesOrder_Select(Control ControlForBind, string EmployeeId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT [YANTRA_SO_MAST].* FROM [YANTRA_ENQ_MAST] inner join [YANTRA_ENQ_ASSIGN_TASKS] on YANTRA_ENQ_ASSIGN_TASKS.ENQ_ID = YANTRA_ENQ_MAST.ENQ_ID inner join [YANTRA_EMPLOYEE_MAST] on [YANTRA_EMPLOYEE_MAST].EMP_ID=[YANTRA_ENQ_ASSIGN_TASKS].EMP_ID inner join [YANTRA_QUOT_MAST] on [YANTRA_ENQ_MAST].ENQ_ID=[YANTRA_QUOT_MAST].ENQ_ID inner join [YANTRA_SO_MAST] on [YANTRA_QUOT_MAST].QUOT_ID=[YANTRA_SO_MAST].QUOT_ID where [YANTRA_ENQ_ASSIGN_TASKS].EMP_ID=" + EmployeeId + " ORDER BY [YANTRA_SO_MAST] .SO_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "SO_NO", "SO_ID");
        //        }
        //    }

        //    public Byte[] SOfileBytes;
        //    public string SOFileContentType;
        //    public string SalesOrderUploads_Save()
        //    {
        //        //  this.SONo = SalesOrder_AutoGenCode();
        //        this.SOUploadId = AutoGenMaxId("[YANTRA_SO_UPLOADS]", "SO_UPLOAD_ID");
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [YANTRA_SO_UPLOADS] values (" + SOUploadId + ",{0},'{1}','{2}','{3}',convert(varbinary(max),'{4}'))", this.SOId, this.SOUploadFileName, this.SOUploadDate, this.SOFileContentType, this.SOfileBytes);
        //        //SqlCommand cmd = new SqlCommand(_commandText);
        //        //cmd.Parameters.AddWithValue("@Data", this.SOfileBytes);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public static void SalesOrderItemTypes_Select(string SalesOrderId, Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT distinct([YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID),([YANTRA_LKUP_ITEM_TYPE].IT_TYPE) FROM [YANTRA_SO_DET],[YANTRA_LKUP_ITEM_TYPE],[YANTRA_ITEM_MAST] WHERE [YANTRA_SO_DET].ITEM_CODE in ([YANTRA_ITEM_MAST].ITEM_CODE) AND [YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID=[YANTRA_ITEM_MAST].IT_TYPE_ID AND  [YANTRA_SO_DET].SO_ID=" + SalesOrderId + "");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "IT_TYPE", "IT_TYPE_ID");
        //        }
        //    }

        //    public static void SalesOrderItemNames_Select(string SalesOrderId, string ItemTypeId, Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_SO_DET],[YANTRA_LKUP_ITEM_TYPE],[YANTRA_ITEM_MAST] WHERE [YANTRA_SO_DET].ITEM_CODE in ([YANTRA_ITEM_MAST].ITEM_CODE) AND [YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID=[YANTRA_ITEM_MAST].IT_TYPE_ID AND [YANTRA_SO_DET].SO_ID=" + SalesOrderId + " AND [YANTRA_ITEM_MAST].IT_TYPE_ID=" + ItemTypeId + "");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "ITEM_NAME", "ITEM_CODE");
        //        }
        //    }

        //    public static void SalesOrderForPayments_Select(Control ControlForBind, string CustomerId, string UnitId, string SaveButtonText)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        if (SaveButtonText == "Save")
        //        {
        //            (ControlForBind as DropDownList).Enabled = true;
        //            (ControlForBind as DropDownList).Items.Clear();
        //            (ControlForBind as DropDownList).Items.Add(new ListItem("--", "0"));
        //            _commandText = string.Format("SELECT * FROM [YANTRA_SO_MAST],[YANTRA_QUOT_MAST],[YANTRA_ENQ_MAST] WHERE [YANTRA_SO_MAST].QUOT_ID=[YANTRA_QUOT_MAST].QUOT_ID AND [YANTRA_QUOT_MAST].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID AND [YANTRA_ENQ_MAST].CUST_ID=" + CustomerId + " AND [YANTRA_ENQ_MAST].CUST_UNIT_ID=" + UnitId + " AND [YANTRA_SO_MAST].SO_ID IN (SELECT SO_ID FROM YANTRA_PAYMENTS_RECEIVED WHERE PR_PAYMENT_STATUS <> 'Cleared') AND [YANTRA_SO_MAST].SO_ID IN (SELECT [YANTRA_DELIVERY_CHALLAN_MAST].SO_ID FROM [YANTRA_DELIVERY_CHALLAN_MAST],[YANTRA_SALES_INVOICE_MAST] WHERE [YANTRA_SALES_INVOICE_MAST].DC_ID=[YANTRA_DELIVERY_CHALLAN_MAST].DC_ID) ORDER BY [YANTRA_SO_MAST].SO_ID");
        //            dbManager.ExecuteReader(CommandType.Text, _commandText);
        //            while (dbManager.DataReader.Read())
        //            {
        //                (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["SO_NO"].ToString(), dbManager.DataReader["SO_ID"].ToString()));
        //            }
        //            dbManager.DataReader.Close();

        //            _commandText = string.Format("SELECT * FROM [YANTRA_SO_MAST],[YANTRA_QUOT_MAST],[YANTRA_ENQ_MAST] WHERE [YANTRA_SO_MAST].QUOT_ID=[YANTRA_QUOT_MAST].QUOT_ID AND [YANTRA_QUOT_MAST].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID AND [YANTRA_ENQ_MAST].CUST_ID=" + CustomerId + " AND [YANTRA_ENQ_MAST].CUST_UNIT_ID=" + UnitId + " AND [YANTRA_SO_MAST].SO_ID NOT IN (SELECT SO_ID FROM YANTRA_PAYMENTS_RECEIVED) AND [YANTRA_SO_MAST].SO_ID IN (SELECT [YANTRA_DELIVERY_CHALLAN_MAST].SO_ID FROM [YANTRA_DELIVERY_CHALLAN_MAST],[YANTRA_SALES_INVOICE_MAST] WHERE [YANTRA_SALES_INVOICE_MAST].DC_ID=[YANTRA_DELIVERY_CHALLAN_MAST].DC_ID) ORDER BY [YANTRA_SO_MAST].SO_ID");
        //            dbManager.ExecuteReader(CommandType.Text, _commandText);
        //            while (dbManager.DataReader.Read())
        //            {
        //                (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["SO_NO"].ToString(), dbManager.DataReader["SO_ID"].ToString()));
        //            }
        //            dbManager.DataReader.Close();
        //        }
        //        else if (SaveButtonText == "Update")
        //        {
        //            (ControlForBind as DropDownList).Enabled = false;
        //            _commandText = string.Format("SELECT * FROM [YANTRA_SO_MAST],[YANTRA_QUOT_MAST],[YANTRA_ENQ_MAST] WHERE [YANTRA_SO_MAST].QUOT_ID=[YANTRA_QUOT_MAST].QUOT_ID AND [YANTRA_QUOT_MAST].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID AND [YANTRA_ENQ_MAST].CUST_ID=" + CustomerId + " AND [YANTRA_ENQ_MAST].CUST_UNIT_ID=" + UnitId + "  ORDER BY [YANTRA_SO_MAST].SO_ID");
        //            dbManager.ExecuteReader(CommandType.Text, _commandText);
        //            if (ControlForBind is DropDownList)
        //            {
        //                DropDownListBind(ControlForBind as DropDownList, "SO_NO", "SO_ID");
        //            }
        //        }
        //    }

        //    public int SalesOrderItem_Select(string SalesOrderId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST],[YANTRA_LKUP_ENQ_MODE],[YANTRA_LKUP_DESP_MODE],[YANTRA_CUSTOMER_MAST],[YANTRA_QUOT_MAST],[YANTRA_SO_MAST] WHERE [YANTRA_ENQ_MAST].ENQM_ID=[YANTRA_LKUP_ENQ_MODE].ENQM_ID AND [YANTRA_QUOT_MAST].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID AND [YANTRA_SO_MAST].QUOT_ID=[YANTRA_QUOT_MAST].QUOT_ID AND" +
        //                                    " [YANTRA_SO_MAST].DESPM_ID=[YANTRA_LKUP_DESP_MODE].DESPM_ID AND [YANTRA_ENQ_MAST].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID AND [YANTRA_ENQ_MAST].ENQ_REFERENCE='" + SalesOrderId + "' ORDER BY [YANTRA_ENQ_MAST].ENQ_ID DESC ");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.EnqId = dbManager.DataReader["ENQ_ID"].ToString();
        //            this.SOId = dbManager.DataReader["SO_ID"].ToString();
        //            this.SONo = dbManager.DataReader["SO_NO"].ToString();
        //            this.SODate = Convert.ToDateTime(dbManager.DataReader["SO_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.CustId = dbManager.DataReader["CUST_ID"].ToString();
        //            this.QuotId = dbManager.DataReader["QUOT_ID"].ToString();
        //            this.QuotNo = dbManager.DataReader["QUOT_NO"].ToString();

        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        return _returnIntValue;
        //    }

        //}

        //Methods For Order Acceptance Form
        public class OrderAcceptance
        {
            public string OAId, OANo, OADate, SOId, SONo, WOId, WONo, SOCSTax, DespmId, QuotNo, QuotId, CustId, OARespId, OASalespId, OAPreparedBy, OACheckedBy, OAApprovedBy, OAFlag, OAAcceptanceFlag, OAConsignee, TransId, OADeliveryDate, OACSTax, OAInspection, OAInvoiceTo;
            public string OADetId, OAItemCode, OADetQty, OARate, OADetSpec, OADetRemarks, OADetPriority;

            public OrderAcceptance()
            {
            }

            public static string OrderAcceptance_AutoGenCode()
            {
                //string _codePrefix = CurrentFinancialYear() + " ";
                ////string _codePrefix = "OA/";
                //if (dbManager.Transaction == null)
                //    dbManager.Open();
                //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(CONVERT(BIGINT,REPLACE(OA_NO,LEFT(OA_NO,5),''))),0)+1 FROM [YANTRA_OA_MAST]").ToString());
                ////_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(REPLACE(OA_NO,'" + _codePrefix + "','')),0)+1 FROM [YANTRA_OA_MAST]").ToString());
                //return _codePrefix + _returnIntValue;
                return AutoGenMaxNo("YANTRA_OA_MAST", "OA_NO");
            }

            public string OrderAcceptance_Save()
            {
                //this.OANo = OrderAcceptance_AutoGenCode();
                this.OAId = AutoGenMaxId("[YANTRA_OA_MAST]", "OA_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_OA_MAST] SELECT ISNULL(MAX(OA_ID),0)+1,'{0}','{1}',{2},'{3}','{4}',{5},{6},'{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}' FROM [YANTRA_OA_MAST]", this.OANo, this.OADate, this.WOId, this.OARespId, this.OASalespId, this.DespmId, this.TransId, this.OADeliveryDate, this.OAPreparedBy, this.OACheckedBy, this.OAApprovedBy, this.OAFlag, this.OAConsignee, this.OACSTax, this.OAInspection, this.OAInvoiceTo);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string OrderAcceptance_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_OA_MAST] SET OA_DATE='{0}',OA_RESP_ID='{1}',OA_SALESP_ID='{2}',OA_PREPARED_BY='{3}',OA_CHECKED_BY='{4}',OA_APPROVED_BY='{5}',OA_CONSIGNEE='{6}',DESPM_ID={7},TRANS_ID={8},OA_DELIVERY_DATE='{9}',OA_CSTAX='{10}',OA_INSPECTION='{11}',OA_INVOICE_TO='{12}' WHERE OA_ID={13}", this.OADate, this.OARespId, this.OASalespId, this.OAPreparedBy, this.OACheckedBy, this.OAApprovedBy, this.OAConsignee, this.DespmId, this.TransId, this.OADeliveryDate, this.OACSTax, this.OAInspection, this.OAInvoiceTo, this.OAId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string OrderAcceptance_Delete(string OrderAcceptanceId)
            {
                SM.BeginTransaction();
                if (DeleteRecord("[YANTRA_OA_DET]", "OA_ID", OrderAcceptanceId) == true)
                {
                    if (DeleteRecord("[YANTRA_OA_MAST]", "OA_ID", OrderAcceptanceId) == true)
                    {
                        SM.CommitTransaction();
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        SM.RollBackTransaction();
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                }
                else
                {
                    SM.RollBackTransaction();
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public string OrderAcceptanceDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_OA_DET] SELECT ISNULL(MAX(OA_DET_ID),0)+1,{0},{1},'{2}','{3}','{4}','{5}','{6}' FROM [YANTRA_OA_DET]", this.OAId, this.OAItemCode, this.OADetQty, this.OARate, this.OADetSpec, this.OADetPriority, this.OADetRemarks);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int OrderAcceptanceDetails_Delete(string OrderAcceptanceId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [YANTRA_OA_DET] WHERE OA_ID={0}", OrderAcceptanceId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int OrderAcceptance_Select(string OrderAcceptanceId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT  * FROM [YANTRA_LKUP_DESP_MODE],[YANTRA_ENQ_MAST],[YANTRA_QUOT_MAST],[YANTRA_SO_MAST],[YANTRA_WO_MAST],[YANTRA_OA_MAST] WHERE [YANTRA_ENQ_MAST].ENQ_ID = [YANTRA_QUOT_MAST].ENQ_ID " +
                                            " AND [YANTRA_QUOT_MAST].QUOT_ID=[YANTRA_SO_MAST].QUOT_ID AND [YANTRA_SO_MAST].SO_ID=[YANTRA_WO_MAST].SO_ID AND [YANTRA_SO_MAST].DESPM_ID=[YANTRA_LKUP_DESP_MODE].DESPM_ID" +
                                            " AND [YANTRA_WO_MAST].WO_ID=[YANTRA_OA_MAST].WO_ID AND [YANTRA_OA_MAST].OA_ID='" + OrderAcceptanceId + "' ORDER BY [YANTRA_OA_MAST].OA_ID DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.OANo = dbManager.DataReader["OA_NO"].ToString();
                    this.OADate = Convert.ToDateTime(dbManager.DataReader["OA_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.SOId = dbManager.DataReader["SO_ID"].ToString();
                    this.SONo = dbManager.DataReader["SO_NO"].ToString();
                    this.WOId = dbManager.DataReader["WO_ID"].ToString();
                    this.WONo = dbManager.DataReader["WO_NO"].ToString();
                    this.SOCSTax = dbManager.DataReader["SO_CST"].ToString();
                    this.DespmId = dbManager.DataReader["DESPM_ID"].ToString();
                    this.CustId = dbManager.DataReader["CUST_ID"].ToString();
                    this.QuotId = dbManager.DataReader["QUOT_ID"].ToString();
                    this.QuotNo = dbManager.DataReader["QUOT_NO"].ToString();
                    this.OARespId = dbManager.DataReader["OA_RESP_ID"].ToString();
                    this.OASalespId = dbManager.DataReader["OA_SALESP_ID"].ToString();
                    this.OAPreparedBy = dbManager.DataReader["OA_PREPARED_BY"].ToString();
                    this.OACheckedBy = dbManager.DataReader["OA_CHECKED_BY"].ToString();
                    this.OAApprovedBy = dbManager.DataReader["OA_APPROVED_BY"].ToString();
                    this.OAAcceptanceFlag = dbManager.DataReader["OA_FLAG"].ToString();
                    this.OAConsignee = dbManager.DataReader["OA_CONSIGNEE"].ToString();
                    this.OADeliveryDate = Convert.ToDateTime(dbManager.DataReader["OA_DELIVERY_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.OACSTax = dbManager.DataReader["OA_CSTAX"].ToString();
                    this.OAInspection = dbManager.DataReader["OA_INSPECTION"].ToString();
                    this.OAInvoiceTo = dbManager.DataReader["OA_INVOICE_TO"].ToString();
                    this.TransId = dbManager.DataReader["TRANS_ID"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public static string OrderAcceptanceStatus_Update(SMStatus Status, string OAId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_OA_MAST] SET  OA_FLAG='{0}' WHERE OA_ID='{1}'", Status, OAId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }

            public void OrderAcceptanceDetails_Select(string OrderAcceptanceId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_ITEM_MAST],[YANTRA_LKUP_UOM],[YANTRA_OA_DET] WHERE [YANTRA_OA_DET].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE AND " +
                                               "[YANTRA_ITEM_MAST].UOM_ID=[YANTRA_LKUP_UOM].UOM_ID AND [YANTRA_OA_DET].OA_ID=" + OrderAcceptanceId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable OrderAcceptanceProducts = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                OrderAcceptanceProducts.Columns.Add(col);
                col = new DataColumn("ItemName");
                OrderAcceptanceProducts.Columns.Add(col);
                col = new DataColumn("UOM");
                OrderAcceptanceProducts.Columns.Add(col);
                col = new DataColumn("Quantity");
                OrderAcceptanceProducts.Columns.Add(col);
                col = new DataColumn("Rate");
                OrderAcceptanceProducts.Columns.Add(col);
                col = new DataColumn("Specifications");
                OrderAcceptanceProducts.Columns.Add(col);
                col = new DataColumn("Remarks");
                OrderAcceptanceProducts.Columns.Add(col);
                col = new DataColumn("Priority");
                OrderAcceptanceProducts.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = OrderAcceptanceProducts.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["ITEM_CODE"].ToString();
                    dr["ItemName"] = dbManager.DataReader["ITEM_NAME"].ToString();
                    dr["UOM"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Quantity"] = dbManager.DataReader["OA_DET_QTY"].ToString();
                    dr["Rate"] = dbManager.DataReader["OA_RATE"].ToString();
                    dr["Specifications"] = dbManager.DataReader["OA_DET_SPEC"].ToString();
                    dr["Remarks"] = dbManager.DataReader["OA_DET_REMARKS"].ToString();
                    dr["Priority"] = dbManager.DataReader["OA_DET_PRIORITY"].ToString();

                    OrderAcceptanceProducts.Rows.Add(dr);
                }

                gv.DataSource = OrderAcceptanceProducts;
                gv.DataBind();
            }

            public string OrderAcceptanceApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT  OA_FLAG FROM [YANTRA_OA_MAST] WHERE OA_ID='{0}'", this.OAId);
                if (dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString() == SMStatus.Closed.ToString() || dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString() == SMStatus.Cancelled.ToString())
                {
                    _returnIntValue = 1;
                }
                else
                {
                    _commandText = string.Format("UPDATE [YANTRA_OA_MAST] SET OA_APPROVED_BY={0},OA_FLAG='{1}' WHERE OA_ID='{2}'", this.OAApprovedBy, SMStatus.Closed, this.OAId);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                }
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }

            public static void OrderAcceptance_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_OA_MAST] ORDER BY OA_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "OA_NO", "OA_ID");
                }
            }

            public static void OrderAcceptance_Select(Control ControlForBind, string EmployeeId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT [YANTRA_OA_MAST].* 	FROM [YANTRA_ENQ_MAST] inner join [YANTRA_ENQ_ASSIGN_TASKS] on YANTRA_ENQ_ASSIGN_TASKS.ENQ_ID = YANTRA_ENQ_MAST.ENQ_ID inner join [YANTRA_EMPLOYEE_MAST] on [YANTRA_EMPLOYEE_MAST].EMP_ID=[YANTRA_ENQ_ASSIGN_TASKS].EMP_ID inner join [YANTRA_QUOT_MAST] on [YANTRA_ENQ_MAST].ENQ_ID=[YANTRA_QUOT_MAST].ENQ_ID	 inner join [YANTRA_SO_MAST] on [YANTRA_QUOT_MAST].QUOT_ID=[YANTRA_SO_MAST].QUOT_ID inner join [YANTRA_FE_ORDER_PROFILE] on [YANTRA_SO_MAST].SO_ID=[YANTRA_FE_ORDER_PROFILE].SO_ID inner join [YANTRA_OA_MAST] on [YANTRA_OA_MAST].WO_ID=[YANTRA_FE_ORDER_PROFILE].WO_ID 	where [YANTRA_ENQ_ASSIGN_TASKS].EMP_ID=" + EmployeeId + " ORDER BY [YANTRA_OA_MAST].OA_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "OA_NO", "OA_ID");
                }
            }
        }

        ////Methods For Work Order Form
        //public class WorkOrder
        //{
        //    public string WOId, WONo, WODate, SOId, SONo, DespId, CustId, WOInspDate, WOPackForwInst, WODeliveryDate, WOAccessories, WOExtraSpares, WOPreparedBy, WOCheckedBy, WOApprovedBy, WOFLag, WOFrieght, WORoadPermit, WOFiles, SOAdvanceAmt, WOCSTax, WOTaxLabel;
        //    public string WODetId, WOItemCode, WODetQty, WODetSpec, WODetRemarks;

        //    public WorkOrder()
        //    {
        //    }

        //    public static string WorkOrder_AutoGenCode()
        //    {
        //        //string _codePrefix = CurrentFinancialYear() + " ";
        //        ////string _codePrefix = "WO/";
        //        //if (dbManager.Transaction == null)
        //        //    dbManager.Open();
        //        //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(CONVERT(BIGINT,REPLACE(WO_NO,LEFT(WO_NO,5),''))),0)+1 FROM [YANTRA_WO_MAST]").ToString());
        //        ////_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(REPLACE(WO_NO,'" + _codePrefix + "','')),0)+1 FROM [YANTRA_WO_MAST]").ToString());
        //        //return _codePrefix + _returnIntValue;
        //        return AutoGenMaxNo("YANTRA_WO_MAST", "WO_NO");
        //    }

        //    public string WorkOrder_Save()
        //    {
        //        //this.WONo = WorkOrder_AutoGenCode();
        //        this.WOId = AutoGenMaxId("[YANTRA_WO_MAST]", "WO_ID");
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [YANTRA_WO_MAST] SELECT ISNULL(MAX(WO_ID),0)+1,'{0}','{1}',{2},{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}' FROM [YANTRA_WO_MAST]", this.WONo, this.WODate, this.SOId, this.DespId, this.WOInspDate, this.WOPackForwInst, this.WODeliveryDate, this.WOAccessories, this.WOExtraSpares, this.WOPreparedBy, this.WOCheckedBy, this.WOApprovedBy, "New", this.WOFrieght, this.WORoadPermit, this.WOFiles, this.WOCSTax, this.WOTaxLabel);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string WorkOrder_Update()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [YANTRA_WO_MAST] SET WO_DATE='{0}',DESPM_ID={1},WO_INSP_DATE='{2}',WO_PACK_FORW_INS='{3}',WO_DELIVERY_DATE='{4}',WO_ACCESSORIES='{5}',WO_EXTRA_SPARES='{6}',WO_PREPARED_BY='{7}',WO_CHECKED_BY='{8}',WO_APPROVED_BY='{9}',WO_FRIEGHT='{10}',WO_ROAD_PERMIT='{11}',WO_FILES='{12}',WO_CSTAX='{13}' WHERE WO_ID={14}", this.WODate, this.DespId, this.WOInspDate, this.WOPackForwInst, this.WODeliveryDate, this.WOAccessories, this.WOExtraSpares, this.WOPreparedBy, this.WOCheckedBy, this.WOApprovedBy, this.WOFrieght, this.WORoadPermit, this.WOFiles, this.WOCSTax, this.WOId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string WorkOrder_Delete(string WorkOrderId)
        //    {
        //        SM.BeginTransaction();
        //        if (DeleteRecord("[YANTRA_WO_DET]", "WO_ID", WorkOrderId) == true)
        //        {
        //            if (DeleteRecord("[YANTRA_WO_MAST]", "WO_ID", WorkOrderId) == true)
        //            {
        //                SM.CommitTransaction();
        //                _returnStringMessage = "Data Deleted Successfully";
        //            }
        //            else
        //            {
        //                SM.RollBackTransaction();
        //                _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
        //            }
        //        }
        //        else
        //        {
        //            SM.RollBackTransaction();
        //            _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string WorkOrderDetails_Save()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [YANTRA_WO_DET] SELECT ISNULL(MAX(WO_DET_ID),0)+1,{0},{1},'{2}','{3}','{4}' FROM [YANTRA_WO_DET]", this.WOId, this.WOItemCode, this.WODetQty, this.WODetSpec, this.WODetRemarks);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public int WorkOrderDetails_Delete(string WorkOrderId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("DELETE FROM [YANTRA_WO_DET] WHERE WO_ID={0}", WorkOrderId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        return _returnIntValue;
        //    }

        //    public int WorkOrder_Select(string WorkOrderId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_ENQ_MAST],[YANTRA_QUOT_MAST],[YANTRA_SO_MAST],[YANTRA_WO_MAST] WHERE [YANTRA_ENQ_MAST].ENQ_ID = [YANTRA_QUOT_MAST].ENQ_ID " +
        //                                    " AND [YANTRA_QUOT_MAST].QUOT_ID=[YANTRA_SO_MAST].QUOT_ID AND [YANTRA_SO_MAST].SO_ID=[YANTRA_WO_MAST].SO_ID " +
        //                                    " AND [YANTRA_WO_MAST].WO_ID='" + WorkOrderId + "' ORDER BY [YANTRA_WO_MAST].WO_ID DESC ");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.WOId = dbManager.DataReader["WO_ID"].ToString();
        //            this.WONo = dbManager.DataReader["WO_NO"].ToString();
        //            this.WODate = Convert.ToDateTime(dbManager.DataReader["WO_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.SOId = dbManager.DataReader["SO_ID"].ToString();
        //            this.SONo = dbManager.DataReader["SO_No"].ToString();
        //            this.CustId = dbManager.DataReader["CUST_ID"].ToString();
        //            this.DespId = dbManager.DataReader["DESPM_ID"].ToString();
        //            this.WOInspDate = Convert.ToDateTime(dbManager.DataReader["WO_INSP_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.WOPackForwInst = dbManager.DataReader["WO_PACK_FORW_INS"].ToString();
        //            this.WODeliveryDate = Convert.ToDateTime(dbManager.DataReader["WO_DELIVERY_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.WOAccessories = dbManager.DataReader["WO_ACCESSORIES"].ToString();
        //            this.WOExtraSpares = dbManager.DataReader["WO_EXTRA_SPARES"].ToString();
        //            this.WOPreparedBy = dbManager.DataReader["WO_PREPARED_BY"].ToString();
        //            this.WOCheckedBy = dbManager.DataReader["WO_CHECKED_BY"].ToString();
        //            this.WOApprovedBy = dbManager.DataReader["WO_APPROVED_BY"].ToString();
        //            this.WOFrieght = dbManager.DataReader["WO_FRIEGHT"].ToString();
        //            this.WORoadPermit = dbManager.DataReader["WO_ROAD_PERMIT"].ToString();
        //            this.WOFiles = dbManager.DataReader["WO_FILES"].ToString();
        //            this.WOCSTax = dbManager.DataReader["WO_CSTAX"].ToString();
        //            this.WOTaxLabel = dbManager.DataReader["WO_TAXLBL"].ToString();
        //            this.SOAdvanceAmt = dbManager.DataReader["SO_ADVANCE_AMT"].ToString();

        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        return _returnIntValue;
        //    }

        //    public void WorkOrderDetails_Select(string WorkOrderId, GridView gv)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_ITEM_MAST],[YANTRA_LKUP_UOM],[YANTRA_WO_DET] WHERE [YANTRA_WO_DET].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE AND " +
        //                                       "[YANTRA_ITEM_MAST].UOM_ID=[YANTRA_LKUP_UOM].UOM_ID AND [YANTRA_WO_DET].WO_ID=" + WorkOrderId + "");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);

        //        DataTable OrderAcceptanceProducts = new DataTable();
        //        DataColumn col = new DataColumn();
        //        col = new DataColumn("ItemCode");
        //        OrderAcceptanceProducts.Columns.Add(col);
        //        col = new DataColumn("ItemName");
        //        OrderAcceptanceProducts.Columns.Add(col);
        //        col = new DataColumn("UOM");
        //        OrderAcceptanceProducts.Columns.Add(col);
        //        col = new DataColumn("Quantity");
        //        OrderAcceptanceProducts.Columns.Add(col);
        //        col = new DataColumn("Specifications");
        //        OrderAcceptanceProducts.Columns.Add(col);
        //        col = new DataColumn("Remarks");
        //        OrderAcceptanceProducts.Columns.Add(col);

        //        while (dbManager.DataReader.Read())
        //        {
        //            DataRow dr = OrderAcceptanceProducts.NewRow();
        //            dr["ItemCode"] = dbManager.DataReader["ITEM_CODE"].ToString();
        //            dr["ItemName"] = dbManager.DataReader["ITEM_NAME"].ToString();
        //            dr["UOM"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
        //            dr["Quantity"] = dbManager.DataReader["WO_DET_QTY"].ToString();
        //            dr["Specifications"] = dbManager.DataReader["WO_DET_SPEC"].ToString();
        //            dr["Remarks"] = dbManager.DataReader["WO_DET_REMARKS"].ToString();

        //            OrderAcceptanceProducts.Rows.Add(dr);
        //        }

        //        gv.DataSource = OrderAcceptanceProducts;
        //        gv.DataBind();
        //    }

        //    public string WorkOrderApprove_Update()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT  WO_FLAG FROM [YANTRA_WO_MAST] WHERE WO_ID='{0}'", this.WOId);
        //        if (dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString() == SMStatus.Closed.ToString() || dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString() == SMStatus.Cancelled.ToString())
        //        {
        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _commandText = string.Format("UPDATE [YANTRA_WO_MAST] SET  WO_APPROVED_BY={0},WO_FLAG='{1}' WHERE WO_ID='{2}'", this.WOApprovedBy, SMStatus.Open, this.WOId);
        //            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        }
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Status Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public static string WorkOrderStatus_Update(SMStatus Status, string WOId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [YANTRA_WO_MAST] SET  WO_FLAG='{0}' WHERE WO_ID='{1}'", Status, WOId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public static void WorkOrder_Select(Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_WO_MAST] WHERE WO_FLAG='Open' ORDER BY WO_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "WO_NO", "WO_ID");
        //        }
        //    }

        //    public static void WorkOrder_SelectAll(Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [YANTRA_WO_MAST] ORDER BY WO_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "WO_NO", "WO_ID");
        //        }
        //    }

        //    public static void WorkOrder_Select(Control ControlForBind, string EmployeeId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT [YANTRA_WO_MAST].* FROM [YANTRA_ENQ_MAST] inner join [YANTRA_ENQ_ASSIGN_TASKS] on YANTRA_ENQ_ASSIGN_TASKS.ENQ_ID = YANTRA_ENQ_MAST.ENQ_ID inner join [YANTRA_EMPLOYEE_MAST] on [YANTRA_EMPLOYEE_MAST].EMP_ID=[YANTRA_ENQ_ASSIGN_TASKS].EMP_ID inner join [YANTRA_QUOT_MAST] on [YANTRA_ENQ_MAST].ENQ_ID=[YANTRA_QUOT_MAST].ENQ_ID inner join [YANTRA_SO_MAST] on [YANTRA_QUOT_MAST].QUOT_ID=[YANTRA_SO_MAST].QUOT_ID inner join [YANTRA_WO_MAST] on [YANTRA_SO_MAST].SO_ID=[YANTRA_WO_MAST].SO_ID where [YANTRA_ENQ_ASSIGN_TASKS].EMP_ID=" + EmployeeId + " ORDER BY [YANTRA_WO_MAST].WO_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "WO_NO", "WO_ID");
        //        }
        //    }
        //    public static string GetWorkOrderIdOfSalesOrder(string SalesOrderId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT WO_ID FROM [YANTRA_WO_MAST] WHERE SO_ID='" + SalesOrderId + "' ORDER BY [YANTRA_WO_MAST].WO_ID DESC ");
        //        _returnStringMessage = dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString();

        //        return _returnStringMessage;
        //    }

        //}

        //Method for Agent Master Form
        public class AgentMaster
        {
            public string AgentId, AgentName, AgentContactPerson, AgentAddress, AgentContactPersonDetails, AgentPhone, AgentMobile, AgentEmail, AgentFaxNo; // Agent Master
            // public string SupDetId, ItemCode, ItemType, UOM;

            public AgentMaster()
            { }

            public string AgentMaster_Save()
            {
                dbManager.Open();
                if (IsRecordExists("[YANTRA_AGENT_MASTER]", "AGENT_NAME", this.AgentName) == false)
                {
                    _commandText = string.Format("INSERT INTO [YANTRA_AGENT_MASTER] SELECT ISNULL(MAX(AGENT_ID),0)+1,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}' FROM [YANTRA_AGENT_MASTER]", this.AgentName, this.AgentContactPerson, this.AgentAddress, this.AgentContactPersonDetails, this.AgentPhone, this.AgentMobile, this.AgentEmail, this.AgentFaxNo);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Supplier  Already Exists.";
                }
                return _returnStringMessage;
            }

            public string AgentMaster_Update()
            {
                dbManager.Open();
                if (IsRecordExists("[YANTRA_AGENT_MASTER]", "AGENT_NAME", this.AgentName, "AGENT_ID", this.AgentId) == false)
                {
                    _commandText = string.Format("UPDATE [YANTRA_AGENT_MASTER] SET AGENT_NAME='{0}',AGENT_CONTACT_PERSON='{1}',AGENT_ADDRESS='{2}',AGENT_CONTACT_PER_DET='{3}',AGENT_PHONE='{4}',AGENT_MOBILE='{5}',AGENT_EMAIL='{6}',AGENT_FAXNO='{7}' WHERE AGENT_ID={8}", this.AgentName, this.AgentContactPerson, this.AgentAddress, this.AgentContactPersonDetails, this.AgentPhone, this.AgentMobile, this.AgentEmail, this.AgentFaxNo, this.AgentId);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Supplier Already Exists.";
                }
                return _returnStringMessage;
            }

            public string AgentMaster_Delete()
            {
                if (DeleteRecord("[YANTRA_AGENT_MASTER]", "AGENT_ID", this.AgentId) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public static void AgentMaster_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_AGENT_MASTER] ORDER BY AGENT_NAME");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "AGENT_NAME", "AGENT_ID");
                }
            }

            public int AgentMaster_Select(string AgentId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [YANTRA_AGENT_MASTER] WHERE AGENT_ID = " + AgentId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.AgentId = dbManager.DataReader["AGENT_ID"].ToString();
                    this.AgentName = dbManager.DataReader["AGENT_NAME"].ToString();
                    this.AgentContactPerson = dbManager.DataReader["AGENT_CONTACT_PERSON"].ToString();
                    this.AgentAddress = dbManager.DataReader["AGENT_ADDRESS"].ToString();
                    this.AgentContactPersonDetails = dbManager.DataReader["AGENT_CONTACT_PER_DET"].ToString();
                    this.AgentPhone = dbManager.DataReader["AGENT_PHONE"].ToString();
                    this.AgentMobile = dbManager.DataReader["AGENT_MOBILE"].ToString();
                    this.AgentEmail = dbManager.DataReader["AGENT_EMAIL"].ToString();
                    this.AgentFaxNo = dbManager.DataReader["AGENT_FAXNO"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }

        //Method SalesTarget
        public class SalesTarget
        {
            public string STId, EMPId, TargetMonth, TargetAmt;
            // public string SupDetId, ItemCode, ItemType, UOM;

            public SalesTarget()
            { }

            public string SalesTarget_Save()
            {
                //dbManager.Open();
                if (IsRecordExists("[YANTRA_SM_SALESTARGET]", "[EmpId]", this.EMPId) == false)
                {
                    _commandText = string.Format("INSERT INTO [YANTRA_SM_SALESTARGET] SELECT ISNULL(MAX(ST_NO),0)+1,'{0}','{1}','{2}' FROM [YANTRA_SM_SALESTARGET]", this.TargetMonth, this.EMPId, this.TargetAmt);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Target  Already Exists.";
                }
                return _returnStringMessage;
            }

            public string SalesTarget_Update()
            {
                //dbManager.Open();
                if (IsRecordExists("[YANTRA_SM_SALESTARGET]", "EMPID", this.EMPId, "EMPID", this.EMPId) == false)
                {
                    _commandText = string.Format("UPDATE [YANTRA_SM_SALESTARGET] SET EMPID='{0}',TargetMonth='{1}',TargetAmount='{2}'WHERE ST_NO={3}", this.EMPId, this.TargetMonth, this.TargetAmt, this.STId);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Supplier Already Exists.";
                }
                return _returnStringMessage;
            }

            public static void CustomerMaster_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT CUST_COMPANY_NAME,CUST_ID FROM [YANTRA_CUSTOMER_MAST] ORDER BY CUST_COMPANY_NAME");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "CUST_COMPANY_NAME", "CUST_ID");
                }
            }

            public string SalesTarget_Delete(string delid)
            {
                string delid1 = delid;
                if (DeleteRecord("[YANTRA_SM_SALESTARGET]", "ST_NO", delid1) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public int SalesTarget_Select(string STId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [YANTRA_SM_SALESTARGET] WHERE ST_NO = " + STId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.STId = dbManager.DataReader["ST_NO"].ToString();
                    this.TargetAmt = dbManager.DataReader["TargetAmount"].ToString();
                    this.TargetMonth = dbManager.DataReader["TargetMonth"].ToString();
                    this.EMPId = dbManager.DataReader["EmpId"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }

        //Methods For Payments Received Form
        public class PaymentsReceived
        {
            public string PRId, PRNo, PRDate, CustId, UnitId, SO_Id, SIId, SIAmt, PRReceivedAmt, PRPaymodeType, PRChequeNo, PRChequeDate, PRCahReceivedDate, PRBankDetails, PRPreparedBy, PRApprovedBy, PRPaymentStatus, SPOId;

            public PaymentsReceived()
            {
            }

            public static string PaymentsReceived_AutoGenCode()
            {
                //string _codePrefix = CurrentFinancialYear() + " ";
                //if (dbManager.Transaction == null)
                //    dbManager.Open();
                //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(CONVERT(BIGINT,REPLACE(PR_NO,LEFT(PR_NO,5),''))),0)+1 FROM [YANTRA_PAYMENTS_RECEIVED]").ToString());
                //return _codePrefix + _returnIntValue;
                return AutoGenMaxNo("YANTRA_PAYMENTS_RECEIVED", "PR_NO");
            }

            public string PaymentsReceived_Save()
            {
                this.PRNo = PaymentsReceived_AutoGenCode();
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_PAYMENTS_RECEIVED] SELECT ISNULL(MAX(PR_ID),0)+1,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}' FROM [YANTRA_PAYMENTS_RECEIVED]", this.PRNo, this.PRDate, this.CustId, this.UnitId, this.SO_Id, this.SIId, this.SIAmt, this.PRReceivedAmt, this.PRPaymodeType, this.PRChequeNo, this.PRChequeDate, this.PRCahReceivedDate, this.PRBankDetails, this.PRPreparedBy, this.PRApprovedBy, this.PRPaymentStatus, this.SPOId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string PaymentsReceived_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_PAYMENTS_RECEIVED] SET PR_NO='{0}',PR_DATE='{1}',CUST_ID={2},UNIT_ID={3},SI_ID={4},SI_AMOUNT='{5}',PR_AMT_RECEIVED='{6}',PR_PAYMODE_TYPE='{7}',PR_CHEQUE_NO='{8}',PR_CHEQUE_DATE='{9}',PR_CASH_RECEIVED_DATE='{10}',PR_BANK_DETAILS='{11}',PR_PREPARED_BY='{12}',PR_APPROVED_BY='{13}',PR_PAYMENT_STATUS='{14}',SO_ID={15},SPO_ID={16}  WHERE PR_ID={17}", this.PRNo, Convert.ToDateTime(this.PRDate), this.CustId, this.UnitId, this.SIId, this.SIAmt, this.PRReceivedAmt, this.PRPaymodeType, this.PRChequeNo, Convert.ToDateTime(this.PRChequeDate), Convert.ToDateTime(this.PRCahReceivedDate), this.PRBankDetails, this.PRPreparedBy, this.PRApprovedBy, this.PRPaymentStatus, this.SO_Id, this.SPOId, this.PRId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string PaymentsReceived_Delete(string PaymentsReceivedId)
            {
                if (DeleteRecord("[YANTRA_PAYMENTS_RECEIVED]", "PR_ID", PaymentsReceivedId) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public static void PaymentsReceived_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_PAYMENTS_RECEIVED] ORDER BY PR_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "PR_NO", "PR_ID");
                }
            }

            public int PaymentsReceived_Select(string PaymentsReceivedId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [YANTRA_PAYMENTS_RECEIVED],[YANTRA_CUSTOMER_MAST],[YANTRA_SALES_INVOICE_MAST],[YANTRA_CUSTOMER_UNITS]" +
                                                                        " WHERE [YANTRA_PAYMENTS_RECEIVED].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID " +
                                                                        " AND [YANTRA_PAYMENTS_RECEIVED].UNIT_ID=[YANTRA_CUSTOMER_UNITS].CUST_UNIT_ID " +
                                                                        " AND [YANTRA_PAYMENTS_RECEIVED].SI_ID=[YANTRA_SALES_INVOICE_MAST].SI_ID  " +
                                                                        " AND [YANTRA_PAYMENTS_RECEIVED].PR_ID='" + PaymentsReceivedId + "' ORDER BY [YANTRA_PAYMENTS_RECEIVED].PR_ID DESC ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.PRId = dbManager.DataReader["PR_ID"].ToString();
                    this.PRNo = dbManager.DataReader["PR_NO"].ToString();
                    this.PRDate = Convert.ToDateTime(dbManager.DataReader["PR_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.CustId = dbManager.DataReader["CUST_ID"].ToString();
                    this.UnitId = dbManager.DataReader["UNIT_ID"].ToString();
                    this.SO_Id = dbManager.DataReader["SO_ID"].ToString();
                    this.SPOId = dbManager.DataReader["SPO_ID"].ToString();
                    this.SIId = dbManager.DataReader["SI_ID"].ToString();
                    this.SIAmt = dbManager.DataReader["SI_AMOUNT"].ToString();
                    this.PRReceivedAmt = dbManager.DataReader["PR_AMT_RECEIVED"].ToString();
                    this.PRPaymodeType = dbManager.DataReader["PR_PAYMODE_TYPE"].ToString();
                    this.PRChequeNo = dbManager.DataReader["PR_CHEQUE_NO"].ToString();
                    this.PRChequeDate = Convert.ToDateTime(dbManager.DataReader["PR_CHEQUE_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.PRCahReceivedDate = Convert.ToDateTime(dbManager.DataReader["PR_CASH_RECEIVED_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.PRBankDetails = dbManager.DataReader["PR_BANK_DETAILS"].ToString();
                    this.PRPreparedBy = dbManager.DataReader["PR_PREPARED_BY"].ToString();
                    this.PRApprovedBy = dbManager.DataReader["PR_APPROVED_BY"].ToString();
                    this.PRPaymentStatus = dbManager.DataReader["PR_PAYMENT_STATUS"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void ExistingPaymentsReceived_Select(GridView gv, string SalesInvoiceId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [YANTRA_PAYMENTS_RECEIVED],[YANTRA_CUSTOMER_MAST],[YANTRA_SALES_INVOICE_MAST],[YANTRA_CUSTOMER_UNITS]" +
                                                                        " WHERE [YANTRA_PAYMENTS_RECEIVED].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID " +
                                                                        " AND [YANTRA_PAYMENTS_RECEIVED].UNIT_ID=[YANTRA_CUSTOMER_UNITS].CUST_UNIT_ID " +
                                                                        " AND [YANTRA_PAYMENTS_RECEIVED].SI_ID=[YANTRA_SALES_INVOICE_MAST].SI_ID  " +
                                                                        " AND [YANTRA_PAYMENTS_RECEIVED].SI_ID='" + SalesInvoiceId + "' ORDER BY [YANTRA_PAYMENTS_RECEIVED].PR_ID DESC");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                gv.DataSource = dbManager.DataReader;
                gv.DataBind();
                dbManager.DataReader.Close();
            }

            public string PaymentsStatus_Update(string PaymentStatus, string SIId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_PAYMENTS_RECEIVED] SET PR_PAYMENT_STATUS='{0}' WHERE SI_ID={1}", PaymentStatus, SIId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }
        }

        //Methods For EMDS Received Form
        public class EMDSReceived
        {
            public string EMDRId, EMDRNo, EMDRDate, EnqRef, EnqId, EnqEMDCharges, EMDRAmtReceived, EMDRPaymodeType, EMDRChequeNo, EMDRChequeDate, EMDRCahReceivedDate, EMDRBankDetails, EMDRPreparedBy, EMDRApprovedBy, EMDRRemarks, EmdrStatus;
            public string CustId, CustUnitId, CustDetId;

            public EMDSReceived()
            {
            }

            public static string EMDSReceived_AutoGenCode()
            {
                //string _codePrefix = CurrentFinancialYear() + " ";
                ////string _codePrefix = "SI/";
                //if (dbManager.Transaction == null)
                //    dbManager.Open();
                //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(CONVERT(BIGINT,REPLACE(EMDR_NO,LEFT(EMDR_NO,5),''))),0)+1 FROM [YANTRA_EMDS_RECEIVED]").ToString());
                //return _codePrefix + _returnIntValue;
                return AutoGenMaxNo("YANTRA_EMDS_RECEIVED", "EMDR_NO");
            }

            public string EMDSReceived_Save()
            {
                this.EMDRNo = EMDSReceived_AutoGenCode();
                this.EMDRId = AutoGenMaxId("[YANTRA_EMDS_RECEIVED]", "EMDR_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_EMDS_RECEIVED] SELECT ISNULL(MAX(EMDR_ID),0)+1,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}' FROM [YANTRA_EMDS_RECEIVED]", this.EMDRNo, this.EMDRDate, this.EnqRef, this.EnqId, this.EnqEMDCharges, this.EMDRAmtReceived, this.EMDRPaymodeType, this.EMDRChequeNo, this.EMDRChequeDate, this.EMDRCahReceivedDate, this.EMDRBankDetails, this.EMDRPreparedBy, this.EMDRApprovedBy, this.EMDRRemarks, this.EmdrStatus);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string EMDSReceived_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_EMDS_RECEIVED] SET EMDR_NO='{0}',EMDR_DATE='{1}',ENQ_REFERENCE='{2}',ENQ_EMD_CHARGES='{3}',EMDR_AMT_RECEIVED='{4}',EMDR_PAYMODE_TYPE='{5}',EMDR_CHEQUE_NO='{6}',EMDR_CHEQUE_DATE='{7}',EMDR_CASH_RECEIVED_DATE='{8}',EMDR_BANK_DETAILS='{9}',EMDR_PREPARED_BY='{10}',EMDR_APPROVED_BY='{11}',EMDR_REMARKS='{12}',EMDR_STATUS='{13}' WHERE EMDR_ID={14}", this.EMDRNo, this.EMDRDate, this.EnqRef, this.EnqEMDCharges, this.EMDRAmtReceived, this.EMDRPaymodeType, this.EMDRChequeNo, this.EMDRChequeDate, this.EMDRCahReceivedDate, this.EMDRBankDetails, this.EMDRPreparedBy, this.EMDRApprovedBy, this.EMDRRemarks, this.EmdrStatus, this.EMDRId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string EMDSReceived_Delete(string EMDSReceivedId)
            {
                if (DeleteRecord("[YANTRA_EMDS_RECEIVED]", "EMDR_ID", EMDSReceivedId) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public static void EMDSReceived_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_EMDS_RECEIVED] ORDER BY EMDR_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "EMDR_NO", "EMDR_ID");
                }
            }

            public int EMDSReceived_Select(string EMDSReceivedId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [YANTRA_EMDS_RECEIVED],[YANTRA_CUSTOMER_MAST],[YANTRA_ENQ_MAST],[YANTRA_CUSTOMER_UNITS],[YANTRA_CUSTOMER_DET] WHERE [YANTRA_ENQ_MAST].ENQ_ID=[YANTRA_EMDS_RECEIVED].ENQ_ID  AND [YANTRA_ENQ_MAST].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID  AND [YANTRA_ENQ_MAST].CUST_DET_ID=[YANTRA_CUSTOMER_DET].CUST_DET_ID  AND [YANTRA_ENQ_MAST].CUST_UNIT_ID=[YANTRA_CUSTOMER_UNITS].CUST_UNIT_ID   AND [YANTRA_EMDS_RECEIVED].EMDR_ID='" + EMDSReceivedId + "' ORDER BY [YANTRA_EMDS_RECEIVED].EMDR_ID DESC ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.EMDRId = dbManager.DataReader["EMDR_ID"].ToString();
                    this.EMDRNo = dbManager.DataReader["EMDR_NO"].ToString();
                    this.EMDRDate = Convert.ToDateTime(dbManager.DataReader["EMDR_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.EnqRef = dbManager.DataReader["ENQ_REFERENCE"].ToString();
                    this.EnqId = dbManager.DataReader["ENQ_ID"].ToString();
                    this.CustId = dbManager.DataReader["CUST_ID"].ToString();
                    this.CustUnitId = dbManager.DataReader["CUST_UNIT_ID"].ToString();
                    this.CustDetId = dbManager.DataReader["CUST_DET_ID"].ToString();
                    this.EnqEMDCharges = dbManager.DataReader["ENQ_EMD_CHARGES"].ToString();
                    this.EMDRAmtReceived = dbManager.DataReader["EMDR_AMT_RECEIVED"].ToString();
                    this.EMDRPaymodeType = dbManager.DataReader["EMDR_PAYMODE_TYPE"].ToString();
                    this.EMDRChequeNo = dbManager.DataReader["EMDR_CHEQUE_NO"].ToString();
                    this.EMDRChequeDate = Convert.ToDateTime(dbManager.DataReader["EMDR_CHEQUE_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.EMDRCahReceivedDate = Convert.ToDateTime(dbManager.DataReader["EMDR_CASH_RECEIVED_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.EMDRBankDetails = dbManager.DataReader["EMDR_BANK_DETAILS"].ToString();
                    this.EMDRPreparedBy = dbManager.DataReader["EMDR_PREPARED_BY"].ToString();
                    this.EMDRApprovedBy = dbManager.DataReader["EMDR_APPROVED_BY"].ToString();
                    this.EMDRRemarks = dbManager.DataReader["EMDR_REMARKS"].ToString();
                    this.EmdrStatus = dbManager.DataReader["EMDR_STATUS"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void ExistingEMDSReceived_Select(GridView gv, string SalesEnquiryId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [YANTRA_EMDS_RECEIVED],[YANTRA_ENQ_MAST] WHERE [YANTRA_ENQ_MAST].ENQ_ID=[YANTRA_EMDS_RECEIVED].ENQ_ID AND [YANTRA_EMDS_RECEIVED].ENQ_ID='" + SalesEnquiryId + "' ORDER BY [YANTRA_EMDS_RECEIVED].EMDR_ID DESC");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                gv.DataSource = dbManager.DataReader;
                gv.DataBind();
                dbManager.DataReader.Close();
            }

            public string EMDSStatus_Update(string EMDSStatus, string EnqId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_EMDS_RECEIVED] SET EMDR_STATUS='{0}' WHERE ENQ_ID={1}", EMDSStatus, EnqId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }
        }

        //Methods For Claim Form
        public class ClaimForm
        {
            public string CfId, CfNo, CfDate, SupId, SupNo, CustId, CustUnitId, CustDetId,
                CfPoRefNo, CfFOBDocCharges, CfTotalExworksFOB, CfCifCharges, CfTotalCifCharges, CfTranferCharges,
                CfTotalValue, CfClaimValueUsd, CURRENCYID, CfCurValueAsPerDay, CfIrs, CfConsigneeBillingAddress,
                CfPayment, CfAccountNo, CfDelivery, CfSwift, CfDeliveryInstructions, CITYID, Preparedby, Approvedby, CfPoRefDate;

            public string CFProdDetId, ItemCode, CFProdDetQty, CFProdDetCurrency, CFProdDetUnitPrice;
            public string CFTpDetId, CFItemCode, CFTpDetValue, CFTpDetClaimValue;

            public ClaimForm()
            {
            }

            public static string ClaimForm_AutoGenCode()
            {
                //string _codePrefix = CurrentFinancialYear() + " ";
                //if (dbManager.Transaction == null)
                //    dbManager.Open();
                //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(CONVERT(BIGINT,REPLACE(CF_NO,LEFT(CF_NO,5),''))),0)+1 FROM [YANTRA_CLAIM_FORM]").ToString());
                //return _codePrefix + _returnIntValue;
                return AutoGenMaxNo("YANTRA_CLAIM_FORM", "CF_NO");
            }

            public string ClaimForm_Save()
            {
                this.CfNo = ClaimForm_AutoGenCode();
                //NEED TO DEVELOP THIS 'PO REF NO' WITH 'FE ORDER PROFILE' ( AUTO GENERATE NO TO BE FILLED IN BOTH FORMS WITH OUT REPETATIONS)
                this.CfId = AutoGenMaxId("[YANTRA_CLAIM_FORM]", "CF_ID");

                //////////////////////////////////////////
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_CLAIM_FORM] SELECT ISNULL(MAX(CF_ID),0)+1,'{0}','{1}',{2},{3},{4},{5},'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',{14},'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}',{23},'{24}','{25}','{26}' FROM [YANTRA_CLAIM_FORM]",
                    this.CfNo, this.CfDate, this.SupId, this.CustId, this.CustUnitId, this.CustDetId, this.CfPoRefNo, this.CfFOBDocCharges, this.CfTotalExworksFOB, this.CfCifCharges, this.CfTotalCifCharges, this.CfTranferCharges, this.CfTotalValue, this.CfClaimValueUsd, this.CURRENCYID, this.CfCurValueAsPerDay, this.CfIrs, this.CfConsigneeBillingAddress, this.CfPayment, this.CfAccountNo, this.CfDelivery, this.CfSwift, this.CfDeliveryInstructions, this.CITYID, this.Preparedby, this.Approvedby, this.CfPoRefDate);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string ClaimForm_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_CLAIM_FORM] SET CF_DATE='{0}',CUST_ID={1},CF_PO_REF_NO='{2}',CF_FOB_DOC_CHARGES='{3}',CF_TOTAL_EXWORKS_FOB='{4}',CF_CIF_CHARGES='{5}',CF_TOTAL_CIF_CHARGES='{6}',CF_TRANSFER_CHARGES='{7}',CF_TOTAL_VALUE='{8}',CF_CLAIM_VALUE_USD='{9}',CURRENCY_ID={10},CF_CUR_VALUE_AS_PER_DAY='{11}',CF_IRS='{12}',CF_CONSIGNEE_BILLING_ADDRESS='{13}',CF_PAYMENT='{14}',CF_ACCOUNT_NO='{15}',CF_DELIVERY='{16}',CF_SWIFT='{17}',CF_DELIVERY_INSTRUCTIONS='{18}',  CITY_ID={19},CF_PREPARED_BY='{20}',CF_APPROVED_BY='{21}',CF_PO_REF_DATE='{22}',SUP_ID={23} WHERE CF_ID={24}",
                    this.CfDate, this.CustId, this.CfPoRefNo, this.CfFOBDocCharges, this.CfTotalExworksFOB, this.CfCifCharges, this.CfTotalCifCharges, this.CfTranferCharges, this.CfTotalValue, this.CfClaimValueUsd, this.CURRENCYID, this.CfCurValueAsPerDay, this.CfIrs, this.CfConsigneeBillingAddress, this.CfPayment, this.CfAccountNo, this.CfDelivery, this.CfSwift, this.CfDeliveryInstructions, this.CITYID, this.Preparedby, this.Approvedby, this.CfPoRefDate, this.SupId, this.CfId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string ClaimForm_Delete(string ClaimFormId)
            {
                if (DeleteRecord("[YANTRA_CLAIM_FORM]", "CF_ID", ClaimFormId) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public static void ClaimForm_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_CLAIM_FORM] ORDER BY CF_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "CF_NO", "CF_ID");
                }
            }

            public int ClaimForm_Select(string ClaimFormId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [YANTRA_CLAIM_FORM] inner join [YANTRA_CUSTOMER_MAST] on [YANTRA_CLAIM_FORM].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID " +
" inner join [YANTRA_CUSTOMER_UNITS] on [YANTRA_CLAIM_FORM].CUST_UNIT_ID=[YANTRA_CUSTOMER_UNITS].CUST_UNIT_ID " +
" inner join [YANTRA_CUSTOMER_DET] on [YANTRA_CLAIM_FORM].CUST_DET_ID=[YANTRA_CUSTOMER_DET].CUST_DET_ID " +
" left outer join [YANTRA_LKUP_CURRENCY_TYPE] on [YANTRA_CLAIM_FORM].CURRENCY_ID=[YANTRA_LKUP_CURRENCY_TYPE].CURRENCY_ID " +
" left outer join [YANTRA_LKUP_CITY_MAST] on [YANTRA_CLAIM_FORM].CITY_ID=[YANTRA_LKUP_CITY_MAST].CITY_ID " +
" left outer join [YANTRA_SUPPLIER_MAST] on [YANTRA_CLAIM_FORM].SUP_ID=[YANTRA_SUPPLIER_MAST].SUP_ID " +
" where [YANTRA_CLAIM_FORM].CF_ID='" + ClaimFormId + "' ORDER BY [YANTRA_CLAIM_FORM].CF_ID DESC ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.CfId = dbManager.DataReader["CF_ID"].ToString();
                    this.CfNo = dbManager.DataReader["CF_NO"].ToString();
                    this.CfDate = Convert.ToDateTime(dbManager.DataReader["CF_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.SupId = dbManager.DataReader["SUP_ID"].ToString();
                    this.CustId = dbManager.DataReader["CUST_ID"].ToString();
                    this.CustUnitId = dbManager.DataReader["CUST_UNIT_ID"].ToString();
                    this.CustDetId = dbManager.DataReader["CUST_DET_ID"].ToString();
                    this.CfPoRefNo = dbManager.DataReader["CF_PO_REF_NO"].ToString();
                    this.CfFOBDocCharges = dbManager.DataReader["CF_FOB_DOC_CHARGES"].ToString();
                    this.CfTotalExworksFOB = dbManager.DataReader["CF_TOTAL_EXWORKS_FOB"].ToString();
                    this.CfCifCharges = dbManager.DataReader["CF_CIF_CHARGES"].ToString();
                    this.CfTotalCifCharges = dbManager.DataReader["CF_TOTAL_CIF_CHARGES"].ToString();
                    this.CfTranferCharges = dbManager.DataReader["CF_TRANSFER_CHARGES"].ToString();
                    this.CfTotalValue = dbManager.DataReader["CF_TOTAL_VALUE"].ToString();
                    this.CfClaimValueUsd = dbManager.DataReader["CF_CLAIM_VALUE_USD"].ToString();
                    this.CURRENCYID = dbManager.DataReader["CURRENCY_ID"].ToString();
                    this.CfCurValueAsPerDay = dbManager.DataReader["CF_CUR_VALUE_AS_PER_DAY"].ToString();
                    this.CfIrs = dbManager.DataReader["CF_IRS"].ToString();
                    this.CfConsigneeBillingAddress = dbManager.DataReader["CF_CONSIGNEE_BILLING_ADDRESS"].ToString();
                    this.CfPayment = dbManager.DataReader["CF_PAYMENT"].ToString();
                    this.CfAccountNo = dbManager.DataReader["CF_ACCOUNT_NO"].ToString();
                    this.CfDelivery = dbManager.DataReader["CF_DELIVERY"].ToString();
                    this.CfSwift = dbManager.DataReader["CF_SWIFT"].ToString();
                    this.CfDeliveryInstructions = dbManager.DataReader["CF_DELIVERY_INSTRUCTIONS"].ToString();
                    this.Preparedby = dbManager.DataReader["CF_PREPARED_BY"].ToString();
                    this.Approvedby = dbManager.DataReader["CF_APPROVED_BY"].ToString();
                    this.CITYID = dbManager.DataReader["CITY_ID"].ToString();
                    this.CfPoRefDate = Convert.ToDateTime(dbManager.DataReader["CF_PO_REF_DATE"].ToString()).ToString("dd/MM/yyyy");

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public static string GetClaimFormId(string ClaimFormNo)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT CF_ID FROM [YANTRA_CLAIM_FORM] WHERE CF_NO='" + ClaimFormNo + "'");
                _returnStringMessage = dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString();
                return _returnStringMessage;
            }

            public string ClaimFormApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_CLAIM_FORM] SET CF_APPROVED_BY={0} WHERE CF_ID={1}", this.Approvedby, this.CfId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string ClaimFormDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_CLAIM_FORM_PROD_DET] SELECT ISNULL(MAX(CF_PROD_DET_ID),0)+1,{0},{1},'{2}','{3}','{4}' FROM [YANTRA_CLAIM_FORM_PROD_DET]",
                                                                                                                              this.CfId, this.ItemCode, this.CFProdDetQty, this.CFProdDetCurrency, this.CFProdDetUnitPrice);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int ClaimFormDetails_Delete(string ClaimFormId)
            {
                //if (dbManager.Transaction == null)
                //    dbManager.Open();
                //_commandText = string.Format("DELETE FROM [YANTRA_CLAIM_FORM_PROD_DET] WHERE CF_ID={0}", ClaimFormId);
                //_returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                //return _returnIntValue;
                if (DeleteRecord("[YANTRA_CLAIM_FORM_PROD_DET]", "CF_ID", ClaimFormId) == true)
                { _returnIntValue = 1; }
                else
                { _returnIntValue = 0; }
                return _returnIntValue;
            }

            public void ClaimFormDetails_Select(string ClaimFormId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_ITEM_MAST],[YANTRA_LKUP_CURRENCY_TYPE],[YANTRA_CLAIM_FORM_PROD_DET],[YANTRA_LKUP_ITEM_TYPE] WHERE [YANTRA_CLAIM_FORM_PROD_DET].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE AND " +
                                               "[YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID=[YANTRA_ITEM_MAST].IT_TYPE_ID AND [YANTRA_LKUP_CURRENCY_TYPE].CURRENCY_ID=[YANTRA_CLAIM_FORM_PROD_DET].CF_PROD_DET_CURRENCY AND [YANTRA_CLAIM_FORM_PROD_DET].CF_ID=" + ClaimFormId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable ClaimFormProducts = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                ClaimFormProducts.Columns.Add(col);
                col = new DataColumn("ItemName");
                ClaimFormProducts.Columns.Add(col);
                col = new DataColumn("Quantity");
                ClaimFormProducts.Columns.Add(col);
                col = new DataColumn("Currency");
                ClaimFormProducts.Columns.Add(col);
                col = new DataColumn("CurrencyName");
                ClaimFormProducts.Columns.Add(col);
                col = new DataColumn("UnitPrice");
                ClaimFormProducts.Columns.Add(col);
                col = new DataColumn("CFProdDetId");
                ClaimFormProducts.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = ClaimFormProducts.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["ITEM_CODE"].ToString();
                    dr["ItemName"] = dbManager.DataReader["ITEM_NAME"].ToString();
                    dr["Quantity"] = dbManager.DataReader["CF_PROD_DET_QTY"].ToString();
                    dr["Currency"] = dbManager.DataReader["CF_PROD_DET_CURRENCY"].ToString();
                    dr["CurrencyName"] = dbManager.DataReader["CURRENCY_NAME"].ToString();
                    dr["UnitPrice"] = dbManager.DataReader["CF_PROD_DET_UNIT_PRICE"].ToString();
                    dr["CFProdDetId"] = dbManager.DataReader["CF_PROD_DET_ID"].ToString();

                    ClaimFormProducts.Rows.Add(dr);
                }

                gv.DataSource = ClaimFormProducts;
                gv.DataBind();
            }

            public string ClaimTransferFormDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_CLAIM_FORM_TRANSFER_PRICE_DET] SELECT ISNULL(MAX(CF_TP_DET_ID),0)+1,{0},{1},'{2}','{3}' FROM [YANTRA_CLAIM_FORM_TRANSFER_PRICE_DET]",
                                                                                                                              this.CfId, this.CFItemCode, this.CFTpDetValue, this.CFTpDetClaimValue);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int ClaimTransferFormDetails_Delete(string ClaimFormId)
            {
                //if (dbManager.Transaction == null)
                //    dbManager.Open();
                //_commandText = string.Format("DELETE FROM [YANTRA_CLAIM_FORM_TRANSFER_PRICE_DET] WHERE CF_ID={0}", ClaimFormId);
                //_returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                //return _returnIntValue;
                if (DeleteRecord("[YANTRA_CLAIM_FORM_TRANSFER_PRICE_DET]", "CF_ID", ClaimFormId) == true)
                { _returnIntValue = 1; }
                else
                { _returnIntValue = 0; }
                return _returnIntValue;
            }

            public void ClaimTransferFormDetails_Select(string ClaimFormId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_ITEM_MAST],[YANTRA_LKUP_UOM],[YANTRA_CLAIM_FORM_TRANSFER_PRICE_DET],[YANTRA_LKUP_ITEM_TYPE] WHERE [YANTRA_CLAIM_FORM_TRANSFER_PRICE_DET].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE AND " +
                                               "[YANTRA_ITEM_MAST].UOM_ID=[YANTRA_LKUP_UOM].UOM_ID AND [YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID=[YANTRA_ITEM_MAST].IT_TYPE_ID  AND [YANTRA_CLAIM_FORM_TRANSFER_PRICE_DET].CF_ID=" + ClaimFormId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable ClaimFormTransferProducts = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                ClaimFormTransferProducts.Columns.Add(col);
                col = new DataColumn("ItemName");
                ClaimFormTransferProducts.Columns.Add(col);
                col = new DataColumn("Value");
                ClaimFormTransferProducts.Columns.Add(col);
                col = new DataColumn("CFTpDetId");
                ClaimFormTransferProducts.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = ClaimFormTransferProducts.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["ITEM_CODE"].ToString();
                    dr["ItemName"] = dbManager.DataReader["ITEM_NAME"].ToString();
                    dr["Value"] = dbManager.DataReader["CF_TP_DET_VALUE"].ToString();
                    dr["CFTpDetId"] = dbManager.DataReader["CF_TP_DET_ID"].ToString();

                    ClaimFormTransferProducts.Rows.Add(dr);
                }

                gv.DataSource = ClaimFormTransferProducts;
                gv.DataBind();
            }
        }

        //Methods For FE Order Profile Form
        public class FEOrderProfile
        {
            public string FEOPId, FEOPNo, FEOPDate, FEOPDocRefNo, CustId, CustUnitId, CustDetId, FEOPPONo, FEOPPODate, FEOPMarketing, FEOPRegion, FEOPTerritory, FEOPDivision, FEOPMarketSegment, FEOPOrders, FEOPForwarder, FEOPPortofLanding, FEOPFOBCharges, FEOPCIFCharges, FEOPDespatchMode, FEOPECCNo, FEOPCSTNo, FEOPLSTNo, FEOPTINNo, FEOPFrieghtCharges, FEOPOctroi, FEOPInsurance, FEOPPatrshipment, FEOPRoadPermitReq, FEOPARE1Trans, FEOPEPCGTrans, FEOPDocEnclosed, FEOPDocNo, FEOPTotItemsValue, FEOPTotDisValue, FEOPTotExWorksValue, FEOPPacking, FEOPExciseDuty, FEOPEduCess, FEOPSecEduCess, FEOPCST, FEOPStampingCharges, FEOPTotalValue, FEOPDeliveryDate, FEOPWarrantyPeriod, FEOPPaymentTerms, FEOPAdvRecdDetails, FEOPChequeDD, FEOPPostalAddress, FEOPContactPerson, FEOPTelNo, FEOPMobileNo, FEOPSplInstr, FEOPOrderBookedBy, FEOPApprovedBy, FEOPName, FEOPSignature, FEOPPerDisc, FEPortOfDestination, EnqId, FEOPDespatchConsignee;
            public string ProdDetId, ItemCode, ProdDetQty, ProdDetCurrency, ProdDetUnitPrice, ProdDetTotalPrice;

            public string BuyerDetId, BuyerDetBuyerType, BuyerDetContactPerson, BuyerDetDesig, BuyerDetTelNo, BuyerDetMobileNo;

            public FEOrderProfile()
            {
            }

            public static string FEOrderProfile_AutoGenCode()
            {
                //string _codePrefix = CurrentFinancialYear() + " ";
                ////string _codePrefix = "WO/";
                //if (dbManager.Transaction == null)
                //    dbManager.Open();
                //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(CONVERT(BIGINT,REPLACE(FEOP_NO,LEFT(FEOP_NO,5),''))),0)+1 FROM [YANTRA_FE_ORDER_PROFILE]").ToString());
                ////_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(REPLACE(WO_NO,'" + _codePrefix + "','')),0)+1 FROM [YANTRA_WO_MAST]").ToString());
                //return _codePrefix + _returnIntValue;
                //return AutoGenMaxNo("YANTRA_FE_ORDER_PROFILE", "FEOP_NO");
                return AutoGenMaxNo("YANTRA_CLAIM_FORM", "CF_NO");
            }

            public string FEOrderProfile_Save()
            {
                this.FEOPNo = FEOrderProfile_AutoGenCode();
                this.FEOPId = AutoGenMaxId("[YANTRA_FE_ORDER_PROFILE]", "FEOP_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_FE_ORDER_PROFILE] SELECT ISNULL(MAX(FEOP_ID),0)+1,'{0}','{1}',{2},{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}','{56}','{57}','{58}' FROM [YANTRA_FE_ORDER_PROFILE]", this.FEOPNo, this.FEOPDate, this.CustId, this.CustUnitId, this.CustDetId, this.FEOPPONo, this.FEOPPODate, this.FEOPMarketing, this.FEOPRegion, this.FEOPTerritory, this.FEOPDivision, this.FEOPMarketSegment, this.FEOPOrders, this.FEOPForwarder, this.FEOPPortofLanding, this.FEOPFOBCharges, this.FEOPCIFCharges, this.FEOPDespatchMode, this.FEOPECCNo, this.FEOPCSTNo, this.FEOPLSTNo, this.FEOPTINNo, this.FEOPFrieghtCharges, this.FEOPOctroi, this.FEOPInsurance, this.FEOPPatrshipment, this.FEOPRoadPermitReq, this.FEOPARE1Trans, this.FEOPEPCGTrans, this.FEOPDocEnclosed, this.FEOPDocNo, this.FEOPTotItemsValue, this.FEOPTotDisValue, this.FEOPTotExWorksValue, this.FEOPPacking, this.FEOPExciseDuty, this.FEOPEduCess, this.FEOPSecEduCess, this.FEOPCST, this.FEOPStampingCharges, this.FEOPTotalValue, this.FEOPDeliveryDate, this.FEOPWarrantyPeriod, this.FEOPPaymentTerms, this.FEOPAdvRecdDetails, this.FEOPChequeDD, this.FEOPPostalAddress, this.FEOPContactPerson, this.FEOPTelNo, this.FEOPMobileNo, this.FEOPSplInstr, this.FEOPOrderBookedBy, this.FEOPApprovedBy, this.FEOPName, this.FEOPSignature, this.FEOPPerDisc, this.FEOPDocRefNo, this.FEPortOfDestination, this.FEOPDespatchConsignee);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _commandText = "INSERT INTO [YANTRA_CLAIM_FORM] (CF_ID,CF_NO,CF_DATE,CUST_ID,CUST_UNIT_ID,CUST_DET_ID,CF_PO_REF_NO,CF_PO_REF_DATE,SUP_ID,CITY_ID,CURRENCY_ID,CF_PREPARED_BY,CF_APPROVED_BY) VALUES(" + AutoGenMaxId("[YANTRA_CLAIM_FORM]", "CF_ID") + ",'" + this.FEOPNo + "','" + this.FEOPDate + "'," + this.CustId + "," + this.CustUnitId + "," + this.CustDetId + ",'" + this.FEOPPONo + "','" + this.FEOPPODate + "',0,0,0,0,0)";
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string FEOrderProfile_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_FE_ORDER_PROFILE] SET FEOP_DATE='{0}',CUST_ID={1},CUST_UNIT_ID={2},CUST_DET_ID={3},FEOP_PO_NO='{4}',FEOP__PO_DATE='{5}',FEOP_MARKETING='{6}',FEOP_REGION='{7}',FEOP_TERRITORY='{8}',FEOP_DIVISION='{9}',FEOP_MARKET_SEGMENT='{10}',FEOP_ORDERS='{11}',FEOP_FORWARDER='{12}',FEOP_PORT_OF_LANDING='{13}',FEOP_FOB_CHARGES='{14}',FEOP_CIF_CHARGES='{15}',FEOP_DESPATCH_MODE='{16}',FEOP_ECC_NO='{17}',FEOP_CST_NO='{18}',FEOP_LST_NO='{19}',FEOP_TIN_NO='{20}',FEOP_FRIEGHT_CHARGES='{21}',FEOP_OCTROI='{22}',FEOP_INSURANCE='{23}',FEOP_PARTSHIPMENT='{24}',FEOP_ROAD_PERMIT_REQUIRED='{25}',FEOP_ARE1_TRANSACTION='{26}',FEOP_EPCG_TRANSACTION='{27}',FEOP_DOCUMENT_ENCLOSED='{28}',FEOP_DOCUMENT_NO='{29}',FEOP_TOTAL_ITEMS_VALUE='{30}',FEOP_DISCOUNTED_VALUE='{31}',FEOP_EXWORKS_VALUE='{32}',FEOP_PACKING_FORWARDING='{33}',FEOP_EXCISE_DUTY='{34}',FEOP_EDU_CESS='{35}',FEOP_SEC_EDU_CESS='{36}',FEOP_CST='{37}',FEOP_STAMPING_CHARGES='{38}',FEOP_TOTAL_VALUE='{39}',FEOP_DELIVERY_DATE='{40}',FEOP_WARRANTY_PERIOD='{41}',FEOP_PAYMENT_TERMS='{42}',FEOP_ADV_RECD_DETAILS='{43}',FEOP_CHEQUE_DD_EPAYMENT='{44}',FEOP_FULL_POSTAL_ADDRESS='{45}',FEOP_CONTACT_PERSON='{46}',FEOP_TELNO_DIRECT='{47}',FEOP_MOBILE_NO='{48}',FEOP_SPL_INSTRUCTIONS='{49}',FEOP_ORDER_BOOKED_BY='{50}',FEOP_APPROVED_BY='{51}',FEOP_NAME='{52}',FEOP_SIGNATURE='{53}',FEOP_PERCENTAGE_DISCOUNT='{54}',FEOP_DOC_REF_NO='{55}',FEOP_PORT_OF_DESTINATION='{56}',FEOP_DESPATCH_CONSIGNEE='{57}' WHERE FEOP_ID={58}", this.FEOPDate, this.CustId, this.CustUnitId, this.CustDetId, this.FEOPPONo, this.FEOPPODate, this.FEOPMarketing, this.FEOPRegion, this.FEOPTerritory, this.FEOPDivision, this.FEOPMarketSegment, this.FEOPOrders, this.FEOPForwarder, this.FEOPPortofLanding, this.FEOPFOBCharges, this.FEOPCIFCharges, this.FEOPDespatchMode, this.FEOPECCNo, this.FEOPCSTNo, this.FEOPLSTNo, this.FEOPTINNo, this.FEOPFrieghtCharges, this.FEOPOctroi, this.FEOPInsurance, this.FEOPPatrshipment, this.FEOPRoadPermitReq, this.FEOPARE1Trans, this.FEOPEPCGTrans, this.FEOPDocEnclosed, this.FEOPDocNo, this.FEOPTotItemsValue, this.FEOPTotDisValue, this.FEOPTotExWorksValue, this.FEOPPacking, this.FEOPExciseDuty, this.FEOPEduCess, this.FEOPSecEduCess, this.FEOPCST, this.FEOPStampingCharges, this.FEOPTotalValue, this.FEOPDeliveryDate, this.FEOPWarrantyPeriod, this.FEOPPaymentTerms, this.FEOPAdvRecdDetails, this.FEOPChequeDD, this.FEOPPostalAddress, this.FEOPContactPerson, this.FEOPTelNo, this.FEOPMobileNo, this.FEOPSplInstr, this.FEOPOrderBookedBy, this.FEOPApprovedBy, this.FEOPName, this.FEOPSignature, this.FEOPPerDisc, this.FEOPDocRefNo, this.FEPortOfDestination, this.FEOPDespatchConsignee, this.FEOPId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string FEOrderProfileApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [YANTRA_FE_ORDER_PROFILE] SET FEOP_APPROVED_BY={0} WHERE FEOP_ID={1}", this.FEOPApprovedBy, this.FEOPId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Status Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string FEOrderProfile_Delete(string FEOrderProfileId)
            {
                SM.BeginTransaction();

                if (DeleteRecord("[YANTRA_FE_ORDER_PROFILE]", "FEOP_ID", FEOrderProfileId) == true)
                {
                    SM.CommitTransaction();
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    SM.RollBackTransaction();
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public int FEOrderProfile_Select(string FEOrderProfileId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_FE_ORDER_PROFILE],[YANTRA_CUSTOMER_MAST],[YANTRA_CUSTOMER_UNITS],[YANTRA_CUSTOMER_DET] WHERE [YANTRA_FE_ORDER_PROFILE].CUST_ID = [YANTRA_CUSTOMER_MAST].CUST_ID " +
                                            " AND [YANTRA_FE_ORDER_PROFILE].CUST_UNIT_ID=[YANTRA_CUSTOMER_UNITS].CUST_UNIT_ID AND [YANTRA_FE_ORDER_PROFILE].CUST_DET_ID=[YANTRA_CUSTOMER_DET].CUST_DET_ID " +
                                            " AND [YANTRA_FE_ORDER_PROFILE].FEOP_ID='" + FEOrderProfileId + "' ORDER BY [YANTRA_FE_ORDER_PROFILE].FEOP_ID DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.FEOPId = dbManager.DataReader["FEOP_ID"].ToString();
                    this.FEOPNo = dbManager.DataReader["FEOP_NO"].ToString();
                    this.FEOPDate = Convert.ToDateTime(dbManager.DataReader["FEOP_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.CustId = dbManager.DataReader["CUST_ID"].ToString();
                    this.CustUnitId = dbManager.DataReader["CUST_UNIT_ID"].ToString();
                    this.CustDetId = dbManager.DataReader["CUST_DET_ID"].ToString();
                    this.FEOPPONo = dbManager.DataReader["FEOP_PO_NO"].ToString();
                    this.FEOPPODate = Convert.ToDateTime(dbManager.DataReader["FEOP__PO_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.FEOPMarketing = dbManager.DataReader["FEOP_MARKETING"].ToString();
                    this.FEOPRegion = dbManager.DataReader["FEOP_REGION"].ToString();
                    this.FEOPTerritory = dbManager.DataReader["FEOP_TERRITORY"].ToString();
                    this.FEOPDivision = dbManager.DataReader["FEOP_DIVISION"].ToString();
                    this.FEOPMarketSegment = dbManager.DataReader["FEOP_MARKET_SEGMENT"].ToString();
                    this.FEOPOrders = dbManager.DataReader["FEOP_ORDERS"].ToString();
                    this.FEOPForwarder = dbManager.DataReader["FEOP_FORWARDER"].ToString();
                    this.FEOPPortofLanding = dbManager.DataReader["FEOP_PORT_OF_LANDING"].ToString();
                    this.FEOPFOBCharges = dbManager.DataReader["FEOP_FOB_CHARGES"].ToString();
                    this.FEOPCIFCharges = dbManager.DataReader["FEOP_CIF_CHARGES"].ToString();
                    this.FEOPDespatchMode = dbManager.DataReader["FEOP_DESPATCH_MODE"].ToString();
                    this.FEOPECCNo = dbManager.DataReader["FEOP_ECC_NO"].ToString();
                    this.FEOPCSTNo = dbManager.DataReader["FEOP_CST_NO"].ToString();
                    this.FEOPLSTNo = dbManager.DataReader["FEOP_LST_NO"].ToString();
                    this.FEOPTINNo = dbManager.DataReader["FEOP_TIN_NO"].ToString();
                    this.FEOPFrieghtCharges = dbManager.DataReader["FEOP_FRIEGHT_CHARGES"].ToString();
                    this.FEOPOctroi = dbManager.DataReader["FEOP_OCTROI"].ToString();
                    this.FEOPInsurance = dbManager.DataReader["FEOP_INSURANCE"].ToString();
                    this.FEOPPatrshipment = dbManager.DataReader["FEOP_PARTSHIPMENT"].ToString();
                    this.FEOPRoadPermitReq = dbManager.DataReader["FEOP_ROAD_PERMIT_REQUIRED"].ToString();
                    this.FEOPARE1Trans = dbManager.DataReader["FEOP_ARE1_TRANSACTION"].ToString();
                    this.FEOPEPCGTrans = dbManager.DataReader["FEOP_EPCG_TRANSACTION"].ToString();
                    this.FEOPDocEnclosed = dbManager.DataReader["FEOP_DOCUMENT_ENCLOSED"].ToString();
                    this.FEOPDocNo = dbManager.DataReader["FEOP_DOCUMENT_NO"].ToString();
                    this.FEOPTotItemsValue = dbManager.DataReader["FEOP_TOTAL_ITEMS_VALUE"].ToString();
                    this.FEOPTotDisValue = dbManager.DataReader["FEOP_DISCOUNTED_VALUE"].ToString();
                    this.FEOPTotExWorksValue = dbManager.DataReader["FEOP_EXWORKS_VALUE"].ToString();
                    this.FEOPPacking = dbManager.DataReader["FEOP_PACKING_FORWARDING"].ToString();
                    this.FEOPExciseDuty = dbManager.DataReader["FEOP_EXCISE_DUTY"].ToString();
                    this.FEOPEduCess = dbManager.DataReader["FEOP_EDU_CESS"].ToString();
                    this.FEOPSecEduCess = dbManager.DataReader["FEOP_SEC_EDU_CESS"].ToString();
                    this.FEOPCST = dbManager.DataReader["FEOP_CST"].ToString();
                    this.FEOPStampingCharges = dbManager.DataReader["FEOP_STAMPING_CHARGES"].ToString();
                    this.FEOPTotalValue = dbManager.DataReader["FEOP_TOTAL_VALUE"].ToString();
                    this.FEOPDeliveryDate = Convert.ToDateTime(dbManager.DataReader["FEOP_DELIVERY_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.FEOPWarrantyPeriod = dbManager.DataReader["FEOP_WARRANTY_PERIOD"].ToString();
                    this.FEOPPaymentTerms = dbManager.DataReader["FEOP_PAYMENT_TERMS"].ToString();
                    this.FEOPAdvRecdDetails = dbManager.DataReader["FEOP_ADV_RECD_DETAILS"].ToString();
                    this.FEOPChequeDD = dbManager.DataReader["FEOP_CHEQUE_DD_EPAYMENT"].ToString();
                    this.FEOPPostalAddress = dbManager.DataReader["FEOP_FULL_POSTAL_ADDRESS"].ToString();
                    this.FEOPContactPerson = dbManager.DataReader["FEOP_CONTACT_PERSON"].ToString();
                    this.FEOPTelNo = dbManager.DataReader["FEOP_TELNO_DIRECT"].ToString();
                    this.FEOPMobileNo = dbManager.DataReader["FEOP_MOBILE_NO"].ToString();
                    this.FEOPSplInstr = dbManager.DataReader["FEOP_SPL_INSTRUCTIONS"].ToString();
                    this.FEOPOrderBookedBy = dbManager.DataReader["FEOP_ORDER_BOOKED_BY"].ToString();
                    this.FEOPApprovedBy = dbManager.DataReader["FEOP_APPROVED_BY"].ToString();
                    this.FEOPName = dbManager.DataReader["FEOP_NAME"].ToString();
                    this.FEOPSignature = dbManager.DataReader["FEOP_SIGNATURE"].ToString();
                    this.FEOPPerDisc = dbManager.DataReader["FEOP_PERCENTAGE_DISCOUNT"].ToString();
                    this.FEOPPerDisc = dbManager.DataReader["FEOP_PERCENTAGE_DISCOUNT"].ToString();
                    this.FEOPDocRefNo = dbManager.DataReader["FEOP_DOC_REF_NO"].ToString();
                    this.FEPortOfDestination = dbManager.DataReader["FEOP_PORT_OF_DESTINATION"].ToString();
                    this.FEOPDespatchConsignee = dbManager.DataReader["FEOP_DESPATCH_CONSIGNEE"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public static void FEOrderProfile_SelectAll(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_FE_ORDER_PROFILE] ORDER BY FEOP_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "FEOP_NO", "FEOP_ID");
                }
            }

            public string FEOrderProfileBuyerDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_FE_ORDER_PROFILE_BUYER_DET] SELECT ISNULL(MAX(FEOP_BUYER_DET_ID),0)+1,'{0}','{1}','{2}','{3}','{4}','{5}' FROM [YANTRA_FE_ORDER_PROFILE_BUYER_DET]", this.FEOPId, this.BuyerDetBuyerType, this.BuyerDetContactPerson, this.BuyerDetDesig, this.BuyerDetTelNo, this.BuyerDetMobileNo);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int FEOrderProfileBuyerDetails_Delete(string FEOrderProfileId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [YANTRA_FE_ORDER_PROFILE_BUYER_DET] WHERE FEOP_ID={0}", FEOrderProfileId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public void FEOrderProfileBuyerDetails_Select(string FEOrderProfileId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_FE_ORDER_PROFILE_BUYER_DET],[YANTRA_FE_ORDER_PROFILE] WHERE [YANTRA_FE_ORDER_PROFILE_BUYER_DET].FEOP_ID=[YANTRA_FE_ORDER_PROFILE].FEOP_ID  AND [YANTRA_FE_ORDER_PROFILE_BUYER_DET].FEOP_ID=" + FEOrderProfileId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable BuyerDetails = new DataTable();
                DataColumn col = new DataColumn();

                col = new DataColumn("BuyerType");
                BuyerDetails.Columns.Add(col);
                col = new DataColumn("ContactPerson");
                BuyerDetails.Columns.Add(col);
                col = new DataColumn("Designation");
                BuyerDetails.Columns.Add(col);
                col = new DataColumn("TelNo");
                BuyerDetails.Columns.Add(col);
                col = new DataColumn("MobileNo");
                BuyerDetails.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = BuyerDetails.NewRow();

                    dr["BuyerType"] = dbManager.DataReader["FEOP_BUYER_DET_BUYER_TYPE"].ToString();
                    dr["ContactPerson"] = dbManager.DataReader["FEOP_BUYER_DET_CONTACT_PERSON"].ToString();
                    dr["Designation"] = dbManager.DataReader["FEOP_BUYER_DET_DESIGNATION"].ToString();
                    dr["TelNo"] = dbManager.DataReader["FEOP_BUYER_DET_TEL_NO"].ToString();
                    dr["MobileNo"] = dbManager.DataReader["FEOP_BUYER_DET_MOBILE_NO"].ToString();

                    BuyerDetails.Rows.Add(dr);
                }

                gv.DataSource = BuyerDetails;
                gv.DataBind();
            }

            public string FEOrderProfileProductDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_FE_ORDER_PROFILE_PRODUCT_DET] SELECT ISNULL(MAX(FEOP_PROD_DET_ID),0)+1,'{0}','{1}','{2}','{3}','{4}','{5}' FROM [YANTRA_FE_ORDER_PROFILE_PRODUCT_DET]", this.FEOPId, this.ItemCode, this.ProdDetQty, this.ProdDetCurrency, this.ProdDetUnitPrice, this.ProdDetTotalPrice);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int FEOrderProfileProductDetails_Delete(string FEOrderProfileId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [YANTRA_FE_ORDER_PROFILE_PRODUCT_DET] WHERE FEOP_ID={0}", FEOrderProfileId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public void FEOrderProfileProductDetails_Select(string FEOrderProfileId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_FE_ORDER_PROFILE_PRODUCT_DET],[YANTRA_FE_ORDER_PROFILE],[YANTRA_ITEM_MAST] WHERE [YANTRA_FE_ORDER_PROFILE_PRODUCT_DET].FEOP_ID=[YANTRA_FE_ORDER_PROFILE].FEOP_ID AND [YANTRA_FE_ORDER_PROFILE_PRODUCT_DET].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE AND [YANTRA_FE_ORDER_PROFILE_PRODUCT_DET].FEOP_ID=" + FEOrderProfileId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable ProductDetails = new DataTable();
                DataColumn col = new DataColumn();

                col = new DataColumn("ItemName");
                ProductDetails.Columns.Add(col);
                col = new DataColumn("Qty");
                ProductDetails.Columns.Add(col);
                col = new DataColumn("Currency");
                ProductDetails.Columns.Add(col);
                col = new DataColumn("UnitPrice");
                ProductDetails.Columns.Add(col);
                col = new DataColumn("TotalPrice");
                ProductDetails.Columns.Add(col);
                col = new DataColumn("ItemCode");
                ProductDetails.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = ProductDetails.NewRow();
                    dr["ItemName"] = dbManager.DataReader["ITEM_NAME"].ToString();
                    dr["Qty"] = dbManager.DataReader["FEOP_PROD_DET_QTY"].ToString();
                    dr["Currency"] = dbManager.DataReader["FEOP_PROD_DET_CURRENCY"].ToString();
                    dr["UnitPrice"] = dbManager.DataReader["FEOP_PROD_DET_UNIT_PRICE"].ToString();
                    dr["TotalPrice"] = dbManager.DataReader["FEOP_PROD_DET_TOTAL_PRICE"].ToString();
                    dr["ItemCode"] = dbManager.DataReader["ITEM_CODE"].ToString();
                    ProductDetails.Rows.Add(dr);
                }
                gv.DataSource = ProductDetails;
                gv.DataBind();
            }
        }

        //Methods For Advertisement Agency Information
        public class AdvertisingAgencyInformation
        {
            public string AAIId, AAINo, AAIDate, AdvmId, AaId, AmId, AAIOrgName, AAISubscriptionDate, AAIEventName,
             AAIEventOnDate, AAIEventTillDate, AAISponsorshipMode, AAISponsorshipDate, AAIAdvertisement, AAIAdvtApprovedDate, SaId, AAIAdvtPublishingDate,
             AAIInvoiceNo, AAIInvoiceDate, AAIInvoiceAmount, AAIPayMode, AAIAdvanceGiven, AAIPaymentDate, AAIChequeNo,
             AAIChequeDate, AAIBankDetails, AAIBalnceAmount, AAIFullPayMode, AAIFullAmountPaid, AAIFullPaymentDate,
                AAIFullChequeNo, AAIFullChequeDate, AAIFullBankDetails;

            public AdvertisingAgencyInformation()
            {
            }

            public static string AdvertisingAgencyInformation_AutoGenCode()
            {
                string _codePrefix = CurrentFinancialYear() + " ";

                if (dbManager.Transaction == null)
                    dbManager.Open();
                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(CONVERT(BIGINT,REPLACE(AAI_NO,LEFT(AAI_NO,5),''))),0)+1 FROM [YANTRA_ADVERTISING_AGENSIES_INFO]").ToString());
                return _codePrefix + _returnIntValue;
            }

            public string AdvertisingAgencyInformation_Save()
            {
                this.AAINo = AdvertisingAgencyInformation_AutoGenCode();
                this.AAIId = AutoGenMaxId("[YANTRA_ADVERTISING_AGENSIES_INFO]", "AAI_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_ADVERTISING_AGENSIES_INFO] SELECT ISNULL(MAX(AAI_ID),0)+1,'{0}','{1}',{2},{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',{14},'{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}' FROM [YANTRA_ADVERTISING_AGENSIES_INFO]",
                    this.AAINo, this.AAIDate, this.AdvmId, this.AaId, this.AmId, this.AAIOrgName, this.AAISubscriptionDate, this.AAIEventName, this.AAIEventOnDate, this.AAIEventTillDate, this.AAISponsorshipMode, this.AAISponsorshipDate, this.AAIAdvertisement, this.AAIAdvtApprovedDate, this.SaId, this.AAIAdvtPublishingDate, this.AAIInvoiceNo, this.AAIInvoiceDate, this.AAIInvoiceAmount, this.AAIPayMode, this.AAIAdvanceGiven, this.AAIPaymentDate, this.AAIChequeNo, this.AAIChequeDate, this.AAIBankDetails, this.AAIBalnceAmount, this.AAIFullPayMode, this.AAIFullAmountPaid, this.AAIFullPaymentDate, this.AAIFullChequeNo, this.AAIFullChequeDate, this.AAIFullBankDetails);

                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string AdvertisingAgencyInformation_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_ADVERTISING_AGENSIES_INFO] SET  AAI_NO='{0}',AAI_DATE='{1}',ADVM_ID={2},AA_ID={3},AM_ID={4},AAI_ORG_NAME='{5}',AAI_SUBSCRIPTION_DATE='{6}',AAI_EVENT_NAME='{7}',AAI_EVENT_ON_DATE='{8}',AAI_EVENT_TILL_DATE='{9}',AAI_SPONSORSHIP_MODE='{10}',AAI_SPONSORSHIP_DATE='{11}',AAI_ADVERTISEMENT='{12}',AAI_ADVT_APPROVED_DATE='{13}',SA_ID={14},AAI_ADVT_PUBLISHING_DATE='{15}',AAI_INVOICE_NO='{16}',AAI_INVOICE_DATE='{17}',AAI_INVOICE_AMOUNT='{18}',AAI_PAY_MODE='{19}',AAI_ADVANCE_GIVEN='{20}',AAI_PAYMENT_DATE='{21}',AAI_CHEQUE_NO='{22}',AAI_CHEQUE_DATE='{23}',AAI_BANK_DETAILS='{24}',AAI_BALANCE_AMOUNT='{25}',AAI_FULL_PAY_MODE='{26}',AAI_FULL_AMOUNT_PAID='{27}',AAI_FULL_PAYMENT_DATE='{28}',AAI_FULL_CHEQUE_NO='{29}',AAI_FULL_CHEQUE_DATE='{30}',AAI_FULL_BANK_DETAILS='{31}' WHERE AAI_ID={32}",
                 this.AAINo, this.AAIDate, this.AdvmId, this.AaId, this.AmId, this.AAIOrgName, this.AAISubscriptionDate, this.AAIEventName,
                    this.AAIEventOnDate, this.AAIEventTillDate, this.AAISponsorshipMode, this.AAISponsorshipDate, this.AAIAdvertisement, this.AAIAdvtApprovedDate, this.SaId, this.AAIAdvtPublishingDate,
                    this.AAIInvoiceNo, this.AAIInvoiceDate, this.AAIInvoiceAmount, this.AAIPayMode, this.AAIAdvanceGiven, this.AAIPaymentDate, this.AAIChequeNo,
                    this.AAIChequeDate, this.AAIBankDetails, this.AAIBalnceAmount, this.AAIFullPayMode, this.AAIFullAmountPaid, this.AAIFullPaymentDate, this.AAIFullChequeNo, this.AAIFullChequeDate, this.AAIFullBankDetails, this.AAIId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string AdvertisingAgencyInformation_Delete(string AdvertisingInfoId)
            {
                if (DeleteRecord("[YANTRA_ADVERTISING_AGENSIES_INFO]", "AAI_ID", AdvertisingInfoId) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public static void AdvertisingAgencyInformation_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_ADVERTISING_AGENSIES_INFO] ORDER BY AAI_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "AAI_NO", "AAI_ID");
                }
            }

            public int AdvertisingAgencyInformation_Select(string AdvertisingInfoId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [YANTRA_ADVERTISING_AGENSIES_INFO],[YANTRA_ADVERTISING_MAGZINES],[YANTRA_ADVERTISING_AGENCY],[YANTRA_ADVERTISING_MODE],[YANTRA_SIZE_OF_ADVERTISING]" +
                                                " WHERE [YANTRA_ADVERTISING_AGENSIES_INFO].ADVM_ID=[YANTRA_ADVERTISING_MODE].ADVM_ID  " +

                                                " AND [YANTRA_ADVERTISING_AGENSIES_INFO].AA_ID=[YANTRA_ADVERTISING_AGENCY].AA_ID " +
                     " AND [YANTRA_ADVERTISING_AGENSIES_INFO].AM_ID=[YANTRA_ADVERTISING_MAGZINES].AM_ID  " +
                      " AND [YANTRA_ADVERTISING_AGENSIES_INFO].SA_ID=[YANTRA_SIZE_OF_ADVERTISING].SA_ID   " +
                                                " AND [YANTRA_ADVERTISING_AGENSIES_INFO].AAI_ID='" + AdvertisingInfoId + "' ORDER BY [YANTRA_ADVERTISING_AGENSIES_INFO].AAI_ID DESC ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                if (dbManager.DataReader.Read())
                {
                    this.AAIId = dbManager.DataReader["AAI_ID"].ToString();
                    this.AAINo = dbManager.DataReader["AAI_NO"].ToString();
                    this.AAIDate = Convert.ToDateTime(dbManager.DataReader["AAI_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.AdvmId = dbManager.DataReader["ADVM_ID"].ToString();
                    this.AaId = dbManager.DataReader["AA_ID"].ToString();
                    this.AmId = dbManager.DataReader["AM_ID"].ToString();
                    this.AAIOrgName = dbManager.DataReader["AAI_ORG_NAME"].ToString();
                    this.AAISubscriptionDate = Convert.ToDateTime(dbManager.DataReader["AAI_SUBSCRIPTION_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.AAIEventName = dbManager.DataReader["AAI_EVENT_NAME"].ToString();
                    this.AAIEventOnDate = Convert.ToDateTime(dbManager.DataReader["AAI_EVENT_ON_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.AAIEventTillDate = Convert.ToDateTime(dbManager.DataReader["AAI_EVENT_TILL_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.AAISponsorshipMode = dbManager.DataReader["AAI_SPONSORSHIP_MODE"].ToString();
                    this.AAISponsorshipDate = Convert.ToDateTime(dbManager.DataReader["AAI_SPONSORSHIP_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.AAIAdvertisement = dbManager.DataReader["AAI_ADVERTISEMENT"].ToString();
                    this.AAIAdvtApprovedDate = Convert.ToDateTime(dbManager.DataReader["AAI_ADVT_APPROVED_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.SaId = dbManager.DataReader["SA_ID"].ToString();
                    this.AAIAdvtPublishingDate = Convert.ToDateTime(dbManager.DataReader["AAI_ADVT_PUBLISHING_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.AAIInvoiceNo = dbManager.DataReader["AAI_INVOICE_NO"].ToString();
                    this.AAIInvoiceDate = Convert.ToDateTime(dbManager.DataReader["AAI_INVOICE_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.AAIInvoiceAmount = dbManager.DataReader["AAI_INVOICE_AMOUNT"].ToString();
                    this.AAIPayMode = dbManager.DataReader["AAI_PAY_MODE"].ToString();
                    this.AAIAdvanceGiven = dbManager.DataReader["AAI_ADVANCE_GIVEN"].ToString();
                    this.AAIPaymentDate = Convert.ToDateTime(dbManager.DataReader["AAI_PAYMENT_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.AAIChequeNo = dbManager.DataReader["AAI_CHEQUE_NO"].ToString();
                    this.AAIChequeDate = Convert.ToDateTime(dbManager.DataReader["AAI_CHEQUE_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.AAIBankDetails = dbManager.DataReader["AAI_BANK_DETAILS"].ToString();
                    this.AAIBalnceAmount = dbManager.DataReader["AAI_BALANCE_AMOUNT"].ToString();
                    this.AAIFullPayMode = dbManager.DataReader["AAI_FULL_PAY_MODE"].ToString();
                    this.AAIFullAmountPaid = dbManager.DataReader["AAI_FULL_AMOUNT_PAID"].ToString();
                    this.AAIFullPaymentDate = Convert.ToDateTime(dbManager.DataReader["AAI_FULL_PAYMENT_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.AAIFullChequeNo = dbManager.DataReader["AAI_FULL_CHEQUE_NO"].ToString();
                    this.AAIFullChequeDate = Convert.ToDateTime(dbManager.DataReader["AAI_FULL_CHEQUE_DATE"].ToString()).ToString("MM/dd/yyyy");
                    this.AAIFullBankDetails = dbManager.DataReader["AAI_FULL_BANK_DETAILS"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }

        //Methods For AdvertisingAgency
        public class AdvertisingAgency
        {
            public string AaId, AaName, AaDesc;

            public AdvertisingAgency()
            {
            }

            public string AdvertisingAgency_AutoGen()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(AA_ID),0)+1 FROM YANTRA_ADVERTISING_AGENCY").ToString());
                return _returnIntValue.ToString();
            }

            public string AdvertisingAgency_Save()
            {
                this.AaId = AdvertisingAgency_AutoGen();

                dbManager.Open();
                if (IsRecordExists("[YANTRA_ADVERTISING_AGENCY]", "AA_NAME", this.AaName) == false)
                {
                    _commandText = string.Format("INSERT INTO [YANTRA_ADVERTISING_AGENCY] SELECT ISNULL(MAX(AA_ID),0)+1,'{0}','{1}' FROM [YANTRA_ADVERTISING_AGENCY]", this.AaName, this.AaDesc);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Advertising Agency Name Already Exists.";
                }
                return _returnStringMessage;
            }

            public string AdvertisingAgency_Update()
            {
                dbManager.Open();
                if (IsRecordExists("[YANTRA_ADVERTISING_AGENCY]", "AA_NAME", this.AaName, "AA_ID", this.AaId) == false)
                {
                    _commandText = string.Format("UPDATE [YANTRA_ADVERTISING_AGENCY] SET AA_NAME='{0}',AA_DESC='{1}' WHERE AA_ID={2}", this.AaName, this.AaDesc, this.AaId);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Advertising Agency Already Exists.";
                }
                return _returnStringMessage;
            }

            public string AdvertisingAgency_Delete()
            {
                Masters.BeginTransaction();
                if (DeleteRecord("[YANTRA_ADVERTISING_AGENCY]", "AA_ID", this.AaId) == true)
                {
                    Masters.CommitTransaction();
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    Masters.RollBackTransaction();
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public static void AdvertisingAgency_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_ADVERTISING_AGENCY] ORDER BY AA_NAME");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "AA_NAME", "AA_ID");
                }
            }

            public int AdvertisingAgency_Select(string AdvertisingId)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_ADVERTISING_AGENCY] WHERE AA_ID=" + AdvertisingId + " ORDER BY AA_ID");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.AaId = dbManager.DataReader["AA_ID"].ToString();
                    this.AaName = dbManager.DataReader["AA_NAME"].ToString();
                    this.AaDesc = dbManager.DataReader["AA_DESC"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }

        //Methods For Advertising Mode
        public class AdvertisingMode
        {
            public string AdvmId, AdvmName, AdvmDesc;

            public AdvertisingMode()
            {
            }

            public string AdvertisingMode_AutoGen()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(ADVM_ID),0)+1 FROM YANTRA_ADVERTISING_MODE").ToString());
                return _returnIntValue.ToString();
            }

            public string AdvertisingMode_Save()
            {
                this.AdvmId = AdvertisingMode_AutoGen();

                dbManager.Open();
                if (IsRecordExists("[YANTRA_ADVERTISING_MODE]", "ADVM_NAME", this.AdvmName) == false)
                {
                    _commandText = string.Format("INSERT INTO [YANTRA_ADVERTISING_MODE] SELECT ISNULL(MAX(ADVM_ID),0)+1,'{0}','{1}' FROM [YANTRA_ADVERTISING_MODE]", this.AdvmName, this.AdvmDesc);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Advertising Name Already Exists.";
                }
                return _returnStringMessage;
            }

            public string AdvertisingMode_Update()
            {
                dbManager.Open();
                if (IsRecordExists("[YANTRA_ADVERTISING_MODE]", "ADVM_NAME", this.AdvmName, "ADVM_ID", this.AdvmId) == false)
                {
                    _commandText = string.Format("UPDATE [YANTRA_ADVERTISING_MODE] SET ADVM_NAME='{0}',ADVM_DESC='{1}' WHERE ADVM_ID={2}", this.AdvmName, this.AdvmDesc, this.AdvmId);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Advertising Already Exists.";
                }
                return _returnStringMessage;
            }

            public string AdvertisingMode_Delete()
            {
                Masters.BeginTransaction();
                if (DeleteRecord("[YANTRA_ADVERTISING_MODE]", "ADVM_ID", this.AdvmId) == true)
                {
                    Masters.CommitTransaction();
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    Masters.RollBackTransaction();
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public static void AdvertisingMode_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_ADVERTISING_MODE] ORDER BY ADVM_NAME");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "ADVM_NAME", "ADVM_ID");
                }
            }

            public int AdvertisingMode_Select(string AdvertisingId)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_ADVERTISING_MODE] WHERE ADVM_ID=" + AdvertisingId + " ORDER BY ADVM_ID");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.AdvmId = dbManager.DataReader["ADVM_ID"].ToString();
                    this.AdvmName = dbManager.DataReader["ADVM_NAME"].ToString();
                    this.AdvmDesc = dbManager.DataReader["ADVM_DESC"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }

        //Methods For Magzines
        public class AdvertisingMagzines
        {
            public string AmId, AmName, AmDesc;

            public AdvertisingMagzines()
            {
            }

            public string AdvertisingMagzines_AutoGen()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(AM_ID),0)+1 FROM YANTRA_ADVERTISING_MAGZINES").ToString());
                return _returnIntValue.ToString();
            }

            public string AdvertisingMagzines_Save()
            {
                this.AmId = AdvertisingMagzines_AutoGen();

                dbManager.Open();
                if (IsRecordExists("[YANTRA_ADVERTISING_MAGZINES]", "AM_NAME", this.AmName) == false)
                {
                    _commandText = string.Format("INSERT INTO [YANTRA_ADVERTISING_MAGZINES] SELECT ISNULL(MAX(AM_ID),0)+1,'{0}','{1}' FROM [YANTRA_ADVERTISING_MAGZINES]", this.AmName, this.AmDesc);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Advertising Magzine Name Already Exists.";
                }
                return _returnStringMessage;
            }

            public string AdvertisingMagzines_Update()
            {
                dbManager.Open();
                if (IsRecordExists("[YANTRA_ADVERTISING_MAGZINES]", "AM_NAME", this.AmName, "AM_ID", this.AmId) == false)
                {
                    _commandText = string.Format("UPDATE [YANTRA_ADVERTISING_MAGZINES] SET AM_NAME='{0}',AM_DESC='{1}' WHERE AM_ID={2}", this.AmName, this.AmDesc, this.AmId);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Advertising Magzine Already Exists.";
                }
                return _returnStringMessage;
            }

            public string AdvertisingMagzines_Delete()
            {
                Masters.BeginTransaction();
                if (DeleteRecord("[YANTRA_ADVERTISING_MAGZINES]", "AM_ID", this.AmId) == true)
                {
                    Masters.CommitTransaction();
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    Masters.RollBackTransaction();
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public static void AdvertisingMagzines_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_ADVERTISING_MAGZINES] ORDER BY AM_NAME");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "AM_NAME", "AM_ID");
                }
            }

            public int AdvertisingMagzines_Select(string AdvertisingId)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_ADVERTISING_MAGZINES] WHERE AM_ID=" + AdvertisingId + " ORDER BY AM_ID");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.AmId = dbManager.DataReader["AM_ID"].ToString();
                    this.AmName = dbManager.DataReader["AM_NAME"].ToString();
                    this.AmDesc = dbManager.DataReader["AM_DESC"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }

        //Methods For SizeOfAdvertising
        public class SizeOfAdvertising
        {
            public string SaId, SaDesc, SaSize;

            public SizeOfAdvertising()
            {
            }

            public string SizeOfAdvertising_AutoGen()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(SA_ID),0)+1 FROM YANTRA_SIZE_OF_ADVERTISING").ToString());
                return _returnIntValue.ToString();
            }

            public string SizeOfAdvertising_Save()
            {
                this.SaId = SizeOfAdvertising_AutoGen();

                dbManager.Open();
                if (IsRecordExists("[YANTRA_SIZE_OF_ADVERTISING]", "SA_ID", this.SaId) == false)
                {
                    _commandText = string.Format("INSERT INTO [YANTRA_SIZE_OF_ADVERTISING] SELECT ISNULL(MAX(SA_ID),0)+1,'{0}','{1}' FROM [YANTRA_SIZE_OF_ADVERTISING]", this.SaSize, this.SaDesc);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Advertising  Already Exists.";
                }
                return _returnStringMessage;
            }

            public string SizeOfAdvertising_Update()
            {
                dbManager.Open();
                if (IsRecordExists("[YANTRA_SIZE_OF_ADVERTISING]", "SA_SIZE", this.SaSize, "SA_ID", this.SaId) == false)
                {
                    _commandText = string.Format("UPDATE [YANTRA_SIZE_OF_ADVERTISING] SET SA_SIZE='{0}',SA_DESC='{1}' WHERE SA_ID={2}", this.SaSize, this.SaDesc, this.SaId);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Advertising  Already Exists.";
                }
                return _returnStringMessage;
            }

            public string SizeOfAdvertising_Delete()
            {
                Masters.BeginTransaction();
                if (DeleteRecord("[YANTRA_SIZE_OF_ADVERTISING]", "SA_ID", this.SaId) == true)
                {
                    Masters.CommitTransaction();
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    Masters.RollBackTransaction();
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public static void SizeOfAdvertising_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_SIZE_OF_ADVERTISING] ORDER BY SA_SIZE");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "SA_SIZE", "SA_ID");
                }
            }

            public int SizeOfAdvertising_Select(string AdvertisingId)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_SIZE_OF_ADVERTISING] WHERE SA_ID=" + AdvertisingId + " ORDER BY SA_ID");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SaId = dbManager.DataReader["SA_ID"].ToString();
                    this.SaSize = dbManager.DataReader["SA_SIZE"].ToString();
                    this.SaDesc = dbManager.DataReader["SA_DESC"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }

        //Methods For SDBG Details
        public class SDBG
        {
            public string SDBGId, SDBGNo, SDBGDate, CustId, SDBGStatementOf, EnqId, SoId;
            public string SDBGDetId, SDBGDetStatementOf, SDBGDetNo, SDBGDetDDNo, SDBGDetDated, SDBGDetAmount, SDBGDetBank, SDBGDetDueDate, SDBGDetRemarks;

            public SDBG()
            {
            }

            public static string SDBG_AutoGenCode()
            {
                //string _codePrefix = CurrentFinancialYear() + " ";
                //if (dbManager.Transaction == null)
                //    dbManager.Open();
                //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(CONVERT(BIGINT,REPLACE(SDBG_NO,LEFT(SDBG_NO,5),''))),0)+1 FROM [YANTRA_SDBG_MAST]").ToString());
                //return _codePrefix + _returnIntValue;
                return AutoGenMaxNo("YANTRA_SDBG_MAST", "SDBG_NO");
            }

            public static string SDBGDetails_AutoGenCode()
            {
                string _codePrefix = CurrentFinancialYear() + " ";
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(CONVERT(BIGINT,REPLACE(SDBG_DET_NO,LEFT(SDBG_DET_NO,5),''))),0)+1 FROM [YANTRA_SDBG_DET]").ToString());
                return _codePrefix + _returnIntValue;
            }

            public string SDBG_Save()
            {
                this.SDBGNo = SDBG_AutoGenCode();
                this.SDBGId = AutoGenMaxId("[YANTRA_SDBG_MAST]", "SDBG_ID");
                this.SDBGDetNo = SDBGDetails_AutoGenCode();
                this.SDBGDetId = AutoGenMaxId("[YANTRA_SDBG_DET]", "SDBG_DET_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_SDBG_MAST] SELECT ISNULL(MAX(SDBG_ID),0)+1,'{0}','{1}',{2},'{3}',{4},{5} FROM [YANTRA_SDBG_MAST]",
                                                                                                             this.SDBGNo, this.SDBGDate, this.CustId, this.SDBGStatementOf, this.EnqId, this.SoId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string SDBG_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_SDBG_MAST] SET SDBG_NO='{0}',SDBG_DATE='{1}',CUST_ID={2},SDBG_STATEMENT_OF='{3}',ENQ_ID={4},SO_ID={5} WHERE SDBG_ID={6}",
                                                                          this.SDBGNo, Convert.ToDateTime(this.SDBGDate), this.CustId, this.SDBGStatementOf, this.EnqId, this.SoId, this.SDBGId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string SDBG_Delete(string SDBGId)
            {
                SM.BeginTransaction();
                if (DeleteRecord("[YANTRA_SDBG_DET]", "SDBG_ID", SDBGId) == true)
                {
                    if (DeleteRecord("[YANTRA_SDBG_MAST]", "SDBG_ID", SDBGId) == true)
                    {
                        SM.CommitTransaction();
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        SM.RollBackTransaction();
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                }
                else
                {
                    SM.RollBackTransaction();
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public static void SDBG_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_SDBG_MAST] ORDER BY SDBG_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "SDBG_NO", "SDBG_ID");
                }
            }

            public int SDBG_Select(string SDBGId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [YANTRA_SDBG_MAST],[YANTRA_SO_MAST],[YANTRA_CUSTOMER_MAST],[YANTRA_ENQ_MAST]" +
                                                                        " WHERE [YANTRA_SDBG_MAST].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID  " +
                                                                        " AND [YANTRA_SDBG_MAST].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID  " +
                                                                        " AND [YANTRA_SDBG_MAST].SO_ID=[YANTRA_SO_MAST].SO_ID  " +
                                                                        //" AND [YANTRA_ENQ_MAST].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID " +
                                                                        " AND [YANTRA_SDBG_MAST].SDBG_ID='" + SDBGId + "' ORDER BY [YANTRA_SDBG_MAST].SDBG_ID DESC ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SDBGId = dbManager.DataReader["SDBG_ID"].ToString();
                    this.SDBGNo = dbManager.DataReader["SDBG_NO"].ToString();
                    this.SDBGDate = Convert.ToDateTime(dbManager.DataReader["SDBG_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.CustId = dbManager.DataReader["CUST_ID"].ToString();
                    this.SDBGStatementOf = dbManager.DataReader["SDBG_STATEMENT_OF"].ToString();
                    this.EnqId = dbManager.DataReader["ENQ_ID"].ToString();
                    this.SoId = dbManager.DataReader["SO_ID"].ToString();
                    //this.SDBGDdNO = dbManager.DataReader["SDBG_DDNO"].ToString();
                    //this.SDBGDdDate = Convert.ToDateTime(dbManager.DataReader["SDBG_DDDATE"].ToString()).ToString("dd/MM/yyyy");
                    //this.SDBGAmount = dbManager.DataReader["SDBG_AMOUNT"].ToString();
                    //this.SDBGBank = dbManager.DataReader["SDBG_BANK"].ToString();
                    //this.SDBGDueDate = Convert.ToDateTime(dbManager.DataReader["SDBG_DUE_DATE"].ToString()).ToString("dd/MM/yyyy");
                    //this.SDBGRemarks = dbManager.DataReader["SDBG_REMARKS"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string SDBGDetails_Save()
            {
                //this.SDBGDetNo = SDBGDetails_AutoGenCode();
                //this.SDBGDetId = AutoGenMaxId("[YANTRA_SDBG_DET]", "SDBG_DET_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_SDBG_DET] SELECT ISNULL(MAX(SDBG_DET_ID),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}'FROM [YANTRA_SDBG_DET]",
                                                                                                                              this.SDBGId, this.SDBGDetNo, this.SDBGDetDDNo, this.SDBGDetDated, this.SDBGDetAmount, this.SDBGDetBank, this.SDBGDetDueDate, this.SDBGDetRemarks);

                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int SDBGDetails_Delete(string SDBGId)
            {
                if (DeleteRecord("[YANTRA_SDBG_DET]", "SDBG_ID", SDBGId) == true)
                { _returnIntValue = 1; }
                else
                { _returnIntValue = 0; }
                return _returnIntValue;
            }

            public void SDBGDetails_Select(string SDBGId, GridView gv)
            {
                // dbManager.Open();
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [YANTRA_SDBG_DET] WHERE SDBG_ID = " + SDBGId + "");

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SdbgProducts = new DataTable();
                DataColumn col = new DataColumn();
                //col = new DataColumn("StatementOf");
                //SdbgProducts.Columns.Add(col);
                col = new DataColumn("SDNumber");
                SdbgProducts.Columns.Add(col);
                col = new DataColumn("DDNo");
                SdbgProducts.Columns.Add(col);
                //col = new DataColumn("UOM");
                //ClaimFormProducts.Columns.Add(col);
                col = new DataColumn("DDDate");
                SdbgProducts.Columns.Add(col);
                col = new DataColumn("Amount");
                SdbgProducts.Columns.Add(col);
                col = new DataColumn("Bank");
                SdbgProducts.Columns.Add(col);
                col = new DataColumn("DueDate");
                SdbgProducts.Columns.Add(col);
                col = new DataColumn("Remarks");
                SdbgProducts.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SdbgProducts.NewRow();
                    //dr["StatementOf"] = dbManager.DataReader["SDBG_DET_STATEMENT_OF"].ToString();
                    dr["SDNumber"] = dbManager.DataReader["SDBG_DET_NO"].ToString();
                    dr["DDNo"] = dbManager.DataReader["SDBG_DET_DD_NO"].ToString();
                    dr["DDDate"] = Convert.ToDateTime(dbManager.DataReader["SDBG_DET_DATED"].ToString()).ToString("dd/MM/yyyy");
                    dr["Amount"] = dbManager.DataReader["SDBG_DET_AMOUNT"].ToString();
                    dr["Bank"] = dbManager.DataReader["SDBG_DET_BANK"].ToString();
                    dr["DueDate"] = Convert.ToDateTime(dbManager.DataReader["SDBG_DET_DUE_DATE"].ToString()).ToString("dd/MM/yyyy");

                    dr["Remarks"] = dbManager.DataReader["SDBG_DET_REMARKS"].ToString();

                    SdbgProducts.Rows.Add(dr);
                }

                gv.DataSource = SdbgProducts;
                gv.DataBind();
                //}
            }
        }

        //Methods For SDBG  Receipts Details
        public class SDBGReceipts
        {
            public string SDBGReceiptsId, SDBGReceiptsNo, SDBGReceiptsDate, CustId, SDBGReceiptsStatementOf, SDBGDetId, SDBGDETDATE, SDBGReceiptsPayMode, SDBGReceiptsDdChequeNo, SDBGReceiptsDDChequeDate, SDBGReceiptsBankDetails, SDBGReceiptsDueDate, SDBGReceiptsRemarks, SOID, ENQID;

            public SDBGReceipts()
            {
            }

            public static string SDBGReceipts_AutoGenCode()
            {
                //string _codePrefix = CurrentFinancialYear() + " ";
                //if (dbManager.Transaction == null)
                //    dbManager.Open();
                //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(CONVERT(BIGINT,REPLACE(SDBG_RECEIPTS_NO,LEFT(SDBG_RECEIPTS_NO,5),''))),0)+1 FROM [YANTRA_SDBG_RECEIPTS]").ToString());
                //return _codePrefix + _returnIntValue;
                return AutoGenMaxNo("YANTRA_SDBG_RECEIPTS", "SDBG_RECEIPTS_NO");
            }

            public string SDBGReceipts_Save()
            {
                this.SDBGReceiptsNo = SDBGReceipts_AutoGenCode();
                this.SDBGReceiptsId = AutoGenMaxId("[YANTRA_SDBG_RECEIPTS]", "SDBG_RECEIPTS_ID");

                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_SDBG_RECEIPTS] SELECT ISNULL(MAX(SDBG_RECEIPTS_ID),0)+1,'{0}','{1}',{2},'{3}',{4},'{5}','{6}','{7}','{8}','{9}','{10}' FROM [YANTRA_SDBG_RECEIPTS]",
                                                                                                             this.SDBGReceiptsNo, this.SDBGReceiptsDate, this.CustId, this.SDBGReceiptsStatementOf, this.SDBGDetId, this.SDBGReceiptsPayMode, this.SDBGReceiptsDdChequeNo, this.SDBGReceiptsDDChequeDate, this.SDBGReceiptsBankDetails, this.SDBGReceiptsDueDate, this.SDBGReceiptsRemarks);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string SDBGReceipts_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_SDBG_RECEIPTS] SET SDBG_RECEIPTS_NO='{0}',SDBG_RECEIPTS_DATE='{1}',CUST_ID={2},SDBG_RECEIPTS_STATEMENT_OF='{3}',SDBG_DET_ID={4},SDBG_RECEIPTS_PAY_MODE='{5}',SDBG_RECEIPTS_DD_CHEQUE_NO='{6}',SDBG_RECEIPTS_DD_CHEQUE_DATE='{7}',SDBG_RECEIPTS_BANK_DETAILS='{8}',SDBG_RECEIPTS_DUE_DATE='{9}',SDBG_RECEIPTS_REMARKS='{10}' WHERE SDBG_RECEIPTS_ID={11}",

                                                                           this.SDBGReceiptsNo, Convert.ToDateTime(this.SDBGReceiptsDate), this.CustId, this.SDBGReceiptsStatementOf, this.SDBGDetId, this.SDBGReceiptsPayMode, this.SDBGReceiptsDdChequeNo, Convert.ToDateTime(this.SDBGReceiptsDDChequeDate), this.SDBGReceiptsBankDetails, Convert.ToDateTime(this.SDBGReceiptsDueDate), this.SDBGReceiptsRemarks, this.SDBGReceiptsId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string SDBGReceipts_Delete(string SDBGReceiptsId)
            {
                if (DeleteRecord("[YANTRA_SDBG_RECEIPTS]", "SDBG_RECEIPTS_ID", SDBGReceiptsId) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public static void SDBGReceipts_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_SDBG_RECEIPTS] ORDER BY SDBG_RECEIPTS_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "SDBG_RECEIPTS_NO", "SDBG_RECEIPTS_ID");
                }
            }

            public int SDBGReceipts_Select(string SDBGReceiptsId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM YANTRA_SDBG_RECEIPTS, [YANTRA_SDBG_MAST],[YANTRA_SO_MAST],[YANTRA_CUSTOMER_MAST],[YANTRA_ENQ_MAST],YANTRA_SDBG_DET " +
                                                                        " WHERE [YANTRA_SDBG_RECEIPTS].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID   " +
                                                                        " AND [YANTRA_SDBG_MAST].ENQ_ID=[YANTRA_ENQ_MAST].ENQ_ID   " +
                                                                         " AND [YANTRA_SDBG_MAST].SO_ID=[YANTRA_SO_MAST].SO_ID     " +
                                                                          " AND YANTRA_SDBG_RECEIPTS.SDBG_DET_ID=[YANTRA_SDBG_DET].SDBG_DET_ID     " +
                                                                            " AND YANTRA_SDBG_DET.SDBG_ID=YANTRA_SDBG_MAST.SDBG_ID       " +

                                                                        " AND [YANTRA_SDBG_RECEIPTS].SDBG_RECEIPTS_ID='" + SDBGReceiptsId + "' ORDER BY [YANTRA_SDBG_RECEIPTS].SDBG_RECEIPTS_ID DESC ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SDBGReceiptsId = dbManager.DataReader["SDBG_RECEIPTS_ID"].ToString();
                    this.SDBGReceiptsNo = dbManager.DataReader["SDBG_RECEIPTS_NO"].ToString();
                    this.SDBGReceiptsDate = Convert.ToDateTime(dbManager.DataReader["SDBG_RECEIPTS_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.CustId = dbManager.DataReader["CUST_ID"].ToString();
                    this.SOID = dbManager.DataReader["SO_ID"].ToString();
                    this.ENQID = dbManager.DataReader["ENQ_ID"].ToString();
                    this.SDBGDETDATE = dbManager.DataReader["SDBG_DATE"].ToString();
                    this.SDBGReceiptsStatementOf = dbManager.DataReader["SDBG_RECEIPTS_STATEMENT_OF"].ToString();
                    this.SDBGDetId = dbManager.DataReader["SDBG_DET_ID"].ToString();
                    this.SDBGReceiptsPayMode = dbManager.DataReader["SDBG_RECEIPTS_PAY_MODE"].ToString();
                    this.SDBGReceiptsDdChequeNo = dbManager.DataReader["SDBG_RECEIPTS_DD_CHEQUE_NO"].ToString();
                    this.SDBGReceiptsDDChequeDate = Convert.ToDateTime(dbManager.DataReader["SDBG_RECEIPTS_DD_CHEQUE_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SDBGReceiptsBankDetails = dbManager.DataReader["SDBG_RECEIPTS_BANK_DETAILS"].ToString();
                    this.SDBGReceiptsDueDate = Convert.ToDateTime(dbManager.DataReader["SDBG_RECEIPTS_DUE_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SDBGReceiptsRemarks = dbManager.DataReader["SDBG_RECEIPTS_REMARKS"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }

        //Foundry Report
        public class FoundryReport
        {
            public string Id, CastingNo, StartTime, Endtime, PureIngots, LocalScrap, ImportedScarp, HomeScrap, Lm6, Mg, InputWeight, Nooflogs, Lengthoflogs, Output, WeightDross, FurOil, Remarks, Date;

            public string Silicon, Ferrous, Copper, Magnesium, Manganeese, Zinc, Aluminium, Remarks2, Status;

            public string FoundryReport_Save()
            {
                this.Id = AutoGenMaxId("[YANTRA_FOUNDRY_REPORT]", "FOUNDRY_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_FOUNDRY_REPORT] VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')",
               this.Id, this.CastingNo, this.StartTime, this.Endtime, this.PureIngots, this.LocalScrap, this.ImportedScarp, this.HomeScrap, this.Lm6, this.Mg, this.InputWeight, this.Nooflogs, this.Lengthoflogs, this.Output, this.WeightDross, this.FurOil, this.Remarks, this.Date);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string FoundryReportDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_FOUNDRY_DETAILS] SELECT ISNULL(MAX(FOUNDRY_DET_ID),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}' FROM [YANTRA_FOUNDRY_DETAILS]", this.Id, this.Silicon, this.Ferrous, this.Copper, this.Magnesium, this.Manganeese, this.Zinc, this.Aluminium, this.Remarks2, this.Status);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int FoundryReportDetails_Delete(string FoundryReportId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [YANTRA_FOUNDRY_DETAILS] WHERE FOUNDRY_ID = {0}", FoundryReportId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int FoundryReport_Select(string FoundryReportId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_FOUNDRY_REPORT] where FOUNDRY_ID ='" + FoundryReportId + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.CastingNo = dbManager.DataReader["CASTING_NO"].ToString();
                    this.StartTime = dbManager.DataReader["START_TIME"].ToString();
                    this.Date = Convert.ToDateTime(dbManager.DataReader["DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Endtime = dbManager.DataReader["END_TIME"].ToString();

                    this.PureIngots = dbManager.DataReader["PURE_INGOTS"].ToString();
                    this.LocalScrap = dbManager.DataReader["LOCAL_SCRAP"].ToString();
                    this.ImportedScarp = dbManager.DataReader["IMPORTED_SCRAP"].ToString();
                    this.HomeScrap = dbManager.DataReader["HOME_SCRAP"].ToString();

                    this.Lm6 = dbManager.DataReader["LM6"].ToString();
                    this.Mg = dbManager.DataReader["MG"].ToString();
                    this.InputWeight = dbManager.DataReader["INPUTWEIGHT"].ToString();
                    this.Nooflogs = dbManager.DataReader["NO_LOGS"].ToString();
                    this.Lengthoflogs = dbManager.DataReader["LENGTHS_OF_LOGS"].ToString();
                    this.Output = dbManager.DataReader["OUTPUT"].ToString();
                    this.WeightDross = dbManager.DataReader["WEIGHT_DROSS"].ToString();
                    this.FurOil = dbManager.DataReader["FUR_OIL"].ToString();
                    this.Remarks = dbManager.DataReader["REMARKS"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void FoundryReportDetails_Select(string FoundryReportId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_FOUNDRY_DETAILS] where FOUNDRY_ID = " + FoundryReportId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Slilcon");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Ferrous");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Copper");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Magnesium");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Manganeese");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Zinc");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Aluminium");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Status");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Slilcon"] = dbManager.DataReader["SILICON"].ToString();
                    dr["Ferrous"] = dbManager.DataReader["FERROUS"].ToString();
                    dr["Copper"] = dbManager.DataReader["COPPER"].ToString();
                    dr["Magnesium"] = dbManager.DataReader["MAGNESIUM"].ToString();
                    dr["Manganeese"] = dbManager.DataReader["MANGANEESE"].ToString();
                    dr["Zinc"] = dbManager.DataReader["ZINC"].ToString();
                    dr["Aluminium"] = dbManager.DataReader["ALUMINIUM"].ToString();
                    dr["Remarks"] = dbManager.DataReader["REMARKS"].ToString();
                    dr["Status"] = dbManager.DataReader["STATUS"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void FoundryReportDetailsReport_Select(string FoundryReportId, Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_FOUNDRY_REPORT] where FOUNDRY_ID = " + FoundryReportId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            //public void FoundryReportDetailsReport_Select(string FoundryReportId, GridView gv)
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();
            //    _commandText = string.Format("SELECT * FROM [YANTRA_FOUNDRY_REPORT] where FOUNDRY_ID = " + FoundryReportId);

            //    //SqlCommand sqlCommand = new SqlCommand("select * from table1", sqlConnection);
            //    //sqlConnection.Open();

            //    //SqlDataReader reader = sqlCommand.ExecuteReader();

            //    //GridView1.DataSource = reader;
            //    //GridView1.DataBind();
            //    //gv.DataSource = dbManager.DataReader;
            //    //gv.DataBind();
            //    //dbManager.DataReader.Close();

            //   dbManager.ExecuteReader(CommandType.Text, _commandText);
            //   gv.DataSource = dbManager.DataReader;
            //    gv.DataBind();
            //}

            public string FoundryReport_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_FOUNDRY_REPORT] SET CASTING_NO = {0},START_TIME='{1}',END_TIME='{2}',PURE_INGOTS={3},LOCAL_SCRAP='{4}',IMPORTED_SCRAP='{5}',HOME_SCRAP='{6}',LM6='{7}',MG='{8}',INPUTWEIGHT='{9}',NO_LOGS='{10}',LENGTHS_OF_LOGS='{11}',OUTPUT='{12}',WEIGHT_DROSS='{13}',FUR_OIL='{14}',REMARKS='{15}',DATE='{16}' WHERE FOUNDRY_ID ='{17}'", this.CastingNo, this.StartTime, this.Endtime, this.PureIngots, this.LocalScrap, this.ImportedScarp, this.HomeScrap, this.Lm6, this.Mg, this.InputWeight, this.Nooflogs, this.Lengthoflogs, this.Output, this.WeightDross, this.FurOil, this.Remarks, this.Date, this.Id);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }
        }

        /////Production Report

        public class ProductionReport
        {
            public string Id, sctionName, Shift, Date, DieNo, Alloy, CastingNo, LoadingTime, UnloadTime, TotalRtime, Billetssize, NoofBillets, Input, Cutlength, Weight, NoofGoodPcs, Output, Recovery, PPH, Remarks, Itemtypeid;

            //public string ProductionReport_Save()
            //{
            //    this.Id = AutoGenMaxId("[YANTRA_PREPORT]", "Production_Id");

            //        dbManager.Open();
            //    _commandText = string.Format("INSERT INTO [YANTRA_PREPORT] VALUES({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}',{20})",
            //   this.Id, this.sctionName, this.Shift, this.Date, this.DieNo, this.Alloy, this.CastingNo, this.LoadingTime, this.UnloadTime, this.TotalRtime, this.Billetssize, this.NoofBillets, this.Input, this.Cutlength, this.Weight, this.NoofGoodPcs, this.Output, this.Recovery,this.PPH,this.Remarks,this.Itemtypeid);
            //    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            //    _returnStringMessage = string.Empty;
            //    if (_returnIntValue < 0 || _returnIntValue == 0)
            //    {
            //        _returnStringMessage = "Some Data Missing.";
            //    }
            //    else if (_returnIntValue > 0)
            //    {
            //        _returnStringMessage = "Data Saved Successfully";
            //    }
            //    return _returnStringMessage;
            //}

            public string ProductionReport_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("INSERT INTO [YANTRA_PREPORT] SELECT ISNULL(MAX(DESPM_ID),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}',{19} FROM [YANTRA_PREPORT]", this.sctionName, this.Shift, this.Date, this.DieNo, this.Alloy, this.CastingNo, this.LoadingTime, this.UnloadTime, this.TotalRtime, this.Billetssize, this.NoofBillets, this.Input, this.Cutlength, this.Weight, this.NoofGoodPcs, this.Output, this.Recovery, this.PPH, this.Remarks, this.Itemtypeid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }

                return _returnStringMessage;
            }

            public string ProductionReport_Update(string ProductionReportId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE YANTRA_PRODUCTION_REPORT1 SET SECTION_NAME={0},SHIFT='{1}',DATE='{2}',DIE_NO='{3}',ALLOY='{4}',CASTING_NO='{5}',LOADING_TIME='{6}',UNLOAD_TIME='{7}',TOTAL_RTIME='{8}',BILLETS_SIZE='{9}',NO_OF_BILLETS='{10}',INPUT='{11}',CUTLENGTH = '{12}',WEIGHT = '{13}',NO_OF_GOODS_PCS = '{14}',OUTPUT = '{15}',RECOVERY = '{16}',PPH = '{17}',REMARKS = '{18}',ITEMTYPE_ID = {19} where PRODUCTION_REPORT_ID = {20}", sctionName, Shift, Date, DieNo, Alloy, CastingNo, LoadingTime, UnloadTime, TotalRtime, Billetssize, NoofBillets, Input, Cutlength, Weight, NoofGoodPcs, Output, Recovery, PPH, Remarks, Itemtypeid, Id);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string ProductionReport_Delete(string ProductionReportId)
            {
                if (DeleteRecord("[YANTRA_PRODUCTION_REPORT1]", "PRODUCTION_REPORT_ID", ProductionReportId) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public int ProductionReport_Select(string ProductionReportId)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_PRODUCTION_REPORT1] where PRODUCTION_REPORT_ID =" + ProductionReportId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["PRODUCTION_REPORT_ID"].ToString();
                    this.sctionName = dbManager.DataReader["SECTION_NAME"].ToString();
                    this.Shift = dbManager.DataReader["SHIFT"].ToString();
                    this.Date = Convert.ToDateTime(dbManager.DataReader["DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.DieNo = dbManager.DataReader["DIE_NO"].ToString();
                    this.Alloy = dbManager.DataReader["ALLOY"].ToString();
                    this.CastingNo = dbManager.DataReader["CASTING_NO"].ToString();
                    this.LoadingTime = dbManager.DataReader["LOADING_TIME"].ToString();
                    this.UnloadTime = dbManager.DataReader["UNLOAD_TIME"].ToString();
                    this.TotalRtime = dbManager.DataReader["TOTAL_RTIME"].ToString();
                    this.Billetssize = dbManager.DataReader["BILLETS_SIZE"].ToString();
                    this.NoofBillets = dbManager.DataReader["NO_OF_BILLETS"].ToString();
                    this.Input = dbManager.DataReader["INPUT"].ToString();
                    this.Cutlength = dbManager.DataReader["CUTLENGTH"].ToString();
                    this.Weight = dbManager.DataReader["WEIGHT"].ToString();
                    this.NoofGoodPcs = dbManager.DataReader["NO_OF_GOODS_PCS"].ToString();
                    this.Output = dbManager.DataReader["OUTPUT"].ToString();
                    this.Recovery = dbManager.DataReader["RECOVERY"].ToString();
                    this.PPH = dbManager.DataReader["PPH"].ToString();
                    this.Remarks = dbManager.DataReader["REMARKS"].ToString();
                    this.Itemtypeid = dbManager.DataReader["ITEMTYPE_ID"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }

        ////Inventory Stock

        public class Stock
        {
            public string Id, ItemcatgoryId, ItemSubcategoryId, SectionId, Cutlength, WeightPerPc, NoofPcs, Weight, Remarks, Date;

            public string Stock_Save()
            {
                this.Id = AutoGenMaxId("[YANTRA_STOCK]", "STOCK_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_STOCK] VALUES({0},{1},{2},{3},'{4}','{5}','{6}','{7}','{8}','{9}')",
               this.Id, this.ItemcatgoryId, this.ItemSubcategoryId, this.SectionId, this.Cutlength, this.WeightPerPc, this.NoofPcs, this.Weight, this.Remarks, this.Date);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string Stock_Update(string StockId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE YANTRA_STOCK SET ITEM_CATEGORY_ID={0},ITEM_SUBCATEGORY_ID={1},SECTION_ID={2},CUTLENGTH='{3}',WEIGHTPERPC='{4}',NOOFPCS='{5}',WEIGHT='{6}',REMARKS='{7}',Date = '{8}' where STOCK_ID = {9}", ItemcatgoryId, ItemSubcategoryId, SectionId, Cutlength, WeightPerPc, NoofPcs, Weight, Remarks, Date, Id);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string Stock_Delete(string StockId)
            {
                if (DeleteRecord("[YANTRA_STOCK]", "STOCK_ID", StockId) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public int Stock_Select(string StockId)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_STOCK] where STOCK_ID =" + StockId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["STOCK_ID"].ToString();
                    this.ItemcatgoryId = dbManager.DataReader["ITEM_CATEGORY_ID"].ToString();
                    this.ItemSubcategoryId = dbManager.DataReader["ITEM_SUBCATEGORY_ID"].ToString();
                    this.SectionId = dbManager.DataReader["SECTION_ID"].ToString();
                    this.Cutlength = dbManager.DataReader["CUTLENGTH"].ToString();
                    this.WeightPerPc = dbManager.DataReader["WEIGHTPERPC"].ToString();
                    this.NoofPcs = dbManager.DataReader["NOOFPCS"].ToString();
                    this.Weight = dbManager.DataReader["WEIGHT"].ToString();
                    this.Remarks = dbManager.DataReader["REMARKS"].ToString();
                    this.Date = Convert.ToDateTime(dbManager.DataReader["Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public static void Stock_Select(Control ControlForBind, string id)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT  * FROM [YANTRA_STOCK],YANTRA_ITEM_MASTER where YANTRA_STOCK.SECTION_ID = YANTRA_ITEM_MASTER.Item_Master_Id and SECTION_ID = '" + id + "'  ORDER BY STOCK_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }
        }

        ////////////nEW cLASS FOR vISHNU eRP

        //Performa Invocie

        public class PerformaInvocie
        {
            public string PIId, PIno, date, preparedby, custid, custunitid, status, bankid, orderno, orderdate, Dcno, Lrno, Lrdate, Insurance, Transport, Cst, Vat, PIType, WoodenPacking;

            public string PIDetid, Itemcode, description, qty, Mrp, discount, addDisc, Amount, UOMId, Colorid, Specifications;

            public static string PerformaInvoice_AutoGenCode()
            {
                return AutoGenMaxNo("CUST_PERFORMA", "Proforma_No");
            }

            public string PerformaInvoice_Save()
            {
                this.PIId = AutoGenMaxId("[CUST_PERFORMA]", "Proforma_Id");

                dbManager.Open();
                _commandText = string.Format("INSERT INTO [CUST_PERFORMA] VALUES({0},'{1}','{2}',{3},{4},{5},'{6}',{7},{8},'{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')",
               this.PIId, this.PIno, this.date, this.preparedby, this.custid, this.custunitid, this.status, this.bankid, this.orderno, this.orderdate, this.Dcno, this.Lrno, this.Lrdate, this.Insurance, this.Transport, this.Cst, this.Vat, this.PIType, this.WoodenPacking);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string DealerPrice;

            public string PerformaInvoiceDetails_Save()
            {
                dbManager.Open();
                _commandText = string.Format("INSERT INTO [PERFORMA_DETAILS] SELECT ISNULL(MAX(Pro_Det_Id),0)+1,{0},{1},'{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}' FROM [PERFORMA_DETAILS]", this.PIId, this.Itemcode, this.description, this.qty, this.Mrp, this.discount, this.addDisc, this.Amount, this.UOMId, this.Colorid, this.DealerPrice);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int PerformaInvoiceDetails_Delete(string PIID)
            {
                dbManager.Open();
                _commandText = string.Format("DELETE FROM [PERFORMA_DETAILS] WHERE Pro_Id = {0}", PIID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int PerformaInvoice_Select(string PIId)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [CUST_PERFORMA] where CUST_PERFORMA.Proforma_Id ='" + PIId + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.PIId = dbManager.DataReader["Proforma_Id"].ToString();
                    this.PIno = dbManager.DataReader["Proforma_No"].ToString();
                    this.date = Convert.ToDateTime(dbManager.DataReader["Proforma_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.preparedby = dbManager.DataReader["Proforma_Preparedby"].ToString();
                    this.custid = dbManager.DataReader["Cust_Id"].ToString();
                    this.custunitid = dbManager.DataReader["Cust_Unit_Id"].ToString();
                    this.status = dbManager.DataReader["Status"].ToString();
                    this.bankid = dbManager.DataReader["Bank_Id"].ToString();
                    this.orderno = dbManager.DataReader["Order_No"].ToString();
                    this.orderdate = dbManager.DataReader["Order_Date"].ToString();
                    this.Dcno = dbManager.DataReader["DC_No"].ToString();
                    this.Lrno = dbManager.DataReader["LR_No"].ToString();
                    this.Lrdate = Convert.ToDateTime(dbManager.DataReader["LR_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); ;
                    this.Insurance = dbManager.DataReader["Insurance"].ToString();
                    this.Transport = dbManager.DataReader["Transport"].ToString();
                    this.Cst = dbManager.DataReader["CST"].ToString();
                    this.Vat = dbManager.DataReader["VAT"].ToString();
                    this.PIType = dbManager.DataReader["PIType"].ToString();
                    this.WoodenPacking = dbManager.DataReader["WOODEN_PACKING"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string PerformaInvoice_Update()
            {
                dbManager.Open();
                _commandText = string.Format("UPDATE [CUST_PERFORMA] SET Proforma_No = '{0}',Proforma_Date='{1}',Proforma_Preparedby={2},Cust_Id={3},Cust_Unit_Id={4},Status='{5}',Bank_Id={6},Order_No={7},Order_Date='{8}',DC_No='{9}',LR_No='{10}',LR_Date='{11}',Insurance='{12}',Transport='{13}',CST='{14}',VAT='{15}',PIType = '{16}',WOODEN_PACKING='{17}' WHERE Proforma_Id = {18}", this.PIno, this.date, this.preparedby, this.custid, this.custunitid, this.status, this.bankid, this.orderno, this.orderdate, this.Dcno, this.Lrno, this.Lrdate, this.Insurance, this.Transport, this.Cst, this.Vat, this.PIType, this.WoodenPacking, this.PIId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string Performa_Delete(string PIID)
            {
                if (DeleteRecord("[PERFORMA_DETAILS]", "Pro_Id", PIID) == true)
                {
                    if (DeleteRecord("[CUST_PERFORMA]", "Proforma_Id", PIID) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public static void PIItems_Select(Control ControlForBind, string PIid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT YANTRA_ITEM_MAST.ITEM_MODEL_NO,YANTRA_ITEM_MAST.ITEM_CODE FROM YANTRA_ITEM_MAST, [PERFORMA_DETAILS]  where PERFORMA_DETAILS.ITEM_CODE =  YANTRA_ITEM_MAST.ITEM_CODE and PERFORMA_DETAILS.Pro_Id =" + PIid + " ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "ITEM_MODEL_NO", "ITEM_CODE");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static void PI_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [CUST_PERFORMA] ORDER BY Proforma_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Proforma_No", "Proforma_Id");
                }
            }

            public void PIDetails_Select(string PIID, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [PERFORMA_DETAILS],[YANTRA_ITEM_MAST],YANTRA_LKUP_COLOR_MAST WHERE [PERFORMA_DETAILS].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE and PERFORMA_DETAILS.COLOR_ID = YANTRA_LKUP_COLOR_MAST.COLOUR_ID AND [PERFORMA_DETAILS].Pro_Id=" + PIID);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ProductCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Serie");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("UOM");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Specifications");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("MRP");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Discount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SPDisc");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Itemcode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("DealerPrice");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ProductCode"] = dbManager.DataReader["ITEM_MODEL_NO"].ToString();
                    dr["Serie"] = dbManager.DataReader["ITEM_NAME"].ToString();
                    dr["Color"] = dbManager.DataReader["COLOUR_NAME"].ToString();
                    dr["UOM"] = dbManager.DataReader["UOM"].ToString();
                    dr["Specifications"] = dbManager.DataReader["Description"].ToString();
                    dr["Qty"] = dbManager.DataReader["Qty"].ToString();
                    dr["MRP"] = dbManager.DataReader["MRP"].ToString();
                    dr["Itemcode"] = dbManager.DataReader["ITEM_CODE"].ToString();
                    dr["ColorId"] = dbManager.DataReader["COLOR_ID"].ToString();
                    dr["DealerPrice"] = dbManager.DataReader["DEALER_PRICE"].ToString();
                    dr["Amount"] = dbManager.DataReader["Amount"].ToString();
                    dr["SPDisc"] = dbManager.DataReader["Additional_Disc"].ToString();
                    dr["Discount"] = dbManager.DataReader["Discount"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }
        }

        ///WorkOrder

        public class WorkOrder
        {
            public string WoId, WoNo, date, PIid, preparedby, PIdate, custid, custunitid, insurance, transport, cst, vat, Custpono, Custpodate, Woodenpacking;

            public string Wodetid, woid, itemcode, qty, specifications, colorid, remarks, uomid, mrp, discount, adddiscount, amount;

            public static void WorkOrder_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT WO_NO,WO_ID FROM [WORK_ORDER] ORDER BY WO_ID desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "WO_NO", "WO_ID");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static void PIWorkOrder_Select(Control ControlForBind, string SOid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT YANTRA_ITEM_MAST.ITEM_MODEL_NO,YANTRA_ITEM_MAST.ITEM_CODE FROM YANTRA_ITEM_MAST, [WORK_ORDER_DETAILS]  where WORK_ORDER_DETAILS.ITEM_CODE =  YANTRA_ITEM_MAST.ITEM_CODE and WORK_ORDER_DETAILS.WO_ID =" + SOid + " ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "ITEM_MODEL_NO", "ITEM_CODE");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static string Workorder_AutoGenCode()
            {
                return AutoGenMaxNo("WORK_ORDER", "WO_NO");
            }

            public string WorkOrder_Save()
            {
                this.woid = AutoGenMaxId("[WORK_ORDER]", "WO_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [WORK_ORDER] VALUES({0},'{1}','{2}',{3},{4},'{5}',{6},{7},'{8}','{9}','{10}','{11}','{12}','{13}','{14}')",
               this.woid, this.WoNo, this.date, this.PIid, this.preparedby, this.PIdate, this.custid, this.custunitid, this.insurance, this.transport, this.cst, this.vat, this.Custpono, this.Custpodate, this.Woodenpacking);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string WorkOrderDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [WORK_ORDER_DETAILS] SELECT ISNULL(MAX(WO_DET_ID),0)+1,{0},{1},{2},{3},'{4}','{5}','{6}' FROM [WORK_ORDER_DETAILS]", this.woid, this.itemcode, this.qty, this.colorid, this.remarks, this.uomid, this.mrp);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int WorkoderDetails_Delete(string WOID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [WORK_ORDER_DETAILS] WHERE WO_ID = {0}", WOID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public static void SoCustomer_Select(Control ControlForBind, string Custid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT WORK_ORDER.WO_NO,WORK_ORDER.WO_ID FROM WORK_ORDER  where  WORK_ORDER.CUST_ID =" + Custid + " ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "WO_NO", "WO_ID");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static void POCustomer_Select(Control ControlForBind, string Custid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT Proforma_No,Proforma_Id FROM CUST_PERFORMA  where Cust_Id =" + Custid + " ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Proforma_No", "Proforma_Id");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public int Workoder_Select(string WOID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [WORK_ORDER] where WORK_ORDER.WO_ID ='" + WOID + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.woid = dbManager.DataReader["WO_ID"].ToString();
                    this.WoNo = dbManager.DataReader["WO_NO"].ToString();
                    this.date = Convert.ToDateTime(dbManager.DataReader["WO_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.PIid = dbManager.DataReader["PI_ID"].ToString();
                    this.preparedby = dbManager.DataReader["PREPARED_BY"].ToString();
                    this.PIdate = Convert.ToDateTime(dbManager.DataReader["PI_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.custid = dbManager.DataReader["CUST_ID"].ToString();
                    this.custunitid = dbManager.DataReader["CUST_UNIT_ID"].ToString();
                    this.insurance = dbManager.DataReader["INSURANCE"].ToString();
                    this.transport = dbManager.DataReader["TRANSPORT"].ToString();
                    this.cst = dbManager.DataReader["CST"].ToString();
                    this.vat = dbManager.DataReader["VAT"].ToString();
                    this.Custpodate = Convert.ToDateTime(dbManager.DataReader["CUST_PO_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Custpono = dbManager.DataReader["CUST_PO_NO"].ToString();
                    this.Woodenpacking = dbManager.DataReader["WOODEN_PACKING"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string WorkOrder_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [WORK_ORDER] SET WO_NO = '{0}',WO_DATE='{1}',PI_ID={2},PREPARED_BY={3},PI_DATE='{4}' WHERE WO_ID = {5}", this.WoNo, this.date, this.PIid, this.preparedby, this.PIdate, this.woid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string WORKORder_Delete(string WOID)
            {
                if (DeleteRecord("[WORK_ORDER_DETAILS]", "WO_ID", WOID) == true)
                {
                    if (DeleteRecord("[WORK_ORDER]", "WO_ID", WOID) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public void WODetails_Select(string WOID, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [WORK_ORDER_DETAILS],[YANTRA_ITEM_MAST],YANTRA_LKUP_COLOR_MAST WHERE [WORK_ORDER_DETAILS].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE and WORK_ORDER_DETAILS.COLOR_ID = YANTRA_LKUP_COLOR_MAST.COLOUR_ID AND [WORK_ORDER_DETAILS].WO_ID=" + WOID);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ProductCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Serie");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("UOM");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Specifications");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Itemcode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ProductCode"] = dbManager.DataReader["ITEM_MODEL_NO"].ToString();
                    dr["Serie"] = dbManager.DataReader["ITEM_NAME"].ToString();
                    dr["Color"] = dbManager.DataReader["COLOUR_NAME"].ToString();
                    dr["UOM"] = dbManager.DataReader["UOM_ID"].ToString();
                    dr["Specifications"] = dbManager.DataReader["REMARKS"].ToString();
                    dr["Qty"] = dbManager.DataReader["QTY"].ToString();
                    dr["Rate"] = dbManager.DataReader["MRP"].ToString();
                    dr["Itemcode"] = dbManager.DataReader["ITEM_CODE"].ToString();
                    dr["ColorId"] = dbManager.DataReader["COLOR_ID"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }
        }

        //Sup Enq on Products

        public class SupEnquiry
        {
            public string enqid, enqno, date, supid, preparedby, status;

            public string enqdetid, itemcode, qty, RATE, reqfor, specifications, AMOUNT, colorid, uomid;

            public static void SuplierEnq_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT SUP_ENQ_NO,SUP_ENQ_ID FROM [YANTRA_SUP_ENQ_MAST] ORDER BY SUP_ENQ_ID desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "SUP_ENQ_NO", "SUP_ENQ_ID");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static void PoSupplierenq_Select(Control ControlForBind, string Enqid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT YANTRA_ITEM_MAST.ITEM_MODEL_NO,YANTRA_ITEM_MAST.ITEM_CODE FROM YANTRA_ITEM_MAST, [YANTRA_SUP_ENQ_DET]  where YANTRA_SUP_ENQ_DET.ITEM_CODE =  YANTRA_ITEM_MAST.ITEM_CODE and YANTRA_SUP_ENQ_DET.SUP_ENQ_ID =" + Enqid + " ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "ITEM_MODEL_NO", "ITEM_CODE");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static string SupEnq_AutoGenCode()
            {
                return AutoGenMaxNo("YANTRA_SUP_ENQ_MAST", "SUP_ENQ_NO");
            }

            public string SupEnq_Save()
            {
                this.enqid = AutoGenMaxId("[YANTRA_SUP_ENQ_MAST]", "SUP_ENQ_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_SUP_ENQ_MAST] VALUES({0},'{1}','{2}',{3},'{4}',{5})",
               this.enqid, this.enqno, this.date, this.supid, this.status, this.preparedby);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string Discount;

            public string SupEnqDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_SUP_ENQ_DET] SELECT ISNULL(MAX(SUP_ENQ_DET_ID),0)+1,{0},{1},'{2}','{3}','{4}','{5}','{6}',{7},'{8}','{9}' FROM [YANTRA_SUP_ENQ_DET]", this.enqid, this.itemcode, this.qty, this.RATE, this.reqfor, this.specifications, this.AMOUNT, this.colorid, this.uomid, this.Discount);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int SupDetails_Delete(string ENQID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [YANTRA_SUP_ENQ_DET] WHERE SUP_ENQ_ID = {0}", ENQID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int SupEnq_Select(string ENQID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_SUP_ENQ_MAST] where YANTRA_SUP_ENQ_MAST.SUP_ENQ_ID ='" + ENQID + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.enqid = dbManager.DataReader["SUP_ENQ_ID"].ToString();
                    this.enqno = dbManager.DataReader["SUP_ENQ_NO"].ToString();
                    this.date = Convert.ToDateTime(dbManager.DataReader["SUP_ENQ_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.supid = dbManager.DataReader["SUP_ID"].ToString();
                    this.preparedby = dbManager.DataReader["SUP_ENQ_PREPARED_BY"].ToString();
                    this.status = dbManager.DataReader["SUP_ENQ_STATUS"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string SupENQ_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [YANTRA_SUP_ENQ_MAST] SET SUP_ENQ_NO = '{0}',SUP_ENQ_DATE='{1}',SUP_ID={2},SUP_ENQ_STATUS='{3}',SUP_ENQ_PREPARED_BY={4} WHERE SUP_ENQ_ID = {5}", this.enqno, this.date, this.supid, this.status, this.preparedby, this.enqid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string SupEnq_Delete(string ENQID)
            {
                if (DeleteRecord("[YANTRA_SUP_ENQ_DET]", "SUP_ENQ_ID", ENQID) == true)
                {
                    if (DeleteRecord("[YANTRA_SUP_ENQ_MAST]", "SUP_ENQ_ID", ENQID) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public void SupEnqDetails_Select(string SupEnqId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_SUP_ENQ_DET],[YANTRA_ITEM_MAST],[YANTRA_LKUP_UOM],YANTRA_LKUP_COLOR_MAST WHERE [YANTRA_SUP_ENQ_DET].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE AND [YANTRA_LKUP_UOM].UOM_ID=[YANTRA_ITEM_MAST].UOM_ID and YANTRA_SUP_ENQ_DET.COLOR_ID = YANTRA_LKUP_COLOR_MAST.COLOUR_ID AND [YANTRA_SUP_ENQ_DET].SUP_ENQ_ID=" + SupEnqId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ProductCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Serie");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("UOM");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Specifications");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ImportPrice");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Discount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Itemcode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Requiredfor");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ProductCode"] = dbManager.DataReader["ITEM_MODEL_NO"].ToString();
                    dr["Serie"] = dbManager.DataReader["ITEM_NAME"].ToString();
                    dr["Color"] = dbManager.DataReader["COLOUR_NAME"].ToString();
                    dr["UOM"] = dbManager.DataReader["UOM_ID"].ToString();
                    dr["Specifications"] = dbManager.DataReader["SUP_ENQ_SPECS"].ToString();
                    dr["Qty"] = dbManager.DataReader["SUP_ENQ_QTY"].ToString();
                    dr["ImportPrice"] = dbManager.DataReader["SUP_ENQ_RATE"].ToString();
                    dr["Discount"] = dbManager.DataReader["DISCOUNT"].ToString();

                    dr["Amount"] = dbManager.DataReader["SUP_ENQ_AMOUNT"].ToString();
                    dr["Itemcode"] = dbManager.DataReader["ITEM_CODE"].ToString();
                    dr["ColorId"] = dbManager.DataReader["COLOR_ID"].ToString();
                    dr["Requiredfor"] = dbManager.DataReader["SUP_ENQ_REQ_FOR"].ToString();
                    SalesOrderItems.Rows.Add(dr);
                }
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }
        }

        //PurchaseoRder on Products

        public class PO
        {
            public string poid, pono, date, supid, discount, vat, preparedby, cst, ENQID, ENQDATE, NETAMOUNT;

            public string podetid, itemcode, qty, specifications, colorid, uomid, AMOUNT, RATE;

            public static void PO_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT PO_NO,PO_ID FROM [PURCHASE_ORDER] ORDER BY PO_ID desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "PO_NO", "PO_ID");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static void PoItems_Select(Control ControlForBind, string POid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT YANTRA_ITEM_MAST.ITEM_MODEL_NO,YANTRA_ITEM_MAST.ITEM_CODE FROM YANTRA_ITEM_MAST, [PURCHASE_ORDER_DETAILS]  where PURCHASE_ORDER_DETAILS.ITEM_CODE =  YANTRA_ITEM_MAST.ITEM_CODE and PURCHASE_ORDER_DETAILS.PO_ID =" + POid + " ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "ITEM_MODEL_NO", "ITEM_CODE");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static string PO_AutoGenCode()
            {
                return AutoGenMaxNo("PURCHASE_ORDER", "PO_NO");
            }

            public string PO_Save()
            {
                this.poid = AutoGenMaxId("[PURCHASE_ORDER]", "PO_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [PURCHASE_ORDER] VALUES({0},'{1}','{2}',{3},'{4}','{5}',{6},'{7}',{8},'{9}','{10}')",
               this.poid, this.date, this.pono, this.supid, this.discount, this.vat, this.preparedby, this.cst, this.ENQID, this.ENQDATE, this.NETAMOUNT);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string ItemDiscount;

            public string PODetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [PURCHASE_ORDER_DETAILS] SELECT ISNULL(MAX(PO_DET_ID),0)+1,{0},{1},{2},'{3}',{4},'{5}','{6}','{7}','{8}' FROM [PURCHASE_ORDER_DETAILS]", this.poid, this.itemcode, this.qty, this.specifications, this.colorid, this.uomid, this.AMOUNT, this.RATE, this.ItemDiscount);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int PODetails_Delete(string POID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [PURCHASE_ORDER_DETAILS] WHERE PO_ID = {0}", POID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int PO_Select(string POID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [PURCHASE_ORDER] where PURCHASE_ORDER.PO_ID ='" + POID + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.poid = dbManager.DataReader["PO_ID"].ToString();
                    this.pono = dbManager.DataReader["PO_NO"].ToString();
                    this.date = Convert.ToDateTime(dbManager.DataReader["PO_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.supid = dbManager.DataReader["SUP_ID"].ToString();
                    this.preparedby = dbManager.DataReader["PREPARED_BY"].ToString();
                    this.discount = dbManager.DataReader["DISCOUNT"].ToString();
                    this.vat = dbManager.DataReader["VAT"].ToString();
                    this.cst = dbManager.DataReader["CST"].ToString();
                    this.ENQID = dbManager.DataReader["SUP_ENQ_ID"].ToString();
                    this.ENQDATE = Convert.ToDateTime(dbManager.DataReader["SUP_ENQ_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.NETAMOUNT = dbManager.DataReader["AMOUNT"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string PO_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [PURCHASE_ORDER] SET PO_NO = '{0}',PO_DATE='{1}',SUP_ID={2},DISCOUNT='{3}',VAT='{4}',PREPARED_BY={5},CST='{6}',SUP_ENQ_ID={7},SUP_ENQ_DATE='{8}',AMOUNT='{9}' WHERE PO_ID = {10}", this.pono, this.date, this.supid, this.discount, this.vat, this.preparedby, this.cst, this.ENQID, this.ENQDATE, this.NETAMOUNT, this.poid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string PO_Delete(string POID)
            {
                if (DeleteRecord("[PURCHASE_ORDER_DETAILS]", "PO_ID", POID) == true)
                {
                    if (DeleteRecord("[PURCHASE_ORDER]", "PO_ID", POID) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public void PODetails_Select(string POID, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [PURCHASE_ORDER_DETAILS],[YANTRA_ITEM_MAST],YANTRA_LKUP_COLOR_MAST WHERE [PURCHASE_ORDER_DETAILS].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE AND PURCHASE_ORDER_DETAILS.COLOR_ID = YANTRA_LKUP_COLOR_MAST.COLOUR_ID AND [PURCHASE_ORDER_DETAILS].PO_ID=" + POID);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ProductCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Serie");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("UOM");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Specifications");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ImportPrice");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Itemcode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Discount");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ProductCode"] = dbManager.DataReader["ITEM_MODEL_NO"].ToString();
                    dr["Serie"] = dbManager.DataReader["ITEM_NAME"].ToString();
                    dr["Color"] = dbManager.DataReader["COLOUR_NAME"].ToString();
                    dr["UOM"] = dbManager.DataReader["UOM_ID"].ToString();
                    dr["Specifications"] = dbManager.DataReader["SPECIFICATIONS"].ToString();
                    dr["Qty"] = dbManager.DataReader["QTY"].ToString();
                    dr["ImportPrice"] = dbManager.DataReader["RATE"].ToString();
                    dr["Amount"] = dbManager.DataReader["AMOUNT"].ToString();
                    dr["Itemcode"] = dbManager.DataReader["ITEM_CODE"].ToString();
                    dr["ColorId"] = dbManager.DataReader["COLOR_ID"].ToString();
                    dr["Discount"] = dbManager.DataReader["DISCOUNT"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }
        }

        /// dELIVERY cHALLAN
        ///

        //public class DeliveryChallan
        //{
        //    public string dcid, dcno, date, piid, pidate, custid, preparedby, paymentmode, dispatchthrough, destination, deliveryterms;

        //    public string dcdetid, itemcode, qty, colorid, uomid, remarks, rate, amount, godownid;

        //    public static string DC_AutoGenCode()
        //    {
        //        return AutoGenMaxNo("DELIVERY_CHALLAN", "DC_NO");
        //    }

        //    public static void DC_Select(Control ControlForBind)
        //    {
        //        dbManager.Open();
        //        _commandText = string.Format("SELECT DC_NO,DC_ID FROM [DELIVERY_CHALLAN] ORDER BY DC_ID desc");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "DC_NO", "DC_ID");
        //        }
        //        else if (ControlForBind is GridView)
        //        {
        //            GridViewBind(ControlForBind as GridView);
        //        }
        //    }

        //    public string DC_Save()
        //    {
        //        this.dcid = AutoGenMaxId("[DELIVERY_CHALLAN]", "DC_ID");
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [DELIVERY_CHALLAN] VALUES({0},'{1}','{2}',{3},'{4}',{5},{6},'{7}','{8}','{9}','{10}')",
        //       this.dcid, this.dcno, this.date, this.piid, this.pidate, this.custid, this.preparedby, this.paymentmode, this.dispatchthrough, this.destination, this.deliveryterms);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string DCDetails_Save()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [DELIVERY_CHALLAN_DET] SELECT ISNULL(MAX(DC_DET_ID),0)+1,{0},{1},{2},{3},'{4}','{5}','{6}','{7}',{8} FROM [DELIVERY_CHALLAN_DET]", this.dcid, this.itemcode, this.qty, this.colorid, this.remarks, this.uomid, this.rate, this.amount, this.godownid);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string DeliveryDetailsIssueStock_Update(string ItemCode, string DCQty, string colorid, string godownid)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [STOCK] SET  QTY=CONVERT(BIGINT,QTY)-{0} WHERE ITEM_CODE={1} and COLOR_ID={2} and GODOWN_ID= {3}", DCQty, ItemCode, colorid, godownid);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Updated Successfully";

        //        }
        //        return _returnStringMessage;
        //    }

        //    public int DCDetails_Delete(string DCID)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("DELETE FROM [DELIVERY_CHALLAN_DET] WHERE DC_ID = {0}", DCID);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        return _returnIntValue;
        //    }

        //    public int DC_Select(string DCID)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [DELIVERY_CHALLAN] where DELIVERY_CHALLAN.DC_ID ='" + DCID + "'  ");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.dcid = dbManager.DataReader["DC_ID"].ToString();
        //            this.dcno = dbManager.DataReader["DC_NO"].ToString();
        //            this.date = Convert.ToDateTime(dbManager.DataReader["DC_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        //            this.piid = dbManager.DataReader["PI_ID"].ToString();
        //            this.pidate = Convert.ToDateTime(dbManager.DataReader["PI_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        //            this.custid = dbManager.DataReader["CUST_ID"].ToString();
        //            this.dispatchthrough = dbManager.DataReader["DISPATCHED_THROUGH"].ToString();
        //            this.preparedby = dbManager.DataReader["PREPARED_BY"].ToString();
        //            this.destination = dbManager.DataReader["DESTINATION"].ToString();
        //            this.deliveryterms = dbManager.DataReader["DELIVERY_TERMS"].ToString();
        //            this.paymentmode = dbManager.DataReader["PAYMENT_MODE"].ToString();
        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        return _returnIntValue;
        //    }
        //    public string DC_Update()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [DELIVERY_CHALLAN] SET DC_NO = '{0}',DC_DATE='{1}',PI_ID={2},PI_DATE='{3}',CUST_ID={4},PREPARED_BY={5},PAYMENT_MODE='{6}',DISPATCHED_THROUGH='{7}',DESTINATION='{8}',DELIVERY_TERMS='{9}' WHERE DC_ID = {10}", this.dcno, this.date, this.piid, this.pidate, this.custid, this.preparedby, this.paymentmode, this.dispatchthrough, this.destination, this.deliveryterms, this.dcid);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }
        //    public string DC_Delete(string DCID)
        //    {
        //        if (DeleteRecord("[DELIVERY_CHALLAN]", "DC_ID", DCID) == true)
        //        {
        //            _returnStringMessage = "Data Deleted Successfully";
        //        }
        //        else
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }

        //        return _returnStringMessage;
        //    }

        //    public void DCDetails_Select(string DCID, GridView gv)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [DELIVERY_CHALLAN_DET],[YANTRA_ITEM_MAST],YANTRA_LKUP_COLOR_MAST,GODOWN_MASTER WHERE [DELIVERY_CHALLAN_DET].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE AND GODOWN_MASTER.GODOWN_ID = DELIVERY_CHALLAN_DET.Godownid and DELIVERY_CHALLAN_DET.COLOR_ID = YANTRA_LKUP_COLOR_MAST.COLOUR_ID AND [DELIVERY_CHALLAN_DET].DC_ID=" + DCID);

        //        dbManager.ExecuteReader(CommandType.Text, _commandText);

        //        DataTable SalesOrderItems = new DataTable();
        //        DataColumn col = new DataColumn();
        //        col = new DataColumn("ProductCode");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Serie");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Color");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("UOM");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Specifications");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Qty");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Rate");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Amount");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Itemcode");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("ColorId");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Godown");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("GodownId");
        //        SalesOrderItems.Columns.Add(col);

        //        while (dbManager.DataReader.Read())
        //        {
        //            DataRow dr = SalesOrderItems.NewRow();
        //            dr["ProductCode"] = dbManager.DataReader["ITEM_MODEL_NO"].ToString();
        //            dr["Serie"] = dbManager.DataReader["ITEM_NAME"].ToString();
        //            dr["Color"] = dbManager.DataReader["COLOUR_NAME"].ToString();
        //            dr["UOM"] = dbManager.DataReader["UOM_ID"].ToString();
        //            dr["Specifications"] = dbManager.DataReader["REMARKS"].ToString();
        //            dr["Qty"] = dbManager.DataReader["QTY"].ToString();
        //            dr["Rate"] = dbManager.DataReader["RATE"].ToString();
        //            dr["Amount"] = dbManager.DataReader["Amount"].ToString();
        //            dr["Itemcode"] = dbManager.DataReader["ITEM_CODE"].ToString();
        //            dr["ColorId"] = dbManager.DataReader["COLOR_ID"].ToString();
        //            dr["Godown"] = dbManager.DataReader["GODOWN_NAME"].ToString();
        //            dr["GodownId"] = dbManager.DataReader["Godownid"].ToString();

        //            SalesOrderItems.Rows.Add(dr);
        //        }
        //        gv.DataSource = SalesOrderItems;
        //        gv.DataBind();
        //    }

        //}

        /// MRN
        ///

        public class MRN
        {
            public string mrnid, mrnno, date, pono, podate, supid, receivedon, preparedby, chekcedby;

            public string mrndetid, itemcode, orderqty, receciedqty, rejectedqty, damgedqty, colorid, uomid, remarks, godownId, GOODQTY;

            public static string MRN_AutoGenCode()
            {
                return AutoGenMaxNo("MRN", "MRN_NO");
            }

            public string MRN_Save()
            {
                this.mrnid = AutoGenMaxId("[MRN]", "MRN_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [MRN] VALUES({0},'{1}','{2}','{3}','{4}',{5},'{6}',{7},{8})",
               this.mrnid, this.mrnno, this.date, this.pono, this.podate, this.supid, this.receivedon, this.preparedby, this.chekcedby);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string MRNDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [MRN_DETAILS] SELECT ISNULL(MAX(MRN_DET_ID),0)+1,{0},{1},{2},{3},{4},{5},'{6}',{7},'{8}',{9},{10} FROM [MRN_DETAILS]", this.mrnid, this.itemcode, this.orderqty, this.receciedqty, this.rejectedqty, this.damgedqty, this.remarks, this.colorid, this.uomid, this.godownId, this.GOODQTY);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string stockid;

            public string StockID_AutoGen()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(STOCK_ID),0)+1 FROM STOCK").ToString());
                return _returnIntValue.ToString();
            }

            public string MRNStock_Update(string ItemCode, string Qty, string Colorid, string GODOWNID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[STOCK]", "ITEM_CODE", ItemCode, "GODOWN_ID", GODOWNID) == true)
                {
                    _commandText = string.Format("UPDATE [STOCK] SET  QTY=CONVERT(BIGINT,QTY)+{0} WHERE ITEM_CODE = {1}  and COLOR_ID = {2} AND GODOWN_ID ={3} ", Qty, ItemCode, Colorid, GODOWNID);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }
                else
                {
                    this.stockid = StockID_AutoGen();
                    _commandText = string.Format("INSERT INTO [STOCK] VALUES ({0},{1},{2},{3},{4})", this.stockid, ItemCode, Colorid, Qty, GODOWNID);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }
                }
                return _returnStringMessage;
            }

            //public string MRNStock_Update(string ItemCode, string Qty, string Colorid, string GODOWNID)
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();
            //    if (IsRecordExists("[STOCK]", "ITEM_CODE", ItemCode, "GODOWN_ID", GODOWNID) == true)
            //    {
            //        _commandText = string.Format("UPDATE [STOCK] SET  QTY=CONVERT(BIGINT,QTY)+{0} WHERE ITEM_CODE = {1}  and COLOR_ID = {2} AND GODOWN_ID ={3} ", Qty, ItemCode, Colorid, GODOWNID);
            //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            //        _returnStringMessage = string.Empty;
            //        if (_returnIntValue < 0 || _returnIntValue == 0)
            //        {
            //            _returnStringMessage = "Some Data Missing.";
            //        }
            //        else if (_returnIntValue > 0)
            //        {
            //            _returnStringMessage = "Data Updated Successfully";
            //        }
            //    }
            //    else
            //    {
            //        this.stockid = StockID_AutoGen();
            //        _commandText = string.Format("INSERT INTO [STOCK] VALUES ({0},{1},{2},{3},{4})", this.stockid, ItemCode, Colorid, Qty, GODOWNID);
            //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

            //        _returnStringMessage = string.Empty;
            //        if (_returnIntValue < 0 || _returnIntValue == 0)
            //        {
            //            _returnStringMessage = "Some Data Missing.";
            //        }
            //        else if (_returnIntValue > 0)
            //        {
            //            _returnStringMessage = "Data Saved Successfully";
            //        }
            //    }
            //    return _returnStringMessage;
            //}

            public int MRNDetails_Delete(string MRNID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [MRN_DETAILS] WHERE MRN_ID = {0}", MRNID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int MRN_Select(string MRNID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [MRN] where MRN.MRN_ID ='" + MRNID + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.mrnid = dbManager.DataReader["MRN_ID"].ToString();
                    this.mrnno = dbManager.DataReader["MRN_NO"].ToString();
                    this.date = Convert.ToDateTime(dbManager.DataReader["MRN_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.pono = dbManager.DataReader["PO_NO"].ToString();
                    this.podate = dbManager.DataReader["PO_DATE"].ToString();
                    this.supid = dbManager.DataReader["SUPLIER_ID"].ToString();
                    this.receivedon = Convert.ToDateTime(dbManager.DataReader["RECEVIED_ON"].ToString()).ToString("dd/MM/yyyy");
                    this.preparedby = dbManager.DataReader["PREPARED_BY"].ToString();
                    this.chekcedby = dbManager.DataReader["CHECKED_BY"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string MRN_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [MRN] SET MRN_NO = '{0}',MRN_DATE='{1}',PO_NO='{2}',PO_DATE='{3}',SUPLIER_ID={4},RECEVIED_ON='{5}',PREPARED_BY={6},CHECKED_BY={7} WHERE MRN_ID = {8}", this.mrnno, this.date, this.pono, this.podate, this.supid, this.receivedon, this.preparedby, this.chekcedby, this.mrnid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string MRN_Delete(string MRNID)
            {
                if (DeleteRecord("[MRN]", "MRN_ID", MRNID) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public void MRNDetails_Select(string MRNID, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [MRN_DETAILS],[YANTRA_ITEM_MAST],YANTRA_LKUP_COLOR_MAST,GODOWN_MASTER WHERE [MRN_DETAILS].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE and MRN_DETAILS.GODOWNID = GODOWN_MASTER.GODOWN_ID  AND MRN_DETAILS.MRN_COLOR_ID = YANTRA_LKUP_COLOR_MAST.COLOUR_ID AND [MRN_DETAILS].MRN_ID=" + MRNID);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ProductCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Serie");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("UOM");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Specifications");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("OrderedQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("AcceptedQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("RejectedQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("DamagedQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Itemcode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Godown");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("GodownId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("GoodQty");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ProductCode"] = dbManager.DataReader["ITEM_MODEL_NO"].ToString();
                    dr["Serie"] = dbManager.DataReader["ITEM_NAME"].ToString();
                    dr["Color"] = dbManager.DataReader["COLOUR_NAME"].ToString();
                    dr["UOM"] = dbManager.DataReader["UOM_ID"].ToString();
                    dr["Specifications"] = dbManager.DataReader["REMARKS"].ToString();
                    dr["OrderedQty"] = dbManager.DataReader["ORDERED_QTY"].ToString();
                    dr["AcceptedQty"] = dbManager.DataReader["RECEIVED_QTY"].ToString();
                    dr["RejectedQty"] = dbManager.DataReader["REJECTED_QTY"].ToString();
                    dr["DamagedQty"] = dbManager.DataReader["DAMGED_QTY"].ToString();
                    dr["Itemcode"] = dbManager.DataReader["ITEM_CODE"].ToString();
                    dr["ColorId"] = dbManager.DataReader["MRN_COLOR_ID"].ToString();
                    dr["Godown"] = dbManager.DataReader["GODOWN_NAME"].ToString();
                    dr["GodownId"] = dbManager.DataReader["GODOWNID"].ToString();
                    dr["GoodQty"] = dbManager.DataReader["GOOD_QTY"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }
        }

        ////sALES iNVOICE

        public class Invoice
        {
            public string siid, sino, date, piid, Pidate, vat, cst, insurance, preparedby, custid, transport;

            public string sidetid, itemcode, qty, rate, colorid, uomid, amount, remarks;

            public static string Invoice_AutoGenCode()
            {
                return AutoGenMaxNo("SALES_INVOICE", "SI_NO");
            }

            public string Invoice_Save()
            {
                this.siid = AutoGenMaxId("[SALES_INVOICE]", "SI_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [SALES_INVOICE] VALUES({0},'{1}','{2}',{3},'{4}',{5},'{6}','{7}','{8}','{9}',{10})",
               this.siid, this.sino, this.date, this.piid, this.Pidate, this.custid, this.insurance, this.vat, this.cst, this.transport, this.preparedby);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string InvocieDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [SALES_INVOCE_DET] SELECT ISNULL(MAX(SI_DET_ID),0)+1,{0},{1},{2},'{3}',{4},'{5}','{6}','{7}' FROM [SALES_INVOCE_DET]", this.siid, this.itemcode, this.qty, this.rate, this.colorid, this.uomid, this.amount, this.remarks);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int InvoiceDetails_Delete(string SIID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [SALES_INVOCE_DET] WHERE SI_ID = {0}", SIID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int Invoice_Select(string SIID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SALES_INVOICE] where SALES_INVOICE.SI_ID ='" + SIID + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.siid = dbManager.DataReader["SI_ID"].ToString();
                    this.sino = dbManager.DataReader["SI_NO"].ToString();
                    this.date = Convert.ToDateTime(dbManager.DataReader["SI_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Pidate = dbManager.DataReader["PI_DATE"].ToString();
                    this.piid = dbManager.DataReader["PI_ID"].ToString();
                    this.insurance = dbManager.DataReader["INSURANCE"].ToString();
                    this.vat = dbManager.DataReader["VAT"].ToString();
                    this.preparedby = dbManager.DataReader["PREPARED_BY"].ToString();
                    this.custid = dbManager.DataReader["CUST_ID"].ToString();
                    this.insurance = dbManager.DataReader["INSURANCE"].ToString();
                    this.cst = dbManager.DataReader["CST"].ToString();
                    this.transport = dbManager.DataReader["TRANSPORT"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string Invoice_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [SALES_INVOICE] SET SI_NO = '{0}',SI_DATE='{1}',PI_ID={2},PI_DATE='{3}',CUST_ID={4},INSURANCE='{5}',VAT='{6}',CST='{7}',TRANSPORT='{8}',PREPARED_BY={9} WHERE SI_ID = {10}", this.sino, this.date, this.piid, this.Pidate, this.custid, this.insurance, this.vat, this.cst, this.transport, this.preparedby, this.siid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string invoice_Delete(string SIID)
            {
                if (DeleteRecord("[SALES_INVOICE]", "SI_ID", SIID) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public void InvocieDetails_Select(string SIID, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SALES_INVOCE_DET],[YANTRA_ITEM_MAST],YANTRA_LKUP_COLOR_MAST WHERE [SALES_INVOCE_DET].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE AND SALES_INVOCE_DET.COLOR_ID = YANTRA_LKUP_COLOR_MAST.COLOUR_ID AND [SALES_INVOCE_DET].SI_ID=" + SIID);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ModelNo");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemName");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("UOM");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Specifications");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Itemcode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ModelNo"] = dbManager.DataReader["ITEM_MODEL_NO"].ToString();
                    dr["ItemName"] = dbManager.DataReader["ITEM_NAME"].ToString();
                    dr["Color"] = dbManager.DataReader["COLOUR_NAME"].ToString();
                    dr["UOM"] = dbManager.DataReader["UOM_ID"].ToString();
                    dr["Specifications"] = dbManager.DataReader["REMARKS"].ToString();
                    dr["Qty"] = dbManager.DataReader["QTY"].ToString();
                    dr["Rate"] = dbManager.DataReader["RATE"].ToString();
                    dr["Amount"] = dbManager.DataReader["AMOUNT"].ToString();
                    dr["Itemcode"] = dbManager.DataReader["ITEM_CODE"].ToString();
                    dr["ColorId"] = dbManager.DataReader["COLOR_ID"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void inVOICE_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT SI_NO,SI_ID FROM [SALES_INVOICE] ORDER BY SI_ID desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "SI_NO", "SI_ID");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static void InvoiceItems_Select(Control ControlForBind, string SIid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT YANTRA_ITEM_MAST.ITEM_MODEL_NO,YANTRA_ITEM_MAST.ITEM_CODE FROM YANTRA_ITEM_MAST, [SALES_INVOCE_DET]  where SALES_INVOCE_DET.ITEM_CODE =  YANTRA_ITEM_MAST.ITEM_CODE and SALES_INVOCE_DET.SI_ID =" + SIid + " ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "ITEM_MODEL_NO", "ITEM_CODE");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }
        }

        ///Sales Return
        ///

        //public class SalesReturn
        //{
        //    public string srid, srno, date, siid, SIDATE, CUSTID, preparedby;

        //    public string srdetid, itemcode, qty, rate, AMOUNT, colorid, uomid, REMARKS;

        //    public static string SR_AutoGenCode()
        //    {
        //        return AutoGenMaxNo("SALES_RETURN", "SR_NO");
        //    }

        //    public string SR_Save()
        //    {
        //        this.srid = AutoGenMaxId("[SALES_RETURN]", "SR_ID");
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [SALES_RETURN] VALUES({0},'{1}','{2}',{3},'{4}',{5},{6})",
        //       this.srid, this.srno, this.date, this.siid, this.SIDATE, this.CUSTID, this.preparedby);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string SRDetails_Save()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [SALES_RETURN_DET] SELECT ISNULL(MAX(SR_DET_ID),0)+1,{0},{1},{2},'{3}','{4}',{5},'{6}','{7}' FROM [SALES_RETURN_DET]", this.srid, this.itemcode, this.qty, this.rate, this.AMOUNT, this.colorid, this.uomid, this.REMARKS);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public int SRDetails_Delete(string SRID)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("DELETE FROM [SALES_RETURN_DET] WHERE SR_ID = {0}", SRID);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        return _returnIntValue;
        //    }

        //    public int SR_Select(string SRID)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [SALES_RETURN] where SALES_RETURN.SR_ID ='" + SRID + "'  ");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.srid = dbManager.DataReader["SR_ID"].ToString();
        //            this.srno = dbManager.DataReader["SR_NO"].ToString();
        //            this.date = Convert.ToDateTime(dbManager.DataReader["SR_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.siid = dbManager.DataReader["SI_ID"].ToString();
        //            this.SIDATE = Convert.ToDateTime(dbManager.DataReader["SI_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.CUSTID = dbManager.DataReader["CUST_ID"].ToString();
        //            this.preparedby = dbManager.DataReader["PREPARED_BY"].ToString();

        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        return _returnIntValue;
        //    }

        //    public string SR_Update()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [SALES_RETURN] SET SR_NO = '{0}',SR_DATE='{1}',SI_ID={2},SI_DATE='{3}',CUST_ID={4},PREPARED_BY={5} WHERE SR_ID = {6}", this.srno, this.date, this.siid, this.SIDATE, this.CUSTID, this.preparedby, this.srid);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Updated Successfully";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public string SR_Delete(string SRID)
        //    {
        //        if (DeleteRecord("[SALES_RETURN]", "SR_ID", SRID) == true)
        //        {
        //            _returnStringMessage = "Data Deleted Successfully";
        //        }
        //        else
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }

        //        return _returnStringMessage;
        //    }

        //    public void SRDetails_Select(string SRID, GridView gv)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [SALES_RETURN_DET],[YANTRA_ITEM_MAST],YANTRA_LKUP_COLOR_MAST WHERE [SALES_RETURN_DET].ITEM_CODE=[YANTRA_ITEM_MAST].ITEM_CODE AND SALES_RETURN_DET.COLOR_ID = YANTRA_LKUP_COLOR_MAST.COLOUR_ID AND [SALES_RETURN_DET].SR_ID=" + SRID);

        //        dbManager.ExecuteReader(CommandType.Text, _commandText);

        //        DataTable SalesOrderItems = new DataTable();
        //        DataColumn col = new DataColumn();
        //        col = new DataColumn("ModelNo");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("ItemName");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Color");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("UOM");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Specifications");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Qty");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Rate");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Amount");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("Itemcode");
        //        SalesOrderItems.Columns.Add(col);
        //        col = new DataColumn("ColorId");
        //        SalesOrderItems.Columns.Add(col);

        //        while (dbManager.DataReader.Read())
        //        {
        //            DataRow dr = SalesOrderItems.NewRow();
        //            dr["ModelNo"] = dbManager.DataReader["ITEM_MODEL_NO"].ToString();
        //            dr["ItemName"] = dbManager.DataReader["ITEM_NAME"].ToString();
        //            dr["Color"] = dbManager.DataReader["COLOUR_NAME"].ToString();
        //            dr["UOM"] = dbManager.DataReader["UOM_ID"].ToString();
        //            dr["Specifications"] = dbManager.DataReader["REMARKS"].ToString();
        //            dr["Qty"] = dbManager.DataReader["QTY"].ToString();
        //            dr["Rate"] = dbManager.DataReader["RATE"].ToString();
        //            dr["Amount"] = dbManager.DataReader["AMOUNT"].ToString();
        //            dr["Itemcode"] = dbManager.DataReader["ITEM_CODE"].ToString();
        //            dr["ColorId"] = dbManager.DataReader["COLOR_ID"].ToString();

        //            SalesOrderItems.Rows.Add(dr);
        //        }
        //        gv.DataSource = SalesOrderItems;
        //        gv.DataBind();
        //    }

        //    public static void SR_Select(Control ControlForBind)
        //    {
        //        dbManager.Open();
        //        _commandText = string.Format("SELECT SR_NO,SR_ID FROM [SALES_RETURN] ORDER BY SR_ID desc");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "SR_NO", "SR_ID");
        //        }
        //        else if (ControlForBind is GridView)
        //        {
        //            GridViewBind(ControlForBind as GridView);
        //        }
        //    }

        //}

        ////////////DC - Purchase

        public class DCPurchase
        {
            public string PurId, DCNo, DCDate, LRNo, Transporter, Freight, Waybillno, SupplierID, PreparedBy;

            public string purdetid, productid, batchno, mfgdate, expirydate, packing, Quantity, noofcases;

            public string stockid, qty;

            public static string DCPurchase_AutoGenCode()
            {
                return AutoGenMaxNo("DC_Purchase", "DC_No");
            }

            public string DCPurchase_Save()
            {
                this.PurId = AutoGenMaxId("[DC_Purchase]", "DC_Pur_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [DC_Purchase] VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}',{7},{8})",
               this.PurId, this.DCNo, this.DCDate, this.LRNo, this.Transporter, this.Freight, this.Waybillno, this.SupplierID, this.PreparedBy);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string DCPurchaseDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [DC_Purchase_Details] SELECT ISNULL(MAX(DC_Pur_Det_Id),0)+1,{0},{1},'{2}','{3}','{4}','{5}',{6},'{7}' FROM [DC_Purchase_Details]", this.PurId, this.productid, this.batchno, this.mfgdate, this.expirydate, this.packing, this.Quantity, this.noofcases);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string StockID_AutoGen()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(STOCK_ID),0)+1 FROM STOCK").ToString());
                return _returnIntValue.ToString();
            }

            public string MRNStock_Update(string productid, string Qty, string batchno, string mfg, string exp)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[STOCK]", "Product_Id", productid, "Batch_No", batchno) == true)
                {
                    _commandText = string.Format("UPDATE [STOCK] SET  QTY=CONVERT(BIGINT,QTY)+{0} WHERE Product_Id = {1}  and Batch_No = '{2}' ", Qty, productid, batchno);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }
                else
                {
                    this.stockid = StockID_AutoGen();
                    _commandText = string.Format("INSERT INTO [STOCK] VALUES ({0},{1},'{2}','{3}','{4}','{5}')", this.stockid, productid, batchno, Qty, mfg, exp);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }
                }
                return _returnStringMessage;
            }

            public int DC_Purchase_Details_Delete(string MRNID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [DC_Purchase_Details] WHERE Dc_Id = {0}", MRNID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int DC_Purchase_Select(string MRNID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [DC_Purchase] where DC_Pur_Id ='" + MRNID + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.PurId = dbManager.DataReader["DC_Pur_Id"].ToString();
                    this.DCNo = dbManager.DataReader["DC_No"].ToString();
                    this.DCDate = Convert.ToDateTime(dbManager.DataReader["DC_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.LRNo = dbManager.DataReader["LR_No"].ToString();
                    this.Transporter = dbManager.DataReader["Transporter"].ToString();
                    this.Freight = dbManager.DataReader["Freight"].ToString();
                    this.Waybillno = dbManager.DataReader["WayBillNo"].ToString();
                    this.SupplierID = dbManager.DataReader["SupplierId"].ToString();
                    this.PreparedBy = dbManager.DataReader["Prepared_By"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string DC_Purchase_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [DC_Purchase] SET DC_No = '{0}',DC_Date='{1}',LR_No='{2}',Transporter='{3}',Freight={4},WayBillNo='{5}',SupplierId={6},Prepared_By={7} WHERE DC_Pur_Id = {8}", this.DCNo, this.DCDate, this.LRNo, this.Transporter, this.Freight, this.Waybillno, this.SupplierID, this.PreparedBy, this.PurId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string DC_Purchase_Delete(string POID)
            {
                if (DeleteRecord("[DC_Purchase_Details]", "Dc_Id", POID) == true)
                {
                    if (DeleteRecord("[DC_Purchase]", "DC_Pur_Id", POID) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public void DC_Purchase_Details_Select(string MRNID, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [DC_Purchase_Details],[Product_Master] WHERE [DC_Purchase_Details].Product_Id=[Product_Master].Product_Id  AND [DC_Purchase_Details].Dc_Id=" + MRNID);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Product");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("BatchNo");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("MfgDate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ExpDate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Gms/ml");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("NoofBottles");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("NoofCases");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ProductId");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Product"] = dbManager.DataReader["Name"].ToString();
                    dr["BatchNo"] = dbManager.DataReader["Batchno"].ToString();
                    dr["MFGDate"] = Convert.ToDateTime(dbManager.DataReader["MFG_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dr["ExpDate"] = Convert.ToDateTime(dbManager.DataReader["Expiry_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dr["Gms/ml"] = dbManager.DataReader["Packing"].ToString();
                    dr["NoofBottles"] = dbManager.DataReader["Quantity"].ToString();
                    dr["NoofCases"] = dbManager.DataReader["Cases"].ToString();
                    dr["ProductId"] = dbManager.DataReader["Product_Id"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void DCProduct_Select(Control ControlForBind, string SOid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT Product_Master.Product_Id,Product_Master.Name FROM Product_Master, DC_Purchase_Details  where DC_Purchase_Details.Product_Id =  Product_Master.Product_Id and DC_Purchase_Details.Dc_Id =" + SOid + " ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Name", "Product_Id");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static void DCCustomer_Select(Control ControlForBind, string SOid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT DC_Pur_Id,DC_No FROM DC_Purchase, YANTRA_SUPPLIER_MAST  where DC_Purchase.SupplierId =  YANTRA_SUPPLIER_MAST.SUP_ID and DC_Purchase.SupplierId =" + SOid + " ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "DC_No", "DC_Pur_Id");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }
        }

        ////////////DC - Sales

        public class DCSales
        {
            public string PurId, DCNo, DCDate, LRNo, Transporter, Freight, Waybillno, SupplierID, PreparedBy;

            public string purdetid, productid, batchno, mfgdate, expirydate, packing, Quantity, noofcases;

            public string stockid, qty;

            public static string DCPurchase_AutoGenCode()
            {
                return AutoGenMaxNo("DC_Sales", "DC_No");
            }

            public string DCPurchase_Save()
            {
                this.PurId = AutoGenMaxId("[DC_Sales]", "DC_Sales_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [DC_Sales] VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}',{7},{8})",
               this.PurId, this.DCNo, this.DCDate, this.LRNo, this.Transporter, this.Freight, this.Waybillno, this.SupplierID, this.PreparedBy);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string DCPurchaseDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [DC_Sales_Details] SELECT ISNULL(MAX(DC_Sales_Det_Id),0)+1,{0},{1},'{2}','{3}','{4}','{5}',{6},'{7}' FROM [DC_Sales_Details]", this.PurId, this.productid, this.batchno, this.mfgdate, this.expirydate, this.packing, this.Quantity, this.noofcases);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string StockID_AutoGen()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(STOCK_ID),0)+1 FROM STOCK").ToString());
                return _returnIntValue.ToString();
            }

            public string MRNStock_Update(string productid, string Qty, string batchno)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[STOCK]", "Product_Id", productid, "Batch_No", batchno) == true)
                {
                    _commandText = string.Format("UPDATE [STOCK] SET  QTY=CONVERT(BIGINT,QTY)-{0} WHERE Product_Id = {1}  and Batch_No = '{2}' ", Qty, productid, batchno);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }

                return _returnStringMessage;
            }

            //public string MRNStock_Update(string productid, string Qty, string batchno, string mfg, string exp)
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();
            //    if (IsRecordExists("[STOCK]", "Product_Id", productid, "Batch_No", batchno) == true)
            //    {
            //        _commandText = string.Format("UPDATE [STOCK] SET  QTY=CONVERT(BIGINT,QTY)+{0} WHERE Product_Id = {1}  and Batch_No = '{2}' ", Qty, productid, batchno);
            //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            //        _returnStringMessage = string.Empty;
            //        if (_returnIntValue < 0 || _returnIntValue == 0)
            //        {
            //            _returnStringMessage = "Some Data Missing.";
            //        }
            //        else if (_returnIntValue > 0)
            //        {
            //            _returnStringMessage = "Data Updated Successfully";
            //        }
            //    }
            //    else
            //    {
            //        this.stockid = StockID_AutoGen();
            //        _commandText = string.Format("INSERT INTO [STOCK] VALUES ({0},{1},{2},'{3}','{4}','{5}')", this.stockid, productid, batchno, Qty, mfg, exp);
            //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

            //        _returnStringMessage = string.Empty;
            //        if (_returnIntValue < 0 || _returnIntValue == 0)
            //        {
            //            _returnStringMessage = "Some Data Missing.";
            //        }
            //        else if (_returnIntValue > 0)
            //        {
            //            _returnStringMessage = "Data Saved Successfully";
            //        }
            //    }
            //    return _returnStringMessage;
            //}

            public int DC_Purchase_Details_Delete(string MRNID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [DC_Sales_Details] WHERE Dc_Id = {0}", MRNID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int DC_Purchase_Select(string MRNID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [DC_Sales] where DC_Sales_Id ='" + MRNID + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.PurId = dbManager.DataReader["DC_Sales_Id"].ToString();
                    this.DCNo = dbManager.DataReader["DC_No"].ToString();
                    this.DCDate = Convert.ToDateTime(dbManager.DataReader["DC_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.LRNo = dbManager.DataReader["LR_No"].ToString();
                    this.Transporter = dbManager.DataReader["Transporter"].ToString();
                    this.Freight = dbManager.DataReader["Freight"].ToString();
                    this.Waybillno = dbManager.DataReader["WayBillNo"].ToString();
                    this.SupplierID = dbManager.DataReader["SupplierId"].ToString();
                    this.PreparedBy = dbManager.DataReader["Prepared_By"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string DC_Purchase_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [DC_Sales] SET DC_No = '{0}',DC_Date='{1}',LR_No='{2}',Transporter='{3}',Freight={4},WayBillNo='{5}',SupplierId={6},Prepared_By={7} WHERE DC_Sales_Id = {8}", this.DCNo, this.DCDate, this.LRNo, this.Transporter, this.Freight, this.Waybillno, this.SupplierID, this.PreparedBy, this.PurId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string DC_Purchase_Delete(string POID)
            {
                if (DeleteRecord("[DC_Sales_Details]", "Dc_Id", POID) == true)
                {
                    if (DeleteRecord("[DC_Sales]", "DC_Sales_Id", POID) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            //public string DC_Purchase_Delete(string MRNID)
            //{
            //    if (DeleteRecord("[DC_Sales]", "DC_Sales_Id", MRNID) == true)
            //    {
            //        _returnStringMessage = "Data Deleted Successfully";
            //    }
            //    else
            //    {
            //        _returnStringMessage = "Some Data Missing.";
            //    }

            //    return _returnStringMessage;
            //}

            public void DC_Purchase_Details_Select(string MRNID, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [DC_Sales_Details],[Product_Master] WHERE [DC_Sales_Details].Product_Id=[Product_Master].Product_Id  AND [DC_Sales_Details].Dc_Id=" + MRNID);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Product");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("BatchNo");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("MfgDate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ExpDate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Gms/ml");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("NoofBottles");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("NoofCases");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ProductId");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Product"] = dbManager.DataReader["Name"].ToString();
                    dr["BatchNo"] = dbManager.DataReader["Batchno"].ToString();
                    dr["MFGDate"] = Convert.ToDateTime(dbManager.DataReader["MFG_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dr["ExpDate"] = Convert.ToDateTime(dbManager.DataReader["Expiry_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dr["Gms/ml"] = dbManager.DataReader["Packing"].ToString();
                    dr["NoofBottles"] = dbManager.DataReader["Quantity"].ToString();
                    dr["NoofCases"] = dbManager.DataReader["Cases"].ToString();
                    dr["ProductId"] = dbManager.DataReader["Product_Id"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void DCProduct_Select(Control ControlForBind, string SOid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT (Name + '-' + Sizes) AS Name,Product_Master.Product_Id FROM Product_Master, DC_Sales_Details  where DC_Sales_Details.Product_Id =  Product_Master.Product_Id and DC_Sales_Details.Dc_Id =" + SOid + " ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Name", "Product_Id");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static void DCCustomer_Select(Control ControlForBind, string SOid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT DC_Sales_Id,DC_No FROM DC_Sales, YANTRA_CUSTOMER_MAST  where DC_Sales.SupplierId =  YANTRA_CUSTOMER_MAST.CUST_ID and DC_Sales.SupplierId =" + SOid + " ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "DC_No", "DC_Sales_Id");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }
        }

        public class SalesAccountCopy
        {
            public string acopyid, custid, debit, credit, naration, acopydate, invoiceno;

            public string SalesAccountCopy_Save()
            {
                try
                {
                    dbManager.Open();
                    this.acopyid = AutoGenMaxId("[SalesAccount_Copy]", "acopy_id");
                    _commandText = string.Format("INSERT INTO [SalesAccount_Copy] VALUES({0},{1},'{2}','{3}','{4}','{5}','{6}')",
                   this.acopyid, this.custid, this.debit, this.credit, this.naration, this.acopydate, this.invoiceno);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }
                    return _returnStringMessage;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    dbManager.Dispose();
                }
            }

            public string SalesAccountCopy_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [SalesAccount_Copy] SET cust_id = {0},debit='{1}',acopy_date='{2}' WHERE invoiceNo = '{3}'", this.custid, this.debit, this.acopydate, this.invoiceno);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string ReturnSalesAccountCopy_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [SalesAccount_Copy] SET cust_id = {0},credit='{1}',acopy_date='{2}' WHERE invoiceNo = {3}", this.custid, this.credit, this.acopydate, this.invoiceno);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }
        }

        /// <summary>
        /// //DC Invoice
        /// </summary>

        public class DCInvoice
        {
            public string siid, sino, sidate, dcid, custid, vat, cst, insurance, preparedby, transport, MainDiscount, totalamount;

            public string sidetid, productid, qty, rate, amount, discount, BatchNo, mfgdate, expdate, cases;

            public static string DCInvoice_AutoGenCode()
            {
                return AutoGenMaxNo("SALES_INVOICE", "SI_NO");
            }

            public string DCInvoice_Save()
            {
                this.siid = AutoGenMaxId("[SALES_INVOICE]", "SI_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [SALES_INVOICE] VALUES({0},'{1}','{2}',{3},{4},'{5}','{6}','{7}','{8}',{9},'{10}','{11}')",
               this.siid, this.sino, this.sidate, this.dcid, this.custid, this.insurance, this.vat, this.cst, this.transport, this.preparedby, this.MainDiscount, this.totalamount);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string DCInvoiceDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [SALES_INVOCE_DET] SELECT ISNULL(MAX(SI_DET_ID),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}' FROM [SALES_INVOCE_DET]", this.siid, this.productid, this.qty, this.rate, this.amount, this.discount, this.BatchNo, this.mfgdate, this.expdate, this.cases);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int DCInvoiceInvoiceDetails_Delete(string SIID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [SALES_INVOCE_DET] WHERE SI_ID = {0}", SIID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int DCInvoice_Select(string SIID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SALES_INVOICE] where SALES_INVOICE.SI_ID ='" + SIID + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.siid = dbManager.DataReader["SI_ID"].ToString();
                    this.sino = dbManager.DataReader["SI_NO"].ToString();
                    this.sidate = Convert.ToDateTime(dbManager.DataReader["SI_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.dcid = dbManager.DataReader["DC_ID"].ToString();

                    this.insurance = dbManager.DataReader["INSURANCE"].ToString();
                    this.vat = dbManager.DataReader["VAT"].ToString();
                    this.preparedby = dbManager.DataReader["PREPARED_BY"].ToString();
                    this.custid = dbManager.DataReader["CUST_ID"].ToString();
                    this.insurance = dbManager.DataReader["INSURANCE"].ToString();
                    this.cst = dbManager.DataReader["CST"].ToString();
                    this.transport = dbManager.DataReader["TRANSPORT"].ToString();
                    this.MainDiscount = dbManager.DataReader["Discount"].ToString();
                    this.totalamount = dbManager.DataReader["Totalamount"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string MRNStock_Update(string productid, string Qty, string batchno)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[STOCK]", "Product_Id", productid, "Batch_No", batchno) == true)
                {
                    _commandText = string.Format("UPDATE [STOCK] SET  QTY=CONVERT(BIGINT,QTY)-{0} WHERE Product_Id = {1}  and Batch_No = '{2}' ", Qty, productid, batchno);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }

                return _returnStringMessage;
            }

            public string DCInvoice_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [SALES_INVOICE] SET SI_NO = '{0}',SI_DATE='{1}',DC_ID={2},CUST_ID={3},INSURANCE='{4}',VAT='{5}',CST='{6}',TRANSPORT='{7}',PREPARED_BY={8},Discount='{9}',Totalamount='{10}' WHERE SI_ID = {11}", this.sino, this.sidate, this.dcid, this.custid, this.insurance, this.vat, this.cst, this.transport, this.preparedby, this.MainDiscount, this.totalamount, this.siid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string DCInvoice_Delete(string POID)
            {
                if (DeleteRecord("[SALES_INVOCE_DET]", "SI_ID", POID) == true)
                {
                    if (DeleteRecord("[SALES_INVOICE]", "SI_ID", POID) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public string SalesAccountCopyDCInvoice_Delete(string custid, string Invoiceno)
            {
                if (DeleteRecord("[SalesAccount_Copy]", "cust_id", custid, "invoiceNo", Invoiceno) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public void InvocieDetails_Select(string SIID, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SALES_INVOCE_DET],[Product_Master] WHERE [SALES_INVOCE_DET].PRODUCT_ID=[Product_Master].Product_Id  AND [SALES_INVOCE_DET].SI_ID=" + SIID);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Product");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Quantity");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Discount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ProductId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("BatchNo");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("MfgDate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ExpDate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("NoofCases");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Product"] = dbManager.DataReader["Name"].ToString();
                    dr["Quantity"] = dbManager.DataReader["QTY"].ToString();
                    dr["Rate"] = dbManager.DataReader["RATE"].ToString();
                    dr["Discount"] = dbManager.DataReader["DISCOUNT"].ToString();
                    dr["Amount"] = dbManager.DataReader["AMOUNT"].ToString();
                    dr["ProductId"] = dbManager.DataReader["Product_Id"].ToString();
                    dr["BatchNo"] = dbManager.DataReader["BatchNo"].ToString();

                    dr["MfgDate"] = Convert.ToDateTime(dbManager.DataReader["MFG_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dr["ExpDate"] = Convert.ToDateTime(dbManager.DataReader["Expiry_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    dr["NoofCases"] = dbManager.DataReader["Cases"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void DCInvoice_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT SI_NO,SI_ID FROM [SALES_INVOICE] ORDER BY SI_ID desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "SI_NO", "SI_ID");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static void InvoiceItems_Select(Control ControlForBind, string SIid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT YANTRA_ITEM_MAST.ITEM_MODEL_NO,YANTRA_ITEM_MAST.ITEM_CODE FROM YANTRA_ITEM_MAST, [SALES_INVOCE_DET]  where SALES_INVOCE_DET.ITEM_CODE =  YANTRA_ITEM_MAST.ITEM_CODE and SALES_INVOCE_DET.SI_ID =" + SIid + " ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "ITEM_MODEL_NO", "ITEM_CODE");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }
        }

        /// <summary>
        /// //PURCHASE Invoice
        /// </summary>

        public class PURCHASEInvoice
        {
            public string siid, sino, sidate, dcid, custid, vat, cst, insurance, preparedby, transport;

            public string sidetid, productid, qty, rate, amount, discount, BatchNo, mfgdate, expirydate, stockid;

            public static string DCInvoice_AutoGenCode()
            {
                return AutoGenMaxNo("PURCHASE_INVOICE", "SI_NO");
            }

            public string DCInvoice_Save()
            {
                this.siid = AutoGenMaxId("[PURCHASE_INVOICE]", "SI_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [PURCHASE_INVOICE] VALUES({0},'{1}','{2}',{3},{4},'{5}','{6}','{7}','{8}',{9})",
               this.siid, this.sino, this.sidate, this.dcid, this.custid, this.insurance, this.vat, this.cst, this.transport, this.preparedby);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string DCInvoiceDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [PURCHASE_INVOICE_DETAILS] SELECT ISNULL(MAX(SI_DET_ID),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}' FROM [PURCHASE_INVOICE_DETAILS]", this.siid, this.productid, this.qty, this.rate, this.amount, this.discount, this.BatchNo, this.mfgdate, this.expirydate);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int DCInvoiceInvoiceDetails_Delete(string SIID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [PURCHASE_INVOICE_DETAILS] WHERE SI_ID = {0}", SIID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int DCInvoice_Select(string SIID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [PURCHASE_INVOICE] where PURCHASE_INVOICE.SI_ID ='" + SIID + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.siid = dbManager.DataReader["SI_ID"].ToString();
                    this.sino = dbManager.DataReader["SI_NO"].ToString();
                    this.sidate = Convert.ToDateTime(dbManager.DataReader["SI_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.dcid = dbManager.DataReader["DC_ID"].ToString();

                    this.insurance = dbManager.DataReader["INSURANCE"].ToString();
                    this.vat = dbManager.DataReader["VAT"].ToString();
                    this.preparedby = dbManager.DataReader["PREPARED_BY"].ToString();
                    this.custid = dbManager.DataReader["CUST_ID"].ToString();
                    this.insurance = dbManager.DataReader["INSURANCE"].ToString();
                    this.cst = dbManager.DataReader["CST"].ToString();
                    this.transport = dbManager.DataReader["TRANSPORT"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string DCInvoice_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [PURCHASE_INVOICE] SET SI_NO = '{0}',SI_DATE='{1}',DC_ID={2},CUST_ID={3},INSURANCE='{4}',VAT='{5}',CST='{6}',TRANSPORT='{7}',PREPARED_BY={8} WHERE SI_ID = {9}", this.sino, this.sidate, this.dcid, this.custid, this.insurance, this.vat, this.cst, this.transport, this.preparedby, this.siid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string DCInvoice_Delete(string POID)
            {
                if (DeleteRecord("[PURCHASE_INVOICE_DETAILS]", "SI_ID", POID) == true)
                {
                    if (DeleteRecord("[PURCHASE_INVOICE]", "SI_ID", POID) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public string StockID_AutoGen()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(STOCK_ID),0)+1 FROM STOCK").ToString());
                return _returnIntValue.ToString();
            }

            public string MRNStock_Update(string productid, string Qty, string batchno, string mfg, string exp)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[STOCK]", "Product_Id", productid, "Batch_No", batchno) == true)
                {
                    _commandText = string.Format("UPDATE [STOCK] SET  QTY=CONVERT(BIGINT,QTY)+{0} WHERE Product_Id = {1}  and Batch_No = '{2}' ", Qty, productid, batchno);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }
                else
                {
                    this.stockid = StockID_AutoGen();
                    _commandText = string.Format("INSERT INTO [STOCK] VALUES ({0},{1},'{2}','{3}','{4}','{5}')", this.stockid, productid, batchno, Qty, mfg, exp);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }
                }
                return _returnStringMessage;
            }

            public string SalesAccountCopyDCInvoice_Delete(string custid, string Invoiceno)
            {
                if (DeleteRecord("[PurchaseAccount_Copy]", "sup_id", custid, "invoiceno", Invoiceno) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public void InvocieDetails_Select(string SIID, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [PURCHASE_INVOICE_DETAILS],[Product_Master] WHERE [PURCHASE_INVOICE_DETAILS].PRODUCT_ID=[Product_Master].Product_Id  AND [PURCHASE_INVOICE_DETAILS].SI_ID=" + SIID);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Product");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Quantity");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Discount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ProductId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("BatchNo");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("MFGDate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("EXPDate");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Product"] = dbManager.DataReader["Name"].ToString();
                    dr["Quantity"] = dbManager.DataReader["QTY"].ToString();
                    dr["Rate"] = dbManager.DataReader["RATE"].ToString();
                    dr["Discount"] = dbManager.DataReader["DISCOUNT"].ToString();
                    dr["Amount"] = dbManager.DataReader["AMOUNT"].ToString();
                    dr["ProductId"] = dbManager.DataReader["Product_Id"].ToString();
                    dr["BatchNo"] = dbManager.DataReader["BatchNo"].ToString();

                    dr["MFGDate"] = dbManager.DataReader["MFG_Date"].ToString();
                    dr["EXPDate"] = dbManager.DataReader["Expiry_Date"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void DCInvoice_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT SI_NO,SI_ID FROM [PURCHASE_INVOICE] ORDER BY SI_ID desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "SI_NO", "SI_ID");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static void InvoiceItems_Select(Control ControlForBind, string SIid)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT YANTRA_ITEM_MAST.ITEM_MODEL_NO,YANTRA_ITEM_MAST.ITEM_CODE FROM YANTRA_ITEM_MAST, [SALES_INVOCE_DET]  where SALES_INVOCE_DET.ITEM_CODE =  YANTRA_ITEM_MAST.ITEM_CODE and SALES_INVOCE_DET.SI_ID =" + SIid + " ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "ITEM_MODEL_NO", "ITEM_CODE");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }
        }

        /// <summary>
        /// //DC Invoice
        /// </summary>

        public class DirectInvoice
        {
            public string siid, sino, sidate, custid, vat, cst, insurance, preparedby, transport, totalamount;

            public string sidetid, productid, qty, rate, amount, discount, BatchNo;

            public static string DirectInvoice_AutoGenCode()
            {
                return AutoGenMaxNo("Direct_Invoice", "SI_NO");
            }

            public string DirectInvoice_Save()
            {
                this.siid = AutoGenMaxId("[Direct_Invoice]", "SI_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Direct_Invoice] VALUES({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}',{8},'{9}')",
               this.siid, this.sino, this.sidate, this.custid, this.insurance, this.vat, this.cst, this.transport, this.preparedby, this.totalamount);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string DirectInvoiceDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Direct_Invoice_Details] SELECT ISNULL(MAX(SI_DET_ID),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}' FROM [Direct_Invoice_Details]", this.siid, this.productid, this.qty, this.rate, this.amount, this.discount, this.BatchNo);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int DirectInvoiceDetails_Delete(string SIID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Direct_Invoice_Details] WHERE SI_ID = {0}", SIID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int DirectInvoice_Select(string SIID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Direct_Invoice] where Direct_Invoice.SI_ID ='" + SIID + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.siid = dbManager.DataReader["SI_ID"].ToString();
                    this.sino = dbManager.DataReader["SI_NO"].ToString();
                    this.sidate = Convert.ToDateTime(dbManager.DataReader["SI_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    this.insurance = dbManager.DataReader["INSURANCE"].ToString();
                    this.vat = dbManager.DataReader["VAT"].ToString();
                    this.preparedby = dbManager.DataReader["PREPARED_BY"].ToString();
                    this.custid = dbManager.DataReader["CUST_ID"].ToString();
                    this.insurance = dbManager.DataReader["INSURANCE"].ToString();
                    this.cst = dbManager.DataReader["CST"].ToString();
                    this.transport = dbManager.DataReader["TRANSPORT"].ToString();
                    this.totalamount = dbManager.DataReader["Totalamount"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string DirectInvoice_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Direct_Invoice] SET SI_NO = '{0}',SI_DATE='{1}',CUST_ID={2},INSURANCE='{3}',VAT='{4}',CST='{5}',TRANSPORT='{6}',PREPARED_BY={7},Totalamount='{8}' WHERE SI_ID = {9}", this.sino, this.sidate, this.custid, this.insurance, this.vat, this.cst, this.transport, this.preparedby, this.totalamount, this.siid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string DirectInvoice_Delete(string POID)
            {
                if (DeleteRecord("[Direct_Invoice_Details]", "SI_ID", POID) == true)
                {
                    if (DeleteRecord("[Direct_Invoice]", "SI_ID", POID) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public void DirectInvoiceDetails_Select(string SIID, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Direct_Invoice_Details],[Product_Master] WHERE [Direct_Invoice_Details].PRODUCT_ID=[Product_Master].Product_Id  AND [Direct_Invoice_Details].SI_ID=" + SIID);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Product");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Quantity");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Discount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ProductId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("BatchNo");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Product"] = dbManager.DataReader["Name"].ToString();
                    dr["Quantity"] = dbManager.DataReader["QTY"].ToString();
                    dr["Rate"] = dbManager.DataReader["RATE"].ToString();
                    dr["Discount"] = dbManager.DataReader["DISCOUNT"].ToString();
                    dr["Amount"] = dbManager.DataReader["AMOUNT"].ToString();
                    dr["ProductId"] = dbManager.DataReader["Product_Id"].ToString();
                    dr["BatchNo"] = dbManager.DataReader["BatchNo"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void DirectInvoice_Select(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT SI_NO,SI_ID FROM [Direct_Invoice] ORDER BY SI_ID desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "SI_NO", "SI_ID");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public string SalesAccountCopyDCInvoice_Delete(string custid, string Invoiceno)
            {
                if (DeleteRecord("[SalesAccount_Copy]", "cust_id", custid, "invoiceNo", Invoiceno) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public string MRNStock_Update(string productid, string Qty, string batchno)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[STOCK]", "Product_Id", productid, "Batch_No", batchno) == true)
                {
                    _commandText = string.Format("UPDATE [STOCK] SET  QTY=CONVERT(BIGINT,QTY)-{0} WHERE Product_Id = {1}  and Batch_No = '{2}' ", Qty, productid, batchno);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }

                return _returnStringMessage;
            }

            public string MRNReturnStock_Update(string productid, string Qty, string batchno)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[STOCK]", "Product_Id", productid, "Batch_No", batchno) == true)
                {
                    _commandText = string.Format("UPDATE [STOCK] SET  QTY=CONVERT(BIGINT,QTY)+{0} WHERE Product_Id = {1}  and Batch_No = '{2}' ", Qty, productid, batchno);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }

                return _returnStringMessage;
            }
        }

        /// <summary>
        /// //Sales Return
        /// </summary>

        public class SalesReturn
        {
            public string siid, sino, sidate, custid, vat, cst, insurance, preparedby, transport;

            public string sidetid, productid, qty, rate, amount, discount, BatchNo;

            public static string DirectInvoice_AutoGenCode()
            {
                return AutoGenMaxNo("Return_Sales", "SI_NO");
            }

            public string DirectInvoice_Save()
            {
                this.siid = AutoGenMaxId("[Return_Sales]", "SI_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Return_Sales] VALUES({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}',{8})",
               this.siid, this.sino, this.sidate, this.custid, this.insurance, this.vat, this.cst, this.transport, this.preparedby);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string DirectInvoiceDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Return_Sales_Details] SELECT ISNULL(MAX(SI_DET_ID),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}' FROM [Direct_Invoice_Details]", this.siid, this.productid, this.qty, this.rate, this.amount, this.discount, this.BatchNo);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public int DirectInvoiceDetails_Delete(string SIID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Return_Sales_Details] WHERE SI_ID = {0}", SIID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public string SalesAccountCopyDCInvoice_Delete(string custid, string Invoiceno)
            {
                if (DeleteRecord("[SalesAccount_Copy]", "cust_id", custid, "invoiceNo", Invoiceno) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public int DirectInvoice_Select(string SIID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Return_Sales] where Return_Sales.SI_ID ='" + SIID + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.siid = dbManager.DataReader["SI_ID"].ToString();
                    this.sino = dbManager.DataReader["SI_NO"].ToString();
                    this.sidate = Convert.ToDateTime(dbManager.DataReader["SI_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    this.insurance = dbManager.DataReader["INSURANCE"].ToString();
                    this.vat = dbManager.DataReader["VAT"].ToString();
                    this.preparedby = dbManager.DataReader["PREPARED_BY"].ToString();
                    this.custid = dbManager.DataReader["CUST_ID"].ToString();
                    this.insurance = dbManager.DataReader["INSURANCE"].ToString();
                    this.cst = dbManager.DataReader["CST"].ToString();
                    this.transport = dbManager.DataReader["TRANSPORT"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string DirectInvoice_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Return_Sales] SET SI_NO = '{0}',SI_DATE='{1}',CUST_ID={2},INSURANCE='{3}',VAT='{4}',CST='{5}',TRANSPORT='{6}',PREPARED_BY={7} WHERE SI_ID = {8}", this.sino, this.sidate, this.custid, this.insurance, this.vat, this.cst, this.transport, this.preparedby, this.siid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string DirectInvoice_Delete(string POID)
            {
                if (DeleteRecord("[Return_Sales_Details]", "SI_ID", POID) == true)
                {
                    if (DeleteRecord("[Return_Sales]", "SI_ID", POID) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public void DirectInvoiceDetails_Select(string SIID, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Return_Sales_Details],[Product_Master] WHERE [Return_Sales_Details].PRODUCT_ID=[Product_Master].Product_Id  AND [Return_Sales_Details].SI_ID=" + SIID);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Product");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Quantity");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Discount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ProductId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("BatchNo");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Product"] = dbManager.DataReader["Name"].ToString();
                    dr["Quantity"] = dbManager.DataReader["QTY"].ToString();
                    dr["Rate"] = dbManager.DataReader["RATE"].ToString();
                    dr["Discount"] = dbManager.DataReader["DISCOUNT"].ToString();
                    dr["Amount"] = dbManager.DataReader["AMOUNT"].ToString();
                    dr["ProductId"] = dbManager.DataReader["Product_Id"].ToString();
                    dr["BatchNo"] = dbManager.DataReader["BatchNo"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public string MRNReturnStock_Update(string productid, string Qty, string batchno)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[STOCK]", "Product_Id", productid, "Batch_No", batchno) == true)
                {
                    _commandText = string.Format("UPDATE [STOCK] SET  QTY=CONVERT(BIGINT,QTY)+{0} WHERE Product_Id = {1}  and Batch_No = '{2}' ", Qty, productid, batchno);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }

                return _returnStringMessage;
            }
        }

        /// <summary>
        /// //Purchase Return
        /// </summary>

        public class PurchaseReturn
        {
            public string siid, sino, sidate, custid, vat, cst, insurance, preparedby, transport;

            public string sidetid, productid, qty, rate, amount, discount, BatchNo;

            public static string DirectInvoice_AutoGenCode()
            {
                return AutoGenMaxNo("Return_Purchases", "SI_NO");
            }

            public string DirectInvoice_Save()
            {
                this.siid = AutoGenMaxId("[Return_Purchases]", "SI_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Return_Purchases] VALUES({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}',{8})",
               this.siid, this.sino, this.sidate, this.custid, this.insurance, this.vat, this.cst, this.transport, this.preparedby);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string DirectInvoiceDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Return_Purchase_Details] SELECT ISNULL(MAX(SI_DET_ID),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}' FROM [Return_Purchase_Details]", this.siid, this.productid, this.qty, this.rate, this.amount, this.discount, this.BatchNo);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string SalesAccountCopyDCInvoice_Delete(string custid, string Invoiceno)
            {
                if (DeleteRecord("[PurchaseAccount_Copy]", "sup_id", custid, "invoiceno", Invoiceno) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public int DirectInvoiceDetails_Delete(string SIID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Return_Purchase_Details] WHERE SI_ID = {0}", SIID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int DirectInvoice_Select(string SIID)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Return_Purchases] where Return_Purchases.SI_ID ='" + SIID + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.siid = dbManager.DataReader["SI_ID"].ToString();
                    this.sino = dbManager.DataReader["SI_NO"].ToString();
                    this.sidate = Convert.ToDateTime(dbManager.DataReader["SI_DATE"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    this.insurance = dbManager.DataReader["INSURANCE"].ToString();
                    this.vat = dbManager.DataReader["VAT"].ToString();
                    this.preparedby = dbManager.DataReader["PREPARED_BY"].ToString();
                    this.custid = dbManager.DataReader["CUST_ID"].ToString();
                    this.insurance = dbManager.DataReader["INSURANCE"].ToString();
                    this.cst = dbManager.DataReader["CST"].ToString();
                    this.transport = dbManager.DataReader["TRANSPORT"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string DirectInvoice_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Return_Purchases] SET SI_NO = '{0}',SI_DATE='{1}',CUST_ID={2},INSURANCE='{3}',VAT='{4}',CST='{5}',TRANSPORT='{6}',PREPARED_BY={7} WHERE SI_ID = {8}", this.sino, this.sidate, this.custid, this.insurance, this.vat, this.cst, this.transport, this.preparedby, this.siid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }
                return _returnStringMessage;
            }

            public string DirectInvoice_Delete(string POID)
            {
                if (DeleteRecord("[Return_Purchase_Details]", "SI_ID", POID) == true)
                {
                    if (DeleteRecord("[Return_Purchases]", "SI_ID", POID) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public void DirectInvoiceDetails_Select(string SIID, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Return_Purchase_Details],[Product_Master] WHERE [Return_Purchase_Details].PRODUCT_ID=[Product_Master].Product_Id  AND [Return_Purchase_Details].SI_ID=" + SIID);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Product");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Quantity");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Discount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ProductId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("BatchNo");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["Product"] = dbManager.DataReader["Name"].ToString();
                    dr["Quantity"] = dbManager.DataReader["QTY"].ToString();
                    dr["Rate"] = dbManager.DataReader["RATE"].ToString();
                    dr["Discount"] = dbManager.DataReader["DISCOUNT"].ToString();
                    dr["Amount"] = dbManager.DataReader["AMOUNT"].ToString();
                    dr["ProductId"] = dbManager.DataReader["Product_Id"].ToString();
                    dr["BatchNo"] = dbManager.DataReader["BatchNo"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }
                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public string MRNReturnStock_Update(string productid, string Qty, string batchno)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[STOCK]", "Product_Id", productid, "Batch_No", batchno) == true)
                {
                    _commandText = string.Format("UPDATE [STOCK] SET  QTY=CONVERT(BIGINT,QTY)-{0} WHERE Product_Id = {1}  and Batch_No = '{2}' ", Qty, productid, batchno);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Updated Successfully";
                    }
                }

                return _returnStringMessage;
            }
        }

        //Method Receipts
        public class SalesReceipts
        {
            public string Id, custid, amount, receivedtype, narration, srdate, srno;
            // public string SupDetId, ItemCode, ItemType, UOM;

            public SalesReceipts()
            { }

            public static string SalesReceipts_AutoGenCode()
            {
                return AutoGenMaxNo("Receipts_Sales", "receipt_No");
            }

            public string SalesReceipts_Save()
            {
                try
                {
                    dbManager.Open();

                    _commandText = string.Format("INSERT INTO [Receipts_Sales] SELECT ISNULL(MAX(Receipts_Id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}' FROM [Receipts_Sales]", this.custid, this.amount, this.receivedtype, this.narration, this.srdate, this.srno);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }

                    return _returnStringMessage;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    dbManager.Dispose();
                }
            }

            public string SalesReceipts_Update()
            {
                dbManager.Open();

                _commandText = string.Format("UPDATE [Receipts_Sales] SET Cust_Id='{0}',Amount='{1}',Payment_received='{2}',narration ='{3}',receipt_date='{4}',receipt_No='{5}'  WHERE Receipts_Id  ={6}", this.custid, this.amount, this.receivedtype, this.narration, this.srdate, this.srno, this.Id);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }

                return _returnStringMessage;
            }

            public string SalesReceipts_Delete(string delid)
            {
                string delid1 = delid;
                if (DeleteRecord("[Receipts_Sales]", "Receipts_Id", delid1) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string SalesAccountCopyDCInvoice_Delete(string custid, string Invoiceno)
            {
                if (DeleteRecord("[SalesAccount_Copy]", "cust_id", custid, "invoiceNo", Invoiceno) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public int SalesReceipts_Select(string STId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [Receipts_Sales] WHERE Receipts_Id = " + STId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.custid = dbManager.DataReader["Cust_Id"].ToString();
                    this.amount = dbManager.DataReader["Amount"].ToString();
                    this.receivedtype = dbManager.DataReader["Payment_received"].ToString();
                    this.narration = dbManager.DataReader["narration"].ToString();
                    this.srdate = Convert.ToDateTime(dbManager.DataReader["receipt_date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.srno = dbManager.DataReader["receipt_No"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }

        //Method Receipts
        public class PurchaseReceipts
        {
            public string Id, custid, amount, receivedtype, narration, srdate, prno;
            // public string SupDetId, ItemCode, ItemType, UOM;

            public PurchaseReceipts()
            { }

            public static string PurchaseReceipts_AutoGenCode()
            {
                return AutoGenMaxNo("Receipts_Purchases", "receipt_No");
            }

            public string PurchaseReceipts_Save()
            {
                try
                {
                    dbManager.Open();
                    _commandText = string.Format("INSERT INTO [Receipts_Purchases] SELECT ISNULL(MAX(Receipts_Id),0)+1,'{0}','{1}','{2}','{3}','{4}','{5}' FROM [Receipts_Purchases]", this.custid, this.amount, this.receivedtype, this.narration, this.srdate, this.prno);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }
                    return _returnStringMessage;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    dbManager.Dispose();
                }
            }

            public string SalesAccountCopyDCInvoice_Delete(string custid, string Invoiceno)
            {
                if (DeleteRecord("[PurchaseAccount_Copy]", "sup_id", custid, "invoiceno", Invoiceno) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public string PurchaseReceipts_Update()
            {
                dbManager.Open();

                _commandText = string.Format("UPDATE [Receipts_Purchases] SET Cust_Id='{0}',Amount='{1}',Payment_received='{2}',narration ='{3}',receipt_date='{4}',receipt_No='{5}'  WHERE Receipts_Id  ={6}", this.custid, this.amount, this.receivedtype, this.narration, this.srdate, this.prno, this.Id);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }

                return _returnStringMessage;
            }

            public string PurchaseReceipts_Delete(string delid)
            {
                string delid1 = delid;
                if (DeleteRecord("[Receipts_Purchases]", "Receipts_Id", delid1) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public int PurchaseReceipts_Select(string STId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [Receipts_Purchases] WHERE Receipts_Id = " + STId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.custid = dbManager.DataReader["Cust_Id"].ToString();
                    this.amount = dbManager.DataReader["Amount"].ToString();
                    this.receivedtype = dbManager.DataReader["Payment_received"].ToString();
                    this.narration = dbManager.DataReader["narration"].ToString();
                    this.srdate = Convert.ToDateTime(dbManager.DataReader["receipt_date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.prno = dbManager.DataReader["receipt_No"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }

        //Method DebitNote
        public class DebitNote
        {
            public string Id, custid, amount, receivedtype, narration, srdate, srno;
            // public string SupDetId, ItemCode, ItemType, UOM;

            public DebitNote()
            { }

            public static string DebitNote_AutoGenCode()
            {
                return AutoGenMaxNo("Debitnote", "receipt_No");
            }

            public string DebitNote_Save()
            {
                try
                {
                    dbManager.Open();

                    _commandText = string.Format("INSERT INTO [Debitnote] SELECT ISNULL(MAX(Receipts_Id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}' FROM [Debitnote]", this.custid, this.amount, this.receivedtype, this.narration, this.srdate, this.srno);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }

                    return _returnStringMessage;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    dbManager.Dispose();
                }
            }

            public string Debitnote_Update()
            {
                dbManager.Open();

                _commandText = string.Format("UPDATE [Debitnote] SET Cust_Id='{0}',Amount='{1}',Payment_received='{2}',narration ='{3}',receipt_date='{4}',receipt_No='{5}'  WHERE Receipts_Id  ={6}", this.custid, this.amount, this.receivedtype, this.narration, this.srdate, this.srno, this.Id);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }

                return _returnStringMessage;
            }

            public string Debitnote_Delete(string delid)
            {
                string delid1 = delid;
                if (DeleteRecord("[Debitnote]", "Receipts_Id", delid1) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string SalesAccountCopyDCInvoice_Delete(string custid, string Invoiceno)
            {
                if (DeleteRecord("[SalesAccount_Copy]", "cust_id", custid, "invoiceNo", Invoiceno) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public int Debitnote_Select(string STId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [Debitnote] WHERE Receipts_Id = " + STId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.custid = dbManager.DataReader["Cust_Id"].ToString();
                    this.amount = dbManager.DataReader["Amount"].ToString();
                    this.receivedtype = dbManager.DataReader["Payment_received"].ToString();
                    this.narration = dbManager.DataReader["narration"].ToString();
                    this.srdate = Convert.ToDateTime(dbManager.DataReader["receipt_date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.srno = dbManager.DataReader["receipt_No"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }

        //Method CreditNote
        public class CreditNote
        {
            public string Id, custid, amount, receivedtype, narration, srdate, srno;
            // public string SupDetId, ItemCode, ItemType, UOM;

            public CreditNote()
            { }

            public static string DebitNote_AutoGenCode()
            {
                return AutoGenMaxNo("CreditNote", "receipt_No");
            }

            public string DebitNote_Save()
            {
                try
                {
                    dbManager.Open();

                    _commandText = string.Format("INSERT INTO [CreditNote] SELECT ISNULL(MAX(Receipts_Id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}' FROM [CreditNote]", this.custid, this.amount, this.receivedtype, this.narration, this.srdate, this.srno);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }

                    return _returnStringMessage;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    dbManager.Dispose();
                }
            }

            public string Debitnote_Update()
            {
                dbManager.Open();

                _commandText = string.Format("UPDATE [CreditNote] SET Cust_Id='{0}',Amount='{1}',Payment_received='{2}',narration ='{3}',receipt_date='{4}',receipt_No='{5}'  WHERE Receipts_Id  ={6}", this.custid, this.amount, this.receivedtype, this.narration, this.srdate, this.srno, this.Id);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }

                return _returnStringMessage;
            }

            public string Debitnote_Delete(string delid)
            {
                string delid1 = delid;
                if (DeleteRecord("[CreditNote]", "Receipts_Id", delid1) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string SalesAccountCopyDCInvoice_Delete(string custid, string Invoiceno)
            {
                if (DeleteRecord("[SalesAccount_Copy]", "cust_id", custid, "invoiceNo", Invoiceno) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }

                return _returnStringMessage;
            }

            public int Debitnote_Select(string STId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [CreditNote] WHERE Receipts_Id = " + STId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.custid = dbManager.DataReader["Cust_Id"].ToString();
                    this.amount = dbManager.DataReader["Amount"].ToString();
                    this.receivedtype = dbManager.DataReader["Payment_received"].ToString();
                    this.narration = dbManager.DataReader["narration"].ToString();
                    this.srdate = Convert.ToDateTime(dbManager.DataReader["receipt_date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.srno = dbManager.DataReader["receipt_No"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }






        public class DailyReport
        {
            public string DRId, DRNo, DRDate, CustName, Remarks, Purpose, DRPreparedBy, DRAttendedBy, Time, Phone, Address;
            public string DRDetId, DRDetDate, DetCustName, DetReference, DetPurpose, DetRemarks, DetComments, EmpID, CommentedBy;
            public string ID, DetId, Date, IssuedDate, Subject, Description, PreparedBy, Status;

            public DailyReport()
            {
            }

            public static string DailyReports_AutoGenCode()
            {

                return AutoGenMaxNo("YANTRA_DAILY_REPORT", "DR_NO");
            }
            public string ToDO_List_Status_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("update to_do_list set status='{0}' where id='{1}' ", this.Status, this.ID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                    //log.add_Insert("Daily Reports Details", "135");

                }
                return _returnStringMessage;
            }
            public string ToDo_List_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                this.ID = AutoGenMaxId("To_Do_List", "Id");

                _commandText = string.Format("INSERT INTO [To_Do_List] SELECT ISNULL(MAX(ID),0)+1,getdate(),'{0}','{1}','{2}','{3}','{4}' FROM [To_Do_List]", this.IssuedDate, this.Subject, this.Description, this.Status, this.PreparedBy);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                    //log.add_Insert("Daily Reports Details", "135");

                }
                return _returnStringMessage;
            }
            public string ToDO_List_Det_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [To_Do_List_Reporting] SELECT ISNULL(MAX(DetId),0)+1,'{0}','{1}' FROM [To_Do_List_Reporting]", this.ID, this.EmpID);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                    //log.add_Insert("Daily Reports Details", "135");

                }
                return _returnStringMessage;
            }
            public string Reference, Architect, outTime, Comment, FileName;

            public static void ReferenceSelect(Control ControlForBind)
            {
                dbManager.Open();
                _commandText = string.Format("select CUST_ID ,CUST_ECC  from YANTRA_CUSTOMER_MAST order  by CUST_ID desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "CUST_ECC", "CUST_ID");
                }
                else if (ControlForBind is GridView)
                {
                    //GridViewBind(ControlForBind as GridView);
                }
                //dbManager.Close();

            }
            public string DailyReports_Save()
            {
                //this.DRNo = DailyReports_AutoGenCode();
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [DAILY_REPORT] SELECT ISNULL(MAX(DAILYREPORTID),0)+1,'{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}' FROM [DAILY_REPORT]", this.DRDate, this.CustName, this.Purpose, this.Remarks, this.DRAttendedBy, this.DRPreparedBy, this.Time, this.Phone, this.Address, this.Reference, this.Architect, this.outTime, this.Comment, this.FileName);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                    //log.add_Insert("Daily Reports Details", "135");

                }
                return _returnStringMessage;
            }
            public string DailyReportComm_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("update YANTRA_DAILY_REPORT set Comments ='{0}' where DAILYREPORTID ={1}", this.DetComments, this.DRId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                    //log.add_Update("Delivery Details", "62");

                }
                return _returnStringMessage;
            }
            public string DailyReportDet_Save()
            {
                this.DRDetId = AutoGenMaxId("[YANTRA_DAILY_REPORT_DET]", "DAILYREPORTDET_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT  INTO [YANTRA_DAILY_REPORT_DET] VALUES({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}',{8})", this.DRId, this.DRDetId, this.DetCustName, this.DetPurpose, this.DetRemarks, this.DetComments, this.DRDetDate, this.DetReference, this.CommentedBy);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                    //log.add_Insert("Sales Assignments Follow Up Details", "120");

                }
                return _returnStringMessage;
            }
            //public string PaymentsReceived_Update()
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();
            //    _commandText = string.Format("UPDATE [YANTRA_PAYMENTS_RECEIVED] SET PR_NO='{0}',PR_DATE='{1}',CUST_ID={2},UNIT_ID={3},SI_ID={4},SI_AMOUNT='{5}',PR_AMT_RECEIVED='{6}',PR_PAYMODE_TYPE='{7}',PR_CHEQUE_NO='{8}',PR_CHEQUE_DATE='{9}',PR_CASH_RECEIVED_DATE='{10}',PR_BANK_DETAILS='{11}',PR_PREPARED_BY='{12}',PR_APPROVED_BY='{13}',PR_PAYMENT_STATUS='{14}',SO_ID={15},SPO_ID={16}  WHERE PR_ID={17}", this.PRNo, Convert.ToDateTime(this.PRDate), this.CustId, this.UnitId, this.SIId, this.SIAmt, this.PRReceivedAmt, this.PRPaymodeType, this.PRChequeNo, Convert.ToDateTime(this.PRChequeDate), Convert.ToDateTime(this.PRCahReceivedDate), this.PRBankDetails, this.PRPreparedBy, this.PRApprovedBy, this.PRPaymentStatus, this.SO_Id, this.SPOId, this.PRId);
            //    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            //    _returnStringMessage = string.Empty;
            //    if (_returnIntValue < 0 || _returnIntValue == 0)
            //    {
            //        _returnStringMessage = "Some Data Missing.";
            //    }
            //   else if (_returnIntValue > 0)
            //    {
            //        _returnStringMessage = "Data Updated Successfully";
            //    }
            //    return _returnStringMessage;
            //}

            //public string PaymentsReceived_Delete(string PaymentsReceivedId)
            //{
            //    if (DeleteRecord("[YANTRA_PAYMENTS_RECEIVED]", "PR_ID", PaymentsReceivedId) == true)
            //    {
            //        _returnStringMessage = "Data Deleted Successfully";
            //    }
            //    else
            //    {
            //        _returnStringMessage = "Some Data Missing.";
            //    }

            //    return _returnStringMessage;
            //}



            //public int PaymentsReceived_Select(string PaymentsReceivedId)
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();

            //    _commandText = string.Format("SELECT * FROM [YANTRA_PAYMENTS_RECEIVED],[YANTRA_CUSTOMER_MAST],[YANTRA_CUSTOMER_UNITS],YANTRA_SO_MAST" +
            //                                                            " WHERE [YANTRA_PAYMENTS_RECEIVED].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID " +
            //                                                            " AND [YANTRA_PAYMENTS_RECEIVED].UNIT_ID=[YANTRA_CUSTOMER_UNITS].CUST_UNIT_ID " +
            //        //" AND [YANTRA_PAYMENTS_RECEIVED].SI_ID=[YANTRA_SALES_INVOICE_MAST].SI_ID  " +
            //                                                             " AND [YANTRA_PAYMENTS_RECEIVED].SO_ID=[YANTRA_SO_MAST].SO_ID  " +
            //                                                            " AND [YANTRA_PAYMENTS_RECEIVED].PR_ID='" + PaymentsReceivedId + "' ORDER BY [YANTRA_PAYMENTS_RECEIVED].PR_ID DESC ");

            //    dbManager.ExecuteReader(CommandType.Text, _commandText);
            //    if (dbManager.DataReader.Read())
            //    {
            //        this.PRId = dbManager.DataReader["PR_ID"].ToString();
            //        this.PRNo = dbManager.DataReader["PR_NO"].ToString();
            //        this.PRDate = Convert.ToDateTime(dbManager.DataReader["PR_DATE"].ToString()).ToString("dd/MM/yyyy");
            //        this.CustId = dbManager.DataReader["CUST_ID"].ToString();
            //        this.UnitId = dbManager.DataReader["UNIT_ID"].ToString();
            //        this.SO_Id = dbManager.DataReader["SO_ID"].ToString();
            //        this.SPOId = dbManager.DataReader["SPO_ID"].ToString();
            //        this.SIId = dbManager.DataReader["SI_ID"].ToString();
            //        this.SIAmt = dbManager.DataReader["SI_AMOUNT"].ToString();
            //        this.PRReceivedAmt = dbManager.DataReader["PR_AMT_RECEIVED"].ToString();
            //        this.PRPaymodeType = dbManager.DataReader["PR_PAYMODE_TYPE"].ToString();
            //        this.PRChequeNo = dbManager.DataReader["PR_CHEQUE_NO"].ToString();
            //        this.PRChequeDate = Convert.ToDateTime(dbManager.DataReader["PR_CHEQUE_DATE"].ToString()).ToString("dd/MM/yyyy");
            //        this.PRCahReceivedDate = Convert.ToDateTime(dbManager.DataReader["PR_CASH_RECEIVED_DATE"].ToString()).ToString("dd/MM/yyyy");
            //        this.PRBankDetails = dbManager.DataReader["PR_BANK_DETAILS"].ToString();
            //        this.PRPreparedBy = dbManager.DataReader["PR_PREPARED_BY"].ToString();
            //        this.PRApprovedBy = dbManager.DataReader["PR_APPROVED_BY"].ToString();
            //        this.PRPaymentStatus = dbManager.DataReader["PR_PAYMENT_STATUS"].ToString();

            //        _returnIntValue = 1;
            //    }
            //    else
            //    {
            //        _returnIntValue = 0;
            //    }
            //    return _returnIntValue;
            //}


            public string PODocdate, PODocRemarks, PODocuments;

            public string PODocuments_Details_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Daily_Report_Docs] SELECT ISNULL(MAX(DA_Doc_Id),0)+1,'{0}','{1}','{2}',{3} FROM [Daily_Report_Docs]", this.PODocdate, this.PODocRemarks, this.PODocuments, this.DRId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Saved Successfully";
                }
                return _returnStringMessage;
            }

            public string PODocumentsDetails_Delete(string Eleid)
            {
                if (DeleteRecord("[Daily_Report_Docs]", "DA_Doc_Id", Eleid) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }

                return _returnStringMessage;
            }



            public int DailyReport_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [DAILY_REPORT] WHERE  [DAILY_REPORT].DAILYREPORTID='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.DRId = dbManager.DataReader["DAILYREPORTID"].ToString();
                    //  this.DRNo = dbManager.DataReader["IndentApproval_No"].ToString();
                    this.DRDate = Convert.ToDateTime(dbManager.DataReader["DATETIME"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Purpose = dbManager.DataReader["PURPOSE"].ToString();
                    this.Remarks = dbManager.DataReader["REMARKS"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }






        }


        //public class DailyReport
        //{
        //    public string DRId, DRNo, DRDate, CustName, Remarks, Purpose, DRPreparedBy, DRAttendedBy, Time, Phone, Address;
        //    public string DRDetId, DRDetDate, DetCustName, DetReference, DetPurpose, DetRemarks, DetComments, EmpID, CommentedBy;

        //    public DailyReport()
        //    {
        //    }

        //    public static string DailyReports_AutoGenCode()
        //    {

        //        return AutoGenMaxNo("YANTRA_DAILY_REPORT", "DR_NO");
        //    }
        //    public string Reference, Architect, outTime, Comment;
        //    public string DailyReports_Save()
        //    {
        //        //this.DRNo = DailyReports_AutoGenCode();
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [YANTRA_DAILY_REPORT] SELECT ISNULL(MAX(DAILYREPORTID),0)+1,'{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}','{10}','{11}','{12}' FROM [YANTRA_DAILY_REPORT]", this.DRDate, this.CustName, this.Purpose, this.Remarks, this.DRAttendedBy, this.DRPreparedBy, this.Time, this.Phone, this.Address, this.Reference, this.Architect, this.outTime, this.Comment);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";

        //        }
        //        return _returnStringMessage;
        //    }
        //    public string DailyReportComm_Update()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("update YANTRA_DAILY_REPORT set Comments ='{0}' where DAILYREPORTID ={1}", this.DetComments, this.DRId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Updated Successfully";
        //            //log.add_Update("Delivery Details", "62");

        //        }
        //        return _returnStringMessage;
        //    }
        //    public string DailyReportDet_Save()
        //    {
        //        this.DRDetId = AutoGenMaxId("[YANTRA_DAILY_REPORT_DET]", "DAILYREPORTDET_ID");
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT  INTO [YANTRA_DAILY_REPORT_DET] VALUES({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}',{8})", this.DRId, this.DRDetId, this.DetCustName, this.DetPurpose, this.DetRemarks, this.DetComments, this.DRDetDate, this.DetReference, this.CommentedBy);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Saved Successfully";

        //        }
        //        return _returnStringMessage;
        //    }
        //    //public string PaymentsReceived_Update()
        //    //{
        //    //    if (dbManager.Transaction == null)
        //    //        dbManager.Open();
        //    //    _commandText = string.Format("UPDATE [YANTRA_PAYMENTS_RECEIVED] SET PR_NO='{0}',PR_DATE='{1}',CUST_ID={2},UNIT_ID={3},SI_ID={4},SI_AMOUNT='{5}',PR_AMT_RECEIVED='{6}',PR_PAYMODE_TYPE='{7}',PR_CHEQUE_NO='{8}',PR_CHEQUE_DATE='{9}',PR_CASH_RECEIVED_DATE='{10}',PR_BANK_DETAILS='{11}',PR_PREPARED_BY='{12}',PR_APPROVED_BY='{13}',PR_PAYMENT_STATUS='{14}',SO_ID={15},SPO_ID={16}  WHERE PR_ID={17}", this.PRNo, Convert.ToDateTime(this.PRDate), this.CustId, this.UnitId, this.SIId, this.SIAmt, this.PRReceivedAmt, this.PRPaymodeType, this.PRChequeNo, Convert.ToDateTime(this.PRChequeDate), Convert.ToDateTime(this.PRCahReceivedDate), this.PRBankDetails, this.PRPreparedBy, this.PRApprovedBy, this.PRPaymentStatus, this.SO_Id, this.SPOId, this.PRId);
        //    //    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //    //    _returnStringMessage = string.Empty;
        //    //    if (_returnIntValue < 0 || _returnIntValue == 0)
        //    //    {
        //    //        _returnStringMessage = "Some Data Missing.";
        //    //    }
        //    //   else if (_returnIntValue > 0)
        //    //    {
        //    //        _returnStringMessage = "Data Updated Successfully";
        //    //    }
        //    //    return _returnStringMessage;
        //    //}

        //    //public string PaymentsReceived_Delete(string PaymentsReceivedId)
        //    //{
        //    //    if (DeleteRecord("[YANTRA_PAYMENTS_RECEIVED]", "PR_ID", PaymentsReceivedId) == true)
        //    //    {
        //    //        _returnStringMessage = "Data Deleted Successfully";
        //    //    }
        //    //    else
        //    //    {
        //    //        _returnStringMessage = "Some Data Missing.";
        //    //    }

        //    //    return _returnStringMessage;
        //    //}



        //    //public int PaymentsReceived_Select(string PaymentsReceivedId)
        //    //{
        //    //    if (dbManager.Transaction == null)
        //    //        dbManager.Open();

        //    //    _commandText = string.Format("SELECT * FROM [YANTRA_PAYMENTS_RECEIVED],[YANTRA_CUSTOMER_MAST],[YANTRA_CUSTOMER_UNITS],YANTRA_SO_MAST" +
        //    //                                                            " WHERE [YANTRA_PAYMENTS_RECEIVED].CUST_ID=[YANTRA_CUSTOMER_MAST].CUST_ID " +
        //    //                                                            " AND [YANTRA_PAYMENTS_RECEIVED].UNIT_ID=[YANTRA_CUSTOMER_UNITS].CUST_UNIT_ID " +
        //    //        //" AND [YANTRA_PAYMENTS_RECEIVED].SI_ID=[YANTRA_SALES_INVOICE_MAST].SI_ID  " +
        //    //                                                             " AND [YANTRA_PAYMENTS_RECEIVED].SO_ID=[YANTRA_SO_MAST].SO_ID  " +
        //    //                                                            " AND [YANTRA_PAYMENTS_RECEIVED].PR_ID='" + PaymentsReceivedId + "' ORDER BY [YANTRA_PAYMENTS_RECEIVED].PR_ID DESC ");

        //    //    dbManager.ExecuteReader(CommandType.Text, _commandText);
        //    //    if (dbManager.DataReader.Read())
        //    //    {
        //    //        this.PRId = dbManager.DataReader["PR_ID"].ToString();
        //    //        this.PRNo = dbManager.DataReader["PR_NO"].ToString();
        //    //        this.PRDate = Convert.ToDateTime(dbManager.DataReader["PR_DATE"].ToString()).ToString("dd/MM/yyyy");
        //    //        this.CustId = dbManager.DataReader["CUST_ID"].ToString();
        //    //        this.UnitId = dbManager.DataReader["UNIT_ID"].ToString();
        //    //        this.SO_Id = dbManager.DataReader["SO_ID"].ToString();
        //    //        this.SPOId = dbManager.DataReader["SPO_ID"].ToString();
        //    //        this.SIId = dbManager.DataReader["SI_ID"].ToString();
        //    //        this.SIAmt = dbManager.DataReader["SI_AMOUNT"].ToString();
        //    //        this.PRReceivedAmt = dbManager.DataReader["PR_AMT_RECEIVED"].ToString();
        //    //        this.PRPaymodeType = dbManager.DataReader["PR_PAYMODE_TYPE"].ToString();
        //    //        this.PRChequeNo = dbManager.DataReader["PR_CHEQUE_NO"].ToString();
        //    //        this.PRChequeDate = Convert.ToDateTime(dbManager.DataReader["PR_CHEQUE_DATE"].ToString()).ToString("dd/MM/yyyy");
        //    //        this.PRCahReceivedDate = Convert.ToDateTime(dbManager.DataReader["PR_CASH_RECEIVED_DATE"].ToString()).ToString("dd/MM/yyyy");
        //    //        this.PRBankDetails = dbManager.DataReader["PR_BANK_DETAILS"].ToString();
        //    //        this.PRPreparedBy = dbManager.DataReader["PR_PREPARED_BY"].ToString();
        //    //        this.PRApprovedBy = dbManager.DataReader["PR_APPROVED_BY"].ToString();
        //    //        this.PRPaymentStatus = dbManager.DataReader["PR_PAYMENT_STATUS"].ToString();

        //    //        _returnIntValue = 1;
        //    //    }
        //    //    else
        //    //    {
        //    //        _returnIntValue = 0;
        //    //    }
        //    //    return _returnIntValue;
        //    //}


        //}





        //Method CreditNote






        public class DashBoradPurchase
        {
            public string Id, SoId, ConfirmationDate, ShopActual, ShopReceived, MaterialLocal_Actual, MaterialLocal_Received, MaterialGreece_actual, MaterialGreece_Received, Glassorder_actual, Glassorder_Reveived, Fabrication_actual, Fabrication_Recived, Installation_actual, Installation_Received, Remarks,Status;

            public DashBoradPurchase()
            { }

            public static string DashBoradPurchase_AutoGenCode()
            {
                return AutoGenMaxNo("DashBoard_Purchase", "PurDash_Id");
            }

            public string DashBoradPurchase_Save()
            {
                try
                {
                    dbManager.Open();

                    _commandText = string.Format("INSERT INTO [DashBoard_Purchase] SELECT ISNULL(MAX(PurDash_Id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}' FROM [DashBoard_Purchase]", this.SoId, this.ConfirmationDate, this.ShopActual, this.ShopReceived, this.MaterialLocal_Actual, this.MaterialLocal_Received, this.MaterialGreece_actual, this.MaterialGreece_Received, this.Glassorder_actual, this.Glassorder_Reveived, this.Fabrication_actual, this.Fabrication_Recived, this.Installation_actual, this.Installation_Received, this.Remarks,this.Status);
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        _returnStringMessage = "Data Saved Successfully";
                    }

                    return _returnStringMessage;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    dbManager.Dispose();
                }
            }

            public string DashBoradPurchase_Update()
            {
                dbManager.Open();

                _commandText = string.Format("UPDATE [DashBoard_Purchase] SET So_Id={0},Confirmation_Date='{1}',ShopDrawing_Actual='{2}',ShopDrawing_Received ='{3}',MaterialOrder_local_Actual='{4}',MaterialOrder_Local_Received='{5}',MaterialOrder_Greece_Actual='{6}',MaterialOrder_Greece_Received='{7}',GlassOrder_Actual='{8}',Glassorder_Received='{9}',Fabrication_Actual='{10}',Fabrication_Started='{11}',Installation_Actual='{12}',Installation_Received='{13}',Remarks='{14}',Status='{15}'  WHERE So_Id={0}", this.SoId, this.ConfirmationDate, this.ShopActual, this.ShopReceived, this.MaterialLocal_Actual, this.MaterialLocal_Received, this.MaterialGreece_actual, this.MaterialGreece_Received, this.Glassorder_actual, this.Glassorder_Reveived, this.Fabrication_actual, this.Fabrication_Recived, this.Installation_actual, this.Installation_Received, this.Remarks, this.Status);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Updated Successfully";
                }

                return _returnStringMessage;
            }

            public string DashBoradPurchase_Delete(string delid)
            {
                string delid1 = delid;
                if (DeleteRecord("[DashBoard_Purchase]", "PurDash_Id", delid1) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }



            public int DashBoradPurchase_Select(string STId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [DashBoard_Purchase] WHERE So_Id = " + STId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SoId = dbManager.DataReader["So_Id"].ToString();
                    this.ConfirmationDate = Convert.ToDateTime(dbManager.DataReader["Confirmation_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    this.ShopActual = Convert.ToDateTime(dbManager.DataReader["ShopDrawing_Actual"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.ShopReceived = Convert.ToDateTime(dbManager.DataReader["ShopDrawing_Received"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.MaterialLocal_Actual = Convert.ToDateTime(dbManager.DataReader["MaterialOrder_local_Actual"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.MaterialLocal_Received = Convert.ToDateTime(dbManager.DataReader["MaterialOrder_Local_Received"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    this.MaterialGreece_actual = Convert.ToDateTime(dbManager.DataReader["MaterialOrder_Greece_Actual"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.MaterialGreece_Received = Convert.ToDateTime(dbManager.DataReader["MaterialOrder_Greece_Received"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Glassorder_actual = Convert.ToDateTime(dbManager.DataReader["GlassOrder_Actual"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Glassorder_Reveived = Convert.ToDateTime(dbManager.DataReader["Glassorder_Received"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    this.Fabrication_actual = Convert.ToDateTime(dbManager.DataReader["Fabrication_Actual"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Fabrication_Recived = Convert.ToDateTime(dbManager.DataReader["Fabrication_Started"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Installation_actual = Convert.ToDateTime(dbManager.DataReader["Installation_Actual"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Installation_Received = Convert.ToDateTime(dbManager.DataReader["Installation_Received"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
        }


    }
}