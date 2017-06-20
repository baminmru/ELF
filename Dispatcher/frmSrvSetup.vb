Public Class frmSrvSetup

   

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Hide()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        Me.Hide()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        SaveSetting("TeploSrv", "Setup", "SrvID", txtSrv.Tag.ToString().ToUpper())
        SrvID = txtSrv.Tag
    End Sub

    Private Sub cmdSrv_Click(sender As System.Object, e As System.EventArgs) Handles cmdSrv.Click
       On Error Resume Next
        Dim id As guid
        Dim brief As String = String.Empty
        Dim OK As Boolean
        If guiManager.GetReferenceDialog("TPSRV_INFO", "", System.Guid.Empty, id, brief) Then
            txtSrv.Tag = id
            txtSrv.Text = brief
            txtID.Text = id.ToString().ToUpper()
        End If

    End Sub

    Private Sub frmSrvSetup_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtSrv.Tag = SrvID
        txtID.Text = SrvID.ToString().ToUpper()
        Dim brief As String = String.Empty
        MyManager.Session.GetBrief("TPSRV_INFO", SrvID, brief)
        txtSrv.Text = brief
    End Sub
End Class