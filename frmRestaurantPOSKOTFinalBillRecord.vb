Imports System.Data.SqlClient

Public Class frmRestaurantPOSKOTFinalBillRecord
    Sub fillBillNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillNo) FROM RestaurantPOS_BillingInfoKOT order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbBillNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbBillNo.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoKOT.Id), RTRIM(BillNo),BillDate,KOTDiscountPer,KOTDiscountAmt,(RestaurantPOS_BillingInfoKOT.GrandTotal),Cash,Change,RTRIM(PaymentMode),RTRIM(Operator),RTRIM(CurrencyCode),ExchangeRate,RTRIM(Member_ID),RTRIM(Waiter) from RestaurantPOS_BillingInfoKOT where (DATEDIFF(d,BillDate,GetDate())= 0)  Order by BillDate Desc"
            cmd = New SqlCommand(sql, con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
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
                frmPOS.txtBillID.Text = dr.Cells(0).Value.ToString()
                frmPOS.lblBillNo.Text = dr.Cells(1).Value.ToString()
                frmPOS.txtKOTDiscPer.Text = dr.Cells(3).Value.ToString()
                frmPOS.txtKOTDiscountAmount.Text = dr.Cells(4).Value.ToString()
                frmPOS.txtGrandTotal.Text = dr.Cells(5).Value
                frmPOS.txtCash.Text = dr.Cells(6).Value.ToString()
                frmPOS.txtChange.Text = dr.Cells(7).Value.ToString()
                frmPOS.lblPaymentMode.Text = dr.Cells(8).Value.ToString()

                frmPOS.lblCurrencyValKOT.Text = dr.Cells(10).Value.ToString()
                frmPOS.btnSave1.Enabled = False
                If lblUserType.Text = "Admin" Or lblUserType.Text = "Super Admin" Then
                    frmPOS.btnDelete1.Enabled = True
                Else
                    frmPOS.btnDelete1.Enabled = False
                End If
                frmPOS.btnPrint1.Enabled = True

                frmPOS.lblSet.Text = "Not Allowed"
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select RTRIM(TableNo), RTRIM(Dish),RTRIM(Rate),RTRIM(Quantity),RTRIM(Amount),(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer),RTRIM(VATAmount),SCPer,SCAmount,RTRIM(TotalAmount) from RestaurantPOS_BillingInfoKOT,RestaurantPOS_OrderedProductBillKOT where RestaurantPOS_BillingInfoKOT.Id=RestaurantPOS_OrderedProductBillKOT.BillID and RestaurantPOS_BillingInfoKOT.ID=" & dr.Cells(0).Value & " order by TableNo,Dish"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmPOS.DataGridView2.Rows.Clear()
                While (rdr.Read() = True)
                    frmPOS.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
                End While
                con.Close()
                frmPOS.txtGrandTotal.Text = frmPOS.GrandTotal_Food()
                frmPOS.FillCurrencyKOT()
                frmPOS.Calc()

                'frmRestaurantPOS.pnlKOT.Enabled = False
                frmPOS.lblCurrencyKOT.Visible = True
                frmPOS.lblCurrencyValKOT.Visible = True
                If Val(dr.Cells(6).Value) = 0 Then
                    frmPOS.btnUpdateFinalBill.Enabled = True
                    frmPOS.flpKOT.Visible = True
                Else
                    frmPOS.btnUpdateFinalBill.Enabled = False
                    frmPOS.flpKOT.Visible = False
                End If
                frmPOS.lblPrintMode.Text = "Final Bill"
                frmPOS.lvTable.Enabled = False
                frmPOS.lblMemberID.Text = dr.Cells(12).Value.ToString()
                frmPOS.lblWaiterNameVal.Text = dr.Cells(13).Value.ToString()
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
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoKOT.Id), RTRIM(BillNo),BillDate,KOTDiscountPer,KOTDiscountAmt,(RestaurantPOS_BillingInfoKOT.GrandTotal),Cash,Change,RTRIM(PaymentMode),RTRIM(Operator),RTRIM(CurrencyCode),ExchangeRate,RTRIM(Member_ID),RTRIM(Waiter) from RestaurantPOS_BillingInfoKOT where  BillDate >=@d1 and BillDate < @d2 Order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
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
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoKOT.Id), RTRIM(BillNo),BillDate,KOTDiscountPer,KOTDiscountAmt,(RestaurantPOS_BillingInfoKOT.GrandTotal),Cash,Change,RTRIM(PaymentMode),RTRIM(Operator),RTRIM(CurrencyCode),ExchangeRate,RTRIM(Member_ID),RTRIM(Waiter) from RestaurantPOS_BillingInfoKOT where BillNo=@d1 Order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@d1", cmbBillNo.Text)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
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

End Class

