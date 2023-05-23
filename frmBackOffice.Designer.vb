<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackOffice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBackOffice))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnRestaurantInfo = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnDatabase = New System.Windows.Forms.Button()
        Me.btnKitchen = New System.Windows.Forms.Button()
        Me.btnCategories = New System.Windows.Forms.Button()
        Me.btnItems = New System.Windows.Forms.Button()
        Me.btnMenuItemsModifiers = New System.Windows.Forms.Button()
        Me.btnPizza = New System.Windows.Forms.Button()
        Me.btnItemStockx = New System.Windows.Forms.Button()
        Me.btnNotes = New System.Windows.Forms.Button()
        Me.btnTables = New System.Windows.Forms.Button()
        Me.btnWallet = New System.Windows.Forms.Button()
        Me.btnCreditCustomer = New System.Windows.Forms.Button()
        Me.btnInventory = New System.Windows.Forms.Button()
        Me.btnWarehouse = New System.Windows.Forms.Button()
        Me.btnSupplier = New System.Windows.Forms.Button()
        Me.btnProduct = New System.Windows.Forms.Button()
        Me.btnPurchaseOrder = New System.Windows.Forms.Button()
        Me.btnPurchase = New System.Windows.Forms.Button()
        Me.btnPayment = New System.Windows.Forms.Button()
        Me.btnStockTransfer_Issue = New System.Windows.Forms.Button()
        Me.btnRecipe = New System.Windows.Forms.Button()
        Me.btnWorkPeriod = New System.Windows.Forms.Button()
        Me.btnPOSReport = New System.Windows.Forms.Button()
        Me.btnWorkPeriodReport = New System.Windows.Forms.Button()
        Me.btnAccountingReports = New System.Windows.Forms.Button()
        Me.btnSendSMS = New System.Windows.Forms.Button()
        Me.btnLogs = New System.Windows.Forms.Button()
        Me.btnRegistration = New System.Windows.Forms.Button()
        Me.btnStockAdjustment = New System.Windows.Forms.Button()
        Me.btnHomeDelivery = New System.Windows.Forms.Button()
        Me.BtnVoucher = New System.Windows.Forms.Button()
        Me.btnKeyboard = New System.Windows.Forms.Button()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
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
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(991, 60)
        Me.Panel1.TabIndex = 3
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(452, 6)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(237, 46)
        Me.Label30.TabIndex = 321
        Me.Label30.Text = "Operator ID :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Back Office"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.White
        Me.lblUser.Location = New System.Drawing.Point(683, 6)
        Me.lblUser.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(128, 46)
        Me.lblUser.TabIndex = 320
        Me.lblUser.Text = "lblUser"
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.Color.White
        Me.lblDateTime.Location = New System.Drawing.Point(7, 65)
        Me.lblDateTime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(168, 46)
        Me.lblDateTime.TabIndex = 3
        Me.lblDateTime.Text = "DateTime"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Timer2
        '
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnRestaurantInfo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSettings, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDatabase, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnKitchen, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCategories, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnItems, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnMenuItemsModifiers, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPizza, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnItemStockx, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnNotes, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnTables, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnWallet, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCreditCustomer, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnInventory, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnWarehouse, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSupplier, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnProduct, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPurchaseOrder, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPurchase, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPayment, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnStockTransfer_Issue, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnRecipe, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnWorkPeriod, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPOSReport, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnWorkPeriodReport, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAccountingReports, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSendSMS, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnLogs, 3, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnRegistration, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnStockAdjustment, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnHomeDelivery, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnVoucher, 2, 5)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(16, 114)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1189, 706)
        Me.TableLayoutPanel1.TabIndex = 56
        '
        'btnRestaurantInfo
        '
        Me.btnRestaurantInfo.AutoSize = True
        Me.btnRestaurantInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnRestaurantInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRestaurantInfo.FlatAppearance.BorderSize = 0
        Me.btnRestaurantInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRestaurantInfo.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestaurantInfo.ForeColor = System.Drawing.Color.White
        Me.btnRestaurantInfo.Image = CType(resources.GetObject("btnRestaurantInfo.Image"), System.Drawing.Image)
        Me.btnRestaurantInfo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRestaurantInfo.Location = New System.Drawing.Point(4, 4)
        Me.btnRestaurantInfo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRestaurantInfo.Name = "btnRestaurantInfo"
        Me.btnRestaurantInfo.Size = New System.Drawing.Size(289, 80)
        Me.btnRestaurantInfo.TabIndex = 30
        Me.btnRestaurantInfo.Text = "Business Info"
        Me.btnRestaurantInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRestaurantInfo.UseVisualStyleBackColor = False
        '
        'btnSettings
        '
        Me.btnSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSettings.AutoSize = True
        Me.btnSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnSettings.FlatAppearance.BorderSize = 0
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.ForeColor = System.Drawing.Color.White
        Me.btnSettings.Image = CType(resources.GetObject("btnSettings.Image"), System.Drawing.Image)
        Me.btnSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSettings.Location = New System.Drawing.Point(301, 4)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(289, 80)
        Me.btnSettings.TabIndex = 50
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnDatabase
        '
        Me.btnDatabase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDatabase.AutoSize = True
        Me.btnDatabase.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnDatabase.FlatAppearance.BorderSize = 0
        Me.btnDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDatabase.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDatabase.ForeColor = System.Drawing.Color.White
        Me.btnDatabase.Image = CType(resources.GetObject("btnDatabase.Image"), System.Drawing.Image)
        Me.btnDatabase.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDatabase.Location = New System.Drawing.Point(598, 4)
        Me.btnDatabase.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDatabase.Name = "btnDatabase"
        Me.btnDatabase.Size = New System.Drawing.Size(289, 80)
        Me.btnDatabase.TabIndex = 58
        Me.btnDatabase.Text = "Database"
        Me.btnDatabase.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDatabase.UseVisualStyleBackColor = False
        '
        'btnKitchen
        '
        Me.btnKitchen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKitchen.AutoSize = True
        Me.btnKitchen.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnKitchen.FlatAppearance.BorderSize = 0
        Me.btnKitchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKitchen.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKitchen.ForeColor = System.Drawing.Color.White
        Me.btnKitchen.Image = CType(resources.GetObject("btnKitchen.Image"), System.Drawing.Image)
        Me.btnKitchen.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnKitchen.Location = New System.Drawing.Point(895, 4)
        Me.btnKitchen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnKitchen.Name = "btnKitchen"
        Me.btnKitchen.Size = New System.Drawing.Size(290, 80)
        Me.btnKitchen.TabIndex = 47
        Me.btnKitchen.Text = "Section"
        Me.btnKitchen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnKitchen.UseVisualStyleBackColor = False
        '
        'btnCategories
        '
        Me.btnCategories.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCategories.AutoSize = True
        Me.btnCategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnCategories.FlatAppearance.BorderSize = 0
        Me.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCategories.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCategories.ForeColor = System.Drawing.Color.White
        Me.btnCategories.Image = CType(resources.GetObject("btnCategories.Image"), System.Drawing.Image)
        Me.btnCategories.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCategories.Location = New System.Drawing.Point(4, 92)
        Me.btnCategories.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCategories.Name = "btnCategories"
        Me.btnCategories.Size = New System.Drawing.Size(289, 80)
        Me.btnCategories.TabIndex = 22
        Me.btnCategories.Text = "Categories"
        Me.btnCategories.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCategories.UseVisualStyleBackColor = False
        '
        'btnItems
        '
        Me.btnItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnItems.AutoSize = True
        Me.btnItems.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnItems.FlatAppearance.BorderSize = 0
        Me.btnItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnItems.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItems.ForeColor = System.Drawing.Color.White
        Me.btnItems.Image = CType(resources.GetObject("btnItems.Image"), System.Drawing.Image)
        Me.btnItems.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnItems.Location = New System.Drawing.Point(301, 92)
        Me.btnItems.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnItems.Name = "btnItems"
        Me.btnItems.Size = New System.Drawing.Size(289, 80)
        Me.btnItems.TabIndex = 23
        Me.btnItems.Text = "Menu Items"
        Me.btnItems.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnItems.UseVisualStyleBackColor = False
        '
        'btnMenuItemsModifiers
        '
        Me.btnMenuItemsModifiers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMenuItemsModifiers.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnMenuItemsModifiers.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMenuItemsModifiers.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMenuItemsModifiers.ForeColor = System.Drawing.Color.White
        Me.btnMenuItemsModifiers.Image = CType(resources.GetObject("btnMenuItemsModifiers.Image"), System.Drawing.Image)
        Me.btnMenuItemsModifiers.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMenuItemsModifiers.Location = New System.Drawing.Point(598, 92)
        Me.btnMenuItemsModifiers.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnMenuItemsModifiers.Name = "btnMenuItemsModifiers"
        Me.btnMenuItemsModifiers.Size = New System.Drawing.Size(289, 80)
        Me.btnMenuItemsModifiers.TabIndex = 66
        Me.btnMenuItemsModifiers.Text = "Menu Items Modifiers"
        Me.btnMenuItemsModifiers.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMenuItemsModifiers.UseVisualStyleBackColor = False
        '
        'btnPizza
        '
        Me.btnPizza.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPizza.AutoSize = True
        Me.btnPizza.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnPizza.FlatAppearance.BorderSize = 0
        Me.btnPizza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPizza.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPizza.ForeColor = System.Drawing.Color.White
        Me.btnPizza.Image = CType(resources.GetObject("btnPizza.Image"), System.Drawing.Image)
        Me.btnPizza.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPizza.Location = New System.Drawing.Point(895, 92)
        Me.btnPizza.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPizza.Name = "btnPizza"
        Me.btnPizza.Size = New System.Drawing.Size(290, 80)
        Me.btnPizza.TabIndex = 62
        Me.btnPizza.Text = "Pizza"
        Me.btnPizza.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPizza.UseVisualStyleBackColor = False
        '
        'btnItemStockx
        '
        Me.btnItemStockx.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnItemStockx.AutoSize = True
        Me.btnItemStockx.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnItemStockx.FlatAppearance.BorderSize = 0
        Me.btnItemStockx.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnItemStockx.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItemStockx.ForeColor = System.Drawing.Color.White
        Me.btnItemStockx.Image = CType(resources.GetObject("btnItemStockx.Image"), System.Drawing.Image)
        Me.btnItemStockx.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnItemStockx.Location = New System.Drawing.Point(4, 180)
        Me.btnItemStockx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnItemStockx.Name = "btnItemStockx"
        Me.btnItemStockx.Size = New System.Drawing.Size(289, 80)
        Me.btnItemStockx.TabIndex = 37
        Me.btnItemStockx.Text = "Finished Goods Entry"
        Me.btnItemStockx.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnItemStockx.UseVisualStyleBackColor = False
        '
        'btnNotes
        '
        Me.btnNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnNotes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNotes.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotes.ForeColor = System.Drawing.Color.White
        Me.btnNotes.Image = CType(resources.GetObject("btnNotes.Image"), System.Drawing.Image)
        Me.btnNotes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNotes.Location = New System.Drawing.Point(301, 180)
        Me.btnNotes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNotes.Name = "btnNotes"
        Me.btnNotes.Size = New System.Drawing.Size(289, 80)
        Me.btnNotes.TabIndex = 65
        Me.btnNotes.Text = "Notes"
        Me.btnNotes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNotes.UseVisualStyleBackColor = False
        '
        'btnTables
        '
        Me.btnTables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTables.AutoSize = True
        Me.btnTables.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnTables.FlatAppearance.BorderSize = 0
        Me.btnTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTables.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTables.ForeColor = System.Drawing.Color.White
        Me.btnTables.Image = CType(resources.GetObject("btnTables.Image"), System.Drawing.Image)
        Me.btnTables.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTables.Location = New System.Drawing.Point(598, 180)
        Me.btnTables.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnTables.Name = "btnTables"
        Me.btnTables.Size = New System.Drawing.Size(289, 80)
        Me.btnTables.TabIndex = 24
        Me.btnTables.Text = "Tables"
        Me.btnTables.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTables.UseVisualStyleBackColor = False
        '
        'btnWallet
        '
        Me.btnWallet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWallet.AutoSize = True
        Me.btnWallet.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnWallet.FlatAppearance.BorderSize = 0
        Me.btnWallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWallet.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWallet.ForeColor = System.Drawing.Color.White
        Me.btnWallet.Image = CType(resources.GetObject("btnWallet.Image"), System.Drawing.Image)
        Me.btnWallet.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWallet.Location = New System.Drawing.Point(895, 180)
        Me.btnWallet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWallet.Name = "btnWallet"
        Me.btnWallet.Size = New System.Drawing.Size(290, 80)
        Me.btnWallet.TabIndex = 59
        Me.btnWallet.Text = "Wallet"
        Me.btnWallet.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWallet.UseVisualStyleBackColor = False
        '
        'btnCreditCustomer
        '
        Me.btnCreditCustomer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreditCustomer.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnCreditCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCreditCustomer.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreditCustomer.ForeColor = System.Drawing.Color.White
        Me.btnCreditCustomer.Image = CType(resources.GetObject("btnCreditCustomer.Image"), System.Drawing.Image)
        Me.btnCreditCustomer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCreditCustomer.Location = New System.Drawing.Point(4, 268)
        Me.btnCreditCustomer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCreditCustomer.Name = "btnCreditCustomer"
        Me.btnCreditCustomer.Size = New System.Drawing.Size(289, 80)
        Me.btnCreditCustomer.TabIndex = 63
        Me.btnCreditCustomer.Text = "Credit Customer"
        Me.btnCreditCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCreditCustomer.UseVisualStyleBackColor = False
        '
        'btnInventory
        '
        Me.btnInventory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInventory.AutoSize = True
        Me.btnInventory.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnInventory.FlatAppearance.BorderSize = 0
        Me.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInventory.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInventory.ForeColor = System.Drawing.Color.White
        Me.btnInventory.Image = CType(resources.GetObject("btnInventory.Image"), System.Drawing.Image)
        Me.btnInventory.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnInventory.Location = New System.Drawing.Point(301, 268)
        Me.btnInventory.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnInventory.Name = "btnInventory"
        Me.btnInventory.Size = New System.Drawing.Size(289, 80)
        Me.btnInventory.TabIndex = 53
        Me.btnInventory.Text = "Inventory"
        Me.btnInventory.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnInventory.UseVisualStyleBackColor = False
        '
        'btnWarehouse
        '
        Me.btnWarehouse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWarehouse.AutoSize = True
        Me.btnWarehouse.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnWarehouse.FlatAppearance.BorderSize = 0
        Me.btnWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnWarehouse.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWarehouse.ForeColor = System.Drawing.Color.White
        Me.btnWarehouse.Image = CType(resources.GetObject("btnWarehouse.Image"), System.Drawing.Image)
        Me.btnWarehouse.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWarehouse.Location = New System.Drawing.Point(598, 268)
        Me.btnWarehouse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWarehouse.Name = "btnWarehouse"
        Me.btnWarehouse.Size = New System.Drawing.Size(289, 80)
        Me.btnWarehouse.TabIndex = 52
        Me.btnWarehouse.Text = "Warehouse"
        Me.btnWarehouse.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWarehouse.UseVisualStyleBackColor = False
        '
        'btnSupplier
        '
        Me.btnSupplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSupplier.AutoSize = True
        Me.btnSupplier.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnSupplier.FlatAppearance.BorderSize = 0
        Me.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupplier.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplier.ForeColor = System.Drawing.Color.White
        Me.btnSupplier.Image = CType(resources.GetObject("btnSupplier.Image"), System.Drawing.Image)
        Me.btnSupplier.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSupplier.Location = New System.Drawing.Point(895, 268)
        Me.btnSupplier.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSupplier.Name = "btnSupplier"
        Me.btnSupplier.Size = New System.Drawing.Size(290, 80)
        Me.btnSupplier.TabIndex = 40
        Me.btnSupplier.Text = "Supplier"
        Me.btnSupplier.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSupplier.UseVisualStyleBackColor = False
        '
        'btnProduct
        '
        Me.btnProduct.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProduct.AutoSize = True
        Me.btnProduct.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnProduct.FlatAppearance.BorderSize = 0
        Me.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProduct.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProduct.ForeColor = System.Drawing.Color.White
        Me.btnProduct.Image = CType(resources.GetObject("btnProduct.Image"), System.Drawing.Image)
        Me.btnProduct.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProduct.Location = New System.Drawing.Point(4, 356)
        Me.btnProduct.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnProduct.Name = "btnProduct"
        Me.btnProduct.Size = New System.Drawing.Size(289, 80)
        Me.btnProduct.TabIndex = 39
        Me.btnProduct.Text = "Raw Materials"
        Me.btnProduct.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProduct.UseVisualStyleBackColor = False
        '
        'btnPurchaseOrder
        '
        Me.btnPurchaseOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPurchaseOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnPurchaseOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPurchaseOrder.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPurchaseOrder.ForeColor = System.Drawing.Color.White
        Me.btnPurchaseOrder.Image = CType(resources.GetObject("btnPurchaseOrder.Image"), System.Drawing.Image)
        Me.btnPurchaseOrder.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPurchaseOrder.Location = New System.Drawing.Point(301, 356)
        Me.btnPurchaseOrder.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPurchaseOrder.Name = "btnPurchaseOrder"
        Me.btnPurchaseOrder.Size = New System.Drawing.Size(289, 80)
        Me.btnPurchaseOrder.TabIndex = 67
        Me.btnPurchaseOrder.Text = "Purchase Order"
        Me.btnPurchaseOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPurchaseOrder.UseVisualStyleBackColor = False
        '
        'btnPurchase
        '
        Me.btnPurchase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPurchase.AutoSize = True
        Me.btnPurchase.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnPurchase.FlatAppearance.BorderSize = 0
        Me.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPurchase.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPurchase.ForeColor = System.Drawing.Color.White
        Me.btnPurchase.Image = CType(resources.GetObject("btnPurchase.Image"), System.Drawing.Image)
        Me.btnPurchase.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPurchase.Location = New System.Drawing.Point(598, 356)
        Me.btnPurchase.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPurchase.Name = "btnPurchase"
        Me.btnPurchase.Size = New System.Drawing.Size(289, 80)
        Me.btnPurchase.TabIndex = 41
        Me.btnPurchase.Text = "Purchase Entry"
        Me.btnPurchase.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPurchase.UseVisualStyleBackColor = False
        '
        'btnPayment
        '
        Me.btnPayment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPayment.AutoSize = True
        Me.btnPayment.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnPayment.FlatAppearance.BorderSize = 0
        Me.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPayment.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPayment.ForeColor = System.Drawing.Color.White
        Me.btnPayment.Image = CType(resources.GetObject("btnPayment.Image"), System.Drawing.Image)
        Me.btnPayment.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPayment.Location = New System.Drawing.Point(895, 356)
        Me.btnPayment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(290, 80)
        Me.btnPayment.TabIndex = 42
        Me.btnPayment.Text = "Payment"
        Me.btnPayment.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPayment.UseVisualStyleBackColor = False
        '
        'btnStockTransfer_Issue
        '
        Me.btnStockTransfer_Issue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStockTransfer_Issue.AutoSize = True
        Me.btnStockTransfer_Issue.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnStockTransfer_Issue.FlatAppearance.BorderSize = 0
        Me.btnStockTransfer_Issue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStockTransfer_Issue.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockTransfer_Issue.ForeColor = System.Drawing.Color.White
        Me.btnStockTransfer_Issue.Image = CType(resources.GetObject("btnStockTransfer_Issue.Image"), System.Drawing.Image)
        Me.btnStockTransfer_Issue.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnStockTransfer_Issue.Location = New System.Drawing.Point(4, 444)
        Me.btnStockTransfer_Issue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnStockTransfer_Issue.Name = "btnStockTransfer_Issue"
        Me.btnStockTransfer_Issue.Size = New System.Drawing.Size(289, 80)
        Me.btnStockTransfer_Issue.TabIndex = 55
        Me.btnStockTransfer_Issue.Text = "Stock Transfer/Issue"
        Me.btnStockTransfer_Issue.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnStockTransfer_Issue.UseVisualStyleBackColor = False
        '
        'btnRecipe
        '
        Me.btnRecipe.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRecipe.AutoSize = True
        Me.btnRecipe.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnRecipe.FlatAppearance.BorderSize = 0
        Me.btnRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecipe.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecipe.ForeColor = System.Drawing.Color.White
        Me.btnRecipe.Image = CType(resources.GetObject("btnRecipe.Image"), System.Drawing.Image)
        Me.btnRecipe.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRecipe.Location = New System.Drawing.Point(4, 532)
        Me.btnRecipe.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRecipe.Name = "btnRecipe"
        Me.btnRecipe.Size = New System.Drawing.Size(289, 80)
        Me.btnRecipe.TabIndex = 36
        Me.btnRecipe.Text = "Recipe"
        Me.btnRecipe.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRecipe.UseVisualStyleBackColor = False
        '
        'btnWorkPeriod
        '
        Me.btnWorkPeriod.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWorkPeriod.AutoSize = True
        Me.btnWorkPeriod.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnWorkPeriod.FlatAppearance.BorderSize = 0
        Me.btnWorkPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkPeriod.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorkPeriod.ForeColor = System.Drawing.Color.White
        Me.btnWorkPeriod.Image = CType(resources.GetObject("btnWorkPeriod.Image"), System.Drawing.Image)
        Me.btnWorkPeriod.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWorkPeriod.Location = New System.Drawing.Point(301, 532)
        Me.btnWorkPeriod.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWorkPeriod.Name = "btnWorkPeriod"
        Me.btnWorkPeriod.Size = New System.Drawing.Size(289, 80)
        Me.btnWorkPeriod.TabIndex = 38
        Me.btnWorkPeriod.Text = "Work Period"
        Me.btnWorkPeriod.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWorkPeriod.UseVisualStyleBackColor = False
        '
        'btnPOSReport
        '
        Me.btnPOSReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPOSReport.AutoSize = True
        Me.btnPOSReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnPOSReport.FlatAppearance.BorderSize = 0
        Me.btnPOSReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPOSReport.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPOSReport.ForeColor = System.Drawing.Color.White
        Me.btnPOSReport.Image = CType(resources.GetObject("btnPOSReport.Image"), System.Drawing.Image)
        Me.btnPOSReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPOSReport.Location = New System.Drawing.Point(598, 532)
        Me.btnPOSReport.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPOSReport.Name = "btnPOSReport"
        Me.btnPOSReport.Size = New System.Drawing.Size(289, 80)
        Me.btnPOSReport.TabIndex = 33
        Me.btnPOSReport.Text = "POS Report"
        Me.btnPOSReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPOSReport.UseVisualStyleBackColor = False
        '
        'btnWorkPeriodReport
        '
        Me.btnWorkPeriodReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWorkPeriodReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnWorkPeriodReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkPeriodReport.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorkPeriodReport.ForeColor = System.Drawing.Color.White
        Me.btnWorkPeriodReport.Image = CType(resources.GetObject("btnWorkPeriodReport.Image"), System.Drawing.Image)
        Me.btnWorkPeriodReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWorkPeriodReport.Location = New System.Drawing.Point(895, 532)
        Me.btnWorkPeriodReport.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWorkPeriodReport.Name = "btnWorkPeriodReport"
        Me.btnWorkPeriodReport.Size = New System.Drawing.Size(290, 80)
        Me.btnWorkPeriodReport.TabIndex = 57
        Me.btnWorkPeriodReport.Text = "Work Period Report"
        Me.btnWorkPeriodReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWorkPeriodReport.UseVisualStyleBackColor = False
        '
        'btnAccountingReports
        '
        Me.btnAccountingReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAccountingReports.AutoSize = True
        Me.btnAccountingReports.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnAccountingReports.FlatAppearance.BorderSize = 0
        Me.btnAccountingReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccountingReports.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccountingReports.ForeColor = System.Drawing.Color.White
        Me.btnAccountingReports.Image = CType(resources.GetObject("btnAccountingReports.Image"), System.Drawing.Image)
        Me.btnAccountingReports.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAccountingReports.Location = New System.Drawing.Point(4, 620)
        Me.btnAccountingReports.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAccountingReports.Name = "btnAccountingReports"
        Me.btnAccountingReports.Size = New System.Drawing.Size(289, 82)
        Me.btnAccountingReports.TabIndex = 43
        Me.btnAccountingReports.Text = "Accounting Reports"
        Me.btnAccountingReports.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAccountingReports.UseVisualStyleBackColor = False
        '
        'btnSendSMS
        '
        Me.btnSendSMS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendSMS.AutoSize = True
        Me.btnSendSMS.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnSendSMS.FlatAppearance.BorderSize = 0
        Me.btnSendSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSendSMS.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendSMS.ForeColor = System.Drawing.Color.White
        Me.btnSendSMS.Image = CType(resources.GetObject("btnSendSMS.Image"), System.Drawing.Image)
        Me.btnSendSMS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSendSMS.Location = New System.Drawing.Point(301, 620)
        Me.btnSendSMS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSendSMS.Name = "btnSendSMS"
        Me.btnSendSMS.Size = New System.Drawing.Size(289, 82)
        Me.btnSendSMS.TabIndex = 61
        Me.btnSendSMS.Text = "Send SMS"
        Me.btnSendSMS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSendSMS.UseVisualStyleBackColor = False
        '
        'btnLogs
        '
        Me.btnLogs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogs.AutoSize = True
        Me.btnLogs.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnLogs.FlatAppearance.BorderSize = 0
        Me.btnLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogs.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogs.ForeColor = System.Drawing.Color.White
        Me.btnLogs.Image = CType(resources.GetObject("btnLogs.Image"), System.Drawing.Image)
        Me.btnLogs.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLogs.Location = New System.Drawing.Point(895, 620)
        Me.btnLogs.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(290, 82)
        Me.btnLogs.TabIndex = 26
        Me.btnLogs.Text = "Logs"
        Me.btnLogs.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLogs.UseVisualStyleBackColor = False
        '
        'btnRegistration
        '
        Me.btnRegistration.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRegistration.AutoSize = True
        Me.btnRegistration.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnRegistration.FlatAppearance.BorderSize = 0
        Me.btnRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegistration.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistration.ForeColor = System.Drawing.Color.White
        Me.btnRegistration.Image = CType(resources.GetObject("btnRegistration.Image"), System.Drawing.Image)
        Me.btnRegistration.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRegistration.Location = New System.Drawing.Point(598, 620)
        Me.btnRegistration.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRegistration.Name = "btnRegistration"
        Me.btnRegistration.Size = New System.Drawing.Size(289, 82)
        Me.btnRegistration.TabIndex = 25
        Me.btnRegistration.Text = "Registration"
        Me.btnRegistration.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRegistration.UseVisualStyleBackColor = False
        '
        'btnStockAdjustment
        '
        Me.btnStockAdjustment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStockAdjustment.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnStockAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnStockAdjustment.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockAdjustment.ForeColor = System.Drawing.Color.White
        Me.btnStockAdjustment.Image = CType(resources.GetObject("btnStockAdjustment.Image"), System.Drawing.Image)
        Me.btnStockAdjustment.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnStockAdjustment.Location = New System.Drawing.Point(301, 444)
        Me.btnStockAdjustment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnStockAdjustment.Name = "btnStockAdjustment"
        Me.btnStockAdjustment.Size = New System.Drawing.Size(289, 80)
        Me.btnStockAdjustment.TabIndex = 64
        Me.btnStockAdjustment.Text = "Stock Adjustment"
        Me.btnStockAdjustment.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnStockAdjustment.UseVisualStyleBackColor = False
        '
        'btnHomeDelivery
        '
        Me.btnHomeDelivery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHomeDelivery.AutoSize = True
        Me.btnHomeDelivery.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.btnHomeDelivery.FlatAppearance.BorderSize = 0
        Me.btnHomeDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHomeDelivery.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHomeDelivery.ForeColor = System.Drawing.Color.White
        Me.btnHomeDelivery.Image = CType(resources.GetObject("btnHomeDelivery.Image"), System.Drawing.Image)
        Me.btnHomeDelivery.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnHomeDelivery.Location = New System.Drawing.Point(895, 444)
        Me.btnHomeDelivery.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnHomeDelivery.Name = "btnHomeDelivery"
        Me.btnHomeDelivery.Size = New System.Drawing.Size(290, 80)
        Me.btnHomeDelivery.TabIndex = 48
        Me.btnHomeDelivery.Text = "Home Delivery"
        Me.btnHomeDelivery.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnHomeDelivery.UseVisualStyleBackColor = False
        '
        'BtnVoucher
        '
        Me.BtnVoucher.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnVoucher.AutoSize = True
        Me.BtnVoucher.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.BtnVoucher.FlatAppearance.BorderSize = 0
        Me.BtnVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnVoucher.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVoucher.ForeColor = System.Drawing.Color.White
        Me.BtnVoucher.Image = CType(resources.GetObject("BtnVoucher.Image"), System.Drawing.Image)
        Me.BtnVoucher.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnVoucher.Location = New System.Drawing.Point(598, 444)
        Me.BtnVoucher.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnVoucher.Name = "BtnVoucher"
        Me.BtnVoucher.Size = New System.Drawing.Size(289, 80)
        Me.BtnVoucher.TabIndex = 46
        Me.BtnVoucher.Text = "Voucher"
        Me.BtnVoucher.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnVoucher.UseVisualStyleBackColor = False
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
        Me.btnKeyboard.Location = New System.Drawing.Point(1000, 1)
        Me.btnKeyboard.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnKeyboard.Name = "btnKeyboard"
        Me.btnKeyboard.Size = New System.Drawing.Size(69, 60)
        Me.btnKeyboard.TabIndex = 58
        Me.btnKeyboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeyboard.UseVisualStyleBackColor = False
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
        Me.btnMinimize.Location = New System.Drawing.Point(1075, 1)
        Me.btnMinimize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(69, 60)
        Me.btnMinimize.TabIndex = 35
        Me.btnMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMinimize.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(1151, 1)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 60)
        Me.btnCancel.TabIndex = 29
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmBackOffice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1221, 834)
        Me.Controls.Add(Me.btnKeyboard)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnMinimize)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmBackOffice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblDateTime As System.Windows.Forms.Label
    Friend WithEvents btnCategories As System.Windows.Forms.Button
    Friend WithEvents btnItems As System.Windows.Forms.Button
    Friend WithEvents btnTables As System.Windows.Forms.Button
    Friend WithEvents btnRegistration As System.Windows.Forms.Button
    Friend WithEvents btnLogs As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnRestaurantInfo As System.Windows.Forms.Button
    Friend WithEvents btnPOSReport As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents btnMinimize As System.Windows.Forms.Button
    Friend WithEvents btnRecipe As System.Windows.Forms.Button
    Friend WithEvents btnItemStockx As System.Windows.Forms.Button
    Friend WithEvents btnWorkPeriod As System.Windows.Forms.Button
    Friend WithEvents btnProduct As System.Windows.Forms.Button
    Friend WithEvents btnSupplier As System.Windows.Forms.Button
    Friend WithEvents btnPurchase As System.Windows.Forms.Button
    Friend WithEvents btnPayment As System.Windows.Forms.Button
    Friend WithEvents btnAccountingReports As System.Windows.Forms.Button
    Friend WithEvents BtnVoucher As System.Windows.Forms.Button
    Friend WithEvents btnKitchen As System.Windows.Forms.Button
    Friend WithEvents btnHomeDelivery As System.Windows.Forms.Button
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents btnWarehouse As System.Windows.Forms.Button
    Friend WithEvents btnInventory As System.Windows.Forms.Button
    Friend WithEvents btnStockTransfer_Issue As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnKeyboard As System.Windows.Forms.Button
    Friend WithEvents btnWorkPeriodReport As System.Windows.Forms.Button
    Friend WithEvents btnDatabase As System.Windows.Forms.Button
    Friend WithEvents btnWallet As System.Windows.Forms.Button
    Friend WithEvents btnSendSMS As System.Windows.Forms.Button
    Friend WithEvents btnPizza As System.Windows.Forms.Button
    Friend WithEvents btnCreditCustomer As System.Windows.Forms.Button
    Friend WithEvents btnStockAdjustment As System.Windows.Forms.Button
    Friend WithEvents btnNotes As System.Windows.Forms.Button
    Friend WithEvents btnMenuItemsModifiers As System.Windows.Forms.Button
    Friend WithEvents btnPurchaseOrder As System.Windows.Forms.Button
End Class
