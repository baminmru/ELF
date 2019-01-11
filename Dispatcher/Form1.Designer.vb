<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Form1
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents Text3 As System.Windows.Forms.TextBox
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.Text3 = New System.Windows.Forms.TextBox
        Me.ButtonConnect = New System.Windows.Forms.Button
        Me.ButtonClear = New System.Windows.Forms.Button
        Me.ButtonReadArch = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ComboBoxArchType = New System.Windows.Forms.ComboBox
        Me.TextBoxAcrhHour = New System.Windows.Forms.TextBox
        Me.TextBoxAcrhDay = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Labell = New System.Windows.Forms.Label
        Me.TextBoxArchMonth = New System.Windows.Forms.TextBox
        Me.TextBoxArchYear = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.cmdNPort = New System.Windows.Forms.Button
        Me.Frame2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.Text3)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(12, 103)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(433, 316)
        Me.Frame2.TabIndex = 1
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Протокол"
        '
        'Text3
        '
        Me.Text3.AcceptsReturn = True
        Me.Text3.BackColor = System.Drawing.SystemColors.Window
        Me.Text3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text3.Location = New System.Drawing.Point(6, 18)
        Me.Text3.MaxLength = 0
        Me.Text3.Multiline = True
        Me.Text3.Name = "Text3"
        Me.Text3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Text3.Size = New System.Drawing.Size(416, 276)
        Me.Text3.TabIndex = 14
        '
        'ButtonConnect
        '
        Me.ButtonConnect.Location = New System.Drawing.Point(465, 48)
        Me.ButtonConnect.Name = "ButtonConnect"
        Me.ButtonConnect.Size = New System.Drawing.Size(195, 24)
        Me.ButtonConnect.TabIndex = 19
        Me.ButtonConnect.Text = "Соединение с ТВ"
        Me.ButtonConnect.UseVisualStyleBackColor = True
        '
        'ButtonClear
        '
        Me.ButtonClear.Location = New System.Drawing.Point(464, 347)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(195, 24)
        Me.ButtonClear.TabIndex = 24
        Me.ButtonClear.Text = "Очистка протокола"
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'ButtonReadArch
        '
        Me.ButtonReadArch.Location = New System.Drawing.Point(464, 202)
        Me.ButtonReadArch.Name = "ButtonReadArch"
        Me.ButtonReadArch.Size = New System.Drawing.Size(195, 24)
        Me.ButtonReadArch.TabIndex = 30
        Me.ButtonReadArch.Text = "Получить архив"
        Me.ButtonReadArch.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ComboBoxArchType)
        Me.GroupBox3.Controls.Add(Me.TextBoxAcrhHour)
        Me.GroupBox3.Controls.Add(Me.TextBoxAcrhDay)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Labell)
        Me.GroupBox3.Controls.Add(Me.TextBoxArchMonth)
        Me.GroupBox3.Controls.Add(Me.TextBoxArchYear)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 18)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(433, 79)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Чтение Архива"
        '
        'ComboBoxArchType
        '
        Me.ComboBoxArchType.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxArchType.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboBoxArchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxArchType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBoxArchType.Location = New System.Drawing.Point(320, 17)
        Me.ComboBoxArchType.Name = "ComboBoxArchType"
        Me.ComboBoxArchType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComboBoxArchType.Size = New System.Drawing.Size(102, 21)
        Me.ComboBoxArchType.TabIndex = 30
        '
        'TextBoxAcrhHour
        '
        Me.TextBoxAcrhHour.Location = New System.Drawing.Point(211, 46)
        Me.TextBoxAcrhHour.Name = "TextBoxAcrhHour"
        Me.TextBoxAcrhHour.Size = New System.Drawing.Size(62, 20)
        Me.TextBoxAcrhHour.TabIndex = 27
        Me.TextBoxAcrhHour.Text = "1"
        '
        'TextBoxAcrhDay
        '
        Me.TextBoxAcrhDay.Location = New System.Drawing.Point(211, 18)
        Me.TextBoxAcrhDay.Name = "TextBoxAcrhDay"
        Me.TextBoxAcrhDay.Size = New System.Drawing.Size(62, 20)
        Me.TextBoxAcrhDay.TabIndex = 26
        Me.TextBoxAcrhDay.Text = "1"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(163, 49)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(27, 13)
        Me.Label20.TabIndex = 25
        Me.Label20.Text = "Час"
        '
        'Labell
        '
        Me.Labell.AutoSize = True
        Me.Labell.Location = New System.Drawing.Point(163, 21)
        Me.Labell.Name = "Labell"
        Me.Labell.Size = New System.Drawing.Size(34, 13)
        Me.Labell.TabIndex = 24
        Me.Labell.Text = "День"
        '
        'TextBoxArchMonth
        '
        Me.TextBoxArchMonth.Location = New System.Drawing.Point(64, 46)
        Me.TextBoxArchMonth.Name = "TextBoxArchMonth"
        Me.TextBoxArchMonth.Size = New System.Drawing.Size(62, 20)
        Me.TextBoxArchMonth.TabIndex = 23
        Me.TextBoxArchMonth.Text = "1"
        '
        'TextBoxArchYear
        '
        Me.TextBoxArchYear.Location = New System.Drawing.Point(64, 18)
        Me.TextBoxArchYear.Name = "TextBoxArchYear"
        Me.TextBoxArchYear.Size = New System.Drawing.Size(62, 20)
        Me.TextBoxArchYear.TabIndex = 22
        Me.TextBoxArchYear.Text = "2007"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(16, 49)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 13)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Месяц"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(16, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(25, 13)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Год"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(464, 318)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(195, 24)
        Me.Button5.TabIndex = 36
        Me.Button5.Text = "Мгновенные архивы"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(464, 260)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(195, 24)
        Me.Button7.TabIndex = 38
        Me.Button7.Text = "Часовые за сутки"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(464, 231)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(195, 24)
        Me.Button8.TabIndex = 39
        Me.Button8.Text = "Суточные за месяц"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(464, 289)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(195, 24)
        Me.Button9.TabIndex = 40
        Me.Button9.Text = "Итоговые архивы"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'cmdNPort
        '
        Me.cmdNPort.Location = New System.Drawing.Point(464, 18)
        Me.cmdNPort.Name = "cmdNPort"
        Me.cmdNPort.Size = New System.Drawing.Size(195, 24)
        Me.cmdNPort.TabIndex = 43
        Me.cmdNPort.Text = "Connect"
        Me.cmdNPort.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(672, 427)
        Me.Controls.Add(Me.cmdNPort)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.ButtonReadArch)
        Me.Controls.Add(Me.ButtonClear)
        Me.Controls.Add(Me.ButtonConnect)
        Me.Controls.Add(Me.Frame2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(4, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Тест работы с устройством"
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonConnect As System.Windows.Forms.Button
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents ButtonReadArch As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxAcrhHour As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAcrhDay As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Labell As System.Windows.Forms.Label
    Friend WithEvents TextBoxArchMonth As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxArchYear As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents ComboBoxArchType As System.Windows.Forms.ComboBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents cmdNPort As System.Windows.Forms.Button
#End Region
End Class