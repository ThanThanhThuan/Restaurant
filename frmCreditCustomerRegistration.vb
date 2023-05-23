Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class frmCreditCustomerRegistration
    Dim st1 As String
    Sub Reset()
        txtContactNo.Text = ""
        txtSearchByACNo.Text = ""
        txtCreditCustomerName.Text = ""
        txtAddress.Text = ""
        txtSearchByCreditCustomerName.Text = ""
        chkActive.Checked = True
        cmbOpeningBalanceType.SelectedIndex = 0
        txtOpeningBalance.Text = "0.00"
        cmbOpeningBalanceType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbOpeningBalanceType.Enabled = True
        txtOpeningBalance.ReadOnly = False
        txtAccountNo.Text = ""
        txtAccountNo.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        txtCreditCustomerName.Enabled = True
        txtACNo.Text = ""
        auto()
        Getdata()
    End Sub

    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cl1 As String = "SELECT CreditCustomerID FROM CreditCustomer INNER JOIN CreditCustomerPayment ON CreditCustomer.CC_ID = CreditCustomerPayment.CreditCustomer_ID where CreditCustomerID=@d1"
            cmd = New SqlCommand(cl1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtAccountNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Receipt Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql2 As String = "select CreditCustomerID from RestaurantPOS_BillingInfoEB,CreditCustomer where RestaurantPOS_BillingInfoEB.Member_ID=CreditCustomer.CreditCustomerID and CreditCustomerID=@d1"
            cmd = New SqlCommand(sql2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtAccountNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select CreditCustomerID from RestaurantPOS_BillingInfoTA,CreditCustomer where RestaurantPOS_BillingInfoTA.Member_ID=CreditCustomer.CreditCustomerID and CreditCustomerID=@d1"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtAccountNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql1 As String = "select CreditCustomerID from RestaurantPOS_BillingInfoHD,CreditCustomer where RestaurantPOS_BillingInfoHD.Member_ID=CreditCustomer.CreditCustomerID and CreditCustomerID=@d1"
            cmd = New SqlCommand(sql1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtAccountNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl5 As String = "select CreditCustomerID from RestaurantPOS_BillingInfoKOT,CreditCustomer where RestaurantPOS_BillingInfoKOT.Member_ID=CreditCustomer.CreditCustomerID and CreditCustomerID=@d1"
            cmd = New SqlCommand(cl5)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtAccountNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from CreditCustomer where CC_id=" & Val(txtCC_ID.Text) & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "Deleted the CreditCustomer having Account No. '" & txtAccountNo.Text & "'"
                LogFunc(lblUser.Text, st)
                LedgerDelete(txtAccountNo.Text, "Opening Balance")
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Getdata()
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CC_ID, RTRIM(CreditCustomerid), RTRIM(Name), RTRIM(Address), RTRIM(ContactNo),RTRIM(Active),RTRIM(Convert(nvarchar(50),OpeningBalance) + ' ' + Convert(Nvarchar(50),OpeningBalanceType)),RegistrationDate from CreditCustomer order by Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
            End While
            con.Close()
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

    Private Sub frmCreditCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtCC_ID.Text = dr.Cells(0).Value.ToString()
                txtAccountNo.Text = dr.Cells(1).Value.ToString()
                txtACNo.Text = dr.Cells(1).Value.ToString()
                txtCreditCustomerName.Text = dr.Cells(2).Value.ToString()
                txtCustName.Text = dr.Cells(2).Value.ToString()
                txtAddress.Text = (dr.Cells(3).Value.ToString())
                txtContactNo.Text = (dr.Cells(4).Value.ToString())
                If dr.Cells(5).Value.ToString() = "Yes" Then
                    chkActive.Checked = True
                Else
                    chkActive.Checked = False
                End If
                Dim strX As String
                Dim strArr() As String
                strX = dr.Cells.Item(6).Value.ToString()
                strArr = strX.Split(" ")
                txtOpeningBalance.Text = strArr(0)
                cmbOpeningBalanceType.Text = strArr(1)
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
                cmbOpeningBalanceType.Enabled = False
                txtOpeningBalance.ReadOnly = True
                txtCreditCustomerName.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If txtAccountNo.Text = "" Then
            MessageBox.Show("Please enter account no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAccountNo.Focus()
            Return
        End If
        If txtCreditCustomerName.Text = "" Then
            MessageBox.Show("Please enter CreditCustomer name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCreditCustomerName.Focus()
            Return
        End If
        If txtContactNo.Text = "" Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Return
        End If

        Try
            If txtAccountNo.Text <> txtACNo.Text Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cl2 As String = "SELECT CreditCustomerID from CreditCustomer where CreditCustomerID=@d1"
                cmd = New SqlCommand(cl2)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtAccountNo.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read Then
                    MessageBox.Show("Account No. already exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtAccountNo.Text = ""
                    txtAccountNo.Focus()
                    If Not rdr Is Nothing Then
                        rdr.Close()
                    End If
                    Exit Sub
                End If
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "update LedgerBook set Name=@d3 where PartyID=@d1 and Name=@d2"
            cmd = New SqlCommand(cb1)
            cmd.Parameters.AddWithValue("@d1", txtAccountNo.Text)
            cmd.Parameters.AddWithValue("@d2", txtCustName.Text)
            cmd.Parameters.AddWithValue("@d3", txtCreditCustomerName.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            If chkActive.Checked = True Then
                st1 = "Yes"
            Else
                st1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update CreditCustomer set CreditCustomerID=@d1, Name=@d2, ContactNo=@d3, Address=@d4, Active=@d5 where CC_ID=" & Val(txtCC_ID.Text) & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtAccountNo.Text)
            cmd.Parameters.AddWithValue("@d2", txtCreditCustomerName.Text)
            cmd.Parameters.AddWithValue("@d3", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d4", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d5", st1)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "Updated the CreditCustomer having Account No. '" & txtAccountNo.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Credit Customer Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 CC_ID FROM CreditCustomer ORDER BY CC_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("CC_ID")
            End If
            rdr.Close()
            ' Increase the ID by 1
            value += 1
            ' Because incrementing a string with an integer removes 0's
            ' we need to replace them. If necessary.
            If value <= 9 Then 'Value is between 0 and 10
                value = "000" & value
            ElseIf value <= 99 Then 'Value is between 9 and 100
                value = "00" & value
            ElseIf value <= 999 Then 'Value is between 999 and 1000
                value = "0" & value
            End If
        Catch ex As Exception
            ' If an error occurs, check the connection state and close it if necessary.
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            value = "0000"
        End Try
        Return value
    End Function
    Sub auto()
        Try
            txtCC_ID.Text = GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtAccountNo.Text = "" Then
            MessageBox.Show("Please enter account no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAccountNo.Focus()
            Return
        End If
        If txtCreditCustomerName.Text = "" Then
            MessageBox.Show("Please enter CreditCustomer name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCreditCustomerName.Focus()
            Return
        End If
        If txtContactNo.Text = "" Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Return
        End If

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cl2 As String = "SELECT CreditCustomerID from CreditCustomer where CreditCustomerID=@d1"
            cmd = New SqlCommand(cl2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtAccountNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Account No. already exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtAccountNo.Text = ""
                txtAccountNo.Focus()
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl1 As String = "SELECT Name from CreditCustomer where Name=@d1"
            cmd = New SqlCommand(cl1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtCreditCustomerName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Name already exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCreditCustomerName.Text = ""
                txtCreditCustomerName.Focus()
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            auto()
            If chkActive.Checked = True Then
                st1 = "Yes"
            Else
                st1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into CreditCustomer(CC_ID,CreditCustomerID, Name, ContactNo, Address, RegistrationDate, Active,OpeningBalanceType,OpeningBalance) VALUES (" & Val(txtCC_ID.Text) & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtAccountNo.Text)
            cmd.Parameters.AddWithValue("@d2", txtCreditCustomerName.Text)
            cmd.Parameters.AddWithValue("@d3", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d4", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d5", Now)
            cmd.Parameters.AddWithValue("@d6", st1)
            cmd.Parameters.AddWithValue("@d7", cmbOpeningBalanceType.Text)
            cmd.Parameters.AddWithValue("@d8", Val(txtOpeningBalance.Text))
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new CreditCustomer having Account No. '" & txtAccountNo.Text & "'"
            LogFunc(lblUser.Text, st)
            If cmbOpeningBalanceType.SelectedIndex = 0 And Val(txtOpeningBalance.Text) > 0 Then
                LedgerSave(Today, txtCreditCustomerName.Text, txtAccountNo.Text, "Opening Balance", 0, Val(txtOpeningBalance.Text), txtAccountNo.Text, "Opening")
            End If
            If cmbOpeningBalanceType.SelectedIndex = 1 And Val(txtOpeningBalance.Text) > 0 Then
                LedgerSave(Today, txtCreditCustomerName.Text, txtAccountNo.Text, "Opening Balance", Val(txtOpeningBalance.Text), 0, txtAccountNo.Text, "Opening")
            End If
            MessageBox.Show("Successfully Registered", "Credit Customer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub txtSearchByCreditCustomerName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByCreditCustomerName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CC_ID, RTRIM(CreditCustomerid), RTRIM(Name), RTRIM(Address), RTRIM(ContactNo),RTRIM(Active),RTRIM(Convert(nvarchar(50),OpeningBalance) + ' ' + Convert(Nvarchar(50),OpeningBalanceType)),RegistrationDate from CreditCustomer where Name like '%" & txtSearchByCreditCustomerName.Text & "%' order by Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub txtOpeningBalance_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpeningBalance.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtOpeningBalance.Text
            Dim selectionStart = Me.txtOpeningBalance.SelectionStart
            Dim selectionLength = Me.txtOpeningBalance.SelectionLength

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

    Private Sub txtSearchByACNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByACNo.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CC_ID, RTRIM(CreditCustomerid), RTRIM(Name), RTRIM(Address), RTRIM(ContactNo),RTRIM(Active),RTRIM(Convert(nvarchar(50),OpeningBalance) + ' ' + Convert(Nvarchar(50),OpeningBalanceType)),RegistrationDate from CreditCustomer where CreditCustomerID like '%" & txtSearchByACNo.Text & "%' order by Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
