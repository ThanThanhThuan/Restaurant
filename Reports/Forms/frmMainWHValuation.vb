Imports Microsoft.Reporting.WinForms

Public Class frmMainWHValuation
    Public Sub GetValue(ByVal dt As DataTable)
        Dim retr As New Retrieving()
        With Me.mainWarehouseValuation.LocalReport
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.MainWHValuation.rdlc"
            .DataSources.Add(New ReportDataSource("dtMainWHValuation", dt))
            .DataSources.Add(New ReportDataSource("dtDefault", Retrieving.logoo()))
        End With
        mainWarehouseValuation.RefreshReport()
    End Sub
    Private Sub frmMainWHValuation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.mainWarehouseValuation.RefreshReport()
        mainWarehouseValuation.ZoomMode = ZoomMode.FullPage
    End Sub
End Class