<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmClassTerms.aspx.vb" Inherits="frmClassTerms" %>

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
            #form1
            {
                height: 1277px;
                width: 1236px;
            }
            </style>
    
</head>

<body style="background-image: url('images/body-bg.jpg');">

 
    <form id="form1" runat="server">
    <!-- start page -->
    
<div style="width:960px; height: 1245px; background-color:#FFF; margin-top: 10px; margin-bottom: 80px; text-align:center; margin-left: auto; margin-right: auto;">
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
 <td  colspan="4">
                &nbsp;<br />
                <asp:ImageButton ID="ibBack" runat="server" Height="50px" 
                    ImageUrl="~/images/backbutton.png" Width="100px" onclick="ibBack_Click"/> </td>
</tr>            
    				<tr>
					<td height="1" >
					 <asp:Label ID="Label1" runat="server" Text="Classes"></asp:Label>
					</TD>
					<TD height="1"  > 
					    
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="200">
                        </asp:DropDownList>
					</TD>
				</TR>
				<tr> <td><asp:Label ID="Label2" runat="server" Text="Words"></asp:Label>
					</TD>
				<td >
                  <asp:DropDownList ID="DropDownList2" runat="server" Width="200" 
                        AutoPostBack="True">
                        </asp:DropDownList>   
				
				</td>
				</tr>
				<tr> <td><asp:Label ID="Label3" runat="server" Text="Bad Words"></asp:Label>
					</TD>
				<td >
                  <asp:DropDownList ID="DropDownList3" runat="server" Width="200" 
                        AutoPostBack="True">
                        </asp:DropDownList>   
				
				</td>
				</tr>
				
				<tr> <td><asp:Label ID="Label4" runat="server" Text="Selected Word"></asp:Label>
					</TD>
				<td class="style16">
                  <asp:Label ID="lblSelWord" runat="server" Text=""></asp:Label>  
				
				</td>
				</tr>
				<tr> 
				<td >
					        &nbsp;</td>
				<td>
				   <asp:Button ID="Button1" runat="server" Text="Save"  Width="168px" 
                                Height="38px" style="margin-top: 25px" Font-Bold="True" 
                        Font-Size="Large" />
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
                    Width="501px" >
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