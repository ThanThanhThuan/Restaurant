Imports System.Data.SqlClient
Public Class frmCreditCustomersList
    Sub Reset()
        txtSearchByCustomerName.Text = ""
    End Sub
    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then

                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                If lblSet.Text = "Customer Ledger" Then
                    Me.Hide()
                    frmCreditCustomerLedger.Show()
                    frmCreditCustomerLedger.txtCustID.Text = dr.Cells(0).Value.ToString()
                    frmCreditCustomerLedger.txtCustomerID.Text = dr.Cells(1).Value.ToString()
                    frmCreditCustomerLedger.txtCustomerName.Text = dr.Cells(2).Value.ToString()
                    lblSet.Text = ""
                End If
                If lblSet.Text = "Payment" Then
                    Me.Hide()
                    frmCreditCustomerReceipt.Show()
                    frmCreditCustomerReceipt.txtCustID.Text = dr.Cells(0).Value.ToString()
                    frmCreditCustomerReceipt.txtCustomerID.Text = dr.Cells(1).Value.ToString()
                    frmCreditCustomerReceipt.txtCustomerName.Text = dr.Cells(2).Value.ToString()
                    frmCreditCustomerReceipt.txtAddress.Text = dr.Cells(3).Value.ToString()
                    frmCreditCustomerReceipt.txtContactNo.Text = dr.Cells(4).Value.ToString()
                    frmCreditCustomerReceipt.GetCustomerBalance()
                    lblSet.Text = ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CC_ID,RTRIM(CreditCustomerid), RTRIM(Name), RTRIM(Address), RTRIM(ContactNo),RTRIM(Active),RegistrationDate from CreditCustomer order by Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub txtSearchByCreditCustomerName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByCustomerName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CC_ID,RTRIM(CreditCustomerid), RTRIM(Name), RTRIM(Address), RTRIM(ContactNo),RTRIM(Active),RegistrationDate from CreditCustomer where Name like '%" & txtSearchByCustomerName.Text & "%' order by Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmCreditCustomerList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub txtSearchByAC_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByAC.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CC_ID,RTRIM(CreditCustomerid), RTRIM(Name), RTRIM(Address), RTRIM(ContactNo),RTRIM(Active),RegistrationDate from CreditCustomer where CreditCustomerID like '%" & txtSearchByAC.Text & "%' order by Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class