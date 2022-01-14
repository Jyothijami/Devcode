<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="PackingMaterial.aspx.cs" Inherits="Modules_Masters_PackingMaterial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <div class="panel panel-default">
			                <div class="panel-heading"><h6 class="panel-title"><i class="icon-file"></i>Packing Material</h6> <span class="pull-right">
          <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span></div>
			          

                   <div class="panel-body">         
                                        
        <div class="datatable-tasks">                        

    <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="PackingMaterial_Id" HeaderText="Sl.No" SortExpression="PackingMaterial_Id" />
            <asp:BoundField DataField="Packing_Material" HeaderText="Packing Material" SortExpression="Packing_Material" />
            <asp:BoundField DataField="Packing_Description" HeaderText="Description" SortExpression="Packing_Description" />
            <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center" >
                <ItemTemplate>
                    <span class="text-center">
                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Masters/PackingMaterial_Details.aspx?Cid=" + Eval("PackingMaterial_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
               </span> </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center" >
                 <ItemTemplate>
                    <span class="text-center">
                    <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-icon btn-danger" OnClick="lbtnDelete_Click"><i class="icon-remove3"></i></asp:LinkButton>
               </span> </ItemTemplate>

                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />

            </asp:TemplateField>
        </Columns>
                                <EmptyDataTemplate>
                                    <div style="text-align: center">
                                        <span style="color: #CC0000">No Data Found</span></div>
        </EmptyDataTemplate>
                                </asp:GridView>

                              
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="Select * from Packing_Material">
                                        </asp:SqlDataSource>
                                 <asp:Label id="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                            <asp:Label id="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
                              </div>
                       </div>  
  </div>
				     



</asp:Content>

