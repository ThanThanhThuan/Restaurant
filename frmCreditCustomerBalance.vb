Imports System.Data.SqlClient
Public Class frmCreditCustomerBalance
    Sub Reset()
        txtContactNo.Text = ""
        txtCustomerName.Text = ""
        txtSearchByAC.Text = ""
        GetData()
    End Sub
    Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CC_ID,CreditCustomer.CreditCustomerID,RTRIM(CreditCustomer.Name),RTRIM(ContactNo),IsNull(sum(Credit)-sum(Debit),0) FROM CreditCustomer Left join LedgerBook on CreditCustomer.CreditCustomerID=LedgerBook.PartyID where Active='Yes' group by CC_ID, CreditCustomerID,CreditCustomer.name,ContactNo order by CreditCustomer.Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmMemberBalance_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                If lblSet.Text = "HD" Then
                    Me.Hide()
                    frmPOS.Show()
                    frmPOS.lblPaymentMode2.Text = "Credit Customer"
                    frmPOS.lblMemberID.Text = dr.Cells(1).Value
                    frmPOS.txtCustID.Text = dr.Cells(0).Value
                    POSHeaderClear()
                    frmPOS.lblCustName.Visible = True
                    frmPOS.lblCustNameVAL.Visible = True
                    frmPOS.lblCustNameVAL.Text = dr.Cells(2).Value
                End If
                If lblSet.Text = "Dine In Billing" Then
                    Me.Hide()
                    frmPOS.Show()
                    frmPOS.lblPaymentMode.Text = "Credit Customer"
                    frmPOS.lblMemberID.Text = dr.Cells(1).Value
                    frmPOS.txtCustID.Text = dr.Cells(0).Value
                    frmPOS.txtCash.ReadOnly = True
                    frmPOS.txtCash.Text = "0.00"
                    frmPOS.txtChange.Text = "0.00"
                    POSHeaderClear()
                    frmPOS.lblCustName.Visible = True
                    frmPOS.lblCustNameVAL.Visible = True
                    frmPOS.lblCustNameVAL.Text = dr.Cells(2).Value
                End If
                If lblSet.Text = "TA" Then
                    Me.Hide()
                    frmPOS.Show()
                    frmPOS.lblPaymentMode1.Text = "Credit Customer"
                    frmPOS.lblMemberID.Text = dr.Cells(1).Value
                    frmPOS.txtCustID.Text = dr.Cells(0).Value
                    frmPOS.txtCash1.ReadOnly = True
                    frmPOS.txtCash1.Text = "0.00"
                    frmPOS.txtChange1.Text = "0.00"
                    POSHeaderClear()
                    frmPOS.lblCustName.Visible = True
                    frmPOS.lblCustNameVAL.Visible = True
                    frmPOS.lblCustNameVAL.Text = dr.Cells(2).Value
                End If
                If lblSet.Text = "EB" Then
                    Me.Hide()
                    frmPOS.Show()
                    'frmPOS.lblPaymentMode3.Text = "Credit Customer"
                    frmPOS.lblMemberID.Text = dr.Cells(1).Value
                    frmPOS.txtCustID.Text = dr.Cells(0).Value
                    'frmPOS.txtCash3.ReadOnly = True
                    'frmPOS.txtCash3.Text = "0.00"
                    'frmPOS.txtChange3.Text = "0.00"
                    POSHeaderClear()
                    frmPOS.lblCustName.Visible = True
                    frmPOS.lblCustNameVAL.Visible = True
                    frmPOS.lblCustNameVAL.Text = dr.Cells(2).Value
                End If
                lblSet.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub POSHeaderClear()
        frmPOS.lblPOS.Visible = False
        frmPOS.lblU.Visible = False
        frmPOS.lblUserVAL.Visible = False
        frmPOS.lblOD.Visible = False
        frmPOS.lblOrderNo.Visible = False
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

    Private Sub txtCustomerName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCustomerName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CC_ID,CreditCustomer.CreditCustomerID,RTRIM(CreditCustomer.Name),RTRIM(ContactNo),IsNull(sum(Credit)-sum(Debit),0) FROM CreditCustomer Left join LedgerBook on CreditCustomer.CreditCustomerID=LedgerBook.PartyID where Active='Yes' and CreditCustomer.Name like '%" & txtCustomerName.Text & "%' group by CC_ID, CreditCustomerID,CreditCustomer.name,ContactNo order by CreditCustomer.Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtContactNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtContactNo.TextChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CC_ID,CreditCustomer.CreditCustomerID,RTRIM(CreditCustomer.Name),RTRIM(ContactNo),IsNull(sum(Credit)-sum(Debit),0) FROM CreditCustomer Left join LedgerBook on CreditCustomer.CreditCustomerID=LedgerBook.PartyID where Active='Yes' and ContactNo like '%" & txtContactNo.Text & "%' group by CC_ID, CreditCustomerID,CreditCustomer.name,ContactNo order by CreditCustomer.Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearchByAC_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByAC.TextChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CC_ID,CreditCustomer.CreditCustomerID,RTRIM(CreditCustomer.Name),RTRIM(ContactNo),IsNull(sum(Credit)-sum(Debit),0) FROM CreditCustomer Left join LedgerBook on CreditCustomer.CreditCustomerID=LedgerBook.PartyID where Active='Yes' and CreditCustomerID like '%" & txtSearchByAC.Text & "%' group by CC_ID, CreditCustomerID,CreditCustomer.name,ContactNo order by CreditCustomer.Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class