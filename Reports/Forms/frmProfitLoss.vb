Imports Microsoft.Reporting.WinForms

Public Class frmProfitLoss
    Dim retrieve As New Retrieving()

    Public Sub GetValue(ByVal dtt As DataTable)
        Dim p(0) As ReportParameter
        p(0) = New ReportParameter("dateTime", retrieve.dayTime())
        With Me.rptProfitLoss.LocalReport
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.ProfitLoss.rdlc"
            .SetParameters(p)
            .DataSources.Add(New ReportDataSource("stockContent", dtt))
        End With
        rptProfitLoss.RefreshReport()
    End Sub
    Private Sub frmProfitLoss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.rptProfitLoss.RefreshReport()
        rptProfitLoss.ZoomMode = ZoomMode.PageWidth
    End Sub
End Class