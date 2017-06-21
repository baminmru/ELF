
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Мгновенные значения режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLC_M
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
Friend WithEvents lblQ1  as  System.Windows.Forms.Label
Friend WithEvents txtQ1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblQ2  as  System.Windows.Forms.Label
Friend WithEvents txtQ2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblT1  as  System.Windows.Forms.Label
Friend WithEvents txtT1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblT2  as  System.Windows.Forms.Label
Friend WithEvents txtT2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDT12  as  System.Windows.Forms.Label
Friend WithEvents txtDT12 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblT3  as  System.Windows.Forms.Label
Friend WithEvents txtT3 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblT4  as  System.Windows.Forms.Label
Friend WithEvents txtT4 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblT5  as  System.Windows.Forms.Label
Friend WithEvents txtT5 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDT45  as  System.Windows.Forms.Label
Friend WithEvents txtDT45 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblT6  as  System.Windows.Forms.Label
Friend WithEvents txtT6 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblV1  as  System.Windows.Forms.Label
Friend WithEvents txtV1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblV2  as  System.Windows.Forms.Label
Friend WithEvents txtV2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDV12  as  System.Windows.Forms.Label
Friend WithEvents txtDV12 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblV3  as  System.Windows.Forms.Label
Friend WithEvents txtV3 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblV4  as  System.Windows.Forms.Label
Friend WithEvents txtV4 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblV5  as  System.Windows.Forms.Label
Friend WithEvents txtV5 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDV45  as  System.Windows.Forms.Label
Friend WithEvents txtDV45 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblV6  as  System.Windows.Forms.Label
Friend WithEvents txtV6 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblM1  as  System.Windows.Forms.Label
Friend WithEvents txtM1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblM2  as  System.Windows.Forms.Label
Friend WithEvents txtM2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDM12  as  System.Windows.Forms.Label
Friend WithEvents txtDM12 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblM3  as  System.Windows.Forms.Label
Friend WithEvents txtM3 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblM4  as  System.Windows.Forms.Label
Friend WithEvents txtM4 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblM5  as  System.Windows.Forms.Label
Friend WithEvents txtM5 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDM45  as  System.Windows.Forms.Label
Friend WithEvents txtDM45 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblM6  as  System.Windows.Forms.Label
Friend WithEvents txtM6 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblP1  as  System.Windows.Forms.Label
Friend WithEvents txtP1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblP2  as  System.Windows.Forms.Label
Friend WithEvents txtP2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblP3  as  System.Windows.Forms.Label
Friend WithEvents txtP3 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblP4  as  System.Windows.Forms.Label
Friend WithEvents txtP4 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblP5  as  System.Windows.Forms.Label
Friend WithEvents txtP5 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblP6  as  System.Windows.Forms.Label
Friend WithEvents txtP6 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblG1  as  System.Windows.Forms.Label
Friend WithEvents txtG1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblG2  as  System.Windows.Forms.Label
Friend WithEvents txtG2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblG3  as  System.Windows.Forms.Label
Friend WithEvents txtG3 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblG4  as  System.Windows.Forms.Label
Friend WithEvents txtG4 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblG5  as  System.Windows.Forms.Label
Friend WithEvents txtG5 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblG6  as  System.Windows.Forms.Label
Friend WithEvents txtG6 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTCOOL  as  System.Windows.Forms.Label
Friend WithEvents txtTCOOL As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTCE1  as  System.Windows.Forms.Label
Friend WithEvents txtTCE1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTCE2  as  System.Windows.Forms.Label
Friend WithEvents txtTCE2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTSUM1  as  System.Windows.Forms.Label
Friend WithEvents txtTSUM1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTSUM2  as  System.Windows.Forms.Label
Friend WithEvents txtTSUM2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblQ1H  as  System.Windows.Forms.Label
Friend WithEvents txtQ1H As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblQ2H  as  System.Windows.Forms.Label
Friend WithEvents txtQ2H As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblV1H  as  System.Windows.Forms.Label
Friend WithEvents txtV1H As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblV2H  as  System.Windows.Forms.Label
Friend WithEvents txtV2H As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblV4H  as  System.Windows.Forms.Label
Friend WithEvents txtV4H As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblV5H  as  System.Windows.Forms.Label
Friend WithEvents txtV5H As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblERRTIME  as  System.Windows.Forms.Label
Friend WithEvents txtERRTIME As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblERRTIMEH  as  System.Windows.Forms.Label
Friend WithEvents txtERRTIMEH As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblHC  as  System.Windows.Forms.Label
Friend WithEvents txtHC As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblSP  as  System.Windows.Forms.Label
Friend WithEvents txtSP As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblSP_TB1  as  System.Windows.Forms.Label
Friend WithEvents txtSP_TB1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblSP_TB2  as  System.Windows.Forms.Label
Friend WithEvents txtSP_TB2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbldatetimeCOUNTER  as  System.Windows.Forms.Label
Friend WithEvents dtpdatetimeCOUNTER As System.Windows.Forms.DateTimePicker
Friend WithEvents lblDG12  as  System.Windows.Forms.Label
Friend WithEvents txtDG12 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDG45  as  System.Windows.Forms.Label
Friend WithEvents txtDG45 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDP12  as  System.Windows.Forms.Label
Friend WithEvents txtDP12 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDP45  as  System.Windows.Forms.Label
Friend WithEvents txtDP45 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblUNITSR  as  System.Windows.Forms.Label
Friend WithEvents txtUNITSR As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblQ3  as  System.Windows.Forms.Label
Friend WithEvents txtQ3 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblQ4  as  System.Windows.Forms.Label
Friend WithEvents txtQ4 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblPATM  as  System.Windows.Forms.Label
Friend WithEvents txtPATM As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblQ5  as  System.Windows.Forms.Label
Friend WithEvents txtQ5 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDQ12  as  System.Windows.Forms.Label
Friend WithEvents txtDQ12 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDQ45  as  System.Windows.Forms.Label
Friend WithEvents txtDQ45 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblPXB  as  System.Windows.Forms.Label
Friend WithEvents txtPXB As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDQ  as  System.Windows.Forms.Label
Friend WithEvents txtDQ As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblHC_1  as  System.Windows.Forms.Label
Friend WithEvents txtHC_1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblHC_2  as  System.Windows.Forms.Label
Friend WithEvents txtHC_2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTHOT  as  System.Windows.Forms.Label
Friend WithEvents txtTHOT As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDANS1  as  System.Windows.Forms.Label
Friend WithEvents txtDANS1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDANS2  as  System.Windows.Forms.Label
Friend WithEvents txtDANS2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDANS3  as  System.Windows.Forms.Label
Friend WithEvents txtDANS3 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDANS4  as  System.Windows.Forms.Label
Friend WithEvents txtDANS4 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDANS5  as  System.Windows.Forms.Label
Friend WithEvents txtDANS5 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDANS6  as  System.Windows.Forms.Label
Friend WithEvents txtDANS6 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCHECK_A  as  System.Windows.Forms.Label
Friend WithEvents txtCHECK_A As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblOKTIME  as  System.Windows.Forms.Label
Friend WithEvents txtOKTIME As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblWORKTIME  as  System.Windows.Forms.Label
Friend WithEvents txtWORKTIME As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTAIR1  as  System.Windows.Forms.Label
Friend WithEvents txtTAIR1 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTAIR2  as  System.Windows.Forms.Label
Friend WithEvents txtTAIR2 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblHC_CODE  as  System.Windows.Forms.Label
Friend WithEvents txtHC_CODE As LATIR2GuiManager.TouchTextBox

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
Me.lblQ1 = New System.Windows.Forms.Label
Me.txtQ1 = New LATIR2GuiManager.TouchTextBox
Me.lblQ2 = New System.Windows.Forms.Label
Me.txtQ2 = New LATIR2GuiManager.TouchTextBox
Me.lblT1 = New System.Windows.Forms.Label
Me.txtT1 = New LATIR2GuiManager.TouchTextBox
Me.lblT2 = New System.Windows.Forms.Label
Me.txtT2 = New LATIR2GuiManager.TouchTextBox
Me.lblDT12 = New System.Windows.Forms.Label
Me.txtDT12 = New LATIR2GuiManager.TouchTextBox
Me.lblT3 = New System.Windows.Forms.Label
Me.txtT3 = New LATIR2GuiManager.TouchTextBox
Me.lblT4 = New System.Windows.Forms.Label
Me.txtT4 = New LATIR2GuiManager.TouchTextBox
Me.lblT5 = New System.Windows.Forms.Label
Me.txtT5 = New LATIR2GuiManager.TouchTextBox
Me.lblDT45 = New System.Windows.Forms.Label
Me.txtDT45 = New LATIR2GuiManager.TouchTextBox
Me.lblT6 = New System.Windows.Forms.Label
Me.txtT6 = New LATIR2GuiManager.TouchTextBox
Me.lblV1 = New System.Windows.Forms.Label
Me.txtV1 = New LATIR2GuiManager.TouchTextBox
Me.lblV2 = New System.Windows.Forms.Label
Me.txtV2 = New LATIR2GuiManager.TouchTextBox
Me.lblDV12 = New System.Windows.Forms.Label
Me.txtDV12 = New LATIR2GuiManager.TouchTextBox
Me.lblV3 = New System.Windows.Forms.Label
Me.txtV3 = New LATIR2GuiManager.TouchTextBox
Me.lblV4 = New System.Windows.Forms.Label
Me.txtV4 = New LATIR2GuiManager.TouchTextBox
Me.lblV5 = New System.Windows.Forms.Label
Me.txtV5 = New LATIR2GuiManager.TouchTextBox
Me.lblDV45 = New System.Windows.Forms.Label
Me.txtDV45 = New LATIR2GuiManager.TouchTextBox
Me.lblV6 = New System.Windows.Forms.Label
Me.txtV6 = New LATIR2GuiManager.TouchTextBox
Me.lblM1 = New System.Windows.Forms.Label
Me.txtM1 = New LATIR2GuiManager.TouchTextBox
Me.lblM2 = New System.Windows.Forms.Label
Me.txtM2 = New LATIR2GuiManager.TouchTextBox
Me.lblDM12 = New System.Windows.Forms.Label
Me.txtDM12 = New LATIR2GuiManager.TouchTextBox
Me.lblM3 = New System.Windows.Forms.Label
Me.txtM3 = New LATIR2GuiManager.TouchTextBox
Me.lblM4 = New System.Windows.Forms.Label
Me.txtM4 = New LATIR2GuiManager.TouchTextBox
Me.lblM5 = New System.Windows.Forms.Label
Me.txtM5 = New LATIR2GuiManager.TouchTextBox
Me.lblDM45 = New System.Windows.Forms.Label
Me.txtDM45 = New LATIR2GuiManager.TouchTextBox
Me.lblM6 = New System.Windows.Forms.Label
Me.txtM6 = New LATIR2GuiManager.TouchTextBox
Me.lblP1 = New System.Windows.Forms.Label
Me.txtP1 = New LATIR2GuiManager.TouchTextBox
Me.lblP2 = New System.Windows.Forms.Label
Me.txtP2 = New LATIR2GuiManager.TouchTextBox
Me.lblP3 = New System.Windows.Forms.Label
Me.txtP3 = New LATIR2GuiManager.TouchTextBox
Me.lblP4 = New System.Windows.Forms.Label
Me.txtP4 = New LATIR2GuiManager.TouchTextBox
Me.lblP5 = New System.Windows.Forms.Label
Me.txtP5 = New LATIR2GuiManager.TouchTextBox
Me.lblP6 = New System.Windows.Forms.Label
Me.txtP6 = New LATIR2GuiManager.TouchTextBox
Me.lblG1 = New System.Windows.Forms.Label
Me.txtG1 = New LATIR2GuiManager.TouchTextBox
Me.lblG2 = New System.Windows.Forms.Label
Me.txtG2 = New LATIR2GuiManager.TouchTextBox
Me.lblG3 = New System.Windows.Forms.Label
Me.txtG3 = New LATIR2GuiManager.TouchTextBox
Me.lblG4 = New System.Windows.Forms.Label
Me.txtG4 = New LATIR2GuiManager.TouchTextBox
Me.lblG5 = New System.Windows.Forms.Label
Me.txtG5 = New LATIR2GuiManager.TouchTextBox
Me.lblG6 = New System.Windows.Forms.Label
Me.txtG6 = New LATIR2GuiManager.TouchTextBox
Me.lblTCOOL = New System.Windows.Forms.Label
Me.txtTCOOL = New LATIR2GuiManager.TouchTextBox
Me.lblTCE1 = New System.Windows.Forms.Label
Me.txtTCE1 = New LATIR2GuiManager.TouchTextBox
Me.lblTCE2 = New System.Windows.Forms.Label
Me.txtTCE2 = New LATIR2GuiManager.TouchTextBox
Me.lblTSUM1 = New System.Windows.Forms.Label
Me.txtTSUM1 = New LATIR2GuiManager.TouchTextBox
Me.lblTSUM2 = New System.Windows.Forms.Label
Me.txtTSUM2 = New LATIR2GuiManager.TouchTextBox
Me.lblQ1H = New System.Windows.Forms.Label
Me.txtQ1H = New LATIR2GuiManager.TouchTextBox
Me.lblQ2H = New System.Windows.Forms.Label
Me.txtQ2H = New LATIR2GuiManager.TouchTextBox
Me.lblV1H = New System.Windows.Forms.Label
Me.txtV1H = New LATIR2GuiManager.TouchTextBox
Me.lblV2H = New System.Windows.Forms.Label
Me.txtV2H = New LATIR2GuiManager.TouchTextBox
Me.lblV4H = New System.Windows.Forms.Label
Me.txtV4H = New LATIR2GuiManager.TouchTextBox
Me.lblV5H = New System.Windows.Forms.Label
Me.txtV5H = New LATIR2GuiManager.TouchTextBox
Me.lblERRTIME = New System.Windows.Forms.Label
Me.txtERRTIME = New LATIR2GuiManager.TouchTextBox
Me.lblERRTIMEH = New System.Windows.Forms.Label
Me.txtERRTIMEH = New LATIR2GuiManager.TouchTextBox
Me.lblHC = New System.Windows.Forms.Label
Me.txtHC = New LATIR2GuiManager.TouchTextBox
Me.lblSP = New System.Windows.Forms.Label
Me.txtSP = New LATIR2GuiManager.TouchTextBox
Me.lblSP_TB1 = New System.Windows.Forms.Label
Me.txtSP_TB1 = New LATIR2GuiManager.TouchTextBox
Me.lblSP_TB2 = New System.Windows.Forms.Label
Me.txtSP_TB2 = New LATIR2GuiManager.TouchTextBox
Me.lbldatetimeCOUNTER = New System.Windows.Forms.Label
Me.dtpdatetimeCOUNTER = New System.Windows.Forms.DateTimePicker
Me.lblDG12 = New System.Windows.Forms.Label
Me.txtDG12 = New LATIR2GuiManager.TouchTextBox
Me.lblDG45 = New System.Windows.Forms.Label
Me.txtDG45 = New LATIR2GuiManager.TouchTextBox
Me.lblDP12 = New System.Windows.Forms.Label
Me.txtDP12 = New LATIR2GuiManager.TouchTextBox
Me.lblDP45 = New System.Windows.Forms.Label
Me.txtDP45 = New LATIR2GuiManager.TouchTextBox
Me.lblUNITSR = New System.Windows.Forms.Label
Me.txtUNITSR = New LATIR2GuiManager.TouchTextBox
Me.lblQ3 = New System.Windows.Forms.Label
Me.txtQ3 = New LATIR2GuiManager.TouchTextBox
Me.lblQ4 = New System.Windows.Forms.Label
Me.txtQ4 = New LATIR2GuiManager.TouchTextBox
Me.lblPATM = New System.Windows.Forms.Label
Me.txtPATM = New LATIR2GuiManager.TouchTextBox
Me.lblQ5 = New System.Windows.Forms.Label
Me.txtQ5 = New LATIR2GuiManager.TouchTextBox
Me.lblDQ12 = New System.Windows.Forms.Label
Me.txtDQ12 = New LATIR2GuiManager.TouchTextBox
Me.lblDQ45 = New System.Windows.Forms.Label
Me.txtDQ45 = New LATIR2GuiManager.TouchTextBox
Me.lblPXB = New System.Windows.Forms.Label
Me.txtPXB = New LATIR2GuiManager.TouchTextBox
Me.lblDQ = New System.Windows.Forms.Label
Me.txtDQ = New LATIR2GuiManager.TouchTextBox
Me.lblHC_1 = New System.Windows.Forms.Label
Me.txtHC_1 = New LATIR2GuiManager.TouchTextBox
Me.lblHC_2 = New System.Windows.Forms.Label
Me.txtHC_2 = New LATIR2GuiManager.TouchTextBox
Me.lblTHOT = New System.Windows.Forms.Label
Me.txtTHOT = New LATIR2GuiManager.TouchTextBox
Me.lblDANS1 = New System.Windows.Forms.Label
Me.txtDANS1 = New LATIR2GuiManager.TouchTextBox
Me.lblDANS2 = New System.Windows.Forms.Label
Me.txtDANS2 = New LATIR2GuiManager.TouchTextBox
Me.lblDANS3 = New System.Windows.Forms.Label
Me.txtDANS3 = New LATIR2GuiManager.TouchTextBox
Me.lblDANS4 = New System.Windows.Forms.Label
Me.txtDANS4 = New LATIR2GuiManager.TouchTextBox
Me.lblDANS5 = New System.Windows.Forms.Label
Me.txtDANS5 = New LATIR2GuiManager.TouchTextBox
Me.lblDANS6 = New System.Windows.Forms.Label
Me.txtDANS6 = New LATIR2GuiManager.TouchTextBox
Me.lblCHECK_A = New System.Windows.Forms.Label
Me.txtCHECK_A = New LATIR2GuiManager.TouchTextBox
Me.lblOKTIME = New System.Windows.Forms.Label
Me.txtOKTIME = New LATIR2GuiManager.TouchTextBox
Me.lblWORKTIME = New System.Windows.Forms.Label
Me.txtWORKTIME = New LATIR2GuiManager.TouchTextBox
Me.lblTAIR1 = New System.Windows.Forms.Label
Me.txtTAIR1 = New LATIR2GuiManager.TouchTextBox
Me.lblTAIR2 = New System.Windows.Forms.Label
Me.txtTAIR2 = New LATIR2GuiManager.TouchTextBox
Me.lblHC_CODE = New System.Windows.Forms.Label
Me.txtHC_CODE = New LATIR2GuiManager.TouchTextBox

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
Me.lblQ1.Location = New System.Drawing.Point(20,99)
Me.lblQ1.name = "lblQ1"
Me.lblQ1.Size = New System.Drawing.Size(200, 20)
Me.lblQ1.TabIndex = 5
Me.lblQ1.Text = "Тепловая энергия канал 1"
Me.lblQ1.ForeColor = System.Drawing.Color.Blue
Me.txtQ1.Location = New System.Drawing.Point(20,121)
Me.txtQ1.name = "txtQ1"
Me.txtQ1.MultiLine = false
Me.txtQ1.Size = New System.Drawing.Size(200,  20)
Me.txtQ1.TabIndex = 6
Me.txtQ1.Text = "" 
Me.txtQ1.MaxLength = 27
Me.lblQ2.Location = New System.Drawing.Point(20,146)
Me.lblQ2.name = "lblQ2"
Me.lblQ2.Size = New System.Drawing.Size(200, 20)
Me.lblQ2.TabIndex = 7
Me.lblQ2.Text = "Тепловая энергия канал 2"
Me.lblQ2.ForeColor = System.Drawing.Color.Blue
Me.txtQ2.Location = New System.Drawing.Point(20,168)
Me.txtQ2.name = "txtQ2"
Me.txtQ2.MultiLine = false
Me.txtQ2.Size = New System.Drawing.Size(200,  20)
Me.txtQ2.TabIndex = 8
Me.txtQ2.Text = "" 
Me.txtQ2.MaxLength = 27
Me.lblT1.Location = New System.Drawing.Point(20,193)
Me.lblT1.name = "lblT1"
Me.lblT1.Size = New System.Drawing.Size(200, 20)
Me.lblT1.TabIndex = 9
Me.lblT1.Text = "Температура по каналу 1"
Me.lblT1.ForeColor = System.Drawing.Color.Blue
Me.txtT1.Location = New System.Drawing.Point(20,215)
Me.txtT1.name = "txtT1"
Me.txtT1.MultiLine = false
Me.txtT1.Size = New System.Drawing.Size(200,  20)
Me.txtT1.TabIndex = 10
Me.txtT1.Text = "" 
Me.txtT1.MaxLength = 27
Me.lblT2.Location = New System.Drawing.Point(20,240)
Me.lblT2.name = "lblT2"
Me.lblT2.Size = New System.Drawing.Size(200, 20)
Me.lblT2.TabIndex = 11
Me.lblT2.Text = "Температура по каналу 2"
Me.lblT2.ForeColor = System.Drawing.Color.Blue
Me.txtT2.Location = New System.Drawing.Point(20,262)
Me.txtT2.name = "txtT2"
Me.txtT2.MultiLine = false
Me.txtT2.Size = New System.Drawing.Size(200,  20)
Me.txtT2.TabIndex = 12
Me.txtT2.Text = "" 
Me.txtT2.MaxLength = 27
Me.lblDT12.Location = New System.Drawing.Point(20,287)
Me.lblDT12.name = "lblDT12"
Me.lblDT12.Size = New System.Drawing.Size(200, 20)
Me.lblDT12.TabIndex = 13
Me.lblDT12.Text = "Разность Температур по каналу 1 и 2"
Me.lblDT12.ForeColor = System.Drawing.Color.Blue
Me.txtDT12.Location = New System.Drawing.Point(20,309)
Me.txtDT12.name = "txtDT12"
Me.txtDT12.MultiLine = false
Me.txtDT12.Size = New System.Drawing.Size(200,  20)
Me.txtDT12.TabIndex = 14
Me.txtDT12.Text = "" 
Me.txtDT12.MaxLength = 27
Me.lblT3.Location = New System.Drawing.Point(20,334)
Me.lblT3.name = "lblT3"
Me.lblT3.Size = New System.Drawing.Size(200, 20)
Me.lblT3.TabIndex = 15
Me.lblT3.Text = "Температура по каналу 3"
Me.lblT3.ForeColor = System.Drawing.Color.Blue
Me.txtT3.Location = New System.Drawing.Point(20,356)
Me.txtT3.name = "txtT3"
Me.txtT3.MultiLine = false
Me.txtT3.Size = New System.Drawing.Size(200,  20)
Me.txtT3.TabIndex = 16
Me.txtT3.Text = "" 
Me.txtT3.MaxLength = 27
Me.lblT4.Location = New System.Drawing.Point(20,381)
Me.lblT4.name = "lblT4"
Me.lblT4.Size = New System.Drawing.Size(200, 20)
Me.lblT4.TabIndex = 17
Me.lblT4.Text = "Температура по каналу 4"
Me.lblT4.ForeColor = System.Drawing.Color.Blue
Me.txtT4.Location = New System.Drawing.Point(20,403)
Me.txtT4.name = "txtT4"
Me.txtT4.MultiLine = false
Me.txtT4.Size = New System.Drawing.Size(200,  20)
Me.txtT4.TabIndex = 18
Me.txtT4.Text = "" 
Me.txtT4.MaxLength = 27
Me.lblT5.Location = New System.Drawing.Point(230,5)
Me.lblT5.name = "lblT5"
Me.lblT5.Size = New System.Drawing.Size(200, 20)
Me.lblT5.TabIndex = 19
Me.lblT5.Text = "Температура по каналу 5"
Me.lblT5.ForeColor = System.Drawing.Color.Blue
Me.txtT5.Location = New System.Drawing.Point(230,27)
Me.txtT5.name = "txtT5"
Me.txtT5.MultiLine = false
Me.txtT5.Size = New System.Drawing.Size(200,  20)
Me.txtT5.TabIndex = 20
Me.txtT5.Text = "" 
Me.txtT5.MaxLength = 27
Me.lblDT45.Location = New System.Drawing.Point(230,52)
Me.lblDT45.name = "lblDT45"
Me.lblDT45.Size = New System.Drawing.Size(200, 20)
Me.lblDT45.TabIndex = 21
Me.lblDT45.Text = "Разность Температур по каналу 4 и 5"
Me.lblDT45.ForeColor = System.Drawing.Color.Blue
Me.txtDT45.Location = New System.Drawing.Point(230,74)
Me.txtDT45.name = "txtDT45"
Me.txtDT45.MultiLine = false
Me.txtDT45.Size = New System.Drawing.Size(200,  20)
Me.txtDT45.TabIndex = 22
Me.txtDT45.Text = "" 
Me.txtDT45.MaxLength = 27
Me.lblT6.Location = New System.Drawing.Point(230,99)
Me.lblT6.name = "lblT6"
Me.lblT6.Size = New System.Drawing.Size(200, 20)
Me.lblT6.TabIndex = 23
Me.lblT6.Text = "Температура по каналу 6"
Me.lblT6.ForeColor = System.Drawing.Color.Blue
Me.txtT6.Location = New System.Drawing.Point(230,121)
Me.txtT6.name = "txtT6"
Me.txtT6.MultiLine = false
Me.txtT6.Size = New System.Drawing.Size(200,  20)
Me.txtT6.TabIndex = 24
Me.txtT6.Text = "" 
Me.txtT6.MaxLength = 27
Me.lblV1.Location = New System.Drawing.Point(230,146)
Me.lblV1.name = "lblV1"
Me.lblV1.Size = New System.Drawing.Size(200, 20)
Me.lblV1.TabIndex = 25
Me.lblV1.Text = "Объемный расход воды по каналу 1"
Me.lblV1.ForeColor = System.Drawing.Color.Blue
Me.txtV1.Location = New System.Drawing.Point(230,168)
Me.txtV1.name = "txtV1"
Me.txtV1.MultiLine = false
Me.txtV1.Size = New System.Drawing.Size(200,  20)
Me.txtV1.TabIndex = 26
Me.txtV1.Text = "" 
Me.txtV1.MaxLength = 27
Me.lblV2.Location = New System.Drawing.Point(230,193)
Me.lblV2.name = "lblV2"
Me.lblV2.Size = New System.Drawing.Size(200, 20)
Me.lblV2.TabIndex = 27
Me.lblV2.Text = "Объемный расход воды по каналу 2"
Me.lblV2.ForeColor = System.Drawing.Color.Blue
Me.txtV2.Location = New System.Drawing.Point(230,215)
Me.txtV2.name = "txtV2"
Me.txtV2.MultiLine = false
Me.txtV2.Size = New System.Drawing.Size(200,  20)
Me.txtV2.TabIndex = 28
Me.txtV2.Text = "" 
Me.txtV2.MaxLength = 27
Me.lblDV12.Location = New System.Drawing.Point(230,240)
Me.lblDV12.name = "lblDV12"
Me.lblDV12.Size = New System.Drawing.Size(200, 20)
Me.lblDV12.TabIndex = 29
Me.lblDV12.Text = "Разность объемов канал 1  (расход ГВС)"
Me.lblDV12.ForeColor = System.Drawing.Color.Blue
Me.txtDV12.Location = New System.Drawing.Point(230,262)
Me.txtDV12.name = "txtDV12"
Me.txtDV12.MultiLine = false
Me.txtDV12.Size = New System.Drawing.Size(200,  20)
Me.txtDV12.TabIndex = 30
Me.txtDV12.Text = "" 
Me.txtDV12.MaxLength = 27
Me.lblV3.Location = New System.Drawing.Point(230,287)
Me.lblV3.name = "lblV3"
Me.lblV3.Size = New System.Drawing.Size(200, 20)
Me.lblV3.TabIndex = 31
Me.lblV3.Text = "Объемный расход воды по каналу 3"
Me.lblV3.ForeColor = System.Drawing.Color.Blue
Me.txtV3.Location = New System.Drawing.Point(230,309)
Me.txtV3.name = "txtV3"
Me.txtV3.MultiLine = false
Me.txtV3.Size = New System.Drawing.Size(200,  20)
Me.txtV3.TabIndex = 32
Me.txtV3.Text = "" 
Me.txtV3.MaxLength = 27
Me.lblV4.Location = New System.Drawing.Point(230,334)
Me.lblV4.name = "lblV4"
Me.lblV4.Size = New System.Drawing.Size(200, 20)
Me.lblV4.TabIndex = 33
Me.lblV4.Text = "Объемный расход воды по каналу 4"
Me.lblV4.ForeColor = System.Drawing.Color.Blue
Me.txtV4.Location = New System.Drawing.Point(230,356)
Me.txtV4.name = "txtV4"
Me.txtV4.MultiLine = false
Me.txtV4.Size = New System.Drawing.Size(200,  20)
Me.txtV4.TabIndex = 34
Me.txtV4.Text = "" 
Me.txtV4.MaxLength = 27
Me.lblV5.Location = New System.Drawing.Point(230,381)
Me.lblV5.name = "lblV5"
Me.lblV5.Size = New System.Drawing.Size(200, 20)
Me.lblV5.TabIndex = 35
Me.lblV5.Text = "Объемный расход воды по каналу 5"
Me.lblV5.ForeColor = System.Drawing.Color.Blue
Me.txtV5.Location = New System.Drawing.Point(230,403)
Me.txtV5.name = "txtV5"
Me.txtV5.MultiLine = false
Me.txtV5.Size = New System.Drawing.Size(200,  20)
Me.txtV5.TabIndex = 36
Me.txtV5.Text = "" 
Me.txtV5.MaxLength = 27
Me.lblDV45.Location = New System.Drawing.Point(440,5)
Me.lblDV45.name = "lblDV45"
Me.lblDV45.Size = New System.Drawing.Size(200, 20)
Me.lblDV45.TabIndex = 37
Me.lblDV45.Text = "Разность объемов канал 2"
Me.lblDV45.ForeColor = System.Drawing.Color.Blue
Me.txtDV45.Location = New System.Drawing.Point(440,27)
Me.txtDV45.name = "txtDV45"
Me.txtDV45.MultiLine = false
Me.txtDV45.Size = New System.Drawing.Size(200,  20)
Me.txtDV45.TabIndex = 38
Me.txtDV45.Text = "" 
Me.txtDV45.MaxLength = 27
Me.lblV6.Location = New System.Drawing.Point(440,52)
Me.lblV6.name = "lblV6"
Me.lblV6.Size = New System.Drawing.Size(200, 20)
Me.lblV6.TabIndex = 39
Me.lblV6.Text = "Объемный расход воды по каналу 6"
Me.lblV6.ForeColor = System.Drawing.Color.Blue
Me.txtV6.Location = New System.Drawing.Point(440,74)
Me.txtV6.name = "txtV6"
Me.txtV6.MultiLine = false
Me.txtV6.Size = New System.Drawing.Size(200,  20)
Me.txtV6.TabIndex = 40
Me.txtV6.Text = "" 
Me.txtV6.MaxLength = 27
Me.lblM1.Location = New System.Drawing.Point(440,99)
Me.lblM1.name = "lblM1"
Me.lblM1.Size = New System.Drawing.Size(200, 20)
Me.lblM1.TabIndex = 41
Me.lblM1.Text = "Масса воды по каналу 1"
Me.lblM1.ForeColor = System.Drawing.Color.Blue
Me.txtM1.Location = New System.Drawing.Point(440,121)
Me.txtM1.name = "txtM1"
Me.txtM1.MultiLine = false
Me.txtM1.Size = New System.Drawing.Size(200,  20)
Me.txtM1.TabIndex = 42
Me.txtM1.Text = "" 
Me.txtM1.MaxLength = 27
Me.lblM2.Location = New System.Drawing.Point(440,146)
Me.lblM2.name = "lblM2"
Me.lblM2.Size = New System.Drawing.Size(200, 20)
Me.lblM2.TabIndex = 43
Me.lblM2.Text = "Масса воды по каналу 2"
Me.lblM2.ForeColor = System.Drawing.Color.Blue
Me.txtM2.Location = New System.Drawing.Point(440,168)
Me.txtM2.name = "txtM2"
Me.txtM2.MultiLine = false
Me.txtM2.Size = New System.Drawing.Size(200,  20)
Me.txtM2.TabIndex = 44
Me.txtM2.Text = "" 
Me.txtM2.MaxLength = 27
Me.lblDM12.Location = New System.Drawing.Point(440,193)
Me.lblDM12.name = "lblDM12"
Me.lblDM12.Size = New System.Drawing.Size(200, 20)
Me.lblDM12.TabIndex = 45
Me.lblDM12.Text = "Разность масс канал 1  (расход ГВС)"
Me.lblDM12.ForeColor = System.Drawing.Color.Blue
Me.txtDM12.Location = New System.Drawing.Point(440,215)
Me.txtDM12.name = "txtDM12"
Me.txtDM12.MultiLine = false
Me.txtDM12.Size = New System.Drawing.Size(200,  20)
Me.txtDM12.TabIndex = 46
Me.txtDM12.Text = "" 
Me.txtDM12.MaxLength = 27
Me.lblM3.Location = New System.Drawing.Point(440,240)
Me.lblM3.name = "lblM3"
Me.lblM3.Size = New System.Drawing.Size(200, 20)
Me.lblM3.TabIndex = 47
Me.lblM3.Text = "Масса воды по каналу 3"
Me.lblM3.ForeColor = System.Drawing.Color.Blue
Me.txtM3.Location = New System.Drawing.Point(440,262)
Me.txtM3.name = "txtM3"
Me.txtM3.MultiLine = false
Me.txtM3.Size = New System.Drawing.Size(200,  20)
Me.txtM3.TabIndex = 48
Me.txtM3.Text = "" 
Me.txtM3.MaxLength = 27
Me.lblM4.Location = New System.Drawing.Point(440,287)
Me.lblM4.name = "lblM4"
Me.lblM4.Size = New System.Drawing.Size(200, 20)
Me.lblM4.TabIndex = 49
Me.lblM4.Text = "Масса воды по каналу 4"
Me.lblM4.ForeColor = System.Drawing.Color.Blue
Me.txtM4.Location = New System.Drawing.Point(440,309)
Me.txtM4.name = "txtM4"
Me.txtM4.MultiLine = false
Me.txtM4.Size = New System.Drawing.Size(200,  20)
Me.txtM4.TabIndex = 50
Me.txtM4.Text = "" 
Me.txtM4.MaxLength = 27
Me.lblM5.Location = New System.Drawing.Point(440,334)
Me.lblM5.name = "lblM5"
Me.lblM5.Size = New System.Drawing.Size(200, 20)
Me.lblM5.TabIndex = 51
Me.lblM5.Text = "Масса воды по каналу 5"
Me.lblM5.ForeColor = System.Drawing.Color.Blue
Me.txtM5.Location = New System.Drawing.Point(440,356)
Me.txtM5.name = "txtM5"
Me.txtM5.MultiLine = false
Me.txtM5.Size = New System.Drawing.Size(200,  20)
Me.txtM5.TabIndex = 52
Me.txtM5.Text = "" 
Me.txtM5.MaxLength = 27
Me.lblDM45.Location = New System.Drawing.Point(440,381)
Me.lblDM45.name = "lblDM45"
Me.lblDM45.Size = New System.Drawing.Size(200, 20)
Me.lblDM45.TabIndex = 53
Me.lblDM45.Text = "Разность масс канал 2"
Me.lblDM45.ForeColor = System.Drawing.Color.Blue
Me.txtDM45.Location = New System.Drawing.Point(440,403)
Me.txtDM45.name = "txtDM45"
Me.txtDM45.MultiLine = false
Me.txtDM45.Size = New System.Drawing.Size(200,  20)
Me.txtDM45.TabIndex = 54
Me.txtDM45.Text = "" 
Me.txtDM45.MaxLength = 27
Me.lblM6.Location = New System.Drawing.Point(650,5)
Me.lblM6.name = "lblM6"
Me.lblM6.Size = New System.Drawing.Size(200, 20)
Me.lblM6.TabIndex = 55
Me.lblM6.Text = "Масса воды по каналу 6"
Me.lblM6.ForeColor = System.Drawing.Color.Blue
Me.txtM6.Location = New System.Drawing.Point(650,27)
Me.txtM6.name = "txtM6"
Me.txtM6.MultiLine = false
Me.txtM6.Size = New System.Drawing.Size(200,  20)
Me.txtM6.TabIndex = 56
Me.txtM6.Text = "" 
Me.txtM6.MaxLength = 27
Me.lblP1.Location = New System.Drawing.Point(650,52)
Me.lblP1.name = "lblP1"
Me.lblP1.Size = New System.Drawing.Size(200, 20)
Me.lblP1.TabIndex = 57
Me.lblP1.Text = "Давление в трубопроводе 1"
Me.lblP1.ForeColor = System.Drawing.Color.Blue
Me.txtP1.Location = New System.Drawing.Point(650,74)
Me.txtP1.name = "txtP1"
Me.txtP1.MultiLine = false
Me.txtP1.Size = New System.Drawing.Size(200,  20)
Me.txtP1.TabIndex = 58
Me.txtP1.Text = "" 
Me.txtP1.MaxLength = 27
Me.lblP2.Location = New System.Drawing.Point(650,99)
Me.lblP2.name = "lblP2"
Me.lblP2.Size = New System.Drawing.Size(200, 20)
Me.lblP2.TabIndex = 59
Me.lblP2.Text = "Давление в трубопроводе 2"
Me.lblP2.ForeColor = System.Drawing.Color.Blue
Me.txtP2.Location = New System.Drawing.Point(650,121)
Me.txtP2.name = "txtP2"
Me.txtP2.MultiLine = false
Me.txtP2.Size = New System.Drawing.Size(200,  20)
Me.txtP2.TabIndex = 60
Me.txtP2.Text = "" 
Me.txtP2.MaxLength = 27
Me.lblP3.Location = New System.Drawing.Point(650,146)
Me.lblP3.name = "lblP3"
Me.lblP3.Size = New System.Drawing.Size(200, 20)
Me.lblP3.TabIndex = 61
Me.lblP3.Text = "Давление в трубопроводе 3"
Me.lblP3.ForeColor = System.Drawing.Color.Blue
Me.txtP3.Location = New System.Drawing.Point(650,168)
Me.txtP3.name = "txtP3"
Me.txtP3.MultiLine = false
Me.txtP3.Size = New System.Drawing.Size(200,  20)
Me.txtP3.TabIndex = 62
Me.txtP3.Text = "" 
Me.txtP3.MaxLength = 27
Me.lblP4.Location = New System.Drawing.Point(650,193)
Me.lblP4.name = "lblP4"
Me.lblP4.Size = New System.Drawing.Size(200, 20)
Me.lblP4.TabIndex = 63
Me.lblP4.Text = "Давление в трубопроводе 4"
Me.lblP4.ForeColor = System.Drawing.Color.Blue
Me.txtP4.Location = New System.Drawing.Point(650,215)
Me.txtP4.name = "txtP4"
Me.txtP4.MultiLine = false
Me.txtP4.Size = New System.Drawing.Size(200,  20)
Me.txtP4.TabIndex = 64
Me.txtP4.Text = "" 
Me.txtP4.MaxLength = 27
Me.lblP5.Location = New System.Drawing.Point(650,240)
Me.lblP5.name = "lblP5"
Me.lblP5.Size = New System.Drawing.Size(200, 20)
Me.lblP5.TabIndex = 65
Me.lblP5.Text = "Давление в трубопроводе 5"
Me.lblP5.ForeColor = System.Drawing.Color.Blue
Me.txtP5.Location = New System.Drawing.Point(650,262)
Me.txtP5.name = "txtP5"
Me.txtP5.MultiLine = false
Me.txtP5.Size = New System.Drawing.Size(200,  20)
Me.txtP5.TabIndex = 66
Me.txtP5.Text = "" 
Me.txtP5.MaxLength = 27
Me.lblP6.Location = New System.Drawing.Point(650,287)
Me.lblP6.name = "lblP6"
Me.lblP6.Size = New System.Drawing.Size(200, 20)
Me.lblP6.TabIndex = 67
Me.lblP6.Text = "Давление в трубопроводе 6"
Me.lblP6.ForeColor = System.Drawing.Color.Blue
Me.txtP6.Location = New System.Drawing.Point(650,309)
Me.txtP6.name = "txtP6"
Me.txtP6.MultiLine = false
Me.txtP6.Size = New System.Drawing.Size(200,  20)
Me.txtP6.TabIndex = 68
Me.txtP6.Text = "" 
Me.txtP6.MaxLength = 27
Me.lblG1.Location = New System.Drawing.Point(650,334)
Me.lblG1.name = "lblG1"
Me.lblG1.Size = New System.Drawing.Size(200, 20)
Me.lblG1.TabIndex = 69
Me.lblG1.Text = "Текущее значение расхода в трубопроводе 1"
Me.lblG1.ForeColor = System.Drawing.Color.Blue
Me.txtG1.Location = New System.Drawing.Point(650,356)
Me.txtG1.name = "txtG1"
Me.txtG1.MultiLine = false
Me.txtG1.Size = New System.Drawing.Size(200,  20)
Me.txtG1.TabIndex = 70
Me.txtG1.Text = "" 
Me.txtG1.MaxLength = 27
Me.lblG2.Location = New System.Drawing.Point(650,381)
Me.lblG2.name = "lblG2"
Me.lblG2.Size = New System.Drawing.Size(200, 20)
Me.lblG2.TabIndex = 71
Me.lblG2.Text = "Текущее значение расхода в трубопроводе 2"
Me.lblG2.ForeColor = System.Drawing.Color.Blue
Me.txtG2.Location = New System.Drawing.Point(650,403)
Me.txtG2.name = "txtG2"
Me.txtG2.MultiLine = false
Me.txtG2.Size = New System.Drawing.Size(200,  20)
Me.txtG2.TabIndex = 72
Me.txtG2.Text = "" 
Me.txtG2.MaxLength = 27
Me.lblG3.Location = New System.Drawing.Point(860,5)
Me.lblG3.name = "lblG3"
Me.lblG3.Size = New System.Drawing.Size(200, 20)
Me.lblG3.TabIndex = 73
Me.lblG3.Text = "Текущее значение расхода в трубопроводе 3"
Me.lblG3.ForeColor = System.Drawing.Color.Blue
Me.txtG3.Location = New System.Drawing.Point(860,27)
Me.txtG3.name = "txtG3"
Me.txtG3.MultiLine = false
Me.txtG3.Size = New System.Drawing.Size(200,  20)
Me.txtG3.TabIndex = 74
Me.txtG3.Text = "" 
Me.txtG3.MaxLength = 27
Me.lblG4.Location = New System.Drawing.Point(860,52)
Me.lblG4.name = "lblG4"
Me.lblG4.Size = New System.Drawing.Size(200, 20)
Me.lblG4.TabIndex = 75
Me.lblG4.Text = "Текущее значение расхода в трубопроводе 4"
Me.lblG4.ForeColor = System.Drawing.Color.Blue
Me.txtG4.Location = New System.Drawing.Point(860,74)
Me.txtG4.name = "txtG4"
Me.txtG4.MultiLine = false
Me.txtG4.Size = New System.Drawing.Size(200,  20)
Me.txtG4.TabIndex = 76
Me.txtG4.Text = "" 
Me.txtG4.MaxLength = 27
Me.lblG5.Location = New System.Drawing.Point(860,99)
Me.lblG5.name = "lblG5"
Me.lblG5.Size = New System.Drawing.Size(200, 20)
Me.lblG5.TabIndex = 77
Me.lblG5.Text = "Текущее значение расхода в трубопроводе 5"
Me.lblG5.ForeColor = System.Drawing.Color.Blue
Me.txtG5.Location = New System.Drawing.Point(860,121)
Me.txtG5.name = "txtG5"
Me.txtG5.MultiLine = false
Me.txtG5.Size = New System.Drawing.Size(200,  20)
Me.txtG5.TabIndex = 78
Me.txtG5.Text = "" 
Me.txtG5.MaxLength = 27
Me.lblG6.Location = New System.Drawing.Point(860,146)
Me.lblG6.name = "lblG6"
Me.lblG6.Size = New System.Drawing.Size(200, 20)
Me.lblG6.TabIndex = 79
Me.lblG6.Text = "Текущее значение расхода в трубопроводе 6"
Me.lblG6.ForeColor = System.Drawing.Color.Blue
Me.txtG6.Location = New System.Drawing.Point(860,168)
Me.txtG6.name = "txtG6"
Me.txtG6.MultiLine = false
Me.txtG6.Size = New System.Drawing.Size(200,  20)
Me.txtG6.TabIndex = 80
Me.txtG6.Text = "" 
Me.txtG6.MaxLength = 27
Me.lblTCOOL.Location = New System.Drawing.Point(860,193)
Me.lblTCOOL.name = "lblTCOOL"
Me.lblTCOOL.Size = New System.Drawing.Size(200, 20)
Me.lblTCOOL.TabIndex = 81
Me.lblTCOOL.Text = "Температура холодной воды"
Me.lblTCOOL.ForeColor = System.Drawing.Color.Blue
Me.txtTCOOL.Location = New System.Drawing.Point(860,215)
Me.txtTCOOL.name = "txtTCOOL"
Me.txtTCOOL.MultiLine = false
Me.txtTCOOL.Size = New System.Drawing.Size(200,  20)
Me.txtTCOOL.TabIndex = 82
Me.txtTCOOL.Text = "" 
Me.txtTCOOL.MaxLength = 27
Me.lblTCE1.Location = New System.Drawing.Point(860,240)
Me.lblTCE1.name = "lblTCE1"
Me.lblTCE1.Size = New System.Drawing.Size(200, 20)
Me.lblTCE1.TabIndex = 83
Me.lblTCE1.Text = "Температура холодного конца канал 1"
Me.lblTCE1.ForeColor = System.Drawing.Color.Blue
Me.txtTCE1.Location = New System.Drawing.Point(860,262)
Me.txtTCE1.name = "txtTCE1"
Me.txtTCE1.MultiLine = false
Me.txtTCE1.Size = New System.Drawing.Size(200,  20)
Me.txtTCE1.TabIndex = 84
Me.txtTCE1.Text = "" 
Me.txtTCE1.MaxLength = 27
Me.lblTCE2.Location = New System.Drawing.Point(860,287)
Me.lblTCE2.name = "lblTCE2"
Me.lblTCE2.Size = New System.Drawing.Size(200, 20)
Me.lblTCE2.TabIndex = 85
Me.lblTCE2.Text = "Температура холодного конца канал 2"
Me.lblTCE2.ForeColor = System.Drawing.Color.Blue
Me.txtTCE2.Location = New System.Drawing.Point(860,309)
Me.txtTCE2.name = "txtTCE2"
Me.txtTCE2.MultiLine = false
Me.txtTCE2.Size = New System.Drawing.Size(200,  20)
Me.txtTCE2.TabIndex = 86
Me.txtTCE2.Text = "" 
Me.txtTCE2.MaxLength = 27
Me.lblTSUM1.Location = New System.Drawing.Point(860,334)
Me.lblTSUM1.name = "lblTSUM1"
Me.lblTSUM1.Size = New System.Drawing.Size(200, 20)
Me.lblTSUM1.TabIndex = 87
Me.lblTSUM1.Text = "Тотальное время счета TB1"
Me.lblTSUM1.ForeColor = System.Drawing.Color.Blue
Me.txtTSUM1.Location = New System.Drawing.Point(860,356)
Me.txtTSUM1.name = "txtTSUM1"
Me.txtTSUM1.MultiLine = false
Me.txtTSUM1.Size = New System.Drawing.Size(200,  20)
Me.txtTSUM1.TabIndex = 88
Me.txtTSUM1.Text = "" 
Me.txtTSUM1.MaxLength = 27
Me.lblTSUM2.Location = New System.Drawing.Point(860,381)
Me.lblTSUM2.name = "lblTSUM2"
Me.lblTSUM2.Size = New System.Drawing.Size(200, 20)
Me.lblTSUM2.TabIndex = 89
Me.lblTSUM2.Text = "Тотальное время счета TB2"
Me.lblTSUM2.ForeColor = System.Drawing.Color.Blue
Me.txtTSUM2.Location = New System.Drawing.Point(860,403)
Me.txtTSUM2.name = "txtTSUM2"
Me.txtTSUM2.MultiLine = false
Me.txtTSUM2.Size = New System.Drawing.Size(200,  20)
Me.txtTSUM2.TabIndex = 90
Me.txtTSUM2.Text = "" 
Me.txtTSUM2.MaxLength = 27
Me.lblQ1H.Location = New System.Drawing.Point(1070,5)
Me.lblQ1H.name = "lblQ1H"
Me.lblQ1H.Size = New System.Drawing.Size(200, 20)
Me.lblQ1H.TabIndex = 91
Me.lblQ1H.Text = "Тепловая энергия канал 1 нарастающим итогом"
Me.lblQ1H.ForeColor = System.Drawing.Color.Blue
Me.txtQ1H.Location = New System.Drawing.Point(1070,27)
Me.txtQ1H.name = "txtQ1H"
Me.txtQ1H.MultiLine = false
Me.txtQ1H.Size = New System.Drawing.Size(200,  20)
Me.txtQ1H.TabIndex = 92
Me.txtQ1H.Text = "" 
Me.txtQ1H.MaxLength = 27
Me.lblQ2H.Location = New System.Drawing.Point(1070,52)
Me.lblQ2H.name = "lblQ2H"
Me.lblQ2H.Size = New System.Drawing.Size(200, 20)
Me.lblQ2H.TabIndex = 93
Me.lblQ2H.Text = "Тепловая энергия канал 2 нарастающим итогом"
Me.lblQ2H.ForeColor = System.Drawing.Color.Blue
Me.txtQ2H.Location = New System.Drawing.Point(1070,74)
Me.txtQ2H.name = "txtQ2H"
Me.txtQ2H.MultiLine = false
Me.txtQ2H.Size = New System.Drawing.Size(200,  20)
Me.txtQ2H.TabIndex = 94
Me.txtQ2H.Text = "" 
Me.txtQ2H.MaxLength = 27
Me.lblV1H.Location = New System.Drawing.Point(1070,99)
Me.lblV1H.name = "lblV1H"
Me.lblV1H.Size = New System.Drawing.Size(200, 20)
Me.lblV1H.TabIndex = 95
Me.lblV1H.Text = "Объемный расход воды по каналу 1  нарастающим итогом"
Me.lblV1H.ForeColor = System.Drawing.Color.Blue
Me.txtV1H.Location = New System.Drawing.Point(1070,121)
Me.txtV1H.name = "txtV1H"
Me.txtV1H.MultiLine = false
Me.txtV1H.Size = New System.Drawing.Size(200,  20)
Me.txtV1H.TabIndex = 96
Me.txtV1H.Text = "" 
Me.txtV1H.MaxLength = 27
Me.lblV2H.Location = New System.Drawing.Point(1070,146)
Me.lblV2H.name = "lblV2H"
Me.lblV2H.Size = New System.Drawing.Size(200, 20)
Me.lblV2H.TabIndex = 97
Me.lblV2H.Text = "Объемный расход воды по каналу 2  нарастающим итогом"
Me.lblV2H.ForeColor = System.Drawing.Color.Blue
Me.txtV2H.Location = New System.Drawing.Point(1070,168)
Me.txtV2H.name = "txtV2H"
Me.txtV2H.MultiLine = false
Me.txtV2H.Size = New System.Drawing.Size(200,  20)
Me.txtV2H.TabIndex = 98
Me.txtV2H.Text = "" 
Me.txtV2H.MaxLength = 27
Me.lblV4H.Location = New System.Drawing.Point(1070,193)
Me.lblV4H.name = "lblV4H"
Me.lblV4H.Size = New System.Drawing.Size(200, 20)
Me.lblV4H.TabIndex = 99
Me.lblV4H.Text = "Объемный расход воды по каналу 4  нарастающим итогом"
Me.lblV4H.ForeColor = System.Drawing.Color.Blue
Me.txtV4H.Location = New System.Drawing.Point(1070,215)
Me.txtV4H.name = "txtV4H"
Me.txtV4H.MultiLine = false
Me.txtV4H.Size = New System.Drawing.Size(200,  20)
Me.txtV4H.TabIndex = 100
Me.txtV4H.Text = "" 
Me.txtV4H.MaxLength = 27
Me.lblV5H.Location = New System.Drawing.Point(1070,240)
Me.lblV5H.name = "lblV5H"
Me.lblV5H.Size = New System.Drawing.Size(200, 20)
Me.lblV5H.TabIndex = 101
Me.lblV5H.Text = "Объемный расход воды по каналу 5  нарастающим итогом"
Me.lblV5H.ForeColor = System.Drawing.Color.Blue
Me.txtV5H.Location = New System.Drawing.Point(1070,262)
Me.txtV5H.name = "txtV5H"
Me.txtV5H.MultiLine = false
Me.txtV5H.Size = New System.Drawing.Size(200,  20)
Me.txtV5H.TabIndex = 102
Me.txtV5H.Text = "" 
Me.txtV5H.MaxLength = 27
Me.lblERRTIME.Location = New System.Drawing.Point(1070,287)
Me.lblERRTIME.name = "lblERRTIME"
Me.lblERRTIME.Size = New System.Drawing.Size(200, 20)
Me.lblERRTIME.TabIndex = 103
Me.lblERRTIME.Text = "Время аварии"
Me.lblERRTIME.ForeColor = System.Drawing.Color.Blue
Me.txtERRTIME.Location = New System.Drawing.Point(1070,309)
Me.txtERRTIME.name = "txtERRTIME"
Me.txtERRTIME.MultiLine = false
Me.txtERRTIME.Size = New System.Drawing.Size(200,  20)
Me.txtERRTIME.TabIndex = 104
Me.txtERRTIME.Text = "" 
Me.txtERRTIME.MaxLength = 27
Me.lblERRTIMEH.Location = New System.Drawing.Point(1070,334)
Me.lblERRTIMEH.name = "lblERRTIMEH"
Me.lblERRTIMEH.Size = New System.Drawing.Size(200, 20)
Me.lblERRTIMEH.TabIndex = 105
Me.lblERRTIMEH.Text = "Время аварии нарастающим итогом"
Me.lblERRTIMEH.ForeColor = System.Drawing.Color.Blue
Me.txtERRTIMEH.Location = New System.Drawing.Point(1070,356)
Me.txtERRTIMEH.name = "txtERRTIMEH"
Me.txtERRTIMEH.MultiLine = false
Me.txtERRTIMEH.Size = New System.Drawing.Size(200,  20)
Me.txtERRTIMEH.TabIndex = 106
Me.txtERRTIMEH.Text = "" 
Me.txtERRTIMEH.MaxLength = 27
Me.lblHC.Location = New System.Drawing.Point(1070,381)
Me.lblHC.name = "lblHC"
Me.lblHC.Size = New System.Drawing.Size(200, 20)
Me.lblHC.TabIndex = 107
Me.lblHC.Text = "Нештатные ситуации общ"
Me.lblHC.ForeColor = System.Drawing.Color.Blue
Me.txtHC.Location = New System.Drawing.Point(1070,403)
Me.txtHC.name = "txtHC"
Me.txtHC.Size = New System.Drawing.Size(200, 20)
Me.txtHC.TabIndex = 108
Me.txtHC.Text = "" 
Me.lblSP.Location = New System.Drawing.Point(1280,5)
Me.lblSP.name = "lblSP"
Me.lblSP.Size = New System.Drawing.Size(200, 20)
Me.lblSP.TabIndex = 109
Me.lblSP.Text = "Схема потребления"
Me.lblSP.ForeColor = System.Drawing.Color.Blue
Me.txtSP.Location = New System.Drawing.Point(1280,27)
Me.txtSP.name = "txtSP"
Me.txtSP.MultiLine = false
Me.txtSP.Size = New System.Drawing.Size(200,  20)
Me.txtSP.TabIndex = 110
Me.txtSP.Text = "" 
Me.txtSP.MaxLength = 27
Me.lblSP_TB1.Location = New System.Drawing.Point(1280,52)
Me.lblSP_TB1.name = "lblSP_TB1"
Me.lblSP_TB1.Size = New System.Drawing.Size(200, 20)
Me.lblSP_TB1.TabIndex = 111
Me.lblSP_TB1.Text = "Схема потребления TB1"
Me.lblSP_TB1.ForeColor = System.Drawing.Color.Blue
Me.txtSP_TB1.Location = New System.Drawing.Point(1280,74)
Me.txtSP_TB1.name = "txtSP_TB1"
Me.txtSP_TB1.MultiLine = false
Me.txtSP_TB1.Size = New System.Drawing.Size(200,  20)
Me.txtSP_TB1.TabIndex = 112
Me.txtSP_TB1.Text = "" 
Me.txtSP_TB1.MaxLength = 27
Me.lblSP_TB2.Location = New System.Drawing.Point(1280,99)
Me.lblSP_TB2.name = "lblSP_TB2"
Me.lblSP_TB2.Size = New System.Drawing.Size(200, 20)
Me.lblSP_TB2.TabIndex = 113
Me.lblSP_TB2.Text = "Схема потребления TB2"
Me.lblSP_TB2.ForeColor = System.Drawing.Color.Blue
Me.txtSP_TB2.Location = New System.Drawing.Point(1280,121)
Me.txtSP_TB2.name = "txtSP_TB2"
Me.txtSP_TB2.MultiLine = false
Me.txtSP_TB2.Size = New System.Drawing.Size(200,  20)
Me.txtSP_TB2.TabIndex = 114
Me.txtSP_TB2.Text = "" 
Me.txtSP_TB2.MaxLength = 27
Me.lbldatetimeCOUNTER.Location = New System.Drawing.Point(1280,146)
Me.lbldatetimeCOUNTER.name = "lbldatetimeCOUNTER"
Me.lbldatetimeCOUNTER.Size = New System.Drawing.Size(200, 20)
Me.lbldatetimeCOUNTER.TabIndex = 115
Me.lbldatetimeCOUNTER.Text = "datetimeCOUNTER"
Me.lbldatetimeCOUNTER.ForeColor = System.Drawing.Color.Blue
Me.dtpdatetimeCOUNTER.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpdatetimeCOUNTER.Location = New System.Drawing.Point(1280,168)
Me.dtpdatetimeCOUNTER.name = "dtpdatetimeCOUNTER"
Me.dtpdatetimeCOUNTER.Size = New System.Drawing.Size(200,  20)
Me.dtpdatetimeCOUNTER.TabIndex =116
Me.dtpdatetimeCOUNTER.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpdatetimeCOUNTER.ShowCheckBox=True
Me.lblDG12.Location = New System.Drawing.Point(1280,193)
Me.lblDG12.name = "lblDG12"
Me.lblDG12.Size = New System.Drawing.Size(200, 20)
Me.lblDG12.TabIndex = 117
Me.lblDG12.Text = "G1-G2"
Me.lblDG12.ForeColor = System.Drawing.Color.Blue
Me.txtDG12.Location = New System.Drawing.Point(1280,215)
Me.txtDG12.name = "txtDG12"
Me.txtDG12.MultiLine = false
Me.txtDG12.Size = New System.Drawing.Size(200,  20)
Me.txtDG12.TabIndex = 118
Me.txtDG12.Text = "" 
Me.txtDG12.MaxLength = 27
Me.lblDG45.Location = New System.Drawing.Point(1280,240)
Me.lblDG45.name = "lblDG45"
Me.lblDG45.Size = New System.Drawing.Size(200, 20)
Me.lblDG45.TabIndex = 119
Me.lblDG45.Text = "G4-G5"
Me.lblDG45.ForeColor = System.Drawing.Color.Blue
Me.txtDG45.Location = New System.Drawing.Point(1280,262)
Me.txtDG45.name = "txtDG45"
Me.txtDG45.MultiLine = false
Me.txtDG45.Size = New System.Drawing.Size(200,  20)
Me.txtDG45.TabIndex = 120
Me.txtDG45.Text = "" 
Me.txtDG45.MaxLength = 27
Me.lblDP12.Location = New System.Drawing.Point(1280,287)
Me.lblDP12.name = "lblDP12"
Me.lblDP12.Size = New System.Drawing.Size(200, 20)
Me.lblDP12.TabIndex = 121
Me.lblDP12.Text = "P1-P2"
Me.lblDP12.ForeColor = System.Drawing.Color.Blue
Me.txtDP12.Location = New System.Drawing.Point(1280,309)
Me.txtDP12.name = "txtDP12"
Me.txtDP12.MultiLine = false
Me.txtDP12.Size = New System.Drawing.Size(200,  20)
Me.txtDP12.TabIndex = 122
Me.txtDP12.Text = "" 
Me.txtDP12.MaxLength = 27
Me.lblDP45.Location = New System.Drawing.Point(1280,334)
Me.lblDP45.name = "lblDP45"
Me.lblDP45.Size = New System.Drawing.Size(200, 20)
Me.lblDP45.TabIndex = 123
Me.lblDP45.Text = "P4-P5"
Me.lblDP45.ForeColor = System.Drawing.Color.Blue
Me.txtDP45.Location = New System.Drawing.Point(1280,356)
Me.txtDP45.name = "txtDP45"
Me.txtDP45.MultiLine = false
Me.txtDP45.Size = New System.Drawing.Size(200,  20)
Me.txtDP45.TabIndex = 124
Me.txtDP45.Text = "" 
Me.txtDP45.MaxLength = 27
Me.lblUNITSR.Location = New System.Drawing.Point(1280,381)
Me.lblUNITSR.name = "lblUNITSR"
Me.lblUNITSR.Size = New System.Drawing.Size(200, 20)
Me.lblUNITSR.TabIndex = 125
Me.lblUNITSR.Text = "Единицы измерения расхода"
Me.lblUNITSR.ForeColor = System.Drawing.Color.Blue
Me.txtUNITSR.Location = New System.Drawing.Point(1280,403)
Me.txtUNITSR.name = "txtUNITSR"
Me.txtUNITSR.Size = New System.Drawing.Size(200, 20)
Me.txtUNITSR.TabIndex = 126
Me.txtUNITSR.Text = "" 
Me.lblQ3.Location = New System.Drawing.Point(1490,5)
Me.lblQ3.name = "lblQ3"
Me.lblQ3.Size = New System.Drawing.Size(200, 20)
Me.lblQ3.TabIndex = 127
Me.lblQ3.Text = "Тепловая энергия канал 3"
Me.lblQ3.ForeColor = System.Drawing.Color.Blue
Me.txtQ3.Location = New System.Drawing.Point(1490,27)
Me.txtQ3.name = "txtQ3"
Me.txtQ3.MultiLine = false
Me.txtQ3.Size = New System.Drawing.Size(200,  20)
Me.txtQ3.TabIndex = 128
Me.txtQ3.Text = "" 
Me.txtQ3.MaxLength = 27
Me.lblQ4.Location = New System.Drawing.Point(1490,52)
Me.lblQ4.name = "lblQ4"
Me.lblQ4.Size = New System.Drawing.Size(200, 20)
Me.lblQ4.TabIndex = 129
Me.lblQ4.Text = "Тепловая энергия канал 4"
Me.lblQ4.ForeColor = System.Drawing.Color.Blue
Me.txtQ4.Location = New System.Drawing.Point(1490,74)
Me.txtQ4.name = "txtQ4"
Me.txtQ4.MultiLine = false
Me.txtQ4.Size = New System.Drawing.Size(200,  20)
Me.txtQ4.TabIndex = 130
Me.txtQ4.Text = "" 
Me.txtQ4.MaxLength = 27
Me.lblPATM.Location = New System.Drawing.Point(1490,99)
Me.lblPATM.name = "lblPATM"
Me.lblPATM.Size = New System.Drawing.Size(200, 20)
Me.lblPATM.TabIndex = 131
Me.lblPATM.Text = "Атмосферное давление"
Me.lblPATM.ForeColor = System.Drawing.Color.Blue
Me.txtPATM.Location = New System.Drawing.Point(1490,121)
Me.txtPATM.name = "txtPATM"
Me.txtPATM.MultiLine = false
Me.txtPATM.Size = New System.Drawing.Size(200,  20)
Me.txtPATM.TabIndex = 132
Me.txtPATM.Text = "" 
Me.txtPATM.MaxLength = 27
Me.lblQ5.Location = New System.Drawing.Point(1490,146)
Me.lblQ5.name = "lblQ5"
Me.lblQ5.Size = New System.Drawing.Size(200, 20)
Me.lblQ5.TabIndex = 133
Me.lblQ5.Text = "Тепловая энергия канал 5"
Me.lblQ5.ForeColor = System.Drawing.Color.Blue
Me.txtQ5.Location = New System.Drawing.Point(1490,168)
Me.txtQ5.name = "txtQ5"
Me.txtQ5.MultiLine = false
Me.txtQ5.Size = New System.Drawing.Size(200,  20)
Me.txtQ5.TabIndex = 134
Me.txtQ5.Text = "" 
Me.txtQ5.MaxLength = 27
Me.lblDQ12.Location = New System.Drawing.Point(1490,193)
Me.lblDQ12.name = "lblDQ12"
Me.lblDQ12.Size = New System.Drawing.Size(200, 20)
Me.lblDQ12.TabIndex = 135
Me.lblDQ12.Text = "Тепловая энергия потребитель 1"
Me.lblDQ12.ForeColor = System.Drawing.Color.Blue
Me.txtDQ12.Location = New System.Drawing.Point(1490,215)
Me.txtDQ12.name = "txtDQ12"
Me.txtDQ12.MultiLine = false
Me.txtDQ12.Size = New System.Drawing.Size(200,  20)
Me.txtDQ12.TabIndex = 136
Me.txtDQ12.Text = "" 
Me.txtDQ12.MaxLength = 27
Me.lblDQ45.Location = New System.Drawing.Point(1490,240)
Me.lblDQ45.name = "lblDQ45"
Me.lblDQ45.Size = New System.Drawing.Size(200, 20)
Me.lblDQ45.TabIndex = 137
Me.lblDQ45.Text = "Тепловая энергия потребитель 2"
Me.lblDQ45.ForeColor = System.Drawing.Color.Blue
Me.txtDQ45.Location = New System.Drawing.Point(1490,262)
Me.txtDQ45.name = "txtDQ45"
Me.txtDQ45.MultiLine = false
Me.txtDQ45.Size = New System.Drawing.Size(200,  20)
Me.txtDQ45.TabIndex = 138
Me.txtDQ45.Text = "" 
Me.txtDQ45.MaxLength = 27
Me.lblPXB.Location = New System.Drawing.Point(1490,287)
Me.lblPXB.name = "lblPXB"
Me.lblPXB.Size = New System.Drawing.Size(200, 20)
Me.lblPXB.TabIndex = 139
Me.lblPXB.Text = "Давление холодной воды"
Me.lblPXB.ForeColor = System.Drawing.Color.Blue
Me.txtPXB.Location = New System.Drawing.Point(1490,309)
Me.txtPXB.name = "txtPXB"
Me.txtPXB.MultiLine = false
Me.txtPXB.Size = New System.Drawing.Size(200,  20)
Me.txtPXB.TabIndex = 140
Me.txtPXB.Text = "" 
Me.txtPXB.MaxLength = 27
Me.lblDQ.Location = New System.Drawing.Point(1490,334)
Me.lblDQ.name = "lblDQ"
Me.lblDQ.Size = New System.Drawing.Size(200, 20)
Me.lblDQ.TabIndex = 141
Me.lblDQ.Text = "Расход энергии потребитель 1"
Me.lblDQ.ForeColor = System.Drawing.Color.Blue
Me.txtDQ.Location = New System.Drawing.Point(1490,356)
Me.txtDQ.name = "txtDQ"
Me.txtDQ.MultiLine = false
Me.txtDQ.Size = New System.Drawing.Size(200,  20)
Me.txtDQ.TabIndex = 142
Me.txtDQ.Text = "" 
Me.txtDQ.MaxLength = 27
Me.lblHC_1.Location = New System.Drawing.Point(1490,381)
Me.lblHC_1.name = "lblHC_1"
Me.lblHC_1.Size = New System.Drawing.Size(200, 20)
Me.lblHC_1.TabIndex = 143
Me.lblHC_1.Text = "Нештатная ситуация 1 (ТВ1 или внешняя)"
Me.lblHC_1.ForeColor = System.Drawing.Color.Blue
Me.txtHC_1.Location = New System.Drawing.Point(1490,403)
Me.txtHC_1.name = "txtHC_1"
Me.txtHC_1.Size = New System.Drawing.Size(200, 20)
Me.txtHC_1.TabIndex = 144
Me.txtHC_1.Text = "" 
Me.lblHC_2.Location = New System.Drawing.Point(1700,5)
Me.lblHC_2.name = "lblHC_2"
Me.lblHC_2.Size = New System.Drawing.Size(200, 20)
Me.lblHC_2.TabIndex = 145
Me.lblHC_2.Text = "Нештатная ситуация 2 (ТВ2 или внутренняя)"
Me.lblHC_2.ForeColor = System.Drawing.Color.Blue
Me.txtHC_2.Location = New System.Drawing.Point(1700,27)
Me.txtHC_2.name = "txtHC_2"
Me.txtHC_2.Size = New System.Drawing.Size(200, 20)
Me.txtHC_2.TabIndex = 146
Me.txtHC_2.Text = "" 
Me.lblTHOT.Location = New System.Drawing.Point(1700,52)
Me.lblTHOT.name = "lblTHOT"
Me.lblTHOT.Size = New System.Drawing.Size(200, 20)
Me.lblTHOT.TabIndex = 147
Me.lblTHOT.Text = "Температура горячей воды"
Me.lblTHOT.ForeColor = System.Drawing.Color.Blue
Me.txtTHOT.Location = New System.Drawing.Point(1700,74)
Me.txtTHOT.name = "txtTHOT"
Me.txtTHOT.MultiLine = false
Me.txtTHOT.Size = New System.Drawing.Size(200,  20)
Me.txtTHOT.TabIndex = 148
Me.txtTHOT.Text = "" 
Me.txtTHOT.MaxLength = 27
Me.lblDANS1.Location = New System.Drawing.Point(1700,99)
Me.lblDANS1.name = "lblDANS1"
Me.lblDANS1.Size = New System.Drawing.Size(200, 20)
Me.lblDANS1.TabIndex = 149
Me.lblDANS1.Text = "DANS1"
Me.lblDANS1.ForeColor = System.Drawing.Color.Blue
Me.txtDANS1.Location = New System.Drawing.Point(1700,121)
Me.txtDANS1.name = "txtDANS1"
Me.txtDANS1.MultiLine = false
Me.txtDANS1.Size = New System.Drawing.Size(200,  20)
Me.txtDANS1.TabIndex = 150
Me.txtDANS1.Text = "" 
Me.txtDANS1.MaxLength = 27
Me.lblDANS2.Location = New System.Drawing.Point(1700,146)
Me.lblDANS2.name = "lblDANS2"
Me.lblDANS2.Size = New System.Drawing.Size(200, 20)
Me.lblDANS2.TabIndex = 151
Me.lblDANS2.Text = "DANS2"
Me.lblDANS2.ForeColor = System.Drawing.Color.Blue
Me.txtDANS2.Location = New System.Drawing.Point(1700,168)
Me.txtDANS2.name = "txtDANS2"
Me.txtDANS2.MultiLine = false
Me.txtDANS2.Size = New System.Drawing.Size(200,  20)
Me.txtDANS2.TabIndex = 152
Me.txtDANS2.Text = "" 
Me.txtDANS2.MaxLength = 27
Me.lblDANS3.Location = New System.Drawing.Point(1700,193)
Me.lblDANS3.name = "lblDANS3"
Me.lblDANS3.Size = New System.Drawing.Size(200, 20)
Me.lblDANS3.TabIndex = 153
Me.lblDANS3.Text = "DANS3"
Me.lblDANS3.ForeColor = System.Drawing.Color.Blue
Me.txtDANS3.Location = New System.Drawing.Point(1700,215)
Me.txtDANS3.name = "txtDANS3"
Me.txtDANS3.MultiLine = false
Me.txtDANS3.Size = New System.Drawing.Size(200,  20)
Me.txtDANS3.TabIndex = 154
Me.txtDANS3.Text = "" 
Me.txtDANS3.MaxLength = 27
Me.lblDANS4.Location = New System.Drawing.Point(1700,240)
Me.lblDANS4.name = "lblDANS4"
Me.lblDANS4.Size = New System.Drawing.Size(200, 20)
Me.lblDANS4.TabIndex = 155
Me.lblDANS4.Text = "DANS4"
Me.lblDANS4.ForeColor = System.Drawing.Color.Blue
Me.txtDANS4.Location = New System.Drawing.Point(1700,262)
Me.txtDANS4.name = "txtDANS4"
Me.txtDANS4.MultiLine = false
Me.txtDANS4.Size = New System.Drawing.Size(200,  20)
Me.txtDANS4.TabIndex = 156
Me.txtDANS4.Text = "" 
Me.txtDANS4.MaxLength = 27
Me.lblDANS5.Location = New System.Drawing.Point(1700,287)
Me.lblDANS5.name = "lblDANS5"
Me.lblDANS5.Size = New System.Drawing.Size(200, 20)
Me.lblDANS5.TabIndex = 157
Me.lblDANS5.Text = "DANS5"
Me.lblDANS5.ForeColor = System.Drawing.Color.Blue
Me.txtDANS5.Location = New System.Drawing.Point(1700,309)
Me.txtDANS5.name = "txtDANS5"
Me.txtDANS5.MultiLine = false
Me.txtDANS5.Size = New System.Drawing.Size(200,  20)
Me.txtDANS5.TabIndex = 158
Me.txtDANS5.Text = "" 
Me.txtDANS5.MaxLength = 27
Me.lblDANS6.Location = New System.Drawing.Point(1700,334)
Me.lblDANS6.name = "lblDANS6"
Me.lblDANS6.Size = New System.Drawing.Size(200, 20)
Me.lblDANS6.TabIndex = 159
Me.lblDANS6.Text = "DANS6"
Me.lblDANS6.ForeColor = System.Drawing.Color.Blue
Me.txtDANS6.Location = New System.Drawing.Point(1700,356)
Me.txtDANS6.name = "txtDANS6"
Me.txtDANS6.MultiLine = false
Me.txtDANS6.Size = New System.Drawing.Size(200,  20)
Me.txtDANS6.TabIndex = 160
Me.txtDANS6.Text = "" 
Me.txtDANS6.MaxLength = 27
Me.lblCHECK_A.Location = New System.Drawing.Point(1700,381)
Me.lblCHECK_A.name = "lblCHECK_A"
Me.lblCHECK_A.Size = New System.Drawing.Size(200, 20)
Me.lblCHECK_A.TabIndex = 161
Me.lblCHECK_A.Text = "Проверка архивных данных на НС (0 - не производилась, 1 - произведена)"
Me.lblCHECK_A.ForeColor = System.Drawing.Color.Blue
Me.txtCHECK_A.Location = New System.Drawing.Point(1700,403)
Me.txtCHECK_A.name = "txtCHECK_A"
Me.txtCHECK_A.MultiLine = false
Me.txtCHECK_A.Size = New System.Drawing.Size(200,  20)
Me.txtCHECK_A.TabIndex = 162
Me.txtCHECK_A.Text = "" 
Me.txtCHECK_A.MaxLength = 27
Me.lblOKTIME.Location = New System.Drawing.Point(1910,5)
Me.lblOKTIME.name = "lblOKTIME"
Me.lblOKTIME.Size = New System.Drawing.Size(200, 20)
Me.lblOKTIME.TabIndex = 163
Me.lblOKTIME.Text = "Время безошиб.работы"
Me.lblOKTIME.ForeColor = System.Drawing.Color.Blue
Me.txtOKTIME.Location = New System.Drawing.Point(1910,27)
Me.txtOKTIME.name = "txtOKTIME"
Me.txtOKTIME.MultiLine = false
Me.txtOKTIME.Size = New System.Drawing.Size(200,  20)
Me.txtOKTIME.TabIndex = 164
Me.txtOKTIME.Text = "" 
Me.txtOKTIME.MaxLength = 27
Me.lblWORKTIME.Location = New System.Drawing.Point(1910,52)
Me.lblWORKTIME.name = "lblWORKTIME"
Me.lblWORKTIME.Size = New System.Drawing.Size(200, 20)
Me.lblWORKTIME.TabIndex = 165
Me.lblWORKTIME.Text = "Время работы"
Me.lblWORKTIME.ForeColor = System.Drawing.Color.Blue
Me.txtWORKTIME.Location = New System.Drawing.Point(1910,74)
Me.txtWORKTIME.name = "txtWORKTIME"
Me.txtWORKTIME.MultiLine = false
Me.txtWORKTIME.Size = New System.Drawing.Size(200,  20)
Me.txtWORKTIME.TabIndex = 166
Me.txtWORKTIME.Text = "" 
Me.txtWORKTIME.MaxLength = 27
Me.lblTAIR1.Location = New System.Drawing.Point(1910,99)
Me.lblTAIR1.name = "lblTAIR1"
Me.lblTAIR1.Size = New System.Drawing.Size(200, 20)
Me.lblTAIR1.TabIndex = 167
Me.lblTAIR1.Text = "Температура воздуха канал 1"
Me.lblTAIR1.ForeColor = System.Drawing.Color.Blue
Me.txtTAIR1.Location = New System.Drawing.Point(1910,121)
Me.txtTAIR1.name = "txtTAIR1"
Me.txtTAIR1.MultiLine = false
Me.txtTAIR1.Size = New System.Drawing.Size(200,  20)
Me.txtTAIR1.TabIndex = 168
Me.txtTAIR1.Text = "" 
Me.txtTAIR1.MaxLength = 27
Me.lblTAIR2.Location = New System.Drawing.Point(1910,146)
Me.lblTAIR2.name = "lblTAIR2"
Me.lblTAIR2.Size = New System.Drawing.Size(200, 20)
Me.lblTAIR2.TabIndex = 169
Me.lblTAIR2.Text = "Температура воздуха канал 2"
Me.lblTAIR2.ForeColor = System.Drawing.Color.Blue
Me.txtTAIR2.Location = New System.Drawing.Point(1910,168)
Me.txtTAIR2.name = "txtTAIR2"
Me.txtTAIR2.MultiLine = false
Me.txtTAIR2.Size = New System.Drawing.Size(200,  20)
Me.txtTAIR2.TabIndex = 170
Me.txtTAIR2.Text = "" 
Me.txtTAIR2.MaxLength = 27
Me.lblHC_CODE.Location = New System.Drawing.Point(1910,193)
Me.lblHC_CODE.name = "lblHC_CODE"
Me.lblHC_CODE.Size = New System.Drawing.Size(200, 20)
Me.lblHC_CODE.TabIndex = 171
Me.lblHC_CODE.Text = "Код нештатной ситуации тепловычислителя"
Me.lblHC_CODE.ForeColor = System.Drawing.Color.Blue
Me.txtHC_CODE.Location = New System.Drawing.Point(1910,215)
Me.txtHC_CODE.name = "txtHC_CODE"
Me.txtHC_CODE.Size = New System.Drawing.Size(200, 20)
Me.txtHC_CODE.TabIndex = 172
Me.txtHC_CODE.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDCALL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpDCALL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDCOUNTER)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpDCOUNTER)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblQ1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtQ1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblQ2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtQ2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblT1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtT1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblT2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtT2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDT12)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDT12)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblT3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtT3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblT4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtT4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblT5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtT5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDT45)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDT45)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblT6)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtT6)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblV1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtV1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblV2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtV2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDV12)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDV12)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblV3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtV3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblV4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtV4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblV5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtV5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDV45)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDV45)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblV6)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtV6)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblM1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtM1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblM2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtM2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDM12)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDM12)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblM3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtM3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblM4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtM4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblM5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtM5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDM45)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDM45)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblM6)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtM6)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblP1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtP1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblP2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtP2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblP3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtP3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblP4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtP4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblP5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtP5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblP6)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtP6)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblG1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtG1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblG2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtG2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblG3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtG3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblG4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtG4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblG5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtG5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblG6)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtG6)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTCOOL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTCOOL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTCE1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTCE1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTCE2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTCE2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTSUM1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTSUM1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTSUM2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTSUM2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblQ1H)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtQ1H)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblQ2H)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtQ2H)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblV1H)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtV1H)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblV2H)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtV2H)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblV4H)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtV4H)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblV5H)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtV5H)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblERRTIME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtERRTIME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblERRTIMEH)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtERRTIMEH)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblHC)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtHC)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSP)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSP)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSP_TB1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSP_TB1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSP_TB2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSP_TB2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbldatetimeCOUNTER)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpdatetimeCOUNTER)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDG12)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDG12)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDG45)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDG45)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDP12)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDP12)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDP45)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDP45)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblUNITSR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtUNITSR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblQ3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtQ3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblQ4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtQ4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPATM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPATM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblQ5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtQ5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDQ12)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDQ12)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDQ45)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDQ45)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPXB)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPXB)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDQ)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDQ)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblHC_1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtHC_1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblHC_2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtHC_2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTHOT)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTHOT)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDANS1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDANS1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDANS2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDANS2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDANS3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDANS3)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDANS4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDANS4)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDANS5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDANS5)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDANS6)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDANS6)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCHECK_A)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCHECK_A)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblOKTIME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtOKTIME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblWORKTIME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtWORKTIME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTAIR1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTAIR1)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTAIR2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTAIR2)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblHC_CODE)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtHC_CODE)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLC_M"
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
        Private Sub txtQ1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ1.Validating
        If txtQ1.Text <> "" Then
            try
            If Not IsNumeric(txtQ1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtQ1.Text) < -922337203685478# Or Val(txtQ1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtQ1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQ1.TextChanged
  Changing

end sub
        Private Sub txtQ2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ2.Validating
        If txtQ2.Text <> "" Then
            try
            If Not IsNumeric(txtQ2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtQ2.Text) < -922337203685478# Or Val(txtQ2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtQ2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQ2.TextChanged
  Changing

end sub
        Private Sub txtT1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtT1.Validating
        If txtT1.Text <> "" Then
            try
            If Not IsNumeric(txtT1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtT1.Text) < -922337203685478# Or Val(txtT1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtT1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT1.TextChanged
  Changing

end sub
        Private Sub txtT2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtT2.Validating
        If txtT2.Text <> "" Then
            try
            If Not IsNumeric(txtT2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtT2.Text) < -922337203685478# Or Val(txtT2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtT2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT2.TextChanged
  Changing

end sub
        Private Sub txtDT12_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDT12.Validating
        If txtDT12.Text <> "" Then
            try
            If Not IsNumeric(txtDT12.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDT12.Text) < -922337203685478# Or Val(txtDT12.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDT12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDT12.TextChanged
  Changing

end sub
        Private Sub txtT3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtT3.Validating
        If txtT3.Text <> "" Then
            try
            If Not IsNumeric(txtT3.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtT3.Text) < -922337203685478# Or Val(txtT3.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtT3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT3.TextChanged
  Changing

end sub
        Private Sub txtT4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtT4.Validating
        If txtT4.Text <> "" Then
            try
            If Not IsNumeric(txtT4.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtT4.Text) < -922337203685478# Or Val(txtT4.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtT4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT4.TextChanged
  Changing

end sub
        Private Sub txtT5_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtT5.Validating
        If txtT5.Text <> "" Then
            try
            If Not IsNumeric(txtT5.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtT5.Text) < -922337203685478# Or Val(txtT5.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtT5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT5.TextChanged
  Changing

end sub
        Private Sub txtDT45_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDT45.Validating
        If txtDT45.Text <> "" Then
            try
            If Not IsNumeric(txtDT45.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDT45.Text) < -922337203685478# Or Val(txtDT45.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDT45_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDT45.TextChanged
  Changing

end sub
        Private Sub txtT6_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtT6.Validating
        If txtT6.Text <> "" Then
            try
            If Not IsNumeric(txtT6.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtT6.Text) < -922337203685478# Or Val(txtT6.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtT6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtT6.TextChanged
  Changing

end sub
        Private Sub txtV1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtV1.Validating
        If txtV1.Text <> "" Then
            try
            If Not IsNumeric(txtV1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtV1.Text) < -922337203685478# Or Val(txtV1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtV1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtV1.TextChanged
  Changing

end sub
        Private Sub txtV2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtV2.Validating
        If txtV2.Text <> "" Then
            try
            If Not IsNumeric(txtV2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtV2.Text) < -922337203685478# Or Val(txtV2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtV2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtV2.TextChanged
  Changing

end sub
        Private Sub txtDV12_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDV12.Validating
        If txtDV12.Text <> "" Then
            try
            If Not IsNumeric(txtDV12.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDV12.Text) < -922337203685478# Or Val(txtDV12.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDV12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDV12.TextChanged
  Changing

end sub
        Private Sub txtV3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtV3.Validating
        If txtV3.Text <> "" Then
            try
            If Not IsNumeric(txtV3.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtV3.Text) < -922337203685478# Or Val(txtV3.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtV3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtV3.TextChanged
  Changing

end sub
        Private Sub txtV4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtV4.Validating
        If txtV4.Text <> "" Then
            try
            If Not IsNumeric(txtV4.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtV4.Text) < -922337203685478# Or Val(txtV4.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtV4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtV4.TextChanged
  Changing

end sub
        Private Sub txtV5_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtV5.Validating
        If txtV5.Text <> "" Then
            try
            If Not IsNumeric(txtV5.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtV5.Text) < -922337203685478# Or Val(txtV5.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtV5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtV5.TextChanged
  Changing

end sub
        Private Sub txtDV45_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDV45.Validating
        If txtDV45.Text <> "" Then
            try
            If Not IsNumeric(txtDV45.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDV45.Text) < -922337203685478# Or Val(txtDV45.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDV45_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDV45.TextChanged
  Changing

end sub
        Private Sub txtV6_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtV6.Validating
        If txtV6.Text <> "" Then
            try
            If Not IsNumeric(txtV6.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtV6.Text) < -922337203685478# Or Val(txtV6.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtV6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtV6.TextChanged
  Changing

end sub
        Private Sub txtM1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtM1.Validating
        If txtM1.Text <> "" Then
            try
            If Not IsNumeric(txtM1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtM1.Text) < -922337203685478# Or Val(txtM1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtM1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM1.TextChanged
  Changing

end sub
        Private Sub txtM2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtM2.Validating
        If txtM2.Text <> "" Then
            try
            If Not IsNumeric(txtM2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtM2.Text) < -922337203685478# Or Val(txtM2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtM2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM2.TextChanged
  Changing

end sub
        Private Sub txtDM12_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDM12.Validating
        If txtDM12.Text <> "" Then
            try
            If Not IsNumeric(txtDM12.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDM12.Text) < -922337203685478# Or Val(txtDM12.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDM12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDM12.TextChanged
  Changing

end sub
        Private Sub txtM3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtM3.Validating
        If txtM3.Text <> "" Then
            try
            If Not IsNumeric(txtM3.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtM3.Text) < -922337203685478# Or Val(txtM3.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtM3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM3.TextChanged
  Changing

end sub
        Private Sub txtM4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtM4.Validating
        If txtM4.Text <> "" Then
            try
            If Not IsNumeric(txtM4.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtM4.Text) < -922337203685478# Or Val(txtM4.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtM4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM4.TextChanged
  Changing

end sub
        Private Sub txtM5_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtM5.Validating
        If txtM5.Text <> "" Then
            try
            If Not IsNumeric(txtM5.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtM5.Text) < -922337203685478# Or Val(txtM5.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtM5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM5.TextChanged
  Changing

end sub
        Private Sub txtDM45_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDM45.Validating
        If txtDM45.Text <> "" Then
            try
            If Not IsNumeric(txtDM45.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDM45.Text) < -922337203685478# Or Val(txtDM45.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDM45_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDM45.TextChanged
  Changing

end sub
        Private Sub txtM6_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtM6.Validating
        If txtM6.Text <> "" Then
            try
            If Not IsNumeric(txtM6.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtM6.Text) < -922337203685478# Or Val(txtM6.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtM6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM6.TextChanged
  Changing

end sub
        Private Sub txtP1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtP1.Validating
        If txtP1.Text <> "" Then
            try
            If Not IsNumeric(txtP1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtP1.Text) < -922337203685478# Or Val(txtP1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtP1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtP1.TextChanged
  Changing

end sub
        Private Sub txtP2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtP2.Validating
        If txtP2.Text <> "" Then
            try
            If Not IsNumeric(txtP2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtP2.Text) < -922337203685478# Or Val(txtP2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtP2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtP2.TextChanged
  Changing

end sub
        Private Sub txtP3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtP3.Validating
        If txtP3.Text <> "" Then
            try
            If Not IsNumeric(txtP3.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtP3.Text) < -922337203685478# Or Val(txtP3.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtP3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtP3.TextChanged
  Changing

end sub
        Private Sub txtP4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtP4.Validating
        If txtP4.Text <> "" Then
            try
            If Not IsNumeric(txtP4.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtP4.Text) < -922337203685478# Or Val(txtP4.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtP4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtP4.TextChanged
  Changing

end sub
        Private Sub txtP5_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtP5.Validating
        If txtP5.Text <> "" Then
            try
            If Not IsNumeric(txtP5.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtP5.Text) < -922337203685478# Or Val(txtP5.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtP5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtP5.TextChanged
  Changing

end sub
        Private Sub txtP6_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtP6.Validating
        If txtP6.Text <> "" Then
            try
            If Not IsNumeric(txtP6.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtP6.Text) < -922337203685478# Or Val(txtP6.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtP6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtP6.TextChanged
  Changing

end sub
        Private Sub txtG1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtG1.Validating
        If txtG1.Text <> "" Then
            try
            If Not IsNumeric(txtG1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtG1.Text) < -922337203685478# Or Val(txtG1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtG1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtG1.TextChanged
  Changing

end sub
        Private Sub txtG2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtG2.Validating
        If txtG2.Text <> "" Then
            try
            If Not IsNumeric(txtG2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtG2.Text) < -922337203685478# Or Val(txtG2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtG2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtG2.TextChanged
  Changing

end sub
        Private Sub txtG3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtG3.Validating
        If txtG3.Text <> "" Then
            try
            If Not IsNumeric(txtG3.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtG3.Text) < -922337203685478# Or Val(txtG3.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtG3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtG3.TextChanged
  Changing

end sub
        Private Sub txtG4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtG4.Validating
        If txtG4.Text <> "" Then
            try
            If Not IsNumeric(txtG4.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtG4.Text) < -922337203685478# Or Val(txtG4.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtG4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtG4.TextChanged
  Changing

end sub
        Private Sub txtG5_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtG5.Validating
        If txtG5.Text <> "" Then
            try
            If Not IsNumeric(txtG5.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtG5.Text) < -922337203685478# Or Val(txtG5.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtG5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtG5.TextChanged
  Changing

end sub
        Private Sub txtG6_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtG6.Validating
        If txtG6.Text <> "" Then
            try
            If Not IsNumeric(txtG6.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtG6.Text) < -922337203685478# Or Val(txtG6.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtG6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtG6.TextChanged
  Changing

end sub
        Private Sub txtTCOOL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTCOOL.Validating
        If txtTCOOL.Text <> "" Then
            try
            If Not IsNumeric(txtTCOOL.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtTCOOL.Text) < -922337203685478# Or Val(txtTCOOL.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtTCOOL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTCOOL.TextChanged
  Changing

end sub
        Private Sub txtTCE1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTCE1.Validating
        If txtTCE1.Text <> "" Then
            try
            If Not IsNumeric(txtTCE1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtTCE1.Text) < -922337203685478# Or Val(txtTCE1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtTCE1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTCE1.TextChanged
  Changing

end sub
        Private Sub txtTCE2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTCE2.Validating
        If txtTCE2.Text <> "" Then
            try
            If Not IsNumeric(txtTCE2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtTCE2.Text) < -922337203685478# Or Val(txtTCE2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtTCE2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTCE2.TextChanged
  Changing

end sub
        Private Sub txtTSUM1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTSUM1.Validating
        If txtTSUM1.Text <> "" Then
            try
            If Not IsNumeric(txtTSUM1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtTSUM1.Text) < -922337203685478# Or Val(txtTSUM1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtTSUM1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTSUM1.TextChanged
  Changing

end sub
        Private Sub txtTSUM2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTSUM2.Validating
        If txtTSUM2.Text <> "" Then
            try
            If Not IsNumeric(txtTSUM2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtTSUM2.Text) < -922337203685478# Or Val(txtTSUM2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtTSUM2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTSUM2.TextChanged
  Changing

end sub
        Private Sub txtQ1H_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ1H.Validating
        If txtQ1H.Text <> "" Then
            try
            If Not IsNumeric(txtQ1H.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtQ1H.Text) < -922337203685478# Or Val(txtQ1H.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtQ1H_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQ1H.TextChanged
  Changing

end sub
        Private Sub txtQ2H_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ2H.Validating
        If txtQ2H.Text <> "" Then
            try
            If Not IsNumeric(txtQ2H.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtQ2H.Text) < -922337203685478# Or Val(txtQ2H.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtQ2H_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQ2H.TextChanged
  Changing

end sub
        Private Sub txtV1H_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtV1H.Validating
        If txtV1H.Text <> "" Then
            try
            If Not IsNumeric(txtV1H.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtV1H.Text) < -922337203685478# Or Val(txtV1H.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtV1H_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtV1H.TextChanged
  Changing

end sub
        Private Sub txtV2H_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtV2H.Validating
        If txtV2H.Text <> "" Then
            try
            If Not IsNumeric(txtV2H.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtV2H.Text) < -922337203685478# Or Val(txtV2H.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtV2H_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtV2H.TextChanged
  Changing

end sub
        Private Sub txtV4H_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtV4H.Validating
        If txtV4H.Text <> "" Then
            try
            If Not IsNumeric(txtV4H.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtV4H.Text) < -922337203685478# Or Val(txtV4H.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtV4H_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtV4H.TextChanged
  Changing

end sub
        Private Sub txtV5H_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtV5H.Validating
        If txtV5H.Text <> "" Then
            try
            If Not IsNumeric(txtV5H.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtV5H.Text) < -922337203685478# Or Val(txtV5H.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtV5H_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtV5H.TextChanged
  Changing

end sub
        Private Sub txtERRTIME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtERRTIME.Validating
        If txtERRTIME.Text <> "" Then
            try
            If Not IsNumeric(txtERRTIME.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtERRTIME.Text) < -922337203685478# Or Val(txtERRTIME.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtERRTIME_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtERRTIME.TextChanged
  Changing

end sub
        Private Sub txtERRTIMEH_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtERRTIMEH.Validating
        If txtERRTIMEH.Text <> "" Then
            try
            If Not IsNumeric(txtERRTIMEH.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtERRTIMEH.Text) < -922337203685478# Or Val(txtERRTIMEH.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtERRTIMEH_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtERRTIMEH.TextChanged
  Changing

end sub
private sub txtHC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHC.TextChanged
  Changing

end sub
        Private Sub txtSP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSP.Validating
        If txtSP.Text <> "" Then
            try
            If Not IsNumeric(txtSP.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtSP.Text) < -922337203685478# Or Val(txtSP.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtSP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSP.TextChanged
  Changing

end sub
        Private Sub txtSP_TB1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSP_TB1.Validating
        If txtSP_TB1.Text <> "" Then
            try
            If Not IsNumeric(txtSP_TB1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtSP_TB1.Text) < -922337203685478# Or Val(txtSP_TB1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtSP_TB1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSP_TB1.TextChanged
  Changing

end sub
        Private Sub txtSP_TB2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSP_TB2.Validating
        If txtSP_TB2.Text <> "" Then
            try
            If Not IsNumeric(txtSP_TB2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtSP_TB2.Text) < -922337203685478# Or Val(txtSP_TB2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtSP_TB2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSP_TB2.TextChanged
  Changing

end sub
private sub dtpdatetimeCOUNTER_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpdatetimeCOUNTER.ValueChanged
  Changing 

end sub
        Private Sub txtDG12_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDG12.Validating
        If txtDG12.Text <> "" Then
            try
            If Not IsNumeric(txtDG12.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDG12.Text) < -922337203685478# Or Val(txtDG12.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDG12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDG12.TextChanged
  Changing

end sub
        Private Sub txtDG45_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDG45.Validating
        If txtDG45.Text <> "" Then
            try
            If Not IsNumeric(txtDG45.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDG45.Text) < -922337203685478# Or Val(txtDG45.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDG45_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDG45.TextChanged
  Changing

end sub
        Private Sub txtDP12_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDP12.Validating
        If txtDP12.Text <> "" Then
            try
            If Not IsNumeric(txtDP12.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDP12.Text) < -922337203685478# Or Val(txtDP12.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDP12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDP12.TextChanged
  Changing

end sub
        Private Sub txtDP45_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDP45.Validating
        If txtDP45.Text <> "" Then
            try
            If Not IsNumeric(txtDP45.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDP45.Text) < -922337203685478# Or Val(txtDP45.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDP45_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDP45.TextChanged
  Changing

end sub
private sub txtUNITSR_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUNITSR.TextChanged
  Changing

end sub
        Private Sub txtQ3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ3.Validating
        If txtQ3.Text <> "" Then
            try
            If Not IsNumeric(txtQ3.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtQ3.Text) < -922337203685478# Or Val(txtQ3.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtQ3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQ3.TextChanged
  Changing

end sub
        Private Sub txtQ4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ4.Validating
        If txtQ4.Text <> "" Then
            try
            If Not IsNumeric(txtQ4.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtQ4.Text) < -922337203685478# Or Val(txtQ4.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtQ4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQ4.TextChanged
  Changing

end sub
        Private Sub txtPATM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPATM.Validating
        If txtPATM.Text <> "" Then
            try
            If Not IsNumeric(txtPATM.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtPATM.Text) < -922337203685478# Or Val(txtPATM.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtPATM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPATM.TextChanged
  Changing

end sub
        Private Sub txtQ5_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQ5.Validating
        If txtQ5.Text <> "" Then
            try
            If Not IsNumeric(txtQ5.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtQ5.Text) < -922337203685478# Or Val(txtQ5.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtQ5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQ5.TextChanged
  Changing

end sub
        Private Sub txtDQ12_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDQ12.Validating
        If txtDQ12.Text <> "" Then
            try
            If Not IsNumeric(txtDQ12.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDQ12.Text) < -922337203685478# Or Val(txtDQ12.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDQ12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDQ12.TextChanged
  Changing

end sub
        Private Sub txtDQ45_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDQ45.Validating
        If txtDQ45.Text <> "" Then
            try
            If Not IsNumeric(txtDQ45.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDQ45.Text) < -922337203685478# Or Val(txtDQ45.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDQ45_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDQ45.TextChanged
  Changing

end sub
        Private Sub txtPXB_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPXB.Validating
        If txtPXB.Text <> "" Then
            try
            If Not IsNumeric(txtPXB.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtPXB.Text) < -922337203685478# Or Val(txtPXB.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtPXB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPXB.TextChanged
  Changing

end sub
        Private Sub txtDQ_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDQ.Validating
        If txtDQ.Text <> "" Then
            try
            If Not IsNumeric(txtDQ.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDQ.Text) < -922337203685478# Or Val(txtDQ.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDQ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDQ.TextChanged
  Changing

end sub
private sub txtHC_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHC_1.TextChanged
  Changing

end sub
private sub txtHC_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHC_2.TextChanged
  Changing

end sub
        Private Sub txtTHOT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTHOT.Validating
        If txtTHOT.Text <> "" Then
            try
            If Not IsNumeric(txtTHOT.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtTHOT.Text) < -922337203685478# Or Val(txtTHOT.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtTHOT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTHOT.TextChanged
  Changing

end sub
        Private Sub txtDANS1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDANS1.Validating
        If txtDANS1.Text <> "" Then
            try
            If Not IsNumeric(txtDANS1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDANS1.Text) < -922337203685478# Or Val(txtDANS1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDANS1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDANS1.TextChanged
  Changing

end sub
        Private Sub txtDANS2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDANS2.Validating
        If txtDANS2.Text <> "" Then
            try
            If Not IsNumeric(txtDANS2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDANS2.Text) < -922337203685478# Or Val(txtDANS2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDANS2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDANS2.TextChanged
  Changing

end sub
        Private Sub txtDANS3_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDANS3.Validating
        If txtDANS3.Text <> "" Then
            try
            If Not IsNumeric(txtDANS3.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDANS3.Text) < -922337203685478# Or Val(txtDANS3.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDANS3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDANS3.TextChanged
  Changing

end sub
        Private Sub txtDANS4_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDANS4.Validating
        If txtDANS4.Text <> "" Then
            try
            If Not IsNumeric(txtDANS4.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDANS4.Text) < -922337203685478# Or Val(txtDANS4.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDANS4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDANS4.TextChanged
  Changing

end sub
        Private Sub txtDANS5_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDANS5.Validating
        If txtDANS5.Text <> "" Then
            try
            If Not IsNumeric(txtDANS5.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDANS5.Text) < -922337203685478# Or Val(txtDANS5.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDANS5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDANS5.TextChanged
  Changing

end sub
        Private Sub txtDANS6_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDANS6.Validating
        If txtDANS6.Text <> "" Then
            try
            If Not IsNumeric(txtDANS6.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtDANS6.Text) < -922337203685478# Or Val(txtDANS6.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtDANS6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDANS6.TextChanged
  Changing

end sub
        Private Sub txtCHECK_A_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCHECK_A.Validating
        If txtCHECK_A.Text <> "" Then
            try
            If Not IsNumeric(txtCHECK_A.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtCHECK_A.Text) < -922337203685478# Or Val(txtCHECK_A.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtCHECK_A_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCHECK_A.TextChanged
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
        Private Sub txtTAIR1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTAIR1.Validating
        If txtTAIR1.Text <> "" Then
            try
            If Not IsNumeric(txtTAIR1.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtTAIR1.Text) < -922337203685478# Or Val(txtTAIR1.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtTAIR1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAIR1.TextChanged
  Changing

end sub
        Private Sub txtTAIR2_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTAIR2.Validating
        If txtTAIR2.Text <> "" Then
            try
            If Not IsNumeric(txtTAIR2.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtTAIR2.Text) < -922337203685478# Or Val(txtTAIR2.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtTAIR2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAIR2.TextChanged
  Changing

end sub
private sub txtHC_CODE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHC_CODE.TextChanged
  Changing

end sub

Public Item As TPLC.TPLC.TPLC_M
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLC.TPLC.TPLC_M)
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
txtQ1.text = item.Q1.toString()
txtQ2.text = item.Q2.toString()
txtT1.text = item.T1.toString()
txtT2.text = item.T2.toString()
txtDT12.text = item.DT12.toString()
txtT3.text = item.T3.toString()
txtT4.text = item.T4.toString()
txtT5.text = item.T5.toString()
txtDT45.text = item.DT45.toString()
txtT6.text = item.T6.toString()
txtV1.text = item.V1.toString()
txtV2.text = item.V2.toString()
txtDV12.text = item.DV12.toString()
txtV3.text = item.V3.toString()
txtV4.text = item.V4.toString()
txtV5.text = item.V5.toString()
txtDV45.text = item.DV45.toString()
txtV6.text = item.V6.toString()
txtM1.text = item.M1.toString()
txtM2.text = item.M2.toString()
txtDM12.text = item.DM12.toString()
txtM3.text = item.M3.toString()
txtM4.text = item.M4.toString()
txtM5.text = item.M5.toString()
txtDM45.text = item.DM45.toString()
txtM6.text = item.M6.toString()
txtP1.text = item.P1.toString()
txtP2.text = item.P2.toString()
txtP3.text = item.P3.toString()
txtP4.text = item.P4.toString()
txtP5.text = item.P5.toString()
txtP6.text = item.P6.toString()
txtG1.text = item.G1.toString()
txtG2.text = item.G2.toString()
txtG3.text = item.G3.toString()
txtG4.text = item.G4.toString()
txtG5.text = item.G5.toString()
txtG6.text = item.G6.toString()
txtTCOOL.text = item.TCOOL.toString()
txtTCE1.text = item.TCE1.toString()
txtTCE2.text = item.TCE2.toString()
txtTSUM1.text = item.TSUM1.toString()
txtTSUM2.text = item.TSUM2.toString()
txtQ1H.text = item.Q1H.toString()
txtQ2H.text = item.Q2H.toString()
txtV1H.text = item.V1H.toString()
txtV2H.text = item.V2H.toString()
txtV4H.text = item.V4H.toString()
txtV5H.text = item.V5H.toString()
txtERRTIME.text = item.ERRTIME.toString()
txtERRTIMEH.text = item.ERRTIMEH.toString()
txtHC.text = item.HC
txtSP.text = item.SP.toString()
txtSP_TB1.text = item.SP_TB1.toString()
txtSP_TB2.text = item.SP_TB2.toString()
dtpdatetimeCOUNTER.value = System.DateTime.Now
if item.datetimeCOUNTER <> System.DateTime.MinValue then
  try
     dtpdatetimeCOUNTER.value = item.datetimeCOUNTER
  catch
   dtpdatetimeCOUNTER.value = System.DateTime.MinValue
  end try
else
   dtpdatetimeCOUNTER.value = System.DateTime.Today
   dtpdatetimeCOUNTER.Checked =false
end if
txtDG12.text = item.DG12.toString()
txtDG45.text = item.DG45.toString()
txtDP12.text = item.DP12.toString()
txtDP45.text = item.DP45.toString()
txtUNITSR.text = item.UNITSR
txtQ3.text = item.Q3.toString()
txtQ4.text = item.Q4.toString()
txtPATM.text = item.PATM.toString()
txtQ5.text = item.Q5.toString()
txtDQ12.text = item.DQ12.toString()
txtDQ45.text = item.DQ45.toString()
txtPXB.text = item.PXB.toString()
txtDQ.text = item.DQ.toString()
txtHC_1.text = item.HC_1
txtHC_2.text = item.HC_2
txtTHOT.text = item.THOT.toString()
txtDANS1.text = item.DANS1.toString()
txtDANS2.text = item.DANS2.toString()
txtDANS3.text = item.DANS3.toString()
txtDANS4.text = item.DANS4.toString()
txtDANS5.text = item.DANS5.toString()
txtDANS6.text = item.DANS6.toString()
txtCHECK_A.text = item.CHECK_A.toString()
txtOKTIME.text = item.OKTIME.toString()
txtWORKTIME.text = item.WORKTIME.toString()
txtTAIR1.text = item.TAIR1.toString()
txtTAIR2.text = item.TAIR2.toString()
txtHC_CODE.text = item.HC_CODE
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
item.Q1 = cdbl(txtQ1.text)
item.Q2 = cdbl(txtQ2.text)
item.T1 = cdbl(txtT1.text)
item.T2 = cdbl(txtT2.text)
item.DT12 = cdbl(txtDT12.text)
item.T3 = cdbl(txtT3.text)
item.T4 = cdbl(txtT4.text)
item.T5 = cdbl(txtT5.text)
item.DT45 = cdbl(txtDT45.text)
item.T6 = cdbl(txtT6.text)
item.V1 = cdbl(txtV1.text)
item.V2 = cdbl(txtV2.text)
item.DV12 = cdbl(txtDV12.text)
item.V3 = cdbl(txtV3.text)
item.V4 = cdbl(txtV4.text)
item.V5 = cdbl(txtV5.text)
item.DV45 = cdbl(txtDV45.text)
item.V6 = cdbl(txtV6.text)
item.M1 = cdbl(txtM1.text)
item.M2 = cdbl(txtM2.text)
item.DM12 = cdbl(txtDM12.text)
item.M3 = cdbl(txtM3.text)
item.M4 = cdbl(txtM4.text)
item.M5 = cdbl(txtM5.text)
item.DM45 = cdbl(txtDM45.text)
item.M6 = cdbl(txtM6.text)
item.P1 = cdbl(txtP1.text)
item.P2 = cdbl(txtP2.text)
item.P3 = cdbl(txtP3.text)
item.P4 = cdbl(txtP4.text)
item.P5 = cdbl(txtP5.text)
item.P6 = cdbl(txtP6.text)
item.G1 = cdbl(txtG1.text)
item.G2 = cdbl(txtG2.text)
item.G3 = cdbl(txtG3.text)
item.G4 = cdbl(txtG4.text)
item.G5 = cdbl(txtG5.text)
item.G6 = cdbl(txtG6.text)
item.TCOOL = cdbl(txtTCOOL.text)
item.TCE1 = cdbl(txtTCE1.text)
item.TCE2 = cdbl(txtTCE2.text)
item.TSUM1 = cdbl(txtTSUM1.text)
item.TSUM2 = cdbl(txtTSUM2.text)
item.Q1H = cdbl(txtQ1H.text)
item.Q2H = cdbl(txtQ2H.text)
item.V1H = cdbl(txtV1H.text)
item.V2H = cdbl(txtV2H.text)
item.V4H = cdbl(txtV4H.text)
item.V5H = cdbl(txtV5H.text)
item.ERRTIME = cdbl(txtERRTIME.text)
item.ERRTIMEH = cdbl(txtERRTIMEH.text)
item.HC = txtHC.text
item.SP = cdbl(txtSP.text)
item.SP_TB1 = cdbl(txtSP_TB1.text)
item.SP_TB2 = cdbl(txtSP_TB2.text)
  if dtpdatetimeCOUNTER.checked=false then
       item.datetimeCOUNTER = System.DateTime.MinValue
  else 
  try
    item.datetimeCOUNTER = dtpdatetimeCOUNTER.value
  catch
    item.datetimeCOUNTER = System.DateTime.MinValue
  end try
  end if
item.DG12 = cdbl(txtDG12.text)
item.DG45 = cdbl(txtDG45.text)
item.DP12 = cdbl(txtDP12.text)
item.DP45 = cdbl(txtDP45.text)
item.UNITSR = txtUNITSR.text
item.Q3 = cdbl(txtQ3.text)
item.Q4 = cdbl(txtQ4.text)
item.PATM = cdbl(txtPATM.text)
item.Q5 = cdbl(txtQ5.text)
item.DQ12 = cdbl(txtDQ12.text)
item.DQ45 = cdbl(txtDQ45.text)
item.PXB = cdbl(txtPXB.text)
item.DQ = cdbl(txtDQ.text)
item.HC_1 = txtHC_1.text
item.HC_2 = txtHC_2.text
item.THOT = cdbl(txtTHOT.text)
item.DANS1 = cdbl(txtDANS1.text)
item.DANS2 = cdbl(txtDANS2.text)
item.DANS3 = cdbl(txtDANS3.text)
item.DANS4 = cdbl(txtDANS4.text)
item.DANS5 = cdbl(txtDANS5.text)
item.DANS6 = cdbl(txtDANS6.text)
item.CHECK_A = cdbl(txtCHECK_A.text)
item.OKTIME = cdbl(txtOKTIME.text)
item.WORKTIME = cdbl(txtWORKTIME.text)
item.TAIR1 = cdbl(txtTAIR1.text)
item.TAIR2 = cdbl(txtTAIR2.text)
item.HC_CODE = txtHC_CODE.text
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
