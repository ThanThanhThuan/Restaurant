Imports System.Data.SqlClient
Public Class frmWalletType

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Sub Reset()
        txtWalletType.Text = ""
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        txtWalletType.Focus()
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtWalletType.Text = "" Then
            MessageBox.Show("Please enter Wallet Type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtWalletType.Focus()
            Return
        End If

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select WalletType from Wallet where WalletType=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtWalletType.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Wallet Type Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtWalletType.Text = ""
                txtWalletType.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If

            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Wallet(WalletType) VALUES (@d1)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", txtWalletType.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim st As String = "added the new Wallet Type '" & txtWalletType.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully Saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Getdata()
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtWalletType.Text = "" Then
            MessageBox.Show("Please enter Wallet Type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtWalletType.Focus()
            Return
        End If

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "Update RestaurantPOS_BillingInfoEB set PaymentMode=@d1 where PaymentMode=@d2"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtWalletType.Text)
            cmd.Parameters.AddWithValue("@d2", txtType.Text)
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "Update RestaurantPOS_BillingInfoHD set PaymentMode=@d1 where PaymentMode=@d2"
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtWalletType.Text)
            cmd.Parameters.AddWithValue("@d2", txtType.Text)
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb3 As String = "Update RestaurantPOS_BillingInfoTA set PaymentMode=@d1 where PaymentMode=@d2"
            cmd = New SqlCommand(cb3)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtWalletType.Text)
            cmd.Parameters.AddWithValue("@d2", txtType.Text)
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb4 As String = "Update RestaurantPOS_BillingInfoKOT set PaymentMode=@d1 where PaymentMode=@d2"
            cmd = New SqlCommand(cb4)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtWalletType.Text)
            cmd.Parameters.AddWithValue("@d2", txtType.Text)
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update Wallet set WalletType=@d1 where WalletType=@d2"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtWalletType.Text)
            cmd.Parameters.AddWithValue("@d2", txtType.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "updated the Wallet Type '" & txtWalletType.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub DeleteRecord()

        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Wallet where Wallettype=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", txtType.Text)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the Wallet Type '" & txtWalletType.Text & "'"
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
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtType.Text = dr.Cells(0).Value.ToString()
                txtWalletType.Text = dr.Cells(0).Value.ToString()
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
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
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(WalletType) from Wallet order by Wallettype", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmtype_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub
End Class
