Public Class frmPizza

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPizzaSize_Click(sender As System.Object, e As System.EventArgs) Handles btnPizzaSize.Click
        frmPizzaSize.Reset()
        frmPizzaSize.lblUser.Text = lblUser.Text
        frmPizzaSize.ShowDialog()
    End Sub

    Private Sub btnPizzaToppings_Click(sender As System.Object, e As System.EventArgs) Handles btnPizzaToppings.Click
        frmPizzaToppings.Reset()
        frmPizzaToppings.lblUser.Text = lblUser.Text
        frmPizzaToppings.ShowDialog()
    End Sub

    Private Sub btnPizzaMaster_Click(sender As System.Object, e As System.EventArgs) Handles btnPizzaMaster.Click
        frmPizzaMaster.Reset()
        frmPizzaMaster.lblUser.Text = lblUser.Text
        frmPizzaMaster.ShowDialog()
    End Sub
End Class