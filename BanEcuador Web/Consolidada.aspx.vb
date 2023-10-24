Imports System.Data.SqlClient
Public Class Consolidada
    Inherits System.Web.UI.Page

    Dim cmd As SqlCommand
    Dim adaptador As New SqlDataAdapter
    Dim registro As New DataSet
    Dim consulta As String
    Dim lista As Byte
    Dim respuesta As Byte
    Dim otabla As New DataTable
    Dim nuev As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        desconectar()
        conectar()
        buscar_consolidada()
    End Sub

    Sub buscar_consolidada()

        Dim consulta As String
        Dim lista As Byte
        Try
            consulta = "SELECT * FROM tb_cuenta"
            'consulta = "SELECT * FROM tb_cuenta WHERE ncuenta='" & txtncuanta.Text & "'"
            adaptador = New SqlDataAdapter(consulta, conexion)
            registro = New DataSet
            adaptador.Fill(registro, "tb_cuenta")

            lista = registro.Tables("tb_cuenta").Rows.Count
            DataGridView1.Visible = True

            If lista <> 0 Then
                DataGridView1.DataSource = registro
                DataGridView1.DataBind()
            Else
                ' btnsalirc.Visible = True
            End If
            'GroupBox4.Visible = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

       
    End Sub

End Class