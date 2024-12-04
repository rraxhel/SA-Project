<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 存貨修改
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
        Me.grv = New System.Windows.Forms.DataGridView()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.butUpdate = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.proName = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.number = New System.Windows.Forms.RichTextBox()
        butExit = New System.Windows.Forms.Button()
        CType(Me.grv, System.ComponentModel.ISupportInitialize).BeginInit()
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
        butExit.Location = New System.Drawing.Point(1130, -3)
        butExit.Name = "butExit"
        butExit.Size = New System.Drawing.Size(75, 56)
        butExit.TabIndex = 11
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
        Me.Label2.Location = New System.Drawing.Point(223, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 40)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "商品編號"
        '
        'grv
        '
        Me.grv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grv.Location = New System.Drawing.Point(689, 118)
        Me.grv.Name = "grv"
        Me.grv.RowHeadersWidth = 62
        Me.grv.RowTemplate.Height = 31
        Me.grv.Size = New System.Drawing.Size(490, 528)
        Me.grv.TabIndex = 38
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("微軟正黑體", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(230, 142)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(420, 63)
        Me.ComboBox1.TabIndex = 37
        '
        'butUpdate
        '
        Me.butUpdate.BackColor = System.Drawing.Color.Transparent
        Me.butUpdate.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.庫存修改but
        Me.butUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.butUpdate.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.butUpdate.FlatAppearance.BorderSize = 0
        Me.butUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.butUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.butUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butUpdate.Location = New System.Drawing.Point(381, 487)
        Me.butUpdate.Name = "butUpdate"
        Me.butUpdate.Size = New System.Drawing.Size(268, 60)
        Me.butUpdate.TabIndex = 36
        Me.butUpdate.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(223, 227)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 40)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "商品名稱"
        '
        'proName
        '
        Me.proName.Font = New System.Drawing.Font("微軟正黑體", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.proName.Location = New System.Drawing.Point(229, 260)
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
        Me.Label1.Location = New System.Drawing.Point(223, 354)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 40)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "商品數量"
        '
        'number
        '
        Me.number.Font = New System.Drawing.Font("微軟正黑體", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.number.Location = New System.Drawing.Point(229, 387)
        Me.number.Multiline = False
        Me.number.Name = "number"
        Me.number.Size = New System.Drawing.Size(420, 57)
        Me.number.TabIndex = 33
        Me.number.Text = ""
        '
        '存貨修改
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.庫存修改資產_24
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1200, 675)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grv)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.butUpdate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.proName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.number)
        Me.Controls.Add(butExit)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "存貨修改"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "存貨修改"
        CType(Me.grv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents grv As DataGridView
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents butUpdate As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents proName As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents number As RichTextBox
End Class
