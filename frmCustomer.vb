Imports System.Data.SqlClient
Public Class frmCustomer
    Sub Reset()
        txtCustomerName.Text = ""
        txtContactNo.Text = ""
        txtAddress.Text = ""
        txtSearchByContactNo.Text = ""
        txtSearchByCustomer.Text = ""
        txtCustomerName.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        Getdata()
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtCustomerName.Text = "" Then
            MessageBox.Show("Please enter customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCustomerName.Focus()
            Return
        End If
        If txtAddress.Text = "" Then
            MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
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
            Dim cb As String = "insert into HDCustomer(CustomerName,Address,ContactNo) VALUES (@d1,@d2,@d3)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtCustomerName.Text)
            cmd.Parameters.AddWithValue("@d2", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d3", txtContactNo.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new Customer '" & txtCustomerName.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Customer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
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
            Dim cq As String = "delete from HDCustomer where ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the Customer '" & txtCustomerName.Text & "'"
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

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If txtCustomerName.Text = "" Then
                MessageBox.Show("Please enter customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustomerName.Focus()
                Return
            End If
            If txtAddress.Text = "" Then
                MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAddress.Focus()
                Return
            End If
            If txtContactNo.Text = "" Then
                MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtContactNo.Focus()
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update HDCustomer set CustomerName=@d1,Address=@d2,ContactNo=@d3 where ID=" & Val(txtID.Text) & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtCustomerName.Text)
            cmd.Parameters.AddWithValue("@d2", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d3", txtContactNo.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "updated the Customer '" & txtCustomerName.Text & "' details"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Customer Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT  ID, RTRIM(CustomerName),RTRIM(Address),RTRIM(ContactNo) from HDCustomer order by CustomerName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
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

    Private Sub frmCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtCustomerName.Text = dr.Cells(1).Value.ToString()
                txtID.Text = dr.Cells(0).Value.ToString()
                txtContactNo.Text = dr.Cells(3).Value.ToString()
                txtAddress.Text = dr.Cells(2).Value.ToString()
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtSearchByCustomer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByCustomer.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT  ID, RTRIM(CustomerName),RTRIM(Address),RTRIM(ContactNo) from HDCustomer Where CustomerName like '%" & txtSearchByCustomer.Text & "%' order by CustomerName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearchByContactNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByContactNo.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT  ID, RTRIM(CustomerName),RTRIM(Address),RTRIM(ContactNo) from HDCustomer Where ContactNo like '%" & txtSearchByContactNo.Text & "%' order by CustomerName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        frmCustomersExportImport.Reset()
        frmCustomersExportImport.ShowDialog()
    End Sub
End Class
