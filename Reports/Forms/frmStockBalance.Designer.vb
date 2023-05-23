<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockBalance
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
        Me.rptstkBalance = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rptstkBalance
        '
        Me.rptstkBalance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptstkBalance.LocalReport.ReportEmbeddedResource = "RestaurantPOS6.stockBalance.rdlc"
        Me.rptstkBalance.Location = New System.Drawing.Point(0, 0)
        Me.rptstkBalance.Name = "rptstkBalance"
        Me.rptstkBalance.Size = New System.Drawing.Size(704, 417)
        Me.rptstkBalance.TabIndex = 0
        '
        'frmStockBalance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 417)
        Me.Controls.Add(Me.rptstkBalance)
        Me.MinimizeBox = False
        Me.Name = "frmStockBalance"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Balance (Kitchen)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rptstkBalance As Microsoft.Reporting.WinForms.ReportViewer
End Class
