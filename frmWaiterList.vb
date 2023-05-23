Imports System.Data.SqlClient
Public Class frmWaiterList
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Sub FillWaiterList()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT distinct RTRIM(Name) from Registration where UserType='Waiter' order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpWaiters.Controls.Clear()
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
                flpWaiters.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.Button2_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
                Dim btn1 As Button = CType(sender, Button)
                Dim str As String = btn1.Text.Trim()
            frmPOS.lblWaiterNameVal.Text = str
                Me.Hide()
                frmPOS.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub frmTables_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillWaiterList()
    End Sub

    Private Sub btnLogout_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class