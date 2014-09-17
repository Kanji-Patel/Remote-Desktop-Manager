Imports System.IO

Public Class frmSettings

#Region "Form Related Code"
    Private Sub frmSettings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If dsRDC IsNot Nothing AndAlso dsRDC.Tables.Count > 1 AndAlso dsRDC.Tables(1).Rows.Count > 0 Then
                WithDrive = chkWithDrives.Checked
                Dim dr() As DataRow = dsRDC.Tables(1).Select("Id=1")
                If dr.Length > 0 Then
                    dr(0).Item("Value") = WithDrive
                End If
                fnSaveConnections()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkWithDrives_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWithDrives.CheckedChanged
        Try
              WithDrive = chkWithDrives.Checked
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If dsRDC IsNot Nothing AndAlso dsRDC.Tables.Count > 0 Then
                'If ModGeneral.dsRDC.Tables(0).Columns.Contains("Delete") = False Then
                '    ModGeneral.dsRDC.Tables(0).Columns.Add("Delete")
                'End If
                dgvConnectionDetails.DataSource = ModGeneral.dsRDC.Tables(0)
                dgvConnectionDetails.Refresh()
                Application.DoEvents()
                chkWithDrives.Checked = WithDrive
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        Try
            Dim objAddNew As New frmAddNew()
            If objAddNew.ShowDialog() = Windows.Forms.DialogResult.OK Then
                fnSaveConnections()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvConnectionDetails_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConnectionDetails.CellClick
        Try
            If Not dgvConnectionDetails Is Nothing AndAlso e.RowIndex <> -1 AndAlso dgvConnectionDetails.Columns(e.ColumnIndex).Name = "ColDel" Then
                Dim iId As Integer = dgvConnectionDetails.Rows(e.RowIndex).Cells("ColId").Value
                Dim sIPAddress As String = dgvConnectionDetails.Rows(e.RowIndex).Cells("ColIPaddress").Value
                If MessageBox.Show("Are tou sure want to delete """ & sIPAddress & """ IP Address?", My.Application.Info.AssemblyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim drDelete() As DataRow = dsRDC.Tables("dtConnections").Select("Id=" & iId)
                    For Each dr As DataRow In drDelete
                        dsRDC.Tables("dtConnections").Rows.Remove(dr)
                    Next
                    fnSaveConnections()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvConnectionDetails_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvConnectionDetails.DataBindingComplete
        Try
            If Not dgvConnectionDetails Is Nothing AndAlso dgvConnectionDetails.Rows.Count > 0 Then
                For i As Integer = 1 To dgvConnectionDetails.Rows.Count
                    dgvConnectionDetails.Rows(i - 1).Cells("SrNo").Value = i
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
#End Region

#Region "Private/Public procedure and function"
    Private Function fnSaveConnections() As Boolean
        Try
            If dsRDC IsNot Nothing AndAlso dsRDC.Tables.Count > 0 Then
                ModGeneral.dsRDC.WriteXml(IO.Path.Combine(Application.StartupPath, "RemoteConnectionDetails.xml"), XmlWriteMode.WriteSchema)

                frmMain.pLoadConnection()

                dgvConnectionDetails.AutoGenerateColumns = False

                dgvConnectionDetails.DataSource = ModGeneral.dsRDC.Tables(0)
                'dgvConnectionDetails.Columns("Delete") = dgvConnectionDetails.Columns.Count - 1

                dgvConnectionDetails.Refresh()
                Application.DoEvents()
                frmMain.pCreateMenu()

                chkWithDrives.Checked = WithDrive
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
