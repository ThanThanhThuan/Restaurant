Imports System
Imports System.IO
Imports System.Net
Imports System.Data.SqlClient

Public Class frmSendBroadcastSMS
    Dim st1, st2, st3 As String
    Sub Reset()
        listView1.Items.Clear()
        txtMessage.Text = ""
        GetData()
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub
    Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select distinct RTRIM(Customername),RTRIM(Address),RTRIM(ContactNo) from RestaurantPOS_BillingInfoHD Union Select distinct RTRIM(Customername),RTRIM(Address),RTRIM(ContactNo) from HDCustomer  order by 1", con)
            rdr = cmd.ExecuteReader()
            listView1.Items.Clear()
            While rdr.Read()
                Dim item = New ListViewItem()
                item.Text = rdr(0).ToString().Trim()
                item.SubItems.Add(rdr(1).ToString().Trim())
                item.SubItems.Add(rdr(2).ToString().Trim())
                listView1.Items.Add(item)
            End While
            For i = 0 To listView1.Items.Count - 1
                listView1.Items(i).Checked = True
            Next
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmSendSMS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub btnSendSMS_Click(sender As System.Object, e As System.EventArgs) Handles btnSendSMS.Click
        Try
            If Len(Trim(txtMessage.Text)) = 0 Then
                MessageBox.Show("Please enter message", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtMessage.Focus()
                Exit Sub
            End If
            If listView1.Items.Count = 0 Then
                MessageBox.Show("Please retrieve customers list", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If listView1.CheckedItems.Count = 0 Then
                MessageBox.Show("Please select at least one customer", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If CheckForInternetConnection() = True Then
                Cursor = Cursors.WaitCursor
                Timer2.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                cmd = New SqlCommand(ctn)
                cmd.Connection = con
                Dim rdr1 As SqlDataReader = cmd.ExecuteReader()
                If rdr1.Read() Then
                    st2 = rdr1.GetValue(0)
                    st1 = ""
                    For i = 0 To listView1.Items.Count - 1
                        If listView1.Items(i).Checked = True Then
                            st1 += listView1.Items(i).SubItems(2).Text & "" & ","
                        End If
                    Next
                    st1 = st1.Trim().Remove(st1.Length - 1)
                    SMSFunc(st1, txtMessage.Text, st2)
                End If
            End If
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub
End Class