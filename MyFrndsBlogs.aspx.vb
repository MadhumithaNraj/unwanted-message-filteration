Imports admin.adminClass
Imports System.Data

Partial Class MyFrndsBlogs
    Inherits System.Web.UI.Page

    Dim objX As New admin.adminClass
    Dim qry As String = ""
    Dim dTbl As New DataTable

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
            Response.Redirect("UserDetails.aspx", False)
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub


    Sub fillBlog()
        Try
            qry = ""

            qry = "select * from tblUsrBlog where usrname <> '" & Session("UserName") & "' and usrname in (select FrndName from tblFrndReq where Usrname = '" & Session("UserName") & "'  and FrndReqStatus = 'Friend')  and blgid not in (select blgid from dbo.tblgraph1 where navieclassification = 'Offensive' or  navieclassification = 'Violence'  or  navieclassification = 'Vulgar'  or  navieclassification = 'Sex')  order by usrname ,blgid desc"
            ' qry = "select * from tblUsrBlog where usrname <> '" & Session("UserName") & "' and usrname in (select FrndName from tblFrndReq where Usrname = '" & Session("UserName") & "'  and FrndReqStatus = 'Friend')  order by usrname , blgid ,  postingdate desc"
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


End Class
