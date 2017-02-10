<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="readme.aspx.cs" Inherits="SPAuditApi.readme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>SPAuditApi WebAPI Sample</h1>
        <hr />

        <ul>
            <li>Works best on Visual Studio 2013 or higher</li>
            <li>F5 to build and run</li>
            <li>Open <a href="/api/Audit">/api/Audit</a> to execute GET method and see echo JSON parameter example, test connectivity</li>
			<li>Open <a href="/api/Audit">/api/Audit</a> to execute POST method with params and see JSON of audit events</li>
        </ul>
        <hr />

        <asp:Label ID="lblVersion" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
