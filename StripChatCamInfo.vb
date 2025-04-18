Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class StripChatCamInfo
    Public Property GetGoalInfo As GoalInfo
    Public Sub New(JsonString As String)

        Dim JsonData As JObject = JsonConvert.DeserializeObject(Of JObject)(JsonString)
        GetGoalInfo = New GoalInfo(JsonData)

    End Sub

End Class