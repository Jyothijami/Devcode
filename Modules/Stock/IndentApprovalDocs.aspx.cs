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

public partial class Modules_Purchases_IndentApprovalDocs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {
            if (Qid != "")
            {

                SCM.IndentApproval.IndentApprovalStua_Select(ddlQuatationno);

                ddlQuatationno.SelectedValue = Request.QueryString["Cid"].ToString();
                ddlQuatationno_SelectedIndexChanged(sender, e);

            }
        }
    }


    protected void ddlQuatationno_SelectedIndexChanged(object sender, EventArgs e)
    {
        SCM.IndentApproval obj = new SCM.IndentApproval();
        if (obj.IndentApproval_Select(ddlQuatationno.SelectedItem.Value) > 0)
        {
            txtQuatationDate.Text = obj.IndappDate;
            General.GridBindwithCommand(gvElevationDrawings, "select * from IndentApproval_Docs where IA_Id= '" + ddlQuatationno.SelectedItem.Value + "'");

        }
    }



    protected void btnsubmitElevationdrawing_Click(object sender, EventArgs e)
    {
        try
        {
            SCM.IndentApproval objSM = new SCM.IndentApproval();

            objSM.PODocdate = General.toMMDDYYYY(txtReceiveddate.Text);
            objSM.PODocRemarks = txtremarks.Text;
            objSM.IndappId = ddlQuatationno.SelectedItem.Value;

            if (FileUpload1.HasFiles)
            {
                #region ElevationDocuments
                string Attachment = "";
                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Content/IndentApprovalDocs"))
                {

                    foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                    {
                        Random rand = new Random();
                        string randNumber = Convert.ToString(rand.Next(0, 10000));
                        string path = Server.MapPath("~/Content/IndentApprovalDocs/");
                        string fileName = System.IO.Path.GetFileName(uploadedFile.FileName);

                        Attachment = randNumber + "_" + fileName;
                        uploadedFile.SaveAs(path + randNumber + "_" + fileName);
                        objSM.PODocuments = Attachment;
                    }


                }

                #endregion
            }
            else
            {
                objSM.PODocuments = "";
            }

            MessageBox.Show(this, objSM.PODocuments_Details_Save());

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString());
        }
        finally
        {
            gvElevationDrawings.DataBind();
            General.GridBindwithCommand(gvElevationDrawings, "select * from IndentApproval_Docs where IA_Id= '" + ddlQuatationno.SelectedItem.Value + "'");

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
                SCM.IndentApproval objSM = new SCM.IndentApproval();
                MessageBox.Show(this, objSM.PODocumentsDetails_Delete(gvElevationDrawings.SelectedRow.Cells[0].Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                gvElevationDrawings.DataBind();
                General.GridBindwithCommand(gvElevationDrawings, "select * from IndentApproval_Docs where IA_Id= '" + ddlQuatationno.SelectedItem.Value + "'");

            }
        }
        else
        {
            MessageBox.Notify(this, "Please select atleast a Record");
        }
    }


}