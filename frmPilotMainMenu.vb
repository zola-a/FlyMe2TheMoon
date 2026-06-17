Public Class frmPilotMainMenu
    Private Sub btnUpdateProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateProfile.Click
        Dim frm As New frmPilotUpdate
        frm.ShowDialog()
    End Sub

    Private Sub btnShowPastFlights_Click(sender As Object, e As EventArgs) Handles btnShowPastFlights.Click
        Dim frm As New frmPilotPastFlights
        frm.ShowDialog()
    End Sub

    Private Sub btnShowFutureFlights_Click(sender As Object, e As EventArgs) Handles btnShowFutureFlights.Click
        Dim frm As New frmPilotFutureFlights
        frm.ShowDialog()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        g_intPilotID = -1

        Me.Close()
    End Sub
End Class