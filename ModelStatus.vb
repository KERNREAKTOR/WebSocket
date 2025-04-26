Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ModelStatus
    ' Eigenschaften für die wichtigsten Werte
    Public Property Id As Integer
    Public Property FavoritedCount As Integer
    Public Property Username As String
    Public Property Status As String
    Public Property Age As Integer
    Public Property BroadcastServer As String
    Public Property Country As String
    Public Property AvatarUrl As String
    Public Property IsOnline As Boolean
    Public Property IsLive As Boolean
    Public Property HairColor As String
    Public Property EyeColor As String
    Public Property WentIdleAt As String
    Public Property Languages As List(Of String)
    Public Property Interests As List(Of String)

    ' Methode zum Parsen der JSON-Datei
    Public Shared Function FromJson(jsonString As String) As ModelStatus
        Try
            ' JSON in JObject umwandeln
            Dim jsonObject As JObject = JObject.Parse(jsonString)
            Dim modelData As JObject = jsonObject("push")("pub")("data")("model")

            ' Objekt mit Daten füllen
            Dim model As New ModelStatus With {
                .BroadcastServer = modelData("broadcastServer").ToString(),
                .IsLive = modelData("isLive"),
                .Id = modelData("id"),
                .FavoritedCount = modelData("favoritedCount"),
                .Username = modelData("username").ToString(),
                .WentIdleAt = modelData("wentIdleAt").ToString(),
                .Status = modelData("status").ToString(),
                .Age = modelData("age"),
                .Country = modelData("country").ToString(),
                .AvatarUrl = modelData("avatarUrl").ToString(),
                .IsOnline = modelData("isOnline"),
                .HairColor = modelData("hairColor").ToString(),
                .EyeColor = modelData("eyeColor").ToString(),
                .Languages = modelData("languages").ToObject(Of List(Of String))(),
                .Interests = modelData("interests").ToObject(Of List(Of String))()
            }

            Return model
        Catch ex As Exception
            MessageBox.Show("Fehler beim Verarbeiten der JSON-Daten: " & ex.Message)
            Return Nothing
        End Try
    End Function
End Class
