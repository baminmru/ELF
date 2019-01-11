
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Модуль режим:read
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editiu_rcfg_modread
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
Friend WithEvents lblCaption  as  System.Windows.Forms.Label
Friend WithEvents txtCaption As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblModuleAccessible  as  System.Windows.Forms.Label
Friend WithEvents cmbModuleAccessible As System.Windows.Forms.ComboBox
Friend cmbModuleAccessibleDATA As DataTable
Friend cmbModuleAccessibleDATAROW As DataRow
Friend WithEvents lblTheIcon  as  System.Windows.Forms.Label
Friend WithEvents txtTheIcon As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblname  as  System.Windows.Forms.Label
Friend WithEvents txtname As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblGroupName  as  System.Windows.Forms.Label
Friend WithEvents txtGroupName As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblAllObjects  as  System.Windows.Forms.Label
Friend WithEvents cmbAllObjects As System.Windows.Forms.ComboBox
Friend cmbAllObjectsDATA As DataTable
Friend cmbAllObjectsDATAROW As DataRow
Friend WithEvents lblColegsObject  as  System.Windows.Forms.Label
Friend WithEvents cmbColegsObject As System.Windows.Forms.ComboBox
Friend cmbColegsObjectDATA As DataTable
Friend cmbColegsObjectDATAROW As DataRow
Friend WithEvents lblSubStructObjects  as  System.Windows.Forms.Label
Friend WithEvents cmbSubStructObjects As System.Windows.Forms.ComboBox
Friend cmbSubStructObjectsDATA As DataTable
Friend cmbSubStructObjectsDATAROW As DataRow
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
Me.lblCaption = New System.Windows.Forms.Label
Me.txtCaption = New LATIR2GuiManager.TouchTextBox
Me.lblModuleAccessible = New System.Windows.Forms.Label
Me.cmbModuleAccessible = New System.Windows.Forms.ComboBox
Me.lblTheIcon = New System.Windows.Forms.Label
Me.txtTheIcon = New LATIR2GuiManager.TouchTextBox
Me.lblname = New System.Windows.Forms.Label
Me.txtname = New LATIR2GuiManager.TouchTextBox
Me.lblGroupName = New System.Windows.Forms.Label
Me.txtGroupName = New LATIR2GuiManager.TouchTextBox
Me.lblAllObjects = New System.Windows.Forms.Label
Me.cmbAllObjects = New System.Windows.Forms.ComboBox
Me.lblColegsObject = New System.Windows.Forms.Label
Me.cmbColegsObject = New System.Windows.Forms.ComboBox
Me.lblSubStructObjects = New System.Windows.Forms.Label
Me.cmbSubStructObjects = New System.Windows.Forms.ComboBox
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
Me.txtSequence.ReadOnly = True
Me.lblCaption.Location = New System.Drawing.Point(20,52)
Me.lblCaption.name = "lblCaption"
Me.lblCaption.Size = New System.Drawing.Size(200, 20)
Me.lblCaption.TabIndex = 3
Me.lblCaption.Text = "Надпись"
Me.lblCaption.ForeColor = System.Drawing.Color.Black
Me.txtCaption.Location = New System.Drawing.Point(20,74)
Me.txtCaption.name = "txtCaption"
Me.txtCaption.Size = New System.Drawing.Size(200, 20)
Me.txtCaption.TabIndex = 4
Me.txtCaption.Text = "" 
Me.txtCaption.ReadOnly = True
Me.lblModuleAccessible.Location = New System.Drawing.Point(20,99)
Me.lblModuleAccessible.name = "lblModuleAccessible"
Me.lblModuleAccessible.Size = New System.Drawing.Size(200, 20)
Me.lblModuleAccessible.TabIndex = 5
Me.lblModuleAccessible.Text = "Разрешен"
Me.lblModuleAccessible.ForeColor = System.Drawing.Color.Black
Me.cmbModuleAccessible.Location = New System.Drawing.Point(20,121)
Me.cmbModuleAccessible.name = "cmbModuleAccessible"
Me.cmbModuleAccessible.Size = New System.Drawing.Size(200,  20)
Me.cmbModuleAccessible.TabIndex = 6
Me.cmbModuleAccessible.Enabled = true
Me.lblTheIcon.Location = New System.Drawing.Point(20,146)
Me.lblTheIcon.name = "lblTheIcon"
Me.lblTheIcon.Size = New System.Drawing.Size(200, 20)
Me.lblTheIcon.TabIndex = 7
Me.lblTheIcon.Text = "Иконка"
Me.lblTheIcon.ForeColor = System.Drawing.Color.Blue
Me.txtTheIcon.Location = New System.Drawing.Point(20,168)
Me.txtTheIcon.name = "txtTheIcon"
Me.txtTheIcon.Size = New System.Drawing.Size(200, 20)
Me.txtTheIcon.TabIndex = 8
Me.txtTheIcon.Text = "" 
Me.txtTheIcon.ReadOnly = True
Me.lblname.Location = New System.Drawing.Point(20,193)
Me.lblname.name = "lblname"
Me.lblname.Size = New System.Drawing.Size(200, 20)
Me.lblname.TabIndex = 9
Me.lblname.Text = "Название меню"
Me.lblname.ForeColor = System.Drawing.Color.Black
Me.txtname.Location = New System.Drawing.Point(20,215)
Me.txtname.name = "txtname"
Me.txtname.Size = New System.Drawing.Size(200, 20)
Me.txtname.TabIndex = 10
Me.txtname.Text = "" 
Me.txtname.ReadOnly = True
Me.lblGroupName.Location = New System.Drawing.Point(20,240)
Me.lblGroupName.name = "lblGroupName"
Me.lblGroupName.Size = New System.Drawing.Size(200, 20)
Me.lblGroupName.TabIndex = 11
Me.lblGroupName.Text = "Меню верхнего урровня"
Me.lblGroupName.ForeColor = System.Drawing.Color.Blue
Me.txtGroupName.Location = New System.Drawing.Point(20,262)
Me.txtGroupName.name = "txtGroupName"
Me.txtGroupName.Size = New System.Drawing.Size(200, 20)
Me.txtGroupName.TabIndex = 12
Me.txtGroupName.Text = "" 
Me.txtGroupName.ReadOnly = True
Me.lblAllObjects.Location = New System.Drawing.Point(20,287)
Me.lblAllObjects.name = "lblAllObjects"
Me.lblAllObjects.Size = New System.Drawing.Size(200, 20)
Me.lblAllObjects.TabIndex = 13
Me.lblAllObjects.Text = "Вся фирма"
Me.lblAllObjects.ForeColor = System.Drawing.Color.Black
Me.cmbAllObjects.Location = New System.Drawing.Point(20,309)
Me.cmbAllObjects.name = "cmbAllObjects"
Me.cmbAllObjects.Size = New System.Drawing.Size(200,  20)
Me.cmbAllObjects.TabIndex = 14
Me.cmbAllObjects.Enabled = true
Me.lblColegsObject.Location = New System.Drawing.Point(20,334)
Me.lblColegsObject.name = "lblColegsObject"
Me.lblColegsObject.Size = New System.Drawing.Size(200, 20)
Me.lblColegsObject.TabIndex = 15
Me.lblColegsObject.Text = "Объекты коллег"
Me.lblColegsObject.ForeColor = System.Drawing.Color.Black
Me.cmbColegsObject.Location = New System.Drawing.Point(20,356)
Me.cmbColegsObject.name = "cmbColegsObject"
Me.cmbColegsObject.Size = New System.Drawing.Size(200,  20)
Me.cmbColegsObject.TabIndex = 16
Me.cmbColegsObject.Enabled = true
Me.lblSubStructObjects.Location = New System.Drawing.Point(20,381)
Me.lblSubStructObjects.name = "lblSubStructObjects"
Me.lblSubStructObjects.Size = New System.Drawing.Size(200, 20)
Me.lblSubStructObjects.TabIndex = 17
Me.lblSubStructObjects.Text = "Подчиненные подразделения"
Me.lblSubStructObjects.ForeColor = System.Drawing.Color.Black
Me.cmbSubStructObjects.Location = New System.Drawing.Point(20,403)
Me.cmbSubStructObjects.name = "cmbSubStructObjects"
Me.cmbSubStructObjects.Size = New System.Drawing.Size(200,  20)
Me.cmbSubStructObjects.TabIndex = 18
Me.cmbSubStructObjects.Enabled = true
Me.lblvisibleControl.Location = New System.Drawing.Point(230,5)
Me.lblvisibleControl.name = "lblvisibleControl"
Me.lblvisibleControl.Size = New System.Drawing.Size(200, 20)
Me.lblvisibleControl.TabIndex = 19
Me.lblvisibleControl.Text = "Управление видимостью"
Me.lblvisibleControl.ForeColor = System.Drawing.Color.Black
Me.cmbvisibleControl.Location = New System.Drawing.Point(230,27)
Me.cmbvisibleControl.name = "cmbvisibleControl"
Me.cmbvisibleControl.Size = New System.Drawing.Size(200,  20)
Me.cmbvisibleControl.TabIndex = 20
Me.cmbvisibleControl.Enabled = true
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCaption)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblModuleAccessible)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbModuleAccessible)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheIcon)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheIcon)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtname)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblGroupName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtGroupName)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllObjects)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllObjects)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblColegsObject)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbColegsObject)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSubStructObjects)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbSubStructObjects)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblvisibleControl)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbvisibleControl)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editiu_rcfg_mod"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtSequence_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSequence.TextChanged
  Changing

end sub
private sub txtCaption_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaption.TextChanged
  Changing

end sub
private sub cmbModuleAccessible_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModuleAccessible.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTheIcon_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheIcon.TextChanged
  Changing

end sub
private sub txtname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
  Changing

end sub
private sub txtGroupName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupName.TextChanged
  Changing

end sub
private sub cmbAllObjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllObjects.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbColegsObject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbColegsObject.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbSubStructObjects_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubStructObjects.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbvisibleControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbvisibleControl.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As bprcfg.bprcfg.iu_rcfg_mod
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,bprcfg.bprcfg.iu_rcfg_mod)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtSequence.text = item.Sequence.toString()
txtCaption.text = item.Caption
cmbModuleAccessibleData = New DataTable
cmbModuleAccessibleData.Columns.Add("name", GetType(System.String))
cmbModuleAccessibleData.Columns.Add("Value", GetType(System.Int32))
try
cmbModuleAccessibleDataRow = cmbModuleAccessibleData.NewRow
cmbModuleAccessibleDataRow("name") = "Да"
cmbModuleAccessibleDataRow("Value") = -1
cmbModuleAccessibleData.Rows.Add (cmbModuleAccessibleDataRow)
cmbModuleAccessibleDataRow = cmbModuleAccessibleData.NewRow
cmbModuleAccessibleDataRow("name") = "Нет"
cmbModuleAccessibleDataRow("Value") = 0
cmbModuleAccessibleData.Rows.Add (cmbModuleAccessibleDataRow)
cmbModuleAccessible.DisplayMember = "name"
cmbModuleAccessible.ValueMember = "Value"
cmbModuleAccessible.DataSource = cmbModuleAccessibleData
 cmbModuleAccessible.SelectedValue=CInt(Item.ModuleAccessible)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtTheIcon.text = item.TheIcon
txtname.text = item.name
txtGroupName.text = item.GroupName
cmbAllObjectsData = New DataTable
cmbAllObjectsData.Columns.Add("name", GetType(System.String))
cmbAllObjectsData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllObjectsDataRow = cmbAllObjectsData.NewRow
cmbAllObjectsDataRow("name") = "Да"
cmbAllObjectsDataRow("Value") = -1
cmbAllObjectsData.Rows.Add (cmbAllObjectsDataRow)
cmbAllObjectsDataRow = cmbAllObjectsData.NewRow
cmbAllObjectsDataRow("name") = "Нет"
cmbAllObjectsDataRow("Value") = 0
cmbAllObjectsData.Rows.Add (cmbAllObjectsDataRow)
cmbAllObjects.DisplayMember = "name"
cmbAllObjects.ValueMember = "Value"
cmbAllObjects.DataSource = cmbAllObjectsData
 cmbAllObjects.SelectedValue=CInt(Item.AllObjects)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbColegsObjectData = New DataTable
cmbColegsObjectData.Columns.Add("name", GetType(System.String))
cmbColegsObjectData.Columns.Add("Value", GetType(System.Int32))
try
cmbColegsObjectDataRow = cmbColegsObjectData.NewRow
cmbColegsObjectDataRow("name") = "Да"
cmbColegsObjectDataRow("Value") = -1
cmbColegsObjectData.Rows.Add (cmbColegsObjectDataRow)
cmbColegsObjectDataRow = cmbColegsObjectData.NewRow
cmbColegsObjectDataRow("name") = "Нет"
cmbColegsObjectDataRow("Value") = 0
cmbColegsObjectData.Rows.Add (cmbColegsObjectDataRow)
cmbColegsObject.DisplayMember = "name"
cmbColegsObject.ValueMember = "Value"
cmbColegsObject.DataSource = cmbColegsObjectData
 cmbColegsObject.SelectedValue=CInt(Item.ColegsObject)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbSubStructObjectsData = New DataTable
cmbSubStructObjectsData.Columns.Add("name", GetType(System.String))
cmbSubStructObjectsData.Columns.Add("Value", GetType(System.Int32))
try
cmbSubStructObjectsDataRow = cmbSubStructObjectsData.NewRow
cmbSubStructObjectsDataRow("name") = "Да"
cmbSubStructObjectsDataRow("Value") = -1
cmbSubStructObjectsData.Rows.Add (cmbSubStructObjectsDataRow)
cmbSubStructObjectsDataRow = cmbSubStructObjectsData.NewRow
cmbSubStructObjectsDataRow("name") = "Нет"
cmbSubStructObjectsDataRow("Value") = 0
cmbSubStructObjectsData.Rows.Add (cmbSubStructObjectsDataRow)
cmbSubStructObjects.DisplayMember = "name"
cmbSubStructObjects.ValueMember = "Value"
cmbSubStructObjects.DataSource = cmbSubStructObjectsData
 cmbSubStructObjects.SelectedValue=CInt(Item.SubStructObjects)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
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

  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtSequence.text <> "" ) 
if mIsOK then mIsOK =( txtCaption.text <> "" ) 
if mIsOK then mIsOK =(cmbModuleAccessible.SelectedIndex >=0)
if mIsOK then mIsOK =( txtname.text <> "" ) 
if mIsOK then mIsOK =(cmbAllObjects.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbColegsObject.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbSubStructObjects.SelectedIndex >=0)
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
