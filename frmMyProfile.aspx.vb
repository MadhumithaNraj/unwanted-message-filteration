Imports System.Data

Partial Class frmMyProfile
    Inherits System.Web.UI.Page

    Dim objX As New admin.adminClass
    Dim qry As String = ""
    Dim dTbl As New DataTable


    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try

            If txtBook.Text.Trim = "" Then
                MsgBox("Book Name not found", MsgBoxStyle.Information, "Error")
                txtBook.Focus()


            ElseIf txtMovie.Text.Trim = "" Then
                MsgBox("Movie Name not found", MsgBoxStyle.Information, "Error")
                txtMovie.Focus()

            ElseIf txtPolitical.Text.Trim = "" Then
                MsgBox("Political Details not found", MsgBoxStyle.Information, "Error")
                txtPolitical.Focus()
            ElseIf txtReligion.Text.Trim = "" Then
                MsgBox("Religion not found", MsgBoxStyle.Information, "Error")
                txtReligion.Focus()
            ElseIf txtActivities.Text.Trim = "" Then
                MsgBox("Activities not found", MsgBoxStyle.Information, "Error")
                txtActivities.Focus()
            ElseIf txtSport.Text.Trim = "" Then
                MsgBox("Sport Details not found", MsgBoxStyle.Information, "Error")
                txtSport.Focus()
            ElseIf txtSongs.Text.Trim = "" Then
                MsgBox("Songs not found", MsgBoxStyle.Information, "Error")
                txtSongs.Focus()
            ElseIf txtTVShows.Text.Trim = "" Then
                MsgBox("TVShows not found", MsgBoxStyle.Information, "Error")
                txtTVShows.Focus()
            ElseIf txtMobileModel.Text.Trim = "" Then
                MsgBox("MobileModel not found", MsgBoxStyle.Information, "Error")
                txtMobileModel.Focus()
            ElseIf txtMobileNetwork.Text.Trim = "" Then
                MsgBox("MobileNetwork not found", MsgBoxStyle.Information, "Error")
                txtMobileNetwork.Focus()
            Else



                qry = ""
                qry = "select * from tblProfile where usrName  = '" & Session("UserName") & "'"
                dTbl = objX.getDataTable(qry)

                If dTbl.Rows.Count > 0 Then
                    qry = "Update tblProfile set usrBook ='" & objX.FormatText(txtBook.Text.Trim) & "' , usrMovie = '" & objX.FormatText(txtMovie.Text.Trim) & "' , usrPolitical = '" & objX.FormatText(txtPolitical.Text.Trim) & "' , usrReligion ='" & objX.FormatText(txtReligion.Text.Trim) & "' , usrActivities = '" & objX.FormatText(txtActivities.Text.Trim) & "' , usrSport = '" & objX.FormatText(txtSport.Text.Trim) & "' , usrSongs = '" & objX.FormatText(txtSongs.Text.Trim) & "' , usrTVShows = '" & objX.FormatText(txtTVShows.Text.Trim) & "' , usrMobileModel = '" & objX.FormatText(txtMobileModel.Text.Trim) & "' , usrMobileNetwork = '" & objX.FormatText(txtMobileNetwork.Text.Trim) & "' where usrName = '" & Session("UserName") & "'"
                    objX.exeQuery(qry)

                    If admin.adminClass.rows > 0 Then
                        MsgBox("Record Saved")

                    End If
                Else
                    qry = "insert into tblProfile values ('" & Session("UserName") & "' , '" & objX.FormatText(txtBook.Text.Trim) & "' , '" & objX.FormatText(txtMovie.Text.Trim) & "' , '" & objX.FormatText(txtPolitical.Text.Trim) & "' , '" & objX.FormatText(txtReligion.Text.Trim) & "' , '" & objX.FormatText(txtActivities.Text.Trim) & "' , '" & objX.FormatText(txtSport.Text.Trim) & "' , '" & objX.FormatText(txtSongs.Text.Trim) & "' , '" & objX.FormatText(txtTVShows.Text.Trim) & "' , '" & objX.FormatText(txtMobileModel.Text.Trim) & "' , '" & objX.FormatText(txtMobileNetwork.Text.Trim) & "')"
                    objX.exeQuery(qry)

                    If admin.adminClass.rows > 0 Then
                        MsgBox("Record Saved")
                    Else
                        MsgBox("Record not saved")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            fillProfile()
        End Try
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            txtClear()
            txtBook.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub txtClear()
        Try
            lblName.Text = ""
            txtBook.Text = ""
            txtMovie.Text = ""
            txtPolitical.Text = ""
            txtReligion.Text = ""
            txtActivities.Text = ""
            txtSport.Text = ""
            txtSongs.Text = ""
            txtTVShows.Text = ""
            txtMobileModel.Text = ""
            txtMobileNetwork.Text = ""

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then



                If Session("UserName") = "" Then
                    Response.Redirect("Default.aspx", False)
                Else
                    fillProfile()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub fillProfile()
        Try
            txtClear()
            qry = ""
            qry = "select * from tblProfile where usrName  = '" & Session("UserName") & "'"
            dTbl = objX.getDataTable(qry)
            lblName.Text = Session("UserName")
            If dTbl.Rows.Count > 0 Then

                txtBook.Text = dTbl.Rows(0).Item(1).ToString.Trim
                txtMovie.Text = dTbl.Rows(0).Item(2).ToString.Trim
                txtPolitical.Text = dTbl.Rows(0).Item(3).ToString.Trim
                txtReligion.Text = dTbl.Rows(0).Item(4).ToString.Trim
                txtActivities.Text = dTbl.Rows(0).Item(5).ToString.Trim
                txtSport.Text = dTbl.Rows(0).Item(6).ToString.Trim
                txtSongs.Text = dTbl.Rows(0).Item(7).ToString.Trim
                txtTVShows.Text = dTbl.Rows(0).Item(8).ToString.Trim
                txtMobileModel.Text = dTbl.Rows(0).Item(9).ToString.Trim
                txtMobileNetwork.Text = dTbl.Rows(0).Item(10).ToString.Trim
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            Response.Redirect("UserDetails.aspx", False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
