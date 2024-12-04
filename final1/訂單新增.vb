Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class 訂單新增
    Private selectedRowIndex As Integer = -1
    Private printDocument As PrintDocument
    Private printPreviewDialog As PrintPreviewDialog

    Private Sub 訂單_Load_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboBoxItems()
        ComboBox1.Items.Add("現金")
        ComboBox1.Items.Add("信用卡")
        ComboBox1.Items.Add("Line Pay")
        printDocument = New PrintDocument()
        printPreviewDialog = New PrintPreviewDialog()
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


    Private Function CalculateTotalPrice(item As String, quantity As String) As Integer
        Dim itemAmount As Integer = 0 ' 商品金额
        Dim qty As Integer ' 数量
        Dim con As New connection
        Dim query As String = "SELECT `商品售價` FROM `商品` WHERE `商品名稱` = @Item"

        Using connection As MySqlConnection = con.getConnection()
            connection.Open()

            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Item", item)

                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        Dim pricePerItem As Double = Convert.ToDouble(reader("商品售價"))

                        If Integer.TryParse(quantity, qty) Then
                            itemAmount = Convert.ToInt32(pricePerItem * qty)
                        End If
                    End If
                End Using
            End Using
        End Using

        Return itemAmount
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' 检查输入字段是否有值
        If ComboBox2.SelectedItem IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
            Dim item As String = ComboBox2.SelectedItem.ToString() ' 商品名称
            Dim quantity As String = TextBox2.Text.Trim() ' 数量

            TextBox3.Text += item & ": " & quantity & vbCrLf ' 将商品和数量添加到 TextBox3 中

            ' 计算商品金额
            Dim itemAmount As Integer = CalculateTotalPrice(item, quantity)

            ' 计算总金额
            Dim totalPrice As Integer = itemAmount + CalculateTotalAmount()

            ' 更新 Label 控制项上的总金额
            Label7.Text = "總金額: " & totalPrice.ToString()

            ComboBox2.SelectedIndex = -1 ' 清除选择的商品
            TextBox2.Clear() ' 清空数量字段
        Else
            ' 字段未填写完整
            MessageBox.Show("請選擇商品並填寫數量")
        End If
    End Sub

    Private Function CalculateTotalAmount() As Integer
        Dim totalAmount As Integer = 0

        ' 将 TextBox3 中的商品和数量拆分并计算总金额
        Dim itemLines As String() = TextBox3.Text.Trim().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

        For Each itemLine As String In itemLines
            Dim itemParts As String() = itemLine.Split("-"c, ":"c) ' 使用连字符 "-" 和冒号 ":" 作为分隔符号

            If itemParts.Length = 3 Then
                Dim itemName As String = itemParts(1).Trim()
                Dim itemQuantity As Integer = 0

                If Integer.TryParse(itemParts(2).Trim(), itemQuantity) Then
                    Dim itemAmount As Integer = CalculateTotalPrice(itemName, itemQuantity.ToString())
                    totalAmount += itemAmount
                End If
            End If
        Next

        Return totalAmount
    End Function




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' 檢查輸入欄位是否有值
        If Not String.IsNullOrWhiteSpace(TextBox1.Text) AndAlso ComboBox1.SelectedItem IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
            Dim con As New connection ' 使用您的数据库连接字符串

            Try
                con.Openconnection()
                Dim checkInvoiceCommand As New MySqlCommand("SELECT COUNT(*) FROM `顧客訂單` WHERE `發票編號` = @InvoiceNumber", con.getConnection())
                checkInvoiceCommand.Parameters.AddWithValue("@InvoiceNumber", TextBox1.Text.Trim())
                Dim invoiceCount As Integer = Convert.ToInt32(checkInvoiceCommand.ExecuteScalar())
                If invoiceCount > 0 Then
                    ' 發票編號已存在
                    MessageBox.Show("輸入發票編號已存在")
                    Return
                End If

                ' 驗證發票編號格式
                Dim invoicePattern As String = "^[A-Za-z]{2}-\d{8}$"
                Dim invoiceRegex As New Regex(invoicePattern)

                If Not invoiceRegex.IsMatch(TextBox1.Text.Trim()) Then
                    ' 發票編號格式不正確
                    MessageBox.Show("發票編號格式不正確，應為兩個英文字母加上連字符 '-' 與八個數字")
                    Return
                End If

                ' 获取数据库中最大的交易編號
                Dim getMaxOrderIdCommand As New MySqlCommand("SELECT MAX(`交易編號`) FROM `顧客訂單`", con.getConnection())

                Dim maxOrderId As Integer = Convert.ToInt32(getMaxOrderIdCommand.ExecuteScalar())

                ' 计算新记录的交易編號
                Dim newOrderId As Integer = maxOrderId + 1

                Dim allItemsAdded As Boolean = True ' 标记是否所有订单品项都成功添加
                Dim userInput3 As String = ComboBox1.SelectedItem.ToString() ' 支付方式
                Dim userInput4 As Date = DateTimePicker1.Value ' 日期
                Dim userInput5 As String = TextBox1.Text.Trim() ' 發票編號
                Dim itemInfo As String = TextBox3.Text.Trim() ' 商品名稱和數量
                Dim transactionAmount As Integer = 0
                ' 拆分每個商品名稱和數量的組合

                Dim itemLines As String() = itemInfo.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries) ' 使用換行符號分割每個商品

                ' 插入顧客訂單
                Dim insertOrderCommand As New MySqlCommand("INSERT INTO `顧客訂單` (`交易編號`, `發票編號`, `支付方式`, `交易日期`) VALUES (@OrderId, @UserInput5, @UserInput3, @UserInput4)", con.getConnection())

                insertOrderCommand.Parameters.AddWithValue("@OrderId", newOrderId)
                insertOrderCommand.Parameters.AddWithValue("@UserInput5", userInput5)

                insertOrderCommand.Parameters.AddWithValue("@UserInput3", userInput3)
                insertOrderCommand.Parameters.AddWithValue("@UserInput4", userInput4)
                insertOrderCommand.ExecuteNonQuery()


                For Each itemLine As String In itemLines
                    ' 拆分商品編號、商品名稱和商品數量
                    Dim itemParts As String() = itemLine.Split("-"c, ":"c) ' 使用連字符 "-" 和冒號 ":" 作為分隔符號
                    If itemParts.Length = 3 Then
                        Dim itemCode As String = itemParts(0).Trim()
                        Dim itemName As String = itemParts(1).Trim()
                        Dim itemQuantity As Integer = 0
                        If Integer.TryParse(itemParts(2).Trim(), itemQuantity) Then
                            ' 查詢商品編號和售價
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
                                        itemCommand.Parameters.AddWithValue("@OrderId", newOrderId)
                                        itemCommand.Parameters.AddWithValue("@ProductId", productId)
                                        itemCommand.Parameters.AddWithValue("@ItemName", itemName)
                                        itemCommand.Parameters.AddWithValue("@ItemQuantity", itemQuantity)
                                        itemCommand.ExecuteNonQuery()
                                    Else
                                        ' 库存不足
                                        MessageBox.Show("商品库存不足")
                                        allItemsAdded = False
                                        Exit For
                                    End If
                                Else
                                    ' 商品不存在
                                    MessageBox.Show("商品不存在")
                                    allItemsAdded = False
                                    Exit For
                                End If
                            Else
                                ' 商品不存在
                                MessageBox.Show("商品不存在")
                                allItemsAdded = False
                                Exit For
                            End If
                        Else
                            ' 商品名稱和數量格式不正確
                            MessageBox.Show("商品名稱和數量格式不正確")
                            allItemsAdded = False
                            Exit For
                        End If
                    Else
                        ' 商品名稱和數量格式不正確
                        MessageBox.Show("商品名稱和數量格式不正確")
                        allItemsAdded = False
                        Exit For
                    End If
                Next

                If allItemsAdded = True Then
                    ' 更新顧客訂單總金額
                    Dim updateOrderAmountCommand As New MySqlCommand("UPDATE `顧客訂單` SET `交易金額` = @TransactionAmount WHERE `交易編號` = @OrderId", con.getConnection())
                    updateOrderAmountCommand.Parameters.AddWithValue("@TransactionAmount", transactionAmount)
                    updateOrderAmountCommand.Parameters.AddWithValue("@OrderId", newOrderId)
                    updateOrderAmountCommand.ExecuteNonQuery()

                    MessageBox.Show("訂單添加成功")
                    TextBox3.Clear() ' 清空商品名稱和數量的輸入框
                    ComboBox1.SelectedIndex = -1 ' 清除 ComboBox1 的選擇項
                    TextBox1.Clear() ' 清空發票編號的輸入框
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


    Private Sub butExit_Click_1(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


End Class