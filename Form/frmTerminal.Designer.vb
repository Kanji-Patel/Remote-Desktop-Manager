<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTerminal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTerminal))
        Me.RemoteDisplay = New AxMSTSCLib.AxMsRdpClient2()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblConnectingTo = New System.Windows.Forms.Label()
        CType(Me.RemoteDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RemoteDisplay
        '
        Me.RemoteDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RemoteDisplay.Enabled = True
        Me.RemoteDisplay.Location = New System.Drawing.Point(0, 0)
        Me.RemoteDisplay.Name = "RemoteDisplay"
        Me.RemoteDisplay.OcxState = CType(resources.GetObject("RemoteDisplay.OcxState"), System.Windows.Forms.AxHost.State)
        Me.RemoteDisplay.Size = New System.Drawing.Size(804, 463)
        Me.RemoteDisplay.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'lblConnectingTo
        '
        Me.lblConnectingTo.BackColor = System.Drawing.Color.Transparent
        Me.lblConnectingTo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblConnectingTo.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.lblConnectingTo.Location = New System.Drawing.Point(0, 0)
        Me.lblConnectingTo.Name = "lblConnectingTo"
        Me.lblConnectingTo.Size = New System.Drawing.Size(804, 23)
        Me.lblConnectingTo.TabIndex = 1
        Me.lblConnectingTo.Text = "Connecting..."
        Me.lblConnectingTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmTerminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 463)
        Me.Controls.Add(Me.lblConnectingTo)
        Me.Controls.Add(Me.RemoteDisplay)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(812, 497)
        Me.Name = "frmTerminal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Terminal"
        CType(Me.RemoteDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RemoteDisplay As AxMSTSCLib.AxMsRdpClient2
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblConnectingTo As System.Windows.Forms.Label
End Class
