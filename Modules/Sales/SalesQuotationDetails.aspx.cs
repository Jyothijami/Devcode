using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_SalesQuotationDetails : System.Web.UI.Page
{

    
       
    protected void Page_Load(object sender, EventArgs e)
    {
        //PostBackTrigger trigger = new PostBackTrigger();
        //UpdatePanel updatePanel = (UpdatePanel)Page.Master.FindControl("UpdatePanel1");
        //trigger.ControlID = btnUploadExcel.UniqueID;
        //updatePanel.Triggers.Add(trigger);

        this.MaintainScrollPositionOnPostBack = true;
        txtItemQty.Attributes.Add("onkeyup", "javascript:ItemArea();");
        txttax.Attributes.Add("onkeyup", "javascript:grosscalc();");
        txtdiscount.Attributes.Add("onkeyup", "javascript:grosscalc();");
        string Qid = Request.QueryString["Cid"].ToString();
        if(!IsPostBack)
        {
           // gvitems.DataBind();
       
          
            show();

            Clearlabel();
            SM.CustomerMaster.CustomerMaster_Select(ddlcustomer);
            Masters.PaymentTerms.Payment_Select(ddlpaymentterms);
            Masters.SalesTermsConditions.SalesTermsConditions_Select(ddltermscondtions);
            SM.CustomerMaster.CustomerUnit_Select(ddlsite);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlSalesEmployee);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlpreparedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlapprovedby);
            HR.EmployeeMaster.EmployeeMaster_Select(ddlDesigner);
            SM.SalesEnquiry.SalesEnquiry_Select(ddlEnquiryNo);
            Masters.SalesDamage.SalesDamage_Select(ddlDamageTerms);
            Masters.Installationtech.Installationtech_Select(ddlInstallation);
            Masters.SalesStorage.SalesStorage_Select(ddlStroageTerms);

            txtdiscount.Text = txttax.Text = txttotal.Text = txtsubtotal.Text = "0";
            txtquatationno.Text = SM.SalesQuotation.SalesQuotation_AutoGenCode();
            txtquotationdate.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtValidto.Text = DateTime.Now.AddDays(15).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (Qid != "Add")
            {
                QuatationFill();
                btnSave.Visible = true;
                btnSave.Text = "Update";
                btnPrint.Visible = true;
                btnOptions.Visible = true;
            }
            else
            {
                ddlpreparedby.SelectedValue = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
                btnPrint.Visible = false;
                btnRevise.Visible = false;
                btnApprove.Visible = false;
                btnOptions.Visible = false;
            }
        }
    }
    protected void Page_InitComplete(object sender, EventArgs e)
    {
       
    }  
    private void Clearlabel()
    {
        lblTotalProfileCost.Text = "0";
        lblTotalWastageCost.Text = "0";
        lbltotalGlasspriceCost.Text = "0";
        lbltotalMsCost.Text = "0";
        lbltotalWallplugwithscrews.Text = "0";
        lbltotalSilicon.Text = "0";
        lbltotalmaskingtape.Text = "0";
        lbltotalBackersRod.Text = "0";
        lbltotalSSmesh.Text = "0";
        lbltotalRecractableMesh.Text = "0";
        lbltotalfabrication.Text = "0";
        lbltotalinstallation.Text = "0";
        lbltotalCost.Text = "0";
        lbltotalmargin.Text = "0";
        lbltotalamount.Text = "0";
        lblct.Text = "0";
        lbltotalextraglassprice.Text = "0";
    }

    private void show()
    {
        Masters.QuatationChangables obj = new Masters.QuatationChangables();
        if (obj.QuatationChangables_Select() > 0)
        {
            txtEuroPrice.Text = obj.EuroPrice;
            txtFreight.Text = obj.Freight;
            txtCustoms.Text = obj.Customes;
            txtInsurance.Text = obj.Insurance;
            txtClearance.Text = obj.Clearance;
            txtwastage.Text = obj.Wastage;
            txtWallplugs.Text = obj.Wallplugs;
            txtSilicon.Text = obj.Silicon;
            txtmaskingpape.Text = obj.Maskingtape;
            txtbackrod.Text = obj.BackorRod;
            txtFabricationPersqft.Text = obj.FabricationPersqf;
            txtfabricationPersqmt.Text = obj.FabricationPersqm;
            txtinstallationpersqft.Text = obj.Installationpersft;
            txtInstallationpersqmt.Text = obj.InstallationPersqm;
            txtmargin.Text = obj.Margin;
            txtSiliconWidth.Text = obj.Siliconwidht;
            txtSiliconDepth.Text = obj.SiliconDepth;
        }
    }

    private void QuatationFill()
    {
        SM.SalesQuotation obj = new SM.SalesQuotation();
        if (obj.SalesQuotation_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
             btnSave.Text = "Update";
            //btnRevise.Text = "Modify";
            txtquatationno.Text = obj.QuotNo;
            txtquotationdate.Text = obj.QuotDate;
            ddlquotationto.SelectedValue = obj.Quotto;
          

            ddlEnquiryNo.SelectedValue = obj.EnqId;
           

            if (obj.EnqId != "0")
            {
                panelEnquirydetails.Visible = true;
                ddlEnquiryNo_SelectedIndexChanged(new object(), new System.EventArgs());
            }
            else
            {
                panelEnquirydetails.Visible = false;
            }
            txtValidto.Text = obj.Validto;
            ddlcustomer.SelectedValue = obj.CustId;
            ddlcustomer_SelectedIndexChanged(new object(), new System.EventArgs());
            ddlsite.SelectedValue = obj.UnitId;
            ddlsite_SelectedIndexChanged(new object(), new System.EventArgs());
            ddlSalesEmployee.SelectedValue = obj.SalesEmpId;
            ddlpaymentterms.SelectedValue = obj.PaymentTermsId;
            // ddlpaymentterms_SelectedIndexChanged(new object(), new System.EventArgs());

            txtpaymenttermsdetails.Text = HttpUtility.HtmlDecode(obj.Paymentterms);

            ddltermscondtions.SelectedValue = obj.TermsCondtionId;
            //   ddltermscondtions_SelectedIndexChanged(new object(), new System.EventArgs());
            txttermsconditions.Text = obj.TermsCondtions;

            obj.NewSalesQuotationDetails_Select(Request.QueryString["Cid"].ToString(), gvitems);


            txtdiscount.Text = obj.Discount;
            txttax.Text = obj.Tax;
            txttotal.Text = obj.GrandTotal;
            ddlpreparedby.SelectedValue = obj.Preparedby;
            ddlapprovedby.SelectedValue = obj.Approvedby;
            txtSpecifications.Text = HttpUtility.HtmlDecode(obj.Specifications);



            ddlInstallation.SelectedValue = obj.InstallationtempId;
            // ddlInstallation_SelectedIndexChanged(new object(), new System.EventArgs());
            txtInstallationTerms.Text = HttpUtility.HtmlDecode(obj.Installationterms);
            ddlDamageTerms.SelectedValue = obj.DamagetempId;
            // ddlDamageTerms_SelectedIndexChanged(new object(), new System.EventArgs());

            txtDamageterms.Text = HttpUtility.HtmlDecode(obj.DamageTerms);
            ddlStroageTerms.SelectedValue = obj.StroageTempId;
            //ddlStroageTerms_SelectedIndexChanged(new object(), new System.EventArgs());
            txtStroagetermsdetails.Text = HttpUtility.HtmlDecode(obj.StrorageTerms);
            ddlDesigner.SelectedValue = obj.DesignerId;


            txtaluminiumColor.Text = obj.AluminumColor;
            txtHardwareColoritem.Text = obj.HardwarecolorItem;
            txtWindload.Text = obj.Windload;
            lbloptions.Text = obj.Options;
            lblRevise.Text = obj.Revisedkey;
            txtHardwareColoritem.Text = obj.HardwareColor;

           
        }
    }

    
    protected void gvitems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;

            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[18].Visible = false;
            e.Row.Cells[19].Visible = false;

            e.Row.Cells[20].Visible = false;
            e.Row.Cells[21].Visible = false;

            e.Row.Cells[22].Visible = false;
            e.Row.Cells[23].Visible = false;
            e.Row.Cells[24].Visible = false;

            // e.Row.Cells[11].Visible = false;
        }

        GridViewRow row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Attributes.Add("onclick", "return confirm('Are you sure you want to remove this Item from Interested Products list?');");
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // e.Row.Cells[1].Attributes.Add("onclick", "return confirm('Are you sure you want to remove this Item from Item Details list?');");
            // e.Row.Cells[10].Text =Math.Round(Convert.ToDecimal(e.Row.Cells[8].Text) * Convert.ToDecimal(txtRatepersqmt.Text)).ToString();
            // string total = (gvitems.FindControl("txtitemamount") as TextBox).Text;
            // string price = ((TextBox)e.Row.Cells[10].FindControl("txtitemamount")).Text;

            //decimal _Price = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "txtitemamount"));
            //e.Row.Cells[11].Text = Math.Round(Convert.ToDecimal(e.Row.Cells[7].Text) * Convert.ToDecimal(_Price)).ToString();
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            txtsubtotal.Text = txttotal.Text = NetAmountCalc().ToString();
            // GrandTotal();
        }
    }

    //private void GrandTotal()
    //{
    //    float GTotal = 0f;
    //    for (int i = 0; i < gvitems.Rows.Count; i++)
    //    {
    //        String total = (gvitems.Rows[i].FindControl("txtitemamount") as TextBox).Text;
    //        GTotal += Convert.ToSingle(total);
    //    }
    //    txtsubtotal.Text = GTotal.ToString();
    //    txttotal.Text = GTotal.ToString();
    //}

    private double GrossAmountCalc()
    {
        double _totalAmt = 0;
        //  double gst = 0;
        foreach (GridViewRow gvrow in gvitems.Rows)
        {
            _totalAmt = _totalAmt + Convert.ToDouble(gvrow.Cells[11].Text);

            //   string total = (gvrow.FindControl("txtitemamount") as TextBox).Text;

            // _totalAmt = _totalAmt + Convert.ToDouble((gvrow.FindControl("txtitemamount") as TextBox).Text);
        }
        return _totalAmt;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (btnSave.Text == "Save")
        {
            SalesQuotationSave();
        }
        else if (btnSave.Text == "Update")
        {
            SalesQuotationUpdate();
        }
    }

    private void SalesQuotationUpdate()
    {
        try
        {
            SM.SalesQuotation objSM = new SM.SalesQuotation();
            objSM.QuotId = Request.QueryString["Cid"].ToString();
            objSM.QuotNo = txtquatationno.Text;
            objSM.QuotDate = General.toMMDDYYYY(txtquotationdate.Text);
            objSM.Quotto = ddlquotationto.SelectedItem.Value;

            objSM.Validto = General.toMMDDYYYY(txtValidto.Text);
            objSM.EnqId = ddlEnquiryNo.SelectedItem.Value;
            objSM.CustId = ddlcustomer.SelectedItem.Value;
            objSM.UnitId = ddlsite.SelectedItem.Value;

            objSM.SalesEmpId = ddlSalesEmployee.SelectedItem.Value;
            objSM.PaymentTermsId = ddlpaymentterms.SelectedItem.Value;
            objSM.TermsCondtionId = ddltermscondtions.SelectedItem.Value;
            objSM.Discount = txtdiscount.Text;
            objSM.Tax = txttax.Text;
            objSM.GrandTotal = txttotal.Text;
            objSM.Preparedby = ddlpreparedby.SelectedItem.Value;
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;

            objSM.Specifications = HttpUtility.HtmlEncode(txtSpecifications.Text);
            objSM.DamagetempId = ddlDamageTerms.SelectedItem.Value;
            objSM.StroageTempId = ddlStroageTerms.SelectedItem.Value;
            objSM.InstallationtempId = ddlInstallation.SelectedItem.Value;
            objSM.DesignerId = ddlDesigner.SelectedItem.Value;

           

            objSM.AluminumColor = txtaluminiumColor.Text;
            objSM.HardwarecolorItem = txtHardwareColoritem.Text;
            objSM.Windload = txtWindload.Text;



            objSM.Paymentterms = txtpaymenttermsdetails.Text;
            objSM.TermsCondtions = txttermsconditions.Text;
            objSM.StrorageTerms = txtStroagetermsdetails.Text;
            objSM.DamageTerms = txtDamageterms.Text;
            objSM.Installationterms = txtInstallationTerms.Text;




            objSM.EuroPrice = txtEuroPrice.Text;
            objSM.Freight = txtFreight.Text;
            objSM.Customes = txtCustoms.Text;
            objSM.Insurance = txtInsurance.Text;
            objSM.Clearance = txtClearance.Text;
            objSM.Wastage = txtwastage.Text;
            objSM.Wallplugs = txtWallplugs.Text;
            objSM.Silicon = txtSilicon.Text;
            objSM.Maskingtape = txtmaskingpape.Text;
            objSM.BackorRod = txtbackrod.Text;
            objSM.FabricationPersqf = txtFabricationPersqft.Text;
            objSM.FabricationPersqm = txtfabricationPersqmt.Text;
            objSM.Installationpersft = txtinstallationpersqft.Text;
            objSM.InstallationPersqm = txtInstallationpersqmt.Text;
            objSM.Margin = txtmargin.Text;
            objSM.Siliconwidht = txtSiliconWidth.Text;
            objSM.SiliconDepth = txtSiliconDepth.Text;


            objSM.Options = lbloptions.Text;




            if (objSM.SalesQuotation_Update() == "Data Updated Successfully")
            {
                objSM.SalesQuotationDetails_Delete(objSM.QuotId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.WindowCode = gvrow.Cells[2].Text;
                    objSM.System = gvrow.Cells[3].Text;
                    objSM.Description = gvrow.Cells[4].Text;
                    objSM.Glass = gvrow.Cells[5].Text;
                    objSM.Location = gvrow.Cells[6].Text;
                    objSM.Mesh = gvrow.Cells[7].Text;

                    objSM.Width = gvrow.Cells[8].Text;
                    objSM.Height = gvrow.Cells[9].Text;
                    objSM.Qty = gvrow.Cells[10].Text;
                    objSM.TotalArea = gvrow.Cells[11].Text;
                    objSM.ProfileColor = gvrow.Cells[12].Text;
                    objSM.HardwareColor = gvrow.Cells[13].Text;

                    TextBox CostPerUnitEuro = (TextBox)gvrow.FindControl("txtItemUnitCostEuro");
                    objSM.ProfileCostEuro = CostPerUnitEuro.Text;

                    TextBox GlassPrice = (TextBox)gvrow.FindControl("txtItemGlassPrice");
                    objSM.GlassPrice = GlassPrice.Text;

                    TextBox MeshPrice = (TextBox)gvrow.FindControl("txtItemMeshPrice");
                    objSM.MeshPrice = MeshPrice.Text;

                    TextBox RecractablePrice = (TextBox)gvrow.FindControl("txtItemRecractablePrice");
                    objSM.RecractablePrice = RecractablePrice.Text;

                    TextBox MSInsertPrice = (TextBox)gvrow.FindControl("txtItemMSInsertPrice");
                    objSM.MsInsertPrice = MSInsertPrice.Text;

                    TextBox ExtraGlassWidth = (TextBox)gvrow.FindControl("txtItemExtraGlasswidth");
                    objSM.ExtraGlassWidth = ExtraGlassWidth.Text;

                    TextBox ExtraGlassHeight = (TextBox)gvrow.FindControl("txtItemExtraGlassheight");
                    objSM.ExtraGlassHeight = ExtraGlassHeight.Text;

                    TextBox ExtraGlassQty = (TextBox)gvrow.FindControl("txtItemExtraGlassQty");
                    objSM.ExtraGlassQty = ExtraGlassQty.Text;

                    TextBox ExtraGlassArea = (TextBox)gvrow.FindControl("txtItemExtraGlassArea");
                    objSM.ExtraGlassArea = ExtraGlassArea.Text;

                    TextBox ExtraGlassPrice = (TextBox)gvrow.FindControl("txtItemExtraGlassPrice");
                    objSM.ExtraGlassPrice = ExtraGlassPrice.Text;

                    TextBox HardWarePrice = (TextBox)gvrow.FindControl("txtItemHardwarePrice");
                    objSM.HardwarePrice = HardWarePrice.Text;

                    TextBox TotalAmount = (TextBox)gvrow.FindControl("txttotalAmount");
                    objSM.TotalAmount = TotalAmount.Text;

                    objSM.ElevationView = "";
                    objSM.ItemImage = System.Data.SqlTypes.SqlBinary.Null.ToString();



                    objSM.SalesQuotationDetails_Save();
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
                //MessageBox.Show(this, "Data Updated Successfully");
            }
            else
            {
                MessageBox.Show(this, "Some Data Missing");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            SM.ClearControls(this);
            SM.Dispose();
          //  Response.Redirect("~/Modules/Sales/SalesQuotation.aspx");
        }
    }

    private void SalesQuotationSave()
    {
        try
        {
            SM.SalesQuotation objSM = new SM.SalesQuotation();
            objSM.QuotNo = txtquatationno.Text;
            objSM.QuotDate = General.toMMDDYYYY(txtquotationdate.Text);
            objSM.Quotto = ddlquotationto.SelectedItem.Value;

            objSM.Validto = General.toMMDDYYYY(txtValidto.Text);
            objSM.EnqId = ddlEnquiryNo.SelectedItem.Value;
            objSM.CustId = ddlcustomer.SelectedItem.Value;
            objSM.UnitId = ddlsite.SelectedItem.Value;

            objSM.SalesEmpId = ddlSalesEmployee.SelectedItem.Value;
            objSM.PaymentTermsId = ddlpaymentterms.SelectedItem.Value;
            objSM.TermsCondtionId = ddltermscondtions.SelectedItem.Value;
            objSM.Discount = txtdiscount.Text;
            objSM.Tax = txttax.Text;
            objSM.GrandTotal = txttotal.Text;
            objSM.Preparedby = ddlpreparedby.SelectedItem.Value;
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;

            objSM.Specifications = HttpUtility.HtmlEncode(txtSpecifications.Text);
            objSM.DamagetempId = ddlDamageTerms.SelectedItem.Value;
            objSM.StroageTempId = ddlStroageTerms.SelectedItem.Value;
            objSM.InstallationtempId = ddlInstallation.SelectedItem.Value;
            objSM.DesignerId = ddlDesigner.SelectedItem.Value;

            objSM.Status = "New";

            objSM.AluminumColor = txtaluminiumColor.Text;
            objSM.HardwarecolorItem = txtHardwareColoritem.Text;
            objSM.Windload = txtWindload.Text;

            objSM.Paymentterms = txtpaymenttermsdetails.Text;
            objSM.TermsCondtions = txttermsconditions.Text;
            objSM.StrorageTerms = txtStroagetermsdetails.Text;
            objSM.DamageTerms = txtDamageterms.Text;
            objSM.Installationterms = txtInstallationTerms.Text;


            objSM.EuroPrice = txtEuroPrice.Text;
            objSM.Freight = txtFreight.Text;
            objSM.Customes = txtCustoms.Text;
            objSM.Insurance = txtInsurance.Text;
            objSM.Clearance = txtClearance.Text;
            objSM.Wastage = txtwastage.Text;
            objSM.Wallplugs = txtWallplugs.Text;
            objSM.Silicon = txtSilicon.Text;
            objSM.Maskingtape = txtmaskingpape.Text;
            objSM.BackorRod = txtbackrod.Text;
            objSM.FabricationPersqf = txtFabricationPersqft.Text;
            objSM.FabricationPersqm = txtfabricationPersqmt.Text;
            objSM.Installationpersft = txtinstallationpersqft.Text;
            objSM.InstallationPersqm = txtInstallationpersqmt.Text;
            objSM.Margin = txtmargin.Text;
            objSM.Siliconwidht = txtSiliconWidth.Text;
            objSM.SiliconDepth = txtSiliconDepth.Text;

            if (objSM.SalesQuotation_Save() == "Data Saved Successfully")
            {
                objSM.SalesQuotationDetails_Delete(objSM.QuotId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.WindowCode = gvrow.Cells[2].Text;
                    objSM.System = gvrow.Cells[3].Text;
                    objSM.Description = gvrow.Cells[4].Text;
                    objSM.Glass = gvrow.Cells[5].Text;
                    objSM.Location = gvrow.Cells[6].Text;
                    objSM.Mesh = gvrow.Cells[7].Text;

                    objSM.Width = gvrow.Cells[8].Text;
                    objSM.Height = gvrow.Cells[9].Text;
                    objSM.Qty = gvrow.Cells[10].Text;
                    objSM.TotalArea = gvrow.Cells[11].Text;
                    objSM.ProfileColor = gvrow.Cells[12].Text;
                    objSM.HardwareColor = gvrow.Cells[13].Text;

                    TextBox CostPerUnitEuro = (TextBox)gvrow.FindControl("txtItemUnitCostEuro");
                    objSM.ProfileCostEuro = CostPerUnitEuro.Text;

                    TextBox GlassPrice = (TextBox)gvrow.FindControl("txtItemGlassPrice");
                    objSM.GlassPrice = GlassPrice.Text;

                    TextBox MeshPrice = (TextBox)gvrow.FindControl("txtItemMeshPrice");
                    objSM.MeshPrice = MeshPrice.Text;

                    TextBox RecractablePrice = (TextBox)gvrow.FindControl("txtItemRecractablePrice");
                    objSM.RecractablePrice = RecractablePrice.Text;

                    TextBox MSInsertPrice = (TextBox)gvrow.FindControl("txtItemMSInsertPrice");
                    objSM.MsInsertPrice = MSInsertPrice.Text;

                    TextBox ExtraGlassWidth = (TextBox)gvrow.FindControl("txtItemExtraGlasswidth");
                    objSM.ExtraGlassWidth = ExtraGlassWidth.Text;

                    TextBox ExtraGlassHeight = (TextBox)gvrow.FindControl("txtItemExtraGlassheight");
                    objSM.ExtraGlassHeight = ExtraGlassHeight.Text;

                    TextBox ExtraGlassQty = (TextBox)gvrow.FindControl("txtItemExtraGlassQty");
                    objSM.ExtraGlassQty = ExtraGlassQty.Text;

                    TextBox ExtraGlassArea = (TextBox)gvrow.FindControl("txtItemExtraGlassArea");
                    objSM.ExtraGlassArea = ExtraGlassArea.Text;

                    TextBox ExtraGlassPrice = (TextBox)gvrow.FindControl("txtItemExtraGlassPrice");
                    objSM.ExtraGlassPrice = ExtraGlassPrice.Text;

                    TextBox HardWarePrice = (TextBox)gvrow.FindControl("txtItemHardwarePrice");
                    objSM.HardwarePrice = HardWarePrice.Text;

                    TextBox TotalAmount = (TextBox)gvrow.FindControl("txttotalAmount");
                    objSM.TotalAmount = TotalAmount.Text;

                    objSM.ElevationView = "";
                    objSM.ItemImage = System.Data.SqlTypes.SqlBinary.Null.ToString();



                    objSM.SalesQuotationDetails_Save();
                }

               // MessageBox.Show(this, "Data Saved Successfully");

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "hi()", true);
            }
            else
            {
                MessageBox.Show(this, "Some Data Missing");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            SM.ClearControls(this);
            SM.Dispose();
           // Response.Redirect("~/Modules/Sales/SalesQuotation.aspx");
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtCode.Text = string.Empty;
        txtSystem.Text = string.Empty;
        txtDescription.Text = string.Empty;
        txtGlass.Text = string.Empty;
        txtLocation.Text = string.Empty;
        txtMesh.Text = string.Empty;
        txtWidth.Text = string.Empty;
        txtHeight.Text = string.Empty;
        txtItemQty.Text = string.Empty;
        txttotalarea.Text = string.Empty;
        txtProfileColor.Text = string.Empty;
        txtHardwareColor.Text = string.Empty;
        txtProfileCostEuro.Text = string.Empty;
        txtGlassPrice.Text = string.Empty;
        txtSsmeshPrice.Text = string.Empty;
        txtRecractableMesh.Text = string.Empty;
        txtMSInsertPrice.Text = string.Empty;
        txtextraglasswidth.Text = string.Empty;
        txtextraglassHeight.Text = string.Empty;
        txtextraglassQty.Text = string.Empty;
        txtextraglassArea.Text = string.Empty;
        txtExtraGlassprice.Text = string.Empty;
        txtExtraHardware.Text = string.Empty;
        txtitemtotalamount.Text = string.Empty;
        txttotalpriceininr.Text = string.Empty;
        txtTotalProfileCostEuro.Text = string.Empty;

        Clearlabel();

        gvitems.SelectedIndex = -1;
    }

    protected void btnRevise_Click(object sender, EventArgs e)
    {
        try
        {
           
            SM.SalesQuotation objSM = new SM.SalesQuotation();
            objSM.QuotId = Request.QueryString["Cid"].ToString();
            objSM.QuotNo = txtquatationno.Text;
            objSM.QuotDate = General.toMMDDYYYY(txtquotationdate.Text);
            objSM.Quotto = ddlquotationto.SelectedItem.Value;

            objSM.Validto = General.toMMDDYYYY(txtValidto.Text);
            objSM.EnqId = ddlEnquiryNo.SelectedItem.Value;
            objSM.CustId = ddlcustomer.SelectedItem.Value;
            objSM.UnitId = ddlsite.SelectedItem.Value;

            objSM.SalesEmpId = ddlSalesEmployee.SelectedItem.Value;
            objSM.PaymentTermsId = ddlpaymentterms.SelectedItem.Value;
            objSM.TermsCondtionId = ddltermscondtions.SelectedItem.Value;
            objSM.Discount = txtdiscount.Text;
            objSM.Tax = txttax.Text;
            objSM.GrandTotal = txttotal.Text;
            objSM.Preparedby = ddlpreparedby.SelectedItem.Value;
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;

            objSM.Status = "New";

            objSM.Specifications = HttpUtility.HtmlEncode(txtSpecifications.Text);
            objSM.DamagetempId = ddlDamageTerms.SelectedItem.Value;
            objSM.StroageTempId = ddlStroageTerms.SelectedItem.Value;
            objSM.InstallationtempId = ddlInstallation.SelectedItem.Value;
            objSM.DesignerId = ddlDesigner.SelectedItem.Value;

            objSM.AluminumColor = txtaluminiumColor.Text;
            objSM.HardwarecolorItem = txtHardwareColoritem.Text;
            objSM.Windload = txtWindload.Text;



            objSM.Paymentterms = txtpaymenttermsdetails.Text;
            objSM.TermsCondtions = txttermsconditions.Text;
            objSM.StrorageTerms = txtStroagetermsdetails.Text;
            objSM.DamageTerms = txtDamageterms.Text;
            objSM.Installationterms = txtInstallationTerms.Text;


            objSM.RevisedDate = DateTime.Now.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);



            objSM.EuroPrice = txtEuroPrice.Text;
            objSM.Freight = txtFreight.Text;
            objSM.Customes = txtCustoms.Text;
            objSM.Insurance = txtInsurance.Text;
            objSM.Clearance = txtClearance.Text;
            objSM.Wastage = txtwastage.Text;
            objSM.Wallplugs = txtWallplugs.Text;
            objSM.Silicon = txtSilicon.Text;
            objSM.Maskingtape = txtmaskingpape.Text;
            objSM.BackorRod = txtbackrod.Text;
            objSM.FabricationPersqf = txtFabricationPersqft.Text;
            objSM.FabricationPersqm = txtfabricationPersqmt.Text;
            objSM.Installationpersft = txtinstallationpersqft.Text;
            objSM.InstallationPersqm = txtInstallationpersqmt.Text;
            objSM.Margin = txtmargin.Text;
            objSM.Siliconwidht = txtSiliconWidth.Text;
            objSM.SiliconDepth = txtSiliconDepth.Text;
            objSM.Options = lbloptions.Text;

            if (objSM.SalesQuotationRevise_Save() == "Data Saved Successfully")
            {
                objSM.SalesQuotationDetails_Delete(objSM.QuotId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.WindowCode = gvrow.Cells[2].Text;
                    objSM.System = gvrow.Cells[3].Text;
                    objSM.Description = gvrow.Cells[4].Text;
                    objSM.Glass = gvrow.Cells[5].Text;
                    objSM.Location = gvrow.Cells[6].Text;
                    objSM.Mesh = gvrow.Cells[7].Text;

                    objSM.Width = gvrow.Cells[8].Text;
                    objSM.Height = gvrow.Cells[9].Text;
                    objSM.Qty = gvrow.Cells[10].Text;
                    objSM.TotalArea = gvrow.Cells[11].Text;
                    objSM.ProfileColor = gvrow.Cells[12].Text;
                    objSM.HardwareColor = gvrow.Cells[13].Text;

                    TextBox CostPerUnitEuro = (TextBox)gvrow.FindControl("txtItemUnitCostEuro");
                    objSM.ProfileCostEuro = CostPerUnitEuro.Text;

                    TextBox GlassPrice = (TextBox)gvrow.FindControl("txtItemGlassPrice");
                    objSM.GlassPrice = GlassPrice.Text;

                    TextBox MeshPrice = (TextBox)gvrow.FindControl("txtItemMeshPrice");
                    objSM.MeshPrice = MeshPrice.Text;

                    TextBox RecractablePrice = (TextBox)gvrow.FindControl("txtItemRecractablePrice");
                    objSM.RecractablePrice = RecractablePrice.Text;

                    TextBox MSInsertPrice = (TextBox)gvrow.FindControl("txtItemMSInsertPrice");
                    objSM.MsInsertPrice = MSInsertPrice.Text;

                    TextBox ExtraGlassWidth = (TextBox)gvrow.FindControl("txtItemExtraGlasswidth");
                    objSM.ExtraGlassWidth = ExtraGlassWidth.Text;

                    TextBox ExtraGlassHeight = (TextBox)gvrow.FindControl("txtItemExtraGlassheight");
                    objSM.ExtraGlassHeight = ExtraGlassHeight.Text;

                    TextBox ExtraGlassQty = (TextBox)gvrow.FindControl("txtItemExtraGlassQty");
                    objSM.ExtraGlassQty = ExtraGlassQty.Text;

                    TextBox ExtraGlassArea = (TextBox)gvrow.FindControl("txtItemExtraGlassArea");
                    objSM.ExtraGlassArea = ExtraGlassArea.Text;

                    TextBox ExtraGlassPrice = (TextBox)gvrow.FindControl("txtItemExtraGlassPrice");
                    objSM.ExtraGlassPrice = ExtraGlassPrice.Text;

                    TextBox HardWarePrice = (TextBox)gvrow.FindControl("txtItemHardwarePrice");
                    objSM.HardwarePrice = HardWarePrice.Text;

                    TextBox TotalAmount = (TextBox)gvrow.FindControl("txttotalAmount");
                    objSM.TotalAmount = TotalAmount.Text;
                    objSM.SalesQuotationDetails_Save();
                }
            }
            else
            {
                MessageBox.Show(this, "Some Data Missing");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            SM.ClearControls(this);
            SM.Dispose();
            Response.Redirect("~/Modules/Sales/SalesQuotation.aspx");
        }
    }

    protected void ddlEnquiryNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesEnquiry obj = new SM.SalesEnquiry();
        if (obj.SalesEnquiry_Select(ddlEnquiryNo.SelectedItem.Value) > 0)
        {
            txtenquirydate.Text = obj.EnqDate;
            //ddlSoldtoParty.SelectedValue = obj.CustId;
            //ddlSoldtoParty_SelectedIndexChanged(sender, e);
            //ddlshiptoparty.SelectedValue = obj.UnitId;

            ddlcustomer.SelectedValue = obj.CustId;
            ddlcustomer_SelectedIndexChanged(sender, e);

            ddlsite.SelectedValue = obj.UnitId;
            ddlsite_SelectedIndexChanged(sender, e);

            ddlSalesEmployee.SelectedValue = obj.salesinchargeid;

            txtSpecifications.Text = HttpUtility.HtmlDecode(obj.Specificaitons);

            obj.SalesEnquiry_Select(ddlEnquiryNo.SelectedItem.Value, gvEnqItems);
            General.GridBindwithCommand(gvElevationDrawings, "select * from Enquiry_ElevationDetails where ENQ_ID= '" + ddlEnquiryNo.SelectedItem.Value + "'");
            General.GridBindwithCommand(gvFloorPlan, "select * from Enquiry_FloorPlanDetails where ENQ_ID= '" + ddlEnquiryNo.SelectedItem.Value + "'");
            //if (obj.GlassDetails_Select(ddlEnquiryNo.SelectedItem.Value) > 0)
            //{
            //    txtglassspecification.Text = obj.GlassSpecification;
            //    txtglassreceiveddate.Text = obj.GlassReceiveddate;
            //    txtglassthick.Text = obj.Glassthick;
            //    txtGlassremarks.Text = obj.GlassRemarks;

            //}
            //if (obj.FinishDetails_Select(ddlEnquiryNo.SelectedItem.Value) > 0)
            //{
            //    txtfinishcolor.Text = obj.FinishColor;
            //    txtfinsihedReceiveddate.Text = obj.FinishReceiveddate;
            //    txtfinishprofile.Text = obj.FinishProfile;
            //    txtfinishremarks.Text = obj.FinishRemarks;
            //}
        }
    }

    protected void gvEnqItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            //e.Row.Cells[12].Visible = false;
            //e.Row.Cells[13].Visible = false;
            //e.Row.Cells[14].Visible = false;
        }
    }

    protected void gvitems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string x1 = gvitems.Rows[e.RowIndex].Cells[1].Text;
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("CodeNo");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("System");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Glass");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Location");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Mesh");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Width");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("height");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("TotalArea");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ProfileColor");
        SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("ProfileColor");
        //SalesOrderItems.Columns.Add(col);
        col = new DataColumn("HardwareColor");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("UnitCostEuro");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemGlassPrice");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemMeshPrice");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemRecractablePrice");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemMSInsertPrice");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemExtraGlasswidth");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemExtraGlassheight");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemExtraGlassQty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemExtraGlassArea");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemExtraGlassPrice");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemHardwarePrice");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("TotalAmount");
        SalesOrderItems.Columns.Add(col);
        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvrow.RowIndex != e.RowIndex)
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["CodeNo"] = gvrow.Cells[2].Text;
                    dr["System"] = gvrow.Cells[3].Text;
                    dr["Description"] = gvrow.Cells[4].Text;
                    dr["Glass"] = gvrow.Cells[5].Text;
                    dr["Location"] = gvrow.Cells[6].Text;
                    dr["Mesh"] = gvrow.Cells[7].Text;
                    dr["Width"] = gvrow.Cells[8].Text;
                    dr["height"] = gvrow.Cells[9].Text;
                    dr["Qty"] = gvrow.Cells[10].Text;
                    dr["TotalArea"] = gvrow.Cells[11].Text;
                    dr["ProfileColor"] = gvrow.Cells[12].Text;
                    dr["HardwareColor"] = gvrow.Cells[13].Text;
                    dr["UnitCostEuro"] = gvrow.Cells[14].Text;
                    dr["ItemGlassPrice"] = gvrow.Cells[15].Text;
                    dr["ItemMeshPrice"] = gvrow.Cells[16].Text;
                    dr["ItemRecractablePrice"] = gvrow.Cells[17].Text;
                    dr["ItemMSInsertPrice"] = gvrow.Cells[18].Text;
                    dr["ItemExtraGlasswidth"] = gvrow.Cells[19].Text;
                    dr["ItemExtraGlassQty"] = gvrow.Cells[20].Text;
                    dr["ItemExtraGlassArea"] = gvrow.Cells[21].Text;
                    dr["ItemExtraGlassPrice"] = gvrow.Cells[22].Text;
                    dr["ItemHardwarePrice"] = gvrow.Cells[23].Text;
                    dr["TotalAmount"] = gvrow.Cells[24].Text;
                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
    }

    protected void btnAddItems_Click(object sender, EventArgs e)
    {
        DataTable SalesOrderItems = new DataTable();
        DataColumn col = new DataColumn();
        col = new DataColumn("CodeNo");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("System");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Description");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Glass");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Location");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Mesh");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Width");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("height");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("Qty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("TotalArea");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ProfileColor");
        SalesOrderItems.Columns.Add(col);
        //col = new DataColumn("ProfileColor");
        //SalesOrderItems.Columns.Add(col);
        col = new DataColumn("HardwareColor");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("UnitCostEuro");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemGlassPrice");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemMeshPrice");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemRecractablePrice");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemMSInsertPrice");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemExtraGlasswidth");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemExtraGlassheight");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemExtraGlassQty");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemExtraGlassArea");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemExtraGlassPrice");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("ItemHardwarePrice");
        SalesOrderItems.Columns.Add(col);
        col = new DataColumn("TotalAmount");
        SalesOrderItems.Columns.Add(col);

        if (gvitems.Rows.Count > 0)
        {
            foreach (GridViewRow gvrow in gvitems.Rows)
            {
                if (gvitems.SelectedIndex > -1)
                {
                    if (gvrow.RowIndex == gvitems.SelectedRow.RowIndex)
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["CodeNo"] = txtCode.Text;
                        dr["System"] = txtSystem.Text; ;
                        dr["Description"] = txtDescription.Text;
                        dr["Glass"] = txtGlass.Text;
                        dr["Location"] = txtLocation.Text;
                        dr["Mesh"] = txtMesh.Text;
                        dr["Width"] = txtWidth.Text;
                        dr["height"] = txtHeight.Text;
                        dr["Qty"] = txtItemQty.Text;
                        dr["TotalArea"] = txttotalarea.Text;
                        dr["ProfileColor"] = txtProfileColor.Text;
                        dr["HardwareColor"] = txtHardwareColor.Text;
                        dr["UnitCostEuro"] = txtProfileCostEuro.Text;
                        dr["ItemGlassPrice"] = txtGlassPrice.Text;
                        dr["ItemMeshPrice"] = txtSsmeshPrice.Text;
                        dr["ItemRecractablePrice"] = txtRecractableMesh.Text;
                        dr["ItemMSInsertPrice"] = txtMSInsertPrice.Text;
                        dr["ItemExtraGlasswidth"] = txtextraglasswidth.Text;
                        dr["ItemExtraGlassheight"] = txtextraglassHeight.Text;
                        dr["ItemExtraGlassQty"] = txtextraglassQty.Text;
                        dr["ItemExtraGlassArea"] = txtextraglassArea.Text;
                        dr["ItemExtraGlassPrice"] = txtExtraGlassprice.Text;
                        dr["ItemHardwarePrice"] = txtExtraHardware.Text;
                        dr["TotalAmount"] = txtitemtotalamount.Text;

                        //TextBox PerUnitEuro = (TextBox)gvrow.FindControl("txtItemUnitCostEuro");
                        //dr["UnitCostEuro"] = PerUnitEuro.Text;
                        //TextBox GlassPrice = (TextBox)gvrow.FindControl("txtItemGlassPrice");
                        //dr["ItemGlassPrice"] = GlassPrice.Text;
                        //TextBox MeshPrice = (TextBox)gvrow.FindControl("txtItemMeshPrice");
                        //dr["ItemMeshPrice"] = MeshPrice.Text;
                        //TextBox RecractablePrice = (TextBox)gvrow.FindControl("txtItemRecractablePrice");
                        //dr["ItemRecractablePrice"] = RecractablePrice.Text;

                        //TextBox MSInsertPrice = (TextBox)gvrow.FindControl("txtItemMSInsertPrice");
                        //dr["ItemMSInsertPrice"] = MSInsertPrice.Text;
                        //TextBox GlassWidth = (TextBox)gvrow.FindControl("txtItemExtraGlasswidth");
                        //dr["ItemGlassPrice"] = GlassWidth.Text;

                        //TextBox ItemExtraGlassHeight = (TextBox)gvrow.FindControl("txtItemExtraGlassheight");
                        //dr["ItemExtraGlassheight"] = ItemExtraGlassHeight.Text;

                        //TextBox ItemExtraGlassQty = (TextBox)gvrow.FindControl("txtItemExtraGlassQty");
                        //dr["ItemExtraGlassQty"] = ItemExtraGlassQty.Text;
                        //TextBox ItemExtraGlassArea = (TextBox)gvrow.FindControl("txtItemExtraGlassArea");
                        //dr["ItemExtraGlassArea"] = ItemExtraGlassArea.Text;
                        //TextBox ItemExtraGlassPrice = (TextBox)gvrow.FindControl("txtItemExtraGlassPrice");
                        //dr["ItemExtraGlassPrice"] = ItemExtraGlassPrice.Text;
                        //TextBox ItemHardwarePrice = (TextBox)gvrow.FindControl("txtItemHardwarePrice");
                        //dr["ItemHardwarePrice"] = ItemHardwarePrice.Text;

                        //TextBox Totalamount = (TextBox)gvrow.FindControl("txttotalAmount");
                        //dr["TotalAmount"] = Totalamount.Text;

                        SalesOrderItems.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = SalesOrderItems.NewRow();
                        dr["CodeNo"] = gvrow.Cells[2].Text;
                        dr["System"] = gvrow.Cells[3].Text;
                        dr["Description"] = gvrow.Cells[4].Text;
                        dr["Glass"] = gvrow.Cells[5].Text;
                        dr["Location"] = gvrow.Cells[6].Text;
                        dr["Mesh"] = gvrow.Cells[7].Text;
                        dr["Width"] = gvrow.Cells[8].Text;
                        dr["height"] = gvrow.Cells[9].Text;
                        dr["Qty"] = gvrow.Cells[10].Text;
                        dr["TotalArea"] = gvrow.Cells[11].Text;
                        dr["ProfileColor"] = gvrow.Cells[12].Text;
                        dr["HardwareColor"] = gvrow.Cells[13].Text;
                        dr["UnitCostEuro"] = gvrow.Cells[14].Text;
                        dr["ItemGlassPrice"] = gvrow.Cells[15].Text;
                        dr["ItemMeshPrice"] = gvrow.Cells[16].Text;
                        dr["ItemRecractablePrice"] = gvrow.Cells[17].Text;
                        dr["ItemMSInsertPrice"] = gvrow.Cells[18].Text;
                        dr["ItemExtraGlasswidth"] = gvrow.Cells[19].Text;
                        dr["ItemExtraGlassQty"] = gvrow.Cells[20].Text;
                        dr["ItemExtraGlassArea"] = gvrow.Cells[21].Text;
                        dr["ItemExtraGlassPrice"] = gvrow.Cells[22].Text;
                        dr["ItemHardwarePrice"] = gvrow.Cells[23].Text;
                        dr["TotalAmount"] = gvrow.Cells[24].Text;
                        SalesOrderItems.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = SalesOrderItems.NewRow();
                    dr["CodeNo"] = gvrow.Cells[2].Text;
                    dr["System"] = gvrow.Cells[3].Text;
                    dr["Description"] = gvrow.Cells[4].Text;
                    dr["Glass"] = gvrow.Cells[5].Text;
                    dr["Location"] = gvrow.Cells[6].Text;
                    dr["Mesh"] = gvrow.Cells[7].Text;
                    dr["Width"] = gvrow.Cells[8].Text;
                    dr["height"] = gvrow.Cells[9].Text;
                    dr["Qty"] = gvrow.Cells[10].Text;
                    dr["TotalArea"] = gvrow.Cells[11].Text;
                    dr["ProfileColor"] = gvrow.Cells[12].Text;
                    dr["HardwareColor"] = gvrow.Cells[13].Text;
                    dr["UnitCostEuro"] = gvrow.Cells[14].Text;
                    dr["ItemGlassPrice"] = gvrow.Cells[15].Text;
                    dr["ItemMeshPrice"] = gvrow.Cells[16].Text;
                    dr["ItemRecractablePrice"] = gvrow.Cells[17].Text;
                    dr["ItemMSInsertPrice"] = gvrow.Cells[18].Text;
                    dr["ItemExtraGlasswidth"] = gvrow.Cells[19].Text;
                    dr["ItemExtraGlassQty"] = gvrow.Cells[20].Text;
                    dr["ItemExtraGlassArea"] = gvrow.Cells[21].Text;
                    dr["ItemExtraGlassPrice"] = gvrow.Cells[22].Text;
                    dr["ItemHardwarePrice"] = gvrow.Cells[23].Text;
                    dr["TotalAmount"] = gvrow.Cells[24].Text;

                    SalesOrderItems.Rows.Add(dr);
                }
            }
        }

        if (gvitems.SelectedIndex == -1)
        {
            DataRow drnew = SalesOrderItems.NewRow();
            drnew["CodeNo"] = txtCode.Text;
            drnew["System"] = txtSystem.Text; ;
            drnew["Description"] = txtDescription.Text;
            drnew["Glass"] = txtGlass.Text;
            drnew["Location"] = txtLocation.Text;
            drnew["Mesh"] = txtMesh.Text;
            drnew["Width"] = txtWidth.Text;
            drnew["height"] = txtHeight.Text;
            drnew["Qty"] = txtItemQty.Text;
            drnew["TotalArea"] = txttotalarea.Text;
            drnew["ProfileColor"] = txtProfileColor.Text;
            drnew["HardwareColor"] = txtHardwareColor.Text;
            drnew["UnitCostEuro"] = txtProfileCostEuro.Text;
            drnew["ItemGlassPrice"] = txtGlassPrice.Text;
            drnew["ItemMeshPrice"] = txtSsmeshPrice.Text;
            drnew["ItemRecractablePrice"] = txtRecractableMesh.Text;
            drnew["ItemMSInsertPrice"] = txtMSInsertPrice.Text;
            drnew["ItemExtraGlasswidth"] = txtextraglasswidth.Text;
            drnew["ItemExtraGlassheight"] = txtextraglassHeight.Text;
            drnew["ItemExtraGlassQty"] = txtextraglassQty.Text;
            drnew["ItemExtraGlassArea"] = txtextraglassArea.Text;
            drnew["ItemExtraGlassPrice"] = txtExtraGlassprice.Text;
            drnew["ItemHardwarePrice"] = txtExtraHardware.Text;
            drnew["TotalAmount"] = txtitemtotalamount.Text;

            SalesOrderItems.Rows.Add(drnew);
        }
        gvitems.DataSource = SalesOrderItems;
        gvitems.DataBind();
        gvitems.SelectedIndex = -1;
        Clearlabel();
        btnReset_Click(sender, e);
    }

    protected void ddlcustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.CustomerMaster obj = new SM.CustomerMaster();

        if (obj.CustomerMaster_Select(ddlcustomer.SelectedItem.Value) > 0)
        {
            txtCustomerAddress.Text = obj.custaddress;
            //txtshippingaddress.Text = obj.custaddress;
            txtContactperson.Text = obj.CustName;
            txtContactMobileNo.Text = obj.CustMobile;

            SM.CustomerMaster.CustomerUnit_Select(ddlsite, ddlcustomer.SelectedItem.Value);
        }
    }

    protected void ddlsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.CustomerMaster obj = new SM.CustomerMaster();

        if (obj.CustomerUnitMaster_Select(ddlsite.SelectedItem.Value) > 0)
        {
            txtsiteaddress.Text = obj.UnitAddress;
            txtsiteContactperson.Text = obj.UnitContactPerson;
            txtsiteMobileno.Text = obj.UnitMobileNo;
        }
    }

    protected void ddlpaymentterms_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.PaymentTerms obj = new Masters.PaymentTerms();

        if (obj.Payment_Select(ddlpaymentterms.SelectedItem.Value) > 0)
        {
            //txtpaymenttermsdetails.Text = HttpUtility.HtmlDecode(obj.Desc);

            txtpaymenttermsdetails.Text = obj.Desc;
        }
    }

    protected void ddltermscondtions_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.SalesTermsConditions obj = new Masters.SalesTermsConditions();

        if (obj.SalesTermsConditions_Select(ddltermscondtions.SelectedItem.Value) > 0)
        {
            txttermsconditions.Text = HttpUtility.HtmlDecode(obj.Desc);
        }
    }

    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("CodeNo");
        dt.Columns.Add("Width");
        dt.Columns.Add("height");
        dt.Columns.Add("SillHeight");
        dt.Columns.Add("Series");
        dt.Columns.Add("Qty");
        dt.Columns.Add("Glass");
        dt.Columns.Add("FlyScreen");
        dt.Columns.Add("Amount");
        dt.Columns.Add("TotalAmount");

        dt.Columns.Add("EnqDetId");

        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("EnqDetId = '" + gvRow.Cells[10].Text + "'");
        // DataRow[] dr ;
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["CodeNo"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["Width"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["height"] = gvRow.Cells[3].Text;
            dt.Rows[dt.Rows.Count - 1]["SillHeight"] = gvRow.Cells[4].Text;
            dt.Rows[dt.Rows.Count - 1]["Series"] = gvRow.Cells[5].Text;
            dt.Rows[dt.Rows.Count - 1]["Qty"] = gvRow.Cells[6].Text;
            dt.Rows[dt.Rows.Count - 1]["Glass"] = gvRow.Cells[7].Text;
            dt.Rows[dt.Rows.Count - 1]["FlyScreen"] = gvRow.Cells[8].Text;
            dt.Rows[dt.Rows.Count - 1]["Amount"] = "0";
            dt.Rows[dt.Rows.Count - 1]["TotalAmount"] = "0";
            dt.Rows[dt.Rows.Count - 1]["EnqDetId"] = gvRow.Cells[10].Text;

            dt.AcceptChanges();
        }
        return dt;
    }

    private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("EnqDetId = '" + gvRow.Cells[10].Text + "'");
        if (dr.Length > 0)
        {
            dt.Rows.Remove(dr[0]);
            dt.AcceptChanges();
        }
        return dt;
    }

    private void GetData()
    {
        DataTable dt;
        if (ViewState["SelectedRecords"] != null)
            dt = (DataTable)ViewState["SelectedRecords"];
        else
            dt = CreateDataTable();
        CheckBox chkAll = (CheckBox)gvEnqItems.HeaderRow
                            .Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvEnqItems.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvEnqItems.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvEnqItems.Rows[i]
                                .Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    dt = AddRow(gvEnqItems.Rows[i], dt);
                }
                else
                {
                    dt = RemoveRow(gvEnqItems.Rows[i], dt);
                }
            }
        }
        ViewState["SelectedRecords"] = dt;
    }

    private void SetData()
    {
        CheckBox chkAll = (CheckBox)gvEnqItems.HeaderRow.Cells[0].FindControl("chkAll");
        chkAll.Checked = true;
        if (ViewState["SelectedRecords"] != null)
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];
            for (int i = 0; i < gvEnqItems.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gvEnqItems.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    DataRow[] dr = dt.Select("EnqDetId = '" + gvEnqItems.Rows[i].Cells[10].Text + "'");
                    chk.Checked = dr.Length > 0;
                    if (!chk.Checked)
                    {
                        chkAll.Checked = false;
                    }
                }
            }
        }
    }

    protected void CheckBox_CheckChanged(object sender, EventArgs e)
    {
        GetData();
        SetData();
        BindSecondaryGrid();
    }

    private void BindSecondaryGrid()
    {
        DataTable dt = (DataTable)ViewState["SelectedRecords"];
        gvitems.DataSource = dt;
        gvitems.DataBind();
    }

    protected void ddlquotationto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlquotationto.SelectedItem.Value == "Customer")
        {
            panelEnquirydetails.Visible = false;
        }
        else
        {
            panelEnquirydetails.Visible = true;
        }
    }

    protected void txtitemamount_TextChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in gvitems.Rows)
        {
            TextBox rate = (TextBox)gvr.FindControl("txtitemamount");
            TextBox qty = (TextBox)gvr.FindControl("txtitemqty");
            Label amount = (Label)gvr.FindControl("lblAmount");

            if (rate.Text != "" && qty.Text != "")
            {
                amount.Text = (Convert.ToDecimal(rate.Text) * Convert.ToDecimal(qty.Text)).ToString();
                txtsubtotal.Text = txttotal.Text = NetAmountCalc().ToString();
            }
            else
            {
                amount.Text = "0";
                txtsubtotal.Text = txttotal.Text = NetAmountCalc().ToString();
            }
        }
    }

    private double NetAmountCalc()
    {
        double _totalAmt = 0;
        foreach (GridViewRow gvrow in gvitems.Rows)
        {
            TextBox amt = (TextBox)gvrow.FindControl("txttotalAmount");
            if (amt.Text != "")
            {
                _totalAmt = _totalAmt + Convert.ToDouble(amt.Text);
            }
            else
            {
                _totalAmt = _totalAmt + 0;
            }
        }
        return _totalAmt;
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            SM.SalesQuotation objSMSOApprove = new SM.SalesQuotation();
            objSMSOApprove.QuotId = Request.QueryString["Cid"].ToString();
            objSMSOApprove.Approvedby = Alumil.Authentication.GetEmployeeInSession(Alumil.Authentication.Logged_EMP_Details.EmpId);
            objSMSOApprove.SalesQuotationApprove_Update();

            if (ddlEnquiryNo.SelectedItem.Value != "0")
            {
                objSMSOApprove.EnqId = ddlEnquiryNo.SelectedItem.Value;
                objSMSOApprove.SalesEnquiryStatus_Update();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Response.Redirect("~/Modules/Sales/SalesQuotation.aspx");
        }
    }

    protected void ddlInstallation_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.Installationtech obj = new Masters.Installationtech();

        if (obj.Installationtech_Select(ddlInstallation.SelectedItem.Value) > 0)
        {
            txtInstallationTerms.Text = HttpUtility.HtmlDecode(obj.Desc);
        }
    }

    protected void ddlDamageTerms_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.SalesDamage obj = new Masters.SalesDamage();

        if (obj.SalesDamage_Select(ddlDamageTerms.SelectedItem.Value) > 0)
        {
            txtDamageterms.Text = HttpUtility.HtmlDecode(obj.Desc);
        }
    }

    protected void ddlStroageTerms_SelectedIndexChanged(object sender, EventArgs e)
    {
        Masters.SalesStorage obj = new Masters.SalesStorage();

        if (obj.SalesStorage_Select(ddlStroageTerms.SelectedItem.Value) > 0)
        {
            txtStroagetermsdetails.Text = HttpUtility.HtmlDecode(obj.Desc);
        }
    }

    //protected void txtFabricationPersqft_TextChanged(object sender, EventArgs e)
    //{
    //    if (txtFabricationPersqft.Text != "")
    //    {
    //        double a = double.Parse(txtFabricationPersqft.Text);

    //        double c = (a * 10.764);

    //        txtfabricationPersqmt.Text = c.ToString();
    //    }
    //}

    //protected void txtinstallationpersqft_TextChanged(object sender, EventArgs e)
    //{
    //    if (txtinstallationpersqft.Text != "")
    //    {
    //        double a = double.Parse(txtinstallationpersqft.Text);

    //        double c = (a * 10.764);

    //        txtInstallationpersqmt.Text = c.ToString();
    //    }
    //}

    //protected void txtItemQty_TextChanged(object sender, EventArgs e)
    //{
    //    //if (txtWidth.Text != "" && txtHeight.Text != "")
    //    //{
    //    //    Decimal i = Convert.ToDecimal(txtItemQty.Text) * ((Convert.ToDecimal(txtWidth.Text) * Convert.ToDecimal(txtHeight.Text)) / 1000000);
    //    //    txttotalarea.Text = i.ToString();

    //    //}
    //}
    protected void txtProfileCostEuro_TextChanged(object sender, EventArgs e)
    {
        decimal euro = Convert.ToDecimal(txtItemQty.Text) * Convert.ToDecimal(txtProfileCostEuro.Text);

        txtTotalProfileCostEuro.Text = euro.ToString();

        decimal Basic = euro * Convert.ToDecimal(txtEuroPrice.Text);

        //txttotalpriceininr.Text = Math.Round(Basic, 2).ToString();
        txttotalpriceininr.Text = Basic.ToString();

        //Freight Calculations =P22*$Q$6

        decimal fright = Convert.ToDecimal(txtFreight.Text);
        decimal totalfright = ((Basic * fright) / 100 );

       // decimal totalfright = Math.Round(Basic * fright / 100, 2);

        //Customs Calculations =(P25+Q25)*$R$6

        decimal Customs = Convert.ToDecimal(txtCustoms.Text);

        decimal basicplustotalfright = Basic + totalfright;

        decimal totalCustoms = ((basicplustotalfright * Customs) / 100);

       // decimal totalCustoms = Math.Round((Basic + totalfright) * Customs / 100, 2);

        //Insurance Calculations =(P25+Q25+R25)*$S$6

        decimal insurance = Convert.ToDecimal(txtInsurance.Text);

        decimal basicplustotalfrightpluscustoms = basicplustotalfright + totalCustoms;

          decimal insurancetotal = ((basicplustotalfrightpluscustoms * insurance) / 100);

      //  decimal insurancetotal = Math.Round((Basic + totalfright + totalCustoms) * insurance / 100, 2);

        ///Clearance Calculations =(P25+Q25+R25+S25)*$T$6

        decimal clearance = Convert.ToDecimal(txtClearance.Text);

        decimal basicplustotalfrightpluscustomsplusinsurance = basicplustotalfrightpluscustoms + insurancetotal;

        decimal clearancetotal = ((basicplustotalfrightpluscustomsplusinsurance * clearance) / 100);
      //  decimal clearancetotal = Math.Round((Basic + totalfright + totalCustoms + insurancetotal) * clearance / 100, 2);

        decimal ProfileCost = Basic + totalfright + totalCustoms + insurancetotal + clearancetotal;

        lblTotalProfileCost.Text = "";
        //lblTotalProfileCost.Text = Math.Round(ProfileCost, 2).ToString();

        lblTotalProfileCost.Text = ProfileCost.ToString();

        decimal wastage = Convert.ToDecimal(txtwastage.Text);

        decimal WastageTotal = ((ProfileCost * wastage) / 100);

        lblTotalWastageCost.Text = "";
        //lblTotalWastageCost.Text = Math.Round(WastageTotal, 2).ToString();

        lblTotalWastageCost.Text = WastageTotal.ToString();

        // =((((F8+G8)*2)/305)*I8*$AE$7)
        /////////WallPlug Calculations

        decimal f8 = Convert.ToDecimal(txtWidth.Text);
        decimal g8 = Convert.ToDecimal(txtHeight.Text);
        decimal ae7 = Convert.ToDecimal(txtWallplugs.Text);
        decimal I8 = Convert.ToDecimal(txtItemQty.Text);

        decimal wallplug = ((((f8 + g8) * 2) / 305) * I8 * ae7);
        //lbltotalWallplugwithscrews.Text = Math.Round(wallplug, 2).ToString();


        lbltotalWallplugwithscrews.Text = wallplug.ToString();



        //  =(((((F8*4)+(G8*4))/1000)*$AF$6*$AG$6)/300)*I8*$AF$7
        ///Silicon Calculations

        decimal af = Convert.ToDecimal(txtSiliconWidth.Text);
        decimal ag = Convert.ToDecimal(txtSiliconDepth.Text);
        decimal af7 = Convert.ToDecimal(txtSilicon.Text);

        decimal Silicon = (((((f8 * 4) + (g8 * 4)) / 1000) * af * ag) / 300) * I8 * af7;

       // lbltotalSilicon.Text = Math.Round(Silicon, 2).ToString();


        lbltotalSilicon.Text = Silicon.ToString();

        //=(((F8+G8))*I8/1000)*4*$AH$7
        //Masking Tape

        decimal ah7 = Convert.ToDecimal(txtmaskingpape.Text);

        decimal maskingtape = (((f8 + g8)) * I8 / 1000) * 4 * ah7;

        //lbltotalmaskingtape.Text = Math.Round(maskingtape, 2).ToString();

        lbltotalmaskingtape.Text = maskingtape.ToString();

        // =(((F8+G8)*2*I8)/1000)*2*$AI$7
        //Backers Rod

        decimal ai7 = Convert.ToDecimal(txtbackrod.Text);

        decimal backersrod = (((f8 + g8) * 2 * I8) / 1000) * 2 * ai7;

        //lbltotalBackersRod.Text = Math.Round(backersrod, 2).ToString();


        lbltotalBackersRod.Text = backersrod.ToString();


        //Fabrication =J8*$AL$6

        decimal j8 = Convert.ToDecimal(txttotalarea.Text);
        decimal al6 = Convert.ToDecimal(txtfabricationPersqmt.Text);

        decimal fabrication = j8 * al6;

        //lbltotalfabrication.Text = Math.Round(fabrication, 2).ToString();
        lbltotalfabrication.Text = fabrication.ToString();

        //Installation =$AN$6*J8

        decimal an6 = Convert.ToDecimal(txtInstallationpersqmt.Text);
        decimal installation = an6 * j8;

        //lbltotalinstallation.Text = Math.Round(installation, 2).ToString();
        lbltotalinstallation.Text = installation.ToString();

        //TotalCost

        decimal totalcost = Convert.ToDecimal(lblTotalProfileCost.Text) + Convert.ToDecimal(lblTotalWastageCost.Text) + Convert.ToDecimal(lbltotalWallplugwithscrews.Text) + Convert.ToDecimal(lbltotalSilicon.Text) + Convert.ToDecimal(lbltotalmaskingtape.Text) + Convert.ToDecimal(lbltotalBackersRod.Text);
        //lbltotalCost.Text = Math.Round(totalcost, 2).ToString();
        lbltotalCost.Text = totalcost.ToString();
        //Margin OH =AO8*$AP$6

        decimal ap6 = Convert.ToDecimal(txtmargin.Text);
        decimal a08 = Convert.ToDecimal(lbltotalCost.Text);

        decimal Margin = a08 * ap6 / 100;
        //lbltotalmargin.Text = Math.Round(Margin, 2).ToString();

        lbltotalmargin.Text = Margin.ToString();

        //CT for Easy

        decimal ct = Convert.ToDecimal(lbltotalfabrication.Text) + Convert.ToDecimal(lbltotalinstallation.Text) + Convert.ToDecimal(lbltotalCost.Text) + Convert.ToDecimal(lbltotalmargin.Text);
        lblct.Text = Math.Round(ct, 2).ToString();

        txtitemtotalamount.Text = Math.Round(ct, 2).ToString();
    }

    protected void txtGlassPrice_TextChanged(object sender, EventArgs e)
    {
        if (txttotalarea.Text != "")
        {
            decimal glassprice = Convert.ToDecimal(txtGlassPrice.Text) * Convert.ToDecimal(txttotalarea.Text);
            lbltotalGlasspriceCost.Text = Math.Round(glassprice, 2).ToString();

            //decimal tm = Convert.ToDecimal(lblct.Text) + Convert.ToDecimal(lbltotalGlasspriceCost.Text);
            decimal tm = Convert.ToDecimal(lblct.Text) + Convert.ToDecimal(lbltotalGlasspriceCost.Text) + Convert.ToDecimal(lbltotalMsCost.Text) + Convert.ToDecimal(lbltotalSSmesh.Text) + Convert.ToDecimal(lbltotalRecractableMesh.Text);
            txtitemtotalamount.Text = Math.Round(tm, 2).ToString();
        }
    }

    protected void txtMSInsertPrice_TextChanged(object sender, EventArgs e)
    {
        if (txttotalarea.Text != "")
        {
            decimal MSPrice = Convert.ToDecimal(txtMSInsertPrice.Text) * Convert.ToDecimal(txttotalarea.Text);
            lbltotalMsCost.Text = Math.Round(MSPrice, 2).ToString();

            //  decimal tm = Convert.ToDecimal(lblct.Text) + Convert.ToDecimal(lbltotalGlasspriceCost.Text) + Convert.ToDecimal(lbltotalMsCost.Text) + Convert.ToDecimal() ;
            decimal tm = Convert.ToDecimal(lblct.Text) + Convert.ToDecimal(lbltotalGlasspriceCost.Text) + Convert.ToDecimal(lbltotalMsCost.Text) + Convert.ToDecimal(lbltotalSSmesh.Text) + Convert.ToDecimal(lbltotalRecractableMesh.Text);
            txtitemtotalamount.Text = Math.Round(tm, 2).ToString();
        }
    }

    protected void txtSsmeshPrice_TextChanged(object sender, EventArgs e)
    {
        if (txttotalarea.Text != "")
        {
            decimal ssmesh = Convert.ToDecimal(txtSsmeshPrice.Text) * Convert.ToDecimal(txttotalarea.Text);
            lbltotalSSmesh.Text = Math.Round(ssmesh, 2).ToString();

            // decimal tm = Convert.ToDecimal(lblct.Text) + Convert.ToDecimal(lbltotalGlasspriceCost.Text) + Convert.ToDecimal(lbltotalMsCost.Text) + Convert.ToDecimal(lbltotalSSmesh.Text);
            decimal tm = Convert.ToDecimal(lblct.Text) + Convert.ToDecimal(lbltotalGlasspriceCost.Text) + Convert.ToDecimal(lbltotalMsCost.Text) + Convert.ToDecimal(lbltotalSSmesh.Text) + Convert.ToDecimal(lbltotalRecractableMesh.Text);
            txtitemtotalamount.Text = Math.Round(tm, 2).ToString();
        }
    }

    protected void txtRecractableMesh_TextChanged(object sender, EventArgs e)
    {
        if (txttotalarea.Text != "")
        {
            decimal Recractablemesh = Convert.ToDecimal(txtRecractableMesh.Text) * Convert.ToDecimal(txttotalarea.Text);
            lbltotalRecractableMesh.Text = Math.Round(Recractablemesh, 2).ToString();

            decimal tm = Convert.ToDecimal(lblct.Text) + Convert.ToDecimal(lbltotalGlasspriceCost.Text) + Convert.ToDecimal(lbltotalMsCost.Text) + Convert.ToDecimal(lbltotalSSmesh.Text) + Convert.ToDecimal(lbltotalRecractableMesh.Text);
            txtitemtotalamount.Text = Math.Round(tm, 2).ToString();
        }
    }

    protected void txtextraglassQty_TextChanged(object sender, EventArgs e)
    {
        if (txtextraglasswidth.Text != "" && txtextraglassHeight.Text != "")
        {
            decimal n19 = Convert.ToDecimal(txtextraglasswidth.Text);
            decimal m19 = Convert.ToDecimal(txtextraglassHeight.Text);
            decimal L19 = Convert.ToDecimal(txtextraglassQty.Text);

            decimal area = n19 * m19 * L19 / 1000000;

            txtextraglassArea.Text = Math.Round(area, 2).ToString();
        }
    }

    protected void txtExtraGlassprice_TextChanged(object sender, EventArgs e)
    {
        if (txtextraglassArea.Text != "")
        {
            decimal extraglassprice = Convert.ToDecimal(txtExtraGlassprice.Text) * Convert.ToDecimal(txttotalarea.Text);
            lbltotalextraglassprice.Text = Math.Round(extraglassprice, 2).ToString();

            decimal tm = Convert.ToDecimal(lblct.Text) + Convert.ToDecimal(lbltotalGlasspriceCost.Text) + Convert.ToDecimal(lbltotalMsCost.Text) + Convert.ToDecimal(lbltotalSSmesh.Text) + Convert.ToDecimal(lbltotalRecractableMesh.Text) + Convert.ToDecimal(lbltotalextraglassprice.Text);
            txtitemtotalamount.Text = Math.Round(tm, 2).ToString();
        }
    }

    protected void txtExtraHardware_TextChanged(object sender, EventArgs e)
    {
        decimal extrahardware = Convert.ToDecimal(txtExtraHardware.Text);

        decimal tm = extrahardware + Convert.ToDecimal(lblct.Text) + Convert.ToDecimal(lbltotalGlasspriceCost.Text) + Convert.ToDecimal(lbltotalMsCost.Text) + Convert.ToDecimal(lbltotalSSmesh.Text) + Convert.ToDecimal(lbltotalRecractableMesh.Text) + Convert.ToDecimal(lbltotalextraglassprice.Text);
        txtitemtotalamount.Text = Math.Round(tm, 2).ToString();
    }

    protected void btnUploadExcel_Click(object sender, EventArgs e)
    {
        if (FileUpload.HasFile)
        {
            if (!Convert.IsDBNull(FileUpload.PostedFile) &
                    FileUpload.PostedFile.ContentLength > 0)
            {
                // SAVE THE SELECTED FILE IN THE ROOT DIRECTORY.
                FileUpload.SaveAs(Server.MapPath(".") + "\\" + "UploadDocs" + "\\" + FileUpload.FileName);

                // SET A CONNECTION WITH THE EXCEL FILE.
                OleDbConnection myExcelConn = new OleDbConnection
                    ("Provider=Microsoft.ACE.OLEDB.12.0; " +
                        "Data Source=" + Server.MapPath(".") + "\\" + "UploadDocs" + "\\" + FileUpload.FileName +
                        ";Extended Properties=Excel 12.0;");
                try
                {
                    myExcelConn.Open();

                    // GET DATA FROM EXCEL SHEET.
                    OleDbCommand objOleDB =
                        new OleDbCommand("SELECT * FROM [APPLICATION$]", myExcelConn);

                    // READ THE DATA EXTRACTED FROM THE EXCEL FILE.
                    OleDbDataReader objBulkReader = null;
                    objBulkReader = objOleDB.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(objBulkReader);

                    //Create Tempory Table
                    DataTable dtTemp = new DataTable();

                    // Creating Header Row
                    dtTemp.Columns.Add("CodeNo");
                    dtTemp.Columns.Add("System");
                    dtTemp.Columns.Add("Description");
                    dtTemp.Columns.Add("Glass");
                    dtTemp.Columns.Add("Location");
                    dtTemp.Columns.Add("Mesh");
                    dtTemp.Columns.Add("Width");
                    dtTemp.Columns.Add("height");
                    dtTemp.Columns.Add("Qty");
                    dtTemp.Columns.Add("TotalArea");
                    dtTemp.Columns.Add("ProfileColor");
                    dtTemp.Columns.Add("HardwareColor");

                    dtTemp.Columns.Add("UnitCostEuro");

                    dtTemp.Columns.Add("ItemGlassPrice");
                    dtTemp.Columns.Add("ItemMeshPrice");
                    dtTemp.Columns.Add("ItemRecractablePrice");

                    dtTemp.Columns.Add("ItemMSInsertPrice");
                    dtTemp.Columns.Add("ItemExtraGlasswidth");
                    dtTemp.Columns.Add("ItemExtraGlassheight");

                    dtTemp.Columns.Add("ItemExtraGlassQty");
                    dtTemp.Columns.Add("ItemExtraGlassArea");
                    dtTemp.Columns.Add("ItemExtraGlassPrice");

                    dtTemp.Columns.Add("ItemHardwarePrice");
                    dtTemp.Columns.Add("TotalAmount");

                    //DataRow drAddItem;
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    drAddItem = dtTemp.NewRow();
                    //    drAddItem[0] = dt.Rows[i]["Window Codes"].ToString();
                    //    drAddItem[1] = dt.Rows[i]["System"].ToString();
                    //    drAddItem[2] = dt.Rows[i]["Description"].ToString();
                    //    drAddItem[3] = dt.Rows[i]["Glass"].ToString();
                    //    drAddItem[4] = dt.Rows[i]["Location"].ToString();
                    //    drAddItem[5] = dt.Rows[i]["Mesh"].ToString();
                    //    drAddItem[6] = dt.Rows[i]["Width"].ToString();
                    //    drAddItem[7] = dt.Rows[i]["height"].ToString();
                    //    drAddItem[8] = dt.Rows[i]["SillHeight"].ToString();
                    //    drAddItem[9] = dt.Rows[i]["Qty"].ToString();
                    //    drAddItem[10] = dt.Rows[i]["Total Area"].ToString();
                    //    drAddItem[11] = dt.Rows[i]["Total Amount"].ToString();
                    //    drAddItem[12] = dt.Rows[i]["ProfileFinish"].ToString();
                    //    dtTemp.Rows.Add(drAddItem);
                    //}

                    DataRow drAddItem;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (dt.Rows[i]["Window Codes"].ToString() != "")
                        {
                            drAddItem = dtTemp.NewRow();
                            drAddItem[0] = dt.Rows[i]["Window Codes"].ToString();
                            drAddItem[1] = dt.Rows[i]["System"].ToString();
                            drAddItem[2] = dt.Rows[i]["Description"].ToString();
                            drAddItem[3] = dt.Rows[i]["Glass"].ToString();
                            drAddItem[4] = dt.Rows[i]["Location"].ToString();
                            drAddItem[5] = dt.Rows[i]["Mesh"].ToString();

                            if (dt.Rows[i]["Width"].ToString() == "")
                            {
                                drAddItem[6] = "0";
                            }
                            else
                            {
                                drAddItem[6] = dt.Rows[i]["Width"].ToString();
                            }
                            if (dt.Rows[i]["height"].ToString() == "")
                            {
                                drAddItem[7] = "0";
                            }
                            else
                            {
                                drAddItem[7] = dt.Rows[i]["height"].ToString();
                            }

                            if (dt.Rows[i]["Qty"].ToString() == "")
                            {
                                drAddItem[8] = "0";
                            }
                            else
                            {
                                drAddItem[8] = dt.Rows[i]["Qty"].ToString();
                            }

                            decimal totalarea = Convert.ToDecimal(drAddItem[6]) * Convert.ToDecimal(drAddItem[7]) * Convert.ToDecimal(drAddItem[8]) / 1000000;
                            //drAddItem[9] = Math.Round(totalarea, 2);
                            drAddItem[9] = totalarea;

                            if (dt.Rows[i]["Profile Color"].ToString() == "")
                            {
                                drAddItem[10] = "-";
                            }
                            else
                            {
                                drAddItem[10] = dt.Rows[i]["Profile Color"].ToString();
                            }

                            if (dt.Rows[i]["Hardware Color"].ToString() == "")
                            {
                                drAddItem[11] = "-";
                            }
                            else
                            {
                                drAddItem[11] = dt.Rows[i]["Hardware Color"].ToString();
                            }

                            drAddItem[12] = dt.Rows[i]["Profile Cost per unit in Euro"].ToString();

                            decimal euro = Convert.ToDecimal(drAddItem[8]) * Convert.ToDecimal(drAddItem[12]);

                            decimal Basic = euro * Convert.ToDecimal(txtEuroPrice.Text);

                            //Freight Calculations =P22*$Q$6

                            decimal fright = Convert.ToDecimal(txtFreight.Text);
                            decimal totalfright = ((Basic * fright) / 100);

                            // decimal totalfright = Math.Round(Basic * fright / 100, 2);

                            //Customs Calculations =(P25+Q25)*$R$6

                            decimal Customs = Convert.ToDecimal(txtCustoms.Text);

                            decimal basicplustotalfright = Basic + totalfright;

                            //decimal totalCustoms = ((basicplustotalfright * Customs) / 100);

                            //decimal totalCustoms = Math.Round((Basic + totalfright) * Customs / 100, 2);

                            decimal totalCustoms = (Basic + totalfright) * Customs / 100;

                            //Insurance Calculations =(P25+Q25+R25)*$S$6

                            decimal insurance = Convert.ToDecimal(txtInsurance.Text);

                            //decimal insurancetotal = Math.Round((Basic + totalfright + totalCustoms) * insurance / 100, 2);

                            decimal insurancetotal = (Basic + totalfright + totalCustoms) * insurance / 100;

                            ///Clearance Calculations =(P25+Q25+R25+S25)*$T$6

                            decimal clearance = Convert.ToDecimal(txtClearance.Text);

                            //decimal clearancetotal = ((basicplustotalfrightpluscustomsplusinsurance * clearance) / 100);
                            //decimal clearancetotal = Math.Round((Basic + totalfright + totalCustoms + insurancetotal) * clearance / 100, 2);

                            decimal clearancetotal = (Basic + totalfright + totalCustoms + insurancetotal) * clearance / 100;



                            decimal ProfileCost = Basic + totalfright + totalCustoms + insurancetotal + clearancetotal;

                            lblTotalProfileCost.Text = "";
                            //lblTotalProfileCost.Text = Math.Round(ProfileCost, 2).ToString();

                            lblTotalProfileCost.Text = ProfileCost.ToString();


                            decimal wastage = Convert.ToDecimal(txtwastage.Text);

                            decimal WastageTotal = ((ProfileCost * wastage) / 100);

                            lblTotalWastageCost.Text = "";
                            //lblTotalWastageCost.Text = Math.Round(WastageTotal, 2).ToString();
                            lblTotalWastageCost.Text = WastageTotal.ToString();

                            // =((((F8+G8)*2)/305)*I8*$AE$7)
                            /////////WallPlug Calculations

                            decimal f8 = Convert.ToDecimal(drAddItem[6]);
                            decimal g8 = Convert.ToDecimal(drAddItem[7]);
                            decimal ae7 = Convert.ToDecimal(txtWallplugs.Text);
                            decimal I8 = Convert.ToDecimal(drAddItem[8]);

                            decimal wallplug = ((((f8 + g8) * 2) / 305) * I8 * ae7);
                            //lbltotalWallplugwithscrews.Text = Math.Round(wallplug, 2).ToString();
                            lbltotalWallplugwithscrews.Text = wallplug.ToString();
                            //  =(((((F8*4)+(G8*4))/1000)*$AF$6*$AG$6)/300)*I8*$AF$7
                            ///Silicon Calculations

                            decimal af = Convert.ToDecimal(txtSiliconWidth.Text);
                            decimal ag = Convert.ToDecimal(txtSiliconDepth.Text);
                            decimal af7 = Convert.ToDecimal(txtSilicon.Text);

                            decimal Silicon = (((((f8 * 4) + (g8 * 4)) / 1000) * af * ag) / 300) * I8 * af7;

                            //lbltotalSilicon.Text = Math.Round(Silicon, 2).ToString();
                            lbltotalSilicon.Text = Silicon.ToString();
                            //=(((F8+G8))*I8/1000)*4*$AH$7
                            //Masking Tape

                            decimal ah7 = Convert.ToDecimal(txtmaskingpape.Text);

                            decimal maskingtape = (((f8 + g8)) * I8 / 1000) * 8 * ah7;

                            //lbltotalmaskingtape.Text = Math.Round(maskingtape, 2).ToString();


                            lbltotalmaskingtape.Text = maskingtape.ToString();

                            // =(((F8+G8)*2*I8)/1000)*2*$AI$7
                            //Backers Rod

                            decimal ai7 = Convert.ToDecimal(txtbackrod.Text);

                            decimal backersrod = (((f8 + g8) * 2 * I8) / 1000) * 2 * ai7;

                            //lbltotalBackersRod.Text = Math.Round(backersrod, 2).ToString();
                            lbltotalBackersRod.Text = backersrod.ToString();
                            //Fabrication =J8*$AL$6

                            decimal j8 = Convert.ToDecimal(drAddItem[9]);
                            decimal al6 = Convert.ToDecimal(txtfabricationPersqmt.Text);

                            decimal fabrication = j8 * al6;

                            //lbltotalfabrication.Text = Math.Round(fabrication, 2).ToString();
                            lbltotalfabrication.Text = fabrication.ToString();

                            //Installation =$AN$6*J8

                            decimal an6 = Convert.ToDecimal(txtInstallationpersqmt.Text);
                            decimal installation = an6 * j8;

                            //lbltotalinstallation.Text = Math.Round(installation, 2).ToString();
                            lbltotalinstallation.Text = installation.ToString();
                            //TotalCost

                            decimal totalcost = Convert.ToDecimal(lblTotalProfileCost.Text) + Convert.ToDecimal(lblTotalWastageCost.Text) + Convert.ToDecimal(lbltotalWallplugwithscrews.Text) + Convert.ToDecimal(lbltotalSilicon.Text) + Convert.ToDecimal(lbltotalmaskingtape.Text) + Convert.ToDecimal(lbltotalBackersRod.Text);
                            lbltotalCost.Text = Math.Round(totalcost, 2).ToString();
                            //lbltotalCost.Text = totalcost.ToString();
                            //Margin OH =AO8*$AP$6

                            decimal ap6 = Convert.ToDecimal(txtmargin.Text);
                            decimal a08 = Convert.ToDecimal(lbltotalCost.Text);

                            decimal Margin = a08 * ap6 / 100;
                            //lbltotalmargin.Text = Math.Round(Margin, 2).ToString();
                            lbltotalmargin.Text = Margin.ToString();
                            ////CT for Easy

                            decimal ct = Convert.ToDecimal(lbltotalfabrication.Text) + Convert.ToDecimal(lbltotalinstallation.Text) + Convert.ToDecimal(lbltotalCost.Text) + Convert.ToDecimal(lbltotalmargin.Text);
                            lblct.Text = Math.Round(ct, 2).ToString();

                            drAddItem[13] = dt.Rows[i]["Glass Price"].ToString();

                            decimal glassprice = Convert.ToDecimal(drAddItem[13]) * Convert.ToDecimal(drAddItem[9]);
                            //lbltotalGlasspriceCost.Text = Math.Round(glassprice, 2).ToString();
                            lbltotalGlasspriceCost.Text = glassprice.ToString();

                            //decimal tm = Convert.ToDecimal(lblct.Text) + Convert.ToDecimal(lbltotalGlasspriceCost.Text);
                            //  decimal tm = Convert.ToDecimal(lblct.Text) + Convert.ToDecimal(lbltotalGlasspriceCost.Text) + Convert.ToDecimal(lbltotalMsCost.Text) + Convert.ToDecimal(lbltotalSSmesh.Text) + Convert.ToDecimal(lbltotalRecractableMesh.Text);

                            drAddItem[14] = Convert.ToDecimal(string.IsNullOrEmpty(dt.Rows[i]["SS Mesh Price"].ToString()) ? "0" : dt.Rows[i]["SS Mesh Price"].ToString());

                            decimal ssmesh = Convert.ToDecimal(drAddItem[14]) * Convert.ToDecimal(drAddItem[9]);
                            //lbltotalSSmesh.Text = Math.Round(ssmesh, 2).ToString();
                            lbltotalSSmesh.Text = ssmesh.ToString();
                            drAddItem[15] = Convert.ToDecimal(string.IsNullOrEmpty(dt.Rows[i]["Recractable Mesh Price"].ToString()) ? "0" : dt.Rows[i]["Recractable Mesh Price"].ToString());

                            decimal Recractablemesh = Convert.ToDecimal(drAddItem[15]) * Convert.ToDecimal(drAddItem[9]);
                            //lbltotalRecractableMesh.Text = Math.Round(Recractablemesh, 2).ToString();

                            lbltotalRecractableMesh.Text = Recractablemesh.ToString();


                            drAddItem[16] = Convert.ToDecimal(string.IsNullOrEmpty(dt.Rows[i]["MS Insert"].ToString()) ? "0" : dt.Rows[i]["MS Insert"].ToString());
                            decimal MSPrice = Convert.ToDecimal(drAddItem[16]) * Convert.ToDecimal(drAddItem[8]);
                            //  decimal MSPrice = Convert.ToDecimal(drAddItem[16]) * Convert.ToDecimal(drAddItem[9]);
                            //lbltotalMsCost.Text = Math.Round(MSPrice, 2).ToString();

                            lbltotalMsCost.Text = MSPrice.ToString();

                            drAddItem[17] = Convert.ToDecimal(string.IsNullOrEmpty(dt.Rows[i]["Extra Glass Width"].ToString()) ? "0" : dt.Rows[i]["Extra Glass Width"].ToString());

                            drAddItem[18] = Convert.ToDecimal(string.IsNullOrEmpty(dt.Rows[i]["Extra Glass Height"].ToString()) ? "0" : dt.Rows[i]["Extra Glass Height"].ToString());

                            drAddItem[19] = Convert.ToDecimal(string.IsNullOrEmpty(dt.Rows[i]["Extra Glass Qty"].ToString()) ? "0" : dt.Rows[i]["Extra Glass Qty"].ToString());

                            decimal area = Convert.ToDecimal(drAddItem[18]) * Convert.ToDecimal(drAddItem[19]) * Convert.ToDecimal(drAddItem[17]) / 1000000;

                            //drAddItem[20] = Math.Round(area, 2);

                            drAddItem[20] = area;

                            drAddItem[21] = Convert.ToDecimal(string.IsNullOrEmpty(dt.Rows[i]["Extra Glass Price"].ToString()) ? "0" : dt.Rows[i]["Extra Glass Price"].ToString());

                            decimal extraglassprice = Convert.ToDecimal(drAddItem[21]) * Convert.ToDecimal(drAddItem[20]);
                            lbltotalextraglassprice.Text = Math.Round(extraglassprice, 2).ToString();

                            drAddItem[22] = Convert.ToDecimal(string.IsNullOrEmpty(dt.Rows[i]["Hardware"].ToString()) ? "0" : dt.Rows[i]["Hardware"].ToString());

                            decimal extrahardware = Convert.ToDecimal(drAddItem[22]);

                            drAddItem[23] = extrahardware + Convert.ToDecimal(lblct.Text) + Convert.ToDecimal(lbltotalGlasspriceCost.Text) + Convert.ToDecimal(lbltotalMsCost.Text) + Convert.ToDecimal(lbltotalSSmesh.Text) + Convert.ToDecimal(lbltotalRecractableMesh.Text) + Convert.ToDecimal(lbltotalextraglassprice.Text);

                            dtTemp.Rows.Add(drAddItem);
                            Clearlabel();
                        }
                    }

                    // FINALLY, BIND THE EXTRACTED DATA TO THE GRIDVIEW.
                    gvitems.DataSource = dtTemp;
                    gvitems.DataBind();

                    //lblConfirm.Text = "DATA IMPORTED TO THE GRID, SUCCESSFULLY.";
                    //lblConfirm.Attributes.Add("style", "color:green");

                    MessageBox.Show(this, "DATA IMPORTED TO THE GRID, SUCCESSFULLY.");
                }
                catch (Exception ex)
                {
                    // SHOW ERROR MESSAGE, IF ANY.
                    //lblConfirm.Text = ex.Message;
                    //lblConfirm.Attributes.Add("style", "color:red");

                    MessageBox.Show(this, ex.ToString());
                }
                finally
                {
                    // CLEAR.
                    myExcelConn.Close(); myExcelConn = null;
                }
            }
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Cid"].ToString() != "Add")
        {
            string pagenavigationstr = "";
            if (((Button)sender).Text == "Print")
            {
                pagenavigationstr = "../Reports/SMReportViewer.aspx?type=quot&qno=" + Request.QueryString["Cid"].ToString() + "";
            }

            System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "rptwindow", "window.open('" + pagenavigationstr + "','rptview','resizable=yes,scrool=yes,width=900,height=600,status=yes,toolbar=no,menubar=no,scrollbars=yes')", true);
        }
        else
        {
            MessageBox.Show(this, "Print Option Not Avail for this Record");
        }
    }
    protected void btnOptions_Click(object sender, EventArgs e)
    {
        try
        {

            SM.SalesQuotation objSM = new SM.SalesQuotation();
            objSM.QuotId = Request.QueryString["Cid"].ToString();
            objSM.QuotNo = txtquatationno.Text;
            objSM.QuotDate = General.toMMDDYYYY(txtquotationdate.Text);
            objSM.Quotto = ddlquotationto.SelectedItem.Value;

            objSM.Validto = General.toMMDDYYYY(txtValidto.Text);
            objSM.EnqId = ddlEnquiryNo.SelectedItem.Value;
            objSM.CustId = ddlcustomer.SelectedItem.Value;
            objSM.UnitId = ddlsite.SelectedItem.Value;

            objSM.SalesEmpId = ddlSalesEmployee.SelectedItem.Value;
            objSM.PaymentTermsId = ddlpaymentterms.SelectedItem.Value;
            objSM.TermsCondtionId = ddltermscondtions.SelectedItem.Value;
            objSM.Discount = txtdiscount.Text;
            objSM.Tax = txttax.Text;
            objSM.GrandTotal = txttotal.Text;
            objSM.Preparedby = ddlpreparedby.SelectedItem.Value;
            objSM.Approvedby = ddlapprovedby.SelectedItem.Value;

            objSM.Status = "New";

            objSM.Specifications = HttpUtility.HtmlEncode(txtSpecifications.Text);
            objSM.DamagetempId = ddlDamageTerms.SelectedItem.Value;
            objSM.StroageTempId = ddlStroageTerms.SelectedItem.Value;
            objSM.InstallationtempId = ddlInstallation.SelectedItem.Value;
            objSM.DesignerId = ddlDesigner.SelectedItem.Value;

            objSM.AluminumColor = txtaluminiumColor.Text;
            objSM.HardwarecolorItem = txtHardwareColoritem.Text;
            objSM.Windload = txtWindload.Text;



            objSM.Paymentterms = txtpaymenttermsdetails.Text;
            objSM.TermsCondtions = txttermsconditions.Text;
            objSM.StrorageTerms = txtStroagetermsdetails.Text;
            objSM.DamageTerms = txtDamageterms.Text;
            objSM.Installationterms = txtInstallationTerms.Text;


            objSM.RevisedDate = DateTime.Now.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);



            objSM.EuroPrice = txtEuroPrice.Text;
            objSM.Freight = txtFreight.Text;
            objSM.Customes = txtCustoms.Text;
            objSM.Insurance = txtInsurance.Text;
            objSM.Clearance = txtClearance.Text;
            objSM.Wastage = txtwastage.Text;
            objSM.Wallplugs = txtWallplugs.Text;
            objSM.Silicon = txtSilicon.Text;
            objSM.Maskingtape = txtmaskingpape.Text;
            objSM.BackorRod = txtbackrod.Text;
            objSM.FabricationPersqf = txtFabricationPersqft.Text;
            objSM.FabricationPersqm = txtfabricationPersqmt.Text;
            objSM.Installationpersft = txtinstallationpersqft.Text;
            objSM.InstallationPersqm = txtInstallationpersqmt.Text;
            objSM.Margin = txtmargin.Text;
            objSM.Siliconwidht = txtSiliconWidth.Text;
            objSM.SiliconDepth = txtSiliconDepth.Text;
            objSM.Options = lbloptions.Text;
            objSM.Revisedkey = lblRevise.Text;

            if (objSM.SalesQuotationOptions_Save() == "Data Saved Successfully")
            {
                objSM.SalesQuotationDetails_Delete(objSM.QuotId);
                foreach (GridViewRow gvrow in gvitems.Rows)
                {
                    objSM.WindowCode = gvrow.Cells[2].Text;
                    objSM.System = gvrow.Cells[3].Text;
                    objSM.Description = gvrow.Cells[4].Text;
                    objSM.Glass = gvrow.Cells[5].Text;
                    objSM.Location = gvrow.Cells[6].Text;
                    objSM.Mesh = gvrow.Cells[7].Text;

                    objSM.Width = gvrow.Cells[8].Text;
                    objSM.Height = gvrow.Cells[9].Text;
                    objSM.Qty = gvrow.Cells[10].Text;
                    objSM.TotalArea = gvrow.Cells[11].Text;
                    objSM.ProfileColor = gvrow.Cells[12].Text;
                    objSM.HardwareColor = gvrow.Cells[13].Text;

                    TextBox CostPerUnitEuro = (TextBox)gvrow.FindControl("txtItemUnitCostEuro");
                    objSM.ProfileCostEuro = CostPerUnitEuro.Text;

                    TextBox GlassPrice = (TextBox)gvrow.FindControl("txtItemGlassPrice");
                    objSM.GlassPrice = GlassPrice.Text;

                    TextBox MeshPrice = (TextBox)gvrow.FindControl("txtItemMeshPrice");
                    objSM.MeshPrice = MeshPrice.Text;

                    TextBox RecractablePrice = (TextBox)gvrow.FindControl("txtItemRecractablePrice");
                    objSM.RecractablePrice = RecractablePrice.Text;

                    TextBox MSInsertPrice = (TextBox)gvrow.FindControl("txtItemMSInsertPrice");
                    objSM.MsInsertPrice = MSInsertPrice.Text;

                    TextBox ExtraGlassWidth = (TextBox)gvrow.FindControl("txtItemExtraGlasswidth");
                    objSM.ExtraGlassWidth = ExtraGlassWidth.Text;

                    TextBox ExtraGlassHeight = (TextBox)gvrow.FindControl("txtItemExtraGlassheight");
                    objSM.ExtraGlassHeight = ExtraGlassHeight.Text;

                    TextBox ExtraGlassQty = (TextBox)gvrow.FindControl("txtItemExtraGlassQty");
                    objSM.ExtraGlassQty = ExtraGlassQty.Text;

                    TextBox ExtraGlassArea = (TextBox)gvrow.FindControl("txtItemExtraGlassArea");
                    objSM.ExtraGlassArea = ExtraGlassArea.Text;

                    TextBox ExtraGlassPrice = (TextBox)gvrow.FindControl("txtItemExtraGlassPrice");
                    objSM.ExtraGlassPrice = ExtraGlassPrice.Text;

                    TextBox HardWarePrice = (TextBox)gvrow.FindControl("txtItemHardwarePrice");
                    objSM.HardwarePrice = HardWarePrice.Text;

                    TextBox TotalAmount = (TextBox)gvrow.FindControl("txttotalAmount");
                    objSM.TotalAmount = TotalAmount.Text;
                    objSM.SalesQuotationDetails_Save();
                }
            }
            else
            {
                MessageBox.Show(this, "Some Data Missing");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            SM.ClearControls(this);
            SM.Dispose();
            Response.Redirect("~/Modules/Sales/SalesQuotation.aspx");
        }
    }
}