Imports System.IO

Public Class ListForm


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim f As String() = Directory.GetFiles(Application.StartupPath & "\data")
        For Each fil As String In f
            If fil.EndsWith(".xml") Then
                ListBox1.Items.Add(fil.Replace(Application.StartupPath & "\data\", "").Replace(".xml", ""))
            End If
        Next
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        Close()
    End Sub
End Class
