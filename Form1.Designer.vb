<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        lbMessages = New ListBox()
        lIncome = New Label()
        lbIncome = New ListBox()
        lGoal = New Label()
        lStatus = New Label()
        GroupBox1 = New GroupBox()
        GroupBox2 = New GroupBox()
        Tabbi = New TabControl()
        TPMessages = New TabPage()
        TPErrors = New TabPage()
        lbErrors = New ListBox()
        TPTips = New TabPage()
        LBTips = New ListBox()
        TPModelStatus = New TabPage()
        LBModelStatus = New ListBox()
        ImageList1 = New ImageList(components)
        GroupBox3 = New GroupBox()
        PBGoal = New ProgressBar()
        ToolStrip1 = New ToolStrip()
        ToolStripButton1 = New ToolStripButton()
        ToolStripButton2 = New ToolStripButton()
        PicBoxAvatar = New PictureBox()
        PicBoxStatus = New PictureBox()
        GroupBox4 = New GroupBox()
        LPoints = New Label()
        LPosition = New Label()
        LC2CRate = New Label()
        LPrivateRate = New Label()
        Label1 = New Label()
        LlModelLink = New LinkLabel()
        LFollower = New Label()
        LOnline = New Label()
        LCurStatus = New Label()
        Timer1 = New Timer(components)
        pnlOnlineStatus = New Panel()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        Tabbi.SuspendLayout()
        TPMessages.SuspendLayout()
        TPErrors.SuspendLayout()
        TPTips.SuspendLayout()
        TPModelStatus.SuspendLayout()
        GroupBox3.SuspendLayout()
        ToolStrip1.SuspendLayout()
        CType(PicBoxAvatar, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicBoxStatus, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox4.SuspendLayout()
        SuspendLayout()
        ' 
        ' lbMessages
        ' 
        lbMessages.BackColor = Color.Gray
        lbMessages.Dock = DockStyle.Fill
        lbMessages.FormattingEnabled = True
        lbMessages.ItemHeight = 17
        lbMessages.Location = New Point(3, 3)
        lbMessages.Name = "lbMessages"
        lbMessages.Size = New Size(758, 124)
        lbMessages.TabIndex = 0
        ' 
        ' lIncome
        ' 
        lIncome.BorderStyle = BorderStyle.FixedSingle
        lIncome.Dock = DockStyle.Bottom
        lIncome.FlatStyle = FlatStyle.Popup
        lIncome.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lIncome.Location = New Point(3, 494)
        lIncome.Name = "lIncome"
        lIncome.Size = New Size(281, 43)
        lIncome.TabIndex = 1
        lIncome.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lbIncome
        ' 
        lbIncome.BackColor = Color.DarkGray
        lbIncome.Dock = DockStyle.Fill
        lbIncome.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbIncome.FormattingEnabled = True
        lbIncome.ItemHeight = 17
        lbIncome.Location = New Point(3, 19)
        lbIncome.Name = "lbIncome"
        lbIncome.Size = New Size(281, 475)
        lbIncome.TabIndex = 0
        ' 
        ' lGoal
        ' 
        lGoal.Dock = DockStyle.Top
        lGoal.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lGoal.Location = New Point(3, 19)
        lGoal.Name = "lGoal"
        lGoal.Size = New Size(772, 35)
        lGoal.TabIndex = 3
        lGoal.Text = "---"
        lGoal.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lStatus
        ' 
        lStatus.BackColor = Color.DimGray
        lStatus.BorderStyle = BorderStyle.Fixed3D
        lStatus.Dock = DockStyle.Top
        lStatus.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lStatus.ForeColor = Color.White
        lStatus.Location = New Point(0, 0)
        lStatus.Name = "lStatus"
        lStatus.Size = New Size(1065, 43)
        lStatus.TabIndex = 4
        lStatus.Text = "Label1 - Offline"
        lStatus.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(lbIncome)
        GroupBox1.Controls.Add(lIncome)
        GroupBox1.Dock = DockStyle.Right
        GroupBox1.Location = New Point(778, 43)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(287, 540)
        GroupBox1.TabIndex = 5
        GroupBox1.TabStop = False
        GroupBox1.Text = "Token Ranking"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Tabbi)
        GroupBox2.Dock = DockStyle.Bottom
        GroupBox2.Location = New Point(0, 396)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(778, 187)
        GroupBox2.TabIndex = 6
        GroupBox2.TabStop = False
        GroupBox2.Text = "Nachrichten"
        ' 
        ' Tabbi
        ' 
        Tabbi.Controls.Add(TPMessages)
        Tabbi.Controls.Add(TPErrors)
        Tabbi.Controls.Add(TPTips)
        Tabbi.Controls.Add(TPModelStatus)
        Tabbi.Dock = DockStyle.Fill
        Tabbi.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Tabbi.ImageList = ImageList1
        Tabbi.Location = New Point(3, 19)
        Tabbi.Name = "Tabbi"
        Tabbi.SelectedIndex = 0
        Tabbi.Size = New Size(772, 165)
        Tabbi.TabIndex = 1
        ' 
        ' TPMessages
        ' 
        TPMessages.BackColor = Color.Transparent
        TPMessages.Controls.Add(lbMessages)
        TPMessages.ImageIndex = 0
        TPMessages.Location = New Point(4, 31)
        TPMessages.Name = "TPMessages"
        TPMessages.Padding = New Padding(3)
        TPMessages.Size = New Size(764, 130)
        TPMessages.TabIndex = 0
        TPMessages.Text = "Nachrichten"
        ' 
        ' TPErrors
        ' 
        TPErrors.BackColor = Color.DimGray
        TPErrors.Controls.Add(lbErrors)
        TPErrors.ImageIndex = 1
        TPErrors.Location = New Point(4, 31)
        TPErrors.Name = "TPErrors"
        TPErrors.Padding = New Padding(3)
        TPErrors.Size = New Size(764, 130)
        TPErrors.TabIndex = 1
        TPErrors.Text = "Fehler"
        ' 
        ' lbErrors
        ' 
        lbErrors.BackColor = Color.Gray
        lbErrors.Dock = DockStyle.Fill
        lbErrors.ForeColor = Color.Red
        lbErrors.FormattingEnabled = True
        lbErrors.ItemHeight = 17
        lbErrors.Location = New Point(3, 3)
        lbErrors.Name = "lbErrors"
        lbErrors.Size = New Size(758, 124)
        lbErrors.TabIndex = 1
        ' 
        ' TPTips
        ' 
        TPTips.BackColor = Color.DimGray
        TPTips.Controls.Add(LBTips)
        TPTips.ImageIndex = 2
        TPTips.Location = New Point(4, 31)
        TPTips.Name = "TPTips"
        TPTips.Size = New Size(764, 130)
        TPTips.TabIndex = 2
        TPTips.Text = "Trinkgelder"
        ' 
        ' LBTips
        ' 
        LBTips.BackColor = Color.Gray
        LBTips.Dock = DockStyle.Fill
        LBTips.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LBTips.ForeColor = Color.Lime
        LBTips.FormattingEnabled = True
        LBTips.ItemHeight = 21
        LBTips.Location = New Point(0, 0)
        LBTips.Name = "LBTips"
        LBTips.Size = New Size(764, 130)
        LBTips.TabIndex = 1
        ' 
        ' TPModelStatus
        ' 
        TPModelStatus.BackColor = Color.DimGray
        TPModelStatus.Controls.Add(LBModelStatus)
        TPModelStatus.ImageIndex = 4
        TPModelStatus.Location = New Point(4, 31)
        TPModelStatus.Name = "TPModelStatus"
        TPModelStatus.Padding = New Padding(3)
        TPModelStatus.Size = New Size(764, 130)
        TPModelStatus.TabIndex = 3
        TPModelStatus.Text = "Modelstatus"
        ' 
        ' LBModelStatus
        ' 
        LBModelStatus.BackColor = Color.Gray
        LBModelStatus.Dock = DockStyle.Fill
        LBModelStatus.ForeColor = Color.DeepSkyBlue
        LBModelStatus.FormattingEnabled = True
        LBModelStatus.ItemHeight = 17
        LBModelStatus.Location = New Point(3, 3)
        LBModelStatus.Name = "LBModelStatus"
        LBModelStatus.Size = New Size(758, 124)
        LBModelStatus.TabIndex = 2
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), ImageListStreamer)
        ImageList1.TransparentColor = Color.Transparent
        ImageList1.Images.SetKeyName(0, "chat_24dp_434343_FILL0_wght400_GRAD0_opsz24.png")
        ImageList1.Images.SetKeyName(1, "warning_16dp_434343_FILL0_wght400_GRAD0_opsz20.png")
        ImageList1.Images.SetKeyName(2, "attach_money_24dp_434343_FILL0_wght400_GRAD0_opsz24.png")
        ImageList1.Images.SetKeyName(3, "person_add_24dp_434343_FILL0_wght400_GRAD0_opsz24.png")
        ImageList1.Images.SetKeyName(4, "account_circle_48dp_434343.png")
        ImageList1.Images.SetKeyName(5, "system_update_alt_48dp_434343 (1).png")
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(PBGoal)
        GroupBox3.Controls.Add(lGoal)
        GroupBox3.Dock = DockStyle.Bottom
        GroupBox3.Location = New Point(0, 307)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(778, 89)
        GroupBox3.TabIndex = 7
        GroupBox3.TabStop = False
        GroupBox3.Text = "Aktuelles Ziel"
        ' 
        ' PBGoal
        ' 
        PBGoal.Dock = DockStyle.Top
        PBGoal.Location = New Point(3, 54)
        PBGoal.Name = "PBGoal"
        PBGoal.Size = New Size(772, 27)
        PBGoal.TabIndex = 4
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.BackColor = Color.Transparent
        ToolStrip1.BackgroundImageLayout = ImageLayout.None
        ToolStrip1.GripStyle = ToolStripGripStyle.Hidden
        ToolStrip1.ImageScalingSize = New Size(24, 24)
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripButton1, ToolStripButton2})
        ToolStrip1.Location = New Point(0, 43)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.RenderMode = ToolStripRenderMode.Professional
        ToolStrip1.Size = New Size(778, 31)
        ToolStrip1.TabIndex = 8
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), Image)
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(28, 28)
        ToolStripButton1.Text = "ToolStripButton1"
        ' 
        ' ToolStripButton2
        ' 
        ToolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), Image)
        ToolStripButton2.ImageTransparentColor = Color.Magenta
        ToolStripButton2.Name = "ToolStripButton2"
        ToolStripButton2.Size = New Size(28, 28)
        ToolStripButton2.Text = "ToolStripButton2"
        ToolStripButton2.ToolTipText = "Dark / Light Mode umschalten"
        ' 
        ' PicBoxAvatar
        ' 
        PicBoxAvatar.Dock = DockStyle.Fill
        PicBoxAvatar.Location = New Point(287, 74)
        PicBoxAvatar.Name = "PicBoxAvatar"
        PicBoxAvatar.Size = New Size(491, 201)
        PicBoxAvatar.SizeMode = PictureBoxSizeMode.Zoom
        PicBoxAvatar.TabIndex = 9
        PicBoxAvatar.TabStop = False
        ' 
        ' PicBoxStatus
        ' 
        PicBoxStatus.BackColor = Color.Transparent
        PicBoxStatus.Dock = DockStyle.Fill
        PicBoxStatus.Image = CType(resources.GetObject("PicBoxStatus.Image"), Image)
        PicBoxStatus.Location = New Point(287, 74)
        PicBoxStatus.Name = "PicBoxStatus"
        PicBoxStatus.Size = New Size(491, 201)
        PicBoxStatus.SizeMode = PictureBoxSizeMode.CenterImage
        PicBoxStatus.TabIndex = 10
        PicBoxStatus.TabStop = False
        PicBoxStatus.Visible = False
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(LPoints)
        GroupBox4.Controls.Add(LPosition)
        GroupBox4.Controls.Add(LC2CRate)
        GroupBox4.Controls.Add(LPrivateRate)
        GroupBox4.Controls.Add(Label1)
        GroupBox4.Controls.Add(LlModelLink)
        GroupBox4.Controls.Add(LFollower)
        GroupBox4.Controls.Add(LOnline)
        GroupBox4.Dock = DockStyle.Left
        GroupBox4.Location = New Point(0, 74)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(287, 233)
        GroupBox4.TabIndex = 6
        GroupBox4.TabStop = False
        GroupBox4.Text = "Modelinformationen"
        ' 
        ' LPoints
        ' 
        LPoints.AutoSize = True
        LPoints.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LPoints.Location = New Point(3, 166)
        LPoints.Name = "LPoints"
        LPoints.Size = New Size(68, 21)
        LPoints.TabIndex = 7
        LPoints.Text = "Punkte:"
        ' 
        ' LPosition
        ' 
        LPosition.AutoSize = True
        LPosition.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LPosition.Location = New Point(3, 145)
        LPosition.Name = "LPosition"
        LPosition.Size = New Size(102, 21)
        LPosition.TabIndex = 6
        LPosition.Text = "Platzierung:"
        ' 
        ' LC2CRate
        ' 
        LC2CRate.AutoSize = True
        LC2CRate.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LC2CRate.Location = New Point(3, 124)
        LC2CRate.Name = "LC2CRate"
        LC2CRate.Size = New Size(43, 21)
        LC2CRate.TabIndex = 5
        LC2CRate.Text = "C2C:"
        ' 
        ' LPrivateRate
        ' 
        LPrivateRate.AutoSize = True
        LPrivateRate.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LPrivateRate.Location = New Point(3, 103)
        LPrivateRate.Name = "LPrivateRate"
        LPrivateRate.Size = New Size(59, 21)
        LPrivateRate.TabIndex = 4
        LPrivateRate.Text = "Privat:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(3, 61)
        Label1.Name = "Label1"
        Label1.Size = New Size(180, 21)
        Label1.TabIndex = 3
        Label1.Text = "Besuche die Seite von "
        ' 
        ' LlModelLink
        ' 
        LlModelLink.AutoSize = True
        LlModelLink.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LlModelLink.Location = New Point(3, 82)
        LlModelLink.Name = "LlModelLink"
        LlModelLink.Size = New Size(92, 21)
        LlModelLink.TabIndex = 2
        LlModelLink.TabStop = True
        LlModelLink.Text = "LinkLabel1"
        ' 
        ' LFollower
        ' 
        LFollower.AutoSize = True
        LFollower.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LFollower.Location = New Point(3, 40)
        LFollower.Name = "LFollower"
        LFollower.Size = New Size(22, 21)
        LFollower.TabIndex = 1
        LFollower.Text = "..."
        ' 
        ' LOnline
        ' 
        LOnline.AutoSize = True
        LOnline.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LOnline.Location = New Point(3, 19)
        LOnline.Name = "LOnline"
        LOnline.Size = New Size(22, 21)
        LOnline.TabIndex = 0
        LOnline.Text = "..."
        ' 
        ' LCurStatus
        ' 
        LCurStatus.Dock = DockStyle.Bottom
        LCurStatus.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LCurStatus.Location = New Point(287, 275)
        LCurStatus.Name = "LCurStatus"
        LCurStatus.Size = New Size(491, 32)
        LCurStatus.TabIndex = 1
        LCurStatus.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 1000
        ' 
        ' pnlOnlineStatus
        ' 
        pnlOnlineStatus.Location = New Point(4, 4)
        pnlOnlineStatus.Name = "pnlOnlineStatus"
        pnlOnlineStatus.Size = New Size(8, 35)
        pnlOnlineStatus.TabIndex = 11
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DimGray
        ClientSize = New Size(1065, 583)
        Controls.Add(pnlOnlineStatus)
        Controls.Add(PicBoxAvatar)
        Controls.Add(PicBoxStatus)
        Controls.Add(LCurStatus)
        Controls.Add(GroupBox4)
        Controls.Add(ToolStrip1)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(lStatus)
        Name = "Form1"
        Text = "Form1"
        GroupBox1.ResumeLayout(False)
        GroupBox2.ResumeLayout(False)
        Tabbi.ResumeLayout(False)
        TPMessages.ResumeLayout(False)
        TPErrors.ResumeLayout(False)
        TPTips.ResumeLayout(False)
        TPModelStatus.ResumeLayout(False)
        GroupBox3.ResumeLayout(False)
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        CType(PicBoxAvatar, ComponentModel.ISupportInitialize).EndInit()
        CType(PicBoxStatus, ComponentModel.ISupportInitialize).EndInit()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lbMessages As ListBox
    Friend WithEvents lIncome As Label
    Friend WithEvents lbIncome As ListBox
    Friend WithEvents lGoal As Label
    Friend WithEvents lStatus As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TCUserMessages As TabControl
    Friend WithEvents TPMessages As TabPage
    Friend WithEvents TPErrors As TabPage
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Tabbi As TabControl
    Friend WithEvents lbErrors As ListBox
    Friend WithEvents TPTips As TabPage
    Friend WithEvents LBTips As ListBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents PBGoal As ProgressBar
    Friend WithEvents PicBoxAvatar As PictureBox
    Friend WithEvents PicBoxStatus As PictureBox
    Friend WithEvents TPModelStatus As TabPage
    Friend WithEvents LBModelStatus As ListBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents LCurStatus As Label
    Friend WithEvents LOnline As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LFollower As Label
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents LlModelLink As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents LC2CRate As Label
    Friend WithEvents LPrivateRate As Label
    Friend WithEvents LPosition As Label
    Friend WithEvents LPoints As Label
    Friend WithEvents pnlOnlineStatus As Panel

End Class
