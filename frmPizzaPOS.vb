Imports System.Data.SqlClient
Public Class frmPizzaPOS
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Dim Rate, DiscountPer, HST, Discount, HSTPer, Amount, TotalAmount As Double
    Dim num1, num2, num3, num4, num5, num6, num7 As Double
    Dim ItemName, Topping, Pizza, PizzaSize, Description, ExtraTopping As String
    Sub FillPizzaSize()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT distinct RTRIM(Size) from PizzaSize,PizzaMaster where PizzaSize.Size=PizzaMaster.PizzaSize order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpPizzaSize.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.TextAlign = ContentAlignment.MiddleCenter
                Dim btnColor As Color = Color.DimGray
                btn.BackColor = btnColor
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Popup
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpPizzaSize.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.btnSize_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub FillPizza()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT distinct RTRIM(PizzaName) from PizzaMaster order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpPizza.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.TextAlign = ContentAlignment.MiddleCenter
                Dim btnColor As Color = Color.DimGray
                btn.BackColor = btnColor
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Popup
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpPizza.Controls.Add(btn)
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub frmPizzaPOS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillPizzaSize()
        FillPizza()
        GetTaxType()
        DisableHSBar()
    End Sub
    Sub DisableHSBar()
        flpPizza.HorizontalScroll.Maximum = 0
        flpPizza.AutoScroll = False
        flpPizza.VerticalScroll.Visible = False
        flpPizza.AutoScroll = True

        flpPizzaSize.HorizontalScroll.Maximum = 0
        flpPizzaSize.AutoScroll = False
        flpPizzaSize.VerticalScroll.Visible = False
        flpPizzaSize.AutoScroll = True
    End Sub
    Private Sub btnSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text.Trim()
            lblPizzaSize.Text = str
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT distinct RTRIM(PizzaName),BackColor from PizzaMaster where PizzaSize=@d1 order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpPizza.Controls.Clear()
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
                flpPizza.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.btnPizza_Click
                AddHandler btn.Click, AddressOf Me.btnPizza_MouseHover
            Loop
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnPizza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If lblPizzaSize.Text = "" Then
                MessageBox.Show("Please select pizza size", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(10).Value = "Pizza" Then
                    MessageBox.Show("Pizza is already added", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            lblPizzaName.Text = str
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Rate,Discount FROM PizzaMaster WHERE PizzaName=@d1 and PizzaSize=@d2"
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Parameters.AddWithValue("@d2", lblPizzaSize.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                Rate = rdr.GetValue(0)
                DiscountPer = rdr.GetValue(1)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT FROM Category WHERE CategoryName='Pizza'"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                HSTPer = rdr.GetValue(0)
            Else
                HSTPer = 0
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Compute()
            DataGridView1.Rows.Add(str, lblPizzaSize.Text, Rate, 1, Amount, DiscountPer, Discount, HSTPer, HST, TotalAmount, "Pizza")
            Dim k As Double = 0
            k = GrandTotal_Food()
            k = Math.Round(k, 2)
            lblBalance.Text = k
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Function GrandTotal_Food() As Double
        Dim sum As Double = 0
        Try
            If DataGridView1.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView1.Rows
                    sum = sum + r.Cells(9).Value
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function FinalGrandTotal() As Double
        Dim sum As Double = 0
        Try
            If DataGridView2.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView2.Rows
                    sum = sum + r.Cells(9).Value
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub GetTaxType()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(TaxType) from OtherSetting"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtTaxType.Text = rdr.GetValue(0).ToString()
            Else
                txtTaxType.Text = ""
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub Compute()
        Try
            If txtTaxType.Text = "Inclusive" Then
                num1 = Rate
                num1 = Math.Round(num1, 2)
                Amount = num1
                num2 = (num1 * DiscountPer) / 100
                num2 = Math.Round(num2, 2)
                Discount = num2
                num3 = Amount - Discount
                num3 = Math.Round(num3, 2)
                num4 = num3 - (num3 / (1 + (Val(HSTPer) / 100)))
                num4 = Math.Round(num4, 2)
                HST = num4
                num6 = num3
                num6 = Math.Round(num6, 2)
                TotalAmount = num6
            Else
                num1 = Rate
                num1 = Math.Round(num1, 2)
                Amount = num1
                num2 = (num1 * DiscountPer) / 100
                num2 = Math.Round(num2, 2)
                Discount = num2
                num3 = Amount - Discount
                num3 = Math.Round(num3, 2)
                num4 = (num3 * HSTPer) / 100
                num4 = Math.Round(num4, 2)
                HST = num4
                num6 = num3 + num4
                num6 = Math.Round(num6, 2)
                TotalAmount = num6
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnToppings_Click(sender As System.Object, e As System.EventArgs) Handles btnToppings.Click
      
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Add pizza first", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If lblPizzaSize.Text = "" Then
            MessageBox.Show("Please select pizza size", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        frmToppingsList.GetTaxType()
        frmToppingsList.FillToppings()
        frmToppingsList.ShowDialog()
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                If row.Cells(10).Value = "Pizza" Then
                    If MessageBox.Show("Do you really want to remove the pizza?" & vbCrLf & "It will also remove all added toppings.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                        DataGridView1.Rows.Clear()
                        lblBalance.Text = "0.00"
                        lblPizzaSize.Text = ""
                        lblPizzaName.Text = ""
                    End If
                    Exit Sub
                End If
                DataGridView1.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = GrandTotal_Food()
            k = Math.Round(k, 2)
            lblBalance.Text = k
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

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Try

            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("Sorry,No pizza added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(10).Value = "Topping" Then
                    Topping = Topping & vbCrLf & row.Cells(0).Value
                End If
            Next
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(10).Value = "Extra Topping" Then
                    ExtraTopping = ExtraTopping & vbCrLf & row.Cells(0).Value
                End If
            Next
            Dim st1, st2
            If Topping <> "" Then
                st1 = "Toppings :"
            Else
                st1 = ""
            End If
            If ExtraTopping <> "" Then
                st2 = "Extra Toppings :"
            Else
                st2 = ""
            End If
            Pizza = DataGridView1.Rows(0).Cells(0).Value & " " & "(" & DataGridView1.Rows(0).Cells(1).Value & ")"
            If st1 = "" Then
                ItemName = (Pizza & vbCrLf & st2 & ExtraTopping).ToString().Trim()
            Else
                ItemName = (Pizza & vbCrLf & st1 & Topping & vbCrLf & st2 & ExtraTopping).ToString().Trim()
            End If
            PizzaSize = DataGridView1.Rows(0).Cells(1).Value
            num1 = PizzaRate()
            num1 = Math.Round(num1, 2)
            Rate = num1
            Amount = num1
            DiscountPer = DataGridView1.Rows(0).Cells(5).Value
            num2 = PizzaDiscount()
            num2 = Math.Round(num2, 2)
            Discount = num2
            HSTPer = DataGridView1.Rows(0).Cells(7).Value
            num3 = PizzaHST()
            num3 = Math.Round(num3, 2)
            HST = num3
            TotalAmount = lblBalance.Text
            DataGridView2.Rows.Add(ItemName, PizzaSize, Rate, 1, Amount, DiscountPer, Discount, HSTPer, HST, TotalAmount)
            Dim k As Double = 0
            k = FinalGrandTotal()
            k = Math.Round(k, 2)
            lblFinalBalance.Text = k
            DataGridView1.Rows.Clear()
            lblBalance.Text = "0.00"
            lblPizzaSize.Text = ""
            lblPizzaName.Text = ""
            Topping = ""
            ExtraTopping = ""
            ItemName = ""
            Pizza = ""
            PizzaSize = ""
            btnRemove.Enabled = False
            st1 = ""
            st2 = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function PizzaRate() As Double
        Dim sum As Double = 0
        Try
            If DataGridView1.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView1.Rows
                    sum = sum + r.Cells(2).Value
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function PizzaDiscount() As Double
        Dim sum As Double = 0
        Try
            If DataGridView1.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView1.Rows
                    sum = sum + r.Cells(6).Value
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function PizzaHST() As Double
        Dim sum As Double = 0
        Try
            If DataGridView1.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView1.Rows
                    sum = sum + r.Cells(8).Value
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub Reset()
        DataGridView1.Rows.Clear()
        lblBalance.Text = "0.00"
        lblPizzaSize.Text = ""
        lblPizzaName.Text = ""
        Topping = ""
        ItemName = ""
        Pizza = ""
        PizzaSize = ""
        DataGridView2.Rows.Clear()
        lblFinalBalance.Text = "0.00"
        btnRemove.Enabled = False
        btnRemove1.Enabled = False
        FillPizzaSize()
        FillPizza()
        GetTaxType()
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnRemove1_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove1.Click
        Try
            For Each row As DataGridViewRow In DataGridView2.SelectedRows
                DataGridView2.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = FinalGrandTotal()
            k = Math.Round(k, 2)
            lblFinalBalance.Text = k
            btnRemove1.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView2_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        If DataGridView2.Rows.Count > 0 Then
            btnRemove1.Enabled = True
        End If
    End Sub

    Private Sub btnDone_Click(sender As System.Object, e As System.EventArgs) Handles btnDone.Click
        If DataGridView2.Rows.Count = 0 Then
            MessageBox.Show("Add pizza first", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If lblSet.Text = "KOT" Then
            For Each row As DataGridViewRow In DataGridView2.Rows
                frmPOS.DataGridView1.Rows.Add(row.Cells(0).Value, Val(row.Cells(2).Value), 1, Val(row.Cells(4).Value), Val(row.Cells(5).Value), Val(row.Cells(6).Value), 0, 0, Val(row.Cells(7).Value), Val(row.Cells(8).Value), 0, 0, Val(row.Cells(9).Value), "", 0, "Pizza")
            Next
            Dim k As Double = 0
            k = frmPOS.GrandTotal_Food()
            k = Math.Round(k, 2)
            frmPOS.lblBalance.Text = k
            Me.Hide()
            frmPOS.Show()
            lblSet.Text = ""
        End If
        If lblSet.Text = "HD" Then
            For Each row As DataGridViewRow In DataGridView2.Rows
                frmPOS.DataGridView4.Rows.Add(row.Cells(0).Value, Val(row.Cells(2).Value), 1, Val(row.Cells(4).Value), Val(row.Cells(5).Value), Val(row.Cells(6).Value), 0, 0, Val(row.Cells(7).Value), Val(row.Cells(8).Value), 0, 0, Val(row.Cells(9).Value), "", 0, "Pizza")
            Next
            Dim k As Double = 0
            k = frmPOS.GrandTotal_Food3()
            k = Math.Round(k, 2)
            frmPOS.lblBalance2.Text = k
            frmPOS.txtSubTotal.Text = Val(frmPOS.lblBalance2.Text)
            frmPOS.Calc2()
            Me.Hide()
            frmPOS.Show()
            lblSet.Text = ""
        End If
        If lblSet.Text = "TA" Then
            For Each row As DataGridViewRow In DataGridView2.Rows
                frmPOS.DataGridView3.Rows.Add(row.Cells(0).Value, Val(row.Cells(2).Value), 1, Val(row.Cells(4).Value), Val(row.Cells(5).Value), Val(row.Cells(6).Value), 0, 0, Val(row.Cells(7).Value), Val(row.Cells(8).Value), 0, 0, Val(row.Cells(9).Value), "", 0, "Pizza")
            Next
            Dim k As Double = 0
            k = frmPOS.GrandTotal_Food2()
            k = Math.Round(k, 2)
            frmPOS.lblBalance1.Text = k
            frmPOS.txtSubTotal1.Text = Val(frmPOS.lblBalance1.Text)
            frmPOS.Calc1()
            frmPOS.fillCurrencyTA()
            Me.Hide()
            frmPOS.Show()
            lblSet.Text = ""
        End If
        If lblSet.Text = "EB" Then
            For Each row As DataGridViewRow In DataGridView2.Rows
                'frmPOS.DataGridView5.Rows.Add(row.Cells(0).Value, Val(row.Cells(2).Value), 1, Val(row.Cells(4).Value), Val(row.Cells(5).Value), Val(row.Cells(6).Value), 0, 0, Val(row.Cells(7).Value), Val(row.Cells(8).Value), 0, 0, Val(row.Cells(9).Value), "", 0, "Pizza")
            Next
            Dim k As Double = 0
            k = frmPOS.GrandTotal_Food4()
            k = Math.Round(k, 2)
            'frmPOS.lblBalance3.Text = k
            'frmPOS.txtGrandTotal3.Text = Val(frmPOS.lblBalance3.Text)
            frmPOS.Calc3()
            frmPOS.fillCurrencyEB()
            Me.Hide()
            frmPOS.Show()
            lblSet.Text = ""
        End If
    End Sub

    Private Sub btnPizza_MouseHover(sender As System.Object, e As System.EventArgs)
        Dim btn1 As Button = CType(sender, Button)
        Dim str As String = btn1.Text
        con = New SqlConnection(cs)
        con.Open()
        Dim cmdText1 As String = "SELECT RTRIM(Description) from PizzaMaster where PizzaName=@d1 and PizzaSize=@d2 order by 1"
        cmd = New SqlCommand(cmdText1)
        cmd.Parameters.AddWithValue("@d1", str)
        cmd.Parameters.AddWithValue("@d2", lblPizzaSize.Text)
        cmd.Connection = con
        Description = ""
        rdr = cmd.ExecuteReader()
        If rdr.Read Then
            Description = rdr.GetValue(0)
        Else
            Description = ""
        End If
        con.Close()
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(btn1, Description)
    End Sub

    Private Sub btnFreeToppings_Click(sender As System.Object, e As System.EventArgs) Handles btnFreeToppings.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Add pizza first", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If lblPizzaSize.Text = "" Then
            MessageBox.Show("Please select pizza size", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        frmFreeToppingsList.FillToppings()
        frmFreeToppingsList.ShowDialog()
    End Sub

End Class