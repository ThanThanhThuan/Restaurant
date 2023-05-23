Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Public Class frmMenuItem
    Dim Item As String
    Dim retrieving As New Retrieving()
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
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
            txtBarcode.Text = 10000000 + GenerateID()
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
    Sub fillCombo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbCategory.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbCategory.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        cmbCategory.SelectedIndex = -1
        txtHDRate.Text = ""
        txtTARate.Text = ""
        txtDIRate.Text = ""
        txtSearchByDish.Text = ""
        txtItemName.Text = ""
        txtItemName.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnUIColor.BackColor = Color.DimGray
        chkActive.Checked = True
        txtBarcode.Text = ""
        txtBCode.Text = ""
        Picture.Image = My.Resources._12
        txtImagePath.Text = ""
        auto()
        GenerateBarcode()
        btnUpdateImage.Enabled = False
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtItemName.Text)) = 0 Then
            MessageBox.Show("Please enter item name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtItemName.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbCategory.Text)) = 0 Then
            MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategory.Focus()
            Exit Sub
        End If
        If Len(Trim(txtDIRate.Text)) = 0 Then
            MessageBox.Show("Please enter Dine In rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDIRate.Focus()
            Exit Sub
        End If
        If Len(Trim(txtTARate.Text)) = 0 Then
            MessageBox.Show("Please enter Take Away rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTARate.Focus()
            Exit Sub
        End If
        If Len(Trim(txtHDRate.Text)) = 0 Then
            MessageBox.Show("Please enter Home Delivery rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHDRate.Focus()
            Exit Sub
        End If
        If Len(Trim(txtBarcode.Text)) = 0 Then
            MessageBox.Show("Please enter barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBarcode.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select DishName from Dish where DishName=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Item Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtItemName.Text = ""
                txtItemName.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "select Barcode from Dish where Barcode=@d1"
            cmd = New SqlCommand(ct1)
            cmd.Parameters.AddWithValue("@d1", txtBarcode.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtBarcode.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            If chkActive.Checked = True Then
                Item = "Active"
            Else
                Item = "Inactive"
            End If
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Dish(DishName,Category,DIRate,TARate,HDRate,BackColor,MI_Status,Barcode,DishID,Photo,PurcPrice,UnitPrice) VALUES (@d1,@d2," & Val(txtDIRate.Text) & "," & Val(txtTARate.Text) & "," & Val(txtHDRate.Text) & ",@d3,@d5,@d6," & Val(txtDishID.Text) & ",@d7, " & Val(numPurPrice.Value) & ", " & Val(numSellingPrice.Value) & ")"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbCategory.Text)
            cmd.Parameters.AddWithValue("@d3", btnUIColor.BackColor.ToArgb())
            cmd.Parameters.AddWithValue("@d5", Item)
            cmd.Parameters.AddWithValue("@d6", txtBarcode.Text)
            If (Not System.IO.Directory.Exists(Application.StartupPath & "\Menu Items Image")) Then
                System.IO.Directory.CreateDirectory(Application.StartupPath & "\Menu Items Image")
            End If
            Picture.Image.Save(Application.StartupPath & "\Menu Items Image\" & txtItemName.Text & ".jpg")
            Picture.Image.Dispose()
            cmd.Parameters.AddWithValue("@d7", "\Menu Items Image\" & txtItemName.Text & ".jpg")
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "added the new item '" & txtItemName.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtItemName.Text = ""
            txtDish.Text = ""
            Getdata()
            auto()
            GenerateBarcode()
            Picture.Image = My.Resources._12
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
            Dim sql4 As String = "select Dish.Dishname from Stock_Store_Join,Dish where Stock_Store_Join.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(sql4)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Store Stock Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql3 As String = "select Dish.Dishname from Recipe,Dish where Recipe.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(sql3)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Recipe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql12 As String = "select Dish.Dishname from RestaurantPOS_OrderedProductBillEB,Dish where RestaurantPOS_OrderedProductBillEB.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(sql12)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql11 As String = "select Dish.Dishname from RestaurantPOS_OrderedProductBillHD,Dish where RestaurantPOS_OrderedProductBillHD.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(sql11)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select Dish.Dishname from RestaurantPOS_OrderedProductBillTA,Dish where RestaurantPOS_OrderedProductBillTA.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cl6 As String = "select Dish.Dishname from RestaurantPOS_OrderedProductBillKOT,Dish where RestaurantPOS_OrderedProductBillKOT.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(cl6)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cl2 As String = "select Dish.DishName from RestaurantPOS_OrderedProductKOT,Dish where RestaurantPOS_OrderedProductKOT.Dish=Dish.DishName and Dish.DishName=@d1"
            cmd = New SqlCommand(cl2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Restaurant POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Dish where DishName=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Picture.Image.Dispose()
                My.Computer.FileSystem.DeleteFile(Application.StartupPath & txtImagePath.Text)
                Dim st As String = "deleted the item '" & txtItemName.Text & "'"
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
            If Len(Trim(txtItemName.Text)) = 0 Then
                MessageBox.Show("Please enter item name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtItemName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbCategory.Text)) = 0 Then
                MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbCategory.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDIRate.Text)) = 0 Then
                MessageBox.Show("Please enter Dine In rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDIRate.Focus()
                Exit Sub
            End If
            If Len(Trim(txtTARate.Text)) = 0 Then
                MessageBox.Show("Please enter Take Away rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTARate.Focus()
                Exit Sub
            End If
            If Len(Trim(txtHDRate.Text)) = 0 Then
                MessageBox.Show("Please enter Home Delivery rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtHDRate.Focus()
                Exit Sub
            End If
            If Len(Trim(txtBarcode.Text)) = 0 Then
                MessageBox.Show("Please enter barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcode.Focus()
                Exit Sub
            End If
            If txtBarcode.Text <> txtBCode.Text Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Barcode from Dish where Barcode=@d1"
                cmd = New SqlCommand(ct)
                cmd.Parameters.AddWithValue("@d1", txtBarcode.Text)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    txtBarcode.Text = ""
                    txtBarcode.Focus()
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    Return
                End If
            End If
            If chkActive.Checked = True Then
                Item = "Active"
            Else
                Item = "Inactive"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update Dish set DishName=@d1,Category=@d2,DIRate=" & Val(txtDIRate.Text) & ",TARate=" & Val(txtTARate.Text) & ",HDRate=" & Val(txtHDRate.Text) & ",BackColor=@d4,MI_Status=@d6,Barcode=@d7,Photo=@d8, PurcPrice = " & Val(numPurPrice.Value) & ", UnitPrice = " & Val(numSellingPrice.Value) & " where DishName=@d3"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtItemName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbCategory.Text)
            cmd.Parameters.AddWithValue("@d3", txtDish.Text)
            cmd.Parameters.AddWithValue("@d4", btnUIColor.BackColor.ToArgb())
            cmd.Parameters.AddWithValue("@d6", Item)
            cmd.Parameters.AddWithValue("@d7", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d8", "\Menu Items Image\" & txtItemName.Text & ".jpg")
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "updated the item '" & txtItemName.Text & "' details"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Item Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Getdata()
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(DishName), RTRIM(Category),DIRate,TARate,HDRate,RTRIM(Barcode),BackColor,RTRIM(MI_Status),RTRIM(Photo),PurcPrice,UnitPrice from Dish order by DishName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
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

    Private Sub frmDish_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
        fillCombo()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtItemName.Text = dr.Cells(0).Value.ToString()
                txtDish.Text = dr.Cells(0).Value.ToString()
                cmbCategory.Text = dr.Cells(1).Value.ToString()
                txtDIRate.Text = dr.Cells(2).Value.ToString()
                txtTARate.Text = dr.Cells(3).Value.ToString()
                txtHDRate.Text = dr.Cells(4).Value.ToString()
                txtBarcode.Text = dr.Cells(5).Value.ToString()
                txtBCode.Text = dr.Cells(5).Value.ToString()
                numPurPrice.Value = CType(IIf(dr.Cells(9).Value.ToString() = "", 0, dr.Cells(9).Value), Decimal)
                numSellingPrice.Value = CType(IIf(dr.Cells(10).Value.ToString() = "", 0, dr.Cells(10).Value), Decimal)
                Dim btnColor As Color = Color.FromArgb(dr.Cells(6).Value)
                If dr.Cells(7).Value = "Active" Then
                    chkActive.Checked = True
                Else
                    chkActive.Checked = False
                End If
                btnUpdateImage.Enabled = True
                txtImagePath.Text = dr.Cells(8).Value.ToString()
                btnUIColor.BackColor = btnColor
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtServiceTax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIRate.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDIRate.Text
            Dim selectionStart = Me.txtDIRate.SelectionStart
            Dim selectionLength = Me.txtDIRate.SelectionLength

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
    Private Sub txtFirstName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchByDish.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(DishName), RTRIM(Category),DIRate,TARate,HDRate,RTRIM(Barcode),BackColor,RTRIM(MI_Status),RTRIM(Photo),PurcPrice,UnitPrice from Dish where DishName like '%" & txtSearchByDish.Text & "%' order by DishName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
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

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        frmMenuItemsExportImport.Reset()
        frmMenuItemsExportImport.ShowDialog()
    End Sub

    Private Sub txtTARate_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTARate.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtTARate.Text
            Dim selectionStart = Me.txtTARate.SelectionStart
            Dim selectionLength = Me.txtTARate.SelectionLength

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

    Private Sub txtHDRate_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtHDRate.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtHDRate.Text
            Dim selectionStart = Me.txtHDRate.SelectionStart
            Dim selectionLength = Me.txtHDRate.SelectionLength

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

    Private Sub btnBarcodePrint_Click(sender As System.Object, e As System.EventArgs) Handles btnBarcodePrint.Click
        frmBarcodeLabelPrinting.Reset()
        frmBarcodeLabelPrinting.ShowDialog()
    End Sub

    Private Sub Browse_Click(sender As System.Object, e As System.EventArgs) Handles Browse.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Picture.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub BRemove_Click(sender As System.Object, e As System.EventArgs) Handles BRemove.Click
        Picture.Image = My.Resources._12
    End Sub

    Private Sub btnUpdateImage_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdateImage.Click
        Try
            If (Not System.IO.Directory.Exists(Application.StartupPath & "\Menu Items Image")) Then
                System.IO.Directory.CreateDirectory(Application.StartupPath & "\Menu Items Image")
            End If
            Picture.Image.Save(Application.StartupPath & "\Menu Items Image\" & txtItemName.Text & ".jpg")
            MessageBox.Show("Successfully updated", "Item Image", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Getdata()
            Reset()
        Catch ex As Exception
            MessageBox.Show("Unable to update image because same image is " & vbCrLf & "already used by another process." & vbCrLf & "restart the application and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class
