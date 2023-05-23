<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProfitLoss
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
        Me.tblstockBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StockContentxsd = New RestaurantPOS6.StockContentxsd()
        Me.rptProfitLoss = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.tblstockTableAdapter = New RestaurantPOS6.StockContentxsdTableAdapters.tblstockTableAdapter()
        CType(Me.tblstockBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StockContentxsd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tblstockBindingSource
        '
        Me.tblstockBindingSource.DataMember = "tblstock"
        Me.tblstockBindingSource.DataSource = Me.StockContentxsd
        '
        'StockContentxsd
        '
        Me.StockContentxsd.DataSetName = "StockContentxsd"
        Me.StockContentxsd.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'rptProfitLoss
        '
        Me.rptProfitLoss.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "stockContent"
        ReportDataSource1.Value = Me.tblstockBindingSource
        Me.rptProfitLoss.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptProfitLoss.LocalReport.ReportEmbeddedResource = "RestaurantPOS6.ProfitLoss.rdlc"
        Me.rptProfitLoss.Location = New System.Drawing.Point(0, 0)
        Me.rptProfitLoss.Name = "rptProfitLoss"
        Me.rptProfitLoss.Size = New System.Drawing.Size(783, 467)
        Me.rptProfitLoss.TabIndex = 0
        '
        'tblstockTableAdapter
        '
        Me.tblstockTableAdapter.ClearBeforeFill = True
        '
        'frmProfitLoss
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 467)
        Me.Controls.Add(Me.rptProfitLoss)
        Me.MinimizeBox = False
        Me.Name = "frmProfitLoss"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Profit Loss Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.tblstockBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StockContentxsd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rptProfitLoss As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tblstockBindingSource As BindingSource
    Friend WithEvents StockContentxsd As StockContentxsd
    Friend WithEvents tblstockTableAdapter As StockContentxsdTableAdapters.tblstockTableAdapter
End Class
