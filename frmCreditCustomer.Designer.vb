<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreditCustomer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreditCustomer))
        Me.lblUser = New System.Windows.Forms.Label()
        Me.btnCustomerLedger = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnReceipt = New System.Windows.Forms.Button()
        Me.btnCreditCustomer = New System.Windows.Forms.Button()
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
        'btnCustomerLedger
        '
        Me.btnCustomerLedger.AutoSize = True
        Me.btnCustomerLedger.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnCustomerLedger.FlatAppearance.BorderSize = 0
        Me.btnCustomerLedger.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCustomerLedger.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomerLedger.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCustomerLedger.Image = CType(resources.GetObject("btnCustomerLedger.Image"), System.Drawing.Image)
        Me.btnCustomerLedger.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCustomerLedger.Location = New System.Drawing.Point(12, 114)
        Me.btnCustomerLedger.Name = "btnCustomerLedger"
        Me.btnCustomerLedger.Size = New System.Drawing.Size(217, 76)
        Me.btnCustomerLedger.TabIndex = 324
        Me.btnCustomerLedger.Text = "Customer Ledger"
        Me.btnCustomerLedger.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCustomerLedger.UseVisualStyleBackColor = False
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
        'btnReceipt
        '
        Me.btnReceipt.AutoSize = True
        Me.btnReceipt.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnReceipt.FlatAppearance.BorderSize = 0
        Me.btnReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReceipt.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceipt.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnReceipt.Image = CType(resources.GetObject("btnReceipt.Image"), System.Drawing.Image)
        Me.btnReceipt.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReceipt.Location = New System.Drawing.Point(235, 32)
        Me.btnReceipt.Name = "btnReceipt"
        Me.btnReceipt.Size = New System.Drawing.Size(217, 76)
        Me.btnReceipt.TabIndex = 52
        Me.btnReceipt.Text = "Receipt"
        Me.btnReceipt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReceipt.UseVisualStyleBackColor = False
        '
        'btnCreditCustomer
        '
        Me.btnCreditCustomer.AutoSize = True
        Me.btnCreditCustomer.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnCreditCustomer.FlatAppearance.BorderSize = 0
        Me.btnCreditCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreditCustomer.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreditCustomer.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCreditCustomer.Image = CType(resources.GetObject("btnCreditCustomer.Image"), System.Drawing.Image)
        Me.btnCreditCustomer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCreditCustomer.Location = New System.Drawing.Point(12, 32)
        Me.btnCreditCustomer.Name = "btnCreditCustomer"
        Me.btnCreditCustomer.Size = New System.Drawing.Size(217, 76)
        Me.btnCreditCustomer.TabIndex = 28
        Me.btnCreditCustomer.Text = "Credit Customer"
        Me.btnCreditCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCreditCustomer.UseVisualStyleBackColor = False
        '
        'frmCreditCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(462, 200)
        Me.Controls.Add(Me.btnCustomerLedger)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.btnReceipt)
        Me.Controls.Add(Me.btnCreditCustomer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCreditCustomer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCreditCustomer As System.Windows.Forms.Button
    Friend WithEvents btnReceipt As System.Windows.Forms.Button
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnCustomerLedger As System.Windows.Forms.Button
End Class
