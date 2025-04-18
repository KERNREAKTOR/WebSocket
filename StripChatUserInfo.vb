Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class StripChatUserInfo

    Public Property IsLive As Boolean
    Public Property IsOnline As Boolean

    Public Property Id As Integer
    Public Property FavoritedCount As Integer
    Public Property SpyRate As Integer
    Public Property SpyMinimum As Integer
    Public Property PrivateRate As Integer
    Public Property PrivateMinDuration As Integer
    Public Property PrivateMinimum As Integer
    Public Property PrivateOfflineMinimum As Integer
    Public Property P2pRate As Integer
    Public Property P2pMinDuration As Integer
    Public Property P2pMinimum As Integer
    Public Property P2pOfflineMinimum As Integer
    Public Property P2pVoiceMinimum As Integer
    Public Property GroupRate As Integer
    Public Property TicketRate As Integer
    Public Property PublicRecordingsRate As Integer
    Public Property RatingPrivateUsers As Integer

    Public Property BroadcastServer As String
    Public Property RatingPrivate As String
    Public Property Status As String
    Public Property StatusChangedAt As String
    Public Property WentIdleAt As String
    Public Property PreviewUrlThumbBig As String
    Public Property AvatarUrlOriginal As String
    Public Property AvatarUrl As String
    Public Property Username As String
    Public Property Login As String
    Public Sub New(JsonString As String)


        Try

            Dim userJsonData As JObject = JsonConvert.DeserializeObject(Of JObject)(JsonString)

            IsLive = userJsonData("user")("isLive").ToObject(Of Boolean)
            IsOnline = userJsonData("user")("isOnline").ToObject(Of Boolean)


            Id = userJsonData("user")("id").ToObject(Of Int32)
            FavoritedCount = userJsonData("user")("favoritedCount").ToObject(Of Int32)

            SpyRate = userJsonData("user")("spyRate").ToObject(Of Int32)
            SpyMinimum = userJsonData("user")("spyMinimum").ToObject(Of Int32)

            PrivateRate = userJsonData("user")("privateRate").ToObject(Of Int32)
            PrivateMinDuration = userJsonData("user")("privateMinDuration").ToObject(Of Int32)
            PrivateMinimum = userJsonData("user")("privateMinimum").ToObject(Of Int32)
            PrivateOfflineMinimum = userJsonData("user")("privateOfflineMinimum").ToObject(Of Int32)

            P2pMinDuration = userJsonData("user")("p2pMinDuration").ToObject(Of Int32)
            P2pRate = userJsonData("user")("p2pRate").ToObject(Of Int32)
            P2pMinimum = userJsonData("user")("p2pMinimum").ToObject(Of Int32)
            P2pOfflineMinimum = userJsonData("user")("p2pOfflineMinimum").ToObject(Of Int32)
            P2pVoiceMinimum = userJsonData("user")("p2pVoiceMinimum").ToObject(Of Int32)

            GroupRate = userJsonData("user")("groupRate").ToObject(Of Int32)
            TicketRate = userJsonData("user")("ticketRate").ToObject(Of Int32)
            PublicRecordingsRate = userJsonData("user")("publicRecordingsRate").ToObject(Of Int32)
            RatingPrivateUsers = userJsonData("user")("ratingPrivateUsers").ToObject(Of Int32)

            BroadcastServer = userJsonData("user")("broadcastServer").ToObject(Of String)
            Status = userJsonData("user")("status").ToObject(Of String)
            RatingPrivate = userJsonData("user")("ratingPrivate").ToObject(Of String)
            StatusChangedAt = userJsonData("user")("statusChangedAt").ToObject(Of String)
            WentIdleAt = userJsonData("user")("wentIdleAt").ToObject(Of String)
            PreviewUrlThumbBig = userJsonData("user")("previewUrlThumbBig").ToObject(Of String)
            AvatarUrl = userJsonData("user")("avatarUrl").ToObject(Of String)
            AvatarUrlOriginal = userJsonData("user")("avatarUrlOriginal").ToObject(Of String)
            Username = userJsonData("user")("username").ToObject(Of String)
            Login = userJsonData("user")("login").ToObject(Of String)

        Catch ex As Exception

            FormatErrors($"Fehler: {ex.Message}")

        End Try

    End Sub

End Class
