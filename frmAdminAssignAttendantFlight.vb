Imports System.Data.OleDb

Public Class frmAdminAssignAttendantFlight

    Private Sub frmAdminAssignAttendantFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAttendants()
        LoadFutureFlights()
    End Sub

    Private Sub LoadAttendants()
        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub
            Dim cmd As New OleDbCommand("SELECT intAttendantID, strFirstName + ' ' + strLastName AS AttendantName FROM TAttendants", m_conAdministrator)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            Dim dt As New DataTable
            dt.Load(dr)
            cboAttendants.DisplayMember = "AttendantName"
            cboAttendants.ValueMember = "intAttendantID"
            cboAttendants.DataSource = dt
            dr.Close()
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadFutureFlights()
        cboFlights.Items.Clear()
        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub
            Dim strSQL As String = "SELECT F.intFlightID, F.strFlightNumber, F.dtmFlightDate, AF.strAirportCity as FromCity, AT.strAirportCity as ToCity " &
                                   "FROM TFlights F " &
                                   "JOIN TAirports AF ON F.intFromAirportID = AF.intAirportID " &
                                   "JOIN TAirports AT ON F.intToAirportID = AT.intAirportID " &
                                   "WHERE F.dtmFlightDate > GETDATE() ORDER BY F.dtmFlightDate"
            Dim cmd As New OleDbCommand(strSQL, m_conAdministrator)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            Dim dt As New DataTable
            dt.Load(dr)
            cboFlights.DisplayMember = "strFlightNumber"
            cboFlights.ValueMember = "intFlightID"
            cboFlights.DataSource = dt
            dr.Close()
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If cboAttendants.SelectedIndex = -1 Or cboFlights.SelectedIndex = -1 Then
            MessageBox.Show("Select an attendant and a flight first.")
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to assign this attendant to the flight?", "Confirm", MessageBoxButtons.YesNo) <> DialogResult.Yes Then Exit Sub

        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub
            ' Insert assignment
            Dim cmdGet As New OleDbCommand("SELECT MAX(intAttendantFlightID)+1 AS NextID FROM TAttendantFlights", m_conAdministrator)
            Dim drGet As OleDbDataReader = cmdGet.ExecuteReader()
            Dim nextID As Integer = 1
            If drGet.Read() AndAlso Not drGet.IsDBNull(0) Then nextID = CInt(drGet("NextID"))
            drGet.Close()

            Dim strInsert As String = "INSERT INTO TAttendantFlights (intAttendantFlightID, intAttendantID, intFlightID) VALUES (" &
                                      nextID & ", " & cboAttendants.SelectedValue & ", " & cboFlights.SelectedValue & ")"
            Dim cmdInsert As New OleDbCommand(strInsert, m_conAdministrator)
            Dim rows As Integer = cmdInsert.ExecuteNonQuery()
            If rows > 0 Then
                MessageBox.Show("Attendant assigned to flight.")
            Else
                MessageBox.Show("Assignment failed.")
            End If
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        Dim f As New frmAdminMain
        f.ShowDialog()
        Me.Close()
    End Sub
End Class