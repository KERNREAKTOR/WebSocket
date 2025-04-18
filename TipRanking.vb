Imports System.IO
Imports Newtonsoft.Json

Public Class TipRanking
    Private TipData As New Dictionary(Of Integer, (Username As String, TotalTips As Integer))

    ' Methode zum Hinzufügen eines Trinkgelds
    Public Sub AddTip(userId As Integer, username As String, amount As Integer)
        If TipData.ContainsKey(userId) Then
            TipData(userId) = (username, TipData(userId).TotalTips + amount)
        Else
            TipData.Add(userId, (username, amount))
        End If
    End Sub

    ' Methode zum Abrufen des Rankings
    Public Function GetRanking() As List(Of (Username As String, TotalTips As Integer))
        Return TipData.Values.OrderByDescending(Function(t) t.TotalTips).ToList()
    End Function

    ' Datei-Pfad generieren (z. B. "tips_2025-03-30.json")
    Private Function GetFilePath() As String

        Dim folderPath As String = Path.Combine(Application.StartupPath, Form1.modelId)

        ' Überprüfen, ob der Ordner existiert, und erstellen, falls nicht
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        Dim filePath As String = Path.Combine(folderPath, $"tips_{Date.Today:yyyy-MM-dd}.json")

        Return filePath

    End Function

    ' Ranking als JSON speichern
    Public Sub SaveToFile()
        Dim jsonDict As New Dictionary(Of Integer, TipUserData)
        For Each kvp In TipData
            jsonDict.Add(kvp.Key, New TipUserData With {
                .Username = kvp.Value.Username,
                .TotalTips = kvp.Value.TotalTips
            })
        Next

        Dim json As String = JsonConvert.SerializeObject(jsonDict, Formatting.Indented)
        File.WriteAllText(GetFilePath(), json)
    End Sub

    ' Ranking aus JSON laden
    Public Sub LoadFromFile()
        Dim path As String = GetFilePath()
        If File.Exists(path) Then
            Dim json As String = File.ReadAllText(path)
            Dim jsonDict = JsonConvert.DeserializeObject(Of Dictionary(Of Integer, TipUserData))(json)
            TipData.Clear()
            For Each kvp In jsonDict
                TipData.Add(kvp.Key, (kvp.Value.Username, kvp.Value.TotalTips))
            Next
        End If
    End Sub

    ' Hilfsklasse für JSON
    Private Class TipUserData
        Public Property Username As String
        Public Property TotalTips As Integer
    End Class
End Class
