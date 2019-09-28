Imports System.Threading
Imports System.IO.Ports
Imports System.Text
Imports System.Net




Public Class Form1


    Public version As String = "190927A"

    Dim isLog As Boolean
    Dim isDebug As Boolean

    Dim LOG As cls_Log_file = New cls_Log_file("./log")
    Dim ini As clsSetINI = New clsSetINI("./config.ini")

    Dim tcp As Net.Sockets.TcpClient
    Dim ip As String = ""
    Dim ipport As String = ""
    Dim tcp_rev_buf(8000) As Byte
    Dim tcp_rev_cnt As Int16 = 0
    Dim tcp_ret As IAsyncResult

    Dim indir As String = ""
    Dim outdir As String = ""

    '转存次数
    Dim work_cnt As Integer = 0


    '文件名称
    Dim fileIN As String = ""
    Dim fileOUT As String = ""

    Dim qr1 As String = ""
    Dim qr2 As String = ""
    Dim qr As String = ""


    'plc指令
    Dim cmdQRread As String = ""
    Dim cmdQRHide As String = ""
    Dim cmdQRbad As String = ""





    Private Sub 退出XToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出XToolStripMenuItem.Click
        bye()
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles bt_hide.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    Sub tcp_plc_connect()
        Try
            'tcp.Close()
            'tcp.Client.Disconnect(False)
            tcp = New Sockets.TcpClient

            tcp.Connect(ip, ipport)
            showlog("ip=" & ip & "连接成功.")
            'showlog("tcp.Client.Connected3-->" & tcp.Client.Connected)

            'Timer1.Start()
        Catch ex As Exception
            showlog("tcp_plc_connect->")
            showlog(ex.Message)
        End Try
    End Sub




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '2019-09-03_HOU_023.cvs
            fileIN = ini.GetSetting("system", "fileprofix")
            If fileIN.Length = 0 Then
                MsgBox("文件后缀无效,运行终止.")
                End
            End If
            fileIN = fdate(1) & "_" & ini.GetSetting("system", "fileprofix") & ".csv"
            fileOUT = fdate(1) & "_" & ini.GetSetting("system", "fileprofix") & ".csv"

            cmdQRread = ini.GetSetting("system", "QRread")
            cmdQRHide = ini.GetSetting("system", "QRhide")
            cmdQRbad = ini.GetSetting("system", "QRbad")

            isLog = CBool(ini.GetSetting("system", "log"))
            isDebug = CBool(ini.GetSetting("system", "debug"))

            showlog("begin...")
            Me.Text = ini.GetSetting("system", "title")

            ts_qrport.Text = ini.GetSetting("system", "qr")
            ts_runtime.Text = Now()



            'tcp 
            ip = ini.GetSetting("system", "ip")
            ipport = ini.GetSetting("system", "port")

            tcp_plc_connect()
            do_tcp_read()


            'qr
            SP1.PortName = ini.GetSetting("system", "QR")
            SP1_OPEN()

            'timer
            Timer1.Interval = 2000
            If Not tcp.Connected Then
                Timer1.Start()
            End If


            '
            'indir = ini.GetSetting("system", "in_dir")
            indir = get_current_dir() & "./FINAL DATA" & "/TEMPERAture"
            'outdir = ini.GetSetting("system", "out_dir")
            outdir = get_current_dir() & "./FINAL DATA"

            show_ts()
            txtQR.Focus()
        Catch ex As Exception
            MsgBox("form loading")
            MsgBox(ex.Message)
        End Try



    End Sub

    Sub bye()
        Try
            ini = Nothing
            LOG.close()
            tcp.Close()
            SP1.Close()

        Catch ex As Exception
            MsgBox("bye")
            MsgBox(ex.Message)
        End Try

    End Sub



    Private Sub 打开工作目录ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开工作目录ToolStripMenuItem.Click
        Process.Start("explorer.exe ", get_current_dir())
    End Sub



    Public Function get_current_dir() As String
        Dim curDir As String

        curDir = My.Application.Info.DirectoryPath

        Return curDir
        'path最后没有\
    End Function

    Private Sub 关于AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 关于AToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub SP1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SP1.DataReceived
        Me.Invoke(New EventHandler(AddressOf callbackSerialPortDataReceived1), Nothing) '同步委托
    End Sub



    Private Sub callbackSerialPortDataReceived1(ByVal sender As Object, ByVal e As EventArgs)

        Dim _data As String = ""
        Static _data16(128) As Byte
        Dim index As Integer = 0
        Dim CNT As Integer = 0

        Do While True
            Thread.Sleep(30)
            If SP1.BytesToRead > 0 Then
                CNT = SP1.BytesToRead
                SP1.Read(_data16, index, SP1.BytesToRead)
                index = index + CNT
            Else
                Exit Do
            End If
        Loop

        showlog("接受消息:")
        showlog(show_hex_txt(_data16))

        Dim qr As String
        qr = Encoding.Default.GetString(_data16, 0, CNT)
        qr = qr.Replace(vbCrLf, "")
        do_QR(qr)

    End Sub

    Sub do_QR(qr As String)


        '[)>06P401909061T007192480024

        work_cnt += 1

        showlog("处理qr")
        showlog("qr=" & qr)
        txtQR.Text = qr

        If qr = qr1 Then
            Return
        Else
            qr1 = qr
        End If


        'Beep()
        '.......
        '读取数据
        '另存为...
        Dim ts() As String
        Try


            If InStr(qr, "T") > 0 Then
                ts = qr.Split("T")
                txtQR.Text = ts(1)
                qr = ts(1)
            End If

            qr = qr.Replace(vbCr, "")
            qr = qr.Replace(vbLf, "")
        Catch ex As Exception
            showlog(ex.Message)
        End Try





        Try
            Dim outfile As IO.StreamWriter = New IO.StreamWriter(outdir & "\" & fileOUT, True, Encoding.Default)

            Dim infile As IO.StreamReader = New IO.StreamReader(indir & "\" & fileIN, Encoding.Default)

            Do While infile.Peek() >= 0
                Dim t As String = ""
                t = infile.ReadLine()
                If Not t.StartsWith("日期时间") Then
                    outfile.WriteLine(qr & "," & t)
                End If

            Loop
            outfile.Close()
            infile.Close()
            show_ts()

        Catch ex As Exception
            MsgBox(ex.Message)


        End Try



    End Sub


    Sub showlog(ByVal info As String)


        If isLog Then
            LOG.Log(info)
        End If

        Try
            'T_INFO.Text = TimeOfDay() & "__" & info & vbCrLf & T_INFO.Text
            Me.t_info.Text = TimeOfDay() & ":" & str3(Now.Millisecond) & "__" & info & vbCrLf & t_info.Text


            t_info.SelectionStart = t_info.Text.Length - 1
            't_info.SelectionLength = 1
            'T_INFO.ScrollToCaret()
            If t_info.Text.Length > 200000 Then t_info.Text = ""
        Catch

        End Try
    End Sub

    Function str3(ByVal s As String) As String
        If s.Length < 3 Then
            Return Microsoft.VisualBasic.Left("000" & s, 3)
        Else
            Return s
        End If

    End Function


    Function show_hex_txt(ByVal ccs() As Byte) As String
        'hex和txt输出格式
        '现在时间：2018年5月1日02时00分14秒

        '16个hex   16个字符
        '00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F  |  ................  
        '10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F  |  ................  
        '20 21 22 23 24 25 26 27 28 29 2A 2B 2C 2D 2E 2F  |   !"#$%&'()*+,-./ 

        Dim temp As String = ""
        Dim lhex = ""         '每行的hex
        Dim ltxt = ""       '每行的txt
        Dim lall = ""
        Dim i = 0

        If ccs.Length = 0 Then
            Return Nothing
        End If

        temp = vbCrLf & "[Hex长度]=" & ccs.Length & "字节"
        temp = temp & vbCrLf & "__0__1__2__3__4__5__6__7__8__9__A__B__C__D__E__F | 0123456789ABCDEF"

        For Each cc As Byte In ccs
            If Hex(cc).Length = 2 Then
                lhex = lhex & " " & Hex(cc)
            Else
                lhex = lhex & " 0" & Hex(cc)
            End If


            If CInt(cc) < 32 Then
                ltxt = ltxt & "."
            ElseIf CInt(cc) > 126 Then
                ltxt = ltxt & "."
            Else
                ltxt = ltxt & Chr(cc)
            End If


            i = i + 1

            If (i = ccs.Length) Then

                Dim cnt = 0
                cnt = 16 - (i Mod 16)
                If cnt = 16 Then
                    lall = lhex & " | " & ltxt
                Else
                    lall = lhex & Space(3 * cnt) & " | " & ltxt
                End If
                temp = temp & vbCrLf & lall
                Exit For

            End If

            If (i Mod 16 = 0) Then
                lall = lhex & " | " & ltxt
                temp = temp & vbCrLf & lall
                lhex = ""
                lall = ""
                ltxt = ""

            End If


        Next

        Return temp

    End Function



    Function show_hex_txt(ByVal ccs() As Byte, ByVal lens As Integer) As String
        'hex和txt输出格式
        '现在时间：2018年5月1日02时00分14秒

        '16个hex   16个字符
        '00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F  |  ................  
        '10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F  |  ................  
        '20 21 22 23 24 25 26 27 28 29 2A 2B 2C 2D 2E 2F  |   !"#$%&'()*+,-./ 

        Dim temp As String = ""
        Dim lhex = ""         '每行的hex
        Dim ltxt = ""       '每行的txt
        Dim lall = ""
        Dim i = 0
        Dim ucl = 0

        If ccs.Length = 0 Then
            Return ""
        End If

        '设定上限
        If ccs.Length < lens Then
            ucl = ccs.Length
        Else
            ucl = lens
        End If

        temp = vbCrLf & "[Hex长度]=" & ccs.Length & "字节"
        temp = temp & vbCrLf & "__0__1__2__3__4__5__6__7__8__9__A__B__C__D__E__F | 0123456789ABCDEF"

        For Each cc As Byte In ccs
            If Hex(cc).Length = 2 Then
                lhex = lhex & " " & Hex(cc)
            Else
                lhex = lhex & " 0" & Hex(cc)
            End If


            If CInt(cc) < 32 Then
                ltxt = ltxt & "."
            ElseIf CInt(cc) > 126 Then
                ltxt = ltxt & "."
            Else
                ltxt = ltxt & Chr(cc)
            End If


            i = i + 1

            If (i = ucl) Then

                Dim cnt = 0
                cnt = 16 - (i Mod 16)
                If cnt = 16 Then
                    lall = lhex & " | " & ltxt
                Else
                    lall = lhex & Space(3 * cnt) & " | " & ltxt
                End If
                temp = temp & vbCrLf & lall
                lhex = ""
                lall = ""
                ltxt = ""
                Exit For

            End If



            If (i Mod 16 = 0) Then

                lall = lhex & " | " & ltxt
                temp = temp & vbCrLf & lall
                lhex = ""
                lall = ""
                ltxt = ""

            End If


        Next

        Return temp

    End Function

    Private Sub bt_plc_Click(sender As Object, e As EventArgs) Handles bt_plc.Click
        plc_tcp_reconnect()

    End Sub


    Sub plc_tcp_reconnect()

        tcp_plc_connect()
        do_tcp_read()
        If tcp.Connected Then
            invoke_showlog("tcp ok")

        End If
    End Sub

    Sub show_ts()

        'qr
        ts_qrport.Text = SP1.PortName
        If SP1.IsOpen Then
            ts_qrport.BackColor = Color.GreenYellow
            ts_qrport.ForeColor = Color.Black
        Else
            ts_qrport.BackColor = Color.Red
            ts_qrport.ForeColor = Color.White

        End If


        'plc
        If tcp.Connected Then
            ts_plc.BackColor = Color.GreenYellow
            ts_plc.ForeColor = Color.Black
            ts_plc.Text = "连接"
        Else
            ts_plc.BackColor = Color.Red
            ts_plc.ForeColor = Color.White
            ts_plc.Text = "断开"
        End If


        'work cnt
        ts_cnt.Text = work_cnt


    End Sub

    Sub SP1_OPEN()
        Try
            SP1.PortName = ini.GetSetting("system", "QR")
            'showlog("CDHolding=" & SP1.CDHolding)
            SP1.ReceivedBytesThreshold = 1
            SP1.BaudRate = ini.GetSetting("system", "speed")
            showlog(SP1.PortName & "...")
            SP1.Open()
            showlog("-->OPEN OK!")
            showlog("CDHolding=" & SP1.CDHolding)
        Catch ex As Exception
            showlog("发生错误=" & ex.Message)
            'showlog( " OPEN OK!")
        End Try


    End Sub

    Private Sub 工具ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 工具ToolStripMenuItem.Click

    End Sub

    Private Sub 串口发送测试ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 串口发送测试ToolStripMenuItem.Click
        sp_send_test()

    End Sub


    Sub sp_send_test()
        If Not SP1.IsOpen Then
            showlog("Err:com not open!")
            Return
        End If

        SP1.WriteLine(txtQR.Text)

    End Sub

    Private Sub bt_qr_Click(sender As Object, e As EventArgs)
        SP1.Close()
        SP1_OPEN()
        show_ts()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub PLC发送测试ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PLC发送测试ToolStripMenuItem.Click
        tcp_send_test()

    End Sub


    Sub tcp_send_test()
        'Dim stm As Sockets.NetworkStream = tcp.GetStream
        Dim bb() As Byte = Encoding.Default.GetBytes(txtQR.Text)
        showlog(show_hex_txt(bb))
        If tcp.Connected Then
            'stm.Write(bb, 0, bb.Length)
            tcp.Client.Send(bb)
            showlog("发送->" & txtQR.Text)
        Else
            showlog("tcp中断")
        End If
    End Sub


    Sub do_tcp_read()
        If Not tcp.Connected Then

            Return
        End If

        Dim stm As Sockets.NetworkStream = tcp.GetStream

        'If stm.DataAvailable Then
        'cnt = stm.Read(bb, 0, 8000)
        tcp_ret = stm.BeginRead(tcp_rev_buf, 0, tcp_rev_buf.Length, AddressOf tcp_when_receive, 0)
        'End If
    End Sub

    Sub clear_log()
        t_info.Clear()
    End Sub


    Sub tcp_when_receive(ByVal ar As IAsyncResult)
        Dim bytesRead As Integer = 0

        '本次tcp读取到的数据长度
        Try
            bytesRead = tcp.GetStream.EndRead(ar)

            invoke_showlog("长度:" & bytesRead)


            If bytesRead = 0 Then

                invoke_showlog("tcp.Client.Connected1-->" & tcp.Client.Connected)
                invoke_showlog("tcp.Connected1-->" & tcp.Connected)
                invoke_showlog("tcp.Client.Available1-->" & tcp.Client.Available)
                tcp.Close()

                invoke_showlog("对方tcp中断,请重连")
                plc_tcp_reconnect()
                Return
            End If

            showlog(show_hex_txt(tcp_rev_buf))

            Dim txt As String = Encoding.Default.GetString(tcp_rev_buf, 0, bytesRead)
            invoke_showlog("接收:" & txt)


            'tcp消息解析处理
            do_tcp_msg(txt)


            '循环继续回调,读取tcp进来消息
            do_tcp_read()


        Catch ex As Exception
            invoke_showlog("tcp_when_receive-->")
            invoke_showlog(ex.Message)

            Me.Invoke(New EventHandler(AddressOf timer_up))
        End Try
    End Sub

    Sub timer_up()
        Timer1.Start()
    End Sub


    Sub do_tcp_msg(txt As String)
        '#plc发送0001    启动扫码
        '        read = 1

        '#plc发送0002    扫码成功
        '        Hide = 2

        '#plc接收      0003    扫码失败

        If txt.IndexOf(cmdQRread) > 0 Then
            Me.Invoke(New EventHandler(AddressOf me_show))
        End If
        If txt.IndexOf(cmdQRbad) > 0 Then
            Me.Invoke(New EventHandler(AddressOf me_re_show))
        End If

        If txt.IndexOf(cmdQRHide) > 0 Then
            Me.Invoke(New EventHandler(AddressOf me_hide))
        End If

        If txt = "read" Then
            Me.Invoke(New EventHandler(AddressOf me_show))
        End If

        If txt = "hide" Then
            Me.Invoke(New EventHandler(AddressOf me_hide))
        End If
    End Sub

    Sub showlog1(ByVal sender As Object, ByVal info As obj_EventArgs)
        showlog(info.info)
        show_ts()
    End Sub



    Sub me_hide()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Sub me_show()
        Me.txtQR.Text = "新测试,请扫二维码!"
        Me.WindowState = FormWindowState.Normal
    End Sub

    Sub me_re_show()
        Me.txtQR.Text = "QR识别失败,请重新扫码!"
        Me.WindowState = FormWindowState.Normal
    End Sub


    Sub invoke_showlog(ByVal info As String)
        Me.Invoke(New EventHandler(AddressOf showlog1), New Object() {Me, New obj_EventArgs(0, info)})
    End Sub

    Private Sub DoRead(ByVal ar As IAsyncResult)
        'Dim bytesRead As Integer
        'Dim strMessage As String
        'Dim readBuffer() As Byte
        'Try
        '    bytesRead = client.GetStream.EndRead(ar)
        '    If bytesRead < 1 Then
        '        MessageBox.Show("Disconnected!")
        '        Exit Sub
        '    End If
        '    strMessage = Encoding.Default.GetString(bytes, 0, bytesRead - 1)
        '    invoke_showlog(strMessage)

        '    '继续委托
        '    client.GetStream.BeginRead(bytes, 0, 255, New AsyncCallback(AddressOf DoRead), Nothing)

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try


    End Sub

    Private Sub 清除运行日志ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清除运行日志ToolStripMenuItem.Click
        clear_log()
    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        showlog(Me.Handle)
        showlog(tcp.Client.Handle)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        plc_tcp_reconnect()
        invoke_showlog("PLC reconnect!")
        If tcp.Connected Then
            Timer1.Stop()
        End If
    End Sub

    Private Sub ToolStripStatusLabel7_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel7.Click

    End Sub

    Private Sub 打开原数据目录ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开原数据目录ToolStripMenuItem.Click
        Process.Start("explorer.exe ", indir)
    End Sub

    Private Sub 打开新数据目录ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开新数据目录ToolStripMenuItem.Click
        Process.Start("explorer.exe ", outdir)
    End Sub

    Private Sub 打开转存目录ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开转存目录ToolStripMenuItem.Click

    End Sub

    Private Sub Ts_runtime_Click(sender As Object, e As EventArgs) Handles ts_runtime.Click

    End Sub
End Class



Public Class obj_EventArgs
    '串口的事件参数定义,
    Inherits EventArgs
    'Public sender As Object
    Public id As Integer
    Public info As String
    'Public col As Color

    Sub New(ByVal id0 As Integer, ByVal info0 As String)
        id = id0
        info = info0
        'col = col0
    End Sub

End Class 'FireEventArgs
