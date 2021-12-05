Public Class Ultima1Menu
    Dim U1Directories = {"C:\GOG Games\Ultima 1", "C:\Program Files\GOG.com\Ultima Trilogy\Ultima1", "C:\Program Files (x86)\GOG.com\Ultima Trilogy\Ultima1", "C:\GOG Games\Ultima Trilogy\ULTIMA1", "C:\GOG Games\Ultima 1", "C:\Program Files (x86)\GOG Galaxy\Games\Ultima 1"}
    Dim U1Location As String
    Dim PatchInstalled As Boolean

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Ultima1DirectoryDialog.ShowDialog() = DialogResult.OK Then
            If (SetGameLocation(Ultima1DirectoryDialog.SelectedPath)) Then
                Return
            Else
                MsgBox("Game not found in this location.")
            End If
        End If
    End Sub

    Private Sub Ultima1Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        REM Attempt to locate Ultima 1 installation
        Dim d As String
        Try
            For Each d In U1Directories
                SetGameLocation(d)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
        If U1Location = "" Then
            If Ultima1DirectoryDialog.ShowDialog() = DialogResult.OK Then
                If Not (SetGameLocation(Ultima1DirectoryDialog.SelectedPath)) Then
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchButton.Click
        If PatchInstalled Then
            My.Computer.FileSystem.CopyFile("Files\U1ORIG_OUT.EXE", U1Location & "\OUT.exe", True)
            PatchInstalled = False
            PatchStatus.Text = "(Not Installed)"
            PatchButton.Text = "Install Patch"
        Else
            My.Computer.FileSystem.CopyFile("Files\U1NEW_OUT.EXE", U1Location & "\OUT.exe", True)
            PatchInstalled = True
            PatchStatus.Text = "(Installed)"
            PatchButton.Text = "Uninstall Patch"
        End If
    End Sub

    Public Function SetGameLocation(ByVal directory As String)
        If Dir(directory & "\MONDAIN.exe") <> "" Then
            U1Location = directory
            Ultima1DirectoryTextbox.Text = directory

            REM See if graphic patch installed
            Dim origfile = FileComp("Files\U1ORIG_OUT.EXE", U1Location & "\OUT.exe")
            If origfile Then
                PatchInstalled = False
                PatchStatus.Text = "(Not Installed)"
                PatchButton.Text = "Install Patch"
            Else
                PatchInstalled = True
                PatchStatus.Text = "(Installed)"
                PatchButton.Text = "Uninstall Patch"
            End If
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MainMenu.Show()
        MainMenu.Focus()
        Me.Close()
    End Sub
End Class
