Imports System.Net
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
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
    Public Shared Function CheckForUpdate() As UpdateInfo
        Dim updateInfo As UpdateInfo = Nothing
        Try
            Dim manager As New DownloadManager()


            Dim jsonText As String = manager.DownloadJsonAsync("https://raw.githubusercontent.com/KERNREAKTOR/WebSocket/master/Resources/update.json")
            'Dim jsonText As String = manager.DownloadJsonAsync("https://github.com/KERNREAKTOR/WebSocket/blob/4262a5042ed57e3e340aba1e0738c4b0776703cb/Resources/update.json")

            ' JSON in die Klasse laden
            updateInfo = JsonConvert.DeserializeObject(Of UpdateInfo)(jsonText)

            'If updateInfo Is Nothing Then
            '    MessageBox.Show("Update-Informationen konnten nicht geladen werden.")
            '    Return updateInfo
            'Else
            '    Dim localVersion As String = Application.ProductVersion

            '    If Version.Parse(updateInfo.version) > Version.Parse(localVersion) Then
            '        Dim message As String = $"Neue Version verfügbar: {updateInfo.version}" & vbCrLf &
            '                                $"Änderungen: {updateInfo.changelog}" & vbCrLf &
            '                                "Möchtest du jetzt aktualisieren?"

            '        If MessageBox.Show(message, "Update verfügbar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            '            Process.Start(updateInfo.downloadUrl)
            '            Application.Exit()
            '        End If
            '    End If
            'End If


        Catch ex As Exception
            FormatErrors(ex)

        End Try
        Return UpdateInfo
    End Function
    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CkUpdate As UpdateInfo = CheckForUpdate()
        LVersion.Text = "Version: " & CkUpdate.version
        LChangeLog.Text = "Changelog: " & CkUpdate.changelog
    End Sub
End Class
