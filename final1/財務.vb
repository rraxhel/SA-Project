Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class 財務
    ' Private printDocument As New PrintDocument()
    Private printDocumentExpenditure As New PrintDocument()
    Private printDocumentIncome As New PrintDocument()
    Private dataGridViewPrint As DataGridView
    Private rowPrinted As Integer = 0

    Private Sub ButExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CalculateTransactionTotals()
        Dim cashTotal As Integer = 0
        Dim creditTotal As Integer = 0
        Dim payTotal As Integer = 0
        Dim outTotal As Integer = 0
        Dim ch As Integer = 0
        Dim allTotal As Integer = 0

        For Each row As DataGridViewRow In grvCard.Rows
            Dim transactionAmount As Integer = Convert.ToInt32(row.Cells("交易金額").Value)
            Dim transactionMethod As String = row.Cells("支付方式").Value.ToString()

            If transactionMethod = "現金" Then
                cashTotal += transactionAmount
            ElseIf transactionMethod = "信用卡" Then
                creditTotal += transactionAmount
            ElseIf transactionMethod = "Line Pay" Then
                payTotal += transactionAmount
            End If
            allTotal = cashTotal + creditTotal + payTotal
        Next

        For Each row As DataGridViewRow In grvOut.Rows
            Dim transactionout As Integer = Convert.ToInt32(row.Cells("進貨金額").Value)
            Dim transactionooo As String = row.Cells("進貨金額").Value.ToString()
            outTotal += transactionout
        Next
        ch = allTotal - outTotal
        textCash.Text = cashTotal.ToString()
        textCard.Text = creditTotal.ToString()
        textPay.Text = payTotal.ToString()
        income.Text = allTotal.ToString()
        outcome.Text = outTotal.ToString()
        chhh.Text = ch.ToString()

    End Sub

    Private Sub DateT_ValueChanged(sender As Object, e As EventArgs) Handles DateT.ValueChanged

        '日
        If (radday.Checked = True) Then
            Dim conn As New connection
            Dim table As New DataTable()
            Dim cmd As New MySqlCommand("SELECT 交易日期, 交易金額, 支付方式 FROM 顧客訂單 WHERE YEAR(交易日期) = @chsyear AND MONTH(交易日期) = @chsmon AND DAY(交易日期) = @chsday ORDER BY 交易日期", conn.getConnection())
            Dim selectedDate As DateTime = DateT.Value
            cmd.Parameters.Add("@chsday", MySqlDbType.VarChar).Value = selectedDate.Day
            cmd.Parameters.Add("@chsmon", MySqlDbType.VarChar).Value = selectedDate.Month
            cmd.Parameters.Add("@chsyear", MySqlDbType.VarChar).Value = selectedDate.Year
            Dim adapter As New MySqlDataAdapter(cmd)
            table.Clear()
            adapter.Fill(table)
            grvCard.DataSource = table

            Dim table2 As New DataTable()
            Dim cmd2 As New MySqlCommand("SELECT 進貨日期, 進貨金額 FROM 進貨 WHERE 進貨日期 = @outday ORDER BY 進貨日期", conn.getConnection)
            cmd2.Parameters.Add("@outday", MySqlDbType.VarChar).Value = DateT.Value
            Dim adapter2 As New MySqlDataAdapter(cmd2)
            table2.Clear()
            adapter2.Fill(table2)
            grvOut.DataSource = table2

        End If

        '月
        If (radmonth.Checked = True) Then
            Dim conn As New connection
            Dim table As New DataTable()
            Dim cmd As New MySqlCommand("SELECT 交易日期, 交易金額, 支付方式 FROM 顧客訂單 WHERE YEAR(交易日期) = @chsyear AND MONTH(交易日期) = @chsmon ORDER BY 顧客訂單.交易日期", conn.getConnection())
            Dim selectedDate As DateTime = DateT.Value
            cmd.Parameters.Add("@chsmon", MySqlDbType.VarChar).Value = selectedDate.Month
            cmd.Parameters.Add("@chsyear", MySqlDbType.VarChar).Value = selectedDate.Year
            Dim adapter As New MySqlDataAdapter(cmd)
            table.Clear()
            adapter.Fill(table) 'table name
            grvCard.DataSource = table

            Dim table2 As New DataTable()
            Dim cmd2 As New MySqlCommand("SELECT 進貨日期, 進貨金額 FROM 進貨 WHERE YEAR(進貨日期) = @outyear AND MONTH(進貨日期) = @outmon ORDER BY 進貨日期", conn.getConnection)
            cmd2.Parameters.Add("@outmon", MySqlDbType.VarChar).Value = selectedDate.Month
            cmd2.Parameters.Add("@outyear", MySqlDbType.VarChar).Value = selectedDate.Year
            Dim adapter2 As New MySqlDataAdapter(cmd2)
            table2.Clear()
            adapter2.Fill(table2)
            grvOut.DataSource = table2

        End If
        '年
        If (radyear.Checked = True) Then
            Dim conn As New connection
            Dim table As New DataTable()
            Dim cmd3 As New MySqlCommand("SELECT 交易日期, 交易金額, 支付方式 FROM 顧客訂單 WHERE YEAR(交易日期) = @chsyear ORDER BY 交易日期", conn.getConnection())
            Dim selectedDate As DateTime = DateT.Value
            cmd3.Parameters.Add("@chsyear", MySqlDbType.VarChar).Value = selectedDate.Year
            Dim adapter3 As New MySqlDataAdapter(cmd3)
            table.Clear()
            adapter3.Fill(table) 'table name
            grvCard.DataSource = table

            Dim table2 As New DataTable()
            Dim cmd2 As New MySqlCommand("SELECT 進貨日期, 進貨金額 FROM 進貨 WHERE YEAR(進貨日期) = @outyear ORDER BY 進貨日期", conn.getConnection)
            cmd2.Parameters.Add("@outyear", MySqlDbType.VarChar).Value = selectedDate.Year
            Dim adapter2 As New MySqlDataAdapter(cmd2)
            table2.Clear()
            adapter2.Fill(table2)
            grvOut.DataSource = table2

        End If

        CalculateTransactionTotals()
    End Sub
    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs)
        ' 取得要列印的 DataGridView
        dataGridViewPrint = grvCard

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
    Private Sub PrintDocument_PrintPage2(sender As Object, e As PrintPageEventArgs)
        ' 取得要列印的 DataGridView
        dataGridViewPrint = grvOut

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
                    Dim columnWidth As Integer = CInt(column.Width * 2.2)

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
                    Dim columnWidth As Integer = CInt(column.Width * 2.2)

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
                                Dim cellWidth As Integer = CInt(column.Width * 2.2)
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
    Private Sub PrintButton_Click(sender As Object, e As EventArgs) Handles butPrint.Click

        ' 清空前一次列印的設定
        Me.printDocumentExpenditure.PrintController = New StandardPrintController()
        Me.printDocumentExpenditure.DefaultPageSettings = New PageSettings()
        ' 使用 PrintDocument 控制項列印 DataGridView
        Dim printDialog As New PrintDialog()
        printDialog.Document = Me.printDocumentExpenditure
        AddHandler Me.printDocumentExpenditure.PrintPage, AddressOf PrintDocument_PrintPage
        ' 使用 PrintPreviewDialog 預覽列印結果
        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = Me.printDocumentExpenditure
        printPreviewDialog.StartPosition = FormStartPosition.CenterScreen

        If printDialog.ShowDialog() = DialogResult.OK Then
            rowPrinted = 0 ' 重置列印的起始行索引
            printPreviewDialog.ShowDialog() ' 顯示列印預覽對話框
        End If

    End Sub

    Private Sub butprint2_Click(sender As Object, e As EventArgs) Handles butprint2.Click
        ' 清空前一次列印的設定
        Me.printDocumentIncome.PrintController = New StandardPrintController()
        Me.printDocumentExpenditure.DefaultPageSettings = New PageSettings()

        ' 使用 PrintDocument 控制項列印 DataGridView
        Dim printDialog As New PrintDialog()
        printDialog.Document = Me.printDocumentIncome
        AddHandler Me.printDocumentIncome.PrintPage, AddressOf PrintDocument_PrintPage2

        ' 使用 PrintPreviewDialog 預覽列印結果
        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = Me.printDocumentIncome
        printPreviewDialog.StartPosition = FormStartPosition.CenterScreen

        If printDialog.ShowDialog() = DialogResult.OK Then
            rowPrinted = 0 ' 重置列印的起始行索引
            printPreviewDialog.ShowDialog() ' 顯示列印預覽對話框
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class