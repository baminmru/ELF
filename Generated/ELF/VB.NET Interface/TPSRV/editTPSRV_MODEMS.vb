
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Модемы режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPSRV_MODEMS
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
Friend WithEvents lblPortNum  as  System.Windows.Forms.Label
Friend WithEvents txtPortNum As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblIsUsable  as  System.Windows.Forms.Label
Friend WithEvents cmbIsUsable As System.Windows.Forms.ComboBox
Friend cmbIsUsableDATA As DataTable
Friend cmbIsUsableDATAROW As DataRow
Friend WithEvents lblIsUsed  as  System.Windows.Forms.Label
Friend WithEvents cmbIsUsed As System.Windows.Forms.ComboBox
Friend cmbIsUsedDATA As DataTable
Friend cmbIsUsedDATAROW As DataRow
Friend WithEvents lblUsedUntil  as  System.Windows.Forms.Label
Friend WithEvents dtpUsedUntil As System.Windows.Forms.DateTimePicker

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
Me.lblPortNum = New System.Windows.Forms.Label
Me.txtPortNum = New LATIR2GuiManager.TouchTextBox
Me.lblIsUsable = New System.Windows.Forms.Label
Me.cmbIsUsable = New System.Windows.Forms.ComboBox
Me.lblIsUsed = New System.Windows.Forms.Label
Me.cmbIsUsed = New System.Windows.Forms.ComboBox
Me.lblUsedUntil = New System.Windows.Forms.Label
Me.dtpUsedUntil = New System.Windows.Forms.DateTimePicker

Me.lblPortNum.Location = New System.Drawing.Point(20,5)
Me.lblPortNum.name = "lblPortNum"
Me.lblPortNum.Size = New System.Drawing.Size(200, 20)
Me.lblPortNum.TabIndex = 1
Me.lblPortNum.Text = "Номер ком порта"
Me.lblPortNum.ForeColor = System.Drawing.Color.Black
Me.txtPortNum.Location = New System.Drawing.Point(20,27)
Me.txtPortNum.name = "txtPortNum"
Me.txtPortNum.Size = New System.Drawing.Size(200, 20)
Me.txtPortNum.TabIndex = 2
Me.txtPortNum.Text = "" 
Me.lblIsUsable.Location = New System.Drawing.Point(20,52)
Me.lblIsUsable.name = "lblIsUsable"
Me.lblIsUsable.Size = New System.Drawing.Size(200, 20)
Me.lblIsUsable.TabIndex = 3
Me.lblIsUsable.Text = "Может использоваться сервером"
Me.lblIsUsable.ForeColor = System.Drawing.Color.Black
Me.cmbIsUsable.Location = New System.Drawing.Point(20,74)
Me.cmbIsUsable.name = "cmbIsUsable"
Me.cmbIsUsable.Size = New System.Drawing.Size(200,  20)
Me.cmbIsUsable.TabIndex = 4
Me.lblIsUsed.Location = New System.Drawing.Point(20,99)
Me.lblIsUsed.name = "lblIsUsed"
Me.lblIsUsed.Size = New System.Drawing.Size(200, 20)
Me.lblIsUsed.TabIndex = 5
Me.lblIsUsed.Text = "Занят"
Me.lblIsUsed.ForeColor = System.Drawing.Color.Black
Me.cmbIsUsed.Location = New System.Drawing.Point(20,121)
Me.cmbIsUsed.name = "cmbIsUsed"
Me.cmbIsUsed.Size = New System.Drawing.Size(200,  20)
Me.cmbIsUsed.TabIndex = 6
Me.lblUsedUntil.Location = New System.Drawing.Point(20,146)
Me.lblUsedUntil.name = "lblUsedUntil"
Me.lblUsedUntil.Size = New System.Drawing.Size(200, 20)
Me.lblUsedUntil.TabIndex = 7
Me.lblUsedUntil.Text = "Занят до"
Me.lblUsedUntil.ForeColor = System.Drawing.Color.Blue
Me.dtpUsedUntil.Format = System.Windows.Forms.DateTimePickerFormat.Custom
Me.dtpUsedUntil.Location = New System.Drawing.Point(20,168)
Me.dtpUsedUntil.name = "dtpUsedUntil"
Me.dtpUsedUntil.Size = New System.Drawing.Size(200,  20)
Me.dtpUsedUntil.TabIndex =8
Me.dtpUsedUntil.CustomFormat = "dd/MM/yyyy HH:mm:ss"
Me.dtpUsedUntil.ShowCheckBox=True
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblPortNum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtPortNum)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIsUsable)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbIsUsable)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblIsUsed)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmbIsUsed)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblUsedUntil)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.dtpUsedUntil)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPSRV_MODEMS"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtPortNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPortNum.TextChanged
  Changing

end sub
private sub cmbIsUsable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsUsable.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub cmbIsUsed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIsUsed.SelectedIndexChanged
  try
  Changing

        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub
private sub dtpUsedUntil_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpUsedUntil.ValueChanged
  Changing 

end sub

Public Item As TPSRV.TPSRV.TPSRV_MODEMS
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPSRV.TPSRV.TPSRV_MODEMS)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtPortNum.text = item.PortNum
cmbIsUsableData = New DataTable
cmbIsUsableData.Columns.Add("name", GetType(System.String))
cmbIsUsableData.Columns.Add("Value", GetType(System.Int32))
try
cmbIsUsableDataRow = cmbIsUsableData.NewRow
cmbIsUsableDataRow("name") = "Да"
cmbIsUsableDataRow("Value") = -1
cmbIsUsableData.Rows.Add (cmbIsUsableDataRow)
cmbIsUsableDataRow = cmbIsUsableData.NewRow
cmbIsUsableDataRow("name") = "Нет"
cmbIsUsableDataRow("Value") = 0
cmbIsUsableData.Rows.Add (cmbIsUsableDataRow)
cmbIsUsable.DisplayMember = "name"
cmbIsUsable.ValueMember = "Value"
cmbIsUsable.DataSource = cmbIsUsableData
 cmbIsUsable.SelectedValue=CInt(Item.IsUsable)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
cmbIsUsedData = New DataTable
cmbIsUsedData.Columns.Add("name", GetType(System.String))
cmbIsUsedData.Columns.Add("Value", GetType(System.Int32))
try
cmbIsUsedDataRow = cmbIsUsedData.NewRow
cmbIsUsedDataRow("name") = "Да"
cmbIsUsedDataRow("Value") = -1
cmbIsUsedData.Rows.Add (cmbIsUsedDataRow)
cmbIsUsedDataRow = cmbIsUsedData.NewRow
cmbIsUsedDataRow("name") = "Нет"
cmbIsUsedDataRow("Value") = 0
cmbIsUsedData.Rows.Add (cmbIsUsedDataRow)
cmbIsUsed.DisplayMember = "name"
cmbIsUsed.ValueMember = "Value"
cmbIsUsed.DataSource = cmbIsUsedData
 cmbIsUsed.SelectedValue=CInt(Item.IsUsed)
        catch ex as System.Exception
             Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
dtpUsedUntil.value = System.DateTime.Now
if item.UsedUntil <> System.DateTime.MinValue then
  try
     dtpUsedUntil.value = item.UsedUntil
  catch
   dtpUsedUntil.value = System.DateTime.MinValue
  end try
else
   dtpUsedUntil.value = System.DateTime.Today
   dtpUsedUntil.Checked =false
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

item.PortNum = txtPortNum.text
   item.IsUsable = cmbIsUsable.SelectedValue
   item.IsUsed = cmbIsUsed.SelectedValue
  if dtpUsedUntil.checked=false then
       item.UsedUntil = System.DateTime.MinValue
  else 
  try
    item.UsedUntil = dtpUsedUntil.value
  catch
    item.UsedUntil = System.DateTime.MinValue
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

if mIsOK then mIsOK =( txtPortNum.text <> "" ) 
if mIsOK then mIsOK =(cmbIsUsable.SelectedIndex >=0)
if mIsOK then mIsOK =(cmbIsUsed.SelectedIndex >=0)
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
