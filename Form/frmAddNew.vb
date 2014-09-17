Imports System.Text.RegularExpressions
Imports System.IO

Public Class frmAddNew

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Dim IpReg As New Regex("^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$")
            Dim WebReg As New Regex("([-\w\.]+)+(:\d+)$")

            If txtServerName.Text = "" Then
                MessageBox.Show("Please enter Server Name", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtServerName.Focus()
            ElseIf txtIPAddress.Text = "" Then
                MessageBox.Show("Please enter IP Address", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtIPAddress.Focus()
            ElseIf IpReg.IsMatch(txtIPAddress.Text.Trim) = False AndAlso WebReg.IsMatch(txtIPAddress.Text.Trim) = False Then
                MessageBox.Show("IPAddress/Url not valid", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtIPAddress.Focus()
            ElseIf txtUsername.Text = "" Then
                MessageBox.Show("Please enter Username", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtUsername.Focus()
            ElseIf txtPassword.Text = "" Then
                MessageBox.Show("Please enter Password", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtPassword.Focus()
            ElseIf cmbGroup.Text = "" Then
                MessageBox.Show("Please enter Group", My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                cmbGroup.Focus()
            Else
                Dim MaxId = ModGeneral.dsRDC.Tables("dtConnections").Compute("Max(Id)", "")
                Dim iId As Int64 = -1

                If IsDBNull(MaxId) Then
                    iId = 1
                Else
                    iId = MaxId + 1
                End If

                Dim dr As DataRow = ModGeneral.dsRDC.Tables("dtConnections").NewRow
                dr("Id") = iId
                dr("IPaddress") = txtIPAddress.Text
                dr("UserName") = txtUsername.Text
                dr("Password") = clsDesCrypto.fnEncryptR(txtPassword.Text)
                dr("ServerName") = txtServerName.Text
                dr("Group") = cmbGroup.Text
                ModGeneral.dsRDC.Tables("dtConnections").Rows.Add(dr)
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmAddNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim sFilePath As String = Path.Combine(Application.StartupPath, "RemoteConnectionDetails.xml")
            If File.Exists(sFilePath) Then
                ModGeneral.dsRDC.Clear()
                ModGeneral.dsRDC.ReadXml(sFilePath)
            Else
                ModGeneral.dsRDC = New DataSet
                Dim dt As New DataTable("dtConnections")
                dt.Columns.Add("ID", GetType(System.Int64))
                dt.Columns.Add("IPaddress", GetType(System.String))
                dt.Columns.Add("UserName", GetType(System.String))
                dt.Columns.Add("Password", GetType(System.String))
                dt.Columns.Add("ServerName", GetType(System.String))
                dt.Columns.Add("Group", GetType(System.String))
                ModGeneral.dsRDC.Tables.Add(dt)
            End If

            For Each dr As DataRow In dsRDC.Tables(0).DefaultView.ToTable(True, "Group").Rows
                cmbGroup.Items.Add(dr("Group"))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class