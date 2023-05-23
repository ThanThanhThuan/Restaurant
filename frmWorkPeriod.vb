Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.SqlServer.Management.Smo
Public Class frmWorkPeriod
    Dim Filename As String
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Dim a, b, b1, b2, b3, b4, b5 As Double
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
        frmFrontOffice.lblUserType.Text = lblUserType.Text
        frmFrontOffice.lblUser.Text = lblUser.Text
        frmFrontOffice.Show()
    End Sub

    Private Sub btnStartWP_Click(sender As System.Object, e As System.EventArgs) Handles btnStartWP.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "Update WorkPeriodStart set Status='Inactive'"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into WorkPeriodStart(WPStart,Status) VALUES (@d1,'Active')"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", System.DateTime.Now)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            frmCustomDialog1.ShowDialog()
            GetData()
            FillDataGridview()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT ID,WPStart from WorkPeriodStart where Status='Active'"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                lblTotalWorkTime.Visible = True
                lblTotalWT.Visible = True
                lblWorkPeriodDate.Visible = True
                lblWPDate.Visible = True
                txtID.Text = rdr.GetValue(0)
                lblWorkPeriodDate.Text = rdr.GetDateTime(1).ToString("dd/MM/yyyy hh:mm:ss tt")
                btnStartWP.Enabled = False
            Else
                lblTotalWorkTime.Visible = False
                lblTotalWT.Visible = False
                lblWorkPeriodDate.Visible = False
                lblWPDate.Visible = False
                btnStartWP.Enabled = True
                btnEndWP.Enabled = False
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub frmWorkPeriod_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetData()
        FillDataGridview()
        dgw.ClearSelection()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        con = New SqlConnection(cs)
        con.Open()
        Dim ct As String = "SELECT WPStart from WorkPeriodStart where Status='Active'"
        cmd = New SqlCommand(ct)
        cmd.Connection = con
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            Dim startDate As DateTime = DateTime.Now
            Dim endDate As DateTime = rdr.GetDateTime(0)
            Dim timeSpan As TimeSpan = startDate.Subtract(endDate)
            Dim difDays As Integer = timeSpan.Days
            Dim difHr As Integer = timeSpan.Hours
            Dim difMin As Integer = timeSpan.Minutes
            If difDays > 0 And difHr > 0 And difMin > 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays > 0 And difHr = 0 And difMin = 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays > 0 And difHr > 0 And difMin = 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays = 0 And difHr = 0 And difMin > 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays = 0 And difHr > 0 And difMin = 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays = 0 And difHr > 0 And difMin > 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays > 0 And difHr = 0 And difMin > 0 Then
                btnEndWP.Enabled = True
            End If
            If difDays = 0 And difHr = 0 And difMin >= 0 Then
                If difMin <= 1 Then
                    lblTotalWorkTime.Text = difMin & " " & "Minute"
                Else
                    lblTotalWorkTime.Text = difMin & " " & "Minutes"
                End If
            End If
            If difDays = 0 And difHr > 0 And difMin >= 0 Then
                If difHr <= 1 And difMin <= 1 Then
                    lblTotalWorkTime.Text = difHr & " " & "Hour" & " " & difMin & " " & "Minute"
                ElseIf difHr <= 1 And difMin >= 1 Then
                    lblTotalWorkTime.Text = difHr & " " & "Hour" & " " & difMin & " " & "Minutes"
                ElseIf difHr > 1 And difMin <= 1 Then
                    lblTotalWorkTime.Text = difHr & " " & "Hours" & " " & difMin & " " & "Minute"
                ElseIf difHr > 1 And difMin > 1 Then
                    lblTotalWorkTime.Text = difHr & " " & "Hours" & " " & difMin & " " & "Minutes"
                End If
            End If
            If difDays > 0 And difHr >= 0 And difMin >= 0 Then
                If difDays <= 1 And difHr <= 1 And difMin <= 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Day" & " " & difHr & " " & "Hour" & " " & difMin & " " & "Minute"
                ElseIf difDays > 1 And difHr > 1 And difMin > 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Days" & " " & difHr & " " & "Hours" & " " & difMin & " " & "Minutes"
                ElseIf difDays > 1 And difHr <= 1 And difMin <= 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Days" & " " & difHr & " " & "Hour" & " " & difMin & " " & "Minute"
                ElseIf difDays > 1 And difHr > 1 And difMin <= 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Days" & " " & difHr & " " & "Hours" & " " & difMin & " " & "Minute"
                ElseIf difDays <= 1 And difHr <= 1 And difMin > 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Day" & " " & difHr & " " & "Hour" & " " & difMin & " " & "Minutes"
                ElseIf difDays <= 1 And difHr > 1 And difMin <= 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Day" & " " & difHr & " " & "Hours" & " " & difMin & " " & "Minute"
                ElseIf difDays > 1 And difHr <= 1 And difMin > 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Days" & " " & difHr & " " & "Hour" & " " & difMin & " " & "Minutes"
                ElseIf difDays <= 1 And difHr > 1 And difMin > 1 Then
                    lblTotalWorkTime.Text = difDays & " " & "Day" & " " & difHr & " " & "Hours" & " " & difMin & " " & "Minutes"
                End If
            End If
        End If
        con.Close()
    End Sub
    Sub FillDataGridview()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT * from WorkPeriodStart"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                dgw.Enabled = False
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT WPStart,WPEnd from WorkPeriodStart left join WorkPeriodEnd On WorkperiodStart.ID=WorkPeriodEnd.ID  order by WPStart", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1))
            End While
            con.Close()
            dgw.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEndWP_Click(sender As System.Object, e As System.EventArgs) Handles btnEndWP.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT * from RestaurantPOS_OrderInfoKOT where KOT_Status in ('Open','Prepared','Served')"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                frmCustomDialog4.ShowDialog()
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into WorkPeriodEnd(ID,WPEnd) VALUES (" & Val(txtID.Text) & ",@d1)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", System.DateTime.Now)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "Update WorkPeriodStart set Status='Inactive'"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "Delete from tblOrder"
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb3 As String = "Update RestaurantPOS_BillingInfoTA set TA_Status='Closed' where TA_Status='Paid'"
            cmd = New SqlCommand(cb3)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb4 As String = "Update RestaurantPOS_BillingInfoHD set HD_Status='Delivered' where HD_Status <> 'Cancelled'"
            cmd = New SqlCommand(cb4)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb5 As String = "Update RestaurantPOS_BillingInfoEB set EB_Status='Closed' where EB_Status <> 'Void'"
            cmd = New SqlCommand(cb5)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            frmCustomDialog2.ShowDialog()
            GetData()
            FillDataGridview()
            con = New SqlConnection(cs)
            con.Open()
            Dim ctz As String = "SELECT top 1 WpStart,WpEnd FROM WorkPeriodStart,WorkPeriodEnd where WorkPeriodStart.ID=WorkPeriodEnd.ID order by WorkPeriodStart.ID desc"
            cmd = New SqlCommand(ctz)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                Cursor = Cursors.WaitCursor
                Timer3.Enabled = True
                Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
                Dim ds As DataSet
                Dim adp, adp1, adp2, adp3, adp4, adp5 As SqlDataAdapter
                Dim dtable, dtable1, dtable2, dtable3, dtable4, dtable5 As DataTable
                Dim StartDate As DateTime = rdr.GetDateTime(0)
                Dim EndDate As DateTime = rdr.GetDateTime(1)
                con = New SqlConnection(cs)
                con.Open()
                Dim ctc As String = "select Operator from RestaurantPOS_BillingInfoKOT where BillDate >=@d1 and BillDate < @d2 union select Operator from RestaurantPOS_BillingInfoTA where BillDate >=@d1 and BillDate < @d2 and TA_Status <> 'Void' union select Operator from RestaurantPOS_BillingInfoHD where BillDate >=@d1 and BillDate < @d2 and HD_Status <> 'Cancelled' Union select Operator from RestaurantPOS_BillingInfoEB where BillDate >=@d1 and BillDate < @d2 and EB_Status <> 'Void'"
                cmd5 = New SqlCommand(ctc)
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
                frmWPReport_CRViewer.CrystalReportViewer1.ReportSource = rpt
                frmWPReport_CRViewer.cmbWorkPeriodStartTime.Text = StartDate
                frmWPReport_CRViewer.cmbWorkPeriodEndTime.Text = EndDate
                frmWPReport_CRViewer.txtEmailID.Text = ""
                frmWPReport_CRViewer.ShowDialog()
                rpt.Close()
                rpt.Dispose()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        Cursor = Cursors.Default
        Timer3.Enabled = False
    End Sub

End Class