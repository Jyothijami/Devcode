using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using phani.Classes;
public partial class Modules_Sales_Testing : System.Web.UI.Page
{

    private const int _firstEditCellIndex = 2;
   #region Page Load

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _sampleData = null;
            this.GridView1.DataSource = _sampleData;
            this.GridView1.DataBind();
        }

        if (this.GridView1.SelectedIndex > -1)
        {
            // Call UpdateRow on every postback
            this.GridView1.UpdateRow(this.GridView1.SelectedIndex, false);
        }      
    }

    #endregion

    #region GridView1

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Get the LinkButton control in the first cell
            LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
            // Get the javascript which is assigned to this LinkButton
            string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");

            // If the page contains validator controls then call 
            // Page_ClientValidate before allowing a cell to be edited
            if(Page.Validators.Count > 0)
                _jsSingle = _jsSingle.Insert(11, "if(Page_ClientValidate())");

            // Add events to each editable cell
            for (int columnIndex = _firstEditCellIndex; columnIndex < e.Row.Cells.Count; columnIndex++)
            {
                // Add the column index as the event argument parameter
                string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                // Add this javascript to the onclick Attribute of the cell
                e.Row.Cells[columnIndex].Attributes["onclick"] = js;
                // Add a cursor style to the cells
                e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;"; 
            }     
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;        

        switch (e.CommandName)
        {
            case ("SingleClick"):
                // Get the row index
                int _rowIndex = int.Parse(e.CommandArgument.ToString());
                // Parse the event argument (added in RowDataBound) to get the selected column index
                int _columnIndex = int.Parse(Request.Form["__EVENTARGUMENT"]);
                // Set the Gridview selected index
                _gridView.SelectedIndex = _rowIndex;
                // Bind the Gridview
                _gridView.DataSource = _sampleData;
                _gridView.DataBind();

                // Write out a history if the event
                this.Message.Text += "Single clicked GridView row at index " + _rowIndex.ToString() 
                    + " on column index " + _columnIndex + "<br />";

                // Get the display control for the selected cell and make it invisible
                Control _displayControl = _gridView.Rows[_rowIndex].Cells[_columnIndex].Controls[1]; 
                _displayControl.Visible = false;
                // Get the edit control for the selected cell and make it visible
                Control _editControl = _gridView.Rows[_rowIndex].Cells[_columnIndex].Controls[3];
                _editControl.Visible = true;
                // Clear the attributes from the selected cell to remove the click event
                _gridView.Rows[_rowIndex].Cells[_columnIndex].Attributes.Clear();

                // Set focus on the selected edit control
                ScriptManager.RegisterStartupScript(this, GetType(), "SetFocus",
                    "document.getElementById('" + _editControl.ClientID + "').focus();", true);
                // If the edit control is a dropdownlist set the
                // SelectedValue to the value of the display control
                if (_editControl is DropDownList && _displayControl is Label)
                {
                    ((DropDownList)_editControl).SelectedValue = ((Label)_displayControl).Text;
                }
                // If the edit control is a textbox then select the text
                if (_editControl is TextBox)
                {
                   ((TextBox)_editControl).Attributes.Add("onfocus", "this.select()");
                }
                // If the edit control is a checkbox set the
                // Checked value to the value of the display control
                if (_editControl is CheckBox && _displayControl is Label)
                {
                    ((CheckBox)_editControl).Checked = bool.Parse(((Label)_displayControl).Text);
                }

                break;
        }
    }

    /// <summary>
    /// Update the sample data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView _gridView = (GridView)sender;

        if (e.RowIndex > -1)
        {
            // Loop though the columns to find a cell in edit mode
            for (int i = _firstEditCellIndex; i < _gridView.Columns.Count; i++)
            {
                // Get the editing control for the cell
                Control _editControl = _gridView.Rows[e.RowIndex].Cells[i].Controls[3];
                if (_editControl.Visible)
                {
                    int _dataTableColumnIndex = i - 1;

                    try
                    {
                        // Get the id of the row
                        Label idLabel = (Label)_gridView.Rows[e.RowIndex].FindControl("IdLabel");
                        int id = int.Parse(idLabel.Text);
                        // Get the value of the edit control and update the DataTable
                        DataTable dt = _sampleData;
                        DataRow dr = dt.Rows.Find(id);
                        dr.BeginEdit();
                        if (_editControl is TextBox)
                        {
                            dr[_dataTableColumnIndex] = ((TextBox)_editControl).Text;
                        }
                        else if (_editControl is DropDownList)
                        {
                            dr[_dataTableColumnIndex] = ((DropDownList)_editControl).SelectedValue;
                        }
                        else if (_editControl is CheckBox)
                        {
                            dr[_dataTableColumnIndex] = ((CheckBox)_editControl).Checked;
                        }
                        dr.EndEdit();

                        // Save the updated DataTable
                        _sampleData = dt;

                        // Clear the selected index to prevent 
                        // another update on the next postback
                        _gridView.SelectedIndex = -1;

                        // Repopulate the GridView
                        _gridView.DataSource = dt;
                        _gridView.DataBind();
                    }
                    catch (ArgumentException)
                    {
                        this.Message.Text += "Error updating GridView row at index " 
                            + e.RowIndex + "<br />";

                        // Repopulate the GridView
                        _gridView.DataSource = _sampleData;
                        _gridView.DataBind();
                    }   
                }
            }
        }
    }

    protected void AddRow_Click(object sender, EventArgs e)
    {
        // Add a new empty row
        DataTable dt = _sampleData;
        int newid = dt.Rows.Count + 1;
        dt.Rows.Add(new object[] { newid, "", "", "", false });
        _sampleData = dt;

        // Repopulate the GridView
        this.GridView1.DataSource = _sampleData;
        this.GridView1.DataBind();
    }

    #endregion

    #region Render Override

    // Register the dynamically created client scripts
    protected override void Render(HtmlTextWriter writer)
    {
        // The client events for GridView1 were created in GridView1_RowDataBound
        foreach (GridViewRow r in GridView1.Rows)
        {
            if (r.RowType == DataControlRowType.DataRow)
            {
                for (int columnIndex = _firstEditCellIndex; columnIndex < r.Cells.Count; columnIndex++)
                {
                    Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl00", columnIndex.ToString());
                }
            }
        }
      
        base.Render(writer);
    }

    #endregion

    /// <summary>
    /// Property to manage data
    /// </summary>
    private DataTable _sampleData
    {
        get
        {
            DataTable dt = (DataTable)Session["TestData"];

            if (dt == null)
            {
                // Create a DataTable and save it to session
                dt = new DataTable();


                General obj = new General();
                string sql = "select * from Customer_Units";
                 dt = obj.ReturnDataTable(sql);

                 // Add the id column as a primary key
                 DataColumn[] keys = new DataColumn[1];
                 keys[0] = dt.Columns["CUST_UNIT_ID"];
                 dt.PrimaryKey = keys;
                GridView1.DataSource = dt;
                _sampleData = dt;
            }

            return dt;
        }
        set
        {
            Session["TestData"] = value;
        }
    }

   
}