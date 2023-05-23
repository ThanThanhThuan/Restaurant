Imports Microsoft.Reporting.WinForms

Public Class frmhmdlv

    Public Sub GetValue(ByVal dtCompany As DataTable, ByVal dtBill As DataTable, ByVal dtt As DataTable, ByVal items As Integer, ByVal qnty As Integer, ByVal cash As Decimal, ByVal change As Decimal, ByVal discount As Decimal, ByVal vat As Decimal, ByVal net As Decimal, ByVal gross As Decimal, ByVal customer As String, ByVal contact As String, ByVal address As String, ByVal deliveryP As String, ByVal deliveryFee As Double, Optional payment As String = "")
        Dim p(13) As ReportParameter
        p(0) = New ReportParameter("Cash", cash)
        p(1) = New ReportParameter("Items", items)
        p(2) = New ReportParameter("Qty", qnty)
        p(3) = New ReportParameter("Change", change)
        p(4) = New ReportParameter("Discount", discount)
        p(5) = New ReportParameter("VAT", vat)
        p(6) = New ReportParameter("Gross", gross)
        p(7) = New ReportParameter("Net", net)
        p(8) = New ReportParameter("Payment", payment)
        p(9) = New ReportParameter("customer", customer)
        p(10) = New ReportParameter("contact", contact)
        p(11) = New ReportParameter("address", address)
        p(12) = New ReportParameter("deliveryP", deliveryP)
        p(13) = New ReportParameter("deliveryFee", deliveryFee)
        With Me.homeDelivery.LocalReport
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.HomeDelivery.rdlc"
            .SetParameters(p)
            .DataSources.Add(New ReportDataSource("OrderSet", dtBill))
            .DataSources.Add(New ReportDataSource("DataSet", dtt))
            .DataSources.Add(New ReportDataSource("Company", dtCompany))
        End With
        'Dim pg As Printing.PageSettings = New Printing.PageSettings()
        'pg.Margins.Left = 0
        'pg.Margins.Right = 0
        'Me.rptPaidorder.SetPageSettings(pg)
        homeDelivery.RefreshReport()
    End Sub
    Private Sub frmhmdlv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.homeDelivery.RefreshReport()
    End Sub
End Class