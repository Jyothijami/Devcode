<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile.master" AutoEventWireup="true" CodeFile="Drt.aspx.cs" Inherits="Drt" %>

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

           

       <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.6/js/dataTables.buttons.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/buttons/1.5.6/js/buttons.html5.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            //fnPageLoad();
        });
        function fnPageLoad() {
            $('#<%=hai.ClientID%>').prepend($("<thead></thead>").append($('#<%=hai.ClientID%>').find("tr:first"))).DataTable({

                bSort: true,
                dom: '<"html5buttons"B>lTfgitp',
                //lengthChange: false,
                pageLength: 10,
                buttons: ['copyHtml5',
   'excelHtml5',
   'csvHtml5',
   'pdfHtml5'],
                bStateSave: true,
                order: [[0, 'desc']],
            });
        }
    </script>


            <div class="panel panel-danger">

                    

        

            <div class="form-horizontal">
              
                   


                         <div class="panel panel-default" runat ="server"   >
                <div class="panel-heading">
                    <h6 class="panel-title">Daily Report Details</h6>
                </div>
                <div class="panel-body">

                   

                     

                    <div class="">

                          <asp:GridView ID="hai" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="hai_RowDataBound" >
                <Columns>
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


                       <asp:TemplateField HeaderText="Purpose"  SortExpression="Purpose">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQuestion" runat="server" Text='<%# Server.HtmlDecode(Eval("Purpose").ToString()) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left"  />
                                                </asp:TemplateField>

                       <asp:BoundField DataField="Remarks" HeaderText="Remarks"   SortExpression="Remarks">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                          <ItemStyle HorizontalAlign="Left"  />
                        </asp:BoundField>

                        <asp:BoundField DataField="Attended By" HeaderText="Attended By" SortExpression="Attended By" ItemStyle-Wrap="false">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true"/>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="true" />
                        </asp:BoundField>


                </Columns>
            </asp:GridView>
  
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





</asp:Content>

