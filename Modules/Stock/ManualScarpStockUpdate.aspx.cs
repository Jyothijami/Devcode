using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Stock_ManualScarpStockUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Masters.MaterialMaster.MaterialMaster_Select(ddlItemCode);
            Masters.ColorMaster.Color_Select(ddlColor);
            Masters.Plant.Plant_Select(ddlPlant);
            Masters.StorageLocation.StorageLocation_Select(ddlStroageLoaction);

        }
    }
    protected void ddlItemCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.MaterialMaster obj = new Masters.MaterialMaster();
        if (obj.MaterialType_Select(ddlItemCode.SelectedItem.Value) > 0)
        {
            txtUom.Text = obj.UomName;
            txtCategory.Text = obj.CategoryName;
            txtLength.Text = obj.BarLength;
        }
    }
    protected void ddlPlant_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.StorageLocation.PlantStorageLocation_Select(ddlStroageLoaction, ddlPlant.SelectedItem.Value);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SCM.PurchaseReceipt objSM = new SCM.PurchaseReceipt();
        objSM.matid = ddlItemCode.SelectedItem.Value;
        objSM.aCCEPTEDQTY = txtQtytoUpdate.Text;
        objSM.plantid = ddlPlant.SelectedItem.Value;
        objSM.colorid = ddlColor.SelectedItem.Value;
        objSM.storagelocid = ddlStroageLoaction.SelectedItem.Value;
        objSM.length = txtLength.Text;
        objSM.ScrapStock_Update1(objSM.matid, objSM.aCCEPTEDQTY, objSM.plantid, objSM.colorid, objSM.storagelocid, objSM.length);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
    }
}