Imports System.Runtime.InteropServices.JavaScript.JSType
Imports Newtonsoft.Json.Linq

Module HandleJsonHelpher
    Public Sub HandleChatMessage(item As JProperty)

        Dim messageType As String = item.Value("pub")("data")("message")("type").ToString()

        Select Case messageType

            Case "text"
                Dim username As String = item.Value("pub")("data")("message")("userData")("username").ToString()
                Dim body As String = item.Value("pub")("data")("message")("details")("body").ToString()
                FormatMessages($"{username}: {body}")

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

                Form1.AddUserUserBoughtContentTips(item.Value)

            Case "clearChat"
                '{"push":{"channel":"newChatMessage@13971979","pub":{"data":{"additionalData":{},"message":{"additionalData":{"isKing":false,"isKnight":false,"isStudioAdmin":false,"isStudioModerator":false},"cacheId":"67f3e6c9720be","createdAt":"2025-04-07T14:52:57Z","details":{"fanClubNumberMonthsOfSubscribed":0,"fanClubTier":null},"id":1828755946807486,"modelId":13971979,"type":"clearChat","userData":{"hasAdminBadge":false,"hasVrDevice":false,"id":13971979,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":false,"isModel":true,"isOnline":true,"isRegular":false,"isStudio":false,"isSupport":false,"isUltimate":false,"userRanking":null,"username":"Alirawrz"}}},"offset":1105}}}

            Case "privateTip"

                '{"push":{"channel":"newChatMessage@57255263","pub":{"data":{"additionalData":{},"message":{"additionalData":{"isKing":false,"isKnight":false,"isStudioAdmin":false,"isStudioModerator":false},"cacheId":"67f2ced94fd04","createdAt":"2025-04-06T18:58:33Z","details":{"amount":11,"body":"make your fingers wet and put it in my mouth","fanClubNumberMonthsOfSubscribed":22,"fanClubTier":"tier1","isAnonymous":false,"source":"","tipData":{"tipperKey":"UZhYgZPpKXZC7KO72UKUBg=="}},"id":1828680801516804,"modelId":57255263,"type":"privateTip","userData":{"hasAdminBadge":false,"hasVrDevice":false,"id":41152083,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":false,"isModel":false,"isOnline":false,"isRegular":false,"isStudio":false,"isSupport":false,"isUltimate":true,"userRanking":{"isEx":false,"league":"diamond","level":55},"username":"Maylo5978"}}},"offset":748}}}
                Form1.AddTips(item.Value)

            Case "tip"
                '{"push":{"channel":"newChatMessage@172531274","pub":{"data":{"additionalData":{},"message":{"additionalData":{"isKing":false,"isKnight":false,"isStudioAdmin":false,"isStudioModerator":false},"cacheId":"67e7ccb1db869","createdAt":"2025-03-29T10:34:25Z","details":{"amount":5,"body":"","fanClubNumberMonthsOfSubscribed":0,"fanClubTier":null,"isAnonymous":false,"source":"fullScreen","tipData":{"tipperKey":"GY2HcU8UTSqdCNHDbfAVew=="}},"id":1827924309031017,"modelId":172531274,"type":"tip","userData":{"hasAdminBadge":false,"hasVrDevice":false,"id":16765833,"isAdmin":false,"isBlocked":false,"isDeleted":false,"isExGreen":false,"isGreen":true,"isModel":false,"isOnline":true,"isRegular":false,"isStudio":false,"isSupport":false,"isUltimate":false,"userRanking":{"isEx":false,"league":"gold","level":54},"username":"merlin8989"}}},"offset":161}}}
                Form1.AddTips(item.Value)

            Case Else

                FormatErrorsString($"Unbekannter Typ: {messageType}")
                FormatErrorsString($"{item.Value}")

        End Select
    End Sub
End Module
