Module Common

    Public Function fdate(mode As Integer)

        Select Case mode
            Case 1
                '2019-02-31
                Return Year(Now) & "-" & vbRight("0" & Month(Now()), 2) & "-" & vbRight("0" & vbDay(Now()), 2)
            Case 2
                '190231
                Return "190231"
            Case 3
                Return "19-2-31"
        End Select
        Return Now()
    End Function


    Function vbRight(str As String, len As Integer)
        Return Microsoft.VisualBasic.Right(str, len)
    End Function

    Function vbLeft(str As String, len As Integer)
        Return Microsoft.VisualBasic.Left(str, len)
    End Function

    Function vbDay(str As String)
        Return Microsoft.VisualBasic.Day(str)
    End Function


End Module
