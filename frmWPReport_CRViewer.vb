Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Public Class frmWPReport_CRViewer
    Dim a, b, b1, b2, b3, b4, b5 As Double
    Private Sub txtEmailID_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailID.KeyPress
        Dim ac As String = "@"
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Asc(e.KeyChar) < 97 Or Asc(e.KeyChar) > 122 Then
                If Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 95 Then
                    If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                        If ac.IndexOf(e.KeyChar) = -1 Then
                            e.Handled = True

                        Else

                            If txtEmailID.Text.Contains("@") And e.KeyChar = "@" Then
                                e.Handled = True
                            End If

                        End If


                    End If
                End If
            End If

        End If
    End Sub

    Private Sub txtEmailID_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtEmailID.Validating
        Dim pattern As String = "^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"
        Dim match As System.Text.RegularExpressions.Match = Regex.Match(txtEmailID.Text.Trim(), pattern, RegexOptions.IgnoreCase)
        If (match.Success) Then
        Else
            MessageBox.Show("Please enter a valid email id", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtEmailID.Clear()
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnSendMail.Click
        Try
            If txtEmailID.Text = "" Then
                MessageBox.Show("Please enter Email ID", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmailID.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select count(*) from EmailSetting Having count(*) <=0"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                frmCustomDialog15.ShowDialog()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()
            If CheckForInternetConnection() = True Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn As String = "select RTRIM(Username),RTRIM(Password),RTRIM(SMTPAddress),(Port) from EmailSetting where IsDefault='Yes' and IsActive='Yes'"
                cmd = New SqlCommand(ctn)
                cmd.Connection = con
                Dim rdr1 As SqlDataReader
                rdr1 = cmd.ExecuteReader()
                If rdr1.Read() Then
                    Cursor = Cursors.WaitCursor
                    Timer1.Enabled = True
                    If (Not System.IO.Directory.Exists(Application.StartupPath & "\PDF Reports")) Then
                        System.IO.Directory.CreateDirectory(Application.StartupPath & "\PDF Reports")
                    End If
                    Dim pdfFile As String = Application.StartupPath & "\PDF Reports\WorkPeriodReport " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".Pdf"
                    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
                    Dim ds As DataSet
                    Dim adp, adp1, adp2, adp3, adp4, adp5 As SqlDataAdapter
                    Dim dtable, dtable1, dtable2, dtable3, dtable4, dtable5 As DataTable
                    Dim StartDate As DateTime = DateTime.ParseExact(cmbWorkPeriodStartTime.Text, "dd/MM/yyyy hh:mm:ss tt", Nothing)
                    Dim EndDate As DateTime = DateTime.ParseExact(cmbWorkPeriodEndTime.Text, "dd/MM/yyyy hh:mm:ss tt", Nothing)
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select Operator from RestaurantPOS_BillingInfoKOT where BillDate >=@d1 and BillDate < @d2 union select Operator from RestaurantPOS_BillingInfoTA where BillDate >=@d1 and BillDate < @d2 and TA_Status <> 'Void' union select Operator from RestaurantPOS_BillingInfoHD where BillDate >=@d1 and BillDate < @d2 and HD_Status <> 'Cancelled' Union select Operator from RestaurantPOS_BillingInfoEB where BillDate >=@d1 and BillDate < @d2 and EB_Status <> 'Void'"
                    cmd5 = New SqlCommand(ct)
                    cmd5.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = StartDate
                    cmd5.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = EndDate
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
                    cmd1.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = StartDate
                    cmd1.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = EndDate
                    adp1 = New SqlDataAdapter(cmd1)
                    cmd2 = New SqlCommand("SELECT Category,Sum(TotalAmount) as Total from (Select category,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillKOT, RestaurantPOS_BillingInfoKOT where RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID and BillDate >=@d3 and BillDate < @d4 UNION ALL Select category,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillTA, RestaurantPOS_BillingInfoTA where RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and BillDate >=@d3 and BillDate < @d4 and TA_Status <> 'Void' UNION ALL Select category,(TotalAmount) as [TotalAmount] from RestaurantPOS_OrderedProductBillHD, RestaurantPOS_BillingInfoHD where RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and BillDate >=@d3 and BillDate < @d4 and HD_Status <> 'Cancelled' Union all Select category,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillEB, RestaurantPOS_BillingInfoEB where RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID and BillDate >=@d3 and BillDate < @d4 and EB_Status <> 'Void')C group by Category order by 1", con)
                    cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "DateIN").Value = StartDate
                    cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "DateIN").Value = EndDate
                    adp2 = New SqlDataAdapter(cmd2)
                    cmd3 = New SqlCommand("SELECT Category,Sum(Quantity) as TotalQuantity from (Select category,Quantity from RestaurantPOS_OrderedProductBillKOT, RestaurantPOS_BillingInfoKOT where RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID and BillDate >=@d5 and BillDate < @d6 UNION ALL Select category,Quantity from RestaurantPOS_OrderedProductBillTA, RestaurantPOS_BillingInfoTA where RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and BillDate >=@d5 and BillDate < @d6 and TA_Status <> 'Void' UNION ALL Select category,Quantity from RestaurantPOS_OrderedProductBillHD, RestaurantPOS_BillingInfoHD where RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and BillDate >=@d5 and BillDate < @d6 and HD_Status <> 'Cancelled' Union all Select category,Quantity from RestaurantPOS_OrderedProductBillEB, RestaurantPOS_BillingInfoEB where RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID and BillDate >=@d5 and BillDate < @d6 and EB_Status <> 'Void')C group by Category order by 1", con)
                    cmd3.Parameters.Add("@d5", SqlDbType.DateTime, 30, "DateIN").Value = StartDate
                    cmd3.Parameters.Add("@d6", SqlDbType.DateTime, 30, "DateIN").Value = EndDate
                    adp3 = New SqlDataAdapter(cmd3)
                    cmd4 = New SqlCommand("SELECT Dish,Sum(Quantity) as [Quantity],Sum(TotalAmount) as [Amount] from (Select Dish,Quantity,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillKOT,RestaurantPOS_BillingInfoKOT where BillDate >=@d7 and BillDate < @d8 and RestaurantPOS_BillingInfoKOT.ID=RestaurantPOS_OrderedProductBillKOT.BillID Union All Select Dish,Quantity,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillTA,RestaurantPOS_BillingInfoTA where BillDate >=@d7 and BillDate < @d8 and RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and TA_Status <> 'Void' Union All Select Dish,Quantity,TotalAmount as [TotalAmount] from RestaurantPOS_OrderedProductBillHD,RestaurantPOS_BillingInfoHD where BillDate >=@d7 and BillDate < @d8 and RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and HD_Status <> 'Cancelled' Union all Select Dish,Quantity,(TotalAmount*ExchangeRate) as [TotalAmount] from RestaurantPOS_OrderedProductBillEB,RestaurantPOS_BillingInfoEB where BillDate >=@d7 and BillDate < @d8 and RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID and EB_Status <> 'Void')G  group by Dish order by 1", con)
                    cmd4.Parameters.Add("@d7", SqlDbType.DateTime, 30, "DateIN").Value = StartDate
                    cmd4.Parameters.Add("@d8", SqlDbType.DateTime, 30, "DateIN").Value = EndDate
                    adp4 = New SqlDataAdapter(cmd4)
                    cmd6 = New SqlCommand("SELECT PaymentMode,Sum(GrandTotal) as [GrandTotal] from (Select PaymentMode,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoKOT where BillDate >=@d11 and BillDate < @d12 Union All Select  PaymentMode,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoTA where BillDate >=@d11 and BillDate < @d12 and TA_Status <> 'Void' Union All Select  PaymentMode,GrandTotal as [GrandTotal] from RestaurantPOS_BillingInfoHD where BillDate >=@d11 and BillDate < @d12 and HD_Status <> 'Cancelled' Union all Select PaymentMode,(GrandTotal*ExchangeRate) as [GrandTotal] from RestaurantPOS_BillingInfoEB where BillDate >=@d11 and BillDate < @d12 and EB_Status <> 'Void')G  group by PaymentMode order by 1", con)
                    cmd6.Parameters.Add("@d11", SqlDbType.DateTime, 30, "DateIN").Value = StartDate
                    cmd6.Parameters.Add("@d12", SqlDbType.DateTime, 30, "DateIN").Value = EndDate
                    adp5 = New SqlDataAdapter(cmd6)
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct1 As String = "select IsNull(Sum(HomeDeliveryCharges),0) from RestaurantPOS_BillingInfoHD where BillDate >=@d9 and BillDate < @d10 and HD_Status <> 'Cancelled'"
                    cmd = New SqlCommand(ct1)
                    cmd.Parameters.Add("@d9", SqlDbType.DateTime, 30, "DateIN").Value = StartDate
                    cmd.Parameters.Add("@d10", SqlDbType.DateTime, 30, "DateIN").Value = EndDate
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
                    cmd.Parameters.Add("@d11", SqlDbType.DateTime, 30, "DateIN").Value = StartDate
                    cmd.Parameters.Add("@d12", SqlDbType.DateTime, 30, "DateIN").Value = EndDate
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
                    cmd.Parameters.Add("@d13", SqlDbType.DateTime, 30, "DateIN").Value = StartDate
                    cmd.Parameters.Add("@d14", SqlDbType.DateTime, 30, "DateIN").Value = EndDate
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
                    cmd.Parameters.Add("@d13", SqlDbType.DateTime, 30, "DateIN").Value = StartDate
                    cmd.Parameters.Add("@d14", SqlDbType.DateTime, 30, "DateIN").Value = EndDate
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
                    cmd.Parameters.Add("@d13", SqlDbType.DateTime, 30, "DateIN").Value = StartDate
                    cmd.Parameters.Add("@d14", SqlDbType.DateTime, 30, "DateIN").Value = EndDate
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
                    cmd.Parameters.Add("@d13", SqlDbType.DateTime, 30, "DateIN").Value = StartDate
                    cmd.Parameters.Add("@d14", SqlDbType.DateTime, 30, "DateIN").Value = EndDate
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
                    cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "DateIN").Value = StartDate
                    cmd.Parameters.Add("@d4", SqlDbType.DateTime, 30, "DateIN").Value = EndDate
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
                    Dim rpt As New rptWorkPeriod
                    rpt.Subreports(0).SetDataSource(ds)
                    rpt.Subreports(1).SetDataSource(ds)
                    rpt.Subreports(2).SetDataSource(ds)
                    rpt.Subreports(3).SetDataSource(ds)
                    rpt.Subreports(4).SetDataSource(ds)
                    rpt.Subreports(5).SetDataSource(ds)
                    rpt.SetDataSource(ds)
                    rpt.SetParameterValue("p1", StartDate)
                    rpt.SetParameterValue("p2", EndDate)
                    rpt.SetParameterValue("p3", a)
                    rpt.SetParameterValue("p4", b)
                    rpt.SetParameterValue("p5", a)
                    rpt.SetParameterValue("p6", b)
                    rpt.SetParameterValue("b1", b1)
                    rpt.SetParameterValue("b2", b2)
                    rpt.SetParameterValue("b3", b3)
                    rpt.SetParameterValue("b4", b4)
                    rpt.SetParameterValue("b5", b5)
                    rpt.ExportToDisk(ExportFormatType.PortableDocFormat, pdfFile)
                    SendMail1(rdr1.GetValue(0), txtEmailID.Text, "Please find the attachment below", pdfFile, "Work Period Report", rdr1.GetValue(2), rdr1.GetValue(3), rdr1.GetValue(0), Decrypt(rdr1.GetValue(1)))
                    If (rdr1 IsNot Nothing) Then
                        rdr1.Close()
                    End If
                    rpt.Close()
                    rpt.Dispose()
                    MessageBox.Show("Successfully send", "Mail", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub


End Class
