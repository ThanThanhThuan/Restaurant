Imports System.Data.SqlClient
Public Class frmToppingsList
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Dim Rate, DiscountPer, HST, Discount, HSTPer, Amount, TotalAmount As Double
    Dim num1, num2, num3, num4, num5, num6, num7 As Double
    Sub FillToppings()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(ToppingName),BackColor from PizzaTopping where PizzaSize=@d1 order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", frmPizzaPOS.lblPizzaSize.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpTables.Controls.Clear()
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
                flpTables.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.btnTopping_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub frmTables_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillToppings()
        GetTaxType()
    End Sub
    Private Sub btnTopping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
           
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            For Each row As DataGridViewRow In frmPizzaPOS.DataGridView1.Rows
                If row.Cells(0).Value = str And row.Cells(10).Value = "Extra Topping" Then
                    MessageBox.Show("Selected topping is already added", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Rate FROM PizzaTopping WHERE ToppingName=@d1 and PizzaSize=@d2"
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Parameters.AddWithValue("@d2", frmPizzaPOS.lblPizzaSize.Text)
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
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Discount FROM PizzaMaster WHERE PizzaName=@d1 and PizzaSize=@d2"
            cmd.Parameters.AddWithValue("@d1", frmPizzaPOS.lblPizzaName.Text)
            cmd.Parameters.AddWithValue("@d2", frmPizzaPOS.lblPizzaSize.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                DiscountPer = rdr.GetValue(0)
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
            frmPizzaPOS.DataGridView1.Rows.Add(str, frmPizzaPOS.lblPizzaSize.Text, Rate, 1, Amount, DiscountPer, Discount, HSTPer, HST, TotalAmount, "Extra Topping")
            Dim k As Double = 0
            k = frmPizzaPOS.GrandTotal_Food()
            k = Math.Round(k, 2)
            frmPizzaPOS.lblBalance.Text = k
            Me.Hide()
            frmPizzaPOS.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnLogout_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub
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
End Class