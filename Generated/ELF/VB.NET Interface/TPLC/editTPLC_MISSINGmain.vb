
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Пропущенные архивы режим:main
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLC_MISSINGmain
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
Friend WithEvents lblAType  as  System.Windows.Forms.Label
Friend WithEvents txtAType As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdAType As System.Windows.Forms.Button
Friend WithEvents lblADate  as  System.Windows.Forms.Label
Friend WithEvents dtpADate As System.Windows.Forms.DateTimePicker
Friend WithEvents lblQueryCount  as  System.Windows.Forms.Label
Friend WithEvents txtQueryCount As LATIR2GuiManager.TouchTextBox

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
Me.lblAType = New System.Windows.Forms.Label
Me.txtAType = New LATIR2GuiManager.TouchTextBox
Me.cmdAType = New System.Windows.Forms.Button
Me.lblADate = New System.Windows.Forms.Label
Me.dtpADate = New System.Windows.Forms.DateTimePicker
Me.lblQueryCount = New System.Windows.Forms.Label
Me.txtQueryCount = New LATIR2GuiManager.TouchTextBox

Me.lblAType.Location = New System.Drawing.Point(20,5)
Me.lblAType.name = "lblAType"
Me.lblAType.Size = New System.Drawing.Size(200, 20)
Me.lblAType.TabIndex = 1
Me.lblAType.Text = "Тип архива"
Me.lblAType.ForeColor = System.Drawing.Color.Black
Me.txtAType.Location = New System.Drawing.Point(20,27)
Me.txtAType.name = "txtAType"
Me.txtAType.ReadOnly = True
Me.txtAType.Size = New System.Drawing.Size(176, 20)
Me.txtAType.TabIndex = 2
Me.txtAType.Text = "" 
Me.cmdAType.Location = New System.Drawing.Point(198,27)
Me.cmdAType.name = "cmdAType"
Me.cmdAType.Size = New System.Drawing.Size(22, 20)
Me.cmdAType.TabIndex = 3
Me.cmdAType.Text = "..." 
Me.lblADate.Location = New System.Drawing.Point(20,52)
Me.lblADate.name = "lblADate"
Me.lblADate.Size = New System.Drawing.Size(200, 20)
Me.lblADate.TabIndex = 4
Me.lblADate.Text = "Дата архива"
Me.lblADate.ForeColor = System.Drawing.Color.Black
Me.dtpADate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpADate.Location = New System.Drawing.Point(20,74)
Me.dtpADate.name = "dtpADate"
Me.dtpADate.Size = New System.Drawing.Size(200,  20)
Me.dtpADate.TabIndex =5
Me.dtpADate.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpADate.ShowCheckBox=False
Me.lblQueryCount.Location = New System.Drawing.Point(20,99)
Me.lblQueryCount.name = "lblQueryCount"
Me.lblQueryCount.Size = New System.Drawing.Size(200, 20)
Me.lblQueryCount.TabIndex = 6
Me.lblQueryCount.Text = "Количество попыток  опроса"
Me.lblQueryCount.ForeColor = System.Drawing.Color.Blue
Me.txtQueryCount.Location = New System.Drawing.Point(20,121)
Me.txtQueryCount.name = "txtQueryCount"
Me.txtQueryCount.MultiLine = false
Me.txtQueryCount.Size = New System.Drawing.Size(200,  20)
Me.txtQueryCount.TabIndex = 7
Me.txtQueryCount.Text = "" 
Me.txtQueryCount.MaxLength = 15
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtAType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdAType)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblADate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpADate)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblQueryCount)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtQueryCount)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLC_MISSING"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtAType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAType.TextChanged
  Changing

end sub
private sub cmdAType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAType.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLD_PARAMTYPE","",System.guid.Empty, id, brief) Then
          txtAType.Tag = id
          txtAType.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub dtpADate_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpADate.ValueChanged
  Changing 

end sub
        Private Sub txtQueryCount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQueryCount.Validating
        If txtQueryCount.Text <> "" Then
            try
            If Not IsNumeric(txtQueryCount.Text) Then
                e.Cancel = True
                MsgBox("Ожидалось число", vbOKOnly + vbExclamation, "Внимание")
            ElseIf Val(txtQueryCount.Text) < -2000000000 Or Val(txtQueryCount.Text) > 2000000000 Then
                e.Cancel = True
                MsgBox("Значение вне допустимого диапазона", vbOKOnly + vbExclamation, "Внимание")
            End If
        catch ex as System.Exception
            Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
        End If
    End Sub
private sub txtQueryCount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQueryCount.TextChanged
  Changing

end sub

Public Item As TPLC.TPLC.TPLC_MISSING
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLC.TPLC.TPLC_MISSING)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

If Not item.AType Is Nothing Then
  txtAType.Tag = item.AType.id
  txtAType.text = item.AType.brief
else
  txtAType.Tag = System.Guid.Empty 
  txtAType.text = "" 
End If
dtpADate.value = System.DateTime.Now
if item.ADate <> System.DateTime.MinValue then
  try
     dtpADate.value = item.ADate
  catch
   dtpADate.value = System.DateTime.MinValue
  end try
end if
txtQueryCount.text = item.QueryCount.toString()
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

If not txtAType.Tag.Equals(System.Guid.Empty) Then
  item.AType = Item.Application.FindRowObject("TPLD_PARAMTYPE",txtAType.Tag)
Else
   item.AType = Nothing
End If
  try
    item.ADate = dtpADate.value
  catch
    item.ADate = System.DateTime.MinValue
  end try
item.QueryCount = val(txtQueryCount.text)
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtAType.Tag.Equals(System.Guid.Empty)
if mIsOK then mIsOK = (dtpADate.value <> System.DateTime.MinValue)
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
