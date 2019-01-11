
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
Imports LATIR2.Utils
Imports TVMain

Public Class ClientForm
    Inherits System.Windows.Forms.Form
    Dim archType_hour As Short = 3
    Dim archType_day As Short = 4
    Dim archType_moment As Short = 1
    Dim archType_total As Short = 2
    Dim bActivated As Boolean = False
    Dim ftM As Boolean = True
    Dim ftH As Boolean = True
    Dim ftD As Boolean = True
    Dim ftT As Boolean = True
    Dim ftL As Boolean = True
    Private DeviceID As Guid
    Private SystemDT As DataTable = Nothing
    Private StopReading As Boolean

    Public localtree As Infragistics.Win.UltraWinTree.UltraTree

    Dim timesp As System.TimeSpan

    Private lastName As String
    Private Sub AppendInfo(ByVal s As String)
        lblError.Text = s & vbCrLf & lblError.Text
    End Sub

  Private Function SentRcv() As String
        Dim ut As TVMain.UniTransport
        If Not TvMain.TVD Is Nothing Then
            ut = TvMain.TVD.DriverTransport
            If Not ut Is Nothing Then
                Return "(R:" & ut.BytesReceived.ToString & " S:" & ut.BytesSent.ToString & ")"
            Else
                Return ""
            End If
        Else
            Return ""
        End If
    End Function


    Private Sub ButtonReadArch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReadArch.Click
        lblNodeName.Text = "Опрос: " + lastName
        lblError.Text = ""
        Application.DoEvents()
        timesp = New System.TimeSpan
        queryStartTime = DateTime.Now
        labelTime.Text = timesp.Minutes.ToString + ":" + timesp.Seconds.ToString()
        labelTime.Visible = True


        If chkElectro.Checked = False And chkSystem.Checked = False And CheckBoxMoment.Checked = False And CheckBoxHour.Checked = False And CheckBoxDay.Checked = False And chkTotal.Checked = False Then
            Return
        End If



        Dim DeviceID As Object

        If localtree.SelectedNodes.Count > 0 Then
            If localtree.SelectedNodes.Item(0).Key.ToString().Substring(0, 1) = "N" Then
                DeviceID = localtree.SelectedNodes.Item(0).Tag
            Else
                Exit Sub
            End If
        Else
            Exit Sub

        End If

        If TvMain.DeviceInit(DeviceID) = False Then
            TvMain.CloseTransportConnect()
            lblError.Text = "Ошибка соединения с тепловычислителем" & vbCrLf & TvMain.ConnectStatus
            Return
        End If
        TvMain.connect()
        If Not TvMain.isConnected() Then
            TvMain.CloseTransportConnect()
            lblError.Text = "Ошибка соединения с тепловычислителем" & vbCrLf & TvMain.ConnectStatus
            Return
        End If

        lblError.Text = TvMain.ConnectStatus
        StopReading = False
        cmdStop.Enabled = True
        ButtonReadArch.Enabled = False
        queryStartTime = DateTime.Now
        ReadTimer.Enabled = True


        If (chkElectro.Checked = True) Then
            Try

                If True Then ' (TvMain.LockDevice(DeviceID, 5)) Then
                    AppendInfo("Чтение данных по электричеству")
                    Application.DoEvents()
                    TvMain.ReadElectroArch()

                    If (TvMain.TVD.isElectroToDBWrite) Then
                        AppendInfo("Сохранение данных по электричеству")
                        Application.DoEvents()
                        TvMain.WriteElectroToDB()

                    End If
                    AppendInfo("Чтение данных по электричеству завершено")
                    Application.DoEvents()
                    'TvMain.UnLockDevice(DeviceID)

                    If StopReading Then GoTo Stopping
                End If
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If

        If StopReading Then GoTo Stopping

        If (CheckBoxMoment.Checked = True) Then
            Try

                If True Then ' (TvMain.LockDevice(DeviceID, 5)) Then
                    AppendInfo("Чтение мгновенного архива")
                    Application.DoEvents()
                    TvMain.readmarch()

                    If (TvMain.TVD.isMArchToDBWrite) Then
                        AppendInfo("Сохранение мгновенного архива")
                        Application.DoEvents()
                        TvMain.WritemArchToDB()

                    End If
                    AppendInfo("Чтение мгновенного архива завершено")
                    Application.DoEvents()
                    'TvMain.UnLockDevice(DeviceID)

                    If StopReading Then GoTo Stopping
                End If
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

        End If

        If StopReading Then GoTo Stopping

        If (chkTotal.Checked = True) Then
            Try

                If True Then 'If (TvMain.LockDevice(DeviceID, 5)) Then

                    AppendInfo("Чтение итогового архива")
                    Application.DoEvents()
                    Dim sss As String

                    sss = TvMain.readtarch()

                    If TvMain.TVD.isTArchToDBWrite Then
                        AppendInfo("Сохранение итогового архива")
                        Application.DoEvents()
                        TvMain.WriteTArchToDB()

                    End If
                    AppendInfo("Чтение итогового архива завершено")
                    Application.DoEvents()
                    'TvMain.UnLockDevice(DeviceID)

                    If StopReading Then GoTo Stopping
                End If

            Catch ex As Exception

                MsgBox(ex.Message)
            End Try


        End If

        If StopReading Then GoTo Stopping

        If (CheckBoxHour.Checked = True) Then

            'TvMain.ClearDBarch(DateTimePickerAfter.Value, DateTimePickerBefor.Value, archType_hour, TvMain.TVD.DeviceID.ToString)
            Dim i As Double
            Dim razn As TimeSpan
            Dim tempdate As Date
            razn = DateTimePickerBefor.Value - DateTimePickerAfter.Value
            ProgressBar1.Visible = True
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = razn.Hours + razn.Days * 24 + 1
            ProgressBar1.Value = 1
            ProgressBar1.Step = 1
            'Dim transaction As OracleClient.OracleTransaction
            AppendInfo("Чтение часовых архивов")
            Application.DoEvents()
            For i = 0 To razn.Hours + razn.Days * 24
                timesp = DateTime.Now - queryStartTime
                labelTime.Text = timesp.Minutes.ToString + ":" + timesp.Seconds.ToString

                tempdate = DateTimePickerAfter.Value
                tempdate = tempdate.AddMinutes(-tempdate.Minute)
                tempdate = tempdate.AddSeconds(-tempdate.Second)
                tempdate = tempdate.AddHours(i)

                'transaction = TvMain.dbconnect.BeginTransaction(IsolationLevel.ReadCommitted)

                Try

                    Dim str As String


                    If True Then 'If (TvMain.LockDevice(DeviceID, 5)) Then

                        AppendInfo("Читаем Часовой архив за: " + tempdate.ToString())
                        str = TvMain.readarch(archType_hour, tempdate.Year, tempdate.Month, tempdate.Day, tempdate.Hour)

                        If str.Substring(0, 6) = "Ошибка" Then
                            'transaction.Rollback()
                            'TvMain.UnLockDevice(DeviceID)
                            AppendInfo(str)
                            Application.DoEvents()
                            Continue For
                        End If

                        If TvMain.TVD.isArchToDBWrite Then
                            Dim rewrite As Boolean = False
                            Dim writeit As Boolean = False
                            Dim d1 As DateTime
                            rewrite = TvMain.CheckForArch(archType_hour, tempdate.Year, tempdate.Month, tempdate.Day, tempdate.Hour, TvMain.TVD.DeviceID)


                            If rewrite And chkQuestionOnRewrite.Checked Then

                                d1 = TvMain.GetRealDateFromBase(archType_hour, tempdate.Year, tempdate.Month, tempdate.Day, tempdate.Hour, TvMain.TVD.DeviceID)
                                If MsgBox("Часовой архив на: " + d1.ToString + " уже есть в базе." & vbCrLf & "Перезаписать ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                    writeit = True
                                Else
                                    writeit = False
                                End If

                            Else
                                writeit = True
                            End If
                            If writeit Then

                                TvMain.ClearDBarch(tempdate.AddSeconds(-1), tempdate.AddSeconds(+1), Global.TVMain.TVMain.enumArchType.H, TvMain.TVD.DeviceID)

                                TvMain.WriteArchToDB()
                            End If

                        End If

                        'TvMain.UnLockDevice(DeviceID)

                        If StopReading Then GoTo Stopping

                    End If


                    ProgressBar1.PerformStep()



                Catch ex As Exception

                    AppendInfo(ex.Message)
                    Application.DoEvents()
                    MsgBox(ex.Message)

                End Try

            Next

            If StopReading Then GoTo Stopping
            ProgressBar1.Visible = False
            AppendInfo("Чтение часовых архивов завершено")
            Application.DoEvents()
        End If
        If (CheckBoxDay.Checked = True) Then
            Dim i As Double
            Dim razn As TimeSpan
            Dim tempdate As Date
            razn = DateTimePickerBefor.Value - DateTimePickerAfter.Value
            ProgressBar1.Visible = True
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = razn.Days + 1
            ProgressBar1.Value = 1
            ProgressBar1.Step = 1
            AppendInfo("Чтение суточных архивов")
            Application.DoEvents()
            For i = 0 To razn.Days
                If StopReading Then GoTo Stopping
                timesp = DateTime.Now - queryStartTime
                labelTime.Text = timesp.Minutes.ToString + ":" + timesp.Seconds.ToString

                'transaction = TvMain.dbconnect.BeginTransaction(IsolationLevel.ReadCommitted)
                tempdate = DateTimePickerAfter.Value
                tempdate = tempdate.AddHours(-tempdate.Hour)
                tempdate = tempdate.AddMinutes(-tempdate.Minute)
                tempdate = tempdate.AddSeconds(-tempdate.Second)
                tempdate = tempdate.AddDays(i)

                Try
                    Dim str As String
                    If True Then 'If (TvMain.LockDevice(DeviceID, 5)) Then

                        AppendInfo("Читаем Суточный архив за: " + tempdate.ToString())
                        str = TvMain.readarch(archType_day, tempdate.Year, tempdate.Month, tempdate.Day, 0)
                        If str.Substring(0, 6) = "Ошибка" Then

                            'TvMain.UnLockDevice(DeviceID)
                            AppendInfo(str)
                            Application.DoEvents()
                            Continue For
                        End If
                        If TvMain.TVD.isArchToDBWrite Then
                            Dim rewrite As Boolean = False
                            Dim writeit As Boolean = False
                            Dim d1 As DateTime

                            rewrite = TvMain.CheckForArch(archType_day, tempdate.Year, tempdate.Month, tempdate.Day, 0, TvMain.TVD.DeviceID)

                            If rewrite And chkQuestionOnRewrite.Checked Then
                                d1 = TvMain.GetRealDateFromBase(archType_day, tempdate.Year, tempdate.Month, tempdate.Day, 0, TvMain.TVD.DeviceID)
                                If MsgBox("Суточный архив на: " + d1.ToString() + " уже есть в базе." & vbCrLf & "Перезаписать ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                    writeit = True
                                Else
                                    writeit = False
                                End If
                            Else
                                writeit = True
                            End If

                            If writeit Then

                                TvMain.ClearDBarch(tempdate.AddSeconds(-1), tempdate.AddSeconds(+1), Global.TVMain.TVMain.enumArchType.D, TvMain.TVD.DeviceID)

                                TvMain.WriteArchToDB()
                            End If

                        End If


                        'TvMain.UnLockDevice(DeviceID)

                        If StopReading Then GoTo Stopping
                    End If
                    'transaction.Commit()
                    ProgressBar1.PerformStep()

                Catch ex As Exception

                    AppendInfo(ex.Message)
                    Application.DoEvents()
                    MsgBox(ex.Message)
                End Try
            Next
            ProgressBar1.Visible = False
            AppendInfo("Чтение суточных архивов завершено")
            Application.DoEvents()

        End If



        If chkSystem.Checked = True Then
            Dim dtsys As DataTable = Nothing
           
            dtsys = TvMain.ReadSystemParameters
            If Not dtsys Is Nothing Then
                DataGridSystem.DataSource = Nothing
                Application.DoEvents()
                DataGridSystem.DataSource = dtsys
                'TvMain.SaveLog(Tag, 0, "??", 1, "Читаем системные параметры")
                'TvMain.UnLockDevice(Tag)
            Else
                DataGridSystem.DataSource = Nothing
                'TvMain.SaveLog(Tag, 0, "??", 1, "Ошибка чтения системных параметров")
                'TvMain.UnLockDevice(Tag)
            End If


        End If
Stopping:

        If StopReading Then
            ProgressBar1.Visible = False
            AppendInfo("Чтение данных прервано")
            Application.DoEvents()
        End If

        TvMain.CloseTransportConnect()
        cmdStop.Enabled = False
        RefreshData(localtree)
        ButtonReadArch.Enabled = True
        ReadTimer.Enabled = False
    End Sub

    Private Sub ButtonExportMoment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportMoment.Click
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            expExcel.Export(DataGridMoment, SaveFileDialog1.FileName)
        End If

    End Sub


    Private Sub ButtonExportHour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportHour.Click
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            expExcel.Export(DataGridHour, SaveFileDialog1.FileName)
        End If

    End Sub

    Private Sub ButtonExportDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportDay.Click

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            expExcel.Export(DataGridDay, SaveFileDialog1.FileName)
        End If
    End Sub


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        RefreshData(localtree, False)


    End Sub


    Private Sub DataGridMoment_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub ButtonExportTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportTotal.Click
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            expExcel.Export(DataGridTotal, SaveFileDialog1.FileName)
        End If

    End Sub

    Private Sub RefreshDatabyID(ByVal tag As Guid, ByVal GCaption As String)
        Dim dTo As Date
        Dim dfrom As Date
        dTo = Date.Now
        Dim edt As DataTable
        edt = New DataTable
        LastName = GCaption

        Select Case (TabControl1.SelectedTab.Text)
            Case "Мгновенный"
                If optMoment.CheckedItem.DataValue = 0 Then
                    dfrom = DateTimePickerAfter.Value
                    dTo = DateTimePickerBefor.Value
                Else
                    dfrom = dTo.AddDays(-optMoment.CheckedItem.DataValue)
                End If
                DataGridMoment.DataSource = edt
                DataGridMoment.DataSource = GetTVData(tag, dfrom, dTo, archType_moment)
                Utils.SetupGrid(DataGridMoment, tag, archType_moment)
                DataGridMoment.Text = GCaption
            Case "Часовой"

                If optHour.CheckedItem.DataValue = 0 Then
                    dfrom = DateTimePickerAfter.Value
                    dTo = DateTimePickerBefor.Value
                Else
                    dfrom = dTo.AddDays(-optHour.CheckedItem.DataValue)
                End If
                DataGridHour.DataSource = edt
                DataGridHour.DataSource = GetTVData(tag, dfrom, dTo, archType_hour)
                Utils.SetupGrid(DataGridHour, tag, archType_hour)
                DataGridHour.Text = GCaption

            Case "Суточный"
                If optDay.CheckedItem.DataValue = 0 Then
                    dfrom = DateTimePickerAfter.Value
                    dTo = DateTimePickerBefor.Value
                Else
                    dfrom = dTo.AddDays(-optDay.CheckedItem.DataValue)
                End If
                DataGridDay.DataSource = edt
                DataGridDay.DataSource = GetTVData(tag, dfrom, dTo, archType_day)
                DataGridDay.Text = GCaption
                Utils.SetupGrid(DataGridDay, tag, archType_day)

            Case "Итоговые"
                DataGridTotal.Text = GCaption

                If optTotal.CheckedItem.DataValue = 0 Then
                    dfrom = DateTimePickerAfter.Value
                    dTo = DateTimePickerBefor.Value
                Else
                    dfrom = dTo.AddDays(-optTotal.CheckedItem.DataValue)
                End If
                DataGridTotal.DataSource = edt
                DataGridTotal.DataSource = GetTVData(tag, dfrom, dTo, archType_total)
                Utils.SetupGrid(DataGridTotal, tag, archType_total)

            Case "Пропущенные архивы"
                DataGridMissing.DataSource = GetmissingData(tag)
                DataGridMissing.Text = GCaption
                DataGridMissing.Tag = tag

                With DataGridMissing.DisplayLayout.Bands(0).Columns(0)
                    .Width = 300
                End With

                With DataGridMissing.DisplayLayout.Bands(0).Columns(1)
                    .Width = 300
                    .Style = ColumnStyle.Time
                    .Format = "dd.MM.yyyy HH:mm:ss"
                    .FormatInfo = System.Globalization.CultureInfo.CreateSpecificCulture("ru")
                    .CellAppearance.TextHAlign = HAlign.Right
                    .CellAppearance.TextVAlign = VAlign.Middle
                    .CellActivation = Activation.ActivateOnly
                End With
        End Select
    End Sub

    Private Function getMissingCmd(id As Guid) As String
        Dim cmd As String

        cmd = "select tplc_missing_atype as ""Тип"", tplc_missing_Adate as ""Дата"" from v_autotplc_missing where tplc_missing_Adate >= now()-40 and instanceid='" & GUID2String(id) & "'"
        Return cmd

    End Function

    Private Function GetmissingData(ByVal id_bd As Guid) As DataTable
        Dim dt As DataTable
        Dim cmd As String
        cmd = getMissingCmd(id_bd)
        dt = TvMain.TheSession.GetData(cmd)
        Return dt
    End Function

    Public Sub RefreshData(ByVal tree As Infragistics.Win.UltraWinTree.UltraTree, Optional ByVal Full As Boolean = True)
        localtree = tree
        Dim tag As Object
        If tree Is Nothing Then Exit Sub

        If Not bActivated Then Exit Sub
        If tree.SelectedNodes.Count > 0 Then
            If tree.SelectedNodes.Item(0).Key.ToString().Substring(0, 1) = "N" Then
                tag = tree.SelectedNodes.Item(0).Tag
            Else
                Exit Sub
            End If
        Else
            Exit Sub

        End If

        If Full Then
            SystemDT = Nothing
        End If

        RefreshDatabyID(New Guid(tag.ToString), tree.SelectedNodes.Item(0).Text)
    End Sub

    Private Sub DateTimePickerAfter_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerAfter.ValueChanged
        'RefreshData()
    End Sub

    Private Sub DateTimePickerBefor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerBefor.ValueChanged
        'RefreshData()
    End Sub

    'Private Sub SetupGrid(ByVal ug1 As UltraWinGrid.UltraGrid)
    '    Dim i As Int32, s1 As String = ""

    '    Dim column As UltraWinGrid.UltraGridColumn

    '    ug1.DisplayLayout.CaptionVisible = DefaultableBoolean.False
    '    ug1.DisplayLayout.ColumnChooserEnabled = DefaultableBoolean.False
    '    ug1.DisplayLayout.GroupByBox.Hidden = True
    '    ug1.DisplayLayout.AddNewBox.Hidden = True
    '    ug1.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True
    '    ug1.DisplayLayout.UseFixedHeaders = False

    '    Dim info As RowLayoutColumnInfo

    '    ug1.DisplayLayout.Scrollbars = Scrollbars.Automatic


    '    ug1.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.WithinGroup
    '    ug1.DisplayLayout.Override.AllowColMoving = AllowColMoving.WithinGroup

    '    ug1.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid
    '    ug1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
    '    ug1.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Solid


    '    ug1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti


    '    ug1.DisplayLayout.Bands(0).Columns(0).CellActivation = Activation.ActivateOnly
    '    ug1.DisplayLayout.Bands(0).Columns(0).Header.Fixed = True
    '    ug1.DisplayLayout.Bands(0).Columns(0).CellMultiLine = DefaultableBoolean.True


    '    Dim dt As DataTable
    '    Dim HideMarker As Boolean = False
    '    dt = ug1.DataSource
    '    For i = 1 To dt.Columns.Count - 1
    '        column = ug1.DisplayLayout.Bands(0).Columns(i)


    '        'If dt.Columns.Item(i).ColumnName = "ID" Then
    '        '    HideMarker = True
    '        'End If
    '        'If HideMarker Then
    '        '    ug1.DisplayLayout.Bands(0).Columns(i).Hidden = True
    '        '    'ug1.DisplayLayout.Rows(0).Cells(i).Hidden = True
    '        'End If
    '        info = ug1.DisplayLayout.Bands(0).Columns(i).RowLayoutColumnInfo

    '        'If dt.Rows.Count > 0 Then
    '        Try
    '            If dt.Columns.Item(i).ColumnName.Substring(0, 4) = "Дата" Then
    '                column.Style = ColumnStyle.DateTime
    '            End If
    '        Catch
    '        End Try
    '        'End If
    '        'ug1.DisplayLayout.Rows(0).Cells(i).Style = ColumnStyle.CheckBox
    '        'ug1.DisplayLayout.Rows(0).Cells(6 + (i - 1) * 3).Hidden = True
    '        'ug1.DisplayLayout.Rows(0).Cells(7 + (i - 1) * 3).Hidden = True




    '        column = info.Column
    '        'column.Format = "##,###,####.00"
    '        'column.MaxValue = 100
    '        column.CellAppearance.TextHAlign = HAlign.Right
    '        column.CellAppearance.TextVAlign = VAlign.Middle


    '    Next



    'End Sub





    Private Sub SetupMoment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetupMoment.Click
        'DataGridMoment.ShowColumnChooser()

        'Dim lpath As String
        'Try
        '    lpath = GetSetting("MTZ", "CONFIG", "LAYOUTS", My.Application.Info.DirectoryPath & "\Layouts\")

        '    DataGridMoment.DisplayLayout.Save(lpath & "\" & "Moment" & ".ugl")
        'Catch
        'End Try



        Dim tag As Object
        If localtree Is Nothing Then Exit Sub
        If localtree.SelectedNodes.Count > 0 Then
            If localtree.SelectedNodes.Item(0).Key.ToString().Substring(0, 1) = "N" Then
                tag = localtree.SelectedNodes.Item(0).Tag
            Else
                Exit Sub
            End If
        Else
            Exit Sub

        End If
        'Dim f As frmSetupGrid
        'f = New frmSetupGrid
        'f.grid = DataGridMoment
        'f.id_bd = tag
        'f.ptype = archType_moment
        'f.LoadData()

        'If f.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    RefreshData(localtree)
        'End If
    End Sub

    Private Sub MomentPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MomentPrint.Click
        DataGridMoment.Text = "Моментальные архивы"
        DataGridMoment.PrintPreview()
    End Sub

    Private Sub DataGridMoment_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DataGridMoment.InitializeLayout
        'If ftM Then
        '    SetupGrid(DataGridMoment)
        '    Dim lpath As String
        '    Try
        '        lpath = GetSetting("MTZ", "CONFIG", "LAYOUTS", My.Application.Info.DirectoryPath & "\Layouts\")
        '        DataGridMoment.DisplayLayout.Load(lpath & "\" & "Moment" & ".ugl")
        '    Catch
        '    End Try
        '    ftM = False
        'End If
    End Sub
    Private Sub DataGridHour_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DataGridHour.InitializeLayout
        'If ftH Then
        '    SetupGrid(DataGridHour)
        '    Dim lpath As String
        '    Try
        '        lpath = GetSetting("MTZ", "CONFIG", "LAYOUTS", My.Application.Info.DirectoryPath & "\Layouts\")
        '        DataGridHour.DisplayLayout.Load(lpath & "\" & "Hour" & ".ugl")
        '    Catch
        '    End Try
        '    ftH = False
        'End If
    End Sub

    Private Sub DataGridDay_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DataGridDay.InitializeLayout
        'If ftD Then
        '    SetupGrid(DataGridDay)
        '    Dim lpath As String
        '    Try
        '        lpath = GetSetting("MTZ", "CONFIG", "LAYOUTS", My.Application.Info.DirectoryPath & "\Layouts\")
        '        DataGridDay.DisplayLayout.Load(lpath & "\" & "Day" & ".ugl")
        '    Catch
        '    End Try
        '    ftD = False
        'End If
    End Sub

    Private Sub DataGridTotal_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DataGridTotal.InitializeLayout
        'If ftT Then
        '    SetupGrid(DataGridTotal)
        '    Dim lpath As String
        '    Try
        '        lpath = GetSetting("MTZ", "CONFIG", "LAYOUTS", My.Application.Info.DirectoryPath & "\Layouts\")
        '        DataGridTotal.DisplayLayout.Load(lpath & "\" & "Total" & ".ugl")
        '    Catch
        '    End Try
        '    ftT = False
        'End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DataGridHour.Text = "Часовые архивы"
        DataGridHour.PrintPreview()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        DataGridDay.Text = "Суточные архивы"
        DataGridDay.PrintPreview()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        DataGridTotal.Text = "Итоговые архивы"
        DataGridTotal.PrintPreview()
    End Sub

    Private Sub cmdHourSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHourSetup.Click
        'DataGridHour.ShowColumnChooser()

        'Dim lpath As String
        'Try
        '    lpath = GetSetting("MTZ", "CONFIG", "LAYOUTS", My.Application.Info.DirectoryPath & "\Layouts\")

        '    DataGridHour.DisplayLayout.Save(lpath & "\" & "Hour" & ".ugl")
        'Catch
        'End Try
        Dim tag As Object
        If localtree Is Nothing Then Exit Sub
        If localtree.SelectedNodes.Count > 0 Then
            If localtree.SelectedNodes.Item(0).Key.ToString().Substring(0, 1) = "N" Then
                tag = localtree.SelectedNodes.Item(0).Tag
            Else
                Exit Sub
            End If
        Else
            Exit Sub

        End If
        'Dim f As frmSetupGrid
        'f = New frmSetupGrid
        'f.Grid = DataGridHour
        'f.id_bd = tag
        'f.ptype = archType_hour
        'f.LoadData()
        'If f.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    RefreshData(localtree)
        'End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDaySetup.Click
        'DataGridDay.ShowColumnChooser()

        'Dim lpath As String
        'Try
        '    lpath = GetSetting("MTZ", "CONFIG", "LAYOUTS", My.Application.Info.DirectoryPath & "\Layouts\")

        '    DataGridDay.DisplayLayout.Save(lpath & "\" & "Day" & ".ugl")
        'Catch
        'End Try
        Dim tag As Object
        If localtree Is Nothing Then Exit Sub
        If localtree.SelectedNodes.Count > 0 Then
            If localtree.SelectedNodes.Item(0).Key.ToString().Substring(0, 1) = "N" Then
                tag = localtree.SelectedNodes.Item(0).Tag
            Else
                Exit Sub
            End If
        Else
            Exit Sub

        End If
        'Dim f As frmSetupGrid
        'f = New frmSetupGrid
        'f.Grid = DataGridDay
        'f.id_bd = tag
        'f.ptype = archType_day
        'f.LoadData()
        'If f.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    RefreshData(localtree)
        'End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTotalSetup.Click
        'DataGridTotal.ShowColumnChooser()

        'Dim lpath As String
        'Try
        '    lpath = GetSetting("MTZ", "CONFIG", "LAYOUTS", My.Application.Info.DirectoryPath & "\Layouts\")

        '    DataGridTotal.DisplayLayout.Save(lpath & "\" & "Total" & ".ugl")
        'Catch
        'End Try
        Dim tag As Object
        If localtree Is Nothing Then Exit Sub
        If localtree.SelectedNodes.Count > 0 Then
            If localtree.SelectedNodes.Item(0).Key.ToString().Substring(0, 1) = "N" Then
                tag = localtree.SelectedNodes.Item(0).Tag
            Else
                Exit Sub
            End If
        Else
            Exit Sub

        End If
        'Dim f As frmSetupGrid
        'f = New frmSetupGrid
        'f.Grid = DataGridTotal
        'f.id_bd = tag
        'f.ptype = archType_total
        'f.LoadData()
        'If f.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    RefreshData(localtree)
        'End If
    End Sub

    Private Sub CheckBoxHour_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxHour.CheckedChanged

    End Sub





    Private Function GetTVData(ByVal instanceid As Guid, ByVal dfrom As Date, ByVal dto As Date, ByVal id_ptype As Integer) As DataTable
        Dim dt As DataTable
        Dim id As Guid
        Dim tt As TPLT.TPLT.Application
        tt = MyManager.GetInstanceObject(instanceid)

        dt = Session.GetData("select * from v_autoTPLC_HEADER where TPLC_HEADER_id_bd_id='" + Session.GetProvider().ID2Param(tt.TPLT_BDEVICES.Item(1).ID) + "'")

        If dt.Rows.Count = 0 Then
            ' создем новый объект  для устройства
            id = Guid.NewGuid
            MyManager.NewInstance(id, "TPLC", "Данные")
            Dim tvd As TPLC.TPLC.Application

            tvd = MyManager.GetInstanceObject(id)
            With CType(tvd.TPLC_HEADER.Add, TPLC.TPLC.TPLC_HEADER)
                .ID_BD = tt.TPLT_BDEVICES.Item(1)
                .Save()
            End With
        Else
            id = New Guid(dt.Rows(0)("instanceid").ToString)
        End If
        'DeviceID = id

        If id_ptype = archType_moment Then
            dt = Session.GetData("select DCALL,DCOUNTER,Q1,Q2,T1,T2,DT12,T3,T4,T5,DT45,T6,V1,V2,DV12,V3,V4,V5,DV45,V6,M1,M2,DM12,M3,M4,M5,DM45,M6 " + _
           ",P1,P2,P3,P4,P5,P6,G1,G2,G3,G4,G5,G6,TSUM1,TSUM2,Q1H,Q2H,V1H,V2H,V4H,V5H,Q3,Q4,Q5,DQ12,DQ45,HC,HC_1,HC_2,HC_CODE from TPLC_M where DCOUNTER>=" + Session.GetProvider.Date2Const(dfrom) + " and DCOUNTER<=" + Session.GetProvider.Date2Const(dto) + " and instanceid=" + GUID2String(Session, id) + "")
        End If

        If id_ptype = archType_hour Then
            dt = Session.GetData("select DCALL,DCOUNTER,Q1,Q2,T1,T2,DT12,T3,T4,T5,DT45,T6,V1,V2,DV12,V3,V4,V5,DV45,V6,M1,M2,DM12,M3,M4,M5,DM45,M6 " + _
           ",P1,P2,P3,P4,P5,P6,G1,G2,G3,G4,G5,G6,TSUM1,TSUM2,Q1H,Q2H,V1H,V2H,V4H,V5H,Q3,Q4,Q5,DQ12,DQ45,HC,HC_1,HC_2,HC_CODE from TPLC_H where DCOUNTER>=" + Session.GetProvider.Date2Const(dfrom) + " and DCOUNTER<=" + Session.GetProvider.Date2Const(dto) + " and instanceid=" + GUID2String(Session, id) + "")
        End If
        If id_ptype = archType_day Then
            dt = Session.GetData("select DCALL,DCOUNTER,Q1,Q2,T1,T2,DT12,T3,T4,T5,DT45,T6,V1,V2,DV12,V3,V4,V5,DV45,V6,M1,M2,DM12,M3,M4,M5,DM45,M6 " + _
          ",P1,P2,P3,P4,P5,P6,G1,G2,G3,G4,G5,G6,TSUM1,TSUM2,Q1H,Q2H,V1H,V2H,V4H,V5H,Q3,Q4,Q5,DQ12,DQ45,HC,HC_1,HC_2,HC_CODE from TPLC_D where DCOUNTER>=" + Session.GetProvider.Date2Const(dfrom) + " and DCOUNTER<=" + Session.GetProvider.Date2Const(dto) + " and instanceid=" + GUID2String(Session, id) + "")
        End If
        If id_ptype = archType_total Then
            dt = Session.GetData("select DCALL,DCOUNTER,Q1,Q2,T1,T2,DT12,T3,T4,T5,DT45,T6,V1,V2,DV12,V3,V4,V5,DV45,V6,M1,M2,DM12,M3,M4,M5,DM45,M6 " + _
          ",P1,P2,P3,P4,P5,P6,G1,G2,G3,G4,G5,G6,TSUM1,TSUM2,Q1H,Q2H,V1H,V2H,V4H,V5H,Q3,Q4,Q5,DQ12,DQ45,HC,HC_1,HC_2,HC_CODE from TPLC_T where DCOUNTER>=" + Session.GetProvider.Date2Const(dfrom) + " and DCOUNTER<=" + Session.GetProvider.Date2Const(dto) + " and instanceid=" + GUID2String(Session, id) + "")
        End If

        Return dt
    End Function









    Private Sub optMoment_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMoment.ValueChanged
        RefreshData(localtree, False)
    End Sub

    Private Sub optHour_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optHour.ValueChanged
        RefreshData(localtree, False)
    End Sub

    Private Sub optDay_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDay.ValueChanged
        RefreshData(localtree, False)
    End Sub

    Private Sub optTotal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTotal.ValueChanged
        RefreshData(localtree, False)
    End Sub

    Private Sub ClientForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        bActivated = True
        RefreshData(localtree, False)

    End Sub

    Private Sub ClientForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        bActivated = False
        CType(MdiParent, frmMain).MyfrmManual = Nothing
    End Sub

    'Private Sub cmdRefreshLost_Click(sender As System.Object, e As System.EventArgs) Handles cmdRefreshLost.Click
    '    Dim an As LostAnalizer = New LostAnalizer
    '    an.tvmain = TvMain
    '    an.id_bd = DataGridMissing.Tag
    '    an.NodeName = DataGridMissing.Text
    '    an.AnalizeLost()
    '    an = Nothing
    '    RefreshDatabyID(DataGridMissing.Tag, DataGridMissing.Text)
    'End Sub
 

    Private Sub ReadTimer_Tick(sender As Object, e As System.EventArgs) Handles ReadTimer.Tick
        timesp = New System.TimeSpan
        timesp = DateTime.Now - queryStartTime
        ReadTimer.Interval = 100
        labelTime.Text = Format(timesp.Minutes, "00") + ":" + Format(timesp.Seconds, "00")
        Select Case LastAction
            Case UnitransportAction.Connected
                lblError.Text = "Соединение установлено" + vbCrLf + lblError.Text
                lblActiopn.Text = "Соединение установлено " & SentRcv()
                lblRcv.BackColor = Color.Green
                lblSnd.BackColor = Color.Green
            Case UnitransportAction.Connecting
                lblActiopn.Text = "Соединяемся " & SentRcv()
                lblRcv.BackColor = Color.LightGray
                lblSnd.BackColor = Color.LightGray
            Case UnitransportAction.Destroy
                lblActiopn.Text = "Транспорт удален " & SentRcv()
            Case UnitransportAction.Disconnected
                lblActiopn.Text = "Отключен " & SentRcv()
                lblRcv.BackColor = Color.LightGray
                lblSnd.BackColor = Color.LightGray
            Case UnitransportAction.Disconnecting
                lblActiopn.Text = "Отключение " & SentRcv()
                lblRcv.BackColor = Color.LightGray
                lblSnd.BackColor = Color.LightGray
            Case UnitransportAction.ReceiveData
                lblActiopn.Text = "Получены данные " & SentRcv()
                lblRcv.BackColor = Color.Green
                lblSnd.BackColor = Color.Green
                lblRcv.BackColor = Color.Red
            Case UnitransportAction.SendData
                lblActiopn.Text = "Отосланы данные " & SentRcv()
                lblRcv.BackColor = Color.Green
                lblSnd.BackColor = Color.Green
                lblSnd.BackColor = Color.Red
            Case UnitransportAction.SettingUp
                lblActiopn.Text = "Настроен " & SentRcv()
                lblRcv.BackColor = Color.LightGray
                lblSnd.BackColor = Color.LightGray
            Case UnitransportAction.Wait
                lblActiopn.Text = "Ожидание " & SentRcv()
                lblRcv.BackColor = Color.Green
                lblSnd.BackColor = Color.Green
            Case UnitransportAction.LowLevelStop
                lblError.Text = "Ошибка связи." + LastMSG + vbCrLf + lblError.Text
                lblActiopn.Text = "Ошибка связи." + LastMSG
                lblRcv.BackColor = Color.LightGray
                lblSnd.BackColor = Color.LightGray
        End Select
        LastAction = UnitransportAction.NoAction
        Application.DoEvents()

    End Sub
    Private Sub DataGridMissing_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles DataGridMissing.DoubleClickCell
        Dim row As UltraGridRow
        row = e.Cell.Row
        Dim dat As DateTime
        Dim name As String
        name = row.Cells(0).Value
        dat = row.Cells(1).Value

        If InStr(name, "Часовой") > 0 Then
            DateTimePickerAfter.Value = dat.AddHours(-1)
            DateTimePickerBefor.Value = dat.AddHours(1)
            CheckBoxHour.Checked = True
            CheckBoxMoment.Checked = False
            CheckBoxDay.Checked = False
            chkTotal.Checked = False
        End If

        If InStr(name, "Суточный") > 0 Then
            DateTimePickerAfter.Value = dat.AddDays(-1)
            DateTimePickerBefor.Value = dat.AddDays(1)
            CheckBoxHour.Checked = False
            CheckBoxMoment.Checked = False
            CheckBoxDay.Checked = True
            chkTotal.Checked = False
        End If

    End Sub

    Private Sub cmdStop_Click(sender As System.Object, e As System.EventArgs) Handles cmdStop.Click
        StopReading = True
    End Sub
End Class
