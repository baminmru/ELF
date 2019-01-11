
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace TPLD


''' <summary>
'''Реализация строки раздела Снабжающая организация
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLD_SNAB
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CNAME  as String


''' <summary>
'''Локальная переменная для поля Адрес
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CADDRESS  as String


''' <summary>
'''Локальная переменная для поля Контактное лицо
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CFIO  as String


''' <summary>
'''Локальная переменная для поля Телефон
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CPHONE  as String


''' <summary>
'''Локальная переменная для поля Регион
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CREGION  as String


''' <summary>
'''Локальная переменная для поля Поставщик
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Supplier  as System.Guid



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_CNAME=   
            ' m_CADDRESS=   
            ' m_CFIO=   
            ' m_CPHONE=   
            ' m_CREGION=   
            ' m_Supplier=   
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
                    Value = CNAME
                Case 2
                    Value = CADDRESS
                Case 3
                    Value = CFIO
                Case 4
                    Value = CPHONE
                Case 5
                    Value = CREGION
                Case 6
                    Value = Supplier
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
                    CNAME = value
                Case 2
                    CADDRESS = value
                Case 3
                    CFIO = value
                Case 4
                    CPHONE = value
                Case 5
                    CREGION = value
                Case 6
                    Supplier = value
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
                    Return "CNAME"
                Case 2
                    Return "CADDRESS"
                Case 3
                    Return "CFIO"
                Case 4
                    Return "CPHONE"
                Case 5
                    Return "CREGION"
                Case 6
                    Return "Supplier"
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
             dr("CNAME") =CNAME
             dr("CADDRESS") =CADDRESS
             dr("CFIO") =CFIO
             dr("CPHONE") =CPHONE
             dr("CREGION") =CREGION
             if Supplier is nothing then
               dr("Supplier") =system.dbnull.value
               dr("Supplier_ID") =System.Guid.Empty
             else
               dr("Supplier") =Supplier.BRIEF
               dr("Supplier_ID") =Supplier.ID
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
          nv.Add("CNAME", CNAME, dbtype.string)
          nv.Add("CADDRESS", CADDRESS, dbtype.string)
          nv.Add("CFIO", CFIO, dbtype.string)
          nv.Add("CPHONE", CPHONE, dbtype.string)
          nv.Add("CREGION", CREGION, dbtype.string)
          if m_Supplier.Equals(System.Guid.Empty) then
            nv.Add("Supplier", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("Supplier", Application.Session.GetProvider.ID2Param(m_Supplier), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
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
          If reader.Table.Columns.Contains("CNAME") Then m_CNAME=reader.item("CNAME").ToString()
          If reader.Table.Columns.Contains("CADDRESS") Then m_CADDRESS=reader.item("CADDRESS").ToString()
          If reader.Table.Columns.Contains("CFIO") Then m_CFIO=reader.item("CFIO").ToString()
          If reader.Table.Columns.Contains("CPHONE") Then m_CPHONE=reader.item("CPHONE").ToString()
          If reader.Table.Columns.Contains("CREGION") Then m_CREGION=reader.item("CREGION").ToString()
      If reader.Table.Columns.Contains("Supplier") Then
          if isdbnull(reader.item("Supplier")) then
            If reader.Table.Columns.Contains("Supplier") Then m_Supplier = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("Supplier") Then m_Supplier= New System.Guid(reader.item("Supplier").ToString())
          end if 
      end if 
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Название
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CNAME() As String
            Get
                LoadFromDatabase()
                CNAME = m_CNAME
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_CNAME = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Адрес
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CADDRESS() As String
            Get
                LoadFromDatabase()
                CADDRESS = m_CADDRESS
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_CADDRESS = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Контактное лицо
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CFIO() As String
            Get
                LoadFromDatabase()
                CFIO = m_CFIO
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_CFIO = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Телефон
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CPHONE() As String
            Get
                LoadFromDatabase()
                CPHONE = m_CPHONE
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_CPHONE = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Регион
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CREGION() As String
            Get
                LoadFromDatabase()
                CREGION = m_CREGION
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_CREGION = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Поставщик
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Supplier() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                Supplier = me.application.Findrowobject("TPLD_SNABTOP",m_Supplier)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_Supplier = Value.id
                else
                   m_Supplier=System.Guid.Empty
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
            CNAME = node.Attributes.GetNamedItem("CNAME").Value
            CADDRESS = node.Attributes.GetNamedItem("CADDRESS").Value
            CFIO = node.Attributes.GetNamedItem("CFIO").Value
            CPHONE = node.Attributes.GetNamedItem("CPHONE").Value
            CREGION = node.Attributes.GetNamedItem("CREGION").Value
            m_Supplier = new system.guid(node.Attributes.GetNamedItem("Supplier").Value)
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
          node.SetAttribute("CNAME", CNAME)  
          node.SetAttribute("CADDRESS", CADDRESS)  
          node.SetAttribute("CFIO", CFIO)  
          node.SetAttribute("CPHONE", CPHONE)  
          node.SetAttribute("CREGION", CREGION)  
          node.SetAttribute("Supplier", m_Supplier.tostring)  
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
