using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Phani.Modules;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;


/// <summary>
/// Summary description for UserName
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 

    
 [System.Web.Script.Services.ScriptService]
public class UserName : System.Web.Services.WebService {

    public UserName () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    
    public void UserNameExists(string userName) 
    { 
        string mobileno = string.Empty,email = string.Empty;
        bool userNameInUse = false;
        string cs = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs)) 
        {
            SqlCommand cmd = new SqlCommand("spUserNameExists", con); 
            cmd.CommandType = CommandType.StoredProcedure; 
            cmd.Parameters.Add(new SqlParameter() 
            { 
                ParameterName = "@UserName",
                Value = userName 
            }); 
            con.Open(); 
            userNameInUse = Convert.ToBoolean(cmd.ExecuteScalar()); 
        }
        SM.CustomerMaster regsitration = new SM.CustomerMaster(); 
        regsitration.CustName = userName; 
        regsitration.UserNameInUse = userNameInUse;
        regsitration.CustMobile = mobileno;
        regsitration.CustEmail = email;
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(regsitration));
    }



  
   






} 











    

