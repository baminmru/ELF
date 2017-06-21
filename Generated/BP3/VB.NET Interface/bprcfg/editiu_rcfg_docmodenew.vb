
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Режим документа режим:new
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editiu_rcfg_docmodenew
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
Friend WithEvents lblThe_Document  as  System.Windows.Forms.Label
Friend WithEvents txtThe_Document As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdThe_Document As System.Windows.Forms.Button
Friend WithEvents lblAddMode  as  System.Windows.Forms.Label
Friend WithEvents txtAddMode As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblEditMode  as  System.Windows.Forms.Label
Friend WithEvents txtEditMode As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblAllowAdd  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowAdd As System.Windows.Forms.ComboBox
Friend cmbAllowAddDATA As DataTable
Friend cmbAllowAddDATAROW As DataRow
Friend WithEvents lblAllowDelete  as  System.Windows.Forms.Label
Friend WithEvents cmbAllowDelete As System.Windows.Forms.ComboBox
Friend cmbAllowDeleteDATA As DataTable
Friend cmbAllowDeleteDATAROW As DataRow

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
Me.lblThe_Document = New System.Windows.Forms.Label
Me.txtThe_Document = New LATIR2GuiManager.TouchTextBox
Me.cmdThe_Document = New System.Windows.Forms.Button
Me.lblAddMode = New System.Windows.Forms.Label
Me.txtAddMode = New LATIR2GuiManager.TouchTextBox
Me.lblEditMode = New System.Windows.Forms.Label
Me.txtEditMode = New LATIR2GuiManager.TouchTextBox
Me.lblAllowAdd = New System.Windows.Forms.Label
Me.cmbAllowAdd = New System.Windows.Forms.ComboBox
Me.lblAllowDelete = New System.Windows.Forms.Label
Me.cmbAllowDelete = New System.Windows.Forms.ComboBox

Me.lblThe_Document.Location = New System.Drawing.Point(20,5)
Me.lblThe_Document.name = "lblThe_Document"
Me.lblThe_Document.Size = New System.Drawing.Size(200, 20)
Me.lblThe_Document.TabIndex = 1
Me.lblThe_Document.Text = "Тип документа"
Me.lblThe_Document.ForeColor = System.Drawing.Color.Black
Me.txtThe_Document.Location = New System.Drawing.Point(20,27)
Me.txtThe_Document.name = "txtThe_Document"
Me.txtThe_Document.ReadOnly = True
Me.txtThe_Document.Size = New System.Drawing.Size(176, 20)
Me.txtThe_Document.TabIndex = 2
Me.txtThe_Document.Text = "" 
Me.cmdThe_Document.Location = New System.Drawing.Point(198,27)
Me.cmdThe_Document.name = "cmdThe_Document"
Me.cmdThe_Document.Size = New System.Drawing.Size(22, 20)
Me.cmdThe_Document.TabIndex = 3
Me.cmdThe_Document.Text = "..." 
Me.lblAddMode.Location = New System.Drawing.Point(20,52)
Me.lblAddMode.name = "lblAddMode"
Me.lblAddMode.Size = New System.Drawing.Size(200, 20)
Me.lblAddMode.TabIndex = 4
Me.lblAddMode.Text = "Режим для  создания"
Me.lblAddMode.ForeColor = System.Drawing.Color.Blue
Me.txtAddMode.Location = New System.Drawing.Point(20,74)
Me.txtAddMode.name = "txtAddMode"
Me.txtAddMode.Size = New System.Drawing.Size(200, 20)
Me.txtAddMode.TabIndex = 5
Me.txtAddMode.Text = "" 
Me.lblEditMode.Location = New System.Drawing.Point(20,99)
Me.lblEditMode.name = "lblEditMode"
Me.lblEditMode.Size = New System.Drawing.Size(200, 20)
Me.lblEditMode.TabIndex = 6
Me.lblEditMode.Text = "Режим для редактирования"
Me.lblEditMode.ForeColor = System.Drawing.Color.Blue
Me.txtEditMode.Location = New System.Drawing.Point(20,121)
Me.txtEditMode.name = "txtEditMode"
Me.txtEditMode.Size = New System.Drawing.Size(200, 20)
Me.txtEditMode.TabIndex = 7
Me.txtEditMode.Text = "" 
Me.lblAllowAdd.Location = New System.Drawing.Point(20,146)
Me.lblAllowAdd.name = "lblAllowAdd"
Me.lblAllowAdd.Size = New System.Drawing.Size(200, 20)
Me.lblAllowAdd.TabIndex = 8
Me.lblAllowAdd.Text = "Можно создавать"
Me.lblAllowAdd.ForeColor = System.Drawing.Color.Black
Me.cmbAllowAdd.Location = New System.Drawing.Point(20,168)
Me.cmbAllowAdd.name = "cmbAllowAdd"
Me.cmbAllowAdd.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowAdd.TabIndex = 9
Me.lblAllowDelete.Location = New System.Drawing.Point(20,193)
Me.lblAllowDelete.name = "lblAllowDelete"
Me.lblAllowDelete.Size = New System.Drawing.Size(200, 20)
Me.lblAllowDelete.TabIndex = 10
Me.lblAllowDelete.Text = "Можно удалять"
Me.lblAllowDelete.ForeColor = System.Drawing.Color.Black
Me.cmbAllowDelete.Location = New System.Drawing.Point(20,215)
Me.cmbAllowDelete.name = "cmbAllowDelete"
Me.cmbAllowDelete.Size = New System.Drawing.Size(200,  20)
Me.cmbAllowDelete.TabIndex = 11
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblThe_Document)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtThe_Document)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdThe_Document)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAddMode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtAddMode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblEditMode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtEditMode)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowAdd)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowAdd)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAllowDelete)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbAllowDelete)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editiu_rcfg_docmode"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtThe_Document_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThe_Document.TextChanged
  Changing

end sub
private sub cmdThe_Document_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdThe_Document.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("OBJECTTYPE","",System.guid.Empty, id, brief) Then
          txtThe_Document.Tag = id
          txtThe_Document.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtAddMode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddMode.TextChanged
  Changing

end sub
private sub txtEditMode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEditMode.TextChanged
  Changing

end sub
private sub cmbAllowAdd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowAdd.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbAllowDelete_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAllowDelete.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As bprcfg.bprcfg.iu_rcfg_docmode
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,bprcfg.bprcfg.iu_rcfg_docmode)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.The_Document Is Nothing Then
  txtThe_Document.Tag = item.The_Document.id
  txtThe_Document.text = item.The_Document.brief
else
  txtThe_Document.Tag = System.Guid.Empty 
  txtThe_Document.text = "" 
End If
txtAddMode.text = item.AddMode
txtEditMode.text = item.EditMode
cmbAllowAddData = New DataTable
cmbAllowAddData.Columns.Add("name", GetType(System.String))
cmbAllowAddData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowAddDataRow = cmbAllowAddData.NewRow
cmbAllowAddDataRow("name") = "Да"
cmbAllowAddDataRow("Value") = -1
cmbAllowAddData.Rows.Add (cmbAllowAddDataRow)
cmbAllowAddDataRow = cmbAllowAddData.NewRow
cmbAllowAddDataRow("name") = "Нет"
cmbAllowAddDataRow("Value") = 0
cmbAllowAddData.Rows.Add (cmbAllowAddDataRow)
cmbAllowAdd.DisplayMember = "name"
cmbAllowAdd.ValueMember = "Value"
cmbAllowAdd.DataSource = cmbAllowAddData
 cmbAllowAdd.SelectedValue=CInt(Item.AllowAdd)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbAllowDeleteData = New DataTable
cmbAllowDeleteData.Columns.Add("name", GetType(System.String))
cmbAllowDeleteData.Columns.Add("Value", GetType(System.Int32))
try
cmbAllowDeleteDataRow = cmbAllowDeleteData.NewRow
cmbAllowDeleteDataRow("name") = "Да"
cmbAllowDeleteDataRow("Value") = -1
cmbAllowDeleteData.Rows.Add (cmbAllowDeleteDataRow)
cmbAllowDeleteDataRow = cmbAllowDeleteData.NewRow
cmbAllowDeleteDataRow("name") = "Нет"
cmbAllowDeleteDataRow("Value") = 0
cmbAllowDeleteData.Rows.Add (cmbAllowDeleteDataRow)
cmbAllowDelete.DisplayMember = "name"
cmbAllowDelete.ValueMember = "Value"
cmbAllowDelete.DataSource = cmbAllowDeleteData
 cmbAllowDelete.SelectedValue=CInt(Item.AllowDelete)
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

If not txtThe_Document.Tag.Equals(System.Guid.Empty) Then
  item.The_Document = Item.Application.FindRowObject("OBJECTTYPE",txtThe_Document.Tag)
Else
   item.The_Document = Nothing
End If
item.AddMode = txtAddMode.text
item.EditMode = txtEditMode.text
   item.AllowAdd = cmbAllowAdd.SelectedValue
   item.AllowDelete = cmbAllowDelete.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtThe_Document.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =(cmbAllowAdd.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbAllowDelete.SelectedIndex >=0)
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
