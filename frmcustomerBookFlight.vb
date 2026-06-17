Imports System.Data.OleDb

Public Class frmCustomerBookFlight

    Private g_intCustomerID As Integer = 1 ' Example: replace with actual logged-in customer ID

    Private Sub frmCustomerBookFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFutureFlights()

        rdoReservedSeat.Visible = False
        rdoDesignatedSeat.Visible = False
    End Sub

    '===============================================================
    ' Load future flights
    '===============================================================
    Private Sub LoadFutureFlights()
        cboFlights.Items.Clear()

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Dim strSQL As String =
                "SELECT F.intFlightID, F.strFlightNumber, F.dtmFlightDate, F.intMilesFlown, " &
                "AF.strAirportCity AS FromCity, AT.strAirportCity AS ToCity, " &
                "PT.strPlaneType " &
                "FROM TFlights F " &
                "JOIN TAirports AF ON F.intFromAirportID = AF.intAirportID " &
                "JOIN TAirports AT ON F.intToAirportID = AT.intAirportID " &
                "LEFT JOIN TPlanes P ON F.intPlaneID = P.intPlaneID " &
                "LEFT JOIN TPlaneTypes PT ON P.intPlaneTypeID = PT.intPlaneTypeID " &
                "WHERE CAST(F.dtmFlightDate AS DATE) > CAST(GETDATE() AS DATE) " &
                "ORDER BY F.dtmFlightDate"

            Dim cmd As New OleDbCommand(strSQL, m_conAdministrator)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            While dr.Read()
                Dim display As String =
                    dr("strFlightNumber").ToString() & " - " &
                    Convert.ToDateTime(dr("dtmFlightDate")).ToShortDateString() & " : " &
                    dr("FromCity").ToString() & " → " & dr("ToCity").ToString() &
                    " (" & dr("intMilesFlown").ToString() & " miles, " &
                    dr("strPlaneType").ToString() & ")" &
                    "|" & dr("intFlightID").ToString()

                cboFlights.Items.Add(display)
            End While

            dr.Close()
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Error loading flights: " & ex.Message)
            CloseDatabaseConnection()
        End Try
    End Sub

    '===============================================================
    ' When user selects a flight
    '===============================================================
    Private Sub cboFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFlights.SelectedIndexChanged
        If cboFlights.SelectedIndex = -1 Then Exit Sub

        rdoReservedSeat.Visible = True
        rdoDesignatedSeat.Visible = True

        UpdateCostLabels()
    End Sub

    Private Sub rdoSeat_CheckedChanged(sender As Object, e As EventArgs) _
        Handles rdoReservedSeat.CheckedChanged, rdoDesignatedSeat.CheckedChanged

        UpdateCostLabels()
    End Sub

    '===============================================================
    ' Update cost labels
    '===============================================================
    Private Sub UpdateCostLabels()
        If cboFlights.SelectedIndex = -1 Then Exit Sub

        lblReservedCost.Text = "Reserved Seat: $" & CalculateFlightCost("Reserved").ToString("0.00")
        lblDesignatedCost.Text = "Designated Seat: $" & CalculateFlightCost("Designated").ToString("0.00")
    End Sub

    '===============================================================
    ' Cost calculation business logic
    '===============================================================
    Private Function CalculateFlightCost(seatType As String) As Double

        Dim cost As Double = 250

        Dim selectedParts() As String = cboFlights.SelectedItem.ToString().Split("|"c)
        Dim intFlightID As Integer = CInt(selectedParts(1))

        Dim miles As Integer = 0
        Dim planeType As String = ""
        Dim landingAirport As String = ""

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Return cost

            ' Retrieve flight details
            Dim cmd As New OleDbCommand(
                "SELECT F.intMilesFlown, PT.strPlaneType, AT.strAirportCity AS ToCity " &
                "FROM TFlights F " &
                "LEFT JOIN TPlanes P ON F.intPlaneID = P.intPlaneID " &
                "LEFT JOIN TPlaneTypes PT ON P.intPlaneTypeID = PT.intPlaneTypeID " &
                "JOIN TAirports AT ON F.intToAirportID = AT.intAirportID " &
                "WHERE F.intFlightID = " & intFlightID, m_conAdministrator)

            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            If dr.Read() Then
                miles = CInt(dr("intMilesFlown"))
                planeType = dr("strPlaneType").ToString()
                landingAirport = dr("ToCity").ToString()
            End If

            dr.Close()

            '=======================================================
            ' Cost rules
            '=======================================================

            ' Miles surcharge
            If miles > 750 Then cost += 50

            ' Reserved seat congestion rules
            Dim reservedCount As Integer =
                CInt(New OleDbCommand(
                    "SELECT COUNT(*) FROM TFlightPassengers WHERE intFlightID=" & intFlightID &
                    " AND strSeat='Reserved'", m_conAdministrator).ExecuteScalar())

            If reservedCount > 8 Then cost += 100
            If reservedCount < 4 Then cost -= 50

            ' Plane type adjustments
            If planeType = "Airbus A350" Then cost += 35
            If planeType = "Boeing 747-8" Then cost -= 25

            ' Airport surcharge
            If landingAirport = "MIA" Then cost += 15

            ' Reserved seat fee
            If seatType = "Reserved" Then cost += 125

            '=======================================================
            ' Age discount
            '=======================================================
            Dim dob As Object =
                New OleDbCommand(
                    "SELECT dtmPassengerDateOfBirth FROM TPassengers WHERE intPassengerID=" & g_intCustomerID,
                    m_conAdministrator).ExecuteScalar()

            If dob IsNot Nothing Then
                Dim age As Integer = DateDiff(DateInterval.Year, CDate(dob), Date.Today)

                If age >= 65 Then cost *= 0.8
                If age <= 5 Then cost *= 0.35
            End If

            '=======================================================
            ' Frequent flyer discount
            '=======================================================
            Dim pastFlights As Integer = CInt(
                New OleDbCommand(
                    "SELECT COUNT(*) FROM TFlightPassengers FP " &
                    "JOIN TFlights F ON FP.intFlightID = F.intFlightID " &
                    "WHERE FP.intPassengerID=" & g_intCustomerID &
                    " AND F.dtmFlightDate < GETDATE()", m_conAdministrator).ExecuteScalar())

            If pastFlights > 10 Then cost *= 0.8
            If pastFlights > 5 Then cost *= 0.9

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show("Error calculating cost: " & ex.Message)
            CloseDatabaseConnection()
        End Try

        Return cost
    End Function

    '===============================================================
    ' Book flight
    '===============================================================
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        If cboFlights.SelectedIndex = -1 Then
            MessageBox.Show("Please select a flight.")
            Exit Sub
        End If

        If Not rdoReservedSeat.Checked AndAlso Not rdoDesignatedSeat.Checked Then
            MessageBox.Show("Please select a seat type.")
            Exit Sub
        End If

        Dim parts() As String = cboFlights.SelectedItem.ToString().Split("|"c)
        Dim intFlightID As Integer = CInt(parts(1))
        Dim seatType As String = If(rdoReservedSeat.Checked, "Reserved", "Designated")
        Dim cost As Double = CalculateFlightCost(seatType)

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Dim cmd As New OleDbCommand("usp_BookFlightWithCost", m_conAdministrator)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@PassengerID", g_intCustomerID)
            cmd.Parameters.AddWithValue("@FlightID", intFlightID)
            cmd.Parameters.AddWithValue("@SeatType", seatType)
            cmd.Parameters.AddWithValue("@FlightCost", cost)

            cmd.ExecuteNonQuery()
            CloseDatabaseConnection()

            MessageBox.Show("Flight booked successfully. Cost: $" & cost.ToString("0.00"))
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message)
            CloseDatabaseConnection()
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
