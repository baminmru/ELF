
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Заголовок режим:admin
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLC_HEADERadmin
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
Friend WithEvents lblID_BD  as  System.Windows.Forms.Label
Friend WithEvents txtID_BD As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdID_BD As System.Windows.Forms.Button
Friend WithEvents cmdID_BDClear As System.Windows.Forms.Button

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
Me.lblID_BD = New System.Windows.Forms.Label
Me.txtID_BD = New LATIR2GuiManager.TouchTextBox
Me.cmdID_BD = New System.Windows.Forms.Button
Me.cmdID_BDClear = New System.Windows.Forms.Button

Me.lblID_BD.Location = New System.Drawing.Point(20,5)
Me.lblID_BD.name = "lblID_BD"
Me.lblID_BD.Size = New System.Drawing.Size(200, 20)
Me.lblID_BD.TabIndex = 1
Me.lblID_BD.Text = "Устройство"
Me.lblID_BD.ForeColor = System.Drawing.Color.Blue
Me.txtID_BD.Location = New System.Drawing.Point(20,27)
Me.txtID_BD.name = "txtID_BD"
Me.txtID_BD.ReadOnly = True
Me.txtID_BD.Size = New System.Drawing.Size(155, 20)
Me.txtID_BD.TabIndex = 2
Me.txtID_BD.Text = "" 
Me.cmdID_BD.Location = New System.Drawing.Point(176,27)
Me.cmdID_BD.name = "cmdID_BD"
Me.cmdID_BD.Size = New System.Drawing.Size(22, 20)
Me.cmdID_BD.TabIndex = 3
Me.cmdID_BD.Text = "..." 
Me.cmdID_BDClear.Location = New System.Drawing.Point(198,27)
Me.cmdID_BDClear.name = "cmdID_BDClear"
Me.cmdID_BDClear.Size = New System.Drawing.Size(22, 20)
Me.cmdID_BDClear.TabIndex = 4
Me.cmdID_BDClear.Text = "X" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblID_BD)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtID_BD)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdID_BD)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdID_BDClear)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLC_HEADER"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtID_BD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtID_BD.TextChanged
  Changing

end sub
private sub cmdID_BD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdID_BD.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLT_BDEVICES","",System.guid.Empty, id, brief) Then
          txtID_BD.Tag = id
          txtID_BD.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdID_BDClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdID_BDClear.Click
  try
          txtID_BD.Tag = Guid.Empty
          txtID_BD.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As TPLC.TPLC.TPLC_HEADER
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLC.TPLC.TPLC_HEADER)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.ID_BD Is Nothing Then
  txtID_BD.Tag = item.ID_BD.id
  txtID_BD.text = item.ID_BD.brief
else
  txtID_BD.Tag = System.Guid.Empty 
  txtID_BD.text = "" 
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

If not txtID_BD.Tag.Equals(System.Guid.Empty) Then
  item.ID_BD = Item.Application.FindRowObject("TPLT_BDEVICES",txtID_BD.Tag)
Else
   item.ID_BD = Nothing
End If
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
