Imports Newtonsoft.Json

Public Class Subscription
    <JsonProperty("subscribe")>
    Public Property Subscribe As SubscribeDetails

    <JsonProperty("id")>
    Public Property Id As Integer
End Class

Public Class SubscribeDetails
    <JsonProperty("channel")>
    Public Property Channel As String
End Class

