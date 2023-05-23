<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHomeDelivery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHomeDelivery))
        Me.lblUser = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.btnDeliveryPerson = New System.Windows.Forms.Button()
        Me.btnCustomerEntry = New System.Windows.Forms.Button()
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
        'btnDeliveryPerson
        '
        Me.btnDeliveryPerson.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeliveryPerson.AutoSize = True
        Me.btnDeliveryPerson.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnDeliveryPerson.FlatAppearance.BorderSize = 0
        Me.btnDeliveryPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeliveryPerson.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeliveryPerson.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDeliveryPerson.Image = CType(resources.GetObject("btnDeliveryPerson.Image"), System.Drawing.Image)
        Me.btnDeliveryPerson.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDeliveryPerson.Location = New System.Drawing.Point(238, 36)
        Me.btnDeliveryPerson.Name = "btnDeliveryPerson"
        Me.btnDeliveryPerson.Size = New System.Drawing.Size(217, 65)
        Me.btnDeliveryPerson.TabIndex = 324
        Me.btnDeliveryPerson.Text = "Delivery Person"
        Me.btnDeliveryPerson.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDeliveryPerson.UseVisualStyleBackColor = False
        '
        'btnCustomerEntry
        '
        Me.btnCustomerEntry.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCustomerEntry.AutoSize = True
        Me.btnCustomerEntry.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnCustomerEntry.FlatAppearance.BorderSize = 0
        Me.btnCustomerEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCustomerEntry.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomerEntry.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCustomerEntry.Image = CType(resources.GetObject("btnCustomerEntry.Image"), System.Drawing.Image)
        Me.btnCustomerEntry.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCustomerEntry.Location = New System.Drawing.Point(15, 36)
        Me.btnCustomerEntry.Name = "btnCustomerEntry"
        Me.btnCustomerEntry.Size = New System.Drawing.Size(217, 65)
        Me.btnCustomerEntry.TabIndex = 323
        Me.btnCustomerEntry.Text = "Customer Entry"
        Me.btnCustomerEntry.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCustomerEntry.UseVisualStyleBackColor = False
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
        'frmHomeDelivery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(462, 109)
        Me.Controls.Add(Me.btnDeliveryPerson)
        Me.Controls.Add(Me.btnCustomerEntry)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmHomeDelivery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnCustomerEntry As System.Windows.Forms.Button
    Friend WithEvents btnDeliveryPerson As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
