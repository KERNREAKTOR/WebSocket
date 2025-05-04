Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class StripchatDespatcher

    Public Property GetUserInformation As StripChatUserUserInfo
    Public Property GetCameraInformation As StripChatCamInfo
    Public Property GetUser As StripchatUser
    Public Sub New(JsonString As String)
        If String.IsNullOrEmpty(JsonString) Then
            Throw New ArgumentException("JsonString cannot be null or empty", NameOf(JsonString))
        End If

        Dim jsonCamObject As JObject = JsonConvert.DeserializeObject(Of JObject)(JsonString)

        GetUserInformation = New StripChatUserUserInfo(jsonCamObject("user").ToString())
        GetCameraInformation = New StripChatCamInfo(jsonCamObject("cam").ToString())
        GetUser = New StripchatUser(jsonCamObject.ToString)

    End Sub

End Class
