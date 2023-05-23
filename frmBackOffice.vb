Imports System.Data.SqlClient
Imports System.IO
Imports Ext
Imports Microsoft.SqlServer.Management.Smo
Public Class frmBackOffice
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private Sub btnCategories_Click(sender As System.Object, e As System.EventArgs) Handles btnCategories.Click
        frmMenuItemsCategory.lblUser.Text = lblUser.Text
        frmMenuItemsCategory.Reset()
        frmMenuItemsCategory.ShowDialog()
    End Sub
    Private Sub btnItems_Click(sender As System.Object, e As System.EventArgs) Handles btnItems.Click
        frmMenuItem.lblUser.Text = lblUser.Text
        frmMenuItem.Reset()
        frmMenuItem.ShowDialog()
    End Sub

    Private Sub btnTables_Click(sender As System.Object, e As System.EventArgs) Handles btnTables.Click
        frmTable.lblUser.Text = lblUser.Text
        frmTable.Reset()
        frmTable.ShowDialog()
    End Sub

    Private Sub btnRegistration_Click(sender As System.Object, e As System.EventArgs) Handles btnRegistration.Click
        frmRegistration.lblUser.Text = lblUser.Text
        frmRegistration.Reset()
        frmRegistration.ShowDialog()
    End Sub

    Private Sub btnLogs_Click(sender As System.Object, e As System.EventArgs) Handles btnLogs.Click
        frmLogs.Reset()
        frmLogs.lblUser.Text = lblUser.Text
        frmLogs.ShowDialog()
    End Sub

    Private Sub btnRestaurantInfo_Click(sender As System.Object, e As System.EventArgs) Handles btnRestaurantInfo.Click
        frmRestaurantMaster.lblUser.Text = lblUser.Text
        frmRestaurantMaster.Reset()
        frmRestaurantMaster.ShowDialog()
    End Sub
    Private Sub btnPOSReport_Click(sender As System.Object, e As System.EventArgs) Handles btnPOSReport.Click
        frmRPOSReport.Reset()
        frmRPOSReport.ShowDialog()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub
    Private Sub Cancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        frmCustomDialog17.lblUser.Text = lblUser.Text
        frmCustomDialog17.ShowDialog()
    End Sub

    Private Sub btnMinimize_Click(sender As System.Object, e As System.EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnProduct_Click(sender As System.Object, e As System.EventArgs) Handles btnProduct.Click
        frmProduct.lblUser.Text = lblUser.Text
        frmProduct.Reset()
        frmProduct.ShowDialog()
    End Sub

    Private Sub btnSupplier_Click(sender As System.Object, e As System.EventArgs) Handles btnSupplier.Click
        frmSupplier.lblUser.Text = lblUser.Text
        frmSupplier.Reset()
        frmSupplier.ShowDialog()
    End Sub

    Private Sub btnPurchase_Click(sender As System.Object, e As System.EventArgs) Handles btnPurchase.Click
        frmPurchaseEntry.lblUser.Text = lblUser.Text
        frmPurchaseEntry.Reset()
        frmPurchaseEntry.ShowDialog()
    End Sub

    Private Sub btnPayment_Click(sender As System.Object, e As System.EventArgs) Handles btnPayment.Click
        frmPayment.lblUser.Text = lblUser.Text
        frmPayment.Reset()
        frmPayment.ShowDialog()
    End Sub

    Private Sub BtnVoucher_Click(sender As System.Object, e As System.EventArgs) Handles BtnVoucher.Click
        frmVoucher.lblUser.Text = lblUser.Text
        frmVoucher.Reset()
        frmVoucher.ShowDialog()
    End Sub

    Private Sub btnAccountingReports_Click(sender As System.Object, e As System.EventArgs) Handles btnAccountingReports.Click
        frmAccountingReport.Reset()
        frmAccountingReport.lblUser.Text = lblUser.Text
        frmAccountingReport.ShowDialog()
    End Sub

    Private Sub btnKitchen_Click(sender As System.Object, e As System.EventArgs) Handles btnKitchen.Click
        frmKitchen_Section.lblUser.Text = lblUser.Text
        frmKitchen_Section.Reset()
        frmKitchen_Section.ShowDialog()
    End Sub

    Private Sub btnDeliveryPerson_Click(sender As System.Object, e As System.EventArgs) Handles btnHomeDelivery.Click
        frmHomeDelivery.lblUser.Text = lblUser.Text
        frmHomeDelivery.ShowDialog()
    End Sub

    Private Sub btnOtherCharges_Click(sender As System.Object, e As System.EventArgs) Handles btnSettings.Click
        frmSettings.lblUser.Text = lblUser.Text
        frmSettings.ShowDialog()
    End Sub

    Private Sub btnInventory_Click(sender As System.Object, e As System.EventArgs) Handles btnInventory.Click
        Dim f As New frmInventory
        f.Reset()
        f.ShowDialog()
        'frmWarehouseType.lblUser.Text = lblUser.Text
        'frmWarehouseType.Reset()
        'frmWarehouseType.ShowDialog()
    End Sub

    Private Sub btnWarehouse_Click(sender As System.Object, e As System.EventArgs) Handles btnWarehouse.Click
        frmWarehouse.lblUser.Text = lblUser.Text
        frmWarehouse.Reset()
        frmWarehouse.ShowDialog()
    End Sub

    Private Sub btnStockTransfer_Issue_Click(sender As System.Object, e As System.EventArgs) Handles btnStockTransfer_Issue.Click
        Dim frmStockTransfer1 As New frmStockTransfer
        frmStockTransfer1.lblUser.Text = lblUser.Text
        frmStockTransfer1.Reset()
        frmStockTransfer1.ShowDialog()
    End Sub

    Private Sub btnKeyboard_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.Click
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

    Private Sub btnRecipe_Click(sender As System.Object, e As System.EventArgs) Handles btnRecipe.Click
        frmRecipe.lblUser.Text = lblUser.Text
        frmRecipe.Reset()
        frmRecipe.ShowDialog()
    End Sub
    Private Sub btnWorkPeriod_Click(sender As System.Object, e As System.EventArgs) Handles btnWorkPeriod.Click
        frmWorkPeriod_Del.lblUser.Text = lblUser.Text
        frmWorkPeriod_Del.ShowDialog()
    End Sub

    Private Sub btnItemStock_Click(sender As System.Object, e As System.EventArgs) Handles btnItemStockx.Click
        'frmStock_Store.lblUser.Text = lblUser.Text
        'frmStock_Store.Reset()
        'frmStock_Store.ShowDialog()
        'zz
        Dim frmStockTransfer1 As New frmStockTransfer
        frmStockTransfer1.lblUser.Text = lblUser.Text
        frmStockTransfer1.Reset()
        frmStockTransfer1.IsGoods = True
        frmStockTransfer1.ShowDialog()
    End Sub

    Private Sub btnAbout_Click(sender As System.Object, e As System.EventArgs)
        frmAboutUs.ShowDialog()
    End Sub

    Private Sub btnWorkPeriodReport_Click(sender As System.Object, e As System.EventArgs) Handles btnWorkPeriodReport.Click
        frmWorkPeriodReport.Reset()
        frmWorkPeriodReport.ShowDialog()
    End Sub

    Private Sub btnDatabase_Click(sender As System.Object, e As System.EventArgs) Handles btnDatabase.Click
        frmDatabase.lblUser.Text = lblUser.Text
        frmDatabase.ShowDialog()
    End Sub

    Private Sub btnWallet_Click(sender As System.Object, e As System.EventArgs) Handles btnWallet.Click
        frmWalletType.lblUser.Text = lblUser.Text
        frmWalletType.Reset()
        frmWalletType.ShowDialog()
    End Sub

    Private Sub btnSendSMS_Click(sender As System.Object, e As System.EventArgs) Handles btnSendSMS.Click
        frmSendBroadcastSMS.Reset()
        frmSendBroadcastSMS.ShowDialog()
    End Sub


    Private Sub btnPizza_Click(sender As System.Object, e As System.EventArgs) Handles btnPizza.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct2 As String = "SELECT * from Category where CategoryName='Pizza'"
            cmd = New SqlCommand(ct2)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                frmCustomDialog19.ShowDialog()
                Exit Sub
            End If
            con.Close()
            frmPizza.lblUser.Text = lblUser.Text
            frmPizza.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnCreditCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditCustomer.Click
        frmCreditCustomer.lblUser.Text = lblUser.Text
        frmCreditCustomer.ShowDialog()
    End Sub

    Private Sub btnNotes_Click(sender As System.Object, e As System.EventArgs) Handles btnNotes.Click
        frmNotesMaster.Reset()
        frmNotesMaster.lblUser.Text = lblUser.Text
        frmNotesMaster.ShowDialog()
    End Sub

    Private Sub btnPurchaseOrder_Click(sender As System.Object, e As System.EventArgs) Handles btnPurchaseOrder.Click
        frmPurchaseOrder.lblUser.Text = lblUser.Text
        frmPurchaseOrder.Reset()
        frmPurchaseOrder.ShowDialog()
    End Sub

    Private Sub btnMenuItemsModifiers_Click(sender As System.Object, e As System.EventArgs) Handles btnMenuItemsModifiers.Click
        frmMenuItemsModifiers.lblUser.Text = lblUser.Text
        frmMenuItemsModifiers.Reset()
        frmMenuItemsModifiers.ShowDialog()
    End Sub

    Private Sub btnStockAdjustment_Click(sender As System.Object, e As System.EventArgs) Handles btnStockAdjustment.Click
        frmStockAdjustment.lblUser.Text = lblUser.Text
        frmStockAdjustment.ShowDialog()
    End Sub

    Private Sub frmBackOffice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dtAccess As New DataTable()
            Dim access As New GetInfos()
            dtAccess = access.GetAccessList()
            Dim a As Integer
            While (a < dtAccess.Rows.Count)
                If (btnRestaurantInfo.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnRestaurantInfo.Visible = False
                End If
                If (btnKitchen.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnKitchen.Visible = False
                End If
                If (btnCategories.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnCategories.Visible = False
                End If
                If (btnItems.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnItems.Visible = False
                End If
                If (btnMenuItemsModifiers.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnMenuItemsModifiers.Visible = False
                End If
                If (btnPizza.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnPizza.Visible = False
                End If
                If (btnNotes.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnNotes.Visible = False
                End If
                If (btnTables.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnTables.Visible = False
                End If
                If (btnWallet.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnWallet.Visible = False
                End If
                If (btnCreditCustomer.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnCreditCustomer.Visible = False
                End If
                If (btnInventory.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnInventory.Visible = False
                End If
                If (btnWarehouse.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnWarehouse.Visible = False
                End If
                If (btnSupplier.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnSupplier.Visible = False
                End If
                If (btnProduct.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnProduct.Visible = False
                End If
                If (btnPurchaseOrder.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnPurchaseOrder.Visible = False
                End If
                If (btnPurchase.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnPurchase.Visible = False
                End If
                If (btnPayment.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnPayment.Visible = False
                End If
                If (btnStockTransfer_Issue.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnStockTransfer_Issue.Visible = False
                End If
                If (btnStockAdjustment.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnStockAdjustment.Visible = False
                End If
                If (BtnVoucher.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    BtnVoucher.Visible = False
                End If
                If (btnHomeDelivery.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnHomeDelivery.Visible = False
                End If
                If (btnRecipe.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnRecipe.Visible = False
                End If
                If (btnWorkPeriod.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnWorkPeriod.Visible = False
                End If
                If (btnPOSReport.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnPOSReport.Visible = False
                End If
                If (btnWorkPeriodReport.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnWorkPeriodReport.Visible = False
                End If
                If (btnAccountingReports.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnAccountingReports.Visible = False
                End If
                If (btnSendSMS.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnSendSMS.Visible = False
                End If
                If (btnRegistration.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnRegistration.Visible = False
                End If
                If (btnLogs.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnLogs.Visible = False
                End If
                If (btnItemStockx.Text.ToUpper() = dtAccess.Rows(a)(0)) Then
                    btnItemStockx.Enabled = False
                End If
                a = a + 1
            End While
        Catch
        End Try
    End Sub
End Class