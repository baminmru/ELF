

Public Class frmSelectParam
    Public ds_id As String
    Public ts As TPLS.TPLS.Application
    Public ptype As Integer




    Public Sub LoadData(ByVal newid As Guid)
        chkParams.Items.Clear()
        Dim i As Long
        For i = 1 To ts.TPLS_PARAM.Count
            With ts.TPLS_PARAM.Item(i)

                If CType(.ArchType, TPLD.TPLD.TPLD_PARAMTYPE).TheCode = ptype.ToString() Then

                    If .HIDEPARAM = TPLS.TPLS.enumBoolean.Boolean_Net Then
                        chkParams.Items.Add(CType(.Param, TPLD.TPLD.TPLD_PARAM).Name, True)
                    Else
                        chkParams.Items.Add(CType(.Param, TPLD.TPLD.TPLD_PARAM).Name, False)
                    End If

                End If
            End With

        Next

    End Sub



    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK

        Dim i As Long
        Dim j As Long




        For j = 0 To chkParams.CheckedItems.Count - 1
            For i = 1 To ts.TPLS_PARAM.Count
                With ts.TPLS_PARAM.Item(i)

                    If CType(.ArchType, TPLD.TPLD.TPLD_PARAMTYPE).TheCode = ptype.ToString() Then
                        If chkParams.CheckedItems.Item(j) = CType(.Param, TPLD.TPLD.TPLD_PARAM).Name Then
                            .HIDEPARAM = TPLS.TPLS.enumBoolean.Boolean_Net
                            .Save()
                        End If
                    End If

                End With

            Next
        Next



        For i = 1 To ts.TPLS_PARAM.Count
            With ts.TPLS_PARAM.Item(i)
                If CType(.ArchType, TPLD.TPLD.TPLD_PARAMTYPE).TheCode = ptype.ToString() Then
                    If .HIDEPARAM = TPLS.TPLS.enumBoolean.Boolean_Net Then
                        If Not chkParams.CheckedItems.Contains(CType(.Param, TPLD.TPLD.TPLD_PARAM).Name) Then
                            .HIDEPARAM = TPLS.TPLS.enumBoolean.Boolean_Da
                            .Save()
                        End If
                    End If
                End If

            End With

        Next


        Me.Hide()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub frmSelectParam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class