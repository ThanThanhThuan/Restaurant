Imports System.Data.SqlClient
Public Class frmMenuItemsModifiers
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
                txtMIM_ID.Text = Num.ToString
            Else
                Num = cmd.ExecuteScalar + 1
                txtMIM_ID.Text = Num.ToString
            End If
            con.Close()
            con.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillCombo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Dishname) FROM Dish order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbItemName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbItemName.Items.Add(drow(0).ToString())
            Next
            CN.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        cmbItemName.SelectedIndex = -1
        txtRate.Text = ""
        txtSearchByModifier.Text = ""
        txtModifierName.Text = ""
        txtModifierName.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnUIColor.BackColor = Color.DimGray
        auto()
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtModifierName.Text)) = 0 Then
            MessageBox.Show("Please enter modifier name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtModifierName.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbItemName.Text)) = 0 Then
            MessageBox.Show("Please select item name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbItemName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtRate.Text)) = 0 Then
            MessageBox.Show("Please enter rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRate.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select ModifierName,Item from Modifiers where ModifierName=@d1 and Item=@d2"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtModifierName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbItemName.Text)
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtModifierName.Text = ""
                txtModifierName.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Modifiers(MIM_ID,ModifierName,Item,Rate,BackColor) VALUES (" & Val(txtMIM_ID.Text) & ",@d1,@d2," & Val(txtRate.Text) & ",@d3)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtModifierName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbItemName.Text)
            cmd.Parameters.AddWithValue("@d3", btnUIColor.BackColor.ToArgb())
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new modifier '" & txtModifierName.Text & "' having modifier id='" & txtMIM_ID.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Getdata()
            AutoComplete()
            auto()
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
            Dim cq As String = "delete from Modifiers where MIM_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtMIM_ID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the modifier '" & txtModifierName.Text & "' having modifier id='" & txtMIM_ID.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Getdata()
                AutoComplete()
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
            If Len(Trim(txtModifierName.Text)) = 0 Then
                MessageBox.Show("Please enter modifier name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtModifierName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbItemName.Text)) = 0 Then
                MessageBox.Show("Please select item name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbItemName.Focus()
                Exit Sub
            End If
            If Len(Trim(txtRate.Text)) = 0 Then
                MessageBox.Show("Please enter rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRate.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update Modifiers set ModifierName=@d1,Item=@d2,Rate=" & Val(txtRate.Text) & ",BackColor=@d4 where MIM_ID=@d3"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtModifierName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbItemName.Text)
            cmd.Parameters.AddWithValue("@d3", Val(txtMIM_ID.Text))
            cmd.Parameters.AddWithValue("@d4", btnUIColor.BackColor.ToArgb())
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "Updated the modifier '" & txtModifierName.Text & "' having modifier id='" & txtMIM_ID.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "modifier Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
            AutoComplete()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT MIM_ID, RTRIM(ModifierName), RTRIM(Item), RTRIM(Rate),BackColor from Modifiers order by ModifierName", con)
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
    Sub AutoComplete()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Distinct (ModifierName) FROM Modifiers order by 1", con)
            ds = New DataSet()
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Modifiers")
            Dim col As AutoCompleteStringCollection = New AutoCompleteStringCollection()
            Dim i As Integer = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("ModifierName").ToString())
            Next
            txtModifierName.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtModifierName.AutoCompleteCustomSource = col
            txtModifierName.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub frmDish_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
        fillCombo()
        AutoComplete()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtModifierName.Text = dr.Cells(1).Value.ToString()
                txtMIM_ID.Text = dr.Cells(0).Value.ToString()
                cmbItemName.Text = dr.Cells(2).Value.ToString()
                txtRate.Text = dr.Cells(3).Value.ToString()
                Dim btnColor As Color = Color.FromArgb(dr.Cells(4).Value)
                btnUIColor.BackColor = btnColor
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtServiceTax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtRate.Text
            Dim selectionStart = Me.txtRate.SelectionStart
            Dim selectionLength = Me.txtRate.SelectionLength

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

    Private Sub txtFirstName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchByModifier.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT MIM_ID, RTRIM(ModifierName), RTRIM(Item), RTRIM(Rate),BackColor from Modifiers where ModifierName like '%" & txtSearchByModifier.Text & "%' order by ModifierName", con)
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

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            ' Show the color dialog.
            Dim result As DialogResult = ColorDialog1.ShowDialog()
            ' See if user pressed ok.
            If result = DialogResult.OK Then
                ' Set form background to the selected color.
                Me.btnUIColor.BackColor = ColorDialog1.Color
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtModifierName_LostFocus(sender As Object, e As System.EventArgs) Handles txtModifierName.LostFocus
        txtModifierName.Text = txtModifierName.Text.Trim()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        frmModifiersExportImport.Reset()
        frmModifiersExportImport.ShowDialog()
    End Sub
End Class
