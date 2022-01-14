<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="IndentApproval_Details.aspx.cs" Inherits="Modules_Stock_IndentApproval_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
<!--
    function Check_Click(objRef) {
        //Get the Row based on checkbox
        var row = objRef.parentNode.parentNode;

        //Get the reference of GridView
        var GridView = row.parentNode;

        //Get all input elements in Gridview
        var inputList = GridView.getElementsByTagName("input");

        for (var i = 0; i < inputList.length; i++) {
            //The First element is the Header Checkbox
            var headerCheckBox = inputList[0];

            //Based on all or none checkboxes
            //are checked check/uncheck Header Checkbox
            var checked = true;
            if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                if (!inputList[i].checked) {
                    checked = false;
                    break;
                }
            }
        }
        headerCheckBox.checked = checked;

    }
    function checkAll(objRef) {
        var GridView = objRef.parentNode.parentNode.parentNode;
        var inputList = GridView.getElementsByTagName("input");
        for (var i = 0; i < inputList.length; i++) {
            var row = inputList[i].parentNode.parentNode;
            if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                if (objRef.checked) {
                    inputList[i].checked = true;
                }
                else {
                    if (row.rowIndex % 2 == 0) {
                        row.style.backgroundColor = "#C2D69B";
                    }
                    else {
                        row.style.backgroundColor = "white";
                    }
                    inputList[i].checked = false;
                }
            }
        }
    }
    //-->
    </script>

    <div class="page-header">
        <div class="page-title">
            <h3>Indent Approval Details</h3>
        </div>
    </div>
    <!-- /page header -->

    <!-- Breadcrumbs line -->
    <div class="breadcrumb-line">
        <ul class="breadcrumb">
            <li><a href="IndentApproval.aspx">Indent Approval</a></li>
            <li class="active">Indent Approval Details</li>
        </ul>
    </div>
    <!-- /breadcrumbs line -->

    <div class="form-horizontal">
        <div class="panel panel-default">
            <div class="panel-body">

                <div class="form-group">
                    <label class="col-sm-2 control-label text-right">Indent Approval No :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtMaterialreqestNo" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <label class="col-sm-2 control-label text-right">Indent Approval Date :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtMrdate" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:Image
                            ID="imgQuotationDate" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender2" runat="server" PopupButtonID="imgQuotationDate"
                            TargetControlID="txtMrdate">
                        </cc1:CalendarExtender>
                    </div>
                </div>

                <div class="panel panel-danger">
                    <div class="panel-heading">

                        <h5 class="panel-title">Get Items From Indent Order </h5>

                        <div class="panel-icons-group">
                            <a href="#" data-panel="collapse" class="btn btn-link btn-icon"><i class="icon-arrow-up9"></i></a>
                        </div>
                    </div>

                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Indent No :</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlIndent" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="ddlIndent_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="" style="padding-top: 10px">
                            <asp:GridView ID="gvIndent" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvIndent_RowDataBound"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);"
                                                AutoPostBack="true" OnCheckedChanged="CheckBox_CheckChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)"
                                                AutoPostBack="true" OnCheckedChanged="CheckBox_CheckChanged" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                                    <asp:BoundField DataField="Series" HeaderText="Series" />
                                    <asp:BoundField DataField="Length" HeaderText="Length" />
                                    <asp:BoundField DataField="Color" HeaderText="Color" />
                                    <asp:BoundField DataField="RequiredDate" HeaderText="Required Date" />
                                    <asp:BoundField DataField="Requestfor" HeaderText="Request For" />
                                    <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                                    <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                                    <asp:BoundField DataField="SoId" HeaderText="SoId" />
                                    <asp:BoundField DataField="SoMatId" HeaderText="SoMatId" />
                                    <asp:BoundField DataField="RequiredQty" HeaderText="RequiredQty" />
                                    <asp:BoundField DataField="Uom" HeaderText="Uom" />
                                    <asp:BoundField DataField="PU" HeaderText="PU" />
                                    <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                    <asp:BoundField DataField="IndId" HeaderText="IndId" />

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

                <div class="" style="padding-top: 10px">
                    <asp:GridView ID="gvItems" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvItems_RowDataBound"
                        Width="100%" OnRowDeleting="gvItems_RowDeleting">
                        <Columns>

                            <asp:CommandField ShowDeleteButton="True" />
                            <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                            <asp:BoundField DataField="Series" HeaderText="Series" />
                            <asp:BoundField DataField="Length" HeaderText="Length" />
                            <asp:BoundField DataField="Color" HeaderText="Color" />
                            <asp:BoundField DataField="RequiredDate" HeaderText="Req Date" />
                            <asp:BoundField DataField="Requestfor" HeaderText="Req For" />
                            <asp:BoundField DataField="ItemCodeId" HeaderText="ItemCodeId" />
                            <asp:BoundField DataField="ColorId" HeaderText="ColorId" />
                            <asp:BoundField DataField="SoId" HeaderText="SoId" />
                            <asp:BoundField DataField="SoMatId" HeaderText="SoMatId" />
                            <asp:BoundField DataField="RequiredQty" HeaderText="RequiredQty" />
                            <asp:BoundField DataField="Uom" HeaderText="Uom" />
                            <asp:BoundField DataField="PU" HeaderText="PU" />
                            <asp:BoundField DataField="Qty" HeaderText="Qty" />
                            <asp:BoundField DataField="QtyinStock" HeaderText="Available Qty" />


                            <asp:TemplateField HeaderText="Qty to Order">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtqtyorder" CssClass="form-control" runat="server" Text='<%# Bind("qtyorder") %>'></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtqtyorder" ForeColor="Red" ErrorMessage="Qty can't be blanked"></asp:RequiredFieldValidator>  
                                     </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtitemremarks" CssClass="form-control" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Block Qty">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBlockQty" CssClass="form-control" runat="server" Text='<%# Bind("BlockQty") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IndId" HeaderText="IndId" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center">
                                <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>

                <div class="panel panel-default">
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Remarks :</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txttermscondtionscontent" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                                <cc1:HtmlEditorExtender
                                    ID="HtmlEditorExtender5" TargetControlID="txttermscondtionscontent" EnableSanitization="false" DisplaySourceTab="false"
                                    runat="server" />
                            </div>
                        </div>

                       
                    </div>
                </div>







                 <div class="panel panel-default">
                    <div class="panel-body">


                 <div class="bg-primary with-padding block-inner">Indent Items</div>
                <div class="form-group">

                    <asp:GridView ID="gvIndentedappr" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvIndentedappr_RowDataBound"
                        Width="100%" >
                        <Columns>

                           
                            <asp:BoundField DataField="Material_Code" HeaderText="Item Code" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:BoundField DataField="Bar_Length" HeaderText="Length" />
                            <asp:BoundField DataField="Color_Name" HeaderText="Color" />
                            <asp:BoundField DataField="Req_Date" HeaderText="Req Date" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="RequestedFor" HeaderText="Req For" />
                            <asp:BoundField DataField="QtytoOrder" HeaderText="Approved Qty" />
                         <%--   <asp:BoundField DataField="Remarks" HeaderText="Remarks" />--%>
                          
                              <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtitemremarks" CssClass="form-control" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:BoundField DataField="InApproval_Det_Id" HeaderText="DetId" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center">
                                <span class="auto-style1" style="color: #CC0000">No Records Added</span>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>

                </div>


                 <div class="bg-primary with-padding block-inner">Office Details</div>
                            <div class="form-horizontal">

                                <div class="form-group">
                                    <label class="col-sm-2 control-label text-right">Prepared By :</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlpreparedby" Enabled="false" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>

                                    <label class="col-sm-2 control-label text-right">Approved By:</label>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlapprovedby" Enabled="false" Width="100%" TabIndex="2" CssClass="select-full" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                
                <div class="form-group">

                    <div class="form-actions col-sm-offset-10">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-success" Text="Approve" OnClick="btnApprove_Click" />
                    </div>
                </div>


                <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server"  DisplayMode="BulletList" ShowSummary="false"/>  
      
                        </div></div>



            </div>
        </div>
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </div>
</asp:Content>