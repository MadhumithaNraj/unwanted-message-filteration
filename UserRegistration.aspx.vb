Imports System.Net.Mail
Imports admin.adminClass
Partial Class UserRegistration
    Inherits System.Web.UI.Page
    Dim objX As New admin.adminClass
    Dim qry As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try

            If Session("randomStr").ToString() = txtcaptcha.Text Then

                LblRegistration.Text = ""
                If txtUsernamereg.Text.Trim = "" Then
                    LblRegistration.Text = "Username not found..."
                ElseIf txtpasswordreg.Text.Trim = "" Then
                    LblRegistration.Text = "Password not found..."
                ElseIf txtcpwdreg.Text.Trim = "" Then
                    LblRegistration.Text = "Confirm Password not found..."
                ElseIf txtname.Text.Trim = "" Then
                    LblRegistration.Text = "Name not found..."
                ElseIf txtEmailid.Text.Trim = "" Then
                    LblRegistration.Text = "Email ID not found..."
                ElseIf txtCityName.Text.Trim = "" Then
                    LblRegistration.Text = "Cityname not found..."
                ElseIf txtSecurityans.Text.Trim = "" Then
                    LblRegistration.Text = "Security Answer not found..."
                ElseIf txtSecurityans.Text.Trim = "" Then
                    LblRegistration.Text = "Image Captcha not found..."
                Else
                    Dim maxId As Integer = 0
                    maxId = objX.getMaxID("tblUserRegistration", "Usrid")
                    maxId += 1
                    qry = "insert into tblUserRegistration values (" & maxId & ",'" & txtUsernamereg.Text.Trim & "' , '" & txtpasswordreg.Text.Trim & "' , '" & txtname.Text.Trim & "' , '" & txtEmailid.Text.Trim & "' , '" & ddlCountry.SelectedItem.ToString.Trim & "' , '" & txtCityName.Text.Trim & "' , '" & ddlSecurityques.SelectedItem.ToString.Trim & "' , '" & txtSecurityans.Text.Trim & "')"
                    objX.exeQuery(qry)

                    Dim pat As String = ""
                    pat = Server.MapPath("~/images/" & txtname.Text.Trim)

                    System.IO.Directory.CreateDirectory(pat)

                    If admin.adminClass.rows > 0 Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('User Registered. Login for further details...');", True)
                        sendMail()
                        txtClear()
                    End If

                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('Wrong text inserted ,Please enter new characters shown in image textbox...');", True)
            End If


        Catch ex As Exception
            LblRegistration.Text = ex.Message.ToString
        End Try
    End Sub

    Sub txtClear()
        Try
            txtUsernamereg.Text = ""
            txtpasswordreg.Text = ""
            txtcpwdreg.Text = ""
            txtname.Text = ""
            txtEmailid.Text = ""
            txtCityName.Text = ""
            txtSecurityans.Text = ""
            txtcaptcha.Text = ""
            txtUsernamereg.Focus()
        Catch ex As Exception
            LblRegistration.Text = ex.Message.ToString
        End Try
    End Sub


    Sub sendMail()
        Try
            LblRegistration.Text = ""

            Dim Mail As New MailMessage
            Mail.Subject = "User Registration from Online Social Network"
            Mail.To.Add(txtEMailId.Text.ToString.Trim)
            Mail.From = New MailAddress("snrsonscas@gmail.com")
            Mail.Body = "User Registration Details" & ControlChars.CrLf
            Mail.Body &= "************************" & ControlChars.CrLf
            Mail.Body &= "User Name : " & txtUsernamereg.Text & ControlChars.CrLf
            Mail.Body &= "Password :" & txtpasswordreg.Text & ControlChars.CrLf


            Dim SMTP As New SmtpClient("smtp.gmail.com")
            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("snrsonscas@gmail.com", "mahe1990")
            SMTP.Port = 587

            SMTP.Send(Mail)

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('User Details Sent to " & txtEmailid.Text.ToString.Trim & " sent successfully!');", True)


        Catch ex As Exception
            LblRegistration.Text = ex.Message.ToString
        End Try
    End Sub
End Class
