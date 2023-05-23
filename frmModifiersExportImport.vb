Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO

Public Class frmModifiersExportImport
    Private Sub auto()
        Try
            Dim Num As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = ("SELECT MAX(MIM_ID) FROM Modifiers")
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            If (IsDBNull(cmd.ExecuteScalar)) Then
                Num = 1
                txtModifierID.Text = Num.ToString
            Else
                Num = cmd.ExecuteScalar + 1
                txtModifierID.Text = Num.ToString
            End If
            con.Close()
            con.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ModifierName), RTRIM(Item),Rate from Modifiers order by ModifierName", con)
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
        Getdata()
    End Sub
    Sub Reset()
        dgvGrid.DataSource = Nothing
        dgvGrid.Visible = False
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

                    File.WriteAllText(fbdir & "Items Modifier.csv", csv)
                    MessageBox.Show("Exported successfully! " & " " & vbLf & " " & " Check on Documents")
                    If (MessageBox.Show("Do you want to preview file", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                        Dim pro As Process = New Process()
                        pro.StartInfo.FileName = fbdir & "Items Modifier.csv"
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

                    File.WriteAllText(fbdir & "Items Modifier.csv", csv)
                    MessageBox.Show("Exported successfully! " & " " & vbLf & " " & " Check on Documents")
                    If (MessageBox.Show("Do you want to preview file", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                        Dim pro As Process = New Process()
                        pro.StartInfo.FileName = fbdir & "Items Modifier.csv"
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
        'Try
        '    Dim OpenFileDialog As New OpenFileDialog
        '    OpenFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
        '    If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso OpenFileDialog.FileName <> "" Then
        '        Cursor = Cursors.WaitCursor
        '        Timer1.Enabled = True
        '        Dim Pathname As String = OpenFileDialog.FileName
        '        Dim MyConnection As System.Data.OleDb.OleDbConnection
        '        Dim DtSet As System.Data.DataSet
        '        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        '        MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Pathname + ";Extended Properties=Excel 8.0;")
        '        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
        '        MyConnection.Open()
        '        DtSet = New System.Data.DataSet
        '        MyCommand.Fill(DtSet)
        '        DataGridView1.Visible = True
        '        DataGridView1.DataSource = DtSet.Tables(0)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        Try
            Dim OpenFileDialog As New OpenFileDialog
            OpenFileDialog.Filter = "Excel Files (.xlsx) | *.xlsx; *.xls;"
            If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso OpenFileDialog.FileName <> "" Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                Dim Pathname As String = OpenFileDialog.FileName
                ''
                Dim constr As String
                Dim sheetName As String, excelstring As String
                Dim olecon As New OleDbConnection()
                Dim oleda As New OleDbDataAdapter
                'Data table runtime'
                constr = String.Format("Provider = Microsoft.ACE.OLEDB.12.0;Data Source = {0};Extended Properties = ""Excel 12.0 Xml;HDR = NO;""", Pathname)
                Dim dtt As DataTable
                Dim dt As DataTable
                dtt = New DataTable()
                dtt.Columns.Add("Modifier Name", GetType(String))
                dtt.Columns.Add("Item Name", GetType(String))
                dtt.Columns.Add("Rate", GetType(Double))
                ''
                olecon = New OleDbConnection(constr)
                olecon.Open()
                Dim dtexcel As DataTable = olecon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                sheetName = dtexcel.Rows(0)("TABLE_NAME").ToString()
                olecon.Close()
                excelstring = String.Format("SELECT * FROM[{0}]", sheetName)
                ds = New DataSet()
                ds.Clear()
                dgvGrid.Rows.Clear()
                ''
                'dt.Rows.Clear()
                oleda = New OleDbDataAdapter(excelstring, olecon)
                oleda.Fill(ds)
                dt = ds.Tables(0)
                ''
                For i As Integer = 0 To dt.Rows.Count - 1
                    dtt.Rows.Add(dt.Rows(i)(0).ToString(), dt.Rows(i)(1).ToString(), dt.Rows(i)(2).ToString())
                Next
                MessageBox.Show("Validation completed successfuly!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Dim MyConnection As System.Data.OleDb.OleDbConnection
                '            Dim DtSet As System.Data.DataSet
                '            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
                '            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Pathname + ";Extended Properties=Excel 8.0;")
                '            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
                '            MyConnection.Open()
                '            DtSet = New System.Data.DataSet
                '            MyCommand.Fill(DtSet)
                dgvGrid.Visible = True
                dgvGrid.DataSource = dtt 'DtSet.Tables(0) 
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
        frmMenuItemsModifiers.Getdata()
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
                    Dim ct As String = "select ModifierName,Item from Modifiers where ModifierName=@d1 and Item=@d2"
                    cmd = New SqlCommand(ct)
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value.ToString())
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value.ToString())
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If Not rdr.Read() Then
                        Cursor = Cursors.WaitCursor
                        Timer1.Enabled = True
                        SqlConnection.ClearAllPools()
                        auto()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "Insert Into Modifiers(MIM_ID,ModifierName,Item,Rate,BackColor) Values(@d3,@d1,@d2," & Val(row.Cells(2).Value) & ",-9868951)"
                        cmd = New SqlCommand(cb)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value.ToString())
                        cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value.ToString())
                        cmd.Parameters.AddWithValue("@d3", Val(txtModifierID.Text))
                        cmd.ExecuteReader()
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

