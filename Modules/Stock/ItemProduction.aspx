<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="ItemProduction.aspx.cs" Inherits="Modules_Stock_ItemProduction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Item Production Details</h6>
            <span class="pull-right">
                <%--<asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" />--%></span>
        </div>
        <div class="panel-body">
            <div class="datatable-tasks">

                <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                         <asp:BoundField DataField="ProductionOder_det_Id" HeaderText="Sl.No" SortExpression="ProductionOder_det_Id"  />
                         <asp:BoundField DataField="ProductionOrder_No" HeaderText="Production No" SortExpression="ProductionOrder_No" />
                         <asp:BoundField DataField="Material_Code" HeaderText="Item Name" SortExpression="Material_Code" />
                       
                        
                        
                        
                        
                         <asp:BoundField DataField="IsActive" HeaderText="Is Active" SortExpression="IsActive"  />
                      
                        <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Stock/BomDetails.aspx?Cid=" + Eval("Bom_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
                                </span>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-icon btn-danger" OnClick="lbtnDelete_Click"><i class="icon-remove3"></i></asp:LinkButton>
                                </span>
                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center">
                            <span style="color: #CC0000">No Data Found</span>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select *,Bom_No+' - '+Material_Code as BomNo  from Bom,Material_Master where Bom.Item_Id  = Material_Master.Material_Id order by Bom.Bom_Id"></asp:SqlDataSource>
              
            </div>
        </div>
    </div>










</asp:Content>

