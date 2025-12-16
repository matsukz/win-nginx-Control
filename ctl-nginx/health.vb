Module health
    Sub check()

        Dim ps = Process.GetProcessesByName("nginx") ' nginx.exe → "nginx"

        Dim display_pids As String = ""

        If ps.Length = 0 Then
            ' 動いていない
            Form1.label_status.Text = "Inactive"
            Form1.label_status.BackColor = ColorTranslator.FromOle(RGB(255, 128, 128))
            Form1.label_pid.Text = ""
            Form1.Button1.BackColor = ColorTranslator.FromOle(RGB(128, 255, 128))
            Form1.Button1.Text = "▶START"
            Form1.nginx_status_flag = False
        Else
            ' 動いてる（nginxは複数プロセスになることが多い）
            For Each p In ps
                Dim pid = p.Id
                Dim name = p.ProcessName
                ' 状態表示など
                display_pids = display_pids & pid & vbCrLf
            Next

            Form1.label_status.Text = "Active"
            Form1.label_status.BackColor = ColorTranslator.FromOle(RGB(128, 255, 128))
            Form1.label_pid.Text = display_pids
            Form1.Button1.BackColor = ColorTranslator.FromOle(RGB(255, 128, 128))
            Form1.Button1.Text = "■STOP"

            Form1.nginx_status_flag = True
        End If
    End Sub
End Module
