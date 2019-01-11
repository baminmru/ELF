Imports System.Windows.Forms
Imports LATIR2.Utils
Public Class frmMain
    Public MyfrmManual As ClientForm
    Public MyfrmSchema As frmSchema

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub



    'Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    'End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer



    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim f As STKDispatcherSplash
        f = New STKDispatcherSplash
        f.Show()

    End Sub

    Private Sub mnuManualQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuManualQuery.Click
        If MyfrmManual Is Nothing Then
            MyfrmManual = New ClientForm
        End If
        If MyfrmManual.Visible = False Then
            MyfrmManual.MdiParent = Me
            MyfrmManual.Show()
        End If
        MyfrmManual.RefreshData(tree)


    End Sub







    ' bami
    Public Sub ListBoxInit()


        Dim dt As DataTable
        Dim i As Integer
        Dim GrpPostFix As String


        GrpPostFix = ""


        dt = Session.GetData("select * from v_autoTPLD_GRP order by TPLD_GRP_CGRPNM")


        If Not dt Is Nothing Then
            LoadLevelData("", dt, tree)
            For i = 0 To dt.Rows.Count - 1
                LoadLevelData(dt.Rows.Item(i)("TPLD_GRPID").ToString, Session.GetData("select * from v_autoTPLT_BDEVICES where TPLT_BDEVICES_DevGrp_id='" + Session.GetProvider().ID2Param(New Guid(dt.Rows.Item(i)("TPLD_GRPID").ToString)) + "' order by TPLT_BDEVICES_Name"), tree)
            Next
        End If

        tree.HideSelection = False


    End Sub

    Private Sub frmMain_ContextMenuStripChanged(sender As Object, e As System.EventArgs) Handles Me.ContextMenuStripChanged

    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Session.Logout()
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TvMain = New TVMain.TVMain
        If TvMain.Init(MyManager, SrvID) = False Then
            Application.Exit()
            End
        Else
            ListBoxInit()

            applicationStartTime = DateTime.Now.AddMinutes(-2)
            Me.UltraToolbarsManager1.Toolbars("tool1").Tools.AddTool("p1")
        End If


        

    End Sub





    Private Sub cmdTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest.Click
        Dim f As Form1
        Dim tag As Object

        If tree.SelectedNodes.Count > 0 Then
            If tree.SelectedNodes.Item(0).Key.ToString().Substring(0, 1) = "N" Then
                tag = tree.SelectedNodes.Item(0).Tag
            Else
                Exit Sub
            End If
        Else
            Exit Sub

        End If
        f = New Form1
        f.DEVID = tag
        f.ShowDialog()


    End Sub

    Private Sub tree_AfterSelect(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTree.SelectEventArgs) Handles tree.AfterSelect
        If Not MyfrmManual Is Nothing Then
            If MyfrmManual.Visible = True Then
                MyfrmManual.RefreshData(tree)
            Else
                MyfrmManual = Nothing
            End If

        End If





        If Not MyfrmSchema Is Nothing Then
            If MyfrmSchema.Visible = True Then
                Try
                    If tree.SelectedNodes.Item(0).Key.ToString().Substring(0, 1) = "N" Then

                        MyfrmSchema.LoadData(tree.SelectedNodes.Item(0).Tag)
                    End If
                Catch
                End Try
            Else

                MyfrmSchema = Nothing
            End If

        End If
    End Sub

    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager1.ToolClick

    End Sub

    Private Sub mnuSchema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSchema.Click
        If MyfrmSchema Is Nothing Then
            MyfrmSchema = New frmSchema
        End If
        If Not MyfrmSchema.Visible Then
            MyfrmSchema.MdiParent = Me
            MyfrmSchema.Show()
        End If
        Try
            If tree.SelectedNodes.Item(0).Key.ToString().Substring(0, 1) = "N" Then
                MyfrmSchema.LoadData(tree.SelectedNodes.Item(0).Tag)
            End If
        Catch
        End Try

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MyManager = New LATIR2.Manager
        guiManager = New LATIR2GuiManager.LATIRGuiManager
        guiManager.Attach(MyManager)

        Dim username As String = ""
        Dim sitename As String = ""
        sitename = GetSetting("TeploSrv", "Setup", "Site", "")
        username = GetSetting("TeploSrv", "Setup", "User", "")
        If Not guiManager.Login(username, sitename) Then
            Application.Exit()
            End
        End If

        SaveSetting("TeploSrv", "Setup", "Site", sitename)
        SaveSetting("TeploSrv", "Setup", "User", username)
        Dim s As String

        s = GetSetting("TeploSrv", "Setup", "SrvID", Guid.Empty.ToString())
        SrvID = New Guid(s)

        Session = MyManager.Session

    End Sub

    Private Sub ButtonConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConfig.Click
        Dim TAG As Guid
        If tree.SelectedNodes.Count > 0 Then
            If tree.SelectedNodes.Item(0).Key.ToString().Substring(0, 1) = "N" Then
                Tag = tree.SelectedNodes.Item(0).Tag

                Dim f As frmChild
                f = New frmChild


                Dim ed As LATIR2.Document.Doc_Base
                ed = guiManager.Manager.GetInstanceObject(TAG)
                If (Not ed Is Nothing) Then
                    Dim Doc_GUIBase As LATIR2GuiManager.Doc_GUIBase
                    Doc_GUIBase = guiManager.GetTypeGUI(ed.TypeName)

                    Dim objControl As Object = Nothing
                    Try
                        objControl = Doc_GUIBase.GetObjectControl(String.Empty, "TPLT")
                    Catch
                    End Try

                    If (Not objControl Is Nothing) Then
                        f.AppendControl(Doc_GUIBase.GetObjectControl(String.Empty, "TPLT"))
                        f.MdiParent = Me
                        f.Attach(guiManager, ed)
                        f.Show()
                    Else
                        MessageBox.Show("Error occured while running the form")
                    End If
                End If

            Else
                Exit Sub
            End If
        Else
            Exit Sub

        End If
    End Sub


    Private Sub mnuDic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDic.Click
        Dim f As frmChild
        f = New frmChild
        Dim ObjTypeName As String = "TPLD"
        Dim dt As DataTable
        Dim oID As Guid
        dt = guiManager.Manager.Session.GetRowsExDT("INSTANCE", guiManager.Manager.Session.GetProvider.InstanceFieldList, , , "OBJTYPE='" + ObjTypeName + "'")
        If dt.Rows.Count = 0 Then
            MyManager.NewInstance(Guid.NewGuid(), "TPLD", "Справочник")
            dt = guiManager.Manager.Session.GetRowsExDT("INSTANCE", guiManager.Manager.Session.GetProvider.InstanceFieldList, , , "OBJTYPE='" + ObjTypeName + "'")
        End If
        oID = New Guid(dt.Rows.Item(0).Item("INSTANCEID").ToString)
        Dim ed As LATIR2.Document.Doc_Base
        ed = guiManager.Manager.GetInstanceObject(oID)
        If (Not ed Is Nothing) Then
            Dim Doc_GUIBase As LATIR2GuiManager.Doc_GUIBase
            Doc_GUIBase = guiManager.GetTypeGUI(ed.TypeName)

            Dim objControl As Object = Nothing
            Try
                objControl = Doc_GUIBase.GetObjectControl(String.Empty, ObjTypeName)
            Catch
            End Try

            If (Not objControl Is Nothing) Then
                f.AppendControl(Doc_GUIBase.GetObjectControl(String.Empty, ObjTypeName))
                f.MdiParent = Me
                f.Attach(guiManager, ed)
                f.Show()
            Else
                MessageBox.Show("Error occured while running the form")
            End If
        End If
    End Sub

    Private Sub mnuServerSetup_Click(sender As System.Object, e As System.EventArgs) Handles mnuServerSetup.Click
        Dim f As frmSrvSetup
        f = New frmSrvSetup
        f.ShowDialog()
        f = Nothing
    End Sub


    'Private Sub mnuAnalizeLosot_Click(sender As System.Object, e As System.EventArgs) Handles mnuAnalizeLosot.Click
    '    Dim dt As DataTable
    '    Dim an As LostAnalizer
    '    dt = TvMain.TheSession.GetData("select * from v_dev_all")
    '    Dim i As Integer
    '    For i = 0 To dt.Rows.Count - 1
    '        an = New LostAnalizer
    '        an.tvmain = TvMain
    '        an.id_bd = dt.Rows(i)("id_bd")
    '        an.NodeName = dt.Rows(i)("Узел")
    '        an.AnalizeLost()
    '    Next
    'End Sub
End Class
