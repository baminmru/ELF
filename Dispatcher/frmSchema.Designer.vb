﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSchema
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim UltraToolTipInfo3 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Выбор показателей для отображения на схеме", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Размещение показателей на схеме", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Задать граничные значения показателей", Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
        Me.picSchema = New System.Windows.Forms.PictureBox
        Me.cmdParams = New Infragistics.Win.Misc.UltraButton
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.cmdSetup = New Infragistics.Win.Misc.UltraButton
        Me.cmdValues = New Infragistics.Win.Misc.UltraButton
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.chkMoment = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.chkHour = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.chkDay = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.chkITog = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        CType(Me.picSchema, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'picSchema
        '
        Me.picSchema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSchema.Location = New System.Drawing.Point(12, 5)
        Me.picSchema.Name = "picSchema"
        Me.picSchema.Size = New System.Drawing.Size(630, 500)
        Me.picSchema.TabIndex = 1
        Me.picSchema.TabStop = False
        '
        'cmdParams
        '
        Me.cmdParams.Location = New System.Drawing.Point(6, 19)
        Me.cmdParams.Name = "cmdParams"
        Me.cmdParams.Size = New System.Drawing.Size(148, 27)
        Me.cmdParams.TabIndex = 6
        Me.cmdParams.Text = "Выбор показателей"
        UltraToolTipInfo3.ToolTipText = "Выбор показателей для отображения на схеме"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.cmdParams, UltraToolTipInfo3)
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        '
        'cmdSetup
        '
        Me.cmdSetup.Location = New System.Drawing.Point(6, 52)
        Me.cmdSetup.Name = "cmdSetup"
        Me.cmdSetup.Size = New System.Drawing.Size(148, 27)
        Me.cmdSetup.TabIndex = 7
        Me.cmdSetup.Text = "Рамещение показателей"
        UltraToolTipInfo2.ToolTipText = "Размещение показателей на схеме"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.cmdSetup, UltraToolTipInfo2)
        '
        'cmdValues
        '
        Me.cmdValues.Location = New System.Drawing.Point(6, 22)
        Me.cmdValues.Name = "cmdValues"
        Me.cmdValues.Size = New System.Drawing.Size(148, 28)
        Me.cmdValues.TabIndex = 11
        Me.cmdValues.Text = "Граничные значения"
        UltraToolTipInfo1.ToolTipText = "Задать граничные значения показателей"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.cmdValues, UltraToolTipInfo1)
        '
        'Timer1
        '
        Me.Timer1.Interval = 59000
        '
        'chkMoment
        '
        Me.chkMoment.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3DOldStyle
        Me.chkMoment.Checked = True
        Me.chkMoment.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMoment.Location = New System.Drawing.Point(648, 5)
        Me.chkMoment.Name = "chkMoment"
        Me.chkMoment.Size = New System.Drawing.Size(148, 29)
        Me.chkMoment.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkMoment.TabIndex = 8
        Me.chkMoment.Text = "Мгновенные"
        '
        'chkHour
        '
        Me.chkHour.Location = New System.Drawing.Point(648, 40)
        Me.chkHour.Name = "chkHour"
        Me.chkHour.Size = New System.Drawing.Size(148, 29)
        Me.chkHour.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkHour.TabIndex = 9
        Me.chkHour.Text = "Часовые"
        '
        'chkDay
        '
        Me.chkDay.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3DOldStyle
        Me.chkDay.Location = New System.Drawing.Point(648, 75)
        Me.chkDay.Name = "chkDay"
        Me.chkDay.Size = New System.Drawing.Size(148, 29)
        Me.chkDay.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkDay.TabIndex = 10
        Me.chkDay.Text = "Суточные"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdSetup)
        Me.GroupBox1.Controls.Add(Me.cmdParams)
        Me.GroupBox1.Location = New System.Drawing.Point(648, 234)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(165, 86)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Настройка схемы"
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.cmdValues)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(648, 150)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(165, 63)
        Me.UltraGroupBox1.TabIndex = 14
        Me.UltraGroupBox1.Text = "Настройка узла"
        '
        'chkITog
        '
        Me.chkITog.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3DOldStyle
        Me.chkITog.Location = New System.Drawing.Point(648, 110)
        Me.chkITog.Name = "chkITog"
        Me.chkITog.Size = New System.Drawing.Size(148, 29)
        Me.chkITog.Style = Infragistics.Win.EditCheckStyle.Button
        Me.chkITog.TabIndex = 15
        Me.chkITog.Text = "Итоговые"
        '
        'frmSchema
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(869, 464)
        Me.Controls.Add(Me.chkITog)
        Me.Controls.Add(Me.UltraGroupBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkDay)
        Me.Controls.Add(Me.chkHour)
        Me.Controls.Add(Me.chkMoment)
        Me.Controls.Add(Me.picSchema)
        Me.Name = "frmSchema"
        Me.Text = "Схема подключения"
        CType(Me.picSchema, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picSchema As System.Windows.Forms.PictureBox
    Friend WithEvents cmdParams As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmdSetup As Infragistics.Win.Misc.UltraButton
    Friend WithEvents chkMoment As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkDay As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents chkHour As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents cmdValues As Infragistics.Win.Misc.UltraButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chkITog As Infragistics.Win.UltraWinEditors.UltraCheckEditor

End Class
