<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test6.aspx.cs" Inherits="test6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js"></script>
    <script src="select/select2.js"></script>
    <link href="select/select2.css" rel="stylesheet"/>


</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <select  id="Books" style="width:300px" runat="server"></select>


            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />

        </div>
        <asp:Label ID="lblItem" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>

    <script>
        $(document).ready(function () {
            $("#Books").select2({ placeholder: 'Find and Select Books' });
        });
</script>
</html>
