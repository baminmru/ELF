
Imports LATIR2GuiManager
Imports System.Windows.Forms
Imports System.Diagnostics


''' <summary>
'''Основной класс компонента
''' </summary>
''' <remarks>
'''Класс обслуживает визуальное редактирование 
''' </remarks>
Public Class GUI
    Inherits LATIR2GuiManager.Doc_GUIBase


''' <summary>
'''Имя типа
''' </summary>
''' <returns>
'''Строковое значение кода типа объекта 
''' </returns>
''' <remarks>
'''Код типа в метамодели
''' </remarks>
    Public Overrides Function TypeName() As String
        Return "bprcfg"
    End Function


''' <summary>
'''Форма редактирования раздела
''' </summary>
''' <returns>
'''Результат работы формы редактирования
''' </returns>
''' <remarks>
'''Определяется какая форма должна быть вызвана, происходит инициализация и вызов формы
''' </remarks>
    Public Overrides Function ShowPartEditForm(ByVal Mode As String, ByRef RowItem As LATIR2.Document.DocRow_Base, optional byval FormReadOnly as boolean = false) As Boolean
        ' Mode
        If Mode = "" Then

            If RowItem.PartName.ToUpper = "IU_RCFG_DEF" Then
                Dim f As frmiu_rcfg_def
                f = New frmiu_rcfg_def
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "IU_RCFG_MOD" Then
                Dim f As frmiu_rcfg_mod
                f = New frmiu_rcfg_mod
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "IU_RCFG_DOCMODE" Then
                Dim f As frmiu_rcfg_docmode
                f = New frmiu_rcfg_docmode
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If
        If Mode = "read" Then

            If RowItem.PartName.ToUpper = "IU_RCFG_DEF" Then
                Dim f As frmiu_rcfg_defread
                f = New frmiu_rcfg_defread
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "IU_RCFG_MOD" Then
                Dim f As frmiu_rcfg_modread
                f = New frmiu_rcfg_modread
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "IU_RCFG_DOCMODE" Then
                Dim f As frmiu_rcfg_docmoderead
                f = New frmiu_rcfg_docmoderead
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If
        If Mode = "edit" Then

            If RowItem.PartName.ToUpper = "IU_RCFG_DEF" Then
                Dim f As frmiu_rcfg_defedit
                f = New frmiu_rcfg_defedit
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "IU_RCFG_MOD" Then
                Dim f As frmiu_rcfg_modedit
                f = New frmiu_rcfg_modedit
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "IU_RCFG_DOCMODE" Then
                Dim f As frmiu_rcfg_docmodeedit
                f = New frmiu_rcfg_docmodeedit
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If
        If Mode = "new" Then

            If RowItem.PartName.ToUpper = "IU_RCFG_DEF" Then
                Dim f As frmiu_rcfg_defnew
                f = New frmiu_rcfg_defnew
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "IU_RCFG_MOD" Then
                Dim f As frmiu_rcfg_modnew
                f = New frmiu_rcfg_modnew
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "IU_RCFG_DOCMODE" Then
                Dim f As frmiu_rcfg_docmodenew
                f = New frmiu_rcfg_docmodenew
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If

    End Function


''' <summary>
'''Форма редактирования документа
''' </summary>
''' <returns>
'''Резултат работы формы редактирования
''' </returns>
''' <remarks>
'''Определяется какая форма должна быть вызвана, происходит инициализация и вызов формы в модальном режиме
''' </remarks>
    Public Overrides Function ShowForm(ByVal Mode As String, ByRef DocItem As LATIR2.Document.Doc_Base, optional byval FormReadOnly as boolean = false) As Boolean
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "" Then
                Dim f As frmbprcfg
                f = New frmbprcfg
                f.Attach(DocItem, Me.GUIManager, FormReadOnly)
                ShowForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If
        End If
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "read" Then
                Dim fread As frmbprcfgread
                fread = New frmbprcfgread
                fread.Attach(DocItem, Me.GUIManager,FormReadOnly)
                ShowForm = (fread.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                fread = Nothing
            End If
        End If
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "edit" Then
                Dim fedit As frmbprcfgedit
                fedit = New frmbprcfgedit
                fedit.Attach(DocItem, Me.GUIManager,FormReadOnly)
                ShowForm = (fedit.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                fedit = Nothing
            End If
        End If
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "new" Then
                Dim fnew As frmbprcfgnew
                fnew = New frmbprcfgnew
                fnew.Attach(DocItem, Me.GUIManager,FormReadOnly)
                ShowForm = (fnew.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                fnew = Nothing
            End If
        End If
    End Function


''' <summary>
'''Получить контрол, реализующий работу в заданном режиме
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides Function GetObjectControl(ByVal Mode As String, ByVal TypeName As String) As Object
            If Mode = "read" Then
                Return New Tabviewread
            End If
            If Mode = "edit" Then
                Return New Tabviewedit
            End If
            If Mode = "new" Then
                Return New Tabviewnew
            End If
      Return New Tabview
    End Function

    Public Overrides Sub Dispose()
        ' do nothing
    End Sub




End Class
