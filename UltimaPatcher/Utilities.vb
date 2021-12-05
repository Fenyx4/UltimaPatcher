Module Utilities
    Public Function FileComp(ByVal File1 As String, ByVal File2 As String) As Boolean
        If Dir(File1) = "" Then Return False
        If Dir(File2) = "" Then Return False
        Dim a As Byte() = My.Computer.FileSystem.ReadAllBytes(File1)
        Dim b As Byte() = My.Computer.FileSystem.ReadAllBytes(File2)

        If a.Length <> b.Length Then
            Return False
        End If

        Dim Success As Boolean = True

        For I As Integer = 0 To a.Length - 1

            If a(I) <> b(I) Then
                Success = False
                Exit For
            End If
        Next

        Return Success
    End Function

    Declare Function GetUserName Lib "advapi32.dll" Alias _ 
       "GetUserNameA" (ByVal lpBuffer As String, _
       ByRef nSize As Integer) As Integer

    Public Function GetUserName() As String
        Dim iReturn As Integer
        Dim userName As String
        userName = New String(CChar(" "), 50)
        iReturn = GetUserName(userName, 50)
        GetUserName = userName.Substring(0, userName.IndexOf(Chr(0)))
    End Function

End Module
