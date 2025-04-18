Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class GoalInfo
    Public Property Description As String
    Public Property Goal As Integer
    Public Property Spent As Integer
    Public Property Left As Integer
    Public Property IsEnabled As Boolean
    Public Sub New(JsonData As JObject)

        ' Dim JsonData As JObject = JsonConvert.DeserializeObject(Of JObject)(JsonString)
        'JsonData("user")("isLive").ToObject(Of Boolean)()

        If JsonData("goal").HasValues Then

            Description = JsonData("goal")("description").ToObject(Of String)
            Goal = JsonData("goal")("goal").ToObject(Of Integer)
            Spent = JsonData("goal")("spent").ToObject(Of Integer)
            Left = JsonData("goal")("left").ToObject(Of Integer)
            IsEnabled = JsonData("goal")("isEnabled").ToObject(Of Boolean)

        Else

            Description = ""
            Goal = 0
            Spent = 0
            Left = 0
            IsEnabled = False

        End If

    End Sub
End Class
