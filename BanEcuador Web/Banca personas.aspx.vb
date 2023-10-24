Imports System.Data.SqlClient
Public Class Banca_personas
    Inherits System.Web.UI.Page

    Dim total, total2 As Double

    Dim adaptador As New SqlDataAdapter
    Dim registro As New DataSet
    Dim tabla As New DataTable
    Dim comand As New SqlCommand
    Dim cmd As SqlCommand
    Dim consulta, consulta1, z As String
    Dim lista As Byte
    Dim con1, con2 As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        desconectar()
        conectar()

        HyperLink3.Visible = False
        txtusuario.Visible = True
        txtpass.Visible = True
        ImageButton4.Visible = True
        Label2.Visible = True
        Label3.Visible = True

        ' Label4.ForeColor = Drawing.Color.White
        Label2.ForeColor = Drawing.Color.White
        Label3.ForeColor = Drawing.Color.White

        Label8.ForeColor = Drawing.Color.CadetBlue
        Label9.ForeColor = Drawing.Color.CadetBlue

        Panel2.BorderStyle = BorderStyle.Solid
        Panel3.BorderStyle = BorderStyle.Solid

        Panel2.BorderColor = Drawing.Color.CadetBlue
        Panel3.BorderColor = Drawing.Color.CadetBlue

        Panel4.BackColor = Drawing.Color.Gray
    End Sub

    Sub buscar_usuario()
        Try
            If txtusuario.Text <> "" Then
                Dim comando As New SqlCommand("SELECT * FROM tb_usuario WHERE usuario='" & txtusuario.Text & "' and pass='" & txtpass.Text & "' ", conexion)
                Dim dr As SqlDataReader
                dr = comando.ExecuteReader

                If dr.Read Then
                    MsgBox("Bienvenidos a BanEcuador", MsgBoxStyle.Information)
                    dr.Close()

                    HyperLink3.Visible = True
                    txtusuario.Visible = False
                    txtpass.Visible = False
                    ImageButton4.Visible = False
                    Label2.Visible = False
                    Label3.Visible = False
                Else
                    MsgBox("Error de usuario y contraseña", MsgBoxStyle.Exclamation, "Error")
                    dr.Close()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ImageButton4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton4.Click
        buscar_usuario()
    End Sub
End Class