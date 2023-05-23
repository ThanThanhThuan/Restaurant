Imports System.Data.SqlClient

Public Class frmRestaurantPOSHDRecord
    Sub fillBillNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillNo) FROM RestaurantPOS_BillingInfoHD order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbBillNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbBillNo.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoHD.Id), RTRIM(BillNo),BillDate,RTRIM(Customername),RTRIM(RestaurantPOS_BillingInfoHD.Address),RTRIM(RestaurantPOS_BillingInfoHD.ContactNo),HDDiscountPer,HDDiscountAmt,(RestaurantPOS_BillingInfoHD.SubTotal),HomeDeliveryCharges,GrandTotal,Employee_ID,RTRIM(EmployeeName),RTRIM(PaymentMode),RTRIM(Operator),RTRIM(Member_ID),RTRIM(HD_Status) from RestaurantPOS_BillingInfoHD,EmployeeRegistration where RestaurantPOS_BillingInfoHD.Employee_ID=EmployeeRegistration.EmpID and (DATEDIFF(d,BillDate,GetDate())= 0) Order by BillDate Desc"
            cmd = New SqlCommand(sql, con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillBillNo()
    End Sub
    Sub Reset()
        cmbBillNo.Text = ""
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        txtContactNo.Text = ""
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
                frmPOS.txtBillID2.Text = dr.Cells(0).Value.ToString()
                frmPOS.lblBillNo2.Text = dr.Cells(1).Value.ToString()
                frmPOS.txtCustomerName.Text = dr.Cells(3).Value.ToString()
                frmPOS.txtAddress.Text = dr.Cells(4).Value.ToString()
                frmPOS.txtContactNo.Text = dr.Cells(5).Value.ToString()
                frmPOS.txtHDDiscountPer.Text = dr.Cells(6).Value.ToString()
                frmPOS.txtHDDiscountAmount.Text = dr.Cells(7).Value.ToString()
                frmPOS.txtSubTotal.Text = dr.Cells(8).Value.ToString()
                frmPOS.lblBalance2.Text = dr.Cells(8).Value.ToString()
                frmPOS.txtDeliveryCharges.Text = dr.Cells(9).Value.ToString()
                frmPOS.txtGrandTotal2.Text = dr.Cells(10).Value.ToString()
                frmPOS.txtDeliveryPersonID.Text = dr.Cells(11).Value.ToString()
                frmPOS.txtDeliveryPerson.Text = dr.Cells(12).Value.ToString()
                frmPOS.lblPaymentMode2.Text = dr.Cells(13).Value.ToString()
                frmPOS.lblMemberID.Text = dr.Cells(15).Value.ToString()
                frmPOS.btnSave3.Enabled = False
                If lblUserType.Text = "Super Admin" Then
                    frmPOS.btnDelete3.Enabled = True
                Else
                    frmPOS.btnDelete3.Enabled = False
                End If
                '''''If (lblUserType.Text = "Super Admin" And ((dr.Cells(16).Value.ToString() = "Confirmed") Or (dr.Cells(16).Value.ToString() = "Prepared"))) Or (lblUserType.Text = "Super Admin" And ((dr.Cells(16).Value.ToString() = "Confirmed") Or (dr.Cells(16).Value.ToString() = "Prepared"))) Then
                frmPOS.btnChangeStatus.Enabled = True
                frmPOS.btnPrint3.Enabled = True
                frmPOS.lblSet.Text = "Not Allowed"
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select RTRIM(Dish),RTRIM(Rate),RTRIM(Quantity),RTRIM(Amount),RTRIM(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer), RTRIM(VATAmount),SCPer,SCAmount,RTRIM(TotalAmount),RTRIM(Notes) from RestaurantPOS_BillingInfoHD,RestaurantPOS_OrderedProductBillHD where RestaurantPOS_BillingInfoHD.Id=RestaurantPOS_OrderedProductBillHD.BillID and RestaurantPOS_BillingInfoHD.ID=" & dr.Cells(0).Value & " order by Dish"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmPOS.DataGridView4.Rows.Clear()
                While (rdr.Read() = True)
                    frmPOS.DataGridView4.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
                End While
                frmPOS.lblBalance2.Text = frmPOS.GrandTotal_Food3()
                frmPOS.txtSubTotal.Text = frmPOS.GrandTotal_Food3()
                frmPOS.txtStatus.Text = dr.Cells(16).Value.ToString()
                con.Close()
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
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoHD.Id), RTRIM(BillNo),BillDate,RTRIM(Customername),RTRIM(RestaurantPOS_BillingInfoHD.Address),RTRIM(RestaurantPOS_BillingInfoHD.ContactNo),HDDiscountPer,HDDiscountAmt,(RestaurantPOS_BillingInfoHD.SubTotal),HomeDeliveryCharges,GrandTotal,Employee_ID,RTRIM(EmployeeName),RTRIM(PaymentMode),RTRIM(Operator),RTRIM(Member_ID),RTRIM(HD_Status) from RestaurantPOS_BillingInfoHD,EmployeeRegistration where RestaurantPOS_BillingInfoHD.Employee_ID=EmployeeRegistration.EmpID and  BillDate >=@d1 and BillDate < @d2 Order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBillNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoHD.Id), RTRIM(BillNo),BillDate,RTRIM(Customername),RTRIM(RestaurantPOS_BillingInfoHD.Address),RTRIM(RestaurantPOS_BillingInfoHD.ContactNo),HDDiscountPer,HDDiscountAmt,(RestaurantPOS_BillingInfoHD.SubTotal),HomeDeliveryCharges,GrandTotal,Employee_ID,RTRIM(EmployeeName),RTRIM(PaymentMode),RTRIM(Operator),RTRIM(Member_ID),RTRIM(HD_Status) from RestaurantPOS_BillingInfoHD,EmployeeRegistration where RestaurantPOS_BillingInfoHD.Employee_ID=EmployeeRegistration.EmpID and BillNo=@d1 Order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.CommandTimeout = 0
            cmd.Parameters.AddWithValue("@d1", cmbBillNo.Text)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_Format(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbBillNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub txtContactNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtContactNo.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoHD.Id), RTRIM(BillNo),BillDate,RTRIM(Customername),RTRIM(RestaurantPOS_BillingInfoHD.Address),RTRIM(RestaurantPOS_BillingInfoHD.ContactNo),HDDiscountPer,HDDiscountAmt,(RestaurantPOS_BillingInfoHD.SubTotal),HomeDeliveryCharges,GrandTotal,Employee_ID,RTRIM(EmployeeName),RTRIM(PaymentMode),RTRIM(Operator),RTRIM(Member_ID),RTRIM(HD_Status) from RestaurantPOS_BillingInfoHD,EmployeeRegistration where RestaurantPOS_BillingInfoHD.Employee_ID=EmployeeRegistration.EmpID and RestaurantPOS_BillingInfoHD.ContactNo like '%" & txtContactNo.Text & "%' Order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnShowAllBills_Click(sender As System.Object, e As System.EventArgs) Handles btnShowAllBills.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(RestaurantPOS_BillingInfoHD.Id), RTRIM(BillNo),BillDate,RTRIM(Customername),RTRIM(RestaurantPOS_BillingInfoHD.Address),RTRIM(RestaurantPOS_BillingInfoHD.ContactNo),HDDiscountPer,HDDiscountAmt,(RestaurantPOS_BillingInfoHD.SubTotal),HomeDeliveryCharges,GrandTotal,Employee_ID,RTRIM(EmployeeName),RTRIM(PaymentMode),RTRIM(Operator),RTRIM(Member_ID),RTRIM(HD_Status) from RestaurantPOS_BillingInfoHD,EmployeeRegistration where RestaurantPOS_BillingInfoHD.Employee_ID=EmployeeRegistration.EmpID Order by BillDate"
            cmd = New SqlCommand(sql, con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

