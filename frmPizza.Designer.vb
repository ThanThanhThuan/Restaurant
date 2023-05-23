<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPizza
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPizza))
        Me.lblUser = New System.Windows.Forms.Label()
        Me.btnPizzaMaster = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPizzaToppings = New System.Windows.Forms.Button()
        Me.btnPizzaSize = New System.Windows.Forms.Button()
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
        'btnPizzaMaster
        '
        Me.btnPizzaMaster.AutoSize = True
        Me.btnPizzaMaster.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnPizzaMaster.FlatAppearance.BorderSize = 0
        Me.btnPizzaMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPizzaMaster.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPizzaMaster.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPizzaMaster.Image = CType(resources.GetObject("btnPizzaMaster.Image"), System.Drawing.Image)
        Me.btnPizzaMaster.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPizzaMaster.Location = New System.Drawing.Point(12, 103)
        Me.btnPizzaMaster.Name = "btnPizzaMaster"
        Me.btnPizzaMaster.Size = New System.Drawing.Size(217, 65)
        Me.btnPizzaMaster.TabIndex = 323
        Me.btnPizzaMaster.Text = "Pizza Master"
        Me.btnPizzaMaster.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPizzaMaster.UseVisualStyleBackColor = False
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
        'btnPizzaToppings
        '
        Me.btnPizzaToppings.AutoSize = True
        Me.btnPizzaToppings.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnPizzaToppings.FlatAppearance.BorderSize = 0
        Me.btnPizzaToppings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPizzaToppings.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPizzaToppings.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPizzaToppings.Image = CType(resources.GetObject("btnPizzaToppings.Image"), System.Drawing.Image)
        Me.btnPizzaToppings.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPizzaToppings.Location = New System.Drawing.Point(235, 32)
        Me.btnPizzaToppings.Name = "btnPizzaToppings"
        Me.btnPizzaToppings.Size = New System.Drawing.Size(217, 65)
        Me.btnPizzaToppings.TabIndex = 52
        Me.btnPizzaToppings.Text = "Pizza Toppings"
        Me.btnPizzaToppings.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPizzaToppings.UseVisualStyleBackColor = False
        '
        'btnPizzaSize
        '
        Me.btnPizzaSize.AutoSize = True
        Me.btnPizzaSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnPizzaSize.FlatAppearance.BorderSize = 0
        Me.btnPizzaSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPizzaSize.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPizzaSize.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPizzaSize.Image = CType(resources.GetObject("btnPizzaSize.Image"), System.Drawing.Image)
        Me.btnPizzaSize.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPizzaSize.Location = New System.Drawing.Point(12, 32)
        Me.btnPizzaSize.Name = "btnPizzaSize"
        Me.btnPizzaSize.Size = New System.Drawing.Size(217, 65)
        Me.btnPizzaSize.TabIndex = 28
        Me.btnPizzaSize.Text = "Pizza Size"
        Me.btnPizzaSize.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPizzaSize.UseVisualStyleBackColor = False
        '
        'frmPizza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(462, 178)
        Me.Controls.Add(Me.btnPizzaMaster)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.btnPizzaToppings)
        Me.Controls.Add(Me.btnPizzaSize)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPizza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPizzaSize As System.Windows.Forms.Button
    Friend WithEvents btnPizzaToppings As System.Windows.Forms.Button
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPizzaMaster As System.Windows.Forms.Button
End Class
