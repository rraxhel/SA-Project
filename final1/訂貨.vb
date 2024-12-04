Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Public Class 訂貨
    Dim connection As New MySqlConnection("Server=ww5211.mysql.database.azure.com;UserID = ww5211;Password=Aa1104558!;Database=sa ;SslMode=Required;SslCa={path_to_CA_cert}")
    Dim dr As MySqlDataReader
    Dim ccon As New MySqlConnection("Server=localhost;UserID=root;Password=;database=sadb")
    Dim i As Integer
    Private printDocument As New PrintDocument()
    Private printPreviewDialog As PrintPreviewDialog
    Private dataGridViewPrint As DataGridView
    Private rowPrinted As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        stock_load()
        impoter_load()
        oder_load()

        pro_ID()
        pro_ID4()
        impoter_ID()

        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub stock_load()
        connection.Open()
        Dim cmd As New MySqlCommand("select * from 庫存 where 商品數量 < 30", connection)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr.Item("商品編號"), dr.Item("商品名稱"), dr.Item("商品數量"))
        End While
        dr.Close()
        connection.Close()
    End Sub
    Private Sub impoter_load()
        connection.Open()
        Dim cmd As New MySqlCommand("select * from 廠商", connection)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView2.Rows.Add(dr.Item("廠商編號"), dr.Item("廠商名稱"), dr.Item("廠商電話"))
        End While
        dr.Close()
        connection.Close()
    End Sub

    Private Sub oder_load()
        Try
            connection.Open()
            Dim cmd As New MySqlCommand("select 訂貨時間,訂單.廠商編號,廠商.廠商名稱,訂單.商品編號, 訂購數量, 商品.商品名稱 
                                    from 訂單, 商品, 廠商 where 訂單.商品編號 = 商品.商品編號 and 訂單.廠商編號 = 廠商.廠商編號 and DATE(訂貨時間) = @NowTime ", connection)
            'dr = cmd.ExecuteReader
            'While dr.Read
            'DataGridView3.Rows.Add(dr.Item("訂貨時間"), dr.Item("廠商編號"), dr.Item("廠商名稱"), dr.Item("商品編號"), dr.Item("訂購數量"), dr.Item("商品名稱"))
            'End While
            'dr.DisposeAsync()
            Dim now As String = Date.Now().ToString
            cmd.Parameters.AddWithValue("@NowTime", DateTime.Now.ToString("yyyy-MM-dd"))
            'MsgBox(now)
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(cmd)

            table.Clear()
            adapter.Fill(table) 'table name
            'MessageBox.Show(table.Rows.Count.ToString())
            DataGridView3.DataSource = table
            AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
            DataGridView3.AutoResizeColumns()
            DataGridView3.AutoResizeRows()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'dr.Close()
            connection.Close()
        End Try
    End Sub



    '加入訂貨單
    Private Sub save()
        Try
            connection.Open()
            Dim cmd As New MySqlCommand("INSERT INTO `訂單`(`廠商編號`, `商品編號`, `訂購數量`, `訂貨時間`) VALUES (@廠商編號,@商品編號,@訂購數量,@訂貨時間)", connection)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@廠商編號", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@商品編號", ComboBox2.Text)
            cmd.Parameters.AddWithValue("@訂購數量", TextBox2.Text)
            cmd.Parameters.AddWithValue("@訂貨時間", CDate(DateTimePicker2.Value))

            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MessageBox.Show("Success", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            connection.Close()
        End Try
        TextBox2.Clear()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        save()
        oder_load()
    End Sub

    'combobox
    Private Sub pro_ID()
        Dim adpt As New MySqlDataAdapter("SELECT 商品編號 FROM 庫存 WHERE 商品數量 < 30", connection)
        Dim dataTable As New DataTable()
        adpt.Fill(dataTable)

        ComboBox2.DisplayMember = "商品編號"
        ComboBox2.ValueMember = "商品編號"
        ComboBox2.DataSource = dataTable
    End Sub
    Private Sub pro_ID4()
        Dim adpt As New MySqlDataAdapter("SELECT 商品編號 FROM 商品", connection)
        Dim dataTable As New DataTable()
        adpt.Fill(dataTable)

        ComboBox4.DisplayMember = "商品編號"
        ComboBox4.ValueMember = "商品編號"
        ComboBox4.DataSource = dataTable
    End Sub
    Private Sub impoter_ID()
        Dim adp As New MySqlDataAdapter("select 廠商編號 from 廠商", connection)
        Dim dt As New DataTable()
        adp.Fill(dt)

        ComboBox1.DisplayMember = "廠商編號"
        ComboBox1.ValueMember = "廠商編號"
        ComboBox1.DataSource = dt
        ComboBox3.DisplayMember = "廠商編號"
        ComboBox3.ValueMember = "廠商編號"
        ComboBox3.DataSource = dt
    End Sub

    '查詢訂貨單
    Public Sub search(valueToSearch As String, selectDate As String)
        'SELECT * From Users WHERE CONCAT(fname, lname, age) like '%F%'
        Dim searchQuery As String = "SELECT 訂貨時間, 訂單.廠商編號, 廠商名稱, 訂單.商品編號, 訂購數量, 商品名稱 
                                     FROM 訂單, 商品, 廠商 
                                    WHERE 訂單.商品編號 = 商品.商品編號 
                                     AND 訂單.廠商編號 = 廠商.廠商編號 
                                    AND 訂單.廠商編號 LIKE '%" & valueToSearch & "%' 
                                    AND 訂貨時間 LIKE '%" & selectDate & "%'"


        Dim command As New MySqlCommand(searchQuery, connection)
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView3.DataSource = table
        AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        search(ComboBox3.Text, DateTimePicker1.Value.ToString("yyyy-MM-dd"))
        'search(ComboBox4.Text, DateTimePicker1.Value.ToString("yyyy-MM-dd"))
    End Sub

    '刪除訂貨單
    Private Sub delete()
        If MsgBox("Delete ?", MsgBoxStyle.Question + vbYesNo) = vbYes Then
            Try
                connection.Open()
                Dim cmd As New MySqlCommand("delete from `訂單` where `廠商編號` = @廠商編號 and 訂貨時間=@訂貨時間 and 商品編號=@商品編號", connection)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@廠商編號", ComboBox3.Text)
                cmd.Parameters.AddWithValue("@商品編號", ComboBox4.Text)
                cmd.Parameters.AddWithValue("@訂貨時間", CDate(DateTimePicker1.Value))

                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Success", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                connection.Close()
            End Try

        Else
            Return
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        delete()
        oder_load()
    End Sub

    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        ComboBox3.Text = DataGridView3.CurrentRow.Cells(1).Value
        ComboBox4.Text = DataGridView3.CurrentRow.Cells(3).Value
        DateTimePicker1.Value = DataGridView3.CurrentRow.Cells(0).Value
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
        ' 取得要列印的 DataGridView

        dataGridViewPrint = DataGridView3
        ' 計算列印的起始位置及列印範圍
        Dim printArea As RectangleF = e.MarginBounds
        Dim startX As Integer = printArea.Left
        Dim startY As Integer = printArea.Top  ' 調整此數值以改變表頭的垂直位置
        Dim printWidth As Integer = 0
        Dim printHeight As Integer = CInt(printArea.Height)
        Dim morePages As Boolean = False
        ' 計算列印寬度
        For Each column As DataGridViewColumn In dataGridViewPrint.Columns
            printWidth += CInt(column.Width * 1)
        Next

        ' 檢查是否需要分頁列印
        Try
            If printHeight < dataGridViewPrint.Rows(rowPrinted).Height * 1 Then
                morePages = True
            End If
        Catch ex As Exception
            'MessageBox.Show("沒有資料")
        End Try

        ' 列印資料
        Using gridBrush As New SolidBrush(dataGridViewPrint.GridColor), backColorBrush As New SolidBrush(dataGridViewPrint.BackgroundColor), font As New Font(dataGridViewPrint.Font, FontStyle.Regular)
            Using headerBrush As New SolidBrush(dataGridViewPrint.ColumnHeadersDefaultCellStyle.BackColor), headerFont As New Font(dataGridViewPrint.Font, FontStyle.Bold)
                ' 列印表頭
                Dim headerLeft As Integer = startX
                Dim headerTop As Integer = startY - 50 ' 調整此數值以改變表頭的垂直位置
                Dim headerWidth As Integer = printWidth
                Dim headerHeight As Integer = dataGridViewPrint.ColumnHeadersHeight

                e.Graphics.DrawRectangle(Pens.Black, headerLeft, headerTop, headerWidth, headerHeight)

                ' 填充表頭背景色
                e.Graphics.FillRectangle(headerBrush, headerLeft, headerTop, headerWidth, headerHeight)

                ' 繪製表頭文字
                headerLeft += 5
                For Each column As DataGridViewColumn In dataGridViewPrint.Columns
                    Dim columnWidth As Integer = CInt(column.Width * 1)

                    Dim format As New StringFormat()
                    format.Alignment = StringAlignment.Center
                    format.LineAlignment = StringAlignment.Center
                    e.Graphics.DrawString(column.HeaderText, headerFont, Brushes.Black, New RectangleF(headerLeft, headerTop, columnWidth, headerHeight), format)

                    ' 更新表頭位置
                    headerLeft += columnWidth
                Next

                ' 繪製分隔線
                headerLeft = startX
                For Each column As DataGridViewColumn In dataGridViewPrint.Columns
                    Dim columnWidth As Integer = CInt(column.Width * 1)

                    ' 繪製分隔線
                    e.Graphics.DrawLine(Pens.Black, headerLeft + columnWidth, headerTop, headerLeft + columnWidth, headerTop + headerHeight)

                    ' 更新表頭位置
                    headerLeft += columnWidth
                Next

                ' 列印資料列
                Dim left As Integer = startX
                Dim top As Integer = headerTop + dataGridViewPrint.ColumnHeadersHeight - 60
                Dim fixedCellHeight As Integer = 60 ' 設定欄位的固定高度
                While rowPrinted < dataGridViewPrint.Rows.Count
                    Dim row As DataGridViewRow = dataGridViewPrint.Rows(rowPrinted)

                    ' 判斷是否有資料
                    Dim hasData As Boolean = False
                    For Each cell As DataGridViewCell In row.Cells
                        If Not cell.Value Is Nothing AndAlso Not String.IsNullOrWhiteSpace(cell.Value.ToString()) Then
                            hasData = True
                            Exit For
                        End If
                    Next

                    If hasData Then
                        If top + fixedCellHeight > e.MarginBounds.Height + e.MarginBounds.Top Then
                            morePages = True
                            Exit While
                        Else
                            top += fixedCellHeight
                            left = startX

                            ' 列印資料格
                            For Each column As DataGridViewColumn In dataGridViewPrint.Columns
                                Dim cellWidth As Integer = CInt(column.Width * 1)
                                Dim cellHeight As Integer = fixedCellHeight

                                e.Graphics.FillRectangle(backColorBrush, left, top, cellWidth, cellHeight)
                                e.Graphics.DrawRectangle(Pens.Black, left, top, cellWidth, cellHeight)

                                If Not row.Cells(column.Index).Value Is Nothing Then
                                    Dim cellValue As String = row.Cells(column.Index).Value.ToString()

                                    ' 換行
                                    Dim format As New StringFormat()
                                    format.Alignment = StringAlignment.Near
                                    format.LineAlignment = StringAlignment.Center
                                    format.Trimming = StringTrimming.Word

                                    ' 調整字體大小
                                    Dim fontSize As Single = 10 ' 設定較小的字體大小
                                    Dim cellFont As New Font(dataGridViewPrint.Font.FontFamily, fontSize, FontStyle.Regular)

                                    ' 繪製文字
                                    e.Graphics.DrawString(cellValue, cellFont, Brushes.Black, New RectangleF(left + 5, top + 5, cellWidth - 10, cellHeight - 10), format)
                                End If

                                left += cellWidth
                            Next
                        End If
                    End If

                    rowPrinted += 1
                End While
            End Using
        End Using

        ' 若還有更多頁要列印，設定 HasMorePages 為 True
        e.HasMorePages = morePages
    End Sub


    Private Sub PrintButton_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' 使用 PrintDocument 控制項列印 DataGridView
        Dim printDialog As New PrintDialog()
        printDialog.Document = printDocument

        ' 使用 PrintPreviewDialog 預覽列印結果
        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDocument
        printPreviewDialog.StartPosition = FormStartPosition.CenterScreen

        If printDialog.ShowDialog() = DialogResult.OK Then
            rowPrinted = 0 ' 重置列印的起始行索引
            printPreviewDialog.ShowDialog() ' 顯示列印預覽對話框
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        ' 取得目前選取的頁籤索引
        Dim selectedIndex As Integer = TabControl1.SelectedIndex

        ' 根據選取的頁籤執行相應的程式碼
        Select Case selectedIndex
            Case 0 ' 第一個頁籤
                Button5.Enabled = False
                Button5.Visible = False
            Case 1 ' 第二個頁籤
                Button5.Visible = False
                Button5.Enabled = False
            Case 2 ' 第三個頁籤
                Button5.Visible = True
                Button5.Enabled = True

        End Select
    End Sub


End Class