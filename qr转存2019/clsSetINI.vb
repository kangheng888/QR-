Public Class clsSetINI

    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32

    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32

    Private File_name As String = ""
    Private File_name_bak As String = ""


    '声明INI配置文件读写API函数
    Public Function GetSetting(ByVal Section_name As String, ByVal Setting_name As String) As String
        Dim retval As Integer
        Dim t As String = LSet(Space(256), 256)
        File_name = File_name_bak
        Debug.Print(File_name)

        ' Get the value
        retval = GetPrivateProfileString(Section_name, Setting_name, "", t, Len(t), File_name)

        ' If there is one, return it
        If retval > 0 Then

            GetSetting = Microsoft.VisualBasic.Left(t, InStr(t, Chr(0)) - 1)
        Else
            GetSetting = ""
        End If

    End Function

    '保存ini的参数
    Public Sub SaveOrCreateSetting(ByVal Section$, ByVal Key$, ByVal Value$)
        Dim retval As Integer
        File_name = File_name_bak
        Debug.Print(File_name)
        retval = WritePrivateProfileString(Section$, Key$, Value$, File_name)
    End Sub


    Public Property File0() As String
        Get
            File0 = File_name_bak
        End Get
        Set(ByVal value As String)
            File_name = value
            File_name_bak = value
        End Set
    End Property


    Sub New(ByVal file1 As String)
          If Not My.Computer.FileSystem.FileExists(file1) Then
            MsgBox(file1 & vbCrLf & "不存在.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "不可恢复的错误")
        End If
        File_name = file1
        File_name_bak = file1
    End Sub


End Class