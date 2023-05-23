<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRPOSReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRPOSReport))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnMainWHValuation = New System.Windows.Forms.Button()
        Me.btnStockUsage = New System.Windows.Forms.Button()
        Me.cmbMisc = New System.Windows.Forms.ComboBox()
        Me.lblMisce = New System.Windows.Forms.Label()
        Me.btnSalesExpensesOverview = New System.Windows.Forms.Button()
        Me.salesExpense_dateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.salesExpense_dateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnHappyHour = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.dateSalesTo = New System.Windows.Forms.DateTimePicker()
        Me.lbldateSalesTo = New System.Windows.Forms.Label()
        Me.dateSalesFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblDateSalesFrom = New System.Windows.Forms.Label()
        Me.cmbWaiter = New System.Windows.Forms.ComboBox()
        Me.lblWaiter = New System.Windows.Forms.Label()
        Me.btnProfitLoss = New System.Windows.Forms.Button()
        Me.grbStockContent = New System.Windows.Forms.GroupBox()
        Me.cmbSection = New System.Windows.Forms.ComboBox()
        Me.lblSection = New System.Windows.Forms.Label()
        Me.cmbDestination = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbSource = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnStockTransfer = New System.Windows.Forms.Button()
        Me.cmbItemName = New System.Windows.Forms.ComboBox()
        Me.btnstkBalance = New System.Windows.Forms.Button()
        Me.btnstockContentrpt = New System.Windows.Forms.Button()
        Me.date1 = New System.Windows.Forms.DateTimePicker()
        Me.date2 = New System.Windows.Forms.DateTimePicker()
        Me.lblTostock = New System.Windows.Forms.Label()
        Me.lblItemstock = New System.Windows.Forms.Label()
        Me.lblFromstock = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbWaiterName = New System.Windows.Forms.ComboBox()
        Me.cmbOperatorID = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnViewReport = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grbStockContent.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Location = New System.Drawing.Point(5, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(633, 625)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(366, 45)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 102)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search By Monthly Sales"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.CustomFormat = "MM/yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(6, 58)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(132, 29)
        Me.DateTimePicker1.TabIndex = 108
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(144, 37)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(110, 50)
        Me.Button5.TabIndex = 109
        Me.Button5.Text = "View Report"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpDateTo)
        Me.GroupBox1.Controls.Add(Me.dtpDateFrom)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(355, 102)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search By Bill Date :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(185, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "To :"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo.Location = New System.Drawing.Point(189, 60)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(156, 29)
        Me.dtpDateTo.TabIndex = 107
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom.Location = New System.Drawing.Point(22, 60)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(152, 29)
        Me.dtpDateFrom.TabIndex = 106
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "From :"
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.GroupBox4)
        Me.Panel5.Controls.Add(Me.GroupBox3)
        Me.Panel5.Controls.Add(Me.btnProfitLoss)
        Me.Panel5.Controls.Add(Me.grbStockContent)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.cmbWaiterName)
        Me.Panel5.Controls.Add(Me.cmbOperatorID)
        Me.Panel5.Controls.Add(Me.Button4)
        Me.Panel5.Controls.Add(Me.Button3)
        Me.Panel5.Controls.Add(Me.Button2)
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.btnViewReport)
        Me.Panel5.Controls.Add(Me.btnReset)
        Me.Panel5.Location = New System.Drawing.Point(5, 153)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(623, 468)
        Me.Panel5.TabIndex = 42
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnMainWHValuation)
        Me.GroupBox4.Controls.Add(Me.btnStockUsage)
        Me.GroupBox4.Controls.Add(Me.cmbMisc)
        Me.GroupBox4.Controls.Add(Me.lblMisce)
        Me.GroupBox4.Controls.Add(Me.btnSalesExpensesOverview)
        Me.GroupBox4.Controls.Add(Me.salesExpense_dateTo)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.salesExpense_dateFrom)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 312)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(326, 151)
        Me.GroupBox4.TabIndex = 119
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Miscellaneous Report"
        '
        'btnMainWHValuation
        '
        Me.btnMainWHValuation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMainWHValuation.FlatAppearance.BorderSize = 0
        Me.btnMainWHValuation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainWHValuation.Image = CType(resources.GetObject("btnMainWHValuation.Image"), System.Drawing.Image)
        Me.btnMainWHValuation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMainWHValuation.Location = New System.Drawing.Point(234, 110)
        Me.btnMainWHValuation.Name = "btnMainWHValuation"
        Me.btnMainWHValuation.Size = New System.Drawing.Size(91, 35)
        Me.btnMainWHValuation.TabIndex = 122
        Me.btnMainWHValuation.Text = "Main WH Valution"
        Me.btnMainWHValuation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMainWHValuation.UseVisualStyleBackColor = True
        '
        'btnStockUsage
        '
        Me.btnStockUsage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockUsage.FlatAppearance.BorderSize = 0
        Me.btnStockUsage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockUsage.Image = CType(resources.GetObject("btnStockUsage.Image"), System.Drawing.Image)
        Me.btnStockUsage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockUsage.Location = New System.Drawing.Point(130, 110)
        Me.btnStockUsage.Name = "btnStockUsage"
        Me.btnStockUsage.Size = New System.Drawing.Size(102, 35)
        Me.btnStockUsage.TabIndex = 119
        Me.btnStockUsage.Text = "Stock Usage"
        Me.btnStockUsage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStockUsage.UseVisualStyleBackColor = True
        '
        'cmbMisc
        '
        Me.cmbMisc.FormattingEnabled = True
        Me.cmbMisc.Location = New System.Drawing.Point(65, 69)
        Me.cmbMisc.Name = "cmbMisc"
        Me.cmbMisc.Size = New System.Drawing.Size(182, 21)
        Me.cmbMisc.TabIndex = 121
        '
        'lblMisce
        '
        Me.lblMisce.AutoSize = True
        Me.lblMisce.Location = New System.Drawing.Point(7, 72)
        Me.lblMisce.Name = "lblMisce"
        Me.lblMisce.Size = New System.Drawing.Size(49, 13)
        Me.lblMisce.TabIndex = 120
        Me.lblMisce.Text = "Category"
        '
        'btnSalesExpensesOverview
        '
        Me.btnSalesExpensesOverview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalesExpensesOverview.FlatAppearance.BorderSize = 0
        Me.btnSalesExpensesOverview.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalesExpensesOverview.Image = CType(resources.GetObject("btnSalesExpensesOverview.Image"), System.Drawing.Image)
        Me.btnSalesExpensesOverview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalesExpensesOverview.Location = New System.Drawing.Point(3, 110)
        Me.btnSalesExpensesOverview.Name = "btnSalesExpensesOverview"
        Me.btnSalesExpensesOverview.Size = New System.Drawing.Size(124, 35)
        Me.btnSalesExpensesOverview.TabIndex = 113
        Me.btnSalesExpensesOverview.Text = "Sales && Expenses Overview"
        Me.btnSalesExpensesOverview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalesExpensesOverview.UseVisualStyleBackColor = True
        '
        'salesExpense_dateTo
        '
        Me.salesExpense_dateTo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.salesExpense_dateTo.CustomFormat = "dd/MM/yyyy"
        Me.salesExpense_dateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.salesExpense_dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.salesExpense_dateTo.Location = New System.Drawing.Point(65, 44)
        Me.salesExpense_dateTo.Name = "salesExpense_dateTo"
        Me.salesExpense_dateTo.Size = New System.Drawing.Size(116, 22)
        Me.salesExpense_dateTo.TabIndex = 115
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 114
        Me.Label9.Text = "Date To"
        '
        'salesExpense_dateFrom
        '
        Me.salesExpense_dateFrom.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.salesExpense_dateFrom.CustomFormat = "dd/MM/yyyy"
        Me.salesExpense_dateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.salesExpense_dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.salesExpense_dateFrom.Location = New System.Drawing.Point(65, 19)
        Me.salesExpense_dateFrom.Name = "salesExpense_dateFrom"
        Me.salesExpense_dateFrom.Size = New System.Drawing.Size(116, 22)
        Me.salesExpense_dateFrom.TabIndex = 113
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Date From"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnHappyHour)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.cmbCategory)
        Me.GroupBox3.Controls.Add(Me.lblCategory)
        Me.GroupBox3.Controls.Add(Me.dateSalesTo)
        Me.GroupBox3.Controls.Add(Me.lbldateSalesTo)
        Me.GroupBox3.Controls.Add(Me.dateSalesFrom)
        Me.GroupBox3.Controls.Add(Me.lblDateSalesFrom)
        Me.GroupBox3.Controls.Add(Me.cmbWaiter)
        Me.GroupBox3.Controls.Add(Me.lblWaiter)
        Me.GroupBox3.Location = New System.Drawing.Point(339, 312)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(275, 152)
        Me.GroupBox3.TabIndex = 115
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Itemized Sales Report"
        '
        'btnHappyHour
        '
        Me.btnHappyHour.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnHappyHour.FlatAppearance.BorderSize = 0
        Me.btnHappyHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHappyHour.Image = CType(resources.GetObject("btnHappyHour.Image"), System.Drawing.Image)
        Me.btnHappyHour.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHappyHour.Location = New System.Drawing.Point(159, 114)
        Me.btnHappyHour.Name = "btnHappyHour"
        Me.btnHappyHour.Size = New System.Drawing.Size(110, 35)
        Me.btnHappyHour.TabIndex = 118
        Me.btnHappyHour.Text = "Happy Hours"
        Me.btnHappyHour.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHappyHour.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(8, 114)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(145, 35)
        Me.Button6.TabIndex = 113
        Me.Button6.Text = "Itemized Sales Report"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'cmbCategory
        '
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(65, 91)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(145, 21)
        Me.cmbCategory.TabIndex = 117
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Location = New System.Drawing.Point(7, 94)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(49, 13)
        Me.lblCategory.TabIndex = 116
        Me.lblCategory.Text = "Category"
        '
        'dateSalesTo
        '
        Me.dateSalesTo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateSalesTo.CustomFormat = "dd/MM/yyyy"
        Me.dateSalesTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateSalesTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateSalesTo.Location = New System.Drawing.Point(65, 66)
        Me.dateSalesTo.Name = "dateSalesTo"
        Me.dateSalesTo.Size = New System.Drawing.Size(116, 22)
        Me.dateSalesTo.TabIndex = 115
        '
        'lbldateSalesTo
        '
        Me.lbldateSalesTo.AutoSize = True
        Me.lbldateSalesTo.Location = New System.Drawing.Point(7, 70)
        Me.lbldateSalesTo.Name = "lbldateSalesTo"
        Me.lbldateSalesTo.Size = New System.Drawing.Size(46, 13)
        Me.lbldateSalesTo.TabIndex = 114
        Me.lbldateSalesTo.Text = "Date To"
        '
        'dateSalesFrom
        '
        Me.dateSalesFrom.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateSalesFrom.CustomFormat = "dd/MM/yyyy"
        Me.dateSalesFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateSalesFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateSalesFrom.Location = New System.Drawing.Point(65, 41)
        Me.dateSalesFrom.Name = "dateSalesFrom"
        Me.dateSalesFrom.Size = New System.Drawing.Size(116, 22)
        Me.dateSalesFrom.TabIndex = 113
        '
        'lblDateSalesFrom
        '
        Me.lblDateSalesFrom.AutoSize = True
        Me.lblDateSalesFrom.Location = New System.Drawing.Point(7, 45)
        Me.lblDateSalesFrom.Name = "lblDateSalesFrom"
        Me.lblDateSalesFrom.Size = New System.Drawing.Size(56, 13)
        Me.lblDateSalesFrom.TabIndex = 2
        Me.lblDateSalesFrom.Text = "Date From"
        '
        'cmbWaiter
        '
        Me.cmbWaiter.FormattingEnabled = True
        Me.cmbWaiter.Location = New System.Drawing.Point(65, 17)
        Me.cmbWaiter.Name = "cmbWaiter"
        Me.cmbWaiter.Size = New System.Drawing.Size(145, 21)
        Me.cmbWaiter.TabIndex = 1
        '
        'lblWaiter
        '
        Me.lblWaiter.AutoSize = True
        Me.lblWaiter.Location = New System.Drawing.Point(7, 20)
        Me.lblWaiter.Name = "lblWaiter"
        Me.lblWaiter.Size = New System.Drawing.Size(38, 13)
        Me.lblWaiter.TabIndex = 0
        Me.lblWaiter.Text = "Waiter"
        '
        'btnProfitLoss
        '
        Me.btnProfitLoss.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProfitLoss.FlatAppearance.BorderSize = 0
        Me.btnProfitLoss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProfitLoss.Image = CType(resources.GetObject("btnProfitLoss.Image"), System.Drawing.Image)
        Me.btnProfitLoss.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProfitLoss.Location = New System.Drawing.Point(468, 44)
        Me.btnProfitLoss.Name = "btnProfitLoss"
        Me.btnProfitLoss.Size = New System.Drawing.Size(146, 50)
        Me.btnProfitLoss.TabIndex = 19
        Me.btnProfitLoss.Text = "View Profit / Loss" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Date range in: Stock)"
        Me.btnProfitLoss.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProfitLoss.UseVisualStyleBackColor = True
        '
        'grbStockContent
        '
        Me.grbStockContent.Controls.Add(Me.cmbSection)
        Me.grbStockContent.Controls.Add(Me.lblSection)
        Me.grbStockContent.Controls.Add(Me.cmbDestination)
        Me.grbStockContent.Controls.Add(Me.Label7)
        Me.grbStockContent.Controls.Add(Me.cmbSource)
        Me.grbStockContent.Controls.Add(Me.Label6)
        Me.grbStockContent.Controls.Add(Me.btnStockTransfer)
        Me.grbStockContent.Controls.Add(Me.cmbItemName)
        Me.grbStockContent.Controls.Add(Me.btnstkBalance)
        Me.grbStockContent.Controls.Add(Me.btnstockContentrpt)
        Me.grbStockContent.Controls.Add(Me.date1)
        Me.grbStockContent.Controls.Add(Me.date2)
        Me.grbStockContent.Controls.Add(Me.lblTostock)
        Me.grbStockContent.Controls.Add(Me.lblItemstock)
        Me.grbStockContent.Controls.Add(Me.lblFromstock)
        Me.grbStockContent.Location = New System.Drawing.Point(227, 130)
        Me.grbStockContent.Name = "grbStockContent"
        Me.grbStockContent.Size = New System.Drawing.Size(387, 176)
        Me.grbStockContent.TabIndex = 15
        Me.grbStockContent.TabStop = False
        Me.grbStockContent.Text = "Stock"
        '
        'cmbSection
        '
        Me.cmbSection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbSection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSection.FormattingEnabled = True
        Me.cmbSection.Location = New System.Drawing.Point(67, 72)
        Me.cmbSection.Name = "cmbSection"
        Me.cmbSection.Size = New System.Drawing.Size(187, 21)
        Me.cmbSection.TabIndex = 118
        '
        'lblSection
        '
        Me.lblSection.AutoSize = True
        Me.lblSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSection.Location = New System.Drawing.Point(16, 75)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(46, 13)
        Me.lblSection.TabIndex = 119
        Me.lblSection.Text = "Section:"
        '
        'cmbDestination
        '
        Me.cmbDestination.FormattingEnabled = True
        Me.cmbDestination.Location = New System.Drawing.Point(67, 47)
        Me.cmbDestination.Name = "cmbDestination"
        Me.cmbDestination.Size = New System.Drawing.Size(187, 21)
        Me.cmbDestination.TabIndex = 117
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "Dest :"
        '
        'cmbSource
        '
        Me.cmbSource.FormattingEnabled = True
        Me.cmbSource.Location = New System.Drawing.Point(67, 21)
        Me.cmbSource.Name = "cmbSource"
        Me.cmbSource.Size = New System.Drawing.Size(187, 21)
        Me.cmbSource.TabIndex = 115
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "Source:"
        '
        'btnStockTransfer
        '
        Me.btnStockTransfer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockTransfer.FlatAppearance.BorderSize = 0
        Me.btnStockTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockTransfer.Image = CType(resources.GetObject("btnStockTransfer.Image"), System.Drawing.Image)
        Me.btnStockTransfer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockTransfer.Location = New System.Drawing.Point(271, 14)
        Me.btnStockTransfer.Name = "btnStockTransfer"
        Me.btnStockTransfer.Size = New System.Drawing.Size(110, 35)
        Me.btnStockTransfer.TabIndex = 113
        Me.btnStockTransfer.Text = "Stock Transfer"
        Me.btnStockTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStockTransfer.UseVisualStyleBackColor = True
        '
        'cmbItemName
        '
        Me.cmbItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItemName.FormattingEnabled = True
        Me.cmbItemName.Location = New System.Drawing.Point(67, 97)
        Me.cmbItemName.Name = "cmbItemName"
        Me.cmbItemName.Size = New System.Drawing.Size(187, 21)
        Me.cmbItemName.TabIndex = 16
        '
        'btnstkBalance
        '
        Me.btnstkBalance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnstkBalance.FlatAppearance.BorderSize = 0
        Me.btnstkBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnstkBalance.Image = CType(resources.GetObject("btnstkBalance.Image"), System.Drawing.Image)
        Me.btnstkBalance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnstkBalance.Location = New System.Drawing.Point(271, 54)
        Me.btnstkBalance.Name = "btnstkBalance"
        Me.btnstkBalance.Size = New System.Drawing.Size(110, 35)
        Me.btnstkBalance.TabIndex = 112
        Me.btnstkBalance.Text = "Stock Balance"
        Me.btnstkBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnstkBalance.UseVisualStyleBackColor = True
        '
        'btnstockContentrpt
        '
        Me.btnstockContentrpt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnstockContentrpt.FlatAppearance.BorderSize = 0
        Me.btnstockContentrpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnstockContentrpt.Image = CType(resources.GetObject("btnstockContentrpt.Image"), System.Drawing.Image)
        Me.btnstockContentrpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnstockContentrpt.Location = New System.Drawing.Point(271, 94)
        Me.btnstockContentrpt.Name = "btnstockContentrpt"
        Me.btnstockContentrpt.Size = New System.Drawing.Size(110, 35)
        Me.btnstockContentrpt.TabIndex = 110
        Me.btnstockContentrpt.Text = "Stock Content"
        Me.btnstockContentrpt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnstockContentrpt.UseVisualStyleBackColor = True
        '
        'date1
        '
        Me.date1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date1.CustomFormat = "dd/MM/yyyy"
        Me.date1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.date1.Location = New System.Drawing.Point(67, 122)
        Me.date1.Name = "date1"
        Me.date1.Size = New System.Drawing.Size(98, 20)
        Me.date1.TabIndex = 110
        '
        'date2
        '
        Me.date2.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date2.CustomFormat = "dd/MM/yyyy"
        Me.date2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.date2.Location = New System.Drawing.Point(67, 146)
        Me.date2.Name = "date2"
        Me.date2.Size = New System.Drawing.Size(98, 20)
        Me.date2.TabIndex = 111
        '
        'lblTostock
        '
        Me.lblTostock.AutoSize = True
        Me.lblTostock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTostock.Location = New System.Drawing.Point(36, 148)
        Me.lblTostock.Name = "lblTostock"
        Me.lblTostock.Size = New System.Drawing.Size(26, 13)
        Me.lblTostock.TabIndex = 109
        Me.lblTostock.Text = "To :"
        '
        'lblItemstock
        '
        Me.lblItemstock.AutoSize = True
        Me.lblItemstock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemstock.Location = New System.Drawing.Point(32, 102)
        Me.lblItemstock.Name = "lblItemstock"
        Me.lblItemstock.Size = New System.Drawing.Size(30, 13)
        Me.lblItemstock.TabIndex = 16
        Me.lblItemstock.Text = "Item:"
        '
        'lblFromstock
        '
        Me.lblFromstock.AutoSize = True
        Me.lblFromstock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFromstock.Location = New System.Drawing.Point(26, 125)
        Me.lblFromstock.Name = "lblFromstock"
        Me.lblFromstock.Size = New System.Drawing.Size(36, 13)
        Me.lblFromstock.TabIndex = 108
        Me.lblFromstock.Text = "From :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(223, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Search By Waiter :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(223, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(169, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Search By Operator ID :"
        '
        'cmbWaiterName
        '
        Me.cmbWaiterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWaiterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbWaiterName.FormattingEnabled = True
        Me.cmbWaiterName.Location = New System.Drawing.Point(223, 92)
        Me.cmbWaiterName.Name = "cmbWaiterName"
        Me.cmbWaiterName.Size = New System.Drawing.Size(182, 32)
        Me.cmbWaiterName.TabIndex = 11
        '
        'cmbOperatorID
        '
        Me.cmbOperatorID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperatorID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOperatorID.FormattingEnabled = True
        Me.cmbOperatorID.Location = New System.Drawing.Point(223, 31)
        Me.cmbOperatorID.Name = "cmbOperatorID"
        Me.cmbOperatorID.Size = New System.Drawing.Size(182, 32)
        Me.cmbOperatorID.TabIndex = 10
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(7, 190)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(212, 50)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "View Report Express Billing"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(7, 246)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(212, 50)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "View Report Home Delivery Billing"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(7, 134)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(210, 50)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "View Report Takeaway Billing"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(7, 78)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(210, 50)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "View Report KOT Billing"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnViewReport
        '
        Me.btnViewReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewReport.FlatAppearance.BorderSize = 0
        Me.btnViewReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewReport.Image = CType(resources.GetObject("btnViewReport.Image"), System.Drawing.Image)
        Me.btnViewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewReport.Location = New System.Drawing.Point(7, 30)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(210, 42)
        Me.btnViewReport.TabIndex = 5
        Me.btnViewReport.Text = "View Report Overall"
        Me.btnViewReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(517, 2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(97, 40)
        Me.btnReset.TabIndex = 0
        Me.btnReset.Text = "Reset"
        Me.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(5, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(577, 41)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(148, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(258, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Restaurant POS Report"
        '
        'btnClose
        '
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(588, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 41)
        Me.btnClose.TabIndex = 4
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'frmRPOSReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(642, 634)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRPOSReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grbStockContent.ResumeLayout(False)
        Me.grbStockContent.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbWaiterName As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOperatorID As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grbStockContent As GroupBox
    Friend WithEvents lblItemstock As Label
    Friend WithEvents btnstockContentrpt As Button
    Friend WithEvents date1 As DateTimePicker
    Friend WithEvents date2 As DateTimePicker
    Friend WithEvents lblTostock As Label
    Friend WithEvents lblFromstock As Label
    Friend WithEvents btnstkBalance As Button
    Friend WithEvents cmbItemName As ComboBox
    Friend WithEvents btnStockTransfer As Button
    Friend WithEvents cmbSource As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbDestination As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnProfitLoss As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Button6 As Button
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents dateSalesTo As DateTimePicker
    Friend WithEvents lbldateSalesTo As Label
    Friend WithEvents dateSalesFrom As DateTimePicker
    Friend WithEvents lblDateSalesFrom As Label
    Friend WithEvents cmbWaiter As ComboBox
    Friend WithEvents lblWaiter As Label
    Friend WithEvents cmbSection As ComboBox
    Friend WithEvents lblSection As Label
    Friend WithEvents btnHappyHour As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnSalesExpensesOverview As Button
    Friend WithEvents salesExpense_dateTo As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents salesExpense_dateFrom As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents btnStockUsage As Button
    Friend WithEvents cmbMisc As ComboBox
    Friend WithEvents lblMisce As Label
    Friend WithEvents btnMainWHValuation As Button
End Class
