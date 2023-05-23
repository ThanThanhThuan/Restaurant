Imports Microsoft.Reporting.WinForms

Public Class frmSalesReport

    Public Sub GetValue(ByVal dt As DataTable, ByVal dates As String)
        Dim p(0) As ReportParameter
        p(0) = New ReportParameter("date", dates)
        With Me.rptItemizedSalesOverview.LocalReport
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.ItemizedSalesOverview.rdlc"
            .DataSources.Add(New ReportDataSource("ItemizedSales", dt))
            .SetParameters(p)
        End With
        rptItemizedSalesOverview.RefreshReport()
    End Sub
    Private Sub frmSalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.rptItemizedSalesOverview.RefreshReport()
        rptItemizedSalesOverview.ZoomMode = ZoomMode.PageWidth
    End Sub
End Class