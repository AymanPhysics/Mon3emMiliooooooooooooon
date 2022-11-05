Public Class LoadForm

    Private Sub LoadForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Process.GetCurrentProcess().MainModule.FileName.Replace(Application.StartupPath & "\", "").ToLower = "Mon3em.exe".ToLower Then
            Dim f As New XML
            f.Show()
        Else
            Dim a As New Entry
            a.Show()

            Dim a2 As New Entry
            a2.Flag = 2
            a2.ShowDialog()

            Dim f As New MainForm
            f.Show()

            a.Close()
        End If
        Close()

        'Dim ss As New Video
        'ss.ShowDialog()
        'Close()
        'Return

    End Sub
End Class