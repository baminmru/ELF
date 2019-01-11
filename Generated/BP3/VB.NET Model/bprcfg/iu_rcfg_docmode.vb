
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace bprcfg


''' <summary>
'''Реализация строки раздела Режим документа
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class iu_rcfg_docmode
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Тип документа
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_The_Document  as System.Guid


''' <summary>
'''Локальная переменная для поля Режим для  создания
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AddMode  as String


''' <summary>
'''Локальная переменная для поля Режим для редактирования
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_EditMode  as String


''' <summary>
'''Локальная переменная для поля Можно создавать
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowAdd  as enumBoolean


''' <summary>
'''Локальная переменная для поля Можно удалять
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowDelete  as enumBoolean



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_The_Document=   
            ' m_AddMode=   
            ' m_EditMode=   
            ' m_AllowAdd=   
            ' m_AllowDelete=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 5
        End Get
    End Property



''' <summary>
'''Получить \Задать поле по номеру 
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Overrides Property Value(ByVal Index As Object) As Object
    Get
        If Microsoft.VisualBasic.IsNumeric(Index) Then
            Dim l As Long
            l = CLng(Index)
            Select Case l
                Case 0
                    Value = ID
                Case 1
                    Value = The_Document
                Case 2
                    Value = AddMode
                Case 3
                    Value = EditMode
                Case 4
                    Value = AllowAdd
                Case 5
                    Value = AllowDelete
            End Select
        else
        try
          Value = Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Get, Nothing)
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
              Value=nothing
          end try
        End If
    End Get
    Set(ByVal value As Object)
    If Microsoft.VisualBasic.IsNumeric(Index) Then
        Dim l As Long
        l = CLng(Index)
        Select Case l
            Case 0
                 ID=value
                Case 1
                    The_Document = value
                Case 2
                    AddMode = value
                Case 3
                    EditMode = value
                Case 4
                    AllowAdd = value
                Case 5
                    AllowDelete = value
        End Select
     Else
        Try
            Try
                Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Set, value)
            Catch ex As Exception
                Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Let, value)
            End Try
        Catch ex As Exception
        End Try
     End If
  End Set

End Property



''' <summary>
'''Название поля по номеру
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Overrides Function FieldNameByID(ByVal Index As long) As String
        If Microsoft.VisualBasic.IsNumeric(Index) Then
            Dim l As Long
            l = CLng(Index)
            Select Case l
                Case 0
                   Return "ID"
                Case 1
                    Return "The_Document"
                Case 2
                    Return "AddMode"
                Case 3
                    Return "EditMode"
                Case 4
                    Return "AllowAdd"
                Case 5
                    Return "AllowDelete"
                Case else
                return "" 
            End Select
        End If
        return "" 
End Function



''' <summary>
'''Заполнить строку таблицы данными из полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub FillDataTable(ByRef DestDataTable As System.Data.DataTable)
            Dim dr As  DataRow
            dr = destdatatable.NewRow
            try
            dr("ID") =ID
            dr("Brief") =Brief
             if The_Document is nothing then
               dr("The_Document") =system.dbnull.value
               dr("The_Document_ID") =System.Guid.Empty
             else
               dr("The_Document") =The_Document.BRIEF
               dr("The_Document_ID") =The_Document.ID
             end if 
             dr("AddMode") =AddMode
             dr("EditMode") =EditMode
             select case AllowAdd
            case enumBoolean.Boolean_Da
              dr ("AllowAdd")  = "Да"
              dr ("AllowAdd_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowAdd")  = "Нет"
              dr ("AllowAdd_VAL")  = 0
              end select 'AllowAdd
             select case AllowDelete
            case enumBoolean.Boolean_Da
              dr ("AllowDelete")  = "Да"
              dr ("AllowDelete_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowDelete")  = "Нет"
              dr ("AllowDelete_VAL")  = 0
              end select 'AllowDelete
            DestDataTable.Rows.Add (dr)
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub



''' <summary>
'''Найти строку в коллекции по идентификатору
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function FindInside(ByVal Table As String, ByVal RowID As String) As LATIR2.Document.DocRow_Base
            dim mFindInside As LATIR2.Document.DocRow_Base = Nothing
            Return Nothing
        End Function



''' <summary>
'''Заполнить коллекцю именованных полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Pack(ByVal nv As LATIR2.NamedValues)
          if m_The_Document.Equals(System.Guid.Empty) then
            nv.Add("The_Document", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("The_Document", Application.Session.GetProvider.ID2Param(m_The_Document), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("AddMode", AddMode, dbtype.string)
          nv.Add("EditMode", EditMode, dbtype.string)
          nv.Add("AllowAdd", AllowAdd, dbtype.int16)
          nv.Add("AllowDelete", AllowDelete, dbtype.int16)
            nv.Add(PartName() & "id", Application.Session.GetProvider.ID2Param(ID),  Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
        End Sub




''' <summary>
'''Заполнить поля из именованной коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Unpack(ByVal reader As System.Data.DataRow)
            try  
            If IsDBNull(reader.item("SecurityStyleID")) Then
                SecureStyleID = System.guid.Empty
            Else
                SecureStyleID = new Guid(reader.item("SecurityStyleID").ToString())
            End If

            RowRetrived = True
            RetriveTime = Now
      If reader.Table.Columns.Contains("The_Document") Then
          if isdbnull(reader.item("The_Document")) then
            If reader.Table.Columns.Contains("The_Document") Then m_The_Document = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("The_Document") Then m_The_Document= New System.Guid(reader.item("The_Document").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("AddMode") Then m_AddMode=reader.item("AddMode").ToString()
          If reader.Table.Columns.Contains("EditMode") Then m_EditMode=reader.item("EditMode").ToString()
          If reader.Table.Columns.Contains("AllowAdd") Then m_AllowAdd=reader.item("AllowAdd")
          If reader.Table.Columns.Contains("AllowDelete") Then m_AllowDelete=reader.item("AllowDelete")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Тип документа
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property The_Document() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                The_Document = me.application.Findrowobject("OBJECTTYPE",m_The_Document)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_The_Document = Value.id
                else
                   m_The_Document=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Режим для  создания
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AddMode() As String
            Get
                LoadFromDatabase()
                AddMode = m_AddMode
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_AddMode = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Режим для редактирования
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property EditMode() As String
            Get
                LoadFromDatabase()
                EditMode = m_EditMode
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_EditMode = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Можно создавать
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowAdd() As enumBoolean
            Get
                LoadFromDatabase()
                AllowAdd = m_AllowAdd
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowAdd = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Можно удалять
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowDelete() As enumBoolean
            Get
                LoadFromDatabase()
                AllowDelete = m_AllowDelete
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowDelete = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Заполнить поля данными из XML
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XMLUnpack(ByVal node As System.Xml.XmlNode, Optional ByVal LoadMode As Integer = 0)
          Dim e_list As XmlNodeList
          try 
            m_The_Document = new system.guid(node.Attributes.GetNamedItem("The_Document").Value)
            AddMode = node.Attributes.GetNamedItem("AddMode").Value
            EditMode = node.Attributes.GetNamedItem("EditMode").Value
            AllowAdd = node.Attributes.GetNamedItem("AllowAdd").Value
            AllowDelete = node.Attributes.GetNamedItem("AllowDelete").Value
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
          node.SetAttribute("The_Document", m_The_Document.tostring)  
          node.SetAttribute("AddMode", AddMode)  
          node.SetAttribute("EditMode", EditMode)  
          node.SetAttribute("AllowAdd", AllowAdd)  
          node.SetAttribute("AllowDelete", AllowDelete)  
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub


''' <summary>
'''Записать изменения в базу данных
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Overrides Sub BatchUpdate()
  If Deleted Then
    Delete
    Exit Sub
  End If
  If Changed Then Save
End Sub


''' <summary>
'''Количество дочерних разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 0
            End Get
        End Property



''' <summary>
'''Доступ к дочернему разделу по номеру
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function GetDocCollection_Base(ByVal Index As Long) As LATIR2.Document.DocCollection_Base
            Select Case Index
            End Select
            return nothing
        End Function
    End Class
End Namespace
