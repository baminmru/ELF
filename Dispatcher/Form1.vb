Option Strict Off
Option Explicit On
Friend Class Form1
    Inherits System.Windows.Forms.Form
    Public DEVID As Guid
    Public Sb, Br, Db, Pt As Object
    Public Fc As Short
    Public RBUF As String
    Public Bcnt As Short
    Public ArchType_hour As Short = 3
    Public ArchType_day As Short = 4



    Private TvMain As TVMain.TVMain

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ComboBoxArchType.Items.Add("Часовой")
        ComboBoxArchType.Items.Add("Суточный")
        TvMain = New TVMain.TVMain
        Dim ret As Boolean
        ret = TvMain.Init(MyManager, SrvID)
        If ret = False Then
            Application.Exit()

        End If
        'MsgBox(TvMain.CounterName)
        TvMain.DeviceInit(DEVID)
        Me.Text = "Тест соединения с устройством ID=" + DEVID.ToString()

        TextBoxArchYear.Text = Date.Today.Year.ToString()
        TextBoxArchMonth.Text = Date.Today.Month.ToString()
        TextBoxAcrhDay.Text = Date.Today.Day.ToString()
        If TvMain.isConnected Then
            Text3.Text = TvMain.ConnectStatus
            Text3.Text += vbCrLf & "Соединение установлено"
            Timer1.Start()
        Else
            Text3.Text = TvMain.ConnectStatus
        End If




    End Sub

    Private Sub Form1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TvMain.CloseTransportConnect()
        'TvMain.CloseDBConnection()
    End Sub

    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        Static retstr As String
        retstr = TvMain.bufcheck()
        If (retstr <> "") Then
            Text3.Text = Text3.Text + retstr
        End If
    End Sub

    Private Sub ButtonConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConnect.Click
        Try

            TvMain.connect()
        Catch exc As Exception
        End Try
        If TvMain.isConnected Then
            Text3.Text = Text3.Text + vbCrLf + "Соединение установлено"
        Else
            Text3.Text = Text3.Text + vbCrLf + "Не удалось установить соединение"
        End If
    End Sub


   

    'Private Sub ButtonReadFlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReadFlash.Click
    '    If TvMain.isConnected Then
    '        Try
    '            TvMain.readflash(Int(TextBoxFirstPageNumber.Text), Int(TextBoxReadPageCount.Text))
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
    '        End Try
    '    Else
    '        Text3.Text += vbCrLf + "Соединение с устройством не установлено"
    '    End If

    'End Sub

    'Private Sub ButtonMemoryRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMemoryRead.Click

    '    If TvMain.isConnected Then
    '        Try
    '            TvMain.readRAM(Int(TextBoxFirstElem.Text), Int(TextBoxElemCount.Text))
    '        Catch ex As Exception
    '            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
    '        End Try
    '    Else
    '        Text3.Text += vbCrLf + "Соединение с устройством не установлено"
    '    End If
    'End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        Text3.Text = ""
    End Sub

  

    Private Sub ButtonReadArch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReadArch.Click
       


        If TvMain.isConnected Then
            Try
                Dim archtype As Short


                If (ComboBoxArchType.Text = "") Then
                    MsgBox("Задайте тип архива")
                    Exit Sub
                End If
                If (ComboBoxArchType.Text = "Часовой") Then
                    archtype = ArchType_hour
                End If

                If (ComboBoxArchType.Text = "Суточный") Then
                    archtype = ArchType_day
                End If


                Text3.Text = Text3.Text + TvMain.readarch(archtype, Int(TextBoxArchYear.Text), Int(TextBoxArchMonth.Text), _
                Int(TextBoxAcrhDay.Text), Int(TextBoxAcrhHour.Text))
                Text3.Text = Text3.Text & vbCrLf
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            End Try
        Else
            Text3.Text += vbCrLf + "Соединение с устройством не установлено"
        End If
    End Sub

 
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TvMain.isConnected Then
            Try
                Text3.Text = Text3.Text + TvMain.readmarch()
                Text3.Text = Text3.Text & vbCrLf
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            End Try
        Else
            Text3.Text += vbCrLf + "Соединение с устройством не установлено"
        End If
       
    End Sub

   

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        

        If TvMain.isConnected Then
            Try
                Dim archtype As Short
                archtype = ArchType_hour
                Dim i As Integer
                For i = 0 To 23
                    Text3.Text = Text3.Text & vbCrLf & i.ToString & _
                    TvMain.readarch(archtype, Int(TextBoxArchYear.Text), Int(TextBoxArchMonth.Text), _
                               Int(TextBoxAcrhDay.Text), i)
                 
                    Application.DoEvents()

                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            End Try
        Else
            Text3.Text += vbCrLf + "Соединение с устройством не установлено"
        End If


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
    

        If TvMain.isConnected Then
            Try
                Dim archtype As Short
                archtype = ArchType_day
                Dim i As Integer
                For i = 1 To 31
                    Text3.Text = Text3.Text & vbCrLf & i.ToString & _
                    TvMain.readarch(archtype, Int(TextBoxArchYear.Text), Int(TextBoxArchMonth.Text), _
                               i, 0)
                  
                    Application.DoEvents()

                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            End Try
        Else
            Text3.Text += vbCrLf + "Соединение с устройством не установлено"
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
      
        If TvMain.isConnected Then
            Try
                Text3.Text = Text3.Text + TvMain.readtarch()
                Text3.Text = Text3.Text + TvMain.TVD.WriteTArchToDB()
                Text3.Text = Text3.Text & vbCrLf
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            End Try
        Else
            Text3.Text += vbCrLf + "Соединение с устройством не установлено"
        End If
    End Sub

    
  

    Private Sub cmdNPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNPort.Click
        If Not TvMain.TVD Is Nothing Then

            If TvMain.TVD.OpenPort() Then
                Text3.Text += vbCrLf + "Канальное соединение установлено"
                If TvMain.TVD.Connect Then
                    Text3.Text += vbCrLf + "Соединение с тепловычислителем установлено"
                Else
                    Text3.Text += vbCrLf + "Ошибка открытия тепловычислителя"
                End If
            Else
                Text3.Text += vbCrLf + "Ошибка открытия канала"
            End If
        Else
            Text3.Text += vbCrLf + "Драйвер не инициализирован"
        End If
    End Sub
End Class