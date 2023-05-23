Imports System.Data.SqlClient

Public Class frmRestaurantPOSEBRecord_Unpaid
    Sub fillBillNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillNo) FROM RestaurantPOS_BillingInfoEB where EB_Status='Unpaid' order by 1", CN)
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
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoEB.Id), RTRIM(BillNo),BillDate,EBDiscountPer,EBDiscountAmt,(RestaurantPOS_BillingInfoEB.GrandTotal),Cash,Change,RTRIM(PaymentMode),RTRIM(Operator),RTRIM(CurrencyCode),ExchangeRate,RTRIM(EB_PhoneNo),RTRIM(Member_ID) from RestaurantPOS_BillingInfoEB where EB_Status='Unpaid' and (DATEDIFF(d,BillDate,GetDate())= 0) Order by BillDate Desc"
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
        txtContactNo.Text = ""
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
                frmPOS.txtBillID3.Text = dr.Cells(0).Value.ToString()
                'frmPOS.lblBillNo3.Text = dr.Cells(1).Value.ToString()
                'frmPOS.txtEBDiscountPer.Text = dr.Cells(3).Value.ToString()
                'frmPOS.txtEBDiscountAmount.Text = dr.Cells(4).Value.ToString()
                'frmPOS.lblBalance3.Text = dr.Cells(5).Value.ToString()
                'frmPOS.txtGrandTotal3.Text = dr.Cells(5).Value.ToString()
                'frmPOS.txtCash3.Text = dr.Cells(6).Value.ToString()
                'frmPOS.txtChange3.Text = dr.Cells(7).Value.ToString()
                'frmPOS.lblPaymentMode3.Text = dr.Cells(8).Value.ToString()
                'frmPOS.flpCategoriesEB.Enabled = False
                'frmPOS.DataGridView5.Enabled = False
                'frmPOS.lblCurrencyValEB.Text = dr.Cells(10).Value.ToString()
                'frmPOS.txtEBContactNo.Text = dr.Cells(12).Value.ToString()
                frmPOS.lblMemberID.Text = dr.Cells(13).Value.ToString()
                'frmPOS.btnSave4.Enabled = False
                'frmPOS.btnUpdate.Enabled = True
                'frmPOS.btnPrint4.Enabled = True
                'frmPOS.flpEB.Visible = True
                'If lblUserType.Text = "Super Admin" Then
                '    frmPOS.btnDelete4.Enabled = True
                'Else
                '    frmPOS.btnDelete4.Enabled = False
                'End If
                'If lblUserType.Text = "Super Admin" Or lblUserType.Text = "Admin" Then
                '    frmPOS.btnVoid2.Enabled = True
                'Else
                '    frmPOS.btnVoid2.Enabled = False
                'End If
                frmPOS.lblSet.Text = "Not Allowed"
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select RTRIM(Dish),RTRIM(Rate),RTRIM(Quantity),RTRIM(Amount),RTRIM(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer), RTRIM(VATAmount),SCPer,SCAmount,RTRIM(TotalAmount),RTRIM(Notes) from RestaurantPOS_BillingInfoEB,RestaurantPOS_OrderedProductBillEB where RestaurantPOS_BillingInfoEB.Id=RestaurantPOS_OrderedProductBillEB.BillID and RestaurantPOS_BillingInfoEB.ID=" & dr.Cells(0).Value & " order by Dish"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                'frmPOS.DataGridView5.Rows.Clear()
                While (rdr.Read() = True)
                    'frmPOS.DataGridView5.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
                End While
                con.Close()
                'frmPOS.lblBalance3.Text = frmPOS.GrandTotal_Food4()
                'frmPOS.txtGrandTotal3.Text = frmPOS.GrandTotal_Food4()
                'frmPOS.lblCurrencyEB.Visible = True
                'frmPOS.lblCurrencyValEB.Visible = True
                'frmPOS.btnCreditCustomer3.Enabled = False
                frmPOS.Calc3()
                'frmPOS.pnlEB.Visible = True
                'frmPOS.pnlEB.Location = New Point(Me.ClientSize.Width / 2 - frmPOS.pnlEB.Size.Width / 2, Me.ClientSize.Height / 2 - frmPOS.pnlEB.Size.Height / 2)
                'frmPOS.pnlEB.Anchor = AnchorStyles.None
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
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoEB.Id), RTRIM(BillNo),BillDate,EBDiscountPer,EBDiscountAmt,(RestaurantPOS_BillingInfoEB.GrandTotal),Cash,Change,RTRIM(PaymentMode),RTRIM(Operator),RTRIM(CurrencyCode),ExchangeRate,RTRIM(EB_PhoneNo),RTRIM(Member_ID) from RestaurantPOS_BillingInfoEB where EB_Status='Unpaid' and  BillDate >=@d1 and BillDate < @d2 Order by BillDate"
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
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoEB.Id), RTRIM(BillNo),BillDate,EBDiscountPer,EBDiscountAmt,(RestaurantPOS_BillingInfoEB.GrandTotal),Cash,Change,RTRIM(PaymentMode),RTRIM(Operator),RTRIM(CurrencyCode),ExchangeRate,RTRIM(EB_PhoneNo),RTRIM(Member_ID) from RestaurantPOS_BillingInfoEB where EB_Status='Unpaid' and BillNo=@d1 Order by BillDate"
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

    Private Sub txtContactNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtContactNo.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoEB.Id), RTRIM(BillNo),BillDate,EBDiscountPer,EBDiscountAmt,(RestaurantPOS_BillingInfoEB.GrandTotal),Cash,Change,RTRIM(PaymentMode),RTRIM(Operator),RTRIM(CurrencyCode),ExchangeRate,RTRIM(EB_PhoneNo),RTRIM(Member_ID) from RestaurantPOS_BillingInfoEB where EB_Status='Unpaid' and EB_PhoneNo like '%" & txtContactNo.Text & "%' Order by BillDate"
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

    Private Sub btnShowAllBills_Click(sender As System.Object, e As System.EventArgs) Handles btnShowAllBills.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoEB.Id), RTRIM(BillNo),BillDate,EBDiscountPer,EBDiscountAmt,(RestaurantPOS_BillingInfoEB.GrandTotal),Cash,Change,RTRIM(PaymentMode),RTRIM(Operator),RTRIM(CurrencyCode),ExchangeRate,RTRIM(EB_PhoneNo),RTRIM(Member_ID) from RestaurantPOS_BillingInfoEB where EB_Status='Unpaid' Order by BillDate"
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
End Class

