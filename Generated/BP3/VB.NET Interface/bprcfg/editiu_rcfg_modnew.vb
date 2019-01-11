
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Модуль режим:new
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editiu_rcfg_modnew
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
Me.lblvisibleControl = New System.Windows.Forms.Label
Me.cmbvisibleControl = New System.Windows.Forms.ComboBox

Me.lblvisibleControl.Location = New System.Drawing.Point(20,5)
Me.lblvisibleControl.name = "lblvisibleControl"
Me.lblvisibleControl.Size = New System.Drawing.Size(200, 20)
Me.lblvisibleControl.TabIndex = 1
Me.lblvisibleControl.Text = "Управление видимостью"
Me.lblvisibleControl.ForeColor = System.Drawing.Color.Black
Me.cmbvisibleControl.Location = New System.Drawing.Point(20,27)
Me.cmbvisibleControl.name = "cmbvisibleControl"
Me.cmbvisibleControl.Size = New System.Drawing.Size(200,  20)
Me.cmbvisibleControl.TabIndex = 2
        Me.AutoScroll = True

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

   item.visibleControl = cmbvisibleControl.SelectedValue
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

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
