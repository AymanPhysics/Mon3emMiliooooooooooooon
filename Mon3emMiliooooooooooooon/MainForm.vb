Imports System.Data
Imports System.IO
Imports System.Data.OleDb
Imports System.Xml

Public Class MainForm

    Dim ss As New Screens
    Dim CurrDegree As Integer = 0
    Dim TrueResult As Integer = 4
    Dim CurrentLesson As String = ""



    Structure Questions
        Dim Id As Integer
        Dim Question As String
        Dim Ans1 As String
        Dim Ans2 As String
        Dim Ans3 As String
        Dim Ans4 As String
        Dim Result As String
    End Structure

    Dim Question(15) As Questions

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked, LinkLabel2.LinkClicked, LinkLabel3.LinkClicked, LinkLabel4.LinkClicked
        Dim a As LinkLabel = sender
        TestSolution(a.Tag)
        ResetLinks()
    End Sub


    Sub TestSolution(ByVal MyTag As String)
        Dim Pic As New PictureBox
        Select Case MyTag
            Case 1
                Pic = PictureBox1
            Case 2
                Pic = PictureBox2
            Case 3
                Pic = PictureBox3
            Case 4
                Pic = PictureBox4
        End Select

        If MyTag = TrueResult Then
            Pic.Image = GreenImage.Image
            Refresh()
            For i As Integer = 0 To 2
                Threading.Thread.Sleep(50)
                Pic.Image = BlackImage.Image
                Refresh()
                Threading.Thread.Sleep(50)
                Pic.Image = GreenImage.Image
                Refresh()
            Next
            CurrDegree += 1
            LoadList()
            LoadOne(CurrDegree)
        Else
            Pic.Image = RedImage.Image
            Refresh()
            Threading.Thread.Sleep(2000)

            Select Case TrueResult
                Case 1
                    Pic = PictureBox1
                Case 2
                    Pic = PictureBox2
                Case 3
                    Pic = PictureBox3
                Case 4
                    Pic = PictureBox4
            End Select

            Pic.Image = GreenImage.Image
            Refresh()
            For i As Integer = 0 To 2
                Threading.Thread.Sleep(50)
                Pic.Image = BlackImage.Image
                Refresh()
                Threading.Thread.Sleep(50)
                Pic.Image = GreenImage.Image
                Refresh()
            Next
            Threading.Thread.Sleep(2000)
            GameOver()
        End If
        Threading.Thread.Sleep(2000)
        ClearImages()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ss.Screens_FormClosing()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FullScreen()
        ClearImages()
        LoadList()
        loadCategory()
    End Sub

    Sub loadCategory()
        Dim f As New ListForm
        f.ShowDialog()
        CurrentLesson = f.ListBox1.SelectedItem
        If CurrentLesson = Nothing Then
            Application.Exit()
        End If
        LoadQuestion(CurrentLesson)
        LoadOne(0)
    End Sub
    Sub LoadOne(ByVal i As Integer)

        lblQuestion.Text = Question(i).Question
        LinkLabel1.Text = Question(i).Ans1
        LinkLabel2.Text = Question(i).Ans2
        LinkLabel3.Text = Question(i).Ans3
        LinkLabel4.Text = Question(i).Ans4
        TrueResult = 0
        Select Case Question(i).Result
            Case "أ"
                TrueResult = 1
            Case "ب"
                TrueResult = 2
            Case "ج"
                TrueResult = 3
            Case "د"
                TrueResult = 4
        End Select

    End Sub

    Sub LoadQuestion(ByVal FileName As String)
        Try
            Dim objXMLTR As New XmlTextReader("data\" & FileName & ".xml")
            Dim sCategory As String
            Dim bNested As Boolean
            Dim sLastElement As String = ""
            Dim sValue As String
            ReDim Question(15)

            Dim Id As Integer = 0
            Do While objXMLTR.Read

                If objXMLTR.NodeType = XmlNodeType.Element Then

                    bNested = True
                    sLastElement = objXMLTR.Name

                ElseIf objXMLTR.NodeType = XmlNodeType.Text Or objXMLTR.NodeType = XmlNodeType.CDATA Then

                    bNested = False
                    sValue = objXMLTR.Value

                    Select Case sLastElement
                        Case "Id"
                            Id = objXMLTR.Value - 1
                        Case "Question"
                            Question(Id).Question = objXMLTR.Value
                        Case "Answer1"
                            Question(Id).Ans1 = objXMLTR.Value
                        Case "Answer2"
                            Question(Id).Ans2 = objXMLTR.Value
                        Case "Answer3"
                            Question(Id).Ans3 = objXMLTR.Value
                        Case "Answer4"
                            Question(Id).Ans4 = objXMLTR.Value
                        Case "RightAnswer"
                            Question(Id).Result = objXMLTR.Value
                    End Select

                    sLastElement = ""
                    sCategory = ""
                End If
            Loop
            objXMLTR.Close()
        Catch Ex As Exception
            Ex = Ex
        End Try

    End Sub

    Sub FullScreen()
        Top = 0
        Left = 0
        ss.Screens_Load(1280, 800)
    End Sub

    Sub ClearImages()
        PictureBox1.Image = BlackImage.Image
        PictureBox2.Image = BlackImage.Image
        PictureBox3.Image = BlackImage.Image
        PictureBox4.Image = BlackImage.Image

    End Sub

    Sub LoadList()
        ListPic0.Visible = False
        ListPic1.Visible = False
        ListPic2.Visible = False
        ListPic3.Visible = False
        ListPic4.Visible = False
        ListPic5.Visible = False
        ListPic6.Visible = False
        ListPic7.Visible = False
        ListPic8.Visible = False
        ListPic9.Visible = False
        ListPic10.Visible = False
        ListPic11.Visible = False
        ListPic12.Visible = False
        ListPic13.Visible = False
        ListPic14.Visible = False
        ListPic15.Visible = False
        Select Case CurrDegree
            Case 1
                ListPic1.Visible = True
            Case 2
                ListPic2.Visible = True
            Case 3
                ListPic3.Visible = True
            Case 4
                ListPic4.Visible = True
            Case 5
                ListPic5.Visible = True
            Case 6
                ListPic6.Visible = True
            Case 7
                ListPic7.Visible = True
            Case 8
                ListPic8.Visible = True
            Case 9
                ListPic9.Visible = True
            Case 10
                ListPic10.Visible = True
            Case 11
                ListPic11.Visible = True
            Case 12
                ListPic12.Visible = True
            Case 13
                ListPic13.Visible = True
            Case 14
                ListPic14.Visible = True
            Case 15
                ListPic15.Visible = True


        End Select
    End Sub

    Private Sub Pic50En_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic50En.MouseClick
        Pic50Dis.Visible = True

        Dim x As Integer = 0

        If TrueResult <> 1 And x < 2 Then
            LinkLabel1.Visible = False
            x += 1
        End If


        If TrueResult <> 2 And x < 2 Then
            LinkLabel2.Visible = False
            x += 1
        End If


        If TrueResult <> 3 And x < 2 Then
            LinkLabel3.Visible = False
            x += 1
        End If


        If TrueResult <> 4 And x < 2 Then
            LinkLabel4.Visible = False
            x += 1
        End If

    End Sub


    Sub ResetLinks()
        LinkLabel1.Visible = True
        LinkLabel2.Visible = True
        LinkLabel3.Visible = True
        LinkLabel4.Visible = True
    End Sub

    Private Sub PicCallEn_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicCallEn.MouseClick
        PicCallDis.Visible = True
        Dim f As New FormCall

        Select Case TrueResult
            Case 1
                f.Result = LinkLabel1.Text
            Case 2
                f.Result = LinkLabel2.Text
            Case 3
                f.Result = LinkLabel3.Text
            Case 4
                f.Result = LinkLabel4.Text
        End Select
        f.ShowDialog()
    End Sub

    Private Sub PicAskEn_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicAskEn.MouseClick
        PicAskDis.Visible = True
        Dim f As New FormAsk
        f.Pic = TrueResult
        f.ShowDialog()
    End Sub

    Private Sub btnNewGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGame.Click
        CurrDegree = 0
        LoadList()
        ClearImages()
        ResetLinks()
        PicAskDis.Visible = False
        PicCallDis.Visible = False
        Pic50Dis.Visible = False
    End Sub

    Sub GameOver()
        LinkLabel1.Text = ""
        LinkLabel2.Text = ""
        LinkLabel3.Text = ""
        LinkLabel4.Text = ""
        lblQuestion.Text = ""

        ClearImages()


        MessageBox.Show("U R DON...")
        btnNewGame_Click(Nothing, Nothing)
        Form1_Load(Nothing, Nothing)
    End Sub

    Private Sub PicExit_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicExit.MouseClick
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class
