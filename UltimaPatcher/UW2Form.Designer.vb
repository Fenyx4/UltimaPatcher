<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UW2Form
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UW2DirectoryTextbox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.UW2DirectoryDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.MT32EmulationText = New System.Windows.Forms.TextBox()
        Me.ROMStatus = New System.Windows.Forms.TextBox()
        Me.InstallMT32Button = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SpeechCombo = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.AddROMsButton = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SoundCombo = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GMToggleButton = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GMStatusLabel = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.AddROMDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.UW2DirectoryTextbox)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(879, 81)
        Me.GroupBox2.TabIndex = 18
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
        'UW2DirectoryTextbox
        '
        Me.UW2DirectoryTextbox.Location = New System.Drawing.Point(54, 24)
        Me.UW2DirectoryTextbox.Name = "UW2DirectoryTextbox"
        Me.UW2DirectoryTextbox.ReadOnly = True
        Me.UW2DirectoryTextbox.Size = New System.Drawing.Size(819, 20)
        Me.UW2DirectoryTextbox.TabIndex = 11
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
        'UW2DirectoryDialog
        '
        Me.UW2DirectoryDialog.Description = "Select Ultima Underworld 1 & 2 Directory"
        Me.UW2DirectoryDialog.SelectedPath = "C:\Program Files (x86)\GOG.com\Ultima Trilogy\Ultima2"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.MT32EmulationText)
        Me.GroupBox5.Controls.Add(Me.ROMStatus)
        Me.GroupBox5.Controls.Add(Me.InstallMT32Button)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.SpeechCombo)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.AddROMsButton)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.SoundCombo)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 193)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(879, 88)
        Me.GroupBox5.TabIndex = 27
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "GroupBox5"
        '
        'MT32EmulationText
        '
        Me.MT32EmulationText.Location = New System.Drawing.Point(313, 49)
        Me.MT32EmulationText.Name = "MT32EmulationText"
        Me.MT32EmulationText.ReadOnly = True
        Me.MT32EmulationText.Size = New System.Drawing.Size(100, 20)
        Me.MT32EmulationText.TabIndex = 32
        '
        'ROMStatus
        '
        Me.ROMStatus.Location = New System.Drawing.Point(313, 22)
        Me.ROMStatus.Name = "ROMStatus"
        Me.ROMStatus.ReadOnly = True
        Me.ROMStatus.Size = New System.Drawing.Size(100, 20)
        Me.ROMStatus.TabIndex = 29
        '
        'InstallMT32Button
        '
        Me.InstallMT32Button.Location = New System.Drawing.Point(419, 49)
        Me.InstallMT32Button.Name = "InstallMT32Button"
        Me.InstallMT32Button.Size = New System.Drawing.Size(75, 23)
        Me.InstallMT32Button.TabIndex = 33
        Me.InstallMT32Button.Text = "Install"
        Me.InstallMT32Button.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Speech:"
        '
        'SpeechCombo
        '
        Me.SpeechCombo.FormattingEnabled = True
        Me.SpeechCombo.Items.AddRange(New Object() {"On", "Off"})
        Me.SpeechCombo.Location = New System.Drawing.Point(70, 49)
        Me.SpeechCombo.Name = "SpeechCombo"
        Me.SpeechCombo.Size = New System.Drawing.Size(121, 21)
        Me.SpeechCombo.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(217, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 13)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "MT-32 Emulation:"
        '
        'AddROMsButton
        '
        Me.AddROMsButton.Location = New System.Drawing.Point(419, 21)
        Me.AddROMsButton.Name = "AddROMsButton"
        Me.AddROMsButton.Size = New System.Drawing.Size(75, 23)
        Me.AddROMsButton.TabIndex = 30
        Me.AddROMsButton.Text = "Add ROM's"
        Me.AddROMsButton.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Soundcard:"
        '
        'SoundCombo
        '
        Me.SoundCombo.FormattingEnabled = True
        Me.SoundCombo.Items.AddRange(New Object() {"SB Pro", "MIDI/MT-32"})
        Me.SoundCombo.Location = New System.Drawing.Point(70, 22)
        Me.SoundCombo.Name = "SoundCombo"
        Me.SoundCombo.Size = New System.Drawing.Size(121, 21)
        Me.SoundCombo.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(217, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "MT-32 ROM's:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Sound Options"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GMToggleButton)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.GMStatusLabel)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.TextBox4)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 99)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(879, 88)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GroupBox3"
        '
        'GMToggleButton
        '
        Me.GMToggleButton.Location = New System.Drawing.Point(755, 16)
        Me.GMToggleButton.Name = "GMToggleButton"
        Me.GMToggleButton.Size = New System.Drawing.Size(118, 24)
        Me.GMToggleButton.TabIndex = 12
        Me.GMToggleButton.Text = "Install"
        Me.GMToggleButton.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Description:"
        '
        'GMStatusLabel
        '
        Me.GMStatusLabel.AutoSize = True
        Me.GMStatusLabel.Location = New System.Drawing.Point(67, 27)
        Me.GMStatusLabel.Name = "GMStatusLabel"
        Me.GMStatusLabel.Size = New System.Drawing.Size(72, 13)
        Me.GMStatusLabel.TabIndex = 14
        Me.GMStatusLabel.Text = "(Not Installed)"
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
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(70, 55)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(803, 26)
        Me.TextBox4.TabIndex = 6
        Me.TextBox4.Text = "Adds support for General MIDI soundcards. Note that SB Pro soundcard is not suppo" & _
            "rted when installed."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "General MIDI Patch"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(810, 287)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 23
        Me.Button3.Text = "Close"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'AddROMDialog
        '
        Me.AddROMDialog.Description = "Select location of MT-32 ROM's (Either CM32L_CONTROL.ROM & CM32L_PCM.ROM or MT32_" & _
            "CONROL.ROM & MT32_PCM.ROM)"
        '
        'UW2Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 320)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "UW2Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ultima Underworld 2"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents UW2DirectoryTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents UW2DirectoryDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents SpeechCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents SoundCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GMToggleButton As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GMStatusLabel As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents MT32EmulationText As System.Windows.Forms.TextBox
    Friend WithEvents ROMStatus As System.Windows.Forms.TextBox
    Friend WithEvents InstallMT32Button As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents AddROMsButton As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents AddROMDialog As System.Windows.Forms.FolderBrowserDialog
End Class
