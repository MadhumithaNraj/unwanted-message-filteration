

Imports System.IO
Imports System.Data

Partial Class frmClasses
    Inherits System.Web.UI.Page

    Dim objX As New admin.adminClass
    Dim qry As String = ""
    Dim dTbl As New DataTable

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Try
            Dim filePath As String = ""
            filePath = Server.MapPath(".") & "\database\Files\classes.txt"
            Dim file As System.IO.FileStream
            Dim sw As StreamReader
            Dim input As String = ""

            file = New System.IO.FileStream(filePath.Trim, IO.FileMode.Open, IO.FileAccess.Read)
            sw = New StreamReader(file)
            sw.BaseStream.Seek(0, SeekOrigin.Begin)

            While sw.Peek <> -1
                input = sw.ReadLine


                If input.Trim <> "" Then

                    qry = "delete from tblClassNames where ClassNames   = '" & objX.FormatText(input.Trim) & "'"
                    objX.exeQuery(qry)

                    qry = "insert into  tblClassNames values ('" & objX.FormatText(input.Trim) & "')"
                    objX.exeQuery(qry)
                End If

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            fillBlog()
            MsgBox("Class Names updated...")

        End Try
    End Sub



    Protected Sub ibBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibBack.Click
        Try
            Response.Redirect("frmAdminHome.aspx", False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    Protected Sub GridView1_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex
            fillBlog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserName") = "admin" Then


                If IsPostBack = False Then
                    fillBlog()
                End If
            Else
                Response.Redirect("Default.aspx", False)
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub fillBlog()
        Try
            qry = ""

            qry = "select *  from  tblClassNames order by ClassNames"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                GridView1.DataSource = dTbl
                GridView1.DataBind()
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub



End Class

