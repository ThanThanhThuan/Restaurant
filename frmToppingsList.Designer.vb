<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmToppingsList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmToppingsList))
        Me.flpTables = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtTaxType = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.flpTables.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpTables
        '
        Me.flpTables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpTables.AutoScroll = True
        Me.flpTables.BackColor = System.Drawing.Color.White
        Me.flpTables.Controls.Add(Me.txtTaxType)
        Me.flpTables.Location = New System.Drawing.Point(0, 54)
        Me.flpTables.Name = "flpTables"
        Me.flpTables.Size = New System.Drawing.Size(817, 379)
        Me.flpTables.TabIndex = 4
        '
        'txtTaxType
        '
        Me.txtTaxType.Location = New System.Drawing.Point(3, 3)
        Me.txtTaxType.Name = "txtTaxType"
        Me.txtTaxType.Size = New System.Drawing.Size(53, 20)
        Me.txtTaxType.TabIndex = 454
        Me.txtTaxType.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(816, 50)
        Me.Label5.TabIndex = 390
        Me.Label5.Text = "List of Toppings"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmToppingsList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(817, 433)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.flpTables)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmToppingsList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Toppings"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.flpTables.ResumeLayout(False)
        Me.flpTables.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents flpTables As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTaxType As System.Windows.Forms.TextBox
End Class
