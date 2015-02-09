
Public Class WarGame
    Public Property Deck As List(Of Card) = New List(Of Card)
    Public Property Team1Deck As List(Of Card) = New List(Of Card)
    Public Property Team2Deck As List(Of Card) = New List(Of Card)
    Public Property Results As List(Of Battle) = New List(Of Battle)
    Public Property Rules As IRules
    Public Property Team1Score As Integer = 0
    Public Property Team2Score As Integer = 0
    Public Property Ties As Integer = 0
    Public Property Winner As BattleResult = BattleResult.Tie
    Public Sub New()

    End Sub

    Public Sub StartNewGame(myrules As IRules)
        Rules = myrules
        Dim mySuits As List(Of CardSuit) = Me.GetListSuits
        Dim myCardfaces As List(Of CardNumber) = Me.GetFaceCards()

        For Each mySuit In mySuits
            For Each myCardface In myCardfaces
                Deck.Add(New Card(mySuit, myCardface))
            Next
        Next
        Deck = Shuffle(Deck)
        Deal()
        StartWar()

        If Team1Score > Team2Score Then
            Me.Winner = BattleResult.Team1
        ElseIf Team2Score > Team1Score Then
            Me.Winner = BattleResult.Team2
        Else
            Me.Winner = BattleResult.Tie
        End If
    End Sub

    Public Function GetListSuits() As List(Of CardSuit)
        Dim mySuits As New List(Of CardSuit)
        mySuits.Add(CardSuit.Clubs)
        mySuits.Add(CardSuit.Hearts)
        mySuits.Add(CardSuit.Spades)
        mySuits.Add(CardSuit.Diamonds)
        Return mySuits
    End Function

    Public Function GetFaceCards() As List(Of CardNumber)
        Dim myCardfaces As New List(Of CardNumber)
        myCardfaces.Add(CardNumber.Two)
        myCardfaces.Add(CardNumber.Three)
        myCardfaces.Add(CardNumber.Four)
        myCardfaces.Add(CardNumber.Five)
        myCardfaces.Add(CardNumber.Six)
        myCardfaces.Add(CardNumber.Seven)
        myCardfaces.Add(CardNumber.Eight)
        myCardfaces.Add(CardNumber.Nine)
        myCardfaces.Add(CardNumber.Ten)
        myCardfaces.Add(CardNumber.Jack)
        myCardfaces.Add(CardNumber.Queen)
        myCardfaces.Add(CardNumber.King)
        myCardfaces.Add(CardNumber.Ace)
        Return myCardfaces
    End Function

    Function Shuffle(Of card)(collection As IEnumerable(Of Card)) As List(Of Card)
        Dim r As Random = New Random()
        Shuffle = collection.OrderBy(Function(a) r.Next()).ToList()
    End Function

    Private Sub Deal()
        For Each myCard As Card In Deck
            If Team2Deck.Count <> Team1Deck.Count Then
                Team2Deck.Add(myCard)
            Else
                Team1Deck.Add(myCard)
            End If
        Next
    End Sub

    Private Sub StartWar()
        Dim myBattle As Battle
        For x As Integer = 0 To 25
            myBattle = New Battle(Team1Deck(x), Team2Deck(x), Rules)
            myBattle.Fight()
            If myBattle.Result = BattleResult.Team1 Then
                Team1Score = Team1Score + 1
            ElseIf myBattle.Result = BattleResult.Team2 Then
                Team2Score = Team2Score + 1
            Else
                Ties += 1
            End If
            Results.Add(myBattle)
        Next
    End Sub

End Class
