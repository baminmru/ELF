
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Группа режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLD_GRP
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
Friend WithEvents lbltheClient  as  System.Windows.Forms.Label
Friend WithEvents txttheClient As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdtheClient As System.Windows.Forms.Button
Friend WithEvents lblCGRPNM  as  System.Windows.Forms.Label
Friend WithEvents txtCGRPNM As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCTXT  as  System.Windows.Forms.Label
Friend WithEvents txtCTXT As LATIR2GuiManager.TouchTextBox

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
Me.lbltheClient = New System.Windows.Forms.Label
Me.txttheClient = New LATIR2GuiManager.TouchTextBox
Me.cmdtheClient = New System.Windows.Forms.Button
Me.lblCGRPNM = New System.Windows.Forms.Label
Me.txtCGRPNM = New LATIR2GuiManager.TouchTextBox
Me.lblCTXT = New System.Windows.Forms.Label
Me.txtCTXT = New LATIR2GuiManager.TouchTextBox

Me.lbltheClient.Location = New System.Drawing.Point(20,5)
Me.lbltheClient.name = "lbltheClient"
Me.lbltheClient.Size = New System.Drawing.Size(200, 20)
Me.lbltheClient.TabIndex = 1
Me.lbltheClient.Text = "Клиент"
Me.lbltheClient.ForeColor = System.Drawing.Color.Black
Me.txttheClient.Location = New System.Drawing.Point(20,27)
Me.txttheClient.name = "txttheClient"
Me.txttheClient.ReadOnly = True
Me.txttheClient.Size = New System.Drawing.Size(176, 20)
Me.txttheClient.TabIndex = 2
Me.txttheClient.Text = "" 
Me.cmdtheClient.Location = New System.Drawing.Point(198,27)
Me.cmdtheClient.name = "cmdtheClient"
Me.cmdtheClient.Size = New System.Drawing.Size(22, 20)
Me.cmdtheClient.TabIndex = 3
Me.cmdtheClient.Text = "..." 
Me.lblCGRPNM.Location = New System.Drawing.Point(20,52)
Me.lblCGRPNM.name = "lblCGRPNM"
Me.lblCGRPNM.Size = New System.Drawing.Size(200, 20)
Me.lblCGRPNM.TabIndex = 4
Me.lblCGRPNM.Text = "Название группы"
Me.lblCGRPNM.ForeColor = System.Drawing.Color.Blue
Me.txtCGRPNM.Location = New System.Drawing.Point(20,74)
Me.txtCGRPNM.name = "txtCGRPNM"
Me.txtCGRPNM.Size = New System.Drawing.Size(200, 20)
Me.txtCGRPNM.TabIndex = 5
Me.txtCGRPNM.Text = "" 
Me.lblCTXT.Location = New System.Drawing.Point(20,99)
Me.lblCTXT.name = "lblCTXT"
Me.lblCTXT.Size = New System.Drawing.Size(200, 20)
Me.lblCTXT.TabIndex = 6
Me.lblCTXT.Text = "Описание"
Me.lblCTXT.ForeColor = System.Drawing.Color.Blue
Me.txtCTXT.Location = New System.Drawing.Point(20,121)
Me.txtCTXT.name = "txtCTXT"
Me.txtCTXT.Size = New System.Drawing.Size(200, 20)
Me.txtCTXT.TabIndex = 7
Me.txtCTXT.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltheClient)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttheClient)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdtheClient)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCGRPNM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCGRPNM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCTXT)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCTXT)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLD_GRP"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txttheClient_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttheClient.TextChanged
  Changing

end sub
private sub cmdtheClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtheClient.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("bpc_info","",System.guid.Empty, id, brief) Then
          txttheClient.Tag = id
          txttheClient.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtCGRPNM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCGRPNM.TextChanged
  Changing

end sub
private sub txtCTXT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCTXT.TextChanged
  Changing

end sub

Public Item As TPLD.TPLD.TPLD_GRP
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLD.TPLD.TPLD_GRP)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.theClient Is Nothing Then
  txttheClient.Tag = item.theClient.id
  txttheClient.text = item.theClient.brief
else
  txttheClient.Tag = System.Guid.Empty 
  txttheClient.text = "" 
End If
txtCGRPNM.text = item.CGRPNM
txtCTXT.text = item.CTXT
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

If not txttheClient.Tag.Equals(System.Guid.Empty) Then
  item.theClient = Item.Application.FindRowObject("bpc_info",txttheClient.Tag)
Else
   item.theClient = Nothing
End If
item.CGRPNM = txtCGRPNM.text
item.CTXT = txtCTXT.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txttheClient.Tag.Equals(System.Guid.Empty)
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
