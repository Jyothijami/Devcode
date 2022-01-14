<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="MaterialMaster.aspx.cs" Inherits="Modules_Masters_MaterialMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Material Master</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>

        <div class="panel-body">

            <div class="datatable-tasks">

                <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="Material_Id" HeaderText="Sl.No" SortExpression="Material_Id">
                            <HeaderStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Material_Code" HeaderText="Material Code" SortExpression="Material_Code">
                            <HeaderStyle Font-Size="Smaller" />
                            <ItemStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Material_Name" HeaderText="Material Name" SortExpression="Material_Name">
                            <HeaderStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Material_Type" HeaderText="Material Type" SortExpression="Material_Type">
                            <HeaderStyle Font-Size="Smaller" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MaterialGroup" HeaderText="Material Group" SortExpression="MaterialGroup">

                            <HeaderStyle Font-Size="Smaller" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Masters/MaterialMaster_Details.aspx?Cid=" + Eval("Material_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
                                </span>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Purchase Data" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Masters/MaterialMaster_Details.aspx?Cid=" + Eval("Material_Id") %>'><i class="icon-factory"></i></asp:LinkButton>
                                </span>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MRP Data" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-info" PostBackUrl='<%# "~/Modules/Masters/MaterialMaster_Details.aspx?Cid=" + Eval("Material_Id") %>'><i class="icon-cart-plus"></i></asp:LinkButton>
                                </span>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Stores Data" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-primary" PostBackUrl='<%# "~/Modules/Masters/MaterialMaster_Details.aspx?Cid=" + Eval("Material_Id") %>'><i class="icon-tag5"></i></asp:LinkButton>
                                </span>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Accounting Data" HeaderStyle-CssClass="text-center">
                            <ItemTemplate>
                                <span class="text-center">
                                    <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-warning" PostBackUrl='<%# "~/Modules/Masters/MaterialMaster_Details.aspx?Cid=" + Eval("Material_Id") %>'><i class="icon-stackoverflow"></i></asp:LinkButton>
                                </span>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
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
                </asp:GridView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT Material_Master.*, Material_Type.Material_Type, MaterialGroup_Master.MaterialGroup FROM Material_Master INNER JOIN MaterialGroup_Master ON Material_Master.MaterialGroup_Id = MaterialGroup_Master.MaterialGroup_Id INNER JOIN Material_Type ON Material_Master.MaterialType_Id = Material_Type.MaterialType_Id"></asp:SqlDataSource>
                <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>