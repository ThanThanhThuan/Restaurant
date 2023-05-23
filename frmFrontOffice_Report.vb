Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.SqlServer.Management.Smo
Public Class frmFrontOffice_Report
    Dim Filename As String

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPOSReport_Click(sender As System.Object, e As System.EventArgs) Handles btnPOSReport.Click
        frmRPOSReport.Reset()
        frmRPOSReport.ShowDialog()
    End Sub

    Private Sub btnWorkPeriodReport_Click(sender As System.Object, e As System.EventArgs) Handles btnWorkPeriodReport.Click
        frmWorkPeriodReport.Reset()
        frmWorkPeriodReport.ShowDialog()
    End Sub
End Class