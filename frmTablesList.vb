Imports System.Data.SqlClient

Public Class frmTablesList
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Sub FillAvailableTables()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(R_Table.TableNo),BkColor,Sum(Case when KOT_Status not in ('Closed','Void') then GrandTotal else NULL end),Max(Case when KOT_Status not in ('Closed','Void') then DateDiff(Minute,(BillDate),GetDate()) else NULL end) from R_Table left Join RestaurantPOS_OrderInfoKOT on R_Table.TableNo=RestaurantPOS_OrderInfoKOT.TableNo where Status='Activate' group By R_Table.TableNo,BkColor ORDER BY LEFT(R_Table.TableNo, PATINDEX('%[0-9]%', R_Table.TableNo)-1),CONVERT(INT, SUBSTRING(R_Table.TableNo, PATINDEX('%[0-9]%', R_Table.TableNo), LEN(R_Table.TableNo))) "
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpTables.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button

                btn.TextAlign = ContentAlignment.MiddleCenter
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                If Val(rdr.GetValue(1)) = "-65536" Then
                    btn.Text = rdr.GetValue(0) & Environment.NewLine & rdr.GetValue(2) & Environment.NewLine & rdr.GetValue(3) & " " & "Minutes"
                Else
                    btn.Text = rdr.GetValue(0)
                End If
                btn.BackColor = btnColor
                btn.FlatStyle = FlatStyle.Popup
                btn.TextAlign = ContentAlignment.MiddleCenter
                btn.Width = 150
                btn.Height = 100
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpTables.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.button1_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
   
    Private Sub frmTables_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillAvailableTables()
    End Sub

    Private Sub btnLogout_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        FillAvailableTables()
    End Sub
    Private Sub button1_Click(sender As System.Object, e As System.EventArgs)
        Try
            frmPOS.lblTableNo.Text = ""
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text.Trim()
            Dim strText() As String
            strText = Split(str, vbCrLf)
            frmPOS.lblTableNo.Text = strText(0)
            frmPOS.cmbGroup.Enabled = True
            frmPOS.FillGroup()
            Me.Hide()
            frmPOS.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class