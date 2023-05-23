Imports System.Data.SqlClient


Public Class frmGeneralLedger

    Dim a, b, c As String

    Sub Reset()
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        cmbAccountName.Text = ""
        fillCombo()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Sub fillCombo()
        Try
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            Dim ctn1 As String = "SELECT distinct RTRIM(Name) FROM LedgerBook order by 1"
            cmd = New SqlCommand(ctn1)
            cmd.Connection = con
            cmbAccountName.Items.Clear()
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                cmbAccountName.Items.Add(rdr(0).ToString())
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            If Len(Trim(cmbAccountName.Text)) = 0 Then
                MessageBox.Show("Please select account name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbAccountName.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select PartyID from LedgerBook where Name=@d1 and Date >=@d2 and Date < @d3"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", cmbAccountName.Text)
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
            cmd = New SqlCommand("Select Date, LedgerNo, Label, Credit, Debit,AccLedger,Name from LedgerBook where Date >=@d1 and Date < @d2 and Name=@d3 order by ID,Date,LedgerNo", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Parameters.AddWithValue("@d3", cmbAccountName.Text)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("LedgerBookNew.xml")
            Dim rpt As New rptGeneralLedger
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", cmbAccountName.Text & " " & " Ledger")
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
  
    Private Sub frmGeneralLedger_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fillCombo()
    End Sub

    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        Cursor = Cursors.Default
        Timer4.Enabled = False
    End Sub
End Class
