Imports System.Data.OleDb

Public Class frmEmployeeLogin

    '----------------------------------------------------------
    ' Form Load
    '----------------------------------------------------------
    Private Sub frmEmployeeLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Employee Login"
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

            ' Query Employee table
            Dim sql As String =
                "SELECT intEmployeeID, strEmployeeRole 
                 FROM TEmployees 
                 WHERE strEmployeeUsername = ? 
                 AND strEmployeePassword = ?"

            Using cmd As New OleDbCommand(sql, m_conAdministrator)
                cmd.Parameters.AddWithValue("?", txtUserName.Text.Trim)
                cmd.Parameters.AddWithValue("?", txtPassword.Text.Trim)

                Using rdr As OleDbDataReader = cmd.ExecuteReader()

                    If rdr.Read() Then
                        '----------------------------------------------------------
                        ' Found matching employee
                        '----------------------------------------------------------
                        Dim empID As Integer = CInt(rdr("intEmployeeID"))
                        Dim role As String = rdr("strEmployeeRole").ToString()

                        rdr.Close()
                        CloseDatabaseConnection()

                        ' Store role globally
                        g_strUserType = role

                        ' Store correct employee ID depending on role
                        Select Case role
                            Case "Pilot"
                                g_intPilotID = empID
                            Case "Attendant"
                                g_intAttendantID = empID
                            Case "Admin"
                                ' Admin does not need an ID reference
                        End Select

                        '----------------------------------------------------------
                        ' Navigation by role
                        '----------------------------------------------------------
                        Select Case role
                            Case "Admin"
                                Dim f As New frmAdminMain()
                                f.ShowDialog()
                            Case "Pilot"
                                Dim f As New frmPilotMainMenu()
                                f.ShowDialog()
                            Case "Attendant"
                                Dim f As New frmAttendantMain()
                                f.ShowDialog()
                        End Select

                        Me.Close()

                    Else
                        '----------------------------------------------------------
                        ' No matching employee found
                        '----------------------------------------------------------
                        MessageBox.Show("Username and/or Password are not valid.")
                        txtPassword.Clear()
                        txtPassword.Focus()
                    End If

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Login error: " & ex.Message)
        End Try

    End Sub

    '----------------------------------------------------------
    ' Exit Button
    '----------------------------------------------------------
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
