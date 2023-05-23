Imports System.IO.Ports
Imports System.IO
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class frmCallerID
    Dim WithEvents com1 As New SerialPort
    Dim st As String

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim x As Integer
        Dim y As Integer
        x = Screen.PrimaryScreen.WorkingArea.Width
        y = Screen.PrimaryScreen.WorkingArea.Height - Me.Height

        Do Until x = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
            x = x - 1
            Me.Location = New Point(x, y)
        Loop
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
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub com1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles com1.DataReceived
        CheckForIllegalCrossThreadCalls = False
        txtInfo.Text += com1.ReadLine()
    End Sub
   
    Private Sub btnOkay_Click(sender As System.Object, e As System.EventArgs) Handles btnOkay.Click
        Me.Hide()
        frmPOS.Show()
        frmPOS.TabControl1.SelectedTab = frmPOS.TabPage4
        frmPOS.lblCustName.Visible = False
        frmPOS.lblCustNameVAL.Visible = False
        If frmPOS.lblUserVAL.Text = "lblUser" Then
            frmPOS.lblUserVAL.Text = "sa"
        End If
        frmPOS.Reset3()
        frmPOS.txtContactNo.Text = txtPhoneNo.Text
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim MatchPhonePattern As String = "\(?\d{3}\)?-? *\d{3}-? *-?\d{2,4}"
        Dim rx As Regex = New Regex(MatchPhonePattern, (RegexOptions.Compiled Or RegexOptions.IgnoreCase))
        Dim matches As MatchCollection = rx.Matches(txtInfo.Text)
        Dim noOfMatches As Integer = matches.Count
        ' Report on each match.
        For Each match As Match In matches
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

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        txtInfo.Text = ""
        lblCustomer.Text = ""
    End Sub
End Class
