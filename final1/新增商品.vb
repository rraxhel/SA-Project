Imports MySql.Data.MySqlClient


Public Class 新增商品
    Public temp As Boolean = False
    Private Sub butUpdate_Click(sender As Object, e As EventArgs) Handles butUpdate.Click
        Dim con As New connection
        con.Openconnection()
        Dim cmd As New MySqlCommand("INSERT INTO 商品 (商品編號,商品名稱,商品售價)  VALUES (@MNO,@MName,@Price) ", con.getConnection())
        cmd.Parameters.AddWithValue("@MNO", proID.Text)
        cmd.Parameters.AddWithValue("@MName", proName.Text)
        cmd.Parameters.AddWithValue("@Price", price.Text)

        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter(cmd)
        table.Clear()
        adapter.Fill(table)
        DataGridView1.DataSource = table
        DataGridView1.AutoResizeColumns()
        DataGridView1.AutoResizeRows()
        DataGridView1.RowHeadersWidth = 30

        If (proID.Text <> "") And (proName.Text <> "") Then
            MsgBox("新增成功!")
            temp = True
            RefreshDataGridView()
        End If
        If temp = True Then
            updatestock()
            temp = False
        End If
        con.Closeconnection()

        proID.Clear()
        proName.Clear()
        price.Clear()

    End Sub

    Private Sub 新增商品_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()
    End Sub

    Private Sub butExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub



    Sub updatestock()
        Dim con As New connection
        Dim cmd2 As New MySqlCommand("INSERT INTO 庫存 (商品編號,商品名稱) VALUES (@MNO,@MName)", con.getConnection())
        con.Openconnection()
        cmd2.Parameters.AddWithValue("@MNO", proID.Text)
        cmd2.Parameters.AddWithValue("@MName", proName.Text)
        'cmd2.Parameters.AddWithValue("@Number", 0)

        cmd2.ExecuteNonQuery()
        con.Closeconnection()
    End Sub
    Sub load()
        Dim con As New connection
        Dim cmd As New MySqlCommand("Select * From 商品 ", con.getConnection())
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter(cmd)
        table.Clear()
        adapter.Fill(table)
        DataGridView1.DataSource = table
        DataGridView1.AutoResizeColumns()
        DataGridView1.AutoResizeRows()
        DataGridView1.RowHeadersWidth = 30
    End Sub

    Private Sub RefreshDataGridView()
        ' 清空DataGridView的数据源
        DataGridView1.DataSource = Nothing

        ' 重新加载数据到DataGridView
        ' 示例：从数据库或其他数据源获取最新数据
        Dim con As New connection()
        Dim adapter As New MySqlDataAdapter("Select * From 商品", con.getConnection())
        Dim table As New DataTable()
        DataGridView1.Rows.Clear()
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        adapter.Fill(table) 'table name
        DataGridView1.DataSource = table
    End Sub
End Class