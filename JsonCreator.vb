Imports Newtonsoft.Json

Public Class JsonCreator
    Private IntModelId As Integer
    Private IntWsId As Integer
    Sub New(ModelId As Integer, wsId As Integer)
        ' Constructor logic here
        IntModelId = ModelId
        IntWsId = wsId
    End Sub

    ReadOnly Property Connect As String
        Get
            IntWsId += 1

            Dim jsonObj = New With {
            .connect = New With {
                .token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiItNTk1NiIsImluZm8iOnsiaXNHdWVzdCI6dHJ1ZSwidXNlcklkIjotNTk1Nn19.wiw0qLpgg3_peIr6grrWU6Zjgu58wugE5fZHBiyX9_A",
                .name = "js"
            },
            .id = 1
        }

            Return JsonConvert.SerializeObject(jsonObj)
        End Get
    End Property
    ReadOnly Property UnsubcribeModelStatusChanged As String
        Get
            IntWsId += 1

            Dim jsonObj = New With {
            .unsubscribe = New With {
                .channel = $"modelStatusChanged@{IntModelId}"
            },
            .id = IntWsId
        }

            Return JsonConvert.SerializeObject(jsonObj)
        End Get
    End Property
    ReadOnly Property SubscribeModelStatusChanged As String
        Get
            IntWsId += 1
            Dim jsonObj = New With {
            .subscribe = New With {
                .channel = $"modelStatusChanged@{IntModelId}"
            },
            .id = IntWsId
        }
            Return JsonConvert.SerializeObject(jsonObj)
        End Get
    End Property

    ReadOnly Property UnsubcribeUserUpdated As String
        Get
            IntWsId += 1

            Dim jsonObj = New With {
            .unsubscribe = New With {
                .channel = $"userUpdated@{IntModelId}"
            },
            .id = IntWsId
        }

            Return JsonConvert.SerializeObject(jsonObj)
        End Get
    End Property

    ReadOnly Property SubscribeUserUpdated As String
        Get
            IntWsId += 1
            Dim jsonObj = New With {
            .subscribe = New With {
                .channel = $"userUpdated@{IntModelId}"
            },
            .id = IntWsId
        }
            Return JsonConvert.SerializeObject(jsonObj)
        End Get
    End Property

    ReadOnly Property UnsubcribeNewChatMessage As String
        Get
            IntWsId += 1

            Dim jsonObj = New With {
            .unsubscribe = New With {
                .channel = $"newChatMessage@{IntModelId}"
            },
            .id = IntWsId
        }

            Return JsonConvert.SerializeObject(jsonObj)
        End Get
    End Property

    ReadOnly Property SubscribeNewChatMessage As String
        Get
            IntWsId += 1
            Dim jsonObj = New With {
            .subscribe = New With {
                .channel = $"newChatMessage@{IntModelId}"
            },
            .id = IntWsId
        }
            Return JsonConvert.SerializeObject(jsonObj)
        End Get
    End Property

    ReadOnly Property UnsubcribeGoalChanged As String
        Get
            IntWsId += 1

            Dim jsonObj = New With {
            .unsubscribe = New With {
                .channel = $"goalChanged@{IntModelId}"
            },
            .id = IntWsId
        }

            Return JsonConvert.SerializeObject(jsonObj)
        End Get
    End Property
    ReadOnly Property SubscribeGoalChanged As String
        Get
            IntWsId += 1
            Dim jsonObj = New With {
            .subscribe = New With {
                .channel = $"goalChanged@{IntModelId}"
            },
            .id = IntWsId
        }
            Return JsonConvert.SerializeObject(jsonObj)
        End Get
    End Property

    Public Property WebSocketId As Integer
        Get
            Return IntWsId
        End Get
        Set(value As Integer)
            IntWsId = value
        End Set
    End Property
End Class
