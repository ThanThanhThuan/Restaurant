<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCallerID
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCallerID))
        Me.txtInfo = New System.Windows.Forms.RichTextBox()
        Me.txtCallerIDComPort = New System.Windows.Forms.TextBox()
        Me.txtTillID = New System.Windows.Forms.TextBox()
        Me.btnOkay = New System.Windows.Forms.Button()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtPhoneNo = New System.Windows.Forms.TextBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtInfo
        '
        Me.txtInfo.Location = New System.Drawing.Point(2, 24)
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtInfo.Size = New System.Drawing.Size(224, 128)
        Me.txtInfo.TabIndex = 0
        Me.txtInfo.Text = ""
        '
        'txtCallerIDComPort
        '
        Me.txtCallerIDComPort.Location = New System.Drawing.Point(229, 82)
        Me.txtCallerIDComPort.Name = "txtCallerIDComPort"
        Me.txtCallerIDComPort.Size = New System.Drawing.Size(26, 20)
        Me.txtCallerIDComPort.TabIndex = 1
        Me.txtCallerIDComPort.Visible = False
        '
        'txtTillID
        '
        Me.txtTillID.Location = New System.Drawing.Point(261, 82)
        Me.txtTillID.Name = "txtTillID"
        Me.txtTillID.Size = New System.Drawing.Size(25, 20)
        Me.txtTillID.TabIndex = 2
        Me.txtTillID.Visible = False
        '
        'btnOkay
        '
        Me.btnOkay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOkay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkay.Location = New System.Drawing.Point(232, 13)
        Me.btnOkay.Name = "btnOkay"
        Me.btnOkay.Size = New System.Drawing.Size(56, 63)
        Me.btnOkay.TabIndex = 3
        Me.btnOkay.Text = "&Ok"
        Me.btnOkay.UseVisualStyleBackColor = True
        '
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.Location = New System.Drawing.Point(5, 4)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(81, 17)
        Me.lblCustomer.TabIndex = 4
        Me.lblCustomer.Text = "lblCustomer"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'txtPhoneNo
        '
        Me.txtPhoneNo.Location = New System.Drawing.Point(232, 121)
        Me.txtPhoneNo.Name = "txtPhoneNo"
        Me.txtPhoneNo.Size = New System.Drawing.Size(53, 20)
        Me.txtPhoneNo.TabIndex = 5
        Me.txtPhoneNo.Visible = False
        '
        'btnReset
        '
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Location = New System.Drawing.Point(232, 82)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 63)
        Me.btnReset.TabIndex = 6
        Me.btnReset.Text = "&Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'frmCallerID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(288, 153)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.txtPhoneNo)
        Me.Controls.Add(Me.lblCustomer)
        Me.Controls.Add(Me.btnOkay)
        Me.Controls.Add(Me.txtTillID)
        Me.Controls.Add(Me.txtCallerIDComPort)
        Me.Controls.Add(Me.txtInfo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCallerID"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Caller ID"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInfo As System.Windows.Forms.RichTextBox
    Friend WithEvents txtCallerIDComPort As System.Windows.Forms.TextBox
    Friend WithEvents txtTillID As System.Windows.Forms.TextBox
    Friend WithEvents btnOkay As System.Windows.Forms.Button
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtPhoneNo As System.Windows.Forms.TextBox
    Friend WithEvents btnReset As System.Windows.Forms.Button

End Class
