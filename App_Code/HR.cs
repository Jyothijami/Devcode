using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Globalization;
using phani;
using phaniDAL;

/// <summary>
/// Summary description for HR
/// </summary>
public class HR
{
    private static int _returnIntValue;
    private static string _returnStringMessage, _commandText;

    static DBManager dbManager = new DBManager(DataProvider.SqlServer, DBConString.ConnectionString());

    public HR()
    { }

    //Method for Auto Generate Max Serial ID
    public static string AutoGenMaxId(string TableName, string FieldName)
    {
        if (dbManager.Transaction == null)
            dbManager.Open();
        _returnIntValue = int.Parse(dbManager.ExecuteScalar(CommandType.Text, "SELECT ISNULL(MAX(" + FieldName + "),0)+1 FROM " + TableName + "").ToString());
        return _returnIntValue.ToString();
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

    //Methods for Checking a record exists or not with reference id
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

    public class EmployeeMaster
    {
        public string EmpID, EmpFirstName, EmpMiddleName, EmpLastName, EmpGender, EmpMobile, EmpPhone, EmpDOB, EmpEMail, EmpPhoto, EmpAddress, EmpCity, DeptID, DesgID, BranchId, EmpDetDOJ, EmpDetDOT, EmpTypeID, EmpBranchID, EMPUserName, EmpReportingto,sALARY,TDS,ACCOUNTNO,Status;
        public string tEmpPhoto, DeptName12, DesgName12,PASSWORD,Empseries;

        public string CpId, PlantId,Grade;
        public bool UserNameInUse { get; set; }
        public EmployeeMaster()
        { }

        public int GetAge(int EmpId)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("select DATEDIFF(yyyy,emp_dob,getdate()) from [Employee_Master] where EMP_ID=" + EmpId + "");
            _returnIntValue = Convert.ToInt32(dbManager.ExecuteScalar(CommandType.Text, _commandText));
            return _returnIntValue;
        }
        public static string EmpSeries_AutoGenCode()
        {
            return AutoGenMaxNo("Employee_Master", "EMP_NO");
        }

        public static void EmployeeMaster_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT EMP_FIRST_NAME,EMP_LAST_NAME,EMP_ID FROM [Employee_Master] WHERE EMP_ID<>0 ORDER BY EMP_FIRST_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                (ControlForBind as DropDownList).Items.Clear();
                (ControlForBind as DropDownList).Items.Add(new ListItem("Select Employee", "0"));
                while (dbManager.DataReader.Read())
                {
                    (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["EMP_FIRST_NAME"].ToString() + " " + dbManager.DataReader["EMP_LAST_NAME"].ToString(), dbManager.DataReader["EMP_ID"].ToString()));
                }
                dbManager.DataReader.Close();
            }
            //dbManager.Dispose();
        }



        public static void EmployeeMaster_Select_2(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format(" SELECT EMP_FIRST_NAME,EMP_LAST_NAME,EMP_ID FROM [Employee_Master] WHERE EMP_ID<>0 and EMP_CPID = '1' and Status != 'Inactive' ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                (ControlForBind as DropDownList).Items.Clear();
                (ControlForBind as DropDownList).Items.Add(new ListItem("Select Employee", "0"));
                while (dbManager.DataReader.Read())
                {
                    (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["EMP_FIRST_NAME"].ToString() + " " + dbManager.DataReader["EMP_LAST_NAME"].ToString(), dbManager.DataReader["EMP_ID"].ToString()));
                }
                dbManager.DataReader.Close();
            }
            //dbManager.Dispose();
        }



        public static void EmployeeMaster_SelectDept_Comp(Control ControlForBind, string deptId)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Employee_Master] a inner join dbo.Employee_Details b on a.EMP_ID=b.EMP_ID WHERE a.EMP_ID<>0 and  b.DEPT_ID='" + deptId + "'  ORDER BY EMP_FIRST_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                (ControlForBind as DropDownList).Items.Clear();
                (ControlForBind as DropDownList).Items.Add(new ListItem("--", "0"));
                while (dbManager.DataReader.Read())
                {
                    (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["EMP_FIRST_NAME"].ToString() + " " + dbManager.DataReader["EMP_LAST_NAME"].ToString(), dbManager.DataReader["EMP_ID"].ToString()));
                }
                dbManager.DataReader.Close();
            }
        }

        // Department HR
        public static void EmployeeMasterHR_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("select EMP_FIRST_NAME,EMP_LAST_NAME,Employee_Master.EMP_ID from  Employee_Master,Employee_Details where Employee_Master.EMP_ID = Employee_Details.EMP_ID and Employee_Details.DEPT_ID = '5' and Employee_Master.EMP_ID<>0 ORDER BY EMP_FIRST_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                (ControlForBind as DropDownList).Items.Clear();
                (ControlForBind as DropDownList).Items.Add(new ListItem("Select Employee", "0"));
                while (dbManager.DataReader.Read())
                {
                    (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["EMP_FIRST_NAME"].ToString() + " " + dbManager.DataReader["EMP_LAST_NAME"].ToString(), dbManager.DataReader["EMP_ID"].ToString()));
                }
                dbManager.DataReader.Close();
            }
            //dbManager.Dispose();
        }




        /// <summary>
        /// ///Desinger EMployeee lIst
        /// </summary>
        /// <param name="ControlForBind"></param>
        public static void EmployeeMasterDesigner_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("select EMP_FIRST_NAME,EMP_LAST_NAME,Employee_Master.EMP_ID from  Employee_Master,Employee_Details where Employee_Master.EMP_ID = Employee_Details.EMP_ID and Employee_Details.DEPT_ID = '4' and Employee_Master.EMP_ID<>0 and Employee_Master.Status = 'Active'  ORDER BY EMP_FIRST_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                (ControlForBind as DropDownList).Items.Clear();
                (ControlForBind as DropDownList).Items.Add(new ListItem("Select Employee", "0"));
                while (dbManager.DataReader.Read())
                {
                    (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["EMP_FIRST_NAME"].ToString() + " " + dbManager.DataReader["EMP_LAST_NAME"].ToString(), dbManager.DataReader["EMP_ID"].ToString()));
                }
                dbManager.DataReader.Close();
            }
            //dbManager.Dispose();
        }

        public static void EmployeeMasterDepartment_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Employee_Master],Employee_Details WHERE Employee_Master.EMP_ID = Employee_Details.EMP_ID and Employee_Details.DEPT_ID ='2' and  Employee_Master.EMP_ID<>0   ORDER BY EMP_FIRST_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                (ControlForBind as DropDownList).Items.Clear();
                (ControlForBind as DropDownList).Items.Add(new ListItem("--", "0"));
                while (dbManager.DataReader.Read())
                {
                    (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["EMP_FIRST_NAME"].ToString() + " " + dbManager.DataReader["EMP_LAST_NAME"].ToString(), dbManager.DataReader["EMP_ID"].ToString()));
                }
                dbManager.DataReader.Close();
            }
        }



        public static void EmployeeUserMaster_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Employee_Master] WHERE EMP_ID<>0 and EMP_USERNAME = '' ORDER BY EMP_FIRST_NAME");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                (ControlForBind as DropDownList).Items.Clear();
                (ControlForBind as DropDownList).Items.Add(new ListItem("--", "0"));
                while (dbManager.DataReader.Read())
                {
                    (ControlForBind as DropDownList).Items.Add(new ListItem(dbManager.DataReader["EMP_FIRST_NAME"].ToString() , dbManager.DataReader["EMP_ID"].ToString()));
                }
                dbManager.DataReader.Close();
            }
        }



        public string CompanyName, EmpTypeName;

        //This method is for temporary use only For Sales & Marketing Module...
        public int EmployeeMaster_Select(string EmployeeId)
        {
            dbManager.Open();
            //_commandText = string.Format("SELECT * FROM [Employee_Master],[Employee_Details],Designation_Master,Department_Master,Plant_Master,Company_Profile,Employee_Type WHERE " +
            //                " [Employee_Master].EMP_ID=[Employee_Details].EMP_ID AND [Employee_Master].EMP_ID<>0 AND  Employee_Details.DEPT_ID=Department_Master.DEPT_ID AND Employee_Details.DESG_ID=Designation_Master.DESG_ID AND" +
            //                "    Employee_Master.EMP_CPID = Company_Profile.CP_ID and Employee_Details.EMP_TYPE_ID = Employee_Type.EMP_TYPE_ID  and [Employee_Master].EMP_ID=" + EmployeeId + "");


            _commandText = string.Format("SELECT * FROM [Employee_Master],[Employee_Details],Designation_Master,Department_Master,Company_Profile,Employee_Type WHERE " +
                          " [Employee_Master].EMP_ID=[Employee_Details].EMP_ID AND [Employee_Master].EMP_ID<>0 AND  Employee_Details.DEPT_ID=Department_Master.DEPT_ID AND Employee_Details.DESG_ID=Designation_Master.DESG_ID AND" +
                          "    Employee_Master.EMP_CPID = Company_Profile.CP_ID and Employee_Details.EMP_TYPE_ID = Employee_Type.EMP_TYPE_ID  and [Employee_Master].EMP_ID=" + EmployeeId + "");

            
            
            
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (dbManager.DataReader.Read())
            {
                this.EmpID = dbManager.DataReader["EMP_ID"].ToString();
                this.EmpFirstName = dbManager.DataReader["EMP_FIRST_NAME"].ToString();
                this.EmpMiddleName = dbManager.DataReader["EMP_MIDDLE_NAME"].ToString();
                this.EmpLastName = dbManager.DataReader["EMP_LAST_NAME"].ToString();
                this.EmpGender = dbManager.DataReader["EMP_GENDER"].ToString();
                this.EmpMobile = dbManager.DataReader["EMP_MOBILE"].ToString();
                this.EmpPhone = dbManager.DataReader["EMP_PHONE"].ToString();
                this.EmpDOB = dbManager.DataReader["EMP_DOB"].ToString();
                this.EmpEMail = dbManager.DataReader["EMP_EMAIL"].ToString();
                this.EmpPhoto = dbManager.DataReader["EMP_PHOTO"].ToString();
                this.EmpAddress = dbManager.DataReader["EMP_ADDRESS"].ToString();
                this.EmpCity = dbManager.DataReader["EMP_CITY"].ToString();
                this.DeptID = dbManager.DataReader["DEPT_ID"].ToString();
                this.DesgID = dbManager.DataReader["DESG_ID"].ToString();
                this.EmpDetDOJ = dbManager.DataReader["EMP_DET_DOJ"].ToString();
                this.EmpDetDOT = dbManager.DataReader["EMP_DET_DOT"].ToString();
                this.EmpBranchID = dbManager.DataReader["BRAN_ID"].ToString();
                this.EmpTypeID = dbManager.DataReader["EMP_TYPE_ID"].ToString();
                this.EMPUserName = dbManager.DataReader["EMP_USERNAME"].ToString();
                this.DeptName12 = dbManager.DataReader["DEPT_NAME"].ToString();
                this.DesgName12 = dbManager.DataReader["DESG_NAME"].ToString();
                this.PASSWORD = dbManager.DataReader["EMP_PASSWORD"].ToString();

                this.PlantId = dbManager.DataReader["EMP_LEAVEAPPROVER_ID"].ToString();
                this.CpId = dbManager.DataReader["EMP_CPID"].ToString();
                this.Empseries = dbManager.DataReader["EMP_NO"].ToString();

                this.CompanyName = dbManager.DataReader["CP_FULL_NAME"].ToString();
                this.EmpTypeName = dbManager.DataReader["EMP_TYPE_NAME"].ToString();

                this.sALARY = dbManager.DataReader["EMP_SALARY"].ToString();

                this.TDS = dbManager.DataReader["EMP_TDS"].ToString();
                this.ACCOUNTNO = dbManager.DataReader["BANK_ACCOUNT"].ToString();
                this.Grade = dbManager.DataReader["GradeId"].ToString();

                this.EmpReportingto = dbManager.DataReader["EMP_LEAVEAPPROVER_ID"].ToString();
                if (this.EmpDOB == "1/1/1900 12:00:00 AM") { this.EmpDOB = ""; } else { this.EmpDOB = Convert.ToDateTime(this.EmpDOB).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); }
                if (this.EmpDetDOJ == "1/1/1900 12:00:00 AM") { this.EmpDetDOJ = ""; } else { this.EmpDetDOJ = Convert.ToDateTime(this.EmpDetDOJ).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); }
                if (this.EmpDetDOT == "1/1/1900 12:00:00 AM") { this.EmpDetDOT = ""; } else { this.EmpDetDOT = Convert.ToDateTime(this.EmpDetDOT).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); }

                _returnIntValue = 1;
            }
            else
            {
                _returnIntValue = 0;
            }
            return _returnIntValue;
        }








        public int EmployeeMasterEmail_Select(string EmployeeId)
        {
            dbManager.Open();
           

            _commandText = string.Format("SELECT * FROM [Employee_Master] where [Employee_Master].EMP_ID=" + EmployeeId + "");




            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (dbManager.DataReader.Read())
            {
                
                this.EmpEMail = dbManager.DataReader["EMP_EMAIL"].ToString();
              

                _returnIntValue = 1;
            }
            else
            {
                _returnIntValue = 0;
            }
            return _returnIntValue;
        }











        public static string GetEmployeeEmail(string EmployeeId)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT EMP_EMAIL FROM [Employee_Master] WHERE EMP_ID=" + EmployeeId + "");
            _returnStringMessage = dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString();
            return _returnStringMessage;
        }
        public static string GetEmailPass(string Email)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT smartpassword FROM [smart_emails] WHERE smartemail='" + Email + "'");
            _returnStringMessage = dbManager.ExecuteScalar(CommandType.Text, _commandText).ToString();
            return _returnStringMessage;
        }



        public int tMaxEmpId;

        public string Empoyee_Save()
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("INSERT INTO Employee_Master SELECT ISNULL(MAX(EMP_ID),0)+1,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},'{9}','{10}','{11}','{12}',{13},{14},'{15}','{16}','{17}','{18}',{19},'{20}' FROM Employee_Master", EmpFirstName, EmpMiddleName, EmpLastName, EmpGender, EmpMobile, EmpPhone, EmpDOB, EmpEMail, tEmpPhoto, EmpAddress, EmpCity, EMPUserName, PASSWORD,CpId,PlantId,Empseries,sALARY,TDS,ACCOUNTNO,this.Grade,this.Status);
            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            _commandText = string.Format("SELECT MAX(EMP_ID) FROM Employee_Master");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            while (dbManager.DataReader.Read())
            {
                tMaxEmpId = int.Parse(dbManager.DataReader[0].ToString());
            }
            dbManager.DataReader.Close();
            _commandText = string.Format("INSERT INTO Employee_Details SELECT ISNULL(MAX(EMP_DET_ID),0)+1,{0},{1},{2},'{3}','{4}',{5},{6} FROM Employee_Details", tMaxEmpId, DeptID, DesgID, EmpDetDOJ, EmpDetDOT, '0', EmpTypeID);
            dbManager.ExecuteNonQuery(CommandType.Text, _commandText);



            _commandText = string.Format("INSERT INTO User_Master SELECT ISNULL(MAX(UserId),0)+1,'{0}','{1}','{2}','{3}',{4} FROM User_Master", this.EMPUserName, this.PASSWORD, "0", "0", tMaxEmpId);
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

        public string Employee_Update(string EmployeeId)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("UPDATE Employee_Master SET EMP_FIRST_NAME='{0}',EMP_MIDDLE_NAME='{1}',EMP_LAST_NAME='{2}',EMP_GENDER='{3}',EMP_MOBILE='{4}',EMP_PHONE='{5}',EMP_DOB='{6}',EMP_EMAIL='{7}',EMP_ADDRESS='{8}',EMP_CITY='{9}',EMP_USERNAME='{10}',EMP_PASSWORD='{11}',EMP_CPID={12},EMP_LEAVEAPPROVER_ID={13},EMP_NO='{14}',EMP_SALARY='{15}',EMP_TDS='{16}',BANK_ACCOUNT='{17}',GradeId={18},Status='{19}' where EMP_ID={20}", EmpFirstName, EmpMiddleName, EmpLastName, EmpGender, EmpMobile, EmpPhone, EmpDOB, EmpEMail, EmpAddress, EmpCity, EMPUserName, PASSWORD, CpId, PlantId, Empseries, sALARY, TDS, ACCOUNTNO, Grade,Status, EmployeeId);
            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            _commandText = string.Format("UPDATE Employee_Details SET DEPT_ID={0},DESG_ID={1},EMP_DET_DOJ='{2}',EMP_DET_DOT='{3}',BRAN_ID={4},EMP_TYPE_ID={5} where EMP_ID={6}", DeptID, DesgID, EmpDetDOJ, EmpDetDOT, '0', EmpTypeID, EmployeeId);
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

        public string Employee_Delete(string EmployeeId)
        {
            if (DeleteRecord("[Employee_Details]", "EMP_ID", EmployeeId) == true)
            {
                if (DeleteRecord("[Employee_Master]", "EMP_ID", EmployeeId) == true)
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


        ///Update Status to Delete
        ///


        public string EmployeeStatus_Update(string EmployeeId)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
           // this.Status = "Inactive";
            _commandText = string.Format("UPDATE Employee_Master SET Status='Inactive' where EMP_ID={0}", EmployeeId);
            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
          
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

    }




    //Methods For JobOpenings Form
    public class JobOpenings
    {
        public string JOId, JobTitle, Status, Description, Createdon;        // JobOpenings
        public JobOpenings()
        { }

        public string JobOpenings_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[JobOpenings]", "Job_Title", this.JobTitle) == false)
            {
                _commandText = string.Format("INSERT INTO [JobOpenings] SELECT ISNULL(MAX(JobOpening_id),0)+1,'{0}','{1}','{2}','{3}' FROM [JobOpenings]", this.JobTitle, this.Status, this.Description, this.Createdon);
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

        public string JobOpenings_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[JobOpenings]", "Job_Title", this.JobTitle, "JobOpening_id", this.JOId) == false)
            {
                _commandText = string.Format("UPDATE [JobOpenings] SET Job_Title='{0}',Status='{1}',Description='{2}',Created_On='{3}' WHERE JobOpening_id={4}", this.JobTitle, this.Status,this.Description,this.Createdon, this.JOId);
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
                _returnStringMessage = "Opening Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string JobOpenings_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[JobOpenings]", "JobOpening_id", this.JOId) == true)
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

        public static void JobOpenings_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [JobOpenings] where Status != 'Closed'");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Job_Title", "JobOpening_id");
            }
        }


        public int JobOpenings_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [JobOpenings] where JobOpenings.JobOpening_id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.JOId = dbManager.DataReader["JobOpening_id"].ToString();
                    this.JobTitle = dbManager.DataReader["Job_Title"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();
                    this.Description = dbManager.DataReader["Description"].ToString();
                    this.Createdon = Convert.ToDateTime(dbManager.DataReader["Created_On"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
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



    //Methods For JobApplicant Form
    public class JobApplicant
    {
        public string JAId, ApplicantName, JobOpeningId, ApplicantEmail, Status, CoverLetter, Attachment;        // JobApplicant
        public JobApplicant()
        { }

        public string JobApplicant_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[JobApplicant]", "Applicant_Name", this.ApplicantName) == false)
            {
                _commandText = string.Format("INSERT INTO [JobApplicant] SELECT ISNULL(MAX(JobApplicant_Id),0)+1,'{0}',{1},'{2}','{3}','{4}','{5}' FROM [JobApplicant]", this.ApplicantName, this.JobOpeningId, this.ApplicantEmail, this.Status, this.CoverLetter, this.Attachment);
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

        public string JobApplicant_Update()
        {
            dbManager.Open();
           
                _commandText = string.Format("UPDATE [JobApplicant] SET Applicant_Name='{0}',JobOpening_Id= {1},Applicant_Email='{2}',Status='{3}',CoverLetter='{4}' WHERE JobApplicant_Id={6}", this.ApplicantName, this.JobOpeningId, this.ApplicantEmail, this.Status, this.CoverLetter, this.JAId);
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
        public string JobApplicantResume_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [JobApplicant] SET Attachement='{0}' WHERE JobApplicant_Id={1}", this.Attachment, this.JAId);
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
        public string JobApplicant_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[JobApplicant]", "JobApplicant_Id", this.JAId) == true)
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

        public static void JobApplicant_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [JobApplicant] ORDER BY Applicant_Name ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Applicant_Name", "JobApplicant_Id");
            }
        }


        public int JobApplicant_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [JobApplicant] where JobApplicant.JobApplicant_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.JAId = dbManager.DataReader["JobApplicant_Id"].ToString();
                    this.ApplicantName = dbManager.DataReader["Applicant_Name"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();
                    this.CoverLetter = dbManager.DataReader["CoverLetter"].ToString();
                    this.Attachment = dbManager.DataReader["Attachement"].ToString();
                    this.JobOpeningId = dbManager.DataReader["JobOpening_Id"].ToString();
                    this.ApplicantEmail = dbManager.DataReader["Applicant_Email"].ToString();
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






    //Methods For OfferTerms Master
    public class OfferTerms
    {
        public string OfferTermsId, OfferTerm, OfferTermsDesc;   //OfferTerms Master 
        public OfferTerms()
        {
        }

        public string OfferTerms_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[OfferTerms]", "Offer_term", this.OfferTerm) == false)
            {
                _commandText = string.Format("INSERT INTO [OfferTerms] SELECT ISNULL(MAX(Offerterm_id),0)+1,'{0}','{1}' FROM [OfferTerms]", this.OfferTerm, this.OfferTermsDesc);
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
                _returnStringMessage = "OfferTerms Already Exists.";
            }
            return _returnStringMessage;
        }

        public string OfferTerms_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[OfferTerms]", "Offer_term", this.OfferTerm, "Offerterm_id", this.OfferTermsId) == false)
            {
                _commandText = string.Format("UPDATE [OfferTerms] SET Offer_term='{0}',Description='{1}' WHERE Offerterm_id={2}", this.OfferTerm, this.OfferTermsDesc, this.OfferTermsId);
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
                _returnStringMessage = "OfferTerms Already Exists.";
            }
            return _returnStringMessage;
        }

        public string OfferTerms_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[OfferTerms]", "Offerterm_id", this.OfferTermsId) == true)
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

        public static void OfferTerms_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [OfferTerms] ORDER BY Offer_term");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Offer_term", "Offerterm_id");
            }
            else if (ControlForBind is GridView)
            {
                
            }
        }


        public int OfferTerms_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [OfferTerms] where OfferTerms.Offerterm_id=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.OfferTermsId = dbManager.DataReader["Offerterm_id"].ToString();
                    this.OfferTerm = dbManager.DataReader["Offer_term"].ToString();
                    this.OfferTermsDesc = dbManager.DataReader["Description"].ToString();

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




    //Methods For OfferLetter Master
    public class OfferLetter
    {
        public string OfferLetterId, JobappId, offerdate, Status, Designationid, Termsandconditions,offerNo;   //OfferLetter Master 

        public string offerdetid, offerterm, offerdescription;

        public OfferLetter()
        {
        }


        public static string OfferLetter_AutoGenCode()
        {
            return AutoGenMaxNo("OfferLetter", "Offer_No");
        }



        public string OfferLetter_Save()
        {
            this.OfferLetterId = AutoGenMaxId("[OfferLetter]", "OfferLetter_Id");
            this.offerNo = AutoGenMaxNo("OfferLetter", "Offer_No");
            dbManager.Open();
            if (IsRecordExists("[OfferLetter]", "JobApp_Id", this.JobappId) == false)
            {
               // _commandText = string.Format("INSERT INTO [OfferLetter] SELECT ISNULL(MAX(OfferLetter_Id),0)+1,{0},'{1}','{2}',{3},'{4}','{5}' FROM [OfferLetter]", this.JobappId, this.offerdate, this.Status, this.Designationid, this.Termsandconditions,this.offerNo);
               
                 _commandText = string.Format("INSERT INTO [OfferLetter] VALUES({0},{1},'{2}','{3}',{4},'{5}','{6}')",
                    this.OfferLetterId, this.JobappId, this.offerdate, this.Status, this.Designationid, this.Termsandconditions, this.offerNo);

                
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
                _returnStringMessage = "OfferLetter Already Exists.";
            }
            return _returnStringMessage;
        }




        public string OfferLetterDetails_Save()
        {
            dbManager.Open();

            _commandText = string.Format("INSERT INTO [OfferLetter_Details] SELECT ISNULL(MAX(OfferletterDetails_Id),0)+1,'{0}','{1}','{2}' FROM [OfferLetter_Details]", this.offerterm, this.offerdescription, this.OfferLetterId);
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




        public string OfferLetter_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[OfferLetter]", "JobApp_Id", this.JobappId, "OfferLetter_Id", this.OfferLetterId) == false)
            {
                _commandText = string.Format("UPDATE [OfferLetter] SET JobApp_Id={0},JobOffer_Date='{1}',Status='{2}',Desgination_Id={3},TermsandConditions='{4}',Offer_No='{5}' WHERE OfferLetter_Id={6}", this.JobappId, this.offerdate, this.Status, this.Designationid, this.Termsandconditions,this.offerNo, this.OfferLetterId);
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
                _returnStringMessage = "OfferLetter Already Exists.";
            }
            return _returnStringMessage;
        }

        public string OfferLetter_Delete()
        {
            HR.BeginTransaction();
            if (DeleteRecord("[OfferLetter]", "OfferLetter_Id", this.OfferLetterId) == true)
            {
                if (DeleteRecord("[OfferLetter_Details]", "OfferLetter_Id", this.OfferLetterId) == true)
                        {
                            HR.CommitTransaction();
                            _returnStringMessage = "Data Deleted Successfully";
                        }
                        else
                        {
                            HR.RollBackTransaction();
                            _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";
                        }
            }
            else
            {
                HR.RollBackTransaction();
                _returnStringMessage = "This Record cannot be deleted. It has been used as reference in other forms.........";

            }
            return _returnStringMessage;
        }

        public int OfferLetterDetails_Delete(string offid)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("DELETE FROM [OfferLetter_Details] WHERE OfferLetter_Id = {0}", offid);
            _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
            return _returnIntValue;
        }
        public int OfferLetter_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [OfferLetter] where OfferLetter.OfferLetter_Id=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.OfferLetterId = dbManager.DataReader["OfferLetter_Id"].ToString();
                    this.JobappId = dbManager.DataReader["JobApp_Id"].ToString();
                    this.offerdate = dbManager.DataReader["JobOffer_Date"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();
                    this.Designationid = dbManager.DataReader["Desgination_Id"].ToString();
                    this.Termsandconditions = dbManager.DataReader["TermsandConditions"].ToString();
                    this.offerNo = dbManager.DataReader["Offer_No"].ToString();


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




        public void OfferLetterDetails_Select(string QuotationId, GridView gv)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            _commandText = string.Format("SELECT * FROM [OfferLetter_Details] where [OfferLetter_Details].OfferLetter_Id=" + QuotationId + "");
            dbManager.ExecuteReader(CommandType.Text, _commandText);

            DataTable SalesQuotationItems = new DataTable();
            DataColumn col = new DataColumn();
            col = new DataColumn("OfferTerms");
            SalesQuotationItems.Columns.Add(col);
            col = new DataColumn("Description");
            SalesQuotationItems.Columns.Add(col);


            while (dbManager.DataReader.Read())
            {
                DataRow dr = SalesQuotationItems.NewRow();
                dr["OfferTerms"] = dbManager.DataReader["OfferTerm"].ToString();
                dr["Description"] = dbManager.DataReader["Offerterm_Decription"].ToString();


                SalesQuotationItems.Rows.Add(dr);
            }

            gv.DataSource = SalesQuotationItems;
            gv.DataBind();
        }







    }




    //Methods For LeaveType Form
    public class LeaveType
    {
        public string LeaveTypeId, LeaveType_name, MaxDay_Allowed, ISCarryForword, IsLeavewithoutPay, AllowNegitiveBalance, IncludeHolidayswithinLeaveasLeave;        // 
        public LeaveType()
        { }


       

        public string LeaveType_Save()
        {
            dbManager.Open();
           
                _commandText = string.Format("INSERT INTO [LeaveType] SELECT ISNULL(MAX(LeaveType_Id),0)+1,'{0}',{1},'{2}','{3}','{4}','{5}' FROM [LeaveType]", this.LeaveType_name, this.MaxDay_Allowed, this.ISCarryForword, this.IsLeavewithoutPay, this.AllowNegitiveBalance, this.IncludeHolidayswithinLeaveasLeave);
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

        public string LeaveType_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[LeaveType]", "LeaveType_name", this.LeaveType_name, "LeaveType_Id", this.LeaveTypeId) == false)
            {
                _commandText = string.Format("UPDATE [LeaveType] SET LeaveType_name='{0}',MaxDay_Allowed={1},ISCarryForword='{2}',IsLeavewithoutPay='{3}',AllowNegitiveBalance='{4}',IncludeHolidayswithinLeaveasLeave='{5}' WHERE LeaveType_Id={6}", this.LeaveType_name, this.MaxDay_Allowed, this.ISCarryForword, this.IsLeavewithoutPay, this.AllowNegitiveBalance, this.IncludeHolidayswithinLeaveasLeave, this.LeaveTypeId);
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
                _returnStringMessage = "Opening Name Already Exists.";
            }
            return _returnStringMessage;
        }

        public string LeaveType_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[LeaveType]", "LeaveType_Id", this.LeaveTypeId) == true)
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

        public static void LeaveType_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [LeaveType] ORDER BY LeaveType_name ");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "LeaveType_name", "LeaveType_Id");
            }
        }


        public int LeaveType_Select(string Code)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [LeaveType] where LeaveType.LeaveType_Id =" + Code + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.LeaveTypeId = dbManager.DataReader["LeaveType_Id"].ToString();
                    this.LeaveType_name = dbManager.DataReader["LeaveType_name"].ToString();
                    this.MaxDay_Allowed = dbManager.DataReader["MaxDay_Allowed"].ToString();
                    this.ISCarryForword = dbManager.DataReader["ISCarryForword"].ToString();
                    this.IsLeavewithoutPay = dbManager.DataReader["IsLeavewithoutPay"].ToString();

                    this.AllowNegitiveBalance = dbManager.DataReader["AllowNegitiveBalance"].ToString();
                    this.IncludeHolidayswithinLeaveasLeave = dbManager.DataReader["IncludeHolidayswithinLeaveasLeave"].ToString();

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







    //Methods For Leave_Application Master
    public class Leave_Application
    {
        public string Leave_ApplicationId, LapNo, LeavetypeId, Status, fromdate, todate, reason, halfday, halfdaydate, empid, LeaveapproverId, Postingdate,HrId,Noofdays,addresswhileonleave,cl,el,lop,HRstatus,HodStatus;   //Leave_Application Master 
        public Leave_Application()
        {
        }

        public static string Leave_Application_AutoGenCode()
        {
            return AutoGenMaxNo("Leave_Application", "Lap_No");
        }

        public string Leave_Application_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Leave_Application]", "Lap_No", this.LapNo) == false)
            {
                _commandText = string.Format("INSERT INTO [Leave_Application] SELECT ISNULL(MAX(Lap_id),0)+1,'{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}',{8},{9},'{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}' FROM [Leave_Application]", this.LapNo, this.LeavetypeId, this.Status, this.fromdate, this.todate, this.reason, this.halfday, this.halfdaydate, this.empid, this.LeaveapproverId, this.Postingdate,this.HrId,this.Noofdays,this.addresswhileonleave,this.cl,this.el,this.lop,this.HRstatus,this.HodStatus);
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
                _returnStringMessage = "Leave_Application Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Leave_Application_Update()
        {
            dbManager.Open();
            //if (IsRecordExists("[Leave_Application]", "Lap_No", this.LapNo, "Lap_id", this.Leave_ApplicationId) == false)
            //{
                _commandText = string.Format("UPDATE [Leave_Application] SET Lap_No='{0}',LeaveType_Id={1},Status='{2}',From_date='{3}',To_date='{4}',Reason='{5}',Halfday='{6}',Halfday_date='{7}',Emp_Id={8},Leaveapprover_id={9},Posting_date='{10}',Hr_Id='{11}',NoofDays='{12}',AddressWhileLeave='{13}',CL='{14}',EL='{15}',LOP='{16}',Hrstatus='{17}',HodStatus='{18}' WHERE Lap_id={19}", this.LapNo, this.LeavetypeId, this.Status, this.fromdate, this.todate, this.reason, this.halfday, this.halfdaydate, this.empid, this.LeaveapproverId, this.Postingdate,this.HrId,this.Noofdays,this.addresswhileonleave,this.cl,this.el,this.lop,this.HRstatus,this.HodStatus, this.Leave_ApplicationId);
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
            //    _returnStringMessage = "Leave_Application Already Exists.";
            //}
            return _returnStringMessage;
        }



        public string Leave_ApplicationApprove_Update()
        {
            dbManager.Open();
            //if (IsRecordExists("[Leave_Application]", "Lap_No", this.LapNo, "Lap_id", this.Leave_ApplicationId) == false)
            //{
            _commandText = string.Format("UPDATE [Leave_Application] SET HodStatus='{0}' WHERE Lap_id={1}",  this.Status, this.Leave_ApplicationId);
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
            //    _returnStringMessage = "Leave_Application Already Exists.";
            //}
            return _returnStringMessage;
        }

        public string Leave_Application_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Leave_Application]", "Lap_id", this.Leave_ApplicationId) == true)
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

        public static void Leave_Application_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Leave_Application] ORDER BY Lap_No");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "Lap_No", "Lap_id");
            }
            else if (ControlForBind is GridView)
            {

            }
        }


        public int Leave_Application_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Leave_Application] where Leave_Application.Lap_id=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Leave_ApplicationId = dbManager.DataReader["Lap_id"].ToString();
                    this.LapNo = dbManager.DataReader["Lap_No"].ToString();
                    this.LeavetypeId = dbManager.DataReader["LeaveType_Id"].ToString();


                    this.Status = dbManager.DataReader["Status"].ToString();
                    this.fromdate = Convert.ToDateTime(dbManager.DataReader["From_date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.todate = Convert.ToDateTime(dbManager.DataReader["To_date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.reason = dbManager.DataReader["Reason"].ToString();
                    this.halfday = dbManager.DataReader["Halfday"].ToString();
                    this.halfdaydate = Convert.ToDateTime(dbManager.DataReader["Halfday_date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);


                    this.empid = dbManager.DataReader["Emp_Id"].ToString();
                    this.LeaveapproverId = dbManager.DataReader["Leaveapprover_id"].ToString();
                    this.Postingdate = Convert.ToDateTime(dbManager.DataReader["Posting_date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                    this.HrId = dbManager.DataReader["Hr_Id"].ToString();
                    this.Noofdays = dbManager.DataReader["NoofDays"].ToString();
                    this.addresswhileonleave = dbManager.DataReader["AddressWhileLeave"].ToString();
                    this.cl = dbManager.DataReader["CL"].ToString();

                    this.el = dbManager.DataReader["EL"].ToString();
                    this.lop = dbManager.DataReader["LOP"].ToString();


                    this.HRstatus = dbManager.DataReader["Hrstatus"].ToString();
                    this.HodStatus = dbManager.DataReader["HodStatus"].ToString();



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




        public string Leaves_Update(string empid, string causualleaves, string Earnedleaves)
        {
            if (dbManager.Transaction == null)
                dbManager.Open();
            if (IsRecordExists("[Leave_tbl]", "EMP_Id", empid) == true)
            {
                _commandText = string.Format("UPDATE [Leave_tbl] SET  Casual_Leaves = Casual_Leaves-'{0}',Earned_Leaves= Earned_Leaves-'{1}' WHERE EMP_Id = {2}", causualleaves, Earnedleaves, empid);
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







    //Methods For Salary_Component Master
    public class Salary_Component
    {
        public string Salary_ComponentId, SalaryComName, Type, Description,MaxAmount;   //Salary_Component Master 
        public Salary_Component()
        {
        }

        public string Salary_Component_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Salary_Component]", "SalaryComp_Name", this.SalaryComName) == false)
            {
                _commandText = string.Format("INSERT INTO [Salary_Component] SELECT ISNULL(MAX(SalaryComp_id),0)+1,'{0}','{1}','{2}','{3}' FROM [Salary_Component]", this.SalaryComName, this.Type, this.Description,this.MaxAmount);
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
                _returnStringMessage = "Salary_Component Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Salary_Component_Update()
        {
            dbManager.Open();
            if (IsRecordExists("[Salary_Component]", "SalaryComp_Name", this.SalaryComName, "SalaryComp_id", this.Salary_ComponentId) == false)
            {
                _commandText = string.Format("UPDATE [Salary_Component] SET SalaryComp_Name='{0}',Type='{1}',Description='{2}',Max_Amount='{3}' WHERE SalaryComp_id={4}", this.SalaryComName, this.Type, this.Description,this.MaxAmount, this.Salary_ComponentId);
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
                _returnStringMessage = "Salary_Component Already Exists.";
            }
            return _returnStringMessage;
        }

        public string Salary_Component_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Salary_Component]", "SalaryComp_id", this.Salary_ComponentId) == true)
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

        public static void Salary_Component_Select(Control ControlForBind)
        {
            dbManager.Open();
            _commandText = string.Format("SELECT * FROM [Salary_Component] ORDER BY SalaryComp_Name");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (ControlForBind is DropDownList)
            {
                DropDownListBind(ControlForBind as DropDownList, "SalaryComp_Name", "SalaryComp_id");
            }
            else if (ControlForBind is GridView)
            {

            }
        }


        public int Salary_Component_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Salary_Component] where Salary_Component.SalaryComp_id=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Salary_ComponentId = dbManager.DataReader["SalaryComp_id"].ToString();
                    this.SalaryComName = dbManager.DataReader["SalaryComp_Name"].ToString();
                    this.Type = dbManager.DataReader["Type"].ToString();
                    this.Description = dbManager.DataReader["Description"].ToString();
                    this.MaxAmount = dbManager.DataReader["Max_Amount"].ToString();
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












    //Methods For EmployeeAttendance Master
    public class Employee_Attendance
    {
        public string Attendance_Id, Attendance_Date, Emp_Id, Status;   //Employee_Attendance Master 
        public Employee_Attendance()
        {
        }

        public string EmployeeAttendance_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Employee_Attendance]", "Attendance_Date", this.Attendance_Date) == false)
            {
                _commandText = string.Format("INSERT INTO [Employee_Attendance] SELECT ISNULL(MAX(Attendance_Id),0)+1,'{0}',{1},'{2}' FROM [Employee_Attendance]", this.Attendance_Date, this.Emp_Id, this.Status);
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
                _returnStringMessage = "Employee Attendance Already Done.";
            }
            return _returnStringMessage;
        }

        public string Employee_Attendance_Update()
        {
            dbManager.Open();

            _commandText = string.Format("UPDATE [Employee_Attendance] SET Attendance_Date='{0}',Emp_Id={1},Status='{2}' WHERE Attendance_Id={3}", this.Attendance_Date, this.Emp_Id, this.Status, this.Attendance_Id);
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

        public string Employee_Attendance_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Employee_Attendance]", "Attendance_Id", this.Attendance_Id) == true)
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


        public int Employee_Attendance_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Employee_Attendance] where Employee_Attendance.Attendance_Id=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Attendance_Id = dbManager.DataReader["Attendance_Id"].ToString();
                    this.Attendance_Date = Convert.ToDateTime(dbManager.DataReader["Attendance_Date"].ToString()).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    this.Emp_Id = dbManager.DataReader["Emp_Id"].ToString();
                    this.Status = dbManager.DataReader["Status"].ToString();
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






        ////Attendance Tool

        #region EmpAttendance Select
        public DataTable EmpAttendance_Select(int BranchId)
        {
            DataTable dtable = new DataTable();
            DataColumn dcol = new DataColumn();
            dcol = new DataColumn("EMP_ID");
            dtable.Columns.Add(dcol);

            dbManager.Open();
            _commandText = string.Format("SELECT * FROM Employee_Master,Employee_Details WHERE Employee_Master.EMP_ID = Employee_Details.BRAN_ID and BRAN_ID = {0}", BranchId);
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            while (dbManager.DataReader.Read())
            {
                DataRow drow = dtable.NewRow();
                drow["EMP_ID"] = dbManager.DataReader[1].ToString();
                dtable.Rows.Add(drow);

            }
            dbManager.DataReader.Close();
            return dtable;
        }
        #endregion

        


    }


    #region IsRecordExistswithWhere
    public static bool IsRecordExists(string command)
    {
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
    #endregion	

    #region Employee Attendance Class
    public class EmployeeAttendance
    {
        #region EmployeeAttendance_Save
        public int EmployeeAttendance_Save(string EmpId, DateTime date, string status)
        {

            dbManager.Open();
            string sqlcmd;
            int count = 0;

            sqlcmd = "select count(*) from Employee_Attendance where Attendance_Date = '" + date.ToString("yyyy-MM-dd") + "' and Emp_Id = '" + EmpId + "'";

            if (HR.IsRecordExists(sqlcmd) == false)
            {

                _commandText = string.Format("INSERT INTO [Employee_Attendance] SELECT ISNULL(MAX(Attendance_Id),0)+1,'{0}',{1},'{2}' FROM [Employee_Attendance]", date.ToString("yyyy-MM-dd"), EmpId, status);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                count = count + 1;


            }
            else if (HR.IsRecordExists(sqlcmd) == true)
            {
                _commandText = string.Format("update Employee_Attendance set Status = '{0}' where Attendance_Date = '{1}' And Emp_Id = {2}", status, date, EmpId);
                _returnIntValue = dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                count = count + 1;

            }

            return count;

        }
        #endregion

    }
    #endregion

    #region Allowance_Setup
    public class AllowanceSetup
    {
        #region AllowanceSetup_Save
        public string AllowanceSetup_Save(int CategoryName, int AllowanceName, string Type, string Calculations, double Amount)
        {

            dbManager.Open();

            if (HR.IsRecordExists("SELECT COUNT(*) FROM Salary_Structure WHERE Categoryid =" + CategoryName + " AND ALLOWANCE_MASTER_ID=" + AllowanceName + "") == false)
            {
                _commandText = string.Format("INSERT INTO [Salary_Structure] SELECT ISNULL(MAX(ALLOWANCE_SETUP_ID),0)+1,{0},{1},'{2}','{3}','{4}' FROM [Salary_Structure]", CategoryName, AllowanceName, Type, Calculations, Amount);
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
        #endregion

        #region AllowanceSetup_UpDate
        public string AllowanceSetup_Update(int Id, int CategoryName, int AllowanceName, string Type, string Calculations, double Amount)
        {

            dbManager.Open();
          
            {
                _commandText = string.Format("UPDATE Salary_Structure SET Categoryid={0},ALLOWANCE_MASTER_ID={1},ALLOWANCE_SETUP_TYPE='{2}',ALLOWANCE_SETUP_CALCULATIONS='{3}',ALLOWANCE_SETUP_AMOUNT={4} WHERE ALLOWANCE_SETUP_ID={5}", CategoryName, AllowanceName, Type, Calculations, Amount, Id);
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
            //else
            //{
            //    _returnStringMessage = "Name Already Exists.";
            //}
           // dbManager.Dispose();
            return _returnStringMessage;


        }
        #endregion

        #region AllowanceSetup_Delete
        public string AllowanceSetup_Delete(int sno)
        {
            if (HR.DeleteRecord("Salary_Structure", "ALLOWANCE_SETUP_ID", sno.ToString()) == true)
            {
                _returnStringMessage = "Data Deleted Successfully";
            }
            else
            {
                _returnStringMessage = "Some Data Missing.";
            }
            return _returnStringMessage;
        }
        #endregion

        #region Allowance_Selected
        public string Allowance_Selected(int Id)
        {

            dbManager.Open();
            _commandText = string.Format("select ALLOWANCE_MASTER_AMOUNT from Salary_Structure where ALLOWANCE_MASTER_ID = {0}", Id);
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            if (dbManager.DataReader.Read())
                _returnStringMessage = dbManager.DataReader[0].ToString();
            dbManager.Dispose();
            return _returnStringMessage;

        }
        #endregion


        public string Id, Catid, Allowanceid, setuptype, Calcualtion, amount;


        public int Allowance_Setup_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Salary_Structure] where Salary_Structure.ALLOWANCE_SETUP_ID=" + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.Id = dbManager.DataReader["ALLOWANCE_SETUP_ID"].ToString();
                    this.Catid = dbManager.DataReader["Categoryid"].ToString();
                    this.Allowanceid = dbManager.DataReader["ALLOWANCE_MASTER_ID"].ToString();
                    this.setuptype = dbManager.DataReader["ALLOWANCE_SETUP_TYPE"].ToString();
                    this.Calcualtion = dbManager.DataReader["ALLOWANCE_SETUP_CALCULATIONS"].ToString();
                    this.amount = dbManager.DataReader["ALLOWANCE_SETUP_AMOUNT"].ToString();

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
    #endregion

    #region SalaryDetails
    public class SalaryDetails
    {
        public string EmpName, BasicSalary, Emp_Category_Id;
        #region SalaryDetails_Go
        public void SalaryDetails_Go(string EmpId)
        {
            dbManager.Open();

            _commandText = string.Format("select * from Employee_Master,Employee_Details  where  Employee_Master.EMP_ID = Employee_Details.EMP_ID  and  Employee_Master.EMP_ID ='" + EmpId + "'");
            dbManager.ExecuteReader(CommandType.Text, _commandText);
            while (dbManager.DataReader.Read())
            {

                EmpName = dbManager.DataReader["EMP_FIRST_NAME"].ToString();
                BasicSalary = dbManager.DataReader["EMP_SALARY"].ToString();
                Emp_Category_Id = dbManager.DataReader["DEPT_ID"].ToString();


            }

            dbManager.DataReader.Close();
        }
        #endregion

        #region SalaryDetails_Save
        public string SalaryDetails_Save(string empid, double basic, GridView gvSalary)
        {
            try
            {

                Double AMOUNT = 0;
                dbManager.Open();

               
                _commandText = string.Format("DELETE FROM [Employee_SalaryDetails] WHERE EMP_ID = '{0}'", empid);
                dbManager.ExecuteNonQuery(CommandType.Text, _commandText);


                foreach (GridViewRow gvr in gvSalary.Rows)
                {
                    CheckBox chkselect = gvr.FindControl("cblSelect") as CheckBox;
                    if ((chkselect != null) && chkselect.Checked)
                    {
                        if (gvr.Cells[5].Text == "AMOUNT")
                            AMOUNT = Convert.ToDouble(gvr.Cells[6].Text);
                        else if (gvr.Cells[5].Text == "PERCENTAGE")
                            AMOUNT = (basic * Convert.ToDouble(gvr.Cells[6].Text)) / 100;
                        if (HR.IsRecordExists("SELECT COUNT(*) FROM Employee_SalaryDetails WHERE EMP_ID =" + empid + " AND ALLOWANCE_SETUP_ID =" + gvr.Cells[1].Text + "") == false)
                        {
                            _commandText = string.Format("INSERT INTO [Employee_SalaryDetails] SELECT ISNULL(MAX(SALARY_ID),0)+1,'{0}',{1},'{2}',{3} FROM [Employee_SalaryDetails]", empid, gvr.Cells[1].Text, gvr.Cells[4].Text, AMOUNT);
                            dbManager.ExecuteNonQuery(CommandType.Text, _commandText);
                            _returnStringMessage = "Data Saved Successfully";
                        }
                        else
                        {
                            _returnStringMessage = "Already Alloweance set this Employee";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                _returnStringMessage = "Some Data Missing.";

            }
            finally
            {
                dbManager.Dispose();

            }
            return _returnStringMessage;
        }
        #endregion

    }


    #endregion









    //Methods For Employee CTC
    public class EmployeeCTC
    {
        public string CtcId, EmpId, DateCreated, EarningsBasicSalary, EarningsHouseRentallowance, EarningsCOnveyanceAllowance, EarningsMedicalAllowance,EarningsOtherAllowance, StatutoryPfcontributions, StatutoryEsicContribution, StatutoryProfessionaltax, StContributionpfconveyance, Stcontributionesicconveyance,Totalmonthly,Totalstatutorydeduction,TotalstatutoryContribution,TotalCtc,Netsalary,Preparedby;

        public string CausalLeaves, EarnedLeaves;
        
        public EmployeeCTC()
        {
        }

        public string EmployeeCTC_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Employee_CTC]", "Emp_Id", this.EmpId) == false)
            {

               
                _commandText = string.Format("INSERT INTO [Employee_CTC] SELECT ISNULL(MAX(Ctc_id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}',{17} FROM [Employee_CTC]", this.EmpId, this.DateCreated, this.EarningsBasicSalary, this.EarningsHouseRentallowance, this.EarningsCOnveyanceAllowance, this.EarningsMedicalAllowance,this.EarningsOtherAllowance, this.StatutoryPfcontributions, this.StatutoryEsicContribution, this.StatutoryProfessionaltax, this.StContributionpfconveyance, this.Stcontributionesicconveyance, this.Totalmonthly, this.Totalstatutorydeduction, this.TotalstatutoryContribution, this.TotalCtc,this.Netsalary,this.Preparedby);
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
                _commandText = string.Format("UPDATE [Employee_CTC] SET Emp_Id={0},DateCreated='{1}',Earnings_BasicSalary='{2}',Earnings_HouserentAllowance='{3}',Earnings_ConveyanceAllowance='{4}',Earnings_MedicalAllowance='{5}',Earingings_OtherAllowance='{6}',Statutory_PFContribution='{7}',Statutory_ESICContribution='{8}',Statutory_ProfessionalTax='{9}',StContribution_PFContribution='{10}',StContribution_ESICContribution='{11}',Total_Monthly='{12}',Total_StatutoryDeductions='{13}',Total_StatutoryContributions='{14}',Total_CTC='{15}',NetSalary='{16}',PreparedBy={17} WHERE Emp_Id={18}", this.EmpId, this.DateCreated, this.EarningsBasicSalary, this.EarningsHouseRentallowance, this.EarningsCOnveyanceAllowance, this.EarningsMedicalAllowance, this.EarningsOtherAllowance, this.StatutoryPfcontributions, this.StatutoryEsicContribution, this.StatutoryProfessionaltax, this.StContributionpfconveyance, this.Stcontributionesicconveyance, this.Totalmonthly, this.Totalstatutorydeduction, this.TotalstatutoryContribution, this.TotalCtc, this.Netsalary, this.Preparedby, this.EmpId);
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

        public string EmployeeCTC_Update()
        {
            dbManager.Open();
            
                _commandText = string.Format("UPDATE [Employee_CTC] SET Emp_Id={0},DateCreated='{1}',Earnings_BasicSalary='{2}',Earnings_HouserentAllowance='{3}',Earnings_ConveyanceAllowance='{4}',Earnings_MedicalAllowance='{5}',Earingings_OtherAllowance='{6}',Statutory_PFContribution='{7}',Statutory_ESICContribution='{8}',Statutory_ProfessionalTax='{9}',StContribution_PFContribution='{10}',StContribution_ESICContribution='{11}',Total_Monthly='{12}',Total_StatutoryDeductions='{13}',Total_StatutoryContributions='{14}',Total_CTC='{15}',NetSalary='{16}',PreparedBy={17} WHERE Ctc_id={18}", this.EmpId, this.DateCreated, this.EarningsBasicSalary, this.EarningsHouseRentallowance, this.EarningsCOnveyanceAllowance, this.EarningsMedicalAllowance,this.EarningsOtherAllowance, this.StatutoryPfcontributions, this.StatutoryEsicContribution, this.StatutoryProfessionaltax, this.StContributionpfconveyance, this.Stcontributionesicconveyance, this.Totalmonthly, this.Totalstatutorydeduction, this.TotalstatutoryContribution, this.TotalCtc,this.Netsalary,this.Preparedby, this.CtcId);
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

        public string EmployeeCTC_Delete()
        {
            Masters.BeginTransaction();
            if (DeleteRecord("[Employee_CTC]", "Ctc_id", this.CtcId) == true)
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

       

        public int EmployeeCTC_Select(string ItemCode)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Employee_CTC] where Emp_Id = " + ItemCode + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.EmpId = dbManager.DataReader["Emp_Id"].ToString();
                    this.DateCreated = dbManager.DataReader["DateCreated"].ToString();
                    this.EarningsBasicSalary = dbManager.DataReader["Earnings_BasicSalary"].ToString();
                    this.EarningsHouseRentallowance = dbManager.DataReader["Earnings_HouserentAllowance"].ToString();
                    this.EarningsCOnveyanceAllowance = dbManager.DataReader["Earnings_ConveyanceAllowance"].ToString();

                    this.EarningsMedicalAllowance = dbManager.DataReader["Earnings_MedicalAllowance"].ToString();
                    this.EarningsOtherAllowance = dbManager.DataReader["Earingings_OtherAllowance"].ToString();
                    this.StatutoryPfcontributions = dbManager.DataReader["Statutory_PFContribution"].ToString();
                    this.StatutoryEsicContribution = dbManager.DataReader["Statutory_ESICContribution"].ToString();
                    this.StatutoryProfessionaltax = dbManager.DataReader["Statutory_ProfessionalTax"].ToString();


                    this.StContributionpfconveyance = dbManager.DataReader["StContribution_PFContribution"].ToString();
                    this.Stcontributionesicconveyance = dbManager.DataReader["StContribution_ESICContribution"].ToString();
                    this.Totalmonthly = dbManager.DataReader["Total_Monthly"].ToString();
                    this.Totalstatutorydeduction = dbManager.DataReader["Total_StatutoryDeductions"].ToString();
                    this.TotalstatutoryContribution = dbManager.DataReader["Total_StatutoryContributions"].ToString();
                    this.TotalCtc = dbManager.DataReader["Total_CTC"].ToString();
                    this.Netsalary = dbManager.DataReader["NetSalary"].ToString();
                   
                    
                    
                    
                    this.Preparedby = dbManager.DataReader["PreparedBy"].ToString();
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


        public string EmployeeLeaves_Save()
        {
            dbManager.Open();
            if (IsRecordExists("[Leave_tbl]", "EMP_Id", this.EmpId) == false)
            {
                _commandText = string.Format("INSERT INTO [Leave_tbl] VALUES({0},'{1}','{2}')", this.EmpId, this.CausalLeaves, this.EarnedLeaves);
                //_commandText = string.Format("INSERT INTO [Leave_tbl] SELECT ISNULL(MAX(Ctc_id),0)+1,{0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}',{17} FROM [Employee_CTC]", this.EmpId, this.DateCreated, this.EarningsBasicSalary, this.EarningsHouseRentallowance, this.EarningsCOnveyanceAllowance, this.EarningsMedicalAllowance, this.EarningsOtherAllowance, this.StatutoryPfcontributions, this.StatutoryEsicContribution, this.StatutoryProfessionaltax, this.StContributionpfconveyance, this.Stcontributionesicconveyance, this.Totalmonthly, this.Totalstatutorydeduction, this.TotalstatutoryContribution, this.TotalCtc, this.Netsalary, this.Preparedby);
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
                _commandText = string.Format("UPDATE [Leave_tbl] SET Casual_Leaves='{0}',Earned_Leaves='{1}' WHERE EMP_Id={2}", this.CausalLeaves,this.EarnedLeaves,this.EmpId);
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
            return _returnStringMessage;
        }




        public int EmployeeleavesAvailable_Select(string empid)
        {
            dbManager.Open();
            try
            {
                _commandText = string.Format("SELECT * FROM [Leave_tbl] where EMP_Id = " + empid + " ");

                dbManager.ExecuteReader(CommandType.Text, _commandText);
                if (dbManager.DataReader.Read())
                {
                    this.CausalLeaves = dbManager.DataReader["Casual_Leaves"].ToString();
                    this.EarnedLeaves = dbManager.DataReader["Earned_Leaves"].ToString();
                 
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

