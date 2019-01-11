
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Параметры на схеме режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLS_PARAM
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
Friend WithEvents lblArchType  as  System.Windows.Forms.Label
Friend WithEvents txtArchType As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdArchType As System.Windows.Forms.Button
Friend WithEvents lblParam  as  System.Windows.Forms.Label
Friend WithEvents txtParam As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdParam As System.Windows.Forms.Button
Friend WithEvents lblPOS_LEFT  as  System.Windows.Forms.Label
Friend WithEvents txtPOS_LEFT As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblPOS_TOP  as  System.Windows.Forms.Label
Friend WithEvents txtPOS_TOP As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblHIDEPARAM  as  System.Windows.Forms.Label
Friend WithEvents cmbHIDEPARAM As System.Windows.Forms.ComboBox
Friend cmbHIDEPARAMDATA As DataTable
Friend cmbHIDEPARAMDATAROW As DataRow
Friend WithEvents lblHideOnSchema  as  System.Windows.Forms.Label
Friend WithEvents cmbHideOnSchema As System.Windows.Forms.ComboBox
Friend cmbHideOnSchemaDATA As DataTable
Friend cmbHideOnSchemaDATAROW As DataRow

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
Me.lblArchType = New System.Windows.Forms.Label
Me.txtArchType = New LATIR2GuiManager.TouchTextBox
Me.cmdArchType = New System.Windows.Forms.Button
Me.lblParam = New System.Windows.Forms.Label
Me.txtParam = New LATIR2GuiManager.TouchTextBox
Me.cmdParam = New System.Windows.Forms.Button
Me.lblPOS_LEFT = New System.Windows.Forms.Label
Me.txtPOS_LEFT = New LATIR2GuiManager.TouchTextBox
Me.lblPOS_TOP = New System.Windows.Forms.Label
Me.txtPOS_TOP = New LATIR2GuiManager.TouchTextBox
Me.lblHIDEPARAM = New System.Windows.Forms.Label
Me.cmbHIDEPARAM = New System.Windows.Forms.ComboBox
Me.lblHideOnSchema = New System.Windows.Forms.Label
Me.cmbHideOnSchema = New System.Windows.Forms.ComboBox

Me.lblArchType.Location = New System.Drawing.Point(20,5)
Me.lblArchType.name = "lblArchType"
Me.lblArchType.Size = New System.Drawing.Size(200, 20)
Me.lblArchType.TabIndex = 1
Me.lblArchType.Text = "Тип архива"
Me.lblArchType.ForeColor = System.Drawing.Color.Black
Me.txtArchType.Location = New System.Drawing.Point(20,27)
Me.txtArchType.name = "txtArchType"
Me.txtArchType.ReadOnly = True
Me.txtArchType.Size = New System.Drawing.Size(176, 20)
Me.txtArchType.TabIndex = 2
Me.txtArchType.Text = "" 
Me.cmdArchType.Location = New System.Drawing.Point(198,27)
Me.cmdArchType.name = "cmdArchType"
Me.cmdArchType.Size = New System.Drawing.Size(22, 20)
Me.cmdArchType.TabIndex = 3
Me.cmdArchType.Text = "..." 
Me.lblParam.Location = New System.Drawing.Point(20,52)
Me.lblParam.name = "lblParam"
Me.lblParam.Size = New System.Drawing.Size(200, 20)
Me.lblParam.TabIndex = 4
Me.lblParam.Text = "Параметр"
Me.lblParam.ForeColor = System.Drawing.Color.Black
Me.txtParam.Location = New System.Drawing.Point(20,74)
Me.txtParam.name = "txtParam"
Me.txtParam.ReadOnly = True
Me.txtParam.Size = New System.Drawing.Size(176, 20)
Me.txtParam.TabIndex = 5
Me.txtParam.Text = "" 
Me.cmdParam.Location = New System.Drawing.Point(198,74)
Me.cmdParam.name = "cmdParam"
Me.cmdParam.Size = New System.Drawing.Size(22, 20)
Me.cmdParam.TabIndex = 6
Me.cmdParam.Text = "..." 
Me.lblPOS_LEFT.Location = New System.Drawing.Point(20,99)
Me.lblPOS_LEFT.name = "lblPOS_LEFT"
Me.lblPOS_LEFT.Size = New System.Drawing.Size(200, 20)
Me.lblPOS_LEFT.TabIndex = 7
Me.lblPOS_LEFT.Text = "X"
Me.lblPOS_LEFT.ForeColor = System.Drawing.Color.Black
Me.txtPOS_LEFT.Location = New System.Drawing.Point(20,121)
Me.txtPOS_LEFT.name = "txtPOS_LEFT"
Me.txtPOS_LEFT.MultiLine = false
Me.txtPOS_LEFT.Size = New System.Drawing.Size(200,  20)
Me.txtPOS_LEFT.TabIndex = 8
Me.txtPOS_LEFT.Text = "" 
Me.txtPOS_LEFT.MaxLength = 27
Me.lblPOS_TOP.Location = New System.Drawing.Point(20,146)
Me.lblPOS_TOP.name = "lblPOS_TOP"
Me.lblPOS_TOP.Size = New System.Drawing.Size(200, 20)
Me.lblPOS_TOP.TabIndex = 9
Me.lblPOS_TOP.Text = "Y"
Me.lblPOS_TOP.ForeColor = System.Drawing.Color.Black
Me.txtPOS_TOP.Location = New System.Drawing.Point(20,168)
Me.txtPOS_TOP.name = "txtPOS_TOP"
Me.txtPOS_TOP.MultiLine = false
Me.txtPOS_TOP.Size = New System.Drawing.Size(200,  20)
Me.txtPOS_TOP.TabIndex = 10
Me.txtPOS_TOP.Text = "" 
Me.txtPOS_TOP.MaxLength = 27
Me.lblHIDEPARAM.Location = New System.Drawing.Point(20,193)
Me.lblHIDEPARAM.name = "lblHIDEPARAM"
Me.lblHIDEPARAM.Size = New System.Drawing.Size(200, 20)
Me.lblHIDEPARAM.TabIndex = 11
Me.lblHIDEPARAM.Text = "Скрыть"
Me.lblHIDEPARAM.ForeColor = System.Drawing.Color.Black
Me.cmbHIDEPARAM.Location = New System.Drawing.Point(20,215)
Me.cmbHIDEPARAM.name = "cmbHIDEPARAM"
Me.cmbHIDEPARAM.Size = New System.Drawing.Size(200,  20)
Me.cmbHIDEPARAM.TabIndex = 12
Me.lblHideOnSchema.Location = New System.Drawing.Point(20,240)
Me.lblHideOnSchema.name = "lblHideOnSchema"
Me.lblHideOnSchema.Size = New System.Drawing.Size(200, 20)
Me.lblHideOnSchema.TabIndex = 13
Me.lblHideOnSchema.Text = "Не отображать на схеме"
Me.lblHideOnSchema.ForeColor = System.Drawing.Color.Blue
Me.cmbHideOnSchema.Location = New System.Drawing.Point(20,262)
Me.cmbHideOnSchema.name = "cmbHideOnSchema"
Me.cmbHideOnSchema.Size = New System.Drawing.Size(200,  20)
Me.cmbHideOnSchema.TabIndex = 14
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblArchType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtArchType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdArchType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblParam)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtParam)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdParam)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPOS_LEFT)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPOS_LEFT)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPOS_TOP)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPOS_TOP)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblHIDEPARAM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbHIDEPARAM)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblHideOnSchema)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbHideOnSchema)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLS_PARAM"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtArchType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtArchType.TextChanged
  Changing

end sub
private sub cmdArchType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdArchType.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLD_PARAMTYPE","",System.guid.Empty, id, brief) Then
          txtArchType.Tag = id
          txtArchType.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtParam_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtParam.TextChanged
  Changing

end sub
private sub cmdParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdParam.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLD_PARAM","",System.guid.Empty, id, brief) Then
          txtParam.Tag = id
          txtParam.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtPOS_LEFT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPOS_LEFT.Validating
        If txtPOS_LEFT.Text <> "" Then
            try
            If Not IsNumeric(txtPOS_LEFT.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtPOS_LEFT.Text) < -922337203685478# Or Val(txtPOS_LEFT.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtPOS_LEFT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPOS_LEFT.TextChanged
  Changing

end sub
        Private Sub txtPOS_TOP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPOS_TOP.Validating
        If txtPOS_TOP.Text <> "" Then
            try
            If Not IsNumeric(txtPOS_TOP.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtPOS_TOP.Text) < -922337203685478# Or Val(txtPOS_TOP.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtPOS_TOP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPOS_TOP.TextChanged
  Changing

end sub
private sub cmbHIDEPARAM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHIDEPARAM.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbHideOnSchema_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHideOnSchema.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As TPLS.TPLS.TPLS_PARAM
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLS.TPLS.TPLS_PARAM)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.ArchType Is Nothing Then
  txtArchType.Tag = item.ArchType.id
  txtArchType.text = item.ArchType.brief
else
  txtArchType.Tag = System.Guid.Empty 
  txtArchType.text = "" 
End If
If Not item.Param Is Nothing Then
  txtParam.Tag = item.Param.id
  txtParam.text = item.Param.brief
else
  txtParam.Tag = System.Guid.Empty 
  txtParam.text = "" 
End If
txtPOS_LEFT.text = item.POS_LEFT.toString()
txtPOS_TOP.text = item.POS_TOP.toString()
cmbHIDEPARAMData = New DataTable
cmbHIDEPARAMData.Columns.Add("name", GetType(System.String))
cmbHIDEPARAMData.Columns.Add("Value", GetType(System.Int32))
try
cmbHIDEPARAMDataRow = cmbHIDEPARAMData.NewRow
cmbHIDEPARAMDataRow("name") = "Да"
cmbHIDEPARAMDataRow("Value") = -1
cmbHIDEPARAMData.Rows.Add (cmbHIDEPARAMDataRow)
cmbHIDEPARAMDataRow = cmbHIDEPARAMData.NewRow
cmbHIDEPARAMDataRow("name") = "Нет"
cmbHIDEPARAMDataRow("Value") = 0
cmbHIDEPARAMData.Rows.Add (cmbHIDEPARAMDataRow)
cmbHIDEPARAM.DisplayMember = "name"
cmbHIDEPARAM.ValueMember = "Value"
cmbHIDEPARAM.DataSource = cmbHIDEPARAMData
 cmbHIDEPARAM.SelectedValue=CInt(Item.HIDEPARAM)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbHideOnSchemaData = New DataTable
cmbHideOnSchemaData.Columns.Add("name", GetType(System.String))
cmbHideOnSchemaData.Columns.Add("Value", GetType(System.Int32))
try
cmbHideOnSchemaDataRow = cmbHideOnSchemaData.NewRow
cmbHideOnSchemaDataRow("name") = "Да"
cmbHideOnSchemaDataRow("Value") = -1
cmbHideOnSchemaData.Rows.Add (cmbHideOnSchemaDataRow)
cmbHideOnSchemaDataRow = cmbHideOnSchemaData.NewRow
cmbHideOnSchemaDataRow("name") = "Нет"
cmbHideOnSchemaDataRow("Value") = 0
cmbHideOnSchemaData.Rows.Add (cmbHideOnSchemaDataRow)
cmbHideOnSchema.DisplayMember = "name"
cmbHideOnSchema.ValueMember = "Value"
cmbHideOnSchema.DataSource = cmbHideOnSchemaData
 cmbHideOnSchema.SelectedValue=CInt(Item.HideOnSchema)
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

If not txtArchType.Tag.Equals(System.Guid.Empty) Then
  item.ArchType = Item.Application.FindRowObject("TPLD_PARAMTYPE",txtArchType.Tag)
Else
   item.ArchType = Nothing
End If
If not txtParam.Tag.Equals(System.Guid.Empty) Then
  item.Param = Item.Application.FindRowObject("TPLD_PARAM",txtParam.Tag)
Else
   item.Param = Nothing
End If
item.POS_LEFT = cdbl(txtPOS_LEFT.text)
item.POS_TOP = cdbl(txtPOS_TOP.text)
   item.HIDEPARAM = cmbHIDEPARAM.SelectedValue
   item.HideOnSchema = cmbHideOnSchema.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtArchType.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = not txtParam.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtPOS_LEFT.text <> "" ) 
if mIsOK then mIsOK =( txtPOS_TOP.text <> "" ) 
if mIsOK then mIsOK =(cmbHIDEPARAM.SelectedIndex >=0)
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
