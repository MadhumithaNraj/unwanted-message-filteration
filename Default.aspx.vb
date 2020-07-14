Imports admin.adminClass
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim objX As New admin.adminClass
    Dim qry As String = ""
    Dim dTbl As New DataTable

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLogin.Click
        Try
            If txtUsername.Text.Trim = "" Then
                lblmessage.Text = "User Name not found..."
            ElseIf txtPassword.Text.Trim = "" Then
                lblmessage.Text = "Password not found..."
            ElseIf txtUsername.Text.Trim = "admin" And txtPassword.Text.Trim = "admin" Then
                Session("UserName") = "admin"
                Response.Redirect("frmAdminHome.aspx", False)


            Else
                qry = "Select * from tblUserRegistration where usrname = '" & txtUsername.Text.Trim & "' and paswrd = '" & txtPassword.Text.Trim & "'"
                dTbl = objX.getDataTable(qry)

                If dTbl.Rows.Count > 0 Then
                    lblmessage.Text = "Valid User !"
                    Session("UsrName") = txtUsername.Text.Trim
                    Session("UserName") = dTbl.Rows(0).Item(3).ToString.Trim
                    Response.Redirect("UserDetails.aspx")
                Else
                    lblmessage.Text = "Invalid User !!"
                End If
            End If
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub
End Class
