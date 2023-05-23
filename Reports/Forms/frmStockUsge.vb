Imports Microsoft.Reporting.WinForms

Public Class frmStockUsge
    Public Sub GetValue(ByVal dt As DataTable)
        Dim retr As New Retrieving()
        With Me.stockUsage.LocalReport
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.StockUsage.rdlc"
            .DataSources.Add(New ReportDataSource("dtStockUsage", dt))
            .DataSources.Add(New ReportDataSource("dtDefault", Retrieving.logoo()))
        End With
        stockUsage.RefreshReport()
    End Sub
    Private Sub frmStockUsge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.stockUsage.RefreshReport()
        stockUsage.ZoomMode = ZoomMode.FullPage
    End Sub
End Class