Imports System.Data.SqlClient
Public Class frmStockTransfer
    Dim dgvMaterial As New DataGridView
    Private IsGoodsValue As Boolean


    Public Property IsGoods() As Boolean
        Get
            Return IsGoodsValue
        End Get
        Set(ByVal value As Boolean)
            IsGoodsValue = value
        End Set
    End Property
    Sub FillStore()
        If Not IsGoods Then
            Try
                Dim CN As New SqlConnection(cs)
                CN.Open()
                adp = New SqlDataAdapter()
                'adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(KitchenName) FROM Kitchen", CN)
                adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(WarehouseName) FROM Warehouse  where WarehouseName <> 'NONE'", CN)
                ds = New DataSet("ds")
                adp.Fill(ds)
                dtable = ds.Tables(0)
                cmbKitchen.Items.Clear()
                For Each drow As DataRow In dtable.Rows
                    cmbKitchen.Items.Add(drow(0).ToString())
                Next
                '--
                Me.cmbFromWH.Items.Clear()
                For Each drow As DataRow In dtable.Rows
                    Me.cmbFromWH.Items.Add(drow(0).ToString())
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else 'goods
            Try
                Dim CN As New SqlConnection(cs)
                CN.Open()
                adp = New SqlDataAdapter()
                'adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(KitchenName) FROM Kitchen", CN)
                adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(WarehouseName) FROM Warehouse where WarehouseType = 'Finished Goods Warehouse'", CN)
                ds = New DataSet("ds")
                adp.Fill(ds)
                dtable = ds.Tables(0)
                cmbKitchen.Items.Clear()
                For Each drow As DataRow In dtable.Rows
                    cmbKitchen.Items.Add(drow(0).ToString())
                Next
                If cmbKitchen.Items.Count > 0 Then
                    cmbKitchen.SelectedIndex = 0
                End If
                '--
                adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(WarehouseName) FROM Warehouse where WarehouseName <> 'NONE' And (WarehouseType = 'Main Warehouse' or WarehouseType = 'Production Warehouse')", CN)
                ds = New DataSet("ds")
                adp.Fill(ds)
                dtable = ds.Tables(0)
                Me.cmbFromWH.Items.Clear()
                For Each drow As DataRow In dtable.Rows
                    Me.cmbFromWH.Items.Add(drow(0).ToString())
                Next
                If cmbFromWH.Items.Count > 0 Then
                    cmbFromWH.SelectedIndex = 0
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub
    Sub Reset()
        dtpDate.Value = Today
        txtAvailableQty.Text = ""
        txtExpiryDate.Text = ""
        txtProductName.Text = ""
        txtSearchByProductName.Text = ""
        cmbKitchen.SelectedIndex = -1
        txtTransferQty.Text = ""
        txtWarehouse.Text = ""
        dgw.Rows.Clear()
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnPrint.Enabled = False
        btnRemove.Enabled = False
        btnAdd.Enabled = True
        lblUnit.Visible = False
        lblQty.Text = ""
        lblSet.Text = ""
        If Me.rdProduct.Checked Then
            Getdata()
        ElseIf Me.rdItem.Checked Then
            GetItemdata()
        Else
            GetDishdata()
        End If
        auto()
        If Not IsGoods Then rdProduct.Checked = True
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 ST_ID FROM StockTransfer ORDER BY ST_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ST_ID")
            End If
            rdr.Close()
            ' Increase the ID by 1
            value += 1
            ' Because incrementing a string with an integer removes 0's
            ' we need to replace them. If necessary.
            If value <= 9 Then 'Value is between 0 and 10
                value = "000" & value
            ElseIf value <= 99 Then 'Value is between 9 and 100
                value = "00" & value
            ElseIf value <= 999 Then 'Value is between 999 and 1000
                value = "0" & value
            End If
        Catch ex As Exception
            ' If an error occurs, check the connection state and close it if necessary.
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            value = "0000"
        End Try
        Return value
    End Function
    Sub auto()
        Try
            txtID.Text = GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsGoods AndAlso (GetWHType(Me.cmbFromWH.Text) = "Production Warehouse" AndAlso GetWHType(Me.cmbKitchen.Text) = "Finished Goods Warehouse") Then
            SaveByRecipe()
            Return
        End If
        Try
            Dim retrv As New Retrieving()
            If (rdProduct.Checked) Then

                If Len(Trim(cmbKitchen.Text)) = 0 Then
                    MessageBox.Show("Please select kitchen/section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbKitchen.Focus()
                    Exit Sub
                End If
                If dgw.Rows.Count = 0 Then
                    MessageBox.Show("sorry no product added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                For Each row As DataGridViewRow In dgw.Rows
                    Dim con As New SqlConnection(cs)
                    con.Open()
                    Dim cmd As New SqlCommand("SELECT qty from Temp_Stock where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3", con)
                    'from wh
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    If ds.Tables(0).Rows.Count > 0 Then
                        lblQty.Text = ds.Tables(0).Rows(0)("Qty")
                        If Val(row.Cells(4).Value) > Val(lblQty.Text) Then
                            MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. of Product name '" & row.Cells(2).Value & "' from Warehouse '" & row.Cells(0).Value & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                    con.Close()
                Next
                For Each row As DataGridViewRow In dgw.Rows
                    con = New SqlConnection(cs)
                    con.Open()
                    'frm wh
                    Dim ct As String = "select WareHouse,ProductID,ExpiryDate from temp_Stock where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty=Qty - " & Val(row.Cells(4).Value) & ",Date_done = getdate() where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        'from wh
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                    '---zz add
                    'to wh
                    con = New SqlConnection(cs)
                    con.Open()
                    ct = "select WareHouse,ProductID,ExpiryDate from temp_Stock where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Me.cmbKitchen.Text)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty=Qty + " & Val(row.Cells(4).Value) & ",Date_done = getdate() where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        'to wh
                        cmd.Parameters.AddWithValue("@d1", Me.cmbKitchen.Text)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    Else
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb3 As String = "insert into Temp_Stock(Warehouse,ProductID,ExpiryDate,Qty,Date_done) VALUES (@d0,@d1,@dex,@d2,GetDate())"
                        cmd = New SqlCommand(cb3)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d0", Me.cmbKitchen.Text)
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@dex", row.Cells(3).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(4).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                Next
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "insert into StockTransfer(ST_ID, Date,Kitchen) VALUES (@d1,@d2,@d3)"
                cmd = New SqlCommand(cb)
                cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
                cmd.Parameters.AddWithValue("@d2", dtpDate.Value.Date)
                cmd.Parameters.AddWithValue("@d3", cmbKitchen.Text)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                'from wh
                'Dim cb1 As String = "insert into StockTransfer_Join(StockTransferID,Warehouse,ProductID,ExpiryDate,Qty) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4)"
                Dim cb1 As String = "insert into StockTransfer_Join(StockTransferID,Warehouse,ProductID,ExpiryDate,Qty,ToWarehouse) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4,@d5)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In dgw.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                        'zz to wh
                        cmd.Parameters.AddWithValue("@d5", cmbKitchen.Text)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                'RM

                'For Each row As DataGridViewRow In dgw.Rows
                '    If Not row.IsNewRow Then
                '        con = New SqlConnection(cs)
                '        con.Open()
                '        Dim ctx As String = "select ProductID from Temp_Stock_RM where ProductID=@d1"
                '        cmd = New SqlCommand(ctx)
                '        cmd.Connection = con
                '        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                '        rdr = cmd.ExecuteReader()
                '        If (rdr.Read()) Then

                '            con = New SqlConnection(cs)
                '            con.Open()
                '            Dim cb2 As String = "Update Temp_Stock_RM set Qty = Qty + " & row.Cells(4).Value & ",Date_done = getdate() where ProductID=@d1"
                '            cmd = New SqlCommand(cb2)
                '            cmd.Connection = con
                '            cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                '            cmd.ExecuteReader()
                '            con.Close()

                '        Else
                '            con = New SqlConnection(cs)
                '            con.Open()
                '            Dim cb3 As String = "insert into Temp_Stock_RM(ProductID,Qty,Date_done) VALUES (@d1,@d2,GetDate())"
                '            cmd = New SqlCommand(cb3)
                '            cmd.Connection = con
                '            cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                '            cmd.Parameters.AddWithValue("@d2", Val(row.Cells(4).Value))
                '            cmd.ExecuteReader()
                '            con.Close()
                '        End If
                '    End If
                'Next

                LogFunc(lblUser.Text, "added the new Stock Transfer having Transfer ID '" & txtID.Text & "'")
                MessageBox.Show("Successfully saved", "Stock Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSave.Enabled = False
                con.Close()
                'zz
                Me.DataGridView1.Rows.Clear()
                '--
                If Me.rdProduct.Checked Then
                    Getdata()
                ElseIf Me.rdItem.Checked Then
                    GetItemdata()
                Else
                    GetDishdata()
                End If
                btnPrint.Enabled = True
            End If
            '==========================ITEM==========
            If (rdItem.Checked) Then

                If Len(Trim(cmbKitchen.Text)) = 0 Then
                    MessageBox.Show("Please select kitchen/section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbKitchen.Focus()
                    Exit Sub
                End If
                If dgw.Rows.Count = 0 Then
                    MessageBox.Show("sorry no product added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                For Each row As DataGridViewRow In dgw.Rows
                    Dim con As New SqlConnection(cs)
                    con.Open()
                    Dim cmd As New SqlCommand("SELECT qty from TempItem_Stock where Warehouse=@d1 and DishID=@d2 and ExpiryDate=@d3", con)
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    If ds.Tables(0).Rows.Count > 0 Then
                        lblQty.Text = ds.Tables(0).Rows(0)("Qty")
                        If Val(row.Cells(4).Value) > Val(lblQty.Text) Then
                            MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. of Product name '" & row.Cells(2).Value & "' from Warehouse '" & row.Cells(0).Value & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                    con.Close()
                Next
                For Each row As DataGridViewRow In dgw.Rows
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select WareHouse,DishID,ExpiryDate from tempItem_Stock where Warehouse=@d1 and DishID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update TempItem_Stock set Qty=Qty - " & Val(row.Cells(4).Value) & " where Warehouse=@d1 and DishID=@d2 and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                    'To wh zzzzz
                    con = New SqlConnection(cs)
                    con.Open()
                    ct = "select WareHouse,DishID,ExpiryDate from tempItem_Stock where Warehouse=@d1 and DishID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Me.cmbKitchen.Text)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update TempItem_Stock set Qty=Qty + " & Val(row.Cells(4).Value) & ",Date_done = getdate() where Warehouse=@d1 and DishID=@d2 and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        'to wh
                        cmd.Parameters.AddWithValue("@d1", Me.cmbKitchen.Text)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    Else
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb3 As String = "insert into TempItem_Stock(Warehouse,DishID,ExpiryDate,Qty,Date_done) VALUES (@d0,@d1,@dex,@d2,GetDate())"
                        cmd = New SqlCommand(cb3)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d0", Me.cmbKitchen.Text)
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@dex", row.Cells(3).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(4).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                Next
                con = New SqlConnection(cs)
                con.Open()
                'Dim cb As String = "insert into StockTransferItem(ST_ID, Date,Kitchen) VALUES (@d1,@d2,@d3)"
                Dim cb As String = "insert into StockTransfer(ST_ID, Date,Kitchen) VALUES (@d1,@d2,@d3)"
                cmd = New SqlCommand(cb)
                cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
                cmd.Parameters.AddWithValue("@d2", dtpDate.Value.Date)
                cmd.Parameters.AddWithValue("@d3", cmbKitchen.Text)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                'Dim cb1 As String = "insert into StockTransferItem_Join(StockTransferID,Warehouse,DishID,ExpiryDate,Qty,ValidityDate) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4,GetDate())"
                Dim cb1 As String = "insert into StockTransferItem_Join(StockTransferID,Warehouse,DishID,ExpiryDate,Qty,ToWarehouse,ValidityDate) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4,@d5,GetDate())"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In dgw.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                        'to wh
                        cmd.Parameters.AddWithValue("@d5", Me.cmbKitchen.Text)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                'zz comm
                'For Each row As DataGridViewRow In dgw.Rows
                '    If Not row.IsNewRow Then
                '        con = New SqlConnection(cs)
                '        con.Open()
                '        Dim ctx As String = "select ID from Temp_Stock_Store where ID=@d1"
                '        cmd = New SqlCommand(ctx)
                '        cmd.Connection = con
                '        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                '        rdr = cmd.ExecuteReader()
                '        If (rdr.Read()) Then

                '            con = New SqlConnection(cs)
                '            con.Open()
                '            Dim cb2 As String = "Update Temp_Stock_Store set Qty = Qty + " & row.Cells(4).Value & " where ID=@d1"
                '            cmd = New SqlCommand(cb2)
                '            cmd.Connection = con
                '            cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                '            cmd.ExecuteReader()
                '            con.Close()
                '            retrv.AddStock((CType(row.Cells(4).Value, Decimal)), row.Cells(2).Value.ToString())  'Added by Jaemsoft Tech 12/02/2020 3:15AM
                '        Else
                '            con = New SqlConnection(cs)
                '            con.Open()
                '            Dim cb3 As String = "insert into Temp_Stock_Store(Dish,Qty) VALUES (@d1,@d2)"
                '            cmd = New SqlCommand(cb3)
                '            cmd.Connection = con
                '            cmd.Parameters.AddWithValue("@d1", row.Cells(2).Value)
                '            cmd.Parameters.AddWithValue("@d2", Val(row.Cells(4).Value))
                '            cmd.ExecuteReader()
                '            con.Close()
                '            retrv.insertStock((CType(row.Cells(4).Value, Decimal)), row.Cells(2).Value.ToString())  'Added by Jaemsoft Tech 12/02/2020 3:15AM
                '        End If
                '    End If
                'Next

                LogFunc(lblUser.Text, "added the new Stock Transfer having Transfer ID '" & txtID.Text & "'")
                MessageBox.Show("Successfully saved", "Stock Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSave.Enabled = False
                con.Close()
                If Not IsGoods Then rdProduct.Checked = True
                btnPrint.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()
        '--find by _Join tables
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from StockTransfer where ST_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim ct As String = ""
                For i = 1 To 2
                    Dim con3 = New SqlConnection(cs)
                    con3.Open()
                    If i = 1 Then
                        ct = "SELECT [Warehouse],[ProductID],[Qty],[ToWareHouse]  FROM [StockTransfer_Join] where [StockTransferID] = @d1"
                    Else
                        ct = "SELECT [Warehouse],[DishID],[Qty],[ToWareHouse]  FROM [StockTransferItem_Join] where [StockTransferID] = @d1"
                    End If

                    cmd = New SqlCommand(ct)
                    cmd.Connection = con3
                    cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
                    rdr = cmd.ExecuteReader()
                    Dim cb2 As String = ""
                    Do While rdr.Read()
                        If i = 1 Then
                            cb2 &= " Update Temp_Stock set Qty=Qty + " & Val(rdr(2)) & " where Warehouse='" & rdr(0) & "' and ProductID=" & Val(rdr(1)) & vbNewLine
                            cb2 &= " Update Temp_Stock set Qty=Qty - " & Val(rdr(2)) & " where Warehouse='" & rdr(3) & "' and ProductID=" & Val(rdr(1)) & vbNewLine
                        Else
                            cb2 &= " Update TempItem_Stock set Qty=Qty + " & Val(rdr(2)) & " where Warehouse='" & rdr(0) & "' and DishID=" & Val(rdr(1)) & vbNewLine
                            cb2 &= " Update TempItem_Stock set Qty=Qty - " & Val(rdr(2)) & " where Warehouse='" & rdr(3) & "' and DishID=" & Val(rdr(1)) & vbNewLine
                        End If

                    Loop
                    rdr.Close()
                    con3.Close()

                    If cb2 <> "" Then
                        Dim con2 = New SqlConnection(cs)
                        con2.Open()
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con2
                        cmd.ExecuteNonQuery()
                        con2.Close()
                    End If
                Next
                '--
                cq = "delete from [StockTransfer_Join] where [StockTransferID] = @d1; "
                cq &= "delete from [StockTransferItem_Join] where [StockTransferID] = @d1; "
                cmd = New SqlCommand(cq)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
                cmd.ExecuteNonQuery()
                con.Close()
                'For Each row As DataGridViewRow In dgw.Rows
                '    If Not row.IsNewRow Then
                '        con = New SqlConnection(cs)
                '        con.Open()
                '        Dim cb2 As String = "Update Temp_Stock_RM set Qty = Qty - " & row.Cells(4).Value & " where ProductID=@d1"
                '        cmd = New SqlCommand(cb2)
                '        cmd.Connection = con
                '        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                '        cmd.ExecuteReader()
                '        con.Close()
                '    End If
                'Next
                If IsGoods Then
                    LogFunc(lblUser.Text, "Deleted the Finished Goods Entry having Transfer ID '" & txtID.Text & "'")
                Else
                    LogFunc(lblUser.Text, "Deleted the Stock Transfer having Transfer ID '" & txtID.Text & "'")
                End If

                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If Me.rdProduct.Checked Then
                    Getdata()
                ElseIf Me.rdItem.Checked Then
                    GetItemdata()
                Else
                    GetDishdata()
                End If
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub DeleteRecord_OLD()
        Try
            Dim RowsAffected As Integer = 0

            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from StockTransfer where ST_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                For Each row As DataGridViewRow In dgw.Rows
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select WareHouse,ProductID,ExpiryDate from temp_Stock where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty=Qty + " & Val(row.Cells(4).Value) & " where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        '----zz
                        cb2 = "Update Temp_Stock set Qty=Qty - " & Val(row.Cells(4).Value) & " where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Me.cmbKitchen.Text)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        '----
                        con.Close()
                    End If
                Next
                'For Each row As DataGridViewRow In dgw.Rows
                '    If Not row.IsNewRow Then
                '        con = New SqlConnection(cs)
                '        con.Open()
                '        Dim cb2 As String = "Update Temp_Stock_RM set Qty = Qty - " & row.Cells(4).Value & " where ProductID=@d1"
                '        cmd = New SqlCommand(cb2)
                '        cmd.Connection = con
                '        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                '        cmd.ExecuteReader()
                '        con.Close()
                '    End If
                'Next
                LogFunc(lblUser.Text, "Deleted the Stock Transfer having Transfer ID '" & txtID.Text & "'")
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If Me.rdProduct.Checked Then
                    Getdata()
                ElseIf Me.rdItem.Checked Then
                    GetItemdata()
                Else
                    GetDishdata()
                End If
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim AndWH As String = If(Me.cmbFromWH.Text = "", "", " And RTRIM(WareHouse) = '" & Me.cmbFromWH.Text.TrimEnd & "' ")
            cmd = New SqlCommand("SELECT RTRIM(WareHouse),RTRIM(ProductID),RTRIM(ProductName),RTRIM(Unit),RTRIM(ExpiryDate),Qty from Temp_Stock,Product where Temp_Stock.ProductID=Product.PID and Qty > 0 " & AndWH & "order by ProductName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
                End While
            End If

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetItemdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim AndWH As String = If(Me.cmbFromWH.Text = "", "", " And RTRIM(WareHouse) = '" & Me.cmbFromWH.Text.TrimEnd & "' ")
            cmd = New SqlCommand("SELECT RTRIM(WareHouse),RTRIM(TempItem_Stock.DishID),RTRIM(DishName),RTRIM(DIRate),RTRIM(ExpiryDate),Qty from TempItem_Stock,Dish where TempItem_Stock.DishID = Dish.DishID and Qty > 0 " & AndWH & "order by DishName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
                End While
            End If

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetDishdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            'cmd = New SqlCommand("SELECT 'NONE',RTRIM(R.R_ID),RTRIM(D.DishName),RTRIM(D.DIRate),'',50 from Recipe R left Join Dish D on R.Dish = D.DishName order by D.DishName", con)
            cmd = New SqlCommand("SELECT 'NONE',D.DishID,RTRIM(D.DishName),RTRIM(D.DIRate),'',50 from Recipe R left Join Dish D on R.Dish = D.DishName order by D.DishName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
                End While
            End If

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
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

    Private Sub frmStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsGoods Then
            Me.Label1.Text = "Finished Goods Entry"
            Me.GroupBox4.Text = "Finished Goods Info"
            Me.rdDish.Checked = True
            'Me.Panel4.Visible = False
            AddColsToDgvMat()
        Else
            Me.rdDish.Visible = False
            Me.rdItem.Checked = True
        End If
        'Getdata() 'zz
        FillStore()
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                txtWarehouse.Text = dr.Cells(0).Value.ToString()
                txtProductID.Text = dr.Cells(1).Value.ToString()
                txtProductName.Text = dr.Cells(2).Value.ToString()
                lblUnit.Visible = True
                lblUnit.Text = dr.Cells(3).Value.ToString()
                txtExpiryDate.Text = dr.Cells(4).Value.ToString()
                txtAvailableQty.Text = dr.Cells(5).Value.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub
    Sub Clear()
        txtWarehouse.Text = ""
        txtProductName.Text = ""
        txtProductID.Text = ""
        txtExpiryDate.Text = ""
        txtAvailableQty.Text = ""
        txtTransferQty.Text = ""
        btnRemove.Enabled = False
        lblUnit.Visible = False
    End Sub

    Private Sub btnRemoveFromGridOS_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            If dgw.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgw.SelectedRows
                    dgw.Rows.Remove(row)
                Next
                btnRemove.Enabled = False
                Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddOS_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtWarehouse.Text = "" Then
                MessageBox.Show("Please retrieve warehouse", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtWarehouse.Focus()
                Exit Sub
            End If
            If txtTransferQty.Text = "" Then
                MessageBox.Show("Please enter qty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTransferQty.Focus()
                Exit Sub
            End If
            If Val(txtTransferQty.Text) = 0 Then
                MessageBox.Show("Transferred quantity must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTransferQty.Focus()
                Exit Sub
            End If
            If Val(txtAvailableQty.Text) < Val(txtTransferQty.Text) Then
                MessageBox.Show("Transferred quantity must be less than available quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTransferQty.Focus()
                Exit Sub
            End If
            If txtExpiryDate.Text <> "" Then
                For Each row As DataGridViewRow In dgw.Rows
                    If txtWarehouse.Text = row.Cells(0).Value And txtProductID.Text = Val(row.Cells(1).Value) And txtExpiryDate.Text = row.Cells(3).Value Then
                        row.Cells(0).Value = txtWarehouse.Text
                        row.Cells(1).Value = Val(txtProductID.Text)
                        row.Cells(2).Value = txtProductName.Text
                        row.Cells(3).Value = txtExpiryDate.Text
                        row.Cells(4).Value += Val(txtTransferQty.Text)
                        Clear()
                        Exit Sub
                    End If
                Next
            End If
            If txtExpiryDate.Text = "" Then
                For Each row As DataGridViewRow In dgw.Rows
                    If txtWarehouse.Text = row.Cells(0).Value And txtProductID.Text = Val(row.Cells(1).Value) And txtExpiryDate.Text = "" Then
                        row.Cells(0).Value = txtWarehouse.Text
                        row.Cells(1).Value = Val(txtProductID.Text)
                        row.Cells(2).Value = txtProductName.Text
                        row.Cells(3).Value = txtExpiryDate.Text
                        row.Cells(4).Value += Val(txtTransferQty.Text)
                        Clear()
                        Exit Sub
                    End If
                Next
            End If
            dgw.Rows.Add(txtWarehouse.Text, Val(txtProductID.Text), txtProductName.Text, txtExpiryDate.Text, Val(txtTransferQty.Text))
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtSearchByProductName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByProductName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(WareHouse),RTRIM(ProductID),RTRIM(ProductName),RTRIM(Unit),RTRIM(ExpiryDate),Qty from Temp_Stock,Product where Temp_Stock.ProductID=Product.PID and Productname like '%" & txtSearchByProductName.Text & "%' and Qty > 0 order by ProductName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtTransferQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTransferQty.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtTransferQty.Text
            Dim selectionStart = Me.txtTransferQty.SelectionStart
            Dim selectionLength = Me.txtTransferQty.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        frmStockTransferRecord.Reset()
        Me.Tag = ""
        frmStockTransferRecord.CallfrmStockTransfer = Me
        frmStockTransferRecord.ShowDialog()
        If Me.Tag.ToString = "" Then Return
        '---
        con = New SqlConnection(cs)
        con.Open()
        Me.dgw.Rows.Clear()
        Dim sql As String = ""
        Dim HasFinishedGoods As Boolean = False
        sql = "Select RTRIM(Warehouse),Dish.DishID,RTRIM(DishName),RTRIM(ExpiryDate),Qty from Dish,StockTransfer,StockTransferItem_Join where Dish.DishID=StockTransferItem_Join.DishID and StockTransfer.ST_ID=StockTransferItem_Join.StockTransferID and ST_ID=" & Me.Tag & " and RTRIM(Warehouse) = 'NONE'" ' & " order by DishName"
        cmd = New SqlCommand(sql, con)
        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        While (rdr.Read() = True)
            Me.dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
            HasFinishedGoods = True
        End While
        rdr.Close()
        '----
        If Not HasFinishedGoods Then
            sql = "Select RTRIM(Warehouse),(PID),RTRIM(ProductName),RTRIM(ExpiryDate),Qty from Product,StockTransfer,StockTransfer_Join where Product.PID=StockTransfer_Join.ProductID and StockTransfer.ST_ID=StockTransfer_Join.StockTransferID and ST_ID=" & Me.Tag ' & " order by ProductName"
            sql &= " Union All Select RTRIM(Warehouse),Dish.DishID,RTRIM(DishName),RTRIM(ExpiryDate),Qty from Dish,StockTransfer,StockTransferItem_Join where Dish.DishID=StockTransferItem_Join.DishID and StockTransfer.ST_ID=StockTransferItem_Join.StockTransferID and ST_ID=" & Me.Tag
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While (rdr.Read() = True)
                Me.dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
            End While
            rdr.Close()
        End If

        '----

        con.Close()

    End Sub

    Private Sub dgw_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        If dgw.Rows.Count > 0 Then
            If lblSet.Text = "Not allowed" Then
                btnRemove.Enabled = False
            Else
                btnRemove.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptStockTransferInvoice 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT StockTransfer.ST_ID, StockTransfer.Date, StockTransfer.Kitchen, StockTransfer_Join.STJ_ID, StockTransfer_Join.StockTransferID, StockTransfer_Join.Warehouse, StockTransfer_Join.ProductID,StockTransfer_Join.ExpiryDate, StockTransfer_Join.Qty, Product.PID, Product.ProductCode, Product.ProductName, Product.Category, Product.Description, Product.Unit, Product.Price, Product.ReorderPoint FROM StockTransfer INNER JOIN StockTransfer_Join ON StockTransfer.ST_ID = StockTransfer_Join.StockTransferID INNER JOIN Product ON StockTransfer_Join.ProductID = Product.PID where ST_ID=" & Val(txtID.Text) & " order by StockTransfer.Date"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "StockTransfer")
            myDA.Fill(myDS, "StockTransfer_Join")
            myDA.Fill(myDS, "Product")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
    Private Sub rdProduct_CheckedChanged(sender As Object, e As EventArgs) Handles rdProduct.CheckedChanged
        If rdProduct.Checked Then
            Getdata()
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns("DataGridViewTextBoxColumn3").HeaderText = "Product Name"
            End If

        End If
    End Sub
    Private Sub rdItem_CheckedChanged(sender As Object, e As EventArgs) Handles rdItem.CheckedChanged
        If rdItem.Checked Then
            GetItemdata()
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns("DataGridViewTextBoxColumn3").HeaderText = "Item Name"
            End If

        End If
    End Sub
    Private Sub rdDish_CheckedChanged(sender As Object, e As EventArgs) Handles rdDish.CheckedChanged
        If rdDish.Checked Then
            GetDishdata()
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns("DataGridViewTextBoxColumn3").HeaderText = "Item Name"
            End If

        End If
    End Sub

    Private Sub cmbFromWH_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFromWH.SelectedIndexChanged
        If Me.rdProduct.Checked Then
            Getdata()
        ElseIf Me.rdItem.Checked Then
            GetItemdata()
        Else
            GetDishdata()
        End If

    End Sub
    Public Function GetWHType(w As String) As String
        Dim r As String = ""
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT WarehouseType from Warehouse where WarehouseName = '" & w & "'", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While (rdr.Read() = True)
                Return rdr(0).ToString.TrimEnd
                Exit While
            End While


            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return r
    End Function
    Public Function GetRecipeID(dishID As Integer) As Integer
        Dim r As Integer = 0
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT R_ID from Recipe R left join Dish D on RTrim(R.Dish) = RTrim(D.DishName) where D.DishID = " & dishID & "", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            While (rdr.Read() = True)
                Return rdr(0)
                Exit While
            End While


            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return r
    End Function



    'Private Sub cmbKitchen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKitchen.SelectedIndexChanged
    '    If Not (GetWHType(Me.cmbFromWH.Text) = "Production Warehouse" AndAlso GetWHType(Me.cmbKitchen.Text) = "Finished Goods Warehouse") Then
    '        Me.rdDish.Visible = False
    '        Me.rdProduct.Checked = True
    '    End If
    'End Sub
    Private Sub SaveByRecipe()
        Try
            Dim retrv As New Retrieving()
            If (rdDish.Checked) Then

                If Len(Trim(cmbKitchen.Text)) = 0 Then
                    MessageBox.Show("Please select a Finished Goods Warehouse", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbKitchen.Focus()
                    Exit Sub
                End If
                If dgw.Rows.Count = 0 Then
                    MessageBox.Show("sorry no product added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                '====START
                For Each row As DataGridViewRow In dgw.Rows
                    Dim RecipeID As Integer = GetRecipeID(row.Cells(1).Value)
                    Dim DishQty As Decimal = row.Cells(4).Value
                    'material
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct0 = "SELECT [ProductID],[Quantity],[CostPerUnit],[TotalItemCost] FROM [Recipe_Join] where [RecipeID] = " & RecipeID
                    cmd = New SqlCommand(ct0, con)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    While (rdr.Read() = True)
                        'dgw.Rows.Add(txtWarehouse.Text, Val(txtProductID.Text), txtProductName.Text, txtExpiryDate.Text, Val(txtTransferQty.Text))
                        dgvMaterial.Rows.Add(Me.cmbFromWH.Text, rdr(0), "ProductName", "", rdr(1) * DishQty)
                    End While
                    rdr.Close()
                    'con.Close()
                    ''==
                    'con = New SqlConnection(cs)
                    'con.Open()
                    Dim cb As String = "insert into StockTransfer(ST_ID, Date,Kitchen) VALUES (@d1,@d2,@d3)"
                    cmd = New SqlCommand(cb, con)
                    cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
                    cmd.Parameters.AddWithValue("@d2", dtpDate.Value.Date)
                    cmd.Parameters.AddWithValue("@d3", cmbKitchen.Text)
                    cmd.Connection = con
                    cmd.ExecuteNonQuery()
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    'from wh
                    Dim cb1 As String = "insert into StockTransfer_Join(StockTransferID,Warehouse,ProductID,ExpiryDate,Qty,ToWarehouse) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4,@d5)"
                    cmd = New SqlCommand(cb1, con)
                    cmd.Connection = con
                    ' Prepare command for repeated execution
                    cmd.Prepare()
                    ' Data to be inserted
                    For Each rowMat As DataGridViewRow In dgvMaterial.Rows
                        If Not rowMat.IsNewRow Then
                            'from wh- Production
                            cmd.Parameters.AddWithValue("@d1", rowMat.Cells(0).Value)

                            cmd.Parameters.AddWithValue("@d2", Val(rowMat.Cells(1).Value))
                            cmd.Parameters.AddWithValue("@d3", rowMat.Cells(3).Value)
                            cmd.Parameters.AddWithValue("@d4", Val(rowMat.Cells(4).Value))
                            'zz to wh NONE
                            cmd.Parameters.AddWithValue("@d5", "NONE")
                            cmd.ExecuteNonQuery()
                            cmd.Parameters.Clear()
                        End If
                    Next
                    'insert the dish 
                    Dim cb2 As String = "insert into StockTransferItem_Join(StockTransferID,Warehouse,DishID,ExpiryDate,Qty,ToWarehouse,ValidityDate) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4,@d5,GetDate())"
                    Dim cmdD = New SqlCommand(cb2, con)
                    'from wh Production
                    cmdD.Parameters.AddWithValue("@d1", Me.cmbFromWH.Text)
                    cmdD.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmdD.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    cmdD.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                    'zz to wh Goods
                    cmdD.Parameters.AddWithValue("@d5", Me.cmbKitchen.Text)
                    cmdD.ExecuteNonQuery()
                    cmdD.Parameters.Clear()
                    '-> NONE -> Production
                    cb2 = "insert into StockTransferItem_Join(StockTransferID,Warehouse,DishID,ExpiryDate,Qty,ToWarehouse,ValidityDate) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4,@d5,GetDate())"
                    cmdD = New SqlCommand(cb2, con)
                    'from wh NONE
                    cmdD.Parameters.AddWithValue("@d1", "NONE")
                    cmdD.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmdD.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    cmdD.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                    'zz to wh Production
                    cmdD.Parameters.AddWithValue("@d5", Me.cmbFromWH.Text)
                    cmdD.ExecuteNonQuery()
                    cmdD.Parameters.Clear()
                Next
                con.Close()
                '+/- Temp balance MATERIALS, only Production WH 
                For Each row As DataGridViewRow In dgvMaterial.Rows
                    con = New SqlConnection(cs)
                    con.Open()
                    'Minus from Production
                    Dim ct As String = "select WareHouse,ProductID,ExpiryDate from temp_Stock where Warehouse=@d1 and ProductID=@d2" ' and ExpiryDate=@d3"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Me.cmbFromWH.Text.TrimEnd)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value)) 'pro id
                    'cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        Dim con7 = New SqlConnection(cs)
                        con7.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty=Qty - " & Val(row.Cells(4).Value) & ",Date_done = getdate() where Warehouse=@d1 and ProductID=@d2" ' and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con7
                        'from wh
                        cmd.Parameters.AddWithValue("@d1", Me.cmbFromWH.Text.TrimEnd)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        'cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.ExecuteReader()

                        con7.Close()
                    End If
                    con.Close()
                Next
                '+/- Temp balance DISHES, only Goods WH
                For Each row As DataGridViewRow In dgw.Rows
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct = "select WareHouse,DishID,ExpiryDate from tempItem_Stock where Warehouse=@d1 and DishID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Me.cmbKitchen.Text)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update TempItem_Stock set Qty=Qty + " & Val(row.Cells(4).Value) & ",Date_done = getdate() where Warehouse=@d1 and DishID=@d2 and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        'to wh
                        cmd.Parameters.AddWithValue("@d1", Me.cmbKitchen.Text)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    Else
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb3 As String = "insert into TempItem_Stock(Warehouse,DishID,ExpiryDate,Qty,Date_done) VALUES (@d0,@d1,@dex,@d2,GetDate())"
                        cmd = New SqlCommand(cb3)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d0", Me.cmbKitchen.Text)
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@dex", row.Cells(3).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(4).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                Next
                LogFunc(lblUser.Text, "Added the new Finished Goods entry having Transfer ID '" & txtID.Text & "'")
                MessageBox.Show("Successfully saved", "Finished Goods entry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSave.Enabled = False
                con.Close()
                'zz
                'Me.DataGridView1.Rows.Clear()
                '--
                GetDishdata()
                btnPrint.Enabled = True
                Return
                '===END RECIPE=====================

                For Each row As DataGridViewRow In dgw.Rows
                    con = New SqlConnection(cs)
                    con.Open()
                    'frm wh
                    Dim ct As String = "select WareHouse,ProductID,ExpiryDate from temp_Stock where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value)) 'pro id
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty=Qty - " & Val(row.Cells(4).Value) & ",Date_done = getdate() where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        'from wh
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                    '---zz add
                    'to wh
                    con = New SqlConnection(cs)
                    con.Open()
                    ct = "select WareHouse,ProductID,ExpiryDate from temp_Stock where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Me.cmbKitchen.Text)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty=Qty + " & Val(row.Cells(4).Value) & ",Date_done = getdate() where Warehouse=@d1 and ProductID=@d2 and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        'to wh
                        cmd.Parameters.AddWithValue("@d1", Me.cmbKitchen.Text)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    Else
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb3 As String = "insert into Temp_Stock(Warehouse,ProductID,ExpiryDate,Qty,Date_done) VALUES (@d0,@d1,@dex,@d2,GetDate())"
                        cmd = New SqlCommand(cb3)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d0", Me.cmbKitchen.Text)
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@dex", row.Cells(3).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(4).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                Next

                'RM

                'For Each row As DataGridViewRow In dgw.Rows
                '    If Not row.IsNewRow Then
                '        con = New SqlConnection(cs)
                '        con.Open()
                '        Dim ctx As String = "select ProductID from Temp_Stock_RM where ProductID=@d1"
                '        cmd = New SqlCommand(ctx)
                '        cmd.Connection = con
                '        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                '        rdr = cmd.ExecuteReader()
                '        If (rdr.Read()) Then

                '            con = New SqlConnection(cs)
                '            con.Open()
                '            Dim cb2 As String = "Update Temp_Stock_RM set Qty = Qty + " & row.Cells(4).Value & ",Date_done = getdate() where ProductID=@d1"
                '            cmd = New SqlCommand(cb2)
                '            cmd.Connection = con
                '            cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                '            cmd.ExecuteReader()
                '            con.Close()

                '        Else
                '            con = New SqlConnection(cs)
                '            con.Open()
                '            Dim cb3 As String = "insert into Temp_Stock_RM(ProductID,Qty,Date_done) VALUES (@d1,@d2,GetDate())"
                '            cmd = New SqlCommand(cb3)
                '            cmd.Connection = con
                '            cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                '            cmd.Parameters.AddWithValue("@d2", Val(row.Cells(4).Value))
                '            cmd.ExecuteReader()
                '            con.Close()
                '        End If
                '    End If
                'Next

                LogFunc(lblUser.Text, "added the new Stock Transfer having Transfer ID '" & txtID.Text & "'")
                MessageBox.Show("Successfully saved", "Stock Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSave.Enabled = False
                con.Close()
                'zz
                Me.DataGridView1.Rows.Clear()
                '--
                Getdata()
                btnPrint.Enabled = True
            End If
            '==========================ITEM==============================
            If (rdItem.Checked) Then

                If Len(Trim(cmbKitchen.Text)) = 0 Then
                    MessageBox.Show("Please select kitchen/section", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbKitchen.Focus()
                    Exit Sub
                End If
                If dgw.Rows.Count = 0 Then
                    MessageBox.Show("sorry no product added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                For Each row As DataGridViewRow In dgw.Rows
                    Dim con As New SqlConnection(cs)
                    con.Open()
                    Dim cmd As New SqlCommand("SELECT qty from TempItem_Stock where Warehouse=@d1 and DishID=@d2 and ExpiryDate=@d3", con)
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    If ds.Tables(0).Rows.Count > 0 Then
                        lblQty.Text = ds.Tables(0).Rows(0)("Qty")
                        If Val(row.Cells(4).Value) > Val(lblQty.Text) Then
                            MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. of Product name '" & row.Cells(2).Value & "' from Warehouse '" & row.Cells(0).Value & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                    con.Close()
                Next
                For Each row As DataGridViewRow In dgw.Rows
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select WareHouse,DishID,ExpiryDate from tempItem_Stock where Warehouse=@d1 and DishID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update TempItem_Stock set Qty=Qty - " & Val(row.Cells(4).Value) & " where Warehouse=@d1 and DishID=@d2 and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                    'To wh zzzzz
                    con = New SqlConnection(cs)
                    con.Open()
                    ct = "select WareHouse,DishID,ExpiryDate from tempItem_Stock where Warehouse=@d1 and DishID=@d2 and ExpiryDate=@d3"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Me.cmbKitchen.Text)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update TempItem_Stock set Qty=Qty + " & Val(row.Cells(4).Value) & ",Date_done = getdate() where Warehouse=@d1 and DishID=@d2 and ExpiryDate=@d3"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        'to wh
                        cmd.Parameters.AddWithValue("@d1", Me.cmbKitchen.Text)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    Else
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb3 As String = "insert into TempItem_Stock(Warehouse,DishID,ExpiryDate,Qty,Date_done) VALUES (@d0,@d1,@dex,@d2,GetDate())"
                        cmd = New SqlCommand(cb3)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d0", Me.cmbKitchen.Text)
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@dex", row.Cells(3).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(4).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                Next
                con = New SqlConnection(cs)
                con.Open()
                'Dim cb As String = "insert into StockTransferItem(ST_ID, Date,Kitchen) VALUES (@d1,@d2,@d3)"
                Dim cb As String = "insert into StockTransfer(ST_ID, Date,Kitchen) VALUES (@d1,@d2,@d3)"
                cmd = New SqlCommand(cb)
                cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
                cmd.Parameters.AddWithValue("@d2", dtpDate.Value.Date)
                cmd.Parameters.AddWithValue("@d3", cmbKitchen.Text)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                'Dim cb1 As String = "insert into StockTransferItem_Join(StockTransferID,Warehouse,DishID,ExpiryDate,Qty,ValidityDate) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4,GetDate())"
                Dim cb1 As String = "insert into StockTransferItem_Join(StockTransferID,Warehouse,DishID,ExpiryDate,Qty,ToWarehouse,ValidityDate) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4,@d5,GetDate())"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In dgw.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value)
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                        'to wh
                        cmd.Parameters.AddWithValue("@d5", Me.cmbKitchen.Text)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                'zz comm
                'For Each row As DataGridViewRow In dgw.Rows
                '    If Not row.IsNewRow Then
                '        con = New SqlConnection(cs)
                '        con.Open()
                '        Dim ctx As String = "select ID from Temp_Stock_Store where ID=@d1"
                '        cmd = New SqlCommand(ctx)
                '        cmd.Connection = con
                '        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                '        rdr = cmd.ExecuteReader()
                '        If (rdr.Read()) Then

                '            con = New SqlConnection(cs)
                '            con.Open()
                '            Dim cb2 As String = "Update Temp_Stock_Store set Qty = Qty + " & row.Cells(4).Value & " where ID=@d1"
                '            cmd = New SqlCommand(cb2)
                '            cmd.Connection = con
                '            cmd.Parameters.AddWithValue("@d1", Val(row.Cells(1).Value))
                '            cmd.ExecuteReader()
                '            con.Close()
                '            retrv.AddStock((CType(row.Cells(4).Value, Decimal)), row.Cells(2).Value.ToString())  'Added by Jaemsoft Tech 12/02/2020 3:15AM
                '        Else
                '            con = New SqlConnection(cs)
                '            con.Open()
                '            Dim cb3 As String = "insert into Temp_Stock_Store(Dish,Qty) VALUES (@d1,@d2)"
                '            cmd = New SqlCommand(cb3)
                '            cmd.Connection = con
                '            cmd.Parameters.AddWithValue("@d1", row.Cells(2).Value)
                '            cmd.Parameters.AddWithValue("@d2", Val(row.Cells(4).Value))
                '            cmd.ExecuteReader()
                '            con.Close()
                '            retrv.insertStock((CType(row.Cells(4).Value, Decimal)), row.Cells(2).Value.ToString())  'Added by Jaemsoft Tech 12/02/2020 3:15AM
                '        End If
                '    End If
                'Next

                LogFunc(lblUser.Text, "added the new Stock Transfer having Transfer ID '" & txtID.Text & "'")
                MessageBox.Show("Successfully saved", "Stock Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSave.Enabled = False
                con.Close()
                If Not IsGoods Then rdProduct.Checked = True
                btnPrint.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub AddColsToDgvMat()
        Dim MeXColumn1 As New DataGridViewTextBoxColumn
        MeXColumn1.HeaderText = "Warehouse"
        MeXColumn1.MinimumWidth = 6
        MeXColumn1.Name = "Column1"
        MeXColumn1.ReadOnly = True
        MeXColumn1.Width = 125
        '
        Dim MeXColumn2 As New DataGridViewTextBoxColumn
        '
        MeXColumn2.HeaderText = "Product ID"
        MeXColumn2.MinimumWidth = 6
        MeXColumn2.Name = "Column2"
        MeXColumn2.ReadOnly = True
        MeXColumn2.Visible = False
        MeXColumn2.Width = 125
        '
        Dim MeXColumn3 As New DataGridViewTextBoxColumn
        '
        MeXColumn3.HeaderText = "Product Name"
        MeXColumn3.MinimumWidth = 6
        MeXColumn3.Name = "Column3"
        MeXColumn3.ReadOnly = True
        MeXColumn3.Width = 117
        '
        Dim MeXColumn6 As New DataGridViewTextBoxColumn
        '
        MeXColumn6.HeaderText = "Expiry Date"
        MeXColumn6.MinimumWidth = 6
        MeXColumn6.Name = "Column6"
        MeXColumn6.ReadOnly = True
        MeXColumn6.Width = 125
        '
        Dim MeXColumn5 As New DataGridViewTextBoxColumn
        '
        MeXColumn5.HeaderText = "Transfer Qty."
        MeXColumn5.MinimumWidth = 6
        MeXColumn5.Name = "Column5"
        MeXColumn5.ReadOnly = True
        MeXColumn5.Width = 125

        Me.dgvMaterial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {MeXColumn1, MeXColumn2, MeXColumn3, MeXColumn6, MeXColumn5})
    End Sub
End Class
