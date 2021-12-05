Imports System.IO

Public Class MDForm
    Dim MDDirectories = {"C:\Program Files (x86)\GOG.com\Martian Dreams", "C:\Program Files\GOG.com\Martian Dreams", "C:\GOG Games\Worlds of Ultima - Martian Dreams", "C:\GOG Games\Martian Dreams"}
    Dim MDLocation As String
    Dim MT32Installed As Boolean
    Dim MT32Roms As Boolean


    Public Function SetGameLocation(ByVal directory As String)

        If Dir(directory & "\MARTIAN\MARTIAN.EXE") <> "" Then
            MDLocation = directory
            Ultima6DirectoryTextbox.Text = directory
            AddROMsButton.Visible = True
            InstallMT32Button.Visible = True
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
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SEForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d As String
        Try
            For Each d In MDDirectories
                SetGameLocation(d)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
        If MDLocation = "" Then
            If MDDirectoryDialog.ShowDialog() = DialogResult.OK Then
                If Not (SetGameLocation(MDDirectoryDialog.SelectedPath)) Then
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Computer.FileSystem.CopyFile("Files\DosboxBase.conf", "Files\Patch.conf", True)

        Dim objStreamWriter As StreamWriter

        objStreamWriter = New StreamWriter("Files\Patch.conf", True)
        objStreamWriter.WriteLine("mount c """ & MDLocation & "\MARTIAN""")
        objStreamWriter.WriteLine("c:\")
        objStreamWriter.WriteLine("install.exe")
        objStreamWriter.WriteLine("exit.exe")
        objStreamWriter.Close()

        Shell("Files\Dosbox\DOSBox.exe -conf .\Files\Patch.conf -noconsole ", , True)
        SetGameLocation(MDLocation)
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
            CopyDirectory("Files/Dosbox", MDLocation & "\DOSBOX", True)
            My.Computer.FileSystem.CopyFile("Files\dosboxMARTIAN.conf", MDLocation & "\dosboxMARTIAN.conf", True)
        Else
            CopyDirectory("Files/Dosbox (SVN)", MDLocation & "\DOSBOX", True)
            My.Computer.FileSystem.CopyFile("Files\dosboxMARTIAN.mt32.conf", MDLocation & "\dosboxMARTIAN.conf", True)
            If (Dir("Files\Dosbox (SVN)\CM32L_CONTROL.ROM") <> "") Then
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\CM32L_PCM.ROM", MDLocation & "\CM32L_PCM.ROM", True)
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\CM32L_CONTROL.ROM", MDLocation & "\CM32L_CONTROL.ROM", True)
            ElseIf (Dir("Files\Dosbox (SVN)\MT32_CONTROL.ROM") <> "") Then
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\MT32_PCM.ROM", MDLocation & "\MT32_PCM.ROM", True)
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\MT32_CONTROL.ROM", MDLocation & "\MT32_CONTROL.ROM", True)
            End If
        End If
        SetGameLocation(MDLocation)
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



    Private Sub SEForm_Load_1(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AddROMsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddROMsButton.Click
        If AddROMDialog.ShowDialog() = DialogResult.OK Then
            If Not (CopyMT32Roms(AddROMDialog.SelectedPath)) Then
                MsgBox("ROM's not found in this location.")
            Else
                SetGameLocation(MDLocation)
            End If
        End If
    End Sub
End Class