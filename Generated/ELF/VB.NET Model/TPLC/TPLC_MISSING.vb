
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace TPLC


''' <summary>
'''Реализация строки раздела Пропущенные архивы
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLC_MISSING
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Тип архива
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AType  as System.Guid


''' <summary>
'''Локальная переменная для поля Дата архива
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ADate  as DATE


''' <summary>
'''Локальная переменная для поля Количество попыток  опроса
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_QueryCount  as long



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_AType=   
            ' m_ADate=   
            ' m_QueryCount=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 3
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
                    Value = AType
                Case 2
                    Value = ADate
                Case 3
                    Value = QueryCount
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
                    AType = value
                Case 2
                    ADate = value
                Case 3
                    QueryCount = value
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
                    Return "AType"
                Case 2
                    Return "ADate"
                Case 3
                    Return "QueryCount"
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
             if AType is nothing then
               dr("AType") =system.dbnull.value
               dr("AType_ID") =System.Guid.Empty
             else
               dr("AType") =AType.BRIEF
               dr("AType_ID") =AType.ID
             end if 
             dr("ADate") =ADate
             dr("QueryCount") =QueryCount
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
          if m_AType.Equals(System.Guid.Empty) then
            nv.Add("AType", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("AType", Application.Session.GetProvider.ID2Param(m_AType), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if ADate=System.DateTime.MinValue then
            nv.Add("ADate", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("ADate", ADate, dbtype.DATETIME)
          end if 
          nv.Add("QueryCount", QueryCount, dbtype.Int32)
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
      If reader.Table.Columns.Contains("AType") Then
          if isdbnull(reader.item("AType")) then
            If reader.Table.Columns.Contains("AType") Then m_AType = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("AType") Then m_AType= New System.Guid(reader.item("AType").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("ADate") Then
          if isdbnull(reader.item("ADate")) then
            If reader.Table.Columns.Contains("ADate") Then m_ADate = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("ADate") Then m_ADate=reader.item("ADate")
          end if 
      end if 
          If reader.Table.Columns.Contains("QueryCount") Then m_QueryCount=reader.item("QueryCount")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Тип архива
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AType() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                AType = me.application.Findrowobject("TPLD_PARAMTYPE",m_AType)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_AType = Value.id
                else
                   m_AType=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Дата архива
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ADate() As DATE
            Get
                LoadFromDatabase()
                ADate = m_ADate
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_ADate = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Количество попыток  опроса
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property QueryCount() As long
            Get
                LoadFromDatabase()
                QueryCount = m_QueryCount
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_QueryCount = Value
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
            m_AType = new system.guid(node.Attributes.GetNamedItem("AType").Value)
            m_ADate = System.DateTime.MinValue
            ADate = m_ADate.AddTicks( node.Attributes.GetNamedItem("ADate").Value)
            QueryCount = node.Attributes.GetNamedItem("QueryCount").Value
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
          node.SetAttribute("AType", m_AType.tostring)  
         ' if ADate = System.DateTime.MinValue then ADate=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("ADate", ADate.Ticks)  
          node.SetAttribute("QueryCount", QueryCount)  
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
