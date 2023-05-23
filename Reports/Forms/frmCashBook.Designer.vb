<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashBook
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
        Me.RestaurantPOS_OrderedProductBillKOTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RPOS_DBDataSet = New RestaurantPOS6.RPOS_DBDataSet()
        Me.cashBook = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.RestaurantPOS_OrderedProductBillKOTTableAdapter = New RestaurantPOS6.RPOS_DBDataSetTableAdapters.RestaurantPOS_OrderedProductBillKOTTableAdapter()
        CType(Me.RestaurantPOS_OrderedProductBillKOTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RPOS_DBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RestaurantPOS_OrderedProductBillKOTBindingSource
        '
        Me.RestaurantPOS_OrderedProductBillKOTBindingSource.DataMember = "RestaurantPOS_OrderedProductBillKOT"
        Me.RestaurantPOS_OrderedProductBillKOTBindingSource.DataSource = Me.RPOS_DBDataSet
        '
        'RPOS_DBDataSet
        '
        Me.RPOS_DBDataSet.DataSetName = "RPOS_DBDataSet"
        Me.RPOS_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cashBook
        '
        Me.cashBook.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ItemizedSales"
        ReportDataSource1.Value = Me.RestaurantPOS_OrderedProductBillKOTBindingSource
        Me.cashBook.LocalReport.DataSources.Add(ReportDataSource1)
        Me.cashBook.LocalReport.ReportEmbeddedResource = "RestaurantPOS6.reportCash.rdlc"
        Me.cashBook.Location = New System.Drawing.Point(0, 0)
        Me.cashBook.Name = "cashBook"
        Me.cashBook.Size = New System.Drawing.Size(823, 502)
        Me.cashBook.TabIndex = 0
        '
        'RestaurantPOS_OrderedProductBillKOTTableAdapter
        '
        Me.RestaurantPOS_OrderedProductBillKOTTableAdapter.ClearBeforeFill = True
        '
        'frmCashBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 502)
        Me.Controls.Add(Me.cashBook)
        Me.MinimizeBox = False
        Me.Name = "frmCashBook"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash Book"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RestaurantPOS_OrderedProductBillKOTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RPOS_DBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cashBook As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents RestaurantPOS_OrderedProductBillKOTBindingSource As BindingSource
    Friend WithEvents RPOS_DBDataSet As RPOS_DBDataSet
    Friend WithEvents RestaurantPOS_OrderedProductBillKOTTableAdapter As RPOS_DBDataSetTableAdapters.RestaurantPOS_OrderedProductBillKOTTableAdapter
End Class
