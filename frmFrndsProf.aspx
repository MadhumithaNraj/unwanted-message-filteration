<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmFrndsProf.aspx.vb" Inherits="frmFrndsProf" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Online Social Network</title>
      <style type="text/css">
        .style35
        {
            height: 17px;
            width: 361px;
        }
        .style37
        {
            height: 324px;
            width: 725px;
        }
        .style50
        {
            width: 188px;
            
        }
        .style57
    {
        height: 18px;
        width: 361px;
    }
        .style77
        {
              width: 11px;
              font-weight: 700;
              height: 341px;
          }
        .style78
        {
              width: 684px;
              height: 341px;
          }
        .style79
        {
            height: 341px;
        }
        .style81
        {
            height: 45px;
        }
        .style83
        {
            height: 137px;
        }
        .style89
        {
            height: 38px;
        }
        .style90
        {
            color: #000000;
        }
          .style92
          {
              width: 166%;
              height: 367px;
          }
          .style93
          {
              width: 340%;
              height: 566px;
          }
          .style94
          {
              width: 100%;
              height: 344px;
          }
          .style95
          {
              width: 100%;
              height: 476px;
          }
          .style96
          {
              width: 228px;
              height: 139px;
          }
          .button1
          {}
          .style97
          {
              width: 450px;
          }
          .auto-style1 {
              width: 943px;
              height: 341px;
          }
    </style>
    
</head>
<body style="background-image: url('images/body-bg.jpg'); background-repeat: no-repeat;">

    <form id="form1" runat="server">
    <div>
    <br /><br /><br />
       <table style="border: thin solid #C0C0C0; background-color: #FFFFFF;" 
            class="style94">
        <tr>
            <td class="style35" valign="top" style="border: 1px solid #C0C0C0">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style57" valign="top" style="border: 1px solid #C0C0C0">
                <table class="style93">
                    <tr>
                        <td class="style37" valign="top">
                            <table class="style92">
                                <tr>
                                    <td class="style77" valign="top">
                        <table><tr><td class="style50">
                            
                            </td></tr></table>
                            
                                        <table style="margin-bottom: 0px;" class="style96">
                                            <tr>
                                                <td class="style89" 
                                                    style="background-image: url('images/sidemenusheading.gif'); background-repeat: no-repeat">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; My Profile&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                 </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UserDetails.aspx">BACK</asp:HyperLink>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                            
                                        <br />
                            
                                    </td>
                                    <td class="auto-style1" valign="top">
                                        <table class="style95">
                                         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"  
                    CellPadding="4" EnableModelValidation="True" Height="189px" 
                    Width="501px" >
                         <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                         <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                         <PagerSettings Mode="NextPreviousFirstLast" />
                         <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                         <RowStyle BackColor="White" ForeColor="#330099" />
                         <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                     </asp:GridView>
                                           
                                             
                                            </table>
                                    </td>
                                    <td class="style79" valign="top">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style77" valign="top">
                                        &nbsp;</td>
                                    <td class="auto-style1" valign="top">
                                        &nbsp;</td>
                                    <td class="style79" valign="top">
                                        &nbsp;</td>
                                </tr>
                                </table>
                            
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
