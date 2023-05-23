<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockAdjustment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockAdjustment))
        Me.btnStockTransfer_W2S = New System.Windows.Forms.Button()
        Me.btnStockTransfer_W2W = New System.Windows.Forms.Button()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnStockTransfer_W2S
        '
        Me.btnStockTransfer_W2S.AutoSize = True
        Me.btnStockTransfer_W2S.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnStockTransfer_W2S.FlatAppearance.BorderSize = 0
        Me.btnStockTransfer_W2S.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStockTransfer_W2S.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockTransfer_W2S.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnStockTransfer_W2S.Location = New System.Drawing.Point(12, 32)
        Me.btnStockTransfer_W2S.Name = "btnStockTransfer_W2S"
        Me.btnStockTransfer_W2S.Size = New System.Drawing.Size(217, 65)
        Me.btnStockTransfer_W2S.TabIndex = 28
        Me.btnStockTransfer_W2S.Text = "Kitchen"
        Me.btnStockTransfer_W2S.UseVisualStyleBackColor = False
        '
        'btnStockTransfer_W2W
        '
        Me.btnStockTransfer_W2W.AutoSize = True
        Me.btnStockTransfer_W2W.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnStockTransfer_W2W.FlatAppearance.BorderSize = 0
        Me.btnStockTransfer_W2W.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStockTransfer_W2W.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockTransfer_W2W.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnStockTransfer_W2W.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnStockTransfer_W2W.Location = New System.Drawing.Point(235, 32)
        Me.btnStockTransfer_W2W.Name = "btnStockTransfer_W2W"
        Me.btnStockTransfer_W2W.Size = New System.Drawing.Size(217, 65)
        Me.btnStockTransfer_W2W.TabIndex = 29
        Me.btnStockTransfer_W2W.Text = "Warehouse"
        Me.btnStockTransfer_W2W.UseVisualStyleBackColor = False
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(393, 8)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(29, 13)
        Me.lblUser.TabIndex = 323
        Me.lblUser.Text = "User"
        Me.lblUser.Visible = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(428, -5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(37, 36)
        Me.btnClose.TabIndex = 322
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'frmStockAdjustment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(462, 108)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnStockTransfer_W2W)
        Me.Controls.Add(Me.btnStockTransfer_W2S)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStockAdjustment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStockTransfer_W2S As System.Windows.Forms.Button
    Friend WithEvents btnStockTransfer_W2W As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblUser As System.Windows.Forms.Label
End Class
