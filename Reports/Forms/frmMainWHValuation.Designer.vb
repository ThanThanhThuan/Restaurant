<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainWHValuation
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.mainWarehouseValuation = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.RPOS_DBDataSet = New RestaurantPOS6.RPOS_DBDataSet()
        Me.RestaurantPOS_OrderedProductBillKOTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RestaurantPOS_OrderedProductBillKOTTableAdapter = New RestaurantPOS6.RPOS_DBDataSetTableAdapters.RestaurantPOS_OrderedProductBillKOTTableAdapter()
        Me.HotelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HotelTableAdapter = New RestaurantPOS6.RPOS_DBDataSetTableAdapters.HotelTableAdapter()
        CType(Me.RPOS_DBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RestaurantPOS_OrderedProductBillKOTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HotelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mainWarehouseValuation
        '
        Me.mainWarehouseValuation.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dtStockUsage"
        ReportDataSource1.Value = Me.RestaurantPOS_OrderedProductBillKOTBindingSource
        ReportDataSource2.Name = "dtDefault"
        ReportDataSource2.Value = Me.HotelBindingSource
        Me.mainWarehouseValuation.LocalReport.DataSources.Add(ReportDataSource1)
        Me.mainWarehouseValuation.LocalReport.DataSources.Add(ReportDataSource2)
        Me.mainWarehouseValuation.LocalReport.ReportEmbeddedResource = "RestaurantPOS6.MainWHValuation.rdlc"
        Me.mainWarehouseValuation.Location = New System.Drawing.Point(0, 0)
        Me.mainWarehouseValuation.Name = "mainWarehouseValuation"
        Me.mainWarehouseValuation.Size = New System.Drawing.Size(905, 526)
        Me.mainWarehouseValuation.TabIndex = 0
        '
        'RPOS_DBDataSet
        '
        Me.RPOS_DBDataSet.DataSetName = "RPOS_DBDataSet"
        Me.RPOS_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RestaurantPOS_OrderedProductBillKOTBindingSource
        '
        Me.RestaurantPOS_OrderedProductBillKOTBindingSource.DataMember = "RestaurantPOS_OrderedProductBillKOT"
        Me.RestaurantPOS_OrderedProductBillKOTBindingSource.DataSource = Me.RPOS_DBDataSet
        '
        'RestaurantPOS_OrderedProductBillKOTTableAdapter
        '
        Me.RestaurantPOS_OrderedProductBillKOTTableAdapter.ClearBeforeFill = True
        '
        'HotelBindingSource
        '
        Me.HotelBindingSource.DataMember = "Hotel"
        Me.HotelBindingSource.DataSource = Me.RPOS_DBDataSet
        '
        'HotelTableAdapter
        '
        Me.HotelTableAdapter.ClearBeforeFill = True
        '
        'frmMainWHValuation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 526)
        Me.Controls.Add(Me.mainWarehouseValuation)
        Me.Name = "frmMainWHValuation"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Warehouse Valuation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RPOS_DBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RestaurantPOS_OrderedProductBillKOTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HotelBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mainWarehouseValuation As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents RestaurantPOS_OrderedProductBillKOTBindingSource As BindingSource
    Friend WithEvents RPOS_DBDataSet As RPOS_DBDataSet
    Friend WithEvents HotelBindingSource As BindingSource
    Friend WithEvents RestaurantPOS_OrderedProductBillKOTTableAdapter As RPOS_DBDataSetTableAdapters.RestaurantPOS_OrderedProductBillKOTTableAdapter
    Friend WithEvents HotelTableAdapter As RPOS_DBDataSetTableAdapters.HotelTableAdapter
End Class
