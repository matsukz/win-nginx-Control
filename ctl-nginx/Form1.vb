Imports System.Diagnostics
Imports System.Text

Public Class Form1

    '起動FLAG (True = 起動中 Flase = 停止)
    Public Shared nginx_status_flag As Boolean = False

    '実行ファイルのパスを格納する。このEXEとnginx.exeが同じ場所にあることが前提
    Dim strPath As String = Application.StartupPath '実行中のディレクトリ
    Dim nginxExe As String = IO.Path.Combine(strPath, "nginx.exe") 'strPathの合わせたnginx.exeのパス

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Button1.Enabled = False
        Button1.Cursor = Cursors.WaitCursor

        If nginx_status_flag = True Then
            '起動中なので停止処理を実行する
            exec_nginx_cmd.stop_cmd(nginxExe:=nginxExe, strPath:=strPath)
        Else
            '停止中なので開始処理をする
            If exec_nginx_cmd.syntax_test(nginxExe:=nginxExe, strPath:=strPath, result_window:=False) Then
                exec_nginx_cmd.start_cmd(nginxExe:=nginxExe, strPath:=strPath)
            Else
                MessageBox.Show(
                    "nginxの設定に誤りがあるため起動できません。" & vbCrLf & "「操作」からシンタックスチェックを実行してエラーを修正してください",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error
                )
                Button1.Enabled = True
                Button1.Cursor = Cursors.Hand
                Exit Sub
            End If
        End If

        '開始/停止を確認するために待機する
        Threading.Thread.Sleep(3000)
        health.check()
        Button1.Cursor = Cursors.Hand
        Button1.Enabled = True

    End Sub


    Private Sub Form_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not IO.File.Exists(nginxExe) Then
            MessageBox.Show("nginx.exeが見つかりません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End If

        '起動時に状態を確認する
        health.check()

    End Sub

    Private Sub 設定ファイルの確認nginxtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 設定ファイルの確認nginxtToolStripMenuItem.Click
        exec_nginx_cmd.syntax_test(nginxExe:=nginxExe, strPath:=strPath, result_window:=True)
    End Sub

    Private Sub 状態を再取得ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 状態を再取得ToolStripMenuItem.Click
        health.check()
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