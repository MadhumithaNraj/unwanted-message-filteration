
Partial Class myFriends
    Inherits System.Web.UI.Page
    Dim objX As New admin.adminClass
    Dim qry As String = ""
    Dim dTbl As New DataTable

    Protected Sub btnopenfriends_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnopenfriends.Click
        Try
            Response.Redirect("UserDetails.aspx", False)
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then

                If Session("UserName") = "" Then
                    Response.Redirect("Default.aspx", False)
                Else
                    lblName.Text = Session("UserName")
                    fillUsers()
                    fillFrndRequest()
                    fillFrnds()
                End If

            End If



        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub

    Sub fillUsers()
        Try
            lstUser.Items.Clear()
            qry = "select regname from tblUserRegistration where regname <> '" & Session("UserName") & "'  and regname not in (select FrndName from tblFrndReq where Usrname = '" & Session("UserName") & "' and FrndReqStatus = 'Friend')"
            dTbl = objX.getDataTable(qry)
            If dTbl.Rows.Count > 0 Then
                lstUser.DataSource = dTbl
                lstUser.DataValueField = "regname"
                lstUser.DataBind()
            End If

        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub

    Sub fillFrndRequest()
        Try
            lstFrndReq.Items.Clear()

            qry = "select usrname from tblFrndReq where FrndName = '" & Session("UserName") & "' and FrndReqStatus = 'Request'   and usrname <> '" & Session("UserName") & "'"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                lstFrndReq.DataSource = dTbl
                lstFrndReq.DataValueField = "usrname"
                lstFrndReq.DataBind()
            End If

        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub

    Sub fillFrnds()
        Try
            lstFrnds.Items.Clear()
            qry = "select FrndName from tblFrndReq where Usrname = '" & Session("UserName") & "'  and FrndReqStatus = 'Friend'"
            dTbl = objX.getDataTable(qry)

            If dTbl.Rows.Count > 0 Then
                lstFrnds.DataSource = dTbl
                lstFrnds.DataValueField = "FrndName"
                lstFrnds.DataBind()
            End If

        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try

    End Sub


    Protected Sub btnRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRequest.Click
        Try


            If lstUser.SelectedValue.ToString.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('User Not Selected...');", True)
            Else
                admin.adminClass.rows = 0

                qry = ""
                qry = "select * from tblFrndReq where UsrName = '" & Session("UserName") & "' and FrndName = '" & lstUser.SelectedValue.ToString.Trim & "' and FrndReqStatus = 'Request'"
                dTbl = objX.getDataTable(qry)

                If dTbl.Rows.Count > 0 Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('User Request Already Sent! Awaiting for Approval !');", True)
                Else

                    qry = "insert into tblFrndReq values ('" & Session("UserName") & "' , '" & lstUser.SelectedValue.ToString.Trim & "' , 'Request')"
                    objX.exeQuery(qry)

                   

                    If admin.adminClass.rows > 0 Then
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('User Request Sent...');", True)
                    End If

                    fillUsers()
                    fillFrndRequest()
                    fillFrnds()

                End If

            End If
        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub btnCancelRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelRequest.Click
        Try
            If lstFrnds.SelectedValue.ToString.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('User Not Selected...');", True)
            Else
                admin.adminClass.rows = 0

                qry = ""

                qry = "update tblFrndReq set FrndReqStatus = 'Request' where UsrName = '" & Session("UserName") & "' and FrndName = '" & lstFrnds.SelectedValue.ToString.Trim & "'"
                objX.exeQuery(qry)


                If admin.adminClass.rows > 0 Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('Friend Request Revoked...');", True)
                End If

                fillUsers()
                fillFrndRequest()
                fillFrnds()

            End If


        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub btnConfirmRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmRequest.Click
        Try
            If lstFrndReq.SelectedValue.ToString.Trim = "" Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('User Not Selected...');", True)
            Else
                admin.adminClass.rows = 0

                qry = ""

                qry = "update tblFrndReq set FrndReqStatus = 'Friend' where UsrName = '" & lstFrndReq.SelectedValue.ToString.Trim & "' and FrndName = '" & Session("UserName") & "'"
                objX.exeQuery(qry)

                fillUsers()
                fillFrndRequest()
                fillFrnds()

                If admin.adminClass.rows > 0 Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "script", "alert('Friend Request Confirmed...');", True)
                End If
            End If


        Catch ex As Exception
            lblmessage.Text = ex.Message.ToString
        End Try
    End Sub
End Class
