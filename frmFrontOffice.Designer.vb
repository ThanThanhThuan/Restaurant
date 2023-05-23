<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFrontOffice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFrontOffice))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnKithcenDisplay = New System.Windows.Forms.Button()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnWorkPeriod = New System.Windows.Forms.Button()
        Me.btnPOS = New System.Windows.Forms.Button()
        Me.btnOpenTickets = New System.Windows.Forms.Button()
        Me.lblUserType = New System.Windows.Forms.Label()
        Me.btnOpenCashDrawer = New System.Windows.Forms.Button()
        Me.btnKeyboard = New System.Windows.Forms.Button()
        Me.btnMaximise = New System.Windows.Forms.Button()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.txtTillID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label30)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblUser)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(687, 51)
        Me.Panel1.TabIndex = 3
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(339, 5)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(178, 37)
        Me.Label30.TabIndex = 321
        Me.Label30.Text = "Operator ID :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Front Office"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.White
        Me.lblUser.Location = New System.Drawing.Point(512, 5)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(102, 37)
        Me.lblUser.TabIndex = 320
        Me.lblUser.Text = "lblUser"
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.lblDateTime.Location = New System.Drawing.Point(5, 53)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(134, 37)
        Me.lblDateTime.TabIndex = 3
        Me.lblDateTime.Text = "DateTime"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnKithcenDisplay, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnReport, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnLogout, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnWorkPeriod, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPOS, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnOpenTickets, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 93)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(892, 574)
        Me.TableLayoutPanel1.TabIndex = 56
        '
        'btnKithcenDisplay
        '
        Me.btnKithcenDisplay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKithcenDisplay.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnKithcenDisplay.FlatAppearance.BorderSize = 0
        Me.btnKithcenDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKithcenDisplay.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKithcenDisplay.ForeColor = System.Drawing.Color.White
        Me.btnKithcenDisplay.Image = CType(resources.GetObject("btnKithcenDisplay.Image"), System.Drawing.Image)
        Me.btnKithcenDisplay.Location = New System.Drawing.Point(3, 290)
        Me.btnKithcenDisplay.Name = "btnKithcenDisplay"
        Me.btnKithcenDisplay.Size = New System.Drawing.Size(291, 281)
        Me.btnKithcenDisplay.TabIndex = 5
        Me.btnKithcenDisplay.Text = "Kitchen Display"
        Me.btnKithcenDisplay.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnKithcenDisplay.UseVisualStyleBackColor = False
        '
        'btnReport
        '
        Me.btnReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnReport.FlatAppearance.BorderSize = 0
        Me.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReport.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.ForeColor = System.Drawing.Color.White
        Me.btnReport.Image = CType(resources.GetObject("btnReport.Image"), System.Drawing.Image)
        Me.btnReport.Location = New System.Drawing.Point(300, 290)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(291, 281)
        Me.btnReport.TabIndex = 4
        Me.btnReport.Text = "Report"
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReport.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Image = CType(resources.GetObject("btnLogout.Image"), System.Drawing.Image)
        Me.btnLogout.Location = New System.Drawing.Point(597, 290)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(292, 281)
        Me.btnLogout.TabIndex = 3
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'btnWorkPeriod
        '
        Me.btnWorkPeriod.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWorkPeriod.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnWorkPeriod.FlatAppearance.BorderSize = 0
        Me.btnWorkPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkPeriod.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorkPeriod.ForeColor = System.Drawing.Color.White
        Me.btnWorkPeriod.Image = CType(resources.GetObject("btnWorkPeriod.Image"), System.Drawing.Image)
        Me.btnWorkPeriod.Location = New System.Drawing.Point(3, 3)
        Me.btnWorkPeriod.Name = "btnWorkPeriod"
        Me.btnWorkPeriod.Size = New System.Drawing.Size(291, 281)
        Me.btnWorkPeriod.TabIndex = 0
        Me.btnWorkPeriod.Text = "Work Period"
        Me.btnWorkPeriod.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWorkPeriod.UseVisualStyleBackColor = False
        '
        'btnPOS
        '
        Me.btnPOS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPOS.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnPOS.FlatAppearance.BorderSize = 0
        Me.btnPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPOS.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPOS.ForeColor = System.Drawing.Color.White
        Me.btnPOS.Image = CType(resources.GetObject("btnPOS.Image"), System.Drawing.Image)
        Me.btnPOS.Location = New System.Drawing.Point(300, 3)
        Me.btnPOS.Name = "btnPOS"
        Me.btnPOS.Size = New System.Drawing.Size(291, 281)
        Me.btnPOS.TabIndex = 1
        Me.btnPOS.Text = "POS"
        Me.btnPOS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPOS.UseVisualStyleBackColor = False
        '
        'btnOpenTickets
        '
        Me.btnOpenTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenTickets.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnOpenTickets.FlatAppearance.BorderSize = 0
        Me.btnOpenTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenTickets.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenTickets.ForeColor = System.Drawing.Color.White
        Me.btnOpenTickets.Image = CType(resources.GetObject("btnOpenTickets.Image"), System.Drawing.Image)
        Me.btnOpenTickets.Location = New System.Drawing.Point(597, 3)
        Me.btnOpenTickets.Name = "btnOpenTickets"
        Me.btnOpenTickets.Size = New System.Drawing.Size(292, 281)
        Me.btnOpenTickets.TabIndex = 2
        Me.btnOpenTickets.Text = "Open Tickets"
        Me.btnOpenTickets.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOpenTickets.UseVisualStyleBackColor = False
        '
        'lblUserType
        '
        Me.lblUserType.AutoSize = True
        Me.lblUserType.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserType.ForeColor = System.Drawing.Color.PaleGoldenrod
        Me.lblUserType.Location = New System.Drawing.Point(703, 53)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(130, 37)
        Me.lblUserType.TabIndex = 322
        Me.lblUserType.Text = "UserType"
        Me.lblUserType.Visible = False
        '
        'btnOpenCashDrawer
        '
        Me.btnOpenCashDrawer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenCashDrawer.BackColor = System.Drawing.Color.Transparent
        Me.btnOpenCashDrawer.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOpenCashDrawer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOpenCashDrawer.FlatAppearance.BorderSize = 0
        Me.btnOpenCashDrawer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenCashDrawer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenCashDrawer.Image = CType(resources.GetObject("btnOpenCashDrawer.Image"), System.Drawing.Image)
        Me.btnOpenCashDrawer.Location = New System.Drawing.Point(693, 1)
        Me.btnOpenCashDrawer.Name = "btnOpenCashDrawer"
        Me.btnOpenCashDrawer.Size = New System.Drawing.Size(52, 51)
        Me.btnOpenCashDrawer.TabIndex = 322
        Me.btnOpenCashDrawer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOpenCashDrawer.UseVisualStyleBackColor = False
        '
        'btnKeyboard
        '
        Me.btnKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.btnKeyboard.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnKeyboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnKeyboard.FlatAppearance.BorderSize = 0
        Me.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKeyboard.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKeyboard.Image = CType(resources.GetObject("btnKeyboard.Image"), System.Drawing.Image)
        Me.btnKeyboard.Location = New System.Drawing.Point(749, 1)
        Me.btnKeyboard.Name = "btnKeyboard"
        Me.btnKeyboard.Size = New System.Drawing.Size(52, 49)
        Me.btnKeyboard.TabIndex = 58
        Me.btnKeyboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeyboard.UseVisualStyleBackColor = False
        '
        'btnMaximise
        '
        Me.btnMaximise.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMaximise.BackColor = System.Drawing.Color.Transparent
        Me.btnMaximise.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnMaximise.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnMaximise.FlatAppearance.BorderSize = 0
        Me.btnMaximise.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaximise.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaximise.Image = Global.RestaurantPOS6.My.Resources.Resources.Entypo_e713_0__64
        Me.btnMaximise.Location = New System.Drawing.Point(860, 1)
        Me.btnMaximise.Name = "btnMaximise"
        Me.btnMaximise.Size = New System.Drawing.Size(52, 49)
        Me.btnMaximise.TabIndex = 57
        Me.btnMaximise.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMaximise.UseVisualStyleBackColor = False
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.BackColor = System.Drawing.Color.Transparent
        Me.btnMinimize.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnMinimize.FlatAppearance.BorderSize = 0
        Me.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimize.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinimize.Image = CType(resources.GetObject("btnMinimize.Image"), System.Drawing.Image)
        Me.btnMinimize.Location = New System.Drawing.Point(805, 1)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(52, 49)
        Me.btnMinimize.TabIndex = 35
        Me.btnMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMinimize.UseVisualStyleBackColor = False
        '
        'txtTillID
        '
        Me.txtTillID.Location = New System.Drawing.Point(436, 329)
        Me.txtTillID.Name = "txtTillID"
        Me.txtTillID.Size = New System.Drawing.Size(45, 20)
        Me.txtTillID.TabIndex = 449
        Me.txtTillID.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(495, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(421, 37)
        Me.Label2.TabIndex = 450
        Me.Label2.Text = "Don't Forget to End Work Period."
        '
        'frmFrontOffice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(916, 678)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblUserType)
        Me.Controls.Add(Me.btnOpenCashDrawer)
        Me.Controls.Add(Me.btnKeyboard)
        Me.Controls.Add(Me.btnMaximise)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnMinimize)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtTillID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFrontOffice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblDateTime As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents btnMinimize As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMaximise As System.Windows.Forms.Button
    Friend WithEvents btnKeyboard As System.Windows.Forms.Button
    Friend WithEvents btnWorkPeriod As System.Windows.Forms.Button
    Friend WithEvents btnPOS As System.Windows.Forms.Button
    Friend WithEvents btnKithcenDisplay As System.Windows.Forms.Button
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents btnOpenTickets As System.Windows.Forms.Button
    Friend WithEvents btnOpenCashDrawer As System.Windows.Forms.Button
    Friend WithEvents lblUserType As System.Windows.Forms.Label
    Friend WithEvents txtTillID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
