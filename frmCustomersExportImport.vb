Imports System.Data.SqlClient

Public Class frmCustomersExportImport
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(CustomerName), RTRIM(Address), RTRIM(ContactNo) from HDCustomer order by CustomerName", con)
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
        txtSearchByCustomer.Text = ""
        txtSearchByContactNo.Text = ""
        DataGridView1.DataSource = Nothing
        DataGridView1.Visible = False
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub txtSearchByCustomer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByCustomer.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(CustomerName), RTRIM(Address), RTRIM(ContactNo) from HDCustomer where CustomerName like '%" & txtSearchByCustomer.Text & "%' order by CustomerName", con)
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

    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnImportExcel.Click
        Try
            Dim OpenFileDialog As New OpenFileDialog
            OpenFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
            If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso OpenFileDialog.FileName <> "" Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                Dim Pathname As String = OpenFileDialog.FileName
                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
                MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Pathname + ";Extended Properties=Excel 8.0;")
                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
                MyConnection.Open()
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)
                DataGridView1.Visible = True
                DataGridView1.DataSource = DtSet.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub frmMenuItemsExportImport_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        frmCustomer.Getdata()
    End Sub

    Private Sub txtCategory_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByContactNo.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(CustomerName), RTRIM(Address), RTRIM(ContactNo) from HDCustomer where ContactNo like '%" & txtSearchByContactNo.Text & "%' order by CustomerName", con)
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

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If DataGridView1.RowCount = Nothing Then
                MessageBox.Show("Sorry nothing to save.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    SqlConnection.ClearAllPools()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select CustomerName,Address,ContactNo from HDCustomer Where CustomerName=@d1 and Address=@d2 and ContactNo=@d3"
                    cmd = New SqlCommand(ct)
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value.ToString())
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value.ToString())
                    cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value.ToString())
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If Not rdr.Read() Then
                        Cursor = Cursors.WaitCursor
                        Timer1.Enabled = True
                        SqlConnection.ClearAllPools()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "Insert Into HDCustomer(CustomerName,Address,ContactNo) Values(@d1,@d2,@d3)"
                        cmd = New SqlCommand(cb)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value.ToString())
                        cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value.ToString())
                        cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value.ToString())
                        cmd.ExecuteReader()
                        con.Close()
                        con.Dispose()
                    End If
                    con.Close()
                    con.Dispose()
                End If
            Next
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridView1.DataSource = Nothing
            Reset()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            con.Close()
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub
End Class

