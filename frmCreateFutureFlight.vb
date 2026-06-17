Imports System.Data.OleDb

Public Class frmCreateFutureFlight

    Private Sub frmCreateFutureFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Flight must be in the future
        dtmFlightDate.MinDate = Date.Today.AddDays(1)
        LoadAirports()
        LoadPlanes()  ' Load planes into ComboBox
    End Sub

    '----------------------------------------------------------
    ' Load Airports
    '----------------------------------------------------------
    Private Sub LoadAirports()
        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            ' "From" airports
            Dim cmdFrom As New OleDbCommand("SELECT intAirportID, strAirportCity FROM TAirports ORDER BY strAirportCity", m_conAdministrator)
            Dim dtFrom As New DataTable
            dtFrom.Load(cmdFrom.ExecuteReader())
            cboFromAirport.DisplayMember = "strAirportCity"
            cboFromAirport.ValueMember = "intAirportID"
            cboFromAirport.DataSource = dtFrom

            ' "To" airports
            Dim cmdTo As New OleDbCommand("SELECT intAirportID, strAirportCity FROM TAirports ORDER BY strAirportCity", m_conAdministrator)
            Dim dtTo As New DataTable
            dtTo.Load(cmdTo.ExecuteReader())
            cboToAirport.DisplayMember = "strAirportCity"
            cboToAirport.ValueMember = "intAirportID"
            cboToAirport.DataSource = dtTo

            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Error loading airports: " & ex.Message)
        End Try
    End Sub

    '----------------------------------------------------------
    ' Load Planes
    '----------------------------------------------------------
    Private Sub LoadPlanes()
        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Dim cmd As New OleDbCommand("
                SELECT P.intPlaneID, P.strPlaneNumber + ' (' + PT.strPlaneType + ')' AS PlaneDisplay
                FROM TPlanes P
                JOIN TPlaneTypes PT ON P.intPlaneTypeID = PT.intPlaneTypeID
                ORDER BY P.strPlaneNumber
            ", m_conAdministrator)

            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader())

            cboPlane.DisplayMember = "PlaneDisplay"
            cboPlane.ValueMember = "intPlaneID"
            cboPlane.DataSource = dt
            cboPlane.SelectedIndex = -1

            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Error loading planes: " & ex.Message)
        End Try
    End Sub

    '----------------------------------------------------------
    ' Submit Flight
    '----------------------------------------------------------
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Validation
        If txtFlightNumber.Text.Trim = "" OrElse cboFromAirport.SelectedIndex = -1 OrElse cboToAirport.SelectedIndex = -1 OrElse cboPlane.SelectedIndex = -1 Then
            MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If dtmFlightDate.Value <= Date.Today Then
            MessageBox.Show("Flight date must be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If dtmDepartureTime.Value >= dtmLandingTime.Value Then
            MessageBox.Show("Departure time must be before landing time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim miles As Integer
        If Not Integer.TryParse(txtMilesFlown.Text, miles) OrElse miles <= 0 Then
            MessageBox.Show("Please enter a valid number for miles flown.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            ' Generate next FlightID
            Dim nextFlightID As Integer = 1
            Using cmdGet As New OleDbCommand("SELECT ISNULL(MAX(intFlightID),0)+1 AS NextID FROM TFlights", m_conAdministrator)
                Dim dr As OleDbDataReader = cmdGet.ExecuteReader()
                If dr.Read() AndAlso Not dr.IsDBNull(0) Then nextFlightID = CInt(dr("NextID"))
                dr.Close()
            End Using

            ' Insert flight using stored procedure
            Using cmd As New OleDbCommand("usp_InsertFlight", m_conAdministrator)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@FlightID", nextFlightID)
                cmd.Parameters.AddWithValue("@FlightNumber", txtFlightNumber.Text.Trim)
                cmd.Parameters.AddWithValue("@FromAirportID", cboFromAirport.SelectedValue)
                cmd.Parameters.AddWithValue("@ToAirportID", cboToAirport.SelectedValue)
                cmd.Parameters.AddWithValue("@FlightDate", dtmFlightDate.Value)
                cmd.Parameters.AddWithValue("@DepartureTime", dtmDepartureTime.Value)
                cmd.Parameters.AddWithValue("@LandingTime", dtmLandingTime.Value)
                cmd.Parameters.AddWithValue("@MilesFlown", miles)
                cmd.Parameters.AddWithValue("@PlaneID", cboPlane.SelectedValue)

                ' Status output
                Dim paramStatus As New OleDbParameter("@Status", OleDbType.Integer)
                paramStatus.Direction = ParameterDirection.Output
                cmd.Parameters.Add(paramStatus)

                cmd.ExecuteNonQuery()
                Dim result As Integer = CInt(paramStatus.Value)

                If result = 0 Then
                    MessageBox.Show("Future flight created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Optional: assign pilots/attendants
                    Using assignPilotForm As New frmAdminAssignPilotFlight
                        assignPilotForm.ShowDialog()
                    End Using

                    Using assignAttendantForm As New frmAdminAssignAttendantFlight
                        assignAttendantForm.ShowDialog()
                    End Using

                    Me.Close()
                Else
                    MessageBox.Show("Error creating flight. Status: " & result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using

            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseDatabaseConnection()
        End Try
    End Sub

    '----------------------------------------------------------
    ' Exit Button
    '----------------------------------------------------------
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
