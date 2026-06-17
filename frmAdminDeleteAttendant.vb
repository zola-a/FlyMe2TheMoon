Imports System.Data.OleDb

Public Class frmAdminDeleteAttendant

    Private Sub frmAdminDeleteAttendant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAttendants()
    End Sub

    Private Sub LoadAttendants()
        cboAttendants.Items.Clear()
        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Dim cmd As New OleDbCommand("SELECT intAttendantID, strFirstName + ' ' + strLastName AS FullName FROM TAttendants ORDER BY strLastName, strFirstName", m_conAdministrator)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            Dim dt As New DataTable
            dt.Load(dr)
            dr.Close()

            cboAttendants.DataSource = dt
            cboAttendants.ValueMember = "intAttendantID"
            cboAttendants.DisplayMember = "FullName"

            btnSubmit.Enabled = dt.Rows.Count > 0
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Error loading attendants: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If cboAttendants.SelectedIndex = -1 Then
            MessageBox.Show("Select an attendant first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show($"Are you sure you want to delete '{cboAttendants.Text}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Using cmd As New OleDbCommand("uspDeleteAttendant", m_conAdministrator)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@AttendantID", cboAttendants.SelectedValue)
                Dim paramStatus As New OleDbParameter("@Status", OleDbType.Integer)
                paramStatus.Direction = ParameterDirection.Output
                cmd.Parameters.Add(paramStatus)

                cmd.ExecuteNonQuery()

                Select Case CInt(paramStatus.Value)
                    Case 0
                        MessageBox.Show("Attendant deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case 1
                        MessageBox.Show("Attendant not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Case Else
                        MessageBox.Show("Unknown error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select
            End Using

            CloseDatabaseConnection()
            LoadAttendants()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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