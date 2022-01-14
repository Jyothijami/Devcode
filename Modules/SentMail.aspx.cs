using phani.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_SentMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            General.GridBindwithCommand(hai, "select * from MailBox,Employee_Master where MailBox.ReceiverId = Employee_Master.EMP_ID and   SenderId = '" + Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId) + "' ");
        }
    }
    protected void hai_PreRender(object sender, EventArgs e)
    {
        if (hai.HeaderRow != null)
        {
            hai.UseAccessibleHeader = true;
            hai.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}