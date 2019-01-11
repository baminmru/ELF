
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Электроэнергия режим:main
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLC_Emain
    Inherits System.Windows.Forms.UserControl
    Implements LATIR2GUIManager.IRowEditor

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
    private mOnInit as boolean = false
    private mChanged as boolean = false
    public event Changed() Implements LATIR2GUIManager.IRowEditor.Changed 
    Public Event Saved() Implements LATIR2GUIManager.IRowEditor.Saved
    Public Event Refreshed() Implements LATIR2GUIManager.IRowEditor.Refreshed
    Public Sub Changing()
      if not mOnInit then
        mChanged = true
        raiseevent Changed()
      end if
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose (disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

 Dim iii As Integer
    Friend WithEvents HolderPanel As LATIR2GUIControls.AutoPanel
Friend WithEvents lblDCALL  as  System.Windows.Forms.Label
Friend WithEvents dtpDCALL As System.Windows.Forms.DateTimePicker
Friend WithEvents lblDCOUNTER  as  System.Windows.Forms.Label
Friend WithEvents dtpDCOUNTER As System.Windows.Forms.DateTimePicker
Friend WithEvents lblE0  as  System.Windows.Forms.Label
Friend WithEvents txtE0 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblE1  as  System.Windows.Forms.Label
Friend WithEvents txtE1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblE2  as  System.Windows.Forms.Label
Friend WithEvents txtE2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblE3  as  System.Windows.Forms.Label
Friend WithEvents txtE3 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblE4  as  System.Windows.Forms.Label
Friend WithEvents txtE4 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblE0S  as  System.Windows.Forms.Label
Friend WithEvents txtE0S As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblE1S  as  System.Windows.Forms.Label
Friend WithEvents txtE1S As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblE2S  as  System.Windows.Forms.Label
Friend WithEvents txtE2S As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblE3S  as  System.Windows.Forms.Label
Friend WithEvents txtE3S As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblE4S  as  System.Windows.Forms.Label
Friend WithEvents txtE4S As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblAP  as  System.Windows.Forms.Label
Friend WithEvents txtAP As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblAM  as  System.Windows.Forms.Label
Friend WithEvents txtAM As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblRP  as  System.Windows.Forms.Label
Friend WithEvents txtRP As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblRM  as  System.Windows.Forms.Label
Friend WithEvents txtRM As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblI1  as  System.Windows.Forms.Label
Friend WithEvents txtI1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblI2  as  System.Windows.Forms.Label
Friend WithEvents txtI2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblI3  as  System.Windows.Forms.Label
Friend WithEvents txtI3 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblU1  as  System.Windows.Forms.Label
Friend WithEvents txtU1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblU2  as  System.Windows.Forms.Label
Friend WithEvents txtU2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblU3  as  System.Windows.Forms.Label
Friend WithEvents txtU3 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblOKTIME  as  System.Windows.Forms.Label
Friend WithEvents txtOKTIME As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblWORKTIME  as  System.Windows.Forms.Label
Friend WithEvents txtWORKTIME As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblerrInfo  as  System.Windows.Forms.Label
Friend WithEvents txterrInfo As LATIR2GuiManager.TouchTextBox

<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

 Me.HolderPanel = New LATIR2GUIControls.AutoPanel
 Me.HolderPanel.SuspendLayout()
Me.SuspendLayout()
 '
'HolderPanel
'
Me.HolderPanel.AllowDrop = True
Me.HolderPanel.BackColor = System.Drawing.SystemColors.Control
Me.HolderPanel.Dock = System.Windows.Forms.DockStyle.Fill
Me.HolderPanel.Location = New System.Drawing.Point(0, 0)
Me.HolderPanel.Name = "HolderPanel"
Me.HolderPanel.Size = New System.Drawing.Size(232, 120)
Me.HolderPanel.TabIndex = 0
Me.lblDCALL = New System.Windows.Forms.Label
Me.dtpDCALL = New System.Windows.Forms.DateTimePicker
Me.lblDCOUNTER = New System.Windows.Forms.Label
Me.dtpDCOUNTER = New System.Windows.Forms.DateTimePicker
Me.lblE0 = New System.Windows.Forms.Label
Me.txtE0 = New LATIR2GuiManager.TouchTextBox
Me.lblE1 = New System.Windows.Forms.Label
Me.txtE1 = New LATIR2GuiManager.TouchTextBox
Me.lblE2 = New System.Windows.Forms.Label
Me.txtE2 = New LATIR2GuiManager.TouchTextBox
Me.lblE3 = New System.Windows.Forms.Label
Me.txtE3 = New LATIR2GuiManager.TouchTextBox
Me.lblE4 = New System.Windows.Forms.Label
Me.txtE4 = New LATIR2GuiManager.TouchTextBox
Me.lblE0S = New System.Windows.Forms.Label
Me.txtE0S = New LATIR2GuiManager.TouchTextBox
Me.lblE1S = New System.Windows.Forms.Label
Me.txtE1S = New LATIR2GuiManager.TouchTextBox
Me.lblE2S = New System.Windows.Forms.Label
Me.txtE2S = New LATIR2GuiManager.TouchTextBox
Me.lblE3S = New System.Windows.Forms.Label
Me.txtE3S = New LATIR2GuiManager.TouchTextBox
Me.lblE4S = New System.Windows.Forms.Label
Me.txtE4S = New LATIR2GuiManager.TouchTextBox
Me.lblAP = New System.Windows.Forms.Label
Me.txtAP = New LATIR2GuiManager.TouchTextBox
Me.lblAM = New System.Windows.Forms.Label
Me.txtAM = New LATIR2GuiManager.TouchTextBox
Me.lblRP = New System.Windows.Forms.Label
Me.txtRP = New LATIR2GuiManager.TouchTextBox
Me.lblRM = New System.Windows.Forms.Label
Me.txtRM = New LATIR2GuiManager.TouchTextBox
Me.lblI1 = New System.Windows.Forms.Label
Me.txtI1 = New LATIR2GuiManager.TouchTextBox
Me.lblI2 = New System.Windows.Forms.Label
Me.txtI2 = New LATIR2GuiManager.TouchTextBox
Me.lblI3 = New System.Windows.Forms.Label
Me.txtI3 = New LATIR2GuiManager.TouchTextBox
Me.lblU1 = New System.Windows.Forms.Label
Me.txtU1 = New LATIR2GuiManager.TouchTextBox
Me.lblU2 = New System.Windows.Forms.Label
Me.txtU2 = New LATIR2GuiManager.TouchTextBox
Me.lblU3 = New System.Windows.Forms.Label
Me.txtU3 = New LATIR2GuiManager.TouchTextBox
Me.lblOKTIME = New System.Windows.Forms.Label
Me.txtOKTIME = New LATIR2GuiManager.TouchTextBox
Me.lblWORKTIME = New System.Windows.Forms.Label
Me.txtWORKTIME = New LATIR2GuiManager.TouchTextBox
Me.lblerrInfo = New System.Windows.Forms.Label
Me.txterrInfo = New LATIR2GuiManager.TouchTextBox

Me.lblDCALL.Location = New System.Drawing.Point(20,5)
Me.lblDCALL.name = "lblDCALL"
Me.lblDCALL.Size = New System.Drawing.Size(200, 20)
Me.lblDCALL.TabIndex = 1
Me.lblDCALL.Text = "Дата опроса"
Me.lblDCALL.ForeColor = System.Drawing.Color.Blue
Me.dtpDCALL.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpDCALL.Location = New System.Drawing.Point(20,27)
Me.dtpDCALL.name = "dtpDCALL"
Me.dtpDCALL.Size = New System.Drawing.Size(200,  20)
Me.dtpDCALL.TabIndex =2
Me.dtpDCALL.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpDCALL.ShowCheckBox=True
Me.lblDCOUNTER.Location = New System.Drawing.Point(20,52)
Me.lblDCOUNTER.name = "lblDCOUNTER"
Me.lblDCOUNTER.Size = New System.Drawing.Size(200, 20)
Me.lblDCOUNTER.TabIndex = 3
Me.lblDCOUNTER.Text = "Дата счетчика"
Me.lblDCOUNTER.ForeColor = System.Drawing.Color.Blue
Me.dtpDCOUNTER.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpDCOUNTER.Location = New System.Drawing.Point(20,74)
Me.dtpDCOUNTER.name = "dtpDCOUNTER"
Me.dtpDCOUNTER.Size = New System.Drawing.Size(200,  20)
Me.dtpDCOUNTER.TabIndex =4
Me.dtpDCOUNTER.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpDCOUNTER.ShowCheckBox=True
Me.lblE0.Location = New System.Drawing.Point(20,99)
Me.lblE0.name = "lblE0"
Me.lblE0.Size = New System.Drawing.Size(200, 20)
Me.lblE0.TabIndex = 5
Me.lblE0.Text = "Энергия общ."
Me.lblE0.ForeColor = System.Drawing.Color.Blue
Me.txtE0.Location = New System.Drawing.Point(20,121)
Me.txtE0.name = "txtE0"
Me.txtE0.MultiLine = false
Me.txtE0.Size = New System.Drawing.Size(200,  20)
Me.txtE0.TabIndex = 6
Me.txtE0.Text = "" 
Me.txtE0.MaxLength = 27
Me.lblE1.Location = New System.Drawing.Point(20,146)
Me.lblE1.name = "lblE1"
Me.lblE1.Size = New System.Drawing.Size(200, 20)
Me.lblE1.TabIndex = 7
Me.lblE1.Text = "Энергия тариф 1"
Me.lblE1.ForeColor = System.Drawing.Color.Blue
Me.txtE1.Location = New System.Drawing.Point(20,168)
Me.txtE1.name = "txtE1"
Me.txtE1.MultiLine = false
Me.txtE1.Size = New System.Drawing.Size(200,  20)
Me.txtE1.TabIndex = 8
Me.txtE1.Text = "" 
Me.txtE1.MaxLength = 27
Me.lblE2.Location = New System.Drawing.Point(20,193)
Me.lblE2.name = "lblE2"
Me.lblE2.Size = New System.Drawing.Size(200, 20)
Me.lblE2.TabIndex = 9
Me.lblE2.Text = "Энергия тариф 2"
Me.lblE2.ForeColor = System.Drawing.Color.Blue
Me.txtE2.Location = New System.Drawing.Point(20,215)
Me.txtE2.name = "txtE2"
Me.txtE2.MultiLine = false
Me.txtE2.Size = New System.Drawing.Size(200,  20)
Me.txtE2.TabIndex = 10
Me.txtE2.Text = "" 
Me.txtE2.MaxLength = 27
Me.lblE3.Location = New System.Drawing.Point(20,240)
Me.lblE3.name = "lblE3"
Me.lblE3.Size = New System.Drawing.Size(200, 20)
Me.lblE3.TabIndex = 11
Me.lblE3.Text = "Энергия тариф 3"
Me.lblE3.ForeColor = System.Drawing.Color.Blue
Me.txtE3.Location = New System.Drawing.Point(20,262)
Me.txtE3.name = "txtE3"
Me.txtE3.MultiLine = false
Me.txtE3.Size = New System.Drawing.Size(200,  20)
Me.txtE3.TabIndex = 12
Me.txtE3.Text = "" 
Me.txtE3.MaxLength = 27
Me.lblE4.Location = New System.Drawing.Point(20,287)
Me.lblE4.name = "lblE4"
Me.lblE4.Size = New System.Drawing.Size(200, 20)
Me.lblE4.TabIndex = 13
Me.lblE4.Text = "Энергия тариф 4"
Me.lblE4.ForeColor = System.Drawing.Color.Blue
Me.txtE4.Location = New System.Drawing.Point(20,309)
Me.txtE4.name = "txtE4"
Me.txtE4.MultiLine = false
Me.txtE4.Size = New System.Drawing.Size(200,  20)
Me.txtE4.TabIndex = 14
Me.txtE4.Text = "" 
Me.txtE4.MaxLength = 27
Me.lblE0S.Location = New System.Drawing.Point(20,334)
Me.lblE0S.name = "lblE0S"
Me.lblE0S.Size = New System.Drawing.Size(200, 20)
Me.lblE0S.TabIndex = 15
Me.lblE0S.Text = "Энергия общ. НИ"
Me.lblE0S.ForeColor = System.Drawing.Color.Blue
Me.txtE0S.Location = New System.Drawing.Point(20,356)
Me.txtE0S.name = "txtE0S"
Me.txtE0S.MultiLine = false
Me.txtE0S.Size = New System.Drawing.Size(200,  20)
Me.txtE0S.TabIndex = 16
Me.txtE0S.Text = "" 
Me.txtE0S.MaxLength = 27
Me.lblE1S.Location = New System.Drawing.Point(20,381)
Me.lblE1S.name = "lblE1S"
Me.lblE1S.Size = New System.Drawing.Size(200, 20)
Me.lblE1S.TabIndex = 17
Me.lblE1S.Text = "Энергия тариф 1 НИ"
Me.lblE1S.ForeColor = System.Drawing.Color.Blue
Me.txtE1S.Location = New System.Drawing.Point(20,403)
Me.txtE1S.name = "txtE1S"
Me.txtE1S.MultiLine = false
Me.txtE1S.Size = New System.Drawing.Size(200,  20)
Me.txtE1S.TabIndex = 18
Me.txtE1S.Text = "" 
Me.txtE1S.MaxLength = 27
Me.lblE2S.Location = New System.Drawing.Point(230,5)
Me.lblE2S.name = "lblE2S"
Me.lblE2S.Size = New System.Drawing.Size(200, 20)
Me.lblE2S.TabIndex = 19
Me.lblE2S.Text = "Энергия тариф 2 НИ"
Me.lblE2S.ForeColor = System.Drawing.Color.Blue
Me.txtE2S.Location = New System.Drawing.Point(230,27)
Me.txtE2S.name = "txtE2S"
Me.txtE2S.MultiLine = false
Me.txtE2S.Size = New System.Drawing.Size(200,  20)
Me.txtE2S.TabIndex = 20
Me.txtE2S.Text = "" 
Me.txtE2S.MaxLength = 27
Me.lblE3S.Location = New System.Drawing.Point(230,52)
Me.lblE3S.name = "lblE3S"
Me.lblE3S.Size = New System.Drawing.Size(200, 20)
Me.lblE3S.TabIndex = 21
Me.lblE3S.Text = "Энергия тариф 3 НИ"
Me.lblE3S.ForeColor = System.Drawing.Color.Blue
Me.txtE3S.Location = New System.Drawing.Point(230,74)
Me.txtE3S.name = "txtE3S"
Me.txtE3S.MultiLine = false
Me.txtE3S.Size = New System.Drawing.Size(200,  20)
Me.txtE3S.TabIndex = 22
Me.txtE3S.Text = "" 
Me.txtE3S.MaxLength = 27
Me.lblE4S.Location = New System.Drawing.Point(230,99)
Me.lblE4S.name = "lblE4S"
Me.lblE4S.Size = New System.Drawing.Size(200, 20)
Me.lblE4S.TabIndex = 23
Me.lblE4S.Text = "Энергия тариф 4 НИ"
Me.lblE4S.ForeColor = System.Drawing.Color.Blue
Me.txtE4S.Location = New System.Drawing.Point(230,121)
Me.txtE4S.name = "txtE4S"
Me.txtE4S.MultiLine = false
Me.txtE4S.Size = New System.Drawing.Size(200,  20)
Me.txtE4S.TabIndex = 24
Me.txtE4S.Text = "" 
Me.txtE4S.MaxLength = 27
Me.lblAP.Location = New System.Drawing.Point(230,146)
Me.lblAP.name = "lblAP"
Me.lblAP.Size = New System.Drawing.Size(200, 20)
Me.lblAP.TabIndex = 25
Me.lblAP.Text = "Активная +"
Me.lblAP.ForeColor = System.Drawing.Color.Blue
Me.txtAP.Location = New System.Drawing.Point(230,168)
Me.txtAP.name = "txtAP"
Me.txtAP.MultiLine = false
Me.txtAP.Size = New System.Drawing.Size(200,  20)
Me.txtAP.TabIndex = 26
Me.txtAP.Text = "" 
Me.txtAP.MaxLength = 27
Me.lblAM.Location = New System.Drawing.Point(230,193)
Me.lblAM.name = "lblAM"
Me.lblAM.Size = New System.Drawing.Size(200, 20)
Me.lblAM.TabIndex = 27
Me.lblAM.Text = "Активная - "
Me.lblAM.ForeColor = System.Drawing.Color.Blue
Me.txtAM.Location = New System.Drawing.Point(230,215)
Me.txtAM.name = "txtAM"
Me.txtAM.MultiLine = false
Me.txtAM.Size = New System.Drawing.Size(200,  20)
Me.txtAM.TabIndex = 28
Me.txtAM.Text = "" 
Me.txtAM.MaxLength = 27
Me.lblRP.Location = New System.Drawing.Point(230,240)
Me.lblRP.name = "lblRP"
Me.lblRP.Size = New System.Drawing.Size(200, 20)
Me.lblRP.TabIndex = 29
Me.lblRP.Text = "Реактивная +"
Me.lblRP.ForeColor = System.Drawing.Color.Blue
Me.txtRP.Location = New System.Drawing.Point(230,262)
Me.txtRP.name = "txtRP"
Me.txtRP.MultiLine = false
Me.txtRP.Size = New System.Drawing.Size(200,  20)
Me.txtRP.TabIndex = 30
Me.txtRP.Text = "" 
Me.txtRP.MaxLength = 27
Me.lblRM.Location = New System.Drawing.Point(230,287)
Me.lblRM.name = "lblRM"
Me.lblRM.Size = New System.Drawing.Size(200, 20)
Me.lblRM.TabIndex = 31
Me.lblRM.Text = "Реактивная -"
Me.lblRM.ForeColor = System.Drawing.Color.Blue
Me.txtRM.Location = New System.Drawing.Point(230,309)
Me.txtRM.name = "txtRM"
Me.txtRM.MultiLine = false
Me.txtRM.Size = New System.Drawing.Size(200,  20)
Me.txtRM.TabIndex = 32
Me.txtRM.Text = "" 
Me.txtRM.MaxLength = 27
Me.lblI1.Location = New System.Drawing.Point(230,334)
Me.lblI1.name = "lblI1"
Me.lblI1.Size = New System.Drawing.Size(200, 20)
Me.lblI1.TabIndex = 33
Me.lblI1.Text = "Ток Ф1"
Me.lblI1.ForeColor = System.Drawing.Color.Blue
Me.txtI1.Location = New System.Drawing.Point(230,356)
Me.txtI1.name = "txtI1"
Me.txtI1.MultiLine = false
Me.txtI1.Size = New System.Drawing.Size(200,  20)
Me.txtI1.TabIndex = 34
Me.txtI1.Text = "" 
Me.txtI1.MaxLength = 27
Me.lblI2.Location = New System.Drawing.Point(230,381)
Me.lblI2.name = "lblI2"
Me.lblI2.Size = New System.Drawing.Size(200, 20)
Me.lblI2.TabIndex = 35
Me.lblI2.Text = "Ток Ф2"
Me.lblI2.ForeColor = System.Drawing.Color.Blue
Me.txtI2.Location = New System.Drawing.Point(230,403)
Me.txtI2.name = "txtI2"
Me.txtI2.MultiLine = false
Me.txtI2.Size = New System.Drawing.Size(200,  20)
Me.txtI2.TabIndex = 36
Me.txtI2.Text = "" 
Me.txtI2.MaxLength = 27
Me.lblI3.Location = New System.Drawing.Point(440,5)
Me.lblI3.name = "lblI3"
Me.lblI3.Size = New System.Drawing.Size(200, 20)
Me.lblI3.TabIndex = 37
Me.lblI3.Text = "Ток Ф3"
Me.lblI3.ForeColor = System.Drawing.Color.Blue
Me.txtI3.Location = New System.Drawing.Point(440,27)
Me.txtI3.name = "txtI3"
Me.txtI3.MultiLine = false
Me.txtI3.Size = New System.Drawing.Size(200,  20)
Me.txtI3.TabIndex = 38
Me.txtI3.Text = "" 
Me.txtI3.MaxLength = 27
Me.lblU1.Location = New System.Drawing.Point(440,52)
Me.lblU1.name = "lblU1"
Me.lblU1.Size = New System.Drawing.Size(200, 20)
Me.lblU1.TabIndex = 39
Me.lblU1.Text = "Напряжение Ф1"
Me.lblU1.ForeColor = System.Drawing.Color.Blue
Me.txtU1.Location = New System.Drawing.Point(440,74)
Me.txtU1.name = "txtU1"
Me.txtU1.MultiLine = false
Me.txtU1.Size = New System.Drawing.Size(200,  20)
Me.txtU1.TabIndex = 40
Me.txtU1.Text = "" 
Me.txtU1.MaxLength = 27
Me.lblU2.Location = New System.Drawing.Point(440,99)
Me.lblU2.name = "lblU2"
Me.lblU2.Size = New System.Drawing.Size(200, 20)
Me.lblU2.TabIndex = 41
Me.lblU2.Text = "Напряжение Ф2"
Me.lblU2.ForeColor = System.Drawing.Color.Blue
Me.txtU2.Location = New System.Drawing.Point(440,121)
Me.txtU2.name = "txtU2"
Me.txtU2.MultiLine = false
Me.txtU2.Size = New System.Drawing.Size(200,  20)
Me.txtU2.TabIndex = 42
Me.txtU2.Text = "" 
Me.txtU2.MaxLength = 27
Me.lblU3.Location = New System.Drawing.Point(440,146)
Me.lblU3.name = "lblU3"
Me.lblU3.Size = New System.Drawing.Size(200, 20)
Me.lblU3.TabIndex = 43
Me.lblU3.Text = "Напряжение Ф3"
Me.lblU3.ForeColor = System.Drawing.Color.Blue
Me.txtU3.Location = New System.Drawing.Point(440,168)
Me.txtU3.name = "txtU3"
Me.txtU3.MultiLine = false
Me.txtU3.Size = New System.Drawing.Size(200,  20)
Me.txtU3.TabIndex = 44
Me.txtU3.Text = "" 
Me.txtU3.MaxLength = 27
Me.lblOKTIME.Location = New System.Drawing.Point(440,193)
Me.lblOKTIME.name = "lblOKTIME"
Me.lblOKTIME.Size = New System.Drawing.Size(200, 20)
Me.lblOKTIME.TabIndex = 45
Me.lblOKTIME.Text = "Время безошиб.работы"
Me.lblOKTIME.ForeColor = System.Drawing.Color.Blue
Me.txtOKTIME.Location = New System.Drawing.Point(440,215)
Me.txtOKTIME.name = "txtOKTIME"
Me.txtOKTIME.MultiLine = false
Me.txtOKTIME.Size = New System.Drawing.Size(200,  20)
Me.txtOKTIME.TabIndex = 46
Me.txtOKTIME.Text = "" 
Me.txtOKTIME.MaxLength = 27
Me.lblWORKTIME.Location = New System.Drawing.Point(440,240)
Me.lblWORKTIME.name = "lblWORKTIME"
Me.lblWORKTIME.Size = New System.Drawing.Size(200, 20)
Me.lblWORKTIME.TabIndex = 47
Me.lblWORKTIME.Text = "Время работы"
Me.lblWORKTIME.ForeColor = System.Drawing.Color.Blue
Me.txtWORKTIME.Location = New System.Drawing.Point(440,262)
Me.txtWORKTIME.name = "txtWORKTIME"
Me.txtWORKTIME.MultiLine = false
Me.txtWORKTIME.Size = New System.Drawing.Size(200,  20)
Me.txtWORKTIME.TabIndex = 48
Me.txtWORKTIME.Text = "" 
Me.txtWORKTIME.MaxLength = 27
Me.lblerrInfo.Location = New System.Drawing.Point(440,287)
Me.lblerrInfo.name = "lblerrInfo"
Me.lblerrInfo.Size = New System.Drawing.Size(200, 20)
Me.lblerrInfo.TabIndex = 49
Me.lblerrInfo.Text = "Ошибки"
Me.lblerrInfo.ForeColor = System.Drawing.Color.Blue
Me.txterrInfo.Location = New System.Drawing.Point(440,309)
Me.txterrInfo.name = "txterrInfo"
Me.txterrInfo.Size = New System.Drawing.Size(200, 20)
Me.txterrInfo.TabIndex = 50
Me.txterrInfo.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDCALL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpDCALL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDCOUNTER)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpDCOUNTER)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblE0)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtE0)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblE1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtE1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblE2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtE2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblE3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtE3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblE4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtE4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblE0S)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtE0S)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblE1S)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtE1S)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblE2S)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtE2S)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblE3S)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtE3S)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblE4S)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtE4S)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAP)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtAP)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtAM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblRP)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtRP)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblRM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtRM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblI1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtI1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblI2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtI2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblI3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtI3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblU1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtU1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblU2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtU2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblU3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtU3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblOKTIME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtOKTIME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblWORKTIME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtWORKTIME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblerrInfo)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txterrInfo)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLC_E"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub dtpDCALL_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDCALL.ValueChanged
  Changing 

end sub
private sub dtpDCOUNTER_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDCOUNTER.ValueChanged
  Changing 

end sub
        Private Sub txtE0_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtE0.Validating
        If txtE0.Text <> "" Then
            try
            If Not IsNumeric(txtE0.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtE0.Text) < -922337203685478# Or Val(txtE0.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtE0_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtE0.TextChanged
  Changing

end sub
        Private Sub txtE1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtE1.Validating
        If txtE1.Text <> "" Then
            try
            If Not IsNumeric(txtE1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtE1.Text) < -922337203685478# Or Val(txtE1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtE1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtE1.TextChanged
  Changing

end sub
        Private Sub txtE2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtE2.Validating
        If txtE2.Text <> "" Then
            try
            If Not IsNumeric(txtE2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtE2.Text) < -922337203685478# Or Val(txtE2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtE2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtE2.TextChanged
  Changing

end sub
        Private Sub txtE3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtE3.Validating
        If txtE3.Text <> "" Then
            try
            If Not IsNumeric(txtE3.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtE3.Text) < -922337203685478# Or Val(txtE3.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtE3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtE3.TextChanged
  Changing

end sub
        Private Sub txtE4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtE4.Validating
        If txtE4.Text <> "" Then
            try
            If Not IsNumeric(txtE4.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtE4.Text) < -922337203685478# Or Val(txtE4.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtE4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtE4.TextChanged
  Changing

end sub
        Private Sub txtE0S_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtE0S.Validating
        If txtE0S.Text <> "" Then
            try
            If Not IsNumeric(txtE0S.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtE0S.Text) < -922337203685478# Or Val(txtE0S.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtE0S_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtE0S.TextChanged
  Changing

end sub
        Private Sub txtE1S_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtE1S.Validating
        If txtE1S.Text <> "" Then
            try
            If Not IsNumeric(txtE1S.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtE1S.Text) < -922337203685478# Or Val(txtE1S.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtE1S_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtE1S.TextChanged
  Changing

end sub
        Private Sub txtE2S_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtE2S.Validating
        If txtE2S.Text <> "" Then
            try
            If Not IsNumeric(txtE2S.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtE2S.Text) < -922337203685478# Or Val(txtE2S.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtE2S_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtE2S.TextChanged
  Changing

end sub
        Private Sub txtE3S_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtE3S.Validating
        If txtE3S.Text <> "" Then
            try
            If Not IsNumeric(txtE3S.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtE3S.Text) < -922337203685478# Or Val(txtE3S.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtE3S_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtE3S.TextChanged
  Changing

end sub
        Private Sub txtE4S_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtE4S.Validating
        If txtE4S.Text <> "" Then
            try
            If Not IsNumeric(txtE4S.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtE4S.Text) < -922337203685478# Or Val(txtE4S.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtE4S_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtE4S.TextChanged
  Changing

end sub
        Private Sub txtAP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAP.Validating
        If txtAP.Text <> "" Then
            try
            If Not IsNumeric(txtAP.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtAP.Text) < -922337203685478# Or Val(txtAP.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtAP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAP.TextChanged
  Changing

end sub
        Private Sub txtAM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAM.Validating
        If txtAM.Text <> "" Then
            try
            If Not IsNumeric(txtAM.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtAM.Text) < -922337203685478# Or Val(txtAM.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtAM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAM.TextChanged
  Changing

end sub
        Private Sub txtRP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRP.Validating
        If txtRP.Text <> "" Then
            try
            If Not IsNumeric(txtRP.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtRP.Text) < -922337203685478# Or Val(txtRP.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtRP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRP.TextChanged
  Changing

end sub
        Private Sub txtRM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRM.Validating
        If txtRM.Text <> "" Then
            try
            If Not IsNumeric(txtRM.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtRM.Text) < -922337203685478# Or Val(txtRM.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtRM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRM.TextChanged
  Changing

end sub
        Private Sub txtI1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtI1.Validating
        If txtI1.Text <> "" Then
            try
            If Not IsNumeric(txtI1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtI1.Text) < -922337203685478# Or Val(txtI1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtI1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtI1.TextChanged
  Changing

end sub
        Private Sub txtI2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtI2.Validating
        If txtI2.Text <> "" Then
            try
            If Not IsNumeric(txtI2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtI2.Text) < -922337203685478# Or Val(txtI2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtI2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtI2.TextChanged
  Changing

end sub
        Private Sub txtI3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtI3.Validating
        If txtI3.Text <> "" Then
            try
            If Not IsNumeric(txtI3.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtI3.Text) < -922337203685478# Or Val(txtI3.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtI3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtI3.TextChanged
  Changing

end sub
        Private Sub txtU1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtU1.Validating
        If txtU1.Text <> "" Then
            try
            If Not IsNumeric(txtU1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtU1.Text) < -922337203685478# Or Val(txtU1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtU1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtU1.TextChanged
  Changing

end sub
        Private Sub txtU2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtU2.Validating
        If txtU2.Text <> "" Then
            try
            If Not IsNumeric(txtU2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtU2.Text) < -922337203685478# Or Val(txtU2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtU2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtU2.TextChanged
  Changing

end sub
        Private Sub txtU3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtU3.Validating
        If txtU3.Text <> "" Then
            try
            If Not IsNumeric(txtU3.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtU3.Text) < -922337203685478# Or Val(txtU3.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtU3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtU3.TextChanged
  Changing

end sub
        Private Sub txtOKTIME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOKTIME.Validating
        If txtOKTIME.Text <> "" Then
            try
            If Not IsNumeric(txtOKTIME.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtOKTIME.Text) < -922337203685478# Or Val(txtOKTIME.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtOKTIME_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOKTIME.TextChanged
  Changing

end sub
        Private Sub txtWORKTIME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtWORKTIME.Validating
        If txtWORKTIME.Text <> "" Then
            try
            If Not IsNumeric(txtWORKTIME.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtWORKTIME.Text) < -922337203685478# Or Val(txtWORKTIME.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtWORKTIME_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWORKTIME.TextChanged
  Changing

end sub
private sub txterrInfo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txterrInfo.TextChanged
  Changing

end sub

Public Item As TPLC.TPLC.TPLC_E
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLC.TPLC.TPLC_E)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

dtpDCALL.value = System.DateTime.Now
if item.DCALL <> System.DateTime.MinValue then
  try
     dtpDCALL.value = item.DCALL
  catch
   dtpDCALL.value = System.DateTime.MinValue
  end try
else
   dtpDCALL.value = System.DateTime.Today
   dtpDCALL.Checked =false
end if
dtpDCOUNTER.value = System.DateTime.Now
if item.DCOUNTER <> System.DateTime.MinValue then
  try
     dtpDCOUNTER.value = item.DCOUNTER
  catch
   dtpDCOUNTER.value = System.DateTime.MinValue
  end try
else
   dtpDCOUNTER.value = System.DateTime.Today
   dtpDCOUNTER.Checked =false
end if
txtE0.text = item.E0.toString()
txtE1.text = item.E1.toString()
txtE2.text = item.E2.toString()
txtE3.text = item.E3.toString()
txtE4.text = item.E4.toString()
txtE0S.text = item.E0S.toString()
txtE1S.text = item.E1S.toString()
txtE2S.text = item.E2S.toString()
txtE3S.text = item.E3S.toString()
txtE4S.text = item.E4S.toString()
txtAP.text = item.AP.toString()
txtAM.text = item.AM.toString()
txtRP.text = item.RP.toString()
txtRM.text = item.RM.toString()
txtI1.text = item.I1.toString()
txtI2.text = item.I2.toString()
txtI3.text = item.I3.toString()
txtU1.text = item.U1.toString()
txtU2.text = item.U2.toString()
txtU3.text = item.U3.toString()
txtOKTIME.text = item.OKTIME.toString()
txtWORKTIME.text = item.WORKTIME.toString()
txterrInfo.text = item.errInfo
        mOnInit = false
  raiseevent Refreshed()
end sub


''' <summary>
'''Сохранения данных в полях объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Save() Implements LATIR2GUIManager.IRowEditor.Save
  if mRowReadOnly =false then

  if dtpDCALL.checked=false then
       item.DCALL = System.DateTime.MinValue
  else 
  try
    item.DCALL = dtpDCALL.value
  catch
    item.DCALL = System.DateTime.MinValue
  end try
  end if
  if dtpDCOUNTER.checked=false then
       item.DCOUNTER = System.DateTime.MinValue
  else 
  try
    item.DCOUNTER = dtpDCOUNTER.value
  catch
    item.DCOUNTER = System.DateTime.MinValue
  end try
  end if
item.E0 = cdbl(txtE0.text)
item.E1 = cdbl(txtE1.text)
item.E2 = cdbl(txtE2.text)
item.E3 = cdbl(txtE3.text)
item.E4 = cdbl(txtE4.text)
item.E0S = cdbl(txtE0S.text)
item.E1S = cdbl(txtE1S.text)
item.E2S = cdbl(txtE2S.text)
item.E3S = cdbl(txtE3S.text)
item.E4S = cdbl(txtE4S.text)
item.AP = cdbl(txtAP.text)
item.AM = cdbl(txtAM.text)
item.RP = cdbl(txtRP.text)
item.RM = cdbl(txtRM.text)
item.I1 = cdbl(txtI1.text)
item.I2 = cdbl(txtI2.text)
item.I3 = cdbl(txtI3.text)
item.U1 = cdbl(txtU1.text)
item.U2 = cdbl(txtU2.text)
item.U3 = cdbl(txtU3.text)
item.OKTIME = cdbl(txtOKTIME.text)
item.WORKTIME = cdbl(txtWORKTIME.text)
item.errInfo = txterrInfo.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

 return mIsOK
end function
Public function IsChanged() as boolean Implements LATIR2GUIManager.IRowEditor.IsChanged
 return mChanged
end function
Public Sub SetupPanel()
    HolderPanel.SetupPanel()
End Sub
Public Overridable Function GetMaxX() As Double
    Return HolderPanel.GetMaxX()
End Function
Public Overridable Function GetMaxY() As Double
    Return HolderPanel.GetMaxY()
End Function
end class
