<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ultima3Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ultima3Form))
        Me.GraphicsModeButton = New System.Windows.Forms.Button()
        Me.PatchStatus = New System.Windows.Forms.Label()
        Me.PatchButton = New System.Windows.Forms.Button()
        Me.Ultima3DirectoryTextbox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Ultima3DirectoryDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.AltEGAToggleButton = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AltEGAStatusLabel = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.UltimoreButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UltimoreStatus = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GraphicsModeButton
        '
        Me.GraphicsModeButton.Location = New System.Drawing.Point(440, 19)
        Me.GraphicsModeButton.Name = "GraphicsModeButton"
        Me.GraphicsModeButton.Size = New System.Drawing.Size(118, 24)
        Me.GraphicsModeButton.TabIndex = 15
        Me.GraphicsModeButton.Text = "Button2"
        Me.GraphicsModeButton.UseVisualStyleBackColor = True
        Me.GraphicsModeButton.Visible = False
        '
        'PatchStatus
        '
        Me.PatchStatus.AutoSize = True
        Me.PatchStatus.Location = New System.Drawing.Point(67, 27)
        Me.PatchStatus.Name = "PatchStatus"
        Me.PatchStatus.Size = New System.Drawing.Size(72, 13)
        Me.PatchStatus.TabIndex = 14
        Me.PatchStatus.Text = "(Not Installed)"
        '
        'PatchButton
        '
        Me.PatchButton.Location = New System.Drawing.Point(564, 19)
        Me.PatchButton.Name = "PatchButton"
        Me.PatchButton.Size = New System.Drawing.Size(118, 24)
        Me.PatchButton.TabIndex = 12
        Me.PatchButton.Text = "Button2"
        Me.PatchButton.UseVisualStyleBackColor = True
        '
        'Ultima3DirectoryTextbox
        '
        Me.Ultima3DirectoryTextbox.Location = New System.Drawing.Point(54, 24)
        Me.Ultima3DirectoryTextbox.Name = "Ultima3DirectoryTextbox"
        Me.Ultima3DirectoryTextbox.ReadOnly = True
        Me.Ultima3DirectoryTextbox.Size = New System.Drawing.Size(633, 20)
        Me.Ultima3DirectoryTextbox.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(547, 50)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(140, 20)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Change Game Directory"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Ultima3DirectoryDialog
        '
        Me.Ultima3DirectoryDialog.Description = "Select Ultima 3 Directory"
        Me.Ultima3DirectoryDialog.SelectedPath = "C:\Program Files (x86)\GOG.com\Ultima Trilogy\Ultima2"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Ultima3DirectoryTextbox)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(702, 81)
        Me.GroupBox2.TabIndex = 16
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PatchButton)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.GraphicsModeButton)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.PatchStatus)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(702, 243)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(566, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(116, 13)
        Me.LinkLabel1.TabIndex = 16
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Tag = "http://exodus.voyd.net"
        Me.LinkLabel1.Text = "http://exodus.voyd.net"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 179)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Instructions:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(70, 179)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(612, 52)
        Me.TextBox2.TabIndex = 10
        Me.TextBox2.Text = resources.GetString("TextBox2.Text")
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Status:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(70, 55)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(612, 118)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Upgrade Patch (Version 3.3)"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(639, 569)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.AltEGAToggleButton)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.AltEGAStatusLabel)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.TextBox4)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 358)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(702, 106)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GroupBox3"
        '
        'AltEGAToggleButton
        '
        Me.AltEGAToggleButton.Location = New System.Drawing.Point(564, 19)
        Me.AltEGAToggleButton.Name = "AltEGAToggleButton"
        Me.AltEGAToggleButton.Size = New System.Drawing.Size(118, 24)
        Me.AltEGAToggleButton.TabIndex = 12
        Me.AltEGAToggleButton.Text = "Button2"
        Me.AltEGAToggleButton.UseVisualStyleBackColor = True
        Me.AltEGAToggleButton.Visible = False
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
        'AltEGAStatusLabel
        '
        Me.AltEGAStatusLabel.AutoSize = True
        Me.AltEGAStatusLabel.Location = New System.Drawing.Point(67, 27)
        Me.AltEGAStatusLabel.Name = "AltEGAStatusLabel"
        Me.AltEGAStatusLabel.Size = New System.Drawing.Size(72, 13)
        Me.AltEGAStatusLabel.TabIndex = 14
        Me.AltEGAStatusLabel.Text = "(Not Installed)"
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
        Me.TextBox4.Size = New System.Drawing.Size(612, 39)
        Me.TextBox4.TabIndex = 6
        Me.TextBox4.Text = resources.GetString("TextBox4.Text")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(147, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Alternative EGA Tileset Patch"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.LinkLabel3)
        Me.GroupBox4.Controls.Add(Me.UltimoreButton)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.UltimoreStatus)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.TextBox3)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 471)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(702, 88)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "GroupBox4"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(435, 0)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(261, 13)
        Me.LinkLabel3.TabIndex = 22
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Tag = "https://daemon-master.itch.io/ultimore-a-world-divided"
        Me.LinkLabel3.Text = "https://daemon-master.itch.io/ultimore-a-world-divided"
        '
        'UltimoreButton
        '
        Me.UltimoreButton.Location = New System.Drawing.Point(564, 16)
        Me.UltimoreButton.Name = "UltimoreButton"
        Me.UltimoreButton.Size = New System.Drawing.Size(118, 24)
        Me.UltimoreButton.TabIndex = 12
        Me.UltimoreButton.Text = "Install"
        Me.UltimoreButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Description:"
        '
        'UltimoreStatus
        '
        Me.UltimoreStatus.AutoSize = True
        Me.UltimoreStatus.Location = New System.Drawing.Point(67, 27)
        Me.UltimoreStatus.Name = "UltimoreStatus"
        Me.UltimoreStatus.Size = New System.Drawing.Size(72, 13)
        Me.UltimoreStatus.TabIndex = 14
        Me.UltimoreStatus.Text = "(Not Installed)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Status:"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(70, 55)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(612, 26)
        Me.TextBox3.TabIndex = 6
        Me.TextBox3.Text = "Unofficial expansion created by Joel Fenton in 1985 and ported to PC by Daemon Ma" &
    "ster in 2022."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Ultimore: A World Divided"
        '
        'Ultima3Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 597)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Ultima3Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ultima 3"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GraphicsModeButton As System.Windows.Forms.Button
    Friend WithEvents PatchStatus As System.Windows.Forms.Label
    Friend WithEvents PatchButton As System.Windows.Forms.Button
    Friend WithEvents Ultima3DirectoryTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Ultima3DirectoryDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents AltEGAToggleButton As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AltEGAStatusLabel As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents UltimoreButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents UltimoreStatus As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents LinkLabel3 As LinkLabel
End Class
