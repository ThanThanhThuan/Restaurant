<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCards_POS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCards_POS))
        Me.lblSet = New System.Windows.Forms.Label()
        Me.btnCreditCard = New System.Windows.Forms.Button()
        Me.btnDebitCard = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblSet
        '
        Me.lblSet.AutoSize = True
        Me.lblSet.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSet.ForeColor = System.Drawing.Color.Black
        Me.lblSet.Location = New System.Drawing.Point(12, 4)
        Me.lblSet.Name = "lblSet"
        Me.lblSet.Size = New System.Drawing.Size(23, 13)
        Me.lblSet.TabIndex = 321
        Me.lblSet.Text = "Set"
        Me.lblSet.Visible = False
        '
        'btnCreditCard
        '
        Me.btnCreditCard.AutoSize = True
        Me.btnCreditCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnCreditCard.FlatAppearance.BorderSize = 0
        Me.btnCreditCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreditCard.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreditCard.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCreditCard.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCreditCard.Location = New System.Drawing.Point(15, 35)
        Me.btnCreditCard.Name = "btnCreditCard"
        Me.btnCreditCard.Size = New System.Drawing.Size(217, 120)
        Me.btnCreditCard.TabIndex = 323
        Me.btnCreditCard.Text = "Credit Card"
        Me.btnCreditCard.UseVisualStyleBackColor = False
        '
        'btnDebitCard
        '
        Me.btnDebitCard.AutoSize = True
        Me.btnDebitCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnDebitCard.FlatAppearance.BorderSize = 0
        Me.btnDebitCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDebitCard.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDebitCard.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDebitCard.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDebitCard.Location = New System.Drawing.Point(238, 35)
        Me.btnDebitCard.Name = "btnDebitCard"
        Me.btnDebitCard.Size = New System.Drawing.Size(217, 120)
        Me.btnDebitCard.TabIndex = 324
        Me.btnDebitCard.Text = "Debit Card"
        Me.btnDebitCard.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(424, -3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(37, 36)
        Me.btnClose.TabIndex = 325
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'frmCards_POS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(462, 165)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDebitCard)
        Me.Controls.Add(Me.btnCreditCard)
        Me.Controls.Add(Me.lblSet)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCards_POS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSet As System.Windows.Forms.Label
    Friend WithEvents btnCreditCard As System.Windows.Forms.Button
    Friend WithEvents btnDebitCard As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
