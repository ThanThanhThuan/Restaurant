﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaidorder
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
        Me.RestaurantPOS_OrderInfoKOTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KitchenOrder = New RestaurantPOS6.KitchenOrder()
        Me.HotelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RPOS_DBDataSet = New RestaurantPOS6.RPOS_DBDataSet()
        Me.ActivationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rptPaidorder = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.RestaurantPOS_OrderInfoKOTTableAdapter = New RestaurantPOS6.KitchenOrderTableAdapters.RestaurantPOS_OrderInfoKOTTableAdapter()
        Me.HotelTableAdapter = New RestaurantPOS6.RPOS_DBDataSetTableAdapters.HotelTableAdapter()
        Me.ActivationTableAdapter = New RestaurantPOS6.RPOS_DBDataSetTableAdapters.ActivationTableAdapter()
        CType(Me.RestaurantPOS_OrderInfoKOTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KitchenOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HotelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RPOS_DBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActivationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'HotelBindingSource
        '
        Me.HotelBindingSource.DataMember = "Hotel"
        Me.HotelBindingSource.DataSource = Me.RPOS_DBDataSet
        '
        'RPOS_DBDataSet
        '
        Me.RPOS_DBDataSet.DataSetName = "RPOS_DBDataSet"
        Me.RPOS_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ActivationBindingSource
        '
        Me.ActivationBindingSource.DataMember = "Activation"
        Me.ActivationBindingSource.DataSource = Me.RPOS_DBDataSet
        '
        'rptPaidorder
        '
        Me.rptPaidorder.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "OrderSet"
        ReportDataSource1.Value = Me.RestaurantPOS_OrderInfoKOTBindingSource
        ReportDataSource2.Name = "Company"
        ReportDataSource2.Value = Me.HotelBindingSource
        ReportDataSource3.Name = "items"
        ReportDataSource3.Value = Me.ActivationBindingSource
        Me.rptPaidorder.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptPaidorder.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rptPaidorder.LocalReport.DataSources.Add(ReportDataSource3)
        Me.rptPaidorder.LocalReport.ReportEmbeddedResource = "RestaurantPOS6.Paidorder.rdlc"
        Me.rptPaidorder.Location = New System.Drawing.Point(0, 0)
        Me.rptPaidorder.Name = "rptPaidorder"
        Me.rptPaidorder.Size = New System.Drawing.Size(691, 453)
        Me.rptPaidorder.TabIndex = 0
        '
        'RestaurantPOS_OrderInfoKOTTableAdapter
        '
        Me.RestaurantPOS_OrderInfoKOTTableAdapter.ClearBeforeFill = True
        '
        'HotelTableAdapter
        '
        Me.HotelTableAdapter.ClearBeforeFill = True
        '
        'ActivationTableAdapter
        '
        Me.ActivationTableAdapter.ClearBeforeFill = True
        '
        'frmPaidorder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 453)
        Me.Controls.Add(Me.rptPaidorder)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaidorder"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paid order"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RestaurantPOS_OrderInfoKOTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KitchenOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HotelBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RPOS_DBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActivationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rptPaidorder As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents RestaurantPOS_OrderInfoKOTBindingSource As BindingSource
    Friend WithEvents KitchenOrder As KitchenOrder
    Friend WithEvents HotelBindingSource As BindingSource
    Friend WithEvents RPOS_DBDataSet As RPOS_DBDataSet
    Friend WithEvents ActivationBindingSource As BindingSource
    Friend WithEvents RestaurantPOS_OrderInfoKOTTableAdapter As KitchenOrderTableAdapters.RestaurantPOS_OrderInfoKOTTableAdapter
    Friend WithEvents HotelTableAdapter As RPOS_DBDataSetTableAdapters.HotelTableAdapter
    Friend WithEvents ActivationTableAdapter As RPOS_DBDataSetTableAdapters.ActivationTableAdapter
End Class
