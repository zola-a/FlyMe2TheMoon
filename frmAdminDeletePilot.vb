Imports System.Data.OleDb

Public Class frmAdminDeletePilot

    Private Sub frmAdminDeletePilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPilots()
    End Sub

    Private Sub LoadPilots()
        Try
            cboPilots.DataSource = Nothing

            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Dim sql As String =
                "SELECT intPilotID,
                        strFirstName + ' ' + strLastName AS FullName
                 FROM TPilots
                 ORDER BY strLastName, strFirstName"

            Dim cmd As New OleDbCommand(sql, m_conAdministrator)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            Dim dt As New DataTable
            dt.Load(dr)
            dr.Close()

            cboPilots.ValueMember = "intPilotID"
            cboPilots.DisplayMember = "FullName"
            cboPilots.DataSource = dt

            btnSubmit.Enabled = (dt.Rows.Count > 0)

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show("Error loading pilots: " & ex.Message)
            CloseDatabaseConnection()
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        If cboPilots.SelectedIndex = -1 Then
            MessageBox.Show("Please select a pilot to delete.")
            Exit Sub
        End If

        Dim pilotID As Integer = CInt(cboPilots.SelectedValue)
        Dim pilotName As String = cboPilots.Text

        If MessageBox.Show("Are you sure you want to delete the pilot: " & pilotName & "?",
                           "Confirm Delete",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Using cmd As New OleDbCommand("uspDeletePilot", m_conAdministrator)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@intPilotID", pilotID)

                Dim paramStatus As New OleDbParameter("@Status", OleDbType.Integer)
                paramStatus.Direction = ParameterDirection.Output
                cmd.Parameters.Add(paramStatus)

                cmd.ExecuteNonQuery()

                Select Case CInt(paramStatus.Value)
                    Case 0
                        MessageBox.Show("Pilot deleted successfully.")
                    Case 1
                        MessageBox.Show("Pilot does not exist.")
                    Case 2
                        MessageBox.Show("Cannot delete pilot: pilot is assigned to future flights.")
                    Case Else
                        MessageBox.Show("An unknown error occurred.")
                End Select
            End Using

            CloseDatabaseConnection()

            LoadPilots()

        Catch ex As Exception
            MessageBox.Show("Error deleting pilot: " & ex.Message)
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
