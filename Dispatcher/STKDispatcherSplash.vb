﻿Public NotInheritable Class STKDispatcherSplash

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub STKDispatcherSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        'If My.Application.Info.Title <> "" Then
        ApplicationTitle.Text = "Диспетчер"
        Dim addr As System.Net.IPAddress()
        addr = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())

        lblIP.Text = System.Net.Dns.GetHostName().ToUpper() + " IP:"
        Dim i As Integer
        Dim ab(0 To 6) As Byte
        For i = 0 To UBound(addr)
            ab = addr(i).GetAddressBytes()
            If UBound(ab) = 3 Then
                lblIP.Text = lblIP.Text & vbCrLf & ab(0).ToString & "." & ab(1).ToString & "." & ab(2).ToString & "." & ab(3).ToString
            End If
        Next


        'Else
        '    'If the application title is missing, use the application name, without the extension
        '    ApplicationTitle.Text = "ПОТОК-IP. Диспетчер" ' System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        'End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        'Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        'Copyright.Text = My.Application.Info.Copyright
    End Sub

    Private Sub MainLayoutPanel_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.Close()
    End Sub

    Private Sub MainLayoutPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub STKDispatcherSplash_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Me.Close()
    End Sub

    Private Sub ApplicationTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Version_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Copyright_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub STKDispatcherSplash_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Application.DoEvents()
        System.Threading.Thread.Sleep(2000)
    End Sub
End Class
