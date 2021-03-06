﻿Imports WarCardGameLibrary

Public Class Fight
    Inherits System.Web.UI.Page

    Private Sub Fight_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("CardGame") Is Nothing Then
            Response.Redirect("~/Default.aspx")
        End If
    End Sub
    Protected Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        pnlResults.Visible = True

        Dim myGame As WarGame = CType(Session("CardGame"), WarGame)
        If ddlRules.SelectedValue = "1" Then
            myGame.StartGame(New ClassicRules())
        ElseIf ddlRules.SelectedValue = "2" Then
            myGame.StartGame(New OppositeRules())
        End If
        ltlResults.Text = myGame.Winner.ToString
        ltlTeam1Score.Text = myGame.Team1Score.ToString
        ltlTeam2Score.Text = myGame.Team2Score.ToString
        ltlties.Text = myGame.Ties.ToString

        rptResults.DataSource = myGame.Results
        rptResults.DataBind()

    End Sub

    Protected Sub rptResults_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptResults.ItemDataBound
        Dim myResult As Battle
        Dim imgTeam1 As Image
        Dim imgTeam2 As Image
        Dim trResult As HtmlTableRow
        Dim ltlResult As Literal
        Try
            myResult = CType(e.Item.DataItem, Battle)
            imgTeam1 = CType(e.Item.FindControl("imgTeam1"), Image)
            imgTeam2 = CType(e.Item.FindControl("imgTeam2"), Image)
            trResult = CType(e.Item.FindControl("trResult"), HtmlTableRow)
            ltlResult = CType(e.Item.FindControl("ltlResult"), Literal)

            imgTeam1.ImageUrl = "~/Images/" + myResult.Team1Card.ImageName
            imgTeam2.ImageUrl = "~/Images/" + myResult.Team2Card.ImageName
            ltlResult.Text = myResult.Result.ToString
            If myResult.Result = BattleResult.Team1 Then
                trResult.BgColor = "#FFFF00"
            ElseIf myResult.Result = BattleResult.Team2 Then
                trResult.BgColor = "#0033CC"
            End If


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnStartOver_Click(sender As Object, e As EventArgs) Handles btnStartOver.Click
        Response.Redirect("~/Default.aspx")
    End Sub
End Class