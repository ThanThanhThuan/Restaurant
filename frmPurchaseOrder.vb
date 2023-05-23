Imports System.Data.SqlClient
Imports System.IO

Public Class frmPurchaseOrder
    Dim str As String
    Public st, lblname As String
    Dim num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11 As Decimal
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 PO_ID FROM PurchaseOrder ORDER BY PO_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("PO_ID")
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
    Sub GetRegisteredUserName(ByVal st As String)
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT RTRIM(Name) from Registration where UserID=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", st)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                lblname = rdr.GetValue(0)
            Else
                lblname = ""
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub auto()
        Try
            txtPO_ID.Text = GenerateID()
            txtPONo.Text = "PO-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Sub Reset()
        txtSupplierID.Text = ""
        txtSupplierName.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtContactNo.Text = ""
        txtVAT.Text = "0.00"
        txtVATAmt.Text = "0.00"
        txtSubTotal.Text = "0.00"
        txtSup_ID.Text = ""
        txtGrandTotal.Text = ""
        txtPONo.Text = ""
        txtTerms.Text = ""
        dtpDate.Value = Today
        btnSave.Enabled = True
        btnDelete.Enabled = False
        DataGridView1.Enabled = True
        btnAdd.Enabled = True
        pnlCalc.Enabled = True
        btnRemove.Enabled = False
        lblBalance.Text = "0.00"
        txtPONo.ReadOnly = False
        txtPONo.BackColor = Color.White
        DataGridView1.Rows.Clear()
        cmbTaxType.SelectedIndex = 1
        cmbTaxType.Enabled = True
        btnSelection.Enabled = True
        btnPrint.Enabled = False
        lblSet.Text = ""
        txtEmailID.Text = ""
        Clear()
        auto()
    End Sub

    Public Function SubTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(4).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub Clear()
        cmbProductName.Text = ""
        cmbProductName.SelectedIndex = -1
        lblUnit.Visible = False
        txtQty.Text = ""
        txtPricePerQty.Text = ""
        txtTotalAmount.Text = ""
        cmbProductName.Focus()
    End Sub

    Sub Compute()
        If cmbTaxType.Text = "Inclusive" Then
            num6 = Val(txtSubTotal.Text) - ((Val(txtSubTotal.Text) / (1 + (Val(txtVAT.Text) / 100))))
            num6 = Math.Round(num6, 2)
            txtVATAmt.Text = num6
            num1 = Val(txtSubTotal.Text)
            num1 = Math.Round(num1, 2)
            txtGrandTotal.Text = num1
        Else
            num6 = (Val(txtSubTotal.Text) * Val(txtVAT.Text)) / 100
            num6 = Math.Round(num6, 2)
            txtVATAmt.Text = num6
            num1 = num6 + Val(txtSubTotal.Text)
            num1 = Math.Round(num1, 2)
            txtGrandTotal.Text = num1
        End If

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
        fillCombo()
    End Sub

    Private Sub txtPricePerQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPricePerQty.TextChanged
        Calc()
    End Sub

    Sub Calc()
        Dim i As Double = 0
        i = CDbl(Val(txtQty.Text) * Val(txtPricePerQty.Text))
        i = Math.Round(i, 2)
        txtTotalAmount.Text = i
    End Sub
    Private Sub txtQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQty.TextChanged
        Calc()
    End Sub

    Private Sub txtQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtQty.Text
            Dim selectionStart = Me.txtQty.SelectionStart
            Dim selectionLength = Me.txtQty.SelectionLength

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

    Private Sub txtPricePerQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPricePerQty.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtPricePerQty.Text
            Dim selectionStart = Me.txtPricePerQty.SelectionStart
            Dim selectionLength = Me.txtPricePerQty.SelectionLength

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

    Private Sub txtTotalPayment_TextChanged(sender As System.Object, e As System.EventArgs)
        Compute()
    End Sub
    Sub GetSupplierBalance()
        Try
            Try
                num1 = 0
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from LedgerBook where PartyID=@d1 group By PartyID"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@d1", txtSupplierID.Text)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If (rdr.Read() = True) Then
                    num1 = rdr.GetValue(0)
                End If
                con.Close()
                lblBalance.Text = num1
                If Val(lblBalance.Text) >= 0 Then
                    str = "CR"
                ElseIf Val(lblBalance.Text < 0) Then
                    str = "DR"
                End If
                lblBalance.Text = Math.Abs(Val(lblBalance.Text))
                lblBalance.Text = (lblBalance.Text & " " & str).ToString()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub GetSupplierInfo()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT SupplierID,Name,Address,City,ContactNo from Supplier Where ID=@d1"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtSup_ID.Text))
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                txtSupplierID.Text = rdr.GetValue(0)
                txtSupplierName.Text = rdr.GetValue(1)
                txtAddress.Text = rdr.GetValue(2)
                txtCity.Text = rdr.GetValue(3)
                txtContactNo.Text = rdr.GetValue(4)
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from PurchaseOrder where PO_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtPO_ID.Text))
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                LogFunc(lblUser.Text, "deleted the purchase order record having PO No. '" & txtPONo.Text & "'")
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

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnSelection.Click
        frmSupplierRecord.lblSet.Text = "Purchase Order"
        frmSupplierRecord.Reset()
        frmSupplierRecord.ShowDialog()
    End Sub

    Private Sub txtDiscPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVAT.TextChanged
        Compute()
    End Sub

    Private Sub txtSubTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubTotal.TextChanged
        Compute()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtPONo.Text = "" Then
            MessageBox.Show("Please enter PO No.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPONo.Focus()
            Exit Sub
        End If
        If txtSup_ID.Text = "" Then
            MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierID.Focus()
            Exit Sub
        End If
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Sorry no product info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select PONumber from PurchaseOrder where PONumber=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtPONo.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Purchase Order No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtPONo.Text = ""
                txtPONo.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into PurchaseOrder(PO_ID,PONumber, Date,Supplier_ID,Terms,SubTotal,VATPer,VATAmount,GrandTotal,TaxType) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d11,@d12)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtPO_ID.Text))
            cmd.Parameters.AddWithValue("@d2", txtPONo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", Val(txtSup_ID.Text))
            cmd.Parameters.AddWithValue("@d5", txtTerms.Text)
            cmd.Parameters.AddWithValue("@d6", Val(txtSubTotal.Text))
            cmd.Parameters.AddWithValue("@d7", Val(txtVAT.Text))
            cmd.Parameters.AddWithValue("@d8", Val(txtVATAmt.Text))
            cmd.Parameters.AddWithValue("@d11", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d12", cmbTaxType.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into PurchaseOrder_Join(PurchaseOrderID,ProductID,Qty,PricePerUnit,Amount) VALUES (" & txtPO_ID.Text & ",@d1,@d2,@d3,@d4)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            LogFunc(lblUser.Text, "added the new Purchase Order having PO No. '" & txtPONo.Text & "'")
            MessageBox.Show("Successfully saved", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            con.Close()
            btnPrint.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillCombo()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            Dim ctn1 As String = "SELECT ProductName FROM Product order by 1"
            cmd = New SqlCommand(ctn1)
            cmd.Connection = con
            cmbProductName.Items.Clear()
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                cmbProductName.Items.Add(rdr(0).ToString())
            End While
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
        frmPurchaseOrderRecord.lblSet.Text = "PO"
        frmPurchaseOrderRecord.Reset()
        frmPurchaseOrderRecord.ShowDialog()
    End Sub

    Private Sub cmbProductName_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbProductName.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub cmbProductName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbProductName.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT PID,RTRIM(Unit),RTRIM(Price) from Product where ProductName=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbProductName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                lblUnit.Visible = True
                txtProductID.Text = rdr.GetValue(0)
                lblUnit.Text = rdr.GetValue(1)
                txtPricePerQty.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            txtQty.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnItems_Click(sender As Object, e As EventArgs) Handles btnItems.Click
        frmPurchaseItemOrder.lblUser.Text = lblUser.Text
        Dim p As New frmPurchaseItemOrder()
        p.ShowDialog()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbProductName.Text = "" Then
                MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbProductName.Focus()
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
            If txtPricePerQty.Text = "" Then
                MessageBox.Show("Please enter price per unit", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPricePerQty.Focus()
                Exit Sub
            End If
            If Val(txtPricePerQty.Text = 0) Then
                MessageBox.Show("Price per unit can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPricePerQty.Focus()
                Exit Sub
            End If

            If DataGridView1.Rows.Count = 0 Then
                DataGridView1.Rows.Add(Val(txtProductID.Text), cmbProductName.Text, Val(txtQty.Text), Val(txtPricePerQty.Text), Val(txtTotalAmount.Text))
                Dim k As Double = 0
                k = SubTotal()
                k = Math.Round(k, 2)
                txtSubTotal.Text = k
                Clear()
                Exit Sub
            End If
            For Each row As DataGridViewRow In DataGridView1.Rows
                If txtProductID.Text = row.Cells(0).Value Then
                    MessageBox.Show("Already added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next
            DataGridView1.Rows.Add(Val(txtProductID.Text), cmbProductName.Text, Val(txtQty.Text), Val(txtPricePerQty.Text), Val(txtTotalAmount.Text))
            Dim k1 As Double = 0
            k1 = SubTotal()
            k1 = Math.Round(k1, 2)
            txtSubTotal.Text = k1
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
            Dim k As Double = 0
            k = SubTotal()
            k = Math.Round(k, 2)
            txtSubTotal.Text = k
            Compute()
            btnRemove.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtDiscPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtVAT.KeyPress
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

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If txtPONo.Text = "" Then
            MessageBox.Show("Please enter PO No.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPONo.Focus()
            Exit Sub
        End If
        If txtSup_ID.Text = "" Then
            MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierID.Focus()
            Exit Sub
        End If
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Sorry no product info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try

            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update PurchaseOrder Set PONumber=@d2, Date=@d3,Supplier_ID=@d4,Terms=@d5,SubTotal=@d6,VATPer=@d7,VATAmount=@d8,GrandTotal=@d11 where PO_ID=@d1 "
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtPO_ID.Text))
            cmd.Parameters.AddWithValue("@d2", txtPONo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", Val(txtSup_ID.Text))
            cmd.Parameters.AddWithValue("@d5", txtTerms.Text)
            cmd.Parameters.AddWithValue("@d6", Val(txtSubTotal.Text))
            cmd.Parameters.AddWithValue("@d7", Val(txtVAT.Text))
            cmd.Parameters.AddWithValue("@d8", Val(txtVATAmt.Text))
            cmd.Parameters.AddWithValue("@d11", Val(txtGrandTotal.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from PurchaseOrder_Join where PurchaseOrderID=" & txtPO_ID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into PurchaseOrder_Join(PurchaseOrderID,ProductID,Qty,PricePerUnit,Amount) VALUES (" & txtPO_ID.Text & ",@d1,@d2,@d3,@d4)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            LogFunc(lblUser.Text, "Updated the Purchase Order having PO No. '" & txtPONo.Text & "'")
            MessageBox.Show("Successfully Updated", "Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtAddVATAmount_TextChanged(sender As System.Object, e As System.EventArgs)
        Compute()
    End Sub

    Private Sub txtADDVAT_TextChanged(sender As System.Object, e As System.EventArgs)
        Compute()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptPurchaseOrder 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT TaxType, PurchaseOrder.PO_ID, PurchaseOrder.PONumber, PurchaseOrder.Date, PurchaseOrder.Supplier_ID, PurchaseOrder.Terms, PurchaseOrder.SubTotal, PurchaseOrder.VATPer, PurchaseOrder.VATAmount, PurchaseOrder.GrandTotal, PurchaseOrder_Join.POJ_ID, PurchaseOrder_Join.PurchaseOrderID, PurchaseOrder_Join.ProductID, PurchaseOrder_Join.Qty,PurchaseOrder_Join.PricePerUnit, PurchaseOrder_Join.Amount, Product.PID, Product.ProductCode, Product.ProductName,  Product.Unit, Supplier.ID, Supplier.SupplierID, Supplier.Name,Supplier.Address, Supplier.City, Supplier.State, Supplier.ZipCode, Supplier.ContactNo, Supplier.EmailID, Supplier.Remarks, Supplier.TIN, Supplier.STNo, Supplier.CST, Supplier.PAN, Supplier.AccountName,Supplier.AccountNumber, Supplier.Bank, Supplier.Branch, Supplier.IFSCCode, Supplier.OpeningBalance, Supplier.OpeningBalanceType FROM PurchaseOrder INNER JOIN PurchaseOrder_Join ON PurchaseOrder.PO_ID = PurchaseOrder_Join.PurchaseOrderID INNER JOIN Product ON PurchaseOrder_Join.ProductID = Product.PID INNER JOIN Supplier ON PurchaseOrder.Supplier_ID = Supplier.ID where PO_ID=" & Val(txtPO_ID.Text) & ""
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "PurchaseOrder")
            myDA.Fill(myDS, "PurchaseOrder_Join")
            myDA.Fill(myDS, "Supplier")
            myDA.Fill(myDS, "Product")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            GetRegisteredUserName(lblUser.Text)
            rpt.SetParameterValue("p1", lblname)
            frmPO_CRViewer.CrystalReportViewer1.ReportSource = rpt
            frmPO_CRViewer.txtEmailID.Text = txtEmailID.Text
            frmPO_CRViewer.lblUser.Text = lblUser.Text
            frmPO_CRViewer.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub cmbTaxType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbTaxType.SelectedIndexChanged
        Calc()
        Compute()
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class
