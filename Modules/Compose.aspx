<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Compose.aspx.cs" Inherits="Modules_Compose" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="RegUpdatePanel" runat="server">
         <ContentTemplate>
   
  <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Compose New Message</h3>
        </div>
    </div>

    <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="Home.aspx">Home</a></li>
                    <li class="active">Compose</li>
                </ul>
    </div>
        
        
    <div class="row">
        <div class="col-md-3">
            <a href="MailBox.aspx" class="btn btn-primary btn-block margin-bottom">Inbox</a>

            <div class="box box-solid">
                <div class="box-header with-border">
                    <h3 class="box-title "></h3>
                </div>
                <div class="box-body no-padding">
                    <ul class="nav nav-pills nav-stacked">
                        <li class="active"><a href="#"><i class="fa fa-inbox"></i>Inbox</a></li>
                        <li><a href="#"><i class="fa fa-envelope-o"></i>Sent</a></li>
                     
                        <li><a href="#"><i class="fa fa-filter"></i>Trash </a>
                        </li>
                        
                    </ul>
                </div>
                <!-- /.box-body -->
            </div>
            <!-- /. box -->
        </div>
        <!-- /.col -->
        <div class="col-md-9">
            <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Compose New Message</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">


                <div class="form-horizontal">
                     

              <div class="form-group">
                <label class="col-sm-1 control-label text-right">To :</label>
                   <div class="col-sm-11">
                  <asp:DropDownList ID="ddlTo" Width="100%" CssClass="select-full" runat="server"></asp:DropDownList>
                       </div>
              </div>
              <div class="form-group">
                   <label class="col-sm-1 control-label text-right">Subject :</label>
                  <div class="col-sm-11">
                  <asp:TextBox ID="txtSubject" CssClass="form-control" placeholder="Subject" runat="server"></asp:TextBox>
                   </div>
                       </div>
              <div class="form-group">
                    <div class="col-sm-12">
                  <asp:TextBox ID="txtDescription" CssClass="editor" placeholder="Enter Description" TextMode="MultiLine" runat="server"></asp:TextBox>
                          <cc1:HtmlEditorExtender
                                                ID="HtmlEditorExtender5" TargetControlID="txtDescription" EnableSanitization="false" DisplaySourceTab="false" 
                                                runat="server" />
                        </div>
                         </div>
             
                </div>
              </div>
                
                
                
                 <div class="form-group">
                <div class="btn btn-default btn-file">
                  Attachment
                  <asp:FileUpload ID="FileUpload1" AllowMultiple="true"  runat="server" />
                </div>
              
              </div>
            
            <!-- /.box-body -->
            <div class="box-footer">
              <div class="pull-right">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Send" OnClick="btnSave_Click" />
              </div>
            </div>
            <!-- /.box-footer -->
          </div>
            <!-- /. box -->
        </div>
        <!-- /.col -->
    </div>
         </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <%--   <asp:AsyncPostBackTrigger ControlID="btSubmit" />--%>
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>

