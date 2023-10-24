Imports System.Data.SqlClient
Public Class Pais
    Inherits System.Web.UI.Page

    Dim cmd As SqlCommand
    Dim adaptador As New SqlDataAdapter
    Dim registro As New DataSet
    Dim consulta As String
    Dim lista As Byte
    Dim respuesta As Byte
    Dim otabla As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        desconectar()
        conectar()
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    '---------------------------------- << ..... GENERADOR DE UN NUMERO [NUEVO] EN CUALQUIER TABLA.... >>-------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub generar_nuevo()

        Dim otabla As New DataTable
        Try
            consulta = "SELECT MAX(codigo) FROM tb_pais"
            adaptador = New SqlDataAdapter(consulta, conexion)
            registro = New DataSet
            adaptador.Fill(registro, "tb_pais")
            txtcodigo_p.Text = registro.Tables(0).Rows(0).Item(0) + 1
            ' txtnombre.Focus()
        Catch ex As Exception
            If otabla.Rows.Count = 0 Then
                txtcodigo_p.Text = 1
                ' txtnombre.Focus()
            End If
        End Try

    End Sub
    '--------------------------------------------------------------------------------------------------------------------------
    Sub limpiar_provincia()
        txtcodigo_p.Text = ""
        txtnombre_p.Text = ""
        generar_nuevo()
    End Sub

    Sub guardar_provincia()
        If txtnombre_p.Text = "" Or txtcodigo_p.Text = "" Then
            Exit Sub
        End If
        Dim comando As New SqlCommand("SELECT * FROM tb_pais WHERE pais='" & txtnombre_p.Text & "' ", conexion)
        Dim dr As SqlDataReader
        dr = comando.ExecuteReader

        If dr.Read Then
            MsgBox("Datos duplicados...", MsgBoxStyle.Information, "Error")
            txtcodigo_p.Focus()
            txtnombre_p.Text = ""
            dr.Close()
        Else
            dr.Close()
            Try

                Dim cmd As New SqlCommand("INSERT INTO tb_pais VALUES(@codigo,@pais)", conexion)
                cmd.Parameters.AddWithValue("@codigo", SqlDbType.Int).Value = txtcodigo_p.Text
                cmd.Parameters.AddWithValue("@pais", SqlDbType.VarChar).Value = UCase(txtnombre_p.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Datos Guardados con Exito...", MsgBoxStyle.Information, "Guardado")
                txtcodigo_p.Focus()
                limpiar_provincia()
                generar_nuevo()
            Catch ex As Exception
                ' MsgBox(ex.ToString)
                'MsgBox("No puede volver a gruadar el mismo dato", MsgBoxStyle.Exclamation, "Error")
                MsgBox("Se le recomienda Actualizar, no Guardar", MsgBoxStyle.Exclamation, "Error")
            End Try
        End If
    End Sub
    Sub editar_provincia()
        If txtcodigo_p.Text = "" Or txtnombre_p.Text = "" Then
            Exit Sub
        End If
        Try
            Dim cmd As New SqlCommand("UPDATE tb_pais SET pais='" & UCase(txtnombre_p.Text) & "' WHERE codigo=" & txtcodigo_p.Text & "", conexion)
            cmd.ExecuteNonQuery()
            MsgBox("Datos Actualizados correctamente...", MsgBoxStyle.Information, "Actulizar")

            limpiar_provincia()
            generar_nuevo()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub eliminar_provincia()
        ' Dim respuesta As Byte
        If txtcodigo_p.Text = "" Or txtnombre_p.Text = "" Then
            Exit Sub
        End If
        respuesta = MsgBox("¿Esta seguro que desea eliminar el registro?", vbYesNo, "Eliminar")
        If respuesta = vbYes Then
            ' eliminar()
            Dim cmd As New SqlCommand("DELETE  FROM tb_pais WHERE codigo=" & txtcodigo_p.Text & "", conexion)
            cmd.ExecuteNonQuery()
            MsgBox("Datos Eliminados con Exito...", MsgBoxStyle.Information, "Eliminado")
            limpiar_provincia()
            generar_nuevo()
        End If
    End Sub
    Sub buscar_provinvia()
        Dim buscar As String
        Dim consulta As String
        Dim lista As Byte
        buscar = InputBox("Ingrese el País")

        If buscar <> "" Then
            consulta = "SELECT * FROM tb_pais WHERE pais like '" & buscar & "%'"
            adaptador = New SqlDataAdapter(consulta, conexion)
            registro = New DataSet
            adaptador.Fill(registro, "tb_pais")

            lista = registro.Tables("tb_pais").Rows.Count
            DataGridView1.Visible = True
        Else
            MsgBox("Ingrese un dato a buscar", , "Error")
            'btnsalirp.Visible = True
        End If
        If lista <> 0 Then
            DataGridView1.DataSource = registro
            DataGridView1.DataBind()
        Else
            ' btnsalirp.Visible = True
        End If
        'GroupBox6.Visible = True
    End Sub


    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click
        guardar_provincia()
    End Sub

    Protected Sub btneditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btneditar.Click
        editar_provincia()
    End Sub

    Protected Sub btneliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btneliminar.Click
        eliminar_provincia()
    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btncancelar.Click
        limpiar_provincia()
    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        buscar_provinvia()
    End Sub
    Protected Sub DataGridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.SelectedIndexChanged
        Dim row As GridViewRow
        row = DataGridView1.SelectedRow
        txtcodigo_p.Text = row.Cells(1).Text
        txtnombre_p.Text = row.Cells(2).Text
        DataGridView1.Visible = False
    End Sub
End Class