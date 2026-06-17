Imports System.Data.OleDb

Public Class frmPassengerLogin

    '----------------------------------------------------------
    ' Form Load
    '----------------------------------------------------------
    Private Sub frmPassengerLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Passenger Login"
        txtUserName.Clear()
        txtPassword.Clear()
        txtUserName.Focus()
    End Sub

    '----------------------------------------------------------
    ' Login Button
    '----------------------------------------------------------
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Validate input
        If txtUserName.Text.Trim = "" Or txtPassword.Text.Trim = "" Then
            MessageBox.Show("Please enter both username and password.")
            Exit Sub
        End If

        Try
            ' Open database connection
            If Not OpenDatabaseConnectionSQLServer() Then
                MessageBox.Show("Database connection error.")
                Exit Sub
            End If

            ' Query Passenger table for username and password
            Dim sql As String = "SELECT intPassengerID FROM TPassengers WHERE strPassengerUsername = ? AND strPassengerPassword = ?"
            Using cmd As New OleDbCommand(sql, m_conAdministrator)
                cmd.Parameters.AddWithValue("?", txtUserName.Text.Trim)
                cmd.Parameters.AddWithValue("?", txtPassword.Text.Trim)

                Using rdr As OleDbDataReader = cmd.ExecuteReader()
                    If rdr.Read() Then
                        ' Matching record found
                        g_intCustomerID = CInt(rdr("intPassengerID"))  ' Store PassengerID in global variable
                        g_strUserType = "Customer"                     ' Store user type globally

                        ' Navigate to Passenger Main Menu
                        Dim f As New frmCustomerMain
                        f.ShowDialog()
                        Me.Close()
                    Else
                        ' No match found
                        MessageBox.Show("Username and/or Password are not valid.")
                        txtPassword.Clear()
                        txtPassword.Focus()
                    End If
                End Using
            End Using

            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Login error: " & ex.Message)
        End Try
    End Sub

    '----------------------------------------------------------
    ' New Passenger Button
    '----------------------------------------------------------
    Private Sub btnNewPassenger_Click(sender As Object, e As EventArgs) Handles btnNewPassenger.Click
        Dim f As New frmAddPassenger()
        f.ShowDialog()
        ' After adding, the new passenger can login using their username/password
        txtUserName.Clear()
        txtPassword.Clear()
        txtUserName.Focus()
    End Sub

    '----------------------------------------------------------
    ' Exit Button
    '----------------------------------------------------------
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
