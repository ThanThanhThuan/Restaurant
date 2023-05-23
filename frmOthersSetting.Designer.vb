<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOthersSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOthersSetting))
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnCategory = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblPerc = New System.Windows.Forms.Label()
        Me.numOFF = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dateHappyhour = New System.Windows.Forms.DateTimePicker()
        Me.chkHappyHours = New System.Windows.Forms.CheckBox()
        Me.timeTO = New System.Windows.Forms.DateTimePicker()
        Me.lblHappyhoursTO = New System.Windows.Forms.Label()
        Me.timeFrom = New System.Windows.Forms.DateTimePicker()
        Me.cmbTaxType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkKG = New System.Windows.Forms.CheckBox()
        Me.chkHD = New System.Windows.Forms.CheckBox()
        Me.chkTA = New System.Windows.Forms.CheckBox()
        Me.txVATPer = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtParcelCharges = New System.Windows.Forms.TextBox()
        Me.txtHDCharges = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dgw = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvisHappyHour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvHappyHourDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvHappyHourTimefrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvHappyHourTimeTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvOFF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtSCPer = New System.Windows.Forms.TextBox()
        Me.txtSTPer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAccessList = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numOFF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.dgw)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(463, 361)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnCategory)
        Me.GroupBox3.Controls.Add(Me.btnAccessList)
        Me.GroupBox3.Controls.Add(Me.btnDelete)
        Me.GroupBox3.Controls.Add(Me.btnUpdate)
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Controls.Add(Me.btnNew)
        Me.GroupBox3.Location = New System.Drawing.Point(361, 37)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(93, 226)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'btnCategory
        '
        Me.btnCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCategory.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCategory.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnCategory.Location = New System.Drawing.Point(8, 166)
        Me.btnCategory.Name = "btnCategory"
        Me.btnCategory.Size = New System.Drawing.Size(79, 26)
        Me.btnCategory.TabIndex = 4
        Me.btnCategory.Text = "Category"
        Me.btnCategory.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnDelete.Location = New System.Drawing.Point(8, 128)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(79, 37)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnUpdate.Location = New System.Drawing.Point(8, 89)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(79, 37)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnSave.Location = New System.Drawing.Point(8, 51)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(79, 37)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnNew.Location = New System.Drawing.Point(8, 11)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(79, 39)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblPerc)
        Me.GroupBox1.Controls.Add(Me.numOFF)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dateHappyhour)
        Me.GroupBox1.Controls.Add(Me.chkHappyHours)
        Me.GroupBox1.Controls.Add(Me.timeTO)
        Me.GroupBox1.Controls.Add(Me.lblHappyhoursTO)
        Me.GroupBox1.Controls.Add(Me.timeFrom)
        Me.GroupBox1.Controls.Add(Me.cmbTaxType)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.chkKG)
        Me.GroupBox1.Controls.Add(Me.chkHD)
        Me.GroupBox1.Controls.Add(Me.chkTA)
        Me.GroupBox1.Controls.Add(Me.txVATPer)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtParcelCharges)
        Me.GroupBox1.Controls.Add(Me.txtHDCharges)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 221)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Setting :"
        '
        'lblPerc
        '
        Me.lblPerc.AutoSize = True
        Me.lblPerc.Location = New System.Drawing.Point(93, 117)
        Me.lblPerc.Name = "lblPerc"
        Me.lblPerc.Size = New System.Drawing.Size(15, 13)
        Me.lblPerc.TabIndex = 23
        Me.lblPerc.Text = "%"
        '
        'numOFF
        '
        Me.numOFF.DecimalPlaces = 2
        Me.numOFF.Enabled = False
        Me.numOFF.Location = New System.Drawing.Point(45, 113)
        Me.numOFF.Name = "numOFF"
        Me.numOFF.Size = New System.Drawing.Size(48, 20)
        Me.numOFF.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "OFF"
        '
        'dateHappyhour
        '
        Me.dateHappyhour.CustomFormat = "dd MMMM yyyy"
        Me.dateHappyhour.Enabled = False
        Me.dateHappyhour.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateHappyhour.Location = New System.Drawing.Point(120, 89)
        Me.dateHappyhour.Name = "dateHappyhour"
        Me.dateHappyhour.ShowUpDown = True
        Me.dateHappyhour.Size = New System.Drawing.Size(158, 20)
        Me.dateHappyhour.TabIndex = 20
        '
        'chkHappyHours
        '
        Me.chkHappyHours.AutoSize = True
        Me.chkHappyHours.Location = New System.Drawing.Point(20, 91)
        Me.chkHappyHours.Name = "chkHappyHours"
        Me.chkHappyHours.Size = New System.Drawing.Size(86, 17)
        Me.chkHappyHours.TabIndex = 19
        Me.chkHappyHours.Text = "Happy hours"
        Me.chkHappyHours.UseVisualStyleBackColor = True
        '
        'timeTO
        '
        Me.timeTO.CustomFormat = "HH:mm tt"
        Me.timeTO.Enabled = False
        Me.timeTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeTO.Location = New System.Drawing.Point(209, 111)
        Me.timeTO.Name = "timeTO"
        Me.timeTO.ShowUpDown = True
        Me.timeTO.Size = New System.Drawing.Size(69, 20)
        Me.timeTO.TabIndex = 18
        '
        'lblHappyhoursTO
        '
        Me.lblHappyhoursTO.AutoSize = True
        Me.lblHappyhoursTO.Location = New System.Drawing.Point(194, 115)
        Me.lblHappyhoursTO.Name = "lblHappyhoursTO"
        Me.lblHappyhoursTO.Size = New System.Drawing.Size(10, 13)
        Me.lblHappyhoursTO.TabIndex = 17
        Me.lblHappyhoursTO.Text = "-"
        '
        'timeFrom
        '
        Me.timeFrom.CustomFormat = "HH:mm tt"
        Me.timeFrom.Enabled = False
        Me.timeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeFrom.Location = New System.Drawing.Point(120, 111)
        Me.timeFrom.Name = "timeFrom"
        Me.timeFrom.ShowUpDown = True
        Me.timeFrom.Size = New System.Drawing.Size(69, 20)
        Me.timeFrom.TabIndex = 16
        '
        'cmbTaxType
        '
        Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTaxType.FormattingEnabled = True
        Me.cmbTaxType.Items.AddRange(New Object() {"Inclusive", "Exclusive"})
        Me.cmbTaxType.Location = New System.Drawing.Point(157, 194)
        Me.cmbTaxType.Name = "cmbTaxType"
        Me.cmbTaxType.Size = New System.Drawing.Size(121, 21)
        Me.cmbTaxType.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(93, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Tax Type :"
        '
        'chkKG
        '
        Me.chkKG.AutoSize = True
        Me.chkKG.Location = New System.Drawing.Point(157, 174)
        Me.chkKG.Name = "chkKG"
        Me.chkKG.Size = New System.Drawing.Size(145, 17)
        Me.chkKG.TabIndex = 6
        Me.chkKG.Text = "In Cash Counter (Dine In)"
        Me.chkKG.UseVisualStyleBackColor = True
        '
        'chkHD
        '
        Me.chkHD.AutoSize = True
        Me.chkHD.Location = New System.Drawing.Point(157, 155)
        Me.chkHD.Name = "chkHD"
        Me.chkHD.Size = New System.Drawing.Size(95, 17)
        Me.chkHD.TabIndex = 4
        Me.chkHD.Text = "Home Delivery"
        Me.chkHD.UseVisualStyleBackColor = True
        '
        'chkTA
        '
        Me.chkTA.AutoSize = True
        Me.chkTA.Location = New System.Drawing.Point(157, 135)
        Me.chkTA.Name = "chkTA"
        Me.chkTA.Size = New System.Drawing.Size(76, 17)
        Me.chkTA.TabIndex = 3
        Me.chkTA.Text = "Takeaway"
        Me.chkTA.UseVisualStyleBackColor = True
        '
        'txVATPer
        '
        Me.txVATPer.BackColor = System.Drawing.Color.White
        Me.txVATPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txVATPer.Location = New System.Drawing.Point(157, 65)
        Me.txVATPer.Name = "txVATPer"
        Me.txVATPer.Size = New System.Drawing.Size(124, 20)
        Me.txVATPer.TabIndex = 2
        Me.txVATPer.Text = "0.00"
        Me.txVATPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(106, 65)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "VAT % :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(135, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Print Kitchen Order Ticket :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Home Delivery Charges :"
        '
        'txtParcelCharges
        '
        Me.txtParcelCharges.BackColor = System.Drawing.Color.White
        Me.txtParcelCharges.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParcelCharges.Location = New System.Drawing.Point(157, 14)
        Me.txtParcelCharges.Name = "txtParcelCharges"
        Me.txtParcelCharges.Size = New System.Drawing.Size(124, 20)
        Me.txtParcelCharges.TabIndex = 0
        Me.txtParcelCharges.Text = "0.00"
        Me.txtParcelCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHDCharges
        '
        Me.txtHDCharges.BackColor = System.Drawing.Color.White
        Me.txtHDCharges.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHDCharges.Location = New System.Drawing.Point(157, 39)
        Me.txtHDCharges.Name = "txtHDCharges"
        Me.txtHDCharges.Size = New System.Drawing.Size(124, 20)
        Me.txtHDCharges.TabIndex = 1
        Me.txtHDCharges.Text = "0.00"
        Me.txtHDCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(66, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Parcel Charges :"
        '
        'btnClose
        '
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnClose.Location = New System.Drawing.Point(379, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 38)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dgw
        '
        Me.dgw.AllowUserToAddRows = False
        Me.dgw.AllowUserToDeleteRows = False
        DataGridViewCellStyle28.BackColor = System.Drawing.Color.FloralWhite
        Me.dgw.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle28
        Me.dgw.BackgroundColor = System.Drawing.Color.White
        Me.dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgw.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle29
        Me.dgw.ColumnHeadersHeight = 35
        Me.dgw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column1, Me.Column2, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column4, Me.dgvisHappyHour, Me.dgvHappyHourDate, Me.dgvHappyHourTimefrom, Me.dgvHappyHourTimeTo, Me.dgvOFF})
        Me.dgw.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgw.EnableHeadersVisualStyles = False
        Me.dgw.GridColor = System.Drawing.Color.White
        Me.dgw.Location = New System.Drawing.Point(3, 269)
        Me.dgw.MultiSelect = False
        Me.dgw.Name = "dgw"
        Me.dgw.ReadOnly = True
        Me.dgw.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle35.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgw.RowHeadersDefaultCellStyle = DataGridViewCellStyle35
        Me.dgw.RowHeadersVisible = False
        Me.dgw.RowHeadersWidth = 25
        Me.dgw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle36.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.Color.Black
        Me.dgw.RowsDefaultCellStyle = DataGridViewCellStyle36
        Me.dgw.RowTemplate.Height = 18
        Me.dgw.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw.Size = New System.Drawing.Size(451, 88)
        Me.dgw.TabIndex = 1
        '
        'Column3
        '
        Me.Column3.HeaderText = "ID"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'Column1
        '
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle30
        Me.Column1.HeaderText = "Parcel Charges"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle31
        Me.Column2.HeaderText = "Home Delivery Charges"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle32
        Me.Column5.HeaderText = "Service Tax %"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Column6
        '
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle33
        Me.Column6.HeaderText = "VAT %"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle34
        Me.Column7.HeaderText = "Service Charges %"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'Column8
        '
        Me.Column8.HeaderText = "KOT Print in Takeaway"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "KOT Print in Home Delivery"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "KOT Print in Express Billing"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "KOT Print in Cashier Counter"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Tax Type"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'dgvisHappyHour
        '
        Me.dgvisHappyHour.HeaderText = "Is Happy Hour"
        Me.dgvisHappyHour.Name = "dgvisHappyHour"
        Me.dgvisHappyHour.ReadOnly = True
        '
        'dgvHappyHourDate
        '
        Me.dgvHappyHourDate.HeaderText = "Happy Hour Date"
        Me.dgvHappyHourDate.Name = "dgvHappyHourDate"
        Me.dgvHappyHourDate.ReadOnly = True
        '
        'dgvHappyHourTimefrom
        '
        Me.dgvHappyHourTimefrom.HeaderText = "Time From"
        Me.dgvHappyHourTimefrom.Name = "dgvHappyHourTimefrom"
        Me.dgvHappyHourTimefrom.ReadOnly = True
        '
        'dgvHappyHourTimeTo
        '
        Me.dgvHappyHourTimeTo.HeaderText = "Time To"
        Me.dgvHappyHourTimeTo.Name = "dgvHappyHourTimeTo"
        Me.dgvHappyHourTimeTo.ReadOnly = True
        '
        'dgvOFF
        '
        Me.dgvOFF.HeaderText = "OFF %"
        Me.dgvOFF.Name = "dgvOFF"
        Me.dgvOFF.ReadOnly = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtID)
        Me.Panel2.Controls.Add(Me.lblUser)
        Me.Panel2.Controls.Add(Me.txtSCPer)
        Me.Panel2.Controls.Add(Me.txtSTPer)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(370, 31)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(125, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Others Setting"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(3, 7)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(39, 20)
        Me.txtID.TabIndex = 4
        Me.txtID.Visible = False
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(26, 10)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(39, 13)
        Me.lblUser.TabIndex = 5
        Me.lblUser.Text = "Label8"
        Me.lblUser.Visible = False
        '
        'txtSCPer
        '
        Me.txtSCPer.BackColor = System.Drawing.Color.White
        Me.txtSCPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSCPer.Location = New System.Drawing.Point(50, 3)
        Me.txtSCPer.Name = "txtSCPer"
        Me.txtSCPer.Size = New System.Drawing.Size(56, 20)
        Me.txtSCPer.TabIndex = 3
        Me.txtSCPer.Text = "0.00"
        Me.txtSCPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSCPer.Visible = False
        '
        'txtSTPer
        '
        Me.txtSTPer.BackColor = System.Drawing.Color.White
        Me.txtSTPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSTPer.Location = New System.Drawing.Point(52, 7)
        Me.txtSTPer.Name = "txtSTPer"
        Me.txtSTPer.Size = New System.Drawing.Size(49, 20)
        Me.txtSTPer.TabIndex = 2
        Me.txtSTPer.Text = "0.00"
        Me.txtSTPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSTPer.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(530, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 0
        '
        'btnAccessList
        '
        Me.btnAccessList.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAccessList.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAccessList.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAccessList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccessList.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnAccessList.Location = New System.Drawing.Point(8, 194)
        Me.btnAccessList.Name = "btnAccessList"
        Me.btnAccessList.Size = New System.Drawing.Size(79, 26)
        Me.btnAccessList.TabIndex = 5
        Me.btnAccessList.Text = "Access List"
        Me.btnAccessList.UseVisualStyleBackColor = False
        '
        'frmOthersSetting
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(470, 375)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOthersSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numOFF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHDCharges As System.Windows.Forms.TextBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents dgw As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtParcelCharges As System.Windows.Forms.TextBox
    Friend WithEvents chkKG As System.Windows.Forms.CheckBox
    Friend WithEvents chkHD As System.Windows.Forms.CheckBox
    Friend WithEvents chkTA As System.Windows.Forms.CheckBox
    Friend WithEvents txtSCPer As System.Windows.Forms.TextBox
    Friend WithEvents txVATPer As System.Windows.Forms.TextBox
    Friend WithEvents txtSTPer As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents timeFrom As DateTimePicker
    Friend WithEvents timeTO As DateTimePicker
    Friend WithEvents lblHappyhoursTO As Label
    Friend WithEvents chkHappyHours As CheckBox
    Friend WithEvents dateHappyhour As DateTimePicker
    Friend WithEvents lblPerc As Label
    Friend WithEvents numOFF As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents dgvisHappyHour As DataGridViewTextBoxColumn
    Friend WithEvents dgvHappyHourDate As DataGridViewTextBoxColumn
    Friend WithEvents dgvHappyHourTimefrom As DataGridViewTextBoxColumn
    Friend WithEvents dgvHappyHourTimeTo As DataGridViewTextBoxColumn
    Friend WithEvents dgvOFF As DataGridViewTextBoxColumn
    Friend WithEvents btnCategory As Button
    Friend WithEvents btnAccessList As Button
End Class
