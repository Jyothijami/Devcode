<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="MumbaiStockUpdate.aspx.cs" Inherits="Modules_Stock_MumbaiStockUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     <asp:UpdatePanel ID="UpdatePanel14" runat="server">
        <ContentTemplate>
             <div class="page-header">
                <div class="page-title">
                    <h3>Mumbai Stock Update</h3>
                </div>
            </div>

            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="MumbaiStock.aspx">Mumbai Stock </a></li>
                    <li class="active">Mumbai Stock Update</li>
                </ul>
            </div>

         
       <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">

                 <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Upload File:</label>
                    <div class="col-sm-4">
                        <asp:FileUpload ID="FileUpload1" type="file" CssClass="styled" runat="server" />
                    </div>
                    <div class="col-sm-4">
                        <asp:Button ID="btnfileUpload" Text="Upload" CssClass="btn btn-danger" OnClick="btnfileUpload_Click" runat="server" />
                    </div>
                  </div>




                







                </div>
            </div>
           </div>



              </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="btnfileUpload" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>

