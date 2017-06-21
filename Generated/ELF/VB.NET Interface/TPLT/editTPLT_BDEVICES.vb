
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Описание режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLT_BDEVICES
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
Friend WithEvents lblTheNode  as  System.Windows.Forms.Label
Friend WithEvents txtTheNode As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheNode As System.Windows.Forms.Button
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblThePhone  as  System.Windows.Forms.Label
Friend WithEvents txtThePhone As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblAddr  as  System.Windows.Forms.Label
Friend WithEvents txtAddr As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDEVType  as  System.Windows.Forms.Label
Friend WithEvents txtDEVType As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdDEVType As System.Windows.Forms.Button
Friend WithEvents cmdDEVTypeClear As System.Windows.Forms.Button
Friend WithEvents lblShab  as  System.Windows.Forms.Label
Friend WithEvents txtShab As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdShab As System.Windows.Forms.Button
Friend WithEvents cmdShabClear As System.Windows.Forms.Button
Friend WithEvents lblDevGrp  as  System.Windows.Forms.Label
Friend WithEvents txtDevGrp As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdDevGrp As System.Windows.Forms.Button
Friend WithEvents lblTHESCHEMA  as  System.Windows.Forms.Label
Friend WithEvents txtTHESCHEMA As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTHESCHEMA As System.Windows.Forms.Button
Friend WithEvents cmdTHESCHEMAClear As System.Windows.Forms.Button
Friend WithEvents lblTheServer  as  System.Windows.Forms.Label
Friend WithEvents txtTheServer As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheServer As System.Windows.Forms.Button
Friend WithEvents cmdTheServerClear As System.Windows.Forms.Button
Friend WithEvents lblNPLOCK  as  System.Windows.Forms.Label
Friend WithEvents dtpNPLOCK As System.Windows.Forms.DateTimePicker
Friend WithEvents lblCONNECTED  as  System.Windows.Forms.Label
Friend WithEvents cmbCONNECTED As System.Windows.Forms.ComboBox
Friend cmbCONNECTEDDATA As DataTable
Friend cmbCONNECTEDDATAROW As DataRow

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
Me.lblTheNode = New System.Windows.Forms.Label
Me.txtTheNode = New LATIR2GuiManager.TouchTextBox
Me.cmdTheNode = New System.Windows.Forms.Button
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New LATIR2GuiManager.TouchTextBox
Me.lblThePhone = New System.Windows.Forms.Label
Me.txtThePhone = New LATIR2GuiManager.TouchTextBox
Me.lblAddr = New System.Windows.Forms.Label
Me.txtAddr = New LATIR2GuiManager.TouchTextBox
Me.lblDEVType = New System.Windows.Forms.Label
Me.txtDEVType = New LATIR2GuiManager.TouchTextBox
Me.cmdDEVType = New System.Windows.Forms.Button
Me.cmdDEVTypeClear = New System.Windows.Forms.Button
Me.lblShab = New System.Windows.Forms.Label
Me.txtShab = New LATIR2GuiManager.TouchTextBox
Me.cmdShab = New System.Windows.Forms.Button
Me.cmdShabClear = New System.Windows.Forms.Button
Me.lblDevGrp = New System.Windows.Forms.Label
Me.txtDevGrp = New LATIR2GuiManager.TouchTextBox
Me.cmdDevGrp = New System.Windows.Forms.Button
Me.lblTHESCHEMA = New System.Windows.Forms.Label
Me.txtTHESCHEMA = New LATIR2GuiManager.TouchTextBox
Me.cmdTHESCHEMA = New System.Windows.Forms.Button
Me.cmdTHESCHEMAClear = New System.Windows.Forms.Button
Me.lblTheServer = New System.Windows.Forms.Label
Me.txtTheServer = New LATIR2GuiManager.TouchTextBox
Me.cmdTheServer = New System.Windows.Forms.Button
Me.cmdTheServerClear = New System.Windows.Forms.Button
Me.lblNPLOCK = New System.Windows.Forms.Label
Me.dtpNPLOCK = New System.Windows.Forms.DateTimePicker
Me.lblCONNECTED = New System.Windows.Forms.Label
Me.cmbCONNECTED = New System.Windows.Forms.ComboBox

Me.lblTheNode.Location = New System.Drawing.Point(20,5)
Me.lblTheNode.name = "lblTheNode"
Me.lblTheNode.Size = New System.Drawing.Size(200, 20)
Me.lblTheNode.TabIndex = 1
Me.lblTheNode.Text = "Узел"
Me.lblTheNode.ForeColor = System.Drawing.Color.Black
Me.txtTheNode.Location = New System.Drawing.Point(20,27)
Me.txtTheNode.name = "txtTheNode"
Me.txtTheNode.ReadOnly = True
Me.txtTheNode.Size = New System.Drawing.Size(176, 20)
Me.txtTheNode.TabIndex = 2
Me.txtTheNode.Text = "" 
Me.cmdTheNode.Location = New System.Drawing.Point(198,27)
Me.cmdTheNode.name = "cmdTheNode"
Me.cmdTheNode.Size = New System.Drawing.Size(22, 20)
Me.cmdTheNode.TabIndex = 3
Me.cmdTheNode.Text = "..." 
Me.lblName.Location = New System.Drawing.Point(20,52)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 4
Me.lblName.Text = "Название"
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,74)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 5
Me.txtName.Text = "" 
Me.lblThePhone.Location = New System.Drawing.Point(20,99)
Me.lblThePhone.name = "lblThePhone"
Me.lblThePhone.Size = New System.Drawing.Size(200, 20)
Me.lblThePhone.TabIndex = 6
Me.lblThePhone.Text = "Телефон"
Me.lblThePhone.ForeColor = System.Drawing.Color.Blue
Me.txtThePhone.Location = New System.Drawing.Point(20,121)
Me.txtThePhone.name = "txtThePhone"
Me.txtThePhone.Size = New System.Drawing.Size(200, 20)
Me.txtThePhone.TabIndex = 7
Me.txtThePhone.Text = "" 
Me.lblAddr.Location = New System.Drawing.Point(20,146)
Me.lblAddr.name = "lblAddr"
Me.lblAddr.Size = New System.Drawing.Size(200, 20)
Me.lblAddr.TabIndex = 8
Me.lblAddr.Text = "Адрес"
Me.lblAddr.ForeColor = System.Drawing.Color.Blue
Me.txtAddr.Location = New System.Drawing.Point(20,168)
Me.txtAddr.name = "txtAddr"
Me.txtAddr.MultiLine = True
Me.txtAddr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtAddr.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtAddr.TabIndex = 9
Me.txtAddr.Text = "" 
Me.lblDEVType.Location = New System.Drawing.Point(20,238)
Me.lblDEVType.name = "lblDEVType"
Me.lblDEVType.Size = New System.Drawing.Size(200, 20)
Me.lblDEVType.TabIndex = 10
Me.lblDEVType.Text = "Устройство"
Me.lblDEVType.ForeColor = System.Drawing.Color.Blue
Me.txtDEVType.Location = New System.Drawing.Point(20,260)
Me.txtDEVType.name = "txtDEVType"
Me.txtDEVType.ReadOnly = True
Me.txtDEVType.Size = New System.Drawing.Size(155, 20)
Me.txtDEVType.TabIndex = 11
Me.txtDEVType.Text = "" 
Me.cmdDEVType.Location = New System.Drawing.Point(176,260)
Me.cmdDEVType.name = "cmdDEVType"
Me.cmdDEVType.Size = New System.Drawing.Size(22, 20)
Me.cmdDEVType.TabIndex = 12
Me.cmdDEVType.Text = "..." 
Me.cmdDEVTypeClear.Location = New System.Drawing.Point(198,260)
Me.cmdDEVTypeClear.name = "cmdDEVTypeClear"
Me.cmdDEVTypeClear.Size = New System.Drawing.Size(22, 20)
Me.cmdDEVTypeClear.TabIndex = 13
Me.cmdDEVTypeClear.Text = "X" 
Me.lblShab.Location = New System.Drawing.Point(20,285)
Me.lblShab.name = "lblShab"
Me.lblShab.Size = New System.Drawing.Size(200, 20)
Me.lblShab.TabIndex = 14
Me.lblShab.Text = "Снабжающая орг."
Me.lblShab.ForeColor = System.Drawing.Color.Blue
Me.txtShab.Location = New System.Drawing.Point(20,307)
Me.txtShab.name = "txtShab"
Me.txtShab.ReadOnly = True
Me.txtShab.Size = New System.Drawing.Size(155, 20)
Me.txtShab.TabIndex = 15
Me.txtShab.Text = "" 
Me.cmdShab.Location = New System.Drawing.Point(176,307)
Me.cmdShab.name = "cmdShab"
Me.cmdShab.Size = New System.Drawing.Size(22, 20)
Me.cmdShab.TabIndex = 16
Me.cmdShab.Text = "..." 
Me.cmdShabClear.Location = New System.Drawing.Point(198,307)
Me.cmdShabClear.name = "cmdShabClear"
Me.cmdShabClear.Size = New System.Drawing.Size(22, 20)
Me.cmdShabClear.TabIndex = 17
Me.cmdShabClear.Text = "X" 
Me.lblDevGrp.Location = New System.Drawing.Point(20,332)
Me.lblDevGrp.name = "lblDevGrp"
Me.lblDevGrp.Size = New System.Drawing.Size(200, 20)
Me.lblDevGrp.TabIndex = 18
Me.lblDevGrp.Text = "Группа"
Me.lblDevGrp.ForeColor = System.Drawing.Color.Black
Me.txtDevGrp.Location = New System.Drawing.Point(20,354)
Me.txtDevGrp.name = "txtDevGrp"
Me.txtDevGrp.ReadOnly = True
Me.txtDevGrp.Size = New System.Drawing.Size(176, 20)
Me.txtDevGrp.TabIndex = 19
Me.txtDevGrp.Text = "" 
Me.cmdDevGrp.Location = New System.Drawing.Point(198,354)
Me.cmdDevGrp.name = "cmdDevGrp"
Me.cmdDevGrp.Size = New System.Drawing.Size(22, 20)
Me.cmdDevGrp.TabIndex = 20
Me.cmdDevGrp.Text = "..." 
Me.lblTHESCHEMA.Location = New System.Drawing.Point(20,379)
Me.lblTHESCHEMA.name = "lblTHESCHEMA"
Me.lblTHESCHEMA.Size = New System.Drawing.Size(200, 20)
Me.lblTHESCHEMA.TabIndex = 21
Me.lblTHESCHEMA.Text = "Схема подключения"
Me.lblTHESCHEMA.ForeColor = System.Drawing.Color.Blue
Me.txtTHESCHEMA.Location = New System.Drawing.Point(20,401)
Me.txtTHESCHEMA.name = "txtTHESCHEMA"
Me.txtTHESCHEMA.ReadOnly = True
Me.txtTHESCHEMA.Size = New System.Drawing.Size(155, 20)
Me.txtTHESCHEMA.TabIndex = 22
Me.txtTHESCHEMA.Text = "" 
Me.cmdTHESCHEMA.Location = New System.Drawing.Point(176,401)
Me.cmdTHESCHEMA.name = "cmdTHESCHEMA"
Me.cmdTHESCHEMA.Size = New System.Drawing.Size(22, 20)
Me.cmdTHESCHEMA.TabIndex = 23
Me.cmdTHESCHEMA.Text = "..." 
Me.cmdTHESCHEMAClear.Location = New System.Drawing.Point(198,401)
Me.cmdTHESCHEMAClear.name = "cmdTHESCHEMAClear"
Me.cmdTHESCHEMAClear.Size = New System.Drawing.Size(22, 20)
Me.cmdTHESCHEMAClear.TabIndex = 24
Me.cmdTHESCHEMAClear.Text = "X" 
Me.lblTheServer.Location = New System.Drawing.Point(230,5)
Me.lblTheServer.name = "lblTheServer"
Me.lblTheServer.Size = New System.Drawing.Size(200, 20)
Me.lblTheServer.TabIndex = 25
Me.lblTheServer.Text = "Сервер"
Me.lblTheServer.ForeColor = System.Drawing.Color.Blue
Me.txtTheServer.Location = New System.Drawing.Point(230,27)
Me.txtTheServer.name = "txtTheServer"
Me.txtTheServer.ReadOnly = True
Me.txtTheServer.Size = New System.Drawing.Size(155, 20)
Me.txtTheServer.TabIndex = 26
Me.txtTheServer.Text = "" 
Me.cmdTheServer.Location = New System.Drawing.Point(386,27)
Me.cmdTheServer.name = "cmdTheServer"
Me.cmdTheServer.Size = New System.Drawing.Size(22, 20)
Me.cmdTheServer.TabIndex = 27
Me.cmdTheServer.Text = "..." 
Me.cmdTheServerClear.Location = New System.Drawing.Point(408,27)
Me.cmdTheServerClear.name = "cmdTheServerClear"
Me.cmdTheServerClear.Size = New System.Drawing.Size(22, 20)
Me.cmdTheServerClear.TabIndex = 28
Me.cmdTheServerClear.Text = "X" 
Me.lblNPLOCK.Location = New System.Drawing.Point(230,52)
Me.lblNPLOCK.name = "lblNPLOCK"
Me.lblNPLOCK.Size = New System.Drawing.Size(200, 20)
Me.lblNPLOCK.TabIndex = 29
Me.lblNPLOCK.Text = "Заблокированно до"
Me.lblNPLOCK.ForeColor = System.Drawing.Color.Blue
Me.dtpNPLOCK.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpNPLOCK.Location = New System.Drawing.Point(230,74)
Me.dtpNPLOCK.name = "dtpNPLOCK"
Me.dtpNPLOCK.Size = New System.Drawing.Size(200,  20)
Me.dtpNPLOCK.TabIndex =30
Me.dtpNPLOCK.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpNPLOCK.ShowCheckBox=True
Me.lblCONNECTED.Location = New System.Drawing.Point(230,99)
Me.lblCONNECTED.name = "lblCONNECTED"
Me.lblCONNECTED.Size = New System.Drawing.Size(200, 20)
Me.lblCONNECTED.TabIndex = 31
Me.lblCONNECTED.Text = "Подключен"
Me.lblCONNECTED.ForeColor = System.Drawing.Color.Blue
Me.cmbCONNECTED.Location = New System.Drawing.Point(230,121)
Me.cmbCONNECTED.name = "cmbCONNECTED"
Me.cmbCONNECTED.Size = New System.Drawing.Size(200,  20)
Me.cmbCONNECTED.TabIndex = 32
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheNode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheNode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheNode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblThePhone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtThePhone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAddr)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtAddr)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDEVType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDEVType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdDEVType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdDEVTypeClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblShab)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtShab)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdShab)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdShabClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDevGrp)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDevGrp)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdDevGrp)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTHESCHEMA)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTHESCHEMA)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTHESCHEMA)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTHESCHEMAClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheServer)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheServer)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheServer)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheServerClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblNPLOCK)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpNPLOCK)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCONNECTED)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbCONNECTED)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLT_BDEVICES"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTheNode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheNode.TextChanged
  Changing

end sub
private sub cmdTheNode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheNode.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPN_DEF","",System.guid.Empty, id, brief) Then
          txtTheNode.Tag = id
          txtTheNode.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtThePhone_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThePhone.TextChanged
  Changing

end sub
private sub txtAddr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddr.TextChanged
  Changing

end sub
private sub txtDEVType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDEVType.TextChanged
  Changing

end sub
private sub cmdDEVType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDEVType.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLD_DEVTYPE","",System.guid.Empty, id, brief) Then
          txtDEVType.Tag = id
          txtDEVType.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdDEVTypeClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDEVTypeClear.Click
  try
          txtDEVType.Tag = Guid.Empty
          txtDEVType.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtShab_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShab.TextChanged
  Changing

end sub
private sub cmdShab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShab.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLD_SNAB","",System.guid.Empty, id, brief) Then
          txtShab.Tag = id
          txtShab.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdShabClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShabClear.Click
  try
          txtShab.Tag = Guid.Empty
          txtShab.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtDevGrp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDevGrp.TextChanged
  Changing

end sub
private sub cmdDevGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDevGrp.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLD_GRP","",System.guid.Empty, id, brief) Then
          txtDevGrp.Tag = id
          txtDevGrp.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTHESCHEMA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTHESCHEMA.TextChanged
  Changing

end sub
private sub cmdTHESCHEMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTHESCHEMA.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLS_INFO","",System.guid.Empty, id, brief) Then
          txtTHESCHEMA.Tag = id
          txtTHESCHEMA.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdTHESCHEMAClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTHESCHEMAClear.Click
  try
          txtTHESCHEMA.Tag = Guid.Empty
          txtTHESCHEMA.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
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
private sub dtpNPLOCK_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNPLOCK.ValueChanged
  Changing 

end sub
private sub cmbCONNECTED_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCONNECTED.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As TPLT.TPLT.TPLT_BDEVICES
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLT.TPLT.TPLT_BDEVICES)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.TheNode Is Nothing Then
  txtTheNode.Tag = item.TheNode.id
  txtTheNode.text = item.TheNode.brief
else
  txtTheNode.Tag = System.Guid.Empty 
  txtTheNode.text = "" 
End If
txtName.text = item.Name
txtThePhone.text = item.ThePhone
txtAddr.text = item.Addr
If Not item.DEVType Is Nothing Then
  txtDEVType.Tag = item.DEVType.id
  txtDEVType.text = item.DEVType.brief
else
  txtDEVType.Tag = System.Guid.Empty 
  txtDEVType.text = "" 
End If
If Not item.Shab Is Nothing Then
  txtShab.Tag = item.Shab.id
  txtShab.text = item.Shab.brief
else
  txtShab.Tag = System.Guid.Empty 
  txtShab.text = "" 
End If
If Not item.DevGrp Is Nothing Then
  txtDevGrp.Tag = item.DevGrp.id
  txtDevGrp.text = item.DevGrp.brief
else
  txtDevGrp.Tag = System.Guid.Empty 
  txtDevGrp.text = "" 
End If
If Not item.THESCHEMA Is Nothing Then
  txtTHESCHEMA.Tag = item.THESCHEMA.id
  txtTHESCHEMA.text = item.THESCHEMA.brief
else
  txtTHESCHEMA.Tag = System.Guid.Empty 
  txtTHESCHEMA.text = "" 
End If
If Not item.TheServer Is Nothing Then
  txtTheServer.Tag = item.TheServer.id
  txtTheServer.text = item.TheServer.brief
else
  txtTheServer.Tag = System.Guid.Empty 
  txtTheServer.text = "" 
End If
dtpNPLOCK.value = System.DateTime.Now
if item.NPLOCK <> System.DateTime.MinValue then
  try
     dtpNPLOCK.value = item.NPLOCK
  catch
   dtpNPLOCK.value = System.DateTime.MinValue
  end try
else
   dtpNPLOCK.value = System.DateTime.Today
   dtpNPLOCK.Checked =false
end if
cmbCONNECTEDData = New DataTable
cmbCONNECTEDData.Columns.Add("name", GetType(System.String))
cmbCONNECTEDData.Columns.Add("Value", GetType(System.Int32))
try
cmbCONNECTEDDataRow = cmbCONNECTEDData.NewRow
cmbCONNECTEDDataRow("name") = "Да"
cmbCONNECTEDDataRow("Value") = -1
cmbCONNECTEDData.Rows.Add (cmbCONNECTEDDataRow)
cmbCONNECTEDDataRow = cmbCONNECTEDData.NewRow
cmbCONNECTEDDataRow("name") = "Нет"
cmbCONNECTEDDataRow("Value") = 0
cmbCONNECTEDData.Rows.Add (cmbCONNECTEDDataRow)
cmbCONNECTED.DisplayMember = "name"
cmbCONNECTED.ValueMember = "Value"
cmbCONNECTED.DataSource = cmbCONNECTEDData
 cmbCONNECTED.SelectedValue=CInt(Item.CONNECTED)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
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

If not txtTheNode.Tag.Equals(System.Guid.Empty) Then
  item.TheNode = Item.Application.FindRowObject("TPN_DEF",txtTheNode.Tag)
Else
   item.TheNode = Nothing
End If
item.Name = txtName.text
item.ThePhone = txtThePhone.text
item.Addr = txtAddr.text
If not txtDEVType.Tag.Equals(System.Guid.Empty) Then
  item.DEVType = Item.Application.FindRowObject("TPLD_DEVTYPE",txtDEVType.Tag)
Else
   item.DEVType = Nothing
End If
If not txtShab.Tag.Equals(System.Guid.Empty) Then
  item.Shab = Item.Application.FindRowObject("TPLD_SNAB",txtShab.Tag)
Else
   item.Shab = Nothing
End If
If not txtDevGrp.Tag.Equals(System.Guid.Empty) Then
  item.DevGrp = Item.Application.FindRowObject("TPLD_GRP",txtDevGrp.Tag)
Else
   item.DevGrp = Nothing
End If
If not txtTHESCHEMA.Tag.Equals(System.Guid.Empty) Then
  item.THESCHEMA = Item.Application.FindRowObject("TPLS_INFO",txtTHESCHEMA.Tag)
Else
   item.THESCHEMA = Nothing
End If
If not txtTheServer.Tag.Equals(System.Guid.Empty) Then
  item.TheServer = Item.Application.FindRowObject("TPSRV_INFO",txtTheServer.Tag)
Else
   item.TheServer = Nothing
End If
  if dtpNPLOCK.checked=false then
       item.NPLOCK = System.DateTime.MinValue
  else 
  try
    item.NPLOCK = dtpNPLOCK.value
  catch
    item.NPLOCK = System.DateTime.MinValue
  end try
  end if
   item.CONNECTED = cmbCONNECTED.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtTheNode.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK = not txtDevGrp.Tag.Equals(System.Guid.Empty)
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
