Imports System.Data.SqlClient

Imports System.IO

Public Class frmCreditCustomerReceiptRecord
    Dim num1, num2, num3 As Decimal
    Dim str As String
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),CC_ID, RTRIM(CreditCustomer.CreditCustomerID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(CreditCustomerPayment.Remarks) from CreditCustomer,CreditCustomerPayment where CreditCustomer.CC_ID=CreditCustomerPayment.creditCustomer_ID and Amount > 0 order by [Date]", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Payment" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    frmCreditCustomerReceipt.Show()
                    Me.Hide()
                    frmCreditCustomerReceipt.txtT_ID.Text = dr.Cells(0).Value.ToString()
                    frmCreditCustomerReceipt.txtTransactionNo.Text = dr.Cells(1).Value.ToString()
                    frmCreditCustomerReceipt.dtpTranactionDate.Text = dr.Cells(2).Value.ToString()
                    frmCreditCustomerReceipt.cmbPaymentMode.Text = dr.Cells(3).Value.ToString()
                    frmCreditCustomerReceipt.txtCustID.Text = dr.Cells(4).Value.ToString()
                    frmCreditCustomerReceipt.txtCustomerID.Text = dr.Cells(5).Value.ToString()
                    frmCreditCustomerReceipt.txtCustomerName.Text = dr.Cells(6).Value.ToString()
                    frmCreditCustomerReceipt.txtTransactionAmount.Text = dr.Cells(7).Value.ToString()
                    frmCreditCustomerReceipt.txtTempAmt.Text = dr.Cells(7).Value.ToString()
                    frmCreditCustomerReceipt.txtPaymentModeDetails.Text = dr.Cells(8).Value.ToString()
                    frmCreditCustomerReceipt.txtRemarks.Text = dr.Cells(9).Value.ToString()
                    frmCreditCustomerReceipt.btnSave.Enabled = False
                    frmCreditCustomerReceipt.btnUpdate.Enabled = True
                    frmCreditCustomerReceipt.btnDelete.Enabled = True
                    frmCreditCustomerReceipt.GetCustomerInfo()
                    frmCreditCustomerReceipt.btnSelection.Enabled = False
                    frmCreditCustomerReceipt.GetCustomerBalance()
                End If
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
    Sub Reset()
        txtCustomerName.Text = ""
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        Getdata()
    End Sub


    Private Sub txtSupplierName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCustomerName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),CC_ID, RTRIM(CreditCustomer.CreditCustomerID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(CreditCustomerPayment.Remarks) from CreditCustomer,CreditCustomerPayment where CreditCustomer.CC_ID=CreditCustomerPayment.creditCustomer_ID and Amount > 0  and [Name] like '%" & txtCustomerName.Text & "%' order by [Date]", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT T_ID, RTRIM(TransactionID), Date,RTRIM(PaymentMode),CC_ID, RTRIM(CreditCustomer.CreditCustomerID),RTRIM(Name),Amount,RTRIM(PaymentModeDetails), RTRIM(CreditCustomerPayment.Remarks) from CreditCustomer,CreditCustomerPayment where CreditCustomer.CC_ID=CreditCustomerPayment.creditCustomer_ID and Amount > 0  and [Date] between @d1 and @d2 order by [Date]", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnReset_Click_1(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

End Class
