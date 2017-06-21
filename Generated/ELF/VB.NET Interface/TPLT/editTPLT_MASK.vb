
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Параметры для вывода режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLT_MASK
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
Friend WithEvents lblPTYPE  as  System.Windows.Forms.Label
Friend WithEvents txtPTYPE As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdPTYPE As System.Windows.Forms.Button
Friend WithEvents lblsequence  as  System.Windows.Forms.Label
Friend WithEvents txtsequence As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblPNAME  as  System.Windows.Forms.Label
Friend WithEvents txtPNAME As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdPNAME As System.Windows.Forms.Button
Friend WithEvents cmdPNAMEClear As System.Windows.Forms.Button
Friend WithEvents lblparamFormat  as  System.Windows.Forms.Label
Friend WithEvents txtparamFormat As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblcolWidth  as  System.Windows.Forms.Label
Friend WithEvents txtcolWidth As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblphide  as  System.Windows.Forms.Label
Friend WithEvents cmbphide As System.Windows.Forms.ComboBox
Friend cmbphideDATA As DataTable
Friend cmbphideDATAROW As DataRow

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
Me.lblPTYPE = New System.Windows.Forms.Label
Me.txtPTYPE = New LATIR2GuiManager.TouchTextBox
Me.cmdPTYPE = New System.Windows.Forms.Button
Me.lblsequence = New System.Windows.Forms.Label
Me.txtsequence = New LATIR2GuiManager.TouchTextBox
Me.lblPNAME = New System.Windows.Forms.Label
Me.txtPNAME = New LATIR2GuiManager.TouchTextBox
Me.cmdPNAME = New System.Windows.Forms.Button
Me.cmdPNAMEClear = New System.Windows.Forms.Button
Me.lblparamFormat = New System.Windows.Forms.Label
Me.txtparamFormat = New LATIR2GuiManager.TouchTextBox
Me.lblcolWidth = New System.Windows.Forms.Label
Me.txtcolWidth = New LATIR2GuiManager.TouchTextBox
Me.lblphide = New System.Windows.Forms.Label
Me.cmbphide = New System.Windows.Forms.ComboBox

Me.lblPTYPE.Location = New System.Drawing.Point(20,5)
Me.lblPTYPE.name = "lblPTYPE"
Me.lblPTYPE.Size = New System.Drawing.Size(200, 20)
Me.lblPTYPE.TabIndex = 1
Me.lblPTYPE.Text = "Тип архива"
Me.lblPTYPE.ForeColor = System.Drawing.Color.Black
Me.txtPTYPE.Location = New System.Drawing.Point(20,27)
Me.txtPTYPE.name = "txtPTYPE"
Me.txtPTYPE.ReadOnly = True
Me.txtPTYPE.Size = New System.Drawing.Size(176, 20)
Me.txtPTYPE.TabIndex = 2
Me.txtPTYPE.Text = "" 
Me.cmdPTYPE.Location = New System.Drawing.Point(198,27)
Me.cmdPTYPE.name = "cmdPTYPE"
Me.cmdPTYPE.Size = New System.Drawing.Size(22, 20)
Me.cmdPTYPE.TabIndex = 3
Me.cmdPTYPE.Text = "..." 
Me.lblsequence.Location = New System.Drawing.Point(20,52)
Me.lblsequence.name = "lblsequence"
Me.lblsequence.Size = New System.Drawing.Size(200, 20)
Me.lblsequence.TabIndex = 4
Me.lblsequence.Text = "Порядок вывода"
Me.lblsequence.ForeColor = System.Drawing.Color.Black
Me.txtsequence.Location = New System.Drawing.Point(20,74)
Me.txtsequence.name = "txtsequence"
Me.txtsequence.MultiLine = false
Me.txtsequence.Size = New System.Drawing.Size(200,  20)
Me.txtsequence.TabIndex = 5
Me.txtsequence.Text = "" 
Me.txtsequence.MaxLength = 15
Me.lblPNAME.Location = New System.Drawing.Point(20,99)
Me.lblPNAME.name = "lblPNAME"
Me.lblPNAME.Size = New System.Drawing.Size(200, 20)
Me.lblPNAME.TabIndex = 6
Me.lblPNAME.Text = "Параметр"
Me.lblPNAME.ForeColor = System.Drawing.Color.Blue
Me.txtPNAME.Location = New System.Drawing.Point(20,121)
Me.txtPNAME.name = "txtPNAME"
Me.txtPNAME.ReadOnly = True
Me.txtPNAME.Size = New System.Drawing.Size(155, 20)
Me.txtPNAME.TabIndex = 7
Me.txtPNAME.Text = "" 
Me.cmdPNAME.Location = New System.Drawing.Point(176,121)
Me.cmdPNAME.name = "cmdPNAME"
Me.cmdPNAME.Size = New System.Drawing.Size(22, 20)
Me.cmdPNAME.TabIndex = 8
Me.cmdPNAME.Text = "..." 
Me.cmdPNAMEClear.Location = New System.Drawing.Point(198,121)
Me.cmdPNAMEClear.name = "cmdPNAMEClear"
Me.cmdPNAMEClear.Size = New System.Drawing.Size(22, 20)
Me.cmdPNAMEClear.TabIndex = 9
Me.cmdPNAMEClear.Text = "X" 
Me.lblparamFormat.Location = New System.Drawing.Point(20,146)
Me.lblparamFormat.name = "lblparamFormat"
Me.lblparamFormat.Size = New System.Drawing.Size(200, 20)
Me.lblparamFormat.TabIndex = 10
Me.lblparamFormat.Text = "Формат"
Me.lblparamFormat.ForeColor = System.Drawing.Color.Blue
Me.txtparamFormat.Location = New System.Drawing.Point(20,168)
Me.txtparamFormat.name = "txtparamFormat"
Me.txtparamFormat.Size = New System.Drawing.Size(200, 20)
Me.txtparamFormat.TabIndex = 11
Me.txtparamFormat.Text = "" 
Me.lblcolWidth.Location = New System.Drawing.Point(20,193)
Me.lblcolWidth.name = "lblcolWidth"
Me.lblcolWidth.Size = New System.Drawing.Size(200, 20)
Me.lblcolWidth.TabIndex = 12
Me.lblcolWidth.Text = "Ширина"
Me.lblcolWidth.ForeColor = System.Drawing.Color.Blue
Me.txtcolWidth.Location = New System.Drawing.Point(20,215)
Me.txtcolWidth.name = "txtcolWidth"
Me.txtcolWidth.MultiLine = false
Me.txtcolWidth.Size = New System.Drawing.Size(200,  20)
Me.txtcolWidth.TabIndex = 13
Me.txtcolWidth.Text = "" 
Me.txtcolWidth.MaxLength = 27
Me.lblphide.Location = New System.Drawing.Point(20,240)
Me.lblphide.name = "lblphide"
Me.lblphide.Size = New System.Drawing.Size(200, 20)
Me.lblphide.TabIndex = 14
Me.lblphide.Text = "Скрыть"
Me.lblphide.ForeColor = System.Drawing.Color.Blue
Me.cmbphide.Location = New System.Drawing.Point(20,262)
Me.cmbphide.name = "cmbphide"
Me.cmbphide.Size = New System.Drawing.Size(200,  20)
Me.cmbphide.TabIndex = 15
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPTYPE)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPTYPE)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdPTYPE)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtsequence)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPNAME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPNAME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdPNAME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdPNAMEClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblparamFormat)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtparamFormat)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblcolWidth)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtcolWidth)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblphide)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbphide)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLT_MASK"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtPTYPE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPTYPE.TextChanged
  Changing

end sub
private sub cmdPTYPE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPTYPE.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLD_PARAMTYPE","",System.guid.Empty, id, brief) Then
          txtPTYPE.Tag = id
          txtPTYPE.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtsequence_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtsequence.Validating
        If txtsequence.Text <> "" Then
            try
            If Not IsNumeric(txtsequence.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtsequence.Text) < -2000000000 Or Val(txtsequence.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtsequence_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsequence.TextChanged
  Changing

end sub
private sub txtPNAME_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPNAME.TextChanged
  Changing

end sub
private sub cmdPNAME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPNAME.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLD_PARAM","",System.guid.Empty, id, brief) Then
          txtPNAME.Tag = id
          txtPNAME.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdPNAMEClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPNAMEClear.Click
  try
          txtPNAME.Tag = Guid.Empty
          txtPNAME.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtparamFormat_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtparamFormat.TextChanged
  Changing

end sub
        Private Sub txtcolWidth_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcolWidth.Validating
        If txtcolWidth.Text <> "" Then
            try
            If Not IsNumeric(txtcolWidth.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtcolWidth.Text) < -922337203685478# Or Val(txtcolWidth.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtcolWidth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcolWidth.TextChanged
  Changing

end sub
private sub cmbphide_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbphide.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As TPLT.TPLT.TPLT_MASK
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLT.TPLT.TPLT_MASK)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.PTYPE Is Nothing Then
  txtPTYPE.Tag = item.PTYPE.id
  txtPTYPE.text = item.PTYPE.brief
else
  txtPTYPE.Tag = System.Guid.Empty 
  txtPTYPE.text = "" 
End If
txtsequence.text = item.sequence.toString()
If Not item.PNAME Is Nothing Then
  txtPNAME.Tag = item.PNAME.id
  txtPNAME.text = item.PNAME.brief
else
  txtPNAME.Tag = System.Guid.Empty 
  txtPNAME.text = "" 
End If
txtparamFormat.text = item.paramFormat
txtcolWidth.text = item.colWidth.toString()
cmbphideData = New DataTable
cmbphideData.Columns.Add("name", GetType(System.String))
cmbphideData.Columns.Add("Value", GetType(System.Int32))
try
cmbphideDataRow = cmbphideData.NewRow
cmbphideDataRow("name") = "Да"
cmbphideDataRow("Value") = -1
cmbphideData.Rows.Add (cmbphideDataRow)
cmbphideDataRow = cmbphideData.NewRow
cmbphideDataRow("name") = "Нет"
cmbphideDataRow("Value") = 0
cmbphideData.Rows.Add (cmbphideDataRow)
cmbphide.DisplayMember = "name"
cmbphide.ValueMember = "Value"
cmbphide.DataSource = cmbphideData
 cmbphide.SelectedValue=CInt(Item.phide)
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

If not txtPTYPE.Tag.Equals(System.Guid.Empty) Then
  item.PTYPE = Item.Application.FindRowObject("TPLD_PARAMTYPE",txtPTYPE.Tag)
Else
   item.PTYPE = Nothing
End If
item.sequence = val(txtsequence.text)
If not txtPNAME.Tag.Equals(System.Guid.Empty) Then
  item.PNAME = Item.Application.FindRowObject("TPLD_PARAM",txtPNAME.Tag)
Else
   item.PNAME = Nothing
End If
item.paramFormat = txtparamFormat.text
item.colWidth = cdbl(txtcolWidth.text)
   item.phide = cmbphide.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtPTYPE.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK =( txtsequence.text <> "" ) 
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
