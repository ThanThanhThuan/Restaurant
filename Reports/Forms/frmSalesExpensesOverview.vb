Imports Microsoft.Reporting.WinForms

Public Class frmSalesExpensesOverview
    Public Sub GetValue(ByVal dt As DataTable)
        Dim retr As New Retrieving()
        With Me.salesExpensesOverview.LocalReport
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.SalesExpenseOverview.rdlc"
            .DataSources.Add(New ReportDataSource("dtSalesExpenseOverview", dt))
            .DataSources.Add(New ReportDataSource("dtDefault", Retrieving.logoo()))
        End With
        salesExpensesOverview.RefreshReport()
    End Sub
    Private Sub frmSalesExpensesOverview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.salesExpensesOverview.RefreshReport()
        salesExpensesOverview.ZoomMode = ZoomMode.PageWidth
    End Sub
End Class