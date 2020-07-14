<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserDetails.aspx.vb" Inherits="UserDetails" %>

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
            width: 117px;
        }
        .style76
        {
            width: 85px;
            font-weight: bold;
        }
        .style77
        {
            width: 44px;
            font-weight: 700;
            height: 341px;
        }
        .style78
        {
            width: 469px;
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
              width: 142%;
              height: 367px;
          }
          .style93
          {
              width: 290%;
              height: 334px;
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
              width: 117px;
              font-weight: bold;
          }
          .Gridview
          {}
    </style>
    <script type="text/javascript" src="Stylesheets/jquery-1.8.2.js"></script>

    <script type="text/javascript">
        function showimagepreview(input) {
            if (input.files && input.files[0]) {
                var filerdr = new FileReader();
                filerdr.onload = function (e) {
                    $('#imgprvw').attr('src', e.target.result);
                }
                filerdr.readAsDataURL(input.files[0]);
            }
        }
        

</script>
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
                                                    <asp:LinkButton ID="btnopenblog" runat="server" onclick="btnopenblog_Click" 
                                                        CssClass="style90">My blog</asp:LinkButton>
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
                                                    <asp:LinkButton ID="btnMyProf" runat="server" CssClass="style90">My Profile</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnmyFrnd" runat="server" CssClass="style90">My Friends</asp:LinkButton>
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
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnmyFrndBlog" runat="server" CssClass="style90">My Friend&#39;s Blog</asp:LinkButton>
                                                        </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnMyProf0" runat="server" CssClass="style90" PostBackUrl="~/frmFrndsProf.aspx">My Friend&#39;s Profile</asp:LinkButton>
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
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnLogout" runat="server" 
                                                        CssClass="style90">Logout</asp:LinkButton>
                                                        </td>
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
                                                                <strong>&nbsp;&nbsp; ABOUT ME
                                                                </strong></td>
                                                        </tr>
                                                        <tr >
                                                            <td  class="style76" colspan="3">
                                                                <asp:Label ID="lblaboutme" runat="server"></asp:Label>
                                                                <hr />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style97">
                                                                <span lang="en-us">Name </span>:</td>
                                                            <td>
                                                                <asp:Label ID="lblName" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="style88">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td  class="style97">
                                                                <span lang="en-us">E~Mail </span>:</td>
                                                            <td>
                                                                <asp:Label ID="lblEMail" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="style88">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td  class="style97">
                                                                <span lang="en-us">Country Name</span> :</td>
                                                            <td>
                                                                <asp:Label ID="lblCountry" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="style88">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td  class="style97">
                                                                <span lang="en-us">City Name</span> :</td>
                                                            <td>
                                                                <asp:Label ID="lblCityName" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="style88">
                                                                &nbsp;</td>
                                                        </tr>

<%--                                                        <tr>
                                                            <td  class="style97">
                                                                <span lang="en-us">Security Question</span> :</td>
                                                            <td>
                                                                <asp:Label ID="lblSecQuest" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="style88">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td  class="style97">
                                                                <span lang="en-us">Answer :</span> :</td>
                                                            <td>
                                                                <asp:Label ID="lblSecQuestAns" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="style88">
                                                                &nbsp;</td>
                                                        </tr>--%>

                                                        <tr>
                                                            <td class="style75">
                                                                &nbsp;</td>
                                                            <td>
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
                                                    </table>
                                                    </td>
                                            </tr>
                                            </table>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Image"></asp:Label> <br /><br />
                                    <asp:FileUpload ID="fileuploadimages" runat="server" 
                                            onchange="showimagepreview(this)" Width="300px"  />
                                        <br />
                                    <img id="imgprvw" alt="" runat="server" height="300" width="300" border="2"   />
                                    <br />
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit"  />
                                        <br />
                                                                                
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="false" Height="170px" Width="385px">
    <Columns>        
        <asp:ImageField DataImageUrlField="Value" ControlStyle-Height="250" ControlStyle-Width="250" />
    </Columns>
</asp:GridView>

                                     
                                    </td>
                                    <br /><br />
                                    
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
