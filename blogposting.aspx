<%@ Page Language="VB" AutoEventWireup="false" CodeFile="blogposting.aspx.vb" Inherits="blogposting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
        .style75
        {
            width: 105px;
        }
        .style76
        {
            width: 85px;
            font-weight: bold;
              height: 23px;
          }
        .style77
        {
            width: 44px;
            font-weight: 700;
            height: 341px;
        }
        .style78
        {
              width: 643px;
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
        .style88
        {
            width: 38px;
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
              height: 312px;
          }
          .style96
          {
              width: 228px;
              height: 139px;
          }
          .style97
          {
              width: 105px;
              font-weight: bold;
          }
          .style98
          {
              text-align: center;
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
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnopenfriends" runat="server" 
                                                        onclick="btnopenfriends_Click" CssClass="style90">Home</asp:LinkButton>
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
                                    <td class="style78" valign="top">
                                        <table class="style95">
                                         
                                           
                                            <tr>
                                                <td class="style83" valign="top">
                                                    <table style="width:100%;">
                                                        <tr>
                                                            <td  colspan="3" class="style81" 
                                                                style="background-image: url('images/headingbg417.jpg'); background-repeat: no-repeat;">
                                                                <strong>&nbsp;&nbsp; Welcome : </strong> <asp:Label ID="lblName" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr >
                                                            <td  class="style76" colspan="3">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                                                                                        <td class="style97">
                                                                                                                            <span lang="en-us">Blog </span>:</td>

                                                            <td>
                                                                
                                                                <asp:TextBox ID="txtBlog" runat="server" BackColor="#FFFFCC" Height="147px" 
                                                                    MaxLength="450" tabIndex="1" TextMode="MultiLine" Width="557px"></asp:TextBox>
                                                                
                                                            </td>
                                                            <td class="style88">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style75">
                                                                &nbsp;</td>
                                                            <td class="style98">
                                                            <asp:Button id="BT_Send" runat="server" Text="Post" Width="80px" 
                            CssClass="button1"  BackColor="#006699" 
                            Font-Names="Bell MT" Font-Size="Large" ForeColor="White"></asp:Button>
						<asp:Button id="btnClear" runat="server" Text="Clear" Width="80px" 
                            CssClass="button1"  BackColor="#006699" 
                            Font-Names="Bell MT" Font-Size="Large" ForeColor="White"></asp:Button>
                                                                &nbsp;</td>
                                                            <td class="style88">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                        <td colspan = "3">
                                                                                <asp:Label ID="lblmessage" runat="server" ForeColor="#CC3300"></asp:Label>
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                        <td colspan = "3">
                                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                        <td colspan = "3">
                                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                        <td colspan = "3">
                                                                                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                                                                    BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                                                                                    CellPadding="4" EnableModelValidation="True" Height="650px" PageSize="5" 
                                                                                    Width="754px">
                                                                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                                                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                                                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                                                                    <RowStyle BackColor="White" ForeColor="#330099" />
                                                                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                                                                </asp:GridView>
                                                        </td>
                                                        </tr>
                                                    </table>
                                                    </td>
                                            </tr>
                                            </table>
                                    </td>
                                    <td class="style79" valign="top">
                                        <asp:Image ID="Image1" runat="server" Height="266px" 
                                            ImageUrl="~/otherimage/message-board.jpg" Width="273px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style77" valign="top">
                                        &nbsp;</td>
                                    <td class="style78" valign="top">
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
