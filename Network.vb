Imports System.Net.Http

Module Network
    Public Async Function IsInternetAvailableAsync() As Task(Of Boolean)
        Try
            Using client As New HttpClient()
                Using response = Await client.GetAsync("https://www.google.com")
                    Return response.IsSuccessStatusCode
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

End Module
