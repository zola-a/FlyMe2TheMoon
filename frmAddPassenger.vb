Imports System.Data.OleDb

Public Class frmAddPassenger
    Private Sub frmAddPassenger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load states into cboStates
        Try
            If Not OpenDatabaseConnectionSQLServer() Then
                MessageBox.Show("DB connection error")
                Me.Close()
                Return
            End If

            Dim sql As String = "SELECT intStateID, strState FROM TStates"
            Dim cmd As New OleDbCommand(sql, m_conAdministrator)
            Dim rdr = cmd.ExecuteReader()
            Dim dt As New DataTable
            dt.Load(rdr)
            cboStates.ValueMember = "intStateID"
            cboStates.DisplayMember = "strState"
            cboStates.DataSource = dt
            rdr.Close()
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show("Load states error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Validate required fields
        If txtFirstName.Text.Trim = "" Or txtLastName.Text.Trim = "" Or txtAddress.Text.Trim = "" Or txtCity.Text.Trim = "" Or txtZip.Text.Trim = "" Or txtPhoneNumber.Text.Trim = "" Or txtEmail.Text.Trim = "" Or txtUsername.Text.Trim = "" Or txtPassword.Text.Trim = "" Then
            MessageBox.Show("Please fill in all required fields.")
            Exit Sub
        End If

        If Not txtEmail.Text.Contains("@") Then
            MessageBox.Show("Please enter a valid email address.")
            Exit Sub
        End If

        Try
            If Not OpenDatabaseConnectionSQLServer() Then
                MessageBox.Show("DB connection error")
                Exit Sub
            End If

            ' Get next PassengerID
            Dim nextID As Integer = 1
            Dim cmdPK As New OleDbCommand("SELECT MAX(intPassengerID) + 1 AS NextID FROM TPassengers", m_conAdministrator)
            Dim rdr = cmdPK.ExecuteReader()
            If rdr.Read() AndAlso Not IsDBNull(rdr("NextID")) Then nextID = CInt(rdr("NextID"))
            rdr.Close()

            ' Insert new passenger with username, password, DOB
            Dim sqlInsert As String = "INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strPassengerUsername, strPassengerPassword, dtmPassengerDateOfBirth) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
            Using cmdIns As New OleDbCommand(sqlInsert, m_conAdministrator)
                cmdIns.Parameters.AddWithValue("?", nextID)
                cmdIns.Parameters.AddWithValue("?", txtFirstName.Text.Trim)
                cmdIns.Parameters.AddWithValue("?", txtLastName.Text.Trim)
                cmdIns.Parameters.AddWithValue("?", txtAddress.Text.Trim)
                cmdIns.Parameters.AddWithValue("?", txtCity.Text.Trim)
                cmdIns.Parameters.AddWithValue("?", CInt(cboStates.SelectedValue))
                cmdIns.Parameters.AddWithValue("?", txtZip.Text.Trim)
                cmdIns.Parameters.AddWithValue("?", txtPhoneNumber.Text.Trim)
                cmdIns.Parameters.AddWithValue("?", txtEmail.Text.Trim)
                cmdIns.Parameters.AddWithValue("?", txtUsername.Text.Trim)
                cmdIns.Parameters.AddWithValue("?", txtPassword.Text.Trim)
                cmdIns.Parameters.AddWithValue("?", dtpDateOfBirth.Value.Date)

                Dim rows = cmdIns.ExecuteNonQuery()
                If rows > 0 Then
                    MessageBox.Show("Passenger added successfully.")

                    ' Store global variables for immediate login
                    g_intCustomerID = nextID
                    g_strUserType = "Customer"
                Else
                    MessageBox.Show("Insert failed.")
                End If
            End Using

            CloseDatabaseConnection()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Add error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Hide()
        Dim f As New frmAdminMain
        f.ShowDialog()
        Me.Close()
    End Sub

End Class