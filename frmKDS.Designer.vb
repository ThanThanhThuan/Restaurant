<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKDS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKDS))
        Me.flpDineIn = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmbDineInKOT = New System.Windows.Forms.ComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.flpTA = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmbTAKOT = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.flpHD = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmbHDKOT = New System.Windows.Forms.ComboBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.flpEB = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmbEBKOT = New System.Windows.Forms.ComboBox()
        Me.flpDineIn.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.flpTA.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.flpHD.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.flpEB.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpDineIn
        '
        Me.flpDineIn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpDineIn.AutoScroll = True
        Me.flpDineIn.BackColor = System.Drawing.Color.White
        Me.flpDineIn.Controls.Add(Me.cmbDineInKOT)
        Me.flpDineIn.Location = New System.Drawing.Point(0, 3)
        Me.flpDineIn.Name = "flpDineIn"
        Me.flpDineIn.Size = New System.Drawing.Size(976, 477)
        Me.flpDineIn.TabIndex = 0
        '
        'cmbDineInKOT
        '
        Me.cmbDineInKOT.FormattingEnabled = True
        Me.cmbDineInKOT.Location = New System.Drawing.Point(3, 3)
        Me.cmbDineInKOT.Name = "cmbDineInKOT"
        Me.cmbDineInKOT.Size = New System.Drawing.Size(121, 21)
        Me.cmbDineInKOT.TabIndex = 0
        Me.cmbDineInKOT.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 60000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(68, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(405, 21)
        Me.Label1.TabIndex = 393
        Me.Label1.Text = "(All Orders will be automatically refresh after 1 minute)"
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.Transparent
        Me.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Location = New System.Drawing.Point(5, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(52, 49)
        Me.btnRefresh.TabIndex = 392
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabControl1.ItemSize = New System.Drawing.Size(150, 35)
        Me.TabControl1.Location = New System.Drawing.Point(5, 58)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(990, 526)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.flpDineIn)
        Me.TabPage1.Location = New System.Drawing.Point(4, 39)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(982, 483)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Dine In KOT"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.flpTA)
        Me.TabPage2.Location = New System.Drawing.Point(4, 39)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(982, 483)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Take Away KOT"
        '
        'flpTA
        '
        Me.flpTA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpTA.AutoScroll = True
        Me.flpTA.BackColor = System.Drawing.Color.White
        Me.flpTA.Controls.Add(Me.cmbTAKOT)
        Me.flpTA.Location = New System.Drawing.Point(3, 3)
        Me.flpTA.Name = "flpTA"
        Me.flpTA.Size = New System.Drawing.Size(976, 477)
        Me.flpTA.TabIndex = 1
        '
        'cmbTAKOT
        '
        Me.cmbTAKOT.FormattingEnabled = True
        Me.cmbTAKOT.Location = New System.Drawing.Point(3, 3)
        Me.cmbTAKOT.Name = "cmbTAKOT"
        Me.cmbTAKOT.Size = New System.Drawing.Size(121, 21)
        Me.cmbTAKOT.TabIndex = 0
        Me.cmbTAKOT.Visible = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.White
        Me.TabPage3.Controls.Add(Me.flpHD)
        Me.TabPage3.Location = New System.Drawing.Point(4, 39)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(982, 483)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Home Delivery KOT"
        '
        'flpHD
        '
        Me.flpHD.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpHD.AutoScroll = True
        Me.flpHD.BackColor = System.Drawing.Color.White
        Me.flpHD.Controls.Add(Me.cmbHDKOT)
        Me.flpHD.Location = New System.Drawing.Point(3, 3)
        Me.flpHD.Name = "flpHD"
        Me.flpHD.Size = New System.Drawing.Size(976, 477)
        Me.flpHD.TabIndex = 2
        '
        'cmbHDKOT
        '
        Me.cmbHDKOT.FormattingEnabled = True
        Me.cmbHDKOT.Location = New System.Drawing.Point(3, 3)
        Me.cmbHDKOT.Name = "cmbHDKOT"
        Me.cmbHDKOT.Size = New System.Drawing.Size(121, 21)
        Me.cmbHDKOT.TabIndex = 0
        Me.cmbHDKOT.Visible = False
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.White
        Me.TabPage4.Controls.Add(Me.flpEB)
        Me.TabPage4.Location = New System.Drawing.Point(4, 39)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(982, 483)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Express Billing KOT"
        '
        'flpEB
        '
        Me.flpEB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpEB.AutoScroll = True
        Me.flpEB.BackColor = System.Drawing.Color.White
        Me.flpEB.Controls.Add(Me.cmbEBKOT)
        Me.flpEB.Location = New System.Drawing.Point(3, 3)
        Me.flpEB.Name = "flpEB"
        Me.flpEB.Size = New System.Drawing.Size(976, 477)
        Me.flpEB.TabIndex = 3
        '
        'cmbEBKOT
        '
        Me.cmbEBKOT.FormattingEnabled = True
        Me.cmbEBKOT.Location = New System.Drawing.Point(3, 3)
        Me.cmbEBKOT.Name = "cmbEBKOT"
        Me.cmbEBKOT.Size = New System.Drawing.Size(121, 21)
        Me.cmbEBKOT.TabIndex = 0
        Me.cmbEBKOT.Visible = False
        '
        'frmKDS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(998, 586)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnRefresh)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmKDS"
        Me.Text = "Kitchen Display"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.flpDineIn.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.flpTA.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.flpHD.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.flpEB.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents flpDineIn As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmbDineInKOT As System.Windows.Forms.ComboBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents flpTA As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmbTAKOT As System.Windows.Forms.ComboBox
    Friend WithEvents flpHD As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmbHDKOT As System.Windows.Forms.ComboBox
    Friend WithEvents flpEB As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmbEBKOT As System.Windows.Forms.ComboBox
End Class
