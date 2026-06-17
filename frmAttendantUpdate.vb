Imports System.Data.OleDb

Public Class frmAttendantUpdate

    Private Sub frmAttendantUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If g_intAttendantID <= 0 Then
            MessageBox.Show("No attendant selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            ' Load Attendant main record
            Using cmd As New OleDbCommand("
                SELECT strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOfTermination 
                FROM TAttendants 
                WHERE intAttendantID = @ID", m_conAdministrator)

                cmd.Parameters.AddWithValue("@ID", g_intAttendantID)

                Using dr As OleDbDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        txtFirstName.Text = dr("strFirstName").ToString()
                        txtLastName.Text = dr("strLastName").ToString()
                        txtEmployeeID.Text = dr("strEmployeeID").ToString()

                        If Not IsDBNull(dr("dtmDateOfHire")) Then dtmHire.Value = CDate(dr("dtmDateOfHire"))
                        If Not IsDBNull(dr("dtmDateOfTermination")) Then dtmTermination.Value = CDate(dr("dtmDateOfTermination"))
                    Else
                        MessageBox.Show("Attendant not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        CloseDatabaseConnection()
                        Me.Close()
                        Exit Sub
                    End If
                End Using
            End Using

            ' Load EMPLOYEE login account (username + password)
            Using cmd2 As New OleDbCommand("
                SELECT strEmployeeUsername, strEmployeePassword 
                FROM TEmployees 
                WHERE intEmployeeID = @EmpID", m_conAdministrator)

                cmd2.Parameters.AddWithValue("@EmpID", CInt(txtEmployeeID.Text))

                Using dr2 As OleDbDataReader = cmd2.ExecuteReader()
                    If dr2.Read() Then
                        txtUserName.Text = dr2("strEmployeeUsername").ToString()
                        txtPassword.Text = dr2("strEmployeePassword").ToString()
                    End If
                End Using
            End Using

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show("Error loading attendant: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseDatabaseConnection()
        End Try

    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        ' Validation
        If txtFirstName.Text.Trim = "" Or txtLastName.Text.Trim = "" Or
           txtUserName.Text.Trim = "" Or txtPassword.Text.Trim = "" Then

            MessageBox.Show("All fields are required, including Username and Password.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If dtmTermination.Value < dtmHire.Value Then
            MessageBox.Show("Termination date cannot be earlier than hire date.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Using cmd As New OleDbCommand("uspUpdateAttendant", m_conAdministrator)
                cmd.CommandType = CommandType.StoredProcedure

                ' Attendant table parameters
                cmd.Parameters.AddWithValue("@AttendantID", g_intAttendantID)
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim)
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim)
                cmd.Parameters.AddWithValue("@EmployeeID", CInt(txtEmployeeID.Text))
                cmd.Parameters.AddWithValue("@DateOfHire", dtmHire.Value)
                cmd.Parameters.AddWithValue("@DateOfTermination", dtmTermination.Value)

                ' Employee table login update
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim)
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim)

                ' Output parameter
                Dim paramStatus As New OleDbParameter("@Status", OleDbType.Integer)
                paramStatus.Direction = ParameterDirection.Output
                cmd.Parameters.Add(paramStatus)

                cmd.ExecuteNonQuery()

                Select Case CInt(paramStatus.Value)
                    Case 0
                        MessageBox.Show("Attendant and Login updated successfully.",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case 1
                        MessageBox.Show("Attendant not found.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Case -1
                        MessageBox.Show("Error updating attendant.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Case Else
                        MessageBox.Show("Unknown error occurred.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select

            End Using

            CloseDatabaseConnection()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseDatabaseConnection()
        End Try

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class