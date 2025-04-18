Imports System.Net.Http

Public Class DownloadManager
    Public Function DownloadJsonAsync(url As String) As String

        Dim jsonString As String = String.Empty
        Try
            Using client As New HttpClient()
                jsonString = client.GetStringAsync(url).Result
            End Using

        Catch ex As Exception
            FormatErrors(ex.Message + " - url: " & url)
        End Try

        Return jsonString

    End Function
End Class
