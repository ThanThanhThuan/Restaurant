Imports System.Data.SqlClient


Public Class frmCreditCustomerLedger

    Dim a, b, c As String

    Sub Reset()
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today
        txtCustomerID.Text = ""
        txtCustomerName.Text = ""
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            If Len(Trim(txtCustomerID.Text)) = 0 Then
                MessageBox.Show("Please retrieve CreditCustomer info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustomerID.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select PartyID from LedgerBook where PartyID=@d1 and Date >=@d2 and Date < @d3"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtCustomerID.Text)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()

            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer4.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Date, LedgerNo, Label, Credit, Debit,AccLedger from LedgerBook where Date >=@d1 and Date < @d2 and PartyID=@d3 order by ID,Date,LedgerNo", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Parameters.AddWithValue("@d3", txtCustomerID.Text)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("CreditCustomerLedgerNew.xml")
            Dim rpt As New rptCreditCustomerLedger
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", txtCustomerID.Text)
            rpt.SetParameterValue("p4", txtCustomerName.Text)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNavigation_Click(sender As System.Object, e As System.EventArgs) Handles btnNavigation.Click
        frmCreditCustomersList.lblSet.Text = "Customer Ledger"
        frmCreditCustomersList.Reset()
        frmCreditCustomersList.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from LedgerBook where Date >=@d2 and Date < @d3"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer4.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Date, LedgerNo, Label, Credit, Debit,LedgerBook.Name,AccLedger from LedgerBook,CreditCustomer where LedgerBook.PartyID=CreditCustomer.CreditCustomerID and Date >=@d1 and Date < @d2 order by ID,Date,LedgerNo", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("CreditCustomerLedgerNew1.xml")
            Dim rpt As New rptCreditCustomerLedger1
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", DateTimePicker2.Value.Date)
            rpt.SetParameterValue("p2", DateTimePicker1.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer4.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CreditCustomer.CreditCustomerID,LedgerBook.Name,ContactNo,IsNull(sum(Credit)-sum(Debit),0) as Balance FROM CreditCustomer Inner join LedgerBook on CreditCustomer.CreditCustomerID=LedgerBook.PartyID group by CreditCustomer.CreditCustomerID,LedgerBook.name,ContactNo having (sum(Credit)-sum(Debit)) <> 0 order by Name", con)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("CreditCustomerBalance.xml")
            Dim rpt As New rptCreditCustomerBalance
            rpt.SetDataSource(ds)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        Cursor = Cursors.Default
        Timer4.Enabled = False
    End Sub
End Class
