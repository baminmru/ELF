Public Class frmChild
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents pnlStatus As System.Windows.Forms.Panel
    Friend WithEvents ctlStatus As LATIR2GUIControls.StatusControl
    Friend WithEvents pnlObj As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChild))
        Me.pnlStatus = New System.Windows.Forms.Panel
        Me.ctlStatus = New LATIR2GUIControls.StatusControl
        Me.pnlObj = New System.Windows.Forms.Panel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlStatus
        '
        Me.pnlStatus.Controls.Add(Me.ctlStatus)
        Me.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlStatus.Location = New System.Drawing.Point(0, 0)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(992, 36)
        Me.pnlStatus.TabIndex = 0
        '
        'ctlStatus
        '
        Me.ctlStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctlStatus.Location = New System.Drawing.Point(0, 0)
        Me.ctlStatus.Name = "ctlStatus"
        Me.ctlStatus.Size = New System.Drawing.Size(992, 36)
        Me.ctlStatus.TabIndex = 0
        '
        'pnlObj
        '
        Me.pnlObj.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlObj.Location = New System.Drawing.Point(0, 36)
        Me.pnlObj.Name = "pnlObj"
        Me.pnlObj.Size = New System.Drawing.Size(992, 637)
        Me.pnlObj.TabIndex = 1
        '
        'frmChild
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(992, 673)
        Me.Controls.Add(Me.pnlObj)
        Me.Controls.Add(Me.pnlStatus)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChild"
        Me.Text = "frmChild"
        Me.pnlStatus.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private DataControl As System.Windows.Forms.UserControl
    Private GuiManager As LATIR2GuiManager.LATIRGuiManager
    Private Item As LATIR2.Document.Doc_Base

    Public Sub AppendControl(ByVal uc As System.Windows.Forms.UserControl)
        Me.SuspendLayout()
        pnlObj.SuspendLayout()
        DataControl = uc
        DataControl.Location = New Point(0, 0)
        DataControl.Dock = DockStyle.Fill
        pnlObj.Controls.Add(DataControl)
        pnlObj.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Public Sub Attach(ByVal gm As LATIR2GuiManager.LATIRGuiManager, ByVal DOcItem As LATIR2.Document.Doc_Base)
        GuiManager = gm

        Item = DOcItem

        If Item.IsLocked = LATIR2.Session.LockStyle.ExternalLockPermanent Or Item.IsLocked = LATIR2.Session.LockStyle.ExternalLockSession Then
            Me.Text = "Только чтение:" & DOcItem.Name
            MsgBox("Документ заблокирован другим пользователем", MsgBoxStyle.OkOnly, "Предупреждение")
            Try
                CType(DataControl, Object).Attach(DOcItem, gm, True)
            Catch
            End Try
        Else
            Me.Text = DOcItem.Name
            Item.LockResource(False)
            CType(DataControl, Object).Attach(DOcItem, gm, False)
        End If



        If Not DOcItem.HasStatuses Then
            pnlStatus.Size = New Size(528, 0)
            pnlStatus.Enabled = False
            'ctlStatus.Visible = False
        Else
            pnlStatus.Size = New System.Drawing.Size(528, 40)
            pnlStatus.Enabled = True
            'pnlStatus.Visible = True
            'ctlStatus.Visible = True
            If Item.IsLocked() = LATIR2.Session.LockStyle.ExternalLockPermanent Or Item.IsLocked() = LATIR2.Session.LockStyle.ExternalLockSession Then
                ctlStatus.Attach(gm, DOcItem, False, False, False)
            Else
                ctlStatus.Attach(gm, DOcItem, True, True, True)
            End If

        End If
        Timer1.Enabled = True


    End Sub

    Private Sub ctlStatus_AfterChangeState(ByVal DocItem As LATIR2.Document.Doc_Base, ByVal NewStateID As System.Guid) Handles ctlStatus.AfterChangeState
        Dim bst As LATIR2.Document.Doc_StatusSupport = Nothing
        Try
            bst = DocItem.Manager.GetDocStatusSupport(DocItem.TypeName)
        Catch
        End Try
        If Not bst Is Nothing Then
            Try
                bst.AfterChangeState(DocItem, NewStateID)
            Catch
                Return
            End Try
        End If

        If CheckAndSave(True) Then
            Me.Hide()
        End If
    End Sub

    Private Function CheckAndSave(ByVal sielent As Boolean) As Boolean
        If Item.IsLocked = LATIR2.Session.LockStyle.ExternalLockPermanent Or Item.IsLocked = LATIR2.Session.LockStyle.ExternalLockSession Then
            Return True
        End If

        Dim iv As LATIR2GuiManager.IViewPanel
        Dim OK As Boolean
        iv = CType(DataControl, LATIR2GuiManager.IViewPanel)
        If iv.IsChanged() Then
            If Not sielent Then
                If MsgBox("Данные изменены. Сохранить изменения?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Закрытие документа") = MsgBoxResult.Yes Then
                    If iv.Verify(True) Then

                        OK = iv.Save(True, False)
                        If OK Then
                            If Item.CountOfParts > 0 Then
                                If Item.GetDocCollection_Base(1).Count = 1 Then
                                    If Item.Session.GetData("select parttype from part where name='" + Item.GetDocCollection_Base(1).ChildPartName() + "'").Rows(0)(0) = 0 Then
                                        Item.Name = Item.GetDocCollection_Base(1).Item(1).ActualBrief
                                        Item.Save()
                                        Me.Text = Item.Name
                                    End If
                                End If
                            End If
                            Return OK
                        Else
                            Return False
                        End If
                    End If
                Else

                    OK = iv.Save(True, True)
                    If OK Then
                        If Item.CountOfParts > 0 Then
                            If Item.GetDocCollection_Base(1).Count = 1 Then
                                If Item.Session.GetData("select parttype from part where name='" + Item.GetDocCollection_Base(1).ChildPartName() + "'").Rows(0)(0) = 0 Then
                                    Item.Name = Item.GetDocCollection_Base(1).Item(1).ActualBrief
                                    Item.Save()
                                    Me.Text = Item.Name
                                End If
                            End If
                        End If
                        Return OK
                    Else
                        Return False
                    End If

                End If
            End If
        End If
        Return True

    End Function

    Private Sub ctlStatus_BeforeChangeState(ByVal DocItem As LATIR2.Document.Doc_Base, ByVal NewStateID As System.Guid) Handles ctlStatus.BeforeChangeState
        Dim bst As LATIR2.Document.Doc_StatusSupport = Nothing
        Try
            bst = DocItem.Manager.GetDocStatusSupport(DocItem.TypeName)
        Catch
        End Try
        If Not bst Is Nothing Then
            bst.BeforeChangeState(DocItem, NewStateID)
        End If

    End Sub

    Private Sub ctlStatus_CheckFor(ByVal DocItem As LATIR2.Document.Doc_Base, ByVal NewStateID As System.Guid, ByRef OK As Boolean) Handles ctlStatus.CheckFor
        Dim CanSwitch As Boolean

        CanSwitch = True 'RoleDocCanSwitchStatus(DocItem)
        If Not CanSwitch Then
            MsgBox("Для текущего документа не разрешена смена состояния", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Смена состояния")
            OK = False
            Exit Sub
        End If

        OK = True

        Dim bst As LATIR2.Document.Doc_StatusSupport = Nothing
        Try
            bst = DocItem.Manager.GetDocStatusSupport(DocItem.TypeName)
        Catch
        End Try
        If Not bst Is Nothing Then
            OK = bst.CheckFor(DocItem, NewStateID)
        End If
    End Sub

    Private Sub ctlStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctlStatus.Load

    End Sub

    Private Sub frmChild_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            Item.UnLockResource()
        Catch
        End Try
    End Sub

    Private Sub frmChild_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.FormOwnerClosing Then
            e.Cancel = Not CheckAndSave(False)
        End If

        If e.CloseReason = CloseReason.ApplicationExitCall Then
            e.Cancel = Not CheckAndSave(False)
        End If

        If e.CloseReason = CloseReason.MdiFormClosing Then
            e.Cancel = Not CheckAndSave(False)
        End If

        If e.CloseReason = CloseReason.TaskManagerClosing Then
            CheckAndSave(True)
        End If

        If e.CloseReason = CloseReason.WindowsShutDown Then
            CheckAndSave(True)
        End If

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = Not CheckAndSave(False)
        End If

        If e.CloseReason = CloseReason.None Then
            e.Cancel = Not CheckAndSave(False)
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If Item.TypeName <> "LEKD" And Item.TypeName.ToUpper <> "MTZUSERS" Then
                If Item.CountOfParts > 0 Then

                    If Item.GetDocCollection_Base(1).Count > 0 Then
                        If Item.Name <> Item.GetDocCollection_Base(1).Item(1).ActualBrief Then
                            Item.Name = Item.GetDocCollection_Base(1).Item(1).ActualBrief
                            Item.Save()
                        End If
                        Me.Text = Item.Name
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
