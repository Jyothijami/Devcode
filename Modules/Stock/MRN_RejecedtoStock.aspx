<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="MRN_RejecedtoStock.aspx.cs" Inherits="Modules_Stock_MRN_RejecedtoStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     <div class="page-header">
        <div class="page-title">
            <h3>MRN Rejected to Stock</h3>
        </div>
    </div>
    <!-- /page header -->
      <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="ScarpStock.aspx">Mrn Rejected List</a></li>
            <li class="active">Redjected to Stock</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->
  
    <div class="form-horizontal">


     <div class="form-group">

                    <label class="col-sm-2 control-label text-right">MRN No :</label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlmrnno" CssClass="select-full" AutoPostBack="true" OnSelectedIndexChanged="ddlmrnno_SelectedIndexChanged" Width="100%" runat="server"></asp:DropDownList>
                    </div>

                  
     </div>



        <div class="panel">
                    <div class="panel-body">

                        <div class="datatable">

                            <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                Width="100%" >
                                <Columns>
                                    <asp:BoundField DataField="CodeNo" HeaderText="Item Name" />
                                    <asp:BoundField DataField="Series" HeaderText="Description" />
                                    <asp:BoundField DataField="Color" HeaderText="Color" />
                                    <asp:BoundField DataField="Length" HeaderText="Length" />
                                    <asp:BoundField DataField="Qty" HeaderText="Ordered Qty" />
                                    <asp:BoundField DataField="ReceivedQty" HeaderText="ReceivedQty" />
                                    <asp:BoundField DataField="AcceptedQty" HeaderText="AcceptedQty" />
                                    <asp:BoundField DataField="RejectedQty" HeaderText="RejectedQty" />

                                    <asp:TemplateField HeaderText=" Qty to Stock">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRECEIVEDQTY" runat="server" Width="40px" Text='<%# Eval("TakeinStock") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                   
                                    <asp:BoundField DataField="ItemcodeId" HeaderText="ItemcodeId" />
                                    <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                   
                                   

                                  

                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtitemremarks" runat="server" Width="40px" Text='<%# Eval("Remarks") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                     <asp:BoundField DataField="SPR_DET_ID" HeaderText="SPRDETID" />
                                 

                                  

                                </Columns>
                                <EmptyDataTemplate>
                                    <div style="text-align: center">
                                        <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

        <div class="form-group text-center">

               <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnSave_Click" />    
         </div>

       
        






   </div>



</asp:Content>

