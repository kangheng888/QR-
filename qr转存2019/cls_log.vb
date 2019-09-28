Imports System.IO
Imports System.Text


Public Class cls_Log_file

    Dim hh As Char = ""


    Dim Dir As String = ""
    Public file_name As String = ""

    Dim sw As StreamWriter

    Dim sw_export As StreamWriter



    Sub Log(ByVal info As String)

        Try
            sw.WriteLine(Now & "__" & info)

        Catch ex As Exception

        End Try

	End Sub



    Public Sub New(ByVal dir0 As String)
        Dir = dir0
        file_name = Dir & "\log.txt"
        file_name = Dir & "\log_" & DateString() & ".txt"
        '  file_name2 = Dir & "\rfid_log.htm"




        If Not My.Computer.FileSystem.DirectoryExists(Dir) Then
            My.Computer.FileSystem.CreateDirectory(Dir)
        End If


        '如果log文件太大,则删除
        If My.Computer.FileSystem.FileExists(file_name) Then
            Dim kk As System.IO.FileInfo = New FileInfo(file_name)
            If kk.Length > 1000000 Then
                kk.Delete()
            End If

        End If


        sw = New StreamWriter(file_name, True, Encoding.Default)


    End Sub

	Public Sub close()
		sw.Flush()
		sw.Close()


	End Sub


#Region "export file 操作"

	Public Function export_file_open(ByVal dir As String, ByVal name As String) As Boolean

        '建立一个新文件,导出温度数据
        file_name = dir & "\temp_out_" & name & ".txt"
        Try
            sw_export = New StreamWriter(file_name, True, Encoding.Default)
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function


    Public Sub export_file_fill(ByVal info As String)
        sw_export.WriteLine(info)

    End Sub

	Public Sub export_file_close()

		sw_export.Flush()
		sw_export.Close()

	End Sub


#End Region

End Class
