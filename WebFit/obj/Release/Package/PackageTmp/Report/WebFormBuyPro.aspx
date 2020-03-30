<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormBuyPro.aspx.cs" Inherits="WebFit.Report.WebFormBuyPro" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 391px;
        }
        .auto-style2 {
            margin-left: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager" runat="server">
            </asp:ScriptManager>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1" Width="169px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style2" OnClick="Button1_Click" Text="ค้นหา" />
        </div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="579px" Width="1043px" style="margin-top: 81px">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
