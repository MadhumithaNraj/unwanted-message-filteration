<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmReport2.aspx.vb" Inherits="frmReport2" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Online Social Network</title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
    <div>
    
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
    AutoDataBind="True" Height="1202px" ReportSourceID="CrystalReportSource2" 
        Width="903px" GroupTreeImagesFolderUrl="" ToolbarImagesFolderUrl="" 
        ToolPanelWidth="200px" ToolPanelView="None" HasRefreshButton="True" />

        <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
<report filename="CrystalReport2.rpt"></report>
</CR:CrystalReportSource>

        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="CrystalReport1.rpt">
            </Report>
        </CR:CrystalReportSource>

    </div>
    <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" Text="Back" />
            </center>
    </form>
</body>
</html>
