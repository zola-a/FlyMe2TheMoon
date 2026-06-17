Imports System.Data.OleDb

Public Class frmCustomerFutureFlights

    Private g_intCustomerID As Integer = 1 ' Example: replace with actual logged-in customer

    Private Sub frmCustomerFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFutureFlights()
    End Sub

    '----------------------------------------------------------
    ' Load all booked future flights for this customer
    '----------------------------------------------------------
    Private Sub LoadFutureFlights()
        lstFlights.Items.Clear()
        lblTotalMiles.Text = "Total Miles: 0"

        If g_intCustomerID <= 0 Then
            MessageBox.Show("No customer selected.")
            Me.Close()
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            ' Only future flights (date-only comparison)
            Dim strSQL As String = "SELECT F.strFlightNumber, F.dtmFlightDate, F.dtmTimeofDeparture, F.dtmTimeOfLanding, " &
                                   "F.intMilesFlown, AF.strAirportCity AS FromCity, AT.strAirportCity AS ToCity " &
                                   "FROM TFlights F " &
                                   "JOIN TFlightPassengers FP ON F.intFlightID = FP.intFlightID " &
                                   "JOIN TAirports AF ON F.intFromAirportID = AF.intAirportID " &
                                   "JOIN TAirports AT ON F.intToAirportID = AT.intAirportID " &
                                   "WHERE FP.intPassengerID = " & g_intCustomerID & " " &
                                   "AND CAST(F.dtmFlightDate AS DATE) >= CAST(GETDATE() AS DATE) " &
                                   "ORDER BY F.dtmFlightDate"

            Dim cmd As New OleDbCommand(strSQL, m_conAdministrator)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            Dim totalMiles As Integer = 0

            While dr.Read()
                Dim s As String = dr("strFlightNumber").ToString() & " | " &
                                  Convert.ToDateTime(dr("dtmFlightDate")).ToShortDateString() & " | " &
                                  dr("FromCity").ToString() & " -> " & dr("ToCity").ToString() & " | Dep: " &
                                  dr("dtmTimeofDeparture").ToString() & " Arr: " &
                                  dr("dtmTimeOfLanding").ToString() & " | Miles: " &
                                  dr("intMilesFlown").ToString()
                lstFlights.Items.Add(s)
                totalMiles += CInt(dr("intMilesFlown"))
            End While

            dr.Close()
            lblTotalMiles.Text = "Total Miles (future): " & totalMiles.ToString()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show("Error loading flights: " & ex.Message)
        End Try
    End Sub

    '----------------------------------------------------------
    ' Exit button
    '----------------------------------------------------------
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    '----------------------------------------------------------
    ' Optional: select flight from list
    '----------------------------------------------------------
    Private Sub lstFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFlights.SelectedIndexChanged
        ' Add any logic if needed when a flight is selected
    End Sub

    '----------------------------------------------------------
    ' Call this after booking a flight to refresh the list immediately
    '----------------------------------------------------------
    Public Sub RefreshFlights()
        LoadFutureFlights()
    End Sub

End Class
