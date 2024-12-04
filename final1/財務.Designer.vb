<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 財務
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
        Me.grvCard = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.radday = New System.Windows.Forms.RadioButton()
        Me.radmonth = New System.Windows.Forms.RadioButton()
        Me.radyear = New System.Windows.Forms.RadioButton()
        Me.DateT = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.textPay = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.textCard = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.textCash = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chhh = New System.Windows.Forms.TextBox()
        Me.outcome = New System.Windows.Forms.TextBox()
        Me.income = New System.Windows.Forms.TextBox()
        Me.grvOut = New System.Windows.Forms.DataGridView()
        Me.GroupBox = New System.Windows.Forms.GroupBox()
        Me.butPrint = New System.Windows.Forms.Button()
        Me.butprint2 = New System.Windows.Forms.Button()
        butExit = New System.Windows.Forms.Button()
        CType(Me.grvCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grvOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
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
        butExit.Location = New System.Drawing.Point(1125, 3)
        butExit.Name = "butExit"
        butExit.Size = New System.Drawing.Size(75, 56)
        butExit.TabIndex = 14
        butExit.Text = "X"
        butExit.UseVisualStyleBackColor = False
        AddHandler butExit.Click, AddressOf Me.ButExit_Click
        '
        'grvCard
        '
        Me.grvCard.AllowUserToAddRows = False
        Me.grvCard.AllowUserToDeleteRows = False
        Me.grvCard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grvCard.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grvCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grvCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grvCard.Location = New System.Drawing.Point(401, 314)
        Me.grvCard.Name = "grvCard"
        Me.grvCard.ReadOnly = True
        Me.grvCard.RowHeadersWidth = 62
        Me.grvCard.RowTemplate.Height = 31
        Me.grvCard.Size = New System.Drawing.Size(709, 378)
        Me.grvCard.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.upp2
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(butExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("微軟正黑體", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1189, 100)
        Me.Panel1.TabIndex = 15
        '
        'radday
        '
        Me.radday.AutoSize = True
        Me.radday.Location = New System.Drawing.Point(507, 23)
        Me.radday.Name = "radday"
        Me.radday.Size = New System.Drawing.Size(74, 44)
        Me.radday.TabIndex = 19
        Me.radday.TabStop = True
        Me.radday.Text = "日"
        Me.radday.UseVisualStyleBackColor = True
        '
        'radmonth
        '
        Me.radmonth.AutoSize = True
        Me.radmonth.Location = New System.Drawing.Point(403, 23)
        Me.radmonth.Name = "radmonth"
        Me.radmonth.Size = New System.Drawing.Size(74, 44)
        Me.radmonth.TabIndex = 18
        Me.radmonth.TabStop = True
        Me.radmonth.Text = "月"
        Me.radmonth.UseVisualStyleBackColor = True
        '
        'radyear
        '
        Me.radyear.AutoSize = True
        Me.radyear.Location = New System.Drawing.Point(299, 23)
        Me.radyear.Name = "radyear"
        Me.radyear.Size = New System.Drawing.Size(74, 44)
        Me.radyear.TabIndex = 17
        Me.radyear.TabStop = True
        Me.radyear.Text = "年"
        Me.radyear.UseVisualStyleBackColor = True
        '
        'DateT
        '
        Me.DateT.Location = New System.Drawing.Point(713, 21)
        Me.DateT.Name = "DateT"
        Me.DateT.Size = New System.Drawing.Size(326, 50)
        Me.DateT.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(706, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(209, 40)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "線上支付總額"
        '
        'textPay
        '
        Me.textPay.Location = New System.Drawing.Point(713, 160)
        Me.textPay.Name = "textPay"
        Me.textPay.ReadOnly = True
        Me.textPay.Size = New System.Drawing.Size(326, 50)
        Me.textPay.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(357, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(241, 40)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "信用卡收入總額"
        '
        'textCard
        '
        Me.textCard.Location = New System.Drawing.Point(364, 160)
        Me.textCard.Name = "textCard"
        Me.textCard.ReadOnly = True
        Me.textCard.Size = New System.Drawing.Size(326, 50)
        Me.textCard.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(241, 40)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "現金總收入總額"
        '
        'textCash
        '
        Me.textCash.Location = New System.Drawing.Point(12, 160)
        Me.textCash.Name = "textCash"
        Me.textCash.ReadOnly = True
        Me.textCash.Size = New System.Drawing.Size(326, 50)
        Me.textCash.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(706, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 40)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "盈虧"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(360, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 40)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "總支出"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 40)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "總收入"
        '
        'chhh
        '
        Me.chhh.Location = New System.Drawing.Point(713, 86)
        Me.chhh.Name = "chhh"
        Me.chhh.ReadOnly = True
        Me.chhh.Size = New System.Drawing.Size(323, 50)
        Me.chhh.TabIndex = 6
        '
        'outcome
        '
        Me.outcome.Location = New System.Drawing.Point(367, 86)
        Me.outcome.Name = "outcome"
        Me.outcome.ReadOnly = True
        Me.outcome.Size = New System.Drawing.Size(323, 50)
        Me.outcome.TabIndex = 5
        '
        'income
        '
        Me.income.Location = New System.Drawing.Point(12, 86)
        Me.income.Name = "income"
        Me.income.ReadOnly = True
        Me.income.Size = New System.Drawing.Size(326, 50)
        Me.income.TabIndex = 4
        '
        'grvOut
        '
        Me.grvOut.AllowUserToAddRows = False
        Me.grvOut.AllowUserToDeleteRows = False
        Me.grvOut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grvOut.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grvOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grvOut.Location = New System.Drawing.Point(50, 314)
        Me.grvOut.Name = "grvOut"
        Me.grvOut.ReadOnly = True
        Me.grvOut.RowHeadersWidth = 62
        Me.grvOut.RowTemplate.Height = 31
        Me.grvOut.Size = New System.Drawing.Size(353, 378)
        Me.grvOut.TabIndex = 12
        '
        'GroupBox
        '
        Me.GroupBox.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.box
        Me.GroupBox.Controls.Add(Me.radday)
        Me.GroupBox.Controls.Add(Me.radmonth)
        Me.GroupBox.Controls.Add(Me.radyear)
        Me.GroupBox.Controls.Add(Me.DateT)
        Me.GroupBox.Controls.Add(Me.Label6)
        Me.GroupBox.Controls.Add(Me.textPay)
        Me.GroupBox.Controls.Add(Me.Label5)
        Me.GroupBox.Controls.Add(Me.textCard)
        Me.GroupBox.Controls.Add(Me.Label4)
        Me.GroupBox.Controls.Add(Me.textCash)
        Me.GroupBox.Controls.Add(Me.Label3)
        Me.GroupBox.Controls.Add(Me.Label2)
        Me.GroupBox.Controls.Add(Me.Label1)
        Me.GroupBox.Controls.Add(Me.chhh)
        Me.GroupBox.Controls.Add(Me.outcome)
        Me.GroupBox.Controls.Add(Me.income)
        Me.GroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox.Font = New System.Drawing.Font("微軟正黑體", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox.Location = New System.Drawing.Point(51, 106)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(1059, 208)
        Me.GroupBox.TabIndex = 10
        Me.GroupBox.TabStop = False
        Me.GroupBox.Text = "結算報表"
        '
        'butPrint
        '
        Me.butPrint.BackColor = System.Drawing.Color.RosyBrown
        Me.butPrint.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.printer
        Me.butPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.butPrint.FlatAppearance.BorderSize = 0
        Me.butPrint.Location = New System.Drawing.Point(1125, 106)
        Me.butPrint.Name = "butPrint"
        Me.butPrint.Size = New System.Drawing.Size(64, 54)
        Me.butPrint.TabIndex = 16
        Me.butPrint.UseVisualStyleBackColor = False
        '
        'butprint2
        '
        Me.butprint2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.butprint2.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.printer
        Me.butprint2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.butprint2.FlatAppearance.BorderSize = 0
        Me.butprint2.Location = New System.Drawing.Point(1125, 177)
        Me.butprint2.Name = "butprint2"
        Me.butprint2.Size = New System.Drawing.Size(64, 54)
        Me.butprint2.TabIndex = 17
        Me.butprint2.UseVisualStyleBackColor = False
        '
        '財務
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.BackgroundImage = Global.銷貨訂單.My.Resources.Resources.yellow
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1200, 675)
        Me.Controls.Add(Me.butprint2)
        Me.Controls.Add(Me.butPrint)
        Me.Controls.Add(Me.grvCard)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grvOut)
        Me.Controls.Add(Me.GroupBox)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "財務"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "財務"
        CType(Me.grvCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grvOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grvCard As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents radday As RadioButton
    Friend WithEvents radmonth As RadioButton
    Friend WithEvents radyear As RadioButton
    Friend WithEvents DateT As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents textPay As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents textCard As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents textCash As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chhh As TextBox
    Friend WithEvents outcome As TextBox
    Friend WithEvents income As TextBox
    Friend WithEvents grvOut As DataGridView
    Friend WithEvents GroupBox As GroupBox
    Friend WithEvents butPrint As Button
    Friend WithEvents butprint2 As Button
End Class
