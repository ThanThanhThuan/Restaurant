Imports System.Data.SqlClient

Public Class frmRestaurantPOSTARecord
    Sub fillBillNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillNo) FROM RestaurantPOS_BillingInfoTA order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbBillNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbBillNo.Items.Add(drow(0).ToString())
            Next
            CN.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoTA.Id), RTRIM(BillNo),BillDate,TADiscountPer,TADiscountAmt,SubTotal,ParcelCharges,(RestaurantPOS_BillingInfoTA.GrandTotal),Cash,Change,RTRIM(PaymentMode),RTRIM(Operator),RTRIM(CurrencyCode),ExchangeRate,RTRIM(Member_ID),RTRIM(PhoneNo),RTRIM(TA_Status) from RestaurantPOS_BillingInfoTA where (DATEDIFF(d,BillDate,GetDate())= 0) Order by BillDate Desc"
            cmd = New SqlCommand(sql, con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillBillNo()
    End Sub
    Sub Reset()
        cmbBillNo.Text = ""
        txtContactNo.Text = ""
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try

            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmPOS.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmPOS.txtBillID1.Text = dr.Cells(0).Value.ToString()
                frmPOS.lblBillNo1.Text = dr.Cells(1).Value.ToString()
                frmPOS.txtTADiscountPer.Text = dr.Cells(3).Value.ToString()
                frmPOS.txtTADiscountAmount.Text = dr.Cells(4).Value.ToString()
                frmPOS.txtParcelCharges.Text = dr.Cells(6).Value.ToString()
                frmPOS.txtGrandTotal1.Text = dr.Cells(7).Value.ToString()
                frmPOS.txtCash1.Text = dr.Cells(8).Value.ToString()
                frmPOS.txtChange1.Text = dr.Cells(9).Value.ToString()
                frmPOS.lblPaymentMode1.Text = dr.Cells(10).Value.ToString()

                frmPOS.btnSave2.Enabled = False
                If lblUserType.Text = "Super Admin" Then
                    frmPOS.btnDelete2.Enabled = True
                Else
                    frmPOS.btnDelete2.Enabled = False
                End If
                If (lblUserType.Text = "Super Admin" And dr.Cells(16).Value.ToString() <> "Void") Or (lblUserType.Text = "Admin" And dr.Cells(16).Value.ToString() <> "Void") Then
                    frmPOS.btnVoid1.Enabled = True
                Else
                    frmPOS.btnVoid1.Enabled = False
                End If
                frmPOS.btnPrint2.Enabled = True
                frmPOS.lblSet.Text = "Not Allowed"
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select RTRIM(Dish),RTRIM(Rate),RTRIM(Quantity),RTRIM(Amount),RTRIM(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer), RTRIM(VATAmount),SCPer,SCAmount,RTRIM(TotalAmount),RTRIM(Notes) from RestaurantPOS_BillingInfoTA,RestaurantPOS_OrderedProductBillTA where RestaurantPOS_BillingInfoTA.Id=RestaurantPOS_OrderedProductBillTA.BillID and RestaurantPOS_BillingInfoTA.ID=" & dr.Cells(0).Value & " order by Dish"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmPOS.DataGridView3.Rows.Clear()
                While (rdr.Read() = True)
                    frmPOS.DataGridView3.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
                End While
                frmPOS.lblBalance1.Text = frmPOS.GrandTotal_Food2()
                frmPOS.txtSubTotal1.Text = frmPOS.GrandTotal_Food2()
                frmPOS.flpTA.Visible = False
                frmPOS.lblCurrencyValTA.Text = dr.Cells(12).Value.ToString()
                frmPOS.lblMemberID.Text = dr.Cells(14).Value.ToString()
                frmPOS.txtTAContactNo.Text = dr.Cells(15).Value.ToString()
                frmPOS.txtStatus.Text = dr.Cells(16).Value.ToString()
                frmPOS.lblCurrencyTA.Visible = True
                frmPOS.lblCurrencyValTA.Visible = True
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoTA.Id), RTRIM(BillNo),BillDate,TADiscountPer,TADiscountAmt,SubTotal,ParcelCharges,(RestaurantPOS_BillingInfoTA.GrandTotal),Cash,Change,RTRIM(PaymentMode),RTRIM(Operator),RTRIM(CurrencyCode),ExchangeRate,RTRIM(Member_ID),RTRIM(PhoneNo),RTRIM(TA_Status) from RestaurantPOS_BillingInfoTA where  BillDate >=@d1 and BillDate < @d2 Order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBillNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoTA.Id), RTRIM(BillNo),BillDate,TADiscountPer,TADiscountAmt,SubTotal,ParcelCharges,(RestaurantPOS_BillingInfoTA.GrandTotal),Cash,Change,RTRIM(PaymentMode),RTRIM(Operator),RTRIM(CurrencyCode),ExchangeRate,RTRIM(Member_ID),RTRIM(PhoneNo),RTRIM(TA_Status) from RestaurantPOS_BillingInfoTA where BillNo=@d1 Order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", cmbBillNo.Text)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_Format(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbBillNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub txtContactNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtContactNo.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoTA.Id), RTRIM(BillNo),BillDate,TADiscountPer,TADiscountAmt,SubTotal,ParcelCharges,(RestaurantPOS_BillingInfoTA.GrandTotal),Cash,Change,RTRIM(PaymentMode),RTRIM(Operator),RTRIM(CurrencyCode),ExchangeRate,RTRIM(Member_ID),RTRIM(PhoneNo),RTRIM(TA_Status) from RestaurantPOS_BillingInfoTA where PhoneNo like '%" & txtContactNo.Text & "%' Order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnViewReport_Click(sender As System.Object, e As System.EventArgs) Handles btnShowAllBills.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoTA.Id), RTRIM(BillNo),BillDate,TADiscountPer,TADiscountAmt,SubTotal,ParcelCharges,(RestaurantPOS_BillingInfoTA.GrandTotal),Cash,Change,RTRIM(PaymentMode),RTRIM(Operator),RTRIM(CurrencyCode),ExchangeRate,RTRIM(Member_ID),RTRIM(PhoneNo),RTRIM(TA_Status) from RestaurantPOS_BillingInfoTA Order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

