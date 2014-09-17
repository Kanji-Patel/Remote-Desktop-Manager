Imports MSTSCLib

Public Class frmTerminal
    Private IsDisconnected As Boolean = False
    Private Delegate Sub CloseForm()

    Public Sub New(ByVal MachineID As String, ByVal UserName As String, ByVal Password As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Try
            'Me.Timer1.Enabled = True
            Timer1.Interval = 100
            Me.WindowState = FormWindowState.Normal
            Me.RemoteDisplay.SuspendLayout()
            If MachineID.Contains(":") Then
                Dim sToken() As String = MachineID.Split(":")
                Me.RemoteDisplay.Server = sToken(0)
                If sToken.Length > 0 Then
                    Me.RemoteDisplay.AdvancedSettings2.RDPPort = sToken(1)
                End If
            Else
                Me.RemoteDisplay.Server = MachineID
            End If

            Me.RemoteDisplay.UserName = UserName
            Me.RemoteDisplay.AdvancedSettings.ContainerHandledFullScreen = -1
            Me.RemoteDisplay.AdvancedSettings3.RedirectSmartCards = True
            Me.RemoteDisplay.AdvancedSettings2.RedirectDrives = WithDrive
            'Me.RemoteDisplay.AdvancedSettings2.RedirectDrives = True
            Dim value As String = Screen.PrimaryScreen.Bounds.Width.ToString()
            Dim value2 As String = Screen.PrimaryScreen.Bounds.Height.ToString()
            Me.RemoteDisplay.DesktopWidth = CInt(value)
            Me.RemoteDisplay.DesktopHeight = CInt(value2)
            Me.RemoteDisplay.FullScreen = True
            Me.RemoteDisplay.ResumeLayout(True)

            'Me.Text = "Terminal - " & MachineID
            Me.Text = "Terminal - " & UserName & "@" & MachineID
            Dim msTscNonScriptable As IMsTscNonScriptable = CType(Me.RemoteDisplay.GetOcx(), IMsTscNonScriptable)
            msTscNonScriptable.ClearTextPassword = Password
            Me.RemoteDisplay.Connect()

            lblConnectingTo.Text = "Connecting to " & UserName & "@" & MachineID
            lblConnectingTo.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Me.Close()
        End Try
    End Sub

    Private Sub RemoteDisplay_OnConnected(sender As Object, e As System.EventArgs) Handles RemoteDisplay.OnConnected
        lblConnectingTo.Visible = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub RemoteDisplay_OnDisconnected(ByVal sender As Object, ByVal e As AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEvent) Handles RemoteDisplay.OnDisconnected
        Me.IsDisconnected = True
        Timer1.Enabled = True
    End Sub

    Private Sub RemoteDisplay_OnRequestContainerMinimize(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemoteDisplay.OnRequestContainerMinimize
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub RemoteDisplay_OnRequestLeaveFullScreen(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemoteDisplay.OnRequestLeaveFullScreen
        RemoteDisplay.FullScreen = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Timer1.Enabled = False
            If Me.IsDisconnected = True Then
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class