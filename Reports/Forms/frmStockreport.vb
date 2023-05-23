Imports Microsoft.Reporting.WinForms

Public Class frmStockreport

    Public Sub GetValue(ByVal dt As DataTable)
        With Me.rptStockContent.LocalReport
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.StockContent.rdlc"
            .DataSources.Add(New ReportDataSource("stockContent", dt))
        End With
        rptStockContent.RefreshReport()
    End Sub
    Private Sub frmStockreport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.rptStockContent.RefreshReport()
        rptStockContent.ZoomMode = ZoomMode.PageWidth
    End Sub
End Class