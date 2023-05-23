<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendBroadcastSMS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSendBroadcastSMS))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnSendSMS = New System.Windows.Forms.Button()
        Me.listView1 = New System.Windows.Forms.ListView()
        Me.columnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Address = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtMessage = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1061, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Broadcasting Message To Customers"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnReset)
        Me.Panel3.Location = New System.Drawing.Point(13, 48)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(126, 57)
        Me.Panel3.TabIndex = 3
        '
        'btnReset
        '
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = Global.RestaurantPOS6.My.Resources.Resources.Reset2_32x32
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(13, 9)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(104, 37)
        Me.btnReset.TabIndex = 3
        Me.btnReset.Text = "Reset"
        Me.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnSendSMS
        '
        Me.btnSendSMS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSendSMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendSMS.Image = CType(resources.GetObject("btnSendSMS.Image"), System.Drawing.Image)
        Me.btnSendSMS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSendSMS.Location = New System.Drawing.Point(656, 489)
        Me.btnSendSMS.Name = "btnSendSMS"
        Me.btnSendSMS.Size = New System.Drawing.Size(121, 45)
        Me.btnSendSMS.TabIndex = 0
        Me.btnSendSMS.Text = "Send SMS"
        Me.btnSendSMS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSendSMS.UseVisualStyleBackColor = True
        '
        'listView1
        '
        Me.listView1.CheckBoxes = True
        Me.listView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader3, Me.Address, Me.ColumnHeader2})
        Me.listView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listView1.GridLines = True
        Me.listView1.Location = New System.Drawing.Point(13, 110)
        Me.listView1.Name = "listView1"
        Me.listView1.Size = New System.Drawing.Size(637, 557)
        Me.listView1.TabIndex = 66
        Me.listView1.UseCompatibleStateImageBehavior = False
        Me.listView1.View = System.Windows.Forms.View.Details
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "Customer Name"
        Me.columnHeader3.Width = 200
        '
        'Address
        '
        Me.Address.Text = "Address"
        Me.Address.Width = 300
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Contact No."
        Me.ColumnHeader2.Width = 132
        '
        'txtMessage
        '
        Me.txtMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessage.Location = New System.Drawing.Point(656, 110)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.txtMessage.Size = New System.Drawing.Size(395, 373)
        Me.txtMessage.TabIndex = 67
        Me.txtMessage.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(656, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 15)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Message :"
        '
        'Timer2
        '
        '
        'frmSendBroadcastSMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1059, 671)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.btnSendSMS)
        Me.Controls.Add(Me.listView1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSendBroadcastSMS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Send SMS"
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnSendSMS As System.Windows.Forms.Button
    Friend WithEvents listView1 As System.Windows.Forms.ListView
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Address As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
