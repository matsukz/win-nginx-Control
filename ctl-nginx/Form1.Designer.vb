<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.label_status = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.label_pid = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ファイルToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.コマンドプロンプトToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.エクスプローラーで開くToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NGINXダウンロードサイトToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ウィンドウを閉じるToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.操作ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.状態を再取得ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.設定ファイルの確認nginxtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nginxconfを開くToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PIDから強制終了ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ソースコードGithubcomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.label_ports = New System.Windows.Forms.Label()
        Me.ファイアウォールの設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Location = New System.Drawing.Point(12, 54)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 57)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "▶START"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(236, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "状態："
        '
        'label_status
        '
        Me.label_status.AutoSize = True
        Me.label_status.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.label_status.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.label_status.Location = New System.Drawing.Point(286, 39)
        Me.label_status.Name = "label_status"
        Me.label_status.Size = New System.Drawing.Size(81, 19)
        Me.label_status.TabIndex = 2
        Me.label_status.Text = "Inactive"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(244, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "PID："
        '
        'label_pid
        '
        Me.label_pid.AutoSize = True
        Me.label_pid.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.label_pid.Location = New System.Drawing.Point(286, 108)
        Me.label_pid.Name = "label_pid"
        Me.label_pid.Size = New System.Drawing.Size(57, 38)
        Me.label_pid.TabIndex = 4
        Me.label_pid.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "XXXX"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(227, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Listen："
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルToolStripMenuItem, Me.操作ToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(387, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ファイルToolStripMenuItem
        '
        Me.ファイルToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.コマンドプロンプトToolStripMenuItem, Me.エクスプローラーで開くToolStripMenuItem, Me.ファイアウォールの設定ToolStripMenuItem, Me.NGINXダウンロードサイトToolStripMenuItem, Me.ウィンドウを閉じるToolStripMenuItem})
        Me.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem"
        Me.ファイルToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.ファイルToolStripMenuItem.Text = "ファイル"
        '
        'コマンドプロンプトToolStripMenuItem
        '
        Me.コマンドプロンプトToolStripMenuItem.Name = "コマンドプロンプトToolStripMenuItem"
        Me.コマンドプロンプトToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.コマンドプロンプトToolStripMenuItem.Text = "コマンドプロンプトを開く"
        '
        'エクスプローラーで開くToolStripMenuItem
        '
        Me.エクスプローラーで開くToolStripMenuItem.Name = "エクスプローラーで開くToolStripMenuItem"
        Me.エクスプローラーで開くToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.エクスプローラーで開くToolStripMenuItem.Text = "エクスプローラーで開く"
        '
        'NGINXダウンロードサイトToolStripMenuItem
        '
        Me.NGINXダウンロードサイトToolStripMenuItem.Name = "NGINXダウンロードサイトToolStripMenuItem"
        Me.NGINXダウンロードサイトToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.NGINXダウンロードサイトToolStripMenuItem.Text = "NGINXダウンロードサイトを開く"
        '
        'ウィンドウを閉じるToolStripMenuItem
        '
        Me.ウィンドウを閉じるToolStripMenuItem.Name = "ウィンドウを閉じるToolStripMenuItem"
        Me.ウィンドウを閉じるToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ウィンドウを閉じるToolStripMenuItem.Text = "ウィンドウを閉じる"
        '
        '操作ToolStripMenuItem
        '
        Me.操作ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.状態を再取得ToolStripMenuItem, Me.設定ファイルの確認nginxtToolStripMenuItem, Me.Nginxconfを開くToolStripMenuItem, Me.PIDから強制終了ToolStripMenuItem})
        Me.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem"
        Me.操作ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.操作ToolStripMenuItem.Text = "操作"
        '
        '状態を再取得ToolStripMenuItem
        '
        Me.状態を再取得ToolStripMenuItem.Name = "状態を再取得ToolStripMenuItem"
        Me.状態を再取得ToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.状態を再取得ToolStripMenuItem.Text = "状態を再取得"
        '
        '設定ファイルの確認nginxtToolStripMenuItem
        '
        Me.設定ファイルの確認nginxtToolStripMenuItem.Name = "設定ファイルの確認nginxtToolStripMenuItem"
        Me.設定ファイルの確認nginxtToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.設定ファイルの確認nginxtToolStripMenuItem.Text = "シンタックスチェック"
        '
        'Nginxconfを開くToolStripMenuItem
        '
        Me.Nginxconfを開くToolStripMenuItem.Name = "Nginxconfを開くToolStripMenuItem"
        Me.Nginxconfを開くToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.Nginxconfを開くToolStripMenuItem.Text = "nginx.confを開く"
        '
        'PIDから強制終了ToolStripMenuItem
        '
        Me.PIDから強制終了ToolStripMenuItem.Name = "PIDから強制終了ToolStripMenuItem"
        Me.PIDから強制終了ToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.PIDから強制終了ToolStripMenuItem.Text = "PIDから強制終了"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ソースコードGithubcomToolStripMenuItem})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ソースコードGithubcomToolStripMenuItem
        '
        Me.ソースコードGithubcomToolStripMenuItem.Name = "ソースコードGithubcomToolStripMenuItem"
        Me.ソースコードGithubcomToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.ソースコードGithubcomToolStripMenuItem.Text = "ソースコード(Github.com)"
        '
        'label_ports
        '
        Me.label_ports.AutoSize = True
        Me.label_ports.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.label_ports.Location = New System.Drawing.Point(285, 65)
        Me.label_ports.Name = "label_ports"
        Me.label_ports.Size = New System.Drawing.Size(57, 38)
        Me.label_ports.TabIndex = 7
        Me.label_ports.Text = "XXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "XXXX"
        '
        'ファイアウォールの設定ToolStripMenuItem
        '
        Me.ファイアウォールの設定ToolStripMenuItem.Name = "ファイアウォールの設定ToolStripMenuItem"
        Me.ファイアウォールの設定ToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ファイアウォールの設定ToolStripMenuItem.Text = "ファイアウォールの設定"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 154)
        Me.Controls.Add(Me.label_ports)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.label_pid)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.label_status)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "NGINX状態確認"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents label_status As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents label_pid As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ファイルToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 操作ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents コマンドプロンプトToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents エクスプローラーで開くToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ウィンドウを閉じるToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 設定ファイルの確認nginxtToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Nginxconfを開くToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PIDから強制終了ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 状態を再取得ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ソースコードGithubcomToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NGINXダウンロードサイトToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents label_ports As Label
    Friend WithEvents ファイアウォールの設定ToolStripMenuItem As ToolStripMenuItem
End Class
