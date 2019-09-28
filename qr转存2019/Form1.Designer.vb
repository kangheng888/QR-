<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件FToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出XToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.工具ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开工作目录ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开日志文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开转存目录ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.串口发送测试ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PLC发送测试ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.清除运行日志ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.打开原数据目录ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开新数据目录ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.帮助HToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关于AToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtQR = New System.Windows.Forms.TextBox()
        Me.t_info = New System.Windows.Forms.TextBox()
        Me.bt_plc = New System.Windows.Forms.Button()
        Me.bt_hide = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts_qrport = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts_plc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts_cnt = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel9 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel10 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ts_runtime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.bt_qr = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SP1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件FToolStripMenuItem, Me.工具ToolStripMenuItem, Me.帮助HToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(580, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件FToolStripMenuItem
        '
        Me.文件FToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.退出XToolStripMenuItem})
        Me.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem"
        Me.文件FToolStripMenuItem.Size = New System.Drawing.Size(58, 22)
        Me.文件FToolStripMenuItem.Text = "文件(&F)"
        '
        '退出XToolStripMenuItem
        '
        Me.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem"
        Me.退出XToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.退出XToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.退出XToolStripMenuItem.Text = "退出(&X)"
        '
        '工具ToolStripMenuItem
        '
        Me.工具ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开工作目录ToolStripMenuItem, Me.打开日志文件ToolStripMenuItem, Me.打开转存目录ToolStripMenuItem, Me.ToolStripSeparator1, Me.串口发送测试ToolStripMenuItem, Me.PLC发送测试ToolStripMenuItem, Me.清除运行日志ToolStripMenuItem, Me.TestToolStripMenuItem, Me.ToolStripMenuItem1, Me.打开原数据目录ToolStripMenuItem, Me.打开新数据目录ToolStripMenuItem})
        Me.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem"
        Me.工具ToolStripMenuItem.Size = New System.Drawing.Size(59, 22)
        Me.工具ToolStripMenuItem.Text = "工具(&T)"
        '
        '打开工作目录ToolStripMenuItem
        '
        Me.打开工作目录ToolStripMenuItem.Name = "打开工作目录ToolStripMenuItem"
        Me.打开工作目录ToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.打开工作目录ToolStripMenuItem.Text = "打开工作目录"
        '
        '打开日志文件ToolStripMenuItem
        '
        Me.打开日志文件ToolStripMenuItem.Name = "打开日志文件ToolStripMenuItem"
        Me.打开日志文件ToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.打开日志文件ToolStripMenuItem.Text = "打开日志文件"
        '
        '打开转存目录ToolStripMenuItem
        '
        Me.打开转存目录ToolStripMenuItem.Name = "打开转存目录ToolStripMenuItem"
        Me.打开转存目录ToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.打开转存目录ToolStripMenuItem.Text = "打开转存目录"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(166, 6)
        '
        '串口发送测试ToolStripMenuItem
        '
        Me.串口发送测试ToolStripMenuItem.Name = "串口发送测试ToolStripMenuItem"
        Me.串口发送测试ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.串口发送测试ToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.串口发送测试ToolStripMenuItem.Text = "串口发送测试"
        '
        'PLC发送测试ToolStripMenuItem
        '
        Me.PLC发送测试ToolStripMenuItem.Name = "PLC发送测试ToolStripMenuItem"
        Me.PLC发送测试ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.PLC发送测试ToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.PLC发送测试ToolStripMenuItem.Text = "PLC发送测试"
        '
        '清除运行日志ToolStripMenuItem
        '
        Me.清除运行日志ToolStripMenuItem.Name = "清除运行日志ToolStripMenuItem"
        Me.清除运行日志ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.清除运行日志ToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.清除运行日志ToolStripMenuItem.Text = "清除运行日志"
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.TestToolStripMenuItem.Text = "test"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(166, 6)
        '
        '打开原数据目录ToolStripMenuItem
        '
        Me.打开原数据目录ToolStripMenuItem.Name = "打开原数据目录ToolStripMenuItem"
        Me.打开原数据目录ToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.打开原数据目录ToolStripMenuItem.Text = "打开原数据目录"
        '
        '打开新数据目录ToolStripMenuItem
        '
        Me.打开新数据目录ToolStripMenuItem.Name = "打开新数据目录ToolStripMenuItem"
        Me.打开新数据目录ToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.打开新数据目录ToolStripMenuItem.Text = "打开新数据目录"
        '
        '帮助HToolStripMenuItem
        '
        Me.帮助HToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.关于AToolStripMenuItem})
        Me.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem"
        Me.帮助HToolStripMenuItem.Size = New System.Drawing.Size(61, 22)
        Me.帮助HToolStripMenuItem.Text = "帮助(&H)"
        '
        '关于AToolStripMenuItem
        '
        Me.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem"
        Me.关于AToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.关于AToolStripMenuItem.Text = "关于...(&A)"
        '
        'txtQR
        '
        Me.txtQR.Font = New System.Drawing.Font("微软雅黑", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtQR.ForeColor = System.Drawing.Color.Blue
        Me.txtQR.Location = New System.Drawing.Point(287, 24)
        Me.txtQR.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtQR.Name = "txtQR"
        Me.txtQR.Size = New System.Drawing.Size(263, 36)
        Me.txtQR.TabIndex = 2
        Me.txtQR.Text = "请二维码扫码。。。"
        '
        't_info
        '
        Me.t_info.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.t_info.Location = New System.Drawing.Point(5, 19)
        Me.t_info.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.t_info.Multiline = True
        Me.t_info.Name = "t_info"
        Me.t_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.t_info.Size = New System.Drawing.Size(554, 247)
        Me.t_info.TabIndex = 2
        '
        'bt_plc
        '
        Me.bt_plc.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.bt_plc.Location = New System.Drawing.Point(17, 29)
        Me.bt_plc.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.bt_plc.Name = "bt_plc"
        Me.bt_plc.Size = New System.Drawing.Size(79, 28)
        Me.bt_plc.TabIndex = 3
        Me.bt_plc.Text = "PLC重连"
        Me.bt_plc.UseVisualStyleBackColor = True
        '
        'bt_hide
        '
        Me.bt_hide.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.bt_hide.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.bt_hide.Location = New System.Drawing.Point(197, 29)
        Me.bt_hide.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.bt_hide.Name = "bt_hide"
        Me.bt_hide.Size = New System.Drawing.Size(56, 28)
        Me.bt_hide.TabIndex = 3
        Me.bt_hide.Text = "隐藏"
        Me.bt_hide.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ts_qrport, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ts_plc, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel7, Me.ts_cnt, Me.ToolStripStatusLabel9, Me.ToolStripStatusLabel10, Me.ts_runtime})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 399)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 11, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(580, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(80, 17)
        Me.ToolStripStatusLabel1.Text = "扫码枪端口："
        '
        'ts_qrport
        '
        Me.ts_qrport.BackColor = System.Drawing.Color.Lime
        Me.ts_qrport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ts_qrport.Name = "ts_qrport"
        Me.ts_qrport.Size = New System.Drawing.Size(45, 17)
        Me.ts_qrport.Text = "COM1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(11, 17)
        Me.ToolStripStatusLabel3.Text = "|"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(89, 17)
        Me.ToolStripStatusLabel4.Text = "PLC通讯端口："
        '
        'ts_plc
        '
        Me.ts_plc.BackColor = System.Drawing.Color.Red
        Me.ts_plc.ForeColor = System.Drawing.Color.White
        Me.ts_plc.Name = "ts_plc"
        Me.ts_plc.Size = New System.Drawing.Size(32, 17)
        Me.ts_plc.Text = "断开"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(11, 17)
        Me.ToolStripStatusLabel6.Text = "|"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel7.Text = "转存次数："
        '
        'ts_cnt
        '
        Me.ts_cnt.Name = "ts_cnt"
        Me.ts_cnt.Size = New System.Drawing.Size(15, 17)
        Me.ts_cnt.Text = "0"
        '
        'ToolStripStatusLabel9
        '
        Me.ToolStripStatusLabel9.Name = "ToolStripStatusLabel9"
        Me.ToolStripStatusLabel9.Size = New System.Drawing.Size(11, 17)
        Me.ToolStripStatusLabel9.Text = "|"
        '
        'ToolStripStatusLabel10
        '
        Me.ToolStripStatusLabel10.Name = "ToolStripStatusLabel10"
        Me.ToolStripStatusLabel10.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel10.Text = "启动时间："
        '
        'ts_runtime
        '
        Me.ts_runtime.Name = "ts_runtime"
        Me.ts_runtime.Size = New System.Drawing.Size(62, 17)
        Me.ts_runtime.Text = "9-10 3:45"
        '
        'bt_qr
        '
        Me.bt_qr.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.bt_qr.Location = New System.Drawing.Point(100, 29)
        Me.bt_qr.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.bt_qr.Name = "bt_qr"
        Me.bt_qr.Size = New System.Drawing.Size(93, 28)
        Me.bt_qr.TabIndex = 3
        Me.bt_qr.Text = "扫码枪重连"
        Me.bt_qr.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.t_info)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 108)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(562, 277)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "运行日志"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtQR)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.bt_hide)
        Me.GroupBox2.Controls.Add(Me.bt_qr)
        Me.GroupBox2.Controls.Add(Me.bt_plc)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 36)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GroupBox2.Size = New System.Drawing.Size(562, 67)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "功能 "
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(457, 0)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(84, 16)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "开机自启动"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'SP1
        '
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 421)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "Form1"
        Me.Text = "二维码扫码转存"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 文件FToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 退出XToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtQR As TextBox
    Friend WithEvents t_info As TextBox
    Friend WithEvents bt_plc As Button
    Friend WithEvents bt_hide As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ts_qrport As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ts_plc As ToolStripStatusLabel
    Friend WithEvents bt_qr As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ToolStripStatusLabel6 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As ToolStripStatusLabel
    Friend WithEvents ts_cnt As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel9 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel10 As ToolStripStatusLabel
    Friend WithEvents ts_runtime As ToolStripStatusLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents 工具ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 打开工作目录ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 打开日志文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 打开转存目录ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents 帮助HToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 关于AToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SP1 As IO.Ports.SerialPort
    Friend WithEvents 串口发送测试ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PLC发送测试ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 清除运行日志ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents 打开原数据目录ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 打开新数据目录ToolStripMenuItem As ToolStripMenuItem
End Class
