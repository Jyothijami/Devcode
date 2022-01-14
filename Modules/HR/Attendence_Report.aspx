<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Attendence_Report.aspx.cs" Inherits="Modules_HR_Attendence_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


     <script type="text/javascript">
         $(document).ready(function () {
             //fnPageLoad();
         });
         function fnPageLoad() {
             $('#<%=gvEmpCTC.ClientID%>').prepend($("<thead></thead>").append($('#<%=gvEmpCTC.ClientID%>').find("tr:first"))).DataTable({

                 bSort: true,
                 dom: '<"html5buttons"B>lTfgitp',
                 //lengthChange: false,
                 pageLength: 10,

                 bStateSave: true,
                 order: [[0, 'desc']],
             });
         }
       </script>


    <script type="text/javascript">
        // Let's use a lowercase function name to keep with JavaScript conventions
        function selectAll(invoker) {
            // Since ASP.NET checkboxes are really HTML input elements
            //  let's get all the inputs 
            var inputElements = document.getElementsByTagName('input');

            for (var i = 0 ; i < inputElements.length ; i++) {
                var myElement = inputElements[i];

                // Filter through the input types looking for checkboxes
                if (myElement.type === "checkbox") {

                    // Use the invoker (our calling element) as the reference 
                    //  for our checkbox status
                    myElement.checked = invoker.checked;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="page-header">
                <div class="page-title">
                    <h3>Employee Attendance Report</h3>
                </div>
            </div>
            <!-- /page header -->
            <div class="form-horizontal">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Month :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass ="select-full" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="Month" DataValueField="ID">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                </asp:DropDownList>    	
				            </div>
                            <label class="col-sm-2 control-label text-right">Financial Year :</label>
				            <div class="col-sm-4">
                                <asp:TextBox ID="txtYear" CssClass ="form-control" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                                <asp:DropDownList ID="ddlYear" CssClass ="select-full" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                            </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Department :</label>
				            <div class="col-sm-4">
                                <asp:DropDownlist ID="ddlDepartment" CssClass="select-full" Width="100%" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack ="true"   runat="server"></asp:DropDownlist>    	
				            </div>
				            <label class="col-sm-2 control-label text-right">Employee :</label>
				            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlEmployee" runat="server" CssClass ="select-full" Width="100%" AutoPostBack="True" >
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                </asp:DropDownList>    	
				            </div>
				        
                       
                        </div>
                        <div class="form-group">
				            <label class="col-sm-2 control-label text-right">Toatl No.Of Days :</label>
				            <div class="col-sm-4">
                                 <asp:TextBox ID="txtNOD" CssClass ="form-control" runat="server" ReadOnly="True"></asp:TextBox>
				            </div>
				        <label class="col-sm-2 control-label text-right">W.Off / Holidays :</label>
				            <div class="col-sm-4">
                                 <asp:TextBox ID="txtHolidays" CssClass ="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                       
                        </div>
                         <div class="form-actions col-sm-offset-2">                            
                             <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="btn btn-primary" Text="Save" />
                        	
                  </div>
                    </div>
                </div>
            </div>
            <div>



                <asp:GridView ID="gvEmpCTC" Width="100%" CssClass="table table-responsive" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gvEmpCTC_PageIndexChanging"  OnRowDataBound="gvEmpCTC_RowDataBound">
                    <Columns>

                        <asp:TemplateField HeaderText="Employee ID">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEmpId" Text='<%#Eval("EMP_ID")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee Name">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEmpName" Text='<%#Eval("Emp_Name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee No">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEmpDept" Text='<%#Eval("EMP_NO")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Designation">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDesignation" Text='<%#Eval("Emp_Desg")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date Of Joining">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDOJ" Text='<%#Eval("Emp_DOJ")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                       

                        <asp:TemplateField HeaderText="Absent Days">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtAbsentDays" CssClass ="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtAbsentDays_TextChanged"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Present Days">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPresentDays"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="CL-OB">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtCLOB" CssClass ="form-control" runat="server" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="CL-LA">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCL" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="CL-CB">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtCLCB" CssClass ="form-control" runat="server" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="EL-OB">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtELOB" CssClass ="form-control" runat="server" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="EL-LA">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEL" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="EL-CB">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtELCB" CssClass ="form-control" runat="server" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Extra">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblExtra" ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Payable Days">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblPD"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="LOP">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblLOP"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TDS">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtTDS" CssClass ="form-control" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Other Deductions">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtOther" CssClass ="form-control" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Salary Advance">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtSalaryAdv" CssClass ="form-control" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Avl Spl Leaves">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtCOB" CssClass ="form-control" runat="server" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Applied Spl Leaves">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtCLC" CssClass ="form-control" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="C-Off(LA)">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtCLA" CssClass ="form-control" runat="server" Text="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="C-Off(CB)">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtCCB" CssClass ="form-control" runat="server" Text="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                <asp:CheckBox ID="cbSelectAll" runat="server" Text="All" OnClick="selectAll(this)" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>




            </div>
            <asp:Label ID="lblWoff" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblHoli" runat="server" Visible="false"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT * FROM [Month_Calendar_tbl]"></asp:SqlDataSource>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

