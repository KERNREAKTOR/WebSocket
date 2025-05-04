Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Module ModelMethod
    Public Function GetModelStatus(ShortStatus As String) As String
        Select Case ShortStatus
            Case "virtualPrivate" : Return "Virtuell Privat"
            Case "public" : Return "Öffentlich"
            Case "private" : Return "Privat"
            Case "p2p" : Return "Cam 2 Cam"
            Case "off" : Return "Offline"
            Case "groupShow" : Return "Gruppen-Show"
            Case "idle" : Return "Bald Live"
            Case Else : Return "Unbekannt"
        End Select
    End Function
    Public Sub CheckStatus(UserJson As String)

        Dim StatusChanged As Boolean = False
        Dim UserInfoInfo As New UserInfo(UserJson)

        With UserInfoInfo.GetUserInfo

            Dim info As New StatusInfo(.Id)
            info.LoadStatusInfo()

            'Model Id festlegen
            Form1.modelId = .Id
            Form1.userName = .Username
            Form1.LPrivateRate.Text = $"Private: { .PrivateRate} TK / Min."
            Form1.LC2CRate.Text = $"C2C: { .P2pRate} TK / Min."

            'Form1.SetModelStatus(.status)

            'Form1.lStatus.Text = $"{Form1.userName} - {Form1.PrivateModelStatus}"

            'Status ändert sich
            If info.CurStatus <> .Status Then

                Dim StatusDuration As TimeSpan = DateTime.Now - info.StatusChangedAt
                Dim TotalMinutes As Integer = CInt(StatusDuration.TotalMinutes) + 1
                Dim TKIncome As Integer
                Dim UserName As String = info.CurStatus & info.StatusChangedAt.ToString("_yyyy_MM_dd_HH_mm")
                Dim UserId As Integer = CInt(info.StatusChangedAt.ToString("MMddHHmm"))

                Select Case info.CurStatus
                    Case "private"

                        TKIncome = TotalMinutes * .PrivateRate
                        Form1.AddTips($"{UserName}", UserId, TKIncome)

                    Case "p2p"
                        TKIncome = TotalMinutes * .P2pRate
                        Form1.AddTips($"{UserName}", UserId, TKIncome)

                End Select

                info.CurStatus = .Status
                info.StatusChangedAt = DateTime.Now
                FormatStatus($"{ .Username} ist { GetModelStatus(.Status)}")
                StatusChanged = True

            End If

            'Onlinestatus ändert sich
            If info.IsOnline <> .IsOnline Then
                info.IsOnline = .IsOnline
                info.OnlineChangedAt = DateTime.Now
                StatusChanged = True
                FormatStatus($"{ .username} hat sich {If(.IsOnline, "angemeldet", "abgemeldet")}")
            End If

            Form1.lStatus.BackColor = If(.isOnline, Color.Green, Color.Red)

            'Follower ausgeben
            If .FavoritedCount <> info.Follower Then
                Dim FollowerDiff As Integer = .FavoritedCount - info.Follower
                Form1.LFollower.Text = $"{ .FavoritedCount:N0} ({FollowerDiff}) Follower"
            Else
                Form1.LFollower.Text = $"{ .FavoritedCount:N0} Follower"
            End If

            info.Follower = .FavoritedCount

            If StatusChanged Then
                info.SaveStatusInfo(info)
            End If

        End With

    End Sub

End Module
