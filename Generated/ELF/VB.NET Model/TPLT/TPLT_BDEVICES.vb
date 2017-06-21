
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
'''Реализация строки раздела Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLT_BDEVICES
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Узел
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheNode  as System.Guid


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Телефон
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ThePhone  as String


''' <summary>
'''Локальная переменная для поля Адрес
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Addr  as STRING


''' <summary>
'''Локальная переменная для поля Устройство
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DEVType  as System.Guid


''' <summary>
'''Локальная переменная для поля Снабжающая орг.
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Shab  as System.Guid


''' <summary>
'''Локальная переменная для поля Группа
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DevGrp  as System.Guid


''' <summary>
'''Локальная переменная для поля Схема подключения
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_THESCHEMA  as System.Guid


''' <summary>
'''Локальная переменная для поля Сервер
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheServer  as System.Guid


''' <summary>
'''Локальная переменная для поля Заблокированно до
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_NPLOCK  as DATE


''' <summary>
'''Локальная переменная для поля Подключен
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CONNECTED  as enumBoolean



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_TheNode=   
            ' m_Name=   
            ' m_ThePhone=   
            ' m_Addr=   
            ' m_DEVType=   
            ' m_Shab=   
            ' m_DevGrp=   
            ' m_THESCHEMA=   
            ' m_TheServer=   
            ' m_NPLOCK=   
            ' m_CONNECTED=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 11
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
                    Value = TheNode
                Case 2
                    Value = Name
                Case 3
                    Value = ThePhone
                Case 4
                    Value = Addr
                Case 5
                    Value = DEVType
                Case 6
                    Value = Shab
                Case 7
                    Value = DevGrp
                Case 8
                    Value = THESCHEMA
                Case 9
                    Value = TheServer
                Case 10
                    Value = NPLOCK
                Case 11
                    Value = CONNECTED
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
                    TheNode = value
                Case 2
                    Name = value
                Case 3
                    ThePhone = value
                Case 4
                    Addr = value
                Case 5
                    DEVType = value
                Case 6
                    Shab = value
                Case 7
                    DevGrp = value
                Case 8
                    THESCHEMA = value
                Case 9
                    TheServer = value
                Case 10
                    NPLOCK = value
                Case 11
                    CONNECTED = value
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
                    Return "TheNode"
                Case 2
                    Return "Name"
                Case 3
                    Return "ThePhone"
                Case 4
                    Return "Addr"
                Case 5
                    Return "DEVType"
                Case 6
                    Return "Shab"
                Case 7
                    Return "DevGrp"
                Case 8
                    Return "THESCHEMA"
                Case 9
                    Return "TheServer"
                Case 10
                    Return "NPLOCK"
                Case 11
                    Return "CONNECTED"
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
             if TheNode is nothing then
               dr("TheNode") =system.dbnull.value
               dr("TheNode_ID") =System.Guid.Empty
             else
               dr("TheNode") =TheNode.BRIEF
               dr("TheNode_ID") =TheNode.ID
             end if 
             dr("Name") =Name
             dr("ThePhone") =ThePhone
             dr("Addr") =Addr
             if DEVType is nothing then
               dr("DEVType") =system.dbnull.value
               dr("DEVType_ID") =System.Guid.Empty
             else
               dr("DEVType") =DEVType.BRIEF
               dr("DEVType_ID") =DEVType.ID
             end if 
             if Shab is nothing then
               dr("Shab") =system.dbnull.value
               dr("Shab_ID") =System.Guid.Empty
             else
               dr("Shab") =Shab.BRIEF
               dr("Shab_ID") =Shab.ID
             end if 
             if DevGrp is nothing then
               dr("DevGrp") =system.dbnull.value
               dr("DevGrp_ID") =System.Guid.Empty
             else
               dr("DevGrp") =DevGrp.BRIEF
               dr("DevGrp_ID") =DevGrp.ID
             end if 
             if THESCHEMA is nothing then
               dr("THESCHEMA") =system.dbnull.value
               dr("THESCHEMA_ID") =System.Guid.Empty
             else
               dr("THESCHEMA") =THESCHEMA.BRIEF
               dr("THESCHEMA_ID") =THESCHEMA.ID
             end if 
             if TheServer is nothing then
               dr("TheServer") =system.dbnull.value
               dr("TheServer_ID") =System.Guid.Empty
             else
               dr("TheServer") =TheServer.BRIEF
               dr("TheServer_ID") =TheServer.ID
             end if 
             dr("NPLOCK") =NPLOCK
             select case CONNECTED
            case enumBoolean.Boolean_Da
              dr ("CONNECTED")  = "Да"
              dr ("CONNECTED_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("CONNECTED")  = "Нет"
              dr ("CONNECTED_VAL")  = 0
              end select 'CONNECTED
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
          if m_TheNode.Equals(System.Guid.Empty) then
            nv.Add("TheNode", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheNode", Application.Session.GetProvider.ID2Param(m_TheNode), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("Name", Name, dbtype.string)
          nv.Add("ThePhone", ThePhone, dbtype.string)
          nv.Add("Addr", Addr, dbtype.string)
          if m_DEVType.Equals(System.Guid.Empty) then
            nv.Add("DEVType", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("DEVType", Application.Session.GetProvider.ID2Param(m_DEVType), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_Shab.Equals(System.Guid.Empty) then
            nv.Add("Shab", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("Shab", Application.Session.GetProvider.ID2Param(m_Shab), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_DevGrp.Equals(System.Guid.Empty) then
            nv.Add("DevGrp", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("DevGrp", Application.Session.GetProvider.ID2Param(m_DevGrp), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_THESCHEMA.Equals(System.Guid.Empty) then
            nv.Add("THESCHEMA", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("THESCHEMA", Application.Session.GetProvider.ID2Param(m_THESCHEMA), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_TheServer.Equals(System.Guid.Empty) then
            nv.Add("TheServer", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheServer", Application.Session.GetProvider.ID2Param(m_TheServer), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if NPLOCK=System.DateTime.MinValue then
            nv.Add("NPLOCK", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("NPLOCK", NPLOCK, dbtype.DATETIME)
          end if 
          nv.Add("CONNECTED", CONNECTED, dbtype.int16)
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
      If reader.Table.Columns.Contains("TheNode") Then
          if isdbnull(reader.item("TheNode")) then
            If reader.Table.Columns.Contains("TheNode") Then m_TheNode = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheNode") Then m_TheNode= New System.Guid(reader.item("TheNode").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
          If reader.Table.Columns.Contains("ThePhone") Then m_ThePhone=reader.item("ThePhone").ToString()
          If reader.Table.Columns.Contains("Addr") Then m_Addr=reader.item("Addr").ToString()
      If reader.Table.Columns.Contains("DEVType") Then
          if isdbnull(reader.item("DEVType")) then
            If reader.Table.Columns.Contains("DEVType") Then m_DEVType = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("DEVType") Then m_DEVType= New System.Guid(reader.item("DEVType").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("Shab") Then
          if isdbnull(reader.item("Shab")) then
            If reader.Table.Columns.Contains("Shab") Then m_Shab = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("Shab") Then m_Shab= New System.Guid(reader.item("Shab").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("DevGrp") Then
          if isdbnull(reader.item("DevGrp")) then
            If reader.Table.Columns.Contains("DevGrp") Then m_DevGrp = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("DevGrp") Then m_DevGrp= New System.Guid(reader.item("DevGrp").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("THESCHEMA") Then
          if isdbnull(reader.item("THESCHEMA")) then
            If reader.Table.Columns.Contains("THESCHEMA") Then m_THESCHEMA = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("THESCHEMA") Then m_THESCHEMA= New System.Guid(reader.item("THESCHEMA").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("TheServer") Then
          if isdbnull(reader.item("TheServer")) then
            If reader.Table.Columns.Contains("TheServer") Then m_TheServer = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheServer") Then m_TheServer= New System.Guid(reader.item("TheServer").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("NPLOCK") Then
          if isdbnull(reader.item("NPLOCK")) then
            If reader.Table.Columns.Contains("NPLOCK") Then m_NPLOCK = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("NPLOCK") Then m_NPLOCK=reader.item("NPLOCK")
          end if 
      end if 
          If reader.Table.Columns.Contains("CONNECTED") Then m_CONNECTED=reader.item("CONNECTED")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Узел
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheNode() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TheNode = me.application.Findrowobject("TPN_DEF",m_TheNode)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TheNode = Value.id
                else
                   m_TheNode=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Название
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Name() As String
            Get
                LoadFromDatabase()
                Name = m_Name
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_Name = Value
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
'''Доступ к полю Адрес
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Addr() As STRING
            Get
                LoadFromDatabase()
                Addr = m_Addr
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_Addr = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Устройство
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DEVType() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                DEVType = me.application.Findrowobject("TPLD_DEVTYPE",m_DEVType)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_DEVType = Value.id
                else
                   m_DEVType=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Снабжающая орг.
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Shab() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                Shab = me.application.Findrowobject("TPLD_SNAB",m_Shab)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_Shab = Value.id
                else
                   m_Shab=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Группа
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DevGrp() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                DevGrp = me.application.Findrowobject("TPLD_GRP",m_DevGrp)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_DevGrp = Value.id
                else
                   m_DevGrp=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Схема подключения
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property THESCHEMA() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                THESCHEMA = me.application.Findrowobject("TPLS_INFO",m_THESCHEMA)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_THESCHEMA = Value.id
                else
                   m_THESCHEMA=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Сервер
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheServer() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TheServer = me.application.Findrowobject("TPSRV_INFO",m_TheServer)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TheServer = Value.id
                else
                   m_TheServer=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Заблокированно до
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property NPLOCK() As DATE
            Get
                LoadFromDatabase()
                NPLOCK = m_NPLOCK
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_NPLOCK = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Подключен
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CONNECTED() As enumBoolean
            Get
                LoadFromDatabase()
                CONNECTED = m_CONNECTED
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_CONNECTED = Value
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
            m_TheNode = new system.guid(node.Attributes.GetNamedItem("TheNode").Value)
            Name = node.Attributes.GetNamedItem("Name").Value
            ThePhone = node.Attributes.GetNamedItem("ThePhone").Value
            Addr = node.Attributes.GetNamedItem("Addr").Value
            m_DEVType = new system.guid(node.Attributes.GetNamedItem("DEVType").Value)
            m_Shab = new system.guid(node.Attributes.GetNamedItem("Shab").Value)
            m_DevGrp = new system.guid(node.Attributes.GetNamedItem("DevGrp").Value)
            m_THESCHEMA = new system.guid(node.Attributes.GetNamedItem("THESCHEMA").Value)
            m_TheServer = new system.guid(node.Attributes.GetNamedItem("TheServer").Value)
            m_NPLOCK = System.DateTime.MinValue
            NPLOCK = m_NPLOCK.AddTicks( node.Attributes.GetNamedItem("NPLOCK").Value)
            CONNECTED = node.Attributes.GetNamedItem("CONNECTED").Value
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
          node.SetAttribute("TheNode", m_TheNode.tostring)  
          node.SetAttribute("Name", Name)  
          node.SetAttribute("ThePhone", ThePhone)  
          node.SetAttribute("Addr", Addr)  
          node.SetAttribute("DEVType", m_DEVType.tostring)  
          node.SetAttribute("Shab", m_Shab.tostring)  
          node.SetAttribute("DevGrp", m_DevGrp.tostring)  
          node.SetAttribute("THESCHEMA", m_THESCHEMA.tostring)  
          node.SetAttribute("TheServer", m_TheServer.tostring)  
         ' if NPLOCK = System.DateTime.MinValue then NPLOCK=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("NPLOCK", NPLOCK.Ticks)  
          node.SetAttribute("CONNECTED", CONNECTED)  
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
