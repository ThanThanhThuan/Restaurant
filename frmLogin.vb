Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Ports

Public Class frmLogin
    Dim frm As New frmOption
    Dim sign_Indicator As Integer = 0
    Dim variable1 As Double
    Dim variable2 As Double
    Dim fl As Boolean = False
    Dim s, x As String
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            GetData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function HandleRegistry() As Boolean
        Dim firstRunDate As Date
        Dim st As Date = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\C177", "Set", Nothing)
        firstRunDate = st
        If firstRunDate = Nothing Then
            firstRunDate = System.DateTime.Today.Date
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\C177", "Set", firstRunDate)
        ElseIf (Now - firstRunDate).Days > 367 Then
            Return False
        End If
        If (firstRunDate - System.DateTime.Now).Days > 367 Then
            Return False
        End If
        Return True
    End Function
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ClearCustomerDisplay()
        End
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
    Private Sub CreateDirectory()
        Try
            Const CREATE_DIR As String = "C:\Users\Public\Documents\Restaurant POS\"
            Dim dr As DirectoryInfo = New DirectoryInfo(CREATE_DIR)

            If Not dr.Exists Then
                dr.Create()
            End If

        Catch __unusedException1__ As Exception
            MessageBox.Show("Missing file, contact your administration for help!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub LoginForm1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Panel1.Location = New Point(Me.ClientSize.Width / 2 - Panel1.Size.Width / 2, Me.ClientSize.Height / 2 - Panel1.Size.Height / 2)
        Panel1.Anchor = AnchorStyles.None
        Panel2.Width = Me.Width
        CreateDirectory()
    End Sub

    Private Sub frmLogin_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub btnTA0_Click(sender As System.Object, e As System.EventArgs) Handles btnTA0.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnX_Click(sender As System.Object, e As System.EventArgs) Handles btnX.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        s = Password.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        Password.Text = x
        x = ""
    End Sub
    Private Sub btnTA9_Click(sender As System.Object, e As System.EventArgs) Handles btnTA9.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA8_Click(sender As System.Object, e As System.EventArgs) Handles btnTA8.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA7_Click(sender As System.Object, e As System.EventArgs) Handles btnTA7.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA6_Click(sender As System.Object, e As System.EventArgs) Handles btnTA6.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA5_Click(sender As System.Object, e As System.EventArgs) Handles btnTA5.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA4_Click(sender As System.Object, e As System.EventArgs) Handles btnTA4.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA3_Click(sender As System.Object, e As System.EventArgs) Handles btnTA3.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA2_Click(sender As System.Object, e As System.EventArgs) Handles btnTA2.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA1_Click(sender As System.Object, e As System.EventArgs) Handles btnTA1.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA1_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnTA1.MouseHover
        btnTA1.BackColor = Color.DimGray
        btnTA1.ForeColor = Color.White
    End Sub

    Private Sub btnTA1_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnTA1.MouseLeave
        btnTA1.BackColor = Color.White
        btnTA1.ForeColor = Color.Black
    End Sub

    Private Sub btnTA0_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA0.MouseHover
        btnTA0.BackColor = Color.DimGray
        btnTA0.ForeColor = Color.White
    End Sub

    Private Sub btnTA0_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA0.MouseLeave
        btnTA0.BackColor = Color.White
        btnTA0.ForeColor = Color.Black
    End Sub

    Private Sub btnTA2_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA2.MouseHover
        btnTA2.BackColor = Color.DimGray
        btnTA2.ForeColor = Color.White
    End Sub

    Private Sub btnTA2_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA2.MouseLeave
        btnTA2.BackColor = Color.White
        btnTA2.ForeColor = Color.Black
    End Sub

    Private Sub btnTA3_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA3.MouseHover
        btnTA3.BackColor = Color.DimGray
        btnTA3.ForeColor = Color.White
    End Sub

    Private Sub btnTA3_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA3.MouseLeave
        btnTA3.BackColor = Color.White
        btnTA3.ForeColor = Color.Black
    End Sub

    Private Sub btnTA4_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA4.MouseHover
        btnTA4.BackColor = Color.DimGray
        btnTA4.ForeColor = Color.White
    End Sub

    Private Sub btnTA4_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA4.MouseLeave
        btnTA4.BackColor = Color.White
        btnTA4.ForeColor = Color.Black
    End Sub

    Private Sub btnTA5_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA5.MouseHover
        btnTA5.BackColor = Color.DimGray
        btnTA5.ForeColor = Color.White
    End Sub

    Private Sub btnTA5_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA5.MouseLeave
        btnTA5.BackColor = Color.White
        btnTA5.ForeColor = Color.Black
    End Sub

    Private Sub btnTA6_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA6.MouseHover
        btnTA6.BackColor = Color.DimGray
        btnTA6.ForeColor = Color.White
    End Sub

    Private Sub btnTA6_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA6.MouseLeave
        btnTA6.BackColor = Color.White
        btnTA6.ForeColor = Color.Black
    End Sub

    Private Sub btnTA7_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA7.MouseHover
        btnTA7.BackColor = Color.DimGray
        btnTA7.ForeColor = Color.White
    End Sub

    Private Sub btnTA7_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA7.MouseLeave
        btnTA7.BackColor = Color.White
        btnTA7.ForeColor = Color.Black
    End Sub

    Private Sub btnTA8_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA8.MouseHover
        btnTA8.BackColor = Color.DimGray
        btnTA8.ForeColor = Color.White
    End Sub

    Private Sub btnTA8_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA8.MouseLeave
        btnTA8.BackColor = Color.White
        btnTA8.ForeColor = Color.Black
    End Sub

    Private Sub btnTA9_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA9.MouseHover
        btnTA9.BackColor = Color.DimGray
        btnTA9.ForeColor = Color.White
    End Sub

    Private Sub btnTA9_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA9.MouseLeave
        btnTA9.BackColor = Color.White
        btnTA9.ForeColor = Color.Black
    End Sub

    Private Sub btnX_MouseHover(sender As Object, e As System.EventArgs) Handles btnX.MouseHover
        btnX.BackColor = Color.DimGray
        btnX.ForeColor = Color.White
    End Sub

    Private Sub btnX_MouseLeave(sender As Object, e As System.EventArgs) Handles btnX.MouseLeave
        btnX.BackColor = Color.White
        btnX.ForeColor = Color.Black
    End Sub



    Private Sub OK_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnLogin.MouseHover
        btnLogin.BackColor = Color.Yellow

    End Sub

    Private Sub OK_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = Color.Transparent
    End Sub

    Private Sub Cancel_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnCancel.MouseHover
        btnCancel.BackColor = Color.Red
    End Sub

    Private Sub Cancel_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnCancel.MouseLeave
        btnCancel.BackColor = Color.Transparent
    End Sub


    Private Sub btnForgetPassword_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnForgetPassword.MouseHover
        btnForgetPassword.BackColor = Color.Blue
    End Sub

    Private Sub btnForgetPassword_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnForgetPassword.MouseLeave
        btnForgetPassword.BackColor = Color.Transparent
    End Sub

    Private Sub btnForgetPassword_Click(sender As System.Object, e As System.EventArgs) Handles btnForgetPassword.Click
        Me.Hide()
        frmRecoveryPIN.txtEmailID.Text = ""
        frmRecoveryPIN.Show()
    End Sub

    Private Sub Password_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Password.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Password_TextChanged(sender As System.Object, e As System.EventArgs) Handles Password.TextChanged

        Try
            If Password.TextLength = 4 Then
                GetData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Sub GetData()
        Try
            'Dim result As Boolean = HandleRegistry()
            'If result = False Then 'something went wrong
            '    MessageBox.Show("Trial expired" & vbCrLf & "for purchasing the full version of software Contact us at :" & vbCrLf & "Vaibhav Patidar" & vbCrLf & "Mobile No. +919630014949", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End
            'End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(UserID),RTRIM(Password) FROM Registration where Password=@d1 and Active='Yes' and UserType in('Admin','Cashier','Super Admin','Kitchen User','Waiter','Waitress','Manager')"
            cmd.Parameters.AddWithValue("@d1", Encrypt(Password.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                UserID.Text = rdr.GetValue(0)
                If Encrypt(Password.Text).Trim = rdr.GetValue(1).trim Then
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT usertype FROM Registration where UserID=@d3 and Password=@d4"
                    cmd.Parameters.AddWithValue("@d3", UserID.Text)
                    cmd.Parameters.AddWithValue("@d4", Encrypt(Password.Text))
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        UserType.Text = rdr.GetValue(0).ToString.Trim
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    If UserType.Text = "Cashier" Then
                        frmFrontOffice.lblUser.Text = UserID.Text
                        Dim st As String = "Successfully logged in"
                        LogFunc(UserID.Text, st)
                        Me.Hide()
                        frmFrontOffice.btnOpenCashDrawer.Enabled = False
                        frmFrontOffice.btnPOS.Enabled = True
                        frmFrontOffice.btnOpenTickets.Enabled = True
                        frmFrontOffice.btnKithcenDisplay.Enabled = True
                        frmFrontOffice.btnWorkPeriod.Enabled = True
                        frmFrontOffice.btnReport.Enabled = True
                        frmFrontOffice.lblUserType.Text = UserType.Text
                        frmFrontOffice.lblUser.Text = UserID.Text
                        frmFrontOffice.Show()
                    End If
                    If UserType.Text = "Kitchen User" Then
                        frmFrontOffice.lblUser.Text = UserID.Text
                        Dim st As String = "Successfully logged in"
                        LogFunc(UserID.Text, st)
                        Me.Hide()
                        frmFrontOffice.btnOpenCashDrawer.Enabled = False
                        frmFrontOffice.btnPOS.Enabled = False
                        frmFrontOffice.btnOpenTickets.Enabled = False
                        frmFrontOffice.btnWorkPeriod.Enabled = False
                        frmFrontOffice.btnKithcenDisplay.Enabled = True
                        frmFrontOffice.btnReport.Enabled = False
                        frmFrontOffice.lblUserType.Text = UserType.Text
                        frmFrontOffice.lblUser.Text = UserID.Text
                        frmFrontOffice.Show()
                    End If
                    If UserType.Text = "Waiter" Then
                        frmFrontOffice.lblUser.Text = UserID.Text
                        Dim st As String = "Successfully logged in"
                        LogFunc(UserID.Text, st)
                        Me.Hide()
                        frmFrontOffice.btnOpenCashDrawer.Enabled = False
                        frmFrontOffice.btnPOS.Enabled = True
                        frmFrontOffice.btnOpenTickets.Enabled = False
                        frmFrontOffice.btnWorkPeriod.Enabled = False
                        frmFrontOffice.btnKithcenDisplay.Enabled = False
                        frmFrontOffice.btnReport.Enabled = False
                        frmFrontOffice.lblUserType.Text = UserType.Text
                        frmFrontOffice.lblUser.Text = UserID.Text
                        frmFrontOffice.Show()
                    End If
                    If (UserType.Text = "Super Admin") Then
                        frm.lblUser.Text = UserID.Text
                        frm.lblUserType.Text = UserType.Text
                        frm.btnBackOffice.Enabled = True
                        frmFrontOffice.btnPOS.Enabled = True
                        frmFrontOffice.btnOpenTickets.Enabled = True
                        frmFrontOffice.btnKithcenDisplay.Enabled = True
                        frmFrontOffice.btnWorkPeriod.Enabled = True
                        frmFrontOffice.btnReport.Enabled = True
                        Dim st As String = "Successfully logged in"
                        LogFunc(UserID.Text, st)
                        Me.Hide()
                        frm.lblUser.Text = UserID.Text
                        frm.Show()
                    End If
                    If (UserType.Text = "Admin") Then
                        frm.lblUser.Text = UserID.Text
                        frm.lblUserType.Text = UserType.Text
                        frm.btnBackOffice.Enabled = True
                        frmFrontOffice.btnPOS.Enabled = True
                        frmFrontOffice.btnOpenTickets.Enabled = True
                        frmFrontOffice.btnKithcenDisplay.Enabled = True
                        frmFrontOffice.btnWorkPeriod.Enabled = True
                        frmFrontOffice.btnReport.Enabled = True
                        Dim st As String = "Successfully logged in"
                        LogFunc(UserID.Text, st)
                        Me.Hide()
                        frm.lblUser.Text = UserID.Text
                        frm.Show()

                    End If
                End If
            Else
                Password.PasswordChar = ""
                Password.Text = "ENTER PIN"
            End If
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            End 'zz
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frmAboutUs.ShowDialog()
    End Sub

End Class
