
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace TPLT


''' <summary>
'''Реализация строки раздела Граничные значения
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLT_VALUEBOUNDS
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Параметр
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_PNAME  as System.Guid


''' <summary>
'''Локальная переменная для поля Тип архива
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_PTYPE  as System.Guid


''' <summary>
'''Локальная переменная для поля Минимальное значение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_PMIN  as double


''' <summary>
'''Локальная переменная для поля Максимальное значение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_PMAX  as double


''' <summary>
'''Локальная переменная для поля Проверять на минимум
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ISMIN  as enumBoolean


''' <summary>
'''Локальная переменная для поля Проверять на максимум
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ISMAX  as enumBoolean



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_PNAME=   
            ' m_PTYPE=   
            ' m_PMIN=   
            ' m_PMAX=   
            ' m_ISMIN=   
            ' m_ISMAX=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 6
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
                    Value = PNAME
                Case 2
                    Value = PTYPE
                Case 3
                    Value = PMIN
                Case 4
                    Value = PMAX
                Case 5
                    Value = ISMIN
                Case 6
                    Value = ISMAX
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
                    PNAME = value
                Case 2
                    PTYPE = value
                Case 3
                    PMIN = value
                Case 4
                    PMAX = value
                Case 5
                    ISMIN = value
                Case 6
                    ISMAX = value
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
                    Return "PNAME"
                Case 2
                    Return "PTYPE"
                Case 3
                    Return "PMIN"
                Case 4
                    Return "PMAX"
                Case 5
                    Return "ISMIN"
                Case 6
                    Return "ISMAX"
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
             if PNAME is nothing then
               dr("PNAME") =system.dbnull.value
               dr("PNAME_ID") =System.Guid.Empty
             else
               dr("PNAME") =PNAME.BRIEF
               dr("PNAME_ID") =PNAME.ID
             end if 
             if PTYPE is nothing then
               dr("PTYPE") =system.dbnull.value
               dr("PTYPE_ID") =System.Guid.Empty
             else
               dr("PTYPE") =PTYPE.BRIEF
               dr("PTYPE_ID") =PTYPE.ID
             end if 
             dr("PMIN") =PMIN
             dr("PMAX") =PMAX
             select case ISMIN
            case enumBoolean.Boolean_Da
              dr ("ISMIN")  = "Да"
              dr ("ISMIN_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("ISMIN")  = "Нет"
              dr ("ISMIN_VAL")  = 0
              end select 'ISMIN
             select case ISMAX
            case enumBoolean.Boolean_Da
              dr ("ISMAX")  = "Да"
              dr ("ISMAX_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("ISMAX")  = "Нет"
              dr ("ISMAX_VAL")  = 0
              end select 'ISMAX
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
          if m_PNAME.Equals(System.Guid.Empty) then
            nv.Add("PNAME", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("PNAME", Application.Session.GetProvider.ID2Param(m_PNAME), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_PTYPE.Equals(System.Guid.Empty) then
            nv.Add("PTYPE", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("PTYPE", Application.Session.GetProvider.ID2Param(m_PTYPE), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("PMIN", PMIN, dbtype.double)
          nv.Add("PMAX", PMAX, dbtype.double)
          nv.Add("ISMIN", ISMIN, dbtype.int16)
          nv.Add("ISMAX", ISMAX, dbtype.int16)
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
      If reader.Table.Columns.Contains("PNAME") Then
          if isdbnull(reader.item("PNAME")) then
            If reader.Table.Columns.Contains("PNAME") Then m_PNAME = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("PNAME") Then m_PNAME= New System.Guid(reader.item("PNAME").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("PTYPE") Then
          if isdbnull(reader.item("PTYPE")) then
            If reader.Table.Columns.Contains("PTYPE") Then m_PTYPE = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("PTYPE") Then m_PTYPE= New System.Guid(reader.item("PTYPE").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("PMIN") Then m_PMIN=reader.item("PMIN")
          If reader.Table.Columns.Contains("PMAX") Then m_PMAX=reader.item("PMAX")
          If reader.Table.Columns.Contains("ISMIN") Then m_ISMIN=reader.item("ISMIN")
          If reader.Table.Columns.Contains("ISMAX") Then m_ISMAX=reader.item("ISMAX")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Параметр
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property PNAME() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                PNAME = me.application.Findrowobject("TPLD_PARAM",m_PNAME)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_PNAME = Value.id
                else
                   m_PNAME=System.Guid.Empty
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
        Public Property PTYPE() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                PTYPE = me.application.Findrowobject("TPLD_PARAMTYPE",m_PTYPE)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_PTYPE = Value.id
                else
                   m_PTYPE=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Минимальное значение
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property PMIN() As double
            Get
                LoadFromDatabase()
                PMIN = m_PMIN
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_PMIN = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Максимальное значение
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property PMAX() As double
            Get
                LoadFromDatabase()
                PMAX = m_PMAX
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_PMAX = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Проверять на минимум
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ISMIN() As enumBoolean
            Get
                LoadFromDatabase()
                ISMIN = m_ISMIN
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_ISMIN = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Проверять на максимум
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ISMAX() As enumBoolean
            Get
                LoadFromDatabase()
                ISMAX = m_ISMAX
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_ISMAX = Value
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
            m_PNAME = new system.guid(node.Attributes.GetNamedItem("PNAME").Value)
            m_PTYPE = new system.guid(node.Attributes.GetNamedItem("PTYPE").Value)
            PMIN = node.Attributes.GetNamedItem("PMIN").Value
            PMAX = node.Attributes.GetNamedItem("PMAX").Value
            ISMIN = node.Attributes.GetNamedItem("ISMIN").Value
            ISMAX = node.Attributes.GetNamedItem("ISMAX").Value
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
          node.SetAttribute("PNAME", m_PNAME.tostring)  
          node.SetAttribute("PTYPE", m_PTYPE.tostring)  
          node.SetAttribute("PMIN", PMIN)  
          node.SetAttribute("PMAX", PMAX)  
          node.SetAttribute("ISMIN", ISMIN)  
          node.SetAttribute("ISMAX", ISMAX)  
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
