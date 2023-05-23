Imports System.Data.SqlClient
Public Class frmMemberBalance
    Sub Reset()
        txtMemberID.Text = ""
        txtMemberName.Text = ""
        GetData()
    End Sub
    Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Member.MemberID,RTRIM(Name),RTRIM(ContactNo),IsNull(sum(Credit)-sum(Debit),0) FROM Member Inner join MemberLedger on Member.MemberID=MemberLedger.MemberID group by Member.MemberID,name,ContactNo order by Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmMemberBalance_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Member.MemberID,RTRIM(Name),RTRIM(ContactNo),IsNull(sum(Credit)-sum(Debit),0) FROM Member Inner join MemberLedger on Member.MemberID=MemberLedger.MemberID where Name like '%" & txtMemberName.Text & "%' group by Member.MemberID,name,ContactNo order by Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Member.MemberID,RTRIM(Name),RTRIM(ContactNo),IsNull(sum(Credit)-sum(Debit),0) FROM Member Inner join MemberLedger on Member.MemberID=MemberLedger.MemberID where Member.MemberID like '%" & txtMemberID.Text & "%' group by Member.MemberID,name,ContactNo order by Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtMemberID_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMemberID.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT Member.MemberID,RTRIM(Name),RTRIM(ContactNo),IsNull(sum(Credit)-sum(Debit),0) FROM Member Inner join MemberLedger on Member.MemberID=MemberLedger.MemberID where Member.MemberID like '%" & txtMemberID.Text & "%' group by Member.MemberID,name,ContactNo order by Name", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnScanCard.Click
        txtMemberID.Focus()
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "HD" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    If dr.Cells(3).Value >= Val(lblAmount.Text) Then
                        Me.Hide()
                        frmPOS.Show()
                        frmPOS.lblPaymentMode2.Text = "RPOS Card"
                        frmPOS.lblMemberID.Text = dr.Cells(0).Value
                    Else
                        MessageBox.Show("Insufficient fund available in member's account...try other payment mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                If lblSet.Text = "Dine In Billing" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    If dr.Cells(3).Value >= Val(lblAmount.Text) Then
                        If lblTempAmount.Text = "" Then
                            Me.Hide()
                            frmPOS.Show()
                            frmPOS.lblPaymentMode.Text = "RPOS Card"
                            frmPOS.lblMemberID.Text = dr.Cells(0).Value
                            frmPOS.txtCash.Text = lblAmount.Text
                        Else
                            Me.Hide()
                            frmPOS.Show()
                            frmPOS.lblPaymentMode.Text = "RPOS Card"
                            frmPOS.lblMemberID.Text = dr.Cells(0).Value
                            frmPOS.txtCash.Text = lblTempAmount.Text
                        End If
                    Else
                        MessageBox.Show("Insufficient fund available in member's account...try other payment mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                If lblSet.Text = "TA" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    If dr.Cells(3).Value >= Val(lblAmount.Text) Then
                        If lblTempAmount.Text = "" Then
                            Me.Hide()
                            frmPOS.Show()
                            frmPOS.lblPaymentMode1.Text = "RPOS Card"
                            frmPOS.lblMemberID.Text = dr.Cells(0).Value
                            frmPOS.txtCash1.Text = lblAmount.Text
                        Else
                            Me.Hide()
                            frmPOS.Show()
                            frmPOS.lblPaymentMode1.Text = "RPOS Card"
                            frmPOS.lblMemberID.Text = dr.Cells(0).Value
                            frmPOS.txtCash1.Text = lblTempAmount.Text
                        End If
                    Else
                        MessageBox.Show("Insufficient fund available in member's account...try other payment mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                If lblSet.Text = "EB" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    If dr.Cells(3).Value >= Val(lblAmount.Text) Then
                        If lblTempAmount.Text = "" Then
                            Me.Hide()
                            frmPOS.Show()
                            'frmPOS.lblPaymentMode3.Text = "RPOS Card"
                            frmPOS.lblMemberID.Text = dr.Cells(0).Value
                            'frmPOS.txtCash3.Text = lblAmount.Text
                        Else
                            Me.Hide()
                            frmPOS.Show()
                            'frmPOS.lblPaymentMode3.Text = "RPOS Card"
                            frmPOS.lblMemberID.Text = dr.Cells(0).Value
                            'frmPOS.txtCash3.Text = lblTempAmount.Text
                        End If
                    Else
                        MessageBox.Show("Insufficient fund available in member's account...try other payment mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                lblTempAmount.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub
End Class