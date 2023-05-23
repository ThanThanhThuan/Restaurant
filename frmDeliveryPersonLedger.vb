Imports System.Data.SqlClient


Public Class frmDeliveryPersonLedger
    Sub Reset()
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        DateTimePicker2.Value = Today
        DateTimePicker1.Value = Today
        txtDPName.Text = ""
        txtDPID.Text = ""
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            If Len(Trim(txtDPName.Text)) = 0 Then
                MessageBox.Show("Please retrieve delivery person information", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDPName.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT RestaurantPOS_BillingInfoHD.BillNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.CustomerName, RestaurantPOS_BillingInfoHD.ContactNo,RestaurantPOS_BillingInfoHD.GrandTotal FROM RestaurantPOS_BillingInfoHD INNER JOIN EmployeeRegistration ON RestaurantPOS_BillingInfoHD.Employee_ID = EmployeeRegistration.EmpId where EmployeeID=@d1 and BillDate >=@d2 and BillDate < @d3 and HD_Status <> 'Cancelled'"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtDPID.Text)
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
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RestaurantPOS_BillingInfoHD.BillNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.CustomerName, RestaurantPOS_BillingInfoHD.ContactNo,RestaurantPOS_BillingInfoHD.GrandTotal FROM RestaurantPOS_BillingInfoHD INNER JOIN EmployeeRegistration ON RestaurantPOS_BillingInfoHD.Employee_ID = EmployeeRegistration.EmpId where EmployeeID=@d1 and BillDate >=@d2 and BillDate < @d3 and HD_Status <> 'Cancelled' order by BillDate", con)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Parameters.AddWithValue("@d1", txtDPID.Text)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("CollectionsByDP.xml")
            Dim rpt As New rptCollectionsByDP
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", txtDPID.Text)
            rpt.SetParameterValue("p4", txtDPName.Text)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSelection_Click(sender As System.Object, e As System.EventArgs) Handles btnSelection.Click
        frmEmployeesRecord.lblSet.Text = "Collections Report"
        frmEmployeesRecord.Reset()
        frmEmployeesRecord.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT RestaurantPOS_BillingInfoHD.BillNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.CustomerName, RestaurantPOS_BillingInfoHD.ContactNo,RestaurantPOS_BillingInfoHD.GrandTotal FROM RestaurantPOS_BillingInfoHD INNER JOIN EmployeeRegistration ON RestaurantPOS_BillingInfoHD.Employee_ID = EmployeeRegistration.EmpId where BillDate >=@d2 and BillDate < @d3 and HD_Status <> 'Cancelled'"
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
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RestaurantPOS_BillingInfoHD.BillNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.CustomerName, RestaurantPOS_BillingInfoHD.ContactNo,EmployeeRegistration.EmployeeName,RestaurantPOS_BillingInfoHD.GrandTotal FROM RestaurantPOS_BillingInfoHD INNER JOIN EmployeeRegistration ON RestaurantPOS_BillingInfoHD.Employee_ID = EmployeeRegistration.EmpId where BillDate >=@d2 and BillDate < @d3 and HD_Status <> 'Cancelled' order by BillDate", con)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("CollectionsByDP1.xml")
            Dim rpt As New rptCollectionsByDP1
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
