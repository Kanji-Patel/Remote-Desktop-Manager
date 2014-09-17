Imports System.IO

Public Class frmMain
    Private objfrmSettings As frmSettings

    Private m_iCount As Integer = 0

#Region "Form Related Code"
    Private Sub mnuConnectTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If CType(sender, System.Windows.Forms.ToolStripMenuItem).Name <> "mnuConnectTo" Then
                Dim clsDesCrypto As clsDesCrypto = New clsDesCrypto()
                Dim dataRow As DataRow = ModGeneral.dsRDC.Tables("dtConnections").[Select]("IPaddress= '" + CType(sender, System.Windows.Forms.ToolStripMenuItem).Name + "'")(0)
                Dim frmTerminal As frmTerminal = New frmTerminal(dataRow("IPaddress"), dataRow("UserName"), clsDesCrypto.fnDecryptR(dataRow("Password")))
                frmTerminal.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            frmAbout.Show()
            frmAbout.BringToFront()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuMain123_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Try
            If MessageBox.Show("Are you sure want to close application?", My.Application.Info.AssemblyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                End
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSettings.Click
        Try
            pOpenSettingForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            pLoadConnection()
            Timer1.Interval = 20
            Timer1.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            'e.Cancel = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Try
            m_iCount += 1
            If m_iCount >= 100 Then
                m_iCount = 0
                Me.Hide()
                Timer1.Enabled = False
            End If
        Catch ex As Exception
            Timer1.Enabled = False
        End Try
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Try
            pOpenSettingForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Private/Public procedure and function"
    Public Sub pLoadConnection()
        Try
            Dim sFilePath As String = Path.Combine(Application.StartupPath, "RemoteConnectionDetails.xml")
            If File.Exists(sFilePath) Then
                ModGeneral.dsRDC.Clear()
                ModGeneral.dsRDC.ReadXml(sFilePath)
            Else
                ModGeneral.dsRDC = New DataSet
                Dim dt As New DataTable("dtConnections")
                dt.Columns.Add("ID", GetType(System.Int64))
                dt.Columns.Add("ServerName", GetType(System.String))
                dt.Columns.Add("IPaddress", GetType(System.String))
                dt.Columns.Add("UserName", GetType(System.String))
                dt.Columns.Add("Password", GetType(System.String))
                dt.Columns.Add("Group", GetType(System.String))
                ModGeneral.dsRDC.Tables.Add(dt)

                Dim dtSettings As New DataTable("dtSettings")
                dtSettings.Columns.Add("ID", GetType(System.Int64))
                dtSettings.Columns.Add("Value", GetType(System.String))

                Dim dr As DataRow = dtSettings.NewRow
                dr("ID") = 1
                dr("Value") = "False"
                dtSettings.Rows.Add(dr)
                ModGeneral.dsRDC.Tables.Add(dtSettings)

                If dsRDC IsNot Nothing AndAlso dsRDC.Tables.Count > 0 Then
                    ModGeneral.dsRDC.WriteXml(IO.Path.Combine(Application.StartupPath, "RemoteConnectionDetails.xml"), XmlWriteMode.WriteSchema)
                End If
            End If
            pCreateMenu()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub pCreateMenu()
        Try
            Dim mnuName As ToolStripMenuItem = Nothing
            ctxMenu.Items.Clear()

            If dsRDC IsNot Nothing AndAlso dsRDC.Tables.Count > 0 Then
                dtRDP = dsRDC.Tables("dtConnections").Copy
                dtRDP.DefaultView.Sort = "ServerName"
                dtRDP = dtRDP.DefaultView.ToTable

                'Dim iCount As Integer = ctxMenu.Items.Count
                For Each drGroup As DataRow In dsRDC.Tables(0).DefaultView.ToTable(True, "Group").Rows
                    Dim mnuGroup As ToolStripMenuItem
                    mnuGroup = New ToolStripMenuItem(drGroup("Group"), My.Resources.PC_a_icon, New EventHandler(AddressOf Me.mnuMain123_Click))

                    'ctxMenu.Items.Add(drGroup("Group"), My.Resources.PC_a_icon, New EventHandler(AddressOf Me.mnuMain123_Click))
                    'Dim mnuGroup As ToolStripMenuItem = ctxMenu.Items(iCount)
                    'iCount += 1
                    'ctxMenu.Items.Add("-")

                    For Each dr As DataRow In dtRDP.Select("Group='" & drGroup("Group") & "'")
                        Dim sDisplayName As String = ""
                        If dr("ServerName").ToString().Trim = "" Then
                            sDisplayName = dr("IPaddress") & " - " & dr("UserName")
                        Else
                            sDisplayName = dr("ServerName") & " - " & dr("IPaddress")
                        End If

                        sDisplayName = sDisplayName.Replace("&", "&&")
                        mnuName = New ToolStripMenuItem(sDisplayName, My.Resources.Network_Remote_Desktop_icon, New EventHandler(AddressOf Me.mnuConnectTo_Click), dr("IPaddress").ToString)
                        mnuGroup.DropDownItems.Add(mnuName)
                    Next
                    ctxMenu.Items.Add(mnuGroup)
                    ctxMenu.Items.Add("-")
                Next

                If dsRDC IsNot Nothing AndAlso dsRDC.Tables.Count > 1 AndAlso dsRDC.Tables(1).Rows.Count > 0 Then
                    Dim dr() As DataRow = dsRDC.Tables(1).Select("Id=1")
                    If dr.Length > 0 Then
                        WithDrive = dr(0).Item("Value")
                    End If
                End If
            End If

            ctxMenu.Items.Add("&About", My.Resources.user_info_icon, New EventHandler(AddressOf Me.mnuAbout_Click))
            ctxMenu.Items.Add("&Settings", My.Resources.settings_icon, New EventHandler(AddressOf Me.mnuSettings_Click))
            ctxMenu.Items.Add("&Exit", My.Resources.logout, New EventHandler(AddressOf Me.mnuExit_Click))


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub pOpenSettingForm()
        Try
            If objfrmSettings Is Nothing Then
                objfrmSettings = New frmSettings()
                objfrmSettings.ShowDialog()
                objfrmSettings = Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
End Class