<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.gpMain = New System.Windows.Forms.GroupBox()
        Me.chkWithDrives = New System.Windows.Forms.CheckBox()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.dgvConnectionDetails = New System.Windows.Forms.DataGridView()
        Me.ColDel = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ColId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SrNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColServerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPaddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColUsername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gpMain.SuspendLayout()
        CType(Me.dgvConnectionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpMain
        '
        Me.gpMain.Controls.Add(Me.chkWithDrives)
        Me.gpMain.Controls.Add(Me.btnAddNew)
        Me.gpMain.Controls.Add(Me.dgvConnectionDetails)
        Me.gpMain.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gpMain.Location = New System.Drawing.Point(6, 2)
        Me.gpMain.Name = "gpMain"
        Me.gpMain.Size = New System.Drawing.Size(674, 394)
        Me.gpMain.TabIndex = 0
        Me.gpMain.TabStop = False
        Me.gpMain.Text = "Connection Details"
        '
        'chkWithDrives
        '
        Me.chkWithDrives.AutoSize = True
        Me.chkWithDrives.Location = New System.Drawing.Point(533, 27)
        Me.chkWithDrives.Name = "chkWithDrives"
        Me.chkWithDrives.Size = New System.Drawing.Size(135, 19)
        Me.chkWithDrives.TabIndex = 1
        Me.chkWithDrives.Text = "Connect with Drives"
        Me.chkWithDrives.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddNew.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnAddNew.FlatAppearance.BorderSize = 0
        Me.btnAddNew.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.Location = New System.Drawing.Point(8, 19)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(171, 27)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "Add &New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'dgvConnectionDetails
        '
        Me.dgvConnectionDetails.AllowUserToAddRows = False
        Me.dgvConnectionDetails.AllowUserToDeleteRows = False
        Me.dgvConnectionDetails.AllowUserToOrderColumns = True
        Me.dgvConnectionDetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.dgvConnectionDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvConnectionDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConnectionDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColDel, Me.ColId, Me.SrNo, Me.ColServerName, Me.ColIPaddress, Me.ColUsername, Me.ColPassword, Me.ColGroup})
        Me.dgvConnectionDetails.Location = New System.Drawing.Point(8, 50)
        Me.dgvConnectionDetails.Name = "dgvConnectionDetails"
        Me.dgvConnectionDetails.ReadOnly = True
        Me.dgvConnectionDetails.RowHeadersVisible = False
        Me.dgvConnectionDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConnectionDetails.Size = New System.Drawing.Size(660, 336)
        Me.dgvConnectionDetails.TabIndex = 2
        '
        'ColDel
        '
        Me.ColDel.HeaderText = ""
        Me.ColDel.Image = Global.RemoteDesktopConnection.My.Resources.Resources.DeleteRed1
        Me.ColDel.Name = "ColDel"
        Me.ColDel.ReadOnly = True
        Me.ColDel.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColDel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColDel.ToolTipText = "Delete"
        Me.ColDel.Width = 30
        '
        'ColId
        '
        Me.ColId.DataPropertyName = "Id"
        Me.ColId.HeaderText = "Id"
        Me.ColId.Name = "ColId"
        Me.ColId.ReadOnly = True
        Me.ColId.Visible = False
        '
        'SrNo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SrNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.SrNo.HeaderText = "Sr.No"
        Me.SrNo.Name = "SrNo"
        Me.SrNo.ReadOnly = True
        Me.SrNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SrNo.Width = 45
        '
        'ColServerName
        '
        Me.ColServerName.DataPropertyName = "ServerName"
        Me.ColServerName.HeaderText = "Server Name"
        Me.ColServerName.Name = "ColServerName"
        Me.ColServerName.ReadOnly = True
        Me.ColServerName.Width = 130
        '
        'ColIPaddress
        '
        Me.ColIPaddress.DataPropertyName = "IPaddress"
        Me.ColIPaddress.HeaderText = "IP Address"
        Me.ColIPaddress.Name = "ColIPaddress"
        Me.ColIPaddress.ReadOnly = True
        Me.ColIPaddress.Width = 130
        '
        'ColUsername
        '
        Me.ColUsername.DataPropertyName = "UserName"
        Me.ColUsername.HeaderText = "Username"
        Me.ColUsername.Name = "ColUsername"
        Me.ColUsername.ReadOnly = True
        Me.ColUsername.Width = 140
        '
        'ColPassword
        '
        Me.ColPassword.DataPropertyName = "Password"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.ColPassword.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColPassword.HeaderText = "Password"
        Me.ColPassword.Name = "ColPassword"
        Me.ColPassword.ReadOnly = True
        Me.ColPassword.Visible = False
        '
        'ColGroup
        '
        Me.ColGroup.DataPropertyName = "Group"
        Me.ColGroup.HeaderText = "Group"
        Me.ColGroup.Name = "ColGroup"
        Me.ColGroup.ReadOnly = True
        Me.ColGroup.Width = 150
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 403)
        Me.Controls.Add(Me.gpMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.gpMain.ResumeLayout(False)
        Me.gpMain.PerformLayout()
        CType(Me.dgvConnectionDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpMain As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents dgvConnectionDetails As System.Windows.Forms.DataGridView
    Friend WithEvents chkWithDrives As System.Windows.Forms.CheckBox
    Friend WithEvents ColDel As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ColId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SrNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColServerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPaddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColUsername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPassword As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGroup As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
