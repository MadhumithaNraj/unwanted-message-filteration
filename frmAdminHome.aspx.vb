
Partial Class frmAdminHome
    Inherits System.Web.UI.Page

    Dim objX As New admin.adminClass
    Dim qry As String
    Dim dTbl As New DataTable
    Dim frCnt As Integer = 0
    Shared oprMode As String = ""


    Protected Sub btnLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Try
            Session("UserName") = ""
            Response.Redirect("Default.aspx", False)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub


    Protected Sub GridView1_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex

            fillRecords()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub fillRecords()
        Try
            qry = ""

            oprMode = "btnApriori_Click"
            qry = "select * from tblBlgWrdCnt"




            If oprMode = "btnPreProcess_Click" Then
                qry = "select * from tblStpWrdRmv"

            ElseIf oprMode = "btnApriori_Click" Then
                qry = "select * from tblBlgWrdCnt"

            End If

            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                GridView1.DataSource = dTbl
                GridView1.DataBind()
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserName") = "admin" Then

            Else
                Response.Redirect("Default.aspx", False)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Protected Sub btnPreProcess_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreProcess.Click
        Try
            WordsSplit()
            removeStpWord()
            updateShortText()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Sub WordsSplit()
        Try

            qry = "select blgid , blog from tblUsrBlog"
            dTbl = objX.getDataTable(qry)

            Dim input As String = ""
            Dim bId As Integer = 0
            Dim words() As String
            Dim word As String = ""
            Dim wordNo As Integer = 0


            objX.exeQuery("Truncate table tblStpWrdRmv")

            If dTbl.Rows.Count > 0 Then
                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    wordNo = 0
                    input = dTbl.Rows(Me.frCnt)(1).ToString.Trim
                    bId = dTbl.Rows(Me.frCnt)(0).ToString.Trim
                    words = input.Split(" ")
                    For Each word In words
                        wordNo += 1
                        qry = "Insert into tblStpWrdRmv values (" & bId & " , " & wordNo & " , '" & objX.FormatText(word) & "')"
                        objX.exeQuery(qry)

                        'lblStatus.Text = "Updation : " & frCnt & " / " & dTbl.Rows.Count
                    Next
                Next

                MsgBox("Blog Words Seperated...")


                ' Remove Special character
                dTbl = New DataTable
                qry = ""

                qry = "select * from  dbo.tblSplChar"
                dTbl = objX.getDataTable(qry)

                If dTbl.Rows.Count > 0 Then
                    For Me.frCnt = 0 To dTbl.Rows.Count - 1
                        qry = "update tblStpWrdRmv set Splitword = Replace(Splitword, '" & (dTbl.Rows(Me.frCnt).Item(0).ToString.Trim) & "', '')"
                        objX.exeQuery(qry)
                    Next
                End If


                MsgBox("Special characters Removed...")

                'objX.exeQuery("drop table tblStpWrdRmv1")
                'objX.exeQuery("select * into  tblStpWrdRmv1 from  tblStpWrdRmv")
                'objX.exeQuery("update tblStpWrdRmv1 set word = 'x****x' where word in  (select badword from  dbo.tblBadWords)")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub removeStpWord()
        Try
            qry = "delete from tblStpWrdRmv where splitword in (select stpWord from tblStopWords)"
            objX.exeQuery(qry)




        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MsgBox(admin.adminClass.rows & " Stop Words Removed")
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
        Finally
            MsgBox(totRecUpd & " short Words Updated")

        End Try
    End Sub



    Sub classApriori3()
        Try
            Dim mst As Decimal = 0
            Dim mct As Decimal = 0
            Dim dTbl2 As New DataTable
            Dim frCnt2 As Integer = 0
            Dim cnt As Integer = 0
            objX.exeQuery("Truncate Table tblBlgWrdCnt")

            qry = "select distinct(blgid)  from tblStpWrdRmv order by blgid"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    qry = ""
                    qry = "select  SplitWord , count(*) as Countings from tblStpWrdRmv where blgid = " & CInt(dTbl.Rows(frCnt).Item(0).ToString.Trim) & " group by SplitWord"
                    dTbl2 = objX.getDataTable(qry)

                    If dTbl2.Rows.Count > 0 Then
                        For frCnt2 = 0 To dTbl2.Rows.Count - 1


                            qry = ""
                            qry = "Insert into tblBlgWrdCnt values (" & CInt(dTbl.Rows(frCnt).Item(0).ToString.Trim) & " , '" & dTbl2.Rows(frCnt2).Item(0).ToString.Trim & "' , " & CInt(dTbl2.Rows(frCnt2).Item(1).ToString.Trim) & " , " & CInt(dTbl2.Rows.Count) & " , " & CDec(CInt(dTbl2.Rows(frCnt2).Item(1).ToString.Trim) / CInt(dTbl2.Rows.Count)) & ",0)"
                            objX.exeQuery(qry)
                        Next
                    End If
                Next
            End If



            objX.exeQuery("drop Table tblBlgWrdCnt2")
            objX.exeQuery("select * into tblBlgWrdCnt2 from tblBlgWrdCnt where word in (select badword from tblBadWords) or word in (select  engword from tblClassTerms)")

            qry = "select distinct(blgid)  from tblBlgWrdCnt2  order by blgid"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then

                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    qry = ""
                    qry = "select word , count(*) from tblBlgWrdCnt2 where blgid =  " & dTbl.Rows(frCnt).Item(0).ToString.Trim & " group by word"
                    dTbl2 = objX.getDataTable(qry)
                    If dTbl2.Rows.Count > 0 Then
                        For frCnt2 = 0 To dTbl2.Rows.Count - 1
                            qry = ""
                            qry = "Update tblBlgWrdCnt2 set ConfVal = " & Math.Abs(CDec(1 / dTbl2.Rows.Count - 1)) & " where blgid = " & dTbl.Rows(frCnt).Item(0).ToString.Trim & " and word = '" & dTbl2.Rows(frCnt2).Item(0).ToString.Trim & "'"
                            objX.exeQuery(qry)
                        Next
                    End If
                Next
            End If

            qry = "Update tblBlgWrdCnt2 set ConfVal = 0.01  where ConfVal <= 0.00"
            objX.exeQuery(qry)


            objX.exeQuery("drop table tblRes")
            objX.exeQuery("select a.blgid , a.word , b.classname into tblRes from tblBlgWrdCnt2 a , tblClassTerms b where (supval >" & mst & " and confval >" & mct & ") and ( a.word = b.engword)")
            objX.exeQuery("drop table tblres1")
            objX.exeQuery("select blgid , word , classname , count(*) as countings into tblres1 from tblres group by blgid , word , classname order by  blgid , countings desc")

            qry = "select distinct(blgid) from tblres1 order by blgid"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    qry = ""
                    qry = "select * from tblres1 where blgid = " & CInt(dTbl.Rows(frCnt).Item(0).ToString.Trim)
                    dTbl2 = objX.getDataTable(qry)
                    If dTbl2.Rows.Count > 0 Then
                        For frCnt2 = 0 To dTbl2.Rows.Count - 1
                            If frCnt2 > 0 Then
                                qry = "delete from tblres1 where blgid = " & CInt(dTbl2.Rows(frCnt2).Item(0).ToString.Trim) & " and word = '" & dTbl2.Rows(frCnt2).Item(1).ToString.Trim & "'"
                                objX.exeQuery(qry)
                            End If

                        Next
                    End If
                Next
            End If



            objX.exeQuery("drop table tblRes5")
            objX.exeQuery("drop table tblRes6")
            objX.exeQuery("select classname , count(classname) as countings INTO tblRes5 from tblres3 group by classname")
            objX.exeQuery("select classname , count(classname) as countings INTO tblRes6 from tblres1 group by classname")
            objX.exeQuery("drop table tblRes7")
            objX.exeQuery("select a.className , a.countings as [AprioriRules] , b.countings as [NavieBayesRules] into tblRes7 from tblres6 a , tblres5 b where b.classname = a.classname")
            objX.exeQuery("select * from tblRes7")

            MsgBox("Completed")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnApriori_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApriori.Click
        Try
            classApriori()
        Catch ex As Exception

        End Try
    End Sub

    Sub classApriori()
        Try
            Dim mst As Decimal = 0
            Dim mct As Decimal = 0
            Dim dTbl2 As New DataTable
            Dim frCnt2 As Integer = 0
            Dim cnt As Integer = 0
            objX.exeQuery("Truncate Table tblBlgWrdCnt")

            qry = "select distinct(blgid)  from tblStpWrdRmv order by blgid"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    qry = ""
                    qry = "select  splitword , count(*) as Countings from tblStpWrdRmv where blgid = " & CInt(dTbl.Rows(Me.frCnt).Item(0).ToString.Trim) & " group by splitword"
                    dTbl2 = objX.getDataTable(qry)

                    If dTbl2.Rows.Count > 0 Then
                        For frCnt2 = 0 To dTbl2.Rows.Count - 1


                            qry = ""
                            qry = "Insert into tblBlgWrdCnt values (" & CInt(dTbl.Rows(Me.frCnt).Item(0).ToString.Trim) & " , '" & dTbl2.Rows(frCnt2).Item(0).ToString.Trim & "' , " & CInt(dTbl2.Rows(frCnt2).Item(1).ToString.Trim) & " , " & CInt(dTbl2.Rows.Count) & " , " & CDec(CInt(dTbl2.Rows(frCnt2).Item(1).ToString.Trim) / CInt(dTbl2.Rows.Count)) & ",0)"
                            objX.exeQuery(qry)
                        Next
                    End If
                Next
            End If



            objX.exeQuery("drop Table tblBlgWrdCnt2")
            objX.exeQuery("select * into tblBlgWrdCnt2 from tblBlgWrdCnt where word in (select badword from tblBadWords) or word in (select  engword from tblClassTerms)")

            qry = "select distinct(blgid)  from tblBlgWrdCnt2  order by blgid"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then

                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    qry = ""
                    qry = "select word , count(*) from tblBlgWrdCnt2 where blgid =  " & dTbl.Rows(Me.frCnt).Item(0).ToString.Trim & " group by word"
                    dTbl2 = objX.getDataTable(qry)
                    If dTbl2.Rows.Count > 0 Then
                        For frCnt2 = 0 To dTbl2.Rows.Count - 1
                            qry = ""
                            qry = "Update tblBlgWrdCnt2 set ConfVal = " & Math.Abs(CDec(1 / dTbl2.Rows.Count - 1)) & " where blgid = " & dTbl.Rows(Me.frCnt).Item(0).ToString.Trim & " and word = '" & dTbl2.Rows(frCnt2).Item(0).ToString.Trim & "'"
                            objX.exeQuery(qry)
                        Next
                    End If
                Next
            End If

            'qry = "Update tblBlgWrdCnt2 set ConfVal = 0.01  where ConfVal <= 0.00"
            'objX.exeQuery(qry)


            objX.exeQuery("drop table tblRes")
            objX.exeQuery("select a.blgid , a.word , b.classname into tblRes from tblBlgWrdCnt2 a , tblClassTerms b where (supval >" & mst & " and confval >" & mct & ") and ( a.word = b.engword)")
            objX.exeQuery("drop table tblres1")
            objX.exeQuery("select blgid , word , classname , count(*) as countings into tblres1 from tblres group by blgid , word , classname order by  blgid , countings desc")

            qry = "select distinct(blgid) from tblres1 order by blgid"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    qry = ""
                    qry = "select * from tblres1 where blgid = " & CInt(dTbl.Rows(Me.frCnt).Item(0).ToString.Trim)
                    dTbl2 = objX.getDataTable(qry)
                    If dTbl2.Rows.Count > 0 Then
                        For frCnt2 = 0 To dTbl2.Rows.Count - 1
                            If frCnt2 > 0 Then
                                qry = "delete from tblres1 where blgid = " & CInt(dTbl2.Rows(frCnt2).Item(0).ToString.Trim) & " and word = '" & dTbl2.Rows(frCnt2).Item(1).ToString.Trim & "'"
                                objX.exeQuery(qry)
                            End If

                        Next
                    End If
                Next
            End If

            objX.exeQuery("drop table tblRes5")
            objX.exeQuery("drop table tblRes6")
            objX.exeQuery("select classname , count(classname) as countings INTO tblRes5 from tblres3 group by classname")
            objX.exeQuery("select classname , count(classname) as countings INTO tblRes6 from tblres1 group by classname")
            objX.exeQuery("drop table tblRes7")
            objX.exeQuery("select a.className , a.countings as [AprioriRules] , b.countings as [NavieBayesRules] into tblRes7 from tblres6 a , tblres5 b where b.classname = a.classname")
            objX.exeQuery("select * from tblRes7")

            MsgBox("Apriori Classification Completed")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub classApriori2()
        Try
            Dim mst As Decimal = 0.0
            Dim mct As Decimal = 0.0
            Dim dTbl2 As New DataTable
            Dim frCnt2 As Integer = 0
            Dim cnt As Integer = 0
            objX.exeQuery("Truncate Table tblBlgWrdCnt")

            qry = "select distinct(blgid)  from tblStpWrdRmv order by blgid"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    qry = ""
                    qry = "select  splitword , count(*) as Countings from tblStpWrdRmv where blgid = " & CInt(dTbl.Rows(Me.frCnt).Item(0).ToString.Trim) & " group by splitword"
                    dTbl2 = objX.getDataTable(qry)

                    If dTbl2.Rows.Count > 0 Then
                        For frCnt2 = 0 To dTbl2.Rows.Count - 1


                            qry = ""
                            qry = "Insert into tblBlgWrdCnt values (" & CInt(dTbl.Rows(frCnt).Item(0).ToString.Trim) & " , '" & dTbl2.Rows(frCnt2).Item(0).ToString.Trim & "' , " & CInt(dTbl2.Rows(frCnt2).Item(1).ToString.Trim) & " , " & CInt(dTbl2.Rows.Count) & " , " & CDec(CInt(dTbl2.Rows(frCnt2).Item(1).ToString.Trim) / CInt(dTbl2.Rows.Count)) & ",0)"
                            objX.exeQuery(qry)
                        Next
                    End If
                Next
            End If



            objX.exeQuery("drop Table tblBlgWrdCnt2")
            objX.exeQuery("select * into tblBlgWrdCnt2 from tblBlgWrdCnt where word in (select badword from tblBadWords) or word in (select  engword from tblClassTerms)")

            qry = "select distinct(blgid)  from tblBlgWrdCnt2  order by blgid"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then

                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    qry = ""
                    qry = "select word , count(*) from tblBlgWrdCnt2 where blgid =  " & dTbl.Rows(frCnt).Item(0).ToString.Trim & " group by word"
                    dTbl2 = objX.getDataTable(qry)
                    If dTbl2.Rows.Count > 0 Then
                        For frCnt2 = 0 To dTbl2.Rows.Count - 1
                            qry = ""
                            qry = "Update tblBlgWrdCnt2 set ConfVal = " & Math.Abs(CDec(1 / dTbl2.Rows.Count - 1)) & " where blgid = " & dTbl.Rows(frCnt).Item(0).ToString.Trim & " and word = '" & dTbl2.Rows(frCnt2).Item(0).ToString.Trim & "'"
                            objX.exeQuery(qry)
                        Next
                    End If
                Next
            End If

            qry = "Update tblBlgWrdCnt2 set ConfVal = 0.01  where ConfVal <= 0.00"
            objX.exeQuery(qry)


            objX.exeQuery("drop table tblRes")
            objX.exeQuery("select a.blgid , a.word , b.classname into tblRes from tblBlgWrdCnt2 a , tblClassTerms b where (supval >" & mst & " and confval >" & mct & ") and ( a.word = b.engword)")
            objX.exeQuery("drop table tblres1")
            objX.exeQuery("select blgid , word , classname , count(*) as countings into tblres1 from tblres group by blgid , word , classname order by  blgid , countings desc")

            qry = "select distinct(blgid) from tblres1 order by blgid"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    qry = ""
                    qry = "select * from tblres1 where blgid = " & CInt(dTbl.Rows(frCnt).Item(0).ToString.Trim)
                    dTbl2 = objX.getDataTable(qry)
                    If dTbl2.Rows.Count > 0 Then
                        For frCnt2 = 0 To dTbl2.Rows.Count - 1
                            If frCnt2 > 0 Then
                                qry = "delete from tblres1 where blgid = " & CInt(dTbl2.Rows(frCnt2).Item(0).ToString.Trim) & " and word = '" & dTbl2.Rows(frCnt2).Item(1).ToString.Trim & "'"
                                objX.exeQuery(qry)
                            End If

                        Next
                    End If
                Next
            End If

            objX.exeQuery("drop table tblRes3")
            objX.exeQuery("select * into tblRes3 from tblRes1")
            objX.exeQuery("drop table tblRes5")
            objX.exeQuery("drop table tblRes6")
            objX.exeQuery("select classname , count(classname) as countings INTO tblRes5 from tblres3 group by classname")
            objX.exeQuery("select classname , count(classname) as countings INTO tblRes6 from tblres1 group by classname")
            objX.exeQuery("drop table tblRes7")
            objX.exeQuery("select a.className , a.countings as [AprioriRules] , b.countings as [NavieBayesRules] into tblRes7 from tblres6 a , tblres5 b where b.classname = a.classname")
            objX.exeQuery("select * from tblRes7")

            MsgBox("Completed")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnBlog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBlog.Click
        Try
            'objX.exeQuery("drop table tblRes5")
            'objX.exeQuery("drop table tblRes6")
            'objX.exeQuery("select classname , count(classname) as countings INTO tblRes5 from tblres3 group by classname")
            'objX.exeQuery("select classname , count(classname) as countings INTO tblRes6 from tblres1 group by classname ")
            'objX.exeQuery("drop table tblRes7")
            'objX.exeQuery("select a.className , a.countings as [AprioriRules] , b.countings as [NavieBayesRules] into tblRes7 from tblres6 a , tblres5 b where b.classname = a.classname")

            'qry = "drop table tblGraph1"
            'objX.exeQuery(qry)

            'qry = "drop table tblGraph2"
            'objX.exeQuery(qry)



            'qry = "drop table tblGraph3"
            'objX.exeQuery(qry)

            'qry = "select a.blgid , a.blog , b.className as [AprioriClassification] , c.className  as [NavieClassification]  into tblGraph1 from tblUsrBlog a , tblRes3 b , tblRes1 c where (a.blgid = b.blgid) and (a.blgid = c.blgid)"
            'objX.exeQuery(qry)


            'qry = "select navieClassification , count(*) as Countings into tblGraph3 from tblGraph1 group by navieClassification "
            'objX.exeQuery(qry)


            'qry = "select aprioriClassification , count(*) as Countings into tblGraph2 from tblGraph1 group by aprioriClassification "
            'objX.exeQuery(qry)

            'admin.adminClass.qry = "select a.blgid , a.blog , b.className as [AprioriClassification] , c.className  as [NavieClassification]  from tblUsrBlog a , tblRes3 b , tblRes1 c where (a.blgid = b.blgid) and (a.blgid = c.blgid)"

            objX.exeQuery("drop table tblRes5")
            objX.exeQuery("drop table tblRes6")
            objX.exeQuery("select classname , count(classname) as countings INTO tblRes5 from tblres3 group by classname")
            objX.exeQuery("select classname , count(classname) as countings INTO tblRes6 from tblres1 group by classname ")
            objX.exeQuery("drop table tblRes7")
            objX.exeQuery("select a.className , a.countings as [AprioriRules] , b.countings as [NavieBayesRules] into tblRes7 from tblres6 a , tblres5 b where b.classname = a.classname")

            qry = "drop table tblGraph1"
            objX.exeQuery(qry)

            qry = "drop table tblGraph2"
            objX.exeQuery(qry)



            qry = "drop table tblGraph3"
            objX.exeQuery(qry)

            qry = "select a.blgid , a.blog , b.className as [AprioriClassification] , c.className  as [NavieClassification]  into tblGraph1 from tblUsrBlog a , tblRes3 b , tblRes1 c where (a.blgid = b.blgid) and (a.blgid = c.blgid)"
            objX.exeQuery(qry)


            qry = "select navieClassification , count(*) as Countings into tblGraph3 from tblGraph1 group by navieClassification "
            objX.exeQuery(qry)


            qry = "select aprioriClassification , count(*) as Countings into tblGraph2 from tblGraph1 group by aprioriClassification "
            objX.exeQuery(qry)


            Response.Redirect("frmBlogBlock.aspx", False)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MsgBox("Classification Results Updated")
        End Try
    End Sub

    Protected Sub btnNaiveBayes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNaiveBayes.Click
        Try
            Dim dTbl2 As New DataTable
            Dim frCnt2 As Integer = 0

            objX.exeQuery("truncate table tblBlgProb")
            qry = ""
            qry = "drop table tblres2"
            objX.exeQuery(qry)

            qry = "drop table tblres3"
            objX.exeQuery(qry)

            qry = "select a.blgid , a.word , b.classname, count(*) as countings into tblRes2 from tblBlgWrdCnt2 a , tblClassTerms b where   ( a.word = b.engword) group by a.blgid , a.word , b.classname order by a.blgid"
            objX.exeQuery(qry)

            qry = "select distinct(blgid) from tblres2"
            dTbl = objX.getDataTable(qry)
            If dTbl.Rows.Count > 0 Then
                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    qry = ""
                    qry = "select * from tblres2 where blgid = " & CInt(dTbl.Rows(frCnt).Item(0).ToString.Trim)
                    dTbl2 = objX.getDataTable(qry)
                    If dTbl2.Rows.Count > 0 Then
                        For frCnt2 = 0 To dTbl2.Rows.Count - 1
                            qry = "insert into tblBlgProb values (" & CInt(dTbl2.Rows(frCnt2).Item(0).ToString.Trim) & " , '" & dTbl2.Rows(frCnt2).Item(1).ToString.Trim & "' , '" & dTbl2.Rows(frCnt2).Item(2).ToString.Trim & "' , " & CInt(dTbl2.Rows.Count) & ")"
                            objX.exeQuery(qry)
                        Next
                    End If
                Next
            End If

            qry = "select blgid ,  classname  , count(classname ) as countCls , countings as counts  ,  (count(classname ) / countings ) as prob into tblRes3 from tblBlgProb  group by blgid ,  classname  , countings  order by blgid"
            objX.exeQuery(qry)

            qry = "alter table tblres3 alter column prob numeric(10,6)"
            objX.exeQuery(qry)


            qry = "select * from tblres3"
            dTbl = New DataTable
            dTbl = objX.getDataTable(qry)
            Dim ctn As Integer = 0
            Dim totCnt As Integer = 0
            Dim prob As Decimal = 0
            If dTbl.Rows.Count > 0 Then
                For Me.frCnt = 0 To dTbl.Rows.Count - 1
                    ctn = 0
                    totCnt = 0
                    prob = 0

                    ctn = CInt(dTbl.Rows(frCnt).Item(2).ToString.Trim)
                    totCnt = CInt(dTbl.Rows(frCnt).Item(3).ToString.Trim)
                    prob = ctn / totCnt


                    qry = "update tblres3 set prob = " & prob & " where blgid = " & CInt(dTbl.Rows(frCnt).Item(0).ToString.Trim) & " and classname = '" & dTbl.Rows(frCnt).Item(1).ToString.Trim & "'"
                    objX.exeQuery(qry)
                Next
            End If

            qry = "select blgid from tblres3"
            dTbl = New DataTable
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                For Me.frCnt = 0 To dTbl.Rows.Count - 1

                    qry = "select * from tblres3 where blgid = " & CInt(dTbl.Rows(frCnt).Item(0).ToString.Trim) & " order by prob desc"
                    dTbl2 = objX.getDataTable(qry)

                    If dTbl2.Rows.Count > 0 Then
                        For frCnt2 = 0 To dTbl2.Rows.Count - 1
                            If frCnt2 > 0 Then
                                qry = ""
                                qry = "delete from tblres3 where blgid = " & CInt(dTbl2.Rows(frCnt2).Item(0).ToString.Trim) & " and classname = '" & (dTbl2.Rows(frCnt2).Item(1).ToString.Trim) & "'"
                                objX.exeQuery(qry)
                            End If
                        Next
                    End If



                Next
            End If
            MsgBox("Naive Bayes Classification completed")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub btnReport1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport1.Click
        Try
            Response.Redirect("frmReport1.aspx", False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnReport2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport2.Click
        Try
            Response.Redirect("frmReport2.aspx", False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
