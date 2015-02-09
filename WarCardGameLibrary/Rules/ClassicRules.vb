Public Class ClassicRules
    Implements IRules


    Public Function Fight(team1Card As Card, team2Card As Card) As BattleResult Implements IRules.Fight
        If team1Card.Number > team2Card.Number Then
            Return BattleResult.Team1
        ElseIf team2Card.Number > team1Card.Number Then
            Return BattleResult.Team2
        Else
            Return BattleResult.Tie
        End If
    End Function
End Class
