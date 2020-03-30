<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EQ.aspx.cs" Inherits="WebFit.Report.EQ1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <div class="auto-style3">
             <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
             <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style6" Width="125px"></asp:TextBox>
             <asp:Button ID="Button2" runat="server" CssClass="auto-style8" Text="ถึง" />
             <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style7"></asp:TextBox>
             <asp:Button ID="Button1" runat="server" CssClass="auto-style5" OnClick="Button1_Click" Text="ค้นหา" />
             <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="auto-style4">
                 <asp:ListItem Value="01">ชื่อ</asp:ListItem>               
                 <asp:ListItem Value="02">วันที่</asp:ListItem>
             </asp:CheckBoxList>
        </div>
         <rsweb:ReportViewer ID="ReportViewer2" runat="server" Height="764px" Width="1400px" CssClass="auto-style1"></rsweb:ReportViewer>
    </form>
</body>
</html>
