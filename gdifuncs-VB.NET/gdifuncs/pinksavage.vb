' The original source code made by rootabx is available at: https://github.com/Gork3m/MrsMajor-3.0
' rewritten in VB.NET by Angel Castillo / Windows Vista

Imports System.Windows.Forms

Public Class pinksavage
    Dim cur As Double = 0.05
    Dim akis As Integer = 0
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim wew As CreateParams = MyBase.CreateParams
            wew.ExStyle = MyBase.CreateParams.ExStyle Or &H20
            Return wew
        End Get
    End Property
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        Select Case e.CloseReason
            Case CloseReason.UserClosing
                e.Cancel = True
        End Select
        MyBase.OnFormClosing(e)
    End Sub
    Private Sub pinksavage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.TopMost = False
        Me.TopMost = True
        If cur > 0.6 Then
            akis = 1
            cur = 0.59
        End If

        If cur < 0.05 Then
            akis = 0
        End If

        If akis = 1 Then
            cur = cur - 0.01
        Else
            cur = cur + 0.01
        End If

        Me.Opacity = cur
    End Sub
End Class