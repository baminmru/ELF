
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела План опроса устройств режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLT_PLANCALL
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
Friend WithEvents lblCSTATUS  as  System.Windows.Forms.Label
Friend WithEvents cmbCSTATUS As System.Windows.Forms.ComboBox
Friend cmbCSTATUSDATA As DataTable
Friend cmbCSTATUSDATAROW As DataRow
Friend WithEvents lblNMAXCALL  as  System.Windows.Forms.Label
Friend WithEvents txtNMAXCALL As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblMINREPEAT  as  System.Windows.Forms.Label
Friend WithEvents txtMINREPEAT As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDLOCK  as  System.Windows.Forms.Label
Friend WithEvents dtpDLOCK As System.Windows.Forms.DateTimePicker
Friend WithEvents lblDLASTCALL  as  System.Windows.Forms.Label
Friend WithEvents dtpDLASTCALL As System.Windows.Forms.DateTimePicker
Friend WithEvents lblCCURR  as  System.Windows.Forms.Label
Friend WithEvents cmbCCURR As System.Windows.Forms.ComboBox
Friend cmbCCURRDATA As DataTable
Friend cmbCCURRDATAROW As DataRow
Friend WithEvents lblICALLCURR  as  System.Windows.Forms.Label
Friend WithEvents txtICALLCURR As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDNEXTCURR  as  System.Windows.Forms.Label
Friend WithEvents dtpDNEXTCURR As System.Windows.Forms.DateTimePicker
Friend WithEvents lblCHOUR  as  System.Windows.Forms.Label
Friend WithEvents cmbCHOUR As System.Windows.Forms.ComboBox
Friend cmbCHOURDATA As DataTable
Friend cmbCHOURDATAROW As DataRow
Friend WithEvents lblICALL  as  System.Windows.Forms.Label
Friend WithEvents txtICALL As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblNUMHOUR  as  System.Windows.Forms.Label
Friend WithEvents txtNUMHOUR As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDNEXTHOUR  as  System.Windows.Forms.Label
Friend WithEvents dtpDNEXTHOUR As System.Windows.Forms.DateTimePicker
Friend WithEvents lblDLASTHOUR  as  System.Windows.Forms.Label
Friend WithEvents dtpDLASTHOUR As System.Windows.Forms.DateTimePicker
Friend WithEvents lblC24  as  System.Windows.Forms.Label
Friend WithEvents cmbC24 As System.Windows.Forms.ComboBox
Friend cmbC24DATA As DataTable
Friend cmbC24DATAROW As DataRow
Friend WithEvents lblICALL24  as  System.Windows.Forms.Label
Friend WithEvents txtICALL24 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblNUM24  as  System.Windows.Forms.Label
Friend WithEvents txtNUM24 As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDNEXT24  as  System.Windows.Forms.Label
Friend WithEvents dtpDNEXT24 As System.Windows.Forms.DateTimePicker
Friend WithEvents lblDLASTDAY  as  System.Windows.Forms.Label
Friend WithEvents dtpDLASTDAY As System.Windows.Forms.DateTimePicker
Friend WithEvents lblCSUM  as  System.Windows.Forms.Label
Friend WithEvents cmbCSUM As System.Windows.Forms.ComboBox
Friend cmbCSUMDATA As DataTable
Friend cmbCSUMDATAROW As DataRow
Friend WithEvents lblICALLSUM  as  System.Windows.Forms.Label
Friend WithEvents txtICALLSUM As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDNEXTSUM  as  System.Windows.Forms.Label
Friend WithEvents dtpDNEXTSUM As System.Windows.Forms.DateTimePicker
Friend WithEvents lblCEL  as  System.Windows.Forms.Label
Friend WithEvents cmbCEL As System.Windows.Forms.ComboBox
Friend cmbCELDATA As DataTable
Friend cmbCELDATAROW As DataRow
Friend WithEvents lblIEL  as  System.Windows.Forms.Label
Friend WithEvents txtIEL As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDNEXTEL  as  System.Windows.Forms.Label
Friend WithEvents dtpDNEXTEL As System.Windows.Forms.DateTimePicker

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
Me.lblCSTATUS = New System.Windows.Forms.Label
Me.cmbCSTATUS = New System.Windows.Forms.ComboBox
Me.lblNMAXCALL = New System.Windows.Forms.Label
Me.txtNMAXCALL = New LATIR2GuiManager.TouchTextBox
Me.lblMINREPEAT = New System.Windows.Forms.Label
Me.txtMINREPEAT = New LATIR2GuiManager.TouchTextBox
Me.lblDLOCK = New System.Windows.Forms.Label
Me.dtpDLOCK = New System.Windows.Forms.DateTimePicker
Me.lblDLASTCALL = New System.Windows.Forms.Label
Me.dtpDLASTCALL = New System.Windows.Forms.DateTimePicker
Me.lblCCURR = New System.Windows.Forms.Label
Me.cmbCCURR = New System.Windows.Forms.ComboBox
Me.lblICALLCURR = New System.Windows.Forms.Label
Me.txtICALLCURR = New LATIR2GuiManager.TouchTextBox
Me.lblDNEXTCURR = New System.Windows.Forms.Label
Me.dtpDNEXTCURR = New System.Windows.Forms.DateTimePicker
Me.lblCHOUR = New System.Windows.Forms.Label
Me.cmbCHOUR = New System.Windows.Forms.ComboBox
Me.lblICALL = New System.Windows.Forms.Label
Me.txtICALL = New LATIR2GuiManager.TouchTextBox
Me.lblNUMHOUR = New System.Windows.Forms.Label
Me.txtNUMHOUR = New LATIR2GuiManager.TouchTextBox
Me.lblDNEXTHOUR = New System.Windows.Forms.Label
Me.dtpDNEXTHOUR = New System.Windows.Forms.DateTimePicker
Me.lblDLASTHOUR = New System.Windows.Forms.Label
Me.dtpDLASTHOUR = New System.Windows.Forms.DateTimePicker
Me.lblC24 = New System.Windows.Forms.Label
Me.cmbC24 = New System.Windows.Forms.ComboBox
Me.lblICALL24 = New System.Windows.Forms.Label
Me.txtICALL24 = New LATIR2GuiManager.TouchTextBox
Me.lblNUM24 = New System.Windows.Forms.Label
Me.txtNUM24 = New LATIR2GuiManager.TouchTextBox
Me.lblDNEXT24 = New System.Windows.Forms.Label
Me.dtpDNEXT24 = New System.Windows.Forms.DateTimePicker
Me.lblDLASTDAY = New System.Windows.Forms.Label
Me.dtpDLASTDAY = New System.Windows.Forms.DateTimePicker
Me.lblCSUM = New System.Windows.Forms.Label
Me.cmbCSUM = New System.Windows.Forms.ComboBox
Me.lblICALLSUM = New System.Windows.Forms.Label
Me.txtICALLSUM = New LATIR2GuiManager.TouchTextBox
Me.lblDNEXTSUM = New System.Windows.Forms.Label
Me.dtpDNEXTSUM = New System.Windows.Forms.DateTimePicker
Me.lblCEL = New System.Windows.Forms.Label
Me.cmbCEL = New System.Windows.Forms.ComboBox
Me.lblIEL = New System.Windows.Forms.Label
Me.txtIEL = New LATIR2GuiManager.TouchTextBox
Me.lblDNEXTEL = New System.Windows.Forms.Label
Me.dtpDNEXTEL = New System.Windows.Forms.DateTimePicker

Me.lblCSTATUS.Location = New System.Drawing.Point(20,5)
Me.lblCSTATUS.name = "lblCSTATUS"
Me.lblCSTATUS.Size = New System.Drawing.Size(200, 20)
Me.lblCSTATUS.TabIndex = 1
Me.lblCSTATUS.Text = "Исключить из опроса"
Me.lblCSTATUS.ForeColor = System.Drawing.Color.Blue
Me.cmbCSTATUS.Location = New System.Drawing.Point(20,27)
Me.cmbCSTATUS.name = "cmbCSTATUS"
Me.cmbCSTATUS.Size = New System.Drawing.Size(200,  20)
Me.cmbCSTATUS.TabIndex = 2
Me.lblNMAXCALL.Location = New System.Drawing.Point(20,52)
Me.lblNMAXCALL.name = "lblNMAXCALL"
Me.lblNMAXCALL.Size = New System.Drawing.Size(200, 20)
Me.lblNMAXCALL.TabIndex = 3
Me.lblNMAXCALL.Text = "Max число попыток дозвона"
Me.lblNMAXCALL.ForeColor = System.Drawing.Color.Blue
Me.txtNMAXCALL.Location = New System.Drawing.Point(20,74)
Me.txtNMAXCALL.name = "txtNMAXCALL"
Me.txtNMAXCALL.MultiLine = false
Me.txtNMAXCALL.Size = New System.Drawing.Size(200,  20)
Me.txtNMAXCALL.TabIndex = 4
Me.txtNMAXCALL.Text = "" 
Me.txtNMAXCALL.MaxLength = 15
Me.lblMINREPEAT.Location = New System.Drawing.Point(20,99)
Me.lblMINREPEAT.name = "lblMINREPEAT"
Me.lblMINREPEAT.Size = New System.Drawing.Size(200, 20)
Me.lblMINREPEAT.TabIndex = 5
Me.lblMINREPEAT.Text = "Повторить через (минут)"
Me.lblMINREPEAT.ForeColor = System.Drawing.Color.Blue
Me.txtMINREPEAT.Location = New System.Drawing.Point(20,121)
Me.txtMINREPEAT.name = "txtMINREPEAT"
Me.txtMINREPEAT.MultiLine = false
Me.txtMINREPEAT.Size = New System.Drawing.Size(200,  20)
Me.txtMINREPEAT.TabIndex = 6
Me.txtMINREPEAT.Text = "" 
Me.txtMINREPEAT.MaxLength = 15
Me.lblDLOCK.Location = New System.Drawing.Point(20,146)
Me.lblDLOCK.name = "lblDLOCK"
Me.lblDLOCK.Size = New System.Drawing.Size(200, 20)
Me.lblDLOCK.TabIndex = 7
Me.lblDLOCK.Text = "Когда заблокирован"
Me.lblDLOCK.ForeColor = System.Drawing.Color.Blue
Me.dtpDLOCK.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpDLOCK.Location = New System.Drawing.Point(20,168)
Me.dtpDLOCK.name = "dtpDLOCK"
Me.dtpDLOCK.Size = New System.Drawing.Size(200,  20)
Me.dtpDLOCK.TabIndex =8
Me.dtpDLOCK.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpDLOCK.ShowCheckBox=True
Me.lblDLASTCALL.Location = New System.Drawing.Point(20,193)
Me.lblDLASTCALL.name = "lblDLASTCALL"
Me.lblDLASTCALL.Size = New System.Drawing.Size(200, 20)
Me.lblDLASTCALL.TabIndex = 9
Me.lblDLASTCALL.Text = "Последний опрос"
Me.lblDLASTCALL.ForeColor = System.Drawing.Color.Blue
Me.dtpDLASTCALL.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpDLASTCALL.Location = New System.Drawing.Point(20,215)
Me.dtpDLASTCALL.name = "dtpDLASTCALL"
Me.dtpDLASTCALL.Size = New System.Drawing.Size(200,  20)
Me.dtpDLASTCALL.TabIndex =10
Me.dtpDLASTCALL.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpDLASTCALL.ShowCheckBox=True
Me.lblCCURR.Location = New System.Drawing.Point(20,240)
Me.lblCCURR.name = "lblCCURR"
Me.lblCCURR.Size = New System.Drawing.Size(200, 20)
Me.lblCCURR.TabIndex = 11
Me.lblCCURR.Text = "Опрашивать текущие"
Me.lblCCURR.ForeColor = System.Drawing.Color.Blue
Me.cmbCCURR.Location = New System.Drawing.Point(20,262)
Me.cmbCCURR.name = "cmbCCURR"
Me.cmbCCURR.Size = New System.Drawing.Size(200,  20)
Me.cmbCCURR.TabIndex = 12
Me.lblICALLCURR.Location = New System.Drawing.Point(20,287)
Me.lblICALLCURR.name = "lblICALLCURR"
Me.lblICALLCURR.Size = New System.Drawing.Size(200, 20)
Me.lblICALLCURR.TabIndex = 13
Me.lblICALLCURR.Text = "Интервал (минут) "
Me.lblICALLCURR.ForeColor = System.Drawing.Color.Blue
Me.txtICALLCURR.Location = New System.Drawing.Point(20,309)
Me.txtICALLCURR.name = "txtICALLCURR"
Me.txtICALLCURR.MultiLine = false
Me.txtICALLCURR.Size = New System.Drawing.Size(200,  20)
Me.txtICALLCURR.TabIndex = 14
Me.txtICALLCURR.Text = "" 
Me.txtICALLCURR.MaxLength = 15
Me.lblDNEXTCURR.Location = New System.Drawing.Point(20,334)
Me.lblDNEXTCURR.name = "lblDNEXTCURR"
Me.lblDNEXTCURR.Size = New System.Drawing.Size(200, 20)
Me.lblDNEXTCURR.TabIndex = 15
Me.lblDNEXTCURR.Text = "Следующий опрос"
Me.lblDNEXTCURR.ForeColor = System.Drawing.Color.Blue
Me.dtpDNEXTCURR.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpDNEXTCURR.Location = New System.Drawing.Point(20,356)
Me.dtpDNEXTCURR.name = "dtpDNEXTCURR"
Me.dtpDNEXTCURR.Size = New System.Drawing.Size(200,  20)
Me.dtpDNEXTCURR.TabIndex =16
Me.dtpDNEXTCURR.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpDNEXTCURR.ShowCheckBox=True
Me.lblCHOUR.Location = New System.Drawing.Point(20,381)
Me.lblCHOUR.name = "lblCHOUR"
Me.lblCHOUR.Size = New System.Drawing.Size(200, 20)
Me.lblCHOUR.TabIndex = 17
Me.lblCHOUR.Text = "Опрашивать ч."
Me.lblCHOUR.ForeColor = System.Drawing.Color.Blue
Me.cmbCHOUR.Location = New System.Drawing.Point(20,403)
Me.cmbCHOUR.name = "cmbCHOUR"
Me.cmbCHOUR.Size = New System.Drawing.Size(200,  20)
Me.cmbCHOUR.TabIndex = 18
Me.lblICALL.Location = New System.Drawing.Point(230,5)
Me.lblICALL.name = "lblICALL"
Me.lblICALL.Size = New System.Drawing.Size(200, 20)
Me.lblICALL.TabIndex = 19
Me.lblICALL.Text = "Интервал опроса (минут)"
Me.lblICALL.ForeColor = System.Drawing.Color.Blue
Me.txtICALL.Location = New System.Drawing.Point(230,27)
Me.txtICALL.name = "txtICALL"
Me.txtICALL.MultiLine = false
Me.txtICALL.Size = New System.Drawing.Size(200,  20)
Me.txtICALL.TabIndex = 20
Me.txtICALL.Text = "" 
Me.txtICALL.MaxLength = 15
Me.lblNUMHOUR.Location = New System.Drawing.Point(230,52)
Me.lblNUMHOUR.name = "lblNUMHOUR"
Me.lblNUMHOUR.Size = New System.Drawing.Size(200, 20)
Me.lblNUMHOUR.TabIndex = 21
Me.lblNUMHOUR.Text = "За сколько часов"
Me.lblNUMHOUR.ForeColor = System.Drawing.Color.Blue
Me.txtNUMHOUR.Location = New System.Drawing.Point(230,74)
Me.txtNUMHOUR.name = "txtNUMHOUR"
Me.txtNUMHOUR.MultiLine = false
Me.txtNUMHOUR.Size = New System.Drawing.Size(200,  20)
Me.txtNUMHOUR.TabIndex = 22
Me.txtNUMHOUR.Text = "" 
Me.txtNUMHOUR.MaxLength = 15
Me.lblDNEXTHOUR.Location = New System.Drawing.Point(230,99)
Me.lblDNEXTHOUR.name = "lblDNEXTHOUR"
Me.lblDNEXTHOUR.Size = New System.Drawing.Size(200, 20)
Me.lblDNEXTHOUR.TabIndex = 23
Me.lblDNEXTHOUR.Text = "Следующий опрос"
Me.lblDNEXTHOUR.ForeColor = System.Drawing.Color.Blue
Me.dtpDNEXTHOUR.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpDNEXTHOUR.Location = New System.Drawing.Point(230,121)
Me.dtpDNEXTHOUR.name = "dtpDNEXTHOUR"
Me.dtpDNEXTHOUR.Size = New System.Drawing.Size(200,  20)
Me.dtpDNEXTHOUR.TabIndex =24
Me.dtpDNEXTHOUR.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpDNEXTHOUR.ShowCheckBox=True
Me.lblDLASTHOUR.Location = New System.Drawing.Point(230,146)
Me.lblDLASTHOUR.name = "lblDLASTHOUR"
Me.lblDLASTHOUR.Size = New System.Drawing.Size(200, 20)
Me.lblDLASTHOUR.TabIndex = 25
Me.lblDLASTHOUR.Text = "Последний опрос"
Me.lblDLASTHOUR.ForeColor = System.Drawing.Color.Blue
Me.dtpDLASTHOUR.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpDLASTHOUR.Location = New System.Drawing.Point(230,168)
Me.dtpDLASTHOUR.name = "dtpDLASTHOUR"
Me.dtpDLASTHOUR.Size = New System.Drawing.Size(200,  20)
Me.dtpDLASTHOUR.TabIndex =26
Me.dtpDLASTHOUR.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpDLASTHOUR.ShowCheckBox=True
Me.lblC24.Location = New System.Drawing.Point(230,193)
Me.lblC24.name = "lblC24"
Me.lblC24.Size = New System.Drawing.Size(200, 20)
Me.lblC24.TabIndex = 27
Me.lblC24.Text = "Опрашивать С."
Me.lblC24.ForeColor = System.Drawing.Color.Blue
Me.cmbC24.Location = New System.Drawing.Point(230,215)
Me.cmbC24.name = "cmbC24"
Me.cmbC24.Size = New System.Drawing.Size(200,  20)
Me.cmbC24.TabIndex = 28
Me.lblICALL24.Location = New System.Drawing.Point(230,240)
Me.lblICALL24.name = "lblICALL24"
Me.lblICALL24.Size = New System.Drawing.Size(200, 20)
Me.lblICALL24.TabIndex = 29
Me.lblICALL24.Text = "Интервал (часов)"
Me.lblICALL24.ForeColor = System.Drawing.Color.Blue
Me.txtICALL24.Location = New System.Drawing.Point(230,262)
Me.txtICALL24.name = "txtICALL24"
Me.txtICALL24.MultiLine = false
Me.txtICALL24.Size = New System.Drawing.Size(200,  20)
Me.txtICALL24.TabIndex = 30
Me.txtICALL24.Text = "" 
Me.txtICALL24.MaxLength = 15
Me.lblNUM24.Location = New System.Drawing.Point(230,287)
Me.lblNUM24.name = "lblNUM24"
Me.lblNUM24.Size = New System.Drawing.Size(200, 20)
Me.lblNUM24.TabIndex = 31
Me.lblNUM24.Text = "За сколько суток"
Me.lblNUM24.ForeColor = System.Drawing.Color.Blue
Me.txtNUM24.Location = New System.Drawing.Point(230,309)
Me.txtNUM24.name = "txtNUM24"
Me.txtNUM24.MultiLine = false
Me.txtNUM24.Size = New System.Drawing.Size(200,  20)
Me.txtNUM24.TabIndex = 32
Me.txtNUM24.Text = "" 
Me.txtNUM24.MaxLength = 15
Me.lblDNEXT24.Location = New System.Drawing.Point(230,334)
Me.lblDNEXT24.name = "lblDNEXT24"
Me.lblDNEXT24.Size = New System.Drawing.Size(200, 20)
Me.lblDNEXT24.TabIndex = 33
Me.lblDNEXT24.Text = "Следующий опрос"
Me.lblDNEXT24.ForeColor = System.Drawing.Color.Blue
Me.dtpDNEXT24.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpDNEXT24.Location = New System.Drawing.Point(230,356)
Me.dtpDNEXT24.name = "dtpDNEXT24"
Me.dtpDNEXT24.Size = New System.Drawing.Size(200,  20)
Me.dtpDNEXT24.TabIndex =34
Me.dtpDNEXT24.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpDNEXT24.ShowCheckBox=True
Me.lblDLASTDAY.Location = New System.Drawing.Point(230,381)
Me.lblDLASTDAY.name = "lblDLASTDAY"
Me.lblDLASTDAY.Size = New System.Drawing.Size(200, 20)
Me.lblDLASTDAY.TabIndex = 35
Me.lblDLASTDAY.Text = "Последний опрос"
Me.lblDLASTDAY.ForeColor = System.Drawing.Color.Blue
Me.dtpDLASTDAY.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpDLASTDAY.Location = New System.Drawing.Point(230,403)
Me.dtpDLASTDAY.name = "dtpDLASTDAY"
Me.dtpDLASTDAY.Size = New System.Drawing.Size(200,  20)
Me.dtpDLASTDAY.TabIndex =36
Me.dtpDLASTDAY.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpDLASTDAY.ShowCheckBox=True
Me.lblCSUM.Location = New System.Drawing.Point(440,5)
Me.lblCSUM.name = "lblCSUM"
Me.lblCSUM.Size = New System.Drawing.Size(200, 20)
Me.lblCSUM.TabIndex = 37
Me.lblCSUM.Text = "Опрашивать Ит."
Me.lblCSUM.ForeColor = System.Drawing.Color.Blue
Me.cmbCSUM.Location = New System.Drawing.Point(440,27)
Me.cmbCSUM.name = "cmbCSUM"
Me.cmbCSUM.Size = New System.Drawing.Size(200,  20)
Me.cmbCSUM.TabIndex = 38
Me.lblICALLSUM.Location = New System.Drawing.Point(440,52)
Me.lblICALLSUM.name = "lblICALLSUM"
Me.lblICALLSUM.Size = New System.Drawing.Size(200, 20)
Me.lblICALLSUM.TabIndex = 39
Me.lblICALLSUM.Text = "Интервал  (минут) "
Me.lblICALLSUM.ForeColor = System.Drawing.Color.Blue
Me.txtICALLSUM.Location = New System.Drawing.Point(440,74)
Me.txtICALLSUM.name = "txtICALLSUM"
Me.txtICALLSUM.MultiLine = false
Me.txtICALLSUM.Size = New System.Drawing.Size(200,  20)
Me.txtICALLSUM.TabIndex = 40
Me.txtICALLSUM.Text = "" 
Me.txtICALLSUM.MaxLength = 15
Me.lblDNEXTSUM.Location = New System.Drawing.Point(440,99)
Me.lblDNEXTSUM.name = "lblDNEXTSUM"
Me.lblDNEXTSUM.Size = New System.Drawing.Size(200, 20)
Me.lblDNEXTSUM.TabIndex = 41
Me.lblDNEXTSUM.Text = "Следующий опрос"
Me.lblDNEXTSUM.ForeColor = System.Drawing.Color.Blue
Me.dtpDNEXTSUM.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpDNEXTSUM.Location = New System.Drawing.Point(440,121)
Me.dtpDNEXTSUM.name = "dtpDNEXTSUM"
Me.dtpDNEXTSUM.Size = New System.Drawing.Size(200,  20)
Me.dtpDNEXTSUM.TabIndex =42
Me.dtpDNEXTSUM.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpDNEXTSUM.ShowCheckBox=True
Me.lblCEL.Location = New System.Drawing.Point(440,146)
Me.lblCEL.name = "lblCEL"
Me.lblCEL.Size = New System.Drawing.Size(200, 20)
Me.lblCEL.TabIndex = 43
Me.lblCEL.Text = "Опрашивать Эл."
Me.lblCEL.ForeColor = System.Drawing.Color.Blue
Me.cmbCEL.Location = New System.Drawing.Point(440,168)
Me.cmbCEL.name = "cmbCEL"
Me.cmbCEL.Size = New System.Drawing.Size(200,  20)
Me.cmbCEL.TabIndex = 44
Me.lblIEL.Location = New System.Drawing.Point(440,193)
Me.lblIEL.name = "lblIEL"
Me.lblIEL.Size = New System.Drawing.Size(200, 20)
Me.lblIEL.TabIndex = 45
Me.lblIEL.Text = "Интервал (мин.)"
Me.lblIEL.ForeColor = System.Drawing.Color.Blue
Me.txtIEL.Location = New System.Drawing.Point(440,215)
Me.txtIEL.name = "txtIEL"
Me.txtIEL.MultiLine = false
Me.txtIEL.Size = New System.Drawing.Size(200,  20)
Me.txtIEL.TabIndex = 46
Me.txtIEL.Text = "" 
Me.txtIEL.MaxLength = 15
Me.lblDNEXTEL.Location = New System.Drawing.Point(440,240)
Me.lblDNEXTEL.name = "lblDNEXTEL"
Me.lblDNEXTEL.Size = New System.Drawing.Size(200, 20)
Me.lblDNEXTEL.TabIndex = 47
Me.lblDNEXTEL.Text = "Дата следующего опроса"
Me.lblDNEXTEL.ForeColor = System.Drawing.Color.Blue
Me.dtpDNEXTEL.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpDNEXTEL.Location = New System.Drawing.Point(440,262)
Me.dtpDNEXTEL.name = "dtpDNEXTEL"
Me.dtpDNEXTEL.Size = New System.Drawing.Size(200,  20)
Me.dtpDNEXTEL.TabIndex =48
Me.dtpDNEXTEL.CustomFormat = "dd/MM/yyyy"
Me.dtpDNEXTEL.ShowCheckBox=True
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCSTATUS)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbCSTATUS)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblNMAXCALL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtNMAXCALL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblMINREPEAT)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtMINREPEAT)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDLOCK)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpDLOCK)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDLASTCALL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpDLASTCALL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCCURR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbCCURR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblICALLCURR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtICALLCURR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDNEXTCURR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpDNEXTCURR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCHOUR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbCHOUR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblICALL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtICALL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblNUMHOUR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtNUMHOUR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDNEXTHOUR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpDNEXTHOUR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDLASTHOUR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpDLASTHOUR)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblC24)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbC24)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblICALL24)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtICALL24)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblNUM24)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtNUM24)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDNEXT24)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpDNEXT24)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDLASTDAY)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpDLASTDAY)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCSUM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbCSUM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblICALLSUM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtICALLSUM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDNEXTSUM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpDNEXTSUM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCEL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbCEL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIEL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtIEL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDNEXTEL)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpDNEXTEL)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLT_PLANCALL"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub cmbCSTATUS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCSTATUS.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtNMAXCALL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNMAXCALL.Validating
        If txtNMAXCALL.Text <> "" Then
            try
            If Not IsNumeric(txtNMAXCALL.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtNMAXCALL.Text) < -2000000000 Or Val(txtNMAXCALL.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtNMAXCALL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNMAXCALL.TextChanged
  Changing

end sub
        Private Sub txtMINREPEAT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMINREPEAT.Validating
        If txtMINREPEAT.Text <> "" Then
            try
            If Not IsNumeric(txtMINREPEAT.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtMINREPEAT.Text) < -2000000000 Or Val(txtMINREPEAT.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtMINREPEAT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMINREPEAT.TextChanged
  Changing

end sub
private sub dtpDLOCK_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDLOCK.ValueChanged
  Changing 

end sub
private sub dtpDLASTCALL_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDLASTCALL.ValueChanged
  Changing 

end sub
private sub cmbCCURR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCCURR.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtICALLCURR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtICALLCURR.Validating
        If txtICALLCURR.Text <> "" Then
            try
            If Not IsNumeric(txtICALLCURR.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtICALLCURR.Text) < -2000000000 Or Val(txtICALLCURR.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtICALLCURR_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtICALLCURR.TextChanged
  Changing

end sub
private sub dtpDNEXTCURR_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDNEXTCURR.ValueChanged
  Changing 

end sub
private sub cmbCHOUR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCHOUR.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtICALL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtICALL.Validating
        If txtICALL.Text <> "" Then
            try
            If Not IsNumeric(txtICALL.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtICALL.Text) < -2000000000 Or Val(txtICALL.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtICALL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtICALL.TextChanged
  Changing

end sub
        Private Sub txtNUMHOUR_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNUMHOUR.Validating
        If txtNUMHOUR.Text <> "" Then
            try
            If Not IsNumeric(txtNUMHOUR.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtNUMHOUR.Text) < -2000000000 Or Val(txtNUMHOUR.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtNUMHOUR_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNUMHOUR.TextChanged
  Changing

end sub
private sub dtpDNEXTHOUR_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDNEXTHOUR.ValueChanged
  Changing 

end sub
private sub dtpDLASTHOUR_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDLASTHOUR.ValueChanged
  Changing 

end sub
private sub cmbC24_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbC24.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtICALL24_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtICALL24.Validating
        If txtICALL24.Text <> "" Then
            try
            If Not IsNumeric(txtICALL24.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtICALL24.Text) < -2000000000 Or Val(txtICALL24.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtICALL24_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtICALL24.TextChanged
  Changing

end sub
        Private Sub txtNUM24_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNUM24.Validating
        If txtNUM24.Text <> "" Then
            try
            If Not IsNumeric(txtNUM24.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtNUM24.Text) < -2000000000 Or Val(txtNUM24.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtNUM24_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNUM24.TextChanged
  Changing

end sub
private sub dtpDNEXT24_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDNEXT24.ValueChanged
  Changing 

end sub
private sub dtpDLASTDAY_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDLASTDAY.ValueChanged
  Changing 

end sub
private sub cmbCSUM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCSUM.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtICALLSUM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtICALLSUM.Validating
        If txtICALLSUM.Text <> "" Then
            try
            If Not IsNumeric(txtICALLSUM.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtICALLSUM.Text) < -2000000000 Or Val(txtICALLSUM.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtICALLSUM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtICALLSUM.TextChanged
  Changing

end sub
private sub dtpDNEXTSUM_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDNEXTSUM.ValueChanged
  Changing 

end sub
private sub cmbCEL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCEL.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtIEL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtIEL.Validating
        If txtIEL.Text <> "" Then
            try
            If Not IsNumeric(txtIEL.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtIEL.Text) < -2000000000 Or Val(txtIEL.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtIEL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIEL.TextChanged
  Changing

end sub
private sub dtpDNEXTEL_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDNEXTEL.ValueChanged
  Changing 

end sub

Public Item As TPLT.TPLT.TPLT_PLANCALL
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLT.TPLT.TPLT_PLANCALL)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

cmbCSTATUSData = New DataTable
cmbCSTATUSData.Columns.Add("name", GetType(System.String))
cmbCSTATUSData.Columns.Add("Value", GetType(System.Int32))
try
cmbCSTATUSDataRow = cmbCSTATUSData.NewRow
cmbCSTATUSDataRow("name") = "Да"
cmbCSTATUSDataRow("Value") = -1
cmbCSTATUSData.Rows.Add (cmbCSTATUSDataRow)
cmbCSTATUSDataRow = cmbCSTATUSData.NewRow
cmbCSTATUSDataRow("name") = "Нет"
cmbCSTATUSDataRow("Value") = 0
cmbCSTATUSData.Rows.Add (cmbCSTATUSDataRow)
cmbCSTATUS.DisplayMember = "name"
cmbCSTATUS.ValueMember = "Value"
cmbCSTATUS.DataSource = cmbCSTATUSData
 cmbCSTATUS.SelectedValue=CInt(Item.CSTATUS)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtNMAXCALL.text = item.NMAXCALL.toString()
txtMINREPEAT.text = item.MINREPEAT.toString()
dtpDLOCK.value = System.DateTime.Now
if item.DLOCK <> System.DateTime.MinValue then
  try
     dtpDLOCK.value = item.DLOCK
  catch
   dtpDLOCK.value = System.DateTime.MinValue
  end try
else
   dtpDLOCK.value = System.DateTime.Today
   dtpDLOCK.Checked =false
end if
dtpDLASTCALL.value = System.DateTime.Now
if item.DLASTCALL <> System.DateTime.MinValue then
  try
     dtpDLASTCALL.value = item.DLASTCALL
  catch
   dtpDLASTCALL.value = System.DateTime.MinValue
  end try
else
   dtpDLASTCALL.value = System.DateTime.Today
   dtpDLASTCALL.Checked =false
end if
cmbCCURRData = New DataTable
cmbCCURRData.Columns.Add("name", GetType(System.String))
cmbCCURRData.Columns.Add("Value", GetType(System.Int32))
try
cmbCCURRDataRow = cmbCCURRData.NewRow
cmbCCURRDataRow("name") = "Да"
cmbCCURRDataRow("Value") = -1
cmbCCURRData.Rows.Add (cmbCCURRDataRow)
cmbCCURRDataRow = cmbCCURRData.NewRow
cmbCCURRDataRow("name") = "Нет"
cmbCCURRDataRow("Value") = 0
cmbCCURRData.Rows.Add (cmbCCURRDataRow)
cmbCCURR.DisplayMember = "name"
cmbCCURR.ValueMember = "Value"
cmbCCURR.DataSource = cmbCCURRData
 cmbCCURR.SelectedValue=CInt(Item.CCURR)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtICALLCURR.text = item.ICALLCURR.toString()
dtpDNEXTCURR.value = System.DateTime.Now
if item.DNEXTCURR <> System.DateTime.MinValue then
  try
     dtpDNEXTCURR.value = item.DNEXTCURR
  catch
   dtpDNEXTCURR.value = System.DateTime.MinValue
  end try
else
   dtpDNEXTCURR.value = System.DateTime.Today
   dtpDNEXTCURR.Checked =false
end if
cmbCHOURData = New DataTable
cmbCHOURData.Columns.Add("name", GetType(System.String))
cmbCHOURData.Columns.Add("Value", GetType(System.Int32))
try
cmbCHOURDataRow = cmbCHOURData.NewRow
cmbCHOURDataRow("name") = "Да"
cmbCHOURDataRow("Value") = -1
cmbCHOURData.Rows.Add (cmbCHOURDataRow)
cmbCHOURDataRow = cmbCHOURData.NewRow
cmbCHOURDataRow("name") = "Нет"
cmbCHOURDataRow("Value") = 0
cmbCHOURData.Rows.Add (cmbCHOURDataRow)
cmbCHOUR.DisplayMember = "name"
cmbCHOUR.ValueMember = "Value"
cmbCHOUR.DataSource = cmbCHOURData
 cmbCHOUR.SelectedValue=CInt(Item.CHOUR)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtICALL.text = item.ICALL.toString()
txtNUMHOUR.text = item.NUMHOUR.toString()
dtpDNEXTHOUR.value = System.DateTime.Now
if item.DNEXTHOUR <> System.DateTime.MinValue then
  try
     dtpDNEXTHOUR.value = item.DNEXTHOUR
  catch
   dtpDNEXTHOUR.value = System.DateTime.MinValue
  end try
else
   dtpDNEXTHOUR.value = System.DateTime.Today
   dtpDNEXTHOUR.Checked =false
end if
dtpDLASTHOUR.value = System.DateTime.Now
if item.DLASTHOUR <> System.DateTime.MinValue then
  try
     dtpDLASTHOUR.value = item.DLASTHOUR
  catch
   dtpDLASTHOUR.value = System.DateTime.MinValue
  end try
else
   dtpDLASTHOUR.value = System.DateTime.Today
   dtpDLASTHOUR.Checked =false
end if
cmbC24Data = New DataTable
cmbC24Data.Columns.Add("name", GetType(System.String))
cmbC24Data.Columns.Add("Value", GetType(System.Int32))
try
cmbC24DataRow = cmbC24Data.NewRow
cmbC24DataRow("name") = "Да"
cmbC24DataRow("Value") = -1
cmbC24Data.Rows.Add (cmbC24DataRow)
cmbC24DataRow = cmbC24Data.NewRow
cmbC24DataRow("name") = "Нет"
cmbC24DataRow("Value") = 0
cmbC24Data.Rows.Add (cmbC24DataRow)
cmbC24.DisplayMember = "name"
cmbC24.ValueMember = "Value"
cmbC24.DataSource = cmbC24Data
 cmbC24.SelectedValue=CInt(Item.C24)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtICALL24.text = item.ICALL24.toString()
txtNUM24.text = item.NUM24.toString()
dtpDNEXT24.value = System.DateTime.Now
if item.DNEXT24 <> System.DateTime.MinValue then
  try
     dtpDNEXT24.value = item.DNEXT24
  catch
   dtpDNEXT24.value = System.DateTime.MinValue
  end try
else
   dtpDNEXT24.value = System.DateTime.Today
   dtpDNEXT24.Checked =false
end if
dtpDLASTDAY.value = System.DateTime.Now
if item.DLASTDAY <> System.DateTime.MinValue then
  try
     dtpDLASTDAY.value = item.DLASTDAY
  catch
   dtpDLASTDAY.value = System.DateTime.MinValue
  end try
else
   dtpDLASTDAY.value = System.DateTime.Today
   dtpDLASTDAY.Checked =false
end if
cmbCSUMData = New DataTable
cmbCSUMData.Columns.Add("name", GetType(System.String))
cmbCSUMData.Columns.Add("Value", GetType(System.Int32))
try
cmbCSUMDataRow = cmbCSUMData.NewRow
cmbCSUMDataRow("name") = "Да"
cmbCSUMDataRow("Value") = -1
cmbCSUMData.Rows.Add (cmbCSUMDataRow)
cmbCSUMDataRow = cmbCSUMData.NewRow
cmbCSUMDataRow("name") = "Нет"
cmbCSUMDataRow("Value") = 0
cmbCSUMData.Rows.Add (cmbCSUMDataRow)
cmbCSUM.DisplayMember = "name"
cmbCSUM.ValueMember = "Value"
cmbCSUM.DataSource = cmbCSUMData
 cmbCSUM.SelectedValue=CInt(Item.CSUM)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtICALLSUM.text = item.ICALLSUM.toString()
dtpDNEXTSUM.value = System.DateTime.Now
if item.DNEXTSUM <> System.DateTime.MinValue then
  try
     dtpDNEXTSUM.value = item.DNEXTSUM
  catch
   dtpDNEXTSUM.value = System.DateTime.MinValue
  end try
else
   dtpDNEXTSUM.value = System.DateTime.Today
   dtpDNEXTSUM.Checked =false
end if
cmbCELData = New DataTable
cmbCELData.Columns.Add("name", GetType(System.String))
cmbCELData.Columns.Add("Value", GetType(System.Int32))
try
cmbCELDataRow = cmbCELData.NewRow
cmbCELDataRow("name") = "Да"
cmbCELDataRow("Value") = -1
cmbCELData.Rows.Add (cmbCELDataRow)
cmbCELDataRow = cmbCELData.NewRow
cmbCELDataRow("name") = "Нет"
cmbCELDataRow("Value") = 0
cmbCELData.Rows.Add (cmbCELDataRow)
cmbCEL.DisplayMember = "name"
cmbCEL.ValueMember = "Value"
cmbCEL.DataSource = cmbCELData
 cmbCEL.SelectedValue=CInt(Item.CEL)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtIEL.text = item.IEL.toString()
dtpDNEXTEL.value = System.DateTime.Today
if item.DNEXTEL <> System.DateTime.MinValue then
  try
     dtpDNEXTEL.value = item.DNEXTEL
  catch
   dtpDNEXTEL.value = System.DateTime.MinValue
  end try
else
   dtpDNEXTEL.value = System.DateTime.Today
   dtpDNEXTEL.Checked =false
end if
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

   item.CSTATUS = cmbCSTATUS.SelectedValue
item.NMAXCALL = val(txtNMAXCALL.text)
item.MINREPEAT = val(txtMINREPEAT.text)
  if dtpDLOCK.checked=false then
       item.DLOCK = System.DateTime.MinValue
  else 
  try
    item.DLOCK = dtpDLOCK.value
  catch
    item.DLOCK = System.DateTime.MinValue
  end try
  end if
  if dtpDLASTCALL.checked=false then
       item.DLASTCALL = System.DateTime.MinValue
  else 
  try
    item.DLASTCALL = dtpDLASTCALL.value
  catch
    item.DLASTCALL = System.DateTime.MinValue
  end try
  end if
   item.CCURR = cmbCCURR.SelectedValue
item.ICALLCURR = val(txtICALLCURR.text)
  if dtpDNEXTCURR.checked=false then
       item.DNEXTCURR = System.DateTime.MinValue
  else 
  try
    item.DNEXTCURR = dtpDNEXTCURR.value
  catch
    item.DNEXTCURR = System.DateTime.MinValue
  end try
  end if
   item.CHOUR = cmbCHOUR.SelectedValue
item.ICALL = val(txtICALL.text)
item.NUMHOUR = val(txtNUMHOUR.text)
  if dtpDNEXTHOUR.checked=false then
       item.DNEXTHOUR = System.DateTime.MinValue
  else 
  try
    item.DNEXTHOUR = dtpDNEXTHOUR.value
  catch
    item.DNEXTHOUR = System.DateTime.MinValue
  end try
  end if
  if dtpDLASTHOUR.checked=false then
       item.DLASTHOUR = System.DateTime.MinValue
  else 
  try
    item.DLASTHOUR = dtpDLASTHOUR.value
  catch
    item.DLASTHOUR = System.DateTime.MinValue
  end try
  end if
   item.C24 = cmbC24.SelectedValue
item.ICALL24 = val(txtICALL24.text)
item.NUM24 = val(txtNUM24.text)
  if dtpDNEXT24.checked=false then
       item.DNEXT24 = System.DateTime.MinValue
  else 
  try
    item.DNEXT24 = dtpDNEXT24.value
  catch
    item.DNEXT24 = System.DateTime.MinValue
  end try
  end if
  if dtpDLASTDAY.checked=false then
       item.DLASTDAY = System.DateTime.MinValue
  else 
  try
    item.DLASTDAY = dtpDLASTDAY.value
  catch
    item.DLASTDAY = System.DateTime.MinValue
  end try
  end if
   item.CSUM = cmbCSUM.SelectedValue
item.ICALLSUM = val(txtICALLSUM.text)
  if dtpDNEXTSUM.checked=false then
       item.DNEXTSUM = System.DateTime.MinValue
  else 
  try
    item.DNEXTSUM = dtpDNEXTSUM.value
  catch
    item.DNEXTSUM = System.DateTime.MinValue
  end try
  end if
   item.CEL = cmbCEL.SelectedValue
item.IEL = val(txtIEL.text)
  if dtpDNEXTEL.checked=false then
       item.DNEXTEL = System.DateTime.MinValue
  else 
  try
    item.DNEXTEL = dtpDNEXTEL.value
  catch
    item.DNEXTEL = System.DateTime.MinValue
  end try
  end if
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
