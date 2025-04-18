Imports System.Net.Http
Imports System.Net.Security
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class AddModel

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub AddModel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LBModeNames.Items.Clear()

        ' Load the model names from settings into the ListBox
        If My.Settings.ModelNames IsNot Nothing Then

            For Each name As String In My.Settings.ModelNames
                LBModeNames.Items.Add(name)
            Next

        Else
            OK_Button.Enabled = False
        End If
    End Sub

    Private Sub BtnAddModel_Click(sender As Object, e As EventArgs) Handles BtnAddModel.Click
        Dim ModelName As String = InputBox("Bitte geben Sie den Namen des Modells ein", "Modell hinzufügen")

        If Not String.IsNullOrEmpty(ModelName) AndAlso Not ModelName.Contains(" ") Then
            Using client As New HttpClient()
                Dim url As String = $"https://de.stripchat.com/api/front/v2/models/username/{ModelName}/chat"
                Dim request As New HttpRequestMessage(HttpMethod.Head, url)
                Dim response As HttpResponseMessage = client.SendAsync(request).Result

                If response.IsSuccessStatusCode Then
                    LBModeNames.Items.Add(ModelName)
                    LBModeNames.SelectedIndex = LBModeNames.Items.Count - 1
                    ' Check if the model name is not empty and does not already exist in the ListBox
                    'Dim names As New System.Collections.Specialized.StringCollection()
                    My.Settings.ModelNames.Clear()

                    For Each item As String In LBModeNames.Items
                        My.Settings.ModelNames.Add(item)
                    Next

                    ' My.Settings.ModelNames = names
                    My.Settings.Save()
                Else
                    MessageBox.Show("Dieses Model existiert nicht.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using

        Else
            MessageBox.Show("Der Modellname darf keine Leerzeichen enthalten und darf nicht leer sein.", "Ungültiger Modellname", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub LBModeNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBModeNames.SelectedIndexChanged

        If LBModeNames.SelectedIndex >= 0 Then
            BtnAddModel.Enabled = True
            OK_Button.Enabled = True
            Dim SelectedModel As String = LBModeNames.Items(LBModeNames.SelectedIndex)
            Dim manager As New DownloadManager()
            Dim urlCam As String = $"https://de.stripchat.com/api/front/v2/models/username/{SelectedModel}/cam"
            Dim jsonStringCam As String = manager.DownloadJsonAsync(urlCam)
            Dim Stripchat As New StripchatDespatcher(jsonStringCam)
            LStatus.Text = Stripchat.GetUserInformation.Status
        Else
            BtnAddModel.Enabled = False
            OK_Button.Enabled = False
        End If

    End Sub

    Private Sub BtnRemoveModel_Click(sender As Object, e As EventArgs) Handles BtnRemoveModel.Click
        If LBModeNames.SelectedIndex >= 0 Then
            LBModeNames.Items.RemoveAt(LBModeNames.SelectedIndex)

            My.Settings.ModelNames.Clear()

            For Each item As String In LBModeNames.Items
                My.Settings.ModelNames.Add(item)
            Next

            My.Settings.Save()
            ' Check if the ListBox is empty and disable the OK button if it is
            If LBModeNames.Items.Count = 0 Then
                OK_Button.Enabled = False
            End If
        End If
    End Sub
End Class
