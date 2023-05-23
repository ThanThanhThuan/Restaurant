<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.lblUser = New System.Windows.Forms.Label()
        Me.btnExpenses = New System.Windows.Forms.Button()
        Me.btnExpenseType = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnEmailSetting = New System.Windows.Forms.Button()
        Me.btnOtherCharges = New System.Windows.Forms.Button()
        Me.btnTerminalSetting = New System.Windows.Forms.Button()
        Me.btnUnit = New System.Windows.Forms.Button()
        Me.btnCategoryMaster = New System.Windows.Forms.Button()
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
        'btnExpenses
        '
        Me.btnExpenses.AutoSize = True
        Me.btnExpenses.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnExpenses.FlatAppearance.BorderSize = 0
        Me.btnExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExpenses.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpenses.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExpenses.Image = CType(resources.GetObject("btnExpenses.Image"), System.Drawing.Image)
        Me.btnExpenses.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExpenses.Location = New System.Drawing.Point(12, 173)
        Me.btnExpenses.Name = "btnExpenses"
        Me.btnExpenses.Size = New System.Drawing.Size(217, 65)
        Me.btnExpenses.TabIndex = 326
        Me.btnExpenses.Text = "Expense Master"
        Me.btnExpenses.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExpenses.UseVisualStyleBackColor = False
        '
        'btnExpenseType
        '
        Me.btnExpenseType.AutoSize = True
        Me.btnExpenseType.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnExpenseType.FlatAppearance.BorderSize = 0
        Me.btnExpenseType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExpenseType.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpenseType.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExpenseType.Image = CType(resources.GetObject("btnExpenseType.Image"), System.Drawing.Image)
        Me.btnExpenseType.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExpenseType.Location = New System.Drawing.Point(235, 103)
        Me.btnExpenseType.Name = "btnExpenseType"
        Me.btnExpenseType.Size = New System.Drawing.Size(217, 65)
        Me.btnExpenseType.TabIndex = 325
        Me.btnExpenseType.Text = "Expense Type Master"
        Me.btnExpenseType.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExpenseType.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.AutoSize = True
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(12, 103)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(217, 65)
        Me.Button1.TabIndex = 323
        Me.Button1.Text = "SMS Setting"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
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
        'btnEmailSetting
        '
        Me.btnEmailSetting.AutoSize = True
        Me.btnEmailSetting.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnEmailSetting.FlatAppearance.BorderSize = 0
        Me.btnEmailSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmailSetting.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmailSetting.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnEmailSetting.Image = CType(resources.GetObject("btnEmailSetting.Image"), System.Drawing.Image)
        Me.btnEmailSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEmailSetting.Location = New System.Drawing.Point(235, 32)
        Me.btnEmailSetting.Name = "btnEmailSetting"
        Me.btnEmailSetting.Size = New System.Drawing.Size(217, 65)
        Me.btnEmailSetting.TabIndex = 52
        Me.btnEmailSetting.Text = "Email Setting"
        Me.btnEmailSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEmailSetting.UseVisualStyleBackColor = False
        '
        'btnOtherCharges
        '
        Me.btnOtherCharges.AutoSize = True
        Me.btnOtherCharges.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnOtherCharges.FlatAppearance.BorderSize = 0
        Me.btnOtherCharges.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOtherCharges.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOtherCharges.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnOtherCharges.Image = CType(resources.GetObject("btnOtherCharges.Image"), System.Drawing.Image)
        Me.btnOtherCharges.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnOtherCharges.Location = New System.Drawing.Point(235, 242)
        Me.btnOtherCharges.Name = "btnOtherCharges"
        Me.btnOtherCharges.Size = New System.Drawing.Size(217, 65)
        Me.btnOtherCharges.TabIndex = 51
        Me.btnOtherCharges.Text = "Other Settings"
        Me.btnOtherCharges.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOtherCharges.UseVisualStyleBackColor = False
        '
        'btnTerminalSetting
        '
        Me.btnTerminalSetting.AutoSize = True
        Me.btnTerminalSetting.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnTerminalSetting.FlatAppearance.BorderSize = 0
        Me.btnTerminalSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTerminalSetting.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTerminalSetting.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnTerminalSetting.Image = CType(resources.GetObject("btnTerminalSetting.Image"), System.Drawing.Image)
        Me.btnTerminalSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTerminalSetting.Location = New System.Drawing.Point(12, 32)
        Me.btnTerminalSetting.Name = "btnTerminalSetting"
        Me.btnTerminalSetting.Size = New System.Drawing.Size(217, 65)
        Me.btnTerminalSetting.TabIndex = 28
        Me.btnTerminalSetting.Text = "Terminal Setting"
        Me.btnTerminalSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTerminalSetting.UseVisualStyleBackColor = False
        '
        'btnUnit
        '
        Me.btnUnit.AutoSize = True
        Me.btnUnit.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnUnit.FlatAppearance.BorderSize = 0
        Me.btnUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUnit.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnit.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnUnit.Image = CType(resources.GetObject("btnUnit.Image"), System.Drawing.Image)
        Me.btnUnit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUnit.Location = New System.Drawing.Point(235, 173)
        Me.btnUnit.Name = "btnUnit"
        Me.btnUnit.Size = New System.Drawing.Size(217, 65)
        Me.btnUnit.TabIndex = 327
        Me.btnUnit.Text = "Unit Master"
        Me.btnUnit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUnit.UseVisualStyleBackColor = False
        '
        'btnCategoryMaster
        '
        Me.btnCategoryMaster.AutoSize = True
        Me.btnCategoryMaster.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnCategoryMaster.FlatAppearance.BorderSize = 0
        Me.btnCategoryMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCategoryMaster.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCategoryMaster.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCategoryMaster.Image = CType(resources.GetObject("btnCategoryMaster.Image"), System.Drawing.Image)
        Me.btnCategoryMaster.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCategoryMaster.Location = New System.Drawing.Point(12, 242)
        Me.btnCategoryMaster.Name = "btnCategoryMaster"
        Me.btnCategoryMaster.Size = New System.Drawing.Size(217, 65)
        Me.btnCategoryMaster.TabIndex = 328
        Me.btnCategoryMaster.Text = "Products Category"
        Me.btnCategoryMaster.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCategoryMaster.UseVisualStyleBackColor = False
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(462, 317)
        Me.Controls.Add(Me.btnCategoryMaster)
        Me.Controls.Add(Me.btnUnit)
        Me.Controls.Add(Me.btnExpenses)
        Me.Controls.Add(Me.btnExpenseType)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.btnEmailSetting)
        Me.Controls.Add(Me.btnOtherCharges)
        Me.Controls.Add(Me.btnTerminalSetting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnTerminalSetting As System.Windows.Forms.Button
    Friend WithEvents btnOtherCharges As System.Windows.Forms.Button
    Friend WithEvents btnEmailSetting As System.Windows.Forms.Button
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnExpenseType As System.Windows.Forms.Button
    Friend WithEvents btnExpenses As System.Windows.Forms.Button
    Friend WithEvents btnUnit As System.Windows.Forms.Button
    Friend WithEvents btnCategoryMaster As System.Windows.Forms.Button
End Class
