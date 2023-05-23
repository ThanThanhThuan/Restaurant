<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountingReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountingReport))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnStockUsed = New System.Windows.Forms.Button()
        Me.btnStockOut_RM = New System.Windows.Forms.Button()
        Me.btnStockIn_RM = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnStoreStockOUT = New System.Windows.Forms.Button()
        Me.btnStoreStockIN = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnExpiredProducts = New System.Windows.Forms.Button()
        Me.btnStockIN = New System.Windows.Forms.Button()
        Me.btnLowStock = New System.Windows.Forms.Button()
        Me.btnStockOut = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnCollectionsByDP = New System.Windows.Forms.Button()
        Me.btnTip = New System.Windows.Forms.Button()
        Me.btnCreditors = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnGeneralDaybook = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnBalanceSheet = New System.Windows.Forms.Button()
        Me.btnJournalEntry = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnInputTax = New System.Windows.Forms.Button()
        Me.btnGeneralLedger = New System.Windows.Forms.Button()
        Me.btnTaxReport = New System.Windows.Forms.Button()
        Me.btnStockTransfer = New System.Windows.Forms.Button()
        Me.btnVouchers = New System.Windows.Forms.Button()
        Me.btnPurchase = New System.Windows.Forms.Button()
        Me.btnTrialBalance = New System.Windows.Forms.Button()
        Me.txtCashBook = New System.Windows.Forms.Button()
        Me.btnPurchaseDaybook = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbSupplierName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSupplierLedger = New System.Windows.Forms.Button()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtSupplierID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox7)
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.btnReset)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Location = New System.Drawing.Point(5, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(811, 655)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnStockUsed)
        Me.GroupBox7.Controls.Add(Me.btnStockOut_RM)
        Me.GroupBox7.Controls.Add(Me.btnStockIn_RM)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(315, 495)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(243, 150)
        Me.GroupBox7.TabIndex = 116
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Raw Materials Inventory (Kitchen/Section)"
        '
        'btnStockUsed
        '
        Me.btnStockUsed.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockUsed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockUsed.Image = CType(resources.GetObject("btnStockUsed.Image"), System.Drawing.Image)
        Me.btnStockUsed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockUsed.Location = New System.Drawing.Point(115, 87)
        Me.btnStockUsed.Name = "btnStockUsed"
        Me.btnStockUsed.Size = New System.Drawing.Size(116, 50)
        Me.btnStockUsed.TabIndex = 115
        Me.btnStockUsed.Text = "Stock Used"
        Me.btnStockUsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStockUsed.UseVisualStyleBackColor = True
        '
        'btnStockOut_RM
        '
        Me.btnStockOut_RM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockOut_RM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockOut_RM.Image = CType(resources.GetObject("btnStockOut_RM.Image"), System.Drawing.Image)
        Me.btnStockOut_RM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockOut_RM.Location = New System.Drawing.Point(115, 31)
        Me.btnStockOut_RM.Name = "btnStockOut_RM"
        Me.btnStockOut_RM.Size = New System.Drawing.Size(116, 50)
        Me.btnStockOut_RM.TabIndex = 113
        Me.btnStockOut_RM.Text = "Stock OUT"
        Me.btnStockOut_RM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStockOut_RM.UseVisualStyleBackColor = True
        Me.btnStockOut_RM.Visible = False
        '
        'btnStockIn_RM
        '
        Me.btnStockIn_RM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockIn_RM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockIn_RM.Image = CType(resources.GetObject("btnStockIn_RM.Image"), System.Drawing.Image)
        Me.btnStockIn_RM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockIn_RM.Location = New System.Drawing.Point(6, 31)
        Me.btnStockIn_RM.Name = "btnStockIn_RM"
        Me.btnStockIn_RM.Size = New System.Drawing.Size(103, 50)
        Me.btnStockIn_RM.TabIndex = 112
        Me.btnStockIn_RM.Text = "Stock"
        Me.btnStockIn_RM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStockIn_RM.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnStoreStockOUT)
        Me.GroupBox6.Controls.Add(Me.btnStoreStockIN)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(564, 495)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(232, 93)
        Me.GroupBox6.TabIndex = 115
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Menu Items Inventory (Restaurant)"
        '
        'btnStoreStockOUT
        '
        Me.btnStoreStockOUT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStoreStockOUT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStoreStockOUT.Image = CType(resources.GetObject("btnStoreStockOUT.Image"), System.Drawing.Image)
        Me.btnStoreStockOUT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStoreStockOUT.Location = New System.Drawing.Point(107, 31)
        Me.btnStoreStockOUT.Name = "btnStoreStockOUT"
        Me.btnStoreStockOUT.Size = New System.Drawing.Size(111, 50)
        Me.btnStoreStockOUT.TabIndex = 113
        Me.btnStoreStockOUT.Text = "Stock OUT"
        Me.btnStoreStockOUT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStoreStockOUT.UseVisualStyleBackColor = True
        Me.btnStoreStockOUT.Visible = False
        '
        'btnStoreStockIN
        '
        Me.btnStoreStockIN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStoreStockIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStoreStockIN.Image = CType(resources.GetObject("btnStoreStockIN.Image"), System.Drawing.Image)
        Me.btnStoreStockIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStoreStockIN.Location = New System.Drawing.Point(6, 31)
        Me.btnStoreStockIN.Name = "btnStoreStockIN"
        Me.btnStoreStockIN.Size = New System.Drawing.Size(97, 50)
        Me.btnStoreStockIN.TabIndex = 112
        Me.btnStoreStockIN.Text = "Stock"
        Me.btnStoreStockIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStoreStockIN.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnExpiredProducts)
        Me.GroupBox5.Controls.Add(Me.btnStockIN)
        Me.GroupBox5.Controls.Add(Me.btnLowStock)
        Me.GroupBox5.Controls.Add(Me.btnStockOut)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(5, 495)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(304, 152)
        Me.GroupBox5.TabIndex = 114
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Warehouse Inventory"
        '
        'btnExpiredProducts
        '
        Me.btnExpiredProducts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExpiredProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpiredProducts.Image = CType(resources.GetObject("btnExpiredProducts.Image"), System.Drawing.Image)
        Me.btnExpiredProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExpiredProducts.Location = New System.Drawing.Point(151, 87)
        Me.btnExpiredProducts.Name = "btnExpiredProducts"
        Me.btnExpiredProducts.Size = New System.Drawing.Size(139, 50)
        Me.btnExpiredProducts.TabIndex = 114
        Me.btnExpiredProducts.Text = "Expired Products"
        Me.btnExpiredProducts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExpiredProducts.UseVisualStyleBackColor = True
        '
        'btnStockIN
        '
        Me.btnStockIN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockIN.Image = CType(resources.GetObject("btnStockIN.Image"), System.Drawing.Image)
        Me.btnStockIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockIN.Location = New System.Drawing.Point(6, 31)
        Me.btnStockIN.Name = "btnStockIN"
        Me.btnStockIN.Size = New System.Drawing.Size(139, 50)
        Me.btnStockIN.TabIndex = 111
        Me.btnStockIN.Text = "Stock"
        Me.btnStockIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStockIN.UseVisualStyleBackColor = True
        '
        'btnLowStock
        '
        Me.btnLowStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLowStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLowStock.Image = CType(resources.GetObject("btnLowStock.Image"), System.Drawing.Image)
        Me.btnLowStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLowStock.Location = New System.Drawing.Point(6, 87)
        Me.btnLowStock.Name = "btnLowStock"
        Me.btnLowStock.Size = New System.Drawing.Size(139, 50)
        Me.btnLowStock.TabIndex = 113
        Me.btnLowStock.Text = "Low Stock"
        Me.btnLowStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLowStock.UseVisualStyleBackColor = True
        '
        'btnStockOut
        '
        Me.btnStockOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockOut.Image = CType(resources.GetObject("btnStockOut.Image"), System.Drawing.Image)
        Me.btnStockOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockOut.Location = New System.Drawing.Point(151, 31)
        Me.btnStockOut.Name = "btnStockOut"
        Me.btnStockOut.Size = New System.Drawing.Size(139, 50)
        Me.btnStockOut.TabIndex = 112
        Me.btnStockOut.Text = "Stock OUT"
        Me.btnStockOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStockOut.UseVisualStyleBackColor = True
        Me.btnStockOut.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnCollectionsByDP)
        Me.Panel3.Controls.Add(Me.btnTip)
        Me.Panel3.Controls.Add(Me.btnCreditors)
        Me.Panel3.Location = New System.Drawing.Point(343, 404)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(453, 85)
        Me.Panel3.TabIndex = 113
        '
        'btnCollectionsByDP
        '
        Me.btnCollectionsByDP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCollectionsByDP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCollectionsByDP.Image = CType(resources.GetObject("btnCollectionsByDP.Image"), System.Drawing.Image)
        Me.btnCollectionsByDP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCollectionsByDP.Location = New System.Drawing.Point(9, 17)
        Me.btnCollectionsByDP.Name = "btnCollectionsByDP"
        Me.btnCollectionsByDP.Size = New System.Drawing.Size(141, 50)
        Me.btnCollectionsByDP.TabIndex = 112
        Me.btnCollectionsByDP.Text = "Collections By Delivery Person"
        Me.btnCollectionsByDP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCollectionsByDP.UseVisualStyleBackColor = True
        '
        'btnTip
        '
        Me.btnTip.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTip.Image = CType(resources.GetObject("btnTip.Image"), System.Drawing.Image)
        Me.btnTip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTip.Location = New System.Drawing.Point(299, 17)
        Me.btnTip.Name = "btnTip"
        Me.btnTip.Size = New System.Drawing.Size(139, 50)
        Me.btnTip.TabIndex = 111
        Me.btnTip.Text = "Tip"
        Me.btnTip.UseVisualStyleBackColor = True
        '
        'btnCreditors
        '
        Me.btnCreditors.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreditors.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreditors.Image = CType(resources.GetObject("btnCreditors.Image"), System.Drawing.Image)
        Me.btnCreditors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreditors.Location = New System.Drawing.Point(154, 17)
        Me.btnCreditors.Name = "btnCreditors"
        Me.btnCreditors.Size = New System.Drawing.Size(139, 50)
        Me.btnCreditors.TabIndex = 110
        Me.btnCreditors.Text = "Creditors List"
        Me.btnCreditors.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreditors.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnGeneralDaybook)
        Me.GroupBox4.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(5, 394)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(332, 95)
        Me.GroupBox4.TabIndex = 112
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Search By Date"
        '
        'btnGeneralDaybook
        '
        Me.btnGeneralDaybook.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGeneralDaybook.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGeneralDaybook.Image = CType(resources.GetObject("btnGeneralDaybook.Image"), System.Drawing.Image)
        Me.btnGeneralDaybook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGeneralDaybook.Location = New System.Drawing.Point(185, 30)
        Me.btnGeneralDaybook.Name = "btnGeneralDaybook"
        Me.btnGeneralDaybook.Size = New System.Drawing.Size(139, 50)
        Me.btnGeneralDaybook.TabIndex = 108
        Me.btnGeneralDaybook.Text = "General Daybook"
        Me.btnGeneralDaybook.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGeneralDaybook.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(27, 41)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(152, 29)
        Me.DateTimePicker1.TabIndex = 107
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnBalanceSheet)
        Me.GroupBox3.Controls.Add(Me.btnJournalEntry)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.Panel5)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 52)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(799, 214)
        Me.GroupBox3.TabIndex = 111
        Me.GroupBox3.TabStop = False
        '
        'btnBalanceSheet
        '
        Me.btnBalanceSheet.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBalanceSheet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBalanceSheet.Image = CType(resources.GetObject("btnBalanceSheet.Image"), System.Drawing.Image)
        Me.btnBalanceSheet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBalanceSheet.Location = New System.Drawing.Point(151, 117)
        Me.btnBalanceSheet.Name = "btnBalanceSheet"
        Me.btnBalanceSheet.Size = New System.Drawing.Size(139, 50)
        Me.btnBalanceSheet.TabIndex = 44
        Me.btnBalanceSheet.Text = "Balance Sheet"
        Me.btnBalanceSheet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBalanceSheet.UseVisualStyleBackColor = True
        '
        'btnJournalEntry
        '
        Me.btnJournalEntry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnJournalEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJournalEntry.Image = CType(resources.GetObject("btnJournalEntry.Image"), System.Drawing.Image)
        Me.btnJournalEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnJournalEntry.Location = New System.Drawing.Point(6, 117)
        Me.btnJournalEntry.Name = "btnJournalEntry"
        Me.btnJournalEntry.Size = New System.Drawing.Size(139, 50)
        Me.btnJournalEntry.TabIndex = 43
        Me.btnJournalEntry.Text = "Journal Entry"
        Me.btnJournalEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnJournalEntry.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpDateTo)
        Me.GroupBox1.Controls.Add(Me.dtpDateFrom)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(355, 102)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search By Date :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(185, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "To :"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo.Location = New System.Drawing.Point(189, 60)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(156, 29)
        Me.dtpDateTo.TabIndex = 107
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom.Location = New System.Drawing.Point(22, 60)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(152, 29)
        Me.dtpDateFrom.TabIndex = 106
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "From :"
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.btnInputTax)
        Me.Panel5.Controls.Add(Me.btnGeneralLedger)
        Me.Panel5.Controls.Add(Me.btnTaxReport)
        Me.Panel5.Controls.Add(Me.btnStockTransfer)
        Me.Panel5.Controls.Add(Me.btnVouchers)
        Me.Panel5.Controls.Add(Me.btnPurchase)
        Me.Panel5.Controls.Add(Me.btnTrialBalance)
        Me.Panel5.Controls.Add(Me.txtCashBook)
        Me.Panel5.Controls.Add(Me.btnPurchaseDaybook)
        Me.Panel5.Location = New System.Drawing.Point(367, 19)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(426, 183)
        Me.Panel5.TabIndex = 42
        '
        'btnInputTax
        '
        Me.btnInputTax.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInputTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInputTax.Image = CType(resources.GetObject("btnInputTax.Image"), System.Drawing.Image)
        Me.btnInputTax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInputTax.Location = New System.Drawing.Point(282, 125)
        Me.btnInputTax.Name = "btnInputTax"
        Me.btnInputTax.Size = New System.Drawing.Size(132, 50)
        Me.btnInputTax.TabIndex = 115
        Me.btnInputTax.Text = "Input Tax"
        Me.btnInputTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInputTax.UseVisualStyleBackColor = True
        '
        'btnGeneralLedger
        '
        Me.btnGeneralLedger.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGeneralLedger.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGeneralLedger.Image = CType(resources.GetObject("btnGeneralLedger.Image"), System.Drawing.Image)
        Me.btnGeneralLedger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGeneralLedger.Location = New System.Drawing.Point(282, 13)
        Me.btnGeneralLedger.Name = "btnGeneralLedger"
        Me.btnGeneralLedger.Size = New System.Drawing.Size(132, 50)
        Me.btnGeneralLedger.TabIndex = 114
        Me.btnGeneralLedger.Text = "General Ledger"
        Me.btnGeneralLedger.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGeneralLedger.UseVisualStyleBackColor = True
        '
        'btnTaxReport
        '
        Me.btnTaxReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTaxReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTaxReport.Image = CType(resources.GetObject("btnTaxReport.Image"), System.Drawing.Image)
        Me.btnTaxReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTaxReport.Location = New System.Drawing.Point(152, 125)
        Me.btnTaxReport.Name = "btnTaxReport"
        Me.btnTaxReport.Size = New System.Drawing.Size(124, 50)
        Me.btnTaxReport.TabIndex = 113
        Me.btnTaxReport.Text = "Output Tax"
        Me.btnTaxReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTaxReport.UseVisualStyleBackColor = True
        '
        'btnStockTransfer
        '
        Me.btnStockTransfer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockTransfer.Image = CType(resources.GetObject("btnStockTransfer.Image"), System.Drawing.Image)
        Me.btnStockTransfer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockTransfer.Location = New System.Drawing.Point(7, 125)
        Me.btnStockTransfer.Name = "btnStockTransfer"
        Me.btnStockTransfer.Size = New System.Drawing.Size(139, 50)
        Me.btnStockTransfer.TabIndex = 12
        Me.btnStockTransfer.Text = "Stock Transfer"
        Me.btnStockTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStockTransfer.UseVisualStyleBackColor = True
        '
        'btnVouchers
        '
        Me.btnVouchers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVouchers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVouchers.Image = CType(resources.GetObject("btnVouchers.Image"), System.Drawing.Image)
        Me.btnVouchers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVouchers.Location = New System.Drawing.Point(282, 69)
        Me.btnVouchers.Name = "btnVouchers"
        Me.btnVouchers.Size = New System.Drawing.Size(132, 50)
        Me.btnVouchers.TabIndex = 11
        Me.btnVouchers.Text = "Vouchers"
        Me.btnVouchers.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVouchers.UseVisualStyleBackColor = True
        '
        'btnPurchase
        '
        Me.btnPurchase.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPurchase.Image = CType(resources.GetObject("btnPurchase.Image"), System.Drawing.Image)
        Me.btnPurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPurchase.Location = New System.Drawing.Point(152, 69)
        Me.btnPurchase.Name = "btnPurchase"
        Me.btnPurchase.Size = New System.Drawing.Size(124, 50)
        Me.btnPurchase.TabIndex = 9
        Me.btnPurchase.Text = "Purchases"
        Me.btnPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPurchase.UseVisualStyleBackColor = True
        '
        'btnTrialBalance
        '
        Me.btnTrialBalance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTrialBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrialBalance.Image = CType(resources.GetObject("btnTrialBalance.Image"), System.Drawing.Image)
        Me.btnTrialBalance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTrialBalance.Location = New System.Drawing.Point(7, 69)
        Me.btnTrialBalance.Name = "btnTrialBalance"
        Me.btnTrialBalance.Size = New System.Drawing.Size(139, 50)
        Me.btnTrialBalance.TabIndex = 8
        Me.btnTrialBalance.Text = "Trial Balance"
        Me.btnTrialBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTrialBalance.UseVisualStyleBackColor = True
        '
        'txtCashBook
        '
        Me.txtCashBook.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCashBook.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashBook.Image = CType(resources.GetObject("txtCashBook.Image"), System.Drawing.Image)
        Me.txtCashBook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtCashBook.Location = New System.Drawing.Point(152, 13)
        Me.txtCashBook.Name = "txtCashBook"
        Me.txtCashBook.Size = New System.Drawing.Size(124, 50)
        Me.txtCashBook.TabIndex = 6
        Me.txtCashBook.Text = "Cash Book"
        Me.txtCashBook.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.txtCashBook.UseVisualStyleBackColor = True
        '
        'btnPurchaseDaybook
        '
        Me.btnPurchaseDaybook.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPurchaseDaybook.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPurchaseDaybook.Image = CType(resources.GetObject("btnPurchaseDaybook.Image"), System.Drawing.Image)
        Me.btnPurchaseDaybook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPurchaseDaybook.Location = New System.Drawing.Point(7, 13)
        Me.btnPurchaseDaybook.Name = "btnPurchaseDaybook"
        Me.btnPurchaseDaybook.Size = New System.Drawing.Size(139, 50)
        Me.btnPurchaseDaybook.TabIndex = 5
        Me.btnPurchaseDaybook.Text = "Purchase Daybook"
        Me.btnPurchaseDaybook.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPurchaseDaybook.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.Location = New System.Drawing.Point(719, 5)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(40, 41)
        Me.btnReset.TabIndex = 0
        Me.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbSupplierName)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.btnSupplierLedger)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker3)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 272)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(758, 116)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search by Supplier Name and Date"
        '
        'cmbSupplierName
        '
        Me.cmbSupplierName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbSupplierName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSupplierName.FormattingEnabled = True
        Me.cmbSupplierName.Location = New System.Drawing.Point(20, 65)
        Me.cmbSupplierName.Name = "cmbSupplierName"
        Me.cmbSupplierName.Size = New System.Drawing.Size(234, 32)
        Me.cmbSupplierName.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 24)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Supplier Name :"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(449, 64)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(170, 29)
        Me.DateTimePicker2.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(445, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 24)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "To :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(262, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 24)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "From :"
        '
        'btnSupplierLedger
        '
        Me.btnSupplierLedger.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSupplierLedger.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplierLedger.Image = CType(resources.GetObject("btnSupplierLedger.Image"), System.Drawing.Image)
        Me.btnSupplierLedger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSupplierLedger.Location = New System.Drawing.Point(625, 54)
        Me.btnSupplierLedger.Name = "btnSupplierLedger"
        Me.btnSupplierLedger.Size = New System.Drawing.Size(124, 50)
        Me.btnSupplierLedger.TabIndex = 7
        Me.btnSupplierLedger.Text = "Supplier Ledger"
        Me.btnSupplierLedger.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSupplierLedger.UseVisualStyleBackColor = True
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker3.Location = New System.Drawing.Point(260, 64)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(183, 29)
        Me.DateTimePicker3.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.lblUser)
        Me.Panel2.Controls.Add(Me.txtSupplierID)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(5, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(708, 41)
        Me.Panel2.TabIndex = 0
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(83, 12)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(29, 13)
        Me.lblUser.TabIndex = 401
        Me.lblUser.Text = "User"
        Me.lblUser.Visible = False
        '
        'txtSupplierID
        '
        Me.txtSupplierID.Location = New System.Drawing.Point(47, 12)
        Me.txtSupplierID.Name = "txtSupplierID"
        Me.txtSupplierID.Size = New System.Drawing.Size(16, 20)
        Me.txtSupplierID.TabIndex = 2
        Me.txtSupplierID.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(255, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Accounting Reports"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(764, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 41)
        Me.btnClose.TabIndex = 4
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'frmAccountingReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(822, 662)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAccountingReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents btnPurchaseDaybook As System.Windows.Forms.Button
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCashBook As System.Windows.Forms.Button
    Friend WithEvents btnSupplierLedger As System.Windows.Forms.Button
    Friend WithEvents btnPurchase As System.Windows.Forms.Button
    Friend WithEvents btnTrialBalance As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnGeneralDaybook As System.Windows.Forms.Button
    Friend WithEvents btnVouchers As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSupplierName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSupplierID As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnCreditors As System.Windows.Forms.Button
    Friend WithEvents btnStockTransfer As System.Windows.Forms.Button
    Friend WithEvents btnStockIN As System.Windows.Forms.Button
    Friend WithEvents btnStockOut As System.Windows.Forms.Button
    Friend WithEvents btnLowStock As System.Windows.Forms.Button
    Friend WithEvents btnExpiredProducts As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStoreStockOUT As System.Windows.Forms.Button
    Friend WithEvents btnStoreStockIN As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStockOut_RM As System.Windows.Forms.Button
    Friend WithEvents btnStockIn_RM As System.Windows.Forms.Button
    Friend WithEvents btnTip As System.Windows.Forms.Button
    Friend WithEvents btnCollectionsByDP As System.Windows.Forms.Button
    Friend WithEvents btnTaxReport As System.Windows.Forms.Button
    Friend WithEvents btnGeneralLedger As System.Windows.Forms.Button
    Friend WithEvents btnStockUsed As System.Windows.Forms.Button
    Friend WithEvents btnInputTax As System.Windows.Forms.Button
    Friend WithEvents btnBalanceSheet As System.Windows.Forms.Button
    Friend WithEvents btnJournalEntry As System.Windows.Forms.Button
    Friend WithEvents lblUser As System.Windows.Forms.Label

End Class
