<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTakeAway
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
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.takeAway = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.KitchenOrder = New RestaurantPOS6.KitchenOrder()
        Me.RestaurantPOS_OrderInfoKOTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RestaurantPOS_OrderInfoKOTTableAdapter = New RestaurantPOS6.KitchenOrderTableAdapters.RestaurantPOS_OrderInfoKOTTableAdapter()
        Me.RPOS_DBDataSet = New RestaurantPOS6.RPOS_DBDataSet()
        Me.HotelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HotelTableAdapter = New RestaurantPOS6.RPOS_DBDataSetTableAdapters.HotelTableAdapter()
        Me.PaymentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PaymentTableAdapter = New RestaurantPOS6.RPOS_DBDataSetTableAdapters.PaymentTableAdapter()
        CType(Me.KitchenOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RestaurantPOS_OrderInfoKOTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RPOS_DBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HotelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'takeAway
        '
        Me.takeAway.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "OrderSet"
        ReportDataSource1.Value = Me.RestaurantPOS_OrderInfoKOTBindingSource
        ReportDataSource2.Name = "Company"
        ReportDataSource2.Value = Me.HotelBindingSource
        ReportDataSource3.Name = "DataSet"
        ReportDataSource3.Value = Me.PaymentBindingSource
        Me.takeAway.LocalReport.DataSources.Add(ReportDataSource1)
        Me.takeAway.LocalReport.DataSources.Add(ReportDataSource2)
        Me.takeAway.LocalReport.DataSources.Add(ReportDataSource3)
        Me.takeAway.LocalReport.ReportEmbeddedResource = "RestaurantPOS6.takeAway.rdlc"
        Me.takeAway.Location = New System.Drawing.Point(0, 0)
        Me.takeAway.Name = "takeAway"
        Me.takeAway.Size = New System.Drawing.Size(850, 524)
        Me.takeAway.TabIndex = 0
        '
        'KitchenOrder
        '
        Me.KitchenOrder.DataSetName = "KitchenOrder"
        Me.KitchenOrder.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RestaurantPOS_OrderInfoKOTBindingSource
        '
        Me.RestaurantPOS_OrderInfoKOTBindingSource.DataMember = "RestaurantPOS_OrderInfoKOT"
        Me.RestaurantPOS_OrderInfoKOTBindingSource.DataSource = Me.KitchenOrder
        '
        'RestaurantPOS_OrderInfoKOTTableAdapter
        '
        Me.RestaurantPOS_OrderInfoKOTTableAdapter.ClearBeforeFill = True
        '
        'RPOS_DBDataSet
        '
        Me.RPOS_DBDataSet.DataSetName = "RPOS_DBDataSet"
        Me.RPOS_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'PaymentBindingSource
        '
        Me.PaymentBindingSource.DataMember = "Payment"
        Me.PaymentBindingSource.DataSource = Me.RPOS_DBDataSet
        '
        'PaymentTableAdapter
        '
        Me.PaymentTableAdapter.ClearBeforeFill = True
        '
        'frmTakeAway
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 524)
        Me.Controls.Add(Me.takeAway)
        Me.MinimizeBox = False
        Me.Name = "frmTakeAway"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Take Away"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.KitchenOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RestaurantPOS_OrderInfoKOTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RPOS_DBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HotelBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents takeAway As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents RestaurantPOS_OrderInfoKOTBindingSource As BindingSource
    Friend WithEvents KitchenOrder As KitchenOrder
    Friend WithEvents HotelBindingSource As BindingSource
    Friend WithEvents RPOS_DBDataSet As RPOS_DBDataSet
    Friend WithEvents PaymentBindingSource As BindingSource
    Friend WithEvents RestaurantPOS_OrderInfoKOTTableAdapter As KitchenOrderTableAdapters.RestaurantPOS_OrderInfoKOTTableAdapter
    Friend WithEvents HotelTableAdapter As RPOS_DBDataSetTableAdapters.HotelTableAdapter
    Friend WithEvents PaymentTableAdapter As RPOS_DBDataSetTableAdapters.PaymentTableAdapter
End Class
