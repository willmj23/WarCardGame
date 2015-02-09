Public Class Battle
    Public Property Team1Card As Card
    Public Property Team2Card As Card
    Public Property Result As BattleResult
    Public Property Rules As IRules

    Public Sub New(myTeam1Card As Card, myTeam2card As Card, myRules As IRules)
        Me.Team1Card = myTeam1Card
        Me.Team2Card = myTeam2card
        Me.Rules = myRules
    End Sub

    Public Sub Fight()
        Result = Rules.Fight(Team1Card, Team2Card)
    End Sub

End Class
