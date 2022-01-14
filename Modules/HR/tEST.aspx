<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="tEST.aspx.cs" Inherits="Modules_HR_tEST" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div class="block">
     <div class="block-inner">

    <asp:TextBox ID="TextBox1" TextMode="MultiLine" CssClass="editor" runat="server"></asp:TextBox>


        </div>
        </div>



    <h6><i class="icon-pencil"></i> WYSIWYG editor</h6>
				<div class="block-inner">
					<textarea class="editor" placeholder="Enter text ..."></textarea>
				</div>
                <div class="text-right">
	                <button type="submit" class="btn btn-danger">Cancel</button>
					<button type="submit" class="btn btn-primary">Submit</button>
				</div>
</asp:Content>

