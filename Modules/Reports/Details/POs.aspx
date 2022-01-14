<%@ Page Title="" Language="C#" MasterPageFile="~/ModalPop.master" AutoEventWireup="true" CodeFile="POs.aspx.cs" Inherits="Modules_Reports_Details_POs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


        <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="Sup_PO_Id" HeaderText="Sl.No" SortExpression="Sup_PO_Id">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>
                <asp:BoundField DataField="Sup_PO_No" HeaderText="Sup PO No" SortExpression="Sup_PO_No">
                    <HeaderStyle Font-Size="Smaller" />
                    <ItemStyle Font-Size="Smaller" />
                </asp:BoundField>

                <asp:BoundField DataField="Sup_PO_Date" HeaderText="Date" SortExpression="Sup_PO_Date" DataFormatString="{0:dd/MM/yyyy}">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>

                <asp:BoundField DataField="SUP_NAME" HeaderText="Supplier Name" SortExpression="SUP_NAME">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>

                <asp:BoundField DataField="SUP_MOBILE" HeaderText="Mobile No" SortExpression="SUP_MOBILE">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>


                <asp:BoundField DataField="preparedby" HeaderText="Prepared By" SortExpression="preparedby">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>




                <asp:BoundField DataField="CustomerNo" HeaderText="CustomerNo" SortExpression="CustomerNo">
                    <HeaderStyle Font-Size="Smaller" />
                </asp:BoundField>

             
                
            </Columns>
        </asp:GridView>

</asp:Content>

