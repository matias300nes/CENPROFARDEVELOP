Public Class frmConceptos_old
    Private Sub frmConceptos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        centrarForm()
    End Sub

    Private Sub configurarform()
        Me.Text = "Farmacias"

        Me.grd.Location = New Size(GroupPanel1.Location.X, GroupPanel1.Location.Y + GroupPanel1.Size.Height + 7)

        'Me.Size = New Size(IIf(Me.Size.Width <= AnchoMinimoForm, AnchoMinimoForm, Me.Size.Width), Me.grd.Location.Y + Me.grd.Size.Height + 65)
        Me.Size = New Size(Me.Size.Width, (Screen.PrimaryScreen.WorkingArea.Height - 65))
        '65-7-65
        Dim p As New Size(GroupPanel1.Size.Width, Me.Size.Height - 7 - GroupPanel1.Size.Height - GroupPanel1.Location.Y - 65)
        Me.grd.Size = New Size(p)



        Me.Top = 0
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) \ 2

    End Sub

    Private Sub centrarForm()

        Dim Ancho_pantalla As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim Alto_pantalla As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim ancho As Integer = Ancho_pantalla - Me.Width
        Dim alto As Integer = Alto_pantalla - Me.Height
        Me.Location = New Point(ancho \ 2, alto \ 2)
    End Sub
End Class