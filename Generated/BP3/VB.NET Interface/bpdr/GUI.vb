
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
        Return "bpdr"
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

            If RowItem.PartName.ToUpper = "IU_CROLE" Then
                Dim f As frmiu_crole
                f = New frmiu_crole
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If
        If Mode = "read" Then

            If RowItem.PartName.ToUpper = "IU_CROLE" Then
                Dim f As frmiu_croleread
                f = New frmiu_croleread
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If
        If Mode = "edit" Then

            If RowItem.PartName.ToUpper = "IU_CROLE" Then
                Dim f As frmiu_croleedit
                f = New frmiu_croleedit
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
                Dim f As frmbpdr
                f = New frmbpdr
                f.Attach(DocItem, Me.GUIManager, FormReadOnly)
                ShowForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If
        End If
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "read" Then
                Dim fread As frmbpdrread
                fread = New frmbpdrread
                fread.Attach(DocItem, Me.GUIManager,FormReadOnly)
                ShowForm = (fread.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                fread = Nothing
            End If
        End If
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "edit" Then
                Dim fedit As frmbpdredit
                fedit = New frmbpdredit
                fedit.Attach(DocItem, Me.GUIManager,FormReadOnly)
                ShowForm = (fedit.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                fedit = Nothing
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
      Return New Tabview
    End Function

    Public Overrides Sub Dispose()
        ' do nothing
    End Sub




End Class
