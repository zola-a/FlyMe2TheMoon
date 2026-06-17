Imports System.Data.OleDb

Public Class frmCustomerMain

    Private Sub frmCustomerMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If g_intCustomerID <= 0 Then
            MessageBox.Show("No customer selected.")
            Dim f As New frmPassengerLogin
            f.Show()
            Me.Close()
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Dim cmdSelect As New OleDbCommand("usp_GetCustomerByID", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            Dim objParam As OleDbParameter = cmdSelect.Parameters.Add("@CustomerID", OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = g_intCustomerID

            Dim dr As OleDbDataReader = cmdSelect.ExecuteReader()
            If dr.Read() Then
                lblWelcome.Text = "Welcome, " & dr("FirstName").ToString().Trim() & " " & dr("LastName").ToString().Trim()
            Else
                lblWelcome.Text = "Welcome, Customer"
            End If
            dr.Close()
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnUpdateProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateProfile.Click
        Dim frm As New frmCustomerUpdate()
        frm.ShowDialog()
        frmCustomerMain_Load(sender, e)
    End Sub

    Private Sub btnBookFlight_Click(sender As Object, e As EventArgs) Handles btnBookFlight.Click
        Dim frm As New frmcustomerBookFlight()
        frm.ShowDialog()
    End Sub

    Private Sub btnShowPast_Click(sender As Object, e As EventArgs) Handles btnShowPast.Click
        Dim frm As New frmCustomerPastFlights()
        frm.ShowDialog()
    End Sub

    Private Sub btnShowFuture_Click(sender As Object, e As EventArgs) Handles btnShowFuture.Click
        Dim frm As New frmCustomerFutureFlights()
        frm.ShowDialog()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim f As New frmPassengerLogin
        f.ShowDialog()
        Me.Close()
    End Sub

End Class
