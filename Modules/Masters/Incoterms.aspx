﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Incoterms.aspx.cs" Inherits="Modules_Masters_Incoterms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-file"></i>Incoterms Master</h6>
            <span class="pull-right">
                <asp:Button ID="btnAddnew" CssClass="btn btn-warning" runat="server" Text="Add New" OnClick="btnAddnew_Click" /></span>
        </div>
      
        <div class="datatable-tasks">

            <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="IncoTerms_Id" HeaderText="Sl.No" SortExpression="IncoTerms_Id" />
                    <asp:BoundField DataField="IncoTerms" HeaderText="Incoterms" SortExpression="IncoTerms" />
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/Modules/Masters/Incoterm_Details.aspx?Cid=" + Eval("IncoTerms_Id") %>'><i class="icon-wrench2"></i></asp:LinkButton>
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
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT * FROM [Incoterms_Master]"></asp:SqlDataSource>
          
        </div>
    </div>



</asp:Content>

