Imports System.Diagnostics

Public Class Form1

    '起動FLAG (True = 起動中 Flase = 停止)
    Dim nginx_status_flag As Boolean = False

    '実行ファイルのパスを格納する。このEXEとnginx.exeが同じ場所にあることが前提
    Dim strPath As String = Application.StartupPath '実行中のディレクトリ
    Dim nginxExe As String = IO.Path.Combine(strPath, "nginx.exe") 'strPathの合わせたnginx.exeのパス

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If nginx_status_flag = True Then

            '起動中なので停止処理を実行する
            Dim nginx_stop As New ProcessStartInfo() With {
                .FileName = nginxExe,
                .Arguments = "-s stop",
                .WorkingDirectory = strPath,
                .UseShellExecute = False,
                .CreateNoWindow = True
            }
            Process.Start(nginx_stop)

        Else

            '停止中なので開始処理をする
            Dim nginx_start As New ProcessStartInfo() With {
                .FileName = nginxExe,
                .WorkingDirectory = strPath,
                .UseShellExecute = False,
                .CreateNoWindow = True
            }
            Process.Start(nginx_start)

        End If

        '開始/停止を確認するために待機する
        Threading.Thread.Sleep(3000)
        nginx_check_status()

    End Sub


    Private Sub Form_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IO.File.Exists(nginxExe) Then
            MessageBox.Show("nginx.exeが見つかりません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End If

        '起動時に状態を確認する
        nginx_check_status()

    End Sub

    Sub nginx_check_status()

        Dim ps = Process.GetProcessesByName("nginx") ' nginx.exe → "nginx"

        Dim display_pids As String = ""

        If ps.Length = 0 Then
            ' 動いていない
            label_status.Text = "Inactive"
            label_status.BackColor = ColorTranslator.FromOle(RGB(255, 128, 128))
            label_pid.Text = ""
            Button1.BackColor = ColorTranslator.FromOle(RGB(128, 255, 128))
            Button1.Text = "▶START"
            nginx_status_flag = False
        Else
            ' 動いてる（nginxは複数プロセスになることが多い）
            For Each p In ps
                Dim pid = p.Id
                Dim name = p.ProcessName
                ' 状態表示など
                display_pids = display_pids & pid & vbCrLf
            Next

            label_status.Text = "Active"
            label_status.BackColor = ColorTranslator.FromOle(RGB(128, 255, 128))
            label_pid.Text = display_pids
            Button1.BackColor = ColorTranslator.FromOle(RGB(255, 128, 128))
            Button1.Text = "■STOP"

            nginx_status_flag = True

        End If
    End Sub

    Private Sub 設定ファイルの確認nginxtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 設定ファイルの確認nginxtToolStripMenuItem.Click

    End Sub

    Private Sub 状態を再取得ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 状態を再取得ToolStripMenuItem.Click
        nginx_check_status()
    End Sub

    Private Sub エクスプローラーで開くToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles エクスプローラーで開くToolStripMenuItem.Click
        Process.Start(strPath)
    End Sub

    Private Sub コマンドプロンプトToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles コマンドプロンプトToolStripMenuItem.Click
        Dim cmd_start As New ProcessStartInfo("cmd.exe") With {
            .Arguments = "/K cd /d """ & strPath & """",
            .UseShellExecute = True
        }
        Process.Start(cmd_start)
    End Sub

    Private Sub ウィンドウを閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ウィンドウを閉じるToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub Nginxconfを開くToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Nginxconfを開くToolStripMenuItem.Click
        Process.Start(strPath & "\conf\nginx.conf")
    End Sub

    Private Sub PIDから強制終了ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PIDから強制終了ToolStripMenuItem.Click

    End Sub
End Class