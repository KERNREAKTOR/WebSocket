Imports System.IO
Imports System.Net.WebSockets
Imports System.Reflection.Emit
Imports System.Text
Imports System.Threading
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1

    Public userName As String = "xiaoyu---sss"

    Private wsClient As ClientWebSocket
    Private intToken As Int32
    Public modelId As Int32
    Private wsId As Int32
    Private ranking As TipRanking
    Public TipsCounts As Int32
    Public ErrorCounts As Int32
    Public StatusCounts As Int32
    Public MessagesCounts As Int32
    Private PrivateModelStatus As String

    Private serverUri As New Uri("wss://websocket-centrifugo-v5.sc-apps.com/connection/websocket") ' Ersetze mit der echten URL

    ' Liste zum Speichern der eindeutigen IDs
    Private uniqueIds As New HashSet(Of Long)

    Private Function GetUsername(userId As Int32) As String
        Dim url As String = $"https://de.stripchat.com/api/front/users/{userId}"

        Dim manager As New DownloadManager()

        Dim jsonStringCam As String = manager.DownloadJsonAsync(url)
        Dim jsonCamObject As JObject = JsonConvert.DeserializeObject(Of JObject)(jsonStringCam)
        Return jsonCamObject("user")("name")

    End Function
    Private Sub ProcessMessage(jsonString As String)
        Dim type As String
        Dim errorId = 0
        Try
            'Dim parsedJsonObject As JObject = JObject.Parse(jsonString)
            Dim jsonObject = ParseMultipleJsonObjects(jsonString)

            For Each parsedJsonObject In jsonObject

                If parsedJsonObject.HasValues Then
                    'Dim index As Integer = 0

                    For Each item As JProperty In parsedJsonObject.Properties

                        Select Case item.Name
                            Case "unsubscribe"
                            Case "subscribe"
                                errorId = 100


                            Case "id"
                                errorId = 101

                                wsId = item.Value

                            Case "connect"
                                errorId = 102
                                Dim client As String = item.Value("client")
                                Dim version As String = item.Value("version")
                                Dim ping As Int32 = item.Value("ping")
                                Dim pong As Boolean = item.Value("pong")
                                lbMessages.Items.Add($"Verbunden mit dem Client: {client}")
                                lbMessages.Items.Add($"Version: {version}")
                                lbMessages.Items.Add($"Ping: {ping}")
                                FormatMessages($"Pong: {pong}")

                            Case "push"

                                Select Case item.Value("channel")

                                '########################
                                '#  modelStatusChanged  #
                                '########################

                                    Case "modelStatusChanged@" & modelId
                                        errorId = 102
                                        ' JSON in Objekt umwandeln
                                        Dim model As ModelStatus = ModelStatus.FromJson(jsonString)

                                        '##################
                                        '# Status abrufen #
                                        '##################
                                        Dim currentStatus As String = "online" ' Beispielwert
                                        Dim info As New StatusInfo(modelId)
                                        info.LoadStatusInfo()
                                        Dim statusChanged As Boolean = False

                                        'Staus ändert sich
                                        If info.CurStatus <> model.Status Then

                                            info.CurStatus = model.Status
                                            info.StatusChangedAt = DateTime.Now

                                            FormatStatus($"{model.Username} ist {model.Status}")

                                            statusChanged = True

                                        End If

                                        'Onlinestatus ändert sich
                                        If info.IsOnline <> model.IsOnline Then

                                            info.IsOnline = model.IsOnline
                                            info.OnlineChangedAt = DateTime.Now

                                            If model.IsOnline Then
                                                FormatStatus($"{model.Username} ist Online")
                                            Else
                                                FormatStatus($"{model.Username} ist Offline")
                                            End If

                                            statusChanged = True

                                        End If

                                        If statusChanged Then

                                            info.SaveStatusInfo(info)

                                        End If


                                        ' Falls erfolgreich geladen, in ListBox anzeigen
                                        If model IsNot Nothing Then

                                            PrivateModelStatus = model.Status
                                            Me.Text = $"{model.Username} - {model.Status}"
                                            lStatus.Text = $"{model.Username} - {model.Status}"
                                            Dim Status As String = model.Status
                                            SetModelStatus(Status)

                                            If model.IsOnline Then
                                                lStatus.BackColor = Color.Green
                                            Else
                                                lStatus.BackColor = Color.Red
                                            End If

                                        End If

                                '################
                                '#  ModelEvent  #
                                '################

                                    Case "newModelEvent"
                                        errorId = 103
                                        '{"push":{"channel":"newModelEvent","pub":{"data":{"accessMode":"free","additionalData":{},"modelIds":[169158238,186249823,188831572]},"offset":7}}}
                                        Dim modelIds As JArray = item.Value("pub")("data")("modelIds")
                                        Dim accesMode As String = item.Value("pub")("data")("accessMode")


                                        For Each modelId As Integer In modelIds

                                            Dim userName As String

                                            If modelId = 0 Then

                                                userName = "***"

                                            Else

                                                userName = GetUsername(modelId)

                                            End If

                                            FormatMessages($"---> User: {userName} betritt den Raum ({accesMode})")

                                        Next

                                '#################
                                '#  goalChanged  #
                                '#################
                                    Case "goalChanged@" & modelId
                                        errorId = 104
                                        '{"push":{"channel":"goalChanged@165681464","pub":{"data":{"additionalData":{},"goal":{"description":"Massage of my boobs with oil!","goal":444,"isEnabled":true,"left":173,"spent":271}},"offset":43}}}
                                        Dim left As Int32 = item.Value("pub")("data")("goal")("left")
                                        Dim spent As Int32 = item.Value("pub")("data")("goal")("spent")
                                        Dim goal As Int32 = item.Value("pub")("data")("goal")("goal")
                                        Dim isEnabled As Boolean = item.Value("pub")("data")("goal")("isEnabled")
                                        Dim description As String = item.Value("pub")("data")("goal")("description")

                                        If isEnabled Then

                                            If spent > goal Then
                                                spent = goal
                                            End If

                                            PBGoal.Visible = True
                                            lGoal.Text = $"{left} Token übrig bis -> {description}"
                                            PBGoal.Maximum = goal
                                            PBGoal.Value = spent

                                        Else

                                            PBGoal.Visible = False
                                            lGoal.Text = $"Kein Ziel"
                                            PBGoal.Maximum = 100
                                            PBGoal.Value = 0

                                        End If





                                '####################
                                '#  newChatMessage  #
                                '####################
                                    Case "newChatMessage@" & modelId
                                        errorId = 105
                                        type = parsedJsonObject("push")("pub")("data")("message")("type").ToString()

                                        Select Case type
                                            Case "text"
                                                '{"push":{"channel":"newChatMessage@172531274","pub":{"data":{"additionalData":{},"message":{"additionalData":{"isKing":false,"isKnight":false,"isStudioAdmin":false,"isStudioModerator":false},"cacheId":"67e7c9836866a","createdAt":"2025-03-29T10:20:51Z","details":{"body":"Wie groß bist du Baby","fanClubNumberMonthsOfSubscribed":0,"fanClubTier":null},"id":1827923455018602,"modelId":172531274,"type":"text","userData":{"hasAdminBadge":false,"hasVrDevice":false,"id":189794742,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":false,"isModel":false,"isOnline":true,"isRegular":false,"isStudio":false,"isSupport":false,"isUltimate":true,"userRanking":{"isEx":false,"league":"gold","level":42},"username":"FiratcanSecici"}}},"offset":104}}}
                                                errorId = 106
                                                Dim user As String = parsedJsonObject("push")("pub")("data")("message")("userData")("username").ToString()
                                                Dim message As String = parsedJsonObject("push")("pub")("data")("message")("details")("body").ToString()
                                                FormatMessages($"{user}: {parsedJsonObject("push")("pub")("data")("message")("details")("body")}")

                                            Case "userSubscribedOnFanClub"
                                        '{"push":{"channel":"newChatMessage@165681464","pub":{"data":{"additionalData":{},"message":{"additionalData":{"isKing":false,"isKnight":false,"isStudioAdmin":false,"isStudioModerator":false},"cacheId":"67e823fe27bf0","createdAt":"2025-03-29T16:46:54Z","details":{"fanClubNumberMonthsOfSubscribed":1,"fanClubSubscription":{"createdAt":"2025-03-29T16:46:54Z","expireAt":"2025-04-28T17:46:49Z","id":1521042,"isRecurrent":true,"numberMonthsOfSubscribed":1,"periodMonths":1,"status":"active","tier":"tier1","user":{"avatarUrlThumb":"","id":44985251,"isExGreen":false,"isGold":false,"isGreen":true,"isRegular":false,"isUltimate":false,"userRanking":{"isEx":false,"league":"silver","level":21},"username":"kossy8796"}},"fanClubTier":"tier1"},"id":1827947742919664,"modelId":165681464,"type":"userSubscribedOnFanClub","userData":{"hasAdminBadge":false,"hasVrDevice":false,"id":44985251,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":true,"isModel":false,"isOnline":true,"isRegular":false,"isStudio":false,"isSupport":false,"isUltimate":false,"userRanking":{"isEx":false,"league":"silver","level":21},"username":"kossy8796"}}},"offset":693}}}

                                            Case "newKing"
                                         '{"push":{"channel":"newChatMessage@165681464","pub":{"data":{"additionalData":{},"message":{"additionalData":{"isKing":true,"isKnight":false,"isStudioAdmin":false,"isStudioModerator":false},"cacheId":"67e81d72d34d4","createdAt":"2025-03-29T16:18:58Z","details":{"fanClubNumberMonthsOfSubscribed":0,"fanClubTier":null,"kingId":8062509},"id":1827945986208980,"modelId":165681464,"type":"newKing","userData":{"hasAdminBadge":false,"hasVrDevice":false,"id":8062509,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":true,"isModel":false,"isOnline":true,"isRegular":false,"isStudio":false,"isSupport":false,"isUltimate":false,"userRanking":{"isEx":false,"league":"gold","level":35},"username":"EKzudemO"}}},"offset":531}}}

                                            Case "userMuted"
                                        '{"push":{"channel":"newChatMessage@165681464","pub":{"data":{"additionalData":{},"message":{"additionalData":{"banned":{"hasAdminBadge":false,"hasVrDevice":false,"id":109404962,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":false,"isModel":false,"isOnline":true,"isRegular":true,"isStudio":false,"isSupport":false,"isUltimate":false,"userRanking":{"isEx":false,"league":"grey","level":9},"username":"Joghnbfh57"}},"cacheId":"67e81347733e4","createdAt":"2025-03-29T15:35:35Z","details":{"bannedId":109404962,"fanClubNumberMonthsOfSubscribed":0,"fanClubTier":null},"id":1827943256372196,"modelId":165681464,"type":"userMuted","userData":{"hasAdminBadge":false,"hasVrDevice":false,"id":165681464,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":false,"isModel":true,"isOnline":true,"isRegular":false,"isStudio":false,"isSupport":false,"isUltimate":false,"userRanking":null,"username":"ArdithGoodrich"}}},"offset":118}}}

                                            Case "goal"
                                        '{"push":{"channel":"newChatMessage@172531274","pub":{"data":{"additionalData":{},"message":{"additionalData":{"isKing":false,"isKnight":false,"isStudioAdmin":false,"isStudioModerator":false},"cacheId":"67e7d209ec262","createdAt":"2025-03-29T10:57:13Z","details":{"body":"Spank w Whip 10x \u0026 2 Videos","fanClubNumberMonthsOfSubscribed":0,"fanClubTier":null,"goal":444,"isEnabled":true},"id":1827925743551074,"modelId":172531274,"type":"goal","userData":{"hasAdminBadge":false,"hasVrDevice":false,"id":172531274,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":false,"isModel":true,"isOnline":true,"isRegular":false,"isStudio":false,"isSupport":false,"isUltimate":false,"userRanking":null,"username":"AlyssaHottv_"}}},"offset":3}}}

                                            Case "repeatGoal"

                                            Case "thresholdGoal"
                                        '{"push":{"channel":"newChatMessage@172531274","pub":{"data":{"additionalData":{},"message":{"additionalData":{"isKing":false,"isKnight":false,"isStudioAdmin":false,"isStudioModerator":false},"cacheId":"67e7c9ccbaaf9","createdAt":"2025-03-29T10:22:04Z","details":{"body":"BUY ME A FUCKMACHiNE 😈 :wanker:","fanClubNumberMonthsOfSubscribed":0,"fanClubTier":null,"goal":4973},"id":1827923531901689,"modelId":172531274,"type":"thresholdGoal","userData":{"hasAdminBadge":false,"hasVrDevice":false,"id":172531274,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":false,"isModel":true,"isOnline":true,"isRegular":false,"isStudio":false,"isSupport":false,"isUltimate":false,"userRanking":null,"username":"AlyssaHottv_"}}},"offset":109}}}

                                            Case "lovense"
                                        '{"push":{"channel":"newChatMessage@172531274","pub":{"data":{"additionalData":{},"message":{"additionalData":{"isKing":false,"isKnight":false,"isStudioAdmin":false,"isStudioModerator":false},"cacheId":"67e7c8da71b82","createdAt":"2025-03-29T10:18:02Z","details":{"fanClubNumberMonthsOfSubscribed":0,"fanClubTier":null,"lovenseDetails":{"additionalData":{"isKing":false,"isKnight":false,"isStudioAdmin":false,"isStudioModerator":false},"clientUserInfo":{"hasAdminBadge":false,"hasVrDevice":false,"id":172976933,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":true,"isGreen":false,"isModel":false,"isOnline":true,"isRegular":true,"isStudio":false,"isSupport":false,"isUltimate":false,"userRanking":{"isEx":true,"league":"silver","level":20},"username":"TestoMesto1672"},"detail":{"amount":180,"name":"TestoMesto1672","power":"high","time":71},"status":"","text":"","type":"tip"}},"id":1827923277847426,"modelId":172531274,"type":"lovense","userData":{"hasAdminBadge":false,"hasVrDevice":false,"id":172531274,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":false,"isModel":true,"isOnline":true,"isRegular":false,"isStudio":false,"isSupport":false,"isUltimate":false,"userRanking":null,"username":"AlyssaHottv_"}}},"offset":90}}}

                                            Case "userBoughtContent"
                                                AddUserUserBoughtContentTips(parsedJsonObject)

                                            Case "clearChat"
                                                '{"push":{"channel":"newChatMessage@13971979","pub":{"data":{"additionalData":{},"message":{"additionalData":{"isKing":false,"isKnight":false,"isStudioAdmin":false,"isStudioModerator":false},"cacheId":"67f3e6c9720be","createdAt":"2025-04-07T14:52:57Z","details":{"fanClubNumberMonthsOfSubscribed":0,"fanClubTier":null},"id":1828755946807486,"modelId":13971979,"type":"clearChat","userData":{"hasAdminBadge":false,"hasVrDevice":false,"id":13971979,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":false,"isModel":true,"isOnline":true,"isRegular":false,"isStudio":false,"isSupport":false,"isUltimate":false,"userRanking":null,"username":"Alirawrz"}}},"offset":1105}}}

                                            Case "privateTip"
                                                errorId = 107
                                                '{"push":{"channel":"newChatMessage@57255263","pub":{"data":{"additionalData":{},"message":{"additionalData":{"isKing":false,"isKnight":false,"isStudioAdmin":false,"isStudioModerator":false},"cacheId":"67f2ced94fd04","createdAt":"2025-04-06T18:58:33Z","details":{"amount":11,"body":"make your fingers wet and put it in my mouth","fanClubNumberMonthsOfSubscribed":22,"fanClubTier":"tier1","isAnonymous":false,"source":"","tipData":{"tipperKey":"UZhYgZPpKXZC7KO72UKUBg=="}},"id":1828680801516804,"modelId":57255263,"type":"privateTip","userData":{"hasAdminBadge":false,"hasVrDevice":false,"id":41152083,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":false,"isModel":false,"isOnline":false,"isRegular":false,"isStudio":false,"isSupport":false,"isUltimate":true,"userRanking":{"isEx":false,"league":"diamond","level":55},"username":"Maylo5978"}}},"offset":748}}}
                                                AddTips(parsedJsonObject)

                                            Case "tip"
                                                '{"push":{"channel":"newChatMessage@172531274","pub":{"data":{"additionalData":{},"message":{"additionalData":{"isKing":false,"isKnight":false,"isStudioAdmin":false,"isStudioModerator":false},"cacheId":"67e7ccb1db869","createdAt":"2025-03-29T10:34:25Z","details":{"amount":5,"body":"","fanClubNumberMonthsOfSubscribed":0,"fanClubTier":null,"isAnonymous":false,"source":"fullScreen","tipData":{"tipperKey":"GY2HcU8UTSqdCNHDbfAVew=="}},"id":1827924309031017,"modelId":172531274,"type":"tip","userData":{"hasAdminBadge":false,"hasVrDevice":false,"id":16765833,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":true,"isModel":false,"isOnline":true,"isRegular":false,"isStudio":false,"isSupport":false,"isUltimate":false,"userRanking":{"isEx":false,"league":"gold","level":54},"username":"merlin8989"}}},"offset":161}}}

                                                errorId = 108
                                                AddTips(parsedJsonObject)

                                            Case Else

                                                FormatErrors($"Unbekannter Typ: {type}")

                                        End Select

                                    Case Else

                                        FormatErrors($"Unbekannter Parameter ---> Name: {item.Name}, Value: {item.Value}")

                                End Select

                            Case Else

                                FormatErrors($"Unbekannte Parameter ---> Name: {item.Name}, Value: {item.Value}")

                        End Select

                    Next

                End If
            Next



            If jsonString = "{}" Then

                SendMessage("{}")

            End If

            If Not intToken = 0 Then

                lIncome.Text = $"{intToken} Token ({Math.Round(intToken * 0.05, 2):F2} $)"

            End If

        Catch ex As Exception

            ' Fehlerbehandlung
            FormatErrors($"Fehler beim Verarbeiten der Nachricht: {ex.Message} Fehler-Id: {errorId}")
            FormatErrors(jsonString)

        End Try
    End Sub

    Private Sub AddTips(json As JObject)
        Dim user As String = json("push")("pub")("data")("message")("userData")("username").ToString()
        Dim userId As Int32 = json("push")("pub")("data")("message")("userData")("id")
        Dim RankNumber As Int16 = 1
        Dim TokenAmount As Int32 = json("push")("pub")("data")("message")("details")("amount").ToObject(Of Int32)

        If userId = 0 Then
            user = "***"

        End If

        intToken = 0

        FormatTips($"{user} hat {TokenAmount} Token gespendet")


        ranking.AddTip(userId, user, TokenAmount)

        ' Ranking abrufen und in ListBox anzeigen
        lbIncome.Items.Clear()
        For Each entry In ranking.GetRanking()

            lbIncome.Items.Add($"{RankNumber}. {entry.TotalTips} Tokens - {entry.Username}")
            intToken += entry.TotalTips
            RankNumber += 1

        Next

        ranking.SaveToFile()
    End Sub
    Private Sub AddUserUserBoughtContentTips(json As JObject)
        Dim user As String = json("push")("pub")("data")("message")("userData")("username").ToString()
        Dim userId As Int32 = json("push")("pub")("data")("message")("userData")("id")
        Dim TokenAmount As Int32 = json("push")("pub")("data")("message")("details")("content")("cost").ToObject(Of Int32)
        Dim ContentType As String = json("push")("pub")("data")("message")("details")("content")("type").ToString
        Dim RankNumber As Int16 = 1

        If userId = 0 Then
            user = "***"

        End If

        intToken = 0

        user = user & "_" & ContentType

        ranking.AddTip(userId + 1, user, TokenAmount)

        FormatTips($"{user} hat {TokenAmount} Token für ein {ContentType} ausgegeben")


        ' Ranking abrufen und in ListBox anzeigen
        lbIncome.Items.Clear()

        For Each entry In ranking.GetRanking()

            lbIncome.Items.Add($"{RankNumber}. {entry.TotalTips} Tokens - {entry.Username}")
            intToken += entry.TotalTips
            RankNumber += 1

        Next

        ranking.SaveToFile()

    End Sub

    Private Sub SetModelStatus(Status As String)

        Select Case Status

            Case "virtualPrivate"

                ' Wenn der Status "virtualPrivate" ist, setzen Sie das Bild auf "Virtuell Privat"
                With PicBoxStatus
                    .Visible = True

                    Dim imageData As Byte() = My.Resources.disabled_visible_48dp_434343

                    Using ms As New MemoryStream(imageData)
                        .Image = Image.FromStream(ms)
                    End Using

                End With

                PrivateModelStatus = "Virtuell Privat"

            Case "public"

                ' Wenn der Status "public" ist, setzen Sie das Bild auf "Öffentlich"
                With PicBoxStatus

                    .Visible = False

                End With

                PrivateModelStatus = "Öffentlich"

            Case "private"

                ' Wenn der Status "p2p" ist, setzen Sie das Bild auf "Privat"
                With PicBoxStatus
                    .Visible = True

                    Dim imageData As Byte() = My.Resources._private

                    Using ms As New MemoryStream(imageData)
                        .Image = Image.FromStream(ms)
                    End Using

                End With

                PrivateModelStatus = "Privat"

            Case "p2p"

                ' Wenn der Status "p2p" ist, setzen Sie das Bild auf "Cam 2 Cam"
                With PicBoxStatus
                    .Visible = True

                    Dim imageData As Byte() = My.Resources.c2c

                    Using ms As New MemoryStream(imageData)
                        .Image = Image.FromStream(ms)
                    End Using

                End With

                PrivateModelStatus = "Cam 2 Cam"

            Case "off"

                ' Wenn der Status "off" ist, setzen Sie das Bild auf "Offline"
                With PicBoxStatus
                    .Visible = False
                End With

                PrivateModelStatus = "Offline"

            Case "groupShow"

                ' Wenn der Status "groupShow" ist, setzen Sie das Bild auf "Gruppen-Show"
                With PicBoxStatus
                    .Visible = True

                    Dim imageData As Byte() = My.Resources.groups_48dp_434343

                    Using ms As New MemoryStream(imageData)
                        .Image = Image.FromStream(ms)
                    End Using

                End With

                PrivateModelStatus = "Gruppen-Show"

            Case "idle"

                ' Wenn der Status "idle" ist, setzen Sie das Bild auf "Bald Live"
                With PicBoxStatus
                    .Visible = True
                    Dim imageData As Byte() = My.Resources.idle
                    Using ms As New MemoryStream(imageData)
                        .Image = Image.FromStream(ms)
                    End Using
                End With

                PrivateModelStatus = "Bald Live"

            Case Else

                With PicBoxStatus
                    .Visible = False
                End With
                ' Wenn der Status nicht erkannt wird, setzen Sie ihn auf "Unbekannt"
                PrivateModelStatus = "Unbekannt"

        End Select

    End Sub

    Private Async Function ListenForMessages() As Task
        Dim buffer(8192) As Byte ' Buffergröße erhöht

        While wsClient.State = WebSocketState.Open
            Try
                Dim receivedData As New ArraySegment(Of Byte)(buffer)
                Dim result As WebSocketReceiveResult = Await wsClient.ReceiveAsync(receivedData, CancellationToken.None)

                If result.MessageType = WebSocketMessageType.Close Then

                    'Dim serverUri As New Uri("wss://websocket-centrifugo-v5.sc-apps.com/connection/websocket") ' Ersetze mit der echten URL
                    'lbErrors.Items.Add("Verbindung geschlossen!")
                    'Await wsClient.CloseAsync(WebSocketCloseStatus.NormalClosure, "Schließen", CancellationToken.None)
                    'wsClient.Dispose()
                    'wsClient = New ClientWebSocket()
                    'Await wsClient.ConnectAsync(serverUri, CancellationToken.None)
                    'InitializeWebSocketConnection()

                    'Dim serverUri As New Uri("wss://websocket-centrifugo-v5.sc-apps.com/connection/websocket") ' Ersetze mit der echten URL

                    'Await wsClient.ConnectAsync(serverUri, CancellationToken.None)

                    InitializeWebSocketConnection()

                    Await ListenForMessages()

                End If

                Dim message As String = Encoding.UTF8.GetString(buffer, 0, result.Count)

                ProcessMessage(message)

            Catch ex As Exception

                FormatErrors("Fehler beim Empfangen: " & ex.Message)

            End Try
        End While
    End Function

    Private Async Sub SendMessage(message As String)
        If wsClient IsNot Nothing AndAlso wsClient.State = WebSocketState.Open Then

            If Not String.IsNullOrEmpty(message) Then

                Dim sendData As Byte() = Encoding.UTF8.GetBytes(message)
                Dim buffer As New ArraySegment(Of Byte)(sendData)

                Await wsClient.SendAsync(buffer, WebSocketMessageType.Text, True, CancellationToken.None)

            End If

        Else
            wsClient = New ClientWebSocket()



            Await wsClient.ConnectAsync(serverUri, CancellationToken.None)

            FormatErrors("WebSocket ist nicht verbunden!")

        End If
    End Sub
    Private Async Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        intToken = 0
        ranking = New TipRanking()

        Try
            Dim manager As New DownloadManager()
            If Not My.Settings.CurModelName = "" Then
                userName = My.Settings.CurModelName
            End If

            Dim urlCam As String = $"https://de.stripchat.com/api/front/v2/models/username/{userName}/cam"
            Dim jsonStringCam As String = manager.DownloadJsonAsync(urlCam)
            Dim Stripchat As New StripchatDespatcher(jsonStringCam)

            CheckOnline(Stripchat)
            UpdateGoalStatus(Stripchat)

            modelId = Stripchat.GetUserInformation.Id

            ranking.LoadFromFile()

            Dim ImgLoader As New WebPImageLoader()

            ImgLoader.LoadWebPImageAsync(Stripchat.GetUserInformation.PreviewUrlThumbBig, PicBoxAvatar)

            CheckStatus(Stripchat)

            Me.Text = $"Modelname: {userName} - Modelid: {modelId} - {PrivateModelStatus}"

            Dim RankNumber As Int32 = 1

            For Each entry In ranking.GetRanking()

                lbIncome.Items.Add($"{RankNumber}. {entry.TotalTips} Tokens - {entry.Username}")
                RankNumber += 1
                intToken += entry.TotalTips

            Next

            If Not intToken = 0 Then

                lIncome.Text = $"{intToken} Token ({Math.Round(intToken * 0.05, 2):F2} $)"

            End If
            Timer1.Enabled = True

            SetModelStatus(Stripchat.GetUserInformation.Status)
            lStatus.Text = $"{userName} - {PrivateModelStatus}"
            wsClient = New ClientWebSocket()

            'Dim serverUri As New Uri("wss://websocket-centrifugo-v5.sc-apps.com/connection/websocket") ' Ersetze mit der echten URL

            Await wsClient.ConnectAsync(serverUri, CancellationToken.None)

            InitializeWebSocketConnection()

            Await ListenForMessages()

        Catch ex As Exception

            FormatErrors(ex.Message)

        End Try
    End Sub

    Private Sub UpdateGoalStatus(Stripchat As StripchatDespatcher)
        If Stripchat.GetCameraInformation.GetGoalInfo.IsEnabled Then

            lGoal.Text = $"{Stripchat.GetCameraInformation.GetGoalInfo.Left} Token übrig bis -> {Stripchat.GetCameraInformation.GetGoalInfo.Description}"
            PBGoal.Maximum = Stripchat.GetCameraInformation.GetGoalInfo.Goal
            PBGoal.Value = Stripchat.GetCameraInformation.GetGoalInfo.Spent
            PBGoal.Visible = True

        Else

            lGoal.Text = "Kein Ziel"
            PBGoal.Visible = False

        End If
    End Sub

    Private Sub CheckOnline(Stripchat As StripchatDespatcher)
        If Stripchat.GetUserInformation.IsOnline Then

            lStatus.BackColor = Color.Green

        Else

            lStatus.BackColor = Color.Red

        End If
    End Sub

    Private Sub InitializeWebSocketConnection()

        'SendMessage("{""connect"":{""token"":""eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiItNTk1NiIsImluZm8iOnsiaXNHdWVzdCI6dHJ1ZSwidXNlcklkIjotNTk1Nn19.wiw0qLpgg3_peIr6grrWU6Zjgu58wugE5fZHBiyX9_A"",""name"":""js""},""id"":1}")
        Dim jsonCr As New JsonCreator(modelId, 1)
        SendMessage(jsonCr.Connect)
        SendMessage(jsonCr.SubscribeNewChatMessage)
        SendMessage(jsonCr.SubscribeGoalChanged)
        SendMessage(jsonCr.SubscribeModelStatusChanged)
        wsId = 4

    End Sub

    Private Sub Tabbi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tabbi.SelectedIndexChanged

        Select Case Tabbi.SelectedTab.TabIndex

            Case 0

                TPMessages.Text = $"Nachrichten"
                MessagesCounts = lbMessages.Items.Count

            Case 1

                TPErrors.Text = $"Fehler"
                ErrorCounts = lbErrors.Items.Count

            Case 2

                TPTips.Text = $"Trinkgelder"
                TipsCounts = LBTips.Items.Count

            Case 3

                TPModelStatus.Text = $"Modelstatus"
                StatusCounts = LBModelStatus.Items.Count

        End Select

    End Sub

    Private Sub lbErrors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbErrors.SelectedIndexChanged

        If lbErrors.SelectedItem IsNot Nothing Then
            Clipboard.SetText(lbErrors.SelectedItem.ToString())
        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        If AddModel.ShowDialog() = DialogResult.OK Then
            Dim SelectedModel As String = AddModel.LBModeNames.Items(AddModel.LBModeNames.SelectedIndex)
            Dim manager As New DownloadManager()
            Dim urlCam As String = $"https://de.stripchat.com/api/front/v2/models/username/{SelectedModel}/cam"
            Dim jsonStringCam As String = manager.DownloadJsonAsync(urlCam)
            Dim Stripchat As New StripchatDespatcher(jsonStringCam)

            Dim jsonCr As New JsonCreator(modelId, wsId)
            SendMessage(jsonCr.UnsubcribeNewChatMessage)
            SendMessage(jsonCr.UnsubcribeGoalChanged)
            SendMessage(jsonCr.UnsubcribeModelStatusChanged)
            wsId = wsId + 3

            modelId = Stripchat.GetUserInformation.Id
            jsonCr = New JsonCreator(modelId, wsId)
            SendMessage(jsonCr.SubscribeNewChatMessage)
            SendMessage(jsonCr.SubscribeGoalChanged)
            SendMessage(jsonCr.SubscribeModelStatusChanged)

            My.Settings.CurModelName = SelectedModel
            My.Settings.Save()

            CheckStatus(Stripchat)

            SetModelStatus(Stripchat.GetUserInformation.Status)

            If Stripchat.GetUserInformation.IsOnline Then

                lStatus.BackColor = Color.Green

            Else

                lStatus.BackColor = Color.Red

            End If


            If Stripchat.GetCameraInformation.GetGoalInfo.IsEnabled Then

                lGoal.Text = $"{Stripchat.GetCameraInformation.GetGoalInfo.Left} Token übrig bis -> {Stripchat.GetCameraInformation.GetGoalInfo.Description}"
                PBGoal.Maximum = Stripchat.GetCameraInformation.GetGoalInfo.Goal
                PBGoal.Value = Stripchat.GetCameraInformation.GetGoalInfo.Spent
                PBGoal.Visible = True

            Else

                lGoal.Text = "Kein Ziel"
                PBGoal.Visible = False

            End If

            modelId = Stripchat.GetUserInformation.Id
            ranking = New TipRanking()

            ranking.LoadFromFile()

            Dim ImgLoader As New WebPImageLoader()

            ImgLoader.LoadWebPImageAsync(Stripchat.GetUserInformation.PreviewUrlThumbBig, PicBoxAvatar)

            Me.Text = $"Modelname: {userName} - Modelid: {modelId} - {PrivateModelStatus}"

            Dim RankNumber As Int32 = 1

            For Each entry In ranking.GetRanking()

                lbIncome.Items.Add($"{RankNumber}. {entry.TotalTips} Tokens - {entry.Username}")
                RankNumber += 1
                intToken += entry.TotalTips

            Next

            If Not intToken = 0 Then

                lIncome.Text = $"{intToken} Token ({Math.Round(intToken * 0.05, 2):F2} $)"

            End If

            SetModelStatus(Stripchat.GetUserInformation.Status)
            lStatus.Text = $"{userName} - {PrivateModelStatus}"

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim info As New StatusInfo(modelId)
        info.LoadStatusInfo()

        Dim StatusDuration As TimeSpan = DateTime.Now - info.StatusChangedAt
        Dim onlineDuration As TimeSpan = DateTime.Now - info.OnlineChangedAt

        LCurStatus.Text = $"{StatusDuration:hh\:mm\:ss}"

        If info.IsOnline Then

            LOnline.Text = $"Online seit {onlineDuration:hh\:mm\:ss}"

        Else

            LOnline.Text = $"Offline seit {onlineDuration:hh\:mm\:ss}"

        End If

    End Sub

    Private Sub PicBoxStatus_Click(sender As Object, e As EventArgs) Handles PicBoxStatus.Click

    End Sub
End Class
