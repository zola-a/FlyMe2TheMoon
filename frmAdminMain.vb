Imports System.Data.OleDb

Public Class frmAdminMain

    Private Sub btnAddPilot_Click(sender As Object, e As EventArgs) Handles btnAddPilot.Click
        Dim f As New frmAdminAddPilot
        f.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub btnDeletePilot_Click(sender As Object, e As EventArgs) Handles btnDeletePilot.Click
        Dim f As New frmAdminDeletePilot
        f.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub btnAssignPilot_Click(sender As Object, e As EventArgs) Handles btnAssignPilot.Click
        Dim f As New frmAdminAssignPilotFlight
        f.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub btnAddAttendant_Click(sender As Object, e As EventArgs) Handles btnAddAttendant.Click
        Dim f As New frmAdminAddAttendant
        f.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub btnDeleteAttendant_Click(sender As Object, e As EventArgs) Handles btnDeleteAttendant.Click
        Dim f As New frmAdminDeleteAttendant
        f.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub btnAssignAttendant_Click(sender As Object, e As EventArgs) Handles btnAssignAttendant.Click
        Dim f As New frmAdminAssignAttendantFlight
        f.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub btnStatistics_Click(sender As Object, e As EventArgs) Handles btnStatistics.Click
        Dim f As New frmStatistics
        f.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' return to user selection / main form
        Dim f As New frmEmployeeLogin
        f.Show()
        Me.Close()
    End Sub

    Private Sub btnCreateFlights_Click(sender As Object, e As EventArgs) Handles btnCreateFlights.Click
        Dim f As New frmCreateFutureFlight
        f.ShowDialog()
        Me.Hide()
    End Sub
End Class