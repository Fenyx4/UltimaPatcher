Imports System.IO

Public Class U5Form
    Dim U5Directories = {"C:\Program Files (x86)\GOG.com\Ultima Second Trilogy\ULTIMA5", "C:\Program Files\GOG.com\Ultima Second Trilogy\ULTIMA5", "C:\GOG Games\Ultima Second Trilogy\Ultima 5", "C:\GOG Games\Ultima 5", "C:\Program Files (x86)\GOG Galaxy\Games\Ultima 5"}
    Dim U4Directories = {"C:\Program Files\GOG.com\Ultima 4", "C:\Program Files (x86)\GOG.com\Ultima 4", "C:\Program Files (x86)\GOG.com\Ultima Second Trilogy\ULTIMA4", "C:\Program Files\GOG.com\Ultima Second Trilogy\ULTIMA4", "C:\GOG Games\Ultima Second Trilogy\Ultima 4", "C:\GOG Games\Ultima 4 - Quest of the Avatar", "C:\GOG Games\Ultima 4", "C:\Program Files (x86)\GOG Galaxy\Games\Ultima 4"}
    Dim U5Location As String
    Dim UpgradeInstalled As Boolean
    Dim RunelessInstalled As Boolean
    Dim WCInstalled As Boolean
    Dim DosboxExeConfig As String
    Public Function SetGameLocation(ByVal directory As String)

        If Dir(directory & "\DUNGEON.CBT") <> "" Then
            U5Location = directory
            Ultima5DirectoryTextbox.Text = directory
            If Dir(U5Location & "\dosboxULTIMA5_single.CONF") <> "" Then
                DosboxExeConfig = "\dosboxULTIMA5_single.CONF"
            Else
                DosboxExeConfig = "\dosboxULTIMA5.conf"
            End If

            Dim lOpenFile As System.IO.StreamReader
            Dim fileText As String

            Try
                lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U5Location & DosboxExeConfig)
                fileText = lOpenFile.ReadToEnd
                lOpenFile.Close()
            Catch ex As Exception
                fileText = ""
            End Try
            If fileText.IndexOf("ultima5.com") <> -1 Then
                UpgradeInstalled = True
                UpgradeButton.Text = "Configure Patch"
                UpgradeStatus.Text = "Installed"
            Else
                UpgradeInstalled = False
                UpgradeButton.Text = "Install"
                UpgradeStatus.Text = "Not installed"
            End If

            If FileComp("Files\U5_ALT_RUNES.CH", U5Location & "\RUNES.CH") Then
                RunelessInstalled = True
                RunelessStatus.Text = "Installed"
                RunelessButton.Text = "Uninstall Patch"
            Else
                RunelessInstalled = False
                RunelessStatus.Text = "Not installed"
                RunelessButton.Text = "Install"
            End If

            If FileComp("Files\NatregU5\CASTLE.TLK", U5Location & "\CASTLE.TLK") Then
                WCInstalled = True
                WCStatus.Text = "Installed"
                WCButton.Text = "Uninstall Patch"
            Else
                WCInstalled = False
                WCStatus.Text = "Not installed"
                WCButton.Text = "Install"
            End If

            Return True
        Else
            Return False
        End If
    End Function


    Private Sub U5Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d As String
        Try
            For Each d In U5Directories
                SetGameLocation(d)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
        If U5Location = "" Then
            If Ultima5DirectoryDialog.ShowDialog() = DialogResult.OK Then
                If Not (SetGameLocation(Ultima5DirectoryDialog.SelectedPath)) Then
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

    Private Sub RunelessButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunelessButton.Click
        If RunelessInstalled Then
            My.Computer.FileSystem.CopyFile("Files\U5_ORIG_RUNES.CH", U5Location & "\RUNES.CH", True)
        Else
            My.Computer.FileSystem.CopyFile("Files\U5_ALT_RUNES.CH", U5Location & "\RUNES.CH", True)
        End If
        SetGameLocation(U5Location)
    End Sub

    Private Sub UpgradeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpgradeButton.Click
        Dim fileNames = My.Computer.FileSystem.GetFiles("Files\U5Upgrade", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
        For Each file In fileNames
            My.Computer.FileSystem.CopyFile(file, U5Location & "\" & System.IO.Path.GetFileName(file), True)
        Next

        My.Computer.FileSystem.CopyFile("Files\DosboxBase.conf", "Files\Patch.conf", True)

        Dim objStreamWriter As StreamWriter

        objStreamWriter = New StreamWriter("Files\Patch.conf", True)
        objStreamWriter.WriteLine("mount c """ & U5Location & """")
        objStreamWriter.WriteLine("c:\")
        objStreamWriter.WriteLine("setm.exe")
        objStreamWriter.WriteLine("u5cfg.exe")
        objStreamWriter.WriteLine("u5data.exe")
        objStreamWriter.WriteLine("exit.exe")
        objStreamWriter.Close()

        Shell("Files\Dosbox\DOSBox.exe -conf .\Files\Patch.conf -noconsole ", , True)
        Dim lOpenFile As System.IO.StreamReader
        Dim fileText As String
        Try
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U5Location & DosboxExeConfig)
            fileText = lOpenFile.ReadToEnd
            lOpenFile.Close()

            fileText = fileText.Replace("ULTIMA.EXE", "ultima5.com")
            My.Computer.FileSystem.WriteAllText(U5Location & DosboxExeConfig, fileText, False, System.Text.Encoding.ASCII)
        Catch exp As System.Exception
        End Try
        SetGameLocation(U5Location)
    End Sub

    Private Sub PartyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartyButton.Click
        Dim d As String
        For Each d In U4Directories
            If Dir(d & "\PARTY.SAV") <> "" Then Ultima4DirectoryDialog.SelectedPath = d
        Next
        If Ultima4DirectoryDialog.ShowDialog() = DialogResult.OK Then
            If Not (MountU4(Ultima4DirectoryDialog.SelectedPath)) Then
                MsgBox("Save not found in this location.")
            Else
                MsgBox("Update Complete. Start Ultima 5, select Transfer Character and press A.")
            End If
        End If
    End Sub
    Public Function MountU4(ByVal directory As String)
        Dim Systemdrive As String
        Systemdrive = System.Environment.SystemDirectory.Substring(0, 3)

        If Dir(directory & "\PARTY.SAV") <> "" Then
            If My.Computer.FileSystem.GetFileInfo(directory & "\PARTY.SAV").LastWriteTime.Year < 1990 Then
                If Dir(Systemdrive & "Users\" & GetUserName() & "\AppData\Local\VirtualStore\" & directory.Substring(3) & "\PARTY.SAV") <> "" Then
                    If My.Computer.FileSystem.GetFileInfo(Systemdrive & "Users\" & GetUserName() & "\AppData\Local\VirtualStore\" & directory.Substring(3) & "\PARTY.SAV").LastWriteTime.Year < 1990 Then
                        Return False
                    Else
                        directory = Systemdrive & "Users\" & GetUserName() & "\AppData\Local\VirtualStore\" & directory.Substring(3)
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
                lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U5Location & DosboxExeConfig)

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
                My.Computer.FileSystem.WriteAllText(U5Location & DosboxExeConfig, fileText, False, System.Text.Encoding.ASCII)
            Catch exp As System.Exception
            End Try
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Ultima5DirectoryDialog.ShowDialog() = DialogResult.OK Then
            If (SetGameLocation(Ultima5DirectoryDialog.SelectedPath)) Then
                Return
            Else
                MsgBox("Game not found in this location.")
            End If
        End If
    End Sub

    Private Sub Ultima4DirectoryDialog_HelpRequest(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ultima4DirectoryDialog.HelpRequest

    End Sub


    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Shell("explorer.exe http://exodus.voyd.net")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim d As String
        For Each d In U4Directories
            If Dir(d & "\PARTY.SAV") <> "" Then Ultima4DirectoryDialog.SelectedPath = d
        Next
        If Ultima4DirectoryDialog.ShowDialog() = DialogResult.OK Then
            If Not (FixParty(Ultima4DirectoryDialog.SelectedPath)) Then
                MsgBox("Save not found in this location.")
            Else
                MsgBox("Fix complete. Start Ultima 5, select Transfer Character and press A.")
            End If
        End If
    End Sub

    Public Function FixParty(ByVal directory As String)
        Dim Systemdrive As String
        Systemdrive = System.Environment.SystemDirectory.Substring(0, 3)

        If Dir(directory & "\PARTY.SAV") <> "" Then
            If My.Computer.FileSystem.GetFileInfo(directory & "\PARTY.SAV").LastWriteTime.Year < 1990 Then
                If Dir(Systemdrive & "Users\" & GetUserName() & "\AppData\Local\VirtualStore\" & directory.Substring(3) & "\PARTY.SAV") <> "" Then
                    If My.Computer.FileSystem.GetFileInfo(Systemdrive & "Users\" & GetUserName() & "\AppData\Local\VirtualStore\" & directory.Substring(3) & "\PARTY.SAV").LastWriteTime.Year < 1990 Then
                        Return False
                    Else
                        directory = Systemdrive & "Users\" & GetUserName() & "\AppData\Local\VirtualStore\" & directory.Substring(3)
                    End If
                Else
                    Return False
                End If
            End If

            My.Computer.FileSystem.CopyFile("Files\DosboxBase.conf", "Files\Patch.conf", True)
            My.Computer.FileSystem.CopyFile("Files\fixparty.exe", directory & "\fixparty.exe", True)

            Dim objStreamWriter As StreamWriter

            objStreamWriter = New StreamWriter("Files\Patch.conf", True)
            objStreamWriter.WriteLine("mount a """ & directory & """")
            objStreamWriter.WriteLine("a:\")
            objStreamWriter.WriteLine("fixparty.exe")
            objStreamWriter.WriteLine("exit.exe")
            objStreamWriter.Close()
            Shell("Files\Dosbox\DOSBox.exe -conf .\Files\Patch.conf -noconsole ", , True)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

    End Sub

    Private Sub TextBox5_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub WCButton_Click(sender As System.Object, e As System.EventArgs) Handles WCButton.Click
        If WCInstalled Then
            My.Computer.FileSystem.CopyFile("Files\NatregU5\CASTLE_ORIG.TLK", U5Location & "\CASTLE.TLK", True)
        Else
            My.Computer.FileSystem.CopyFile("Files\NatregU5\CASTLE.TLK", U5Location & "\CASTLE.TLK", True)
        End If
        SetGameLocation(U5Location)
    End Sub
End Class