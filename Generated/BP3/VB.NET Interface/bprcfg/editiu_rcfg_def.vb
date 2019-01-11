
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Роль режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editiu_rcfg_def
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
Friend WithEvents lbltherole  as  System.Windows.Forms.Label
Friend WithEvents txttherole As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdtherole As System.Windows.Forms.Button

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
Me.lbltherole = New System.Windows.Forms.Label
Me.txttherole = New LATIR2GuiManager.TouchTextBox
Me.cmdtherole = New System.Windows.Forms.Button

Me.lbltherole.Location = New System.Drawing.Point(20,5)
Me.lbltherole.name = "lbltherole"
Me.lbltherole.Size = New System.Drawing.Size(200, 20)
Me.lbltherole.TabIndex = 1
Me.lbltherole.Text = "Роль"
Me.lbltherole.ForeColor = System.Drawing.Color.Black
Me.txttherole.Location = New System.Drawing.Point(20,27)
Me.txttherole.name = "txttherole"
Me.txttherole.ReadOnly = True
Me.txttherole.Size = New System.Drawing.Size(176, 20)
Me.txttherole.TabIndex = 2
Me.txttherole.Text = "" 
Me.cmdtherole.Location = New System.Drawing.Point(198,27)
Me.cmdtherole.name = "cmdtherole"
Me.cmdtherole.Size = New System.Drawing.Size(22, 20)
Me.cmdtherole.TabIndex = 3
Me.cmdtherole.Text = "..." 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltherole)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttherole)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdtherole)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editiu_rcfg_def"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txttherole_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttherole.TextChanged
  Changing

end sub
private sub cmdtherole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdtherole.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        MsgBox ("Режим не предусматривает редактирования",vbInformation)
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As bprcfg.bprcfg.iu_rcfg_def
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,bprcfg.bprcfg.iu_rcfg_def)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.therole Is Nothing Then
  txttherole.Tag = item.therole.id
  txttherole.text = item.therole.brief
else
  txttherole.Tag = System.Guid.Empty 
  txttherole.text = "" 
End If
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

  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txttherole.Tag.Equals(System.Guid.Empty)
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
