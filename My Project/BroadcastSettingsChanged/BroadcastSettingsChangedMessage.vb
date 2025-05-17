
Imports Newtonsoft.Json
'{"push":{"channel":"broadcastSettingsChanged@101209241","pub":{"data":{"additionalData":{},"bFrames":0,"bitrate":3982444,"broadcastType":"webrtc","externalObs":{"blockedTill":null,"errors":[],"fps":0,"warnings":[]},"forcedBroadcastPlayer":null,"forcedBroadcastType":null,"fps":30,"fpsHistory":[30,30],"gop":60,"hasBFramesAlert":false,"height":720,"isBadStream":false,"isMobile":false,"isMuted":false,"isSourcePreset":true,"keyInterval":2,"lockedServer":true,"originOnly":false,"presets":{"default":["720p","480p","240p","160p"],"testing":{"160p":"_160p","160p_blurred":"_160p_blurred","240p":"_240p","480p":"_480p","720p":"_720p"},"vr":[]},"protocol":"TCP","videoCodec":"h264","width":1280},"offset":1}}}

'Public Class BroadcastSettingsChangedMessage
'    Public Property push As PushData
'End Class

Public Class BroadcastSettingsChangedMessage
    Public Property pub As PubData
End Class

Public Class PubData
    Public Property data As BroadcastData
End Class

Public Class BroadcastData
    Public Property additionalData As Dictionary(Of String, Object)
    Public Property bFrames As Integer
    Public Property bitrate As Integer
    Public Property broadcastType As String
    Public Property externalObs As ExternalObs
    Public Property forcedBroadcastPlayer As Object
    Public Property forcedBroadcastType As Object
    Public Property fps As Integer
    Public Property fpsHistory As List(Of Integer)
    Public Property gop As Integer
    Public Property hasBFramesAlert As Boolean
    Public Property height As Integer
    Public Property isBadStream As Boolean
    Public Property isMobile As Boolean
    Public Property isMuted As Boolean
    Public Property isSourcePreset As Boolean
    Public Property keyInterval As Integer
    Public Property lockedServer As Boolean
    Public Property originOnly As Boolean
    Public Property presets As Presets
    Public Property protocol As String
    Public Property videoCodec As String
    Public Property width As Integer
End Class

Public Class ExternalObs
    Public Property blockedTill As Object
    Public Property errors As List(Of String)
    Public Property fps As Integer
    Public Property warnings As List(Of String)
End Class

Public Class Presets
    <JsonProperty("default")>
    Public Property DefaultPresets As List(Of String)

    Public Property testing As Dictionary(Of String, String)
    Public Property vr As List(Of Object)
End Class

