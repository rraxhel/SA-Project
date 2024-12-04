Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Diagnostics.Eventing
Public Class 訂單
    Private selectedRowIndex As Integer = -1
    Private printDocument As New PrintDocument()
    Private printPreviewDialog As PrintPreviewDialog
    Private readers As Object
    Private dataGridViewPrint As DataGridView
    Private rowPrinted As Integer = 0

    Private Sub 訂單_Load_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboBoxItems()
        Dim con As New connection()
        Dim adapter As New MySqlDataAdapter("SELECT `顧客訂單`.`交易編號`,`顧客訂單`.`發票編號`, `顧客訂單`.`交易日期`, `顧客訂單`.`交易金額`, `顧客訂單`.`支付方式`, " &
                                       "GROUP_CONCAT(CONCAT(`顧客訂單品項`.`商品名稱`, ' - ', `顧客訂單品項`.`商品數量`)) AS 商品與數量 " &
                                       "FROM 顧客訂單 " &
                                       "JOIN 顧客訂單品項 ON `顧客訂單`.`交易編號` = `顧客訂單品項`.`交易編號` " &
                                       "GROUP BY `顧客訂單`.`交易編號`,`顧客訂單`.`發票編號`, `顧客訂單`.`交易日期`, `顧客訂單`.`交易金額`, `顧客訂單`.`支付方式`", con.getConnection())
        Dim table As New DataTable()
        DataGridView1.Rows.Clear()
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        adapter.Fill(table) 'table name
        DataGridView1.DataSource = table
        AddHandler printDocument.PrintPage, AddressOf PrintDocument_PrintPage
    End Sub

    Private Sub LoadComboBoxItems()
        ' 清除 ComboBox 的舊選項
        ComboBox1.Items.Clear()

        ' 加入發票編號和交易金額作為選項
        ComboBox1.Items.Add("信用卡")
        ComboBox1.Items.Add("現金")
        ComboBox1.Items.Add("Line Pay")

    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim con As New connection()
            Dim selectedProperty As String = ComboBox1.SelectedItem.ToString()

            Dim selectedDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
            Dim command As MySqlCommand = Nothing
            If selectedProperty = "支付方式" Then
                command = New MySqlCommand("SELECT `顧客訂單`.`交易編號`, `顧客訂單`.`發票編號`, `顧客訂單`.`交易日期`, `顧客訂單`.`交易金額`, `顧客訂單`.`支付方式`, " &
                               "GROUP_CONCAT(CONCAT(`顧客訂單品項`.`商品名稱`, ' - ', `顧客訂單品項`.`商品數量`)) AS 品項與數量 " &
                               "FROM 顧客訂單 " &
                               "JOIN 顧客訂單品項 ON `顧客訂單`.`交易編號` = `顧客訂單品項`.`交易編號` " &
                               "WHERE `顧客訂單`.`支付方式` LIKE @UserInput " &
                               "AND DATE(`顧客訂單`.`交易日期`) = @SelectedDate " &
                               "GROUP BY `顧客訂單`.`交易編號`, `顧客訂單`.`發票編號`, `顧客訂單`.`交易日期`, `顧客訂單`.`交易金額`, `顧客訂單`.`支付方式`", con.getConnection())
            End If

            If command IsNot Nothing Then

                command.Parameters.AddWithValue("@SelectedDate", selectedDate)
                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table) ' 填充資料到 DataTable

                DataGridView1.DataSource = table
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim userInput As String = ComboBox1.Text
        Dim command As MySqlCommand = Nothing
        Dim con As New connection()
        Dim selectedDate As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        command = New MySqlCommand("SELECT `顧客訂單`.`交易編號`, `顧客訂單`.`發票編號`, `顧客訂單`.`交易日期`, `顧客訂單`.`交易金額`, `顧客訂單`.`支付方式`, " &
                          "GROUP_CONCAT(CONCAT(`顧客訂單品項`.`商品名稱`, ' - ', `顧客訂單品項`.`商品數量`)) AS 品項與數量 " &
                          "FROM 顧客訂單 " &
                          "JOIN 顧客訂單品項 ON `顧客訂單`.`交易編號` = `顧客訂單品項`.`交易編號` " &
                          "WHERE `顧客訂單`.`支付方式` LIKE @UserInput " &
                          "AND DATE(`顧客訂單`.`交易日期`) = @SelectedDate " &
                          "GROUP BY `顧客訂單`.`交易編號`, `顧客訂單`.`發票編號`, `顧客訂單`.`交易日期`, `顧客訂單`.`交易金額`, `顧客訂單`.`支付方式`", con.getConnection())
        If command IsNot Nothing Then
            command.Parameters.AddWithValue("@UserInput", "%" & userInput & "%")
            command.Parameters.AddWithValue("@SelectedDate", selectedDate)
            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table) ' 填充資料到 DataTable
            If table.Rows.Count > 0 Then
                DataGridView1.DataSource = table
            Else
                MessageBox.Show("無資料", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ComboBox1.SelectedIndex = -1
        End If
    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' 检查是否选中了行
        If DataGridView1.SelectedRows.Count > 0 Then
            ' 提示用户确认删除
            Dim result As DialogResult = MessageBox.Show("确定要刪除選中的訂單吗？", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                ' 获取选中行的订单号
                Dim orderId As String = DataGridView1.SelectedRows(0).Cells("交易編號").Value.ToString()

                ' 使用您的数据库连接字符串
                Dim con As New connection

                Try
                    con.Openconnection()

                    ' 删除订单项数据
                    Dim deleteOrderItemCommand As New MySqlCommand("DELETE FROM 顧客訂單品項 WHERE 交易編號 = @OrderId", con.getConnection())
                    deleteOrderItemCommand.Parameters.AddWithValue("@OrderId", orderId)
                    deleteOrderItemCommand.ExecuteNonQuery()

                    ' 删除订单数据
                    Dim deleteOrderCommand As New MySqlCommand("DELETE FROM 顧客訂單 WHERE 交易編號 = @OrderId", con.getConnection())
                    deleteOrderCommand.Parameters.AddWithValue("@OrderId", orderId)
                    deleteOrderCommand.ExecuteNonQuery()

                    MessageBox.Show("訂單刪除成功")

                    ' 重新加载数据到DataGridView控件
                    RefreshDataGridView()
                Catch ex As Exception
                    MessageBox.Show("發生錯誤：" & ex.Message)
                Finally
                    con.Closeconnection()
                End Try
            End If
        Else
            MessageBox.Show("請選擇要刪除的訂單")
        End If
    End Sub




    Private Sub RefreshDataGridView()
        ' 清空DataGridView的数据源
        DataGridView1.DataSource = Nothing

        ' 重新加载数据到DataGridView
        ' 示例：从数据库或其他数据源获取最新数据
        Dim con As New connection()
        Dim adapter As New MySqlDataAdapter("SELECT `顧客訂單`.`交易編號`,`顧客訂單`.`發票編號`, `顧客訂單`.`交易日期`, `顧客訂單`.`交易金額`, `顧客訂單`.`支付方式`, " &
                                       "GROUP_CONCAT(CONCAT(`顧客訂單品項`.`商品名稱`, ' - ', `顧客訂單品項`.`商品數量`)) AS 商品與數量 " &
                                       "FROM 顧客訂單 " &
                                       "JOIN 顧客訂單品項 ON `顧客訂單`.`交易編號` = `顧客訂單品項`.`交易編號` " &
                                       "GROUP BY `顧客訂單`.`交易編號`,`顧客訂單`.`發票編號`, `顧客訂單`.`交易日期`, `顧客訂單`.`交易金額`, `顧客訂單`.`支付方式`", con.getConnection())
        Dim table As New DataTable()
        DataGridView1.Rows.Clear()
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        adapter.Fill(table) 'table name
        DataGridView1.DataSource = table
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
        If printHeight < dataGridViewPrint.Rows(rowPrinted).Height * 1 Then
            morePages = True
        End If

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
                                    Dim fontSize As Single = 8 ' 設定較小的字體大小
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
