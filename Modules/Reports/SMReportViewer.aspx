﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMReportViewer.aspx.cs" Inherits="Modules_REPORTS_SMReportViewer" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%--<Web:CrystalReportViewer id="CrystalReportViewer1" runat="server" autodatabind="true" reuseparametervaluesonrefresh="True" />--%>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
    <div>
    
    </div>
    </form>
</body>
</html>
