Imports System.Data.OleDb

Public Class frmAdminAddAttendant

    Private Sub frmAdminAddAttendant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' No role dropdown required. Role = "Attendant" always.
    End Sub

    ' ============================================================
    ' SUBMIT BUTTON
    ' ============================================================
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        ' --------------------------------------------------------
        ' Validation
        ' --------------------------------------------------------
        If txtFirstName.Text.Trim = "" OrElse
           txtLastName.Text.Trim = "" OrElse
           txtEmployeeID.Text.Trim = "" OrElse
           txtUserName.Text.Trim = "" OrElse
           txtPassword.Text.Trim = "" Then

            MessageBox.Show("Please fill in all required fields.",
                            "Validation Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            ' ============================================================
            ' 1. GET NEXT Attendant ID
            ' ============================================================
            Dim nextAttendantID As Integer
            Using cmdGet As New OleDbCommand(
                "SELECT ISNULL(MAX(intAttendantID),0) + 1 FROM TAttendants",
                m_conAdministrator)

                nextAttendantID = CInt(cmdGet.ExecuteScalar())
            End Using

            ' ============================================================
            ' 2. CALL STORED PROCEDURE usp_InsertAttendant
            ' ============================================================
            Using cmdInsert As New OleDbCommand("usp_InsertAttendant", m_conAdministrator)
                cmdInsert.CommandType = CommandType.StoredProcedure

                cmdInsert.Parameters.AddWithValue("@AttendantID", nextAttendantID)
                cmdInsert.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim)
                cmdInsert.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim)
                cmdInsert.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text.Trim)
                cmdInsert.Parameters.AddWithValue("@DateOfHire", dtmHire.Value)
                cmdInsert.Parameters.AddWithValue("@DateOfTermination", dtmTermination.Value)
                cmdInsert.Parameters.AddWithValue("@Username", txtUserName.Text.Trim)
                cmdInsert.Parameters.AddWithValue("@Password", txtPassword.Text.Trim)

                Dim pStatus As New OleDbParameter("@Status", OleDbType.Integer)
                pStatus.Direction = ParameterDirection.Output
                cmdInsert.Parameters.Add(pStatus)

                cmdInsert.ExecuteNonQuery()

                If CInt(pStatus.Value) <> 0 Then
                    MessageBox.Show("Failed to insert attendant record.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CloseDatabaseConnection()
                    Exit Sub
                End If
            End Using

            ' ============================================================
            ' DONE
            ' ============================================================
            MessageBox.Show("Attendant and login created successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            CloseDatabaseConnection()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error adding attendant: " & ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            CloseDatabaseConnection()
        End Try

    End Sub

    ' ============================================================
    ' EXIT BUTTON
    ' ============================================================
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        Dim f As New frmAdminMain
        f.ShowDialog()
        Me.Close()
    End Sub

End Class
