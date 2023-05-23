Imports Microsoft.Reporting.WinForms

Public Class frmCashBook
    Public Sub GetValue(ByVal dt As DataTable, ByRef datex As String)
        Dim retr As New Retrieving()
        Dim p(1) As ReportParameter
        p(0) = New ReportParameter("date", retr.dayTime())
        p(1) = New ReportParameter("datex", datex)
        With Me.cashBook.LocalReport
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.reportCash.rdlc"
            .DataSources.Add(New ReportDataSource("ItemizedSales", dt))
            .SetParameters(p)
        End With
        cashBook.RefreshReport()
    End Sub
    Private Sub frmCashBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cashBook.RefreshReport()
        cashBook.ZoomMode = ZoomMode.FullPage
    End Sub
End Class