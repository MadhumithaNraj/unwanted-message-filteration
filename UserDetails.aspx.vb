Imports admin.adminClass
Imports System.Data
Imports System.IO
Imports System.Collections.Generic


Partial Class UserDetails
    Inherits System.Web.UI.Page
    Dim objX As New admin.adminClass
    Dim qry As String = ""
    Dim dTbl As New Datatable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserName") = "" Then
                Response.Redirect("Default.aspx", False)
            Else
                lblaboutme.Text = ""
                lblaboutme.Text = "User Name : " & Session("UserName")
                fillImages()
                qry = ""
                qry = "Select * from tblUserRegistration where regname = '" & Session("UserName").ToString.Trim & "'"
                dTbl = objX.getDataTable(qry)

                If dTbl.Rows.Count > 0 Then
                    lblmessage.Text = "Valid User !"
                    lblName.Text = dTbl.Rows(0).Item(3).ToString.Trim
                    lblEMail.Text = dTbl.Rows(0).Item(4).ToString.Trim
                    lblCountry.Text = dTbl.Rows(0).Item(5).ToString.Trim
                    lblCityName.Text = dTbl.Rows(0).Item(6).ToString.Trim
                    ' lblSecQuest.Text = dTbl.Rows(0).Item(7).ToString.Trim
                    ' lblSecQuestAns.Text = dTbl.Rows(0).Item(8).ToString.Trim
                Else
                    lblmessage.Text = "Invalid User !!"
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btnopenblog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnopenblog.Click
        Try
            Response.Redirect("blogposting.aspx", True)
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Try
            Session("username") = ""
            Response.Redirect("Default.aspx", True)
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub btnMyProf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMyProf.Click
        Try
            Response.Redirect("frmMyProfile.aspx", True)
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub btnmyFrnd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmyFrnd.Click
        Try
            Response.Redirect("myFriends.aspx", False)
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub btnmyFrndBlog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnmyFrndBlog.Click
        Try
            Response.Redirect("MyFrndsBlogs.aspx", False)
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try


            Dim filename2 As String = ""
            filename2 = Server.MapPath("~/images/" & Session("UserName"))
            If System.IO.Directory.Exists(filename2) Then
                System.IO.Directory.Delete(filename2, True)
            End If
            Threading.Thread.Sleep(2000)
            System.IO.Directory.CreateDirectory(filename2)
            Threading.Thread.Sleep(2000)
            fileuploadimages.SaveAs(filename2 & "\" & fileuploadimages.PostedFile.FileName)
            Threading.Thread.Sleep(2000)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('Image Updated');", True)
            fillImages()
         

        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub


    Sub fillImages()
        Try
            Dim filename2 As String = ""
            filename2 = Server.MapPath("~/images/" & Session("UsrName"))
            Dim filePaths As String() = Directory.GetFiles(filename2)
            Dim files As New List(Of ListItem)()
            For Each filePath As String In filePaths
                Dim fileName As String = Path.GetFileName(filePath)
                files.Add(New ListItem(fileName, "~/Images/" + Session("UsrName") + "/" + fileName))
            Next
            GridView1.DataSource = files
            GridView1.DataBind()

        Catch ex As Exception

        End Try
    End Sub
   
     
End Class
