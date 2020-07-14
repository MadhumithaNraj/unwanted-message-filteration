


Imports System.Data
Partial Class frmClassTerms
    Inherits System.Web.UI.Page
    Dim objX As New admin.adminClass
    Dim qry As String = ""
    Dim dTble As New DataTable
    Shared selWord As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("UserName") = "admin" Then
            If IsPostBack = False Then
                loadClasses()
                loadEngWords()
                loadBadWords()
                loadClassesTerms()
            End If

        Else
            Response.Redirect("Default.aspx", False)
        End If



    End Sub

    Sub loadClasses()
        Try
            qry = "select * from tblClassNames order by ClassNames"
            dTble = objX.getDataTable(qry)

            If dTble.Rows.Count > 0 Then
                DropDownList1.DataSource = dTble
                DropDownList1.DataValueField = "ClassNames"
                DropDownList1.DataBind()
                DropDownList1.SelectedIndex = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub loadEngWords()
        Try
            qry = "select * from  tblEngWords order by engword"
            dTble = objX.getDataTable(qry)

            If dTble.Rows.Count > 0 Then
                DropDownList2.DataSource = dTble
                DropDownList2.DataValueField = "engword"
                DropDownList2.DataBind()
                DropDownList2.SelectedIndex = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub loadBadWords()
        Try
            qry = "select * from tblBadWords order by badword"
            dTble = objX.getDataTable(qry)

            If dTble.Rows.Count > 0 Then
                DropDownList3.DataSource = dTble
                DropDownList3.DataValueField = "badword"
                DropDownList3.DataBind()
                DropDownList3.SelectedIndex = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If lblSelWord.Text.Trim <> "" Then



                qry = "delete from  tblClassTerms where ClassName = '" & DropDownList1.SelectedValue & "' and engWord = '" & lblSelWord.Text.Trim & "'"
                objX.exeQuery(qry)


                qry = "insert into tblClassTerms values ('" & DropDownList1.SelectedValue & "' , '" & lblSelWord.Text.Trim & "')"
                objX.exeQuery(qry)

                MsgBox("Record Saved")
                loadClassesTerms()
                lblSelWord.Text = ""
            Else
                MsgBox("Word Selection Not Found")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged
        Try
            lblSelWord.Text = DropDownList2.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DropDownList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList3.SelectedIndexChanged
        Try
            lblSelWord.Text = DropDownList3.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ibBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibBack.Click
        Try
            Response.Redirect("frmAdminHome.aspx", False)
        Catch ex As Exception

        End Try
    End Sub


    
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex
            loadClassesTerms()
        Catch ex As Exception

        End Try
    End Sub

    Sub loadClassesTerms()
        Try
            qry = "select *  from tblClassTerms order by ClassName , EngWord"
            dTble = objX.getDataTable(qry)

            If dTble.Rows.Count > 0 Then
                GridView1.DataSource = dTble
                GridView1.DataBind()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
