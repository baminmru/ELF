
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Результат обработки режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPQ_result
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
Friend WithEvents lblTextResult  as  System.Windows.Forms.Label
Friend WithEvents txtTextResult As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblMomentArch  as  System.Windows.Forms.Label
Friend WithEvents txtMomentArch As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdMomentArch As System.Windows.Forms.Button
Friend WithEvents cmdMomentArchClear As System.Windows.Forms.Button
Friend WithEvents lblHourArch  as  System.Windows.Forms.Label
Friend WithEvents txtHourArch As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdHourArch As System.Windows.Forms.Button
Friend WithEvents cmdHourArchClear As System.Windows.Forms.Button
Friend WithEvents lblDayArch  as  System.Windows.Forms.Label
Friend WithEvents txtDayArch As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdDayArch As System.Windows.Forms.Button
Friend WithEvents cmdDayArchClear As System.Windows.Forms.Button
Friend WithEvents lblTotalArch  as  System.Windows.Forms.Label
Friend WithEvents txtTotalArch As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdTotalArch As System.Windows.Forms.Button
Friend WithEvents cmdTotalArchClear As System.Windows.Forms.Button
Friend WithEvents lblIsError  as  System.Windows.Forms.Label
Friend WithEvents cmbIsError As System.Windows.Forms.ComboBox
Friend cmbIsErrorDATA As DataTable
Friend cmbIsErrorDATAROW As DataRow
Friend WithEvents lblLogMessage  as  System.Windows.Forms.Label
Friend WithEvents txtLogMessage As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblStartTime  as  System.Windows.Forms.Label
Friend WithEvents dtpStartTime As System.Windows.Forms.DateTimePicker
Friend WithEvents lblEndTime  as  System.Windows.Forms.Label
Friend WithEvents dtpEndTime As System.Windows.Forms.DateTimePicker

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
Me.lblTextResult = New System.Windows.Forms.Label
Me.txtTextResult = New LATIR2GuiManager.TouchTextBox
Me.lblMomentArch = New System.Windows.Forms.Label
Me.txtMomentArch = New LATIR2GuiManager.TouchTextBox
Me.cmdMomentArch = New System.Windows.Forms.Button
Me.cmdMomentArchClear = New System.Windows.Forms.Button
Me.lblHourArch = New System.Windows.Forms.Label
Me.txtHourArch = New LATIR2GuiManager.TouchTextBox
Me.cmdHourArch = New System.Windows.Forms.Button
Me.cmdHourArchClear = New System.Windows.Forms.Button
Me.lblDayArch = New System.Windows.Forms.Label
Me.txtDayArch = New LATIR2GuiManager.TouchTextBox
Me.cmdDayArch = New System.Windows.Forms.Button
Me.cmdDayArchClear = New System.Windows.Forms.Button
Me.lblTotalArch = New System.Windows.Forms.Label
Me.txtTotalArch = New LATIR2GuiManager.TouchTextBox
Me.cmdTotalArch = New System.Windows.Forms.Button
Me.cmdTotalArchClear = New System.Windows.Forms.Button
Me.lblIsError = New System.Windows.Forms.Label
Me.cmbIsError = New System.Windows.Forms.ComboBox
Me.lblLogMessage = New System.Windows.Forms.Label
Me.txtLogMessage = New LATIR2GuiManager.TouchTextBox
Me.lblStartTime = New System.Windows.Forms.Label
Me.dtpStartTime = New System.Windows.Forms.DateTimePicker
Me.lblEndTime = New System.Windows.Forms.Label
Me.dtpEndTime = New System.Windows.Forms.DateTimePicker

Me.lblTextResult.Location = New System.Drawing.Point(20,5)
Me.lblTextResult.name = "lblTextResult"
Me.lblTextResult.Size = New System.Drawing.Size(200, 20)
Me.lblTextResult.TabIndex = 1
Me.lblTextResult.Text = "Текстовый результат"
Me.lblTextResult.ForeColor = System.Drawing.Color.Black
Me.txtTextResult.Location = New System.Drawing.Point(20,27)
Me.txtTextResult.name = "txtTextResult"
Me.txtTextResult.Size = New System.Drawing.Size(200, 20)
Me.txtTextResult.TabIndex = 2
Me.txtTextResult.Text = "" 
Me.lblMomentArch.Location = New System.Drawing.Point(20,52)
Me.lblMomentArch.name = "lblMomentArch"
Me.lblMomentArch.Size = New System.Drawing.Size(200, 20)
Me.lblMomentArch.TabIndex = 3
Me.lblMomentArch.Text = "Запись мгновенного архива"
Me.lblMomentArch.ForeColor = System.Drawing.Color.Blue
Me.txtMomentArch.Location = New System.Drawing.Point(20,74)
Me.txtMomentArch.name = "txtMomentArch"
Me.txtMomentArch.ReadOnly = True
Me.txtMomentArch.Size = New System.Drawing.Size(155, 20)
Me.txtMomentArch.TabIndex = 4
Me.txtMomentArch.Text = "" 
Me.cmdMomentArch.Location = New System.Drawing.Point(176,74)
Me.cmdMomentArch.name = "cmdMomentArch"
Me.cmdMomentArch.Size = New System.Drawing.Size(22, 20)
Me.cmdMomentArch.TabIndex = 5
Me.cmdMomentArch.Text = "..." 
Me.cmdMomentArchClear.Location = New System.Drawing.Point(198,74)
Me.cmdMomentArchClear.name = "cmdMomentArchClear"
Me.cmdMomentArchClear.Size = New System.Drawing.Size(22, 20)
Me.cmdMomentArchClear.TabIndex = 6
Me.cmdMomentArchClear.Text = "X" 
Me.lblHourArch.Location = New System.Drawing.Point(20,99)
Me.lblHourArch.name = "lblHourArch"
Me.lblHourArch.Size = New System.Drawing.Size(200, 20)
Me.lblHourArch.TabIndex = 7
Me.lblHourArch.Text = "Запись часового архива"
Me.lblHourArch.ForeColor = System.Drawing.Color.Blue
Me.txtHourArch.Location = New System.Drawing.Point(20,121)
Me.txtHourArch.name = "txtHourArch"
Me.txtHourArch.ReadOnly = True
Me.txtHourArch.Size = New System.Drawing.Size(155, 20)
Me.txtHourArch.TabIndex = 8
Me.txtHourArch.Text = "" 
Me.cmdHourArch.Location = New System.Drawing.Point(176,121)
Me.cmdHourArch.name = "cmdHourArch"
Me.cmdHourArch.Size = New System.Drawing.Size(22, 20)
Me.cmdHourArch.TabIndex = 9
Me.cmdHourArch.Text = "..." 
Me.cmdHourArchClear.Location = New System.Drawing.Point(198,121)
Me.cmdHourArchClear.name = "cmdHourArchClear"
Me.cmdHourArchClear.Size = New System.Drawing.Size(22, 20)
Me.cmdHourArchClear.TabIndex = 10
Me.cmdHourArchClear.Text = "X" 
Me.lblDayArch.Location = New System.Drawing.Point(20,146)
Me.lblDayArch.name = "lblDayArch"
Me.lblDayArch.Size = New System.Drawing.Size(200, 20)
Me.lblDayArch.TabIndex = 11
Me.lblDayArch.Text = "Запись суточного архива"
Me.lblDayArch.ForeColor = System.Drawing.Color.Blue
Me.txtDayArch.Location = New System.Drawing.Point(20,168)
Me.txtDayArch.name = "txtDayArch"
Me.txtDayArch.ReadOnly = True
Me.txtDayArch.Size = New System.Drawing.Size(155, 20)
Me.txtDayArch.TabIndex = 12
Me.txtDayArch.Text = "" 
Me.cmdDayArch.Location = New System.Drawing.Point(176,168)
Me.cmdDayArch.name = "cmdDayArch"
Me.cmdDayArch.Size = New System.Drawing.Size(22, 20)
Me.cmdDayArch.TabIndex = 13
Me.cmdDayArch.Text = "..." 
Me.cmdDayArchClear.Location = New System.Drawing.Point(198,168)
Me.cmdDayArchClear.name = "cmdDayArchClear"
Me.cmdDayArchClear.Size = New System.Drawing.Size(22, 20)
Me.cmdDayArchClear.TabIndex = 14
Me.cmdDayArchClear.Text = "X" 
Me.lblTotalArch.Location = New System.Drawing.Point(20,193)
Me.lblTotalArch.name = "lblTotalArch"
Me.lblTotalArch.Size = New System.Drawing.Size(200, 20)
Me.lblTotalArch.TabIndex = 15
Me.lblTotalArch.Text = "Запись итогового архива"
Me.lblTotalArch.ForeColor = System.Drawing.Color.Blue
Me.txtTotalArch.Location = New System.Drawing.Point(20,215)
Me.txtTotalArch.name = "txtTotalArch"
Me.txtTotalArch.ReadOnly = True
Me.txtTotalArch.Size = New System.Drawing.Size(155, 20)
Me.txtTotalArch.TabIndex = 16
Me.txtTotalArch.Text = "" 
Me.cmdTotalArch.Location = New System.Drawing.Point(176,215)
Me.cmdTotalArch.name = "cmdTotalArch"
Me.cmdTotalArch.Size = New System.Drawing.Size(22, 20)
Me.cmdTotalArch.TabIndex = 17
Me.cmdTotalArch.Text = "..." 
Me.cmdTotalArchClear.Location = New System.Drawing.Point(198,215)
Me.cmdTotalArchClear.name = "cmdTotalArchClear"
Me.cmdTotalArchClear.Size = New System.Drawing.Size(22, 20)
Me.cmdTotalArchClear.TabIndex = 18
Me.cmdTotalArchClear.Text = "X" 
Me.lblIsError.Location = New System.Drawing.Point(20,240)
Me.lblIsError.name = "lblIsError"
Me.lblIsError.Size = New System.Drawing.Size(200, 20)
Me.lblIsError.TabIndex = 19
Me.lblIsError.Text = "Обработан с ошибкой"
Me.lblIsError.ForeColor = System.Drawing.Color.Blue
Me.cmbIsError.Location = New System.Drawing.Point(20,262)
Me.cmbIsError.name = "cmbIsError"
Me.cmbIsError.Size = New System.Drawing.Size(200,  20)
Me.cmbIsError.TabIndex = 20
Me.lblLogMessage.Location = New System.Drawing.Point(20,287)
Me.lblLogMessage.name = "lblLogMessage"
Me.lblLogMessage.Size = New System.Drawing.Size(200, 20)
Me.lblLogMessage.TabIndex = 21
Me.lblLogMessage.Text = "Протокол"
Me.lblLogMessage.ForeColor = System.Drawing.Color.Blue
Me.txtLogMessage.Location = New System.Drawing.Point(20,309)
Me.txtLogMessage.name = "txtLogMessage"
Me.txtLogMessage.MultiLine = True
Me.txtLogMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtLogMessage.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtLogMessage.TabIndex = 22
Me.txtLogMessage.Text = "" 
Me.lblStartTime.Location = New System.Drawing.Point(20,379)
Me.lblStartTime.name = "lblStartTime"
Me.lblStartTime.Size = New System.Drawing.Size(200, 20)
Me.lblStartTime.TabIndex = 23
Me.lblStartTime.Text = "Время начала обработки"
Me.lblStartTime.ForeColor = System.Drawing.Color.Blue
Me.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpStartTime.Location = New System.Drawing.Point(20,401)
Me.dtpStartTime.name = "dtpStartTime"
Me.dtpStartTime.Size = New System.Drawing.Size(200,  20)
Me.dtpStartTime.TabIndex =24
Me.dtpStartTime.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpStartTime.ShowCheckBox=True
Me.lblEndTime.Location = New System.Drawing.Point(230,5)
Me.lblEndTime.name = "lblEndTime"
Me.lblEndTime.Size = New System.Drawing.Size(200, 20)
Me.lblEndTime.TabIndex = 25
Me.lblEndTime.Text = "Время завершения обработки"
Me.lblEndTime.ForeColor = System.Drawing.Color.Blue
Me.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpEndTime.Location = New System.Drawing.Point(230,27)
Me.dtpEndTime.name = "dtpEndTime"
Me.dtpEndTime.Size = New System.Drawing.Size(200,  20)
Me.dtpEndTime.TabIndex =26
Me.dtpEndTime.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpEndTime.ShowCheckBox=True
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTextResult)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTextResult)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblMomentArch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtMomentArch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdMomentArch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdMomentArchClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblHourArch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtHourArch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdHourArch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdHourArchClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblDayArch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtDayArch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdDayArch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdDayArchClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblTotalArch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtTotalArch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTotalArch)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdTotalArchClear)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIsError)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbIsError)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblLogMessage)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtLogMessage)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblStartTime)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpStartTime)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblEndTime)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpEndTime)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPQ_result"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtTextResult_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTextResult.TextChanged
  Changing

end sub
private sub txtMomentArch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMomentArch.TextChanged
  Changing

end sub
private sub cmdMomentArch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMomentArch.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLC_M","",System.guid.Empty, id, brief) Then
          txtMomentArch.Tag = id
          txtMomentArch.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdMomentArchClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMomentArchClear.Click
  try
          txtMomentArch.Tag = Guid.Empty
          txtMomentArch.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtHourArch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHourArch.TextChanged
  Changing

end sub
private sub cmdHourArch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHourArch.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLC_H","",System.guid.Empty, id, brief) Then
          txtHourArch.Tag = id
          txtHourArch.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdHourArchClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHourArchClear.Click
  try
          txtHourArch.Tag = Guid.Empty
          txtHourArch.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtDayArch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDayArch.TextChanged
  Changing

end sub
private sub cmdDayArch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDayArch.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLC_D","",System.guid.Empty, id, brief) Then
          txtDayArch.Tag = id
          txtDayArch.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdDayArchClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDayArchClear.Click
  try
          txtDayArch.Tag = Guid.Empty
          txtDayArch.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtTotalArch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalArch.TextChanged
  Changing

end sub
private sub cmdTotalArch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTotalArch.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLC_T","",System.guid.Empty, id, brief) Then
          txtTotalArch.Tag = id
          txtTotalArch.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmdTotalArchClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTotalArchClear.Click
  try
          txtTotalArch.Tag = Guid.Empty
          txtTotalArch.text = ""
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbIsError_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsError.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub txtLogMessage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLogMessage.TextChanged
  Changing

end sub
private sub dtpStartTime_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpStartTime.ValueChanged
  Changing 

end sub
private sub dtpEndTime_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEndTime.ValueChanged
  Changing 

end sub

Public Item As TPQ.TPQ.TPQ_result
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPQ.TPQ.TPQ_result)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtTextResult.text = item.TextResult
If Not item.MomentArch Is Nothing Then
  txtMomentArch.Tag = item.MomentArch.id
  txtMomentArch.text = item.MomentArch.brief
else
  txtMomentArch.Tag = System.Guid.Empty 
  txtMomentArch.text = "" 
End If
If Not item.HourArch Is Nothing Then
  txtHourArch.Tag = item.HourArch.id
  txtHourArch.text = item.HourArch.brief
else
  txtHourArch.Tag = System.Guid.Empty 
  txtHourArch.text = "" 
End If
If Not item.DayArch Is Nothing Then
  txtDayArch.Tag = item.DayArch.id
  txtDayArch.text = item.DayArch.brief
else
  txtDayArch.Tag = System.Guid.Empty 
  txtDayArch.text = "" 
End If
If Not item.TotalArch Is Nothing Then
  txtTotalArch.Tag = item.TotalArch.id
  txtTotalArch.text = item.TotalArch.brief
else
  txtTotalArch.Tag = System.Guid.Empty 
  txtTotalArch.text = "" 
End If
cmbIsErrorData = New DataTable
cmbIsErrorData.Columns.Add("name", GetType(System.String))
cmbIsErrorData.Columns.Add("Value", GetType(System.Int32))
try
cmbIsErrorDataRow = cmbIsErrorData.NewRow
cmbIsErrorDataRow("name") = "Да"
cmbIsErrorDataRow("Value") = -1
cmbIsErrorData.Rows.Add (cmbIsErrorDataRow)
cmbIsErrorDataRow = cmbIsErrorData.NewRow
cmbIsErrorDataRow("name") = "Нет"
cmbIsErrorDataRow("Value") = 0
cmbIsErrorData.Rows.Add (cmbIsErrorDataRow)
cmbIsError.DisplayMember = "name"
cmbIsError.ValueMember = "Value"
cmbIsError.DataSource = cmbIsErrorData
 cmbIsError.SelectedValue=CInt(Item.IsError)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
txtLogMessage.text = item.LogMessage
dtpStartTime.value = System.DateTime.Now
if item.StartTime <> System.DateTime.MinValue then
  try
     dtpStartTime.value = item.StartTime
  catch
   dtpStartTime.value = System.DateTime.MinValue
  end try
else
   dtpStartTime.value = System.DateTime.Today
   dtpStartTime.Checked =false
end if
dtpEndTime.value = System.DateTime.Now
if item.EndTime <> System.DateTime.MinValue then
  try
     dtpEndTime.value = item.EndTime
  catch
   dtpEndTime.value = System.DateTime.MinValue
  end try
else
   dtpEndTime.value = System.DateTime.Today
   dtpEndTime.Checked =false
end if
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

item.TextResult = txtTextResult.text
If not txtMomentArch.Tag.Equals(System.Guid.Empty) Then
  item.MomentArch = Item.Application.FindRowObject("TPLC_M",txtMomentArch.Tag)
Else
   item.MomentArch = Nothing
End If
If not txtHourArch.Tag.Equals(System.Guid.Empty) Then
  item.HourArch = Item.Application.FindRowObject("TPLC_H",txtHourArch.Tag)
Else
   item.HourArch = Nothing
End If
If not txtDayArch.Tag.Equals(System.Guid.Empty) Then
  item.DayArch = Item.Application.FindRowObject("TPLC_D",txtDayArch.Tag)
Else
   item.DayArch = Nothing
End If
If not txtTotalArch.Tag.Equals(System.Guid.Empty) Then
  item.TotalArch = Item.Application.FindRowObject("TPLC_T",txtTotalArch.Tag)
Else
   item.TotalArch = Nothing
End If
   item.IsError = cmbIsError.SelectedValue
item.LogMessage = txtLogMessage.text
  if dtpStartTime.checked=false then
       item.StartTime = System.DateTime.MinValue
  else 
  try
    item.StartTime = dtpStartTime.value
  catch
    item.StartTime = System.DateTime.MinValue
  end try
  end if
  if dtpEndTime.checked=false then
       item.EndTime = System.DateTime.MinValue
  else 
  try
    item.EndTime = dtpEndTime.value
  catch
    item.EndTime = System.DateTime.MinValue
  end try
  end if
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtTextResult.text <> "" ) 
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
