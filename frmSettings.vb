Public Class frmSettings

    Private Sub btnPrinterSetting_Click(sender As System.Object, e As System.EventArgs) Handles btnTerminalSetting.Click
        frmTerminalSetting.Reset()
        frmTerminalSetting.ShowDialog()
    End Sub

    Private Sub btnOtherCharges_Click(sender As System.Object, e As System.EventArgs) Handles btnOtherCharges.Click
        frmOthersSetting.Reset()
        frmOthersSetting.lblUser.Text = lblUser.Text
        frmOthersSetting.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnEmailSetting_Click(sender As System.Object, e As System.EventArgs) Handles btnEmailSetting.Click
        frmEmailSetting.Reset()
        frmEmailSetting.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmSMSSetting.Reset()
        frmSMSSetting.ShowDialog()
    End Sub

    Private Sub btnExpenseType_Click(sender As System.Object, e As System.EventArgs) Handles btnExpenseType.Click
        frmExpenseType.Reset()
        frmExpenseType.lblUser.Text = lblUser.Text
        frmExpenseType.ShowDialog()
    End Sub

    Private Sub btnExpenses_Click(sender As System.Object, e As System.EventArgs) Handles btnExpenses.Click
        frmExpense.Reset()
        frmExpense.lblUser.Text = lblUser.Text
        frmExpense.ShowDialog()
    End Sub

    Private Sub frmSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnUnit_Click(sender As System.Object, e As System.EventArgs) Handles btnUnit.Click
        frmUnit.Reset()
        frmUnit.lblUser.Text = lblUser.Text
        frmUnit.ShowDialog()
    End Sub

    Private Sub btnCategoryMaster_Click(sender As System.Object, e As System.EventArgs) Handles btnCategoryMaster.Click
        frmRawMaterialsCategory.Reset()
        frmRawMaterialsCategory.lblUser.Text = lblUser.Text
        frmRawMaterialsCategory.ShowDialog()
    End Sub
End Class