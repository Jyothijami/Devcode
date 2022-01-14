using phani.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HR_SalaryStructure_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Qid = Request.QueryString["Cid"].ToString();
        if (!IsPostBack)
        {

            //Masters.DDLBindWithSelect(ddlempcategory, "select * from Department_Master");
            //Masters.DDLBindWithSelect(ddlallowance, "select * from Salary_Component");

            Masters.Department.Department_Select(ddlempcategory);
            HR.Salary_Component.Salary_Component_Select(ddlallowance);


            if (Qid != "Add")
            {
                CategoryFill();
            }
        }
    }


    private void CategoryFill()
    {
        HR.AllowanceSetup objmaster = new HR.AllowanceSetup();
        if (objmaster.Allowance_Setup_Select(Request.QueryString["Cid"].ToString()) > 0)
        {
            btnSave.Text = "Update";
            ddlCalculation.SelectedValue = objmaster.Calcualtion;
            ddlempcategory.SelectedValue = objmaster.Catid;
            ddlallowance.SelectedItem.Value = objmaster.Allowanceid;
            txtAmount.Text = objmaster.amount;
            if (objmaster.setuptype == "+")
            {
                rdbearnings.Checked = true;
                rdbDeduction.Checked = false;
            }
            else
            {
                rdbearnings.Checked = false;
                rdbDeduction.Checked = true;
            }


        }
    }











    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnSave.Text == "Save")
            {
                string Type;
                if (rdbearnings.Checked == true)
                    Type = "+";
                else
                    Type = "-";

                if (ddlCalculation.Text == "AMOUNT" && Convert.ToDouble(txtAmount.Text) <= Convert.ToDouble(txtMaxAmount.Text))
                {
                    HR.AllowanceSetup obj = new HR.AllowanceSetup();
                    MessageBox.Show(this, obj.AllowanceSetup_Save(int.Parse(ddlempcategory.SelectedItem.Value), int.Parse(ddlallowance.SelectedItem.Value), Type, ddlCalculation.SelectedItem.Value, double.Parse(txtAmount.Text)));
                }
                else if (ddlCalculation.Text == "PERCENTAGE" && Convert.ToDouble(txtAmount.Text) < 100)
                {
                    HR.AllowanceSetup obj = new HR.AllowanceSetup();
                    MessageBox.Show(this, obj.AllowanceSetup_Save(int.Parse(ddlempcategory.SelectedItem.Value), int.Parse(ddlallowance.SelectedItem.Value), Type, ddlCalculation.SelectedItem.Value, double.Parse(txtAmount.Text)));
                }
                else
                {
                    MessageBox.Show(this, "You have entered Maximum Amount for the allowance, Please Check");
                }

            }
            else if (btnSave.Text == "Update")
            {
                string Type;
                if (rdbearnings.Checked == true)
                    Type = "+";
                else
                    Type = "-";
                if (ddlCalculation.Text == "AMOUNT" && Convert.ToDouble(txtAmount.Text) <= Convert.ToDouble(txtMaxAmount.Text))
                {
                    HR.AllowanceSetup obj = new HR.AllowanceSetup();
                    MessageBox.Show(this, obj.AllowanceSetup_Update(int.Parse(Request.QueryString["Cid"].ToString()), int.Parse(ddlempcategory.SelectedItem.Value), int.Parse(ddlallowance.SelectedItem.Value), Type, ddlCalculation.SelectedItem.Value, double.Parse(txtAmount.Text)));
                }
                else if (ddlCalculation.Text == "PERCENTAGE" && Convert.ToDouble(txtAmount.Text) < 100)
                {
                    HR.AllowanceSetup obj = new HR.AllowanceSetup();
                    MessageBox.Show(this, obj.AllowanceSetup_Update(int.Parse(Request.QueryString["Cid"].ToString()), int.Parse(ddlempcategory.SelectedItem.Value), int.Parse(ddlallowance.SelectedItem.Value), Type, ddlCalculation.SelectedItem.Value, double.Parse(txtAmount.Text)));

                }

                else
                {
                    MessageBox.Show(this, "You have entered Maximum Amount for the allowance, Please Check");
                }

            }

           
           
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
        finally
        {
            HR.ClearControls(this);
            HR.Dispose();
            Response.Redirect("~/Modules/HR/SalaryStructure.aspx");
        }
    }


    #region  ddLcALC
    protected void ddlCalculation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCalculation.SelectedItem.Text == "AMOUNT")
        {
            lblAmount.Text = "Amount";
        }
        else
        {
            lblAmount.Text = "Percentage";
        }
    }
    #endregion


    #region Allowance Selected Index Changed
    protected void ddlAllowance_SelectedIndexChanged(object sender, EventArgs e)
    {


        HR.Salary_Component obj = new HR.Salary_Component();

     if(obj.Salary_Component_Select(ddlallowance.SelectedItem.Value) > 0)
     {
         txtMaxAmount.Text = obj.MaxAmount;
     }




    }
    #endregion





}