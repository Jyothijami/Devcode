using phani.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_TableWiseData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "fnPageLoad()", true);
        if(!IsPostBack)
        {
            General.GridBindwithCommand(hai, "select Material_Code as Tool,isnull([1],0) as [Table 1],isnull([2],0) as  [Table 2],isnull([3],0) as [Table 3],isnull([4],0) as [Table 4],isnull([5],0) as [Table 5],isnull([6],0) as [Table 6],isnull([7],0) as [Table 7],isnull([8],0) as [Table 8],isnull([9],0) as [Table 9] from ( select Material_Code,TableId,Qty from Request_Tools_Details,Material_Master  where Request_Tools_Details.Item_Code = Material_Master.Material_Id)  up  pivot ( sum(Qty)  for [TableId] in ([1],[2],[3],[4],[5],[6],[7],[8],[9]))as r");
        }
    }
}