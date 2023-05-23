Public Class frmCards_POS


    Private Sub btnCreditCard_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditCard.Click
        If lblSet.Text = "Dine In Billing" Then
            Me.Hide()
            frmPOS.Show()
            frmPOS.lblPaymentMode.Text = btnCreditCard.Text
            frmPOS.txtCash.Text = frmPOS.txtGrandTotal.Text
            frmPOS.txtChange.Text = "0.00"
        End If
        If lblSet.Text = "Take Away" Then
            Me.Hide()
            frmPOS.Show()
            frmPOS.lblPaymentMode1.Text = btnCreditCard.Text
            frmPOS.txtCash1.Text = frmPOS.txtGrandTotal1.Text
            frmPOS.txtChange1.Text = "0.00"
        End If
        If lblSet.Text = "Home Delivery" Then
            Me.Hide()
            frmPOS.Show()
            frmPOS.lblPaymentMode2.Text = btnCreditCard.Text
        End If
        If lblSet.Text = "Express Billing" Then
            Me.Hide()
            frmPOS.Show()
            'frmPOS.lblPaymentMode3.Text = btnCreditCard.Text
            'frmPOS.txtCash3.Text = frmPOS.txtGrandTotal3.Text
            'frmPOS.txtChange3.Text = "0.00"
        End If
        lblSet.Text = ""
    End Sub

    Private Sub btnDebitCard_Click(sender As System.Object, e As System.EventArgs) Handles btnDebitCard.Click
        If lblSet.Text = "Dine In Billing" Then
            Me.Hide()
            frmPOS.Show()
            frmPOS.lblPaymentMode.Text = btnDebitCard.Text
            frmPOS.txtCash.Text = frmPOS.txtGrandTotal.Text
            frmPOS.txtChange.Text = "0.00"
        End If
        If lblSet.Text = "Take Away" Then
            Me.Hide()
            frmPOS.Show()
            frmPOS.lblPaymentMode1.Text = btnDebitCard.Text
            frmPOS.txtCash1.Text = frmPOS.txtGrandTotal1.Text
            frmPOS.txtChange1.Text = "0.00"
        End If
        If lblSet.Text = "Home Delivery" Then
            Me.Hide()
            frmPOS.Show()
            frmPOS.lblPaymentMode2.Text = btnDebitCard.Text
        End If
        If lblSet.Text = "Express Billing" Then
            Me.Hide()
            frmPOS.Show()
            'frmPOS.lblPaymentMode3.Text = btnDebitCard.Text
            'frmPOS.txtCash3.Text = frmPOS.txtGrandTotal3.Text
            'frmPOS.txtChange3.Text = "0.00"
        End If
        lblSet.Text = ""
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class