<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class 新增商品
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim butExit As System.Windows.Forms.Button
        Me.butUpdate = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.proName = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.price = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.proID = New System.Windows.Forms.RichTextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        butExit = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        butExit.Location = New System.Drawing.Point(1134, 0)
        butExit.Name = "butExit"
        butExit.Size = New System.Drawing.Size(68, 53)
        butExit.TabIndex = 41
        butExit.Text = "X"
        butExit.UseVisualStyleBackColor = False
        AddHandler butExit.Click, AddressOf Me.butExit_Click
        '
        'butUpdate
        '
        Me.butUpdate.BackColor = System.Drawing.Color.Transparent
        Me.butUpdate.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.產品but
        Me.butUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.butUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.butUpdate.FlatAppearance.BorderSize = 0
        Me.butUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.butUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.butUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butUpdate.Location = New System.Drawing.Point(166, 431)
        Me.butUpdate.Name = "butUpdate"
        Me.butUpdate.Size = New System.Drawing.Size(297, 60)
        Me.butUpdate.TabIndex = 39
        Me.butUpdate.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(100, 218)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 40)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "商品名稱"
        '
        'proName
        '
        Me.proName.Font = New System.Drawing.Font("微軟正黑體", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.proName.Location = New System.Drawing.Point(106, 251)
        Me.proName.Multiline = False
        Me.proName.Name = "proName"
        Me.proName.Size = New System.Drawing.Size(420, 57)
        Me.proName.TabIndex = 31
        Me.proName.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(100, 318)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 40)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "商品售價"
        '
        'price
        '
        Me.price.Font = New System.Drawing.Font("微軟正黑體", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.price.Location = New System.Drawing.Point(106, 351)
        Me.price.Multiline = False
        Me.price.Name = "price"
        Me.price.Size = New System.Drawing.Size(420, 57)
        Me.price.TabIndex = 33
        Me.price.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(100, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 40)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "商品編號"
        '
        'proID
        '
        Me.proID.Font = New System.Drawing.Font("微軟正黑體", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.proID.Location = New System.Drawing.Point(106, 149)
        Me.proID.Multiline = False
        Me.proID.Name = "proID"
        Me.proID.Size = New System.Drawing.Size(420, 57)
        Me.proID.TabIndex = 30
        Me.proID.Text = ""
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(587, 126)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 31
        Me.DataGridView1.Size = New System.Drawing.Size(562, 355)
        Me.DataGridView1.TabIndex = 42
        '
        '新增商品
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.新增商品_01
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1200, 675)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(butExit)
        Me.Controls.Add(Me.butUpdate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.proName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.price)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.proID)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "新增商品"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "存貨新增修改"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butUpdate As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents proName As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents price As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents proID As RichTextBox
    Friend WithEvents DataGridView1 As DataGridView
End Class
