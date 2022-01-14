<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="ItemPrice.aspx.cs" Inherits="Modules_Masters_ItemPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


      <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Item Price Details</h6>
           <%-- <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>--%>
        </div>
        <div class="panel-body">
            <div class="datatable-tasks">

                <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="Material_Id" HeaderText="Sl.No" SortExpression="Material_Id" />
                        <asp:BoundField DataField="Material_Code" HeaderText="Material Code" SortExpression="Material_Code" />
                        <asp:BoundField DataField="Brand_Name" HeaderText="Brand" SortExpression="Brand_Name"  />
                        <asp:BoundField DataField="sellcur" HeaderText="Selling Currency" SortExpression="sellcur" />
                         <asp:BoundField DataField="SellingPrice" HeaderText="Selling Rate" SortExpression="SellingPrice" />
                      
                           <asp:BoundField DataField="buycur" HeaderText="Buying Currency" SortExpression="buycur" />
                         <asp:BoundField DataField="BuyingPrice" HeaderText="Buying Rate" SortExpression="BuyingPrice" />
                    


                      <%--  <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/MASTERS/Item_Details.aspx?Cid=" + Eval("Material_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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
                        </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="text-align: center">
                            <span style="color: #CC0000">No Data Found</span>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="select *,cm.CURRENCY_NAME as sellcur,bc.CURRENCY_NAME as buycur from Material_Master,Brand_Master,Currency_Master as bc,Currency_Master as cm where Material_Master.Brand_Id = Brand_Master.Brand_Id and Material_Master.BuyingCurrency = bc.CURRENCY_ID and Material_Master.SellingCurrency = cm.CURRENCY_ID"></asp:SqlDataSource>
              
            </div>
        </div>
    </div>





</asp:Content>

