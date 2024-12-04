Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class 訂單修改

    Private Sub 訂單修改_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboBoxItems()
        Dim con As New connection()
        Dim adapter As New MySqlDataAdapter("SELECT `顧客訂單`.`交易編號`,`顧客訂單`.`發票編號`, `顧客訂單`.`交易日期`, `顧客訂單`.`交易金額`, `顧客訂單`.`支付方式`, " &
                                   "GROUP_CONCAT(CONCAT(`顧客訂單品項`.`商品編號`, '-', `顧客訂單品項`.`商品名稱`, ':', `顧客訂單品項`.`商品數量`)) AS `商品與數量` " &
                                   "FROM `顧客訂單` " &
                                   "JOIN `顧客訂單品項` ON `顧客訂單`.`交易編號` = `顧客訂單品項`.`交易編號` " &
                                   "GROUP BY `顧客訂單`.`交易編號`,`顧客訂單`.`發票編號`, `顧客訂單`.`交易日期`, `顧客訂單`.`交易金額`, `顧客訂單`.`支付方式`", con.getConnection())

        Dim table As New DataTable()
        DataGridView1.Rows.Clear()
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        adapter.Fill(table) 'table name
        DataGridView1.DataSource = table
        ComboBox1.Items.Add("現金")
        ComboBox1.Items.Add("信用卡")
        ComboBox1.Items.Add("Line Pay")
    End Sub
    Private Sub LoadComboBoxItems()
        ' 清除 ComboBox 的舊選項
        ComboBox2.Items.Clear()

        ' 加入商品編號和名稱作為選項
        Dim con As New connection ' 使用您的資料庫連線字串

        Try
            con.Openconnection()

            ' 查詢商品編號和商品名稱
            Dim queryProductsCommand As New MySqlCommand("SELECT `商品編號`, `商品名稱` FROM `商品`", con.getConnection())
            Dim reader As MySqlDataReader = queryProductsCommand.ExecuteReader()

            While reader.Read()
                Dim itemNo As String = reader("商品編號").ToString()
                Dim productName As String = reader("商品名稱").ToString()

                ' 組合商品編號和名稱顯示在 ComboBox 中
                Dim displayText As String = itemNo & " - " & productName
                ComboBox2.Items.Add(displayText)
            End While

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("發生錯誤：" & ex.Message)
        Finally
            con.Closeconnection()
        End Try
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        ' 检查是否有选中行
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' 将日期显示在 DateTimePicker 中
            DateTimePicker1.Value = Convert.ToDateTime(selectedRow.Cells("交易日期").Value)

            ' 将支付方式显示在 ComboBox 中
            ComboBox1.SelectedItem = selectedRow.Cells("支付方式").Value.ToString()

            ' 将商品和数量显示在 TextBox 中
            Dim productsWithQuantities As String = selectedRow.Cells("商品與數量").Value.ToString()

            ' 使用逗号分割商品与数量
            Dim productQuantities As String() = productsWithQuantities.Split(","c)

            TextBox1.Clear() ' 清空原有内容

            For Each productQuantity As String In productQuantities
                TextBox1.AppendText(productQuantity.Trim() & vbCrLf)
            Next
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' 檢查輸入欄位是否有值
        If ComboBox2.SelectedItem IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
            Dim item As String = ComboBox2.SelectedItem.ToString() ' 商品名稱
            Dim quantity As String = TextBox2.Text.Trim() ' 數量

            TextBox1.Text += item & ": " & quantity & vbCrLf ' 將商品和數量添加到 TextBox3 中1

            ComboBox2.SelectedIndex = -1 ' 清除選擇的商品
            TextBox2.Clear() ' 清空數量欄位

        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' 检查输入字段是否有值
        If Not String.IsNullOrWhiteSpace(TextBox1.Text) AndAlso ComboBox1.SelectedItem IsNot Nothing Then
            Dim con As New connection ' 使用您的数据库连接字符串

            Try
                con.Openconnection()
                ' 验证订单是否存在
                Dim selectedOrderId As Integer = 0
                If DataGridView1.SelectedRows.Count > 0 Then
                    selectedOrderId = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("交易編號").Value)
                End If
                If selectedOrderId = 0 Then
                    MessageBox.Show("請選擇訂單")
                    Return
                End If


                Dim checkOrderCommand As New MySqlCommand("SELECT COUNT(*) FROM `顧客訂單` WHERE `交易編號` = @OrderId", con.getConnection())
                checkOrderCommand.Parameters.AddWithValue("@OrderId", selectedOrderId)
                Dim orderCount As Integer = Convert.ToInt32(checkOrderCommand.ExecuteScalar())
                If orderCount = 0 Then
                    ' 订单不存在
                    MessageBox.Show("订单不存在")
                    Return
                End If

                ' 获取当前订单的交易金额
                Dim getOrderAmountCommand As New MySqlCommand("SELECT `交易金額` FROM `顧客訂單` WHERE `交易編號` = @OrderId", con.getConnection())
                getOrderAmountCommand.Parameters.AddWithValue("@OrderId", selectedOrderId)
                Dim currentOrderAmount As Integer = Convert.ToInt32(getOrderAmountCommand.ExecuteScalar())

                ' 更新订单信息
                Dim userInput3 As String = ComboBox1.SelectedItem.ToString() ' 支付方式
                Dim userInput4 As Date = DateTimePicker1.Value ' 日期
                Dim itemInfo As String = TextBox1.Text.Trim() ' 商品名稱和數量

                ' 更新顾客訂單表
                Dim updateOrderCommand As New MySqlCommand("UPDATE `顧客訂單` SET  `支付方式` = @UserInput3, `交易日期` = @UserInput4 WHERE `交易編號` = @OrderId", con.getConnection())
                updateOrderCommand.Parameters.AddWithValue("@UserInput3", userInput3)
                updateOrderCommand.Parameters.AddWithValue("@UserInput4", userInput4)
                updateOrderCommand.Parameters.AddWithValue("@OrderId", selectedOrderId)
                updateOrderCommand.ExecuteNonQuery()

                ' 更新顾客訂單品項表（先删除原有的品項）
                Dim deleteItemsCommand As New MySqlCommand("DELETE FROM `顧客訂單品項` WHERE `交易編號` = @OrderId", con.getConnection())
                deleteItemsCommand.Parameters.AddWithValue("@OrderId", selectedOrderId)
                deleteItemsCommand.ExecuteNonQuery()

                Dim allItemsUpdated As Boolean = True ' 标记是否所有订单品项都成功更新
                Dim transactionAmount As Integer = 0 ' 重新计算交易金额

                ' 拆分每個商品名稱和數量的組合
                Dim itemLines As String() = itemInfo.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries) ' 使用換行符號分割每個商品

                For Each itemLine As String In itemLines
                    ' 拆分商品編號、商品名稱和商品數量
                    Dim itemParts As String() = itemLine.Split("-"c, ":"c) ' 使用連字符 "-" 和冒號 ":" 作為分隔符號
                    If itemParts.Length = 3 Then
                        Dim itemCode As String = itemParts(0).Trim()
                        Dim itemName As String = itemParts(1).Trim()
                        Dim itemQuantity As Integer = itemParts(2).Trim()
                        If Integer.TryParse(itemParts(2).Trim(), itemQuantity) Then
                            ' 查询商品編號和售價
                            Dim queryProductCommand As New MySqlCommand("SELECT `商品編號`, `商品售價` FROM `商品` WHERE `商品名稱` = @ItemName", con.getConnection())
                            queryProductCommand.Parameters.AddWithValue("@ItemName", itemName)

                            Dim reader As MySqlDataReader = queryProductCommand.ExecuteReader()
                            If reader.Read() Then
                                Dim productId As String = reader("商品編號").ToString()
                                Dim productPrice As Double = Convert.ToDouble(reader("商品售價"))
                                reader.Close()

                                ' 查询商品库存数量
                                Dim queryStockCommand As New MySqlCommand("SELECT `商品數量` FROM `庫存` WHERE `商品名稱` = @ItemName", con.getConnection())
                                queryStockCommand.Parameters.AddWithValue("@ItemName", itemName)

                                Dim reader2 As MySqlDataReader = queryStockCommand.ExecuteReader()
                                If reader2.Read() Then
                                    Dim currentStock As Integer = Convert.ToInt32(reader2("商品數量"))
                                    reader2.Close()

                                    ' 检查库存是否充足
                                    If currentStock >= itemQuantity Then
                                        ' 更新商品库存数量
                                        Dim updateStockCommand As New MySqlCommand("UPDATE `庫存` SET `商品數量` = `商品數量` - @ItemQuantity WHERE `商品名稱` = @ItemName", con.getConnection())
                                        updateStockCommand.Parameters.AddWithValue("@ItemQuantity", itemQuantity)
                                        updateStockCommand.Parameters.AddWithValue("@ItemName", itemName)
                                        updateStockCommand.ExecuteNonQuery()

                                        ' 计算交易金额
                                        Dim itemAmount As Integer = Convert.ToInt32(productPrice * itemQuantity)
                                        transactionAmount += itemAmount

                                        ' 插入顧客訂單品項
                                        Dim itemCommand As New MySqlCommand("INSERT INTO `顧客訂單品項` (`交易編號`, `商品編號`, `商品名稱`, `商品數量`) VALUES (@OrderId, @ProductId, @ItemName, @ItemQuantity)", con.getConnection())
                                        itemCommand.Parameters.AddWithValue("@OrderId", selectedOrderId)
                                        itemCommand.Parameters.AddWithValue("@ProductId", productId)
                                        itemCommand.Parameters.AddWithValue("@ItemName", itemName)
                                        itemCommand.Parameters.AddWithValue("@ItemQuantity", itemQuantity)
                                        itemCommand.ExecuteNonQuery()
                                    Else
                                        ' 库存不足
                                        MessageBox.Show("商品库存不足")
                                        allItemsUpdated = False
                                        Exit For
                                    End If
                                Else
                                    ' 商品不存在
                                    MessageBox.Show("商品不存在")
                                    allItemsUpdated = False
                                    Exit For
                                End If
                            Else
                                ' 商品不存在
                                MessageBox.Show("商品不存在")
                                allItemsUpdated = False
                                Exit For
                            End If
                        Else
                            ' 商品名稱和數量格式不正確
                            MessageBox.Show("商品名稱和數量格式不正確")
                            allItemsUpdated = False
                            Exit For
                        End If
                    Else
                        ' 商品名稱和數量格式不正確
                        MessageBox.Show("商品名稱和數量格式不正確")
                        allItemsUpdated = False
                        Exit For
                    End If
                Next

                If allItemsUpdated Then
                    ' 更新顧客訂單總金額
                    Dim updateOrderAmountCommand As New MySqlCommand("UPDATE `顧客訂單` SET `交易金額` = @TransactionAmount WHERE `交易編號` = @OrderId", con.getConnection())
                    updateOrderAmountCommand.Parameters.AddWithValue("@TransactionAmount", transactionAmount)
                    updateOrderAmountCommand.Parameters.AddWithValue("@OrderId", selectedOrderId)
                    updateOrderAmountCommand.ExecuteNonQuery()

                    MessageBox.Show("訂單修改成功")
                    TextBox1.Clear() ' 清空商品名稱和數量的輸入框
                    ComboBox1.SelectedIndex = -1 ' 清除 ComboBox1 的選擇項
                    TextBox1.Clear() ' 清空發票編號的輸入框
                    RefreshDataGridView()
                End If
            Catch ex As Exception
                MessageBox.Show("發生錯誤：" & ex.Message)
            Finally
                con.Closeconnection()
            End Try
        Else
            ' 欄位未填寫完整
            MessageBox.Show("請填寫完整的訂單資訊")
        End If
    End Sub


    Private Sub RefreshDataGridView()
        ' 清空DataGridView的数据源
        DataGridView1.DataSource = Nothing

        ' 重新加载数据到DataGridView
        ' 示例：从数据库或其他数据源获取最新数据
        Dim con As New connection()
        Dim adapter As New MySqlDataAdapter("SELECT `顧客訂單`.`交易編號`,`顧客訂單`.`發票編號`, `顧客訂單`.`交易日期`, `顧客訂單`.`交易金額`, `顧客訂單`.`支付方式`, " &
                                   "GROUP_CONCAT(CONCAT(`顧客訂單品項`.`商品編號`, '-', `顧客訂單品項`.`商品名稱`, ':', `顧客訂單品項`.`商品數量`)) AS `商品與數量` " &
                                   "FROM `顧客訂單` " &
                                   "JOIN `顧客訂單品項` ON `顧客訂單`.`交易編號` = `顧客訂單品項`.`交易編號` " &
                                   "GROUP BY `顧客訂單`.`交易編號`,`顧客訂單`.`發票編號`, `顧客訂單`.`交易日期`, `顧客訂單`.`交易金額`, `顧客訂單`.`支付方式`", con.getConnection())
        Dim table As New DataTable()
        DataGridView1.Rows.Clear()
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        adapter.Fill(table) 'table name
        DataGridView1.DataSource = table
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)
        Me.Close()
        主選單.Show()
    End Sub

    Private Sub butExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

End Class