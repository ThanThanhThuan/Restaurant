Imports System.Data.SqlClient

Public Class Entity

    Public Function CompanyDetails()
        con = New SqlConnection(cs)
        con.Open()
        Dim cb As String = "select HotelName from hotel"
        cmd = New SqlCommand(cb)
        cmd.Connection = con
        Dim compName As String = cmd.ExecuteScalar().ToString()
        Return compName
    End Function
End Class
