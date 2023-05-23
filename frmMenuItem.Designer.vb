<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMenuItem
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuItem))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtImagePath = New System.Windows.Forms.TextBox()
        Me.Picture = New System.Windows.Forms.PictureBox()
        Me.BRemove = New System.Windows.Forms.Button()
        Me.Browse = New System.Windows.Forms.Button()
        Me.btnBarcodePrint = New System.Windows.Forms.Button()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnUpdateImage = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.numSellingPrice = New System.Windows.Forms.NumericUpDown()
        Me.lblSellingPrice = New System.Windows.Forms.Label()
        Me.numPurPrice = New System.Windows.Forms.NumericUpDown()
        Me.lblPurPrice = New System.Windows.Forms.Label()
        Me.btnUIColor = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHDRate = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTARate = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDIRate = New System.Windows.Forms.TextBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSearchByDish = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dgw = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvPurPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvSellingPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtDishID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBCode = New System.Windows.Forms.TextBox()
        Me.txtDish = New System.Windows.Forms.TextBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numSellingPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPurPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtImagePath)
        Me.Panel1.Controls.Add(Me.Picture)
        Me.Panel1.Controls.Add(Me.BRemove)
        Me.Panel1.Controls.Add(Me.Browse)
        Me.Panel1.Controls.Add(Me.btnBarcodePrint)
        Me.Panel1.Controls.Add(Me.btnExportExcel)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.dgw)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.txtDish)
        Me.Panel1.Controls.Add(Me.lblUser)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(750, 653)
        Me.Panel1.TabIndex = 2
        '
        'txtImagePath
        '
        Me.txtImagePath.Location = New System.Drawing.Point(530, 254)
        Me.txtImagePath.Name = "txtImagePath"
        Me.txtImagePath.Size = New System.Drawing.Size(100, 20)
        Me.txtImagePath.TabIndex = 295
        Me.txtImagePath.Visible = False
        '
        'Picture
        '
        Me.Picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture.Image = Global.RestaurantPOS6.My.Resources.Resources._12
        Me.Picture.Location = New System.Drawing.Point(530, 47)
        Me.Picture.Name = "Picture"
        Me.Picture.Size = New System.Drawing.Size(112, 94)
        Me.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picture.TabIndex = 294
        Me.Picture.TabStop = False
        '
        'BRemove
        '
        Me.BRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BRemove.ForeColor = System.Drawing.Color.Black
        Me.BRemove.Image = CType(resources.GetObject("BRemove.Image"), System.Drawing.Image)
        Me.BRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BRemove.Location = New System.Drawing.Point(530, 180)
        Me.BRemove.Name = "BRemove"
        Me.BRemove.Size = New System.Drawing.Size(112, 35)
        Me.BRemove.TabIndex = 293
        Me.BRemove.Text = "Remove"
        Me.BRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BRemove.UseVisualStyleBackColor = True
        '
        'Browse
        '
        Me.Browse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Browse.ForeColor = System.Drawing.Color.Black
        Me.Browse.Image = CType(resources.GetObject("Browse.Image"), System.Drawing.Image)
        Me.Browse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Browse.Location = New System.Drawing.Point(530, 144)
        Me.Browse.Name = "Browse"
        Me.Browse.Size = New System.Drawing.Size(112, 35)
        Me.Browse.TabIndex = 292
        Me.Browse.Text = "Browse..."
        Me.Browse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Browse.UseVisualStyleBackColor = True
        '
        'btnBarcodePrint
        '
        Me.btnBarcodePrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBarcodePrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBarcodePrint.Image = CType(resources.GetObject("btnBarcodePrint.Image"), System.Drawing.Image)
        Me.btnBarcodePrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBarcodePrint.Location = New System.Drawing.Point(359, 210)
        Me.btnBarcodePrint.Name = "btnBarcodePrint"
        Me.btnBarcodePrint.Size = New System.Drawing.Size(129, 64)
        Me.btnBarcodePrint.TabIndex = 8
        Me.btnBarcodePrint.Text = "Barcode Print"
        Me.btnBarcodePrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBarcodePrint.UseVisualStyleBackColor = True
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportExcel.Image = CType(resources.GetObject("btnExportExcel.Image"), System.Drawing.Image)
        Me.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportExcel.Location = New System.Drawing.Point(224, 210)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(129, 64)
        Me.btnExportExcel.TabIndex = 6
        Me.btnExportExcel.Text = "Import/Export Excel"
        Me.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportExcel.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnUpdateImage)
        Me.GroupBox3.Controls.Add(Me.btnDelete)
        Me.GroupBox3.Controls.Add(Me.btnUpdate)
        Me.GroupBox3.Controls.Add(Me.btnNew)
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Location = New System.Drawing.Point(646, 38)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(99, 236)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'btnUpdateImage
        '
        Me.btnUpdateImage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdateImage.Enabled = False
        Me.btnUpdateImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateImage.Image = CType(resources.GetObject("btnUpdateImage.Image"), System.Drawing.Image)
        Me.btnUpdateImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateImage.Location = New System.Drawing.Point(8, 182)
        Me.btnUpdateImage.Name = "btnUpdateImage"
        Me.btnUpdateImage.Size = New System.Drawing.Size(82, 48)
        Me.btnUpdateImage.TabIndex = 4
        Me.btnUpdateImage.Text = "Update" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Image"
        Me.btnUpdateImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdateImage.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(8, 141)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(82, 37)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate.Location = New System.Drawing.Point(8, 99)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(82, 37)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(8, 15)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(82, 37)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(8, 57)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(82, 37)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.numSellingPrice)
        Me.GroupBox2.Controls.Add(Me.lblSellingPrice)
        Me.GroupBox2.Controls.Add(Me.numPurPrice)
        Me.GroupBox2.Controls.Add(Me.lblPurPrice)
        Me.GroupBox2.Controls.Add(Me.btnUIColor)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtHDRate)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtTARate)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtBarcode)
        Me.GroupBox2.Controls.Add(Me.chkActive)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtItemName)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtDIRate)
        Me.GroupBox2.Controls.Add(Me.cmbCategory)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(4, 38)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(520, 162)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Item Details"
        '
        'numSellingPrice
        '
        Me.numSellingPrice.DecimalPlaces = 2
        Me.numSellingPrice.Location = New System.Drawing.Point(393, 133)
        Me.numSellingPrice.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.numSellingPrice.Name = "numSellingPrice"
        Me.numSellingPrice.Size = New System.Drawing.Size(120, 23)
        Me.numSellingPrice.TabIndex = 317
        '
        'lblSellingPrice
        '
        Me.lblSellingPrice.AutoSize = True
        Me.lblSellingPrice.Location = New System.Drawing.Point(315, 137)
        Me.lblSellingPrice.Name = "lblSellingPrice"
        Me.lblSellingPrice.Size = New System.Drawing.Size(72, 15)
        Me.lblSellingPrice.TabIndex = 316
        Me.lblSellingPrice.Text = "Selling Price"
        '
        'numPurPrice
        '
        Me.numPurPrice.DecimalPlaces = 2
        Me.numPurPrice.Location = New System.Drawing.Point(186, 133)
        Me.numPurPrice.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.numPurPrice.Name = "numPurPrice"
        Me.numPurPrice.Size = New System.Drawing.Size(120, 23)
        Me.numPurPrice.TabIndex = 315
        '
        'lblPurPrice
        '
        Me.lblPurPrice.AutoSize = True
        Me.lblPurPrice.Location = New System.Drawing.Point(126, 137)
        Me.lblPurPrice.Name = "lblPurPrice"
        Me.lblPurPrice.Size = New System.Drawing.Size(54, 15)
        Me.lblPurPrice.TabIndex = 314
        Me.lblPurPrice.Text = "Pur Price"
        '
        'btnUIColor
        '
        Me.btnUIColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnUIColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUIColor.ForeColor = System.Drawing.Color.White
        Me.btnUIColor.Location = New System.Drawing.Point(9, 109)
        Me.btnUIColor.Name = "btnUIColor"
        Me.btnUIColor.Size = New System.Drawing.Size(106, 31)
        Me.btnUIColor.TabIndex = 8
        Me.btnUIColor.Text = "Button UI Color"
        Me.btnUIColor.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(395, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(118, 15)
        Me.Label9.TabIndex = 309
        Me.Label9.Text = "Home Delivery Rate :"
        '
        'txtHDRate
        '
        Me.txtHDRate.BackColor = System.Drawing.Color.White
        Me.txtHDRate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHDRate.Location = New System.Drawing.Point(396, 80)
        Me.txtHDRate.Name = "txtHDRate"
        Me.txtHDRate.Size = New System.Drawing.Size(94, 23)
        Me.txtHDRate.TabIndex = 4
        Me.txtHDRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(293, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 15)
        Me.Label8.TabIndex = 307
        Me.Label8.Text = "Take Away Rate :"
        '
        'txtTARate
        '
        Me.txtTARate.BackColor = System.Drawing.Color.White
        Me.txtTARate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTARate.Location = New System.Drawing.Point(296, 80)
        Me.txtTARate.Name = "txtTARate"
        Me.txtTARate.Size = New System.Drawing.Size(94, 23)
        Me.txtTARate.TabIndex = 3
        Me.txtTARate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(282, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 15)
        Me.Label7.TabIndex = 305
        Me.Label7.Text = "Barcode :"
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.Color.White
        Me.txtBarcode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(339, 106)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(173, 23)
        Me.txtBarcode.TabIndex = 7
        Me.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActive.Location = New System.Drawing.Point(196, 107)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(85, 29)
        Me.chkActive.TabIndex = 6
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(121, 114)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(70, 15)
        Me.LinkLabel1.TabIndex = 5
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Select Color"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Item Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Category :"
        '
        'txtItemName
        '
        Me.txtItemName.BackColor = System.Drawing.Color.White
        Me.txtItemName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemName.Location = New System.Drawing.Point(125, 23)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(285, 23)
        Me.txtItemName.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Dine In Rate :"
        '
        'txtDIRate
        '
        Me.txtDIRate.BackColor = System.Drawing.Color.White
        Me.txtDIRate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIRate.Location = New System.Drawing.Point(196, 80)
        Me.txtDIRate.Name = "txtDIRate"
        Me.txtDIRate.Size = New System.Drawing.Size(94, 23)
        Me.txtDIRate.TabIndex = 2
        Me.txtDIRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbCategory
        '
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(125, 51)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(165, 23)
        Me.cmbCategory.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSearchByDish)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 206)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(202, 68)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search By Item Name :"
        '
        'txtSearchByDish
        '
        Me.txtSearchByDish.BackColor = System.Drawing.Color.White
        Me.txtSearchByDish.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchByDish.Location = New System.Drawing.Point(22, 29)
        Me.txtSearchByDish.Name = "txtSearchByDish"
        Me.txtSearchByDish.Size = New System.Drawing.Size(172, 23)
        Me.txtSearchByDish.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(659, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(82, 37)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dgw
        '
        Me.dgw.AllowUserToAddRows = False
        Me.dgw.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.dgw.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgw.BackgroundColor = System.Drawing.Color.White
        Me.dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgw.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgw.ColumnHeadersHeight = 28
        Me.dgw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column9, Me.Column8, Me.Column5, Me.Column7, Me.Column6, Me.dgvPurPrice, Me.dgvSellingPrice})
        Me.dgw.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgw.EnableHeadersVisualStyles = False
        Me.dgw.GridColor = System.Drawing.Color.White
        Me.dgw.Location = New System.Drawing.Point(4, 280)
        Me.dgw.MultiSelect = False
        Me.dgw.Name = "dgw"
        Me.dgw.ReadOnly = True
        Me.dgw.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgw.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgw.RowHeadersWidth = 25
        Me.dgw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.dgw.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgw.RowTemplate.Height = 18
        Me.dgw.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw.Size = New System.Drawing.Size(738, 364)
        Me.dgw.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "Menu Item"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 110
        '
        'Column2
        '
        Me.Column2.HeaderText = "Category"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 120
        '
        'Column3
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column3.HeaderText = "Dine In Rate"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column4.HeaderText = "Take Away Rate"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column9
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column9.HeaderText = "Home Delivery Rate"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Barcode"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "BackColor"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "Status"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        Me.Column7.Width = 78
        '
        'Column6
        '
        Me.Column6.HeaderText = "Image Path"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'dgvPurPrice
        '
        Me.dgvPurPrice.HeaderText = "Pur Price"
        Me.dgvPurPrice.Name = "dgvPurPrice"
        Me.dgvPurPrice.ReadOnly = True
        '
        'dgvSellingPrice
        '
        Me.dgvSellingPrice.HeaderText = "Selling Price"
        Me.dgvSellingPrice.Name = "dgvSellingPrice"
        Me.dgvSellingPrice.ReadOnly = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.txtDishID)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtBCode)
        Me.Panel2.Location = New System.Drawing.Point(4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(649, 28)
        Me.Panel2.TabIndex = 0
        '
        'txtDishID
        '
        Me.txtDishID.Location = New System.Drawing.Point(479, 4)
        Me.txtDishID.Name = "txtDishID"
        Me.txtDishID.Size = New System.Drawing.Size(59, 20)
        Me.txtDishID.TabIndex = 9
        Me.txtDishID.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(250, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Menu Items Entry"
        '
        'txtBCode
        '
        Me.txtBCode.Location = New System.Drawing.Point(544, 6)
        Me.txtBCode.Name = "txtBCode"
        Me.txtBCode.Size = New System.Drawing.Size(59, 20)
        Me.txtBCode.TabIndex = 8
        Me.txtBCode.Visible = False
        '
        'txtDish
        '
        Me.txtDish.Location = New System.Drawing.Point(212, 269)
        Me.txtDish.Name = "txtDish"
        Me.txtDish.Size = New System.Drawing.Size(40, 20)
        Me.txtDish.TabIndex = 4
        Me.txtDish.Visible = False
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(258, 276)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(39, 13)
        Me.lblUser.TabIndex = 5
        Me.lblUser.Text = "Label8"
        Me.lblUser.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmMenuItem
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(757, 660)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numSellingPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPurPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents dgw As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDIRate As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDish As System.Windows.Forms.TextBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtSearchByDish As System.Windows.Forms.TextBox
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents btnUIColor As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents btnExportExcel As System.Windows.Forms.Button
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents txtBCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDishID As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtHDRate As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTARate As System.Windows.Forms.TextBox
    Friend WithEvents btnBarcodePrint As System.Windows.Forms.Button
    Public WithEvents Picture As System.Windows.Forms.PictureBox
    Private WithEvents BRemove As System.Windows.Forms.Button
    Private WithEvents Browse As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtImagePath As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdateImage As System.Windows.Forms.Button
    Friend WithEvents numSellingPrice As NumericUpDown
    Friend WithEvents lblSellingPrice As Label
    Friend WithEvents numPurPrice As NumericUpDown
    Friend WithEvents lblPurPrice As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents dgvPurPrice As DataGridViewTextBoxColumn
    Friend WithEvents dgvSellingPrice As DataGridViewTextBoxColumn
End Class
