<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

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
    <style type="text/css">
   
        .style25
        {
            height: 208px;
        }
        .style30
        {
            width: 494px;
            height: 253px;
        }
        .style31
        {
        }
        .style36
        {
            height: 28px;
        }
        .style38
        {
            width: 102px;
        }
        .style39
        {
            height: 14px;
            width: 102px;
            color: #000000;
        }
        .style41
        {
            height: 28px;
            width: 102px;
        }
        .style42
        {
            width: 235px;
        }
        .style44
        {
            color: #000000;
        }
        .style45
        {
            width: 474px;
        }
    .style46
    {
        width: 443px;
    }
        .style47
        {
            height: 14px;
        }
        .style48
        {
            height: 13px;
            width: 102px;
        }
        .style49
        {
            height: 13px;
        }
        .style50
        {
            width: 97%;
            height: 233px;
        }
        .style51
        {
            width: 98%;
            height: 353px;
        }
        .style52
        {
            width: 100%;
            height: 359px;
        }
        .style53
        {
            width: 235px;
            margin-left: 40px;
        }
    </style>

</head>

<body style="background-image: url('images/body-bg.jpg');">

 
    <form id="form1" runat="server">
    <!-- start page -->
    
<div style="width:960px; height: 960px; background-color:#FFF; margin: 0 auto; margin-top: 10px; margin-bottom: 80px;">
    <table style="width:100%;">
        <tr>
            <td class="style1" colspan="3" 
                
                style="background-image: url('otherimage/networking-banner.jpg'); background-repeat: no-repeat;">
            </td>
        </tr>
        <tr>
            <td colspan="3">
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
    </table>




    <table style="background-repeat: no-repeat; color: #000000;" class="style52">
    <tr>
        <td class="style45" valign="top" 
            style="background-repeat: no-repeat; background-image: url('otherimage/socialnetworkingloginimages.jpg')">
            <br />
        </td>
        <td valign="top">
            <table style="margin-left: 0px;" class="style51">
                <tr>
                    <td style="background-image: none; background-repeat: no-repeat;" 
                        valign="top" class="style46">
                        &nbsp;&nbsp;&nbsp;&nbsp;<table><tr>
                            <td class="style30" valign="top" style="color: #FFFFFF">
                            <table class="style50">
                                <tr>
                                    <td class="style38">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style31" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Login To Website&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style38">
                                        </td>
                                    <td>
                        <asp:Label ID="lblmessage" runat="server" ForeColor="#CC3300"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style39">
                                        &nbsp; Username</td>
                                    <td class="style47">
                        <asp:TextBox ID="txtUsername" runat="server" Width="222px" Height="26px" 
                            CssClass="form-login" BorderColor="Black" BackColor="#0099FF"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtUsername" ErrorMessage="Enter Username">*</asp:RequiredFieldValidator>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style48">
                                        &nbsp;<span class="style44">Password</span></td>
                                    <td class="style49">
                        <asp:TextBox ID="txtPassword" runat="server" Width="222px" Height="26px" 
                            CssClass="form-login" BorderColor="Black" TextMode="Password" BackColor="#0099FF"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtPassword" ErrorMessage="Enter Password">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style41">
                                        </td>
                                    <td class="style36">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style38">
                                        &nbsp;</td>
                                    <td valign="top">
                                        <table><tr><td class="style42">
                                        <asp:ImageButton ID="btnLogin" runat="server" Height="36px" 
                                            ImageUrl="~/otherimage/login-btn.png" onclick="btnLogin_Click" Width="123px" />
                                            </td></tr><tr><td class="style53">
                                                <asp:HyperLink ID="HyperLink6" runat="server" ForeColor="Red" 
                                                    NavigateUrl="~/UserRegistration.aspx">Sign Up</asp:HyperLink>
                                                </td></tr></table>
                                                <br />
                                    </td>
                                </tr>
                            </table>
                            </td></tr></table>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Find colleagues, classmates and develop your 
                        network
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Share &amp; communicate&nbsp;With friends and Classmates.<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Discover new&nbsp;people through friends of friends.<br />
                        <br />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    </table>
    
        <table style="width:100%; height: 184px; background-image: none;">
            <tr>
                <td class="style25" 
                    style="background-position: center; background-image: url('otherimage/footerimagesww3.jpg'); background-repeat: no-repeat;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            </table>

</div>
<!-- end page -->
    </form>
</body>
</html>
