Imports System.Data.SqlClient
Imports System.IO.Ports

Public Class frmOption
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
    Sub ClearCustomerDisplay()
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
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnFrontOffice.Click
        frmFrontOffice.lblUserType.Text = lblUserType.Text
        frmFrontOffice.lblUser.Text = lblUser.Text
        frmFrontOffice.btnOpenCashDrawer.Enabled = True
        frmFrontOffice.btnPOS.Enabled = True
        frmFrontOffice.btnOpenTickets.Enabled = True
        frmFrontOffice.btnWorkPeriod.Enabled = True
        frmFrontOffice.btnReport.Enabled = True
        Me.Hide()
        frmFrontOffice.Show()
    End Sub

    Private Sub btnBackOffice_Click(sender As System.Object, e As System.EventArgs) Handles btnBackOffice.Click
        If lblUserType.Text = "Super Admin" Then
            frmBackOffice.lblUser.Text = lblUser.Text
            frmBackOffice.btnRegistration.Enabled = True
            frmBackOffice.btnLogs.Enabled = True
            Me.Hide()
            frmBackOffice.Show()
        End If
        If lblUserType.Text = "Admin" Then
            frmBackOffice.lblUser.Text = lblUser.Text
            frmBackOffice.btnRegistration.Enabled = False
            frmBackOffice.btnLogs.Enabled = False
            Me.Hide()
            frmBackOffice.Show()
        End If
    End Sub
    Private Function HandleRegistry() As Boolean
        Dim firstRunDate As Date
        Dim st As Date = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\C177", "Set", Nothing)
        firstRunDate = st
        If firstRunDate = Nothing Then
            firstRunDate = System.DateTime.Today.Date
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\C177", "Set", firstRunDate)
        ElseIf (Now - firstRunDate).Days > 5 Then
            Return False
        End If
        If (firstRunDate - System.DateTime.Now).Days > 5 Then
            Return False
        End If
        Return True
    End Function
    Private Sub frmOption_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BackColor = Color.Coral
        TransparencyKey = BackColor

        'Dim result As Boolean = HandleRegistry()
        'If result = False Then 'something went wrong
        '    MessageBox.Show("Trial expired" & vbCrLf & "for purchasing the full version of software Contact us at :" & vbCrLf & "Vaibhav Patidar" & vbCrLf & "Mobile No. +919630014949", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End
        'End If
       
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        ClearCustomerDisplay()
        End
    End Sub
End Class