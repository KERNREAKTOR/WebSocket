Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO

Module JSONReader

    Public Function ParseMultipleJsonObjects(jsonLine As String) As List(Of JObject)
        Dim objects As New List(Of JObject)()

        Using reader As New JsonTextReader(New StringReader(jsonLine))
            reader.SupportMultipleContent = True

            Dim serializer As New JsonSerializer()

            While reader.Read()
                If reader.TokenType = JsonToken.StartObject Then
                    Dim obj = serializer.Deserialize(Of JObject)(reader)
                    objects.Add(obj)
                End If
            End While
        End Using

        Return objects
    End Function

End Module
