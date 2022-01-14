<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="SentMail.aspx.cs" Inherits="Modules_SentMail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <script type="text/javascript">
         //On Page Load
         $(function () {
             $('#<%= hai.ClientID %>').DataTable();
         });

         //On UpdatePanel Refresh

</script>

     <!-- Page header -->
    <div class="page-header">
        <div class="page-title">
            <h3>Mail Box</h3>
        </div>
    </div>

    <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="Home.aspx">Home</a></li>
                    <li class="active">MailBox</li>
                </ul>
    </div>


    <div class="row">
        <div class="col-md-3">
            <a href="Compose.aspx" class="btn btn-primary btn-block margin-bottom">Compose</a>

            <div class="box box-solid">
                <div class="box-header with-border">
                    <h3 class="box-title "></h3>
                </div>
                <div class="box-body no-padding">
                    <ul class="nav nav-pills nav-stacked">
                        <li class="active"><a href="MailBox.aspx"><i class="fa fa-inbox"></i>Inbox
                </a></li>
                        <li><a href="SentMail.aspx"><i class="fa fa-envelope-o"></i>Sent</a></li>
                     
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
                    <h3 class="box-title">Sent</h3>

                    
                    <!-- /.box-tools -->
                </div>
                <!-- /.box-header -->
                <div class="box-body no-padding">
                    
                    <div class="table-responsive mailbox-messages">
                        

                          <asp:GridView ID="hai" CssClass="table table-responsive" runat="server" AutoGenerateColumns="False" OnPreRender="hai_PreRender" >
                   <Columns>
                    <asp:BoundField DataField="EMP_FIRST_NAME" HeaderText="" SortExpression="EMP_FIRST_NAME"></asp:BoundField>
                    <asp:BoundField DataField="Subject" HeaderText="" SortExpression="Subject"></asp:BoundField>
                    <asp:BoundField DataField="SentDate" HeaderText="" DataFormatString="{0:MMMM d, yyyy}" HtmlEncode="false" SortExpression="SentDate"></asp:BoundField>

                   
                    

                    

                                  </Columns>
            </asp:GridView>

                        <!-- /.table -->
                    </div>
                    <!-- /.mail-box-messages -->
                </div>
                <!-- /.box-body -->
                
            </div>
            <!-- /. box -->
        </div>
        <!-- /.col -->
    </div>



</asp:Content>

