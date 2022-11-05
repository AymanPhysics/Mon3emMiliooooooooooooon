Imports System.Data
Imports System.Data.OleDb

Module Module1
    Public cmd As New OleDbCommand
    Public con As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\System.mdb")
End Module
