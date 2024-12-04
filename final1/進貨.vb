Imports MySql.Data.MySqlClient
Public Class 進貨
    Private Sub 進貨_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New connection
        Dim cmd As New MySqlCommand("SELECT  商品編號,商品名稱 FROM 商品  ", con.getConnection())
        Dim cmd2 As New MySqlCommand("SELECT  廠商編號,廠商名稱 FROM 廠商  ", con.getConnection())

        Dim adapter As New MySqlDataAdapter(cmd)
        Dim table As New DataTable()
        Dim adapter2 As New MySqlDataAdapter(cmd2)
        Dim table2 As New DataTable()

        'table.Clear()
        adapter.Fill(table)
        ComboBox1.DataSource = table
        ComboBox1.DisplayMember = "商品編號"
        ComboBox1.ValueMember = "商品名稱"
        Label1.Text = " "
        ComboBox1.Text = "選擇商品編號"

        adapter2.Fill(table2)
        ComboBox2.DataSource = table2
        ComboBox2.DisplayMember = "廠商編號"
        ComboBox2.ValueMember = "廠商名稱"
        Label11.Text = " "
        ComboBox2.Text = "選擇廠商編號"

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Label1.Text = ComboBox1.GetItemText(ComboBox1.SelectedValue)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New connection
        Try
            con.Openconnection()
            Dim cmd As New MySqlCommand("INSERT INTO 進貨 (商品編號,廠商編號,商品進貨數量,進貨日期,商品到期日,進貨金額)  VALUES (@MNO,@BuyerNO,@amount,@date,@rdate,@money) ", con.getConnection())
            cmd.Parameters.Add("@amount", MySqlDbType.VarChar).Value = RichTextBox1.Text
            cmd.Parameters.AddWithValue("@money", RichTextBox2.Text)
            cmd.Parameters.AddWithValue("@MNO", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@BuyerNO", ComboBox2.Text)
            cmd.Parameters.AddWithValue("@date", DateTimePicker1.Value)
            cmd.Parameters.AddWithValue("@rdate", DateTimePicker2.Value)

            cmd.ExecuteNonQuery()
            con.Closeconnection()


            If (RichTextBox1.Text <> "") And (RichTextBox1.Text <> "") Then
                MsgBox("新增成功!")
            End If
            con.Openconnection()
            Dim cmd2 As New MySqlCommand("UPDATE 庫存 SET 商品數量 = 商品數量 + @新增數量 WHERE 商品編號=@MNO", con.getConnection())
            cmd2.Parameters.AddWithValue("@新增數量", Convert.ToInt32(RichTextBox1.Text))
            cmd2.Parameters.AddWithValue("@MNO", ComboBox1.Text)

            cmd2.ExecuteNonQuery()
            'con.Closeconnection()

            'con.Openconnection()
            'Dim cmd3 As New MySqlCommand("UPDATE 庫存 SET 商品數量 = @新增數量 WHERE 商品編號=@MNO", con.getConnection())
            'cmd3.Parameters.AddWithValue("@新增數量", Convert.ToInt32(RichTextBox1.Text))
            'cmd3.Parameters.AddWithValue("@MNO", ComboBox1.Text)

            'cmd3.ExecuteNonQuery()
            con.Closeconnection()
        Catch ex As Exception
            ' 处理异常
            MsgBox("該商品今日已有進貨!")

        End Try
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Label11.Text = ComboBox2.GetItemText(ComboBox2.SelectedValue)
    End Sub

    Private Sub butExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


End Class