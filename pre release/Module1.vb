Module Module1

    Class Toy
        Private Name As String
        Private ID As String
        Private Price As Decimal
        Private MinAge As Integer

        'Constructor
        Sub New(ByVal n As String, ByVal i As String, ByVal p As Decimal, ByVal m As Integer)
            Name = n
            ID = i
            Price = p
            MinAge = m
        End Sub

        'Setter Functions
        Sub setName(ByVal n As String)
            Name = n
        End Sub
        Sub setID(ByVal i As String)
            ID = i
        End Sub
        Sub setPrice(ByVal p As Decimal)
            If p > 0 Then
                Price = p
            End If
        End Sub
        Sub setAge(ByVal a As Integer)
            If a > 0 And a < 18 Then
                MinAge = a
            End If
        End Sub

        'getter functions
        Function getName()
            Return Name
        End Function
        Function getID()
            Return ID
        End Function
        Function getPrice()
            Return Price
        End Function
        Function getAge()
            Return MinAge
        End Function

    End Class

    Class ComputerGame
        Inherits Toy
        Private Category As String
        Private Console As String

        'Constructor
        Sub New(ByVal n As String, ByVal i As String, ByVal p As Decimal, ByVal m As Integer, ByVal cat As String, ByVal con As String)
            MyBase.New(n, i, p, m)
            Category = cat
            Console = con
        End Sub

        'setter functions
        Sub setCat(ByVal cat As String)
            Category = cat
        End Sub
        Sub setCon(ByVal con As String)
            Console = con
        End Sub

        'getter functions
        Function getCat()
            Return Category
        End Function
        Function getCon()
            Return Console
        End Function
    End Class

    Class Vehicle
        Inherits Toy
        Private Type As String
        Private Height As Decimal
        Private Length As Decimal
        Private Weight As Decimal

        'Constructor
        Sub New(ByVal n As String, ByVal i As String, ByVal p As Decimal, ByVal m As Integer, ByVal t As String, ByVal h As Decimal, ByVal l As Decimal, ByVal w As Decimal)
            MyBase.New(n, i, p, m)
            Type = t
            Height = h
            Length = l
            Weight = w
        End Sub

        'Setter Functions
        Sub setType(ByVal n As String)
            Type = n
        End Sub
        Sub setHeight(ByVal h As Decimal)
            If h > 0 Then
                Height = h
            End If
        End Sub
        Sub setLength(ByVal p As Decimal)
            If p > 0 Then
                Length = p
            End If

        End Sub
        Sub setWeight(ByVal a As Decimal)
            If a > 0 Then
                Weight = a
            End If
        End Sub

        'getter functions
        Function getMyType()
            Return Type
        End Function
        Function getHeight()
            Return Height
        End Function
        Function getLength()
            Return Length
        End Function
        Function getWeight()
            Return Weight
        End Function
    End Class


    Sub Main()
        'arrays of classes
        Dim vehicles(10) As Vehicle
        Dim game(10) As ComputerGame

        'instantiating objects
        vehicles(0) = New Vehicle("red sports car", "RSC13", 15.0, 6, "Car", 3.3, 12.1, 0.08)

        Console.WriteLine(findByID(vehicles, game).ToString)

        discount(vehicles, game, 10)
    End Sub

    Function findByID(ByVal vehicles() As Vehicle, ByVal game() As ComputerGame)
        Console.WriteLine("input id")
        Dim idtofind = Console.ReadLine()
        Dim i As Integer
        While i < vehicles.Length - 1 Or i < game.Length - 1
            If i < vehicles.Length - 1 Then
                If vehicles(i).getID = idtofind Then
                    Return vehicles(i)
                End If
            End If
            If i < game.Length - 1 Then
                If game(i).getID = idtofind Then
                    Return game(i)
                End If
            End If
        End While
        Return 0
    End Function

    Sub discount(ByRef vehicles() As Vehicle, ByRef game() As ComputerGame, ByVal disc As Decimal)
        For i = 0 To vehicles.Length - 1
            vehicles(i).setPrice(vehicles(i).getPrice * (100 - disc) / 100)
        Next
        For i = 0 To game.Length - 1
            game(i).setPrice(game(i).getPrice * (100 - disc) / 100)
        Next
    End Sub

    Sub sort(ByRef game() As ComputerGame)
        Dim toInsert As ComputerGame
        Dim counter As Integer
        For i = 1 To game.Length - 1
            toInsert = game(i)
            counter = i
            While game(counter).getPrice < game(counter - 1).getPrice And counter <> 0
                game(counter) = game(counter - 1)
                counter -= 1
            End While
            game(counter) = toInsert
        Next
    End Sub
End Module
