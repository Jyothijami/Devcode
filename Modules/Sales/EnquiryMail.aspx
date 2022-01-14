<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="EnquiryMail.aspx.cs" Inherits="Modules_Sales_EnquiryMail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="select/select2.css" rel="stylesheet" />

    <script>

        $(document).ready(function () {
            $('#<%=Books.ClientID%>').select2({ placeholder: 'Select Employee' });

                    //$("#ContentPlaceHolder1_Books").select2({ placeholder: 'Find and Select Books' });

                });

                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                function EndRequestHandler(sender, args) {
                    //Binding Code Again
                    $(<%=Books.ClientID%>).select2({ placeholder: 'Select Employee' });
                }
    </script>


    <%-- For Cc --%>

    <script>

          $(document).ready(function () {
              $('#<%=tobcc.ClientID%>').select2({ placeholder: 'Select Employee' });

            //$("#ContentPlaceHolder1_Books").select2({ placeholder: 'Find and Select Books' });

        });

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            //Binding Code Again
            $(<%=tobcc.ClientID%>).select2({ placeholder: 'Select Employee' });
                }
    </script>


  
    <table>

        <tr>
            <td>To
            </td>
            <td>
                <asp:TextBox ID="txttomail" runat="server" Height="35px" Width="358px"></asp:TextBox>

                  <select id="Books" style="width: 100%" runat="server"></select>

            <asp:SqlDataSource ID="usersds1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT [EMP_ID], [EMP_EMAIL] FROM [Employee_master]  ORDER BY [EMP_ID]"></asp:SqlDataSource>
            <asp:HiddenField ID="hffromuid1" runat="server" />

            <script>
                $(document).ready(function () {
                    $("#Books").select2({ placeholder: 'Select Employee' });
                });
            </script>

            </td>
        </tr>
        <tr>
            <td>BCC
            </td>
            <td>
                <asp:TextBox ID="txtBCC" runat="server" Height="35px" Width="358px"></asp:TextBox>


                 <select id="tobcc" style="width: 100%" runat="server"></select>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT [EMP_ID], [EMP_EMAIL] FROM [Employee_master]  ORDER BY [EMP_ID]"></asp:SqlDataSource>
            <asp:HiddenField ID="HiddenField1" runat="server" />

            <script>
                $(document).ready(function () {
                    $("#tobcc").select2({ placeholder: 'Select Employee' });
                });
            </script>



            </td>
        </tr>
        <tr>
            <td>CC</td>
            <td>
                <asp:TextBox ID="txtcc" runat="server" Height="35px" Width="358px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Subject
            </td>
            <td>
                <asp:TextBox ID="txtsub" CssClass="editor" runat="server"  ></asp:TextBox>
                 <cc1:HtmlEditorExtender ID="HtmlEditorExtender4" TargetControlID="txtsub" EnableSanitization="false" DisplaySourceTab="false" runat="server" />
                                        
            </td>
        </tr>
        <tr>
            <td>Message
            </td>
            <td>
                <asp:TextBox ID="txtmsg" runat="server" TextMode="MultiLine" Height="102px" Width="362px"
                    Font-Names="Times New Roman" Font-Size="Medium"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center" style="width: 724px">
        <asp:Button ID="Button1" runat="server" Text="Send" BackColor="#999966" OnClick="btnsend_Click" />
        <asp:Button ID="Button2" runat="server" Text="Reset" BackColor="#999966" OnClick="btnreset_Click" /><br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false" ForeColor="Green"></asp:Label>
    </div>
</asp:Content>