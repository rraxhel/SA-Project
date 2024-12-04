<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 主選單
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim butExit As System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.財務管理系統ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.存貨系統ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.查詢存貨資料ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.新增和修改存貨資料ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.進貨系統ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.新增進貨功能ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.查詢及刪除進貨資料ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.訂貨系統ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保鮮管理系統ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.銷貨系統ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.新稱商品ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.訂單管理ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.訂單新增功能ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.訂單查詢功能ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.訂單修改功能ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        butExit = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butExit
        '
        butExit.BackColor = System.Drawing.SystemColors.ButtonFace
        butExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        butExit.FlatAppearance.BorderSize = 0
        butExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        butExit.Font = New System.Drawing.Font("微軟正黑體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        butExit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        butExit.Location = New System.Drawing.Point(1142, 0)
        butExit.Name = "butExit"
        butExit.Size = New System.Drawing.Size(58, 61)
        butExit.TabIndex = 22
        butExit.Text = "X"
        butExit.UseVisualStyleBackColor = False
        AddHandler butExit.Click, AddressOf Me.butExit_Click
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.財務管理系統ToolStripMenuItem, Me.存貨系統ToolStripMenuItem, Me.進貨系統ToolStripMenuItem, Me.保鮮管理系統ToolStripMenuItem, Me.訂貨系統ToolStripMenuItem, Me.銷貨系統ToolStripMenuItem, Me.訂單管理ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1200, 61)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '財務管理系統ToolStripMenuItem
        '
        Me.財務管理系統ToolStripMenuItem.Font = New System.Drawing.Font("Microsoft JhengHei UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.財務管理系統ToolStripMenuItem.Name = "財務管理系統ToolStripMenuItem"
        Me.財務管理系統ToolStripMenuItem.Size = New System.Drawing.Size(278, 57)
        Me.財務管理系統ToolStripMenuItem.Text = "財務管理系統"
        '
        '存貨系統ToolStripMenuItem
        '
        Me.存貨系統ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.查詢存貨資料ToolStripMenuItem, Me.新增和修改存貨資料ToolStripMenuItem})
        Me.存貨系統ToolStripMenuItem.Font = New System.Drawing.Font("Microsoft JhengHei UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.存貨系統ToolStripMenuItem.Name = "存貨系統ToolStripMenuItem"
        Me.存貨系統ToolStripMenuItem.Size = New System.Drawing.Size(278, 57)
        Me.存貨系統ToolStripMenuItem.Text = "存貨管理系統"
        '
        '查詢存貨資料ToolStripMenuItem
        '
        Me.查詢存貨資料ToolStripMenuItem.Name = "查詢存貨資料ToolStripMenuItem"
        Me.查詢存貨資料ToolStripMenuItem.Size = New System.Drawing.Size(374, 58)
        Me.查詢存貨資料ToolStripMenuItem.Text = "查詢存貨資料"
        '
        '新增和修改存貨資料ToolStripMenuItem
        '
        Me.新增和修改存貨資料ToolStripMenuItem.Name = "新增和修改存貨資料ToolStripMenuItem"
        Me.新增和修改存貨資料ToolStripMenuItem.Size = New System.Drawing.Size(374, 58)
        Me.新增和修改存貨資料ToolStripMenuItem.Text = "修改存貨資料"
        '
        '進貨系統ToolStripMenuItem
        '
        Me.進貨系統ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.新增進貨功能ToolStripMenuItem, Me.查詢及刪除進貨資料ToolStripMenuItem})
        Me.進貨系統ToolStripMenuItem.Font = New System.Drawing.Font("Microsoft JhengHei UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.進貨系統ToolStripMenuItem.Name = "進貨系統ToolStripMenuItem"
        Me.進貨系統ToolStripMenuItem.Size = New System.Drawing.Size(198, 57)
        Me.進貨系統ToolStripMenuItem.Text = "進貨系統"
        '
        '新增進貨功能ToolStripMenuItem
        '
        Me.新增進貨功能ToolStripMenuItem.Name = "新增進貨功能ToolStripMenuItem"
        Me.新增進貨功能ToolStripMenuItem.Size = New System.Drawing.Size(494, 58)
        Me.新增進貨功能ToolStripMenuItem.Text = "新增進貨資料"
        '
        '查詢及刪除進貨資料ToolStripMenuItem
        '
        Me.查詢及刪除進貨資料ToolStripMenuItem.Name = "查詢及刪除進貨資料ToolStripMenuItem"
        Me.查詢及刪除進貨資料ToolStripMenuItem.Size = New System.Drawing.Size(494, 58)
        Me.查詢及刪除進貨資料ToolStripMenuItem.Text = "查詢及刪除進貨資料"
        '
        '訂貨系統ToolStripMenuItem
        '
        Me.訂貨系統ToolStripMenuItem.Font = New System.Drawing.Font("Microsoft JhengHei UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.訂貨系統ToolStripMenuItem.Name = "訂貨系統ToolStripMenuItem"
        Me.訂貨系統ToolStripMenuItem.Size = New System.Drawing.Size(198, 57)
        Me.訂貨系統ToolStripMenuItem.Text = "訂貨系統"
        '
        '保鮮管理系統ToolStripMenuItem
        '
        Me.保鮮管理系統ToolStripMenuItem.Font = New System.Drawing.Font("Microsoft JhengHei UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.保鮮管理系統ToolStripMenuItem.Name = "保鮮管理系統ToolStripMenuItem"
        Me.保鮮管理系統ToolStripMenuItem.Size = New System.Drawing.Size(278, 57)
        Me.保鮮管理系統ToolStripMenuItem.Text = "保鮮管理系統"
        '
        '銷貨系統ToolStripMenuItem
        '
        Me.銷貨系統ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.新稱商品ToolStripMenuItem})
        Me.銷貨系統ToolStripMenuItem.Font = New System.Drawing.Font("Microsoft JhengHei UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.銷貨系統ToolStripMenuItem.Name = "銷貨系統ToolStripMenuItem"
        Me.銷貨系統ToolStripMenuItem.Size = New System.Drawing.Size(198, 57)
        Me.銷貨系統ToolStripMenuItem.Text = "銷貨系統"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(374, 58)
        Me.ToolStripMenuItem1.Text = "查詢銷貨資料"
        '
        '新稱商品ToolStripMenuItem
        '
        Me.新稱商品ToolStripMenuItem.Name = "新稱商品ToolStripMenuItem"
        Me.新稱商品ToolStripMenuItem.Size = New System.Drawing.Size(374, 58)
        Me.新稱商品ToolStripMenuItem.Text = "新增商品"
        '
        '訂單管理ToolStripMenuItem
        '
        Me.訂單管理ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.訂單新增功能ToolStripMenuItem, Me.訂單查詢功能ToolStripMenuItem, Me.訂單修改功能ToolStripMenuItem})
        Me.訂單管理ToolStripMenuItem.Font = New System.Drawing.Font("Microsoft JhengHei UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.訂單管理ToolStripMenuItem.Name = "訂單管理ToolStripMenuItem"
        Me.訂單管理ToolStripMenuItem.Size = New System.Drawing.Size(198, 57)
        Me.訂單管理ToolStripMenuItem.Text = "訂單管理"
        '
        '訂單新增功能ToolStripMenuItem
        '
        Me.訂單新增功能ToolStripMenuItem.Name = "訂單新增功能ToolStripMenuItem"
        Me.訂單新增功能ToolStripMenuItem.Size = New System.Drawing.Size(374, 58)
        Me.訂單新增功能ToolStripMenuItem.Text = "訂單新增功能"
        '
        '訂單查詢功能ToolStripMenuItem
        '
        Me.訂單查詢功能ToolStripMenuItem.Name = "訂單查詢功能ToolStripMenuItem"
        Me.訂單查詢功能ToolStripMenuItem.Size = New System.Drawing.Size(374, 58)
        Me.訂單查詢功能ToolStripMenuItem.Text = "訂單查詢功能"
        '
        '訂單修改功能ToolStripMenuItem
        '
        Me.訂單修改功能ToolStripMenuItem.Name = "訂單修改功能ToolStripMenuItem"
        Me.訂單修改功能ToolStripMenuItem.Size = New System.Drawing.Size(374, 58)
        Me.訂單修改功能ToolStripMenuItem.Text = "訂單修改功能"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1500
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.暗
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(573, 461)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(203, 215)
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        '主選單
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.sa_BACK_01
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1200, 675)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(butExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "主選單"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "主選單"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 財務管理系統ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 存貨系統ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 進貨系統ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 訂貨系統ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 保鮮管理系統ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 銷貨系統ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 訂單管理ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 訂單新增功能ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 訂單查詢功能ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 訂單修改功能ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 新增進貨功能ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 查詢及刪除進貨資料ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 查詢存貨資料ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 新增和修改存貨資料ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 新稱商品ToolStripMenuItem As ToolStripMenuItem
End Class
