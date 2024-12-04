
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Public Class 保鮮

    Private printDocument As New PrintDocument()
    Private printPreviewDialog As PrintPreviewDialog
    Private dataGridViewPrint As DataGridView
    Private rowPrinted As Integer = 0
    Public updatestock As Boolean = False
    Private Sub Label7_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub

    Private Sub 保鮮_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBox1.Text = "選擇你要查詢之項目"
        Dim con As New connection
        Dim cmd As New MySqlCommand("Select 庫存.商品編號,商品名稱,商品到期日,商品進貨數量 From 進貨 INNER JOIN 庫存 ON 進貨.商品編號=庫存.商品編號", con.getConnection())
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter(cmd)
        adapter.Fill(table)
        DataGridView1.DataSource = table
        DataGridView1.AutoResizeColumns()
        DataGridView1.AutoResizeRows()
        DataGridView1.RowHeadersWidth = 30
        AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim selectedValue As String = ComboBox1.SelectedItem.ToString()

        '全部
        If (selectedValue = "全部保鮮資料") Then
            Dim con As New connection
            Dim cmd As New MySqlCommand("Select 庫存.商品編號,商品名稱,商品到期日,商品進貨數量 From 進貨 INNER JOIN 庫存 ON 進貨.商品編號=庫存.商品編號", con.getConnection())
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(cmd)
            adapter.Fill(table)
            DataGridView1.DataSource = table
            DataGridView1.AutoResizeColumns()
            DataGridView1.AutoResizeRows()
            DataGridView1.RowHeadersWidth = 30
            AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
        End If

        '即期
        If (selectedValue = "即期商品") Then
            Dim currentDate As DateTime = DateTime.Now
            Dim enddate As DateTime = currentDate.AddDays(60)
            Dim con As New connection
            Dim cmd As New MySqlCommand("Select 庫存.商品編號,商品到期日,商品名稱,商品進貨數量 From 進貨 INNER JOIN 庫存 ON 進貨.商品編號=庫存.商品編號 WHERE  商品到期日 <= @EndDate AND 商品到期日 >= @Now", con.getConnection())
            cmd.Parameters.AddWithValue("@EndDate", enddate)
            cmd.Parameters.AddWithValue("@Now", currentDate)
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(cmd)
            adapter.Fill(table)
            DataGridView1.DataSource = table
            DataGridView1.AutoResizeColumns()
            DataGridView1.AutoResizeRows()
            DataGridView1.RowHeadersWidth = 30
            AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
        End If

        '過期
        If (selectedValue = "過期商品") Then
            Dim currentDate As DateTime = DateTime.Now
            Dim enddate As DateTime = currentDate.AddDays(-1)
            Dim con As New connection
            Dim cmd As New MySqlCommand("Select 庫存.商品編號,商品到期日,商品名稱,商品進貨數量 From 進貨 INNER JOIN 庫存 ON 進貨.商品編號=庫存.商品編號 WHERE 商品到期日 < @Now", con.getConnection())
            cmd.Parameters.AddWithValue("@Now", enddate)
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(cmd)
            adapter.Fill(table)
            DataGridView1.DataSource = table
            DataGridView1.AutoResizeColumns()
            DataGridView1.AutoResizeRows()
            DataGridView1.RowHeadersWidth = 30
            AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage



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


                ' 填充表頭背景色
                e.Graphics.FillRectangle(headerBrush, headerLeft, headerTop, headerWidth, headerHeight)

                ' 繪製表頭文字
                headerLeft += 5
                For Each column As DataGridViewColumn In dataGridViewPrint.Columns
                    Dim columnWidth As Integer = CInt(column.Width * 1.5)

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
                    Dim columnWidth As Integer = CInt(column.Width * 1.5)

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
                                Dim cellWidth As Integer = CInt(column.Width * 1.5)
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
                                    Dim fontSize As Single = 12 ' 設定較小的字體大小
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
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox1.ForeColor = Color.Black
    End Sub

    Private Sub butExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs)
    '   updatestock = True
    'End Sub
End Class