Imports System.Data.OleDb

Public Class frmCustomerUpdate

    '----------------------------------------------------------
    ' Form Load
    '----------------------------------------------------------
    Private Sub frmCustomerUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If g_intCustomerID <= 0 Then
            MessageBox.Show("No customer selected.")
            Me.Close()
            Exit Sub
        End If

        LoadStates()
        LoadCustomerInfo()
    End Sub

    '----------------------------------------------------------
    ' Load States Combo Box
    '----------------------------------------------------------
    Private Sub LoadStates()
        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Dim cmd As New OleDbCommand("uspGetStates", m_conAdministrator)
            cmd.CommandType = CommandType.StoredProcedure

            Dim dr As OleDbDataReader = cmd.ExecuteReader()
            Dim dt As New DataTable
            dt.Load(dr)
            dr.Close()

            cboStates.DataSource = dt
            cboStates.DisplayMember = "strState"
            cboStates.ValueMember = "intStateID"

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show("Error loading states: " & ex.Message)
        End Try
    End Sub

    '----------------------------------------------------------
    ' Load Customer Info
    '----------------------------------------------------------
    Private Sub LoadCustomerInfo()
        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Dim cmd As New OleDbCommand("usp_GetCustomerByID", m_conAdministrator)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@CustomerID", OleDbType.Integer).Value = g_intCustomerID

            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            If dr.Read() Then
                txtFirstName.Text = dr("FirstName").ToString()
                txtLastName.Text = dr("LastName").ToString()
                txtAddress.Text = dr("Address").ToString()
                txtCity.Text = dr("City").ToString()
                txtZip.Text = dr("Zip").ToString()
                txtPhoneNumber.Text = dr("PhoneNumber").ToString()
                txtEmail.Text = dr("Email").ToString()

                ' --- New Fields ---
                txtPassengerUsername.Text = dr("PassengerUsername").ToString()
                txtPassengerPassword.Text = dr("PassengerPassword").ToString()
                If Not IsDBNull(dr("PassengerDateOfBirth")) Then
                    dtpDateOfBirth.Value = Convert.ToDateTime(dr("PassengerDateOfBirth"))
                End If

                ' Must be AFTER states are loaded
                cboStates.SelectedValue = CInt(dr("StateID"))
            End If

            dr.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show("Error loading customer info: " & ex.Message)
        End Try
    End Sub

    '----------------------------------------------------------
    ' Submit Update
    '----------------------------------------------------------
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        ' Basic validation
        If txtFirstName.Text.Trim = "" Or
           txtLastName.Text.Trim = "" Or
           txtAddress.Text.Trim = "" Or
           txtCity.Text.Trim = "" Or
           txtZip.Text.Trim = "" Or
           txtPhoneNumber.Text.Trim = "" Or
           txtEmail.Text.Trim = "" Or
           txtPassengerUsername.Text.Trim = "" Or
           txtPassengerPassword.Text.Trim = "" Then

            MessageBox.Show("Please fill in all required fields.")
            Exit Sub
        End If

        If Not txtEmail.Text.Contains("@") Then
            MessageBox.Show("Please enter a valid email address.")
            Exit Sub
        End If

        ' Perform the update
        Try
            If Not OpenDatabaseConnectionSQLServer() Then Exit Sub

            Dim cmd As New OleDbCommand("uspUpdatePassenger", m_conAdministrator)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@PassengerID", OleDbType.Integer).Value = g_intCustomerID
            cmd.Parameters.Add("@FirstName", OleDbType.VarChar).Value = txtFirstName.Text.Trim
            cmd.Parameters.Add("@LastName", OleDbType.VarChar).Value = txtLastName.Text.Trim
            cmd.Parameters.Add("@Address", OleDbType.VarChar).Value = txtAddress.Text.Trim
            cmd.Parameters.Add("@City", OleDbType.VarChar).Value = txtCity.Text.Trim
            cmd.Parameters.Add("@StateID", OleDbType.Integer).Value = cboStates.SelectedValue
            cmd.Parameters.Add("@Zip", OleDbType.VarChar).Value = txtZip.Text.Trim
            cmd.Parameters.Add("@PhoneNumber", OleDbType.VarChar).Value = txtPhoneNumber.Text.Trim
            cmd.Parameters.Add("@Email", OleDbType.VarChar).Value = txtEmail.Text.Trim
            cmd.Parameters.Add("@PassengerUsername", OleDbType.VarChar).Value = txtPassengerUsername.Text.Trim
            cmd.Parameters.Add("@PassengerPassword", OleDbType.VarChar).Value = txtPassengerPassword.Text.Trim
            cmd.Parameters.Add("@PassengerDateOfBirth", OleDbType.Date).Value = dtpDateOfBirth.Value.Date


            Dim rows As Integer = cmd.ExecuteNonQuery()

            If rows = 1 Then
                MessageBox.Show("Profile updated.")
            Else
                MessageBox.Show("Update failed.")
            End If

            CloseDatabaseConnection()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error updating customer: " & ex.Message)
        End Try

    End Sub

    '----------------------------------------------------------
    ' Exit Button
    '----------------------------------------------------------
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class