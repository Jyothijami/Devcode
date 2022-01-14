using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using phani.MessageBox;
public partial class Modules_Masters_Quatation_Changeables : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

            show();

            

        }
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
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            Masters.QuatationChangables obj = new Masters.QuatationChangables();
            //objMaster.Cpid = "1";
            obj.EuroPrice = txtEuroPrice.Text;
            obj.Freight = txtFreight.Text ;
            obj.Customes = txtCustoms.Text;
            obj.Insurance = txtInsurance.Text;
            obj.Clearance = txtClearance.Text;
            obj.Wastage = txtwastage.Text ;
            obj.Wallplugs = txtWallplugs.Text;
            obj.Silicon = txtSilicon.Text;
            obj.Maskingtape = txtmaskingpape.Text;
            obj.BackorRod = txtbackrod.Text;
            obj.FabricationPersqf = txtFabricationPersqft.Text;
            obj.FabricationPersqm = txtfabricationPersqmt.Text;
            obj.Installationpersft = txtinstallationpersqft.Text;
            obj.InstallationPersqm = txtInstallationpersqmt.Text;
            obj.Margin = txtmargin.Text;
            obj.Siliconwidht = txtSiliconWidth.Text;
            obj.SiliconDepth = txtSiliconDepth.Text;

            MessageBox.Show(this, obj.QuatationChangables_Update());

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            Masters.ClearControls(this);
            Masters.Dispose();
            show();
           // Response.Redirect("~/Modules/Masters/Quatation_Changeables.aspx");

        }


    }
    protected void txtFabricationPersqft_TextChanged(object sender, EventArgs e)
    {
        if(txtFabricationPersqft.Text != "")
        {
            double a = double.Parse(txtFabricationPersqft.Text);

            double c = (a * 10.764);

            txtfabricationPersqmt.Text = c.ToString();


        }
    }
    protected void txtinstallationpersqft_TextChanged(object sender, EventArgs e)
    {
        if (txtinstallationpersqft.Text != "")
        {
            double a = double.Parse(txtinstallationpersqft.Text);

            double c = (a * 10.764);

            txtInstallationpersqmt.Text = c.ToString();


        }
    }
}