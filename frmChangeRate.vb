Public Class frmChangeRate
    Dim sign_Indicator As Integer = 0
    Dim variable1 As Double
    Dim variable2 As Double
    Dim fl As Boolean = False
    Dim s, x As String
    Private Sub btnOkay_Click(sender As System.Object, e As System.EventArgs) Handles btnOkay.Click
        Try
            If txtRate.Text = "" Then
                MessageBox.Show("Please enter the rate", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtRate.Focus()
                Exit Sub
            End If
            If lblSet.Text = "Takeaway" Then
                If frmPOS.DataGridView3.Rows.Count > 0 Then
                    Me.Hide()
                    Dim dr As DataGridViewRow = frmPOS.DataGridView3.SelectedRows(0)
                    frmPOS.txtFoodName.Text = dr.Cells(0).Value.ToString()
                    frmPOS.txtRate_Food.Text = Val(txtRate.Text)
                    frmPOS.txtQty_Food.Text = dr.Cells(2).Value.ToString()
                    frmPOS.txtAmt_Food.Text = dr.Cells(3).Value.ToString()
                    frmPOS.txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
                    frmPOS.txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
                    frmPOS.txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
                    frmPOS.txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
                    frmPOS.txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
                    frmPOS.txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
                    frmPOS.txtSCPer.Text = dr.Cells(10).Value.ToString()
                    frmPOS.txtSCAmount.Text = dr.Cells(11).Value.ToString()
                    frmPOS.txtTotalAmt_Food.Text = dr.Cells(12).Value.ToString()
                    frmPOS.txtTempDiscountPer.Text = dr.Cells(14).Value.ToString()
                End If
                frmPOS.Compute()
                For Each r As DataGridViewRow In frmPOS.DataGridView3.SelectedRows
                    frmPOS.DataGridView3.Rows.Remove(r)
                Next
                frmPOS.DataGridView3.Rows.Add(frmPOS.txtFoodName.Text, Val(frmPOS.txtRate_Food.Text), Val(frmPOS.txtQty_Food.Text), Val(frmPOS.txtAmt_Food.Text), Val(frmPOS.txtDiscountPer_Food.Text), Val(frmPOS.txtDiscountAmount_Food.Text), Val(frmPOS.txtServiceTaxPer_Food.Text), Val(frmPOS.txtServiceTaxAmount_Food.Text), Val(frmPOS.txtVATPer_Food.Text), Val(frmPOS.txtVATAmt_Food.Text), Val(frmPOS.txtSCPer.Text), Val(frmPOS.txtSCAmount.Text), Val(frmPOS.txtTotalAmt_Food.Text), txtNotes.Text, Val(frmPOS.txtTempDiscountPer.Text), txtCategory.Text)
                Dim k As Double = 0
                k = frmPOS.GrandTotal_Food2()
                k = Math.Round(k, 2)
                frmPOS.lblBalance1.Text = k
                frmPOS.txtSubTotal1.Text = k
                frmPOS.Calc1()
                frmPOS.fillCurrencyTA()
                frmPOS.Clear1()
                frmPOS.Clear2()
                frmPOS.DataGridView3.ClearSelection()
                frmPOS.txtTADiscountPer.Text = txtR.Text
                txtRate.Text = ""
                txtR.Text = ""
                txtNotes.Text = ""
            End If
            If lblSet.Text = "Express Billing" Then
                'If frmPOS.DataGridView5.Rows.Count > 0 Then
                '    Me.Hide()
                '    Dim dr As DataGridViewRow = frmPOS.DataGridView5.SelectedRows(0)
                '    frmPOS.txtFoodName.Text = dr.Cells(0).Value.ToString()
                '    frmPOS.txtRate_Food.Text = Val(txtRate.Text)
                '    frmPOS.txtQty_Food.Text = dr.Cells(2).Value.ToString()
                '    frmPOS.txtAmt_Food.Text = dr.Cells(3).Value.ToString()
                '    frmPOS.txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
                '    frmPOS.txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
                '    frmPOS.txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
                '    frmPOS.txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
                '    frmPOS.txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
                '    frmPOS.txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
                '    frmPOS.txtSCPer.Text = dr.Cells(10).Value.ToString()
                '    frmPOS.txtSCAmount.Text = dr.Cells(11).Value.ToString()
                '    frmPOS.txtTotalAmt_Food.Text = dr.Cells(12).Value.ToString()
                '    frmPOS.txtTempDiscountPer.Text = dr.Cells(14).Value.ToString()
                'End If
                frmPOS.Compute()
                'For Each r As DataGridViewRow In frmPOS.DataGridView5.SelectedRows
                '    frmPOS.DataGridView5.Rows.Remove(r)
                'Next
                'frmPOS.DataGridView5.Rows.Add(frmPOS.txtFoodName.Text, Val(frmPOS.txtRate_Food.Text), Val(frmPOS.txtQty_Food.Text), Val(frmPOS.txtAmt_Food.Text), Val(frmPOS.txtDiscountPer_Food.Text), Val(frmPOS.txtDiscountAmount_Food.Text), Val(frmPOS.txtServiceTaxPer_Food.Text), Val(frmPOS.txtServiceTaxAmount_Food.Text), Val(frmPOS.txtVATPer_Food.Text), Val(frmPOS.txtVATAmt_Food.Text), Val(frmPOS.txtSCPer.Text), Val(frmPOS.txtSCAmount.Text), Val(frmPOS.txtTotalAmt_Food.Text), txtNotes.Text, Val(frmPOS.txtTempDiscountPer.Text), txtCategory.Text)
                Dim k As Double = 0
                k = frmPOS.GrandTotal_Food4()
                k = Math.Round(k, 2)
                'frmPOS.lblBalance3.Text = k
                'frmPOS.txtGrandTotal3.Text = k
                frmPOS.Calc3()
                frmPOS.fillCurrencyEB()
                frmPOS.Clear1()
                frmPOS.Clear4()
                'frmPOS.DataGridView5.ClearSelection()
                'frmPOS.txtEBDiscountPer.Text = txtR.Text
                txtRate.Text = ""
                txtR.Text = ""
                txtNotes.Text = ""
            End If
            If lblSet.Text = "Home Delivery" Then
                If frmPOS.DataGridView4.Rows.Count > 0 Then
                    Me.Hide()
                    Dim dr As DataGridViewRow = frmPOS.DataGridView4.SelectedRows(0)
                    frmPOS.txtFoodName.Text = dr.Cells(0).Value.ToString()
                    frmPOS.txtRate_Food.Text = Val(txtRate.Text)
                    frmPOS.txtQty_Food.Text = dr.Cells(2).Value.ToString()
                    frmPOS.txtAmt_Food.Text = dr.Cells(3).Value.ToString()
                    frmPOS.txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
                    frmPOS.txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
                    frmPOS.txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
                    frmPOS.txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
                    frmPOS.txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
                    frmPOS.txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
                    frmPOS.txtSCPer.Text = dr.Cells(10).Value.ToString()
                    frmPOS.txtSCAmount.Text = dr.Cells(11).Value.ToString()
                    frmPOS.txtTotalAmt_Food.Text = dr.Cells(12).Value.ToString()
                    frmPOS.txtTempDiscountPer.Text = dr.Cells(14).Value.ToString()
                End If
                frmPOS.Compute()
                For Each r As DataGridViewRow In frmPOS.DataGridView4.SelectedRows
                    frmPOS.DataGridView4.Rows.Remove(r)
                Next
                frmPOS.DataGridView4.Rows.Add(frmPOS.txtFoodName.Text, Val(frmPOS.txtRate_Food.Text), Val(frmPOS.txtQty_Food.Text), Val(frmPOS.txtAmt_Food.Text), Val(frmPOS.txtDiscountPer_Food.Text), Val(frmPOS.txtDiscountAmount_Food.Text), Val(frmPOS.txtServiceTaxPer_Food.Text), Val(frmPOS.txtServiceTaxAmount_Food.Text), Val(frmPOS.txtVATPer_Food.Text), Val(frmPOS.txtVATAmt_Food.Text), Val(frmPOS.txtSCPer.Text), Val(frmPOS.txtSCAmount.Text), Val(frmPOS.txtTotalAmt_Food.Text), txtNotes.Text, Val(frmPOS.txtTempDiscountPer.Text), txtCategory.Text)
                Dim k As Double = 0
                k = frmPOS.GrandTotal_Food3()
                k = Math.Round(k, 2)
                frmPOS.lblBalance2.Text = k
                frmPOS.txtSubTotal.Text = k
                frmPOS.Calc2()
                frmPOS.Clear1()
                frmPOS.Clear3()
                frmPOS.DataGridView4.ClearSelection()
                frmPOS.txtHDDiscountPer.Text = txtR.Text
                txtRate.Text = ""
                txtR.Text = ""
                txtNotes.Text = ""
            End If
            If lblSet.Text = "KOT" Then
                If frmPOS.DataGridView1.Rows.Count > 0 Then
                    Me.Hide()
                    Dim dr As DataGridViewRow = frmPOS.DataGridView1.SelectedRows(0)
                    frmPOS.txtFoodName.Text = dr.Cells(0).Value.ToString()
                    frmPOS.txtRate_Food.Text = Val(txtRate.Text)
                    frmPOS.txtQty_Food.Text = dr.Cells(2).Value.ToString()
                    frmPOS.txtAmt_Food.Text = dr.Cells(3).Value.ToString()
                    frmPOS.txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
                    frmPOS.txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
                    frmPOS.txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
                    frmPOS.txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
                    frmPOS.txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
                    frmPOS.txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
                    frmPOS.txtSCPer.Text = dr.Cells(10).Value.ToString()
                    frmPOS.txtSCAmount.Text = dr.Cells(11).Value.ToString()
                    frmPOS.txtTotalAmt_Food.Text = dr.Cells(12).Value.ToString()
                End If
                frmPOS.Compute()
                For Each r As DataGridViewRow In frmPOS.DataGridView1.SelectedRows
                    frmPOS.DataGridView1.Rows.Remove(r)
                Next
                frmPOS.DataGridView1.Rows.Add(frmPOS.txtFoodName.Text, Val(frmPOS.txtRate_Food.Text), Val(frmPOS.txtQty_Food.Text), Val(frmPOS.txtAmt_Food.Text), Val(frmPOS.txtDiscountPer_Food.Text), Val(frmPOS.txtDiscountAmount_Food.Text), Val(frmPOS.txtServiceTaxPer_Food.Text), Val(frmPOS.txtServiceTaxAmount_Food.Text), Val(frmPOS.txtVATPer_Food.Text), Val(frmPOS.txtVATAmt_Food.Text), Val(frmPOS.txtSCPer.Text), Val(frmPOS.txtSCAmount.Text), Val(frmPOS.txtTotalAmt_Food.Text), txtNotes.Text, Val(Me.txtR.Text), txtCategory.Text)
                Dim k As Double = 0
                k = frmPOS.GrandTotal_Food()
                k = Math.Round(k, 2)
                frmPOS.lblBalance.Text = k
                frmPOS.Clear()
                frmPOS.Clear1()
                frmPOS.DataGridView1.ClearSelection()
                txtRate.Text = ""
                txtNotes.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub txtRate_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate.KeyPress
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

    Private Sub frmChangeRate_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnTA1_Click(sender As System.Object, e As System.EventArgs) Handles btnTA1.Click
        If sign_Indicator = 0 Then
            txtRate.Text = txtRate.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            txtRate.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA2_Click(sender As System.Object, e As System.EventArgs) Handles btnTA2.Click
        If sign_Indicator = 0 Then
            txtRate.Text = txtRate.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            txtRate.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA3_Click(sender As System.Object, e As System.EventArgs) Handles btnTA3.Click
        If sign_Indicator = 0 Then
            txtRate.Text = txtRate.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            txtRate.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA4_Click(sender As System.Object, e As System.EventArgs) Handles btnTA4.Click
        If sign_Indicator = 0 Then
            txtRate.Text = txtRate.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            txtRate.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA5_Click(sender As System.Object, e As System.EventArgs) Handles btnTA5.Click
        If sign_Indicator = 0 Then
            txtRate.Text = txtRate.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            txtRate.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA6_Click(sender As System.Object, e As System.EventArgs) Handles btnTA6.Click
        If sign_Indicator = 0 Then
            txtRate.Text = txtRate.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            txtRate.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA7_Click(sender As System.Object, e As System.EventArgs) Handles btnTA7.Click
        If sign_Indicator = 0 Then
            txtRate.Text = txtRate.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            txtRate.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA8_Click(sender As System.Object, e As System.EventArgs) Handles btnTA8.Click
        If sign_Indicator = 0 Then
            txtRate.Text = txtRate.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            txtRate.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA9_Click(sender As System.Object, e As System.EventArgs) Handles btnTA9.Click
        If sign_Indicator = 0 Then
            txtRate.Text = txtRate.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            txtRate.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTAComma_Click(sender As System.Object, e As System.EventArgs) Handles btnTAComma.Click
        Dim i As Integer = 0
        Dim chr As Char = ControlChars.NullChar
        Dim decimal_Indicator As Integer = 0
        Dim l As Integer = txtRate.Text.Length - 1
        If sign_Indicator <> 1 Then
            For i = 0 To l
                chr = txtRate.Text(i)
                If chr = "."c Then
                    decimal_Indicator = 1
                End If
            Next

            If decimal_Indicator <> 1 Then
                txtRate.Text = txtRate.Text + Convert.ToString(".")
            End If
        End If
    End Sub

    Private Sub btnTA0_Click(sender As System.Object, e As System.EventArgs) Handles btnTA0.Click
        If sign_Indicator = 0 Then
            txtRate.Text = txtRate.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            txtRate.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTAx_Click(sender As System.Object, e As System.EventArgs) Handles btnTAx.Click
        s = txtRate.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        txtRate.Text = x
        x = ""
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtRate.Text = ""
    End Sub

End Class