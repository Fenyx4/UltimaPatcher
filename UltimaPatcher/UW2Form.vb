Imports System.IO
Public Class UW2Form
    Dim UW2Directories = {"C:\Program Files\GOG.com\Ultima Underworld 1 and 2", "C:\Program Files (x86)\GOG.com\Ultima Underworld 1 and 2", "C:\GOG Games\Ultima Underworld 1 and 2\Ultima Underworld 2", "C:\GOG Games\Ultima Underworld 2", "C:\Program Files (x86)\GOG Galaxy\Games\Ultima Underworld 2"}
    Dim UW2Location As String
    Dim GMInstalled As Boolean
    Dim SBSound As Boolean
    Dim Speech As Boolean
    Dim LoadingForm As Boolean
    Dim MT32Roms As Boolean
    Dim MT32Installed As Boolean

    Private Sub UW2Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d As String
        Try
            For Each d In UW2Directories
                SetGameLocation(d)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
        If UW2Location = "" Then
            If UW2DirectoryDialog.ShowDialog() = DialogResult.OK Then
                If Not (SetGameLocation(UW2DirectoryDialog.SelectedPath)) Then
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
    Public Function SetGameLocation(ByVal directory As String)
        If Dir(directory & "\dosboxULTIMA2.conf") <> "" Then
            LoadingForm = True
            UW2Location = directory
            UW2DirectoryTextbox.Text = directory

            If Dir(directory & "\UNDEROM2\SOUND\UWR31.XMI") <> "" Then
                GMInstalled = True
                GMToggleButton.Text = "Uninstall"
                GMStatusLabel.Text = "Installed"
                SoundCombo.Enabled = False
            Else
                GMInstalled = False
                GMToggleButton.Text = "Install"
                GMStatusLabel.Text = "Not installed"
                SoundCombo.Enabled = True
            End If

            If (Dir("Files\Dosbox (SVN)\CM32L_PCM.ROM") <> "" And Dir("Files\Dosbox (SVN)\CM32L_CONTROL.ROM") <> "") Or (Dir("Files\Dosbox (SVN)\MT32_CONTROL.ROM") <> "" And Dir("Files\Dosbox (SVN)\MT32_PCM.ROM") <> "") Then
                MT32Roms = True
                ROMStatus.Text = "ROM's Found"
                AddROMsButton.Visible = False
                InstallMT32Button.Visible = True
                If FileComp("Files\Dosbox (SVN)\dosbox.exe", directory & "\DOSBOX\DOSBox.exe") Then
                    InstallMT32Button.Text = "Uninstall"
                    MT32EmulationText.Text = "Installed"
                    MT32Installed = True
                Else
                    InstallMT32Button.Text = "Install"
                    MT32EmulationText.Text = "Not installed"
                    MT32Installed = False
                End If
            Else
                MT32Roms = False
                ROMStatus.Text = "ROM's Missing"
                AddROMsButton.Visible = True
                MT32EmulationText.Text = "Not Available"
                InstallMT32Button.Visible = False
            End If

            Try
                Dim lOpenFile As System.IO.StreamReader
                lOpenFile = My.Computer.FileSystem.OpenTextFileReader(UW2Location & "\UNDEROM2\DATA\UW.cfg")
                Dim fileText As String
                fileText = lOpenFile.ReadToEnd
                lOpenFile.Close()

                If fileText.IndexOf("4 -1 -1 -1") <> -1 Or fileText.IndexOf("4 7 220 1 sound") <> -1 Then
                    SBSound = True
                    SoundCombo.SelectedIndex = 0
                Else
                    SBSound = False
                    SoundCombo.SelectedIndex = 1
                End If

                If fileText.IndexOf("2 7 220 1 speech") <> -1 Then
                    Speech = True
                    SpeechCombo.SelectedIndex = 0
                Else
                    Speech = False
                    SpeechCombo.SelectedIndex = 1
                End If

            Catch Ax As Exception
            End Try
            LoadingForm = False
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SoundCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoundCombo.SelectedIndexChanged
        If LoadingForm Then Return
        If SBSound Then
            SBSound = False
        Else
            SBSound = True
        End If
        SetSound()
    End Sub

    Private Sub SpeechCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeechCombo.SelectedIndexChanged
        If LoadingForm Then Return
        If Speech Then
            Speech = False
        Else
            Speech = True
        End If
        SetSound()
    End Sub

    Public Sub SetSound()
        Dim fileText As String
        If SBSound And Speech Then
            fileText = "4 -1 -1 -1 sound" & Chr(13) & Chr(10) & "2 7 220 1 speech" & Chr(13) & Chr(10) & "0 cuts"
        Else
            If SBSound Then
                fileText = "4 7 220 1 sound" & Chr(13) & Chr(10) & "-1 -1 -1 -1 speech" & Chr(13) & Chr(10) & "0 cuts"
            Else
                If Speech Then
                    fileText = "5 -1 -1 -1 sound" & Chr(13) & Chr(10) & "2 7 220 1 speech" & Chr(13) & Chr(10) & "0 cuts"
                Else
                    fileText = "5 -1 -1 -1 sound" & Chr(13) & Chr(10) & "-1 -1 -1 -1 speech" & Chr(13) & Chr(10) & "0 cuts"
                End If
            End If
        End If
        IO.File.WriteAllText(UW2Location & "\UNDEROM2\DATA\uw.cfg", fileText)
        SetGameLocation(UW2Location)
    End Sub

    Private Sub GeneralMIDIToggleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GMToggleButton.Click
        If Dir(UW2Location & "\UNDEROM2\SOUND\") = "" Then
            My.Computer.FileSystem.CreateDirectory(UW2Location & "\UNDEROM2\SOUND")
        End If
        If Not GMInstalled Then
            If MT32Installed Then
                MsgBox("Please uninstall the MT-32 patch first")
                Return
            End If
            Dim fileNames = My.Computer.FileSystem.GetFiles("Files\UW2GM", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, UW2Location & "\UNDEROM2\SOUND\" & System.IO.Path.GetFileName(file), True)
            Next
            SBSound = False
        Else
            Dim fileNames = My.Computer.FileSystem.GetFiles("Files\UW2GM", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.DeleteFile(UW2Location & "\UNDEROM2\SOUND\" & System.IO.Path.GetFileName(file), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Next
        End If
        SetSound()
        SetGameLocation(UW2Location)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If UW2DirectoryDialog.ShowDialog() = DialogResult.OK Then
            If (SetGameLocation(UW2DirectoryDialog.SelectedPath)) Then
                Return
            Else
                MsgBox("Game not found in this location.")
            End If
        End If
    End Sub

    Private Sub AddROMsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddROMsButton.Click
        If AddROMDialog.ShowDialog() = DialogResult.OK Then
            If Not (CopyMT32Roms(AddROMDialog.SelectedPath)) Then
                MsgBox("ROM's not found in this location.")
            Else
                SetGameLocation(UW2Location)
            End If
        End If
    End Sub

    Private Function CopyMT32Roms(ByVal Directory As String)
        If (Dir(Directory & "\CM32L_PCM.ROM") <> "" And Dir(Directory & "\CM32L_CONTROL.ROM") <> "") Then
            My.Computer.FileSystem.CopyFile(Directory & "\CM32L_PCM.ROM", "Files\Dosbox (SVN)\CM32L_PCM.ROM", True)
            My.Computer.FileSystem.CopyFile(Directory & "\CM32L_CONTROL.ROM", "Files\Dosbox (SVN)\CM32L_CONTROL.ROM", True)
            Return True
        ElseIf (Dir(Directory & "\MT32_CONTROL.ROM") <> "" And Dir(Directory & "\MT32_PCM.ROM") <> "") Then
            My.Computer.FileSystem.CopyFile(Directory & "\MT32_PCM.ROM", "Files\Dosbox (SVN)\MT32_PCM.ROM", True)
            My.Computer.FileSystem.CopyFile(Directory & "\MT32_CONTROL.ROM", "Files\Dosbox (SVN)\MT32_CONTROL.ROM", True)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub InstallMT32Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstallMT32Button.Click
        If MT32Installed Then
            CopyDirectory("Files/Dosbox", UW2Location & "\DOSBOX", True)
            My.Computer.FileSystem.CopyFile("Files\dosboxULTIMA2.conf", UW2Location & "\dosboxULTIMA2.conf", True)
        Else
            If GMInstalled Then
                MsgBox("Please uninstall the general MIDI patch first")
                Return
            End If
            CopyDirectory("Files/Dosbox (SVN)", UW2Location & "\DOSBOX", True)
            My.Computer.FileSystem.CopyFile("Files\dosboxULTIMA2.mt32.conf", UW2Location & "\dosboxULTIMA2.conf", True)
            If (Dir("Files\Dosbox (SVN)\CM32L_CONTROL.ROM") <> "") Then
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\CM32L_PCM.ROM", UW2Location & "\CM32L_PCM.ROM", True)
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\CM32L_CONTROL.ROM", UW2Location & "\CM32L_CONTROL.ROM", True)
            ElseIf (Dir("Files\Dosbox (SVN)\MT32_CONTROL.ROM") <> "") Then
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\MT32_PCM.ROM", UW2Location & "\MT32_PCM.ROM", True)
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\MT32_CONTROL.ROM", UW2Location & "\MT32_CONTROL.ROM", True)
            End If
        End If
        SetGameLocation(UW2Location)
    End Sub

    Sub CopyDirectory(ByVal SourcePath As String, ByVal DestPath As String, Optional ByVal Overwrite As Boolean = False)
        Dim SourceDir As DirectoryInfo = New DirectoryInfo(SourcePath)
        Dim DestDir As DirectoryInfo = New DirectoryInfo(DestPath)

        ' the source directory must exist, otherwise throw an exception
        If SourceDir.Exists Then
            ' if destination SubDir's parent SubDir does not exist throw an exception
            If Not DestDir.Parent.Exists Then
                Throw New DirectoryNotFoundException _
                    ("Destination directory does not exist: " + DestDir.Parent.FullName)
            End If

            If Not DestDir.Exists Then
                DestDir.Create()
            End If

            ' copy all the files of the current directory
            Dim ChildFile As FileInfo
            For Each ChildFile In SourceDir.GetFiles()
                If Overwrite Then
                    ChildFile.CopyTo(Path.Combine(DestDir.FullName, ChildFile.Name), True)
                Else
                    ' if Overwrite = false, copy the file only if it does not exist
                    ' this is done to avoid an IOException if a file already exists
                    ' this way the other files can be copied anyway...
                    If Not File.Exists(Path.Combine(DestDir.FullName, ChildFile.Name)) Then
                        ChildFile.CopyTo(Path.Combine(DestDir.FullName, ChildFile.Name), False)
                    End If
                End If
            Next

            ' copy all the sub-directories by recursively calling this same routine
            Dim SubDir As DirectoryInfo
            For Each SubDir In SourceDir.GetDirectories()
                CopyDirectory(SubDir.FullName, Path.Combine(DestDir.FullName, _
                    SubDir.Name), Overwrite)
            Next
        Else
            Throw New DirectoryNotFoundException("Source directory does not exist: " + SourceDir.FullName)
        End If
    End Sub
End Class