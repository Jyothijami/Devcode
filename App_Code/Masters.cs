using phaniDAL;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Masters
/// </summary>
public class Masters
{
    private static int _returnIntValue;
    private static string _returnStringMessage, _commandText;
    static DBManager dbManager = new DBManager(DataProvider.SqlServer, DBConString.ConnectionString());

    public Masters()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //Method for dispose
    public static void Dispose()
    {
        dbManager.Dispose();
    }

    //Method for Begin Transaction
    public static void BeginTransaction()
    {
        dbManager.Open();
        dbManager.BeginTransaction();
    }

    //Method for Commit Transaction
    public static void CommitTransaction()
    {
        dbManager.CommitTransaction();
    }

    //Method for Rollback Transaction
    public static void RollBackTransaction()
    {
        dbManager.RollBackTransaction();
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

    //Method for Dropdownlist Binding
    private static void DropDownListBind(DropDownList ddl, string DataTextField, string DataValueField)
    {
        dbManager.Open();
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("Select an Option", "0"));
        while (dbManager.DataReader.Read())
        {
            ddl.Items.Add(new ListItem(dbManager.DataReader[DataTextField].ToString(), dbManager.DataReader[DataValueField].ToString()));
        }
        dbManager.DataReader.Close();
        dbManager.Close();
    }

    private static void ColorDropDownListBind(DropDownList ddl, string DataTextField, string DataValueField)
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
    private static void DropDownListBindcolor(DropDownList ddl, string DataTextField, string DataValueField)
    {
        dbManager.Open();
        ddl.Items.Clear();
        //ddl.Items.Add(new ListItem("Select an Option", "0"));
        while (dbManager.DataReader.Read())
        {
            ddl.Items.Add(new ListItem(dbManager.DataReader[DataTextField].ToString(), dbManager.DataReader[DataValueField].ToString()));
        }
        dbManager.DataReader.Close();
        dbManager.Close();
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
        return Prefix(TableName) + "-" + numb + "/" + CurrentFinancialYear();
    }

    public static string Prefix(string TableName)
    {
        if (dbManager.Transaction == null)
            dbManager.Open();
        _returnStringMessage = dbManager.ExecuteScalar(CommandType.Text, "SELECT " + phani.Classes.General.GetRequiredPrefix(TableName) + " FROM YANTRA_PREFIX").ToString();
        return _returnStringMessage.ToString();
    }

    //Method for to Get Current Financial Year
    public static string CurrentFinancialYear()
    {
        string year;
        if (dbManager.Transaction == null)
            dbManager.Open();
        year = dbManager.ExecuteScalar(CommandType.Text, "SELECT CP_CF_YEAR FROM [YANTRA_COMP_PROFILE]").ToString();
        if (string.IsNullOrEmpty(year))
        {
            year = "0000";
        }
        return year;
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
        _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT COUNT(*) FROM " + paraTableName + " WHERE " + paraFirstFieldName + "='" + paraFirstFieldValue + "' and " + paraSecondFieldName + "<>'" + paraSecondFieldValue + "'").ToString());
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

    //Method for GridBind Fill
    private static void GridViewBind(GridView gv)
    {
        gv.DataSource = dbManager.DataReader;
        gv.DataBind();
        dbManager.DataReader.Close();
    }

    //Method for Checkbox List Filling with statement

    #region chkbox list fill

    public static void CheckboxListWithStatement(CheckBoxList cblName, string command)
    {
        dbManager.Open();
        dbManager.ExecuteReader(CommandType.Text, command);
        cblName.Items.Clear();
        while (dbManager.DataReader.Read())
        {
            cblName.Items.Add(new ListItem(dbManager.DataReader[1].ToString(), dbManager.DataReader[0].ToString()));
        }
        dbManager.DataReader.Close();
    }

    #endregion chkbox list fill

    //Methods For EmployeeType Master Form
    public class EmployeeType
    {
        public string EmpTypeId, EmpTypeName, EmpTypeDesc;   //EmployeeType Look Up
        public EmployeeType()
        { }

        public static void EmployeeType_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Employee_Type] ORDER BY EMP_TYPE_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "EMP_TYPE_NAME", "EMP_TYPE_ID");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public string EmployeeType_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Employee_Type]", "EMP_TYPE_NAME", this.EmpTypeName) == false)
            {
                _commandText = string.Format("INSERT INTO [Employee_Type] SELECT ISNULL(MAX(EMP_TYPE_ID),0)+1,'{0}','{1}' FROM [Employee_Type]", this.EmpTypeName, this.EmpTypeDesc);
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
                _returnStringMessage = "Unit Code Already Exists.";
            }
            return _returnStringMessage;
        }

        public string EmployeeType_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Employee_Type]", "EMP_TYPE_NAME", this.EmpTypeName, "EMP_TYPE_ID", this.EmpTypeId) == false)
            {
                _commandText = string.Format("UPDATE [Employee_Type] SET EMP_TYPE_NAME='{0}',EMP_TYPE_DESC='{1}' WHERE EMP_TYPE_ID={2}", this.EmpTypeName, this.EmpTypeDesc, this.EmpTypeId);
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
                _returnStringMessage = "Emp Type Already Exists.";
            }
            return _returnStringMessage;
        }

        public string EmployeeType_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Employee_Type]", "EMP_TYPE_ID", this.EmpTypeId) == true)
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

        public int EmployeeType_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Employee_Type] where Employee_Type.EMP_TYPE_ID =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.EmpTypeId = dbManager.DataReader["EMP_TYPE_ID"].ToString();
                    this.EmpTypeName = dbManager.DataReader["EMP_TYPE_NAME"].ToString();
                    this.EmpTypeDesc = dbManager.DataReader["EMP_TYPE_DESC"].ToString();

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

    //Methods For Unit Master Form
    public class UnitMaster
    {
        public string UOMId, UOMName, UOMDesc;        // Unit Master
        public UnitMaster()
        { }

        public string UnitMaster_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Uom_Master]", "UOM_SHORT_DESC", this.UOMName) == false)
            {
                _commandText = string.Format("INSERT INTO [Uom_Master] SELECT ISNULL(MAX(UOM_ID),0)+1,'{0}','{1}' FROM [Uom_Master]", this.UOMName, this.UOMDesc);
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
                _returnStringMessage = "Unit Code Already Exists.";
            }
            return _returnStringMessage;
        }

        public string UnitMaster_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Uom_Master]", "UOM_SHORT_DESC", this.UOMName, "UOM_ID", this.UOMId) == false)
            {
                _commandText = string.Format("UPDATE [Uom_Master] SET UOM_SHORT_DESC='{0}',UOM_LONG_DESC='{1}' WHERE UOM_ID={2}", this.UOMName, this.UOMDesc, this.UOMId);
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
                _returnStringMessage = "Unit Code Already Exists.";
            }
            return _returnStringMessage;
        }

        public string UnitMaster_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Uom_Master]", "UOM_ID", this.UOMId) == true)
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

        public static void UnitMaster_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Uom_Master] ORDER BY UOM_SHORT_DESC");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "UOM_SHORT_DESC", "UOM_ID");
            }
        }

        public int Unit_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Uom_Master] where Uom_Master.UOM_ID =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.UOMId = dbManager.DataReader["UOM_ID"].ToString();
                    this.UOMName = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    this.UOMDesc = dbManager.DataReader["UOM_LONG_DESC"].ToString();

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

    //Methods For Payment Terms Form
    public class PaymentTerms
    {
        public string Id, Name, Desc;
        public PaymentTerms()
        { }

        public string PaymetnTerms_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[PaymentTerms_Master]", "PaymentTerms", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [PaymentTerms_Master] SELECT ISNULL(MAX(PaymentTerms_Id),0)+1,'{0}','{1}' FROM [PaymentTerms_Master]", this.Name, this.Desc);
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
                _returnStringMessage = "Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string PaymentMaster_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [PaymentTerms_Master] SET PaymentTerms='{0}',PaymentTerms_Desc='{1}' WHERE PaymentTerms_Id={2}", this.Name, this.Desc, this.Id);
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

        public string Payment_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[PaymentTerms_Master]", "PaymentTerms_Id", this.Id) == true)
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

        public static void Payment_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT PaymentTerms,PaymentTerms_Id FROM [PaymentTerms_Master] ORDER BY PaymentTerms_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "PaymentTerms", "PaymentTerms_Id");
            }
            //dbManager.Dispose();
        }

        public int Payment_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [PaymentTerms_Master] where PaymentTerms_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["PaymentTerms_Id"].ToString();
                    this.Name = dbManager.DataReader["PaymentTerms"].ToString();
                    this.Desc =  HttpUtility.HtmlDecode(dbManager.DataReader["PaymentTerms_Desc"].ToString());

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

    public class IncoTerms
    {
        public string Id, Name, Desc;
        public IncoTerms()
        { }

        public string IncoTerms_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Incoterms_Master]", "IncoTerms", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [Incoterms_Master] SELECT ISNULL(MAX(IncoTerms_Id),0)+1,'{0}','{1}' FROM [Incoterms_Master]", this.Name, this.Desc);
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
                _returnStringMessage = "Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string IncoTerms_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Incoterms_Master] SET IncoTerms='{0}',Incoterms_Desc='{1}' WHERE IncoTerms_Id={2}", this.Name, this.Desc, this.Id);
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

        public string IncoTerms_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Incoterms_Master]", "IncoTerms_Id", this.Id) == true)
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

        public static void IncoTerms_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Incoterms_Master] ORDER BY IncoTerms_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "IncoTerms", "IncoTerms_Id");
            }
        }

        public int IncoTerms_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Incoterms_Master] where IncoTerms_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["IncoTerms_Id"].ToString();
                    this.Name = dbManager.DataReader["IncoTerms"].ToString();
                    this.Desc = dbManager.DataReader["Incoterms_Desc"].ToString();

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

    public class IndustryType
    {
        public string Id, Name, Desc;
        public IndustryType()
        { }

        public string IndustryType_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[IndustryType_Master]", "IndustryType", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [IndustryType_Master] SELECT ISNULL(MAX(IndustryType_Id),0)+1,'{0}','{1}' FROM [IndustryType_Master]", this.Name, this.Desc);
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
                _returnStringMessage = "Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string IndustryType_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [IndustryType_Master] SET IndustryType='{0}',Description='{1}' WHERE IndustryType_Id={2}", this.Name, this.Desc, this.Id);
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

        public string IndustryType_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[IndustryType_Master]", "IndustryType_Id", this.Id) == true)
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

        public static void IndustryType_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [IndustryType_Master] ORDER BY IndustryType_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "IndustryType", "IndustryType_Id");
            }
        }

        public int IndustryType_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [IndustryType_Master] where IndustryType_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["IndustryType_Id"].ToString();
                    this.Name = dbManager.DataReader["IndustryType"].ToString();
                    this.Desc = dbManager.DataReader["Description"].ToString();

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

    public class SupplierType
    {
        public string Id, Name, Desc;
        public SupplierType()
        { }

        public string SupplierType_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Supplier_Type]", "SupType_Name", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [Supplier_Type] SELECT ISNULL(MAX(SupType_Id),0)+1,'{0}','{1}' FROM [Supplier_Type]", this.Name, this.Desc);
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
                _returnStringMessage = "Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string SupplierType_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Supplier_Type] SET SupType_Name='{0}',Description='{1}' WHERE SupType_Id={2}", this.Name, this.Desc, this.Id);
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

        public string SupplierType_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Supplier_Type]", "SupType_Id", this.Id) == true)
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

        public static void SupplierType_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Supplier_Type] ORDER BY SupType_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "SupType_Name", "SupType_Id");
            }
        }

        public int SupplierType_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Supplier_Type] where SupType_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["SupType_Id"].ToString();
                    this.Name = dbManager.DataReader["SupType_Name"].ToString();
                    this.Desc = dbManager.DataReader["Description"].ToString();

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

    public class Salutation
    {
        public string Id, Name, Desc;
        public Salutation()
        { }

        public string Salutation_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Salutation_Master]", "Salutation", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [Salutation_Master] SELECT ISNULL(MAX(Salutation_id),0)+1,'{0}','{1}' FROM [Salutation_Master]", this.Name, this.Desc);
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
                _returnStringMessage = "Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Salutation_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Salutation_Master] SET Salutation='{0}',Sal_desc='{1}' WHERE Salutation_id={2}", this.Name, this.Desc, this.Id);
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

        public string Salutation_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Salutation_Master]", "Salutation_id", this.Id) == true)
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

        public static void Salutation_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Salutation_Master] ORDER BY Salutation_id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Salutation", "Salutation_id");
            }
        }

        public int Salutation_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Salutation_Master] where Salutation_id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["Salutation_id"].ToString();
                    this.Name = dbManager.DataReader["Salutation"].ToString();
                    this.Desc = dbManager.DataReader["Sal_desc"].ToString();

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

    public class LeadSource
    {
        public string Id, Name, Desc;
        public LeadSource()
        { }

        public string LeadSource_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[LeadSource]", "LeadSource", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [LeadSource] SELECT ISNULL(MAX(LeadSource_id),0)+1,'{0}','{1}' FROM [LeadSource]", this.Name, this.Desc);
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
                _returnStringMessage = "Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string LeadSource_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [LeadSource] SET LeadSource='{0}',Description='{1}' WHERE LeadSource_id={2}", this.Name, this.Desc, this.Id);
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

        public string LeadSource_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[LeadSource]", "LeadSource_id", this.Id) == true)
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

        public static void LeadSource_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [LeadSource] ORDER BY LeadSource_id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "LeadSource", "LeadSource_id");
            }
        }

        public int LeadSource_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [LeadSource] where LeadSource_id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["LeadSource_id"].ToString();
                    this.Name = dbManager.DataReader["LeadSource"].ToString();
                    this.Desc = dbManager.DataReader["Description"].ToString();

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

    public class SalesTermsConditions
    {
        public string Id, Name, Desc;
        public SalesTermsConditions()
        { }

        public string SalesTermsConditions_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Sales_TermsConditions]", "Terms_Conditions_Name", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [Sales_TermsConditions] SELECT ISNULL(MAX(Sales_TC_Id),0)+1,'{0}','{1}' FROM [Sales_TermsConditions]", this.Name, this.Desc);
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
                _returnStringMessage = "Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string SalesTermsConditions_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Sales_TermsConditions] SET Terms_Conditions_Name='{0}',Descritpion='{1}' WHERE Sales_TC_Id={2}", this.Name, this.Desc, this.Id);
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

        public string SalesTermsConditions_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Sales_TermsConditions]", "Sales_TC_Id", this.Id) == true)
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

        public static void SalesTermsConditions_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Terms_Conditions_Name,Sales_TC_Id FROM [Sales_TermsConditions] ORDER BY Sales_TC_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Terms_Conditions_Name", "Sales_TC_Id");
            }
            //dbManager.Dispose();
        }

        public int SalesTermsConditions_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Sales_TermsConditions] where Sales_TC_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["Sales_TC_Id"].ToString();
                    this.Name = dbManager.DataReader["Terms_Conditions_Name"].ToString();
                    this.Desc = dbManager.DataReader["Descritpion"].ToString();

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




    /// <summary>
    /// Storage
    /// </summary>
    public class SalesStorage
    {
        public string Id, Name, Desc;
        public SalesStorage()
        { }

        public string SalesStorage_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Sales_Storage_Template]", "Terms_Conditions_Name", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [Sales_Storage_Template] SELECT ISNULL(MAX(Sales_Storage_Id),0)+1,'{0}','{1}' FROM [Sales_Storage_Template]", this.Name, this.Desc);
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
                _returnStringMessage = "Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string SalesStorage_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Sales_Storage_Template] SET Terms_Conditions_Name='{0}',Descritpion='{1}' WHERE Sales_Storage_Id={2}", this.Name, this.Desc, this.Id);
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

        public string SalesStorage_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Sales_Storage_Template]", "Sales_Storage_Id", this.Id) == true)
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

        public static void SalesStorage_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Terms_Conditions_Name,Sales_Storage_Id FROM [Sales_Storage_Template] ORDER BY Sales_Storage_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Terms_Conditions_Name", "Sales_Storage_Id");
            }
            //dbManager.Close();
        }

        public int SalesStorage_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Sales_Storage_Template] where Sales_Storage_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["Sales_Storage_Id"].ToString();
                    this.Name = dbManager.DataReader["Terms_Conditions_Name"].ToString();
                    this.Desc = dbManager.DataReader["Descritpion"].ToString();

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




    /// <summary>
    /// Damage
    /// </summary>
    public class SalesDamage
    {
        public string Id, Name, Desc;
        public SalesDamage()
        { }

        public string SalesDamage_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Sales_Damage_Template]", "Terms_Conditions_Name", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [Sales_Damage_Template] SELECT ISNULL(MAX(Sales_Damage_Id),0)+1,'{0}','{1}' FROM [Sales_Damage_Template]", this.Name, this.Desc);
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
                _returnStringMessage = "Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string SalesDamage_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Sales_Damage_Template] SET Terms_Conditions_Name='{0}',Descritpion='{1}' WHERE Sales_Damage_Id={2}", this.Name, this.Desc, this.Id);
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

        public string SalesDamage_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Sales_Damage_Template]", "Sales_Damage_Id", this.Id) == true)
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

        public static void SalesDamage_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Terms_Conditions_Name,Sales_Damage_Id FROM [Sales_Damage_Template] ORDER BY Sales_Damage_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Terms_Conditions_Name", "Sales_Damage_Id");
            }
            //dbManager.Dispose();
        }

        public int SalesDamage_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Sales_Damage_Template] where Sales_Damage_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["Sales_Damage_Id"].ToString();
                    this.Name = dbManager.DataReader["Terms_Conditions_Name"].ToString();
                    this.Desc = dbManager.DataReader["Descritpion"].ToString();

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





    /// <summary>
    /// Installation technical
    /// </summary>
    public class Installationtech
    {
        public string Id, Name, Desc;
        public Installationtech()
        { }

        public string Installationtech_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Installation_Assistance_Template]", "Terms_Conditions_Name", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [Installation_Assistance_Template] SELECT ISNULL(MAX(Sales_Installation_Id),0)+1,'{0}','{1}' FROM [Installation_Assistance_Template]", this.Name, this.Desc);
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
                _returnStringMessage = "Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Installationtech_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Installation_Assistance_Template] SET Terms_Conditions_Name='{0}',Descritpion='{1}' WHERE Sales_Installation_Id={2}", this.Name, this.Desc, this.Id);
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

        public string Installationtech_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Installation_Assistance_Template]", "Sales_Installation_Id", this.Id) == true)
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

        public static void Installationtech_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Terms_Conditions_Name,Sales_Installation_Id FROM [Installation_Assistance_Template] ORDER BY Sales_Installation_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Terms_Conditions_Name", "Sales_Installation_Id");
            }
            //dbManager.Dispose();
        }

        public int Installationtech_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Installation_Assistance_Template] where Sales_Installation_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["Sales_Installation_Id"].ToString();
                    this.Name = dbManager.DataReader["Terms_Conditions_Name"].ToString();
                    this.Desc = dbManager.DataReader["Descritpion"].ToString();

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


















    //Methods For Operation Master
    public class OperationMaster
    {
        public string ItCategoryId, ItCategoryName, ItCategoryDesc;   //Item Category Master
        public OperationMaster()
        {
        }

        public string OperationMaster_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Operation_Master]", "Operation_Name", this.ItCategoryName) == false)
            {
                _commandText = string.Format("INSERT INTO [Operation_Master] SELECT ISNULL(MAX(Operation_Id),0)+1,'{0}','{1}' FROM [Operation_Master]", this.ItCategoryName, this.ItCategoryDesc);
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
                _returnStringMessage = "Operation Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string OperationMaster_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Operation_Master] SET Operation_Name='{0}',Operation_Details='{1}' WHERE Operation_Id={2}", this.ItCategoryName, this.ItCategoryDesc, this.ItCategoryId);
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

        public string Operation_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Operation_Master]", "Operation_Id", this.ItCategoryId) == true)
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

        public static void Operation_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Operation_Master] ORDER BY Operation_Name");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Operation_Name", "Operation_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }


        public int Operation_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Operation_Master] where Operation_Master.Operation_Id=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ItCategoryId = dbManager.DataReader["Operation_Id"].ToString();
                    this.ItCategoryName = dbManager.DataReader["Operation_Name"].ToString();
                    this.ItCategoryDesc = dbManager.DataReader["Operation_Details"].ToString();

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




    //Methods For ItemBrand Master
    public class ItemBrand
    {
        public string ItemBrandId, ItemBrandName, ItemBrandDesc;   //ItemBrand Master
        public ItemBrand()
        {
        }

        public string ItemBrand_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Brand_Master]", "Brand_Name", this.ItemBrandName) == false)
            {
                _commandText = string.Format("INSERT INTO [Brand_Master] SELECT ISNULL(MAX(Brand_Id),0)+1,'{0}','{1}' FROM [Brand_Master]", this.ItemBrandName, this.ItemBrandDesc);
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
                _returnStringMessage = "Series Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string ItemBrand_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Brand_Master] SET Brand_Name='{0}',Description='{1}' WHERE Brand_Id={2}", this.ItemBrandName, this.ItemBrandDesc, this.ItemBrandId);
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

        public string ItemBrand_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Brand_Master]", "Brand_Id", this.ItemBrandId) == true)
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

        public static void ItemBrand_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Brand_Master] ORDER BY Brand_Name");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Brand_Name", "Brand_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        
        public int ItemBrand_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Brand_Master] where Brand_Master.Brand_Id=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ItemBrandId = dbManager.DataReader["Brand_Id"].ToString();
                    this.ItemBrandName = dbManager.DataReader["Brand_Name"].ToString();
                    this.ItemBrandDesc = dbManager.DataReader["Description"].ToString();

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


    //Methods For ItemSeries Master
    public class ItemSeries
    {
        public string ItemSeriesId, ItemSeriesName, ItemSeriesDesc;   //ItemSeries Master
        public ItemSeries()
        {
        }

        public string ItemSeries_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[ItemSeries]", "Item_Series", this.ItemSeriesName) == false)
            {
                _commandText = string.Format("INSERT INTO [ItemSeries] SELECT ISNULL(MAX(Item_Series_Id),0)+1,'{0}','{1}' FROM [ItemSeries]", this.ItemSeriesName, this.ItemSeriesDesc);
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
                _returnStringMessage = "Series Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string ItemSeries_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [ItemSeries] SET Item_Series='{0}',Description='{1}' WHERE Item_Series_Id={2}", this.ItemSeriesName, this.ItemSeriesDesc, this.ItemSeriesId);
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

        public string ItemSeries_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[ItemSeries]", "Item_Series_Id", this.ItemSeriesId) == true)
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

        public static void ItemSeries_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Item_Series,Item_Series_Id FROM [ItemSeries] where Item_Series_Id != '0' ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Item_Series", "Item_Series_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }


        public int ItemSeries_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [ItemSeries] where ItemSeries.Item_Series_Id=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ItemSeriesId = dbManager.DataReader["Item_Series_Id"].ToString();
                    this.ItemSeriesName = dbManager.DataReader["Item_Series"].ToString();
                    this.ItemSeriesDesc = dbManager.DataReader["Description"].ToString();

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



    //Methods For ItemCategory Master
    public class ItemCategory
    {
        public string ItCategoryId, ItCategoryName, ItCategoryDesc;   //Item Category Master
        public ItemCategory()
        {
        }

        public string ItemCategory_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Category_Master]", "ITEM_CATEGORY_NAME", this.ItCategoryName) == false)
            {
                _commandText = string.Format("INSERT INTO [Category_Master] SELECT ISNULL(MAX(ITEM_CATEGORY_ID),0)+1,'{0}','{1}' FROM [Category_Master]", this.ItCategoryName, this.ItCategoryDesc);
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
                _returnStringMessage = "category Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string ItemCategory_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Category_Master]", "ITEM_CATEGORY_NAME", this.ItCategoryName, "ITEM_CATEGORY_ID", this.ItCategoryId) == false)
            {
                _commandText = string.Format("UPDATE [Category_Master] SET ITEM_CATEGORY_NAME='{0}',ITEM_CATEGORY_DESC='{1}' WHERE ITEM_CATEGORY_ID={2}", this.ItCategoryName, this.ItCategoryDesc, this.ItCategoryId);
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
                _returnStringMessage = "Category Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string ItemCategory_Delete()
        {
           // Masters.BeginTransaction();
            if (DeleteRecord("[Category_Master]", "ITEM_CATEGORY_ID", this.ItCategoryId) == true)
            {
              //  Masters.CommitTransaction();
                _returnStringMessage = "Data Deleted Successfully";
            }
            else
            {
                //Masters.RollBackTransaction();
                _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
            }
            return _returnStringMessage;
        }

        public static void ItemCategory_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Category_Master] ORDER BY ITEM_CATEGORY_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "ITEM_CATEGORY_NAME", "ITEM_CATEGORY_ID");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public static void ItemCategory_SelectForPrint(Control ControlForBind, string brand, string category)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT  DISTINCT(dbo.YANTRA_LKUP_ITEM_TYPE.IT_TYPE_ID),dbo.YANTRA_LKUP_ITEM_TYPE.IT_TYPE FROM  dbo.Category_Master INNER JOIN   dbo.YANTRA_ITEM_MAST INNER JOIN dbo.YANTRA_LKUP_PRODUCT_COMPANY ON dbo.YANTRA_ITEM_MAST.BRAND_ID = dbo.YANTRA_LKUP_PRODUCT_COMPANY.PRODUCT_COMPANY_ID ON dbo.Category_Master.ITEM_CATEGORY_ID = dbo.YANTRA_ITEM_MAST.IC_ID INNER JOIN dbo.YANTRA_LKUP_ITEM_TYPE ON dbo.YANTRA_ITEM_MAST.IT_TYPE_ID = dbo.YANTRA_LKUP_ITEM_TYPE.IT_TYPE_ID WHERE     (dbo.YANTRA_ITEM_MAST.IC_ID =" + category + ") AND (dbo.YANTRA_ITEM_MAST.BRAND_ID =" + brand + ")");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "IT_TYPE", "IT_TYPE_ID");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public int ItemCategory_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Category_Master] where Category_Master.ITEM_CATEGORY_ID=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ItCategoryId = dbManager.DataReader["ITEM_CATEGORY_ID"].ToString();
                    this.ItCategoryName = dbManager.DataReader["ITEM_CATEGORY_NAME"].ToString();
                    this.ItCategoryDesc = dbManager.DataReader["ITEM_CATEGORY_DESC"].ToString();

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


    //Methods For JobTitle
    public class JobTitle
    {
        public string ItCategoryId, ItCategoryName, ItCategoryDesc;   
        public JobTitle()
        {
        }

        public string JobTitle_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[JobTitle]", "JobTitle", this.ItCategoryName) == false)
            {
                _commandText = string.Format("INSERT INTO [JobTitle] SELECT ISNULL(MAX(Jobtitle_Id),0)+1,'{0}','{1}' FROM [JobTitle]", this.ItCategoryName, this.ItCategoryDesc);
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
                _returnStringMessage = "Job Title Already Exists.";
            }
            return _returnStringMessage;
        }

        public string JobTitle_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [JobTitle] SET JobTitle='{0}',Description='{1}' WHERE Jobtitle_Id={2}", this.ItCategoryName, this.ItCategoryDesc, this.ItCategoryId);
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

        public string JobTitle_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[JobTitle]", "Jobtitle_Id", this.ItCategoryId) == true)
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

        public static void JobTitle_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Jobtitle_Id,JobTitle FROM [JobTitle] ORDER BY JobTitle");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "JobTitle", "Jobtitle_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }


        public int JobTitle_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [JobTitle] where JobTitle.Jobtitle_Id=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ItCategoryId = dbManager.DataReader["Jobtitle_Id"].ToString();
                    this.ItCategoryName = dbManager.DataReader["JobTitle"].ToString();
                    this.ItCategoryDesc = dbManager.DataReader["Description"].ToString();

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

    //Methods For GradeMaster
    public class GradeMaster
    {
        public string ItCategoryId, ItCategoryName, ItCategoryDesc;
        public GradeMaster()
        {
        }

        public string GradeMaster_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Grade_Master]", "Grade_Name", this.ItCategoryName) == false)
            {
                _commandText = string.Format("INSERT INTO [Grade_Master] SELECT ISNULL(MAX(Grade_Id),0)+1,'{0}','{1}' FROM [Grade_Master]", this.ItCategoryName, this.ItCategoryDesc);
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
                _returnStringMessage = "Grade Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string GradeMaster_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Grade_Master] SET Grade_Name='{0}',Grade_Details='{1}' WHERE Grade_Id={2}", this.ItCategoryName, this.ItCategoryDesc, this.ItCategoryId);
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

        public string GradeMaster_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Grade_Master]", "Grade_Id", this.ItCategoryId) == true)
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

        public static void GradeMaster_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Grade_Id,Grade_Name FROM [Grade_Master] ORDER BY Grade_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Grade_Name", "Grade_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }


        public int GradeMaster_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Grade_Master] where Grade_Master.Grade_Id =" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ItCategoryId = dbManager.DataReader["Grade_Id"].ToString();
                    this.ItCategoryName = dbManager.DataReader["Grade_Name"].ToString();
                    this.ItCategoryDesc = dbManager.DataReader["Grade_Details"].ToString();

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
    //Methods For State Master
    public class State
    {
        public string StateId, CountryId, StateName;   //State Master
        public State()
        {
        }

        public string State_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[State_Master]", "STATE_NAME", this.StateName) == false)
            {
                _commandText = string.Format("INSERT INTO [State_Master] SELECT ISNULL(MAX(STATE_ID),0)+1,'{0}',{1} FROM [State_Master]", this.StateName, this.CountryId);
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
                _returnStringMessage = "State Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string State_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [State_Master] SET STATE_NAME = '{0}',  COUNTRY_ID={1} WHERE STATE_ID = {2}", this.StateName, this.CountryId, this.StateId);
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

        public string State_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[State_Master]", "STATE_ID", this.StateId) == true)
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

        public static void State_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [State_Master] ORDER BY STATE_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "STATE_NAME", "STATE_ID");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public int State_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [State_Master] where State_Master.STATE_ID =" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.StateId = dbManager.DataReader["STATE_ID"].ToString();
                    this.StateName = dbManager.DataReader["STATE_NAME"].ToString();
                    this.CountryId = dbManager.DataReader["COUNTRY_ID"].ToString();
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

    //Methods For City Master
    public class City
    {
        public string CityId, StateId, CityName;   //City Master
        public City()
        {
        }

        public string City_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[City_Master]", "CITY_NAME", this.CityName) == false)
            {
                _commandText = string.Format("INSERT INTO [City_Master] SELECT ISNULL(MAX(CITY_ID),0)+1,'{0}',{1} FROM [City_Master]", this.CityName, this.StateId);
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
                _returnStringMessage = "City Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string City_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [City_Master] SET CITY_NAME = '{0}',  STATE_ID={1} WHERE CITY_ID = {2}", this.CityName, this.StateId, this.CityId);
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

        public string City_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[City_Master]", "CITY_ID", this.CityId) == true)
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

        public static void City_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [City_Master] ORDER BY CITY_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "CITY_NAME", "CITY_ID");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }


        public static void City_Select(Control ControlForBind,string Stateid)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [City_Master] where STATE_ID = '"+Stateid+"' ORDER BY CITY_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "CITY_NAME", "CITY_ID");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public int City_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [City_Master] where City_Master.CITY_ID =" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.CityId = dbManager.DataReader["CITY_ID"].ToString();
                    this.CityName = dbManager.DataReader["CITY_NAME"].ToString();
                    this.StateId = dbManager.DataReader["STATE_ID"].ToString();
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



    //Methods For ItemSubCategory Master
    public class ItemSubCategory
    {
        public string ItsubCategoryId, Catid, ItsubCategoryName, ItsubCategoryDesc;   //Item Sub Category Master
        public ItemSubCategory()
        {
        }

        public string ItemSubCategory_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[SubCategory_Master]", "SubCategory_Name", this.ItsubCategoryName) == false)
            {
                _commandText = string.Format("INSERT INTO [SubCategory_Master] SELECT ISNULL(MAX(SubCategory_Id),0)+1,{0},'{1}','{2}' FROM [SubCategory_Master]", this.Catid, this.ItsubCategoryName, this.ItsubCategoryDesc);
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
                _returnStringMessage = "Sub Category Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string ItemSubCategory_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[SubCategory_Master]", "SubCategory_Name", this.ItsubCategoryName) == false)
            {
                _commandText = string.Format("UPDATE [SubCategory_Master] SET Category_Id = '{0}',  SubCategory_Name='{1}',SubCategory_Description='{2}' WHERE SubCategory_Id = {3}", this.Catid, this.ItsubCategoryName, this.ItsubCategoryDesc, this.ItsubCategoryId);
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
                _returnStringMessage = "Sub Category Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string ItemSubCategory_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[SubCategory_Master]", "SubCategory_Id", this.ItsubCategoryId) == true)
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

        public static void ItemSubCategory_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [SubCategory_Master] ORDER BY SubCategory_Name");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "SubCategory_Name", "SubCategory_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public int SubItemCategory_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [SubCategory_Master] where SubCategory_Master.SubCategory_Id =" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ItsubCategoryId = dbManager.DataReader["SubCategory_Id"].ToString();
                    this.ItsubCategoryName = dbManager.DataReader["SubCategory_Name"].ToString();
                    this.ItsubCategoryDesc = dbManager.DataReader["SubCategory_Description"].ToString();
                    this.Catid = dbManager.DataReader["Category_Id"].ToString();
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

    //Methods For Plant Master
    public class Plant
    {
        public string PlantId, Cpid, Name, Desc;
        public Plant()
        {
        }

        public string Plant_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Plant_Master]", "Plant_Name", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [Plant_Master] SELECT ISNULL(MAX(Plant_Id),0)+1,{0},'{1}','{2}' FROM [Plant_Master]", this.Cpid, this.Name, this.Desc);
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
                _returnStringMessage = "Plant Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Plant_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Plant_Master]", "Plant_Name", this.Name) == false)
            {
                _commandText = string.Format("UPDATE [Plant_Master] SET Company_Id = '{0}',  Plant_Name='{1}',Plant_Description='{2}' WHERE Plant_Id = {3}", this.Cpid, this.Name, this.Desc, this.PlantId);
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
                _returnStringMessage = "Plant Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Plant_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Plant_Master]", "Plant_Id", this.PlantId) == true)
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

        public static void Company_Plant_Select(Control ControlForBind, string Cmpid)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM Company_Profile,[Plant_Master] where Company_Profile.CP_ID = Plant_Master.Company_Id and Company_Profile.CP_ID = '" + Cmpid + "'  ORDER BY Plant_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Plant_Name", "Plant_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public static void Plant_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Plant_Master] ORDER BY Plant_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Plant_Name", "Plant_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public int Plant_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Plant_Master] where Plant_Master.Plant_Id =" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.PlantId = dbManager.DataReader["Plant_Id"].ToString();
                    this.Name = dbManager.DataReader["Plant_Name"].ToString();
                    this.Desc = dbManager.DataReader["Plant_Description"].ToString();
                    this.Cpid = dbManager.DataReader["Company_Id"].ToString();
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

    //Methods For ItemCategory Master
    public class GODOWN
    {
        public string ItCategoryId, ItCategoryName, ItCategoryDesc;   //Godown Master
        public GODOWN()
        {
        }

        public string GODOWN_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[GODOWN_MASTER]", "GODOWN_NAME", this.ItCategoryName) == false)
            {
                _commandText = string.Format("INSERT INTO [GODOWN_MASTER] SELECT ISNULL(MAX(GODOWN_ID),0)+1,'{0}','{1}' FROM [GODOWN_MASTER]", this.ItCategoryName, this.ItCategoryDesc);
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
                _returnStringMessage = "GODOWN Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string GODOWN_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[GODOWN_MASTER]", "GODOWN_NAME", this.ItCategoryName, "GODOWN_ID", this.ItCategoryId) == false)
            {
                _commandText = string.Format("UPDATE [GODOWN_MASTER] SET GODOWN_NAME='{0}',GODOWN_ADDRESS='{1}' WHERE GODOWN_ID={2}", this.ItCategoryName, this.ItCategoryDesc, this.ItCategoryId);
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
                _returnStringMessage = "GODOWN Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string GODOWN_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[GODOWN_MASTER]", "GODOWN_ID", this.ItCategoryId) == true)
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

        public static void GODOWN_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [GODOWN_MASTER] ORDER BY GODOWN_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "GODOWN_NAME", "GODOWN_ID");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }
    }

    //Methods For StockTYpe
    public class StockType
    {
        public string ItCategoryId, ItCategoryName, ItCategoryDesc;   //StockType Master
        public StockType()
        {
        }

        public string StockType_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Stock_Type]", "Stock_Type", this.ItCategoryName) == false)
            {
                _commandText = string.Format("INSERT INTO [Stock_Type] SELECT ISNULL(MAX(StockType_Id),0)+1,'{0}','{1}' FROM [Stock_Type]", this.ItCategoryName, this.ItCategoryDesc);
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
                _returnStringMessage = "StockType Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string StockType_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Stock_Type]", "Stock_Type", this.ItCategoryName, "StockType_Id", this.ItCategoryId) == false)
            {
                _commandText = string.Format("UPDATE [Stock_Type] SET Stock_Type='{0}',Stock_Description='{1}' WHERE StockType_Id={2}", this.ItCategoryName, this.ItCategoryDesc, this.ItCategoryId);
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
                _returnStringMessage = "StockType Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string StockType_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Stock_Type]", "StockType_Id", this.ItCategoryId) == true)
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

        public static void StockType_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Stock_Type] ORDER BY Stock_Type");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Stock_Type", "StockType_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }
    }

    //Methods For Product Master
    public class ProductMaster
    {
        public string Id, Code, Name, Sizes, Brand, MRP, GST, Category;
        public ProductMaster()
        {
        }

        public string ProductMaster_Save()
        {
            dbManager.Open();

            _commandText = string.Format("INSERT INTO [Product_Master] SELECT ISNULL(MAX(Product_Id),0)+1,'{0}','{1}','{2}','{3}','{4}','{5}','{6}' FROM [Product_Master]", this.Code, this.Name, this.Sizes, this.Brand, this.MRP, this.GST, this.Category);
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

        public string ProductMaster_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Product_Master] SET Product_Code='{0}',Name ='{1}',Sizes='{2}',Brand='{3}',MRP='{4}',GST='{5}',Category='{6}' WHERE Product_Id={7}", this.Code, this.Name, this.Sizes, this.Brand, this.MRP, this.GST, this.Category, this.Id);
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

        public string ProductMaster_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Product_Master]", "Product_Id", this.Id) == true)
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

        public static void ProductMaster_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("select Name +'-'+Sizes as Name,Product_Id from Product_Master order by Name Asc");
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

        public int ProductMaster_Select(string Id)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Product_Master] where Product_Id='" + Id + "' ORDER BY Product_Id DESC ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (dbManager.DataReader.Read())
            {
                this.Id = dbManager.DataReader["Product_Id"].ToString();
                this.Code = dbManager.DataReader["Product_Code"].ToString();
                this.Name = dbManager.DataReader["Name"].ToString();
                this.Sizes = dbManager.DataReader["Sizes"].ToString();
                this.Brand = dbManager.DataReader["Brand"].ToString();
                this.MRP = dbManager.DataReader["MRP"].ToString();
                this.GST = dbManager.DataReader["GST"].ToString();
                this.Category = dbManager.DataReader["Category"].ToString();
                _returnIntValue = 1;
            }
            else
            {
                _returnIntValue = 0;
            }
            return _returnIntValue;
        }

        public string stockqty, batchno, mfg, exp;
        public int ProductMasterBatch_Select(string Id)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("SELECT * FROM [STOCK] where Batch_No ='" + Id + "' ORDER BY Product_Id DESC ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (dbManager.DataReader.Read())
            {
                this.stockqty = dbManager.DataReader["QTY"].ToString();
                this.batchno = dbManager.DataReader["Batch_No"].ToString();
                this.mfg = Convert.ToDateTime(dbManager.DataReader["MFG_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                this.exp = Convert.ToDateTime(dbManager.DataReader["EXP_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                _returnIntValue = 1;
            }
            else
            {
                _returnIntValue = 0;
            }
            return _returnIntValue;
        }

        public int ProductMasterBatch_Select(string Id, string productid)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("SELECT * FROM [STOCK] where Batch_No ='" + Id + "' and Product_Id = '" + productid + "' ORDER BY Product_Id DESC ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (dbManager.DataReader.Read())
            {
                this.stockqty = dbManager.DataReader["QTY"].ToString();
                this.batchno = dbManager.DataReader["Batch_No"].ToString();
                this.mfg = Convert.ToDateTime(dbManager.DataReader["MFG_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                this.exp = Convert.ToDateTime(dbManager.DataReader["EXP_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                _returnIntValue = 1;
            }
            else
            {
                _returnIntValue = 0;
            }
            return _returnIntValue;
        }

        public static void ProductMasterBatch_Select(Control ControlForBind, string id)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [STOCK] where Product_Id = '" + id + "' ORDER BY Product_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Batch_No", "Batch_No");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public static string Code_AutoGenCode()
        {
            return AutoGenNo("Product_Master", "Product_Id");
        }
    }

    public static string AutoGenNo(string TableName, string FieldName)
    {
        if (dbManager.Transaction == null)
            dbManager.Open();
        _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(" + FieldName + "),0)+1 FROM " + TableName + "").ToString());

        string hello;
        //   hello = _returnIntValue + "R" + "/" + CurrentFinancialYear();
        hello = "R" + _returnIntValue;
        return hello;

        //return _returnIntValue.ToString();
    }

    //Methods For Country Master Form
    public class Country
    {
        public string CountryId, CountryName, cURRENCY;  //Country Master
        public Country()
        { }

        public int Country_Select(string Id)
        {
            try
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [Country_Master] where COUNTRY_ID ='" + Id + "' ORDER BY COUNTRY_ID DESC ");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.CountryName = dbManager.DataReader["COUNTRY_NAME"].ToString();
                    this.cURRENCY = dbManager.DataReader["CURRENCY"].ToString();
                    _returnIntValue = 1;
                }
                else
                {
                    _returnIntValue = 0;
                }
                dbManager.Close();
                return _returnIntValue;
            }
            finally
            {
                dbManager.Close();
            }
        }

        public static string GetCountryName(string Id)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT COUNTRY_NAME FROM [Country_Master] where COUNTRY_ID=" + Id);
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (dbManager.DataReader.Read())
            {
                //this.ItemCode = dbManager.DataReader["ITEM_CODE"].ToString();
                //this.ItemType = dbManager.DataReader["IT_TYPE"].ToString();
                _returnStringMessage = dbManager.DataReader["COUNTRY_NAME"].ToString();
            }
            dbManager.DataReader.Close();
            return _returnStringMessage; ;
        }

        public string Country_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Country_Master]", "COUNTRY_NAME", this.CountryName) == false)
            {
                _commandText = string.Format("INSERT INTO [Country_Master] SELECT ISNULL(MAX(COUNTRY_ID),0)+1,'{0}','{1}' FROM [Country_Master]", this.CountryName, this.cURRENCY);
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
                _returnStringMessage = "Country Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Country_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Country_Master] SET COUNTRY_NAME='{0}',CURRENCY='{1}' WHERE COUNTRY_ID={2}", this.CountryName, this.cURRENCY, this.CountryId);
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

        public string Country_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Country_Master]", "COUNTRY_ID", this.CountryId) == true)
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

        public static void Country_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT  * FROM [Country_Master] ORDER BY COUNTRY_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "COUNTRY_NAME", "COUNTRY_ID");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }
    }

    //Methods For Item Type Form
    public class ItemType
    {
        public string ItemTypeId, ItemTypeName, ItemDesc, ItemCategoryId;
        public ItemType()
        { }

        public string ItemType_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[YANTRA_LKUP_ITEM_TYPE]", "IT_TYPE", this.ItemTypeName) == false)
            {
                _commandText = string.Format("INSERT INTO [YANTRA_LKUP_ITEM_TYPE] SELECT ISNULL(MAX(IT_TYPE_ID),0)+1,'{0}',{1},'{2}' FROM [YANTRA_LKUP_ITEM_TYPE]", this.ItemTypeName, this.ItemCategoryId, this.ItemDesc);
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
                _returnStringMessage = "Item Type Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string ItemType_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [YANTRA_LKUP_ITEM_TYPE] SET IT_TYPE='{0}',IT_DESC='{1}',ITEM_CATEGORY_ID={2} WHERE IT_TYPE_ID={3}", this.ItemTypeName, this.ItemDesc, this.ItemCategoryId, this.ItemTypeId);
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

        public string ItemType_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[YANTRA_LKUP_ITEM_TYPE]", "IT_TYPE_ID", this.ItemTypeId) == true)
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

        public static void ItemType_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [YANTRA_LKUP_ITEM_TYPE] ORDER BY IT_TYPE");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "IT_TYPE", "IT_TYPE_ID");
            }
        }

        public static void ItemTypeCategory_Select(Control ControlForBind, string ItemTypeId)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [YANTRA_LKUP_ITEM_TYPE] WHERE ITEM_CATEGORY_ID =" + ItemTypeId + " ORDER BY IT_TYPE");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "IT_TYPE", "IT_TYPE_ID");
            }
        }
    }

    //Methods For ProductCompany Master
    public class ProductCompany
    {
        public string PdCompanyId, PdCompanyName, PdCompanyDesc;   //ProductCompany Master
        public ProductCompany()
        {
        }

        public string ProductCompany_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[YANTRA_LKUP_PRODUCT_COMPANY]", "PRODUCT_COMPANY_NAME", this.PdCompanyName) == false)
            {
                _commandText = string.Format("INSERT INTO [YANTRA_LKUP_PRODUCT_COMPANY] SELECT ISNULL(MAX(PRODUCT_COMPANY_ID),0)+1,'{0}','{1}' FROM [YANTRA_LKUP_PRODUCT_COMPANY]", this.PdCompanyName, this.PdCompanyDesc);
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
                _returnStringMessage = "Company Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string ProductCompany_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[YANTRA_LKUP_PRODUCT_COMPANY]", "PRODUCT_COMPANY_NAME", this.PdCompanyName, "PRODUCT_COMPANY_ID", this.PdCompanyId) == false)
            {
                _commandText = string.Format("UPDATE [YANTRA_LKUP_PRODUCT_COMPANY] SET PRODUCT_COMPANY_NAME='{0}',PRODUCT_COMPANY_DESC='{1}' WHERE PRODUCT_COMPANY_ID={2}", this.PdCompanyName, this.PdCompanyDesc, this.PdCompanyId);
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
                _returnStringMessage = "Company Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string ProductCompany_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[YANTRA_LKUP_PRODUCT_COMPANY]", "PRODUCT_COMPANY_ID", this.PdCompanyId) == true)
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

        public static void ProductCompany_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT PRODUCT_COMPANY_NAME,PRODUCT_COMPANY_ID FROM [YANTRA_LKUP_PRODUCT_COMPANY] ORDER BY PRODUCT_COMPANY_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "PRODUCT_COMPANY_NAME", "PRODUCT_COMPANY_ID");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }
    }

    //Methods For Color Master
    public class ColorMaster
    {
        public string ColorId, ColorName, Desc;
        public ColorMaster()
        {
        }

        public string ColorMaster_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Color_Master]", "Color_Name", this.ColorName) == false)
            {
                _commandText = string.Format("INSERT INTO [Color_Master] SELECT ISNULL(MAX(Color_Id),0)+1,'{0}','{1}' FROM [Color_Master]", this.ColorName, this.Desc);
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
                _returnStringMessage = "Color Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string ColorMaster_Update()
        {
            dbManager.Open();
            //if (IsRecordExists("[Color_Master]", "Color_Name", this.ColorName) == false)
            //{
                _commandText = string.Format("UPDATE [Color_Master] SET Color_Name='{0}',Color_Desc='{1}' WHERE Color_Id={2}", this.ColorName, this.Desc, this.ColorId);
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
            //    _returnStringMessage = "Color Name Already Exists.";
            //}
            return _returnStringMessage;
        }

        public string ColorMaster_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Color_Master]", "Color_Id", this.ColorId) == true)
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

        public static void Color_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Color_Master] ORDER BY Color_Name ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                ColorDropDownListBind(ControlForBind as DropDownList, "Color_Name", "Color_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public int Color_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Color_Master] where Color_Master.Color_Id=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ColorId = dbManager.DataReader["Color_Id"].ToString();
                    this.ColorName = dbManager.DataReader["Color_Name"].ToString();
                    this.Desc = dbManager.DataReader["Color_Desc"].ToString();

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








    //Methods For Table Master
    public class TableMaster
    {
        public string ColorId, ColorName, Desc;
        public TableMaster()
        {
        }

        public string TableMaster_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Table_Master]", "Table_Name", this.ColorName) == false)
            {
                _commandText = string.Format("INSERT INTO [Table_Master] SELECT ISNULL(MAX(Table_Id),0)+1,'{0}','{1}' FROM [Table_Master]", this.ColorName, this.Desc);
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
                _returnStringMessage = "Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string TableMaster_Update()
        {
            dbManager.Open();
            //if (IsRecordExists("[Color_Master]", "Color_Name", this.ColorName) == false)
            //{
            _commandText = string.Format("UPDATE [Table_Master] SET Table_Name='{0}',Table_Location='{1}' WHERE Table_Id={2}", this.ColorName, this.Desc, this.ColorId);
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
            //    _returnStringMessage = "Color Name Already Exists.";
            //}
            return _returnStringMessage;
        }

        public string TableMaster_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Table_Master]", "Table_Id", this.ColorId) == true)
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

        public static void TableMaster_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Table_Master] ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                ColorDropDownListBind(ControlForBind as DropDownList, "Table_Name", "Table_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }



        public int TableMaster_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [TableMaster] where TableMaster.Table_Id=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ColorId = dbManager.DataReader["Table_Id"].ToString();
                    this.ColorName = dbManager.DataReader["Table_Name"].ToString();
                    this.Desc = dbManager.DataReader["Table_Location"].ToString();

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















    public class ItemMaster
    {
        public string ItemCode, ItemName, ItemSpec, Materialtype, ItemtypeId, Uomid, Principalname, Itemseries, Purchasespec, ModelNo, IcId, Brandid, financialyear, rsp, mrp, roundprice, Barcode;
        public string detailscolorid, detailsitemcode;
        public string Itemattachment, attachmentdate;
        public string ItemImage, ItemDate;
        public string itemSpecifcation, Specdate;
        public string ItemMaster_AutoGen()
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(ITEM_CODE),0)+1 FROM YANTRA_ITEM_MAST").ToString());
            return _returnIntValue.ToString();
        }
        public string ItemMaster_Save()
        {
            this.ItemCode = ItemMaster_AutoGen();
            this.Barcode = this.ItemCode;
            dbManager.Open();
            if (IsRecordExists("[YANTRA_ITEM_MAST]", "ITEM_MODEL_NO", this.ModelNo) == false)
            {
                // _commandText = string.Format("INSERT INTO [YANTRA_ITEM_MAST] SELECT ISNULL(MAX(ITEM_CODE),0)+1,'{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}','{8}',{9},{10},'{11}','{12}','{13}' FROM [YANTRA_ITEM_MAST]", this.ItemName, this.ItemSpec, this.Materialtype, this.ItemtypeId, this.Uomid, this.Principalname, this.Itemseries, this.Purchasespec, this.ModelNo, this.IcId, this.Brandid, this.Barcode, this.mrp, this.rsp);

                _commandText = string.Format("INSERT INTO [YANTRA_ITEM_MAST] VALUES ({0},'{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}','{9}',{10},{11},'{12}','{13}','{14}' )", this.ItemCode, this.ItemName, this.ItemSpec, this.Materialtype, this.ItemtypeId, this.Uomid, this.Principalname, this.Itemseries, this.Purchasespec, this.ModelNo, this.IcId, this.Brandid, this.Barcode, this.mrp, this.rsp);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                //_commandText = string.Format("insert into [YANTRA_ITEM_RSP] select isnull(max(Item_Rsp_Id),0)+1,'{0}',{1},'{2}','{3}' from [YANTRA_ITEM_RSP]", this.rsp, this.ItemCode, this.financialyear, DateTime.Now.ToString());
                //_returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _commandText = string.Format("insert into [YANTRA_ITEM_MRP] select isnull(max(Item_Mrp_Id),0)+1,'{0}',{1},'{2}' from [YANTRA_ITEM_MRP]", this.mrp, this.ItemCode, DateTime.Now.ToString("MM/dd/yyyy"));
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                //_commandText = string.Format("insert into [YANTRA_ITEM_ROUNDPRICE] select isnull(max(Item_RoundPrice_Id),0)+1,'{0}',{1},'{2}','{3}' from [YANTRA_ITEM_ROUNDPRICE]", this.roundprice, this.ItemCode, this.financialyear, DateTime.Now.ToString());
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
            }
            else
            {
                _returnStringMessage = "Item Already Exists.";
            }
            return _returnStringMessage;
        }

        public string ItemAttachment_Save()
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("INSERT INTO [YANTRA_ITEM_ATTACHMENTS] SELECT ISNULL(MAX(Item_attachmentId),0)+1,'{0}',{1},'{2}' FROM [YANTRA_ITEM_ATTACHMENTS]", this.Itemattachment, this.ItemCode, this.attachmentdate);
            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            _returnStringMessage = string.Empty;
            return _returnStringMessage;
        }
        public string ItemImage_Save()
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("INSERT INTO [YANTRA_ITEM_IMAGE] SELECT ISNULL(MAX(Item_Image_Id),0)+1,{0},'{1}','{2}' FROM [YANTRA_ITEM_IMAGE]", this.ItemCode, this.ItemImage, this.ItemDate);
            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            _returnStringMessage = string.Empty;
            return _returnStringMessage;
        }
        public string SpecImage_Save()
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("INSERT INTO [YANTRA_ITEM_SPECIFICATION_IMAGE] SELECT ISNULL(MAX(Item_Specification_Id),0)+1,{0},'{1}','{2}' FROM [YANTRA_ITEM_SPECIFICATION_IMAGE]", this.ItemCode, this.ItemSpec, this.Specdate);
            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            _returnStringMessage = string.Empty;
            return _returnStringMessage;
        }

        public int titemcode;
        public string ItemColorDetails_save()
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("INSERT INTO YANTRA_ITEM_COLOR_DETAILS SELECT ISNULL(MAX(ITEM_MASTER_COLOR_DETAIL_ID),0)+1,{0},{1} FROM YANTRA_ITEM_COLOR_DETAILS", this.ItemCode, this.detailscolorid);
            dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

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

        public int ItemColorDetails_Delete(string Itemcode)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("DELETE FROM [YANTRA_ITEM_COLOR_DETAILS] WHERE ITEM_CODE={0}", Itemcode);
            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            return _returnIntValue;
        }

        #region Itemcolor Select

        public DataTable ItemColor_Select(int ItemCode)
        {
            DataTable dtable = new DataTable();
            DataColumn dcol = new DataColumn();
            dcol = new DataColumn("COLOR_ID");
            dtable.Columns.Add(dcol);

            dbManager.Open();
            _commandText = string.Format("SELECT * FROM YANTRA_ITEM_COLOR_DETAILS WHERE  ITEM_CODE={0}", ItemCode);
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            while (dbManager.DataReader.Read())
            {
                DataRow drow = dtable.NewRow();
                drow["COLOR_ID"] = dbManager.DataReader[2].ToString();
                dtable.Rows.Add(drow);
            }
            dbManager.DataReader.Close();
            return dtable;
        }

        #endregion Itemcolor Select

        public string ItemMaster_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [YANTRA_ITEM_MAST] SET ITEM_NAME='{0}',ITEM_SPEC='{1}',ITEM_MATERIAL_TYPE='{2}',IT_TYPE_ID={3},UOM_ID={4},ITEM_PRINCIPAL_NAME='{5}',ITEM_SERIES='{6}',ITEM_PURCHASE_SPEC='{7}',ITEM_MODEL_NO ='{8}',IC_ID ={9},BRAND_ID ={10},ITEM_BARCODE = '{11}',ITEM_MRP='{12}',ITEM_RSP='{13}' WHERE ITEM_CODE={14}", this.ItemName, this.ItemSpec, this.Materialtype, this.ItemtypeId, this.Uomid, this.Principalname, this.Itemseries, this.Purchasespec, this.ModelNo, this.IcId, this.Brandid, this.ItemCode, this.mrp, this.rsp, this.ItemCode);
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

        public string ItemMaster_Delete()
        {
            if (DeleteRecord("[YANTRA_ITEM_MAST]", "ITEM_CODE", this.ItemCode) == true)
            {
                _returnStringMessage = "Data Deleted Successfully";
            }
            else
            {
                _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
            }
            return _returnStringMessage;
        }
        public string UOM, Category, SubCategory, Brand, Rate;
        public int ItemMaster_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [YANTRA_ITEM_MAST],[YANTRA_LKUP_ITEM_TYPE],[YANTRA_LKUP_UOM],[Category_Master],[YANTRA_LKUP_PRODUCT_COMPANY] " +
                            " WHERE [YANTRA_ITEM_MAST].IT_TYPE_ID=[YANTRA_LKUP_ITEM_TYPE].IT_TYPE_ID and " +
                            " [YANTRA_ITEM_MAST].UOM_ID=[YANTRA_LKUP_UOM].UOM_ID and YANTRA_ITEM_MAST.IC_ID = Category_Master.ITEM_CATEGORY_ID AND YANTRA_LKUP_PRODUCT_COMPANY.PRODUCT_COMPANY_ID =YANTRA_ITEM_MAST.BRAND_ID and [YANTRA_ITEM_MAST].ITEM_CODE=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.ItemCode = dbManager.DataReader["ITEM_CODE"].ToString();
                    this.ItemName = dbManager.DataReader["ITEM_NAME"].ToString();
                    this.ItemSpec = dbManager.DataReader["ITEM_SPEC"].ToString();
                    this.Materialtype = dbManager.DataReader["ITEM_MATERIAL_TYPE"].ToString();
                    this.Uomid = dbManager.DataReader["UOM_ID"].ToString();
                    this.ItemtypeId = dbManager.DataReader["IT_TYPE_ID"].ToString();
                    // this.mrp = dbManager.DataReader["ITEM_MRP"].ToString();
                    this.Principalname = dbManager.DataReader["ITEM_PRINCIPAL_NAME"].ToString();
                    this.Itemseries = dbManager.DataReader["ITEM_SERIES"].ToString();
                    this.Purchasespec = dbManager.DataReader["ITEM_PURCHASE_SPEC"].ToString();
                    this.ModelNo = dbManager.DataReader["ITEM_MODEL_NO"].ToString();
                    this.IcId = dbManager.DataReader["IC_ID"].ToString();
                    this.Brandid = dbManager.DataReader["BRAND_ID"].ToString();
                    //  this.financialyear = dbManager.DataReader["FINANCIAL_YEAR"].ToString();
                    //  this.roundprice = dbManager.DataReader["ROUND_PRICE"].ToString();
                    this.rsp = dbManager.DataReader["ITEM_RSP"].ToString();
                    this.UOM = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    this.Category = dbManager.DataReader["ITEM_CATEGORY_NAME"].ToString();
                    this.SubCategory = dbManager.DataReader["IT_TYPE"].ToString();
                    this.Brand = dbManager.DataReader["PRODUCT_COMPANY_NAME"].ToString();
                    this.Rate = dbManager.DataReader["ITEM_MRP"].ToString();

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

        public string Stockqty;
        public int Stock_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [STOCK] where STOCK.ITEM_CODE =" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Stockqty = dbManager.DataReader["QTY"].ToString();
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

        public static void ItemMaster_ModelNoSelect(Control ControlForBind, string MdNo)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT YANTRA_LKUP_COLOR_MAST.COLOUR_ID, YANTRA_LKUP_COLOR_MAST.COLOUR_NAME FROM YANTRA_LKUP_COLOR_MAST INNER JOIN YANTRA_ITEM_COLOR_DETAILS ON YANTRA_LKUP_COLOR_MAST.COLOUR_ID = YANTRA_ITEM_COLOR_DETAILS.COLOR_ID where YANTRA_ITEM_COLOR_DETAILS.ITEM_CODE = " + MdNo);
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "COLOUR_NAME", "COLOUR_ID");
            }
        }

        public static void ItemMaster_RateCalc(string Brand, string percentage, string finan)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            int sizeOfArray = Convert.ToInt32(dbManager.ExecuteScalar(CommandType.Text, "select count(ITEM_CODE) FROM [YANTRA_ITEM_MAST]  WHERE BRAND_ID=" + Brand + "").ToString());
            int[] a = new int[sizeOfArray];
            if (dbManager.Transaction == null)
                dbManager.Open();
            dbManager.ExecuteReader(CommandType.Text, "select ITEM_CODE FROM [YANTRA_ITEM_MAST]  WHERE BRAND_ID=" + Brand + "");
            int i = 0;
            while (dbManager.DataReader.Read())
            {
                a[i] = Convert.ToInt32(dbManager.DataReader["ITEM_CODE"].ToString());
                i++;
            }
            dbManager.DataReader.Close();

            decimal[] c = new decimal[sizeOfArray];
            if (dbManager.Transaction == null)
                dbManager.Open();
            for (int x = 0; x < a.Length; x++)
            {
                dbManager.ExecuteReader(CommandType.Text, "select MRP FROM [YANTRA_ITEM_MAST]  WHERE ITEM_CODE=" + a[x] + "");
                if (dbManager.DataReader.Read())
                {
                    string tempMrp = dbManager.DataReader["MRP"].ToString();
                    decimal flt = Convert.ToDecimal(tempMrp);
                    flt = flt + (flt * int.Parse(percentage) / 100);
                    c[x] = flt;
                }
                dbManager.DataReader.Close();
            }

            if (dbManager.Transaction == null)
                dbManager.Open();
            for (int x = 0; x < c.Length; x++)
            {
                _commandText = string.Format("insert into [YANTRA_ITEM_MRP] select isnull(max(Item_Mrp_Id),0)+1,'{0}',{1},'{2}','{3}' from [YANTRA_ITEM_MRP]", c[x], a[x], finan, DateTime.Now.ToString());
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                _commandText = string.Format("UPDATE [YANTRA_ITEM_MAST] SET MRP='{0}' and FINANCIAL_YEAR = '{1}' WHERE ITEM_CODE={2} ", c[x], finan, a[x]);
                dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            }
        }

        public static void SearchItemBrand_Select(Control ControlForBind, string ItemTypeId)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT top 300 YANTRA_ITEM_MAST.ITEM_CODE, YANTRA_ITEM_MAST.ITEM_MODEL_NO FROM YANTRA_ITEM_MAST INNER JOIN YANTRA_LKUP_PRODUCT_COMPANY ON YANTRA_ITEM_MAST.BRAND_ID = YANTRA_LKUP_PRODUCT_COMPANY.PRODUCT_COMPANY_ID  and YANTRA_LKUP_PRODUCT_COMPANY.PRODUCT_COMPANY_ID =" + ItemTypeId + " order by YANTRA_ITEM_MAST.ITEM_MODEL_NO asc ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "ITEM_MODEL_NO", "ITEM_CODE");
            }
        }

        public static void ItemMasterModel_Select(Control ControlForBind, string Modelno)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT top 300 YANTRA_ITEM_MAST.ITEM_CODE, YANTRA_ITEM_MAST.ITEM_MODEL_NO FROM YANTRA_ITEM_MAST where YANTRA_ITEM_MAST.ITEM_CODE  =" + Modelno + " order by YANTRA_ITEM_MAST.ITEM_MODEL_NO asc ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "ITEM_MODEL_NO", "ITEM_CODE");
            }
        }
    }




    //Methods For Currency Master Form
    public class Currency
    {
        public string CurId, CurName, CurFullName, CurDesc;   //Currency Master
        public Currency()
        { }

        public string Currency_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Currency_Master]", "CURRENCY_NAME", this.CurName) == false)
            {
                _commandText = string.Format("INSERT INTO [Currency_Master] SELECT ISNULL(MAX(CURRENCY_ID),0)+1,'{0}','{1}','{2}' FROM [Currency_Master]", this.CurName,this.CurFullName, this.CurDesc);
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
                _returnStringMessage = "Currency Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Currency_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Currency_Master] SET CURRENCY_NAME='{0}',CURRENCY_FULL_NAME='{1}',CURRENCY_DESC='{2}' WHERE CURRENCY_ID={3}", this.CurName, this.CurFullName, this.CurDesc,this.CurDesc);
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

        public string Currency_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Currency_Master]", "CURRENCY_ID", this.CurId) == true)
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

        public static void Currency_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT CURRENCY_NAME,CURRENCY_ID FROM [Currency_Master] where CURRENCY_NAME is not null");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "CURRENCY_NAME", "CURRENCY_ID");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public int Currency_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Currency_Master] where Currency_Master.CURRENCY_ID =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.CurId = dbManager.DataReader["CURRENCY_ID"].ToString();
                    this.CurName = dbManager.DataReader["CURRENCY_NAME"].ToString();
                    this.CurFullName = dbManager.DataReader["CURRENCY_FULL_NAME"].ToString();
                    this.CurDesc = dbManager.DataReader["CURRENCY_DESC"].ToString();
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



    //Methods For Quatation Changables Master Form
    public class QuatationChangables
    {
        public string  Qcid, EuroPrice, Freight, Customes, Insurance,Clearance,Wastage,Wallplugs,Silicon,Maskingtape,BackorRod,FabricationPersqf,FabricationPersqm,Installationpersft,InstallationPersqm,Margin,Siliconwidht,SiliconDepth;   // Master
        public QuatationChangables()
        { }

        public string QuatationChangables_Save()
        {
            dbManager.Open();

            _commandText = string.Format("INSERT INTO [Quatation_Changeables] SELECT ISNULL(MAX(QC_id),0)+1,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}' FROM [Quatation_Changeables]", this.EuroPrice, this.Freight,this.Customes,this.Insurance,this.Clearance,this.Wastage,this.Wallplugs,this.Silicon,this.Maskingtape,this.BackorRod,this.FabricationPersqf,this.FabricationPersqm,this.Installationpersft,this.InstallationPersqm,this.Margin,this.Siliconwidht,this.SiliconDepth);
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

        public string QuatationChangables_Update()
        {
            dbManager.Open();
            _commandText = string.Format("UPDATE [Quatation_Changeables] SET Euro_Price='{0}',Freight='{1}',Customs='{2}',Insurance='{3}',Clearance='{4}',Wastage='{5}',WallPlugs='{6}',Silicon='{7}',Maskingtape='{8}',BackorRod='{9}',FabricationPerSft='{10}',FabricationPerSqm='{11}',InstallationPerSft='{12}',InstallationPerSqm='{13}',Margin='{14}',Silicon_Width='{15}',Silicon_Depth='{16}' ", this.EuroPrice, this.Freight, this.Customes, this.Insurance, this.Clearance, this.Wastage, this.Wallplugs, this.Silicon, this.Maskingtape, this.BackorRod, this.FabricationPersqf, this.FabricationPersqm, this.Installationpersft, this.InstallationPersqm, this.Margin, this.Siliconwidht, this.SiliconDepth);
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


        public int QuatationChangables_Select()
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Quatation_Changeables] where QC_id = '1' ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.EuroPrice = dbManager.DataReader["Euro_Price"].ToString();
                    this.Freight = dbManager.DataReader["Freight"].ToString();
                    this.Customes = dbManager.DataReader["Customs"].ToString();


                    this.Insurance = dbManager.DataReader["Insurance"].ToString();
                    this.Clearance = dbManager.DataReader["Clearance"].ToString();
                    this.Wastage = dbManager.DataReader["Wastage"].ToString();

                    this.Wallplugs = dbManager.DataReader["WallPlugs"].ToString();
                    this.Silicon = dbManager.DataReader["Silicon"].ToString();
                    this.Maskingtape = dbManager.DataReader["Maskingtape"].ToString();

                    this.BackorRod = dbManager.DataReader["BackorRod"].ToString();
                    this.FabricationPersqf = dbManager.DataReader["FabricationPerSft"].ToString();
                    this.FabricationPersqm = dbManager.DataReader["FabricationPerSqm"].ToString();

                    this.Installationpersft = dbManager.DataReader["InstallationPerSft"].ToString();
                    this.InstallationPersqm = dbManager.DataReader["InstallationPerSqm"].ToString();
                    this.Margin = dbManager.DataReader["Margin"].ToString();

                    this.SiliconDepth = dbManager.DataReader["Silicon_Width"].ToString();
                    this.Siliconwidht = dbManager.DataReader["Silicon_Depth"].ToString();
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
                dbManager.Dispose();
            }
            return _returnIntValue;
        }
    }




    //Methods For Department Master Form
    public class Department
    {
        public string DeptId, DeptName, DeptHead, DeptDesc,empid;   //Department Master
        public Department()
        { }

        public string Department_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Department_Master]", "DEPT_NAME", this.DeptName) == false)
            {
                _commandText = string.Format("INSERT INTO [Department_Master] SELECT ISNULL(MAX(DEPT_ID),0)+1,'{0}','{1}',{2} FROM [Department_Master]", this.DeptName, this.DeptDesc,this.empid);
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
                _returnStringMessage = "Department Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Department_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Department_Master]", "DEPT_NAME", this.DeptName, "DEPT_ID", this.DeptId) == false)
            {
                _commandText = string.Format("UPDATE [Department_Master] SET DEPT_NAME='{0}',DEPT_DESC='{1}',DEPT_HEAD={2} WHERE DEPT_ID={3}", this.DeptName, this.DeptDesc,this.empid, this.DeptId);
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
                _returnStringMessage = "Department Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Department_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Department_Master]", "DEPT_ID", this.DeptId) == true)
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

        public static void Department_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT DEPT_NAME,DEPT_ID FROM [Department_Master] where DEPT_NAME is not null");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "DEPT_NAME", "DEPT_ID");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public int Department_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Department_Master] where Department_Master.DEPT_ID =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.DeptId = dbManager.DataReader["DEPT_ID"].ToString();
                    this.DeptName = dbManager.DataReader["DEPT_NAME"].ToString();
                    this.DeptDesc = dbManager.DataReader["DEPT_DESC"].ToString();
                    this.empid = dbManager.DataReader["DEPT_HEAD"].ToString();

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

    //Methods For Designation Master Form
    public class Designation
    {
        public string DesgId, DesgName, DesgDesc;  //Desination Master
        public Designation()
        { }

        public string Designation_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Designation_Master]", "DESG_NAME", this.DesgName) == false)
            {
                _commandText = string.Format("INSERT INTO [Designation_Master] SELECT ISNULL(MAX(DESG_ID),0)+1,'{0}','{1}' FROM [Designation_Master]", this.DesgName, this.DesgDesc);
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
                _returnStringMessage = "Designation Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Designation_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Designation_Master]", "DESG_NAME", this.DesgName, "DESG_ID", this.DesgId) == false)
            {
                _commandText = string.Format("UPDATE [Designation_Master] SET DESG_NAME='{0}',DESG_DESC='{1}' WHERE DESG_ID={2}", this.DesgName, this.DesgDesc, this.DesgId);
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
                _returnStringMessage = "Designation Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Designation_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Designation_Master]", "DESG_ID", this.DesgId) == true)
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

        public static void Designation_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT  * FROM [Designation_Master] ORDER BY DESG_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "DESG_NAME", "DESG_ID");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public int Designation_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Designation_Master] where Designation_Master.DESG_ID =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.DesgId = dbManager.DataReader["DESG_ID"].ToString();
                    this.DesgName = dbManager.DataReader["DESG_NAME"].ToString();
                    this.DesgDesc = dbManager.DataReader["DESG_DESC"].ToString();

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

    //Methods For Regional Master Form
    public class RegionalMaster
    {
        public string RegId, RegName, RegDesc;        // Regional Master
        public RegionalMaster()
        { }

        public string RegionalMaster_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Regional_Master]", "REG_NAME", this.RegName) == false)
            {
                _commandText = string.Format("INSERT INTO [Regional_Master] SELECT ISNULL(MAX(REG_ID),0)+1,'{0}','{1}' FROM [Regional_Master]", this.RegName, this.RegDesc);
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
                _returnStringMessage = "Regional Code Already Exists.";
            }
            return _returnStringMessage;
        }

        public string RegionalMaster_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Regional_Master]", "REG_NAME", this.RegName, "REG_ID", this.RegId) == false)
            {
                _commandText = string.Format("UPDATE [Regional_Master] SET REG_NAME='{0}',REG_DESC='{1}' WHERE REG_ID={2}", this.RegName, this.RegDesc, this.RegId);
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
                _returnStringMessage = "Regional Code Already Exists.";
            }
            return _returnStringMessage;
        }

        public string RegionalMaster_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Regional_Master]", "REG_ID", this.RegId) == true)
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

        public static void RegionalMaster_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Regional_Master] ORDER BY REG_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "REG_NAME", "REG_ID");
            }
        }

        public int Region_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Regional_Master] where Regional_Master.REG_ID =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.RegId = dbManager.DataReader["REG_ID"].ToString();
                    this.RegName = dbManager.DataReader["REG_NAME"].ToString();
                    this.RegDesc = dbManager.DataReader["REG_DESC"].ToString();

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

    //Methods For Enquiry Mode Form
    public class EnquiryMode
    {
        public string EnqmId, EnqmName, EnqmDesc;  //Equiry Mode
        public EnquiryMode()
        { }

        public string EnquiryMode_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Enquiry_Mode]", "ENQM_NAME", this.EnqmName) == false)
            {
                _commandText = string.Format("INSERT INTO [Enquiry_Mode] SELECT ISNULL(MAX(ENQM_ID),0)+1,'{0}','{1}' FROM [Enquiry_Mode]", this.EnqmName, this.EnqmDesc);
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
                _returnStringMessage = "Enquiry  Mode Already Exists.";
            }
            return _returnStringMessage;
        }

        public string EnquiryMode_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Enquiry_Mode]", "ENQM_NAME", this.EnqmName, "ENQM_ID", this.EnqmId) == false)
            {
                _commandText = string.Format("UPDATE [Enquiry_Mode] SET ENQM_NAME='{0}',ENQM_DESC='{1}' WHERE ENQM_ID={2}", this.EnqmName, this.EnqmDesc, this.EnqmId);
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
                _returnStringMessage = "Enquiry Mode Already Exists.";
            }
            return _returnStringMessage;
        }

        public string EnquiryMode_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Enquiry_Mode]", "ENQM_ID", this.EnqmId) == true)
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

        public static void EnquiryMode_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Enquiry_Mode] ORDER BY ENQM_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "ENQM_NAME", "ENQM_ID");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public int Enquiry_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Enquiry_Mode] where Enquiry_Mode.ENQM_ID =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.EnqmId = dbManager.DataReader["ENQM_ID"].ToString();
                    this.EnqmName = dbManager.DataReader["ENQM_NAME"].ToString();
                    this.EnqmDesc = dbManager.DataReader["ENQM_DESC"].ToString();

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

    public class Bankmaster
    {
        public string id, name, details, ifsc, accno;
        public Bankmaster()
        { }

        public string Bankmaster_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[BANK]", "BANK_NAME", this.name) == false)
            {
                _commandText = string.Format("INSERT INTO [BANK] SELECT ISNULL(MAX(BANK_ID),0)+1,'{0}','{1}','{2}','{3}' FROM [BANK]", this.name, this.details, this.accno, this.ifsc);
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
                _returnStringMessage = "Bank Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Bank_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [BANK] SET BANK_NAME='{0}',DETAILS='{1}',ACCOUNT_NO='{2}',IFSC='{3}' WHERE BANK_ID={4}", this.name, this.details, this.accno, this.ifsc, this.id);
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

        public string BANK_Delete()
        {
            if (DeleteRecord("[BANK]", "BANK_ID", this.id) == true)
            {
                _returnStringMessage = "Data Deleted Successfully";
            }
            else
            {
                _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
            }
            return _returnStringMessage;
        }

        public static void BANKMaster_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [BANK] ORDER BY BANK_ID");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "BANK_NAME", "BANK_ID");
            }
        }
        public int Bank_Select(string SFDID)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("SELECT * FROM [BANK] where [BANK].BANK_ID ='" + SFDID + "' ORDER BY BANK_ID DESC ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (dbManager.DataReader.Read())
            {
                this.id = dbManager.DataReader["BANK_ID"].ToString();
                this.name = dbManager.DataReader["BANK_NAME"].ToString();
                this.details = dbManager.DataReader["DETAILS"].ToString();
                this.accno = dbManager.DataReader["ACCOUNT_NO"].ToString();
                this.ifsc = dbManager.DataReader["IFSC"].ToString();

                _returnIntValue = 1;
            }
            else
            {
                _returnIntValue = 0;
            }
            return _returnIntValue;
        }
    }

    #region UserMaster Class

    public class UserMaster
    {
        #region UserMaster Save

        public string UserMaster_Save(string UserName, string Password)
        {
            dbManager.Open();
            if (Masters.IsRecordExists("SELECT COUNT(*) FROM User_Master WHERE UserName='" + UserName + "'") == false)
            {
                _commandText = string.Format("INSERT INTO User_Master SELECT ISNULL(MAX(UserId),0)+1,'{0}','{1}','{2}','{3}' FROM User_Master", UserName, Password, "0", "0");
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing";
                }
                else
                {
                    _returnStringMessage = "Record Inserted";
                }
            }
            else
            {
                _returnStringMessage = "User Name Already  Exists";
            }
            //dbManager.Dispose();
            return _returnStringMessage;
        }

        #endregion UserMaster Save

        #region UserMaster Update

        //public string UserMaster_Update(int UserId, string UserName, string OldPassword, string NewPassword, string GridViewUserName)
        //{
        //    dbManager.Open();
        //    if (Masters.IsRecordExists("SELECT COUNT(*) FROM UTY_USER_MASTER WHERE PassWord='" + OldPassword + "'and UserId=" + UserId) == true)
        //    {
        //        //if (UserName != GridViewUserName)
        //        //{
        //        //    if (Masters.IsRecordExists("SELECT COUNT(*) FROM UTY_USER_MASTER WHERE UserName='" + UserName + "'") == false)
        //        //    {
        //        //        _commandText = string.Format("UPDATE UTY_USER_MASTER SET UserName='" + UserName + "',PassWord='" + NewPassword + "'WHERE UserId=" + UserId);
        //        //        _returnStringMessage = string.Empty;
        //        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        //        _commandText = string.Format("UPDATE YANTRA_EMPLOYEE_MAST SET EMP_USERNAME='" + UserName + "',EMP_PASSWORD='" + NewPassword + "'WHERE EMP_USERNAME=" + UserName);
        //        //        _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //        //        if (_returnIntValue < 0 || _returnIntValue == 0)
        //        //        {
        //        //            _returnStringMessage = "Some Data Missing..";
        //        //        }
        //        //        else
        //        //        {
        //        //            _returnStringMessage = "Updated Successfully";
        //        //        }

        //        //    }
        //        //    else
        //        //    {
        //        //        _returnStringMessage = "User Name Already Exists";
        //        //    }
        //        //}
        //        //else
        //        //{
        //            _commandText = string.Format("UPDATE UTY_USER_MASTER SET UserName='" + UserName + "',PassWord='" + NewPassword + "'WHERE UserId=" + UserId);
        //            _returnStringMessage = string.Empty;
        //            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        //            if (_returnIntValue < 0 || _returnIntValue == 0)
        //            {
        //                _returnStringMessage = "Some Data Missing..";
        //            }
        //            else
        //            {
        //                _returnStringMessage = "Updated Successfully";
        //            }

        //        //}
        //    }
        //    else
        //    {
        //        _returnStringMessage = "Your Old Password is not correct..";
        //    }
        //     dbManager.Dispose();
        //    return _returnStringMessage;

        //}

        public string UserMaster_Update(int UserId, string UserName, string OldPassword, string NewPassword)
        {
            dbManager.Open();
            if (Masters.IsRecordExists("SELECT COUNT(*) FROM User_Master WHERE PassWord='" + OldPassword + "'and UserId=" + UserId) == true)
            {
                _commandText = string.Format("UPDATE User_Master SET UserName='" + UserName + "',PassWord='" + NewPassword + "'WHERE UserId=" + UserId);
                _returnStringMessage = string.Empty;
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing..";
                }
                else
                {
                    _returnStringMessage = "Updated Successfully";
                }
            }
            else
            {
                _returnStringMessage = "Your Old Password is not correct..";
            }
            dbManager.Dispose();
            return _returnStringMessage;
        }

        #endregion UserMaster Update

        public string deleteedit_Update(int userid, string edit, string delete)
        {
            dbManager.Open();
            _commandText = string.Format("UPDATE User_Master SET IsDelete='" + delete + "',IsEdit='" + edit + "'WHERE Emp_Id=" + userid);
            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            if (_returnIntValue < 0 || _returnIntValue == 0)
            {
                _returnStringMessage = "Some Data Missing..";
            }
            else
            {
                _returnStringMessage = "Updated Successfully";
            }
            dbManager.Dispose();
            return _returnStringMessage;
        }

        #region UserPermissions Save

        public void UserPermissions_Save(int UserId, string UserPermissions)
        {
            dbManager.Open();
            _commandText = string.Format("INSERT INTO User_Permissions VALUES ({0},'{1}')", UserId, UserPermissions);
            dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        }

        #endregion UserPermissions Save

        #region UserPermisssions_Delete

        public void UserPermissions_Delete(int UserId)
        {
            dbManager.Open();
            _commandText = string.Format("DELETE FROM User_Permissions WHERE UserId=" + UserId);
            dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        }

        #endregion UserPermisssions_Delete

        #region UserPermissions Select

        public DataTable UserPermissions_Select(int UserId)
        {
            DataTable dtable = new DataTable();
            DataColumn dcol = new DataColumn();
            dcol = new DataColumn("Permissions");
            dtable.Columns.Add(dcol);

            dbManager.Open();
            _commandText = string.Format("SELECT * FROM User_Permissions WHERE UserId={0}", UserId);
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            while (dbManager.DataReader.Read())
            {
                DataRow drow = dtable.NewRow();
                drow["Permissions"] = dbManager.DataReader[1].ToString();
                dtable.Rows.Add(drow);
            }
            dbManager.DataReader.Close();
            return dtable;
        }

        #endregion UserPermissions Select

        #region UserName & UserPermissions Delete

        public string UserName_UserPermissions_Delete(int UserId)
        {
            if (Masters.DeleteRecord("User_Master", "UserId", UserId.ToString()) == true)
            {
                Masters.DeleteRecord("User_Permissions", "UserId", UserId.ToString());
                _returnStringMessage = "Data Deleted Successfully..";
            }
            else
            {
                _returnStringMessage = "Some Data Missing..";
            }
            return _returnStringMessage;
          //  dbManager.Dispose();
        }

        #endregion UserName & UserPermissions Delete

        public string edit, delete, uname;
        public int editdelete_Select(string userid)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("SELECT * FROM [User_Master] where UserId='" + userid + "'  ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (dbManager.DataReader.Read())
            {
                this.uname = dbManager.DataReader["UserName"].ToString();
                this.edit = dbManager.DataReader["IsEdit"].ToString();
                this.delete = dbManager.DataReader["IsDelete"].ToString();

                _returnIntValue = 1;
            }
            else
            {
                _returnIntValue = 0;
            }
            return _returnIntValue;
        }

        public static void UserMaster_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [User_Master] ORDER BY UserId");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "UserName", "UserId");
            }
        }
    }

    #endregion UserMaster Class

    #region IsRecordExistsWithWhere

    public static bool IsRecordExists(string command)
    {
        int _returnIntValue;
        bool check = false;
        _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, command).ToString());
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

    #endregion IsRecordExistsWithWhere

    #region DDL Bind with Select

    public static void DDLBindWithSelect(DropDownList ddlname, string command)
    {
        dbManager.Open();
        dbManager.ExecuteReader(CommandType.Text, command);
        ddlname.Items.Clear();
        ddlname.Items.Add(new ListItem("--SELECT--", "SELECT"));
        while (dbManager.DataReader.Read())
        {
            ddlname.Items.Add(new ListItem(dbManager.DataReader[1].ToString(), dbManager.DataReader[0].ToString()));
        }
    }

    #endregion DDL Bind with Select

    #region ChangePassWord Class

    public class ChangePassword
    {
        #region ChangePassword Update

        public string ChangePassword_Update(int UserId, string OldPassword, string NewPassword)
        {
            dbManager.Open();
            if (Masters.IsRecordExists("SELECT COUNT(*) FROM User_Master WHERE PassWord='" + OldPassword + "'and Emp_Id=" + UserId) == true)
            {
                _commandText = string.Format("UPDATE User_Master SET PassWord='" + NewPassword + "'WHERE Emp_Id=" + UserId);
                _returnStringMessage = string.Empty;
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                if (_returnIntValue < 0 || _returnIntValue == 0)
                {
                    _returnStringMessage = "Some Data Missing..";
                }
                else
                {
                    _returnStringMessage = "Updated Successfully";
                }
            }
            else
            {
                _returnStringMessage = "Your Old Password is not correct..";
            }
            return _returnStringMessage;
        }

        #endregion ChangePassword Update
    }

    #endregion ChangePassWord Class

    //Methods For Company Profile Form
    //public class CompanyProfile
    //{
    //    public string CPCompanyId, CPFullName, CPShortName, CPAddress, CPContactNo1, CPFaxNo, CPContactNo2, CPEmail, CPTelexNo, CPAPGSTNo, CPCSTNo, CPECCNo, CPVATNo, CPPANNo, CPEstYear;
    //    public string CPCFYear, CPCPONo, CPCINo, CPCDCNo, CPYearStartDate, CPYearEndDate, CPInvoicePrefix, CPInvoiceSuffix, CPPOPrefix, CPPOSuffix, CPDCPrefix, CPDCSuffix, CPLogo, locid;
    //    public CompanyProfile()
    //    { }

    //    public string CompanyProfile_Save()
    //    {
    //        dbManager.Open();
    //        _commandText = string.Format("INSERT INTO [YANTRA_COMP_PROFILE] SELECT ISNULL(MAX(CP_ID),0)+1,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}' FROM [YANTRA_COMP_PROFILE]", this.CPFullName, this.CPShortName, this.CPAddress, this.CPContactNo1, this.CPFaxNo, this.CPContactNo2, this.CPEmail, this.CPTelexNo, this.CPAPGSTNo, this.CPCSTNo, this.CPECCNo, this.CPVATNo, this.CPPANNo, this.CPEstYear, this.CPCFYear, this.CPCPONo, this.CPCINo, this.CPCDCNo, Convert.ToDateTime(this.CPYearStartDate), Convert.ToDateTime(this.CPYearEndDate), this.CPInvoicePrefix, this.CPInvoiceSuffix, this.CPPOPrefix, this.CPPOSuffix, this.CPDCPrefix, this.CPDCSuffix, this.CPLogo, this.locid);
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

    //    public string CompanyProfile_Update()
    //    {
    //        dbManager.Open();
    //        _commandText = string.Format("UPDATE [YANTRA_COMP_PROFILE] SET CP_FULL_NAME='{0}',CP_SHORT_NAME='{1}',CP_ADDRESS='{2}',CP_CONTACT_NO1='{3}',CP_FAXNO='{4}',CP_CONTACT_NO2='{5}',CP_EMAIL='{6}',CP_TELEX_NO='{7}',CP_APGST_NO='{8}',CP_CST_NO='{9}',CP_ECC_NO='{10}',CP_VAT_NO='{11}',CP_PAN_NO='{12}',CP_EST_YEAR='{13}' " +
    //              ",CP_CF_YEAR='{14}' WHERE CP_ID='1'",
    //              this.CPFullName, this.CPShortName, this.CPAddress, this.CPContactNo1, this.CPFaxNo, this.CPContactNo2, this.CPEmail, this.CPTelexNo, this.CPAPGSTNo, this.CPCSTNo, this.CPECCNo, this.CPVATNo, this.CPPANNo, this.CPEstYear,
    //              this.CPCFYear,this.CPCompanyId);

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

    //    public string CompanyProfile_Delete()
    //    {
    //        Masters.BeginTransaction();
    //        if (DeleteRecord("[YANTRA_COMP_PROFILE]", "CP_ID", this.CPCompanyId) == true)
    //        {
    //            Masters.CommitTransaction();
    //            _returnStringMessage = "Data Deleted Successfully";

    //        }
    //        else
    //        {
    //            Masters.RollBackTransaction();
    //            _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";

    //        }
    //        return _returnStringMessage;
    //    }

    //    public int CompanyProfile_Select()
    //    {
    //        dbManager.Open();
    //        _commandText = string.Format("SELECT * FROM [YANTRA_COMP_PROFILE]");
    //        dbManager.ExecuteReader(CommandType.Text, _commandText);
    //        if (dbManager.DataReader.Read())
    //        {
    //            this.CPFullName = dbManager.DataReader["CP_FULL_NAME"].ToString();
    //            this.CPShortName = dbManager.DataReader["CP_SHORT_NAME"].ToString();
    //            this.CPAddress = dbManager.DataReader["CP_ADDRESS"].ToString();
    //            this.CPContactNo1 = dbManager.DataReader["CP_CONTACT_NO1"].ToString();
    //            this.CPFaxNo = dbManager.DataReader["CP_FAXNO"].ToString();
    //            this.CPContactNo2 = dbManager.DataReader["CP_CONTACT_NO2"].ToString();
    //            this.CPEmail = dbManager.DataReader["CP_EMAIL"].ToString();
    //            this.CPTelexNo = dbManager.DataReader["CP_TELEX_NO"].ToString();
    //            this.CPAPGSTNo = dbManager.DataReader["CP_APGST_NO"].ToString();
    //            this.CPCSTNo = dbManager.DataReader["CP_CST_NO"].ToString();
    //            this.CPECCNo = dbManager.DataReader["CP_ECC_NO"].ToString();
    //            this.CPVATNo = dbManager.DataReader["CP_VAT_NO"].ToString();
    //            this.CPPANNo = dbManager.DataReader["CP_PAN_NO"].ToString();
    //            this.CPEstYear = Convert.ToDateTime(dbManager.DataReader["CP_EST_YEAR"].ToString()).ToString("yyyy");
    //            this.CPCFYear = dbManager.DataReader["CP_CF_YEAR"].ToString();
    //            //this.CPCPONo = dbManager.DataReader["CP_CPO_NO"].ToString();
    //            //this.CPCINo = dbManager.DataReader["CP_CI_NO"].ToString();
    //            //this.CPCDCNo = dbManager.DataReader["CP_CDC_NO"].ToString();
    //            //this.CPYearStartDate = Convert.ToDateTime(dbManager.DataReader["CP_YEAR_STARTDATE"].ToString()).ToString("dd/MM/yyyy");
    //           //this.CPInvoicePrefix = dbManager.DataReader["CP_INVOICE_PREFIX"].ToString();
    //           // this.CPInvoiceSuffix = dbManager.DataReader["CP_INVOICE_SUFFIX"].ToString();
    //           // this.CPPOPrefix = dbManager.DataReader["CP_PO_PREFIX"].ToString();
    //           // this.CPPOSuffix = dbManager.DataReader["CP_PO_SUFFIX"].ToString();
    //           // this.CPDCPrefix = dbManager.DataReader["CP_DC_PREFIX"].ToString();
    //           // this.CPDCSuffix = dbManager.DataReader["CP_DC_SUFFIX"].ToString();
    //           // this.CPLogo = dbManager.DataReader["CP_LOGO"].ToString();
    //           // this.locid = dbManager.DataReader["locid"].ToString();          this.CPYearEndDate = Convert.ToDateTime(dbManager.DataReader["CP_YEAR_ENDDATE"].ToString()).ToString("dd/MM/yyyy");
    //            //////this.CPYearStartDate = dbManager.DataReader["CP_YEAR_STARTDATE"].ToString();
    //            //////this.CPYearEndDate = dbManager.DataReader["CP_YEAR_ENDDATE"].ToString();

    //            _returnIntValue = 1;
    //        }
    //        else
    //        {
    //            _returnIntValue = 0;
    //        }
    //        dbManager.DataReader.Close();
    //        return _returnIntValue;
    //    }

    //    public static void Company_Select(Control ControlForBind)
    //    {
    //        dbManager.Open();
    //        //_commandText = string.Format("SELECT * FROM [YANTRA_COMP_PROFILE] ORDER BY CP_FULL_NAME");
    //        _commandText = string.Format("SELECT distinct(a.CP_ID), a.CP_FULL_NAME + ',' + b.locname AS COMP_NAME FROM YANTRA_COMP_PROFILE AS a INNER JOIN location_tbl AS b ON a.locid = b.locid");

    //        dbManager.ExecuteReader(CommandType.Text, _commandText);
    //        if (ControlForBind is DropDownList)
    //        {
    //            //DropDownListBind(ControlForBind as DropDownList, "CP_FULL_NAME", "CP_ID");
    //            DropDownListBind(ControlForBind as DropDownList, "COMP_NAME", "CP_ID");
    //        }
    //        else if (ControlForBind is GridView)
    //        {
    //            GridViewBind(ControlForBind as GridView);
    //        }
    //    }

    //}

    public class CompanyProfile
    {
        public string Cpid, fullname, shortname, ceo, foundataiondate, phoneoffice, email, mobile, faxno, address, gst, cfyear;

        public string CompanyProfile_Save()
        {
            //this.Cpid = AutoGenMaxId("[Company_Profile]", "CP_ID");
            dbManager.Open();
            _commandText = string.Format("INSERT INTO [Company_Profile] SELECT ISNULL(MAX(CP_ID),0)+1,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}' FROM [Company_Profile]", this.fullname, this.shortname, this.ceo, this.foundataiondate, this.phoneoffice, this.email, this.mobile, this.faxno, this.address, this.gst, this.cfyear);
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

        public string CompanyProfile_Update()
        {
            dbManager.Open();
            _commandText = string.Format("UPDATE [Company_Profile] SET CP_FULL_NAME='{0}',CP_SHORT_NAME='{1}',CP_CEO='{2}',CP_FOUNDATIONDATE='{3}',CP_PHONE_OFFICE='{4}',CP_EMAIL='{5}',CP_MOBILE='{6}',CP_FAXNO='{7}',CP_ADDRESS='{8}',CP_GST='{9}',CP_CF_YEAR='{10}' WHERE CP_ID='1'",
                  this.fullname, this.shortname, this.ceo, this.foundataiondate, this.phoneoffice, this.email, this.mobile, this.faxno, this.address, this.gst, this.cfyear, this.Cpid);

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

        public int CompanyProfile_Select(string Code)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Company_Profile] where CP_ID = '" + Code + "'");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (dbManager.DataReader.Read())
            {
                this.fullname = dbManager.DataReader["CP_FULL_NAME"].ToString();
                this.shortname = dbManager.DataReader["CP_SHORT_NAME"].ToString();
                this.ceo = dbManager.DataReader["CP_CEO"].ToString();
                this.foundataiondate = Convert.ToDateTime(dbManager.DataReader["CP_FOUNDATIONDATE"].ToString()).ToString("yyyy");
                this.phoneoffice = dbManager.DataReader["CP_PHONE_OFFICE"].ToString();
                this.email = dbManager.DataReader["CP_EMAIL"].ToString();
                this.mobile = dbManager.DataReader["CP_MOBILE"].ToString();
                this.faxno = dbManager.DataReader["CP_FAXNO"].ToString();
                this.address = dbManager.DataReader["CP_ADDRESS"].ToString();
                this.gst = dbManager.DataReader["CP_GST"].ToString();
                this.cfyear = dbManager.DataReader["CP_CF_YEAR"].ToString();

                _returnIntValue = 1;
            }
            else
            {
                _returnIntValue = 0;
            }
            dbManager.DataReader.Close();
            return _returnIntValue;
        }

        public static void Company_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT CP_FULL_NAME,CP_ID FROM [Company_Profile] ORDER BY CP_FULL_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "CP_FULL_NAME", "CP_ID");
            }
        }

        public string Company_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Company_Profile]", "CP_ID", this.Cpid) == true)
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
    }

    //Methods For Despatch Mode Form
    public class DespatchMode
    {
        public string DespmId, DespmName, DespmDesc;
        public DespatchMode()
        { }

        public string DespatchMode_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[DispatchMode_Master]", "DESPM_NAME", this.DespmName) == false)
            {
                _commandText = string.Format("INSERT INTO [DispatchMode_Master] SELECT ISNULL(MAX(DESPM_ID),0)+1,'{0}','{1}' FROM [DispatchMode_Master]", this.DespmName, this.DespmDesc);
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
                _returnStringMessage = "Despatch Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string DespatchMode_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[DispatchMode_Master]", "DESPM_NAME", this.DespmName) == false)
            {
                _commandText = string.Format("UPDATE [DispatchMode_Master] SET DESPM_NAME='{0}',DESPM_DESC='{1}' WHERE DESPM_ID={2}", this.DespmName, this.DespmDesc, this.DespmId);
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
                _returnStringMessage = "Despatch Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string DespatchMode_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[DispatchMode_Master]", "DESPM_ID", this.DespmId) == true)
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

        public static void DespatchMode_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT DESPM_NAME,DESPM_ID FROM [DispatchMode_Master] ORDER BY DESPM_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "DESPM_NAME", "DESPM_ID");
            }
        }

        public int Despatch_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [DispatchMode_Master] where DispatchMode_Master.DESPM_ID =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.DespmId = dbManager.DataReader["DESPM_ID"].ToString();
                    this.DespmName = dbManager.DataReader["DESPM_NAME"].ToString();
                    this.DespmDesc = dbManager.DataReader["DESPM_DESC"].ToString();

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

    //Methods For MaterialType Form
    public class MaterialType
    {
        public string Mtid, Name, Desc;
        public MaterialType()
        { }

        public string MaterialType_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Material_Type]", "Material_Type", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [Material_Type] SELECT ISNULL(MAX(MaterialType_Id),0)+1,'{0}','{1}' FROM [Material_Type]", this.Name, this.Desc);
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
                _returnStringMessage = "Despatch Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string MaterialType_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Material_Type]", "Material_Type", this.Name) == false)
            {
                _commandText = string.Format("UPDATE [Material_Type] SET Material_Type='{0}',Material_Description='{1}' WHERE MaterialType_Id={2}", this.Name, this.Desc, this.Mtid);
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
                _returnStringMessage = "Material Type Already Exists.";
            }
            return _returnStringMessage;
        }

        public string MaterialType_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Material_Type]", "MaterialType_Id", this.Mtid) == true)
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

        public static void MaterialType_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Material_Type,MaterialType_Id FROM [Material_Type] ORDER BY Material_Type");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Material_Type", "MaterialType_Id");
            }
        }

        public int MaterialType_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Material_Type] where Material_Type.MaterialType_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Mtid = dbManager.DataReader["MaterialType_Id"].ToString();
                    this.Name = dbManager.DataReader["Material_Type"].ToString();
                    this.Desc = dbManager.DataReader["Material_Description"].ToString();

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

    //Methods For PackingMaterial Form
    public class PackingMaterial
    {
        public string Mtid, Name, Desc;
        public PackingMaterial()
        { }

        public string PackingMaterial_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Packing_Material]", "Packing_Material", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [Packing_Material] SELECT ISNULL(MAX(PackingMaterial_Id),0)+1,'{0}','{1}' FROM [Packing_Material]", this.Name, this.Desc);
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
                _returnStringMessage = "Packing Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string PackingMaterial_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Packing_Material]", "Packing_Material", this.Name) == false)
            {
                _commandText = string.Format("UPDATE [Packing_Material] SET Packing_Material='{0}',Packing_Description='{1}' WHERE PackingMaterial_Id={2}", this.Name, this.Desc, this.Mtid);
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
                _returnStringMessage = "PackingMaterial Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string PackingMaterial_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Packing_Material]", "PackingMaterial_Id", this.Mtid) == true)
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

        public static void PackingMaterial_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Packing_Material,PackingMaterial_Id FROM [Packing_Material] ORDER BY Packing_Material");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Packing_Material", "PackingMaterial_Id");
            }
        }

        public int PackingMaterial_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Packing_Material] where Packing_Material.PackingMaterial_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Mtid = dbManager.DataReader["PackingMaterial_Id"].ToString();
                    this.Name = dbManager.DataReader["Packing_Material"].ToString();
                    this.Desc = dbManager.DataReader["Packing_Description"].ToString();

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

    //Methods For MaterialGroup Master Form
    public class MaterialGroup
    {
        public string Mtid, Name, Desc;
        public MaterialGroup()
        { }

        public string MaterialGroup_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[MaterialGroup_Master]", "MaterialGroup", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [MaterialGroup_Master] SELECT ISNULL(MAX(MaterialGroup_Id),0)+1,'{0}','{1}' FROM [MaterialGroup_Master]", this.Name, this.Desc);
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
                _returnStringMessage = "MaterialGroup Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string MaterialGroup_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[MaterialGroup_Master]", "MaterialGroup", this.Name) == false)
            {
                _commandText = string.Format("UPDATE [MaterialGroup_Master] SET MaterialGroup='{0}',MaterialGroup_Description='{1}' WHERE MaterialGroup_Id={2}", this.Name, this.Desc, this.Mtid);
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
                _returnStringMessage = "MaterialGroup Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string MaterialGroup_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[MaterialGroup_Master]", "MaterialGroup_Id", this.Mtid) == true)
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

        public static void MaterialGroup_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT MaterialGroup,MaterialGroup_Id FROM [MaterialGroup_Master] ORDER BY MaterialGroup");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "MaterialGroup", "MaterialGroup_Id");
            }
        }

        public int MaterialGroup_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [MaterialGroup_Master] where MaterialGroup_Master.MaterialGroup_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Mtid = dbManager.DataReader["MaterialGroup_Id"].ToString();
                    this.Name = dbManager.DataReader["MaterialGroup"].ToString();
                    this.Desc = dbManager.DataReader["MaterialGroup_Description"].ToString();

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

    //Methods For MaterialStatus Master Form
    public class MaterialStatus
    {
        public string Mtid, Name, Desc;
        public MaterialStatus()
        { }

        public string MaterialStatus_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Material_Status]", "MaterialGroup", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [Material_Status] SELECT ISNULL(MAX(MaterialStatus_Id),0)+1,'{0}','{1}' FROM [Material_Status]", this.Name, this.Desc);
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
                _returnStringMessage = "MaterialStatus Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string MaterialStatus_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Material_Status]", "MaterialGroup", this.Name) == false)
            {
                _commandText = string.Format("UPDATE [Material_Status] SET Material_Status='{0}',Material_Desc='{1}' WHERE MaterialStatus_Id={2}", this.Name, this.Desc, this.Mtid);
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
                _returnStringMessage = "MaterialStatus Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string MaterialStatus_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Material_Status]", "MaterialStatus_Id", this.Mtid) == true)
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

        public static void MaterialStatus_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Material_Status,MaterialStatus_Id FROM [Material_Status] ORDER BY Material_Status");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Material_Status", "MaterialStatus_Id");
            }
        }

        public int MaterialStatus_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Material_Status] where Material_Status.MaterialStatus_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Mtid = dbManager.DataReader["MaterialStatus_Id"].ToString();
                    this.Name = dbManager.DataReader["Material_Status"].ToString();
                    this.Desc = dbManager.DataReader["Material_Desc"].ToString();

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

    //Material Master

    //Methods for Basic Data

    //public class MaterialMaster
    //{
    //    public string Matid,MatCode,Uomid,MGId,OldMaterialNumber,Grossweight,WeightUnit,NetWeight,Sizedimensions,PackMaterialid,Matstatus,Matname,MatTpyeId,MatDrawings,ColorId,ColorName,MRP,SSP,HSN,ItemDescription;
    //    public MaterialMaster()
    //    { }

    //    public string MaterialMaster_BasicData_Save()
    //    {
    //        dbManager.Open();
    //        if (IsRecordExists("[Material_Master]", "Material_Code", this.MatCode) == false)
    //        {
    //            _commandText = string.Format("INSERT INTO [Material_Master] SELECT ISNULL(MAX(Material_Id),0)+1,'{0}',{1},{2},'{3}','{4}',{5},'{6}','{7}','{8}','{9}','{10}',{11},'{12}',{13},'{14}','{15}','{16}','{17}' FROM [Material_Master]", this.MatCode,this.Uomid,this.MGId,this.OldMaterialNumber,this.Grossweight,this.WeightUnit,this.NetWeight,this.Sizedimensions,this.PackMaterialid,this.Matstatus,this.Matname,this.MatTpyeId,this.MatDrawings,this.ColorId,this.MRP,this.SSP,this.HSN,this.ItemDescription);
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
    //        else
    //        {
    //            _returnStringMessage = "Material Code Already Exists.";
    //        }
    //        return _returnStringMessage;
    //    }

    //    public string MaterialMaster_Update()
    //    {
    //        dbManager.Open();

    //        _commandText = string.Format("UPDATE [Material_Master] SET Material_Code='{0}',Uom_Id='{1}',MaterialGroup_Id={2},OldMaterial_Number='{3}',Gross_Weight='{4}',Weight_Unit={5},Net_Weight='{6}',Size_Dimensions='{7}',PackingMaterial_Id={8},Material_Status='{9}',Material_Name='{10}',MaterialType_Id={11},Material_Drawings='{12}',Color_Id={13},MRP='{14}',SSP='{15}',HSN='{16}',Item_Description='{17}' WHERE Material_Id={18}", this.MatCode, this.Uomid, this.MGId, this.OldMaterialNumber, this.Grossweight, this.WeightUnit, this.NetWeight, this.Sizedimensions, this.PackMaterialid, this.Matstatus, this.Matname, this.MatTpyeId, this.MatDrawings, this.ColorId, this.MRP,this.SSP,this.HSN,this.ItemDescription, this.Matid);
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

    //        return _returnStringMessage;
    //    }

    //    public string MaterialMaster_Delete()
    //    {
    //        Masters.BeginTransaction();
    //        if (DeleteRecord("[Material_Master]", "Material_Id", this.Matid) == true)
    //        {
    //            Masters.CommitTransaction();
    //            _returnStringMessage = "Data Deleted Successfully";
    //        }
    //        else
    //        {
    //            Masters.RollBackTransaction();
    //            _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";

    //        }
    //        return _returnStringMessage;
    //    }

    //    public static void MaterialMaster_Select(Control ControlForBind)
    //    {
    //        dbManager.Open();
    //        _commandText = string.Format("SELECT Material_Code,Material_Id FROM [Material_Master] ORDER BY Material_Code");
    //        dbManager.ExecuteReader(CommandType.Text, _commandText);
    //        if (ControlForBind is DropDownList)
    //        {
    //            DropDownListBind(ControlForBind as DropDownList, "Material_Code", "Material_Id");
    //        }
    //    }

    //    public int MaterialType_Select(string Code)
    //    {
    //        dbManager.Open();
    //        try
    //        {
    //            _commandText = string.Format("SELECT * FROM [Material_Master],Color_Master  where Material_Master.Color_Id = Color_Master.Color_Id and Material_Master.Material_Id =" + Code + " ");

    //            dbManager.ExecuteReader(CommandType.Text, _commandText);
    //            if (dbManager.DataReader.Read())
    //            {
    //                this.Matid = dbManager.DataReader["Material_Id"].ToString();
    //                this.MatCode = dbManager.DataReader["Material_Code"].ToString();
    //                this.Uomid = dbManager.DataReader["Uom_Id"].ToString();
    //                this.MGId = dbManager.DataReader["MaterialGroup_Id"].ToString();
    //                this.OldMaterialNumber = dbManager.DataReader["OldMaterial_Number"].ToString();
    //                this.Grossweight = dbManager.DataReader["Gross_Weight"].ToString();
    //                this.WeightUnit = dbManager.DataReader["Weight_Unit"].ToString();
    //                this.NetWeight = dbManager.DataReader["Net_Weight"].ToString();
    //                this.Sizedimensions = dbManager.DataReader["Size_Dimensions"].ToString();
    //                this.PackMaterialid = dbManager.DataReader["PackingMaterial_Id"].ToString();
    //                this.Matstatus = dbManager.DataReader["Material_Status_Id"].ToString();
    //                this.Matname = dbManager.DataReader["Material_Name"].ToString();
    //                this.MatTpyeId = dbManager.DataReader["MaterialType_Id"].ToString();
    //                this.MatDrawings = dbManager.DataReader["Material_Drawings"].ToString();
    //                this.ColorId = dbManager.DataReader["Color_Id"].ToString();
    //                this.ColorName = dbManager.DataReader["Color_Name"].ToString();
    //                this.MRP = dbManager.DataReader["MRP"].ToString();
    //                this.SSP = dbManager.DataReader["SSP"].ToString();
    //                this.HSN = dbManager.DataReader["HSN"].ToString();
    //                this.ItemDescription = dbManager.DataReader["Item_Description"].ToString();

    //                _returnIntValue = 1;
    //            }
    //            else
    //            {
    //                _returnIntValue = 0;
    //            }
    //            dbManager.DataReader.Close();

    //        }
    //        catch
    //        {
    //        }
    //        finally
    //        {
    //        }
    //        return _returnIntValue;

    //    }

    //}

    public class MaterialMaster
    {
        public string Matid, MatCode, Catid, Boxsize, BarLength, Uomid, Description, weight, plantid, StorageLocation, ItemGroup, SellingPrice,Itemseries,Status;


        public string Companyid, BuyingPrice, BuyingCurrency, BrandId,sellingCurrency,ItemImage;
        
        public MaterialMaster()
        { }

        public string MaterialMaster_AutoGen()
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT  ISNULL(MAX(Material_Id),0)+1 FROM Material_Master").ToString());
            return _returnIntValue.ToString();
        }
        public string MaterialMaster_BasicData_Save()
        {
            this.Matid = MaterialMaster_AutoGen();
            dbManager.Open();
            if (IsRecordExists("[Material_Master]", "Material_Code", this.MatCode) == false)
            {
                _commandText = string.Format("INSERT INTO [Material_Master] values ({0},'{1}',{2},{3},{4},{5},'{6}',{7},{8},{9},{10},{11},{12},{13},'{14}',{15},{16},{17},'{18}' )", this.Matid, this.MatCode, this.Catid, this.Boxsize, this.BarLength, this.Uomid, this.Description, this.weight, this.plantid, this.StorageLocation, this.ItemGroup, this.SellingPrice,this.Itemseries,this.Companyid,this.BuyingPrice,this.BuyingCurrency,this.BrandId,this.sellingCurrency,this.Status);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);



                _commandText = string.Format("INSERT INTO [Material_Master_Image] values ({0},{1} )", this.Matid, this.ItemImage);
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
                _returnStringMessage = "Material Code Already Exists.";
            }
            return _returnStringMessage;
        }
        public int ItemColorDetails_Delete(string Itemcode)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("DELETE FROM [Material_Color_Details] WHERE Material_id={0}", Itemcode);
            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            return _returnIntValue;
        }
        public string MaterialMaster_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Material_Master] SET Material_Code='{0}',Category_Id={1},Box_Size={2},Bar_Length={3},UOM_Id={4},Description='{5}',Weight={6},Plant_Id={7},Storage_Location_Id={8},Item_Group={9},SellingPrice='{10}',Series={11},Cp_Id={12},BuyingPrice='{13}',BuyingCurrency={14},Brand_Id={15},SellingCurrency={16},Status = '{17}' WHERE Material_Id={18}", this.MatCode, this.Catid, this.Boxsize, this.BarLength, this.Uomid, this.Description, this.weight, this.plantid, this.StorageLocation, this.ItemGroup, this.SellingPrice, this.Itemseries, this.Companyid, this.BuyingPrice, this.BuyingCurrency, this.BrandId, this.sellingCurrency,this.Status, this.Matid);
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

        public string MaterialMaster_Delete()
        {
           // Masters.BeginTransaction();
            if (DeleteRecord("[Material_Master]", "Material_Id", this.Matid) == true)
            {


                 DeleteRecord("Material_Master_Image", "MaterialId", this.Matid);
                _returnStringMessage = "Data Deleted Successfully";
            }
            else
            {
                //Masters.RollBackTransaction();
                _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
            }
            return _returnStringMessage;
        }

        public static void MaterialMaster_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Material_Code,Material_Id FROM [Material_Master] where Material_Id != '0' ORDER BY Material_Code");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Material_Code", "Material_Id");
            }
        }

        public static void MaterialMasterGroup_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Material_Code,Material_Id FROM [Material_Master] where Item_Group = 'Product' ORDER BY Material_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Material_Code", "Material_Id");
            }
        }

        public static void BomMaterialMaster_Select(Control ControlForBind, string Code)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Bom_Id,Bom_No FROM [Material_Master],Bom where Material_Master.Material_Id = Bom.Item_Id and Material_Master.Item_Group = 'Product' and Material_Master.Material_Id = '" + Code + "'   ORDER BY Material_Code");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Bom_No", "Bom_Id");
            }
        }

        public string CategoryName, UomName,seriesName;



        //Item Image Select
        public int ImageMaterialType_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT MaterialId,Material_Code FROM [Material_Master_Image],Material_Master where Material_Master.Material_Id = Material_Master_Image.MaterialId and Material_Master_Image.MaterialId =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Matid = dbManager.DataReader["MaterialId"].ToString();
                    this.MatCode = dbManager.DataReader["Material_Code"].ToString();
                   // this.ItemImage = dbManager.DataReader["Item_Image"].ToString();
                   


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


        public int MaterialPO_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT [Material_Master].Description,[Material_Master].Bar_Length,UOM_SHORT_DESC,Box_Size FROM [Material_Master],Uom_Master  where  Material_Master.UOM_Id = Uom_Master.UOM_ID and  Material_Master.Material_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                   
                    this.BarLength = dbManager.DataReader["Bar_Length"].ToString();
                    this.Description = dbManager.DataReader["Description"].ToString();
                    this.UomName = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    this.Boxsize = dbManager.DataReader["Box_Size"].ToString();
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

        public int MaterialType_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Material_Master],Category_Master,Uom_Master,ItemSeries  where Material_Master.Category_Id = Category_Master.ITEM_CATEGORY_ID and Material_Master.UOM_Id =  Uom_Master.UOM_ID  and Material_Master.Series = ItemSeries.Item_Series_Id and   Material_Master.Material_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Matid = dbManager.DataReader["Material_Id"].ToString();
                    this.MatCode = dbManager.DataReader["Material_Code"].ToString();
                    this.Uomid = dbManager.DataReader["UOM_Id"].ToString();
                    this.Catid = dbManager.DataReader["Category_Id"].ToString();
                    this.Boxsize = dbManager.DataReader["Box_Size"].ToString();
                    this.BarLength = dbManager.DataReader["Bar_Length"].ToString();
                    this.Description = dbManager.DataReader["Description"].ToString();
                    this.weight = dbManager.DataReader["Weight"].ToString();
                    this.plantid = dbManager.DataReader["Plant_Id"].ToString();
                    this.StorageLocation = dbManager.DataReader["Storage_Location_Id"].ToString();
                    this.CategoryName = dbManager.DataReader["ITEM_CATEGORY_NAME"].ToString();
                    this.ItemGroup = dbManager.DataReader["Item_Group"].ToString();
                    this.UomName = dbManager.DataReader["UOM_SHORT_DESC"].ToString();
                    this.SellingPrice = dbManager.DataReader["SellingPrice"].ToString();
                    this.Itemseries = dbManager.DataReader["Series"].ToString();
                    this.ItemGroup = dbManager.DataReader["Item_Group"].ToString();
                    this.Companyid = dbManager.DataReader["Cp_Id"].ToString();
                    this.BuyingPrice = dbManager.DataReader["BuyingPrice"].ToString();
                    this.BuyingCurrency = dbManager.DataReader["BuyingCurrency"].ToString();
                    this.BrandId = dbManager.DataReader["Brand_Id"].ToString();
                    this.sellingCurrency = dbManager.DataReader["SellingCurrency"].ToString();
                    this.seriesName = dbManager.DataReader["Item_Series"].ToString();
                    

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

        public string ColorId;

        public string ItemColorDetails_save()
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("INSERT INTO Material_Color_Details SELECT ISNULL(MAX(Material_Color_Id),0)+1,{0},{1} FROM Material_Color_Details", this.Matid, this.ColorId);
            dbManager.ExecuteNonQuery(CommandType.Text, _commandText);

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

        #region Itemcolor Select

        public DataTable ItemColor_Select(int ItemCode)
        {
            DataTable dtable = new DataTable();
            DataColumn dcol = new DataColumn();
            dcol = new DataColumn("Color_Id");
            dtable.Columns.Add(dcol);

            dbManager.Open();
            _commandText = string.Format("SELECT * FROM Material_Color_Details WHERE  Material_id={0}", ItemCode);
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            while (dbManager.DataReader.Read())
            {
                DataRow drow = dtable.NewRow();
                drow["Color_Id"] = dbManager.DataReader[2].ToString();
                dtable.Rows.Add(drow);
            }
            dbManager.DataReader.Close();
            return dtable;
        }

        #endregion Itemcolor Select

        public static void ItemMaster_ModelNoSelect(Control ControlForBind, string MdNo)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT DISTINCT Color_Master.Color_Id, Color_Master.Color_Name FROM Color_Master INNER JOIN Material_Color_Details ON Color_Master.Color_Id = Material_Color_Details.Color_Id where Material_Color_Details.Material_id = " + MdNo);
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBindcolor(ControlForBind as DropDownList, "Color_Name", "Color_Id");
            }
          //  dbManager.Close();
        }





       /// <summary>
       /// From Stock List
       /// </summary>
       /// <param name="ControlForBind"></param>
       /// <param name="MdNo"></param>


        public static void ItemStock_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT DISTINCT Material_Code,MatId FROM Stock,[Material_Master] where  Stock.MatId = Material_Master.Material_Id  ORDER BY Material_Code");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Material_Code", "MatId");
            }
        }




        public static void ColorStock_ModelNoSelect(Control ControlForBind, string MdNo)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT DISTINCT Color_Master.Color_Id, Color_Master.Color_Name FROM Color_Master INNER JOIN Stock ON Color_Master.Color_Id = Stock.ColorId where Stock.MatId = " + MdNo);
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBindcolor(ControlForBind as DropDownList, "Color_Name", "Color_Id");
            }
            //  dbManager.Close();
        }


        public static void LengthStock_ModelNoSelect(Control ControlForBind, string MdNo)
        {
            dbManager.Open();
            _commandText = string.Format("select DISTINCT Stock.Length  from stock where Stock.MatId = " + MdNo);
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBindcolor(ControlForBind as DropDownList, "Length", "Length");
            }
            //  dbManager.Close();
        }


        public static void ItemColorLengthStock_ModelNoSelect(Control ControlForBind, string MdNo,string Color)
        {
            dbManager.Open();
            _commandText = string.Format("select DISTINCT Stock.Length  from stock where Stock.MatId = '" + MdNo +"' and ColorId = '"+ Color +"' ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBindcolor(ControlForBind as DropDownList, "Length", "Length");
            }
            //  dbManager.Close();
        }




    }

    //Methods For Storage Location Master
    public class StorageLocation
    {
        public string SLid, PlantId, Cpid, Name, Desc;

        public string StoreageLocName, StorageLocDesc;

        public StorageLocation()
        {
        }

        public string Plant_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Plant_Master]", "Plant_Name", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [Plant_Master] SELECT ISNULL(MAX(Plant_Id),0)+1,{0},'{1}','{2}' FROM [Plant_Master]", this.Cpid, this.Name, this.Desc);
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
                _returnStringMessage = "Plant Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Plant_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Plant_Master]", "Plant_Name", this.Name) == false)
            {
                _commandText = string.Format("UPDATE [Plant_Master] SET Company_Id = '{0}',  Plant_Name='{1}',Plant_Description='{2}' WHERE Plant_Id = {3}", this.Cpid, this.Name, this.Desc, this.PlantId);
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
                _returnStringMessage = "Plant Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Plant_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Plant_Master]", "Plant_Id", this.PlantId) == true)
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

        public static void Company_Plant_Select(Control ControlForBind, string Cmpid)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM Company_Profile,[Plant_Master] where Company_Profile.CP_ID = Plant_Master.Company_Id and Company_Profile.CP_ID = '" + Cmpid + "'  ORDER BY Plant_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Plant_Name", "Plant_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public static void StorageLocation_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [StorageLocation_Master] where StorageLoacation_Id !='0'");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "StorageLocation_Name", "StorageLoacation_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public static void PlantStorageLocation_Select(Control ControlForBind, string Plantid)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT StorageLocation_Name,StorageLoacation_Id FROM [StorageLocation_Master] where Plant_Id='" + Plantid + "' ORDER BY StorageLoacation_Id");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "StorageLocation_Name", "StorageLoacation_Id");
            }
            else if (ControlForBind is GridView)
            {
                GridViewBind(ControlForBind as GridView);
            }
        }

        public int Plant_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Plant_Master] where Plant_Master.Plant_Id =" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.PlantId = dbManager.DataReader["Plant_Id"].ToString();
                    this.Name = dbManager.DataReader["Plant_Name"].ToString();
                    this.Desc = dbManager.DataReader["Plant_Description"].ToString();
                    this.Cpid = dbManager.DataReader["Company_Id"].ToString();
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



        public int Stroage_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [StorageLocation_Master] where StorageLocation_Master.StorageLoacation_Id =" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.PlantId = dbManager.DataReader["Plant_Id"].ToString();
                    this.StoreageLocName = dbManager.DataReader["StorageLocation_Name"].ToString();
                    this.Desc = dbManager.DataReader["StorageLoacation_Desc"].ToString();
                    this.Cpid = dbManager.DataReader["CP_Id"].ToString();
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


        public string StorageLoc_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[StorageLocation_Master]", "StorageLocation_Name", this.StoreageLocName) == false)
            {
                _commandText = string.Format("INSERT INTO [StorageLocation_Master] SELECT ISNULL(MAX(StorageLoacation_Id),0)+1,{0},{1},'{2}','{3}' FROM [StorageLocation_Master]", this.Cpid, this.PlantId, this.StoreageLocName,this.StorageLocDesc);
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
                _returnStringMessage = "Storage Loc Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string StorageLoc_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [StorageLocation_Master] SET CP_Id = {0},Plant_Id={1},StorageLocation_Name='{2}',StorageLoacation_Desc='{3}' WHERE StorageLoacation_Id = {4}", this.Cpid, this.PlantId, this.StoreageLocName, this.StorageLocDesc,this.SLid);
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

        public string StorageLoc_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[StorageLocation_Master]", "StorageLoacation_Id", this.SLid) == true)
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




    }



    //Methods For Architect Master Form
    public class ArchitectMaster
    {
        public string Id,Name,Mobile,Email,Address,Time;

        public bool UserNameInUse { get; set; }
        public ArchitectMaster()
        { }

        public string ArchitectMaster_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Architect_Master]", "Architect_Name", this.Name) == false)
            {
                _commandText = string.Format("INSERT INTO [Architect_Master] SELECT ISNULL(MAX(Architect_Id),0)+1,'{0}','{1}','{2}','{3}' FROM [Architect_Master]", this.Name, this.Mobile,this.Email,this.Address);
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
                _returnStringMessage = "MaterialGroup Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string ArchitectMaster_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Architect_Master] SET Architect_Name='{0}',Architect_Mobile='{1}',Architect_Email='{2}',Architect_Address='{3}' WHERE Architect_Id = {4}", this.Name, this.Mobile, this.Email,this.Address,this.Id);
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

        public string ArchitectMaster_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Architect_Master]", "Architect_Id", this.Id) == true)
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

        public static void ArchitectMaster_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT Architect_Name,Architect_Id FROM [Architect_Master] where Architect_Id != 0");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Architect_Name", "Architect_Id");
            }
        }

        public int ArchitectMaster_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Architect_Master] where Architect_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["Architect_Id"].ToString();
                    this.Name = dbManager.DataReader["Architect_Name"].ToString();
                    this.Mobile = dbManager.DataReader["Architect_Mobile"].ToString();
                    this.Address = dbManager.DataReader["Architect_Address"].ToString();
                    this.Email = dbManager.DataReader["Architect_Email"].ToString();

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








    //Methods For Length Master Form
    public class LengthMaster
    {
        public string Id, Length,Description;
        public LengthMaster()
        { }

        public string LengthMaster_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[ProfileLength_Master]", "ProfileLength", this.Length) == false)
            {
                _commandText = string.Format("INSERT INTO [ProfileLength_Master] SELECT ISNULL(MAX(ProfileLength_Id),0)+1,'{0}','{1}' FROM [ProfileLength_Master]", this.Length, this.Description);
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
                _returnStringMessage = "Profile Length Already Exists.";
            }
            return _returnStringMessage;
        }

        public string LengthMaster_Update()
        {
            dbManager.Open();
             if (IsRecordExists("[ProfileLength_Master]", "ProfileLength", this.Length) == false)
            {
                _commandText = string.Format("UPDATE [ProfileLength_Master] SET ProfileLength='{0}',Description='{1}' WHERE ProfileLength_Id = {2}", this.Length, this.Description, this.Id);
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
                 _returnStringMessage = "Profile Length Already Exists.";
             }

            return _returnStringMessage;
        }

        public string LengthMaster_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[ProfileLength_Master]", "ProfileLength_Id", this.Id) == true)
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

        public static void LengthMaster_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT ProfileLength,ProfileLength_Id FROM [ProfileLength_Master]");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "ProfileLength", "ProfileLength_Id");
            }
        }

        public int LengthMaster_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [ProfileLength_Master] where ProfileLength_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["ProfileLength_Id"].ToString();
                    this.Length = dbManager.DataReader["ProfileLength"].ToString();
                    this.Description = dbManager.DataReader["Description"].ToString();
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










}