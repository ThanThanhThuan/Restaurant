Imports System.Data.SqlClient
Public Class frmRecipe
    Sub FillItems()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(DishName) FROM Dish", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbItemName.Items.Clear()
            cmbDish.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbItemName.Items.Add(drow(0).ToString())
                cmbDish.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        cmbItemName.Text = ""
        txtCategory.Text = ""
        txtRecipeName.Text = ""
        txtDescription.Text = ""
        txtTotalCost.Text = "0.00"
        lblUnit.Text = "Unit"
        dgw.Rows.Clear()
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnPrint.Enabled = False
        btnRemove.Enabled = False
        btnAdd.Enabled = True
        Clear()
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
            cmd = New SqlCommand("SELECT TOP 1 R_ID FROM Recipe ORDER BY R_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("R_ID")
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
        Dim cb1 As String = ""
        Try
            If Len(Trim(txtRecipeName.Text)) = 0 Then
                MessageBox.Show("Please enter recipe name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRecipeName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbItemName.Text)) = 0 Then
                MessageBox.Show("Please select item name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbItemName.Focus()
                Exit Sub
            End If
            If txtTotalCost.Text = "" Then
                MessageBox.Show("Please enter fixed cost", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalCost.Focus()
                Exit Sub
            End If
            If dgw.Rows.Count = 0 Then
                MessageBox.Show("sorry no product added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select RecipeName from Recipe where RecipeName=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtRecipeName.Text)
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Recipe Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRecipeName.Text = ""
                txtRecipeName.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select Dish from Recipe where Dish=@d1"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbItemName.Text)
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Recipe Already Exists for selected item", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Recipe(R_ID,RecipeName,Dish,FixedCost,Description) VALUES (@d1,@d2,@d3,@d4,@d5)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtRecipeName.Text)
            cmd.Parameters.AddWithValue("@d3", cmbItemName.Text)
            cmd.Parameters.AddWithValue("@d4", Val(txtTotalCost.Text))
            cmd.Parameters.AddWithValue("@d5", txtDescription.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            cb1 = "insert into Recipe_Join(RecipeID,ProductID,Quantity,CostPerUnit,TotalItemCost) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In dgw.Rows
                If Not row.IsNewRow AndAlso CBool(row.Cells(5).Value) = False Then
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            '----
            cb1 = "insert into RecipeDish_Join(RecipeID,DishID,Quantity,CostPerUnit,TotalItemCost) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In dgw.Rows
                If Not row.IsNewRow AndAlso CBool(row.Cells(5).Value) = True Then
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            '----
            LogFunc(lblUser.Text, "Added the new Receipe '" & txtRecipeName.Text & "' having Recipe ID '" & txtID.Text & "'")
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            con.Close()
            btnPrint.Enabled = True
        Catch ex As Exception
            Debug.WriteLine(cb1 & vbNewLine & ex.Message)
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
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Recipe where R_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                LogFunc(lblUser.Text, "Deleted the Receipe '" & txtRecipeName.Text & "' having Recipe ID '" & txtID.Text & "'")
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        FillItems()
        fillProduct()
        con = New SqlConnection(cs)
        con.Open()
        Dim cq As String = "IF OBJECT_ID(N'dbo.RecipeDish_Join', N'U') IS NULL
BEGIN
CREATE TABLE [dbo].[RecipeDish_Join](
	[RJD_ID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NOT NULL,
	[DishID] [int] NOT NULL,
	[Quantity] [decimal](18, 2) NULL,
	[CostPerUnit] [decimal](18, 2) NULL,
	[TotalItemCost] [decimal](18, 2) NULL,
 CONSTRAINT [PK_RecipeDish_Join] PRIMARY KEY CLUSTERED 
(
	[RJD_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END"
        cmd = New SqlCommand(cq)
        cmd.Connection = con
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    Sub Clear()
        cmbProductName.Text = ""
        cmbDish.Text = ""
        txtTotalItemCost.Text = "0.00"
        txtCostPerUnit.Text = "0.00"
        lblUnit.Text = "Unit"
        btnGridUpdate.Enabled = False
        btnRemove.Enabled = False
        btnAdd.Enabled = True
        txtQty.Text = 1
    End Sub
    Public Function TotalCost() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.dgw.Rows
                sum = sum + r.Cells(4).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Private Sub btnRemoveFromGridOS_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            If dgw.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgw.SelectedRows
                    dgw.Rows.Remove(row)
                Next
                Dim k As Double = 0
                k = TotalCost()
                k = Math.Round(k, 2)
                txtTotalCost.Text = k
                btnRemove.Enabled = False
                Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddOS_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click, btnAddDish.Click
        Try
            If DirectCast(sender, Button) Is btnAdd Then
                If cmbProductName.Text = "" Then
                    MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbProductName.Focus()
                    Exit Sub
                End If
            Else
                If Me.cmbDish.Text = "" Then
                    MessageBox.Show("Please select an item", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.cmbDish.Focus()
                    Exit Sub
                End If
            End If

            If txtQty.Text = "" Then
                MessageBox.Show("Please enter qty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If Val(txtQty.Text) = 0 Then
                MessageBox.Show("Quantity must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtTotalItemCost.Text = "" Then
                MessageBox.Show("Please enter cost", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalItemCost.Focus()
                Exit Sub
            End If
            If dgw.Rows.Count = 0 Then
                If DirectCast(sender, Button) Is btnAdd Then
                    dgw.Rows.Add(Val(txtProductID.Text), cmbProductName.Text, Val(txtQty.Text) & " " & lblUnit.Text, Val(txtCostPerUnit.Text), Val(txtTotalItemCost.Text), 0)
                Else
                    dgw.Rows.Add(Val(txtProductID.Text), cmbDish.Text, Val(txtQty.Text) & " " & lblUnit.Text, Val(txtCostPerUnit.Text), Val(txtTotalItemCost.Text), 1)
                End If

                Dim k2 As Double = 0
                k2 = TotalCost()
                k2 = Math.Round(k2, 2)
                txtTotalCost.Text = k2
                Clear()
                Exit Sub
            End If
            For Each row As DataGridViewRow In dgw.Rows
                'zz tmp comm
                'If txtProductID.Text = Val(row.Cells(0).Value) OrElse cmbProductName.Text = row.Cells(1).Value Then
                '    MessageBox.Show("Already added to grid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Clear()
                '    Exit Sub
                'End If
                If DirectCast(sender, Button) Is btnAdd Then
                    '5= IsDish
                    If CBool(row.Cells(5).Value) = False AndAlso txtProductID.Text = Val(row.Cells(0).Value) Then
                        MessageBox.Show("Already added to grid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Clear()
                        Exit Sub
                    End If
                Else
                    If CBool(row.Cells(5).Value) = True AndAlso txtProductID.Text = Val(row.Cells(0).Value) Then
                        MessageBox.Show("Already added to grid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Clear()
                        Exit Sub
                    End If
                End If
            Next
            dgw.Rows.Add(Val(txtProductID.Text), If(DirectCast(sender, Button) Is btnAdd, cmbProductName.Text, cmbDish.Text), Val(txtQty.Text) & " " & lblUnit.Text, Val(txtCostPerUnit.Text), Val(txtTotalItemCost.Text), If(DirectCast(sender, Button) Is btnAdd, 0, 1))
            Dim k As Double = 0
            k = TotalCost()
            k = Math.Round(k, 2)
            txtTotalCost.Text = k
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtTransferQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtQty.Text
            Dim selectionStart = Me.txtQty.SelectionStart
            Dim selectionLength = Me.txtQty.SelectionLength

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
        frmRecipeRecord.Reset()
        frmRecipeRecord.ShowDialog()
    End Sub

    Private Sub dgw_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        If dgw.Rows.Count > 0 Then
            btnRemove.Enabled = True
            btnAdd.Enabled = False
            btnGridUpdate.Enabled = True
            Dim dr As DataGridViewRow = dgw.SelectedRows(0)
            txtProductID.Text = dr.Cells(0).Value.ToString()
            cmbProductName.Text = dr.Cells(1).Value.ToString()
            Dim strX As String
            Dim strArr() As String
            strX = dr.Cells.Item(2).Value.ToString()
            strArr = strX.Split(" ")
            txtQty.Text = strArr(0)
            lblUnit.Text = strArr(1)
            txtTotalItemCost.Text = dr.Cells(4).Value.ToString()
            txtCostPerUnit.Text = dr.Cells(3).Value.ToString()
        End If
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptRecipe 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Unit,Recipe.R_ID, Recipe.RecipeName, Recipe.Dish, Recipe.FixedCost, Recipe.Description, Recipe_Join.RJ_ID, Recipe_Join.RecipeID, Recipe_Join.ProductID, Recipe_Join.Quantity, Recipe_Join.CostPerUnit,TotalItemCost,Dish.DishName, Dish.Category, Product.PID, Product.ProductCode, Product.ProductName, Product.Category AS Expr1, Product.Description AS Expr2,Product.Unit AS Expr3, Product.Price, Product.ReorderPoint FROM Recipe INNER JOIN Recipe_Join ON Recipe.R_ID = Recipe_Join.RecipeID INNER JOIN Dish ON Recipe.Dish = Dish.DishName INNER JOIN Product ON Recipe_Join.ProductID = Product.PID where R_ID=" & Val(txtID.Text) & ""
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Recipe")
            myDA.Fill(myDS, "Recipe_Join")
            myDA.Fill(myDS, "Dish")
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

    Private Sub cmbItemName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbItemName.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Category from Dish where DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbItemName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtCategory.Text = rdr.GetValue(0)
                txtRecipeName.Text = ""
                txtRecipeName.Text = cmbItemName.Text & " " & "Recipe"
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

    Private Sub cmbProductName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbProductName.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(Unit),PID,Price from Product where ProductName=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbProductName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                lblUnit.Text = rdr.GetValue(0).ToString()
                txtProductID.Text = rdr.GetValue(1)
                txtQty.Text = 1
                txtCostPerUnit.Text = rdr.GetValue(2)
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
    Sub fillProduct()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT ProductName FROM Product order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbProductName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbProductName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbProductName_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbProductName.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub cmbUnit_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub


    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Try
            If Len(Trim(txtRecipeName.Text)) = 0 Then
                MessageBox.Show("Please enter recipe name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRecipeName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbItemName.Text)) = 0 Then
                MessageBox.Show("Please select item name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbItemName.Focus()
                Exit Sub
            End If
            If txtTotalCost.Text = "" Then
                MessageBox.Show("Please enter fixed cost", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalCost.Focus()
                Exit Sub
            End If
            If dgw.Rows.Count = 0 Then
                MessageBox.Show("sorry no product added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update Recipe set RecipeName=@d2,Dish=@d3,FixedCost=@d4,Description=@d5 where R_ID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtRecipeName.Text)
            cmd.Parameters.AddWithValue("@d3", cmbItemName.Text)
            cmd.Parameters.AddWithValue("@d4", Val(txtTotalCost.Text))
            cmd.Parameters.AddWithValue("@d5", txtDescription.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Recipe_Join where RecipeID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Recipe_Join(RecipeID,ProductID,Quantity,CostPerUnit,TotalItemCost,IsDish) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d4,@d5)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In dgw.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value)) 'isdish
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            LogFunc(lblUser.Text, "Updated the Receipe '" & txtRecipeName.Text & "' having Recipe ID '" & txtID.Text & "'")
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub


    Private Sub btnGridUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnGridUpdate.Click
        Try
            If cmbProductName.Text = "" AndAlso cmbDish.Text = "" Then
                MessageBox.Show("Please select a material or an item", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbProductName.Focus()
                Exit Sub
            ElseIf cmbProductName.Text <> "" AndAlso cmbDish.Text <> "" Then
                MessageBox.Show("Please don't select both material and item", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbProductName.Focus()
                Exit Sub
            End If

            'If cmbProductName.Text = "" Then
            '    MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    cmbProductName.Focus()
            '    Exit Sub
            'End If
            If txtQty.Text = "" Then
                MessageBox.Show("Please enter qty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If Val(txtQty.Text) = 0 Then
                MessageBox.Show("Quantity must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtTotalItemCost.Text = "" Then
                MessageBox.Show("Please enter cost", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalItemCost.Focus()
                Exit Sub
            End If
            If dgw.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgw.SelectedRows
                    dgw.Rows.Remove(row)
                Next
            End If
            dgw.Rows.Add(Val(txtProductID.Text), cmbProductName.Text, Val(txtQty.Text) & " " & lblUnit.Text, Val(txtCostPerUnit.Text), Val(txtTotalItemCost.Text), If(cmbProductName.Text <> "", 0, 1))
            Dim k As Double = 0
            k = TotalCost()
            k = Math.Round(k, 2)
            txtTotalCost.Text = k
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Compute()
        Dim num1 As Double
        num1 = Val(txtCostPerUnit.Text) * Val(txtQty.Text)
        num1 = Math.Round(num1, 2)
        txtTotalItemCost.Text = num1
    End Sub
    Private Sub txtQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQty.TextChanged
        Compute()
    End Sub

    Private Sub txtCostPerUnit_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostPerUnit.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtCostPerUnit.Text
            Dim selectionStart = Me.txtCostPerUnit.SelectionStart
            Dim selectionLength = Me.txtCostPerUnit.SelectionLength

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

    Private Sub txtCostPerUnit_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCostPerUnit.TextChanged
        Compute()
    End Sub

    Private Sub cmbDish_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDish.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT 'Unit',DishID,PurcPrice from Dish where DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbDish.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                lblUnit.Text = rdr.GetValue(0).ToString()
                txtProductID.Text = rdr.GetValue(1)
                txtQty.Text = 1
                txtCostPerUnit.Text = NNStr(rdr.GetValue(2))
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
    Public Function NNStr(o As Object) As String
        Try
            Return CStr(o)
        Catch ex As Exception

        End Try
        Return ""
    End Function
End Class
