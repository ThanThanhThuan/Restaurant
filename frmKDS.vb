Imports System.Data.SqlClient
Public Class frmKDS
    Friend WithEvents dgwDI As System.Windows.Forms.DataGridView
    Friend WithEvents dgwTA As System.Windows.Forms.DataGridView
    Friend WithEvents dgwHD As System.Windows.Forms.DataGridView
    Friend WithEvents dgwEB As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn

    Sub GetDataDineIn()
        Try
            If DBConnectionStatus() = False Then
                MessageBox.Show("Failed to connect with Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End If
            flpDineIn.Controls.Clear()
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT DISTINCT RTRIM(TicketNo) from RestaurantPOS_OrderInfoKOT where KOT_Status='Open' order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbDineInKOT.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbDineInKOT.Items.Add(drow(0).ToString())
            Next
            CN.Close()
            For Each item As String In cmbDineInKOT.Items
                con = New SqlConnection(cs)
                con.Open()
                Dim cmdText1 As String = "SELECT Distinct RTRIM(Dish),Quantity,RTRIM(TableNo),RTRIM(Notes),BillDate from RestaurantPOS_OrderedProductKOT,RestaurantPOS_OrderInfoKOT where RestaurantPOS_OrderInfoKOT.ID=RestaurantPOS_OrderedProductKOT.TicketID and TicketNo=@d1 and KOT_Status='Open' order by 1"
                cmd = New SqlCommand(cmdText1)
                cmd.Parameters.AddWithValue("@d1", item)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                Dim flp As New FlowLayoutPanel
                flp.Size = New System.Drawing.Size(282, 342)
                flp.FlowDirection = FlowDirection.TopDown
                flp.BorderStyle = BorderStyle.FixedSingle
                Dim lblBillNo As New Label
                Dim lblRunningTime As New Label
                lblBillNo.AutoSize = True
                lblRunningTime.AutoSize = True
                Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
                Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
                Me.dgwDI = New System.Windows.Forms.DataGridView()
                dgwDI.EnableHeadersVisualStyles = False
                DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
                DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
                dgwDI.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                Me.dgwDI.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
                Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
                Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
                dgwDI.GridColor = System.Drawing.Color.White
                dgwDI.AllowUserToAddRows = False
                dgwDI.AllowUserToDeleteRows = False
                dgwDI.AllowUserToOrderColumns = False
                dgwDI.AllowUserToResizeColumns = False
                dgwDI.MultiSelect = False
                Me.dgwDI.BackgroundColor = System.Drawing.Color.White
                Column1.HeaderText = "Item Name"
                Column1.Name = "Column1"
                Me.Column1.ReadOnly = True
                Me.Column1.Width = 190
                DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                Me.Column2.DefaultCellStyle = DataGridViewCellStyle1
                Me.Column2.HeaderText = "Quantity"
                Me.Column2.Name = "Column2"
                Me.Column2.ReadOnly = True
                Me.Column2.Width = 80
                dgwDI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgwDI.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
                dgwDI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
                dgwDI.RowHeadersVisible = False
                dgwDI.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                dgwDI.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                dgwDI.Size = New System.Drawing.Size(273, 250)

                Dim Button1 As New Button
                'Button1.Location = New System.Drawing.Point(40, 269) 
                Button1.Size = New System.Drawing.Size(100, 50)
                Button1.Text = "BUMP" & " " & item
                Button1.UseVisualStyleBackColor = True
                Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
                Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
                Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Button1.ForeColor = System.Drawing.Color.White
                Do While (rdr.Read())
                    Dim s1 As String
                    If rdr.GetValue(3).ToString() = "" Then
                        s1 = rdr.GetValue(0).ToString()
                    Else
                        s1 = rdr(0) & vbCrLf & rdr.GetValue(3).ToString()
                    End If
                    dgwDI.Rows.Add(s1, rdr(1))
                    lblBillNo.Text = "KOT No.:" & " " & item & "           " & "Table No.:" & " " & rdr.GetValue(2).ToString()
                    flp.Controls.Add(lblBillNo)
                    Dim StartDate As DateTime = System.DateTime.Now
                    Dim EndDate As DateTime = rdr.GetValue(4)
                    ' Find time difference between two dates
                    Dim interval As TimeSpan = StartDate - EndDate
                    lblRunningTime.Text = "Running since " & (interval.Days * 24 * 60 + interval.Hours * 60 + interval.Minutes).ToString() & " Minutes."
                    flp.Controls.Add(lblRunningTime)
                    flp.Controls.Add(dgwDI)
                    flp.Controls.Add(Button1)
                    flpDineIn.Controls.Add(flp)
                    dgwDI.ClearSelection()
                Loop
                con.Close()
                AddHandler Button1.Click, AddressOf Me.ButtonDineIn_Click
            Next

        Catch ex As Exception
            End
        End Try
    End Sub
    Sub GetDataTakeAway()
        Try
            If DBConnectionStatus() = False Then
                MessageBox.Show("Failed to connect with Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End If
            flpTA.Controls.Clear()
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT DISTINCT RTRIM(BillNo) from RestaurantPOS_BillingInfoTA where TA_Status='Paid' order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbTAKOT.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbTAKOT.Items.Add(drow(0).ToString())
            Next
            CN.Close()
            For Each item As String In cmbTAKOT.Items
                con = New SqlConnection(cs)
                con.Open()
                Dim cmdText1 As String = "SELECT Distinct RTRIM(Dish),Quantity,RTRIM(Notes),BillDate,RTRIM(ODN) from RestaurantPOS_BillingInfoTA,RestaurantPOS_OrderedProductBillTA where RestaurantPOS_BillingInfoTA.ID=RestaurantPOS_OrderedProductBillTA.BillID and BillNo=@d1 and TA_Status='Paid' order by 1"
                cmd = New SqlCommand(cmdText1)
                cmd.Parameters.AddWithValue("@d1", item)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                Dim flp As New FlowLayoutPanel
                flp.Size = New System.Drawing.Size(282, 342)
                flp.FlowDirection = FlowDirection.TopDown
                flp.BorderStyle = BorderStyle.FixedSingle
                Dim lblBillNo As New Label
                Dim lblRunningTime As New Label
                lblBillNo.AutoSize = True
                lblRunningTime.AutoSize = True
                Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
                Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
                Me.dgwTA = New System.Windows.Forms.DataGridView()
                dgwTA.EnableHeadersVisualStyles = False
                DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
                DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
                dgwTA.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                Me.dgwTA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
                Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
                Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
                dgwTA.GridColor = System.Drawing.Color.White
                dgwTA.AllowUserToAddRows = False
                dgwTA.AllowUserToDeleteRows = False
                dgwTA.AllowUserToOrderColumns = False
                dgwTA.AllowUserToResizeColumns = False
                dgwTA.MultiSelect = False
                Me.dgwTA.BackgroundColor = System.Drawing.Color.White
                Column1.HeaderText = "Item Name"
                Column1.Name = "Column1"
                Me.Column1.ReadOnly = True
                Me.Column1.Width = 190
                DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                Me.Column2.DefaultCellStyle = DataGridViewCellStyle1
                Me.Column2.HeaderText = "Quantity"
                Me.Column2.Name = "Column2"
                Me.Column2.ReadOnly = True
                Me.Column2.Width = 80
                dgwTA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgwTA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
                dgwTA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
                dgwTA.RowHeadersVisible = False
                dgwTA.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                dgwTA.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                dgwTA.Size = New System.Drawing.Size(273, 250)

                Dim Button1 As New Button
                'Button1.Location = New System.Drawing.Point(40, 269) 
                Button1.Size = New System.Drawing.Size(100, 50)
                Button1.Text = "BUMP" & " " & item
                Button1.UseVisualStyleBackColor = True
                Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
                Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
                Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Button1.ForeColor = System.Drawing.Color.White
                Do While (rdr.Read())
                    Dim s1 As String
                    If rdr.GetValue(2).ToString() = "" Then
                        s1 = rdr.GetValue(0).ToString()
                    Else
                        s1 = rdr(0) & vbCrLf & rdr.GetValue(2).ToString()
                    End If
                    dgwTA.Rows.Add(s1, rdr(1))
                    lblBillNo.Text = "Bill No.:" & " " & item & "           " & "Order No.:" & " " & rdr.GetValue(4).ToString()
                    flp.Controls.Add(lblBillNo)
                    Dim StartDate As DateTime = System.DateTime.Now
                    Dim EndDate As DateTime = rdr.GetValue(3)
                    ' Find time difference between two dates
                    Dim interval As TimeSpan = StartDate - EndDate
                    lblRunningTime.Text = "Running since " & (interval.Days * 24 * 60 + interval.Hours * 60 + interval.Minutes).ToString() & " Minutes."
                    flp.Controls.Add(lblRunningTime)
                    flp.Controls.Add(dgwTA)
                    flp.Controls.Add(Button1)
                    flpTA.Controls.Add(flp)
                    dgwTA.ClearSelection()
                Loop
                con.Close()
                AddHandler Button1.Click, AddressOf Me.ButtonTA_Click
            Next

        Catch ex As Exception
            End
        End Try
    End Sub
    Sub GetDataHomeDelivery()
        Try
            If DBConnectionStatus() = False Then
                MessageBox.Show("Failed to connect with Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End If
            flpHD.Controls.Clear()
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT DISTINCT RTRIM(BillNo) from RestaurantPOS_BillingInfoHD where HD_Status='Confirmed' order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbHDKOT.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbHDKOT.Items.Add(drow(0).ToString())
            Next
            CN.Close()
            For Each item As String In cmbHDKOT.Items
                con = New SqlConnection(cs)
                con.Open()
                Dim cmdText1 As String = "SELECT Distinct RTRIM(Dish),Quantity,RTRIM(Notes),BillDate,RTRIM(ODN) from RestaurantPOS_BillingInfoHD,RestaurantPOS_OrderedProductBillHD where RestaurantPOS_BillingInfoHD.ID=RestaurantPOS_OrderedProductBillHD.BillID and BillNo=@d1 and HD_Status='Confirmed' order by 1"
                cmd = New SqlCommand(cmdText1)
                cmd.Parameters.AddWithValue("@d1", item)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                Dim flp As New FlowLayoutPanel
                flp.Size = New System.Drawing.Size(282, 342)
                flp.FlowDirection = FlowDirection.TopDown
                flp.BorderStyle = BorderStyle.FixedSingle
                Dim lblBillNo As New Label
                Dim lblRunningTime As New Label
                lblBillNo.AutoSize = True
                lblRunningTime.AutoSize = True
                Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
                Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
                Me.dgwHD = New System.Windows.Forms.DataGridView()
                dgwHD.EnableHeadersVisualStyles = False
                DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
                DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
                dgwHD.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                Me.dgwHD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
                Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
                Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
                dgwHD.GridColor = System.Drawing.Color.White
                dgwHD.AllowUserToAddRows = False
                dgwHD.AllowUserToDeleteRows = False
                dgwHD.AllowUserToOrderColumns = False
                dgwHD.AllowUserToResizeColumns = False
                dgwHD.MultiSelect = False
                Me.dgwHD.BackgroundColor = System.Drawing.Color.White
                Column1.HeaderText = "Item Name"
                Column1.Name = "Column1"
                Me.Column1.ReadOnly = True
                Me.Column1.Width = 190
                DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                Me.Column2.DefaultCellStyle = DataGridViewCellStyle1
                Me.Column2.HeaderText = "Quantity"
                Me.Column2.Name = "Column2"
                Me.Column2.ReadOnly = True
                Me.Column2.Width = 80
                dgwHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgwHD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
                dgwHD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
                dgwHD.RowHeadersVisible = False
                dgwHD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                dgwHD.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                dgwHD.Size = New System.Drawing.Size(273, 250)

                Dim Button1 As New Button
                'Button1.Location = New System.Drawing.Point(40, 269) 
                Button1.Size = New System.Drawing.Size(100, 50)
                Button1.Text = "BUMP" & " " & item
                Button1.UseVisualStyleBackColor = True
                Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
                Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
                Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Button1.ForeColor = System.Drawing.Color.White
                Do While (rdr.Read())
                    Dim s1 As String
                    If rdr.GetValue(2).ToString() = "" Then
                        s1 = rdr.GetValue(0).ToString()
                    Else
                        s1 = rdr(0) & vbCrLf & rdr.GetValue(2).ToString()
                    End If
                    dgwHD.Rows.Add(s1, rdr(1))
                    lblBillNo.Text = "Bill No.:" & " " & item & "           " & "Order No.:" & " " & rdr.GetValue(4).ToString()
                    flp.Controls.Add(lblBillNo)
                    Dim StartDate As DateTime = System.DateTime.Now
                    Dim EndDate As DateTime = rdr.GetValue(3)
                    ' Find time difference between two dates
                    Dim interval As TimeSpan = StartDate - EndDate
                    lblRunningTime.Text = "Running since " & (interval.Days * 24 * 60 + interval.Hours * 60 + interval.Minutes).ToString() & " Minutes."
                    flp.Controls.Add(lblRunningTime)
                    flp.Controls.Add(dgwHD)
                    flp.Controls.Add(Button1)
                    flpHD.Controls.Add(flp)
                    dgwHD.ClearSelection()
                Loop
                con.Close()
                AddHandler Button1.Click, AddressOf Me.ButtonHD_Click
            Next

        Catch ex As Exception
            End
        End Try
    End Sub
    Sub GetDataExpressBilling()
        Try
            If DBConnectionStatus() = False Then
                MessageBox.Show("Failed to connect with Database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End If
            flpEB.Controls.Clear()
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT DISTINCT RTRIM(BillNo) from RestaurantPOS_BillingInfoEB where EB_Status in ('Unpaid','Paid','Partially Paid') order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbEBKOT.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbEBKOT.Items.Add(drow(0).ToString())
            Next
            CN.Close()
            For Each item As String In cmbEBKOT.Items
                con = New SqlConnection(cs)
                con.Open()
                Dim cmdText1 As String = "SELECT Distinct RTRIM(Dish),Quantity,RTRIM(Notes),BillDate,RTRIM(ODN) from RestaurantPOS_BillingInfoEB,RestaurantPOS_OrderedProductBillEB where RestaurantPOS_BillingInfoEB.ID=RestaurantPOS_OrderedProductBillEB.BillID and BillNo=@d1 and EB_Status in ('Unpaid','Paid','Partially Paid') order by 1"
                cmd = New SqlCommand(cmdText1)
                cmd.Parameters.AddWithValue("@d1", item)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                Dim flp As New FlowLayoutPanel
                flp.Size = New System.Drawing.Size(282, 342)
                flp.FlowDirection = FlowDirection.TopDown
                flp.BorderStyle = BorderStyle.FixedSingle
                Dim lblBillNo As New Label
                Dim lblRunningTime As New Label
                lblBillNo.AutoSize = True
                lblRunningTime.AutoSize = True
                Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
                Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
                Me.dgwEB = New System.Windows.Forms.DataGridView()
                dgwEB.EnableHeadersVisualStyles = False
                DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
                DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
                dgwEB.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                Me.dgwEB.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
                Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
                Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
                dgwEB.GridColor = System.Drawing.Color.White
                dgwEB.AllowUserToAddRows = False
                dgwEB.AllowUserToDeleteRows = False
                dgwEB.AllowUserToOrderColumns = False
                dgwEB.AllowUserToResizeColumns = False
                dgwEB.MultiSelect = False
                Me.dgwEB.BackgroundColor = System.Drawing.Color.White
                Column1.HeaderText = "Item Name"
                Column1.Name = "Column1"
                Me.Column1.ReadOnly = True
                Me.Column1.Width = 190
                DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

                Me.Column2.DefaultCellStyle = DataGridViewCellStyle1
                Me.Column2.HeaderText = "Quantity"
                Me.Column2.Name = "Column2"
                Me.Column2.ReadOnly = True
                Me.Column2.Width = 80
                dgwEB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgwEB.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
                dgwEB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
                dgwEB.RowHeadersVisible = False
                dgwEB.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                dgwEB.Columns(0).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                dgwEB.Size = New System.Drawing.Size(273, 250)

                Dim Button1 As New Button
                'Button1.Location = New System.Drawing.Point(40, 269) 
                Button1.Size = New System.Drawing.Size(100, 50)
                Button1.Text = "BUMP" & " " & item
                Button1.UseVisualStyleBackColor = True
                Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
                Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
                Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Button1.ForeColor = System.Drawing.Color.White
                Do While (rdr.Read())
                    Dim s1 As String
                    If rdr.GetValue(2).ToString() = "" Then
                        s1 = rdr.GetValue(0).ToString()
                    Else
                        s1 = rdr(0) & vbCrLf & rdr.GetValue(2).ToString()
                    End If
                    dgwEB.Rows.Add(s1, rdr(1))
                    lblBillNo.Text = "Bill No.:" & " " & item & "           " & "Order No.:" & " " & rdr.GetValue(4).ToString()
                    flp.Controls.Add(lblBillNo)
                    Dim StartDate As DateTime = System.DateTime.Now
                    Dim EndDate As DateTime = rdr.GetValue(3)
                    ' Find time difference between two dates
                    Dim interval As TimeSpan = StartDate - EndDate
                    lblRunningTime.Text = "Running since " & (interval.Days * 24 * 60 + interval.Hours * 60 + interval.Minutes).ToString() & " Minutes."
                    flp.Controls.Add(lblRunningTime)
                    flp.Controls.Add(dgwEB)
                    flp.Controls.Add(Button1)
                    flpEB.Controls.Add(flp)
                    dgwEB.ClearSelection()
                Loop
                con.Close()
                AddHandler Button1.Click, AddressOf Me.ButtonEB_Click
            Next

        Catch ex As Exception
            End
        End Try
    End Sub
    Private Sub ButtonDineIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim BNo As String
            Dim str As String = btn1.Text.Trim()
            Dim strText() As String
            strText = Split(str, " ")
            BNo = strText(1)
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "Update RestaurantPOS_OrderInfoKOT set KOT_Status='Prepared' where TicketNo=@d1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", BNo)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            con.Close()
            GetDataDineIn()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ButtonTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim BNo As String
            Dim str As String = btn1.Text.Trim()
            Dim strText() As String
            strText = Split(str, " ")
            BNo = strText(1)
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "Update RestaurantPOS_BillingInfoTA set TA_Status='Closed' where BillNo=@d1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", BNo)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            con.Close()
            GetDataTakeAway()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ButtonHD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim BNo As String
            Dim str As String = btn1.Text.Trim()
            Dim strText() As String
            strText = Split(str, " ")
            BNo = strText(1)
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "Update RestaurantPOS_BillingInfoHD set HD_Status='Prepared' where BillNo=@d1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", BNo)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            con.Close()
            GetDataHomeDelivery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ButtonEB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim BNo As String
            Dim str As String = btn1.Text.Trim()
            Dim strText() As String
            strText = Split(str, " ")
            BNo = strText(1)
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "Update RestaurantPOS_BillingInfoEB set EB_Status='Closed' where BillNo=@d1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", BNo)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            con.Close()
            GetDataExpressBilling()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function DBConnectionStatus() As Boolean
        Try
            Using sqlConn As New SqlConnection(cs)
                sqlConn.Open()
                Return (sqlConn.State = ConnectionState.Open)
            End Using
        Catch e1 As SqlException
            Return False
        Catch e2 As Exception
            Return False
        End Try
    End Function

    Private Sub frmKDS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetDataDineIn()
        GetDataTakeAway()
        GetDataHomeDelivery()
        GetDataExpressBilling()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        GetDataDineIn()
        GetDataTakeAway()
        GetDataHomeDelivery()
        GetDataExpressBilling()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        GetDataDineIn()
        GetDataTakeAway()
        GetDataHomeDelivery()
        GetDataExpressBilling()
    End Sub

    Private Sub TabControl1_DrawItem(sender As System.Object, e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        'Firstly we'll define some parameters.
        Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
        Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
        Dim FillBrush As New SolidBrush(Color.NavajoWhite)
        Dim TextBrush As New SolidBrush(Color.Black)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        'If we are currently painting the Selected TabItem we'll 
        'change the brush colors and inflate the rectangle.
        If CBool(e.State And DrawItemState.Selected) Then
            FillBrush.Color = Color.NavajoWhite
            TextBrush.Color = Color.Black
            ItemRect.Inflate(2, 2)
        End If

        'Set up rotation for left and right aligned tabs
        If TabControl1.Alignment = TabAlignment.Left Or TabControl1.Alignment = TabAlignment.Right Then
            Dim RotateAngle As Single = 90
            If TabControl1.Alignment = TabAlignment.Left Then RotateAngle = 270
            Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
            e.Graphics.TranslateTransform(cp.X, cp.Y)
            e.Graphics.RotateTransform(RotateAngle)
            ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
        End If

        'Next we'll paint the TabItem with our Fill Brush
        e.Graphics.FillRectangle(FillBrush, ItemRect)

        'Now draw the text.
        e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)

        'Reset any Graphics rotation
        e.Graphics.ResetTransform()

        'Finally, we should Dispose of our brushes.
        FillBrush.Dispose()
        TextBrush.Dispose()
        'Dim g As Graphics = e.Graphics
        'Dim p As New Pen(Color.Tomato, 4)
        'g.DrawRectangle(p, Me.TabPage1.Bounds)
    End Sub
End Class