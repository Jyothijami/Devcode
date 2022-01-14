<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.master" AutoEventWireup="true" CodeFile="Mobiletodo.aspx.cs" Inherits="Mobiletodo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


       <asp:UpdatePanel ID="UpdatePanel344" runat="server">
        <ContentTemplate>

             <link href="select/select2.css" rel="stylesheet"/>

            <script>

                $(document).ready(function () {
                    $('#<%=Books.ClientID%>').select2({ placeholder: 'Select Employee' });


                    //$("#ContentPlaceHolder1_Books").select2({ placeholder: 'Find and Select Books' });


                });


                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                function EndRequestHandler(sender, args) {
                    //Binding Code Again
                    $(<%=Books.ClientID%>).select2({ placeholder: 'Select Employee' });
        }




         </script>

               <div class="form-horizontal">
          

                   <div class="panel panel-default">

                     


                       <div class="panel-body">

                              <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">To Do List</h6>
                </div>
                <div class="panel-body">

                       <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Date & Time :</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtIssueddt" runat ="server" CssClass="form-control"></asp:TextBox>

                        <asp:Image
                                    ID="Image1" class="ui-datepicker-trigger" runat="server" ImageUrl="~/images/calendar.png"></asp:Image>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="Calendarextender1" runat="server" PopupButtonID="Image1"
                                    TargetControlID="txtIssueddt">
                                </cc1:CalendarExtender>
                            </div>
                        </div>



                    
                       <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Reporting To :</label>
                            <div class="col-sm-10">
                                  <select id="Books" style="width:100%" runat="server"></select>
                                   
                                  <asp:SqlDataSource ID="usersds1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT EMP_FIRST_NAME+' '+EMP_LAST_NAME as EMP_FIRST_NAME,EMP_ID FROM EMPLOYEE_MASTER where EMP_ID != 0"></asp:SqlDataSource>
                                        <asp:HiddenField ID="hffromuid1" runat="server" />


                                           <script>
                                               $(document).ready(function () {
                                                   $("#Books").select2({ placeholder: 'Select Employee' });
                                               });
                                               </script>
                            </div>
                        </div>

                      <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Subject :</label>
                            <div class="col-sm-10">
                               <asp:TextBox ID="txtSubject" runat ="server" CssClass="form-control"  ></asp:TextBox>
                            </div>
                        </div>

                   <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Task Activity Description :</label>
                            <div class="col-sm-10">
                              <asp:TextBox ID="txtDescr" runat ="server" CssClass="form-control" TextMode ="MultiLine" ></asp:TextBox>
                            </div>
                        </div>
                  
                  <div class="form-group">
                            <label class="col-sm-2 control-label text-right">Task Activity Status :</label>
                            <div class="col-sm-4">
                             <asp:DropDownList ID="ddlActivity" runat ="server" CssClass ="form-control" >
                                <asp:ListItem Value ="55" >To Do</asp:ListItem>
                                <asp:ListItem Value ="56" >In-Progress</asp:ListItem>
                                <asp:ListItem Value ="57">Completed</asp:ListItem>
                            </asp:DropDownList>
                            </div>
                        </div>


                         <div class="form-group">
                     
                         
                          
                                <div class="form-actions text-right">
                                    <asp:Button ID="btnListSave" runat="server" CssClass="btn btn-lg btn-danger " OnClick ="btnListSave_Click" Text="Save" />
                                    <asp:Label ID="Label21" runat="server" Visible="False"></asp:Label>
                               
                                     </div>
                           
                       
                    </div>
                
                   
                   
                </div>
           
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">To DO List Details</h6>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <div class="row">

                    <div class="col-md-1"></div>
                    <div class="col-md-5">
                        <asp:Label ID="Label22" runat ="server"  Text ="From Date" ></asp:Label>
                         <asp:TextBox ID="txtListFrom" runat ="server" CssClass="form-control" type="datepic"></asp:TextBox>
                    </div>
                   <div class="col-md-5">
                        <asp:Label ID="Label23" runat ="server"  Text ="To Date" ></asp:Label>
                         <asp:TextBox ID="txtListTo" runat ="server" CssClass="form-control" type="datepic"></asp:TextBox>
                    </div>
                </div>
                        <div class="row">

                    <div class="col-md-1"></div>
                    <div class="col-md-5">
                        <asp:Label ID="Label24" runat ="server"  Text ="Subject" ></asp:Label>
                         <asp:TextBox ID="txtListSubject" runat ="server" CssClass="form-control" ></asp:TextBox>
                    </div>
                   <div class="col-md-5">
                        <asp:Label ID="Label25" runat ="server"  Text ="Executive Name" ></asp:Label>
                         <asp:DropDownList ID="ddlEmp" runat="server" CssClass ="form-control"></asp:DropDownList>
                    </div>
                </div>
                        <div class="form-group">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-10">
                                <div class="form-actions text-center">
                        <asp:Button ID="btnListSearch" runat="server" Text="Search" OnClick="btnListSearch_Click" CausesValidation="False" />
                <asp:Button ID="btnListDelete" runat="server" Text="Delete" OnClick="btnListDelete_Click" Visible ="false"  CausesValidation="False" />
                                    <asp:Button ID="btnListUpdate" runat ="server" Text ="Update" OnClick ="btnListUpdate_Click" Visible ="false" CausesValidation ="false" />
<asp:Label ID="lblItem" runat ="server" Visible ="false" ></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                    </div>
                        
                        <div>
                            <asp:GridView ID="gvList" CssClass="table table-bordered" Width="100%" OnRowDataBound ="gvlist_RowDataBound" runat="server" SelectedRowStyle-BackColor="#c0c0c0" EmptyDataText="No Records To Display" AllowPaging="True" OnPageIndexChanging="gvList_PageIndexChanging" PageSize="8" AutoGenerateColumns="False" >
                    <Columns>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkhdr" runat="server" AutoPostBack="True" OnClick="selectAll(this)" />
                            </HeaderTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="Chk" OnCheckedChanged="Chk_CheckedChanged" AutoPostBack="true" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Id" SortExpression="ID" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblId" Text='<%#Eval("ID")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                        </asp:BoundField>
                         <asp:BoundField DataField="IssuedDate" HeaderText="IssuedDate" SortExpression="IssuedDate">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                        </asp:BoundField>
                       

                        <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" ItemStyle-Wrap="false">
                            
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Wrap="true" />
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                        </asp:BoundField>
                         <%-- <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlStatus" runat="server">
                                   <asp:ListItem >To Do</asp:ListItem>
                                <asp:ListItem >In-Progress</asp:ListItem>
                                <asp:ListItem >Completed</asp:ListItem>
                                </asp:DropDownList>
                                <asp:HiddenField ID="cthf1" runat="server" Value='<%# Eval("Status") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PreparedBy" HeaderText="PreparedBy" SortExpression="PreparedBy" ItemStyle-Wrap="false">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                        </asp:BoundField>
                        <asp:BoundField DataField ="ID" HeaderText ="Id" />
                        <asp:TemplateField HeaderText ="Reporting To">
                            <HeaderStyle HorizontalAlign ="Center"  />
                             <ItemTemplate>
                                 <asp:GridView ID="gvChild" CssClass="table table-bordered" ShowHeader ="false" EnableTheming ="false" Width ="100%"  runat ="server"  AutoGenerateColumns ="false">
                                                  <Columns >
                                                      <%--<asp:BoundField DataField ="ID" HeaderText ="ID" />--%>
                                                       
                                     <asp:BoundField  DataField ="EMP_FIRST_NAME" HeaderText ="Reporting To" >
                                          <ItemStyle HorizontalAlign ="Center" />
                         <HeaderStyle HorizontalAlign ="Center" /> </asp:BoundField>
                                     
                                                  </Columns>
                                             </asp:GridView>
                             </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="Silver"></SelectedRowStyle>
                </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <asp:Label ID="lblSearchTypeHidden" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblSearchValueFromHidden" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblSearchItemHidden" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblSearchValueHidden" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblUserType" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblEmpIdHidden" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblDeptId" runat ="server" Visible ="false" ></asp:Label>
                                    <asp:Label ID="lblDeptHeadId" runat ="server" Visible ="false" ></asp:Label>
                                    <asp:Label ID="lblDeptHead" runat ="server" Visible ="false"  ></asp:Label>
                                    <asp:Label ID="lblUserId" runat ="server" Visible ="false" ></asp:Label>
            </div>


                       </div>

                   </div>


         

                   </div>
        </ContentTemplate>
         <Triggers>
            <asp:PostBackTrigger ControlID="btnListSave" />
            
        </Triggers>
    </asp:UpdatePanel>





</asp:Content>

