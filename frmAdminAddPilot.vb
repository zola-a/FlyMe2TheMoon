Imports System.Data.OleDb

Public Class frmAdminAddPilot

    Private Sub frmAdminAddPilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPilotRoles()
    End Sub

    Private Sub LoadPilotRoles()
        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Dim cmd As New OleDbCommand("SELECT intPilotRoleID, strPilotRole FROM TPilotRoles ORDER BY strPilotRole", m_conAdministrator)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            Dim dt As New DataTable
            dt.Load(dr)
            dr.Close()

            cboPilotRoles.DisplayMember = "strPilotRole"
            cboPilotRoles.ValueMember = "intPilotRoleID"
            cboPilotRoles.DataSource = dt

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show("Error loading roles: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        ' Validate inputs
        If txtFirstName.Text.Trim = "" OrElse
           txtLastName.Text.Trim = "" OrElse
           txtEmployeeID.Text.Trim = "" OrElse
           txtPilotUserName.Text.Trim = "" OrElse
           txtPilotPassword.Text.Trim = "" Then

            MessageBox.Show("Please fill in all fields.")
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            ' Generate next PilotID
            Dim cmdNextID As New OleDbCommand("SELECT ISNULL(MAX(intPilotID),0) + 1 FROM TPilots", m_conAdministrator)
            Dim nextPilotID As Integer = CInt(cmdNextID.ExecuteScalar())

            ' Call stored procedure
            Dim cmd As New OleDbCommand("usp_InsertPilot", m_conAdministrator)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@PilotID", nextPilotID)
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim)
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim)
            cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text.Trim)
            cmd.Parameters.AddWithValue("@DateOfHire", dtmHire.Value)
            cmd.Parameters.AddWithValue("@DateOfTermination", dtmTermination.Value)
            cmd.Parameters.AddWithValue("@DateOfLicense", dtmLicense.Value)
            cmd.Parameters.AddWithValue("@PilotRoleID", cboPilotRoles.SelectedValue)
            cmd.Parameters.AddWithValue("@Username", txtPilotUserName.Text.Trim)
            cmd.Parameters.AddWithValue("@Password", txtPilotPassword.Text.Trim)

            Dim pStatus As New OleDbParameter("@Status", OleDbType.Integer)
            pStatus.Direction = ParameterDirection.Output
            cmd.Parameters.Add(pStatus)

            cmd.ExecuteNonQuery()

            If CInt(pStatus.Value) <> 0 Then
                MessageBox.Show("Pilot insert failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CloseDatabaseConnection()
                Exit Sub
            End If

            MessageBox.Show("Pilot and login created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            CloseDatabaseConnection()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Insert error: " & ex.Message)
            CloseDatabaseConnection()
        End Try

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        Dim f As New frmAdminMain
        f.ShowDialog()
        Me.Close()
    End Sub

End Class


