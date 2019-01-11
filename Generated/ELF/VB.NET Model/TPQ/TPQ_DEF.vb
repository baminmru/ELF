
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace TPQ


''' <summary>
'''Реализация строки раздела Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPQ_DEF
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Сессия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheSessionID  as System.Guid


''' <summary>
'''Локальная переменная для поля Тепловычислитель
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheDevice  as System.Guid


''' <summary>
'''Локальная переменная для поля Тип архива
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ArchType  as System.Guid


''' <summary>
'''Локальная переменная для поля Время
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ArchTime  as DATE


''' <summary>
'''Локальная переменная для поля Время  постановки запроса
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_QueryTime  as DATE


''' <summary>
'''Локальная переменная для поля Срочный запрос
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsUrgent  as enumBoolean


''' <summary>
'''Локальная переменная для поля Количество повторений при ошибке
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_RepeatTimes  as long


''' <summary>
'''Локальная переменная для поля Интервал между повторами
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_RepeatInterval  as long



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_TheSessionID=   
            ' m_TheDevice=   
            ' m_ArchType=   
            ' m_ArchTime=   
            ' m_QueryTime=   
            ' m_IsUrgent=   
            ' m_RepeatTimes=   
            ' m_RepeatInterval=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 8
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
                    Value = TheSessionID
                Case 2
                    Value = TheDevice
                Case 3
                    Value = ArchType
                Case 4
                    Value = ArchTime
                Case 5
                    Value = QueryTime
                Case 6
                    Value = IsUrgent
                Case 7
                    Value = RepeatTimes
                Case 8
                    Value = RepeatInterval
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
                    TheSessionID = value
                Case 2
                    TheDevice = value
                Case 3
                    ArchType = value
                Case 4
                    ArchTime = value
                Case 5
                    QueryTime = value
                Case 6
                    IsUrgent = value
                Case 7
                    RepeatTimes = value
                Case 8
                    RepeatInterval = value
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
                    Return "TheSessionID"
                Case 2
                    Return "TheDevice"
                Case 3
                    Return "ArchType"
                Case 4
                    Return "ArchTime"
                Case 5
                    Return "QueryTime"
                Case 6
                    Return "IsUrgent"
                Case 7
                    Return "RepeatTimes"
                Case 8
                    Return "RepeatInterval"
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
             if TheSessionID is nothing then
               dr("TheSessionID") =system.dbnull.value
               dr("TheSessionID_ID") =System.Guid.Empty
             else
               dr("TheSessionID") =TheSessionID.BRIEF
               dr("TheSessionID_ID") =TheSessionID.ID
             end if 
             if TheDevice is nothing then
               dr("TheDevice") =system.dbnull.value
               dr("TheDevice_ID") =System.Guid.Empty
             else
               dr("TheDevice") =TheDevice.BRIEF
               dr("TheDevice_ID") =TheDevice.ID
             end if 
             if ArchType is nothing then
               dr("ArchType") =system.dbnull.value
               dr("ArchType_ID") =System.Guid.Empty
             else
               dr("ArchType") =ArchType.BRIEF
               dr("ArchType_ID") =ArchType.ID
             end if 
             dr("ArchTime") =ArchTime
             dr("QueryTime") =QueryTime
             select case IsUrgent
            case enumBoolean.Boolean_Da
              dr ("IsUrgent")  = "Да"
              dr ("IsUrgent_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsUrgent")  = "Нет"
              dr ("IsUrgent_VAL")  = 0
              end select 'IsUrgent
             dr("RepeatTimes") =RepeatTimes
             dr("RepeatInterval") =RepeatInterval
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
          if m_TheSessionID.Equals(System.Guid.Empty) then
            nv.Add("TheSessionID", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheSessionID", Application.Session.GetProvider.ID2Param(m_TheSessionID), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_TheDevice.Equals(System.Guid.Empty) then
            nv.Add("TheDevice", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheDevice", Application.Session.GetProvider.ID2Param(m_TheDevice), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_ArchType.Equals(System.Guid.Empty) then
            nv.Add("ArchType", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("ArchType", Application.Session.GetProvider.ID2Param(m_ArchType), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if ArchTime=System.DateTime.MinValue then
            nv.Add("ArchTime", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("ArchTime", ArchTime, dbtype.DATETIME)
          end if 
          if QueryTime=System.DateTime.MinValue then
            nv.Add("QueryTime", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("QueryTime", QueryTime, dbtype.DATETIME)
          end if 
          nv.Add("IsUrgent", IsUrgent, dbtype.int16)
          nv.Add("RepeatTimes", RepeatTimes, dbtype.Int32)
          nv.Add("RepeatInterval", RepeatInterval, dbtype.Int32)
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
      If reader.Table.Columns.Contains("TheSessionID") Then
          if isdbnull(reader.item("TheSessionID")) then
            If reader.Table.Columns.Contains("TheSessionID") Then m_TheSessionID = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheSessionID") Then m_TheSessionID= New System.Guid(reader.item("TheSessionID").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("TheDevice") Then
          if isdbnull(reader.item("TheDevice")) then
            If reader.Table.Columns.Contains("TheDevice") Then m_TheDevice = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheDevice") Then m_TheDevice= New System.Guid(reader.item("TheDevice").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("ArchType") Then
          if isdbnull(reader.item("ArchType")) then
            If reader.Table.Columns.Contains("ArchType") Then m_ArchType = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ArchType") Then m_ArchType= New System.Guid(reader.item("ArchType").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("ArchTime") Then
          if isdbnull(reader.item("ArchTime")) then
            If reader.Table.Columns.Contains("ArchTime") Then m_ArchTime = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("ArchTime") Then m_ArchTime=reader.item("ArchTime")
          end if 
      end if 
      If reader.Table.Columns.Contains("QueryTime") Then
          if isdbnull(reader.item("QueryTime")) then
            If reader.Table.Columns.Contains("QueryTime") Then m_QueryTime = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("QueryTime") Then m_QueryTime=reader.item("QueryTime")
          end if 
      end if 
          If reader.Table.Columns.Contains("IsUrgent") Then m_IsUrgent=reader.item("IsUrgent")
          If reader.Table.Columns.Contains("RepeatTimes") Then m_RepeatTimes=reader.item("RepeatTimes")
          If reader.Table.Columns.Contains("RepeatInterval") Then m_RepeatInterval=reader.item("RepeatInterval")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Сессия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheSessionID() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TheSessionID = me.application.Findrowobject("the_Session",m_TheSessionID)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TheSessionID = Value.id
                else
                   m_TheSessionID=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тепловычислитель
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheDevice() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TheDevice = me.application.Findrowobject("TPLT_BDEVICES",m_TheDevice)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TheDevice = Value.id
                else
                   m_TheDevice=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тип архива
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ArchType() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                ArchType = me.application.Findrowobject("TPLD_PARAMTYPE",m_ArchType)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_ArchType = Value.id
                else
                   m_ArchType=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Время
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ArchTime() As DATE
            Get
                LoadFromDatabase()
                ArchTime = m_ArchTime
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_ArchTime = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Время  постановки запроса
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property QueryTime() As DATE
            Get
                LoadFromDatabase()
                QueryTime = m_QueryTime
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_QueryTime = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Срочный запрос
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsUrgent() As enumBoolean
            Get
                LoadFromDatabase()
                IsUrgent = m_IsUrgent
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsUrgent = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Количество повторений при ошибке
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property RepeatTimes() As long
            Get
                LoadFromDatabase()
                RepeatTimes = m_RepeatTimes
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_RepeatTimes = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Интервал между повторами
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property RepeatInterval() As long
            Get
                LoadFromDatabase()
                RepeatInterval = m_RepeatInterval
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_RepeatInterval = Value
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
            m_TheSessionID = new system.guid(node.Attributes.GetNamedItem("TheSessionID").Value)
            m_TheDevice = new system.guid(node.Attributes.GetNamedItem("TheDevice").Value)
            m_ArchType = new system.guid(node.Attributes.GetNamedItem("ArchType").Value)
            m_ArchTime = System.DateTime.MinValue
            ArchTime = m_ArchTime.AddTicks( node.Attributes.GetNamedItem("ArchTime").Value)
            m_QueryTime = System.DateTime.MinValue
            QueryTime = m_QueryTime.AddTicks( node.Attributes.GetNamedItem("QueryTime").Value)
            IsUrgent = node.Attributes.GetNamedItem("IsUrgent").Value
            RepeatTimes = node.Attributes.GetNamedItem("RepeatTimes").Value
            RepeatInterval = node.Attributes.GetNamedItem("RepeatInterval").Value
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
          node.SetAttribute("TheSessionID", m_TheSessionID.tostring)  
          node.SetAttribute("TheDevice", m_TheDevice.tostring)  
          node.SetAttribute("ArchType", m_ArchType.tostring)  
         ' if ArchTime = System.DateTime.MinValue then ArchTime=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("ArchTime", ArchTime.Ticks)  
         ' if QueryTime = System.DateTime.MinValue then QueryTime=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("QueryTime", QueryTime.Ticks)  
          node.SetAttribute("IsUrgent", IsUrgent)  
          node.SetAttribute("RepeatTimes", RepeatTimes)  
          node.SetAttribute("RepeatInterval", RepeatInterval)  
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
