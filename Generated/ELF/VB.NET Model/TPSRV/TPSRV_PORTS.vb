
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace TPSRV


''' <summary>
'''Реализация строки раздела Ком порты
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPSRV_PORTS
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Номер порта
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_PortName  as String


''' <summary>
'''Локальная переменная для поля Может использоваться сервером
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsUsable  as enumBoolean


''' <summary>
'''Локальная переменная для поля Занят
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsUsed  as enumBoolean


''' <summary>
'''Локальная переменная для поля Занят до
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_UsedUntil  as DATE



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_PortName=   
            ' m_IsUsable=   
            ' m_IsUsed=   
            ' m_UsedUntil=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 4
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
                    Value = PortName
                Case 2
                    Value = IsUsable
                Case 3
                    Value = IsUsed
                Case 4
                    Value = UsedUntil
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
                    PortName = value
                Case 2
                    IsUsable = value
                Case 3
                    IsUsed = value
                Case 4
                    UsedUntil = value
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
                    Return "PortName"
                Case 2
                    Return "IsUsable"
                Case 3
                    Return "IsUsed"
                Case 4
                    Return "UsedUntil"
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
             dr("PortName") =PortName
             select case IsUsable
            case enumBoolean.Boolean_Da
              dr ("IsUsable")  = "Да"
              dr ("IsUsable_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsUsable")  = "Нет"
              dr ("IsUsable_VAL")  = 0
              end select 'IsUsable
             select case IsUsed
            case enumBoolean.Boolean_Da
              dr ("IsUsed")  = "Да"
              dr ("IsUsed_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsUsed")  = "Нет"
              dr ("IsUsed_VAL")  = 0
              end select 'IsUsed
             dr("UsedUntil") =UsedUntil
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
          nv.Add("PortName", PortName, dbtype.string)
          nv.Add("IsUsable", IsUsable, dbtype.int16)
          nv.Add("IsUsed", IsUsed, dbtype.int16)
          if UsedUntil=System.DateTime.MinValue then
            nv.Add("UsedUntil", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("UsedUntil", UsedUntil, dbtype.DATETIME)
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
          If reader.Table.Columns.Contains("PortName") Then m_PortName=reader.item("PortName").ToString()
          If reader.Table.Columns.Contains("IsUsable") Then m_IsUsable=reader.item("IsUsable")
          If reader.Table.Columns.Contains("IsUsed") Then m_IsUsed=reader.item("IsUsed")
      If reader.Table.Columns.Contains("UsedUntil") Then
          if isdbnull(reader.item("UsedUntil")) then
            If reader.Table.Columns.Contains("UsedUntil") Then m_UsedUntil = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("UsedUntil") Then m_UsedUntil=reader.item("UsedUntil")
          end if 
      end if 
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Номер порта
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property PortName() As String
            Get
                LoadFromDatabase()
                PortName = m_PortName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_PortName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Может использоваться сервером
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsUsable() As enumBoolean
            Get
                LoadFromDatabase()
                IsUsable = m_IsUsable
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsUsable = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Занят
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsUsed() As enumBoolean
            Get
                LoadFromDatabase()
                IsUsed = m_IsUsed
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsUsed = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Занят до
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property UsedUntil() As DATE
            Get
                LoadFromDatabase()
                UsedUntil = m_UsedUntil
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_UsedUntil = Value
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
            PortName = node.Attributes.GetNamedItem("PortName").Value
            IsUsable = node.Attributes.GetNamedItem("IsUsable").Value
            IsUsed = node.Attributes.GetNamedItem("IsUsed").Value
            m_UsedUntil = System.DateTime.MinValue
            UsedUntil = m_UsedUntil.AddTicks( node.Attributes.GetNamedItem("UsedUntil").Value)
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
          node.SetAttribute("PortName", PortName)  
          node.SetAttribute("IsUsable", IsUsable)  
          node.SetAttribute("IsUsed", IsUsed)  
         ' if UsedUntil = System.DateTime.MinValue then UsedUntil=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("UsedUntil", UsedUntil.Ticks)  
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
