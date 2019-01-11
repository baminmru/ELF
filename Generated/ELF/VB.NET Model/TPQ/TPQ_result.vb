
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
'''Реализация строки раздела Результат обработки
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPQ_result
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Текстовый результат
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TextResult  as String


''' <summary>
'''Локальная переменная для поля Запись мгновенного архива
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_MomentArch  as System.Guid


''' <summary>
'''Локальная переменная для поля Запись часового архива
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_HourArch  as System.Guid


''' <summary>
'''Локальная переменная для поля Запись суточного архива
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DayArch  as System.Guid


''' <summary>
'''Локальная переменная для поля Запись итогового архива
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TotalArch  as System.Guid


''' <summary>
'''Локальная переменная для поля Обработан с ошибкой
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsError  as enumBoolean


''' <summary>
'''Локальная переменная для поля Протокол
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_LogMessage  as STRING


''' <summary>
'''Локальная переменная для поля Время начала обработки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_StartTime  as DATE


''' <summary>
'''Локальная переменная для поля Время завершения обработки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_EndTime  as DATE



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_TextResult=   
            ' m_MomentArch=   
            ' m_HourArch=   
            ' m_DayArch=   
            ' m_TotalArch=   
            ' m_IsError=   
            ' m_LogMessage=   
            ' m_StartTime=   
            ' m_EndTime=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 9
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
                    Value = TextResult
                Case 2
                    Value = MomentArch
                Case 3
                    Value = HourArch
                Case 4
                    Value = DayArch
                Case 5
                    Value = TotalArch
                Case 6
                    Value = IsError
                Case 7
                    Value = LogMessage
                Case 8
                    Value = StartTime
                Case 9
                    Value = EndTime
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
                    TextResult = value
                Case 2
                    MomentArch = value
                Case 3
                    HourArch = value
                Case 4
                    DayArch = value
                Case 5
                    TotalArch = value
                Case 6
                    IsError = value
                Case 7
                    LogMessage = value
                Case 8
                    StartTime = value
                Case 9
                    EndTime = value
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
                    Return "TextResult"
                Case 2
                    Return "MomentArch"
                Case 3
                    Return "HourArch"
                Case 4
                    Return "DayArch"
                Case 5
                    Return "TotalArch"
                Case 6
                    Return "IsError"
                Case 7
                    Return "LogMessage"
                Case 8
                    Return "StartTime"
                Case 9
                    Return "EndTime"
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
             dr("TextResult") =TextResult
             if MomentArch is nothing then
               dr("MomentArch") =system.dbnull.value
               dr("MomentArch_ID") =System.Guid.Empty
             else
               dr("MomentArch") =MomentArch.BRIEF
               dr("MomentArch_ID") =MomentArch.ID
             end if 
             if HourArch is nothing then
               dr("HourArch") =system.dbnull.value
               dr("HourArch_ID") =System.Guid.Empty
             else
               dr("HourArch") =HourArch.BRIEF
               dr("HourArch_ID") =HourArch.ID
             end if 
             if DayArch is nothing then
               dr("DayArch") =system.dbnull.value
               dr("DayArch_ID") =System.Guid.Empty
             else
               dr("DayArch") =DayArch.BRIEF
               dr("DayArch_ID") =DayArch.ID
             end if 
             if TotalArch is nothing then
               dr("TotalArch") =system.dbnull.value
               dr("TotalArch_ID") =System.Guid.Empty
             else
               dr("TotalArch") =TotalArch.BRIEF
               dr("TotalArch_ID") =TotalArch.ID
             end if 
             select case IsError
            case enumBoolean.Boolean_Da
              dr ("IsError")  = "Да"
              dr ("IsError_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsError")  = "Нет"
              dr ("IsError_VAL")  = 0
              end select 'IsError
             dr("LogMessage") =LogMessage
             dr("StartTime") =StartTime
             dr("EndTime") =EndTime
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
          nv.Add("TextResult", TextResult, dbtype.string)
          if m_MomentArch.Equals(System.Guid.Empty) then
            nv.Add("MomentArch", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("MomentArch", Application.Session.GetProvider.ID2Param(m_MomentArch), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_HourArch.Equals(System.Guid.Empty) then
            nv.Add("HourArch", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("HourArch", Application.Session.GetProvider.ID2Param(m_HourArch), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_DayArch.Equals(System.Guid.Empty) then
            nv.Add("DayArch", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("DayArch", Application.Session.GetProvider.ID2Param(m_DayArch), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_TotalArch.Equals(System.Guid.Empty) then
            nv.Add("TotalArch", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TotalArch", Application.Session.GetProvider.ID2Param(m_TotalArch), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("IsError", IsError, dbtype.int16)
          nv.Add("LogMessage", LogMessage, dbtype.string)
          if StartTime=System.DateTime.MinValue then
            nv.Add("StartTime", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("StartTime", StartTime, dbtype.DATETIME)
          end if 
          if EndTime=System.DateTime.MinValue then
            nv.Add("EndTime", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("EndTime", EndTime, dbtype.DATETIME)
          end if 
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
          If reader.Table.Columns.Contains("TextResult") Then m_TextResult=reader.item("TextResult").ToString()
      If reader.Table.Columns.Contains("MomentArch") Then
          if isdbnull(reader.item("MomentArch")) then
            If reader.Table.Columns.Contains("MomentArch") Then m_MomentArch = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("MomentArch") Then m_MomentArch= New System.Guid(reader.item("MomentArch").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("HourArch") Then
          if isdbnull(reader.item("HourArch")) then
            If reader.Table.Columns.Contains("HourArch") Then m_HourArch = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("HourArch") Then m_HourArch= New System.Guid(reader.item("HourArch").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("DayArch") Then
          if isdbnull(reader.item("DayArch")) then
            If reader.Table.Columns.Contains("DayArch") Then m_DayArch = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("DayArch") Then m_DayArch= New System.Guid(reader.item("DayArch").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("TotalArch") Then
          if isdbnull(reader.item("TotalArch")) then
            If reader.Table.Columns.Contains("TotalArch") Then m_TotalArch = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TotalArch") Then m_TotalArch= New System.Guid(reader.item("TotalArch").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("IsError") Then m_IsError=reader.item("IsError")
          If reader.Table.Columns.Contains("LogMessage") Then m_LogMessage=reader.item("LogMessage").ToString()
      If reader.Table.Columns.Contains("StartTime") Then
          if isdbnull(reader.item("StartTime")) then
            If reader.Table.Columns.Contains("StartTime") Then m_StartTime = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("StartTime") Then m_StartTime=reader.item("StartTime")
          end if 
      end if 
      If reader.Table.Columns.Contains("EndTime") Then
          if isdbnull(reader.item("EndTime")) then
            If reader.Table.Columns.Contains("EndTime") Then m_EndTime = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("EndTime") Then m_EndTime=reader.item("EndTime")
          end if 
      end if 
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Текстовый результат
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TextResult() As String
            Get
                LoadFromDatabase()
                TextResult = m_TextResult
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_TextResult = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Запись мгновенного архива
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property MomentArch() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                MomentArch = me.application.Findrowobject("TPLC_M",m_MomentArch)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_MomentArch = Value.id
                else
                   m_MomentArch=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Запись часового архива
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property HourArch() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                HourArch = me.application.Findrowobject("TPLC_H",m_HourArch)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_HourArch = Value.id
                else
                   m_HourArch=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Запись суточного архива
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DayArch() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                DayArch = me.application.Findrowobject("TPLC_D",m_DayArch)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_DayArch = Value.id
                else
                   m_DayArch=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Запись итогового архива
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TotalArch() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TotalArch = me.application.Findrowobject("TPLC_T",m_TotalArch)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TotalArch = Value.id
                else
                   m_TotalArch=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Обработан с ошибкой
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsError() As enumBoolean
            Get
                LoadFromDatabase()
                IsError = m_IsError
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsError = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Протокол
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property LogMessage() As STRING
            Get
                LoadFromDatabase()
                LogMessage = m_LogMessage
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_LogMessage = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Время начала обработки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property StartTime() As DATE
            Get
                LoadFromDatabase()
                StartTime = m_StartTime
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_StartTime = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Время завершения обработки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property EndTime() As DATE
            Get
                LoadFromDatabase()
                EndTime = m_EndTime
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_EndTime = Value
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
            TextResult = node.Attributes.GetNamedItem("TextResult").Value
            m_MomentArch = new system.guid(node.Attributes.GetNamedItem("MomentArch").Value)
            m_HourArch = new system.guid(node.Attributes.GetNamedItem("HourArch").Value)
            m_DayArch = new system.guid(node.Attributes.GetNamedItem("DayArch").Value)
            m_TotalArch = new system.guid(node.Attributes.GetNamedItem("TotalArch").Value)
            IsError = node.Attributes.GetNamedItem("IsError").Value
            LogMessage = node.Attributes.GetNamedItem("LogMessage").Value
            m_StartTime = System.DateTime.MinValue
            StartTime = m_StartTime.AddTicks( node.Attributes.GetNamedItem("StartTime").Value)
            m_EndTime = System.DateTime.MinValue
            EndTime = m_EndTime.AddTicks( node.Attributes.GetNamedItem("EndTime").Value)
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
          node.SetAttribute("TextResult", TextResult)  
          node.SetAttribute("MomentArch", m_MomentArch.tostring)  
          node.SetAttribute("HourArch", m_HourArch.tostring)  
          node.SetAttribute("DayArch", m_DayArch.tostring)  
          node.SetAttribute("TotalArch", m_TotalArch.tostring)  
          node.SetAttribute("IsError", IsError)  
          node.SetAttribute("LogMessage", LogMessage)  
         ' if StartTime = System.DateTime.MinValue then StartTime=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("StartTime", StartTime.Ticks)  
         ' if EndTime = System.DateTime.MinValue then EndTime=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("EndTime", EndTime.Ticks)  
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
