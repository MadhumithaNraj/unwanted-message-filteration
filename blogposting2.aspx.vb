Imports System.Net.Mail

Partial Class blogposting2
    Inherits System.Web.UI.Page

    Dim objX As New admin.adminClass
    Dim qry As String = ""
    Dim dTbl As New DataTable
    Dim frCnt As Integer = 0


    Protected Sub btnopenfriends_Click(sender As Object, e As EventArgs) Handles btnopenfriends.Click
        Try
            Response.Redirect("UserDetails.aspx", False)
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserName") = "" Then
                Response.Redirect("Default.aspx", False)
            Else
                If IsPostBack = False Then
                    lblName.Text = Session("username")

                    If Session("username").ToString.Trim <> "" Then
                        qry = "select FrndName from tblFrndReq where Usrname = '" & Session("username").ToString.Trim & "'  and FrndReqStatus = 'Friend'"
                        dTbl = objX.getDataTable(qry)

                        If dTbl.Rows.Count > 0 Then
                            With ddlFrnd
                                .DataSource = dTbl
                                .DataMember = "FrndName"
                                .DataValueField = "FrndName"
                                .DataBind()
                            End With



                        Else

                        End If
                    End If
                End If


            End If
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        Finally
            fillBlog()
        End Try
    End Sub


    Protected Sub BT_Send_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_Send.Click
        Try
            If txtBlog.Text.Trim = "" Then
                lblmessage.Text = "Blog posting not found..."
            Else




                If txtBlog.Text.Trim <> "" Then

                    classifyWords()
                    qry = "select * from tblBlogAnalysis where class = 'Vulgar' or class = 'Violence' or class = 'sex'"
                    dTbl = objX.getDataTable(qry)

                    If dTbl.Rows.Count > 0 Then
                        Dim msg As MsgBoxResult = MsgBoxResult.No
                        msg = MsgBox("Vulgar / Violence Words Found... Blog want to Posted?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Post")

                        qry = ""
                        dTbl = New DataTable

                        qry = "select usremail from tblUserRegistration where regname = '" & ddlFrnd.SelectedValue.ToString.Trim & "'"
                        dTbl = objX.getDataTable(qry)

                        If dTbl.Rows.Count > 0 Then



                            If msg = MsgBoxResult.Yes Then

                                Dim Mail As New MailMessage
                                Mail.Subject = "Unwanted Message from OSN"
                                Mail.To.Add(dTbl.Rows(0).Item(0).ToString.Trim)
                                Mail.From = New MailAddress("snrsonscas@gmail.com")
                                Mail.Body = "Unwanted Message from your Friend" & ControlChars.CrLf
                                Mail.Body &= "************************" & ControlChars.CrLf
                                Mail.Body &= "From : " & Session("username") & ControlChars.CrLf
                                Mail.Body &= "To : " & ddlFrnd.SelectedValue.ToString.Trim & ControlChars.CrLf
                                Mail.Body &= "Time : " & Date.Now & ControlChars.CrLf
                                Mail.Body &= "Message : " & txtBlog.Text.Trim & ControlChars.CrLf
                                Mail.Body &= "************************" & ControlChars.CrLf



                                Dim SMTP As New SmtpClient("smtp.gmail.com")
                                SMTP.EnableSsl = True
                                SMTP.Credentials = New System.Net.NetworkCredential("snrsonscas@gmail.com", "mahe1990")
                                SMTP.Port = 587

                                SMTP.Send(Mail)

                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('Unwanted Message Details Sent to your friend!!');", True)


                                lblmessage.Text = "Mail Sent..."

                            End If

                        End If
                    Else
                        Dim maxId As Integer = 0
                        maxId = objX.getMaxID("tblUsrBlog2", "blgId")
                        maxId += 1
                        qry = "Insert into tblUsrBlog2 values (" & maxId & " , '" & Session("username") & "' , '" & ddlFrnd.SelectedValue.ToString.Trim & "' ,'" & objX.FormatText(txtBlog.Text.Trim) & "' ,getdate())"
                        objX.exeQuery(qry)
                        lblmessage.Text = "Blog posted..."
                        txtBlog.Text = ""

                        fillBlog()


                    End If


                Else
                    MsgBox("Blog not found")
                End If




            End If
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub

    Sub classifyWords()
        Try
            Dim words() As String
            Dim word As String = ""

            objX.exeQuery("truncate table tblBlogAnalysis")

            words = txtBlog.Text.Trim.Split(" ")


            For Each word In words
                qry = ""
                dTbl = New DataTable

                qry = "select * from dbo.tblClassTerms where engword = '" & word.Trim & "'"
                dTbl = objX.getDataTable(qry)

                If dTbl.Rows.Count > 0 Then
                    For Me.frCnt = 0 To dTbl.Rows.Count - 1
                        qry = "Insert into tblBlogAnalysis values ('" & objX.FormatText(dTbl.Rows(Me.frCnt)(1).ToString.Trim) & "' , '" & objX.FormatText(dTbl.Rows(Me.frCnt)(0).ToString.Trim) & "')"
                        objX.exeQuery(qry)
                    Next
                End If



            Next

            removeStpWord()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub removeStpWord()
        Try
            qry = "delete from tblBlogAnalysis where word in (select stpWord from tblStopWords)"
            objX.exeQuery(qry)


            ' Remove Special character
            dTbl = New DataTable
            qry = ""

            qry = "select * from  dbo.tblSplChar"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    qry = "update tblBlogAnalysis set word = Replace(word, '" & (dTbl.Rows(Me.frCnt).Item(0).ToString.Trim) & "', '')"
                    objX.exeQuery(qry)
                Next
            End If



            updateShortText()


            'MsgBox("Stop Words Removed")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub updateShortText()
        Dim totRecUpd As Integer = 0
        Try
            qry = ""
            dTbl = New DataTable
            Dim dTbl2 As New DataTable


            qry = "select distinct(splitword) from tblStpWrdRmv where splitword in (select shorttext from tblShortText)"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    qry = ""
                    qry = "select top 1 fullword from tblShortText where shorttext = '" & dTbl.Rows(Me.frCnt).Item(0).ToString.Trim & "'"
                    dTbl2 = New DataTable
                    dTbl2 = objX.getDataTable(qry)
                    If dTbl2.Rows.Count > 0 Then
                        If dTbl2.Rows(0).Item(0).ToString.Trim <> "" Then
                            qry = ""
                            qry = "update tblStpWrdRmv set splitword = '" & dTbl2.Rows(0).Item(0).ToString.Trim & "' where splitword = '" & dTbl.Rows(Me.frCnt).Item(0).ToString.Trim & "'"
                            objX.exeQuery(qry)

                            totRecUpd += admin.adminClass.rows

                        End If
                    End If
                Next
            End If
            objX.exeQuery("delete from tblStpWrdRmv where splitword = ''")



        Catch ex As Exception
            MsgBox(ex.Message)


        End Try
    End Sub


    Sub fillBlog()
        Try
            qry = ""
            dTbl = New DataTable

            qry = "select * from tblUsrBlog2 where usrname = '" & Session("username") & "'  or frndname = '" & Session("username") & "'"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                GridView2.DataSource = dTbl
                GridView2.DataBind()
            Else
                GridView2.DataSource = Nothing
            End If
        Catch ex As Exception
            lblmessage.Text = ex.Message
        End Try
    End Sub
End Class
