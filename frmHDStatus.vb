Imports System.Data.SqlClient
Public Class frmHDStatus

    Private Sub btnBackOffice_Click(sender As System.Object, e As System.EventArgs) Handles btnDelivered.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update RestaurantPOS_BillingInfoHD Set HD_Status='Delivered' where ID=" & Val(txtHdID.Text) & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            MessageBox.Show("Successfully Changed", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            frmPOS.Reset3()
            frmPOS.Reset3()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelled_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelled.Click
        Try
            If MessageBox.Show("Do you really want to cancel the bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("Does the stock affected?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    frmPOS.VoidBill2()
                    Me.Close()
                Else
                    frmPOS.RollBackStock2()
                    frmPOS.VoidBill2()
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
       
    End Sub
End Class