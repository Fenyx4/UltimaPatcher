<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDForm))
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.InstallMT32Button = New System.Windows.Forms.Button()
        Me.MT32EmulationText = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.AddROMsButton = New System.Windows.Forms.Button()
        Me.ROMStatus = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Ultima6DirectoryTextbox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MDDirectoryDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.AddROMDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.TextBox1)
        Me.GroupBox5.Controls.Add(Me.InstallMT32Button)
        Me.GroupBox5.Controls.Add(Me.MT32EmulationText)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.AddROMsButton)
        Me.GroupBox5.Controls.Add(Me.ROMStatus)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 97)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(879, 88)
        Me.GroupBox5.TabIndex = 31
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "GroupBox5"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Description:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(70, 15)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(803, 37)
        Me.TextBox1.TabIndex = 13
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'InstallMT32Button
        '
        Me.InstallMT32Button.Location = New System.Drawing.Point(517, 59)
        Me.InstallMT32Button.Name = "InstallMT32Button"
        Me.InstallMT32Button.Size = New System.Drawing.Size(75, 23)
        Me.InstallMT32Button.TabIndex = 24
        Me.InstallMT32Button.Text = "Install"
        Me.InstallMT32Button.UseVisualStyleBackColor = True
        '
        'MT32EmulationText
        '
        Me.MT32EmulationText.Location = New System.Drawing.Point(402, 60)
        Me.MT32EmulationText.Name = "MT32EmulationText"
        Me.MT32EmulationText.ReadOnly = True
        Me.MT32EmulationText.Size = New System.Drawing.Size(100, 20)
        Me.MT32EmulationText.TabIndex = 23
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(306, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 13)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "MT-32 Emulation:"
        '
        'AddROMsButton
        '
        Me.AddROMsButton.Location = New System.Drawing.Point(203, 58)
        Me.AddROMsButton.Name = "AddROMsButton"
        Me.AddROMsButton.Size = New System.Drawing.Size(75, 23)
        Me.AddROMsButton.TabIndex = 21
        Me.AddROMsButton.Text = "Add ROM's"
        Me.AddROMsButton.UseVisualStyleBackColor = True
        '
        'ROMStatus
        '
        Me.ROMStatus.Location = New System.Drawing.Point(88, 62)
        Me.ROMStatus.Name = "ROMStatus"
        Me.ROMStatus.ReadOnly = True
        Me.ROMStatus.Size = New System.Drawing.Size(100, 20)
        Me.ROMStatus.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 63)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "MT-32 ROM's:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "MT-32 Emulation"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 191)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(879, 99)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GroupBox3"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(755, 25)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(118, 24)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Run Setup"
        Me.Button2.UseVisualStyleBackColor = True
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
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(70, 55)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(803, 32)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.Text = "Run the original game installer to change setup. If using MT-32 emulation, then u" & _
            "se this to swap sound to MT-32."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Run game setup"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(810, 307)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 30
        Me.Button3.Text = "Close"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Ultima6DirectoryTextbox)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(879, 81)
        Me.GroupBox2.TabIndex = 28
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
        'Ultima6DirectoryTextbox
        '
        Me.Ultima6DirectoryTextbox.Location = New System.Drawing.Point(54, 24)
        Me.Ultima6DirectoryTextbox.Name = "Ultima6DirectoryTextbox"
        Me.Ultima6DirectoryTextbox.ReadOnly = True
        Me.Ultima6DirectoryTextbox.Size = New System.Drawing.Size(819, 20)
        Me.Ultima6DirectoryTextbox.TabIndex = 11
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
        'MDDirectoryDialog
        '
        Me.MDDirectoryDialog.Description = "Select Martian Dreams Directory"
        Me.MDDirectoryDialog.SelectedPath = "C:\Program Files (x86)\GOG.com\Ultima Trilogy\Ultima2"
        '
        'AddROMDialog
        '
        Me.AddROMDialog.Description = "Select location of MT-32 ROM's (Either CM32L_CONTROL.ROM & CM32L_PCM.ROM or MT32_" & _
            "CONROL.ROM & MT32_PCM.ROM)"
        '
        'MDForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 340)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "MDForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Martian Dreams"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents InstallMT32Button As System.Windows.Forms.Button
    Friend WithEvents MT32EmulationText As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents AddROMsButton As System.Windows.Forms.Button
    Friend WithEvents ROMStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Ultima6DirectoryTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MDDirectoryDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AddROMDialog As System.Windows.Forms.FolderBrowserDialog
End Class
