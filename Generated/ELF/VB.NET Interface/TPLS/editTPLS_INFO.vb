
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Схема подключения режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLS_INFO
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
Friend WithEvents lblNAME  as  System.Windows.Forms.Label
Friend WithEvents txtNAME As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblSCHEMA_IMAGEfile  as  System.Windows.Forms.Label
Friend WithEvents txtSCHEMA_IMAGEfile As LATIR2GuiManager.TouchTextBox

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
Me.lblNAME = New System.Windows.Forms.Label
Me.txtNAME = New LATIR2GuiManager.TouchTextBox
Me.lblSCHEMA_IMAGEfile = New System.Windows.Forms.Label
Me.txtSCHEMA_IMAGEfile = New LATIR2GuiManager.TouchTextBox

Me.lblNAME.Location = New System.Drawing.Point(20,5)
Me.lblNAME.name = "lblNAME"
Me.lblNAME.Size = New System.Drawing.Size(200, 20)
Me.lblNAME.TabIndex = 1
Me.lblNAME.Text = "Название"
Me.lblNAME.ForeColor = System.Drawing.Color.Black
Me.txtNAME.Location = New System.Drawing.Point(20,27)
Me.txtNAME.name = "txtNAME"
Me.txtNAME.Size = New System.Drawing.Size(200, 20)
Me.txtNAME.TabIndex = 2
Me.txtNAME.Text = "" 
Me.lblSCHEMA_IMAGEfile.Location = New System.Drawing.Point(20,52)
Me.lblSCHEMA_IMAGEfile.name = "lblSCHEMA_IMAGEfile"
Me.lblSCHEMA_IMAGEfile.Size = New System.Drawing.Size(200, 20)
Me.lblSCHEMA_IMAGEfile.TabIndex = 3
Me.lblSCHEMA_IMAGEfile.Text = "Изображение"
Me.lblSCHEMA_IMAGEfile.ForeColor = System.Drawing.Color.Blue
Me.txtSCHEMA_IMAGEfile.Location = New System.Drawing.Point(20,74)
Me.txtSCHEMA_IMAGEfile.name = "txtSCHEMA_IMAGEfile"
Me.txtSCHEMA_IMAGEfile.MultiLine = True
Me.txtSCHEMA_IMAGEfile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtSCHEMA_IMAGEfile.Size = New System.Drawing.Size(200, 50 + 20)
Me.txtSCHEMA_IMAGEfile.TabIndex = 4
Me.txtSCHEMA_IMAGEfile.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblNAME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtNAME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblSCHEMA_IMAGEfile)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtSCHEMA_IMAGEfile)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLS_INFO"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtNAME_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNAME.TextChanged
  Changing

end sub
private sub txtSCHEMA_IMAGEfile_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSCHEMA_IMAGEfile.TextChanged
  Changing

end sub

Public Item As TPLS.TPLS.TPLS_INFO
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLS.TPLS.TPLS_INFO)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtNAME.text = item.NAME
txtSCHEMA_IMAGEfile.text = item.SCHEMA_IMAGEfile
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

item.NAME = txtNAME.text
item.SCHEMA_IMAGEfile = txtSCHEMA_IMAGEfile.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

if mIsOK then mIsOK =( txtNAME.text <> "" ) 
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
