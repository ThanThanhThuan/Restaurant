Public Class frmStockAdjustment
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnStockTransfer_W2S_Click(sender As System.Object, e As System.EventArgs) Handles btnStockTransfer_W2S.Click
        frmStockAdjustment_Store.lblUser.Text = lblUser.Text
        frmStockAdjustment_Store.Reset()
        frmStockAdjustment_Store.ShowDialog()
    End Sub

    Private Sub btnStockTransfer_W2W_Click(sender As System.Object, e As System.EventArgs) Handles btnStockTransfer_W2W.Click
        frmStockAdjustment_Warehouse.lblUser.Text = lblUser.Text
        frmStockAdjustment_Warehouse.Reset()
        frmStockAdjustment_Warehouse.ShowDialog()
    End Sub
End Class