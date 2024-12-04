
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient

Public Class 進貨查詢
    Private printDocument As New PrintDocument()
    Private printPreviewDialog As PrintPreviewDialog
    Private dataGridViewPrint As DataGridView
    Private rowPrinted As Integer = 0
    Private Sub 進貨查詢_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim con As New connection
        Dim cmd As New MySqlCommand("SELECT  商品編號,商品名稱 FROM 商品  ", con.getConnection())

        Dim adapter As New MySqlDataAdapter(cmd)
        Dim table As New DataTable()


        table.Clear()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "商品編號"
        ComboBox1.ValueMember = "商品名稱"


        Dim cmd2 As New MySqlCommand("SELECT  廠商編號,廠商名稱 FROM 廠商  ", con.getConnection())
        Dim adapter2 As New MySqlDataAdapter(cmd2)
        Dim table2 As New DataTable()
        adapter2.Fill(table2)
        ComboBox2.DataSource = table2
        ComboBox2.DisplayMember = "廠商編號"
        ComboBox2.ValueMember = "廠商名稱"


        Dim table3 As New DataTable()
        Dim cmd3 As New MySqlCommand("Select * From 進貨 ", con.getConnection())
        Dim adapter3 As New MySqlDataAdapter(cmd3)
        table3.Clear()
        adapter3.Fill(table3) 'table name
        DataGridView1.DataSource = table3
        DataGridView1.RowHeadersWidth = 30
        DataGridView1.AutoResizeColumns()
        DataGridView1.AutoResizeRows()
        AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '日
        If (RadioButton2.Checked = True) Then
            Dim con As New connection
            Dim table As New DataTable()
            Dim cmd As New MySqlCommand("Select 進貨.商品編號,商品名稱, 進貨.廠商編號, 進貨日期, 進貨金額, 商品到期日,商品進貨數量 From 進貨 INNER JOIN 商品 ON 進貨.商品編號=商品.商品編號 where 進貨日期=@choosedate", con.getConnection())
            cmd.Parameters.Add("choosedate", MySqlDbType.VarChar).Value = DateTimePicker1.Value
            Dim adapter As New MySqlDataAdapter(cmd)

            table.Clear()
            adapter.Fill(table) 'table name 
            DataGridView1.DataSource = table
            'DataGridView1.RowHeadersWidth = 30
            'DataGridView1.Columns(0).Width = 80
            'DataGridView1.Columns(1).Width = 80
            'DataGridView1.Columns(2).Width = 80
            'DataGridView1.Columns(3).Width = 80
            DataGridView1.AutoResizeColumns()
            DataGridView1.AutoResizeRows()
            AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
        End If

        '月
        If (RadioButton1.Checked = True) Then
            Dim con As New connection
            Dim table As New DataTable()

            Dim cmd2 As New MySqlCommand("Select 進貨.商品編號,商品名稱, 進貨.廠商編號, 進貨日期, 進貨金額, 商品到期日,商品進貨數量 From 進貨 INNER JOIN 商品 ON 進貨.商品編號=商品.商品編號 where Year(進貨日期) = Year(@chooseyear) And Month(進貨日期)=Month(@choosemonth)", con.getConnection())
            cmd2.Parameters.Add("@choosemonth", MySqlDbType.VarChar).Value = DateTimePicker2.Value
            cmd2.Parameters.Add("@chooseyear", MySqlDbType.VarChar).Value = DateTimePicker2.Value
            Dim adapter2 As New MySqlDataAdapter(cmd2)
            table.Clear()
            adapter2.Fill(table) 'table name
            DataGridView1.DataSource = table
            DataGridView1.RowHeadersWidth = 30
            DataGridView1.AutoResizeColumns()
            DataGridView1.AutoResizeRows()
            AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
        End If
        '商品
        If (RadioButton4.Checked = True And Label1.Text <> "") Then
            Dim con As New connection
            Dim table As New DataTable()
            Dim cmd3 As New MySqlCommand("Select 進貨.商品編號,商品名稱, 進貨.廠商編號, 進貨日期, 進貨金額, 商品到期日,商品進貨數量 From 進貨 INNER JOIN 商品 ON 進貨.商品編號=商品.商品編號 WHERE 進貨.商品編號=@MNO", con.getConnection())
            cmd3.Parameters.AddWithValue("@MNO", ComboBox1.Text)
            Dim adapter3 As New MySqlDataAdapter(cmd3)
            table.Clear()
            adapter3.Fill(table) 'table name
            DataGridView1.DataSource = table
            DataGridView1.RowHeadersWidth = 30
            DataGridView1.AutoResizeColumns()
            DataGridView1.AutoResizeRows()
            AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
        End If
        '廠商
        If (RadioButton3.Checked = True And Label2.Text <> "") Then
            Dim con As New connection
            Dim table As New DataTable()
            Dim cmd4 As New MySqlCommand("Select 進貨.廠商編號,進貨.商品編號,商品名稱, 進貨日期, 進貨金額, 商品到期日,商品進貨數量 From 進貨 INNER JOIN 商品 ON 進貨.商品編號=商品.商品編號 WHERE 進貨.廠商編號=@BUYERNO", con.getConnection())
            cmd4.Parameters.AddWithValue("@BUYERNO", ComboBox2.Text)
            Dim adapter4 As New MySqlDataAdapter(cmd4)
            table.Clear()
            adapter4.Fill(table) 'table name
            DataGridView1.DataSource = table
            DataGridView1.RowHeadersWidth = 30
            DataGridView1.AutoResizeColumns()
            DataGridView1.AutoResizeRows()
            AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
        End If
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Label1.Text = ComboBox1.GetItemText(ComboBox1.SelectedValue)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Label2.Text = ComboBox2.GetItemText(ComboBox2.SelectedValue)
    End Sub



    Private Sub RadioButton3_click(sender As Object, e As EventArgs) Handles RadioButton3.Click
        ComboBox2.Enabled = True
        RadioButton4.Checked = False
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        ComboBox1.Enabled = False
        Label1.ForeColor = Color.Gray
        Label2.ForeColor = Color.Black
        Label2.Text = " "
        ComboBox2.Text = "選擇廠商編號"


    End Sub

    Private Sub RadioButton4_Click(sender As Object, e As EventArgs) Handles RadioButton4.Click
        ComboBox1.Enabled = True
        RadioButton3.Checked = False
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        ComboBox2.Enabled = False
        Label2.ForeColor = Color.Gray
        Label1.ForeColor = Color.Black


        Label1.Text = " "
        ComboBox1.Text = "選擇商品編號"
    End Sub
    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        DateTimePicker2.Enabled = True
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton2.Checked = False
        DateTimePicker1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox1.Enabled = False
        Label2.ForeColor = Color.Gray
        Label1.ForeColor = Color.Gray
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        DateTimePicker1.Enabled = True
        RadioButton3.Checked = False
        RadioButton1.Checked = False
        RadioButton4.Checked = False
        DateTimePicker2.Enabled = False
        ComboBox2.Enabled = False
        ComboBox1.Enabled = False
        Label2.ForeColor = Color.Gray
        Label1.ForeColor = Color.Gray
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim primaryKey1 As String = selectedRow.Cells("商品編號").Value.ToString()
            Dim primaryKey2 As String = selectedRow.Cells("進貨日期").Value()

            Dim deleteSql As String = "DELETE FROM 進貨 WHERE 商品編號 = @primaryKey1 AND 進貨日期 = @primaryKey2"
            Dim result As DialogResult = MessageBox.Show("是否刪除該筆紀錄？", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                Dim con As New connection
                con.Openconnection()

                Using cmd As New MySqlCommand(deleteSql, con.getConnection())
                    cmd.Parameters.AddWithValue("@primaryKey1", primaryKey1)
                    cmd.Parameters.AddWithValue("@primaryKey2", primaryKey2)


                    cmd.ExecuteNonQuery()
                End Using

                con.Closeconnection()
                DataGridView1.Rows.Remove(selectedRow)
            End If
        End If
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
        ' 取得要列印的 DataGridView
        dataGridViewPrint = DataGridView1

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
            '' MessageBox.Show("沒有資料")
        End Try
        ' 列印資料
        Using gridBrush As New SolidBrush(dataGridViewPrint.GridColor), backColorBrush As New SolidBrush(dataGridViewPrint.BackgroundColor), font As New Font(dataGridViewPrint.Font, FontStyle.Regular)
            Using headerBrush As New SolidBrush(dataGridViewPrint.ColumnHeadersDefaultCellStyle.BackColor), headerFont As New Font(dataGridViewPrint.Font, FontStyle.Bold)
                ' 列印表頭
                Dim headerLeft As Integer = startX
                Dim headerTop As Integer = startY - 50 ' 調整此數值以改變表頭的垂直位置
                Dim headerWidth As Integer = printWidth
                Dim headerHeight As Integer = dataGridViewPrint.ColumnHeadersHeight

                ' 繪製表頭外框
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


    Private Sub PrintButton_Click(sender As Object, e As EventArgs) Handles Button3.Click
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
    Private Sub butExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class