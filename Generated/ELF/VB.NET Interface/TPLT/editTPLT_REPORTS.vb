
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Отчеты режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLT_REPORTS
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
Friend WithEvents lblrepType  as  System.Windows.Forms.Label
Friend WithEvents txtrepType As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdrepType As System.Windows.Forms.Button
Friend WithEvents lblName  as  System.Windows.Forms.Label
Friend WithEvents txtName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lbltheFile  as  System.Windows.Forms.Label
Friend WithEvents txttheFile As LATIR2GuiManager.TouchTextBox

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
Me.lblrepType = New System.Windows.Forms.Label
Me.txtrepType = New LATIR2GuiManager.TouchTextBox
Me.cmdrepType = New System.Windows.Forms.Button
Me.lblName = New System.Windows.Forms.Label
Me.txtName = New LATIR2GuiManager.TouchTextBox
Me.lbltheFile = New System.Windows.Forms.Label
Me.txttheFile = New LATIR2GuiManager.TouchTextBox

Me.lblrepType.Location = New System.Drawing.Point(20,5)
Me.lblrepType.name = "lblrepType"
Me.lblrepType.Size = New System.Drawing.Size(200, 20)
Me.lblrepType.TabIndex = 1
Me.lblrepType.Text = "Данные"
Me.lblrepType.ForeColor = System.Drawing.Color.Black
Me.txtrepType.Location = New System.Drawing.Point(20,27)
Me.txtrepType.name = "txtrepType"
Me.txtrepType.ReadOnly = True
Me.txtrepType.Size = New System.Drawing.Size(176, 20)
Me.txtrepType.TabIndex = 2
Me.txtrepType.Text = "" 
Me.cmdrepType.Location = New System.Drawing.Point(198,27)
Me.cmdrepType.name = "cmdrepType"
Me.cmdrepType.Size = New System.Drawing.Size(22, 20)
Me.cmdrepType.TabIndex = 3
Me.cmdrepType.Text = "..." 
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
Me.lbltheFile.Location = New System.Drawing.Point(20,99)
Me.lbltheFile.name = "lbltheFile"
Me.lbltheFile.Size = New System.Drawing.Size(200, 20)
Me.lbltheFile.TabIndex = 6
Me.lbltheFile.Text = "Файл"
Me.lbltheFile.ForeColor = System.Drawing.Color.Black
Me.txttheFile.Location = New System.Drawing.Point(20,121)
Me.txttheFile.name = "txttheFile"
Me.txttheFile.MultiLine = True
Me.txttheFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txttheFile.Size = New System.Drawing.Size(200, 50 + 20)
Me.txttheFile.TabIndex = 7
Me.txttheFile.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblrepType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtrepType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdrepType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lbltheFile)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txttheFile)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLT_REPORTS"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtrepType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrepType.TextChanged
  Changing

end sub
private sub cmdrepType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrepType.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLD_PARAMTYPE","",System.guid.Empty, id, brief) Then
          txtrepType.Tag = id
          txtrepType.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
  Changing

end sub
private sub txttheFile_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttheFile.TextChanged
  Changing

end sub

Public Item As TPLT.TPLT.TPLT_REPORTS
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLT.TPLT.TPLT_REPORTS)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.repType Is Nothing Then
  txtrepType.Tag = item.repType.id
  txtrepType.text = item.repType.brief
else
  txtrepType.Tag = System.Guid.Empty 
  txtrepType.text = "" 
End If
txtName.text = item.Name
txttheFile.text = item.theFile
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

If not txtrepType.Tag.Equals(System.Guid.Empty) Then
  item.repType = Item.Application.FindRowObject("TPLD_PARAMTYPE",txtrepType.Tag)
Else
   item.repType = Nothing
End If
item.Name = txtName.text
item.theFile = txttheFile.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtrepType.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtName.text <> "" ) 
if mIsOK then mIsOK =( txttheFile.text <> "" ) 
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
