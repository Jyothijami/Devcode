<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="test9.aspx.cs" Inherits="test9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <asp:UpdatePanel ID="UpdatePanel14" runat="server">
        <ContentTemplate>
<%--         
        <%--
        <script type="text/javascript" src="<%= ResolveUrl("~/select/select2.js")%>"></script> --%>

        <link href="select/select2.css" rel="stylesheet"/>

    

     <script>

         $(document).ready(function () {
             $('#<%=Books.ClientID%>').select2({ placeholder: 'Find and Select Books' });


                  //$("#ContentPlaceHolder1_Books").select2({ placeholder: 'Find and Select Books' });


              });


              Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
              function EndRequestHandler(sender, args) {
                  //Binding Code Again
                  $(<%=Books.ClientID%>).select2({ placeholder: 'Find and Select Books' });
              }




         </script>

   


    
        <div >
            <select  id="Books" style="width:300px" runat="server"></select>



           

          <%--  <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />--%>

        </div>

        <asp:Label ID="lblItem" runat="server" Text="Label"></asp:Label>
 
          


        
          <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Upload" />





            <asp:Button ID="btnblock" runat="server"  OnClick="btnblock_Click" Text="Blockstock" />









              </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="Button2" />
        </Triggers>
    </asp:UpdatePanel>







   
</asp:Content>

