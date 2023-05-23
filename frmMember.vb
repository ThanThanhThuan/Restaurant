Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class frmMember
    Dim st1 As String
    Sub Reset()
        txtContactNo.Text = ""
        txtMemberName.Text = ""
        txtAddress.Text = ""
        txtSearchByMemberName.Text = ""
        chkActive.Checked = True
        txtMemberName.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        auto()
        Getdata()
    End Sub

    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql2 As String = "select MemberID from RestaurantPOS_BillingInfoEB,Member where RestaurantPOS_BillingInfoEB.Member_ID=Member.MemberID and MemberID=@d1"
            cmd = New SqlCommand(sql2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtMemberID.Text))
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
            Dim sql As String = "select MemberID from RestaurantPOS_BillingInfoTA,Member where RestaurantPOS_BillingInfoTA.Member_ID=Member.MemberID and MemberID=@d1"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtMemberID.Text))
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
            Dim sql1 As String = "select MemberID from RestaurantPOS_BillingInfoHD,Member where RestaurantPOS_BillingInfoHD.Member_ID=Member.MemberID and MemberID=@d1"
            cmd = New SqlCommand(sql1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtMemberID.Text))
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
            Dim cl5 As String = "select MemberID from RestaurantPOS_BillingInfoKOT,Member where RestaurantPOS_BillingInfoKOT.Member_ID=Member.MemberID and MemberID=@d1"
            cmd = New SqlCommand(cl5)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtMemberID.Text))
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
            Dim cq As String = "delete from Member where Memberid='" & Val(txtMemberID.Text) & "'"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "Deleted the Member '" & txtMemberID.Text & "' having Member ID '" & txtMemberID.Text & "'"
                LogFunc(lblUser.Text, st)
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
            cmd = New SqlCommand("SELECT Memberid, RTRIM(Name), RTRIM(Address), RTRIM(ContactNo),RTRIM(Active),RegistrationDate from Member order by Name", con)
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


    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub frmMember_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtMemberID.Text = dr.Cells(0).Value.ToString()
                txtMemberName.Text = dr.Cells(1).Value.ToString()
                txtMemName.Text = dr.Cells(1).Value.ToString()
                txtAddress.Text = (dr.Cells(2).Value.ToString())
                txtContactNo.Text = (dr.Cells(3).Value.ToString())
                If dr.Cells(4).Value.ToString() = "Yes" Then
                    chkActive.Checked = True
                Else
                    chkActive.Checked = False
                End If
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click_1(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub



    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If txtMemberName.Text = "" Then
            MessageBox.Show("Please enter member name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMemberName.Focus()
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
            Dim cb1 As String = "update LedgerBook set Name=@d3 where PartyID=@d1 and Name=@d2"
            cmd = New SqlCommand(cb1)
            cmd.Parameters.AddWithValue("@d1", txtMemberID.Text)
            cmd.Parameters.AddWithValue("@d2", txtMemName.Text)
            cmd.Parameters.AddWithValue("@d3", txtMemberName.Text)
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
            Dim cb As String = "Update Member set Name=@d2, ContactNo=@d3, Address=@d4, Active=@d5 where MemberID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtMemberID.Text))
            cmd.Parameters.AddWithValue("@d2", txtMemberName.Text)
            cmd.Parameters.AddWithValue("@d3", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d4", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d5", st1)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "Updated the Member '" & txtMemberID.Text & "' having Member ID '" & txtMemberID.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Member Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(MemberID) FROM Member")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtMemberID.Text = 100000 + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtMemberID.Text = Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtMemberName.Text = "" Then
            MessageBox.Show("Please enter member name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMemberName.Focus()
            Return
        End If
        If txtContactNo.Text = "" Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Return
        End If

        Try
            auto()
            If chkActive.Checked = True Then
                st1 = "Yes"
            Else
                st1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Member(MemberID, Name, ContactNo, Address, RegistrationDate, Active) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtMemberID.Text))
            cmd.Parameters.AddWithValue("@d2", txtMemberName.Text)
            cmd.Parameters.AddWithValue("@d3", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d4", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d5", Now)
            cmd.Parameters.AddWithValue("@d6", st1)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new Member '" & txtMemberID.Text & "' having Member ID '" & txtMemberID.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully Registered", "Member", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub txtSearchByMemberName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByMemberName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Memberid, RTRIM(Name), RTRIM(Address), RTRIM(ContactNo),RTRIM(Active),RegistrationDate from Member where Name like '%" & txtSearchByMemberName.Text & "%' order by Name", con)
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
End Class
