
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Описание режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPQ_DEF
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
Friend WithEvents lblTheSessionID  as  System.Windows.Forms.Label
Friend WithEvents txtTheSessionID As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheSessionID As System.Windows.Forms.Button
Friend WithEvents lblTheDevice  as  System.Windows.Forms.Label
Friend WithEvents txtTheDevice As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTheDevice As System.Windows.Forms.Button
Friend WithEvents lblArchType  as  System.Windows.Forms.Label
Friend WithEvents txtArchType As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdArchType As System.Windows.Forms.Button
Friend WithEvents lblArchTime  as  System.Windows.Forms.Label
Friend WithEvents dtpArchTime As System.Windows.Forms.DateTimePicker
Friend WithEvents lblQueryTime  as  System.Windows.Forms.Label
Friend WithEvents dtpQueryTime As System.Windows.Forms.DateTimePicker
Friend WithEvents lblIsUrgent  as  System.Windows.Forms.Label
Friend WithEvents cmbIsUrgent As System.Windows.Forms.ComboBox
Friend cmbIsUrgentDATA As DataTable
Friend cmbIsUrgentDATAROW As DataRow
Friend WithEvents lblRepeatTimes  as  System.Windows.Forms.Label
Friend WithEvents txtRepeatTimes As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblRepeatInterval  as  System.Windows.Forms.Label
Friend WithEvents txtRepeatInterval As LATIR2GuiManager.TouchTextBox

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
Me.lblTheSessionID = New System.Windows.Forms.Label
Me.txtTheSessionID = New LATIR2GuiManager.TouchTextBox
Me.cmdTheSessionID = New System.Windows.Forms.Button
Me.lblTheDevice = New System.Windows.Forms.Label
Me.txtTheDevice = New LATIR2GuiManager.TouchTextBox
Me.cmdTheDevice = New System.Windows.Forms.Button
Me.lblArchType = New System.Windows.Forms.Label
Me.txtArchType = New LATIR2GuiManager.TouchTextBox
Me.cmdArchType = New System.Windows.Forms.Button
Me.lblArchTime = New System.Windows.Forms.Label
Me.dtpArchTime = New System.Windows.Forms.DateTimePicker
Me.lblQueryTime = New System.Windows.Forms.Label
Me.dtpQueryTime = New System.Windows.Forms.DateTimePicker
Me.lblIsUrgent = New System.Windows.Forms.Label
Me.cmbIsUrgent = New System.Windows.Forms.ComboBox
Me.lblRepeatTimes = New System.Windows.Forms.Label
Me.txtRepeatTimes = New LATIR2GuiManager.TouchTextBox
Me.lblRepeatInterval = New System.Windows.Forms.Label
Me.txtRepeatInterval = New LATIR2GuiManager.TouchTextBox

Me.lblTheSessionID.Location = New System.Drawing.Point(20,5)
Me.lblTheSessionID.name = "lblTheSessionID"
Me.lblTheSessionID.Size = New System.Drawing.Size(200, 20)
Me.lblTheSessionID.TabIndex = 1
Me.lblTheSessionID.Text = "Сессия"
Me.lblTheSessionID.ForeColor = System.Drawing.Color.Black
Me.txtTheSessionID.Location = New System.Drawing.Point(20,27)
Me.txtTheSessionID.name = "txtTheSessionID"
Me.txtTheSessionID.ReadOnly = True
Me.txtTheSessionID.Size = New System.Drawing.Size(176, 20)
Me.txtTheSessionID.TabIndex = 2
Me.txtTheSessionID.Text = "" 
Me.cmdTheSessionID.Location = New System.Drawing.Point(198,27)
Me.cmdTheSessionID.name = "cmdTheSessionID"
Me.cmdTheSessionID.Size = New System.Drawing.Size(22, 20)
Me.cmdTheSessionID.TabIndex = 3
Me.cmdTheSessionID.Text = "..." 
Me.lblTheDevice.Location = New System.Drawing.Point(20,52)
Me.lblTheDevice.name = "lblTheDevice"
Me.lblTheDevice.Size = New System.Drawing.Size(200, 20)
Me.lblTheDevice.TabIndex = 4
Me.lblTheDevice.Text = "Тепловычислитель"
Me.lblTheDevice.ForeColor = System.Drawing.Color.Black
Me.txtTheDevice.Location = New System.Drawing.Point(20,74)
Me.txtTheDevice.name = "txtTheDevice"
Me.txtTheDevice.ReadOnly = True
Me.txtTheDevice.Size = New System.Drawing.Size(176, 20)
Me.txtTheDevice.TabIndex = 5
Me.txtTheDevice.Text = "" 
Me.cmdTheDevice.Location = New System.Drawing.Point(198,74)
Me.cmdTheDevice.name = "cmdTheDevice"
Me.cmdTheDevice.Size = New System.Drawing.Size(22, 20)
Me.cmdTheDevice.TabIndex = 6
Me.cmdTheDevice.Text = "..." 
Me.lblArchType.Location = New System.Drawing.Point(20,99)
Me.lblArchType.name = "lblArchType"
Me.lblArchType.Size = New System.Drawing.Size(200, 20)
Me.lblArchType.TabIndex = 7
Me.lblArchType.Text = "Тип архива"
Me.lblArchType.ForeColor = System.Drawing.Color.Black
Me.txtArchType.Location = New System.Drawing.Point(20,121)
Me.txtArchType.name = "txtArchType"
Me.txtArchType.ReadOnly = True
Me.txtArchType.Size = New System.Drawing.Size(176, 20)
Me.txtArchType.TabIndex = 8
Me.txtArchType.Text = "" 
Me.cmdArchType.Location = New System.Drawing.Point(198,121)
Me.cmdArchType.name = "cmdArchType"
Me.cmdArchType.Size = New System.Drawing.Size(22, 20)
Me.cmdArchType.TabIndex = 9
Me.cmdArchType.Text = "..." 
Me.lblArchTime.Location = New System.Drawing.Point(20,146)
Me.lblArchTime.name = "lblArchTime"
Me.lblArchTime.Size = New System.Drawing.Size(200, 20)
Me.lblArchTime.TabIndex = 10
Me.lblArchTime.Text = "Время"
Me.lblArchTime.ForeColor = System.Drawing.Color.Blue
Me.dtpArchTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpArchTime.Location = New System.Drawing.Point(20,168)
Me.dtpArchTime.name = "dtpArchTime"
Me.dtpArchTime.Size = New System.Drawing.Size(200,  20)
Me.dtpArchTime.TabIndex =11
Me.dtpArchTime.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpArchTime.ShowCheckBox=True
Me.lblQueryTime.Location = New System.Drawing.Point(20,193)
Me.lblQueryTime.name = "lblQueryTime"
Me.lblQueryTime.Size = New System.Drawing.Size(200, 20)
Me.lblQueryTime.TabIndex = 12
Me.lblQueryTime.Text = "Время  постановки запроса"
Me.lblQueryTime.ForeColor = System.Drawing.Color.Black
Me.dtpQueryTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpQueryTime.Location = New System.Drawing.Point(20,215)
Me.dtpQueryTime.name = "dtpQueryTime"
Me.dtpQueryTime.Size = New System.Drawing.Size(200,  20)
Me.dtpQueryTime.TabIndex =13
Me.dtpQueryTime.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpQueryTime.ShowCheckBox=False
Me.lblIsUrgent.Location = New System.Drawing.Point(20,240)
Me.lblIsUrgent.name = "lblIsUrgent"
Me.lblIsUrgent.Size = New System.Drawing.Size(200, 20)
Me.lblIsUrgent.TabIndex = 14
Me.lblIsUrgent.Text = "Срочный запрос"
Me.lblIsUrgent.ForeColor = System.Drawing.Color.Blue
Me.cmbIsUrgent.Location = New System.Drawing.Point(20,262)
Me.cmbIsUrgent.name = "cmbIsUrgent"
Me.cmbIsUrgent.Size = New System.Drawing.Size(200,  20)
Me.cmbIsUrgent.TabIndex = 15
Me.lblRepeatTimes.Location = New System.Drawing.Point(20,287)
Me.lblRepeatTimes.name = "lblRepeatTimes"
Me.lblRepeatTimes.Size = New System.Drawing.Size(200, 20)
Me.lblRepeatTimes.TabIndex = 16
Me.lblRepeatTimes.Text = "Количество повторений при ошибке"
Me.lblRepeatTimes.ForeColor = System.Drawing.Color.Blue
Me.txtRepeatTimes.Location = New System.Drawing.Point(20,309)
Me.txtRepeatTimes.name = "txtRepeatTimes"
Me.txtRepeatTimes.MultiLine = false
Me.txtRepeatTimes.Size = New System.Drawing.Size(200,  20)
Me.txtRepeatTimes.TabIndex = 17
Me.txtRepeatTimes.Text = "" 
Me.txtRepeatTimes.MaxLength = 15
Me.lblRepeatInterval.Location = New System.Drawing.Point(20,334)
Me.lblRepeatInterval.name = "lblRepeatInterval"
Me.lblRepeatInterval.Size = New System.Drawing.Size(200, 20)
Me.lblRepeatInterval.TabIndex = 18
Me.lblRepeatInterval.Text = "Интервал между повторами"
Me.lblRepeatInterval.ForeColor = System.Drawing.Color.Blue
Me.txtRepeatInterval.Location = New System.Drawing.Point(20,356)
Me.txtRepeatInterval.name = "txtRepeatInterval"
Me.txtRepeatInterval.MultiLine = false
Me.txtRepeatInterval.Size = New System.Drawing.Size(200,  20)
Me.txtRepeatInterval.TabIndex = 19
Me.txtRepeatInterval.Text = "" 
Me.txtRepeatInterval.MaxLength = 15
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheSessionID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheSessionID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheSessionID)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTheDevice)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTheDevice)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTheDevice)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblArchType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtArchType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdArchType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblArchTime)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpArchTime)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblQueryTime)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpQueryTime)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIsUrgent)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbIsUrgent)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblRepeatTimes)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtRepeatTimes)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblRepeatInterval)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtRepeatInterval)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPQ_DEF"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTheSessionID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheSessionID.TextChanged
  Changing

end sub
private sub cmdTheSessionID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheSessionID.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("the_Session","",System.guid.Empty, id, brief) Then
          txtTheSessionID.Tag = id
          txtTheSessionID.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTheDevice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTheDevice.TextChanged
  Changing

end sub
private sub cmdTheDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTheDevice.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLT_BDEVICES","",System.guid.Empty, id, brief) Then
          txtTheDevice.Tag = id
          txtTheDevice.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
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
private sub dtpArchTime_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpArchTime.ValueChanged
  Changing 

end sub
private sub dtpQueryTime_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpQueryTime.ValueChanged
  Changing 

end sub
private sub cmbIsUrgent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsUrgent.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
        Private Sub txtRepeatTimes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRepeatTimes.Validating
        If txtRepeatTimes.Text <> "" Then
            try
            If Not IsNumeric(txtRepeatTimes.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtRepeatTimes.Text) < -2000000000 Or Val(txtRepeatTimes.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtRepeatTimes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRepeatTimes.TextChanged
  Changing

end sub
        Private Sub txtRepeatInterval_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRepeatInterval.Validating
        If txtRepeatInterval.Text <> "" Then
            try
            If Not IsNumeric(txtRepeatInterval.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtRepeatInterval.Text) < -2000000000 Or Val(txtRepeatInterval.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtRepeatInterval_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRepeatInterval.TextChanged
  Changing

end sub

Public Item As TPQ.TPQ.TPQ_DEF
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPQ.TPQ.TPQ_DEF)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.TheSessionID Is Nothing Then
  txtTheSessionID.Tag = item.TheSessionID.id
  txtTheSessionID.text = item.TheSessionID.brief
else
  txtTheSessionID.Tag = System.Guid.Empty 
  txtTheSessionID.text = "" 
End If
If Not item.TheDevice Is Nothing Then
  txtTheDevice.Tag = item.TheDevice.id
  txtTheDevice.text = item.TheDevice.brief
else
  txtTheDevice.Tag = System.Guid.Empty 
  txtTheDevice.text = "" 
End If
If Not item.ArchType Is Nothing Then
  txtArchType.Tag = item.ArchType.id
  txtArchType.text = item.ArchType.brief
else
  txtArchType.Tag = System.Guid.Empty 
  txtArchType.text = "" 
End If
dtpArchTime.value = System.DateTime.Now
if item.ArchTime <> System.DateTime.MinValue then
  try
     dtpArchTime.value = item.ArchTime
  catch
   dtpArchTime.value = System.DateTime.MinValue
  end try
else
   dtpArchTime.value = System.DateTime.Today
   dtpArchTime.Checked =false
end if
dtpQueryTime.value = System.DateTime.Now
if item.QueryTime <> System.DateTime.MinValue then
  try
     dtpQueryTime.value = item.QueryTime
  catch
   dtpQueryTime.value = System.DateTime.MinValue
  end try
end if
cmbIsUrgentData = New DataTable
cmbIsUrgentData.Columns.Add("name", GetType(System.String))
cmbIsUrgentData.Columns.Add("Value", GetType(System.Int32))
try
cmbIsUrgentDataRow = cmbIsUrgentData.NewRow
cmbIsUrgentDataRow("name") = "Да"
cmbIsUrgentDataRow("Value") = -1
cmbIsUrgentData.Rows.Add (cmbIsUrgentDataRow)
cmbIsUrgentDataRow = cmbIsUrgentData.NewRow
cmbIsUrgentDataRow("name") = "Нет"
cmbIsUrgentDataRow("Value") = 0
cmbIsUrgentData.Rows.Add (cmbIsUrgentDataRow)
cmbIsUrgent.DisplayMember = "name"
cmbIsUrgent.ValueMember = "Value"
cmbIsUrgent.DataSource = cmbIsUrgentData
 cmbIsUrgent.SelectedValue=CInt(Item.IsUrgent)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtRepeatTimes.text = item.RepeatTimes.toString()
txtRepeatInterval.text = item.RepeatInterval.toString()
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

If not txtTheSessionID.Tag.Equals(System.Guid.Empty) Then
  item.TheSessionID = Item.Application.FindRowObject("the_Session",txtTheSessionID.Tag)
Else
   item.TheSessionID = Nothing
End If
If not txtTheDevice.Tag.Equals(System.Guid.Empty) Then
  item.TheDevice = Item.Application.FindRowObject("TPLT_BDEVICES",txtTheDevice.Tag)
Else
   item.TheDevice = Nothing
End If
If not txtArchType.Tag.Equals(System.Guid.Empty) Then
  item.ArchType = Item.Application.FindRowObject("TPLD_PARAMTYPE",txtArchType.Tag)
Else
   item.ArchType = Nothing
End If
  if dtpArchTime.checked=false then
       item.ArchTime = System.DateTime.MinValue
  else 
  try
    item.ArchTime = dtpArchTime.value
  catch
    item.ArchTime = System.DateTime.MinValue
  end try
  end if
  try
    item.QueryTime = dtpQueryTime.value
  catch
    item.QueryTime = System.DateTime.MinValue
  end try
   item.IsUrgent = cmbIsUrgent.SelectedValue
item.RepeatTimes = val(txtRepeatTimes.text)
item.RepeatInterval = val(txtRepeatInterval.text)
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtTheSessionID.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = not txtTheDevice.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = not txtArchType.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = (dtpQueryTime.value <> System.DateTime.MinValue)
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
