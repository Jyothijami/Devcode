using phani.MessageBox;
using System;
using phani.Classes;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;



public partial class Modules_Masters_Item_Details_ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            Plant_Fill();
            Category_Fill();
            uom_fILL();
            itemgroup_Fill();

            Masters.CompanyProfile.Company_Select(ddlCompany);
            Masters.Currency.Currency_Select(ddlCurency);
            Masters.Currency.Currency_Select(ddlsellingcurrency);
            Masters.ItemBrand.ItemBrand_Select(ddlBrand);
            Masters.ItemSeries.ItemSeries_Select(ddlitemseries);


          //  Masters.CheckboxListWithStatement(chkItemColor, "select Color_Id,Color_Name from Color_Master");
           // BindList();
            if (Qid != "Add")
            {

                ItemDetails_Fill();

            }
        }
    }

    private void itemgroup_Fill()
    {
        Masters.MaterialType.MaterialType_Select(ddlItemGroup);
    }
   
    private void uom_fILL()
    {
        Masters.UnitMaster.UnitMaster_Select(ddlUom);
      

    }

    private void ItemDetails_Fill()
    {
        Masters.MaterialMaster obj = new Masters.MaterialMaster();
        if(obj.MaterialType_Select(Request.QueryString["Cid"].ToString()) > 0)
        {


            ddlitemseries.SelectedValue = obj.Itemseries;
            ddlCompany.SelectedValue = obj.Companyid;
            ddlCurency.SelectedValue = obj.BuyingCurrency;
            ddlBrand.SelectedValue = obj.BrandId;
            txtBuyingPrice.Text = obj.BuyingPrice;
            ddlItemGroup.SelectedValue = obj.ItemGroup;
            txtItemCode.Text = obj.MatCode;
            ddlCategory.SelectedValue = obj.Catid;
            ddlItemGroup.SelectedValue = obj.ItemGroup;
            txtlength.Text = obj.BarLength;
            txtDescription.Text = obj.Description;
            txtboxsize.Text = obj.Boxsize;
            ddlUom.SelectedValue = obj.Uomid;
            txtWeight.Text = obj.weight;
            ddlplant.SelectedValue = obj.plantid;
            ddlplant_SelectedIndexChanged(new object(), new System.EventArgs());
            ddlstoragelocation.SelectedValue = obj.StorageLocation;
            txtsellingprice.Text = obj.SellingPrice;
            ddlsellingcurrency.SelectedValue = obj.sellingCurrency;
            btnSave.Text = "Update";
            //DataTable dt = obj.ItemColor_Select(int.Parse(Request.QueryString["Cid"].ToString()));
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ListItem currentCheckBox = chkItemColor.Items.FindByValue(dt.Rows[i][0].ToString());
            //    if (currentCheckBox != null)
            //    {
            //        currentCheckBox.Selected = true;
            //    }
            //}
        }
        

    }

    private void Category_Fill()
    {
        Masters.ItemCategory.ItemCategory_Select(ddlCategory);
    }

    private void Plant_Fill()
    {
        Masters.Plant.Company_Plant_Select(ddlplant, "1");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            ItemSave();
        }
        else if (btnSave.Text == "Update")
        {
            ItemUpdate();
        }
    }

    private void ItemUpdate()
    {
        try
        {
            Masters.MaterialMaster obj = new Masters.MaterialMaster();
            obj.Matid = Request.QueryString["Cid"].ToString();
            obj.MatCode = txtItemCode.Text;
            obj.Uomid = ddlUom.SelectedItem.Value;
            obj.Catid = ddlCategory.SelectedItem.Value;
            obj.BarLength = txtlength.Text;
            obj.Description = txtDescription.Text;
            obj.Boxsize = txtboxsize.Text;
            obj.weight = txtWeight.Text;
            obj.plantid = ddlplant.SelectedItem.Value;
            obj.StorageLocation = ddlstoragelocation.SelectedItem.Value;
            obj.SellingPrice = txtsellingprice.Text;
            //  MessageBox.Show(this, obj.MaterialMaster_Update());
            obj.Itemseries = ddlitemseries.SelectedItem.Value;

            obj.sellingCurrency = ddlsellingcurrency.SelectedItem.Value;

            obj.Companyid = ddlCompany.SelectedItem.Value;
            obj.BuyingPrice = txtBuyingPrice.Text;
            obj.BuyingCurrency = ddlCurency.SelectedItem.Value;
            obj.BrandId = ddlBrand.SelectedItem.Value;
            obj.ItemGroup = ddlItemGroup.SelectedItem.Value;

            obj.Status = "Updated";

          //  obj.ItemColorDetails_Delete(Request.QueryString["Cid"].ToString());
            //for (int i = 0; i < chkItemColor.Items.Count; i++)
            //{
            //    if (chkItemColor.Items[i].Selected == true)
            //    {

            //        obj.ColorId = chkItemColor.Items[i].Value;
            //        obj.ItemColorDetails_save();
            //    }
            //    //else if (chkItemColor.Items[i].Selected != true)
            //    //{
            //    //    obj.ColorId = "0";
            //    //    obj.ItemColorDetails_save();
            //    //    //return;
            //    //}

            //}

            obj.MaterialMaster_Update();
            //if ( == "Data Updated Successfully")
            //{
                //for (int i = 0; i < chkItemColor.Items.Count; i++)
                //{
                //    if (chkItemColor.Items[i].Selected == true)
                //    {

                //        obj.ColorId = chkItemColor.Items[i].Value;
                //        obj.ItemColorDetails_save();
                //    }
                //    else if (chkItemColor.Items[i].Selected != true)
                //    {
                //        obj.ColorId = "0";
                //        obj.ItemColorDetails_save();
                //        return;
                //    }

                //}


                //obj.ItemColorDetails_Delete(Request.QueryString["Cid"].ToString());
                //for (int i = 0; i < chkItemColor.Items.Count; i++)
                //{
                //    if (chkItemColor.Items[i].Selected == true)
                //    {

                //        obj.ColorId = chkItemColor.Items[i].Value;
                //        obj.ItemColorDetails_save();
                //    }
                //    else if (chkItemColor.Items[i].Selected != true)
                //    {
                //        obj.ColorId = "0";
                //        obj.ItemColorDetails_save();
                //        return;
                //    }

                //}





            //}


        //    MessageBox.Show(this, "Data Updated Successfully");
          //  chkItemColor.ClearSelection();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);


        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            Masters.ClearControls(this);
            Masters.Dispose();
            //Response.Redirect("~/Modules/Masters/Item.aspx");
        }
    }

    private void ItemSave()
    {
        try
        {
            Masters.MaterialMaster obj = new Masters.MaterialMaster();

            obj.MatCode = txtItemCode.Text;
            obj.Uomid = ddlUom.SelectedItem.Value;
            obj.Catid = ddlCategory.SelectedItem.Value;
            obj.BarLength = txtlength.Text;
            obj.Description = txtDescription.Text;
            obj.Boxsize = txtboxsize.Text;
            obj.weight = txtWeight.Text;

            obj.plantid = ddlplant.SelectedItem.Value;
            obj.StorageLocation = ddlstoragelocation.SelectedItem.Value;
            obj.SellingPrice = txtsellingprice.Text;
            obj.Itemseries = ddlitemseries.SelectedItem.Value;


            obj.Companyid = ddlCompany.SelectedItem.Value;
            obj.BuyingPrice = txtBuyingPrice.Text;
            obj.BuyingCurrency = ddlCurency.SelectedItem.Value;
            obj.BrandId = ddlBrand.SelectedItem.Value;
            obj.sellingCurrency = ddlsellingcurrency.SelectedItem.Value;
            obj.ItemGroup = ddlItemGroup.SelectedItem.Value;
            obj.Status = "New";
            obj.ItemImage = "0x";

            MessageBox.Show(this, obj.MaterialMaster_BasicData_Save());

            //if (obj.MaterialMaster_BasicData_Save() == "Data Saved Successfully")
            //{
            //    //for (int i = 0; i < chkItemColor.Items.Count; i++)
            //    //{
            //    //    if (chkItemColor.Items[i].Selected == true)
            //    //    {

            //    //        obj.ColorId = chkItemColor.Items[i].Value;
            //    //        obj.ItemColorDetails_save();
            //    //    }
            //    //    else if (chkItemColor.Items[i].Selected != true)
            //    //    {
            //    //        obj.ColorId = "0";
            //    //        obj.ItemColorDetails_save();
            //    //        return;
            //    //    }

            //    //}
            //}



            
          //  MessageBox.Show(this, "Data Saved Successfully");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
           // chkItemColor.ClearSelection();
            Masters.ClearControls(this);
            Masters.Dispose();
          //  Response.Redirect("~/Modules/Masters/Item.aspx");
        }
    }

    protected void ddlplant_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if(ddlplant.SelectedItem.Value > 0)
        //{
            Masters.StorageLocation.PlantStorageLocation_Select(ddlstoragelocation, ddlplant.SelectedItem.Value);
       //}
       
    }

   
}