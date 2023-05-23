Imports Microsoft.Reporting.WinForms

Public Class frmstkTransfer
    Public Sub GetValue(ByVal dt As DataTable)
        With Me.StockTransfer.LocalReport
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.stockTransfer.rdlc"
            .DataSources.Add(New ReportDataSource("stockBalance", dt))
        End With
        'Dim pg As Printing.PageSettings = New Printing.PageSettings()
        'pg.Margins.Left = 0
        'pg.Margins.Right = 0
        'Me.rptPaidorder.SetPageSettings(pg)
        StockTransfer.RefreshReport()
    End Sub
    Private Sub frmstkTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StockTransfer.RefreshReport()
        StockTransfer.ZoomMode = ZoomMode.PageWidth
    End Sub
End Class