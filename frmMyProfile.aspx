<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmMyProfile.aspx.vb" Inherits="frmMyProfile" %>

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

<body style="background-image: url('images/body-bg.jpg'); background-repeat: no-repeat;">

 
    <form id="form1" runat="server">
    <!-- start page -->
    
<div style="width:960px; height: auto; background-color:#FFF; margin: 0 auto; margin-top: 80px; margin-bottom: 80px;">
    <table style="width:100%;">
        <tr>
            <td class="style1" colspan="3" 
                
                style="background-image: url('otherimage/networking-banner.jpg'); background-repeat: no-repeat;">
            </td>
        </tr>
    
    </table>
 <center></center>           
            <table style="width:60%; height: 392px; font-family: 'Book Antiqua'; font-size: 15px;" 
        align="center" style=""
             >
            <tr>
            <td  colspan="2" class="style81" 
            style="background-image: url('images/headingbg417.jpg'); background-repeat: no-repeat;">
            <strong>&nbsp;&nbsp; My Personal Details </strong></td>
    </tr>
    <tr >
        <td  colspan="2">
            <hr />
        </td>
    </tr>
    <tr>
        <td >
            <span lang="en-us">Name </span>:</td>
        <td>
            <asp:Label ID="lblName" runat="server"></asp:Label>
        </td>
       
    </tr>
    <tr>
        <td  >
            <span lang="en-us">Favorite Books</span></td>
        <td>
            <asp:TextBox ID="txtBook" runat="server" Width="287px"></asp:TextBox>
        </td>
       
    </tr>
    <tr>
        <td  >
            <span lang="en-us">Favorite Movies</span></td>
        <td>
            <asp:TextBox ID="txtMovie" runat="server" Width="287px"></asp:TextBox>
        </td>
       
    </tr>
    <tr>
        <td >
            <span lang="en-us">Political Affiliation</span></td>
        <td>
            <asp:TextBox ID="txtPolitical" runat="server" Width="287px"></asp:TextBox>
        </td>
        
    </tr>
    <tr>
        <td  >
            <span lang="en-us">Religion</span></td>
        <td>
            <asp:TextBox ID="txtReligion" runat="server" Width="287px"></asp:TextBox>
        </td>
       
    </tr>
    <tr>
        <td >
            <span lang="en-us">Activities</span></td>
        <td>
            <asp:TextBox ID="txtActivities" runat="server" Width="287px"></asp:TextBox>
        </td>
       
    </tr>

        <tr>
        <td  >
            <span lang="en-us">Favorite Sports</span></td>
        <td>
            <asp:TextBox ID="txtSport" runat="server" Width="287px"></asp:TextBox>
        </td>
        
    </tr>

        <tr>
        <td  >
            <span lang="en-us">Favorite Songs</span></td>
        <td>
            <asp:TextBox ID="txtSongs" runat="server" Width="287px"></asp:TextBox>
        </td>
       
    </tr>

        <tr>
        <td  >
            <span lang="en-us">Favorite TV Shows</span></td>
        <td>
            <asp:TextBox ID="txtTVShows" runat="server" Width="287px"></asp:TextBox>
        </td>
       
    </tr>

        <tr>
        <td  >
            <span lang="en-us">Mobile Model</span></td>
        <td>
            <asp:TextBox ID="txtMobileModel" runat="server" Width="287px"></asp:TextBox>
        </td>
     
    </tr>

        <tr>
        <td  >
            <span lang="en-us">Mobile Network</span></td>
        <td>
            <asp:TextBox ID="txtMobileNetwork" runat="server" Width="287px"></asp:TextBox>
        </td>
       
    </tr>



    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Update" />
            <asp:Button ID="btnClear" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Clear" />
            <asp:Button ID="btnBack" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Back" />
        </td>
       
    </tr>


    <tr>
    <td colspan = "3">
                            <asp:Label ID="lblmessage" runat="server" ForeColor="#CC3300"></asp:Label>
    </td>
    </tr>
</table>


</div>


<!-- end page -->
    </form>
</body>
</html>
