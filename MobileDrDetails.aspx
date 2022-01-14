﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.master" AutoEventWireup="true" CodeFile="MobileDrDetails.aspx.cs" Inherits="MobileDrDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    
            <script lang="javascript" type="text/javascript">
                function check(e) {
                    var keynum
                    var keychar
                    var numcheck
                    // For Internet Explorer
                    if (window.event) {
                        keynum = e.keyCode;
                    }
                        // For Netscape/Firefox/Opera
                    else if (e.which) {
                        keynum = e.which;
                    }
                    keychar = String.fromCharCode(keynum);
                    //List of special characters you want to restrict
                    if (keychar == "'" || keychar == "`" || keychar == "&" || keychar == "¬" || keychar == '"') {
                        return false;
                    } else {
                        return true;
                    }
                }
    </script>

            <script type="text/javascript">
                $(document).ready(function () {
                    //fnPageLoad();
                });
                function fnPageLoad() {
                    $('#<%=gvDrs.ClientID%>').prepend($("<thead></thead>").append($('#<%=gvDrs.ClientID%>').find("tr:first"))).DataTable({

                        bSort: true,
                        dom: '<"html5buttons"B>lTfgitp',
                        //lengthChange: false,
                        pageLength: 10,

                        bStateSave: true,
                        order: [[0, 'desc']],
                    });
                }
            </script>


        <div class="form-horizontal">

       <div class="panel panel-default">

                <div class="panel-body">


     
            <div class="panel panel-danger">

                    <div class="page-header">
                <div class="page-title">
                    
                </div>
            </div>

           <%-- <!-- Breadcrumbs line -->
            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="DR.aspx">Daily Report</a></li>
                    <li><a href="DrDetails.aspx">Daily Details</a></li>

                    

                    <li class="active"><a href="~/MobileLogin.aspx" runat="server"><i class="icon-exit"></i>Logout</a></li>
                </ul>
            </div>--%>

        
              
                   


                         <div class="panel panel-default" runat ="server"   >
                <div class="panel-heading">
                    <h3 class="panel-title">Daily Report Details</h3>
                </div>
                <div class="panel-body">

                   

                       <div class="form-group">

                            <div class="form-actions col-sm-offset-6">
                                  <asp:Button ID="btnDelete" runat="server" CssClass="btn  btn-danger" Text="Delete" OnClick="btnDelete_Click" Visible ="false"  CausesValidation="False" />
                            </div>
                        </div>


                    <div class="datatable-tasks">
                        <div>
                            <asp:GridView ID="gvDrs" CssClass="table table-bordered" Width="100%" runat="server"  EmptyDataText="No Records To Display" AllowPaging="True"  PageSize="8" AutoGenerateColumns="False" OnRowDataBound="gvDrs_RowDataBound">
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

                        <asp:TemplateField HeaderText="Form Id" SortExpression="DAILYREPORTID" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblId" Text='<%#Eval("DAILYREPORTID")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                        </asp:BoundField>

                        <asp:BoundField DataField="In Time" HeaderText="In Time" SortExpression="In Time">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Out Time" HeaderText="Out TIME" SortExpression="Out Time">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Client Name" HeaderText="Client" SortExpression="Client Name" ItemStyle-Wrap="false">
                            
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Wrap="true" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Reference" HeaderText="Reference" SortExpression="Reference">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Architect" HeaderText="Architect" SortExpression="Architect">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-Wrap="false" SortExpression="Address">
                            
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                        </asp:BoundField>

                      <asp:TemplateField HeaderText="Purpose" SortExpression="Purpose">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuestion" runat="server" Text='<%# Server.HtmlDecode(Eval("Purpose").ToString()) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="60%"  Font-Size="X-Small" Wrap="true"/>
                                                </asp:TemplateField>

                        <asp:BoundField DataField="Remarks" HeaderText="Remarks"  ItemStyle-Wrap="false" SortExpression="Remarks">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="X-Small" Wrap="true"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Attended By" HeaderText="Attended By" SortExpression="Attended By" ItemStyle-Wrap="false">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="X-Small" Wrap="true" />
                        </asp:BoundField>

                    <%--    <asp:BoundField DataField="Executive Name" HeaderText="Executive Name" SortExpression="Executive Name" ItemStyle-Wrap="false">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Comments">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtComment" TextMode="SingleLine" Width="150px" Text='<%#Eval("Comments")%>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        <asp:BoundField DataField ="DAILYREPORTID" HeaderText ="Id" />
                     <asp:TemplateField HeaderText="Documents" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <span class="text-center">
                                <asp:LinkButton ID="lbtnDocuments" runat="server" CssClass="btn btn-icon btn-success" PostBackUrl='<%# "~/DrDocs.aspx?Cid=" + Eval("DAILYREPORTID") %>'><i class="icon-attachment"></i></asp:LinkButton>
                            </span>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Smaller" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="Silver"></SelectedRowStyle>
                </asp:GridView>
                        </div>
                    </div>


                        </div>


                    
                         </div>
                 <div id="lables">
                <asp:Label ID="lblUserType" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblEmpIdHidden" runat="server" Visible="False"></asp:Label>
                                    <asp:Label ID="lblDeptId" runat ="server" Visible ="false" ></asp:Label>
                                    <asp:Label ID="lblDeptHead" runat ="server" Visible ="false"  ></asp:Label>
                                    <asp:Label ID="lblDeptHeadId" runat ="server" Visible ="false" ></asp:Label>


            </div>





                    </div>
              

            </div>


                    </div>
         </div>


</asp:Content>

