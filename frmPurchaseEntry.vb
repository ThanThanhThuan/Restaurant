﻿Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmPurchaseEntry
    Dim str As String
    Dim st As String
    Dim OBtype As String
    Dim num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11 As Decimal
    Dim filled As Integer
    Dim dtPOItems As DataTable = New DataTable
    Dim dtPO As DataTable = New DataTable
    Dim BackFromSup As Boolean = False
    Dim dicPOItem As Dictionary(Of Integer, DataTable) = New Dictionary(Of Integer, DataTable)



    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 ST_ID FROM Purchase ORDER BY ST_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ST_ID")
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
    Sub auto()
        Try
            txtST_ID.Text = GenerateID()
            txtInvoiceNo.Text = "ST-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Sub Reset()
        txtAddress.Text = ""
        txtBalance.Text = ""
        txtCity.Text = ""
        txtContactNo.Text = ""
        txtDiscPer.Text = "0.00"
        txtDisc.Text = "0.00"
        txtSubTotal.Text = ""
        txtTotal.Text = ""
        txtSupplierID.Text = ""
        txtSupplierName.Text = ""
        txtSup_ID.Text = ""
        txtVATPer.Text = "0.00"
        txtVATAmt.Text = "0.00"
        txtFreightCharges.Text = "0.00"
        txtGrandTotal.Text = ""
        txtInvoiceNo.Text = ""
        txtOtherCharges.Text = "0.00"
        txtPreviousDue.Text = "0.00"
        txtRemarks.Text = ""
        txtRoundOff.Text = "0.00"
        txtTotalPaid.Text = "0.00"
        cmbPurchaseType.SelectedIndex = 1

        BindingNavigator1.BindingSource = Nothing
        RemoveHandler cmbInvoice.SelectedIndexChanged, AddressOf cmbInvoiceKSelectedIndexChanged
        Me.cmbInvoice.DataSource = Nothing

        dtpDate.Value = Today
        btnSave.Enabled = True
        btnDelete.Enabled = False
        DataGridView1.Enabled = True
        btnAdd.Enabled = True
        pnlCalc.Enabled = True
        btnRemove.Enabled = False
        lblBalance.Text = "0.00"
        txtTotalPaid.ReadOnly = True
        txtTotalPaid.Enabled = False
        DataGridView1.Rows.Clear()
        btnSelection.Enabled = True
        lblSet.Text = ""
        Clear()
        auto()
    End Sub

    Public Function SubTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(5).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub Clear()
        cmbProductName.Text = ""
        cmbWarehouse.SelectedIndex = -1
        lblUnit.Visible = False
        chkHasExpiryDate.Checked = False
        dtpExpiryDate.Enabled = False
        txtQty.Text = ""
        txtPricePerQty.Text = ""
        txtTotalAmount.Text = ""
        dtpExpiryDate.Value = Today
    End Sub
    Sub Compute()
        num6 = (Val(txtSubTotal.Text) * Val(txtDiscPer.Text)) / 100
        num6 = Math.Round(num6, 2)
        txtDisc.Text = num6
        num7 = Val(txtSubTotal.Text) - num6
        num8 = (num7 * Val(txtVATPer.Text)) / 100
        num8 = Math.Round(num8, 2)
        txtVATAmt.Text = num8
        num1 = num7 + Val(txtFreightCharges.Text) + Val(txtOtherCharges.Text) + Val(txtPreviousDue.Text) + Val(txtVATAmt.Text)
        num1 = Math.Round(num1, 2)
        txtTotal.Text = num1
        num2 = Math.Round(num1, 1)
        num3 = num2 - num1
        num3 = Math.Round(num3, 2)
        txtRoundOff.Text = num3
        num4 = Val(txtTotal.Text) + Val(txtRoundOff.Text)
        num4 = Math.Round(num4, 2)
        txtGrandTotal.Text = num4
        num5 = Val(txtGrandTotal.Text) - Val(txtTotalPaid.Text)
        num5 = Math.Round(num5, 2)
        txtBalance.Text = num5
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
        fillInvoiceCombo(-1)
        FillWarehouse()
        BindingNavigator1.BindingSource = Nothing
        RemoveHandler cmbInvoice.SelectedIndexChanged, AddressOf cmbInvoiceKSelectedIndexChanged
        con = New SqlConnection(cs)
        con.Open()
        Dim cq As String = "IF COL_LENGTH('Purchase', 'PO_ID') IS NULL
            BEGIN
                ALTER TABLE Purchase
                ADD [PO_ID] INT
            END"
        cmd = New SqlCommand(cq)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub txtPricePerQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPricePerQty.TextChanged
        Dim i As Double = 0
        i = CDbl(Val(txtQty.Text) * Val(txtPricePerQty.Text))
        i = Math.Round(i, 2)
        txtTotalAmount.Text = i
    End Sub


    Private Sub txtQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQty.TextChanged
        Dim i As Double = 0
        i = CDbl(Val(txtQty.Text) * Val(txtPricePerQty.Text))
        i = Math.Round(i, 2)
        txtTotalAmount.Text = i
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

    Private Sub txtTotalPayment_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Exit Sub
    End Sub
    Sub GetSupplierBalance()
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
            txtPreviousDue.Text = num1
            lblBalance.Text = Math.Abs(Val(lblBalance.Text))
            lblBalance.Text = (lblBalance.Text & " " & str).ToString()
            Compute()
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
    Sub GetSupplierBalance1()
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
                Compute()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Purchase where ST_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtST_ID.Text))
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            con.Close()
            If RowsAffected > 0 Then
                For Each row As DataGridViewRow In DataGridView1.Rows
                    SqlConnection.ClearAllPools()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select WareHouse,ProductID,ExpiryDate from temp_Stock where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(7).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        SqlConnection.ClearAllPools()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty=Qty - " & Val(row.Cells(3).Value) & " where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(2).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(7).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                Next
                LedgerDelete(txtInvoiceNo.Text, "Purchase Invoice")
                LogFunc(lblUser.Text, "deleted the purchase record having Invoice No. '" & txtInvoiceNo.Text & "'")
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
        frmSupplierRecord.lblSet.Text = "Purchase"
        frmSupplierRecord.Reset()
        'BackFromSup = True
        'cmbInvoice.DataSource = Nothing
        'Me.cmbInvoice.Items.Clear() 
        'RemoveAllHandlers cmbInvoice
        RemoveHandler cmbInvoice.SelectedIndexChanged, AddressOf cmbInvoiceKSelectedIndexChanged
        frmSupplierRecord.ShowDialog()
        'zz

        fillInvoiceCombo(txtSupplierID.Text)
        AddHandler cmbInvoice.SelectedIndexChanged, AddressOf cmbInvoiceKSelectedIndexChanged
    End Sub
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If cmbInvoice.Text IsNot "" Then
            If cmbWarehouse.Text = "" Then
                MessageBox.Show("Please select warehouse before proceed!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return
            End If
        End If
        If Len(Trim(txtSupplierID.Text)) = 0 Then
            MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierID.Focus()
            Exit Sub
        End If
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Sorry no product info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Len(Trim(txtDiscPer.Text)) = 0 Then
            MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDiscPer.Focus()
            Exit Sub
        End If
        If Len(Trim(txtFreightCharges.Text)) = 0 Then
            MessageBox.Show("Please enter freight charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFreightCharges.Focus()
            Exit Sub
        End If
        If Len(Trim(txtOtherCharges.Text)) = 0 Then
            MessageBox.Show("Please enter other charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOtherCharges.Focus()
            Exit Sub
        End If
        If Len(Trim(txtRoundOff.Text)) = 0 Then
            MessageBox.Show("Please enter round off", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoundOff.Focus()
            Exit Sub
        End If
        Try
            filled = 0
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells("Column2").Value = Nothing Then
                    filled += filled + 1
                Else
                    filled += filled - 1
                End If
            Next
            If filled < 0 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select InvoiceNo from Purchase where InvoiceNo=@d1"
                cmd = New SqlCommand(ct)
                cmd.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    MessageBox.Show("Invoice No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    txtInvoiceNo.Text = ""
                    txtInvoiceNo.Focus()
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    Return
                End If
                con.Close()
                For Each row As DataGridViewRow In DataGridView1.Rows
                    SqlConnection.ClearAllPools()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctX As String = "select WareHouse,ProductID,ExpiryDate from temp_Stock where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(ctX)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(7).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        SqlConnection.ClearAllPools()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty=Qty + " & Val(row.Cells(3).Value) & " where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(2).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(7).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    Else
                        SqlConnection.ClearAllPools()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb3 As String = "Insert Into Temp_Stock(Warehouse,ProductID,Qty,HasExpiryDate,ExpiryDate) values (@d1,@d2,@d3,@d4,@d5)"
                        cmd = New SqlCommand(cb3)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(2).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d4", row.Cells(6).Value)
                        cmd.Parameters.AddWithValue("@d5", row.Cells(7).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                Next
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "insert into Purchase(ST_ID, InvoiceNo, Date,PurchaseType, Supplier_ID, SubTotal, DiscountPer, Discount, PreviousDue, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, Remarks,HSTPer,HST,PO_ID) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17," & Val(txtVATPer.Text) & "," & Val(txtVATAmt.Text) & ",@poid)"
                cmd = New SqlCommand(cb)
                cmd.Parameters.AddWithValue("@d1", Val(txtST_ID.Text))
                cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
                cmd.Parameters.AddWithValue("@d3", dtpDate.Value.Date)
                cmd.Parameters.AddWithValue("@d4", cmbPurchaseType.Text)
                cmd.Parameters.AddWithValue("@d5", Val(txtSup_ID.Text))
                cmd.Parameters.AddWithValue("@d6", Val(txtSubTotal.Text))
                cmd.Parameters.AddWithValue("@d7", Val(txtDiscPer.Text))
                cmd.Parameters.AddWithValue("@d8", Val(txtDisc.Text))
                cmd.Parameters.AddWithValue("@d9", Val(txtPreviousDue.Text))
                cmd.Parameters.AddWithValue("@d10", Val(txtFreightCharges.Text))
                cmd.Parameters.AddWithValue("@d11", Val(txtOtherCharges.Text))
                cmd.Parameters.AddWithValue("@d12", Val(txtTotal.Text))
                cmd.Parameters.AddWithValue("@d13", Val(txtRoundOff.Text))
                cmd.Parameters.AddWithValue("@d14", Val(txtGrandTotal.Text))
                cmd.Parameters.AddWithValue("@d15", Val(txtTotalPaid.Text))
                cmd.Parameters.AddWithValue("@d16", Val(txtBalance.Text))
                cmd.Parameters.AddWithValue("@d17", txtRemarks.Text)
                cmd.Parameters.AddWithValue("@poid", If(Me.cmbInvoice.SelectedValue, -1))
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                SqlConnection.ClearAllPools()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into Purchase_Join(PurchaseID,ProductID,Warehouse,Qty,Price,TotalAmount,HasExpiryDate,ExpiryDate) VALUES (" & txtST_ID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d2", row.Cells(2).Value)
                        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d6", (row.Cells(6).Value))
                        cmd.Parameters.AddWithValue("@d7", (row.Cells(7).Value))
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                LedgerSave(dtpDate.Value.Date, txtSupplierName.Text, txtInvoiceNo.Text, "Purchase Invoice", 0, Val(txtGrandTotal.Text) - Val(txtPreviousDue.Text), txtSupplierID.Text, "Purchase A/c")
                LedgerSave(dtpDate.Value.Date, "Purchase A/c", txtInvoiceNo.Text, "Purchase Invoice", Val(txtGrandTotal.Text) - Val(txtPreviousDue.Text), 0, "", txtSupplierName.Text)
                LogFunc(lblUser.Text, "added the new Purchase having Invoice No. '" & txtInvoiceNo.Text & "'")
                MessageBox.Show("Successfully saved", "Purchase", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSave.Enabled = False
                con.Close()
                fillInvoiceCombo(-1)
            Else
                MessageBox.Show("Please check your records, missing warehouse!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillCombo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT ProductName FROM Product order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbProductName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbProductName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function Qry2Table(qr As String) As DataTable
        Dim CN As New SqlConnection(cs)
        CN.Open()
        Dim adp0 = New SqlDataAdapter()
        adp0.SelectCommand = New SqlCommand(qr, CN)
        Dim ds0 = New DataSet("ds0")
        adp0.Fill(ds0)
        CN.Close()
        Return ds0.Tables(0)
    End Function
    Sub fillInvoiceCombo(ByVal supID As String)
        Try
            dicPOItem = New Dictionary(Of Integer, DataTable)
            Dim HasDonePOs As New List(Of DataRow)
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT PO_ID,([PONumber] + ' ['+FORMAT([GrandTotal], 'N2')+']') AS Invoice FROM [dbo].[PurchaseOrder] WHERE [PO_ID] NOT IN(SELECT [PurchaseOrderID] FROM [dbo].[PurchaseItemOrder_Join]) AND Supplier_ID IN(SELECT TOP 1 [ID] FROM [dbo].[Supplier] WHERE SupplierID = '" & supID & "')", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtPO = ds.Tables(0)
            '----
            'Dim dPOItems As New DataTable
            For Each r As DataRow In dtPO.Rows
                Dim qr2 = "SELECT P.[ST_ID]
                      ,P.[InvoiceNo]
                         ,P.[PO_ID]
	                  ,J.ProductID
	                  ,j.Qty
                  From [Purchase] P left Join [Purchase_Join] J on P.[ST_ID] = J.PurchaseID
                  Where P.PO_ID = " & r.Item(0)
                Dim dPUItems = Qry2Table(qr2)
                '---
                Dim dPOItems = Qry2Table("SELECT PU.[POJ_ID],PU.[PurchaseOrderID],PU.[ProductID],PU.[Qty],PU.[PricePerUnit],PU.[Amount],PR.[ProductName]  FROM [PurchaseOrder_Join] PU left join [Product] PR on PU.ProductID = PR.PID where PU.[PurchaseOrderID] = " & r.Item(0))
                For Each rpo As DataRow In dPOItems.Rows
                    For Each rpu As DataRow In dPUItems.Rows
                        If rpo.Item("ProductID") = rpu.Item("ProductID") Then
                            Dim re As Decimal = rpo.Item("Qty") - rpu.Item("Qty")
                            rpo.Item("Qty") = re
                            rpo.Item("Amount") = rpo.Item("PricePerUnit") * re
                        End If
                    Next
                Next
                Dim HasDone As Boolean = True
                For Each rpo As DataRow In dPOItems.Rows
                    If rpo.Item("Qty") > 0 Then
                        HasDone = False
                        Exit For
                    End If
                Next
                If Not HasDone Then
                    dicPOItem.Add(r.Item(0), dPOItems)
                Else
                    HasDonePOs.Add(r)
                End If
            Next
            '----
            For Each p As DataRow In HasDonePOs
                dtPO.Rows.Remove(p)
                'dtPO.AcceptChanges()
            Next
            If dtPO.Rows.Count > 0 Then
                cmbInvoice.DataSource = dtPO
                cmbInvoice.DisplayMember = "Invoice"
                cmbInvoice.ValueMember = "PO_ID"
                cmbInvoice.SelectedIndex = -1
            End If



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
        frmPurchaseRecord.lblSet.Text = "Purchase"
        frmPurchaseRecord.Reset()
        frmPurchaseRecord.ShowDialog()
    End Sub

    Private Sub cmbProductName_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbProductName.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub cmbProductName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbProductName.SelectedIndexChanged
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
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbProductName.Text = "" Then
                MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbProductName.Focus()
                Exit Sub
            End If
            If cmbWarehouse.Text = "" Then
                MessageBox.Show("Please select warehouse", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbWarehouse.Focus()
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
            If chkHasExpiryDate.Checked = True Then
                st = "Yes"
            Else
                st = "No"
            End If
            If DataGridView1.Rows.Count = 0 And chkHasExpiryDate.Checked = True Then
                DataGridView1.Rows.Add(Val(txtProductID.Text), cmbProductName.Text, cmbWarehouse.Text, Val(txtQty.Text), Val(txtPricePerQty.Text), Val(txtTotalAmount.Text), st, dtpExpiryDate.Text)
                Dim k As Double = 0
                k = SubTotal()
                k = Math.Round(k, 2)
                txtSubTotal.Text = k
                Clear()
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 And chkHasExpiryDate.Checked = False Then
                DataGridView1.Rows.Add(Val(txtProductID.Text), cmbProductName.Text, cmbWarehouse.Text, Val(txtQty.Text), Val(txtPricePerQty.Text), Val(txtTotalAmount.Text), st, "")
                Dim k As Double = 0
                k = SubTotal()
                k = Math.Round(k, 2)
                txtSubTotal.Text = k
                Clear()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If r.Cells(0).Value = Val(txtProductID.Text) And r.Cells(2).Value = cmbWarehouse.Text And r.Cells(7).Value = dtpExpiryDate.Text And r.Cells(4).Value = Val(txtPricePerQty.Text) Then
                    r.Cells(0).Value = txtProductID.Text
                    r.Cells(1).Value = cmbProductName.Text
                    r.Cells(2).Value = cmbWarehouse.Text
                    r.Cells(4).Value = Val(txtPricePerQty.Text)
                    r.Cells(3).Value = Val(r.Cells(3).Value) + Val(txtQty.Text)
                    r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtTotalAmount.Text)
                    r.Cells(6).Value = st
                    r.Cells(7).Value = dtpExpiryDate.Text
                    Dim i As Double = 0
                    i = SubTotal()
                    i = Math.Round(i, 2)
                    txtSubTotal.Text = i
                    Clear()
                    Exit Sub
                End If
            Next
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If r.Cells(0).Value = Val(txtProductID.Text) And r.Cells(2).Value = cmbWarehouse.Text And r.Cells(7).Value = "" And r.Cells(4).Value = Val(txtPricePerQty.Text) Then
                    r.Cells(0).Value = txtProductID.Text
                    r.Cells(1).Value = cmbProductName.Text
                    r.Cells(2).Value = cmbWarehouse.Text
                    r.Cells(4).Value = Val(txtPricePerQty.Text)
                    r.Cells(3).Value = Val(r.Cells(3).Value) + Val(txtQty.Text)
                    r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtTotalAmount.Text)
                    r.Cells(6).Value = st
                    r.Cells(7).Value = ""
                    Dim i As Double = 0
                    i = SubTotal()
                    i = Math.Round(i, 2)
                    txtSubTotal.Text = i
                    Clear()
                    Exit Sub
                End If
            Next
            If chkHasExpiryDate.Checked = True Then
                DataGridView1.Rows.Add(Val(txtProductID.Text), cmbProductName.Text, cmbWarehouse.Text, Val(txtQty.Text), Val(txtPricePerQty.Text), Val(txtTotalAmount.Text), st, dtpExpiryDate.Text)
                Dim k As Double = 0
                k = SubTotal()
                k = Math.Round(k, 2)
                txtSubTotal.Text = k
                Clear()
                Exit Sub
            End If
            If chkHasExpiryDate.Checked = False Then
                DataGridView1.Rows.Add(Val(txtProductID.Text), cmbProductName.Text, cmbWarehouse.Text, Val(txtQty.Text), Val(txtPricePerQty.Text), Val(txtTotalAmount.Text), st, "")
                Dim k As Double = 0
                k = SubTotal()
                k = Math.Round(k, 2)
                txtSubTotal.Text = k
                Clear()
                Exit Sub
            End If
            cmbInvoice.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub FillWarehouse()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(WarehouseName) FROM Warehouse", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbWarehouse.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbWarehouse.Items.Add(drow(0).ToString())
            Next
            'zz add
            If cmbWarehouse.Items.Count > 0 Then
                cmbWarehouse.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub chkHasExpiryDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkHasExpiryDate.CheckedChanged
        If chkHasExpiryDate.Checked = True Then
            dtpExpiryDate.Enabled = True
        Else
            dtpExpiryDate.Enabled = False
        End If
    End Sub

    Private Sub txtDiscPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDiscPer.Text
            Dim selectionStart = Me.txtDiscPer.SelectionStart
            Dim selectionLength = Me.txtDiscPer.SelectionLength

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

    Private Sub btnItem_Click(sender As Object, e As EventArgs) Handles btnItem.Click
        frmPurchaseItemEntry.lblUser = lblUser
        Dim purchaseItem As New frmPurchaseItemEntry()
        purchaseItem.ShowDialog()
    End Sub

    Private Sub cmbInvoiceKSelectedIndexChanged(sender As Object, e As EventArgs) ' Handles cmbInvoice.SelectedIndexChanged
        'Private Sub cmbInvoice_TextChanged(sender As Object, e As EventArgs) Handles cmbInvoice.TextChanged
        'If cmbInvoice.Text <> "" Then
        '    Stop
        'End If
        'If BackFromSup Then
        '    BackFromSup = False
        '    cmbInvoice.SelectedIndex = -1

        '    cmbInvoice.DataSource = Nothing
        '    'cmbInvoice.Items.Clear()
        '    Return
        'End If

        Try
            If (Not cmbInvoice.DataSource Is Nothing) AndAlso cmbInvoice.SelectedIndex >= 0 AndAlso cmbInvoice.Text <> "" Then 'zz >=
                Dim d2 = dicPOItem(cmbInvoice.SelectedValue)
                Dim qr As String = "Select [ProductID],'' AS ProductName,'" & cmbWarehouse.Text & "' AS Column2,[Qty],[PricePerUnit],[Amount], '" & IIf(chkHasExpiryDate.Checked = True, "Yes", "No") & "' AS Column7, '" & IIf(chkHasExpiryDate.Checked = True, dtpExpiryDate.Value, "") & "' AS Column8 FROM [dbo].[PurchaseOrder_Join] PJ INNER JOIN [PurchaseOrder] PO On PO.PO_ID = PJ.PurchaseOrderID WHERE 1=2" & vbNewLine
                For Each por As DataRow In d2.Rows
                    qr &= " union all " & vbNewLine
                    'dPOItems = Qry2Table("SELECT PU.[POJ_ID],PU.[PurchaseOrderID],PU.[ProductID],PU.[Qty],PU.[PricePerUnit],PU.[Amount],PR.[ProductName]  FROM [PurchaseOrder_Join] PU left join [Product] PR on PU.ProductID = PR.PID where PU.[PurchaseOrderID] = " & r.Item(0))
                    qr &= "Select " & por.Item("ProductID") & " as [ProductID],RTRIM('" & por.Item("ProductName") & "') AS ProductName,'" & cmbWarehouse.Text & "' AS Column2," & por.Item("Qty") & " AS [Qty]," & por.Item("PricePerUnit") & " AS [PricePerUnit]," & por.Item("Amount") & " as [Amount], '" & IIf(chkHasExpiryDate.Checked = True, "Yes", "No") & "' AS Column7, '" & IIf(chkHasExpiryDate.Checked = True, dtpExpiryDate.Value, "") & "' AS Column8 " & vbNewLine
                Next
                Dim CN As New SqlConnection(cs)
                CN.Open()
                adp = New SqlDataAdapter()
                'adp.SelectCommand = New SqlCommand("Select [ProductID],RTRIM(P.ProductName) AS ProductName,'" & cmbWarehouse.Text & "' AS Column2,[Qty],[PricePerUnit],[Amount], '" & IIf(chkHasExpiryDate.Checked = True, "Yes", "No") & "' AS Column7, '" & IIf(chkHasExpiryDate.Checked = True, dtpExpiryDate.Value, "") & "' AS Column8 FROM [dbo].[PurchaseOrder_Join] PJ INNER JOIN [PurchaseOrder] PO On PO.PO_ID = PJ.PurchaseOrderID WHERE PO.PO_ID = '" & cmbInvoice.SelectedValue & "'", CN)
                adp.SelectCommand = New SqlCommand(qr, CN)
                ds = New DataSet("ds")
                adp.Fill(ds)
                'dtable = ds.Tables(0)
                'zz
                DataGridView1.Rows.Clear()
                dtPOItems = ds.Tables(0)
                BindingSource1.DataSource = dtPOItems
                BindingNavigator1.BindingSource = BindingSource1
                '---
                For Each row As DataRow In dtPOItems.Rows ' dtable.Rows
                    DataGridView1.Rows.Add(row(0).ToString(), row(1).ToString(), row(2).ToString(), row(3).ToString(), row(4).ToString(), row(5).ToString(), row(6).ToString(), "")
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Try
            If DataGridView1.CurrentCell.ColumnIndex = 3 Then
                If Regex.IsMatch(DataGridView1.CurrentRow.Cells(3).Value, "^[0-9]\d{0,9}(\.\d{1,3})?%?$") Then
                    DataGridView1.CurrentRow.Cells(4).Value = CDec(DataGridView1.CurrentRow.Cells(3).Value) * CDec(DataGridView1.CurrentRow.Cells(5).Value)
                Else
                    DataGridView1.CurrentRow.Cells("Column4").Value = Nothing
                    DataGridView1.CurrentRow.Cells("Column6").Value = CDec(0) * CDec(DataGridView1.CurrentRow.Cells("Column5").Value)
                    MessageBox.Show("Only positive number allowed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Try
        Catch
            MessageBox.Show("Only positive number allowed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
    End Sub

    Private Sub txtFreightCharges_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtFreightCharges.Text
            Dim selectionStart = Me.txtFreightCharges.SelectionStart
            Dim selectionLength = Me.txtFreightCharges.SelectionLength

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

    Private Sub txtOtherCharges_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtOtherCharges.Text
            Dim selectionStart = Me.txtOtherCharges.SelectionStart
            Dim selectionLength = Me.txtOtherCharges.SelectionLength

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

    Private Sub txtTotalPaid_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtTotalPaid.Text
            Dim selectionStart = Me.txtTotalPaid.SelectionStart
            Dim selectionLength = Me.txtTotalPaid.SelectionLength

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
    Private Sub txtSubTotal_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txtSubTotal.TextChanged
        Compute()
    End Sub

    Private Sub txtDiscPer_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txtDiscPer.TextChanged
        Compute()
    End Sub

    Private Sub txHSTPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVATPer.TextChanged
        Compute()
    End Sub

    Private Sub txtFreightCharges_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txtFreightCharges.TextChanged
        Compute()
    End Sub

    Private Sub txtOtherCharges_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txtOtherCharges.TextChanged
        Compute()
    End Sub

    Private Sub txtRoundOff_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txtRoundOff.TextChanged
        Compute()
    End Sub

    Private Sub txtTotalPaid_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txtTotalPaid.TextChanged
        Compute()
    End Sub

    Private Sub BindingSource1_PositionChanged(sender As Object, e As EventArgs) Handles BindingSource1.PositionChanged
        'adp.SelectCommand = New SqlCommand("Select [ProductID],RTRIM(P.ProductName) AS ProductName,'" & cmbWarehouse.Text & "' AS Column2,[Qty],[PricePerUnit],[Amount], '" & IIf(chkHasExpiryDate.Checked = True, "Yes", "No") & "' AS Column7, '" & IIf(chkHasExpiryDate.Checked = True, dtpExpiryDate.Value, "") & "' AS Column8 FROM [dbo].[PurchaseOrder_Join] PJ INNER JOIN Product P On P.PID = PJ.ProductID INNER JOIN [PurchaseOrder] PO On PO.PO_ID = PJ.PurchaseOrderID WHERE PO.PO_ID = '" & cmbInvoice.SelectedValue & "'", CN)
        If Me.dtPOItems.Rows.Count = 0 OrElse Me.BindingSource1.Position = -1 Then Return
        'MessageBox.Show(Me.dtPOItems.Rows(Me.BindingSource1.Position).Item(1))
        Me.cmbProductName.Text = Me.dtPOItems.Rows(Me.BindingSource1.Position).Item(1).ToString
        Me.txtQty.Text = Me.dtPOItems.Rows(Me.BindingSource1.Position).Item(3)
        Me.txtPricePerQty.Text = Me.dtPOItems.Rows(Me.BindingSource1.Position).Item(4)
        Me.txtTotalAmount.Text = Me.dtPOItems.Rows(Me.BindingSource1.Position).Item(5)

    End Sub

    Private Sub frmPurchaseEntry_QueryAccessibilityHelp(sender As Object, e As QueryAccessibilityHelpEventArgs) Handles Me.QueryAccessibilityHelp

    End Sub
End Class
