Imports System.IO
Imports System.Threading

Public MustInherit Class TVDriver
#Region "properties"


    Private mMyManager As LATIR2.Manager
    Public Property MyManager As LATIR2.Manager
        Get
            Return mMyManager
        End Get
        Set(value As LATIR2.Manager)
            mMyManager = value
        End Set
    End Property


    Private mDeviceID As Guid
    Public Property DeviceID As Guid
        Get
            Return mDeviceID
        End Get
        Set(value As Guid)
            mDeviceID = value
        End Set
    End Property

    Private m_ComPort As String = ""
    Public Property ComPort As String
        Get
            Return m_ComPort
        End Get
        Set(value As String)
            m_ComPort = value
        End Set
    End Property

    Private m_ConnectLimit As Integer = 60
    Public Property ConnectLimit As Integer
        Get
            Return m_ConnectLimit
        End Get
        Set(ByVal value As Integer)
            m_ConnectLimit = value
        End Set
    End Property



    Private m_Phone As String = ""
    Public Property Phone As String
        Get
            Return m_Phone
        End Get
        Set(value As String)
            m_Phone = value
        End Set
    End Property

    Private m_PhoneLineType As String = ""
    Public Property PhoneLineType As String
        Get
            Return m_PhoneLineType
        End Get
        Set(value As String)
            m_PhoneLineType = value
        End Set
    End Property

    Private m_AtCommand As String = ""
    Public Property AtCommand As String
        Get
            Return m_AtCommand
        End Get
        Set(value As String)
            m_AtCommand = value
        End Set
    End Property

  



    Private m_serverip As String
    Public Property ServerIp() As String
        Get
            Return m_serverip
        End Get
        Set(ByVal value As String)
            m_serverip = value
        End Set
    End Property

    Private m_timeout As Long
    Public Property TimeOut() As Long
        Get
            Return m_timeout
        End Get
        Set(ByVal value As Long)
            m_timeout = value
        End Set
    End Property
    Private m_BaudRate As Long
    Public Property BaudRate() As Long
        Get
            Return m_BaudRate
        End Get
        Set(ByVal value As Long)
            m_BaudRate = value
        End Set
    End Property
    Private m_DataBits As Long = 8
    Public Property DataBits() As Long
        Get
            Return m_DataBits
        End Get
        Set(ByVal value As Long)
            m_DataBits = value
        End Set
    End Property
    Private m_StopBits As Long = 1
    Public Property StopBits() As Long
        Get
            Return m_StopBits
        End Get
        Set(ByVal value As Long)
            m_StopBits = value
        End Set
    End Property
    Private m_Parity As String
    Public Property Parity() As String
        Get
            Return m_Parity
        End Get
        Set(ByVal value As String)
            m_Parity = value
        End Set
    End Property
    Private m_FlowControl As String
    'Public Overridable Property FlowControl() As String
    '    Get
    '        Return m_FlowControl
    '    End Get
    '    Set(ByVal value As String)
    '        m_FlowControl = value
    '    End Set
    'End Property


    Private m_NPPassword As String
    Public Property NPPassword() As String
        Get
            Return m_NPPassword
        End Get
        Set(ByVal value As String)
            m_NPPassword = value
        End Set
    End Property

    Private m_IPPort As String
    Public Property IPPort() As String
        Get
            Return m_IPPort
        End Get
        Set(ByVal value As String)
            m_IPPort = value
        End Set
    End Property



    Private mTransport As String
    Public Property Transport As String
        Get
            Return mTransport
        End Get
        Set(value As String)
            mTransport = value
        End Set
    End Property



    Dim m_sleepInterval As Int32
    Public Property sleepInterval() As Int32

        Get
            Return m_sleepInterval
        End Get
        Set(ByVal value As Int32)
            m_sleepInterval = value
        End Set
    End Property

#End Region
#Region "Transport support"

    Protected WithEvents MyTransport As UniTransport

    Public ReadOnly Property DriverTransport() As UniTransport
        Get
            Return MyTransport
        End Get
    End Property

    Public Overridable Function OpenPort() As Boolean
        Return MyTransport.Connect()
    End Function

    Public Overridable Function Init(drvTransport As String, tsd As TransportSetupData) As Boolean
        Dim nd As NportTransportSetupData
        Dim vd As VortexTransportSetupData
        Dim sd As SerialTransportSetupData
        Dim md As ModemTransportSetupData
        Transport = drvTransport
        If Transport = "VORTEX" Then
            MyTransport = New VortexTransport
            vd = tsd
            'vd.BaudRate = BaudRate

            'vd.Host = ServerIp
            'Try
            '    vd.Port = Integer.Parse(IPPort)
            'Catch ex As Exception
            '    vd.Port = 80
            'End Try

            'vd.Timeout = TimeOut
            MyTransport.SetupTransport(vd)
        End If
        If Transport = "NPORT" Then
            MyTransport = New NportTransport
            nd = tsd
            'nd.BaudRate = BaudRate
            'nd.Parity = Ports.Parity.None
            'If Parity.ToLower() = "none" Then
            '    nd.Parity = Ports.Parity.None
            'End If
            'If Parity.ToLower() = "even" Then
            '    nd.Parity = Ports.Parity.Even
            'End If
            'If Parity.ToLower() = "odd" Then
            '    nd.Parity = Ports.Parity.Odd
            'End If
            'If Parity.ToLower() = "mark" Then
            '    nd.Parity = Ports.Parity.Mark
            'End If
            'If Parity.ToLower() = "space" Then
            '    nd.Parity = Ports.Parity.Space
            'End If
            'nd.DataBits = DataBits
            'nd.StopBits = StopBits
            'Dim nIPport As Integer
            'Try
            '    nIPport = Integer.Parse(IPPort)
            'Catch ex As Exception
            '    nIPport = 1
            'End Try

            If nd.ComPortIdx <= 0 Or nd.ComPortIdx > 12 Then
                nd.ComPortIdx = 1
            End If

            'nd.IPAddress = ServerIp
            'nd.Timeout = TimeOut
            MyTransport.SetupTransport(nd)

        End If

        If Transport = "DIRECT" Then
            MyTransport = New SerialTransport
            sd = tsd

            'sd.BaudRate = BaudRate
            'sd.Parity = Ports.Parity.None
            'If Parity.ToLower() = "none" Then
            '    sd.Parity = Ports.Parity.None
            'End If
            'If Parity.ToLower() = "even" Then
            '    sd.Parity = Ports.Parity.Even
            'End If
            'If Parity.ToLower() = "odd" Then
            '    sd.Parity = Ports.Parity.Odd
            'End If
            'If Parity.ToLower() = "mark" Then
            '    sd.Parity = Ports.Parity.Mark
            'End If
            'If Parity.ToLower() = "space" Then
            '    sd.Parity = Ports.Parity.Space
            'End If
            'sd.DataBits = DataBits
            'sd.StopBits = StopBits
            'sd.PortName = ComPort
            sd.Handshake = Ports.Handshake.RequestToSend

            MyTransport.SetupTransport(sd)

        End If
        If Transport = "MODEM" Then
            MyTransport = New ModemTransport
            md = tsd

            'md.BaudRate = BaudRate
            'md.Parity = Ports.Parity.None
            'If Parity.ToLower() = "none" Then
            '    md.Parity = Ports.Parity.None
            'End If
            'If Parity.ToLower() = "even" Then
            '    md.Parity = Ports.Parity.Even
            'End If
            'If Parity.ToLower() = "odd" Then
            '    md.Parity = Ports.Parity.Odd
            'End If
            'If Parity.ToLower() = "mark" Then
            '    md.Parity = Ports.Parity.Mark
            'End If
            'If Parity.ToLower() = "space" Then
            '    md.Parity = Ports.Parity.Space
            'End If
            'md.DataBits = DataBits
            'md.StopBits = StopBits
            'md.PortName = ComPort
            'md.InitCommand = AtCommand
            'md.ConnectLimit = ConnectLimit
            'md.Phone = Phone
            'md.PhoneLineType = PhoneLineType
            If md.PhoneLineType.ToUpper = "G" Then
                BaudRate = 1200
            End If
            MyTransport.SetupTransport(md)

        End If
        If MyTransport Is Nothing Then
            MyTransport = New NportTransport
        End If

        Return MyTransport.Connect()
    End Function


    Public Overridable Sub CloseTransportConnect()
        If Not MyTransport Is Nothing Then
            MyTransport.DisConnect()
            MyTransport = Nothing
        End If
    End Sub


    Protected Overridable Function MyRead(ByVal buf() As Byte, ByVal offset As Integer, ByVal len As Integer, ByVal timeToRead As Integer) As Integer
        Dim ret As Integer = 0
        Dim sz As Integer = 0
        'Dim i As Integer
        Dim btr As Integer
        Dim cnt As Integer


        btr = MyTransport.BytesToRead
        While btr > 0
            While btr
                Dim i As Integer
                i = MyTransport.Read(buf, sz + offset, 1)

                sz += i
                If sz = len Then
                    Return sz
                End If
                System.Threading.Thread.Sleep(CalcInterval(3))
                btr = MyTransport.BytesToRead
            End While

            RaiseIdle()
            cnt = 0
            While btr = 0 And cnt < 10
                System.Threading.Thread.Sleep(CalcInterval(10))
                btr = MyTransport.BytesToRead
                cnt = cnt + 1
            End While

        End While
        Return sz


        'Try
        '    For i = 1 To 10
        '        ret = ret + MyTransport.Read(buf, ret + offset, len - ret)
        '        If ret = len Then
        '            Return ret
        '        End If

        '        If MyTransport.BytesToRead = 0 Then
        '            System.Threading.Thread.Sleep(1 + timeToRead / 10)
        '            RaiseIdle()
        '        End If
        '    Next
        'Catch ex As Exception
        '    'Stop
        'End Try

        'Return ret
    End Function

    Public Overridable Function write(ByVal buf() As Byte, ByVal len As Long) As String
        Try
            MyTransport.CleanPort()
            MyTransport.Write(buf, 0, len)
            Return "Отослано " & len.ToString() & " байт"
        Catch ew As Exception
            Return "Ошибка." & ew.Message

        End Try
    End Function

    Public Overridable Function CalcInterval(ByVal datasize As Long) As Double
        Dim d As Double
        d = 1000.0 * (DataBits + StopBits) * datasize / BaudRate
        If d < 5 Then
            d = 5
        End If
        Return d
    End Function
#End Region
#Region "Events"

    Public Event Idle()
    Public Overridable Sub RaiseIdle()
        RaiseEvent Idle()
    End Sub

    Public Event TransportStatus(ByVal Action As UnitransportAction, ByVal MSG As String)


#End Region
#Region "MustOvverride_zone"
    Public MustOverride Property isArchToDBWrite() As Boolean

    Private m_IsElectroToDBWrite As Boolean = False
    Public Overridable Property isElectroToDBWrite() As Boolean
        Get
            Return m_IsElectroToDBWrite
        End Get
        Set(value As Boolean)
            m_IsElectroToDBWrite = value
        End Set
    End Property


    Public MustOverride Property isMArchToDBWrite() As Boolean
    Public MustOverride Property isTArchToDBWrite() As Boolean
    Public MustOverride Function CounterName() As String
    Public MustOverride Function Connect() As Boolean
    Public MustOverride Function IsConnected() As Boolean
    Public MustOverride Function ReadArch(ByVal ArchType As Short, ByVal ArchYear As Short, _
     ByVal ArchMonth As Short, ByVal ArchDay As Short, ByVal ArchHour As Short) As String
    Public MustOverride Function WriteArchToDB() As String
    Public MustOverride Function WriteMArchToDB() As String
    Public MustOverride Function WriteTArchToDB() As String

    Public Overridable Function WriteElectroToDB() As String
        Return "select 1"
    End Function
    Public MustOverride Function ReadMArch() As String
    Public MustOverride Function ReadTArch() As String

    Public Overridable Function ReadElectroArch() As String
        Return "Ошибка. Данные по электричеству не поддерживаются"
    End Function
    Public MustOverride Function ReadSystemParameters() As DataTable
    ' запрос для записи ошибки в базу
    Public MustOverride Function WriteErrToDB(ByVal ErrDate As Date, ByVal ErrMsg As String) As String

#End Region

    Private Sub MyTransport_Idle() Handles MyTransport.Idle
        RaiseEvent Idle()
    End Sub

    Private Sub MyTransport_TransportAction(ByVal Action As UnitransportAction, ByVal MSG As String) Handles MyTransport.TransportAction
        RaiseEvent TransportStatus(Action, MSG)
    End Sub

    Public Sub WaitForData(Optional ByVal q1 As Integer = 10, Optional ByVal Q2 As Integer = 20, Optional ByVal q3 As Integer = 10)

        Dim t As Int16
        Dim si As Double
        'If q1 <= 0 Then q1 = 10
        'If Q2 <= 0 Then Q2 = 20
        'If q3 <= 0 Then q3 = 10


        RaiseIdle()
        t = 0
        si = CalcInterval(10)
        Thread.Sleep(si)
        RaiseIdle()
        While MyTransport.BytesToRead = 0 And t < 500
            si = CalcInterval(1)
            Thread.Sleep(si)
            RaiseIdle()
            t = t + 1
        End While

        Dim cnt As Integer
        cnt = -1
        t = 0
        While MyTransport.BytesToRead <> cnt And t < 20
            cnt = MyTransport.BytesToRead
            RaiseIdle()
            si = CalcInterval(10)
            Thread.Sleep(si)
            t = t + 1
        End While
        If cnt = 0 Then
            If Me.BaudRate - (Me.BaudRate / 10) >= 1200 Then
                Me.BaudRate -= (Me.BaudRate / 10)
            Else
                Me.BaudRate = 1200
            End If

            Debug.Print("Decrement baud rate: " + BaudRate.ToString)
        End If

    End Sub

    Public Function NanFormat(ByVal n As Single, ByVal fStr As String) As String
        If Single.IsNaN(n) Then
            Return "NULL"
        Else
            Dim s As String
            s = Format(n, fStr)
            If s.Length > 19 Then Return "NULL"
            If s.Contains("E") Then Return "NULL"
            Return s
        End If
    End Function


    Public Function S180(ByVal s As String) As String

        Dim outs As String
        outs = s
        If outs.Length <= 180 Then
            Return outs
        End If
        outs = outs.Substring(0, 180)
        Return outs
    End Function

    Public Function TableForArch(ByVal ArchType As Short) As String
        Dim tName As String = ""
        If ArchType = 1 Then
            tName = "TPLC_M"
        End If

        If ArchType = 3 Then
            tName = "TPLC_H"
        End If
        If ArchType = 4 Then
            tName = "TPLC_D"
        End If
        If ArchType = 2 Then
            tName = "TPLC_T"
        End If
        Return tName
    End Function

End Class
