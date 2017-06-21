
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics

  Public Class viewTPN_DEF
    Inherits System.Windows.Forms.UserControl
    Implements LATIR2GUIManager.IViewPanel 
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents EditTPN_DEF1 As TPNGUI.editTPN_DEF
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.EditTPN_DEF1 = New TPNGUI.editTPN_DEF
        Me.cmdSave = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'EditTPN_DEF1
        '
        Me.EditTPN_DEF1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditTPN_DEF1.Location = New System.Drawing.Point(0, 40)
        Me.EditTPN_DEF1.name = "EditTPN_DEF1"
        Me.EditTPN_DEF1.Size = New System.Drawing.Size(248, 128)
        Me.EditTPN_DEF1.TabIndex = 0
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(8, 8)
        Me.cmdSave.name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(104, 24)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "&Сохранить"
        '
        'view" & p.name & "
        '
        Me.Controls.Add (Me.cmdSave)
        Me.Controls.Add (Me.EditTPN_DEF1)
        Me.name = "viewTPN_DEF"
        Me.Size = New System.Drawing.Size(248, 168)
        Me.ResumeLayout (False)

    End Sub

#End Region
    Public item As TPN.TPN.Application
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager
    Private mReadOnly as boolean


''' <summary>
'''Инициализация
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager,byval ReadOnlyView as boolean) Implements LATIR2GUIManager.IViewPanel.Attach
        mReadOnly = ReadOnlyView
        item = CType(docItem, TPN.TPN.Application)
        GuiManager = gm
        If item.TPN_DEF.Count = 0 Then
            item.TPN_DEF.Add()
        End If
        EditTPN_DEF1.Attach(gm, item.TPN_DEF.Item(1),mReadOnly)
        cmdSave.Enabled = false
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        if not mReadOnly then
          if EditTPN_DEF1.IsOK() then
            EditTPN_DEF1.Save()
            item.TPN_DEF.Item(1).Save()
            cmdSave.Enabled = false
          Else
            MsgBox("Не все обязательные поля заполнены")
          End If
        Else
          MsgBox("Сохранение невозможно, документ в режиме просмотра")
        End If
    End Sub
    Private Sub EditTPN_DEF1_Changed() Handles EditTPN_DEF1.Changed
        cmdSave.Enabled = True
    End Sub
 Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save
   if not mReadOnly then
     EditTPN_DEF1.Save()
     item.TPN_DEF.Item(1).Save()
     cmdSave.Enabled = false
     Return true
   Else
     Return false
   End If
 End Function
 Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK
     Return EditTPN_DEF1.IsOK()
 End Function
 Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged
   if not mReadOnly then
     Return EditTPN_DEF1.IsChanged()
   else
     Return false
   end if
 End Function
 Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify
   if not mReadOnly then
     Return  EditTPN_DEF1.IsOK()
   else
     Return true
   end if
 End Function
End Class