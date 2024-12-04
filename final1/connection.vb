Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class connection
    ' Private connection As New MySqlConnection("DATABASE=test3;SERVER=118.171.215.131;USERID=root;PASSWORD=1104558;SSLMODE=Disabled")
    'Private connection As New MySqlConnection("DATABASE=test3;SERVER=192.168.56.1;USERID=test;PASSWORD=123456;SSLMODE=Disabled")
    Private connection As New MySqlConnection("Server=erp0606.mysql.database.azure.com;UserID = s1104558;Password=P@ssw0rd;Database=ss;SslMode=Required;SslCa={path_to_CA_cert}")

    'Private connection As New MySqlConnection("Server=118.171.197.93;UserID = ww5211;Password=Aa1104558!;Database=test3;SslMode=Required;SslCa={path_to_CA_cert}")
    ReadOnly Property getConnection() As MySqlConnection
        Get
            Return connection
        End Get
    End Property

    Sub Openconnection()
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
    End Sub

    Sub Closeconnection()
        If connection.State = ConnectionState.Closed Then
            connection.Close()
        End If
    End Sub

    Public Function getdata(ByVal query As String, ByVal parameters() As MySqlParameter) As DataTable

        Dim command As New MySqlCommand(query, connection)
        If parameters Is Nothing Then
            command.Parameters.AddRange(parameters)
        End If

        Dim adapter As New MySqlDataAdapter()
        Dim table As New DataTable()
        adapter.SelectCommand = command
        adapter.Fill(table)

        Return table
    End Function

    Public Function setdata(ByVal query As String, ByVal parameters() As MySqlParameter) As Integer

        Dim command As New MySqlCommand(query, connection)
        If parameters Is Nothing Then
            command.Parameters.AddRange(parameters)
        End If

        Openconnection()
        Dim commandstate As Integer = command.ExecuteNonQuery
        Closeconnection()
        Return commandstate


    End Function
End Class


