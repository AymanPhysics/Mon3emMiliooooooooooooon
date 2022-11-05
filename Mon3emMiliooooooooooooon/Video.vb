Public Class Video

    Dim ss As New Screens
    Private Sub Video_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FullScreen()
        Try
            If IO.File.Exists("Data\Physics") Then IO.File.Delete("Data\Physics")
            Dim a As New IO.FileStream("Data\Physics", IO.FileMode.CreateNew)
            a.Close()
            IO.File.WriteAllBytes("Data\Physics", Global.Mon3emMiliooooooooooooon.My.Resources._111)
            AxWindowsMediaPlayer1.URL = "Data\Physics"
            AxWindowsMediaPlayer1.settings.volume = 100
            AxWindowsMediaPlayer1.stretchToFit = True
            AxWindowsMediaPlayer1.BeginInit()
        Catch ex As Exception

        End Try
    End Sub

    Sub FullScreen()
        Top = 0
        Left = 0
        ss.Screens_Load(1280, 800)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Video_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        DestroyHandle()
    End Sub

End Class