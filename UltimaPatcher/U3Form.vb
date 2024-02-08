Imports System.IO

Public Class Ultima3Form
    Dim U3Directories = {"C:\Program Files\GOG.com\Ultima Trilogy\Ultima3", "C:\Program Files (x86)\GOG.com\Ultima Trilogy\Ultima3", "C:\GOG Games\Ultima Trilogy\ULTIMA3", "C:\GOG Games\Ultima 3", "C:\Program Files (x86)\GOG Galaxy\Games\Ultima 3"}
    Dim U3Location As String
    Dim PatchInstalled As Boolean
    Dim EGAVersion As Boolean
    Dim AltEGA As Boolean
    Dim DosboxExeConfig As String
    Dim UltimoreInstalled As Boolean


    Private Sub U3Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d As String
        Try
            For Each d In U3Directories
                SetGameLocation(d)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
        If U3Location = "" Then
            If Ultima3DirectoryDialog.ShowDialog() = DialogResult.OK Then
                If Not (SetGameLocation(Ultima3DirectoryDialog.SelectedPath)) Then
                    MsgBox("Game not found in this location.")
                    MainMenu.Show()
                    MainMenu.BringToFront()
                    MainMenu.Focus()
                    Me.Close()
                End If
            Else
                MainMenu.Show()
                MainMenu.BringToFront()
                MainMenu.Focus()
                Me.Close()
            End If
        End If
    End Sub
    Public Function SetGameLocation(ByVal directory As String)
        If Dir(directory & "\AMBROSIA.ULT") <> "" Then
            U3Location = directory
            Ultima3DirectoryTextbox.Text = directory
            If Dir(U3Location & "\dosboxULTIMA3_single.CONF") <> "" Then
                DosboxExeConfig = "\dosboxULTIMA3_single.CONF"
            Else
                DosboxExeConfig = "\dosboxULTIMA3.CONF"
            End If
            If Dir(U3Location & "\U3.CFG") <> "" Then
                PatchInstalled = True
                PatchStatus.Text = "(Installed)"
                PatchButton.Text = "Configure Patch"
                AltEGAToggleButton.Visible = True

                Dim lOpenFile As System.IO.StreamReader
                Dim fileText As String
                Try
                    lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U3Location & DosboxExeConfig)
                    fileText = lOpenFile.ReadToEnd
                    lOpenFile.Close()

                    GraphicsModeButton.Text = "Uninstall"
                    GraphicsModeButton.Visible = True
                Catch exp As System.Exception
                    GraphicsModeButton.Visible = False
                End Try
            Else
                PatchInstalled = False
                PatchStatus.Text = "Not Installed"
                PatchButton.Text = "Install Patch"
                GraphicsModeButton.Visible = False
            End If
            If FileComp("Files\U3alt_shapes.ega", U3Location & "\shapes.ega") Then
                AltEGA = True
                AltEGAStatusLabel.Text = "Installed"
                AltEGAToggleButton.Text = "Uninstall"
            Else
                AltEGA = False
                AltEGAStatusLabel.Text = "Not Installed"
                AltEGAToggleButton.Text = "Install"
            End If
            'If FileComp("Files\U3UltimoreWorldDivided\EXODUS.BIN", U3Location & "\EXODUS.BIN") OrElse FileComp("Files\U3UltimoreWorldDivided\EXODUS.BIN.UPGRADEPATCHVERSION", U3Location & "\EXODUS.BIN") Then
            If System.IO.File.Exists(U3Location & "\DIVIDED\EXODUS.BIN") Then
                UltimoreInstalled = True
                UltimoreStatus.Text = "Installed"
                UltimoreButton.Text = "Uninstall"
            Else
                UltimoreInstalled = False
                UltimoreStatus.Text = "Not Installed"
                UltimoreButton.Text = "Install"
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub PatchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchButton.Click
        Dim ultimore = UltimoreInstalled
        If UltimoreInstalled Then
            UltimoreButton_Click(vbNull, e)
        End If

        If Not (PatchInstalled) Then

            Dim fileNames = My.Computer.FileSystem.GetFiles("Files\U3Upgrade", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U3Location & "\" & System.IO.Path.GetFileName(file), True)
            Next

            fileNames = My.Computer.FileSystem.GetFiles("Files\U3Upgrade\LOLB", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U3Location & "\LOLB\" & System.IO.Path.GetFileName(file), True)
            Next
        End If
        My.Computer.FileSystem.CopyFile("Files\DosboxBase.conf", "Files\U3Patch.conf", True)

        Dim objStreamWriter As StreamWriter


        objStreamWriter = New StreamWriter("Files\U3Patch.conf", True)
        objStreamWriter.WriteLine("mount c """ & U3Location & """")
        objStreamWriter.WriteLine("c:\")
        If Not (PatchInstalled) Then
            objStreamWriter.WriteLine("BINPAT.EXE U3UP-33.PAT")
        End If
        objStreamWriter.WriteLine("u3cfg.exe")
        objStreamWriter.WriteLine("setm.exe")
        objStreamWriter.WriteLine("exit.exe")
        objStreamWriter.Close()

        Shell("Files\Dosbox\DOSBox.exe -conf .\Files\U3Patch.conf -noconsole ", , True)

        Dim lOpenFile As System.IO.StreamReader
        Dim fileText As String
        Try
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U3Location & "\dosboxULTIMA3.CONF")
            fileText = lOpenFile.ReadToEnd
            lOpenFile.Close()

            fileText = fileText.Replace("ultima.com", "ultima3.com")
            fileText = fileText.Replace("cycles=300", "cycles=5000")

            My.Computer.FileSystem.WriteAllText(U3Location & "\dosboxULTIMA3.CONF", fileText, False, System.Text.Encoding.ASCII)
        Catch exp As System.Exception
        End Try
        Try
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U3Location & DosboxExeConfig)
            fileText = lOpenFile.ReadToEnd
            lOpenFile.Close()

            fileText = fileText.Replace("ultima.com", "ultima3.com")
            fileText = fileText.Replace("cycles=300", "cycles=5000")

            My.Computer.FileSystem.WriteAllText(U3Location & DosboxExeConfig, fileText, False, System.Text.Encoding.ASCII)
        Catch exp As System.Exception
        End Try

        SetGameLocation(U3Location)
        If ultimore And Not UltimoreInstalled Then
            UltimoreButton_Click(vbNull, e)
        End If
    End Sub

    Private Sub GraphicsModeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GraphicsModeButton.Click
        Dim ultimore = UltimoreInstalled
        If UltimoreInstalled Then
            UltimoreButton_Click(vbNull, e)
        End If

        Dim lOpenFile As System.IO.StreamReader
        Dim fileText As String
        My.Computer.FileSystem.CopyFile("Files\DosboxBase.conf", "Files\U3Patch.conf", True)

        Dim objStreamWriter As StreamWriter

        objStreamWriter = New StreamWriter("Files\U3Patch.conf", True)
        objStreamWriter.WriteLine("mount c """ & U3Location & """")
        objStreamWriter.WriteLine("c:\")
        objStreamWriter.WriteLine("BINUNPAT.EXE U3UP-30.PAT")
        objStreamWriter.WriteLine("BINUNPAT.EXE U3UP-31.PAT")
        objStreamWriter.WriteLine("BINUNPAT.EXE U3UP-32.PAT")
        objStreamWriter.WriteLine("BINUNPAT.EXE U3UP-33.PAT")
        objStreamWriter.WriteLine("del U3.CFG")
        objStreamWriter.WriteLine("exit.exe")
        objStreamWriter.Close()

        Shell("Files\Dosbox\DOSBox.exe -conf .\Files\U3Patch.conf -noconsole ", , True)
        Try
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U3Location & "\dosboxULTIMA3.CONF")
            fileText = lOpenFile.ReadToEnd
            lOpenFile.Close()

            fileText = fileText.Replace("ultima3.com", "ultima.com")
            fileText = fileText.Replace("cycles=5000", "cycles=300")

            My.Computer.FileSystem.WriteAllText(U3Location & "\dosboxULTIMA3.CONF", fileText, False, System.Text.Encoding.ASCII)
        Catch exp As System.Exception
        End Try
        Try
            lOpenFile = My.Computer.FileSystem.OpenTextFileReader(U3Location & DosboxExeConfig)
            fileText = lOpenFile.ReadToEnd
            lOpenFile.Close()

            fileText = fileText.Replace("ultima3.com", "ultima.com")
            fileText = fileText.Replace("cycles=5000", "cycles=300")

            My.Computer.FileSystem.WriteAllText(U3Location & DosboxExeConfig, fileText, False, System.Text.Encoding.ASCII)
        Catch exp As System.Exception
        End Try

        SetGameLocation(U3Location)
        If ultimore And Not UltimoreInstalled Then
            UltimoreButton_Click(vbNull, e)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MainMenu.Show()
        Me.Close()
    End Sub

    Private Sub AltEGAToggleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltEGAToggleButton.Click
        If AltEGA Then
            My.Computer.FileSystem.CopyFile("Files\U3Upgrade\shapes.ega", U3Location & "\shapes.ega", True)
            SetGameLocation(U3Location)
        Else
            My.Computer.FileSystem.CopyFile("Files\U3alt_shapes.ega", U3Location & "\shapes.ega", True)
            SetGameLocation(U3Location)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Ultima3DirectoryDialog.ShowDialog() = DialogResult.OK Then
            If (SetGameLocation(Ultima3DirectoryDialog.SelectedPath)) Then
                Return
            Else
                MsgBox("Game not found in this location.")
            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Shell("explorer.exe http://exodus.voyd.net")
    End Sub

    Private Sub UltimoreButton_Click(sender As Object, e As EventArgs) Handles UltimoreButton.Click
        If UltimoreInstalled Then
            If My.Computer.FileSystem.DirectoryExists(U3Location & "\DIVIDED") Then
                My.Computer.FileSystem.DeleteDirectory(U3Location & "\DIVIDED", FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
            If My.Computer.FileSystem.DirectoryExists(U3Location & "\EGYPT") Then
                My.Computer.FileSystem.DeleteDirectory(U3Location & "\EGYPT", FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If

            My.Computer.FileSystem.CopyFile("Files\dosboxULTIMA3_single.conf.orig", U3Location & "\" & System.IO.Path.GetFileName("dosboxULTIMA3_single.conf"), True)
        Else
            ' Divided
            If Not My.Computer.FileSystem.DirectoryExists(U3Location & "\DIVIDED") Then
                My.Computer.FileSystem.CreateDirectory(U3Location & "\DIVIDED")
            End If

            Dim fileNames = My.Computer.FileSystem.GetFiles(U3Location, FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U3Location & "\DIVIDED\" & System.IO.Path.GetFileName(file), True)
            Next

            fileNames = My.Computer.FileSystem.GetFiles("Files\U3UltimoreWorldDivided", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U3Location & "\DIVIDED\" & System.IO.Path.GetFileName(file), True)
            Next
            If My.Computer.FileSystem.DirectoryExists(U3Location & "\cloud_saves") Then
                If Not My.Computer.FileSystem.DirectoryExists(U3Location & "\cloud_saves\DIVIDED") Then
                    My.Computer.FileSystem.CreateDirectory(U3Location & "\cloud_saves\DIVIDED")
                End If
            End If

            If PatchInstalled Then
                My.Computer.FileSystem.CopyFile("Files\U3UltimoreWorldDivided\EXODUS.BIN.UPGRADEPATCHVERSION", U3Location & "\DIVIDED\EXODUS.BIN", True)
            End If

            ' Egypt
            If Not My.Computer.FileSystem.DirectoryExists(U3Location & "\EGYPT") Then
                My.Computer.FileSystem.CreateDirectory(U3Location & "\EGYPT")
            End If

            fileNames = My.Computer.FileSystem.GetFiles(U3Location, FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U3Location & "\EGYPT\" & System.IO.Path.GetFileName(file), True)
            Next

            fileNames = My.Computer.FileSystem.GetFiles("Files\U3UltimoreEgypt", FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            For Each file In fileNames
                My.Computer.FileSystem.CopyFile(file, U3Location & "\EGYPT\" & System.IO.Path.GetFileName(file), True)
            Next
            If My.Computer.FileSystem.DirectoryExists(U3Location & "\cloud_saves") Then
                If Not My.Computer.FileSystem.DirectoryExists(U3Location & "\cloud_saves\EGYPT") Then
                    My.Computer.FileSystem.CreateDirectory(U3Location & "\cloud_saves\EGYPT")
                End If
            End If

            If PatchInstalled Then
                My.Computer.FileSystem.CopyFile("Files\U3UltimoreEgypt\PatchedExodus\EXODUS.BIN", U3Location & "\EGYPT\EXODUS.BIN", True)
            End If

            ' config
            My.Computer.FileSystem.CopyFile("Files\dosboxULTIMA3_single.conf.ultimore", U3Location & "\" & System.IO.Path.GetFileName("dosboxULTIMA3_single.conf"), True)
            If PatchInstalled Then
                Dim fileReader As String = My.Computer.FileSystem.ReadAllText(U3Location & "\" & System.IO.Path.GetFileName("dosboxULTIMA3_single.conf")).Replace("ultima.com", "ultima3.com")
                My.Computer.FileSystem.WriteAllText(U3Location & "\" & System.IO.Path.GetFileName("dosboxULTIMA3_single.conf"), fileReader, False)
            End If
        End If

        SetGameLocation(U3Location)
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Shell("explorer.exe https://daemon-master.itch.io/ultimore-a-world-divided")
    End Sub
End Class