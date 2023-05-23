Imports System.Data.SqlClient
Imports System.IO
Imports Ext

Public Class frmStock_Store
    Dim str As String
    Dim st As String
    Dim retrieving As New Retrieving()
    Private Sub auto()
        Try
            Dim Num As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = ("SELECT MAX(ST_ID) FROM Stock_Store")
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            If (IsDBNull(cmd.ExecuteScalar)) Then
                Num = 1
                txtST_ID.Text = Num.ToString
            Else
                Num = cmd.ExecuteScalar + 1
                txtST_ID.Text = Num.ToString
            End If
            cmd.Dispose()
            con.Close()
            con.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        dtpDate.Value = Today
        btnSave.Enabled = True
        btnDelete.Enabled = False
        DataGridView1.Enabled = True
        btnAdd.Enabled = True
        btnRemove.Enabled = False
        DataGridView1.Rows.Clear()
        lblSet.Text = ""
        Clear()
        auto()
    End Sub
    Sub Clear()
        cmbItemName.Text = ""
        txtQty.Text = ""
    End Sub
    Private Sub DataGridView1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If DataGridView1.Rows.Count > 0 Then
            If lblSet.Text = "Not allowed" Then
                btnRemove.Enabled = False
            Else
                btnRemove.Enabled = True
            End If
        End If
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

    Private Sub frmPurchase_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fillItem()
    End Sub

    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            For Each row As DataGridViewRow In DataGridView1.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Dish from temp_Stock_Store where Dish=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty - " & Val(row.Cells(1).Value) & " where Dish=@d1"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.ExecuteReader()
                    con.Close()
                    retrieving.ReduceStock((CType(row.Cells(1).Value, Decimal)), row.Cells(0).Value.ToString())  'Added by Jaemsoft Tech 12/02/2020 3:15AM
                End If
            Next
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Stock_Store where ST_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtST_ID.Text))
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                LogFunc(lblUser.Text, "deleted the item stock record having Stock ID '" & txtST_ID.Text & "'")
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        frmSupplierRecord.lblSet.Text = "Purchase"
        frmSupplierRecord.Reset()
        frmSupplierRecord.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Sorry no item info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            For Each row As DataGridViewRow In DataGridView1.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1"
                cmd = New SqlCommand(ctX)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty + " & Val(row.Cells(1).Value) & " where Dish=@d1"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.ExecuteReader()
                    con.Close()
                    retrieving.AddStock((CType(row.Cells(1).Value, Decimal)), row.Cells(0).Value.ToString())  'Added by Jaemsoft Tech 12/02/2020 3:15AM

                Else
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb3 As String = "Insert Into Temp_Stock_Store(Dish,Qty) values (@d1,@d2)"
                    cmd = New SqlCommand(cb3)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.ExecuteReader()
                    con.Close()
                    retrieving.insertStock((CType(row.Cells(1).Value, Decimal)), row.Cells(0).Value.ToString())  'Added by Jaemsoft Tech 12/02/2020 3:15AM
                End If
            Next
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Stock_Store(ST_ID,Date,Remarks) VALUES (@d1,@d2,@d3)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtST_ID.Text))
            cmd.Parameters.AddWithValue("@d2", dtpDate.Value.Date)
            cmd.Parameters.AddWithValue("@d3", txtRemarks.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Stock_Store_Join(StockID,Dish,Qty) VALUES (" & txtST_ID.Text & ",@d1,@d2)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            LogFunc(lblUser.Text, "added the new Item Stock having Stock ID '" & txtST_ID.Text & "'")
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Me.Reset()
        frmStock_StoreRecord.Reset()
        frmStock_StoreRecord.ShowDialog()
    End Sub

    Private Sub cmbProductName_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbItemName.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbItemName.Text = "" Then
                MessageBox.Show("Please select item name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbItemName.Focus()
                Exit Sub
            End If
            If txtQty.Text = "" Then
                MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If Val(txtQty.Text = 0) Then
                MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                DataGridView1.Rows.Add(cmbItemName.Text, Val(txtQty.Text))
                Clear()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If r.Cells(0).Value = cmbItemName.Text Then
                    r.Cells(0).Value = cmbItemName.Text
                    r.Cells(1).Value = Val(r.Cells(1).Value) + Val(txtQty.Text)
                    Clear()
                    Exit Sub
                End If
            Next
            DataGridView1.Rows.Add(cmbItemName.Text, Val(txtQty.Text))
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            btnRemove.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Sub fillItem()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(DishName) FROM Dish order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbItemName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbItemName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Extracts()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT [DishName],[DishID] FROM [Dish]", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            richExtract.ResetText()
            richExtract.Text = " Item          ID"
            For Each drow As DataRow In dtable.Rows
                richExtract.AppendText(drow("DishName").ToString() + "  " + drow("DishID").ToString())
            Next
            If MessageBox.Show("Do you want to save As text document ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim savef As New SaveFileDialog()
                With savef
                    .Title = "Text document"
                    .Filter = "Notepad(*.txt)|*.txt"
                End With
                If (savef.ShowDialog() = DialogResult.OK) Then
                    Dim fs As New FileStream(savef.FileName, FileMode.Create)
                    Dim sw As New StreamWriter(fs)
                    sw.WriteLine(richExtract.Text)
                    sw.Close()
                    fs.Close()
                    MessageBox.Show("File saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub lnkExtract_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Extracts()
    End Sub

    Private Sub lnkImport_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkImport.LinkClicked
        Dim ext As New frmExt()
        ext.isImportQuantity = 1
        ext.userx = lblUser.Text
        ext.ShowDialog()
    End Sub
End Class
