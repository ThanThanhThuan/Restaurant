
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO.Ports

Public Class frmTerminalSetting
    Dim st2, st1, st3, st4, st5 As String
    Sub Reset()
        cmbPrinter.Text = ""
        chkCashDrawer.Checked = False
        chkIsEnabled.Checked = True
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        chkCustomerDisplay.Checked = False
        txtDisplayPort.Text = "COM1"
        chkCallerID.Checked = False
        chkSMII.Checked = False
        txtCallerIDPort.Text = "COM2"
        txtMessage.Text = "Hello, This is test message"
        txtTillID.Text = System.Net.Dns.GetHostName
        txtTillID.Focus()
    End Sub
    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtTillID.Text)) = 0 Then
            MessageBox.Show("Please enter till id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTillID.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbPrinter.Text)) = 0 Then
            MessageBox.Show("Please select printer", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbPrinter.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select tillID from PosPrinterSetting where TillID=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Record already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            If chkCustomerDisplay.Checked = True Then
                st3 = "Yes"
            Else
                st3 = "No"
            End If
            If chkCallerID.Checked = True Then
                st4 = "Yes"
            Else
                st4 = "No"
            End If
            If chkIsEnabled.Checked = True Then
                st2 = "Yes"
            Else
                st2 = "No"
            End If
            If chkCashDrawer.Checked = True Then
                st1 = "Enabled"
            Else
                st1 = "Disabled"
            End If
            If chkSMII.Checked = True Then
                st5 = "Yes"
            Else
                st5 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into PosPrinterSetting(TillID,PrinterName,IsEnabled,CashDrawer,CustomerDisplay,CDPort,CallerID,CallerIDPort,SMII) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
            cmd.Parameters.AddWithValue("@d2", cmbPrinter.Text)
            cmd.Parameters.AddWithValue("@d3", st2)
            cmd.Parameters.AddWithValue("@d4", st1)
            cmd.Parameters.AddWithValue("@d5", st3)
            cmd.Parameters.AddWithValue("@d6", txtDisplayPort.Text)
            cmd.Parameters.AddWithValue("@d7", st4)
            cmd.Parameters.AddWithValue("@d8", txtCallerIDPort.Text)
            cmd.Parameters.AddWithValue("@d9", st5)
            cmd.ExecuteReader()
            con.Close()
            MessageBox.Show("Successfully saved", "Terminal Setting", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ID,RTRIM(TillID), RTRIM(PrinterName),RTRIM(IsEnabled),RTRIM(CashDrawer),RTRIM(SMII),RTRIM(CustomerDisplay),RTRIM(CDPort),RTRIM(CallerID),RTRIM(CallerIDPort) from PosPrinterSetting order by TillID", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PopulateInstalledPrintersCombo()
        Try
            ' Add list of installed printers found to the combo box.
            ' The pkInstalledPrinters string will be used to provide the display string.
            Dim i As Integer
            Dim pkInstalledPrinters As String
            cmbPrinter.Items.Clear()
            For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
                pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
                cmbPrinter.Items.Add(pkInstalledPrinters)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
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
    Private Sub DeleteRecord()

        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from PosPrinterSetting where ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Getdata()
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

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtID.Text = dr.Cells(0).Value.ToString()
                txtTillID.Text = dr.Cells(1).Value.ToString()
                cmbPrinter.Text = dr.Cells(2).Value.ToString()
                If dr.Cells(3).Value.ToString() = "Yes" Then
                    chkIsEnabled.Checked = True
                Else
                    chkIsEnabled.Checked = False
                End If
                If dr.Cells(4).Value = "Enabled" Then
                    chkCashDrawer.Checked = True
                Else
                    chkCashDrawer.Checked = False
                End If
                If dr.Cells(5).Value = "Yes" Then
                    chkSMII.Checked = True
                Else
                    chkSMII.Checked = False
                End If
                If dr.Cells(6).Value = "Yes" Then
                    chkCustomerDisplay.Checked = True
                Else
                    chkCustomerDisplay.Checked = False
                End If
                txtDisplayPort.Text = dr.Cells(7).Value.ToString()
                If dr.Cells(8).Value = "Yes" Then
                    chkCallerID.Checked = True
                Else
                    chkCallerID.Checked = False
                End If
                txtCallerIDPort.Text = dr.Cells(9).Value.ToString()
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtTillID.Text)) = 0 Then
            MessageBox.Show("Please enter till id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTillID.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbPrinter.Text)) = 0 Then
            MessageBox.Show("Please select printer", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbPrinter.Focus()
            Exit Sub
        End If
        Try
            If chkCustomerDisplay.Checked = True Then
                st3 = "Yes"
            Else
                st3 = "No"
            End If
            If chkCallerID.Checked = True Then
                st4 = "Yes"
            Else
                st4 = "No"
            End If
            If chkIsEnabled.Checked = True Then
                st2 = "Yes"
            Else
                st2 = "No"
            End If
            If chkCashDrawer.Checked = True Then
                st1 = "Enabled"
            Else
                st1 = "Disabled"
            End If
            If chkSMII.Checked = True Then
                st5 = "Yes"
            Else
                st5 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update PosPrinterSetting set TillID=@d1,PrinterName=@d2,IsEnabled=@d3,CashDrawer=@d4,CustomerDisplay=@d5,CDPort=@d6,CallerID=@d7,CallerIDPort=@d8,SMII=@d9 where ID=" & Val(txtID.Text) & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtTillID.Text)
            cmd.Parameters.AddWithValue("@d2", cmbPrinter.Text)
            cmd.Parameters.AddWithValue("@d3", st2)
            cmd.Parameters.AddWithValue("@d4", st1)
            cmd.Parameters.AddWithValue("@d5", st3)
            cmd.Parameters.AddWithValue("@d6", txtDisplayPort.Text)
            cmd.Parameters.AddWithValue("@d7", st4)
            cmd.Parameters.AddWithValue("@d8", txtCallerIDPort.Text)
            cmd.Parameters.AddWithValue("@d9", st5)
            cmd.ExecuteReader()
            con.Close()
            MessageBox.Show("Successfully updated", "Terminal Setting", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        Try
            Dim sp As New SerialPort(txtDisplayPort.Text, 9600, Parity.None, 8, StopBits.One)
            sp.Open()
            ' to clear the display
            sp.Write(CChar(ChrW(12)))
            ' first line goes here
            sp.WriteLine(txtMessage.Text)
            sp.Close()
            sp.Dispose()
            sp = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub frmTerminalSetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Getdata()
        PopulateInstalledPrintersCombo()
        txtTillID.Text = System.Net.Dns.GetHostName
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClearDisplay.Click
        Try
            Dim sp As New SerialPort(txtDisplayPort.Text, 9600, Parity.None, 8, StopBits.One)
            sp.Open()
            ' to clear the display
            sp.Write(CChar(ChrW(12)))
            sp.Close()
            sp.Dispose()
            sp = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class