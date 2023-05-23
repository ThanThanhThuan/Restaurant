Imports System.Data.SqlClient
Public Class frmNotes1
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(Notes) from NotesMaster order by Notes"
            cmd = New SqlCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpNotes.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.TextAlign = ContentAlignment.MiddleCenter
                Dim btnColor As Color = Color.DimGray
                btn.BackColor = btnColor
                btn.ForeColor = Color.White
                btn.FlatStyle = FlatStyle.Popup
                btn.Width = 150
                btn.Height = 60
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpNotes.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.Button2_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnOkay.Click
        If lblSet.Text = "KOT" Then
            Me.Hide()
            frmPOS.Show()
            frmPOS.txtNotes.Text = txtNotes.Text
        End If
        If lblSet.Text = "TA" Then
            Me.Hide()
            frmPOS.Show()
            frmPOS.txtNotes.Text = txtNotes.Text
        End If
        If lblSet.Text = "HD" Then
            Me.Hide()
            frmPOS.Show()
            frmPOS.txtNotes.Text = txtNotes.Text
        End If
        If lblSet.Text = "EB" Then
            Me.Hide()
            frmPOS.Show()
            frmPOS.txtNotes.Text = txtNotes.Text
        End If
    End Sub
    Sub Reset()
        txtNotes.Text = ""
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
    Private Sub btnKeyboard_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.Click
        OSKeyboard()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
                Dim btn1 As Button = CType(sender, Button)
                Dim str As String = btn1.Text.Trim()
            txtNotes.Text += str & vbCrLf
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
  
    Private Sub frmNotes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Getdata()
        flpNotes.AutoScroll = False
        flpNotes.HorizontalScroll.Maximum = 0
        flpNotes.HorizontalScroll.Visible = False
        flpNotes.VerticalScroll.Maximum = 0
        flpNotes.VerticalScroll.Visible = False
        flpNotes.AutoScroll = True
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtNotes.Text = ""
    End Sub
End Class