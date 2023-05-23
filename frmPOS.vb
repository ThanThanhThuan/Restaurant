Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.IO.Ports
Imports System.Text.RegularExpressions
Imports CrystalDecisions.Shared
Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Printing
Imports RawPrint
Imports System.Text
Imports System.Drawing.Imaging
Imports GemBox.Pdf
Imports Spire.Pdf
Imports Ext

Public Class frmPOS
    Private Const VerticalStep As Integer = 40
    Dim Filename As String
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Dim sign_Indicator As Integer = 0
    Dim variable1 As Double
    Dim variable2 As Double
    Private operatorx As String = ""
    Dim fl As Boolean = False
    Dim s, x As String
    Dim num1, num2, num3, num4, num5, num6, num7 As Double
    Dim s1, s2, s3, s4 As String
    Dim str1 As String
    Dim str2 As Integer = 0
    Dim str As String
    Dim m As Decimal
    Dim i1, i2 As Integer
    Dim a As Decimal
    Dim CurrentTextBox As TextBox
    Public scrollValue As Integer
    Dim strCreditCustomerName As String
    Public literal As String
    Public subt As String
    Dim WithEvents com1 As New SerialPort
    Private Declare Function ShowScrollBar Lib "user32" (ByVal hwnd As IntPtr, ByVal wBar As Integer, ByVal bShow As Boolean) As Integer
    ' Constants
    Private Const SB_HORZ As Integer = 0
    Private Const SB_VERT As Integer = 1
    Private Const SB_BOTH As Integer = 3
    Dim retrieving As New Retrieving()
    Private paymentMode As String = "Cash"
    Dim retrieve As New Retrieving()
    Dim pth As String = "C:\Users\Public\Documents\Restaurant POS\"
    Dim filepath As String = Application.StartupPath + "\\rawData\\"
    Private isHappyHour As Boolean = False

    Sub GetHotelName()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(HotelName) from Hotel"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtHotelName.Text = rdr.GetValue(0)
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
    Sub GetAccessList()
        Try
            Dim lbl As New Label()
            lbl.Text = "No image"
            lbl.Font = New Font("Microsoft sans serif", 13.0F, FontStyle.Bold)
            lbl.ForeColor = Color.Red
            Dim dtAccess As New DataTable()
            Dim access As New GetInfos()
            dtAccess = access.GetAccessList()
            Dim a As Integer
            While (a < dtAccess.Rows.Count)
                If (TabPage1.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    TabPage1.Enabled = False
                    TabPage1.Controls.Clear()
                    TabPage1.Controls.Add(lbl)
                End If
                If (TabPage2.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    TabPage2.Enabled = False
                    TabPage2.Controls.Clear()
                    TabPage2.Controls.Add(lbl)
                End If
                If (TabPage3.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    TabPage3.Enabled = False
                    TabPage3.Controls.Clear()
                    TabPage3.Controls.Add(lbl)
                End If
                If (TabPage4.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    TabPage4.Enabled = False
                    TabPage4.Controls.Clear()
                    TabPage4.Controls.Add(lbl)
                End If
                a = a + 1
            End While
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(HotelName) from Hotel"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtHotelName.Text = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            '//

            If (TabPage1.Enabled = True) Then
                TabControl1.SelectedIndex = 0
                Return
            End If
            If (TabPage2.Enabled = True) Then
                TabControl1.SelectedIndex = 1
                Return
            End If
            If (TabPage3.Enabled = True) Then
                TabControl1.SelectedIndex = 2
                Return
            End If
            If (TabPage4.Enabled = True) Then
                TabControl1.SelectedIndex = 5
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub GetTaxType()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(TaxType) from OtherSetting"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtTaxType.Text = rdr.GetValue(0).ToString()
            Else
                txtTaxType.Text = ""
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
    Sub CustomerDisplayOpeningMessage()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT * from POSPrinterSetting where TillID=@d1 and CustomerDisplay='Yes'"
            cmd.Parameters.AddWithValue("@d1", System.Net.Dns.GetHostName)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                Dim sp As New SerialPort(txtDisplayPort.Text, 9600, Parity.None, 8, StopBits.One)
                sp.Open()
                ' to clear the display
                sp.Write(CChar(ChrW(12)))
                sp.WriteLine(txtHotelName.Text)
                sp.Close()
                sp.Dispose()
                sp = Nothing
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
    Sub GetCustomerDisplayPort()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(CDPort) from POSPrinterSetting where TillID=@d1"
            cmd.Parameters.AddWithValue("@d1", System.Net.Dns.GetHostName)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtDisplayPort.Text = rdr.GetValue(0)
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
    Sub CustomerDisplay(ByVal ItemName As String, ByVal TotalAmount As Decimal, ByVal NetTotal As Decimal)
        Try
            GetCustomerDisplayPort()
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT * from POSPrinterSetting where TillID=@d1 and CustomerDisplay='Yes'"
            cmd.Parameters.AddWithValue("@d1", System.Net.Dns.GetHostName)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                Dim sp As New SerialPort(txtDisplayPort.Text, 9600, Parity.None, 8, StopBits.One)
                sp.Open()
                ' to clear the display
                sp.Write(CChar(ChrW(12)))
                ' first line goes here
                sp.WriteLine(ItemName & " " & TotalAmount)
                ' second line goes here
                sp.Write(CChar(ChrW(13)))
                sp.WriteLine("TOTAL : " & NetTotal)
                sp.Close()
                sp.Dispose()
                sp = Nothing
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
    Private Sub OrderNo()
        Try
            Dim Num As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = ("SELECT MAX(ODNo) FROM tblOrder")
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            If (IsDBNull(cmd.ExecuteScalar)) Then
                Num = 1
                lblOrderNo.Text = Num.ToString
            Else
                Num = cmd.ExecuteScalar + 1
                lblOrderNo.Text = Num.ToString
            End If
            cmd.Dispose()
            con.Close()
            con.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnCurrencyKOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            lblCurrencyKOT.Visible = True
            lblCurrencyValKOT.Visible = True
            lblCurrencyValKOT.Text = ""
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text.Trim()
            Dim strText() As String
            strText = str.Split(" ")
            lblCurrencyValKOT.Text = strText(1).Trim()
            txtCash.Text = ""
            txtGrandTotal.Text = strText(0)
            GetExchangeRate(strText(1))
            For Each row As DataGridViewRow In DataGridView2.Rows
                row.Cells(2).Value = Math.Round(Val(row.Cells(2).Value) / Val(txtExchangeRate.Text), 2)
                row.Cells(4).Value = Math.Round(Val(row.Cells(4).Value) / Val(txtExchangeRate.Text), 2)
                row.Cells(6).Value = Math.Round(Val(row.Cells(6).Value) / Val(txtExchangeRate.Text), 2)
                row.Cells(8).Value = Math.Round(Val(row.Cells(8).Value) / Val(txtExchangeRate.Text), 2)
                row.Cells(10).Value = Math.Round(Val(row.Cells(10).Value) / Val(txtExchangeRate.Text), 2)
                row.Cells(12).Value = Math.Round(Val(row.Cells(12).Value) / Val(txtExchangeRate.Text), 2)
                row.Cells(13).Value = Math.Round(Val(row.Cells(13).Value) / Val(txtExchangeRate.Text), 2)
            Next
            txtGrandTotal.Text = GrandTotal_Food1()
            flpKOT.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub OpenCashdrawer()
        Try
            'Modify DrawerCode to your receipt printer open drawer code
            Dim DrawerCode As String = Chr(27) & Chr(112) & Chr(48) & Chr(64) & Chr(64)
            'Modify PrinterName to your receipt printer name
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes' and CashDrawer='Enabled'"
            cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s4 = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Dim PrinterName As String = s4
            RawPrinter.PrintRaw(PrinterName, DrawerCode)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function GenerateID1() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 ID FROM RestaurantPOS_BillingInfoKOT ORDER BY ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ID")
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
    Sub auto1()
        Try
            txtBillID.Text = GenerateID1()
            lblBillNo.Text = "DIB-" + GenerateID1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Function GenerateID2() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 ID FROM RestaurantPOS_BillingInfoTA ORDER BY ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ID")
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
    Sub auto2()
        Try
            txtBillID1.Text = GenerateID2()
            lblBillNo1.Text = "TA-" + GenerateID2()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Function GenerateID3() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 ID FROM RestaurantPOS_BillingInfoHD ORDER BY ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ID")
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
    Sub auto3()
        Try
            txtBillID2.Text = GenerateID3()
            lblBillNo2.Text = "HDB-" + GenerateID3()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Function GenerateID4() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 ID FROM RestaurantPOS_BillingInfoEB ORDER BY ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ID")
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
    Sub auto4()
        Try
            txtBillID3.Text = GenerateID4()
            'lblBillNo3.Text = "EB-" + GenerateID4()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub fillTableNo()
        Try
            Dim _with1 = lvTable
            _with1.Clear()
            _with1.Columns.Add("Table No.", 140, HorizontalAlignment.Left)
            _with1.Columns.Add("Cust./Group Name", -2, HorizontalAlignment.Left)
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT distinct RTRIM(TableNo),RTRIM(GroupName) FROM RestaurantPOS_OrderInfoKOT where KOT_Status in ('Open','Served','Prepared') and ID in(SELECT [TicketID] FROM [RestaurantPOS_OrderedProductKOT] where Category in(select Kitchenname from Kitchen where Kitchenname = '" & cmbBillSetion.Text.Trim() & "'))", con)
            'cmd = New SqlCommand("SELECT distinct RTRIM(R_Table.TableNo),RTRIM(GroupName) FROM R_Table,RestaurantPOS_OrderInfoKOT where (RestaurantPOS_OrderInfoKOT.TableNo=R_Table.TableNo OR R_Table.TableNo in (Select TableNo from RestaurantPOS_OrderInfoKOT)) and R_Table.Status='Activate' and KOT_Status in ('Open','Served','Prepared')", con)
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                Dim item = New ListViewItem()
                item.Text = rdr(0).ToString().Trim()
                item.SubItems.Add(rdr(1).ToString().Trim())
                lvTable.Items.Add(item)
            End While
            con.Close()
            ShowScrollBar(lvTable.Handle, SB_HORZ, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub POSHeaderEnable()
        lblPOS.Visible = True
        lblU.Visible = True
        lblUserVAL.Visible = True
        lblOD.Visible = True
        lblOrderNo.Visible = True
    End Sub
    Sub Reset1()
        lblBillNo.Text = ""
        cmbKOTDiscountType.SelectedIndex = 0
        txtKOTDiscountAmount.Enabled = False
        txtKOTDiscPer.Enabled = True
        txtKOTDiscPer.Text = "0.00"
        txtKOTDiscountAmount.Text = "0.00"
        txtCash.Text = ""
        txtChange.Text = ""
        DataGridView2.Rows.Clear()
        btnSave1.Enabled = True
        btnDelete1.Enabled = False
        lvTable.Enabled = True
        lblPaymentMode.Text = "Cash"
        flpKOT.Visible = False
        lblCurrencyKOT.Visible = False
        lblCurrencyValKOT.Visible = False
        lblCurrencyValKOT.Text = ""
        flpKOT.Enabled = True
        txtExchangeRate.Text = 1
        btnUpdateFinalBill.Enabled = False
        pnlKOT.Enabled = True
        auto1()
        fillTableNo()
        GetOtherSetting()
        txtGrandTotal.Text = ""
        Me.lvTable.Enabled = True
        lblPrintMode.Text = ""
        lblMemberID.Text = ""
        txtCash.ReadOnly = False
        POSHeaderEnable()
        lblCustName.Visible = False
        lblCustNameVAL.Visible = False
        lblWaiterNameVal.Text = ""
        OrderNo()
        CustomerDisplayOpeningMessage()
        ShowScrollBar(lvTable.Handle, SB_HORZ, False)
    End Sub
    Sub GetOtherSetting()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT IsNull(ParcelCharges,0),Isnull(HomeDeliveryCharges,0),RTRIM(TA),RTRIM(HD),RTRIM(EB),RTRIM(KG) from OtherSetting"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtParcelCharges.Text = rdr.GetValue(0)
                txtDeliveryCharges.Text = rdr.GetValue(1)
                K1.Text = rdr.GetString(2)
                K2.Text = rdr.GetString(3)
                K3.Text = rdr.GetString(4)
                K4.Text = rdr.GetString(5)
            Else
                txtParcelCharges.Text = 0
                txtDeliveryCharges.Text = 0
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
    Sub GetSMIISetting()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(SMII) from POSprinterSetting where TillID=@d1"
            cmd.Parameters.AddWithValue("@d1", System.Net.Dns.GetHostName)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtSMII.Text = rdr.GetValue(0).ToString()
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
    Sub GetBaseCurrency()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(CurrencyCode) from Hotel"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                str = rdr.GetValue(0)
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
    Sub GetExchangeRate(ByVal st As String)
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Rate from Currency where CurrencyCode=@d1"
            cmd.Parameters.AddWithValue("@d1", st)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtExchangeRate.Text = rdr.GetValue(0)
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
    Sub Reset2()
        btnRevert1.Visible = False
        lblBillNo1.Text = ""
        cmbTADiscountType.SelectedIndex = 0
        txtTADiscountAmount.Enabled = False
        txtTADiscountPer.Enabled = True
        txtTADiscountPer.Text = "0.00"
        txtTADiscountAmount.Text = "0.00"
        txtSubTotal1.Text = ""
        txtCash1.Text = ""
        txtGrandTotal1.Text = ""
        txtChange1.Text = ""
        DataGridView3.Rows.Clear()
        btnSave2.Enabled = True
        btnDelete2.Enabled = False
        flpCategoriesTA.Enabled = True
        flpItemsTA.Enabled = True
        btnPlus1.Enabled = False
        btnMinus1.Enabled = False
        btnChangeRate1.Enabled = False
        btnChangeQty1.Enabled = False
        btnCancel1.Enabled = False
        lblBalance1.Text = "0.00"
        lblSet.Text = ""
        txtNotes.Text = ""
        auto2()
        Clear2()
        lblPaymentMode1.Text = "Cash"
        txtExchangeRate.Text = 1
        lblCurrencyTA.Visible = False
        lblCurrencyValTA.Visible = False
        lblCurrencyValTA.Text = ""
        flpTA.Visible = False
        flpTA.Enabled = True
        txtItemsTA.Text = ""
        lblMemberID.Text = ""
        GetOtherSetting()
        DataGridView3.Enabled = True
        txtCash1.ReadOnly = False
        txtTAContactNo.Text = ""
        lblCustName.Visible = False
        lblCustNameVAL.Visible = False
        btnVoid1.Enabled = False
        OrderNo()
        CustomerDisplayOpeningMessage()
        POSHeaderEnable()
        btnModifiers1.Enabled = False
        pnlTA.Visible = False
        DataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub
    Sub Reset3()
        lblBillNo2.Text = ""
        cmbHDDiscountType.SelectedIndex = 0
        txtHDDiscountAmount.Enabled = False
        txtHDDiscountPer.Enabled = True
        txtHDDiscountPer.Text = "0.00"
        txtHDDiscountAmount.Text = "0.00"
        txtSubTotal.Text = ""
        txtGrandTotal2.Text = ""
        DataGridView4.Rows.Clear()
        btnSave3.Enabled = True
        btnDelete3.Enabled = False
        txtCustomerName.Text = ""
        txtAddress.Text = ""
        txtContactNo.Text = ""
        txtDeliveryPerson.Text = ""
        flpCategoriesHD.Enabled = True
        flpItemsHD.Enabled = True
        btnPlus2.Enabled = False
        btnMinus2.Enabled = False
        btnChangeRate2.Enabled = False
        btnChangeQty2.Enabled = False
        btnCancel2.Enabled = False
        lblBalance2.Text = "0.00"
        lblSet.Text = ""
        txtNotes.Text = ""
        txtItemsHD.Text = ""
        auto3()
        Clear3()
        lblPaymentMode2.Text = "Cash"
        lblMemberID.Text = ""
        GetOtherSetting()
        lblCustName.Visible = False
        lblCustNameVAL.Visible = False
        OrderNo()
        btnChangeStatus.Enabled = False
        CustomerDisplayOpeningMessage()
        POSHeaderEnable()
        btnModifiers2.Enabled = False
        pnlHD.Visible = False
        DataGridView4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub
    Sub Reset4()
        'lblBillNo3.Text = ""
        'cmbEBDiscountType.SelectedIndex = 0
        'txtEBDiscountAmount.Enabled = False
        'txtEBDiscountPer.Enabled = True
        'txtEBDiscountPer.Text = "0.00"
        'txtEBDiscountAmount.Text = "0.00"
        'txtGrandTotal3.Text = ""
        'btnModifiers3.Enabled = False
        'DataGridView5.Rows.Clear()
        'btnPrint4.Enabled = False
        'btnSave4.Enabled = True
        'btnDelete4.Enabled = False
        'flpCategoriesEB.Enabled = True
        'flpItemsEB.Enabled = True
        'btnPlus3.Enabled = False
        'btnMinus3.Enabled = False
        'btnChangeRate3.Enabled = False
        'btnChangeQty3.Enabled = False
        'btnCancel3.Enabled = False
        'lblBalance3.Text = "0.00"
        lblSet.Text = ""
        txtNotes.Text = ""
        auto4()
        Clear4()
        txtExchangeRate.Text = 1
        'lblCurrencyEB.Visible = False
        'lblCurrencyValEB.Visible = False
        'lblCurrencyValEB.Text = ""
        'DataGridView5.Enabled = True
        'btnUpdate.Enabled = False
        'flpEB.Visible = False
        'flpEB.Enabled = True
        'lblPaymentMode3.Text = "Cash"
        'txtCash3.Text = "0.00"
        'txtChange3.Text = "0.00"
        'txtItemsEB.Text = ""
        'btnRevert2.Visible = False
        GetOtherSetting()
        lblMemberID.Text = ""
        'DataGridView5.Enabled = True
        'txtCash3.ReadOnly = False
        'txtEBContactNo.Text = ""
        lblCustName.Visible = False
        lblCustNameVAL.Visible = False
        OrderNo()
        'btnVoid2.Enabled = False
        CustomerDisplayOpeningMessage()
        POSHeaderEnable()
        'pnlEB.Visible = False
        'DataGridView5.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        'btnCreditCustomer3.Enabled = True
    End Sub
    Sub LoadData()
        Try
            GetBaseCurrency()
            txtExchangeRate.Text = 1
            'flpEB.Visible = False
            flpTA.Visible = False
            flpKOT.Visible = False
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT Distinct RTRIM(CategoryName),Category.BackColor from Category,Dish where Category.Categoryname=Dish.Category and RTRIM(Kitchen) = RTRIM(@kitchen) order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.Add("@kitchen", SqlDbType.NVarChar).Value = cmbSection.Text.Trim()
            cmd.Connection = con
            rdr = cmd.ExecuteReader
            flpCategoriesKOT.Controls.Clear()
            flpItemsKOT.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpCategoriesKOT.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.Button_Click
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText2 As String = "SELECT Distinct RTRIM(CategoryName),Category.BackColor from Category,Dish where Category.Categoryname=Dish.Category and RTRIM(Kitchen) = RTRIM(@kitchen) order by 1"
            cmd = New SqlCommand(cmdText2)
            cmd.Parameters.Add("@kitchen", SqlDbType.NVarChar).Value = cmbTSection.Text.Trim()
            cmd.Connection = con
            rdr = cmd.ExecuteReader
            flpCategoriesTA.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpCategoriesTA.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.ButtonTA_Click
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText3 As String = "SELECT Distinct RTRIM(CategoryName),Category.BackColor from Category,Dish where Category.Categoryname=Dish.Category order by 1"
            cmd = New SqlCommand(cmdText3)
            cmd.Connection = con
            rdr = cmd.ExecuteReader
            flpCategoriesHD.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpCategoriesHD.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.ButtonHD_Click
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText4 As String = "SELECT Distinct RTRIM(CategoryName),Category.BackColor from Category,Dish where Category.Categoryname=Dish.Category order by 1"
            cmd = New SqlCommand(cmdText4)
            cmd.Connection = con
            rdr = cmd.ExecuteReader
            'flpCategoriesEB.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                'flpCategoriesEB.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.ButtonEB_Click
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
            fillTableNo()
            'Fill()
            auto()
            auto1()
            auto2()
            auto3()
            auto4()
            lblPaymentMode.Text = "Cash"
            lblPaymentMode1.Text = "Cash"
            lblPaymentMode2.Text = "Cash"
            'lblPaymentMode3.Text = "Cash"
            GetOtherSetting()
            txtTillID.Text = System.Net.Dns.GetHostName
            OrderNo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub LoadDataORDER()
        Try
            GetBaseCurrency()
            txtExchangeRate.Text = 1
            'flpEB.Visible = False
            flpTA.Visible = False
            flpKOT.Visible = False
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT Distinct RTRIM(CategoryName),Category.BackColor from Category,Dish where Category.Categoryname=Dish.Category and RTRIM(Kitchen) = RTRIM(@kitchen) order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.Add("@kitchen", SqlDbType.NVarChar).Value = cmbSection.SelectedItem.ToString().Trim()
            cmd.Connection = con
            rdr = cmd.ExecuteReader
            flpCategoriesKOT.Controls.Clear()
            flpItemsKOT.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpCategoriesKOT.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.Button_Click
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
            con = New SqlConnection(cs)
            fillTableNo()
            'Fill()
            auto()
            auto1()
            auto2()
            auto3()
            auto4()
            lblPaymentMode.Text = "Cash"
            lblPaymentMode1.Text = "Cash"
            lblPaymentMode2.Text = "Cash"
            'lblPaymentMode3.Text = "Cash"
            GetOtherSetting()
            txtTillID.Text = System.Net.Dns.GetHostName
            OrderNo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(DishName),Dish.BackColor,RTRIM(Photo) from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 and MI_Status='Active' and RTRIM(DishName) in(SELECT RTRIM([Dish]) FROM [Temp_Stock_Store] where Qty >= 1) order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsKOT.Controls.Clear()
            Do While (rdr.Read())
                If txtSMII.Text = "Yes" Then
                    Dim Dflp As New FlowLayoutPanel
                    Dflp.Size = New System.Drawing.Size(110, 140)
                    Dflp.BackColor = Color.White
                    Dflp.BorderStyle = BorderStyle.FixedSingle
                    Dflp.FlowDirection = FlowDirection.TopDown
                    Dim btn As New Button
                    Dim btnX As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.Width = 108
                    btn.Height = 90
                    If rdr.GetValue(2).ToString() <> "" Then
                        btn.BackgroundImage = Image.FromFile(Application.StartupPath & rdr.GetValue(2).ToString())
                        btn.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Text = rdr.GetValue(0)
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 1.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
                    btn.ForeColor = System.Drawing.Color.Black
                    btnX.Text = rdr.GetValue(0)
                    btnX.FlatStyle = FlatStyle.Flat
                    btnX.Width = 108
                    btnX.Height = 35
                    btnX.FlatAppearance.BorderSize = 0
                    btnX.Text = rdr.GetValue(0)
                    btnX.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    btnX.ForeColor = Color.Black
                    UserButtons.Add(btn)
                    UserButtons.Add(btnX)
                    Dflp.Controls.Add(btn)
                    Dflp.Controls.Add(btnX)
                    flpItemsKOT.Controls.Add(Dflp)
                    AddHandler btn.Click, AddressOf Me.Button1_Click
                    AddHandler btnX.Click, AddressOf Me.Button1X_Click
                Else
                    Dim btn As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.FlatStyle = FlatStyle.Popup
                    Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                    btn.BackColor = btnColor
                    btn.ForeColor = Color.White
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Width = 110
                    btn.Height = 60
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    UserButtons.Add(btn)
                    flpItemsKOT.Controls.Add(btn)
                    AddHandler btn.Click, AddressOf Me.Button1_Click

                End If
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
            If (flpItemsKOT.Controls.Count < 1) Then
                Dim lNofound As New Label()
                lNofound.Text = "No item found!"
                lNofound.Width = 120
                flpItemsKOT.Controls.Add(lNofound)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ButtonTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(DishName),Dish.BackColor,RTRIM(Photo) from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 and MI_Status='Active' and RTRIM(DishName) in (SELECT RTRIM([Dish]) FROM [Temp_Stock_Store] where Qty >= 1) order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsTA.Controls.Clear()
            Do While (rdr.Read())
                If txtSMII.Text = "Yes" Then
                    Dim Dflp As New FlowLayoutPanel
                    Dflp.Size = New System.Drawing.Size(110, 140)
                    Dflp.BackColor = Color.White
                    Dflp.BorderStyle = BorderStyle.FixedSingle
                    Dflp.FlowDirection = FlowDirection.TopDown
                    Dim btn As New Button
                    Dim btnX As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.Width = 108
                    btn.Height = 90
                    If rdr.GetValue(2).ToString() <> "" Then
                        btn.BackgroundImage = Image.FromFile(Application.StartupPath & rdr.GetValue(2).ToString())
                        btn.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Text = rdr.GetValue(0)
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 1.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
                    btn.ForeColor = System.Drawing.Color.Black
                    btnX.Text = rdr.GetValue(0)
                    btnX.FlatStyle = FlatStyle.Flat
                    btnX.Width = 108
                    btnX.Height = 35
                    btnX.FlatAppearance.BorderSize = 0
                    btnX.Text = rdr.GetValue(0)
                    btnX.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    btnX.ForeColor = Color.Black
                    UserButtons.Add(btn)
                    UserButtons.Add(btnX)
                    Dflp.Controls.Add(btn)
                    Dflp.Controls.Add(btnX)
                    flpItemsTA.Controls.Add(Dflp)
                    AddHandler btn.Click, AddressOf Me.ButtonTA1_Click
                    AddHandler btnX.Click, AddressOf Me.ButtonTA1X_Click
                Else
                    Dim btn As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.FlatStyle = FlatStyle.Popup
                    Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                    btn.BackColor = btnColor
                    btn.ForeColor = Color.White
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Width = 110
                    btn.Height = 60
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    UserButtons.Add(btn)
                    flpItemsTA.Controls.Add(btn)
                    AddHandler btn.Click, AddressOf Me.ButtonTA1_Click
                End If
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
            If (flpItemsTA.Controls.Count < 1) Then
                Dim lNofound As New Label()
                lNofound.Text = "No item found!"
                lNofound.Width = 120
                flpItemsTA.Controls.Add(lNofound)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ButtonEB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(DishName),Dish.BackColor,RTRIM(Photo) from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 and MI_Status='Active' and RTRIM(DishName) in(SELECT RTRIM([Dish]) FROM [Temp_Stock_Store] where Qty >= 1) order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            'flpItemsEB.Controls.Clear()
            Do While (rdr.Read())
                If txtSMII.Text = "Yes" Then
                    Dim Dflp As New FlowLayoutPanel
                    Dflp.Size = New System.Drawing.Size(110, 140)
                    Dflp.BackColor = Color.White
                    Dflp.BorderStyle = BorderStyle.FixedSingle
                    Dflp.FlowDirection = FlowDirection.TopDown
                    Dim btn As New Button
                    Dim btnX As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.Width = 108
                    btn.Height = 90
                    If rdr.GetValue(2).ToString() <> "" Then
                        btn.BackgroundImage = Image.FromFile(Application.StartupPath & rdr.GetValue(2).ToString())
                        btn.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Text = rdr.GetValue(0)
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 1.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
                    btn.ForeColor = System.Drawing.Color.Black
                    btnX.Text = rdr.GetValue(0)
                    btnX.FlatStyle = FlatStyle.Flat
                    btnX.Width = 108
                    btnX.Height = 35
                    btnX.FlatAppearance.BorderSize = 0
                    btnX.Text = rdr.GetValue(0)
                    btnX.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    btnX.ForeColor = Color.Black
                    UserButtons.Add(btn)
                    UserButtons.Add(btnX)
                    Dflp.Controls.Add(btn)
                    Dflp.Controls.Add(btnX)
                    'flpItemsEB.Controls.Add(Dflp)
                    AddHandler btn.Click, AddressOf Me.ButtonEB1_Click
                    AddHandler btnX.Click, AddressOf Me.ButtonEB1X_Click
                Else
                    Dim btn As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.FlatStyle = FlatStyle.Popup
                    Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                    btn.BackColor = btnColor
                    btn.ForeColor = Color.White
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Width = 110
                    btn.Height = 60
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    UserButtons.Add(btn)
                    'flpItemsEB.Controls.Add(btn)
                    AddHandler btn.Click, AddressOf Me.ButtonEB1_Click
                End If
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
            'If (flpItemsEB.Controls.Count < 1) Then
            '    Dim lNofound As New Label()
            '    lNofound.Text = "No item found!"
            '    lNofound.Width = 120
            '    flpItemsEB.Controls.Add(lNofound)
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ButtonHD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(DishName),Dish.BackColor,RTRIM(Photo) from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 and MI_Status='Active' and RTRIM(DishName) in(SELECT RTRIM([Dish]) FROM [Temp_Stock_Store] where Qty >= 1) order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsHD.Controls.Clear()
            Do While (rdr.Read())
                If txtSMII.Text = "Yes" Then
                    Dim Dflp As New FlowLayoutPanel
                    Dflp.Size = New System.Drawing.Size(110, 140)
                    Dflp.BackColor = Color.White
                    Dflp.BorderStyle = BorderStyle.FixedSingle
                    Dflp.FlowDirection = FlowDirection.TopDown
                    Dim btn As New Button
                    Dim btnX As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.Width = 108
                    btn.Height = 90
                    If rdr.GetValue(2).ToString() <> "" Then
                        btn.BackgroundImage = Image.FromFile(Application.StartupPath & rdr.GetValue(2).ToString())
                        btn.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Text = rdr.GetValue(0)
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 1.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
                    btn.ForeColor = System.Drawing.Color.Black
                    btnX.Text = rdr.GetValue(0)
                    btnX.FlatStyle = FlatStyle.Flat
                    btnX.Width = 108
                    btnX.Height = 35
                    btnX.FlatAppearance.BorderSize = 0
                    btnX.Text = rdr.GetValue(0)
                    btnX.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    btnX.ForeColor = Color.Black
                    UserButtons.Add(btn)
                    UserButtons.Add(btnX)
                    Dflp.Controls.Add(btn)
                    Dflp.Controls.Add(btnX)
                    flpItemsHD.Controls.Add(Dflp)
                    AddHandler btn.Click, AddressOf Me.ButtonHD1_Click
                    AddHandler btnX.Click, AddressOf Me.ButtonHD1X_Click
                Else
                    Dim btn As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.FlatStyle = FlatStyle.Popup
                    Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                    btn.BackColor = btnColor
                    btn.ForeColor = Color.White
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Width = 110
                    btn.Height = 60
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    UserButtons.Add(btn)
                    flpItemsHD.Controls.Add(btn)
                    AddHandler btn.Click, AddressOf Me.ButtonHD1_Click
                End If
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
            If (flpItemsHD.Controls.Count < 1) Then
                Dim lNofound As New Label()
                lNofound.Text = "No item found!"
                lNofound.Width = 120
                flpItemsHD.Controls.Add(lNofound)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Fill()
        Try

            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText2 As String = "SELECT Top 1 RTRIM(categoryname) from Category,Dish where Category.CategoryName=Dish.Category order by 1"
            cmd = New SqlCommand(cmdText2)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                str1 = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(DishName),Dish.BackColor,RTRIM(Photo) from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 and MI_Status = 'Active' and RTRIM(DishName) in(SELECT RTRIM([Dish]) FROM [Temp_Stock_Store] where Qty >= 1) order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Parameters.AddWithValue("@d1", str1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsKOT.Controls.Clear()
            Do While (rdr.Read())
                If txtSMII.Text = "Yes" Then
                    Dim Dflp As New FlowLayoutPanel
                    Dflp.Size = New System.Drawing.Size(110, 140)
                    Dflp.BackColor = Color.White
                    Dflp.BorderStyle = BorderStyle.FixedSingle
                    Dflp.FlowDirection = FlowDirection.TopDown
                    Dim btn As New Button
                    Dim btnX As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.Width = 108
                    btn.Height = 90
                    If rdr.GetValue(2).ToString() <> "" Then
                        btn.BackgroundImage = Image.FromFile(Application.StartupPath & rdr.GetValue(2).ToString())
                        btn.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Text = rdr.GetValue(0)
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 1.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
                    btn.ForeColor = System.Drawing.Color.Black
                    btnX.Text = rdr.GetValue(0)
                    btnX.FlatStyle = FlatStyle.Flat
                    btnX.Width = 108
                    btnX.Height = 35
                    btnX.FlatAppearance.BorderSize = 0
                    btnX.Text = rdr.GetValue(0)
                    btnX.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    btnX.ForeColor = Color.Black
                    UserButtons.Add(btn)
                    UserButtons.Add(btnX)
                    Dflp.Controls.Add(btn)
                    Dflp.Controls.Add(btnX)
                    flpItemsKOT.Controls.Add(Dflp)
                    AddHandler btn.Click, AddressOf Me.Button1_Click
                    AddHandler btnX.Click, AddressOf Me.Button1X_Click
                Else
                    Dim btn As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.FlatStyle = FlatStyle.Popup
                    Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                    btn.BackColor = btnColor
                    btn.ForeColor = Color.White
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Width = 110
                    btn.Height = 60
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    UserButtons.Add(btn)
                    flpItemsKOT.Controls.Add(btn)
                    AddHandler btn.Click, AddressOf Me.Button1_Click
                End If
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
            If (flpItemsKOT.Controls.Count < 1) Then
                Dim lNofound As New Label()
                lNofound.Text = "No item found!"
                lNofound.Width = 120
                flpItemsKOT.Controls.Add(lNofound)
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText4 As String = "SELECT Top 1 RTRIM(categoryname) from Category,Dish where Category.CategoryName=Dish.Category order by 1"
            cmd = New SqlCommand(cmdText4)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                str1 = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText3 As String = "SELECT RTRIM(DishName),Dish.BackColor,RTRIM(Photo) from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 and MI_Status='Active' and RTRIM(DishName) in(SELECT RTRIM([Dish]) FROM [Temp_Stock_Store] where Qty >= 1) order by 1"
            cmd = New SqlCommand(cmdText3)
            cmd.Parameters.AddWithValue("@d1", str1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsTA.Controls.Clear()
            Do While (rdr.Read())
                If txtSMII.Text = "Yes" Then
                    Dim Dflp As New FlowLayoutPanel
                    Dflp.Size = New System.Drawing.Size(110, 140)
                    Dflp.BackColor = Color.White
                    Dflp.BorderStyle = BorderStyle.FixedSingle
                    Dflp.FlowDirection = FlowDirection.TopDown
                    Dim btn As New Button
                    Dim btnX As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.Width = 108
                    btn.Height = 90
                    If rdr.GetValue(2).ToString() <> "" Then
                        btn.BackgroundImage = Image.FromFile(Application.StartupPath & rdr.GetValue(2).ToString())
                        btn.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Text = rdr.GetValue(0)
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 1.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
                    btn.ForeColor = System.Drawing.Color.Black
                    btnX.Text = rdr.GetValue(0)
                    btnX.FlatStyle = FlatStyle.Flat
                    btnX.Width = 108
                    btnX.Height = 35
                    btnX.FlatAppearance.BorderSize = 0
                    btnX.Text = rdr.GetValue(0)
                    btnX.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    btnX.ForeColor = Color.Black
                    UserButtons.Add(btn)
                    UserButtons.Add(btnX)
                    Dflp.Controls.Add(btn)
                    Dflp.Controls.Add(btnX)
                    flpItemsTA.Controls.Add(Dflp)
                    AddHandler btn.Click, AddressOf Me.ButtonTA1_Click
                    AddHandler btnX.Click, AddressOf Me.ButtonTA1X_Click
                Else
                    Dim btn As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.FlatStyle = FlatStyle.Popup
                    Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                    btn.BackColor = btnColor
                    btn.ForeColor = Color.White
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Width = 110
                    btn.Height = 60
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    UserButtons.Add(btn)
                    flpItemsTA.Controls.Add(btn)
                    AddHandler btn.Click, AddressOf Me.ButtonTA1_Click
                End If
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
            If (flpItemsTA.Controls.Count < 1) Then
                Dim lNofound As New Label()
                lNofound.Text = "No item found!"
                lNofound.Width = 120
                flpItemsTA.Controls.Add(lNofound)
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText6 As String = "SELECT Top 1 RTRIM(categoryname) from Category,Dish where Category.CategoryName=Dish.Category order by 1"
            cmd = New SqlCommand(cmdText6)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                str1 = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText5 As String = "SELECT RTRIM(DishName),Dish.BackColor,RTRIM(Photo) from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 and MI_Status='Active' and RTRIM(DishName) in(SELECT RTRIM([Dish]) FROM [Temp_Stock_Store] where Qty >= 1) order by 1"
            cmd = New SqlCommand(cmdText5)
            cmd.Parameters.AddWithValue("@d1", str1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsHD.Controls.Clear()
            Do While (rdr.Read())
                If txtSMII.Text = "Yes" Then
                    Dim Dflp As New FlowLayoutPanel
                    Dflp.Size = New System.Drawing.Size(110, 140)
                    Dflp.BackColor = Color.White
                    Dflp.BorderStyle = BorderStyle.FixedSingle
                    Dflp.FlowDirection = FlowDirection.TopDown
                    Dim btn As New Button
                    Dim btnX As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.Width = 108
                    btn.Height = 90
                    If rdr.GetValue(2).ToString() <> "" Then
                        btn.BackgroundImage = Image.FromFile(Application.StartupPath & rdr.GetValue(2).ToString())
                        btn.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Text = rdr.GetValue(0)
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 1.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
                    btn.ForeColor = System.Drawing.Color.Black
                    btnX.Text = rdr.GetValue(0)
                    btnX.FlatStyle = FlatStyle.Flat
                    btnX.Width = 108
                    btnX.Height = 35
                    btnX.FlatAppearance.BorderSize = 0
                    btnX.Text = rdr.GetValue(0)
                    btnX.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    btnX.ForeColor = Color.Black
                    UserButtons.Add(btn)
                    UserButtons.Add(btnX)
                    Dflp.Controls.Add(btn)
                    Dflp.Controls.Add(btnX)
                    flpItemsHD.Controls.Add(Dflp)
                    AddHandler btn.Click, AddressOf Me.ButtonHD1_Click
                    AddHandler btnX.Click, AddressOf Me.ButtonHD1X_Click
                Else
                    Dim btn As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.FlatStyle = FlatStyle.Popup
                    Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                    btn.BackColor = btnColor
                    btn.ForeColor = Color.White
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Width = 110
                    btn.Height = 60
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    UserButtons.Add(btn)
                    flpItemsHD.Controls.Add(btn)
                    AddHandler btn.Click, AddressOf Me.ButtonHD1_Click
                End If
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
            If (flpItemsHD.Controls.Count < 1) Then
                Dim lNofound As New Label()
                lNofound.Text = "No item found!"
                lNofound.Width = 120
                flpItemsHD.Controls.Add(lNofound)
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText8 As String = "SELECT Top 1 RTRIM(categoryname) from Category,Dish where Category.CategoryName=Dish.Category order by 1"
            cmd = New SqlCommand(cmdText8)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                str1 = rdr.GetValue(0)
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText7 As String = "SELECT RTRIM(DishName),Dish.BackColor,RTRIM(Photo) from Category,Dish where Category.CategoryName=Dish.Category and Category=@d1 and MI_Status='Active' and RTRIM(DishName) in(SELECT RTRIM([Dish]) FROM [Temp_Stock_Store] where Qty >= 1) order by 1"
            cmd = New SqlCommand(cmdText7)
            cmd.Parameters.AddWithValue("@d1", str1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            'flpItemsEB.Controls.Clear()
            Do While (rdr.Read())
                If txtSMII.Text = "Yes" Then
                    Dim Dflp As New FlowLayoutPanel
                    Dflp.Size = New System.Drawing.Size(110, 140)
                    Dflp.BackColor = Color.White
                    Dflp.BorderStyle = BorderStyle.FixedSingle
                    Dflp.FlowDirection = FlowDirection.TopDown
                    Dim btn As New Button
                    Dim btnX As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.Width = 108
                    btn.Height = 90
                    If rdr.GetValue(2).ToString() <> "" Then
                        btn.BackgroundImage = Image.FromFile(Application.StartupPath & rdr.GetValue(2).ToString())
                        btn.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Text = rdr.GetValue(0)
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 1.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
                    btn.ForeColor = System.Drawing.Color.Black
                    btnX.Text = rdr.GetValue(0)
                    btnX.FlatStyle = FlatStyle.Flat
                    btnX.Width = 108
                    btnX.Height = 35
                    btnX.FlatAppearance.BorderSize = 0
                    btnX.Text = rdr.GetValue(0)
                    btnX.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    btnX.ForeColor = Color.Black
                    UserButtons.Add(btn)
                    UserButtons.Add(btnX)
                    Dflp.Controls.Add(btn)
                    Dflp.Controls.Add(btnX)
                    'flpItemsEB.Controls.Add(Dflp)
                    AddHandler btn.Click, AddressOf Me.ButtonEB1_Click
                    AddHandler btnX.Click, AddressOf Me.ButtonEB1X_Click
                Else
                    Dim btn As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.FlatStyle = FlatStyle.Popup
                    Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                    btn.BackColor = btnColor
                    btn.ForeColor = Color.White
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Width = 110
                    btn.Height = 60
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    UserButtons.Add(btn)
                    'flpItemsEB.Controls.Add(btn)
                    AddHandler btn.Click, AddressOf Me.ButtonEB1_Click
                End If
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
            'If (flpItemsEB.Controls.Count < 1) Then
            '    Dim lNofound As New Label()
            '    lNofound.Text = "No item found!"
            '    lNofound.Width = 120
            '    flpItemsEB.Controls.Add(lNofound)
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Compute()
        Try
            If txtTaxType.Text = "Inclusive" Then
                If Val(txtQty_Food.Text) = 0 Then
                    txtQty_Food.Text = 1
                End If
                If txtQty_Food.Text.Length > 5 Then
                    txtQty_Food.Text = 1
                End If
                num1 = CDbl(Val(txtRate_Food.Text) * Val(txtQty_Food.Text))
                num1 = Math.Round(num1, 2)
                txtAmt_Food.Text = num1
                num2 = CDbl((Val(txtAmt_Food.Text) * Val(txtDiscountPer_Food.Text)) / 100)
                num2 = Math.Round(num2, 2)
                txtDiscountAmount_Food.Text = num2
                num3 = CDbl(Val(txtAmt_Food.Text) - Val(txtDiscountAmount_Food.Text))
                num3 = Math.Round(num3, 2)
                txtSubTotal_Food.Text = num3
                num4 = CDbl((Val(txtSubTotal_Food.Text) * Val(txtServiceTaxPer_Food.Text)) / 100)
                num4 = Math.Round(num4, 2)
                txtServiceTaxAmount_Food.Text = 0
                num5 = num3 - (num3 / (1 + (Val(txtVATPer_Food.Text) / 100)))
                num5 = Math.Round(num5, 2)
                txtVATAmt_Food.Text = num5
                num7 = CDbl((Val(txtSubTotal_Food.Text) * Val(txtSCPer.Text)) / 100)
                num7 = Math.Round(num7, 2)
                txtSCAmount.Text = 0
                num6 = CDbl(Val(txtSubTotal_Food.Text))
                num6 = Math.Round(num6, 2)
                txtTotalAmt_Food.Text = num6
            Else
                If Val(txtQty_Food.Text) = 0 Then
                    txtQty_Food.Text = 1
                End If
                If txtQty_Food.Text.Length > 5 Then
                    txtQty_Food.Text = 1
                End If
                num1 = CDbl(Val(txtRate_Food.Text) * Val(txtQty_Food.Text))
                num1 = Math.Round(num1, 2)
                txtAmt_Food.Text = num1
                num2 = CDbl((Val(txtAmt_Food.Text) * Val(txtDiscountPer_Food.Text)) / 100)
                num2 = Math.Round(num2, 2)
                txtDiscountAmount_Food.Text = num2
                num3 = CDbl(Val(txtAmt_Food.Text) - Val(txtDiscountAmount_Food.Text))
                num3 = Math.Round(num3, 2)
                txtSubTotal_Food.Text = num3
                num4 = CDbl((Val(txtSubTotal_Food.Text) * Val(txtServiceTaxPer_Food.Text)) / 100)
                num4 = Math.Round(num4, 2)
                txtServiceTaxAmount_Food.Text = 0
                num5 = CDbl((Val(txtSubTotal_Food.Text) * Val(txtVATPer_Food.Text)) / 100)
                num5 = Math.Round(num5, 2)
                txtVATAmt_Food.Text = num5
                num7 = CDbl((Val(txtSubTotal_Food.Text) * Val(txtSCPer.Text)) / 100)
                num7 = Math.Round(num7, 2)
                txtSCAmount.Text = 0
                num6 = CDbl(Val(txtSubTotal_Food.Text) + Val(txtServiceTaxAmount_Food.Text) + Val(txtVATAmt_Food.Text) + Val(txtSCAmount.Text))
                num6 = Math.Round(num6, 2)
                txtTotalAmt_Food.Text = num6
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty <=0"
            cmd = New SqlCommand(ctX)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog9.ShowDialog()
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty < 10"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog16.ShowDialog()
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select Dish from Recipe where Dish=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1))
                End While
                con.Close()
                For Each dr As DataGridViewRow In dgw.Rows
                    Dim con As New SqlConnection(cs)
                    con.Open()
                    Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                    cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    Dim i1 As Decimal
                    If ds.Tables(0).Rows.Count > 0 Then
                        i1 = ds.Tables(0).Rows(0)("Qty")
                        If Val(dr.Cells(1).Value) > Val(i1) Then
                            frmCustomDialog13.ShowDialog()
                            Exit Sub
                        End If
                    End If
                    con.Close()
                Next
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            Dim sSQL As String = ""
            'If chkHappyHour.Checked = True Then
            '    sSQL += " IF EXISTS(SELECT distinct 1 FROM [OtherSetting] where ishappyHour = 1)"
            '    sSQL += " BEGIN"
            '    sSQL += " IF EXISTS(select distinct 1 from OtherSetting where convert(nvarchar, getdate(), 103) = convert(nvarchar, [happyHourDate], 103) and (substring(convert(nvarchar, getdate(), 20),1,16) between concat(convert(nvarchar, getdate(), 23),' ',substring(convert(nvarchar, happyHourTime_from, 20), 1,5)) and concat(convert(nvarchar, getdate(), 23),' ',substring(convert(nvarchar, happyHourTime_to, 20), 1,5))))"
            '    sSQL += " SELECT (DIRate - (DIRate * ((select distinct isnull([Discount],0) from OtherSetting)/100))) as DIRate,Category FROM Dish WHERE DishName=@d1"
            '    sSQL += " ELSE"
            '    sSQL += " SELECT DIRate,Category FROM Dish WHERE DishName=@d1"
            '    sSQL += " END"
            '    sSQL += " ELSE"
            '    sSQL += " SELECT DIRate,Category FROM Dish WHERE DishName=@d1"
            'Else
            '    sSQL += " SELECT DIRate,Category FROM Dish WHERE DishName=@d1"
            'End If
            cmd = New SqlCommand("uspGetInfohappyHour", con)
            cmd.CommandType = CommandType.StoredProcedure
            ' cmd.CommandText = "SELECT DIRate,Category FROM Dish WHERE DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", str.Trim())
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRate_Food.Text = rdr.GetValue(0)
                txtCategory_Food.Text = rdr.GetString(1)
                txtDiscountPer_Food.Text = 0.0
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT,ST,SC FROM Category WHERE CategoryName=@d1"
            cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtVATPer_Food.Text = rdr.GetValue(0)
                txtServiceTaxPer_Food.Text = rdr.GetValue(1)
                txtSCPer.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

#Region "Added by Emmanuel 04/08/2020 10:05PM Limit insufficient quantity in a gridview"
            'Dim con As New SqlConnection(cs)
            con.Open()
            Dim cmd1 As New SqlCommand("SELECT isnull(Qty,0) as Qty from Temp_Stock_Store where Dish=@d1", con)
            cmd1.Parameters.AddWithValue("@d1", str)
            Dim da1 As New SqlDataAdapter(cmd1)
            Dim ds1 As DataSet = New DataSet()
            da1.Fill(ds1)
            con.Close()
            i1 = 0
            If ds1.Tables(0).Rows.Count > 0 Then
                i1 = ds1.Tables(0).Rows(0)("Qty")
                If Val(CType(IIf(txtItemsKOT.Text = "", 1, txtItemsKOT.Text), Double) > Val(i1)) Then
                    MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. " & i1 & " of item name '" & str & "'", "Invalid provided qty", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    DataGridView1.ClearSelection()
                    Clear()
                    Exit Sub
                End If
            Else
                MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. " & i1 & " of item name '" & str & "'", "Invalid provided qty", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DataGridView1.ClearSelection()
                Clear()
                Exit Sub
            End If
#End Region

            Compute()
            DataGridView1.Rows.Add(str, Val(txtRate_Food.Text), Val(txtQty_Food.Text), Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtSCPer.Text), Val(txtSCAmount.Text), Val(txtTotalAmt_Food.Text), "", 0, txtCategory_Food.Text)
            Dim k As Double = 0
            k = GrandTotal_Food()
            k = Math.Round(k, 2)
            lblBalance.Text = k
            ItemDataSubString(str)
            CustomerDisplay(subt, Val(txtTotalAmt_Food.Text), Val(lblBalance.Text))
            Clear()
            DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(0)
            txtItemsKOT.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub Button1X_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty <=0"
            cmd = New SqlCommand(ctX)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog9.ShowDialog()
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty < 10"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog16.ShowDialog()
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select Dish from Recipe where Dish=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1))
                End While
                con.Close()
                For Each dr As DataGridViewRow In dgw.Rows
                    Dim con As New SqlConnection(cs)
                    con.Open()
                    Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                    cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    Dim i1 As Decimal
                    If ds.Tables(0).Rows.Count > 0 Then
                        i1 = ds.Tables(0).Rows(0)("Qty")
                        If Val(dr.Cells(1).Value) > Val(i1) Then
                            frmCustomDialog13.ShowDialog()
                            Exit Sub
                        End If
                    End If
                    con.Close()
                Next
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT DIRate,Category FROM Dish WHERE DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRate_Food.Text = rdr.GetValue(0)
                txtCategory_Food.Text = rdr.GetString(1)
                txtDiscountPer_Food.Text = 0.0
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT,ST,SC FROM Category WHERE CategoryName=@d1"
            cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtVATPer_Food.Text = rdr.GetValue(0)
                txtServiceTaxPer_Food.Text = rdr.GetValue(1)
                txtSCPer.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Compute()
            DataGridView1.Rows.Add(str, Val(txtRate_Food.Text), Val(txtQty_Food.Text), Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtSCPer.Text), Val(txtSCAmount.Text), Val(txtTotalAmt_Food.Text), "", 0, txtCategory_Food.Text)
            Dim k As Double = 0
            k = GrandTotal_Food()
            k = Math.Round(k, 2)
            lblBalance.Text = k
            ItemDataSubString(str)
            CustomerDisplay(subt, Val(txtTotalAmt_Food.Text), Val(lblBalance.Text))
            Clear()
            DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(0)
            txtItemsKOT.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub ItemDataSubString(ByVal st As String)
        literal = st
        If literal.Length > 12 Then
            subt = literal.Substring(0, 12)
        Else
            subt = literal
        End If
    End Sub
    Private Sub ButtonTA1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty <=0"
            cmd = New SqlCommand(ctX)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog9.ShowDialog()
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty < 10"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog16.ShowDialog()
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select Dish from Recipe where Dish=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1))
                End While
                con.Close()
                For Each dr As DataGridViewRow In dgw.Rows
                    Dim con As New SqlConnection(cs)
                    con.Open()
                    Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                    cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    Dim i1 As Decimal
                    If ds.Tables(0).Rows.Count > 0 Then
                        i1 = ds.Tables(0).Rows(0)("Qty")
                        If Val(dr.Cells(1).Value) > Val(i1) Then
                            frmCustomDialog13.ShowDialog()
                            Exit Sub
                        End If
                    End If
                    con.Close()
                Next
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT TARate,Category FROM Dish WHERE DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRate_Food.Text = rdr.GetValue(0)
                txtCategory_Food.Text = rdr.GetString(1)
                txtDiscountPer_Food.Text = 0.0
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT,ST,SC FROM Category WHERE CategoryName=@d1"
            cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtVATPer_Food.Text = rdr.GetValue(0)
                txtServiceTaxPer_Food.Text = rdr.GetValue(1)
                txtSCPer.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

#Region "Added Emmanuel 04/08/2020 10:05PM Limit insufficient quantity in a gridview"
            'Dim con As New SqlConnection(cs)
            con.Open()
            Dim cmd1 As New SqlCommand("SELECT isnull(Qty,0) as Qty from Temp_Stock_Store where Dish=@d1", con)
            cmd1.Parameters.AddWithValue("@d1", str)
            Dim da1 As New SqlDataAdapter(cmd1)
            Dim ds1 As DataSet = New DataSet()
            da1.Fill(ds1)
            con.Close()
            i1 = 0
            If ds1.Tables(0).Rows.Count > 0 Then
                i1 = ds1.Tables(0).Rows(0)("Qty")
                If Val(CType(IIf(txtItemsTA.Text = "", 1, txtItemsTA.Text), Double) > Val(i1)) Then
                    MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. " & i1 & " of item name '" & str & "'", "Invalid provided qty", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    DataGridView3.ClearSelection()
                    Clear()
                    Exit Sub
                End If
            Else
                MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. " & i1 & " of item name '" & str & "'", "Invalid provided qty", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DataGridView3.ClearSelection()
                Clear()
                Exit Sub
            End If
#End Region

            Compute()
            DataGridView3.Rows.Add(str, Val(txtRate_Food.Text), Val(txtQty_Food.Text), Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtSCPer.Text), Val(txtSCAmount.Text), Val(txtTotalAmt_Food.Text), "", Val(txtDiscountPer_Food.Text), txtCategory_Food.Text)
            Dim k As Double = 0
            k = GrandTotal_Food2()
            k = Math.Round(k, 2)
            lblBalance1.Text = k
            txtSubTotal1.Text = Val(lblBalance1.Text)
            Calc1()
            fillCurrencyTA()
            ItemDataSubString(str)
            CustomerDisplay(subt, Val(txtTotalAmt_Food.Text), Val(txtGrandTotal1.Text))
            Clear()
            DataGridView3.CurrentCell = DataGridView3.Rows(DataGridView3.Rows.Count - 1).Cells(0)
            txtItemsTA.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub ButtonTA1X_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty <=0"
            cmd = New SqlCommand(ctX)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog9.ShowDialog()
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty < 10"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog16.ShowDialog()
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select Dish from Recipe where Dish=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1))
                End While
                con.Close()
                For Each dr As DataGridViewRow In dgw.Rows
                    Dim con As New SqlConnection(cs)
                    con.Open()
                    Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                    cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    Dim i1 As Decimal
                    If ds.Tables(0).Rows.Count > 0 Then
                        i1 = ds.Tables(0).Rows(0)("Qty")
                        If Val(dr.Cells(1).Value) > Val(i1) Then
                            frmCustomDialog13.ShowDialog()
                            Exit Sub
                        End If
                    End If
                    con.Close()
                Next
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT TARate,Category FROM Dish WHERE DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRate_Food.Text = rdr.GetValue(0)
                txtCategory_Food.Text = rdr.GetString(1)
                txtDiscountPer_Food.Text = 0.0
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT,ST,SC FROM Category WHERE CategoryName=@d1"
            cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtVATPer_Food.Text = rdr.GetValue(0)
                txtServiceTaxPer_Food.Text = rdr.GetValue(1)
                txtSCPer.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Compute()
            DataGridView3.Rows.Add(str, Val(txtRate_Food.Text), Val(txtQty_Food.Text), Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtSCPer.Text), Val(txtSCAmount.Text), Val(txtTotalAmt_Food.Text), "", Val(txtDiscountPer_Food.Text), txtCategory_Food.Text)
            Dim k As Double = 0
            k = GrandTotal_Food2()
            k = Math.Round(k, 2)
            lblBalance1.Text = k
            txtSubTotal1.Text = Val(lblBalance1.Text)
            Calc1()
            fillCurrencyTA()
            ItemDataSubString(str)
            CustomerDisplay(subt, Val(txtTotalAmt_Food.Text), Val(txtGrandTotal1.Text))
            Clear()
            DataGridView3.CurrentCell = DataGridView3.Rows(DataGridView3.Rows.Count - 1).Cells(0)
            txtItemsTA.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub ButtonHD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty <=0"
            cmd = New SqlCommand(ctX)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog9.ShowDialog()
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty < 10"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog16.ShowDialog()
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select Dish from Recipe where Dish=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1))
                End While
                con.Close()
                For Each dr As DataGridViewRow In dgw.Rows
                    Dim con As New SqlConnection(cs)
                    con.Open()
                    Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                    cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    Dim i1 As Decimal
                    If ds.Tables(0).Rows.Count > 0 Then
                        i1 = ds.Tables(0).Rows(0)("Qty")
                        If Val(dr.Cells(1).Value) > Val(i1) Then
                            frmCustomDialog13.ShowDialog()
                            Exit Sub
                        End If
                    End If
                    con.Close()
                Next
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT HDRate,Category FROM Dish WHERE DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRate_Food.Text = rdr.GetValue(0)
                txtCategory_Food.Text = rdr.GetString(1)
                txtDiscountPer_Food.Text = 0.0
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT,ST,SC FROM Category WHERE CategoryName=@d1"
            cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtVATPer_Food.Text = rdr.GetValue(0)
                txtServiceTaxPer_Food.Text = rdr.GetValue(1)
                txtSCPer.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

#Region "Added Emmanuel 04/08/2020 10:05PM Limit insufficient quantity in a gridview"
            'Dim con As New SqlConnection(cs)
            con.Open()
            Dim cmd1 As New SqlCommand("SELECT isnull(Qty,0) as Qty from Temp_Stock_Store where Dish=@d1", con)
            cmd1.Parameters.AddWithValue("@d1", str)
            Dim da1 As New SqlDataAdapter(cmd1)
            Dim ds1 As DataSet = New DataSet()
            da1.Fill(ds1)
            con.Close()
            i1 = 0
            If ds1.Tables(0).Rows.Count > 0 Then
                i1 = ds1.Tables(0).Rows(0)("Qty")
                If Val(CType(IIf(txtItemsHD.Text = "", 1, txtItemsHD.Text), Double) > Val(i1)) Then
                    MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. " & i1 & " of item name '" & str & "'", "Invalid provided qty", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    DataGridView4.ClearSelection()
                    Clear()
                    Exit Sub
                End If
            Else
                MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. " & i1 & " of item name '" & str & "'", "Invalid provided qty", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DataGridView4.ClearSelection()
                Clear()
                Exit Sub
            End If
#End Region

            Compute()
            DataGridView4.Rows.Add(str, Val(txtRate_Food.Text), Val(txtQty_Food.Text), Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtSCPer.Text), Val(txtSCAmount.Text), Val(txtTotalAmt_Food.Text), "", Val(txtDiscountPer_Food.Text), txtCategory_Food.Text)
            Dim k As Double = 0
            k = GrandTotal_Food3()
            k = Math.Round(k, 2)
            lblBalance2.Text = k
            txtSubTotal.Text = Val(lblBalance2.Text)
            Calc2()
            ItemDataSubString(str)
            CustomerDisplay(subt, Val(txtTotalAmt_Food.Text), Val(txtGrandTotal2.Text))
            Clear()
            DataGridView4.CurrentCell = DataGridView4.Rows(DataGridView4.Rows.Count - 1).Cells(0)
            txtItemsHD.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub ButtonHD1X_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty <=0"
            cmd = New SqlCommand(ctX)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog9.ShowDialog()
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty < 10"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog16.ShowDialog()
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select Dish from Recipe where Dish=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1))
                End While
                con.Close()
                For Each dr As DataGridViewRow In dgw.Rows
                    Dim con As New SqlConnection(cs)
                    con.Open()
                    Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                    cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    Dim i1 As Decimal
                    If ds.Tables(0).Rows.Count > 0 Then
                        i1 = ds.Tables(0).Rows(0)("Qty")
                        If Val(dr.Cells(1).Value) > Val(i1) Then
                            frmCustomDialog13.ShowDialog()
                            Exit Sub
                        End If
                    End If
                    con.Close()
                Next
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT HDRate,Category FROM Dish WHERE DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRate_Food.Text = rdr.GetValue(0)
                txtCategory_Food.Text = rdr.GetString(1)
                txtDiscountPer_Food.Text = 0.0
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT,ST,SC FROM Category WHERE CategoryName=@d1"
            cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtVATPer_Food.Text = rdr.GetValue(0)
                txtServiceTaxPer_Food.Text = rdr.GetValue(1)
                txtSCPer.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Compute()
            DataGridView4.Rows.Add(str, Val(txtRate_Food.Text), Val(txtQty_Food.Text), Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtSCPer.Text), Val(txtSCAmount.Text), Val(txtTotalAmt_Food.Text), "", Val(txtDiscountPer_Food.Text), txtCategory_Food.Text)
            Dim k As Double = 0
            k = GrandTotal_Food3()
            k = Math.Round(k, 2)
            lblBalance2.Text = k
            txtSubTotal.Text = Val(lblBalance2.Text)
            Calc2()
            ItemDataSubString(str)
            CustomerDisplay(subt, Val(txtTotalAmt_Food.Text), Val(txtGrandTotal2.Text))
            Clear()
            DataGridView4.CurrentCell = DataGridView4.Rows(DataGridView4.Rows.Count - 1).Cells(0)
            txtItemsHD.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub ButtonEB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty <=0"
            cmd = New SqlCommand(ctX)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog9.ShowDialog()
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty < 10"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog16.ShowDialog()
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select Dish from Recipe where Dish=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1))
                End While
                con.Close()
                For Each dr As DataGridViewRow In dgw.Rows
                    Dim con As New SqlConnection(cs)
                    con.Open()
                    Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                    cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    Dim i1 As Decimal
                    If ds.Tables(0).Rows.Count > 0 Then
                        i1 = ds.Tables(0).Rows(0)("Qty")
                        If Val(dr.Cells(1).Value) > Val(i1) Then
                            frmCustomDialog13.ShowDialog()
                            Exit Sub
                        End If
                    End If
                    con.Close()
                Next
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT DIRate,Category FROM Dish WHERE DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRate_Food.Text = rdr.GetValue(0)
                txtCategory_Food.Text = rdr.GetString(1)
                txtDiscountPer_Food.Text = 0.0
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT,ST,SC FROM Category WHERE CategoryName=@d1"
            cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtVATPer_Food.Text = rdr.GetValue(0)
                txtServiceTaxPer_Food.Text = rdr.GetValue(1)
                txtSCPer.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

#Region "Added Emmanuel 04/08/2020 10:05PM Limit insufficient quantity in a gridview"
            'Dim con As New SqlConnection(cs)
            con.Open()
            Dim cmd1 As New SqlCommand("SELECT isnull(Qty,0) as Qty from Temp_Stock_Store where Dish=@d1", con)
            cmd1.Parameters.AddWithValue("@d1", str)
            Dim da1 As New SqlDataAdapter(cmd1)
            Dim ds1 As DataSet = New DataSet()
            da1.Fill(ds1)
            con.Close()
            i1 = 0
            If ds1.Tables(0).Rows.Count > 0 Then
                i1 = ds1.Tables(0).Rows(0)("Qty")
                'If Val(CType(IIf(txtItemsEB.Text = "", 1, txtItemsEB.Text), Double) > Val(i1)) Then
                '    MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. " & i1 & " of item name '" & str & "'", "Invalid provided qty", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    DataGridView5.ClearSelection()
                '    Clear()
                '    Exit Sub
                'End If
            Else
                MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. " & i1 & " of item name '" & str & "'", "Invalid provided qty", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'DataGridView5.ClearSelection()
                Clear()
                Exit Sub
            End If
#End Region

            Compute()
            'DataGridView5.Rows.Add(str, Val(txtRate_Food.Text), Val(txtQty_Food.Text), Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtSCPer.Text), Val(txtSCAmount.Text), Val(txtTotalAmt_Food.Text), "", Val(txtDiscountPer_Food.Text), txtCategory_Food.Text)
            Dim k As Double = 0
            k = GrandTotal_Food4()
            k = Math.Round(k, 2)
            'lblBalance3.Text = k
            'txtGrandTotal3.Text = Val(lblBalance3.Text)
            Calc3()
            fillCurrencyEB()
            ItemDataSubString(str)
            'CustomerDisplay(subt, Val(txtTotalAmt_Food.Text), Val(txtGrandTotal3.Text))
            Clear()
            'DataGridView5.CurrentCell = DataGridView5.Rows(DataGridView5.Rows.Count - 1).Cells(0)
            'txtItemsEB.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub ButtonEB1X_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty <=0"
            cmd = New SqlCommand(ctX)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog9.ShowDialog()
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty < 10"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                frmCustomDialog16.ShowDialog()
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select Dish from Recipe where Dish=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If (rdr.Read()) Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1))
                End While
                con.Close()
                For Each dr As DataGridViewRow In dgw.Rows
                    Dim con As New SqlConnection(cs)
                    con.Open()
                    Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                    cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    da.Fill(ds)
                    Dim i1 As Decimal
                    If ds.Tables(0).Rows.Count > 0 Then
                        i1 = ds.Tables(0).Rows(0)("Qty")
                        If Val(dr.Cells(1).Value) > Val(i1) Then
                            frmCustomDialog13.ShowDialog()
                            Exit Sub
                        End If
                    End If
                    con.Close()
                Next
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT DIRate,Category FROM Dish WHERE DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", str)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRate_Food.Text = rdr.GetValue(0)
                txtCategory_Food.Text = rdr.GetString(1)
                txtDiscountPer_Food.Text = 0.0
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT,ST,SC FROM Category WHERE CategoryName=@d1"
            cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtVATPer_Food.Text = rdr.GetValue(0)
                txtServiceTaxPer_Food.Text = rdr.GetValue(1)
                txtSCPer.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Compute()
            'DataGridView5.Rows.Add(str, Val(txtRate_Food.Text), Val(txtQty_Food.Text), Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtSCPer.Text), Val(txtSCAmount.Text), Val(txtTotalAmt_Food.Text), "", Val(txtDiscountPer_Food.Text), txtCategory_Food.Text)
            Dim k As Double = 0
            k = GrandTotal_Food4()
            k = Math.Round(k, 2)
            'lblBalance3.Text = k
            'txtGrandTotal3.Text = Val(lblBalance3.Text)
            Calc3()
            fillCurrencyEB()
            ItemDataSubString(str)
            'CustomerDisplay(subt, Val(txtTotalAmt_Food.Text), Val(txtGrandTotal3.Text))
            Clear()
            'DataGridView5.CurrentCell = DataGridView5.Rows(DataGridView5.Rows.Count - 1).Cells(0)
            'txtItemsEB.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            lblTableNo.Text = ""
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text.Trim()
            Dim strText() As String
            strText = Split(str, vbCrLf)
            lblTableNo.Text = strText(0)
            cmbGroup.Enabled = True
            FillGroup()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub Clear()
        txtFoodName.Text = ""
        txtRate_Food.Text = ""
        txtQty_Food.Text = 1
        txtAmt_Food.Text = ""
        txtServiceTaxAmount_Food.Text = ""
        txtServiceTaxPer_Food.Text = ""
        txtDiscountAmount_Food.Text = ""
        txtDiscountPer_Food.Text = ""
        txtVATAmt_Food.Text = ""
        txtVATPer_Food.Text = ""
        txtTotalAmt_Food.Text = ""
        btnMinus.Enabled = False
        btnPlus.Enabled = False
        btnCancel.Enabled = False
        btnChangeRate.Enabled = False
        btnModifier.Enabled = False
        btnChangeQty.Enabled = False
        DataGridView1.ClearSelection()
    End Sub
    Sub Clear2()
        txtFoodName.Text = ""
        txtRate_Food.Text = ""
        txtQty_Food.Text = 1
        txtAmt_Food.Text = ""
        txtServiceTaxAmount_Food.Text = ""
        txtServiceTaxPer_Food.Text = ""
        txtDiscountAmount_Food.Text = ""
        txtDiscountPer_Food.Text = ""
        txtVATAmt_Food.Text = ""
        txtVATPer_Food.Text = ""
        txtTotalAmt_Food.Text = ""
        btnMinus1.Enabled = False
        btnPlus1.Enabled = False
        btnCancel1.Enabled = False
        btnChangeRate1.Enabled = False
        btnChangeQty1.Enabled = False
        btnModifiers1.Enabled = False
        DataGridView3.ClearSelection()
    End Sub
    Sub Clear3()
        txtFoodName.Text = ""
        txtRate_Food.Text = ""
        txtQty_Food.Text = 1
        txtAmt_Food.Text = ""
        txtServiceTaxAmount_Food.Text = ""
        txtServiceTaxPer_Food.Text = ""
        txtDiscountAmount_Food.Text = ""
        txtDiscountPer_Food.Text = ""
        txtVATAmt_Food.Text = ""
        txtVATPer_Food.Text = ""
        txtTotalAmt_Food.Text = ""
        btnMinus2.Enabled = False
        btnPlus2.Enabled = False
        btnCancel2.Enabled = False
        btnChangeRate2.Enabled = False
        btnChangeQty2.Enabled = False
        btnModifiers2.Enabled = False
        DataGridView4.ClearSelection()
    End Sub

    Sub Clear4()
        txtFoodName.Text = ""
        txtRate_Food.Text = ""
        txtQty_Food.Text = 1
        txtAmt_Food.Text = ""
        txtServiceTaxAmount_Food.Text = ""
        txtServiceTaxPer_Food.Text = ""
        txtDiscountAmount_Food.Text = ""
        txtDiscountPer_Food.Text = ""
        txtVATAmt_Food.Text = ""
        txtVATPer_Food.Text = ""
        txtTotalAmt_Food.Text = ""
        'btnMinus3.Enabled = False
        'btnPlus3.Enabled = False
        'btnCancel3.Enabled = False
        'btnChangeRate3.Enabled = False
        'btnChangeQty3.Enabled = False
        'btnModifiers3.Enabled = False
        'DataGridView5.ClearSelection()
    End Sub
    Sub Clear1()
        txtFoodName.Text = ""
        txtRate_Food.Text = ""
        txtQty_Food.Text = 1
        txtAmt_Food.Text = ""
        txtServiceTaxAmount_Food.Text = ""
        txtServiceTaxPer_Food.Text = ""
        txtDiscountAmount_Food.Text = ""
        txtDiscountPer_Food.Text = ""
        txtVATAmt_Food.Text = ""
        txtVATPer_Food.Text = ""
        txtTotalAmt_Food.Text = ""
        txtSCAmount.Text = ""
        txtSCPer.Text = ""
        txtTempDiscountPer.Text = ""
    End Sub
    Public Function GrandTotal_Food() As Double
        Dim sum As Double = 0
        Try
            If DataGridView1.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView1.Rows
                    sum = sum + r.Cells(12).Value
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function GrandTotal_Food2() As Double
        Dim sum As Double = 0
        Try
            If DataGridView3.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView3.Rows
                    sum = sum + r.Cells(12).Value
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function GrandTotal_Food3() As Double
        Dim sum As Double = 0
        Try
            If DataGridView4.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView4.Rows
                    sum = sum + r.Cells(12).Value
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function GrandTotal_Food4() As Double
        Dim sum As Double = 0
        Try
            'If DataGridView5.Rows.Count > 0 Then
            '    For Each r As DataGridViewRow In Me.DataGridView5.Rows
            '        sum = sum + r.Cells(12).Value
            '    Next
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Private Sub DataGridView1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If DataGridView1.Rows.Count > 0 Then
            If lblSet.Text = "Not Allowed" Then
                btnPlus.Enabled = False
                btnCancel.Enabled = False
                btnChangeRate.Enabled = False
                btnChangeQty.Enabled = False
                btnMinus.Enabled = False
                btnModifier.Enabled = False
            Else
                For Each row As DataGridViewRow In DataGridView1.SelectedRows
                    btnPlus.Enabled = True
                    btnCancel.Enabled = True
                    btnNotes.Enabled = True
                    btnChangeRate.Enabled = True
                    btnChangeQty.Enabled = True
                    If row.Cells(2).Value > 1 Then
                        btnMinus.Enabled = True
                    End If
                    btnModifier.Enabled = True
                Next
            End If
        End If
    End Sub

    Private Sub btnPlus_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus.Click
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.SelectedRows
                FillData()
                Compute()
                r.Cells(0).Value = r.Cells(0).Value
                r.Cells(1).Value = txtRate_Food.Text
                r.Cells(2).Value = Val(r.Cells(2).Value) + 1
                r.Cells(3).Value = Val(r.Cells(3).Value) + Val(txtAmt_Food.Text)
                r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
                r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtDiscountAmount_Food.Text)
                r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
                r.Cells(7).Value = Val(r.Cells(7).Value) + Val(txtServiceTaxAmount_Food.Text)
                r.Cells(8).Value = Val(txtVATPer_Food.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtVATAmt_Food.Text)
                r.Cells(10).Value = Val(txtSCPer.Text)
                r.Cells(11).Value = Val(r.Cells(11).Value) + Val(txtSCAmount.Text)
                r.Cells(12).Value = Val(r.Cells(12).Value) + Val(txtTotalAmt_Food.Text)
                Dim i As Double = 0
                i = GrandTotal_Food()
                i = Math.Round(i, 2)
                lblBalance.Text = i
                ItemDataSubString(r.Cells(0).Value.ToString())
                CustomerDisplay(subt, Val(r.Cells(12).Value), Val(lblBalance.Text))
                Clear1()
                If r.Cells(2).Value > 1 Then
                    btnMinus.Enabled = True
                Else
                    btnMinus.Enabled = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = GrandTotal_Food()
            k = Math.Round(k, 2)
            lblBalance.Text = k
            Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnMinus_Click(sender As System.Object, e As System.EventArgs) Handles btnMinus.Click
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.SelectedRows
                FillData()
                If r.Cells(2).Value = 1 Then
                    btnMinus.Enabled = False
                    Exit Sub
                End If
                Compute()
                r.Cells(0).Value = r.Cells(0).Value
                r.Cells(1).Value = txtRate_Food.Text
                r.Cells(2).Value = Val(r.Cells(2).Value) - 1
                r.Cells(3).Value = Val(r.Cells(3).Value) - Val(txtAmt_Food.Text)
                r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
                r.Cells(5).Value = Val(r.Cells(5).Value) - Val(txtDiscountAmount_Food.Text)
                r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
                r.Cells(7).Value = Val(r.Cells(7).Value) - Val(txtServiceTaxAmount_Food.Text)
                r.Cells(8).Value = Val(txtVATPer_Food.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) - Val(txtVATAmt_Food.Text)
                r.Cells(10).Value = Val(txtSCPer.Text)
                r.Cells(11).Value = Val(r.Cells(11).Value) - Val(txtSCAmount.Text)
                r.Cells(12).Value = Val(r.Cells(12).Value) - Val(txtTotalAmt_Food.Text)
                Dim i As Double = 0
                i = GrandTotal_Food()
                i = Math.Round(i, 2)
                lblBalance.Text = i
                ItemDataSubString(r.Cells(0).Value.ToString())
                CustomerDisplay(subt, Val(r.Cells(12).Value), Val(lblBalance.Text))
                Clear1()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 ID FROM RestaurantPOS_OrderInfoKOT ORDER BY ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ID")
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
            txtTicketID.Text = GenerateID()
            lblTicketNo.Text = "KOT-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnChangeRate_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeRate.Click
        Try
            frmChangeRate.lblSet.Text = "KOT"
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                frmChangeRate.txtNotes.Text = dr.Cells(13).Value
                frmChangeRate.txtR.Text = dr.Cells(14).Value
                frmChangeRate.txtCategory.Text = dr.Cells(15).Value
            End If
            frmChangeRate.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub FillData()
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                txtFoodName.Text = dr.Cells(0).Value.ToString()
                txtRate_Food.Text = dr.Cells(1).Value.ToString
                txtQty_Food.Text = 1
                txtAmt_Food.Text = dr.Cells(3).Value.ToString()
                txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
                txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
                txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
                txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
                txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
                txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
                txtSCPer.Text = dr.Cells(10).Value.ToString()
                txtSCAmount.Text = dr.Cells(11).Value.ToString()
                txtTotalAmt_Food.Text = dr.Cells(12).Value.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillData1()
        Try
            If DataGridView3.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
                txtFoodName.Text = dr.Cells(0).Value.ToString()
                txtRate_Food.Text = dr.Cells(1).Value.ToString
                txtQty_Food.Text = 1
                txtAmt_Food.Text = dr.Cells(3).Value.ToString()
                txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
                txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
                txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
                txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
                txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
                txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
                txtSCPer.Text = dr.Cells(10).Value.ToString()
                txtSCAmount.Text = dr.Cells(11).Value.ToString()
                txtTotalAmt_Food.Text = dr.Cells(12).Value.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillData2()
        Try
            If DataGridView4.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView4.SelectedRows(0)
                txtFoodName.Text = dr.Cells(0).Value.ToString()
                txtRate_Food.Text = dr.Cells(1).Value.ToString
                txtQty_Food.Text = 1
                txtAmt_Food.Text = dr.Cells(3).Value.ToString()
                txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
                txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
                txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
                txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
                txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
                txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
                txtSCPer.Text = dr.Cells(10).Value.ToString()
                txtSCAmount.Text = dr.Cells(11).Value.ToString()
                txtTotalAmt_Food.Text = dr.Cells(12).Value.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillData3()
        Try
            'If DataGridView5.Rows.Count > 0 Then
            '    Dim dr As DataGridViewRow = DataGridView5.SelectedRows(0)
            '    txtFoodName.Text = dr.Cells(0).Value.ToString()
            '    txtRate_Food.Text = dr.Cells(1).Value.ToString
            '    txtQty_Food.Text = 1
            '    txtAmt_Food.Text = dr.Cells(3).Value.ToString()
            '    txtDiscountPer_Food.Text = dr.Cells(4).Value.ToString()
            '    txtDiscountAmount_Food.Text = dr.Cells(5).Value.ToString()
            '    txtServiceTaxPer_Food.Text = dr.Cells(6).Value.ToString()
            '    txtServiceTaxAmount_Food.Text = dr.Cells(7).Value.ToString()
            '    txtVATPer_Food.Text = dr.Cells(8).Value.ToString()
            '    txtVATAmt_Food.Text = dr.Cells(9).Value.ToString()
            '    txtSCPer.Text = dr.Cells(10).Value.ToString()
            '    txtSCAmount.Text = dr.Cells(11).Value.ToString()
            '    txtTotalAmt_Food.Text = dr.Cells(12).Value.ToString()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtTotalAmt_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotalAmt_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtDiscountAmount_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscountAmount_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtServiceTaxPer_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtServiceTaxPer_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtVATAmt_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVATAmt_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtVATPer_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVATPer_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtServiceTaxAmount_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtServiceTaxAmount_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtDiscountPer_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscountPer_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtAmt_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAmt_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtQty_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQty_Food.TextChanged
        Compute()
    End Sub

    Private Sub txtRate_Food_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRate_Food.TextChanged
        Compute()
    End Sub

    Sub Settle()
        Try
            If DataGridView1.Rows.Count > 0 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into PosGrouping1 VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                        cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value))
                        cmd.Parameters.AddWithValue("@d13", Val(row.Cells(12).Value))
                        If row.Cells(13).Value = "" Then
                            cmd.Parameters.AddWithValue("@d14", "")
                        Else
                            cmd.Parameters.AddWithValue("@d14", row.Cells(13).Value)
                        End If
                        cmd.Parameters.AddWithValue("@d15", Val(row.Cells(14).Value))
                        If row.Cells(15).Value = "" Then
                            cmd.Parameters.AddWithValue("@d16", "")
                        Else
                            cmd.Parameters.AddWithValue("@d16", row.Cells(15).Value)
                        End If
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT RTRIM(Col1),Col2,Sum(Col3),SUM(Col4),(Col5),Sum(Col6),(Col7),Sum(Col8),(Col9),Sum(Col10),Col11,sum(Col12),Sum(Col13),Col14,Col15,Col16 from PosGrouping1 group by Col1,Col2,Col5,Col7,Col9,Col11,col14,Col15,Col16 order by Col1", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView1.Rows.Clear()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                While (rdr.Read() = True)
                    DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
                End While
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb2 As String = "delete from PosGrouping1"
                cmd = New SqlCommand(cb2)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                DataGridView1.ClearSelection()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Settle1()
        Try
            If DataGridView3.Rows.Count > 0 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into PosGrouping VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView3.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                        cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value))
                        cmd.Parameters.AddWithValue("@d13", Val(row.Cells(12).Value))
                        If row.Cells(13).Value = "" Then
                            cmd.Parameters.AddWithValue("@d14", "")
                        Else
                            cmd.Parameters.AddWithValue("@d14", row.Cells(13).Value)
                        End If
                        cmd.Parameters.AddWithValue("@d15", Val(row.Cells(14).Value))
                        If row.Cells(15).Value = "" Then
                            cmd.Parameters.AddWithValue("@d16", "")
                        Else
                            cmd.Parameters.AddWithValue("@d16", row.Cells(15).Value)
                        End If
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT RTRIM(Col1),Col2,Sum(Col3),SUM(Col4),(Col5),Sum(Col6),(Col7),Sum(Col8),(Col9),Sum(Col10),Col11,sum(Col12),Sum(Col13),Col14,Col15,Col16 from PosGrouping group by Col1,Col2,Col5,Col7,Col9,Col11,col14,Col15,Col16 order by Col1", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView3.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView3.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
                End While
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb2 As String = "delete from PosGrouping"
                cmd = New SqlCommand(cb2)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                DataGridView3.ClearSelection()
                DataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Settle2()
        Try
            If DataGridView4.Rows.Count > 0 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into PosGrouping VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView4.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                        cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value))
                        cmd.Parameters.AddWithValue("@d13", Val(row.Cells(12).Value))
                        If row.Cells(13).Value = "" Then
                            cmd.Parameters.AddWithValue("@d14", "")
                        Else
                            cmd.Parameters.AddWithValue("@d14", row.Cells(13).Value)
                        End If
                        cmd.Parameters.AddWithValue("@d15", Val(row.Cells(14).Value))
                        If row.Cells(15).Value = "" Then
                            cmd.Parameters.AddWithValue("@d16", "")
                        Else
                            cmd.Parameters.AddWithValue("@d16", row.Cells(15).Value)
                        End If
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT RTRIM(Col1),Col2,Sum(Col3),SUM(Col4),(Col5),Sum(Col6),(Col7),Sum(Col8),(Col9),Sum(Col10),Col11,sum(Col12),Sum(Col13),Col14,Col15,Col16 from PosGrouping group by Col1,Col2,Col5,Col7,Col9,Col11,col14,Col15,Col16 order by Col1", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView4.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView4.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
                End While
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb2 As String = "delete from PosGrouping"
                cmd = New SqlCommand(cb2)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                DataGridView4.ClearSelection()
                DataGridView4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Settle3()
        Try
            'If DataGridView5.Rows.Count > 0 Then
            '    con = New SqlConnection(cs)
            '    con.Open()
            '    Dim cb1 As String = "insert into PosGrouping VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
            '    cmd = New SqlCommand(cb1)
            '    cmd.Connection = con
            '    ' Prepare command for repeated execution
            '    cmd.Prepare()
            '    ' Data to be inserted
            '    For Each row As DataGridViewRow In DataGridView5.Rows
            '        If Not row.IsNewRow Then
            '            cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
            '            cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
            '            cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
            '            cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
            '            cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
            '            cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
            '            cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
            '            cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
            '            cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
            '            cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
            '            cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
            '            cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value))
            '            cmd.Parameters.AddWithValue("@d13", Val(row.Cells(12).Value))
            '            If row.Cells(13).Value = "" Then
            '                cmd.Parameters.AddWithValue("@d14", "")
            '            Else
            '                cmd.Parameters.AddWithValue("@d14", row.Cells(13).Value)
            '            End If
            '            cmd.Parameters.AddWithValue("@d15", Val(row.Cells(14).Value))
            '            If row.Cells(15).Value = "" Then
            '                cmd.Parameters.AddWithValue("@d16", "")
            '            Else
            '                cmd.Parameters.AddWithValue("@d16", row.Cells(15).Value)
            '            End If
            '            cmd.ExecuteNonQuery()
            '            cmd.Parameters.Clear()
            '        End If
            '    Next
            '    con.Close()
            '    con = New SqlConnection(cs)
            '    con.Open()
            '    cmd = New SqlCommand("SELECT RTRIM(Col1),Col2,Sum(Col3),SUM(Col4),(Col5),Sum(Col6),(Col7),Sum(Col8),(Col9),Sum(Col10),Col11,sum(Col12),Sum(Col13),Col14,Col15,Col16 from PosGrouping group by Col1,Col2,Col5,Col7,Col9,Col11,col14,col15,col16 order by Col1", con)
            '    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            '    DataGridView5.Rows.Clear()
            '    While (rdr.Read() = True)
            '        DataGridView5.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
            '    End While
            '    con.Close()
            '    con = New SqlConnection(cs)
            '    con.Open()
            '    Dim cb2 As String = "delete from PosGrouping"
            '    cmd = New SqlCommand(cb2)
            '    cmd.Connection = con
            '    cmd.ExecuteNonQuery()
            '    con.Close()
            '    DataGridView5.ClearSelection()
            '    DataGridView5.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSettle_Click(sender As System.Object, e As System.EventArgs) Handles btnSettle.Click
        Try
            If lblTableNo.Text = "" Then
                MessageBox.Show("Please select table", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Settle()
            flpCategoriesKOT.Enabled = False
            flpItemsKOT.Enabled = False
            lblSet.Text = "Not Allowed"
            DataGridView1.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If cmbSection.SelectedIndex = 1 Then
                If lblTableNo.Text = "" Then
                    frmCustomDialog6.ShowDialog()
                    Exit Sub
                End If
            End If
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Dim totals As New Dictionary(Of String, Integer)()
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim str As String = DataGridView1.Rows(i).Cells(0).Value
                Dim strText() As String
                strText = Split(str, vbCrLf)
                Dim group As String = strText(0)
                Dim qty As Integer = Convert.ToInt32(DataGridView1.Rows(i).Cells(2).Value)
                If totals.ContainsKey(group) = False Then
                    totals.Add(group, qty)
                Else
                    totals(group) += qty
                End If
            Next
            For Each group As String In totals.Keys
                i2 = totals(group)

                Dim con As New SqlConnection(cs)
                con.Open()
                Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_Store where Dish=@d1", con)
                cmd.Parameters.AddWithValue("@d1", group)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()
                da.Fill(ds)
                con.Close()
                If ds.Tables(0).Rows.Count > 0 Then
                    i1 = ds.Tables(0).Rows(0)("Qty")
                    If Val(i2) > Val(i1) Then
                        MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. " & i1 & " of item name '" & group & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        DataGridView1.ClearSelection()
                        Clear()
                        Exit Sub
                    End If
                End If
            Next

            For Each row As DataGridViewRow In DataGridView1.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Dish from Recipe where Dish=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        dgw.Rows.Add(rdr(0), rdr(1))
                    End While
                    con.Close()
                    For Each dr As DataGridViewRow In dgw.Rows
                        Dim con As New SqlConnection(cs)
                        con.Open()
                        Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                        cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                        Dim da As New SqlDataAdapter(cmd)
                        Dim ds As DataSet = New DataSet()
                        da.Fill(ds)
                        Dim i1 As Decimal
                        Dim i2 As Integer
                        If DataGridView1.Rows.Count > 1 Then
                            For i = 0 To DataGridView1.RowCount - 2
                                For t = i + 1 To DataGridView1.RowCount - 1
                                    If DataGridView1.Rows(i).Cells(0).Value = DataGridView1.Rows(t).Cells(0).Value Then
                                        i2 += row.Cells(2).Value
                                    End If
                                Next
                            Next
                        Else
                            i2 = row.Cells(2).Value
                        End If
                        If ds.Tables(0).Rows.Count > 0 Then
                            i1 = ds.Tables(0).Rows(0)("Qty")
                            If Val(dr.Cells(1).Value) * Val(i2) > Val(i1) Then
                                MessageBox.Show("Raw Materials are not available to prepare recipe in the kitchen/section for added quantities of item name '" & row.Cells(0).Value & "' in the grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                DataGridView1.ClearSelection()
                                Clear()
                                Exit Sub
                            End If
                        End If
                        con.Close()
                    Next
                End If
            Next
            Settle()
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim str As String = row.Cells(0).Value.ToString()
                Dim strText() As String
                strText = Split(str, vbCrLf)
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Dish from temp_Stock_Store where Dish=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", strText(0))
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty - " & Val(row.Cells(2).Value) & " where Dish=@d1"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    cmd.ExecuteReader()
                    con.Close()
                    'retrieving.SoldStock(CType(row.Cells(2).Value, Decimal), row.Cells(0).Value.ToString())
                End If
            Next
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim str As String = row.Cells(0).Value.ToString()
                Dim strText() As String
                strText = Split(str, vbCrLf)
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Dish from Recipe where Dish=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", strText(0))
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        dgw.Rows.Add(rdr(0), rdr(1))
                    End While
                    con.Close()
                    RM_ID()
                    RawMaterialUsed(Val(txtRM_ID.Text), lblTicketNo.Text)
                    For Each dr As DataGridViewRow In dgw.Rows
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock_RM set Qty=Qty - " & Val(dr.Cells(1).Value) * Val(row.Cells(2).Value) & " where ProductID=@d1"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    Next
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb3 As String = "insert into RM_Used_Join(RawMaterialID,ProductID,Quantity) VALUES (" & Val(txtRM_ID.Text) & ",@d1,@d2)"
                    cmd = New SqlCommand(cb3)
                    cmd.Connection = con
                    ' Prepare command for repeated execution
                    cmd.Prepare()
                    ' Data to be inserted
                    For Each dr1 As DataGridViewRow In dgw.Rows
                        If Not row.IsNewRow Then
                            cmd.Parameters.AddWithValue("@d1", Val(dr1.Cells(0).Value))
                            cmd.Parameters.AddWithValue("@d2", Val(dr1.Cells(1).Value) * Val(row.Cells(2).Value))
                            cmd.ExecuteNonQuery()
                            cmd.Parameters.Clear()
                        End If
                    Next
                End If
            Next
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into RestaurantPOS_OrderInfoKOT( Id,TicketNo, BillDate, GrandTotal,tableNo,Operator,GroupName,TicketNote,KOT_Status) Values (" & txtTicketID.Text & ",@d6,@d2," & Val(lblBalance.Text) & ",@d1,@d3,@d4,@d5,'Open')"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", IIf(lblTableNo.Text = "", DateTime.Now.Ticks.ToString().Substring(5, 13), lblTableNo.Text))
            cmd.Parameters.AddWithValue("@d2", System.DateTime.Now)
            cmd.Parameters.AddWithValue("@d3", lblUserVAL.Text)
            cmd.Parameters.AddWithValue("@d4", cmbGroup.Text)
            cmd.Parameters.AddWithValue("@d5", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d6", lblTicketNo.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            ' Prepare command for repeated execution
            'cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim bl As Boolean = Retrieving.isHappyHour()
                Dim cb1 As String = "insert into RestaurantPOS_OrderedProductKOT(TicketID,Dish,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,SCPer,SCAmount,TotalAmount,Notes,Category,T_Number,isHappyHour) VALUES (" & txtTicketID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con

                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d13", Val(row.Cells(12).Value))
                    If row.Cells(13).Value = "" Then
                        cmd.Parameters.AddWithValue("@d14", "")
                    Else
                        cmd.Parameters.AddWithValue("@d14", row.Cells(13).Value)
                    End If
                    If row.Cells(15).Value = "" Then
                        cmd.Parameters.AddWithValue("@d15", "")
                    Else
                        cmd.Parameters.AddWithValue("@d15", row.Cells(15).Value)
                    End If
                    cmd.Parameters.AddWithValue("@d16", IIf(lblTableNo.Text = "", DateTime.Now.Ticks.ToString().Substring(5, 13), lblTableNo.Text))
                    cmd.Parameters.Add("@d17", SqlDbType.Bit).Value = bl
                    con.Open()
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                    con.Close()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cbX As String = "Update R_Table set BkColor=@d2 where TableNo=@d1"
            cmd = New SqlCommand(cbX)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", IIf(lblTableNo.Text = "", DateTime.Now.Ticks.ToString().Substring(5, 13), lblTableNo.Text))
            cmd.Parameters.AddWithValue("@d2", Color.Red.ToArgb())
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new restaurant pos record having ticket no. '" & lblTicketNo.Text & "'"
            LogFunc(lblUserVAL.Text, st)
            btnSave.Enabled = False
            If MessageBox.Show("Do you want to print kot?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Print()
            End If
            fillTableNo()
            FillGroup()
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub RM_ID()
        Try
            Dim Num As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = ("SELECT MAX(RM_ID) FROM RM_Used")
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            If (IsDBNull(cmd.ExecuteScalar)) Then
                Num = 1
                txtRM_ID.Text = Num.ToString
            Else
                Num = cmd.ExecuteScalar + 1
                txtRM_ID.Text = Num.ToString
            End If
            cmd.Dispose()
            con.Close()
            con.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim ctx As String = "Select Count(TicketNo) from RestaurantPOS_OrderInfoKOT where TableNo=@d1 and KOT_Status in ('Open','Served','Prepared')"
            cmd = New SqlCommand(ctx)
            cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                str2 = rdr.GetValue(0)
                If Val(str2) = 1 Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cbX As String = "Update R_Table set BkColor=@d2 where TableNo=@d1"
                    cmd = New SqlCommand(cbX)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
                    cmd.Parameters.AddWithValue("@d2", Color.LightGreen.ToArgb())
                    cmd.ExecuteReader()
                    con.Close()
                End If
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "delete from RestaurantPOS_OrderInfoKOT where ID=" & txtTicketID.Text & ""
            cmd = New SqlCommand(ct1)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
                If txtStatus.Text <> "Void" Then
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        Dim str As String = row.Cells(0).Value.ToString()
                        Dim strText() As String
                        strText = Split(str, vbCrLf)
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1"
                        cmd = New SqlCommand(sql)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", strText(0))
                        rdr = cmd.ExecuteReader()
                        If (rdr.Read()) Then
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty + " & Val(row.Cells(2).Value) & " where Dish=@d1"
                            cmd = New SqlCommand(cb2)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d1", strText(0))
                            cmd.ExecuteReader()
                            con.Close()
                        End If
                    Next
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        Dim str As String = row.Cells(0).Value.ToString()
                        Dim strText() As String
                        strText = Split(str, vbCrLf)
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql As String = "select Dish from Recipe where Dish=@d1"
                        cmd = New SqlCommand(sql)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", strText(0))
                        rdr = cmd.ExecuteReader()
                        If (rdr.Read()) Then
                            con = New SqlConnection(cs)
                            con.Open()
                            cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                            cmd.Parameters.AddWithValue("@d1", strText(0))
                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            dgw.Rows.Clear()
                            While (rdr.Read() = True)
                                dgw.Rows.Add(rdr(0), rdr(1))
                            End While
                            con.Close()
                            For Each dr As DataGridViewRow In dgw.Rows
                                con = New SqlConnection(cs)
                                con.Open()
                                Dim cb2 As String = "Update Temp_Stock_RM set Qty=Qty + " & Val(dr.Cells(1).Value) * Val(row.Cells(2).Value) & " where ProductID=@d1"
                                cmd = New SqlCommand(cb2)
                                cmd.Connection = con
                                cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                                cmd.ExecuteReader()
                                con.Close()
                            Next
                            RawMaterialUsedDel(lblTicketNo.Text)
                        End If
                    Next
                End If
                Dim st As String = "deleted the restaurant pos record having ticket no. '" & lblTicketNo.Text & "'"
                LogFunc(lblUserVAL.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                fillTableNo()
                FillGroup()
                Reset()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord1()
        Try
            Dim RowsAffected As Integer = 0
            con.Open()
            Dim ct As String = "delete from RestaurantPOS_BillingInfoKOT where ID=" & txtBillID.Text & ""
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
                LedgerDelete(lblBillNo.Text, "POS")
                LedgerDelete(lblBillNo.Text, "Sales Invoice")
                Dim st As String = "deleted the restaurant pos record having bill no. '" & lblBillNo.Text & "'"
                LogFunc(lblUserVAL.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                fillTableNo()
                Reset1()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset1()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord2()
        Try
            Dim RowsAffected As Integer = 0
            con.Open()
            Dim ct As String = "delete from RestaurantPOS_BillingInfoTA where ID=" & txtBillID1.Text & ""
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
                If txtStatus.Text <> "Void" Then
                    For Each row As DataGridViewRow In DataGridView3.Rows
                        Dim str As String = row.Cells(0).Value.ToString()
                        Dim strText() As String
                        strText = Split(str, vbCrLf)
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1"
                        cmd = New SqlCommand(ctX)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", strText(0))
                        rdr = cmd.ExecuteReader()
                        If (rdr.Read()) Then
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty + " & Val(row.Cells(2).Value) & " where Dish=@d1"
                            cmd = New SqlCommand(cb2)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d1", strText(0))
                            cmd.ExecuteReader()
                            con.Close()
                        End If
                    Next
                    For Each row As DataGridViewRow In DataGridView3.Rows
                        Dim str As String = row.Cells(0).Value.ToString()
                        Dim strText() As String
                        strText = Split(str, vbCrLf)
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql As String = "select Dish from Recipe where Dish=@d1"
                        cmd = New SqlCommand(sql)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", strText(0))
                        rdr = cmd.ExecuteReader()
                        If (rdr.Read()) Then
                            con = New SqlConnection(cs)
                            con.Open()
                            cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                            cmd.Parameters.AddWithValue("@d1", strText(0))
                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            dgw.Rows.Clear()
                            While (rdr.Read() = True)
                                dgw.Rows.Add(rdr(0), rdr(1))
                            End While
                            con.Close()
                            For Each dr As DataGridViewRow In dgw.Rows
                                con = New SqlConnection(cs)
                                con.Open()
                                Dim cb2 As String = "Update Temp_Stock_RM set Qty=Qty + " & Val(dr.Cells(1).Value) * Val(row.Cells(2).Value) & " where ProductID=@d1"
                                cmd = New SqlCommand(cb2)
                                cmd.Connection = con
                                cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                                cmd.ExecuteReader()
                                con.Close()
                            Next
                            RawMaterialUsedDel(lblBillNo1.Text)
                        End If
                    Next
                End If
                LedgerDelete(lblBillNo1.Text, "POS")
                LedgerDelete(lblBillNo1.Text, "Sales Invoice")
                Dim st As String = "deleted the restaurant pos(takeaway) record having bill no. '" & lblBillNo1.Text & "'"
                LogFunc(lblUserVAL.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset2()
                Reset2()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset2()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord3()
        Try
            Dim RowsAffected As Integer = 0
            con.Open()
            Dim ct As String = "delete from RestaurantPOS_BillingInfoHD where ID=" & txtBillID2.Text & ""
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
                If txtStatus.Text <> "Cancelled" Then
                    For Each row As DataGridViewRow In DataGridView4.Rows
                        Dim str As String = row.Cells(0).Value.ToString()
                        Dim strText() As String
                        strText = Split(str, vbCrLf)
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1"
                        cmd = New SqlCommand(ctX)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", strText(0))
                        rdr = cmd.ExecuteReader()
                        If (rdr.Read()) Then
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty + " & Val(row.Cells(2).Value) & " where Dish=@d1"
                            cmd = New SqlCommand(cb2)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d1", strText(0))
                            cmd.ExecuteReader()
                            con.Close()
                        End If
                    Next
                    For Each row As DataGridViewRow In DataGridView4.Rows
                        Dim str As String = row.Cells(0).Value.ToString()
                        Dim strText() As String
                        strText = Split(str, vbCrLf)
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim sql As String = "select Dish from Recipe where Dish=@d1"
                        cmd = New SqlCommand(sql)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", strText(0))
                        rdr = cmd.ExecuteReader()
                        If (rdr.Read()) Then
                            con = New SqlConnection(cs)
                            con.Open()
                            cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                            cmd.Parameters.AddWithValue("@d1", strText(0))
                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            dgw.Rows.Clear()
                            While (rdr.Read() = True)
                                dgw.Rows.Add(rdr(0), rdr(1))
                            End While
                            con.Close()
                            For Each dr As DataGridViewRow In dgw.Rows
                                con = New SqlConnection(cs)
                                con.Open()
                                Dim cb2 As String = "Update Temp_Stock_RM set Qty=Qty + " & Val(dr.Cells(1).Value) * Val(row.Cells(2).Value) & " where ProductID=@d1"
                                cmd = New SqlCommand(cb2)
                                cmd.Connection = con
                                cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                                cmd.ExecuteReader()
                                con.Close()
                            Next
                            RawMaterialUsedDel(lblBillNo2.Text)
                        End If
                    Next
                End If
                LedgerDelete(lblBillNo2.Text, "POS")
                LedgerDelete(lblBillNo2.Text, "Sales Invoice")
                Dim st As String = "deleted the restaurant pos(takeaway) record having bill no. '" & lblBillNo2.Text & "'"
                LogFunc(lblUserVAL.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset3()
                Reset3()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset3()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord4()
        Try
            Dim RowsAffected As Integer = 0
            con.Open()
            Dim ct As String = "delete from RestaurantPOS_BillingInfoEB where ID=" & txtBillID3.Text & ""
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
                If txtStatus.Text <> "Void" Then
                    'For Each row As DataGridViewRow In DataGridView5.Rows
                    '    Dim str As String = row.Cells(0).Value.ToString()
                    '    Dim strText() As String
                    '    strText = Split(str, vbCrLf)
                    '    con = New SqlConnection(cs)
                    '    con.Open()
                    '    Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1"
                    '    cmd = New SqlCommand(ctX)
                    '    cmd.Connection = con
                    '    cmd.Parameters.AddWithValue("@d1", strText(0))
                    '    rdr = cmd.ExecuteReader()
                    '    If (rdr.Read()) Then
                    '        con = New SqlConnection(cs)
                    '        con.Open()
                    '        Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty + " & Val(row.Cells(2).Value) & " where Dish=@d1"
                    '        cmd = New SqlCommand(cb2)
                    '        cmd.Connection = con
                    '        cmd.Parameters.AddWithValue("@d1", strText(0))
                    '        cmd.ExecuteReader()
                    '        con.Close()
                    '    End If
                    'Next
                    'For Each row As DataGridViewRow In DataGridView5.Rows
                    '    Dim str As String = row.Cells(0).Value.ToString()
                    '    Dim strText() As String
                    '    strText = Split(str, vbCrLf)
                    '    con = New SqlConnection(cs)
                    '    con.Open()
                    '    Dim sql As String = "select Dish from Recipe where Dish=@d1"
                    '    cmd = New SqlCommand(sql)
                    '    cmd.Connection = con
                    '    cmd.Parameters.AddWithValue("@d1", strText(0))
                    '    rdr = cmd.ExecuteReader()
                    '    If (rdr.Read()) Then
                    '        con = New SqlConnection(cs)
                    '        con.Open()
                    '        cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                    '        cmd.Parameters.AddWithValue("@d1", strText(0))
                    '        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    '        dgw.Rows.Clear()
                    '        While (rdr.Read() = True)
                    '            dgw.Rows.Add(rdr(0), rdr(1))
                    '        End While
                    '        con.Close()
                    '        For Each dr As DataGridViewRow In dgw.Rows
                    '            con = New SqlConnection(cs)
                    '            con.Open()
                    '            Dim cb2 As String = "Update Temp_Stock_RM set Qty=Qty + " & Val(dr.Cells(1).Value) * Val(row.Cells(2).Value) & " where ProductID=@d1"
                    '            cmd = New SqlCommand(cb2)
                    '            cmd.Connection = con
                    '            cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                    '            cmd.ExecuteReader()
                    '            con.Close()
                    '        Next
                    '        RawMaterialUsedDel(lblBillNo3.Text)
                    '    End If
                    'Next
                End If
                'LedgerDelete(lblBillNo3.Text, "POS")
                'LedgerDelete(lblBillNo3.Text, "Sales Invoice")
                'Dim st As String = "deleted the restaurant pos(express billing) record having bill no. '" & lblBillNo3.Text & "'"
                'LogFunc(lblUserVAL.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset4()
                Reset4()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset4()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PrintFunc1()
        Dim CN As New SqlConnection(cs)
        CN.Open()
        cmd = New SqlCommand("SELECT * from Hotel", CN)
        Dim adp12 As New SqlDataAdapter(cmd)
        Dim dtCompany As New DataTable()
        adp12.Fill(dtCompany)
        CN.Close()
        CN.Open()
        adp = New SqlDataAdapter()
        adp.SelectCommand = New SqlCommand("SELECT DISTINCT RTRIM(Kitchen.Kitchenname) FROM Category INNER JOIN Kitchen ON Category.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductKOT ON Category.CategoryName = RestaurantPOS_OrderedProductKOT.Category INNER JOIN RestaurantPOS_OrderInfoKOT ON RestaurantPOS_OrderedProductKOT.TicketID = RestaurantPOS_OrderInfoKOT.ID where TicketNo='" & lblTicketNo.Text & "'", CN)
        ds = New DataSet("ds")
        adp.Fill(ds)
        Dim dtable As DataTable = ds.Tables(0)
        CBox.Items.Clear()
        For Each drow As DataRow In dtable.Rows
            CBox.Items.Add(drow(0).ToString())
        Next
        For Each item As String In CBox.Items
            Cursor = Cursors.WaitCursor
            Timer4.Enabled = True
            Dim myConnection As SqlConnection
            myConnection = New SqlConnection(cs)
            Dim dttable As DataTable = New DataTable()
            Dim dttt As DataTable = New DataTable()
            Dim s As String = "SELECT distinct RestaurantPOS_OrderedProductKOT.TicketID, RestaurantPOS_OrderInfoKOT.TicketNo,Operator,RestaurantPOS_OrderInfoKOT.TableNo, RestaurantPOS_OrderInfoKOT.BillDate FROM Category INNER JOIN Kitchen ON Category.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductKOT ON Category.CategoryName = RestaurantPOS_OrderedProductKOT.Category INNER JOIN RestaurantPOS_OrderInfoKOT ON RestaurantPOS_OrderedProductKOT.TicketID = RestaurantPOS_OrderInfoKOT.ID where TicketNo = '" & lblTicketNo.Text & "' and KitchenName=@d1 group by TicketNo, TableNo, Operator, BillDate, TicketID"
            cmd = New SqlCommand(s, myConnection)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@d1", item)
            Dim sdaa As New SqlDataAdapter(cmd)
            sdaa.Fill(dttt)
            dttable.Columns.Add("T_ID")
            dttable.Columns.Add("SupplierID")
            dttable.Columns.Add("TransactionID")
            dttable.Columns.Add("Amount")
            Dim qnt As Integer
            Dim vt, gross, nt, oddiscount As Decimal
            For index As Integer = 0 To DataGridView1.Rows.Count - 1
                dttable.Rows.Add(DataGridView1.Rows(index).Cells(0).Value, (DataGridView1.Rows(index).Cells(3).Value / DataGridView1.Rows(index).Cells(2).Value), DataGridView1.Rows(index).Cells(2).Value, DataGridView1.Rows(index).Cells(12).Value)
                qnt += CType((DataGridView1.Rows(index).Cells(2).Value), Integer)
                vt += CType((DataGridView1.Rows(index).Cells(9).Value), Decimal)
                gross += CType((DataGridView1.Rows(index).Cells(12).Value), Decimal)
                oddiscount += CType((DataGridView1.Rows(index).Cells(5).Value), Decimal)
            Next
            nt = gross
            'Dim prntOrder As frmPrintKitchenOrder = New frmPrintKitchenOrder()
            GetKitchenOrderValue(dtCompany, dttt, dttable, DataGridView1.Rows.Count, qnt, 0.00, 0.00, oddiscount, vt, nt, gross, lblPaymentMode.Text)
            'prntOrder.ShowDialog()
            vt = gross = nt = qnt = 0
        Next
    End Sub
    Public Sub KitOrder()
        Try
        Catch ex As Exception
        End Try
    End Sub
    Sub PrintFunc2()
        Cursor = Cursors.WaitCursor
        Timer4.Enabled = True
        Dim rpt As New rptRestaurantPOSKOTInvoice 'The report you created.
        Dim myConnection As SqlConnection
        Dim MyCommand, MyCommand1 As New SqlCommand()
        Dim myDA, myDA1 As New SqlDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New SqlConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT TicketNote,SCPer,SCAmount,RestaurantPOS_OrderedProductKOT.OP_ID,RestaurantPOS_OrderedProductKOT.Notes,Operator,GroupName, RestaurantPOS_OrderedProductKOT.TicketID, RestaurantPOS_OrderedProductKOT.Dish, RestaurantPOS_OrderedProductKOT.VATPer,RestaurantPOS_OrderedProductKOT.VATAmount, RestaurantPOS_OrderedProductKOT.STPer, RestaurantPOS_OrderedProductKOT.STAmount, RestaurantPOS_OrderedProductKOT.DiscountPer, RestaurantPOS_OrderedProductKOT.DiscountAmount,RestaurantPOS_OrderedProductKOT.Rate, RestaurantPOS_OrderedProductKOT.Quantity, RestaurantPOS_OrderedProductKOT.Amount, RestaurantPOS_OrderedProductKOT.TotalAmount,RestaurantPOS_OrderInfoKOT.ID, RestaurantPOS_OrderInfoKOT.TicketNo,RestaurantPOS_OrderInfoKOT.TableNo, RestaurantPOS_OrderInfoKOT.BillDate, RestaurantPOS_OrderInfoKOT.GrandTotal FROM RestaurantPOS_OrderedProductKOT INNER JOIN  RestaurantPOS_OrderInfoKOT ON RestaurantPOS_OrderedProductKOT.TicketID = RestaurantPOS_OrderInfoKOT.ID where RestaurantPOS_OrderInfoKOT.TicketNo='" & lblTicketNo.Text & "'"
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "RestaurantPOS_OrderInfoKOT")
        myDA.Fill(myDS, "RestaurantPOS_OrderedProductKOT")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        con = New SqlConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
        cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
        rdr = cmd.ExecuteReader()
        'Dim dtable As DataTable = New DataTable()
        'dtable.Columns.Add("Id")
        'dtable.Columns.Add("HardwareID")
        'Dim qnt As Integer
        'For index As Integer = 0 To DataGridView1.Rows.Count
        '    dtable.Rows.Add(DataGridView1.Rows(index).Cells(0), DataGridView1.Rows(index).Cells(1))
        '    qnt += CType((DataGridView1.Rows(index).Cells(1).Value), Integer)
        'Next
        'Dim dttt As DataTable = New DataTable()
        'Dim sda As New SqlDataAdapter("SELECT * FROM RestaurantPOS_OrderInfoKOT", myConnection)
        'sda.Fill(dttt)
        'Dim prntOrder As frmPrintKitchenOrder = New frmPrintKitchenOrder()
        'prntOrder.GetValue(dttt, dtable, DataGridView1.Rows.Count, qnt)
        'prntOrder.ShowDialog()

        If rdr.Read() Then
            s2 = rdr.GetValue(0)
            rpt.PrintOptions.PrinterName = s2
            Dim rp As ReportDocument = New ReportDocument()
            Dim pageMargins As PageMargins
            pageMargins = rp.PrintOptions.PageMargins
            rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
            rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelope10
            frmWPReport_CRViewer.Refresh()
            frmWPReport_CRViewer.CrystalReportViewer1.Zoom(25)
            pageMargins.leftMargin = 1
            pageMargins.rightMargin = 10
            pageMargins.topMargin = 0
            pageMargins.bottomMargin = 0
            rpt.PrintOptions.ApplyPageMargins(pageMargins)
            rpt.PrintToPrinter(1, False, 0, 0)
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        rpt.Close()
        rpt.Dispose()
    End Sub
    Sub Print()
        Try
            If K4.Text = "Yes" Then
                PrintFunc2()
            End If
            PrintFunc1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Dim files As String() = Directory.GetFiles(filepath)
            For Each filex As String In files
                File.Delete(filex)
            Next
        End Try
    End Sub
    Sub FillGroup()
        cmbGroup.Text = ""
        con = New SqlConnection(cs)
        con.Open()
        cmd = New SqlCommand("Select distinct RTRIM(GroupName) from RestaurantPOS_OrderInfoKOT where TableNo=@d1 and KOT_Status in ('Open','Served','Prepared') order by 1", con)
        cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
        rdr = cmd.ExecuteReader()
        cmbGroup.Items.Clear()
        While rdr.Read()
            cmbGroup.Items.Add(rdr(0))
        End While
        con.Close()
    End Sub
    Sub Reset()
        DataGridView1.Rows.Clear()
        Clear()
        btnSave.Enabled = True
        btnDelete.Enabled = False
        lblTableNo.Text = ""
        flpCategoriesKOT.Enabled = True
        flpItemsKOT.Enabled = True
        lblSet.Text = ""
        lblBalance.Text = "0.00"
        lblTicketNo.Text = ""
        btnSettle.Enabled = True
        btnNotes.Enabled = True
        btnPlus.Enabled = False
        btnMinus.Enabled = False
        btnCancel.Enabled = False
        btnChangeQty.Enabled = False
        btnChangeRate.Enabled = False
        cmbGroup.Text = ""
        cmbGroup.Enabled = False
        btnKOTUpdate.Enabled = False
        btnVoid.Enabled = False
        lblMemberID.Text = ""
        s1 = ""
        s2 = ""
        s3 = ""
        txtNotes.Text = ""
        txtItemsKOT.Text = ""
        auto()
        fillTableNo()
        lblCustName.Visible = False
        lblCustNameVAL.Visible = False
        CustomerDisplayOpeningMessage()
        POSHeaderEnable()
        btnModifier.Enabled = False
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub

    Private Sub btnNewTicket_Click(sender As System.Object, e As System.EventArgs) Handles btnNewTicket.Click
        Reset()
    End Sub

    Private Sub btn1f_Click(sender As System.Object, e As System.EventArgs) Handles btn1f.Click
        If txtCash.ReadOnly = False Then
            If Val(txtCash.Text) = 0 Then
                txtCash.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash.Text = txtCash.Text + Convert.ToString(1)
            ElseIf sign_Indicator = 1 Then
                txtCash.Text = Convert.ToString(1)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btn2f_Click(sender As System.Object, e As System.EventArgs) Handles btn2f.Click
        If txtCash.ReadOnly = False Then
            If Val(txtCash.Text) = 0 Then
                txtCash.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash.Text = txtCash.Text + Convert.ToString(2)
            ElseIf sign_Indicator = 1 Then
                txtCash.Text = Convert.ToString(2)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btn3f_Click(sender As System.Object, e As System.EventArgs) Handles btn3f.Click
        If txtCash.ReadOnly = False Then
            If Val(txtCash.Text) = 0 Then
                txtCash.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash.Text = txtCash.Text + Convert.ToString(3)
            ElseIf sign_Indicator = 1 Then
                txtCash.Text = Convert.ToString(3)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btn4f_Click(sender As System.Object, e As System.EventArgs) Handles btn4f.Click
        If txtCash.ReadOnly = False Then
            If Val(txtCash.Text) = 0 Then
                txtCash.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash.Text = txtCash.Text + Convert.ToString(4)
            ElseIf sign_Indicator = 1 Then
                txtCash.Text = Convert.ToString(4)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btn5f_Click(sender As System.Object, e As System.EventArgs) Handles btn5f.Click
        If txtCash.ReadOnly = False Then
            If Val(txtCash.Text) = 0 Then
                txtCash.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash.Text = txtCash.Text + Convert.ToString(5)
            ElseIf sign_Indicator = 1 Then
                txtCash.Text = Convert.ToString(5)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btn6f_Click(sender As System.Object, e As System.EventArgs) Handles btn6f.Click
        If txtCash.ReadOnly = False Then
            If Val(txtCash.Text) = 0 Then
                txtCash.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash.Text = txtCash.Text + Convert.ToString(6)
            ElseIf sign_Indicator = 1 Then
                txtCash.Text = Convert.ToString(6)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btn7f_Click(sender As System.Object, e As System.EventArgs) Handles btn7f.Click
        If txtCash.ReadOnly = False Then
            If Val(txtCash.Text) = 0 Then
                txtCash.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash.Text = txtCash.Text + Convert.ToString(7)
            ElseIf sign_Indicator = 1 Then
                txtCash.Text = Convert.ToString(7)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btn8f_Click(sender As System.Object, e As System.EventArgs) Handles btn8f.Click
        If txtCash.ReadOnly = False Then
            If Val(txtCash.Text) = 0 Then
                txtCash.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash.Text = txtCash.Text + Convert.ToString(8)
            ElseIf sign_Indicator = 1 Then
                txtCash.Text = Convert.ToString(8)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btn9f_Click(sender As System.Object, e As System.EventArgs) Handles btn9f.Click
        If txtCash.ReadOnly = False Then
            If Val(txtCash.Text) = 0 Then
                txtCash.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash.Text = txtCash.Text + Convert.ToString(9)
            ElseIf sign_Indicator = 1 Then
                txtCash.Text = Convert.ToString(9)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btnDotf_Click(sender As System.Object, e As System.EventArgs) Handles btnDotf.Click
        If txtCash.ReadOnly = False Then
            Dim i As Integer = 0
            Dim chr As Char = ControlChars.NullChar
            Dim decimal_Indicator As Integer = 0
            Dim l As Integer = txtCash.Text.Length - 1
            If sign_Indicator <> 1 Then
                For i = 0 To l
                    chr = txtCash.Text(i)
                    If chr = "."c Then
                        decimal_Indicator = 1
                    End If
                Next

                If decimal_Indicator <> 1 Then
                    txtCash.Text = txtCash.Text + Convert.ToString(".")
                End If
            End If
        End If
    End Sub
    Sub Calc()

        If DataGridView2.Rows.Count > 0 Then
            If cmbKOTDiscountType.SelectedIndex = 0 Then
                txtKOTDiscPer.Enabled = True
                txtKOTDiscountAmount.Enabled = False
                Dim num As Double
                Dim sum As Double = 0
                If txtTaxType.Text = "Inclusive" Then

                    For Each row As DataGridViewRow In DataGridView2.Rows
                        row.Cells(5).Value = Math.Round(Val(txtKOTDiscPer.Text) + Val(row.Cells(15).Value), 4)
                        row.Cells(6).Value = Math.Round((Val(row.Cells(4).Value) * Val(row.Cells(5).Value)) / 100, 2)
                        num1 = Val(row.Cells(4).Value) - Val(row.Cells(6).Value)
                        row.Cells(8).Value = 0
                        row.Cells(10).Value = Math.Round(num1 - (num1 / (1 + (Val(row.Cells(9).Value) / 100))), 2)
                        row.Cells(12).Value = 0
                        row.Cells(13).Value = Math.Round(Val(row.Cells(4).Value) - Val(row.Cells(6).Value), 2)
                        sum = sum + Val(row.Cells(6).Value)
                    Next
                Else
                    For Each row As DataGridViewRow In DataGridView2.Rows
                        row.Cells(5).Value = Math.Round(Val(txtKOTDiscPer.Text) + Val(row.Cells(15).Value), 4)
                        row.Cells(6).Value = Math.Round((Val(row.Cells(4).Value) * Val(row.Cells(5).Value)) / 100, 2)
                        row.Cells(8).Value = Math.Round(((Val(row.Cells(4).Value) - Val(row.Cells(6).Value)) * Val(row.Cells(7).Value)) / 100, 2)
                        row.Cells(10).Value = Math.Round(((Val(row.Cells(4).Value) - Val(row.Cells(6).Value)) * Val(row.Cells(9).Value)) / 100, 2)
                        row.Cells(12).Value = Math.Round(((Val(row.Cells(4).Value) - Val(row.Cells(6).Value)) * Val(row.Cells(11).Value)) / 100, 2)
                        row.Cells(13).Value = Math.Round(Val(row.Cells(4).Value) - Val(row.Cells(6).Value) + Val(row.Cells(8).Value) + Val(row.Cells(10).Value) + Val(row.Cells(12).Value), 2)
                        sum = sum + Val(row.Cells(6).Value)
                    Next
                End If
                sum = Math.Round(sum, 2)
                txtKOTDiscountAmount.Text = sum
                txtGrandTotal.Text = GrandTotal_Food1()
                num = Val(txtCash.Text) - Val(txtGrandTotal.Text)
                num = Math.Round(num, 2)
                If num < 0 Then
                    txtChange.Text = ""
                Else
                    txtChange.Text = num
                End If
            End If
        End If
        If DataGridView2.Rows.Count > 0 Then
            If cmbKOTDiscountType.SelectedIndex = 1 Then
                txtKOTDiscPer.Enabled = False
                txtKOTDiscountAmount.Enabled = True
                Dim num As Double
                Dim num1, num2 As Double
                For Each row As DataGridViewRow In DataGridView2.Rows
                    num2 = num2 + Val(row.Cells(4).Value)
                Next
                num1 = (Val(txtKOTDiscountAmount.Text) * 100) / Val(num2)
                num1 = Math.Round(num1, 4)
                txtKOTDiscPer.Text = num1
                If txtTaxType.Text = "Inclusive" Then
                    For Each row As DataGridViewRow In DataGridView2.Rows
                        row.Cells(5).Value = Math.Round(Val(txtKOTDiscPer.Text) + Val(row.Cells(15).Value), 4)
                        row.Cells(6).Value = Math.Round((Val(row.Cells(4).Value) * Val(row.Cells(5).Value)) / 100, 2)
                        num1 = Val(row.Cells(4).Value) - Val(row.Cells(6).Value)
                        row.Cells(8).Value = 0
                        row.Cells(10).Value = Math.Round(num1 - (num1 / (1 + (Val(row.Cells(9).Value) / 100))), 2)
                        row.Cells(12).Value = 0
                        row.Cells(13).Value = Math.Round(Val(row.Cells(4).Value) - Val(row.Cells(6).Value), 2)
                    Next
                Else
                    For Each row As DataGridViewRow In DataGridView2.Rows
                        row.Cells(5).Value = Math.Round(Val(txtKOTDiscPer.Text) + Val(row.Cells(15).Value), 4)
                        row.Cells(6).Value = Math.Round((Val(row.Cells(4).Value) * Val(row.Cells(5).Value)) / 100, 2)
                        row.Cells(8).Value = Math.Round(((Val(row.Cells(4).Value) - Val(row.Cells(6).Value)) * Val(row.Cells(7).Value)) / 100, 2)
                        row.Cells(10).Value = Math.Round(((Val(row.Cells(4).Value) - Val(row.Cells(6).Value)) * Val(row.Cells(9).Value)) / 100, 2)
                        row.Cells(12).Value = Math.Round(((Val(row.Cells(4).Value) - Val(row.Cells(6).Value)) * Val(row.Cells(11).Value)) / 100, 2)
                        row.Cells(13).Value = Math.Round(Val(row.Cells(4).Value) - Val(row.Cells(6).Value) + Val(row.Cells(8).Value) + Val(row.Cells(10).Value) + Val(row.Cells(12).Value), 2)
                    Next
                End If
                txtGrandTotal.Text = GrandTotal_Food1()
                num = Val(txtCash.Text) - Val(txtGrandTotal.Text)
                num = Math.Round(num, 2)
                If num < 0 Then
                    txtChange.Text = ""
                Else
                    txtChange.Text = num
                End If
            End If
        End If
    End Sub
    Sub Calc1()
        Try

            If DataGridView3.Rows.Count > 0 Then
                If cmbTADiscountType.SelectedIndex = 0 Then
                    Dim num As Double
                    Dim sum As Double = 0
                    txtTADiscountPer.Enabled = True
                    txtTADiscountAmount.Enabled = False
                    If txtTaxType.Text = "Inclusive" Then
                        For Each row As DataGridViewRow In DataGridView3.Rows
                            row.Cells(4).Value = Math.Round(Val(txtTADiscountPer.Text) + Val(row.Cells(14).Value), 4)
                            row.Cells(5).Value = Math.Round((Val(row.Cells(3).Value) * Val(row.Cells(4).Value)) / 100, 2)
                            num1 = Val(row.Cells(3).Value) - Val(row.Cells(5).Value)
                            row.Cells(7).Value = 0
                            row.Cells(9).Value = Math.Round(num1 - (num1 / (1 + (Val(row.Cells(8).Value) / 100))), 2)
                            row.Cells(11).Value = 0
                            row.Cells(12).Value = Math.Round(Val(row.Cells(3).Value) - Val(row.Cells(5).Value), 2)
                            sum = sum + Val(row.Cells(5).Value)
                        Next
                    Else

                        For Each row As DataGridViewRow In DataGridView3.Rows
                            row.Cells(4).Value = Math.Round(Val(txtTADiscountPer.Text) + Val(row.Cells(14).Value), 4)
                            row.Cells(5).Value = Math.Round((Val(row.Cells(3).Value) * Val(row.Cells(4).Value)) / 100, 2)
                            row.Cells(7).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(6).Value)) / 100, 2)
                            row.Cells(9).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(8).Value)) / 100, 2)
                            row.Cells(11).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(10).Value)) / 100, 2)
                            row.Cells(12).Value = Math.Round(Val(row.Cells(3).Value) - Val(row.Cells(5).Value) + Val(row.Cells(7).Value) + Val(row.Cells(9).Value) + Val(row.Cells(11).Value), 2)
                            sum = sum + Val(row.Cells(5).Value)
                        Next
                    End If
                    sum = Math.Round(sum, 2)
                    txtTADiscountAmount.Text = sum
                    lblBalance1.Text = GrandTotal_Food2()
                    txtSubTotal1.Text = GrandTotal_Food2()
                    num1 = Val(txtParcelCharges.Text) + Val(txtSubTotal1.Text)
                    num1 = Math.Round(num1, 2)
                    txtGrandTotal1.Text = num1
                    num = Val(txtCash1.Text) - Val(txtGrandTotal1.Text)
                    num = Math.Round(num, 2)
                    If num < 0 Then
                        txtChange1.Text = ""
                    Else
                        txtChange1.Text = num
                    End If
                End If
            End If
            If DataGridView3.Rows.Count > 0 Then
                If cmbTADiscountType.SelectedIndex = 1 Then
                    txtTADiscountPer.Enabled = False
                    txtTADiscountAmount.Enabled = True
                    Dim num As Double
                    Dim num1, num2 As Double
                    For Each row As DataGridViewRow In DataGridView3.Rows
                        num2 = num2 + Val(row.Cells(3).Value)
                    Next
                    num1 = (Val(txtTADiscountAmount.Text) * 100) / Val(num2)
                    num1 = Math.Round(num1, 4)
                    txtTADiscountPer.Text = num1
                    If txtTaxType.Text = "Inclusive" Then
                        For Each row As DataGridViewRow In DataGridView3.Rows
                            row.Cells(4).Value = Math.Round(Val(txtTADiscountPer.Text) + Val(row.Cells(14).Value), 4)
                            row.Cells(5).Value = Math.Round((Val(row.Cells(3).Value) * Val(row.Cells(4).Value)) / 100, 2)
                            num1 = Val(row.Cells(3).Value) - Val(row.Cells(5).Value)
                            row.Cells(7).Value = 0
                            row.Cells(9).Value = Math.Round(num1 - (num1 / (1 + (Val(row.Cells(8).Value) / 100))), 2)
                            row.Cells(11).Value = 0
                            row.Cells(12).Value = Math.Round(Val(row.Cells(3).Value) - Val(row.Cells(5).Value), 2)
                        Next
                    Else
                        For Each row As DataGridViewRow In DataGridView3.Rows
                            row.Cells(4).Value = Math.Round(Val(txtTADiscountPer.Text) + Val(row.Cells(14).Value), 4)
                            row.Cells(5).Value = Math.Round((Val(row.Cells(3).Value) * Val(row.Cells(4).Value)) / 100, 2)
                            row.Cells(7).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(6).Value)) / 100, 2)
                            row.Cells(9).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(8).Value)) / 100, 2)
                            row.Cells(11).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(10).Value)) / 100, 2)
                            row.Cells(12).Value = Math.Round(Val(row.Cells(3).Value) - Val(row.Cells(5).Value) + Val(row.Cells(7).Value) + Val(row.Cells(9).Value) + Val(row.Cells(11).Value), 2)
                        Next
                    End If
                    lblBalance1.Text = GrandTotal_Food2()
                    txtSubTotal1.Text = GrandTotal_Food2()
                    num1 = Val(txtParcelCharges.Text) + Val(txtSubTotal1.Text)
                    num1 = Math.Round(num1, 2)
                    txtGrandTotal1.Text = num1
                    num = Val(txtCash1.Text) - Val(txtGrandTotal1.Text)
                    num = Math.Round(num, 2)
                    If num < 0 Then
                        txtChange1.Text = ""
                    Else
                        txtChange1.Text = num
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub GetSections()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select KitchenName from Kitchen order by KitchenName ASC"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            Dim dt As New DataTable()
            dt.Load(rdr)
            cmbSection.Items.Clear()
            cmbBillSetion.Items.Clear()
            cmbTSection.Items.Clear()
            For Each row As DataRow In dt.Rows
                cmbSection.Items.Add(row("KitchenName"))
                cmbBillSetion.Items.Add(row("KitchenName"))
                cmbTSection.Items.Add(row("KitchenName"))
            Next
            If cmbSection.Items.Count > 0 Then
                cmbSection.SelectedIndex = 0
            End If
            If cmbTSection.Items.Count > 0 Then
                cmbTSection.SelectedIndex = 0
            End If
        Catch
        End Try
    End Sub
    Sub Calc2()
        Try

            If DataGridView4.Rows.Count > 0 Then
                txtHDDiscountPer.Enabled = True
                txtHDDiscountAmount.Enabled = False
                If cmbHDDiscountType.SelectedIndex = 0 Then
                    Dim num As Double
                    Dim sum As Double = 0
                    If txtTaxType.Text = "Inclusive" Then
                        For Each row As DataGridViewRow In DataGridView4.Rows
                            row.Cells(4).Value = Math.Round(Val(txtHDDiscountPer.Text) + Val(row.Cells(14).Value), 4)
                            row.Cells(5).Value = Math.Round((Val(row.Cells(3).Value) * Val(row.Cells(4).Value)) / 100, 2)
                            num1 = Val(row.Cells(3).Value) - Val(row.Cells(5).Value)
                            row.Cells(7).Value = 0
                            row.Cells(9).Value = Math.Round(num1 - (num1 / (1 + (Val(row.Cells(8).Value) / 100))), 2)
                            row.Cells(11).Value = 0
                            row.Cells(12).Value = Math.Round(Val(row.Cells(3).Value) - Val(row.Cells(5).Value), 2)
                            sum = sum + Val(row.Cells(5).Value)
                        Next
                    Else
                        For Each row As DataGridViewRow In DataGridView4.Rows
                            row.Cells(4).Value = Math.Round(Val(txtHDDiscountPer.Text) + Val(row.Cells(14).Value), 4)
                            row.Cells(5).Value = Math.Round((Val(row.Cells(3).Value) * Val(row.Cells(4).Value)) / 100, 2)
                            row.Cells(7).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(6).Value)) / 100, 2)
                            row.Cells(9).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(8).Value)) / 100, 2)
                            row.Cells(11).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(10).Value)) / 100, 2)
                            row.Cells(12).Value = Math.Round(Val(row.Cells(3).Value) - Val(row.Cells(5).Value) + Val(row.Cells(7).Value) + Val(row.Cells(9).Value) + Val(row.Cells(11).Value), 2)
                            sum = sum + Val(row.Cells(5).Value)
                        Next
                    End If
                    sum = Math.Round(sum, 2)
                    txtHDDiscountAmount.Text = sum
                    lblBalance2.Text = GrandTotal_Food3()
                    txtSubTotal.Text = GrandTotal_Food3()
                    num = Val(txtSubTotal.Text) + Val(txtDeliveryCharges.Text)
                    num = Math.Round(num, 2)
                    txtGrandTotal2.Text = num
                End If
            End If
            If DataGridView4.Rows.Count > 0 Then
                If cmbHDDiscountType.SelectedIndex = 1 Then
                    txtHDDiscountPer.Enabled = False
                    txtHDDiscountAmount.Enabled = True
                    Dim num As Double
                    Dim num1, num2 As Double
                    For Each row As DataGridViewRow In DataGridView4.Rows
                        num2 = num2 + Val(row.Cells(3).Value)
                    Next
                    num1 = (Val(txtHDDiscountAmount.Text) * 100) / Val(num2)
                    num1 = Math.Round(num1, 4)
                    txtHDDiscountPer.Text = num1
                    If txtTaxType.Text = "Inclusive" Then
                        For Each row As DataGridViewRow In DataGridView4.Rows
                            row.Cells(4).Value = Math.Round(Val(txtHDDiscountPer.Text) + Val(row.Cells(14).Value), 4)
                            row.Cells(5).Value = Math.Round((Val(row.Cells(3).Value) * Val(row.Cells(4).Value)) / 100, 2)
                            num1 = Val(row.Cells(3).Value) - Val(row.Cells(5).Value)
                            row.Cells(7).Value = 0
                            row.Cells(9).Value = Math.Round(num1 - (num1 / (1 + (Val(row.Cells(8).Value) / 100))), 2)
                            row.Cells(11).Value = 0
                            row.Cells(12).Value = Math.Round(Val(row.Cells(3).Value) - Val(row.Cells(5).Value), 2)
                        Next
                    Else
                        For Each row As DataGridViewRow In DataGridView4.Rows
                            row.Cells(4).Value = Math.Round(Val(txtHDDiscountPer.Text) + Val(row.Cells(14).Value), 4)
                            row.Cells(5).Value = Math.Round((Val(row.Cells(3).Value) * Val(row.Cells(4).Value)) / 100, 2)
                            row.Cells(7).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(6).Value)) / 100, 2)
                            row.Cells(9).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(8).Value)) / 100, 2)
                            row.Cells(11).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(10).Value)) / 100, 2)
                            row.Cells(12).Value = Math.Round(Val(row.Cells(3).Value) - Val(row.Cells(5).Value) + Val(row.Cells(7).Value) + Val(row.Cells(9).Value) + Val(row.Cells(11).Value), 2)
                        Next
                    End If
                    lblBalance2.Text = GrandTotal_Food3()
                    txtSubTotal.Text = GrandTotal_Food3()
                    num = Val(txtSubTotal.Text) + Val(txtDeliveryCharges.Text)
                    num = Math.Round(num, 2)
                    txtGrandTotal2.Text = num
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Calc3()
        Try
            'If DataGridView5.Rows.Count > 0 Then
            '    txtEBDiscountPer.Enabled = True
            '    txtEBDiscountAmount.Enabled = False
            '    If cmbEBDiscountType.SelectedIndex = 0 Then
            '        Dim num As Double
            '        Dim sum As Double = 0
            '        If txtTaxType.Text = "Inclusive" Then
            '            For Each row As DataGridViewRow In DataGridView5.Rows
            '                row.Cells(4).Value = Math.Round(Val(txtEBDiscountPer.Text) + Val(row.Cells(14).Value), 4)
            '                row.Cells(5).Value = Math.Round((Val(row.Cells(3).Value) * Val(row.Cells(4).Value)) / 100, 2)
            '                num1 = Val(row.Cells(3).Value) - Val(row.Cells(5).Value)
            '                row.Cells(7).Value = 0
            '                row.Cells(9).Value = Math.Round(num1 - (num1 / (1 + (Val(row.Cells(8).Value) / 100))), 2)
            '                row.Cells(11).Value = 0
            '                row.Cells(12).Value = Math.Round(Val(row.Cells(3).Value) - Val(row.Cells(5).Value), 2)
            '                sum = sum + Val(row.Cells(5).Value)
            '            Next
            '        Else
            '            For Each row As DataGridViewRow In DataGridView5.Rows
            '                row.Cells(4).Value = Math.Round(Val(txtEBDiscountPer.Text) + Val(row.Cells(14).Value), 4)
            '                row.Cells(5).Value = Math.Round((Val(row.Cells(3).Value) * Val(row.Cells(4).Value)) / 100, 2)
            '                row.Cells(7).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(6).Value)) / 100, 2)
            '                row.Cells(9).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(8).Value)) / 100, 2)
            '                row.Cells(11).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(10).Value)) / 100, 2)
            '                row.Cells(12).Value = Math.Round(Val(row.Cells(3).Value) - Val(row.Cells(5).Value) + Val(row.Cells(7).Value) + Val(row.Cells(9).Value) + Val(row.Cells(11).Value), 2)
            '                sum = sum + Val(row.Cells(5).Value)
            '            Next
            '        End If
            '        sum = Math.Round(sum, 2)
            '        txtEBDiscountAmount.Text = sum
            '        txtGrandTotal3.Text = GrandTotal_Food4()
            '        lblBalance3.Text = GrandTotal_Food4()
            '        num = Val(txtCash3.Text) - Val(txtGrandTotal3.Text)
            '        num = Math.Round(num, 2)
            '        If num < 0 Then
            '            txtChange3.Text = "0.00"
            '        Else
            '            txtChange3.Text = num
            '        End If
            '    End If
            'End If
            'If DataGridView5.Rows.Count > 0 Then
            '    If cmbEBDiscountType.SelectedIndex = 1 Then
            '        txtEBDiscountPer.Enabled = False
            '        txtEBDiscountAmount.Enabled = True
            '        Dim num As Double
            '        Dim num1, num2 As Double
            '        For Each row As DataGridViewRow In DataGridView5.Rows
            '            num2 = num2 + Val(row.Cells(3).Value)
            '        Next
            '        num1 = (Val(txtEBDiscountAmount.Text) * 100) / Val(num2)
            '        num1 = Math.Round(num1, 4)
            '        txtEBDiscountPer.Text = num1
            '        If txtTaxType.Text = "Inclusive" Then
            '            For Each row As DataGridViewRow In DataGridView5.Rows
            '                row.Cells(4).Value = Math.Round(Val(txtEBDiscountPer.Text) + Val(row.Cells(14).Value), 4)
            '                row.Cells(5).Value = Math.Round((Val(row.Cells(3).Value) * Val(row.Cells(4).Value)) / 100, 2)
            '                num1 = Val(row.Cells(3).Value) - Val(row.Cells(5).Value)
            '                row.Cells(7).Value = 0
            '                row.Cells(9).Value = Math.Round(num1 - (num1 / (1 + (Val(row.Cells(8).Value) / 100))), 2)
            '                row.Cells(11).Value = 0
            '                row.Cells(12).Value = Math.Round(Val(row.Cells(3).Value) - Val(row.Cells(5).Value), 2)
            '            Next
            '        Else
            '            For Each row As DataGridViewRow In DataGridView5.Rows
            '                row.Cells(4).Value = Math.Round(Val(txtEBDiscountPer.Text) + Val(row.Cells(14).Value), 4)
            '                row.Cells(5).Value = Math.Round((Val(row.Cells(3).Value) * Val(row.Cells(4).Value)) / 100, 2)
            '                row.Cells(7).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(6).Value)) / 100, 2)
            '                row.Cells(9).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(8).Value)) / 100, 2)
            '                row.Cells(11).Value = Math.Round(((Val(row.Cells(3).Value) - Val(row.Cells(5).Value)) * Val(row.Cells(10).Value)) / 100, 2)
            '                row.Cells(12).Value = Math.Round(Val(row.Cells(3).Value) - Val(row.Cells(5).Value) + Val(row.Cells(7).Value) + Val(row.Cells(9).Value) + Val(row.Cells(11).Value), 2)
            '            Next
            '        End If
            '        txtGrandTotal3.Text = GrandTotal_Food4()
            '        lblBalance3.Text = GrandTotal_Food4()
            '        num = Val(txtCash3.Text) - Val(txtGrandTotal3.Text)
            '        num = Math.Round(num, 2)
            '        If num < 0 Then
            '            txtChange3.Text = "0.00"
            '        Else
            '            txtChange3.Text = num
            '        End If
            '    End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btn0f_Click(sender As System.Object, e As System.EventArgs) Handles btn0f.Click
        If txtCash.ReadOnly = False Then
            If sign_Indicator = 0 Then
                txtCash.Text = txtCash.Text + Convert.ToString(0)
            ElseIf sign_Indicator = 1 Then
                txtCash.Text = Convert.ToString(0)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btnXf_Click(sender As System.Object, e As System.EventArgs) Handles btnXf.Click
        If txtCash.ReadOnly = False Then
            s = txtCash.Text
            Dim l As Integer = s.Length
            For i As Integer = 0 To l - 2
                x += s(i)
            Next
            txtCash.Text = x
            x = ""
        End If
    End Sub

    Private Sub btnSave1_Click(sender As System.Object, e As System.EventArgs) Handles btnSave1.Click
        Try
            If DataGridView2.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If lblPaymentMode.Text = "" Then
                MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblPaymentMode.Focus()
                Exit Sub
            End If
            If txtCash.Text = "" Then
                MessageBox.Show("Please enter cash", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCash.Focus()
                Exit Sub
            End If
            If Val(txtGrandTotal.Text) < 0 Then
                MessageBox.Show("Grand Total can't be less than zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If lblPaymentMode.Text <> "Credit Customer" Then
                If Val(txtGrandTotal.Text) > Val(txtCash.Text) Then
                    MessageBox.Show("cash can not be less than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            auto1()
            OrderNo()
            ODN(lblOrderNo.Text, lblBillNo.Text)
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into RestaurantPOS_BillingInfoKOT( Id,BillNo, BillDate, GrandTotal,Cash,Change,Operator,PaymentMode,ExchangeRate,CurrencyCode,KOTDiscountPer,KOTDiscountAmt,Member_ID,ODN,Waiter) Values (" & txtBillID.Text & ",'" & lblBillNo.Text & "',@d1," & Val(txtGrandTotal.Text) & "," & Val(txtCash.Text) & "," & Val(txtChange.Text) & ",@d2,@d3," & Val(txtExchangeRate.Text) & ",@d4," & Val(txtKOTDiscPer.Text) & ",@d5,@d6,@d7,@d8)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", System.DateTime.Now)
            cmd.Parameters.AddWithValue("@d2", lblUserVAL.Text)
            cmd.Parameters.AddWithValue("@d3", lblPaymentMode.Text)
            If lblCurrencyValKOT.Text <> "" Then
                cmd.Parameters.AddWithValue("@d4", lblCurrencyValKOT.Text)
            Else
                cmd.Parameters.AddWithValue("@d4", str)
            End If
            cmd.Parameters.AddWithValue("@d5", Val(txtKOTDiscountAmount.Text))
            If lblMemberID.Text = "" Then
                cmd.Parameters.AddWithValue("@d6", "")
            Else
                cmd.Parameters.AddWithValue("@d6", lblMemberID.Text)
            End If
            cmd.Parameters.AddWithValue("@d7", lblOrderNo.Text)
            cmd.Parameters.AddWithValue("@d8", operatorx)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into RestaurantPOS_OrderedProductBillKOT(BillID,TableNo,Dish,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,SCPer,SCAmount,TotalAmount,Category,ValidityFrom,isHappyHour) VALUES (" & txtBillID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,GetDate(),@d16)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d13", Val(row.Cells(12).Value))
                    cmd.Parameters.AddWithValue("@d14", Val(row.Cells(13).Value))
                    If row.Cells(16).Value = "" Then
                        cmd.Parameters.AddWithValue("@d15", "")
                    Else
                        cmd.Parameters.AddWithValue("@d15", row.Cells(16).Value)
                    End If
                    cmd.Parameters.AddWithValue("@d16", row.Cells(17).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            Dim st As String = "added the new restaurant pos record having bill no. '" & lblBillNo.Text & "'"
            LogFunc(lblUserVAL.Text, st)
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    SqlConnection.ClearAllPools()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb4 As String = "Update RestaurantPOS_OrderInfoKOT set KOT_Status='Closed' where TableNo=@d1 and GroupName=@d2 and KOT_Status in ('Open','Prepared','Served')"
                    cmd = New SqlCommand(cb4)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value.ToString())
                    cmd.Parameters.AddWithValue("@d2", row.Cells(14).Value.ToString())
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    SqlConnection.ClearAllPools()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctx As String = "Select Count(TableNo) from RestaurantPOS_OrderInfoKOT where TableNo=@d1 and KOT_Status='Open'"
                    cmd = New SqlCommand(ctx)
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        str2 = rdr.GetValue(0)
                        If Val(str2) <= 0 Then
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cb5 As String = "Update R_Table set BkColor=@d1 where TableNo=@d2"
                            cmd = New SqlCommand(cb5)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d1", Color.LightGreen.ToArgb())
                            cmd.Parameters.AddWithValue("@d2", row.Cells(0).Value)
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                        retrieving.SoldStock(CType(row.Cells(3).Value, Decimal), row.Cells(1).Value.ToString())
                    End If
                End If
            Next
            con.Close()
            GetTransID()
            If lblPaymentMode.Text = "Credit Customer" Then
                LedgerSave(System.DateTime.Today, "Sales A/c", lblBillNo.Text, "Sales Invoice", 0, Val(txtGrandTotal.Text) * Val(txtExchangeRate.Text), "", lblCustNameVAL.Text, cmbBillSetion.Text)
                LedgerSave(System.DateTime.Today, lblCustNameVAL.Text, lblBillNo.Text, "POS", Val(txtGrandTotal.Text) * Val(txtExchangeRate.Text), 0, lblMemberID.Text, "Sales A/c", cmbBillSetion.Text)
            Else
                LedgerSave(System.DateTime.Today, "Cash", lblBillNo.Text, "POS", Val(txtGrandTotal.Text) * Val(txtExchangeRate.Text), 0, "", "Sales A/c", cmbBillSetion.Text)
                LedgerSave(System.DateTime.Today, "Sales A/c", lblBillNo.Text, "Sales Invoice", 0, Val(txtGrandTotal.Text) * Val(txtExchangeRate.Text), "", "Cash", cmbBillSetion.Text)
            End If
            btnSave1.Enabled = False
            If lblPaymentMode.Text = "Cash" And Val(txtCash.Text) > 0 Then
                OpenCashdrawer()
            End If
            lblPrintMode.Text = "Final Bill"
            If MessageBox.Show("Do you want to print bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Print1()
                'printPDF()
            End If
            fillTableNo()
            Reset1()
            AutoCheckSection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Print1()
        Try
            If txtCash.Text IsNot "" Then
                If DataGridView2.Rows.Count = 0 Then
                    MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                'If lblPrintMode.Text = "Final Bill" Then
                '    Cursor = Cursors.WaitCursor
                '    Timer4.Enabled = True
                '    Dim rpt As New rptRestaurantPOSFinalBillKOTInvoice 'The report you created. 
                '    Dim rpt1 As New rptRestaurantPOSTAInvoice
                '    Dim myConnection As SqlConnection
                '    Dim MyCommand, MyCommand1 As New SqlCommand()
                '    Dim myDA, myDA1 As New SqlDataAdapter()
                '    Dim myDS As New DataSet 'The DataSet you created.
                '    myConnection = New SqlConnection(cs)
                '    MyCommand.Connection = myConnection
                '    MyCommand1.Connection = myConnection
                '    MyCommand.CommandText = "SELECT distinct Waiter,Member_ID, ODN,KOTDiscountPer,KOTDiscountAmt,RestaurantPOS_OrderedProductBillKOT.OP_ID,Operator,SCPer,SCAmount,PaymentMode,CurrencyCode, RestaurantPOS_OrderedProductBillKOT.BillID, RestaurantPOS_OrderedProductBillKOT.Dish, RestaurantPOS_OrderedProductBillKOT.VATPer,RestaurantPOS_OrderedProductBillKOT.VATAmount, RestaurantPOS_OrderedProductBillKOT.STPer, RestaurantPOS_OrderedProductBillKOT.STAmount, RestaurantPOS_OrderedProductBillKOT.DiscountPer, RestaurantPOS_OrderedProductBillKOT.DiscountAmount,RestaurantPOS_OrderedProductBillKOT.Rate, RestaurantPOS_OrderedProductBillKOT.Quantity, RestaurantPOS_OrderedProductBillKOT.Amount, RestaurantPOS_OrderedProductBillKOT.TotalAmount,RestaurantPOS_BillingInfoKOT.ID, RestaurantPOS_BillingInfoKOT.BillNo,RestaurantPOS_OrderedProductBillKOT.TableNo, RestaurantPOS_BillingInfoKOT.BillDate, RestaurantPOS_BillingInfoKOT.GrandTotal,RestaurantPOS_BillingInfoKOT.Cash,RestaurantPOS_BillingInfoKOT.Change FROM RestaurantPOS_OrderedProductBillKOT INNER JOIN  RestaurantPOS_BillingInfoKOT ON RestaurantPOS_OrderedProductBillKOT.BillID = RestaurantPOS_BillingInfoKOT.ID where RestaurantPOS_BillingInfoKOT.ID = " & txtBillID.Text & ""
                '    MyCommand1.CommandText = "SELECT * from Hotel"
                '    MyCommand.CommandType = CommandType.Text
                '    MyCommand1.CommandType = CommandType.Text
                '    myDA.SelectCommand = MyCommand
                '    myDA1.SelectCommand = MyCommand1
                '    myDA.Fill(myDS, "RestaurantPOS_BillingInfoKOT")
                '    myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillKOT")
                '    myDA1.Fill(myDS, "Hotel")
                '    rpt.SetDataSource(myDS)
                '    If lblPaymentMode.Text = "Credit Customer" Then
                '        con = New SqlConnection(cs)
                '        con.Open()
                '        cmd = con.CreateCommand()
                '        cmd.CommandText = "SELECT RTRIM(Name) from CreditCustomer where CreditCustomerID=@d1"
                '        cmd.Parameters.AddWithValue("@d1", lblMemberID.Text)
                '        rdr = cmd.ExecuteReader()
                '        If rdr.Read() Then
                '            lblCustNameVAL.Text = rdr.GetValue(0).ToString()
                '        Else
                '            lblCustNameVAL.Text = ""
                '        End If
                '        If (rdr IsNot Nothing) Then
                '            rdr.Close()
                '        End If
                '        If con.State = ConnectionState.Open Then
                '            con.Close()
                '        End If
                '        rpt.SetParameterValue("p1", lblCustNameVAL.Text)
                '    Else
                '        rpt.SetParameterValue("p1", "")
                '    End If

                '    con = New SqlConnection(cs)
                '    con.Open()
                '    cmd = con.CreateCommand()
                '    cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
                '    cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
                '    rdr = cmd.ExecuteReader()
                '    If rdr.Read() Then
                '        s3 = rdr.GetValue(0)
                '        rpt.PrintOptions.PrinterName = s3
                '        Dim rp As ReportDocument = New ReportDocument()
                '        Dim pageMargins As PageMargins
                '        pageMargins = rp.PrintOptions.PageMargins
                '        rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
                '        rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelope10
                '        frmWPReport_CRViewer.Refresh()
                '        frmWPReport_CRViewer.CrystalReportViewer1.Zoom(25)
                '        pageMargins.leftMargin = 1
                '        pageMargins.rightMargin = 10
                '        pageMargins.topMargin = 0
                '        pageMargins.bottomMargin = 0
                '        rpt.PrintOptions.ApplyPageMargins(pageMargins)
                '        rpt.PrintToPrinter(1, False, 0, 0)
                '    End If
                '    If (rdr IsNot Nothing) Then
                '        rdr.Close()
                '    End If
                '    frmWPReport_CRViewer.CrystalReportViewer1.ReportSource = rpt
                '    frmWPReport_CRViewer.txtEmailID.Text = ""
                '    frmWPReport_CRViewer.ShowDialog()
                '    rpt.Close()
                '    rpt.Dispose()
                'Else
                If lvTable.CheckedItems.Count > 0 Then
                    Dim Condition As String = ""
                    Dim Condition1 As String = ""
                    For I = 0 To lvTable.CheckedItems.Count - 1

                        Condition += String.Format("'{0}',", lvTable.CheckedItems(I).Text)
                        Condition1 += String.Format("'{0}',", lvTable.CheckedItems(I).SubItems(1).Text)
                    Next
                    'Condition = Condition.Substring(0, Condition.Length - 1)
                    Condition1 = Condition1.Substring(0, Condition1.Length - 1)
                    Condition = DataGridView2.Rows(0).Cells(0).Value.ToString()
                    Cursor = Cursors.WaitCursor
                    Timer4.Enabled = True
                    Dim cmd, cmd1 As SqlCommand
                    Dim ds As DataSet
                    Dim adp, adp1 As SqlDataAdapter
                    Dim dtable, dtable1 As DataTable
                    con = New SqlConnection(cs)
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("SELECT * from Hotel", con)
                    adp = New SqlDataAdapter(cmd)
                    Dim s As String = "SELECT distinct Operator,RestaurantPOS_OrderInfoKOT.TableNo FROM Category INNER JOIN Kitchen ON Category.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductKOT ON Category.CategoryName = RestaurantPOS_OrderedProductKOT.Category INNER JOIN RestaurantPOS_OrderInfoKOT ON RestaurantPOS_OrderedProductKOT.TicketID = RestaurantPOS_OrderInfoKOT.ID where TableNo = '" & Condition & "' group by TableNo, Operator"
                    cmd1 = New SqlCommand(s, con)
                    cmd1.CommandType = CommandType.Text
                    'cmd1.Parameters.AddWithValue("@d1", item)
                    'cmd1 = New SqlCommand("SELECT RestaurantPOS_OrderedProductKOT.T_Number,RestaurantPOS_OrderedProductKOT.Dish, RestaurantPOS_OrderedProductKOT.Rate,Sum(RestaurantPOS_OrderedProductKOT.Quantity) as Qty, Sum(RestaurantPOS_OrderedProductKOT.Amount) as Amount,Sum(STAmount) as STAmount,Sum(SCAmount) as SCAmount,Sum(VATAmount) as VATAmount,Sum(DiscountAmount) as DiscountAmount,Sum(TotalAmount) as TotalAmount FROM RestaurantPOS_OrderInfoKOT INNER JOIN RestaurantPOS_OrderedProductKOT ON RestaurantPOS_OrderInfoKOT.Id = RestaurantPOS_OrderedProductKOT.TicketID where T_Number in (" & Condition & ") and GroupName in (" & Condition1 & ") and KOT_Status in ('Open','Served','Prepared') group by T_Number,Dish,Rate  order by T_Number", con)
                    adp1 = New SqlDataAdapter(cmd1)
                    dtable = New DataTable()
                    dtable1 = New DataTable()
                    adp.Fill(dtable)
                    adp1.Fill(dtable1)
                    ds = New DataSet()
                    ds.Tables.Add(dtable)
                    ds.Tables.Add(dtable1)
                    ds.WriteXmlSchema("DineInFinalBillBeforePayment3.xml")
                    'Dim rpt As New rptRestaurantPOSTemp_FinalBillKOTInvoice
                    'rpt.SetDataSource(ds)
                    'rpt.SetParameterValue("p1", lblUserVAL.Text)
                    Dim dttable As DataTable = New DataTable()
                    dttable.Columns.Add("T_ID")
                    dttable.Columns.Add("SupplierID")
                    dttable.Columns.Add("TransactionID")
                    dttable.Columns.Add("Amount")
                    Dim qnt As Integer
                    Dim vt, gross, nt As Decimal
                    For index As Integer = 0 To DataGridView2.Rows.Count - 1
                        dttable.Rows.Add(DataGridView2.Rows(index).Cells(1).Value, DataGridView2.Rows(index).Cells(3).Value, DataGridView2.Rows(index).Cells(2).Value, DataGridView2.Rows(index).Cells(4).Value)
                        qnt += CType((DataGridView2.Rows(index).Cells(3).Value), Integer)
                        vt += CType((DataGridView2.Rows(index).Cells(10).Value), Decimal)
                        gross += CType((DataGridView2.Rows(index).Cells(13).Value), Decimal)
                    Next
                    nt = vt + gross
                    'Dim prntOrder As frmPaidorder = New frmPaidorder()
                    GetPaidOrderValue(dtable, dtable1, dttable, DataGridView2.Rows.Count, qnt, CType(txtCash.Text, Decimal), CType(txtChange.Text, Decimal), CType(txtKOTDiscountAmount.Text, Decimal), vt, nt, gross, lblPaymentMode.Text)
                    'prntOrder.ShowDialog()
                    vt = gross = nt = qnt = 0
                    ''con = New SqlConnection(cs)
                    ''con.Open()
                    ''cmd = con.CreateCommand()
                    ''cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
                    ''cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
                    ''rdr = cmd.ExecuteReader()
                    ''If rdr.Read() Then
                    ''    s3 = rdr.GetValue(0)
                    ''    rpt.PrintOptions.PrinterName = s3
                    ''    Dim rp As ReportDocument = New ReportDocument()
                    ''    Dim pageMargins As PageMargins
                    ''    pageMargins = rp.PrintOptions.PageMargins
                    ''    rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
                    ''    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelope10
                    ''    frmWPReport_CRViewer.Refresh()
                    ''    frmWPReport_CRViewer.CrystalReportViewer1.Zoom(25)
                    ''    pageMargins.leftMargin = 1
                    ''    pageMargins.rightMargin = 10
                    ''    pageMargins.topMargin = 0
                    ''    pageMargins.bottomMargin = 0
                    ''    rpt.PrintOptions.ApplyPageMargins(pageMargins)
                    ''    rpt.PrintToPrinter(1, False, 0, 0)
                    ''End If
                    ''If (rdr IsNot Nothing) Then
                    ''    rdr.Close()
                    ''End If
                    ''frmWPReport_CRViewer.CrystalReportViewer1.ReportSource = rpt
                    ''frmWPReport_CRViewer.txtEmailID.Text = ""
                    ''frmWPReport_CRViewer.ShowDialog()
                    'rpt.Close()
                    'rpt.Dispose()
                    Reset()
                End If
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Print2Func1()
        Dim CN As New SqlConnection(cs)
        CN.Open()
        adp = New SqlDataAdapter()
        adp.SelectCommand = New SqlCommand("SELECT DISTINCT RTRIM(Kitchen.Kitchenname) FROM Category INNER JOIN Kitchen ON Category.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductBillTA ON Category.CategoryName = RestaurantPOS_OrderedProductBillTA.Category INNER JOIN RestaurantPOS_BillingInfoTA ON RestaurantPOS_OrderedProductBillTA.BillID = RestaurantPOS_BillingInfoTA.ID where BillNo='" & lblBillNo1.Text & "'", CN)
        ds = New DataSet("ds")
        adp.Fill(ds)
        Dim dtable As DataTable = ds.Tables(0)
        CBox.Items.Clear()
        For Each drow As DataRow In dtable.Rows
            CBox.Items.Add(drow(0).ToString())
        Next
        For Each item As String In CBox.Items
            Cursor = Cursors.WaitCursor
            Timer4.Enabled = True
            Dim rpt As New rptRestaurantPOSTAInvoice_Kitchen 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT distinct ODN, BillNote,SCPer,SCAmount,RestaurantPOS_OrderedProductBillTA.OP_ID,RestaurantPOS_OrderedProductBillTA.Notes,Operator,PaymentMode,CurrencyCode,ParcelCharges,SubTotal, RestaurantPOS_OrderedProductBillTA.BillID, RestaurantPOS_OrderedProductBillTA.Dish, RestaurantPOS_OrderedProductBillTA.VATPer,RestaurantPOS_OrderedProductBillTA.VATAmount, RestaurantPOS_OrderedProductBillTA.STPer, RestaurantPOS_OrderedProductBillTA.STAmount, RestaurantPOS_OrderedProductBillTA.DiscountPer, RestaurantPOS_OrderedProductBillTA.DiscountAmount,RestaurantPOS_OrderedProductBillTA.Rate, RestaurantPOS_OrderedProductBillTA.Quantity, RestaurantPOS_OrderedProductBillTA.Amount, RestaurantPOS_OrderedProductBillTA.TotalAmount,RestaurantPOS_BillingInfoTA.ID, RestaurantPOS_BillingInfoTA.BillNo, RestaurantPOS_BillingInfoTA.BillDate, RestaurantPOS_BillingInfoTA.GrandTotal,Cash,Change FROM Category INNER JOIN Kitchen ON Category.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductBillTA ON Category.CategoryName = RestaurantPOS_OrderedProductBillTA.Category INNER JOIN RestaurantPOS_BillingInfoTA ON RestaurantPOS_OrderedProductBillTA.BillID = RestaurantPOS_BillingInfoTA.ID where BillNo='" & lblBillNo1.Text & "' and KitchenName=@d1"
            MyCommand.Parameters.AddWithValue("@d1", item)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_BillingInfoTA")
            myDA.Fill(myDS, "Category")
            myDA.Fill(myDS, "Kitchen")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillTA")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(Printer) from Kitchen where KitchenName=@d1 and IsEnabled='Yes'"
            cmd.Parameters.AddWithValue("@d1", item)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s1 = rdr.GetValue(0)
                rpt.PrintOptions.PrinterName = s1
                Dim rp As ReportDocument = New ReportDocument()
                Dim pageMargins As PageMargins
                pageMargins = rp.PrintOptions.PageMargins
                rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelope10
                frmWPReport_CRViewer.Refresh()
                frmWPReport_CRViewer.CrystalReportViewer1.Zoom(25)
                pageMargins.leftMargin = 1
                pageMargins.rightMargin = 10
                pageMargins.topMargin = 0
                pageMargins.bottomMargin = 0
                rpt.PrintOptions.ApplyPageMargins(pageMargins)
                rpt.PrintToPrinter(1, False, 0, 0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            'frmWPReport_CRViewer.CrystalReportViewer1.ReportSource = rpt
            'frmWPReport_CRViewer.txtEmailID.Text = ""
            'frmWPReport_CRViewer.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Next
    End Sub
    Sub Print2Func2()
        Cursor = Cursors.WaitCursor
        Timer4.Enabled = True
        Dim rpt As New rptRestaurantPOSTAInvoice 'The report you created.
        Dim myConnection As SqlConnection
        Dim MyCommand, MyCommand1 As New SqlCommand()
        Dim myDA, myDA1 As New SqlDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New SqlConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT Member_ID,TADiscountAmt,ODN, PhoneNo,BillNote,RestaurantPOS_OrderedProductBillTA.OP_ID,SCPer,SCAmount,Operator,Notes,PaymentMode,ParcelCharges,SubTotal,CurrencyCode, RestaurantPOS_OrderedProductBillTA.BillID, RestaurantPOS_OrderedProductBillTA.Dish, RestaurantPOS_OrderedProductBillTA.VATPer,RestaurantPOS_OrderedProductBillTA.VATAmount, RestaurantPOS_OrderedProductBillTA.STPer, RestaurantPOS_OrderedProductBillTA.STAmount, RestaurantPOS_OrderedProductBillTA.DiscountPer, RestaurantPOS_OrderedProductBillTA.DiscountAmount,RestaurantPOS_OrderedProductBillTA.Rate, RestaurantPOS_OrderedProductBillTA.Quantity, RestaurantPOS_OrderedProductBillTA.Amount, RestaurantPOS_OrderedProductBillTA.TotalAmount,RestaurantPOS_BillingInfoTA.ID, RestaurantPOS_BillingInfoTA.BillNo, RestaurantPOS_BillingInfoTA.BillDate, RestaurantPOS_BillingInfoTA.GrandTotal,RestaurantPOS_BillingInfoTA.Cash,RestaurantPOS_BillingInfoTA.Change FROM RestaurantPOS_OrderedProductBillTA INNER JOIN  RestaurantPOS_BillingInfoTA ON RestaurantPOS_OrderedProductBillTA.BillID = RestaurantPOS_BillingInfoTA.ID where RestaurantPOS_BillingInfoTA.ID=" & txtBillID1.Text & ""
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "RestaurantPOS_BillingInfoTA")
        myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillTA")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        If lblPaymentMode1.Text = "Credit Customer" Then
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(Name) from CreditCustomer where CreditCustomerID=@d1"
            cmd.Parameters.AddWithValue("@d1", lblMemberID.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                lblCustNameVAL.Text = rdr.GetValue(0).ToString()
            Else
                lblCustNameVAL.Text = ""
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            rpt.SetParameterValue("p1", lblCustNameVAL.Text)
        Else
            rpt.SetParameterValue("p1", "")
        End If

        con = New SqlConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
        cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        's2 = rdr.GetValue(0)
        'rpt.PrintOptions.PrinterName = s2
        'Dim rp As ReportDocument = New ReportDocument()
        'Dim pageMargins As PageMargins
        'pageMargins = rp.PrintOptions.PageMargins
        'rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
        'rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelope10
        'frmWPReport_CRViewer.Refresh()
        'frmWPReport_CRViewer.CrystalReportViewer1.Zoom(25)
        'pageMargins.leftMargin = 1
        'pageMargins.rightMargin = 10
        'pageMargins.topMargin = 0
        'pageMargins.bottomMargin = 0
        'rpt.PrintOptions.ApplyPageMargins(pageMargins)
        'rpt.PrintToPrinter(1, False, 0, 0)
        Dim dttable As DataTable = New DataTable()
        Dim dttt As DataTable = New DataTable()
        Dim s As String = " SELECT top 1 Member_ID,TADiscountAmt,ODN, PhoneNo,BillNote,RestaurantPOS_OrderedProductBillTA.OP_ID,SCPer,SCAmount,Operator,Notes,PaymentMode,ParcelCharges,SubTotal,CurrencyCode, RestaurantPOS_OrderedProductBillTA.BillID, RestaurantPOS_OrderedProductBillTA.Dish, RestaurantPOS_OrderedProductBillTA.VATPer,RestaurantPOS_OrderedProductBillTA.VATAmount, RestaurantPOS_OrderedProductBillTA.STPer, RestaurantPOS_OrderedProductBillTA.STAmount, RestaurantPOS_OrderedProductBillTA.DiscountPer, RestaurantPOS_OrderedProductBillTA.DiscountAmount,RestaurantPOS_OrderedProductBillTA.Rate, RestaurantPOS_OrderedProductBillTA.Quantity, RestaurantPOS_OrderedProductBillTA.Amount, RestaurantPOS_OrderedProductBillTA.TotalAmount,RestaurantPOS_BillingInfoTA.ID, RestaurantPOS_BillingInfoTA.BillNo as TicketNo, RestaurantPOS_BillingInfoTA.BillDate, RestaurantPOS_BillingInfoTA.GrandTotal,RestaurantPOS_BillingInfoTA.Cash,RestaurantPOS_BillingInfoTA.Change FROM RestaurantPOS_OrderedProductBillTA INNER JOIN  RestaurantPOS_BillingInfoTA ON RestaurantPOS_OrderedProductBillTA.BillID = RestaurantPOS_BillingInfoTA.ID where RestaurantPOS_BillingInfoTA.ID=" & txtBillID1.Text & ""
        cmd = New SqlCommand(s, myConnection)
        cmd.CommandType = CommandType.Text
        'cmd.Parameters.AddWithValue("@d1", item)
        Dim sdaa As New SqlDataAdapter(cmd)
        sdaa.Fill(dttt)
        dttable.Columns.Add("T_ID")
        dttable.Columns.Add("SupplierID")
        dttable.Columns.Add("TransactionID")
        dttable.Columns.Add("Amount")
        Dim qnt As Integer
        Dim vt, gross, nt, oddiscount As Decimal
        For index As Integer = 0 To DataGridView3.Rows.Count - 1
            dttable.Rows.Add(DataGridView3.Rows(index).Cells(0).Value, (DataGridView3.Rows(index).Cells(3).Value / DataGridView3.Rows(index).Cells(2).Value), DataGridView3.Rows(index).Cells(2).Value, DataGridView3.Rows(index).Cells(12).Value)
            qnt += CType((DataGridView3.Rows(index).Cells(2).Value), Integer)
            vt += CType((DataGridView3.Rows(index).Cells(9).Value), Decimal)
            gross += CType((DataGridView3.Rows(index).Cells(12).Value), Decimal)
            oddiscount += CType((DataGridView3.Rows(index).Cells(5).Value), Decimal)
        Next
        nt = gross
        'Dim printTakeAway As frmTakeAway = New frmTakeAway()
        GetTakeAwayValue(myDS.Tables(2), dttt, dttable, DataGridView3.Rows.Count, qnt, 0.00, 0.00, oddiscount, vt, nt, gross, paymentMode)
        'printTakeAway.ShowDialog()
        vt = gross = nt = qnt = 0
        'frmWPReport_CRViewer.CrystalReportViewer1.ReportSource = rpt
        'frmWPReport_CRViewer.txtEmailID.Text = ""
        'frmWPReport_CRViewer.ShowDialog()
        '    rpt.Close()
        'rpt.Dispose()
    End Sub
    Sub Print2()
        Try
            If K1.Text = "Yes" Then
                'Print2Func1()
            End If
            Print2Func2()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Print3Func1()
        Dim CN As New SqlConnection(cs)
        CN.Open()
        adp = New SqlDataAdapter()
        adp.SelectCommand = New SqlCommand("SELECT DISTINCT RTRIM(Kitchen.Kitchenname) FROM Category INNER JOIN Kitchen ON Category.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductBillHD ON Category.CategoryName = RestaurantPOS_OrderedProductBillHD.Category INNER JOIN RestaurantPOS_BillingInfoHD ON RestaurantPOS_OrderedProductBillHD.BillID = RestaurantPOS_BillingInfoHD.ID where BillNo='" & lblBillNo2.Text & "'", CN)
        ds = New DataSet("ds")
        adp.Fill(ds)
        Dim dtable As DataTable = ds.Tables(0)
        CBox.Items.Clear()
        For Each drow As DataRow In dtable.Rows
            CBox.Items.Add(drow(0).ToString())
        Next
        For Each item As String In CBox.Items
            Cursor = Cursors.WaitCursor
            Timer4.Enabled = True
            Dim rpt As New rptRestaurantPOSHDInvoice_Kitchen 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT ODN,BillNote,RestaurantPOS_BillingInfoHD.Id,SCPer,SCAmount, RestaurantPOS_BillingInfoHD.BillNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.Operator, RestaurantPOS_BillingInfoHD.SubTotal,RestaurantPOS_BillingInfoHD.HomeDeliveryCharges, RestaurantPOS_BillingInfoHD.GrandTotal, RestaurantPOS_BillingInfoHD.CustomerName, RestaurantPOS_BillingInfoHD.Address,RestaurantPOS_BillingInfoHD.ContactNo, RestaurantPOS_BillingInfoHD.Employee_ID, RestaurantPOS_BillingInfoHD.PaymentMode, RestaurantPOS_OrderedProductBillHD.OP_ID,RestaurantPOS_OrderedProductBillHD.BillID, RestaurantPOS_OrderedProductBillHD.Dish, RestaurantPOS_OrderedProductBillHD.Rate, RestaurantPOS_OrderedProductBillHD.Quantity, RestaurantPOS_OrderedProductBillHD.Amount, RestaurantPOS_OrderedProductBillHD.VATPer, RestaurantPOS_OrderedProductBillHD.VATAmount, RestaurantPOS_OrderedProductBillHD.STPer, RestaurantPOS_OrderedProductBillHD.STAmount, RestaurantPOS_OrderedProductBillHD.DiscountPer, RestaurantPOS_OrderedProductBillHD.DiscountAmount, RestaurantPOS_OrderedProductBillHD.TotalAmount, RestaurantPOS_OrderedProductBillHD.Notes, EmployeeRegistration.EmpId, EmployeeRegistration.EmployeeID, EmployeeRegistration.EmployeeName,EmployeeRegistration.Address AS Expr1, EmployeeRegistration.City, EmployeeRegistration.ContactNo AS Expr2, EmployeeRegistration.Email, EmployeeRegistration.DateOfJoining,EmployeeRegistration.Active, Category.CategoryName,Kitchen.Kitchenname, Kitchen.Printer, Kitchen.IsEnabled FROM RestaurantPOS_BillingInfoHD INNER JOIN RestaurantPOS_OrderedProductBillHD ON RestaurantPOS_BillingInfoHD.Id = RestaurantPOS_OrderedProductBillHD.BillID INNER JOIN EmployeeRegistration ON RestaurantPOS_BillingInfoHD.Employee_ID = EmployeeRegistration.EmpId INNER JOIN Category ON RestaurantPOS_OrderedProductBillHD.Category = Category.CategoryName INNER JOIN Kitchen ON Category.Kitchen = Kitchen.Kitchenname where BillNo='" & lblBillNo2.Text & "' and KitchenName=@d1"
            MyCommand.Parameters.AddWithValue("@d1", item)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_BillingInfoHD")
            myDA.Fill(myDS, "Category")
            myDA.Fill(myDS, "Kitchen")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillHD")
            myDA.Fill(myDS, "EmployeeRegistration")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(Printer) from Kitchen where KitchenName=@d1 and IsEnabled='Yes'"
            cmd.Parameters.AddWithValue("@d1", item)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s1 = rdr.GetValue(0)
                rpt.PrintOptions.PrinterName = s1
                Dim rp As ReportDocument = New ReportDocument()
                Dim pageMargins As PageMargins
                pageMargins = rp.PrintOptions.PageMargins
                rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelope10
                frmWPReport_CRViewer.Refresh()
                frmWPReport_CRViewer.CrystalReportViewer1.Zoom(25)
                pageMargins.leftMargin = 1
                pageMargins.rightMargin = 10
                pageMargins.topMargin = 0
                pageMargins.bottomMargin = 0
                rpt.PrintOptions.ApplyPageMargins(pageMargins)
                rpt.PrintToPrinter(1, False, 0, 0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            'frmWPReport_CRViewer.CrystalReportViewer1.ReportSource = rpt
            'frmWPReport_CRViewer.txtEmailID.Text = ""
            'frmWPReport_CRViewer.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Next
    End Sub
    Sub Print3Func2()
        Cursor = Cursors.WaitCursor
        Timer4.Enabled = True
        Dim rpt As New rptRestaurantPOSHDInvoice 'The report you created.
        Dim myConnection As SqlConnection
        Dim MyCommand, MyCommand1 As New SqlCommand()
        Dim myDA, myDA1 As New SqlDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New SqlConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT Member_ID,ODN,BillNote,RestaurantPOS_BillingInfoHD.Id,SCPer,SCAmount, RestaurantPOS_BillingInfoHD.BillNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.Operator, RestaurantPOS_BillingInfoHD.SubTotal,RestaurantPOS_BillingInfoHD.HomeDeliveryCharges, RestaurantPOS_BillingInfoHD.GrandTotal, RestaurantPOS_BillingInfoHD.CustomerName, RestaurantPOS_BillingInfoHD.Address,RestaurantPOS_BillingInfoHD.ContactNo, RestaurantPOS_BillingInfoHD.Employee_ID, RestaurantPOS_BillingInfoHD.PaymentMode, RestaurantPOS_OrderedProductBillHD.OP_ID,RestaurantPOS_OrderedProductBillHD.BillID, RestaurantPOS_OrderedProductBillHD.Dish, RestaurantPOS_OrderedProductBillHD.Rate, RestaurantPOS_OrderedProductBillHD.Quantity, RestaurantPOS_OrderedProductBillHD.Amount, RestaurantPOS_OrderedProductBillHD.VATPer, RestaurantPOS_OrderedProductBillHD.VATAmount, RestaurantPOS_OrderedProductBillHD.STPer, RestaurantPOS_OrderedProductBillHD.STAmount, RestaurantPOS_OrderedProductBillHD.DiscountPer, RestaurantPOS_OrderedProductBillHD.DiscountAmount, RestaurantPOS_OrderedProductBillHD.TotalAmount, RestaurantPOS_OrderedProductBillHD.Notes, EmployeeRegistration.EmpId, EmployeeRegistration.EmployeeID, EmployeeRegistration.EmployeeName,EmployeeRegistration.Address AS Expr1, EmployeeRegistration.City, EmployeeRegistration.ContactNo AS Expr2, EmployeeRegistration.Email, EmployeeRegistration.DateOfJoining,EmployeeRegistration.Active FROM RestaurantPOS_BillingInfoHD INNER JOIN RestaurantPOS_OrderedProductBillHD ON RestaurantPOS_BillingInfoHD.Id = RestaurantPOS_OrderedProductBillHD.BillID INNER JOIN EmployeeRegistration ON RestaurantPOS_BillingInfoHD.Employee_ID = EmployeeRegistration.EmpId where RestaurantPOS_BillingInfoHD.ID=" & txtBillID2.Text & ""
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "RestaurantPOS_BillingInfoHD")
        myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillHD")
        myDA.Fill(myDS, "EmployeeRegistration")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        con = New SqlConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
        cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            's2 = rdr.GetValue(0)
            'rpt.PrintOptions.PrinterName = s2
            'Dim rp As ReportDocument = New ReportDocument()
            'Dim pageMargins As PageMargins
            'pageMargins = rp.PrintOptions.PageMargins
            'rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
            'rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelope10
            'frmWPReport_CRViewer.Refresh()
            'frmWPReport_CRViewer.CrystalReportViewer1.Zoom(25)
            'pageMargins.leftMargin = 1
            'pageMargins.rightMargin = 10
            'pageMargins.topMargin = 0
            'pageMargins.bottomMargin = 0
            'rpt.PrintOptions.ApplyPageMargins(pageMargins)
            'rpt.PrintToPrinter(1, False, 0, 0)
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        'rpt.Close()
        'rpt.Dispose()
        Dim dttable As DataTable = New DataTable()
        Dim dttt As DataTable = New DataTable()
        Dim s As String = " SELECT Member_ID,ODN,BillNote,RestaurantPOS_BillingInfoHD.Id,SCPer,SCAmount, RestaurantPOS_BillingInfoHD.BillNo as TicketNo, RestaurantPOS_BillingInfoHD.BillDate, RestaurantPOS_BillingInfoHD.Operator, RestaurantPOS_BillingInfoHD.SubTotal,RestaurantPOS_BillingInfoHD.HomeDeliveryCharges, RestaurantPOS_BillingInfoHD.GrandTotal, RestaurantPOS_BillingInfoHD.CustomerName, RestaurantPOS_BillingInfoHD.Address,RestaurantPOS_BillingInfoHD.ContactNo, RestaurantPOS_BillingInfoHD.Employee_ID, RestaurantPOS_BillingInfoHD.PaymentMode, RestaurantPOS_OrderedProductBillHD.OP_ID,RestaurantPOS_OrderedProductBillHD.BillID, RestaurantPOS_OrderedProductBillHD.Dish, RestaurantPOS_OrderedProductBillHD.Rate, RestaurantPOS_OrderedProductBillHD.Quantity, RestaurantPOS_OrderedProductBillHD.Amount, RestaurantPOS_OrderedProductBillHD.VATPer, RestaurantPOS_OrderedProductBillHD.VATAmount, RestaurantPOS_OrderedProductBillHD.STPer, RestaurantPOS_OrderedProductBillHD.STAmount, RestaurantPOS_OrderedProductBillHD.DiscountPer, RestaurantPOS_OrderedProductBillHD.DiscountAmount, RestaurantPOS_OrderedProductBillHD.TotalAmount, RestaurantPOS_OrderedProductBillHD.Notes, EmployeeRegistration.EmpId, EmployeeRegistration.EmployeeID, EmployeeRegistration.EmployeeName,EmployeeRegistration.Address AS Expr1, EmployeeRegistration.City, EmployeeRegistration.ContactNo AS Expr2, EmployeeRegistration.Email, EmployeeRegistration.DateOfJoining,EmployeeRegistration.Active FROM RestaurantPOS_BillingInfoHD INNER JOIN RestaurantPOS_OrderedProductBillHD ON RestaurantPOS_BillingInfoHD.Id = RestaurantPOS_OrderedProductBillHD.BillID INNER JOIN EmployeeRegistration ON RestaurantPOS_BillingInfoHD.Employee_ID = EmployeeRegistration.EmpId where RestaurantPOS_BillingInfoHD.ID=" & txtBillID2.Text & ""
        cmd = New SqlCommand(s, myConnection)
        cmd.CommandType = CommandType.Text
        'cmd.Parameters.AddWithValue("@d1", item)
        Dim sdaa As New SqlDataAdapter(cmd)
        sdaa.Fill(dttt)
        dttable.Columns.Add("T_ID")
        dttable.Columns.Add("SupplierID")
        dttable.Columns.Add("TransactionID")
        dttable.Columns.Add("Amount")
        Dim qnt As Integer
        Dim vt, gross, nt, oddiscount As Decimal
        For index As Integer = 0 To DataGridView4.Rows.Count - 1
            dttable.Rows.Add(DataGridView4.Rows(index).Cells(0).Value, (DataGridView4.Rows(index).Cells(3).Value / DataGridView4.Rows(index).Cells(2).Value), DataGridView4.Rows(index).Cells(2).Value, DataGridView4.Rows(index).Cells(12).Value)
            qnt += CType((DataGridView4.Rows(index).Cells(2).Value), Integer)
            vt += CType((DataGridView4.Rows(index).Cells(9).Value), Decimal)
            gross += CType((DataGridView4.Rows(index).Cells(12).Value), Decimal)
            oddiscount += CType((DataGridView4.Rows(index).Cells(5).Value), Decimal)
        Next
        nt = gross
        'Dim printHomeDelivery As frmhmdlv = New frmhmdlv()
        GetHomeDeliveryValue(myDS.Tables(3), dttt, dttable, DataGridView4.Rows.Count, qnt, 0.00, 0.00, oddiscount, vt, CType(txtGrandTotal2.Text, Decimal), gross, txtCustomerName.Text, txtContactNo.Text, txtAddress.Text, txtDeliveryPerson.Text, CType(txtDeliveryCharges.Text, Double), paymentMode)
        'printHomeDelivery.ShowDialog()
        vt = gross = nt = qnt = 0
    End Sub
    Sub Print3()
        Try
            If K2.Text = "Yes" Then
                'Print3Func1()
            End If
            'Print3Func2()
            Print3Func2()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNew1_Click(sender As System.Object, e As System.EventArgs) Handles btnNew1.Click
        Reset1()
    End Sub

    Public Function GrandTotal_Food1() As Double
        Dim sum As Double = 0
        Try
            If DataGridView2.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView2.Rows
                    sum = sum + r.Cells(13).Value
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function

    Private Sub lvTable_ItemChecked(sender As System.Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvTable.ItemChecked
        Try

            If lvTable.CheckedItems.Count <= 1 AndAlso lvTable.CheckedItems.Count > 0 Then
                Dim Condition As String = ""
                Dim Condition1 As String = ""
                For I = 0 To lvTable.CheckedItems.Count - 1

                    Condition += String.Format("'{0}',", lvTable.CheckedItems(I).Text)
                    Condition1 += String.Format("'{0}',", lvTable.CheckedItems(I).SubItems(1).Text)
                Next
                Condition = Condition.Substring(0, Condition.Length - 1)
                Condition1 = Condition1.Substring(0, Condition1.Length - 1)
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select RTRIM(TableNo),RTRIM(Dish),(Rate),Sum(Quantity),Sum(Amount),(DiscountPer), Sum(DiscountAmount), RTRIM(STPer), Sum(STAmount), RTRIM(VATPer), Sum(VATAmount),SCPer,Sum(SCAmount),Sum(TotalAmount),RTRIM(GroupName),(DiscountPer),RTRIM(Category),isnull([isHappyHour],0) as isHappyHour from RestaurantPOS_OrderedProductKOT,RestaurantPOS_OrderInfoKOT where RestaurantPOS_OrderedProductKOT.TicketID=RestaurantPOS_OrderInfoKOT.ID and TableNo in (" & Condition & ") and GroupName in (" & Condition1 & ") and KOT_Status in ('Open','Served','Prepared') group by TableNo,Dish,Rate,DiscountPer,STPer,VATPer,SCPer,GroupName,Category,isHappyHour order by TableNo"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView2.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17))
                End While
                con.Close()
                Dim sqlx As String = "Select distinct RTRIM([Operator]) from RestaurantPOS_OrderedProductKOT,RestaurantPOS_OrderInfoKOT where RestaurantPOS_OrderedProductKOT.TicketID=RestaurantPOS_OrderInfoKOT.ID and TableNo in (" & Condition & ") and GroupName in (" & Condition1 & ") and KOT_Status in ('Open','Served','Prepared')"
                cmd = New SqlCommand(sqlx, con)
                con.Open()
                operatorx = cmd.ExecuteScalar().ToString()
                con.Close()
                txtCash.Text = ""
                txtGrandTotal.Text = GrandTotal_Food1()
                Calc()
                flpKOT.Visible = True
                lblCurrencyKOT.Visible = False
                lblCurrencyValKOT.Visible = False
                lblCurrencyValKOT.Text = ""
                flpKOT.Enabled = True
                FillCurrencyKOT()

            Else
                flpKOT.Visible = False
                DataGridView2.Rows.Clear()
                lblCurrencyKOT.Visible = False
                lblCurrencyValKOT.Visible = False
                lblCurrencyValKOT.Text = ""
                flpKOT.Enabled = True
                txtKOTDiscPer.Text = "0.00"
                txtKOTDiscountAmount.Text = ""
                txtGrandTotal.Text = ""
                txtExchangeRate.Text = 1
                If lblCurrencyValKOT.Text = "" Then
                    txtExchangeRate.Text = 1
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillCurrencyKOT()
        'Try
        '    con = New SqlConnection(cs)
        '    con.Open()
        '    Dim cmdText1 As String = "SELECT Distinct Rate, RTRIM(CurrencyCode) from Currency order by 1"
        '    cmd = New SqlCommand(cmdText1)
        '    cmd.Connection = con
        '    rdr = cmd.ExecuteReader
        '    flpKOT.Controls.Clear()
        '    Do While (rdr.Read())
        '        Dim btn As New Button
        '        btn.Text = Math.Round(Val(txtGrandTotal.Text) / Val(rdr.GetValue(0)), 2) & " " & rdr.GetValue(1)
        '        btn.FlatStyle = FlatStyle.Popup
        '        Dim btnColor As Color = Color.Magenta
        '        btn.BackColor = btnColor
        '        btn.Width = 116
        '        btn.Height = 40
        '        btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '        UserButtons.Add(btn)
        '        flpKOT.Controls.Add(btn)
        '        AddHandler btn.Click, AddressOf Me.btnCurrencyKOT_Click
        '    Loop
        '    con.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub txtCash_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCash.TextChanged
        Calc()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint1.Click
        Try
            If (MessageBox.Show("Do you want to re-print receipt?, if not printing again go to Document and print file manually. Do you want to continue", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                If File.Exists(Path.Combine(pth, "paidOrder.pdf")) Then
                    'localPrint.PdfPrint.SendToPrinter(Path.Combine(pth, pathx))
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDelete1_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete1.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord1()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData1_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData1.Click
        Me.DataGridView2.Rows.Clear()
        frmRestaurantPOSKOTFinalBillRecord.Reset()
        frmRestaurantPOSKOTFinalBillRecord.lblUserType.Text = lblUserType.Text
        frmRestaurantPOSKOTFinalBillRecord.ShowDialog()
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        frmRestaurantPOSKOTRecord.Reset()
        frmRestaurantPOSKOTRecord.lblUserType.Text = lblUserType.Text
        frmRestaurantPOSKOTRecord.ShowDialog()
    End Sub

    Private Sub btnNotes_Click(sender As System.Object, e As System.EventArgs) Handles btnNotes.Click
        frmNotes1.lblSet.Text = "KOT"
        frmNotes1.Reset()
        frmNotes1.ShowDialog()
    End Sub

    Private Sub btnPrint_Click_1(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Try
            If (MessageBox.Show("Do you want to re-print receipt?, if not printing again go to Document and print file manually. Do you want to continue", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                If File.Exists(Path.Combine(pth, "Kitchenorder.pdf")) Then
                    'localPrint.PdfPrint.SendToPrinter(Path.Combine(pth, pathx))
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnChangeTable_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeTable.Click
        Try
            If lblTableNo.Text = "" Then
                MessageBox.Show("Please select table", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select TableNo from R_Table where TableNo=@d1 and BkColor=@d2"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
            cmd.Parameters.AddWithValue("@d2", Color.LightGreen.ToArgb())
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                frmCustomDialog10.ShowDialog()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                lblTableNo.Text = ""
                Return
            End If
            frmAvailableTables.lblTable.Text = lblTableNo.Text.Trim()
            frmAvailableTables.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCash_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCash.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtCash.Text
            Dim selectionStart = Me.txtCash.SelectionStart
            Dim selectionLength = Me.txtCash.SelectionLength

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


    Private Sub btnPlus1_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus1.Click
        Try
            For Each r As DataGridViewRow In Me.DataGridView3.SelectedRows
                FillData1()
                Compute()
                r.Cells(0).Value = r.Cells(0).Value
                r.Cells(1).Value = txtRate_Food.Text
                r.Cells(2).Value = Val(r.Cells(2).Value) + 1
                r.Cells(3).Value = Val(r.Cells(3).Value) + Val(txtAmt_Food.Text)
                r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
                r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtDiscountAmount_Food.Text)
                r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
                r.Cells(7).Value = Val(r.Cells(7).Value) + Val(txtServiceTaxAmount_Food.Text)
                r.Cells(8).Value = Val(txtVATPer_Food.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtVATAmt_Food.Text)
                r.Cells(10).Value = Val(txtSCPer.Text)
                r.Cells(11).Value = Val(r.Cells(11).Value) + Val(txtSCAmount.Text)
                r.Cells(12).Value = Val(r.Cells(12).Value) + Val(txtTotalAmt_Food.Text)
                r.Cells(14).Value = m
                Dim i As Double = 0
                i = GrandTotal_Food2()
                i = Math.Round(i, 2)
                lblBalance1.Text = i
                txtSubTotal1.Text = i
                Calc1()
                ItemDataSubString(r.Cells(0).Value.ToString())
                CustomerDisplay(subt, Val(r.Cells(12).Value), Val(txtGrandTotal1.Text))
                Clear1()
                If r.Cells(2).Value > 1 Then
                    btnMinus1.Enabled = True
                Else
                    btnMinus1.Enabled = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnMinus1_Click(sender As System.Object, e As System.EventArgs) Handles btnMinus1.Click
        Try
            For Each r As DataGridViewRow In Me.DataGridView3.SelectedRows
                FillData1()
                If r.Cells(2).Value = 1 Then
                    btnMinus1.Enabled = False
                    Exit Sub
                End If
                Compute()
                r.Cells(0).Value = r.Cells(0).Value
                r.Cells(1).Value = txtRate_Food.Text
                r.Cells(2).Value = Val(r.Cells(2).Value) - 1
                r.Cells(3).Value = Val(r.Cells(3).Value) - Val(txtAmt_Food.Text)
                r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
                r.Cells(5).Value = Val(r.Cells(5).Value) - Val(txtDiscountAmount_Food.Text)
                r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
                r.Cells(7).Value = Val(r.Cells(7).Value) - Val(txtServiceTaxAmount_Food.Text)
                r.Cells(8).Value = Val(txtVATPer_Food.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) - Val(txtVATAmt_Food.Text)
                r.Cells(10).Value = Val(txtSCPer.Text)
                r.Cells(11).Value = Val(r.Cells(11).Value) - Val(txtSCAmount.Text)
                r.Cells(12).Value = Val(r.Cells(12).Value) - Val(txtTotalAmt_Food.Text)

                r.Cells(14).Value = m
                Dim i As Double = 0
                i = GrandTotal_Food2()
                i = Math.Round(i, 2)
                lblBalance1.Text = i
                txtSubTotal1.Text = i
                Calc1()
                fillCurrencyTA()
                ItemDataSubString(r.Cells(0).Value.ToString())
                CustomerDisplay(subt, Val(r.Cells(12).Value), Val(txtGrandTotal1.Text))
                Clear1()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCancel1_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel1.Click
        Try
            For Each row As DataGridViewRow In DataGridView3.SelectedRows
                DataGridView3.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = GrandTotal_Food2()
            k = Math.Round(k, 2)
            lblBalance1.Text = k
            txtSubTotal1.Text = k
            Compute()
            fillCurrencyTA()
            Calc1()
            Clear2()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave2_Click(sender As System.Object, e As System.EventArgs) Handles btnSave2.Click
        Try
            If DataGridView3.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If lblPaymentMode1.Text = "" Then
                MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblPaymentMode1.Focus()
                Exit Sub
            End If
            If txtParcelCharges.Text = "" Then
                MessageBox.Show("Please enter parcel charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtParcelCharges.Focus()
                Exit Sub
            End If
            If txtCash1.Text = "" Then
                MessageBox.Show("Please enter cash", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCash1.Focus()
                Exit Sub
            End If
            If Val(txtGrandTotal1.Text) < 0 Then
                MessageBox.Show("Grand Total cant't be less than zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If lblPaymentMode1.Text <> "Credit Customer" Then
                If Val(txtGrandTotal1.Text) > Val(txtCash1.Text) Then
                    MessageBox.Show("cash can not be less than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            Dim totals As New Dictionary(Of String, Integer)()
            For i As Integer = 0 To DataGridView3.Rows.Count - 1
                Dim str As String = DataGridView3.Rows(i).Cells(0).Value
                Dim strText() As String
                strText = Split(str, vbCrLf)
                Dim group As String = strText(0)
                Dim qty As Integer = Convert.ToInt32(DataGridView3.Rows(i).Cells(2).Value)
                If totals.ContainsKey(group) = False Then
                    totals.Add(group, qty)
                Else
                    totals(group) += qty
                End If
            Next
            For Each group As String In totals.Keys
                i2 = totals(group)
                Dim con As New SqlConnection(cs)
                con.Open()
                Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_Store where Dish=@d1", con)
                cmd.Parameters.AddWithValue("@d1", group)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()
                da.Fill(ds)
                con.Close()
                If ds.Tables(0).Rows.Count > 0 Then
                    i1 = ds.Tables(0).Rows(0)("Qty")
                    If Val(i2) > Val(i1) Then
                        MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. of item name '" & group & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        DataGridView3.ClearSelection()
                        Clear()
                        Exit Sub
                    End If
                End If
            Next
            For Each row As DataGridViewRow In DataGridView3.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Dish from Recipe where Dish=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        dgw.Rows.Add(rdr(0), rdr(1))
                    End While
                    con.Close()
                    For Each dr As DataGridViewRow In dgw.Rows
                        Dim con As New SqlConnection(cs)
                        con.Open()
                        Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                        cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                        Dim da As New SqlDataAdapter(cmd)
                        Dim ds As DataSet = New DataSet()
                        da.Fill(ds)
                        Dim i1 As Decimal
                        Dim i2 As Integer
                        If DataGridView3.Rows.Count > 1 Then
                            For i = 0 To DataGridView3.RowCount - 2
                                For t = i + 1 To DataGridView3.RowCount - 1
                                    If DataGridView3.Rows(i).Cells(0).Value = DataGridView3.Rows(t).Cells(0).Value Then
                                        i2 += row.Cells(2).Value
                                    End If
                                Next
                            Next
                        Else
                            i2 = row.Cells(2).Value
                        End If
                        If ds.Tables(0).Rows.Count > 0 Then
                            i1 = ds.Tables(0).Rows(0)("Qty")
                            If Val(dr.Cells(1).Value) * Val(i2) > Val(i1) Then
                                MessageBox.Show("Raw Materials are not available to prepare recipe in the kitchen/section for added quantities of item name '" & row.Cells(0).Value & "' in the grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                DataGridView3.ClearSelection()
                                Clear()
                                Exit Sub
                            End If
                        End If
                        con.Close()
                    Next
                End If
            Next

            Settle1()
            For Each row As DataGridViewRow In DataGridView3.Rows
                Dim str As String = row.Cells(0).Value.ToString()
                Dim strText() As String
                strText = Split(str, vbCrLf)
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Dish from temp_Stock_Store where Dish=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", strText(0))
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty - " & Val(row.Cells(2).Value) & " where Dish=@d1"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    cmd.ExecuteReader()
                    con.Close()
                End If
                retrieving.SoldStock(CType(row.Cells(2).Value, Decimal), row.Cells(0).Value.ToString())
            Next
            For Each row As DataGridViewRow In DataGridView3.Rows
                Dim str As String = row.Cells(0).Value.ToString()
                Dim strText() As String
                strText = Split(str, vbCrLf)
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Dish from Recipe where Dish=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", strText(0))
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        dgw.Rows.Add(rdr(0), rdr(1))
                    End While
                    con.Close()
                    RM_ID()
                    RawMaterialUsed(Val(txtRM_ID.Text), lblBillNo1.Text)
                    For Each dr As DataGridViewRow In dgw.Rows
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock_RM set Qty=Qty - " & Val(dr.Cells(1).Value) * Val(row.Cells(2).Value) & " where ProductID=@d1"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    Next
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb3 As String = "insert into RM_Used_Join(RawMaterialID,ProductID,Quantity) VALUES (" & Val(txtRM_ID.Text) & ",@d1,@d2)"
                    cmd = New SqlCommand(cb3)
                    cmd.Connection = con
                    ' Prepare command for repeated execution
                    cmd.Prepare()
                    ' Data to be inserted
                    For Each dr1 As DataGridViewRow In dgw.Rows
                        If Not row.IsNewRow Then
                            cmd.Parameters.AddWithValue("@d1", Val(dr1.Cells(0).Value))
                            cmd.Parameters.AddWithValue("@d2", Val(dr1.Cells(1).Value) * Val(row.Cells(2).Value))
                            cmd.ExecuteNonQuery()
                            cmd.Parameters.Clear()
                        End If
                    Next
                End If
            Next
            auto2()
            OrderNo()
            ODN(lblOrderNo.Text, lblBillNo1.Text)
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into RestaurantPOS_BillingInfoTA( Id,BillNo, BillDate, GrandTotal,Cash,Change,Operator,SubTotal,ParcelCharges,PaymentMode,BillNote,ExchangeRate,CurrencyCode,TADiscountPer,TADiscountAmt,Member_ID,PhoneNo,ODN,TA_Status) Values (" & txtBillID1.Text & ",'" & lblBillNo1.Text & "',@d1," & Val(txtGrandTotal1.Text) & "," & Val(txtCash1.Text) & "," & Val(txtChange1.Text) & ",@d2," & Val(txtSubTotal1.Text) & "," & Val(txtParcelCharges.Text) & ",@d3,@d4," & Val(txtExchangeRate.Text) & ",@d5," & Val(txtTADiscountPer.Text) & ",@d6,@d7,@d8,@d9,'Paid')"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", System.DateTime.Now)
            cmd.Parameters.AddWithValue("@d2", lblUserVAL.Text)
            cmd.Parameters.AddWithValue("@d3", lblPaymentMode1.Text)
            cmd.Parameters.AddWithValue("@d4", txtNotes.Text)
            If lblCurrencyValTA.Text <> "" Then
                cmd.Parameters.AddWithValue("@d5", lblCurrencyValTA.Text)
            Else
                cmd.Parameters.AddWithValue("@d5", str)
            End If
            cmd.Parameters.AddWithValue("@d6", Val(txtTADiscountAmount.Text))
            If lblMemberID.Text = "" Then
                cmd.Parameters.AddWithValue("@d7", "")
            Else
                cmd.Parameters.AddWithValue("@d7", lblMemberID.Text)
            End If
            If txtTAContactNo.Text = "" Then
                cmd.Parameters.AddWithValue("@d8", "")
            Else
                cmd.Parameters.AddWithValue("@d8", txtTAContactNo.Text)
            End If
            cmd.Parameters.AddWithValue("@d9", lblOrderNo.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into RestaurantPOS_OrderedProductBillTA(BillID,Dish,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,SCPer,SCAmount,TotalAmount,Notes,Category) VALUES (" & txtBillID1.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView3.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d13", Val(row.Cells(12).Value))
                    If row.Cells(13).Value = "" Then
                        cmd.Parameters.AddWithValue("@d14", "")
                    Else
                        cmd.Parameters.AddWithValue("@d14", row.Cells(13).Value)
                    End If
                    If row.Cells(15).Value = "" Then
                        cmd.Parameters.AddWithValue("@d15", "")
                    Else
                        cmd.Parameters.AddWithValue("@d15", row.Cells(15).Value)
                    End If
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            GetTransID()
            Dim st As String = "added the new restaurant pos(Takeaway) record having bill no. '" & lblBillNo1.Text & "'"
            LogFunc(lblUserVAL.Text, st)
            con.Close()
            If lblPaymentMode1.Text = "Credit Customer" Then
                LedgerSave(System.DateTime.Today, "Sales A/c", lblBillNo1.Text, "Sales Invoice", 0, Val(txtGrandTotal1.Text) * Val(txtExchangeRate.Text), "", lblCustNameVAL.Text, cmbTSection.Text)
                LedgerSave(System.DateTime.Today, lblCustNameVAL.Text, lblBillNo1.Text, "POS", Val(txtGrandTotal1.Text) * Val(txtExchangeRate.Text), 0, lblMemberID.Text, "Sales A/c", cmbTSection.Text)
            Else
                LedgerSave(System.DateTime.Today, "Cash", lblBillNo1.Text, "POS", Val(txtGrandTotal1.Text) * Val(txtExchangeRate.Text), 0, "", "Sales A/c", cmbTSection.Text)
                LedgerSave(System.DateTime.Today, "Sales A/c", lblBillNo1.Text, "Sales Invoice", 0, Val(txtGrandTotal1.Text) * Val(txtExchangeRate.Text), "", "Cash", cmbTSection.Text)
            End If
            btnSave2.Enabled = False
            If lblPaymentMode1.Text = "Cash" Then
                OpenCashdrawer()
            End If
            If MessageBox.Show("Do you want to print bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Print2()
            End If
            Reset2()
            Reset2()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNotes1_Click(sender As System.Object, e As System.EventArgs) Handles btnNotes1.Click
        frmNotes1.lblSet.Text = "TA"
        frmNotes1.Reset()
        frmNotes1.ShowDialog()
    End Sub

    Private Sub btnSettle1_Click(sender As System.Object, e As System.EventArgs) Handles btnSettle1.Click
        Try
            If DataGridView3.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Settle1()
            flpCategoriesTA.Enabled = False
            flpItemsTA.Enabled = False
            lblSet.Text = "Not Allowed"
            DataGridView3.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView3_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView3.MouseClick
        If DataGridView3.Rows.Count > 0 Then
            If lblSet.Text = "Not Allowed" Then
                btnPlus1.Enabled = False
                btnCancel1.Enabled = False
                btnChangeRate1.Enabled = False
                btnMinus1.Enabled = False
                btnModifiers1.Enabled = False
                btnChangeQty1.Enabled = False
            Else
                For Each row As DataGridViewRow In DataGridView3.SelectedRows
                    btnPlus1.Enabled = True
                    btnCancel1.Enabled = True
                    btnChangeRate1.Enabled = True
                    btnNotes1.Enabled = True
                    btnChangeQty1.Enabled = True
                    btnModifiers1.Enabled = True
                    If row.Cells(2).Value > 1 Then
                        btnMinus1.Enabled = True
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnNewBill2_Click(sender As System.Object, e As System.EventArgs) Handles btnNewBill2.Click
        Reset2()
        Reset2()
    End Sub

    Private Sub btnDelete2_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete2.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord2()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData2_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData2.Click
        frmRestaurantPOSTARecord.Reset()
        frmRestaurantPOSTARecord.lblUserType.Text = lblUserType.Text
        frmRestaurantPOSTARecord.ShowDialog()
    End Sub

    Private Sub btnTA1_Click(sender As System.Object, e As System.EventArgs) Handles btnTA1.Click
        If txtCash1.ReadOnly = False Then
            If Val(txtCash1.Text) = 0 Then
                txtCash1.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash1.Text = txtCash1.Text + Convert.ToString(1)
            ElseIf sign_Indicator = 1 Then
                txtCash1.Text = Convert.ToString(1)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btnTA2_Click(sender As System.Object, e As System.EventArgs) Handles btnTA2.Click
        If txtCash1.ReadOnly = False Then
            If Val(txtCash1.Text) = 0 Then
                txtCash1.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash1.Text = txtCash1.Text + Convert.ToString(2)
            ElseIf sign_Indicator = 1 Then
                txtCash1.Text = Convert.ToString(2)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btnTA3_Click(sender As System.Object, e As System.EventArgs) Handles btnTA3.Click
        If txtCash1.ReadOnly = False Then
            If Val(txtCash1.Text) = 0 Then
                txtCash1.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash1.Text = txtCash1.Text + Convert.ToString(3)
            ElseIf sign_Indicator = 1 Then
                txtCash1.Text = Convert.ToString(3)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btnTA4_Click(sender As System.Object, e As System.EventArgs) Handles btnTA4.Click
        If txtCash1.ReadOnly = False Then
            If Val(txtCash1.Text) = 0 Then
                txtCash1.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash1.Text = txtCash1.Text + Convert.ToString(4)
            ElseIf sign_Indicator = 1 Then
                txtCash1.Text = Convert.ToString(4)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btnTA5_Click(sender As System.Object, e As System.EventArgs) Handles btnTA5.Click
        If txtCash1.ReadOnly = False Then
            If Val(txtCash1.Text) = 0 Then
                txtCash1.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash1.Text = txtCash1.Text + Convert.ToString(5)
            ElseIf sign_Indicator = 1 Then
                txtCash1.Text = Convert.ToString(5)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btnTA6_Click(sender As System.Object, e As System.EventArgs) Handles btnTA6.Click
        If txtCash1.ReadOnly = False Then
            If Val(txtCash1.Text) = 0 Then
                txtCash1.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash1.Text = txtCash1.Text + Convert.ToString(6)
            ElseIf sign_Indicator = 1 Then
                txtCash1.Text = Convert.ToString(6)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btnTA7_Click(sender As System.Object, e As System.EventArgs) Handles btnTA7.Click
        If txtCash1.ReadOnly = False Then
            If Val(txtCash1.Text) = 0 Then
                txtCash1.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash1.Text = txtCash1.Text + Convert.ToString(7)
            ElseIf sign_Indicator = 1 Then
                txtCash1.Text = Convert.ToString(7)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btnTA8_Click(sender As System.Object, e As System.EventArgs) Handles btnTA8.Click
        If txtCash1.ReadOnly = False Then
            If Val(txtCash1.Text) = 0 Then
                txtCash1.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash1.Text = txtCash1.Text + Convert.ToString(8)
            ElseIf sign_Indicator = 1 Then
                txtCash1.Text = Convert.ToString(8)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btnTA9_Click(sender As System.Object, e As System.EventArgs) Handles btnTA9.Click
        If txtCash1.ReadOnly = False Then
            If Val(txtCash1.Text) = 0 Then
                txtCash1.Text = ""
            End If
            If sign_Indicator = 0 Then
                txtCash1.Text = txtCash1.Text + Convert.ToString(9)
            ElseIf sign_Indicator = 1 Then
                txtCash1.Text = Convert.ToString(9)
                sign_Indicator = 0
            End If
            fl = True
        End If
    End Sub

    Private Sub btnTAComma_Click(sender As System.Object, e As System.EventArgs) Handles btnTAComma.Click
        If txtCash1.ReadOnly = False Then
            Dim i As Integer = 0
            Dim chr As Char = ControlChars.NullChar
            Dim decimal_Indicator As Integer = 0
            Dim l As Integer = txtCash1.Text.Length - 1
            If sign_Indicator <> 1 Then
                For i = 0 To l
                    chr = txtCash1.Text(i)
                    If chr = "."c Then
                        decimal_Indicator = 1
                    End If
                Next

                If decimal_Indicator <> 1 Then
                    txtCash1.Text = txtCash1.Text + Convert.ToString(".")
                End If
            End If
        End If
    End Sub

    Private Sub btnTA0_Click(sender As System.Object, e As System.EventArgs) Handles btnTA0.Click
        If txtCash1.ReadOnly = False Then
            If txtCash1.ReadOnly = False Then
                If sign_Indicator = 0 Then
                    txtCash1.Text = txtCash1.Text + Convert.ToString(0)
                ElseIf sign_Indicator = 1 Then
                    txtCash1.Text = Convert.ToString(0)
                    sign_Indicator = 0
                End If
                fl = True
            End If
        End If
    End Sub

    Private Sub btnTAx_Click(sender As System.Object, e As System.EventArgs) Handles btnTAx.Click
        If txtCash1.ReadOnly = False Then
            s = txtCash1.Text
            Dim l As Integer = s.Length
            For i As Integer = 0 To l - 2
                x += s(i)
            Next
            txtCash1.Text = x
            x = ""
        End If
    End Sub

    Private Sub btnHD1_Click(sender As System.Object, e As System.EventArgs) Handles btnHD1.Click
        If Val(txtDeliveryCharges.Text) = 0 Then
            txtDeliveryCharges.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD2_Click(sender As System.Object, e As System.EventArgs) Handles btnHD2.Click
        If Val(txtDeliveryCharges.Text) = 0 Then
            txtDeliveryCharges.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD3_Click(sender As System.Object, e As System.EventArgs) Handles btnHD3.Click
        If Val(txtDeliveryCharges.Text) = 0 Then
            txtDeliveryCharges.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD4_Click(sender As System.Object, e As System.EventArgs) Handles btnHD4.Click
        If Val(txtDeliveryCharges.Text) = 0 Then
            txtDeliveryCharges.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD5_Click(sender As System.Object, e As System.EventArgs) Handles btnHD5.Click
        If Val(txtDeliveryCharges.Text) = 0 Then
            txtDeliveryCharges.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD6_Click(sender As System.Object, e As System.EventArgs) Handles btnHD6.Click
        If Val(txtDeliveryCharges.Text) = 0 Then
            txtDeliveryCharges.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD7_Click(sender As System.Object, e As System.EventArgs) Handles btnHD7.Click
        If Val(txtDeliveryCharges.Text) = 0 Then
            txtDeliveryCharges.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD8_Click(sender As System.Object, e As System.EventArgs) Handles btnHD8.Click
        If Val(txtDeliveryCharges.Text) = 0 Then
            txtDeliveryCharges.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHD9_Click(sender As System.Object, e As System.EventArgs) Handles btnHD9.Click
        If Val(txtDeliveryCharges.Text) = 0 Then
            txtDeliveryCharges.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHDComma_Click(sender As System.Object, e As System.EventArgs) Handles btnHDComma.Click
        Dim i As Integer = 0
        Dim chr As Char = ControlChars.NullChar
        Dim decimal_Indicator As Integer = 0
        Dim l As Integer = txtDeliveryCharges.Text.Length - 1
        If sign_Indicator <> 1 Then
            For i = 0 To l
                chr = txtDeliveryCharges.Text(i)
                If chr = "."c Then
                    decimal_Indicator = 1
                End If
            Next

            If decimal_Indicator <> 1 Then
                txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(".")
            End If
        End If
    End Sub

    Private Sub btnHD0_Click(sender As System.Object, e As System.EventArgs) Handles btnHD0.Click
        If sign_Indicator = 0 Then
            txtDeliveryCharges.Text = txtDeliveryCharges.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            txtDeliveryCharges.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnHDx_Click(sender As System.Object, e As System.EventArgs) Handles btnHDx.Click
        s = txtDeliveryCharges.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        txtDeliveryCharges.Text = x
        x = ""
    End Sub

    Private Sub btnNotes2_Click(sender As System.Object, e As System.EventArgs) Handles btnNotes2.Click
        frmNotes1.lblSet.Text = "HD"
        frmNotes1.Reset()
        frmNotes1.ShowDialog()
    End Sub


    Private Sub btnDelete3_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete3.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord3()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData3_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData3.Click
        frmRestaurantPOSHDRecord.Reset()
        frmRestaurantPOSHDRecord.lblUserType.Text = lblUserType.Text
        frmRestaurantPOSHDRecord.ShowDialog()
    End Sub

    Private Sub btnNewBill3_Click(sender As System.Object, e As System.EventArgs) Handles btnNewBill3.Click
        Reset3()
        Reset3()
    End Sub

    Private Sub btnSave3_Click(sender As System.Object, e As System.EventArgs) Handles btnSave3.Click
        Try
            If DataGridView4.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txtCustomerName.Text = "" Then
                MessageBox.Show("Please enter customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustomerName.Focus()
                Exit Sub
            End If
            If txtAddress.Text = "" Then
                MessageBox.Show("Please enter address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAddress.Focus()
                Exit Sub
            End If
            If txtContactNo.Text = "" Then
                MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtContactNo.Focus()
                Exit Sub
            End If
            If lblPaymentMode2.Text = "" Then
                MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblPaymentMode2.Focus()
                Exit Sub
            End If
            If txtDeliveryPerson.Text = "" Then
                MessageBox.Show("Please retrieve delivery person", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDeliveryPerson.Focus()
                Exit Sub
            End If
            If txtDeliveryCharges.Text = "" Then
                MessageBox.Show("Please enter delivery charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDeliveryCharges.Focus()
                Exit Sub
            End If
            If Val(txtGrandTotal2.Text) < 0 Then
                MessageBox.Show("Grand Total cant't be less than zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim totals As New Dictionary(Of String, Integer)()
            For i As Integer = 0 To DataGridView4.Rows.Count - 1
                Dim str As String = DataGridView4.Rows(i).Cells(0).Value
                Dim strText() As String
                strText = Split(str, vbCrLf)
                Dim group As String = strText(0)
                Dim qty As Integer = Convert.ToInt32(DataGridView4.Rows(i).Cells(2).Value)
                If totals.ContainsKey(group) = False Then
                    totals.Add(group, qty)
                Else
                    totals(group) += qty
                End If
            Next
            For Each group As String In totals.Keys
                i2 = totals(group)
                Dim con As New SqlConnection(cs)
                con.Open()
                Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_Store where Dish=@d1", con)
                cmd.Parameters.AddWithValue("@d1", group)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()
                da.Fill(ds)
                con.Close()
                If ds.Tables(0).Rows.Count > 0 Then
                    i1 = ds.Tables(0).Rows(0)("Qty")
                    If Val(i2) > Val(i1) Then
                        MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. of item name '" & group & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        DataGridView4.ClearSelection()
                        Clear()
                        Exit Sub
                    End If
                End If
            Next
            For Each row As DataGridViewRow In DataGridView4.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Dish from Recipe where Dish=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        dgw.Rows.Add(rdr(0), rdr(1))
                    End While
                    con.Close()
                    For Each dr As DataGridViewRow In dgw.Rows
                        Dim con As New SqlConnection(cs)
                        con.Open()
                        Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                        cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                        Dim da As New SqlDataAdapter(cmd)
                        Dim ds As DataSet = New DataSet()
                        da.Fill(ds)
                        Dim i1 As Decimal
                        Dim i2 As Integer
                        If DataGridView4.Rows.Count > 1 Then
                            For i = 0 To DataGridView4.RowCount - 2
                                For t = i + 1 To DataGridView4.RowCount - 1
                                    If DataGridView4.Rows(i).Cells(0).Value = DataGridView4.Rows(t).Cells(0).Value Then
                                        i2 += row.Cells(2).Value
                                    End If
                                Next
                            Next
                        Else
                            i2 = row.Cells(2).Value
                        End If
                        If ds.Tables(0).Rows.Count > 0 Then
                            i1 = ds.Tables(0).Rows(0)("Qty")
                            If Val(dr.Cells(1).Value) * Val(i2) > Val(i1) Then
                                MessageBox.Show("Raw Materials are not available to prepare recipe in the kitchen/section for added quantities of item name '" & row.Cells(0).Value & "' in the grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                DataGridView4.ClearSelection()
                                Clear()
                                Exit Sub
                            End If
                        End If
                        con.Close()
                    Next
                End If
            Next
            Settle2()
            For Each row As DataGridViewRow In DataGridView4.Rows
                Dim str As String = row.Cells(0).Value.ToString()
                Dim strText() As String
                strText = Split(str, vbCrLf)
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Dish from temp_Stock_Store where Dish=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", strText(0))
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty - " & Val(row.Cells(2).Value) & " where Dish=@d1"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    cmd.ExecuteReader()
                    con.Close()
                End If
                retrieving.SoldStock(CType(row.Cells(2).Value, Decimal), row.Cells(0).Value.ToString())
            Next
            For Each row As DataGridViewRow In DataGridView4.Rows
                Dim str As String = row.Cells(0).Value.ToString()
                Dim strText() As String
                strText = Split(str, vbCrLf)
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Dish from Recipe where Dish=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", strText(0))
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        dgw.Rows.Add(rdr(0), rdr(1))
                    End While
                    con.Close()
                    RM_ID()
                    RawMaterialUsed(Val(txtRM_ID.Text), lblBillNo2.Text)
                    For Each dr As DataGridViewRow In dgw.Rows
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock_RM set Qty=Qty - " & Val(dr.Cells(1).Value) * Val(row.Cells(2).Value) & " where ProductID=@d1"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    Next
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb3 As String = "insert into RM_Used_Join(RawMaterialID,ProductID,Quantity) VALUES (" & Val(txtRM_ID.Text) & ",@d1,@d2)"
                    cmd = New SqlCommand(cb3)
                    cmd.Connection = con
                    ' Prepare command for repeated execution
                    cmd.Prepare()
                    ' Data to be inserted
                    For Each dr1 As DataGridViewRow In dgw.Rows
                        If Not row.IsNewRow Then
                            cmd.Parameters.AddWithValue("@d1", Val(dr1.Cells(0).Value))
                            cmd.Parameters.AddWithValue("@d2", Val(dr1.Cells(1).Value) * Val(row.Cells(2).Value))
                            cmd.ExecuteNonQuery()
                            cmd.Parameters.Clear()
                        End If
                    Next
                End If
            Next


            auto3()
            OrderNo()
            ODN(lblOrderNo.Text, lblBillNo2.Text)
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into RestaurantPOS_BillingInfoHD( Id,BillNo, BillDate,SubTotal,HomeDeliveryCharges, GrandTotal,Operator,CustomerName,Address,ContactNo,PaymentMode,Employee_ID,BillNote,HDDiscountPer,HDDiscountAmt,Member_ID,ODN,HD_Status) Values (" & txtBillID2.Text & ",'" & lblBillNo2.Text & "',@d1," & Val(txtSubTotal.Text) & "," & Val(txtDeliveryCharges.Text) & "," & Val(txtGrandTotal2.Text) & ",@d2,@d3,@d4,@d5,@d6," & txtDeliveryPersonID.Text & ",@d7," & Val(txtHDDiscountPer.Text) & ",@d8,@d9,@d10,'Confirmed')"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", System.DateTime.Now)
            cmd.Parameters.AddWithValue("@d2", lblUserVAL.Text)
            cmd.Parameters.AddWithValue("@d3", txtCustomerName.Text)
            cmd.Parameters.AddWithValue("@d4", txtAddress.Text)
            cmd.Parameters.AddWithValue("@d5", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d6", lblPaymentMode2.Text)
            cmd.Parameters.AddWithValue("@d7", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d8", Val(txtHDDiscountAmount.Text))
            If lblMemberID.Text = "" Then
                cmd.Parameters.AddWithValue("@d9", "")
            Else
                cmd.Parameters.AddWithValue("@d9", lblMemberID.Text)
            End If
            cmd.Parameters.AddWithValue("@d10", lblOrderNo.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into RestaurantPOS_OrderedProductBillHD(BillID,Dish,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,SCPer,SCAmount,TotalAmount,Notes,Category) VALUES (" & txtBillID2.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView4.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d13", Val(row.Cells(12).Value))
                    If row.Cells(13).Value = "" Then
                        cmd.Parameters.AddWithValue("@d14", "")
                    Else
                        cmd.Parameters.AddWithValue("@d14", row.Cells(13).Value)
                    End If
                    If row.Cells(15).Value = "" Then
                        cmd.Parameters.AddWithValue("@d15", "")
                    Else
                        cmd.Parameters.AddWithValue("@d15", row.Cells(15).Value)
                    End If
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            Dim st As String = "added the new restaurant pos(home delivery) record having bill no. '" & lblBillNo2.Text & "'"
            LogFunc(lblUserVAL.Text, st)
            con.Close()
            GetTransID()
            If lblPaymentMode2.Text = "Credit Customer" Then
                LedgerSave(System.DateTime.Today, "Sales A/c", lblBillNo2.Text, "Sales Invoice", 0, Val(txtGrandTotal2.Text) * Val(txtExchangeRate.Text), "", lblCustNameVAL.Text)
                LedgerSave(System.DateTime.Today, lblCustNameVAL.Text, lblBillNo2.Text, "POS", Val(txtGrandTotal2.Text) * Val(txtExchangeRate.Text), 0, lblMemberID.Text, "Sales A/c")
            Else
                LedgerSave(System.DateTime.Today, "Cash", lblBillNo2.Text, "POS", Val(txtGrandTotal2.Text) * Val(txtExchangeRate.Text), 0, "", "Sales A/c")
                LedgerSave(System.DateTime.Today, "Sales A/c", lblBillNo2.Text, "Sales Invoice", 0, Val(txtGrandTotal2.Text) * Val(txtExchangeRate.Text), "", "Cash")
            End If
            btnSave3.Enabled = False
            If MessageBox.Show("Do you want to print bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Print3()
                'printPDF()
            End If
            If CheckForInternetConnection() = True Then
                Cursor = Cursors.WaitCursor
                Timer4.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                cmd = New SqlCommand(ctn)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    Dim strX1 As String = rdr.GetValue(0)
                    Dim strX2 As String = lblBillNo2.Text
                    strX2 = strX2.Remove(0, 1)
                    Dim st3X As String = "Hello, " & txtCustomerName.Text & " you have successfully placed your order amounting " & Val(txtGrandTotal2.Text) & " having bill no. " & strX2 & "" & vbCrLf & "Thank you for choosing us"
                    SMSFunc(txtContactNo.Text.Trim, st3X, strX1)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                End If
            End If
            Reset3()
            Reset3()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GetTransID()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM MemberLedger")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtTransID.Text = Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtTransID.Text = Num.ToString
        End If
        con.Close()
    End Sub
    Private Sub btnSettle2_Click(sender As System.Object, e As System.EventArgs) Handles btnSettle2.Click
        Try
            If DataGridView4.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Settle2()
            flpCategoriesHD.Enabled = False
            flpItemsHD.Enabled = False
            lblSet.Text = "Not Allowed"
            DataGridView4.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmRestaurantPOS_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Maximized Then
            txtParcelCharges.TextAlign = HorizontalAlignment.Right
            txtSubTotal.TextAlign = HorizontalAlignment.Right
            txtSubTotal1.TextAlign = HorizontalAlignment.Right
            txtGrandTotal1.TextAlign = HorizontalAlignment.Right
            txtDeliveryCharges.TextAlign = HorizontalAlignment.Right
            txtGrandTotal2.TextAlign = HorizontalAlignment.Right
        End If
    End Sub

    Private Sub btnPlus2_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus2.Click
        Try
            For Each r As DataGridViewRow In Me.DataGridView4.SelectedRows
                FillData2()
                Compute()
                r.Cells(0).Value = r.Cells(0).Value
                r.Cells(1).Value = txtRate_Food.Text
                r.Cells(2).Value = Val(r.Cells(2).Value) + 1
                r.Cells(3).Value = Val(r.Cells(3).Value) + Val(txtAmt_Food.Text)
                r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
                r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtDiscountAmount_Food.Text)
                r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
                r.Cells(7).Value = Val(r.Cells(7).Value) + Val(txtServiceTaxAmount_Food.Text)
                r.Cells(8).Value = Val(txtVATPer_Food.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtVATAmt_Food.Text)
                r.Cells(10).Value = Val(txtSCPer.Text)
                r.Cells(11).Value = Val(r.Cells(11).Value) + Val(txtSCAmount.Text)
                r.Cells(12).Value = Val(r.Cells(12).Value) + Val(txtTotalAmt_Food.Text)

                r.Cells(14).Value = m
                Dim i As Double = 0
                i = GrandTotal_Food3()
                i = Math.Round(i, 2)
                lblBalance2.Text = i
                txtSubTotal.Text = i
                Calc2()
                ItemDataSubString(r.Cells(0).Value.ToString())
                CustomerDisplay(subt, Val(r.Cells(12).Value), Val(txtGrandTotal2.Text))
                Clear1()
                If r.Cells(2).Value > 1 Then
                    btnMinus2.Enabled = True
                Else
                    btnMinus2.Enabled = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnMinus2_Click(sender As System.Object, e As System.EventArgs) Handles btnMinus2.Click
        Try
            For Each r As DataGridViewRow In Me.DataGridView4.SelectedRows
                FillData2()
                If r.Cells(2).Value = 1 Then
                    btnMinus2.Enabled = False
                    Exit Sub
                End If
                Compute()
                r.Cells(0).Value = r.Cells(0).Value
                r.Cells(1).Value = txtRate_Food.Text
                r.Cells(2).Value = Val(r.Cells(2).Value) - 1
                r.Cells(3).Value = Val(r.Cells(3).Value) - Val(txtAmt_Food.Text)
                r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
                r.Cells(5).Value = Val(r.Cells(5).Value) - Val(txtDiscountAmount_Food.Text)
                r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
                r.Cells(7).Value = Val(r.Cells(7).Value) - Val(txtServiceTaxAmount_Food.Text)
                r.Cells(8).Value = Val(txtVATPer_Food.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) - Val(txtVATAmt_Food.Text)
                r.Cells(10).Value = Val(txtSCPer.Text)
                r.Cells(11).Value = Val(r.Cells(11).Value) - Val(txtSCAmount.Text)
                r.Cells(12).Value = Val(r.Cells(12).Value) - Val(txtTotalAmt_Food.Text)

                r.Cells(14).Value = m
                Dim i As Double = 0
                i = GrandTotal_Food3()
                i = Math.Round(i, 2)
                lblBalance2.Text = i
                txtSubTotal.Text = i
                Calc2()
                ItemDataSubString(r.Cells(0).Value.ToString())
                CustomerDisplay(subt, Val(r.Cells(12).Value), Val(txtGrandTotal2.Text))
                Clear1()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCancel2_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel2.Click
        Try
            For Each row As DataGridViewRow In DataGridView4.SelectedRows
                DataGridView4.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = GrandTotal_Food3()
            k = Math.Round(k, 2)
            lblBalance2.Text = k
            txtSubTotal.Text = k
            Compute()
            Calc2()
            Clear3()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnChangeRate1_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeRate1.Click
        Try
            frmChangeRate.lblSet.Text = "Takeaway"
            If DataGridView3.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
                frmChangeRate.txtNotes.Text = dr.Cells(13).Value
                frmChangeRate.txtR.Text = txtTADiscountPer.Text
                frmChangeRate.txtCategory.Text = dr.Cells(15).Value
            End If
            frmChangeRate.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub DataGridView4_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView4.MouseClick
        If DataGridView4.Rows.Count > 0 Then
            If lblSet.Text = "Not Allowed" Then
                btnPlus2.Enabled = False
                btnCancel2.Enabled = False
                btnChangeRate2.Enabled = False
                btnMinus2.Enabled = False
                btnModifiers2.Enabled = False
                btnChangeQty2.Enabled = False
            Else
                For Each row As DataGridViewRow In DataGridView4.SelectedRows
                    btnPlus2.Enabled = True
                    btnCancel2.Enabled = True
                    btnChangeRate2.Enabled = True
                    btnNotes2.Enabled = True
                    btnChangeQty2.Enabled = True
                    btnModifiers2.Enabled = True
                    If row.Cells(2).Value > 1 Then
                        btnMinus2.Enabled = True
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub txtGrandTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGrandTotal.TextChanged
        Calc()
    End Sub

    Private Sub txtChange_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtChange.TextChanged
        Calc()
    End Sub

    Private Sub txtCash1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtParcelCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtParcelCharges.Text
            Dim selectionStart = Me.txtParcelCharges.SelectionStart
            Dim selectionLength = Me.txtParcelCharges.SelectionLength

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

    Private Sub txtDeliveryCharges_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeliveryCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDeliveryCharges.Text
            Dim selectionStart = Me.txtDeliveryCharges.SelectionStart
            Dim selectionLength = Me.txtDeliveryCharges.SelectionLength

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

    Private Sub txtSubTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubTotal.TextChanged
        Calc2()
    End Sub

    Private Sub txtDeliveryCharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDeliveryCharges.TextChanged
        Calc2()
    End Sub

    Private Sub txtGrandTotal2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGrandTotal2.TextChanged
        Calc2()
    End Sub

    Private Sub btnPrint2_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint2.Click
        Try
            If (MessageBox.Show("Do you want to re-print receipt?, if not printing again go to Document and print file manually. Do you want to continue", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                If File.Exists(Path.Combine(pth, "takeAway.pdf")) Then
                    'localPrint.PdfPrint.SendToPrinter(Path.Combine(pth, pathx))
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPrint3_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint3.Click
        Try
            If (MessageBox.Show("Do you want to re-print receipt?, if not printing again go to Document and print file manually. Do you want to continue", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                If File.Exists(Path.Combine(pth, "homeDelivery.pdf")) Then
                    'localPrint.PdfPrint.SendToPrinter(Path.Combine(pth, pathx))
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnChangeRate2_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeRate2.Click
        Try
            frmChangeRate.lblSet.Text = "Home Delivery"
            If DataGridView4.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView4.SelectedRows(0)
                frmChangeRate.txtNotes.Text = dr.Cells(13).Value
                frmChangeRate.txtR.Text = txtHDDiscountPer.Text
                frmChangeRate.txtCategory.Text = dr.Cells(15).Value
            End If
            frmChangeRate.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnSelection_Click(sender As System.Object, e As System.EventArgs) Handles btnSelection.Click
        frmCustomersRecord.Reset()
        frmCustomersRecord.ShowDialog()
    End Sub

    Private Sub DataGridView3_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView3.MouseDoubleClick
        If DataGridView3.Rows.Count > 0 Then
            Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
            frmNotes.txtNotes.Text = dr.Cells(13).Value
            frmNotes.lblSet.Text = "TA"
            frmNotes.ShowDialog()
        End If
    End Sub



    Private Sub DataGridView4_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView4.MouseDoubleClick
        If DataGridView4.Rows.Count > 0 Then
            Dim dr As DataGridViewRow = DataGridView4.SelectedRows(0)
            frmNotes.txtNotes.Text = dr.Cells(13).Value
            frmNotes.lblSet.Text = "HD"
            frmNotes.ShowDialog()
        End If
    End Sub

    Private Sub btnChangeQty1_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeQty1.Click
        Try
            frmChangeQty.lblSet.Text = "Takeaway"
            If DataGridView3.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
                frmChangeQty.txtNotes.Text = dr.Cells(13).Value
                frmChangeQty.txtQ.Text = txtTADiscountPer.Text
                frmChangeQty.txtCategory.Text = dr.Cells(15).Value
            End If
            frmChangeQty.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnChangeQty2_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeQty2.Click
        Try
            frmChangeQty.lblSet.Text = "Home Delivery"
            If DataGridView4.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView4.SelectedRows(0)
                frmChangeQty.txtNotes.Text = dr.Cells(13).Value
                frmChangeQty.txtQ.Text = txtHDDiscountPer.Text
                frmChangeQty.txtCategory.Text = dr.Cells(15).Value
            End If
            frmChangeQty.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub OSKeyboard()
        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start("osk.exe")
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start("osk.exe")
        End If
    End Sub
    Private Sub btnChangeQty_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeQty.Click
        Try
            frmChangeQty.lblSet.Text = "KOT"
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                frmChangeQty.txtNotes.Text = dr.Cells(13).Value
                frmChangeQty.txtQ.Text = dr.Cells(14).Value
                frmChangeQty.txtCategory.Text = dr.Cells(15).Value
                frmChangeQty.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCash_Click(sender As System.Object, e As System.EventArgs) Handles btnCash.Click
        txtCash.ReadOnly = False
        lblPaymentMode.Text = btnCash.Text
    End Sub

    Private Sub txtCash1_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txtCash1.TextChanged
        Calc1()
    End Sub

    Private Sub txtChange1_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txtChange1.TextChanged
        Calc1()
    End Sub

    Private Sub btnCash1_Click(sender As System.Object, e As System.EventArgs) Handles btnCash1.Click
        txtCash1.ReadOnly = False
        lblPaymentMode1.Text = btnCash1.Text
        paymentMode = "Cash"
    End Sub

    Private Sub txtCash1_KeyPress_1(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCash1.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtCash1.Text
            Dim selectionStart = Me.txtCash1.SelectionStart
            Dim selectionLength = Me.txtCash1.SelectionLength

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

    Private Sub btnCash2_Click(sender As System.Object, e As System.EventArgs) Handles btnCash2.Click
        lblPaymentMode2.Text = btnCash2.Text
    End Sub

    Private Sub btnSelection1_Click(sender As System.Object, e As System.EventArgs) Handles btnSelection1.Click
        frmDeliveryPersonRecord.Reset()
        frmDeliveryPersonRecord.ShowDialog()
    End Sub

    Private Sub btnOpenTickets_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenTickets.Click
        frmOpenTicketsRecord.Reset()
        frmOpenTicketsRecord.lblUserType.Text = lblUserType.Text
        frmOpenTicketsRecord.ShowDialog()
    End Sub

    Private Sub DataGridView1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            frmNotes.txtNotes.Text = dr.Cells(13).Value
            frmNotes.lblSet.Text = "KOT"
            frmNotes.ShowDialog()
        End If
    End Sub
    Sub fillCurrencyTA()
        Try
            'If DataGridView3.Rows.Count > 0 Then
            '    flpTA.Visible = True
            '    lblCurrencyTA.Visible = False
            '    lblCurrencyValTA.Visible = False
            '    lblCurrencyValTA.Text = ""
            '    con = New SqlConnection(cs)
            '    con.Open()
            '    Dim cmdText1 As String = "SELECT Distinct Rate, RTRIM(CurrencyCode) from Currency order by 1"
            '    cmd = New SqlCommand(cmdText1)
            '    cmd.Connection = con
            '    rdr = cmd.ExecuteReader
            '    flpTA.Controls.Clear()
            '    Do While (rdr.Read())
            '        Dim btn As New Button
            '        btn.Text = Math.Round(Val(txtSubTotal1.Text) / Val(rdr.GetValue(0)), 2) & " " & rdr.GetValue(1)
            '        btn.FlatStyle = FlatStyle.Popup
            '        Dim btnColor As Color = Color.Magenta
            '        btn.BackColor = btnColor
            '        btn.Width = 100
            '        btn.Height = 30
            '        btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            '        UserButtons.Add(btn)
            '        flpTA.Controls.Add(btn)
            '        AddHandler btn.Click, AddressOf Me.btnCurrencyTA_Click
            '    Loop
            '    con.Close()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillCurrencyEB()
        'Try
        '    If DataGridView5.Rows.Count > 0 Then
        '        flpEB.Visible = True
        '        lblCurrencyEB.Visible = False
        '        lblCurrencyValEB.Visible = False
        '        lblCurrencyValEB.Text = ""
        '        con = New SqlConnection(cs)
        '        con.Open()
        '        Dim cmdText1 As String = "SELECT Distinct Rate, RTRIM(CurrencyCode) from Currency order by 1"
        '        cmd = New SqlCommand(cmdText1)
        '        cmd.Connection = con
        '        rdr = cmd.ExecuteReader
        '        flpEB.Controls.Clear()
        '        Do While (rdr.Read())
        '            Dim btn As New Button
        '            btn.Text = Math.Round(Val(txtGrandTotal3.Text) / Val(rdr.GetValue(0)), 2) & " " & rdr.GetValue(1)
        '            btn.FlatStyle = FlatStyle.Popup
        '            Dim btnColor As Color = Color.Magenta
        '            btn.BackColor = btnColor
        '            btn.Width = 100
        '            btn.Height = 30
        '            btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '            UserButtons.Add(btn)
        '            flpEB.Controls.Add(btn)
        '            AddHandler btn.Click, AddressOf Me.btnCurrencyEB_Click
        '        Loop
        '        con.Close()
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub lblBalance1_TextChanged(sender As System.Object, e As System.EventArgs) Handles lblBalance1.TextChanged
        fillCurrencyTA()
    End Sub
    Private Sub btnCurrencyTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            btnRevert1.Visible = True
            lblCurrencyValTA.Text = ""
            DataGridView3.Enabled = False
            flpItemsTA.Enabled = False
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text.Trim()
            Dim strText() As String
            strText = str.Split(" ")
            txtCash1.Text = ""
            lblBalance1.Text = str(0)
            txtSubTotal1.Text = str(0)
            GetExchangeRate(strText(1))
            txtParcelCharges.Text = Math.Round(Val(txtParcelCharges.Text) / Val(txtExchangeRate.Text), 2)
            For Each row As DataGridViewRow In DataGridView3.Rows
                row.Cells(1).Value = Math.Round(Val(row.Cells(1).Value) / Val(txtExchangeRate.Text), 2)
                row.Cells(3).Value = Math.Round(Val(row.Cells(3).Value) / Val(txtExchangeRate.Text), 2)
                row.Cells(5).Value = Math.Round(Val(row.Cells(5).Value) / Val(txtExchangeRate.Text), 2)
                row.Cells(7).Value = Math.Round(Val(row.Cells(7).Value) / Val(txtExchangeRate.Text), 2)
                row.Cells(9).Value = Math.Round(Val(row.Cells(9).Value) / Val(txtExchangeRate.Text), 2)
                row.Cells(11).Value = Math.Round(Val(row.Cells(11).Value) / Val(txtExchangeRate.Text), 2)
                row.Cells(12).Value = Math.Round(Val(row.Cells(12).Value) / Val(txtExchangeRate.Text), 2)
            Next
            lblBalance1.Text = GrandTotal_Food2()
            txtSubTotal1.Text = GrandTotal_Food2()
            lblCurrencyTA.Visible = True
            lblCurrencyValTA.Visible = True
            lblCurrencyValTA.Text = strText(1).Trim()
            flpTA.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnCurrencyEB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'flpEB.Enabled = False
            'btnRevert2.Visible = True
            'lblCurrencyValEB.Text = ""
            'DataGridView5.Enabled = False
            'flpItemsEB.Enabled = False
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text.Trim()
            Dim strText() As String
            strText = str.Split(" ")
            'txtCash3.Text = "0.00"
            'lblBalance3.Text = strText(0)
            'txtGrandTotal3.Text = strText(0)
            GetExchangeRate(strText(1))
            'For Each row As DataGridViewRow In DataGridView5.Rows
            '    row.Cells(1).Value = Math.Round(Val(row.Cells(1).Value) / Val(txtExchangeRate.Text), 2)
            '    row.Cells(3).Value = Math.Round(Val(row.Cells(3).Value) / Val(txtExchangeRate.Text), 2)
            '    row.Cells(5).Value = Math.Round(Val(row.Cells(5).Value) / Val(txtExchangeRate.Text), 2)
            '    row.Cells(7).Value = Math.Round(Val(row.Cells(7).Value) / Val(txtExchangeRate.Text), 2)
            '    row.Cells(9).Value = Math.Round(Val(row.Cells(9).Value) / Val(txtExchangeRate.Text), 2)
            '    row.Cells(11).Value = Math.Round(Val(row.Cells(11).Value) / Val(txtExchangeRate.Text), 2)
            '    row.Cells(12).Value = Math.Round(Val(row.Cells(12).Value) / Val(txtExchangeRate.Text), 2)
            'Next
            'lblCurrencyEB.Visible = True
            'lblCurrencyValEB.Visible = True
            'lblCurrencyValEB.Text = strText(1).Trim()
            'flpEB.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub ClearCash()
        'If Val(txtCash3.Text) = 0 Then
        '    txtCash3.Text = ""
        'End If
    End Sub
    Private Sub btnEB1_Click(sender As System.Object, e As System.EventArgs)
        'If txtCash3.ReadOnly = False Then
        '    ClearCash()
        '    If sign_Indicator = 0 Then
        '        txtCash3.Text = txtCash3.Text + Convert.ToString(1)
        '    ElseIf sign_Indicator = 1 Then
        '        txtCash3.Text = Convert.ToString(1)
        '        sign_Indicator = 0
        '    End If
        '    fl = True
        'End If
    End Sub

    Private Sub btnEB2_Click(sender As System.Object, e As System.EventArgs)
        'If txtCash3.ReadOnly = False Then
        '    ClearCash()
        '    If sign_Indicator = 0 Then
        '        txtCash3.Text = txtCash3.Text + Convert.ToString(2)
        '    ElseIf sign_Indicator = 1 Then
        '        txtCash3.Text = Convert.ToString(2)
        '        sign_Indicator = 0
        '    End If
        '    fl = True
        'End If
    End Sub

    Private Sub btnEB3_Click(sender As System.Object, e As System.EventArgs)
        'If txtCash3.ReadOnly = False Then
        '    ClearCash()
        '    If sign_Indicator = 0 Then
        '        txtCash3.Text = txtCash3.Text + Convert.ToString(3)
        '    ElseIf sign_Indicator = 1 Then
        '        txtCash3.Text = Convert.ToString(3)
        '        sign_Indicator = 0
        '    End If
        '    fl = True
        'End If
    End Sub

    Private Sub btnEB4_Click(sender As System.Object, e As System.EventArgs)
        'If txtCash3.ReadOnly = False Then
        '    ClearCash()
        '    If sign_Indicator = 0 Then
        '        txtCash3.Text = txtCash3.Text + Convert.ToString(4)
        '    ElseIf sign_Indicator = 1 Then
        '        txtCash3.Text = Convert.ToString(4)
        '        sign_Indicator = 0
        '    End If
        '    fl = True
        'End If
    End Sub

    Private Sub btnEB5_Click(sender As System.Object, e As System.EventArgs)
        'If txtCash3.ReadOnly = False Then
        '    ClearCash()
        '    If sign_Indicator = 0 Then
        '        txtCash3.Text = txtCash3.Text + Convert.ToString(5)
        '    ElseIf sign_Indicator = 1 Then
        '        txtCash3.Text = Convert.ToString(5)
        '        sign_Indicator = 0
        '    End If
        '    fl = True
        'End If
    End Sub

    Private Sub btnEB6_Click(sender As System.Object, e As System.EventArgs)
        'If txtCash3.ReadOnly = False Then
        '    ClearCash()
        '    If sign_Indicator = 0 Then
        '        txtCash3.Text = txtCash3.Text + Convert.ToString(6)
        '    ElseIf sign_Indicator = 1 Then
        '        txtCash3.Text = Convert.ToString(6)
        '        sign_Indicator = 0
        '    End If
        '    fl = True
        'End If
    End Sub

    Private Sub btnEB7_Click(sender As System.Object, e As System.EventArgs)
        'If txtCash3.ReadOnly = False Then
        '    ClearCash()
        '    If sign_Indicator = 0 Then
        '        txtCash3.Text = txtCash3.Text + Convert.ToString(7)
        '    ElseIf sign_Indicator = 1 Then
        '        txtCash3.Text = Convert.ToString(7)
        '        sign_Indicator = 0
        '    End If
        '    fl = True
        'End If
    End Sub

    Private Sub btnEB8_Click(sender As System.Object, e As System.EventArgs)
        'If txtCash3.ReadOnly = False Then
        '    If sign_Indicator = 0 Then
        '        txtCash3.Text = txtCash3.Text + Convert.ToString(8)
        '    ElseIf sign_Indicator = 1 Then
        '        txtCash3.Text = Convert.ToString(8)
        '        sign_Indicator = 0
        '    End If
        '    fl = True
        'End If
    End Sub

    Private Sub btnEB9_Click(sender As System.Object, e As System.EventArgs)
        'If txtCash3.ReadOnly = False Then
        '    ClearCash()
        '    If sign_Indicator = 0 Then
        '        txtCash3.Text = txtCash3.Text + Convert.ToString(9)
        '    ElseIf sign_Indicator = 1 Then
        '        txtCash3.Text = Convert.ToString(9)
        '        sign_Indicator = 0
        '    End If
        '    fl = True
        'End If
    End Sub

    Private Sub btnEBDot_Click(sender As System.Object, e As System.EventArgs)
        'If txtCash3.ReadOnly = False Then
        '    ClearCash()
        '    Dim i As Integer = 0
        '    Dim chr As Char = ControlChars.NullChar
        '    Dim decimal_Indicator As Integer = 0
        '    Dim l As Integer = txtCash3.Text.Length - 1
        '    If sign_Indicator <> 1 Then
        '        For i = 0 To l
        '            chr = txtCash3.Text(i)
        '            If chr = "."c Then
        '                decimal_Indicator = 1
        '            End If
        '        Next

        '        If decimal_Indicator <> 1 Then
        '            txtCash3.Text = txtCash3.Text + Convert.ToString(".")
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub btnEB0_Click(sender As System.Object, e As System.EventArgs)
        'If txtCash3.ReadOnly = False Then
        '    ClearCash()
        '    If sign_Indicator = 0 Then
        '        txtCash3.Text = txtCash3.Text + Convert.ToString(0)
        '    ElseIf sign_Indicator = 1 Then
        '        txtCash3.Text = Convert.ToString(0)
        '        sign_Indicator = 0
        '    End If
        '    fl = True
        'End If
    End Sub

    Private Sub btnEBx_Click(sender As System.Object, e As System.EventArgs)
        'If txtCash3.ReadOnly = False Then
        '    s = txtCash3.Text
        '    Dim l As Integer = s.Length
        '    For i As Integer = 0 To l - 2
        '        x += s(i)
        '    Next
        '    txtCash3.Text = x
        '    x = ""
        'End If
    End Sub

    Private Sub btnDelete4_Click(sender As System.Object, e As System.EventArgs)
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord4()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNewBill4_Click(sender As System.Object, e As System.EventArgs)
        Reset4()
        Reset4()
    End Sub

    Private Sub DataGridView5_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        'If DataGridView5.Rows.Count > 0 Then
        '    If lblSet.Text = "Not Allowed" Then
        '        btnPlus3.Enabled = False
        '        btnCancel3.Enabled = False
        '        btnChangeRate3.Enabled = False
        '        btnMinus3.Enabled = False
        '        btnChangeQty3.Enabled = False
        '        btnModifiers3.Enabled = False
        '    Else
        '        For Each row As DataGridViewRow In DataGridView5.SelectedRows
        '            btnPlus3.Enabled = True
        '            btnCancel3.Enabled = True
        '            btnChangeRate3.Enabled = True
        '            btnNotes3.Enabled = True
        '            btnChangeQty3.Enabled = True
        '            btnModifiers3.Enabled = True
        '            If row.Cells(2).Value > 1 Then
        '                btnMinus3.Enabled = True
        '            End If
        '        Next
        '    End If
        'End If
    End Sub

    Private Sub DataGridView5_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        'If DataGridView5.Rows.Count > 0 Then
        '    Dim dr As DataGridViewRow = DataGridView5.SelectedRows(0)
        '    frmNotes.txtNotes.Text = dr.Cells(13).Value
        '    frmNotes.lblSet.Text = "EB"
        '    frmNotes.ShowDialog()
        'End If
    End Sub

    Private Sub btnNotes3_Click(sender As System.Object, e As System.EventArgs)
        frmNotes1.lblSet.Text = "EB"
        frmNotes1.Reset()
        frmNotes1.ShowDialog()
    End Sub


    Private Sub lblBalance3_TextChanged(sender As System.Object, e As System.EventArgs)
        fillCurrencyEB()
    End Sub

    Private Sub btnPlus3_Click(sender As System.Object, e As System.EventArgs)
        Try
            'For Each r As DataGridViewRow In Me.DataGridView5.SelectedRows
            '    FillData3()
            '    Compute()
            '    r.Cells(0).Value = r.Cells(0).Value
            '    r.Cells(1).Value = txtRate_Food.Text
            '    r.Cells(2).Value = Val(r.Cells(2).Value) + 1
            '    r.Cells(3).Value = Val(r.Cells(3).Value) + Val(txtAmt_Food.Text)
            '    r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
            '    r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtDiscountAmount_Food.Text)
            '    r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
            '    r.Cells(7).Value = Val(r.Cells(7).Value) + Val(txtServiceTaxAmount_Food.Text)
            '    r.Cells(8).Value = Val(txtVATPer_Food.Text)
            '    r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtVATAmt_Food.Text)
            '    r.Cells(10).Value = Val(txtSCPer.Text)
            '    r.Cells(11).Value = Val(r.Cells(11).Value) + Val(txtSCAmount.Text)
            '    r.Cells(12).Value = Val(r.Cells(12).Value) + Val(txtTotalAmt_Food.Text)

            '    r.Cells(14).Value = m
            '    Dim i As Double = 0
            '    i = GrandTotal_Food4()
            '    i = Math.Round(i, 2)
            '    lblBalance3.Text = i
            '    txtGrandTotal3.Text = i
            '    Calc3()
            '    fillCurrencyEB()
            '    ItemDataSubString(r.Cells(0).Value.ToString())
            '    CustomerDisplay(subt, Val(r.Cells(12).Value), Val(txtGrandTotal3.Text))
            '    Clear1()

            '    If r.Cells(2).Value > 1 Then
            '        btnMinus3.Enabled = True
            '    Else
            '        btnMinus3.Enabled = False
            '    End If
            'Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnMinus3_Click(sender As System.Object, e As System.EventArgs)
        Try
            'For Each r As DataGridViewRow In Me.DataGridView5.SelectedRows
            '    FillData3()
            '    If r.Cells(2).Value = 1 Then
            '        btnMinus3.Enabled = False
            '        Exit Sub
            '    End If
            '    Compute()
            '    r.Cells(0).Value = r.Cells(0).Value
            '    r.Cells(1).Value = txtRate_Food.Text
            '    r.Cells(2).Value = Val(r.Cells(2).Value) - 1
            '    r.Cells(3).Value = Val(r.Cells(3).Value) - Val(txtAmt_Food.Text)
            '    r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
            '    r.Cells(5).Value = Val(r.Cells(5).Value) - Val(txtDiscountAmount_Food.Text)
            '    r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
            '    r.Cells(7).Value = Val(r.Cells(7).Value) - Val(txtServiceTaxAmount_Food.Text)
            '    r.Cells(8).Value = Val(txtVATPer_Food.Text)
            '    r.Cells(9).Value = Val(r.Cells(9).Value) - Val(txtVATAmt_Food.Text)
            '    r.Cells(10).Value = Val(txtSCPer.Text)
            '    r.Cells(11).Value = Val(r.Cells(11).Value) - Val(txtSCAmount.Text)
            '    r.Cells(12).Value = Val(r.Cells(12).Value) - Val(txtTotalAmt_Food.Text)

            '    r.Cells(14).Value = m
            '    Dim i As Double = 0
            '    i = GrandTotal_Food4()
            '    i = Math.Round(i, 2)
            '    lblBalance3.Text = i
            '    txtGrandTotal3.Text = i
            '    Calc3()
            '    fillCurrencyEB()
            '    ItemDataSubString(r.Cells(0).Value.ToString())
            '    CustomerDisplay(subt, Val(r.Cells(12).Value), Val(txtGrandTotal3.Text))
            '    Clear1()
            'Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCancel3_Click(sender As System.Object, e As System.EventArgs)
        Try
            'For Each row As DataGridViewRow In DataGridView5.SelectedRows
            '    DataGridView5.Rows.Remove(row)
            'Next
            'Dim k As Double = 0
            'k = GrandTotal_Food4()
            'k = Math.Round(k, 2)
            'lblBalance3.Text = k
            'txtGrandTotal3.Text = k
            'fillCurrencyEB()
            Compute()
            Calc3()
            Clear4()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnChangeRate3_Click(sender As System.Object, e As System.EventArgs)
        Try
            'frmChangeRate.lblSet.Text = "Express Billing"
            'If DataGridView5.Rows.Count > 0 Then
            '    Dim dr As DataGridViewRow = DataGridView5.SelectedRows(0)
            '    frmChangeRate.txtNotes.Text = dr.Cells(13).Value
            '    frmChangeRate.txtR.Text = txtEBDiscountPer.Text
            '    frmChangeRate.txtCategory.Text = dr.Cells(15).Value
            'End If
            'frmChangeRate.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnChangeQty3_Click(sender As System.Object, e As System.EventArgs)
        Try
            'frmChangeQty.lblSet.Text = "Express Billing"
            'If DataGridView5.Rows.Count > 0 Then
            '    Dim dr As DataGridViewRow = DataGridView5.SelectedRows(0)
            '    frmChangeQty.txtNotes.Text = dr.Cells(13).Value
            '    frmChangeQty.txtQ.Text = txtEBDiscountPer.Text
            '    frmChangeQty.txtCategory.Text = dr.Cells(15).Value
            'End If
            'frmChangeQty.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub


    Private Sub txtCash3_TextChanged(sender As System.Object, e As System.EventArgs)
        Calc3()
    End Sub

    Private Sub txtCash3_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        'Dim keyChar = e.KeyChar

        'If Char.IsControl(keyChar) Then
        '    'Allow all control characters.
        'ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
        '    Dim text = Me.txtCash3.Text
        '    Dim selectionStart = Me.txtCash3.SelectionStart
        '    Dim selectionLength = Me.txtCash3.SelectionLength

        '    text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

        '    If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
        '        'Reject an integer that is longer than 16 digits.
        '        e.Handled = True
        '    ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
        '        'Reject a real number with two many decimal places.
        '        e.Handled = False
        '    End If
        'Else
        '    'Reject all other characters.
        '    e.Handled = True
        'End If
    End Sub
    Sub Print4Func1()
        Dim CN As New SqlConnection(cs)
        CN.Open()
        adp = New SqlDataAdapter()
        'adp.SelectCommand = New SqlCommand("SELECT DISTINCT RTRIM(Kitchen.Kitchenname) FROM Category INNER JOIN Kitchen ON Category.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductBillEB ON Category.CategoryName = RestaurantPOS_OrderedProductBillEB.Category INNER JOIN RestaurantPOS_BillingInfoEB ON RestaurantPOS_OrderedProductBillEB.BillID = RestaurantPOS_BillingInfoEB.ID where BillNo='" & lblBillNo3.Text & "'", CN)
        ds = New DataSet("ds")
        adp.Fill(ds)
        Dim dtable As DataTable = ds.Tables(0)
        CBox.Items.Clear()
        For Each drow As DataRow In dtable.Rows
            CBox.Items.Add(drow(0).ToString())
        Next
        For Each item As String In CBox.Items
            Cursor = Cursors.WaitCursor
            Timer4.Enabled = True
            Dim rpt As New rptRestaurantPOSEBInvoice_Kitchen 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            'MyCommand.CommandText = "SELECT distinct ODN,BillNote,RestaurantPOS_OrderedProductBillEB.OP_ID,SCPer,SCAmount,RestaurantPOS_OrderedProductBillEB.Notes,Operator,PaymentMode,CurrencyCode, RestaurantPOS_OrderedProductBillEB.BillID, RestaurantPOS_OrderedProductBillEB.Dish, RestaurantPOS_OrderedProductBillEB.VATPer,RestaurantPOS_OrderedProductBillEB.VATAmount, RestaurantPOS_OrderedProductBillEB.STPer, RestaurantPOS_OrderedProductBillEB.STAmount, RestaurantPOS_OrderedProductBillEB.DiscountPer, RestaurantPOS_OrderedProductBillEB.DiscountAmount,RestaurantPOS_OrderedProductBillEB.Rate, RestaurantPOS_OrderedProductBillEB.Quantity, RestaurantPOS_OrderedProductBillEB.Amount, RestaurantPOS_OrderedProductBillEB.TotalAmount,RestaurantPOS_BillingInfoEB.ID, RestaurantPOS_BillingInfoEB.BillNo, RestaurantPOS_BillingInfoEB.BillDate, RestaurantPOS_BillingInfoEB.GrandTotal,Cash,Change FROM Category INNER JOIN Kitchen ON Category.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductBillEB ON Category.CategoryName = RestaurantPOS_OrderedProductBillEB.Category INNER JOIN RestaurantPOS_BillingInfoEB ON RestaurantPOS_OrderedProductBillEB.BillID = RestaurantPOS_BillingInfoEB.ID where BillNo='" & lblBillNo3.Text & "' and KitchenName=@d1"
            MyCommand.Parameters.AddWithValue("@d1", item)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_BillingInfoEB")
            myDA.Fill(myDS, "Category")
            myDA.Fill(myDS, "Kitchen")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillEB")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(Printer) from Kitchen where KitchenName=@d1 and IsEnabled='Yes'"
            cmd.Parameters.AddWithValue("@d1", item)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s1 = rdr.GetValue(0)
                rpt.PrintOptions.PrinterName = s1
                rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
                rpt.PrintToPrinter(1, False, 0, 0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            rpt.Close()
            rpt.Dispose()
        Next
    End Sub
    Sub Print4Func2()
        Cursor = Cursors.WaitCursor
        Timer4.Enabled = True
        Dim rpt As New rptRestaurantPOSEBInvoice 'The report you created.
        Dim myConnection As SqlConnection
        Dim MyCommand, MyCommand1 As New SqlCommand()
        Dim myDA, myDA1 As New SqlDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New SqlConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT ODN,Member_ID,EB_PhoneNo, BillNote,RestaurantPOS_OrderedProductBillEB.OP_ID,Operator,Notes,SCPer,SCAmount,PaymentMode,CurrencyCode,EB_Status, RestaurantPOS_OrderedProductBillEB.BillID, RestaurantPOS_OrderedProductBillEB.Dish, RestaurantPOS_OrderedProductBillEB.VATPer,RestaurantPOS_OrderedProductBillEB.VATAmount, RestaurantPOS_OrderedProductBillEB.STPer, RestaurantPOS_OrderedProductBillEB.STAmount, RestaurantPOS_OrderedProductBillEB.DiscountPer, RestaurantPOS_OrderedProductBillEB.DiscountAmount,RestaurantPOS_OrderedProductBillEB.Rate, RestaurantPOS_OrderedProductBillEB.Quantity, RestaurantPOS_OrderedProductBillEB.Amount, RestaurantPOS_OrderedProductBillEB.TotalAmount,RestaurantPOS_BillingInfoEB.ID, RestaurantPOS_BillingInfoEB.BillNo, RestaurantPOS_BillingInfoEB.BillDate, RestaurantPOS_BillingInfoEB.GrandTotal,RestaurantPOS_BillingInfoEB.Cash,RestaurantPOS_BillingInfoEB.Change FROM RestaurantPOS_OrderedProductBillEB INNER JOIN  RestaurantPOS_BillingInfoEB ON RestaurantPOS_OrderedProductBillEB.BillID = RestaurantPOS_BillingInfoEB.ID where RestaurantPOS_BillingInfoEB.ID=" & txtBillID3.Text & ""
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "RestaurantPOS_BillingInfoEB")
        myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillEB")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        'If lblPaymentMode3.Text = "Credit Customer" Then
        '    con = New SqlConnection(cs)
        '    con.Open()
        '    cmd = con.CreateCommand()
        '    cmd.CommandText = "SELECT RTRIM(Name) from CreditCustomer where CreditCustomerID=@d1"
        '    cmd.Parameters.AddWithValue("@d1", lblMemberID.Text)
        '    rdr = cmd.ExecuteReader()
        '    If rdr.Read() Then
        '        lblCustNameVAL.Text = rdr.GetValue(0).ToString()
        '    Else
        '        lblCustNameVAL.Text = ""
        '    End If
        '    If (rdr IsNot Nothing) Then
        '        rdr.Close()
        '    End If
        '    If con.State = ConnectionState.Open Then
        '        con.Close()
        '    End If
        '    rpt.SetParameterValue("p1", lblCustNameVAL.Text)
        'Else
        '    rpt.SetParameterValue("p1", "")
        'End If
        con = New SqlConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
        cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            s2 = rdr.GetValue(0)
            rpt.PrintOptions.PrinterName = s2
            rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
            rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
            rpt.PrintToPrinter(1, False, 0, 0)
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        rpt.Close()
        rpt.Dispose()
    End Sub
    Sub Print4Func3()
        Cursor = Cursors.WaitCursor
        Timer4.Enabled = True
        Dim rpt As New rptRestaurantPOSEBInvoice1 'The report you created.
        Dim myConnection As SqlConnection
        Dim MyCommand, MyCommand1 As New SqlCommand()
        Dim myDA, myDA1 As New SqlDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New SqlConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT ODN,Member_ID,EB_PhoneNo, BillNote,RestaurantPOS_OrderedProductBillEB.OP_ID,Operator,Notes,SCPer,SCAmount,PaymentMode,CurrencyCode,EB_Status, RestaurantPOS_OrderedProductBillEB.BillID, RestaurantPOS_OrderedProductBillEB.Dish, RestaurantPOS_OrderedProductBillEB.VATPer,RestaurantPOS_OrderedProductBillEB.VATAmount, RestaurantPOS_OrderedProductBillEB.STPer, RestaurantPOS_OrderedProductBillEB.STAmount, RestaurantPOS_OrderedProductBillEB.DiscountPer, RestaurantPOS_OrderedProductBillEB.DiscountAmount,RestaurantPOS_OrderedProductBillEB.Rate, RestaurantPOS_OrderedProductBillEB.Quantity, RestaurantPOS_OrderedProductBillEB.Amount, RestaurantPOS_OrderedProductBillEB.TotalAmount,RestaurantPOS_BillingInfoEB.ID, RestaurantPOS_BillingInfoEB.BillNo, RestaurantPOS_BillingInfoEB.BillDate, RestaurantPOS_BillingInfoEB.GrandTotal,RestaurantPOS_BillingInfoEB.Cash,RestaurantPOS_BillingInfoEB.Change FROM RestaurantPOS_OrderedProductBillEB INNER JOIN  RestaurantPOS_BillingInfoEB ON RestaurantPOS_OrderedProductBillEB.BillID = RestaurantPOS_BillingInfoEB.ID where RestaurantPOS_BillingInfoEB.ID=" & txtBillID3.Text & ""
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "RestaurantPOS_BillingInfoEB")
        myDA.Fill(myDS, "RestaurantPOS_OrderedProductBillEB")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        'If lblPaymentMode3.Text = "Credit Customer" Then
        '    con = New SqlConnection(cs)
        '    con.Open()
        '    cmd = con.CreateCommand()
        '    cmd.CommandText = "SELECT RTRIM(Name) from CreditCustomer where CreditCustomerID=@d1"
        '    cmd.Parameters.AddWithValue("@d1", lblMemberID.Text)
        '    rdr = cmd.ExecuteReader()
        '    If rdr.Read() Then
        '        lblCustNameVAL.Text = rdr.GetValue(0).ToString()
        '    Else
        '        lblCustNameVAL.Text = ""
        '    End If
        '    If (rdr IsNot Nothing) Then
        '        rdr.Close()
        '    End If
        '    If con.State = ConnectionState.Open Then
        '        con.Close()
        '    End If
        '    rpt.SetParameterValue("p1", lblCustNameVAL.Text)
        'Else
        '    rpt.SetParameterValue("p1", "")
        'End If
        con = New SqlConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
        cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            s2 = rdr.GetValue(0)
            rpt.PrintOptions.PrinterName = s2
            rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
            rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
            rpt.PrintToPrinter(1, False, 0, 0)
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        rpt.Close()
        rpt.Dispose()
    End Sub
    Sub Print4()
        Try
            If K3.Text = "Yes" Then
                Print4Func1()
            End If
            Print4Func2()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Print5()
        Try
            If K3.Text = "Yes" Then
                Print4Func1()
            End If
            Print4Func3()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSave4_Click(sender As System.Object, e As System.EventArgs)
        Try
            'If DataGridView5.Rows.Count = 0 Then
            '    MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            'If lblPaymentMode3.Text = "" Then
            '    MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    lblPaymentMode3.Focus()
            '    Exit Sub
            'End If
            'If txtCash3.Text = "" Then
            '    MessageBox.Show("Please enter cash", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtCash3.Focus()
            '    Exit Sub
            'End If
            'If lblPaymentMode3.Text <> "Credit Customer" Then
            '    If Val(txtGrandTotal3.Text) > Val(txtCash3.Text) And Val(txtCash3.Text) <> 0 Then
            '        MessageBox.Show("cash can not be less than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        Exit Sub
            '    End If
            'End If
            'If Val(txtGrandTotal3.Text) < 0 Then
            '    MessageBox.Show("Grand Total cant't be less than zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End If
            'Dim totals As New Dictionary(Of String, Integer)()
            'For i As Integer = 0 To DataGridView5.Rows.Count - 1
            '    Dim str As String = DataGridView5.Rows(i).Cells(0).Value
            '    Dim strText() As String
            '    strText = Split(str, vbCrLf)
            '    Dim group As String = strText(0)
            '    Dim qty As Integer = Convert.ToInt32(DataGridView5.Rows(i).Cells(2).Value)
            '    If totals.ContainsKey(group) = False Then
            '        totals.Add(group, qty)
            '    Else
            '        totals(group) += qty
            '    End If
            'Next
            'For Each group As String In totals.Keys
            '    i2 = totals(group)
            '    Dim con As New SqlConnection(cs)
            '    con.Open()
            '    Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_Store where Dish=@d1", con)
            '    cmd.Parameters.AddWithValue("@d1", group)
            '    Dim da As New SqlDataAdapter(cmd)
            '    Dim ds As DataSet = New DataSet()
            '    da.Fill(ds)
            '    con.Close()
            '    If ds.Tables(0).Rows.Count > 0 Then
            '        i1 = ds.Tables(0).Rows(0)("Qty")
            '        If Val(i2) > Val(i1) Then
            '            MessageBox.Show("added qty. to grid are more than" & vbCrLf & "available qty. of item name '" & group & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '            DataGridView5.ClearSelection()
            '            Clear()
            '            Exit Sub
            '        End If
            '    End If
            'Next
            'For Each row As DataGridViewRow In DataGridView5.Rows
            '    con = New SqlConnection(cs)
            '    con.Open()
            '    Dim ct As String = "select Dish from Recipe where Dish=@d1"
            '    cmd = New SqlCommand(ct)
            '    cmd.Connection = con
            '    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
            '    rdr = cmd.ExecuteReader()
            '    If (rdr.Read()) Then
            '        con = New SqlConnection(cs)
            '        con.Open()
            '        cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
            '        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
            '        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            '        dgw.Rows.Clear()
            '        While (rdr.Read() = True)
            '            dgw.Rows.Add(rdr(0), rdr(1))
            '        End While
            '        con.Close()
            '        For Each dr As DataGridViewRow In dgw.Rows
            '            Dim con As New SqlConnection(cs)
            '            con.Open()
            '            Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
            '            cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
            '            Dim da As New SqlDataAdapter(cmd)
            '            Dim ds As DataSet = New DataSet()
            '            da.Fill(ds)
            '            Dim i1 As Decimal
            '            Dim i2 As Integer
            '            If DataGridView5.Rows.Count > 1 Then
            '                For i = 0 To DataGridView5.RowCount - 2
            '                    For t = i + 1 To DataGridView5.RowCount - 1
            '                        If DataGridView5.Rows(i).Cells(0).Value = DataGridView5.Rows(t).Cells(0).Value Then
            '                            i2 += row.Cells(2).Value
            '                        End If
            '                    Next
            '                Next
            '            Else
            '                i2 = row.Cells(2).Value
            '            End If
            '            If ds.Tables(0).Rows.Count > 0 Then
            '                i1 = ds.Tables(0).Rows(0)("Qty")
            '                If Val(dr.Cells(1).Value) * Val(i2) > Val(i1) Then
            '                    MessageBox.Show("Raw Materials are not available to prepare recipe in the kitchen/section for added quantities of item name '" & row.Cells(0).Value & "' in the grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '                    DataGridView5.ClearSelection()
            '                    Clear()
            '                    Exit Sub
            '                End If
            '            End If
            '            con.Close()
            '        Next
            '    End If
            'Next

            'Settle3()
            'For Each row As DataGridViewRow In DataGridView5.Rows
            '    Dim str As String = row.Cells(0).Value.ToString()
            '    Dim strText() As String
            '    strText = Split(str, vbCrLf)
            '    con = New SqlConnection(cs)
            '    con.Open()
            '    Dim ct As String = "select Dish from temp_Stock_Store where Dish=@d1"
            '    cmd = New SqlCommand(ct)
            '    cmd.Connection = con
            '    cmd.Parameters.AddWithValue("@d1", strText(0))
            '    rdr = cmd.ExecuteReader()
            '    If (rdr.Read()) Then
            '        con = New SqlConnection(cs)
            '        con.Open()
            '        Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty - " & Val(row.Cells(2).Value) & " where Dish=@d1"
            '        cmd = New SqlCommand(cb2)
            '        cmd.Connection = con
            '        cmd.Parameters.AddWithValue("@d1", strText(0))
            '        cmd.ExecuteReader()
            '        con.Close()
            '    End If
            '    retrieving.SoldStock(CType(row.Cells(2).Value, Decimal), row.Cells(0).Value.ToString())
            'Next
            'For Each row As DataGridViewRow In DataGridView5.Rows
            '    Dim str As String = row.Cells(0).Value.ToString()
            '    Dim strText() As String
            '    strText = Split(str, vbCrLf)
            '    con = New SqlConnection(cs)
            '    con.Open()
            '    Dim ct As String = "select Dish from Recipe where Dish=@d1"
            '    cmd = New SqlCommand(ct)
            '    cmd.Connection = con
            '    cmd.Parameters.AddWithValue("@d1", strText(0))
            '    rdr = cmd.ExecuteReader()
            '    If (rdr.Read()) Then
            '        con = New SqlConnection(cs)
            '        con.Open()
            '        cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
            '        cmd.Parameters.AddWithValue("@d1", strText(0))
            '        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            '        dgw.Rows.Clear()
            '        While (rdr.Read() = True)
            '            dgw.Rows.Add(rdr(0), rdr(1))
            '        End While
            '        con.Close()
            '        RM_ID()
            '        RawMaterialUsed(Val(txtRM_ID.Text), lblBillNo3.Text)
            '        For Each dr As DataGridViewRow In dgw.Rows
            '            con = New SqlConnection(cs)
            '            con.Open()
            '            Dim cb2 As String = "Update Temp_Stock_RM set Qty=Qty - " & Val(dr.Cells(1).Value) * Val(row.Cells(2).Value) & " where ProductID=@d1"
            '            cmd = New SqlCommand(cb2)
            '            cmd.Connection = con
            '            cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
            '            cmd.ExecuteReader()
            '            con.Close()
            '        Next
            '        con = New SqlConnection(cs)
            '        con.Open()
            '        Dim cb3 As String = "insert into RM_Used_Join(RawMaterialID,ProductID,Quantity) VALUES (" & Val(txtRM_ID.Text) & ",@d1,@d2)"
            '        cmd = New SqlCommand(cb3)
            '        cmd.Connection = con
            '        ' Prepare command for repeated execution
            '        cmd.Prepare()
            '        ' Data to be inserted
            '        For Each dr1 As DataGridViewRow In dgw.Rows
            '            If Not row.IsNewRow Then
            '                cmd.Parameters.AddWithValue("@d1", Val(dr1.Cells(0).Value))
            '                cmd.Parameters.AddWithValue("@d2", Val(dr1.Cells(1).Value) * Val(row.Cells(2).Value))
            '                cmd.ExecuteNonQuery()
            '                cmd.Parameters.Clear()
            '            End If
            '        Next
            '    End If
            'Next
            'auto4()
            'OrderNo()
            'ODN(lblOrderNo.Text, lblBillNo3.Text)
            'con = New SqlConnection(cs)
            'con.Open()
            'Dim cb As String = "insert into RestaurantPOS_BillingInfoEB( Id,BillNo, BillDate, GrandTotal,Cash,Change,Operator,PaymentMode,ExchangeRate,CurrencyCode,BillNote,EB_Status,EBDiscountPer,EBDiscountAmt,Member_ID,EB_PhoneNo,ODN) Values (" & txtBillID3.Text & ",'" & lblBillNo3.Text & "',@d1," & Val(txtGrandTotal3.Text) & "," & Val(txtCash3.Text) & "," & Val(txtChange3.Text) & ",@d2,@d3," & Val(txtExchangeRate.Text) & ",@d4,@d5,@d6," & Val(txtEBDiscountPer.Text) & ",@d7,@d8,@d9,@d10)"
            'cmd = New SqlCommand(cb)
            'cmd.Parameters.AddWithValue("@d1", System.DateTime.Now)
            'cmd.Parameters.AddWithValue("@d2", lblUserVAL.Text)
            'cmd.Parameters.AddWithValue("@d3", lblPaymentMode3.Text)
            'If lblCurrencyValEB.Text <> "" Then
            '    cmd.Parameters.AddWithValue("@d4", lblCurrencyValEB.Text)
            'Else
            '    cmd.Parameters.AddWithValue("@d4", str)
            'End If
            'cmd.Parameters.AddWithValue("@d5", txtNotes.Text)
            'If Val(txtCash3.Text) >= Val(txtGrandTotal3.Text) Then
            '    cmd.Parameters.AddWithValue("@d6", "Paid")
            'ElseIf Val(txtCash3.Text) = 0 And lblPaymentMode3.Text = "Credit Customer" Then
            '    cmd.Parameters.AddWithValue("@d6", "Paid")
            'ElseIf Val(txtCash3.Text) = 0 And lblPaymentMode3.Text <> "Credit Customer" Then
            '    cmd.Parameters.AddWithValue("@d6", "Unpaid")
            'Else
            '    cmd.Parameters.AddWithValue("@d6", "Partially Paid")
            'End If
            'cmd.Parameters.AddWithValue("@d7", Val(txtEBDiscountAmount.Text))
            'If lblMemberID.Text = "" Then
            '    cmd.Parameters.AddWithValue("@d8", "")
            'Else
            '    cmd.Parameters.AddWithValue("@d8", lblMemberID.Text)
            'End If
            'cmd.Parameters.AddWithValue("@d9", txtEBContactNo.Text)
            'cmd.Parameters.AddWithValue("@d10", lblOrderNo.Text)
            'cmd.Connection = con
            'cmd.ExecuteReader()
            'con.Close()
            'SqlConnection.ClearAllPools()
            'con = New SqlConnection(cs)
            'con.Open()
            'Dim cb1 As String = "insert into RestaurantPOS_OrderedProductBillEB(BillID,Dish,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,SCPer,SCAmount,TotalAmount,Notes,Category) VALUES (" & txtBillID3.Text & ",@d1,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
            'cmd = New SqlCommand(cb1)
            'cmd.Connection = con
            '' Prepare command for repeated execution
            'cmd.Prepare()
            '' Data to be inserted
            'For Each row As DataGridViewRow In DataGridView5.Rows
            '    If Not row.IsNewRow Then
            '        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
            '        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(1).Value))
            '        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(2).Value))
            '        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(3).Value))
            '        cmd.Parameters.AddWithValue("@d6", Val(row.Cells(4).Value))
            '        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(5).Value))
            '        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(6).Value))
            '        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(7).Value))
            '        cmd.Parameters.AddWithValue("@d10", Val(row.Cells(8).Value))
            '        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(9).Value))
            '        cmd.Parameters.AddWithValue("@d12", Val(row.Cells(10).Value))
            '        cmd.Parameters.AddWithValue("@d13", Val(row.Cells(11).Value))
            '        cmd.Parameters.AddWithValue("@d14", Val(row.Cells(12).Value))
            '        If row.Cells(13).Value = "" Then
            '            cmd.Parameters.AddWithValue("@d15", "")
            '        Else
            '            cmd.Parameters.AddWithValue("@d15", row.Cells(13).Value)
            '        End If
            '        If row.Cells(15).Value = "" Then
            '            cmd.Parameters.AddWithValue("@d16", "")
            '        Else
            '            cmd.Parameters.AddWithValue("@d16", row.Cells(15).Value)
            '        End If
            '        cmd.ExecuteNonQuery()
            '        cmd.Parameters.Clear()
            '    End If
            'Next
            'con.Close()
            'GetTransID()
            'Dim st As String = "added the new restaurant pos(express billing) record having bill no. '" & lblBillNo3.Text & "'"
            'LogFunc(lblUserVAL.Text, st)
            'If lblPaymentMode3.Text = "Credit Customer" Then
            '    LedgerSave(System.DateTime.Today, "Sales A/c", lblBillNo3.Text, "Sales Invoice", 0, Val(txtGrandTotal3.Text) * Val(txtExchangeRate.Text), "", lblCustNameVAL.Text)
            '    LedgerSave(System.DateTime.Today, lblCustNameVAL.Text, lblBillNo3.Text, "POS", Val(txtGrandTotal3.Text) * Val(txtExchangeRate.Text), 0, lblMemberID.Text, "Sales A/c")
            'Else
            '    LedgerSave(System.DateTime.Today, "Cash", lblBillNo3.Text, "POS", Val(txtGrandTotal3.Text) * Val(txtExchangeRate.Text), 0, "", "Sales A/c")
            '    LedgerSave(System.DateTime.Today, "Sales A/c", lblBillNo3.Text, "Sales Invoice", 0, Val(txtGrandTotal3.Text) * Val(txtExchangeRate.Text), "", "Cash")
            'End If
            'btnSave4.Enabled = False
            'If lblPaymentMode3.Text = "Cash" And Val(txtCash3.Text) > 0 Then
            '    OpenCashdrawer()
            'End If
            'If MessageBox.Show("Do you want to print bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            '    If Val(txtCash3.Text) > 0 Then
            '        Print4()
            '    Else
            '        Print5()
            '    End If
            'End If
            'Reset4()
            'Reset4()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCash3_Click(sender As System.Object, e As System.EventArgs)
        'txtCash3.ReadOnly = False
        'lblPaymentMode3.Text = btnCash3.Text
    End Sub

    Private Sub btnGetData4_Click(sender As System.Object, e As System.EventArgs)
        frmRestaurantPOSEBRecord.Reset()
        frmRestaurantPOSEBRecord.lblUserType.Text = lblUserType.Text
        frmRestaurantPOSEBRecord.ShowDialog()
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs)
        Try
            'If DataGridView5.Rows.Count = 0 Then
            '    MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            'If lblPaymentMode3.Text = "" Then
            '    MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    lblPaymentMode3.Focus()
            '    Exit Sub
            'End If
            'If txtCash3.Text = "" Then
            '    MessageBox.Show("Please enter cash", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    txtCash3.Focus()
            '    Exit Sub
            'End If
            'If Val(txtGrandTotal3.Text) > Val(txtCash3.Text) Then
            '    MessageBox.Show("cash can not be less than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End If
            'con = New SqlConnection(cs)
            'con.Open()
            'Dim cb As String = "Update RestaurantPOS_BillingInfoEB set BillNo='" & lblBillNo3.Text & "', GrandTotal=" & Val(txtGrandTotal3.Text) & ",Cash=" & Val(txtCash3.Text) & ",Change=" & Val(txtChange3.Text) & ",PaymentMode=@d1,ExchangeRate=" & Val(txtExchangeRate.Text) & ",CurrencyCode=@d2,BillNote=@d3,EB_Status=@d4,EBDiscountPer=" & Val(txtEBDiscountPer.Text) & ",EBDiscountAmt=@d5,EB_PhoneNo=@d6 where ID=" & Val(txtBillID3.Text) & ""
            'cmd = New SqlCommand(cb)
            'cmd.Parameters.AddWithValue("@d1", lblPaymentMode3.Text)
            'If lblCurrencyValEB.Text <> "" Then
            '    cmd.Parameters.AddWithValue("@d2", lblCurrencyValEB.Text)
            'Else
            '    cmd.Parameters.AddWithValue("@d2", str)
            'End If
            'cmd.Parameters.AddWithValue("@d3", txtNotes.Text)
            'If Val(txtCash3.Text) >= Val(txtGrandTotal3.Text) Then
            '    cmd.Parameters.AddWithValue("@d4", "Paid")
            'ElseIf Val(txtCash3.Text) = 0 And lblPaymentMode3.Text = "Credit Customer" Then
            '    cmd.Parameters.AddWithValue("@d4", "Paid")
            'ElseIf Val(txtCash3.Text) = 0 And lblPaymentMode3.Text <> "Credit Customer" Then
            '    cmd.Parameters.AddWithValue("@d4", "Unpaid")
            'Else
            '    cmd.Parameters.AddWithValue("@d4", "Partially Paid")
            'End If
            'cmd.Parameters.AddWithValue("@d5", Val(txtEBDiscountAmount.Text))
            'cmd.Parameters.AddWithValue("@d6", txtEBContactNo.Text)
            'cmd.Connection = con
            'cmd.ExecuteReader()
            'con.Close()
            'Dim st As String = "Updated the restaurant pos(express billing) record having bill no. '" & lblBillNo3.Text & "'"
            'LogFunc(lblUserVAL.Text, st)
            'MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'GetTransID()
            'btnUpdate.Enabled = False
            'If lblPaymentMode3.Text = "Cash" Then
            '    OpenCashdrawer()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrint4_Click(sender As System.Object, e As System.EventArgs)
        'If Val(txtCash3.Text) > 0 Then
        '    Print4Func2()
        'Else
        '    Print4Func3()
        'End If
        Reset4()
        Reset4()
    End Sub

    Private Sub btnUnpaidBills_Click(sender As System.Object, e As System.EventArgs)
        frmRestaurantPOSEBRecord_Unpaid.Reset()
        frmRestaurantPOSEBRecord_Unpaid.lblUserType.Text = lblUserType.Text
        frmRestaurantPOSEBRecord_Unpaid.ShowDialog()
    End Sub

    Private Sub btnRevert1_Click(sender As System.Object, e As System.EventArgs) Handles btnRevert1.Click
        Try
            If DataGridView3.Rows.Count > 0 Then
                txtCash1.Text = ""
                lblBalance1.Text = Math.Round(Val(lblBalance1.Text) * Val(txtExchangeRate.Text), 2)
                txtSubTotal1.Text = lblBalance1.Text
                txtParcelCharges.Text = Math.Round(Val(txtParcelCharges.Text) * Val(txtExchangeRate.Text), 2)
                For Each row As DataGridViewRow In DataGridView3.Rows
                    row.Cells(1).Value = Math.Round(Val(row.Cells(1).Value) * Val(txtExchangeRate.Text), MidpointRounding.ToEven)
                    row.Cells(3).Value = Math.Round(Val(row.Cells(3).Value) * Val(txtExchangeRate.Text), 2)
                    row.Cells(5).Value = Math.Round(Val(row.Cells(5).Value) * Val(txtExchangeRate.Text), 2)
                    row.Cells(7).Value = Math.Round(Val(row.Cells(7).Value) * Val(txtExchangeRate.Text), 2)
                    row.Cells(9).Value = Math.Round(Val(row.Cells(9).Value) * Val(txtExchangeRate.Text), 2)
                    row.Cells(11).Value = Math.Round(Val(row.Cells(11).Value) * Val(txtExchangeRate.Text), 2)
                    row.Cells(12).Value = Math.Round(Val(row.Cells(12).Value) * Val(txtExchangeRate.Text), 2)
                Next
                btnRevert1.Visible = False
                Calc1()
                fillCurrencyTA()
                lblCurrencyTA.Visible = False
                lblCurrencyValTA.Visible = False
                lblCurrencyValTA.Text = ""
                txtExchangeRate.Text = 1
                DataGridView3.Enabled = False
                flpItemsTA.Enabled = False
                flpTA.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRevert2_Click(sender As System.Object, e As System.EventArgs)
        Try
            'If DataGridView5.Rows.Count > 0 Then
            '    txtCash3.Text = "0.00"
            '    lblBalance3.Text = Math.Round(Val(lblBalance3.Text) * Val(txtExchangeRate.Text), 2)
            '    txtGrandTotal3.Text = lblBalance3.Text
            '    For Each row As DataGridViewRow In DataGridView5.Rows
            '        row.Cells(1).Value = Math.Round(Val(row.Cells(1).Value) * Val(txtExchangeRate.Text), MidpointRounding.ToEven)
            '        row.Cells(3).Value = Math.Round(Val(row.Cells(3).Value) * Val(txtExchangeRate.Text), 2)
            '        row.Cells(5).Value = Math.Round(Val(row.Cells(5).Value) * Val(txtExchangeRate.Text), 2)
            '        row.Cells(7).Value = Math.Round(Val(row.Cells(7).Value) * Val(txtExchangeRate.Text), 2)
            '        row.Cells(9).Value = Math.Round(Val(row.Cells(9).Value) * Val(txtExchangeRate.Text), 2)
            '        row.Cells(11).Value = Math.Round(Val(row.Cells(11).Value) * Val(txtExchangeRate.Text), 2)
            '        row.Cells(12).Value = Math.Round(Val(row.Cells(12).Value) * Val(txtExchangeRate.Text), 2)
            '    Next
            '    btnRevert2.Visible = False
            '    Calc3()
            '    fillCurrencyEB()
            '    lblCurrencyEB.Visible = False
            '    lblCurrencyValEB.Visible = False
            '    lblCurrencyValEB.Text = ""
            '    DataGridView5.Enabled = False
            '    flpItemsEB.Enabled = False
            '    txtExchangeRate.Text = 1
            '    flpEB.Visible = True
            '    flpEB.Enabled = True
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnMinimize_Click(sender As System.Object, e As System.EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
        frmFrontOffice.lblUser.Text = lblUserVAL.Text
        frmFrontOffice.lblUserType.Text = lblUserType.Text
        frmFrontOffice.Show()
    End Sub

    Private Sub btnKeyboard_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.Click
        OSKeyboard()
    End Sub

    Private Sub TabControl1_DrawItem(sender As System.Object, e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        'Firstly we'll define some parameters.
        Dim CurrentTab As TabPage = TabControl1.TabPages(e.Index)
        Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)
        Dim FillBrush As New SolidBrush(Color.DimGray)
        Dim TextBrush As New SolidBrush(Color.White)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        'If we are currently painting the Selected TabItem we'll 
        'change the brush colors and inflate the rectangle.
        If CBool(e.State And DrawItemState.Selected) Then
            FillBrush.Color = Color.DimGray
            TextBrush.Color = Color.White
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

    Private Sub btnKOTUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnKOTUpdate.Click
        Try
            If lblTableNo.Text = "" Then
                MessageBox.Show("Please select table", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Settle()
            For Each row As DataGridViewRow In DataGridView1.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1"
                cmd = New SqlCommand(sql)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty - " & Val(row.Cells(2).Value) & "+" & Val(row.Cells(14).Value) & " where Dish=@d1"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.ExecuteReader()
                    con.Close()
                End If
            Next
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update RestaurantPOS_OrderInfoKOT set TicketNo='" & lblTicketNo.Text & "', BillDate=@d2, GrandTotal=" & lblBalance.Text & ",tableNo=@d1,Operator=@d3,GroupName=@d4,TicketNote=@d5 where ID=" & txtTicketID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
            cmd.Parameters.AddWithValue("@d2", System.DateTime.Now)
            cmd.Parameters.AddWithValue("@d3", lblUserVAL.Text)
            cmd.Parameters.AddWithValue("@d4", cmbGroup.Text)
            cmd.Parameters.AddWithValue("@d5", txtNotes.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "delete from RestaurantPOS_OrderedProductKOT where TicketID=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", Val(txtTicketID.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into RestaurantPOS_OrderedProductKOT(TicketID,Dish,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,SCPer,SCAmount,TotalAmount,Notes,Category,T_Number) VALUES (" & txtTicketID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d13", Val(row.Cells(12).Value))
                    If row.Cells(13).Value = "" Then
                        cmd.Parameters.AddWithValue("@d14", "")
                    Else
                        cmd.Parameters.AddWithValue("@d14", row.Cells(13).Value)
                    End If
                    cmd.Parameters.AddWithValue("@d15", row.Cells(15).Value)
                    cmd.Parameters.AddWithValue("@d16", lblTableNo.Text)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            Dim st As String = "updated the restaurant pos record having ticket no. '" & lblTicketNo.Text & "'"
            LogFunc(lblUserVAL.Text, st)
            btnSave.Enabled = False
            If MessageBox.Show("Do you want to print updated kot?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                PrintUpdate()
            End If
            fillTableNo()
            FillGroup()
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub PrintUpdateFunc1()
        Dim CN As New SqlConnection(cs)
        CN.Open()
        adp = New SqlDataAdapter()
        adp.SelectCommand = New SqlCommand("SELECT DISTINCT RTRIM(Kitchen.Kitchenname) FROM Category INNER JOIN Kitchen ON Category.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductKOT ON Category.CategoryName = RestaurantPOS_OrderedProductKOT.Category INNER JOIN RestaurantPOS_OrderInfoKOT ON RestaurantPOS_OrderedProductKOT.TicketID = RestaurantPOS_OrderInfoKOT.ID where TicketNo='" & lblTicketNo.Text & "'", CN)
        ds = New DataSet("ds")
        adp.Fill(ds)
        Dim dtable As DataTable = ds.Tables(0)
        CBox.Items.Clear()
        For Each drow As DataRow In dtable.Rows
            CBox.Items.Add(drow(0).ToString())
        Next
        For Each item As String In CBox.Items
            Cursor = Cursors.WaitCursor
            Timer4.Enabled = True
            Dim rpt As New rptRestaurantPOSKOTUpdatedInvoice_Kitchen 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT distinct TicketNote,SCper,SCAmount, RestaurantPOS_OrderedProductKOT.OP_ID,RestaurantPOS_OrderedProductKOT.Notes,Operator,GroupName, RestaurantPOS_OrderedProductKOT.TicketID, RestaurantPOS_OrderedProductKOT.Dish, RestaurantPOS_OrderedProductKOT.VATPer,RestaurantPOS_OrderedProductKOT.VATAmount, RestaurantPOS_OrderedProductKOT.STPer, RestaurantPOS_OrderedProductKOT.STAmount, RestaurantPOS_OrderedProductKOT.DiscountPer, RestaurantPOS_OrderedProductKOT.DiscountAmount,RestaurantPOS_OrderedProductKOT.Rate, RestaurantPOS_OrderedProductKOT.Quantity, RestaurantPOS_OrderedProductKOT.Amount, RestaurantPOS_OrderedProductKOT.TotalAmount,RestaurantPOS_OrderInfoKOT.ID, RestaurantPOS_OrderInfoKOT.TicketNo,RestaurantPOS_OrderInfoKOT.TableNo, RestaurantPOS_OrderInfoKOT.BillDate, RestaurantPOS_OrderInfoKOT.GrandTotal FROM Category INNER JOIN Kitchen ON Category.Kitchen = Kitchen.Kitchenname INNER JOIN RestaurantPOS_OrderedProductKOT ON Category.CategoryName = RestaurantPOS_OrderedProductKOT.Category INNER JOIN RestaurantPOS_OrderInfoKOT ON RestaurantPOS_OrderedProductKOT.TicketID = RestaurantPOS_OrderInfoKOT.ID where TicketNo='" & lblTicketNo.Text & "' and KitchenName=@d1"
            MyCommand.Parameters.AddWithValue("@d1", item)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantPOS_OrderInfoKOT")
            myDA.Fill(myDS, "Category")
            myDA.Fill(myDS, "Kitchen")
            myDA.Fill(myDS, "RestaurantPOS_OrderedProductKOT")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(Printer) from Kitchen where KitchenName=@d1 and IsEnabled='Yes'"
            cmd.Parameters.AddWithValue("@d1", item)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s1 = rdr.GetValue(0)
                rpt.PrintOptions.PrinterName = s1
                rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
                rpt.PrintToPrinter(1, False, 0, 0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Next
    End Sub
    Sub PrintUpdateFunc2()
        Cursor = Cursors.WaitCursor
        Timer4.Enabled = True
        Dim rpt As New rptRestaurantPOSKOTUpdatedInvoice 'The report you created.
        Dim myConnection As SqlConnection
        Dim MyCommand, MyCommand1 As New SqlCommand()
        Dim myDA, myDA1 As New SqlDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New SqlConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT TicketNote,SCPer,SCAmount,RestaurantPOS_OrderedProductKOT.OP_ID,RestaurantPOS_OrderedProductKOT.Notes,Operator,GroupName, RestaurantPOS_OrderedProductKOT.TicketID, RestaurantPOS_OrderedProductKOT.Dish, RestaurantPOS_OrderedProductKOT.VATPer,RestaurantPOS_OrderedProductKOT.VATAmount, RestaurantPOS_OrderedProductKOT.STPer, RestaurantPOS_OrderedProductKOT.STAmount, RestaurantPOS_OrderedProductKOT.DiscountPer, RestaurantPOS_OrderedProductKOT.DiscountAmount,RestaurantPOS_OrderedProductKOT.Rate, RestaurantPOS_OrderedProductKOT.Quantity, RestaurantPOS_OrderedProductKOT.Amount, RestaurantPOS_OrderedProductKOT.TotalAmount,RestaurantPOS_OrderInfoKOT.ID, RestaurantPOS_OrderInfoKOT.TicketNo,RestaurantPOS_OrderInfoKOT.TableNo, RestaurantPOS_OrderInfoKOT.BillDate, RestaurantPOS_OrderInfoKOT.GrandTotal FROM RestaurantPOS_OrderedProductKOT INNER JOIN  RestaurantPOS_OrderInfoKOT ON RestaurantPOS_OrderedProductKOT.TicketID = RestaurantPOS_OrderInfoKOT.ID where RestaurantPOS_OrderInfoKOT.TicketNo='" & lblTicketNo.Text & "'"
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "RestaurantPOS_OrderInfoKOT")
        myDA.Fill(myDS, "RestaurantPOS_OrderedProductKOT")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        con = New SqlConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
        cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            s2 = rdr.GetValue(0)
            rpt.PrintOptions.PrinterName = s2
            rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
            rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
            rpt.PrintToPrinter(1, False, 0, 0)
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
    Sub PrintUpdate()
        Try
            If K4.Text = "Yes" Then
                PrintUpdateFunc2()
            End If
            PrintUpdateFunc1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtKOTDiscPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtKOTDiscPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtKOTDiscPer.Text
            Dim selectionStart = Me.txtKOTDiscPer.SelectionStart
            Dim selectionLength = Me.txtKOTDiscPer.SelectionLength

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

    Private Sub txtKOTDiscPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtKOTDiscPer.TextChanged
        Calc()
        FillCurrencyKOT()
    End Sub
    Sub DisableHSBar()

        flpCategoriesKOT.HorizontalScroll.Maximum = 0
        flpCategoriesKOT.AutoScroll = False
        flpCategoriesKOT.VerticalScroll.Visible = False
        flpCategoriesKOT.AutoScroll = True

        flpCategoriesHD.HorizontalScroll.Maximum = 0
        flpCategoriesHD.AutoScroll = False
        flpCategoriesHD.VerticalScroll.Visible = False
        flpCategoriesHD.AutoScroll = True

        'flpCategoriesEB.HorizontalScroll.Maximum = 0
        'flpCategoriesEB.AutoScroll = False
        'flpCategoriesEB.VerticalScroll.Visible = False
        'flpCategoriesEB.AutoScroll = True

        flpCategoriesTA.HorizontalScroll.Maximum = 0
        flpCategoriesTA.AutoScroll = False
        flpCategoriesTA.VerticalScroll.Visible = False
        flpCategoriesTA.AutoScroll = True

        'flpEB.HorizontalScroll.Maximum = 0
        'flpEB.AutoScroll = False
        'flpEB.VerticalScroll.Visible = False
        'flpEB.AutoScroll = True

        flpTA.HorizontalScroll.Maximum = 0
        flpTA.AutoScroll = False
        flpTA.VerticalScroll.Visible = False
        flpTA.AutoScroll = True

        flpKOT.HorizontalScroll.Maximum = 0
        flpKOT.AutoScroll = False
        flpKOT.VerticalScroll.Visible = False
        flpKOT.AutoScroll = True

        flpItemsKOT.HorizontalScroll.Maximum = 0
        flpItemsKOT.AutoScroll = False
        flpItemsKOT.VerticalScroll.Visible = False
        flpItemsKOT.AutoScroll = True

        'flpItemsEB.HorizontalScroll.Maximum = 0
        'flpItemsEB.AutoScroll = False
        'flpItemsEB.VerticalScroll.Visible = False
        'flpItemsEB.AutoScroll = True

        flpItemsHD.HorizontalScroll.Maximum = 0
        flpItemsHD.AutoScroll = False
        flpItemsHD.VerticalScroll.Visible = False
        flpItemsHD.AutoScroll = True

        flpItemsTA.HorizontalScroll.Maximum = 0
        flpItemsTA.AutoScroll = False
        flpItemsTA.VerticalScroll.Visible = False
        flpItemsTA.AutoScroll = True
    End Sub
    Dim UserButtonsT As List(Of Button) = New List(Of Button)
    Private Sub Button1T_Click(sender As System.Object, e As System.EventArgs)
        Try
            lblTableNo.Text = ""
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text.Trim()
            Dim strText() As String
            strText = Split(str, vbCrLf)
            lblTableNo.Text = strText(0)
            cmbGroup.Enabled = True
            FillGroup()
            FillAvailableTables()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub frmRestaurantPOS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetAccessList()
        GetSections()
        FillAvailableTables()
        GetSMIISetting()
        LoadData()
        OrderNo()
        DisableHSBar()
        GetHotelName()
        GetCustomerDisplayPort()
        GetTaxType()
        IsEnabledCallerID()
        lblCustomer.Text = ""
        txtInfo.Text = ""
        Try
            txtTillID.Text = System.Net.Dns.GetHostName
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT RTRIM(CallerIDPort) from POSprinterSetting where TillID=@d1 and CallerID='Yes'"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtInfo.Text = ""
                txtCallerIDComPort.Text = rdr.GetValue(0)
                With com1
                    .PortName = txtCallerIDComPort.Text
                    .BaudRate = 9600
                    .Parity = Parity.None
                    .DataBits = 8
                    .StopBits = StopBits.One
                    .RtsEnable = True
                End With
                AddHandler com1.DataReceived, New SerialDataReceivedEventHandler(AddressOf com1_DataReceived)
                com1.Open()
                Me.com1.WriteLine("AT+VCID=1" & System.Environment.NewLine)
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtTADiscountPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTADiscountPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtTADiscountPer.Text
            Dim selectionStart = Me.txtTADiscountPer.SelectionStart
            Dim selectionLength = Me.txtTADiscountPer.SelectionLength

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

    Private Sub txtTADiscountPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTADiscountPer.TextChanged
        Calc1()
        fillCurrencyTA()
    End Sub

    Private Sub txtHDDiscountPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtHDDiscountPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtHDDiscountPer.Text
            Dim selectionStart = Me.txtHDDiscountPer.SelectionStart
            Dim selectionLength = Me.txtHDDiscountPer.SelectionLength

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

    Private Sub txtEBDiscountPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            'Dim text = Me.txtEBDiscountPer.Text
            'Dim selectionStart = Me.txtEBDiscountPer.SelectionStart
            'Dim selectionLength = Me.txtEBDiscountPer.SelectionLength

            'Text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(Text, New Integer) AndAlso Text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(Text, New Double) AndAlso Text.IndexOf("."c) < Text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtCash3_KeyPress_1(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            'Dim text = Me.txtCash3.Text
            'Dim selectionStart = Me.txtCash3.SelectionStart
            'Dim selectionLength = Me.txtCash3.SelectionLength

            'Text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(Text, New Integer) AndAlso Text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(Text, New Double) AndAlso Text.IndexOf("."c) < Text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtSubTotal1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubTotal1.TextChanged
        Calc1()
    End Sub

    Private Sub txtParcelCharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtParcelCharges.TextChanged
        Calc1()
        fillCurrencyTA()
    End Sub

    Private Sub txtHDDiscountPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHDDiscountPer.TextChanged
        Calc2()
    End Sub

    Private Sub txtEBDiscountPer_TextChanged(sender As System.Object, e As System.EventArgs)
        Calc3()
        fillCurrencyEB()
    End Sub

    Private Sub txtCash3_TextChanged_1(sender As System.Object, e As System.EventArgs)
        Calc3()
        fillCurrencyEB()
    End Sub

    Private Sub btnTables_Click(sender As System.Object, e As System.EventArgs) Handles btnTables.Click
        frmTablesList.FillAvailableTables()
        frmTablesList.ShowDialog()
    End Sub
    Sub FillAvailableTables()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(R_Table.TableNo),BkColor,Sum(Case when KOT_Status not in ('Closed','Void') then GrandTotal else NULL end),Max(Case when KOT_Status not in ('Closed','Void') then DateDiff(Minute,(BillDate),GetDate()) else NULL end) from R_Table left Join RestaurantPOS_OrderInfoKOT on R_Table.TableNo=RestaurantPOS_OrderInfoKOT.TableNo where Status='Activate' group By R_Table.TableNo,BkColor ORDER BY LEFT(R_Table.TableNo, PATINDEX('%[0-9]%', R_Table.TableNo)-1),CONVERT(INT, SUBSTRING(R_Table.TableNo, PATINDEX('%[0-9]%', R_Table.TableNo), LEN(R_Table.TableNo))) "
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpTables.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button

                btn.TextAlign = ContentAlignment.MiddleCenter
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                If Val(rdr.GetValue(1)) = "-65536" Then
                    btn.Text = rdr.GetValue(0) & Environment.NewLine & rdr.GetValue(2) & Environment.NewLine & rdr.GetValue(3) & " " & "Minutes"
                Else
                    btn.Text = rdr.GetValue(0)
                End If
                btn.BackColor = btnColor
                btn.FlatStyle = FlatStyle.Popup
                btn.TextAlign = ContentAlignment.MiddleCenter
                btn.Width = 100
                btn.Height = 45
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtonsT.Add(btn)
                flpTables.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.Button1T_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub txtItemsKOT_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtItemsKOT.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Try
                    Dim str As String
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT DishName FROM Dish WHERE Barcode=@d1 and MI_Status='Active'"
                    cmd.Parameters.AddWithValue("@d1", txtItemsKOT.Text)
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        str = rdr.GetValue(0)
                    Else
                        txtItemsKOT.Text = ""
                        txtItemsKOT.Focus()
                        Exit Sub
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty <=0"
                    cmd = New SqlCommand(ctX)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", str)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        frmCustomDialog9.ShowDialog()
                        Exit Sub
                    End If
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty < 10"
                    cmd = New SqlCommand(sql)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", str)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        frmCustomDialog16.ShowDialog()
                    End If
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select Dish from Recipe where Dish=@d1"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", str)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                        cmd.Parameters.AddWithValue("@d1", str)
                        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        dgw.Rows.Clear()
                        While (rdr.Read() = True)
                            dgw.Rows.Add(rdr(0), rdr(1))
                        End While
                        con.Close()
                        For Each dr As DataGridViewRow In dgw.Rows
                            Dim con As New SqlConnection(cs)
                            con.Open()
                            Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                            cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                            Dim da As New SqlDataAdapter(cmd)
                            Dim ds As DataSet = New DataSet()
                            da.Fill(ds)
                            Dim i1 As Decimal
                            If ds.Tables(0).Rows.Count > 0 Then
                                i1 = ds.Tables(0).Rows(0)("Qty")
                                If Val(dr.Cells(1).Value) > Val(i1) Then
                                    frmCustomDialog13.ShowDialog()
                                    Exit Sub
                                End If
                            End If
                            con.Close()
                        Next
                    End If
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT DIRate,Category FROM Dish WHERE DishName=@d1"
                    cmd.Parameters.AddWithValue("@d1", str)
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        txtRate_Food.Text = rdr.GetValue(0)
                        txtCategory_Food.Text = rdr.GetString(1)
                        txtDiscountPer_Food.Text = 0.0
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT VAT,ST,SC FROM Category WHERE CategoryName=@d1"
                    cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        txtVATPer_Food.Text = rdr.GetValue(0)
                        txtServiceTaxPer_Food.Text = rdr.GetValue(1)
                        txtSCPer.Text = rdr.GetValue(2)
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    Compute()
                    DataGridView1.Rows.Add(str, Val(txtRate_Food.Text), 1, Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtSCPer.Text), Val(txtSCAmount.Text), Val(txtTotalAmt_Food.Text))
                    Dim k As Double = 0
                    k = GrandTotal_Food()
                    k = Math.Round(k, 2)
                    lblBalance.Text = k
                    ItemDataSubString(str)
                    CustomerDisplay(subt, Val(txtTotalAmt_Food.Text), Val(lblBalance.Text))
                    Clear()
                    DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(0)
                    txtItemsKOT.Text = ""
                    txtItemsKOT.Focus()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtItemsTA_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtItemsTA.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim str As String
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT DishName FROM Dish WHERE Barcode=@d1 and MI_Status='Active'"
                cmd.Parameters.AddWithValue("@d1", txtItemsTA.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    str = rdr.GetValue(0)
                Else
                    txtItemsTA.Text = ""
                    txtItemsTA.Focus()
                    Exit Sub
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con = New SqlConnection(cs)
                con.Open()
                Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty <=0"
                cmd = New SqlCommand(ctX)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    frmCustomDialog9.ShowDialog()
                    Exit Sub
                End If
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty < 10"
                cmd = New SqlCommand(sql)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    frmCustomDialog16.ShowDialog()
                End If
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Dish from Recipe where Dish=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                    cmd.Parameters.AddWithValue("@d1", str)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        dgw.Rows.Add(rdr(0), rdr(1))
                    End While
                    con.Close()
                    For Each dr As DataGridViewRow In dgw.Rows
                        Dim con As New SqlConnection(cs)
                        con.Open()
                        Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                        cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                        Dim da As New SqlDataAdapter(cmd)
                        Dim ds As DataSet = New DataSet()
                        da.Fill(ds)
                        Dim i1 As Decimal
                        If ds.Tables(0).Rows.Count > 0 Then
                            i1 = ds.Tables(0).Rows(0)("Qty")
                            If Val(dr.Cells(1).Value) > Val(i1) Then
                                frmCustomDialog13.ShowDialog()
                                Exit Sub
                            End If
                        End If
                        con.Close()
                    Next
                End If
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT TARate,Category FROM Dish WHERE DishName=@d1"
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtRate_Food.Text = rdr.GetValue(0)
                    txtCategory_Food.Text = rdr.GetString(1)
                    txtDiscountPer_Food.Text = 0.0
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT VAT,ST,SC FROM Category WHERE CategoryName=@d1"
                cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtVATPer_Food.Text = rdr.GetValue(0)
                    txtServiceTaxPer_Food.Text = rdr.GetValue(1)
                    txtSCPer.Text = rdr.GetValue(2)
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                Compute()
                DataGridView3.Rows.Add(str, Val(txtRate_Food.Text), 1, Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtSCPer.Text), Val(txtSCAmount.Text), Val(txtTotalAmt_Food.Text), "", Val(txtDiscountPer_Food.Text))
                Dim k As Double = 0
                k = GrandTotal_Food2()
                k = Math.Round(k, 2)
                lblBalance1.Text = k
                txtSubTotal1.Text = Val(lblBalance1.Text)
                Calc1()
                fillCurrencyTA()
                ItemDataSubString(str)
                CustomerDisplay(subt, Val(txtTotalAmt_Food.Text), Val(txtGrandTotal1.Text))
                Clear()
                DataGridView3.CurrentCell = DataGridView3.Rows(DataGridView3.Rows.Count - 1).Cells(0)
                txtItemsTA.Text = ""
                txtItemsTA.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtItemsHD_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtItemsHD.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim str As String
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT DishName FROM Dish WHERE Barcode=@d1 and MI_Status='Active'"
                cmd.Parameters.AddWithValue("@d1", txtItemsHD.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    str = rdr.GetValue(0)
                Else
                    txtItemsHD.Text = ""
                    txtItemsHD.Focus()
                    Exit Sub
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con = New SqlConnection(cs)
                con.Open()
                Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty <=0"
                cmd = New SqlCommand(ctX)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    frmCustomDialog9.ShowDialog()
                    Exit Sub
                End If
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty < 10"
                cmd = New SqlCommand(sql)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    frmCustomDialog16.ShowDialog()
                End If
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Dish from Recipe where Dish=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                    cmd.Parameters.AddWithValue("@d1", str)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        dgw.Rows.Add(rdr(0), rdr(1))
                    End While
                    con.Close()
                    For Each dr As DataGridViewRow In dgw.Rows
                        Dim con As New SqlConnection(cs)
                        con.Open()
                        Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                        cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                        Dim da As New SqlDataAdapter(cmd)
                        Dim ds As DataSet = New DataSet()
                        da.Fill(ds)
                        Dim i1 As Decimal
                        If ds.Tables(0).Rows.Count > 0 Then
                            i1 = ds.Tables(0).Rows(0)("Qty")
                            If Val(dr.Cells(1).Value) > Val(i1) Then
                                frmCustomDialog13.ShowDialog()
                                Exit Sub
                            End If
                        End If
                        con.Close()
                    Next
                End If
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT HDRate,Category FROM Dish WHERE DishName=@d1"
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtRate_Food.Text = rdr.GetValue(0)
                    txtCategory_Food.Text = rdr.GetString(1)
                    txtDiscountPer_Food.Text = 0.0
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT VAT,ST,SC FROM Category WHERE CategoryName=@d1"
                cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtVATPer_Food.Text = rdr.GetValue(0)
                    txtServiceTaxPer_Food.Text = rdr.GetValue(1)
                    txtSCPer.Text = rdr.GetValue(2)
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                Compute()
                DataGridView4.Rows.Add(str, Val(txtRate_Food.Text), 1, Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtSCPer.Text), Val(txtSCAmount.Text), Val(txtTotalAmt_Food.Text), "", Val(txtDiscountPer_Food.Text))
                Dim k As Double = 0
                k = GrandTotal_Food3()
                k = Math.Round(k, 2)
                lblBalance2.Text = k
                txtSubTotal.Text = Val(lblBalance2.Text)
                Calc2()
                ItemDataSubString(str)
                CustomerDisplay(subt, Val(txtTotalAmt_Food.Text), Val(txtGrandTotal2.Text))
                Clear()
                DataGridView4.CurrentCell = DataGridView4.Rows(DataGridView4.Rows.Count - 1).Cells(0)
                txtItemsHD.Text = ""
                txtItemsHD.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtItemsEB_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Then
                Dim str As String
                'con = New SqlConnection(cs)
                'con.Open()
                'cmd = con.CreateCommand()
                'cmd.CommandText = "SELECT DishName FROM Dish WHERE Barcode=@d1 and MI_Status='Active'"
                'cmd.Parameters.AddWithValue("@d1", txtItemsEB.Text)
                'rdr = cmd.ExecuteReader()
                'If rdr.Read() Then
                '    str = rdr.GetValue(0)
                'Else
                '    'txtItemsEB.Text = ""
                '    'txtItemsEB.Focus()
                '    Exit Sub
                'End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con = New SqlConnection(cs)
                con.Open()
                Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty <=0"
                cmd = New SqlCommand(ctX)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    frmCustomDialog9.ShowDialog()
                    Exit Sub
                End If
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1 and Qty < 10"
                cmd = New SqlCommand(sql)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    frmCustomDialog16.ShowDialog()
                End If
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select Dish from Recipe where Dish=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                    cmd.Parameters.AddWithValue("@d1", str)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        dgw.Rows.Add(rdr(0), rdr(1))
                    End While
                    con.Close()
                    For Each dr As DataGridViewRow In dgw.Rows
                        Dim con As New SqlConnection(cs)
                        con.Open()
                        Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_RM where ProductID=@d1", con)
                        cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                        Dim da As New SqlDataAdapter(cmd)
                        Dim ds As DataSet = New DataSet()
                        da.Fill(ds)
                        Dim i1 As Decimal
                        If ds.Tables(0).Rows.Count > 0 Then
                            i1 = ds.Tables(0).Rows(0)("Qty")
                            If Val(dr.Cells(1).Value) > Val(i1) Then
                                frmCustomDialog13.ShowDialog()
                                Exit Sub
                            End If
                        End If
                        con.Close()
                    Next
                End If
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT DIRate,Category FROM Dish WHERE DishName=@d1"
                cmd.Parameters.AddWithValue("@d1", str)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtRate_Food.Text = rdr.GetValue(0)
                    txtCategory_Food.Text = rdr.GetString(1)
                    txtDiscountPer_Food.Text = 0.0
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT VAT,ST,SC FROM Category WHERE CategoryName=@d1"
                cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtVATPer_Food.Text = rdr.GetValue(0)
                    txtServiceTaxPer_Food.Text = rdr.GetValue(1)
                    txtSCPer.Text = rdr.GetValue(2)
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                Compute()
                'DataGridView5.Rows.Add(str, Val(txtRate_Food.Text), 1, Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtSCPer.Text), Val(txtSCAmount.Text), Val(txtTotalAmt_Food.Text), "", Val(txtDiscountPer_Food.Text))
                'Dim k As Double = 0
                'k = GrandTotal_Food4()
                'k = Math.Round(k, 2)
                'lblBalance3.Text = k
                'txtGrandTotal3.Text = Val(lblBalance3.Text)
                'Calc3()
                'fillCurrencyEB()
                'ItemDataSubString(str)
                'CustomerDisplay(subt, Val(txtTotalAmt_Food.Text), Val(txtGrandTotal3.Text))
                'Clear()
                'DataGridView5.CurrentCell = DataGridView5.Rows(DataGridView5.Rows.Count - 1).Cells(0)
                'txtItemsEB.Text = ""
                'txtItemsEB.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(DishName),Dish.BackColor,RTRIM(Photo) from Category,Dish where Category.CategoryName=Dish.Category and DishName like '%" & txtItemsKOT.Text & "%' and MI_Status='Active' order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsKOT.Controls.Clear()
            Do While (rdr.Read())
                If txtSMII.Text = "Yes" Then
                    Dim Dflp As New FlowLayoutPanel
                    Dflp.Size = New System.Drawing.Size(110, 140)
                    Dflp.BackColor = Color.White
                    Dflp.BorderStyle = BorderStyle.FixedSingle
                    Dflp.FlowDirection = FlowDirection.TopDown
                    Dim btn As New Button
                    Dim btnX As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.Width = 108
                    btn.Height = 90
                    If rdr.GetValue(2).ToString() <> "" Then
                        btn.BackgroundImage = Image.FromFile(Application.StartupPath & rdr.GetValue(2).ToString())
                        btn.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Text = rdr.GetValue(0)
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 1.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
                    btn.ForeColor = System.Drawing.Color.Black
                    btnX.Text = rdr.GetValue(0)
                    btnX.FlatStyle = FlatStyle.Flat
                    btnX.Width = 108
                    btnX.Height = 35
                    btnX.FlatAppearance.BorderSize = 0
                    btnX.Text = rdr.GetValue(0)
                    btnX.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    btnX.ForeColor = Color.Black
                    UserButtons.Add(btn)
                    UserButtons.Add(btnX)
                    Dflp.Controls.Add(btn)
                    Dflp.Controls.Add(btnX)
                    flpItemsKOT.Controls.Add(Dflp)
                    AddHandler btn.Click, AddressOf Me.Button1_Click
                    AddHandler btnX.Click, AddressOf Me.Button1X_Click
                Else
                    Dim btn As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.FlatStyle = FlatStyle.Popup
                    Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                    btn.BackColor = btnColor
                    btn.ForeColor = Color.White
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Width = 110
                    btn.Height = 60
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    UserButtons.Add(btn)
                    flpItemsKOT.Controls.Add(btn)
                    AddHandler btn.Click, AddressOf Me.Button1_Click
                End If
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(DishName),Dish.BackColor,RTRIM(Photo) from Category,Dish where Category.CategoryName=Dish.Category and DishName like '%" & txtItemsTA.Text & "%' and MI_Status='Active' order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsTA.Controls.Clear()
            Do While (rdr.Read())
                If txtSMII.Text = "Yes" Then
                    Dim Dflp As New FlowLayoutPanel
                    Dflp.Size = New System.Drawing.Size(110, 140)
                    Dflp.BackColor = Color.White
                    Dflp.BorderStyle = BorderStyle.FixedSingle
                    Dflp.FlowDirection = FlowDirection.TopDown
                    Dim btn As New Button
                    Dim btnX As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.Width = 108
                    btn.Height = 90
                    If rdr.GetValue(2).ToString() <> "" Then
                        btn.BackgroundImage = Image.FromFile(Application.StartupPath & rdr.GetValue(2).ToString())
                        btn.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Text = rdr.GetValue(0)
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 1.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
                    btn.ForeColor = System.Drawing.Color.Black
                    btnX.Text = rdr.GetValue(0)
                    btnX.FlatStyle = FlatStyle.Flat
                    btnX.Width = 108
                    btnX.Height = 35
                    btnX.FlatAppearance.BorderSize = 0
                    btnX.Text = rdr.GetValue(0)
                    btnX.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    btnX.ForeColor = Color.Black
                    UserButtons.Add(btn)
                    UserButtons.Add(btnX)
                    Dflp.Controls.Add(btn)
                    Dflp.Controls.Add(btnX)
                    flpItemsTA.Controls.Add(Dflp)
                    AddHandler btn.Click, AddressOf Me.ButtonTA1_Click
                    AddHandler btnX.Click, AddressOf Me.ButtonTA1X_Click
                Else
                    Dim btn As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.FlatStyle = FlatStyle.Popup
                    Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                    btn.BackColor = btnColor
                    btn.ForeColor = Color.White
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Width = 110
                    btn.Height = 60
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    UserButtons.Add(btn)
                    flpItemsTA.Controls.Add(btn)
                    AddHandler btn.Click, AddressOf Me.ButtonTA1_Click
                End If
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(DishName),Dish.BackColor,RTRIM(Photo) from Category,Dish where Category.CategoryName=Dish.Category and DishName like '%" & txtItemsHD.Text & "%' and MI_Status='Active' order by 1"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpItemsHD.Controls.Clear()
            Do While (rdr.Read())
                If txtSMII.Text = "Yes" Then
                    Dim Dflp As New FlowLayoutPanel
                    Dflp.Size = New System.Drawing.Size(110, 140)
                    Dflp.BackColor = Color.White
                    Dflp.BorderStyle = BorderStyle.FixedSingle
                    Dflp.FlowDirection = FlowDirection.TopDown
                    Dim btn As New Button
                    Dim btnX As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.Width = 108
                    btn.Height = 90
                    If rdr.GetValue(2).ToString() <> "" Then
                        btn.BackgroundImage = Image.FromFile(Application.StartupPath & rdr.GetValue(2).ToString())
                        btn.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Text = rdr.GetValue(0)
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 1.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
                    btn.ForeColor = System.Drawing.Color.Black
                    btnX.Text = rdr.GetValue(0)
                    btnX.FlatStyle = FlatStyle.Flat
                    btnX.Width = 108
                    btnX.Height = 35
                    btnX.FlatAppearance.BorderSize = 0
                    btnX.Text = rdr.GetValue(0)
                    btnX.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    btnX.ForeColor = Color.Black
                    UserButtons.Add(btn)
                    UserButtons.Add(btnX)
                    Dflp.Controls.Add(btn)
                    Dflp.Controls.Add(btnX)
                    flpItemsHD.Controls.Add(Dflp)
                    AddHandler btn.Click, AddressOf Me.ButtonHD1_Click
                    AddHandler btnX.Click, AddressOf Me.ButtonHD1X_Click
                Else
                    Dim btn As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.FlatStyle = FlatStyle.Popup
                    Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                    btn.BackColor = btnColor
                    btn.ForeColor = Color.White
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Width = 110
                    btn.Height = 60
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    UserButtons.Add(btn)
                    flpItemsHD.Controls.Add(btn)
                    AddHandler btn.Click, AddressOf Me.ButtonHD1_Click
                End If
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        Try
            con = New SqlConnection(cs)
            con.Open()
            'Dim cmdText1 As String = "SELECT RTRIM(DishName),Dish.BackColor,RTRIM(Photo) from Category,Dish where Category.CategoryName=Dish.Category and DishName like '%" & txtItemsEB.Text & "%' and MI_Status='Active' order by 1"
            'cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            'flpItemsEB.Controls.Clear()
            Do While (rdr.Read())
                If txtSMII.Text = "Yes" Then
                    Dim Dflp As New FlowLayoutPanel
                    Dflp.Size = New System.Drawing.Size(110, 140)
                    Dflp.BackColor = Color.White
                    Dflp.BorderStyle = BorderStyle.FixedSingle
                    Dflp.FlowDirection = FlowDirection.TopDown
                    Dim btn As New Button
                    Dim btnX As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.Width = 108
                    btn.Height = 90
                    If rdr.GetValue(2).ToString() <> "" Then
                        btn.BackgroundImage = Image.FromFile(Application.StartupPath & rdr.GetValue(2).ToString())
                        btn.BackgroundImageLayout = ImageLayout.Stretch
                    End If
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Text = rdr.GetValue(0)
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 1.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
                    btn.ForeColor = System.Drawing.Color.Black
                    btnX.Text = rdr.GetValue(0)
                    btnX.FlatStyle = FlatStyle.Flat
                    btnX.Width = 108
                    btnX.Height = 35
                    btnX.FlatAppearance.BorderSize = 0
                    btnX.Text = rdr.GetValue(0)
                    btnX.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    btnX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    btnX.ForeColor = Color.Black
                    UserButtons.Add(btn)
                    UserButtons.Add(btnX)
                    Dflp.Controls.Add(btn)
                    Dflp.Controls.Add(btnX)
                    'flpItemsEB.Controls.Add(Dflp)
                    AddHandler btn.Click, AddressOf Me.ButtonEB1_Click
                    AddHandler btnX.Click, AddressOf Me.ButtonEB1X_Click
                Else
                    Dim btn As New Button
                    btn.Text = rdr.GetValue(0)
                    btn.FlatStyle = FlatStyle.Popup
                    Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                    btn.BackColor = btnColor
                    btn.ForeColor = Color.White
                    btn.FlatStyle = FlatStyle.Flat
                    btn.FlatAppearance.BorderSize = 0
                    btn.Width = 110
                    btn.Height = 60
                    btn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    UserButtons.Add(btn)
                    'flpItemsEB.Controls.Add(btn)
                    AddHandler btn.Click, AddressOf Me.ButtonEB1_Click
                End If
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnWallet_Click(sender As System.Object, e As System.EventArgs) Handles btnWallet.Click
        frmWalletList.lblSet.Text = "KOT"
        frmWalletList.ShowDialog()
    End Sub

    Private Sub btnWallet1_Click(sender As System.Object, e As System.EventArgs) Handles btnWallet1.Click
        frmWalletList.lblSet.Text = "Takeaway"
        frmWalletList.ShowDialog()
        paymentMode = "Wallet"
    End Sub

    Private Sub btnWallet2_Click(sender As System.Object, e As System.EventArgs) Handles btnWallet2.Click
        frmWalletList.lblSet.Text = "Home Delivery"
        frmWalletList.ShowDialog()
    End Sub

    Private Sub btnWallet3_Click(sender As System.Object, e As System.EventArgs)
        frmWalletList.lblSet.Text = "Express Billing"
        frmWalletList.ShowDialog()
    End Sub

    Private Sub btnUpdateFinalBill_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdateFinalBill.Click
        Try
            If DataGridView2.Rows.Count = 0 Then
                MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If lblPaymentMode.Text = "" Then
                MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblPaymentMode.Focus()
                Exit Sub
            End If
            If txtCash.Text = "" Then
                MessageBox.Show("Please enter cash", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCash.Focus()
                Exit Sub
            End If
            If Val(txtGrandTotal.Text) > Val(txtCash.Text) Then
                MessageBox.Show("cash can not be less than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update RestaurantPOS_BillingInfoKOT set GrandTotal=" & txtGrandTotal.Text & ",Cash=" & txtCash.Text & ",Change=" & txtChange.Text & ",PaymentMode=@d1,ExchangeRate=" & txtExchangeRate.Text & ",CurrencyCode=@d2,KOTDiscountPer=" & txtKOTDiscPer.Text & ",DiscountReason=@d3 where BillNo= '" & lblBillNo.Text & "'"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", lblPaymentMode.Text)
            If lblCurrencyValKOT.Text <> "" Then
                cmd.Parameters.AddWithValue("@d2", lblCurrencyValKOT.Text)
            Else
                cmd.Parameters.AddWithValue("@d2", str)
            End If
            cmd.Parameters.AddWithValue("@d3", txtKOTDiscountAmount.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ctX As String = "delete from RestaurantPOS_OrderedProductBillKOT where BillID=@d1"
            cmd = New SqlCommand(ctX)
            cmd.Parameters.AddWithValue("@d1", Val(txtBillID.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into RestaurantPOS_OrderedProductBillKOT(BillID,TableNo,Dish,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,SCPer,SCAmount,TotalAmount) VALUES (" & txtBillID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d13", Val(row.Cells(12).Value))
                    cmd.Parameters.AddWithValue("@d14", Val(row.Cells(13).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            If lblPaymentMode.Text = "Cash" Then
                LedgerUpdate(System.DateTime.Today, "Cash Account", 0, Val(txtGrandTotal.Text) * Val(txtExchangeRate.Text), "", lblBillNo.Text, "Restaurant POS")
            ElseIf lblPaymentMode.Text = "Credit Card" Or lblPaymentMode.Text = "Debit Card" Then
                LedgerUpdate(System.DateTime.Today, "Bank Account", 0, Val(txtGrandTotal.Text) * Val(txtExchangeRate.Text), "", lblBillNo.Text, "Restaurant POS")
            Else
                LedgerUpdate(System.DateTime.Today, "Wallet Account", 0, Val(txtGrandTotal.Text) * Val(txtExchangeRate.Text), "", lblBillNo.Text, "Restaurant POS")
            End If
            If lblPaymentMode.Text = "Cash" And Val(txtCash.Text) > 0 Then
                OpenCashdrawer()
            End If
            fillTableNo()
            'btnUpdate.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtGrandTotal1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtGrandTotal1.TextChanged
        Calc1()
    End Sub

    Private Sub txtKOTDiscPer_Enter(sender As System.Object, e As System.EventArgs) Handles txtKOTDiscPer.Enter
        OSKeyboard()
    End Sub

    Private Sub txtTADiscountPer_Enter(sender As System.Object, e As System.EventArgs) Handles txtTADiscountPer.Enter, txtParcelCharges.Enter
        OSKeyboard()
    End Sub

    Private Sub txtHDDiscountPer_Enter(sender As System.Object, e As System.EventArgs) Handles txtHDDiscountPer.Enter
        OSKeyboard()
    End Sub

    Private Sub txtEBDiscountPer_Enter(sender As System.Object, e As System.EventArgs)
        OSKeyboard()
    End Sub

    Private Sub txtHDDiscountReason_Enter(sender As System.Object, e As System.EventArgs) Handles txtHDDiscountAmount.Enter
        OSKeyboard()
    End Sub

    Private Sub txtTADiscountReason_Enter(sender As System.Object, e As System.EventArgs) Handles txtTADiscountAmount.Enter
        OSKeyboard()
    End Sub

    Private Sub txtKOTDiscountReason_Enter(sender As System.Object, e As System.EventArgs) Handles txtKOTDiscountAmount.Enter
        OSKeyboard()
    End Sub

    Private Sub btnPizza1_Click(sender As System.Object, e As System.EventArgs) Handles btnPizza1.Click
        frmPizzaPOS.Reset()
        frmPizzaPOS.lblSet.Text = "KOT"
        frmPizzaPOS.ShowDialog()
    End Sub

    Private Sub btnPizza3_Click(sender As System.Object, e As System.EventArgs) Handles btnPizza3.Click
        frmPizzaPOS.Reset()
        frmPizzaPOS.lblSet.Text = "HD"
        frmPizzaPOS.ShowDialog()
    End Sub

    Private Sub btnPizza2_Click(sender As System.Object, e As System.EventArgs) Handles btnPizza2.Click
        frmPizzaPOS.Reset()
        frmPizzaPOS.lblSet.Text = "TA"
        frmPizzaPOS.ShowDialog()
    End Sub

    Private Sub btnPizza4_Click(sender As System.Object, e As System.EventArgs)
        frmPizzaPOS.Reset()
        frmPizzaPOS.lblSet.Text = "EB"
        frmPizzaPOS.ShowDialog()
    End Sub
    Public Property SV As Integer
        Get
            Return scrollValue
        End Get

        Set(ByVal value As Integer)
            scrollValue = value
            If scrollValue < flpCategoriesKOT.VerticalScroll.Minimum Then
                scrollValue = flpCategoriesKOT.VerticalScroll.Minimum
            End If

            If scrollValue > flpCategoriesKOT.VerticalScroll.Maximum Then
                scrollValue = flpCategoriesKOT.VerticalScroll.Maximum
            End If
            flpCategoriesKOT.VerticalScroll.Value = scrollValue
            flpCategoriesKOT.PerformLayout()
        End Set
    End Property

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs)
        'Dim posY As Integer = 0
        'If posY >= 0 Then posY = -1
        'flpCategoriesKOT.ScrollUp(Math.Max(System.Threading.Interlocked.Decrement(posY), posY + 1))
        If scrollValue > 0 Then
            SV -= flpCategoriesKOT.VerticalScroll.LargeChange
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs)
        'Dim posY As Integer = 0
        'If posY < 0 Then posY = 0
        'flpCategoriesKOT.ScrollDown(Math.Min(System.Threading.Interlocked.Increment(posY), posY - 1))
        SV += flpCategoriesKOT.VerticalScroll.LargeChange
        MsgBox(SV)
    End Sub

    Private Sub Timer4_Tick_1(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        Cursor = Cursors.Default
        Timer4.Enabled = False
    End Sub
    Public Property SV1 As Integer
        Get
            Return scrollValue
        End Get

        Set(ByVal value As Integer)
            scrollValue = value
            If scrollValue < flpItemsKOT.VerticalScroll.Minimum Then
                scrollValue = flpItemsKOT.VerticalScroll.Minimum
            End If

            If scrollValue > flpItemsKOT.VerticalScroll.Maximum Then
                scrollValue = flpItemsKOT.VerticalScroll.Maximum
            End If

            flpItemsKOT.VerticalScroll.Value = scrollValue
            flpItemsKOT.PerformLayout()
        End Set
    End Property

    Private Sub btnScrollUpKOTItem_Click(sender As System.Object, e As System.EventArgs)
        SV1 -= flpItemsKOT.VerticalScroll.LargeChange
    End Sub

    Private Sub btnScrollDownKOTItem_Click(sender As System.Object, e As System.EventArgs)
        SV1 += flpItemsKOT.VerticalScroll.LargeChange
    End Sub

    Private Sub btnCards_Click(sender As System.Object, e As System.EventArgs) Handles btnCards.Click
        frmCards_POS.lblSet.Text = "Dine In Billing"
        frmCards_POS.ShowDialog()
    End Sub

    Private Sub btnCards1_Click(sender As System.Object, e As System.EventArgs) Handles btnCards1.Click
        frmCards_POS.lblSet.Text = "Take Away"
        frmCards_POS.ShowDialog()
        paymentMode = "Cards"
    End Sub

    Private Sub btnCards2_Click(sender As System.Object, e As System.EventArgs) Handles btnCards2.Click
        frmCards_POS.lblSet.Text = "Home Delivery"
        frmCards_POS.ShowDialog()
    End Sub

    Private Sub btnCard3_Click(sender As System.Object, e As System.EventArgs)
        frmCards_POS.lblSet.Text = "Express Billing"
        frmCards_POS.ShowDialog()
    End Sub

    Private Sub btnScanBCode_Click(sender As System.Object, e As System.EventArgs) Handles btnScanBCode.Click
        txtItemsKOT.Focus()
    End Sub

    Private Sub btnScanBCode3_Click(sender As System.Object, e As System.EventArgs)
        'txtItemsEB.Focus()
    End Sub

    Private Sub btnScanBCode2_Click(sender As System.Object, e As System.EventArgs) Handles btnScanBCode2.Click
        txtItemsHD.Focus()
    End Sub

    Private Sub btnScanBCode1_Click(sender As System.Object, e As System.EventArgs) Handles btnScanBCode1.Click
        txtItemsTA.Focus()
    End Sub
    Sub RollBackStock()
        Try
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim str As String = row.Cells(0).Value.ToString()
                Dim strText() As String
                strText = Split(str, vbCrLf)
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "select Dish from temp_Stock_Store where Dish=@d1"
                cmd = New SqlCommand(sql)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", strText(0))
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty + " & Val(row.Cells(2).Value) & " where Dish=@d1"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    cmd.ExecuteReader()
                    con.Close()
                End If
            Next
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim str As String = row.Cells(0).Value.ToString()
                Dim strText() As String
                strText = Split(str, vbCrLf)
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "select Dish from Recipe where Dish=@d1"
                cmd = New SqlCommand(sql)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", strText(0))
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        dgw.Rows.Add(rdr(0), rdr(1))
                    End While
                    con.Close()
                    For Each dr As DataGridViewRow In dgw.Rows
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock_RM set Qty=Qty + " & Val(dr.Cells(1).Value) * Val(row.Cells(2).Value) & " where ProductID=@d1"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    Next
                    RawMaterialUsedDel(lblTicketNo.Text)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub VoidBill()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctx As String = "Select Count(TicketNo) from RestaurantPOS_OrderInfoKOT where TableNo=@d1 and KOT_Status in ('Open','Served','Prepared')"
            cmd = New SqlCommand(ctx)
            cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                str2 = rdr.GetValue(0)
                If Val(str2) = 1 Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cbX As String = "Update R_Table set BkColor=@d2 where TableNo=@d1"
                    cmd = New SqlCommand(cbX)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", lblTableNo.Text)
                    cmd.Parameters.AddWithValue("@d2", Color.LightGreen.ToArgb())
                    cmd.ExecuteReader()
                    con.Close()
                End If
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "Update RestaurantPOS_OrderInfoKOT set KOT_Status='Void' where TicketNo=@d1"
            cmd = New SqlCommand(cb1)
            cmd.Parameters.AddWithValue("@d1", lblTicketNo.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "void the kot having Ticket No.'" & lblTicketNo.Text & "'"
            LogFunc(lblUserVAL.Text, st)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnVoid_Click(sender As System.Object, e As System.EventArgs) Handles btnVoid.Click
        Try
            If MessageBox.Show("Do you really want to void the kot?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("Does the stock affected?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    VoidBill()
                    Reset()
                    Reset()
                Else
                    RollBackStock()
                    VoidBill()
                    Reset()
                    Reset()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        OrderNo()
        lblPaymentMode.Text = "Cash"
        lblPaymentMode1.Text = "Cash"
        lblPaymentMode2.Text = "Cash"
        'lblPaymentMode3.Text = "Cash"
        GetOtherSetting()
        Reset()
        Reset1()
        Reset2()
        Reset3()
        Reset4()
        LoadData()
    End Sub

    Private Sub btnCreditCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditCustomer.Click
        If DataGridView2.Rows.Count = 0 Then
            MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        frmCreditCustomerBalance.lblSet.Text = "Dine In Billing"
        frmCreditCustomerBalance.Reset()
        frmCreditCustomerBalance.ShowDialog()
    End Sub

    Private Sub btnCreditCustomer1_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditCustomer1.Click
        If DataGridView3.Rows.Count = 0 Then
            MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        frmCreditCustomerBalance.lblSet.Text = "TA"
        frmCreditCustomerBalance.Reset()
        frmCreditCustomerBalance.ShowDialog()
        paymentMode = "Credit Customer"
    End Sub

    Private Sub btnCreditCustomer2_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditCustomer2.Click
        If DataGridView4.Rows.Count = 0 Then
            MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        frmCreditCustomerBalance.lblSet.Text = "HD"
        frmCreditCustomerBalance.Reset()
        frmCreditCustomerBalance.ShowDialog()
    End Sub

    Private Sub btnCreditCustomer3_Click(sender As System.Object, e As System.EventArgs)
        'If DataGridView5.Rows.Count = 0 Then
        '    MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'End If
        frmCreditCustomerBalance.lblSet.Text = "EB"
        frmCreditCustomerBalance.Reset()
        frmCreditCustomerBalance.ShowDialog()
    End Sub

    Private Sub txtKOTDiscountAmount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtKOTDiscountAmount.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtKOTDiscountAmount.Text
            Dim selectionStart = Me.txtKOTDiscountAmount.SelectionStart
            Dim selectionLength = Me.txtKOTDiscountAmount.SelectionLength

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

    Private Sub txtEBDiscountAmount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            'Dim text = Me.txtEBDiscountAmount.Text
            'Dim selectionStart = Me.txtEBDiscountAmount.SelectionStart
            'Dim selectionLength = Me.txtEBDiscountAmount.SelectionLength

            'Text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(Text, New Integer) AndAlso Text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(Text, New Double) AndAlso Text.IndexOf("."c) < Text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtHDDiscountAmount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtHDDiscountAmount.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtHDDiscountAmount.Text
            Dim selectionStart = Me.txtHDDiscountAmount.SelectionStart
            Dim selectionLength = Me.txtHDDiscountAmount.SelectionLength

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

    Private Sub txtTADiscountAmount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTADiscountAmount.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtTADiscountAmount.Text
            Dim selectionStart = Me.txtTADiscountAmount.SelectionStart
            Dim selectionLength = Me.txtTADiscountAmount.SelectionLength

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

    Private Sub cmbKOTDiscountType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbKOTDiscountType.SelectedIndexChanged
        Calc()
        FillCurrencyKOT()
    End Sub

    Private Sub txtKOTDiscountAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtKOTDiscountAmount.TextChanged
        Calc()
    End Sub

    Private Sub btnVoid1_Click(sender As System.Object, e As System.EventArgs) Handles btnVoid1.Click
        Try
            If MessageBox.Show("Do you really want to void the bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("Does the stock affected?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    VoidBill1()
                    Reset2()
                    Reset2()
                Else
                    RollBackStock1()
                    VoidBill1()
                    Reset2()
                    Reset2()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub RollBackStock1()
        Try
            For Each row As DataGridViewRow In DataGridView3.Rows
                Dim str As String = row.Cells(0).Value.ToString()
                Dim strText() As String
                strText = Split(str, vbCrLf)
                con = New SqlConnection(cs)
                con.Open()
                Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1"
                cmd = New SqlCommand(ctX)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", strText(0))
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty + " & Val(row.Cells(2).Value) & " where Dish=@d1"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    cmd.ExecuteReader()
                    con.Close()
                End If
            Next
            For Each row As DataGridViewRow In DataGridView3.Rows
                Dim str As String = row.Cells(0).Value.ToString()
                Dim strText() As String
                strText = Split(str, vbCrLf)
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "select Dish from Recipe where Dish=@d1"
                cmd = New SqlCommand(sql)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", strText(0))
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        dgw.Rows.Add(rdr(0), rdr(1))
                    End While
                    con.Close()
                    For Each dr As DataGridViewRow In dgw.Rows
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock_RM set Qty=Qty + " & Val(dr.Cells(1).Value) * Val(row.Cells(2).Value) & " where ProductID=@d1"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    Next
                    RawMaterialUsedDel(lblBillNo1.Text)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub VoidBill1()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "Update RestaurantPOS_BillingInfoTA set TA_Status='Void' where BillNo=@d1"
            cmd = New SqlCommand(cb1)
            cmd.Parameters.AddWithValue("@d1", lblBillNo1.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "void the bill having bill No.'" & lblBillNo1.Text & "'"
            LogFunc(lblUserVAL.Text, st)
            LedgerDelete(lblBillNo1.Text, "POS")
            LedgerDelete(lblBillNo1.Text, "Sales Invoice")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtTADiscountAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTADiscountAmount.TextChanged
        Calc1()
    End Sub

    Private Sub cmbTADiscountType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbTADiscountType.SelectedIndexChanged
        Calc1()
    End Sub
    Sub RollBackStock2()
        Try
            For Each row As DataGridViewRow In DataGridView4.Rows
                Dim str As String = row.Cells(0).Value.ToString()
                Dim strText() As String
                strText = Split(str, vbCrLf)
                con = New SqlConnection(cs)
                con.Open()
                Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1"
                cmd = New SqlCommand(ctX)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", strText(0))
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty + " & Val(row.Cells(2).Value) & " where Dish=@d1"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    cmd.ExecuteReader()
                    con.Close()
                End If
            Next
            For Each row As DataGridViewRow In DataGridView4.Rows
                Dim str As String = row.Cells(0).Value.ToString()
                Dim strText() As String
                strText = Split(str, vbCrLf)
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "select Dish from Recipe where Dish=@d1"
                cmd = New SqlCommand(sql)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", strText(0))
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    dgw.Rows.Clear()
                    While (rdr.Read() = True)
                        dgw.Rows.Add(rdr(0), rdr(1))
                    End While
                    con.Close()
                    For Each dr As DataGridViewRow In dgw.Rows
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock_RM set Qty=Qty + " & Val(dr.Cells(1).Value) * Val(row.Cells(2).Value) & " where ProductID=@d1"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    Next
                    RawMaterialUsedDel(lblBillNo2.Text)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub VoidBill2()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update RestaurantPOS_BillingInfoHD Set HD_Status='Cancelled' where BillNo=@d1"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", lblBillNo2.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "Cancelled the home delivery bill having Bill No.'" & lblBillNo2.Text & "'"
            LogFunc(lblUserVAL.Text, st)
            LedgerDelete(lblBillNo2.Text, "POS")
            LedgerDelete(lblBillNo2.Text, "Sales Invoice")
            MessageBox.Show("Successfully Changed", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset3()
            Reset3()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtHDDiscountAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHDDiscountAmount.TextChanged
        Calc2()
    End Sub

    Private Sub cmbHDDiscountType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbHDDiscountType.SelectedIndexChanged
        Calc2()
    End Sub

    Private Sub btnChangeStatus_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeStatus.Click
        frmHDStatus.txtHdID.Text = txtBillID2.Text
        frmHDStatus.ShowDialog()
    End Sub

    Private Sub TabPage4_Enter(sender As Object, e As System.EventArgs) Handles TabPage4.Enter
        lblOrderNo.Visible = True
        lblOD.Visible = True
        Reset3()
        GetTaxType()
    End Sub

    Private Sub TabPage5_Enter(sender As Object, e As System.EventArgs)
        lblOrderNo.Visible = True
        lblOD.Visible = True
        Reset4()
        GetTaxType()
    End Sub

    Private Sub TabPage3_Enter(sender As Object, e As System.EventArgs) Handles TabPage3.Enter
        lblOrderNo.Visible = True
        lblOD.Visible = True
        Reset2()
        GetTaxType()
    End Sub

    Private Sub TabPage1_Enter(sender As Object, e As System.EventArgs) Handles TabPage1.Enter
        Reset()
        GetTaxType()
        lblOrderNo.Visible = False
        lblOD.Visible = False
    End Sub

    Private Sub TabPage2_Enter(sender As Object, e As System.EventArgs) Handles TabPage2.Enter
        lblOrderNo.Visible = True
        lblOD.Visible = True
        Reset1()
        GetTaxType()
    End Sub

    Private Sub cmbEBDiscountType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Calc3()
    End Sub

    Private Sub txtEBDiscountAmount_TextChanged(sender As System.Object, e As System.EventArgs)
        Calc3()
    End Sub

    Private Sub btnVoid2_Click(sender As System.Object, e As System.EventArgs)
        Try
            If MessageBox.Show("Do you really want to void the bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("Does the stock affected?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    VoidBill3()
                    Reset4()
                    Reset4()
                Else
                    RollBackStock3()
                    VoidBill3()
                    Reset4()
                    Reset4()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub RollBackStock3()
        Try
            'For Each row As DataGridViewRow In DataGridView5.Rows
            '    Dim str As String = row.Cells(0).Value.ToString()
            '    Dim strText() As String
            '    strText = Split(str, vbCrLf)
            '    con = New SqlConnection(cs)
            '    con.Open()
            '    Dim ctX As String = "select Dish from temp_Stock_Store where Dish=@d1"
            '    cmd = New SqlCommand(ctX)
            '    cmd.Connection = con
            '    cmd.Parameters.AddWithValue("@d1", strText(0))
            '    rdr = cmd.ExecuteReader()
            '    If (rdr.Read()) Then
            '        con = New SqlConnection(cs)
            '        con.Open()
            '        Dim cb2 As String = "Update Temp_Stock_store set Qty=Qty + " & Val(row.Cells(2).Value) & " where Dish=@d1"
            '        cmd = New SqlCommand(cb2)
            '        cmd.Connection = con
            '        cmd.Parameters.AddWithValue("@d1", strText(0))
            '        cmd.ExecuteReader()
            '        con.Close()
            '    End If
            'Next
            'For Each row As DataGridViewRow In DataGridView5.Rows
            '    Dim str As String = row.Cells(0).Value.ToString()
            '    Dim strText() As String
            '    strText = Split(str, vbCrLf)
            '    con = New SqlConnection(cs)
            '    con.Open()
            '    Dim sql As String = "select Dish from Recipe where Dish=@d1"
            '    cmd = New SqlCommand(sql)
            '    cmd.Connection = con
            '    cmd.Parameters.AddWithValue("@d1", strText(0))
            '    rdr = cmd.ExecuteReader()
            '    If (rdr.Read()) Then
            '        con = New SqlConnection(cs)
            '        con.Open()
            '        cmd = New SqlCommand("select ProductID,Quantity from Recipe,Recipe_Join where Recipe.R_ID=Recipe_Join.RecipeID and Dish=@d1 order by ProductID", con)
            '        cmd.Parameters.AddWithValue("@d1", strText(0))
            '        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            '        dgw.Rows.Clear()
            '        While (rdr.Read() = True)
            '            dgw.Rows.Add(rdr(0), rdr(1))
            '        End While
            '        con.Close()
            '        For Each dr As DataGridViewRow In dgw.Rows
            '            con = New SqlConnection(cs)
            '            con.Open()
            '            Dim cb2 As String = "Update Temp_Stock_RM set Qty=Qty + " & Val(dr.Cells(1).Value) * Val(row.Cells(2).Value) & " where ProductID=@d1"
            '            cmd = New SqlCommand(cb2)
            '            cmd.Connection = con
            '            cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
            '            cmd.ExecuteReader()
            '            con.Close()
            '        Next
            '        RawMaterialUsedDel(lblBillNo3.Text)
            '    End If
            'Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub VoidBill3()
        Try
            'con = New SqlConnection(cs)
            'con.Open()
            'Dim cb1 As String = "Update RestaurantPOS_BillingInfoEB set EB_Status='Void' where BillNo=@d1"
            'cmd = New SqlCommand(cb1)
            'cmd.Parameters.AddWithValue("@d1", lblBillNo3.Text)
            'cmd.Connection = con
            'cmd.ExecuteReader()
            'con.Close()
            'Dim st As String = "void the bill having bill No.'" & lblBillNo3.Text & "'"
            'LogFunc(lblUserVAL.Text, st)
            'LedgerDelete(lblBillNo3.Text, "POS")
            'LedgerDelete(lblBillNo3.Text, "Sales Invoice")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSelectWaiter_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectWaiter.Click
        frmWaiterList.ShowDialog()
    End Sub

    Private Sub txtContactNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtContactNo.TextChanged
        Try
            If txtContactNo.Text.Length >= 6 Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT distinct RTRIM(Customername),RTRIM(Address) from RestaurantPOS_BillingInfoHD where ContactNo=@d1 Union Select distinct RTRIM(Customername),RTRIM(Address) from HDCustomer where ContactNo=@d1"
                cmd.Parameters.AddWithValue("@d1", txtContactNo.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    txtCustomerName.Text = rdr.GetValue(0).ToString()
                    txtAddress.Text = rdr.GetValue(1).ToString()
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer5_Tick(sender As System.Object, e As System.EventArgs) Handles Timer5.Tick

        Dim MatchPhonePattern As String = "\(?\d{3}\)?-? *\d{3}-? *-?\d{2,4}"
        Dim rx As Regex = New Regex(MatchPhonePattern, (RegexOptions.Compiled Or RegexOptions.IgnoreCase))
        Dim matches As MatchCollection = rx.Matches(txtInfo.Text)
        Dim noOfMatches As Integer = matches.Count
        ' Report on each match.
        For Each match As System.Text.RegularExpressions.Match In matches
            txtPhoneNo.Text = match.Value.ToString()
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT distinct RTRIM(Customername) from RestaurantPOS_BillingInfoHD where ContactNo=@d1 Union Select distinct RTRIM(Customername) from HDCustomer where ContactNo=@d1"
            cmd.Parameters.AddWithValue("@d1", txtPhoneNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                lblCustomer.Text = rdr.GetValue(0).ToString() & " " & "is calling..."
            Else
                lblCustomer.Text = "Unknown person is calling..."
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Next
    End Sub

    Private Sub com1_DataReceived(sender As Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles com1.DataReceived
        CheckForIllegalCrossThreadCalls = False
        txtInfo.Text += com1.ReadExisting()
    End Sub

    Private Sub btnOkay_Click(sender As System.Object, e As System.EventArgs) Handles btnOkay.Click
        TabControl1.SelectedTab = TabPage4
        txtContactNo.Text = txtPhoneNo.Text
        txtInfo.Text = ""
        lblCustomer.Text = ""
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        txtInfo.Text = ""
        lblCustomer.Text = ""
    End Sub
    Sub IsEnabledCallerID()
        Try
            txtTillID.Text = System.Net.Dns.GetHostName
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT RTRIM(CallerIDPort) from POSprinterSetting where TillID=@d1 and CallerID='Yes'"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                lblCustomer.Visible = True
                btnOkay.Visible = True
                btnReset.Visible = True
                lblDateTime.Visible = False
                Timer5.Start()
            Else
                lblCustomer.Visible = False
                btnOkay.Visible = False
                btnReset.Visible = False
                lblDateTime.Visible = True
                Timer5.Stop()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub
    Public Function ModifierRate() As Double
        Dim sum As Double = 0
        Try
            If DataGridView1.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView1.Rows
                    sum = sum + r.Cells(1).Value
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Private Sub btnModifier_Click(sender As System.Object, e As System.EventArgs) Handles btnModifier.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView1.SelectedRows
                    If r.Cells(15).Value.ToString() = "Pizza" Then
                        frmCustomDialog20.ShowDialog()
                        Exit Sub
                    End If
                Next
                For Each r As DataGridViewRow In Me.DataGridView1.SelectedRows
                    Dim strC As String = r.Cells(0).Value.ToString().Trim()
                    If strC.Contains("Add :") = True Then
                        frmCustomDialog21.ShowDialog()
                        Exit Sub
                    End If
                Next
                For Each r As DataGridViewRow In Me.DataGridView1.SelectedRows
                    Dim str As String = r.Cells(0).Value.ToString().Trim()
                    Dim strText() As String
                    strText = Split(str, vbCrLf)
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT * from Modifiers,Dish where Modifiers.Item=Dish.DishName and Item=@d1"
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    rdr = cmd.ExecuteReader()
                    If Not rdr.Read() Then
                        frmCustomDialog20.ShowDialog()
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                        Return
                    End If
                    con.Close()
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        If DataGridView1.Rows.Count > 0 Then
            frmModifiersList.lblSet.Text = "KOT"
            frmModifiersList.Reset()
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            'Dim str As String = dr.Cells(0).Value.ToString()
            'Dim strText() As String
            'strText = Split(str, vbCrLf)
            frmModifiersList.lblItemName.Text = dr.Cells(0).Value.ToString()
            frmModifiersList.lblItemRate.Text = dr.Cells(1).Value
            frmModifiersList.txtNotes.Text = dr.Cells(13).Value
            frmModifiersList.txtTempQD.Text = dr.Cells(14).Value
            frmModifiersList.txtCategory.Text = dr.Cells(15).Value
            frmModifiersList.FillModifiers()
            frmModifiersList.ShowDialog()
        End If
    End Sub

    Private Sub btnModifiers1_Click(sender As System.Object, e As System.EventArgs) Handles btnModifiers1.Click
        Try
            If DataGridView3.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView3.SelectedRows
                    If r.Cells(15).Value.ToString() = "Pizza" Then
                        frmCustomDialog20.ShowDialog()
                        Exit Sub
                    End If
                Next
                For Each r As DataGridViewRow In Me.DataGridView3.SelectedRows
                    Dim strC As String = r.Cells(0).Value.ToString().Trim()
                    If strC.Contains("Add :") = True Then
                        frmCustomDialog21.ShowDialog()
                        Exit Sub
                    End If
                Next
                For Each r As DataGridViewRow In Me.DataGridView3.SelectedRows
                    Dim str As String = r.Cells(0).Value.ToString().Trim()
                    Dim strText() As String
                    strText = Split(str, vbCrLf)
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT * from Modifiers,Dish where Modifiers.Item=Dish.DishName and Item=@d1"
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    rdr = cmd.ExecuteReader()
                    If Not rdr.Read() Then
                        frmCustomDialog20.ShowDialog()
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                        Return
                    End If
                    con.Close()
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        If DataGridView3.Rows.Count > 0 Then
            frmModifiersList.lblSet.Text = "TA"
            frmModifiersList.Reset()
            Dim dr As DataGridViewRow = DataGridView3.SelectedRows(0)
            'Dim str As String = dr.Cells(0).Value.ToString()
            'Dim strText() As String
            'strText = Split(str, vbCrLf)
            frmModifiersList.lblItemName.Text = dr.Cells(0).Value.ToString()
            frmModifiersList.lblItemRate.Text = dr.Cells(1).Value
            frmModifiersList.txtNotes.Text = dr.Cells(13).Value
            frmModifiersList.txtTempQD.Text = txtTADiscountPer.Text
            frmModifiersList.txtCategory.Text = dr.Cells(15).Value
            frmModifiersList.FillModifiers()
            frmModifiersList.ShowDialog()
        End If
    End Sub

    Private Sub btnModifiers2_Click(sender As System.Object, e As System.EventArgs) Handles btnModifiers2.Click
        Try
            If DataGridView4.Rows.Count > 0 Then
                For Each r As DataGridViewRow In Me.DataGridView4.SelectedRows
                    If r.Cells(15).Value.ToString() = "Pizza" Then
                        frmCustomDialog20.ShowDialog()
                        Exit Sub
                    End If
                Next
                For Each r As DataGridViewRow In Me.DataGridView4.SelectedRows
                    Dim strC As String = r.Cells(0).Value.ToString().Trim()
                    If strC.Contains("Add :") = True Then
                        frmCustomDialog21.ShowDialog()
                        Exit Sub
                    End If
                Next
                For Each r As DataGridViewRow In Me.DataGridView4.SelectedRows
                    Dim str As String = r.Cells(0).Value.ToString().Trim()
                    Dim strText() As String
                    strText = Split(str, vbCrLf)
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT * from Modifiers,Dish where Modifiers.Item=Dish.DishName and Item=@d1"
                    cmd.Parameters.AddWithValue("@d1", strText(0))
                    rdr = cmd.ExecuteReader()
                    If Not rdr.Read() Then
                        frmCustomDialog20.ShowDialog()
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                        Return
                    End If
                    con.Close()
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        If DataGridView4.Rows.Count > 0 Then
            frmModifiersList.lblSet.Text = "HD"
            frmModifiersList.Reset()
            Dim dr As DataGridViewRow = DataGridView4.SelectedRows(0)
            'Dim str As String = dr.Cells(0).Value.ToString()
            'Dim strText() As String
            'strText = Split(str, vbCrLf)
            frmModifiersList.lblItemName.Text = dr.Cells(0).Value.ToString()
            frmModifiersList.lblItemRate.Text = dr.Cells(1).Value
            frmModifiersList.txtNotes.Text = dr.Cells(13).Value
            frmModifiersList.txtTempQD.Text = txtHDDiscountPer.Text
            frmModifiersList.txtCategory.Text = dr.Cells(15).Value
            frmModifiersList.FillModifiers()
            frmModifiersList.ShowDialog()
        End If
    End Sub

    Private Sub btnModifiers3_Click(sender As System.Object, e As System.EventArgs)
        Try
            'If DataGridView5.Rows.Count > 0 Then
            '    For Each r As DataGridViewRow In Me.DataGridView5.SelectedRows
            '        If r.Cells(15).Value.ToString() = "Pizza" Then
            '            frmCustomDialog20.ShowDialog()
            '            Exit Sub
            '        End If
            '    Next
            '    For Each r As DataGridViewRow In Me.DataGridView5.SelectedRows
            '        Dim strC As String = r.Cells(0).Value.ToString().Trim()
            '        If strC.Contains("Add :") = True Then
            '            frmCustomDialog21.ShowDialog()
            '            Exit Sub
            '        End If
            '    Next
            '    For Each r As DataGridViewRow In Me.DataGridView5.SelectedRows
            '        Dim str As String = r.Cells(0).Value.ToString().Trim()
            '        Dim strText() As String
            '        strText = Split(str, vbCrLf)
            '        con = New SqlConnection(cs)
            '        con.Open()
            '        cmd = con.CreateCommand()
            '        cmd.CommandText = "SELECT * from Modifiers,Dish where Modifiers.Item=Dish.DishName and Item=@d1"
            '        cmd.Parameters.AddWithValue("@d1", strText(0))
            '        rdr = cmd.ExecuteReader()
            '        If Not rdr.Read() Then
            '            frmCustomDialog20.ShowDialog()
            '            If (rdr IsNot Nothing) Then
            '                rdr.Close()
            '            End If
            '            Return
            '        End If
            '        con.Close()
            '    Next
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        'If DataGridView5.Rows.Count > 0 Then
        '    frmModifiersList.lblSet.Text = "EB"
        '    frmModifiersList.Reset()
        '    Dim dr As DataGridViewRow = DataGridView5.SelectedRows(0)
        '    'Dim str As String = dr.Cells(0).Value.ToString()
        '    'Dim strText() As String
        '    'strText = Split(str, vbCrLf)
        '    frmModifiersList.lblItemName.Text = dr.Cells(0).Value.ToString()
        '    frmModifiersList.lblItemRate.Text = dr.Cells(1).Value
        '    frmModifiersList.txtNotes.Text = dr.Cells(13).Value
        '    frmModifiersList.txtTempQD.Text = txtEBDiscountPer.Text
        '    frmModifiersList.txtCategory.Text = dr.Cells(15).Value
        '    frmModifiersList.FillModifiers()
        '    frmModifiersList.ShowDialog()
        'End If
    End Sub

    Private Sub btnSettleTA_Click(sender As System.Object, e As System.EventArgs) Handles btnSettleTA.Click
        pnlTA.Visible = True
        pnlTA.Location = New Point(Me.ClientSize.Width / 2 - pnlTA.Size.Width / 2, Me.ClientSize.Height / 2 - pnlTA.Size.Height / 2)
        pnlTA.Anchor = AnchorStyles.None
    End Sub


    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        pnlTA.Visible = False
    End Sub

    Private Sub Button5_Click_1(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        pnlHD.Visible = False
    End Sub

    Private Sub btnSettleHD_Click(sender As System.Object, e As System.EventArgs) Handles btnSettleHD.Click
        pnlHD.Visible = True
        pnlHD.Location = New Point(Me.ClientSize.Width / 2 - pnlHD.Size.Width / 2, Me.ClientSize.Height / 2 - pnlHD.Size.Height / 2)
        pnlHD.Anchor = AnchorStyles.None
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs)
        'pnlEB.Visible = False
    End Sub

    Private Sub btnSettleEB_Click(sender As System.Object, e As System.EventArgs)
        'pnlEB.Visible = True
        'pnlEB.Location = New Point(Me.ClientSize.Width / 2 - pnlEB.Size.Width / 2, Me.ClientSize.Height / 2 - pnlEB.Size.Height / 2)
        'pnlEB.Anchor = AnchorStyles.None
    End Sub

    Private Sub txtItemsKOT_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtItemsKOT.TextChanged
        txtQty_Food.Text = txtItemsKOT.Text
    End Sub
    Private Sub btn1K_Click(sender As System.Object, e As System.EventArgs) Handles btn1K.Click
        If sign_Indicator = 0 Then
            txtItemsKOT.Text = txtItemsKOT.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            txtItemsKOT.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn2K_Click(sender As System.Object, e As System.EventArgs) Handles btn2K.Click
        If sign_Indicator = 0 Then
            txtItemsKOT.Text = txtItemsKOT.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            txtItemsKOT.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn3K_Click(sender As System.Object, e As System.EventArgs) Handles btn3K.Click
        If sign_Indicator = 0 Then
            txtItemsKOT.Text = txtItemsKOT.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            txtItemsKOT.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn4K_Click(sender As System.Object, e As System.EventArgs) Handles btn4K.Click
        If sign_Indicator = 0 Then
            txtItemsKOT.Text = txtItemsKOT.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            txtItemsKOT.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn5K_Click(sender As System.Object, e As System.EventArgs) Handles btn5K.Click
        If sign_Indicator = 0 Then
            txtItemsKOT.Text = txtItemsKOT.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            txtItemsKOT.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn6K_Click(sender As System.Object, e As System.EventArgs) Handles btn6K.Click
        If sign_Indicator = 0 Then
            txtItemsKOT.Text = txtItemsKOT.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            txtItemsKOT.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn7K_Click(sender As System.Object, e As System.EventArgs) Handles btn7K.Click
        If sign_Indicator = 0 Then
            txtItemsKOT.Text = txtItemsKOT.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            txtItemsKOT.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn8K_Click(sender As System.Object, e As System.EventArgs) Handles btn8K.Click
        If sign_Indicator = 0 Then
            txtItemsKOT.Text = txtItemsKOT.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            txtItemsKOT.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn9K_Click(sender As System.Object, e As System.EventArgs) Handles btn9K.Click
        If sign_Indicator = 0 Then
            txtItemsKOT.Text = txtItemsKOT.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            txtItemsKOT.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn0K_Click(sender As System.Object, e As System.EventArgs) Handles btn0K.Click
        If sign_Indicator = 0 Then
            txtItemsKOT.Text = txtItemsKOT.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            txtItemsKOT.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn1E_Click(sender As System.Object, e As System.EventArgs)
        'If sign_Indicator = 0 Then
        '    txtItemsEB.Text = txtItemsEB.Text + Convert.ToString(1)
        'ElseIf sign_Indicator = 1 Then
        '    txtItemsEB.Text = Convert.ToString(1)
        '    sign_Indicator = 0
        'End If
        'fl = True
    End Sub

    Private Sub btn2E_Click(sender As System.Object, e As System.EventArgs)
        'If sign_Indicator = 0 Then
        '    txtItemsEB.Text = txtItemsEB.Text + Convert.ToString(2)
        'ElseIf sign_Indicator = 1 Then
        '    txtItemsEB.Text = Convert.ToString(2)
        '    sign_Indicator = 0
        'End If
        'fl = True
    End Sub

    Private Sub btn3E_Click(sender As System.Object, e As System.EventArgs)
        'If sign_Indicator = 0 Then
        '    txtItemsEB.Text = txtItemsEB.Text + Convert.ToString(3)
        'ElseIf sign_Indicator = 1 Then
        '    txtItemsEB.Text = Convert.ToString(3)
        '    sign_Indicator = 0
        'End If
        'fl = True
    End Sub

    Private Sub btn4E_Click(sender As System.Object, e As System.EventArgs)
        'If sign_Indicator = 0 Then
        '    txtItemsEB.Text = txtItemsEB.Text + Convert.ToString(4)
        'ElseIf sign_Indicator = 1 Then
        '    txtItemsEB.Text = Convert.ToString(4)
        '    sign_Indicator = 0
        'End If
        'fl = True
    End Sub

    Private Sub btn5E_Click(sender As System.Object, e As System.EventArgs)
        'If sign_Indicator = 0 Then
        '    txtItemsEB.Text = txtItemsEB.Text + Convert.ToString(5)
        'ElseIf sign_Indicator = 1 Then
        '    txtItemsEB.Text = Convert.ToString(5)
        '    sign_Indicator = 0
        'End If
        'fl = True
    End Sub

    Private Sub btn6E_Click(sender As System.Object, e As System.EventArgs)
        'If sign_Indicator = 0 Then
        '    txtItemsEB.Text = txtItemsEB.Text + Convert.ToString(6)
        'ElseIf sign_Indicator = 1 Then
        '    txtItemsEB.Text = Convert.ToString(6)
        '    sign_Indicator = 0
        'End If
        'fl = True
    End Sub

    Private Sub btn7E_Click(sender As System.Object, e As System.EventArgs)
        'If sign_Indicator = 0 Then
        '    txtItemsEB.Text = txtItemsEB.Text + Convert.ToString(7)
        'ElseIf sign_Indicator = 1 Then
        '    txtItemsEB.Text = Convert.ToString(7)
        '    sign_Indicator = 0
        'End If
        'fl = True
    End Sub

    Private Sub btn8E_Click(sender As System.Object, e As System.EventArgs)
        'If sign_Indicator = 0 Then
        '    txtItemsEB.Text = txtItemsEB.Text + Convert.ToString(8)
        'ElseIf sign_Indicator = 1 Then
        '    txtItemsEB.Text = Convert.ToString(8)
        '    sign_Indicator = 0
        'End If
        'fl = True
    End Sub

    Private Sub btn9E_Click(sender As System.Object, e As System.EventArgs)
        'If sign_Indicator = 0 Then
        '    txtItemsEB.Text = txtItemsEB.Text + Convert.ToString(9)
        'ElseIf sign_Indicator = 1 Then
        '    txtItemsEB.Text = Convert.ToString(9)
        '    sign_Indicator = 0
        'End If
        'fl = True
    End Sub

    Private Sub btn0E_Click(sender As System.Object, e As System.EventArgs)
        'If sign_Indicator = 0 Then
        '    txtItemsEB.Text = txtItemsEB.Text + Convert.ToString(0)
        'ElseIf sign_Indicator = 1 Then
        '    txtItemsEB.Text = Convert.ToString(0)
        '    sign_Indicator = 0
        'End If
        'fl = True
    End Sub

    Private Sub btn1H_Click(sender As System.Object, e As System.EventArgs) Handles btn1H.Click
        If sign_Indicator = 0 Then
            txtItemsHD.Text = txtItemsHD.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            txtItemsHD.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn2H_Click(sender As System.Object, e As System.EventArgs) Handles btn2H.Click
        If sign_Indicator = 0 Then
            txtItemsHD.Text = txtItemsHD.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            txtItemsHD.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn3H_Click(sender As System.Object, e As System.EventArgs) Handles btn3H.Click
        If sign_Indicator = 0 Then
            txtItemsHD.Text = txtItemsHD.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            txtItemsHD.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn4H_Click(sender As System.Object, e As System.EventArgs) Handles btn4H.Click
        If sign_Indicator = 0 Then
            txtItemsHD.Text = txtItemsHD.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            txtItemsHD.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn5H_Click(sender As System.Object, e As System.EventArgs) Handles btn5H.Click
        If sign_Indicator = 0 Then
            txtItemsHD.Text = txtItemsHD.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            txtItemsHD.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn6H_Click(sender As System.Object, e As System.EventArgs) Handles btn6H.Click
        If sign_Indicator = 0 Then
            txtItemsHD.Text = txtItemsHD.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            txtItemsHD.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn7H_Click(sender As System.Object, e As System.EventArgs) Handles btn7H.Click
        If sign_Indicator = 0 Then
            txtItemsHD.Text = txtItemsHD.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            txtItemsHD.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn8H_Click(sender As System.Object, e As System.EventArgs) Handles btn8H.Click
        If sign_Indicator = 0 Then
            txtItemsHD.Text = txtItemsHD.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            txtItemsHD.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn9H_Click(sender As System.Object, e As System.EventArgs) Handles btn9H.Click
        If sign_Indicator = 0 Then
            txtItemsHD.Text = txtItemsHD.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            txtItemsHD.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn0H_Click(sender As System.Object, e As System.EventArgs) Handles btn0H.Click
        If sign_Indicator = 0 Then
            txtItemsHD.Text = txtItemsHD.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            txtItemsHD.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn1T_Click(sender As System.Object, e As System.EventArgs) Handles btn1T.Click
        If sign_Indicator = 0 Then
            txtItemsTA.Text = txtItemsTA.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            txtItemsTA.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn2T_Click(sender As System.Object, e As System.EventArgs) Handles btn2T.Click
        If sign_Indicator = 0 Then
            txtItemsTA.Text = txtItemsTA.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            txtItemsTA.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btn3T_Click(sender As System.Object, e As System.EventArgs) Handles btn3T.Click
        If sign_Indicator = 0 Then
            txtItemsTA.Text = txtItemsTA.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            txtItemsTA.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn4T_Click(sender As System.Object, e As System.EventArgs) Handles btn4T.Click
        If sign_Indicator = 0 Then
            txtItemsTA.Text = txtItemsTA.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            txtItemsTA.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn5T_Click(sender As System.Object, e As System.EventArgs) Handles btn5T.Click
        If sign_Indicator = 0 Then
            txtItemsTA.Text = txtItemsTA.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            txtItemsTA.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn6T_Click(sender As System.Object, e As System.EventArgs) Handles btn6T.Click
        If sign_Indicator = 0 Then
            txtItemsTA.Text = txtItemsTA.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            txtItemsTA.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn7T_Click(sender As System.Object, e As System.EventArgs) Handles btn7T.Click
        If sign_Indicator = 0 Then
            txtItemsTA.Text = txtItemsTA.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            txtItemsTA.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn8T_Click(sender As System.Object, e As System.EventArgs) Handles btn8T.Click
        If sign_Indicator = 0 Then
            txtItemsTA.Text = txtItemsTA.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            txtItemsTA.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btn9T_Click(sender As System.Object, e As System.EventArgs) Handles btn9T.Click
        If sign_Indicator = 0 Then
            txtItemsTA.Text = txtItemsTA.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            txtItemsTA.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub cmbSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSection.SelectedIndexChanged
        LoadDataORDER()
    End Sub

    Private Sub chkHappyHour_CheckedChanged(sender As Object, e As EventArgs) Handles chkHappyHour.CheckedChanged
        If chkHappyHour.Checked = True Then
            cmbSection.SelectedIndex = 0
        End If
    End Sub
    Private Sub AutoCheckSection()
        Try
            Dim _with1 = lvTable
            _with1.Clear()
            _with1.Columns.Add("Table No.", 140, HorizontalAlignment.Left)
            _with1.Columns.Add("Cust./Group Name", -2, HorizontalAlignment.Left)
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT distinct RTRIM(TableNo),RTRIM(GroupName) FROM RestaurantPOS_OrderInfoKOT where KOT_Status in ('Open','Served','Prepared') and ID in(SELECT [TicketID] FROM [RestaurantPOS_OrderedProductKOT] where Category in(select [CategoryName] from [Category] where [Kitchen] = '" & cmbBillSetion.Text.Trim() & "'))", con)
            'cmd = New SqlCommand("SELECT distinct RTRIM(R_Table.TableNo),RTRIM(GroupName) FROM R_Table,RestaurantPOS_OrderInfoKOT where (RestaurantPOS_OrderInfoKOT.TableNo=R_Table.TableNo OR R_Table.TableNo in (Select TableNo from RestaurantPOS_OrderInfoKOT)) and R_Table.Status='Activate' and KOT_Status in ('Open','Served','Prepared')", con)
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                Dim item = New ListViewItem()
                item.Text = rdr(0).ToString().Trim()
                item.SubItems.Add(rdr(1).ToString().Trim())
                lvTable.Items.Add(item)
            End While
            con.Close()
            ShowScrollBar(lvTable.Handle, SB_HORZ, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbBillSetion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBillSetion.SelectedIndexChanged
        AutoCheckSection()
    End Sub

    Private Sub cmbTSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTSection.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText2 As String = "SELECT Distinct RTRIM(CategoryName),Category.BackColor from Category,Dish where Category.Categoryname=Dish.Category and RTRIM(Kitchen) = RTRIM(@kitchen) order by 1"
            cmd = New SqlCommand(cmdText2)
            cmd.Parameters.Add("@kitchen", SqlDbType.NVarChar).Value = cmbTSection.Text.Trim()
            cmd.Connection = con
            rdr = cmd.ExecuteReader
            flpCategoriesTA.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.FlatStyle = FlatStyle.Popup
                Dim btnColor As Color = Color.FromArgb(Val(rdr.GetValue(1)))
                btn.BackColor = btnColor
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
                btn.Width = 130
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpCategoriesTA.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.ButtonTA_Click
            Loop
            con.Close()
            con.Dispose()
            cmd.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn0T_Click(sender As System.Object, e As System.EventArgs) Handles btn0T.Click
        If sign_Indicator = 0 Then
            txtItemsTA.Text = txtItemsTA.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            txtItemsTA.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub txtItemsTA_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtItemsTA.TextChanged
        txtQty_Food.Text = txtItemsTA.Text
    End Sub

    Private Sub txtItemsHD_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtItemsHD.TextChanged
        txtQty_Food.Text = txtItemsHD.Text
    End Sub

    Private Sub txtItemsEB_TextChanged(sender As System.Object, e As System.EventArgs)
        'txtQty_Food.Text = txtItemsEB.Text
    End Sub

    'Reports extension
    ''Private Function getDocument(ByVal document As String, ByRef reportType As Int16) As String

    ''    Dim files As String() = Directory.GetFiles(pth)
    ''    For Each filex As String In files
    ''        File.Delete(filex)
    ''    Next
    ''    Dim filename As String = ""
    ''    Dim bytes As Byte()
    ''    Dim warning As Warning()
    ''    Dim streamids As String()
    ''    Dim mimeType As String
    ''    Dim encoding As String
    ''    Dim filenameExtension As String
    ''    If reportType = 0 Then  'Kitchen
    ''        bytes = kitchenOrder.LocalReport.Render("PDF", Nothing, mimeType, encoding, filenameExtension, streamids, warning)
    ''    ElseIf reportType = 1 Then  'Paid order
    ''        bytes = paidOrder.LocalReport.Render("PDF", Nothing, mimeType, encoding, filenameExtension, streamids, warning)
    ''    ElseIf reportType = 2 Then 'Take Away
    ''        bytes = rpttakeAway.LocalReport.Render("PDF", Nothing, mimeType, encoding, filenameExtension, streamids, warning)
    ''    ElseIf reportType = 3 Then 'Home Delivery
    ''        bytes = homeDelivery.LocalReport.Render("PDF", Nothing, mimeType, encoding, filenameExtension, streamids, warning)
    ''    End If
    ''    If Directory.Exists(filepath) Then
    ''        filename = Path.Combine(filepath, document)
    ''        Using fs = New FileStream(filename, FileMode.Create)
    ''            fs.Write(bytes, 0, bytes.Length)
    ''            fs.Close()
    ''        End Using
    ''        File.Copy(filename, pth + "\" + Path.GetFileName(filename), True)
    ''        Return filename
    ''    Else
    ''        MessageBox.Show("Error found, no directory", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    ''    End If
    ''    Return filename
    ''End Function
    'Kitchen Order
    Public Sub GetKitchenOrderValue(ByVal dtCompany As DataTable, ByVal dtBill As DataTable, ByVal dtt As DataTable, ByVal items As Integer, ByVal qnty As Integer, ByVal cash As Decimal, ByVal change As Decimal, ByVal discount As Decimal, ByVal vat As Decimal, ByVal net As Decimal, ByVal gross As Decimal, Optional payment As String = "")
        Dim demo As New Demo()
        Dim report As New LocalReport()
        Dim retr As New Retrieving()
        Dim p(11) As ReportParameter
        p(0) = New ReportParameter("Cash", cash)
        p(1) = New ReportParameter("Items", items)
        p(2) = New ReportParameter("Qty", qnty)
        p(3) = New ReportParameter("Change", change)
        p(4) = New ReportParameter("Discount", discount)
        p(5) = New ReportParameter("VAT", vat)
        p(6) = New ReportParameter("Gross", gross)
        p(7) = New ReportParameter("Net", net)
        p(8) = New ReportParameter("Payment", payment)
        p(9) = New ReportParameter("dateTime", retrieve.dayTime())
        p(10) = New ReportParameter("Par", cmbSection.Text.ToUpper().Trim())
        p(11) = New ReportParameter("footer", retr.footer())
        With report
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.Kitchenorder.rdlc"
            .SetParameters(p)
            .DataSources.Add(New ReportDataSource("OrderSet", dtBill))
            .DataSources.Add(New ReportDataSource("DataSet", dtt))
            .DataSources.Add(New ReportDataSource("Company", dtCompany))
        End With
        'demo.Export(report)
        demo.Print(report)
    End Sub
    'Paid Order
    Public Sub GetPaidOrderValue(ByVal dtCompany As DataTable, ByVal dtBill As DataTable, ByVal dtt As DataTable, ByVal items As Integer, ByVal qnty As Integer, ByVal cash As Decimal, ByVal change As Decimal, ByVal discount As Decimal, ByVal vat As Decimal, ByVal net As Decimal, ByVal gross As Decimal, Optional payment As String = "")
        Dim demo As New Demo()
        Dim report As New LocalReport()
        Dim retr As New Retrieving()
        Dim p(10) As ReportParameter
        p(0) = New ReportParameter("Cash", cash)
        p(1) = New ReportParameter("Items", items)
        p(2) = New ReportParameter("Qty", qnty)
        p(3) = New ReportParameter("Change", change)
        p(4) = New ReportParameter("Discount", discount)
        p(5) = New ReportParameter("VAT", vat)
        p(6) = New ReportParameter("Gross", gross)
        p(7) = New ReportParameter("Net", net)
        p(8) = New ReportParameter("Payment", payment)
        p(9) = New ReportParameter("Par", cmbBillSetion.Text.ToUpper().Trim())
        p(10) = New ReportParameter("footer", retr.footer())
        With report
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.Paidorder.rdlc"
            .SetParameters(p)
            .DataSources.Add(New ReportDataSource("OrderSet", dtBill))
            .DataSources.Add(New ReportDataSource("DataSet", dtt))
            .DataSources.Add(New ReportDataSource("Company", dtCompany))
        End With
        'demo.Export(report)
        demo.Print(report)
        'paidOrder.RefreshReport()
        'Dim files As String() = Directory.GetFiles(filepath)
        'For Each filex As String In files
        '    File.Delete(filex)
        'Next
        'pdffileName = getDocument("paidOrder.pdf", 1)
    End Sub
    'Take Away
    Public Sub GetTakeAwayValue(ByVal dtCompany As DataTable, ByVal dtBill As DataTable, ByVal dtt As DataTable, ByVal items As Integer, ByVal qnty As Integer, ByVal cash As Decimal, ByVal change As Decimal, ByVal discount As Decimal, ByVal vat As Decimal, ByVal net As Decimal, ByVal gross As Decimal, Optional payment As String = "")
        Dim demo As New Demo()
        Dim report As New LocalReport()
        Dim retr As New Retrieving()
        Dim p(11) As ReportParameter
        p(0) = New ReportParameter("Cash", cash)
        p(1) = New ReportParameter("Items", items)
        p(2) = New ReportParameter("Qty", qnty)
        p(3) = New ReportParameter("Change", change)
        p(4) = New ReportParameter("Discount", discount)
        p(5) = New ReportParameter("VAT", vat)
        p(6) = New ReportParameter("Gross", gross)
        p(7) = New ReportParameter("Net", net)
        p(8) = New ReportParameter("Payment", payment)
        p(9) = New ReportParameter("dateTime", retrieve.dayTime())
        p(10) = New ReportParameter("Par", cmbSection.Text.ToUpper().Trim())
        p(11) = New ReportParameter("footer", retr.footer())
        With report
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.takeAway.rdlc"
            .SetParameters(p)
            .DataSources.Add(New ReportDataSource("OrderSet", dtBill))
            .DataSources.Add(New ReportDataSource("DataSet", dtt))
            .DataSources.Add(New ReportDataSource("Company", dtCompany))
        End With
        'demo.Export(report)
        demo.Print(report)
    End Sub
    'Home Delivery
    Public Sub GetHomeDeliveryValue(ByVal dtCompany As DataTable, ByVal dtBill As DataTable, ByVal dtt As DataTable, ByVal items As Integer, ByVal qnty As Integer, ByVal cash As Decimal, ByVal change As Decimal, ByVal discount As Decimal, ByVal vat As Decimal, ByVal net As Decimal, ByVal gross As Decimal, ByVal customer As String, ByVal contact As String, ByVal address As String, ByVal deliveryP As String, ByVal deliveryFee As Double, Optional payment As String = "")
        Dim demo As New Demo()
        Dim report As New LocalReport()
        Dim p(13) As ReportParameter
        p(0) = New ReportParameter("Cash", cash)
        p(1) = New ReportParameter("Items", items)
        p(2) = New ReportParameter("Qty", qnty)
        p(3) = New ReportParameter("Change", change)
        p(4) = New ReportParameter("Discount", discount)
        p(5) = New ReportParameter("VAT", vat)
        p(6) = New ReportParameter("Gross", gross)
        p(7) = New ReportParameter("Net", net)
        p(8) = New ReportParameter("Payment", payment)
        p(9) = New ReportParameter("customer", customer)
        p(10) = New ReportParameter("contact", contact)
        p(11) = New ReportParameter("address", address)
        p(12) = New ReportParameter("deliveryP", deliveryP)
        p(13) = New ReportParameter("deliveryFee", deliveryFee)
        With report
            .DataSources.Clear()
            .ReportEmbeddedResource = "RestaurantPOS6.HomeDelivery.rdlc"
            .SetParameters(p)
            .DataSources.Add(New ReportDataSource("OrderSet", dtBill))
            .DataSources.Add(New ReportDataSource("DataSet", dtt))
            .DataSources.Add(New ReportDataSource("Company", dtCompany))
        End With
        'demo.Export(report)
        demo.Print(report)
    End Sub
    Dim pdffileName As String
    Dim pathx As String
    'Now printing
    '/// <summary>
    '/// Prints a PDF using its RAW data directly to the printer. It requires the nuGET package RawPrint
    '/// </summary>
    Private Sub printPDF()

        Try
            pathx = Path.GetFileName(pdffileName)
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
            cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s3 = rdr.GetValue(0)
                Dim printName As String = s3
                'PrintingPDF(Path.Combine(pth, pathx))
            End If
            'localPrint.PdfPrint.SendToPrinter(Path.Combine(pth, pathx))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Finally
            'Dim files As String() = Directory.GetFiles(filepath)
            'For Each filex As String In files
            '    File.Delete(filex)
            'Next
        End Try
    End Sub
End Class

Public Class Demo
    Implements IDisposable
    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)
    Private pos As New frmPOS()

    ' Routine to provide to the report renderer, in order to
    ' save an image for each page of the report.
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function
    ' Export the given report as an EMF (Enhanced Metafile) file.
    Public Sub Export(ByVal report As LocalReport)
        Dim deviceInfo As String = "<DeviceInfo>" &
            "<OutputFormat>EMF</OutputFormat>" &
            "<PageWidth>3.2in</PageWidth>" &
            "<PageHeight>5.3in</PageHeight>" &
            "<MarginTop>0in</MarginTop>" &
            "<MarginLeft>0in</MarginLeft>" &
            "<MarginRight>0in</MarginRight>" &
            "<MarginBottom>0in</MarginBottom>" &
            "</DeviceInfo>"
        Dim warnings As Warning()
        m_streams = New List(Of Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        For Each stream As Stream In m_streams
            stream.Position = 0
        Next
    End Sub
    ' Handler for PrintPageEvents
    'Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
    '    Dim pageImage As New Metafile(m_streams(m_currentPageIndex))

    '    ' Adjust rectangular area with printer margins.
    '    Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX),
    '                                      ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY),
    '                                      ev.PageBounds.Width,
    '                                      ev.PageBounds.Height)

    '    ' Draw a white background for the report
    '    ev.Graphics.FillRectangle(Brushes.White, adjustedRect)

    '    ' Draw the report content
    '    ev.Graphics.DrawImage(pageImage, adjustedRect)

    '    ' Prepare for the next page. Make sure we haven't hit the end.
    '    m_currentPageIndex += 1
    '    ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    'End Sub
    'Public Sub Print()
    '    If m_streams Is Nothing OrElse m_streams.Count = 0 Then
    '        Throw New Exception("Error: no stream to print.")
    '    End If
    '    Dim printDoc As New PrintDocument()
    '    If Not printDoc.PrinterSettings.IsValid Then
    '        Throw New Exception("Error: cannot find the default printer.")
    '    Else
    '        AddHandler printDoc.PrintPage, AddressOf PrintPage
    '        m_currentPageIndex = 0
    '        printDoc.Print()
    '    End If
    'End Sub
    Sub Print(ByVal report As LocalReport)
        Dim pageSettings = New PageSettings()
        'pageSettings.PaperSize = report.GetDefaultPageSettings().PaperSize
        pageSettings.Landscape = report.GetDefaultPageSettings().IsLandscape
        pageSettings.Margins = report.GetDefaultPageSettings().Margins
        rdlReport.Print(report, pageSettings)
    End Sub
    ' Create a local report for Report.rdlc, load the data,
    ' export the report to an .emf file, and print it.
    'Private Sub Run()
    '    Dim report As New LocalReport()
    '    'report.ReportPath = "..\..\Report.rdlc"
    '    'report.DataSources.Add(New ReportDataSource("Sales", LoadSalesData()))
    '    Dim p(9) As ReportParameter
    '    p(0) = New ReportParameter("Cash", _cash)
    '    p(1) = New ReportParameter("Items", _items)
    '    p(2) = New ReportParameter("Qty", _qty)
    '    p(3) = New ReportParameter("Change", _change)
    '    p(4) = New ReportParameter("Discount", _discount)
    '    p(5) = New ReportParameter("VAT", _vat)
    '    p(6) = New ReportParameter("Gross", _gross)
    '    p(7) = New ReportParameter("Net", _net)
    '    p(8) = New ReportParameter("Payment", _payment)
    '    p(9) = New ReportParameter("dateTime", retrieve.dayTime())
    '    With report
    '        .DataSources.Clear()
    '        .ReportPath = "RestaurantPOS6.Kitchenorder.rdlc"
    '        .SetParameters(p)
    '        .DataSources.Add(New ReportDataSource("OrderSet", dtBill))
    '        .DataSources.Add(New ReportDataSource("DataSet", dtt))
    '        .DataSources.Add(New ReportDataSource("Company", dtCompany))
    '    End With
    '    Export(report)
    '    Print()
    'End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        If m_streams IsNot Nothing Then
            For Each stream As Stream In m_streams
                stream.Close()
            Next
            m_streams = Nothing
        End If
    End Sub
    Public Shared Sub Main()
        Using demo As New Demo()
            demo.pos.PrintFunc1()
        End Using
    End Sub
End Class