Imports System.Xml
Imports System.Text
Imports System.IO
Public Class XML

    
    Private Sub btnWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWrite.Click

        Dim enc As Encoding
        Dim objXMLTW As New XmlTextWriter("data\" & ComboBox1.Text & ".xml", enc)
        objXMLTW.WriteStartDocument()
        objXMLTW.WriteStartElement("Applicant")


        Try
            For i As Integer = 0 To 14
            objXMLTW.WriteStartElement("Id")
                objXMLTW.WriteString(DataGridView1.Rows(i).Cells(0).Value)
            objXMLTW.WriteEndElement()

            objXMLTW.WriteStartElement("Question")
                objXMLTW.WriteString(DataGridView1.Rows(i).Cells(1).Value)
            objXMLTW.WriteEndElement()

            objXMLTW.WriteStartElement("Answer1")
                objXMLTW.WriteString(DataGridView1.Rows(i).Cells(2).Value)
            objXMLTW.WriteEndElement()

            objXMLTW.WriteStartElement("Answer2")
                objXMLTW.WriteString(DataGridView1.Rows(i).Cells(3).Value)
            objXMLTW.WriteEndElement()

            objXMLTW.WriteStartElement("Answer3")
                objXMLTW.WriteString(DataGridView1.Rows(i).Cells(4).Value)
            objXMLTW.WriteEndElement()

            objXMLTW.WriteStartElement("Answer4")
                objXMLTW.WriteString(DataGridView1.Rows(i).Cells(5).Value)
            objXMLTW.WriteEndElement()

                objXMLTW.WriteStartElement("RightAnswer")
                objXMLTW.WriteString(DataGridView1.Rows(i).Cells(6).Value)
            objXMLTW.WriteEndElement()

            Next

            objXMLTW.WriteEndElement() 'End top level element
            objXMLTW.WriteEndDocument() 'End Document
            objXMLTW.Flush() 'Write to file
            objXMLTW.Close()
        Catch Ex As Exception
        End Try
        ComboBox1.SelectedIndex = -1
        XML_Load(Nothing, Nothing)
    End Sub



    Sub ReadXML(ByVal FileName As String)
        Try
            Dim objXMLTR As New XMLTextReader(FileName)
            Dim sCategory As String
            Dim bNested As Boolean
            Dim sLastElement As String = ""
            Dim sValue As String

            Do While objXMLTR.Read

                'Output elements and values
                'Look at output in browser and compare to menu.xml file to 
                'see exactly what is being done
                If objXMLTR.NodeType = XMLNodeType.Element Then

                    bNested = True
                    sLastElement = objXMLTR.Name

                ElseIf objXMLTR.NodeType = XmlNodeType.Text Or objXMLTR.NodeType = XmlNodeType.CDATA Then
                    bNested = False
                    sValue = objXMLTR.Value



                    'Select Case sLastElement
                    '    Case "Id"
                    '        txtId.Text = objXMLTR.Value
                    '    Case "Question"
                    '        txtQuestion.Text = objXMLTR.Value
                    '    Case "Answer1"
                    '        Q1Anser1.Text = objXMLTR.Value
                    '    Case "Answer2"
                    '        Q1Anser2.Text = objXMLTR.Value
                    '    Case "Answer3"
                    '        Q1Anser3.Text = objXMLTR.Value
                    '    Case "Answer4"
                    '        Q1Anser4.Text = objXMLTR.Value
                    '    Case "RightAnswer"
                    '        txtAnswer.Text = objXMLTR.Value

                    'End Select




                    sLastElement = ""
                    sCategory = ""
                End If
            Loop
            objXMLTR.close()
        Catch Ex As Exception
        End Try

    End Sub

    Private Sub XML_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearGrid()
        ComboBox1.Items.Clear()
        Dim f As String() = Directory.GetFiles(Application.StartupPath & "\data")
        For Each fil As String In f
            If fil.EndsWith(".xml") Then
                ComboBox1.Items.Add(fil.Replace(Application.StartupPath & "\data\", "").Replace(".xml", ""))
            End If
        Next
        ComboBox1.Text = ""
        ComboBox1.Focus()
    End Sub

    Sub ClearGrid()
        DataGridView1.Rows.Clear()
        For i As Integer = 0 To 14
            DataGridView1.Rows.Add()
            DataGridView1.Rows(i).Cells(0).Value = i + 1
        Next

    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        If ComboBox1.Text.Trim = "" Then Return
        ClearGrid()
        FillGrid()
    End Sub

    Sub FillGrid()
        Dim FileName As String = ComboBox1.Text
        Try
            Dim objXMLTR As New XmlTextReader("data\" & FileName & ".xml")
            Dim sCategory As String
            Dim bNested As Boolean
            Dim sLastElement As String = ""
            Dim sValue As String

            Dim Id As Integer = 0
            Do While objXMLTR.Read

                'Output elements and values
                'Look at output in browser and compare to menu.xml file to 
                'see exactly what is being done
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
                            DataGridView1.Rows(Id).Cells(1).Value = objXMLTR.Value
                        Case "Answer1"
                            DataGridView1.Rows(Id).Cells(2).Value = objXMLTR.Value
                        Case "Answer2"
                            DataGridView1.Rows(Id).Cells(3).Value = objXMLTR.Value
                        Case "Answer3"
                            DataGridView1.Rows(Id).Cells(4).Value = objXMLTR.Value
                        Case "Answer4"
                            DataGridView1.Rows(Id).Cells(5).Value = objXMLTR.Value
                        Case "RightAnswer"
                            DataGridView1.Rows(Id).Cells(6).Value = objXMLTR.Value

                    End Select




                    sLastElement = ""
                    sCategory = ""
                End If
            Loop
            objXMLTR.Close()
        Catch Ex As Exception
        End Try

    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectNextControl(sender, True, True, True, True)
        End If
    End Sub
End Class