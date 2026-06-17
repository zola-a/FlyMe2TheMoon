Public Class frmAttendantMain




    Private Sub btnUpdateProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateProfile.Click

        Dim frm As New frmAttendantUpdate
        frm.ShowDialog()

    End Sub

    Private Sub btnPastFlights_Click_1(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        Dim f As New frmAttendantPastFlights
        f.ShowDialog()

    End Sub

    Private Sub btnFutureFlights_Click_1(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        Dim f As New frmAttendantFutureFlights
        f.ShowDialog()

    End Sub

    Private Sub btnLogout_Click_1(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim f As New frmEmployeeLogin
        f.Show()
        Me.Close()

    End Sub
End Class