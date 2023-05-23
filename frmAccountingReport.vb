Imports System.Data.SqlClient

Public Class frmAccountingReport
    Dim a As Decimal
    Dim d, b, c As String
    Sub Reset()
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today
        DateTimePicker3.Value = Today
        cmbSupplierName.Text = ""
    End Sub
    Sub fillSupplier()
        Try
            con = New SqlConnection(cs)
            con.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT RTRIM(Name) FROM Supplier", con)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbSupplierName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbSupplierName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPurchaseDaybook.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctx As String = "select * from Purchase where Date Between @d2 and @d3 and PurchaseType='Credit'"
            cmd = New SqlCommand(ctx)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
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
            cmd = New SqlCommand("SELECT ST_ID,Date,InvoiceNo,Name,SubTotal,Discount,FreightCharges,OtherCharges,PreviousDue,GrandTotal from Supplier,Purchase where Supplier.ID=Purchase.Supplier_ID and PurchaseType='Credit' order by [Date]", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("PurchaseDayBook.xml")
            Dim rpt As New rptPurchaseDayBook
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles txtCashBook.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select PartyID from LedgerBook where Name='Cash' and Date >=@d2 and Date < @d3"
            cmd = New SqlCommand(ct)
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
            'cmd = New SqlCommand("Select Date, LedgerNo, Label, Credit, Debit,AccLedger,Name from LedgerBook where Date >=@d1 and Date < @d2 and Name='Cash' order by ID,Date,LedgerNo", con)
            cmd = New SqlCommand("Select section as [STPer], convert(nvarchar, Date, 103) as [BillID], LedgerNo as [Quantity], Label as [Category], Credit as [TotalAmount], Debit as [VATPer],AccLedger,Name as [Dish] from LedgerBook where Date >=@d1 and Date < @d2 and Name='Cash' order by ID,Date,LedgerNo", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("LedgerBookNew.xml")
            'Dim rpt As New rptCashBook
            'rpt.SetDataSource(ds)
            'rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            'rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            'frmReport.CrystalReportViewer1.ReportSource = rpt
            'frmReport.ShowDialog()
            'rpt.Close()
            'rpt.Dispose()
            Dim cashBook As New frmCashBook()
            cashBook.GetValue(ds.Tables(0), ("From: " & dtpDateFrom.Value.ToString("dd/MM/yyyy") & " To " & dtpDateTo.Value.ToString("dd/MM/yyyy")))
            cashBook.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSupplierLedger_Click(sender As System.Object, e As System.EventArgs) Handles btnSupplierLedger.Click
        Try
            If Len(Trim(cmbSupplierName.Text)) = 0 Then
                MessageBox.Show("Please Select Supplier Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbSupplierName.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select PartyID from LedgerBook where PartyID=@d3 and Date >=@d1 and Date < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d3", txtSupplierID.Text)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker3.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date.AddDays(1)
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
            cmd = New SqlCommand("Select Date, Name, LedgerNo, Label, Credit, Debit from LedgerBook where Date >=@d1 and Date < @d2 and PartyID=@d3 order by ID,Date,LedgerNo", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker3.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date.AddDays(1)
            cmd.Parameters.AddWithValue("@d3", txtSupplierID.Text)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("SupplierLedger.xml")
            Dim rpt As New rptSupplierLedger
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", DateTimePicker3.Value.Date)
            rpt.SetParameterValue("p2", DateTimePicker2.Value.Date)
            rpt.SetParameterValue("p3", txtSupplierID.Text)
            rpt.SetParameterValue("p4", cmbSupplierName.Text)
            rpt.SetParameterValue("p5", d)
            rpt.SetParameterValue("p6", b)
            rpt.SetParameterValue("p7", c)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTrialBalance_Click(sender As System.Object, e As System.EventArgs) Handles btnTrialBalance.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from LedgerBook where Date >=@d1 and Date < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
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
            cmd = New SqlCommand("Select Name,CASE WHEN (Sum(Debit)-Sum(Credit))<= 0 THEN 0 ELSE (Sum(Debit)-Sum(Credit)) END AS Debit,CASE WHEN (Sum(Credit)-Sum(Debit))<= 0 THEN 0 ELSE (Sum(Credit)-Sum(debit)) END AS Credit from LedgerBook where Date >=@d1 and Date < @d2 Group By Name having (Sum(Credit)-Sum(Debit)) <> 0 order by Name", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("TrialBalanceAccounting.xml")
            Dim rpt As New rptTrialBalance
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPurchase_Click(sender As System.Object, e As System.EventArgs) Handles btnPurchase.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from Purchase where Date Between @d2 and @d3"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
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
            Dim rpt As New rptPurchase 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT HST,HSTPer, Supplier.ID, Supplier.SupplierID, Supplier.Name, Supplier.Address, Supplier.City, Supplier.State, Supplier.ZipCode, Supplier.ContactNo, Supplier.EmailID, Supplier.Remarks, Purchase.ST_ID, Purchase.InvoiceNo,Purchase.Date,Purchase.Supplier_ID, Purchase.PurchaseType, Purchase.SubTotal, Purchase.DiscountPer, Purchase.Discount, Purchase.PreviousDue, Purchase.FreightCharges, Purchase.OtherCharges, Purchase.Total, Purchase.RoundOff, Purchase.GrandTotal, Purchase.TotalPayment, Purchase.PaymentDue, Purchase_Join.SP_ID, Purchase_Join.PurchaseID, Purchase_Join.ProductID, Purchase_Join.Qty, Purchase_Join.HasExpiryDate,ExpiryDate, Purchase_Join.Price, Purchase_Join.TotalAmount, Product.PID, Product.ProductCode,Product.Unit, Product.ProductName, Product.Category,Product.Description FROM Supplier INNER JOIN Purchase ON Supplier.ID = Purchase.Supplier_ID INNER JOIN Purchase_Join ON Purchase.ST_ID = Purchase_Join.PurchaseID INNER JOIN Product ON Purchase_Join.ProductID = Product.PID where Purchase.date between @d1 and @d2 order by Purchase.Date"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Supplier")
            myDA.Fill(myDS, "Purchase")
            myDA.Fill(myDS, "Purchase_Join")
            myDA.Fill(myDS, "Product")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("P1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("P2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnVouchers_Click(sender As System.Object, e As System.EventArgs) Handles btnVouchers.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from Voucher where Date Between @d2 and @d3"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
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
            Dim rpt As New rptExpenses 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "SELECT Voucher.ID, Voucher.VoucherNo, Voucher.Date, Voucher.Name, Voucher.Details, Voucher.GrandTotal, Voucher_OtherDetails.VD_ID, Voucher_OtherDetails.VoucherID,Voucher_OtherDetails.Particulars, Voucher_OtherDetails.Amount, Voucher_OtherDetails.Note FROM Voucher INNER JOIN Voucher_OtherDetails ON Voucher.ID = Voucher_OtherDetails.VoucherID  where date between @d1 and @d2 order by date"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "Voucher")
            myDA.Fill(myDS, "Voucher_OtherDetails")
            con = New SqlConnection(cs)
            con.Open()
            Dim ctx As String = "select ISNULL(sum(GrandTotal),0) from Voucher where Date between @d1 and @d2"
            cmd = New SqlCommand(ctx)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                a = rdr.GetValue(0)
            End While
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            rpt.SetParameterValue("p4", Today)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbSupplierName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbSupplierName.SelectedIndexChanged
        Try
            d = ""
            b = ""
            c = ""
            txtSupplierID.Text = ""
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(SupplierID),RTRIM(Address),RTRIM(City),RTRIM(ContactNo) FROM Supplier WHERE Name=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbSupplierName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtSupplierID.Text = rdr.GetValue(0)
                d = rdr.GetValue(1)
                b = rdr.GetValue(2)
                c = rdr.GetValue(3)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnGeneralDaybook_Click(sender As System.Object, e As System.EventArgs) Handles btnGeneralDaybook.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from LedgerBook where Date between @d1 and @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
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
            cmd = New SqlCommand("Select Date, Name, LedgerNo, Label, Credit, Debit from LedgerBook where Date between @d1 and @d2 order by ID,LedgerNo", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("GeneralDayBook.xml")
            Dim rpt As New rptGeneralDayBook
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", DateTimePicker1.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmAccountingReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fillSupplier()
    End Sub

    Private Sub btnCreditors_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditors.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Supplier.SupplierID, Supplier.Name,Supplier.City,Supplier.ContactNo,IsNull(Sum(Credit)-Sum(Debit),0) FROM Supplier,LedgerBook where Supplier.SupplierID=LedgerBook.PartyID group by Supplier.SupplierID, Supplier.Name,Supplier.ContactNo,Supplier.City having (sum(Credit)- sum(Debit) > 0 ) ORDER BY Supplier.Name", con)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("Creditors.xml")
            Dim rpt As New rptCreditors
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", Today)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnStockIN_Click(sender As System.Object, e As System.EventArgs) Handles btnStockIN.Click
        frmStockInRecord.Reset()
        frmStockInRecord.ShowDialog()
    End Sub

    Private Sub btnStockOut_Click(sender As System.Object, e As System.EventArgs) Handles btnStockOut.Click
        frmStockOUTRecord.Reset()
        frmStockOUTRecord.ShowDialog()
    End Sub

    Private Sub btnLowStock_Click(sender As System.Object, e As System.EventArgs) Handles btnLowStock.Click
        frmLowStockRecord.Reset()
        frmLowStockRecord.ShowDialog()
    End Sub

    Private Sub btnExpiredProducts_Click(sender As System.Object, e As System.EventArgs) Handles btnExpiredProducts.Click
        frmExpiredProductsRecord.Reset()
        frmExpiredProductsRecord.ShowDialog()
    End Sub

    Private Sub btnStockTransfer_Click(sender As System.Object, e As System.EventArgs) Handles btnStockTransfer.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from StockTransfer where Date Between @d2 and @d3"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
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
            Dim rpt As New rptStockTransfer 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT StockTransfer.ST_ID, StockTransfer.Date, StockTransfer.kitchen, StockTransfer_Join.STJ_ID, StockTransfer_Join.StockTransferID, StockTransfer_Join.Warehouse, StockTransfer_Join.ProductID,StockTransfer_Join.ExpiryDate, StockTransfer_Join.Qty, Product.PID, Product.ProductCode, Product.ProductName, Product.Category, Product.Description, Product.Unit, Product.Price, Product.ReorderPoint FROM StockTransfer INNER JOIN StockTransfer_Join ON StockTransfer.ST_ID = StockTransfer_Join.StockTransferID INNER JOIN Product ON StockTransfer_Join.ProductID = Product.PID where StockTransfer.date between @d1 and @d2 order by StockTransfer.Date"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "StockTransfer")
            myDA.Fill(myDS, "StockTransfer_Join")
            myDA.Fill(myDS, "Product")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("P1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("P2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnStoreStockIN_Click(sender As System.Object, e As System.EventArgs) Handles btnStoreStockIN.Click
        frmStockIn_StoreRecord.Reset()
        frmStockIn_StoreRecord.ShowDialog()
    End Sub

    Private Sub btnStoreStockOUT_Click(sender As System.Object, e As System.EventArgs) Handles btnStoreStockOUT.Click
        frmStockOUT_StoreRecord.Reset()
        frmStockOUT_StoreRecord.ShowDialog()
    End Sub

    Private Sub btnStockIn_RM_Click(sender As System.Object, e As System.EventArgs) Handles btnStockIn_RM.Click
        frmStockIn_RM.Reset()
        frmStockIn_RM.ShowDialog()
    End Sub

    Private Sub btnStockOut_RM_Click(sender As System.Object, e As System.EventArgs) Handles btnStockOut_RM.Click
        frmStockOUT_RM.Reset()
        frmStockOUT_RM.ShowDialog()
    End Sub

    Private Sub btnTip_Click(sender As System.Object, e As System.EventArgs) Handles btnTip.Click
        frmTipRecord.Reset()
        frmTipRecord.ShowDialog()
    End Sub

    Private Sub btnCollectionsByDP_Click(sender As System.Object, e As System.EventArgs) Handles btnCollectionsByDP.Click
        frmDeliveryPersonLedger.Reset()
        frmDeliveryPersonLedger.ShowDialog()
    End Sub

    Private Sub btnTaxReport_Click(sender As System.Object, e As System.EventArgs) Handles btnTaxReport.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim cmd, cmd1 As SqlCommand
            Dim ds As DataSet
            Dim adp, adp1 As SqlDataAdapter
            Dim dtable, dtable1 As DataTable
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT RestaurantPOS_BillingInfoKOT.BillNo, RestaurantPOS_BillingInfoKOT.BillDate, RestaurantPOS_BillingInfoKOT.PaymentMode, RestaurantPOS_BillingInfoKOT.Operator,SUM(VATPer)/Count(OP_ID), SUM(RestaurantPOS_OrderedProductBillKOT.VATAmount),RestaurantPOS_BillingInfoKOT.GrandTotal FROM RestaurantPOS_BillingInfoKOT INNER JOIN RestaurantPOS_OrderedProductBillKOT ON RestaurantPOS_BillingInfoKOT.Id = RestaurantPOS_OrderedProductBillKOT.BillID Where BillDate >=@d1 and BillDate < @d2 group by RestaurantPOS_BillingInfoKOT.BillNo, RestaurantPOS_BillingInfoKOT.BillDate, RestaurantPOS_BillingInfoKOT.PaymentMode, RestaurantPOS_BillingInfoKOT.Operator,RestaurantPOS_BillingInfoKOT.GrandTotal UNION SELECT RestaurantPOS_BillingInfoTA.BillNo, RestaurantPOS_BillingInfoTA.BillDate, RestaurantPOS_BillingInfoTA.PaymentMode, RestaurantPOS_BillingInfoTA.Operator,SUM(VATPer)/Count(OP_ID), SUM(RestaurantPOS_OrderedProductBillTA.VATAmount),RestaurantPOS_BillingInfoTA.GrandTotal FROM RestaurantPOS_BillingInfoTA INNER JOIN RestaurantPOS_OrderedProductBillTA ON RestaurantPOS_BillingInfoTA.Id = RestaurantPOS_OrderedProductBillTA.BillID Where BillDate >=@d1 and BillDate < @d2 and TA_Status <> 'Void' group by RestaurantPOS_BillingInfoTA.BillNo, RestaurantPOS_BillingInfoTA.BillDate, RestaurantPOS_BillingInfoTA.PaymentMode, RestaurantPOS_BillingInfoTA.Operator,RestaurantPOS_BillingInfoTA.GrandTotal UNION SELECT RestaurantPOS_BillingInfoHD.BillNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.PaymentMode, RestaurantPOS_BillingInfoHD.Operator,SUM(VATPer)/Count(OP_ID), SUM(RestaurantPOS_OrderedProductBillHD.VATAmount),RestaurantPOS_BillingInfoHD.GrandTotal FROM RestaurantPOS_BillingInfoHD INNER JOIN RestaurantPOS_OrderedProductBillHD ON RestaurantPOS_BillingInfoHD.Id = RestaurantPOS_OrderedProductBillHD.BillID Where BillDate >=@d1 and BillDate < @d2 and HD_Status <> 'Cancelled' group by RestaurantPOS_BillingInfoHD.BillNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.PaymentMode, RestaurantPOS_BillingInfoHD.Operator,RestaurantPOS_BillingInfoHD.GrandTotal UNION SELECT RestaurantPOS_BillingInfoEB.BillNo, RestaurantPOS_BillingInfoEB.BillDate, RestaurantPOS_BillingInfoEB.PaymentMode, RestaurantPOS_BillingInfoEB.Operator,SUM(VATPer)/Count(OP_ID), SUM(RestaurantPOS_OrderedProductBillEB.VATAmount),RestaurantPOS_BillingInfoEB.GrandTotal FROM RestaurantPOS_BillingInfoEB INNER JOIN RestaurantPOS_OrderedProductBillEB ON RestaurantPOS_BillingInfoEB.Id = RestaurantPOS_OrderedProductBillEB.BillID Where BillDate >=@d1 and BillDate < @d2 and EB_Status <> 'Void' group by RestaurantPOS_BillingInfoEB.BillNo, RestaurantPOS_BillingInfoEB.BillDate, RestaurantPOS_BillingInfoEB.PaymentMode, RestaurantPOS_BillingInfoEB.Operator, RestaurantPOS_BillingInfoEB.GrandTotal order by 2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RestaurantPOS_BillingInfoKOT.BillNo, RestaurantPOS_BillingInfoKOT.BillDate, RestaurantPOS_BillingInfoKOT.PaymentMode, RestaurantPOS_BillingInfoKOT.Operator,SUM(VATPer)/Count(OP_ID), SUM(RestaurantPOS_OrderedProductBillKOT.VATAmount),RestaurantPOS_BillingInfoKOT.GrandTotal FROM RestaurantPOS_BillingInfoKOT INNER JOIN RestaurantPOS_OrderedProductBillKOT ON RestaurantPOS_BillingInfoKOT.Id = RestaurantPOS_OrderedProductBillKOT.BillID Where BillDate >=@d1 and BillDate < @d2 group by RestaurantPOS_BillingInfoKOT.BillNo, RestaurantPOS_BillingInfoKOT.BillDate, RestaurantPOS_BillingInfoKOT.PaymentMode, RestaurantPOS_BillingInfoKOT.Operator,RestaurantPOS_BillingInfoKOT.GrandTotal UNION SELECT RestaurantPOS_BillingInfoTA.BillNo, RestaurantPOS_BillingInfoTA.BillDate, RestaurantPOS_BillingInfoTA.PaymentMode, RestaurantPOS_BillingInfoTA.Operator,SUM(VATPer)/Count(OP_ID), SUM(RestaurantPOS_OrderedProductBillTA.VATAmount),RestaurantPOS_BillingInfoTA.GrandTotal FROM RestaurantPOS_BillingInfoTA INNER JOIN RestaurantPOS_OrderedProductBillTA ON RestaurantPOS_BillingInfoTA.Id = RestaurantPOS_OrderedProductBillTA.BillID Where BillDate >=@d1 and BillDate < @d2 and TA_Status <> 'Void' group by RestaurantPOS_BillingInfoTA.BillNo, RestaurantPOS_BillingInfoTA.BillDate, RestaurantPOS_BillingInfoTA.PaymentMode, RestaurantPOS_BillingInfoTA.Operator,RestaurantPOS_BillingInfoTA.GrandTotal UNION SELECT RestaurantPOS_BillingInfoHD.BillNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.PaymentMode, RestaurantPOS_BillingInfoHD.Operator,SUM(VATPer)/Count(OP_ID), SUM(RestaurantPOS_OrderedProductBillHD.VATAmount),RestaurantPOS_BillingInfoHD.GrandTotal FROM RestaurantPOS_BillingInfoHD INNER JOIN RestaurantPOS_OrderedProductBillHD ON RestaurantPOS_BillingInfoHD.Id = RestaurantPOS_OrderedProductBillHD.BillID Where BillDate >=@d1 and BillDate < @d2 and HD_Status <> 'Cancelled' group by RestaurantPOS_BillingInfoHD.BillNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.PaymentMode, RestaurantPOS_BillingInfoHD.Operator,RestaurantPOS_BillingInfoHD.GrandTotal UNION SELECT RestaurantPOS_BillingInfoEB.BillNo, RestaurantPOS_BillingInfoEB.BillDate, RestaurantPOS_BillingInfoEB.PaymentMode, RestaurantPOS_BillingInfoEB.Operator,SUM(VATPer)/Count(OP_ID), SUM(RestaurantPOS_OrderedProductBillEB.VATAmount),RestaurantPOS_BillingInfoEB.GrandTotal FROM RestaurantPOS_BillingInfoEB INNER JOIN RestaurantPOS_OrderedProductBillEB ON RestaurantPOS_BillingInfoEB.Id = RestaurantPOS_OrderedProductBillEB.BillID Where BillDate >=@d1 and BillDate < @d2 and EB_Status <> 'Void' group by RestaurantPOS_BillingInfoEB.BillNo, RestaurantPOS_BillingInfoEB.BillDate, RestaurantPOS_BillingInfoEB.PaymentMode, RestaurantPOS_BillingInfoEB.Operator, RestaurantPOS_BillingInfoEB.GrandTotal order by 2", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            cmd1 = New SqlCommand("Select * from Hotel", con)
            adp1 = New SqlDataAdapter(cmd1)
            dtable = New DataTable()
            dtable1 = New DataTable()
            adp.Fill(dtable)
            adp1.Fill(dtable1)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.Tables.Add(dtable1)
            ds.WriteXmlSchema("OutputTax.xml")
            Dim rpt As New rptTax
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Dispose()
            rpt.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGeneralLedger_Click(sender As System.Object, e As System.EventArgs) Handles btnGeneralLedger.Click
        frmGeneralLedger.Reset()
        frmGeneralLedger.ShowDialog()
    End Sub

    Private Sub btnStockUsed_Click(sender As System.Object, e As System.EventArgs) Handles btnStockUsed.Click
        frmRawMaterialsUsed.Reset()
        frmRawMaterialsUsed.ShowDialog()
    End Sub

    Private Sub btnInputTax_Click(sender As System.Object, e As System.EventArgs) Handles btnInputTax.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim cmd, cmd2 As SqlCommand
            Dim ds As DataSet
            Dim adp, adp2 As SqlDataAdapter
            Dim dtable, dtable2 As DataTable
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT * from Purchase where Date > = @d1 and Date < @d2 and (HST) > 0"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Purchase.InvoiceNo, Purchase.Date, Supplier.Name, Supplier.TIN, Purchase.HSTPer, Purchase.HST, Purchase.GrandTotal FROM Purchase INNER JOIN Supplier ON Purchase.Supplier_ID = Supplier.ID where (HST) > 0 and Date > = @d1 and Date < @d2 order by Date", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            cmd2 = New SqlCommand("Select * from Hotel", con)
            adp2 = New SqlDataAdapter(cmd2)
            dtable = New DataTable()
            dtable2 = New DataTable()
            adp.Fill(dtable)
            adp2.Fill(dtable2)
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.Tables.Add(dtable2)
            ds.WriteXmlSchema("InputTaxReport.xml")
            Dim rpt As New rptInputTax
            rpt.Subreports(0).SetDataSource(ds)
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Dispose()
            rpt.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnJournalEntry_Click(sender As System.Object, e As System.EventArgs) Handles btnJournalEntry.Click
        frmJournalEntries.Reset()
        frmJournalEntries.lblUser.Text = lblUser.Text
        frmJournalEntries.ShowDialog()
    End Sub

    Private Sub btnBalanceSheet_Click(sender As System.Object, e As System.EventArgs) Handles btnBalanceSheet.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "Select * FROM LedgerBook where Date >=@d1 and Date < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT distinct Name, (Sum(Debit) - Sum(Credit)) as Debit from LedgerBook where Date >=@d1 and Date < @d2 group by Name having ((Sum(Debit) - Sum(Credit)) > 0) order by 1", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd1 = New SqlCommand("SELECT distinct Name as NameX, (Sum(Credit) - Sum(Debit)) as Credit from LedgerBook where Date >=@d1 and Date < @d2 group by Name having ((Sum(Credit) - Sum(Debit)) > 0) order by 1", con)
            cmd1.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd1.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            adp1 = New SqlDataAdapter(cmd1)
            dtable = New DataTable()
            adp.Fill(dtable)
            adp1.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("BalanceSheetTestX.xml")
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "Select IsNULL(Sum(Price*Qty),0) FROM Temp_Stock,Product where Product.PID=Temp_Stock.ProductID"
            cmd = New SqlCommand(ct1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                a = rdr.GetValue(0)
            Else
                a = 0
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct2 As String = "Select IsNULL(Sum(Price*Qty),0) FROM Temp_Stock_RM,Product where Product.PID=Temp_Stock_RM.ProductID"
            cmd = New SqlCommand(ct2)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                b = rdr.GetValue(0)
            Else
                b = 0
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct3 As String = "Select IsNULL(Sum(DIRate*Qty),0) FROM Temp_Stock_Store,Dish where Dish.DishName=Temp_Stock_Store.Dish"
            cmd = New SqlCommand(ct3)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                c = rdr.GetValue(0)
            Else
                c = 0
            End If
            con.Close()
            Dim rpt As New rptBalanceSheet
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            rpt.SetParameterValue("p4", b)
            rpt.SetParameterValue("p5", c)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
