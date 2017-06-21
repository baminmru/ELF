
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace bpdi


''' <summary>
'''Реализация строки раздела Модуль
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class iu_int_modules
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля № п/п
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Sequence  as long


''' <summary>
'''Локальная переменная для поля Иконка
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheIcon  as String


''' <summary>
'''Локальная переменная для поля Меню верхнего урровня
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_GroupName  as String


''' <summary>
'''Локальная переменная для поля Название меню
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_name  as String


''' <summary>
'''Локальная переменная для поля Надпись
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Caption  as String


''' <summary>
'''Локальная переменная для поля Управление видимостью
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_visibleControl  as enumBoolean


''' <summary>
'''Локальная переменная для поля Документы на контроле
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_controldocmode  as String


''' <summary>
'''Локальная переменная для поля Чужие документы
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_otherdocmode  as String


''' <summary>
'''Локальная переменная для поля Мои документы
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_mydocmode  as String


''' <summary>
'''Локальная переменная для поля Вся фирма
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllObjects  as enumBoolean


''' <summary>
'''Локальная переменная для поля Объекты коллег
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ColegsObject  as enumBoolean


''' <summary>
'''Локальная переменная для поля Подчиненные подразделения
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_SubStructObjects  as enumBoolean



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_Sequence=   
            ' m_TheIcon=   
            ' m_GroupName=   
            ' m_name=   
            ' m_Caption=   
            ' m_visibleControl=   
            ' m_controldocmode=   
            ' m_otherdocmode=   
            ' m_mydocmode=   
            ' m_AllObjects=   
            ' m_ColegsObject=   
            ' m_SubStructObjects=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 12
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
                    Value = Sequence
                Case 2
                    Value = TheIcon
                Case 3
                    Value = GroupName
                Case 4
                    Value = name
                Case 5
                    Value = Caption
                Case 6
                    Value = visibleControl
                Case 7
                    Value = controldocmode
                Case 8
                    Value = otherdocmode
                Case 9
                    Value = mydocmode
                Case 10
                    Value = AllObjects
                Case 11
                    Value = ColegsObject
                Case 12
                    Value = SubStructObjects
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
                    Sequence = value
                Case 2
                    TheIcon = value
                Case 3
                    GroupName = value
                Case 4
                    name = value
                Case 5
                    Caption = value
                Case 6
                    visibleControl = value
                Case 7
                    controldocmode = value
                Case 8
                    otherdocmode = value
                Case 9
                    mydocmode = value
                Case 10
                    AllObjects = value
                Case 11
                    ColegsObject = value
                Case 12
                    SubStructObjects = value
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
                    Return "Sequence"
                Case 2
                    Return "TheIcon"
                Case 3
                    Return "GroupName"
                Case 4
                    Return "name"
                Case 5
                    Return "Caption"
                Case 6
                    Return "visibleControl"
                Case 7
                    Return "controldocmode"
                Case 8
                    Return "otherdocmode"
                Case 9
                    Return "mydocmode"
                Case 10
                    Return "AllObjects"
                Case 11
                    Return "ColegsObject"
                Case 12
                    Return "SubStructObjects"
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
             dr("Sequence") =Sequence
             dr("TheIcon") =TheIcon
             dr("GroupName") =GroupName
             dr("name") =name
             dr("Caption") =Caption
             select case visibleControl
            case enumBoolean.Boolean_Da
              dr ("visibleControl")  = "Да"
              dr ("visibleControl_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("visibleControl")  = "Нет"
              dr ("visibleControl_VAL")  = 0
              end select 'visibleControl
             dr("controldocmode") =controldocmode
             dr("otherdocmode") =otherdocmode
             dr("mydocmode") =mydocmode
             select case AllObjects
            case enumBoolean.Boolean_Da
              dr ("AllObjects")  = "Да"
              dr ("AllObjects_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllObjects")  = "Нет"
              dr ("AllObjects_VAL")  = 0
              end select 'AllObjects
             select case ColegsObject
            case enumBoolean.Boolean_Da
              dr ("ColegsObject")  = "Да"
              dr ("ColegsObject_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("ColegsObject")  = "Нет"
              dr ("ColegsObject_VAL")  = 0
              end select 'ColegsObject
             select case SubStructObjects
            case enumBoolean.Boolean_Da
              dr ("SubStructObjects")  = "Да"
              dr ("SubStructObjects_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("SubStructObjects")  = "Нет"
              dr ("SubStructObjects_VAL")  = 0
              end select 'SubStructObjects
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
          nv.Add("Sequence", Sequence, dbtype.Int32)
          nv.Add("TheIcon", TheIcon, dbtype.string)
          nv.Add("GroupName", GroupName, dbtype.string)
          nv.Add("name", name, dbtype.string)
          nv.Add("Caption", Caption, dbtype.string)
          nv.Add("visibleControl", visibleControl, dbtype.int16)
          nv.Add("controldocmode", controldocmode, dbtype.string)
          nv.Add("otherdocmode", otherdocmode, dbtype.string)
          nv.Add("mydocmode", mydocmode, dbtype.string)
          nv.Add("AllObjects", AllObjects, dbtype.int16)
          nv.Add("ColegsObject", ColegsObject, dbtype.int16)
          nv.Add("SubStructObjects", SubStructObjects, dbtype.int16)
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
          If reader.Table.Columns.Contains("Sequence") Then m_Sequence=reader.item("Sequence")
          If reader.Table.Columns.Contains("TheIcon") Then m_TheIcon=reader.item("TheIcon").ToString()
          If reader.Table.Columns.Contains("GroupName") Then m_GroupName=reader.item("GroupName").ToString()
          If reader.Table.Columns.Contains("name") Then m_name=reader.item("name").ToString()
          If reader.Table.Columns.Contains("Caption") Then m_Caption=reader.item("Caption").ToString()
          If reader.Table.Columns.Contains("visibleControl") Then m_visibleControl=reader.item("visibleControl")
          If reader.Table.Columns.Contains("controldocmode") Then m_controldocmode=reader.item("controldocmode").ToString()
          If reader.Table.Columns.Contains("otherdocmode") Then m_otherdocmode=reader.item("otherdocmode").ToString()
          If reader.Table.Columns.Contains("mydocmode") Then m_mydocmode=reader.item("mydocmode").ToString()
          If reader.Table.Columns.Contains("AllObjects") Then m_AllObjects=reader.item("AllObjects")
          If reader.Table.Columns.Contains("ColegsObject") Then m_ColegsObject=reader.item("ColegsObject")
          If reader.Table.Columns.Contains("SubStructObjects") Then m_SubStructObjects=reader.item("SubStructObjects")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю № п/п
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Sequence() As long
            Get
                LoadFromDatabase()
                Sequence = m_Sequence
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_Sequence = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Иконка
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheIcon() As String
            Get
                LoadFromDatabase()
                TheIcon = m_TheIcon
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_TheIcon = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Меню верхнего урровня
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property GroupName() As String
            Get
                LoadFromDatabase()
                GroupName = m_GroupName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_GroupName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Название меню
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property name() As String
            Get
                LoadFromDatabase()
                name = m_name
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_name = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Надпись
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Caption() As String
            Get
                LoadFromDatabase()
                Caption = m_Caption
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_Caption = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Управление видимостью
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property visibleControl() As enumBoolean
            Get
                LoadFromDatabase()
                visibleControl = m_visibleControl
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_visibleControl = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Документы на контроле
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property controldocmode() As String
            Get
                LoadFromDatabase()
                controldocmode = m_controldocmode
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_controldocmode = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Чужие документы
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property otherdocmode() As String
            Get
                LoadFromDatabase()
                otherdocmode = m_otherdocmode
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_otherdocmode = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Мои документы
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property mydocmode() As String
            Get
                LoadFromDatabase()
                mydocmode = m_mydocmode
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_mydocmode = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Вся фирма
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllObjects() As enumBoolean
            Get
                LoadFromDatabase()
                AllObjects = m_AllObjects
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllObjects = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объекты коллег
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ColegsObject() As enumBoolean
            Get
                LoadFromDatabase()
                ColegsObject = m_ColegsObject
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_ColegsObject = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Подчиненные подразделения
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property SubStructObjects() As enumBoolean
            Get
                LoadFromDatabase()
                SubStructObjects = m_SubStructObjects
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_SubStructObjects = Value
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
            Sequence = node.Attributes.GetNamedItem("Sequence").Value
            TheIcon = node.Attributes.GetNamedItem("TheIcon").Value
            GroupName = node.Attributes.GetNamedItem("GroupName").Value
            name = node.Attributes.GetNamedItem("name").Value
            Caption = node.Attributes.GetNamedItem("Caption").Value
            visibleControl = node.Attributes.GetNamedItem("visibleControl").Value
            controldocmode = node.Attributes.GetNamedItem("controldocmode").Value
            otherdocmode = node.Attributes.GetNamedItem("otherdocmode").Value
            mydocmode = node.Attributes.GetNamedItem("mydocmode").Value
            AllObjects = node.Attributes.GetNamedItem("AllObjects").Value
            ColegsObject = node.Attributes.GetNamedItem("ColegsObject").Value
            SubStructObjects = node.Attributes.GetNamedItem("SubStructObjects").Value
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
          node.SetAttribute("Sequence", Sequence)  
          node.SetAttribute("TheIcon", TheIcon)  
          node.SetAttribute("GroupName", GroupName)  
          node.SetAttribute("name", name)  
          node.SetAttribute("Caption", Caption)  
          node.SetAttribute("visibleControl", visibleControl)  
          node.SetAttribute("controldocmode", controldocmode)  
          node.SetAttribute("otherdocmode", otherdocmode)  
          node.SetAttribute("mydocmode", mydocmode)  
          node.SetAttribute("AllObjects", AllObjects)  
          node.SetAttribute("ColegsObject", ColegsObject)  
          node.SetAttribute("SubStructObjects", SubStructObjects)  
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
