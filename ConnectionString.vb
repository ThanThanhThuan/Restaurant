Imports System.IO
Public Module ConnectionString
    Dim st As String
    Public Function ReadCS() As String
        Return Configuration.ConfigurationManager.ConnectionStrings("restaurantConnectionx").ToString()
    End Function
    Public cs As String = ReadCS()
End Module
