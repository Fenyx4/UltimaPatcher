<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class U9Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(U9Form))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Ultima9DirectoryTextbox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Ultima9DirectoryDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.AddROMDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.RasterizerCombo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.HeightBox = New System.Windows.Forms.TextBox()
        Me.WidthBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UpgradeStatus = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UpgradeButton = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RenameAvatarButton = New System.Windows.Forms.Button()
        Me.DialogButton = New System.Windows.Forms.Button()
        Me.MonEcoButton = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.EcoStatus = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.FogButton = New System.Windows.Forms.Button()
        Me.BBInstallButton = New System.Windows.Forms.Button()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.DownloadBBButon = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BBStatusLabel = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.DownloadLanguagePacksButton = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextInstallButton = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SpeechInstallButton = New System.Windows.Forms.Button()
        Me.LanguageComboBox = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LanguagePacksStatusLabel = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Ultima9DirectoryTextbox)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(879, 81)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Path:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Ultima Game Directory"
        '
        'Ultima9DirectoryTextbox
        '
        Me.Ultima9DirectoryTextbox.Location = New System.Drawing.Point(54, 24)
        Me.Ultima9DirectoryTextbox.Name = "Ultima9DirectoryTextbox"
        Me.Ultima9DirectoryTextbox.ReadOnly = True
        Me.Ultima9DirectoryTextbox.Size = New System.Drawing.Size(819, 20)
        Me.Ultima9DirectoryTextbox.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(733, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(140, 20)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Change Game Directory"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Ultima9DirectoryDialog
        '
        Me.Ultima9DirectoryDialog.Description = "Select Ultima 9 Directory"
        Me.Ultima9DirectoryDialog.SelectedPath = "C:\Program Files (x86)\GOG.com\Ultima Trilogy\Ultima2"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(823, 701)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 24
        Me.Button3.Text = "Close"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'AddROMDialog
        '
        Me.AddROMDialog.Description = "Select location of MT-32 ROM's (Either CM32L_CONTROL.ROM & CM32L_PCM.ROM or MT32_" &
    "CONROL.ROM & MT32_PCM.ROM)"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.RasterizerCombo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.HeightBox)
        Me.GroupBox3.Controls.Add(Me.WidthBox)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 313)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(879, 116)
        Me.GroupBox3.TabIndex = 26
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Graphics Settings"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(201, 27)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(672, 80)
        Me.TextBox2.TabIndex = 18
        Me.TextBox2.Text = resources.GetString("TextBox2.Text")
        '
        'RasterizerCombo
        '
        Me.RasterizerCombo.FormattingEnabled = True
        Me.RasterizerCombo.Items.AddRange(New Object() {"Glide", "Direct3D"})
        Me.RasterizerCombo.Location = New System.Drawing.Point(68, 86)
        Me.RasterizerCombo.Name = "RasterizerCombo"
        Me.RasterizerCombo.Size = New System.Drawing.Size(121, 21)
        Me.RasterizerCombo.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Rasterizer:"
        '
        'HeightBox
        '
        Me.HeightBox.Location = New System.Drawing.Point(68, 55)
        Me.HeightBox.Name = "HeightBox"
        Me.HeightBox.Size = New System.Drawing.Size(80, 20)
        Me.HeightBox.TabIndex = 9
        '
        'WidthBox
        '
        Me.WidthBox.Location = New System.Drawing.Point(68, 24)
        Me.WidthBox.Name = "WidthBox"
        Me.WidthBox.Size = New System.Drawing.Size(80, 20)
        Me.WidthBox.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Height:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Width:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(70, 55)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(803, 32)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.Text = "This fixes a host of issues in the game, not least of which is the infamous float" &
    "ing sigil bug. This allows the game to be played in D3D without using the Glide " &
    "wrapper. "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Status:"
        '
        'UpgradeStatus
        '
        Me.UpgradeStatus.AutoSize = True
        Me.UpgradeStatus.Location = New System.Drawing.Point(67, 27)
        Me.UpgradeStatus.Name = "UpgradeStatus"
        Me.UpgradeStatus.Size = New System.Drawing.Size(72, 13)
        Me.UpgradeStatus.TabIndex = 14
        Me.UpgradeStatus.Text = "(Not Installed)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Description:"
        '
        'UpgradeButton
        '
        Me.UpgradeButton.Location = New System.Drawing.Point(755, 25)
        Me.UpgradeButton.Name = "UpgradeButton"
        Me.UpgradeButton.Size = New System.Drawing.Size(118, 24)
        Me.UpgradeButton.TabIndex = 12
        Me.UpgradeButton.Text = "Install"
        Me.UpgradeButton.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(755, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(120, 13)
        Me.LinkLabel1.TabIndex = 17
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "http://forgottenworld.de/index.php/faq/fw-faq"
        Me.LinkLabel1.Text = "http://forgottenworld.de"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.UpgradeButton)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.UpgradeStatus)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 99)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(879, 93)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Forgotten World (1.19H)"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(649, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(226, 13)
        Me.LinkLabel2.TabIndex = 18
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Tag = "http://forgottenworld.de/index.php/faq/bb-faq"
        Me.LinkLabel2.Text = "http://forgottenworld.de/index.php/faq/bb-faq"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RenameAvatarButton)
        Me.GroupBox4.Controls.Add(Me.DialogButton)
        Me.GroupBox4.Controls.Add(Me.MonEcoButton)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.EcoStatus)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.TextBox3)
        Me.GroupBox4.Location = New System.Drawing.Point(19, 435)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(879, 109)
        Me.GroupBox4.TabIndex = 26
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Economy/Monster and Dialog Patches"
        '
        'RenameAvatarButton
        '
        Me.RenameAvatarButton.Location = New System.Drawing.Point(446, 25)
        Me.RenameAvatarButton.Name = "RenameAvatarButton"
        Me.RenameAvatarButton.Size = New System.Drawing.Size(132, 24)
        Me.RenameAvatarButton.TabIndex = 16
        Me.RenameAvatarButton.Text = "Rename Avatar"
        Me.RenameAvatarButton.UseVisualStyleBackColor = True
        '
        'DialogButton
        '
        Me.DialogButton.Location = New System.Drawing.Point(584, 25)
        Me.DialogButton.Name = "DialogButton"
        Me.DialogButton.Size = New System.Drawing.Size(132, 24)
        Me.DialogButton.TabIndex = 15
        Me.DialogButton.Text = "Install Dialog"
        Me.DialogButton.UseVisualStyleBackColor = True
        '
        'MonEcoButton
        '
        Me.MonEcoButton.Location = New System.Drawing.Point(722, 25)
        Me.MonEcoButton.Name = "MonEcoButton"
        Me.MonEcoButton.Size = New System.Drawing.Size(151, 24)
        Me.MonEcoButton.TabIndex = 12
        Me.MonEcoButton.Text = "Install Monster/Economy"
        Me.MonEcoButton.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Description:"
        '
        'EcoStatus
        '
        Me.EcoStatus.AutoSize = True
        Me.EcoStatus.Location = New System.Drawing.Point(67, 27)
        Me.EcoStatus.Name = "EcoStatus"
        Me.EcoStatus.Size = New System.Drawing.Size(72, 13)
        Me.EcoStatus.TabIndex = 14
        Me.EcoStatus.Text = "(Not Installed)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Status:"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(70, 55)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(803, 48)
        Me.TextBox3.TabIndex = 6
        Me.TextBox3.Text = resources.GetString("TextBox3.Text")
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.FogButton)
        Me.GroupBox5.Controls.Add(Me.BBInstallButton)
        Me.GroupBox5.Controls.Add(Me.LinkLabel2)
        Me.GroupBox5.Controls.Add(Me.ProgressBar2)
        Me.GroupBox5.Controls.Add(Me.DownloadBBButon)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.BBStatusLabel)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.TextBox4)
        Me.GroupBox5.Location = New System.Drawing.Point(17, 198)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(879, 109)
        Me.GroupBox5.TabIndex = 26
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Beautiful Britannia R3"
        '
        'FogButton
        '
        Me.FogButton.Location = New System.Drawing.Point(631, 27)
        Me.FogButton.Name = "FogButton"
        Me.FogButton.Size = New System.Drawing.Size(118, 24)
        Me.FogButton.TabIndex = 21
        Me.FogButton.Text = "Turn On Fog"
        Me.FogButton.UseVisualStyleBackColor = True
        '
        'BBInstallButton
        '
        Me.BBInstallButton.Location = New System.Drawing.Point(755, 27)
        Me.BBInstallButton.Name = "BBInstallButton"
        Me.BBInstallButton.Size = New System.Drawing.Size(118, 24)
        Me.BBInstallButton.TabIndex = 18
        Me.BBInstallButton.Text = "Install"
        Me.BBInstallButton.UseVisualStyleBackColor = True
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(156, 27)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(469, 22)
        Me.ProgressBar2.TabIndex = 20
        Me.ProgressBar2.Tag = "Downloading"
        '
        'DownloadBBButon
        '
        Me.DownloadBBButon.Location = New System.Drawing.Point(654, 27)
        Me.DownloadBBButon.Name = "DownloadBBButon"
        Me.DownloadBBButon.Size = New System.Drawing.Size(220, 24)
        Me.DownloadBBButon.TabIndex = 19
        Me.DownloadBBButon.Text = "Download from Ultimacodex.com"
        Me.DownloadBBButon.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Description:"
        '
        'BBStatusLabel
        '
        Me.BBStatusLabel.AutoSize = True
        Me.BBStatusLabel.Location = New System.Drawing.Point(67, 27)
        Me.BBStatusLabel.Name = "BBStatusLabel"
        Me.BBStatusLabel.Size = New System.Drawing.Size(72, 13)
        Me.BBStatusLabel.TabIndex = 14
        Me.BBStatusLabel.Text = "(Not Installed)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 27)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Status:"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(70, 55)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(803, 48)
        Me.TextBox4.TabIndex = 6
        Me.TextBox4.Text = resources.GetString("TextBox4.Text")
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.DownloadLanguagePacksButton)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.TextInstallButton)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.ProgressBar1)
        Me.GroupBox6.Controls.Add(Me.SpeechInstallButton)
        Me.GroupBox6.Controls.Add(Me.LanguageComboBox)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.LanguagePacksStatusLabel)
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.TextBox5)
        Me.GroupBox6.Location = New System.Drawing.Point(19, 550)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(879, 145)
        Me.GroupBox6.TabIndex = 26
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Language"
        '
        'DownloadLanguagePacksButton
        '
        Me.DownloadLanguagePacksButton.Location = New System.Drawing.Point(598, 30)
        Me.DownloadLanguagePacksButton.Name = "DownloadLanguagePacksButton"
        Me.DownloadLanguagePacksButton.Size = New System.Drawing.Size(118, 24)
        Me.DownloadLanguagePacksButton.TabIndex = 22
        Me.DownloadLanguagePacksButton.Text = "Download"
        Me.DownloadLanguagePacksButton.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(649, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Speech:"
        '
        'TextInstallButton
        '
        Me.TextInstallButton.Location = New System.Drawing.Point(559, 30)
        Me.TextInstallButton.Name = "TextInstallButton"
        Me.TextInstallButton.Size = New System.Drawing.Size(87, 24)
        Me.TextInstallButton.TabIndex = 24
        Me.TextInstallButton.Text = "Not Available"
        Me.TextInstallButton.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(556, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Text:"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(154, 30)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(399, 22)
        Me.ProgressBar1.TabIndex = 22
        Me.ProgressBar1.Tag = "Downloading"
        '
        'SpeechInstallButton
        '
        Me.SpeechInstallButton.Location = New System.Drawing.Point(652, 30)
        Me.SpeechInstallButton.Name = "SpeechInstallButton"
        Me.SpeechInstallButton.Size = New System.Drawing.Size(92, 24)
        Me.SpeechInstallButton.TabIndex = 17
        Me.SpeechInstallButton.Text = "Not Available"
        Me.SpeechInstallButton.UseVisualStyleBackColor = True
        '
        'LanguageComboBox
        '
        Me.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LanguageComboBox.FormattingEnabled = True
        Me.LanguageComboBox.Items.AddRange(New Object() {"En", "De", "Es", "Fr", "Jp", "It"})
        Me.LanguageComboBox.Location = New System.Drawing.Point(753, 30)
        Me.LanguageComboBox.Name = "LanguageComboBox"
        Me.LanguageComboBox.Size = New System.Drawing.Size(118, 21)
        Me.LanguageComboBox.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Description:"
        '
        'LanguagePacksStatusLabel
        '
        Me.LanguagePacksStatusLabel.AutoSize = True
        Me.LanguagePacksStatusLabel.Location = New System.Drawing.Point(67, 37)
        Me.LanguagePacksStatusLabel.Name = "LanguagePacksStatusLabel"
        Me.LanguagePacksStatusLabel.Size = New System.Drawing.Size(72, 13)
        Me.LanguagePacksStatusLabel.TabIndex = 14
        Me.LanguagePacksStatusLabel.Text = "(Not Installed)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Status:"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(70, 65)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(803, 62)
        Me.TextBox5.TabIndex = 6
        Me.TextBox5.Text = "Available language packs. Italian and Spanish are fan patches and are text only. " &
    "These packs are ~300 Mb in size and will need to be downloaded before installing" &
    "."
        '
        'U9Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 732)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "U9Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ultima 9"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Ultima9DirectoryTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Ultima9DirectoryDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents AddROMDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents HeightBox As System.Windows.Forms.TextBox
    Friend WithEvents WidthBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RasterizerCombo As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UpgradeStatus As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UpgradeButton As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents MonEcoButton As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents EcoStatus As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents DialogButton As System.Windows.Forms.Button
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents RenameAvatarButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents DownloadBBButon As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BBStatusLabel As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents BBInstallButton As System.Windows.Forms.Button
    Friend WithEvents FogButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents LanguagePacksStatusLabel As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents LanguageComboBox As ComboBox
    Friend WithEvents SpeechInstallButton As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents TextInstallButton As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents DownloadLanguagePacksButton As Button
End Class
