<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserRegistration.aspx.vb" Inherits="UserRegistration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Online Social Network</title>
    <style type="text/css">

        .style19
        {
            width: 597px;
            height: 374px;
        }
        .style46
        {
            height: 24px;
            width: 125px;
        }
        .style47
        {
            width: 482px;
            height: 24px;
        }
        .style44
        {
            width: 125px;
            height: 11px;
        }
        .style45
        {
            width: 482px;
            height: 101px;
        }
        .style29
        {
            width: 125px;
            height: 4px;
        }
        .style33
        {
            width: 482px;
            height: 4px;
        }
        .style42
        {
            width: 125px;
            height: 5px;
        }
        .style43
        {
            width: 482px;
            height: 5px;
        }
        .style40
        {
            width: 125px;
            height: 14px;
        }
        .style41
        {
            width: 482px;
            height: 14px;
        }
        .style38
        {
            width: 125px;
            height: 9px;
        }
        .style39
        {
            width: 482px;
            height: 9px;
        }
        .style36
        {
            width: 125px;
            height: 18px;
        }
        .style37
        {
            width: 482px;
            height: 18px;
        }
        .style31
        {
            width: 125px;
            height: 25px;
        }
        .style34
        {
            width: 482px;
            height: 25px;
        }
        .style30
        {
            width: 125px;
        }
        .style32
        {
            width: 482px;
        }
        .style49
    {
        width: 349px;
    }
        .style50
        {
            height: 15px;
            width: 327px;
        }
        .style51
        {
            font-weight: bold;
            font-size: large;
        }
        .style52
        {
            height: 24px;
            text-align: left;
        }
        .style53
        {
            width: 327px;
        }
        </style>
</head>

<body style="background-image: url('images/body-bg.jpg');">

    <form id="form1" runat="server">
    <br /><br /><br /><br />
    <div style="width:960px; height: 100%; background-color:#FFF; margin: 0 auto; margin-top: 10px; margin-bottom: 80px;">
       <table style="width:100%; height: 407px; background-color: #FFFFFF;">
        <tr>
            <td class="style49" rowspan="3">
                <table class="style19" 
                    style="border: 1px solid #000000; margin-left: 0px;">
                    <tr>
                        <td class="style52"  colspan="2">
                           
                            <span class="style51"</span>
                                &nbsp;Join Now - it&#39;s easy and free!</span><br />
                            if you Already Registered Sign In
                            <asp:HyperLink ID="hyprlogin" runat="server" NavigateUrl="~/Default.aspx">Here!</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td class="style46" >
                            Username</td>
                        <td class="style47">
                            <asp:TextBox ID="txtUsernamereg" runat="server" 
                                Width="139px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtUsernamereg" ErrorMessage="UserName Reqired"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style44" >
                            Password</td>
                        <td class="style45">
                            <asp:TextBox ID="txtpasswordreg" runat="server" TextMode="Password" 
                                Width="139px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtpasswordreg" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style29"  valign="top">
                            Confirm Password</td>
                        <td class="style33" valign="top">
                            <asp:TextBox ID="txtcpwdreg" runat="server" TextMode="Password" Width="139px"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="txtpasswordreg" ControlToValidate="txtcpwdreg" 
                                ErrorMessage="Password Not Match"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style42" >
                            Name</td>
                        <td class="style43">
                            <asp:TextBox ID="txtname" runat="server" Width="139px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txtname" ErrorMessage="Enter Full Name"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style40" >
                            Email</td>
                        <td class="style41">
                            <asp:TextBox ID="txtEmailid" runat="server" Width="139px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                ControlToValidate="txtEmailid" ErrorMessage="Enter EMail Id"></asp:RequiredFieldValidator>
                            <span lang="en-us">&nbsp;</span><asp:RegularExpressionValidator 
                                ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailid" 
                                ErrorMessage="Invalid Format" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style38" >
                            Country</td>
                        <td class="style39">
                            <asp:DropDownList ID="ddlCountry" runat="server" Height="26px" Width="142px">
                                <asp:ListItem>india</asp:ListItem>
                                <asp:ListItem>australia</asp:ListItem>
                                <asp:ListItem>england</asp:ListItem>
                                <asp:ListItem>pakistan</asp:ListItem>
                                <asp:ListItem>africa</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style38" >
                            City</td>
                        <td class="style39">
                            <asp:TextBox ID="txtCityName" runat="server" Width="139px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                ControlToValidate="txtCityName" ErrorMessage="Enter City Name"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style36" >
                            SecurityQuestion</td>
                        <td class="style37" valign="top">
                            <asp:DropDownList ID="ddlSecurityques" runat="server" Height="21px" 
                                Width="246px">
                                <asp:ListItem>What Is your Name?</asp:ListItem>
                                <asp:ListItem>What Is pet Name?</asp:ListItem>
                                <asp:ListItem>What Is Favorite Colour?</asp:ListItem>
                                <asp:ListItem>Which is your Native?</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style31" >
                            Ans:</td>
                        <td class="style34">
                            <asp:TextBox ID="txtSecurityans" runat="server" Width="139px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                ControlToValidate="txtSecurityans" ErrorMessage="Ans Your Security"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                           <tr>
                        <td class="style31" >
                            Captcha Image</td>
                        <td class="style34">
                            <asp:TextBox runat="server" ID="txtcaptcha" Width="200px"/>
                            <img style="WIDTH: 119px; HEIGHT: 34px" alt="" src="Captcha.aspx" />
                            <a href="UserRegistration.aspx" id="uu">Can't Read?</a>
                        </td>
                    </tr>

                    <tr>
                        <td class="style30">
                            &nbsp;</td>
                        <td class="style32">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="83px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style30">
                            &nbsp;</td>
                        <td class="style32">
                            <asp:Label ID="LblRegistration" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="style50" valign="top" 
                style="border-style: none; border-color: #000000;">
                <span class="Apple-style-span" 
                    style="border-collapse: separate; color: rgb(0, 0, 0); font-family: 'Times New Roman'; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; font-size: medium; ">
                <span class="Apple-style-span" 
                    style="font-family: Arial, Helvetica, sans-serif; font-size: 12px; ">
                <asp:Image ID="Image1" runat="server" Height="396px" 
                    ImageUrl="~/otherimage/message-board.jpg" Width="431px" />
                </span>
                </span></td>
        </tr>
        <tr>
            <td valign="top" class="style53">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style53">
                &nbsp;</td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
