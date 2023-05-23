Imports System.Data.SqlClient

Public Class frmCustomersRecord
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select distinct RTRIM(Customername),RTRIM(Address),RTRIM(ContactNo) from RestaurantPOS_BillingInfoHD UNION Select distinct RTRIM(Customername),RTRIM(Address),RTRIM(ContactNo) from HDCustomer order by 1"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub
    Sub Reset()
        txtCustomerName.Text = ""
        txtContactNo.Text = ""
        txtAddress.Text = ""
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
                frmPOS.txtCustomerName.Text = dr.Cells(0).Value.ToString()
                frmPOS.txtAddress.Text = dr.Cells(1).Value.ToString()
                frmPOS.txtContactNo.Text = dr.Cells(2).Value.ToString()
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

    Private Sub txtCustomerName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCustomerName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select distinct RTRIM(Customername),RTRIM(Address),RTRIM(ContactNo) from RestaurantPOS_BillingInfoHD where CustomerName like '%" & txtCustomerName.Text & "%' UNION Select distinct RTRIM(Customername),RTRIM(Address),RTRIM(ContactNo) from HDCustomer where CustomerName like '%" & txtCustomerName.Text & "%' order by 1"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2))
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
            Dim sql As String = "Select distinct RTRIM(Customername),RTRIM(Address),RTRIM(ContactNo) from RestaurantPOS_BillingInfoHD where ContactNo like '%" & txtContactNo.Text & "%' UNION Select distinct RTRIM(Customername),RTRIM(Address),RTRIM(ContactNo) from HDCustomer where ContactNo like '%" & txtContactNo.Text & "%' order by 1"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtAddress_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAddress.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select distinct RTRIM(Customername),RTRIM(Address),RTRIM(ContactNo) from RestaurantPOS_BillingInfoHD where Address like '%" & txtAddress.Text & "%' UNION Select distinct RTRIM(Customername),RTRIM(Address),RTRIM(ContactNo) from HDCustomer where Address like '%" & txtAddress.Text & "%'  order by 1"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

