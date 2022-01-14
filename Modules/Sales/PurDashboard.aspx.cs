using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Modules_Sales_PurDashboard : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            SM.SalesOrder.SalesOrder_Select(ddlSalesOrderNo);

            SM.CustomerMaster.CustomerMaster_Select(ddlCustomer);
            SM.CustomerMaster.CustomerUnit_Select(ddlProject);



        }
    }

    protected void ddlSalesOrderNo_SelectedIndexChanged(object sender, EventArgs e)
    {

        SM.SalesOrder obj = new SM.SalesOrder();
        if(obj.SalesOrder_Select(ddlSalesOrderNo.SelectedItem.Value) > 0)
        {
            ddlCustomer.SelectedValue = obj.Custid;
            ddlProject.SelectedValue = obj.SiteId;
            txtSalesOrderDate.Text = obj.SODATE;


            SM.DashBoradPurchase das = new SM.DashBoradPurchase();
            if(das.DashBoradPurchase_Select(ddlSalesOrderNo.SelectedItem.Value) >  0)
            {


                if(das.ConfirmationDate == "01/01/1900")
                {
                    txtConfirmationDate.Text = "";
                }
                else
                {
                    txtConfirmationDate.Text = das.ConfirmationDate;
                }

                if (das.ShopActual == "01/01/1900")
                {
                    txtshopdrawingActutal.Text = "";
                }
                else
                {
                    txtshopdrawingActutal.Text = das.ShopActual;
                }

                if (das.ShopReceived == "01/01/1900")
                {
                    txtShopdrawingReceived.Text = "";
                }
                else
                {
                    txtShopdrawingReceived.Text = das.ShopReceived;
                }

                if (das.MaterialLocal_Actual == "01/01/1900")
                {
                    txtlocalmaterialOrdered.Text = "";
                }
                else
                {
                    txtlocalmaterialOrdered.Text = das.MaterialLocal_Actual;
                }


                if (das.MaterialLocal_Received == "01/01/1900")
                {
                    txtlocalmaterialreceived.Text = "";
                }
                else
                {
                    txtlocalmaterialreceived.Text = das.MaterialLocal_Received;
                }



                if (das.MaterialGreece_actual == "01/01/1900")
                {
                    txtgreecematerialordered.Text = "";
                }
                else
                {
                    txtgreecematerialordered.Text = das.MaterialGreece_actual;
                }


                if (das.MaterialGreece_Received == "01/01/1900")
                {
                    txtgreeceMaterialReceived.Text = "";
                }
                else
                {
                    txtgreeceMaterialReceived.Text = das.MaterialGreece_Received;
                }

                if (das.Glassorder_actual == "01/01/1900")
                {
                    txtglassordered.Text = "";
                }
                else
                {
                    txtglassordered.Text = das.Glassorder_actual;
                }


                if (das.Glassorder_Reveived == "01/01/1900")
                {
                    txtglassreceived.Text = "";
                }
                else
                {
                    txtglassreceived.Text = das.Glassorder_Reveived;
                }




                if (das.Fabrication_actual == "01/01/1900")
                {
                    txtfabricationactual.Text = "";
                }
                else
                {
                    txtfabricationactual.Text = das.Fabrication_actual;
                }


                if (das.Fabrication_Recived == "01/01/1900")
                {
                    txtFabricationReceived.Text = "";
                }
                else
                {
                    txtFabricationReceived.Text = das.Fabrication_Recived;
                }

                if (das.Installation_actual == "01/01/1900")
                {
                    txtInstallationStart.Text = "";
                }
                else
                {
                    txtInstallationStart.Text = das.Installation_actual;
                }


                if (das.Installation_Received == "01/01/1900")
                {
                    txtInstallationEnd.Text = "";
                }
                else
                {
                    txtInstallationEnd.Text = das.Installation_Received;
                }

                txtRemarks.Text = HttpUtility.HtmlDecode(txtRemarks.Text);

                ddlStatus.SelectedItem.Text = das.Status;

                btnSave.Text = "Update";

            }




        }
    }









    


    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (btnSave.Text == "Save")
        {
            SalesOrderSave();
        }
        else if (btnSave.Text == "Update")
        {
            SalesOrderUpdate();
        }




        
    }

    private void SalesOrderUpdate()
    {
        try
        {
            //SqlDateTime sqldatenull;
            SM.DashBoradPurchase objSM = new SM.DashBoradPurchase();
            objSM.SoId = ddlSalesOrderNo.SelectedItem.Value;


            objSM.ConfirmationDate = General.toMMDDYYYY(txtConfirmationDate.Text);
            objSM.ShopActual = General.toMMDDYYYY(txtshopdrawingActutal.Text);
            objSM.ShopReceived = General.toMMDDYYYY(txtShopdrawingReceived.Text);
            objSM.MaterialLocal_Actual = General.toMMDDYYYY(txtlocalmaterialOrdered.Text);
            objSM.MaterialLocal_Received = General.toMMDDYYYY(txtlocalmaterialreceived.Text);
            objSM.MaterialGreece_actual = General.toMMDDYYYY(txtgreecematerialordered.Text);
            objSM.MaterialGreece_Received = General.toMMDDYYYY(txtgreeceMaterialReceived.Text);
            objSM.Glassorder_actual = General.toMMDDYYYY(txtglassordered.Text);
            objSM.Glassorder_Reveived = General.toMMDDYYYY(txtglassreceived.Text);
            objSM.Fabrication_actual = General.toMMDDYYYY(txtfabricationactual.Text);
            objSM.Fabrication_Recived = General.toMMDDYYYY(txtFabricationReceived.Text);
            objSM.Installation_actual = General.toMMDDYYYY(txtInstallationStart.Text);
            objSM.Installation_Received = General.toMMDDYYYY(txtInstallationEnd.Text);
            objSM.Remarks = HttpUtility.HtmlEncode(txtRemarks.Text);
            objSM.Status = ddlStatus.SelectedItem.Value;

            MessageBox.Show(this, objSM.DashBoradPurchase_Update());



        }


        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            SM.ClearControls(this);
            SM.Dispose();
            //  Response.Redirect("~/Modules/Sales/SalesOrder.aspx");
        }
    }

    private void SalesOrderSave()
    {
        try
        {
            //SqlDateTime sqldatenull;
            SM.DashBoradPurchase objSM = new SM.DashBoradPurchase();
            objSM.SoId = ddlSalesOrderNo.SelectedItem.Value;


            objSM.ConfirmationDate = General.toMMDDYYYY(txtConfirmationDate.Text);
            objSM.ShopActual = General.toMMDDYYYY(txtshopdrawingActutal.Text);
            objSM.ShopReceived = General.toMMDDYYYY(txtShopdrawingReceived.Text);
            objSM.MaterialLocal_Actual = General.toMMDDYYYY(txtlocalmaterialOrdered.Text);
            objSM.MaterialLocal_Received = General.toMMDDYYYY(txtlocalmaterialreceived.Text);
            objSM.MaterialGreece_actual = General.toMMDDYYYY(txtgreecematerialordered.Text);
            objSM.MaterialGreece_Received = General.toMMDDYYYY(txtgreeceMaterialReceived.Text);
            objSM.Glassorder_actual = General.toMMDDYYYY(txtglassordered.Text);
            objSM.Glassorder_Reveived = General.toMMDDYYYY(txtglassreceived.Text);
            objSM.Fabrication_actual = General.toMMDDYYYY(txtfabricationactual.Text);
            objSM.Fabrication_Recived = General.toMMDDYYYY(txtFabricationReceived.Text);
            objSM.Installation_actual = General.toMMDDYYYY(txtInstallationStart.Text);
            objSM.Installation_Received = General.toMMDDYYYY(txtInstallationEnd.Text);



            objSM.Remarks = HttpUtility.HtmlEncode(txtRemarks.Text);
            objSM.Status = ddlStatus.SelectedItem.Value;

           MessageBox.Show(this,objSM.DashBoradPurchase_Save());



        }


        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            SM.ClearControls(this);
            SM.Dispose();
            //  Response.Redirect("~/Modules/Sales/SalesOrder.aspx");
        }
    }
}