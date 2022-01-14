using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections;
using phani;
using phaniDAL;

    public class LoginClass
    {

        private static int _returnIntValue;
        private static string _returnStringMessage, _commandText,EDIT,DELETE;
        static DBManager dbManager = new DBManager(DataProvider.SqlServer, DBConString.ConnectionString());
        public int UserId;
        public static string[] EmpDetails;

        public enum Logged_EMP_Details
        { EmpId = 0 ,EDIT = 0,DELETE = 0}
        
        private static object YantraSession
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["YantraSession"] == null)
                    return null;
                return System.Web.HttpContext.Current.Session["YantraSession"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["YantraSession"] = value;
            }
        }
        public LoginClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Login_UserAuthentication(string username, string password)
        {
            dbManager.Open();

            if (LoginClass.IsRecordExists("UTY_USER_MASTER", "UserName", username) == true)
            {
                _commandText = "SELECT * FROM  UTY_USER_MASTER where UserName = '" + username + "' and PassWord = '" + password + "'";
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    // if success
                    return 1;


                }
                else
                {
                    // if password is wrong
                    return 2;

                }
            }
            else
            {
                // if user name is not there 
                return 3;

            }
        }

        #region HomePage Class
        public class HomePageClass
        {
            #region HomePage PageLoad
            public ArrayList HomePage_Select(string UserId)
            {
                dbManager.Open();
                _commandText = string.Format("SELECT Permissions FROM UTY_USER_PERMISSIONS WHERE UserId= {0}", int.Parse(UserId));
                dbManager.ExecuteReader(CommandType.Text, _commandText);
                ArrayList Permissions = new ArrayList();
                while (dbManager.DataReader.Read())
                {
                    Permissions.Add(dbManager.DataReader[0].ToString());
                }
                dbManager.DataReader.Close();
                return Permissions;
            }
            #endregion

           
        }

        #endregion

       
        string EmpId;
        private string[] Get_EmployeeDetails(string UserName)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("SELECT  EMP_ID,IsDelete,IsEdit FROM [YANTRA_EMPLOYEE_MAST], UTY_USER_MASTER WHERE YANTRA_EMPLOYEE_MAST.EMP_USERNAME = UTY_USER_MASTER.UserName AND EMP_USERNAME='{0}'", UserName);
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (dbManager.DataReader.Read())
            {
                EmpId = dbManager.DataReader["EMP_ID"].ToString();
                EDIT = dbManager.DataReader["IsEdit"].ToString();
                DELETE = dbManager.DataReader["IsDelete"].ToString();
                _returnIntValue = 1;
            }
            else
            {
                _returnIntValue = 0;
            }
            dbManager.DataReader.Close();
            string[] emp = { EmpId,EDIT,DELETE};
            return emp;
        }

        #region LoginPage Login method
        public int LoginPage_Login(string UserName, string PassWord)
        {
            dbManager.Open();
            if (LoginClass.IsRecordExists("UTY_USER_MASTER", "UserName", UserName) == true)
            {
                YantraSession = Get_EmployeeDetails(UserName);
                _commandText = string.Format("SELECT UserId FROM UTY_USER_MASTER WHERE UserName= '{0}' and PassWord='{1}'", UserName, PassWord);
                _returnIntValue = Convert.ToInt32(dbManager.ExecuteScalar(CommandType.Text, _commandText));
                UserId = _returnIntValue;
                if (_returnIntValue > 0)
                {
                    _returnIntValue = 3;//correct UserId and Password 
                }
                else
                {
                    _returnIntValue = 2;//Invalid Password
                }

            }
            else
            {
                _returnIntValue = 1;//Invalid UserName
            }
            return _returnIntValue;

        }
        #endregion


        public static string GetEmployeeInSession(Logged_EMP_Details Type)
        {
            if (YantraSession != null)
            {
                EmpDetails = (string[])YantraSession;
            }
            
            return EmpDetails[(int)Type];
        }


        #region IsRecordExists
        public static bool IsRecordExists(string paraTableName, string paraFieldName, string paraFieldValue)
        {
            int _returnIntValue;
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
        #endregion

    }
