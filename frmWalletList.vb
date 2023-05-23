Imports System.Data.SqlClient
Public Class frmWalletList
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Sub FillWallet()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(WalletType) from Wallet order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpWallet.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.TextAlign = ContentAlignment.MiddleCenter
                Dim btnColor As Color = Color.DimGray
                btn.BackColor = btnColor
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Popup
                btn.Width = 180
                btn.Height = 80
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpWallet.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.Button2_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If lblSet.Text = "Takeaway" Then
                Dim btn1 As Button = CType(sender, Button)
                Dim str As String = btn1.Text.Trim()
                frmPOS.lblPaymentMode1.Text = str
                frmPOS.txtCash1.Text = frmPOS.txtGrandTotal1.Text
                frmPOS.txtChange1.Text = "0.00"
                Me.Hide()
                frmPOS.Show()
            End If
            If lblSet.Text = "Express Billing" Then
                Dim btn1 As Button = CType(sender, Button)
                Dim str As String = btn1.Text.Trim()
                'frmPOS.lblPaymentMode3.Text = str
                'frmPOS.txtCash3.Text = frmPOS.txtGrandTotal3.Text
                'frmPOS.txtChange3.Text = "0.00"
                Me.Hide()
                frmPOS.Show()
            End If
            If lblSet.Text = "Home Delivery" Then
                Dim btn1 As Button = CType(sender, Button)
                Dim str As String = btn1.Text.Trim()
                frmPOS.lblPaymentMode2.Text = str
                Me.Hide()
                frmPOS.Show()
            End If
            If lblSet.Text = "KOT" Then
                Dim btn1 As Button = CType(sender, Button)
                Dim str As String = btn1.Text.Trim()
                frmPOS.lblPaymentMode.Text = str
                frmPOS.txtCash.Text = frmPOS.txtGrandTotal.Text
                frmPOS.txtChange.Text = "0.00"
                Me.Hide()
                frmPOS.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub frmTables_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillWallet()
    End Sub

    Private Sub btnLogout_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class