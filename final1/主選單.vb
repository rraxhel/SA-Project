Public Class 主選單
    Private Sub 查詢進貨資料ToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub 新增進貨資料ToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub 保鮮管理系統ToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub 訂單新增功能ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 訂單新增功能ToolStripMenuItem.Click
        訂單新增.Show()
    End Sub

    Private Sub 訂單查詢功能ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 訂單查詢功能ToolStripMenuItem.Click
        訂單.Show()
    End Sub

    Private Sub 訂單修改功能ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 訂單修改功能ToolStripMenuItem.Click
        訂單修改.Show()
    End Sub

    Private Sub 保鮮管理系統ToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles 保鮮管理系統ToolStripMenuItem.Click
        保鮮.Show()
    End Sub

    Private Sub 新增進貨功能ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新增進貨功能ToolStripMenuItem.Click
        進貨.Show()
    End Sub

    Private Sub 查詢及刪除進貨資料ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 查詢及刪除進貨資料ToolStripMenuItem.Click
        進貨查詢.Show()
    End Sub

    Private Sub Label7_Click_1(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub 查詢存貨資料ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 查詢存貨資料ToolStripMenuItem.Click
        存貨查詢.Show()
    End Sub

    Private Sub 新增和修改存貨資料ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新增和修改存貨資料ToolStripMenuItem.Click
        存貨修改.Show()
    End Sub

    Private Sub 財務管理系統ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 財務管理系統ToolStripMenuItem.Click
        財務.Show()
    End Sub

    Private Sub butExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub 新增商品資料ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        新增商品.Show()
    End Sub

    Private Sub 訂貨系統ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 訂貨系統ToolStripMenuItem.Click
        訂貨.Show()
    End Sub

    Private Sub 主選單_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PictureBox1.BackgroundImage = My.Resources.亮
        delay(0.5)
        PictureBox1.BackgroundImage = My.Resources.暗

    End Sub


    Sub delay(T As Single)
        Dim Start As Integer = Environment.TickCount()
        Dim TimeLast As Integer = T * 1000
        Do
            If Environment.TickCount() - Start > TimeLast Then Exit Do
            Application.DoEvents()
        Loop
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        銷貨.Show()
    End Sub

    Private Sub 新稱商品ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新稱商品ToolStripMenuItem.Click
        新增商品.Show()
    End Sub
End Class