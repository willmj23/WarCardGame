Public Class Card
    Public Property Suit As CardSuit
    Public Property Number As CardNumber

    Public Sub New(mySuit As CardSuit, myNumber As CardNumber)
        Me.Suit = mySuit
        Me.Number = myNumber
    End Sub

    Public ReadOnly Property IsFaceCard As Boolean
        Get
            Return False
        End Get
    End Property
    Public ReadOnly Property Color As CardColor
        Get
            If Suit = CardSuit.Clubs OrElse Suit = CardSuit.Spades Then
                Return CardColor.Black
            Else
                Return CardColor.Red
            End If
        End Get
    End Property

    Public ReadOnly Property ImageName As String
        Get
            Dim myImageName As String = ""
            If Me.Number <= 10 Then
                myImageName = CInt(Me.Number).ToString
            Else
                myImageName = Me.Number.ToString.Substring(0, 1)
            End If

            myImageName = myImageName + Suit.ToString.Substring(0, 1) + ".jpg"
            Return myImageName
        End Get
    End Property
End Class
