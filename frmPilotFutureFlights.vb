Imports System.Data.OleDb

Public Class frmPilotFutureFlights
    Private Sub frmPilotFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFutureFlights()
    End Sub

    Private Sub LoadFutureFlights()
        lstFlights.Items.Clear()
        lblTotalMiles.Text = "Total Miles: 0"

        If g_intPilotID <= 0 Then
            MessageBox.Show("No pilot selected.")
            Me.Close()
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Dim strSQL As String = "SELECT F.strFlightNumber, F.dtmFlightDate, F.dtmTimeofDeparture, F.dtmTimeOfLanding, F.intMilesFlown, AF.strAirportCity AS FromCity, AT.strAirportCity AS ToCity " &
                                   "FROM TFlights F " &
                                   "JOIN TPilotFlights PF ON F.intFlightID = PF.intFlightID " &
                                   "JOIN TAirports AF ON F.intFromAirportID = AF.intAirportID " &
                                   "JOIN TAirports AT ON F.intToAirportID = AT.intAirportID " &
                                   "WHERE PF.intPilotID = " & g_intPilotID & " AND F.dtmFlightDate >= GETDATE() " &
                                   "ORDER BY F.dtmFlightDate"

            Dim cmd As New OleDbCommand(strSQL, m_conAdministrator)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            Dim totalMiles As Integer = 0
            While dr.Read()
                Dim s As String = dr("strFlightNumber").ToString() & " | " & Convert.ToDateTime(dr("dtmFlightDate")).ToShortDateString() &
                                  " | " & dr("FromCity").ToString() & " -> " & dr("ToCity").ToString() &
                                  " | Dep: " & dr("dtmTimeofDeparture").ToString() & " Arr: " & dr("dtmTimeOfLanding").ToString() &
                                  " | Miles: " & dr("intMilesFlown").ToString()
                lstFlights.Items.Add(s)
                totalMiles += CInt(dr("intMilesFlown"))
            End While
            dr.Close()
            lblTotalMiles.Text = "Total Miles (future): " & totalMiles
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub lstFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFlights.SelectedIndexChanged

    End Sub

    Private Sub lblTotalMiles_Click(sender As Object, e As EventArgs) Handles lblTotalMiles.Click

    End Sub
End Class
