
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
using System.Globalization;
using phani;
using phaniDAL;



/// <summary>
/// Summary description for SCM
/// </summary>
/// 

namespace Phani.Modules
{
    public class SCM
    {
        private static int _returnIntValue;
        private static string _returnStringMessage, _commandText;

        static DBManager dbManager = new DBManager(DataProvider.SqlServer, DBConString.ConnectionString());

        public SCM()
        { }

        //Method for dispose 
        public static void Dispose()
        {
            dbManager.Dispose();
        }

        //Method for BeginTransaction 
        public static void BeginTransaction()
        {
            dbManager.Open();
            dbManager.BeginTransaction();
        }

        //Method for CommitTransaction 
        public static void CommitTransaction()
        {
            dbManager.CommitTransaction();
        }

        //Method for RollBackTransaction 
        public static void RollBackTransaction()
        {
            dbManager.RollBackTransaction();
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


        private static bool IsRecordExists(string paraTableName, string paraFirstFieldName, string paraFirstFieldValue, string paraSecondFieldName, string paraSecondFieldValue, string paraThirdFieldName, string paraThirdFieldValue, string paraFourthFieldName, string paraFourthFieldValue)
        {
            bool check = false;
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT COUNT(*) FROM " + paraTableName + " WHERE " + paraFirstFieldName + "='" + paraFirstFieldValue + "' and " + paraSecondFieldName + "='" + paraSecondFieldValue + "'  and " + paraThirdFieldName + "='" + paraThirdFieldValue + "'  and " + paraFourthFieldName + "='" + paraFourthFieldValue + "'   ").ToString());
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

        private static bool IsRecordExists(string paraTableName, string paraFirstFieldName, string paraFirstFieldValue, string paraSecondFieldName, string paraSecondFieldValue, string paraThirdFieldName, string paraThirdFieldValue, string paraFourthFieldName, string paraFourthFieldValue, string parafifthFieldName, string paraFifthFieldValue)
        {
            bool check = false;
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT COUNT(*) FROM " + paraTableName + " WHERE " + paraFirstFieldName + "='" + paraFirstFieldValue + "' and " + paraSecondFieldName + "='" + paraSecondFieldValue + "'  and " + paraThirdFieldName + "='" + paraThirdFieldValue + "'  and " + paraFourthFieldName + "='" + paraFourthFieldValue + "' and " + parafifthFieldName + "='" + paraFifthFieldValue + "'   ").ToString());
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



        private static bool IsRecordExists(string paraTableName, string paraFirstFieldName, string paraFirstFieldValue, string paraSecondFieldName, string paraSecondFieldValue, string paraThirdFieldName, string paraThirdFieldValue)
        {
            bool check = false;
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT COUNT(*) FROM " + paraTableName + " WHERE " + paraFirstFieldName + "='" + paraFirstFieldValue + "' and " + paraSecondFieldName + "='" + paraSecondFieldValue + "'  and " + paraThirdFieldName + "='" + paraThirdFieldValue + "'").ToString());
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
            if (dbManager.Transaction == null)
                dbManager.Open();
            _returnIntValue = int.Parse(dbManager.ExecuteNonQuery(CommandType.Text, "DELETE FROM " + paraTableName + " WHERE " + paraFieldName + "='" + paraFieldValue + "'").ToString());
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

        //Method for Auto Generate Max Serial NO
        public static string AutoGenMaxNo(string TableName, string FieldName)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = "SELECT ISNULL(MAX(CONVERT(BIGINT,SUBSTRING(SUBSTRING(" + FieldName + ",0,LEN(" + FieldName + ")-5),CHARINDEX('-'," + FieldName + ")+1,LEN(SUBSTRING(" + FieldName + ",0,LEN(" + FieldName + ")-5))))),0)+1 FROM " + TableName + " WHERE SUBSTRING(" + FieldName + ",LEN(" + FieldName + ")-4,5)='" + CurrentFinancialYear() + "'";
            string numb = dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString();
            return Prefix(TableName) + "-" + numb + "/" + CurrentFinancialYear();
            // return Prefix(TableName) + "/" + CurrentFinancialYear() + "/" + numb;
        }

        public static string Prefix(string TableName)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _returnStringMessage = dbManager.ExecuteScalar(CommandType.Text, "SELECT " + phani.Classes.General.GetRequiredPrefix(TableName) + " FROM Code_Prefix").ToString();
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

        //Method for clearing Textbox and Dropdown list and Listbox
        public static void ClearControls(Control Parent)
        {
            if (Parent is TextBox)
                (Parent as TextBox).Text = string.Empty;
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
            ddl.Items.Add(new ListItem("--", "0"));
            while (dbManager.DataReader.Read())
            {
                ddl.Items.Add(new ListItem(dbManager.DataReader[DataTextField].ToString(), dbManager.DataReader[DataValueField].ToString()));
            }
            dbManager.DataReader.Close();
        }

        //Method for GridBind Fill
        private static void GridViewBind(GridView gv)
        {
            gv.DataSource = dbManager.DataReader;
            gv.DataBind();
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

        //Method for Supplier Master Form
        public class SuppliersMaster
        {
            public string SupId, SupName, SupContactPerson, SupAddress, SupContactPersonDetails, SupPhone, SupMobile, SupEmail, SupFaxNo, SupPanNo, SupCstNo, SupVatNo, SupGstNo, Countryid,Catid,Title; // Suppliers Master

            public SuppliersMaster()
            { }

            public string SuppliersMaster_Save()
            {
               
                    dbManager.Open();
                if (IsRecordExists("Supplier_Master", "SUP_NAME", this.SupName) == false)
                {
                    this.SupId = AutoGenMaxId("Supplier_Master", "SUP_ID");
                    _commandText = string.Format("INSERT INTO Supplier_Master SELECT ISNULL(MAX(SUP_ID),0)+1,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},{13},'{14}' FROM [Supplier_Master]", this.SupName, this.SupContactPerson, this.SupAddress, this.SupContactPersonDetails, this.SupPhone, this.SupMobile, this.SupEmail, this.SupFaxNo, this.SupPanNo, this.SupCstNo, this.SupVatNo, this.SupGstNo, this.Countryid, this.Catid,this.Title);
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

            public string SuppliersMaster_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //if (IsRecordExists("[Supplier_Master]", "SUP_NAME", this.SupName) == false)
                //{
                    _commandText = string.Format("UPDATE [Supplier_Master] SET SUP_NAME='{0}',SUP_CONTACT_PERSON='{1}',SUP_ADDRESS='{2}',SUP_CONTACT_PER_DET='{3}',SUP_PHONE='{4}',SUP_MOBILE='{5}',SUP_EMAIL='{6}',SUP_FAXNO='{7}',SUP_PANNO='{8}',SUP_CSTNO='{9}',SUP_VATNO='{10}',SUP_GSTNO='{11}',COUNTRY_ID={12},CAT_ID={13},TITLE='{14}' WHERE SUP_ID={15}", this.SupName, this.SupContactPerson, this.SupAddress, this.SupContactPersonDetails, this.SupPhone, this.SupMobile, this.SupEmail, this.SupFaxNo, this.SupPanNo, this.SupCstNo, this.SupVatNo, this.SupGstNo, this.Countryid, this.Catid,this.Title, this.SupId);
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
                //}
                //else
                //{
                //    _returnStringMessage = "Supplier Already Exists.";
                //}
                return _returnStringMessage;
            }

            public string SuppliersMaster_Delete()
            {
               

                if (DeleteRecord("[Supplier_Master]", "SUP_ID", this.SupId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                        
                    }
                    else
                    {
                       
                    }
               
                return _returnStringMessage;
            }

            public static void SuppliersMaster_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("select SUP_NAME,SUP_ID from Supplier_Master where SUP_ID != '0' ORDER BY SUP_NAME");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "SUP_NAME", "SUP_ID");
                }
            }

           public string CountryName,Currency;
            public int SuppliersMaster_Select(string SupplierId)
            {
                try
                {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("SELECT * FROM [Supplier_Master],Country_Master WHERE Supplier_Master.COUNTRY_ID = Country_Master.COUNTRY_ID and SUP_ID = " + SupplierId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SupId = dbManager.DataReader["SUP_ID"].ToString();
                    this.SupName = dbManager.DataReader["SUP_NAME"].ToString();
                    this.SupContactPerson = dbManager.DataReader["SUP_CONTACT_PERSON"].ToString();
                    this.SupAddress = dbManager.DataReader["SUP_ADDRESS"].ToString();
                    this.SupContactPersonDetails = dbManager.DataReader["SUP_CONTACT_PER_DET"].ToString();
                    this.SupPhone = dbManager.DataReader["SUP_PHONE"].ToString();
                    this.SupMobile = dbManager.DataReader["SUP_MOBILE"].ToString();
                    this.SupEmail = dbManager.DataReader["SUP_EMAIL"].ToString();
                    this.SupFaxNo = dbManager.DataReader["SUP_FAXNO"].ToString();
                    this.SupPanNo = dbManager.DataReader["SUP_PANNO"].ToString();
                    this.SupCstNo = dbManager.DataReader["SUP_CSTNO"].ToString();
                    this.SupVatNo = dbManager.DataReader["SUP_VATNO"].ToString();
                    this.SupGstNo = dbManager.DataReader["SUP_GSTNO"].ToString();
                    this.Countryid = dbManager.DataReader["COUNTRY_ID"].ToString();
                    this.Catid = dbManager.DataReader["CAT_ID"].ToString();
                    this.Title = dbManager.DataReader["TITLE"].ToString();
                    this.CountryName = dbManager.DataReader["COUNTRY_NAME"].ToString();
                    this.Currency = dbManager.DataReader["CURRENCY"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

                finally
                {
                    dbManager.Close();
                }
            }
            

                   

        }



        //Methods for Indent
        public class Indent
        {
            public string INDId, INDNo, INDDate, DeptId, FollowUp, INDPreparedBy, INDApprovedBy,CustId;
            public string INDDetId,MatId,Length,Description,Color,Qty,kgpermt,totalweight,aluminumcoating,amount,ColorId;

            public Indent()
            {
            }

            public static string Indent_AutoGenCode()
            {
                return AutoGenMaxNo("Indent_Master", "Indent_No");
            }
            public string Indent_Save()
            {
                this.INDNo = AutoGenMaxNo("Indent_Master", "Indent_No");
                this.INDId = AutoGenMaxId("[Indent_Master]", "Indent_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Indent_Master] VALUES({0},'{1}','{2}',{3},{4},{5},{6})", this.INDId, this.INDNo, this.INDDate, this.DeptId, this.FollowUp, this.INDPreparedBy, this.INDApprovedBy);
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

            public string Indent_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Indent_Master] SET  Indent_Date='{0}',Dept_Id={1},FollowUp_Id={2},PreparedBy={3},ApprovedBy={4} WHERE IND_ID={5}", this.INDDate, this.DeptId, this.FollowUp, this.INDPreparedBy, this.INDApprovedBy,this.INDId);
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

            public string Indent_Delete(string IndentId)
            {
                if (DeleteRecord("[Indent_Details]", "Indent_Id", IndentId) == true)
                {
                    if (DeleteRecord("[Indent_Master]", "Indent_Id", IndentId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string IndentDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Indent_Details] SELECT ISNULL(MAX(Ind_det_Id),0)+1,{0},{1},'{2}','{3}','{4}',{5},{6},{7},'{8}','{9}','{10}',{11} FROM [Indent_Details]", this.INDId, this.MatId, this.Length, this.Description, this.Color, this.Qty, this.CustId,this.kgpermt,this.totalweight,this.aluminumcoating,this.amount,this.ColorId);
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

            public int IndentDetails_Delete(string IndentId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Indent_Details] WHERE Indent_Id={0}", IndentId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int Indent_Select(string IndentId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Indent_Master],[Department_Master] WHERE [Indent_Master].Dept_Id=[Department_Master].DEPT_ID AND [Indent_Master].Indent_Id='" + IndentId + "' ORDER BY [Indent_Master].Indent_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.INDId = dbManager.DataReader["Indent_Id"].ToString();
                    this.INDNo = dbManager.DataReader["Indent_No"].ToString();
                    this.INDDate = Convert.ToDateTime(dbManager.DataReader["Indent_Date"].ToString()).ToString("dd/MM/yyyy",CultureInfo.InvariantCulture);
                    this.DeptId = dbManager.DataReader["Dept_Id"].ToString();
                    this.FollowUp = dbManager.DataReader["FollowUp_Id"].ToString();
                    this.INDPreparedBy = dbManager.DataReader["PreparedBy"].ToString();
                    this.INDApprovedBy = dbManager.DataReader["ApprovedBy"].ToString();
                    

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void IndentDetails_Select(string IndentId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Indent_Details],[Material_Master],Customer_Master WHERE [Indent_Details].Mat_Id=[Material_Master].Material_Id and Indent_Details.Cust_Id = Customer_Master.CUST_ID  AND [Indent_Details].Indent_Id=" + IndentId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable IndentProducts = new DataTable();
                DataColumn col = new DataColumn();

                col = new DataColumn("Series");
                IndentProducts.Columns.Add(col);
                col = new DataColumn("Length");
                IndentProducts.Columns.Add(col);
                col = new DataColumn("Description");
                IndentProducts.Columns.Add(col);
                col = new DataColumn("Color");
                IndentProducts.Columns.Add(col);
                col = new DataColumn("Qty");
                IndentProducts.Columns.Add(col);
                col = new DataColumn("CustomerName");
                IndentProducts.Columns.Add(col);
                col = new DataColumn("CustId");
                IndentProducts.Columns.Add(col);
                col = new DataColumn("SeriesId");
                IndentProducts.Columns.Add(col);
              
                col = new DataColumn("Kgpermtr");
                IndentProducts.Columns.Add(col);
                col = new DataColumn("TotalWeight");
                IndentProducts.Columns.Add(col);
                col = new DataColumn("AlumiumCoating");
                IndentProducts.Columns.Add(col);
                col = new DataColumn("Amount");
                IndentProducts.Columns.Add(col);
                col = new DataColumn("ColorId");
                IndentProducts.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = IndentProducts.NewRow();
                    dr["Series"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Color"] = dbManager.DataReader["Color"].ToString();
                    dr["Qty"] = dbManager.DataReader["Qty"].ToString();
                    dr["CustomerName"] = dbManager.DataReader["CUST_NAME"].ToString();
                    dr["CustId"] = dbManager.DataReader["Cust_Id"].ToString();
                    dr["SeriesId"] = dbManager.DataReader["Mat_Id"].ToString();
                    dr["Kgpermtr"] = dbManager.DataReader["KGpermt"].ToString();
                    dr["TotalWeight"] = dbManager.DataReader["TotalWeight"].ToString();
                    dr["AlumiumCoating"] = dbManager.DataReader["aluminiumcoating"].ToString();
                    dr["Amount"] = dbManager.DataReader["Totalamount"].ToString();

                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                   

                    IndentProducts.Rows.Add(dr);
                }

                gv.DataSource = IndentProducts;
                gv.DataBind();
            }

            public static void Indent_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Indent_Master] ORDER BY Indent_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Indent_No", "Indent_Id");
                }
            }






         

        }


        //Methods for MaterialRequest
        public class MaterialRequest
        {
            public string MreqId, MRno, RequiredDate, ReqType, Requestedfor, Mrdate, Termsconditonsid, Preparedby, Status,Somainid;
            public string Mrdetid, Itemcode, Quantity, ItemReqDate, WarehouseId, ColorId,Itemrequestedfor,SoId,Somatid,ReqQty;

            public MaterialRequest()
            {
            }

            public static string MaterialRequest_AutoGenCode()
            {
                return AutoGenMaxNo("MaterialRequest", "MaterialRequest_No");
            }
            public string MaterialRequest_Save()
            {
                this.MRno = AutoGenMaxNo("MaterialRequest", "MaterialRequest_No");
                this.MreqId = AutoGenMaxId("[MaterialRequest]", "MaterialRequest_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [MaterialRequest] VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}',{9})", this.MreqId, this.MRno, this.RequiredDate, this.ReqType, this.Requestedfor, this.Mrdate, this.Termsconditonsid, this.Preparedby, this.Status,this.Somainid);
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

            public string MaterialRequest_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [MaterialRequest] SET  MaterialRequest_No='{0}',Required_Date='{1}',Request_Type='{2}',Requested_For='{3}',Requested_Date='{4}',TermsConditions_Id='{5}',Prepared_By={6},Status='{7}' WHERE MaterialRequest_Id={8}", this.MRno, this.RequiredDate, this.ReqType, this.Requestedfor, this.Mrdate, this.Termsconditonsid, this.Preparedby, this.Status, this.MreqId);
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

            public string MaterialRequest_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[MaterialRequest_Details]", "Mreq_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[MaterialRequest]", "MaterialRequest_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string Length;
            public string MaterialRequestDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [MaterialRequest_Details] SELECT ISNULL(MAX(Mreq_Det_Id),0)+1,{0},{1},'{2}','{3}',{4},{5},'{6}',{7},{8},'{9}',{10} FROM [MaterialRequest_Details]", this.MreqId, this.Itemcode, this.Quantity, this.ItemReqDate, this.WarehouseId, this.ColorId,this.Itemrequestedfor,this.SoId,this.Somatid,this.ReqQty,this.Length);
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

            public int MaterialRequestDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [MaterialRequest_Details] WHERE Mreq_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int MaterialRequest_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [MaterialRequest] WHERE  [MaterialRequest].MaterialRequest_Id='" + MaterialRequestId + "' ORDER BY [MaterialRequest].MaterialRequest_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.MreqId = dbManager.DataReader["MaterialRequest_Id"].ToString();
                    this.MRno = dbManager.DataReader["MaterialRequest_No"].ToString();
                    this.RequiredDate = Convert.ToDateTime(dbManager.DataReader["Required_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Mrdate = Convert.ToDateTime(dbManager.DataReader["Requested_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    this.ReqType = dbManager.DataReader["Request_Type"].ToString();
                    this.Requestedfor = dbManager.DataReader["Requested_For"].ToString();
                    this.Preparedby = dbManager.DataReader["Prepared_By"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();
                    this.SoId = dbManager.DataReader["SO_Id"].ToString();
                    this.Termsconditonsid = dbManager.DataReader["TermsConditions_Id"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }





            public int MaterialRequestSo_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [MaterialRequest] WHERE  [MaterialRequest].SO_Id='" + MaterialRequestId + "' ORDER BY [MaterialRequest].MaterialRequest_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.MreqId = dbManager.DataReader["MaterialRequest_Id"].ToString();
                    this.MRno = dbManager.DataReader["MaterialRequest_No"].ToString();
                    this.RequiredDate = Convert.ToDateTime(dbManager.DataReader["Required_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Mrdate = Convert.ToDateTime(dbManager.DataReader["Requested_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    this.ReqType = dbManager.DataReader["Request_Type"].ToString();
                    this.Requestedfor = dbManager.DataReader["Requested_For"].ToString();
                    this.Preparedby = dbManager.DataReader["Prepared_By"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();
                    this.Somainid = dbManager.DataReader["SO_Id"].ToString();
                    this.Termsconditonsid = dbManager.DataReader["TermsConditions_Id"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }




            public void MaterialRequestDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [MaterialRequest_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [MaterialRequest_Details].Item_Code=[Material_Master].Material_Id  and MaterialRequest_Details.Color_Id = Color_Master.Color_Id   AND [MaterialRequest_Details].Mreq_Id='" + MaterialRequestId +"' order by Mreq_Det_Id asc");

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                //col = new DataColumn("Warehouse");
                //SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Requireddate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Requestfor");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoMatId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("RequiredQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("PU");
                SalesOrderItems.Columns.Add(col);


                col = new DataColumn("IndId");
                SalesOrderItems.Columns.Add(col);



                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Item_Series"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Qty"] = dbManager.DataReader["Quantity"].ToString();
                  //  dr["Warehouse"] = dbManager.DataReader["StorageLocation_Name"].ToString();
                    dr["Requireddate"] = Convert.ToDateTime(dbManager.DataReader["Req_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dr["Requestfor"] = dbManager.DataReader["RequestedFor"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["SoMatId"] = dbManager.DataReader["SoMat_Id"].ToString();
                    dr["RequiredQty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();
                    dr["PU"] = dbManager.DataReader["Box_Size"].ToString();


                    dr["IndId"] = dbManager.DataReader["Mreq_Det_Id"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }




            public void MaterialRequestDetailsforquatation_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [MaterialRequest_Details],[Material_Master],Color_Master,StorageLocation_Master,Uom_Master WHERE [MaterialRequest_Details].Item_Code=[Material_Master].Material_Id and MaterialRequest_Details.warehouse_Id = StorageLocation_Master.StorageLoacation_Id and MaterialRequest_Details.Color_Id = Color_Master.Color_Id and  Material_Master.UOM_Id = Uom_Master.UOM_ID   AND [MaterialRequest_Details].Mreq_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();

                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Warehouse");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Requireddate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("WarehouseId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Requestfor");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("UOM");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Price");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Qty"] = dbManager.DataReader["Quantity"].ToString();
                    dr["Warehouse"] = dbManager.DataReader["StorageLocation_Name"].ToString();
                    dr["Requireddate"] = Convert.ToDateTime(dbManager.DataReader["Req_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["WarehouseId"] = dbManager.DataReader["warehouse_Id"].ToString();
                    dr["Requestfor"] = dbManager.DataReader["RequestedFor"].ToString();
                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();
                    dr["UOM"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Series"] = dbManager.DataReader["Series"].ToString();
                    dr["Price"] = dbManager.DataReader["SellingPrice"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }



     






            public static void MaterialRequest_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //_commandText = string.Format("SELECT MaterialRequest_Id,MaterialRequest_No+'('+CUST_UNIT_NAME+')' as MRno  FROM [MaterialRequest],[Sales_Order],Customer_Units where [MaterialRequest].SO_Id = [Sales_Order].SalesOrder_Id and [Sales_Order].CustSiteId = Customer_Units.CUST_UNIT_ID   ORDER BY MaterialRequest_Id");

                _commandText = string.Format("SELECT MaterialRequest_Id,MaterialRequest_No+'('+Requested_For+')' as MRno  FROM [MaterialRequest] ORDER BY MaterialRequest_Id desc");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "MRno", "MaterialRequest_Id");
                }
            }


            public static void MaterialRequestStatus_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //_commandText = string.Format("SELECT MaterialRequest_Id,MaterialRequest_No+'('+CUST_UNIT_NAME+')' as MRno  FROM [MaterialRequest],[Sales_Order],Customer_Units where [MaterialRequest].SO_Id = [Sales_Order].SalesOrder_Id and [Sales_Order].CustSiteId = Customer_Units.CUST_UNIT_ID   ORDER BY MaterialRequest_Id");

                _commandText = string.Format("SELECT MaterialRequest_Id,MaterialRequest_No+'('+Requested_For+')' as MRno  FROM [MaterialRequest] where Status != 'Closed'  ORDER BY MaterialRequest_Id desc");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "MRno", "MaterialRequest_Id");
                }
            }





        }




        //Methods for IndentApproval Details
        public class IndentApproval
        {
            public string IndappId, IndappNo, IndappDate, IndentId, TermsConditons, PreparedBy,ApprovedBy;
            public string Indappdetid, Itemcode, Quantity, ItemReqDate, WarehouseId, ColorId, Itemrequestedfor, SoId, Somatid, ReqQty, QtytoOrder, Remarks, BlockStock,IndId;
            public string PODocdate, PODocRemarks, PODocuments;
            public IndentApproval()
            {
            }

            public static string IndentApproval_AutoGenCode()
            {
                return AutoGenMaxNo("IndentApproval", "IndentApproval_No");
            }
            public string IndentApproval_Save()
            {
                this.IndappNo = AutoGenMaxNo("IndentApproval", "IndentApproval_No");
                this.IndappId = AutoGenMaxId("[IndentApproval]", "IndentApproval_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [IndentApproval] VALUES({0},'{1}','{2}',{3},'{4}',{5},{6})", this.IndappId, this.IndappNo, this.IndappDate, this.IndentId, this.TermsConditons, this.PreparedBy,this.ApprovedBy);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                _commandText = string.Format("UPDATE [MaterialRequest] SET Status = 'Open'  WHERE MaterialRequest_Id ={0}", this.IndentId);
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

            public string IndentApproval_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [IndentApproval] SET  IndentApproval_No='{0}',IndentApproval_Date='{1}',Indent_No={2},TermsConditions_Id='{3}',Prepared_By={4},ApprovedBy={5} WHERE IndentApproval_Id={6}", this.IndappNo, this.IndappDate, this.IndentId, this.TermsConditons, this.PreparedBy,this.ApprovedBy, this.IndappId);
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

            public string IndentApproval_Delete(string indappid)
            {
                if (DeleteRecord("[IndentApproval_Details]", "IndentApproval_Id", indappid) == true)
                {
                    if (DeleteRecord("[IndentApproval]", "IndentApproval_Id", indappid) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }




            public string IndentApproverRemarksStatus_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [IndentApproval_Details] SET Remarks='{0}' WHERE InApproval_Det_Id ={1} ", this.Remarks, this.Indappdetid);
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





            public string IndentAppvalApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [IndentApproval] SET ApprovedBy={0} WHERE IndentApproval_Id ={1}", this.ApprovedBy, this.IndappId);
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


            public string IndentAppvalApproveMaterial_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();


                _commandText = string.Format("UPDATE [MaterialRequest] SET Status = 'Closed' WHERE MaterialRequest_Id ={0}", this.IndId);
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

            public string Length;
          //  public string BlockStock;

            public string IndentApprovalDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [IndentApproval_Details] SELECT ISNULL(MAX(InApproval_Det_Id),0)+1,{0},{1},'{2}','{3}',{4},{5},'{6}',{7},{8},'{9}','{10}','{11}',{12},{13} FROM [IndentApproval_Details]", this.IndappId, this.Itemcode, this.Quantity, this.ItemReqDate, this.WarehouseId, this.ColorId, this.Itemrequestedfor, this.SoId, this.Somatid, this.ReqQty, this.QtytoOrder, this.Remarks,this.IndId,this.Length);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                //_commandText = string.Format("INSERT INTO [Stock_Block] SELECT ISNULL(MAX(BlockStock_Id),0)+1,{0},{1},{2},{3},{4},{5} FROM [Stock_Block]", this.SoId, this.Itemcode, this.BlockStock, this.ColorId, this.Somatid,this.IndappId);
                //_returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


               

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








            public int IndentApprovalDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [IndentApproval_Details] WHERE IndentApproval_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }


            public int IndentApprovalBlock_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Stock_Block] WHERE IndApp_Id = {0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }




            public int IndentApproval_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [IndentApproval] WHERE  [IndentApproval].IndentApproval_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.IndappId = dbManager.DataReader["IndentApproval_Id"].ToString();
                    this.IndappNo = dbManager.DataReader["IndentApproval_No"].ToString();
                    this.IndappDate = Convert.ToDateTime(dbManager.DataReader["IndentApproval_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.IndentId = dbManager.DataReader["Indent_No"].ToString();
                    this.TermsConditons = dbManager.DataReader["TermsConditions_Id"].ToString();
                    this.PreparedBy = dbManager.DataReader["Prepared_By"].ToString();
                    this.ApprovedBy = dbManager.DataReader["ApprovedBy"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }




            public int IndentApprovalIndid_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [IndentApproval] WHERE  [IndentApproval].Indent_No='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.IndappId = dbManager.DataReader["IndentApproval_Id"].ToString();
                    this.IndappNo = dbManager.DataReader["IndentApproval_No"].ToString();
                    this.IndappDate = Convert.ToDateTime(dbManager.DataReader["IndentApproval_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.IndentId = dbManager.DataReader["Indent_No"].ToString();
                    this.TermsConditons = dbManager.DataReader["TermsConditions_Id"].ToString();
                    this.PreparedBy = dbManager.DataReader["Prepared_By"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }





            public void IndentApprovalDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [IndentApproval_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [IndentApproval_Details].Item_Code=[Material_Master].Material_Id  and IndentApproval_Details.Color_Id = Color_Master.Color_Id   AND [IndentApproval_Details].IndentApproval_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                //col = new DataColumn("Warehouse");
                //SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Requireddate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Requestfor");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoMatId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("RequiredQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("PU");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("QtyinStock");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("qtyorder");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Item_Series"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Qty"] = dbManager.DataReader["Quantity"].ToString();
                    //  dr["Warehouse"] = dbManager.DataReader["StorageLocation_Name"].ToString();
                    dr["Requireddate"] = Convert.ToDateTime(dbManager.DataReader["Req_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dr["Requestfor"] = dbManager.DataReader["RequestedFor"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["SoMatId"] = dbManager.DataReader["SoMat_Id"].ToString();
                    dr["RequiredQty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();
                    dr["PU"] = dbManager.DataReader["Box_Size"].ToString();
                    dr["QtyinStock"] = "";

                    dr["qtyorder"] = dbManager.DataReader["QtytoOrder"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }




            public void MaterialRequestDetailsforquatation_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [MaterialRequest_Details],[Material_Master],Color_Master,StorageLocation_Master,Uom_Master WHERE [MaterialRequest_Details].Item_Code=[Material_Master].Material_Id and MaterialRequest_Details.warehouse_Id = StorageLocation_Master.StorageLoacation_Id and MaterialRequest_Details.Color_Id = Color_Master.Color_Id and  Material_Master.UOM_Id = Uom_Master.UOM_ID   AND [MaterialRequest_Details].Mreq_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();

                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Warehouse");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Requireddate");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("WarehouseId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Requestfor");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("UOM");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Price");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Qty"] = dbManager.DataReader["Quantity"].ToString();
                    dr["Warehouse"] = dbManager.DataReader["StorageLocation_Name"].ToString();
                    dr["Requireddate"] = Convert.ToDateTime(dbManager.DataReader["Req_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["WarehouseId"] = dbManager.DataReader["warehouse_Id"].ToString();
                    dr["Requestfor"] = dbManager.DataReader["RequestedFor"].ToString();
                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();
                    dr["UOM"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Series"] = dbManager.DataReader["Series"].ToString();
                    dr["Price"] = dbManager.DataReader["SellingPrice"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }










            public static void IndentApproval_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //_commandText = string.Format("SELECT * FROM [IndentApproval] where ApprovedBy != '0' ORDER BY IndentApproval_Id desc");

                _commandText = string.Format("SELECT IndentApproval_Id,IndentApproval_No+'('+Requested_For+')' as inappno FROM [IndentApproval],[MaterialRequest] where [IndentApproval].Indent_No =[MaterialRequest].MaterialRequest_Id and   [IndentApproval].ApprovedBy != '0' ORDER BY IndentApproval_Id desc");
                
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "inappno", "IndentApproval_Id");
                }
            }



            public static void IndentApprovalStua_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //_commandText = string.Format("SELECT * FROM [IndentApproval] where ApprovedBy != '0' ORDER BY IndentApproval_Id desc");

                _commandText = string.Format("SELECT IndentApproval_Id,IndentApproval_No+'('+Requested_For+')' as inappno FROM [IndentApproval],[MaterialRequest] where [IndentApproval].Indent_No =[MaterialRequest].MaterialRequest_Id  ORDER BY IndentApproval_Id desc");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "inappno", "IndentApproval_Id");
                }
            }




            public string PODocuments_Details_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [IndentApproval_Docs] SELECT ISNULL(MAX(IA_Doc_Id),0)+1,'{0}','{1}','{2}',{3} FROM [IndentApproval_Docs]", this.PODocdate, this.PODocRemarks, this.PODocuments, this.IndappId);
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
                if (DeleteRecord("[IndentApproval_Docs]", "IA_Doc_Id", Eleid) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }

                return _returnStringMessage;
            }




        }






























        //Methods for Purchase Order
        public class SupplierPO
        {
            public string POId, PONo, PODate, INDID, SUPID, STATUS, NETAMOUNT, TermsConds, DespmId, PAYMENTTERMSID, CURRENCYID, DESTINATION, INSURANCE, FREIGHT, DISCOUNT, GST, PREPAREDBY, APPROVEDBY, CIF, FOB,TERMSOFDELIVERY;
            public string PODetId, MatId,Length,Description,Color,Qty,kgpermt,totalweight,aluminumcoating,amount,PoRecievedqty,PoRemainingQty,PoItemStatus,plantid,storagelocid,stocktypeid,custid,cOLORID;

            public SupplierPO()
            {
            }

            public static string SupplierPO_AutoGenCode()
            {
                return SCM.AutoGenMaxNo("Suplier_PurchaseOrder", "PO_NO");
            }

            public string SuppliersPO_Save()
            {
                this.PONo = SupplierPO_AutoGenCode();
                this.POId = AutoGenMaxId("[Suplier_PurchaseOrder]", "PO_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Suplier_PurchaseOrder] VALUES({0},'{1}','{2}',{3},{4},'{5}','{6}','{7}',{8},'{9}','{10}','{11}','{12}','{13}','{14}','{15}',{16},{17},'{18}','{19}','{20}') ", this.POId, this.PONo, this.PODate, this.INDID, this.SUPID, this.STATUS, this.NETAMOUNT, this.TermsConds, this.DespmId, this.PAYMENTTERMSID, this.CURRENCYID, this.DESTINATION, this.INSURANCE, this.FREIGHT, this.DISCOUNT, this.GST, this.PREPAREDBY, this.APPROVEDBY, this.CIF, this.FOB,this.TERMSOFDELIVERY);
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

            public string SuppliersPO_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Suplier_PurchaseOrder] SET PO_DATE='{0}',IND_ID={1}, SUP_ID={2}, PO_STATUS='{3}', NET_AMOUNT='{4}', TERMS_COND='{5}',DESPM_ID={6},PAYMENTTERMS_ID='{7}',CURRENCY_ID='{8}',PO_DESTINATION='{9}',PO_INSURANCE='{10}',PO_FREIGHT='{11}',PO_DISCOUNT='{12}',PO_TAXGST='{13}',PREPAREDBY={14},APPROVEDBY={15},FPO_CIF='{16}',FPO_FOB='{17}',TERMS_DELIVERY ='{18}'  WHERE PO_ID={19}", this.PODate, this.INDID, this.SUPID, this.STATUS, this.NETAMOUNT, this.TermsConds, this.DespmId, this.PAYMENTTERMSID, this.CURRENCYID, this.DESTINATION, this.INSURANCE, this.FREIGHT, this.DISCOUNT, this.GST, this.PREPAREDBY, this.APPROVEDBY, this.CIF, this.FOB,this.TERMSOFDELIVERY, this.POId);
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

            public string SuppliersPOApprove_Update(string ApprovedBy, string POId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Suplier_PurchaseOrder] SET APPROVEDBY={0}   WHERE PO_ID={1}", ApprovedBy, POId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Approved Successfully";
                }
                return _returnStringMessage;
            }

            public string SuppliersPOStatus_Update(string POStatus, string POId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Suplier_PurchaseOrder] SET PO_STATUS ='{0}'   WHERE PO_ID={1}", STATUS, POId);
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

            public string SuppliersPO_Delete(string SupFixedPOId)
            {
                if (DeleteRecord("[Supplier_PurchaseOrderDetails]", "PO_ID", SupFixedPOId) == true)
                {
                    if (DeleteRecord("[Suplier_PurchaseOrder]", "PO_ID", SupFixedPOId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public static void SuppliersPO_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Suplier_PurchaseOrder] ORDER BY PO_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "PO_NO", "PO_ID");
                }
            }
            public string Sname, SContact, Smobile;
           
            public int SuppliersPO_Select(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Suplier_PurchaseOrder],Supplier_Master WHERE Suplier_PurchaseOrder.SUP_ID = Supplier_Master.SUP_ID and  [Suplier_PurchaseOrder].PO_ID='" + SupFixedPOId + "' ORDER BY [Suplier_PurchaseOrder].PO_ID DESC ");
                              dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.POId = dbManager.DataReader["PO_ID"].ToString();
                    this.PONo = dbManager.DataReader["PO_NO"].ToString();
                    this.PODate = Convert.ToDateTime(dbManager.DataReader["PO_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.INDID = dbManager.DataReader["IND_ID"].ToString();
                    this.SUPID = dbManager.DataReader["SUP_ID"].ToString();
                    this.STATUS = dbManager.DataReader["PO_STATUS"].ToString();
                    this.NETAMOUNT = dbManager.DataReader["NET_AMOUNT"].ToString();
                    this.TermsConds = dbManager.DataReader["TERMS_COND"].ToString();
                    this.DespmId = dbManager.DataReader["DESPM_ID"].ToString();
                    this.PAYMENTTERMSID = dbManager.DataReader["PAYMENTTERMS_ID"].ToString();
                    this.CURRENCYID = dbManager.DataReader["CURRENCY_ID"].ToString();
                    this.DESTINATION = dbManager.DataReader["PO_DESTINATION"].ToString();
                    this.INSURANCE = dbManager.DataReader["PO_INSURANCE"].ToString();
                    this.FREIGHT = dbManager.DataReader["PO_FREIGHT"].ToString();
                    this.DISCOUNT = dbManager.DataReader["PO_DISCOUNT"].ToString();
                    this.GST = dbManager.DataReader["PO_TAXGST"].ToString();
                    this.PREPAREDBY = dbManager.DataReader["PREPAREDBY"].ToString();
                    this.APPROVEDBY = dbManager.DataReader["APPROVEDBY"].ToString();
                    this.CIF = dbManager.DataReader["FPO_CIF"].ToString();
                    this.FOB = dbManager.DataReader["FPO_FOB"].ToString();
                    this.TERMSOFDELIVERY = dbManager.DataReader["TERMS_DELIVERY"].ToString();

                    this.SContact = dbManager.DataReader["SUP_CONTACT_PERSON"].ToString();
                    this.Smobile = dbManager.DataReader["SUP_MOBILE"].ToString();
                    this.Sname = dbManager.DataReader["SUP_NAME"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }



            public int SuppliersPOQuataion_Select(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Suplier_PurchaseOrder],Supplier_Master WHERE Suplier_PurchaseOrder.SUP_ID = Supplier_Master.SUP_ID and  [Suplier_PurchaseOrder].PO_ID='" + SupFixedPOId + "' ORDER BY [Suplier_PurchaseOrder].PO_ID DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.POId = dbManager.DataReader["PO_ID"].ToString();
                    this.PONo = dbManager.DataReader["PO_NO"].ToString();
                    this.PODate = Convert.ToDateTime(dbManager.DataReader["PO_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.INDID = dbManager.DataReader["IND_ID"].ToString();
                    this.SUPID = dbManager.DataReader["SUP_ID"].ToString();
                    this.STATUS = dbManager.DataReader["PO_STATUS"].ToString();
                    this.NETAMOUNT = dbManager.DataReader["NET_AMOUNT"].ToString();
                    this.TermsConds = dbManager.DataReader["TERMS_COND"].ToString();
                    this.DespmId = dbManager.DataReader["DESPM_ID"].ToString();
                    this.PAYMENTTERMSID = dbManager.DataReader["PAYMENTTERMS_ID"].ToString();
                    this.CURRENCYID = dbManager.DataReader["CURRENCY_ID"].ToString();
                    this.DESTINATION = dbManager.DataReader["PO_DESTINATION"].ToString();
                    this.INSURANCE = dbManager.DataReader["PO_INSURANCE"].ToString();
                    this.FREIGHT = dbManager.DataReader["PO_FREIGHT"].ToString();
                    this.DISCOUNT = dbManager.DataReader["PO_DISCOUNT"].ToString();
                    this.GST = dbManager.DataReader["PO_TAXGST"].ToString();
                    this.PREPAREDBY = dbManager.DataReader["PREPAREDBY"].ToString();
                    this.APPROVEDBY = dbManager.DataReader["APPROVEDBY"].ToString();
                    this.CIF = dbManager.DataReader["FPO_CIF"].ToString();
                    this.FOB = dbManager.DataReader["FPO_FOB"].ToString();
                    this.TERMSOFDELIVERY = dbManager.DataReader["TERMS_DELIVERY"].ToString();

                    this.SContact = dbManager.DataReader["SUP_CONTACT_PERSON"].ToString();
                    this.Smobile = dbManager.DataReader["SUP_MOBILE"].ToString();
                    this.Sname = dbManager.DataReader["SUP_NAME"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }





          











            public string SuppliersPODetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Supplier_PurchaseOrderDetails] SELECT ISNULL(MAX(PO_DET_ID),0)+1,{0},{1},'{2}','{3}','{4}',{5},'{6}',{7},{8},{9},'{10}',{11},'{12}','{13}',{14},{15},{16},{17} FROM [Supplier_PurchaseOrderDetails]", this.POId, this.MatId, this.Length, this.Description, this.Color, this.Qty, this.amount,this.custid,this.PoRecievedqty,this.PoRemainingQty,this.PoItemStatus,this.kgpermt,this.totalweight,this.aluminumcoating,this.plantid,this.storagelocid,this.stocktypeid,this.cOLORID);
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

            public int SuppliersPODetails_Delete(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Supplier_PurchaseOrderDetails] WHERE PO_ID={0}", SupFixedPOId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public void SuppliersPODetails_Select(string SupFixedPOId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Supplier_PurchaseOrderDetails],Material_Master,Customer_Master WHERE [Supplier_PurchaseOrderDetails].MAT_ID=[Material_Master].Material_Id AND  Supplier_PurchaseOrderDetails.PO_CUSTID = Customer_Master.CUST_ID and [Supplier_PurchaseOrderDetails].PO_ID=" + SupFixedPOId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SuppliersFixedPOItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Series");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Description");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Length");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Color");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("SeriesID");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("CustomerName");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("CustId");
                SuppliersFixedPOItems.Columns.Add(col);
                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SuppliersFixedPOItems.NewRow();
                    dr["Series"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["PO_DET_DESCRIPTION"].ToString();
                    dr["Length"] = dbManager.DataReader["PO_DET_LENGTH"].ToString();
                    dr["Color"] = dbManager.DataReader["PO_DET_COLOR"].ToString();
                    dr["Qty"] = dbManager.DataReader["PO_DET_QTY"].ToString();
                    dr["Rate"] = dbManager.DataReader["PO_DET_RATE"].ToString();
                    dr["SeriesID"] = dbManager.DataReader["MAT_ID"].ToString();
                    dr["Amount"] = dbManager.DataReader["PO_DET_AMOUNT"].ToString();

                    dr["CustomerName"] = dbManager.DataReader["CUST_NAME"].ToString();
                    dr["CustId"] = dbManager.DataReader["PO_CUSTID"].ToString();


                    SuppliersFixedPOItems.Rows.Add(dr);
                }
                gv.DataSource = SuppliersFixedPOItems;
                gv.DataBind();
            }









            public void SuppliersPODetails1_Select(string SupFixedPOId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Supplier_PurchaseOrderDetails],Material_Master,Customer_Master WHERE [Supplier_PurchaseOrderDetails].MAT_ID=[Material_Master].Material_Id AND  Supplier_PurchaseOrderDetails.PO_CUSTID = Customer_Master.CUST_ID and [Supplier_PurchaseOrderDetails].PO_ID=" + SupFixedPOId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SuppliersFixedPOItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Series");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Length");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Description");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Color");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("CustomerName");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("CustId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("SeriesId");
                SuppliersFixedPOItems.Columns.Add(col);

                col = new DataColumn("Kgpermtr");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("TotalWeight");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("AlumiumCoating");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SuppliersFixedPOItems.Columns.Add(col);

                col = new DataColumn("ReceivedQty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("RemainingQty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("PlantId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("StorageLoc");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Stocktype");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("PoDetId");
                SuppliersFixedPOItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SuppliersFixedPOItems.NewRow();
                    dr["Series"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["PO_DET_DESCRIPTION"].ToString();
                    dr["Length"] = dbManager.DataReader["PO_DET_LENGTH"].ToString();
                    dr["Color"] = dbManager.DataReader["PO_DET_COLOR"].ToString();
                    dr["Qty"] = dbManager.DataReader["PO_DET_QTY"].ToString();
                  
                    dr["SeriesID"] = dbManager.DataReader["MAT_ID"].ToString();
                    dr["Amount"] = dbManager.DataReader["PO_DET_AMOUNT"].ToString();
                    dr["CustomerName"] = dbManager.DataReader["CUST_NAME"].ToString();
                    dr["CustId"] = dbManager.DataReader["PO_CUSTID"].ToString();

                    dr["ReceivedQty"] = dbManager.DataReader["PO_RECEIVED_QTY"].ToString();
                    dr["RemainingQty"] = dbManager.DataReader["PO_REMAINING_QTY"].ToString();

                    dr["Kgpermtr"] = dbManager.DataReader["KGPERMTR"].ToString();
                    dr["TotalWeight"] = dbManager.DataReader["TOTAL_WEIGHT"].ToString();
                    dr["AlumiumCoating"] = dbManager.DataReader["ALUMINIUMCOATING"].ToString();




                    dr["PlantId"] = dbManager.DataReader["PLANT_ID"].ToString();
                    dr["StorageLoc"] = dbManager.DataReader["STORAGELOC_ID"].ToString();
                    dr["Stocktype"] = dbManager.DataReader["STOCK_TYPE"].ToString();

                    dr["ColorId"] = dbManager.DataReader["COLOR_ID"].ToString();
                    dr["PoDetId"] = dbManager.DataReader["PO_DET_ID"].ToString();

                    SuppliersFixedPOItems.Rows.Add(dr);
                }
                gv.DataSource = SuppliersFixedPOItems;
                gv.DataBind();
            }





        }




        //Methods for Purchase Receipt

        //public class PurchaseReceipt
        //{
        //    public string SPrId, SPrNo,SPrDate,POid,Preparedby,approvedby,VehicalNo,Remarks,CheckedBy,Invoiceno,Invoicedate;

        //    public string Sprdetid, matid, length, color, orderedqty, cutid, receivedqty, plantid, storagelocid, stocktype, colorid,aCCEPTEDQTY,rEJECTEDQTY,itemremarks,BlockQty;
            

        //    public PurchaseReceipt()
        //    {
        //    }

        //    public static string PurchaseReceipt_AutoGenCode()
        //    {
        //        return SCM.AutoGenMaxNo("Supplier_PurchaseReceipt", "SPR_NO");
        //    }


        //    public string PurchaseReceipt_Save()
        //    {
        //        this.SPrNo = PurchaseReceipt_AutoGenCode();
        //        this.SPrId = AutoGenMaxId("[Supplier_PurchaseReceipt]", "SPR_ID");
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [Supplier_PurchaseReceipt] VALUES({0},'{1}','{2}',{3},{4},{5},'{6}','{7}',{8},'{9}','{10}') ", this.SPrId, this.SPrNo, this.SPrDate, this.POid, this.Preparedby, this.approvedby,this.VehicalNo,this.Remarks,this.CheckedBy,this.Invoiceno,this.Invoicedate);
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


        //    public string PurchaseReceipt_Update()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [Supplier_PurchaseReceipt] SET SPR_NO='{0}',SPR_DATE='{1}', SUP_PO_ID={2}, PREPAREDBY={3}, APPROVEDBY={4},Vehical_No='{5}',Remarks='{6}',Cheked_By='{7}',InvoiceNo='{8}',InvoiceDate='{9}' WHERE SPR_ID={10}", this.SPrNo, this.SPrDate, this.POid, this.Preparedby, this.approvedby,this.VehicalNo,this.Remarks,this.CheckedBy,this.Invoiceno,this.Invoicedate, this.SPrId);
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

        //    public string PurchaseReceiptApprove_Update(string ApprovedBy, string POId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("UPDATE [Supplier_PurchaseReceipt] SET APPROVEDBY={0}   WHERE SPR_ID={1}", ApprovedBy, SPrId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        _returnStringMessage = string.Empty;
        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        else if (_returnIntValue > 0)
        //        {
        //            _returnStringMessage = "Data Approved Successfully";
        //        }
        //        return _returnStringMessage;
        //    }


        //    public string PurchaseReceipt_Delete(string SupFixedPOId)
        //    {
        //        if (DeleteRecord("[Supplier_PurchaseReceipt_Details]", "SPR_ID", SupFixedPOId) == true)
        //        {
        //            if (DeleteRecord("[Supplier_PurchaseReceipt]", "SPR_ID", SupFixedPOId) == true)
        //            {
        //                _returnStringMessage = "Data Deleted Successfully";
        //            }
        //            else
        //            {
        //                _returnStringMessage = "Some Data Missing.";
        //            }
        //        }
        //        else
        //        {
        //            _returnStringMessage = "Some Data Missing.";
        //        }
        //        return _returnStringMessage;
        //    }

        //    public static void PurchaseReceipt_Select(Control ControlForBind)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM [Supplier_PurchaseReceipt] ORDER BY SPR_ID");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (ControlForBind is DropDownList)
        //        {
        //            DropDownListBind(ControlForBind as DropDownList, "SPR_NO", "SPR_ID");
        //        }
        //    }


        //    public int PurchaseReceipt_Select(string SupFixedPOId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM Supplier_PurchaseReceipt WHERE Supplier_PurchaseReceipt.SPR_ID ='" + SupFixedPOId + "' ORDER BY [Supplier_PurchaseReceipt].SPR_ID DESC ");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.SPrId = dbManager.DataReader["SPR_ID"].ToString();
        //            this.SPrNo = dbManager.DataReader["SPR_NO"].ToString();
        //            this.SPrDate = Convert.ToDateTime(dbManager.DataReader["SPR_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.POid = dbManager.DataReader["SUP_PO_ID"].ToString();
        //            this.Preparedby = dbManager.DataReader["PREPAREDBY"].ToString();
        //            this.approvedby = dbManager.DataReader["APPROVEDBY"].ToString();
        //            this.VehicalNo = dbManager.DataReader["Vehical_No"].ToString();
        //            this.Remarks = dbManager.DataReader["Remarks"].ToString();
        //            this.CheckedBy = dbManager.DataReader["Cheked_By"].ToString();


        //            this.Invoiceno = dbManager.DataReader["InvoiceNo"].ToString();
        //            this.Invoicedate = dbManager.DataReader["InvoiceDate"].ToString();

        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        return _returnIntValue;
        //    }







        //    public int PurchaseReceiptPO_Select(string SupFixedPOId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("SELECT * FROM Supplier_PurchaseReceipt WHERE Supplier_PurchaseReceipt.SUP_PO_ID ='" + SupFixedPOId + "' ORDER BY [Supplier_PurchaseReceipt].SPR_ID DESC ");
        //        dbManager.ExecuteReader(CommandType.Text, _commandText);
        //        if (dbManager.DataReader.Read())
        //        {
        //            this.SPrId = dbManager.DataReader["SPR_ID"].ToString();
        //            this.SPrNo = dbManager.DataReader["SPR_NO"].ToString();
        //            this.SPrDate = Convert.ToDateTime(dbManager.DataReader["SPR_DATE"].ToString()).ToString("dd/MM/yyyy");
        //            this.POid = dbManager.DataReader["SUP_PO_ID"].ToString();
        //            this.Preparedby = dbManager.DataReader["PREPAREDBY"].ToString();
        //            this.approvedby = dbManager.DataReader["APPROVEDBY"].ToString();
        //            this.VehicalNo = dbManager.DataReader["Vehical_No"].ToString();
        //            this.Remarks = dbManager.DataReader["Remarks"].ToString();
        //            this.CheckedBy = dbManager.DataReader["Cheked_By"].ToString();

        //            this.Invoiceno = dbManager.DataReader["InvoiceNo"].ToString();
        //            this.Invoicedate = dbManager.DataReader["InvoiceDate"].ToString();


        //            _returnIntValue = 1;
        //        }
        //        else
        //        {
        //            _returnIntValue = 0;
        //        }
        //        return _returnIntValue;
        //    }


        //    public string Instock,Soid,Description;


        //    public string PurchaseReceiptDetails_Save()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [Supplier_PurchaseReceipt_Details] SELECT ISNULL(MAX(SPR_DET_ID),0)+1,{0},{1},'{2}','{3}','{4}',{5},{6},{7},'{8}','{9}','{10}','{11}','{12}','{13}',{14} FROM [Supplier_PurchaseReceipt_Details]", this.SPrId, this.matid,   this.color, this.orderedqty, this.receivedqty, this.plantid, this.storagelocid,  this.colorid,this.aCCEPTEDQTY,this.rEJECTEDQTY,this.Instock,this.itemremarks,this.Soid,this.Description,this.length);
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


        //    public string podetid;
        //     public string PurchaseOrderDetailsRemainingQty_Update(string podetid,string receivedqty)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        //_commandText = string.Format("UPDATE [Supplier_Po_Details] SET  RemainingQty=CONVERT(BIGINT,RemainingQty)-{0} WHERE Sup_PO_Det_id={1} ", receivedqty, podetid);
        //        //_returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);



        //        _commandText = string.Format("UPDATE [Supplier_Po_Details] SET  RemainingQty= RemainingQty -'{0}' WHERE Sup_PO_Det_id={1} ", receivedqty, podetid);
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





        //    public int PurchaseReceiptDetails_Delete(string SupFixedPOId)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("DELETE FROM [Supplier_PurchaseReceipt_Details] WHERE SPR_ID = {0}", SupFixedPOId);
        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        return _returnIntValue;
        //    }


        //    public string QuoDocdate, QuoDocRemarks, QuoDocuments;
        //    public string MRNDocuments_Details_Save()
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        _commandText = string.Format("INSERT INTO [SupplierPO_Documents] SELECT ISNULL(MAX(PGR_Doc_Id),0)+1,'{0}','{1}','{2}',{3} FROM [SupplierPO_Documents]", this.QuoDocdate, this.QuoDocRemarks, this.QuoDocuments, this.SPrId);
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

        //    public string MRNDocumentsDetails_Delete(string Eleid)
        //    {
        //        if (DeleteRecord("[SupplierPO_Documents]", "PGR_Doc_Id", Eleid) == true)
        //        {
        //            _returnStringMessage = "Data Deleted Successfully";
        //        }
        //        else
        //        {
        //            _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
        //        }

        //        return _returnStringMessage;
        //    }
















        //    public string Stock_UpdatePQC(string productid, string Qty, string colorid)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid ) == true)
        //        {
        //            _commandText = string.Format("UPDATE [Stock] SET  Quantity=Quantity+'{0}' WHERE MatId = {1}  and ColorId = {2} ", Qty, productid, colorid);
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
        //        }
               
        //        return _returnStringMessage;
        //    }



        //    public string Stock_Update1(string productid, string Qty, string plantid, string colorid, string storagelocid,string Length)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //       // if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "PlantId", plantid, "StoragelocId", storagelocid, "Length",Length) == true)

        //        if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid,"Length", Length) == true)
        //        {
        //            _commandText = string.Format("UPDATE [Stock] SET  Quantity = Quantity+'{0}' WHERE MatId = {1}  and ColorId = {2} and Length ={3} ", Qty, productid, colorid,Length);
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
        //        }
        //        else
        //        {
        //            _commandText = string.Format("INSERT INTO [Stock] VALUES ({0},{1},'{2}',{3},{4},{5})", productid, colorid, Qty, plantid, storagelocid,Length);
        //            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

        //            _returnStringMessage = string.Empty;
        //            if (_returnIntValue < 0 || _returnIntValue == 0)
        //            {
        //                _returnStringMessage = "Some Data Missing.";
        //            }
        //            else if (_returnIntValue > 0)
        //            {
        //                _returnStringMessage = "Data Saved Successfully";
        //            }
        //        }
        //        return _returnStringMessage;
        //    }





        //    public string BlockStock_Update1(string productid, string Qty, string colorid, string Length, string SOid)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        if (IsRecordExists("[Stock_Block]", "Item_Code", productid, "Color_Id", colorid, "Length", Length, "So_Id", SOid) == true)
        //        {
        //            _commandText = string.Format("UPDATE [Stock_Block] SET  Qty = Qty+'{0}' WHERE Item_Code = {1}  and Color_Id = {2} and Length ={3} and So_Id = {4} ", Qty, productid, colorid, Length, SOid);
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
        //        }
        //        else
        //        {
        //            _commandText = string.Format("INSERT INTO [Stock_Block] SELECT ISNULL(MAX(BlockStock_Id),0)+1,{0},{1},'{2}',{3},{4},{5},{6},'{7}',{8},{9},'{10}' FROM [Stock_Block]", SOid, productid, Qty, colorid, '0', '0', Length, Qty, '0', '0', "From Mrn");
        //            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

        //            _returnStringMessage = string.Empty;
        //            if (_returnIntValue < 0 || _returnIntValue == 0)
        //            {
        //                _returnStringMessage = "Some Data Missing.";
        //            }
        //            else if (_returnIntValue > 0)
        //            {
        //                _returnStringMessage = "Data Saved Successfully";
        //            }
        //        }
        //        return _returnStringMessage;
        //    }





        //    public string ScrapStock_Update1(string productid, string Qty, string plantid, string colorid, string storagelocid, string Length)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        if (IsRecordExists("[Scarp_Stock]", "MatId", productid, "ColorId", colorid, "PlantId", plantid, "StoragelocId", storagelocid, "Length", Length) == true)
        //        {
        //            _commandText = string.Format("UPDATE [Scarp_Stock] SET  Quantity=CONVERT(DECIMAL,Quantity)+'{0}' WHERE MatId = {1}  and ColorId = {2} and PlantId={3} and StoragelocId ={4} and Length ={5} ", Qty, productid, colorid, plantid, storagelocid, Length);
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
        //        }
        //        else
        //        {

        //            _commandText = string.Format("INSERT INTO [Scarp_Stock] VALUES ({0},{1},'{2}',{3},{4},{5})", productid, colorid, Qty, plantid, storagelocid, Length);
        //            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

        //            _returnStringMessage = string.Empty;
        //            if (_returnIntValue < 0 || _returnIntValue == 0)
        //            {
        //                _returnStringMessage = "Some Data Missing.";
        //            }
        //            else if (_returnIntValue > 0)
        //            {
        //                _returnStringMessage = "Data Saved Successfully";
        //            }
        //        }
        //        return _returnStringMessage;
        //    }



        //    public string Stock_Update(string productid, string Qty, string plantid, string colorid, string storagelocid)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "PlantId", plantid, "StoragelocId", storagelocid) == true)
        //        {
        //            _commandText = string.Format("UPDATE [Stock] SET  Quantity=CONVERT(BIGINT,Quantity)+{0} WHERE MatId = {1}  and ColorId = {2} and PlantId={3} and StoragelocId ={4} ", Qty, productid, colorid, plantid, storagelocid);
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
        //        }
        //        else
        //        {

        //            _commandText = string.Format("INSERT INTO [Stock] VALUES ({0},{1},{2},{3},{4})", productid, colorid, Qty, plantid, storagelocid);
        //            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

        //            _returnStringMessage = string.Empty;
        //            if (_returnIntValue < 0 || _returnIntValue == 0)
        //            {
        //                _returnStringMessage = "Some Data Missing.";
        //            }
        //            else if (_returnIntValue > 0)
        //            {
        //                _returnStringMessage = "Data Saved Successfully";
        //            }
        //        }
        //        return _returnStringMessage;
        //    }




        //    public string Stock_Update12(string productid, string Qty, string plantid, string colorid, string storagelocid, string Length)
        //    {
        //        if (dbManager.Transaction == null)
        //            dbManager.Open();
        //        if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "Length", Length) == true)
        //        {
        //            _commandText = string.Format("UPDATE [Stock] SET  Quantity=CONVERT(DECIMAL,Quantity)+'{0}' WHERE MatId = {1}  and ColorId = {2} and Length ={3} ", Qty, productid, colorid, Length);
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
        //        }
        //        else
        //        {

        //            _commandText = string.Format("INSERT INTO [Stock] VALUES ({0},{1},'{2}',{3},{4},{5})", productid, colorid, Qty, plantid, storagelocid, Length);
        //            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

        //            _returnStringMessage = string.Empty;
        //            if (_returnIntValue < 0 || _returnIntValue == 0)
        //            {
        //                _returnStringMessage = "Some Data Missing.";
        //            }
        //            else if (_returnIntValue > 0)
        //            {
        //                _returnStringMessage = "Data Saved Successfully";
        //            }
        //        }
        //        return _returnStringMessage;
        //    }



        //}






        //Methods for BOM






        public class PurchaseReceipt
        {
            public string SPrId, SPrNo, SPrDate, POid, Preparedby, approvedby, VehicalNo, Remarks, CheckedBy, Invoiceno, Invoicedate,PoNos;

            public string Sprdetid, matid, length, color, orderedqty, cutid, receivedqty, plantid, storagelocid, stocktype, colorid, aCCEPTEDQTY, rEJECTEDQTY, itemremarks, BlockQty,DetPOId;

            public string mrnrejectedid;

            public PurchaseReceipt()
            {
            }

            public static string PurchaseReceipt_AutoGenCode()
            {
                return SCM.AutoGenMaxNo("Supplier_PurchaseReceipt", "SPR_NO");
            }

            public string PurchaseReceipt_Save()
            {
                this.SPrNo = PurchaseReceipt_AutoGenCode();
                this.SPrId = AutoGenMaxId("[Supplier_PurchaseReceipt]", "SPR_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Supplier_PurchaseReceipt] VALUES({0},'{1}','{2}',{3},{4},{5},'{6}','{7}',{8},'{9}','{10}','{11}') ", this.SPrId, this.SPrNo, this.SPrDate, this.POid, this.Preparedby, this.approvedby, this.VehicalNo, this.Remarks, this.CheckedBy, this.Invoiceno, this.Invoicedate,this.PoNos);
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

            public string PurchaseReceipt_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Supplier_PurchaseReceipt] SET SPR_NO='{0}',SPR_DATE='{1}', SUP_PO_ID={2}, PREPAREDBY={3}, APPROVEDBY={4},Vehical_No='{5}',Remarks='{6}',Cheked_By='{7}',InvoiceNo='{8}',InvoiceDate='{9}',PONos='{10}' WHERE SPR_ID={11}", this.SPrNo, this.SPrDate, this.POid, this.Preparedby, this.approvedby, this.VehicalNo, this.Remarks, this.CheckedBy, this.Invoiceno, this.Invoicedate,this.PoNos, this.SPrId);
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

            public string PurchaseReceiptApprove_Update(string ApprovedBy, string POId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Supplier_PurchaseReceipt] SET APPROVEDBY={0}   WHERE SPR_ID={1}", ApprovedBy, SPrId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Approved Successfully";
                }
                return _returnStringMessage;
            }

            public string PurchaseReceipt_Delete(string SupFixedPOId)
            {
                if (DeleteRecord("[Supplier_PurchaseReceipt_Details]", "SPR_ID", SupFixedPOId) == true)
                {
                    if (DeleteRecord("[Supplier_PurchaseReceipt]", "SPR_ID", SupFixedPOId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public static void PurchaseReceipt_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Supplier_PurchaseReceipt] ORDER BY SPR_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "SPR_NO", "SPR_ID");
                }
            }

            public int PurchaseReceipt_Select(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM Supplier_PurchaseReceipt WHERE Supplier_PurchaseReceipt.SPR_ID ='" + SupFixedPOId + "' ORDER BY [Supplier_PurchaseReceipt].SPR_ID DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SPrId = dbManager.DataReader["SPR_ID"].ToString();
                    this.SPrNo = dbManager.DataReader["SPR_NO"].ToString();
                    this.SPrDate = Convert.ToDateTime(dbManager.DataReader["SPR_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.POid = dbManager.DataReader["SUP_PO_ID"].ToString();
                    this.Preparedby = dbManager.DataReader["PREPAREDBY"].ToString();
                    this.approvedby = dbManager.DataReader["APPROVEDBY"].ToString();
                    this.VehicalNo = dbManager.DataReader["Vehical_No"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.CheckedBy = dbManager.DataReader["Cheked_By"].ToString();


                    this.Invoiceno = dbManager.DataReader["InvoiceNo"].ToString();
                    this.Invoicedate = dbManager.DataReader["InvoiceDate"].ToString();
                    this.PoNos = dbManager.DataReader["PONos"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public int PurchaseReceiptPO_Select(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM Supplier_PurchaseReceipt WHERE Supplier_PurchaseReceipt.SUP_PO_ID ='" + SupFixedPOId + "' ORDER BY [Supplier_PurchaseReceipt].SPR_ID DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SPrId = dbManager.DataReader["SPR_ID"].ToString();
                    this.SPrNo = dbManager.DataReader["SPR_NO"].ToString();
                    this.SPrDate = Convert.ToDateTime(dbManager.DataReader["SPR_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.POid = dbManager.DataReader["SUP_PO_ID"].ToString();
                    this.Preparedby = dbManager.DataReader["PREPAREDBY"].ToString();
                    this.approvedby = dbManager.DataReader["APPROVEDBY"].ToString();
                    this.VehicalNo = dbManager.DataReader["Vehical_No"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.CheckedBy = dbManager.DataReader["Cheked_By"].ToString();

                    this.Invoiceno = dbManager.DataReader["InvoiceNo"].ToString();
                    this.Invoicedate = dbManager.DataReader["InvoiceDate"].ToString();
                    this.PoNos = dbManager.DataReader["PONos"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public string Instock, Soid, Description;

            public string PurchaseReceiptDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Supplier_PurchaseReceipt_Details] SELECT ISNULL(MAX(SPR_DET_ID),0)+1,{0},{1},'{2}','{3}','{4}',{5},{6},{7},'{8}','{9}','{10}','{11}','{12}','{13}',{14},{15} FROM [Supplier_PurchaseReceipt_Details]", this.SPrId, this.matid, this.color, this.orderedqty, this.receivedqty, this.plantid, this.storagelocid, this.colorid, this.aCCEPTEDQTY, this.rEJECTEDQTY, this.Instock, this.itemremarks, this.Soid, this.Description, this.length,this.DetPOId);
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

            public string MRNRejectedDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [MRN_Rejected] SELECT ISNULL(MAX(MrnReject_Id),0)+1,{0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}',{11},{12} FROM [MRN_Rejected]", this.SPrId, this.matid, this.color, this.orderedqty, this.receivedqty, this.aCCEPTEDQTY, this.rEJECTEDQTY, this.Instock, this.itemremarks, this.Soid, this.Description, this.length, this.DetPOId);
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

            public string podetid;
            public string PurchaseOrderDetailsRemainingQty_Update(string podetid, string receivedqty)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //_commandText = string.Format("UPDATE [Supplier_Po_Details] SET  RemainingQty=CONVERT(BIGINT,RemainingQty)-{0} WHERE Sup_PO_Det_id={1} ", receivedqty, podetid);
                //_returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);



                _commandText = string.Format("UPDATE [Supplier_Po_Details] SET  RemainingQty= RemainingQty -'{0}',ReceivedQty= ReceivedQty +'{0}'   WHERE Sup_PO_Det_id={1} ", receivedqty, podetid);
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

            public string PurchaseOrderDetailsRecivedQty_Update(string podetid, string receivedqty)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //_commandText = string.Format("UPDATE [Supplier_Po_Details] SET  RemainingQty=CONVERT(BIGINT,RemainingQty)-{0} WHERE Sup_PO_Det_id={1} ", receivedqty, podetid);
                //_returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);



                _commandText = string.Format("UPDATE [Supplier_Po_Details] SET  ReceivedQty= ReceivedQty +'{0}'  WHERE Sup_PO_Det_id={1} ", receivedqty, podetid);
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

            public int PurchaseReceiptDetails_Delete(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Supplier_PurchaseReceipt_Details] WHERE SPR_ID = {0}", SupFixedPOId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public string QuoDocdate, QuoDocRemarks, QuoDocuments;
            public string MRNDocuments_Details_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [SupplierPO_Documents] SELECT ISNULL(MAX(PGR_Doc_Id),0)+1,'{0}','{1}','{2}',{3} FROM [SupplierPO_Documents]", this.QuoDocdate, this.QuoDocRemarks, this.QuoDocuments, this.SPrId);
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

            public string MRNDocumentsDetails_Delete(string Eleid)
            {
                if (DeleteRecord("[SupplierPO_Documents]", "PGR_Doc_Id", Eleid) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }

                return _returnStringMessage;
            }

            public string Stock_UpdatePQC(string productid, string Qty, string colorid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=Quantity+'{0}' WHERE MatId = {1}  and ColorId = {2} ", Qty, productid, colorid);
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

            public string Stock_Update1(string productid, string Qty, string plantid, string colorid, string storagelocid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                // if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "PlantId", plantid, "StoragelocId", storagelocid, "Length",Length) == true)

                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "Length", Length) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity = Quantity+'{0}' WHERE MatId = {1}  and ColorId = {2} and Length ={3} ", Qty, productid, colorid, Length);
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
                    _commandText = string.Format("INSERT INTO [Stock] VALUES ({0},{1},'{2}',{3},{4},{5})", productid, colorid, Qty, plantid, storagelocid, Length);
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

            public string BlockStock_Update1(string productid, string Qty, string colorid, string Length, string SOid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock_Block]", "Item_Code", productid, "Color_Id", colorid, "Length", Length, "So_Id", SOid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock_Block] SET  Qty = Qty+'{0}' WHERE Item_Code = {1}  and Color_Id = {2} and Length ={3} and So_Id = {4} ", Qty, productid, colorid, Length, SOid);
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
                    _commandText = string.Format("INSERT INTO [Stock_Block] SELECT ISNULL(MAX(BlockStock_Id),0)+1,{0},{1},'{2}',{3},{4},{5},{6},'{7}',{8},{9},'{10}' FROM [Stock_Block]", SOid, productid, Qty, colorid, '0', '0', Length, Qty, '0', '0', "From Mrn");
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

            public string ScrapStock_Update1(string productid, string Qty, string plantid, string colorid, string storagelocid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //if (IsRecordExists("[Scarp_Stock]", "MatId", productid, "ColorId", colorid, "PlantId", plantid, "StoragelocId", storagelocid, "Length", Length) == true)
                //{
                //    _commandText = string.Format("UPDATE [Scarp_Stock] SET  Quantity=CONVERT(DECIMAL,Quantity)+'{0}' WHERE MatId = {1}  and ColorId = {2} and PlantId={3} and StoragelocId ={4} and Length ={5} ", Qty, productid, colorid, plantid, storagelocid, Length);
                //    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                //    _returnStringMessage = string.Empty;
                //    if (_returnIntValue < 0 || _returnIntValue == 0)
                //    {
                //        _returnStringMessage = "Some Data Missing.";
                //    }
                //    else if (_returnIntValue > 0)
                //    {
                //        _returnStringMessage = "Data Updated Successfully";
                //    }
                //}
                //else
                //{

                    _commandText = string.Format("INSERT INTO [Scarp_Stock] VALUES ({0},{1},'{2}',{3},{4},{5})", productid, colorid, Qty, plantid, storagelocid, Length);
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
                //}
                return _returnStringMessage;
            }

            public string Stock_Update(string productid, string Qty, string plantid, string colorid, string storagelocid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "PlantId", plantid, "StoragelocId", storagelocid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=CONVERT(BIGINT,Quantity)+{0} WHERE MatId = {1}  and ColorId = {2} and PlantId={3} and StoragelocId ={4} ", Qty, productid, colorid, plantid, storagelocid);
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

                    _commandText = string.Format("INSERT INTO [Stock] VALUES ({0},{1},{2},{3},{4})", productid, colorid, Qty, plantid, storagelocid);
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

            public string Stock_Update12(string productid, string Qty, string plantid, string colorid, string storagelocid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "Length", Length) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=CONVERT(DECIMAL,Quantity)+'{0}' WHERE MatId = {1}  and ColorId = {2} and Length ={3} ", Qty, productid, colorid, Length);
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

                    _commandText = string.Format("INSERT INTO [Stock] VALUES ({0},{1},'{2}',{3},{4},{5})", productid, colorid, Qty, plantid, storagelocid, Length);
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












            ///Rejected Qty to Stock Remarks Update
            public void Rejectedtostockmrn(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT *,Supplier_PurchaseReceipt_Details.Description as Series  FROM Supplier_PurchaseReceipt_Details,[Material_Master],Color_Master where Supplier_PurchaseReceipt_Details.MAT_ID=[Material_Master].Material_Id AND " +
                                              "Supplier_PurchaseReceipt_Details.COLOR_ID = Color_Master.Color_Id and Supplier_PurchaseReceipt_Details.SPR_ID ='" + QuotationId + "' and Supplier_PurchaseReceipt_Details.PO_REJECTED_QTY != '0' ");


                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("CodeNo");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesQuotationItems.Columns.Add(col);
               
                col = new DataColumn("ReceivedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("AcceptedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RejectedQty");
                SalesQuotationItems.Columns.Add(col);


                col = new DataColumn("TakeinStock");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("ItemcodeId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("Remarks");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("SPR_DET_ID");
                SalesQuotationItems.Columns.Add(col);


                //col = new DataColumn("AlreadyBlocked");
                //SalesQuotationItems.Columns.Add(col);
                //col = new DataColumn("BlockRemarks");
                //SalesQuotationItems.Columns.Add(col);





                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["CodeNo"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Series"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Length"] = dbManager.DataReader["Lengthh"].ToString();
                    dr["Qty"] = dbManager.DataReader["PO_DET_QTY"].ToString();

                    dr["ReceivedQty"] = dbManager.DataReader["PO_RECEIVED_QTY"].ToString();
                    dr["AcceptedQty"] = dbManager.DataReader["PO_ACCEPTED_QTY"].ToString();
                    dr["RejectedQty"] = dbManager.DataReader["PO_REJECTED_QTY"].ToString();

                    dr["TakeinStock"] = "0";


                    dr["ItemcodeId"] = dbManager.DataReader["MAT_ID"].ToString();
                    dr["ColorId"] = dbManager.DataReader["COLOR_ID"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["SPR_DET_ID"] = dbManager.DataReader["SPR_DET_ID"].ToString();

                   

                    


                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }



            ///Adding in MRN Rejected History

            public string mrndetid;

            public string MRNRjectStock_Update(string mrndetid, string Qty,string reamrks)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [Supplier_PurchaseReceipt_Details] SET  PO_ACCEPTED_QTY=CONVERT(DECIMAL,PO_ACCEPTED_QTY)+'{0}',PO_REJECTED_QTY =CONVERT(DECIMAL,PO_REJECTED_QTY)-'{0}',Remarks = '{2}'  WHERE SPR_DET_ID = {1} ", Qty, mrndetid, reamrks);
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




























        public class BOM
        {

            public string BomId,Soid,SoDetId,Quantity,BomNo,Status;

            public string BomDetid,ItemCodeId,ItemQty,Uom,ColorId,requiredlength;


            public BOM()
            {
            }

            public static string BOMNo_AutoGenCode()
            {
                return SCM.AutoGenMaxNo("Bom", "Bom_No");
            }

            public string BOM_Save()
            {
                this.BomNo = BOMNo_AutoGenCode();
                this.BomId = AutoGenMaxId("[Bom]", "Bom_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Bom] VALUES({0},{1},{2},{3},'{4}','{5}') ", this.BomId, this.Soid, this.SoDetId, this.Quantity, this.BomNo,this.Status);
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

            public string BOM_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Bom] SET So_Id = {0},So_Det_Id={1}, Quantity={2}, Bom_No='{3}',Status='{4}'  WHERE Bom_Id={4}", this.Soid, this.SoDetId, this.Quantity, this.BomNo,this.Status, this.BomId);
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

           

        

            public string BOM_Delete(string SupFixedPOId)
            {
                if (DeleteRecord("[Bom_Details]", "Bom_Id", SupFixedPOId) == true)
                {
                    if (DeleteRecord("[Bom]", "Bom_Id", SupFixedPOId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public static void BOM_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Bom] ORDER BY Bom_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Bom_No", "Bom_Id");
                }
            }
            #region UserPermissions Select

            public DataTable BomOperations_Select(int sodetid)
            {
                DataTable dtable = new DataTable();
                DataColumn dcol = new DataColumn();
                dcol = new DataColumn("Operation_Id");
                dtable.Columns.Add(dcol);

                dbManager.Open();
                _commandText = string.Format("SELECT * FROM Bom_Operations WHERE So_Det_Id={0}", sodetid);
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                while (dbManager.DataReader.Read())
                {
                    DataRow drow = dtable.NewRow();
                    drow["Operation_Id"] = dbManager.DataReader[1].ToString();
                    dtable.Rows.Add(drow);
                }
                dbManager.DataReader.Close();
                return dtable;
            }

            #endregion UserPermissions Select
          
            public int Bom_Select(string SupFixedPOId)
            {
               
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Bom] where [Bom].Bom_Id ='" + SupFixedPOId + "' ORDER BY [Bom].Bom_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.BomId = dbManager.DataReader["Bom_Id"].ToString();
                    this.Soid = dbManager.DataReader["So_Id"].ToString();
                    this.Quantity = dbManager.DataReader["Quantity"].ToString();
                    this.SoDetId = dbManager.DataReader["So_Det_Id"].ToString();
                    this.BomNo = dbManager.DataReader["Bom_No"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

           

            public void BomOperations_Save(int sodetid, string Operationid)
            {
                dbManager.Open();
                _commandText = string.Format("INSERT INTO Bom_Operations VALUES ({0},{1})", sodetid, Operationid);
                dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            }




            public string SalesOrderItemAStatus_Update(string Sodetid)
            {
               
                    dbManager.Open();

                string status = "Yes";

                _commandText = string.Format("UPDATE [SalesOrder_Details] SET BOM_Status='{0}'   WHERE SalesOrderDet_Id={1}", status, Sodetid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Approved Successfully";
                }
                return _returnStringMessage;
            }











            public string BomDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Bom_Details] SELECT ISNULL(MAX(Bom_DetId),0)+1,{0},{1},{2},'{3}',{4},{5} FROM [Bom_Details]", this.BomId, this.ItemCodeId, this.ItemQty, this.Uom,this.ColorId,this.requiredlength);
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

            public int BomDetails_Delete(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Bom_Details] WHERE Bom_Id={0}", SupFixedPOId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public void BomDetails_Select(string SupFixedPOId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Bom_Details],Material_Master,Color_Master WHERE [Bom_Details].Item_Id=[Material_Master].Material_Id and Color_Master.Color_Id = Bom_Details.Color_Id and Bom_Details.Bom_Id=" + SupFixedPOId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SuppliersFixedPOItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("UOM");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Color");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Required");
                SuppliersFixedPOItems.Columns.Add(col);
               
                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SuppliersFixedPOItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Qty"] = dbManager.DataReader["Qty"].ToString();
                    dr["UOM"] = dbManager.DataReader["Uom"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();

                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["Required"] = dbManager.DataReader["RequiredLength"].ToString();
                    SuppliersFixedPOItems.Rows.Add(dr);
                }
                gv.DataSource = SuppliersFixedPOItems;
                gv.DataBind();
            }

            public void BomProductionDetails_Select(string SupFixedPOId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Bom_Details],Material_Master,Color_Master WHERE [Bom_Details].Item_Id=[Material_Master].Material_Id and Color_Master.Color_Id = Bom_Details.Color_Id and Bom_Details.Bom_Id=" + SupFixedPOId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SuppliersFixedPOItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("UOM");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Color");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Required");
                SuppliersFixedPOItems.Columns.Add(col);

                col = new DataColumn("Transferqty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Barlength");
                SuppliersFixedPOItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SuppliersFixedPOItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Qty"] = dbManager.DataReader["Qty"].ToString();
                    dr["UOM"] = dbManager.DataReader["Uom"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();

                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["Required"] = dbManager.DataReader["RequiredLength"].ToString();
                    dr["Transferqty"] = "0";
                    dr["Barlength"] = dbManager.DataReader["Bar_Length"].ToString();
                    SuppliersFixedPOItems.Rows.Add(dr);
                }
                gv.DataSource = SuppliersFixedPOItems;
                gv.DataBind();
            }
            public void BomQtyProductionDetails_Select(string SupFixedPOId, string qty, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Bom_Details],Material_Master,Color_Master WHERE [Bom_Details].Item_Id=[Material_Master].Material_Id and Color_Master.Color_Id = Bom_Details.Color_Id and Bom_Details.Bom_Id=" + SupFixedPOId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SuppliersFixedPOItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("UOM");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Color");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Required");
                SuppliersFixedPOItems.Columns.Add(col);

                col = new DataColumn("Transferqty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Barlength");
                SuppliersFixedPOItems.Columns.Add(col);
                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SuppliersFixedPOItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Qty"] = int.Parse(dbManager.DataReader["Qty"].ToString()) * int.Parse(qty);
                    dr["UOM"] = dbManager.DataReader["Uom"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();

                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["Required"] = int.Parse(dbManager.DataReader["RequiredLength"].ToString()) * int.Parse(qty);
                    dr["Transferqty"] = "0";
                    dr["Barlength"] = dbManager.DataReader["Bar_Length"].ToString();
                    SuppliersFixedPOItems.Rows.Add(dr);
                }
                gv.DataSource = SuppliersFixedPOItems;
                gv.DataBind();
            }




        }











        public class GlassPurchaseReceipt
        {
            public string SPrId, SPrNo, SPrDate, POid, Preparedby, approvedby, VehicalNo, Remarks, CheckedBy, Invoiceno, Invoicedate, PoNos;

            public string Sprdetid, Windowcode, Thickness, Descriptin, Width, Height, Unit, Area, Weight, PoQty, Receivedqty,Plantid,StoragelocId, aCCEPTEDQTY, rEJECTEDQTY, instock,itemremarks, SoId, DetPOId;


            public GlassPurchaseReceipt()
            {
            }

            public static string GlassPurchaseReceipt_AutoGenCode()
            {
                return SCM.AutoGenMaxNo("Glass_PurchaseReceipt", "SPR_NO");
            }


            public string GlassPurchaseReceipt_Save()
            {
                this.SPrNo = GlassPurchaseReceipt_AutoGenCode();
                this.SPrId = AutoGenMaxId("[Glass_PurchaseReceipt]", "SPR_ID");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Glass_PurchaseReceipt] VALUES({0},'{1}','{2}',{3},{4},{5},'{6}','{7}',{8},'{9}','{10}','{11}') ", this.SPrId, this.SPrNo, this.SPrDate, this.POid, this.Preparedby, this.approvedby, this.VehicalNo, this.Remarks, this.CheckedBy, this.Invoiceno, this.Invoicedate, this.PoNos);
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


            public string GlassPurchaseReceipt_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Glass_PurchaseReceipt] SET SPR_NO='{0}',SPR_DATE='{1}', SUP_PO_ID={2}, PREPAREDBY={3}, APPROVEDBY={4},Vehical_No='{5}',Remarks='{6}',Cheked_By='{7}',InvoiceNo='{8}',InvoiceDate='{9}',PONos='{10}' WHERE SPR_ID={11}", this.SPrNo, this.SPrDate, this.POid, this.Preparedby, this.approvedby, this.VehicalNo, this.Remarks, this.CheckedBy, this.Invoiceno, this.Invoicedate, this.PoNos, this.SPrId);
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

            public string GlassPurchaseReceiptApprove_Update(string ApprovedBy, string POId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Glass_PurchaseReceipt] SET APPROVEDBY={0}   WHERE SPR_ID={1}", ApprovedBy, SPrId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                _returnStringMessage = string.Empty;
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                else if (_returnIntValue > 0)
                {
                    _returnStringMessage = "Data Approved Successfully";
                }
                return _returnStringMessage;
            }


            public string GlassPurchaseReceipt_Delete(string SupFixedPOId)
            {
                if (DeleteRecord("[Supplier_GlassReceipt_Details]", "SPR_ID", SupFixedPOId) == true)
                {
                    if (DeleteRecord("[Glass_PurchaseReceipt]", "SPR_ID", SupFixedPOId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public static void GlassPurchaseReceipt_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Glass_PurchaseReceipt] ORDER BY SPR_ID");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "SPR_NO", "SPR_ID");
                }
            }


            public int GlassPurchaseReceipt_Select(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM Glass_PurchaseReceipt WHERE Glass_PurchaseReceipt.SPR_ID ='" + SupFixedPOId + "' ORDER BY [Glass_PurchaseReceipt].SPR_ID DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SPrId = dbManager.DataReader["SPR_ID"].ToString();
                    this.SPrNo = dbManager.DataReader["SPR_NO"].ToString();
                    this.SPrDate = Convert.ToDateTime(dbManager.DataReader["SPR_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.POid = dbManager.DataReader["SUP_PO_ID"].ToString();
                    this.Preparedby = dbManager.DataReader["PREPAREDBY"].ToString();
                    this.approvedby = dbManager.DataReader["APPROVEDBY"].ToString();
                    this.VehicalNo = dbManager.DataReader["Vehical_No"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.CheckedBy = dbManager.DataReader["Cheked_By"].ToString();


                    this.Invoiceno = dbManager.DataReader["InvoiceNo"].ToString();
                    this.Invoicedate = dbManager.DataReader["InvoiceDate"].ToString();
                    this.PoNos = dbManager.DataReader["PONos"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }







            public int GlassPurchaseReceiptPO_Select(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM Glass_PurchaseReceipt WHERE Glass_PurchaseReceipt.SUP_PO_ID ='" + SupFixedPOId + "' ORDER BY [Glass_PurchaseReceipt].SPR_ID DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SPrId = dbManager.DataReader["SPR_ID"].ToString();
                    this.SPrNo = dbManager.DataReader["SPR_NO"].ToString();
                    this.SPrDate = Convert.ToDateTime(dbManager.DataReader["SPR_DATE"].ToString()).ToString("dd/MM/yyyy");
                    this.POid = dbManager.DataReader["SUP_PO_ID"].ToString();
                    this.Preparedby = dbManager.DataReader["PREPAREDBY"].ToString();
                    this.approvedby = dbManager.DataReader["APPROVEDBY"].ToString();
                    this.VehicalNo = dbManager.DataReader["Vehical_No"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.CheckedBy = dbManager.DataReader["Cheked_By"].ToString();

                    this.Invoiceno = dbManager.DataReader["InvoiceNo"].ToString();
                    this.Invoicedate = dbManager.DataReader["InvoiceDate"].ToString();
                    this.PoNos = dbManager.DataReader["PONos"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }


            //public string Instock, Soid;


            public string GlassPurchaseReceiptDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Supplier_GlassReceipt_Details] SELECT ISNULL(MAX(SPR_DET_ID),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},{12},'{13}','{14}','{15}','{16}',{17},{18} FROM [Supplier_GlassReceipt_Details]", this.SPrId, this.Windowcode, this.Thickness, this.Descriptin, this.Width, this.Height, this.Unit, this.Area, this.Weight, this.PoQty, this.Receivedqty, this.Plantid, this.StoragelocId, this.aCCEPTEDQTY, this.rEJECTEDQTY, this.instock,this.itemremarks,this.SoId,this.DetPOId);
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




            public string RejectedGlassPurchaseReceiptDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [GlassPurchaseReceipt_Rejected] SELECT ISNULL(MAX(SPR_DET_ID),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},{12},'{13}','{14}','{15}','{16}',{17},{18} FROM [GlassPurchaseReceipt_Rejected]", this.SPrId, this.Windowcode, this.Thickness, this.Descriptin, this.Width, this.Height, this.Unit, this.Area, this.Weight, this.PoQty, this.Receivedqty, this.Plantid, this.StoragelocId, this.aCCEPTEDQTY, this.rEJECTEDQTY, this.instock, this.itemremarks, this.SoId, this.DetPOId);
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

            public string podetid;
            public string GlassPurchaseOrderDetailsRemainingQty_Update(string podetid, string receivedqty)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //_commandText = string.Format("UPDATE [Supplier_Po_Details] SET  RemainingQty=CONVERT(BIGINT,RemainingQty)-{0} WHERE Sup_PO_Det_id={1} ", receivedqty, podetid);
                //_returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);



                _commandText = string.Format("UPDATE [Glass_PO_Details] SET  RemainingQty= RemainingQty -{0},ReceivedQty= ReceivedQty +{0},stock =stock + {0}  WHERE Sup_GPO_Det_id={1} ", receivedqty, podetid);
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





            public int GlassPurchaseReceiptDetails_Delete(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Supplier_GlassReceipt_Details] WHERE SPR_ID = {0}", SupFixedPOId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }


            public string QuoDocdate, QuoDocRemarks, QuoDocuments;
            public string MRNDocuments_Details_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [SupplierPO_Documents] SELECT ISNULL(MAX(PGR_Doc_Id),0)+1,'{0}','{1}','{2}',{3} FROM [SupplierPO_Documents]", this.QuoDocdate, this.QuoDocRemarks, this.QuoDocuments, this.SPrId);
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

            public string MRNDocumentsDetails_Delete(string Eleid)
            {
                if (DeleteRecord("[SupplierPO_Documents]", "PGR_Doc_Id", Eleid) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }

                return _returnStringMessage;
            }


        }





        //Methods for ProductionOrder
        public class ProductionOrder
        {

            public string ProductionId,ProductionNo,ItemId,BomId,QtytoManf,SOid,WorkinprogressId,ScrapWarehouseId,TargetWarehouseId,PlannedStartDate,ExpectedDeliveryDate,PreparedBy,Status;

            public string ProductionDetId, ItemCode, Color, reqqty, barlength, requiredbarlength, transferqty, uom,PodStatus,ItemSourcewarehouseid,ItemTargetwarehouseid,ItemScarpwarehouseid;


            public ProductionOrder()
            {
            }

            public static string ProductionOrderNo_AutoGenCode()
            {
                return SCM.AutoGenMaxNo("ProductionOrder", "ProductionOrder_No");
            }

            public string ProductionOrder_Save()
            {
                this.ProductionNo = ProductionOrderNo_AutoGenCode();
                this.ProductionId = AutoGenMaxId("[ProductionOrder]", "ProductionOrder_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [ProductionOrder] VALUES({0},'{1}',{2},{3},{4},{5},{6},{7},{8},'{9}','{10}',{11},'{12}') ", this.ProductionId, this.ProductionNo, this.ItemId, this.BomId, this.QtytoManf,this.SOid,this.WorkinprogressId,this.ScrapWarehouseId,this.TargetWarehouseId,this.PlannedStartDate,this.ExpectedDeliveryDate,this.PreparedBy,this.Status);
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

            public string ProductionOrder_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [ProductionOrder] SET ProductionOrder_No={0},Item_Id={1}, Bom_Id={2}, QtytoManf={3},SalesOrder_Id={4},WorkInProgress_WarehouseId={5},ScrapWarehouse_Id={6},Targetwarehouse_Id={7},PlannedStartDate='{8}',ExpectedDeliceryDate='{9}',PreparedBy={10},Status='{11}'  WHERE ProductionOrder_Id={12}", this.ProductionNo, this.ItemId, this.BomId, this.QtytoManf, this.SOid, this.WorkinprogressId, this.ScrapWarehouseId, this.TargetWarehouseId, this.PlannedStartDate, this.ExpectedDeliveryDate, this.PreparedBy, this.Status,this.ProductionId);
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

            public string ProductionOrderStatus_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [ProductionOrder] SET Status='{0}'  WHERE ProductionOrder_Id={1}", this.Status, this.ProductionId);
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



            public string ProductionOrder_Delete(string SupFixedPOId)
            {
                if (DeleteRecord("[ProductionOrder_Details]", "Production_Id", SupFixedPOId) == true)
                {
                    if (DeleteRecord("[ProductionOrder]", "ProductionOrder_Id", SupFixedPOId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public static void ProductionOrder_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [ProductionOrder] ORDER BY ProductionOrder_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "ProductionOrder_No", "ProductionOrder_Id");
                }
            }


            public int ProductionOrder_Select(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [ProductionOrder] where [ProductionOrder].ProductionOrder_Id ='" + SupFixedPOId + "' ORDER BY [ProductionOrder].ProductionOrder_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ProductionId = dbManager.DataReader["ProductionOrder_Id"].ToString();
                    this.ProductionNo = dbManager.DataReader["ProductionOrder_No"].ToString();
                    this.ItemId = dbManager.DataReader["Item_Id"].ToString();
                    this.BomId = dbManager.DataReader["Bom_Id"].ToString();
                    this.QtytoManf = dbManager.DataReader["QtytoManf"].ToString();

                    this.SOid = dbManager.DataReader["SalesOrder_Id"].ToString();
                    this.WorkinprogressId = dbManager.DataReader["WorkInProgress_WarehouseId"].ToString();
                    this.ScrapWarehouseId = dbManager.DataReader["ScrapWarehouse_Id"].ToString();


                    this.TargetWarehouseId = dbManager.DataReader["Targetwarehouse_Id"].ToString();
                    this.PlannedStartDate = Convert.ToDateTime(dbManager.DataReader["PlannedStartDate"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.ExpectedDeliveryDate = Convert.ToDateTime(dbManager.DataReader["ExpectedDeliceryDate"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    this.PreparedBy = dbManager.DataReader["PreparedBy"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }




















            public string ProductionOrderDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [ProductionOrder_Details] SELECT ISNULL(MAX(ProductionOder_det_Id),0)+1,{0},{1},{2},{3},{4},{5},{6},'{7}',{8},{9},{10} FROM [ProductionOrder_Details]", this.ProductionId, this.ItemCode, this.Color, this.reqqty,this.barlength,this.requiredbarlength,this.transferqty,this.uom,this.ItemSourcewarehouseid,this.ItemTargetwarehouseid,this.ItemScarpwarehouseid);
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

            public int ProductionOrderDetails_Delete(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [ProductionOrder_Details] WHERE Production_Id={0}", SupFixedPOId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            //public void BomDetails_Select(string SupFixedPOId, GridView gv)
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();
            //    _commandText = string.Format("SELECT * FROM [Bom_Details],Material_Master WHERE [Bom_Details].Item_Id=[Material_Master].Material_Id and Bom_Details.Bom_Id=" + SupFixedPOId);
            //    dbManager.ExecuteReader(CommandType.Text, _commandText);

            //    DataTable SuppliersFixedPOItems = new DataTable();
            //    DataColumn col = new DataColumn();
            //    col = new DataColumn("ItemCode");
            //    SuppliersFixedPOItems.Columns.Add(col);
            //    col = new DataColumn("Qty");
            //    SuppliersFixedPOItems.Columns.Add(col);
            //    col = new DataColumn("UOM");
            //    SuppliersFixedPOItems.Columns.Add(col);
            //    col = new DataColumn("ItemCodeId");
            //    SuppliersFixedPOItems.Columns.Add(col);

            //    while (dbManager.DataReader.Read())
            //    {
            //        DataRow dr = SuppliersFixedPOItems.NewRow();
            //        dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
            //        dr["Qty"] = dbManager.DataReader["Qty"].ToString();
            //        dr["UOM"] = dbManager.DataReader["Uom"].ToString();
            //        dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();



            //        SuppliersFixedPOItems.Rows.Add(dr);
            //    }
            //    gv.DataSource = SuppliersFixedPOItems;
            //    gv.DataBind();
            //}



              public void ProductionDetails_Select(string SupFixedPOId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [ProductionOrder_Details],Material_Master,Color_Master WHERE [ProductionOrder_Details].Item_Code = [Material_Master].Material_Id and Color_Master.Color_Id = ProductionOrder_Details.Color  and ProductionOrder_Details.Production_Id = " + SupFixedPOId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SuppliersFixedPOItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("UOM");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Color");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Required");
                SuppliersFixedPOItems.Columns.Add(col);

                col = new DataColumn("Transferqty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Barlength");
                SuppliersFixedPOItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SuppliersFixedPOItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Qty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["UOM"] = dbManager.DataReader["Uom"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();

                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color"].ToString();
                    dr["Required"] = dbManager.DataReader["Required_Barlength"].ToString();
                    dr["Transferqty"] = dbManager.DataReader["Transferqty"].ToString();
                    dr["Barlength"] = dbManager.DataReader["BarLength"].ToString();



                    SuppliersFixedPOItems.Rows.Add(dr);
                }
                gv.DataSource = SuppliersFixedPOItems;
                gv.DataBind();
            }

              public void ProductionDetails_Selectformaterialtranfer(string SupFixedPOId, GridView gv)
              {
                  if (dbManager.Transaction == null)
                      dbManager.Open();
                  _commandText = string.Format("SELECT * FROM [ProductionOrder_Details],Material_Master,Color_Master,StorageLocation_Master WHERE [ProductionOrder_Details].Item_Code = [Material_Master].Material_Id and Color_Master.Color_Id = ProductionOrder_Details.Color and StorageLocation_Master.StorageLoacation_Id = ProductionOrder_Details.Sourcewarehouse_id    and StorageLocation_Master.StorageLoacation_Id = ProductionOrder_Details.Targetwarehouse_Id   and StorageLocation_Master.StorageLoacation_Id = ProductionOrder_Details.Scrapwarehouse_id   and ProductionOrder_Details.Production_Id =" + SupFixedPOId);
                  dbManager.ExecuteReader(CommandType.Text, _commandText);

                  DataTable SuppliersFixedPOItems = new DataTable();
                  DataColumn col = new DataColumn();
                  col = new DataColumn("ItemCode");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Qty");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("UOM");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("ItemCodeId");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Color");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("ColorId");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Required");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Transferqty");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Barlength");
                  SuppliersFixedPOItems.Columns.Add(col);


                  col = new DataColumn("Swarehouse");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Twarehouse");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Scrapwarehouse");
                  SuppliersFixedPOItems.Columns.Add(col);


                  col = new DataColumn("SwarehouseId");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("TwarehouseId");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("ScrapwarehouseId");
                  SuppliersFixedPOItems.Columns.Add(col);

                  col = new DataColumn("PrdetId");
                  SuppliersFixedPOItems.Columns.Add(col);

                  while (dbManager.DataReader.Read())
                  {
                      DataRow dr = SuppliersFixedPOItems.NewRow();
                      dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                      dr["Qty"] = dbManager.DataReader["ReqQty"].ToString();
                      dr["UOM"] = dbManager.DataReader["Uom"].ToString();
                      dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                      dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                      dr["ColorId"] = dbManager.DataReader["Color"].ToString();
                      dr["Required"] = dbManager.DataReader["Required_Barlength"].ToString();
                      dr["Transferqty"] = dbManager.DataReader["Transferqty"].ToString();
                      dr["Barlength"] = dbManager.DataReader["BarLength"].ToString();




                      dr["Swarehouse"] = dbManager.DataReader["StorageLocation_Name"].ToString();
                      dr["Twarehouse"] = dbManager.DataReader["StorageLocation_Name"].ToString();
                      dr["Scrapwarehouse"] = dbManager.DataReader["StorageLocation_Name"].ToString();
                      dr["SwarehouseId"] = dbManager.DataReader["Sourcewarehouse_id"].ToString();
                      dr["TwarehouseId"] = dbManager.DataReader["Targetwarehouse_Id"].ToString();
                      dr["ScrapwarehouseId"] = dbManager.DataReader["Scrapwarehouse_id"].ToString();

                      dr["PrdetId"] = dbManager.DataReader["ProductionOder_det_Id"].ToString();



                      SuppliersFixedPOItems.Rows.Add(dr);
                  }
                  gv.DataSource = SuppliersFixedPOItems;
                  gv.DataBind();
              }


              public void BomProductionDetails_Select(string SupFixedPOId, GridView gv)
              {
                  if (dbManager.Transaction == null)
                      dbManager.Open();
                  _commandText = string.Format("SELECT * FROM [Bom_Details],Material_Master,Color_Master WHERE [Bom_Details].Item_Id=[Material_Master].Material_Id and Color_Master.Color_Id = Bom_Details.Color_Id and Bom_Details.Bom_Id=" + SupFixedPOId);
                  dbManager.ExecuteReader(CommandType.Text, _commandText);

                  DataTable SuppliersFixedPOItems = new DataTable();
                  DataColumn col = new DataColumn();
                  col = new DataColumn("ItemCode");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Qty");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("UOM");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("ItemCodeId");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Color");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("ColorId");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Required");
                  SuppliersFixedPOItems.Columns.Add(col);

                  col = new DataColumn("Transferqty");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Barlength");
                  SuppliersFixedPOItems.Columns.Add(col);

                  while (dbManager.DataReader.Read())
                  {
                      DataRow dr = SuppliersFixedPOItems.NewRow();
                      dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                      dr["Qty"] = dbManager.DataReader["Qty"].ToString();
                      dr["UOM"] = dbManager.DataReader["Uom"].ToString();
                      dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();

                      dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                      dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                      dr["Required"] = dbManager.DataReader["RequiredLength"].ToString();
                      dr["Transferqty"] = "0";
                      dr["Barlength"] = dbManager.DataReader["Bar_Length"].ToString();
                      SuppliersFixedPOItems.Rows.Add(dr);
                  }
                  gv.DataSource = SuppliersFixedPOItems;
                  gv.DataBind();
              }

              public void BomQtyProductionDetails_Select(string SupFixedPOId, string qty, GridView gv)
              {
                  if (dbManager.Transaction == null)
                      dbManager.Open();
                  _commandText = string.Format("SELECT * FROM [Bom_Details],Material_Master,Color_Master WHERE [Bom_Details].Item_Id=[Material_Master].Material_Id and Color_Master.Color_Id = Bom_Details.Color_Id and Bom_Details.Bom_Id=" + SupFixedPOId);
                  dbManager.ExecuteReader(CommandType.Text, _commandText);

                  DataTable SuppliersFixedPOItems = new DataTable();
                  DataColumn col = new DataColumn();
                  col = new DataColumn("ItemCode");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Qty");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("UOM");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("ItemCodeId");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Color");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("ColorId");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Required");
                  SuppliersFixedPOItems.Columns.Add(col);

                  col = new DataColumn("Transferqty");
                  SuppliersFixedPOItems.Columns.Add(col);
                  col = new DataColumn("Barlength");
                  SuppliersFixedPOItems.Columns.Add(col);
                  while (dbManager.DataReader.Read())
                  {
                      DataRow dr = SuppliersFixedPOItems.NewRow();
                      dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                      dr["Qty"] = int.Parse(dbManager.DataReader["Qty"].ToString()) * int.Parse(qty);
                      dr["UOM"] = dbManager.DataReader["Uom"].ToString();
                      dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();

                      dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                      dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                      dr["Required"] = int.Parse(dbManager.DataReader["RequiredLength"].ToString()) * int.Parse(qty);
                      dr["Transferqty"] = "0";
                      dr["Barlength"] = dbManager.DataReader["Bar_Length"].ToString();
                      SuppliersFixedPOItems.Rows.Add(dr);
                  }
                  gv.DataSource = SuppliersFixedPOItems;
                  gv.DataBind();
              }


              //public void BomProductionDetails_Select(string SupFixedPOId, GridView gv)
              //{
              //    if (dbManager.Transaction == null)
              //        dbManager.Open();
              //    _commandText = string.Format("SELECT * FROM [Bom_Details],Material_Master,StorageLocation_Master WHERE  [Bom_Details].Item_Id = [Material_Master].Material_Id and Material_Master.Storage_Location_Id = StorageLocation_Master.StorageLoacation_Id  and Bom_Details.Bom_Id = " + SupFixedPOId);
              //    dbManager.ExecuteReader(CommandType.Text, _commandText);

              //    DataTable SuppliersFixedPOItems = new DataTable();
              //    DataColumn col = new DataColumn();
              //    col = new DataColumn("ItemCode");
              //    SuppliersFixedPOItems.Columns.Add(col);
              //    col = new DataColumn("SourceWarehouse");
              //    SuppliersFixedPOItems.Columns.Add(col);
              //    col = new DataColumn("ReqQty");
              //    SuppliersFixedPOItems.Columns.Add(col);
              //    col = new DataColumn("Transferqty");
              //    SuppliersFixedPOItems.Columns.Add(col);
              //    col = new DataColumn("ItemcodeId");
              //    SuppliersFixedPOItems.Columns.Add(col);
              //    col = new DataColumn("Sourcewarehouseid");
              //    SuppliersFixedPOItems.Columns.Add(col);

              //    while (dbManager.DataReader.Read())
              //    {
              //        DataRow dr = SuppliersFixedPOItems.NewRow();
              //        dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
              //        dr["SourceWarehouse"] = dbManager.DataReader["StorageLocation_Name"].ToString();
              //        dr["ReqQty"] = dbManager.DataReader["Qty"].ToString();
              //        dr["Transferqty"] = "0";
              //        dr["Sourcewarehouseid"] = dbManager.DataReader["Storage_Location_Id"].ToString();



              //        dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();



              //        SuppliersFixedPOItems.Rows.Add(dr);
              //    }
              //    gv.DataSource = SuppliersFixedPOItems;
              //    gv.DataBind();
              //}



              //public void BomQtyProductionDetails_Select(string SupFixedPOId,string qty, GridView gv)
              //{
              //    if (dbManager.Transaction == null)
              //        dbManager.Open();
              //    _commandText = string.Format("SELECT * FROM [Bom_Details],Material_Master,StorageLocation_Master WHERE  [Bom_Details].Item_Id = [Material_Master].Material_Id and Material_Master.Storage_Location_Id = StorageLocation_Master.StorageLoacation_Id  and Bom_Details.Bom_Id = " + SupFixedPOId);
              //    dbManager.ExecuteReader(CommandType.Text, _commandText);

              //    DataTable SuppliersFixedPOItems = new DataTable();
              //    DataColumn col = new DataColumn();
              //    col = new DataColumn("ItemCode");
              //    SuppliersFixedPOItems.Columns.Add(col);
              //    col = new DataColumn("SourceWarehouse");
              //    SuppliersFixedPOItems.Columns.Add(col);
              //    col = new DataColumn("ReqQty");
              //    SuppliersFixedPOItems.Columns.Add(col);
              //    col = new DataColumn("Transferqty");
              //    SuppliersFixedPOItems.Columns.Add(col);
              //    col = new DataColumn("ItemcodeId");
              //    SuppliersFixedPOItems.Columns.Add(col);
              //    col = new DataColumn("Sourcewarehouseid");
              //    SuppliersFixedPOItems.Columns.Add(col);

              //    while (dbManager.DataReader.Read())
              //    {
              //        DataRow dr = SuppliersFixedPOItems.NewRow();
              //        dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
              //        dr["SourceWarehouse"] = dbManager.DataReader["StorageLocation_Name"].ToString();
              //        dr["ReqQty"] = int.Parse(dbManager.DataReader["Qty"].ToString()) * int.Parse(qty);
              //        dr["Transferqty"] = "0";
              //        dr["Sourcewarehouseid"] = dbManager.DataReader["Storage_Location_Id"].ToString();



              //        dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();



              //        SuppliersFixedPOItems.Rows.Add(dr);
              //    }
              //    gv.DataSource = SuppliersFixedPOItems;
              //    gv.DataBind();
              //}





















        }



        public class Stock
        {
            public string Matid, Colorid, Quantity, Plantid, StoragelocId;
            public string ItemName, ColorName, PlantName, StorageLocName,BlockQty,Issuedqty;

            public Stock()
            {
            }



            public static void StockOnItemandColor(Control ControlForBind,string ItemID,String ColorId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT StorageLoacation_Id,StorageLocation_Name FROM [Stock],Material_Master,StorageLocation_Master,Plant_Master where [Stock].MatId = Material_Master.Material_Id and [Stock].PlantId = Plant_Master.Plant_Id and Stock.StoragelocId = StorageLocation_Master.StorageLoacation_Id and Stock.MatId ='" + ItemID + "' and Stock.ColorId ='" + ColorId + "' ORDER BY Stock.MatId  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "StorageLocation_Name", "StorageLoacation_Id");
                }
            }




            public int AllStock(string Code)
            {
              
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Stock],Material_Master,StorageLocation_Master,Plant_Master where [Stock].MatId = Material_Master.Material_Id and [Stock].PlantId = Plant_Master.Plant_Id and  Stock.StoragelocId = StorageLocation_Master.StorageLoacation_Id and Stock.MatId ='" + Code + "' ORDER BY Stock.MatId  DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.StorageLocName = dbManager.DataReader["StorageLocation_Name"].ToString();
                    this.ItemName = dbManager.DataReader["Material_Code"].ToString();
                    this.PlantName = dbManager.DataReader["Plant_Name"].ToString();
                    this.Quantity = dbManager.DataReader["Quantity"].ToString();
                   
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }





            public int StockOnStorageLocationCS1(string Code, string Color,string Length)
            {

                dbManager.Open();
                
                //_commandText = string.Format("SELECT * FROM [Stock],Material_Master where [Stock].MatId = Material_Master.Material_Id and Stock.ColorId ='" + Color + "' and Stock.MatId ='" + Code + "'  ORDER BY Stock.MatId  DESC ");
                //_commandText = string.Format("select AvailableStocktoBlock = case when ((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "') - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = '" + Code + "' and B.Color_Id = '" + Color + "' )) < 0 then 0 else((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "') - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = '" + Code + "' and B.Color_Id = '" + Color + "' )) end FROM Stock C ");

                _commandText = string.Format("select  AvailableStocktoBlock = case when ((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' and O.Length = '" + Length + "') - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = '" + Code + "' and B.Color_Id = '" + Color + "' and B.Length = '" + Length + "' )) < 0 then 0 else((SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' and O.Length = '" + Length + "') - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = '" + Code + "' and B.Color_Id = '" + Color + "' and B.Length = '" + Length + "' )) end FROM Stock C ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    //this.StorageLocName = dbManager.DataReader["StorageLocation_Name"].ToString();
                    //this.ItemName = dbManager.DataReader["Material_Code"].ToString();
                    //this.PlantName = dbManager.DataReader["Plant_Name"].ToString();
                    this.Quantity = dbManager.DataReader["AvailableStocktoBlock"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }





            public int StockOnStorageLocationCS(string Code, string Color)
            {

                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Stock],Material_Master,StorageLocation_Master,Plant_Master where [Stock].MatId = Material_Master.Material_Id and [Stock].PlantId = Plant_Master.Plant_Id and  Stock.StoragelocId = StorageLocation_Master.StorageLoacation_Id and Stock.ColorId ='" + Color + "' and Stock.MatId ='" + Code + "'  ORDER BY Stock.MatId  DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    //this.StorageLocName = dbManager.DataReader["StorageLocation_Name"].ToString();
                    this.ItemName = dbManager.DataReader["Material_Code"].ToString();
                    //this.PlantName = dbManager.DataReader["Plant_Name"].ToString();
                    this.Quantity = dbManager.DataReader["Quantity"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }




            public string TotalavailableStockafterBlock,PreviousBlockforSo;

            public int StockAvailableAfterBlock(string Code, string Color,String SoId)
            {

                dbManager.Open();
                _commandText = string.Format("select totalstock = (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "'), Blockedstock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' ),availablestock = case when ( (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "') - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' ) ) < 0  then 0 else (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "') - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' ) end,previousBlockStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' and B.So_Id = '" + SoId + "' ) from stock O where O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.TotalavailableStockafterBlock = dbManager.DataReader["availablestock"].ToString();
                    this.PreviousBlockforSo = dbManager.DataReader["previousBlockStock"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }




            public int StockAvailableAfterBlockWithoutSo(string Code, string Color)
            {

                dbManager.Open();
                _commandText = string.Format("select totalstock = (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "'), Blockedstock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' ),availablestock = case when ( (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "') - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' ) ) < 0  then 0 else (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "') - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' ) end from stock O where O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.TotalavailableStockafterBlock = dbManager.DataReader["availablestock"].ToString();
                    this.PreviousBlockforSo = "0";
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }






            public int BlockStock(string Code, string Color)
            {

                dbManager.Open();
                _commandText = string.Format("SELECT sum(Qty) as BlockQty FROM Stock_Block where  Stock_Block.Color_Id ='" + Color + "' and Stock_Block.Item_Code ='" + Code + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.BlockQty = dbManager.DataReader["BlockQty"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }


            public int BlockStockSo(string Code, string Color,string Soid,string Length)
            {

                dbManager.Open();
                _commandText = string.Format("SELECT isnull(sum(Qty),0) as BlockQty FROM Stock_Block where  Stock_Block.Color_Id ='" + Color + "' and Stock_Block.Item_Code ='" + Code + "' and Stock_Block.So_Id = '" + Soid + "' and Stock_Block.Length = '" + Length + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.BlockQty = dbManager.DataReader["BlockQty"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }




            public int PreviousBlockStock(string Code, string Color,string matanaid)
            {

                dbManager.Open();
                _commandText = string.Format("SELECT sum(Qty) as BlockQty FROM Stock_Block where  Stock_Block.Color_Id ='" + Color + "' and Stock_Block.Item_Code ='" + Code + "' and Stock_Block.So_MatId ='"+matanaid+"'     ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.BlockQty = dbManager.DataReader["BlockQty"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }



            public int IssuedStockSO(string Code, string Color, string Soid,string length)
            {

                dbManager.Open();
                _commandText = string.Format("SELECT isnull(sum(Issued_Qty),0) as Issuedqty FROM Material_Issue_Details where  Material_Issue_Details.Color_Id ='" + Color + "' and Material_Issue_Details.Item_Code ='" + Code + "' and Material_Issue_Details.So_Id ='" + Soid + "' and Material_Issue_Details.Length = '" + length + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Issuedqty = dbManager.DataReader["Issuedqty"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }




            public int IssuedStock(string Code, string Color,string Matid)
            {

                dbManager.Open();
                _commandText = string.Format("SELECT sum(Issued_Qty) as Issuedqty FROM Material_Issue_Details where  Material_Issue_Details.Color_Id ='" + Color + "' and Material_Issue_Details.Item_Code ='" + Code + "' and Material_Issue_Details.So_det_Id ='" + Matid + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Issuedqty = dbManager.DataReader["Issuedqty"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }




            public int StockOnStorageLocation(string Code,string StroageLocId)
            {
                
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Stock],Material_Master,StorageLocation_Master,Plant_Master where [Stock].MatId = Material_Master.Material_Id and [Stock].PlantId = Plant_Master.Plant_Id and  Stock.StoragelocId = StorageLocation_Master.StorageLoacation_Id and Stock.MatId ='" + Code + "' and Stock.StoragelocId = '"+StroageLocId+"' ORDER BY Stock.MatId  DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.StorageLocName = dbManager.DataReader["StorageLocation_Name"].ToString();
                    this.ItemName = dbManager.DataReader["Material_Code"].ToString();
                    this.PlantName = dbManager.DataReader["Plant_Name"].ToString();
                    this.Quantity = dbManager.DataReader["Quantity"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }



            //Code, StorageLocation, Color
            public int StockOnStorageLocationCCS(string Code,string Color, string StroageLocId)
            {

                dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Stock],Material_Master,StorageLocation_Master,Plant_Master where [Stock].MatId = Material_Master.Material_Id and [Stock].PlantId = Plant_Master.Plant_Id and  Stock.StoragelocId = StorageLocation_Master.StorageLoacation_Id and Stock.ColorId ='"+Color+"' and Stock.MatId ='" + Code + "' and Stock.StoragelocId = '" + StroageLocId + "' ORDER BY Stock.MatId  DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.StorageLocName = dbManager.DataReader["StorageLocation_Name"].ToString();
                    this.ItemName = dbManager.DataReader["Material_Code"].ToString();
                    this.PlantName = dbManager.DataReader["Plant_Name"].ToString();
                    this.Quantity = dbManager.DataReader["Quantity"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }







            ///////////////////// Stock on ItemCode,Color,Length

            public string TStock;

            public int MCLStockAvailable(string Code, string Color, string length)
            {

                dbManager.Open();
                _commandText = string.Format("select totalstock = (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' and O.Length = '" + length + "')from stock O where O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' and O.Length = '" + length + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.TStock = dbManager.DataReader["totalstock"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }


            public string FreeStock,Mumbaiqty;
            public int SoMCLStockAvailable(string Code, string Color,string Length, string SoId)
            {

                dbManager.Open();
                _commandText = string.Format("select totalstock = (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' and O.Length = '" + Length + "'), Blockedstock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' and B.Length = '" + Length + "' ),availablestock = case when ( (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' and O.Length = '" + Length + "') - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' and B.Length = '" + Length + "' ) ) < 0  then 0 else (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' and O.Length = '" + Length + "') - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' and B.Length = '" + Length + "') end,previousBlockStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' and B.Length = '" + Length + "' and B.So_Id = '" + SoId + "' ) from stock O where O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' and O.Length = '" + Length + "'");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.FreeStock = dbManager.DataReader["availablestock"].ToString();
                    this.PreviousBlockforSo = dbManager.DataReader["previousBlockStock"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }


            
            ///Mumbai Stock Checking With code and color
            public int MumbaiStockAvailable(string Code, string Color)
            {

                dbManager.Open();
                _commandText = string.Format("select * from mumbaistock where matid = '"+Code+"' and colorid = '"+Color+"' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Mumbaiqty = dbManager.DataReader["Quantity"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }








            public int freeMCLStockAvailable(string Code, string Color, string Length)
            {

                dbManager.Open();
                _commandText = string.Format("select totalstock = (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' and O.Length = '" + Length + "'), Blockedstock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' and B.Length = '" + Length + "' ),availablestock = case when ( (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' and O.Length = '" + Length + "') - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' and B.Length = '" + Length + "' ) ) < 0  then 0 else (SELECT  isnull(sum(O.Quantity),0) FROM Stock O WHERE O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' and O.Length = '" + Length + "') - (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code ='" + Code + "' and B.Color_Id = '" + Color + "' and B.Length = '" + Length + "') end from stock O where O.MatId = '" + Code + "' and O.ColorId = '" + Color + "' and O.Length = '" + Length + "'");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.FreeStock = dbManager.DataReader["availablestock"].ToString();
                   
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }




         




        }




        //Methods for Material Receipt

        public class MaterialReceipt
        {
            public string MrId, MrNo, PostingDate, Preparedby;

            public string Mrdetid, matid, ColorId, Qty, Plantid, StorageLocid;


            public MaterialReceipt()
            {
            }

            public static string MaterialReceipt_AutoGenCode()
            {
                return SCM.AutoGenMaxNo("Material_Receipt", "Material_Receipt_No");
            }


            public string MaterialReceipt_Save()
            {
                this.MrNo = MaterialReceipt_AutoGenCode();
                this.MrId = AutoGenMaxId("[Material_Receipt]", "Material_Receipt_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Material_Receipt] VALUES({0},'{1}','{2}',{3}) ", this.MrId, this.MrNo, this.PostingDate, this.Preparedby);
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


            public string MaterialReceipt_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Material_Receipt] SET Material_Receipt_No='{0}',Posting_Date='{1}', Created_By={2} WHERE Material_Receipt_Id={3}", this.MrNo, this.PostingDate, this.Preparedby, this.MrId);
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




            public string MaterialReceipt_Delete(string SupFixedPOId)
            {
                if (DeleteRecord("[Material_Receipt_Details]", "Material_Receipt_Id", SupFixedPOId) == true)
                {
                    if (DeleteRecord("[Material_Receipt]", "Material_Receipt_Id", SupFixedPOId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public static void MaterialReceipt_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Material_Receipt] ORDER BY Material_Receipt_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Material_Receipt_No", "Material_Receipt_Id");
                }
            }


            public int MaterialReceipt_Select(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM Material_Receipt WHERE Material_Receipt.Material_Receipt_Id ='" + SupFixedPOId + "' ORDER BY [Material_Receipt].Material_Receipt_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.MrId = dbManager.DataReader["Material_Receipt_Id"].ToString();
                    this.MrNo = dbManager.DataReader["Material_Receipt_No"].ToString();
                    this.PostingDate = Convert.ToDateTime(dbManager.DataReader["Posting_Date"].ToString()).ToString("dd/MM/yyyy");

                    this.Preparedby = dbManager.DataReader["Created_By"].ToString();


                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }


            public string MaterialReceiptDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Material_Receipt_Details] SELECT ISNULL(MAX(Material_Receipt_Details_Id),0)+1,{0},{1},{2},{3},{4} FROM [Material_Receipt_Details]", this.MrId, this.matid, this.ColorId, this.Qty, this.StorageLocid);
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



            public void MaterialReceiptDetails_Select(string SupFixedPOId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Material_Receipt_Details],Material_Master,Color_Master,StorageLocation_Master WHERE [Material_Receipt_Details].Itemcode_Id=[Material_Master].Material_Id AND Material_Receipt_Details.Storageloc_Id =StorageLocation_Master.StorageLoacation_Id   and Color_Master.Color_Id = Material_Receipt_Details.Color_Id and Material_Receipt_Details.Material_Receipt_Id=" + SupFixedPOId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SuppliersFixedPOItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Warehouse");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("WarehouseId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Color");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SuppliersFixedPOItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SuppliersFixedPOItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Qty"] = dbManager.DataReader["Quantity"].ToString();
                    dr["Warehouse"] = dbManager.DataReader["StorageLocation_Name"].ToString();
                    dr["WarehouseId"] = dbManager.DataReader["Storageloc_Id"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();

                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();

                    SuppliersFixedPOItems.Rows.Add(dr);
                }
                gv.DataSource = SuppliersFixedPOItems;
                gv.DataBind();
            }



            public int MaterialReceiptDetails_Delete(string SupFixedPOId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Material_Receipt_Details] WHERE Material_Receipt_Id = {0}", SupFixedPOId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }






          //Material Transfer for manufacture

            public string transferqty, sourcewarehouseid, targetwarehouseid, scrapwarehouseid,podetid;

            public string MaterialTransferManufacutere_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [ProductionOrder_Details] SET Transferqty ={0},Sourcewarehouse_id={1}, Targetwarehouse_Id={2},Scrapwarehouse_id={3} WHERE ProductionOder_det_Id={4}", this.transferqty, this.sourcewarehouseid, this.targetwarehouseid, this.scrapwarehouseid,this.podetid);
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




            public string StockMinus_Update(string productid, string Qty, string colorid, string storagelocid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid,  "StoragelocId", storagelocid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=CONVERT(BIGINT,Quantity)-{0} WHERE MatId = {1}  and ColorId = {2}  and StoragelocId ={3} ", Qty, productid, colorid, storagelocid);
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


            public string StockPuls_Update(string productid, string Qty, string colorid, string storagelocid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "StoragelocId", storagelocid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=CONVERT(BIGINT,Quantity)+{0} WHERE MatId = {1}  and ColorId = {2}  and StoragelocId ={3} ", Qty, productid, colorid, storagelocid);
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

                    _commandText = string.Format("INSERT INTO [Stock] VALUES ({0},{1},{2},{3})", productid, colorid, Qty, storagelocid);
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



            public string Stock_Update(string productid, string Qty, string plantid, string colorid, string storagelocid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "PlantId", plantid, "StoragelocId", storagelocid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=CONVERT(BIGINT,Quantity)+{0} WHERE MatId = {1}  and ColorId = {2} and PlantId={3} and StoragelocId ={4} ", Qty, productid, colorid, plantid, storagelocid);
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

                    _commandText = string.Format("INSERT INTO [Stock] VALUES ({0},{1},{2},{3},{4})", productid, colorid, Qty, plantid, storagelocid);
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





        }




        //Methods for Supplier Quotation Form
        public class SupplierQuotation
        {
            public string QuotId, QuotNo, QuotDate,  SupId,MateriralReqId, PaymentTermsId, TermsCondtionId, Discount, Tax, GrandTotal, Preparedby, Approvedby, Status;

            public string QuoDetId, CodeId,  Series, Quantity, Uom,ColorId,Rate,Amount,SoId,Somatid,Requiredfor;




            public SupplierQuotation()
            {
            }

            public static string SupplierQuotation_AutoGenCode()
            {
                return AutoGenMaxNo("Supplier_Quotation_Master", "Sup_Quo_No");
            }

            public string SupplierQuotation_Save()
            {

                this.QuotId = AutoGenMaxId("[Supplier_Quotation_Master]", "Sup_Quo_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Supplier_Quotation_Master] SELECT ISNULL(MAX(Sup_Quo_Id),0)+1,'{0}','{1}',{2},{3},'{4}','{5}','{6}','{7}','{8}',{9},{10},'{11}' from Supplier_Quotation_Master", this.QuotNo, this.QuotDate, this.SupId, this.MateriralReqId, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby, this.Status);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                //if (this.MateriralReqId != "0")
                //{
                  
                //    _commandText = string.Format("UPDATE [MaterialRequest] SET Status='Quatation Done' WHERE MaterialRequest_Id ={1}", this.Status, this.MateriralReqId);
                //    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                //}




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

          

            public string SupplierQuotation_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Supplier_Quotation_Master] SET Sup_Quo_Date='{0}',Sup_Id={1},Matrequest_Id={2},Paymentterms_Id='{3}',TermsConditions_Id='{4}',Discount='{5}',Tax='{6}',GrandTotal='{7}',PreparedBy={8},ApprovedBy={9} WHERE Sup_Quo_Id={10}", this.QuotDate, this.SupId, this.MateriralReqId, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby,this.QuotId);
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

            public string SupplierQuotation_Delete(string QuotationId)
            {
              
                if (DeleteRecord("[Supplier_Quotation_Details]", "Sup_Quo_Id", QuotationId) == true)
                {
                    if (DeleteRecord("[Supplier_Quotation_Master]", "Sup_Quo_Id", QuotationId) == true)
                    {

                     
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                }
                else
                {
                    
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }


            public string Length;
            public string SupplierQuotationDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Supplier_Quotation_Details] SELECT ISNULL(MAX(Sup_Quo_Det_id),0)+1,{0},{1},'{2}','{3}',{4},'{5}','{6}','{7}',{8},{9},'{10}',{11} FROM [Supplier_Quotation_Details]", this.QuotId, this.CodeId, this.Quantity, this.Uom, this.ColorId, this.Rate, this.Amount, this.Series,this.SoId,this.Somatid,this.Requiredfor,this.Length);
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

            public int SupplierQuotationDetails_Delete(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Supplier_Quotation_Details] WHERE Sup_Quo_Id = {0}", QuotationId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }





            public int SupplierQuotation_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Supplier_Quotation_Master] WHERE Supplier_Quotation_Master.Sup_Quo_Id='" + QuotationId + "' ORDER BY Supplier_Quotation_Master.Sup_Quo_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.QuotId = dbManager.DataReader["Sup_Quo_Id"].ToString();
                    this.QuotNo = dbManager.DataReader["Sup_Quo_No"].ToString();
                    this.QuotDate = Convert.ToDateTime(dbManager.DataReader["Sup_Quo_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SupId = dbManager.DataReader["Sup_Id"].ToString();
                    this.MateriralReqId = dbManager.DataReader["Matrequest_Id"].ToString();
                    this.PaymentTermsId = dbManager.DataReader["Paymentterms_Id"].ToString();
                    this.TermsCondtionId = dbManager.DataReader["TermsConditions_Id"].ToString();
                    this.Discount = dbManager.DataReader["Discount"].ToString();
                    this.Tax = dbManager.DataReader["Tax"].ToString();
                   
                    this.GrandTotal = dbManager.DataReader["GrandTotal"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();
             
                    this.Status = dbManager.DataReader["Status"].ToString();


                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }


            public string SupplierQuotationApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                this.Status = "Approved";
                _commandText = string.Format("UPDATE [Supplier_Quotation_Master] SET ApprovedBy={0} WHERE Sup_Quo_Id ={1}", this.Approvedby, this.QuotId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _commandText = string.Format("UPDATE [Supplier_Quotation_Master] SET Status='{0}' WHERE Sup_Quo_Id ={1}", this.Status, this.QuotId);
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

            public string MaterialRequestStatus_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [MaterialRequest] SET Status='Qutation Aprroved' WHERE MaterialRequest_Id ={0}",  this.MateriralReqId);
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



            public void SupplierQuotOrder_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Supplier_Quotation_Details],[Material_Master],Color_Master where Supplier_Quotation_Details.ItemCode=[Material_Master].Material_Id AND " +
                                               "Supplier_Quotation_Details.Color_Id = Color_Master.Color_Id and [Supplier_Quotation_Details].Sup_Quo_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("CodeNo");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ItemcodeId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesQuotationItems.Columns.Add(col);


                col = new DataColumn("SoId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SoMatId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Requestfor");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("Length");
                SalesQuotationItems.Columns.Add(col);


               


                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["CodeNo"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Series"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Uom"] = dbManager.DataReader["Uom"].ToString();
                    dr["Qty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["Rate"] = dbManager.DataReader["Rate"].ToString();
                    dr["Amount"] = dbManager.DataReader["Amount"].ToString();
                    dr["ItemcodeId"] = dbManager.DataReader["ItemCode"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();
                    dr["SoMatId"] = dbManager.DataReader["SO_Mat_Id"].ToString();
                    dr["Requestfor"] = dbManager.DataReader["Requiredfor"].ToString();

                    dr["Length"] = dbManager.DataReader["Length"].ToString();

                   

                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }


         

            public static void SupplierQuotation_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Sup_Quo_Id,Sup_Quo_No+'('+SUP_NAME+')' as quono  FROM [Supplier_Quotation_Master],Supplier_Master where [Supplier_Quotation_Master].Sup_Id = Supplier_Master.SUP_ID  ORDER BY Sup_Quo_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "quono", "Sup_Quo_Id");
                }
            }



        }








        //Methods for Supplier Glass Quotation Form
        public class SupplierGlassQuotation
        {
            public string QuotId, QuotNo, QuotDate, SupId, SoId, PaymentTermsId, TermsCondtionId, Discount, Tax, GrandTotal, Preparedby, Approvedby, Status;

            public string QuoDetId, WindowCode, Thickness, Description, Width, Height, Unit, Area,Weight,ReqQty,Rate,Amount;




            public SupplierGlassQuotation()
            {
            }

            public static string SupplierGlassQuotation_AutoGenCode()
            {
                return AutoGenMaxNo("Glass_Quatation_Master", "Sup_GQuo_No");
            }

            public string SupplierGlassQuotation_Save()
            {

                this.QuotId = AutoGenMaxId("[Glass_Quatation_Master]", "Sup_GQuo_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Glass_Quatation_Master] SELECT ISNULL(MAX(Sup_GQuo_Id),0)+1,'{0}','{1}',{2},{3},'{4}','{5}','{6}','{7}','{8}',{9},{10},'{11}' from Glass_Quatation_Master", this.QuotNo, this.QuotDate, this.SupId, this.SoId, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby, this.Status);
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



            public string SupplierGlassQuotation_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Glass_Quatation_Master] SET Sup_GQuo_Date='{0}',Sup_Id={1},Po_Id={2},Paymentterms_Id='{3}',TermsConditions_Id='{4}',Discount='{5}',Tax='{6}',GrandTotal='{7}',PreparedBy={8},ApprovedBy={9} WHERE Sup_Quo_Id={10}", this.QuotDate, this.SupId, this.SoId, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby, this.QuotId);
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

            public string SupplierGlassQuotation_Delete(string QuotationId)
            {

                if (DeleteRecord("[GlassQuatation_Details]", "Sup_GQuo_Id", QuotationId) == true)
                {
                    if (DeleteRecord("[Glass_Quatation_Master]", "Sup_GQuo_Id", QuotationId) == true)
                    {

                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                }
                else
                {

                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }

            public string SupplierGlassQuotationDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [GlassQuatation_Details] SELECT ISNULL(MAX(Sup_GQuo_Det_id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}' FROM [GlassQuatation_Details]", this.QuotId, this.WindowCode, this.Thickness, this.Description, this.Width, this.Height, this.Unit, this.Area, this.Weight, this.ReqQty, this.Rate, this.Amount);
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

            public int SupplierGlassQuotationDetails_Delete(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [GlassQuatation_Details] WHERE Sup_GQuo_Id = {0}", QuotationId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }





            public int SupplierGlassQuotation_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Glass_Quatation_Master] WHERE Glass_Quatation_Master.Sup_GQuo_Id='" + QuotationId + "' ORDER BY Sup_GQuo_Id DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.QuotId = dbManager.DataReader["Sup_GQuo_Id"].ToString();
                    this.QuotNo = dbManager.DataReader["Sup_GQuo_No"].ToString();
                    this.QuotDate = Convert.ToDateTime(dbManager.DataReader["Sup_GQuo_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SupId = dbManager.DataReader["Sup_Id"].ToString();
                    this.SoId = dbManager.DataReader["Po_Id"].ToString();
                    this.PaymentTermsId = dbManager.DataReader["Paymentterms_Id"].ToString();
                    this.TermsCondtionId = dbManager.DataReader["TermsConditions_Id"].ToString();
                    this.Discount = dbManager.DataReader["Discount"].ToString();
                    this.Tax = dbManager.DataReader["Tax"].ToString();

                    this.GrandTotal = dbManager.DataReader["GrandTotal"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();

                    this.Status = dbManager.DataReader["Status"].ToString();


                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }


            public string SupplierGlassQuotationApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                this.Status = "Approved";
                _commandText = string.Format("UPDATE [Glass_Quatation_Master] SET ApprovedBy={0},Status='Approved' WHERE Sup_GQuo_Id ={1}", this.Approvedby, this.QuotId);
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

          

            public void GlassQuotatation_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [GlassQuatation_Details] where [GlassQuatation_Details].Sup_GQuo_Id =" + QuotationId + "");
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
                col = new DataColumn("Unit");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Area");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Weight");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Quantity");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesQuotationItems.Columns.Add(col);


                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["WindowCode"] = dbManager.DataReader["WindowCode"].ToString();
                    dr["Thickness"] = dbManager.DataReader["Thickness"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["Height"] = dbManager.DataReader["Height"].ToString();
                    dr["Unit"] = dbManager.DataReader["Unit"].ToString();
                    dr["Area"] = dbManager.DataReader["Area"].ToString();
                    dr["Weight"] = dbManager.DataReader["Weight"].ToString();
                    dr["Quantity"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["Amount"] = dbManager.DataReader["Amount"].ToString();
                    dr["Rate"] = dbManager.DataReader["Rate"].ToString();
                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }




            public static void GlassQuotation_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Glass_Quatation_Master] ORDER BY Sup_GQuo_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Sup_GQuo_No", "Sup_GQuo_Id");
                }
            }



        }














        /////// Methods for Rquest Quatation

        //Methods for Supplier Request Quotation Form
        public class SupplierRequestQuotation
        {
            public string ReqQuotId, ReqQuotNo, ReqQuotDate, MateriralReqId,Remarks, Preparedby, Approvedby, Status;

            public string ReqQuoDetId, CodeId, Series, Quantity, Uom, ColorId;

            public string SupReqSupId, SupId;




            public SupplierRequestQuotation()
            {
            }

            public static string SupplierRequestQuotation_AutoGenCode()
            {
                return AutoGenMaxNo("SupplierRequest_Quotation_Master", "ReqSup_Quo_No");
            }


            public string SupplierRequestQuotation_Save()
            {

                this.ReqQuotId = AutoGenMaxId("[SupplierRequest_Quotation_Master]", "ReqSup_Quo_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [SupplierRequest_Quotation_Master] SELECT ISNULL(MAX(ReqSup_Quo_Id),0)+1,'{0}','{1}',{2},'{3}',{4},{5},'{6}' from SupplierRequest_Quotation_Master", this.ReqQuotNo, this.ReqQuotDate, this.MateriralReqId, this.Remarks, this.Preparedby, this.Approvedby, this.Status);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                //if (this.MateriralReqId != "0")
                //{
                //    _commandText = string.Format("UPDATE [MaterialRequest] SET Status='Requested for Quatation' WHERE MaterialRequest_Id ={0}",  this.MateriralReqId);
                //    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                //}

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

            public string SupplierRequestQuotation_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [SupplierRequest_Quotation_Master] SET ReqSup_Quo_Date='{0}',Matrequest_Id={1},Remarks='{2}',PreparedBy={3},ApprovedBy={4},Status='{5}' WHERE ReqSup_Quo_Id = {6}", this.ReqQuotDate,  this.MateriralReqId, this.Remarks,this.Preparedby, this.Approvedby, this.Status, this.ReqQuotId);
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

            public string SupplierRequestQuotation_Delete(string QuotationId)
            {

                if (DeleteRecord("[SupplierRequest_Quotation_Suppliers]", "SupReq_Quo_Id", QuotationId) == true)
                {
                    if (DeleteRecord("[SupplierRequest_Quotation_Details]", "SupReq_Quo_Id", QuotationId) == true)
                    {
                        if (DeleteRecord("[SupplierRequest_Quotation_Master]", "ReqSup_Quo_Id", QuotationId) == true)
                        {

                            _returnStringMessage = "Data Deleted Successfully";
                        }
                        else
                        {
                            _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                        }
                    }
                    else
                    {
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                }
                else
                {

                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }





            public string reqestedfor, soid, somatid;

            public string SupplierRequestQuotationDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [SupplierRequest_Quotation_Details] SELECT ISNULL(MAX(SupReq_Quo_Det_id),0)+1,{0},{1},'{2}',{3},'{4}',{5},{6} FROM [SupplierRequest_Quotation_Details]", this.ReqQuotId, this.CodeId, this.Quantity, this.ColorId, this.reqestedfor,this.soid,this.somatid);
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

            public int SupplierRequestQuotationDetails_Delete(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [SupplierRequest_Quotation_Details] WHERE SupReq_Quo_Id = {0}", QuotationId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }





            public string SupplierDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [SupplierRequest_Quotation_Suppliers] SELECT ISNULL(MAX(SupReq_Sup_Id),0)+1,{0},{1} FROM [SupplierRequest_Quotation_Suppliers]", this.ReqQuotId, this.SupId);
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

            public int SupplierDetails_Delete(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [SupplierRequest_Quotation_Suppliers] WHERE SupReq_Quo_Id = {0}", QuotationId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }
          
            public int SupplierRequestQuotation_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SupplierRequest_Quotation_Master] WHERE SupplierRequest_Quotation_Master.ReqSup_Quo_Id='" + QuotationId + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ReqQuotId = dbManager.DataReader["ReqSup_Quo_Id"].ToString();
                    this.ReqQuotNo = dbManager.DataReader["ReqSup_Quo_No"].ToString();
                    this.ReqQuotDate = Convert.ToDateTime(dbManager.DataReader["ReqSup_Quo_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.MateriralReqId = dbManager.DataReader["Matrequest_Id"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }



            public void SupplierRequestQuotOrder_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SupplierRequest_Quotation_Details],[Material_Master],Color_Master where SupplierRequest_Quotation_Details.ItemCode=[Material_Master].Material_Id AND " +
                                               "SupplierRequest_Quotation_Details.Color_Id = Color_Master.Color_Id and [SupplierRequest_Quotation_Details].SupReq_Quo_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("CodeNo");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesQuotationItems.Columns.Add(col);
              
                col = new DataColumn("ItemcodeId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesQuotationItems.Columns.Add(col);


                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["CodeNo"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Series"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Uom"] = dbManager.DataReader["Uom"].ToString();
                    dr["Qty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["ItemcodeId"] = dbManager.DataReader["ItemCode"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();

                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }


            public void SupplierRequestSupplier_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [SupplierRequest_Quotation_Suppliers],[Supplier_Master] where SupplierRequest_Quotation_Suppliers.Sup_Id=[Supplier_Master].SUP_ID and [SupplierRequest_Quotation_Suppliers].SupReq_Quo_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("VendorName");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ContactPerson");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("MobileNo");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Email");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("VendorId");
                SalesQuotationItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["VendorName"] = dbManager.DataReader["SUP_NAME"].ToString();
                    dr["ContactPerson"] = dbManager.DataReader["SUP_CONTACT_PERSON"].ToString();
                    dr["MobileNo"] = dbManager.DataReader["SUP_MOBILE"].ToString();
                    dr["Email"] = dbManager.DataReader["SUP_EMAIL"].ToString();
                    dr["VendorId"] = dbManager.DataReader["Sup_Id"].ToString();
                    
                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }


        }



        /////// Methods for Glass Rquest Quatation

        //Methods for Glass Request Quotation Form
        public class GlassRequestQuotation
        {
            public string GlassReqQuotId, GlassReqQuotNo, GlassReqQuotDate, SoId, Remarks, Preparedby, Approvedby, Status;

            public string GlassReqQuoDetId, GlassWindowcode, GlassThickness, GlassDescription, GlassWidth, Glassheight, GlassQuantity, GlassUnit, GlassArea, GlassWeight;

            public string GlassSupReqSupId, SupId;




            public GlassRequestQuotation()
            {
            }

            public static string GlassRequestQuotation_AutoGenCode()
            {
                return AutoGenMaxNo("GlassRequest_Quatation_Master", "GlassReqSup_Quo_No");
            }


            public string GlassRequestQuotation_Save()
            {

                this.GlassReqQuotId = AutoGenMaxId("[GlassRequest_Quatation_Master]", "GlassReqSup_Quo_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [GlassRequest_Quatation_Master] SELECT ISNULL(MAX(GlassReqSup_Quo_Id),0)+1,'{0}','{1}',{2},'{3}',{4},{5},'{6}' from GlassRequest_Quatation_Master", this.GlassReqQuotNo, this.GlassReqQuotDate, this.SoId, this.Remarks, this.Preparedby, this.Approvedby, this.Status);
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

            public string GlassRequestQuotation_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [GlassRequest_Quatation_Master] SET GlassReqSup_Quo_Date='{0}',So_Id={1},Remarks='{2}',PreparedBy={3},ApprovedBy={4},Status='{5}' WHERE GlassReqSup_Quo_Id = {6}", this.GlassReqQuotDate, this.SoId, this.Remarks, this.Preparedby, this.Approvedby, this.Status,this.GlassReqQuotId);
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

            public string GlassRequestQuotation_Delete(string QuotationId)
            {

                if (DeleteRecord("[GlassRequest_Quatation_Supplier]", "GlassReq_Id", QuotationId) == true)
                {
                    if (DeleteRecord("[GlassRequest_Quatation_Details]", "GlassReq_Id", QuotationId) == true)
                    {
                        if (DeleteRecord("[GlassRequest_Quatation_Master]", "GlassReqSup_Quo_Id", QuotationId) == true)
                        {

                            _returnStringMessage = "Data Deleted Successfully";
                        }
                        else
                        {
                            _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                        }
                    }
                    else
                    {
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                }
                else
                {

                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }







            public string GlassRequestQuotationDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [GlassRequest_Quatation_Details] SELECT ISNULL(MAX(GlassReq_Quo_Det_Id),0)+1,{0},'{1}','{2}','{3}',{4},'{5}',{6},'{7}','{8}','{9}' FROM [GlassRequest_Quatation_Details]", this.GlassReqQuotId, this.GlassWindowcode, this.GlassThickness, this.GlassDescription, this.GlassWidth, this.Glassheight, this.GlassQuantity, this.GlassUnit, this.GlassArea, this.GlassWeight);
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

            public int GlassRequestQuotationDetails_Delete(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [GlassRequest_Quatation_Details] WHERE GlassReq_Id = {0}", QuotationId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }





            public string SupplierDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [GlassRequest_Quatation_Supplier] SELECT ISNULL(MAX(GlassReq_Sup_Id),0)+1,{0},{1} FROM [GlassRequest_Quatation_Supplier]", this.GlassReqQuotId, this.SupId);
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

            public int SupplierDetails_Delete(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [GlassRequest_Quatation_Supplier] WHERE GlassReq_Id = {0}", QuotationId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int SupplierRequestQuotation_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [GlassRequest_Quatation_Master] WHERE GlassRequest_Quatation_Master.GlassReqSup_Quo_Id='" + QuotationId + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.GlassReqQuotId = dbManager.DataReader["GlassReqSup_Quo_Id"].ToString();
                    this.GlassReqQuotNo = dbManager.DataReader["GlassReqSup_Quo_No"].ToString();
                    this.GlassReqQuotDate = Convert.ToDateTime(dbManager.DataReader["GlassReqSup_Quo_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SoId = dbManager.DataReader["So_Id"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }



            public void SupplierRequestQuotOrder_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [GlassRequest_Quatation_Details] where [GlassRequest_Quatation_Details].GlassReq_Id = " + QuotationId + "");
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


            public void SupplierRequestSupplier_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [GlassRequest_Quatation_Supplier],[Supplier_Master] where GlassRequest_Quatation_Supplier.Sup_Id=[Supplier_Master].SUP_ID and [GlassRequest_Quatation_Supplier].GlassReq_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("VendorName");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ContactPerson");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("MobileNo");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Email");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("VendorId");
                SalesQuotationItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["VendorName"] = dbManager.DataReader["SUP_NAME"].ToString();
                    dr["ContactPerson"] = dbManager.DataReader["SUP_CONTACT_PERSON"].ToString();
                    dr["MobileNo"] = dbManager.DataReader["SUP_MOBILE"].ToString();
                    dr["Email"] = dbManager.DataReader["SUP_EMAIL"].ToString();
                    dr["VendorId"] = dbManager.DataReader["Sup_Id"].ToString();

                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }


        }


        //Methods for Supplier Po Form
        public class SupPo
        {
            public string PoId, PONo, PoDate, SupId, MateriralReqId, PaymentTermsId, TermsCondtionId, Discount, Tax, GrandTotal, Preparedby, Approvedby, Status,Insurance,frieght,Packing,transport,Writeinsurance,WriteFreight,Indentnos,CustomerNo,Message;

            public string PoDetId, CodeId, Series, Quantity, Uom, ColorId, Rate, Amount,reqdate,Length;


            public string PODocdate, PODocRemarks, PODocuments,Remarks,Deliverydate,Deliverto;

            public SupPo()
            {
            }

            public static string SupPo_AutoGenCode()
            {
                return AutoGenMaxNo("Supplier_Po_Master", "Sup_PO_No");
            }

            public string SupPo_Save()
            {

                this.PoId = AutoGenMaxId("[Supplier_Po_Master]", "Sup_PO_Id");
                this.PONo = AutoGenMaxNo("Supplier_Po_Master", "Sup_PO_No");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Supplier_Po_Master] SELECT ISNULL(MAX(Sup_PO_Id),0)+1,'{0}','{1}',{2},{3},'{4}','{5}','{6}','{7}','{8}',{9},{10},'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}' from Supplier_Po_Master", this.PONo, this.PoDate, this.SupId, this.MateriralReqId, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby, this.Status,this.Insurance,this.frieght,this.Packing,this.transport,this.Writeinsurance,this.WriteFreight,this.Indentnos,this.CustomerNo,this.Message);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                if (this.MateriralReqId != "0")
                {
                    _commandText = string.Format("UPDATE [Supplier_Quotation_Master] SET Status='Ordered' WHERE Sup_Quo_Id ={0}", this.MateriralReqId);
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







            public string SupPoStatus_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Supplier_Po_Master] SET Status='{0}' WHERE Sup_PO_Id={1}",this.Status,this.PoId);
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

           

            public string GlassSupPoStatus_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Glass_PO_Master] SET Status='{0}',Message ='{2}',DeliveryDate='{3}',Deliverto='{4}' WHERE Sup_GPO_Id={1}", this.Status, this.PoId, this.Remarks, this.Deliverydate,this.Deliverto);
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







            public string SupPo_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Supplier_Po_Master] SET Sup_PO_Date='{0}',Sup_Id={1},Matrequest_Id={2},Paymentterms_Id='{3}',TermsConditions_Id='{4}',Discount='{5}',Tax='{6}',GrandTotal='{7}',PreparedBy={8},ApprovedBy={9},Status='{10}',Insurance='{11}',Frieght='{12}',Packing='{13}',Transport='{14}',Write_Insurance='{15}',Write_Frieght='{16}',IndentNo='{17}',CustomerNo='{18}',Message='{19}' WHERE Sup_PO_Id={20}", this.PoDate, this.SupId, this.MateriralReqId, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby, this.Status, this.Insurance, this.frieght, this.Packing, this.transport, this.Writeinsurance, this.WriteFreight, this.Indentnos, this.CustomerNo,this.Message, this.PoId);
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

            public string SupPo_Delete(string QuotationId)
            {

                //if (DeleteRecord("[Supplier_Po_Details]", "Sup_PO_Id", QuotationId) == true)
                //{
                    if (DeleteRecord("[Supplier_Po_Master]", "Sup_PO_Id", QuotationId) == true)
                    {

                        DeleteRecord("[Supplier_Po_Details]", "Sup_PO_Id", QuotationId);
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                //}
                //else
                //{

                //    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                //}
                return _returnStringMessage;
            }


            public string ReceivedQty, RemainingQty, ItemStatus, SOid,SoMatid,RequiredFor,Area;

            public string SupPoDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //_commandText = string.Format("INSERT INTO [Supplier_Po_Details] SELECT ISNULL(MAX(Sup_PO_Det_id),0)+1,{0},{1},{2},'{3}',{4},'{5}','{6}','{7}','{8}',{9},{10},'{11}',{12},{13},'{14}','{15}' FROM [Supplier_Po_Details]", this.PoId, this.CodeId, this.Quantity, this.Uom, this.ColorId, this.Rate, this.Amount, this.Series,this.reqdate,this.ReceivedQty,this.RemainingQty,this.ItemStatus,this.SOid,this.SoMatid,this.RequiredFor,this.Length);
                //_returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);



                _commandText = string.Format("INSERT INTO [Supplier_Po_Details] SELECT ISNULL(MAX(Sup_PO_Det_id),0)+1,{0},{1},'{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},{13},'{14}',{15},'{16}' FROM [Supplier_Po_Details]", this.PoId, this.CodeId, this.Quantity, this.Uom, this.ColorId, this.Rate, this.Amount, this.Series, this.reqdate, this.ReceivedQty, this.RemainingQty, this.ItemStatus, this.SOid, this.SoMatid, this.RequiredFor, this.Length,this.Area);
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

            public int SupPoDetails_Delete(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Supplier_Po_Details] WHERE Sup_PO_Id = {0}", QuotationId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }


            public string Sname, SContact, Smobile;

            public int SupPoname_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Supplier_Po_Master],Supplier_Master WHERE Supplier_Po_Master.Sup_Id = Supplier_Master.SUP_ID and Supplier_Po_Master.Sup_PO_Id='" + QuotationId + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.PoId = dbManager.DataReader["Sup_PO_Id"].ToString();
                    this.PONo = dbManager.DataReader["Sup_PO_No"].ToString();
                    this.PoDate = Convert.ToDateTime(dbManager.DataReader["Sup_PO_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SupId = dbManager.DataReader["Sup_Id"].ToString();
                    this.MateriralReqId = dbManager.DataReader["Matrequest_Id"].ToString();
                    this.PaymentTermsId = dbManager.DataReader["Paymentterms_Id"].ToString();
                    this.TermsCondtionId = dbManager.DataReader["TermsConditions_Id"].ToString();
                    this.Discount = dbManager.DataReader["Discount"].ToString();
                    this.Tax = dbManager.DataReader["Tax"].ToString();
                  //  this.TermsCondtionId = dbManager.DataReader["TermsConditions_Id"].ToString();
                  //  this.Discount = dbManager.DataReader["Discount"].ToString();
                  //  this.Tax = dbManager.DataReader["Tax"].ToString();
                    this.GrandTotal = dbManager.DataReader["GrandTotal"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();

                    this.Status = dbManager.DataReader["Status"].ToString();
                    this.SContact = dbManager.DataReader["SUP_ADDRESS"].ToString();
                    this.Smobile = dbManager.DataReader["SUP_MOBILE"].ToString();
                    this.Sname = dbManager.DataReader["SUP_NAME"].ToString();


                    this.Packing = dbManager.DataReader["Packing"].ToString();
                    this.Insurance = dbManager.DataReader["Insurance"].ToString();
                    this.transport = dbManager.DataReader["Transport"].ToString();
                    this.frieght = dbManager.DataReader["Frieght"].ToString();

                    this.Writeinsurance = dbManager.DataReader["Write_Insurance"].ToString();
                    this.WriteFreight = dbManager.DataReader["Write_Frieght"].ToString();
                    this.Indentnos = dbManager.DataReader["IndentNo"].ToString();

                    this.CustomerNo = dbManager.DataReader["CustomerNo"].ToString();



                    this.Message = dbManager.DataReader["Message"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public int SupPo_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Supplier_Po_Master] WHERE Supplier_Po_Master.Sup_PO_Id='" + QuotationId + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.PoId = dbManager.DataReader["Sup_PO_Id"].ToString();
                    this.PONo = dbManager.DataReader["Sup_PO_No"].ToString();
                    this.PoDate = Convert.ToDateTime(dbManager.DataReader["Sup_PO_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SupId = dbManager.DataReader["Sup_Id"].ToString();
                    this.MateriralReqId = dbManager.DataReader["Matrequest_Id"].ToString();
                    this.PaymentTermsId = dbManager.DataReader["Paymentterms_Id"].ToString();
                    this.TermsCondtionId = dbManager.DataReader["TermsConditions_Id"].ToString();
                    this.Discount = dbManager.DataReader["Discount"].ToString();
                    this.Tax = dbManager.DataReader["Tax"].ToString();


                    this.Insurance = dbManager.DataReader["Insurance"].ToString();
                    this.frieght = dbManager.DataReader["Frieght"].ToString();
                    this.Packing = dbManager.DataReader["Packing"].ToString();
                    this.transport = dbManager.DataReader["Transport"].ToString();

                    this.Writeinsurance = dbManager.DataReader["Write_Insurance"].ToString();
                    this.WriteFreight = dbManager.DataReader["Write_Frieght"].ToString();
                    this.Indentnos = dbManager.DataReader["IndentNo"].ToString();


                    this.GrandTotal = dbManager.DataReader["GrandTotal"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();

                    this.Status = dbManager.DataReader["Status"].ToString();

                    this.CustomerNo = dbManager.DataReader["CustomerNo"].ToString();

                    this.Message = dbManager.DataReader["Message"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }



            public string PoStatusRemarks;

            public string SupPO_Status(string PoId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Sup_PO_Status]", "Sup_PO_ID", PoId) == true)
                {
                    _commandText = string.Format("update Sup_PO_status set Staus='{0}',Amount_Paid='{1}',Delivery_OPtion=getdate(), PreparedBy='{2}',Remarks='{3}' where Sup_PO_ID ={4}  ", this.Status, this.Rate, this.Preparedby,this.PoStatusRemarks, this.PoId);
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
                    _commandText = string.Format("Insert into Sup_PO_status SELECT ISNULL(MAX(SPO_StatusId),0)+1,'{0}',getdate(),{1},'{2}','{3}',getdate(),{4},'{5}' from Sup_PO_status", this.PONo,  this.PoId, this.Status, this.Rate, this.Preparedby, this.PoStatusRemarks);
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




            public int SupPoSupQua_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Supplier_Po_Master] WHERE Supplier_Po_Master.Matrequest_Id='" + QuotationId + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.PoId = dbManager.DataReader["Sup_PO_Id"].ToString();
                    this.PONo = dbManager.DataReader["Sup_PO_No"].ToString();
                    this.PoDate = Convert.ToDateTime(dbManager.DataReader["Sup_PO_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SupId = dbManager.DataReader["Sup_Id"].ToString();
                    this.MateriralReqId = dbManager.DataReader["Matrequest_Id"].ToString();
                    this.PaymentTermsId = dbManager.DataReader["Paymentterms_Id"].ToString();
                    this.TermsCondtionId = dbManager.DataReader["TermsConditions_Id"].ToString();
                    this.Discount = dbManager.DataReader["Discount"].ToString();
                    this.Tax = dbManager.DataReader["Tax"].ToString();

                    this.GrandTotal = dbManager.DataReader["GrandTotal"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();

                    this.Status = dbManager.DataReader["Status"].ToString();


                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }




            public string SupPoApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [Supplier_Po_Master] SET ApprovedBy={0},Status='Approved' WHERE Sup_PO_Id ={1}", this.Approvedby, this.PoId);
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


            public string SupPoQuatationApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [Supplier_Quotation_Master] SET Status = 'Close' WHERE Sup_Quo_Id ={0}", this.PoId);
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


            public void SupPoOrder_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Supplier_Po_Details],[Material_Master],Color_Master where Supplier_Po_Details.ItemCode=[Material_Master].Material_Id AND " +
                                               "Supplier_Po_Details.Color_Id = Color_Master.Color_Id and [Supplier_Po_Details].Sup_PO_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("CodeNo");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ItemcodeId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RequiredDate");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("ReceivedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RemainingQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Status");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("PoDetId");
                SalesQuotationItems.Columns.Add(col);


                col = new DataColumn("BarLength");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("AcceptedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RejectedQty");
                SalesQuotationItems.Columns.Add(col);


                col = new DataColumn("SoId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SoMatId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Requestfor");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("Length");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("Area");
                SalesQuotationItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["CodeNo"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Series"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Uom"] = dbManager.DataReader["Uom"].ToString();
                    dr["Qty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["Rate"] = dbManager.DataReader["Rate"].ToString();
                    dr["Amount"] = dbManager.DataReader["Amount"].ToString();
                    dr["ItemcodeId"] = dbManager.DataReader["ItemCode"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["RequiredDate"] = Convert.ToDateTime(dbManager.DataReader["Req_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    dr["ReceivedQty"] = "0";
                    dr["RemainingQty"] = dbManager.DataReader["RemainingQty"].ToString();
                    dr["Status"] = dbManager.DataReader["Status"].ToString();

                    dr["PoDetId"] = dbManager.DataReader["Sup_PO_Det_id"].ToString();
                    dr["BarLength"] = dbManager.DataReader["Bar_Length"].ToString();

                    dr["AcceptedQty"] = "0";
                    dr["RejectedQty"] = "0";



                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();
                    dr["SoMatId"] = dbManager.DataReader["So_MatId"].ToString();
                    dr["Requestfor"] = dbManager.DataReader["Requriedfor"].ToString();

                    dr["Length"] = dbManager.DataReader["Length"].ToString();

                    dr["Area"] = dbManager.DataReader["Area"].ToString();


                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }









            public void SupPoOrderQtyNotZero_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Supplier_Po_Details],[Material_Master],Color_Master where Supplier_Po_Details.ItemCode=[Material_Master].Material_Id AND " +
                                               "Supplier_Po_Details.Color_Id = Color_Master.Color_Id and [Supplier_Po_Details].Sup_PO_Id=" + QuotationId + " and Supplier_Po_Details.RemainingQty != '0' ");


                //_commandText = string.Format("SELECT *,PrevBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = Supplier_Po_Details.ItemCode and B.Color_Id =Supplier_Po_Details.Color_Id and B.Length = Supplier_Po_Details.Length and B.So_Id = Supplier_Po_Details.SO_Id) ,Remak = (select B.Remarks FROM Stock_Block B where B.Item_Code = Supplier_Po_Details.ItemCode and B.Color_Id =Supplier_Po_Details.Color_Id and B.Length = Supplier_Po_Details.Length and B.So_Id = Supplier_Po_Details.SO_Id) FROM [Supplier_Po_Details],[Material_Master],Color_Master where Supplier_Po_Details.ItemCode=[Material_Master].Material_Id and Supplier_Po_Details.Color_Id = Color_Master.Color_Id  " +
                //                              " and [Supplier_Po_Details].Sup_PO_Id=" + QuotationId + " and Supplier_Po_Details.RemainingQty != '0' ");



                //_commandText = string.Format("SELECT * FROM [Supplier_Po_Details],[Material_Master],Color_Master where Supplier_Po_Details.ItemCode=[Material_Master].Material_Id AND " +
                //                             "Supplier_Po_Details.Color_Id = Color_Master.Color_Id and  Supplier_Po_Details.RemainingQty != '0'  " + QuotationId + " ");


               
                
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("CodeNo");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ItemcodeId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RequiredDate");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ReceivedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RemainingQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Status");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("PoDetId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("BarLength");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("AcceptedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RejectedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SoMatId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Requestfor");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("Blockqty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesQuotationItems.Columns.Add(col);


                //col = new DataColumn("AlreadyBlocked");
                //SalesQuotationItems.Columns.Add(col);
                //col = new DataColumn("BlockRemarks");
                //SalesQuotationItems.Columns.Add(col);





                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["CodeNo"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Series"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Uom"] = dbManager.DataReader["Uom"].ToString();
                    dr["Qty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["Rate"] = dbManager.DataReader["Rate"].ToString();
                    dr["Amount"] = dbManager.DataReader["Amount"].ToString();
                    dr["ItemcodeId"] = dbManager.DataReader["ItemCode"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["RequiredDate"] = Convert.ToDateTime(dbManager.DataReader["Req_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    dr["ReceivedQty"] = "0";
                    dr["RemainingQty"] = dbManager.DataReader["RemainingQty"].ToString();
                    dr["Status"] = dbManager.DataReader["Status"].ToString();

                    dr["PoDetId"] = dbManager.DataReader["Sup_PO_Det_id"].ToString();
                    dr["BarLength"] = dbManager.DataReader["Bar_Length"].ToString();

                    dr["AcceptedQty"] = "0";
                    dr["RejectedQty"] = "0";



                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();
                    dr["SoMatId"] = dbManager.DataReader["So_MatId"].ToString();
                    dr["Requestfor"] = dbManager.DataReader["Requriedfor"].ToString();

                    dr["Length"] = dbManager.DataReader["Length"].ToString();


                    dr["Blockqty"] = "0";
                    dr["Remarks"] = "-";

                    //dr["AlreadyBlocked"] = dbManager.DataReader["PrevBlockedStock"].ToString();
                    //dr["BlockRemarks"] = dbManager.DataReader["Remak"].ToString();


                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }




            public void MultiSupPoOrderQtyNotZero_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //_commandText = string.Format("SELECT * FROM [Supplier_Po_Details],[Material_Master],Color_Master where Supplier_Po_Details.ItemCode=[Material_Master].Material_Id AND " +
                //                               "Supplier_Po_Details.Color_Id = Color_Master.Color_Id and [Supplier_Po_Details].Sup_PO_Id=" + QuotationId + " and Supplier_Po_Details.RemainingQty != '0' ");


                //_commandText = string.Format("SELECT *,PrevBlockedStock = (SELECT  isnull(sum(B.Qty),0) FROM Stock_Block B WHERE B.Item_Code = Supplier_Po_Details.ItemCode and B.Color_Id =Supplier_Po_Details.Color_Id and B.Length = Supplier_Po_Details.Length and B.So_Id = Supplier_Po_Details.SO_Id) ,Remak = (select B.Remarks FROM Stock_Block B where B.Item_Code = Supplier_Po_Details.ItemCode and B.Color_Id =Supplier_Po_Details.Color_Id and B.Length = Supplier_Po_Details.Length and B.So_Id = Supplier_Po_Details.SO_Id) FROM [Supplier_Po_Details],[Material_Master],Color_Master where Supplier_Po_Details.ItemCode=[Material_Master].Material_Id and Supplier_Po_Details.Color_Id = Color_Master.Color_Id  " +
                //                              " and [Supplier_Po_Details].Sup_PO_Id=" + QuotationId + " and Supplier_Po_Details.RemainingQty != '0' ");



                _commandText = string.Format("SELECT * FROM [Supplier_Po_Details],[Material_Master],Color_Master,Supplier_Po_Master where Supplier_Po_Details.ItemCode=[Material_Master].Material_Id AND Supplier_Po_Details.Sup_PO_Id = Supplier_Po_Master.Sup_PO_Id and " +
                                             "Supplier_Po_Details.Color_Id = Color_Master.Color_Id and  Supplier_Po_Details.RemainingQty != '0'  " + QuotationId + " ");




                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("CodeNo");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ItemcodeId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RequiredDate");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ReceivedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RemainingQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Status");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("PoDetId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("BarLength");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("AcceptedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RejectedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SoMatId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Requestfor");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("Blockqty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesQuotationItems.Columns.Add(col);


                col = new DataColumn("POId");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("PONO");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("CustomerNO");
                SalesQuotationItems.Columns.Add(col);



                //col = new DataColumn("AlreadyBlocked");
                //SalesQuotationItems.Columns.Add(col);
                //col = new DataColumn("BlockRemarks");
                //SalesQuotationItems.Columns.Add(col);





                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["CodeNo"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Series"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Uom"] = dbManager.DataReader["Uom"].ToString();
                    dr["Qty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["Rate"] = dbManager.DataReader["Rate"].ToString();
                    dr["Amount"] = dbManager.DataReader["Amount"].ToString();
                    dr["ItemcodeId"] = dbManager.DataReader["ItemCode"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["RequiredDate"] = Convert.ToDateTime(dbManager.DataReader["Req_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    dr["ReceivedQty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["RemainingQty"] = dbManager.DataReader["RemainingQty"].ToString();
                    dr["Status"] = dbManager.DataReader["Status"].ToString();

                    dr["PoDetId"] = dbManager.DataReader["Sup_PO_Det_id"].ToString();
                    dr["BarLength"] = dbManager.DataReader["Bar_Length"].ToString();

                    dr["AcceptedQty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["RejectedQty"] = "0"; 



                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();
                    dr["SoMatId"] = dbManager.DataReader["So_MatId"].ToString();
                    dr["Requestfor"] = dbManager.DataReader["Requriedfor"].ToString();

                    dr["Length"] = dbManager.DataReader["Length"].ToString();

                    dr["POId"] = dbManager.DataReader["Sup_PO_Id"].ToString();
                    dr["Blockqty"] = "0";
                    dr["Remarks"] = "-";

                    dr["PONO"] = dbManager.DataReader["Sup_PO_No"].ToString();
                    dr["CustomerNO"] = dbManager.DataReader["CustomerNo"].ToString();


                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }


            public static void NewSupPo_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Sup_PO_No,Sup_PO_Id FROM [Supplier_Po_Master] where ApprovedBy != '0' and Status != 'Close' ORDER BY Sup_PO_Id desc ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Sup_PO_No", "Sup_PO_Id");
                }
            }

            public static void SupPo_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Sup_PO_No,Sup_PO_Id FROM [Supplier_Po_Master] where ApprovedBy != '0' ORDER BY Sup_PO_Id desc ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Sup_PO_No", "Sup_PO_Id");
                }
            }



            public static void SupPo1_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Sup_PO_No,Sup_PO_Id FROM [Supplier_Po_Master] order by Sup_PO_Id desc ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Sup_PO_No", "Sup_PO_Id");
                }
            }


            public void SuppliersPODetails1_Select(string SupFixedPOId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Supplier_Po_Details],Material_Master,Color_Master WHERE [Supplier_Po_Details].ItemCode=[Material_Master].Material_Id AND Supplier_Po_Details.Color_Id = Color_Master.Color_Id   and [Supplier_Po_Details].Sup_PO_Id=" + SupFixedPOId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SuppliersFixedPOItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("Series");
                SuppliersFixedPOItems.Columns.Add(col);
              
                col = new DataColumn("Color");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SuppliersFixedPOItems.Columns.Add(col);
               
                col = new DataColumn("SeriesId");
                SuppliersFixedPOItems.Columns.Add(col);

            
                col = new DataColumn("Amount");
                SuppliersFixedPOItems.Columns.Add(col);

                col = new DataColumn("ReceivedQty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("RemainingQty");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("PlantId");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("StorageLoc");
                SuppliersFixedPOItems.Columns.Add(col);

                col = new DataColumn("Color_Id");
                SuppliersFixedPOItems.Columns.Add(col);
                col = new DataColumn("PoDetId");
                SuppliersFixedPOItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SuppliersFixedPOItems.NewRow();
                    dr["Series"] = dbManager.DataReader["Material_Code"].ToString();
                                       dr["Color"] = dbManager.DataReader["PO_DET_COLOR"].ToString();
                    dr["Qty"] = dbManager.DataReader["PO_DET_QTY"].ToString();

                    dr["SeriesID"] = dbManager.DataReader["ItemCode"].ToString();
                    dr["Amount"] = dbManager.DataReader["Amount"].ToString();
                   
                    dr["ReceivedQty"] = dbManager.DataReader["PO_RECEIVED_QTY"].ToString();
                    dr["RemainingQty"] = dbManager.DataReader["PO_REMAINING_QTY"].ToString();

                    dr["Kgpermtr"] = dbManager.DataReader["KGPERMTR"].ToString();
                    dr["TotalWeight"] = dbManager.DataReader["TOTAL_WEIGHT"].ToString();
                    dr["AlumiumCoating"] = dbManager.DataReader["ALUMINIUMCOATING"].ToString();




                    dr["PlantId"] = dbManager.DataReader["PLANT_ID"].ToString();
                    dr["StorageLoc"] = dbManager.DataReader["STORAGELOC_ID"].ToString();
                    dr["Stocktype"] = dbManager.DataReader["STOCK_TYPE"].ToString();

                    dr["ColorId"] = dbManager.DataReader["COLOR_ID"].ToString();
                    dr["PoDetId"] = dbManager.DataReader["PO_DET_ID"].ToString();

                    SuppliersFixedPOItems.Rows.Add(dr);
                }
                gv.DataSource = SuppliersFixedPOItems;
                gv.DataBind();
            }








            public string PODocuments_Details_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Supplier_PO_Docs] SELECT ISNULL(MAX(PO_Doc_Id),0)+1,'{0}','{1}','{2}',{3} FROM [Supplier_PO_Docs]", this.PODocdate, this.PODocRemarks, this.PODocuments, this.PoId);
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
                if (DeleteRecord("[Supplier_PO_Docs]", "PO_Doc_Id", Eleid) == true)
                {
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }

                return _returnStringMessage;
            }







        }




        //Methods for Supplier Invoice Form
        public class SupInvoice
        {
            public string SupInId, SupInNo, SupInDate, SupId, POnos, PaymentTermsId, TermsCondtionId, Discount, Tax, GrandTotal, Preparedby, Approvedby, Status, Insurance, frieght, Packing, transport, Writeinsurance, WriteFreight, Indentnos;

            public string SupInDetId, CodeId,  POQuantity, Uom, ColorId, Rate, Amount,Series, InvoiceQty, RemainingQty,ItmStatus,SoId,Requriedfor, Length,PoDetid;




            public SupInvoice()
            {
            }

            public static string SupInvoice_AutoGenCode()
            {
                return AutoGenMaxNo("Purchase_Invoice", "Sup_In_No");
            }

            public string SupInvoice_Save()
            {

                this.SupInId = AutoGenMaxId("[Purchase_Invoice]", "Sup_In_Id");
                this.SupInNo = AutoGenMaxNo("Purchase_Invoice", "Sup_In_No");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Purchase_Invoice] SELECT ISNULL(MAX(Sup_In_Id),0)+1,'{0}','{1}',{2},{3},'{4}','{5}','{6}','{7}','{8}',{9},{10},'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}' from Purchase_Invoice", this.SupInNo, this.SupInDate, this.SupId, this.POnos, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby, this.Status, this.Insurance, this.frieght, this.Packing, this.transport, this.Writeinsurance, this.WriteFreight, this.Indentnos);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                //if (this.MateriralReqId != "0")
                //{
                //    _commandText = string.Format("UPDATE [Supplier_Quotation_Master] SET Status='Ordered' WHERE Sup_Quo_Id ={0}", this.MateriralReqId);
                //    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                //}


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



            public string SupInvoice_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Purchase_Invoice] SET Sup_In_Date='{0}',Sup_Id={1},PO_Nos={2},Paymentterms_Id='{3}',TermsConditions_Id='{4}',Discount='{5}',Tax='{6}',GrandTotal='{7}',PreparedBy={8},ApprovedBy={9},Status='{10}',Insurance='{11}',Frieght='{12}',Packing='{13}',Transport='{14}',Write_Insurance='{15}',Write_Frieght='{16}',IndentNo='{17}' WHERE Sup_In_Id={18}", this.SupInDate, this.SupId, this.POnos, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby, this.Status, this.Insurance, this.frieght, this.Packing, this.transport, this.Writeinsurance, this.WriteFreight, this.Indentnos, this.SupInId);
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

            public string SupInvoice_Delete(string QuotationId)
            {

                //if (DeleteRecord("[Supplier_Po_Details]", "Sup_PO_Id", QuotationId) == true)
                //{
                if (DeleteRecord("[Purchase_Invoice]", "Sup_In_Id", QuotationId) == true)
                {

                    DeleteRecord("[Purchase_Invoice_Details]", "Sup_In_Id", QuotationId);
                    _returnStringMessage = "Data Deleted Successfully";
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                //}
                //else
                //{

                //    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                //}
                return _returnStringMessage;
            }


            //public string ReceivedQty, RemainingQty, ItemStatus, SOid, SoMatid, RequiredFor;

            public string SupInvoiceDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //_commandText = string.Format("INSERT INTO [Supplier_Po_Details] SELECT ISNULL(MAX(Sup_PO_Det_id),0)+1,{0},{1},{2},'{3}',{4},'{5}','{6}','{7}','{8}',{9},{10},'{11}',{12},{13},'{14}','{15}' FROM [Supplier_Po_Details]", this.PoId, this.CodeId, this.Quantity, this.Uom, this.ColorId, this.Rate, this.Amount, this.Series,this.reqdate,this.ReceivedQty,this.RemainingQty,this.ItemStatus,this.SOid,this.SoMatid,this.RequiredFor,this.Length);
                //_returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);



                _commandText = string.Format("INSERT INTO [Purchase_Invoice_Details] SELECT ISNULL(MAX(Sup_In_Det_id),0)+1,{0},{1},'{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',{13},{14} FROM [Purchase_Invoice_Details]", this.SupInId, this.CodeId, this.POQuantity, this.Uom, this.ColorId, this.Rate, this.Amount, this.Series, this.InvoiceQty, this.RemainingQty, this.RemainingQty, this.ItmStatus, this.SoId, this.Requriedfor, this.Length,this.PoDetid);
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

            public int SupInvoiceDetails_Delete(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Purchase_Invoice_Details] WHERE Sup_In_Id = {0}", QuotationId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }


            public string Sname, SContact, Smobile;

            public int SupInvoice_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Purchase_Invoice],Supplier_Master WHERE Purchase_Invoice.Sup_Id = Supplier_Master.SUP_ID and Purchase_Invoice.Sup_In_Id='" + QuotationId + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.SupInId = dbManager.DataReader["Sup_In_Id"].ToString();
                    this.SupInNo = dbManager.DataReader["Sup_In_No"].ToString();
                    this.SupInDate = Convert.ToDateTime(dbManager.DataReader["Sup_In_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SupId = dbManager.DataReader["Sup_Id"].ToString();
                    this.POnos = dbManager.DataReader["PO_Nos"].ToString();
                    this.PaymentTermsId = dbManager.DataReader["Paymentterms_Id"].ToString();
                    this.TermsCondtionId = dbManager.DataReader["TermsConditions_Id"].ToString();
                    this.Discount = dbManager.DataReader["Discount"].ToString();
                    this.Tax = dbManager.DataReader["Tax"].ToString();
                    //  this.TermsCondtionId = dbManager.DataReader["TermsConditions_Id"].ToString();
                    //  this.Discount = dbManager.DataReader["Discount"].ToString();
                    //  this.Tax = dbManager.DataReader["Tax"].ToString();
                    this.GrandTotal = dbManager.DataReader["GrandTotal"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();

                    this.Status = dbManager.DataReader["Status"].ToString();
                    this.SContact = dbManager.DataReader["SUP_ADDRESS"].ToString();
                    this.Smobile = dbManager.DataReader["SUP_MOBILE"].ToString();
                    this.Sname = dbManager.DataReader["SUP_NAME"].ToString();


                    this.Packing = dbManager.DataReader["Packing"].ToString();
                    this.Insurance = dbManager.DataReader["Insurance"].ToString();
                    this.transport = dbManager.DataReader["Transport"].ToString();
                    this.frieght = dbManager.DataReader["Frieght"].ToString();

                    this.Writeinsurance = dbManager.DataReader["Write_Insurance"].ToString();
                    this.WriteFreight = dbManager.DataReader["Write_Frieght"].ToString();
                    this.Indentnos = dbManager.DataReader["IndentNo"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

          








        



            public string SupInvoiceApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [Purchase_Invoice] SET ApprovedBy={0},Status='Close' WHERE Sup_In_Id ={1}", this.Approvedby, this.SupInId);
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


    

            public void SupInvoiceOrder_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Purchase_Invoice_Details],[Material_Master],Color_Master where Purchase_Invoice_Details.ItemCode=[Material_Master].Material_Id AND " +
                                               "Purchase_Invoice_Details.Color_Id = Color_Master.Color_Id and [Purchase_Invoice_Details].Sup_In_Id=" + QuotationId + "");
                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesQuotationItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("CodeNo");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("POQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ItemcodeId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("InvReceivedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("InRemainingQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Status");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("So_Id");
                SalesQuotationItems.Columns.Add(col);
             
              
                col = new DataColumn("Requestfor");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("Length");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("PODetId");
                SalesQuotationItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["CodeNo"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Series"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Uom"] = dbManager.DataReader["Uom"].ToString();
                    dr["POQty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["Rate"] = dbManager.DataReader["Rate"].ToString();
                    dr["Amount"] = dbManager.DataReader["Amount"].ToString();
                    dr["ItemcodeId"] = dbManager.DataReader["ItemCode"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["InvReceivedQty"] = dbManager.DataReader["ReceivedQty"].ToString();
                    dr["InRemainingQty"] = dbManager.DataReader["RemainingQty"].ToString();
                    dr["Status"] = dbManager.DataReader["Status"].ToString();
                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();
                    dr["Requestfor"] = dbManager.DataReader["Requriedfor"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["PODetId"] = dbManager.DataReader["PurchaseDet_Id"].ToString();


                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }

            public static void SupInvoice_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Sup_In_No,Sup_In_Id FROM [Purchase_Invoice] where ApprovedBy != '0' ORDER BY Sup_In_Id desc ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Sup_In_No", "Sup_In_Id");
                }
            }

        }

























        //Methods for Tool IssueRequest
        public class ToolsRequest
        {
            public string ReqToolId, RequestTooldate, RequestNo, Reqby, PreparedBy, Status;
            public string ReqdetToolId, Itemcode, Quantity, ColorId, remarks, Length, tableid, empid, detstatus;

            public ToolsRequest()
            {
            }

            public static string ToolsRequest_AutoGenCode()
            {
                return AutoGenMaxNo("Request_Tools", "Req_Tool_No");
            }
            public string ToolsRequest_Save()
            {
                this.RequestNo = AutoGenMaxNo("Request_Tools", "Req_Tool_No");
                this.ReqToolId = AutoGenMaxId("[Request_Tools]", "Req_Tool_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Request_Tools] VALUES({0},'{1}','{2}',{3},{4},'{5}')", this.ReqToolId, this.RequestTooldate, this.RequestNo, this.Reqby, this.PreparedBy, this.Status);
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

            public string ToolsRequest_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Request_Tools] SET  Req_Tool_Date='{0}',Req_Tool_No='{1}',Req_By={2},PreparedBy={3},Status={4} WHERE Req_Tool_Id={5}", this.RequestTooldate, this.RequestNo, this.Reqby, this.PreparedBy, this.Status, this.ReqToolId);
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

            public string ToolsRequest_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[Request_Tools_Details]", "Reuest_Tool_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[Request_Tools]", "Req_Tool_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }
            public string Stock_Update(string productid, string Qty, string plantid, string colorid, string storagelocid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity = Quantity-'{0}' WHERE MatId = {1}  and ColorId = {2} and Length = {3}", Qty, productid, colorid, Length);
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
            public string ToolRequestDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Request_Tools_Details] SELECT ISNULL(MAX(Request_Tool_Det_Id),0)+1,{0},{1},{2},'{3}',{4},{5},{6},'{7}','{8}' FROM [Request_Tools_Details]", this.ReqToolId, this.Itemcode, this.ColorId, this.Quantity, this.tableid, this.Length, this.empid, this.remarks, this.detstatus);
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

            public int ToolRequestDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Request_Tools_Details] WHERE Reuest_Tool_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int ToolRequest_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Request_Tools] WHERE  [Request_Tools].Req_Tool_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ReqToolId = dbManager.DataReader["Req_Tool_Id"].ToString();
                    this.RequestNo = dbManager.DataReader["Req_Tool_No"].ToString();
                    this.RequestTooldate = Convert.ToDateTime(dbManager.DataReader["Req_Tool_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Reqby = dbManager.DataReader["Req_By"].ToString();
                    this.PreparedBy = dbManager.DataReader["PreparedBy"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();
                 

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void ToolRequestDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //  _commandText = string.Format("SELECT * FROM [Request_Material_Issue_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Request_Material_Issue_Details].Item_Code=[Material_Master].Material_Id  and Request_Material_Issue_Details.Color_Id = Color_Master.Color_Id   AND [Request_Material_Issue_Details].ReqIssue_Id=" + MaterialRequestId);
                _commandText = string.Format("SELECT * FROM Request_Tools_Details,[Material_Master],Color_Master,ItemSeries,Uom_Master,Request_Tools ,Table_Master,Employee_Master WHERE Request_Tools_Details.TableId = Table_Master.Table_Id and Request_Tools_Details.Emp_Id = Employee_Master.EMP_ID      and  Request_Tools_Details.Reuest_Tool_Id = Request_Tools.Req_Tool_Id and [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  Request_Tools_Details.Item_Code=[Material_Master].Material_Id  and Request_Tools_Details.Color_Id = Color_Master.Color_Id   AND Request_Tools_Details.Reuest_Tool_Id =" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Table");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Employee");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("TableId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("EmployeeId");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Description"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Qty"] = dbManager.DataReader["Qty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["Table"] = dbManager.DataReader["Table_Name"].ToString();
                    dr["Employee"] = dbManager.DataReader["EMP_FIRST_NAME"].ToString();
                    dr["TableId"] = dbManager.DataReader["TableId"].ToString();
                    dr["EmployeeId"] = dbManager.DataReader["Emp_Id"].ToString();
                    dr["Remarks"] = "-";
                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }


        }




        //Methods for ToolIssue
        public class ToolIssue
        {
            public string ReqToolId, RequestTooldate, RequestNo, Reqby, PreparedBy, Status,ReqId;
            public string ReqdetToolId, Itemcode, Quantity, ColorId, remarks, Length, tableid, empid, detstatus;

            public ToolIssue()
            {
            }

            public static string ToolIssue_AutoGenCode()
            {
                return AutoGenMaxNo("Tools_Issue", "Issue_Req_Tool_No");
            }
            public string ToolsRequest_Save()
            {
                this.RequestNo = AutoGenMaxNo("Tools_Issue", "Issue_Req_Tool_No");
                this.ReqToolId = AutoGenMaxId("[Tools_Issue]", "Issue_Req_Tool_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Tools_Issue] VALUES({0},'{1}','{2}',{3},{4},'{5}',{6})", this.ReqToolId, this.RequestTooldate, this.RequestNo, this.Reqby, this.PreparedBy, this.Status,this.ReqId);
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

            public string ToolsRequest_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Request_Tools] SET  Req_Tool_Date='{0}',Req_Tool_No='{1}',Req_By={2},PreparedBy={3},Status={4} WHERE Req_Tool_Id={5}", this.RequestTooldate, this.RequestNo, this.Reqby, this.PreparedBy, this.Status, this.ReqToolId);
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

            public string ToolsRequest_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[Request_Tools_Details]", "Reuest_Tool_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[Request_Tools]", "Req_Tool_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }
            public string Stock_Update(string productid, string Qty, string plantid, string colorid, string storagelocid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity = Quantity-'{0}' WHERE MatId = {1}  and ColorId = {2} and Length = {3}", Qty, productid, colorid, Length);
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
            public string ToolRequestDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Request_Tools_Details] SELECT ISNULL(MAX(Request_Tool_Det_Id),0)+1,{0},{1},{2},'{3}',{4},{5},{6},'{7}','{8}' FROM [Request_Tools_Details]", this.ReqToolId, this.Itemcode, this.ColorId, this.Quantity, this.tableid, this.Length, this.empid, this.remarks, this.detstatus);
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

            public int ToolRequestDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Request_Tools_Details] WHERE Reuest_Tool_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int ToolRequest_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Request_Tools] WHERE  [Request_Tools].Req_Tool_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ReqToolId = dbManager.DataReader["Req_Tool_Id"].ToString();
                    this.RequestNo = dbManager.DataReader["Req_Tool_No"].ToString();
                    this.RequestTooldate = Convert.ToDateTime(dbManager.DataReader["Req_Tool_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Reqby = dbManager.DataReader["Req_By"].ToString();
                    this.PreparedBy = dbManager.DataReader["PreparedBy"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();


                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void ToolRequestDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //  _commandText = string.Format("SELECT * FROM [Request_Material_Issue_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Request_Material_Issue_Details].Item_Code=[Material_Master].Material_Id  and Request_Material_Issue_Details.Color_Id = Color_Master.Color_Id   AND [Request_Material_Issue_Details].ReqIssue_Id=" + MaterialRequestId);
                _commandText = string.Format("SELECT * FROM Request_Tools_Details,[Material_Master],Color_Master,ItemSeries,Uom_Master,Request_Tools ,Table_Master,Employee_Master WHERE Request_Tools_Details.TableId = Table_Master.Table_Id and Request_Tools_Details.Emp_Id = Employee_Master.EMP_ID      and  Request_Tools_Details.Reuest_Tool_Id = Request_Tools.Req_Tool_Id and [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  Request_Tools_Details.Item_Code=[Material_Master].Material_Id  and Request_Tools_Details.Color_Id = Color_Master.Color_Id   AND Request_Tools_Details.Reuest_Tool_Id =" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Table");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Employee");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("TableId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("EmployeeId");
                SalesOrderItems.Columns.Add(col);



                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Description"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Qty"] = dbManager.DataReader["Received_Qty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["Table"] = dbManager.DataReader["Table_Name"].ToString();
                    dr["Employee"] = dbManager.DataReader["EMP_FIRST_NAME"].ToString();
                    dr["TableId"] = dbManager.DataReader["TableId"].ToString();
                    dr["EmployeeId"] = dbManager.DataReader["Emp_Id"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }


        }












        //Methods for Bulk return IssueRequest
        public class BulkReturnRequest
        {
            public string ReqIssueId, RequestPurpose, RequestDate, SoId, ReturnBy, ApprovedBy, Custid, BulkReqIssueNo, Status,ReturnTime;
            public string ReqIssuedetid, Itemcode, Quantity, ColorId, remarks, Length;

            public BulkReturnRequest()
            {
            }

            public static string BulkReturnRequest_AutoGenCode()
            {
                return AutoGenMaxNo("Request_Bulk_Production_Return", "Req_BulkReturn_No");
            }
            public string BulkReturnIssueRequest_Save()
            {
                this.BulkReqIssueNo = AutoGenMaxNo("Request_Bulk_Production_Return", "Req_BulkReturn_No");
                this.ReqIssueId = AutoGenMaxId("[Request_Bulk_Production_Return]", "Request_ReturnIssue_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Request_Bulk_Production_Return] VALUES({0},'{1}','{2}',{3},{4},{5},{6},'{7}','{8}',getdate())", this.ReqIssueId, this.RequestPurpose, this.RequestDate, this.SoId, this.ReturnBy, this.ApprovedBy, this.Custid, this.BulkReqIssueNo, this.Status);
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

            public string BulkReturnIssueRequest_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Request_Bulk_Production_Return] SET  Return_Purpose='{0}',Return_Date='{1}',So_Id={2},Return_By={3},ApprovedBy={4},Cust_Id={5},Req_BulkReturn_No='{6}',Status='{7}',Return_Time=getdate() WHERE Request_ReturnIssue_Id={8}", this.RequestPurpose, this.RequestDate, this.SoId, this.ReturnBy, this.ApprovedBy, this.Custid, this.BulkReqIssueNo, this.Status,this.ReqIssueId);
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

            public string BulkReturnIssueRequest_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[Request_Bulk_Production_Return_Details]", "Reuest_BulkReturn_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[Request_Bulk_Production_Return]", "Request_ReturnIssue_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string BulkReturnIssueRequestDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Request_Bulk_Production_Return_Details] SELECT ISNULL(MAX(Request_ReturnIssue_Det_Id),0)+1,{0},{1},{2},'{3}','{4}',{5},{6} FROM [Request_Bulk_Production_Return_Details]", this.ReqIssueId, this.Itemcode, this.ColorId, this.Quantity, this.remarks, this.Length,this.SoId);
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

            public int BulkReturnIssueRequestDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Request_Bulk_Production_Return_Details] WHERE Reuest_BulkReturn_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int BulkReturnIssueRequest_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Request_Bulk_Production_Return] WHERE  [Request_Bulk_Production_Return].Request_ReturnIssue_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ReqIssueId = dbManager.DataReader["Request_ReturnIssue_Id"].ToString();
                    this.BulkReqIssueNo = dbManager.DataReader["Req_BulkReturn_No"].ToString();
                    this.RequestDate = Convert.ToDateTime(dbManager.DataReader["Return_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SoId = dbManager.DataReader["So_Id"].ToString();
                    this.ReturnBy = dbManager.DataReader["Return_By"].ToString();
                    this.ApprovedBy = dbManager.DataReader["ApprovedBy"].ToString();
                    this.Custid = dbManager.DataReader["Cust_Id"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();
                    this.RequestPurpose = dbManager.DataReader["Return_Purpose"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void BulkReturnIssueRequestDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //  _commandText = string.Format("SELECT * FROM [Request_Material_Issue_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Request_Material_Issue_Details].Item_Code=[Material_Master].Material_Id  and Request_Material_Issue_Details.Color_Id = Color_Master.Color_Id   AND [Request_Material_Issue_Details].ReqIssue_Id=" + MaterialRequestId);
                _commandText = string.Format("SELECT * FROM [Request_Bulk_Production_Return_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master,Request_Bulk_Production_Return WHERE  [Request_Bulk_Production_Return_Details].Reuest_BulkReturn_Id = Request_Bulk_Production_Return.Request_ReturnIssue_Id and [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Request_Bulk_Production_Return_Details].Item_Code=[Material_Master].Material_Id  and Request_Bulk_Production_Return_Details.Color_Id = Color_Master.Color_Id   AND [Request_Bulk_Production_Return_Details].Reuest_BulkReturn_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Description"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Qty"] = dbManager.DataReader["Received_Qty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["SoId"] = dbManager.DataReader["So_Id"].ToString();


                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }






            public string BulkReturnIssueRequestApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Request_Bulk_Production_Return] SET ApprovedBy = {0} WHERE Request_ReturnIssue_Id ={1}", this.ApprovedBy, this.ReqIssueId);
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







            //public static void ItemsIssueRequest_Select(Control ControlForBind, string ReqDetId)
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();
            //    _commandText = string.Format("SELECT Material_Id,Material_Code FROM [Material_Master],Request_Material_Issue_Details where [Material_Master].Material_Id = Request_Material_Issue_Details.Item_Code and Request_Material_Issue_Details.ReqIssue_Id = '" + ReqDetId + "'  ");
            //    dbManager.ExecuteReader(CommandType.Text, _commandText);
            //    if (ControlForBind is DropDownList)
            //    {
            //        DropDownListBind(ControlForBind as DropDownList, "Material_Code", "Material_Id");
            //    }
            //}



            public static void BulkReturnIssueRequestsTATUS_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Req_BulkReturn_No,Request_ReturnIssue_Id FROM [Request_Bulk_Production_Return] where  ApprovedBy != 0   ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Req_BulkReturn_No", "Request_ReturnIssue_Id");
                }
            }


            public static void BulkReturnIssueRequest_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Req_BulkReturn_No,Request_ReturnIssue_Id FROM [Request_Bulk_Production_Return] where  ApprovedBy != 0   and   Status = 'Not Issued' or Status = '' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Req_BulkReturn_No", "Request_ReturnIssue_Id");
                }
            }



            public static void BulkReturnIssueRequestBeforeApproveandstatus_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Req_BulkReturn_No,Request_ReturnIssue_Id FROM [Request_Bulk_Production_Return] where Request_Bulk_Production_Return.Approved_By != '0' and Status = 'Not Issued' ORDER BY Request_ReturnIssue_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Req_BulkReturn_No", "Request_ReturnIssue_Id");
                }
            }





            //public string ItemDescription, ItemUom, ItemColor;
            //public int MaterialIssueRequest_Select(string Code)
            //{
            //    dbManager.Open();
            //    try
            //    {
            //        _commandText = string.Format("SELECT [Material_Master].Description,[Material_Master].Bar_Length,UOM_SHORT_DESC,Box_Size FROM [Material_Master],Uom_Master  where  Material_Master.UOM_Id = Uom_Master.UOM_ID and  Material_Master.Material_Id =" + Code + " ");

            //        dbManager.ExecuteReader(CommandType.Text, _commandText);
            //        if (dbManager.DataReader.Read())
            //        {

            //            this.ItemDescription = dbManager.DataReader["Description"].ToString();
            //            //this.UomName = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
            //            //this.Boxsize = dbManager.DataReader["Box_Size"].ToString();
            //            _returnIntValue = 1;
            //        }
            //        else
            //        {
            //            _returnIntValue = 0;
            //        }
            //        dbManager.DataReader.Close();
            //    }
            //    catch
            //    {
            //    }
            //    finally
            //    {
            //    }
            //    return _returnIntValue;
            //}




        }

































        //Methods for GlassRequest
        public class GlassRequest
        {
            public string GlassRequest_Id, GlassRequest_No, Required_Date, Request_Type, Requested_for, Requested_Type, TermsCondition_Id, Prepared_By, Status, So_Id, Approved_By;
            public string GlassRequest_Det_Id, Windowcode, Thickness, Description, width, height, unit, Area, weight, Reqqty, sodetid, Req_date, stock;

            public GlassRequest() { }

            public static string GlassRequest_AutoGenCode()
            {
                return AutoGenMaxNo("Glass_Request", "GlasslRequest_No");
            }

            public static void GlassRequestNo_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT GlasslRequest_No,GlasslRequest_Id FROM [Glass_Request] where Glass_Request.Approved_By != '0'  ORDER BY GlasslRequest_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "GlasslRequest_No", "GlasslRequest_Id");
                }
            }




            public static void GlassRequestNo_SelectNotissued(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT GlasslRequest_No,GlasslRequest_Id FROM [Glass_Request] where Glass_Request.Approved_By != '0' and Status != 'Issued'  ORDER BY GlasslRequest_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "GlasslRequest_No", "GlasslRequest_Id");
                }
            }




            public int GlassRequestDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [GlassRequest_Details] WHERE GlassRequest_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }
            public string GlassRequest_Save()
            {
                this.GlassRequest_No = AutoGenMaxNo("Glass_Request", "GlasslRequest_No");
                this.GlassRequest_Id = AutoGenMaxId("[Glass_Request]", "GlasslRequest_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Glass_Request] VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", this.GlassRequest_Id , this.GlassRequest_No , this.Required_Date , this.Request_Type , this.Requested_for  , this.Req_date , this.TermsCondition_Id , this.Prepared_By , this.Status , this.So_Id,this.Approved_By  );
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
            public string GlassRequest_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Glass_Request] SET  Required_Date='{0}',Request_Type='{1}',Requested_For='{2}',Requested_Date='{3}',Prepared_By='{4}',Status='{5}',SO_Id='{6}',Approved_By='{7}' WHERE GlasslRequest_Id={8}", this.Required_Date , this.Requested_Type , this.Requested_for , this.Req_date , this.Prepared_By , this.Status , this.So_Id , this.Approved_By , this.GlassRequest_Id );
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
            public string GlassRequestApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Glass_Request] SET Approved_By = {0} WHERE GlasslRequest_Id ={1}", this.Approved_By , this.GlassRequest_Id );
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
            public string GlassRequestDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [GlassRequest_Details] SELECT ISNULL(MAX(GlassRequest_Det_id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}' FROM [GlassRequest_Details]", this.GlassRequest_Id, this.Windowcode, this.Thickness, this.Description, this.width, this.height, this.unit, this.Area, this.weight, this.Reqqty, this.Req_date, this.sodetid, this.stock);
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

            public string GlassRequest_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[GlassRequest_Details]", "GlassRequest_Det_id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[Glass_Request]", "GlassRequest_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public int GlassRequest_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Glass_Request] WHERE  [Glass_Request].GlasslRequest_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.GlassRequest_Id = dbManager.DataReader["GlasslRequest_Id"].ToString();
                    this.GlassRequest_No = dbManager.DataReader["GlasslRequest_No"].ToString();
                    this.Required_Date = Convert.ToDateTime(dbManager.DataReader["Required_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Requested_Type = dbManager.DataReader["Request_Type"].ToString();
                    this.Requested_for = dbManager.DataReader["Requested_For"].ToString();
                    this.Prepared_By  = dbManager.DataReader["Prepared_By"].ToString();
                    this.TermsCondition_Id  = dbManager.DataReader["TermsConditions_Id"].ToString();
                    this.Req_date = Convert.ToDateTime(dbManager.DataReader["Requested_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Status = dbManager.DataReader["Status"].ToString();

                    this.So_Id  = dbManager.DataReader["SO_Id"].ToString();
                    this.Approved_By = dbManager.DataReader["Approved_By"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void GlassRequestDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //  _commandText = string.Format("SELECT * FROM [Request_Material_Issue_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Request_Material_Issue_Details].Item_Code=[Material_Master].Material_Id  and Request_Material_Issue_Details.Color_Id = Color_Master.Color_Id   AND [Request_Material_Issue_Details].ReqIssue_Id=" + MaterialRequestId);
                _commandText = string.Format("SELECT * FROM [GlassRequest_Details] where [GlassRequest_Details].GlassRequest_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("WindowCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Thickness");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Width");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Height");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Unit");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Area");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Weight");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Stock");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("PoDetId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Requestqty");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["WindowCode"] = dbManager.DataReader["WindowCode"].ToString();
                    dr["Thickness"] = dbManager.DataReader["Thickness"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["Height"] = dbManager.DataReader["Height"].ToString();
                    dr["Unit"] = dbManager.DataReader["Unit"].ToString();
                    dr["Area"] = dbManager.DataReader["Area"].ToString();
                    dr["Weight"] = dbManager.DataReader["Weight"].ToString();
                    dr["Stock"] = dbManager.DataReader["stock"].ToString();
                    dr["PoDetId"] = dbManager.DataReader["So_Id"].ToString();
                    dr["Requestqty"] = dbManager.DataReader["ReqQty"].ToString();


                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }





            public void GlassRequestDetailsIssue_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //  _commandText = string.Format("SELECT * FROM [Request_Material_Issue_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Request_Material_Issue_Details].Item_Code=[Material_Master].Material_Id  and Request_Material_Issue_Details.Color_Id = Color_Master.Color_Id   AND [Request_Material_Issue_Details].ReqIssue_Id=" + MaterialRequestId);
                _commandText = string.Format("SELECT * FROM [GlassRequest_Details] where stock > '0' and [GlassRequest_Details].GlassRequest_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("WindowCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Thickness");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Width");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Height");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Unit");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Area");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Weight");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Stock");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("PoDetId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Requestqty");
                SalesOrderItems.Columns.Add(col);


                col = new DataColumn("GlassRequestDetId");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Issued_Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["WindowCode"] = dbManager.DataReader["WindowCode"].ToString();
                    dr["Thickness"] = dbManager.DataReader["Thickness"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["Height"] = dbManager.DataReader["Height"].ToString();
                    dr["Unit"] = dbManager.DataReader["Unit"].ToString();
                    dr["Area"] = dbManager.DataReader["Area"].ToString();
                    dr["Weight"] = dbManager.DataReader["Weight"].ToString();
                    dr["Stock"] = dbManager.DataReader["stock"].ToString();
                    dr["PoDetId"] = dbManager.DataReader["So_Id"].ToString();
                    dr["Requestqty"] = dbManager.DataReader["ReqQty"].ToString();

                    dr["GlassRequestDetId"] = dbManager.DataReader["GlassRequest_Det_id"].ToString();

                    dr["Issued_Qty"] = "0";
                    dr["Remarks"] = "-";

                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }












        }



        



        //Methods for IssueRequest
        public class IssueRequest
        {
            public string ReqIssueId, RequestPurpose, RequestDate, SoId, RequestedBy, ApprovedBy, Custid, ReqIssueNo,RequriedDate,Status;
            public string ReqIssuedetid, Itemcode, Quantity, ColorId, remarks, sodetid,Length;

            public IssueRequest()
            {
            }

            public static string IssueRequest_AutoGenCode()
            {
                return AutoGenMaxNo("Request_Material_Issue", "Req_Issue_No");
            }
            public string IssueRequest_Save()
            {
                this.ReqIssueNo = AutoGenMaxNo("Request_Material_Issue", "Req_Issue_No");
                this.ReqIssueId = AutoGenMaxId("[Request_Material_Issue]", "Req_Issue_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Request_Material_Issue] VALUES({0},'{1}','{2}',{3},{4},{5},{6},'{7}','{8}','{9}')", this.ReqIssueId, this.RequestPurpose, this.RequestDate, this.SoId, this.RequestedBy, this.ApprovedBy, this.Custid, this.ReqIssueNo,this.RequriedDate,this.Status);
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

            public string IssueRequest_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Request_Material_Issue] SET  Req_Purpose='{0}',Req_Issue_Date='{1}',So_Id={2},Reqested_By={3},Approved_By={4},Cust_Id={5},Req_Issue_No='{6}',Reqired_Date='{7}' WHERE Req_Issue_Id={8}", this.RequestPurpose, this.RequestDate, this.SoId, this.RequestedBy, this.ApprovedBy, this.Custid, this.ReqIssueNo,this.RequriedDate, this.ReqIssueId);
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

            public string IssueRequest_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[Request_Material_Issue_Details]", "ReqIssue_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[Request_Material_Issue]", "Req_Issue_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string IssueRequestDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Request_Material_Issue_Details] SELECT ISNULL(MAX(ReqIssue_Det_Id),0)+1,{0},{1},{2},'{3}','{4}',{5},{6} FROM [Request_Material_Issue_Details]", this.ReqIssueId, this.Itemcode, this.ColorId, this.Quantity, this.remarks, this.sodetid,this.Length);
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

            public int IssueRequestDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Request_Material_Issue_Details] WHERE ReqIssue_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int IssueRequest_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Request_Material_Issue] WHERE  [Request_Material_Issue].Req_Issue_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ReqIssueId = dbManager.DataReader["Req_Issue_Id"].ToString();
                    this.ReqIssueNo = dbManager.DataReader["Req_Issue_No"].ToString();
                    this.RequestDate = Convert.ToDateTime(dbManager.DataReader["Req_Issue_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SoId = dbManager.DataReader["So_Id"].ToString();
                    this.RequestedBy = dbManager.DataReader["Reqested_By"].ToString();
                    this.ApprovedBy = dbManager.DataReader["Approved_By"].ToString();
                    this.Custid = dbManager.DataReader["Cust_Id"].ToString();
                    this.RequriedDate = Convert.ToDateTime(dbManager.DataReader["Reqired_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Status = dbManager.DataReader["Status"].ToString();

                    this.RequestPurpose = dbManager.DataReader["Req_Purpose"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void IssueRequestDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
              //  _commandText = string.Format("SELECT * FROM [Request_Material_Issue_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Request_Material_Issue_Details].Item_Code=[Material_Master].Material_Id  and Request_Material_Issue_Details.Color_Id = Color_Master.Color_Id   AND [Request_Material_Issue_Details].ReqIssue_Id=" + MaterialRequestId);
                _commandText = string.Format("SELECT * FROM [Request_Material_Issue_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master,Request_Material_Issue WHERE  [Request_Material_Issue_Details].ReqIssue_Id = Request_Material_Issue.Req_Issue_Id and [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Request_Material_Issue_Details].Item_Code=[Material_Master].Material_Id  and Request_Material_Issue_Details.Color_Id = Color_Master.Color_Id   AND [Request_Material_Issue_Details].ReqIssue_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoMatId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Description"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["Qty"] = dbManager.DataReader["Issue_Qty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["SoMatId"] = dbManager.DataReader["So_det_Id"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["SoId"] = dbManager.DataReader["So_Id"].ToString();
                

                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }






            public string IssueRequestApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Request_Material_Issue] SET Approved_By = {0} WHERE Req_Issue_Id ={1}", this.ApprovedBy, this.ReqIssueId);
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







            public static void ItemsIssueRequest_Select(Control ControlForBind, string ReqDetId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Material_Id,Material_Code FROM [Material_Master],Request_Material_Issue_Details where [Material_Master].Material_Id = Request_Material_Issue_Details.Item_Code and Request_Material_Issue_Details.ReqIssue_Id = '"+ReqDetId+"'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Material_Code", "Material_Id");
                }
            }






            public static void IssueRequest_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Req_Issue_No,Req_Issue_Id FROM [Request_Material_Issue]  ORDER BY Req_Issue_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Req_Issue_No", "Req_Issue_Id");
                }
            }



            public static void IssueRequestBeforeApproveandstatus_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Req_Issue_No,Req_Issue_Id FROM [Request_Material_Issue] where Request_Material_Issue.Approved_By != '0' and Status = 'Not Issued' ORDER BY Req_Issue_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Req_Issue_No", "Req_Issue_Id");
                }
            }





            public string ItemDescription, ItemUom, ItemColor;
            public int MaterialIssueRequest_Select(string Code)
            {
                dbManager.Open();
                try
                {
                    _commandText = string.Format("SELECT [Material_Master].Description,[Material_Master].Bar_Length,UOM_SHORT_DESC,Box_Size FROM [Material_Master],Uom_Master  where  Material_Master.UOM_Id = Uom_Master.UOM_ID and  Material_Master.Material_Id =" + Code + " ");

                    dbManager.ExecuteReader(CommandType.Text, _commandText);
                    if (dbManager.DataReader.Read())
                    {

                        this.ItemDescription = dbManager.DataReader["Description"].ToString();
                        //this.UomName = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                        //this.Boxsize = dbManager.DataReader["Box_Size"].ToString();
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


        //Methods for GlassIssue

        public class GlassIssue
        {
            public string GlassIssueId, RequestPurpose,Requested_For, IssueDate, SoId, RequestedBy, ApprovedBy, IssueNo, RequestId;
            public string ReqIssuedetid, Windowcode, Thickness, Description, Remarks,Width, Height, Unit, Area, Weight, Stock, SoDetId, ReqQty, IssuedQty;

            public GlassIssue()
            {

            }
            public static string GlassIssue_AutoGenCode()
            {
                return AutoGenMaxNo("Glass_Issue", "Issue_No");
            }
            public int GlassIssue_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Glass_Issue] WHERE  [Glass_Issue].Issue_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.GlassIssueId  = dbManager.DataReader["Issue_Id"].ToString();
                    this.IssueNo = dbManager.DataReader["Issue_No"].ToString();
                    this.IssueDate = Convert.ToDateTime(dbManager.DataReader["Issue_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SoId = dbManager.DataReader["So_Id"].ToString();
                    this.RequestedBy = dbManager.DataReader["Reqested_By"].ToString();
                    this.ApprovedBy = dbManager.DataReader["Approved_By"].ToString();
                    //this.Requested_For = dbManager.DataReader["Requested_For"].ToString();
                    this.RequestPurpose = dbManager.DataReader["Req_Purpose"].ToString();
                    this.RequestId = dbManager.DataReader["Reqest_Id"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }
            public void GlassIssueDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //  _commandText = string.Format("SELECT * FROM [Request_Material_Issue_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Request_Material_Issue_Details].Item_Code=[Material_Master].Material_Id  and Request_Material_Issue_Details.Color_Id = Color_Master.Color_Id   AND [Request_Material_Issue_Details].ReqIssue_Id=" + MaterialRequestId);
                _commandText = string.Format("SELECT * FROM [GlassIssue_Details] where [GlassIssue_Details].GlassIssue_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("WindowCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Thickness");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Width");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Height");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Unit");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Area");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Weight");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Stock");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("PoDetId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Requestqty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Issued_Qty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["WindowCode"] = dbManager.DataReader["WindowCode"].ToString();
                    dr["Thickness"] = dbManager.DataReader["Thickness"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["Height"] = dbManager.DataReader["Height"].ToString();
                    dr["Unit"] = dbManager.DataReader["Unit"].ToString();
                    dr["Area"] = dbManager.DataReader["Area"].ToString();
                    dr["Weight"] = dbManager.DataReader["Weight"].ToString();
                    dr["Stock"] = dbManager.DataReader["stock"].ToString();
                    dr["PoDetId"] = dbManager.DataReader["So_Id"].ToString();
                    dr["Requestqty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["Issued_Qty"] = dbManager.DataReader["Issued_Qty"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();


                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }


            public void GlassRequestDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //  _commandText = string.Format("SELECT * FROM [Request_Material_Issue_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Request_Material_Issue_Details].Item_Code=[Material_Master].Material_Id  and Request_Material_Issue_Details.Color_Id = Color_Master.Color_Id   AND [Request_Material_Issue_Details].ReqIssue_Id=" + MaterialRequestId);
                _commandText = string.Format("SELECT * FROM [GlassRequest_Details] where [GlassRequest_Details].GlassRequest_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("WindowCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Thickness");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Width");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Height");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Unit");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Area");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Weight");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Stock");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("PoDetId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Requestqty");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["WindowCode"] = dbManager.DataReader["WindowCode"].ToString();
                    dr["Thickness"] = dbManager.DataReader["Thickness"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["Height"] = dbManager.DataReader["Height"].ToString();
                    dr["Unit"] = dbManager.DataReader["Unit"].ToString();
                    dr["Area"] = dbManager.DataReader["Area"].ToString();
                    dr["Weight"] = dbManager.DataReader["Weight"].ToString();
                    dr["Stock"] = dbManager.DataReader["stock"].ToString();
                    dr["PoDetId"] = dbManager.DataReader["So_Id"].ToString();
                    dr["Requestqty"] = dbManager.DataReader["ReqQty"].ToString();


                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }


            public string GlassIssue_Save()
            {
                this.IssueNo = AutoGenMaxNo("Glass_Issue", "Issue_No");
                this.GlassIssueId  = AutoGenMaxId("[Glass_Issue]", "Issue_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Glass_Issue] VALUES({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}',{8})", this.GlassIssueId , this.RequestPurpose, this.IssueDate, this.SoId, this.RequestedBy, this.ApprovedBy, this.Requested_For , this.IssueNo, this.RequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _commandText = string.Format("UPDATE [Glass_Request] SET  Status='Issued' WHERE GlasslRequest_Id={0}", this.RequestId);
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

            public string GlassIssueDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [GlassIssue_Details] SELECT ISNULL(MAX(GlassIssue_Det_id),0)+1,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}' FROM [GlassIssue_Details]", this.GlassIssueId , this.Windowcode, this.Thickness, this.Description, this.Width, this.Height, this.Unit, this.Area, this.Weight, this.ReqQty , this.SoDetId  , this.IssuedQty , this.Remarks,this.Stock );
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

            public string GlassIssue_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[GlassIssue_Details]", "GlassIssue_Det_id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[Glass_Issue]", "Issue_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }


            public string GlassPurchaseOrderDetailsStockQty_Update(string podetid, string receivedqty)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //_commandText = string.Format("UPDATE [Supplier_Po_Details] SET  RemainingQty=CONVERT(BIGINT,RemainingQty)-{0} WHERE Sup_PO_Det_id={1} ", receivedqty, podetid);
                //_returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);



                _commandText = string.Format("UPDATE [Glass_PO_Details] SET  stock = stock - '{0}'  WHERE Sup_GPO_Det_id={1} ", receivedqty, podetid);
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

            public string GlassRequest_DetailsStockQty_Update(string podetid, string receivedqty)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [GlassRequest_Details] SET  stock = stock - '{0}'  WHERE GlassRequest_Det_id={1} ", receivedqty, podetid);
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



        //Methods for MaterialIssue
        public class MaterialIssue
        {
            public string MaterialIssueId, RequestPurpose, IssueDate, SoId, RequestedBy, ApprovedBy, Custid, IssueNo,RequestId;
            public string ReqIssuedetid, Itemcode, ReqQuantity, ColorId, remarks, sodetid,Issuedqty,length;

            public MaterialIssue()
            {
            }

            public static string MaterialIssue_AutoGenCode()
            {
                return AutoGenMaxNo("Material_Issue", "Issue_No");
            }
            public string MaterialIssue_Save()
            {
                this.IssueNo = AutoGenMaxNo("Material_Issue", "Issue_No");
                this.MaterialIssueId = AutoGenMaxId("[Material_Issue]", "Issue_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Material_Issue] VALUES({0},'{1}','{2}',{3},{4},{5},{6},'{7}',{8})", this.MaterialIssueId, this.RequestPurpose, this.IssueDate, this.SoId, this.RequestedBy, this.ApprovedBy, this.Custid, this.IssueNo,this.RequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _commandText = string.Format("UPDATE [Request_Material_Issue] SET  Status='Issued' WHERE Req_Issue_Id={0}", this.RequestId);
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

            public string MaterialIssue_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Material_Issue] SET  Req_Purpose='{0}',Issue_Date='{1}',So_Id={2},Reqested_By={3},Approved_By={4},Cust_Id={5},Issue_No='{6}',Reqest_Id={7} WHERE Issue_Id={8}", this.RequestPurpose, this.IssueDate, this.SoId, this.RequestedBy, this.ApprovedBy, this.Custid, this.IssueNo,this.RequestId,this.MaterialIssueId);
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

            public string MaterialIssue_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[Material_Issue_Details]", "Issue_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[Material_Issue]", "Issue_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }


            public string Receivedqty , Blockedqty,FreeQty;

            public string MaterialIssueDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Material_Issue_Details] SELECT ISNULL(MAX(Issue_Det_Id),0)+1,{0},{1},{2},'{3}','{4}',{5},'{6}',{7},{8},'{9}','{10}','{11}' FROM [Material_Issue_Details]", this.MaterialIssueId, this.Itemcode, this.ColorId, this.ReqQuantity, this.remarks, this.sodetid,this.Issuedqty,this.length,this.SoId,this.Receivedqty,this.Blockedqty,this.FreeQty);
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


            public string Stock_Update1(string productid, string Qty, string plantid, string colorid, string storagelocid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=CONVERT(BIGINT,Quantity)+{0} WHERE MatId = {1}  and ColorId = {2} ", Qty, productid, colorid);
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

                    _commandText = string.Format("INSERT INTO [Stock] VALUES ({0},{1},{2},{3},{4},{5})", productid, colorid, Qty, plantid, storagelocid, Length);
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



            public string Stock_Update(string productid, string Qty, string plantid, string colorid, string storagelocid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity = Quantity-'{0}' WHERE MatId = {1}  and ColorId = {2} and Length = {3}", Qty, productid, colorid,Length);
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

            public string BlockStock_Update(string productid, string Qty,  string colorid, string matid,string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock_Block]", "Item_Code", productid, "Color_Id", colorid, "So_Id", matid) == true)
                {
                    //_commandText = string.Format("UPDATE [Stock_Block] SET  Qty=Qty-{0} WHERE Item_Code = {1}  and Color_Id = {2} and So_MatId = {3} ", Qty, productid, colorid,matid);
                    //_commandText = string.Format("UPDATE [Stock_Block] SET  Qty = CASE WHEN Qty-{0} < 0 THEN 0 ELSE Qty-{0} WHERE Item_Code = {1}  and Color_Id = {2} and So_Id = {3} and Length = {4} ", Qty, productid, colorid, matid,Length);

                    _commandText = string.Format("UPDATE [Stock_Block] SET  Qty = CASE WHEN ISNULL(Qty-{0}, 0) <= 0  THEN 0 ELSE (Qty-{0}) end WHERE Item_Code = {1}  and Color_Id = {2} and So_Id = {3} and Length = {4} ", Qty, productid, colorid, matid, Length);
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


            public int MaterialIssueDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Material_Issue_Details] WHERE Issue_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int MaterialIssue_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Material_Issue] WHERE  [Material_Issue].Issue_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.MaterialIssueId = dbManager.DataReader["Issue_Id"].ToString();
                    this.IssueNo = dbManager.DataReader["Issue_No"].ToString();
                    this.IssueDate = Convert.ToDateTime(dbManager.DataReader["Issue_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SoId = dbManager.DataReader["So_Id"].ToString();
                    this.RequestedBy = dbManager.DataReader["Reqested_By"].ToString();
                    this.ApprovedBy = dbManager.DataReader["Approved_By"].ToString();
                    this.Custid = dbManager.DataReader["Cust_Id"].ToString();
                    this.RequestPurpose = dbManager.DataReader["Req_Purpose"].ToString();
                    this.RequestId = dbManager.DataReader["Reqest_Id"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }




            public int MaterialIssueSoId_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Material_Issue] WHERE  [Material_Issue].Issue_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.MaterialIssueId = dbManager.DataReader["Issue_Id"].ToString();
                    this.IssueNo = dbManager.DataReader["Issue_No"].ToString();
                    this.IssueDate = Convert.ToDateTime(dbManager.DataReader["Issue_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SoId = dbManager.DataReader["So_Id"].ToString();
                    this.RequestedBy = dbManager.DataReader["Reqested_By"].ToString();
                    this.ApprovedBy = dbManager.DataReader["Approved_By"].ToString();
                    this.Custid = dbManager.DataReader["Cust_Id"].ToString();
                    this.RequestPurpose = dbManager.DataReader["Req_Purpose"].ToString();
                    this.RequestId = dbManager.DataReader["Reqest_Id"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }








            public void MaterialIssueDetails2_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Material_Issue_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Material_Issue_Details].Item_Code=[Material_Master].Material_Id  and Material_Issue_Details.Color_Id = Color_Master.Color_Id   AND [Material_Issue_Details].Issue_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("IssuedQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoMatId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Receivedqty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Slno");
                SalesOrderItems.Columns.Add(col);


                col = new DataColumn("ReceiveQty");
                SalesOrderItems.Columns.Add(col);


                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Description"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["IssuedQty"] = dbManager.DataReader["Issued_Qty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["SoMatId"] = dbManager.DataReader["So_det_Id"].ToString();
                    dr["Receivedqty"] = dbManager.DataReader["ReceiveQty"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["Slno"] = dbManager.DataReader["Issue_Det_Id"].ToString();
                    dr["ReceiveQty"] = "";


                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }





            public void MaterialIssueDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Material_Issue_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Material_Issue_Details].Item_Code=[Material_Master].Material_Id  and Material_Issue_Details.Color_Id = Color_Master.Color_Id   AND [Material_Issue_Details].Issue_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoMatId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("IssuedQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Slno");
                SalesOrderItems.Columns.Add(col);


                col = new DataColumn("ReceiveQty");
                SalesOrderItems.Columns.Add(col);


                col = new DataColumn("BlockedQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("FreeQty");
                SalesOrderItems.Columns.Add(col);





                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Description"].ToString();
                    dr["Length"] = dbManager.DataReader["Bar_Length"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ReqQty"] = dbManager.DataReader["Reqested_Qty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["SoMatId"] = dbManager.DataReader["So_det_Id"].ToString();
                    dr["IssuedQty"] = dbManager.DataReader["Issued_Qty"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["Slno"] = dbManager.DataReader["Issue_Det_Id"].ToString();
                    dr["ReceiveQty"] = "";

                    dr["BlockedQty"] = dbManager.DataReader["BlockedQty"].ToString();
                    dr["FreeQty"] = dbManager.DataReader["FreeQty"].ToString();


                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void MaterialIssue_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Issue_No+'-'+ProjectCode as issueno,Issue_Id FROM [Material_Issue],Sales_Order where [Material_Issue].So_Id =Sales_Order.SalesOrder_Id  ORDER BY Issue_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "issueno", "Issue_Id");
                }
            }

        }


        //Methods for MaterialGatePass
        public class MaterialGatePass
        {
            public string MaterialGateId, gatepassno, gatepassdate, ReceiverName, Address, ReceiverId, PreparedBy, Approvedby, Remarks;
            public string MatGatedetid, Itemcode, ColorId, Uom, Qty, Purpose,IssueType,Status;

            public MaterialGatePass()
            {
            }

            public static string MaterialGatePass_AutoGenCode()
            {
                return AutoGenMaxNo("Material_GatePass", "Gatepass_No");
            }
            public string MaterialGatePass_Save()
            {
                this.gatepassno = AutoGenMaxNo("Material_GatePass", "Gatepass_No");
                this.MaterialGateId = AutoGenMaxId("[Material_Issue]", "Issue_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Material_GatePass] VALUES({0},'{1}','{2}','{3}','{4}',{5},{6},{7},'{8}')", this.MaterialGateId, this.gatepassno, this.gatepassdate, this.ReceiverName, this.Address, this.ReceiverId, this.PreparedBy, this.Approvedby, this.Remarks);
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

            public string MaterialGatePass_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Material_GatePass] SET  Gatepass_No='{0}',Gatepass_Date='{1}',Receiver_Name='{2}',Address='{3}',Receiver_id={4},Prepared_By={5},Approved_By={6},Remarks='{7}' WHERE MaterialGatePass_Id={8}", this.gatepassno, this.gatepassdate, this.ReceiverName, this.Address, this.ReceiverId, this.PreparedBy, this.Approvedby, this.Remarks, this.MaterialGateId);
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

            public string MaterialGatePass_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[Material_GatePass_Details]", "MaterialGatePass_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[Material_GatePass]", "MaterialGatePass_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string MaterialGatePassDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Material_GatePass_Details] SELECT ISNULL(MAX(MaterialGatePass_Det_Id),0)+1,{0},{1},{2},'{3}',{4},'{5}','{6}' FROM [Material_GatePass_Details]", this.MaterialGateId, this.Itemcode, this.ColorId, this.Uom, this.Qty, this.Purpose, this.IssueType);
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

            public int MaterialGatePassDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Material_GatePass_Details] WHERE MaterialGatePass_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int MaterialGatePass_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Material_GatePass] WHERE  [Material_GatePass].MaterialGatePass_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.MaterialGateId = dbManager.DataReader["MaterialGatePass_Id"].ToString();
                    this.gatepassno = dbManager.DataReader["Gatepass_No"].ToString();
                    this.gatepassdate = Convert.ToDateTime(dbManager.DataReader["Gatepass_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.ReceiverName = dbManager.DataReader["Receiver_Name"].ToString();
                    this.Address = dbManager.DataReader["Address"].ToString();
                    this.ReceiverId = dbManager.DataReader["Receiver_id"].ToString();
                    this.PreparedBy = dbManager.DataReader["Prepared_By"].ToString();
                    this.Approvedby = dbManager.DataReader["Approved_By"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void MaterialIssueDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Material_Issue_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Material_Issue_Details].Item_Code=[Material_Master].Material_Id  and Material_Issue_Details.Color_Id = Color_Master.Color_Id   AND [Material_Issue_Details].Issue_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Series");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoMatId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("IssuedQty");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Series"] = dbManager.DataReader["Item_Series"].ToString();
                    dr["Length"] = dbManager.DataReader["Bar_Length"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ReqQty"] = dbManager.DataReader["Reqested_Qty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["SoMatId"] = dbManager.DataReader["So_det_Id"].ToString();
                    dr["IssuedQty"] = dbManager.DataReader["Issued_Qty"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void MaterialGatePass_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Material_GatePass] ORDER BY MaterialGatePass_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Gatepass_No", "MaterialGatePass_Id");
                }
            }

        }







        //Methods for RGP Request
        public class RGPRequest
        {
            public string RGPId, RgpNo, RgpDate, ReceiverName, Address, PreparedBy, ReceivedBy, status, Remarks,Requestfor,Project;
            public string RgpDetId, Itemcode, ColorId, Uom, Qty, Purpose, DetRemarks, ReceivedQty;

            public RGPRequest()
            {
            }

            public static string RGPRequest_AutoGenCode()
            {
                return AutoGenMaxNo("RGP_Request", "Rgp_Request_No");
            }
            public string RGPRequest_Save()
            {
                this.RgpNo = AutoGenMaxNo("RGP_Request", "Rgp_Request_No");
                this.RGPId = AutoGenMaxId("[RGP_Request]", "RGP_Request_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [RGP_Request] VALUES({0},'{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}','{9}',{10})", this.RGPId, this.RgpNo, this.RgpDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status, this.Remarks,this.Requestfor,this.Project);
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

            public string RGPRequest_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [RGP_Request] SET  Rgp_Request_No='{0}',Rgp_Request_Date='{1}',Receiver_Name='{2}',Address='{3}',PreparedBy={4},RequestedBy={5},Status='{6}',Remarks='{7}',Requestfor='{8}',Project={9} WHERE RGP_Request_Id = {10}", this.RgpNo, this.RgpDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status, this.Remarks,this.Requestfor,this.Project, this.RGPId);
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

            public string RGPRequest_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[RGP_Request_Details]", "Rgp_Request_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[RGP_Request]", "RGP_Request_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }



            public string Length,ProjectId;

            public string RGPRequestDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [RGP_Request_Details] SELECT ISNULL(MAX(Rgp_Request_Details_Id),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}','{7}',{8},{9} FROM [RGP_Request_Details]", this.RGPId, this.Itemcode, this.ColorId, this.Uom, this.Qty, this.Purpose, this.DetRemarks, this.ReceivedQty,this.Length,this.ProjectId);
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


            public string RGPRequestApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [RGP_Request] SET RequestedBy = {0} WHERE RGP_Request_Id ={1}", this.ReceivedBy, this.RGPId);
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



            public int RGPRequestDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [RGP_Request_Details] WHERE Rgp_Request_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int RGPRequest_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [RGP_Request] WHERE  [RGP_Request].RGP_Request_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.RGPId = dbManager.DataReader["RGP_Request_Id"].ToString();
                    this.RgpNo = dbManager.DataReader["Rgp_Request_No"].ToString();
                    this.RgpDate = Convert.ToDateTime(dbManager.DataReader["Rgp_Request_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.ReceiverName = dbManager.DataReader["Receiver_Name"].ToString();
                    this.Address = dbManager.DataReader["Address"].ToString();
                    this.PreparedBy = dbManager.DataReader["PreparedBy"].ToString();
                    this.ReceivedBy = dbManager.DataReader["RequestedBy"].ToString();
                    this.status = dbManager.DataReader["Status"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.Requestfor = dbManager.DataReader["Requestfor"].ToString();
                    this.Project = dbManager.DataReader["Project"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void RGPRequestDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [RGP_Request_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [RGP_Request_Details].Item_Id=[Material_Master].Material_Id  and RGP_Request_Details.Color_Id = Color_Master.Color_Id   AND [RGP_Request_Details].Rgp_Request_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Purpose");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ReceivedQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Slno");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ReceiveQty");
                SalesOrderItems.Columns.Add(col);


            

                col = new DataColumn("ProjectId");
                SalesOrderItems.Columns.Add(col);




                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ReqQty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Purpose"] = dbManager.DataReader["Purpose"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["ReceivedQty"] = dbManager.DataReader["RecievedQty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["Slno"] = dbManager.DataReader["Rgp_Request_Details_Id"].ToString();


                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["ProjectId"] = dbManager.DataReader["ProjectId"].ToString();


                    dr["ReceiveQty"] = "";
                    
                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }


            public static void RGPRequest_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT RGP_Request_Id,Rgp_Request_No FROM [RGP_Request] ORDER BY RGP_Request_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Rgp_Request_No", "RGP_Request_Id");
                }
            }


            public static void RGPRequestApprove_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT RGP_Request_Id,Rgp_Request_No FROM [RGP_Request] where RequestedBy != '0' and Status = 'Not Issued' ORDER BY RGP_Request_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Rgp_Request_No", "RGP_Request_Id");
                }
            }




        }







        //Methods for NRGP Request
        public class NRGPRequest
        {
            public string RGPId, RgpNo, RgpDate, ReceiverName, Address, PreparedBy, ReceivedBy, status, Remarks,Requestfor,Project;
            public string RgpDetId, Itemcode, ColorId, Uom, Qty, Purpose, DetRemarks, ReceivedQty,Length;

            public NRGPRequest()
            {
            }

            public static string NRGPRequest_AutoGenCode()
            {
                return AutoGenMaxNo("NRGP_Request", "NRgp_Request_No");
            }
            public string NRGPRequest_Save()
            {
                this.RgpNo = AutoGenMaxNo("NRGP_Request", "NRgp_Request_No");
                this.RGPId = AutoGenMaxId("[NRGP_Request]", "NRGP_Request_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [NRGP_Request] VALUES({0},'{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}','{9}',{10})", this.RGPId, this.RgpNo, this.RgpDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status, this.Remarks,this.Requestfor,this.Project);
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

            public string NRGPRequest_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [NRGP_Request] SET  NRgp_Request_No='{0}',NRgp_Request_Date='{1}',Receiver_Name='{2}',Address='{3}',PreparedBy={4},RequestedBy={5},Status='{6}',Remarks='{7}',Requestfor='{8}',Project={9} WHERE NRGP_Request_Id = {10}", this.RgpNo, this.RgpDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status, this.Remarks,this.Requestfor,this.Project, this.RGPId);
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

            public string NRGPRequest_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[NRGP_Request_Details]", "NRgp_Request_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[NRGP_Request]", "NRGP_Request_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string NRGPRequestDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [NRGP_Request_Details] SELECT ISNULL(MAX(NRgp_Request_Details_Id),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}','{7}',{8},{9} FROM [NRGP_Request_Details]", this.RGPId, this.Itemcode, this.ColorId, this.Uom, this.Qty, this.Purpose, this.DetRemarks, this.ReceivedQty,this.Length,this.Project);
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


            public string NRGPRequestApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [NRGP_Request] SET RequestedBy = {0} WHERE NRGP_Request_Id ={1}", this.ReceivedBy, this.RGPId);
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



            public int NRGPRequestDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [NRGP_Request_Details] WHERE NRgp_Request_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int NRGPRequest_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [NRGP_Request] WHERE  [NRGP_Request].NRGP_Request_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.RGPId = dbManager.DataReader["NRGP_Request_Id"].ToString();
                    this.RgpNo = dbManager.DataReader["NRgp_Request_No"].ToString();
                    this.RgpDate = Convert.ToDateTime(dbManager.DataReader["NRgp_Request_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.ReceiverName = dbManager.DataReader["Receiver_Name"].ToString();
                    this.Address = dbManager.DataReader["Address"].ToString();
                    this.PreparedBy = dbManager.DataReader["PreparedBy"].ToString();
                    this.ReceivedBy = dbManager.DataReader["RequestedBy"].ToString();
                    this.status = dbManager.DataReader["Status"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();

                    this.Requestfor = dbManager.DataReader["Requestfor"].ToString();
                    this.Project = dbManager.DataReader["Project"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void NRGPRequestDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [NRGP_Request_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [NRGP_Request_Details].Item_Id=[Material_Master].Material_Id  and NRGP_Request_Details.Color_Id = Color_Master.Color_Id   AND [NRGP_Request_Details].NRgp_Request_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Purpose");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ReceivedQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Slno");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ReceiveQty");
                SalesOrderItems.Columns.Add(col);


                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ProjectId");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ReqQty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Purpose"] = dbManager.DataReader["Purpose"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["ReceivedQty"] = dbManager.DataReader["RecievedQty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["Slno"] = dbManager.DataReader["NRgp_Request_Details_Id"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();

                    dr["ProjectId"] = dbManager.DataReader["ProjectId"].ToString();

                    dr["ReceiveQty"] = "";
                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }


            public static void NRGPRequest_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT NRGP_Request_Id,NRgp_Request_No FROM [NRGP_Request] ORDER BY NRGP_Request_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "NRgp_Request_No", "NRGP_Request_Id");
                }
            }


           


            public static void NRGPRequestApprove_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT NRGP_Request_Id,NRgp_Request_No FROM [NRGP_Request] where RequestedBy != '0' and Status = 'Not Issued' ORDER BY NRGP_Request_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "NRgp_Request_No", "NRGP_Request_Id");
                }
            }





        }














        //Methods for RGP
        public class RGP
        {
            public string RGPId, RgpNo, RgpDate, ReceiverName, Address, PreparedBy, ReceivedBy,status, Remarks,Requestrgpid,ProjectId;
            public string RgpDetId, Itemcode, ColorId, Uom, Qty, Purpose, DetRemarks, ReceivedQty;

            public RGP()
            {
            }

            public static string RGP_AutoGenCode()
            {
                return AutoGenMaxNo("RGP", "Rgp_No");
            }
            public string RGP_Save()
            {
                this.RgpNo = AutoGenMaxNo("RGP", "Rgp_No");
                this.RGPId = AutoGenMaxId("[RGP]", "RGP_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [RGP] VALUES({0},'{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}',{9},{10})", this.RGPId, this.RgpNo, this.RgpDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status,this.Remarks,this.Requestrgpid,this.ProjectId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                if (this.Requestrgpid != "0")
                {
                    _commandText = string.Format("UPDATE [RGP_Request] SET  Status='Issued' WHERE RGP_Request_Id = {0}", this.Requestrgpid);
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

            public string RGP_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [RGP] SET  Rgp_No='{0}',Rgp_Date='{1}',Receiver_Name='{2}',Address='{3}',PreparedBy={4},ReceivedBy={5},Status='{6}',Remarks='{7}',RequestedRgp_Id={8},ProjectId={9} WHERE RGP_Id = {10}", this.RgpNo, this.RgpDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status, this.Remarks,this.Requestrgpid,this.ProjectId, this.RGPId);
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

            public string RGP_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[RGP_Details]", "Rgp_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[RGP]", "RGP_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string Length,BlockedQty,FreeQty;
            public string RGPDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [RGP_Details] SELECT ISNULL(MAX(Rgp_Details_Id),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}','{7}',{8},{9},'{10}','{11}' FROM [RGP_Details]", this.RGPId, this.Itemcode, this.ColorId, this.Uom, this.Qty, this.Purpose,this.DetRemarks, this.ReceivedQty,this.Length,this.ProjectId,this.BlockedQty,this.FreeQty);
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


            public string Stock_UpdatePQC(string productid, string Qty, string colorid,string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity = Quantity-'{0}' WHERE MatId = {1}  and ColorId = {2} and Length = {3}", Qty, productid, colorid, Length);
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


            public string BlockStock_Update(string productid, string Qty, string colorid, string matid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock_Block]", "Item_Code", productid, "Color_Id", colorid, "So_Id", matid) == true)
                {
                    //_commandText = string.Format("UPDATE [Stock_Block] SET  Qty=Qty-{0} WHERE Item_Code = {1}  and Color_Id = {2} and So_MatId = {3} ", Qty, productid, colorid,matid);
                    //_commandText = string.Format("UPDATE [Stock_Block] SET  Qty = CASE WHEN Qty-{0} < 0 THEN 0 ELSE Qty-{0} WHERE Item_Code = {1}  and Color_Id = {2} and So_Id = {3} and Length = {4} ", Qty, productid, colorid, matid,Length);

                    _commandText = string.Format("UPDATE [Stock_Block] SET  Qty = CASE WHEN ISNULL(Qty-{0}, 0) <= 0  THEN 0 ELSE (Qty-{0}) end WHERE Item_Code = {1}  and Color_Id = {2} and So_Id = {3} and Length = {4} ", Qty, productid, colorid, matid, Length);
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

            public int RGPDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [RGP_Details] WHERE Rgp_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int RGP_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [RGP] WHERE  [RGP].RGP_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.RGPId = dbManager.DataReader["RGP_Id"].ToString();
                    this.RgpNo = dbManager.DataReader["Rgp_No"].ToString();
                    this.RgpDate = Convert.ToDateTime(dbManager.DataReader["Rgp_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.ReceiverName = dbManager.DataReader["Receiver_Name"].ToString();
                    this.Address = dbManager.DataReader["Address"].ToString();

                    this.PreparedBy = dbManager.DataReader["PreparedBy"].ToString();
                    this.ReceivedBy = dbManager.DataReader["ReceivedBy"].ToString();
                    this.status = dbManager.DataReader["Status"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.ProjectId = dbManager.DataReader["ProjectId"].ToString();
                    this.Requestrgpid = dbManager.DataReader["RequestedRgp_Id"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void RGPDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                //_commandText = string.Format("SELECT * FROM [RGP_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [RGP_Details].Item_Id=[Material_Master].Material_Id  and RGP_Details.Color_Id = Color_Master.Color_Id   AND [RGP_Details].Rgp_Id=" + MaterialRequestId);
                _commandText = string.Format("SELECT * FROM [RGP_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [RGP_Details].Item_Id=[Material_Master].Material_Id  and RGP_Details.Color_Id = Color_Master.Color_Id  and RecievedQty != Qty and  RecievedQty < Qty  AND [RGP_Details].Rgp_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Purpose");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ReceivedQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Slno");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ReceiveQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("BlockedQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("FreeQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("SoId");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Receivelength");
                SalesOrderItems.Columns.Add(col);




                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ReqQty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Purpose"] = dbManager.DataReader["Purpose"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["ReceivedQty"] = dbManager.DataReader["RecievedQty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["Slno"] = dbManager.DataReader["Rgp_Details_Id"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();

                    dr["BlockedQty"] = dbManager.DataReader["BlockedQty"].ToString();
                    dr["FreeQty"] = dbManager.DataReader["FreeQty"].ToString();

                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();

                    dr["ReceiveQty"] = "";
                    dr["Receivelength"] = "";


                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }





            public void rECEIVEDRGPDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [RGP_Return_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [RGP_Return_Details].Item_Id=[Material_Master].Material_Id  and RGP_Return_Details.Color_Id = Color_Master.Color_Id   AND [RGP_Return_Details].Rgp_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Purpose");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ReceivedQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);

              


                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ReqQty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Purpose"] = dbManager.DataReader["Purpose"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["ReceivedQty"] = dbManager.DataReader["RecievedQty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
               

                
                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }






            public static void RGP_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [RGP] ORDER BY RGP_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Rgp_No", "RGP_Id");
                }
            }

        }


        //Methods for NRGP
        public class NRGP
        {
            public string NRGPId, NRgpNo, NRgpDate, ReceiverName, Address, PreparedBy, ReceivedBy, status, Remarks, Length, RequestNrgpid,projectid,description;
            public string NRgpDetId, Itemcode, ColorId, Uom, Qty, Purpose, DetRemarks, ReceivedQty,Blockedqty,freeQty;

            public NRGP()
            {
            }

            public static string NRGP_AutoGenCode()
            {
                return AutoGenMaxNo("NRGP", "NRgp_No");
            }
            public string NRGP_Save()
            {
                this.NRgpNo = AutoGenMaxNo("NRGP", "NRgp_No");
                this.NRGPId = AutoGenMaxId("[NRGP]", "NRGP_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [NRGP] VALUES({0},'{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}',{9},{10})", this.NRGPId, this.NRgpNo, this.NRgpDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status, this.Remarks,this.RequestNrgpid,this.projectid);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                if(this.RequestNrgpid != "0")
                { 
                 _commandText = string.Format("UPDATE [NRGP_Request] SET  Status='Issued' WHERE NRGP_Request_Id={0}", this.RequestNrgpid);
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

            public string NRGP_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [NRGP] SET  NRgp_No='{0}',NRgp_Date='{1}',Receiver_Name='{2}',Address='{3}',PreparedBy={4},ReceivedBy={5},Status='{6}',Remarks='{7}',RequestedNRgp_Id={8},ProjectId={9} WHERE NRGP_Id = {10}", this.NRgpNo, this.NRgpDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status, this.Remarks,this.RequestNrgpid,this.projectid, this.NRGPId);
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

            public string NRGP_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[NRGP_Details]", "NRgp_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[NRGP]", "NRGP_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string NRGPDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [NRGP_Details] SELECT ISNULL(MAX(NRgp_Details_Id),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}','{7}',{8},{9},'{10}','{11}','{12}' FROM [NRGP_Details]", this.NRGPId, this.Itemcode, this.ColorId, this.Uom, this.Qty, this.Purpose, this.DetRemarks, this.ReceivedQty,this.Length,this.projectid,this.Blockedqty,this.freeQty,this.description);
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
            public string Stock_UpdatePQC(string productid, string Qty, string colorid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity = Quantity-'{0}' WHERE MatId = {1}  and ColorId = {2} and Length = {3}", Qty, productid, colorid, Length);
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

            public string BlockStock_Update(string productid, string Qty, string colorid, string matid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock_Block]", "Item_Code", productid, "Color_Id", colorid, "So_Id", matid) == true)
                {
                    //_commandText = string.Format("UPDATE [Stock_Block] SET  Qty=Qty-{0} WHERE Item_Code = {1}  and Color_Id = {2} and So_MatId = {3} ", Qty, productid, colorid,matid);
                    //_commandText = string.Format("UPDATE [Stock_Block] SET  Qty = CASE WHEN Qty-{0} < 0 THEN 0 ELSE Qty-{0} WHERE Item_Code = {1}  and Color_Id = {2} and So_Id = {3} and Length = {4} ", Qty, productid, colorid, matid,Length);

                    _commandText = string.Format("UPDATE [Stock_Block] SET  Qty = CASE WHEN ISNULL(Qty-{0}, 0) <= 0  THEN 0 ELSE (Qty-{0}) end WHERE Item_Code = {1}  and Color_Id = {2} and So_Id = {3} and Length = {4} ", Qty, productid, colorid, matid, Length);
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
            public int NRGPDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [NRGP_Details] WHERE NRgp_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int NRGP_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [NRGP] WHERE  [NRGP].NRGP_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.NRGPId = dbManager.DataReader["NRGP_Id"].ToString();
                    this.NRgpNo = dbManager.DataReader["NRgp_No"].ToString();
                    this.NRgpDate = Convert.ToDateTime(dbManager.DataReader["NRgp_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.ReceiverName = dbManager.DataReader["Receiver_Name"].ToString();
                    this.Address = dbManager.DataReader["Address"].ToString();

                    this.PreparedBy = dbManager.DataReader["PreparedBy"].ToString();
                    this.ReceivedBy = dbManager.DataReader["ReceivedBy"].ToString();
                    this.status = dbManager.DataReader["Status"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();


                    this.projectid = dbManager.DataReader["ProjectId"].ToString();
                    this.RequestNrgpid = dbManager.DataReader["RequestedNRgp_Id"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void NRGPDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [NRGP_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [NRGP_Details].Item_Id=[Material_Master].Material_Id  and NRGP_Details.Color_Id = Color_Master.Color_Id   AND [NRGP_Details].NRgp_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Purpose");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ReceivedQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Slno");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ReceiveQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesOrderItems.Columns.Add(col);


                col = new DataColumn("BlockedQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("FreeQty");
                SalesOrderItems.Columns.Add(col);




                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ReqQty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Purpose"] = dbManager.DataReader["Purpose"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["ReceivedQty"] = dbManager.DataReader["RecievedQty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["Slno"] = dbManager.DataReader["NRgp_Details_Id"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["SoId"] = dbManager.DataReader["ProjectId"].ToString();

                    dr["BlockedQty"] = dbManager.DataReader["BlockedQty"].ToString();
                    dr["FreeQty"] = dbManager.DataReader["FreeQty"].ToString();


                    dr["ReceiveQty"] = "";
                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void NRGP_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [NRGP] ORDER BY NRGP_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "NRgp_No", "NRGP_Id");
                }
            }

        }


        //Methods for Return RGP
        public class ReturnRGP
        {
            public string RRGPId, RRgpNo, RRgpDate, ReceiverName, Address, PreparedBy, ReceivedBy, status, Remarks,Rgpid;
            public string RRgpDetId, Itemcode, ColorId, Uom, Qty, Purpose, DetRemarks, ReceivedQty,length;

            public ReturnRGP()
            {
            }

            public static string ReturnRGP_AutoGenCode()
            {
                return AutoGenMaxNo("RGP_Return", "Rgp_Return_No");
            }
            public string ReturnRGP_Save()
            {
                this.RRgpNo = AutoGenMaxNo("RGP_Return", "Rgp_Return_No");
                this.RRGPId = AutoGenMaxId("[RGP_Return]", "RGP_Return_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [RGP_Return] VALUES({0},'{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}',{9})", this.RRGPId, this.RRgpNo, this.RRgpDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status, this.Remarks,this.Rgpid);
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

            public string ReturnRGP_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [RGP_Return] SET  Rgp_Return_No='{0}',Rgp_Return_Date='{1}',Receiver_Name='{2}',Address='{3}',PreparedBy={4},ReceivedBy={5},Status='{6}',Remarks='{7}',Rgp_Id={8} WHERE RGP_Return_Id = {9}", this.RRgpNo, this.RRgpDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status, this.Remarks,this.Rgpid, this.RRGPId);
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

            public string ReturnRGP_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[RGP_Return_Details]", "Rgp_Return_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[RGP_Return]", "RGP_Return_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string ReturnRGPDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [RGP_Return_Details] SELECT ISNULL(MAX(Rgp_Return_Details_Id),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}','{7}',{8},{9} FROM [RGP_Return_Details]", this.RRGPId, this.Itemcode, this.ColorId, this.Uom, this.Qty, this.Purpose, this.DetRemarks, this.ReceivedQty,this.Rgpid,this.length);
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

            public int ReturnRGPDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [RGP_Return_Details] WHERE Rgp_Return_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }


            public string rgpdetid;

            public string RgpDetailsRemainingQty_Update(string podetid, string receivedqty)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [RGP_Details] SET  RecievedQty=RecievedQty+{0} WHERE Rgp_Details_Id = {1} ", receivedqty, podetid);
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


            public string Stock_UpdatePQC(string productid, string Qty, string colorid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=Quantity+'{0}' WHERE MatId = {1}  and ColorId = {2} ", Qty, productid, colorid);
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

            public string Stock_Update1(string productid, string Qty, string plantid, string colorid, string storagelocid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "Length", Length) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=Quantity+'{0}' WHERE MatId = {1}  and ColorId = {2} and Length ={3} ", Qty, productid, colorid, Length);
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

                    _commandText = string.Format("INSERT INTO [Stock] VALUES ({0},{1},'{2}',{3},{4},{5})", productid, colorid, Qty, plantid, storagelocid, Length);
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



            public int ReturnRGP_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [RGP_Return] WHERE  [RGP_Return].RGP_Return_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.RRGPId = dbManager.DataReader["RGP_Return_Id"].ToString();
                    this.RRgpNo = dbManager.DataReader["Rgp_Return_No"].ToString();
                    this.RRgpDate = Convert.ToDateTime(dbManager.DataReader["Rgp_Return_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.ReceiverName = dbManager.DataReader["Receiver_Name"].ToString();
                    this.Address = dbManager.DataReader["Address"].ToString();

                    this.PreparedBy = dbManager.DataReader["PreparedBy"].ToString();
                    this.ReceivedBy = dbManager.DataReader["ReceivedBy"].ToString();
                    this.status = dbManager.DataReader["Status"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.Rgpid = dbManager.DataReader["Rgp_Id"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void ReturnRGPDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [RGP_Return_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [RGP_Return_Details].Item_Id=[Material_Master].Material_Id  and RGP_Return_Details.Color_Id = Color_Master.Color_Id   AND [RGP_Return_Details].Rgp_Return_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Purpose");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ReceivedQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);



                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ReqQty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Purpose"] = dbManager.DataReader["Purpose"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["ReceivedQty"] = dbManager.DataReader["RecievedQty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();



                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void ReturnRGP_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [RGP_Return] ORDER BY RGP_Return_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Rgp_Return_No", "RGP_Return_Id");
                }
            }

        }





        //Methods for Return Production Change to Cut Pices Return
        public class ReturnProduction
        {
            public string ReturnId, Purpose, ReturnDate, SoId, ReturnBy, PreparedBy, Custid, ReturnNo, MatissueId, ReturnFrom;
            public string ReturnDetId, Itemcode, ColorId, Qty,  DetRemarks,SoDetId,Length;

            public ReturnProduction()
            {
            }

            public static string ReturnProduction_AutoGenCode()
            {
                return AutoGenMaxNo("Production_Return", "ReturnIssue_No");
            }
            public string ReturnProduction_Save()
            {
                this.ReturnNo = AutoGenMaxNo("Production_Return", "ReturnIssue_No");
                this.ReturnId = AutoGenMaxId("[Production_Return]", "ReturnIssue_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Production_Return] VALUES({0},'{1}','{2}',{3},{4},{5},{6},'{7}',{8},'{9}')", this.ReturnId, this.Purpose, this.ReturnDate, this.SoId, this.ReturnBy, this.PreparedBy, this.Custid, this.ReturnNo, this.MatissueId, this.ReturnFrom);
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

            public string ReturnProduction_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Production_Return] SET  Return_Purpose='{0}',Return_Date='{1}',So_Id={2},Return_By={3},PreparedBy={4},Cust_Id={5},ReturnIssue_No='{6}',Issue_Id={7},Return_From='{8}' WHERE ReturnIssue_Id = {9}", this.Purpose, this.ReturnDate, this.SoId, this.ReturnBy, this.PreparedBy, this.Custid, this.ReturnNo, this.MatissueId, this.ReturnFrom, this.ReturnId);
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

            public string ReturnProduction_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[ProductionReturn_Details]", "ProductionReturn_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[Production_Return]", "ReturnIssue_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string ReturnProductionDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [ProductionReturn_Details] SELECT ISNULL(MAX(ReturnIssue_Det_Id),0)+1,{0},{1},{2},'{3}','{4}',{5},{6},{7} FROM [ProductionReturn_Details]", this.ReturnId, this.Itemcode, this.ColorId, this.Qty, this.DetRemarks, this.SoDetId, this.Length,this.SoId);
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

            public int ReturnProductionDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [ProductionReturn_Details] WHERE ProductionReturn_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }


            public string rgpdetid;

            public string RgpDetailsRemainingQty_Update(string podetid, string receivedqty)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [RGP_Details] SET  RecievedQty=CONVERT(BIGINT,RecievedQty)+{0} WHERE Rgp_Details_Id = {1} ", receivedqty, podetid);
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


            public string Stock_UpdatePQC(string productid, string Qty, string colorid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=CONVERT(BIGINT,Quantity)+{0} WHERE MatId = {1}  and ColorId = {2} ", Qty, productid, colorid);
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


            public string Stock_Update1(string productid, string Qty, string plantid, string colorid, string storagelocid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid,"Length",Length) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=Quantity+'{0}' WHERE MatId = {1}  and ColorId = {2} and Length ={3} ", Qty, productid, colorid,Length);
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

                    _commandText = string.Format("INSERT INTO [Stock] VALUES ({0},{1},'{2}',{3},{4},{5})", productid, colorid, Qty, plantid, storagelocid, Length);
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


            public int ReturnProduction_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Production_Return] WHERE  [Production_Return].ReturnIssue_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ReturnId = dbManager.DataReader["ReturnIssue_Id"].ToString();
                    this.Purpose = dbManager.DataReader["Return_Purpose"].ToString();
                    this.ReturnDate = Convert.ToDateTime(dbManager.DataReader["Return_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SoId = dbManager.DataReader["So_Id"].ToString();
                    this.ReturnBy = dbManager.DataReader["Return_By"].ToString();

                    this.PreparedBy = dbManager.DataReader["Prepared_By"].ToString();
                    this.Custid = dbManager.DataReader["Cust_Id"].ToString();
                    this.ReturnNo = dbManager.DataReader["ReturnIssue_No"].ToString();
                    this.MatissueId = dbManager.DataReader["Issue_Id"].ToString();
                    this.ReturnFrom = dbManager.DataReader["Return_From"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void ReturnProductionDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [ProductionReturn_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [ProductionReturn_Details].Item_Code=[Material_Master].Material_Id  and ProductionReturn_Details.Color_Id = Color_Master.Color_Id   AND [ProductionReturn_Details].ProductionReturn_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoMatId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReceivingQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);


                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["SoMatId"] = dbManager.DataReader["So_det_Id"].ToString();
                    dr["ReceivingQty"] = dbManager.DataReader["Received_Qty"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();



                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void ReturnProduction_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Production_Return] ORDER BY ReturnIssue_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "ReturnIssue_No", "ReturnIssue_Id");
                }
            }

        }








        //Methods for BulkReturn Production Return
        public class BulkReturnProduction
        {
            public string ReturnId, Purpose, ReturnDate, SoId, ReturnBy, PreparedBy, Custid, ReturnNo, BulkRequetId, ReturnFrom;
            public string ReturnDetId, Itemcode, ColorId, Qty, DetRemarks, Length;

            public BulkReturnProduction()
            {
            }

            public static string BulkReturnProduction_AutoGenCode()
            {
                return AutoGenMaxNo("BulkReturnMaterial", "BulkReturnIssue_No");
            }
            public string BulkReturnProduction_Save()
            {
                this.ReturnNo = AutoGenMaxNo("BulkReturnMaterial", "BulkReturnIssue_No");
                this.ReturnId = AutoGenMaxId("BulkReturnMaterial", "BulkReturnIssue_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [BulkReturnMaterial] VALUES({0},'{1}','{2}',{3},{4},{5},{6},'{7}',{8},'{9}')", this.ReturnId, this.Purpose, this.ReturnDate, this.SoId, this.ReturnBy, this.PreparedBy, this.Custid, this.ReturnNo, this.BulkRequetId, this.ReturnFrom);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
               
                
                if(BulkRequetId != "0")
                {
                    _commandText = string.Format("UPDATE [Request_Bulk_Production_Return] SET  Status='Issued' WHERE Request_ReturnIssue_Id = {0}", this.BulkRequetId);
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

            public string BulkReturnProduction_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [BulkReturnMaterial] SET  BulkReturn_Purpose='{0}',BulkReturn_Date='{1}',So_Id={2},BulkReturn_By={3},BulkPreparedBy={4},Cust_Id={5},BulkReturnIssue_No='{6}',RequestBulkIssue_Id={7},Return_From='{8}' WHERE BulkReturnIssue_Id = {9}", this.Purpose, this.ReturnDate, this.SoId, this.ReturnBy, this.PreparedBy, this.Custid, this.ReturnNo, this.BulkRequetId, this.ReturnFrom, this.ReturnId);
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

            public string BulkReturnProduction_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[BulkReturnMaterial_Details]", "BulkReturn_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[BulkReturnMaterial]", "BulkReturnIssue_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string BulkReturnProductionDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [BulkReturnMaterial_Details] SELECT ISNULL(MAX(BulkReturnIssue_Det_Id),0)+1,{0},{1},{2},'{3}','{4}','{5}',{6} FROM [BulkReturnMaterial_Details]", this.ReturnId, this.Itemcode, this.ColorId, this.Qty, this.DetRemarks, this.Length, this.SoId);
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

            public int BulkReturnProductionDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [BulkReturnMaterial_Details] WHERE BulkReturn_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }


      
            public string Stock_UpdatePQC(string productid, string Qty, string colorid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=CONVERT(BIGINT,Quantity)+{0} WHERE MatId = {1}  and ColorId = {2} ", Qty, productid, colorid);
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


            public string Stock_Update1(string productid, string Qty, string plantid, string colorid, string storagelocid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "Length", Length) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=Quantity+'{0}' WHERE MatId = {1}  and ColorId = {2} and Length ={3} ", Qty, productid, colorid, Length);
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

                    _commandText = string.Format("INSERT INTO [Stock] VALUES ({0},{1},'{2}',{3},{4},{5})", productid, colorid, Qty, plantid, storagelocid, Length);
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


            public int BulkReturnProduction_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [BulkReturnMaterial] WHERE  [BulkReturnMaterial].BulkReturnIssue_Id = '" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ReturnId = dbManager.DataReader["BulkReturnIssue_Id"].ToString();
                    this.Purpose = dbManager.DataReader["BulkReturn_Purpose"].ToString();
                    this.ReturnDate = Convert.ToDateTime(dbManager.DataReader["BulkReturn_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SoId = dbManager.DataReader["So_Id"].ToString();
                    this.ReturnBy = dbManager.DataReader["BulkReturn_By"].ToString();

                    this.PreparedBy = dbManager.DataReader["BulkPreparedBy"].ToString();
                    this.Custid = dbManager.DataReader["Cust_Id"].ToString();
                    this.ReturnNo = dbManager.DataReader["BulkReturnIssue_No"].ToString();
                    this.BulkRequetId = dbManager.DataReader["RequestBulkIssue_Id"].ToString();
                    this.ReturnFrom = dbManager.DataReader["Return_From"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void BulkReturnProductionDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [BulkReturnMaterial_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [BulkReturnMaterial_Details].Item_Code=[Material_Master].Material_Id  and BulkReturnMaterial_Details.Color_Id = Color_Master.Color_Id   AND [BulkReturnMaterial_Details].BulkReturn_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
              
                col = new DataColumn("ReceivingQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesOrderItems.Columns.Add(col);


                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Code"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                
                    dr["ReceivingQty"] = dbManager.DataReader["Received_Qty"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();

                    dr["SoId"] = dbManager.DataReader["So_Id"].ToString();


                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void BulkReturnProduction_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [BulkReturnMaterial] ORDER BY BulkReturnIssue_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "BulkReturnIssue_No", "BulkReturnIssue_Id");
                }
            }

            public string BlockStock_Update1(string productid, string Qty, string colorid, string Length, string SOid)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock_Block]", "Item_Code", productid, "Color_Id", colorid, "Length", Length, "So_Id", SOid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock_Block] SET  Qty = Qty+'{0}' WHERE Item_Code = {1}  and Color_Id = {2} and Length ={3} and So_Id = {4} ", Qty, productid, colorid, Length, SOid);
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
                    _commandText = string.Format("INSERT INTO [Stock_Block] SELECT ISNULL(MAX(BlockStock_Id),0)+1,{0},{1},'{2}',{3},{4},{5},{6},'{7}',{8},{9},'{10}' FROM [Stock_Block]", SOid, productid, Qty, colorid, '0', '0', Length, Qty, '0', '0', "From Production Return");
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


            //public string BlockStock_Update1(string productid, string Qty, string colorid, string Length, string SOid, string ProjId)
            //{
            //    if (dbManager.Transaction == null)
            //        dbManager.Open();
            //    // if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "PlantId", plantid, "StoragelocId", storagelocid, "Length",Length) == true)

            //    if (IsRecordExists("[Stock_Block]", "Item_Code", productid, "Color_Id", colorid, "Length", Length, "So_Id", SOid, "Project_Id", ProjId) == true)
            //    {
            //        _commandText = string.Format("UPDATE [Stock_Block] SET  Qty = Qty+'{0}' WHERE Item_Code = {1}  and Color_Id = {2} and Length ={3} and So_Id = {4} and Project_Id ={5}  ", Qty, productid, colorid, Length, SOid, ProjId);
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
            //        _commandText = string.Format("INSERT INTO [Stock_Block] SELECT ISNULL(MAX(BlockStock_Id),0)+1,{0},{1},'{2}',{3},{4},{5},{6},'{7}',{8},{9},'{10}' FROM [Stock_Block]", SOid, productid, Qty, colorid, this.SoMatId, this.ReserveId, this.Length, this.Qty, this.CustID, this.ProjectId, this.Remarks);
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




        }










       // Methods for ReturnIssueSlip
        public class ReturnIssueSlip
        {
            public string IssueReturnId, IssueReturnNo, IssuereturnDate, ReceiverName, Address, PreparedBy, ReceivedBy, status, Remarks, IssueId;
            public string IssueReturnDetId, Itemcode, ColorId, Uom, Qty, Purpose, DetRemarks, ReceivedQty,Length;

            public ReturnIssueSlip()
            {
            }

            public static string ReturnIssueSlip_AutoGenCode()
            {
                return AutoGenMaxNo("Issue_Return", "Issue_Return_No");
            }
            public string ReturnIssueSlip_Save()
            {
                this.IssueReturnNo = AutoGenMaxNo("Issue_Return", "Issue_Return_No");
                this.IssueReturnId = AutoGenMaxId("[Issue_Return]", "Issue_Return_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Issue_Return] VALUES({0},'{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}',{9})", this.IssueReturnId, this.IssueReturnNo, this.IssuereturnDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status, this.Remarks, this.IssueId);
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

            public string ReturnIssueSlip_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Issue_Return] SET  Issue_Return_No='{0}',Issue_Return_Date='{1}',Receiver_Name='{2}',Address='{3}',PreparedBy={4},ReceivedBy={5},Status='{6}',Remarks='{7}',Issue_Id={8} WHERE Issue_Return_Id = {9}", this.IssueReturnNo, this.IssuereturnDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status, this.Remarks, this.IssueId, this.IssueReturnId);
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

            public string ReturnIssueSlip_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[Issue_Return_Details]", "Issue_Return_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[Issue_Return]", "Issue_Return_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string ReturnIssueSlipDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Issue_Return_Details] SELECT ISNULL(MAX(Issue_Return_Details_Id),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}','{7}',{8},{9} FROM [Issue_Return_Details]", this.IssueReturnId, this.Itemcode, this.ColorId, this.Uom, this.Qty, this.Purpose, this.DetRemarks, this.ReceivedQty, this.IssueId,this.Length);
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



            public string IssuedetId;

            public string IssueDetailsRemainingQty_Update(string podetid, string receivedqty)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Material_Issue_Details] SET  Receivedqty=Receivedqty+'{0}' WHERE Issue_Det_Id = {1} ", receivedqty, podetid);
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


            public string Stock_UpdatePQC(string productid, string Qty, string colorid,string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid) == true)
                {
                    //_commandText = string.Format("UPDATE [Stock] SET  Quantity=CONVERT(BIGINT,Quantity)+{0} WHERE MatId = {1}  and ColorId = {2} ", Qty, productid, colorid);

                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=Quantity+'{0}' WHERE MatId = {1}  and ColorId = {2} and Length = {3}", Qty, productid, colorid,Length);
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

            public int ReturnIssueDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Issue_Return_Details] WHERE Issue_Return_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int ReturnIssueSlip_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Issue_Return] WHERE  [Issue_Return].Issue_Return_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.IssueReturnId = dbManager.DataReader["Issue_Return_Id"].ToString();
                    this.IssueReturnNo = dbManager.DataReader["Issue_Return_No"].ToString();
                    this.IssuereturnDate = Convert.ToDateTime(dbManager.DataReader["Issue_Return_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.ReceiverName = dbManager.DataReader["Receiver_Name"].ToString();
                    this.Address = dbManager.DataReader["Address"].ToString();
                    this.PreparedBy = dbManager.DataReader["PreparedBy"].ToString();
                    this.ReceivedBy = dbManager.DataReader["ReceivedBy"].ToString();
                    this.status = dbManager.DataReader["Status"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.IssueId = dbManager.DataReader["Issue_Id"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void ReturnIssueDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Issue_Return_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Issue_Return_Details].Item_Id=[Material_Master].Material_Id  and Issue_Return_Details.Color_Id = Color_Master.Color_Id   AND [Issue_Return_Details].Issue_Return_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Purpose");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ReceivedQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);

                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ReqQty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Purpose"] = dbManager.DataReader["Purpose"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["ReceivedQty"] = dbManager.DataReader["RecievedQty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();

                    dr["Length"] = dbManager.DataReader["Length"].ToString();



                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void IssueReturn_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Issue_Return] ORDER BY Issue_Return_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Issue_Return_No", "Issue_Return_Id");
                }
            }

        }







       // Methods for ReturnNRGP
        public class ReturnNRGP
        {
            public string RNRGPId, RNRgpNo, RNRgpDate, ReceiverName, Address, PreparedBy, ReceivedBy, status, Remarks,Nrgpid;
            public string RNRgpDetId, Itemcode, ColorId, Uom, Qty, Purpose, DetRemarks, ReceivedQty;

            public ReturnNRGP()
            {
            }

            public static string RNRGP_AutoGenCode()
            {
                return AutoGenMaxNo("NRGP_Return", "NRgp_Return_No");
            }
            public string RNRGP_Save()
            {
                this.RNRgpNo = AutoGenMaxNo("NRGP_Return", "NRgp_Return_No");
                this.RNRGPId = AutoGenMaxId("[NRGP_Return]", "NRGP_Return_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [NRGP_Return] VALUES({0},'{1}','{2}','{3}','{4}',{5},{6},'{7}','{8}',{9})", this.RNRGPId, this.RNRgpNo, this.RNRgpDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status, this.Remarks,this.Nrgpid);
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

            public string RNRGP_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [NRGP_Return] SET  NRgp_Return_No='{0}',NRgp_Return_Date='{1}',Receiver_Name='{2}',Address='{3}',PreparedBy={4},ReceivedBy={5},Status='{6}',Remarks='{7}',NRgp_Id={8} WHERE NRGP_Return_Id = {9}", this.RNRgpNo, this.RNRgpDate, this.ReceiverName, this.Address, this.PreparedBy, this.ReceivedBy, this.status, this.Remarks,this.Nrgpid, this.RNRGPId);
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

            public string RNRGP_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[NRGP_Return_Details]", "NRgp_Return_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[NRGP_Return]", "NRGP_Return_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public string Length;
            public string RNRGPDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [NRGP_Return_Details] SELECT ISNULL(MAX(NRgp_Return_Details_Id),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}','{7}',{8},{9} FROM [NRGP_Return_Details]", this.RNRGPId, this.Itemcode, this.ColorId, this.Uom, this.Qty, this.Purpose, this.DetRemarks, this.ReceivedQty, this.Nrgpid, this.Length);
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



            public string nrgpdetid;

            public string NRgpDetailsRemainingQty_Update(string podetid, string receivedqty)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [NRGP_Details] SET  RecievedQty=RecievedQty+'{0}' WHERE NRgp_Details_Id = {1} ", receivedqty, podetid);
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


            public string Stock_UpdatePQC(string productid, string Qty, string colorid,string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "Length", Length) == true)
                {
                    //_commandText = string.Format("UPDATE [Stock] SET  Quantity=CONVERT(BIGINT,Quantity)+{0} WHERE MatId = {1}  and ColorId = {2} ", Qty, productid, colorid);

                    _commandText = string.Format("UPDATE [Stock] SET  Quantity=Quantity+'{0}' WHERE MatId = {1}  and ColorId = {2} and Length={3} ", Qty, productid, colorid,Length);
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

            public int RNRGPDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [NRGP_Return_Details] WHERE NRgp_Return_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int RNRGP_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [NRGP_Return] WHERE  [NRGP_Return].NRGP_Return_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.RNRGPId = dbManager.DataReader["NRGP_Return_Id"].ToString();
                    this.RNRgpNo = dbManager.DataReader["NRgp_Return_No"].ToString();
                    this.RNRgpDate = Convert.ToDateTime(dbManager.DataReader["NRgp_Return_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.ReceiverName = dbManager.DataReader["Receiver_Name"].ToString();
                    this.Address = dbManager.DataReader["Address"].ToString();

                    this.PreparedBy = dbManager.DataReader["PreparedBy"].ToString();
                    this.ReceivedBy = dbManager.DataReader["ReceivedBy"].ToString();
                    this.status = dbManager.DataReader["Status"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    this.Nrgpid = dbManager.DataReader["NRgp_Id"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void RNRGPDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [NRGP_Return_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [NRGP_Return_Details].Item_Id=[Material_Master].Material_Id  and NRGP_Return_Details.Color_Id = Color_Master.Color_Id   AND [NRGP_Return_Details].NRgp_Return_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Purpose");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ReceivedQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);



                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ReqQty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Purpose"] = dbManager.DataReader["Purpose"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["ReceivedQty"] = dbManager.DataReader["RecievedQty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();



                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void RNRGP_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [NRGP_Return] ORDER BY NRGP_Return_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "NRGP_Return", "NRGP_Return_Id");
                }
            }

        }






        //Methods for ReserveStock(Block Stock)
        public class ReserveStock
        {
            public string ReserveId, Soid, PreparedBy, ReserveDate, ReserveNo,CustID,ProjectId,Remarks;
            public string ReserveDetid, Itemcode, Qty,ColorId,SoMatId,Length,Totalqty;

            public ReserveStock()
            {
            }

            public static string ReserveStock_AutoGenCode()
            {
                return AutoGenMaxNo("Stock_Reserve", "Stock_Reserve_No");
            }
            public string ReserveStock_Save()
            {
                this.ReserveNo = AutoGenMaxNo("Stock_Reserve", "Stock_Reserve_No");
                this.ReserveId = AutoGenMaxId("[Stock_Reserve]", "Stock_Reserve_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Stock_Reserve] VALUES({0},{1},{2},'{3}','{4}',{5},{6})", this.ReserveId, this.Soid, this.PreparedBy, this.ReserveDate, this.ReserveNo,this.CustID,this.ProjectId);
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

            public string ReserveStock_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Stock_Reserve] SET  So_Id={0},PreparedBy={1},Stock_Reserve_Date='{2}',Stock_Reserve_No='{3}',Cust_Id={4},Project_Id={5} WHERE Stock_Reserve_Id = {6}", this.Soid, this.PreparedBy, this.ReserveDate, this.ReserveNo, this.CustID,this.ProjectId, this.ReserveId);
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

            public string ReserveStock_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[Stock_Block]", "StockReserve_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[Stock_Reserve]", "Stock_Reserve_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }


            public string BlockStock_Update2(string productid, string Qty, string colorid, string Length, string SOid, string ProjId,string Remarks)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                // if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "PlantId", plantid, "StoragelocId", storagelocid, "Length",Length) == true)

                if (IsRecordExists("[Stock_Block]", "Item_Code", productid, "Color_Id", colorid, "Length", Length, "So_Id", SOid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock_Block] SET  Qty = Qty+'{0}',Remarks = Remarks + '{5}' WHERE Item_Code = {1}  and Color_Id = {2} and Length ={3} and So_Id = {4} ", Qty, productid, colorid, Length, SOid, Remarks);
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
                    _commandText = string.Format("INSERT INTO [Stock_Block] SELECT ISNULL(MAX(BlockStock_Id),0)+1,{0},{1},'{2}',{3},{4},{5},{6},'{7}',{8},{9},'{10}' FROM [Stock_Block]", this.Soid, this.Itemcode, this.Qty, this.ColorId, this.SoMatId, this.ReserveId, this.Length, this.Qty, this.CustID, this.ProjectId, this.Remarks);
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


            public string BlockStock_Update1(string productid, string Qty, string colorid,string Length,string SOid,string ProjId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                // if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid, "PlantId", plantid, "StoragelocId", storagelocid, "Length",Length) == true)

                if (IsRecordExists("[Stock_Block]", "Item_Code", productid, "Color_Id", colorid, "Length", Length, "So_Id", SOid, "Project_Id",ProjId) == true)
                {
                    _commandText = string.Format("UPDATE [Stock_Block] SET  Qty = Qty+'{0}' WHERE Item_Code = {1}  and Color_Id = {2} and Length ={3} and So_Id = {4} and Project_Id ={5}  ", Qty, productid, colorid, Length, SOid,ProjId);
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
                    _commandText = string.Format("INSERT INTO [Stock_Block] SELECT ISNULL(MAX(BlockStock_Id),0)+1,{0},{1},'{2}',{3},{4},{5},{6},'{7}',{8},{9},'{10}' FROM [Stock_Block]", this.Soid, this.Itemcode, this.Qty, this.ColorId, this.SoMatId, this.ReserveId, this.Length, this.Qty, this.CustID, this.ProjectId, this.Remarks);
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





            public string ReserveDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("INSERT INTO [Stock_Reserve_Details] SELECT ISNULL(MAX(BlockStock_Id),0)+1,{0},{1},'{2}',{3},{4},{5},{6},'{7}',{8},{9},'{10}' FROM [Stock_Reserve_Details]", this.Soid, this.Itemcode, this.Qty, this.ColorId, this.SoMatId, this.ReserveId, this.Length, this.Qty, this.CustID, this.ProjectId, this.Remarks);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                
                //_commandText = string.Format("INSERT INTO [Stock_Block] SELECT ISNULL(MAX(BlockStock_Id),0)+1,{0},{1},'{2}',{3},{4},{5},{6},'{7}',{8},{9},'{10}' FROM [Stock_Block]", this.Soid, this.Itemcode, this.Qty, this.ColorId, this.SoMatId, this.ReserveId,this.Length,this.Qty,this.CustID,this.ProjectId,this.Remarks);
                //_returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

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






            public string ReserveBlockStock_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Stock_Block] SET  Qty = Qty - '{0}' , Remarks ='{1}' WHERE BlockStock_Id = {2}", this.Qty,this.Remarks, this.ReserveDetid);
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


         


            public string ReserveBlockSOStock_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Stock_Block] SET  So_Id ={0},Remarks ='{1}' WHERE BlockStock_Id = {2}", this.Soid, this.Remarks, this.ReserveDetid);
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






            public int ReserveDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Stock_Block] WHERE StockReserve_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int ReserveStock_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Stock_Reserve] WHERE  [Stock_Reserve].Stock_Reserve_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ReserveId = dbManager.DataReader["Stock_Reserve_Id"].ToString();
                    this.Soid = dbManager.DataReader["So_Id"].ToString();
                    this.ReserveDate = Convert.ToDateTime(dbManager.DataReader["Stock_Reserve_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.ReserveNo = dbManager.DataReader["Stock_Reserve_No"].ToString();
                    this.PreparedBy = dbManager.DataReader["PreparedBy"].ToString();

                    this.CustID = dbManager.DataReader["Cust_Id"].ToString();
                    this.ProjectId = dbManager.DataReader["Project_Id"].ToString();
                  


                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void ReserveDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Stock_Block],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Stock_Block].Item_Code=[Material_Master].Material_Id  and Stock_Block.Color_Id = Color_Master.Color_Id   AND [Stock_Block].IndApp_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("Purpose");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ReceivedQty");
                SalesOrderItems.Columns.Add(col);

                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);



                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Uom"] = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ReqQty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Purpose"] = dbManager.DataReader["Purpose"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["ReceivedQty"] = dbManager.DataReader["RecievedQty"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();



                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void ReserveStock_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Stock_Reserve] ORDER BY Stock_Reserve_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Stock_Reserve_No", "Stock_Reserve_Id");
                }
            }



            public string Indent_Reminder()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("Insert Into Indent_Reminder select ISNULL(MAX(Reminder_Id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',getdate() from Indent_Reminder ", this.ReserveDetid, this.CustID, this.ProjectId, this.Itemcode, this.ColorId, this.Length, this.Totalqty, this.Qty, this.Remarks);
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







        //Methods for Glass Po Form
        public class GlassPo
        {
            public string PoId, PONo, PoDate, SupId, QuatId, PaymentTermsId, TermsCondtionId, Discount, Tax, GrandTotal, Preparedby, Approvedby, Status, Insurance,frieght,Packing,transport,Writeinsurance,WriteFreight,Indentnos,CustomerNo,Message;

             public string PoDetId, WindowCode, Thickness, Description, Width, Height, Unit, Area,Weight,ReqQty,Rate,Amount, reqdate,stock;

             public string ReceivedQty, RemainingQty, ItemStatus, SOid, RequiredFor;

             public string Glasstype, SupPoNo, AlumilPoNO, Deliverydate, Expteddelvierydate, Deliverto;



             public GlassPo()
            {
            }

             public static string GlassPo_AutoGenCode()
            {
                return AutoGenMaxNo("Glass_PO_Master", "Sup_GPO_No");
            }

             public string GlassPo_Save()
            {

                this.PoId = AutoGenMaxId("[Glass_PO_Master]", "Sup_GPO_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Glass_PO_Master] SELECT ISNULL(MAX(Sup_GPO_Id),0)+1,'{0}','{1}',{2},{3},'{4}','{5}','{6}','{7}','{8}',{9},{10},'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}' from Glass_PO_Master", this.PONo, this.PoDate, this.SupId, this.QuatId, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby, this.Status,this.Insurance,this.frieght,this.Packing,this.transport,this.Writeinsurance,this.frieght,this.Indentnos,this.CustomerNo,this.Message,this.Glasstype,this.SupPoNo,this.AlumilPoNO,this.Deliverydate,this.Expteddelvierydate,this.Deliverto);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                if (this.QuatId != "0")
                {
                    _commandText = string.Format("UPDATE [Glass_Quatation_Master] SET Status='Ordered' WHERE Sup_GQuo_Id ={0}", this.QuatId);
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



            public string GlassPo_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Glass_PO_Master] SET Sup_GPO_Date='{0}',Sup_Id={1},GlassQua_Id={2},Paymentterms_Id='{3}',TermsConditions_Id='{4}',Discount='{5}',Tax='{6}',GrandTotal='{7}',PreparedBy={8},ApprovedBy={9},Status='{10}',Insurance='{11}',Frieght='{12}',Packing='{13}',Transport='{14}',Write_Insurance='{15}',Write_Frieght='{16}',IndentNo='{17}',CustomerNo='{18}',Message='{19}',GlassType='{20}',SupPONo='{21}',AlumilPoNO='{22}',DeliveryDate='{23}',ExpectedDate='{24}',Deliverto='{25}' WHERE Sup_GPO_Id={26}", this.PoDate, this.SupId, this.QuatId, this.PaymentTermsId, this.TermsCondtionId, this.Discount, this.Tax, this.GrandTotal, this.Preparedby, this.Approvedby, this.Status, this.Insurance, this.frieght, this.Packing, this.transport, this.Writeinsurance, this.WriteFreight, this.Indentnos, this.CustomerNo, this.Message,this.Glasstype,this.SupPoNo,this.AlumilPoNO,this.Deliverydate,this.Expteddelvierydate,this.Deliverto, this.PoId);
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

            public string GlassPo_Delete(string QuotationId)
            {

                if (DeleteRecord("[Glass_PO_Details]", "Sup_GPO_Id", QuotationId) == true)
                {
                    if (DeleteRecord("[Glass_PO_Master]", "Sup_GPO_Id", QuotationId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                    }
                }
                else
                {
                    _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                }
                return _returnStringMessage;
            }


           
            public string GlassPoDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Glass_PO_Details] SELECT ISNULL(MAX(Sup_GPO_Det_id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',{13},{14},'{15}','{16}',{17},{18} FROM [Glass_PO_Details]", this.PoId, this.WindowCode, this.Thickness, this.Description, this.Width, this.Height, this.Unit, this.Area, this.Weight, this.ReqQty, this.Rate, this.Amount,this.reqdate, this.ReceivedQty,this.RemainingQty,this.ItemStatus,this.RequiredFor,this.SOid,this.stock);
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

            public int GlassPoDetails_Delete(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Glass_PO_Details] WHERE Sup_GPO_Id = {0}", QuotationId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }


            public string Sname, SContact, Smobile;

            public int GlassPoname_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Glass_PO_Master],Supplier_Master WHERE Glass_PO_Master.Sup_Id = Supplier_Master.SUP_ID and Glass_PO_Master.Sup_GPO_Id='" + QuotationId + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.PoId = dbManager.DataReader["Sup_GPO_Id"].ToString();
                    this.PONo = dbManager.DataReader["Sup_GPO_No"].ToString();
                    this.PoDate = Convert.ToDateTime(dbManager.DataReader["Sup_GPO_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SupId = dbManager.DataReader["Sup_Id"].ToString();
                    this.QuatId = dbManager.DataReader["GlassQua_Id"].ToString();
                    this.PaymentTermsId = dbManager.DataReader["Paymentterms_Id"].ToString();
                    this.TermsCondtionId = dbManager.DataReader["TermsConditions_Id"].ToString();
                    this.Discount = dbManager.DataReader["Discount"].ToString();
                    this.Tax = dbManager.DataReader["Tax"].ToString();
                    //  this.TermsCondtionId = dbManager.DataReader["TermsConditions_Id"].ToString();
                    //  this.Discount = dbManager.DataReader["Discount"].ToString();
                    //  this.Tax = dbManager.DataReader["Tax"].ToString();
                    this.GrandTotal = dbManager.DataReader["GrandTotal"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();

                    this.Status = dbManager.DataReader["Status"].ToString();
                    this.SContact = dbManager.DataReader["SUP_CONTACT_PERSON"].ToString();
                    this.Smobile = dbManager.DataReader["SUP_MOBILE"].ToString();
                    this.Sname = dbManager.DataReader["SUP_NAME"].ToString();


                    this.Packing = dbManager.DataReader["Packing"].ToString();
                    this.Insurance = dbManager.DataReader["Insurance"].ToString();
                    this.transport = dbManager.DataReader["Transport"].ToString();
                    this.frieght = dbManager.DataReader["Frieght"].ToString();

                    this.Writeinsurance = dbManager.DataReader["Write_Insurance"].ToString();
                    this.WriteFreight = dbManager.DataReader["Write_Frieght"].ToString();
                    this.Indentnos = dbManager.DataReader["IndentNo"].ToString();

                    this.CustomerNo = dbManager.DataReader["CustomerNo"].ToString();

                    this.Glasstype = dbManager.DataReader["GlassType"].ToString();
                    this.SupPoNo = dbManager.DataReader["SupPONo"].ToString();
                    this.AlumilPoNO = dbManager.DataReader["AlumilPoNO"].ToString();
                    this.Deliverydate = dbManager.DataReader["DeliveryDate"].ToString();
                    this.Expteddelvierydate = dbManager.DataReader["ExpectedDate"].ToString();
                    this.Deliverto = dbManager.DataReader["Deliverto"].ToString();



                    this.Message = dbManager.DataReader["Message"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public int GlassPo_Select(string QuotationId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Glass_PO_Master] WHERE Glass_PO_Master.Sup_GPO_Id = '" + QuotationId + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.PoId = dbManager.DataReader["Sup_GPO_Id"].ToString();
                    this.PONo = dbManager.DataReader["Sup_GPO_No"].ToString();
                    this.PoDate = Convert.ToDateTime(dbManager.DataReader["Sup_GPO_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SupId = dbManager.DataReader["Sup_Id"].ToString();
                    this.QuatId = dbManager.DataReader["GlassQua_Id"].ToString();
                    this.PaymentTermsId = dbManager.DataReader["Paymentterms_Id"].ToString();
                    this.TermsCondtionId = dbManager.DataReader["TermsConditions_Id"].ToString();
                    this.Discount = dbManager.DataReader["Discount"].ToString();
                    this.Tax = dbManager.DataReader["Tax"].ToString();

                    this.Insurance = dbManager.DataReader["Insurance"].ToString();
                    this.frieght = dbManager.DataReader["Frieght"].ToString();
                    this.Packing = dbManager.DataReader["Packing"].ToString();
                    this.transport = dbManager.DataReader["Transport"].ToString();

                    this.Writeinsurance = dbManager.DataReader["Write_Insurance"].ToString();
                    this.WriteFreight = dbManager.DataReader["Write_Frieght"].ToString();
                    this.Indentnos = dbManager.DataReader["IndentNo"].ToString();

                    this.GrandTotal = dbManager.DataReader["GrandTotal"].ToString();
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
                    this.Approvedby = dbManager.DataReader["ApprovedBy"].ToString();

                    this.Status = dbManager.DataReader["Status"].ToString();

                    this.CustomerNo = dbManager.DataReader["CustomerNo"].ToString();

                    this.Message = dbManager.DataReader["Message"].ToString();
                    this.Glasstype = dbManager.DataReader["GlassType"].ToString();
                    this.SupPoNo = dbManager.DataReader["SupPONo"].ToString();
                    this.AlumilPoNO = dbManager.DataReader["AlumilPoNO"].ToString();
                    this.Deliverydate = dbManager.DataReader["DeliveryDate"].ToString();
                    this.Expteddelvierydate = dbManager.DataReader["ExpectedDate"].ToString();
                    this.Deliverto = dbManager.DataReader["Deliverto"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }


            public string GlassPoApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [Glass_PO_Master] SET ApprovedBy={0},Status='Close' WHERE Sup_GPO_Id ={1}", this.Approvedby, this.PoId);
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


            public string GlassPoQuatationApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("UPDATE [Glass_Quatation_Master] SET Status = 'Close' WHERE Sup_GQuo_Id ={0}", this.PoId);
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


            public void GlassPoOrder_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Glass_PO_Details] where [Glass_PO_Details].Sup_GPO_Id=" + QuotationId + "");
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
                col = new DataColumn("Unit");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Area");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Weight");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Quantity");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Rate");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Amount");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RequiredDate");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ReceivedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RemainingQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Status");
                SalesQuotationItems.Columns.Add(col);

                col = new DataColumn("SoId");
                SalesQuotationItems.Columns.Add(col);


                col = new DataColumn("Requiredfor");
                SalesQuotationItems.Columns.Add(col);



                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["WindowCode"] = dbManager.DataReader["WindowCode"].ToString();
                    dr["Thickness"] = dbManager.DataReader["Thickness"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["Height"] = dbManager.DataReader["Height"].ToString();
                    dr["Quantity"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["Unit"] = dbManager.DataReader["Unit"].ToString();
                    dr["Area"] = dbManager.DataReader["Area"].ToString();
                    dr["Weight"] = dbManager.DataReader["Weight"].ToString();

                    dr["Rate"] = dbManager.DataReader["Rate"].ToString();
                    dr["Amount"] = dbManager.DataReader["Amount"].ToString();
                   
                    
                    dr["RequiredDate"] = Convert.ToDateTime(dbManager.DataReader["Req_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dr["ReceivedQty"] = dbManager.DataReader["ReceivedQty"].ToString();
                    dr["RemainingQty"] = dbManager.DataReader["RemainingQty"].ToString();
                    dr["Status"] = dbManager.DataReader["Status"].ToString();
                    dr["SoId"] = dbManager.DataReader["So_Id"].ToString();

                    dr["Requiredfor"] = dbManager.DataReader["Requiredfor"].ToString();

                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }



            public void SupPoOrderQtyNotZero_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Glass_PO_Details] where  [Glass_PO_Details].Sup_GPO_Id=" + QuotationId + " and Glass_PO_Details.RemainingQty != '0' ");

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
                col = new DataColumn("Unit");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Area");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Weight");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ReceivedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("AcceptedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RejectedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RemainingQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Status");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("PoDetId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesQuotationItems.Columns.Add(col);


                //col = new DataColumn("AlreadyBlocked");
                //SalesQuotationItems.Columns.Add(col);
                //col = new DataColumn("BlockRemarks");
                //SalesQuotationItems.Columns.Add(col);





                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["WindowCode"] = dbManager.DataReader["WindowCode"].ToString();
                    dr["Thickness"] = dbManager.DataReader["Thickness"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["Height"] = dbManager.DataReader["Height"].ToString();
                    dr["Unit"] = dbManager.DataReader["Unit"].ToString();
                    dr["Area"] = dbManager.DataReader["Area"].ToString();
                    dr["Weight"] = dbManager.DataReader["Weight"].ToString();

                    dr["ReqQty"] = dbManager.DataReader["ReqQty"].ToString();


                    dr["ReceivedQty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["RemainingQty"] = dbManager.DataReader["RemainingQty"].ToString();
                    dr["Status"] = dbManager.DataReader["Status"].ToString();

                    dr["PoDetId"] = dbManager.DataReader["Sup_GPO_Det_id"].ToString();

                    dr["AcceptedQty"] = dbManager.DataReader["ReqQty"].ToString();
                    dr["RejectedQty"] = "0";



                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();



                    dr["Remarks"] = "-";

                    //dr["AlreadyBlocked"] = dbManager.DataReader["PrevBlockedStock"].ToString();
                    //dr["BlockRemarks"] = dbManager.DataReader["Remak"].ToString();


                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }






            public void SupPoOrderQtybyso_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Glass_PO_Details] where  [Glass_PO_Details].So_Id=" + QuotationId + " ");

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
                col = new DataColumn("Unit");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Area");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Weight");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ReceivedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("AcceptedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RejectedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RemainingQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Status");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("PoDetId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Stock");
                SalesQuotationItems.Columns.Add(col);


                col = new DataColumn("Requestqty");
                SalesQuotationItems.Columns.Add(col);





                //col = new DataColumn("AlreadyBlocked");
                //SalesQuotationItems.Columns.Add(col);
                //col = new DataColumn("BlockRemarks");
                //SalesQuotationItems.Columns.Add(col);





                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["WindowCode"] = dbManager.DataReader["WindowCode"].ToString();
                    dr["Thickness"] = dbManager.DataReader["Thickness"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["Height"] = dbManager.DataReader["Height"].ToString();
                    dr["Unit"] = dbManager.DataReader["Unit"].ToString();
                    dr["Area"] = dbManager.DataReader["Area"].ToString();
                    dr["Weight"] = dbManager.DataReader["Weight"].ToString();

                    dr["ReqQty"] = dbManager.DataReader["ReqQty"].ToString();


                    dr["ReceivedQty"] = "0";
                    dr["RemainingQty"] = dbManager.DataReader["RemainingQty"].ToString();
                    dr["Status"] = dbManager.DataReader["Status"].ToString();

                    dr["PoDetId"] = dbManager.DataReader["Sup_GPO_Det_id"].ToString();

                    dr["AcceptedQty"] = "0";
                    dr["RejectedQty"] = "0";
                    dr["Stock"] = dbManager.DataReader["stock"].ToString();



                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();



                    dr["Remarks"] = "-";


                    dr["Requestqty"] = "0";


                    //dr["AlreadyBlocked"] = dbManager.DataReader["PrevBlockedStock"].ToString();
                    //dr["BlockRemarks"] = dbManager.DataReader["Remak"].ToString();


                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }


            public void SupPoOrderQtybysoStock_Select(string QuotationId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Glass_PO_Details] where  [Glass_PO_Details].So_Id=" + QuotationId + " and stock > 0 order by Sup_GPO_Det_id ");

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
                col = new DataColumn("Unit");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Area");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Weight");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("ReceivedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("AcceptedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RejectedQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("RemainingQty");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Status");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("PoDetId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesQuotationItems.Columns.Add(col);
                col = new DataColumn("Stock");
                SalesQuotationItems.Columns.Add(col);


                col = new DataColumn("Requestqty");
                SalesQuotationItems.Columns.Add(col);





                //col = new DataColumn("AlreadyBlocked");
                //SalesQuotationItems.Columns.Add(col);
                //col = new DataColumn("BlockRemarks");
                //SalesQuotationItems.Columns.Add(col);





                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesQuotationItems.NewRow();
                    dr["WindowCode"] = dbManager.DataReader["WindowCode"].ToString();
                    dr["Thickness"] = dbManager.DataReader["Thickness"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Width"] = dbManager.DataReader["Width"].ToString();
                    dr["Height"] = dbManager.DataReader["Height"].ToString();
                    dr["Unit"] = dbManager.DataReader["Unit"].ToString();
                    dr["Area"] = dbManager.DataReader["Area"].ToString();
                    dr["Weight"] = dbManager.DataReader["Weight"].ToString();

                    dr["ReqQty"] = dbManager.DataReader["ReqQty"].ToString();


                    dr["ReceivedQty"] = "0";
                    dr["RemainingQty"] = dbManager.DataReader["RemainingQty"].ToString();
                    dr["Status"] = dbManager.DataReader["Status"].ToString();

                    dr["PoDetId"] = dbManager.DataReader["Sup_GPO_Det_id"].ToString();

                    dr["AcceptedQty"] = "0";
                    dr["RejectedQty"] = "0";
                    dr["Stock"] = dbManager.DataReader["stock"].ToString();



                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();



                    dr["Remarks"] = "-";


                    dr["Requestqty"] = "0";


                    //dr["AlreadyBlocked"] = dbManager.DataReader["PrevBlockedStock"].ToString();
                    //dr["BlockRemarks"] = dbManager.DataReader["Remak"].ToString();


                    SalesQuotationItems.Rows.Add(dr);
                }

                gv.DataSource = SalesQuotationItems;
                gv.DataBind();
            }




            public static void GlassPo_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Sup_GPO_Id,Sup_GPO_No+' - '+IndentNo as gpno FROM [Glass_PO_Master] ORDER BY Sup_GPO_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "gpno", "Sup_GPO_Id");
                }
            }




            public static void GlassPoStatus_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT Sup_GPO_Id,Sup_GPO_No+' - '+IndentNo as gpno FROM [Glass_PO_Master] where Status!= 'Close' ORDER BY Sup_GPO_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "gpno", "Sup_GPO_Id");
                }
            }






        }






        public class MailBox
        {
             public string MessageId,Message,SenderId,ReceiverId,Subject,SentDate,Isdelete;

             public string MessageDetId,Attachments;

             public MailBox()
            {
            }

              public string MailBox_Save()
            {
                this.MessageId = AutoGenMaxId("[MailBox]", "MessageId");
                if (dbManager.Transaction == null)
                    dbManager.Open();
              //  _commandText = string.Format("INSERT INTO [MailBox] SELECT ISNULL(MAX(MessageId),0)+1,'{0}',{1},{2},'{3}','{4}','{5}' from MailBox", this.Message, this.SenderId, this.ReceiverId, this.Subject, this.SentDate, this.Isdelete);

                _commandText = string.Format("INSERT INTO [MailBox] SELECT ISNULL(MAX(MessageId),0)+1,'{0}',{1},{2},'{3}',getdate(),'{4}' from MailBox", this.Message, this.SenderId, this.ReceiverId, this.Subject,  this.Isdelete);

                  
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

              public string MailBox_Details_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [MailBox_Details] SELECT ISNULL(MAX(Message_Det_Id),0)+1,{0},'{1}' FROM [MailBox_Details]", this.MessageId, this.Attachments);

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

              public string MailBox_Delete(string QuotationId)
            {

                 if (dbManager.Transaction == null)
                    dbManager.Open();
               _commandText = string.Format("UPDATE [MailBox] SET IsDelete='Trash' WHERE MessageId ={0}", QuotationId);
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

              public int MailBox_Inbox_Select(string EmpId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [MailBox] WHERE ReceiverId = '" + EmpId + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.MessageId = dbManager.DataReader["MessageId"].ToString();
                    this.Message = dbManager.DataReader["Message"].ToString();
                    this.SentDate = Convert.ToDateTime(dbManager.DataReader["SentDate"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SenderId = dbManager.DataReader["SenderId"].ToString();
                    this.ReceiverId = dbManager.DataReader["ReceiverId"].ToString();
                    this.Subject = dbManager.DataReader["Subject"].ToString();
                    this.Isdelete = dbManager.DataReader["IsDelete"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

              public int MailBox_Sent_Select(string EmpId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [MailBox] WHERE SenderId = '" + EmpId + "'  ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.MessageId = dbManager.DataReader["MessageId"].ToString();
                    this.Message = dbManager.DataReader["Message"].ToString();
                    this.SentDate = Convert.ToDateTime(dbManager.DataReader["SentDate"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.SenderId = dbManager.DataReader["SenderId"].ToString();
                    this.ReceiverId = dbManager.DataReader["ReceiverId"].ToString();
                    this.Subject = dbManager.DataReader["Subject"].ToString();
                    this.Isdelete = dbManager.DataReader["IsDelete"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

             



        }






        //Methods for PackingList
        public class PackingList
        {
            public string PLId, PLNo, PLDate, Soid, CustId, CustAddress, DeliveryAddress, TotalPackets, TotalWeight, Methodofdispach, preapredby,reqpackid,Remarks;
            public string PLDetId, Itemcode, ColorId, Uom, Qty, PackedQty, DetRemarks, Length;

            public PackingList()
            {
            }

            public static string PackingList_AutoGenCode()
            {
                return AutoGenMaxNo("Packing_List", "PackingList_No");
            }
            public string PackingList_Save()
            {
                this.PLNo = AutoGenMaxNo("Packing_List", "PackingList_No");
                this.PLId = AutoGenMaxId("[Packing_List]", "PackingList_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Packing_List] VALUES({0},'{1}','{2}',{3},{4},'{5}','{6}',{7},'{8}','{9}',{10},{11},'{12}')", this.PLId, this.PLNo, this.PLDate, this.Soid, this.CustId, this.CustAddress, this.DeliveryAddress, this.TotalPackets, this.TotalWeight, this.Methodofdispach, this.preapredby,this.reqpackid,this.Remarks);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                if (this.reqpackid != "0")
                {
                    _commandText = string.Format("UPDATE [Request_PackingList] SET  Status='Issued' WHERE RPackingList_Id = {0}", this.reqpackid);
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

            public string PackingList_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Packing_List] SET  PackingList_No='{0}',PackingList_Date='{1}',SO_Id={2},Cust_Id={3},Cust_Address='{4}',Delivery_Address='{5}',TotalPackets={6},TotalWeight='{7}',MethodofDispacth='{8}',PreparedBy={9},ReqpackingId={10},Remarks='{11}' WHERE PackingList_Id = {12}", this.PLNo, this.PLDate, this.Soid, this.CustId, this.CustAddress, this.DeliveryAddress,this.TotalPackets, this.TotalWeight, this.Methodofdispach, this.preapredby,this.reqpackid,this.Remarks, this.PLId);
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

            public string PackingList_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[PackingList_Details]", "PL_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[Packing_List]", "PackingList_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

           // public string Length;
            public string PackingListDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [PackingList_Details] SELECT ISNULL(MAX(PL_Details_Id),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}',{7},{8} FROM [PackingList_Details]", this.PLId, this.Itemcode, this.ColorId, this.Uom, this.Qty, this.PackedQty, this.DetRemarks, this.Length, this.Soid);
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


            public string Stock_UpdatePQC(string productid, string Qty, string colorid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock]", "MatId", productid, "ColorId", colorid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock] SET  Quantity = Quantity-'{0}' WHERE MatId = {1}  and ColorId = {2} and Length = {3}", Qty, productid, colorid, Length);
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


            public string BlockStock_Update(string productid, string Qty, string colorid, string matid, string Length)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[Stock_Block]", "Item_Code", productid, "Color_Id", colorid, "So_Id", matid) == true)
                {
                    //_commandText = string.Format("UPDATE [Stock_Block] SET  Qty=Qty-{0} WHERE Item_Code = {1}  and Color_Id = {2} and So_MatId = {3} ", Qty, productid, colorid,matid);
                    //_commandText = string.Format("UPDATE [Stock_Block] SET  Qty = CASE WHEN Qty-{0} < 0 THEN 0 ELSE Qty-{0} WHERE Item_Code = {1}  and Color_Id = {2} and So_Id = {3} and Length = {4} ", Qty, productid, colorid, matid,Length);

                    _commandText = string.Format("UPDATE [Stock_Block] SET  Qty = CASE WHEN ISNULL(Qty-{0}, 0) <= 0  THEN 0 ELSE (Qty-{0}) end WHERE Item_Code = {1}  and Color_Id = {2} and So_Id = {3} and Length = {4} ", Qty, productid, colorid, matid, Length);
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

            public int PackingListDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [PackingList_Details] WHERE PL_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int PackingList_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Packing_List] WHERE  [Packing_List].PackingList_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.PLId = dbManager.DataReader["PackingList_Id"].ToString();
                    this.PLNo = dbManager.DataReader["PackingList_No"].ToString();
                    this.PLDate = Convert.ToDateTime(dbManager.DataReader["PackingList_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Soid = dbManager.DataReader["SO_Id"].ToString();
                    this.CustId = dbManager.DataReader["Cust_Id"].ToString();
                    this.CustAddress = dbManager.DataReader["Cust_Address"].ToString();
                    this.DeliveryAddress = dbManager.DataReader["Delivery_Address"].ToString();
                    this.TotalPackets = dbManager.DataReader["TotalPackets"].ToString();
                    this.TotalWeight = dbManager.DataReader["TotalWeight"].ToString();
                    this.Methodofdispach = dbManager.DataReader["MethodofDispacth"].ToString();
                    this.preapredby = dbManager.DataReader["PreparedBy"].ToString();
                    this.reqpackid = dbManager.DataReader["ReqpackingId"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void PackingListDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [PackingList_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [PackingList_Details].Item_Id=[Material_Master].Material_Id  and PackingList_Details.Color_Id = Color_Master.Color_Id   AND [PackingList_Details].PL_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Packedqty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesOrderItems.Columns.Add(col);

              


                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Uom"] = dbManager.DataReader["Uom"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ReqQty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Packedqty"] = dbManager.DataReader["PackedQty"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }

            public static void PackingList_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Packing_List] ORDER BY PackingList_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "PackingList_No", "PackingList_Id");
                }
            }

        }



        //Methods for Request PackingList
        public class RequestPackingList
        {
            public string RPLId, RPLNo, RPLDate, Soid, CustId, CustAddress, DeliveryAddress, TotalPackets, TotalWeight, Methodofdispach, preapredby,ApprovedBy,Status,Remarks;
            public string RPLDetId, Itemcode, ColorId, Uom, Qty, PackedQty, DetRemarks, Length;

            public RequestPackingList()
            {
            }

            public static string RequestPackingPackingList_AutoGenCode()
            {
                return AutoGenMaxNo("Request_PackingList", "RPackingList_No");
            }
            public string RequestPackingList_Save()
            {
                this.RPLNo = AutoGenMaxNo("Request_PackingList", "RPackingList_No");
                this.RPLId = AutoGenMaxId("[Request_PackingList]", "RPackingList_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Request_PackingList] VALUES({0},'{1}','{2}',{3},{4},'{5}','{6}',{7},'{8}','{9}',{10},{11},'{12}','{13}')", this.RPLId, this.RPLNo, this.RPLDate, this.Soid, this.CustId, this.CustAddress, this.DeliveryAddress, this.TotalPackets, this.TotalWeight, this.Methodofdispach, this.preapredby,this.ApprovedBy,this.Status,this.Remarks);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                //if (this.Requestrgpid != "0")
                //{
                //    _commandText = string.Format("UPDATE [RGP_Request] SET  Status='Issued' WHERE RGP_Request_Id = {0}", this.Requestrgpid);
                //    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                //}


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

            public string RequestPackingList_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Request_PackingList] SET  RPackingList_No='{0}',RPackingList_Date='{1}',SO_Id={2},Cust_Id={3},Cust_Address='{4}',Delivery_Address='{5}',TotalPackets={6},TotalWeight='{7}',MethodofDispacth='{8}',PreparedBy={9},APPROVEDBY={10},Remarks='{11}' WHERE RPackingList_Id = {12}", this.RPLNo, this.RPLDate, this.Soid, this.CustId, this.CustAddress, this.DeliveryAddress,this.TotalPackets, this.TotalWeight, this.Methodofdispach, this.preapredby, this.ApprovedBy,this.Remarks, this.RPLId);
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

            public string RequestPackingList_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[Request_PackingList_Details]", "RPL_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[Request_PackingList]", "RPackingList_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            // public string Length;
            public string RequestPackingListDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [Request_PackingList_Details] SELECT ISNULL(MAX(RPL_Details_Id),0)+1,{0},{1},{2},'{3}','{4}','{5}','{6}',{7},{8} FROM [Request_PackingList_Details]", this.RPLId, this.Itemcode, this.ColorId, this.Uom, this.Qty, this.PackedQty, this.DetRemarks, this.Length, this.Soid);
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



            public int RequestPackingListDetails_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [Request_PackingList_Details] WHERE RPL_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }

            public int RequestPackingList_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Request_PackingList] WHERE  [Request_PackingList].RPackingList_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.RPLId = dbManager.DataReader["RPackingList_Id"].ToString();
                    this.RPLNo = dbManager.DataReader["RPackingList_No"].ToString();
                    this.RPLDate = Convert.ToDateTime(dbManager.DataReader["RPackingList_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Soid = dbManager.DataReader["SO_Id"].ToString();
                    this.CustId = dbManager.DataReader["Cust_Id"].ToString();
                    this.CustAddress = dbManager.DataReader["Cust_Address"].ToString();
                    this.DeliveryAddress = dbManager.DataReader["Delivery_Address"].ToString();
                    this.TotalPackets = dbManager.DataReader["TotalPackets"].ToString();
                    this.TotalWeight = dbManager.DataReader["TotalWeight"].ToString();
                    this.Methodofdispach = dbManager.DataReader["MethodofDispacth"].ToString();
                    this.preapredby = dbManager.DataReader["PreparedBy"].ToString();
                    this.ApprovedBy = dbManager.DataReader["APPROVEDBY"].ToString();
                    this.Remarks = dbManager.DataReader["Remarks"].ToString();

                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }

            public void RequestPackingListDetails_Select(string MaterialRequestId, GridView gv)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Request_PackingList_Details],[Material_Master],Color_Master,ItemSeries,Uom_Master WHERE [Material_Master].UOM_Id = Uom_Master.UOM_ID and [Material_Master].Series =ItemSeries.Item_Series_Id and  [Request_PackingList_Details].Item_Id=[Material_Master].Material_Id  and Request_PackingList_Details.Color_Id = Color_Master.Color_Id   AND [Request_PackingList_Details].RPL_Id=" + MaterialRequestId);

                dbManager.ExecuteReader(CommandType.Text, _commandText);

                DataTable SalesOrderItems = new DataTable();
                DataColumn col = new DataColumn();
                col = new DataColumn("ItemCode");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Description");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Uom");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Color");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ReqQty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Packedqty");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Remarks");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("Length");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ItemCodeId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("ColorId");
                SalesOrderItems.Columns.Add(col);
                col = new DataColumn("SoId");
                SalesOrderItems.Columns.Add(col);




                while (dbManager.DataReader.Read())
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["ItemCode"] = dbManager.DataReader["Material_Code"].ToString();
                    dr["Description"] = dbManager.DataReader["Description"].ToString();
                    dr["Uom"] = dbManager.DataReader["Uom"].ToString();
                    dr["Color"] = dbManager.DataReader["Color_Name"].ToString();
                    dr["ReqQty"] = dbManager.DataReader["Qty"].ToString();
                    dr["Packedqty"] = dbManager.DataReader["PackedQty"].ToString();
                    dr["Remarks"] = dbManager.DataReader["Remarks"].ToString();
                    dr["Length"] = dbManager.DataReader["Length"].ToString();
                    dr["ItemCodeId"] = dbManager.DataReader["Item_Id"].ToString();
                    dr["ColorId"] = dbManager.DataReader["Color_Id"].ToString();
                    dr["SoId"] = dbManager.DataReader["SO_Id"].ToString();

                    SalesOrderItems.Rows.Add(dr);
                }

                gv.DataSource = SalesOrderItems;
                gv.DataBind();
            }




            public string RequestPackingApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [Request_PackingList] SET APPROVEDBY = {0} WHERE RPackingList_Id ={1}", this.ApprovedBy, this.RPLId);
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



            public static void RequestPackingListBeforeApproveandstatus_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT RPackingList_No,RPackingList_Id FROM [Request_PackingList] where Request_PackingList.APPROVEDBY != '0' and Status = 'New' ORDER BY RPackingList_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "RPackingList_No", "RPackingList_Id");
                }
            }


            public static void RequestPackingList_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Request_PackingList] ORDER BY RPackingList_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "RPackingList_No", "RPackingList_Id");
                }
            }

        }










        //Methods for RequestBlockStockRealase
        public class RequestBlockStockRealase
        {
            public string RequestBlockStockRealase_Id, RequestBlockStockRealase_No, Required_Date, Request_Type, Requested_for, Requested_date, TermsCondition_Id, Prepared_By, Status, From_SO_Id, To_SO_Id, Approved_By;
            public string RequestBlockStockRealase_Det_Id, Itemcode, ColorId, Reqqty, Remarks, DetFromsoid, Dettosoid, blockedqty,Length,BlockDetId;

            public RequestBlockStockRealase() { }

            public static string RequestBlockStockRealase_AutoGenCode()
            {
                return AutoGenMaxNo("RequestBlockStock_Release", "RequestBlockRelase_No");
            }

            public static void RequestBlockStockRealaseNo_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT RequestBlockRelase_No,RequestBlockRelase_Id FROM [RequestBlockStock_Release] where RequestBlockStock_Release.Approved_By != '0'   ORDER BY RequestBlockRelase_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "RequestBlockRelase_No", "RequestBlockRelase_Id");
                }
            }




            public static void RequestBlockStockRealaseNo_SelectNotissued(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT RequestBlockRelase_No,RequestBlockRelase_Id FROM [RequestBlockStock_Release] where RequestBlockStock_Release.Approved_By != '0' and Status != 'Issued'  ORDER BY RequestBlockRelase_Id");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "RequestBlockRelase_No", "RequestBlockRelase_Id");
                }
            }




            public int RequestBlockStock_Release_Details_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [RequestBlockStock_Release_Details] WHERE RequestBlockRelase_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }
            public string RequestBlockStockRealase_Save()
            {
                this.RequestBlockStockRealase_No = AutoGenMaxNo("RequestBlockStock_Release", "RequestBlockRelase_No");
                this.RequestBlockStockRealase_Id = AutoGenMaxId("[RequestBlockStock_Release]", "RequestBlockRelase_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [RequestBlockStock_Release] VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}',{9},{10},{11})", this.RequestBlockStockRealase_Id, this.RequestBlockStockRealase_No, this.Required_Date, this.Request_Type, this.Requested_for, this.Requested_date, this.TermsCondition_Id, this.Prepared_By, this.Status, this.From_SO_Id, this.To_SO_Id, this.Approved_By);
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
            public string RequestBlockStockRelease_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [RequestBlockStock_Release] SET  Required_Date='{0}',Request_Type='{1}',Requested_For='{2}',Requested_Date='{3}',TermsConditions_Id='{4}',Prepared_By={4},Status='{5}',From_SO_Id={6},To_SO_Id={7},Approved_By={8} WHERE RequestBlockRelase_Id={9}", this.Required_Date, this.Request_Type, this.Requested_for, this.Requested_date, this.Prepared_By, this.Status, this.From_SO_Id, this.To_SO_Id, this.Approved_By, this.RequestBlockStockRealase_Id);
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
            public string RequestBlockStockReleaseApprove_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [RequestBlockStock_Release] SET Approved_By = {0} WHERE RequestBlockRelase_Id ={1}", this.Approved_By, this.RequestBlockStockRealase_Id);
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
            public string RequestBlockStockRelease_Details_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [RequestBlockStock_Release_Details] SELECT ISNULL(MAX(RequestBlockRelase_Det_id),0)+1,{0},{1},{2},'{3}','{4}',{5},{6},{7},{8},{9} FROM [RequestBlockStock_Release_Details]", this.RequestBlockStockRealase_Id , this.Itemcode , this.ColorId, this.Reqqty, this.Remarks, this.From_SO_Id , this.To_SO_Id , this.blockedqty,this.Length,this.BlockDetId );
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

            public string RequestBlockStockRelease_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[RequestBlockStock_Release_Details]", "RequestBlockRelase_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[RequestBlockStock_Release]", "RequestBlockRelase_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public int RequestBlockStockRelease_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [RequestBlockStock_Release] WHERE  [RequestBlockStock_Release].RequestBlockRelase_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.RequestBlockStockRealase_Id = dbManager.DataReader["RequestBlockRelase_Id"].ToString();
                    this.RequestBlockStockRealase_No = dbManager.DataReader["RequestBlockRelase_No"].ToString();
                    this.Required_Date = Convert.ToDateTime(dbManager.DataReader["Required_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Request_Type = dbManager.DataReader["Request_Type"].ToString();
                    this.Requested_for = dbManager.DataReader["Requested_For"].ToString();
                    this.Prepared_By = dbManager.DataReader["Prepared_By"].ToString();
                    this.TermsCondition_Id = dbManager.DataReader["TermsConditions_Id"].ToString();
                    this.Requested_date  = Convert.ToDateTime(dbManager.DataReader["Requested_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Status = dbManager.DataReader["Status"].ToString();
                    this.To_SO_Id = dbManager.DataReader["To_SO_Id"].ToString();
                    this.From_SO_Id = dbManager.DataReader["From_SO_Id"].ToString();
                    this.Approved_By = dbManager.DataReader["Approved_By"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                return _returnIntValue;
            }


        }






        //Methods for IssueBlockStockRealase
        public class IssueBlockStockRealase
        {
            public string IssueBlockId, ReqPurpose, IssueDate, FromSOId,  RequestedBy, ApprovedBy,ToSoid, IssueBlockNo, RequestedBlockId;
            public string IssedBlockDetId, Itemcode, ColorId,Length, Remarks,ReqQty,IssuedQty, DetFromsoid, Dettosoid, Oldblockedqty, BlockStockDetId,Custid,SiteId;

            public IssueBlockStockRealase() { }

            public static string IssueBlockStockRealase_AutoGenCode()
            {
                return AutoGenMaxNo("IssuedBlockStock", "IssueBlock_No");
            }

            public static void IssueBlockStockRealase_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT IssueBlock_No,IssueBlock_Id FROM [IssuedBlockStock] ORDER BY RequestBlockStockRealase_Id desc");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "IssueBlock_No", "IssueBlock_Id");
                }
            }



            public int IssueBlockStockRealase_Details_Delete(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("DELETE FROM [IssuedBlocked_Stock_Details] WHERE IssuedBlock_Id={0}", MaterialRequestId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                return _returnIntValue;
            }
            public string IssueBlockStockRealase_Save()
            {
                this.IssueBlockNo = AutoGenMaxNo("IssuedBlockStock", "IssueBlock_No");
                this.IssueBlockId = AutoGenMaxId("[IssuedBlockStock]", "IssueBlock_Id");
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [IssuedBlockStock] VALUES({0},'{1}','{2}',{3},{4},{5},{6},'{7}',{8})", this.IssueBlockId, this.ReqPurpose, this.IssueDate, this.FromSOId, this.RequestedBy, this.ApprovedBy, this.ToSoid, this.IssueBlockNo, this.RequestedBlockId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                _commandText = string.Format("UPDATE [RequestBlockStock_Release] SET  Status='Issued' WHERE RequestBlockRelase_Id={0}", this.RequestedBlockId);
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
            public string IssueBlockStockRealase_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("UPDATE [IssuedBlockStock] SET  Req_Purpose='{0}',Issue_Date='{1}',From_So_Id={2},Reqested_By={3},Approved_By={4},To_So_Id={4},IssueBlock_No='{5}',ReqestBlock_Id={6} WHERE IssueBlock_Id={7}", this.ReqPurpose, this.IssueDate, this.FromSOId, this.RequestedBy, this.ApprovedBy, this.ToSoid, this.IssueBlockNo, this.RequestedBlockId, this.IssueBlockId);
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

            public string IssueBlockStockRealase_Details_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [IssuedBlocked_Stock_Details] SELECT ISNULL(MAX(Issued_Block_Det_Id),0)+1,{0},{1},{2},{3},'{4}','{5}','{6}',{7},{8},{9},{10} FROM [IssuedBlocked_Stock_Details]", this.IssueBlockId, this.Itemcode, this.ColorId, this.Length, this.Remarks, this.ReqQty, this.IssuedQty, this.FromSOId, this.ToSoid,this.Oldblockedqty, this.BlockStockDetId);
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



               public string TransferBlockStockfrompartytoparty_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();


                _commandText = string.Format("UPDATE [Stock_Block] SET  Qty = Qty - '{0}', Remarks ='{1}' WHERE  BlockStock_Id = {2}", this.IssuedQty, this.Remarks, this.BlockStockDetId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);



                if (IsRecordExists("[Stock_Block]", "Item_Code", this.Itemcode, "Color_Id", this.ColorId, "Length", this.Length, "So_Id", this.ToSoid) == true)
                {
                    _commandText = string.Format("UPDATE [Stock_Block] SET  Qty = Qty+'{0}',Remarks =Remarks +'{1}' WHERE Item_Code = {2}  and Color_Id = {3} and Length ={4} and So_Id = {5} ", this.IssuedQty,this.Remarks, this.Itemcode, this.ColorId, this.Length, this.ToSoid);
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
                    _commandText = string.Format("INSERT INTO [Stock_Block] SELECT ISNULL(MAX(BlockStock_Id),0)+1,{0},{1},'{2}',{3},{4},{5},{6},'{7}',{8},{9},'{10}' FROM [Stock_Block]", this.ToSoid, this.Itemcode, this.IssuedQty, this.ColorId, '0', '0', this.Length, this.IssuedQty, this.Custid, this.SiteId, this.Remarks);
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


            public string IssueBlockStockRealase_Delete(string MaterialRequestId)
            {
                if (DeleteRecord("[IssuedBlocked_Stock_Details]", "IssuedBlock_Id", MaterialRequestId) == true)
                {
                    if (DeleteRecord("[IssuedBlockStock]", "IssueBlock_Id", MaterialRequestId) == true)
                    {
                        _returnStringMessage = "Data Deleted Successfully";
                    }
                    else
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                }
                else
                {
                    _returnStringMessage = "Some Data Missing.";
                }
                return _returnStringMessage;
            }

            public int IssueBlockStockRealase_Select(string MaterialRequestId)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [IssuedBlockStock] WHERE  [IssuedBlockStock].IssueBlock_Id='" + MaterialRequestId + "' ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.IssueBlockId = dbManager.DataReader["IssueBlock_Id"].ToString();
                    this.ReqPurpose = dbManager.DataReader["Req_Purpose"].ToString();
                    this.IssueDate = Convert.ToDateTime(dbManager.DataReader["Issue_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.FromSOId = dbManager.DataReader["From_So_Id"].ToString();
                    this.RequestedBy = dbManager.DataReader["Reqested_By"].ToString();
                    this.ApprovedBy = dbManager.DataReader["Approved_By"].ToString();
                    this.ToSoid = dbManager.DataReader["To_So_Id"].ToString();
                    this.IssueBlockNo = dbManager.DataReader["IssueBlock_No"].ToString();
                    this.RequestedBlockId = dbManager.DataReader["ReqestBlock_Id"].ToString();
                 
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

