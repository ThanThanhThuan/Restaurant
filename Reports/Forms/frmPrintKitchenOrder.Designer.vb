<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrintKitchenOrder
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.RestaurantPOS_OrderInfoKOTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KitchenOrder = New RestaurantPOS6.KitchenOrder()
        Me.ActivationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RPOS_DBDataSet1 = New RestaurantPOS6.RPOS_DBDataSet1()
        Me.rptOrder = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.RestaurantPOS_OrderInfoKOTTableAdapter = New RestaurantPOS6.KitchenOrderTableAdapters.RestaurantPOS_OrderInfoKOTTableAdapter()
        Me.ActivationTableAdapter = New RestaurantPOS6.RPOS_DBDataSet1TableAdapters.ActivationTableAdapter()
        CType(Me.RestaurantPOS_OrderInfoKOTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KitchenOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActivationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RPOS_DBDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RestaurantPOS_OrderInfoKOTBindingSource
        '
        Me.RestaurantPOS_OrderInfoKOTBindingSource.DataMember = "RestaurantPOS_OrderInfoKOT"
        Me.RestaurantPOS_OrderInfoKOTBindingSource.DataSource = Me.KitchenOrder
        '
        'KitchenOrder
        '
        Me.KitchenOrder.DataSetName = "KitchenOrder"
        Me.KitchenOrder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ActivationBindingSource
        '
        Me.ActivationBindingSource.DataMember = "Activation"
        Me.ActivationBindingSource.DataSource = Me.RPOS_DBDataSet1
        '
        'RPOS_DBDataSet1
        '
        Me.RPOS_DBDataSet1.DataSetName = "RPOS_DBDataSet1"
        Me.RPOS_DBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'rptOrder
        '
        Me.rptOrder.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "OrderSet"
        ReportDataSource1.Value = Me.RestaurantPOS_OrderInfoKOTBindingSource
        ReportDataSource2.Name = "Items"
        ReportDataSource2.Value = Me.ActivationBindingSource
        Me.rptOrder.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptOrder.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rptOrder.LocalReport.ReportEmbeddedResource = "RestaurantPOS6.Kitchenorder.rdlc"
        Me.rptOrder.Location = New System.Drawing.Point(0, 0)
        Me.rptOrder.Name = "rptOrder"
        Me.rptOrder.Size = New System.Drawing.Size(776, 451)
        Me.rptOrder.TabIndex = 0
        '
        'RestaurantPOS_OrderInfoKOTTableAdapter
        '
        Me.RestaurantPOS_OrderInfoKOTTableAdapter.ClearBeforeFill = True
        '
        'ActivationTableAdapter
        '
        Me.ActivationTableAdapter.ClearBeforeFill = True
        '
        'frmPrintKitchenOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 451)
        Me.Controls.Add(Me.rptOrder)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrintKitchenOrder"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kitchen order"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RestaurantPOS_OrderInfoKOTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KitchenOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActivationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RPOS_DBDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rptOrder As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents RestaurantPOS_OrderInfoKOTBindingSource As BindingSource
    Friend WithEvents KitchenOrder As KitchenOrder
    Friend WithEvents ActivationBindingSource As BindingSource
    Private WithEvents RPOS_DBDataSet1 As RPOS_DBDataSet1
    Friend WithEvents RestaurantPOS_OrderInfoKOTTableAdapter As KitchenOrderTableAdapters.RestaurantPOS_OrderInfoKOTTableAdapter
    Friend WithEvents ActivationTableAdapter As RPOS_DBDataSet1TableAdapters.ActivationTableAdapter
End Class
