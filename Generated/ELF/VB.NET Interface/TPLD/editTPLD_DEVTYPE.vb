
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Тип устройства режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLD_DEVTYPE
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
Friend WithEvents lblDevClass  as  System.Windows.Forms.Label
Friend WithEvents txtDevClass As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdDevClass As System.Windows.Forms.Button
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblDriverLibName  as  System.Windows.Forms.Label
Friend WithEvents txtDriverLibName As LATIR2GuiManager.TouchTextBox

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
Me.lblDevClass = New System.Windows.Forms.Label
Me.txtDevClass = New LATIR2GuiManager.TouchTextBox
Me.cmdDevClass = New System.Windows.Forms.Button
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New LATIR2GuiManager.TouchTextBox
Me.lblDriverLibName = New System.Windows.Forms.Label
Me.txtDriverLibName = New LATIR2GuiManager.TouchTextBox

Me.lblDevClass.Location = New System.Drawing.Point(20,5)
Me.lblDevClass.name = "lblDevClass"
Me.lblDevClass.Size = New System.Drawing.Size(200, 20)
Me.lblDevClass.TabIndex = 1
Me.lblDevClass.Text = "Класс устройства"
Me.lblDevClass.ForeColor = System.Drawing.Color.Black
Me.txtDevClass.Location = New System.Drawing.Point(20,27)
Me.txtDevClass.name = "txtDevClass"
Me.txtDevClass.ReadOnly = True
Me.txtDevClass.Size = New System.Drawing.Size(176, 20)
Me.txtDevClass.TabIndex = 2
Me.txtDevClass.Text = "" 
Me.cmdDevClass.Location = New System.Drawing.Point(198,27)
Me.cmdDevClass.name = "cmdDevClass"
Me.cmdDevClass.Size = New System.Drawing.Size(22, 20)
Me.cmdDevClass.TabIndex = 3
Me.cmdDevClass.Text = "..." 
Me.lblName.Location = New System.Drawing.Point(20,52)
Me.lblName.name = "lblName"
Me.lblName.Size = New System.Drawing.Size(200, 20)
Me.lblName.TabIndex = 4
Me.lblName.Text = "Название "
Me.lblName.ForeColor = System.Drawing.Color.Black
Me.txtName.Location = New System.Drawing.Point(20,74)
Me.txtName.name = "txtName"
Me.txtName.Size = New System.Drawing.Size(200, 20)
Me.txtName.TabIndex = 5
Me.txtName.Text = "" 
Me.lblDriverLibName.Location = New System.Drawing.Point(20,99)
Me.lblDriverLibName.name = "lblDriverLibName"
Me.lblDriverLibName.Size = New System.Drawing.Size(200, 20)
Me.lblDriverLibName.TabIndex = 6
Me.lblDriverLibName.Text = "Библиотека драйвера"
Me.lblDriverLibName.ForeColor = System.Drawing.Color.Blue
Me.txtDriverLibName.Location = New System.Drawing.Point(20,121)
Me.txtDriverLibName.name = "txtDriverLibName"
Me.txtDriverLibName.Size = New System.Drawing.Size(200, 20)
Me.txtDriverLibName.TabIndex = 7
Me.txtDriverLibName.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDevClass)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDevClass)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdDevClass)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDriverLibName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDriverLibName)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLD_DEVTYPE"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtDevClass_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDevClass.TextChanged
  Changing

end sub
private sub cmdDevClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDevClass.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLD_DEVCLASS","",System.guid.Empty, id, brief) Then
          txtDevClass.Tag = id
          txtDevClass.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txtDriverLibName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDriverLibName.TextChanged
  Changing

end sub

Public Item As TPLD.TPLD.TPLD_DEVTYPE
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLD.TPLD.TPLD_DEVTYPE)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.DevClass Is Nothing Then
  txtDevClass.Tag = item.DevClass.id
  txtDevClass.text = item.DevClass.brief
else
  txtDevClass.Tag = System.Guid.Empty 
  txtDevClass.text = "" 
End If
txtName.text = item.Name
txtDriverLibName.text = item.DriverLibName
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

If not txtDevClass.Tag.Equals(System.Guid.Empty) Then
  item.DevClass = Item.Application.FindRowObject("TPLD_DEVCLASS",txtDevClass.Tag)
Else
   item.DevClass = Nothing
End If
item.Name = txtName.text
item.DriverLibName = txtDriverLibName.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtDevClass.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtName.text <> "" ) 
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
