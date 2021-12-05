Imports System.IO

Public Class Ultima4Form
    Dim U4Directories = {"C:\Program Files\GOG.com\Ultima 4", "C:\Program Files (x86)\GOG.com\Ultima 4", "C:\Program Files (x86)\GOG.com\Ultima Second Trilogy\ULTIMA4", "C:\Program Files\GOG.com\Ultima Second Trilogy\ULTIMA4", "C:\GOG Games\Ultima Second Trilogy\Ultima 4", "C:\GOG Games\Ultima 4", "C:\GOG Games\Ultima 4 - Quest of the Avatar", "C:\Program Files (x86)\GOG Galaxy\Games\Ultima 4"}
    Dim U4Location As String
    Dim EGAUpgradeInstalled As Boolean
    Dim VGAVersion As Boolean
    Dim VGAUpgradeInstalled As Boolean
    Dim HythlothFixInstalled As Boolean
    Dim RunicFontInstalled As Boolean
    Dim U4v101Installed As Boolean
    Dim U4EGADowngradeInstalled As Boolean
    Dim EnhMusicInstalled As Boolean
    Dim EnhMusic2Installed As Boolean
    Dim DosBoxConfName As String
    Dim DosboxExeConfig As String

    Public Function SetGameLocation(ByVal directory As String)

        If Dir(directory & "\justice.ega") <> "" Then
            U4Location = directory
            Ultima4DirectoryTextbox.Text = directory
            If Dir(U4Location & "\dosboxULTIMA4.CONF") <> "" Then
                DosBoxConfName = "\dosboxULTIMA4.CONF"
            Else
                DosBoxConfName = "\dosboxULTIMA4F.CONF"
            End If
            If Dir(U4Location & "\dosboxULTIMA4_single.CONF") <> "" Then
                DosboxExeConfig = "\dosboxULTIMA4_single.CONF"
            Else
                DosboxExeConfig = "\dosboxULTIMA4F_single.CONF"
            End If
            If FileComp("Files\U4VGAUpgrade\love.old", U4Location & "\love.ega") Or FileComp("Files\U4EGADowngrade\SPIRIT.EGA", U4Location & "\SPIRIT.EGA") Then
                VGAUpgradeInstalled = True
                VGAPatchStatus.Text = "Installed"
                VGAPatchButton.Text = "Uninstall Patch"
            Else
                VGAUpgradeInstalled = False
                VGAPatchStatus.Text = "Not Installed"
                VGAPatchButton.Text = "Install Patch"
            End If
            If FileComp("Files\U4EGAUpgrade\honesty.eld", U4Location & "\honesty.ega") Then
                EGAUpgradeInstalled = True
                EGAUpgradeStatusLabel.Text = "Installed"
                EGAUpgradeToggleButton.Text = "Uninstall"
            Else
                EGAUpgradeInstalled = False
                EGAUpgradeStatusLabel.Text = "Not Installed"
                EGAUpgradeToggleButton.Text = "Install"
            End If
            If FileComp("Files\U4_FIXED_HYTHLOTH.DNG", U4Location & "\HYTHLOTH.DNG") Then
                HythlothFixInstalled = True
                HythlothPatchButton.Text = "Uninstall"
                HythlothPatchStatus.Text = "Installed"
            Else
                HythlothFixInstalled = False
                HythlothPatchButton.Text = "Install"
                HythlothPatchStatus.Text = "Not installed"
            End If
            If FileComp("Files\U4Runic\charset.ega", U4Location & "\charset.ega") Then
                RunicFontInstalled = True
                RunicStatus.Text = "Installed"
                RunicButton.Text = "Uninstall"
            Else
                RunicFontInstalled = False
                RunicStatus.Text = "Not installed"
                RunicButton.Text = "Install"
            End If
            If FileComp("Files\U4v101\COVE.TLK", U4Location & "\COVE.TLK") Then
                U4v101Button.Text = "Uninstall"
                U4v101Installed = True
                U4v101Status.Text = "Installed"
            Else
                U4v101Button.Text = "Install"
                U4v101Installed = False
                U4v101Status.Text = "Not installed"
            End If
            If FileComp("Files\U4_NEW_LARGE.XMI", U4Location & "\LARGE.XMI") Then
                EnhMusicInstalled = True
                EnhMusicStatus.Text = "Installed"
                EnhMusicButton.Text = "Uninstall"
                EnhMusic2Button.Enabled = False
                EnhMusicButton.Enabled = True
            Else
                EnhMusicInstalled = False
                EnhMusicStatus.Text = "Not installed"
                EnhMusicButton.Text = "Install"
                EnhMusicButton.Enabled = True
                EnhMusic2Button.Enabled = True
            End If
            If FileComp("Files\U4Music2\LARGE.XMI", U4Location & "\LARGE.XMI") Then
                EnhMusic2Installed = True
                EnhMusic2Status.Text = "Installed"
                EnhMusic2Button.Text = "Uninstall"
                EnhMusicButton.Enabled = False
                EnhMusic2Button.Enabled = True
            Else
                EnhMusic2Installed = False
                EnhMusic2Status.Text = "Not installed"
                EnhMusic2Button.Text = "Install"

            End If
            Dim lOpenFile As System.IO.StreamReader
            Dim fileText As String

            Try
                lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U4Location & DosboxExeConfig)
                fileText = lOpenFile.ReadToEnd
                lOpenFile.Close()
            Catch ex As Exception
                fileText = ""
            End Try
            If FileComp("Files\U4EGADowngrade\SHAPES.VGA", U4Location & "\SHAPES.VGA") Then
                U4EGADowngradeInstalled = True
                MusicButton.Text = "Uninstall"
                MusicStatus.Text = "Installed"
            Else
                U4EGADowngradeInstalled = False
                MusicButton.Text = "Install"
                MusicStatus.Text = "Not installed"
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Ultima4Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d As String
        Try
            For Each d In U4Directories
                SetGameLocation(d)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
        If U4Location = "" Then
            If Ultima4DirectoryDialog.ShowDialog() = DialogResult.OK Then
                If Not (SetGameLocation(Ultima4DirectoryDialog.SelectedPath)) Then
                    MsgBox("Game not found in this location.")
                    MainMenu.Show()
                    Me.Close()
                End If
            Else
                MainMenu.Show()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Ultima4DirectoryDialog.ShowDialog() = DialogResult.OK Then
            If (SetGameLocation(Ultima4DirectoryDialog.SelectedPath)) Then
                Return
            Else
                MsgBox("Game not found in this location.")
            End If
        End If
    End Sub

    Private Sub EGAUpgradeToggleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EGAUpgradeToggleButton.Click
        If VGAUpgradeInstalled Then
            MsgBox("Uninstall the VGA Upgrade first.")
            Return
        End If
        If Not EGAUpgradeInstalled Then
            Dim fileNames = My.Computer.FileSystem.GetFiles("Files\U4EGAUpgrade", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U4Location & "\" & System.IO.Path.GetFileName(file), True)
            Next
        End If
        My.Computer.FileSystem.CopyFile("Files\DosboxBase.conf", "Files\U4EGAPatch.conf", True)

        Dim objStreamWriter As StreamWriter

        objStreamWriter = New StreamWriter("Files\U4EGAPatch.conf", True)
        objStreamWriter.WriteLine("mount c """ & U4Location & """")
        objStreamWriter.WriteLine("c:\")
        objStreamWriter.WriteLine("toggle.bat")
        objStreamWriter.Close()
        Shell("Files\Dosbox\DOSBox.exe -conf .\Files\U4EGAPatch.conf -noconsole ", , True)
        If RunicFontInstalled Then
            My.Computer.FileSystem.CopyFile("Files\U4Runic\charset.ega", U4Location & "\charset.ega", True)
            My.Computer.FileSystem.CopyFile("Files\U4Runic\charset.vga", U4Location & "\charset.vga", True)
        End If
        SetGameLocation(U4Location)
    End Sub


    Private Sub VGAPatchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VGAPatchButton.Click
        If EGAUpgradeInstalled Then
            MsgBox("Uninstall the EGA Upgrade first.")
            Return
        End If
        If U4EGADowngradeInstalled Then
            MsgBox("Uninstall the EGA Graphics Patch first.")
            Return
        End If
        If Not VGAUpgradeInstalled Then
            If (MsgBox("You must create your party in the game before installing this patch. Continue installing?", MsgBoxStyle.YesNo) = MsgBoxResult.No) Then Return
            Dim fileNames = My.Computer.FileSystem.GetFiles("Files\U4VGAUpgrade", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U4Location & "\" & System.IO.Path.GetFileName(file), True)
            Next
        End If
        My.Computer.FileSystem.CopyFile("Files\DosboxBase.conf", "Files\U4VGAPatch.conf", True)

        Dim objStreamWriter As StreamWriter
        Dim lOpenFile As System.IO.StreamReader
        Dim fileText, fileText2 As String

        Try
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U4Location & DosBoxConfName)
            fileText = lOpenFile.ReadToEnd
            lOpenFile.Close()
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U4Location & DosboxExeConfig)
            fileText2 = lOpenFile.ReadToEnd
            lOpenFile.Close()
        Catch ex As Exception
            fileText = ""
            fileText2 = ""
        End Try

        objStreamWriter = New StreamWriter("Files\U4VGAPatch.conf", True)
        objStreamWriter.WriteLine("mount c """ & U4Location & """")
        objStreamWriter.WriteLine("c:")
        If VGAUpgradeInstalled Then
            objStreamWriter.WriteLine("vuninst.bat")
            fileText = fileText.Replace("cycles=8000", "cycles=500")
            fileText2 = fileText2.Replace("cycles=8000", "cycles=500")
        Else
            objStreamWriter.WriteLine("vinst.bat")
            fileText = fileText.Replace("cycles=500", "cycles=8000")
            fileText2 = fileText2.Replace("cycles=500", "cycles=8000")
        End If
        My.Computer.FileSystem.WriteAllText(U4Location & DosBoxConfName, fileText, False, System.Text.Encoding.ASCII)
        My.Computer.FileSystem.WriteAllText(U4Location & DosboxExeConfig, fileText2, False, System.Text.Encoding.ASCII)

        If RunicFontInstalled Then
            My.Computer.FileSystem.CopyFile("Files\U4Runic\charset.vga", U4Location & "\charset.vga", True)
            My.Computer.FileSystem.CopyFile("Files\U4Runic\charset.ega", U4Location & "\charset.ega", True)
        End If

        objStreamWriter.Close()
        Shell("Files\Dosbox\DOSBox.exe -conf .\Files\U4VGAPatch.conf -noconsole ", , True)
        SetGameLocation(U4Location)
    End Sub

    Private Sub HythlothPatchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HythlothPatchButton.Click
        If HythlothFixInstalled Then
            My.Computer.FileSystem.CopyFile("Files\U4_ORIG_HYTHLOTH.DNG", U4Location & "\HYTHLOTH.DNG", True)
        Else
            My.Computer.FileSystem.CopyFile("Files\U4_FIXED_HYTHLOTH.DNG", U4Location & "\HYTHLOTH.DNG", True)
        End If
        SetGameLocation(U4Location)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MainMenu.Show()
        MainMenu.Focus()
        Me.Close()
    End Sub

    Private Sub RunicButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunicButton.Click
        If RunicFontInstalled Then
            If EGAUpgradeInstalled Then
                My.Computer.FileSystem.CopyFile("Files\U4EGAUpgrade\charset.eld", U4Location & "\charset.ega", True)
            Else
                My.Computer.FileSystem.CopyFile("Files\U4_ORIG_CHARSET.EGA", U4Location & "\charset.ega", True)
            End If
            My.Computer.FileSystem.CopyFile("Files\U4VGAUpgrade\charset.vga", U4Location & "\charset.vga", True)
        Else
            My.Computer.FileSystem.CopyFile("Files\U4Runic\charset.vga", U4Location & "\charset.vga", True)
            My.Computer.FileSystem.CopyFile("Files\U4Runic\charset.ega", U4Location & "\charset.ega", True)
        End If
        SetGameLocation(U4Location)
    End Sub

    Private Sub U4v101Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U4v101Button.Click
        If Not U4v101Installed Then
            Dim fileNames = My.Computer.FileSystem.GetFiles("Files\U4v101", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U4Location & "\" & System.IO.Path.GetFileName(file), True)
            Next
        Else
            Dim fileNames = My.Computer.FileSystem.GetFiles("Files\U4v101\ORIG", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U4Location & "\" & System.IO.Path.GetFileName(file), True)
            Next
        End If
        SetGameLocation(U4Location)
    End Sub

    Private Sub MusicButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicButton.Click
        If Not VGAUpgradeInstalled Then
            MsgBox("Install the VGA Upgrade first.")
            Return
        End If
        If Not U4EGADowngradeInstalled Then
            Dim fileNames = My.Computer.FileSystem.GetFiles("Files\U4EGADowngrade", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U4Location & "\" & System.IO.Path.GetFileName(file), True)
            Next
        Else
            Dim fileNames = My.Computer.FileSystem.GetFiles("Files\U4VGAUpgrade", FileIO.SearchOption.SearchTopLevelOnly, "*.ega")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U4Location & "\" & System.IO.Path.GetFileName(file), True)
            Next
            fileNames = My.Computer.FileSystem.GetFiles("Files\U4VGAUpgrade", FileIO.SearchOption.SearchTopLevelOnly, "*.vga")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U4Location & "\" & System.IO.Path.GetFileName(file), True)
            Next
        End If
        SetGameLocation(U4Location)
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Shell("explorer.exe http://www.moongates.com/u4/upgrade/Upgrade.htm")
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Shell("explorer.exe http://www.moongates.com/u4/upgrade/Upgrade.htm")
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Label26_Click(sender As System.Object, e As System.EventArgs) Handles Label26.Click

    End Sub

    Private Sub EnhMusicButton_Click(sender As System.Object, e As System.EventArgs) Handles EnhMusicButton.Click
        If EnhMusicInstalled Then
            My.Computer.FileSystem.CopyFile("Files\U4_ORIG_LARGE.XMI", U4Location & "\LARGE.XMI", True)
        Else
            My.Computer.FileSystem.CopyFile("Files\U4_NEW_LARGE.XMI", U4Location & "\LARGE.XMI", True)
        End If
        SetGameLocation(U4Location)
    End Sub

    Private Sub EnhMusic2Button_Click(sender As System.Object, e As System.EventArgs) Handles EnhMusic2Button.Click
        If EnhMusic2Installed Then
            My.Computer.FileSystem.CopyFile("Files\U4_ORIG_LARGE.XMI", U4Location & "\LARGE.XMI", True)
            My.Computer.FileSystem.CopyFile("Files\U4Music2\OLD_ULTIMA.COM", U4Location & "\ULTIMA.COM", True)
        Else
            My.Computer.FileSystem.CopyFile("Files\U4Music2\LARGE.XMI", U4Location & "\LARGE.XMI", True)
            My.Computer.FileSystem.CopyFile("Files\U4Music2\ULTIMA.COM", U4Location & "\ULTIMA.COM", True)
        End If
        SetGameLocation(U4Location)
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Shell("explorer.exe http://sacredbacon.com/ultima")
    End Sub

    Private Sub Label23_Click(sender As System.Object, e As System.EventArgs) Handles Label23.Click

    End Sub

    Private Sub Label28_Click(sender As System.Object, e As System.EventArgs) Handles Label28.Click

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Shell("explorer.exe http://exodus.voyd.net/")
    End Sub
End Class