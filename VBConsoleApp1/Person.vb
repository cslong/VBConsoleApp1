Imports System.ComponentModel.Design

<System.Serializable()>
Public Class Person
    Public Property Name As String
    Public Property Age As Integer

    Public Sub New()
        Console.WriteLine("This is a constructor")
    End Sub

    Public Sub SetName(newName As String)
        Name = newName
    End Sub

    Public Function GetName() As String
        Return Name
    End Function

End Class

Class Book

End Class


Public Class Student
    Inherits Person

    Public Sub New()
        MyBase.New()
    End Sub

    Public Property Gpa As Decimal

End Class