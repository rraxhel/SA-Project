Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing


Public Class 銷貨
    Private selectedRowIndex As Integer = -1
    Private printDocument As New PrintDocument()
    Private printPreviewDialog As PrintPreviewDialog
    Private dataGridViewPrint As DataGridView
    Private rowPrinted As Integer = 0
    Private originalTable As DataTable ' 儲存原始的資料表


    Private Sub 銷貨_Load_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboBoxItems()
        LoadData() ' 加载初始数据并添加排行列
        AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
    End Sub


    Private Sub LoadComboBoxItems()
        ' 清除 ComboBox 的舊選項
        ComboBox1.Items.Clear()

        ' 加入發票編號和交易金額作為選項
        ComboBox1.Items.Add("商品名稱")
        ComboBox1.Items.Add("商品編號")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedValue As String = ComboBox1.SelectedItem.ToString()

            ' 连接到数据库，执行查询，并填充 ComboBox2
            Dim con As New connection()
            Dim command As MySqlCommand = Nothing
            Dim dataTable As New DataTable()

            If selectedValue = "商品編號" Then
                command = New MySqlCommand("SELECT DISTINCT `商品編號` FROM `商品`", con.getConnection())
            ElseIf selectedValue = "商品名稱" Then
                command = New MySqlCommand("SELECT DISTINCT `商品名稱` FROM `商品`", con.getConnection())
            End If

            If command IsNot Nothing Then
                Dim adapter As New MySqlDataAdapter(command)
                adapter.Fill(dataTable)
            End If

            ComboBox2.DataSource = dataTable
            ComboBox2.DisplayMember = selectedValue
            ComboBox2.ValueMember = selectedValue
        End If
    End Sub

    Private Sub LoadData()
        Dim con As New connection()
        Dim adapter As New MySqlDataAdapter("SELECT `商品`.`商品編號`, `商品`.`商品名稱`, `商品`.`商品售價`,
        SUM(`顧客訂單品項`.`商品數量`) AS `總數量`,
        SUM(`商品`.`商品售價` * `顧客訂單品項`.`商品數量`) AS `總金額`,
        ROW_NUMBER() OVER (ORDER BY SUM(`顧客訂單品項`.`商品數量`) DESC) AS `排名`
        FROM `顧客訂單`
        JOIN `顧客訂單品項` ON `顧客訂單`.`交易編號` = `顧客訂單品項`.`交易編號`
        JOIN `商品` ON `顧客訂單品項`.`商品編號` = `商品`.`商品編號`
        GROUP BY `商品`.`商品編號`, `商品`.`商品名稱`, `商品`.`商品售價`
        ORDER BY `總數量` DESC", con.getConnection())
        originalTable = New DataTable()
        DataGridView1.Rows.Clear()
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        adapter.Fill(originalTable)

        DataGridView1.DataSource = originalTable
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userInput As String = ComboBox2.Text
        Dim searchColumn As String = ""

        If ComboBox1.SelectedItem.ToString() = "商品編號" Then
            searchColumn = "商品編號"
        ElseIf ComboBox1.SelectedItem.ToString() = "商品名稱" Then
            searchColumn = "商品名稱"
        End If

        If Not String.IsNullOrEmpty(userInput) AndAlso Not String.IsNullOrEmpty(searchColumn) Then
            ' 根據使用者輸入過濾資料
            Dim filteredRows() As DataRow = originalTable.Select(searchColumn & " = '" & userInput & "'")
            Dim filteredTable As DataTable = originalTable.Clone()

            For Each row As DataRow In filteredRows
                filteredTable.ImportRow(row)
            Next

            DataGridView1.DataSource = filteredTable
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
                                    Dim fontSize As Single = 11 ' 設定較小的字體大小
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

    Private Sub Label7_Click(sender As Object, e As EventArgs)
        Me.Close()
        主選單.Show()
    End Sub

    Private Sub butExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class