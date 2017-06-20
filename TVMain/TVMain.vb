Imports System.Data
Imports System.IO
Imports System.Reflection
Imports System.Xml
Imports LATIR2.Utils

Public Class TVMain

    Public Event Idle()
    Public Event TransportStatus(ByVal Action As UnitransportAction, ByVal MSG As String)

    Public WithEvents TVD As TVDriver
    Public MANAGER As LATIR2.Manager
    Public TheSession As LATIR2.Session
    Public SrvID As Guid = Guid.Empty
    Dim PortID As Short
    Dim m_RequestInterval As Integer
    Dim DeviceReady As Boolean
    Dim m_ConnectStatus As String

    Private Sub TVD_Idle() Handles TVD.Idle
        RaiseEvent Idle()
    End Sub


    Private Sub TVD_TransportStatus(ByVal Action As UnitransportAction, ByVal MSG As String) Handles TVD.TransportStatus
        Select Case Action
            Case UnitransportAction.Connected

            Case UnitransportAction.Connecting

            Case UnitransportAction.Destroy

            Case UnitransportAction.Disconnected

            Case UnitransportAction.Disconnecting

            Case UnitransportAction.ReceiveData

            Case UnitransportAction.SendData

            Case UnitransportAction.SettingUp

            Case UnitransportAction.Wait

            Case UnitransportAction.LowLevelStop
                'SaveLog(TVD.DeviceID, 0, "0", 0, TVD.ComPort + "->" + MSG)

        End Select
        RaiseEvent TransportStatus(Action, MSG)
    End Sub

    Public Function ReadSystemParameters() As DataTable
        If Not TVD Is Nothing Then
            If TVD.IsConnected Then
                Return TVD.ReadSystemParameters()
            Else
                Return Nothing
            End If


        Else
            Return Nothing
        End If

    End Function

    Public Enum enumArchType
        M = 1
        T = 2
        H = 3
        D = 4
    End Enum




    ' есть ли такой архив
    Public Function CheckForArch(ByVal ArchType As enumArchType, ByVal ArchYear As Int32, _
    ByVal ArchMonth As Int32, ByVal ArchDay As Int32, ByVal ArchHour As Int32, ByVal TPLC_INSTANCEid As Guid) As Boolean

        Dim datearch As DateTime
        Dim after As Date, befor As Date
        datearch = New DateTime(ArchYear, ArchMonth, ArchDay, ArchHour, 0, 0)

        Dim commandText As String
        Dim tName As String = ""
        If ArchType = enumArchType.M Then
            tName = "TPLC_M"
        End If

        If ArchType = enumArchType.H Then
            tName = "TPLC_H"
        End If
        If ArchType = enumArchType.D Then
            tName = "TPLC_D"
        End If
        If ArchType = enumArchType.T Then
            tName = "TPLC_T"
        End If


        after = datearch.AddSeconds(-1)
        befor = datearch.AddSeconds(1)

        commandText = "select count(*) CNT  from " & tName & " where dcounter>=" + _
        TheSession.GetProvider.Date2Const(after) + _
        " and dcounter<=" + _
        TheSession.GetProvider.Date2Const(befor) + _
        " and instanceid=" + GUID2String(TheSession, TPLC_INSTANCEid) + ""

        Dim dt As DataTable
        dt = TheSession.GetData(commandText)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("CNT") > 0 Then
                    Return True
                End If
            End If
        End If


        Return False
    End Function


    ' стсатус соединения
    Public Function ConnectStatus() As String
        Return m_ConnectStatus
    End Function



    ' тип сетевого соединения
    Public Function TransportType() As String
        Return TVD.Transport
    End Function

    ' название тепловычислителя
    Public Function CounterName() As String
        Return TVD.CounterName
    End Function


    Public Function GetTransportType(ByVal TPLT_instanceid As Guid) As String
        Dim DrvStr As String = String.Empty
        Dim tt As String = String.Empty
        Dim tDev As TPLT.TPLT.Application
        Dim ct As TPLD.TPLD.TPLD_CONNECTTYPE

        tDev = MANAGER.GetInstanceObject(TPLT_instanceid)

        If tDev Is Nothing Then Return ""
        Dim i As Integer


        For i = 1 To tDev.TPLT_CONNECT.Count

            With tDev.TPLT_CONNECT.Item(i)
                ct = .ConnectType
                If Not ct Is Nothing Then
                    ' для конкретного сервра можно использовать любой траHCпорт
                    If Not .TheServer Is Nothing Then
                        If .TheServer.ID.Equals(SrvID) Or SrvID.Equals(Guid.Empty) Then
                            If .ConnectionEnabled = TPLT.TPLT.enumBoolean.Boolean_Da Then
                                tt = UCase(ct.Name)
                                Return tt
                            End If
                        End If
                    End If
                End If


            End With
        Next

        ' для абстрактного сервера можно использовать только сетевой траHCпорт, или модем
        For i = 1 To tDev.TPLT_CONNECT.Count
            With tDev.TPLT_CONNECT.Item(i)
                ct = .ConnectType
                If Not ct Is Nothing Then
                    If .TheServer Is Nothing Then
                        If .ConnectionEnabled = TPLT.TPLT.enumBoolean.Boolean_Da Then

                            tt = UCase(ct.Name)
                            Select Case tt
                                Case "VORTEX"
                                    Return tt
                                Case "NPORT"
                                    Return tt
                                Case "MODEM"
                                    Return tt
                            End Select
                        End If
                    End If
                End If


            End With

        Next

        Return ""
    End Function

    ' инициализация устройства
    Public Function DeviceInit(ByVal TPLT_instanceid As Guid) As Boolean

        Dim DrvStr As String = String.Empty
        Dim TransportType As String = String.Empty
        Dim tDev As TPLT.TPLT.Application
        tDev = MANAGER.GetInstanceObject(TPLT_instanceid)

        If Not TVD Is Nothing Then
            'If TVD.IsConnected Then

            'End If
            Try
                TVD.CloseTransportConnect()
            Catch
            End Try

            TVD = Nothing

        End If

        Dim devtype As TPLD.TPLD.TPLD_DEVTYPE
        devtype = tDev.TPLT_BDEVICES.Item(1).DEVType
        If devtype Is Nothing Then
            Exit Function
        End If
        DrvStr = devtype.DriverLibName

        If (DrvStr = "") Then
            m_ConnectStatus += vbCrLf & "Драйвер неизвестен"
            Return False
        End If

        m_ConnectStatus += vbCrLf & "Загружаем драйвер " & DrvStr

        TVD = Nothing
        Try
            TVD = GetDoc(DrvStr)
        Catch
            m_ConnectStatus += vbCrLf & "Ошибка загрузки драйвера"
            Return False
        End Try


        If Not TVD Is Nothing Then

            TVD.MyManager = MANAGER
            m_ConnectStatus += vbCrLf & "Драйвер загружен"

            Dim dt As DataTable
            dt = TheSession.GetData("select b2g(instanceid) instanceid from TPLC_HEADER where ID_BD=" + GUID2String(TheSession, tDev.TPLT_BDEVICES.Item(1).ID) + "")
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    TVD.DeviceID = New Guid(dt.Rows(0)("instanceid").ToString)
                Else
                    Return False
                End If
            Else
                Return False
            End If


            TransportType = GetTransportType(TPLT_instanceid)
            TVD.Transport = UCase(TransportType)




           
            TVD.sleepInterval = 600


            Dim tt As TransportSetupData
            tt = loadparameters(tDev, TransportType)
            'setup trnsport here
            If Not tt Is Nothing Then


                'TVD.Transport = UCase(TransportType)
                TVD.BaudRate = tt.BaudRate
                'TVD.DriverTransport.SetupTransport(tt)

                If TVD.Init(UCase(TransportType), tt) = False Then
                    m_ConnectStatus += vbCrLf & "Ошибка инициализации драйвера канального уровня"
                    Return False
                End If
                m_ConnectStatus += vbCrLf & "Драйвер инициализирован"


                m_ConnectStatus += vbCrLf & "Канальное соединение установлено"


                'cmd = Nothing
                DeviceReady = True

                m_ConnectStatus += vbCrLf & "Device ready"
                Return True
            Else
                Return False
            End If



        Else
            Return False
        End If
    End Function

    Private Function loadparameters(ByVal tDev As TPLT.TPLT.Application, ByVal tt As String) As TransportSetupData
        Dim td As TransportSetupData = Nothing
        Dim sd As SerialTransportSetupData
        Dim nd As NportTransportSetupData
        Dim md As ModemTransportSetupData
        Dim vd As VortexTransportSetupData
        Dim OK As Boolean
        If tDev Is Nothing Then Return Nothing
        Dim i As Integer
        OK = False

        Dim srv As TPSRV.TPSRV.Application


        Dim ct As TPLD.TPLD.TPLD_CONNECTTYPE
        Dim dt As DataTable
        dt = TheSession.GetData("select b2g(instanceid) instanceid from TPSRV_INFO where TPSRV_INFOID=" + GUID2String(TheSession, SrvID) + "")
        If dt.Rows.Count > 0 Then
            srv = MANAGER.GetInstanceObject(New Guid(dt.Rows(0)("INSTANCEID").ToString))
        Else
            srv = Nothing
        End If


        For i = 1 To tDev.TPLT_CONNECT.Count
            With tDev.TPLT_CONNECT.Item(i)
                ct = .ConnectType
                If Not ct Is Nothing Then
                    ' для конкретного сервра можно использовать любой траHCпорт
                    If Not .TheServer Is Nothing Then
                        If .TheServer.ID.Equals(SrvID) Or SrvID.Equals(Guid.Empty) Then

                            If .ConnectionEnabled = TPLT.TPLT.enumBoolean.Boolean_Da And ct.Name = tt Then

                                Select Case UCase(tt)
                                    Case "VORTEX"
                                        vd = New VortexTransportSetupData
                                        vd.Host = .IPAddr
                                        vd.Port = .PortNum
                                        vd.Timeout = 2000
                                        td = vd
                                        OK = True

                                    Case "NPORT"
                                        nd = New NportTransportSetupData
                                        nd.BaudRate = .CSPEED
                                        nd.Parity = Ports.Parity.None
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_None Then
                                            nd.Parity = Ports.Parity.None
                                        End If
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Even Then
                                            nd.Parity = Ports.Parity.Even
                                        End If
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Odd Then
                                            nd.Parity = Ports.Parity.Odd
                                        End If
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Mark Then
                                            nd.Parity = Ports.Parity.Mark
                                        End If
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Space Then
                                            nd.Parity = Ports.Parity.Space
                                        End If
                                        nd.DataBits = Integer.Parse(.CDATABIT)
                                        nd.StopBits = .CSTOPBITS
                                        nd.IPAddress = .IPAddr

                                        nd.ComPortIdx = .PortNum
                                       
                                        nd.Timeout = 2000
                                        td = nd
                                        OK = True
                                    Case "DIRECT"
                            sd = New SerialTransportSetupData
                            sd.BaudRate = .CSPEED
                            sd.Parity = Ports.Parity.None
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_None Then
                                sd.Parity = Ports.Parity.None
                            End If
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Even Then
                                sd.Parity = Ports.Parity.Even
                            End If
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Odd Then
                                sd.Parity = Ports.Parity.Odd
                            End If
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Mark Then
                                sd.Parity = Ports.Parity.Mark
                            End If
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Space Then
                                sd.Parity = Ports.Parity.Space
                            End If
                            sd.DataBits = Integer.Parse(.CDATABIT)
                            sd.StopBits = .CSTOPBITS
                            sd.PortName = .ComPortNum
                            td = sd
                            OK = True


                                    Case "MODEM"
                            md = New ModemTransportSetupData

                            md.BaudRate = .CSPEED
                            md.Parity = Ports.Parity.None
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_None Then
                                md.Parity = Ports.Parity.None
                            End If
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Even Then
                                md.Parity = Ports.Parity.Even
                            End If
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Odd Then
                                md.Parity = Ports.Parity.Odd
                            End If
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Mark Then
                                md.Parity = Ports.Parity.Mark
                            End If
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Space Then
                                md.Parity = Ports.Parity.Space
                            End If
                            md.DataBits = Integer.Parse(.CDATABIT)
                            md.StopBits = .CSTOPBITS
                            md.Phone = .CPHONE
                            md.InitCommand = .ATCommand
                            md.PortName = GetNextModem(srv)
                            md.PhoneLineType = "T"
                            If md.PortName <> "" Then
                                td = md
                                OK = True
                            Else
                                td = Nothing
                                OK = False

                            End If

                                    Case "GSMMODEM"
                            md = New ModemTransportSetupData

                            md.BaudRate = .CSPEED
                            md.Parity = Ports.Parity.None
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_None Then
                                md.Parity = Ports.Parity.None
                            End If
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Even Then
                                md.Parity = Ports.Parity.Even
                            End If
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Odd Then
                                md.Parity = Ports.Parity.Odd
                            End If
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Mark Then
                                md.Parity = Ports.Parity.Mark
                            End If
                            If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Space Then
                                md.Parity = Ports.Parity.Space
                            End If
                            md.DataBits = Integer.Parse(.CDATABIT)
                            md.StopBits = .CSTOPBITS
                            md.Phone = .CPHONE
                            md.InitCommand = .ATCommand
                            md.PhoneLineType = "G"
                            md.PortName = GetNextModem(srv)
                            If md.PortName <> "" Then
                                td = md
                                OK = True
                            Else
                                td = Nothing
                                OK = False

                            End If
                                End Select
                            End If
                        End If
                    End If
                End If
            End With
            If OK Then Exit For
        Next

        If Not OK Then

            ' для абстрактного сервера можно использовать только сетевой траHCпорт, или модем
            For i = 1 To tDev.TPLT_CONNECT.Count
                With tDev.TPLT_CONNECT.Item(i)
                    ct = .ConnectType
                    If Not ct Is Nothing Then
                        If .TheServer Is Nothing Then
                            If .ConnectionEnabled = TPLT.TPLT.enumBoolean.Boolean_Da And ct.Name = tt Then


                                Select Case UCase(tt)
                                    Case "VORTEX"
                                        vd = New VortexTransportSetupData
                                        vd.Host = .IPAddr
                                        vd.Port = .PortNum
                                        vd.Timeout = 2000
                                        td = vd
                                        OK = True
                                    Case "NPORT"
                                        nd = New NportTransportSetupData
                                        nd.BaudRate = .CSPEED
                                        nd.Parity = Ports.Parity.None
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_None Then
                                            nd.Parity = Ports.Parity.None
                                        End If
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Even Then
                                            nd.Parity = Ports.Parity.Even
                                        End If
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Odd Then
                                            nd.Parity = Ports.Parity.Odd
                                        End If
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Mark Then
                                            nd.Parity = Ports.Parity.Mark
                                        End If
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Space Then
                                            nd.Parity = Ports.Parity.Space
                                        End If
                                        nd.DataBits = Integer.Parse(.CDATABIT)
                                        nd.StopBits = .CSTOPBITS
                                        nd.IPAddress = .IPAddr
                                        nd.Timeout = 2000
                                        nd.ComPortIdx = .PortNum
                                        td = nd
                                        OK = True

                                    Case "MODEM"
                                        md = New ModemTransportSetupData
                                        md.BaudRate = .CSPEED
                                        md.Parity = Ports.Parity.None
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_None Then
                                            md.Parity = Ports.Parity.None
                                        End If
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Even Then
                                            md.Parity = Ports.Parity.Even
                                        End If
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Odd Then
                                            md.Parity = Ports.Parity.Odd
                                        End If
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Mark Then
                                            md.Parity = Ports.Parity.Mark
                                        End If
                                        If .CPARITY = TPLT.TPLT.enumParityType.ParityType_Space Then
                                            md.Parity = Ports.Parity.Space
                                        End If
                                        md.DataBits = Integer.Parse(.CDATABIT)
                                        md.StopBits = .CSTOPBITS
                                        md.Phone = .CPHONE
                                        md.InitCommand = .ATCommand

                                        md.PortName = GetNextModem(srv)
                                        If md.PortName <> "" Then
                                            OK = True
                                            td = md
                                        Else
                                            td = Nothing
                                            OK = False
                                        End If

                                End Select
                            End If
                        End If
                    End If



                End With
                If OK Then Exit For
            Next
        End If
        Return td

    End Function

    Private Mymodem As TPSRV.TPSRV.TPSRV_MODEMS = Nothing

    Private Function GetNextModem(ByVal srv As TPSRV.TPSRV.Application) As String

        Dim query As String
        Dim sPort As String

        query = "SELECT     TPSRV_MODEMSid  ,PortNum ,IsUsable,IsUsed,UsedUntil   FROM TPSRV_MODEMS  join TPSRV_INFO on TPSRV_MODEMS.InstanceID=TPSRV_INFO.InstanceID where IsUsable=-1 and UsedUntil<" + TheSession.GetProvider.GetServerDate() + " and TPSRV_INFOid=" & GUID2String(TheSession, SrvID) & ""
        Dim dt As DataTable
        dt = TheSession.GetData(query)
        If dt.Rows.Count > 0 Then
            sPort = dt.Rows(0)("PortNum")
            Mymodem = Nothing
            srv.TPSRV_MODEMS.Refresh()
            Mymodem = srv.TPSRV_MODEMS.Item(dt.Rows(0)("TPSRV_MODEMSid").ToString)
            If Not Mymodem Is Nothing Then

                Mymodem.UsedUntil = TheSession.GetServerTime().AddMinutes(5)
                Mymodem.Save()
                Return sPort
            Else
                Return ""
            End If

        End If

        Return ""
    End Function

    ' инициализация библиотеки
    Public Function Init(ByVal MyManager As LATIR2.Manager, ByVal aSrvid As Guid) As Boolean
        DeviceReady = False
        MANAGER = MyManager
        TheSession = MANAGER.Session
        SrvID = aSrvid
        Return True
    End Function

    ' закрытие библиотеки
    Public Sub EndInit()
        Try
            If Not TVD Is Nothing Then
                TVD.CloseTransportConnect()
            End If

            If Not Mymodem Is Nothing Then
                Mymodem.UsedUntil = TheSession.GetServerTime().AddMinutes(-1)
                Mymodem.Save()
                Mymodem = Nothing

            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        DeviceReady = False
        TheSession = Nothing
        MANAGER = Nothing
    End Sub



    Public Sub HoldLine(Optional ByVal wait As Integer = 3)
        If Not Mymodem Is Nothing Then
            Mymodem.UsedUntil = TheSession.GetServerTime().AddMinutes(wait)
            Mymodem.Save()
        End If
    End Sub




    ' удалить архивы за период
    Public Sub ClearDBarch(ByVal after As Date, ByVal befor As Date, ByVal archtype As enumArchType, ByVal TPLC_INSTANCEid As Guid)
        Dim cmdText As String
        after = after.AddSeconds(-1)
        befor = befor.AddSeconds(1)

        Dim tName As String = ""
        If archtype = enumArchType.M Then
            tName = "TPLC_M"
        End If

        If archtype = enumArchType.H Then
            tName = "TPLC_H"
        End If
        If archtype = enumArchType.D Then
            tName = "TPLC_D"
        End If
        If archtype = enumArchType.T Then
            tName = "TPLC_T"
        End If

        cmdText = "delete from " & tName & " where dcounter>=" + _
          TheSession.GetProvider.Date2Const(after) + _
          " and dcounter<=" + _
          TheSession.GetProvider.Date2Const(befor) + _
        " and instanceid=" + GUID2String(TheSession, TPLC_INSTANCEid) + ""

        Try
            SyncLock TheSession
                TheSession.GetData(cmdText)
            End SyncLock
            'Console.WriteLine(cmdText)
            Debug.Print(cmdText)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    ' получить драйвер
    Protected Function GetDoc(ByVal name As String, Optional ByVal Root As String = "") As TVDriver
        Dim funcAssembly As TVDriver
        Dim asm As System.Reflection.Assembly
        funcAssembly = Nothing
        asm = Nothing

        Console.WriteLine("Driver=" & name)
        Try
            If asm Is Nothing Then
                If Root <> "" Then
                    Try
                        asm = System.Reflection.Assembly.LoadFrom(Root + "\" & name & ".dll")
                    Catch
                    End Try
                End If
            End If
            If asm Is Nothing Then
                Dim FileName As String
                FileName = System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location) + "\" & name & ".dll"
                Try
                    If (File.Exists(FileName)) Then
                        asm = System.Reflection.Assembly.LoadFrom(FileName)
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
                If (asm Is Nothing) Then
                    Try
                        FileName = AppDomain.CurrentDomain.DynamicDirectory + "\" & name & ".dll"
                        If (File.Exists(FileName)) Then
                            asm = System.Reflection.Assembly.LoadFrom(FileName)
                        Else
                            Try
                                funcAssembly = CType(System.Activator.CreateInstance(name, name & ".Driver").Unwrap(), TVDriver)
                            Catch e2 As System.Exception
                                Dim i As Integer = 0
                                Return Nothing
                            End Try
                        End If
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End If
                If (funcAssembly Is Nothing) Then
                    funcAssembly = CType(asm.CreateInstance(name & ".Driver", True), TVDriver)
                End If
            End If
        Catch
        End Try
        asm = Nothing
        Return funcAssembly
    End Function

    ' закрытие канала драйвера
    Public Sub CloseTransportConnect()

        Try
            DeviceReady = False
            If Not TVD Is Nothing Then
                TVD.CloseTransportConnect()
            End If

            If Not Mymodem Is Nothing Then
                Mymodem.UsedUntil = TheSession.GetServerTime().AddMinutes(-1)
                Mymodem.Save()
                Mymodem = Nothing
            End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    ' соединение с тепловычислителем
    Public Sub connect()
        If Not TVD Is Nothing Then
            TVD.Connect()
            If Not TVD.IsConnected Then
                m_ConnectStatus += vbCrLf & "Ошибка соединения с устройством"
            End If
        End If

    End Sub

    ' установлено ли соединение
    Public Function isConnected() As Boolean
        If Not TVD Is Nothing Then
            Return TVD.IsConnected
        Else
            Return False
        End If
    End Function


    ' чение данных по электричеству
    Public Function ReadElectroArch() As String
        If Not TVD Is Nothing Then
            Return TVD.ReadElectroArch()
        Else
            Return "Ошибка. Драйвер устройства не создан"
        End If
    End Function


    ' чение мгновенного архива
    Public Function readmarch() As String
        If Not TVD Is Nothing Then
            readmarch = TVD.ReadMArch()
        Else
            Return "Ошибка. Драйвер устройства не создан"
        End If
    End Function

    ' чтение итогового архива
    Public Function readtarch() As String
        If Not TVD Is Nothing Then
            readtarch = TVD.ReadTArch()
        Else
            Return "Ошибка. Драйвер устройства не создан"
        End If
    End Function

    ' чтение архива
    Public Function readarch(ByVal ArchType As Int32, ByVal ArchYear As Int32, _
   ByVal ArchMonth As Int32, ByVal ArchDay As Int32, ByVal ArchHour As Int32) As String
        If Not TVD Is Nothing Then
            Return TVD.ReadArch(ArchType, ArchYear, ArchMonth, ArchDay, ArchHour)
        Else
            Return "Ошибка. Драйвер устройства не создан"
        End If

    End Function

    ' проверка готовности архива
    Public Function bufcheck() As String
        Dim retstr As String = ""
        If Not TVD Is Nothing Then
            'retstr = TVD.bufcheck()
            If (TVD.isArchToDBWrite = True) Then
                Return WriteArchToDB()
                TVD.isArchToDBWrite = False
            End If
            If (TVD.isMArchToDBWrite = True) Then
                Return WritemArchToDB()
                TVD.isMArchToDBWrite = False
            End If
            If (TVD.isTArchToDBWrite = True) Then
                Return WriteTArchToDB()
                TVD.isTArchToDBWrite = False
            End If
            Return ""
        Else
            Return "Ошибка. Драйвер устройства не создан"
        End If


    End Function

    ' задать времена  для таблицы опроса
    Public Sub SetTimeToPlanCall(ByVal TPLT_instanceid As Guid, ByVal FieldName As String, ByVal time As DateTime)
        'Command.CommandText = "update tplt_PlanCall set " + FieldName + _
        '"=" + "to_date('" + time.Year.ToString() + "-" + _
        'time.Month.ToString() + "-" + time.Day.ToString() + " " + _
        'time.Hour.ToString() + ":" + time.Minute.ToString() + ":" + time.Second.ToString() + _
        '"','YYYY-MM-DD HH24:MI:SS') where id_bd=" + id_bd.ToString
        'Try
        '    SyncLock connection
        '        If connection.State = ConnectionState.Open Then
        '            Command.ExecuteNonQuery()
        '        End If
        '    End SyncLock
        'Catch ex As Exception
        '    Console.WriteLine(ex.Message)
        'End Try
        Try
            MANAGER.Session.GetData("update tplt_PlanCall set " + FieldName + "=" + MANAGER.Session.GetProvider.Date2Const(time) + " where instanceid=" + GUID2String(MANAGER.Session, TPLT_instanceid) + "")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    ' запись архива  в базу
    Public Function WriteArchToDB() As String
        Dim CommandText
        CommandText = TVD.WriteArchToDB
        Dim ret As String
        ret = CommandText & " "
        Try
            SyncLock TheSession
                TheSession.GetData(CommandText)
            End SyncLock
            TVD.isArchToDBWrite = False
            Return ret & " Архив добавлен в БД"
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return ret & ex.Message
        End Try
    End Function


    ' запись архива  в базу
    Public Function WriteElectroToDB() As String
        Dim CommandText
        CommandText = TVD.WriteElectroToDB
        Dim ret As String
        ret = CommandText & " "
        Try
            SyncLock TheSession
                TheSession.GetData(CommandText)
            End SyncLock
            TVD.isElectroToDBWrite = False
            Return ret & "Данные по электропотреблению добавлены в БД"
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return ret & ex.Message
        End Try
    End Function

    ' запись мгновенного архива в базу
    Public Function WritemArchToDB() As String
        Dim CommandText
        CommandText = TVD.WriteMArchToDB
        Dim ret As String
        ret = CommandText & " "
        Try
            SyncLock TheSession
                TheSession.GetData(CommandText)
            End SyncLock
            TVD.isMArchToDBWrite = False
            Return ret & "Мгновенный архив добавлен в БД"
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return ret & ex.Message
        End Try


    End Function

    ' запись итогового архива  в базу
    Public Function WriteTArchToDB() As String
        Dim CommandText
        CommandText = TVD.WriteTArchToDB
        Dim ret As String
        ret = CommandText & " "
        Try
            SyncLock TheSession
                TheSession.GetData(CommandText)
            End SyncLock
            TVD.isTArchToDBWrite = False
            Return ret & "Итоговый архив добавлен в БД"
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return ret & ex.Message
        End Try


    End Function

    ' запись ошибки в  базу
    Public Function WriteErrToDB(ByVal ErrDate As Date, ByVal ErrMsg As String) As String
        Dim CommandText
        CommandText = TVD.WriteErrToDB(ErrDate, ErrMsg)
        Dim ret As String
        ret = CommandText & " "
        Try
            SyncLock TheSession
                TheSession.GetData(CommandText)
            End SyncLock
            TVD.isTArchToDBWrite = False
            Return ret & " " & ErrMsg
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return ret & ex.Message
        End Try
    End Function



    Public Sub New()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub




    Public Function GetRealDateFromBase(ByVal ArchType As enumArchType, ByVal ArchYear As Int32, _
    ByVal ArchMonth As Int32, ByVal ArchDay As Int32, ByVal ArchHour As Int32, ByVal TPLC_INSTANCEid As Guid) As DateTime

        Dim datearch As DateTime
        Dim after As Date, befor As Date
        datearch = New DateTime(ArchYear, ArchMonth, ArchDay, ArchHour, 0, 0)

        Dim commandText As String
        Dim tName As String = ""
        If ArchType = enumArchType.M Then
            tName = "TPLC_M"
        End If

        If ArchType = enumArchType.H Then
            tName = "TPLC_H"
        End If
        If ArchType = enumArchType.D Then
            tName = "TPLC_D"
        End If
        If ArchType = enumArchType.T Then
            tName = "TPLC_T"
        End If


        after = datearch.AddSeconds(-1)
        befor = datearch.AddSeconds(1)

        commandText = "select dcounter  from " & tName & " where dcounter>=" + _
        TheSession.GetProvider.Date2Const(after) + _
        " and dcounter<=" + _
        TheSession.GetProvider.Date2Const(befor) + _
        " and instanceid=" + GUID2String(TheSession, TPLC_INSTANCEid) + ""

        Dim dt As DataTable
        dt = TheSession.GetData(commandText)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("dcounter") > 0
            End If
        End If



        Return DateTime.Now
    End Function

End Class
