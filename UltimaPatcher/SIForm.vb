Imports System.IO

Public Class SIForm
    Dim SIDirectories = {"C:\GOG Games\Ultima VII - Complete\SERPENT", "C:\Program Files (x86)\GOG.com\The Complete Ultima VII\Serpent", "C:\Program Files\GOG.com\The Complete Ultima VII\Serpent", "C:\GOG Games\Ultima 7 - Serpent Isle"}
    Dim SILocation As String
    Dim GMInstalled As Boolean
    Dim MT32Roms As Boolean
    Dim MT32Installed As Boolean
    Dim NatregInstalled As Boolean
    Dim EarthquakeInstalled As Boolean

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If SIDirectoryDialog.ShowDialog() = DialogResult.OK Then
            If (SetGameLocation(SIDirectoryDialog.SelectedPath)) Then
                Return
            Else
                MsgBox("Game not found in this location.")
            End If
        End If
    End Sub
    Public Function SetGameLocation(ByVal directory As String)
        Dim lOpenFile As System.IO.StreamReader
        Dim fileText As String = ""
        Dim newline As String

        If Dir(directory & "\SERPENT.COM") <> "" Then
            SILocation = directory
            SIDirectoryTextbox.Text = directory

            If FileComp("Files\SIGM\MT32SFX.DAT", SILocation & "\STATIC\MT32SFX.DAT") Then
                GMInstalled = True
                GMStatus.Text = "Installed"
                GMButton.Text = "Uninstall"
            Else
                GMInstalled = False
                GMStatus.Text = "Not installed"
                GMButton.Text = "Install"
            End If

            If FileComp("Files\NatregSI\TFA.DAT", SILocation & "\STATIC\TFA.DAT") Then
                NatregInstalled = True
                NatregStatus.Text = "Installed"
                NatregButton.Text = "Uninstall"
            Else
                NatregInstalled = False
                NatregStatus.Text = "Not installed"
                NatregButton.Text = "Install"
            End If

            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(SILocation & "\dosboxSERPENT_single.conf")

            EarthquakeInstalled = False

            While Not lOpenFile.EndOfStream

                newline = lOpenFile.ReadLine
                If newline.IndexOf("sifx") <> -1 Then
                    EarthquakeInstalled = True
                End If
            End While

            lOpenFile.Close()

            If EarthquakeInstalled Then
                EarthquakeStatus.Text = "Installed"
                EarthquakeButton.Text = "Uninstall"
            Else
                EarthquakeStatus.Text = "Not installed"
                EarthquakeButton.Text = "Install"
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
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SIForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d As String
        Try
            For Each d In SIDirectories
                SetGameLocation(d)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
        If SILocation = "" Then
            If SIDirectoryDialog.ShowDialog() = DialogResult.OK Then
                If Not (SetGameLocation(SIDirectoryDialog.SelectedPath)) Then
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

    Private Sub GMButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GMButton.Click
        Dim objStreamWriter As StreamWriter

        If GMInstalled Then
            My.Computer.FileSystem.CopyFile("Files\SI_ORIG_MAINMENU.TIM", SILocation & "\STATIC\MAINMENU.TIM", True)
            My.Computer.FileSystem.CopyFile("Files\SI_ORIG_MAINSHP.FLX", SILocation & "\STATIC\MAINSHP.FLX", True)
            My.Computer.FileSystem.CopyFile("Files\SI_ORIG_MT32MUS.DAT", SILocation & "\STATIC\MT32MUS.DAT", True)
            My.Computer.FileSystem.CopyFile("Files\SI_ORIG_MT32SFX.DAT", SILocation & "\STATIC\MT32SFX.DAT", True)
            My.Computer.FileSystem.CopyFile("Files\SI_ORIG_R_SEND.XMI", SILocation & "\STATIC\R_SEND.XMI", True)
            My.Computer.FileSystem.CopyFile("Files\SI_ORIG_R_SINTRO.XMI", SILocation & "\STATIC\R_SINTRO.XMI", True)
            My.Computer.FileSystem.CopyFile("Files\SI_ORIG_R_VALOR.XMI", SILocation & "\STATIC\R_VALOR.XMI", True)
            objStreamWriter = New StreamWriter(SILocation & "\SERPENT.CFG", False)
            objStreamWriter.WriteLine("s 388")
            objStreamWriter.WriteLine("220 7 1 o")
            objStreamWriter.Close()
        Else
            If MT32Installed Then
                MsgBox("Please uninstall the MT-32 patch first")
                Return
            End If
            My.Computer.FileSystem.CopyFile("Files\SIGM\MAINMENU.TIM", SILocation & "\STATIC\MAINMENU.TIM", True)
            My.Computer.FileSystem.CopyFile("Files\SIGM\MAINSHP.FLX", SILocation & "\STATIC\MAINSHP.FLX", True)
            My.Computer.FileSystem.CopyFile("Files\SIGM\MT32MUS.DAT", SILocation & "\STATIC\MT32MUS.DAT", True)
            My.Computer.FileSystem.CopyFile("Files\SIGM\MT32SFX.DAT", SILocation & "\STATIC\MT32SFX.DAT", True)
            My.Computer.FileSystem.CopyFile("Files\SIGM\R_SEND.XMI", SILocation & "\STATIC\R_SEND.XMI", True)
            My.Computer.FileSystem.CopyFile("Files\SIGM\R_SINTRO.XMI", SILocation & "\STATIC\R_SINTRO.XMI", True)
            My.Computer.FileSystem.CopyFile("Files\SIGM\R_VALOR.XMI", SILocation & "\STATIC\R_VALOR.XMI", True)
            objStreamWriter = New StreamWriter(SILocation & "\SERPENT.CFG", False)
            objStreamWriter.WriteLine("r")
            objStreamWriter.WriteLine("220 7 1 o")
            objStreamWriter.Close()
        End If
        SetGameLocation(SILocation)
    End Sub

    Private Sub AddROMsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddROMsButton.Click
        If AddROMDialog.ShowDialog() = DialogResult.OK Then
            If Not (CopyMT32Roms(AddROMDialog.SelectedPath)) Then
                MsgBox("ROM's not found in this location.")
            Else
                SetGameLocation(SILocation)
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
        Dim objStreamWriter As StreamWriter
        If MT32Installed Then
            CopyDirectory("Files/Dosbox", SILocation & "\DOSBOX", True)
            My.Computer.FileSystem.CopyFile("Files\dosboxSERPENT.conf", SILocation & "\dosboxSERPENT.conf", True)
            objStreamWriter = New StreamWriter(SILocation & "\SERPENT.CFG", False)
            objStreamWriter.WriteLine("s 388")
            objStreamWriter.WriteLine("220 7 1 o")
            objStreamWriter.Close()
            SetGameLocation(SILocation)
        Else
            If GMInstalled Then
                MsgBox("Please uninstall the general MIDI patch first")
                Return
            End If
            CopyDirectory("Files/Dosbox (SVN)", SILocation & "\DOSBOX", True)
            My.Computer.FileSystem.CopyFile("Files\dosboxSERPENT.mt32.conf", SILocation & "\dosboxSERPENT.conf", True)
            If (Dir("Files\Dosbox (SVN)\CM32L_CONTROL.ROM") <> "") Then
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\CM32L_PCM.ROM", SILocation & "\CM32L_PCM.ROM", True)
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\CM32L_CONTROL.ROM", SILocation & "\CM32L_CONTROL.ROM", True)
            ElseIf (Dir("Files\Dosbox (SVN)\MT32_CONTROL.ROM") <> "") Then
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\MT32_PCM.ROM", SILocation & "\MT32_PCM.ROM", True)
                My.Computer.FileSystem.CopyFile("Files\Dosbox (SVN)\MT32_CONTROL.ROM", SILocation & "\MT32_CONTROL.ROM", True)
            End If
            objStreamWriter = New StreamWriter(SILocation & "\SERPENT.CFG", False)
            objStreamWriter.WriteLine("r")
            objStreamWriter.WriteLine("220 7 1 o")
            objStreamWriter.Close()
        End If
        SetGameLocation(SILocation)
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

    Private Sub GroupBox4_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub GroupBox3_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub EarthquakeButton_Click(sender As System.Object, e As System.EventArgs) Handles EarthquakeButton.Click

        Dim lOpenFile As System.IO.StreamReader
        Dim fileText As String = ""
        Dim newline As String

        If EarthquakeInstalled Then

            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(SILocation & "\dosboxSERPENT_single.conf")

            While Not lOpenFile.EndOfStream

                newline = lOpenFile.ReadLine
                If newline.IndexOf("sifx.com") = -1 Then
                    fileText = fileText & newline & vbCrLf
                Else
                    fileText = fileText & "serpent.com" & vbCrLf
                End If
            End While
            lOpenFile.Close()
            My.Computer.FileSystem.WriteAllText(SILocation & "\dosboxSERPENT_single.conf", fileText, False, System.Text.Encoding.ASCII)
        Else
            My.Computer.FileSystem.CopyFile("Files\sifx\sifx.com", SILocation & "\sifx.com", True)
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(SILocation & "\dosboxSERPENT_single.conf")

            While Not lOpenFile.EndOfStream

                newline = lOpenFile.ReadLine
                If newline.IndexOf("serpent.com") = -1 Then
                    fileText = fileText & newline & vbCrLf
                Else
                    fileText = fileText & "sifx.com" & vbCrLf
                End If
            End While
            lOpenFile.Close()
            My.Computer.FileSystem.WriteAllText(SILocation & "\dosboxSERPENT_single.conf", fileText, False, System.Text.Encoding.ASCII)
        End If
        SetGameLocation(SILocation)
    End Sub

    Private Sub NatregButton_Click(sender As System.Object, e As System.EventArgs) Handles NatregButton.Click
        If NatregInstalled Then
            My.Computer.FileSystem.CopyFile("Files\NatregSI\ORIG\TFA.DAT", SILocation & "\STATIC\TFA.DAT", True)
        Else
            My.Computer.FileSystem.CopyFile("Files\NatregSI\TFA.DAT", SILocation & "\STATIC\TFA.DAT", True)
        End If
        SetGameLocation(SILocation)
    End Sub
End Class