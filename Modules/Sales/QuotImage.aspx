<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuotImage.aspx.cs" Inherits="Modules_Sales_QuotImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div class="page-header">
                <div class="page-title">
                    <h3>Quatation Item Images</h3>
                </div>
            </div>

            <div class="breadcrumb-line">
                <ul class="breadcrumb">
                    <li><a href="SalesQuotation.aspx">Quatation</a></li>
                    <li class="active">Quatation Item Images</li>
                </ul>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title">Quatation Item Images</h6>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-5">
                                <label>Quatation No:  </label>
                                <asp:DropDownList ID="ddlQuatationno" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlQuatationno_SelectedIndexChanged" CssClass="select-full" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-5">
                                <label>Quatation Date:  </label>
                                <asp:TextBox ID="txtQuatationDate" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                    </div>

                    <div class="panel panel-default">


                        <div class="panel-body">


                            <div class="">

                        <asp:GridView ID="gvItems" runat="server" AutoGenerateColumns="False" DataKeyNames="QuotationDet_id" CssClass="table table-bordered" OnRowDataBound="gvItems_RowDataBound"
                              onrowcommand="gvItems_RowCommand" Width="100%" >
                            <Columns>
                                <asp:BoundField DataField="QuotationDet_id" HeaderText="QuotationDet_id" />
                                <asp:BoundField DataField="Width" HeaderText="Width" />
                                <asp:BoundField DataField="Height" HeaderText="Height" />



                                <asp:TemplateField HeaderText="Image View" ControlStyle-Width="100px" ControlStyle-Height="100px">
               <%-- <ItemTemplate>
                    <asp:Image ID="Image" runat="server" ImageUrl='<%# "Handler.ashx?id=" + Eval("QuotationDet_id")  %>' />
                </ItemTemplate>--%>
                                     <ItemTemplate>
                                    <asp:Image ID="Image" runat="server" ImageUrl="~/images/noname.jpg" Width="89px" />
                                </ItemTemplate>
            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Elevation View">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtelevationview" CssClass="form-control" Width="80px" runat="server" Text='<%# Eval("ElevationView") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                 </asp:TemplateField>

                                <asp:TemplateField HeaderText="Upload">
                                    <ItemTemplate>

                                    
                                        <asp:FileUpload ID="FileUpload1" runat="server" EnableViewState="true" />
                                        <asp:Button ID="saveBtn" runat="server"
                                            CommandArgument="<%# Container.DataItemIndex%>" CommandName="save"
                                            Text="OK" />

                                    </ItemTemplate>
                                </asp:TemplateField>


                                


                            </Columns>
                        </asp:GridView>

                                </div>
                       </div>
                    </div>
                </div>
            </div>
    </div>
    </form>
</body>
</html>
