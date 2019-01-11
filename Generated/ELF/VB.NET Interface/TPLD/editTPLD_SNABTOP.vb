
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics



''' <summary>
'''Контрол редактирования раздела Поставщик режим:
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Class editTPLD_SNABTOP
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
Friend WithEvents lblCNAME  as  System.Windows.Forms.Label
Friend WithEvents txtCNAME As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCADDRESS  as  System.Windows.Forms.Label
Friend WithEvents txtCADDRESS As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCFIO  as  System.Windows.Forms.Label
Friend WithEvents txtCFIO As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCPHONE  as  System.Windows.Forms.Label
Friend WithEvents txtCPHONE As LATIR2GuiManager.TouchTextBox
Friend WithEvents lblCREGION  as  System.Windows.Forms.Label
Friend WithEvents txtCREGION As LATIR2GuiManager.TouchTextBox

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
Me.lblCNAME = New System.Windows.Forms.Label
Me.txtCNAME = New LATIR2GuiManager.TouchTextBox
Me.lblCADDRESS = New System.Windows.Forms.Label
Me.txtCADDRESS = New LATIR2GuiManager.TouchTextBox
Me.lblCFIO = New System.Windows.Forms.Label
Me.txtCFIO = New LATIR2GuiManager.TouchTextBox
Me.lblCPHONE = New System.Windows.Forms.Label
Me.txtCPHONE = New LATIR2GuiManager.TouchTextBox
Me.lblCREGION = New System.Windows.Forms.Label
Me.txtCREGION = New LATIR2GuiManager.TouchTextBox

Me.lblCNAME.Location = New System.Drawing.Point(20,5)
Me.lblCNAME.name = "lblCNAME"
Me.lblCNAME.Size = New System.Drawing.Size(200, 20)
Me.lblCNAME.TabIndex = 1
Me.lblCNAME.Text = "Название"
Me.lblCNAME.ForeColor = System.Drawing.Color.Blue
Me.txtCNAME.Location = New System.Drawing.Point(20,27)
Me.txtCNAME.name = "txtCNAME"
Me.txtCNAME.Size = New System.Drawing.Size(200, 20)
Me.txtCNAME.TabIndex = 2
Me.txtCNAME.Text = "" 
Me.lblCADDRESS.Location = New System.Drawing.Point(20,52)
Me.lblCADDRESS.name = "lblCADDRESS"
Me.lblCADDRESS.Size = New System.Drawing.Size(200, 20)
Me.lblCADDRESS.TabIndex = 3
Me.lblCADDRESS.Text = "Адрес"
Me.lblCADDRESS.ForeColor = System.Drawing.Color.Blue
Me.txtCADDRESS.Location = New System.Drawing.Point(20,74)
Me.txtCADDRESS.name = "txtCADDRESS"
Me.txtCADDRESS.Size = New System.Drawing.Size(200, 20)
Me.txtCADDRESS.TabIndex = 4
Me.txtCADDRESS.Text = "" 
Me.lblCFIO.Location = New System.Drawing.Point(20,99)
Me.lblCFIO.name = "lblCFIO"
Me.lblCFIO.Size = New System.Drawing.Size(200, 20)
Me.lblCFIO.TabIndex = 5
Me.lblCFIO.Text = "Контактное лицо"
Me.lblCFIO.ForeColor = System.Drawing.Color.Blue
Me.txtCFIO.Location = New System.Drawing.Point(20,121)
Me.txtCFIO.name = "txtCFIO"
Me.txtCFIO.Size = New System.Drawing.Size(200, 20)
Me.txtCFIO.TabIndex = 6
Me.txtCFIO.Text = "" 
Me.lblCPHONE.Location = New System.Drawing.Point(20,146)
Me.lblCPHONE.name = "lblCPHONE"
Me.lblCPHONE.Size = New System.Drawing.Size(200, 20)
Me.lblCPHONE.TabIndex = 7
Me.lblCPHONE.Text = "Телефон"
Me.lblCPHONE.ForeColor = System.Drawing.Color.Blue
Me.txtCPHONE.Location = New System.Drawing.Point(20,168)
Me.txtCPHONE.name = "txtCPHONE"
Me.txtCPHONE.Size = New System.Drawing.Size(200, 20)
Me.txtCPHONE.TabIndex = 8
Me.txtCPHONE.Text = "" 
Me.lblCREGION.Location = New System.Drawing.Point(20,193)
Me.lblCREGION.name = "lblCREGION"
Me.lblCREGION.Size = New System.Drawing.Size(200, 20)
Me.lblCREGION.TabIndex = 9
Me.lblCREGION.Text = "Регион"
Me.lblCREGION.ForeColor = System.Drawing.Color.Blue
Me.txtCREGION.Location = New System.Drawing.Point(20,215)
Me.txtCREGION.name = "txtCREGION"
Me.txtCREGION.Size = New System.Drawing.Size(200, 20)
Me.txtCREGION.TabIndex = 10
Me.txtCREGION.Text = "" 
        Me.AutoScroll = True

CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCNAME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCNAME)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCADDRESS)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCADDRESS)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCFIO)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCFIO)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCPHONE)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCPHONE)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.lblCREGION)
CType(Me.HolderPanel.ClientArea, Panel).Controls.Add(Me.txtCREGION)
        Me.Controls.Add(Me.HolderPanel)
        Me.HolderPanel.ResumeLayout(False)
        Me.HolderPanel.PerformLayout()
        Me.name = "editTPLD_SNABTOP"
        Me.Size = New System.Drawing.Size(232, 120)
        Me.ResumeLayout (False)
    End Sub
#End Region

private sub txtCNAME_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCNAME.TextChanged
  Changing

end sub
private sub txtCADDRESS_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCADDRESS.TextChanged
  Changing

end sub
private sub txtCFIO_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCFIO.TextChanged
  Changing

end sub
private sub txtCPHONE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCPHONE.TextChanged
  Changing

end sub
private sub txtCREGION_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCREGION.TextChanged
  Changing

end sub

Public Item As TPLD.TPLD.TPLD_SNABTOP
Private mRowReadOnly As Boolean
Public GuiManager As LATIR2GuiManager.LATIRGuiManager


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal ri As LATIR2.Document.DocRow_Base,byval RowReadOnly as boolean  ) Implements LATIR2GUIManager.IRowEditor.Attach
        Item = Ctype(ri,TPLD.TPLD.TPLD_SNABTOP)
        GuiManager = gm
        mRowReadOnly = RowReadOnly
        If Item Is Nothing Then Exit Sub
        mOnInit = true

txtCNAME.text = item.CNAME
txtCADDRESS.text = item.CADDRESS
txtCFIO.text = item.CFIO
txtCPHONE.text = item.CPHONE
txtCREGION.text = item.CREGION
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

item.CNAME = txtCNAME.text
item.CADDRESS = txtCADDRESS.text
item.CFIO = txtCFIO.text
item.CPHONE = txtCPHONE.text
item.CREGION = txtCREGION.text
  end if
  mChanged = false
  raiseevent saved()
end sub
Public function IsOK() as boolean Implements LATIR2GUIManager.IRowEditor.IsOK
 Dim mIsOK as boolean
 mIsOK=true
 if mRowReadOnly  then return true

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
