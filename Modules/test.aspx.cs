using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);

        if (!Page.IsPostBack)
        {
            //bind the gridview data
           
            hai1.DataBind();
        }
    }
    protected void hai1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    //add the thead and tbody section programatically
        //    e.Row.TableSection = TableRowSection.TableHeader;
        //}
    }

   
    protected void hai1_PreRender(object sender, EventArgs e)
    {
        this.DataBind();

        if (hai1.Rows.Count > 0)
        {
            //This replaces <td> with <th> and adds the scope attribute
            hai1.UseAccessibleHeader = true;

            //This will add the <thead> and <tbody> elements
            hai1.HeaderRow.TableSection = TableRowSection.TableHeader;

            //This adds the <tfoot> element.
            //Remove if you don't have a footer row
            hai1.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
}