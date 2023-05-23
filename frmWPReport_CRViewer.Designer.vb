<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWPReport_CRViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWPReport_CRViewer))
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmailID = New System.Windows.Forms.TextBox()
        Me.btnSendMail = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmbWorkPeriodEndTime = New System.Windows.Forms.ComboBox()
        Me.cmbWorkPeriodStartTime = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(2, 68)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(855, 448)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(8, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 24)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Enter Email ID :"
        '
        'txtEmailID
        '
        Me.txtEmailID.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtEmailID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailID.ForeColor = System.Drawing.Color.DimGray
        Me.txtEmailID.Location = New System.Drawing.Point(12, 33)
        Me.txtEmailID.Name = "txtEmailID"
        Me.txtEmailID.Size = New System.Drawing.Size(265, 29)
        Me.txtEmailID.TabIndex = 18
        '
        'btnSendMail
        '
        Me.btnSendMail.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnSendMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSendMail.FlatAppearance.BorderSize = 0
        Me.btnSendMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSendMail.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendMail.ForeColor = System.Drawing.Color.White
        Me.btnSendMail.Location = New System.Drawing.Point(283, 5)
        Me.btnSendMail.Name = "btnSendMail"
        Me.btnSendMail.Size = New System.Drawing.Size(147, 57)
        Me.btnSendMail.TabIndex = 20
        Me.btnSendMail.Text = "&Send Email"
        Me.btnSendMail.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'cmbWorkPeriodEndTime
        '
        Me.cmbWorkPeriodEndTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbWorkPeriodEndTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbWorkPeriodEndTime.BackColor = System.Drawing.SystemColors.Control
        Me.cmbWorkPeriodEndTime.Enabled = False
        Me.cmbWorkPeriodEndTime.FormattingEnabled = True
        Me.cmbWorkPeriodEndTime.Location = New System.Drawing.Point(436, 39)
        Me.cmbWorkPeriodEndTime.Name = "cmbWorkPeriodEndTime"
        Me.cmbWorkPeriodEndTime.Size = New System.Drawing.Size(236, 21)
        Me.cmbWorkPeriodEndTime.TabIndex = 22
        Me.cmbWorkPeriodEndTime.Visible = False
        '
        'cmbWorkPeriodStartTime
        '
        Me.cmbWorkPeriodStartTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbWorkPeriodStartTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbWorkPeriodStartTime.FormattingEnabled = True
        Me.cmbWorkPeriodStartTime.Location = New System.Drawing.Point(436, 12)
        Me.cmbWorkPeriodStartTime.Name = "cmbWorkPeriodStartTime"
        Me.cmbWorkPeriodStartTime.Size = New System.Drawing.Size(235, 21)
        Me.cmbWorkPeriodStartTime.TabIndex = 21
        Me.cmbWorkPeriodStartTime.Visible = False
        '
        'frmWPReport_CRViewer
        '
        Me.AcceptButton = Me.btnSendMail
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 528)
        Me.Controls.Add(Me.cmbWorkPeriodEndTime)
        Me.Controls.Add(Me.cmbWorkPeriodStartTime)
        Me.Controls.Add(Me.btnSendMail)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEmailID)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmWPReport_CRViewer"
        Me.Text = "Work Period Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmailID As System.Windows.Forms.TextBox
    Friend WithEvents btnSendMail As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmbWorkPeriodEndTime As System.Windows.Forms.ComboBox
    Friend WithEvents cmbWorkPeriodStartTime As System.Windows.Forms.ComboBox
    Public WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
