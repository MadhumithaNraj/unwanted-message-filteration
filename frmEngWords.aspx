<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmEngWords.aspx.vb" Inherits="frmEngWords" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Online Social Network</title>
        
        <style type="text/css">
        .style1
        {
            height: 254px;
        }
            .style3
            {
            }
            </style>
    
</head>

<body style="background-image: url('images/body-bg.jpg');">

 
    <form id="form1" runat="server">
    <!-- start page -->
    
<div style="width:960px; height: 960px; background-color:#FFF; margin: 0 auto; margin-top: 10px; margin-bottom: 80px; text-align:center">
    <table style="width:100%;" bgcolor="#99CCFF" border="2" frame="box" >
        <tr>
            <td class="style1" colspan="4" 
                
                style="background-image: url('otherimage/networking-banner.jpg'); background-repeat: no-repeat;">
            </td>
        </tr>
     </table>
     <br /> <br /> <br />
     <table style="width:85%; height: 99px;" bgcolor="#6666FF" border="2" frame="box" 
        align="center" >

        
            
       
 
     
        
<tr>
 <td class="style3" colspan="4">
                &nbsp;<br />
                <asp:Button ID="btnUpload" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="Upload" Width="196px" /><br />
                <asp:ImageButton ID="ibBack" runat="server" Height="50px" 
                    ImageUrl="~/images/backbutton.png" Width="100px" onclick="ibBack_Click" 
                     /> </td>
</tr>            
       
        <tr>
            <td class="style3" colspan="4">
                &nbsp;
                &nbsp;
                &nbsp;
                &nbsp;
                &nbsp;
                &nbsp;
                &nbsp;
            </td>
        </tr>
     
        
        <br />    
       
    </table>

       <br />

       <center>
       <table style="width:85%; height: 464px;" bgcolor="#6666FF" border="2" frame="box" 
               align="center" >
        <tr>
            <td class="style3" colspan="4">
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
            </td>
        </tr> 
    </table>
    </center>
</div>
<!-- end page -->
    </form>
</body>
</html>