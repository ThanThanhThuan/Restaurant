
Public Class frmHomeDelivery
    Dim Filename As String

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDeliveryPerson_Click(sender As System.Object, e As System.EventArgs) Handles btnDeliveryPerson.Click
        frmEmployeeRegistration.lblUser.Text = lblUser.Text
        frmEmployeeRegistration.Reset()
        frmEmployeeRegistration.ShowDialog()
    End Sub

    Private Sub btnCustomerEntry_Click(sender As System.Object, e As System.EventArgs) Handles btnCustomerEntry.Click
        frmCustomer.lblUser.Text = lblUser.Text
        frmCustomer.Reset()
        frmCustomer.ShowDialog()
    End Sub
End Class