
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Параметры соединения режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLT_CONNECT
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
Friend WithEvents lblConnectionEnabled  as  System.Windows.Forms.Label
Friend WithEvents cmbConnectionEnabled As System.Windows.Forms.ComboBox
Friend cmbConnectionEnabledDATA As DataTable
Friend cmbConnectionEnabledDATAROW As DataRow
Friend WithEvents lblConnectType  as  System.Windows.Forms.Label
Friend WithEvents txtConnectType As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdConnectType As System.Windows.Forms.Button
Friend WithEvents lblCONNECTLIMIT  as  System.Windows.Forms.Label
Friend WithEvents txtCONNECTLIMIT As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTheServer  as  System.Windows.Forms.Label
Friend WithEvents txtTheServer As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheServer As System.Windows.Forms.Button
Friend WithEvents cmdTheServerClear As System.Windows.Forms.Button
Friend WithEvents lblnetaddr  as  System.Windows.Forms.Label
Friend WithEvents txtnetaddr As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCSPEED  as  System.Windows.Forms.Label
Friend WithEvents txtCSPEED As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCDATABIT  as  System.Windows.Forms.Label
Friend WithEvents txtCDATABIT As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCPARITY  as  System.Windows.Forms.Label
Friend WithEvents cmbCPARITY As System.Windows.Forms.ComboBox
Friend cmbCPARITYDATA As DataTable
Friend cmbCPARITYDATAROW As DataRow
Friend WithEvents lblCSTOPBITS  as  System.Windows.Forms.Label
Friend WithEvents txtCSTOPBITS As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblFlowControl  as  System.Windows.Forms.Label
Friend WithEvents txtFlowControl As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblComPortNum  as  System.Windows.Forms.Label
Friend WithEvents txtComPortNum As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblIPAddr  as  System.Windows.Forms.Label
Friend WithEvents txtIPAddr As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblPortNum  as  System.Windows.Forms.Label
Friend WithEvents txtPortNum As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblUserName  as  System.Windows.Forms.Label
Friend WithEvents txtUserName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblPassword  as  System.Windows.Forms.Label
Friend WithEvents txtPassword As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCTOWNCODE  as  System.Windows.Forms.Label
Friend WithEvents txtCTOWNCODE As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCPHONE  as  System.Windows.Forms.Label
Friend WithEvents txtCPHONE As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblATCommand  as  System.Windows.Forms.Label
Friend WithEvents txtATCommand As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblcallerID  as  System.Windows.Forms.Label
Friend WithEvents txtcallerID As LATIR2GuiManager.TouchTextBox

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
Me.lblConnectionEnabled = New System.Windows.Forms.Label
Me.cmbConnectionEnabled = New System.Windows.Forms.ComboBox
Me.lblConnectType = New System.Windows.Forms.Label
Me.txtConnectType = New LATIR2GuiManager.TouchTextBox
Me.cmdConnectType = New System.Windows.Forms.Button
Me.lblCONNECTLIMIT = New System.Windows.Forms.Label
Me.txtCONNECTLIMIT = New LATIR2GuiManager.TouchTextBox
Me.lblTheServer = New System.Windows.Forms.Label
Me.txtTheServer = New LATIR2GuiManager.TouchTextBox
Me.cmdTheServer = New System.Windows.Forms.Button
Me.cmdTheServerClear = New System.Windows.Forms.Button
Me.lblnetaddr = New System.Windows.Forms.Label
Me.txtnetaddr = New LATIR2GuiManager.TouchTextBox
Me.lblCSPEED = New System.Windows.Forms.Label
Me.txtCSPEED = New LATIR2GuiManager.TouchTextBox
Me.lblCDATABIT = New System.Windows.Forms.Label
Me.txtCDATABIT = New LATIR2GuiManager.TouchTextBox
Me.lblCPARITY = New System.Windows.Forms.Label
Me.cmbCPARITY = New System.Windows.Forms.ComboBox
Me.lblCSTOPBITS = New System.Windows.Forms.Label
Me.txtCSTOPBITS = New LATIR2GuiManager.TouchTextBox
Me.lblFlowControl = New System.Windows.Forms.Label
Me.txtFlowControl = New LATIR2GuiManager.TouchTextBox
Me.lblComPortNum = New System.Windows.Forms.Label
Me.txtComPortNum = New LATIR2GuiManager.TouchTextBox
Me.lblIPAddr = New System.Windows.Forms.Label
Me.txtIPAddr = New LATIR2GuiManager.TouchTextBox
Me.lblPortNum = New System.Windows.Forms.Label
Me.txtPortNum = New LATIR2GuiManager.TouchTextBox
Me.lblUserName = New System.Windows.Forms.Label
Me.txtUserName = New LATIR2GuiManager.TouchTextBox
Me.lblPassword = New System.Windows.Forms.Label
Me.txtPassword = New LATIR2GuiManager.TouchTextBox
Me.lblCTOWNCODE = New System.Windows.Forms.Label
Me.txtCTOWNCODE = New LATIR2GuiManager.TouchTextBox
Me.lblCPHONE = New System.Windows.Forms.Label
Me.txtCPHONE = New LATIR2GuiManager.TouchTextBox
Me.lblATCommand = New System.Windows.Forms.Label
Me.txtATCommand = New LATIR2GuiManager.TouchTextBox
Me.lblcallerID = New System.Windows.Forms.Label
Me.txtcallerID = New LATIR2GuiManager.TouchTextBox

Me.lblConnectionEnabled.Location = New System.Drawing.Point(20,5)
Me.lblConnectionEnabled.name = "lblConnectionEnabled"
Me.lblConnectionEnabled.Size = New System.Drawing.Size(200, 20)
Me.lblConnectionEnabled.TabIndex = 1
Me.lblConnectionEnabled.Text = "Подключение разрешено"
Me.lblConnectionEnabled.ForeColor = System.Drawing.Color.Blue
Me.cmbConnectionEnabled.Location = New System.Drawing.Point(20,27)
Me.cmbConnectionEnabled.name = "cmbConnectionEnabled"
Me.cmbConnectionEnabled.Size = New System.Drawing.Size(200,  20)
Me.cmbConnectionEnabled.TabIndex = 2
Me.lblConnectType.Location = New System.Drawing.Point(20,52)
Me.lblConnectType.name = "lblConnectType"
Me.lblConnectType.Size = New System.Drawing.Size(200, 20)
Me.lblConnectType.TabIndex = 3
Me.lblConnectType.Text = "Тип подключения"
Me.lblConnectType.ForeColor = System.Drawing.Color.Black
Me.txtConnectType.Location = New System.Drawing.Point(20,74)
Me.txtConnectType.name = "txtConnectType"
Me.txtConnectType.ReadOnly = True
Me.txtConnectType.Size = New System.Drawing.Size(176, 20)
Me.txtConnectType.TabIndex = 4
Me.txtConnectType.Text = "" 
Me.cmdConnectType.Location = New System.Drawing.Point(198,74)
Me.cmdConnectType.name = "cmdConnectType"
Me.cmdConnectType.Size = New System.Drawing.Size(22, 20)
Me.cmdConnectType.TabIndex = 5
Me.cmdConnectType.Text = "..." 
Me.lblCONNECTLIMIT.Location = New System.Drawing.Point(20,99)
Me.lblCONNECTLIMIT.name = "lblCONNECTLIMIT"
Me.lblCONNECTLIMIT.Size = New System.Drawing.Size(200, 20)
Me.lblCONNECTLIMIT.TabIndex = 6
Me.lblCONNECTLIMIT.Text = "Время на соединение"
Me.lblCONNECTLIMIT.ForeColor = System.Drawing.Color.Blue
Me.txtCONNECTLIMIT.Location = New System.Drawing.Point(20,121)
Me.txtCONNECTLIMIT.name = "txtCONNECTLIMIT"
Me.txtCONNECTLIMIT.MultiLine = false
Me.txtCONNECTLIMIT.Size = New System.Drawing.Size(200,  20)
Me.txtCONNECTLIMIT.TabIndex = 7
Me.txtCONNECTLIMIT.Text = "" 
Me.txtCONNECTLIMIT.MaxLength = 27
Me.lblTheServer.Location = New System.Drawing.Point(20,146)
Me.lblTheServer.name = "lblTheServer"
Me.lblTheServer.Size = New System.Drawing.Size(200, 20)
Me.lblTheServer.TabIndex = 8
Me.lblTheServer.Text = "Сервер опроса"
Me.lblTheServer.ForeColor = System.Drawing.Color.Blue
Me.txtTheServer.Location = New System.Drawing.Point(20,168)
Me.txtTheServer.name = "txtTheServer"
Me.txtTheServer.ReadOnly = True
Me.txtTheServer.Size = New System.Drawing.Size(155, 20)
Me.txtTheServer.TabIndex = 9
Me.txtTheServer.Text = "" 
Me.cmdTheServer.Location = New System.Drawing.Point(176,168)
Me.cmdTheServer.name = "cmdTheServer"
Me.cmdTheServer.Size = New System.Drawing.Size(22, 20)
Me.cmdTheServer.TabIndex = 10
Me.cmdTheServer.Text = "..." 
Me.cmdTheServerClear.Location = New System.Drawing.Point(198,168)
Me.cmdTheServerClear.name = "cmdTheServerClear"
Me.cmdTheServerClear.Size = New System.Drawing.Size(22, 20)
Me.cmdTheServerClear.TabIndex = 11
Me.cmdTheServerClear.Text = "X" 
Me.lblnetaddr.Location = New System.Drawing.Point(20,193)
Me.lblnetaddr.name = "lblnetaddr"
Me.lblnetaddr.Size = New System.Drawing.Size(200, 20)
Me.lblnetaddr.TabIndex = 12
Me.lblnetaddr.Text = "Сетевой адрес"
Me.lblnetaddr.ForeColor = System.Drawing.Color.Blue
Me.txtnetaddr.Location = New System.Drawing.Point(20,215)
Me.txtnetaddr.name = "txtnetaddr"
Me.txtnetaddr.MultiLine = false
Me.txtnetaddr.Size = New System.Drawing.Size(200,  20)
Me.txtnetaddr.TabIndex = 13
Me.txtnetaddr.Text = "" 
Me.txtnetaddr.MaxLength = 15
Me.lblCSPEED.Location = New System.Drawing.Point(20,240)
Me.lblCSPEED.name = "lblCSPEED"
Me.lblCSPEED.Size = New System.Drawing.Size(200, 20)
Me.lblCSPEED.TabIndex = 14
Me.lblCSPEED.Text = "Скорость бод"
Me.lblCSPEED.ForeColor = System.Drawing.Color.Blue
Me.txtCSPEED.Location = New System.Drawing.Point(20,262)
Me.txtCSPEED.name = "txtCSPEED"
Me.txtCSPEED.Size = New System.Drawing.Size(200, 20)
Me.txtCSPEED.TabIndex = 15
Me.txtCSPEED.Text = "" 
Me.lblCDATABIT.Location = New System.Drawing.Point(20,287)
Me.lblCDATABIT.name = "lblCDATABIT"
Me.lblCDATABIT.Size = New System.Drawing.Size(200, 20)
Me.lblCDATABIT.TabIndex = 16
Me.lblCDATABIT.Text = "Биты данных"
Me.lblCDATABIT.ForeColor = System.Drawing.Color.Blue
Me.txtCDATABIT.Location = New System.Drawing.Point(20,309)
Me.txtCDATABIT.name = "txtCDATABIT"
Me.txtCDATABIT.Size = New System.Drawing.Size(200, 20)
Me.txtCDATABIT.TabIndex = 17
Me.txtCDATABIT.Text = "" 
Me.lblCPARITY.Location = New System.Drawing.Point(20,334)
Me.lblCPARITY.name = "lblCPARITY"
Me.lblCPARITY.Size = New System.Drawing.Size(200, 20)
Me.lblCPARITY.TabIndex = 18
Me.lblCPARITY.Text = "Четность"
Me.lblCPARITY.ForeColor = System.Drawing.Color.Blue
Me.cmbCPARITY.Location = New System.Drawing.Point(20,356)
Me.cmbCPARITY.name = "cmbCPARITY"
Me.cmbCPARITY.Size = New System.Drawing.Size(200,  20)
Me.cmbCPARITY.TabIndex = 19
Me.cmbCPARITY.DropDownStyle = ComboBoxStyle.DropDownList
Me.lblCSTOPBITS.Location = New System.Drawing.Point(20,381)
Me.lblCSTOPBITS.name = "lblCSTOPBITS"
Me.lblCSTOPBITS.Size = New System.Drawing.Size(200, 20)
Me.lblCSTOPBITS.TabIndex = 20
Me.lblCSTOPBITS.Text = "Стоповые биты"
Me.lblCSTOPBITS.ForeColor = System.Drawing.Color.Blue
Me.txtCSTOPBITS.Location = New System.Drawing.Point(20,403)
Me.txtCSTOPBITS.name = "txtCSTOPBITS"
Me.txtCSTOPBITS.MultiLine = false
Me.txtCSTOPBITS.Size = New System.Drawing.Size(200,  20)
Me.txtCSTOPBITS.TabIndex = 21
Me.txtCSTOPBITS.Text = "" 
Me.txtCSTOPBITS.MaxLength = 15
Me.lblFlowControl.Location = New System.Drawing.Point(230,5)
Me.lblFlowControl.name = "lblFlowControl"
Me.lblFlowControl.Size = New System.Drawing.Size(200, 20)
Me.lblFlowControl.TabIndex = 22
Me.lblFlowControl.Text = "FlowControl"
Me.lblFlowControl.ForeColor = System.Drawing.Color.Blue
Me.txtFlowControl.Location = New System.Drawing.Point(230,27)
Me.txtFlowControl.name = "txtFlowControl"
Me.txtFlowControl.Size = New System.Drawing.Size(200, 20)
Me.txtFlowControl.TabIndex = 23
Me.txtFlowControl.Text = "" 
Me.lblComPortNum.Location = New System.Drawing.Point(230,52)
Me.lblComPortNum.name = "lblComPortNum"
Me.lblComPortNum.Size = New System.Drawing.Size(200, 20)
Me.lblComPortNum.TabIndex = 24
Me.lblComPortNum.Text = "Com Port"
Me.lblComPortNum.ForeColor = System.Drawing.Color.Blue
Me.txtComPortNum.Location = New System.Drawing.Point(230,74)
Me.txtComPortNum.name = "txtComPortNum"
Me.txtComPortNum.Size = New System.Drawing.Size(200, 20)
Me.txtComPortNum.TabIndex = 25
Me.txtComPortNum.Text = "" 
Me.lblIPAddr.Location = New System.Drawing.Point(230,99)
Me.lblIPAddr.name = "lblIPAddr"
Me.lblIPAddr.Size = New System.Drawing.Size(200, 20)
Me.lblIPAddr.TabIndex = 26
Me.lblIPAddr.Text = "IP адрес"
Me.lblIPAddr.ForeColor = System.Drawing.Color.Blue
Me.txtIPAddr.Location = New System.Drawing.Point(230,121)
Me.txtIPAddr.name = "txtIPAddr"
Me.txtIPAddr.Size = New System.Drawing.Size(200, 20)
Me.txtIPAddr.TabIndex = 27
Me.txtIPAddr.Text = "" 
Me.lblPortNum.Location = New System.Drawing.Point(230,146)
Me.lblPortNum.name = "lblPortNum"
Me.lblPortNum.Size = New System.Drawing.Size(200, 20)
Me.lblPortNum.TabIndex = 28
Me.lblPortNum.Text = "TCP Порт"
Me.lblPortNum.ForeColor = System.Drawing.Color.Blue
Me.txtPortNum.Location = New System.Drawing.Point(230,168)
Me.txtPortNum.name = "txtPortNum"
Me.txtPortNum.MultiLine = false
Me.txtPortNum.Size = New System.Drawing.Size(200,  20)
Me.txtPortNum.TabIndex = 29
Me.txtPortNum.Text = "" 
Me.txtPortNum.MaxLength = 15
Me.lblUserName.Location = New System.Drawing.Point(230,193)
Me.lblUserName.name = "lblUserName"
Me.lblUserName.Size = New System.Drawing.Size(200, 20)
Me.lblUserName.TabIndex = 30
Me.lblUserName.Text = "Пользователь"
Me.lblUserName.ForeColor = System.Drawing.Color.Blue
Me.txtUserName.Location = New System.Drawing.Point(230,215)
Me.txtUserName.name = "txtUserName"
Me.txtUserName.Size = New System.Drawing.Size(200, 20)
Me.txtUserName.TabIndex = 31
Me.txtUserName.Text = "" 
Me.lblPassword.Location = New System.Drawing.Point(230,240)
Me.lblPassword.name = "lblPassword"
Me.lblPassword.Size = New System.Drawing.Size(200, 20)
Me.lblPassword.TabIndex = 32
Me.lblPassword.Text = "Пароль"
Me.lblPassword.ForeColor = System.Drawing.Color.Blue
Me.txtPassword.Location = New System.Drawing.Point(230,262)
Me.txtPassword.name = "txtPassword"
Me.txtPassword.Size = New System.Drawing.Size(200, 20)
Me.txtPassword.TabIndex = 33
Me.txtPassword.Text = "" 
Me.lblCTOWNCODE.Location = New System.Drawing.Point(230,287)
Me.lblCTOWNCODE.name = "lblCTOWNCODE"
Me.lblCTOWNCODE.Size = New System.Drawing.Size(200, 20)
Me.lblCTOWNCODE.TabIndex = 34
Me.lblCTOWNCODE.Text = "Код города"
Me.lblCTOWNCODE.ForeColor = System.Drawing.Color.Blue
Me.txtCTOWNCODE.Location = New System.Drawing.Point(230,309)
Me.txtCTOWNCODE.name = "txtCTOWNCODE"
Me.txtCTOWNCODE.Size = New System.Drawing.Size(200, 20)
Me.txtCTOWNCODE.TabIndex = 35
Me.txtCTOWNCODE.Text = "" 
Me.lblCPHONE.Location = New System.Drawing.Point(230,334)
Me.lblCPHONE.name = "lblCPHONE"
Me.lblCPHONE.Size = New System.Drawing.Size(200, 20)
Me.lblCPHONE.TabIndex = 36
Me.lblCPHONE.Text = "Телефон"
Me.lblCPHONE.ForeColor = System.Drawing.Color.Blue
Me.txtCPHONE.Location = New System.Drawing.Point(230,356)
Me.txtCPHONE.name = "txtCPHONE"
Me.txtCPHONE.Size = New System.Drawing.Size(200, 20)
Me.txtCPHONE.TabIndex = 37
Me.txtCPHONE.Text = "" 
Me.lblATCommand.Location = New System.Drawing.Point(230,381)
Me.lblATCommand.name = "lblATCommand"
Me.lblATCommand.Size = New System.Drawing.Size(200, 20)
Me.lblATCommand.TabIndex = 38
Me.lblATCommand.Text = "AT команда"
Me.lblATCommand.ForeColor = System.Drawing.Color.Blue
Me.txtATCommand.Location = New System.Drawing.Point(230,403)
Me.txtATCommand.name = "txtATCommand"
Me.txtATCommand.MultiLine = True
Me.txtATCommand.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtATCommand.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtATCommand.TabIndex = 39
Me.txtATCommand.Text = "" 
Me.lblcallerID.Location = New System.Drawing.Point(440,5)
Me.lblcallerID.name = "lblcallerID"
Me.lblcallerID.Size = New System.Drawing.Size(200, 20)
Me.lblcallerID.TabIndex = 40
Me.lblcallerID.Text = "Идентификатор промеж. устройства"
Me.lblcallerID.ForeColor = System.Drawing.Color.Blue
Me.txtcallerID.Location = New System.Drawing.Point(440,27)
Me.txtcallerID.name = "txtcallerID"
Me.txtcallerID.Size = New System.Drawing.Size(200, 20)
Me.txtcallerID.TabIndex = 41
Me.txtcallerID.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblConnectionEnabled)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbConnectionEnabled)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblConnectType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtConnectType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdConnectType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCONNECTLIMIT)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCONNECTLIMIT)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheServer)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheServer)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheServer)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheServerClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblnetaddr)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtnetaddr)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCSPEED)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCSPEED)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCDATABIT)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCDATABIT)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCPARITY)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbCPARITY)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCSTOPBITS)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCSTOPBITS)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblFlowControl)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtFlowControl)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblComPortNum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtComPortNum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIPAddr)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtIPAddr)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPortNum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPortNum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblUserName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtUserName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPassword)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPassword)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCTOWNCODE)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCTOWNCODE)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCPHONE)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCPHONE)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblATCommand)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtATCommand)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcallerID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtcallerID)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLT_CONNECT"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub cmbConnectionEnabled_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbConnectionEnabled.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtConnectType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConnectType.TextChanged
  Changing

end sub
private sub cmdConnectType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnectType.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLD_CONNECTTYPE","",System.guid.Empty, id, brief) Then
          txtConnectType.Tag = id
          txtConnectType.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtCONNECTLIMIT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCONNECTLIMIT.Validating
        If txtCONNECTLIMIT.Text <> "" Then
            try
            If Not IsNumeric(txtCONNECTLIMIT.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtCONNECTLIMIT.Text) < -922337203685478# Or Val(txtCONNECTLIMIT.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtCONNECTLIMIT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONNECTLIMIT.TextChanged
  Changing

end sub
private sub txtTheServer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheServer.TextChanged
  Changing

end sub
private sub cmdTheServer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheServer.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPSRV_INFO","",System.guid.Empty, id, brief) Then
          txtTheServer.Tag = id
          txtTheServer.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdTheServerClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheServerClear.Click
  try
          txtTheServer.Tag = Guid.Empty
          txtTheServer.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtnetaddr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtnetaddr.Validating
        If txtnetaddr.Text <> "" Then
            try
            If Not IsNumeric(txtnetaddr.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtnetaddr.Text) < -2000000000 Or Val(txtnetaddr.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtnetaddr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnetaddr.TextChanged
  Changing

end sub
private sub txtCSPEED_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCSPEED.TextChanged
  Changing

end sub
private sub txtCDATABIT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCDATABIT.TextChanged
  Changing

end sub
private sub cmbCPARITY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPARITY.SelectedIndexChanged
  try
     Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtCSTOPBITS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCSTOPBITS.Validating
        If txtCSTOPBITS.Text <> "" Then
            try
            If Not IsNumeric(txtCSTOPBITS.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtCSTOPBITS.Text) < -2000000000 Or Val(txtCSTOPBITS.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtCSTOPBITS_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCSTOPBITS.TextChanged
  Changing

end sub
private sub txtFlowControl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFlowControl.TextChanged
  Changing

end sub
private sub txtComPortNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComPortNum.TextChanged
  Changing

end sub
private sub txtIPAddr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIPAddr.TextChanged
  Changing

end sub
        Private Sub txtPortNum_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPortNum.Validating
        If txtPortNum.Text <> "" Then
            try
            If Not IsNumeric(txtPortNum.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtPortNum.Text) < -2000000000 Or Val(txtPortNum.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtPortNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPortNum.TextChanged
  Changing

end sub
private sub txtUserName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.TextChanged
  Changing

end sub
private sub txtPassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
  Changing

end sub
private sub txtCTOWNCODE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCTOWNCODE.TextChanged
  Changing

end sub
private sub txtCPHONE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCPHONE.TextChanged
  Changing

end sub
private sub txtATCommand_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtATCommand.TextChanged
  Changing

end sub
private sub txtcallerID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcallerID.TextChanged
  Changing

end sub

Public Item As TPLT.TPLT.TPLT_CONNECT
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLT.TPLT.TPLT_CONNECT)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

cmbConnectionEnabledData = New DataTable
cmbConnectionEnabledData.Columns.Add("name", GetType(System.String))
cmbConnectionEnabledData.Columns.Add("Value", GetType(System.Int32))
try
cmbConnectionEnabledDataRow = cmbConnectionEnabledData.NewRow
cmbConnectionEnabledDataRow("name") = "Да"
cmbConnectionEnabledDataRow("Value") = -1
cmbConnectionEnabledData.Rows.Add (cmbConnectionEnabledDataRow)
cmbConnectionEnabledDataRow = cmbConnectionEnabledData.NewRow
cmbConnectionEnabledDataRow("name") = "Нет"
cmbConnectionEnabledDataRow("Value") = 0
cmbConnectionEnabledData.Rows.Add (cmbConnectionEnabledDataRow)
cmbConnectionEnabled.DisplayMember = "name"
cmbConnectionEnabled.ValueMember = "Value"
cmbConnectionEnabled.DataSource = cmbConnectionEnabledData
 cmbConnectionEnabled.SelectedValue=CInt(Item.ConnectionEnabled)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
If Not item.ConnectType Is Nothing Then
  txtConnectType.Tag = item.ConnectType.id
  txtConnectType.text = item.ConnectType.brief
else
  txtConnectType.Tag = System.Guid.Empty 
  txtConnectType.text = "" 
End If
txtCONNECTLIMIT.text = item.CONNECTLIMIT.toString()
If Not item.TheServer Is Nothing Then
  txtTheServer.Tag = item.TheServer.id
  txtTheServer.text = item.TheServer.brief
else
  txtTheServer.Tag = System.Guid.Empty 
  txtTheServer.text = "" 
End If
txtnetaddr.text = item.netaddr.toString()
txtCSPEED.text = item.CSPEED
txtCDATABIT.text = item.CDATABIT
cmbCPARITYData = New DataTable
cmbCPARITYData.Columns.Add("name", GetType(System.String))
cmbCPARITYData.Columns.Add("Value", GetType(System.Int32))
try
cmbCPARITYDataRow = cmbCPARITYData.NewRow
cmbCPARITYDataRow("name") = "None"
cmbCPARITYDataRow("Value") = 0
cmbCPARITYData.Rows.Add (cmbCPARITYDataRow)
cmbCPARITYDataRow = cmbCPARITYData.NewRow
cmbCPARITYDataRow("name") = "Even"
cmbCPARITYDataRow("Value") = 1
cmbCPARITYData.Rows.Add (cmbCPARITYDataRow)
cmbCPARITYDataRow = cmbCPARITYData.NewRow
cmbCPARITYDataRow("name") = "Odd"
cmbCPARITYDataRow("Value") = 2
cmbCPARITYData.Rows.Add (cmbCPARITYDataRow)
cmbCPARITYDataRow = cmbCPARITYData.NewRow
cmbCPARITYDataRow("name") = "Mark"
cmbCPARITYDataRow("Value") = 3
cmbCPARITYData.Rows.Add (cmbCPARITYDataRow)
cmbCPARITYDataRow = cmbCPARITYData.NewRow
cmbCPARITYDataRow("name") = "Space"
cmbCPARITYDataRow("Value") = 4
cmbCPARITYData.Rows.Add (cmbCPARITYDataRow)
cmbCPARITY.DisplayMember = "name"
cmbCPARITY.ValueMember = "Value"
cmbCPARITY.DataSource = cmbCPARITYData
 cmbCPARITY.SelectedValue=CInt(Item.CPARITY)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtCSTOPBITS.text = item.CSTOPBITS.toString()
txtFlowControl.text = item.FlowControl
txtComPortNum.text = item.ComPortNum
txtIPAddr.text = item.IPAddr
txtPortNum.text = item.PortNum.toString()
txtUserName.text = item.UserName
txtPassword.text = item.Password
txtCTOWNCODE.text = item.CTOWNCODE
txtCPHONE.text = item.CPHONE
txtATCommand.text = item.ATCommand
txtcallerID.text = item.callerID
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

   item.ConnectionEnabled = cmbConnectionEnabled.SelectedValue
If not txtConnectType.Tag.Equals(System.Guid.Empty) Then
  item.ConnectType = Item.Application.FindRowObject("TPLD_CONNECTTYPE",txtConnectType.Tag)
Else
   item.ConnectType = Nothing
End If
item.CONNECTLIMIT = cdbl(txtCONNECTLIMIT.text)
If not txtTheServer.Tag.Equals(System.Guid.Empty) Then
  item.TheServer = Item.Application.FindRowObject("TPSRV_INFO",txtTheServer.Tag)
Else
   item.TheServer = Nothing
End If
item.netaddr = val(txtnetaddr.text)
item.CSPEED = txtCSPEED.text
item.CDATABIT = txtCDATABIT.text
   item.CPARITY = cmbCPARITY.SelectedValue
item.CSTOPBITS = val(txtCSTOPBITS.text)
item.FlowControl = txtFlowControl.text
item.ComPortNum = txtComPortNum.text
item.IPAddr = txtIPAddr.text
item.PortNum = val(txtPortNum.text)
item.UserName = txtUserName.text
item.Password = txtPassword.text
item.CTOWNCODE = txtCTOWNCODE.text
item.CPHONE = txtCPHONE.text
item.ATCommand = txtATCommand.text
item.callerID = txtcallerID.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtConnectType.Tag.Equals(System.Guid.Empty)
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
