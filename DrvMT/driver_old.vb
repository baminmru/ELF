Imports TVMain
Imports System
Imports System.Security.Cryptography
Imports System.Text
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
End Structure

Public Class DataPass
    Public passdata(100) As Byte
    Public bDup As Boolean
    Public Cnt As Int16

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


    Private isTCP As Boolean
    Private SleepTime As Long
    Private MiniSleepTime As Long




    Private Sub FillHArch(ByRef buf() As Byte, ByRef h As HArch)
        Dim st As Integer
        st = 3
        h.day = buf(0 + st)
        h.month = buf(1 + st)
        h.year = buf(2 + st)
        h.hour = buf(3 + st)
        h.Q1 = BToSingle(buf, 4 + st) / 1000
        h.Q2 = BToSingle(buf, 8 + st) / 1000
        h.V1 = BToSingle(buf, 12 + st)
        h.V2 = BToSingle(buf, 16 + st)
        h.V3 = BToSingle(buf, 20 + st)
        h.V4 = BToSingle(buf, 24 + st)
        Flip2(buf, 28 + st)
        h.T1 = BitConverter.ToUInt16(buf, 28 + st)
        Flip2(buf, 30 + st)
        h.T2 = BitConverter.ToUInt16(buf, 30 + st)
        Flip2(buf, 32 + st)
        h.T3 = BitConverter.ToUInt16(buf, 32 + st)
        Flip2(buf, 34 + st)
        h.T4 = BitConverter.ToUInt16(buf, 34 + st)
        h.Status = BitConverter.ToUInt16(buf, 36 + st)
        Flip4(buf, 38 + st)
        h.CrashTime = BitConverter.ToUInt32(buf, 38 + st) / 60

    End Sub
    Private Sub FillHArchTCP(ByRef buf() As Byte, ByRef h As HArch)
        Dim st As Integer
        st = 3
        h.P1 = BitConverter.ToSingle(buf, 0 + st)
        h.P2 = BitConverter.ToSingle(buf, 4 + st)
        h.P3 = BitConverter.ToSingle(buf, 8 + st)
        h.P4 = BitConverter.ToSingle(buf, 12 + st)
    End Sub


    Private Sub FillDArch(ByRef buf() As Byte, ByRef h As DArch)
        Dim st As Int16
        st = 3
        h.day = buf(st + 0)
        h.month = buf(st + 1)
        h.year = buf(st + 2)
        h.hour = buf(st + 3)

        'Flip4(buf, 4)
        h.Q1 = BToSingle(buf, st + 4) / 1000
        h.Q2 = BToSingle(buf, st + 8) / 1000
        h.V1 = BToSingle(buf, st + 12)
        h.V2 = BToSingle(buf, st + 16)
        h.V3 = BToSingle(buf, st + 20)
        h.V4 = BToSingle(buf, st + 24)
        Flip2(buf, st + 28)
        h.T1 = BitConverter.ToUInt16(buf, st + 28)
        Flip2(buf, st + 30)
        h.T2 = BitConverter.ToUInt16(buf, st + 30)
        Flip2(buf, st + 32)
        h.T3 = BitConverter.ToUInt16(buf, st + 32)
        Flip2(buf, st + 34)
        h.T4 = BitConverter.ToUInt16(buf, st + 34)
        Flip4(buf, st + 36)
        h.CrashTime = BitConverter.ToUInt32(buf, st + 36)

    End Sub
    Private Sub FillDArchTCP(ByRef buf() As Byte, ByRef h As DArch)
        Dim st As Integer
        st = 3
        h.P1 = BToSingle(buf, 0 + st)
        h.P2 = BToSingle(buf, 4 + st)
        h.P3 = BToSingle(buf, 8 + st)
        h.P4 = BToSingle(buf, 12 + st)

    End Sub
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
    Public Overrides Property isMArchToDBWrite() As Boolean

        Get
            Return m_isMArchToDBWrite
        End Get
        Set(ByVal value As Boolean)
            m_isMArchToDBWrite = value
        End Set
    End Property


    'Public inputbuffer(69) As Byte

    Public Overrides Function CounterName() As String
        Return "МТТСР"
    End Function

    Private m_serverip As String

    
    Public Overrides Sub CloseTransportConnect()
        If Not MyTransport Is Nothing Then
            MyTransport.DisConnect()
            MyTransport = Nothing
        End If
    End Sub


    Private Function ChSum(ByVal buf() As Byte, ByVal sz As Long) As Byte
        Dim i As Long
        Dim bChSum As Byte = 0
        For i = 0 To sz - 1

            bChSum = bChSum Xor buf(i)
        Next i
        bChSum = (Not bChSum) + 1

        Return bChSum
    End Function

    'Private Function ReadVersion() As String
    '    Dim buf(1000) As Byte
    '    Dim j As Integer
    '    buf(0) = 4
    '    buf(1) = &H4F
    '    buf(2) = 0
    '    buf(3) = ChSum(buf, 3)

    '    MyTransport.Write(buf, 0, 4)

    '    Dim i As Int16

    '    RaiseIdle()
    '   System.Threading.Thread.Sleep(10)


    '    Dim btr As Long
    '    Dim sz As Long = 0
    '    Dim bufStr As String = ""
    '    For i = 1 To 20

    '        RaiseIdle()
    'System.Threading.Thread.Sleep(10)

    '        btr = MyTransport.BytesToRead
    '        If btr > 0 Then

    '            MyTransport.Read(buf, sz, btr)
    '            sz += btr
    '            'Me.Text = i.ToString
    '        End If
    '    Next
    '    If sz > 0 Then
    '        If buf(0) = 0 And buf(sz - 1) = 0 Then
    '            buf = System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(866), System.Text.Encoding.Default, buf, 1, sz - 2)
    '            For j = 0 To sz - 3
    '                bufStr = bufStr + Chr(buf(j))
    '            Next
    '            'txtOUT.Text = bufStr
    '        End If
    '    End If
    'End Function

    Private Sub ReadNumber()
        Dim buf(1000) As Byte
        Dim j As Integer
        buf(0) = 4
        buf(1) = &H50
        buf(2) = 0
        buf(3) = ChSum(buf, 3)

        MyTransport.Write(buf, 0, 4)
        'While MyTransport.Writ > 0
        '    Application.DoEvents()
        'End While
        Dim i As Int16
        'For i = 1 To 600
        'Application.DoEvents()
        RaiseIdle()
        System.Threading.Thread.Sleep(10)
        'Next


        Dim btr As Long
        Dim sz As Long = 0
        Dim bufStr As String = ""
        For i = 1 To 20
            'Application.DoEvents()
            RaiseIdle()
            System.Threading.Thread.Sleep(10)

            btr = MyTransport.BytesToRead
            If btr > 0 Then

                MyTransport.Read(buf, sz, btr)
                sz += btr
                'Me.Text = i.ToString
            End If
        Next
        If sz > 0 Then
            If buf(0) = 0 And buf(sz - 1) = 0 Then
                buf = System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(866), System.Text.Encoding.Default, buf, 1, sz - 2)
                For j = 0 To sz - 3
                    bufStr = bufStr + Chr(buf(j))
                Next
                'txtOUT.Text = txtOUT.Text & vbCrLf & bufStr
            End If
        End If
    End Sub

    Private Sub ReadDateTime()
        Dim buf(1000) As Byte
        Dim j As Integer
        buf(0) = 4
        buf(1) = &H42
        buf(2) = 0
        buf(3) = ChSum(buf, 3)

        MyTransport.Write(buf, 0, 4)
        'While MyTransport.Writ > 0
        '    Application.DoEvents()
        'End While
        Dim i As Int16
        'For i = 1 To 600

        RaiseIdle()
        System.Threading.Thread.Sleep(10)
        'Next


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
                'Me.Text = i.ToString
            End If
        Next
        If sz > 0 Then
            'If buf(0) = 0 And buf(sz - 1) = 0 Then
            buf = System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(866), System.Text.Encoding.Default, buf, 1, sz - 2)
            For j = 0 To sz - 3
                bufStr = bufStr + Chr(buf(j))
            Next
            'txtOUT.Text = txtOUT.Text & vbCrLf & bufStr
            'End If
        End If
        ReDim buf(0 To 1000)

        buf(0) = 4
        buf(1) = &H43
        buf(2) = 0
        buf(3) = ChSum(buf, 3)

        MyTransport.Write(buf, 0, 4)
        'While MyTransport.Writ > 0
        '    Application.DoEvents()
        'End While

        'For i = 1 To 600
        'Application.DoEvents()
        RaiseIdle()
        System.Threading.Thread.Sleep(10)
        'Next



        sz = 0
        bufStr = ""
        For i = 1 To 20
            'Application.DoEvents()
            RaiseIdle()
            System.Threading.Thread.Sleep(10)

            btr = MyTransport.BytesToRead
            If btr > 0 Then

                MyTransport.Read(buf, sz, btr)
                sz += btr
                'Me.Text = i.ToString
            End If
        Next
        If sz > 0 Then
            'If buf(0) = 0 And buf(sz - 1) = 0 Then
            buf = System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(866), System.Text.Encoding.Default, buf, 1, sz - 2)
            For j = 0 To sz - 3
                bufStr = bufStr + Chr(buf(j))
            Next
            'txtOUT.Text = txtOUT.Text & vbCrLf & bufStr
            'End If
        End If
    End Sub

    Public Overrides Function Connect() As Boolean
        SleepTime = 500 + (47 + 49) * 1000 * 10 / MyTransport.SetupData.BaudRate
        MiniSleepTime = 1 + 5 * 1000 * 10 / MyTransport.SetupData.BaudRate

        EraseInputQueue()

        Try

            Dim sret As String
            sret = ReadCommand(&H4F, 255) & ""
            If (sret.Length > 5) Then
                If (sret.Substring(0, 5) = "Error") Then
                    EraseInputQueue()
                    Return False
                End If
                If Left(sret, 9) = "ВЗЛЁТ ТСР" Then
                    mIsConnected = True
                    isTCP = True
                    Return True
                End If

                If sret.Substring(0, 7) = "MT200DS" Then
                    isTCP = False
                    mIsConnected = True
                    Return True
                End If

                If sret = "Not implemented" Then
                    sret = ReadCommand(&H46, 255)
                    If sret.Substring(0, 8) = "MT-200DS" Then
                        isTCP = False
                        mIsConnected = True
                        Return True
                    Else
                        Return False
                    End If
                End If


            End If

        Catch exc As Exception
            Return False
        End Try



    End Function

    Private m_readRAMByteCount As Short

    Public Overrides Function ReadArch(ByVal ArchType As Short, ByVal ArchYear As Short, _
    ByVal ArchMonth As Short, ByVal ArchDay As Short, ByVal ArchHour As Short) As String

        Dim retsum As String
        Try


            cleararchive(Arch)
            EraseInputQueue()
            Dim d1 As DArch, d2 As DArch
            Dim h1 As HArch, h2 As HArch
            Dim dt1 As Date, dt2 As Date
            Arch.archType = ArchType
            If ArchType = archType_hour Then
                dt2 = New Date(ArchYear, ArchMonth, ArchDay, ArchHour, 0, 0)
                dt1 = dt2.AddHours(-1)
                h1 = GetArchiv(dt1, False)
                h2 = GetArchiv(dt2, False)
                Arch.M1 = h2.V1 - h1.V1
                Arch.M2 = h2.V2 - h1.V2
                Arch.V1 = h2.V3 - h1.V3
                Arch.V2 = h2.V4 - h1.V4
                Arch.Q1 = h2.Q1 - h1.Q1
                Arch.Q2 = h2.Q2 - h1.Q2
                Arch.T1 = CDbl(h2.T1) / 100
                Arch.T2 = CDbl(h2.T2) / 100
                Arch.T3 = CDbl(h2.T3) / 100
                Arch.T4 = CDbl(h2.T4) / 100
                Arch.HC = h2.Status
                If isTCP Then
                    Arch.P1 = h2.P1
                    Arch.P2 = h2.P2
                    Arch.P3 = h2.P3
                    Arch.P4 = h2.P4
                End If
                Arch.DateArch = dt2
                Arch.Errtime = h2.CrashTime
            End If

            If ArchType = archType_day Then
                dt2 = New Date(ArchYear, ArchMonth, ArchDay, 0, 0, 0)
                dt1 = dt2.AddDays(-1)
                d1 = GetArchiv(dt1, True)
                d2 = GetArchiv(dt2, True)
                Arch.M1 = d2.V1 - d1.V1
                Arch.M2 = d2.V2 - d1.V2
                Arch.V1 = d2.V3 - d1.V3
                Arch.V2 = d2.V4 - d1.V4
                Arch.Q1 = d2.Q1 - d1.Q1
                Arch.Q2 = d2.Q2 - d1.Q2
                Arch.T1 = CDbl(d2.T1) / 100
                Arch.T2 = CDbl(d2.T2) / 100
                Arch.T3 = CDbl(d2.T3) / 100
                Arch.T4 = CDbl(d2.T4) / 100

                Arch.DateArch = dt2
                If isTCP Then
                    Arch.P1 = d2.P1
                    Arch.P2 = d2.P2
                    Arch.P3 = d2.P3
                    Arch.P4 = d2.P4
                End If
                Arch.Errtime = d2.CrashTime
            End If



            retsum = "Архив прочитан"
            retsum = retsum & vbCrLf
            retsum = retsum & vbCrLf
            EraseInputQueue()
            isArchToDBWrite = True
            Return retsum
        Catch ex As System.Exception
            Return "Ошибка:" & ex.Message
        End Try
    End Function
    Public Function ProcessRcvData(ByVal buf() As Byte, ByVal ret As Short) As String


        Return "Ошибка!Пакет не распознан"
    End Function
    Public Function GetAndProcessData() As String
        Dim buf(0 To 73) As Byte
        Dim i As Int16
        For i = 0 To 73
            buf(i) = 0
        Next

        Dim ret As Long

        If (IsBytesToRead = False) Then
            Return ""
        End If

        Try

            ret = MyRead(buf, 0, WillCountToRead, 100)
            If (buf(2) = &H21) Then
                'tim.Stop()
                EraseInputQueue()
                Return "Ошибка. Код ошибки:" + Hex(buf(3))
            End If
            If (ret > 0) Then
                If (ret = WillCountToRead) Then
                    If (ispackageError = True) Then
                        'tim.Stop()
                        For i = bufferindex + 1 To bufferindex + ret
                            buffer(i) = buf(i - bufferindex - 1)
                        Next
                        If (pagesToRead < 2) Then IsBytesToRead = False
                        bufferindex = 0
                        For i = 0 To 73
                            buffer(i) = 0
                        Next
                        If (pagesToRead < 2) Then EraseInputQueue()
                        ispackageError = False
                        Return ProcessRcvData(buffer, bufferindex)
                    End If
                    If (pagesToRead > 1) Then
                        pagesToRead = pagesToRead - 1
                        Return ProcessRcvData(buf, ret)
                    End If
                    'tim.Stop()
                    IsBytesToRead = False
                    EraseInputQueue()
                    Return ProcessRcvData(buf, ret)
                End If
                If (ret < WillCountToRead) Then
                    For i = bufferindex To bufferindex + ret - 1
                        buffer(i) = buf(i)
                    Next
                    ispackageError = True
                    WillCountToRead = WillCountToRead - ret
                    bufferindex = bufferindex + ret - 1
                End If
            End If
        Catch ex As Exception
            Return "Ошибка." + ex.Message
        End Try
        Return ""
    End Function
    Public Function DeCodeHCNumber(ByVal CodeHC As Long) As String

        DeCodeHCNumber = ""
        'CodeHC = CodeHC And ( 2 ^ 5 + 2 ^ 4 + 2 ^ 3 + 2 ^ 2 + 2 ^ 1 + 2 ^ 0)
        If CodeHC And 2 ^ 0 Then
            DeCodeHCNumber = "HC00" & ";"
        End If

        If CodeHC And 2 ^ 1 Then
            DeCodeHCNumber = DeCodeHCNumber + "HC01" & ";"
        End If

        If CodeHC And 2 ^ 2 Then
            DeCodeHCNumber = DeCodeHCNumber + "HC02" + ";"
        End If
        If CodeHC And 2 ^ 3 Then
            DeCodeHCNumber = DeCodeHCNumber + "HC03" + ";"
        End If
        If CodeHC And 2 ^ 4 Then
            DeCodeHCNumber = DeCodeHCNumber + "HC04" + ";"
        End If
        If CodeHC And 2 ^ 5 Then
            DeCodeHCNumber = DeCodeHCNumber + "HC05" + ";"
        End If
        If CodeHC And 2 ^ 6 Then
            DeCodeHCNumber = DeCodeHCNumber + "HC06" + ";"
        End If
        If CodeHC And 2 ^ 7 Then
            DeCodeHCNumber = DeCodeHCNumber + "HC07" + ";"
        End If



        If CodeHC And 2 ^ 8 Then
            DeCodeHCNumber = DeCodeHCNumber _
                    + "HC08" & ";"
        End If

        If CodeHC And 2 ^ 9 Then
            DeCodeHCNumber = DeCodeHCNumber _
                    + "HC09" & ";"
        End If

        If CodeHC And 2 ^ 10 Then
            DeCodeHCNumber = DeCodeHCNumber _
                    + "HC10" & ";"
        End If

        If CodeHC And 2 ^ 11 Then
            DeCodeHCNumber = DeCodeHCNumber _
                    + "HC11 " & ";"
        End If

        If CodeHC And 2 ^ 12 Then
            DeCodeHCNumber = DeCodeHCNumber _
                    + "HC12" & ";"
        End If

        If CodeHC And 2 ^ 13 Then
            DeCodeHCNumber = DeCodeHCNumber _
                    + "HC13" & ";"
        End If

        If CodeHC And 2 ^ 14 Then
            DeCodeHCNumber = DeCodeHCNumber _
                    + "HC14" & ";"
        End If

        If CodeHC And 2 ^ 15 Then
            DeCodeHCNumber = DeCodeHCNumber _
                    + "HC15" & ";"
        End If


    End Function
    Public Function DeCodeHCText(ByVal CodeHC As Long) As String



        '0	Расход ПР1 выше максимального расхода
        '1	Расход ПР1 ниже минимального расхода
        '2	Расход ПР4 выше максимального расхода
        '3	Расход ПР4 ниже минимального расхода
        '4	Расход ПР2 выше максимального расхода
        '5	Расход ПР2 ниже минимального расхода
        '6	Расход ПР5 выше максимального расхода
        '7	Расход ПР5 ниже минимального расхода
        '8	Расход ПР1 ниже расхода ПР2
        '9	Расход ПР4 выше расхода ПР5
        '10	Температура ПТ4 ниже температуры ПТ5
        '11	Температура ПТ1 ниже температуры ПТ2
        '12	Напряжение сети отсутствовало
        '13:     Прочие(ошибки)
        '14	Отказ канала температуры
        '15	Отказ канала давления
        DeCodeHCText = ""
        If CodeHC And 2 ^ 0 Then
            DeCodeHCText = DeCodeHCText _
                    & "Расход ПР1 выше максимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 1 Then
            DeCodeHCText = DeCodeHCText _
                    & "Расход ПР1 ниже минимального расхода" & ";"
        End If


        If CodeHC And 2 ^ 2 Then
            DeCodeHCText = DeCodeHCText _
                    & "Расход ПР4 выше максимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 3 Then
            DeCodeHCText = DeCodeHCText _
                    & "Расход ПР4 ниже минимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 4 Then
            DeCodeHCText = DeCodeHCText _
                    & "Расход ПР2 выше максимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 5 Then
            DeCodeHCText = DeCodeHCText _
                    & "Расход ПР2 ниже минимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 6 Then
            DeCodeHCText = DeCodeHCText _
                    & "Расход ПР5 выше максимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 7 Then
            DeCodeHCText = DeCodeHCText _
                    & "Расход ПР5 ниже минимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 8 Then
            DeCodeHCText = DeCodeHCText _
                    & "Расход ПР1 ниже расхода ПР2" & ";"
        End If

        If CodeHC And 2 ^ 9 Then
            DeCodeHCText = DeCodeHCText _
                    & "Расход ПР4 выше расхода ПР5" & ";"
        End If

        If CodeHC And 2 ^ 10 Then
            DeCodeHCText = DeCodeHCText _
                    & "Температура ПТ4 ниже температуры ПТ5" & ";"
        End If

        If CodeHC And 2 ^ 11 Then
            DeCodeHCText = DeCodeHCText _
                    & "Температура ПТ1 ниже температуры ПТ2" & ";"
        End If
        If CodeHC And 2 ^ 12 Then
            DeCodeHCText = DeCodeHCText _
                    & "Напряжение сети отсутствовало" & ";"
        End If


        If CodeHC And 2 ^ 13 Then
            DeCodeHCText = DeCodeHCText _
                    & "Прочие(ошибки)" & ";"
        End If

        If CodeHC And 2 ^ 14 Then
            DeCodeHCText = DeCodeHCText _
                    & "Отказ канала температуры" & ";"
        End If

        If CodeHC And 2 ^ 15 Then
            DeCodeHCText = DeCodeHCText _
                    & "Отказ канала давления" & ";"
        End If

    End Function
    Public Function DeCodeHC(ByVal CodeHC As Short) As String


        '0	Расход ПР1 выше максимального расхода
        '1	Расход ПР1 ниже минимального расхода
        '2	Расход ПР4 выше максимального расхода
        '3	Расход ПР4 ниже минимального расхода
        '4	Расход ПР2 выше максимального расхода
        '5	Расход ПР2 ниже минимального расхода
        '6	Расход ПР5 выше максимального расхода
        '7	Расход ПР5 ниже минимального расхода
        '8	Расход ПР1 ниже расхода ПР2
        '9	Расход ПР4 выше расхода ПР5
        '10	Температура ПТ4 ниже температуры ПТ5
        '11	Температура ПТ1 ниже температуры ПТ2
        '12	Напряжение сети отсутствовало
        '13:     Прочие(ошибки)
        '14	Отказ канала температуры
        '15	Отказ канала давления


        DeCodeHC = ""

        If CodeHC And 2 ^ 0 Then
            DeCodeHC = DeCodeHC _
                    & "HC:0 - Расход ПР1 выше максимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 1 Then
            DeCodeHC = DeCodeHC _
                    & "HC:1 - Расход ПР1 ниже минимального расхода" & ";"
        End If


        If CodeHC And 2 ^ 2 Then
            DeCodeHC = DeCodeHC _
                    & "HC:2 - Расход ПР4 выше максимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 3 Then
            DeCodeHC = DeCodeHC _
                    & "HC:3 - Расход ПР4 ниже минимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 4 Then
            DeCodeHC = DeCodeHC _
                    & "HC:4 - Расход ПР2 выше максимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 5 Then
            DeCodeHC = DeCodeHC _
                    & "HC:5 - Расход ПР2 ниже минимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 6 Then
            DeCodeHC = DeCodeHC _
                    & "HC:6 - Расход ПР5 выше максимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 7 Then
            DeCodeHC = DeCodeHC _
                    & "HC:7 - Расход ПР5 ниже минимального расхода" & ";"
        End If

        If CodeHC And 2 ^ 8 Then
            DeCodeHC = DeCodeHC _
                    & "HC:8 - Расход ПР1 ниже расхода ПР2" & ";"
        End If

        If CodeHC And 2 ^ 9 Then
            DeCodeHC = DeCodeHC _
                    & "HC:9 - Расход ПР4 выше расхода ПР5" & ";"
        End If

        If CodeHC And 2 ^ 10 Then
            DeCodeHC = DeCodeHC _
                    & "HC:10 - Температура ПТ4 ниже температуры ПТ5" & ";"
        End If

        If CodeHC And 2 ^ 11 Then
            DeCodeHC = DeCodeHC _
                    & "HC:11 - Температура ПТ1 ниже температуры ПТ2" & ";"
        End If
        If CodeHC And 2 ^ 12 Then
            DeCodeHC = DeCodeHC _
                    & "HC:12 - Напряжение сети отсутствовало" & ";"
        End If


        If CodeHC And 2 ^ 13 Then
            DeCodeHC = DeCodeHC _
                    & "HC:13 - Прочие(ошибки)" & ";"
        End If

        If CodeHC And 2 ^ 14 Then
            DeCodeHC = DeCodeHC _
                    & "HC:14 - Отказ канала температуры" & ";"
        End If

        If CodeHC And 2 ^ 15 Then
            DeCodeHC = DeCodeHC _
                    & "HC:15 - Отказ канала давления" & ";"
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




    Public Function FloatExt(ByVal fB() As Byte, ByVal Index As Integer) As Single
        'Dim tmpStr As String = ""
        'Dim E As Long
        'Dim Mantissa As Long
        'Dim s As Long
        'Dim f As Single
        'Dim i As Long
        'If fb(index + 2) = 0 And fb(index + 1) = 0 And fb(index) = 0 And fb(index + 3) = 0 Then Return 0

        '' If floatStr = String(4, 0) Then Exit Function
        'For i = 1 To 4
        '    tmpStr = Chr(Asc(Mid(floatStr, i, 1))) & tmpStr
        'Next i


        'floatStr = tmpStr
        ''================ Float число========================
        ''ст.байт                                 младший байт
        ''====================================================
        ''двоич.порядок |ст.байт                  младший байт
        ''----------------------------------------------------
        '' xxxx xxxx     | sxxx xxxx | xxxx xxxx | xxxx xxxx |

        '' A = (-1)^s * f * 2^(e-127)
        '' f= сумма от 0 до 23 a(k)*2^(-k), где a(k) бит мантисы с номером k


        'E = Asc(Mid(floatStr, 1, 1))
        'If Asc(Mid(floatStr, 2, 1)) And (2 ^ 7) Then
        '    s = 1
        'Else
        '    s = 0
        'End If
        'Mantissa = ((Asc(Mid(floatStr, 2, 1)) And &H7F) << 16) _
        '             + (Asc(Mid(floatStr, 3, 1)) << 8) _
        '             + (Asc(Mid(floatStr, 4, 1)))

        ''Mantissa = (Asc(Mid(floatStr, 2, 1)) And &H7F) * (2 ^ 16) _
        ''                     + Asc(Mid(floatStr, 3, 1)) * (2 ^ 8) _
        ''                     + Asc(Mid(floatStr, 4, 1))

        'f = 2 ^ 0
        'For i = 22 To 0 Step -1
        '    If Mantissa And 2& ^ i Then
        '        f = f + 2 ^ (i - 23)
        '    End If
        'Next i
        'FloatExt = ((-1) ^ s) * f * (2.0! ^ (E - 127))
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

        WriteArchToDB = "INSERT INTO " & TableForArch(Arch.archType) & "(" & TableForArch(Arch.archType) & "id,instanceid,DCALL,DCOUNTER,t1,t2,t3,t4,t5,t6,tce1,tce2,tair1,tair2,p1,p2,p3,p4,v1,v2,v3,v4,v5,v6,m1,m2,m3,m4,m5,m6,sp_TB1,sp_TB2,q1,q2,q4,q5,TSUM1,TSUM2,hc_code,hc, errtime) values ("
        WriteArchToDB = WriteArchToDB + "" + GUID2String(MyManager.Session, Guid.NewGuid) + ","
        WriteArchToDB = WriteArchToDB + "" + GUID2String(MyManager.Session, DeviceID) + ","
        WriteArchToDB = WriteArchToDB + "" + MyManager.Session.GetProvider.GetServerDate() + "" + ","
        WriteArchToDB = WriteArchToDB + MyManager.Session.GetProvider.Date2Const(Arch.DateArch) + ","
        WriteArchToDB = WriteArchToDB + Arch.T1.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.T2.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.T3.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.T4.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.T5.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.T6.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.tx1.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.tx2.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.tair1.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.tair2.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.P1.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.P2.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.P3.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.P4.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.V1.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.V2.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.V3.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.v4.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.v5.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.v6.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.M1.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.M2.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.M3.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.M4.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.M5.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.M6.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.SPtv1.ToString + ","
        WriteArchToDB = WriteArchToDB + Arch.SPtv2.ToString + ","
        WriteArchToDB = WriteArchToDB + Arch.Q1.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.Q2.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.QG1.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.QG2.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.Tw1.ToString.Replace(",", ".") + ","
        WriteArchToDB = WriteArchToDB + Arch.Tw2.ToString.Replace(",", ".") + ","



        If DeCodeHCNumber(Arch.HC) = "" Then
            WriteArchToDB = WriteArchToDB + "'-','Нет HC'"
        Else
            WriteArchToDB = WriteArchToDB + "'" + S180(DeCodeHCNumber(Arch.HC)) + "','" + S180("Счетчик:" + DeCodeHCText(Arch.HC)) + "'"
        End If
        WriteArchToDB = WriteArchToDB + "," + Arch.Errtime.ToString.Replace(",", ".")

        WriteArchToDB = WriteArchToDB + ")"
        Debug.Print(WriteArchToDB)
    End Function
    Public Overrides Function WriteMArchToDB() As String
        WriteMArchToDB = ""
        Try
            WriteMArchToDB = "INSERT INTO " & TableForArch(mArch.archType) & "(" & TableForArch(mArch.archType) & "id,instanceid,DCALL,DCOUNTER,t1,t2,t3,t4,t5,t6,p1,p2,p3,p4,g1,g2,g3,g4,g5,g6,dt12,dt45,sp_TB1,sp_TB2,tce1,tce2,tair1,tair2,hc_code,hc,hc_1,hc_2) values ("
            WriteMArchToDB = WriteMArchToDB + "" + GUID2String(MyManager.Session, Guid.NewGuid) + ","
            WriteMArchToDB = WriteMArchToDB + "" + guid2string(mymanager.session, DeviceID) + ","
            WriteMArchToDB = WriteMArchToDB + "" + MyManager.Session.GetProvider.GetServerDate() + "" + ","
            WriteMArchToDB = WriteMArchToDB + MyManager.Session.GetProvider.Date2Const(mArch.DateArch) + ","
            WriteMArchToDB = WriteMArchToDB + mArch.t1.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.t2.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.t3.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.t4.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.t5.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.t6.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.p1.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.p2.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.p3.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.p4.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.G1.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.G2.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.G3.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.G4.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.G5.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.G6.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.dt12.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.dt45.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.SPtv1.ToString + ","
            WriteMArchToDB = WriteMArchToDB + mArch.SPtv2.ToString + ","
            WriteMArchToDB = WriteMArchToDB + mArch.tx1.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.tx2.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.tair1.ToString.Replace(",", ".") + ","
            WriteMArchToDB = WriteMArchToDB + mArch.tair2.ToString.Replace(",", ".") + ","



            If DeCodeHCNumber(mArch.HC) = "" Then
                WriteMArchToDB = WriteMArchToDB + "'-','Нет HC',"
            Else
                WriteMArchToDB = WriteMArchToDB + "'" + DeCodeHCNumber(mArch.HC) + "','" + S180("Счетчик: " + DeCodeHCText(mArch.HC)) + "',"
            End If

            WriteMArchToDB = WriteMArchToDB + "'" + DeCodeHCText(mArch.HC) + "',"
            WriteMArchToDB = WriteMArchToDB + "'-'"
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

    Private Function ReadCommand(ByVal Code As Byte, ByVal chanel As Byte) As String
        Dim cmdBuf(1000) As Byte
        Dim sRes(10) As String
        Dim bDup(10) As Boolean
        Dim Cnt(10) As Integer
        Dim bsz(10) As Integer
        Dim buf(1000) As Byte
        Dim maxPass As Int16
        maxPass = 4

        Dim result As String
        result = "Error reading data"

        cmdBuf(0) = 4
        cmdBuf(1) = Code

        If chanel = 255 Then

            cmdBuf(2) = 0
            cmdBuf(3) = ChSum(cmdBuf, 3)

        Else
            cmdBuf(2) = ChanelToByte(chanel)
            cmdBuf(3) = ChSum(cmdBuf, 3)


        End If

        Dim i As Int16, j As Int16, pass As Int16

        For pass = 0 To maxPass
            MyTransport.Write(cmdBuf, 0, 4)

            RaiseIdle()
            System.Threading.Thread.Sleep(SleepTime)



            Dim btr As Long
            Dim sz As Long = 0
            Dim bufStr As String
            bsz(pass) = 0
            bufStr = ""
            ReDim buf(1000)
            For i = 1 To 20

                RaiseIdle()
                System.Threading.Thread.Sleep(MiniSleepTime)

                btr = MyTransport.BytesToRead
                If btr > 0 Then
                    MyTransport.Read(buf, bsz(pass), btr)
                    bsz(pass) += btr
                End If
            Next
            If bsz(pass) > 0 Then
                If buf(0) = 0 And buf(bsz(pass) - 1) = 0 Then
                    buf = System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(866), System.Text.Encoding.Default, buf, 1, bsz(pass) - 2)
                    For j = 0 To bsz(pass) - 3
                        bufStr = bufStr + Chr(buf(j))
                    Next
                    sRes(pass) = bufStr
                End If
            End If
        Next
        ' проверяем правильность получения данных
        For pass = 0 To maxPass
            If bDup(pass) = False Then
                Cnt(pass) = 1
                For j = pass + 1 To maxPass
                    If sRes(pass) = sRes(j) And bDup(j) = False Then
                        Cnt(pass) += 1
                        bDup(j) = True
                    End If
                Next
            End If
        Next

        Dim maxIdx As Integer
        maxIdx = 0
        For pass = 0 To maxPass

            If Cnt(pass) >= Cnt(maxIdx) And bDup(pass) = False Then
                maxIdx = pass
            End If
        Next


        Return sRes(maxIdx)
    End Function


    Private Function ReadCommand5(ByVal Code As Byte, ByVal b As Byte, ByVal chanel As Byte) As String
        Dim cmdBuf(1000) As Byte
        Dim sRes(10) As String
        Dim bDup(10) As Boolean
        Dim Cnt(10) As Integer
        Dim bsz(10) As Integer
        Dim buf(1000) As Byte
        Dim maxPass As Int16
        maxPass = 4

        Dim result As String
        result = "Error reading data"

        cmdBuf(0) = 5
        cmdBuf(1) = Code

        If chanel = 255 Then

            cmdBuf(2) = 0
            cmdBuf(3) = b
            cmdBuf(4) = ChSum(cmdBuf, 4)

        Else
            cmdBuf(2) = ChanelToByte(chanel)
            cmdBuf(3) = b
            cmdBuf(4) = ChSum(cmdBuf, 4)


        End If

        Dim i As Int16, j As Int16, pass As Int16

        For pass = 0 To maxPass
            MyTransport.Write(cmdBuf, 0, 5)

            RaiseIdle()
            System.Threading.Thread.Sleep(10)


            Dim btr As Long
            Dim sz As Long = 0
            Dim bufStr As String
            bsz(pass) = 0
            bufStr = ""
            ReDim buf(1000)
            For i = 1 To 20

                RaiseIdle()
                System.Threading.Thread.Sleep(10)

                btr = MyTransport.BytesToRead
                If btr > 0 Then
                    MyTransport.Read(buf, bsz(pass), btr)
                    bsz(pass) += btr
                End If
            Next
            If bsz(pass) > 0 Then
                If buf(0) = 0 And buf(bsz(pass) - 1) = 0 Then
                    buf = System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding(866), System.Text.Encoding.Default, buf, 1, bsz(pass) - 2)
                    For j = 0 To bsz(pass) - 3
                        bufStr = bufStr + Chr(buf(j))
                    Next
                    sRes(pass) = bufStr
                End If
            End If
        Next
        ' проверяем правильность получения данных
        For pass = 0 To maxPass
            If bDup(pass) = False Then
                Cnt(pass) = 1
                For j = pass + 1 To maxPass
                    If sRes(pass) = sRes(j) And bDup(j) = False Then
                        Cnt(pass) += 1
                        bDup(j) = True
                    End If
                Next
            End If
        Next

        Dim maxIdx As Integer
        maxIdx = 0
        For pass = 0 To maxPass

            If Cnt(pass) >= Cnt(maxIdx) And bDup(pass) = False Then
                maxIdx = pass
            End If
        Next


        Return sRes(maxIdx)
    End Function

    Public Overrides Function ReadMArch() As String

        '0x31 т1	SINGLE	Мгновенные	G1
        '0x31 т2	SINGLE	Мгновенные	G2
        '0x31 т4	SINGLE	Мгновенные	G4
        '0x31 т5	SINGLE	Мгновенные	G5
        '0x33	SINGLE	Мгновенные	Tхк1
        '0x33 т2	SINGLE	Мгновенные	Tхк2
        '0x34 4	SINGLE	Мгновенные	T4
        '0x34 5	SINGLE	Мгновенные	T5
        '0x34 т1	SINGLE	Мгновенные	T1
        '0x34 т2	SINGLE	Мгновенные	T2
        '0x35 т1-т2	SINGLE	Мгновенные	dT
        '0x61	SINGLE	Мгновенные	Gгвс
        '0xA4	SINGLE	Мгновенные	KQ
        '0xA5 т1	SINGLE	Мгновенные	dQ1
        '0xA5 т2	SINGLE	Мгновенные	dQ2
        '0xD1	SINGLE	Мгновенные	Tхв
        '0xD3 т1	SINGLE	Мгновенные	P1
        '0xD3 т1т2	SINGLE	Мгновенные	dP
        '0xD3 т2	SINGLE	Мгновенные	P2
        '0xD3 хв	SINGLE	Мгновенные	Pхв
        '0xD3 к4	SINGLE	Мгновенные	P4
        '0xD3 к5	SINGLE	Мгновенные	P5

        clearMarchive(mArch)
        Dim str As String
        str = ReadCommand(&H31, 1)
        If Left(str, 5) <> "Error" Then mArch.G1 = Val(str)
        str = ReadCommand(&H31, 2)
        If Left(str, 5) <> "Error" Then mArch.G2 = Val(str)
        str = ReadCommand(&H31, 4)
        If Left(str, 5) <> "Error" Then mArch.G4 = Val(str)
        str = ReadCommand(&H31, 5)
        If Left(str, 5) <> "Error" Then mArch.G5 = Val(str)
        'mArch.tx1 = Val(ReadCommand(&H33, 1))
        'mArch.tx2 = Val(ReadCommand(&H33, 2))
        str = ReadCommand(&H34, 1)
        If Left(str, 5) <> "Error" Then mArch.t1 = Val(str)
        str = ReadCommand(&H34, 2)
        If Left(str, 5) <> "Error" Then mArch.t2 = Val(str)
        str = ReadCommand(&H34, 4)
        If Left(str, 5) <> "Error" Then mArch.t3 = Val(str)
        str = ReadCommand(&H34, 5)
        If Left(str, 5) <> "Error" Then mArch.t4 = Val(str)
        str = ReadCommand(&H35, 255)
        If Left(str, 5) <> "Error" Then mArch.dt12 = Val(str)
        str = ReadCommand(&H61, 255)
        If Left(str, 5) <> "Error" Then mArch.G3 = Val(str)
        str = ReadCommand(&HA5, 1)
        If Left(str, 5) <> "Error" Then mArch.dQ1 = Val(str)
        str = ReadCommand(&HA5, 2)
        If Left(str, 5) <> "Error" Then mArch.dQ2 = Val(str)
        str = ReadCommand(&HD1, 2)
        If Left(str, 5) <> "Error" Then mArch.tx1 = Val(str)
        str = ReadCommand(&HD3, 1)
        If Left(str, 5) <> "Error" Then mArch.p1 = Val(str)
        str = ReadCommand(&HD3, 2)
        If Left(str, 5) <> "Error" Then mArch.p2 = Val(str)
        str = ReadCommand(&HD3, 4)
        If Left(str, 5) <> "Error" Then mArch.p4 = Val(str)
        str = ReadCommand(&HD3, 5)
        If Left(str, 5) <> "Error" Then mArch.p5 = Val(str)
        str = ReadCommand(&HD3, 5)
        If Left(str, 5) <> "Error" Then mArch.p3 = Val(str)
        str = ReadCommand(&HD3, 1)
        If Left(str, 5) <> "Error" Then mArch.p1 = Val(str)

        mArch.DateArch = DateTime.Now
        Try
            '0x42	DATE	Системные	Дата	Системная Дата счетчика
            Dim DBUF As String = ""
            str = ReadCommand(&H42, 255)
            If Left(str, 5) <> "Error" Then DBUF = str
            '0x43	DATE	Системные	Время	Системное Время счетчика
            str = ReadCommand(&H43, 255)
            If Left(str, 5) <> "Error" Then
                If DBUF <> "" Then
                    mArch.DateArch = Date.Parse(DBUF + " " + str)
                Else
                    mArch.DateArch = Date.Parse(str)
                End If


            End If
            If mArch.DateArch.Year < 1950 Then
                mArch.DateArch = DateTime.Now
            End If
        Catch
        End Try

        Try
            '0x3b	HC	Нештатная Ситуация	Статус	Статус (Код Состояния)
            str = ReadCommand(&H3B, 255)
            If Left(str, 5) <> "Error" Then mArch.HC = Convert.ToInt32(str, 2)
        Catch
        End Try


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

        '0x30 т1	SINGLE	Итоговые	Q1	Значение Объемного расхода канал 1
        '0x30 т2	SINGLE	Итоговые	Q2	Значение Объемного расхода канал 2
        '0x30 т4	SINGLE	Итоговые	Q4	Объем воды по каналу 4
        '0x30 т5	SINGLE	Итоговые	Q5	Объем воды по каналу 5
        '0x36 т1	SINGLE	Итоговые	W1	Значение теплоты канал 1
        '0x36 т2	SINGLE	Итоговые	W2	Значение теплоты канал 2
        '0x39	SINGLE	Итоговые	tработы	Время работы счетчика
        '0x3A	SINGLE	Итоговые	tаварии	Время аварии счетчика
        '0x63	SINGLE	Итоговые	dW	Разность теплоты (расход теплоты)

        Dim str As String
        str = ReadCommand(&H30, 1)
        If Left(str, 5) <> "Error" Then tArch.V1 = Val(str)
        str = ReadCommand(&H30, 2)
        If Left(str, 5) <> "Error" Then tArch.V2 = Val(str)
        str = ReadCommand(&H30, 4)
        If Left(str, 5) <> "Error" Then tArch.V4 = Val(str)
        str = ReadCommand(&H30, 5)
        If Left(str, 5) <> "Error" Then tArch.V5 = Val(str)

        str = ReadCommand(&H36, 1)
        If Left(str, 5) <> "Error" Then tArch.Q1 = Val(str)
        str = ReadCommand(&H36, 2)
        If Left(str, 5) <> "Error" Then tArch.Q2 = Val(str)

        str = ReadCommand(&H39, 255)
        If Left(str, 5) <> "Error" Then tArch.TW1 = Val(str)
        str = ReadCommand(&H3A, 255)
        If Left(str, 5) <> "Error" Then tArch.TW1 = Val(str)
        str = ReadCommand(&H63, 255)
        If Left(str, 5) <> "Error" Then tArch.Q4 = Val(str)

        tArch.DateArch = DateTime.Now
        Try
            '0x42	DATE	Системные	Дата	Системная Дата счетчика
            Dim DBUF As String = ""
            str = ReadCommand(&H42, 255)
            If Left(str, 5) <> "Error" Then DBUF = str
            '0x43	DATE	Системные	Время	Системное Время счетчика
            str = ReadCommand(&H43, 255)
            If Left(str, 5) <> "Error" Then
                If DBUF <> "" Then
                    tArch.DateArch = Date.Parse(DBUF + " " + str)
                Else
                    tArch.DateArch = Date.Parse(str)
                End If


            End If
            If tArch.DateArch.Year < 1950 Then
                tArch.DateArch = DateTime.Now
            End If
        Catch
        End Try

        Try
            '0x3b	HC	Нештатная Ситуация	Статус	Статус (Код Состояния)
            str = ReadCommand(&H3B, 255)
            If Left(str, 5) <> "Error" Then tArch.HC = Convert.ToInt32(str, 2)
        Catch
        End Try
        isTArchToDBWrite = True

        Return "Итоговый архив прочитан"
    End Function

    Public Overrides Function WriteTArchToDB() As String
        WriteTArchToDB = "INSERT INTO " & TableForArch(tArch.archType) & "(" & TableForArch(tArch.archType) & "id,instanceid,DCALL,DCOUNTER,Q1,Q2,Q3,Q4,M1,M2,M3,M4,M5,M6,v1,v2,v3,v4,v5,v6,TSUM1,TSUM2) values ("
        WriteTArchToDB = WriteTArchToDB + "" + GUID2String(MyManager.Session, Guid.NewGuid) + ","
        WriteTArchToDB = WriteTArchToDB + "" + guid2string(mymanager.session, DeviceID) + ","
        WriteTArchToDB = WriteTArchToDB + "" + MyManager.Session.GetProvider.GetServerDate() + "" + ","
        WriteTArchToDB = WriteTArchToDB + MyManager.Session.GetProvider.Date2Const(tArch.DateArch) + ","
        WriteTArchToDB = WriteTArchToDB + tArch.Q1.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.Q2.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.Q3.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.Q4.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.M1.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.M2.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.M3.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.M4.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.M5.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.M6.ToString.Replace(",", ".") + ","

        WriteTArchToDB = WriteTArchToDB + tArch.V1.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.V2.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.V3.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.V4.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.V5.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.V6.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.TW1.ToString.Replace(",", ".") + ","
        WriteTArchToDB = WriteTArchToDB + tArch.TW2.ToString.Replace(",", ".")
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
        SSS = "INSERT INTO " & "TPLC_M" & "(TPLC_MID,instanceid,DCALL,DCOUNTER,hc) values ("
        SSS = SSS + "" + GUID2String(MyManager.Session, Guid.NewGuid) + ","
        SSS = SSS + "" + guid2string(mymanager.session, DeviceID) + ","
        SSS = SSS + "" + MyManager.Session.GetProvider.GetServerDate() + "" + ","
        SSS = SSS + MyManager.Session.GetProvider.Date2Const(ErrDate) + ","
        SSS = SSS + "'" & ErrMsg & "')"
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

        Dim dr As DataRow

        '0x3E 0	SINGLE	Системные	DeltaT	Значение DeltaT
        dr = dt.NewRow
        dr("Название") = "Значение DeltaT"
        dr("Значение") = ReadCommand(&H3E, 0)
        dt.Rows.Add(dr)


        '0x3E 01	SINGLE	Системные	DeltaT2	Значение DeltaT2
        dr = dt.NewRow
        dr("Название") = "Значение DeltaT2"
        dr("Значение") = ReadCommand(&H3E, 1)
        dt.Rows.Add(dr)




        '0x40	LONG	Системные	Adr RS485	Адрес по интерфейсу RS485
        dr = dt.NewRow
        dr("Название") = "Адрес по интерфейсу RS485"
        dr("Значение") = ReadCommand(&H40, 255)
        dt.Rows.Add(dr)

        '0x42	DATE	Системные	Дата	Системная Дата счетчика
        dr = dt.NewRow
        dr("Название") = "Системная Дата счетчика"
        dr("Значение") = ReadCommand(&H42, 255)
        dt.Rows.Add(dr)


        '0x43	DATE	Системные	Время	Системное Время счетчика
        dr = dt.NewRow
        dr("Название") = "Системное Время счетчика"
        dr("Значение") = ReadCommand(&H43, 255)
        dt.Rows.Add(dr)


        '0x46	STRING	Системные	Версия	Информация о Версии Счетчика
        dr = dt.NewRow
        dr("Название") = "Информация о Версии Счетчика"
        dr("Значение") = ReadCommand(&H46, 255)
        dt.Rows.Add(dr)


        '0x4D т1	SINGLE	Системные	K const т1	Значение коHCтанты K канал 1
        dr = dt.NewRow
        dr("Название") = "Значение коHCтанты K канал 1"
        dr("Значение") = ReadCommand(&H4D, 1)
        dt.Rows.Add(dr)

        '0x4D т2	SINGLE	Системные	K const т2	Значение коHCтанты K канал 2
        dr = dt.NewRow
        dr("Название") = "Значение коHCтанты K канал 2"
        dr("Значение") = ReadCommand(&H4D, 2)
        dt.Rows.Add(dr)

        '0x4E т1	SINGLE	Системные	P const т1	Значение коHCтанты P канал 1
        dr = dt.NewRow
        dr("Название") = "Значение коHCтанты P канал 1"
        dr("Значение") = ReadCommand(&H4E, 1)
        dt.Rows.Add(dr)

        '0x4E т2	SINGLE	Системные	P const т2	Значение коHCтанты P канал 2
        dr = dt.NewRow
        dr("Название") = "Значение коHCтанты P канал 2"
        dr("Значение") = ReadCommand(&H4E, 2)
        dt.Rows.Add(dr)


        '0x4F	STRING	Системные	Информ1	Информация о продукте 1
        dr = dt.NewRow
        dr("Название") = "Информация о продукте 1"
        dr("Значение") = ReadCommand(&H4F, 255)
        dt.Rows.Add(dr)


        '0x50	STRING	Системные	Nиздел.	Идентификационный номер счетчика
        dr = dt.NewRow
        dr("Название") = "Идентификационный номер счетчика"
        dr("Значение") = ReadCommand(&H50, 255)
        dt.Rows.Add(dr)

        '0x52 1	SINGLE	Системные	0 реф 1	Нулевая референция 1
        dr = dt.NewRow
        dr("Название") = "Нулевая референция 1"
        dr("Значение") = ReadCommand(&H52, 1)
        dt.Rows.Add(dr)


        '0x52 2	SINGLE	Системные	0 реф 2	Нулевая референция 2
        dr = dt.NewRow
        dr("Название") = "Нулевая референция 2"
        dr("Значение") = ReadCommand(&H52, 2)
        dt.Rows.Add(dr)

        '0x53 1	SINGLE	Системные	Не 0 реф 1	Ненулевая референция 1
        dr = dt.NewRow
        dr("Название") = "Ненулевая референция 1"
        dr("Значение") = ReadCommand(&H53, 1)
        dt.Rows.Add(dr)

        '0x53 2	SINGLE	Системные	Не 0 реф 2	Ненулевая референция 2
        dr = dt.NewRow
        dr("Название") = "Ненулевая референция 2"
        dr("Значение") = ReadCommand(&H53, 2)
        dt.Rows.Add(dr)

        '0x81 т1	SINGLE	Системные	ТипДатчика т1	Тип Датчика канала 1
        dr = dt.NewRow
        dr("Название") = "Тип Датчика канала 1"
        dr("Значение") = ReadCommand(&H81, 1)
        dt.Rows.Add(dr)

        '0x81 т2	SINGLE	Системные	ТипДатчика т2	Тип Датчика канала 2
        dr = dt.NewRow
        dr("Название") = "Тип Датчика канала 2"
        dr("Значение") = ReadCommand(&H81, 2)
        dt.Rows.Add(dr)

        '0x83 т1	SINGLE	Системные	KP const т1	КоHCтанта преобразования импульс/литр канал 1
        dr = dt.NewRow
        dr("Название") = "КоHCтанта преобразования импульс/литр канал 1"
        dr("Значение") = ReadCommand(&H83, 1)
        dt.Rows.Add(dr)

        '0x83 т2	SINGLE	Системные	KP const т2	КоHCтанта преобразования импульс/литр канал 2
        dr = dt.NewRow
        dr("Название") = "КоHCтанта преобразования импульс/литр канал 2"
        dr("Значение") = ReadCommand(&H83, 2)
        dt.Rows.Add(dr)


        '0x84 т1	SINGLE	Системные	ЧастВых G1	Значение выходной частоты Расхода канал 1
        dr = dt.NewRow
        dr("Название") = "Значение выходной частоты Расхода канал 1"
        dr("Значение") = ReadCommand(&H84, 1)
        dt.Rows.Add(dr)
        '0x84 т2	SINGLE	Системные	ЧастВых G2	Значение выходной частоты Расхода канал 2
        dr = dt.NewRow
        dr("Название") = "Значение выходной частоты Расхода канал 2"
        dr("Значение") = ReadCommand(&H84, 2)
        dt.Rows.Add(dr)


        '0x85 т1	SINGLE	Системные	ЧастВход т1	Входная частота канал 1
        dr = dt.NewRow
        dr("Название") = "Входная частота канал 1"
        dr("Значение") = ReadCommand(&H85, 1)
        dt.Rows.Add(dr)

        '0x85 т2	SINGLE	Системные	ЧастВход т2	Входная частота канал 2
        dr = dt.NewRow
        dr("Название") = "Входная частота канал 2"
        dr("Значение") = ReadCommand(&H85, 2)
        dt.Rows.Add(dr)


        '0x8D	SINGLE	Системные	tперекалибровки	Значение Времени перекалибровки
        dr = dt.NewRow
        dr("Название") = "Значение Времени перекалибровки"
        dr("Значение") = ReadCommand(&H8D, 255)
        dt.Rows.Add(dr)

        '0x9e к4	STRING	Системные	Ед.Изм.G4 V4	Единицы измерения объема и расхода канала 4
        dr = dt.NewRow
        dr("Название") = "Единицы измерения объема и расхода канала 4"
        dr("Значение") = ReadCommand(&H9E, 4)
        dt.Rows.Add(dr)

        '0x9e к5	STRING	Системные	Ед.Изм.G5 V5	Единицы измерения объема и расхода канала 5
        dr = dt.NewRow
        dr("Название") = "Единицы измерения объема и расхода канала 5"
        dr("Значение") = ReadCommand(&H9E, 5)
        dt.Rows.Add(dr)

        '0x9E т1	STRING	Системные	Ед.Изм.G1 V1	Единицы измерения Объемов и Расходов канала 1
        dr = dt.NewRow
        dr("Название") = "Единицы измерения объема и расхода канала 1"
        dr("Значение") = ReadCommand(&H9E, 1)
        dt.Rows.Add(dr)

        '0x9E т2	STRING	Системные	Ед.Изм.G2 V2	Единицы измерения Объемов и Расходов канала 2
        dr = dt.NewRow
        dr("Название") = "Единицы измерения объема и расхода канала 2"
        dr("Значение") = ReadCommand(&H9E, 2)
        dt.Rows.Add(dr)


        '0xA2	STRING	Системные	Скорость RS485	Значение скорости коммуникации по интерфейсу RS485
        dr = dt.NewRow
        dr("Название") = "Значение скорости коммуникации по интерфейсу RS485"
        dr("Значение") = ReadCommand(&HA2, 2)
        dt.Rows.Add(dr)

        '0xA4	SINGLE	Системные	KQ не отечает счетчик	Значение KQ


        '0xA9 т1	STRING	Системные	Ед.Изм.W1	Единицы измерения энергии канала 1
        dr = dt.NewRow
        dr("Название") = "Единицы измерения энергии канала 1"
        dr("Значение") = ReadCommand(&HA9, 1)
        dt.Rows.Add(dr)




        '0xA9 т2	STRING	Системные	Ед.Изм.W2	Единицы измерения энергии канала 2
        dr = dt.NewRow
        dr("Название") = "Единицы измерения энергии канала 2"
        dr("Значение") = ReadCommand(&HA9, 2)
        dt.Rows.Add(dr)

        '0xAA	STRING	Системные	Датч.исп.	Использование Датчиков
        dr = dt.NewRow
        dr("Название") = "Использование Датчиков"
        dr("Значение") = ReadCommand(&HAA, 255)
        dt.Rows.Add(dr)

        '0xAE 4	SINGLE	Системные	№ T4датч	Номер термодатчика 4
        dr = dt.NewRow
        dr("Название") = "Номер термодатчика 4"
        dr("Значение") = ReadCommand(&HAE, 4)
        dt.Rows.Add(dr)


        '0xAE 5	SINGLE	Системные	№ T5датч	Номер термодатчика 5
        dr = dt.NewRow
        dr("Название") = "Номер термодатчика 5"
        dr("Значение") = ReadCommand(&HAE, 5)
        dt.Rows.Add(dr)

        '0xC8	SINGLE	Системные	Iвкат	Ток возбуждения катушки
        dr = dt.NewRow
        dr("Название") = "Ток возбуждения катушки"
        dr("Значение") = ReadCommand(&HC8, 255)
        dt.Rows.Add(dr)

        '0xC9 1	SINGLE	Системные	Kкор1	Коэффициент коррекции 1
        dr = dt.NewRow
        dr("Название") = "Коэффициент коррекции 1"
        dr("Значение") = ReadCommand(&HC9, 1)
        dt.Rows.Add(dr)

        '0xC9 2	SINGLE	Системные	Kкор2	Коэффициент коррекции 2
        dr = dt.NewRow
        dr("Название") = "Коэффициент коррекции 2"
        dr("Значение") = ReadCommand(&HC9, 2)
        dt.Rows.Add(dr)

        '0xCA 1	SINGLE	Системные	СмВхд1	Входное смещение 1
        dr = dt.NewRow
        dr("Название") = "Входное смещение 1"
        dr("Значение") = ReadCommand(&HCA, 1)
        dt.Rows.Add(dr)
        '0xCA 2	SINGLE	Системные	СмВхд2	Входное смещение 2
        dr = dt.NewRow
        dr("Название") = "Входное смещение 2"
        dr("Значение") = ReadCommand(&HCA, 2)
        dt.Rows.Add(dr)

        '0xCB	SINGLE	Системные	KdG	Коэффициент разницы расходов
        dr = dt.NewRow
        dr("Название") = "Коэффициент разницы расходов"
        dr("Значение") = ReadCommand(&HCB, 255)
        dt.Rows.Add(dr)

        '0xCD	SINGLE	Системные	AdrRS485_EEPROM	Адрес RS485 из EEPROM
        dr = dt.NewRow
        dr("Название") = "Адрес RS485 из EEPROM"
        dr("Значение") = ReadCommand(&HCD, 255)
        dt.Rows.Add(dr)

        '0xD5	STRING	Системные	ЗадачаСезона	Сезонная задача счетчика Зима/Лето
        dr = dt.NewRow
        dr("Название") = "Сезонная задача счетчика Зима/Лето"
        dr("Значение") = ReadCommand(&HD5, 255)
        dt.Rows.Add(dr)


        '0xD7	STRING	Системные	Тип ТСП	Тип Термопары
        dr = dt.NewRow
        dr("Название") = "Тип ТСП	Тип Термопары"
        dr("Значение") = ReadCommand(&HD7, 255)
        dt.Rows.Add(dr)




        Return dt
    End Function


    Private Function GetArchiv(ByVal ArchDate As Date, ByVal ArcDayly As Boolean) As Object
        Dim DayInYear As Integer, N As Integer
        Dim AbsDay As Long, Adr As Long
        Dim i As Long
        DayInYear = 0

        For i = 1 To ArchDate.Month - 1
            Select Case i
                Case 1, 3, 5, 7, 8, 10, 12
                    DayInYear = DayInYear + 31
                Case 4, 6, 9, 11
                    DayInYear = DayInYear + 30
                Case 2
                    N = ArchDate.Year
                    DayInYear = DayInYear + 28 + IIf((N Mod 4 = 0 And N Mod 100 <> 0) Or (N Mod 400 = 0), 1, 0)
            End Select
        Next
        DayInYear = DayInYear + ArchDate.Day
        AbsDay = (Year(ArchDate) - 1) * 365 + ((Year(ArchDate) - 1) \ 4) + DayInYear


        If ArcDayly = True Then
            Adr = (AbsDay Mod 60) * 40 + 62048
        ElseIf ArcDayly = False Then
            Adr = ((AbsDay * 24 + Hour(ArchDate)) Mod 1428) * 42 + 2048
        End If

        Dim buf(1000) As Byte
        For i = 0 To 999
            buf(i) = 0
        Next
        Dim dar As DArch
        Dim har As HArch
        If ArcDayly = True Then
            ReadDayArchivTSR(Adr, buf)
            FillDArch(buf, dar)
            If isTCP Then
                ReDim buf(1000)
                For i = 0 To 999
                    buf(i) = 0
                Next
                ReadDayArchivTSR2(Adr, buf)
                FillDArchTCP(buf, dar)
            End If

            Return dar
        ElseIf ArcDayly = False Then
            ReadHourArchivTSR(Adr, buf)
            FillHArch(buf, har)
            If isTCP Then
                ReDim buf(1000)
                For i = 0 To 999
                    buf(i) = 0
                Next
                ReadHourArchivTSR2(Adr, buf)
                FillHArchTCP(buf, har)
            End If

            Return har
        End If
        Return buf

    End Function

    Private Sub ReadDayArchivTSR(ByVal Adr As Long, ByRef buf() As Byte)

        Dim btr As Long
        Dim sz As Long = 0
        Dim i As Long
        Dim cmdbuf(100) As Byte



        cmdbuf(0) = &H2F
        cmdbuf(1) = &H8
        cmdbuf(2) = Adr \ c_lng256
        cmdbuf(3) = Adr Mod c_lng256
        For i = 1 To 40
            cmdbuf(3 + i) = 32
        Next
        cmdbuf(44) = 0
        cmdbuf(45) = 0

        cmdbuf(46) = ChSum(cmdbuf, 45)


        Dim j As Long
        Dim pass(10) As DataPass
        Dim maxpass As Int16

        maxpass = 4
        For j = 0 To maxpass
            pass(j) = New DataPass
            sz = 0
            btr = 0
            MyTransport.Write(cmdbuf, 0, 47)
            RaiseIdle()
            System.Threading.Thread.Sleep(SleepTime)

            For i = 1 To 20
                RaiseIdle()
                System.Threading.Thread.Sleep(MiniSleepTime)
                btr = MyTransport.BytesToRead
                If btr > 0 Then
                    MyTransport.Read(pass(j).passdata, sz, btr)
                    sz += btr

                End If
            Next
        Next


        ' проверяем правильность получения данных
        Dim check As Int16
        For check = 0 To maxpass
            If pass(check).bDup = False Then
                pass(check).Cnt = 1
                For j = check + 1 To maxpass
                    If pass(check).GetHash() = pass(j).GetHash And pass(j).bDup = False Then
                        pass(check).Cnt += 1
                        pass(j).bDup = True
                    End If
                Next
            End If
        Next

        Dim maxIdx As Integer
        maxIdx = 0
        For check = 0 To maxpass

            If pass(check).Cnt >= pass(maxIdx).Cnt And pass(check).bDup = False Then
                maxIdx = check
            End If
        Next

        For i = 0 To 100
            buf(i) = pass(maxIdx).passdata(i)
        Next

    End Sub

    Private Sub ReadDayArchivTSR2(ByVal Adr As Long, ByRef buf() As Byte)

        Dim btr As Long
        Dim sz As Long = 0
        Dim i As Long


        Dim cmdbuf(100) As Byte



        cmdbuf(0) = &H2F
        cmdbuf(1) = &H18
        cmdbuf(2) = Adr \ c_lng256
        cmdbuf(3) = Adr Mod c_lng256
        For i = 1 To 40
            cmdbuf(3 + i) = 32
        Next
        cmdbuf(44) = 0
        cmdbuf(45) = 0

        cmdbuf(46) = ChSum(cmdbuf, 45)


        Dim j As Long
        Dim pass(10) As DataPass
        Dim maxpass As Int16

        maxpass = 4
        For j = 0 To maxpass
            pass(j) = New DataPass
            sz = 0
            btr = 0
            MyTransport.Write(cmdbuf, 0, 47)
            RaiseIdle()
            System.Threading.Thread.Sleep(SleepTime)

            For i = 1 To 20
                RaiseIdle()
                System.Threading.Thread.Sleep(MiniSleepTime)
                btr = MyTransport.BytesToRead
                If btr > 0 Then
                    MyTransport.Read(pass(j).passdata, sz, btr)
                    sz += btr

                End If
            Next
        Next

        ' проверяем правильность получения данных
        Dim check As Int16
        For check = 0 To maxpass
            If pass(check).bDup = False Then
                pass(check).Cnt = 1
                For j = check + 1 To maxpass
                    If pass(check).GetHash() = pass(j).GetHash And pass(j).bDup = False Then
                        pass(check).Cnt += 1
                        pass(j).bDup = True
                    End If
                Next
            End If
        Next

        Dim maxIdx As Integer
        maxIdx = 0
        For check = 0 To maxpass

            If pass(check).Cnt >= pass(maxIdx).Cnt And pass(check).bDup = False Then
                maxIdx = check
            End If
        Next

        For i = 0 To 100
            buf(i) = pass(maxIdx).passdata(i)
        Next
    End Sub
    Private Sub ReadHourArchivTSR(ByVal Adr As Long, ByRef buf() As Byte)
        Dim btr As Long
        Dim sz As Long = 0
        Dim i As Long
        Dim cmdbuf(100) As Byte

        cmdbuf(0) = &H31
        cmdbuf(1) = &H8
        cmdbuf(2) = Adr \ c_lng256
        cmdbuf(3) = Adr Mod c_lng256
        For i = 1 To 42
            cmdbuf(3 + i) = 32
        Next
        cmdbuf(46) = 0
        cmdbuf(47) = 0

        cmdbuf(48) = ChSum(cmdbuf, 47)

        Dim j As Long
        Dim pass(10) As DataPass
        Dim maxpass As Int16

        maxpass = 4
        For j = 0 To maxpass
            pass(j) = New DataPass
            sz = 0
            btr = 0
            MyTransport.Write(cmdbuf, 0, 49)
            RaiseIdle()
            System.Threading.Thread.Sleep(SleepTime)

            For i = 1 To 20
                RaiseIdle()
                System.Threading.Thread.Sleep(MiniSleepTime)
                btr = MyTransport.BytesToRead
                If btr > 0 Then
                    MyTransport.Read(pass(j).passdata, sz, btr)
                    sz += btr

                End If
            Next
        Next
        ' проверяем правильность получения данных
        Dim check As Int16
        For check = 0 To maxpass
            If pass(check).bDup = False Then
                pass(check).Cnt = 1
                For j = check + 1 To maxpass
                    If pass(check).GetHash() = pass(j).GetHash And pass(j).bDup = False Then
                        pass(check).Cnt += 1
                        pass(j).bDup = True
                    End If
                Next
            End If
        Next

        Dim maxIdx As Integer
        maxIdx = 0
        For check = 0 To maxpass

            If pass(check).Cnt >= pass(maxIdx).Cnt And pass(check).bDup = False Then
                maxIdx = check
            End If
        Next

        For i = 0 To 100
            buf(i) = pass(maxIdx).passdata(i)
        Next

    End Sub

    Private Sub ReadHourArchivTSR2(ByVal Adr As Long, ByRef buf() As Byte)
        Dim btr As Long
        Dim sz As Long = 0
        Dim i As Long

        Dim cmdbuf(100) As Byte

        cmdbuf(0) = &H31
        cmdbuf(1) = &H18
        cmdbuf(2) = Adr \ c_lng256
        cmdbuf(3) = Adr Mod c_lng256
        For i = 1 To 42
            cmdbuf(3 + i) = 32
        Next
        cmdbuf(46) = 0
        cmdbuf(47) = 0

        cmdbuf(48) = ChSum(cmdbuf, 47)

        Dim j As Long
        Dim pass(10) As DataPass
        Dim maxpass As Int16

        maxpass = 4
        For j = 0 To maxpass
            pass(j) = New DataPass
            sz = 0
            btr = 0
            MyTransport.Write(cmdbuf, 0, 49)
            RaiseIdle()
            System.Threading.Thread.Sleep(SleepTime)

            For i = 1 To 20
                RaiseIdle()
                System.Threading.Thread.Sleep(MiniSleepTime)
                btr = MyTransport.BytesToRead
                If btr > 0 Then
                    MyTransport.Read(pass(j).passdata, sz, btr)
                    sz += btr

                End If
            Next
        Next

        ' проверяем правильность получения данных
        Dim check As Int16
        For check = 0 To maxpass
            If pass(check).bDup = False Then
                pass(check).Cnt = 1
                For j = check + 1 To maxpass
                    If pass(check).GetHash() = pass(j).GetHash And pass(j).bDup = False Then
                        pass(check).Cnt += 1
                        pass(j).bDup = True
                    End If
                Next
            End If
        Next

        Dim maxIdx As Integer
        maxIdx = 0
        For check = 0 To maxpass

            If pass(check).Cnt >= pass(maxIdx).Cnt And pass(check).bDup = False Then
                maxIdx = check
            End If
        Next

        For i = 0 To 100
            buf(i) = pass(maxIdx).passdata(i)
        Next

    End Sub

End Class
