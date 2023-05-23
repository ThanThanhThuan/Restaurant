Imports System.Data.SqlClient

Public Class Retrieving
    Public Sub insertStock(ByVal quantity As Decimal, ByVal item As String)
        Dim cons As New SqlConnection(cs)
        cmd = New SqlCommand("INSERT INTO tblstock VALUES('" & item & "',GetDate(), '" & quantity & "', 0.00, '" & quantity & "', 0.00, '" & quantity & "', N'Register item')", cons)
        cons.Open()
        cmd.ExecuteNonQuery()
        cons.Close()
    End Sub
    Public Shared ReadOnly supId As String
    Public Function dayTime() As String
        Dim cons As New SqlConnection(cs)
        cmd = New SqlCommand("select convert(nvarchar, getdate(), 100)", cons)
        cons.Open()
        Return cmd.ExecuteScalar().ToString()
    End Function
    Public Function footer() As String
        Dim cons As New SqlConnection(cs)
        cmd = New SqlCommand("SELECT TOP 1 [TicketFooterMessage] FROM [Hotel]", cons)
        cons.Open()
        Return cmd.ExecuteScalar().ToString()
    End Function
    Public Shared Function logoo() As DataTable
        Dim cons As New SqlConnection(cs)
        cmd = New SqlCommand("SELECT TOP 1 * FROM [Hotel]", cons)
        cons.Open()
        Dim sda As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        sda.Fill(dt)
        cons.Close()
        Return dt
    End Function
    Public Function GetProfitLossrpt(ByVal dateFrom As DateTime, ByVal dateTo As DateTime) As DataTable
        Dim cons As New SqlConnection(cs)
        Dim sSQL As String = "SELECT distinct [DishName] as Item,convert(nvarchar, ValidityFrom, 103) as Tarehe,sum(OT.Quantity) as [Stock],sum((OT.Quantity*D.PurcPrice)) as [PLUS_MINUS],sum((OT.Quantity*D.UnitPrice)) as Total, (sum(isnull((OT.Quantity*D.UnitPrice),0)) - sum(isnull((OT.Quantity*D.PurcPrice),0))) as Balance"
        sSQL += " FROM [Dish] D inner join RestaurantPOS_OrderedProductBillKOT OT on D.DishName = OT.Dish"
        sSQL += " where convert(nvarchar, OT.ValidityFrom, 101) between @dateFrom and @dateTo group by DishName, convert(nvarchar, ValidityFrom, 103)"
        cmd = New SqlCommand(sSQL, cons)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@dateFrom", SqlDbType.DateTime).Value = dateFrom.ToString("MM/dd/yyyy")
        cmd.Parameters.Add("@dateTo", SqlDbType.DateTime).Value = dateTo.ToString("MM/dd/yyyy")
        Dim sda As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        sda.Fill(dt)
        cons.Close()
        Return dt
    End Function
    Public Function GetItemizedSalesrpt(ByVal dateFrom As DateTime, ByVal dateTo As DateTime, Optional category As String = "", Optional waiter As String = "") As DataTable
        Dim cons As New SqlConnection(cs)
        Dim sSQL As String = "SELECT BillNo as [BillID],[Dish],[Quantity],convert(nvarchar, [BillDate], 103) as [VATPer],[TotalAmount],[Category],Waiter AS STPer"
        sSQL += " FROM [RestaurantPOS_OrderedProductBillKOT] OPB inner join [RestaurantPOS_BillingInfoKOT] RB"
        sSQL += " on OPB.BillID = RB.Id where OPB.Category LIKE '%" & category & "%' and RB.Waiter LIKE '%" & waiter & "%' and convert(nvarchar, RB.BillDate,101) between @dateFrom and @dateTo"
        sSQL += " UNION ALL"
        sSQL += " SELECT BillNo as [BillID],[Dish] ,[Quantity],convert(nvarchar, [BillDate], 103) as [VATPer],[TotalAmount] "
        sSQL += " ,[Category],Operator AS STPer FROM [RestaurantPOS_OrderedProductBillTA] OPT"
        sSQL += " inner join RestaurantPOS_BillingInfoTA BT on OPT.BillID = BT.Id"
        sSQL += "  where OPT.Category LIKE '%" & category & "%' "
        sSQL += " And BT.Operator LIKE '%" & waiter & "%' and convert(nvarchar, BT.BillDate, 101) between @dateFrom and @dateTo"
        cmd = New SqlCommand(sSQL, cons)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@dateFrom", SqlDbType.Date).Value = dateFrom.ToString("MM/dd/yyyy")
        cmd.Parameters.Add("@dateTo", SqlDbType.Date).Value = dateTo.ToString("MM/dd/yyyy")
        Dim sda As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        sda.Fill(dt)
        cons.Close()
        Return dt
    End Function
    Public Function GetsalesHappyHoursrpt(ByVal dateFrom As DateTime, ByVal dateTo As DateTime, Optional category As String = "", Optional waiter As String = "") As DataTable
        Dim cons As New SqlConnection(cs)
        Dim sSQL As String = "SELECT BillNo as [BillID],[Dish],[Quantity],convert(nvarchar, [BillDate], 103) as [VATPer],[TotalAmount],[Category],Waiter AS STPer"
        sSQL += " FROM [RestaurantPOS_OrderedProductBillKOT] OPB inner join [RestaurantPOS_BillingInfoKOT] RB"
        sSQL += " on OPB.BillID = RB.Id where OPB.isHappyHour = 1 and OPB.Category LIKE '%" & category & "%' and RB.Waiter LIKE '%" & waiter & "%' and convert(nvarchar, RB.BillDate,101) between @dateFrom and @dateTo"
        cmd = New SqlCommand(sSQL, cons)
        cmd.CommandType = CommandType.Text
        cmd.Parameters.Add("@dateFrom", SqlDbType.Date).Value = dateFrom.ToString("MM/dd/yyyy")
        cmd.Parameters.Add("@dateTo", SqlDbType.Date).Value = dateTo.ToString("MM/dd/yyyy")
        Dim sda As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        sda.Fill(dt)
        cons.Close()
        Return dt
    End Function
    Public Sub ReduceStock(ByVal quantity As Decimal, ByVal item As String)
        Dim cons As New SqlConnection(cs)
        cmd = New SqlCommand("INSERT INTO tblstock SELECT TOP 1 '" & item & "',GetDate(), Balance, N'-'+cast('" & quantity & "' AS VARCHAR(50)), Balance - '" & quantity & "', 0.00, Balance - '" & quantity & "', N'Reduce stock' FROM tblStock WHERE Item = '" & item & "' ORDER BY No# DESC", cons)
        cons.Open()
        cmd.ExecuteNonQuery()
        cons.Close()
    End Sub
    Public Sub AddStock(ByVal quantity As Decimal, ByVal item As String)
        Dim cons As New SqlConnection(cs)
        cmd = New SqlCommand("INSERT INTO tblstock SELECT TOP 1 '" & item & "',GetDate(), Balance, N'+'+cast('" & quantity & "' AS VARCHAR(50)), Balance + '" & quantity & "', 0.00, Balance + '" & quantity & "', N'Add stock' FROM tblStock WHERE Item = '" & item & "' ORDER BY No# DESC", cons)
        cons.Open()
        cmd.ExecuteNonQuery()
        cons.Close()
    End Sub
    Public Sub SoldStock(ByVal quantity As Decimal, ByVal item As String)
        Dim cons As New SqlConnection(cs)
        cmd = New SqlCommand("INSERT INTO tblstock SELECT TOP 1 '" & item & "',GetDate(), Balance, 0.00, Balance, '" & quantity & "', Balance - '" & quantity & "', N'Sold stock' FROM tblStock WHERE Item = '" & item & "' ORDER BY No# DESC", cons)
        cons.Open()
        cmd.ExecuteNonQuery()
        cons.Close()
    End Sub
    Private Function GateDate()
        Dim cons As New SqlConnection(cs)
        cmd = New SqlCommand("SELECT CONVERT(NCHAR, GETDATE(), 106)", cons)
        cons.Open()
        Dim dte As String = cmd.ExecuteScalar().ToString()
        con.Close()
        Return dte.Trim()
    End Function
    Public Function StockReport(ByVal dte As DateTime, ByVal dte1 As DateTime, Optional item As String = "", Optional section As String = "") As DataTable
        Dim cons As New SqlConnection(cs)
        cmd = New SqlCommand("SELECT [Item],CONVERT(VARCHAR(15), [Tarehe], 103) AS Tarehe,[Stock],[PLUS_MINUS],[Total],[Sold],[Balance],[Narration] FROM tblstock WHERE Item LIKE '%" & item & "%' AND convert(nvarchar, Tarehe, 101) BETWEEN '" & dte.ToString("MM/dd/yyyy") & "' AND '" & dte1.ToString("MM/dd/yyyy") & "' and Item in (SELECT distinct D.[DishName] FROM [Dish] D inner join Category C on D.Category = C.CategoryName where C.Kitchen like '%" & section & "%') ORDER BY No# ASC", cons)
        cons.Open()
        Dim sda As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        sda.Fill(dt)
        cons.Close()
        Return dt
    End Function
    Public Function GetStocksBalancerpt(Optional item As String = "", Optional section As String = "") As DataSet
        Dim cons As New SqlConnection(cs)
        Dim sSQL As String = "SELECT [Id] as [ProductCode],[Dish] as [ProductName] ,[Qty] as [Description], D.PurcPrice as [Price], (Qty * D.PurcPrice) as [ReorderPoint] FROM [Temp_Stock_Store] TST inner join Dish D on TST.Dish = D.DishName where D.DishName like '%" + item + "%' and D.Category in(SELECT [CategoryName] FROM [Category] where Kitchen like '%" & section & "%')"
        'Dim sSQL As String = "SELECT [PID], [ProductCode], [ProductName], [Category] As Category, [Unit], FORMAT([Price], 'n2') AS Price, Qty As [Description], FORMAT((Qty * Price), 'n2') As [ReorderPoint] FROM Product P INNER JOIN Temp_Stock_RM T On P.PID = T.ProductID WHERE P.ProductName Like '%" + item + "%'"
        'sSQL += " SELECT FORMAT(SUM(Qty * Price), 'n2')As [ReorderPoint] FROM Product P INNER JOIN Temp_Stock_RM T On P.PID = T.ProductID WHERE P.ProductName Like '%" + item + "%'"
        cmd = New SqlCommand(sSQL, cons)
        cmd.CommandType = CommandType.Text
        Dim sda As New SqlDataAdapter(cmd)
        Dim dS As New DataSet()
        sda.Fill(dS)
        con.Close()
        Return dS
    End Function
    Public Shared Function isHappyHour() As Boolean
        Dim cons As New SqlConnection(cs)
        Dim sSQL As String = "IF EXISTS(select distinct 1 from OtherSetting where ishappyHour = 1 and convert(nvarchar, getdate(), 103) = convert(nvarchar, [happyHourDate], 103) and (substring(convert(nvarchar, getdate(), 20),1,16) between concat(convert(nvarchar, getdate(), 23),' ',substring(convert(nvarchar, happyHourTime_from, 20), 1,5)) and concat(convert(nvarchar, getdate(), 23),' ',substring(convert(nvarchar, happyHourTime_to, 20), 1,5))))"
        sSQL += " select 1 as id"
        sSQL += " else"
        sSQL += " select 0 as id"
        cmd = New SqlCommand(sSQL, cons)
        cmd.CommandType = CommandType.Text
        cons.Open()
        Dim ishappyhr As Boolean = Convert.ToBoolean(cmd.ExecuteScalar())
        cons.Close()
        Return ishappyhr
    End Function
    Public Function salesExpensesOverview(ByVal dateFrom As DateTime, ByVal dateTo As DateTime) As DataTable
        Dim cons As New SqlConnection(cs)
        cmd = New SqlCommand("uspSalesExpensesOverview", cons)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@dateFrom", SqlDbType.DateTime).Value = dateFrom
        cmd.Parameters.Add("@dateTo", SqlDbType.DateTime).Value = dateTo
        cons.Open()
        Dim sda As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        sda.Fill(dt)
        cons.Close()
        Return dt
    End Function
    Public Function stockUsage(ByVal dateFrom As DateTime, ByVal dateTo As DateTime, Optional category As String = "") As DataTable
        Dim cons As New SqlConnection(cs)
        cmd = New SqlCommand("uspStockUsage", cons)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@dateFrom", SqlDbType.DateTime).Value = dateFrom
        cmd.Parameters.Add("@dateTo", SqlDbType.DateTime).Value = dateTo
        cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 20).Value = category
        cons.Open()
        Dim sda As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        sda.Fill(dt)
        cons.Close()
        Return dt
    End Function
    Public Function mainWHValuation(ByVal dateFrom As DateTime, ByVal dateTo As DateTime, Optional category As String = "") As DataTable
        Dim cons As New SqlConnection(cs)
        cmd = New SqlCommand("uspMainWHValuation", cons)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@dateFrom", SqlDbType.DateTime).Value = dateFrom
        cmd.Parameters.Add("@dateTo", SqlDbType.DateTime).Value = dateTo
        cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 20).Value = category
        cons.Open()
        Dim sda As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        sda.Fill(dt)
        cons.Close()
        Return dt
    End Function
End Class
