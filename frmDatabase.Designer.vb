<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatabase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDatabase))
        Me.lblUser = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.btnDBRestore = New System.Windows.Forms.Button()
        Me.btnDBBackup = New System.Windows.Forms.Button()
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
        'Timer2
        '
        '
        'btnDBRestore
        '
        Me.btnDBRestore.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDBRestore.AutoSize = True
        Me.btnDBRestore.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnDBRestore.FlatAppearance.BorderSize = 0
        Me.btnDBRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDBRestore.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDBRestore.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDBRestore.Image = CType(resources.GetObject("btnDBRestore.Image"), System.Drawing.Image)
        Me.btnDBRestore.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDBRestore.Location = New System.Drawing.Point(238, 36)
        Me.btnDBRestore.Name = "btnDBRestore"
        Me.btnDBRestore.Size = New System.Drawing.Size(217, 76)
        Me.btnDBRestore.TabIndex = 324
        Me.btnDBRestore.Text = "DB Restore"
        Me.btnDBRestore.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDBRestore.UseVisualStyleBackColor = False
        '
        'btnDBBackup
        '
        Me.btnDBBackup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDBBackup.AutoSize = True
        Me.btnDBBackup.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnDBBackup.FlatAppearance.BorderSize = 0
        Me.btnDBBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDBBackup.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDBBackup.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDBBackup.Image = CType(resources.GetObject("btnDBBackup.Image"), System.Drawing.Image)
        Me.btnDBBackup.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDBBackup.Location = New System.Drawing.Point(15, 36)
        Me.btnDBBackup.Name = "btnDBBackup"
        Me.btnDBBackup.Size = New System.Drawing.Size(217, 76)
        Me.btnDBBackup.TabIndex = 323
        Me.btnDBBackup.Text = "DB Backup"
        Me.btnDBBackup.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDBBackup.UseVisualStyleBackColor = False
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
        'frmDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(462, 120)
        Me.Controls.Add(Me.btnDBRestore)
        Me.Controls.Add(Me.btnDBBackup)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDatabase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnDBBackup As System.Windows.Forms.Button
    Friend WithEvents btnDBRestore As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
