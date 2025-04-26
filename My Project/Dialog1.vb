Imports System.Net
Imports Newtonsoft.Json

Public Class Updater

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Public Shared Sub CheckForUpdate()
        Try
            Dim client As New WebClient()
            Dim jsonText As String = client.DownloadString("https://deinewebseite.de/update.json")

            ' JSON in die Klasse laden
            Dim updateInfo As UpdateInfo = JsonConvert.DeserializeObject(Of UpdateInfo)(jsonText)

            Dim localVersion As String = Application.ProductVersion

            If Version.Parse(updateInfo.version) > Version.Parse(localVersion) Then
                Dim message As String = $"Neue Version verfügbar: {updateInfo.version}" & vbCrLf &
                                        $"Änderungen: {updateInfo.changelog}" & vbCrLf &
                                        "Möchtest du jetzt aktualisieren?"

                If MessageBox.Show(message, "Update verfügbar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    Process.Start(updateInfo.downloadUrl)
                    Application.Exit()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Fehler beim Update-Check: {ex.Message}")
        End Try
    End Sub
    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
