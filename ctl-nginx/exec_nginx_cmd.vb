Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Text

Module exec_nginx_cmd
    Sub start_cmd(ByVal nginxExe As String, ByVal strPath As String)
        Dim ps As New ProcessStartInfo() With {
            .FileName = nginxExe,
            .WorkingDirectory = strPath,
            .UseShellExecute = False,
            .CreateNoWindow = True
        }
        Process.Start(ps)
    End Sub

    Sub stop_cmd(ByVal nginxExe As String, ByVal strPath As String)
        Dim nginx_stop As New ProcessStartInfo() With {
            .FileName = nginxExe,
            .Arguments = "-s stop",
            .WorkingDirectory = strPath,
            .UseShellExecute = False,
            .CreateNoWindow = True
        }
        Process.Start(nginx_stop)
    End Sub

    Function syntax_test(ByVal nginxExe As String, ByVal strPath As String, ByVal result_window As Boolean)

        Dim test_result As Boolean = False

        Dim psi As New ProcessStartInfo() With {
            .FileName = nginxExe,
            .Arguments = "-t",
            .WorkingDirectory = strPath,
            .UseShellExecute = False,
            .CreateNoWindow = True,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .StandardOutputEncoding = Encoding.UTF8,
            .StandardErrorEncoding = Encoding.UTF8
        }

        Try
            Using p As Process = Process.Start(psi)
                Dim stdout As String = p.StandardOutput.ReadToEnd()
                Dim stderr As String = p.StandardError.ReadToEnd()
                p.WaitForExit()

                Dim output As String = (stdout & Environment.NewLine & stderr).Trim()

                ' --- 成否判定 ---
                ' nginx -t は成功時 "test is successful" を出すことが多い
                ' そして ExitCode が 0 なら成功、0以外ならエラー、が基本。
                Dim ok As Boolean = (p.ExitCode = 0) OrElse output.ToLowerInvariant().Contains("test is successful")

                If ok Then
                    If result_window Then
                        MessageBox.Show(If(output = "", "OK (no output)", output),
                                    "Nginx 設定テスト：正常",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                    End If
                    test_result = True
                Else
                    If result_window Then
                        MessageBox.Show(If(output = "", $"Error (ExitCode={p.ExitCode})", output),
                                    "Nginx 設定テスト：エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)
                    End If
                    test_result = False
                End If
            End Using
        Catch ex As Exception
            If result_window Then
                MessageBox.Show(ex.ToString(), "実行エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            test_result = False
        End Try

        Return test_result

    End Function

    Sub force_quit()
        Dim confirm As DialogResult = MessageBox.Show(
            "強制終了を試みますか？" & vbCrLf & "セッションは強制終了し、ログの書き込みも停止します。",
            "確認",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation
        )

        If confirm = DialogResult.Yes Then 'いいえ = True はい = Faslse
            For Each p In Process.GetProcessesByName("nginx")
                p.Kill()
            Next
            Threading.Thread.Sleep(1500)
            health.check()
        End If
    End Sub

    Sub output_versions(ByVal strPath As String, ByVal nginxExe As String)
        Dim psi As New ProcessStartInfo() With {
            .FileName = nginxExe,
            .Arguments = "-V",
            .WorkingDirectory = strPath,
            .UseShellExecute = False,
            .CreateNoWindow = True,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .StandardOutputEncoding = Encoding.UTF8,
            .StandardErrorEncoding = Encoding.UTF8
        }

        Using p As Process = Process.Start(psi)
            ' nginx -v は stderr に出る
            Dim stdout As String = p.StandardOutput.ReadToEnd()
            Dim stderr As String = p.StandardError.ReadToEnd()
            p.WaitForExit()

            Dim output As String = (stdout & stderr).Trim()

            MessageBox.Show(output, "nginx version", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

    Function restart(ByVal strPath As String, ByVal nginxExe As String) As Boolean

        If Not syntax_test(nginxExe:=nginxExe, strPath:=strPath, result_window:=False) Then
            MessageBox.Show(
                "nginxの設定に誤りがあるため再起動できません。" & vbCrLf & "「操作」からシンタックスチェックを実行してエラーを修正してください",
                "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error
            )

            Return False

        End If

        Dim confirm As DialogResult = MessageBox.Show(
            "再起動を試みますか？" & vbCrLf & "接続中のセッションは切断されます。",
            "確認",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation
        )

        '選択肢で拒否した場合Falseを返して処理中断
        If confirm = DialogResult.No Then Return False

        Form1.Button1.Cursor = Cursors.WaitCursor

        Dim psi As New ProcessStartInfo() With {
            .FileName = nginxExe,
            .Arguments = "-s reload",
            .WorkingDirectory = strPath,
            .UseShellExecute = False,
            .CreateNoWindow = True
        }
        Process.Start(psi)

        Threading.Thread.Sleep(1500)
        health.check()

        Return True

    End Function

End Module
