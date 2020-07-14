<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAdminHome.aspx.vb" Inherits="frmAdminHome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
        <title>Online Social Network</title>
        
        <style type="text/css">
        .style1
        {
            height: 254px;
        }
    </style>
    
</head>

<body style="background-image: url('images/body-bg.jpg');">

 
    <form id="form1" runat="server">
    <!-- start page -->
    
<div style="width:960px; height: 1185px; background-color:#FFF; margin-top: 10px; margin-bottom: 80px; text-align:center; margin-left: auto; margin-right: auto;">
    <table style="width:100%;" >
        <tr>
            <td class="style1" colspan="3" style="background-image: url('otherimage/networking-banner.jpg'); background-repeat: no-repeat;">
            </td>
        </tr>

                <tr>
            <td colspan="3">
                <asp:LinkButton ID="LinkButton6" runat="server" Font-Bold="True" Font-Size="X-Large" PostBackUrl="~/frmSplChar.aspx" >Special Character Dictionary</asp:LinkButton>
            </td>
        </tr>

                <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>


        <tr>
            <td colspan="3">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                    Font-Size="X-Large" PostBackUrl="~/frmStopWords.aspx" >Stopword Dictionary</asp:LinkButton>
            </td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

             <tr>
            <td colspan="3">
                <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" 
                    Font-Size="X-Large" PostBackUrl="~/frmEngWords.aspx">English Word Dictionary</asp:LinkButton>
            </td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

             <tr>
            <td colspan="3" style="margin-left: 40px">
                <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="True" 
                    Font-Size="X-Large" PostBackUrl="~/frmBadWords.aspx">Bad Word Dictionary</asp:LinkButton>
            </td>
        </tr>

                <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

             <tr>
            <td colspan="3">
                <asp:LinkButton ID="LinkButton4" runat="server" Font-Bold="True" 
                    Font-Size="X-Large" PostBackUrl="~/frmClasses.aspx">Classification Classes</asp:LinkButton>
            </td>
        </tr>


                <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

             <tr>
            <td colspan="3">
                <asp:LinkButton ID="LinkButton5" runat="server" Font-Bold="True" 
                    Font-Size="X-Large" PostBackUrl="~/frmClassTerms.aspx">Classification Words</asp:LinkButton>
            </td>
        </tr>


                <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

                     <tr>
            <td colspan="3">
                <asp:LinkButton ID="LinkButton7" runat="server" Font-Bold="True" 
                    Font-Size="X-Large" PostBackUrl="~/frmShortText.aspx">Short Text Words</asp:LinkButton>
            </td>
        </tr>


       <tr>
            <td colspan="3">
               <br /> 
                <asp:Button ID="btnPreProcess" runat="server"  
                    Text="Pre-Process Words" Font-Bold="True" Font-Size="Large" 
                    ForeColor="Blue" /> <br /><br />

                <asp:Button ID="btnApriori" runat="server" 
                    Text="Apriori Classifer" Font-Bold="True" Font-Size="Large" height="33px" 
                    width="252px" ForeColor="Blue" />
                    &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReport1" runat="server" 
                    Text="View Graph" Font-Bold="True" Font-Size="Large" height="33px" 
                    width="252px" ForeColor="Blue" Visible="False" />
                    
                     <br /><br />

                <asp:Button ID="btnNaiveBayes" runat="server"  
                    Text="Naive Bayes Classifer" Font-Bold="True" Font-Size="Large" 
                    height="33px" width="252px" ForeColor="Blue" /> 
                    
                    &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReport2" runat="server" 
                    Text="View Graph" Font-Bold="True" Font-Size="Large" height="33px" 
                    width="252px" ForeColor="Blue" Visible="False" />
                    
                <br /><br />

                <asp:Button ID="btnBlog" runat="server"  
                    Text="Blog Classification" Font-Bold="True" Font-Size="Large" 
                    height="33px" width="252px" ForeColor="Blue" /> <br /><br />

            </td>
        </tr>


                <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
             <tr>
            <td colspan="3">
                
                <asp:Button ID="btnLogout" runat="server" onclick="btnLogout_Click" 
                    Text="Logout" Font-Bold="True" Font-Size="Large" />
                
            </td>
        </tr>
        <tr>        
            <td colspan = "3">
            <center>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"  
                    CellPadding="4" EnableModelValidation="True" Height="189px" 
                    Width="501px" onpageindexchanging="GridView1_PageIndexChanging1">
                         <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                         <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                         <PagerSettings Mode="NextPreviousFirstLast" />
                         <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                         <RowStyle BackColor="White" ForeColor="#330099" />
                         <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                     </asp:GridView>
                     </center>
                &nbsp;</td>
        </tr>


    </table>
</div>
<!-- end page -->
    </form>
</body>
</html>

