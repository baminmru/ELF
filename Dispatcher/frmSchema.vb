Imports LATIR2.Utils

Public Class frmSchema
    Public id As Guid
    Dim fname As String
    Dim LastShowD As Date
    Dim ds_id As Guid
    Dim EditParam As Boolean = False
    Dim ptype As Integer = 1
    Dim bActivated As Boolean = False
    Dim tt As TPLT.TPLT.Application
    Dim ts As TPLS.TPLS.Application
    Dim tc As TPLC.TPLC.Application



    Public Sub LoadData(ByVal newID As Guid)

        If Not bActivated Then Exit Sub
        If newID.Equals(Guid.Empty) Then Exit Sub
        id = newID
        Try
            If fname <> "" Then
                Kill(fname)
            End If
        Catch ex As Exception

        End Try

        fname = ""
        Dim dt As DataTable

        tt = MyManager.GetInstanceObject(id)
        If tt Is Nothing Then Exit Sub

        ts = tt.TPLT_BDEVICES.Item(1).THESCHEMA.Application

        ds_id = tt.TPLT_BDEVICES.Item(1).THESCHEMA.ID

        dt = Session.GetData("select instanceid from v_autoTPLC_HEADER where id='" & tt.TPLT_BDEVICES.Item(1).ID.ToString() & "'")
        tc = Nothing
        If dt.Rows.Count > 0 Then
            tc = MyManager.GetInstanceObject(dt.Rows(0)("instanceid"))
        End If


        If ds_id.Equals(Guid.Empty) Then
            fname = System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location()) + "\schema\no.bmp"
            picSchema.Load(fname)
            fname = ""
        Else
            fname = System.IO.Path.GetDirectoryName(Me.GetType().Assembly.Location()) + "\schema\" & Guid.NewGuid.ToString() & ".bmp"

            Module1.Session.GetProvider().SaveFileFromField(Module1.Session.Connection, fname, "TPLS_INFO", "schema_image", ds_id)
            Try
                picSchema.Load(fname)
            Catch ex As Exception

            End Try

        End If

        picSchema.Controls.Clear()

        If fname <> "" Then

            Dim lbl As Label
            Dim chk As CheckBox
            Dim txt As TextBox

            Dim i As Integer
            Dim lblToolTipInfo As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo

            For i = 1 To ts.TPLS_PARAM.Count
                With ts.TPLS_PARAM.Item(i)
                    If .HIDEPARAM = TPLS.TPLS.enumBoolean.Boolean_Net Then
                        If CType(.ArchType, TPLD.TPLD.TPLD_PARAMTYPE).TheCode = ptype.ToString() Then
                            If CType(.Param, TPLD.TPLD.TPLD_PARAM).ShowAs = TPLD.TPLD.enumColumnSortType.ColumnSortType_As_Numeric Then
                                If EditParam Then
                                    txt = New TextBox
                                    txt.BorderStyle = BorderStyle.FixedSingle
                                    txt.Left = .POS_LEFT
                                    txt.Top = .POS_TOP
                                    txt.Height = 22
                                    txt.Width = 50
                                    txt.Text = ""
                                    txt.Tag = CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField + "_max"
                                    txt.ForeColor = Color.Red
                                    txt.BackColor = Color.White
                                    lblToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo(CType(.Param, TPLD.TPLD.TPLD_PARAM).Name, Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
                                    lblToolTipInfo.ToolTipText = "Максимум " & CType(.Param, TPLD.TPLD.TPLD_PARAM).Name
                                    picSchema.Controls.Add(txt)
                                    Me.UltraToolTipManager1.SetUltraToolTip(txt, lblToolTipInfo)
                                    txt.Show()


                                    chk = New CheckBox
                                    chk.Left = .POS_LEFT + 51
                                    chk.Top = .POS_TOP
                                    chk.Height = 20
                                    chk.Width = 20
                                    chk.Text = ""
                                    chk.Tag = "chk_" + CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField + "_max"
                                    chk.BackColor = Color.White
                                    lblToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo(CType(.Param, TPLD.TPLD.TPLD_PARAM).Name, Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
                                    lblToolTipInfo.ToolTipText = "Проверять максимум для " & CType(.Param, TPLD.TPLD.TPLD_PARAM).Name
                                    picSchema.Controls.Add(chk)
                                    Me.UltraToolTipManager1.SetUltraToolTip(chk, lblToolTipInfo)
                                    chk.Show()

                                Else


                                    lbl = New Label
                                    lbl.BorderStyle = BorderStyle.FixedSingle
                                    lbl.Left = .POS_LEFT
                                    lbl.Top = .POS_TOP
                                    lbl.Height = 22
                                    lbl.Width = 50
                                    lbl.Text = ""
                                    lbl.Tag = CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField + "_max"
                                    lbl.ForeColor = Color.Red
                                    lbl.BackColor = Color.White
                                    lblToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo(CType(.Param, TPLD.TPLD.TPLD_PARAM).Name, Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
                                    lblToolTipInfo.ToolTipText = "Максимум " & CType(.Param, TPLD.TPLD.TPLD_PARAM).Name
                                    picSchema.Controls.Add(lbl)
                                    Me.UltraToolTipManager1.SetUltraToolTip(lbl, lblToolTipInfo)
                                    lbl.Show()
                                End If

                                lbl = New Label
                                lbl.BorderStyle = BorderStyle.FixedSingle
                                lbl.Left = .POS_LEFT
                                lbl.Top = .POS_TOP + 23
                                lbl.Height = 22
                                lbl.Width = 50
                                lbl.Text = ""
                                lbl.Tag = CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField
                                lbl.ForeColor = Color.Black
                                lbl.BackColor = Color.White
                                lblToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo(CType(.Param, TPLD.TPLD.TPLD_PARAM).Name, Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
                                lblToolTipInfo.ToolTipText = CType(.Param, TPLD.TPLD.TPLD_PARAM).Name
                                picSchema.Controls.Add(lbl)
                                Me.UltraToolTipManager1.SetUltraToolTip(lbl, lblToolTipInfo)
                                lbl.Show()


                                If EditParam Then
                                    txt = New TextBox
                                    txt.BorderStyle = BorderStyle.FixedSingle
                                    txt.Left = .POS_LEFT
                                    txt.Top = .POS_TOP + 46
                                    txt.Height = 22
                                    txt.Width = 50
                                    txt.Text = ""
                                    txt.Tag = CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField + "_min"
                                    txt.ForeColor = Color.Blue
                                    txt.BackColor = Color.White
                                    lblToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo(CType(.Param, TPLD.TPLD.TPLD_PARAM).Name, Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
                                    lblToolTipInfo.ToolTipText = "Минимум " & CType(.Param, TPLD.TPLD.TPLD_PARAM).Name
                                    picSchema.Controls.Add(txt)
                                    Me.UltraToolTipManager1.SetUltraToolTip(txt, lblToolTipInfo)
                                    txt.Show()

                                    chk = New CheckBox

                                    chk.Left = .POS_LEFT + 50
                                    chk.Top = .POS_TOP + 46
                                    chk.Height = 20
                                    chk.Width = 20
                                    chk.Text = ""
                                    chk.Tag = "chk_" + CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField + "_min"
                                    chk.BackColor = Color.White
                                    lblToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo(CType(.Param, TPLD.TPLD.TPLD_PARAM).Name, Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
                                    lblToolTipInfo.ToolTipText = "Проверять минимум для " & CType(.Param, TPLD.TPLD.TPLD_PARAM).Name
                                    picSchema.Controls.Add(chk)
                                    Me.UltraToolTipManager1.SetUltraToolTip(chk, lblToolTipInfo)
                                    chk.Show()
                                Else

                                    lbl = New Label
                                    lbl.BorderStyle = BorderStyle.FixedSingle
                                    lbl.Left = .POS_LEFT
                                    lbl.Top = .POS_TOP + 46
                                    lbl.Height = 22
                                    lbl.Width = 50
                                    lbl.Text = ""
                                    lbl.Tag = CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField + "_min"
                                    lbl.ForeColor = Color.Blue
                                    lbl.BackColor = Color.White
                                    lblToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo(CType(.Param, TPLD.TPLD.TPLD_PARAM).Name, Infragistics.Win.ToolTipImage.[Default], Nothing, Infragistics.Win.DefaultableBoolean.[Default])
                                    lblToolTipInfo.ToolTipText = "Минимум " & CType(.Param, TPLD.TPLD.TPLD_PARAM).Name
                                    picSchema.Controls.Add(lbl)
                                    Me.UltraToolTipManager1.SetUltraToolTip(lbl, lblToolTipInfo)
                                    lbl.Show()
                                End If
                            End If
                        End If
                    End If
                End With
            Next
            LastShowD = Date.MinValue

            ShowMinMax()
            ShowData()
        End If

    End Sub



    Private Sub frmSchema_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        bActivated = True
        LoadData(id)
    End Sub

    Private Sub frmSchema_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        bActivated = False
        CType(MdiParent, frmMain).MyfrmSchema = Nothing
    End Sub

    Private Sub frmSchema_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If fname <> "" Then
                Kill(fname)
            End If
        Catch ex As Exception

        End Try

        fname = ""
    End Sub

    Private Sub frmSchema_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub



    Private Function GetByName(ByVal name As String) As Control

        Dim i As Integer
        For i = 0 To picSchema.Controls.Count - 1
            If picSchema.Controls.Item(i).Tag.ToString().ToLower = name.ToLower Then
                Return picSchema.Controls.Item(i)
            End If
        Next
        Return Nothing
    End Function

    Private Sub ShowMinMax()


        Dim ctl As Control
        Dim lbl As Label
        Dim txt As TextBox
        Dim chk As CheckBox
        Dim i As Long
        For i = 1 To tt.TPLT_VALUEBOUNDS.Count
            With tt.TPLT_VALUEBOUNDS.Item(i)
                If CType(.PTYPE, TPLD.TPLD.TPLD_PARAMTYPE).TheCode = ptype.ToString() Then
                    If CType(.PNAME, TPLD.TPLD.TPLD_PARAM).ShowAs = TPLD.TPLD.enumColumnSortType.ColumnSortType_As_Numeric Then

                        If EditParam Then

                            ctl = GetByName(CType(.PNAME, TPLD.TPLD.TPLD_PARAM).ParamField + "_min")
                            If Not ctl Is Nothing Then
                                txt = ctl
                                txt.Text = .PMIN.ToString
                            End If

                            ctl = GetByName(CType(.PNAME, TPLD.TPLD.TPLD_PARAM).ParamField + "_max")
                            If Not ctl Is Nothing Then
                                txt = ctl
                                txt.Text = .PMAX.ToString
                            End If

                            ctl = GetByName("chk_" + CType(.PNAME, TPLD.TPLD.TPLD_PARAM).ParamField + "_min")
                            If Not ctl Is Nothing Then
                                chk = ctl
                                If .ISMIN = TPLT.TPLT.enumBoolean.Boolean_Da Then
                                    chk.Checked = True
                                Else
                                    chk.Checked = False
                                End If
                            End If

                            ctl = GetByName("chk_" + CType(.PNAME, TPLD.TPLD.TPLD_PARAM).ParamField + "_max")
                            If Not ctl Is Nothing Then
                                chk = ctl
                                If .ISMAX = TPLT.TPLT.enumBoolean.Boolean_Da Then
                                    chk.Checked = True
                                Else
                                    chk.Checked = False
                                End If
                            End If


                        Else


                            ctl = GetByName(CType(.PNAME, TPLD.TPLD.TPLD_PARAM).ParamField + "_min")
                            If Not ctl Is Nothing Then
                                lbl = ctl
                                lbl.Text = .PMIN.ToString
                            End If

                            ctl = GetByName(CType(.PNAME, TPLD.TPLD.TPLD_PARAM).ParamField + "_max")
                            If Not ctl Is Nothing Then
                                lbl = ctl
                                lbl.Text = .PMAX.ToString()
                            End If

                        End If
                    End If
                End If

            End With

        Next

    End Sub


    Private Sub SaveParams()
        Dim i As Long
        For i = 1 To tt.TPLT_VALUEBOUNDS.Count
            With tt.TPLT_VALUEBOUNDS.Item(i)
                If CType(.PTYPE, TPLD.TPLD.TPLD_PARAMTYPE).TheCode = ptype.ToString() Then
                    Dim ctl As Control
                    Dim txt As TextBox
                    Dim chk As CheckBox
                    If EditParam Then
                        ctl = GetByName(CType(.PNAME, TPLD.TPLD.TPLD_PARAM).ParamField + "_min")
                        If Not ctl Is Nothing Then
                            txt = ctl
                            .PMIN = Val("0" + txt.Text)
                        End If

                        ctl = GetByName(CType(.PNAME, TPLD.TPLD.TPLD_PARAM).ParamField + "_max")
                        If Not ctl Is Nothing Then
                            txt = ctl
                            .PMAX = Val("0" + txt.Text)
                        End If

                        ctl = GetByName("chk_" + CType(.PNAME, TPLD.TPLD.TPLD_PARAM).ParamField + "_min")
                        If Not ctl Is Nothing Then
                            chk = ctl
                            If chk.Checked = True Then
                                .ISMIN = TPLT.TPLT.enumBoolean.Boolean_Da
                            Else
                                .ISMIN = TPLT.TPLT.enumBoolean.Boolean_Net
                            End If
                        End If

                        ctl = GetByName("chk_" + CType(.PNAME, TPLD.TPLD.TPLD_PARAM).ParamField + "_max")
                        If Not ctl Is Nothing Then
                            chk = ctl
                            If chk.Checked = True Then
                                .ISMAX = TPLT.TPLT.enumBoolean.Boolean_Da
                            Else
                                .ISMAX = TPLT.TPLT.enumBoolean.Boolean_Net
                            End If
                        End If

                        ctl = GetByName(CType(.PNAME, TPLD.TPLD.TPLD_PARAM).ParamField)
                        If Not ctl Is Nothing Then
                            .Save()
                        End If

                    End If



                End If

            End With

        Next

    End Sub


    Private Sub ShowData()
        Dim d As Date = Date.Today
        Dim CommandText As String
        Dim dt As DataTable

        If tc Is Nothing Then Exit Sub

        CommandText = "select max(dcounter) md from " + TableForArch(ptype) + " where instanceid=" + GUID2String(Session, tc.ID) + ""
        dt = Session.GetData(CommandText)
        If IsDate(dt.Rows(0)("md")) Then
            d = dt.Rows(0)("md")
        End If
        If d <= LastShowD Then Exit Sub
        LastShowD = d



        CommandText = "select * from " + TableForArch(ptype) + " where instanceid=" + GUID2String(Session, tc.ID) + " and dcounter>=" & Session.GetProvider.Date2Const(d)
        dt = Session.GetData(CommandText)
        If dt.Rows.Count > 0 Then

            Dim i As Integer
            Dim lbl As Label
            For i = 0 To picSchema.Controls.Count - 1
                lbl = Nothing
                Try
                    lbl = picSchema.Controls.Item(i)
                Catch
                End Try

                If Not lbl Is Nothing Then
                    Try
                        lbl.Text = dt.Rows(0)(lbl.Tag)
                    Catch ex As Exception

                    End Try
                End If


            Next
        End If

        CheckBounds()

    End Sub


    Private Sub CheckBounds()
        Dim vdt As DataTable
        vdt = Session.GetData("select TPLT_VALUEBOUNDS.*, tpld_param.paramfield,tpld_paramtype.thecode from TPLT_VALUEBOUNDS " + _
                              " join tpld_param on pname = tpld_paramid " + _
                              " join tpld_paramtype on ptype=tpld_paramtypeid where TPLT_VALUEBOUNDS.instanceid=" + GUID2String(Session, tt.ID) + " and thecode=" + ptype.ToString)

        Dim ctl As Control
        Dim lbl As Label


        Dim i As Long
        For i = 0 To vdt.Rows.Count - 1

            ctl = GetByName(vdt.Rows(i)("paramfield"))
            If Not ctl Is Nothing Then
                lbl = ctl
                If vdt.Rows(i)("ISMIN") = -1 Then
                    If Val(lbl.Text) < vdt.Rows(i)("PMIN") Then
                        lbl.BackColor = Color.Red
                        lbl.ForeColor = Color.White
                    End If
                End If
                If vdt.Rows(i)("ISMAX") = -1 Then
                    If Val(lbl.Text) > vdt.Rows(i)("PMAX") Then
                        lbl.BackColor = Color.Red
                        lbl.ForeColor = Color.White
                    End If
                End If
            End If

        Next


    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not bActivated Then Exit Sub
        ShowData()
    End Sub

    Public Sub SetupPanel()
        Dim f As frmPanelSetup
        f = New frmPanelSetup

        Dim i As Integer, J As Integer
        Dim ctl As Control
        Dim shape As NetronLight.ShapeBase
        f.grc.Shapes.Clear()
        f.grc.Invalidate()
        f.Refresh()
        ' f.BackgroundImage = picSchema.Image
        Dim img As System.Drawing.Image


        img = picSchema.Image.Clone
        f.grc.BackgroundImage = CType(img, System.Drawing.Image)
        f.grc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Dim cPfx As String

        For i = 0 To picSchema.Controls.Count - 1
            ctl = picSchema.Controls.Item(i)
            cPfx = ctl.Tag
            Try
                cPfx = ctl.Tag.Substring(ctl.Tag.ToString.Length - 4, 4)
            Catch
            End Try

            If cPfx <> "_min" And cPfx <> "_max" Then
                shape = New NetronLight.ShapeBase(f.grc)
                Dim loc As System.Drawing.Point
                loc = ctl.Location
                loc.Y -= 23
                shape = f.grc.AddShape(NetronLight.ShapeTypes.Rectangular, loc)
                shape.Text = ctl.Tag
                shape.Width = ctl.Width
                shape.Height = ctl.Height * 3
                shape.ShapeColor = System.Drawing.Color.White
            End If
        Next
        If f.ShowDialog() = DialogResult.OK Then
            For i = 0 To picSchema.Controls.Count - 1
                ctl = picSchema.Controls.Item(i)
                For J = 0 To f.grc.Shapes.Count - 1
                    shape = f.grc.Shapes.Item(J)

                    If shape.Text = ctl.Tag Then
                        ctl.Location = shape.Location
                        ctl.Width = shape.Width
                        ctl.Height = shape.Height

                        ' сохранение в базе данных
                        Dim jj As Long
                        For jj = 1 To ts.TPLS_PARAM.Count

                            With ts.TPLS_PARAM.Item(jj)
                                If CType(.ArchType, TPLD.TPLD.TPLD_PARAMTYPE).TheCode = ptype.ToString() Then
                                    If CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField = ctl.Tag Then
                                        .POS_LEFT = ctl.Location.X
                                        .POS_TOP = ctl.Location.Y
                                        .Save()
                                    End If
                                End If
                            End With

                        Next


                    End If
                Next

            Next



        End If

        LoadData(id)

    End Sub

    Private Sub cmdSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetup.Click
        If fname <> "" Then
            SetupPanel()
        End If
    End Sub



    Private Sub chkMoment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMoment.CheckedChanged
        If chkMoment.Checked Then
            ptype = 1
            chkHour.Checked = False
            chkDay.Checked = False
            chkITog.Checked = False
            LoadData(id)
        End If
        If chkMoment.Checked = False And chkHour.Checked = False And chkDay.Checked = False And chkITog.Checked = False Then
            chkMoment.Checked = True
            ptype = 1
        End If

    End Sub

    Private Sub chkHour_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHour.CheckedChanged
        If chkHour.Checked Then
            ptype = 3
            chkMoment.Checked = False
            chkDay.Checked = False
            chkITog.Checked = False
            LoadData(id)
        End If
        If chkMoment.Checked = False And chkHour.Checked = False And chkDay.Checked = False And chkITog.Checked = False Then
            chkMoment.Checked = True
            ptype = 1
        End If

    End Sub

    Private Sub chkDay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDay.CheckedChanged
        If chkDay.Checked Then
            ptype = 4
            chkMoment.Checked = False
            chkHour.Checked = False
            chkITog.Checked = False
            LoadData(id)
        End If
        If chkMoment.Checked = False And chkHour.Checked = False And chkDay.Checked = False And chkITog.Checked = False Then
            chkMoment.Checked = True
            ptype = 1
        End If

    End Sub

    Private Sub cmdParams_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdParams.Click
        Dim f As frmSelectParam
        f = New frmSelectParam
        f.ts = ts
        f.ptype = ptype
        f.LoadData(ds_id)
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadData(id)
        End If
        f = Nothing
    End Sub





    Private Sub cmdValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValues.Click
        If EditParam Then
            ' сохранить изменения
            cmdValues.Text = "Граничные значения"
            SaveParams()
        Else
            cmdValues.Text = "Сохранить границы"
        End If



        EditParam = Not EditParam

        LoadData(id)

    End Sub

    Private Sub chkITog_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkITog.CheckedChanged
        If chkITog.Checked Then
            ptype = 2
            chkDay.Checked = False
            chkMoment.Checked = False
            chkHour.Checked = False
            LoadData(id)
        End If
        If chkMoment.Checked = False And chkHour.Checked = False And chkDay.Checked = False And chkITog.Checked = False Then
            chkMoment.Checked = True
            ptype = 1
        End If
    End Sub
End Class