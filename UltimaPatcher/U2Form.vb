Imports System.IO

Public Class Ultima2Form
    Dim U2Directories = {"C:\Program Files\GOG.com\Ultima Trilogy\Ultima2", "C:\Program Files (x86)\GOG.com\Ultima Trilogy\Ultima2", "C:\GOG Games\Ultima Trilogy\ULTIMA2", "C:\GOG Games\Ultima 2", "C:\Program Files (x86)\GOG Galaxy\Games\Ultima 2"}
    Dim U2Location As String
    Dim PatchInstalled As Boolean
    Dim EGAVersion As Boolean
    Dim DosboxExeConfig As String

    Private Sub Ultima2Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        REM Attempt to locate Ultima 2 installation
        Dim d As String
        Try
            For Each d In U2Directories
                SetGameLocation(d)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
        If U2Location = "" Then
            If Ultima2DirectoryDialog.ShowDialog() = DialogResult.OK Then
                If Not (SetGameLocation(Ultima2DirectoryDialog.SelectedPath)) Then
                    MsgBox("Game not found in this location.")
                    MainMenu.Show()
                    MainMenu.Focus()
                    Me.Close()
                End If
            Else
                MainMenu.Show()
                MainMenu.Focus()
                Me.Close()
            End If
        End If


    End Sub

    Public Function SetGameLocation(ByVal directory As String)
        If Dir(directory & "\ULTIMAII.exe") <> "" Then
            U2Location = directory
            Ultima2DirectoryTextbox.Text = directory
            If Dir(U2Location & "\dosboxULTIMA2_single.CONF") <> "" Then
                DosboxExeConfig = "\dosboxULTIMA2_single.CONF"
            Else
                DosboxExeConfig = "\dosboxULTIMA2.CONF"
            End If
            If Dir(U2Location & "\u2up-21.pat") <> "" Then
                PatchInstalled = True
                PatchStatus.Text = "Installed"
                PatchButton.Text = "Configure Patch"

                Dim lOpenFile As System.IO.StreamReader
                Dim fileText As String
                Try
                    lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U2Location & DosboxExeConfig)
                    fileText = lOpenFile.ReadToEnd
                    lOpenFile.Close()

                    If InStr(fileText, "ultimaII.exe") <> 0 Then
                        EGAVersion = False
                    Else
                        EGAVersion = True
                    End If
                Catch exp As System.Exception
                End Try
            Else
                PatchInstalled = False
                PatchStatus.Text = "Not Installed"
                PatchButton.Text = "Install Patch"
            End If

            Return True
        Else
            Return False
        End If
    End Function

    Private Sub PatchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchButton.Click
        REM Since the patch is uninstallable but configurable, I'll just do the whole process every time no matter what
        If Not PatchInstalled Then
            Dim fileNames = My.Computer.FileSystem.GetFiles("Files\U2Upgrade", FileIO.SearchOption.SearchTopLevelOnly, "*.*")

            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U2Location & "\" & System.IO.Path.GetFileName(file), True)
            Next

            fileNames = My.Computer.FileSystem.GetFiles("Files\U2Upgrade\EGATHEME.10", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U2Location & "\" & System.IO.Path.GetFileName(file), True)
            Next

            fileNames = My.Computer.FileSystem.GetFiles("Files\U2Upgrade\EGATHEME.ALT", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U2Location & "\" & System.IO.Path.GetFileName(file), True)
            Next

            fileNames = My.Computer.FileSystem.GetFiles("Files\U2Upgrade\EGATHEME.C64", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U2Location & "\" & System.IO.Path.GetFileName(file), True)
            Next
        End If


        My.Computer.FileSystem.CopyFile("Files\DosboxBase.conf", "Files\U2Patch.conf", True)
        Dim objStreamWriter As StreamWriter
        objStreamWriter = New StreamWriter("Files\U2Patch.conf", True)
        objStreamWriter.WriteLine("mount c """ & U2Location & """")
        objStreamWriter.WriteLine("c:\")
        If PatchInstalled Then
            objStreamWriter.WriteLine("u2cfg")
        Else
            objStreamWriter.WriteLine("u2up")
        End If
        objStreamWriter.WriteLine("exit.exe")
        objStreamWriter.Close()
        Shell("Files\Dosbox\DOSBox.exe -conf .\Files\U2Patch.conf -noconsole ", , True)
        SetGameLocation(U2Location)
        GraphicsModeButton_Click(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Ultima2DirectoryDialog.ShowDialog() = DialogResult.OK Then
            If Not (SetGameLocation(Ultima2DirectoryDialog.SelectedPath)) Then
                MsgBox("Game not found in this location.")
            End If
        End If
    End Sub

    Private Sub GraphicsModeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lOpenFile As System.IO.StreamReader
        Dim fileText As String
        Try
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U2Location & "\dosboxULTIMA2.CONF")
            fileText = lOpenFile.ReadToEnd
            lOpenFile.Close()

            If EGAVersion Then
                fileText = fileText.Replace("ultima2.com", "ultimaII.exe")
                fileText = fileText.Replace("cycles=2000", "cycles=500")
                fileText = fileText.Replace("cputype=auto", "cputype=386_slow")
            Else
                fileText = fileText.Replace("ultimaII.exe", "ultima2.com")
                fileText = fileText.Replace("cycles=500", "cycles=10000")
                fileText = fileText.Replace("cycles=2000", "cycles=10000")
                fileText = fileText.Replace("cputype=386_slow", "cputype=auto")
            End If

            My.Computer.FileSystem.WriteAllText(U2Location & "\dosboxULTIMA2.CONF", fileText, False, System.Text.Encoding.ASCII)
        Catch exp As System.Exception
        End Try

        Try
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U2Location & DosboxExeConfig)
            fileText = lOpenFile.ReadToEnd
            lOpenFile.Close()

            If EGAVersion Then
                fileText = fileText.Replace("ultima2.com", "ultimaII.exe")
                fileText = fileText.Replace("cycles=10000", "cycles=500")
                fileText = fileText.Replace("cputype=auto", "cputype=386_slow")
            Else
                fileText = fileText.Replace("ultimaII.exe", "ultima2.com")
                fileText = fileText.Replace("cycles=500", "cycles=10000")
                fileText = fileText.Replace("cycles=2000", "cycles=10000")
                fileText = fileText.Replace("cputype=386_slow", "cputype=auto")
            End If

            My.Computer.FileSystem.WriteAllText(U2Location & DosboxExeConfig, fileText, False, System.Text.Encoding.ASCII)
        Catch exp As System.Exception
        End Try
        SetGameLocation(U2Location)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MainMenu.Show()
        MainMenu.Focus()
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Shell("explorer.exe http://exodus.voyd.net")
    End Sub

    Private Sub GraphicsModeButton_Click_1(sender As System.Object, e As System.EventArgs)
        GraphicsModeButton_Click(sender, e)
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class