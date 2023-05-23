Imports System.Data.SqlClient

Public Class frmInventory
    Private CallfrmStockTransferValue As frmStockTransfer
    Private AndGoods As String = ""
    Public Property CallfrmStockTransfer() As frmStockTransfer
        Get
            Return CallfrmStockTransferValue
        End Get
        Set(ByVal value As frmStockTransfer)
            CallfrmStockTransferValue = value
        End Set
    End Property
    Sub fillWarehouse()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(WarehouseName) from Warehouse where RTRIM(WarehouseName) <> 'NONE' order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbWarehouse.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbWarehouse.Items.Add(drow(0).ToString())
            Next
            cmbWarehouse.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillProduct()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            'adp.SelectCommand = New SqlCommand("SELECT distinct PID,RTrim(ProductName) as PName FROM Product order by 2 ", CN)
            adp.SelectCommand = New SqlCommand("select PID,PName from (SELECT distinct PID,RTrim(ProductName) as PName FROM Product union all select -2,'--ALL MATERIALS--') as dd order by 2 ", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            CN.Close()
            'cmbMaterial.Items.Clear()
            cmbMaterial.DataSource = dtable
            cmbMaterial.DisplayMember = "PName"
            cmbMaterial.ValueMember = "PID"
            cmbMaterial.SelectedValue = -2
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillItem()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct DishID,DishName FROM Dish order by 2", CN)
            adp.SelectCommand = New SqlCommand("select DishID,PName from (SELECT distinct DishID,RTrim(DishName) as PName FROM Dish union all select -2,'--ALL ITEMS--') as dd order by 2 ", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            CN.Close()
            'cmbItem.Items.Clear()
            cmbItem.DataSource = dtable
            cmbItem.DisplayMember = "PName"
            cmbItem.ValueMember = "DishID"
            cmbItem.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetData()
        Return
        '---
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select ST_ID,Date,RTRIM(Kitchen) from StockTransfer " & AndGoods.Replace("and Kitchen", "where Kitchen") & "  order by Date"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GetData()
        fillWarehouse()
        fillItem()
        fillProduct()
    End Sub
    Sub Reset()
        cmbWarehouse.Text = ""
        cmbMaterial.Text = ""
        cmbItem.Text = ""
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
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
        Dim wh = Me.cmbWarehouse.Text.TrimEnd
        If cmbMaterial.Text <> "" Then
            'For materian
            Dim pid = Me.cmbMaterial.SelectedValue
            If pid = -2 OrElse pid > 0 AndAlso wh <> "" Then
                MakeInvMaterialBegBal(wh, pid, "'" & Me.dtpDateFrom.Value.Date.ToString("yyyy-MM-dd") & "'")
                MakeInvMaterialLast(wh, pid, "'" & Me.dtpDateFrom.Value.Date.ToString("yyyy-MM-dd") & "'", "'" & Me.dtpDateTo.Value.Date.ToString("yyyy-MM-dd") & "'")
            End If
        Else
            Dim pid = Me.cmbItem.SelectedValue
            If pid = -2 OrElse pid > 0 AndAlso wh <> "" Then
                MakeInvItemBegBal(wh, pid, "'" & Me.dtpDateFrom.Value.Date.ToString("yyyy-MM-dd") & "'")
                MakeInvItemLast(wh, pid, "'" & Me.dtpDateFrom.Value.Date.ToString("yyyy-MM-dd") & "'", "'" & Me.dtpDateTo.Value.Date.ToString("yyyy-MM-dd") & "'")
            End If
        End If


    End Sub
    Private Sub cmbTicketNo_Format(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbWarehouse.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub cmbMaterial_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbMaterial.SelectedIndexChanged
        If cmbMaterial.SelectedIndex > -1 Then
            cmbItem.SelectedIndex = -1
        End If
    End Sub
    Private Sub MakeInvMaterial(WH As String, PID As Integer)
        ' Dim AndP As String = " And (PID = " & PID & " And RTrim(Warehouse) = '" & WH & "') "
        Dim AndPr As String = " And (ProductID = " & PID & " And RTrim(Warehouse) = '" & WH & "') "
        Dim AndPrTo As String = " And (ProductID = " & PID & " And RTrim(ToWarehouse) = '" & WH & "') "
        Dim cq As String = "delete InventoryReport;
insert InventoryReport (PID,Warehouse,BeginningBal) select [ProductID],[Warehouse]
      ,sum([Qty]) from [Product_OpeningStock] where Qty >0 " & AndPr & " Group By Warehouse, ProductID;
  MERGE InventoryReport AS TARGET
USING (select ProductID,Warehouse,Sum(Qty) as Qty
  FROM [Purchase_Join] where Qty >0 " & AndPr & " Group By Warehouse, ProductID) AS SOURCE 
ON (TARGET.PID = SOURCE.ProductID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.Warehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.QtyIn = SOURCE.Qty + ISNULL(TARGET.QtyIn,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, QtyIn) VALUES (SOURCE.ProductID, RTRIM(SOURCE.Warehouse), SOURCE.Qty);
 MERGE InventoryReport AS TARGET
USING (select ProductID,Warehouse,Sum(Qty) as Qty
  FROM [StockTransfer_Join] where Qty >0 " & AndPr & " Group By Warehouse, ProductID) AS SOURCE 
ON (TARGET.PID = SOURCE.ProductID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.Warehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.QtyOut = SOURCE.Qty + ISNULL(TARGET.QtyOut,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, QtyOut) VALUES (SOURCE.ProductID, RTRIM(SOURCE.Warehouse), SOURCE.Qty);
 MERGE InventoryReport AS TARGET
USING (select ProductID,ToWarehouse,Sum(Qty) as Qty
  FROM [StockTransfer_Join] where Qty >0 " & AndPrTo & " Group By ToWarehouse, ProductID) AS SOURCE 
ON (TARGET.PID = SOURCE.ProductID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.ToWarehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.QtyIn = SOURCE.Qty + ISNULL(TARGET.QtyIn,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, QtyIn) VALUES (SOURCE.ProductID, RTRIM(SOURCE.ToWarehouse), SOURCE.Qty);
Update [InventoryReport] set  [EndingBal] =  ISNULL([BeginningBal],0) +  ISNULL([QtyIn],0) - ISNULL([QtyOut],0);
"
        con = New SqlConnection(cs)
        con.Open()
        cmd = New SqlCommand(cq)
        cmd.Connection = con
        cmd.ExecuteNonQuery()

        '----
        cq = "SELECT 
        RTRIM(P.[ProductName])
      ,[BeginningBal]
      ,[QtyIn]
,NULL as Adj
      ,[QtyOut]
      ,[EndingBal]
      ,[EndingAmount]
  FROM [InventoryReport] I left Join Product P on I.PID = P.PID
"
        cmd = New SqlCommand(cq, con)
        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Me.dgw.Rows.Clear()
        While (rdr.Read() = True)
            Me.dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
        End While
        con.Close()
        'MessageBox.Show("Done!")
    End Sub
    Private Sub MakeInvMaterialLast(WH As String, PID As Integer, FromDate As String, ToDate As String)
        Dim IDC = If(PID = -2, "", " ProductID = " & PID & " And ")
        Dim AndPrD As String = " And (X.Date Between " & FromDate & " And " & ToDate & ") And (" & IDC & " RTrim(Warehouse) = '" & WH & "') "
        Dim AndPrToD As String = " And (X.Date Between " & FromDate & " And " & ToDate & ") And (" & IDC & " RTrim(ToWarehouse) = '" & WH & "') "
        Dim cq As String = "
  MERGE InventoryReport AS TARGET
USING (select ProductID,Warehouse,Sum(Qty) as Qty
  FROM [Purchase_Join] J left Join Purchase X on J.PurchaseID = X.ST_ID  where Qty >0 " & AndPrD & " Group By Warehouse, ProductID) AS SOURCE 
ON (TARGET.PID = SOURCE.ProductID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.Warehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.QtyIn = SOURCE.Qty + ISNULL(TARGET.QtyIn,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, QtyIn) VALUES (SOURCE.ProductID, RTRIM(SOURCE.Warehouse), SOURCE.Qty);
 MERGE InventoryReport AS TARGET
USING (select ProductID,Warehouse,Sum(Qty) as Qty
  FROM [StockTransfer_Join] J left Join StockTransfer X on J.StockTransferID = X.ST_ID  where Qty >0 " & AndPrD & " Group By Warehouse, ProductID) AS SOURCE 
ON (TARGET.PID = SOURCE.ProductID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.Warehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.QtyOut = SOURCE.Qty + ISNULL(TARGET.QtyOut,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, QtyOut) VALUES (SOURCE.ProductID, RTRIM(SOURCE.Warehouse), SOURCE.Qty);
 MERGE InventoryReport AS TARGET
USING (select ProductID,ToWarehouse,Sum(Qty) as Qty
  FROM [StockTransfer_Join] J left Join StockTransfer X on J.StockTransferID = X.ST_ID   where Qty >0 " & AndPrToD & " Group By ToWarehouse, ProductID) AS SOURCE 
ON (TARGET.PID = SOURCE.ProductID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.ToWarehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.QtyIn = SOURCE.Qty + ISNULL(TARGET.QtyIn,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, QtyIn) VALUES (SOURCE.ProductID, RTRIM(SOURCE.ToWarehouse), SOURCE.Qty);
Update [InventoryReport] set  [EndingBal] =  ISNULL([BeginningBal],0) +  ISNULL([QtyIn],0) - ISNULL([QtyOut],0);
Update [InventoryReport] set  [EndingAmount] =  [EndingBal] * (select top 1 Price from Product where PID = [InventoryReport].PID);
"
        Debug.WriteLine(cq)
        con = New SqlConnection(cs)
        con.Open()
        cmd = New SqlCommand(cq)
        cmd.Connection = con
        cmd.ExecuteNonQuery()

        '----
        cq = "SELECT 
        RTRIM(P.[ProductName])
      ,[BeginningBal]
      ,[QtyIn]
,NULL as Adj
      ,[QtyOut]
      ,[EndingBal]
      ,[EndingAmount]
  FROM [InventoryReport] I left Join Product P on I.PID = P.PID
"
        cmd = New SqlCommand(cq, con)
        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Me.dgw.Rows.Clear()
        While (rdr.Read() = True)
            Me.dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
        End While
        con.Close()
        'MessageBox.Show("Done!")
    End Sub
    Private Sub MakeInvMaterialBegBal(WH As String, PID As Integer, fromDate As String)
        Dim IDC = If(PID = -2, "", " ProductID = " & PID & " And ")
        Dim AndPr As String = " And (" & IDC & " RTrim(Warehouse) = '" & WH & "') "
        Dim AndPrD As String = " And X.Date < " & fromDate & " And (" & IDC & " RTrim(Warehouse) = '" & WH & "') "
        ' Dim AndPrTo As String = " And (" & IDC & " RTrim(ToWarehouse) = '" & WH & "') "
        Dim AndPrToD As String = " And X.Date < " & fromDate & " And (" & IDC & " RTrim(ToWarehouse) = '" & WH & "') "
        Dim cq As String = "delete InventoryReport;
insert InventoryReport (PID,Warehouse,BeginningBal) select [ProductID],[Warehouse]
      ,sum([Qty]) from [Product_OpeningStock] where Qty >0 " & AndPr & " Group By Warehouse, ProductID;
  MERGE InventoryReport AS TARGET
USING (select ProductID,Warehouse,Sum(Qty) as Qty
  FROM [Purchase_Join] J left Join Purchase X on J.PurchaseID = X.ST_ID where Qty >0 " & AndPrD & " Group By Warehouse, ProductID) AS SOURCE 
ON (TARGET.PID = SOURCE.ProductID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.Warehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.BeginningBal = SOURCE.Qty + ISNULL(TARGET.BeginningBal,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, BeginningBal) VALUES (SOURCE.ProductID, RTRIM(SOURCE.Warehouse), SOURCE.Qty);
 MERGE InventoryReport AS TARGET
USING (select ProductID,Warehouse,Sum(Qty) as Qty
  FROM [StockTransfer_Join] J left Join StockTransfer X on J.StockTransferID = X.ST_ID  where Qty >0 " & AndPrD & " Group By Warehouse, ProductID) AS SOURCE 
ON (TARGET.PID = SOURCE.ProductID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.Warehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.BeginningBal = - SOURCE.Qty + ISNULL(TARGET.BeginningBal,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, BeginningBal) VALUES (SOURCE.ProductID, RTRIM(SOURCE.Warehouse), (-1) * SOURCE.Qty);
 MERGE InventoryReport AS TARGET
USING (select ProductID,ToWarehouse,Sum(Qty) as Qty
  FROM [StockTransfer_Join] J left Join StockTransfer X on J.StockTransferID = X.ST_ID where Qty >0 " & AndPrToD & " Group By ToWarehouse, ProductID) AS SOURCE 
ON (TARGET.PID = SOURCE.ProductID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.ToWarehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.BeginningBal = SOURCE.Qty + ISNULL(TARGET.BeginningBal,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, BeginningBal) VALUES (SOURCE.ProductID, RTRIM(SOURCE.ToWarehouse), SOURCE.Qty);

"
        con = New SqlConnection(cs)
        con.Open()
        cmd = New SqlCommand(cq)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()
        'MessageBox.Show("Done!")
    End Sub
    Private Sub MakeInvItemLast(WH As String, PID As Integer, FromDate As String, ToDate As String)
        Dim IDC = If(PID = -2, "", " DishID = " & PID & " And ")
        Dim AndPrD As String = " And (X.Date Between " & FromDate & " And " & ToDate & ") And (" & IDC & " RTrim(Warehouse) = '" & WH & "') "
        Dim AndPrToD As String = " And (X.Date Between " & FromDate & " And " & ToDate & ") And (" & IDC & " RTrim(ToWarehouse) = '" & WH & "') "
        Dim cq As String = "
  MERGE InventoryReport AS TARGET
USING (select DishID,Warehouse,Sum(Qty) as Qty
  FROM [PurchaseItem_Join] J left Join Purchase X on J.PurchaseID = X.ST_ID  where Qty >0 " & AndPrD & " Group By Warehouse, DishID) AS SOURCE 
ON (TARGET.PID = SOURCE.DishID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.Warehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.QtyIn = SOURCE.Qty + ISNULL(TARGET.QtyIn,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, QtyIn) VALUES (SOURCE.DishID, RTRIM(SOURCE.Warehouse), SOURCE.Qty);
 MERGE InventoryReport AS TARGET
USING (select DishID,Warehouse,Sum(Qty) as Qty
  FROM [StockTransferItem_Join] J left Join StockTransfer X on J.StockTransferID = X.ST_ID  where Qty >0 " & AndPrD & " Group By Warehouse, DishID) AS SOURCE 
ON (TARGET.PID = SOURCE.DishID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.Warehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.QtyOut = SOURCE.Qty + ISNULL(TARGET.QtyOut,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, QtyOut) VALUES (SOURCE.DishID, RTRIM(SOURCE.Warehouse), SOURCE.Qty);
 MERGE InventoryReport AS TARGET
USING (select DishID,ToWarehouse,Sum(Qty) as Qty
  FROM [StockTransferItem_Join] J left Join StockTransfer X on J.StockTransferID = X.ST_ID   where Qty >0 " & AndPrToD & " Group By ToWarehouse, DishID) AS SOURCE 
ON (TARGET.PID = SOURCE.DishID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.ToWarehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.QtyIn = SOURCE.Qty + ISNULL(TARGET.QtyIn,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, QtyIn) VALUES (SOURCE.DishID, RTRIM(SOURCE.ToWarehouse), SOURCE.Qty);
Update [InventoryReport] set  [EndingBal] =  ISNULL([BeginningBal],0) +  ISNULL([QtyIn],0) - ISNULL([QtyOut],0);
Update [InventoryReport] set  [EndingAmount] =  [EndingBal] * (select top 1 PurcPrice from Dish where DishID = [InventoryReport].PID);
Update [InventoryReport] set  [EndingAmount] =  [EndingBal] * (select top 1 R.FixedCost from Dish D left join Recipe R on RTrim(D.DishName) = RTrim(R.Dish) where DishID = [InventoryReport].PID) where [EndingAmount] is NULL;
"
        Debug.WriteLine(cq)
        con = New SqlConnection(cs)
        con.Open()
        cmd = New SqlCommand(cq)
        cmd.Connection = con
        cmd.ExecuteNonQuery()

        '----
        cq = "SELECT 
        RTRIM(P.[DishName])
      ,[BeginningBal]
      ,[QtyIn]
,NULL as Adj
      ,[QtyOut]
      ,[EndingBal]
      ,[EndingAmount]
  FROM [InventoryReport] I left Join Dish P on I.PID = P.DishID
"
        cmd = New SqlCommand(cq, con)
        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Me.dgw.Rows.Clear()
        While (rdr.Read() = True)
            Me.dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
        End While
        con.Close()
        'MessageBox.Show("Done!")
    End Sub
    Private Sub MakeInvItemBegBal(WH As String, PID As Integer, fromDate As String)
        Dim IDC = If(PID = -2, "", " DishID = " & PID & " And ")
        'Dim AndPr As String = " And (" & IDC & " RTrim(Warehouse) = '" & WH & "') "
        Dim AndPrD As String = " And X.Date < " & fromDate & " And (" & IDC & " RTrim(Warehouse) = '" & WH & "') "
        ' Dim AndPrTo As String = " And (" & IDC & " RTrim(ToWarehouse) = '" & WH & "') "
        Dim AndPrToD As String = " And X.Date < " & fromDate & " And (" & IDC & " RTrim(ToWarehouse) = '" & WH & "') "
        Dim cq As String = "delete InventoryReport;
  MERGE InventoryReport AS TARGET
USING (select DishID,Warehouse,Sum(Qty) as Qty
  FROM [PurchaseItem_Join] J left Join Purchase X on J.PurchaseID = X.ST_ID where Qty >0 " & AndPrD & " Group By Warehouse, DishID) AS SOURCE 
ON (TARGET.PID = SOURCE.DishID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.Warehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.BeginningBal = SOURCE.Qty + ISNULL(TARGET.BeginningBal,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, BeginningBal) VALUES (SOURCE.DishID, RTRIM(SOURCE.Warehouse), SOURCE.Qty);
 MERGE InventoryReport AS TARGET
USING (select DishID,Warehouse,Sum(Qty) as Qty
  FROM [StockTransferItem_Join] J left Join StockTransfer X on J.StockTransferID = X.ST_ID  where Qty >0 " & AndPrD & " Group By Warehouse, DishID) AS SOURCE 
ON (TARGET.PID = SOURCE.DishID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.Warehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.BeginningBal = - SOURCE.Qty + ISNULL(TARGET.BeginningBal,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, BeginningBal) VALUES (SOURCE.DishID, RTRIM(SOURCE.Warehouse), (-1) * SOURCE.Qty);
 MERGE InventoryReport AS TARGET
USING (select DishID,ToWarehouse,Sum(Qty) as Qty
  FROM [StockTransferItem_Join] J left Join StockTransfer X on J.StockTransferID = X.ST_ID where Qty >0 " & AndPrToD & " Group By ToWarehouse, DishID) AS SOURCE 
ON (TARGET.PID = SOURCE.DishID and RTRIM(TARGET.Warehouse) = RTRIM(SOURCE.ToWarehouse)) 
WHEN MATCHED THEN UPDATE SET TARGET.BeginningBal = SOURCE.Qty + ISNULL(TARGET.BeginningBal,0)
WHEN NOT MATCHED BY TARGET 
THEN INSERT (PID, Warehouse, BeginningBal) VALUES (SOURCE.DishID, RTRIM(SOURCE.ToWarehouse), SOURCE.Qty);

"
        Debug.WriteLine(cq)
        con = New SqlConnection(cs)
        con.Open()
        cmd = New SqlCommand(cq)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()
        'MessageBox.Show("Done!")
    End Sub

    Private Sub cmbItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbItem.SelectedIndexChanged
        If cmbItem.SelectedIndex > -1 Then
            cmbMaterial.SelectedIndex = -1
        End If
    End Sub
End Class

