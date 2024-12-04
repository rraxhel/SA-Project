Imports MySql.Data.MySqlClient

Public Class 存貨修改

    Private Sub ButExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub 存貨修改_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        newload()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        proName.Text = ComboBox1.GetItemText(ComboBox1.SelectedValue)
    End Sub

    Private Sub butUpdate_Click(sender As Object, e As EventArgs) Handles butUpdate.Click

        Dim conn As New connection()
        Dim updateQuery = "UPDATE 庫存 SET 商品名稱 = @proname, 商品數量 = @pronum WHERE 商品編號 = @proid"
        Dim table As New DataTable()
        Dim command As New MySqlCommand(updateQuery, conn.getConnection)
        command.Parameters.AddWithValue("@proid", ComboBox1.Text)
        command.Parameters.Add("@proname", MySqlDbType.VarChar).Value = proName.Text
        command.Parameters.Add("@pronum", MySqlDbType.VarChar).Value = number.Text

        conn.Openconnection()

        If command.ExecuteNonQuery() = 1 Then

            MsgBox("修改成功！")
            newload()
            conn.Closeconnection()
            Return

        Else

            MsgBox("修改失敗")
            conn.Closeconnection()
            Return

        End If

    End Sub
    Private Sub newload()

        grv.DataSource = Nothing
        Dim searchQuery As String = "SELECT 商品編號, 商品名稱, 商品數量 FROM 庫存 ORDER BY 商品編號"
        Dim alterQuery As String = " SELECT 商品編號 FROM 庫存"
        Dim conn As New connection()
        Dim table As New DataTable()
        Dim dataSet As New DataSet()
        Dim command As New MySqlCommand(searchQuery, conn.getConnection)
        Dim adapter As New MySqlDataAdapter(command)
        ' command.Parameters.Add("@proID", MySqlDbType.VarChar).Value = proCode.Text

        adapter.Fill(table)
        grv.DataSource = table

        Dim command2 As New MySqlCommand(alterQuery, conn.getConnection)
        Dim table2 As New DataTable()
        Dim adapter2 As New MySqlDataAdapter(command2)

        table.Clear()
        table2.Clear()
        adapter.Fill(table2)
        grv.DataSource = table2

        ComboBox1.DataSource = table2
        ComboBox1.DisplayMember = "商品編號"
        ComboBox1.ValueMember = "商品名稱"

        grv.AutoResizeColumns()
        grv.AutoResizeRows()

    End Sub

End Class