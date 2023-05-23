Imports System.Data.SqlClient

Public Class frmRPOSReport
    Dim a, b, b1, b2, b3, b4, b5 As Double
    Dim retrieving As New Retrieving()
    Sub Reset()
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        DateTimePicker1.Value = Today
        cmbWaiterName.SelectedIndex = -1
        cmbOperatorID.SelectedIndex = -1
    End Sub
    Sub fillWaiter()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Waiter) FROM RestaurantPOS_BillingInfoKOT where Waiter is not Null and Waiter <> '' order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbWaiterName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbWaiterName.Items.Add(drow(0).ToString())
            Next
            CN.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub GetSections()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select KitchenName from Kitchen order by KitchenName ASC"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            Dim dt As New DataTable()
            dt.Load(rdr)
            cmbSection.Items.Clear()
            For Each row As DataRow In dt.Rows
                cmbSection.Items.Add(row("KitchenName").ToString.Trim())
            Next
            If cmbSection.Items.Count > 0 Then
                cmbSection.SelectedIndex = 0
            End If
        Catch
        End Try
    End Sub

    Sub FillStore()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(KitchenName) FROM Kitchen", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbDestination.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbDestination.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillWarehouse()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(WarehouseName) FROM Warehouse", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbSource.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbSource.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillItem()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(DishName) FROM Dish order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbItemName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbItemName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillOperatorID()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Operator) FROM RestaurantPOS_BillingInfoKOT UNION SELECT distinct RTRIM(Operator) FROM RestaurantPOS_BillingInfoTA where TA_Status <> 'Void' UNION SELECT distinct RTRIM(Operator) FROM RestaurantPOS_BillingInfoHD Where HD_Status <> 'Cancelled' UNION SELECT distinct RTRIM(Operator) FROM RestaurantPOS_BillingInfoEB where EB_Status <> 'Void' order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbOperatorID.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbOperatorID.Items.Add(drow(0).ToString())
            Next
            CN.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
            Dim ds As DataSet
            Dim adp, adp1, adp2, adp3, adp4, adp5 As SqlDataAdapter
            Dim dtable, dtable1, dtable2, dtable3, dtable4, dtable5 As DataTable
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select Operator from RestaurantPOS_BillingInfoKOT where BillDate >=@d1 and BillDate < @d2 union select Operator from RestaurantPOS_BillingInfoTA where BillDate >=@d1 and BillDate < @d2 and TA_Status <> 'Void' union select Operator from RestaurantPOS_BillingInfoHD where BillDate >=@d1 and BillDate < @d2 and HD_Status <> 'Cancelled' Union select Operator from RestaurantPOS_BillingInfoEB where BillDate >=@d1 and BillDate < @d2 and EB_Status <> 'Void'"
            cmd5 = New SqlCommand(ct)
            cmd5.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd5.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd5.Connection = con
            rdr = cmd5.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT * from Hotel", con)
            adp = New SqlDataAdapter(cmd)
            cmd1 = New SqlCommand("SELECT Operator,Sum(GrandTotal) as [GrandTotal] from(Select Operator,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoKOT where BillDate >=@d1 and BillDate < @d2  Union all Select Operator,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoTA where BillDate >=@d1 and BillDate < @d2 and TA_Status <> 'Void' Union all Select Operator,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoHD where BillDate >=@d1 and BillDate < @d2 and HD_Status <> 'Cancelled' Union all Select Operator,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoEB where BillDate >=@d1 and BillDate < @d2 and EB_Status <> 'Void')G  group by Operator order by 1", con)
            cmd1.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd1.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            adp1 = New SqlDataAdapter(cmd1)
            cmd2 = New SqlCommand("SELECT Category,Sum(TotalAmount) as Total from (Select category,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillKOT, RestaurantPOS_BillingInfoKOT where RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID and BillDate >=@d3 and BillDate < @d4 UNION ALL Select category,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillTA, RestaurantPOS_BillingInfoTA where RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and BillDate >=@d3 and BillDate < @d4 and TA_Status <> 'Void' UNION ALL Select category,(TotalAmount) as [TotalAmount] from RestaurantPOS_OrderedProductBillHD, RestaurantPOS_BillingInfoHD where RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and BillDate >=@d3 and BillDate < @d4 and HD_Status <> 'Cancelled' Union all Select category,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillEB, RestaurantPOS_BillingInfoEB where RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID and BillDate >=@d3 and BillDate < @d4 and EB_Status <> 'Void')C group by Category order by 1", con)
            cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            adp2 = New SqlDataAdapter(cmd2)
            cmd3 = New SqlCommand("SELECT Category,Sum(Quantity) as TotalQuantity from (Select category,Quantity from RestaurantPOS_OrderedProductBillKOT, RestaurantPOS_BillingInfoKOT where RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID and BillDate >=@d5 and BillDate < @d6 UNION ALL Select category,Quantity from RestaurantPOS_OrderedProductBillTA, RestaurantPOS_BillingInfoTA where RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and BillDate >=@d5 and BillDate < @d6 and TA_Status <> 'Void' UNION ALL Select category,Quantity from RestaurantPOS_OrderedProductBillHD, RestaurantPOS_BillingInfoHD where RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and BillDate >=@d5 and BillDate < @d6 and HD_Status <> 'Cancelled' Union all Select category,Quantity from RestaurantPOS_OrderedProductBillEB, RestaurantPOS_BillingInfoEB where RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID and BillDate >=@d5 and BillDate < @d6 and EB_Status <> 'Void')C group by Category order by 1", con)
            cmd3.Parameters.Add("@d5", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd3.Parameters.Add("@d6", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            adp3 = New SqlDataAdapter(cmd3)
            cmd4 = New SqlCommand("SELECT Dish,Sum(Quantity) as [Quantity],Sum(TotalAmount) as [Amount] from (Select Dish,Quantity,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillKOT,RestaurantPOS_BillingInfoKOT where BillDate >=@d7 and BillDate < @d8 and RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID Union All Select Dish,Quantity,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillTA,RestaurantPOS_BillingInfoTA where BillDate >=@d7 and BillDate < @d8 and RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and TA_Status <> 'Void' Union All Select Dish,Quantity,TotalAmount as [TotalAmount] from RestaurantPOS_OrderedProductBillHD,RestaurantPOS_BillingInfoHD where BillDate >=@d7 and BillDate < @d8 and RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and HD_Status <> 'Cancelled' Union all Select Dish,Quantity,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillEB,RestaurantPOS_BillingInfoEB where BillDate >=@d7 and BillDate < @d8 and RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID and EB_Status <> 'Void')G  group by Dish order by 1", con)
            cmd4.Parameters.Add("@d7", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd4.Parameters.Add("@d8", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            adp4 = New SqlDataAdapter(cmd4)
            cmd6 = New SqlCommand("SELECT PaymentMode,Sum(GrandTotal) as [GrandTotal] from (Select PaymentMode,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoKOT where BillDate >=@d11 and BillDate < @d12 Union All Select  PaymentMode,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoTA where BillDate >=@d11 and BillDate < @d12 and TA_Status <> 'Void' Union All Select  PaymentMode,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoHD where BillDate >=@d11 and BillDate < @d12 and HD_Status <> 'Cancelled' Union all Select PaymentMode,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoEB where BillDate >=@d11 and BillDate < @d12 and EB_Status <> 'Void')G  group by PaymentMode order by 1", con)
            cmd6.Parameters.Add("@d11", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd6.Parameters.Add("@d12", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            adp5 = New SqlDataAdapter(cmd6)
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "select IsNull(Sum(HomeDeliveryCharges),0) from RestaurantPOS_BillingInfoHD where BillDate >=@d9 and BillDate < @d10 and HD_Status <> 'Cancelled'"
            cmd = New SqlCommand(ct1)
            cmd.Parameters.Add("@d9", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d10", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                a = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct2 As String = "select IsNull(Sum(ParcelCharges*ExchangeRate),0) from RestaurantPOS_BillingInfoTA where BillDate >=@d11 and BillDate < @d12 and TA_Status <> 'Void'"
            cmd = New SqlCommand(ct2)
            cmd.Parameters.Add("@d11", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d12", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                b = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct4 As String = "Select IsNull(Sum(GrandTotal*ExchangeRate),0)  from RestaurantPOS_BillingInfoKOT where BillDate >=@d13 and BillDate < @d14"
            cmd = New SqlCommand(ct4)
            cmd.Parameters.Add("@d13", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d14", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                b1 = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct5 As String = "Select IsNull(Sum(GrandTotal*ExchangeRate),0)  from RestaurantPOS_BillingInfoTA where BillDate >=@d13 and BillDate < @d14 and TA_Status <> 'Void'"
            cmd = New SqlCommand(ct5)
            cmd.Parameters.Add("@d13", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d14", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                b2 = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct6 As String = "Select IsNull(Sum(GrandTotal),0)  from RestaurantPOS_BillingInfoHD where BillDate >=@d13 and BillDate < @d14 and HD_Status <> 'Cancelled'"
            cmd = New SqlCommand(ct6)
            cmd.Parameters.Add("@d13", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d14", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                b3 = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct7 As String = "Select IsNull(Sum(GrandTotal*ExchangeRate),0)  from RestaurantPOS_BillingInfoEB where BillDate >=@d13 and BillDate < @d14 and EB_Status <> 'Void'"
            cmd = New SqlCommand(ct7)
            cmd.Parameters.Add("@d13", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d14", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                b4 = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct8 As String = "SELECT Sum(TotalVAT) as TotalVAT from (Select VATAmount as [TotalVAT] from RestaurantPOS_OrderedProductBillKOT, RestaurantPOS_BillingInfoKOT where RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID and BillDate >=@d3 and BillDate < @d4 UNION ALL Select VATAmount as [TotalVAT] from RestaurantPOS_OrderedProductBillTA, RestaurantPOS_BillingInfoTA where RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and BillDate >=@d3 and BillDate < @d4 and TA_Status <> 'Void' UNION ALL Select VATAmount as [TotalVAT] from RestaurantPOS_OrderedProductBillHD, RestaurantPOS_BillingInfoHD where RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and BillDate >=@d3 and BillDate < @d4 and HD_Status <> 'Cancelled' Union all Select VATAmount as [TotalVAT] from RestaurantPOS_OrderedProductBillEB, RestaurantPOS_BillingInfoEB where RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID and BillDate >=@d3 and BillDate < @d4 and EB_Status <> 'Void')C"
            cmd = New SqlCommand(ct8)
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d4", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                b5 = rdr.GetValue(0)
            End If
            con.Close()
            dtable = New DataTable()
            dtable1 = New DataTable()
            dtable2 = New DataTable()
            dtable3 = New DataTable()
            dtable4 = New DataTable()
            dtable5 = New DataTable()
            adp.Fill(dtable)
            adp1.Fill(dtable1)
            adp2.Fill(dtable2)
            adp3.Fill(dtable3)
            adp4.Fill(dtable4)
            adp5.Fill(dtable5)
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.Tables.Add(dtable1)
            ds.Tables.Add(dtable2)
            ds.Tables.Add(dtable3)
            ds.Tables.Add(dtable4)
            ds.Tables.Add(dtable5)
            ds.WriteXmlSchema("RPOSNew.xml")
            Dim rpt As New rptRPOS
            rpt.Subreports(0).SetDataSource(ds)
            rpt.Subreports(1).SetDataSource(ds)
            rpt.Subreports(2).SetDataSource(ds)
            rpt.Subreports(3).SetDataSource(ds)
            rpt.Subreports(4).SetDataSource(ds)
            rpt.Subreports(5).SetDataSource(ds)
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            rpt.SetParameterValue("p4", b)
            rpt.SetParameterValue("p5", a)
            rpt.SetParameterValue("p6", b)
            rpt.SetParameterValue("b1", b1)
            rpt.SetParameterValue("b2", b2)
            rpt.SetParameterValue("b3", b3)
            rpt.SetParameterValue("b4", b4)
            rpt.SetParameterValue("b5", b5)
            frmRPOSReport_CRViewer.CrystalReportViewer1.ReportSource = rpt
            frmRPOSReport_CRViewer.dtpDateFrom.Value = dtpDateFrom.Value
            frmRPOSReport_CRViewer.dtpDateTo.Value = dtpDateTo.Value
            frmRPOSReport_CRViewer.txtEmailID.Text = ""
            frmRPOSReport_CRViewer.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Operator from RestaurantPOS_BillingInfoKOT where BillDate >=@d1 and BillDate < @d2"
            cmd = New SqlCommand(ctX)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptRestaurantPOS 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT RestaurantPOS_BillingInfoKOT.Id,PaymentMode,Operator,CurrencyCode, RestaurantPOS_BillingInfoKOT.BillNo, RestaurantPOS_BillingInfoKOT.BillDate, RestaurantPOS_BillingInfoKOT.GrandTotal, RestaurantPOS_BillingInfoKOT.Cash, RestaurantPOS_BillingInfoKOT.Change,RestaurantPOS_OrderedProductBillKOT.OP_ID, RestaurantPOS_OrderedProductBillKOT.BillID, RestaurantPOS_OrderedProductBillKOT.Dish,RestaurantPOS_OrderedProductBillKOT.Rate, RestaurantPOS_OrderedProductBillKOT.Quantity,SCPer,SCAmount, RestaurantPOS_OrderedProductBillKOT.Amount,RestaurantPOS_OrderedProductBillKOT.VATPer, RestaurantPOS_OrderedProductBillKOT.VATAmount, RestaurantPOS_OrderedProductBillKOT.STPer, RestaurantPOS_OrderedProductBillKOT.STAmount,RestaurantPOS_OrderedProductBillKOT.DiscountPer, RestaurantPOS_OrderedProductBillKOT.DiscountAmount, RestaurantPOS_OrderedProductBillKOT.TotalAmount, RestaurantPOS_OrderedProductBillKOT.TableNo FROM RestaurantPOS_BillingInfoKOT INNER JOIN RestaurantPOS_OrderedProductBillKOT ON RestaurantPOS_BillingInfoKOT.Id = RestaurantPOS_OrderedProductBillKOT.BillID where BillDate >=@d1 and BillDate < @d2 order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_BillingInfoKOT")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillKOT")
            myDA1.Fill(myDS, "Hotel")
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select IsNull(Sum(GrandTotal),0) from RestaurantPOS_BillingInfoKOT where BillDate >=@d1 and BillDate < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                a = rdr.GetValue(0)
            End While
            con.Close()
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Operator from RestaurantPOS_BillingInfoTA where BillDate >=@d1 and BillDate < @d2"
            cmd = New SqlCommand(ctX)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptRestaurantPOSTA 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT TA_Status,RestaurantPOS_BillingInfoTA.Id,Operator,SCPer,SCAmount,PaymentMode,ParcelCharges,SubTotal,CurrencyCode, RestaurantPOS_BillingInfoTA.BillNo, RestaurantPOS_BillingInfoTA.BillDate, RestaurantPOS_BillingInfoTA.GrandTotal, RestaurantPOS_BillingInfoTA.Cash, RestaurantPOS_BillingInfoTA.Change,RestaurantPOS_OrderedProductBillTA.OP_ID, RestaurantPOS_OrderedProductBillTA.BillID, RestaurantPOS_OrderedProductBillTA.Dish,RestaurantPOS_OrderedProductBillTA.Rate, RestaurantPOS_OrderedProductBillTA.Quantity, RestaurantPOS_OrderedProductBillTA.Amount,RestaurantPOS_OrderedProductBillTA.VATPer, RestaurantPOS_OrderedProductBillTA.VATAmount, RestaurantPOS_OrderedProductBillTA.STPer, RestaurantPOS_OrderedProductBillTA.STAmount,RestaurantPOS_OrderedProductBillTA.DiscountPer, RestaurantPOS_OrderedProductBillTA.DiscountAmount, RestaurantPOS_OrderedProductBillTA.TotalAmount FROM RestaurantPOS_BillingInfoTA INNER JOIN RestaurantPOS_OrderedProductBillTA ON RestaurantPOS_BillingInfoTA.Id = RestaurantPOS_OrderedProductBillTA.BillID where BillDate >=@d1 and BillDate < @d2 order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_BillingInfoTA")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillTA")
            myDA1.Fill(myDS, "Hotel")
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select IsNull(Sum(GrandTotal),0) from RestaurantPOS_BillingInfoTA where BillDate >=@d1 and BillDate < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                a = rdr.GetValue(0)
            End While
            con.Close()
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnstockContentrpt_Click(sender As Object, e As EventArgs) Handles btnstockContentrpt.Click
        Try
            Dim dt As New DataTable()
            dt = retrieving.StockReport(date1.Value, date2.Value, cmbItemName.Text, cmbSection.Text)
            If dt.Rows.Count > 0 Then
                Dim stkReport As New frmStockreport()
                stkReport.GetValue(dt)
                stkReport.ShowDialog()
            Else
                MessageBox.Show("No data", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Dim dd As Double
    Private Sub btnstkBalance_Click(sender As Object, e As EventArgs) Handles btnstkBalance.Click
        Try
            Dim ds As New DataSet()
            ds = retrieving.GetStocksBalancerpt(cmbItemName.Text, cmbSection.Text)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim stkReport As New frmStockBalance()
                stkReport.GetValue(ds.Tables(0))
                stkReport.ShowDialog()
            Else
                MessageBox.Show("No data", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnStockTransfer_Click(sender As Object, e As EventArgs) Handles btnStockTransfer.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("uspStockTransfer", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@item", cmbItemName.Text)
            cmd.Parameters.Add("@dateFrom", SqlDbType.DateTime).Value = date1.Value.ToString("MM/dd/yyyy")
            cmd.Parameters.Add("@dateTo", SqlDbType.DateTime).Value = date2.Value.ToString("MM/dd/yyyy")
            adp = New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            adp.Fill(dt)
            con.Close()
            If dt.Rows.Count > 0 Then
                Dim trnsfr As New frmstkTransfer
                trnsfr.GetValue(dt)
                trnsfr.ShowDialog()
            Else
                MessageBox.Show("No data", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnProfitLoss_Click(sender As Object, e As EventArgs) Handles btnProfitLoss.Click
        Try
            Dim dt As New DataTable()
            dt = retrieving.GetProfitLossrpt(date1.Value, date2.Value)
            If dt.Rows.Count > 0 Then
                Dim rptProfitLoss As New frmProfitLoss()
                rptProfitLoss.GetValue(dt)
                rptProfitLoss.ShowDialog()
            Else
                MessageBox.Show("No data", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub fillWaiter1()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Waiter) FROM RestaurantPOS_BillingInfoKOT where Waiter is not Null and Waiter <> '' order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbWaiterName.Items.Clear()
            cmbWaiter.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbWaiterName.Items.Add(drow(0).ToString())
                cmbWaiter.Items.Add(drow(0).ToString())
            Next
            CN.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillCategory()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct [Category] FROM RestaurantPOS_OrderedProductBillKOT order by Category ASC", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbCategory.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbCategory.Items.Add(drow(0).ToString())
            Next
            CN.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillProduct_Category()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT [CategoryName] FROM [dbo].[RMCategory] order by CategoryName ASC", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbMisc.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbMisc.Items.Add(drow(0).ToString())
            Next
            CN.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Dim dt As New DataTable()
            dt = retrieving.GetItemizedSalesrpt(dateSalesFrom.Value, dateSalesTo.Value, cmbCategory.Text, cmbWaiter.Text)
            If dt.Rows.Count > 0 Then
                Dim itmSalesReport As New frmSalesReport()
                itmSalesReport.GetValue(dt, (dateSalesFrom.Value.ToString("dd/MM/yyyy") + " - " + dateSalesTo.Value.ToString("dd/MM/yyyy")))
                itmSalesReport.ShowDialog()
            Else
                MessageBox.Show("No data", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnHappyHour_Click(sender As Object, e As EventArgs) Handles btnHappyHour.Click
        Try
            Dim dt As New DataTable()
            dt = retrieving.GetsalesHappyHoursrpt(dateSalesFrom.Value, dateSalesTo.Value, cmbCategory.Text, cmbWaiter.Text)
            If dt.Rows.Count > 0 Then
                Dim salesHappyHourReport As New frmHappyHour()
                salesHappyHourReport.GetValue(dt, (dateSalesFrom.Value.ToString("dd/MM/yyyy") + " - " + dateSalesTo.Value.ToString("dd/MM/yyyy")))
                salesHappyHourReport.ShowDialog()
            Else
                MessageBox.Show("No data", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSalesExpensesOverview_Click(sender As Object, e As EventArgs) Handles btnSalesExpensesOverview.Click
        Try
            Dim dt As New DataTable()
            dt = retrieving.salesExpensesOverview(salesExpense_dateFrom.Value, salesExpense_dateTo.Value)
            If dt.Rows.Count > 0 Then
                Dim salesExpensesOverview As New frmSalesExpensesOverview()
                salesExpensesOverview.GetValue(dt)
                salesExpensesOverview.ShowDialog()
            Else
                MessageBox.Show("No data", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnStockUsage_Click(sender As Object, e As EventArgs) Handles btnStockUsage.Click
        Try
            Dim dt As New DataTable()
            dt = retrieving.stockUsage(salesExpense_dateFrom.Value, salesExpense_dateTo.Value, cmbMisc.Text.Trim())
            If dt.Rows.Count > 0 Then
                Dim stockUsage As New frmStockUsge()
                stockUsage.GetValue(dt)
                stockUsage.ShowDialog()
            Else
                MessageBox.Show("No data", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnMainWHValuation_Click(sender As Object, e As EventArgs) Handles btnMainWHValuation.Click
        Try
            Dim dt As New DataTable()
            dt = retrieving.mainWHValuation(salesExpense_dateFrom.Value, salesExpense_dateTo.Value, cmbMisc.Text.Trim())
            If dt.Rows.Count > 0 Then
                Dim mainWHValuation As New frmMainWHValuation()
                mainWHValuation.GetValue(dt)
                mainWHValuation.ShowDialog()
            Else
                MessageBox.Show("No data", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Operator from RestaurantPOS_BillingInfoHD where BillDate >=@d1 and BillDate < @d2"
            cmd = New SqlCommand(ctX)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptRestaurantPOSHD 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT HD_Status,RestaurantPOS_BillingInfoHD.Id, RestaurantPOS_BillingInfoHD.BillNo,SCPer,SCAmount, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.Operator, RestaurantPOS_BillingInfoHD.SubTotal,RestaurantPOS_BillingInfoHD.HomeDeliveryCharges, RestaurantPOS_BillingInfoHD.GrandTotal, RestaurantPOS_BillingInfoHD.CustomerName, RestaurantPOS_BillingInfoHD.Address,RestaurantPOS_BillingInfoHD.ContactNo, RestaurantPOS_BillingInfoHD.Employee_ID, RestaurantPOS_BillingInfoHD.PaymentMode, RestaurantPOS_OrderedProductBillHD.OP_ID, RestaurantPOS_OrderedProductBillHD.BillID, RestaurantPOS_OrderedProductBillHD.Dish, RestaurantPOS_OrderedProductBillHD.Rate, RestaurantPOS_OrderedProductBillHD.Quantity,RestaurantPOS_OrderedProductBillHD.Amount, RestaurantPOS_OrderedProductBillHD.VATPer, RestaurantPOS_OrderedProductBillHD.VATAmount, RestaurantPOS_OrderedProductBillHD.STPer,RestaurantPOS_OrderedProductBillHD.STAmount, RestaurantPOS_OrderedProductBillHD.DiscountPer, RestaurantPOS_OrderedProductBillHD.DiscountAmount,RestaurantPOS_OrderedProductBillHD.TotalAmount, RestaurantPOS_OrderedProductBillHD.Notes, EmployeeRegistration.EmpId, EmployeeRegistration.EmployeeID, EmployeeRegistration.EmployeeName,EmployeeRegistration.Address AS Expr1, EmployeeRegistration.City, EmployeeRegistration.ContactNo AS Expr2, EmployeeRegistration.Email, EmployeeRegistration.DateOfJoining, EmployeeRegistration.Photo,EmployeeRegistration.Active FROM RestaurantPOS_BillingInfoHD INNER JOIN RestaurantPOS_OrderedProductBillHD ON RestaurantPOS_BillingInfoHD.Id = RestaurantPOS_OrderedProductBillHD.BillID INNER JOIN EmployeeRegistration ON RestaurantPOS_BillingInfoHD.Employee_ID = EmployeeRegistration.EmpId where BillDate >=@d1 and BillDate < @d2 order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_BillingInfoHD")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillHD")
            myDA.Fill(myDS, "EmployeeRegistration")
            myDA1.Fill(myDS, "Hotel")
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select IsNull(Sum(GrandTotal),0) from RestaurantPOS_BillingInfoHD where BillDate >=@d1 and BillDate < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                a = rdr.GetValue(0)
            End While
            con.Close()
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Operator from RestaurantPOS_BillingInfoEB where BillDate >=@d1 and BillDate < @d2"
            cmd = New SqlCommand(ctX)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptRestaurantPOSEB 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT EB_Status,RestaurantPOS_BillingInfoEB.Id,PaymentMode,Operator,SCPer,SCAmount,CurrencyCode, RestaurantPOS_BillingInfoEB.BillNo, RestaurantPOS_BillingInfoEB.BillDate, RestaurantPOS_BillingInfoEB.GrandTotal, RestaurantPOS_BillingInfoEB.Cash, RestaurantPOS_BillingInfoEB.Change,RestaurantPOS_OrderedProductBillEB.OP_ID, RestaurantPOS_OrderedProductBillEB.BillID, RestaurantPOS_OrderedProductBillEB.Dish,RestaurantPOS_OrderedProductBillEB.Rate, RestaurantPOS_OrderedProductBillEB.Quantity, RestaurantPOS_OrderedProductBillEB.Amount,RestaurantPOS_OrderedProductBillEB.VATPer, RestaurantPOS_OrderedProductBillEB.VATAmount, RestaurantPOS_OrderedProductBillEB.STPer, RestaurantPOS_OrderedProductBillEB.STAmount,RestaurantPOS_OrderedProductBillEB.DiscountPer, RestaurantPOS_OrderedProductBillEB.DiscountAmount, RestaurantPOS_OrderedProductBillEB.TotalAmount FROM RestaurantPOS_BillingInfoEB INNER JOIN RestaurantPOS_OrderedProductBillEB ON RestaurantPOS_BillingInfoEB.Id = RestaurantPOS_OrderedProductBillEB.BillID where BillDate >=@d1 and BillDate < @d2 order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_BillingInfoEB")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillEB")
            myDA1.Fill(myDS, "Hotel")
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select IsNull(Sum(GrandTotal),0) from RestaurantPOS_BillingInfoEB where BillDate >=@d1 and BillDate < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                a = rdr.GetValue(0)
            End While
            con.Close()
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim cmd, cmd1, cmd5 As SqlCommand
            Dim ds As DataSet
            Dim adp, adp1 As SqlDataAdapter
            Dim dtable, dtable1 As DataTable
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT BillDate,Sum(GrandTotal) as [GrandTotal] from(Select Cast(BillDate as Date) as BillDate,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoKOT WHERE (MONTH(BillDate) = @d1) AND (YEAR(BillDate) =@d2) Union all Select Cast(BillDate as Date) as BillDate,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoTA WHERE (MONTH(BillDate) = @d1) AND (YEAR(BillDate) =@d2) and TA_Status <> 'Void' Union all Select Cast(BillDate as Date) as BillDate,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoHD WHERE (MONTH(BillDate) = @d1) AND (YEAR(BillDate) =@d2) and HD_Status <> 'Cancelled' Union all Select Cast(BillDate as Date) as BillDate,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoEB WHERE (MONTH(BillDate) = @d1) AND (YEAR(BillDate) =@d2) and EB_Status <> 'Void')G  group by BillDate order by 1"
            cmd5 = New SqlCommand(ct)
            cmd5.Parameters.AddWithValue("@d1", DateTimePicker1.Value.Date.Month)
            cmd5.Parameters.AddWithValue("@d2", DateTimePicker1.Value.Date.Year)
            cmd5.Connection = con
            rdr = cmd5.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT * from Hotel", con)
            adp = New SqlDataAdapter(cmd)
            cmd1 = New SqlCommand("SELECT BillDate,Sum(GrandTotal) as [GrandTotal] from(Select Cast(BillDate as Date) as BillDate,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoKOT WHERE (MONTH(BillDate) = @d1) AND (YEAR(BillDate) =@d2) Union all Select Cast(BillDate as Date) as BillDate,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoTA WHERE (MONTH(BillDate) = @d1) AND (YEAR(BillDate) =@d2) and TA_Status <> 'Void' Union all Select Cast(BillDate as Date) as BillDate,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoHD WHERE (MONTH(BillDate) = @d1) AND (YEAR(BillDate) =@d2) and HD_Status <> 'Cancelled' Union all Select Cast(BillDate as Date) as BillDate,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoEB WHERE (MONTH(BillDate) = @d1) AND (YEAR(BillDate) =@d2) and EB_Status <> 'Void')G  group by BillDate order by 1", con)
            cmd1.Parameters.AddWithValue("@d1", DateTimePicker1.Value.Date.Month)
            cmd1.Parameters.AddWithValue("@d2", DateTimePicker1.Value.Date.Year)
            adp1 = New SqlDataAdapter(cmd1)
            dtable = New DataTable()
            dtable1 = New DataTable()
            adp.Fill(dtable)
            adp1.Fill(dtable1)
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.Tables.Add(dtable1)
            ds.WriteXmlSchema("NewROSReportByMonth.xml")
            Dim rpt As New rptRPOSByMonth
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", DateTimePicker1.Value)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmRPOSReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fillOperatorID()
        fillWaiter()
        fillWaiter1()
        fillCategory()
        fillProduct_Category()
        fillItem()
        FillWarehouse()
        FillStore()
        GetSections()
    End Sub

    Private Sub cmbWaiterName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbWaiterName.SelectedIndexChanged
        Try
            If cmbWaiterName.SelectedIndex >= 0 Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Waiter from RestaurantPOS_BillingInfoKOT where BillDate >=@d1 and BillDate < @d2 and Waiter=@d3"
                cmd = New SqlCommand(ct)
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
                cmd.Parameters.AddWithValue("@d3", cmbWaiterName.Text)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If Not rdr.Read() Then
                    MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    Return
                End If
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT BillNo, BillDate, Operator, PaymentMode, GrandTotal FROM RestaurantPOS_BillingInfoKOT where BillDate >=@d1 and BillDate < @d2 and Waiter=@d3 order by 2", con)
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
                cmd.Parameters.AddWithValue("@d3", cmbWaiterName.Text)
                adp = New SqlDataAdapter(cmd)
                dtable = New DataTable()
                adp.Fill(dtable)
                ds = New DataSet()
                ds.Tables.Add(dtable)
                ds.WriteXmlSchema("CollectionByWaiter.xml")
                Dim rpt As New rptCollectionsByWaiter
                rpt.SetDataSource(ds)
                rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
                rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
                rpt.SetParameterValue("p3", cmbWaiterName.Text)
                frmReport.CrystalReportViewer1.ReportSource = rpt
                frmReport.ShowDialog()
                rpt.Close()
                rpt.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbOperatorID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbOperatorID.SelectedIndexChanged
        Try
            If cmbOperatorID.SelectedIndex >= 0 Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Operator from RestaurantPOS_BillingInfoKOT where BillDate >=@d1 and BillDate < @d2 and Operator=@d3 union select Operator from RestaurantPOS_BillingInfoTA where BillDate >=@d1 and BillDate < @d2 and Operator=@d3 and TA_Status <> 'Void' union select Operator from RestaurantPOS_BillingInfoHD where BillDate >=@d1 and BillDate < @d2 and Operator=@d3 and HD_Status <> 'Cancelled' Union select Operator from RestaurantPOS_BillingInfoEB where BillDate >=@d1 and BillDate < @d2 and Operator=@d3 and EB_Status <> 'Void'"
                cmd = New SqlCommand(ct)
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
                cmd.Parameters.AddWithValue("@d3", cmbOperatorID.Text)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If Not rdr.Read() Then
                    MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    Return
                End If
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select BillNo,BillDate,ODN,PaymentMode,GrandTotal from RestaurantPOS_BillingInfoKOT where BillDate >=@d1 and BillDate < @d2 and Operator=@d3 union Select BillNo,BillDate,ODN,PaymentMode,GrandTotal from RestaurantPOS_BillingInfoTA where BillDate >=@d1 and BillDate < @d2 and Operator=@d3 and TA_Status <> 'Void' union Select BillNo,BillDate,ODN,PaymentMode,GrandTotal from RestaurantPOS_BillingInfoHD where BillDate >=@d1 and BillDate < @d2 and Operator=@d3 and HD_Status <> 'Cancelled' Union Select BillNo,BillDate,ODN,PaymentMode,GrandTotal from RestaurantPOS_BillingInfoEB where BillDate >=@d1 and BillDate < @d2 and Operator=@d3 and EB_Status <> 'Void'", con)
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
                cmd.Parameters.AddWithValue("@d3", cmbOperatorID.Text)
                adp = New SqlDataAdapter(cmd)
                dtable = New DataTable()
                adp.Fill(dtable)
                ds = New DataSet()
                ds.Tables.Add(dtable)
                ds.WriteXmlSchema("CollectionByOperator.xml")
                Dim rpt As New rptCollectionsByOperatorID
                rpt.SetDataSource(ds)
                rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
                rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
                rpt.SetParameterValue("p3", cmbOperatorID.Text)
                frmReport.CrystalReportViewer1.ReportSource = rpt
                frmReport.ShowDialog()
                rpt.Close()
                rpt.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
