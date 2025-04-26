<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddModel
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        TableLayoutPanel1 = New TableLayoutPanel()
        OK_Button = New Button()
        Cancel_Button = New Button()
        LBModeNames = New ListBox()
        BtnAddModel = New Button()
        BtnRemoveModel = New Button()
        GroupBox1 = New GroupBox()
        LStatus = New Label()
        Label2 = New Label()
        TableLayoutPanel1.SuspendLayout()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(OK_Button, 0, 0)
        TableLayoutPanel1.Controls.Add(Cancel_Button, 1, 0)
        TableLayoutPanel1.Location = New Point(135, 232)
        TableLayoutPanel1.Margin = New Padding(4, 3, 4, 3)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(170, 33)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' OK_Button
        ' 
        OK_Button.Anchor = AnchorStyles.None
        OK_Button.Enabled = False
        OK_Button.Location = New Point(4, 3)
        OK_Button.Margin = New Padding(4, 3, 4, 3)
        OK_Button.Name = "OK_Button"
        OK_Button.Size = New Size(77, 27)
        OK_Button.TabIndex = 0
        OK_Button.Text = "OK"
        ' 
        ' Cancel_Button
        ' 
        Cancel_Button.Anchor = AnchorStyles.None
        Cancel_Button.Location = New Point(89, 3)
        Cancel_Button.Margin = New Padding(4, 3, 4, 3)
        Cancel_Button.Name = "Cancel_Button"
        Cancel_Button.Size = New Size(77, 27)
        Cancel_Button.TabIndex = 1
        Cancel_Button.Text = "Abbrechen"
        ' 
        ' LBModeNames
        ' 
        LBModeNames.FormattingEnabled = True
        LBModeNames.ItemHeight = 15
        LBModeNames.Location = New Point(12, 12)
        LBModeNames.Name = "LBModeNames"
        LBModeNames.Size = New Size(251, 94)
        LBModeNames.TabIndex = 1
        ' 
        ' BtnAddModel
        ' 
        BtnAddModel.Location = New Point(269, 12)
        BtnAddModel.Name = "BtnAddModel"
        BtnAddModel.Size = New Size(32, 23)
        BtnAddModel.TabIndex = 2
        BtnAddModel.Text = "+"
        BtnAddModel.UseVisualStyleBackColor = True
        ' 
        ' BtnRemoveModel
        ' 
        BtnRemoveModel.Location = New Point(269, 41)
        BtnRemoveModel.Name = "BtnRemoveModel"
        BtnRemoveModel.Size = New Size(32, 23)
        BtnRemoveModel.TabIndex = 3
        BtnRemoveModel.Text = "-"
        BtnRemoveModel.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(LStatus)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Location = New Point(16, 112)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(285, 100)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        GroupBox1.Text = "Modelinformationen"
        ' 
        ' LStatus
        ' 
        LStatus.Location = New Point(95, 15)
        LStatus.Name = "LStatus"
        LStatus.Size = New Size(85, 19)
        LStatus.TabIndex = 1
        LStatus.Text = "Status:"
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(4, 15)
        Label2.Name = "Label2"
        Label2.Size = New Size(85, 19)
        Label2.TabIndex = 0
        Label2.Text = "Status:"
        ' 
        ' AddModel
        ' 
        AcceptButton = OK_Button
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = Cancel_Button
        ClientSize = New Size(319, 279)
        Controls.Add(GroupBox1)
        Controls.Add(BtnRemoveModel)
        Controls.Add(BtnAddModel)
        Controls.Add(LBModeNames)
        Controls.Add(TableLayoutPanel1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "AddModel"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Add Model"
        TableLayoutPanel1.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents LBModeNames As ListBox
    Friend WithEvents BtnAddModel As Button
    Friend WithEvents BtnRemoveModel As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LStatus As Label
    Friend WithEvents Label2 As Label

End Class
