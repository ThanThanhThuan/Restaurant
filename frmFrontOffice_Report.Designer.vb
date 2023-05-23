<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFrontOffice_Report
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFrontOffice_Report))
        Me.lblUser = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.btnWorkPeriodReport = New System.Windows.Forms.Button()
        Me.btnPOSReport = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.Black
        Me.lblUser.Location = New System.Drawing.Point(12, 4)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(43, 13)
        Me.lblUser.TabIndex = 321
        Me.lblUser.Text = "lblUser"
        Me.lblUser.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnWorkPeriodReport
        '
        Me.btnWorkPeriodReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWorkPeriodReport.AutoSize = True
        Me.btnWorkPeriodReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnWorkPeriodReport.FlatAppearance.BorderSize = 0
        Me.btnWorkPeriodReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkPeriodReport.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorkPeriodReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnWorkPeriodReport.Image = CType(resources.GetObject("btnWorkPeriodReport.Image"), System.Drawing.Image)
        Me.btnWorkPeriodReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWorkPeriodReport.Location = New System.Drawing.Point(238, 36)
        Me.btnWorkPeriodReport.Name = "btnWorkPeriodReport"
        Me.btnWorkPeriodReport.Size = New System.Drawing.Size(217, 76)
        Me.btnWorkPeriodReport.TabIndex = 324
        Me.btnWorkPeriodReport.Text = "Work Period Report"
        Me.btnWorkPeriodReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWorkPeriodReport.UseVisualStyleBackColor = False
        '
        'btnPOSReport
        '
        Me.btnPOSReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPOSReport.AutoSize = True
        Me.btnPOSReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnPOSReport.FlatAppearance.BorderSize = 0
        Me.btnPOSReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPOSReport.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPOSReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPOSReport.Image = CType(resources.GetObject("btnPOSReport.Image"), System.Drawing.Image)
        Me.btnPOSReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPOSReport.Location = New System.Drawing.Point(15, 36)
        Me.btnPOSReport.Name = "btnPOSReport"
        Me.btnPOSReport.Size = New System.Drawing.Size(217, 76)
        Me.btnPOSReport.TabIndex = 323
        Me.btnPOSReport.Text = "POS Report"
        Me.btnPOSReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPOSReport.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(428, -2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(37, 36)
        Me.btnClose.TabIndex = 322
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'frmFrontOffice_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(462, 120)
        Me.Controls.Add(Me.btnWorkPeriodReport)
        Me.Controls.Add(Me.btnPOSReport)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmFrontOffice_Report"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPOSReport As System.Windows.Forms.Button
    Friend WithEvents btnWorkPeriodReport As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
