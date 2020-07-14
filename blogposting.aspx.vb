Imports admin.adminClass
Imports System.Data

Partial Class blogPosting
    Inherits System.Web.UI.Page

    Dim objX As New admin.adminClass
    Dim qry As String = ""
    Dim dTbl As New DataTable
    Dim frCnt As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserName") = "" Then
                Response.Redirect("Default.aspx", False)
            Else
                lblName.Text = Session("username")
                fillBlog()
            End If
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub btnopenfriends_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnopenfriends.Click
        Try
            Response.Redirect("UserDetails.aspx", True)
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub BT_Send_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT_Send.Click
        Try
            If txtBlog.Text.Trim = "" Then
                lblmessage.Text = "Blog posting not found..."
            Else




                If txtBlog.Text.Trim <> "" Then

                    classifyWords()
                    qry = "select * from tblBlogAnalysis where class = 'Vulgar' or class = 'Violence'  or class = 'Sex' or class = 'Offensive' "
                    dTbl = objX.getDataTable(qry)

                    If dTbl.Rows.Count > 0 Then
                        Dim msg As MsgBoxResult = MsgBoxResult.No
                        msg = MsgBox("Unwanted Words Found in your Blog... Blog want to Posted?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Post")
                        If msg = MsgBoxResult.Yes Then
                            Dim maxId As Integer = 0
                            maxId = objX.getMaxID("tblUsrBlog", "blgId")
                            maxId += 1
                            qry = "Insert into tblUsrBlog values (" & maxId & " , '" & Session("username") & "' ,'" & objX.FormatText(txtBlog.Text.Trim) & "' ,getdate())"
                            objX.exeQuery(qry)
                            lblmessage.Text = "Blog posted..."
                            txtBlog.Text = ""
                            fillBlog()

                        End If
                    Else
                        Dim maxId As Integer = 0
                        maxId = objX.getMaxID("tblUsrBlog", "blgId")
                        maxId += 1
                        qry = "Insert into tblUsrBlog values (" & maxId & " , '" & Session("username") & "' ,'" & objX.FormatText(txtBlog.Text.Trim) & "' ,getdate())"
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

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            txtBlog.Text = ""
            lblmessage.Text = ""

        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub

    Sub fillBlog()
        Try
            qry = ""

            qry = "select * from tblUsrBlog where usrName = '" & Session("UserName").ToString.Trim & "'  order by postingdate desc"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                GridView2.DataSource = dTbl
                GridView2.DataBind()
            End If

        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        Try
            GridView2.PageIndex = e.NewPageIndex
            fillBlog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    Sub classifyWords()
        Try
            Dim words() As String
            Dim word As String = ""


            words = txtBlog.Text.Trim.Split(" ")


            For Each word In words
                qry = ""
                dTbl = New DataTable

                qry = "select * from dbo.tblClassTerms where engword = '" & word & "'"
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

            qry = "select word , class , count(*) as TermFreq from tblBlogAnalysis group by class , word order by count(*) desc"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                GridView2.DataSource = dTbl
                GridView2.DataBind()
            Else
                GridView2.DataSource = Nothing
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            '      MsgBox(totRecUpd & " short Words Updated")

        End Try
    End Sub

End Class
