Public Class frmCreditCustomer


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAddMember_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditCustomer.Click
        frmCreditCustomerRegistration.Reset()
        frmCreditCustomerRegistration.lblUser.Text = lblUser.Text
        frmCreditCustomerRegistration.ShowDialog()
    End Sub

    Private Sub btnAddFunds_Click(sender As System.Object, e As System.EventArgs) Handles btnReceipt.Click
        frmCreditCustomerReceipt.Reset()
        frmCreditCustomerReceipt.lblUser.Text = lblUser.Text
        frmCreditCustomerReceipt.ShowDialog()
    End Sub
    Private Sub btnMemberLedger_Click(sender As System.Object, e As System.EventArgs) Handles btnCustomerLedger.Click
        frmCreditCustomerLedger.Reset()
        frmCreditCustomerLedger.ShowDialog()
    End Sub
End Class