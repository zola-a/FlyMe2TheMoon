Imports System.Data.OleDb

Public Class frmCustomerPastFlights

    Private Sub frmCustomerPastFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPastFlights()
        LoadTotalMiles()
    End Sub

    Private Sub LoadPastFlights()
        lstFlights.Items.Clear()

        If g_intCustomerID <= 0 Then
            MessageBox.Show("No customer selected.")
            Me.Close()
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            ' Call stored procedure to get past flights
            Dim cmd As New OleDbCommand("usp_GetCustomerPastFlights", m_conAdministrator)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@PassengerID", g_intCustomerID)

            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            While dr.Read()
                Dim s As String = dr("strFlightNumber").ToString() & " | " & Convert.ToDateTime(dr("dtmFlightDate")).ToShortDateString() &
                                  " | " & dr("FromCity").ToString() & " -> " & dr("ToCity").ToString() &
                                  " | Dep: " & dr("dtmTimeofDeparture").ToString() & " Arr: " & dr("dtmTimeOfLanding").ToString() &
                                  " | Miles: " & dr("intMilesFlown").ToString()
                lstFlights.Items.Add(s)
            End While
            dr.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show("LoadPastFlights error: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadTotalMiles()
        lblTotalMiles.Text = "Total Miles: 0"

        If g_intCustomerID <= 0 Then Exit Sub

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            ' Call stored procedure to get total miles
            Dim cmd As New OleDbCommand("usp_GetCustomerTotalMiles", m_conAdministrator)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@PassengerID", g_intCustomerID)

            Dim totalMiles As Object = cmd.ExecuteScalar()
            If Not IsDBNull(totalMiles) Then
                lblTotalMiles.Text = "Total Miles: " & totalMiles.ToString()
            End If

            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("LoadTotalMiles error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub lstFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFlights.SelectedIndexChanged

    End Sub
End Class