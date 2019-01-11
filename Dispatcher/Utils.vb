Imports System.Data
Imports System.IO
Imports System.Data.Common
Imports System.Xml
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports VB = Microsoft.VisualBasic

Public Class Utils
    

    Public Shared Sub SetupGrid(ByRef Gr As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal id As Guid, ByVal ptype As Integer)

        Dim tt As TPLT.TPLT.Application
        Dim ts As TPLS.TPLS.Application
        tt = MyManager.GetInstanceObject(id)
        If tt Is Nothing Then Exit Sub


        Dim i As Integer

        Dim info As RowLayoutColumnInfo
        Dim colsz As Double





        Dim hasDcounter As Boolean = False
        Dim hasDcall As Boolean = False

        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn

        If Not tt.TPLT_BDEVICES.Item(1).THESCHEMA Is Nothing Then
            ts = CType(tt.TPLT_BDEVICES.Item(1).THESCHEMA.Application, TPLS.TPLS.Application)






            Gr.DisplayLayout.CaptionVisible = DefaultableBoolean.True
            Gr.DisplayLayout.CaptionAppearance.FontData.Bold = DefaultableBoolean.True


            If Gr.DisplayLayout.Bands(0).Columns.Count = 0 Then
                Return
            End If


            Gr.DisplayLayout.Scrollbars = Scrollbars.Both
            Gr.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True
            Gr.DisplayLayout.BorderStyle = UIElementBorderStyle.Solid
            Gr.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.Solid
            Gr.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
            Gr.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid







            For i = 0 To Gr.DisplayLayout.Bands(0).Columns.Count - 1
                Gr.DisplayLayout.Bands(0).Columns.Item(i).Hidden = True
                Gr.DisplayLayout.Bands(0).Columns.Item(i).ExcludeFromColumnChooser = ExcludeFromColumnChooser.True
            Next



         

            For i = 1 To ts.TPLS_PARAM.Count
                With ts.TPLS_PARAM.Item(i)
                    If .HIDEPARAM = TPLD.TPLD.enumBoolean.Boolean_Net Then
                        If CType(.ArchType, TPLD.TPLD.TPLD_PARAMTYPE).TheCode = ptype.ToString() Then


                            column = Nothing
                            Try
                                column = Gr.DisplayLayout.Bands(0).Columns.Item(CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField)
                            Catch
                            End Try

                            If column Is Nothing Then
                                column = Gr.DisplayLayout.Bands(0).Columns.Add(CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField.ToString())
                                column.Key = CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField
                            End If





                            If CType(.Param, TPLD.TPLD.TPLD_PARAM).Name + "" <> "" Then
                                column.Header.Caption = CType(.Param, TPLD.TPLD.TPLD_PARAM).Name
                            Else
                                column.Header.Caption = CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField
                            End If

                            'Try
                            '    column.RowLayoutColumnInfo.SpanX = dt.Rows(i)("SEQUENCE")
                            'Catch ex As Exception

                            'End Try


                            'If dt.Rows(i)("COLWIDTH").ToString() = "" Then
                            colsz = 60
                            'Else
                            '    colsz = dt.Rows(i)("COLWIDTH")
                            'End If
                            'If colsz < 15 Then
                            '    colsz = 15
                            'End If


                            Select Case CType(.Param, TPLD.TPLD.TPLD_PARAM).ShowAs
                                Case TPLD.TPLD.enumColumnSortType.ColumnSortType_As_String

                                    info = column.RowLayoutColumnInfo
                                    info.PreferredCellSize = New Size(colsz, 24)
                                    column.MinWidth = colsz

                                    column.Style = ColumnStyle.Edit
                                    'column.Format = "##,###,####"
                                    column.CellAppearance.TextHAlign = HAlign.Right
                                    column.CellAppearance.TextVAlign = VAlign.Middle
                                    column.CellActivation = Activation.ActivateOnly
                                    'Case "I"
                                    '    info = column.RowLayoutColumnInfo
                                    '    info.PreferredCellSize = New Size(colsz, 24)
                                    '    column.MinWidth = colsz

                                    '    column.Style = ColumnStyle.Integer
                                    '    column.Format = "##,###,####"
                                    '    column.CellAppearance.TextHAlign = HAlign.Right
                                    '    column.CellAppearance.TextVAlign = VAlign.Middle
                                    '    column.CellActivation = Activation.ActivateOnly
                                    '    'column.CellAppearance.BackColor = Color.Cyan
                                Case TPLD.TPLD.enumColumnSortType.ColumnSortType_As_Numeric

                                    info = column.RowLayoutColumnInfo
                                    info.PreferredCellSize = New Size(colsz, 24)
                                    column.MinWidth = colsz

                                    column.Style = ColumnStyle.Double
                                    column.Format = "##,###,####.000"
                                    column.CellAppearance.TextHAlign = HAlign.Right
                                    column.CellAppearance.TextVAlign = VAlign.Middle
                                    column.CellActivation = Activation.ActivateOnly
                                    'Case "F"

                                    '    info = column.RowLayoutColumnInfo
                                    '    info.PreferredCellSize = New Size(colsz, 24)
                                    '    column.MinWidth = colsz

                                    '    column.Style = ColumnStyle.Double
                                    '    column.Format = "##,###,####.000"
                                    '    column.CellAppearance.TextHAlign = HAlign.Right
                                    '    column.CellAppearance.TextVAlign = VAlign.Middle
                                    '    column.CellActivation = Activation.ActivateOnly
                                    'Case "B"
                                    '    info = column.RowLayoutColumnInfo
                                    '    info.PreferredCellSize = New Size(colsz, 24)
                                    '    column.MinWidth = colsz

                                    '    column.Style = ColumnStyle.CheckBox
                                    '    'column.Format = "##,###,####.00"
                                    '    column.CellAppearance.TextHAlign = HAlign.Right
                                    '    column.CellAppearance.TextVAlign = VAlign.Middle
                                    '    column.CellActivation = Activation.ActivateOnly
                                    'Case "D"
                                    '    info = column.RowLayoutColumnInfo
                                    '    info.PreferredCellSize = New Size(colsz, 24)
                                    '    column.MinWidth = colsz

                                    '    column.Style = ColumnStyle.DateTime
                                    '    column.Format = "HH:mm   dd.MM.yyyy"
                                    '    column.FormatInfo = System.Globalization.CultureInfo.CreateSpecificCulture("ru")
                                    '    column.CellAppearance.TextHAlign = HAlign.Right
                                    '    column.CellAppearance.TextVAlign = VAlign.Middle
                                    '    column.CellActivation = Activation.ActivateOnly
                                Case TPLD.TPLD.enumColumnSortType.ColumnSortType_As_Date

                                    info = column.RowLayoutColumnInfo
                                    info.PreferredCellSize = New Size(colsz, 24)
                                    column.MinWidth = colsz

                                    column.Style = ColumnStyle.Time
                                    column.Format = "HH:mm:ss"
                                    column.FormatInfo = System.Globalization.CultureInfo.CreateSpecificCulture("ru")
                                    column.CellAppearance.TextHAlign = HAlign.Right
                                    column.CellAppearance.TextVAlign = VAlign.Middle
                                    column.CellActivation = Activation.ActivateOnly

                            End Select

                            If UCase(CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField) = "DCOUNTER" Then
                                hasDcounter = True
                                column.Style = ColumnStyle.DateTime
                                column.Format = "dd.MM.yyyy HH:mm:ss"
                                column.Header.Caption = "Дата счетчика"
                            End If

                            If UCase(CType(.Param, TPLD.TPLD.TPLD_PARAM).ParamField) = "DCALL" Then
                                hasDcall = True
                                column.Style = ColumnStyle.DateTime
                                column.Format = "dd.MM.yyyy HH:mm:ss"
                                column.Header.Caption = "Дата опроса"
                            End If

                            column.Hidden = False
                            column.ExcludeFromColumnChooser = ExcludeFromColumnChooser.False

                        End If
                    End If

                End With
            Next






        End If





        If Not hasDcounter Then
            column = Nothing
            Try
                column = Gr.DisplayLayout.Bands(0).Columns.Item("DCOUNTER")
            Catch
            End Try


            If column Is Nothing Then
                column = Gr.DisplayLayout.Bands(0).Columns.Add("DCOUNTER")
                column.Key = "DCOUNTER"
            End If

            column.Header.Caption = "Дата счетчика"
            info = column.RowLayoutColumnInfo
            info.PreferredCellSize = New Size(60, 24)
            column.MinWidth = 60

            column.Style = ColumnStyle.DateTime
            column.Format = "HH:mm:ss dd.MM.yyyy"
            column.FormatInfo = System.Globalization.CultureInfo.CreateSpecificCulture("ru")
            column.CellAppearance.TextHAlign = HAlign.Right
            column.CellAppearance.TextVAlign = VAlign.Middle
            column.CellActivation = Activation.ActivateOnly
            column.Hidden = False
            column.ExcludeFromColumnChooser = ExcludeFromColumnChooser.False
        End If

        If Not hasDcall Then
            column = Nothing
            Try
                column = Gr.DisplayLayout.Bands(0).Columns.Item("DCALL")
            Catch
            End Try


            If column Is Nothing Then
                column = Gr.DisplayLayout.Bands(0).Columns.Add("DCALL")
                column.Key = "DCALL"
            End If

            column.Header.Caption = "Дата опроса"
            info = column.RowLayoutColumnInfo
            info.PreferredCellSize = New Size(60, 24)
            column.MinWidth = 60

            column.Style = ColumnStyle.DateTime
            column.Format = "HH:mm:ss   dd.MM.yyyy"
            column.FormatInfo = System.Globalization.CultureInfo.CreateSpecificCulture("ru")
            column.CellAppearance.TextHAlign = HAlign.Right
            column.CellAppearance.TextVAlign = VAlign.Middle
            column.CellActivation = Activation.ActivateOnly
            column.Hidden = False
            column.ExcludeFromColumnChooser = ExcludeFromColumnChooser.False
        End If



    End Sub



    Public Shared Function ArchFieldList(ByVal id_bd As Integer, ByVal ptype As Integer) As String
        'Dim dt As DataTable
        'Dim result As String
        'Dim cmd As System.Data.Common.DbCommand
        'cmd = New OracleClient.OracleCommand
        'session.GetData(CommandText) 'cmd.Connection = TvMain.dbconnect()
        'cmd.CommandType = CommandType.Text
        'Dim sqlstr As String = ""
        'Select Case ptype
        '    Case 1
        '        sqlstr = "select ml.* from bdevices b join masksline ml on b.id_mask_curr= ml.id_mask  where ml.colhidden = 0 and  b.id_bd = :id order by sequence,cfld"

        '    Case 3
        '        sqlstr = "select ml.* from bdevices b join masksline ml on b.id_mask_hour= ml.id_mask  where ml.colhidden = 0 and  b.id_bd = :id  order by sequence,cfld"

        '    Case 4
        '        sqlstr = "select ml.* from bdevices b join masksline ml on b.id_mask_24= ml.id_mask  where ml.colhidden = 0 and  b.id_bd = :id  order by sequence,cfld"

        '    Case 2
        '        sqlstr = "select ml.* from bdevices b join masksline ml on b.id_mask_sum= ml.id_mask  where ml.colhidden = 0 and  b.id_bd = :id  order by sequence,cfld"
        'End Select

        'If sqlstr = "" Then
        '    Return "*"
        'End If



        'cmd.CommandText = sqlstr
        'cmd.Parameters.Add(New OracleClient.OracleParameter("ID", id_bd))

        'Dim da As OracleClient.OracleDataAdapter
        'da = New OracleClient.OracleDataAdapter
        'da.SelectCommand = cmd
        'dt = New DataTable
        'da.Fill(dt)

        '' если поля в шаблоне не заданы просто все вываливаем  в таблицу
        'If dt.Rows.Count = 0 Then
        '    Return "*"
        'End If

        'Dim i As Integer
        'result = ""
        'For i = 0 To dt.Rows.Count - 1
        '    If result <> "" Then
        '        result = result + ","
        '    End If
        '    result = result + dt.Rows(i)("cfld")
        'Next

        'If result.ToUpper().IndexOf("DCOUNTER") < 0 Then
        '    result = "DCOUNTER," + result
        'End If

        'Select Case ptype
        '    Case 1
        '        If result.ToUpper().IndexOf("DCALL") < 0 Then
        '            result = "DCALL," + result
        '        End If
        'End Select
        Dim result As String = "*"

        Return result
    End Function

    Public Sub New()

    End Sub
End Class
