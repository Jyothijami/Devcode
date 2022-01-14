<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForms/NLMain.master" AutoEventWireup="true" CodeFile="Testing.aspx.cs" Inherits="Modules_Sales_Testing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E9ECEF" AutoGenerateColumns="False" CssClass="table table-bordered"
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
            OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnRowUpdating="GridView1_RowUpdating"
            AllowSorting="True" AllowPaging="True" PageSize="4">
            <Columns>
                <asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="False" />
                <asp:TemplateField HeaderText="Id" SortExpression="Id">
                    <ItemTemplate>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("CUST_UNIT_ID") %>'></asp:Label>
                        <asp:TextBox ID="Id" runat="server" Text='<%# Eval("CUST_UNIT_ID") %>' Width="30px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="cus" SortExpression="cus">
                    <ItemTemplate>
                        <asp:Label ID="cusLabel" runat="server" Text='<%# Eval("CUST_ID") %>'></asp:Label>
                        <asp:TextBox ID="cus" runat="server" Text='<%# Eval("CUST_ID") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Task" SortExpression="Description">
                    <ItemTemplate>
                        <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("CUST_UNIT_NAME") %>'></asp:Label>
                        <asp:TextBox ID="Description" runat="server" Text='<%# Eval("CUST_UNIT_NAME") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Assigned To" SortExpression="AssignedTo">
                    <ItemTemplate>
                        <asp:Label ID="AssignedToLabel" runat="server" Text='<%# Eval("CUST_UNIT_ADDRESS") %>'></asp:Label>
                        <asp:TextBox ID="AssignedTo" runat="server" Text='<%# Eval("CUST_UNIT_ADDRESS") %>' Width="175px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="headerStyle" ForeColor="White" />
            <RowStyle CssClass="rowStyle" />
            <AlternatingRowStyle CssClass="alternatingRowStyle" />
            <FooterStyle CssClass="footerStyle" />
            <PagerStyle CssClass="pagerStyle" ForeColor="White" />
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="Message" runat="server" CssClass="message"></asp:Label>
    </div>

    <div class="row">
        

        <div class="col-lg-12">

        

            <!-- Panel pills -->
            <span class="subtitle">Panel pills</span>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h6 class="panel-title"><i class="icon-droplet2"></i>Panel pills</h6>
                </div>
                <div class="panel-body">
                    <div class="tabbable">
                        <ul class="nav nav-pills nav-justified">
                            <li class="active"><a href="#panel-pill1" data-toggle="tab"><i class="icon-accessibility"></i>Home</a></li>
                            <li><a href="#panel-pill2" data-toggle="tab"><i class="icon-stack"></i>Profile</a></li>
                            <li class="dropdown">
                               
                            </li>
                        </ul>

                        <div class="tab-content pill-content">
                            <div class="tab-pane fade in active" id="panel-pill1">
                                Raw denim you probably haven't heard of them jean shorts Austin. Nesciunt tofu stumptown aliqua, retro synth master cleanse. Mustache cliche tempor, williamsburg carles vegan helvetica. Reprehenderit butcher retro keffiyeh dreamcatcher synth. Cosby sweater eu banh mi, qui irure terry richardson ex squid. Aliquip placeat salvia cillum iphone. Seitan aliquip quis cardigan american apparel, butcher voluptate nisi qui.
                            </div>

                            <div class="tab-pane fade" id="panel-pill2">
                                Food truck fixie locavore, accusamus mcsweeney's marfa nulla single-origin coffee squid. Exercitation +1 labore velit, blog sartorial PBR leggings next level wes anderson artisan four loko farm-to-table craft beer twee. Qui photo booth letterpress, commodo enim craft beer mlkshk aliquip jean shorts ullamco ad vinyl cillum PBR. Homo nostrud organic, assumenda labore aesthetic magna delectus mollit. Keytar helvetica VHS salvia yr, vero magna velit sapiente labore stumptown. Vegan fanny pack odio cillum wes anderson 8-bit, sustainable jean shorts beard ut DIY ethical culpa terry richardson biodiesel. Art party scenester stumptown, tumblr butcher vero sint qui sapiente accusamus tattooed echo park.
                            </div>

                            <div class="tab-pane fade" id="panel-pill3">
                                Etsy mixtape wayfarers, ethical wes anderson tofu before they sold out mcsweeney's organic lomo retro fanny pack lo-fi farm-to-table readymade. Messenger bag gentrify pitchfork tattooed craft beer, iphone skateboard locavore carles etsy salvia banksy hoodie helvetica. DIY synth PBR banksy irony. Leggings gentrify squid 8-bit cred pitchfork. Williamsburg banh mi whatever gluten-free, carles pitchfork biodiesel fixie etsy retro mlkshk vice blog. Scenester cred you probably haven't heard of them, vinyl craft beer blog stumptown. Pitchfork sustainable tofu synth chambray yr.
                            </div>

                            <div class="tab-pane fade" id="panel-pill4">
                                Trust fund seitan letterpress, keytar raw denim keffiyeh etsy art party before they sold out master cleanse gluten-free squid scenester freegan cosby sweater. Fanny pack portland seitan DIY, art party locavore wolf cliche high life echo park Austin. Cred vinyl keffiyeh DIY salvia PBR, banh mi before they sold out farm-to-table VHS viral locavore cosby sweater. Lomo wolf viral, mustache readymade thundercats keffiyeh craft beer marfa ethical. Wolf salvia freegan, sartorial keffiyeh echo park vegan.
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /panel pills -->

           
        </div>
    </div>
</asp:Content>