Imports System.Data
Partial Class frmBlogBlock
    Inherits System.Web.UI.Page

    Dim objX As New admin.adminClass
    Dim qry As String = ""
    Dim dTbl As New DataTable
    Shared flg As String = ""

    Protected Sub ibBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibBack.Click
        Try
            Response.Redirect("frmAdminHome.aspx", False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnRes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRes.Click
        Try
            flg = "Classification"
            fillBlog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub fillBlog()
        Try
            Dim dTbl2 As New DataTable
            Dim dTbl3 As New DataTable
            Dim frCnt As Integer = 0
            Dim frCnt2 As Integer = 0
            Dim combStr As String = ""

            qry = ""
            qry = "select distinct(blgid) from  tblStpWrdRmv  order by blgid"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                qry = ""
                dTbl2 = New DataTable

                For frCnt = 0 To dTbl.Rows.Count - 1
                    qry = ""
                    combStr = ""
                    qry = "select * from  tblStpWrdRmv  where blgid = " & dTbl.Rows(frCnt).Item(0).ToString.Trim & " order by wordno"
                    dTbl2 = objX.getDataTable(qry)

                    If dTbl2.Rows.Count > 0 Then
                        qry = ""

                        For frCnt2 = 0 To dTbl2.Rows.Count - 1
                            combStr &= dTbl2.Rows(frCnt2).Item(2).ToString.Trim & " "
                        Next
                        qry = "update tblGraph1 set blog = '" & objX.FormatText(combStr) & "' where blgid = " & dTbl.Rows(frCnt).Item(0).ToString.Trim
                        objX.exeQuery(qry)
                    End If
                Next


            End If


            'qry = ""
            'objX.exeQuery("update tblGraph1 set navieClassification = 'NA'")

            If flg = "Classification" Then
                qry = "select * from tblGraph1"

            ElseIf flg = "Apriori" Then
                qry = "select * from tblGraph2"
            ElseIf flg = "Naive" Then
                qry = "select * from tblGraph3"
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

    Protected Sub btnApriori_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApriori.Click
        Try
            flg = "Apriori"
            fillBlog()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnNavie_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNavie.Click
        Try
            flg = "Naive"
            fillBlog()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex
            fillBlog()
        Catch ex As Exception

        End Try
    End Sub
End Class
