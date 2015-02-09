Imports WarCardGameLibrary

Partial Class [Default]
    Inherits Page

    Protected Sub btnCreateDeck_Click(sender As Object, e As EventArgs) Handles btnCreateDeck.Click
        pnlDeck.Visible = True
        Dim myGame As New WarGame()
        myGame.CreateDeck()

        Session("CardGame") = myGame
        trTeam1.Visible = False
        trTeam2.Visible = False

        rptTeam1Decka.DataSource = myGame.Deck.GetRange(0, 13)
        rptTeam1Deckb.DataSource = myGame.Deck.GetRange(13, 13)
        rptTeam2Decka.DataSource = myGame.Deck.GetRange(26, 13)
        rptTeam2Deckb.DataSource = myGame.Deck.GetRange(39, 13)

        rptTeam1Decka.DataBind()
        rptTeam1Deckb.DataBind()
        rptTeam2Decka.DataBind()
        rptTeam2Deckb.DataBind()

        btnShuffle.Visible = True
        btnDeal.Visible = True

    End Sub

    Protected Sub rptTeam1Decka_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptTeam1Decka.ItemDataBound, rptTeam1Deckb.ItemDataBound, rptTeam2Decka.ItemDataBound, rptTeam2Deckb.ItemDataBound
        Dim myCard As Card
        Dim img1 As Image


        Try
            myCard = CType(e.Item.DataItem, Card)
            img1 = CType(e.Item.FindControl("img1"), Image)

            img1.ImageUrl = "~/Images/" + myCard.ImageName
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnShuffle_Click(sender As Object, e As EventArgs) Handles btnShuffle.Click
        Dim myGame As WarGame = CType(Session("CardGame"), WarGame)

        myGame.Shuffle()
        trTeam1.Visible = False
        trTeam2.Visible = False

        rptTeam1Decka.DataSource = myGame.Deck.GetRange(0, 13)
        rptTeam1Deckb.DataSource = myGame.Deck.GetRange(13, 13)
        rptTeam2Decka.DataSource = myGame.Deck.GetRange(26, 13)
        rptTeam2Deckb.DataSource = myGame.Deck.GetRange(39, 13)

        rptTeam1Decka.DataBind()
        rptTeam1Deckb.DataBind()
        rptTeam2Decka.DataBind()
        rptTeam2Deckb.DataBind()

        Session("CardGame") = myGame

    End Sub

    Private Sub btnDeal_Click(sender As Object, e As EventArgs) Handles btnDeal.Click
        Dim myGame As WarGame = CType(Session("CardGame"), WarGame)

        myGame.Deal()
        trTeam1.Visible = True
        trTeam2.Visible = True

        rptTeam1Decka.DataSource = myGame.Team1Deck.GetRange(0, 13)
        rptTeam1Deckb.DataSource = myGame.Team1Deck.GetRange(13, 13)
        rptTeam2Decka.DataSource = myGame.Team2Deck.GetRange(0, 13)
        rptTeam2Deckb.DataSource = myGame.Team2Deck.GetRange(13, 13)

        rptTeam1Decka.DataBind()
        rptTeam1Deckb.DataBind()
        rptTeam2Decka.DataBind()
        rptTeam2Deckb.DataBind()

        btnShuffle.Visible = False
        btnDeal.Visible = False
        btnFight.Visible = True
        Session("CardGame") = myGame
    End Sub

    Private Sub btnFight_Click(sender As Object, e As EventArgs) Handles btnFight.Click
        Response.Redirect("~/Fight.aspx", False)
    End Sub
End Class