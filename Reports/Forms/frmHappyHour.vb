Imports Microsoft.Reporting.WinForms

Public Class frmHappyHour
    Public Sub GetValue(ByVal dt As DataTable, ByVal dates As String)
        Dim p(0) As ReportParameter
        p(0) = New ReportParameter("date", dates)
        With Me.salesHappyHour.LocalReport
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.ItemizedSalesOverviewHappyHour.rdlc"
            .DataSources.Add(New ReportDataSource("ItemizedSales", dt))
            .SetParameters(p)
        End With
        salesHappyHour.RefreshReport()
    End Sub
    Private Sub frmHappyHour_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.salesHappyHour.RefreshReport()
        salesHappyHour.ZoomMode = ZoomMode.PageWidth
    End Sub
End Class