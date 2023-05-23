<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmstkTransfer
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
        Me.StockTransfer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.RPOS_DBDataSet = New RestaurantPOS6.RPOS_DBDataSet()
        Me.ProductBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProductTableAdapter = New RestaurantPOS6.RPOS_DBDataSetTableAdapters.ProductTableAdapter()
        CType(Me.RPOS_DBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StockTransfer
        '
        Me.StockTransfer.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "stockBalance"
        ReportDataSource1.Value = Me.ProductBindingSource
        ReportDataSource2.Name = "stock1"
        ReportDataSource2.Value = Me.ProductBindingSource
        Me.StockTransfer.LocalReport.DataSources.Add(ReportDataSource1)
        Me.StockTransfer.LocalReport.DataSources.Add(ReportDataSource2)
        Me.StockTransfer.LocalReport.ReportEmbeddedResource = "RestaurantPOS6.stockTransfer.rdlc"
        Me.StockTransfer.Location = New System.Drawing.Point(0, 0)
        Me.StockTransfer.Name = "StockTransfer"
        Me.StockTransfer.Size = New System.Drawing.Size(736, 467)
        Me.StockTransfer.TabIndex = 0
        '
        'RPOS_DBDataSet
        '
        Me.RPOS_DBDataSet.DataSetName = "RPOS_DBDataSet"
        Me.RPOS_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProductBindingSource
        '
        Me.ProductBindingSource.DataMember = "Product"
        Me.ProductBindingSource.DataSource = Me.RPOS_DBDataSet
        '
        'ProductTableAdapter
        '
        Me.ProductTableAdapter.ClearBeforeFill = True
        '
        'frmstkTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 467)
        Me.Controls.Add(Me.StockTransfer)
        Me.MinimizeBox = False
        Me.Name = "frmstkTransfer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Transfer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RPOS_DBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StockTransfer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ProductBindingSource As BindingSource
    Friend WithEvents RPOS_DBDataSet As RPOS_DBDataSet
    Friend WithEvents ProductTableAdapter As RPOS_DBDataSetTableAdapters.ProductTableAdapter
End Class
