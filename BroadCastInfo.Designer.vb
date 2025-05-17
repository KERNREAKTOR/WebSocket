<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BroadCastInfo
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        LResolution = New Label()
        SuspendLayout()
        ' 
        ' LResolution
        ' 
        LResolution.AutoSize = True
        LResolution.Location = New Point(6, 12)
        LResolution.Name = "LResolution"
        LResolution.Size = New Size(41, 15)
        LResolution.TabIndex = 0
        LResolution.Text = "Label1"
        ' 
        ' BroadCastInfo
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(LResolution)
        Name = "BroadCastInfo"
        Size = New Size(423, 227)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LResolution As Label

End Class
