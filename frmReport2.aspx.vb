
Partial Class frmReport2
    Inherits System.Web.UI.Page

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            Response.Redirect("frmAdminHome.aspx", False)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class
