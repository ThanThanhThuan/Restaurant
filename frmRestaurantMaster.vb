Imports System.Data.SqlClient
Imports System.IO

Public Class frmRestaurantMaster
    Dim s1 As String
    Sub Reset()
        txtSTNo.Text = ""
        txtVATNo.Text = ""
        txtEmailID.Text = ""
        txtContactNo.Text = ""
        txtHotelName.Text = ""
        txtCIN.Text = ""
        txtAddressLine1.Text = ""
        PictureBox1.Image = My.Resources.icon_restaurant
        txtBaseCurrency.Text = ""
        txtCurrencyCode.Text = ""
        txtAddressLine2.Text = ""
        txtAddressLine3.Text = ""
        txtTicketFooterMessage.Text = ""
        txtHotelName.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        chkShowLogo.Checked = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtHotelName.Text = "" Then
            MessageBox.Show("Please enter restaurant name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHotelName.Focus()
            Return
        End If
        If txtAddressLine1.Text = "" Then
            MessageBox.Show("Please enter address line 1", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddressLine1.Focus()
            Return
        End If
        If txtAddressLine2.Text = "" Then
            MessageBox.Show("Please enter address line 2", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddressLine2.Focus()
            Return
        End If
        If txtContactNo.Text = "" Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Return
        End If

        If txtEmailID.Text = "" Then
            MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmailID.Focus()
            Return
        End If
        If txtBaseCurrency.Text = "" Then
            MessageBox.Show("Please enter base currency", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBaseCurrency.Focus()
            Return
        End If
        If txtCurrencyCode.Text = "" Then
            MessageBox.Show("Please enter currency code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCurrencyCode.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select count(*) from Hotel Having count(*) >= 1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Record Already Exists" & vbCrLf & "please update the restautant info", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            If chkShowLogo.Checked = True Then
                s1 = "Yes"
            Else
                s1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Hotel( HotelName, AddressLine1, ContactNo, EmailID, TIN, STNo, CIN, Logo,BaseCurrency,CurrencyCode,AddressLine2,AddressLine3,TicketFooterMessage,ShowLogo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtHotelName.Text)
            cmd.Parameters.AddWithValue("@d2", txtAddressLine1.Text)
            cmd.Parameters.AddWithValue("@d3", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d4", txtEmailID.Text)
            cmd.Parameters.AddWithValue("@d5", txtVATNo.Text)
            cmd.Parameters.AddWithValue("@d6", txtSTNo.Text)
            cmd.Parameters.AddWithValue("@d7", txtCIN.Text)
            cmd.Parameters.AddWithValue("@d9", txtBaseCurrency.Text)
            cmd.Parameters.AddWithValue("@d10", txtCurrencyCode.Text)
            cmd.Parameters.AddWithValue("@d11", txtAddressLine2.Text)
            cmd.Parameters.AddWithValue("@d12", txtAddressLine3.Text)
            cmd.Parameters.AddWithValue("@d13", txtTicketFooterMessage.Text)
            cmd.Parameters.AddWithValue("@d14", s1)
            Dim ms As New MemoryStream()
            Dim bmpImage As New Bitmap(PictureBox1.Image)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@d8", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "added the restaurant '" & txtHotelName.Text & "' info"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Restaurant Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtHotelName.Text = "" Then
            MessageBox.Show("Please enter restaurant name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHotelName.Focus()
            Return
        End If
        If txtAddressLine1.Text = "" Then
            MessageBox.Show("Please enter address line 1", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddressLine1.Focus()
            Return
        End If
        If txtAddressLine2.Text = "" Then
            MessageBox.Show("Please enter address line 2", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddressLine2.Focus()
            Return
        End If
        If txtContactNo.Text = "" Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Return
        End If

        If txtEmailID.Text = "" Then
            MessageBox.Show("Please enter email id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmailID.Focus()
            Return
        End If
        If txtBaseCurrency.Text = "" Then
            MessageBox.Show("Please enter base currency", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBaseCurrency.Focus()
            Return
        End If
        If txtCurrencyCode.Text = "" Then
            MessageBox.Show("Please enter currency code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCurrencyCode.Focus()
            Return
        End If
        Try
            If chkShowLogo.Checked = True Then
                s1 = "Yes"
            Else
                s1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb3 As String = "update RestaurantPOS_BillingInfoEB set CurrencyCode=@d1 where CurrencyCode=@d2"
            cmd = New SqlCommand(cb3)
            cmd.Parameters.AddWithValue("@d1", txtCurrencyCode.Text)
            cmd.Parameters.AddWithValue("@d2", txtcCode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "update RestaurantPOS_BillingInfoKOT set CurrencyCode=@d1 where CurrencyCode=@d2"
            cmd = New SqlCommand(cb1)
            cmd.Parameters.AddWithValue("@d1", txtCurrencyCode.Text)
            cmd.Parameters.AddWithValue("@d2", txtcCode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "update RestaurantPOS_BillingInfoTA set CurrencyCode=@d1 where CurrencyCode=@d2"
            cmd = New SqlCommand(cb2)
            cmd.Parameters.AddWithValue("@d1", txtCurrencyCode.Text)
            cmd.Parameters.AddWithValue("@d2", txtcCode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update Hotel set HotelName=@d1, AddressLine1=@d2, ContactNo=@d3, EmailID=@d4, TIN=@d5, STNo=@d6, CIN=@d7, Logo=@d8,BaseCurrency=@d9,CurrencyCode=@d10,AddressLine2=@d11,AddressLine3=@d12,TicketFooterMessage=@d13,ShowLogo=@d14 where ID=" & txtID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtHotelName.Text)
            cmd.Parameters.AddWithValue("@d2", txtAddressLine1.Text)
            cmd.Parameters.AddWithValue("@d3", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d4", txtEmailID.Text)
            cmd.Parameters.AddWithValue("@d5", txtVATNo.Text)
            cmd.Parameters.AddWithValue("@d6", txtSTNo.Text)
            cmd.Parameters.AddWithValue("@d7", txtCIN.Text)
            cmd.Parameters.AddWithValue("@d9", txtBaseCurrency.Text)
            cmd.Parameters.AddWithValue("@d10", txtCurrencyCode.Text)
            cmd.Parameters.AddWithValue("@d11", txtAddressLine2.Text)
            cmd.Parameters.AddWithValue("@d12", txtAddressLine3.Text)
            cmd.Parameters.AddWithValue("@d13", txtTicketFooterMessage.Text)
            cmd.Parameters.AddWithValue("@d14", s1)
            Dim ms As New MemoryStream()
            Dim bmpImage As New Bitmap(PictureBox1.Image)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@d8", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "updated the restaurant '" & txtHotelName.Text & "' info"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Restaurant Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID), RTRIM(HotelName), RTRIM(AddressLine1),RTRIM(AddressLine2),RTRIM(AddressLine3), RTRIM(ContactNo), RTRIM(EmailID), RTRIM(TIN), RTRIM(STNo), RTRIM(CIN),RTRIM(BaseCurrency),RTRIM(CurrencyCode),RTRIM(TicketFooterMessage),Logo,RTRIM(ShowLogo) from Hotel", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
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

    Private Sub frmRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtID.Text = dr.Cells(0).Value.ToString()
                txtHotelName.Text = dr.Cells(1).Value.ToString()
                txtAddressLine1.Text = dr.Cells(2).Value.ToString()
                txtAddressLine2.Text = dr.Cells(3).Value.ToString()
                txtAddressLine3.Text = dr.Cells(4).Value.ToString()
                txtContactNo.Text = dr.Cells(5).Value.ToString()
                txtEmailID.Text = dr.Cells(6).Value.ToString()
                txtVATNo.Text = dr.Cells(7).Value.ToString()
                txtSTNo.Text = dr.Cells(8).Value.ToString()
                txtCIN.Text = dr.Cells(9).Value.ToString()
                Dim data As Byte() = DirectCast(dr.Cells(13).Value, Byte())
                Dim ms As New MemoryStream(data)
                Me.PictureBox1.Image = Image.FromStream(ms)
                txtBaseCurrency.Text = dr.Cells(10).Value.ToString()
                txtCurrencyCode.Text = dr.Cells(11).Value.ToString()
                txtcCode.Text = dr.Cells(11).Value.ToString()
                txtTicketFooterMessage.Text = dr.Cells(12).Value.ToString()
                If dr.Cells(14).Value.ToString() = "Yes" Then
                    chkShowLogo.Checked = True
                Else
                    chkShowLogo.Checked = False
                End If
                btnUpdate.Enabled = True
                btnSave.Enabled = False
                btnDelete.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;*.ico;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
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
            Dim cq As String = "delete from Hotel where ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the restaurant '" & txtHotelName.Text & "' info"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

End Class
