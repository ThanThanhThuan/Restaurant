Imports Microsoft.Reporting.WinForms

Public Class frmStockBalance
    Public Sub GetValue(ByVal dt As DataTable)
        With Me.rptstkBalance.LocalReport
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.stockBalance.rdlc"
            .DataSources.Add(New ReportDataSource("stockBalance", dt))
        End With
        rptstkBalance.RefreshReport()
    End Sub
    Private Sub frmStockBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.rptstkBalance.RefreshReport()
        rptstkBalance.ZoomMode = ZoomMode.PageWidth
    End Sub
End Class