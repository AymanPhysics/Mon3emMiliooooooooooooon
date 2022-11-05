Public Class FormAsk
    Public Pic As Integer = 1
    Private Sub FormAsk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case Pic
            Case 1
                BackgroundImage = PictureBox1.Image
            Case 2
                BackgroundImage = PictureBox2.Image
            Case 3
                BackgroundImage = PictureBox3.Image
            Case 4
                BackgroundImage = PictureBox4.Image
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class