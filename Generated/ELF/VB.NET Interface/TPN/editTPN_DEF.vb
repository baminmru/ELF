
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Описание режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPN_DEF
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
Friend WithEvents lblAddr  as  System.Windows.Forms.Label
Friend WithEvents txtAddr As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblThePhone  as  System.Windows.Forms.Label
Friend WithEvents txtThePhone As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblOrgUnit  as  System.Windows.Forms.Label
Friend WithEvents txtOrgUnit As LATIR2GuiManager.TouchTextBox
Friend WithEvents cmdOrgUnit As System.Windows.Forms.Button

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
Me.lblAddr = New System.Windows.Forms.Label
Me.txtAddr = New LATIR2GuiManager.TouchTextBox
Me.lblThePhone = New System.Windows.Forms.Label
Me.txtThePhone = New LATIR2GuiManager.TouchTextBox
Me.lblOrgUnit = New System.Windows.Forms.Label
Me.txtOrgUnit = New LATIR2GuiManager.TouchTextBox
Me.cmdOrgUnit = New System.Windows.Forms.Button

Me.lblAddr.Location = New System.Drawing.Point(20,5)
Me.lblAddr.name = "lblAddr"
Me.lblAddr.Size = New System.Drawing.Size(200, 20)
Me.lblAddr.TabIndex = 1
Me.lblAddr.Text = "Адрес"
Me.lblAddr.ForeColor = System.Drawing.Color.Blue
Me.txtAddr.Location = New System.Drawing.Point(20,27)
Me.txtAddr.name = "txtAddr"
Me.txtAddr.Size = New System.Drawing.Size(200, 20)
Me.txtAddr.TabIndex = 2
Me.txtAddr.Text = "" 
Me.lblThePhone.Location = New System.Drawing.Point(20,52)
Me.lblThePhone.name = "lblThePhone"
Me.lblThePhone.Size = New System.Drawing.Size(200, 20)
Me.lblThePhone.TabIndex = 3
Me.lblThePhone.Text = "Телефон"
Me.lblThePhone.ForeColor = System.Drawing.Color.Blue
Me.txtThePhone.Location = New System.Drawing.Point(20,74)
Me.txtThePhone.name = "txtThePhone"
Me.txtThePhone.Size = New System.Drawing.Size(200, 20)
Me.txtThePhone.TabIndex = 4
Me.txtThePhone.Text = "" 
Me.lblOrgUnit.Location = New System.Drawing.Point(20,99)
Me.lblOrgUnit.name = "lblOrgUnit"
Me.lblOrgUnit.Size = New System.Drawing.Size(200, 20)
Me.lblOrgUnit.TabIndex = 5
Me.lblOrgUnit.Text = "Филиал"
Me.lblOrgUnit.ForeColor = System.Drawing.Color.Black
Me.txtOrgUnit.Location = New System.Drawing.Point(20,121)
Me.txtOrgUnit.name = "txtOrgUnit"
Me.txtOrgUnit.ReadOnly = True
Me.txtOrgUnit.Size = New System.Drawing.Size(176, 20)
Me.txtOrgUnit.TabIndex = 6
Me.txtOrgUnit.Text = "" 
Me.cmdOrgUnit.Location = New System.Drawing.Point(198,121)
Me.cmdOrgUnit.name = "cmdOrgUnit"
Me.cmdOrgUnit.Size = New System.Drawing.Size(22, 20)
Me.cmdOrgUnit.TabIndex = 7
Me.cmdOrgUnit.Text = "..." 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblAddr)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtAddr)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblThePhone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtThePhone)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblOrgUnit)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtOrgUnit)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.cmdOrgUnit)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPN_DEF"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtAddr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddr.TextChanged
  Changing

end sub
private sub txtThePhone_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThePhone.TextChanged
  Changing

end sub
private sub txtOrgUnit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrgUnit.TextChanged
  Changing

end sub
private sub cmdOrgUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOrgUnit.Click
  try
Dim id As guid
Dim brief As String = string.Empty
Dim OK as boolean 
        If GuiManager.GetReferenceDialog("TPLD_F","",System.guid.Empty, id, brief) Then
          txtOrgUnit.Tag = id
          txtOrgUnit.text = brief
        End If
        catch ex as System.Exception
        Debug.Print(ex.Message +" >> " + ex.StackTrace)
        end try
end sub

Public Item As TPN.TPN.TPN_DEF
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPN.TPN.TPN_DEF)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtAddr.text = item.Addr
txtThePhone.text = item.ThePhone
If Not item.OrgUnit Is Nothing Then
  txtOrgUnit.Tag = item.OrgUnit.id
  txtOrgUnit.text = item.OrgUnit.brief
else
  txtOrgUnit.Tag = System.Guid.Empty 
  txtOrgUnit.text = "" 
End If
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

item.Addr = txtAddr.text
item.ThePhone = txtThePhone.text
If not txtOrgUnit.Tag.Equals(System.Guid.Empty) Then
  item.OrgUnit = Item.Application.FindRowObject("TPLD_F",txtOrgUnit.Tag)
Else
   item.OrgUnit = Nothing
End If
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK = not txtOrgUnit.Tag.Equals(System.Guid.Empty)
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
