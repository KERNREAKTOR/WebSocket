Module ListBoxFormater
    Public Sub FormatErrors(Message As String)

        Dim currentTab As TabPage = Form1.Tabbi.SelectedTab
        Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        With Form1.lbErrors

            .Items.Add($"{timestamp} - {Message}")
            Form1.TPErrors.Text = $"Fehler({ .Items.Count})"
            .TopIndex = .Items.Count - 1

            If currentTab.TabIndex = 1 Then

                Form1.ErrorCounts = .Items.Count
                Form1.TPErrors.Text = $"Fehler"

            Else

                Form1.TPErrors.Text = $"Fehler({ .Items.Count - Form1.ErrorCounts})"

            End If

        End With

    End Sub

    Public Sub FormatStatus(Message As String)

        Dim currentTab As TabPage = Form1.Tabbi.SelectedTab
        Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        With Form1.LBModelStatus

            .Items.Add($"{timestamp} - {Message}")
            Form1.TPModelStatus.Text = $"Modelstatus({ .Items.Count})"
            .TopIndex = .Items.Count - 1

            If currentTab.TabIndex = 3 Then

                Form1.StatusCounts = .Items.Count
                Form1.TPModelStatus.Text = $"Modelstatus"

            Else

                Form1.TPModelStatus.Text = $"Modelstatus({ .Items.Count - Form1.StatusCounts})"

            End If

        End With

    End Sub
    Public Sub FormatTips(Message As String)

        Dim currentTab As TabPage = Form1.Tabbi.SelectedTab
        Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        With Form1.LBTips

            .Items.Add($"{timestamp} - {Message}")
            .TopIndex = .Items.Count - 1

            If currentTab.TabIndex = 2 Then

                Form1.TipsCounts = .Items.Count
                Form1.TPTips.Text = $"Trinkgelder"

            Else

                Form1.TPTips.Text = $"Trinkgelder({ .Items.Count - Form1.TipsCounts})"

            End If

        End With

    End Sub
    Public Sub FormatMessages(Message As String)

        Dim currentTab As TabPage = Form1.Tabbi.SelectedTab
        Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        With Form1.lbMessages

            .Items.Add($"{timestamp} - {Message}")
            Form1.TPMessages.Text = $"Nachrichten({ .Items.Count})"
            .TopIndex = .Items.Count - 1

            If currentTab.TabIndex = 0 Then

                Form1.MessagesCounts = .Items.Count
                Form1.TPMessages.Text = $"Nachrichten"

            Else

                Form1.TPMessages.Text = $"Nachrichten({ .Items.Count - Form1.MessagesCounts})"

            End If

        End With

    End Sub

End Module
