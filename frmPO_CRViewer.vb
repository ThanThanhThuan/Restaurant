Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class frmPO_CRViewer

    Private Sub btnSendMail_Click(sender As System.Object, e As System.EventArgs) Handles btnSendMail.Click
        Try
            If txtEmailID.Text = "" Then
                MessageBox.Show("Please enter Email ID", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmailID.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select count(*) from EmailSetting Having count(*) <=0"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                frmCustomDialog15.ShowDialog()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()
            If CheckForInternetConnection() = True Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn As String = "select RTRIM(Username),RTRIM(Password),RTRIM(SMTPAddress),(Port) from EmailSetting where IsDefault='Yes' and IsActive='Yes'"
                cmd = New SqlCommand(ctn)
                cmd.Connection = con
                Dim rdr1 As SqlDataReader
                rdr1 = cmd.ExecuteReader()
                If rdr1.Read() Then
                    Cursor = Cursors.WaitCursor
                    Timer1.Enabled = True
                    If (Not System.IO.Directory.Exists(Application.StartupPath & "\PDF Reports")) Then
                        System.IO.Directory.CreateDirectory(Application.StartupPath & "\PDF Reports")
                    End If
                    Dim pdfFile As String = Application.StartupPath & "\PDF Reports\PurchaseOrder " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".Pdf"
                    Cursor = Cursors.WaitCursor
                    Timer1.Enabled = True
                    Dim rpt As New rptPurchaseOrder 'The report you created.
                    Dim myConnection As SqlConnection
                    Dim MyCommand, MyCommand1 As New SqlCommand()
                    Dim myDA, myDA1 As New SqlDataAdapter()
                    Dim myDS As New DataSet 'The DataSet you created.
                    myConnection = New SqlConnection(cs)
                    MyCommand.Connection = myConnection
                    MyCommand1.Connection = myConnection
                    MyCommand.CommandText = "SELECT TaxType, PurchaseOrder.PO_ID, PurchaseOrder.PONumber, PurchaseOrder.Date, PurchaseOrder.Supplier_ID, PurchaseOrder.Terms, PurchaseOrder.SubTotal, PurchaseOrder.VATPer, PurchaseOrder.VATAmount, PurchaseOrder.GrandTotal, PurchaseOrder_Join.POJ_ID, PurchaseOrder_Join.PurchaseOrderID, PurchaseOrder_Join.ProductID, PurchaseOrder_Join.Qty,PurchaseOrder_Join.PricePerUnit, PurchaseOrder_Join.Amount, Product.PID, Product.ProductCode, Product.ProductName,  Product.Unit, Supplier.ID, Supplier.SupplierID, Supplier.Name,Supplier.Address, Supplier.City, Supplier.State, Supplier.ZipCode, Supplier.ContactNo, Supplier.EmailID, Supplier.Remarks, Supplier.TIN, Supplier.STNo, Supplier.CST, Supplier.PAN, Supplier.AccountName,Supplier.AccountNumber, Supplier.Bank, Supplier.Branch, Supplier.IFSCCode, Supplier.OpeningBalance, Supplier.OpeningBalanceType FROM PurchaseOrder INNER JOIN PurchaseOrder_Join ON PurchaseOrder.PO_ID = PurchaseOrder_Join.PurchaseOrderID INNER JOIN Product ON PurchaseOrder_Join.ProductID = Product.PID INNER JOIN Supplier ON PurchaseOrder.Supplier_ID = Supplier.ID where PO_ID=" & Val(frmPurchaseOrder.txtPO_ID.Text) & ""
                    MyCommand1.CommandText = "SELECT * from Hotel"
                    MyCommand.CommandType = CommandType.Text
                    MyCommand1.CommandType = CommandType.Text
                    myDA.SelectCommand = MyCommand
                    myDA1.SelectCommand = MyCommand1
                    myDA.Fill(myDS, "PurchaseOrder")
                    myDA.Fill(myDS, "PurchaseOrder_Join")
                    myDA.Fill(myDS, "Supplier")
                    myDA.Fill(myDS, "Product")
                    myDA1.Fill(myDS, "Hotel")
                    rpt.SetDataSource(myDS)
                    frmPurchaseOrder.GetRegisteredUserName(lblUser.Text)
                    rpt.SetParameterValue("p1", frmPurchaseOrder.lblname)
                    rpt.ExportToDisk(ExportFormatType.PortableDocFormat, pdfFile)
                    SendMail1(rdr1.GetValue(0), txtEmailID.Text, "Please find the attachment below", pdfFile, "Purchase Order", rdr1.GetValue(2), rdr1.GetValue(3), rdr1.GetValue(0), Decrypt(rdr1.GetValue(1)))
                    If (rdr1 IsNot Nothing) Then
                        rdr1.Close()
                    End If
                    rpt.Close()
                    rpt.Dispose()
                    MessageBox.Show("Successfully send", "Mail", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub txtEmailID_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtEmailID.Validating
        Dim pattern As String = "^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"
        Dim match As System.Text.RegularExpressions.Match = Regex.Match(txtEmailID.Text.Trim(), pattern, RegexOptions.IgnoreCase)
        If (match.Success) Then
        Else
            MessageBox.Show("Please enter a valid email id", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtEmailID.Clear()
        End If
    End Sub

    Private Sub txtEmailID_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailID.KeyPress
        Dim ac As String = "@"
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Asc(e.KeyChar) < 97 Or Asc(e.KeyChar) > 122 Then
                If Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 95 Then
                    If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                        If ac.IndexOf(e.KeyChar) = -1 Then
                            e.Handled = True

                        Else

                            If txtEmailID.Text.Contains("@") And e.KeyChar = "@" Then
                                e.Handled = True
                            End If

                        End If


                    End If
                End If
            End If

        End If
    End Sub
End Class
