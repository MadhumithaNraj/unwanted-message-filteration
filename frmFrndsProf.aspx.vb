Imports admin.adminClass
Imports System.Data
Imports System.IO
Imports System.Collections.Generic

Partial Class frmFrndsProf
     Inherits System.Web.UI.Page
    Dim objX As New admin.adminClass
    Dim qry As String = ""
    Dim dTbl As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserName") = "" Then
                Response.Redirect("Default.aspx", False)
            Else
                'Session("UserName")
                 qry = ""
                qry = "select * from dbo.tblProfile where usrName in ( select FrndName from  tblFrndReq where UsrName = '" & Session("UserName") & "' and FrndReqStatus = 'Friend' )"
                dTbl = objX.getDataTable(qry)

                If dTbl.Rows.Count > 0 Then
                    GridView1.DataSource = dTbl
                    GridView1.DataBind()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub


 
  
End Class
