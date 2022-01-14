using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AjaxControlToolkit.HTMLEditor;



/// <summary>
/// Summary description for CustomEditor
/// </summary>
/// 
namespace mycontrols
{ 

public class CustomEditor : Editor
{
	public CustomEditor()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    protected override void FillTopToolbar()
    {
        TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Bold());
        TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Italic());
        TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.FontSize());
        TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.ForeColor());
        TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.JustifyCenter());
        TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.JustifyFull());
        TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.JustifyLeft());
        TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.JustifyRight());
        TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.BackColorSelector());
        TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Paragraph());
        TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Underline());
        TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.StrikeThrough());

    }

    protected override void FillBottomToolbar()
    {
        //BottomToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.DesignMode());
        //BottomToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.PreviewMode());
    }

}

}