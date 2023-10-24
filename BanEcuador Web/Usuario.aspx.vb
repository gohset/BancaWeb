Imports System.Data.SqlClient
Public Class Usuario
    Inherits System.Web.UI.Page

    Dim cmd As SqlCommand
    Dim adaptador As New SqlDataAdapter
    Dim registro As New DataSet
    Dim consulta As String
    Dim lista As Byte
    Dim respuesta As Byte
    Dim otabla As New DataTable
    Dim nuev As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load, CheckBox1.CheckedChanged
        desconectar()
        conectar()

    End Sub

    Sub limpiar()
        txtid.Text = ""
        txtusuario.Text = ""
        txtclave1.Text = ""
        txtclave2.Text = ""
    End Sub
    Sub guardar_usuario()
        If txtid.Text = "" Or txtusuario.Text = "" Or txtclave1.Text = "" Or txtclave2.Text = "" Then
            Exit Sub
        End If

        '------------------------------------------------------------------------------------------------
        Dim seta As New SqlCommand("SELECT * FROM tb_cliente WHERE cedula='" & txtid.Text & "' ", conexion)
        Dim dr As SqlDataReader
        dr = seta.ExecuteReader

        If dr.Read Then
            If txtclave1.Text = txtclave2.Text Then
                dr.Close()
                Dim comando As New SqlCommand("SELECT * FROM tb_usuario WHERE usuario='" & txtusuario.Text & "' ", conexion)
                Dim dr2 As SqlDataReader
                dr2 = comando.ExecuteReader

                If dr2.Read Then
                    MsgBox("Usuario ya registrado", MsgBoxStyle.Information, "Error")
                    txtusuario.Text = ""
                    dr2.Close()
                Else
                    dr2.Close()
                    Try

                        cmd = New SqlCommand("INSERT INTO tb_usuario  VALUES(@cedula,@usuario,@pass)", conexion)

                        cmd.Parameters.AddWithValue("@cedula", SqlDbType.VarChar).Value = txtid.Text
                        cmd.Parameters.AddWithValue("@usuario", SqlDbType.VarChar).Value = txtusuario.Text
                        cmd.Parameters.AddWithValue("@pass", SqlDbType.VarChar).Value = txtclave1.Text

                        cmd.ExecuteNonQuery()
                        MsgBox("Datos Guadados", MsgBoxStyle.Information)

                        limpiar()
                        'nuevo()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Else
                MsgBox("Las claves no coinciden", MsgBoxStyle.Information, "Error")

            End If
        Else
            dr.Close()
            MsgBox("El numero de identificacion (id) no esta registrado", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        If CheckBox1.Checked = False Then
            btnenviar1.Enabled = True
        Else
            btnenviar1.Enabled = False
        End If
    End Sub

    Protected Sub btnenviar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnenviar1.Click
        If CheckBox1.Checked = True Then
            guardar_usuario()
        Else
            MsgBox("Acepte los terminos y condiciones", MsgBoxStyle.Information, "Aceptar terminos")
        End If
    End Sub
End Class