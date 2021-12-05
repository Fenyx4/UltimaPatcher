Imports System.IO


Public Class U6Form
    Dim U6Directories = {"C:\Program Files (x86)\GOG.com\Ultima Second Trilogy\ULTIMA6", "C:\Program Files\GOG.com\Ultima Second Trilogy\ULTIMA6", "C:\GOG Games\Ultima Second Trilogy\Ultima 6", "C:\GOG Games\Ultima 6", "C:\Program Files (x86)\GOG Galaxy\Games\Ultima 6"}
    Dim U5Directories = {"C:\Program Files (x86)\GOG.com\Ultima Second Trilogy\ULTIMA5", "C:\Program Files\GOG.com\Ultima Second Trilogy\ULTIMA5", "C:\GOG Games\Ultima Second Trilogy\Ultima 5", "C:\GOG Games\Ultima 5", "C:\Program Files (x86)\GOG Galaxy\Games\Ultima 5"}
    Dim U6Location As String
    Dim GMInstalled As Boolean
    Dim MT32Roms As Boolean
    Dim MT32Installed As Boolean
    Dim DosboxExeConfig As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Ultima6DirectoryDialog.ShowDialog() = DialogResult.OK Then
            If (SetGameLocation(Ultima6DirectoryDialog.SelectedPath)) Then
                Return
            Else
                MsgBox("Game not found in this location.")
            End If
        End If
    End Sub
    Public Function SetGameLocation(ByVal directory As String)

        If Dir(directory & "\ULTIMA6.EXE") <> "" Then
            U6Location = directory
            Ultima6DirectoryTextbox.Text = directory
            If Dir(U6Location & "\dosboxULTIMA6_single.CONF") <> "" Then
                DosboxExeConfig = "\dosboxULTIMA6_single.CONF"
            Else
                DosboxExeConfig = "\dosboxULTIMA6.conf"
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

            If FileComp("Files\U6_GM_MIDI.DAT", U6Location & "\MIDI.DAT") Then
                GMInstalled = True
                GMStatus.Text = "Installed"
                GMButton.Text = "Uninstall"
            Else
                GMInstalled = False
                GMStatus.Text = "Not installed"
                GMButton.Text = "Install"
            End If

            Return True
        Else
            Return False
        End If
    End Function

    Private Sub PartyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartyButton.Click
        Dim d As String
        For Each d In U5Directories
            If Dir(d & "\SAVED.GAM") <> "" Then Ultima5DirectoryDialog.SelectedPath = d
        Next
        If Ultima5DirectoryDialog.ShowDialog() = DialogResult.OK Then
            If Not (MountU5(Ultima5DirectoryDialog.SelectedPath)) Then
                MsgBox("Save not found in this location.")
            Else
                MsgBox("Update Complete. Start Ultima 6, select Transfer Character and select the A drive.")
            End If
        End If
    End Sub
    Public Function MountU5(ByVal directory As String)

        Dim Systemdrive As String
        Systemdrive = System.Environment.SystemDirectory.Substring(0, 3)
        If Dir(directory & "\SAVED.GAM") <> "" Then
            If My.Computer.FileSystem.GetFileInfo(directory & "\SAVED.GAM").LastWriteTime.Year < 1990 Then
                If Dir(Systemdrive & "Users\" & GetUserName() & "\AppData\Local\VirtualStore\" & directory.Substring(3) & "\SAVED.GAM") <> "" Then
                    If My.Computer.FileSystem.GetFileInfo(Systemdrive & "Users\" & GetUserName() & "\AppData\Local\VirtualStore\" & directory.Substring(3) & "\SAVED.GAM").LastWriteTime.Year < 1990 Then
                        Return False
                    Else
                        directory = Systemdrive & "\Users\" & GetUserName() & "\AppData\Local\VirtualStore\" & directory.Substring(3)
                    End If
                Else
                    Return False
                End If
            End If

            Dim lOpenFile As System.IO.StreamReader
            Dim fileText As String
            Dim newline As String
            fileText = ""
            Try
                lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U6Location & DosboxExeConfig)

                While Not lOpenFile.EndOfStream

                    newline = lOpenFile.ReadLine
                    If newline.IndexOf("mount a") = -1 Then
                        fileText = fileText & newline & vbCrLf
                    End If
                    If newline = "c:" Then
                        fileText = fileText & "mount a """ & directory & """" & vbCrLf
                    End If
                End While
                lOpenFile.Close()
                My.Computer.FileSystem.WriteAllText(U6Location & DosboxExeConfig, fileText, False, System.Text.Encoding.ASCII)
            Catch exp As System.Exception
            End Try
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub U6Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d As String
        Try
            For Each d In U6Directories
                SetGameLocation(d)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
        If U6Location = "" Then
            If Ultima6DirectoryDialog.ShowDialog() = DialogResult.OK Then
                If Not (SetGameLocation(Ultima6DirectoryDialog.SelectedPath)) Then
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
        objStreamWriter.WriteLine("mount c """ & U6Location & """")
        objStreamWriter.WriteLine("c:\")
        objStreamWriter.WriteLine("install.exe")
        objStreamWriter.WriteLine("exit.exe")
        objStreamWriter.Close()

        Shell("Files\Dosbox\DOSBox.exe -conf .\Files\Patch.conf -noconsole ", , True)
        SetGameLocation(U6Location)
    End Sub

    Private Sub GMButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GMButton.Click
        If GMInstalled Then
            My.Computer.FileSystem.CopyFile("Files\U6_ORIG_MIDI.DAT", U6Location & "\MIDI.DAT", True)
        Else
            If MT32Installed Then
                MsgBox("Please uninstall the MT-32 patch first")
                Return
            End If
            My.Computer.FileSystem.CopyFile("Files\U6_GM_MIDI.DAT", U6Location & "\MIDI.DAT", True)
        End If
        SetGameLocation(U6Location)
    End Sub

    Private Sub AddROMsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddROMsButton.Click
        If AddROMDialog.ShowDialog() = DialogResult.OK Then
            If Not (CopyMT32Roms(AddROMDialog.SelectedPath)) Then
                MsgBox("ROM's not found in this location.")
            Else
                SetGameLocation(U6Location)
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

        REM get the mount status if any first
        Dim mount As String = ""
        Dim lOpenFile As System.IO.StreamReader
        Dim fileText As String
        Dim newline As String
        fileText = ""
        Try
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U6Location & "\dosboxULTIMA6.CONF")

            While Not lOpenFile.EndOfStream

                newline = lOpenFile.ReadLine
                If newline.IndexOf("mount a") <> -1 Then
                    mount = newline
                End If
            End While
            lOpenFile.Close()
        Catch exp As System.Exception
        End Try

        If MT32Installed Then
            CopyDirectory("Files/Dosbox", U6Location & "\DOSBOX", True)
            My.Computer.FileSystem.CopyFile("Files\dosboxULTIMA6.conf", U6Location & "\dosboxULTIMA6.conf", True)
            FixU4(False)
            FixU5(False)
        Else
            If GMInstalled Then
                MsgBox("Please uninstall the general MIDI patch first")
                Return
            End If
            CopyDirectory("Files/Dosbox (SVN)", U6Location & "\DOSBOX", True)
            My.Computer.FileSystem.CopyFile("Files\dosboxULTIMA6.mt32.conf", U6Location & "\dosboxULTIMA6.conf", True)
            If (Dir("Files\Dosbox (SVN)\CM32L_CONTROL.ROM") <> "") Then
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\CM32L_PCM.ROM", U6Location & "\CM32L_PCM.ROM", True)
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\CM32L_CONTROL.ROM", U6Location & "\CM32L_CONTROL.ROM", True)
            ElseIf (Dir("Files\Dosbox (SVN)\MT32_CONTROL.ROM") <> "") Then
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\MT32_PCM.ROM", U6Location & "\MT32_PCM.ROM", True)
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\MT32_CONTROL.ROM", U6Location & "\MT32_CONTROL.ROM", True)
            End If
            FixU4(True)
            FixU5(True)
        End If

        If mount <> "" Then
            fileText = ""
            Try
                lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U6Location & "\dosboxULTIMA6.CONF")

                While Not lOpenFile.EndOfStream

                    newline = lOpenFile.ReadLine
                    If newline.IndexOf("mount a") = -1 Then
                        fileText = fileText & newline & vbCrLf
                    End If
                    If newline = "c:" Then
                        fileText = fileText & mount & vbCrLf
                    End If
                End While
                lOpenFile.Close()
                My.Computer.FileSystem.WriteAllText(U6Location & "\dosboxULTIMA6.CONF", fileText, False, System.Text.Encoding.ASCII)
            Catch exp As System.Exception
            End Try
        End If
        SetGameLocation(U6Location)
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

    Private Sub FixU4(ByVal svnInstalled As Boolean)
        REM need to read values for cycles and executable used then copy over the default config and replace as appropriate
        Dim cycles As String
        Dim lOpenFile As System.IO.StreamReader
        Dim fileText As String

        Try
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U6Location & "\..\ULTIMA4\dosboxULTIMA4.conf")
            fileText = lOpenFile.ReadToEnd
            lOpenFile.Close()
        Catch ex As Exception
            Exit Sub
        End Try

        cycles = fileText.Substring(fileText.IndexOf("cycles="), fileText.IndexOf(vbCr, fileText.IndexOf("cycles=")) - fileText.IndexOf("cycles="))

        If svnInstalled Then
            My.Computer.FileSystem.CopyFile("Files\dosboxULTIMA4.mt32.conf", U6Location & "\..\ULTIMA4\dosboxULTIMA4.conf", True)
        Else
            My.Computer.FileSystem.CopyFile("Files\dosboxULTIMA4.conf", U6Location & "\..\ULTIMA4\dosboxULTIMA4.conf", True)
        End If

        Try
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U6Location & "\..\ULTIMA4\dosboxULTIMA4.conf")
            fileText = lOpenFile.ReadToEnd
            lOpenFile.Close()
        Catch ex As Exception
            fileText = ""
        End Try

        fileText = fileText.Replace("cycles=500", cycles)
        My.Computer.FileSystem.WriteAllText(U6Location & "\..\ULTIMA4\dosboxULTIMA4.conf", fileText, False, System.Text.Encoding.ASCII)
    End Sub
    Private Sub FixU5(ByVal svnInstalled As Boolean)
        REM need to read check executable used then copy over the default config and replace as appropriate
        Dim lOpenFile As System.IO.StreamReader
        Dim fileText As String

        Try
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U6Location & "\..\ULTIMA5\dosboxULTIMA5.conf")
            fileText = lOpenFile.ReadToEnd
            lOpenFile.Close()
        Catch ex As Exception
            Exit Sub
        End Try


        If svnInstalled Then
            My.Computer.FileSystem.CopyFile("Files\dosboxULTIMA5.mt32.conf", U6Location & "\..\ULTIMA5\dosboxULTIMA5.conf", True)
        Else
            My.Computer.FileSystem.CopyFile("Files\dosboxULTIMA5.conf", U6Location & "\..\ULTIMA5\dosboxULTIMA5.conf", True)
        End If

        Try
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U6Location & "\..\ULTIMA5\dosboxULTIMA5.conf")
            fileText = lOpenFile.ReadToEnd
            lOpenFile.Close()
        Catch ex As Exception
            fileText = ""
        End Try

        My.Computer.FileSystem.WriteAllText(U6Location & "\..\ULTIMA5\dosboxULTIMA5.conf", fileText, False, System.Text.Encoding.ASCII)
    End Sub
End Class