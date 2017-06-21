
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
'''Реализация строки раздела Параметры для вывода
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLT_MASK
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Тип архива
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_PTYPE  as System.Guid


''' <summary>
'''Локальная переменная для поля Порядок вывода
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_sequence  as long


''' <summary>
'''Локальная переменная для поля Параметр
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_PNAME  as System.Guid


''' <summary>
'''Локальная переменная для поля Формат
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_paramFormat  as String


''' <summary>
'''Локальная переменная для поля Ширина
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_colWidth  as double


''' <summary>
'''Локальная переменная для поля Скрыть
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_phide  as enumBoolean



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_PTYPE=   
            ' m_sequence=   
            ' m_PNAME=   
            ' m_paramFormat=   
            ' m_colWidth=   
            ' m_phide=   
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
                    Value = PTYPE
                Case 2
                    Value = sequence
                Case 3
                    Value = PNAME
                Case 4
                    Value = paramFormat
                Case 5
                    Value = colWidth
                Case 6
                    Value = phide
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
                    PTYPE = value
                Case 2
                    sequence = value
                Case 3
                    PNAME = value
                Case 4
                    paramFormat = value
                Case 5
                    colWidth = value
                Case 6
                    phide = value
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
                    Return "PTYPE"
                Case 2
                    Return "sequence"
                Case 3
                    Return "PNAME"
                Case 4
                    Return "paramFormat"
                Case 5
                    Return "colWidth"
                Case 6
                    Return "phide"
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
             if PTYPE is nothing then
               dr("PTYPE") =system.dbnull.value
               dr("PTYPE_ID") =System.Guid.Empty
             else
               dr("PTYPE") =PTYPE.BRIEF
               dr("PTYPE_ID") =PTYPE.ID
             end if 
             dr("sequence") =sequence
             if PNAME is nothing then
               dr("PNAME") =system.dbnull.value
               dr("PNAME_ID") =System.Guid.Empty
             else
               dr("PNAME") =PNAME.BRIEF
               dr("PNAME_ID") =PNAME.ID
             end if 
             dr("paramFormat") =paramFormat
             dr("colWidth") =colWidth
             select case phide
            case enumBoolean.Boolean_Da
              dr ("phide")  = "Да"
              dr ("phide_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("phide")  = "Нет"
              dr ("phide_VAL")  = 0
              end select 'phide
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
          if m_PTYPE.Equals(System.Guid.Empty) then
            nv.Add("PTYPE", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("PTYPE", Application.Session.GetProvider.ID2Param(m_PTYPE), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("sequence", sequence, dbtype.Int32)
          if m_PNAME.Equals(System.Guid.Empty) then
            nv.Add("PNAME", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("PNAME", Application.Session.GetProvider.ID2Param(m_PNAME), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("paramFormat", paramFormat, dbtype.string)
          nv.Add("colWidth", colWidth, dbtype.double)
          nv.Add("phide", phide, dbtype.int16)
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
      If reader.Table.Columns.Contains("PTYPE") Then
          if isdbnull(reader.item("PTYPE")) then
            If reader.Table.Columns.Contains("PTYPE") Then m_PTYPE = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("PTYPE") Then m_PTYPE= New System.Guid(reader.item("PTYPE").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("sequence") Then m_sequence=reader.item("sequence")
      If reader.Table.Columns.Contains("PNAME") Then
          if isdbnull(reader.item("PNAME")) then
            If reader.Table.Columns.Contains("PNAME") Then m_PNAME = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("PNAME") Then m_PNAME= New System.Guid(reader.item("PNAME").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("paramFormat") Then m_paramFormat=reader.item("paramFormat").ToString()
          If reader.Table.Columns.Contains("colWidth") Then m_colWidth=reader.item("colWidth")
          If reader.Table.Columns.Contains("phide") Then m_phide=reader.item("phide")
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
'''Доступ к полю Порядок вывода
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property sequence() As long
            Get
                LoadFromDatabase()
                sequence = m_sequence
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_sequence = Value
                ChangeTime = Now
            End Set
        End Property


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
'''Доступ к полю Формат
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property paramFormat() As String
            Get
                LoadFromDatabase()
                paramFormat = m_paramFormat
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_paramFormat = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Ширина
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property colWidth() As double
            Get
                LoadFromDatabase()
                colWidth = m_colWidth
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_colWidth = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Скрыть
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property phide() As enumBoolean
            Get
                LoadFromDatabase()
                phide = m_phide
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_phide = Value
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
            m_PTYPE = new system.guid(node.Attributes.GetNamedItem("PTYPE").Value)
            sequence = node.Attributes.GetNamedItem("sequence").Value
            m_PNAME = new system.guid(node.Attributes.GetNamedItem("PNAME").Value)
            paramFormat = node.Attributes.GetNamedItem("paramFormat").Value
            colWidth = node.Attributes.GetNamedItem("colWidth").Value
            phide = node.Attributes.GetNamedItem("phide").Value
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
          node.SetAttribute("PTYPE", m_PTYPE.tostring)  
          node.SetAttribute("sequence", sequence)  
          node.SetAttribute("PNAME", m_PNAME.tostring)  
          node.SetAttribute("paramFormat", paramFormat)  
          node.SetAttribute("colWidth", colWidth)  
          node.SetAttribute("phide", phide)  
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
