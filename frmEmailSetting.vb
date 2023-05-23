Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class frmEmailSetting
    Dim st1, st2, st3 As String
    Sub Reset()
        txtSMTPAddress.Text = ""
        cmbServerName.SelectedIndex = -1
        txtEmailID.Text = ""
        txtPassword.Text = ""
        txtPort.Text = ""
        cmbTSRequired.SelectedIndex = 0
        chkIsDefault.Checked = False
        chkIsEnabled.Checked = True
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        cmbServerName.Focus()
    End Sub
    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(cmbServerName.Text)) = 0 Then
            MessageBox.Show("Please select server name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbServerName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtSMTPAddress.Text)) = 0 Then
            MessageBox.Show("Please enter SMTP Address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSMTPAddress.Focus()
            Exit Sub
        End If
        If Len(Trim(txtEmailID.Text)) = 0 Then
            MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmailID.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPassword.Text)) = 0 Then
            MessageBox.Show("Please enter password", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPort.Text)) = 0 Then
            MessageBox.Show("Please enter port", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPort.Focus()
            Exit Sub
        End If
        Try
            If chkIsDefault.Checked = True Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select IsDefault from EmailSetting where IsDefault='Yes'"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    MessageBox.Show("Other Email ID is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    Return
                End If
            End If
            If chkIsDefault.Checked = True Then
                st1 = "Yes"
            Else
                st1 = "No"
            End If
            If chkIsEnabled.Checked = True Then
                st2 = "Yes"
            Else
                st2 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into EmailSetting(ServerName, SMTPAddress, Username, Password, Port, TLS_SSL_Required, IsDefault, IsActive) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbServerName.Text)
            cmd.Parameters.AddWithValue("@d2", txtSMTPAddress.Text)
            cmd.Parameters.AddWithValue("@d3", txtEmailID.Text)
            cmd.Parameters.AddWithValue("@d4", Encrypt(txtPassword.Text))
            cmd.Parameters.AddWithValue("@d5", txtPort.Text)
            cmd.Parameters.AddWithValue("@d6", cmbTSRequired.Text)
            cmd.Parameters.AddWithValue("@d7", st1)
            cmd.Parameters.AddWithValue("@d8", st2)
            cmd.ExecuteReader()
            con.Close()
            MessageBox.Show("Successfully saved", "Email Setting", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ID,RTRIM(ServerName), RTRIM(SMTPAddress), RTRIM(Username), RTRIM(Password), Port, RTRIM(TLS_SSL_Required), RTRIM(IsDefault), RTRIM(IsActive) from EmailSetting order by ServerName,SMTPAddress", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub frmSMSSetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Getdata()
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
            Dim cq As String = "delete from EmailSetting where ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtID.Text = dr.Cells(0).Value.ToString()
                cmbServerName.Text = dr.Cells(1).Value.ToString()
                txtSMTPAddress.Text = dr.Cells(2).Value.ToString()
                txtEmailID.Text = dr.Cells(3).Value.ToString()
                txtPassword.Text = Decrypt(dr.Cells(4).Value.ToString())
                txtPort.Text = dr.Cells(5).Value.ToString()
                cmbTSRequired.Text = dr.Cells(6).Value.ToString()
                If dr.Cells(7).Value.ToString() = "Yes" Then
                    chkIsDefault.Checked = True
                Else
                    chkIsDefault.Checked = False
                End If
                If dr.Cells(8).Value.ToString() = "Yes" Then
                    chkIsEnabled.Checked = True
                Else
                    chkIsEnabled.Checked = False
                End If
                btnUpdate.Enabled = True
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

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(cmbServerName.Text)) = 0 Then
            MessageBox.Show("Please select server name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbServerName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtSMTPAddress.Text)) = 0 Then
            MessageBox.Show("Please enter SMTP Address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSMTPAddress.Focus()
            Exit Sub
        End If
        If Len(Trim(txtEmailID.Text)) = 0 Then
            MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmailID.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPassword.Text)) = 0 Then
            MessageBox.Show("Please enter password", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPort.Text)) = 0 Then
            MessageBox.Show("Please enter port", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPort.Focus()
            Exit Sub
        End If
        Try
            If chkIsDefault.Checked = True Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "Update EmailSetting set IsDefault='No'"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.ExecuteReader()
            End If
            If chkIsDefault.Checked = True Then
                st1 = "Yes"
            Else
                st1 = "No"
            End If
            If chkIsEnabled.Checked = True Then
                st2 = "Yes"
            Else
                st2 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update EmailSetting set ServerName=@d1, SMTPAddress=@d2, Username=@d3, Password=@d4, Port=@d5, TLS_SSL_Required=@d6, IsDefault=@d7, IsActive=@d8 where ID=" & txtID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbServerName.Text)
            cmd.Parameters.AddWithValue("@d2", txtSMTPAddress.Text)
            cmd.Parameters.AddWithValue("@d3", txtEmailID.Text)
            cmd.Parameters.AddWithValue("@d4", Encrypt(txtPassword.Text))
            cmd.Parameters.AddWithValue("@d5", txtPort.Text)
            cmd.Parameters.AddWithValue("@d6", cmbTSRequired.Text)
            cmd.Parameters.AddWithValue("@d7", st1)
            cmd.Parameters.AddWithValue("@d8", st2)
            cmd.ExecuteReader()
            con.Close()
            MessageBox.Show("Successfully updated", "Email Setting", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub cmbServerName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbServerName.SelectedIndexChanged
        If cmbServerName.SelectedIndex = 0 Then
            txtSMTPAddress.Text = "smtp.mail.yahoo.com"
            txtPort.Text = 465
        End If
        If cmbServerName.SelectedIndex = 1 Then
            txtSMTPAddress.Text = "smtp.gmail.com"
            txtPort.Text = 587
        End If
        If cmbServerName.SelectedIndex = 2 Then
            txtSMTPAddress.Text = "smtp.live.com"
            txtPort.Text = 587
        End If
        If cmbServerName.SelectedIndex = 3 Then
            txtSMTPAddress.Text = "smtp.office365.com"
            txtPort.Text = 587
        End If
        If cmbServerName.SelectedIndex = 4 Then
            txtSMTPAddress.Text = "smtp.aol.com"
            txtPort.Text = 587
        End If
    End Sub

    Private Sub txtPort_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPort.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgw_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgw.CellFormatting
        If (e.ColumnIndex = 4) AndAlso e.Value IsNot Nothing Then
            dgw.Rows(e.RowIndex).Tag = e.Value
            e.Value = New [String]("●"c, e.Value.ToString().Length)
        End If
    End Sub

    Private Sub dgw_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgw.EditingControlShowing
        If dgw.CurrentCell.ColumnIndex = 4 Then
            'select target column
            Dim textBox As TextBox = TryCast(e.Control, TextBox)
            If textBox IsNot Nothing Then
                textBox.UseSystemPasswordChar = True
            End If
        Else
            Dim textBox As TextBox = TryCast(e.Control, TextBox)
            If textBox IsNot Nothing Then
                textBox.UseSystemPasswordChar = False
            End If
        End If
    End Sub

    Private Sub txtUsername_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailID.KeyPress
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
            MessageBox.Show("Please enter a valid email id", "Checking")
            txtEmailID.Clear()
        End If
    End Sub
End Class