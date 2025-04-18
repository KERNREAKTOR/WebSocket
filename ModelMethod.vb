Module ModelMethod
    Public Sub CheckStatus(StripChat As StripchatDespatcher)

        Dim StatusChanged As Boolean = False
        Dim info As New StatusInfo(StripChat.GetUserInformation.Id)
        info.LoadStatusInfo()

        'Staus ändert sich
        If info.CurStatus <> StripChat.GetUserInformation.Status Then

            info.CurStatus = StripChat.GetUserInformation.Status
            info.StatusChangedAt = DateTime.Now
            FormatStatus($"{StripChat.GetUserInformation.Username} ist {StripChat.GetUserInformation.Status}")
            StatusChanged = True

        End If

        'Onlinestatus ändert sich
        If info.IsOnline <> StripChat.GetUserInformation.IsOnline Then

            info.IsOnline = StripChat.GetUserInformation.IsOnline
            info.OnlineChangedAt = DateTime.Now


            If StripChat.GetUserInformation.IsOnline Then
                FormatStatus($"{StripChat.GetUserInformation.Username} ist Online")
            Else
                FormatStatus($"{StripChat.GetUserInformation.Username} ist Offline")
            End If

            StatusChanged = True

        End If

        If StatusChanged Then

            info.SaveStatusInfo(info)

        End If
    End Sub
End Module
