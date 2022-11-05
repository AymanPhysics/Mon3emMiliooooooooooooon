Imports System.Runtime.InteropServices

Public Class Screens
    Const ENUM_CURRENT_SETTINGS As Integer = -1
    Const CDS_UPDATEREGISTRY As Integer = &H1
    Const CDS_TEST As Long = &H2
    Const CCDEVICEhguhgNAME As Integer = 32
    Const CCFORMNAME As Integer = 32
    Const DISP_CHANGE_SUCCESSFUL As Integer = 0
    Const DISP_CHANGE_RESTART As Integer = 1
    Const DISP_CHANGE_FAILED As Integer = -1
    Private Declare Function EnumDisplaySettings Lib "user32" Alias "EnumDisplaySettingsA" (ByVal lpszDeviceName As Integer, ByVal iModeNum As Integer, ByRef lpDevMode As DEVMODE) As Integer
    Private Declare Function ChangeDisplaySettings Lib "user32" Alias "ChangeDisplaySettingsA" (ByRef DEVMODE As DEVMODE, ByVal flags As Long) As Integer

    <StructLayout(LayoutKind.Sequential)> Public Structure DEVMODE
        <MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst:=CCDEVICEhguhgNAME)> Public dmDeviceName As String
        Public dmSpecVersion As Short
        Public dmDriverVersion As Short
        Public dmSize As Short
        Public dmDriverExtra As Short
        Public dmFields As Integer
        Public dmOrientation As Short
        Public dmPaperSize As Short
        Public dmPaperLength As Short
        Public dmPaperWidth As Short
        Public dmScale As Short
        Public dmCopies As Short
        Public dmDefaultSource As Short
        Public dmPrintQuality As Short
        Public dmColor As Short
        Public dmDuplex As Short
        Public dmYResolution As Short
        Public dmTTOption As Short
        Public dmCollate As Short
        <MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst:=CCFORMNAME)> Public dmFormName As String
        Public dmUnusedPadding As Short
        Public dmBitsPerPel As Short
        Public dmPelsWidth As Integer
        Public dmPelsHeight As Integer
        Public dmDisplayFlags As Integer
        Public dmDisplayFrequency As Integer
    End Structure
    Public Sub changeRes(ByVal theWidth As Integer, ByVal theHeight As Integer)
        Dim DevM As DEVMODE
        DevM.dmDeviceName = New [String](New Char(32) {})
        DevM.dmFormName = New [String](New Char(32) {})
        DevM.dmSize = CShort(Marshal.SizeOf(GetType(DEVMODE)))

        If 0 <> EnumDisplaySettings(Nothing, ENUM_CURRENT_SETTINGS, DevM) Then
            Dim lResult As Integer
            DevM.dmPelsWidth = theWidth
            DevM.dmPelsHeight = theHeight
            DevM.dmPelsWidth = theWidth
            DevM.dmPelsHeight = theHeight
            lResult = ChangeDisplaySettings(DevM, CDS_TEST)
            lResult = ChangeDisplaySettings(DevM, CDS_UPDATEREGISTRY)
        End If
    End Sub


    Dim ScreenWidth As Integer = 0
    Dim ScreenHight As Integer = 0

    Public Sub Screens_FormClosing()

        Call changeRes(ScreenWidth, ScreenHight)
    End Sub
    Public Sub Screens_Load(ByVal theWidth As Integer, ByVal theHeight As Integer)
        ScreenWidth = Screen.PrimaryScreen.Bounds.Size.Width
        ScreenHight = Screen.PrimaryScreen.Bounds.Size.Height
        Call changeRes(theWidth, theHeight)
    End Sub


    Private Sub Screens_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class