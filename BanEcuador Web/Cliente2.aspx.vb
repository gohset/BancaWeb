Imports System.Data.SqlClient
Public Class Cliente2
    Inherits System.Web.UI.Page

    Dim adaptador As New SqlDataAdapter
    Dim registro As New DataSet
    Dim tabla As New DataTable
    Dim comand As New SqlCommand
    Dim cmd As SqlCommand
    Dim consulta, consulta1 As String
    Dim lista As Byte

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub buscar_cliente()
        Try
            Dim cmd As New SqlCommand("SELECT * FROM tb_cliente WHERE cedula='" & txtcedula.Text & "'", conexion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                txtnombre.Text = dr(1)
                txtapellido.Text = dr(2)
                txtsexo.Text = dr(3)
                txtestado.Text = dr(4)
                txtfechan.Text = dr(5)
                txtdireccion.Text = dr(6)
                txtcorreo.Text = dr(7)
                txtcelular.Text = dr(8)
                txttelefono.Text = dr(9)
                txtpais.Text = dr(10)
                txtprovincia.Text = dr(11)
                txtcanton.Text = dr(12)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
       
    End Sub
    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        buscar_cliente()
    End Sub
End Class