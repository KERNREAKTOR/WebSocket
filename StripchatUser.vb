Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class StripchatUser
    Public Property CurrPosition As Integer
    Public Property CurrPoints As Integer
    Public Sub New(JsonString As String)
        Try
            Dim userJsonData As JObject = JsonConvert.DeserializeObject(Of JObject)(JsonString)

            CurrPosition = userJsonData("user")("currPosition").ToObject(Of Int32)
            CurrPoints = userJsonData("user")("currPoints").ToObject(Of Int32)
        Catch ex As Exception

        End Try




    End Sub
End Class
