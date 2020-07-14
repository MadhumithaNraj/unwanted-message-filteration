Imports System.Data
Imports System.IO

Partial Class frmShortText
    Inherits System.Web.UI.Page

    Dim objX As New admin.adminClass
    Dim qry As String = ""
    Dim dTble As New DataTable
    Shared selWord As String = ""


    Protected Sub ibBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibBack.Click
        Try
            Response.Redirect("frmAdminHome.aspx", False)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserName") = "admin" Then
                If IsPostBack = False Then

                    loadEngWords()
                   
                End If

            Else
                Response.Redirect("Default.aspx", False)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub loadEngWords()
        Try
            qry = ""
            dTble = New DataTable
            qry = "select * from  tblShortText order by shorttext"
            dTble = objX.getDataTable(qry)

            If dTble.Rows.Count > 0 Then
                GridView1.DataSource = dTble
                GridView1.DataBind()
            Else
                GridView1.DataSource = dTble
                GridView1.DataBind()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Try
            Dim filePath As String = ""
            filePath = Server.MapPath(".") & "\database\Files\shortText.txt"
            Dim file As System.IO.FileStream
            Dim sw As StreamReader
            Dim input As String = ""
            Dim maxId As Integer = 0
            Dim words() As String
            Dim word As String = ""

            file = New System.IO.FileStream(filePath.Trim, IO.FileMode.Open, IO.FileAccess.Read)
            sw = New StreamReader(file)
            sw.BaseStream.Seek(0, SeekOrigin.Begin)

            While sw.Peek <> -1
                input = sw.ReadLine
                words = input.Split("$")
                If words.Length = 2 Then
                    If input.Trim <> "" Then
                        maxId = objX.getMaxID("tblShortText", "recid")
                        maxId += 1
                        qry = "delete from tblShortText where ShortText = '" & objX.FormatText(words.GetValue(0).ToString.Trim) & "'"
                        objX.exeQuery(qry)

                        qry = "insert into  tblShortText values (" & maxId & " , '" & objX.FormatText(words.GetValue(0).ToString.Trim) & "' , '" & objX.FormatText(words.GetValue(1).ToString.Trim) & "')"
                        objX.exeQuery(qry)
                    End If
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            loadEngWords()
            MsgBox("Short Texts Updated...")

        End Try
    End Sub
    Protected Sub GridView1_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex
            loadEngWords()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            qry = "truncate table tblShortText"
            objX.exeQuery(qry)
            loadEngWords()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
