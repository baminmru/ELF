
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Модуль режим:edit
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editiu_int_modulesedit
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
Friend WithEvents lblSequence  as  System.Windows.Forms.Label
Friend WithEvents txtSequence As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblTheIcon  as  System.Windows.Forms.Label
Friend WithEvents txtTheIcon As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblGroupName  as  System.Windows.Forms.Label
Friend WithEvents txtGroupName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblname  as  System.Windows.Forms.Label
Friend WithEvents txtname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCaption  as  System.Windows.Forms.Label
Friend WithEvents txtCaption As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblvisibleControl  as  System.Windows.Forms.Label
Friend WithEvents cmbvisibleControl As System.Windows.Forms.ComboBox
Friend cmbvisibleControlDATA As DataTable
Friend cmbvisibleControlDATAROW As DataRow

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
Me.lblSequence = New System.Windows.Forms.Label
Me.txtSequence = New LATIR2GuiManager.TouchTextBox
Me.lblTheIcon = New System.Windows.Forms.Label
Me.txtTheIcon = New LATIR2GuiManager.TouchTextBox
Me.lblGroupName = New System.Windows.Forms.Label
Me.txtGroupName = New LATIR2GuiManager.TouchTextBox
Me.lblname = New System.Windows.Forms.Label
Me.txtname = New LATIR2GuiManager.TouchTextBox
Me.lblCaption = New System.Windows.Forms.Label
Me.txtCaption = New LATIR2GuiManager.TouchTextBox
Me.lblvisibleControl = New System.Windows.Forms.Label
Me.cmbvisibleControl = New System.Windows.Forms.ComboBox

Me.lblSequence.Location = New System.Drawing.Point(20,5)
Me.lblSequence.name = "lblSequence"
Me.lblSequence.Size = New System.Drawing.Size(200, 20)
Me.lblSequence.TabIndex = 1
Me.lblSequence.Text = "№ п/п"
Me.lblSequence.ForeColor = System.Drawing.Color.Black
Me.txtSequence.Location = New System.Drawing.Point(20,27)
Me.txtSequence.name = "txtSequence"
Me.txtSequence.MultiLine = false
Me.txtSequence.Size = New System.Drawing.Size(200,  20)
Me.txtSequence.TabIndex = 2
Me.txtSequence.Text = "" 
Me.txtSequence.MaxLength = 15
Me.lblTheIcon.Location = New System.Drawing.Point(20,52)
Me.lblTheIcon.name = "lblTheIcon"
Me.lblTheIcon.Size = New System.Drawing.Size(200, 20)
Me.lblTheIcon.TabIndex = 3
Me.lblTheIcon.Text = "Иконка"
Me.lblTheIcon.ForeColor = System.Drawing.Color.Blue
Me.txtTheIcon.Location = New System.Drawing.Point(20,74)
Me.txtTheIcon.name = "txtTheIcon"
Me.txtTheIcon.Size = New System.Drawing.Size(200, 20)
Me.txtTheIcon.TabIndex = 4
Me.txtTheIcon.Text = "" 
Me.lblGroupName.Location = New System.Drawing.Point(20,99)
Me.lblGroupName.name = "lblGroupName"
Me.lblGroupName.Size = New System.Drawing.Size(200, 20)
Me.lblGroupName.TabIndex = 5
Me.lblGroupName.Text = "Меню верхнего урровня"
Me.lblGroupName.ForeColor = System.Drawing.Color.Blue
Me.txtGroupName.Location = New System.Drawing.Point(20,121)
Me.txtGroupName.name = "txtGroupName"
Me.txtGroupName.Size = New System.Drawing.Size(200, 20)
Me.txtGroupName.TabIndex = 6
Me.txtGroupName.Text = "" 
Me.lblname.Location = New System.Drawing.Point(20,146)
Me.lblname.name = "lblname"
Me.lblname.Size = New System.Drawing.Size(200, 20)
Me.lblname.TabIndex = 7
Me.lblname.Text = "Название меню"
Me.lblname.ForeColor = System.Drawing.Color.Black
Me.txtname.Location = New System.Drawing.Point(20,168)
Me.txtname.name = "txtname"
Me.txtname.Size = New System.Drawing.Size(200, 20)
Me.txtname.TabIndex = 8
Me.txtname.Text = "" 
Me.lblCaption.Location = New System.Drawing.Point(20,193)
Me.lblCaption.name = "lblCaption"
Me.lblCaption.Size = New System.Drawing.Size(200, 20)
Me.lblCaption.TabIndex = 9
Me.lblCaption.Text = "Надпись"
Me.lblCaption.ForeColor = System.Drawing.Color.Black
Me.txtCaption.Location = New System.Drawing.Point(20,215)
Me.txtCaption.name = "txtCaption"
Me.txtCaption.Size = New System.Drawing.Size(200, 20)
Me.txtCaption.TabIndex = 10
Me.txtCaption.Text = "" 
Me.lblvisibleControl.Location = New System.Drawing.Point(20,240)
Me.lblvisibleControl.name = "lblvisibleControl"
Me.lblvisibleControl.Size = New System.Drawing.Size(200, 20)
Me.lblvisibleControl.TabIndex = 11
Me.lblvisibleControl.Text = "Управление видимостью"
Me.lblvisibleControl.ForeColor = System.Drawing.Color.Black
Me.cmbvisibleControl.Location = New System.Drawing.Point(20,262)
Me.cmbvisibleControl.name = "cmbvisibleControl"
Me.cmbvisibleControl.Size = New System.Drawing.Size(200,  20)
Me.cmbvisibleControl.TabIndex = 12
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheIcon)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheIcon)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblGroupName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtGroupName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblvisibleControl)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbvisibleControl)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editiu_int_modules"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

        Private Sub txtSequence_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSequence.Validating
        If txtSequence.Text <> "" Then
            try
            If Not IsNumeric(txtSequence.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtSequence.Text) < -2000000000 Or Val(txtSequence.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtSequence_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSequence.TextChanged
  Changing

end sub
private sub txtTheIcon_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheIcon.TextChanged
  Changing

end sub
private sub txtGroupName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupName.TextChanged
  Changing

end sub
private sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
  Changing

end sub
private sub txtCaption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaption.TextChanged
  Changing

end sub
private sub cmbvisibleControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbvisibleControl.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As bpdi.bpdi.iu_int_modules
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,bpdi.bpdi.iu_int_modules)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtSequence.text = item.Sequence.toString()
txtTheIcon.text = item.TheIcon
txtGroupName.text = item.GroupName
txtname.text = item.name
txtCaption.text = item.Caption
cmbvisibleControlData = New DataTable
cmbvisibleControlData.Columns.Add("name", GetType(System.String))
cmbvisibleControlData.Columns.Add("Value", GetType(System.Int32))
try
cmbvisibleControlDataRow = cmbvisibleControlData.NewRow
cmbvisibleControlDataRow("name") = "Да"
cmbvisibleControlDataRow("Value") = -1
cmbvisibleControlData.Rows.Add (cmbvisibleControlDataRow)
cmbvisibleControlDataRow = cmbvisibleControlData.NewRow
cmbvisibleControlDataRow("name") = "Нет"
cmbvisibleControlDataRow("Value") = 0
cmbvisibleControlData.Rows.Add (cmbvisibleControlDataRow)
cmbvisibleControl.DisplayMember = "name"
cmbvisibleControl.ValueMember = "Value"
cmbvisibleControl.DataSource = cmbvisibleControlData
 cmbvisibleControl.SelectedValue=CInt(Item.visibleControl)
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

item.Sequence = val(txtSequence.text)
item.TheIcon = txtTheIcon.text
item.GroupName = txtGroupName.text
item.name = txtname.text
item.Caption = txtCaption.text
   item.visibleControl = cmbvisibleControl.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtSequence.text <> "" ) 
if mIsOK then mIsOK =( txtname.text <> "" ) 
if mIsOK then mIsOK =( txtCaption.text <> "" ) 
if mIsOK then mIsOK =(cmbvisibleControl.SelectedIndex >=0)
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
