


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
    Friend WithEvents ViewTPLT_BDEVICES As TPLTGUI.viewTPLT_BDEVICES
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLT_CONNECT As TPLTGUI.viewTPLT_CONNECT
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLT_CONTRACT As TPLTGUI.viewTPLT_CONTRACT
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLT_PLANCALL As TPLTGUI.viewTPLT_PLANCALL
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLT_VALUEBOUNDS As TPLTGUI.viewTPLT_VALUEBOUNDS
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLT_REPORTS As TPLTGUI.viewTPLT_REPORTS
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLT_MASK As TPLTGUI.viewTPLT_MASK
   
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tab = New System.Windows.Forms.TabControl
   TabPage1 = New System.Windows.Forms.TabPage
   ViewTPLT_BDEVICES = new viewTPLT_BDEVICES
   TabPage2 = New System.Windows.Forms.TabPage
   ViewTPLT_CONNECT = new viewTPLT_CONNECT
   TabPage3 = New System.Windows.Forms.TabPage
   ViewTPLT_CONTRACT = new viewTPLT_CONTRACT
   TabPage4 = New System.Windows.Forms.TabPage
   ViewTPLT_PLANCALL = new viewTPLT_PLANCALL
   TabPage5 = New System.Windows.Forms.TabPage
   ViewTPLT_VALUEBOUNDS = new viewTPLT_VALUEBOUNDS
   TabPage6 = New System.Windows.Forms.TabPage
   ViewTPLT_REPORTS = new viewTPLT_REPORTS
   TabPage7 = New System.Windows.Forms.TabPage
   ViewTPLT_MASK = new viewTPLT_MASK
        Me.tab.SuspendLayout()
   Me.TabPage1.SuspendLayout()
   Me.TabPage2.SuspendLayout()
   Me.TabPage3.SuspendLayout()
   Me.TabPage4.SuspendLayout()
   Me.TabPage5.SuspendLayout()
   Me.TabPage6.SuspendLayout()
   Me.TabPage7.SuspendLayout()
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
        Me.TabPage1.Controls.Add (Me.ViewTPLT_BDEVICES)
        Me.TabPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage1.name = "TabPage1"
        Me.TabPage1.Text = "Описание"
        Me.TabPage1.Size = New System.Drawing.Size(520, 366)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.AutoScroll = True
        '
        'ViewTPLT_BDEVICES
        '
        Me.ViewTPLT_BDEVICES.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLT_BDEVICES.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLT_BDEVICES.name = "ViewTPLT_BDEVICES"
        Me.ViewTPLT_BDEVICES.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLT_BDEVICES.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add (Me.ViewTPLT_CONNECT)
        Me.TabPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage2.name = "TabPage2"
        Me.TabPage2.Text = "Параметры соединения"
        Me.TabPage2.Size = New System.Drawing.Size(520, 366)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.AutoScroll = True
        '
        'ViewTPLT_CONNECT
        '
        Me.ViewTPLT_CONNECT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLT_CONNECT.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLT_CONNECT.name = "ViewTPLT_CONNECT"
        Me.ViewTPLT_CONNECT.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLT_CONNECT.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add (Me.ViewTPLT_CONTRACT)
        Me.TabPage3.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage3.name = "TabPage3"
        Me.TabPage3.Text = "Договорные установки"
        Me.TabPage3.Size = New System.Drawing.Size(520, 366)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.AutoScroll = True
        '
        'ViewTPLT_CONTRACT
        '
        Me.ViewTPLT_CONTRACT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLT_CONTRACT.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLT_CONTRACT.name = "ViewTPLT_CONTRACT"
        Me.ViewTPLT_CONTRACT.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLT_CONTRACT.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add (Me.ViewTPLT_PLANCALL)
        Me.TabPage4.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage4.name = "TabPage4"
        Me.TabPage4.Text = "План опроса устройств"
        Me.TabPage4.Size = New System.Drawing.Size(520, 366)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.AutoScroll = True
        '
        'ViewTPLT_PLANCALL
        '
        Me.ViewTPLT_PLANCALL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLT_PLANCALL.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLT_PLANCALL.name = "ViewTPLT_PLANCALL"
        Me.ViewTPLT_PLANCALL.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLT_PLANCALL.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add (Me.ViewTPLT_VALUEBOUNDS)
        Me.TabPage5.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage5.name = "TabPage5"
        Me.TabPage5.Text = "Граничные значения"
        Me.TabPage5.Size = New System.Drawing.Size(520, 366)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.AutoScroll = True
        '
        'ViewTPLT_VALUEBOUNDS
        '
        Me.ViewTPLT_VALUEBOUNDS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLT_VALUEBOUNDS.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLT_VALUEBOUNDS.name = "ViewTPLT_VALUEBOUNDS"
        Me.ViewTPLT_VALUEBOUNDS.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLT_VALUEBOUNDS.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add (Me.ViewTPLT_REPORTS)
        Me.TabPage6.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage6.name = "TabPage6"
        Me.TabPage6.Text = "Отчеты"
        Me.TabPage6.Size = New System.Drawing.Size(520, 366)
        Me.TabPage6.TabIndex = 0
        Me.TabPage6.AutoScroll = True
        '
        'ViewTPLT_REPORTS
        '
        Me.ViewTPLT_REPORTS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLT_REPORTS.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLT_REPORTS.name = "ViewTPLT_REPORTS"
        Me.ViewTPLT_REPORTS.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLT_REPORTS.TabIndex = 0
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add (Me.ViewTPLT_MASK)
        Me.TabPage7.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage7.name = "TabPage7"
        Me.TabPage7.Text = "Параметры для вывода"
        Me.TabPage7.Size = New System.Drawing.Size(520, 366)
        Me.TabPage7.TabIndex = 0
        Me.TabPage7.AutoScroll = True
        '
        'ViewTPLT_MASK
        '
        Me.ViewTPLT_MASK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLT_MASK.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLT_MASK.name = "ViewTPLT_MASK"
        Me.ViewTPLT_MASK.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLT_MASK.TabIndex = 0
   Me.tab.Controls.Add (Me.TabPage1)
   Me.tab.Controls.Add (Me.TabPage2)
   Me.tab.Controls.Add (Me.TabPage3)
   Me.tab.Controls.Add (Me.TabPage4)
   Me.tab.Controls.Add (Me.TabPage5)
   Me.tab.Controls.Add (Me.TabPage6)
   Me.tab.Controls.Add (Me.TabPage7)
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
   Me.TabPage4.ResumeLayout (False)
   Me.TabPage5.ResumeLayout (False)
   Me.TabPage6.ResumeLayout (False)
   Me.TabPage7.ResumeLayout (False)
        Me.ResumeLayout (False)

    End Sub

#End Region



''' <summary>
'''Редактируемый объект
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public item As TPLT.TPLT.Application
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
        item = CType(docItem, TPLT.TPLT.Application)
        mReadOnly =DocReadOnly
        GuiManager = gm
        ViewTPLT_BDEVICES.Attach(item, GuiManager,DocReadOnly)
        ViewTPLT_CONNECT.Attach(item, GuiManager,DocReadOnly)
        ViewTPLT_CONTRACT.Attach(item, GuiManager,DocReadOnly)
        ViewTPLT_PLANCALL.Attach(item, GuiManager,DocReadOnly)
        ViewTPLT_VALUEBOUNDS.Attach(item, GuiManager,DocReadOnly)
        ViewTPLT_REPORTS.Attach(item, GuiManager,DocReadOnly)
        ViewTPLT_MASK.Attach(item, GuiManager,DocReadOnly)
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
        ok = ok And ViewTPLT_BDEVICES.Save(Sielent, NoError)
        ok = ok And ViewTPLT_CONNECT.Save(Sielent, NoError)
        ok = ok And ViewTPLT_CONTRACT.Save(Sielent, NoError)
        ok = ok And ViewTPLT_PLANCALL.Save(Sielent, NoError)
        ok = ok And ViewTPLT_VALUEBOUNDS.Save(Sielent, NoError)
        ok = ok And ViewTPLT_REPORTS.Save(Sielent, NoError)
        ok = ok And ViewTPLT_MASK.Save(Sielent, NoError)
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
        ok = ok And ViewTPLT_BDEVICES.IsOK()
        ok = ok And ViewTPLT_CONNECT.IsOK()
        ok = ok And ViewTPLT_CONTRACT.IsOK()
        ok = ok And ViewTPLT_PLANCALL.IsOK()
        ok = ok And ViewTPLT_VALUEBOUNDS.IsOK()
        ok = ok And ViewTPLT_REPORTS.IsOK()
        ok = ok And ViewTPLT_MASK.IsOK()
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
        ok = ok or ViewTPLT_BDEVICES.IsChanged()
        ok = ok or ViewTPLT_CONNECT.IsChanged()
        ok = ok or ViewTPLT_CONTRACT.IsChanged()
        ok = ok or ViewTPLT_PLANCALL.IsChanged()
        ok = ok or ViewTPLT_VALUEBOUNDS.IsChanged()
        ok = ok or ViewTPLT_REPORTS.IsChanged()
        ok = ok or ViewTPLT_MASK.IsChanged()
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
        ok = ok And ViewTPLT_BDEVICES.Verify(NoError)
        ok = ok And ViewTPLT_CONNECT.Verify(NoError)
        ok = ok And ViewTPLT_CONTRACT.Verify(NoError)
        ok = ok And ViewTPLT_PLANCALL.Verify(NoError)
        ok = ok And ViewTPLT_VALUEBOUNDS.Verify(NoError)
        ok = ok And ViewTPLT_REPORTS.Verify(NoError)
        ok = ok And ViewTPLT_MASK.Verify(NoError)
       Return ok
    End function
    Private Sub TabPage1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Leave
        If ViewTPLT_BDEVICES.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage1.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLT_BDEVICES.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Leave
        If ViewTPLT_CONNECT.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage2.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLT_CONNECT.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Leave
        If ViewTPLT_CONTRACT.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage3.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLT_CONTRACT.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage4.Leave
        If ViewTPLT_PLANCALL.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage4.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLT_PLANCALL.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage5.Leave
        If ViewTPLT_VALUEBOUNDS.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage5.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLT_VALUEBOUNDS.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage6.Leave
        If ViewTPLT_REPORTS.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage6.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLT_REPORTS.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage7.Leave
        If ViewTPLT_MASK.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage7.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLT_MASK.Save(True, False)
            End If
        End If
    End Sub
End Class
