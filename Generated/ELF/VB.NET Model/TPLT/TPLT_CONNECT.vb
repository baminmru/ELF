
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
'''Реализация строки раздела Параметры соединения
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class TPLT_CONNECT
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Подключение разрешено
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ConnectionEnabled  as enumBoolean


''' <summary>
'''Локальная переменная для поля Тип подключения
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ConnectType  as System.Guid


''' <summary>
'''Локальная переменная для поля Время на соединение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CONNECTLIMIT  as double


''' <summary>
'''Локальная переменная для поля Сервер опроса
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheServer  as System.Guid


''' <summary>
'''Локальная переменная для поля Сетевой адрес
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_netaddr  as long


''' <summary>
'''Локальная переменная для поля Скорость бод
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CSPEED  as String


''' <summary>
'''Локальная переменная для поля Биты данных
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CDATABIT  as String


''' <summary>
'''Локальная переменная для поля Четность
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CPARITY  as enumParityType


''' <summary>
'''Локальная переменная для поля Стоповые биты
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CSTOPBITS  as long


''' <summary>
'''Локальная переменная для поля FlowControl
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FlowControl  as String


''' <summary>
'''Локальная переменная для поля Com Port
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ComPortNum  as String


''' <summary>
'''Локальная переменная для поля IP адрес
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IPAddr  as String


''' <summary>
'''Локальная переменная для поля TCP Порт
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_PortNum  as long


''' <summary>
'''Локальная переменная для поля Пользователь
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_UserName  as String


''' <summary>
'''Локальная переменная для поля Пароль
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Password  as String


''' <summary>
'''Локальная переменная для поля Код города
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CTOWNCODE  as String


''' <summary>
'''Локальная переменная для поля Телефон
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CPHONE  as String


''' <summary>
'''Локальная переменная для поля AT команда
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ATCommand  as STRING


''' <summary>
'''Локальная переменная для поля Идентификатор промеж. устройства
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_callerID  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_ConnectionEnabled=   
            ' m_ConnectType=   
            ' m_CONNECTLIMIT=   
            ' m_TheServer=   
            ' m_netaddr=   
            ' m_CSPEED=   
            ' m_CDATABIT=   
            ' m_CPARITY=   
            ' m_CSTOPBITS=   
            ' m_FlowControl=   
            ' m_ComPortNum=   
            ' m_IPAddr=   
            ' m_PortNum=   
            ' m_UserName=   
            ' m_Password=   
            ' m_CTOWNCODE=   
            ' m_CPHONE=   
            ' m_ATCommand=   
            ' m_callerID=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 19
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
                    Value = ConnectionEnabled
                Case 2
                    Value = ConnectType
                Case 3
                    Value = CONNECTLIMIT
                Case 4
                    Value = TheServer
                Case 5
                    Value = netaddr
                Case 6
                    Value = CSPEED
                Case 7
                    Value = CDATABIT
                Case 8
                    Value = CPARITY
                Case 9
                    Value = CSTOPBITS
                Case 10
                    Value = FlowControl
                Case 11
                    Value = ComPortNum
                Case 12
                    Value = IPAddr
                Case 13
                    Value = PortNum
                Case 14
                    Value = UserName
                Case 15
                    Value = Password
                Case 16
                    Value = CTOWNCODE
                Case 17
                    Value = CPHONE
                Case 18
                    Value = ATCommand
                Case 19
                    Value = callerID
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
                    ConnectionEnabled = value
                Case 2
                    ConnectType = value
                Case 3
                    CONNECTLIMIT = value
                Case 4
                    TheServer = value
                Case 5
                    netaddr = value
                Case 6
                    CSPEED = value
                Case 7
                    CDATABIT = value
                Case 8
                    CPARITY = value
                Case 9
                    CSTOPBITS = value
                Case 10
                    FlowControl = value
                Case 11
                    ComPortNum = value
                Case 12
                    IPAddr = value
                Case 13
                    PortNum = value
                Case 14
                    UserName = value
                Case 15
                    Password = value
                Case 16
                    CTOWNCODE = value
                Case 17
                    CPHONE = value
                Case 18
                    ATCommand = value
                Case 19
                    callerID = value
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
                    Return "ConnectionEnabled"
                Case 2
                    Return "ConnectType"
                Case 3
                    Return "CONNECTLIMIT"
                Case 4
                    Return "TheServer"
                Case 5
                    Return "netaddr"
                Case 6
                    Return "CSPEED"
                Case 7
                    Return "CDATABIT"
                Case 8
                    Return "CPARITY"
                Case 9
                    Return "CSTOPBITS"
                Case 10
                    Return "FlowControl"
                Case 11
                    Return "ComPortNum"
                Case 12
                    Return "IPAddr"
                Case 13
                    Return "PortNum"
                Case 14
                    Return "UserName"
                Case 15
                    Return "Password"
                Case 16
                    Return "CTOWNCODE"
                Case 17
                    Return "CPHONE"
                Case 18
                    Return "ATCommand"
                Case 19
                    Return "callerID"
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
             select case ConnectionEnabled
            case enumBoolean.Boolean_Da
              dr ("ConnectionEnabled")  = "Да"
              dr ("ConnectionEnabled_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("ConnectionEnabled")  = "Нет"
              dr ("ConnectionEnabled_VAL")  = 0
              end select 'ConnectionEnabled
             if ConnectType is nothing then
               dr("ConnectType") =system.dbnull.value
               dr("ConnectType_ID") =System.Guid.Empty
             else
               dr("ConnectType") =ConnectType.BRIEF
               dr("ConnectType_ID") =ConnectType.ID
             end if 
             dr("CONNECTLIMIT") =CONNECTLIMIT
             if TheServer is nothing then
               dr("TheServer") =system.dbnull.value
               dr("TheServer_ID") =System.Guid.Empty
             else
               dr("TheServer") =TheServer.BRIEF
               dr("TheServer_ID") =TheServer.ID
             end if 
             dr("netaddr") =netaddr
             dr("CSPEED") =CSPEED
             dr("CDATABIT") =CDATABIT
             select case CPARITY
            case enumParityType.ParityType_Space
              dr ("CPARITY")  = "Space"
              dr ("CPARITY_VAL")  = 4
            case enumParityType.ParityType_Mark
              dr ("CPARITY")  = "Mark"
              dr ("CPARITY_VAL")  = 3
            case enumParityType.ParityType_Odd
              dr ("CPARITY")  = "Odd"
              dr ("CPARITY_VAL")  = 2
            case enumParityType.ParityType_None
              dr ("CPARITY")  = "None"
              dr ("CPARITY_VAL")  = 0
            case enumParityType.ParityType_Even
              dr ("CPARITY")  = "Even"
              dr ("CPARITY_VAL")  = 1
              end select 'CPARITY
             dr("CSTOPBITS") =CSTOPBITS
             dr("FlowControl") =FlowControl
             dr("ComPortNum") =ComPortNum
             dr("IPAddr") =IPAddr
             dr("PortNum") =PortNum
             dr("UserName") =UserName
             dr("Password") =Password
             dr("CTOWNCODE") =CTOWNCODE
             dr("CPHONE") =CPHONE
             dr("ATCommand") =ATCommand
             dr("callerID") =callerID
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
          nv.Add("ConnectionEnabled", ConnectionEnabled, dbtype.int16)
          if m_ConnectType.Equals(System.Guid.Empty) then
            nv.Add("ConnectType", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("ConnectType", Application.Session.GetProvider.ID2Param(m_ConnectType), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("CONNECTLIMIT", CONNECTLIMIT, dbtype.double)
          if m_TheServer.Equals(System.Guid.Empty) then
            nv.Add("TheServer", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheServer", Application.Session.GetProvider.ID2Param(m_TheServer), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("netaddr", netaddr, dbtype.Int32)
          nv.Add("CSPEED", CSPEED, dbtype.string)
          nv.Add("CDATABIT", CDATABIT, dbtype.string)
          nv.Add("CPARITY", CPARITY, dbtype.int16)
          nv.Add("CSTOPBITS", CSTOPBITS, dbtype.Int32)
          nv.Add("FlowControl", FlowControl, dbtype.string)
          nv.Add("ComPortNum", ComPortNum, dbtype.string)
          nv.Add("IPAddr", IPAddr, dbtype.string)
          nv.Add("PortNum", PortNum, dbtype.Int32)
          nv.Add("UserName", UserName, dbtype.string)
          nv.Add("Password", Password, dbtype.string)
          nv.Add("CTOWNCODE", CTOWNCODE, dbtype.string)
          nv.Add("CPHONE", CPHONE, dbtype.string)
          nv.Add("ATCommand", ATCommand, dbtype.string)
          nv.Add("callerID", callerID, dbtype.string)
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
          If reader.Table.Columns.Contains("ConnectionEnabled") Then m_ConnectionEnabled=reader.item("ConnectionEnabled")
      If reader.Table.Columns.Contains("ConnectType") Then
          if isdbnull(reader.item("ConnectType")) then
            If reader.Table.Columns.Contains("ConnectType") Then m_ConnectType = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ConnectType") Then m_ConnectType= New System.Guid(reader.item("ConnectType").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("CONNECTLIMIT") Then m_CONNECTLIMIT=reader.item("CONNECTLIMIT")
      If reader.Table.Columns.Contains("TheServer") Then
          if isdbnull(reader.item("TheServer")) then
            If reader.Table.Columns.Contains("TheServer") Then m_TheServer = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheServer") Then m_TheServer= New System.Guid(reader.item("TheServer").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("netaddr") Then m_netaddr=reader.item("netaddr")
          If reader.Table.Columns.Contains("CSPEED") Then m_CSPEED=reader.item("CSPEED").ToString()
          If reader.Table.Columns.Contains("CDATABIT") Then m_CDATABIT=reader.item("CDATABIT").ToString()
          If reader.Table.Columns.Contains("CPARITY") Then m_CPARITY=reader.item("CPARITY")
          If reader.Table.Columns.Contains("CSTOPBITS") Then m_CSTOPBITS=reader.item("CSTOPBITS")
          If reader.Table.Columns.Contains("FlowControl") Then m_FlowControl=reader.item("FlowControl").ToString()
          If reader.Table.Columns.Contains("ComPortNum") Then m_ComPortNum=reader.item("ComPortNum").ToString()
          If reader.Table.Columns.Contains("IPAddr") Then m_IPAddr=reader.item("IPAddr").ToString()
          If reader.Table.Columns.Contains("PortNum") Then m_PortNum=reader.item("PortNum")
          If reader.Table.Columns.Contains("UserName") Then m_UserName=reader.item("UserName").ToString()
          If reader.Table.Columns.Contains("Password") Then m_Password=reader.item("Password").ToString()
          If reader.Table.Columns.Contains("CTOWNCODE") Then m_CTOWNCODE=reader.item("CTOWNCODE").ToString()
          If reader.Table.Columns.Contains("CPHONE") Then m_CPHONE=reader.item("CPHONE").ToString()
          If reader.Table.Columns.Contains("ATCommand") Then m_ATCommand=reader.item("ATCommand").ToString()
          If reader.Table.Columns.Contains("callerID") Then m_callerID=reader.item("callerID").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Подключение разрешено
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ConnectionEnabled() As enumBoolean
            Get
                LoadFromDatabase()
                ConnectionEnabled = m_ConnectionEnabled
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_ConnectionEnabled = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тип подключения
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ConnectType() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                ConnectType = me.application.Findrowobject("TPLD_CONNECTTYPE",m_ConnectType)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_ConnectType = Value.id
                else
                   m_ConnectType=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Время на соединение
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CONNECTLIMIT() As double
            Get
                LoadFromDatabase()
                CONNECTLIMIT = m_CONNECTLIMIT
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_CONNECTLIMIT = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Сервер опроса
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
'''Доступ к полю Сетевой адрес
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property netaddr() As long
            Get
                LoadFromDatabase()
                netaddr = m_netaddr
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_netaddr = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Скорость бод
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CSPEED() As String
            Get
                LoadFromDatabase()
                CSPEED = m_CSPEED
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_CSPEED = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Биты данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CDATABIT() As String
            Get
                LoadFromDatabase()
                CDATABIT = m_CDATABIT
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_CDATABIT = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Четность
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CPARITY() As enumParityType
            Get
                LoadFromDatabase()
                CPARITY = m_CPARITY
                AccessTime = Now
            End Get
            Set(ByVal Value As enumParityType )
                LoadFromDatabase()
                m_CPARITY = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Стоповые биты
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CSTOPBITS() As long
            Get
                LoadFromDatabase()
                CSTOPBITS = m_CSTOPBITS
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_CSTOPBITS = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю FlowControl
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FlowControl() As String
            Get
                LoadFromDatabase()
                FlowControl = m_FlowControl
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FlowControl = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Com Port
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ComPortNum() As String
            Get
                LoadFromDatabase()
                ComPortNum = m_ComPortNum
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_ComPortNum = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю IP адрес
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IPAddr() As String
            Get
                LoadFromDatabase()
                IPAddr = m_IPAddr
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_IPAddr = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю TCP Порт
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property PortNum() As long
            Get
                LoadFromDatabase()
                PortNum = m_PortNum
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_PortNum = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Пользователь
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property UserName() As String
            Get
                LoadFromDatabase()
                UserName = m_UserName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_UserName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Пароль
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Password() As String
            Get
                LoadFromDatabase()
                Password = m_Password
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_Password = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Код города
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CTOWNCODE() As String
            Get
                LoadFromDatabase()
                CTOWNCODE = m_CTOWNCODE
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_CTOWNCODE = Value
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
'''Доступ к полю AT команда
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ATCommand() As STRING
            Get
                LoadFromDatabase()
                ATCommand = m_ATCommand
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_ATCommand = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Идентификатор промеж. устройства
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property callerID() As String
            Get
                LoadFromDatabase()
                callerID = m_callerID
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_callerID = Value
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
            ConnectionEnabled = node.Attributes.GetNamedItem("ConnectionEnabled").Value
            m_ConnectType = new system.guid(node.Attributes.GetNamedItem("ConnectType").Value)
            CONNECTLIMIT = node.Attributes.GetNamedItem("CONNECTLIMIT").Value
            m_TheServer = new system.guid(node.Attributes.GetNamedItem("TheServer").Value)
            netaddr = node.Attributes.GetNamedItem("netaddr").Value
            CSPEED = node.Attributes.GetNamedItem("CSPEED").Value
            CDATABIT = node.Attributes.GetNamedItem("CDATABIT").Value
            CPARITY = node.Attributes.GetNamedItem("CPARITY").Value
            CSTOPBITS = node.Attributes.GetNamedItem("CSTOPBITS").Value
            FlowControl = node.Attributes.GetNamedItem("FlowControl").Value
            ComPortNum = node.Attributes.GetNamedItem("ComPortNum").Value
            IPAddr = node.Attributes.GetNamedItem("IPAddr").Value
            PortNum = node.Attributes.GetNamedItem("PortNum").Value
            UserName = node.Attributes.GetNamedItem("UserName").Value
            Password = node.Attributes.GetNamedItem("Password").Value
            CTOWNCODE = node.Attributes.GetNamedItem("CTOWNCODE").Value
            CPHONE = node.Attributes.GetNamedItem("CPHONE").Value
            ATCommand = node.Attributes.GetNamedItem("ATCommand").Value
            callerID = node.Attributes.GetNamedItem("callerID").Value
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
          node.SetAttribute("ConnectionEnabled", ConnectionEnabled)  
          node.SetAttribute("ConnectType", m_ConnectType.tostring)  
          node.SetAttribute("CONNECTLIMIT", CONNECTLIMIT)  
          node.SetAttribute("TheServer", m_TheServer.tostring)  
          node.SetAttribute("netaddr", netaddr)  
          node.SetAttribute("CSPEED", CSPEED)  
          node.SetAttribute("CDATABIT", CDATABIT)  
          node.SetAttribute("CPARITY", CPARITY)  
          node.SetAttribute("CSTOPBITS", CSTOPBITS)  
          node.SetAttribute("FlowControl", FlowControl)  
          node.SetAttribute("ComPortNum", ComPortNum)  
          node.SetAttribute("IPAddr", IPAddr)  
          node.SetAttribute("PortNum", PortNum)  
          node.SetAttribute("UserName", UserName)  
          node.SetAttribute("Password", Password)  
          node.SetAttribute("CTOWNCODE", CTOWNCODE)  
          node.SetAttribute("CPHONE", CPHONE)  
          node.SetAttribute("ATCommand", ATCommand)  
          node.SetAttribute("callerID", callerID)  
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
