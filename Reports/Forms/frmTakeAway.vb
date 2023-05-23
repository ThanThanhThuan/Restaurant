Imports Microsoft.Reporting.WinForms

Public Class frmTakeAway
    Dim retrieve As New Retrieving()

    Public Sub GetValue(ByVal dtCompany As DataTable, ByVal dtBill As DataTable, ByVal dtt As DataTable, ByVal items As Integer, ByVal qnty As Integer, ByVal cash As Decimal, ByVal change As Decimal, ByVal discount As Decimal, ByVal vat As Decimal, ByVal net As Decimal, ByVal gross As Decimal, Optional payment As String = "")
        Dim p(9) As ReportParameter
        p(0) = New ReportParameter("Cash", cash)
        p(1) = New ReportParameter("Items", items)
        p(2) = New ReportParameter("Qty", qnty)
        p(3) = New ReportParameter("Change", change)
        p(4) = New ReportParameter("Discount", discount)
        p(5) = New ReportParameter("VAT", vat)
        p(6) = New ReportParameter("Gross", gross)
        p(7) = New ReportParameter("Net", net)
        p(8) = New ReportParameter("Payment", payment)
        p(9) = New ReportParameter("dateTime", retrieve.dayTime())
        With Me.takeAway.LocalReport
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.takeAway.rdlc"
            .SetParameters(p)
            .DataSources.Add(New ReportDataSource("OrderSet", dtBill))
            .DataSources.Add(New ReportDataSource("DataSet", dtt))
            .DataSources.Add(New ReportDataSource("Company", dtCompany))
        End With
        'Dim pg As Printing.PageSettings = New Printing.PageSettings()
        'pg.Margins.Left = 0
        'pg.Margins.Right = 0
        'Me.rptPaidorder.SetPageSettings(pg)
        takeAway.RefreshReport()
    End Sub
    Private Sub frmTakeAway_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.takeAway.RefreshReport()
    End Sub
End Class