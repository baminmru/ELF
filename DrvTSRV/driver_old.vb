﻿
Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports TVMain
Imports System.IO
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

    Public m1 As Single
    Public m2 As Single
    Public m3 As Single

    Public v1 As Single
    Public v2 As Single
    Public v3 As Single

    Public dt12 As Single
    Public dt45 As Single

    Public tx1 As Single
    Public tx2 As Single

    Public tair1 As Single
    Public tair2 As Single

    Public SP As Long
    Public SPtv1 As Long
    Public SPtv2 As Long

    Public dQ1 As Single
    Public dQ2 As Single


    Public archType As Short
End Structure

Public Structure Archive
    Public DateArch As DateTime

    Public oktime As Long
    Public Errtime As Long
    Public ErrtimeH As Long
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

    Public SP As Long
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
    Public Errtime As Long
    Public oktime As Long

    Public archType As Short
End Structure


'Смещение	Размер поля (в байтах)	Название	Тип значения	Диапазон	Единицы измерения	Примечание
'0х00	1	День	Беззнаковое целое	1 – 31	-	-
'0х01	1	Месяц	Беззнаковое целое	1 – 12	-	-
'0х02	1	Год	Беззнаковое целое	0 – 99	-	-
'0х03	1	Час	Беззнаковое целое	0 – 23	час	-
'0х04	4	Тепло по 1 теплосистеме	32-битный IEEE-754 формат	0 – 999999999	МДж	Накопительный счетчик
'0х08	4	Тепло по 2 теплосистеме	32-битный IEEE-754 формат	0 – 999999999	МДж	Накопительный счетчик
'0х0С	4	Общий расход по 1 трубопроводу	32-битный IEEE-754 формат	0 – 999999	В установленных единицах (т, м3)	Накопительный счетчик
'0х10	4	Общий расход по 2 трубопроводу	32-битный IEEE-754 формат	0 – 999999	В установленных единицах (т, м3)	Накопительный счетчик
'0х14	4	Общий расход по 3 трубопроводу	32-битный IEEE-754 формат	0 – 999999	В установленных единицах (т, м3)	Накопительный счетчик
'0х18	4	Общий расход по 4 трубопроводу	32-битный IEEE-754 формат	0 – 999999	В установленных единицах (т, м3)	Накопительный счетчик
'0х1С	2	Температура по 1 трубопроводу	Беззнаковое целое	0 – 25000	10-2 ºС	Среднее значение за 1 час
'0х1E	2	Температура по 3 трубопроводу	Беззнаковое целое	0 – 25000	10-2 ºС	Среднее значение за 1 час
'0х20	2	Температура по 2 трубопроводу	Беззнаковое целое	0 – 25000	10-2 ºС	Среднее значение за 1 час
'0х22	2	Температура по 4 трубопроводу	Беззнаковое целое	0 – 25000	10-2 ºС	Среднее значение за 1 час
'0х24	2	Слово состояния	Беззнаковое целое	0 – 65535	-	Смотри таблицу 4
'0х26	4	Аварийное время	Беззнаковое целое	0 – 999999999	мин	Накопительный счетчик

Public Structure HArch
    Public day As Byte
    Public month As Byte
    Public year As Byte
    Public hour As Byte
    Public Q1 As Single
    Public Q2 As Single
    Public V1 As Single
    Public V2 As Single
    Public V3 As Single
    Public V4 As Single
    Public T1 As UInteger
    Public T2 As UInteger
    Public T3 As UInteger
    Public T4 As UInteger
    Public Status As UInteger
    Public CrashTime As UInteger
    Public P1 As Single
    Public P2 As Single
    Public P3 As Single
    Public P4 As Single
    Public OKTime As UInteger
    Public OK As Boolean
    Public V1h As Single
    Public V2h As Single
    Public V3h As Single
    Public V4h As Single
    Public Q1H As Single
    Public Q2H As Single

End Structure


Public Structure DArch
    Public day As Byte
    Public month As Byte
    Public year As Byte
    Public hour As Byte
    Public Q1 As Single
    Public Q2 As Single
    Public V1 As Single
    Public V2 As Single
    Public V3 As Single
    Public V4 As Single
    Public T1 As UInteger
    Public T2 As UInteger
    Public T3 As UInteger
    Public T4 As UInteger
    Public CrashTime As UInteger
    Public P1 As Single
    Public P2 As Single
    Public P3 As Single
    Public P4 As Single
    Public OKTime As UInteger
    Public OK As Boolean
    Public V1h As Single
    Public V2h As Single
    Public V3h As Single
    Public V4h As Single
    Public Q1H As Single
    Public Q2H As Single
End Structure

Public Class DataPass
    Public passdata(100) As Byte
    Public bDup As Boolean
    Public Cnt As Int16
    Public Size As Long

    Function GetHash() As String
        ' Create a new instance of the MD5 object.
        Dim md5Hasher As MD5 = MD5.Create()

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hasher.ComputeHash(passdata)

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function


    ' Verify a hash against a string.
    Function VerifyHash(ByVal hash As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = GetHash()

        ' Create a StringComparer an comare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function

End Class

Public Class driver
    Inherits TVMain.TVDriver


    Public Const c_lng256 As Long = 256&
    Private mIsConnected As Boolean

    'Private MyManager As LATIR2.Manager
    Private isTCP As Boolean
    Private SleepTime As Long





    Dim tArch As TArchive
    Dim IsTArchToRead As Boolean = False
    ' Dim WithEvents tim As System.Timers.Timer

    Dim tv As Short

    Dim archType_hour = 3
    Dim archType_day = 4


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

    Dim m_sleepInterval As Int32

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



    'Public inputbuffer(69) As Byte

    Public Overrides Function CounterName() As String
        Return "МТТСР"
    End Function







    Private Function ChSum(ByVal buf() As Byte, ByVal sz As Long) As Long

        Return Crc16(buf, 0, sz)
    End Function

    Function Crc16(ByVal buf() As Byte, ByVal Start As Long, ByVal Size As Long) As Long
        Dim i As Long
        Dim fcs As Long
        Dim sh As Integer
        Dim up As Integer



        ' The initial FCS value
        fcs = &HFFFF&
        up = 1

        ' evaluate the FCS
        For i = Start To Start + Size - 1
            If up Then
                fcs = fcs Xor (buf(i) << 8)
            Else
                fcs = fcs Xor buf(i)
            End If
            up = 1 - up

            sh = 8
            While sh > 0
                If ((fcs And &H1) = &H1) And sh > 0 Then
                    fcs = fcs >> 1
                    fcs = fcs Xor &HA001
                    sh -= 1
                Else
                    fcs = fcs >> 1
                    sh -= 1
                End If
            End While




        Next i

        ' return the result
        Crc16 = fcs
    End Function







    Public Function VerifySum(ByVal buf() As Byte, ByVal sz As Int16) As Boolean
        Dim crc As Long
        crc = ChSum(buf, sz - 2)
        If (buf(sz - 2) = (crc And &HFF)) And (buf(sz - 1) = ((crc And &HFF00) >> 8)) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function Bytes2Single(ByVal hexValue() As Byte, ByVal index As Int16, ByVal Revers As Boolean) As Single

        Try

            Dim i As Integer = 0
            Dim bArray(0 To 3) As Byte

            For i = 0 To 3
                bArray(i) = hexValue(index + i)
            Next
            If Revers Then
                Array.Reverse(bArray)
            End If

            Return BitConverter.ToSingle(bArray, 0)

        Catch ex As Exception
            Return 0.0
        End Try
    End Function

    Private Function GetFlt(ByVal SI() As Byte, ByVal Pos As Integer) As Single
        Dim l As Single
        l = Bytes2Single(SI, Pos, True)
        Return l
    End Function
    Private Function GetLng(ByVal SI() As Byte, ByVal Pos As Integer) As Long

        Dim h As ULong
        h = 0
        Dim b1 As Integer, b2 As Integer, b3 As Integer, b0 As Integer
        Try
            b0 = SI(Pos)
            b1 = SI(Pos + 1)
            b2 = SI(Pos + 2)
            b3 = SI(Pos + 3)
            h = (b0 << 24) + (b1 << 16) + (b2 << 8) + b3
        Catch ex As Exception

            h = 0
        End Try
        Return h
    End Function
    Private Function GetInt(ByVal SI() As Byte, ByVal Pos As Integer) As Integer
        Dim h As Integer
        Dim b1 As Integer, b0 As Integer
        b0 = SI(Pos)
        b1 = SI(Pos + 1)
        h = (b0 << 8) + b1
        Return h
    End Function

    Public Overrides Function Connect() As Boolean
        SleepTime = 700
        EraseInputQueue()
        mIsConnected = False

        Dim buf(1000) As Byte

        buf(0) = 1
        buf(1) = &H11
        Dim crc As Long

        crc = Crc16(buf, 0, 2)
        buf(3) = (crc And &HFF00) >> 8
        buf(2) = crc And &HFF


        MyTransport.Write(buf, 0, 4)

        Dim i As Int16
        Dim j As Int16

        RaiseIdle()
        System.Threading.Thread.Sleep(10)


        Dim btr As Long
        Dim sz As Long = 0
        Dim bufStr As String = ""
        For i = 1 To 20

            RaiseIdle()
            System.Threading.Thread.Sleep(10)

            btr = MyTransport.BytesToRead
            If btr > 0 Then
                MyTransport.Read(buf, sz, btr)
                sz += btr

            End If


        Next
        If sz > 0 Then
            If VerifySum(buf, sz) Then

                For j = 0 To sz - 1
                    If buf(j) >= &H20 Then
                        bufStr = bufStr + " j=" + j.ToString + "->" + Chr(buf(j)) + " V=" + buf(j).ToString
                    Else
                        bufStr = bufStr + " j=" + j.ToString + "->V=" + buf(j).ToString
                    End If
                Next

                Debug.Print(bufStr)
                'VZLJOT
                If buf(3) = Asc("В") And buf(4) = Asc("з") And buf(5) = Asc("л") And buf(6) = Asc("ё") And buf(7) = Asc("т") And buf(8) = Asc(" ") And buf(9) = Asc("Т") And buf(10) = Asc("С") And buf(11) = Asc("Р") And buf(12) = Asc("В") Then
                    mIsConnected = True
                    'Dim d As Date
                    'd = GetDeviceDate()
                    'Debug.Print(d)
                    'RaiseIdle()
                    System.Threading.Thread.Sleep(2000)
                    'd = GetDeviceDate()
                    'Debug.Print(d)
                End If
            End If
        End If

        Return mIsConnected


    End Function




    Private Function EncodeError(ByVal e As Byte) As String
        Select Case e

            Case 1
                Return "ILLEGAL FUNCTION"
            Case 2
                Return "ILLEGAL DATA ADDRESS"
            Case 3
                Return "ILLEGAL DATA VALUE"
            Case 2
                Return "FAILURE IN ASSOCIATED DEVICE"
            Case 2
                Return "ACKNOWLEDGE"
            Case 2
                Return "BUSY, REJECTED MESSAGE"
            Case 2
                Return "NAK-NEGATIVE ACKNOWLEDGMENT"
            Case Else
                Return "UNKNOWN ERROR"
        End Select

    End Function



    Private m_readRAMByteCount As Short

    Private Function ReadArchHalf(ByVal ArchType As Short, ByVal ArchDate As DateTime, ByRef Arch As Archive) As Boolean
        Dim retsum As String
        Dim ok As Boolean
        Dim buf(1000) As Byte
        Dim HC As Integer


        Try


            cleararchive(Arch)
            EraseInputQueue()
            Dim dt2 As Date
            Dim devdate As Date
            devdate = GetDeviceDate()
            devdate = devdate.AddMinutes(-1)
            If ArchType = archType_hour Then
                dt2 = ArchDate

            End If
            If ArchType = archType_day Then
                dt2 = ArchDate
            End If

            If dt2 <= devdate Then
                Arch.archType = ArchType
                If ArchType = archType_hour Then


                    buf(0) = 1
                    buf(1) = 65

                    buf(2) = 0  ' часовой архив
                    buf(3) = 0
                    buf(4) = 0 ' 1 запись
                    buf(5) = 1
                    buf(6) = 1 ' по времени
                    buf(7) = dt2.Second
                    buf(8) = dt2.Minute
                    buf(9) = dt2.Hour
                    buf(10) = dt2.Day
                    buf(11) = dt2.Month
                    buf(12) = (dt2.Year Mod 100)
                    Dim crc As Long
                    crc = Crc16(buf, 0, 13)
                    buf(13) = crc And &HFF
                    buf(14) = (crc And &HFF00) >> 8



                    MyTransport.Write(buf, 0, 15)

                    Dim i As Int16

                    RaiseIdle()
                    System.Threading.Thread.Sleep(10)


                    Dim btr As Long
                    Dim sz As Long = 0
                    Dim bufStr As String = ""
                    For i = 1 To 20

                        RaiseIdle()
                        System.Threading.Thread.Sleep(10)

                        btr = MyTransport.BytesToRead
                        If btr > 0 Then
                            MyTransport.Read(buf, sz, btr)
                            sz += btr

                        End If


                    Next
                    If sz > 0 Then
                        If VerifySum(buf, sz) Then
                            If sz = 5 Then
                                ok = False
                                retsum = EncodeError(buf(2))
                            Else

                                With Arch
                                    .T1 = 0.01 * GetInt(buf, 3 + 28)
                                    .T2 = 0.01 * GetInt(buf, 3 + 30)
                                    .T3 = 0.01 * GetInt(buf, 3 + 32)
                                    .M1 = 0.001 * GetLng(buf, 3 + 16)
                                    .M2 = 0.001 * GetLng(buf, 3 + 20)
                                    .M3 = 0.001 * GetLng(buf, 3 + 24)
                                    .Q1 = 0.001 * GetLng(buf, 3 + 4)
                                    .Q2 = 0.001 * GetLng(buf, 3 + 8)
                                    '.Q3 = 0.001 * GetLng(buf, 3 + 12)
                                    .Errtime = GetLng(buf, 3 + 40) / 60
                                    .ErrtimeH = .Errtime / 60
                                    .oktime = GetLng(buf, 3 + 36) / 60
                                    .V1 = 0.001 * GetLng(buf, 3 + 16)
                                    .V2 = 0.001 * GetLng(buf, 3 + 20)
                                    .V3 = 0.001 * GetLng(buf, 3 + 24)

                                    HC = 0
                                    If buf(3 + 44) <> 0 Then
                                        HC = HC + 1
                                    End If
                                    If buf(3 + 45) <> 0 Then
                                        HC = HC + 2
                                    End If
                                    If buf(3 + 46) <> 0 Then
                                        HC = HC + 4
                                    End If
                                    If buf(3 + 47) <> 0 Then
                                        HC = HC + 8
                                    End If
                                    If buf(3 + 48) <> 0 Then
                                        HC = HC + 16
                                    End If
                                    If buf(3 + 49) <> 0 Then
                                        HC = HC + 32
                                    End If
                                    If buf(3 + 50) <> 0 Then
                                        HC = HC + 64
                                    End If
                                    If buf(3 + 51) <> 0 Then
                                        HC = HC + 128
                                    End If
                                    .HC = HC
                                End With
                                Arch.DateArch = dt2
                                ok = True
                            End If
                        End If
                    End If
                End If

                If ArchType = archType_day Then


                    buf(0) = 1
                    buf(1) = 65

                    buf(2) = 0  ' суточный архив
                    buf(3) = 1
                    buf(4) = 0 ' 1 запись
                    buf(5) = 1
                    buf(6) = 1 ' по времени
                    buf(7) = dt2.Second
                    buf(8) = dt2.Minute
                    buf(9) = dt2.Hour
                    buf(10) = dt2.Day
                    buf(11) = dt2.Month
                    buf(12) = (dt2.Year Mod 100)
                    Dim crc As Long
                    crc = Crc16(buf, 0, 13)
                    buf(13) = crc And &HFF
                    buf(14) = (crc And &HFF00) >> 8



                    MyTransport.Write(buf, 0, 15)

                    Dim i As Int16


                    RaiseIdle()
                    System.Threading.Thread.Sleep(10)


                    Dim btr As Long
                    Dim sz As Long = 0
                    Dim bufStr As String = ""
                    For i = 1 To 20

                        RaiseIdle()
                        System.Threading.Thread.Sleep(10)

                        btr = MyTransport.BytesToRead
                        If btr > 0 Then
                            MyTransport.Read(buf, sz, btr)
                            sz += btr

                        End If


                    Next
                    If sz > 0 Then
                        If VerifySum(buf, sz) Then
                            If sz = 5 Then
                                ok = False
                                retsum = EncodeError(buf(2))
                            Else

                                With Arch
                                    .T1 = 0.01 * GetInt(buf, 3 + 28)
                                    .T2 = 0.01 * GetInt(buf, 3 + 30)
                                    .T3 = 0.01 * GetInt(buf, 3 + 32)
                                    .M1 = 0.001 * GetLng(buf, 3 + 16)
                                    .M2 = 0.001 * GetLng(buf, 3 + 20)
                                    .M3 = 0.001 * GetLng(buf, 3 + 24)
                                    .Q1 = 0.001 * GetLng(buf, 3 + 4)
                                    .Q2 = 0.001 * GetLng(buf, 3 + 8)
                                    '.Q3 = 0.001 * GetLng(buf, 3 + 12)
                                    .Errtime = GetLng(buf, 3 + 40) / 60
                                    .ErrtimeH = .Errtime / 60
                                    .oktime = GetLng(buf, 3 + 36) / 60
                                    .V1 = 0.001 * GetLng(buf, 3 + 16)
                                    .V2 = 0.001 * GetLng(buf, 3 + 20)
                                    .V3 = 0.001 * GetLng(buf, 3 + 24)


                                    HC = 0
                                    If GetInt(buf, 3 + 44) <> 0 Then
                                        HC = HC + 1
                                    End If
                                    If GetInt(buf, 3 + 46) <> 0 Then
                                        HC = HC + 2
                                    End If
                                    If GetInt(buf, 3 + 48) <> 0 Then
                                        HC = HC + 4
                                    End If
                                    If GetInt(buf, 3 + 50) <> 0 Then
                                        HC = HC + 8
                                    End If
                                    If GetInt(buf, 3 + 52) <> 0 Then
                                        HC = HC + 16
                                    End If
                                    If GetInt(buf, 3 + 54) <> 0 Then
                                        HC = HC + 32
                                    End If
                                    If GetInt(buf, 3 + 56) <> 0 Then
                                        HC = HC + 64
                                    End If
                                    If GetInt(buf, 3 + 58) <> 0 Then
                                        HC = HC + 128
                                    End If
                                    .HC = HC
                                End With
                                ok = True
                                Arch.DateArch = dt2
                            End If
                        End If
                    End If


                End If
            End If



            Return ok
        Catch ex As System.Exception
            Return False
        End Try
    End Function


    Public Overrides Function ReadArch(ByVal ArchType As Short, ByVal ArchYear As Short, _
   ByVal ArchMonth As Short, ByVal ArchDay As Short, ByVal ArchHour As Short) As String

        Dim retsum As String
        Dim ok As Boolean = False
        Dim buf(1000) As Byte
        Try


            cleararchive(Arch)
            EraseInputQueue()
            Dim dt1 As Date, dt2 As Date
            Dim devdate As Date
            devdate = GetDeviceDate()
            devdate = devdate.AddMinutes(-1)
            If ArchType = archType_hour Then
                dt2 = New Date(ArchYear, ArchMonth, ArchDay, ArchHour, 0, 0)
                dt2 = dt2.AddHours(-1)
                dt1 = dt2.AddHours(-1)

            End If
            If ArchType = archType_day Then
                dt2 = New Date(ArchYear, ArchMonth, ArchDay, 0, 0, 0)
                dt2 = dt2.AddDays(-1)
                dt1 = dt2.AddDays(-1)
            End If


            If dt2 <= devdate Then
                Arch.archType = ArchType

                Dim Arch1 As Archive
                Dim Arch2 As Archive

                Arch2 = New Archive
                ok = ReadArchHalf(ArchType, dt2, Arch2)

                If ok Then
                    Arch1 = New Archive
                    ok = ReadArchHalf(ArchType, dt1, Arch1)
                End If

                If ok Then
                    With Arch
                        .T1 = Arch2.T1
                        .T2 = Arch2.T2
                        .T3 = Arch2.T3
                        .M1 = Arch2.M1 - Arch1.M1
                        .M2 = Arch2.M2 - Arch1.M2
                        .M3 = Arch2.M3 - Arch1.M3
                        .Q1 = Arch2.Q1 - Arch1.Q1
                        .Q2 = Arch2.Q2 - Arch1.Q2
                        '.Q3 = 0.001 * GetLng(buf, 3 + 12)
                        .Errtime = Arch2.Errtime - Arch1.Errtime
                        .ErrtimeH = Arch2.Errtime
                        .oktime = GetLng(buf, 3 + 36) / 60
                        .V1 = Arch2.V1 - Arch1.V1
                        .V2 = Arch2.V2 - Arch1.V2
                        .V3 = Arch2.V3 - Arch1.V3
                        .HC = Arch2.HC
                    End With

                    If ArchType = archType_hour Then
                        dt2 = New Date(ArchYear, ArchMonth, ArchDay, ArchHour, 0, 0)

                    End If
                    If ArchType = archType_day Then
                        dt2 = New Date(ArchYear, ArchMonth, ArchDay, 0, 0, 0)

                    End If
                    Arch.DateArch = dt2
                End If
            End If


            If ok Then
                retsum = "Архив прочитан"
                retsum = retsum & vbCrLf
                EraseInputQueue()
                isArchToDBWrite = True
            Else
                retsum = "Ошибка: не удалось получить архив"
                retsum = retsum & vbCrLf
                EraseInputQueue()
                isArchToDBWrite = False
            End If

            Return retsum
        Catch ex As System.Exception
            Return "Ошибка:" & ex.Message
        End Try
    End Function

    Public Function DeCodeHCNumber(ByVal CodeHC As Long) As String

        DeCodeHCNumber = ""
        'CodeHC = CodeHC And ( 2 ^ 5 + 2 ^ 4 + 2 ^ 3 + 2 ^ 2 + 2 ^ 1 + 2 ^ 0)
        If CodeHC And 2 ^ 0 Then
            DeCodeHCNumber = "HC1" & ";"

        End If

        If CodeHC And 2 ^ 1 Then
            DeCodeHCNumber = DeCodeHCNumber + "HC2" & ";"
        End If

        If CodeHC And 2 ^ 2 Then
            DeCodeHCNumber = DeCodeHCNumber + "HC3" + ";"
        End If
        If CodeHC And 2 ^ 3 Then
            DeCodeHCNumber = DeCodeHCNumber + "HC4" + ";"
        End If
        If CodeHC And 2 ^ 4 Then
            DeCodeHCNumber = DeCodeHCNumber + "HC5" + ";"
        End If
        If CodeHC And 2 ^ 5 Then
            DeCodeHCNumber = DeCodeHCNumber + "ПР1" + ";"
        End If
        If CodeHC And 2 ^ 6 Then
            DeCodeHCNumber = DeCodeHCNumber + "ПР2" + ";"
        End If
        If CodeHC And 2 ^ 7 Then
            DeCodeHCNumber = DeCodeHCNumber + "ПР3" + ";"
        End If







    End Function
    Public Function DeCodeHCText(ByVal CodeHC As Long) As String
        DeCodeHCText = ""
        'CodeHC = CodeHC And ( 2 ^ 5 + 2 ^ 4 + 2 ^ 3 + 2 ^ 2 + 2 ^ 1 + 2 ^ 0)
        If CodeHC And 2 ^ 0 Then
            DeCodeHCText = "HC1" & ";"

        End If

        If CodeHC And 2 ^ 1 Then
            DeCodeHCText = DeCodeHCText + "HC2" & ";"
        End If

        If CodeHC And 2 ^ 2 Then
            DeCodeHCText = DeCodeHCText + "HC3" + ";"
        End If
        If CodeHC And 2 ^ 3 Then
            DeCodeHCText = DeCodeHCText + "HC4" + ";"
        End If
        If CodeHC And 2 ^ 4 Then
            DeCodeHCText = DeCodeHCText + "HC5" + ";"
        End If
        If CodeHC And 2 ^ 5 Then
            DeCodeHCText = DeCodeHCText + "ПР1" + ";"
        End If
        If CodeHC And 2 ^ 6 Then
            DeCodeHCText = DeCodeHCText + "ПР2" + ";"
        End If
        If CodeHC And 2 ^ 7 Then
            DeCodeHCText = DeCodeHCText + "ПР3" + ";"
        End If

    End Function
    Public Function DeCodeHC(ByVal CodeHC As Long) As String


        DeCodeHC = ""
        'CodeHC = CodeHC And ( 2 ^ 5 + 2 ^ 4 + 2 ^ 3 + 2 ^ 2 + 2 ^ 1 + 2 ^ 0)
        If CodeHC And 2 ^ 0 Then
            DeCodeHC = "HC1" & ";"

        End If

        If CodeHC And 2 ^ 1 Then
            DeCodeHC = DeCodeHC + "HC2" & ";"
        End If

        If CodeHC And 2 ^ 2 Then
            DeCodeHC = DeCodeHC + "HC3" + ";"
        End If
        If CodeHC And 2 ^ 3 Then
            DeCodeHC = DeCodeHC + "HC4" + ";"
        End If
        If CodeHC And 2 ^ 4 Then
            DeCodeHC = DeCodeHC + "HC5" + ";"
        End If
        If CodeHC And 2 ^ 5 Then
            DeCodeHC = DeCodeHC + "ПР1" + ";"
        End If
        If CodeHC And 2 ^ 6 Then
            DeCodeHC = DeCodeHC + "ПР2" + ";"
        End If
        If CodeHC And 2 ^ 7 Then
            DeCodeHC = DeCodeHC + "ПР3" + ";"
        End If
    End Function

    Public Function Bytes2Float(ByVal fbytes() As Byte) As Single
        If UBound(fbytes) < 3 Then
            Return 0
        End If
        Return System.BitConverter.ToSingle(fbytes, 0)
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







    Private Sub Flip4(ByRef b() As Byte, ByVal index As Int16)
        Dim t(4) As Byte
        Dim i As Int16
        For i = 0 To 3
            t(i) = b(index + i)
        Next
        For i = 0 To 3
            b(index + i) = t(3 - i)
        Next
    End Sub

    Private Sub Flip2(ByRef b() As Byte, ByVal index As Int16)
        Dim t(2) As Byte
        Dim i As Int16
        For i = 0 To 1
            t(i) = b(index + i)
        Next
        For i = 0 To 1
            b(index + i) = t(1 - i)
        Next
    End Sub
    Public Overrides Function WriteArchToDB() As String

        If Arch.archType <> 4 Then
            Arch.DateArch = Arch.DateArch.AddSeconds(1)
        End If

        WriteArchToDB = "INSERT INTO " + TableForArch(Arch.archType) + "(" + TableForArch(Arch.archType) + "id,instanceid,DCALL,DCOUNTER,t1,t2,t3,t4,t5,t6,tce1,tce2,tair1,tair2,p1,p2,p3,p4,v1,v2,v3,v4,v5,v6,m1,m2,m3,m4,m5,m6,dm12,V1H,V2H,V5H,V4H,q1h,q2h,sp_TB1,sp_TB2,q1,q2,q4,q5,TSUM1,TSUM2,hc_code,hc,errtime, errtimeh,worktime) values ("
        WriteArchToDB = WriteArchToDB + "" + GUID2String(MyManager.Session, Guid.NewGuid) + ","
        WriteArchToDB = WriteArchToDB + "" + guid2string(mymanager.session, DeviceID) + ","
        WriteArchToDB = WriteArchToDB + "" + MyManager.Session.GetProvider.GetServerDate() + "" + ","
        WriteArchToDB = WriteArchToDB + MyManager.Session.GetProvider.Date2Const(Arch.DateArch) + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.T1, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.T2, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.T5, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.T3, "##############0.000").Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Format(Arch.T4, "##############0.000").Replace(",", ".") + ","
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


        If DeCodeHCNumber(Arch.HC) = "0000000000000000" Then
            WriteArchToDB = WriteArchToDB + "'','Нет HC'"
        Else
            WriteArchToDB = WriteArchToDB + "'" + S180(DeCodeHCNumber(Arch.HC)) + "','" + S180(DeCodeHCText(Arch.HC)) + "'"
        End If
        WriteArchToDB = WriteArchToDB + "," + Format(Arch.Errtime, "##############0").Replace(",", ".")

        WriteArchToDB = WriteArchToDB + "," + Format(Arch.ErrtimeH, "##############0").Replace(",", ".")
        WriteArchToDB = WriteArchToDB + "," + Format(Arch.oktime, "##############0.000").Replace(",", ".")

        WriteArchToDB = WriteArchToDB + ")"
        Debug.Print(WriteArchToDB)
    End Function


    Public Overrides Function WriteMArchToDB() As String
        WriteMArchToDB = ""
        Try
            WriteMArchToDB = "INSERT INTO " + TableForArch(1) + "(" + TableForArch(1) + "id,instanceid,DCALL,DCOUNTER,t1,t2,t3,t4,t5,t6,v1,v2,v3,M1,M2,M3,g1,G2,g3,dt12,dt45,sp_TB1,sp_TB2,tce1,tce2,tair1,tair2,hc_code,hc,hc_1,hc_2) values ("
            WriteMArchToDB = WriteMArchToDB + "" + GUID2String(MyManager.Session, Guid.NewGuid) + ","
            WriteMArchToDB = WriteMArchToDB + "" + guid2string(mymanager.session, DeviceID) + ","
            WriteMArchToDB = WriteMArchToDB + "" + MyManager.Session.GetProvider.GetServerDate() + "" + ","
            WriteMArchToDB = WriteMArchToDB + MyManager.Session.GetProvider.Date2Const(mArch.DateArch) + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.t1, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.t2, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.t3, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.t4, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.t5, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.t6, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.v1, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.v2, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.v3, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.m1, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.m2, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.m3, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.G1, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.G2, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.G3, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.dt12, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.dt45, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.SPtv1.ToString + ","
            WriteMArchToDB = WriteMArchToDB + mArch.SPtv2.ToString + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.tx1, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.tx2, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.tair1, "##############0.000").Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + Format(mArch.tair2, "##############0.000").Replace(",", ".") + ","



            If DeCodeHCNumber(mArch.HC) = "0000000000000000" Then
                WriteMArchToDB = WriteMArchToDB + "'-','Нет HC',"
                WriteMArchToDB = WriteMArchToDB + "'Нет HC',"
                WriteMArchToDB = WriteMArchToDB + "'Нет HC'"
            Else
                WriteMArchToDB = WriteMArchToDB + "'" + DeCodeHCNumber(mArch.HC) + "','" + S180(DeCodeHCText(mArch.HC)) + "',"

                WriteMArchToDB = WriteMArchToDB + "'" + S180(DeCodeHCText(mArch.HC)) + "',"
                WriteMArchToDB = WriteMArchToDB + "'" + S180(DeCodeHCText(mArch.HC)) + "'"
            End If


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

        arc.SP = 0
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

        marc.SP = 0
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


    Private Function ReadFloat(ByVal addr As ULong) As Single
        Dim buf(30) As Byte
        Dim res As Single = 0.0
        Try
            buf(0) = 1
            buf(1) = &H3

            buf(2) = (addr And &HFF00) >> 8
            buf(3) = addr And &HFF
            buf(4) = &H0
            buf(5) = &H2

            Dim crc As Long
            crc = Crc16(buf, 0, 6)
            buf(7) = (crc And &HFF00) >> 8
            buf(6) = crc And &HFF


            MyTransport.Write(buf, 0, 8)

            Dim i As Int16
            RaiseIdle()
            System.Threading.Thread.Sleep(10)



            Dim btr As Long
            Dim sz As Long = 0
            For i = 1 To 20
                RaiseIdle()
                System.Threading.Thread.Sleep(10)

                btr = MyTransport.BytesToRead
                If btr > 0 Then
                    MyTransport.Read(buf, sz, btr)
                    sz += btr

                End If


            Next
            If sz > 0 Then
                If VerifySum(buf, sz) Then
                    If sz = 5 Then
                        Dim es As String
                        es = EncodeError(buf(2))
                        Debug.Print(es)
                    Else
                        res = GetFlt(buf, 3)
                    End If


                End If
            End If
        Catch
        End Try
        Return res

    End Function

    Private Function ReadLong(ByVal addr As ULong) As Long
        Dim buf(30) As Byte
        Dim res As Long = 0
        Try
            buf(0) = 1
            buf(1) = &H3

            buf(2) = (addr And &HFF00) >> 8
            buf(3) = addr And &HFF
            buf(4) = &H0
            buf(5) = &H2

            Dim crc As Long
            crc = Crc16(buf, 0, 6)
            buf(7) = (crc And &HFF00) >> 8
            buf(6) = crc And &HFF


            MyTransport.Write(buf, 0, 8)

            Dim i As Int16
            RaiseIdle()
            System.Threading.Thread.Sleep(10)



            Dim btr As Long
            Dim sz As Long = 0
            For i = 1 To 20
                RaiseIdle()
                System.Threading.Thread.Sleep(10)

                btr = MyTransport.BytesToRead
                If btr > 0 Then
                    MyTransport.Read(buf, sz, btr)
                    sz += btr

                End If


            Next
            If sz > 0 Then
                If VerifySum(buf, sz) Then
                    If sz = 5 Then
                        Dim es As String
                        es = EncodeError(buf(2))
                        Debug.Print(es)
                    Else
                        res = GetLng(buf, 3)
                    End If



                End If
            End If
        Catch
        End Try
        Return res

    End Function

    Private Function ReadInt(ByVal addr As ULong) As Int16
        Dim buf(30) As Byte
        Dim res As Int16 = 0
        Try
            buf(0) = 1
            buf(1) = &H3

            buf(2) = (addr And &HFF00) >> 8
            buf(3) = addr And &HFF
            buf(4) = &H0
            buf(5) = &H1

            Dim crc As Long
            crc = Crc16(buf, 0, 6)
            buf(7) = (crc And &HFF00) >> 8
            buf(6) = crc And &HFF


            MyTransport.Write(buf, 0, 8)

            Dim i As Int16
            RaiseIdle()
            System.Threading.Thread.Sleep(10)



            Dim btr As Long
            Dim sz As Long = 0
            For i = 1 To 20
                RaiseIdle()
                System.Threading.Thread.Sleep(10)

                btr = MyTransport.BytesToRead
                If btr > 0 Then
                    MyTransport.Read(buf, sz, btr)
                    sz += btr

                End If


            Next
            If sz > 0 Then
                If VerifySum(buf, sz) Then
                    If sz = 5 Then
                        Dim es As String
                        es = EncodeError(buf(2))
                        Debug.Print(es)
                    Else
                        res = GetInt(buf, 3)
                    End If


                End If
            End If
        Catch
        End Try
        Return res

    End Function


    Public Function GetDeviceDate() As Date

        Dim DateArch As Date
        Dim buf(1000) As Byte
        Dim Seconds As Long = 0
        Dim addr As Long
        Try

            addr = 32784
            buf(0) = 1
            buf(1) = &H3

            buf(2) = (addr And &HFF00) >> 8
            buf(3) = addr And &HFF
            buf(4) = &H0
            buf(5) = &H2

            Dim crc As Long
            crc = Crc16(buf, 0, 6)
            buf(7) = (crc And &HFF00) >> 8
            buf(6) = crc And &HFF


            MyTransport.Write(buf, 0, 8)

            Dim i As Int16
            RaiseIdle()
            System.Threading.Thread.Sleep(10)



            Dim btr As Long
            Dim sz As Long = 0
            For i = 1 To 20
                RaiseIdle()
                System.Threading.Thread.Sleep(10)

                btr = MyTransport.BytesToRead
                If btr > 0 Then
                    MyTransport.Read(buf, sz, btr)
                    sz += btr

                End If


            Next
            If sz > 0 Then
                If VerifySum(buf, sz) Then
                    Seconds = GetLng(buf, 3)
                    DateArch = New Date(1970, 1, 1, 0, 0, 0)
                    DateArch = DateArch.AddSeconds(Seconds)

                End If
            End If
        Catch
        End Try
        Return DateArch
    End Function

    Public Overrides Function ReadMArch() As String


        clearMarchive(mArch)
        EraseInputQueue()

        mArch.DateArch = GetDeviceDate()

        mArch.t1 = ReadFloat(49153UL - 1)
        mArch.t2 = ReadFloat(49155UL - 1)
        mArch.t3 = ReadFloat(49157UL - 1)

        mArch.t4 = ReadFloat(49223UL - 1)
        mArch.t5 = ReadFloat(49225UL - 1)
        mArch.t6 = ReadFloat(49227UL - 1)

        mArch.m1 = ReadFloat(49171UL - 1)
        mArch.m2 = ReadFloat(49173UL - 1)
        mArch.m3 = ReadFloat(49175UL - 1)

        mArch.v1 = ReadFloat(49177UL - 1)
        mArch.v2 = ReadFloat(49179UL - 1)
        mArch.v3 = ReadFloat(49181UL - 1)

        mArch.G1 = ReadFloat(49165UL - 1)
        mArch.G2 = ReadFloat(49167UL - 1)
        mArch.G3 = ReadFloat(49169UL - 1)


        mArch.HC = ReadInt(16385UL - 1)
        isMArchToDBWrite = True
        Return "Мгновенный архив прочитан"
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
        Dim bArr(0 To 8) As Byte
        Dim temptv As Short
        temptv = tv
        clearTarchive(tArch)
        EraseInputQueue()

        tArch.DateArch = GetDeviceDate()

        tArch.M1 = ReadLong(32775UL - 1)
        tArch.M2 = ReadLong(32777UL - 1)
        tArch.M3 = ReadLong(32779UL - 1)

        tArch.V1 = 0.001 * ReadLong(32781UL - 1)
        tArch.V2 = 0.001 * ReadLong(32785UL - 1)
        tArch.V3 = 0.001 * ReadLong(32787UL - 1)

        tArch.Q1 = ReadLong(32831UL - 1)
        tArch.Q2 = ReadLong(32833UL - 1)
        tArch.Q3 = ReadLong(32835UL - 1)
        tArch.Errtime = ReadLong(32789UL - 1) / 60
        tArch.oktime = ReadLong(32787UL - 1) / 60



        isTArchToDBWrite = True

        Return "Итоговый архив прочитан"
    End Function

    Public Overrides Function WriteTArchToDB() As String
        WriteTArchToDB = "INSERT INTO " + TableForArch(tArch.archType) + "( " + TableForArch(tArch.archType) + "id,instanceid,DCALL,DCOUNTER,Q1,Q2,Q3,Q1H,M1,M2,M3,M4,M5,M6,v1,v2,v3,v4,v5,v6,TSUM1,TSUM2,worktime,ERRTIME) values ("
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
        WriteTArchToDB = WriteTArchToDB + Format(tArch.oktime, "##############0").Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + Format(tArch.Errtime, "##############0").Replace(",", ".")
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
        SSS = "INSERT INTO " & TableForArch(1) & "( " & TableForArch(1) & "id,instanceid,DCALL,DCOUNTER,id_ptype,hc,hc_1,hc_2) values ("
        SSS = SSS + "" + GUID2String(MyManager.Session, Guid.NewGuid) + ","
        SSS = SSS + "" + guid2string(mymanager.session, DeviceID) + ","
        SSS = SSS + "" + MyManager.Session.GetProvider.GetServerDate() + "" + ","
        SSS = SSS + MyManager.Session.GetProvider.Date2Const(ErrDate) + ","
        SSS = SSS + "'" & S180(ErrMsg) & "',"
        SSS = SSS + "'" & S180(ErrMsg) & "',"
        SSS = SSS + "'" & S180(ErrMsg) & "')"
        Return SSS
    End Function
    Public Overrides Function IsConnected() As Boolean
        Return mIsConnected And MyTransport.IsConnected
    End Function
 


  

  

    Public Overrides Function ReadSystemParameters() As DataTable
        Dim dt As DataTable
        dt = New DataTable
        dt.Columns.Add("Название")
        dt.Columns.Add("Значение")

        'Dim dr As DataRow

        ''0x3E 0	SINGLE	Системные	DeltaT	Значение DeltaT
        'dr = dt.NewRow
        'dr("Название") = "Значение DeltaT"
        'dr("Значение") = ReadCommand(&H3E, 0)
        'dt.Rows.Add(dr)







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





End Class
