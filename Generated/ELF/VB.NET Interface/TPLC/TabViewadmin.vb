


''' <summary>
'''Компонент, реализующий редактирование всего документа
''' </summary>
''' <remarks>
'''
''' </remarks>
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Public Class Tabviewadmin
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
    Friend WithEvents ViewTPLC_HEADER As TPLCGUI.viewTPLC_HEADERadmin
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLC_M As TPLCGUI.viewTPLC_Madmin
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLC_H As TPLCGUI.viewTPLC_Hadmin
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLC_D As TPLCGUI.viewTPLC_Dadmin
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLC_T As TPLCGUI.viewTPLC_Tadmin
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLC_MISSING As TPLCGUI.viewTPLC_MISSINGadmin
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLC_E As TPLCGUI.viewTPLC_Eadmin
   
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tab = New System.Windows.Forms.TabControl
   TabPage1 = New System.Windows.Forms.TabPage
   ViewTPLC_HEADER = new viewTPLC_HEADERadmin
   TabPage2 = New System.Windows.Forms.TabPage
   ViewTPLC_M = new viewTPLC_Madmin
   TabPage3 = New System.Windows.Forms.TabPage
   ViewTPLC_H = new viewTPLC_Hadmin
   TabPage4 = New System.Windows.Forms.TabPage
   ViewTPLC_D = new viewTPLC_Dadmin
   TabPage5 = New System.Windows.Forms.TabPage
   ViewTPLC_T = new viewTPLC_Tadmin
   TabPage6 = New System.Windows.Forms.TabPage
   ViewTPLC_MISSING = new viewTPLC_MISSINGadmin
   TabPage7 = New System.Windows.Forms.TabPage
   ViewTPLC_E = new viewTPLC_Eadmin
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
        Me.TabPage1.Controls.Add (Me.ViewTPLC_HEADER)
        Me.TabPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage1.name = "TabPage1"
        Me.TabPage1.Text = "Заголовок"
        Me.TabPage1.Size = New System.Drawing.Size(520, 366)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.AutoScroll = True
        '
        'ViewTPLC_HEADER
        '
        Me.ViewTPLC_HEADER.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLC_HEADER.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLC_HEADER.name = "ViewTPLC_HEADER"
        Me.ViewTPLC_HEADER.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLC_HEADER.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add (Me.ViewTPLC_M)
        Me.TabPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage2.name = "TabPage2"
        Me.TabPage2.Text = "Мгновенные значения"
        Me.TabPage2.Size = New System.Drawing.Size(520, 366)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.AutoScroll = True
        '
        'ViewTPLC_M
        '
        Me.ViewTPLC_M.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLC_M.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLC_M.name = "ViewTPLC_M"
        Me.ViewTPLC_M.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLC_M.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add (Me.ViewTPLC_H)
        Me.TabPage3.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage3.name = "TabPage3"
        Me.TabPage3.Text = "Часовые архивы"
        Me.TabPage3.Size = New System.Drawing.Size(520, 366)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.AutoScroll = True
        '
        'ViewTPLC_H
        '
        Me.ViewTPLC_H.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLC_H.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLC_H.name = "ViewTPLC_H"
        Me.ViewTPLC_H.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLC_H.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add (Me.ViewTPLC_D)
        Me.TabPage4.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage4.name = "TabPage4"
        Me.TabPage4.Text = "Суточный архив"
        Me.TabPage4.Size = New System.Drawing.Size(520, 366)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.AutoScroll = True
        '
        'ViewTPLC_D
        '
        Me.ViewTPLC_D.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLC_D.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLC_D.name = "ViewTPLC_D"
        Me.ViewTPLC_D.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLC_D.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add (Me.ViewTPLC_T)
        Me.TabPage5.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage5.name = "TabPage5"
        Me.TabPage5.Text = "Суммарные показатели"
        Me.TabPage5.Size = New System.Drawing.Size(520, 366)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.AutoScroll = True
        '
        'ViewTPLC_T
        '
        Me.ViewTPLC_T.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLC_T.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLC_T.name = "ViewTPLC_T"
        Me.ViewTPLC_T.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLC_T.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add (Me.ViewTPLC_MISSING)
        Me.TabPage6.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage6.name = "TabPage6"
        Me.TabPage6.Text = "Пропущенные архивы"
        Me.TabPage6.Size = New System.Drawing.Size(520, 366)
        Me.TabPage6.TabIndex = 0
        Me.TabPage6.AutoScroll = True
        '
        'ViewTPLC_MISSING
        '
        Me.ViewTPLC_MISSING.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLC_MISSING.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLC_MISSING.name = "ViewTPLC_MISSING"
        Me.ViewTPLC_MISSING.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLC_MISSING.TabIndex = 0
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add (Me.ViewTPLC_E)
        Me.TabPage7.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage7.name = "TabPage7"
        Me.TabPage7.Text = "Электроэнергия"
        Me.TabPage7.Size = New System.Drawing.Size(520, 366)
        Me.TabPage7.TabIndex = 0
        Me.TabPage7.AutoScroll = True
        '
        'ViewTPLC_E
        '
        Me.ViewTPLC_E.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLC_E.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLC_E.name = "ViewTPLC_E"
        Me.ViewTPLC_E.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLC_E.TabIndex = 0
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
    Public item As TPLC.TPLC.Application
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
        item = CType(docItem, TPLC.TPLC.Application)
        mReadOnly =DocReadOnly
        GuiManager = gm
        ViewTPLC_HEADER.Attach(item, GuiManager,DocReadOnly)
        ViewTPLC_M.Attach(item, GuiManager,DocReadOnly)
        ViewTPLC_H.Attach(item, GuiManager,DocReadOnly)
        ViewTPLC_D.Attach(item, GuiManager,DocReadOnly)
        ViewTPLC_T.Attach(item, GuiManager,DocReadOnly)
        ViewTPLC_MISSING.Attach(item, GuiManager,DocReadOnly)
        ViewTPLC_E.Attach(item, GuiManager,DocReadOnly)
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
        ok = ok And ViewTPLC_HEADER.Save(Sielent, NoError)
        ok = ok And ViewTPLC_M.Save(Sielent, NoError)
        ok = ok And ViewTPLC_H.Save(Sielent, NoError)
        ok = ok And ViewTPLC_D.Save(Sielent, NoError)
        ok = ok And ViewTPLC_T.Save(Sielent, NoError)
        ok = ok And ViewTPLC_MISSING.Save(Sielent, NoError)
        ok = ok And ViewTPLC_E.Save(Sielent, NoError)
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
        ok = ok And ViewTPLC_HEADER.IsOK()
        ok = ok And ViewTPLC_M.IsOK()
        ok = ok And ViewTPLC_H.IsOK()
        ok = ok And ViewTPLC_D.IsOK()
        ok = ok And ViewTPLC_T.IsOK()
        ok = ok And ViewTPLC_MISSING.IsOK()
        ok = ok And ViewTPLC_E.IsOK()
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
        ok = ok or ViewTPLC_HEADER.IsChanged()
        ok = ok or ViewTPLC_M.IsChanged()
        ok = ok or ViewTPLC_H.IsChanged()
        ok = ok or ViewTPLC_D.IsChanged()
        ok = ok or ViewTPLC_T.IsChanged()
        ok = ok or ViewTPLC_MISSING.IsChanged()
        ok = ok or ViewTPLC_E.IsChanged()
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
        ok = ok And ViewTPLC_HEADER.Verify(NoError)
        ok = ok And ViewTPLC_M.Verify(NoError)
        ok = ok And ViewTPLC_H.Verify(NoError)
        ok = ok And ViewTPLC_D.Verify(NoError)
        ok = ok And ViewTPLC_T.Verify(NoError)
        ok = ok And ViewTPLC_MISSING.Verify(NoError)
        ok = ok And ViewTPLC_E.Verify(NoError)
       Return ok
    End function
    Private Sub TabPage1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Leave
        If ViewTPLC_HEADER.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage1.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLC_HEADER.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Leave
        If ViewTPLC_M.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage2.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLC_M.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Leave
        If ViewTPLC_H.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage3.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLC_H.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage4.Leave
        If ViewTPLC_D.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage4.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLC_D.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage5.Leave
        If ViewTPLC_T.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage5.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLC_T.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage6.Leave
        If ViewTPLC_MISSING.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage6.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLC_MISSING.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage7.Leave
        If ViewTPLC_E.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage7.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLC_E.Save(True, False)
            End If
        End If
    End Sub
End Class
