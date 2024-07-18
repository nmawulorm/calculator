Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each button As Button In fPnlNumbers.Controls
            AddHandler button.Click, AddressOf AddNumberToDisplay
        Next

        For Each button As Button In fPnlOperators.Controls
            AddHandler button.Click, AddressOf AddOperation
        Next
    End Sub

    Private Sub AddNumberToDisplay(sender As Button, e As EventArgs)
        Dim text = sender.Text
        Dim display = txtDisplay.Text
        If Not (text = "." And display.Contains(".")) Then
            txtDisplay.Text += text
        End If
    End Sub

    Private Sub AddOperation(sender As Button, e As EventArgs)
        Dim text = sender.Text
        If txtDisplay.Text = "" And (text = "+" Or text = "-") Then
            txtDisplay.Text = text
        ElseIf lblOperation.Text = "" Then
            lblAnswer.Text = txtDisplay.Text
            lblOperation.Text = text
            txtDisplay.Clear()
        Else
            lblOperation.Text = text
            txtDisplay.Clear()
            Calculate()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtDisplay.Clear()
        lblAnswer.Text = ""
        lblOperation.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteDisplay()
    End Sub

    Private Sub DeleteDisplay()
        Dim display = txtDisplay.Text
        If display IsNot "" Then
            txtDisplay.Text = display.Remove(display.Length - 1)
        Else
            Dim operation = lblOperation.Text
            If operation IsNot "" Then
                lblOperation.Text = operation.Remove(operation.Length - 1)
            End If
        End If
    End Sub

    Private Sub btnEquals_Click(sender As Object, e As EventArgs) Handles btnEquals.Click
        If lblAnswer.Text = "" Then
            lblAnswer.Text = txtDisplay.Text
            txtDisplay.Clear()
        Else
            Calculate()
        End If
    End Sub

    Private Sub Calculate()
        Dim operation = lblOperation.Text
        Dim answer = lblAnswer.Text
        Dim display = Val(txtDisplay.Text)
        Try
            Select Case operation
                Case "/"
                    lblAnswer.Text /= display
                Case "-"
                    lblAnswer.Text -= display
                Case "x"
                    lblAnswer.Text *= display
                Case Else
                    lblAnswer.Text += display
            End Select
        Catch ex As Exception
            lblAnswer.Text = "Error!"
        End Try
        txtDisplay.Clear()
        lblOperation.Text = ""

    End Sub
End Class
