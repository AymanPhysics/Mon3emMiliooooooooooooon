Public Class Entry

    Public Flag As Integer = 1
    Dim ss As New Screens
    Private Sub Entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FullScreen()
    End Sub
    Sub FullScreen()
        Top = 0
        Left = 0
        ss.Screens_Load(1280, 800)
    End Sub
    Dim i As Integer = 0

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Flag = 2 Then
            i += 1
            Select Case i
                Case 1
                    lod(Global.Mon3emMiliooooooooooooon.My.Resources.a10)
                Case 2
                    lod(Global.Mon3emMiliooooooooooooon.My.Resources.a9)
                Case 3
                    lod(Global.Mon3emMiliooooooooooooon.My.Resources.a8)
                Case 4
                    lod(Global.Mon3emMiliooooooooooooon.My.Resources.a7)
                Case 5
                    lod(Global.Mon3emMiliooooooooooooon.My.Resources.a6)
                Case 6
                    lod(Global.Mon3emMiliooooooooooooon.My.Resources.a5)
                Case 7
                    lod(Global.Mon3emMiliooooooooooooon.My.Resources.a4)
                Case 8
                    lod(Global.Mon3emMiliooooooooooooon.My.Resources.a3)
                Case 9
                    lod(Global.Mon3emMiliooooooooooooon.My.Resources.a2)
                Case 10
                    lod(Global.Mon3emMiliooooooooooooon.My.Resources.a1)
                Case 11
                    Close()
            End Select

        End If
        

    End Sub

    Sub lod(ByVal aa As Bitmap)
        For i As Integer = 100 To 0 Step -1
            Opacity = i / 100
            Threading.Thread.Sleep(10)
        Next
        BackgroundImage = aa
        Refresh()
        For i As Integer = 0 To 100
            Opacity = i / 100
            Threading.Thread.Sleep(10)
        Next
    End Sub

End Class