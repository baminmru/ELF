
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace TPN


''' <summary>
'''Реализация строки раздела Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPN_DEF
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Адрес
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Addr  as String


''' <summary>
'''Локальная переменная для поля Телефон
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ThePhone  as String


''' <summary>
'''Локальная переменная для поля Филиал
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OrgUnit  as System.Guid



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_Addr=   
            ' m_ThePhone=   
            ' m_OrgUnit=   
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
                    Value = Addr
                Case 2
                    Value = ThePhone
                Case 3
                    Value = OrgUnit
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
                    Addr = value
                Case 2
                    ThePhone = value
                Case 3
                    OrgUnit = value
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
                    Return "Addr"
                Case 2
                    Return "ThePhone"
                Case 3
                    Return "OrgUnit"
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
             dr("Addr") =Addr
             dr("ThePhone") =ThePhone
             if OrgUnit is nothing then
               dr("OrgUnit") =system.dbnull.value
               dr("OrgUnit_ID") =System.Guid.Empty
             else
               dr("OrgUnit") =OrgUnit.BRIEF
               dr("OrgUnit_ID") =OrgUnit.ID
             end if 
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
          nv.Add("Addr", Addr, dbtype.string)
          nv.Add("ThePhone", ThePhone, dbtype.string)
          if m_OrgUnit.Equals(System.Guid.Empty) then
            nv.Add("OrgUnit", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("OrgUnit", Application.Session.GetProvider.ID2Param(m_OrgUnit), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
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
          If reader.Table.Columns.Contains("Addr") Then m_Addr=reader.item("Addr").ToString()
          If reader.Table.Columns.Contains("ThePhone") Then m_ThePhone=reader.item("ThePhone").ToString()
      If reader.Table.Columns.Contains("OrgUnit") Then
          if isdbnull(reader.item("OrgUnit")) then
            If reader.Table.Columns.Contains("OrgUnit") Then m_OrgUnit = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("OrgUnit") Then m_OrgUnit= New System.Guid(reader.item("OrgUnit").ToString())
          end if 
      end if 
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Адрес
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Addr() As String
            Get
                LoadFromDatabase()
                Addr = m_Addr
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_Addr = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Телефон
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ThePhone() As String
            Get
                LoadFromDatabase()
                ThePhone = m_ThePhone
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_ThePhone = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Филиал
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property OrgUnit() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                OrgUnit = me.application.Findrowobject("TPLD_F",m_OrgUnit)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_OrgUnit = Value.id
                else
                   m_OrgUnit=System.Guid.Empty
                end if
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
            Addr = node.Attributes.GetNamedItem("Addr").Value
            ThePhone = node.Attributes.GetNamedItem("ThePhone").Value
            m_OrgUnit = new system.guid(node.Attributes.GetNamedItem("OrgUnit").Value)
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
          node.SetAttribute("Addr", Addr)  
          node.SetAttribute("ThePhone", ThePhone)  
          node.SetAttribute("OrgUnit", m_OrgUnit.tostring)  
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
