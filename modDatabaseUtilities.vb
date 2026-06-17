' ********************************************************************************
' modDatabaseUtilities.vb
' ********************************************************************************
Option Explicit On

Public Module modDatabaseUtilities

    ' Connection object available throughout the app
    Public m_conAdministrator As OleDb.OleDbConnection

    ' SQL Server connection string - update database name here
    Private m_strDatabaseConnectionStringSQLServer As String = "Provider=SQLOLEDB;" &
                                                            "Server=(local);" &
                                                            "Database=dbFlyMe2theMoon;" &
                                                            "Integrated Security=SSPI;"

#Region "Open/Close Connection"

    ' ------------------------------------------------------------------------
    ' Name: OpenDatabaseConnectionSQLServer
    ' Abstract: Opens a connection to the SQL Server database.
    ' ------------------------------------------------------------------------
    Public Function OpenDatabaseConnectionSQLServer() As Boolean

        Dim blnResult As Boolean = False

        Try
            ' Open a connection to the database
            m_conAdministrator = New OleDb.OleDbConnection
            m_conAdministrator.ConnectionString = m_strDatabaseConnectionStringSQLServer
            m_conAdministrator.Open()

            ' Success
            blnResult = True

        Catch excError As Exception
            ' Display any error that occurs
            MessageBox.Show(excError.Message)
        End Try

        Return blnResult

    End Function

    ' ------------------------------------------------------------------------
    ' Name: CloseDatabaseConnection
    ' Abstract: Closes the database connection if open.
    ' ------------------------------------------------------------------------
    Public Function CloseDatabaseConnection() As Boolean

        Dim blnResult As Boolean = False

        Try
            If m_conAdministrator IsNot Nothing Then
                If m_conAdministrator.State <> ConnectionState.Closed Then
                    m_conAdministrator.Close()
                End If
                m_conAdministrator = Nothing
            End If
            blnResult = True

        Catch excError As Exception
            MessageBox.Show(excError.Message)
        End Try

        Return blnResult

    End Function

#End Region

End Module

