


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
    Friend WithEvents ViewTPLD_SNABTOP As TPLDGUI.viewTPLD_SNABTOP
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLD_PARAM As TPLDGUI.viewTPLD_PARAM
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLD_SNAB As TPLDGUI.viewTPLD_SNAB
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLD_F As TPLDGUI.viewTPLD_F
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLD_CONNECTTYPE As TPLDGUI.viewTPLD_CONNECTTYPE
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLD_DEVCLASS As TPLDGUI.viewTPLD_DEVCLASS
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLD_DEVTYPE As TPLDGUI.viewTPLD_DEVTYPE
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLD_GRP As TPLDGUI.viewTPLD_GRP
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents ViewTPLD_PARAMTYPE As TPLDGUI.viewTPLD_PARAMTYPE
   
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tab = New System.Windows.Forms.TabControl
   TabPage1 = New System.Windows.Forms.TabPage
   ViewTPLD_SNABTOP = new viewTPLD_SNABTOP
   TabPage2 = New System.Windows.Forms.TabPage
   ViewTPLD_PARAM = new viewTPLD_PARAM
   TabPage3 = New System.Windows.Forms.TabPage
   ViewTPLD_SNAB = new viewTPLD_SNAB
   TabPage4 = New System.Windows.Forms.TabPage
   ViewTPLD_F = new viewTPLD_F
   TabPage5 = New System.Windows.Forms.TabPage
   ViewTPLD_CONNECTTYPE = new viewTPLD_CONNECTTYPE
   TabPage6 = New System.Windows.Forms.TabPage
   ViewTPLD_DEVCLASS = new viewTPLD_DEVCLASS
   TabPage7 = New System.Windows.Forms.TabPage
   ViewTPLD_DEVTYPE = new viewTPLD_DEVTYPE
   TabPage8 = New System.Windows.Forms.TabPage
   ViewTPLD_GRP = new viewTPLD_GRP
   TabPage9 = New System.Windows.Forms.TabPage
   ViewTPLD_PARAMTYPE = new viewTPLD_PARAMTYPE
        Me.tab.SuspendLayout()
   Me.TabPage1.SuspendLayout()
   Me.TabPage2.SuspendLayout()
   Me.TabPage3.SuspendLayout()
   Me.TabPage4.SuspendLayout()
   Me.TabPage5.SuspendLayout()
   Me.TabPage6.SuspendLayout()
   Me.TabPage7.SuspendLayout()
   Me.TabPage8.SuspendLayout()
   Me.TabPage9.SuspendLayout()
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
        Me.TabPage1.Controls.Add (Me.ViewTPLD_SNABTOP)
        Me.TabPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage1.name = "TabPage1"
        Me.TabPage1.Text = "Поставщик"
        Me.TabPage1.Size = New System.Drawing.Size(520, 366)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.AutoScroll = True
        '
        'ViewTPLD_SNABTOP
        '
        Me.ViewTPLD_SNABTOP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLD_SNABTOP.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLD_SNABTOP.name = "ViewTPLD_SNABTOP"
        Me.ViewTPLD_SNABTOP.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLD_SNABTOP.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add (Me.ViewTPLD_PARAM)
        Me.TabPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage2.name = "TabPage2"
        Me.TabPage2.Text = "Параметры"
        Me.TabPage2.Size = New System.Drawing.Size(520, 366)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.AutoScroll = True
        '
        'ViewTPLD_PARAM
        '
        Me.ViewTPLD_PARAM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLD_PARAM.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLD_PARAM.name = "ViewTPLD_PARAM"
        Me.ViewTPLD_PARAM.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLD_PARAM.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add (Me.ViewTPLD_SNAB)
        Me.TabPage3.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage3.name = "TabPage3"
        Me.TabPage3.Text = "Снабжающая организация"
        Me.TabPage3.Size = New System.Drawing.Size(520, 366)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.AutoScroll = True
        '
        'ViewTPLD_SNAB
        '
        Me.ViewTPLD_SNAB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLD_SNAB.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLD_SNAB.name = "ViewTPLD_SNAB"
        Me.ViewTPLD_SNAB.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLD_SNAB.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add (Me.ViewTPLD_F)
        Me.TabPage4.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage4.name = "TabPage4"
        Me.TabPage4.Text = "Филиал организации"
        Me.TabPage4.Size = New System.Drawing.Size(520, 366)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.AutoScroll = True
        '
        'ViewTPLD_F
        '
        Me.ViewTPLD_F.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLD_F.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLD_F.name = "ViewTPLD_F"
        Me.ViewTPLD_F.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLD_F.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add (Me.ViewTPLD_CONNECTTYPE)
        Me.TabPage5.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage5.name = "TabPage5"
        Me.TabPage5.Text = "Тип подключения"
        Me.TabPage5.Size = New System.Drawing.Size(520, 366)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.AutoScroll = True
        '
        'ViewTPLD_CONNECTTYPE
        '
        Me.ViewTPLD_CONNECTTYPE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLD_CONNECTTYPE.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLD_CONNECTTYPE.name = "ViewTPLD_CONNECTTYPE"
        Me.ViewTPLD_CONNECTTYPE.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLD_CONNECTTYPE.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add (Me.ViewTPLD_DEVCLASS)
        Me.TabPage6.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage6.name = "TabPage6"
        Me.TabPage6.Text = "Класс устройства"
        Me.TabPage6.Size = New System.Drawing.Size(520, 366)
        Me.TabPage6.TabIndex = 0
        Me.TabPage6.AutoScroll = True
        '
        'ViewTPLD_DEVCLASS
        '
        Me.ViewTPLD_DEVCLASS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLD_DEVCLASS.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLD_DEVCLASS.name = "ViewTPLD_DEVCLASS"
        Me.ViewTPLD_DEVCLASS.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLD_DEVCLASS.TabIndex = 0
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add (Me.ViewTPLD_DEVTYPE)
        Me.TabPage7.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage7.name = "TabPage7"
        Me.TabPage7.Text = "Тип устройства"
        Me.TabPage7.Size = New System.Drawing.Size(520, 366)
        Me.TabPage7.TabIndex = 0
        Me.TabPage7.AutoScroll = True
        '
        'ViewTPLD_DEVTYPE
        '
        Me.ViewTPLD_DEVTYPE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLD_DEVTYPE.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLD_DEVTYPE.name = "ViewTPLD_DEVTYPE"
        Me.ViewTPLD_DEVTYPE.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLD_DEVTYPE.TabIndex = 0
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add (Me.ViewTPLD_GRP)
        Me.TabPage8.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage8.name = "TabPage8"
        Me.TabPage8.Text = "Группа"
        Me.TabPage8.Size = New System.Drawing.Size(520, 366)
        Me.TabPage8.TabIndex = 0
        Me.TabPage8.AutoScroll = True
        '
        'ViewTPLD_GRP
        '
        Me.ViewTPLD_GRP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLD_GRP.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLD_GRP.name = "ViewTPLD_GRP"
        Me.ViewTPLD_GRP.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLD_GRP.TabIndex = 0
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add (Me.ViewTPLD_PARAMTYPE)
        Me.TabPage9.Location = New System.Drawing.Point(-10000, -10000)
        Me.TabPage9.name = "TabPage9"
        Me.TabPage9.Text = "Тип архива"
        Me.TabPage9.Size = New System.Drawing.Size(520, 366)
        Me.TabPage9.TabIndex = 0
        Me.TabPage9.AutoScroll = True
        '
        'ViewTPLD_PARAMTYPE
        '
        Me.ViewTPLD_PARAMTYPE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTPLD_PARAMTYPE.Location = New System.Drawing.Point(0, 0)
        Me.ViewTPLD_PARAMTYPE.name = "ViewTPLD_PARAMTYPE"
        Me.ViewTPLD_PARAMTYPE.Size = New System.Drawing.Size(504, 352)
        Me.ViewTPLD_PARAMTYPE.TabIndex = 0
   Me.tab.Controls.Add (Me.TabPage1)
   Me.tab.Controls.Add (Me.TabPage2)
   Me.tab.Controls.Add (Me.TabPage3)
   Me.tab.Controls.Add (Me.TabPage4)
   Me.tab.Controls.Add (Me.TabPage5)
   Me.tab.Controls.Add (Me.TabPage6)
   Me.tab.Controls.Add (Me.TabPage7)
   Me.tab.Controls.Add (Me.TabPage8)
   Me.tab.Controls.Add (Me.TabPage9)
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
   Me.TabPage8.ResumeLayout (False)
   Me.TabPage9.ResumeLayout (False)
        Me.ResumeLayout (False)

    End Sub

#End Region



''' <summary>
'''Редактируемый объект
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public item As TPLD.TPLD.Application
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
        item = CType(docItem, TPLD.TPLD.Application)
        mReadOnly =DocReadOnly
        GuiManager = gm
        ViewTPLD_SNABTOP.Attach(item, GuiManager,DocReadOnly)
        ViewTPLD_PARAM.Attach(item, GuiManager,DocReadOnly)
        ViewTPLD_SNAB.Attach(item, GuiManager,DocReadOnly)
        ViewTPLD_F.Attach(item, GuiManager,DocReadOnly)
        ViewTPLD_CONNECTTYPE.Attach(item, GuiManager,DocReadOnly)
        ViewTPLD_DEVCLASS.Attach(item, GuiManager,DocReadOnly)
        ViewTPLD_DEVTYPE.Attach(item, GuiManager,DocReadOnly)
        ViewTPLD_GRP.Attach(item, GuiManager,DocReadOnly)
        ViewTPLD_PARAMTYPE.Attach(item, GuiManager,DocReadOnly)
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
        ok = ok And ViewTPLD_SNABTOP.Save(Sielent, NoError)
        ok = ok And ViewTPLD_PARAM.Save(Sielent, NoError)
        ok = ok And ViewTPLD_SNAB.Save(Sielent, NoError)
        ok = ok And ViewTPLD_F.Save(Sielent, NoError)
        ok = ok And ViewTPLD_CONNECTTYPE.Save(Sielent, NoError)
        ok = ok And ViewTPLD_DEVCLASS.Save(Sielent, NoError)
        ok = ok And ViewTPLD_DEVTYPE.Save(Sielent, NoError)
        ok = ok And ViewTPLD_GRP.Save(Sielent, NoError)
        ok = ok And ViewTPLD_PARAMTYPE.Save(Sielent, NoError)
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
        ok = ok And ViewTPLD_SNABTOP.IsOK()
        ok = ok And ViewTPLD_PARAM.IsOK()
        ok = ok And ViewTPLD_SNAB.IsOK()
        ok = ok And ViewTPLD_F.IsOK()
        ok = ok And ViewTPLD_CONNECTTYPE.IsOK()
        ok = ok And ViewTPLD_DEVCLASS.IsOK()
        ok = ok And ViewTPLD_DEVTYPE.IsOK()
        ok = ok And ViewTPLD_GRP.IsOK()
        ok = ok And ViewTPLD_PARAMTYPE.IsOK()
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
        ok = ok or ViewTPLD_SNABTOP.IsChanged()
        ok = ok or ViewTPLD_PARAM.IsChanged()
        ok = ok or ViewTPLD_SNAB.IsChanged()
        ok = ok or ViewTPLD_F.IsChanged()
        ok = ok or ViewTPLD_CONNECTTYPE.IsChanged()
        ok = ok or ViewTPLD_DEVCLASS.IsChanged()
        ok = ok or ViewTPLD_DEVTYPE.IsChanged()
        ok = ok or ViewTPLD_GRP.IsChanged()
        ok = ok or ViewTPLD_PARAMTYPE.IsChanged()
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
        ok = ok And ViewTPLD_SNABTOP.Verify(NoError)
        ok = ok And ViewTPLD_PARAM.Verify(NoError)
        ok = ok And ViewTPLD_SNAB.Verify(NoError)
        ok = ok And ViewTPLD_F.Verify(NoError)
        ok = ok And ViewTPLD_CONNECTTYPE.Verify(NoError)
        ok = ok And ViewTPLD_DEVCLASS.Verify(NoError)
        ok = ok And ViewTPLD_DEVTYPE.Verify(NoError)
        ok = ok And ViewTPLD_GRP.Verify(NoError)
        ok = ok And ViewTPLD_PARAMTYPE.Verify(NoError)
       Return ok
    End function
    Private Sub TabPage1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Leave
        If ViewTPLD_SNABTOP.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage1.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLD_SNABTOP.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Leave
        If ViewTPLD_PARAM.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage2.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLD_PARAM.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.Leave
        If ViewTPLD_SNAB.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage3.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLD_SNAB.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage4.Leave
        If ViewTPLD_F.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage4.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLD_F.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage5.Leave
        If ViewTPLD_CONNECTTYPE.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage5.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLD_CONNECTTYPE.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage6.Leave
        If ViewTPLD_DEVCLASS.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage6.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLD_DEVCLASS.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage7.Leave
        If ViewTPLD_DEVTYPE.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage7.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLD_DEVTYPE.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage8_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage8.Leave
        If ViewTPLD_GRP.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage8.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLD_GRP.Save(True, False)
            End If
        End If
    End Sub
    Private Sub TabPage9_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage9.Leave
        If ViewTPLD_PARAMTYPE.IsChanged() Then
            If MsgBox("Сохранить изменения на вкладке <" + TabPage9.Text + "> ?", MsgBoxStyle.YesNo, "Изменения") = MsgBoxResult.Yes Then
                ViewTPLD_PARAMTYPE.Save(True, False)
            End If
        End If
    End Sub
End Class
