Imports System.Text.RegularExpressions

Module health
    Sub check()
        Dim ps = Process.GetProcessesByName("nginx") ' nginx.exe → "nginx"

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
            Dim display_pids As String = ""
            For Each p In ps
                Dim pid = p.Id
                Dim name = p.ProcessName
                ' 状態表示など
                display_pids = display_pids & pid & vbCrLf
            Next

            Dim eps = GetListeningLocalEndpointsForNginx()
            Dim display_ports As String = ""
            For Each e In eps
                display_ports = display_ports & e & vbCrLf
            Next

            Form1.label_status.Text = "Active"
            Form1.label_status.BackColor = ColorTranslator.FromOle(RGB(128, 255, 128))
            Form1.label_pid.Text = display_pids
            Form1.label_ports.Text = display_ports
            Form1.Button1.BackColor = ColorTranslator.FromOle(RGB(255, 128, 128))
            Form1.Button1.Text = "■STOP"

            Form1.nginx_status_flag = True
        End If
    End Sub

    Private Function GetListeningLocalEndpointsForNginx() As List(Of String)
        Dim nginxPids As New HashSet(Of Integer)(
        Process.GetProcessesByName("nginx").Select(Function(x) x.Id)
    )

        Dim endpoints As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

        If nginxPids.Count = 0 Then
            Return endpoints.ToList()
        End If

        Dim psi As New ProcessStartInfo() With {
            .FileName = "cmd.exe",
            .Arguments = "/c netstat -ano -p tcp",
            .UseShellExecute = False,
            .CreateNoWindow = True,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True
        }

        Using p = Process.Start(psi)
            Dim output = p.StandardOutput.ReadToEnd()
            p.WaitForExit()

            For Each line In output.Split({vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)
                Dim t = line.Trim()
                ' 例: TCP  0.0.0.0:80  0.0.0.0:0  LISTENING  1234
                If Not t.StartsWith("TCP", StringComparison.OrdinalIgnoreCase) Then Continue For
                If Not t.Contains("LISTENING") Then Continue For

                Dim parts = Regex.Split(t, "\s+")
                If parts.Length < 5 Then Continue For

                Dim localAddr = parts(1)   ' 0.0.0.0:80 や [::]:443
                Dim pidStr = parts(4)

                Dim pid As Integer
                If Integer.TryParse(pidStr, pid) AndAlso nginxPids.Contains(pid) Then
                    ' 見た目を揃えたいならここで加工
                    endpoints.Add(localAddr)
                End If
            Next
        End Using

        ' 表示順を見やすく（80→443など）したいなら簡易ソート
        Return endpoints.OrderBy(Function(s) s).ToList()
    End Function


End Module
