
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Граничные значения режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLT_VALUEBOUNDS
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
Friend WithEvents lblPNAME  as  System.Windows.Forms.Label
Friend WithEvents txtPNAME As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdPNAME As System.Windows.Forms.Button
Friend WithEvents cmdPNAMEClear As System.Windows.Forms.Button
Friend WithEvents lblPTYPE  as  System.Windows.Forms.Label
Friend WithEvents txtPTYPE As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdPTYPE As System.Windows.Forms.Button
Friend WithEvents lblPMIN  as  System.Windows.Forms.Label
Friend WithEvents txtPMIN As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblPMAX  as  System.Windows.Forms.Label
Friend WithEvents txtPMAX As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblISMIN  as  System.Windows.Forms.Label
Friend WithEvents cmbISMIN As System.Windows.Forms.ComboBox
Friend cmbISMINDATA As DataTable
Friend cmbISMINDATAROW As DataRow
Friend WithEvents lblISMAX  as  System.Windows.Forms.Label
Friend WithEvents cmbISMAX As System.Windows.Forms.ComboBox
Friend cmbISMAXDATA As DataTable
Friend cmbISMAXDATAROW As DataRow

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
Me.lblPNAME = New System.Windows.Forms.Label
Me.txtPNAME = New LATIR2GuiManager.TouchTextBox
Me.cmdPNAME = New System.Windows.Forms.Button
Me.cmdPNAMEClear = New System.Windows.Forms.Button
Me.lblPTYPE = New System.Windows.Forms.Label
Me.txtPTYPE = New LATIR2GuiManager.TouchTextBox
Me.cmdPTYPE = New System.Windows.Forms.Button
Me.lblPMIN = New System.Windows.Forms.Label
Me.txtPMIN = New LATIR2GuiManager.TouchTextBox
Me.lblPMAX = New System.Windows.Forms.Label
Me.txtPMAX = New LATIR2GuiManager.TouchTextBox
Me.lblISMIN = New System.Windows.Forms.Label
Me.cmbISMIN = New System.Windows.Forms.ComboBox
Me.lblISMAX = New System.Windows.Forms.Label
Me.cmbISMAX = New System.Windows.Forms.ComboBox

Me.lblPNAME.Location = New System.Drawing.Point(20,5)
Me.lblPNAME.name = "lblPNAME"
Me.lblPNAME.Size = New System.Drawing.Size(200, 20)
Me.lblPNAME.TabIndex = 1
Me.lblPNAME.Text = "Параметр"
Me.lblPNAME.ForeColor = System.Drawing.Color.Blue
Me.txtPNAME.Location = New System.Drawing.Point(20,27)
Me.txtPNAME.name = "txtPNAME"
Me.txtPNAME.ReadOnly = True
Me.txtPNAME.Size = New System.Drawing.Size(155, 20)
Me.txtPNAME.TabIndex = 2
Me.txtPNAME.Text = "" 
Me.cmdPNAME.Location = New System.Drawing.Point(176,27)
Me.cmdPNAME.name = "cmdPNAME"
Me.cmdPNAME.Size = New System.Drawing.Size(22, 20)
Me.cmdPNAME.TabIndex = 3
Me.cmdPNAME.Text = "..." 
Me.cmdPNAMEClear.Location = New System.Drawing.Point(198,27)
Me.cmdPNAMEClear.name = "cmdPNAMEClear"
Me.cmdPNAMEClear.Size = New System.Drawing.Size(22, 20)
Me.cmdPNAMEClear.TabIndex = 4
Me.cmdPNAMEClear.Text = "X" 
Me.lblPTYPE.Location = New System.Drawing.Point(20,52)
Me.lblPTYPE.name = "lblPTYPE"
Me.lblPTYPE.Size = New System.Drawing.Size(200, 20)
Me.lblPTYPE.TabIndex = 5
Me.lblPTYPE.Text = "Тип архива"
Me.lblPTYPE.ForeColor = System.Drawing.Color.Black
Me.txtPTYPE.Location = New System.Drawing.Point(20,74)
Me.txtPTYPE.name = "txtPTYPE"
Me.txtPTYPE.ReadOnly = True
Me.txtPTYPE.Size = New System.Drawing.Size(176, 20)
Me.txtPTYPE.TabIndex = 6
Me.txtPTYPE.Text = "" 
Me.cmdPTYPE.Location = New System.Drawing.Point(198,74)
Me.cmdPTYPE.name = "cmdPTYPE"
Me.cmdPTYPE.Size = New System.Drawing.Size(22, 20)
Me.cmdPTYPE.TabIndex = 7
Me.cmdPTYPE.Text = "..." 
Me.lblPMIN.Location = New System.Drawing.Point(20,99)
Me.lblPMIN.name = "lblPMIN"
Me.lblPMIN.Size = New System.Drawing.Size(200, 20)
Me.lblPMIN.TabIndex = 8
Me.lblPMIN.Text = "Минимальное значение"
Me.lblPMIN.ForeColor = System.Drawing.Color.Blue
Me.txtPMIN.Location = New System.Drawing.Point(20,121)
Me.txtPMIN.name = "txtPMIN"
Me.txtPMIN.MultiLine = false
Me.txtPMIN.Size = New System.Drawing.Size(200,  20)
Me.txtPMIN.TabIndex = 9
Me.txtPMIN.Text = "" 
Me.txtPMIN.MaxLength = 27
Me.lblPMAX.Location = New System.Drawing.Point(20,146)
Me.lblPMAX.name = "lblPMAX"
Me.lblPMAX.Size = New System.Drawing.Size(200, 20)
Me.lblPMAX.TabIndex = 10
Me.lblPMAX.Text = "Максимальное значение"
Me.lblPMAX.ForeColor = System.Drawing.Color.Blue
Me.txtPMAX.Location = New System.Drawing.Point(20,168)
Me.txtPMAX.name = "txtPMAX"
Me.txtPMAX.MultiLine = false
Me.txtPMAX.Size = New System.Drawing.Size(200,  20)
Me.txtPMAX.TabIndex = 11
Me.txtPMAX.Text = "" 
Me.txtPMAX.MaxLength = 27
Me.lblISMIN.Location = New System.Drawing.Point(20,193)
Me.lblISMIN.name = "lblISMIN"
Me.lblISMIN.Size = New System.Drawing.Size(200, 20)
Me.lblISMIN.TabIndex = 12
Me.lblISMIN.Text = "Проверять на минимум"
Me.lblISMIN.ForeColor = System.Drawing.Color.Blue
Me.cmbISMIN.Location = New System.Drawing.Point(20,215)
Me.cmbISMIN.name = "cmbISMIN"
Me.cmbISMIN.Size = New System.Drawing.Size(200,  20)
Me.cmbISMIN.TabIndex = 13
Me.lblISMAX.Location = New System.Drawing.Point(20,240)
Me.lblISMAX.name = "lblISMAX"
Me.lblISMAX.Size = New System.Drawing.Size(200, 20)
Me.lblISMAX.TabIndex = 14
Me.lblISMAX.Text = "Проверять на максимум"
Me.lblISMAX.ForeColor = System.Drawing.Color.Blue
Me.cmbISMAX.Location = New System.Drawing.Point(20,262)
Me.cmbISMAX.name = "cmbISMAX"
Me.cmbISMAX.Size = New System.Drawing.Size(200,  20)
Me.cmbISMAX.TabIndex = 15
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPNAME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPNAME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdPNAME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdPNAMEClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPTYPE)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPTYPE)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdPTYPE)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPMIN)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPMIN)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPMAX)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPMAX)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblISMIN)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbISMIN)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblISMAX)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbISMAX)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLT_VALUEBOUNDS"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

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
        Private Sub txtPMIN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPMIN.Validating
        If txtPMIN.Text <> "" Then
            try
            If Not IsNumeric(txtPMIN.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtPMIN.Text) < -922337203685478# Or Val(txtPMIN.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtPMIN_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPMIN.TextChanged
  Changing

end sub
        Private Sub txtPMAX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPMAX.Validating
        If txtPMAX.Text <> "" Then
            try
            If Not IsNumeric(txtPMAX.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtPMAX.Text) < -922337203685478# Or Val(txtPMAX.Text) > 922337203685478# Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtPMAX_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPMAX.TextChanged
  Changing

end sub
private sub cmbISMIN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbISMIN.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbISMAX_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbISMAX.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As TPLT.TPLT.TPLT_VALUEBOUNDS
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLT.TPLT.TPLT_VALUEBOUNDS)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.PNAME Is Nothing Then
  txtPNAME.Tag = item.PNAME.id
  txtPNAME.text = item.PNAME.brief
else
  txtPNAME.Tag = System.Guid.Empty 
  txtPNAME.text = "" 
End If
If Not item.PTYPE Is Nothing Then
  txtPTYPE.Tag = item.PTYPE.id
  txtPTYPE.text = item.PTYPE.brief
else
  txtPTYPE.Tag = System.Guid.Empty 
  txtPTYPE.text = "" 
End If
txtPMIN.text = item.PMIN.toString()
txtPMAX.text = item.PMAX.toString()
cmbISMINData = New DataTable
cmbISMINData.Columns.Add("name", GetType(System.String))
cmbISMINData.Columns.Add("Value", GetType(System.Int32))
try
cmbISMINDataRow = cmbISMINData.NewRow
cmbISMINDataRow("name") = "Да"
cmbISMINDataRow("Value") = -1
cmbISMINData.Rows.Add (cmbISMINDataRow)
cmbISMINDataRow = cmbISMINData.NewRow
cmbISMINDataRow("name") = "Нет"
cmbISMINDataRow("Value") = 0
cmbISMINData.Rows.Add (cmbISMINDataRow)
cmbISMIN.DisplayMember = "name"
cmbISMIN.ValueMember = "Value"
cmbISMIN.DataSource = cmbISMINData
 cmbISMIN.SelectedValue=CInt(Item.ISMIN)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbISMAXData = New DataTable
cmbISMAXData.Columns.Add("name", GetType(System.String))
cmbISMAXData.Columns.Add("Value", GetType(System.Int32))
try
cmbISMAXDataRow = cmbISMAXData.NewRow
cmbISMAXDataRow("name") = "Да"
cmbISMAXDataRow("Value") = -1
cmbISMAXData.Rows.Add (cmbISMAXDataRow)
cmbISMAXDataRow = cmbISMAXData.NewRow
cmbISMAXDataRow("name") = "Нет"
cmbISMAXDataRow("Value") = 0
cmbISMAXData.Rows.Add (cmbISMAXDataRow)
cmbISMAX.DisplayMember = "name"
cmbISMAX.ValueMember = "Value"
cmbISMAX.DataSource = cmbISMAXData
 cmbISMAX.SelectedValue=CInt(Item.ISMAX)
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

If not txtPNAME.Tag.Equals(System.Guid.Empty) Then
  item.PNAME = Item.Application.FindRowObject("TPLD_PARAM",txtPNAME.Tag)
Else
   item.PNAME = Nothing
End If
If not txtPTYPE.Tag.Equals(System.Guid.Empty) Then
  item.PTYPE = Item.Application.FindRowObject("TPLD_PARAMTYPE",txtPTYPE.Tag)
Else
   item.PTYPE = Nothing
End If
item.PMIN = cdbl(txtPMIN.text)
item.PMAX = cdbl(txtPMAX.text)
   item.ISMIN = cmbISMIN.SelectedValue
   item.ISMAX = cmbISMAX.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtPTYPE.Tag.Equals(System.Guid.Empty)
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
