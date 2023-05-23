Imports System.Data.SqlClient

Public Class frmRestaurantPOSKOTRecord
    Sub fillTicketNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(TicketNo) FROM RestaurantPOS_OrderInfoKOT order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbTicketNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbTicketNo.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_OrderInfoKOT.Id), RTRIM(TicketNo),BillDate,RTRIM(TableNo),(RestaurantPOS_OrderInfoKOT.GrandTotal),RTRIM(Operator),RTRIM(GroupName),RTRIM(TicketNote),RTRIM(KOT_Status) from RestaurantPOS_OrderInfoKOT where (DATEDIFF(d,BillDate,GetDate())= 0) Order by BillDate Desc"
            cmd = New SqlCommand(sql, con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillTicketNo()
    End Sub
    Sub Reset()
        cmbTicketNo.Text = ""
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try

            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmPOS.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmPOS.txtTicketID.Text = dr.Cells(0).Value.ToString()
                frmPOS.lblTicketNo.Text = dr.Cells(1).Value.ToString()
                frmPOS.lblTableNo.Text = dr.Cells(3).Value.ToString()
                frmPOS.lblBalance.Text = dr.Cells(4).Value.ToString()
                frmPOS.cmbGroup.Text = dr.Cells(6).Value.ToString()
                frmPOS.btnSave.Enabled = False
                If lblUserType.Text = "Super Admin" Then
                    frmPOS.btnDelete.Enabled = True
                Else
                    frmPOS.btnDelete.Enabled = False
                End If
                frmPOS.flpCategoriesKOT.Enabled = False
                frmPOS.flpItemsKOT.Enabled = False
                frmPOS.btnSettle.Enabled = False
                frmPOS.btnPrint.Enabled = True
                frmPOS.cmbGroup.Enabled = False
                frmPOS.btnKOTUpdate.Enabled = False
                frmPOS.lblSet.Text = "Not Allowed"
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select RTRIM(Dish),RTRIM(Rate),RTRIM(Quantity),RTRIM(Amount),RTRIM(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer), RTRIM(VATAmount),SCPer,SCAmount,RTRIM(TotalAmount),RTRIM(Notes) from RestaurantPOS_OrderInfoKOT,RestaurantPOS_OrderedProductKOT where RestaurantPOS_OrderInfoKOT.Id=RestaurantPOS_OrderedProductKOT.TicketID and RestaurantPOS_OrderInfoKOT.ID=" & dr.Cells(0).Value & " order by Dish"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmPOS.DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    frmPOS.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
                End While
                con.Close()
                frmPOS.btnVoid.Enabled = False
                frmPOS.txtStatus.Text = dr.Cells(8).Value.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_OrderInfoKOT.Id), RTRIM(TicketNo),BillDate,RTRIM(TableNo),(RestaurantPOS_OrderInfoKOT.GrandTotal),RTRIM(Operator),RTRIM(GroupName),RTRIM(TicketNote),RTRIM(KOT_Status) from RestaurantPOS_OrderInfoKOT where BillDate >=@d1 and BillDate < @d2 Order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTicketNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTicketNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_OrderInfoKOT.Id), RTRIM(TicketNo),BillDate,RTRIM(TableNo),(RestaurantPOS_OrderInfoKOT.GrandTotal),RTRIM(Operator),RTRIM(GroupName),RTRIM(TicketNote),RTRIM(KOT_Status) from RestaurantPOS_OrderInfoKOT where TicketNo=@d1 Order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", cmbTicketNo.Text)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTicketNo_Format(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbTicketNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

End Class

