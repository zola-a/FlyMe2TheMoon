Imports System.Data.OleDb

Public Class frmStatistics

    Private Sub frmStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' ------------------------------------------------
            ' Use your project's working connection function
            ' ------------------------------------------------
            If Not OpenDatabaseConnectionSQLServer() Then
                MessageBox.Show("Database connection failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' ------------------------------------------------
            ' Total Customers
            ' ------------------------------------------------
            Using cmd As New OleDbCommand("usp_GetTotalCustomers", m_conAdministrator)
                cmd.CommandType = CommandType.StoredProcedure

                Dim result = cmd.ExecuteScalar()
                lblTotalCustomers.Text = If(result IsNot Nothing, result.ToString(), "0")
            End Using

            ' ------------------------------------------------
            ' Total Flights
            ' ------------------------------------------------
            Using cmd As New OleDbCommand("usp_GetTotalFlights", m_conAdministrator)
                cmd.CommandType = CommandType.StoredProcedure

                Dim result = cmd.ExecuteScalar()
                lblTotalFlights.Text = If(result IsNot Nothing, result.ToString(), "0")
            End Using

            ' ------------------------------------------------
            ' Average Miles
            ' ------------------------------------------------
            Using cmd As New OleDbCommand("usp_GetAverageMiles", m_conAdministrator)
                cmd.CommandType = CommandType.StoredProcedure

                Dim result = cmd.ExecuteScalar()

                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    lblAverageMiles.Text = Math.Round(CDec(result), 2).ToString()
                Else
                    lblAverageMiles.Text = "0"
                End If
            End Using

            ' ------------------------------------------------
            ' Pilot Total Miles
            ' ------------------------------------------------
            lstPilotMiles.Items.Clear()

            Using cmd As New OleDbCommand("usp_GetPilotTotalMiles", m_conAdministrator)
                cmd.CommandType = CommandType.StoredProcedure

                Dim dr As OleDbDataReader = cmd.ExecuteReader()

                While dr.Read()
                    Dim name As String = dr("PilotName").ToString()
                    Dim miles As Integer = If(IsDBNull(dr("TotalMiles")), 0, CInt(dr("TotalMiles")))
                    lstPilotMiles.Items.Add(name & " - " & miles & " miles")
                End While

                dr.Close()
            End Using

            ' ------------------------------------------------
            ' Attendant Total Miles
            ' ------------------------------------------------
            lstAttendantMiles.Items.Clear()

            Using cmd As New OleDbCommand("usp_GetAttendantTotalMiles", m_conAdministrator)
                cmd.CommandType = CommandType.StoredProcedure

                Dim dr As OleDbDataReader = cmd.ExecuteReader()

                While dr.Read()
                    Dim name As String = dr("AttendantName").ToString()
                    Dim miles As Integer = If(IsDBNull(dr("TotalMiles")), 0, CInt(dr("TotalMiles")))
                    lstAttendantMiles.Items.Add(name & " - " & miles & " miles")
                End While

                dr.Close()
            End Using

            ' ------------------------------------------------
            ' Close the shared connection
            ' ------------------------------------------------
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show("Error loading statistics: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CloseDatabaseConnection()
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        frmAdminMain.Show()
    End Sub

    Private Sub lstPilotMiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPilotMiles.SelectedIndexChanged

    End Sub
End Class
