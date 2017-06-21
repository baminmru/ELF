
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace bpu


''' <summary>
'''Реализация строки раздела Данные сотрудника
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class iu_u_def
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Клиент
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_theClient  as System.Guid


''' <summary>
'''Локальная переменная для поля Фамилия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_lastname  as String


''' <summary>
'''Локальная переменная для поля Имя
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_name  as String


''' <summary>
'''Локальная переменная для поля Отчество
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_surname  as String


''' <summary>
'''Локальная переменная для поля Роль в производстве
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_curRole  as System.Guid


''' <summary>
'''Локальная переменная для поля Оповещать по почте
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_sendtomail  as enumBoolean


''' <summary>
'''Локальная переменная для поля Удаленная работа
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_freelancer  as enumBoolean


''' <summary>
'''Локальная переменная для поля e-mail
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_email  as String


''' <summary>
'''Локальная переменная для поля Телефон
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_thephone  as String


''' <summary>
'''Локальная переменная для поля Имя для входа
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_login  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_theClient=   
            ' m_lastname=   
            ' m_name=   
            ' m_surname=   
            ' m_curRole=   
            ' m_sendtomail=   
            ' m_freelancer=   
            ' m_email=   
            ' m_thephone=   
            ' m_login=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 10
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
                    Value = theClient
                Case 2
                    Value = lastname
                Case 3
                    Value = name
                Case 4
                    Value = surname
                Case 5
                    Value = curRole
                Case 6
                    Value = sendtomail
                Case 7
                    Value = freelancer
                Case 8
                    Value = email
                Case 9
                    Value = thephone
                Case 10
                    Value = login
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
                    theClient = value
                Case 2
                    lastname = value
                Case 3
                    name = value
                Case 4
                    surname = value
                Case 5
                    curRole = value
                Case 6
                    sendtomail = value
                Case 7
                    freelancer = value
                Case 8
                    email = value
                Case 9
                    thephone = value
                Case 10
                    login = value
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
                    Return "theClient"
                Case 2
                    Return "lastname"
                Case 3
                    Return "name"
                Case 4
                    Return "surname"
                Case 5
                    Return "curRole"
                Case 6
                    Return "sendtomail"
                Case 7
                    Return "freelancer"
                Case 8
                    Return "email"
                Case 9
                    Return "thephone"
                Case 10
                    Return "login"
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
             if theClient is nothing then
               dr("theClient") =system.dbnull.value
               dr("theClient_ID") =System.Guid.Empty
             else
               dr("theClient") =theClient.BRIEF
               dr("theClient_ID") =theClient.ID
             end if 
             dr("lastname") =lastname
             dr("name") =name
             dr("surname") =surname
             if curRole is nothing then
               dr("curRole") =system.dbnull.value
               dr("curRole_ID") =System.Guid.Empty
             else
               dr("curRole") =curRole.BRIEF
               dr("curRole_ID") =curRole.ID
             end if 
             select case sendtomail
            case enumBoolean.Boolean_Da
              dr ("sendtomail")  = "Да"
              dr ("sendtomail_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("sendtomail")  = "Нет"
              dr ("sendtomail_VAL")  = 0
              end select 'sendtomail
             select case freelancer
            case enumBoolean.Boolean_Da
              dr ("freelancer")  = "Да"
              dr ("freelancer_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("freelancer")  = "Нет"
              dr ("freelancer_VAL")  = 0
              end select 'freelancer
             dr("email") =email
             dr("thephone") =thephone
             dr("login") =login
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
          if m_theClient.Equals(System.Guid.Empty) then
            nv.Add("theClient", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("theClient", Application.Session.GetProvider.ID2Param(m_theClient), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("lastname", lastname, dbtype.string)
          nv.Add("name", name, dbtype.string)
          nv.Add("surname", surname, dbtype.string)
          if m_curRole.Equals(System.Guid.Empty) then
            nv.Add("curRole", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("curRole", Application.Session.GetProvider.ID2Param(m_curRole), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("sendtomail", sendtomail, dbtype.int16)
          nv.Add("freelancer", freelancer, dbtype.int16)
          nv.Add("email", email, dbtype.string)
          nv.Add("thephone", thephone, dbtype.string)
          nv.Add("login", login, dbtype.string)
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
      If reader.Table.Columns.Contains("theClient") Then
          if isdbnull(reader.item("theClient")) then
            If reader.Table.Columns.Contains("theClient") Then m_theClient = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("theClient") Then m_theClient= New System.Guid(reader.item("theClient").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("lastname") Then m_lastname=reader.item("lastname").ToString()
          If reader.Table.Columns.Contains("name") Then m_name=reader.item("name").ToString()
          If reader.Table.Columns.Contains("surname") Then m_surname=reader.item("surname").ToString()
      If reader.Table.Columns.Contains("curRole") Then
          if isdbnull(reader.item("curRole")) then
            If reader.Table.Columns.Contains("curRole") Then m_curRole = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("curRole") Then m_curRole= New System.Guid(reader.item("curRole").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("sendtomail") Then m_sendtomail=reader.item("sendtomail")
          If reader.Table.Columns.Contains("freelancer") Then m_freelancer=reader.item("freelancer")
          If reader.Table.Columns.Contains("email") Then m_email=reader.item("email").ToString()
          If reader.Table.Columns.Contains("thephone") Then m_thephone=reader.item("thephone").ToString()
          If reader.Table.Columns.Contains("login") Then m_login=reader.item("login").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Клиент
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property theClient() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                theClient = me.application.Findrowobject("bpc_info",m_theClient)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_theClient = Value.id
                else
                   m_theClient=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Фамилия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property lastname() As String
            Get
                LoadFromDatabase()
                lastname = m_lastname
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_lastname = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Имя
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
'''Доступ к полю Отчество
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property surname() As String
            Get
                LoadFromDatabase()
                surname = m_surname
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_surname = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Роль в производстве
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property curRole() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                curRole = me.application.Findrowobject("iu_crole",m_curRole)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_curRole = Value.id
                else
                   m_curRole=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Оповещать по почте
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property sendtomail() As enumBoolean
            Get
                LoadFromDatabase()
                sendtomail = m_sendtomail
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_sendtomail = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Удаленная работа
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property freelancer() As enumBoolean
            Get
                LoadFromDatabase()
                freelancer = m_freelancer
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_freelancer = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю e-mail
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property email() As String
            Get
                LoadFromDatabase()
                email = m_email
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_email = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Телефон
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property thephone() As String
            Get
                LoadFromDatabase()
                thephone = m_thephone
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_thephone = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Имя для входа
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property login() As String
            Get
                LoadFromDatabase()
                login = m_login
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_login = Value
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
            m_theClient = new system.guid(node.Attributes.GetNamedItem("theClient").Value)
            lastname = node.Attributes.GetNamedItem("lastname").Value
            name = node.Attributes.GetNamedItem("name").Value
            surname = node.Attributes.GetNamedItem("surname").Value
            m_curRole = new system.guid(node.Attributes.GetNamedItem("curRole").Value)
            sendtomail = node.Attributes.GetNamedItem("sendtomail").Value
            freelancer = node.Attributes.GetNamedItem("freelancer").Value
            email = node.Attributes.GetNamedItem("email").Value
            thephone = node.Attributes.GetNamedItem("thephone").Value
            login = node.Attributes.GetNamedItem("login").Value
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
          node.SetAttribute("theClient", m_theClient.tostring)  
          node.SetAttribute("lastname", lastname)  
          node.SetAttribute("name", name)  
          node.SetAttribute("surname", surname)  
          node.SetAttribute("curRole", m_curRole.tostring)  
          node.SetAttribute("sendtomail", sendtomail)  
          node.SetAttribute("freelancer", freelancer)  
          node.SetAttribute("email", email)  
          node.SetAttribute("thephone", thephone)  
          node.SetAttribute("login", login)  
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
