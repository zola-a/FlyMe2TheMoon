Imports System.Data.OleDb

Public Class frmPilotUpdate

    Private Sub frmPilotUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Validate global ID
        If g_intPilotID <= 0 Then
            MessageBox.Show("No pilot selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            ' ---------------------------------------------------------
            ' Load Pilot Roles
            ' ---------------------------------------------------------
            Dim cmdRoles As New OleDbCommand("
                SELECT intPilotRoleID, strPilotRole 
                FROM TPilotRoles 
                ORDER BY strPilotRole", m_conAdministrator)

            Dim drRoles As OleDbDataReader = cmdRoles.ExecuteReader()
            Dim dtRoles As New DataTable
            dtRoles.Load(drRoles)
            drRoles.Close()

            cboPilotRole.ValueMember = "intPilotRoleID"
            cboPilotRole.DisplayMember = "strPilotRole"
            cboPilotRole.DataSource = dtRoles


            ' ---------------------------------------------------------
            ' Load Pilot Details
            ' ---------------------------------------------------------
            Dim cmdPilot As New OleDbCommand("
                SELECT strFirstName, strLastName, strEmployeeID,
                       dtmDateOfHire, dtmDateOfTermination, dtmDateOfLicense,
                       intPilotRoleID
                FROM TPilots
                WHERE intPilotID = @PilotID", m_conAdministrator)

            cmdPilot.Parameters.AddWithValue("@PilotID", g_intPilotID)

            Dim drPilot As OleDbDataReader = cmdPilot.ExecuteReader()

            If drPilot.Read() Then
                txtFirstName.Text = drPilot("strFirstName").ToString()
                txtLastName.Text = drPilot("strLastName").ToString()
                txtEmployeeID.Text = drPilot("strEmployeeID").ToString()

                If Not IsDBNull(drPilot("dtmDateOfHire")) Then dtmHire.Value = CDate(drPilot("dtmDateOfHire"))
                If Not IsDBNull(drPilot("dtmDateOfTermination")) Then dtmTermination.Value = CDate(drPilot("dtmDateOfTermination"))
                If Not IsDBNull(drPilot("dtmDateOfLicense")) Then dtmLicense.Value = CDate(drPilot("dtmDateOfLicense"))

                cboPilotRole.SelectedValue = CInt(drPilot("intPilotRoleID"))
            Else
                MessageBox.Show("Pilot not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                drPilot.Close()
                CloseDatabaseConnection()
                Me.Close()
                Exit Sub
            End If

            drPilot.Close()


            ' ---------------------------------------------------------
            ' Load Employee Login Credentials (Username + Password)
            ' ---------------------------------------------------------
            Dim cmdEmp As New OleDbCommand("
                SELECT strEmployeeUsername, strEmployeePassword
                FROM TEmployees
                WHERE intRoleLinkID = @PilotID
                  AND strEmployeeRole = 'Pilot'
            ", m_conAdministrator)

            cmdEmp.Parameters.AddWithValue("@PilotID", g_intPilotID)

            Dim drEmp As OleDbDataReader = cmdEmp.ExecuteReader()

            If drEmp.Read() Then
                txtPilotUserName.Text = drEmp("strEmployeeUsername").ToString()
                txtPilotPassword.Text = drEmp("strEmployeePassword").ToString()
            Else
                MessageBox.Show("Employee login record not found for this pilot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            drEmp.Close()

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show("Error loading pilot: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseDatabaseConnection()
        End Try
    End Sub



    ' ======================================================
    ' UPDATE BUTTON
    ' ======================================================
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        ' ------------------------------------------------------
        ' Validation
        ' ------------------------------------------------------
        If txtFirstName.Text.Trim = "" OrElse
           txtLastName.Text.Trim = "" OrElse
           txtEmployeeID.Text.Trim = "" OrElse
           txtPilotUserName.Text.Trim = "" OrElse
           txtPilotPassword.Text.Trim = "" Then

            MessageBox.Show("All fields are required including Username and Password.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            ' ------------------------------------------------------
            ' Update Pilot (Stored Procedure)
            ' ------------------------------------------------------
            Dim cmd As New OleDbCommand("uspUpdatePilot", m_conAdministrator)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@PilotID", g_intPilotID)
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim)
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim)
            cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text.Trim)
            cmd.Parameters.AddWithValue("@DateOfHire", dtmHire.Value)
            cmd.Parameters.AddWithValue("@DateOfTermination", dtmTermination.Value)
            cmd.Parameters.AddWithValue("@DateOfLicense", dtmLicense.Value)
            cmd.Parameters.AddWithValue("@RoleID", cboPilotRole.SelectedValue)

            Dim pStatus As New OleDbParameter("@Status", OleDbType.Integer)
            pStatus.Direction = ParameterDirection.Output
            cmd.Parameters.Add(pStatus)

            cmd.ExecuteNonQuery()

            Dim result As Integer = CInt(pStatus.Value)

            If result <> 0 Then
                MessageBox.Show("Pilot update failed. Status Code: " & result, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                CloseDatabaseConnection()
                Exit Sub
            End If


            ' ------------------------------------------------------
            ' Update Employee Login Credentials
            ' ------------------------------------------------------
            Dim cmdEmpUpdate As New OleDbCommand("
                UPDATE TEmployees
                SET strEmployeeUsername = @U,
                    strEmployeePassword = @P
                WHERE intRoleLinkID = @PilotID
                  AND strEmployeeRole = 'Pilot'
            ", m_conAdministrator)

            cmdEmpUpdate.Parameters.AddWithValue("@U", txtPilotUserName.Text.Trim)
            cmdEmpUpdate.Parameters.AddWithValue("@P", txtPilotPassword.Text.Trim)
            cmdEmpUpdate.Parameters.AddWithValue("@PilotID", g_intPilotID)

            cmdEmpUpdate.ExecuteNonQuery()


            MessageBox.Show("Pilot updated successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            CloseDatabaseConnection()
            Me.Close()

        Catch ex As OleDbException
            MessageBox.Show("Database error: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show("Unexpected error: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseDatabaseConnection()
        End Try
    End Sub



    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class