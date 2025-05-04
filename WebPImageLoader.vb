Imports ImageMagick
Imports System.IO
Imports System.Net
Imports System.Net.Http

Public Class WebPImageLoader
    Public Async Sub LoadWebPImageAsync(url As String, pictureBox As PictureBox)
        Try
            Using client As New HttpClient()
                Dim imageBytes As Byte() = Await client.GetByteArrayAsync(url)
                Using ms As New MemoryStream(imageBytes)
                    pictureBox.Image = Image.FromStream(ms)
                    'Form1.PicBoxStatus.BackgroundImage = pictureBox.BackgroundImage
                End Using
            End Using

        Catch ex As Exception
            FormatErrors(ex)
        End Try
    End Sub
End Class
