<%@ Page Title="" Language="C#" MasterPageFile="~/NLMain.master" AutoEventWireup="true" CodeFile="Testing.aspx.cs" Inherits="Testing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3/jquery.min.js"></script>

    <script src="jquery-1.12.4.min.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {

            $("#<%=TextBox1.ClientID%>").keyup(function () {
                var username = $(this).val();

                if (username.length >= 3) {
                    $.ajax({
                        url: 'UserName.asmx/UserNameExists',
                        method: 'post',
                        data: { userName: username },
                        dataType: 'json',
                        success: function (data) {
                            // getAllEmployees();
                            var divElement = $('#divOutput');
                            if (data.UserNameInUse) {
                                divElement.text('Customer Name :' + data.CustName + ' With Mobile no :' + data.CustMobile + ' already in use');
                                divElement.css('color', 'red');

                            }
                            else {
                                divElement.text(data.CustName + ' available');
                                divElement.css('color', 'green');
                            }
                        },
                        error: function (err) {
                            alert(err);
                        }
                    })
                }

            })

            function getAllEmployees() {

                $.ajax({
                    url: 'UserName.asmx/GetCustomerDetails',
                    dataType: "json",
                    method: 'post',
                    contentType: "application/json; charset=utf-8",
                    data: {},

                    success: function (data) {
                        $('#result').html('').append('<p>Here are the teams:</p><ul id="teamsList">');
                        var teams = response.d;
                        for (var i = 0; i < teams.length; i++) {
                            $('#teamsList').append('<li>'
		+ teams[i].Name + ' football club, resides on '
		+ teams[i].City + ' and was established on, '
		+ teams[i].Created
		+ '</li >');

                        }

                        //var employeeTable = $('#employee tbody');
                        //employeeTable.empty();

                        //$(data).each(function (index, Customer) {
                        //    employeeTable.append('<tr><td>' + Customer.Name + '</td><td>'
                        //        + Customer.Email + '</td><td>' + Customer.Mobile + '</td><td>'
                        //        + Customer.Address + '</td></tr>');
                        //});
                    },
                    error: function (err) {
                        console.log(err);
                    }
                });

            }

        });
    </script>

    <script type="text/javascript">

        $(document).ready(function () {
            $("#<%=TextBox1.ClientID%>").keyup(function () {
                var username = $(this).val();

                $.ajax({
                    type: "post",
                    url: "UserName.asmx/GetCustomerDetails",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        var json_data = data[0];
                        console.log(json_data[0]);
                    }

                });

            });
        });
    </script>

      <script type="text/javascript">
          $("[src*=plus]").live("click", function () {
              $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
              $(this).attr("src", "Images/minus.png");
          });
          $("[src*=minus]").live("click", function () {
              $(this).attr("src", "Images/plus.png");
              $(this).closest("tr").next().remove();
          });
    </script>

     <link rel="stylesheet" href='https://cdn.jsdelivr.net/sweetalert2/6.3.8/sweetalert2.min.css'
        media="screen" />
    <link rel="stylesheet" href='https://cdn.jsdelivr.net/sweetalert2/6.3.8/sweetalert2.css'
        media="screen" />
  
      <script type="text/javascript">
          function successalert() {
              swal({
                  title: 'Congratulations!',
                  text: 'Your message has been succesfully sent',
                  type: 'success'
              });
          }
    </script>
     <script type="text/javascript" src='https://cdn.jsdelivr.net/sweetalert2/6.3.8/sweetalert2.min.js'> </script>

    UserName :

                <input id="txtUserName" type="text" />

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

    <div id="divOutput"></div>

    <table id="employee" class="table table-bordered" style="margin-top: 10px;">
        <thead class="bg-danger text-center text-white">
            <tr>
                <th>Name</th>
                <th>Email</th>
                <th>Mobile</th>
                <th>Address</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>

    <div id="divOutput1"></div>

    <div id="result"></div>

    <%--<script type="text/javascript">

    $(function () {

        $("#<%= UserName.ClientID %>").keyup(checkUser);

    });

    function checkUser() {

        $.ajax({

            type: "POST",

            url: "UserName.asmx/CheckUser",

            data: { username: $("#<%=UserName.ClientID%>").val() },

            success: function (response) {

                $("#duplicate").empty();

                if (response.d != "0") {

                    $("#duplicate").html(' That user name has already been taken');

                }

            }

        });

    }
</script>--%>

    <%--    <script type="text/javascript" lang="javascript">
        var xmlHttp;
        var requestURL = 'UserNameAvailability.aspx?q=';

        function show_data(strName)
        {
	        if (strName.length > 5)
	        {
		        var url = requestURL + strName;

		        //Create the xmlHttp object to use in the request
		        xmlHttp = GetXmlHttpObject(stateChangeHandler);

		        //Send the xmlHttp get to the specified url
		        xmlHttp_Get(xmlHttp, url);
	        }
	        else
	        {
		        document.getElementById('UserIDCheck').innerHTML = '';
	        }
        }

        function stateChangeHandler()
        {
	        //readyState of 4 or 'complete' represents that data has been returned
	        if (xmlHttp.readyState == 4 || xmlHttp.readyState == 'complete')
	        {
		        //Populate the innerHTML of the div with the results
		        document.getElementById('UserIDCheck').innerHTML = xmlHttp.responseText;
	        }

	        if (xmlHttp.readyState == 1)
	        {
		        document.getElementById('UserIDCheck').innerHTML = 'Loading...,';
	        }
        }

        function xmlHttp_Get(xmlhttp, url)
        {
	        xmlhttp.open('GET', url, true);
	        xmlhttp.send(null);
        }

        function GetXmlHttpObject(handler)
        {
            var objXmlHttp;

            try
            {
                // Firefox, Opera 8.0+, Safari
	            objXmlHttp=new XMLHttpRequest();
	            objXmlHttp.onload = handler;
		        objXmlHttp.onerror = handler;
            }
            catch (e)
            {
                // Internet Explorer  try
	            try
	            {
		            objXmlHttp=new ActiveXObject("Msxml2.XMLHTTP");
		            objXmlHttp.onreadystatechange = handler;
	            }
	            catch (e)
	            {
		            try
		            {
			            objXmlHttp=new ActiveXObject("Microsoft.XMLHTTP");
			            objXmlHttp.onreadystatechange = handler;
		            }
		            catch (e)
		            {
			            alert("Your browser does not support xmlHTTP!");
			            return false;
		            }
	            }
	            return objXmlHttp;
            }
        }
    </script>

     <div class="row">

      <span class="label">User Name:</span>

      <asp:TextBox ID="UserName" runat="server"></asp:TextBox><span id="duplicate"></span>
    </div>

    <div class="row">

      <span class="label">Password:</span>

      <asp:TextBox ID="Password" runat="server"></asp:TextBox>
    </div>

    <div class="row">

      <span class="label">&nbsp;</span>

      <asp:Button ID="btnRegister" runat="server" Text="Register" />
    </div>--%>

    <%--      <p><input type="button" onserverclick="ExportToExcel"
                value="Export data to Excel" runat="server" /></p>

     <p><asp:Label ID="lblConfirm" Text="" runat="server"></asp:Label></p>

      <div style="float:left;padding-right:10px;">
                    <input type="button" onserverclick="ViewData"
                        id="btView" value="View Data" runat="server"
                        style="display:none;" />
                </div>

                <!--DOWNLOAD EXCEL FILE. -->
                <div style="float:left;">
                    <asp:Button ID="btDownLoadFile" Text="Download"
                        OnClick="DownLoadFile" runat="server" style="display:none;" />
                </div>--%>


    <asp:Button ID="Button1"  OnClick="Button1_Click" runat="server" Text="Button" />





   
<asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false" CssClass="Grid" DataKeyNames="Quotation_Id" OnRowDataBound="OnRowDataBound">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Image ID="Image1" Style="height: 40px; cursor: pointer;" src="Images/plus.png" runat="server" />
                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                    <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false" CssClass="ChildGrid">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="150px" DataField="Quotation_Id" HeaderText="Order Id" />
                            <asp:BoundField ItemStyle-Width="150px" DataField="WindowCode"   HeaderText="WindowCode" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField ItemStyle-Width="150px" DataField="Quotation_No" HeaderText="Quotation_No" />
        <asp:BoundField ItemStyle-Width="150px" DataField="Quotation_Date" HeaderText="Quotation_Date" />
    </Columns>
</asp:GridView>





</asp:Content>