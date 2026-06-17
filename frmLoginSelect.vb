Imports System.Data.OleDb

Public Class frmLoginSelect
    ' Form Load
    Private Sub frmLoginSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Select User Type"
    End Sub

    ' Passenger Login button click
    Private Sub btnPassengerLogin_Click(sender As Object, e As EventArgs) Handles btnPassengerLogin.Click
        Dim f As New frmPassengerLogin()
        f.ShowDialog()
    End Sub

    ' Employee Login button click
    Private Sub btnEmployeeLogin_Click(sender As Object, e As EventArgs) Handles btnEmployeeLogin.Click
        Dim f As New frmEmployeeLogin() ' Opens form for Pilot / Attendant / Admin login
        f.ShowDialog()
    End Sub

    ' Exit button click
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub
End Class
