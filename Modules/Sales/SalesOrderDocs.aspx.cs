using phani.Classes;
using phani.MessageBox;
using Phani.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_Sales_SalesOrderDocs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            if (Qid != "")
            {

                SM.SalesOrder.SalesOrder_Select(ddlQuatationno);

                ddlQuatationno.SelectedValue = Request.QueryString["Cid"].ToString();
                ddlQuatationno_SelectedIndexChanged(sender, e);

            }
        }
    }


    protected void ddlQuatationno_SelectedIndexChanged(object sender, EventArgs e)
    {
        SM.SalesOrder obj = new SM.SalesOrder();
        if (obj.SalesOrder_Select(ddlQuatationno.SelectedItem.Value) > 0)
        {
            txtQuatationDate.Text = obj.SODATE;
            General.GridBindwithCommand(gvElevationDrawings, "select * from SalesOrder_Documents where SO_Id= '" + ddlQuatationno.SelectedItem.Value + "'");

        }
    }



    protected void btnsubmitElevationdrawing_Click(object sender, EventArgs e)
    {
        try
        {
            SM.SalesOrder objSM = new SM.SalesOrder();

            objSM.SODocdate = General.toMMDDYYYY(txtReceiveddate.Text);
            objSM.SODocRemarks = txtremarks.Text;
            objSM.SOID = ddlQuatationno.SelectedItem.Value;

            if (FileUpload1.HasFiles)
            {
                #region ElevationDocuments
                string Attachment = "";
                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Content/SalesOrder_Docs"))
                {

                    foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                    {
                        Random rand = new Random();
                        string randNumber = Convert.ToString(rand.Next(0, 10000));
                        string path = Server.MapPath("~/Content/SalesOrder_Docs/");
                        string fileName = System.IO.Path.GetFileName(uploadedFile.FileName);

                        Attachment = randNumber + "_" + fileName;
                        uploadedFile.SaveAs(path + randNumber + "_" + fileName);
                        objSM.SODocuments = Attachment;
                    }


                }

                #endregion
            }
            else
            {
                objSM.SODocuments = "";
            }

            MessageBox.Show(this, objSM.SODocuments_Details_Save());

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            gvElevationDrawings.DataBind();
            General.GridBindwithCommand(gvElevationDrawings, "select * from SalesOrder_Documents where SO_Id= '" + ddlQuatationno.SelectedItem.Value + "'");

        }
    }


    protected void lbtnElevationDelete_Click(object sender, EventArgs e)
    {
        LinkButton lbtnRegionalMaster;
        lbtnRegionalMaster = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lbtnRegionalMaster.Parent.Parent;
        gvElevationDrawings.SelectedIndex = gvRow.RowIndex;

        if (gvElevationDrawings.SelectedIndex > -1)
        {
            try
            {
                SM.SalesOrder objSM = new SM.SalesOrder();
                MessageBox.Show(this, objSM.SODocumentsDetails_Delete(gvElevationDrawings.SelectedRow.Cells[0].Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                gvElevationDrawings.DataBind();
                General.GridBindwithCommand(gvElevationDrawings, "select * from SalesOrder_Documents where SO_Id= '" + ddlQuatationno.SelectedItem.Value + "'");

            }
        }
        else
        {
            MessageBox.Notify(this, "Please select atleast a Record");
        }
    }


}