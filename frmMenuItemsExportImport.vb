Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
'Imports Microsoft.Office.Interop.Excel

Public Class frmMenuItemsExportImport
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Dim dt As New DataTable()
        Dim ds As New DataSet()
        Dim olecon As New OleDbConnection()
        Dim oleda As New OleDbDataAdapter

        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 DishID FROM Dish ORDER BY DishID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("DishID")
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
    Sub GenerateBarcode()
        Try
            txtBarCode.Text = 10000000 + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub auto()
        Try
            txtDishID.Text = GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(DishName), RTRIM(Category),DIRate,TARate,HDRate from Dish order by DishName", con)
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

    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub
    Sub Reset()
        txtSearchByDish.Text = ""
        txtCategory.Text = ""
        dgvGrid.DataSource = Nothing
        dgvGrid.Visible = False
        btnUpdate.Enabled = False
        Picture.Image = My.Resources._12
        Getdata()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        'ExportExcel(dgw)
        If dgw.RowCount > 0 Then
            Const CREATE_DIR As String = "C:\Users\Public\Documents\Restaurant POS\"
            Dim fbdir As String = CREATE_DIR

            If Not Directory.Exists(fbdir) Then
                Directory.CreateDirectory(fbdir)

                Try
                    Dim csv As String = String.Empty

                    For Each column As DataGridViewColumn In dgw.Columns
                        csv += column.HeaderText + ","c
                    Next

                    csv += vbCrLf

                    For Each row As DataGridViewRow In dgw.Rows

                        For Each cell As DataGridViewCell In row.Cells
                            csv += cell.Value.ToString().Replace(",", ";") + ","c
                        Next

                        csv += vbCrLf
                    Next

                    File.WriteAllText(fbdir & "Items.csv", csv)
                    MessageBox.Show("Exported successfully! " & " " & vbLf & " " & " Check on Documents")
                    If (MessageBox.Show("Do you want to preview file", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                        Dim pro As Process = New Process()
                        pro.StartInfo.FileName = fbdir & "Items.csv"
                        pro.Start()
                    End If
                Catch __unusedIOException1__ As IOException
                    MessageBox.Show("Error occur or file is open close and try again!", "", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
            Else

                Try
                    Dim csv As String = String.Empty

                    For Each column As DataGridViewColumn In dgw.Columns
                        csv += column.HeaderText + ","c
                    Next

                    csv += vbCrLf

                    For Each row As DataGridViewRow In dgw.Rows

                        For Each cell As DataGridViewCell In row.Cells
                            csv += cell.Value.ToString().Replace(",", ";") + ","c
                        Next

                        csv += vbCrLf
                    Next

                    File.WriteAllText(fbdir & "Items.csv", csv)
                    MessageBox.Show("Exported successfully! " & " " & vbLf & " " & " Check on Documents")
                    If (MessageBox.Show("Do you want to preview file", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                        Dim pro As Process = New Process()
                        pro.StartInfo.FileName = fbdir & "Items.csv"
                        pro.Start()
                    End If
                Catch __unusedIOException1__ As IOException
                    MessageBox.Show("Error occur or file is open close and try again!", "", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
            End If
        Else
            MessageBox.Show("Nothing to export!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show("Unable to release the Object " & ex.ToString())
        Finally
            GC.Collect()
        End Try
    End Sub
    Private Sub txtSearchByDish_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByDish.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(DishName), RTRIM(Category),DIRate,TARate,HDRate from Dish where DishName like '%" & txtSearchByDish.Text & "%' order by DishName", con)
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

    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub
    Public Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnImportExcel.Click
        Try
            '    Dim OpenFileDialog As New OpenFileDialog
            '    OpenFileDialog.Filter = "Excel Files (.xlsx) | *.xlsx; *.xls;"
            '    If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso OpenFileDialog.FileName <> "" Then
            '        Cursor = Cursors.WaitCursor
            '        Timer1.Enabled = True
            '        Dim Pathname As String = OpenFileDialog.FileName
            '        ''
            '        Dim constr As String
            '        Dim sheetName As String, excelstring As String
            '        Dim olecon As New OleDbConnection()
            '        Dim oleda As New OleDbDataAdapter
            '        'Data table runtime'
            '        constr = String.Format("Provider = Microsoft.ACE.OLEDB.12.0;Data Source = {0};Extended Properties = ""Excel 12.0 Xml;HDR = NO;""", Pathname)
            '        Dim dtt As DataTable
            '        Dim dt As DataTable
            '        dtt = New DataTable()
            '        dtt.Columns.Add("Dish Name", GetType(String))
            '        dtt.Columns.Add("Category", GetType(String))
            '        dtt.Columns.Add("Dine In Rate", GetType(Double))
            '        dtt.Columns.Add("Take Away Rate", GetType(Double))
            '        dtt.Columns.Add("Home Delivery Rate", GetType(Double))
            '        ''
            '        olecon = New OleDbConnection(constr)
            '        olecon.Open()
            '        Dim dtexcel As DataTable = olecon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            '        sheetName = dtexcel.Rows(0)("TABLE_NAME").ToString()
            '        olecon.Close()
            '        excelstring = String.Format("SELECT * FROM[{0}]", sheetName)
            '        ds = New DataSet()
            '        ds.Clear()
            '        dgvGrid.Rows.Clear()
            '        ''
            '        'dt.Rows.Clear()
            '        oleda = New OleDbDataAdapter(excelstring, olecon)
            '        oleda.Fill(ds)
            '        dt = ds.Tables(0)
            '        ''
            '        For i As Integer = 0 To dt.Rows.Count - 1
            '            dtt.Rows.Add(dt.Rows(i)(0).ToString(), dt.Rows(i)(1).ToString(), dt.Rows(i)(2).ToString(), dt.Rows(i)(3).ToString(), dt.Rows(i)(4).ToString())
            '        Next
            '        MessageBox.Show("Validation completed successfuly!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        'Dim MyConnection As System.Data.OleDb.OleDbConnection
            '        '            Dim DtSet As System.Data.DataSet
            '        '            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            '        '            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Pathname + ";Extended Properties=Excel 8.0;")
            '        '            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
            '        '            MyConnection.Open()
            '        '            DtSet = New System.Data.DataSet
            '        '            MyCommand.Fill(DtSet)
            '        dgvGrid.Visible = True
            '        dgvGrid.DataSource = dtt 'DtSet.Tables(0)
            '        btnUpdate.Enabled = True
            '    End If
            Dim frm1 As New Ext.frmExt()
            frm1.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Try
            If dgvGrid.RowCount = Nothing Then
                MessageBox.Show("Sorry nothing to update.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            For Each row As DataGridViewRow In dgvGrid.Rows
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                SqlConnection.ClearAllPools()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "update Dish set Category=@d2,DIRate=" & Val(row.Cells(2).Value) & ",TARate=" & Val(row.Cells(3).Value) & ",HDRate=" & Val(row.Cells(4).Value) & " where DishName=@d1"
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value.ToString())
                cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value.ToString())
                cmd.ExecuteReader()
                con.Close()
            Next
            MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvGrid.DataSource = Nothing
            Reset()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            con.Close()
        End Try

    End Sub

    Private Sub frmMenuItemsExportImport_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        frmMenuItem.Getdata()
    End Sub

    Private Sub txtCategory_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCategory.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(DishName), RTRIM(Category),DIRate,TARate,HDRate from Dish where Category like '%" & txtCategory.Text & "%' order by DishName", con)
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

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If dgvGrid.RowCount = Nothing Then
                MessageBox.Show("Sorry nothing to save.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            For Each row As DataGridViewRow In dgvGrid.Rows
                If Not row.IsNewRow Then
                    SqlConnection.ClearAllPools()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select DishName from Dish Where DishName=@d1"
                    cmd = New SqlCommand(ct)
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value.ToString())
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If Not rdr.Read() Then
                        Cursor = Cursors.WaitCursor
                        Timer1.Enabled = True
                        SqlConnection.ClearAllPools()
                        auto()
                        GenerateBarcode()
                        Picture.Image = My.Resources._12
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "Insert Into Dish (DishName,Category,DIRate,TARate,HDRate,BackColor,MI_Status,Barcode,DishID,Photo) Values(@d1,@d2," & Val(row.Cells(2).Value) & "," & Val(row.Cells(3).Value) & "," & Val(row.Cells(4).Value) & ",-9868951,'Active',@d4,@d5,@d6)"
                        cmd = New SqlCommand(cb)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value.ToString())
                        cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value.ToString())
                        cmd.Parameters.AddWithValue("@d4", txtBarCode.Text)
                        cmd.Parameters.AddWithValue("@d5", Val(txtDishID.Text))
                        cmd.Parameters.AddWithValue("@d6", "\Menu Items Image\" & row.Cells(0).Value.ToString() & ".jpg")
                        If (Not System.IO.Directory.Exists(Application.StartupPath & "\Menu Items Image")) Then
                            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Menu Items Image")
                        End If
                        Picture.Image.Save(Application.StartupPath & "\Menu Items Image\" & row.Cells(0).Value.ToString() & ".jpg")
                        Picture.Image.Dispose()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                End If
            Next
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvGrid.DataSource = Nothing
            Reset()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            con.Close()
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvGrid.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgvGrid.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgvGrid.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub
End Class

