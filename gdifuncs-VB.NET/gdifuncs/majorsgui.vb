' The original source code made by rootabx is available at: https://github.com/Gork3m/MrsMajor-3.0
' rewritten in VB.NET by Angel Castillo / Windows Vista

Imports System.Drawing
Imports System.Windows.Forms

Public Class majorsgui

    Dim alrdyfed As Integer = 0
    Dim draging As Boolean = False
    Dim isInjected As Boolean = False
    Dim p64 As New protection64
    Dim pointclicked As Point
    Private Sub flogon()
        p64.logonuiOWR()
    End Sub

    Private Sub majorsgui_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TransparencyKey = Color.Red
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PictureBox6.Size = New Size(PictureBox6.Size.Width, PictureBox6.Size.Height + 1)
        If PictureBox6.Size.Height > 330 AndAlso alrdyfed = 0 Then
            alrdyfed = 1
            p64.logonuiOWR()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'p64.logonuiOWR()
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = MouseButtons.Left Then
            draging = True
            pointclicked = New Point(e.X, e.Y)
        Else
            draging = False
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        draging = False
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If draging Then
            Dim pointMoveTo As Point
            pointMoveTo = Me.PointToScreen(New Point(e.X, e.Y))
            pointMoveTo.Offset(-pointclicked.X, -pointclicked.Y)
            Me.Location = pointMoveTo
        End If
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        Select Case e.CloseReason
            Case CloseReason.UserClosing
                e.Cancel = True
        End Select
        MyBase.OnFormClosing(e)
    End Sub
End Class
