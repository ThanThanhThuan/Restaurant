Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.SqlServer.Management.Smo
Public Class frmDatabase
    Dim Filename As String

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Sub Backup()
        Try

            Dim destdir As String = "RPOS_DB " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") & ".bak"
            Dim objdlg As New SaveFileDialog
            objdlg.FileName = destdir
            objdlg.ShowDialog()
            Filename = objdlg.FileName
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "backup database RPOS_DB to disk='" & Filename & "'with init,stats=10"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDBRestore_Click(sender As System.Object, e As System.EventArgs) Handles btnDBRestore.Click
        Try
            With OpenFileDialog1
                .Filter = ("DB Backup File|*.bak;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Timer2.Enabled = True
                SqlConnection.ClearAllPools()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "USE Master ALTER DATABASE RPOS_DB SET Single_User WITH Rollback Immediate Restore database RPOS_DB FROM disk='" & OpenFileDialog1.FileName & "' WITH REPLACE ALTER DATABASE RPOS_DB SET Multi_User "
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "Sucessfully performed the restore"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub

    Private Sub btnDBBackup_Click(sender As System.Object, e As System.EventArgs) Handles btnDBBackup.Click
        Backup()
    End Sub
End Class