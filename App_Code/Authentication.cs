using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

using phani;
using phaniDAL;

namespace Alumil
{

    public class Authentication
    {
        static DBManager dbManager = new DBManager(DataProvider.SqlServer, DBConString.ConnectionString());

        private static int _returnIntValue;
        private static string _returnStringMessage, _commandText, EmpId, EmpName, EmpEmail, EmpUserName, EmpUserType,CpId,Department,Designation;
        public static string[] EmpDetails;

        //public enum Logged_EMP_Details
        //{ EmpId = 0, EmpName = 1, EmpEmail = 2, EmpUserName = 3, UserType = 4, CpId = 5, Department = 6, Designation = 7, EmpUserType =8}



        public enum Logged_EMP_Details
        { EmpId = 0, EmpName = 1, EmpEmail = 2, EmpUserName = 3, CpId = 4, Department = 5, Designation = 6, EmpUserType = 7 }
       



        private static object AlusoftSession
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["AlusoftSession"] == null)
                    return null;
                return System.Web.HttpContext.Current.Session["AlusoftSession"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["AlusoftSession"] = value;
            }
        }

        public Authentication()
        { }

        public static void Dispose()
        {
            dbManager.Dispose();
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


        private static bool IsRecordExists(string paraTableName, string paraFirstFieldName, string paraFirstFieldValue, string paraSecondFieldName, string paraSecondFieldValue, string paraThirdFieldName, string paraThirdFieldValue)
        {
            bool check = false;
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT COUNT(*) FROM " + paraTableName + " WHERE " + paraFirstFieldName + "='" + paraFirstFieldValue + "' and " + paraSecondFieldName + "<>'" + paraSecondFieldValue + "' and " + paraThirdFieldName + "<>'" + paraThirdFieldValue + "'").ToString());
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

        public static void BeginTransaction()
        {
            dbManager.Open();
            dbManager.BeginTransaction();
        }

        public static void CommitTransaction()
        {
            dbManager.CommitTransaction();
        }

        public static void RollBackTransaction()
        {
            dbManager.RollBackTransaction();
        }

        //Method for Auto Generate Max Serial ID
        public static string AutoGenMaxId(string TableName, string FieldName)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(" + FieldName + "),0)+1 FROM " + TableName + "").ToString());
            return _returnIntValue.ToString();
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

        public string LoginCheck(Page page, string UserName, string Password)
        {
            try
            {
                if (this.UserName_Check(UserName) > 0 && this.UserNameFromEmployeeMaster_Check(UserName) > 0)
                {
                    if (this.UserNamePwd_Check(UserName, Password) > 0)
                    {
                        
                            AlusoftSession = Get_EmployeeDetails(UserName);
                            LogDetailsInsert(UserName);
                           
                            page.Response.Redirect("~/Modules/Home.aspx");
                        
                    }
                    else
                    {
                        _returnStringMessage = "Invalid Password";
                    }
                }
                else
                {
                    _returnStringMessage = "User Name Is Not Registered";
                }
            }
            catch (Exception ex)
            {
                _returnStringMessage = ex.Message.ToString();
            }
            finally
            {
            }
            return _returnStringMessage;
        }





        public string MobileLoginCheck(Page page, string UserName, string Password)
        {
            try
            {
                if (this.UserName_Check(UserName) > 0 && this.UserNameFromEmployeeMaster_Check(UserName) > 0)
                {
                    if (this.UserNamePwd_Check(UserName, Password) > 0)
                    {

                        AlusoftSession = Get_EmployeeDetails(UserName);
                        LogDetailsInsert(UserName);

                        page.Response.Redirect("~/MobileDr.aspx");

                    }
                    else
                    {
                        _returnStringMessage = "Invalid Password";
                    }
                }
                else
                {
                    _returnStringMessage = "User Name Is Not Registered";
                }
            }
            catch (Exception ex)
            {
                _returnStringMessage = ex.Message.ToString();
            }
            finally
            {
            }
            return _returnStringMessage;
        }






        private int UserName_Check(string UserName)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("SELECT  COUNT(*) FROM [User_Master] WHERE UserName='{0}'", UserName);
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString());
            return _returnIntValue;
        }

        private int UserNameFromEmployeeMaster_Check(string UserName)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("SELECT  COUNT(*) FROM [Employee_Master] WHERE EMP_USERNAME='{0}' and Employee_Master.Status != 'Inactive' ", UserName);
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString());
            return _returnIntValue;
        }

        private int UserNamePwd_Check(string UserName, string Password)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("SELECT  COUNT(*) FROM [User_Master] WHERE UserName='{0}' AND PassWord='{1}'", UserName, Password);
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString());
            return _returnIntValue;
        }

        private int LoginExpiry_Check(string UserName, string Password)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("SELECT  COUNT(*) FROM [User_Master] WHERE UserName='{0}' AND PassWord='{1}' ", UserName, Password);
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString());
            return _returnIntValue;
        }

        private string[] Get_EmployeeDetails(string UserName)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
//_commandText = string.Format("SELECT  EMP_ID,EMP_FIRST_NAME+' ' + EMP_MIDDLE_NAME + ' ' + EMP_LAST_NAME AS EMP_FULLNAME,EMP_EMAIL,EMP_USERNAME FROM [YANTRA_EMPLOYEE_MAST] WHERE EMP_USERNAME='{0}'", UserName);

          //  _commandText = string.Format(" SELECT  EMP_ID,EMP_FIRST_NAME+' ' + EMP_MIDDLE_NAME + ' ' + EMP_LAST_NAME AS EMP_FULLNAME,EMP_EMAIL, EMP_USERNAME,EMP_CPID FROM [Employee_Master] WHERE  EMP_USERNAME='{0}'", UserName);

            _commandText = string.Format("SELECT [Employee_Master].EMP_ID,EMP_FIRST_NAME+' ' + EMP_MIDDLE_NAME + ' ' + EMP_LAST_NAME AS EMP_FULLNAME,EMP_EMAIL, EMP_USERNAME,EMP_CPID,DEPT_NAME,DESG_NAME,Employee_Details.EMP_TYPE_ID FROM [Employee_Master],Department_Master,Designation_Master,Employee_Details WHERE [Employee_Master].EMP_ID = Employee_Details.EMP_ID and Employee_Details.DEPT_ID = Department_Master.DEPT_ID and Employee_Details.DESG_ID = Designation_Master.DESG_ID and EMP_USERNAME ='{0}'", UserName);
            
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (dbManager.DataReader.Read())
            {
                EmpId = dbManager.DataReader["EMP_ID"].ToString();
                EmpName = dbManager.DataReader["EMP_FULLNAME"].ToString();
                EmpEmail = dbManager.DataReader["EMP_EMAIL"].ToString();
                EmpUserName = dbManager.DataReader["EMP_USERNAME"].ToString();
                CpId = dbManager.DataReader["EMP_CPID"].ToString();
                Department = dbManager.DataReader["DEPT_NAME"].ToString();
                Designation = dbManager.DataReader["DESG_NAME"].ToString();
                EmpUserType = dbManager.DataReader["EMP_TYPE_ID"].ToString();
                _returnIntValue = 1;
            }
            else
            {
                _returnIntValue = 0;
            }
            dbManager.DataReader.Close();
            string[] emp ={ EmpId, EmpName, EmpEmail, EmpUserName, CpId,Department,Designation,EmpUserType};
            return emp;
        }

        private static void LogDetailsInsert(string UserName)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();

            _commandText = string.Format("INSERT INTO [Login_Log_Details] SELECT ISNULL(MAX(LOGID),0)+1,'{0}',GETDATE(),GETDATE() FROM [Login_Log_Details]", UserName);
            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
        }

        public static void Privilege_Check(Page page)
        {
            if (AlusoftSession != null)
            {
                EmpDetails = (string[])AlusoftSession;
                //if (dbManager.Transaction == null)
                //    dbManager.Open();
                //_commandText = string.Format("SELECT  COUNT(*) FROM [YANTRA_USER_PRIVILEGES],[YANTRA_LKUP_PRIVILEGES] WHERE [YANTRA_USER_PRIVILEGES.PRIVILEGE_ID=[YANTRA_LKUP_PRIVILEGES].PRIVILEGE_ID AND [YANTRA_USER_PRIVILEGES].USER_NAME='{0}'", UserName);
                //_returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString());
            }
            else
            {
                page.Response.Redirect("Login.aspx?p=noaccess");
            }
        }

        public static void Session_Check(MasterPage page)
        {
            if (AlusoftSession == null)
            {
                //EmpDetails = (string[])YantraSession;
                page.Response.Redirect("~/Login.aspx");
            }
            //else
            //{
                
            //}
        }

        public static void ClearSession(MasterPage page)
        {
            AlusoftSession = null;
            page.Response.Redirect("~/Login.aspx");
        }

        public static string GetEmployeeInSession(Logged_EMP_Details Type)
        {
            if (AlusoftSession != null)
            {
                EmpDetails = (string[])AlusoftSession;
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Login.aspx");
            }
                
            return EmpDetails[(int)Type];
        }

        public static void UserPrivilegesFill(HiddenField Field)
        {
            Field.Value = "";
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("SELECT * FROM [YANTRA_USER_DETAILS],[YANTRA_USER_PRIVILEGES],[YANTRA_LKUP_PRIVILEGES] WHERE [YANTRA_USER_DETAILS].[USER_ID]=[YANTRA_USER_PRIVILEGES].[USER_ID] AND [YANTRA_USER_PRIVILEGES].PRIVILEGE_ID=[YANTRA_LKUP_PRIVILEGES].PRIVILEGE_ID AND [YANTRA_USER_DETAILS].[USER_NAME]='{0}'", EmpUserName);
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            while (dbManager.DataReader.Read())
            {
                if (Field.Value == "")
                {
                    Field.Value = dbManager.DataReader["PRIVILEGE_NAME"].ToString();
                }
                else
                {
                    Field.Value = Field.Value + "#|#" + dbManager.DataReader["PRIVILEGE_NAME"].ToString();
                }
                _returnIntValue = 1;
            }

            dbManager.DataReader.Close();
        }

        public static int UserPrivilegesFill(string PermissionName)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("SELECT count(*) FROM [YANTRA_USER_DETAILS],[YANTRA_USER_PRIVILEGES],[YANTRA_LKUP_PRIVILEGES] WHERE [YANTRA_USER_DETAILS].[USER_ID]=[YANTRA_USER_PRIVILEGES].[USER_ID] AND [YANTRA_USER_PRIVILEGES].PRIVILEGE_ID=[YANTRA_LKUP_PRIVILEGES].PRIVILEGE_ID AND [YANTRA_USER_DETAILS].[USER_NAME]='{0}' AND [YANTRA_LKUP_PRIVILEGES].PRIVILEGE_NAME='{1}'", EmpUserName, PermissionName);
            _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString());
            return _returnIntValue;
        }



        public class UserDetails
        {
            public string UserId, UserName, Password, AssignDate, ExpiryDate, PrivelegeId, UserPrivelegeId, UserType;   //User Details
            public UserDetails()
            { }

            public static void UserDetails_Select(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                //_commandText = string.Format("select EMP_ID,EMP_FIRST_NAME  +' '+ EMP_LAST_NAME as Full_Name from YANTRA_EMPLOYEE_MAST order by EMP_FIRST_NAME");
                _commandText = "select EMP_ID,EMP_FIRST_NAME  +' '+ EMP_LAST_NAME as Full_Name from YANTRA_EMPLOYEE_MAST WHERE EMP_USERNAME NOT IN (SELECT [USER_NAME] FROM YANTRA_USER_DETAILS) AND EMP_ID<>0 order by EMP_FIRST_NAME";
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "Full_Name", "EMP_ID");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static void UserDetails_Fill(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("select EMP_EMAIL,EMP_FIRST_NAME  +' '+ EMP_LAST_NAME as Full_Name from YANTRA_EMPLOYEE_MAST order by EMP_USERNAME");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "EMP_USERNAME", "EMP_USERNAME");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public static void Privileges_Fill(Control ControlForBind)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();

                _commandText = string.Format("select * from YANTRA_LKUP_PRIVILEGES order by PRIVILEGE_NAME");
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (ControlForBind is DropDownList)
                {
                    DropDownListBind(ControlForBind as DropDownList, "PRIVILEGE_NAME", "PRIVILEGE_ID");
                }
                else if (ControlForBind is GridView)
                {
                    GridViewBind(ControlForBind as GridView);
                }
            }

            public string UserDetails_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                if (IsRecordExists("[YANTRA_USER_DETAILS]", "USER_NAME", this.UserName) == false)
                {
                    this.UserId = AutoGenMaxId("[YANTRA_USER_DETAILS]", "USER_ID");
                    _commandText = string.Format("INSERT INTO [YANTRA_USER_DETAILS] VALUES({0},'{1}','{2}','{3}','{4}','{5}')", this.UserId, this.UserName, this.Password, this.AssignDate, this.ExpiryDate, this.UserType );
                    _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                    _returnStringMessage = string.Empty;
                    if (_returnIntValue < 0 || _returnIntValue == 0)
                    {
                        _returnStringMessage = "Some Data Missing.";
                    }
                    else if (_returnIntValue > 0)
                    {
                        //Privelges_Save();
                        _returnStringMessage = "Data Saved Successfully";
                    }
                }
                else
                {
                    _returnStringMessage = "User Name Already Exists.";
                }
                return _returnStringMessage;
            }

            public int UserDetails_Delete(string UserId)
            {
                if (DeleteRecord("[YANTRA_USER_DETAILS]", "USER_ID", UserId) == true)
                { _returnIntValue = 1; }
                else
                { _returnIntValue = 0; }
                return _returnIntValue;
            }

            public string Privelges_Save()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT PRIVILEGE_ID FROM [YANTRA_LKUP_PRIVILEGES] WHERE PRIVILEGE_NAME='" + this.PrivelegeId + "'");
                _commandText = string.Format("INSERT INTO [YANTRA_USER_PRIVILEGES] SELECT ISNULL(MAX(USER_PRIVILEGES_ID),0)+1,'{0}','{1}' FROM [YANTRA_USER_PRIVILEGES]", this.UserId, dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString());
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

            public int Privelges_Delete(string UserId)
            {
                if (DeleteRecord("[YANTRA_USER_PRIVILEGES]", "USER_ID", UserId) == true)
                { _returnIntValue = 1; }
                else
                { _returnIntValue = 0; }
                return _returnIntValue;
            }

            public string UserDetails_Update()
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                 if (IsRecordExists("[YANTRA_USER_DETAILS]", "USER_NAME", this.UserName, "USER_ID", this.UserId, "USER_TYPE", this.UserType) == false)
                {
                        if (this.Password.Length > 0)
                        {
                            _commandText = string.Format("UPDATE [YANTRA_USER_DETAILS] SET USER_NAME='{0}',PASSWORD='{1}',ASSIGN_DATE='{2}',EXPIRY_DATE='{3}' ,USER_TYPE='{5}' WHERE USER_ID={4}", this.UserName, this.Password, this.AssignDate, this.ExpiryDate, this.UserId, this.UserType);
                        }
                        else
                        {
                            _commandText = string.Format("UPDATE [YANTRA_USER_DETAILS] SET USER_NAME='{0}',ASSIGN_DATE='{2}',EXPIRY_DATE='{3}',USER_TYPE='{5}' WHERE USER_ID={4}", this.UserName, this.Password, this.AssignDate, this.ExpiryDate, this.UserId, this.UserType);
                        }
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
                    _returnStringMessage = "User Name Already Exists.";
                }
                return _returnStringMessage;
            }

            public static void UserPrivilegesFill(string UserId, HiddenField Field)
            {
                Field.Value = "";
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT * FROM [YANTRA_USER_PRIVILEGES],[YANTRA_LKUP_PRIVILEGES] WHERE [YANTRA_USER_PRIVILEGES].PRIVILEGE_ID=[YANTRA_LKUP_PRIVILEGES].PRIVILEGE_ID AND [YANTRA_USER_PRIVILEGES].[USER_ID]='{0}'", UserId);
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                while (dbManager.DataReader.Read())
                {
                    if (Field.Value == "")
                    {
                        Field.Value = dbManager.DataReader["PRIVILEGE_NAME"].ToString();
                    }
                    else
                    {
                        Field.Value = Field.Value + "#|#" + dbManager.DataReader["PRIVILEGE_NAME"].ToString();
                    }
                    _returnIntValue = 1;
                }

                dbManager.DataReader.Close();
            }

            public static void AddPrivilegesInList(string PrivilegeName)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("INSERT INTO [YANTRA_LKUP_PRIVILEGES] SELECT ISNULL(MAX(PRIVILEGE_ID),0)+1,'{0}','{1}' FROM [YANTRA_LKUP_PRIVILEGES]", PrivilegeName, PrivilegeName);
                _returnIntValue = int.Parse(dbManager.ExecuteNonQuery(CommandType.Text, _commandText).ToString());
            }

            public static void RemovePrivilegesFromList(string PrivilegeName)
            {
                Authentication.BeginTransaction();
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT PRIVILEGE_ID FROM [YANTRA_LKUP_PRIVILEGES] WHERE PRIVILEGE_NAME='{0}'", PrivilegeName);
                if (DeleteRecord("[YANTRA_USER_PRIVILEGES]", "PRIVILEGE_ID", dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString()) == true)
                {
                    if (DeleteRecord("[YANTRA_LKUP_PRIVILEGES]", "PRIVILEGE_NAME", PrivilegeName) == true)
                    {
                        Authentication.CommitTransaction();
                    }
                    else
                    {
                        Authentication.RollBackTransaction();
                    }
                }
                else
                {
                    Authentication.RollBackTransaction();
                }
            }

            public static int CheckPrivilegesInList(string PrivilegeName)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT  COUNT(*) FROM [YANTRA_LKUP_PRIVILEGES] WHERE [YANTRA_LKUP_PRIVILEGES].PRIVILEGE_NAME='{0}'", PrivilegeName);
                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString());
                return _returnIntValue;
            }

            public static int CheckPrivilegesCountInList(string PrivilegeName)
            {
                if (dbManager.Transaction == null)
                    dbManager.Open();
                _commandText = string.Format("SELECT  COUNT(*) FROM [YANTRA_LKUP_PRIVILEGES] WHERE [YANTRA_LKUP_PRIVILEGES].PRIVILEGE_NAME LIKE '{0}%'", PrivilegeName);
                _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString());
                return _returnIntValue;
            }
        }


    }
}