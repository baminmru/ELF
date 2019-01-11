Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinTree
Imports LATIR2.Utils


Module STKPublic
    Public WithEvents TvMain As TVMain.TVMain
    Public applicationStartTime As DateTime
    Public queryStartTime As DateTime

    Public LastAction As TVMain.UnitransportAction = Global.TVMain.UnitransportAction.NoAction
    Public LastMSG As String

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

    Public Sub LoadLevelData(ByVal ID As String, ByVal dt As DataTable, ByRef tv As UltraTree)
        Dim i As Integer
        Dim rootnode As UltraTreeNode
        Dim node As UltraTreeNode
        If dt Is Nothing Then Exit Sub

        If ID = "" Then
            tv.Nodes.Clear()
            tv.ViewStyle = UltraWinTree.ViewStyle.Standard
            For i = 0 To dt.Rows.Count - 1
                Try
                    node = tv.Nodes.Add()
                    node.Text = dt.Rows(i).Item("TPLD_GRP_CGRPNM").ToString()
                    node.Tag = dt.Rows(i).Item("TPLD_GRPID").ToString
                    node.Key = "G" & dt.Rows(i).Item("TPLD_GRPID").ToString

                Catch
                    MsgBox(Err.Description)
                End Try
            Next
            tv.RefreshSort(tv.Nodes)
        Else
            rootnode = tv.Nodes.Item("G" & ID)
            rootnode.Nodes.Clear()
            For i = 0 To dt.Rows.Count - 1
                Try
                    node = rootnode.Nodes.Add()
                    node.Text = dt.Rows(i).Item("TPLT_BDEVICES_Name").ToString()
                    node.Tag = New Guid(dt.Rows(i).Item("INSTANCEID").ToString)
                    node.Key = "N" + dt.Rows(i).Item("INSTANCEID").ToString().ToUpper()
                Catch
                    MsgBox(Err.Description)
                End Try
            Next
            tv.RefreshSort(rootnode.Nodes, False)
        End If

    End Sub

    Private Sub TvMain_Idle() Handles TvMain.Idle
        Application.DoEvents()
    End Sub

    Private Sub TvMain_TransportStatus(ByVal Action As TVMain.UnitransportAction, ByVal msg As String) Handles TvMain.TransportStatus

        LastAction = Action
        LastMSG = msg

        Application.DoEvents()
    End Sub
End Module
