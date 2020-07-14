<%@ Page Language="VB" AutoEventWireup="false" CodeFile="myFriends.aspx.vb" Inherits="myFriends" %>

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
              height: 312px;
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
                                                            <td class="style97" ><asp:Label ID="Label1" runat="server" Text="Users" Font-Bold="True" 
                                                                    Font-Size="Large"></asp:Label></td>
                                                            <td><asp:ListBox ID="lstUser" runat="server" Width="378px" 
                                                                    style="margin-left: 98px"></asp:ListBox></td>
                                                        </tr>
                                                       
                                                        <tr>
                                                        <td class="style97"  > </td>
                                                        <td >
                                                        <asp:Button id="btnRequest" runat="server" Text="Send Request" Width="124px" 
                                                                CssClass="button1"  BackColor="#006699" Font-Names="Bell MT" Font-Size="Large" 
                                                                ForeColor="White"></asp:Button>
						
                                                                                &nbsp;&nbsp;&nbsp;<asp:Button id="btnCancelRequest" runat="server" 
                                                                Text="Cancel Request" Width="135px" 
                                                                CssClass="button1"  BackColor="#006699" Font-Names="Bell MT" Font-Size="Large" 
                                                                ForeColor="White"></asp:Button>
						
                                                                                &nbsp;&nbsp;&nbsp;<asp:Button id="btnConfirmRequest" runat="server" 
                                                                Text="Confirm Request" Width="135px" 
                                                                CssClass="button1"  BackColor="#006699" Font-Names="Bell MT" Font-Size="Large" 
                                                                ForeColor="White"></asp:Button>
						
                                                                                </td>
                                                        </tr>

<tr >
                                                            <td class="style97" >
                                                                <asp:Label ID="Label2" runat="server" Text="Friend Request ( From )" Font-Bold="True" 
                                                                    Font-Size="Large"></asp:Label></td>
                                                            <td><asp:ListBox ID="lstFrndReq" runat="server" Width="382px" 
                                                                    style="margin-left: 98px"></asp:ListBox></td>
                                                        </tr>

<tr >
                                                            <td class="style97" >
                                                                <asp:Label ID="Label3" runat="server" Text="I m Friend for" Font-Bold="True" 
                                                                    Font-Size="Large"></asp:Label></td>
                                                            <td><asp:ListBox ID="lstFrnds" runat="server" Width="377px" 
                                                                    style="margin-left: 98px"></asp:ListBox></td>
                                                        </tr>
                                                        <tr>
                                                        <td colspan = "2">
                                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                        <td colspan = "2">
                                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                        <td colspan = "2">
                                                                                <asp:Label ID="lblmessage" runat="server" ForeColor="#CC3300"></asp:Label>
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
