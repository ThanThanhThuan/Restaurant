Imports System.Data.SqlClient
Imports System.IO
Imports Ext
Imports Microsoft.SqlServer.Management.Smo
Public Class frmFrontOffice
    Dim Filename As String
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Dim s4 As String
    Private Sub btnCategories_Click(sender As System.Object, e As System.EventArgs)
        frmMenuItemsCategory.lblUser.Text = lblUser.Text
        frmMenuItemsCategory.Reset()
        frmMenuItemsCategory.ShowDialog()
    End Sub
    Private Sub btnMinimize_Click(sender As System.Object, e As System.EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnMaximise_Click(sender As System.Object, e As System.EventArgs) Handles btnMaximise.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            btnMaximise.Image = My.Resources.Entypo_e715_1__64
            Me.StartPosition = FormStartPosition.CenterScreen
        Else
            Me.WindowState = FormWindowState.Maximized
            btnMaximise.Image = My.Resources.Entypo_e713_0__64
        End If
    End Sub

    Private Sub btnKeyboard_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.Click
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

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub btnPOS_Click(sender As System.Object, e As System.EventArgs) Handles btnPOS.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct2 As String = "SELECT * from Hotel"
            cmd = New SqlCommand(ct2)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                frmCustomDialog18.ShowDialog()
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "SELECT * from Dish"
            cmd = New SqlCommand(ct1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                frmCustomDialog12.ShowDialog()
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT * from WorkPeriodStart where Status='Active'"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                frmCustomDialog3.ShowDialog()
                Exit Sub
            End If
            con.Close()
            If lblUserType.Text = "Admin" Or lblUserType.Text = "Super Admin" Or lblUserType.Text = "Cashier" Then
                Me.Hide()
                Dim tp As TabPage
                For Each tp In frmPOS.TabControl1.TabPages
                    tp.Enabled = True
                Next
                frmPOS.GetSMIISetting()
                frmPOS.LoadData()
                frmPOS.lblUserType.Text = lblUserType.Text
                frmPOS.lblUserVAL.Text = lblUser.Text
                frmPOS.GetTaxType()
                frmPOS.IsEnabledCallerID()
                frmPOS.lblCustNameVAL.Visible = False
                frmPOS.lblCustName.Visible = False
                frmPOS.Show()
            Else
                Me.Hide()
                frmPOS.TabControl1.TabPages(0).Enabled = True
                frmPOS.TabControl1.TabPages(1).Enabled = False
                frmPOS.TabControl1.TabPages(2).Enabled = False
                frmPOS.TabControl1.TabPages(3).Enabled = False
                'frmPOS.TabControl1.TabPages(4).Enabled = False
                frmPOS.GetSMIISetting()
                frmPOS.LoadData()
                frmPOS.lblUserType.Text = lblUserType.Text
                frmPOS.lblUserVAL.Text = lblUser.Text
                frmPOS.GetTaxType()
                frmPOS.IsEnabledCallerID()
                frmPOS.lblCustNameVAL.Visible = False
                frmPOS.lblCustName.Visible = False
                frmPOS.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub btnLogout_Click(sender As System.Object, e As System.EventArgs) Handles btnLogout.Click
        frmCustomDialog8.lblUser.Text = lblUser.Text
        frmCustomDialog8.ShowDialog()
    End Sub

    Private Sub btnTickets_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenTickets.Click
        Me.Hide()
        frmOpenTickets.Reset()
        frmOpenTickets.lblUserType.Text = lblUserType.Text
        frmOpenTickets.lblUser.Text = lblUser.Text
        frmOpenTickets.Show()
    End Sub

    Private Sub btnWorkPeriod_Click(sender As System.Object, e As System.EventArgs) Handles btnWorkPeriod.Click
        Me.Hide()
        frmWorkPeriod.lblUserType.Text = lblUserType.Text
        frmWorkPeriod.lblUser.Text = lblUser.Text
        frmWorkPeriod.Show()
    End Sub

    Private Sub btnOpenCashDrawer_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenCashDrawer.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(CashDrawer) from POSPrinterSetting where TillID=@d1 and CashDrawer='Enabled'"
            cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                frmCustomDialog11.ShowDialog()
                Exit Sub
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            'Modify DrawerCode to your receipt printer open drawer code
            Dim DrawerCode As String = Chr(27) & Chr(112) & Chr(48) & Chr(64) & Chr(64)
            'Modify PrinterName to your receipt printer name
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
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

    Private Sub btnReport_Click(sender As System.Object, e As System.EventArgs) Handles btnReport.Click
        frmFrontOffice_Report.ShowDialog()
    End Sub

    Private Sub btnKithcenDisplay_Click(sender As System.Object, e As System.EventArgs) Handles btnKithcenDisplay.Click
        frmKDS.ShowDialog()
    End Sub

    Private Sub frmFrontOffice_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtTillID.Text = System.Net.Dns.GetHostName
        Try
            Dim dtAccess As New DataTable()
            Dim access As New GetInfos()
            dtAccess = access.GetAccessList()
            Dim a As Integer
            While (a < dtAccess.Rows.Count)
                If (btnWorkPeriod.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnWorkPeriod.Visible = False
                End If
                If (btnPOS.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnPOS.Visible = False
                End If
                If (btnOpenTickets.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnOpenTickets.Visible = False
                End If
                If (btnKithcenDisplay.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnKithcenDisplay.Visible = False
                End If
                If (btnReport.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnReport.Visible = False
                End If
                a = a + 1
            End While
        Catch
        End Try
    End Sub

End Class