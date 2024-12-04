<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 存貨查詢
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
        Dim butExit As System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label()
        Me.butSsearch = New System.Windows.Forms.Button()
        Me.grvStock = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.proCode = New System.Windows.Forms.ComboBox()
        butExit = New System.Windows.Forms.Button()
        CType(Me.grvStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butExit
        '
        butExit.BackColor = System.Drawing.Color.Transparent
        butExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        butExit.FlatAppearance.BorderSize = 0
        butExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        butExit.Font = New System.Drawing.Font("微軟正黑體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        butExit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        butExit.Location = New System.Drawing.Point(1126, -3)
        butExit.Name = "butExit"
        butExit.Size = New System.Drawing.Size(75, 56)
        butExit.TabIndex = 10
        butExit.Text = "X"
        butExit.UseVisualStyleBackColor = False
        AddHandler butExit.Click, AddressOf Me.ButExit_Click
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(832, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 40)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "商品編號"
        '
        'butSsearch
        '
        Me.butSsearch.BackColor = System.Drawing.Color.Transparent
        Me.butSsearch.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.存but
        Me.butSsearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.butSsearch.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.butSsearch.FlatAppearance.BorderSize = 0
        Me.butSsearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.butSsearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.butSsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butSsearch.Location = New System.Drawing.Point(839, 305)
        Me.butSsearch.Name = "butSsearch"
        Me.butSsearch.Size = New System.Drawing.Size(315, 60)
        Me.butSsearch.TabIndex = 13
        Me.butSsearch.UseVisualStyleBackColor = False
        '
        'grvStock
        '
        Me.grvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grvStock.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grvStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grvStock.Location = New System.Drawing.Point(18, 121)
        Me.grvStock.Name = "grvStock"
        Me.grvStock.RowHeadersWidth = 62
        Me.grvStock.RowTemplate.Height = 31
        Me.grvStock.Size = New System.Drawing.Size(764, 547)
        Me.grvStock.TabIndex = 11
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button3.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.printer
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.Location = New System.Drawing.Point(1124, 121)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(64, 54)
        Me.Button3.TabIndex = 23
        Me.Button3.UseVisualStyleBackColor = False
        '
        'proCode
        '
        Me.proCode.Font = New System.Drawing.Font("微軟正黑體", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.proCode.FormattingEnabled = True
        Me.proCode.Location = New System.Drawing.Point(839, 198)
        Me.proCode.Name = "proCode"
        Me.proCode.Size = New System.Drawing.Size(315, 63)
        Me.proCode.TabIndex = 38
        '
        '存貨查詢
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.存貨2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1200, 675)
        Me.Controls.Add(Me.proCode)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.butSsearch)
        Me.Controls.Add(Me.grvStock)
        Me.Controls.Add(butExit)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "存貨查詢"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "存貨查詢"
        CType(Me.grvStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents butSsearch As Button
    Friend WithEvents grvStock As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents proCode As ComboBox
End Class
