Imports System.Data.SqlClient

Public Class frmStockAdjustment_Warehouse_Record

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT  StockAdjustment_Warehouse.SA_ID, StockAdjustment_Warehouse.Date,RTRIM(Warehouse), StockAdjustment_Warehouse.ProductID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName), RTRIM(StockAdjustment_Warehouse.AdjustmentType),StockAdjustment_Warehouse.Qty,RTRIM(Unit), RTRIM(StockAdjustment_Warehouse.Reason) FROM StockAdjustment_Warehouse INNER JOIN Product ON StockAdjustment_Warehouse.ProductID = Product.PID order by Date", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "SA" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    frmStockAdjustment_Warehouse.Show()
                    Me.Hide()
                    frmStockAdjustment_Warehouse.txtAdjustmentID.Text = dr.Cells(0).Value.ToString()
                    frmStockAdjustment_Warehouse.dtpDate.Text = dr.Cells(1).Value.ToString()
                    frmStockAdjustment_Warehouse.cmbWarehouse.Text = dr.Cells(2).Value.ToString()
                    frmStockAdjustment_Warehouse.txtProductID.Text = dr.Cells(3).Value.ToString()
                    frmStockAdjustment_Warehouse.txtProductCode.Text = dr.Cells(4).Value.ToString()
                    frmStockAdjustment_Warehouse.cmbProductName.Text = dr.Cells(5).Value.ToString()
                    If dr.Cells(6).Value.ToString() = "Plus" Then
                        frmStockAdjustment_Warehouse.rbPlus.Checked = True
                    Else
                        frmStockAdjustment_Warehouse.rbMinus.Checked = True
                    End If
                    frmStockAdjustment_Warehouse.txtQty.Text = dr.Cells(7).Value.ToString()
                    frmStockAdjustment_Warehouse.txtQ.Text = dr.Cells(7).Value.ToString()
                    frmStockAdjustment_Warehouse.txtReason.Text = dr.Cells(9).Value.ToString()
                    frmStockAdjustment_Warehouse.btnDelete.Enabled = True
                    frmStockAdjustment_Warehouse.btnUpdate.Enabled = True
                    frmStockAdjustment_Warehouse.btnSave.Enabled = False
                    frmStockAdjustment_Warehouse.cmbProductName.Enabled = False
                    frmStockAdjustment_Warehouse.cmbWarehouse.Enabled = False
                    frmStockAdjustment_Warehouse.gbAdjustment.Enabled = False
                    frmStockAdjustment_Warehouse.GetQty_S()
                End If
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
    Sub Reset()
        txtProductName.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        Getdata()
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT  StockAdjustment_Warehouse.SA_ID, StockAdjustment_Warehouse.Date,RTRIM(Warehouse), StockAdjustment_Warehouse.ProductID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName), RTRIM(StockAdjustment_Warehouse.AdjustmentType),StockAdjustment_Warehouse.Qty,RTRIM(Unit), RTRIM(StockAdjustment_Warehouse.Reason) FROM StockAdjustment_Warehouse INNER JOIN Product ON StockAdjustment_Warehouse.ProductID = Product.PID where Date between @d1 and @d2 order by Date", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub txtProductName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProductName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT  StockAdjustment_Warehouse.SA_ID, StockAdjustment_Warehouse.Date,RTRIM(Warehouse), StockAdjustment_Warehouse.ProductID, RTRIM(Product.ProductCode),RTRIM(Product.ProductName), RTRIM(StockAdjustment_Warehouse.AdjustmentType),StockAdjustment_Warehouse.Qty,RTRIM(Unit), RTRIM(StockAdjustment_Warehouse.Reason) FROM StockAdjustment_Warehouse INNER JOIN Product ON StockAdjustment_Warehouse.ProductID = Product.PID where ProductName like '%" & txtProductName.Text & "%' order by Date", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
