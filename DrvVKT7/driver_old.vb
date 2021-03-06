﻿
Imports System.Security.Cryptography
Imports System.Text
Imports TVMain
Imports System.IO
Imports System.Threading
Imports LATIR2.Utils

Public Structure MArchive
    Public DateArch As DateTime
    Public HC As Int32
    Public MsgHC As String

    Public HCtv1 As Long
    Public MsgHCtv1 As String

    Public HCtv2 As Long
    Public MsgHCtv2 As String

    Public G1 As Single
    Public G2 As Single
    Public G3 As Single
    Public G4 As Single
    Public G5 As Single
    Public G6 As Single

    Public t1 As Single
    Public t2 As Single
    Public t3 As Single
    Public t4 As Single
    Public t5 As Single
    Public t6 As Single

    Public p1 As Single
    Public p2 As Single
    Public p3 As Single
    Public p4 As Single
    Public p5 As Single


    Public v1 As Single
    Public v2 As Single
    Public v3 As Single
    Public v4 As Single

    Public dt12 As Single
    Public dt45 As Single

    Public tx1 As Single
    Public tx2 As Single

    Public tair1 As Single
    Public tair2 As Single

    Public MyTransport As Long
    Public SPtv1 As Long
    Public SPtv2 As Long

    Public dQ1 As Single
    Public dQ2 As Single


    Public archType As Short
End Structure

Public Structure Archive
    Public DateArch As DateTime
    Public Errtime As Long
    Public HC As Long
    Public MsgHC As String

    Public HCtv1 As Long
    Public MsgHCtv1 As String

    Public HCtv2 As Long
    Public MsgHCtv2 As String

    Public Tw1 As Single
    Public Tw2 As Single

    Public P1 As Single
    Public T1 As Single
    Public M2 As Single
    Public V1 As Single

    Public P2 As Single
    Public T2 As Single
    Public M3 As Single
    Public V2 As Single

    Public V3 As Single
    Public M1 As Single

    Public Q1 As Single
    Public Q2 As Single

    Public QG1 As Single
    Public QG2 As Single

    Public MyTransport As Long
    Public SPtv1 As Long
    Public SPtv2 As Long

    Public tx1 As Long
    Public tx2 As Long
    Public tair1 As Long
    Public tair2 As Long

    Public T3 As Single
    Public T4 As Single
    Public T5 As Single
    Public T6 As Single
    Public P3 As Single
    Public P4 As Single
    Public v4 As Single
    Public v5 As Single
    Public v6 As Single
    Public M4 As Single
    Public M5 As Single
    Public M6 As Single
    Public V1h As Double
    Public V2h As Double
    Public V3h As Double
    Public V4h As Double
    Public Q1H As Double
    Public Q2H As Double

    Public errtime1 As Int64
    Public errtime2 As Int64
    Public oktime1 As Int64
    Public oktime2 As Int64


    Public archType As Short
End Structure

Public Structure TArchive
    Public DateArch As DateTime


    Public V1 As Double
    Public V2 As Double
    Public V3 As Double
    Public V4 As Double
    Public V5 As Double
    Public V6 As Double

    Public M1 As Double
    Public M2 As Double
    Public M3 As Double
    Public M4 As Double
    Public M5 As Double
    Public M6 As Double
    Public Q1 As Double
    Public Q2 As Double

    Public TW1 As Double
    Public TW2 As Double
    Public Q3 As Double
    Public Q4 As Double
    Public HC As Int32
    Public errtime1 As Int64
    Public errtime2 As Int64
    Public oktime1 As Int64
    Public oktime2 As Int64

    Public archType As Short
End Structure





Public Class driver
    Inherits TVMain.TVDriver


    Public Const c_lng256 As Long = 256&
    Private mIsConnected As Boolean

    Private isTCP As Boolean
    Private SleepTime As Long


    Dim tArch As TArchive
    Dim IsTArchToRead As Boolean = False
    ' Dim WithEvents tim As System.Timers.Timer

    Dim tv As Short

    Dim archType_hour = 3
    Dim archType_day = 4
    Dim ActiveCount As Integer


    Dim Arch As Archive
    Dim mArch As MArchive

    Dim WillCountToRead As Short = 0
    Dim IsBytesToRead As Boolean = False
    Dim pagesToRead As Short = 0
    Dim curtime As DateTime
    Dim IsmArchToRead As Boolean = False
    Dim ispackageError As Boolean = False

    Dim buffer(0 To 73) As Byte
    Dim bufferindex As Short = 0



    Dim m_timerInterval As Double

  

    Dim m_isArchToDBWrite As Boolean = False
    Public Overrides Property isArchToDBWrite() As Boolean

        Get
            Return m_isArchToDBWrite
        End Get
        Set(ByVal value As Boolean)
            m_isArchToDBWrite = value
        End Set
    End Property
    Dim m_isMArchToDBWrite As Boolean = False


    Public Overrides Function CounterName() As String
        Return "VKT7"
    End Function



    Private Function DevInit() As Boolean

        InitDigMap()

        'FF FF 00 10 3F FF 00 00 CC 63 00 00 00 64 54
        Dim Frame(15) As Byte
        Dim ch As UInt16
        Frame(0) = &HFF
        Frame(1) = &HFF
        Frame(2) = &H0
        Frame(3) = &H10
        Frame(4) = &H3F
        Frame(5) = &HFF
        Frame(6) = &H0
        Frame(7) = &H0
        Frame(8) = &HCC
        Frame(9) = &H63
        Frame(10) = &H0
        Frame(11) = &H0
        Frame(12) = &H0
        ch = CheckSum(Frame, 2, 11)
        Frame(13) = ch Mod 256 '&H64
        Frame(14) = ch \ 256 '&H54

        MyTransport.Write(Frame, 0, 15)

        Dim t As Integer
        RaiseIdle()
        System.Threading.Thread.Sleep(300)
        t = 0
        While MyTransport.BytesToRead = 0 And t < 20
            RaiseIdle()
            System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
            t = t + 1
        End While

        Dim b(4096) As Byte
        Dim cnt As Integer
        cnt = MyTransport.BytesToRead
        If cnt > 0 Then
            Dim ptr As Integer
            Dim sz As Integer
            ptr = 0
            sz = 0
            While cnt > 0
                MyTransport.Read(b, ptr, cnt)
                ptr += cnt
                sz += cnt


                If VerifySumm(b, 0, sz) Then
                    Return True
                End If


                RaiseIdle()
                System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
                cnt = MyTransport.BytesToRead
            End While

        Else
            Return False
        End If

    End Function


    Public Overrides Function Connect() As Boolean
        SleepTime = 700
        EraseInputQueue()
        mIsConnected = False
        Try

            If DevInit() Then
                mIsConnected = True

                RaiseIdle()
                System.Threading.Thread.Sleep(300)


                Dim b() As Byte
                Dim i As Integer

                SetArchType(VKT7ArchType.AT_Properties)

                ' получение точности
                For i = 57 To 76
                    ElemSize(i) = 1
                    SelectElement(i)

                    b = ReadData(i)
                    PropVal(i) = b(3)
                    'If PropVal(i) > 3 Then PropVal(i) = 3

                Next
            End If


        Catch exc As Exception
            Return False
        End Try
        Return mIsConnected


    End Function

    Private m_readRAMByteCount As Short

    Public Overrides Function ReadArch(ByVal ArchType As Short, ByVal ArchYear As Short, _
    ByVal ArchMonth As Short, ByVal ArchDay As Short, ByVal ArchHour As Short) As String

        Dim retsum As String

        Try


            cleararchive(Arch)
            EraseInputQueue()


            Dim dt1 As Date
            Dim dt2 As Date
            Dim devdate As Date
            Dim checkdate As Date

            devdate = GetDeviceDate()
            checkdate = devdate.AddHours(-1)
            dt2 = New Date(ArchYear, ArchMonth, ArchDay, ArchHour, 0, 0)
            If dt2 <= checkdate Then
                Arch.archType = ArchType
                If ArchType = archType_hour Then
                    dt2 = New Date(ArchYear, ArchMonth, ArchDay, ArchHour, 0, 0)
                    dt1 = dt2
                    SetArchType(VKT7ArchType.AT_Hour)
                    If IsError Then
                        Return ErrorMessage
                    End If
                    SetArchDate(dt2)
                    If IsError Then
                        Return ErrorMessage
                    End If
                    GetList()
                    If IsError Then
                        Return ErrorMessage
                    End If

                End If

                If ArchType = archType_day Then

                    dt2 = New Date(ArchYear, ArchMonth, ArchDay, 0, 0, 0)
                    dt2.AddHours(-1)
                    dt1 = New Date(ArchYear, ArchMonth, ArchDay, 0, 0, 0)
                    dt1.AddMinutes(-1)
                    SetArchType(VKT7ArchType.AT_Day)
                    If IsError Then
                        Return ErrorMessage
                    End If
                    SetArchDate(dt2)
                    If IsError Then
                        Return ErrorMessage
                    End If
                    GetList()
                    If IsError Then
                        Return ErrorMessage
                    End If

                End If
            End If

            Dim AErr As String
            'AErr = "Ошибка в получении параметров: "
            AErr = ""
            Arch.QG1 = GetParam(VKT7ElemType.Qg_1TypeP)
            If IsError Then
                If VerifyElement(VKT7ElemType.Qg_1TypeP) Then AErr += "QG1;"
            End If
            Arch.QG2 = GetParam(VKT7ElemType.Qg_2TypeP)
            If IsError Then
                If VerifyElement(VKT7ElemType.Qg_2TypeP) Then AErr += "QG2;"
            End If
            Arch.M1 = GetParam(VKT7ElemType.M1_1Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.M1_1Type) Then AErr += "M1;"
            End If
            Arch.M2 = GetParam(VKT7ElemType.M2_1Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.M2_1Type) Then AErr += "M2;"
            End If
            Arch.M3 = GetParam(VKT7ElemType.M3_1Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.M3_1Type) Then AErr += "M3;"
            End If
            Arch.M4 = GetParam(VKT7ElemType.M1_2Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.M1_2Type) Then AErr += "M4;"
            End If
            Arch.M5 = GetParam(VKT7ElemType.M2_2Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.M2_2Type) Then AErr += "M5;"
            End If
            Arch.M6 = GetParam(VKT7ElemType.M3_2Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.M3_2Type) Then AErr += "M6;"
            End If


            Arch.V1 = GetParam(VKT7ElemType.V1_1Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.V1_1Type) Then AErr += "V1;"
            End If
            Arch.V2 = GetParam(VKT7ElemType.V2_1Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.V2_1Type) Then AErr += "V2;"
            End If
            Arch.V3 = GetParam(VKT7ElemType.V1_2Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.V1_2Type) Then AErr += "V3;"
            End If
            Arch.v4 = GetParam(VKT7ElemType.V2_2Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.V2_2Type) Then AErr += "V4;"
            End If
            Arch.Q1 = GetParam(VKT7ElemType.Qo_1TypeP)
            If IsError Then
                If VerifyElement(VKT7ElemType.Qo_1TypeP) Then AErr += "Q1;"
            End If
            Arch.Q2 = GetParam(VKT7ElemType.Qo_2TypeP)
            If IsError Then
                If VerifyElement(VKT7ElemType.Qo_2TypeP) Then AErr += "Q2;"
            End If


            Arch.T1 = GetParam(VKT7ElemType.t1_1Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.t1_1Type) Then AErr += "T1;"
            End If
            Arch.T2 = GetParam(VKT7ElemType.t2_1Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.t2_1Type) Then AErr += "T2;"
            End If
            Arch.T3 = GetParam(VKT7ElemType.t3_1Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.t3_1Type) Then AErr += "T3;"
            End If
            Arch.T4 = GetParam(VKT7ElemType.t1_2Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.t1_2Type) Then AErr += "T4;"
            End If
            Arch.T5 = GetParam(VKT7ElemType.t2_2Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.t2_2Type) Then AErr += "T5;"
            End If
            Arch.T6 = GetParam(VKT7ElemType.t3_2Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.t3_2Type) Then AErr += "T6;"
            End If



            Arch.HCtv1 = GetParam(VKT7ElemType.NSPrintTypeM_1)
            If IsError Then
                If VerifyElement(VKT7ElemType.NSPrintTypeM_1) Then AErr += "HCtv1;"
            End If
            Arch.HCtv2 = GetParam(VKT7ElemType.NSPrintTypeM_2)
            If IsError Then
                If VerifyElement(VKT7ElemType.NSPrintTypeM_2) Then
                    If Not OldVersion Then
                        AErr += "HCtv2;"
                    Else
                        Arch.HCtv2 = 32
                    End If
                End If

            End If

            Arch.P1 = GetParam(VKT7ElemType.P1_1Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.P1_1Type) Then AErr += "P1;"
            End If
            Arch.P2 = GetParam(VKT7ElemType.P2_1Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.P2_1Type) Then AErr += "P2;"
            End If
            Arch.P3 = GetParam(VKT7ElemType.P2_1Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.P2_1Type) Then AErr += "P3;"
            End If
            Arch.P4 = GetParam(VKT7ElemType.P2_2Type)
            If IsError Then
                If VerifyElement(VKT7ElemType.P2_2Type) Then AErr += "P4;"
            End If

            Arch.DateArch = dt1

            Arch.errtime1 = GetParam(VKT7ElemType.QntType_1P)
            If IsError Then
                'AErr += "errtime1;"
            End If
            Arch.errtime2 = GetParam(VKT7ElemType.Qnt_2TypeP)
            If IsError Then
                'AErr += "errtime2;"
            End If
            Arch.oktime1 = GetParam(VKT7ElemType.QntType_1HIP)
            If IsError Then
                'AErr += "oktime1;"
            End If
            Arch.oktime2 = GetParam(VKT7ElemType.Qnt_2TypeHIP)
            If IsError Then
                'AErr += "oktime2;"
            End If

            If AErr = "" Then
                retsum = "Архив прочитан"
                retsum = retsum & vbCrLf
                EraseInputQueue()
                isArchToDBWrite = True
            Else


                retsum = "Ошибка: не удалось получить часть параметров " & dt2.ToString() + "->"
                retsum = retsum & AErr & vbCrLf
                EraseInputQueue()
                isArchToDBWrite = False
            End If

            Return retsum
        Catch ex As System.Exception
            Return "Ошибка:" & ex.Message
        End Try
    End Function
    Public Function ProcessRcvData(ByVal buf() As Byte, ByVal ret As Short) As String


        Return "Ошибка!Пакет не распознан"
    End Function
    Public Function GetAndProcessData() As String

        Return ""
    End Function
    Public Function DeCodeHCNumber(ByVal CodeHC As Long) As String
        Try
            DeCodeHCNumber = Chr(CodeHC)
        Catch ex As Exception
            DeCodeHCNumber = "-"
        End Try






    End Function
    Public Function DeCodeHCText(ByVal CodeHC As Long) As String
        Try
            DeCodeHCText = Chr(CodeHC)

        Catch ex As Exception
            DeCodeHCText = "-"
        End Try


    End Function
    Public Function DeCodeHC(ByVal CodeHC As Long) As String
        Try
            DeCodeHC = Chr(CodeHC)
        Catch ex As Exception
            DeCodeHC = "-"
        End Try


    End Function


    Public Overrides Function WriteArchToDB() As String

        If Arch.archType <> 4 Then
            Arch.DateArch = Arch.DateArch.AddSeconds(1)
        End If

        WriteArchToDB = "INSERT INTO " + TableForArch(Arch.archType) + "(" + TableForArch(Arch.archType) + "id,instanceid,DCALL,DCOUNTER,t1,t2,t3,t4,t5,t6,tce1,tce2,tair1,tair2,p1,p2,p3,p4,v1,v2,v3,v4,v5,v6,m1,m2,m3,m4,m5,m6,dm12,V1H,V2H,V5H,V4H,q1h,q2h,sp_TB1,sp_TB2,q1,q2,q4,q5,TSUM1,TSUM2,hc_code,hc, oktime,errtime) values ("
        WriteArchToDB = WriteArchToDB + "" + GUID2String(MyManager.Session, Guid.NewGuid) + ","
        WriteArchToDB = WriteArchToDB + "" + guid2string(mymanager.session, DeviceID) + ","
        WriteArchToDB = WriteArchToDB + "" + MyManager.Session.GetProvider.GetServerDate() + "" + ","
        WriteArchToDB = WriteArchToDB + MyManager.Session.GetProvider.Date2Const(Arch.DateArch) + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.T1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.T2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.T3, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.T4, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.T5, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.T6, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.tx1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.tx2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.tair1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.tair2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.P1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.P2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.P3, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.P4, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.V1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.V2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.V3, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.v4, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.v5, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.v6, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.M1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.M2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.M3, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.M4, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.M5, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.M6, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.M1 - Arch.M2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.V1h, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.V2h, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.V3h, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.V4h, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.Q1H, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.Q2H, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.SPtv1.ToString + ","
        WriteArchToDB = WriteArchToDB + Arch.SPtv2.ToString + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.Q1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.Q2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.QG1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.QG2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.Tw1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.Tw2, "##############0.000").Replace(",", ".") + ","




        WriteArchToDB = WriteArchToDB + "'" + S180(DeCodeHCNumber(Arch.HCtv1)) + "','" + S180(DeCodeHCNumber(Arch.HCtv2)) + "'"

        WriteArchToDB = WriteArchToDB + "," + Format((Arch.oktime1 + Arch.oktime2), "##############0").Replace(",", ".")
        WriteArchToDB = WriteArchToDB + "," + Format(Arch.errtime1 + Arch.errtime2, "##############0").Replace(",", ".")

        WriteArchToDB = WriteArchToDB + ")"
        Debug.Print(WriteArchToDB)
    End Function


    Public Overrides Function WriteMArchToDB() As String
        WriteMArchToDB = ""
        Try
            WriteMArchToDB = "INSERT INTO " + TableForArch(1) + "(" + TableForArch(1) + "id,instanceid,DCALL,DCOUNTER,t1,t2,t3,t4,t5,t6,p1,p2,p3,p4,g1,g2,g3,g4,g5,g6,v1,v2,v3,v4,dt12,dt45,sp_TB1,sp_TB2,tce1,tce2,tair1,tair2,hc_code,hc,hc_1,hc_2) values ("
            WriteMArchToDB = WriteMArchToDB + "" + GUID2String(MyManager.Session, Guid.NewGuid) + ","
            WriteMArchToDB = WriteMArchToDB + "" + guid2string(mymanager.session, DeviceID) + ","
            WriteMArchToDB = WriteMArchToDB + "" + MyManager.Session.GetProvider.GetServerDate() + "" + ","
            WriteMArchToDB = WriteMArchToDB + MyManager.Session.GetProvider.Date2Const(Arch.DateArch) + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.t1, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.t2, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.t3, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.t4, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.t5, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.t6, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.p1, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.p2, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.p3, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.p4, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.G1, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.G2, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.G3, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.G4, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.G5, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.G6, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.v1, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.v2, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.v3, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.v4, "##############0.000").Replace(",", ".") + ","

            WriteMArchToDB = WriteMArchToDB + Format(mArch.dt12, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.dt45, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.SPtv1.ToString + ","
            WriteMArchToDB = WriteMArchToDB + mArch.SPtv2.ToString + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.tx1, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.tx2, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.tair1, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.tair2, "##############0.000").Replace(",", ".") + ","




            WriteMArchToDB = WriteMArchToDB + "'" + DeCodeHCNumber(mArch.HC) + "','" + S180(DeCodeHCNumber(mArch.HC) + " " + DeCodeHCText(mArch.HC)) + "',"

            WriteMArchToDB = WriteMArchToDB + "'" + S180(DeCodeHCNumber(mArch.HCtv1) + " " + DeCodeHCText(mArch.HCtv1)) + "',"
            WriteMArchToDB = WriteMArchToDB + "'" + S180(DeCodeHCNumber(mArch.HCtv2) + " " + DeCodeHCText(mArch.HCtv2)) + "'"



            WriteMArchToDB = WriteMArchToDB + ")"
        Catch
        End Try
        'Return WriteMArchToDB
    End Function

  


    Public Sub EraseInputQueue()
        If (IsBytesToRead = True) Then
            IsBytesToRead = False
        End If
        bufferindex = 0
        Dim i As Short
        Dim buffer(1024) As Byte

        i = MyTransport.BytesToRead
        While (i > 0 And MyTransport.IsConnected)
            MyTransport.Read(buffer, 0, i)

            i = MyTransport.BytesToRead

        End While

    End Sub
    Private Sub cleararchive(ByRef arc As Archive)
        arc.DateArch = DateTime.MinValue

        arc.HC = 0
        arc.MsgHC = ""

        arc.HCtv1 = 0
        arc.MsgHCtv1 = ""

        arc.HCtv2 = 0
        arc.MsgHCtv2 = ""

        arc.Tw1 = 0
        arc.Tw2 = 0

        arc.P1 = 0
        arc.T1 = 0
        arc.M2 = 0
        arc.V1 = 0

        arc.P2 = 0
        arc.T2 = 0
        arc.M3 = 0
        arc.V2 = 0

        arc.V3 = 0
        arc.M1 = 0

        arc.Q1 = 0
        arc.Q2 = 0

        arc.QG1 = 0
        arc.QG2 = 0

        arc.MyTransport = 0
        arc.SPtv1 = 0
        arc.SPtv2 = 0

        arc.tx1 = 0
        arc.tx2 = 0
        arc.tair1 = 0
        arc.tair2 = 0

        arc.T3 = 0
        arc.T4 = 0
        arc.T5 = 0
        arc.T6 = 0
        arc.P3 = 0
        arc.P4 = 0
        arc.v4 = 0
        arc.v5 = 0
        arc.v6 = 0
        arc.M4 = 0
        arc.M5 = 0
        arc.M6 = 0

        arc.archType = 0
        isArchToDBWrite = False
    End Sub
    Private Sub clearMarchive(ByRef marc As MArchive)
        marc.DateArch = DateTime.MinValue
        marc.HC = 0
        marc.MsgHC = ""

        marc.HCtv1 = 0
        marc.MsgHCtv1 = ""

        marc.HCtv2 = 0
        marc.MsgHCtv2 = ""

        marc.G1 = 0
        marc.G2 = 0
        marc.G3 = 0
        marc.G4 = 0
        marc.G5 = 0
        marc.G6 = 0

        marc.t1 = 0
        marc.t2 = 0
        marc.t3 = 0
        marc.t4 = 0
        marc.t5 = 0
        marc.t6 = 0

        marc.p1 = 0
        marc.p2 = 0
        marc.p3 = 0
        marc.p4 = 0

        marc.dt12 = 0
        marc.dt45 = 0

        marc.tx1 = 0
        marc.tx2 = 0

        marc.tair1 = 0
        marc.tair2 = 0

        marc.MyTransport = 0
        marc.SPtv1 = 0
        marc.SPtv2 = 0


        marc.archType = 1
        isMArchToDBWrite = False
    End Sub

    Private Function ChanelToByte(ByVal ch As Byte) As Byte
        '1 – первый канал,
        '0 – второй канал,
        '2 – холодная вода,
        '4 – четвертый канал,
        '3 – пятый канал.

        Select Case ch
            Case 1
                Return 1
            Case 2
                Return 0
            Case 3
                Return 2
            Case 4
                Return 4
            Case 5
                Return 3
            Case Else
                Return ch
        End Select
    End Function









    Public Overrides Function ReadMArch() As String



        clearMarchive(mArch)
        SetArchType(VKT7ArchType.AT_Current)
        If IsError Then
            Return ErrorMessage
        End If
        GetList()
        If IsError Then
            Return ErrorMessage
        End If

        Dim AErr As String = ""
        Dim pVal As String
        pVal = GetParam(VKT7ElemType.G1Type)
        mArch.G1 = pVal
        If IsError Then
            AErr += "G1;"
        End If
        pVal = GetParam(VKT7ElemType.G2Type)
        mArch.G2 = pVal
        If IsError Then
            AErr += "G2;"
        End If
        pVal = GetParam(VKT7ElemType.G3Type)
        mArch.G3 = pVal
        If IsError Then
            AErr += "G3;"
        End If

        pVal = GetParam(VKT7ElemType.G1_2Type)
        mArch.G4 = pVal
        If IsError Then
            AErr += "G4;"
        End If
        pVal = GetParam(VKT7ElemType.G2_2Type)
        mArch.G5 = pVal
        If IsError Then
            AErr += "G5;"
        End If
        pVal = GetParam(VKT7ElemType.G3_2Type)
        mArch.G6 = pVal
        If IsError Then
            AErr += "G6;"
        End If

        pVal = GetParam(VKT7ElemType.t1_1Type)
        mArch.t1 = pVal
        If IsError Then
            AErr += "t1;"
        End If
        pVal = GetParam(VKT7ElemType.t2_1Type)
        mArch.t2 = pVal
        If IsError Then
            AErr += "t2;"
        End If
        pVal = GetParam(VKT7ElemType.t3_1Type)
        mArch.t3 = pVal
        If IsError Then
            AErr += "t3;"
        End If
        pVal = GetParam(VKT7ElemType.t1_2Type)
        mArch.t4 = pVal
        If IsError Then
            AErr += "t4;"
        End If
        pVal = GetParam(VKT7ElemType.t2_2Type)
        mArch.t5 = pVal
        If IsError Then
            AErr += "t5;"
        End If
        pVal = GetParam(VKT7ElemType.t3_2Type)
        mArch.t6 = pVal
        If IsError Then
            AErr += "t6;"
        End If
        pVal = GetParam(VKT7ElemType.dt_1TypeP)
        mArch.dt12 = pVal
        If IsError Then
            AErr += "dt12;"
        End If
        pVal = GetParam(VKT7ElemType.dt_2TypeP)
        mArch.dt45 = pVal
        If IsError Then
            AErr += "dt45;"
        End If

        pVal = GetParam(VKT7ElemType.Qg_1TypeP)
        mArch.dQ1 = pVal
        If IsError Then
            AErr += "dQ1;"
        End If
        pVal = GetParam(VKT7ElemType.Qg_2TypeP)
        mArch.dQ2 = pVal
        If IsError Then
            AErr += "dQ2;"
        End If
        pVal = GetParam(VKT7ElemType.tswTypeP)
        mArch.tx1 = pVal
        If IsError Then
            AErr += "tx1;"
        End If

        mArch.v1 = GetParam(VKT7ElemType.V1_1Type)
        If IsError Then
            If VerifyElement(VKT7ElemType.V1_1Type) Then AErr += "V1;"
        End If
        mArch.v2 = GetParam(VKT7ElemType.V2_1Type)
        If IsError Then
            If VerifyElement(VKT7ElemType.V2_1Type) Then AErr += "V2;"
        End If
        mArch.v3 = GetParam(VKT7ElemType.V1_2Type)
        If IsError Then
            If VerifyElement(VKT7ElemType.V1_2Type) Then AErr += "V3;"
        End If
        mArch.v4 = GetParam(VKT7ElemType.V2_2Type)
        If IsError Then
            If VerifyElement(VKT7ElemType.V2_2Type) Then AErr += "V4;"
        End If




        mArch.DateArch = GetDeviceDate()


        Try
            pVal = GetParam(VKT7ElemType.NSPrintTypeM_1)
            mArch.HCtv1 = Convert.ToInt32(pVal, 2)


        Catch
        End Try

        Try
            pVal = GetParam(VKT7ElemType.NSPrintTypeM_2)
            mArch.HCtv2 = Convert.ToInt32(pVal, 2)


        Catch
        End Try

        Dim retsum As String
        retsum = "Мгновенный архив прочитан"
        If AErr = "" Then
            'retsum = "Мгновенный архив прочитан"
            retsum = retsum & vbCrLf
            EraseInputQueue()
            isMArchToDBWrite = True
            Return retsum
        Else
            retsum = "Не удалось получить часть параметров "
            retsum = retsum & AErr & vbCrLf
            EraseInputQueue()
            isMArchToDBWrite = True
            Return retsum
        End If


    End Function
    Dim m_isTArchToDBWrite As Boolean = False
    Public Overrides Property isTArchToDBWrite() As Boolean
        Get
            Return m_isTArchToDBWrite
        End Get
        Set(ByVal value As Boolean)
            m_isTArchToDBWrite = value
        End Set
    End Property

    Public Function ReadFlashSync(ByVal fistpage As Integer, ByVal ReadPageCount As Integer) As String
        Return ""
    End Function

    Public Function ReadRAMSync(ByVal fistbyte As Integer, ByVal byteCount As Integer) As String
        Return ""
    End Function

    Private Sub clearTarchive(ByRef marc As TArchive)
        marc.DateArch = DateTime.MinValue


        marc.V1 = 0
        marc.V2 = 0
        marc.V3 = 0
        marc.V4 = 0
        marc.V5 = 0
        marc.V6 = 0
        marc.M1 = 0
        marc.M2 = 0
        marc.M3 = 0
        marc.M4 = 0
        marc.M5 = 0
        marc.M6 = 0
        marc.Q1 = 0
        marc.Q2 = 0
        marc.TW1 = 0
        marc.TW2 = 0

        marc.archType = 2
        isTArchToDBWrite = False
    End Sub

    Public Overrides Function ReadTArch() As String
        Dim AErr As String = ""
        clearTarchive(tArch)
        EraseInputQueue()


        SetArchType(VKT7ArchType.AT_CurItog)
        If IsError Then
            Return ErrorMessage
        End If
        GetList()
        If IsError Then
            Return ErrorMessage
        End If

        Dim pVal As String
        pVal = GetParam(VKT7ElemType.M1_1Type)
        tArch.M1 = pVal
        If IsError Then
            AErr += "M1;"
        End If
        pVal = GetParam(VKT7ElemType.M2_1Type)
        tArch.M2 = pVal
        If IsError Then
            AErr += "M2;"
        End If
        pVal = GetParam(VKT7ElemType.M3_1Type)
        tArch.M3 = pVal
        If IsError Then
            AErr += "M3;"
        End If
        pVal = GetParam(VKT7ElemType.M1_2Type)
        tArch.M4 = pVal
        If IsError Then
            AErr += "M4;"
        End If
        pVal = GetParam(VKT7ElemType.M2_2Type)
        tArch.M5 = pVal
        If IsError Then
            AErr += "M5;"
        End If
        pVal = GetParam(VKT7ElemType.M3_2Type)
        tArch.M6 = pVal
        If IsError Then
            AErr += "M6;"
        End If


        pVal = GetParam(VKT7ElemType.V1_1Type)
        tArch.V1 = pVal
        If IsError Then
            AErr += "v1;"
        End If
        pVal = GetParam(VKT7ElemType.V2_1Type)
        tArch.V2 = pVal
        If IsError Then
            AErr += "v2;"
        End If
        pVal = GetParam(VKT7ElemType.V3_1Type)
        tArch.V3 = pVal
        If IsError Then
            AErr += "v3;"
        End If
        pVal = GetParam(VKT7ElemType.V1_2Type)
        tArch.V4 = pVal
        If IsError Then
            AErr += "v4;"
        End If
        pVal = GetParam(VKT7ElemType.V2_2Type)
        tArch.V5 = pVal
        If IsError Then
            AErr += "v5;"
        End If
        pVal = GetParam(VKT7ElemType.V3_2Type)
        tArch.V6 = pVal
        If IsError Then
            AErr += "v6;"
        End If




        pVal = GetParam(VKT7ElemType.Qo_1TypeP)
        tArch.Q1 = pVal
        If IsError Then
            AErr += "Q1;"
        End If
        pVal = GetParam(VKT7ElemType.Qo_2TypeP)
        tArch.Q2 = pVal
        If IsError Then
            AErr += "Q2;"
        End If
        pVal = GetParam(VKT7ElemType.Qg_1TypeP)
        tArch.Q3 = pVal
        If IsError Then
            AErr += "Q3;"
        End If
        pVal = GetParam(VKT7ElemType.Qg_2TypeP)
        tArch.Q4 = pVal
        If IsError Then
            AErr += "Q4;"
        End If
        Try
            tArch.errtime1 = GetParam(VKT7ElemType.QntType_1P)
            tArch.errtime2 = GetParam(VKT7ElemType.Qnt_2TypeP)
            tArch.oktime1 = GetParam(VKT7ElemType.QntType_1HIP)
            tArch.oktime2 = GetParam(VKT7ElemType.Qnt_2TypeHIP)
        Catch ex As Exception

        End Try





        tArch.DateArch = GetDeviceDate()




        Dim retsum As String
        retsum = "Итоговый архив прочитан"
        If AErr = "" Then

            retsum = retsum & vbCrLf
            EraseInputQueue()
            isTArchToDBWrite = True
            Return retsum
        Else
            retsum = "Не удалось получить часть параметров "
            retsum = retsum & AErr & vbCrLf
            EraseInputQueue()
            isTArchToDBWrite = True
            Return retsum
        End If

    End Function

    Public Overrides Function WriteTArchToDB() As String
        WriteTArchToDB = "INSERT INTO " + TableForArch(tArch.archType) + "(" + TableForArch(tArch.archType) + "id,instanceid,DCALL,DCOUNTER,Q1H,Q2H,Q4,Q5,M1,M2,M3,M4,M5,M6,v1h,v2h,v3,v4h,v5h,v6,TSUM1,TSUM2,worktime,ERRTIME) values ("
        WriteTArchToDB = WriteTArchToDB + "" + GUID2String(MyManager.Session, Guid.NewGuid) + ","
        WriteTArchToDB = WriteTArchToDB + "" + guid2string(mymanager.session, DeviceID) + ","
        WriteTArchToDB = WriteTArchToDB + "" + MyManager.Session.GetProvider.GetServerDate() + "" + ","
        WriteTArchToDB = WriteTArchToDB + MyManager.Session.GetProvider.Date2Const(tArch.DateArch) + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.Q1, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.Q2, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.Q3, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.Q4, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.V1, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.V2, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.V3, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.V4, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.V5, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.V6, "##############0.000").Replace(",", ".") + ","

        WriteTArchToDB = WriteTArchToDB + Format(tArch.V1, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.V2, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.V3, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.V4, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.V5, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.V6, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.TW1, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.TW2, "##############0.000").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.oktime1 + tArch.oktime2, "##############0").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.errtime1 + tArch.errtime2, "##############0").Replace(",", ".")
        WriteTArchToDB = WriteTArchToDB + ")"
    End Function

    Private Function ExtLong4(ByVal extStr As String) As Double
        Dim i As Long
        On Error Resume Next
        ExtLong4 = 0
        For i = 0 To 3
            ExtLong4 = ExtLong4 + Asc(Mid(extStr, 1 + i, 1)) * (256 ^ (i))
        Next i
    End Function

    Public Overrides Function WriteErrToDB(ByVal ErrDate As Date, ByVal ErrMsg As String) As String
        Dim SSS As String
        SSS = "INSERT INTO " & TableForArch(1) & "(" & TableForArch(1) & "id,instanceid,DCALL,DCOUNTER,id_ptype,hc,hc_1,hc_2) values ("
        SSS = SSS + +"" + GUID2String(MyManager.Session, Guid.NewGuid) + ","
        SSS = SSS + +"" + guid2string(mymanager.session, DeviceID) + ","
        SSS = SSS + +"" + MyManager.Session.GetProvider.GetServerDate() + "" + ","
        SSS = SSS + +MyManager.Session.GetProvider.Date2Const(ErrDate) + ","

        SSS = SSS + "'" & S180(ErrMsg) & "',"
        SSS = SSS + "'" & S180(ErrMsg) & "',"
        SSS = SSS + "'" & S180(ErrMsg) & "')"
        Return SSS
    End Function
    Public Overrides Function IsConnected() As Boolean
        Return mIsConnected And MyTransport.IsConnected
    End Function



   

    Private mIsError As Boolean

    Public Property IsError() As Boolean
        Get
            Return mIsError
        End Get
        Private Set(ByVal value As Boolean)
            mIsError = value
        End Set
    End Property

    Private mErrorMessage As String

    Public Property ErrorMessage() As String
        Get
            Return mErrorMessage
        End Get
        Private Set(ByVal value As String)
            mErrorMessage = value
        End Set
    End Property

    

    Public Overrides Function ReadSystemParameters() As DataTable
        Dim dt As DataTable
        dt = New DataTable
        dt.Columns.Add("Название")
        dt.Columns.Add("Значение")

        'Dim dr As DataRow
        Return dt
    End Function



    Public Overrides Sub CloseTransportConnect()
        If Not MyTransport Is Nothing Then
            Try
                MyTransport.DisConnect()
            Catch
            End Try

            MyTransport = Nothing
        End If
    End Sub






    Public Overrides Property isMArchToDBWrite() As Boolean
        Get
            Return m_isMArchToDBWrite
        End Get
        Set(ByVal value As Boolean)
            m_isMArchToDBWrite = value
        End Set
    End Property





    ''''''''''''''''''''''''''''''' VKT7 specific '''''''''''''''''
    Private Enum VKT7ElemType
        t1_1Type = 0   't1 Тв1 параметр                                                    
        t2_1Type = 1   't2 Тв1 параметр                                                    
        t3_1Type = 2   't3 Тв1 параметр                                                    
        V1_1Type = 3   'V1 Тв1 параметр                                                    
        V2_1Type = 4   'V2 Тв1 параметр                                                    
        V3_1Type = 5   'V3 Тв1 параметр                                                    
        M1_1Type = 6   'M1 Тв1 параметр                                                    
        M2_1Type = 7   'M2 Тв1 параметр                                                    
        M3_1Type = 8   'M3 Тв1 параметр                                                    
        P1_1Type = 9   'P1 Тв1 параметр                                                    
        P2_1Type = 10  'P2 Тв1 параметр                                                    
        Mg_1TypeP = 11  'Mг Тв1 параметр                                                    
        Qo_1TypeP = 12  'Qо Тв1 параметр                                                    
        Qg_1TypeP = 13  'Qг Тв1 параметр                                                    
        dt_1TypeP = 14  'dt Тв1 параметр                                                    
        tswTypeP = 15  'tх параметр                                                        
        taTypeP = 16  'ta параметр                                                        
        QntType_1HIP = 17  'BНP Тв1 параметр                                                   
        QntType_1P = 18  'BOC Тв1 параметр                                                   
        G1Type = 19  'G1 Тв1 параметр                                                    
        G2Type = 20  'G2 Тв1 параметр                                                    
        G3Type = 21  'G3 Тв1 параметр                                                    
        t1_2Type = 22  't1 Тв2 параметр                                                    
        t2_2Type = 23  't2 Тв2 параметр                                                    
        t3_2Type = 24  't3 Тв2 параметр                                                    
        V1_2Type = 25  'V1 Тв2 параметр                                                    
        V2_2Type = 26  'V2 Тв2 параметр                                                    
        V3_2Type = 27  'V3 Тв2 параметр                                                    
        M1_2Type = 28  'M1 Тв2 параметр                                                    
        M2_2Type = 29  'M2 Тв2 параметр                                                    
        M3_2Type = 30  'M3 Тв2 параметр                                                    
        P1_2Type = 31  'P1 Тв2 параметр                                                    
        P2_2Type = 32  'P2 Тв2 параметр                                                    
        Mg_2TypeP = 33  'Mг Тв2 параметр                                                    
        Qo_2TypeP = 34  'Qо Тв2 параметр                                                    
        Qg_2TypeP = 35  'Qг Тв2 параметр                                                    
        dt_2TypeP = 36  'dt Тв2 параметр                                                    
        tsw_2TypeP = 37  'резерв параметр                                                    
        ta_2TypeP = 38  'резерв параметр                                                    
        Qnt_2TypeHIP = 39  'BНP Тв2 параметр                                                   
        Qnt_2TypeP = 40  'BOC Тв2 параметр                                                   
        G1_2Type = 41  'G1 Тв2 параметр                                                    
        G2_2Type = 42  'G2 Тв2 параметр                                                    
        G3_2Type = 43  'G3 Тв2 параметр                                                    
        tTypeM = 44  'ед. измерения по t (температуре) свойство                          
        GTypeM = 45  'ед. измерения по G (расходу) свойство                              
        VTypeM = 46  'ед. измерения по V (объему) свойство                               
        MTypeM = 47  'ед. измерения по M (массе) свойство                                
        PTypeM = 48  'ед. измерения по P (давлению) свойство                             
        dtTypeM = 49  'ед. измерения по dt (температуре) свойство                         
        tswTypeM = 50  'ед. измерения по tx (температуре) свойство                         
        taTypeM = 51  'ед. измерения по ta (температуре) свойство                         
        MgTypeM = 52  'ед. измерения по M (массе) свойство                                
        QoTypeM = 53  'ед. измерения по Q (теплу) свойство                                
        QgTypeM = 54  'ед. измерения по Q (теплу) свойство                                
        QntTypeHIM = 55  'ед. измерения по BНP (времени) свойство                            
        QntTypeM = 56  'ед. измерения по ВОС (времени)* (см. прим.) свойство               
        tTypeFractDiNum = 57  'кол-во знаков после запятой для t свойство                         
        GTypeFractDigNum1 = 58  'резерв свойство                                                    
        VTypeFractDigNum1 = 59  'кол-во знаков после запятой для V по Тв1 свойство                  
        MTypeFractDigNum1 = 60  'кол-во знаков после запятой для M по Тв1 свойство                  
        PTypeFractDigNum1 = 61  'кол-во знаков после запятой для P свойство                         
        dtTypeFractDigNum1 = 62  'кол-во знаков после запятой для dt свойство                        
        tswTypeFractDigNum1 = 63  'кол-во знаков после запятой для tx свойство                        
        taTypeFractDigNum1 = 64  'кол-во знаков после запятой для ta свойство                        
        MgTypeFractDigNum1 = 65  'кол-во знаков после запятой для Mг свойство                        
        QoTypeFractDigNum1 = 66  'кол-во знаков после запятой для Q по Тв1 свойство                  
        tTypeFractDigNum2 = 67  'резерв свойство                                                    
        GTypeFractDigNum2 = 68  'резерв свойство                                                    
        VTypeFractDigNum2 = 69  'кол-во знаков после запятой для V по Тв2 свойство                  
        MTypeFractDigNum2 = 70  'кол-во знаков после запятой для M по Тв2 свойство                  
        PTypeFractDigNum2 = 71  'кол-во знаков после запятой для P свойство                         
        dtTypeFractDigNum2 = 72  'кол-во знаков после запятой для dt свойство                        
        tswTypeFractDigNum2 = 73  'кол-во знаков после запятой для tx свойство                        
        taTypeFractDigNum2 = 74  'кол-во знаков после запятой для ta свойство                        
        MgTypeFractDigNum2 = 75  'кол-во знаков после запятой для Mг свойство                        
        QoTypeFractDigNum2 = 76  'кол-во знаков после запятой для Q по Тв2 свойство                  
        NSPrintTypeM_1 = 77  'Наличие нештатной ситуации по ТВ1 параметр                         
        NSPrintTypeM_2 = 78  'Наличие нештатной ситуации по ТВ2 параметр                         
        QntNS_1 = 79  'Длительность HC по параметрам Тв1 параметр                         
        QntNS_2 = 80  'Длительность HC по параметрам Тв2 параметр                         
        DopInpImpP_Type = 81  ' DI параметр                                                   
        P3P_Type = 82  'P3 параметр    
    End Enum


    Private ActiveElements(100) As Integer
    Private ElemSize(100) As Byte
    Private PropVal(100) As Byte

    Private DigMap(100) As Byte

    Private Sub InitDigMap()
        Dim i As Integer
        For i = 0 To 100
            DigMap(i) = 0
        Next
        DigMap(0) = VKT7ElemType.tTypeFractDiNum
        DigMap(1) = VKT7ElemType.tTypeFractDiNum
        DigMap(2) = VKT7ElemType.tTypeFractDiNum
        DigMap(22) = VKT7ElemType.tTypeFractDiNum
        DigMap(23) = VKT7ElemType.tTypeFractDiNum
        DigMap(24) = VKT7ElemType.tTypeFractDiNum

        DigMap(3) = VKT7ElemType.VTypeFractDigNum1
        DigMap(4) = VKT7ElemType.VTypeFractDigNum1
        DigMap(65) = VKT7ElemType.VTypeFractDigNum1
        DigMap(25) = VKT7ElemType.VTypeFractDigNum2
        DigMap(26) = VKT7ElemType.VTypeFractDigNum2
        DigMap(27) = VKT7ElemType.VTypeFractDigNum2

        DigMap(6) = VKT7ElemType.MTypeFractDigNum1
        DigMap(7) = VKT7ElemType.MTypeFractDigNum1
        DigMap(8) = VKT7ElemType.MTypeFractDigNum1
        DigMap(28) = VKT7ElemType.MTypeFractDigNum2
        DigMap(29) = VKT7ElemType.MTypeFractDigNum2
        DigMap(30) = VKT7ElemType.MTypeFractDigNum2

        DigMap(9) = VKT7ElemType.PTypeFractDigNum1
        DigMap(10) = VKT7ElemType.PTypeFractDigNum1
        DigMap(31) = VKT7ElemType.PTypeFractDigNum2
        DigMap(32) = VKT7ElemType.PTypeFractDigNum2

        DigMap(11) = VKT7ElemType.MgTypeFractDigNum1
        DigMap(33) = VKT7ElemType.MgTypeFractDigNum2

        DigMap(12) = VKT7ElemType.QoTypeFractDigNum1
        DigMap(34) = VKT7ElemType.QoTypeFractDigNum2

        DigMap(13) = VKT7ElemType.QoTypeFractDigNum1
        DigMap(35) = VKT7ElemType.QoTypeFractDigNum2

        DigMap(14) = VKT7ElemType.dtTypeFractDigNum1
        DigMap(36) = VKT7ElemType.dtTypeFractDigNum2

        DigMap(15) = VKT7ElemType.tswTypeFractDigNum1
        DigMap(37) = VKT7ElemType.tswTypeFractDigNum2

        DigMap(16) = VKT7ElemType.taTypeFractDigNum1
        DigMap(38) = VKT7ElemType.taTypeFractDigNum2

        DigMap(19) = VKT7ElemType.GTypeFractDigNum1
        DigMap(20) = VKT7ElemType.GTypeFractDigNum1
        DigMap(21) = VKT7ElemType.GTypeFractDigNum1
        DigMap(41) = VKT7ElemType.taTypeFractDigNum2
        DigMap(42) = VKT7ElemType.taTypeFractDigNum2
        DigMap(43) = VKT7ElemType.taTypeFractDigNum2

    End Sub

    Public Function VerifySumm(ByVal Data() As Byte, ByVal offset As Integer, ByVal sz As Integer) As Boolean
        Dim ch As Long
        ch = CheckSum(Data, offset, sz - 2)
        If Data(sz - 2) = ch Mod 256 And Data(sz - 1) = ch \ 256 Then
            Return True
        End If
        Return False
    End Function



    Private Function CheckSum(ByVal Data() As Byte, ByVal offset As Integer, ByVal sz As Integer) As UInt16
        Dim s As UInt16
        Dim sl As Long
        sl = &HFFFF
        On Error Resume Next
        For i As Integer = 0 To sz - 1

            sl = ((sl \ 256) * 256 + ((sl Mod 256) Xor Data(offset + i))) And &HFFFF
            For sh As Integer = 0 To 7
                If (sl And 1) = 1 Then
                    sl = ((sl \ 2) Xor &HA001) And &HFFFF
                Else
                    sl = (sl \ 2) And &HFFFF
                End If


            Next
        Next
        s = sl And &HFFFF
        Return s
    End Function

    Private Function SelectElement(ByVal elemType As VKT7ElemType) As Boolean
        EraseInputQueue()

        Dim Frame(20) As Byte
        Dim ch As UInt16
        Frame(0) = &HFF
        Frame(1) = &HFF
        Frame(2) = &H0
        Frame(3) = &H10
        Frame(4) = &H3F
        Frame(5) = &HFF
        Frame(6) = &H0
        Frame(7) = &H0
        Frame(8) = &H6
        Frame(9) = elemType
        Frame(10) = &H0
        Frame(11) = &H0
        Frame(12) = 64
        Frame(13) = ElemSize(elemType)
        Frame(14) = 0


        ch = CheckSum(Frame, 2, 13)
        Frame(15) = ch Mod 256
        Frame(16) = ch \ 256

        MyTransport.Write(Frame, 0, 17)

        Dim t As Integer
        RaiseIdle()
        System.Threading.Thread.Sleep(300)
        t = 0
        While MyTransport.BytesToRead = 0 And t < 20
            RaiseIdle()
            System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
            t = t + 1
        End While

        Dim b(4096) As Byte
        Dim cnt As Integer
        cnt = MyTransport.BytesToRead
        If cnt > 0 Then
            Dim ptr As Integer
            Dim sz As Integer
            ptr = 0
            sz = 0
            While cnt > 0
                MyTransport.Read(b, ptr, cnt)
                ptr += cnt
                sz += cnt


                If VerifySumm(b, 0, sz) Then
                    If (b(1) = &H83 Or b(1) = &H90) Then
                        IsError = True
                        ErrorMessage = "Ошибка запроса код:" & b(2)
                        Return False
                    End If
                    Return True
                End If

                RaiseIdle()
                System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
                cnt = MyTransport.BytesToRead
            End While

        End If
        IsError = True
        ErrorMessage = "Ошибка получения данных"
        Return False

    End Function


    Private Function TryGetParam(ByVal ElemType As VKT7ElemType) As Double
        SelectElement(ElemType)

        If IsError Then
            Return 0
        End If

        Dim d As Double = 0.0

        Dim Frame(10) As Byte
        Dim ch As UInt16
        Frame(0) = &HFF
        Frame(1) = &HFF
        Frame(2) = &H0
        Frame(3) = &H3
        Frame(4) = &H3F
        Frame(5) = &HFE
        Frame(6) = &H0
        Frame(7) = &H0
        ch = CheckSum(Frame, 2, 6)
        Frame(8) = ch Mod 256
        Frame(9) = ch \ 256

        MyTransport.Write(Frame, 0, 10)

        Dim t As Integer
        RaiseIdle()
        System.Threading.Thread.Sleep(300)
        t = 0
        While MyTransport.BytesToRead = 0 And t < 20
            RaiseIdle()
            System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
            t = t + 1
        End While

        Dim b() As Byte
        ReDim b(4096)
        Dim sout As String = "0"

        Dim cnt As Integer
        cnt = MyTransport.BytesToRead
        If cnt > 0 Then
            Dim ptr As Integer
            Dim sz As Integer
            ptr = 0
            sz = 0
            While cnt > 0
                MyTransport.Read(b, ptr, cnt)
                ptr += cnt
                sz += cnt


                If VerifySumm(b, 0, sz) Then

                    If (b(1) = &H83 Or b(1) = &H90) Then
                        IsError = True
                        ErrorMessage = "Ошибка запроса код:" & b(2)
                        Return 0
                    End If

                    Dim z As ULong
                    Try


                        If b(2) = 3 Then

                            z = b(3)
                            sout = z.ToString()
                        End If

                        Dim digs As Integer
                        digs = 0
                        If ElemType >= 0 Then
                            digs = PropVal(DigMap(ElemType))
                        End If
                        If b(2) = 4 Then
                            z = b(4) * 256 + b(3)
                            sout = SetDot(z.ToString(), digs)
                        End If

                        If b(2) = 6 Then
                            If ElemType = VKT7ElemType.G1Type Or _
                               ElemType = VKT7ElemType.G2Type Or _
                               ElemType = VKT7ElemType.G3Type Or _
                               ElemType = VKT7ElemType.G1_2Type Or _
                               ElemType = VKT7ElemType.G2_2Type Or _
                               ElemType = VKT7ElemType.G3_2Type Then

                                Dim ddd As Double
                                ddd = BToSingle(b, 3)
                                sout = ddd.ToString().Replace(",", ".")
                            Else


                                z = b(6) * 256L * 65536L + b(5) * 65536L + b(4) * 256L + b(3)
                                sout = SetDot(z.ToString(), digs)
                            End If
                        End If
                        d = Val(sout)
                        Return d
                    Catch ex As Exception
                        Return 0
                    End Try
                End If

                RaiseIdle()
                System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
                cnt = MyTransport.BytesToRead
            End While


        End If
        IsError = True
        ErrorMessage = "Ошибка получения данных"
        Return d
    End Function

    Public Function Bytes2Float(ByVal fbytes() As Byte, ByVal index As Int16) As Single
        If UBound(fbytes) - index < 3 Then
            Return 0
        End If
        Return System.BitConverter.ToSingle(fbytes, index)
    End Function

    Private Function BToSingle(ByVal hexValue() As Byte, ByVal index As Int16) As Single

        Try

            Dim iInputIndex As Integer = 0

            Dim iOutputIndex As Integer = 0

            Dim bArray(3) As Byte



            For iInputIndex = 0 To 3

                bArray(iOutputIndex) = hexValue(index + iInputIndex)

                iOutputIndex += 1

            Next
            'Array.Reverse(bArray)
            Return BitConverter.ToSingle(bArray, 0)

        Catch ex As Exception

        End Try
    End Function


    Private Function GetParam(ByVal ElemType As VKT7ElemType) As Double
        IsError = False
        ErrorMessage = ""
        EraseInputQueue()

        Dim tryCnt = 0
        Dim r As Double
        While tryCnt < 5
            IsError = False
            r = TryGetParam(ElemType)
            If Not IsError Then
                Return r
            End If
            tryCnt += 1
        End While
        Return 0
    End Function


    Private Function SetDot(ByVal S As String, ByVal dig As Integer) As String
        Dim oo As String
        If dig > 0 Then
            oo = S
            While Len(oo) < dig + 1
                oo = "0" + oo
            End While

            Return oo.Substring(0, oo.Length - dig) + "." + oo.Substring(oo.Length - dig, dig)
        Else
            Return S
        End If
    End Function


    Private Function ReadData(Optional ByVal ElemType As Integer = -1) As Byte()

        Dim Frame(10) As Byte
        Dim ch As UInt16
        Frame(0) = &HFF
        Frame(1) = &HFF
        Frame(2) = &H0
        Frame(3) = &H3
        Frame(4) = &H3F
        Frame(5) = &HFE
        Frame(6) = &H0
        Frame(7) = &H0
        ch = CheckSum(Frame, 2, 6)
        Frame(8) = ch Mod 256
        Frame(9) = ch \ 256

        MyTransport.Write(Frame, 0, 10)

        Dim t As Integer
        Dim i As Integer
        RaiseIdle()
        System.Threading.Thread.Sleep(300)
        t = 0
        While MyTransport.BytesToRead = 0 And t < 20
            RaiseIdle()
            System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
            t = t + 1
        End While

        Dim b() As Byte
        ReDim b(4096)
        Dim cnt As Integer
        cnt = MyTransport.BytesToRead
        If cnt > 0 Then
            Dim ptr As Integer
            Dim sz As Integer
            ptr = 0
            sz = 0
            While cnt > 0
                MyTransport.Read(b, ptr, cnt)
                ptr += cnt
                sz += cnt


                If VerifySumm(b, 0, sz) Then
                    Dim sout As String = ""
                    Dim cout As String = ""
                    For i = 0 To cnt - 1
                        sout = sout + " " + b(i).ToString()


                    Next


                    If b(2) = 3 Then
                        Dim q As Integer
                        q = b(3)

                    End If

                    Dim digs As Integer
                    digs = 0
                    If ElemType >= 0 Then
                        digs = PropVal(DigMap(ElemType))
                    End If
                    If b(2) = 4 Then
                        Dim r As Integer
                        r = b(4) * 256 + b(3)

                    End If

                    If b(2) = 6 Then
                        Dim z As Long
                        z = b(6) * 256 * 65536 + b(5) * 65536 + b(4) * 256 + b(3)

                    End If

                End If

                RaiseIdle()
                System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
                cnt = MyTransport.BytesToRead
            End While
            Return b
        Else

            Return b
        End If

    End Function


    Private Function GetDeviceDate2() As Date
        EraseInputQueue()

        Dim Frame(10) As Byte
        Dim ch As UInt16
        Frame(0) = &HFF
        Frame(1) = &HFF
        Frame(2) = &H0
        Frame(3) = &H3
        Frame(4) = &H3F
        Frame(5) = &HF6
        Frame(6) = 0
        Frame(7) = 0


        ch = CheckSum(Frame, 2, 6)
        Frame(8) = ch Mod 256
        Frame(9) = ch \ 256

        MyTransport.Write(Frame, 0, 10)

        Dim t As Integer
        RaiseIdle()
        System.Threading.Thread.Sleep(300)
        t = 0
        While MyTransport.BytesToRead = 0 And t < 20
            RaiseIdle()
            System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
            t = t + 1
        End While

        Dim b(4096) As Byte
        Dim cnt As Integer
        Dim d As DateTime
        cnt = MyTransport.BytesToRead
        If cnt > 0 Then
            Dim ptr As Integer
            Dim sz As Integer
            ptr = 0
            sz = 0
            While cnt > 0
                MyTransport.Read(b, ptr, cnt)
                ptr += cnt
                sz += cnt


                If VerifySumm(b, 0, sz) Then
                    If (b(1) = &H83 Or b(1) = &H90) Then
                        IsError = True
                        ErrorMessage = "Ошибка запроса код:" & b(2)
                        Return Date.Now
                    End If
                    If b(2) >= 12 Then

                        d = New DateTime(2000 + b(4 + 5), b(4 + 4), b(4 + 3), b(4 + 6), 0, 0)
                        Return d
                    Else
                        Return DateTime.Now
                    End If

                End If

                RaiseIdle()
                System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
                cnt = MyTransport.BytesToRead
            End While


        End If
        IsError = True
        ErrorMessage = "Ошибка получения данных"
        Return Date.Now
    End Function
    Private OldVersion As Boolean = False
    Private Function GetDeviceDate() As Date
        EraseInputQueue()

        Dim Frame(10) As Byte
        Dim ch As UInt16
        Frame(0) = &HFF
        Frame(1) = &HFF
        Frame(2) = &H0
        Frame(3) = &H3
        Frame(4) = &H3F
        Frame(5) = &HFB
        ch = CheckSum(Frame, 2, 4)
        Frame(6) = ch Mod 256
        Frame(7) = ch \ 256

        MyTransport.Write(Frame, 0, 8)

        Dim t As Integer
        RaiseIdle()
        System.Threading.Thread.Sleep(300)
        t = 0
        While MyTransport.BytesToRead = 0 And t < 20
            RaiseIdle()
            System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
            t = t + 1
        End While

        Dim b(4096) As Byte
        Dim cnt As Integer
        Dim d As DateTime
        cnt = MyTransport.BytesToRead
        If cnt > 0 Then
            Dim ptr As Integer
            Dim sz As Integer
            ptr = 0
            sz = 0
            While cnt > 0
                MyTransport.Read(b, ptr, cnt)
                ptr += cnt
                sz += cnt


                If VerifySumm(b, 0, sz) Then
                    If (b(1) = &H83 Or b(1) = &H90) Then
                        IsError = True
                        ErrorMessage = "Ошибка запроса код:" & b(2)
                        Return Date.Now
                    End If
                    If b(2) >= 4 Then

                        d = New DateTime(2000 + b(5), b(4), b(3), b(6), 0, 0)
                        Return d
                    ElseIf b(2) >= 3 Then

                        d = New DateTime(2000 + b(5), b(4), b(3), 0, 0, 0)
                        Return d
                    Else 'If b(2) = 0 Then
                        OldVersion = True
                        Return GetDeviceDate2()
                    End If

                End If

                RaiseIdle()
                System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
                cnt = MyTransport.BytesToRead
            End While


        End If
        IsError = True
        ErrorMessage = "Ошибка получения данных"
        Return Date.Now

    End Function


    Private Function SetArchType(ByVal Atype As VKT7ArchType) As Boolean
        IsError = False
        ErrorMessage = ""
        EraseInputQueue()
        Dim Frame(12) As Byte
        Dim ch As UInt16
        Frame(0) = &HFF
        Frame(1) = &HFF
        Frame(2) = &H0
        Frame(3) = &H10
        Frame(4) = &H3F
        Frame(5) = &HFD
        Frame(6) = &H0
        Frame(7) = &H0
        Frame(8) = &H2
        Frame(9) = Atype
        Frame(10) = &H0
        ch = CheckSum(Frame, 2, 9)
        Frame(11) = ch Mod 256
        Frame(12) = ch \ 256

        MyTransport.Write(Frame, 0, 13)

        Dim t As Integer
        RaiseIdle()
        System.Threading.Thread.Sleep(300)
        t = 0
        While MyTransport.BytesToRead = 0 And t < 20
            RaiseIdle()
            System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
            t = t + 1
        End While

        Dim b(4096) As Byte
        Dim cnt As Integer
        cnt = MyTransport.BytesToRead
        If cnt > 0 Then
            Dim ptr As Integer
            Dim sz As Integer
            ptr = 0
            sz = 0
            While cnt > 0
                MyTransport.Read(b, ptr, cnt)
                ptr += cnt
                sz += cnt


                If VerifySumm(b, 0, sz) Then
                    If (b(1) = &H83 Or b(1) = &H90) Then
                        IsError = True
                        ErrorMessage = "Ошибка запроса код:" & b(2)
                        Return False
                    End If
                    Return True
                End If

                RaiseIdle()
                System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
                cnt = MyTransport.BytesToRead
            End While


        End If
        IsError = True
        ErrorMessage = "Ошибка получения данных"
        Return False
    End Function

    Public Enum VKT7ArchType
        AT_Hour = 0 '-часовой архив;
        AT_Day = 1  '-суточный архив;
        AT_Month = 2 '-месячный архив;
        AT_Itog = 3 '-итоговый архив;
        AT_Current = 4 '-текущие значения;
        AT_CurItog = 5 '-итоговые текущие;
        AT_Properties = 6 '-свойства.
    End Enum

    Private Sub SetArchDate(ByVal Dat As Date)
        IsError = False
        ErrorMessage = ""
        EraseInputQueue()
        Dim Frame(20) As Byte
        Dim ch As UInt16
        Frame(0) = &HFF
        Frame(1) = &HFF
        Frame(2) = &H0
        Frame(3) = &H10
        Frame(4) = &H3F
        Frame(5) = &HFB
        Frame(6) = &H0
        Frame(7) = &H0
        Frame(8) = &H4
        Frame(9) = Dat.Day
        Frame(10) = Dat.Month
        Frame(11) = (Dat.Year - 2000)
        Frame(12) = Dat.Hour
        ch = CheckSum(Frame, 2, 11)
        Frame(13) = ch Mod 256
        Frame(14) = ch \ 256

        MyTransport.Write(Frame, 0, 15)

        Dim t As Integer
        RaiseIdle()
        System.Threading.Thread.Sleep(300)
        t = 0
        While MyTransport.BytesToRead = 0 And t < 20
            RaiseIdle()
            System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
            t = t + 1
        End While

        Dim b(4096) As Byte
        Dim cnt As Integer
        cnt = MyTransport.BytesToRead
        If cnt > 0 Then
            Dim ptr As Integer
            Dim sz As Integer
            ptr = 0
            sz = 0
            While cnt > 0
                MyTransport.Read(b, ptr, cnt)
                ptr += cnt
                sz += cnt


                If VerifySumm(b, 0, sz) Then
                    If (b(1) = &H83 Or b(1) = &H90) Then
                        IsError = True
                        ErrorMessage = "Ошибка запроса код:" & b(2)
                        Return
                    End If
                    Return
                End If

                RaiseIdle()
                System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
                cnt = MyTransport.BytesToRead
            End While


        End If
        IsError = True
        ErrorMessage = "Ошибка получения данных"
    End Sub

    Private Sub GetList()
        IsError = False
        ErrorMessage = ""
        EraseInputQueue()
        Dim Frame(10) As Byte
        Dim ch As UInt16
        Frame(0) = &HFF
        Frame(1) = &HFF
        Frame(2) = &H0
        Frame(3) = &H3
        Frame(4) = &H3F
        Frame(5) = &HFC
        Frame(6) = &H0
        Frame(7) = &H0
        ch = CheckSum(Frame, 2, 6)
        Frame(8) = ch Mod 256
        Frame(9) = ch \ 256

        MyTransport.Write(Frame, 0, 10)

        Dim t As Integer
        RaiseIdle()
        System.Threading.Thread.Sleep(300)
        t = 0
        While MyTransport.BytesToRead = 0 And t < 20
            RaiseIdle()
            System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
            t = t + 1
        End While

        Dim b(4096) As Byte
        Dim cnt As Integer
        cnt = MyTransport.BytesToRead
        If cnt > 0 Then
            Dim ptr As Integer
            Dim sz As Integer
            ptr = 0
            sz = 0
            While cnt > 0
                MyTransport.Read(b, ptr, cnt)
                ptr += cnt
                sz += cnt

                Dim i As Integer
                If VerifySumm(b, 0, sz) Then
                    Dim sout As String = ""
                    Dim cout As String = ""
                    If (b(1) = &H83 Or b(1) = &H90) Then
                        IsError = True
                        ErrorMessage = "Ошибка запроса код:" & b(2)
                        Return
                    End If


                    ActiveCount = 0
                    For i = 0 To 100
                        ElemSize(i) = 0
                    Next
                    For i = 3 To cnt - 5 Step 6
                        ActiveElements(ActiveCount) = b(i)
                        ElemSize(b(i)) = b(i + 4)
                        ActiveCount += 1
                    Next
                    Return

                End If

                RaiseIdle()
                System.Threading.Thread.Sleep(1 + CInt(1000 * 8 * 2 / MyTransport.SetupData.BaudRate))
                cnt = MyTransport.BytesToRead
            End While


        End If
        IsError = True
        ErrorMessage = "Ошибка получения данных"

    End Sub

    Private Function VerifyElement(ByVal EType As VKT7ElemType) As Boolean
        Dim i As Integer

        For i = 0 To ActiveCount - 1
            If ActiveElements(i) = EType Then
                Return True
            End If
        Next
        If EType >= 44 And EType <= 80 Then
            Return True
        End If
        Return False

    End Function


    

End Class
