
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace TPLS


''' <summary>
'''Реализация строки раздела Параметры на схеме
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLS_PARAM
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Тип архива
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ArchType  as System.Guid


''' <summary>
'''Локальная переменная для поля Параметр
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Param  as System.Guid


''' <summary>
'''Локальная переменная для поля X
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_POS_LEFT  as double


''' <summary>
'''Локальная переменная для поля Y
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_POS_TOP  as double


''' <summary>
'''Локальная переменная для поля Скрыть
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_HIDEPARAM  as enumBoolean


''' <summary>
'''Локальная переменная для поля Не отображать на схеме
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_HideOnSchema  as enumBoolean



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_ArchType=   
            ' m_Param=   
            ' m_POS_LEFT=   
            ' m_POS_TOP=   
            ' m_HIDEPARAM=   
            ' m_HideOnSchema=   
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
                    Value = ArchType
                Case 2
                    Value = Param
                Case 3
                    Value = POS_LEFT
                Case 4
                    Value = POS_TOP
                Case 5
                    Value = HIDEPARAM
                Case 6
                    Value = HideOnSchema
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
                    ArchType = value
                Case 2
                    Param = value
                Case 3
                    POS_LEFT = value
                Case 4
                    POS_TOP = value
                Case 5
                    HIDEPARAM = value
                Case 6
                    HideOnSchema = value
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
                    Return "ArchType"
                Case 2
                    Return "Param"
                Case 3
                    Return "POS_LEFT"
                Case 4
                    Return "POS_TOP"
                Case 5
                    Return "HIDEPARAM"
                Case 6
                    Return "HideOnSchema"
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
             if ArchType is nothing then
               dr("ArchType") =system.dbnull.value
               dr("ArchType_ID") =System.Guid.Empty
             else
               dr("ArchType") =ArchType.BRIEF
               dr("ArchType_ID") =ArchType.ID
             end if 
             if Param is nothing then
               dr("Param") =system.dbnull.value
               dr("Param_ID") =System.Guid.Empty
             else
               dr("Param") =Param.BRIEF
               dr("Param_ID") =Param.ID
             end if 
             dr("POS_LEFT") =POS_LEFT
             dr("POS_TOP") =POS_TOP
             select case HIDEPARAM
            case enumBoolean.Boolean_Da
              dr ("HIDEPARAM")  = "Да"
              dr ("HIDEPARAM_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("HIDEPARAM")  = "Нет"
              dr ("HIDEPARAM_VAL")  = 0
              end select 'HIDEPARAM
             select case HideOnSchema
            case enumBoolean.Boolean_Da
              dr ("HideOnSchema")  = "Да"
              dr ("HideOnSchema_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("HideOnSchema")  = "Нет"
              dr ("HideOnSchema_VAL")  = 0
              end select 'HideOnSchema
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
          if m_ArchType.Equals(System.Guid.Empty) then
            nv.Add("ArchType", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("ArchType", Application.Session.GetProvider.ID2Param(m_ArchType), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_Param.Equals(System.Guid.Empty) then
            nv.Add("Param", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("Param", Application.Session.GetProvider.ID2Param(m_Param), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("POS_LEFT", POS_LEFT, dbtype.double)
          nv.Add("POS_TOP", POS_TOP, dbtype.double)
          nv.Add("HIDEPARAM", HIDEPARAM, dbtype.int16)
          nv.Add("HideOnSchema", HideOnSchema, dbtype.int16)
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
      If reader.Table.Columns.Contains("ArchType") Then
          if isdbnull(reader.item("ArchType")) then
            If reader.Table.Columns.Contains("ArchType") Then m_ArchType = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ArchType") Then m_ArchType= New System.Guid(reader.item("ArchType").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("Param") Then
          if isdbnull(reader.item("Param")) then
            If reader.Table.Columns.Contains("Param") Then m_Param = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("Param") Then m_Param= New System.Guid(reader.item("Param").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("POS_LEFT") Then m_POS_LEFT=reader.item("POS_LEFT")
          If reader.Table.Columns.Contains("POS_TOP") Then m_POS_TOP=reader.item("POS_TOP")
          If reader.Table.Columns.Contains("HIDEPARAM") Then m_HIDEPARAM=reader.item("HIDEPARAM")
          If reader.Table.Columns.Contains("HideOnSchema") Then m_HideOnSchema=reader.item("HideOnSchema")
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
'''Доступ к полю Параметр
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Param() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                Param = me.application.Findrowobject("TPLD_PARAM",m_Param)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_Param = Value.id
                else
                   m_Param=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю X
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property POS_LEFT() As double
            Get
                LoadFromDatabase()
                POS_LEFT = m_POS_LEFT
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_POS_LEFT = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Y
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property POS_TOP() As double
            Get
                LoadFromDatabase()
                POS_TOP = m_POS_TOP
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_POS_TOP = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Скрыть
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property HIDEPARAM() As enumBoolean
            Get
                LoadFromDatabase()
                HIDEPARAM = m_HIDEPARAM
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_HIDEPARAM = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Не отображать на схеме
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property HideOnSchema() As enumBoolean
            Get
                LoadFromDatabase()
                HideOnSchema = m_HideOnSchema
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_HideOnSchema = Value
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
            m_ArchType = new system.guid(node.Attributes.GetNamedItem("ArchType").Value)
            m_Param = new system.guid(node.Attributes.GetNamedItem("Param").Value)
            POS_LEFT = node.Attributes.GetNamedItem("POS_LEFT").Value
            POS_TOP = node.Attributes.GetNamedItem("POS_TOP").Value
            HIDEPARAM = node.Attributes.GetNamedItem("HIDEPARAM").Value
            HideOnSchema = node.Attributes.GetNamedItem("HideOnSchema").Value
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
          node.SetAttribute("ArchType", m_ArchType.tostring)  
          node.SetAttribute("Param", m_Param.tostring)  
          node.SetAttribute("POS_LEFT", POS_LEFT)  
          node.SetAttribute("POS_TOP", POS_TOP)  
          node.SetAttribute("HIDEPARAM", HIDEPARAM)  
          node.SetAttribute("HideOnSchema", HideOnSchema)  
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
