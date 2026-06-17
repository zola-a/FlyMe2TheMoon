Imports System.Data.OleDb

Public Class frmAdminAssignPilotFlight

    '----------------------------------------------------------
    ' Form Load
    '----------------------------------------------------------
    Private Sub frmAdminAssignPilotFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPilots()
        LoadFutureFlights()
    End Sub

    '----------------------------------------------------------
    ' Load Pilots ComboBox
    '----------------------------------------------------------
    Private Sub LoadPilots()
        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Dim strSQL As String = "SELECT intPilotID, strFirstName + ' ' + strLastName AS PilotName FROM TPilots ORDER BY strLastName, strFirstName"
            Dim cmd As New OleDbCommand(strSQL, m_conAdministrator)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            Dim dt As New DataTable
            dt.Load(dr)
            dr.Close()

            cboPilots.DisplayMember = "PilotName"
            cboPilots.ValueMember = "intPilotID"
            cboPilots.DataSource = dt

            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Error loading pilots: " & ex.Message)
        End Try
    End Sub

    '----------------------------------------------------------
    ' Load Future Flights ComboBox
    '----------------------------------------------------------
    Private Sub LoadFutureFlights()
        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Dim strSQL As String = "SELECT intFlightID, strFlightNumber + ' - ' + CONVERT(varchar, dtmFlightDate, 101) AS FlightInfo " &
                                   "FROM TFlights WHERE dtmFlightDate > GETDATE() ORDER BY dtmFlightDate"
            Dim cmd As New OleDbCommand(strSQL, m_conAdministrator)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            Dim dt As New DataTable
            dt.Load(dr)
            dr.Close()

            cboFlights.DisplayMember = "FlightInfo"
            cboFlights.ValueMember = "intFlightID"
            cboFlights.DataSource = dt

            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Error loading flights: " & ex.Message)
        End Try
    End Sub

    '----------------------------------------------------------
    ' Submit Button
    '----------------------------------------------------------
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If cboPilots.SelectedIndex = -1 Or cboFlights.SelectedIndex = -1 Then
            MessageBox.Show("Please select both a pilot and a flight.")
            Exit Sub
        End If

        Dim intPilotID As Integer = CInt(cboPilots.SelectedValue)
        Dim intFlightID As Integer = CInt(cboFlights.SelectedValue)

        If MessageBox.Show("Are you sure you want to assign this pilot to the selected flight?", "Confirm", MessageBoxButtons.YesNo) <> DialogResult.Yes Then Exit Sub

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            ' Check if already assigned
            Dim cmdCheck As New OleDbCommand("SELECT COUNT(*) FROM TPilotFlights WHERE intPilotID = " & intPilotID & " AND intFlightID = " & intFlightID, m_conAdministrator)
            Dim exists As Integer = CInt(cmdCheck.ExecuteScalar())
            If exists > 0 Then
                MessageBox.Show("This pilot is already assigned to this flight.")
                CloseDatabaseConnection()
                Exit Sub
            End If

            ' Generate next intPilotFlightID
            Dim nextID As Integer = 1
            Dim cmdGet As New OleDbCommand("SELECT ISNULL(MAX(intPilotFlightID),0)+1 AS NextID FROM TPilotFlights", m_conAdministrator)
            Dim dr As OleDbDataReader = cmdGet.ExecuteReader()
            If dr.Read() AndAlso Not dr.IsDBNull(0) Then
                nextID = CInt(dr("NextID"))
            End If
            dr.Close()

            ' Insert assignment
            Dim cmdInsert As New OleDbCommand("INSERT INTO TPilotFlights (intPilotFlightID, intPilotID, intFlightID) VALUES (" & nextID & ", " & intPilotID & ", " & intFlightID & ")", m_conAdministrator)
            Dim rows As Integer = cmdInsert.ExecuteNonQuery()

            If rows > 0 Then
                MessageBox.Show("Pilot assigned to flight successfully.")
            Else
                MessageBox.Show("Assignment failed.")
            End If

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show("Error assigning pilot: " & ex.Message)
        End Try
    End Sub

    '----------------------------------------------------------
    ' Exit Button
    '----------------------------------------------------------
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        Dim f As New frmAdminMain
        f.ShowDialog()
        Me.Close()
    End Sub

End Class
