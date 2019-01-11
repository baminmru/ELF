


''' <summary>
'''Компонент, реализующий редактирование всего документа
''' </summary>
''' <remarks>
'''
''' </remarks>
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class Tabview
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
    Friend WithEvents tab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPSRV_INFO As TPSRVGUI.viewTPSRV_INFO
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPSRV_MODEMS As TPSRVGUI.viewTPSRV_MODEMS
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPSRV_PORTS As TPSRVGUI.viewTPSRV_PORTS
   
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tab = New System.Windows.Forms.TabControl
   TabPage1 = New System.Windows.Forms.TabPage
   ViewTPSRV_INFO = new viewTPSRV_INFO
   TabPage2 = New System.Windows.Forms.TabPage
   ViewTPSRV_MODEMS = new viewTPSRV_MODEMS
   TabPage3 = New System.Windows.Forms.TabPage
   ViewTPSRV_PORTS = new viewTPSRV_PORTS
        Me.tab.SuspendLayout()
   Me.TabPage1.SuspendLayout()
   Me.TabPage2.SuspendLayout()
   Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'tab
        '
        Me.tab.Location = New System.Drawing.Point(0, 0)
        Me.tab.name = "tab"
        Me.tab.Size = New System.Drawing.Size(528, 392)
        Me.tab.TabIndex = 0
        Me.tab.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add (Me.ViewTPSRV_INFO)
        Me.TabPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage1.name = "TabPage1"
        Me.TabPage1.Text = "Описание сервера"
        Me.TabPage1.Size = New System.Drawing.Size(520, 366)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.AutoScroll = True
        '
        'ViewTPSRV_INFO
        '
        Me.ViewTPSRV_INFO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPSRV_INFO.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPSRV_INFO.name = "ViewTPSRV_INFO"
        Me.ViewTPSRV_INFO.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPSRV_INFO.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add (Me.ViewTPSRV_MODEMS)
        Me.TabPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage2.name = "TabPage2"
        Me.TabPage2.Text = "Модемы"
        Me.TabPage2.Size = New System.Drawing.Size(520, 366)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.AutoScroll = True
        '
        'ViewTPSRV_MODEMS
        '
        Me.ViewTPSRV_MODEMS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPSRV_MODEMS.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPSRV_MODEMS.name = "ViewTPSRV_MODEMS"
        Me.ViewTPSRV_MODEMS.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPSRV_MODEMS.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add (Me.ViewTPSRV_PORTS)
        Me.TabPage3.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage3.name = "TabPage3"
        Me.TabPage3.Text = "Ком порты"
        Me.TabPage3.Size = New System.Drawing.Size(520, 366)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.AutoScroll = True
        '
        'ViewTPSRV_PORTS
        '
        Me.ViewTPSRV_PORTS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPSRV_PORTS.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPSRV_PORTS.name = "ViewTPSRV_PORTS"
        Me.ViewTPSRV_PORTS.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPSRV_PORTS.TabIndex = 0
   Me.tab.Controls.Add (Me.TabPage1)
   Me.tab.Controls.Add (Me.TabPage2)
   Me.tab.Controls.Add (Me.TabPage3)
        '
        'Tabview
        '
        Me.Controls.Add (Me.tab)
        Me.name = "TabView"
        Me.Size = New System.Drawing.Size(528, 392)
        Me.tab.ResumeLayout (False)
   Me.TabPage1.ResumeLayout (False)
   Me.TabPage2.ResumeLayout (False)
   Me.TabPage3.ResumeLayout (False)
        Me.ResumeLayout (False)

    End Sub

#End Region



''' <summary>
'''Редактируемый объект
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public item As TPSRV.TPSRV.Application
    Private mReadOnly as boolean



''' <summary>
'''Объект управления визуальными компонентами
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public GuiManager As LATIR2GuiManager.LATIRGuiManager



''' <summary>
'''Инициализация контрольного элемента
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Sub Attach(ByVal docItem As LATIR2.Document.Doc_Base, ByVal gm As LATIR2GuiManager.LATIRGuiManager, byval DocReadOnly as boolean  ) Implements LATIR2GUIManager.IViewPanel.Attach
        item = CType(docItem, TPSRV.TPSRV.Application)
        mReadOnly =DocReadOnly
        GuiManager = gm
        ViewTPSRV_INFO.Attach(item, GuiManager,DocReadOnly)
        ViewTPSRV_MODEMS.Attach(item, GuiManager,DocReadOnly)
        ViewTPSRV_PORTS.Attach(item, GuiManager,DocReadOnly)
    End Sub


''' <summary>
'''Сохранение всех изменений
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Function Save(ByVal Sielent As Boolean, ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Save
    Dim ok As Boolean
    ok = True
        ok = ok And ViewTPSRV_INFO.Save(Sielent, NoError)
        ok = ok And ViewTPSRV_MODEMS.Save(Sielent, NoError)
        ok = ok And ViewTPSRV_PORTS.Save(Sielent, NoError)
       Return ok
    End function


''' <summary>
'''Корректны ли измененные данные проверка после Verify
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Function IsOK() As Boolean Implements LATIR2GUIManager.IViewPanel.IsOK
    Dim ok As Boolean
    ok = True
        ok = ok And ViewTPSRV_INFO.IsOK()
        ok = ok And ViewTPSRV_MODEMS.IsOK()
        ok = ok And ViewTPSRV_PORTS.IsOK()
       Return ok
    End function


''' <summary>
'''Были ли изменения данных
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Function IsChanged() As Boolean Implements LATIR2GUIManager.IViewPanel.IsChanged
    Dim ok As Boolean
    if mReadOnly then return false
    ok = False
        ok = ok or ViewTPSRV_INFO.IsChanged()
        ok = ok or ViewTPSRV_MODEMS.IsChanged()
        ok = ok or ViewTPSRV_PORTS.IsChanged()
       Return ok
    End function


''' <summary>
'''Проверить корректность данных
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Function Verify(ByVal NoError As Boolean) As Boolean Implements LATIR2GUIManager.IViewPanel.Verify
    Dim ok As Boolean
    if mReadOnly then return true
    ok = True
        ok = ok And ViewTPSRV_INFO.Verify(NoError)
        ok = ok And ViewTPSRV_MODEMS.Verify(NoError)
        ok = ok And ViewTPSRV_PORTS.Verify(NoError)
       Return ok
    End function
    Private Sub TabPage1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Leave
        If ViewTPSRV_INFO.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage1.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPSRV_INFO.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Leave
        If ViewTPSRV_MODEMS.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage2.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPSRV_MODEMS.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Leave
        If ViewTPSRV_PORTS.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage3.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPSRV_PORTS.Save(True, False)
            End If
        End If
    End Sub
End Class
