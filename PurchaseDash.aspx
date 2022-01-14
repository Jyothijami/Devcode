<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PurchaseDash.aspx.cs" Inherits="PurchaseDash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Daily Report</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1, maximum-scale=1" />
    <link href="/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
     <link href="/css/londinium-theme.css" rel="stylesheet" type="text/css" />
    <link href="/css/styles.css" rel="stylesheet" type="text/css" />
    <link href="/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="/css/select2.min.css" rel="stylesheet" type="text/css" />


   

    <script type="text/ecmascript" src='<%= ResolveUrl("~/js/bootstrap.min.js") %>'></script>
    <script type="text/ecmascript" src='<%= ResolveUrl("~/js/plugins/interface/datatables.min.js") %>'></script>
    <script type="text/ecmascript" src='<%= ResolveUrl("~/js/plugins/forms/validate.min.js") %>'></script>
    <script type="text/ecmascript" src='<%= ResolveUrl("~/js/plugins/forms/select2.min.js") %>'></script>




    <style>

        body{
            font-size:18px;
        }

    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>

            





    <asp:GridView ID="GridView2" HeaderStyle-BackColor="#9AD6ED" HeaderStyle-ForeColor="#636363" OnRowDataBound="GridView2_RowDataBound" Width="100%" CssClass="table table-bordered"
    runat="server" AutoGenerateColumns="false" OnDataBound = "GridView2_DataBound">

    <Columns>
        <asp:BoundField DataField="So_Id" HeaderText="So_Id" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150" />
        <asp:BoundField DataField="CUST_UNIT_NAME" HeaderText="Project" HeaderStyle-HorizontalAlign="Center"  ItemStyle-Width="150" />
        <asp:BoundField DataField="ProjectCode" HeaderText="ProjectCode" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="150" />
       
        <asp:TemplateField HeaderText ="Confirmation_Date" >
   <ItemTemplate >
   <asp:Label ID="lblConfrimationdate" runat="server" 
              DataFormatString="{0:dd/MM/yyyy}" 
              HtmlEncode="false"  
              Text='<%# Eval("Confirmation_Date", "{0:dd/MM/yyyy}") %>'  />
    </ItemTemplate>
</asp:TemplateField>

        <asp:TemplateField HeaderText ="Actual" >
   <ItemTemplate >
   <asp:Label ID="lblShopDrawing_Actual" runat="server" 
              DataFormatString="{0:dd/MM/yyyy}" 
              HtmlEncode="false"  
              Text='<%# Eval("ShopDrawing_Actual", "{0:dd/MM/yyyy}") %>'  />
    </ItemTemplate>
</asp:TemplateField>

           <asp:TemplateField HeaderText ="Received" >
   <ItemTemplate >
   <asp:Label ID="lblShopDrawing_Received" runat="server" 
              DataFormatString="{0:dd/MM/yyyy}" 
              HtmlEncode="false"  
              Text='<%# Eval("ShopDrawing_Received", "{0:dd/MM/yyyy}") %>'  />
    </ItemTemplate>
</asp:TemplateField>
      <%-- <asp:BoundField DataField="Confirmation_Date" HeaderStyle-HorizontalAlign="Center" HeaderText="Confirmation_Date" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150" />--%>
      <%--  <asp:BoundField DataField="ShopDrawing_Actual" HeaderStyle-HorizontalAlign="Center" HeaderText="ShopDrawing_Actual" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150" />--%>
      <%--  <asp:BoundField DataField="ShopDrawing_Received" HeaderStyle-HorizontalAlign="Center" HeaderText="ShopDrawing_Received" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150" />--%>
       


          <asp:TemplateField HeaderText ="Ordered" >
   <ItemTemplate >
   <asp:Label ID="lblMaterialOrder_local_Actual" runat="server" 
              DataFormatString="{0:dd/MM/yyyy}" 
              HtmlEncode="false"  
              Text='<%# Eval("MaterialOrder_local_Actual", "{0:dd/MM/yyyy}") %>'  />
    </ItemTemplate>
</asp:TemplateField>

           <asp:TemplateField HeaderText ="Received" >
   <ItemTemplate >
   <asp:Label ID="lblMaterialOrder_Local_Received" runat="server" 
              DataFormatString="{0:dd/MM/yyyy}" 
              HtmlEncode="false"  
              Text='<%# Eval("MaterialOrder_Local_Received", "{0:dd/MM/yyyy}") %>'  />
    </ItemTemplate>
</asp:TemplateField>





      <%--  <asp:BoundField DataField="MaterialOrder_local_Actual" HeaderText="MaterialOrder_local_Actual" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150" />
        <asp:BoundField DataField="MaterialOrder_Local_Received" HeaderText="MaterialOrder_Local_Received" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150" />
   --%>


           <asp:TemplateField HeaderText ="Ordered" >
   <ItemTemplate >
   <asp:Label ID="lblMaterialOrder_Greece_Actual" runat="server" 
              DataFormatString="{0:dd/MM/yyyy}" 
              HtmlEncode="false"  
              Text='<%# Eval("MaterialOrder_Greece_Actual", "{0:dd/MM/yyyy}") %>'  />
    </ItemTemplate>
</asp:TemplateField>

           <asp:TemplateField HeaderText ="Received" >
   <ItemTemplate >
   <asp:Label ID="lblMaterialOrder_Greece_Received" runat="server" 
              DataFormatString="{0:dd/MM/yyyy}" 
              HtmlEncode="false"  
              Text='<%# Eval("MaterialOrder_Greece_Received", "{0:dd/MM/yyyy}") %>'  />
    </ItemTemplate>
</asp:TemplateField>




      <%--  <asp:BoundField DataField="MaterialOrder_Greece_Actual" HeaderText="MaterialOrder_Greece_Actual" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150" />
        <asp:BoundField DataField="MaterialOrder_Greece_Received" HeaderText="MaterialOrder_Greece_Received" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150" />--%>


          <asp:TemplateField HeaderText ="Ordered" >
   <ItemTemplate >
   <asp:Label ID="lblGlassOrder_Actual" runat="server" 
              DataFormatString="{0:dd/MM/yyyy}" 
              HtmlEncode="false"  
              Text='<%# Eval("GlassOrder_Actual", "{0:dd/MM/yyyy}") %>'  />
    </ItemTemplate>
</asp:TemplateField>

           <asp:TemplateField HeaderText ="Received" >
   <ItemTemplate >
   <asp:Label ID="lblGlassorder_Received" runat="server" 
              DataFormatString="{0:dd/MM/yyyy}" 
              HtmlEncode="false"  
              Text='<%# Eval("Glassorder_Received", "{0:dd/MM/yyyy}") %>'  />
    </ItemTemplate>
</asp:TemplateField>



      <%--  <asp:BoundField DataField="GlassOrder_Actual" HeaderText="GlassOrder_Actual" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150" />
        <asp:BoundField DataField="Glassorder_Received" HeaderText="Glassorder_Received" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150" />--%>

          <asp:TemplateField HeaderText ="Actual Date" >
   <ItemTemplate >
   <asp:Label ID="lblFabrication_Actual" runat="server" 
              DataFormatString="{0:dd/MM/yyyy}" 
              HtmlEncode="false"  
              Text='<%# Eval("Fabrication_Actual", "{0:dd/MM/yyyy}") %>'  />
    </ItemTemplate>
</asp:TemplateField>

           <asp:TemplateField HeaderText ="End Date" >
   <ItemTemplate >
   <asp:Label ID="lblFabrication_Started" runat="server" 
              DataFormatString="{0:dd/MM/yyyy}" 
              HtmlEncode="false"  
              Text='<%# Eval("Fabrication_Started", "{0:dd/MM/yyyy}") %>'  />
    </ItemTemplate>
</asp:TemplateField>
       <%-- <asp:BoundField DataField="Fabrication_Actual" HeaderText="Fabrication_Actual" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150" />
        <asp:BoundField DataField="Fabrication_Started" HeaderText="Fabrication_Started" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150" />--%>
      

           <asp:TemplateField HeaderText ="Start Date" >
   <ItemTemplate >
   <asp:Label ID="lblInstallation_Actual" runat="server" 
              DataFormatString="{0:dd/MM/yyyy}" 
              HtmlEncode="false"  
              Text='<%# Eval("Installation_Actual", "{0:dd/MM/yyyy}") %>'  />
    </ItemTemplate>
</asp:TemplateField>

           <asp:TemplateField HeaderText ="End date" >
   <ItemTemplate >
   <asp:Label ID="lblInstallation_Received" runat="server" 
              DataFormatString="{0:dd/MM/yyyy}" 
              HtmlEncode="false"  
              Text='<%# Eval("Installation_Received", "{0:dd/MM/yyyy}") %>'  />
    </ItemTemplate>
</asp:TemplateField>


      <%--  <asp:BoundField DataField="Installation_Actual" HeaderText="Installation_Actual" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150" />
        <asp:BoundField DataField="Installation_Received" HeaderText="Installation_Received" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150" />--%>
       <%-- <asp:BoundField DataField="Remarks" HeaderText="Remarks"  ItemStyle-Width="150" />
       --%> 
        
         <asp:TemplateField HeaderText="Remarks" SortExpression="Remarks">
                            <ItemTemplate>
                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Server.HtmlDecode(Eval("Remarks").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="100%" />
                        </asp:TemplateField>
        
        <asp:BoundField DataField="Status" HeaderText="Status"  ItemStyle-Width="150" />
   
    </Columns>


</asp:GridView>











        </div>
    </form>
</body>
</html>
