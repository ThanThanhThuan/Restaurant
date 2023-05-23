Imports System.Data.SqlClient


Public Class frmJournalEntries
    Dim str As String
    Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ID, RTRIM(DebitAccount), RTRIM(CreditAccount), Date, Amount, RTRIM(Remarks) from Journal order by 1", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub auto()
        Try
            Dim Num As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = ("SELECT MAX(ID) FROM Journal")
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            If (IsDBNull(cmd.ExecuteScalar)) Then
                Num = 1
                txtID.Text = Num.ToString
            Else
                Num = cmd.ExecuteScalar + 1
                txtID.Text = Num.ToString
            End If
            cmd.Dispose()
            con.Close()
            con.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        cmbCreditAccount.SelectedIndex = -1
        cmbDebitAccount.SelectedIndex = -1
        txtAmount.Text = ""
        txtRemarks.Text = ""
        lblCreditAccountBalance.Visible = False
        lblCurrentBalance.Visible = False
        lblDebitAccountBalance.Visible = False
        dtpDate.Value = Now
        fillCombo()
        txtCreditAccount.Text = ""
        txtDebitAccount.Text = ""
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        GetData()
        btnSave.Enabled = True
        btnDelete.Enabled = False
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Sub fillCombo()
        Try
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            Dim ctn1 As String = "SELECT distinct RTRIM(Name) FROM LedgerBook order by 1"
            cmd = New SqlCommand(ctn1)
            cmd.Connection = con
            cmbDebitAccount.Items.Clear()
            cmbCreditAccount.Items.Clear()
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                cmbDebitAccount.Items.Add(rdr(0).ToString())
                cmbCreditAccount.Items.Add(rdr(0).ToString())
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        Cursor = Cursors.Default
        Timer3.Enabled = False
    End Sub

    Private Sub frmGeneralLedger_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fillCombo()
    End Sub

    Private Sub txtAmount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtAmount.Text
            Dim selectionStart = Me.txtAmount.SelectionStart
            Dim selectionLength = Me.txtAmount.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub cmbDebitAccount_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDebitAccount.SelectedIndexChanged
            Try
                lblCurrentBalance.Visible = True
                lblDebitAccountBalance.Visible = True
            Dim num1 As Double = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql1 As String = "SELECT RTRIM(SupplierID) from Supplier where Name=@d1 UNION SELECT RTRIM(CreditCustomerID) from CreditCustomer where Name=@d1 "
            cmd = New SqlCommand(sql1, con)
            cmd.Parameters.AddWithValue("@d1", cmbDebitAccount.Text)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                txtDrPartyID.Text = rdr.GetValue(0).ToString()
            Else
                txtDrPartyID.Text = ""
            End If
            con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from LedgerBook where Name=@d1 group By Name"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@d1", cmbDebitAccount.Text)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If (rdr.Read() = True) Then
                    num1 = rdr.GetValue(0)
                End If
                con.Close()
                lblDebitAccountBalance.Text = num1
                If Val(lblDebitAccountBalance.Text) >= 0 Then
                    str = "CR"
                ElseIf Val(lblDebitAccountBalance.Text < 0) Then
                    str = "DR"
                End If
                lblDebitAccountBalance.Text = Math.Abs(Val(lblDebitAccountBalance.Text))
                lblDebitAccountBalance.Text = (lblDebitAccountBalance.Text & " " & str).ToString()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
    End Sub

    Private Sub cmbCreditAccount_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCreditAccount.SelectedIndexChanged
        Try
            lblCurrentBalance.Visible = True
            lblCreditAccountBalance.Visible = True
            Dim num1 As Double = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql1 As String = "SELECT RTRIM(SupplierID) from Supplier where Name=@d1 UNION SELECT RTRIM(CreditCustomerID) from CreditCustomer where Name=@d1 "
            cmd = New SqlCommand(sql1, con)
            cmd.Parameters.AddWithValue("@d1", cmbCreditAccount.Text)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                txtCrPartyID.Text = rdr.GetValue(0).ToString()
            Else
                txtCrPartyID.Text = ""
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from LedgerBook where Name=@d1 group By Name"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", cmbCreditAccount.Text)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                num1 = rdr.GetValue(0)
            End If
            con.Close()
            lblCreditAccountBalance.Text = num1
            If Val(lblCreditAccountBalance.Text) >= 0 Then
                str = "CR"
            ElseIf Val(lblCreditAccountBalance.Text < 0) Then
                str = "DR"
            End If
            lblCreditAccountBalance.Text = Math.Abs(Val(lblCreditAccountBalance.Text))
            lblCreditAccountBalance.Text = (lblCreditAccountBalance.Text & " " & str).ToString()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(cmbDebitAccount.Text)) = 0 Then
            MessageBox.Show("Please select debit account", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbDebitAccount.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbCreditAccount.Text)) = 0 Then
            MessageBox.Show("Please select credit account", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCreditAccount.Focus()
            Exit Sub
        End If
        If Val(txtAmount.Text) = 0 Then
            MessageBox.Show("Please enter amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCreditAccount.Focus()
            Exit Sub
        End If
        If cmbDebitAccount.Text = cmbCreditAccount.Text Then
            MessageBox.Show("Debit and Credit Account must be different", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCreditAccount.Focus()
            Exit Sub
        End If
        auto()
        con = New SqlConnection(cs)
        con.Open()
        Dim cb As String = "insert into Journal( ID, DebitAccount, CreditAccount, Date, Amount, Remarks) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)"
        cmd = New SqlCommand(cb)
        cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
        cmd.Parameters.AddWithValue("@d2", cmbDebitAccount.Text)
        cmd.Parameters.AddWithValue("@d3", cmbCreditAccount.Text)
        cmd.Parameters.AddWithValue("@d4", dtpDate.Value)
        cmd.Parameters.AddWithValue("@d5", Val(txtAmount.Text))
        cmd.Parameters.AddWithValue("@d6", txtRemarks.Text)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()
        Dim st As String = "added the new journal entry having voucher no. '" & txtID.Text & "'"
        LogFunc(lblUser.Text, st)
        LedgerSave(dtpDate.Value.Date, cmbDebitAccount.Text, txtID.Text, "Journal Entry", Val(txtAmount.Text), 0, txtDrPartyID.Text, cmbCreditAccount.Text)
        LedgerSave(dtpDate.Value.Date, cmbCreditAccount.Text, txtID.Text, "Journal Entry", 0, Val(txtAmount.Text), txtCrPartyID.Text, cmbDebitAccount.Text)
        MessageBox.Show("Successfully saved", "Journal Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Reset()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub txtDebitAccount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDebitAccount.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ID, RTRIM(DebitAccount), RTRIM(CreditAccount), Date, Amount, RTRIM(Remarks) from Journal where DebitAccount like '%" & txtDebitAccount.Text & "%' order by 1", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
  
    Private Sub txtCreditAccount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCreditAccount.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ID, RTRIM(DebitAccount), RTRIM(CreditAccount), Date, Amount, RTRIM(Remarks) from Journal where CreditAccount like '%" & txtCreditAccount.Text & "%' order by 1", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
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
            cmd = New SqlCommand("SELECT ID, RTRIM(DebitAccount), RTRIM(CreditAccount), Date, Amount, RTRIM(Remarks) from Journal where Date >=@d1 and Date < @d2 order by 1", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()

        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Journal where ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                LedgerDelete(txtID.Text, "Journal Entry")
                Dim st As String = "deleted the journal entry having voucher no. '" & txtID.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtID.Text = dr.Cells(0).Value.ToString()
                cmbDebitAccount.Text = dr.Cells(1).Value.ToString()
                cmbCreditAccount.Text = dr.Cells(2).Value.ToString()
                dtpDate.Text = dr.Cells(3).Value.ToString()
                txtAmount.Text = dr.Cells(4).Value.ToString()
                txtRemarks.Text = dr.Cells(5).Value.ToString()
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
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
End Class
