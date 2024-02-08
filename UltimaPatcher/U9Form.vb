﻿Imports System.IO
Imports System.Net
Imports Octodiff.Core
Imports Octodiff.Diagnostics

Public Class U9Form
    Dim U9Directories = {"C:\Program Files (x86)\GOG.com\Ultima IX - Ascension", "C:\Program Files\GOG.com\Ultima IX - Ascension", "C:\GOG Games\Ultima IX - Ascension", "C:\GOG Games\Ultima 9", "C:\Program Files (x86)\GOG Galaxy\Games\Ultima 9"}
    Dim U9Location As String
    Dim U9VSLocation As String
    Dim U9OptionsLocation As String
    Dim screenWidth As Integer
    Dim screenHeight As Integer
    Dim rasterizer As Integer
    Dim colorDepth As Integer
    Dim FWInstalled As Boolean
    Dim LoadingForm As Boolean
    Dim DialogInstalled As Boolean
    Dim MonEcoInstalled As Boolean
    Dim DownloadingBB As Boolean
    Dim BBInstalled As Boolean
    Dim BBDownloaded As Boolean
    Dim DownloadingLanguagePacks As Boolean
    Dim LanguagePacksDownloaded As List(Of Boolean)
    Dim FogOn As Boolean

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Ultima9DirectoryDialog.ShowDialog() = DialogResult.OK Then
            If (SetGameLocation(Ultima9DirectoryDialog.SelectedPath)) Then
                Return
            Else
                MsgBox("Game not found in this location.")
            End If
        End If
    End Sub
    Public Function SetGameLocation(ByVal directory As String)

        Dim lOpenFile As System.IO.StreamReader
        Dim fileText As String = ""
        Dim Systemdrive As String
        Systemdrive = System.Environment.SystemDirectory.Substring(0, 3)


        If Dir(directory & "\u9.exe") <> "" Then
            BBStatusLabel.Text = "Not Installed"
            LoadingForm = True
            U9Location = directory
            Ultima9DirectoryTextbox.Text = directory

            ' Save the original file for later use...
            If Not File.Exists("Files\u9.exe") Then
                FileCopy(U9Location & "\u9.exe", "Files\u9.exe")
            End If

            If DownloadingLanguagePacks Then
                LanguageComboBox.Enabled = False
                DownloadLanguagePacksButton.Text = "Downloading"
                ProgressBar1.Visible = True

                SpeechInstallButton.Visible = False
                TextInstallButton.Visible = False
            Else
                If LanguageComboBox.SelectedIndex <> -1 Then
                    If System.IO.Directory.Exists("Files\" & LanguageComboBox.SelectedItem) Then
                        LanguagePacksDownloaded(LanguageComboBox.SelectedIndex) = True
                        TextInstallButton.Visible = True
                        SpeechInstallButton.Visible = True
                        Dim somethingInstalled = False

                        If FileComp("Files\" & LanguageComboBox.SelectedItem & "\static\TYPENAME.FLX", U9Location & "\static\TYPENAME.FLX") _
                              Or (FileComp("Files\U9Fanpatch160\TYPENAME.FLX", U9Location & "\static\TYPENAME.FLX") AndAlso LanguageComboBox.SelectedItem = "En") Then
                            LanguageComboBox.Enabled = True
                            TextInstallButton.Enabled = False
                            TextInstallButton.Text = "Installed"
                            somethingInstalled = True
                            ProgressBar1.Visible = False
                        ElseIf Not System.IO.Directory.Exists("Files\" & LanguageComboBox.SelectedItem & "\static") Then
                            LanguageComboBox.Enabled = True
                            TextInstallButton.Enabled = False
                            TextInstallButton.Text = "Not Available"
                            ProgressBar1.Visible = False
                        Else
                            LanguageComboBox.Enabled = True
                            TextInstallButton.Enabled = True
                            TextInstallButton.Text = "Install"
                            ProgressBar1.Visible = False
                        End If

                        If FileComp("Files\" & LanguageComboBox.SelectedItem & "\Movies\ambush.dat", U9Location & "\Movies\ambush.dat") Then
                            LanguageComboBox.Enabled = True
                            SpeechInstallButton.Enabled = False
                            SpeechInstallButton.Text = "Installed"
                            somethingInstalled = True
                            ProgressBar1.Visible = False
                        ElseIf Not System.IO.Directory.Exists("Files\" & LanguageComboBox.SelectedItem & "\Movies") Then
                            LanguageComboBox.Enabled = True
                            SpeechInstallButton.Enabled = False
                            SpeechInstallButton.Text = "Not Available"
                            ProgressBar1.Visible = False
                        Else
                            LanguageComboBox.Enabled = True
                            SpeechInstallButton.Enabled = True
                            SpeechInstallButton.Text = "Install"
                            ProgressBar1.Visible = False
                        End If

                        DownloadLanguagePacksButton.Visible = False
                        DownloadLanguagePacksButton.Enabled = False
                    Else
                        If Dir("Files\" & LanguageComboBox.SelectedItem & ".zip") <> "" Then
                            UnZipLanguagePack()
                            LanguagePacksDownloaded(LanguageComboBox.SelectedIndex) = True
                            DownloadLanguagePacksButton.Visible = False
                            DownloadLanguagePacksButton.Enabled = False
                            TextInstallButton.Visible = True
                            SpeechInstallButton.Visible = True
                            TextInstallButton.Enabled = True
                            SpeechInstallButton.Enabled = True
                            ProgressBar1.Visible = False
                            SetGameLocation(U9Location)
                        Else
                            LanguagePacksDownloaded(LanguageComboBox.SelectedIndex) = False
                            DownloadLanguagePacksButton.Visible = True
                            DownloadLanguagePacksButton.Enabled = True
                            DownloadLanguagePacksButton.Text = "Download"
                            TextInstallButton.Visible = False
                            TextInstallButton.Enabled = False
                            SpeechInstallButton.Visible = False
                            SpeechInstallButton.Enabled = False
                            ProgressBar1.Visible = False
                        End If
                    End If

                    Dim textFound = False
                    Dim speechFound = False
                    For Each language In LanguageComboBox.Items
                        If System.IO.Directory.Exists("Files\" & language) Then
                            If FileComp("Files\" & language & "\static\TYPENAME.FLX", U9Location & "\static\TYPENAME.FLX") Then
                                LanguageTextLabel.Text = "Current Text: " & language
                                textFound = True
                            End If

                            If FileComp("Files\" & language & "\Movies\ambush.dat", U9Location & "\Movies\ambush.dat") Then
                                LanguageSpeechLabel.Text = "Current Speech: " & language
                                speechFound = True
                            End If
                        End If
                    Next

                    If FileComp("Files\U9Fanpatch160\TYPENAME.FLX", U9Location & "\static\TYPENAME.FLX") Then
                        LanguageTextLabel.Text = "Current Text: En"
                        textFound = True
                    End If

                    If Not textFound Then
                        LanguageTextLabel.Text = "Current Text: Unknown"
                    End If

                    If Not speechFound Then
                        LanguageSpeechLabel.Text = "Current Speech: Unknown"
                    End If
                End If
            End If

            If DownloadingBB Then
                BBInstallButton.Visible = False
                FogButton.Visible = False
                DownloadBBButon.Text = "Downloading"
                BBStatusLabel.Text = "Downloading"
                ProgressBar2.Visible = True
            Else
                If Dir("Files\BB2011R3.cmd") <> "" Then
                    BBDownloaded = True
                    BBInstallButton.Visible = True
                    FogButton.Visible = True
                    DownloadBBButon.Visible = False
                    ProgressBar2.Visible = False
                Else
                    If Dir("Files/BeautifulBritannia2011R3.zip") <> "" Then
                        UnZipBB()
                        BBDownloaded = True
                        BBInstallButton.Visible = True
                        FogButton.Visible = True
                        DownloadBBButon.Visible = False
                        ProgressBar2.Visible = False
                    Else
                        BBDownloaded = False
                        BBInstallButton.Visible = False
                        FogButton.Visible = False
                        DownloadBBButon.Visible = True
                        ProgressBar2.Visible = False
                    End If
                End If
            End If

            If Dir(U9Location & "\U9.exe.bak") <> "" Then
                FogOn = False
                FogButton.Text = "Turn Fog On"
            Else
                FogOn = True
                FogButton.Text = "Turn Fog Off"
            End If

            If BBDownloaded Then
                If FileComp(U9Location & "\static\fixed.9", "Files\BB\BB2011R3\static\fixed.9") Then
                    BBInstalled = True
                    BBInstallButton.Text = "Uninstall"
                    BBStatusLabel.Text = "Installed"
                Else
                    BBInstalled = False
                    BBInstallButton.Text = "Install"
                    BBStatusLabel.Text = "Not installed"
                End If
            End If
            U9VSLocation = Systemdrive & "Users\" & GetUserName() & "\AppData\Local\VirtualStore\" & directory.Substring(3)
            If Dir(Systemdrive & "Users\" & GetUserName() & "\AppData\Local\VirtualStore\" & directory.Substring(3) & "\Options.ini") <> "" Then
                U9OptionsLocation = Systemdrive & "Users\" & GetUserName() & "\AppData\Local\VirtualStore\" & directory.Substring(3)
            Else
                U9OptionsLocation = directory
            End If

            Try
                lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U9OptionsLocation & "\Options.ini")
                fileText = lOpenFile.ReadToEnd
                lOpenFile.Close()
            Catch ex As Exception
                MsgBox("Cannot open Options.ini. Please check your installation")
            End Try



            screenHeight = GetOption("GameScreenHeight", fileText)
            screenWidth = GetOption("GameScreenWidth", fileText)
            colorDepth = GetOption("GameScreenDepth", fileText)
            rasterizer = GetOption("Game Rasterizer", fileText)

            If rasterizer = 2 Then
                RasterizerCombo.SelectedIndex = 1
            Else
                RasterizerCombo.SelectedIndex = 0
            End If

            WidthBox.Text = screenWidth
            HeightBox.Text = screenHeight

            If FileComp("Files\U9Patch-1.19H\runtime\nonfixed.9", directory & "\runtime\nonfixed.9") Then
                FWInstalled = True
                UpgradeButton.Text = "Uninstall"
                UpgradeStatus.Text = "Installed"
            Else
                FWInstalled = False
                UpgradeButton.Text = "Install"
                UpgradeStatus.Text = "Not Installed"
            End If

            If FileComp("Files\U9Fanpatch160\npc.flx", directory & "\runtime\NPC.FLX") Or FileComp("Files\U9F\npc.flx", directory & "\runtime\NPC.FLX") Then
                MonEcoInstalled = True
                MonEcoButton.Text = "Remove Monster/Economy"
                EcoStatus.Text = "Monster/Economy installed"
            Else
                MonEcoInstalled = False
                MonEcoButton.Text = "Install Monster/Economy"
                EcoStatus.Text = "Not installed"
            End If

            If FileComp("Files\U9Fanpatch160\typename.flx", directory & "\static\TYPENAME.FLX") Then
                DialogInstalled = True
                RenameAvatarButton.Visible = True
                DialogButton.Text = "Remove Dialog"
                If MonEcoInstalled Then
                    EcoStatus.Text = "All patches installed"
                Else
                    EcoStatus.Text = "Dialog installed"
                End If
            Else
                DialogInstalled = False
                RenameAvatarButton.Visible = False
                DialogButton.Text = "Install Dialog"
                If MonEcoInstalled Then
                    EcoStatus.Text = "Monster/Economy installed"
                Else
                    EcoStatus.Text = "Not installed"
                End If
                If Not FileComp("Files\U9Fanpatch160\originals\TYPENAME.FLX", U9Location & "\static\TYPENAME.FLX") Then
                    DialogButton.Enabled = False
                Else
                    DialogButton.Enabled = True
                End If
            End If


            LoadingForm = False
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub U9Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d As String
        Try
            For Each d In U9Directories
                SetGameLocation(d)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
        If U9Location = "" Then
            If Ultima9DirectoryDialog.ShowDialog() = DialogResult.OK Then
                If Not (SetGameLocation(Ultima9DirectoryDialog.SelectedPath)) Then
                    MsgBox("Game not found in this location.")
                    MainMenu.Show()
                    Me.Close()
                End If
            Else
                MainMenu.Show()
                Me.Close()
            End If
        End If
        LanguagePacksDownloaded = New List(Of Boolean)
        For i As Integer = 0 To LanguageComboBox.Items.Count - 1
            If Dir("Files\" & LanguageComboBox.Items(i)) <> "" Then
                LanguagePacksDownloaded.Add(True)
            Else
                LanguagePacksDownloaded.Add(False)
            End If

            If FileComp("Files\" & LanguageComboBox.Items(i) & "\static\TYPENAME.FLX", U9Location & "\static\TYPENAME.FLX") Then
                LanguageComboBox.SelectedIndex = i
            End If
        Next

        If LanguageComboBox.SelectedIndex = -1 Then
            LanguageComboBox.SelectedIndex = 0
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If DownloadingBB Then
            If MsgBox("This will cancel download of Beautiful Britannia - continue?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                WC.CancelAsync()
            Else
                Exit Sub
            End If
        End If
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub UpgradeButton_Click(sender As System.Object, e As System.EventArgs) Handles UpgradeButton.Click

        If Dir(U9VSLocation & "\runtime\nonfixed.9") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\runtime\nonfixed.9")
        End If
        If Dir(U9VSLocation & "\runtime\nonfixed.22") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\runtime\nonfixed.22")
        End If
        If Dir(U9VSLocation & "\static\activity.flx") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\static\activity.flx")
        End If
        If Dir(U9VSLocation & "\static\highway.dat") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\static\highway.dat")
        End If
        If Dir(U9VSLocation & "\static\triggers.flx") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\static\triggers.flx")
        End If
        If Dir(U9VSLocation & "\Options.ini") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\Options.ini")
        End If
        If FWInstalled Then
            My.Computer.FileSystem.CopyFile("Files\U9Patch-1.19H\runtime\originals\nonfixed.9", U9Location & "\runtime\nonfixed.9", True)
            My.Computer.FileSystem.CopyFile("Files\U9Patch-1.19H\runtime\originals\nonfixed.22", U9Location & "\runtime\nonfixed.22", True)
            My.Computer.FileSystem.CopyFile("Files\U9Patch-1.19H\static\originals\activity.flx", U9Location & "\static\activity.flx", True)
            My.Computer.FileSystem.CopyFile("Files\U9Patch-1.19H\static\originals\highway.dat", U9Location & "\static\highway.dat", True)
            My.Computer.FileSystem.CopyFile("Files\U9Patch-1.19H\static\originals\triggers.flx", U9Location & "\static\triggers.flx", True)
            My.Computer.FileSystem.CopyFile("Files\Options.ini", U9Location & "\Options.ini", True)
        Else
            My.Computer.FileSystem.CopyFile("Files\U9Patch-1.19H\runtime\nonfixed.9", U9Location & "\runtime\nonfixed.9", True)
            My.Computer.FileSystem.CopyFile("Files\U9Patch-1.19H\runtime\nonfixed.22", U9Location & "\runtime\nonfixed.22", True)
            My.Computer.FileSystem.CopyFile("Files\U9Patch-1.19H\static\activity.flx", U9Location & "\static\activity.flx", True)
            My.Computer.FileSystem.CopyFile("Files\U9Patch-1.19H\static\highway.dat", U9Location & "\static\highway.dat", True)
            My.Computer.FileSystem.CopyFile("Files\U9Patch-1.19H\static\triggers.flx", U9Location & "\static\triggers.flx", True)
            My.Computer.FileSystem.CopyFile("Files\Options.FW.ini", U9Location & "\Options.ini", True)
        End If
        U9OptionsLocation = U9Location
        SetScreenSize()
        SetGameLocation(U9Location)
    End Sub

    Private Sub WidthBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles WidthBox.TextChanged
        Try
            Dim temp = CInt(WidthBox.Text)
        Catch ex As Exception
            If WidthBox.Text <> "" Then
                MsgBox("Please enter a number")
                WidthBox.Text = screenWidth
            End If
        End Try
        If WidthBox.Text <> "" Then
            screenWidth = CInt(WidthBox.Text)
            SetScreenSize()
        End If
    End Sub
    Private Sub HeightBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles HeightBox.TextChanged
        Try
            Dim temp = CInt(HeightBox.Text)
        Catch ex As Exception
            If HeightBox.Text <> "" Then
                MsgBox("Please enter a number")
                HeightBox.Text = screenHeight
            End If
        End Try
        If HeightBox.Text <> "" Then
            screenHeight = CInt(HeightBox.Text)
            SetScreenSize()
        End If
    End Sub

    Private Sub SetScreenSize()

        Dim lOpenFile As System.IO.StreamReader
        Dim fileText As String = ""
        Dim newline As String

        REM Taking the lazy option and shoving the correction for movie location in here

        lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U9OptionsLocation & "\Options.ini")

        While Not lOpenFile.EndOfStream

            newline = lOpenFile.ReadLine
            If newline.IndexOf("GameScreenHeight") = -1 And newline.IndexOf("GameScreenWidth") = -1 And newline.IndexOf("MoviePath") = -1 Then
                fileText = fileText & newline & vbCrLf
            ElseIf newline.IndexOf("GameScreenWidth") <> -1 Then
                fileText = fileText & "GameScreenWidth=" & CStr(screenWidth) & vbCrLf
            ElseIf newline.IndexOf("GameScreenHeight") <> -1 Then
                fileText = fileText & "GameScreenHeight=" & CStr(screenHeight) & vbCrLf
            Else
                fileText = fileText & "MoviePath=" & U9OptionsLocation & "\Movies" & vbCrLf
            End If
        End While
        lOpenFile.Close()
        My.Computer.FileSystem.WriteAllText(U9OptionsLocation & "\Options.ini", fileText, False)

    End Sub

    Function GetOption(Param As String, fileText As String)
        Dim subStart = fileText.IndexOf(Param)
        Dim paramString = fileText.Substring(subStart, fileText.IndexOf(vbCr, subStart) - subStart)

        subStart = paramString.LastIndexOf("=")
        If paramString.LastIndexOf(" ") > subStart Then
            subStart = paramString.LastIndexOf(" ")
        End If
        Return CInt(paramString.Substring(subStart + 1, paramString.Length - subStart - 1))
    End Function

    Private Sub RasterizerCombo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles RasterizerCombo.SelectedIndexChanged
        If LoadingForm Then
            Exit Sub
        End If
        If RasterizerCombo.SelectedIndex = 0 Then
            rasterizer = 3
            colorDepth = 16
        Else
            rasterizer = 2
            colorDepth = 32
        End If

        Dim lOpenFile As System.IO.StreamReader
        Dim fileText As String = ""
        Dim newline As String

        lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U9OptionsLocation & "\Options.ini")

        While Not lOpenFile.EndOfStream

            newline = lOpenFile.ReadLine
            If newline.IndexOf("Game Rasterizer") = -1 And newline.IndexOf("GameScreenDepth") = -1 Then
                fileText = fileText & newline & vbCrLf
            ElseIf newline.IndexOf("GameScreenDepth") = -1 Then
                fileText = fileText & "Game Rasterizer=" & CStr(rasterizer) & vbCrLf
            Else
                fileText = fileText & "GameScreenDepth=" & CStr(colorDepth) & vbCrLf
            End If
        End While
        lOpenFile.Close()
        My.Computer.FileSystem.WriteAllText(U9OptionsLocation & "\Options.ini", fileText, False)

        SetGameLocation(U9Location)
    End Sub

    Private Sub MonEcoButton_Click(sender As System.Object, e As System.EventArgs) Handles MonEcoButton.Click
        'First delete any files that may have crept into virtualstore
        If Dir(U9VSLocation & "\static\BOOKS-EN.FLX") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\static\BOOKS-EN.FLX")
        End If
        If Dir(U9VSLocation & "\runtime\NPC.FLX") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\runtime\NPC.FLX")
        End If
        If Dir(U9VSLocation & "\static\TYPENAME.FLX") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\static\TYPENAME.FLX")
        End If
        If Dir(U9VSLocation & "\static\text.flx") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\static\text.flx")
        End If
        If MonEcoInstalled Then
            My.Computer.FileSystem.CopyFile("Files\U9Fanpatch160\originals\NPC.FLX", U9Location & "\runtime\NPC.FLX", True)
            If DialogInstalled Then
                My.Computer.FileSystem.CopyFile("Files\U9Fanpatch160\book", U9Location & "\static\BOOKS-EN.FLX", True)
            Else
                My.Computer.FileSystem.CopyFile("Files\U9Fanpatch160\originals\BOOKS-EN.FLX", U9Location & "\static\BOOKS-EN.FLX", True)
            End If
        Else
            My.Computer.FileSystem.CopyFile("Files\U9Fanpatch160\npc.flx", U9Location & "\runtime\NPC.FLX", True)
            If DialogInstalled Then
                My.Computer.FileSystem.CopyFile("Files\U9Fanpatch160\book&economy", U9Location & "\static\BOOKS-EN.FLX", True)
            Else
                My.Computer.FileSystem.CopyFile("Files\U9Fanpatch160\book", U9Location & "\static\BOOKS-EN.FLX", True)
            End If
        End If
        SetGameLocation(U9Location)
    End Sub

    Private Sub DialogButton_Click(sender As System.Object, e As System.EventArgs) Handles DialogButton.Click
        Dim lOpenFile As System.IO.StreamReader
        Dim fileText As String = ""
        Dim newline As String
        If Dir(U9VSLocation & "\static\BOOKS-EN.FLX") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\static\BOOKS-EN.FLX")
        End If
        If Dir(U9VSLocation & "\runtime\NPC.FLX") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\runtime\NPC.FLX")
        End If
        If Dir(U9VSLocation & "\static\TYPENAME.FLX") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\static\TYPENAME.FLX")
        End If
        If Dir(U9VSLocation & "\static\text.flx") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\static\text.flx")
        End If
        If DialogInstalled Then
            My.Computer.FileSystem.CopyFile("Files\U9Fanpatch160\originals\text.flx", U9Location & "\static\text.flx", True)
            My.Computer.FileSystem.CopyFile("Files\U9Fanpatch160\originals\TYPENAME.FLX", U9Location & "\static\TYPENAME.FLX", True)


            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U9OptionsLocation & "\Options.ini")

            While Not lOpenFile.EndOfStream

                newline = lOpenFile.ReadLine
                If newline.IndexOf("EnableAudio") = -1 Then
                    fileText = fileText & newline & vbCrLf
                Else
                    fileText = fileText & "EnableAudio=1" & vbCrLf
                End If
            End While
            lOpenFile.Close()
            My.Computer.FileSystem.WriteAllText(U9OptionsLocation & "\Options.ini", fileText, False)

        Else
            My.Computer.FileSystem.CopyFile("Files\U9Fanpatch160\text.flx", U9Location & "\static\text.flx", True)
            My.Computer.FileSystem.CopyFile("Files\U9Fanpatch160\TYPENAME.FLX", U9Location & "\static\TYPENAME.FLX", True)
            My.Computer.FileSystem.CopyFile("Files\U9Fanpatch160\u9name.exe", U9Location & "\u9name.exe", True)
            My.Computer.FileSystem.CopyFile("Files\U9Fanpatch160\u9name.ini", U9Location & "\u9name.ini", True)

            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U9OptionsLocation & "\Options.ini")

            While Not lOpenFile.EndOfStream

                newline = lOpenFile.ReadLine
                If newline.IndexOf("EnableAudio") = -1 Then
                    fileText = fileText & newline & vbCrLf
                Else
                    fileText = fileText & "EnableAudio=0" & vbCrLf
                End If
            End While
            lOpenFile.Close()
            My.Computer.FileSystem.WriteAllText(U9OptionsLocation & "\Options.ini", fileText, False)
        End If
        SetGameLocation(U9Location)

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Shell("explorer.exe http://forgottenworld.de")
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Shell("explorer.exe http://forgottenworld.de")
    End Sub

    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameAvatarButton.Click
        My.Computer.FileSystem.CopyFile("Files\DosboxBase.conf", "Files\Patch.conf", True)

        Dim objStreamWriter As StreamWriter

        objStreamWriter = New StreamWriter("Files\Patch.conf", True)
        objStreamWriter.WriteLine("mount c """ & U9Location & """")
        objStreamWriter.WriteLine("c:\")
        objStreamWriter.WriteLine("u9name.exe")
        objStreamWriter.WriteLine("exit.exe")
        objStreamWriter.Close()
        Shell(CStr(My.Application.Info.DirectoryPath) & "\Files\Dosbox\DOSBox.exe -conf " & My.Application.Info.DirectoryPath & "\Files\Patch.conf -noconsole ")
        SetGameLocation(U9Location)
    End Sub
    Dim WithEvents WC As New WebClient
    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        ProgressBar2.Value = e.ProgressPercentage
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadBBButon.Click
        If DownloadingBB Then
            Exit Sub
        End If
        DownloadBBButon.Text = "Downloading"
        DownloadingBB = True
        ProgressBar2.Visible = True
        BBStatusLabel.Text = "Downloading"

        WC.DownloadFileAsync(New Uri("http://ultima9.ultimacodex.com/?smd_process_download=1&download_id=522"), "Files/BeautifulBritannia2011R3.zip")
    End Sub
    Private Sub WC_DownloadFinished(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted

        If DownloadingBB Then
            If e.Cancelled Then
                If Dir("Files/BeautifulBritannia2011R3.zip") <> "" Then
                    My.Computer.FileSystem.DeleteFile("Files/BeautifulBritannia2011R3.zip")
                End If
                MsgBox("Download aborted.")
            ElseIf Not (IsNothing(e.Error)) Then
                MsgBox("Error downloading.")
                If Dir("Files/BeautifulBritannia2011R3.zip") <> "" Then
                    My.Computer.FileSystem.DeleteFile("Files/BeautifulBritannia2011R3.zip")
                End If
            Else
                MsgBox("Download complete.")
            End If
            DownloadingBB = False
        End If

        If DownloadingLanguagePacks Then
            If e.Cancelled Then
                If Dir("Files/" & LanguageComboBox.SelectedItem & ".zip") <> "" Then
                    My.Computer.FileSystem.DeleteFile("Files/" & LanguageComboBox.SelectedItem & ".zip")
                End If
                MsgBox("Download aborted.")
            ElseIf Not (IsNothing(e.Error)) Then
                MsgBox("Error downloading.")
                If Dir("Files/" & LanguageComboBox.SelectedItem & ".zip") <> "" Then
                    My.Computer.FileSystem.DeleteFile("Files/" & LanguageComboBox.SelectedItem & ".zip")
                End If
            Else
                MsgBox("Download complete.")
            End If
            DownloadingLanguagePacks = False
        End If

        SetGameLocation(U9Location)
    End Sub
    Sub UnZipBB()
        PleaseWait.SetLabel("Unzipping Beautiful Britannia...")
        PleaseWait.Show()
        Dim ShellAppType As Type = Type.GetTypeFromProgID("Shell.Application")
        Dim sc As Object = Activator.CreateInstance(ShellAppType)
        'Declare the folder where the files will be extracted
        Dim output As Shell32.Folder = sc.NameSpace(My.Application.Info.DirectoryPath & "\Files")
        'Declare your input zip file as folder  .
        Dim input As Shell32.Folder = sc.NameSpace(My.Application.Info.DirectoryPath & "\Files\BeautifulBritannia2011R3.zip")
        'Extract the files from the zip file using the CopyHere command .
        output.CopyHere(input.Items, 4)
        PleaseWait.Hide()
    End Sub

    Sub UnZipLanguagePack()
        PleaseWait.SetLabel("Unzipping Language Pack...")
        PleaseWait.Show()
        Dim ShellAppType As Type = Type.GetTypeFromProgID("Shell.Application")
        Dim sc As Object = Activator.CreateInstance(ShellAppType)
        'Declare the folder where the files will be extracted
        Dim output As Shell32.Folder = sc.NameSpace(My.Application.Info.DirectoryPath & "\Files")
        'Declare your input zip file as folder  .
        Dim input As Shell32.Folder = sc.NameSpace(My.Application.Info.DirectoryPath & "\Files\" & LanguageComboBox.SelectedItem & ".zip")
        'Extract the files from the zip file using the CopyHere command .
        output.CopyHere(input.Items, 4)
        PleaseWait.Hide()
    End Sub


    Private Sub BBInstallButton_Click(sender As System.Object, e As System.EventArgs) Handles BBInstallButton.Click


        If Dir(U9VSLocation & "\runtime\nonfixed.9") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\runtime\nonfixed.9")
        End If
        If Dir(U9VSLocation & "\static\fixed.9") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\static\fixed.9")
        End If
        If Dir(U9VSLocation & "\static\bitmap16.flx") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\static\bitmap16.flx")
        End If
        If Dir(U9VSLocation & "\static\sappear.flx") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\static\sappear.flx")
        End If
        If Dir(U9VSLocation & "\static\sdinfo16.flx") <> "" Then
            My.Computer.FileSystem.DeleteFile(U9VSLocation & "\static\sdinfo16.flx")
        End If

        If Dir(U9Location & "\orig_fixed.9") = "" Then
            My.Computer.FileSystem.CopyFile(U9Location & "\static\fixed.9", U9Location & "\orig_fixed.9", True)
        End If
        If Dir(U9Location & "\orig_sappear.flx") = "" Then
            My.Computer.FileSystem.CopyFile(U9Location & "\static\sappear.flx", U9Location & "\orig_sappear.flx", True)
        End If
        If Dir(U9Location & "\orig_sdinfo16.flx") = "" Then
            My.Computer.FileSystem.CopyFile(U9Location & "\static\sdinfo16.flx", U9Location & "\orig_sdinfo16.flx", True)
        End If
        If Dir(U9Location & "\orig_bitmap16.flx") = "" Then
            My.Computer.FileSystem.CopyFile(U9Location & "\static\bitmap16.flx", U9Location & "\orig_bitmap16.flx", True)
        End If

        If BBInstalled Then
            My.Computer.FileSystem.CopyFile(U9Location & "\orig_fixed.9", U9Location & "\static\fixed.9", True)
            My.Computer.FileSystem.CopyFile(U9Location & "\orig_sappear.flx", U9Location & "\static\sappear.flx", True)
            My.Computer.FileSystem.CopyFile(U9Location & "\orig_sdinfo16.flx", U9Location & "\static\sdinfo16.flx", True)
            My.Computer.FileSystem.CopyFile(U9Location & "\orig_bitmap16.flx", U9Location & "\static\bitmap16.flx", True)
            If Not (FWInstalled) Then
                My.Computer.FileSystem.CopyFile("Files\U9Patch-1.19H\runtime\originals\nonfixed.9", U9Location & "\runtime\nonfixed.9", True)
            End If
        Else
            My.Computer.FileSystem.CopyFile("Files\BB\BB2011R3\static\fixed.9", U9Location & "\static\fixed.9", True)
            My.Computer.FileSystem.CopyFile("Files\BB\BB2011R3\runtime\nonfixed.9", U9Location & "\runtime\nonfixed.9", True)
            My.Computer.FileSystem.CopyFile("Files\BB\BB2011R3\static\sappear.flx", U9Location & "\static\sappear.flx", True)
            My.Computer.FileSystem.CopyFile("Files\BB\BB2011R3\static\sdinfo16.flx", U9Location & "\static\sdinfo16.flx", True)
            My.Computer.FileSystem.CopyFile("Files\BB\BB2011R3\static\bitmap16.flx", U9Location & "\static\bitmap16.flx", True)
            If FWInstalled Then
                My.Computer.FileSystem.CopyFile("Files\U9Patch-1.19H\runtime\nonfixed.9", U9Location & "\runtime\nonfixed.9", True)
            End If
            RasterizerCombo.SelectedIndex = 1
        End If
        SetGameLocation(U9Location)
    End Sub

    Private Sub FogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FogButton.Click
        Dim OrigLocation As String
        OrigLocation = My.Computer.FileSystem.CurrentDirectory
        If FogOn Then
            My.Computer.FileSystem.CopyFile("Files\U9PatcherEXE.exe", U9Location & "\U9PatcherEXE.exe", True)
            ChDir(U9Location)
            Shell(U9Location & "\U9PatcherEXE.exe", AppWinStyle.NormalFocus, True)
            ChDir(OrigLocation)
            Me.Focus()
        Else
            My.Computer.FileSystem.CopyFile(U9Location & "\U9.exe.bak", U9Location & "\U9.exe", True)
            My.Computer.FileSystem.DeleteFile(U9Location & "\U9.exe.bak")
        End If
        SetGameLocation(U9Location)
    End Sub

    Private Sub LanguageComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LanguageComboBox.SelectedIndexChanged
        SetGameLocation(U9Location)
    End Sub

    Private Sub DownloadLanguagePacksButton_Click_1(sender As Object, e As EventArgs) Handles DownloadLanguagePacksButton.Click
        If DownloadingLanguagePacks Then
            Exit Sub
        End If
        If LanguagePacksDownloaded(LanguageComboBox.SelectedIndex) Then
            Exit Sub
        Else
            DownloadLanguagePacksButton.Text = "Downloading"
            DownloadingLanguagePacks = True
            ProgressBar1.Visible = True

            WC.DownloadFileAsync(New Uri("https://www.fenyx4.com/ultima/u9/language-packs/" & LanguageComboBox.SelectedItem & ".zip"), "Files/" & LanguageComboBox.SelectedItem & ".zip")
        End If
    End Sub

    Private Sub SpeechInstallButton_Click_1(sender As Object, e As EventArgs) Handles SpeechInstallButton.Click
        If DownloadingLanguagePacks Then
            Exit Sub
        End If
        If LanguagePacksDownloaded(LanguageComboBox.SelectedIndex) Then
            If System.IO.Directory.Exists("Files\" & LanguageComboBox.SelectedItem & "\Movies") Then
                CopyDirectory("Files\" & LanguageComboBox.SelectedItem & "\Movies", U9Location & "\Movies")
            End If

            If System.IO.Directory.Exists("Files\" & LanguageComboBox.SelectedItem & "\sound") Then
                CopyDirectory("Files\" & LanguageComboBox.SelectedItem & "\sound", U9Location & "\sound")
            End If

            SetGameLocation(U9Location)
        Else
            DownloadLanguagePacksButton.Text = "Download"
            DownloadLanguagePacksButton.Enabled = True
            DownloadLanguagePacksButton.Visible = True

            SpeechInstallButton.Visible = False
            TextInstallButton.Visible = False
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub TextInstallButton_Click_1(sender As Object, e As EventArgs) Handles TextInstallButton.Click
        If DownloadingLanguagePacks Then
            Exit Sub
        End If
        If LanguagePacksDownloaded(LanguageComboBox.SelectedIndex) Then
            If System.IO.Directory.Exists("Files\" & LanguageComboBox.SelectedItem & "\static") Then
                CopyDirectory("Files\" & LanguageComboBox.SelectedItem & "\static", U9Location & "\static")

                If (LanguageComboBox.SelectedItem = "Jp") Then
                    Dim signatureBaseFilePath = U9Location & "\u9.exe"
                    Dim signatureFilePath = "Files\U9JPLanguagePatch\u9.exe.sig"
                    Dim newFilePath2 = "Files\U9JPLanguagePatch\u9.exe"
                    Dim newFileOutputDirectory = Path.GetDirectoryName(newFilePath2)
                    Dim deltaFilePath = "Files\U9JPLanguagePatch\u9.exe.octodiff"

                    If Not Directory.Exists(newFileOutputDirectory) Then
                        Directory.CreateDirectory(newFileOutputDirectory)
                    End If

                    Dim DeltaApplier = New DeltaApplier With {
                    .SkipHashCheck = False
                }
                    Using basisStream = New FileStream(signatureBaseFilePath, FileMode.Open, FileAccess.Read, FileShare.Read)
                        Using deltaStream = New FileStream(deltaFilePath, FileMode.Open, FileAccess.Read, FileShare.Read)
                            Using newFileStream = New FileStream(newFilePath2, FileMode.Create, FileAccess.ReadWrite, FileShare.Read)
                                DeltaApplier.Apply(basisStream, New BinaryDeltaReader(deltaStream, New ConsoleProgressReporter()), newFileStream)
                            End Using
                        End Using
                    End Using
                    FileCopy(newFilePath2, U9Location & "\u9.jp.exe")
                    FileCopy("Files\U9JPLanguagePatch\u9.bat.exe", U9Location & "\u9.exe")
                    CopyDirectory("Files\Locale.Emulator.2.5.0.1", U9Location)
                    MessageBox.Show("You need to install the Japanese Language Pack for Windows in order for this to work.", "Details", MessageBoxButtons.OK)
                Else
                    ' If it isn't Japanese version then make sure we have the original version of the exe
                    FileCopy("Files\u9.exe", U9Location & "\u9.exe")
                End If
            End If

            SetGameLocation(U9Location)
        Else
            DownloadLanguagePacksButton.Text = "Download"
            DownloadLanguagePacksButton.Enabled = True
            DownloadLanguagePacksButton.Visible = True

            SpeechInstallButton.Visible = False
            TextInstallButton.Visible = False
            ProgressBar1.Visible = False
        End If
    End Sub

    Public Sub CopyDirectory(ByVal sourcePath As String, ByVal destinationPath As String)
        Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(sourcePath)

        ' If the destination folder don't exist then create it
        If Not System.IO.Directory.Exists(destinationPath) Then
            System.IO.Directory.CreateDirectory(destinationPath)
        End If

        Dim fileSystemInfo As System.IO.FileSystemInfo
        For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
            Dim destinationFileName As String =
            System.IO.Path.Combine(destinationPath, fileSystemInfo.Name)

            ' Now check whether its a file or a folder and take action accordingly
            If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
            Else
                ' Recursively call the mothod to copy all the neste folders
                CopyDirectory(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
    End Sub

End Class