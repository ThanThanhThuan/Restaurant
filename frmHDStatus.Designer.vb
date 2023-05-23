<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHDStatus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHDStatus))
        Me.btnDelivered = New System.Windows.Forms.Button()
        Me.btnCancelled = New System.Windows.Forms.Button()
        Me.txtHdID = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnDelivered
        '
        Me.btnDelivered.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnDelivered.FlatAppearance.BorderSize = 0
        Me.btnDelivered.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelivered.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelivered.ForeColor = System.Drawing.Color.White
        Me.btnDelivered.Location = New System.Drawing.Point(13, 12)
        Me.btnDelivered.Name = "btnDelivered"
        Me.btnDelivered.Size = New System.Drawing.Size(282, 88)
        Me.btnDelivered.TabIndex = 1
        Me.btnDelivered.Text = "Delivered"
        Me.btnDelivered.UseVisualStyleBackColor = False
        '
        'btnCancelled
        '
        Me.btnCancelled.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnCancelled.FlatAppearance.BorderSize = 0
        Me.btnCancelled.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelled.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelled.ForeColor = System.Drawing.Color.White
        Me.btnCancelled.Location = New System.Drawing.Point(12, 106)
        Me.btnCancelled.Name = "btnCancelled"
        Me.btnCancelled.Size = New System.Drawing.Size(282, 88)
        Me.btnCancelled.TabIndex = 2
        Me.btnCancelled.Text = "Cancelled"
        Me.btnCancelled.UseVisualStyleBackColor = False
        '
        'txtHdID
        '
        Me.txtHdID.Location = New System.Drawing.Point(82, 12)
        Me.txtHdID.Name = "txtHdID"
        Me.txtHdID.Size = New System.Drawing.Size(100, 20)
        Me.txtHdID.TabIndex = 3
        Me.txtHdID.Visible = False
        '
        'frmHDStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(307, 204)
        Me.Controls.Add(Me.txtHdID)
        Me.Controls.Add(Me.btnCancelled)
        Me.Controls.Add(Me.btnDelivered)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHDStatus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Status"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDelivered As System.Windows.Forms.Button
    Friend WithEvents btnCancelled As System.Windows.Forms.Button
    Friend WithEvents txtHdID As System.Windows.Forms.TextBox
End Class
