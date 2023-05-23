<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotes1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotes1))
        Me.txtNotes = New System.Windows.Forms.RichTextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnOkay = New System.Windows.Forms.Button()
        Me.btnKeyboard = New System.Windows.Forms.Button()
        Me.lblSet = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.flpNotes = New System.Windows.Forms.FlowLayoutPanel()
        Me.SuspendLayout()
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotes.Location = New System.Drawing.Point(1, 1)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(190, 284)
        Me.txtNotes.TabIndex = 0
        Me.txtNotes.Text = ""
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClose.Location = New System.Drawing.Point(197, 159)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(116, 47)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnOkay
        '
        Me.btnOkay.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnOkay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOkay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkay.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnOkay.Location = New System.Drawing.Point(197, 1)
        Me.btnOkay.Name = "btnOkay"
        Me.btnOkay.Size = New System.Drawing.Size(116, 47)
        Me.btnOkay.TabIndex = 1
        Me.btnOkay.Text = "&Okay"
        Me.btnOkay.UseVisualStyleBackColor = False
        '
        'btnKeyboard
        '
        Me.btnKeyboard.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnKeyboard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKeyboard.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnKeyboard.Location = New System.Drawing.Point(197, 53)
        Me.btnKeyboard.Name = "btnKeyboard"
        Me.btnKeyboard.Size = New System.Drawing.Size(116, 47)
        Me.btnKeyboard.TabIndex = 368
        Me.btnKeyboard.Text = "Keyboard"
        Me.btnKeyboard.UseVisualStyleBackColor = False
        '
        'lblSet
        '
        Me.lblSet.AutoSize = True
        Me.lblSet.Location = New System.Drawing.Point(235, 242)
        Me.lblSet.Name = "lblSet"
        Me.lblSet.Size = New System.Drawing.Size(23, 13)
        Me.lblSet.TabIndex = 369
        Me.lblSet.Text = "Set"
        Me.lblSet.Visible = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClear.Location = New System.Drawing.Point(197, 106)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(116, 47)
        Me.btnClear.TabIndex = 372
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'flpNotes
        '
        Me.flpNotes.Location = New System.Drawing.Point(320, 1)
        Me.flpNotes.Name = "flpNotes"
        Me.flpNotes.Size = New System.Drawing.Size(488, 593)
        Me.flpNotes.TabIndex = 373
        '
        'frmNotes1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 597)
        Me.Controls.Add(Me.flpNotes)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.lblSet)
        Me.Controls.Add(Me.btnKeyboard)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOkay)
        Me.Controls.Add(Me.txtNotes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNotes1"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnOkay As System.Windows.Forms.Button
    Friend WithEvents btnKeyboard As System.Windows.Forms.Button
    Friend WithEvents lblSet As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents flpNotes As System.Windows.Forms.FlowLayoutPanel
End Class
