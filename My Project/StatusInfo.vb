Imports Newtonsoft.Json
Imports System.IO

Public Class StatusInfo
    Public Property CurStatus As String
    Public Property IsOnline As Boolean
    Public Property Follower As Integer
    Public Property CurrPosition As Integer
    Public Property CurrPoints As Integer
    Public Property StatusChangedAt As DateTime
    Public Property OnlineChangedAt As DateTime

    Private PrvModelId As Integer

    Private configPath As String

    Sub New(ModelId As Integer)

        PrvModelId = ModelId
        configPath = $"{PrvModelId}_status_config.json"
    End Sub

    Sub LoadStatusInfo()

        If File.Exists(configPath) Then

            Dim json As String = File.ReadAllText(configPath)
            Dim info As StatusInfo = JsonConvert.DeserializeObject(Of StatusInfo)(json)

            With info
                CurStatus = .CurStatus
                IsOnline = .IsOnline
                StatusChangedAt = .StatusChangedAt
                OnlineChangedAt = .OnlineChangedAt
                Follower = .Follower
                CurrPosition = .CurrPosition
                CurrPoints = .CurrPoints
            End With

        Else
            CurStatus = "off"
            StatusChangedAt = DateTime.Now
            OnlineChangedAt = DateTime.Now
            IsOnline = False
            Follower = 0
            CurrPosition = 0
            CurrPoints = 0
        End If

    End Sub

    Sub SaveStatusInfo(info As StatusInfo)

        Dim json As String = JsonConvert.SerializeObject(info, Formatting.Indented)
        File.WriteAllText(configPath, json)

    End Sub

End Class
