﻿Imports System.Data.SqlClient
Public Class frmMenuItemsCategory
    Sub fillCombo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(KitchenName) FROM Kitchen order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbKitchen.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbKitchen.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        txtCategory.Text = ""
        cmbKitchen.SelectedIndex = -1
        txtCategory.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnUIColor.BackColor = Color.DimGray
        GetTaxes()
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtCategory.Text = "" Then
            MessageBox.Show("Please enter category name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCategory.Focus()
            Return
        End If
        If cmbKitchen.Text = "" Then
            MessageBox.Show("Please select kitchen", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbKitchen.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select CategoryName from Category where CategoryName=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtCategory.Text)
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Category Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtCategory.Text = ""
                txtCategory.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into Category(CategoryName,VAT,ST,SC,BackColor,Kitchen) VALUES (@d1," & Val(txtVAT.Text) & "," & Val(txtServiceTax.Text) & "," & Val(txtSCPer.Text) & ",@d2,@d3)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtCategory.Text)
            cmd.Parameters.AddWithValue("@d2", btnUIColor.BackColor.ToArgb())
            cmd.Parameters.AddWithValue("@d3", cmbKitchen.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new category '" & txtCategory.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Category", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset()
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
            Dim cl As String = "select CategoryName from Dish,Category where Dish.Category=Category.CategoryName and CategoryName=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtCategory.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Menu Items Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Category where CategoryName=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtCategory.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the category '" & txtCategory.Text & "'"
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
            If txtCategory.Text = "" Then
                MessageBox.Show("Please enter category name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCategory.Focus()
                Return
            End If
            If cmbKitchen.Text = "" Then
                MessageBox.Show("Please select kitchen", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbKitchen.Focus()
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "update RestaurantPOS_OrderedProductKOT set Category=@d1 where Category=@d2"
            cmd = New SqlCommand(cb2)
            cmd.Parameters.AddWithValue("@d1", txtCategory.Text)
            cmd.Parameters.AddWithValue("@d2", txtCategoryName.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb3 As String = "update RestaurantPOS_OrderedProductBillTA set Category=@d1 where Category=@d2"
            cmd = New SqlCommand(cb3)
            cmd.Parameters.AddWithValue("@d1", txtCategory.Text)
            cmd.Parameters.AddWithValue("@d2", txtCategoryName.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb4 As String = "update RestaurantPOS_OrderedProductBillKOT set Category=@d1 where Category=@d2"
            cmd = New SqlCommand(cb4)
            cmd.Parameters.AddWithValue("@d1", txtCategory.Text)
            cmd.Parameters.AddWithValue("@d2", txtCategoryName.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb5 As String = "update RestaurantPOS_OrderedProductBillEB set Category=@d1 where Category=@d2"
            cmd = New SqlCommand(cb5)
            cmd.Parameters.AddWithValue("@d1", txtCategory.Text)
            cmd.Parameters.AddWithValue("@d2", txtCategoryName.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb6 As String = "update RestaurantPOS_OrderedProductBillHD set Category=@d1 where Category=@d2"
            cmd = New SqlCommand(cb6)
            cmd.Parameters.AddWithValue("@d1", txtCategory.Text)
            cmd.Parameters.AddWithValue("@d2", txtCategoryName.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update Category set CategoryName=@d1,VAT=" & Val(txtVAT.Text) & ",ST=" & Val(txtServiceTax.Text) & ",SC=" & Val(txtSCPer.Text) & ",BackColor=@d3,Kitchen=@d4 where CategoryName=@d2"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtCategory.Text)
            cmd.Parameters.AddWithValue("@d2", txtCategoryName.Text)
            cmd.Parameters.AddWithValue("@d3", btnUIColor.BackColor.ToArgb())
            cmd.Parameters.AddWithValue("@d4", cmbKitchen.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "updated the category '" & txtCategory.Text & "' details"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Category Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            cmd = New SqlCommand("SELECT RTRIM(CategoryName),RTRIM(Kitchen), (VAT), (ST),SC,BackColor from Category order by CategoryName", con)
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

    Private Sub frmCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
        GetTaxes()
        fillCombo()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtCategory.Text = dr.Cells(0).Value.ToString()
                txtCategoryName.Text = dr.Cells(0).Value.ToString()
                cmbKitchen.Text = dr.Cells(1).Value.ToString()
                txtVAT.Text = dr.Cells(2).Value.ToString()
                txtServiceTax.Text = dr.Cells(3).Value.ToString()
                txtSCPer.Text = dr.Cells(4).Value.ToString()
                Dim btnColor As Color = Color.FromArgb(dr.Cells(5).Value)
                btnUIColor.BackColor = btnColor
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtVAT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVAT.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtVAT.Text
            Dim selectionStart = Me.txtVAT.SelectionStart
            Dim selectionLength = Me.txtVAT.SelectionLength

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

    Private Sub txtServiceTax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServiceTax.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtServiceTax.Text
            Dim selectionStart = Me.txtServiceTax.SelectionStart
            Dim selectionLength = Me.txtServiceTax.SelectionLength

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
    Sub GetTaxes()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT IsNull(ServiceTax,0.00),IsNull(VAT,0.00),IsNull(ServiceCharges,0.00) from OtherSetting"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtServiceTax.Text = rdr.GetValue(0)
                txtVAT.Text = rdr.GetValue(1)
                txtSCPer.Text = rdr.GetValue(2)
            Else
                txtServiceTax.Text = "0.00"
                txtVAT.Text = "0.00"
                txtSCPer.Text = "0.00"
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSCPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSCPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtSCPer.Text
            Dim selectionStart = Me.txtSCPer.SelectionStart
            Dim selectionLength = Me.txtSCPer.SelectionLength

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

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        frmCategoriesExportImport.Reset()
        frmCategoriesExportImport.ShowDialog()
    End Sub
End Class
