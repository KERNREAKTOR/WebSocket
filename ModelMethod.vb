﻿Imports System.IO
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

            'Form1.SetModelStatus(.status)

            'Form1.lStatus.Text = $"{Form1.userName} - {Form1.PrivateModelStatus}"

            'Status ändert sich
            If info.CurStatus <> .Status Then
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

            If StatusChanged Then
                info.SaveStatusInfo(info)
            End If

            'Follower ausgeben
            Form1.LFollower.Text = $"{ .FavoritedCount:N0} Follower"

        End With

    End Sub

End Module
