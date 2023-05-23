Imports System.Data.SqlClient
Public Class frmModifiersList
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Dim Rate, DiscountPer, HST, Discount, HSTPer, Amount, TotalAmount As Double
    Dim num1, num2, num3, num4, num5, num6, num7 As Double
    Dim ItemName, ModifierName As String
    Public Function ModifierRate() As Double
        Dim sum As Double = 0
        Try
            If DataGridView1.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView1.Rows
                    sum = sum + r.Cells(1).Value
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub FillModifiers()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT distinct RTRIM(ModifierName),BackColor from Modifiers where Item=@d1 order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", lblItemName.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpModifiers.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.TextAlign = ContentAlignment.MiddleCenter
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Popup
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpModifiers.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.btnModifier_Click
            Loop
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub Reset()
        btnRemove.Enabled = False
        DataGridView1.Rows.Clear()
        ItemName = ""
    End Sub
    Private Sub frmPizzaPOS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillModifiers()
        DisableHSBar()
    End Sub
    Sub DisableHSBar()
        flpModifiers.HorizontalScroll.Maximum = 0
        flpModifiers.AutoScroll = False
        flpModifiers.VerticalScroll.Visible = False
        flpModifiers.AutoScroll = True
    End Sub
    Private Sub btnSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub
    Private Sub btnModifier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
           
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(0).Value = str Then
                    MessageBox.Show("Modifier is already added", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Rate FROM Modifiers WHERE Item=@d2 and ModifierName=@d1"
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Parameters.AddWithValue("@d2", lblItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                Rate = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            DataGridView1.Rows.Add(str, Rate, 1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
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

    Private Sub DataGridView1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If DataGridView1.Rows.Count > 0 Then
            btnRemove.Enabled = True
        End If
    End Sub
    Private Sub btnDone_Click(sender As System.Object, e As System.EventArgs) Handles btnDone.Click
        Try
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("Sorry,No modifier added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            For Each row As DataGridViewRow In DataGridView1.Rows
                ModifierName = ModifierName & vbCrLf & row.Cells(0).Value
            Next
            ItemName = lblItemName.Text & vbCrLf & "Add :" & ModifierName
            If lblSet.Text = "KOT" Then
                If frmPOS.DataGridView1.Rows.Count > 0 Then
                    Me.Hide()
                    lblTotalRate.Text = Val(lblItemRate.Text) + ModifierRate()
                    Dim dr As DataGridViewRow = frmPOS.DataGridView1.SelectedRows(0)
                    frmPOS.txtFoodName.Text = dr.Cells(0).Value.ToString()
                    frmPOS.txtRate_Food.Text = Val(lblTotalRate.Text)
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

                frmPOS.DataGridView1.Rows.Add(ItemName, Val(lblTotalRate.Text), Val(frmPOS.txtQty_Food.Text), Val(frmPOS.txtAmt_Food.Text), Val(frmPOS.txtDiscountPer_Food.Text), Val(frmPOS.txtDiscountAmount_Food.Text), Val(frmPOS.txtServiceTaxPer_Food.Text), Val(frmPOS.txtServiceTaxAmount_Food.Text), Val(frmPOS.txtVATPer_Food.Text), Val(frmPOS.txtVATAmt_Food.Text), Val(frmPOS.txtSCPer.Text), Val(frmPOS.txtSCAmount.Text), Val(frmPOS.txtTotalAmt_Food.Text), txtNotes.Text, Val(Me.txtTempQD.Text), txtCategory.Text)
                Dim k As Double = 0
                k = frmPOS.GrandTotal_Food()
                k = Math.Round(k, 2)
                frmPOS.lblBalance.Text = k
                frmPOS.Clear()
                frmPOS.Clear1()
                frmPOS.DataGridView1.ClearSelection()
                lblSet.Text = ""
                ItemName = ""
                ModifierName = ""
            End If
            If lblSet.Text = "HD" Then
                If frmPOS.DataGridView4.Rows.Count > 0 Then
                    Me.Hide()
                    lblTotalRate.Text = Val(lblItemRate.Text) + ModifierRate()
                    Dim dr As DataGridViewRow = frmPOS.DataGridView4.SelectedRows(0)
                    frmPOS.txtFoodName.Text = dr.Cells(0).Value.ToString()
                    frmPOS.txtRate_Food.Text = Val(lblTotalRate.Text)
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
                frmPOS.DataGridView4.Rows.Add(ItemName, Val(lblTotalRate.Text), Val(frmPOS.txtQty_Food.Text), Val(frmPOS.txtAmt_Food.Text), Val(frmPOS.txtDiscountPer_Food.Text), Val(frmPOS.txtDiscountAmount_Food.Text), Val(frmPOS.txtServiceTaxPer_Food.Text), Val(frmPOS.txtServiceTaxAmount_Food.Text), Val(frmPOS.txtVATPer_Food.Text), Val(frmPOS.txtVATAmt_Food.Text), Val(frmPOS.txtSCPer.Text), Val(frmPOS.txtSCAmount.Text), Val(frmPOS.txtTotalAmt_Food.Text), txtNotes.Text, Val(frmPOS.txtTempDiscountPer.Text), txtCategory.Text)
                Dim k As Double = 0
                k = frmPOS.GrandTotal_Food3()
                k = Math.Round(k, 2)
                frmPOS.lblBalance2.Text = k
                frmPOS.txtSubTotal.Text = k
                frmPOS.Calc2()
                frmPOS.Clear1()
                frmPOS.Clear3()
                frmPOS.DataGridView4.ClearSelection()
                frmPOS.txtHDDiscountPer.Text = txtTempQD.Text
                lblSet.Text = ""
                ItemName = ""
                ModifierName = ""
            End If
            If lblSet.Text = "TA" Then
                If frmPOS.DataGridView3.Rows.Count > 0 Then
                    Me.Hide()
                    lblTotalRate.Text = Val(lblItemRate.Text) + ModifierRate()
                    Dim dr As DataGridViewRow = frmPOS.DataGridView3.SelectedRows(0)
                    frmPOS.txtFoodName.Text = dr.Cells(0).Value.ToString()
                    frmPOS.txtRate_Food.Text = Val(lblTotalRate.Text)
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
                frmPOS.DataGridView3.Rows.Add(ItemName, Val(lblTotalRate.Text), Val(frmPOS.txtQty_Food.Text), Val(frmPOS.txtAmt_Food.Text), Val(frmPOS.txtDiscountPer_Food.Text), Val(frmPOS.txtDiscountAmount_Food.Text), Val(frmPOS.txtServiceTaxPer_Food.Text), Val(frmPOS.txtServiceTaxAmount_Food.Text), Val(frmPOS.txtVATPer_Food.Text), Val(frmPOS.txtVATAmt_Food.Text), Val(frmPOS.txtSCPer.Text), Val(frmPOS.txtSCAmount.Text), Val(frmPOS.txtTotalAmt_Food.Text), txtNotes.Text, Val(frmPOS.txtTempDiscountPer.Text), txtCategory.Text)
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
                frmPOS.txtTADiscountPer.Text = txtTempQD.Text
                lblSet.Text = ""
                ItemName = ""
                ModifierName = ""
            End If
            If lblSet.Text = "EB" Then
                'If frmPOS.DataGridView5.Rows.Count > 0 Then
                '    Me.Hide()
                '    lblTotalRate.Text = Val(lblItemRate.Text) + ModifierRate()
                '    Dim dr As DataGridViewRow = frmPOS.DataGridView5.SelectedRows(0)
                '    frmPOS.txtFoodName.Text = dr.Cells(0).Value.ToString()
                '    frmPOS.txtRate_Food.Text = Val(lblTotalRate.Text)
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
                'frmPOS.DataGridView5.Rows.Add(ItemName, Val(lblTotalRate.Text), Val(frmPOS.txtQty_Food.Text), Val(frmPOS.txtAmt_Food.Text), Val(frmPOS.txtDiscountPer_Food.Text), Val(frmPOS.txtDiscountAmount_Food.Text), Val(frmPOS.txtServiceTaxPer_Food.Text), Val(frmPOS.txtServiceTaxAmount_Food.Text), Val(frmPOS.txtVATPer_Food.Text), Val(frmPOS.txtVATAmt_Food.Text), Val(frmPOS.txtSCPer.Text), Val(frmPOS.txtSCAmount.Text), Val(frmPOS.txtTotalAmt_Food.Text), txtNotes.Text, Val(frmPOS.txtTempDiscountPer.Text), txtCategory.Text)
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
                'frmPOS.txtEBDiscountPer.Text = txtTempQD.Text
                lblSet.Text = ""
                ItemName = ""
                ModifierName = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class