Imports System.Data.SqlClient
Public Class Canton
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
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    '---------------------------------- << ..... GENERADOR DE UN NUMERO [NUEVO] EN CUALQUIER TABLA.... >>-------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub generar_nuevo()

        Dim otabla As New DataTable
        Try
            consulta = "SELECT MAX(codigo) FROM tb_canton"
            adaptador = New SqlDataAdapter(consulta, conexion)
            registro = New DataSet
            adaptador.Fill(registro, "tb_canton")
            txtcodigo_c.Text = registro.Tables(0).Rows(0).Item(0) + 1
            ' txtnombre.Focus()
        Catch ex As Exception
            If otabla.Rows.Count = 0 Then
                txtcodigo_c.Text = 1
                ' txtnombre.Focus()
            End If
        End Try

    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '--------------------------------------------------- PROCEDIMIENTO [LIMPIAR] -------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub limpiar_canton()
        txtcodigo_c.Text = ""
        txtnombre_c.Text = ""
        generar_nuevo()
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    '---------------------------------------------<<.. PROCEDIMIENTOS PARA [GUARDAR] DATOS ..>>-----------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub guardar_canton()
        'sonido2()
        If txtcodigo_c.Text = "" Or txtnombre_c.Text = "" Then
            Exit Sub
        End If
        Dim comando As New SqlCommand("SELECT * FROM tb_canton WHERE canton='" & txtnombre_c.Text & "' ", conexion)
        Dim dr As SqlDataReader
        dr = comando.ExecuteReader

        If dr.Read Then
            MsgBox("Datos duplicados...", MsgBoxStyle.Information, "Error")
            txtcodigo_c.Focus()
            dr.Close()
        Else
            dr.Close()
            Try

                Dim cmd As New SqlCommand("INSERT INTO tb_canton VALUES(@codigo,@canton)", conexion)
                cmd.Parameters.AddWithValue("@codigo", SqlDbType.Int).Value = txtcodigo_c.Text
                cmd.Parameters.AddWithValue("@canton", SqlDbType.VarChar).Value = UCase(txtnombre_c.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Datos Guardados con Exito...", MsgBoxStyle.Information, "Guardado")
                txtcodigo_c.Focus()
                limpiar_canton()
                generar_nuevo()
            Catch ex As Exception
                ' MsgBox(ex.ToString)
                'MsgBox("No puede volver a gruadar el mismo dato", MsgBoxStyle.Exclamation, "Error")
                MsgBox("Se le recomienda Actualizar, no Guardar", MsgBoxStyle.Exclamation, "Error")
            End Try
        End If
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    '---------------------------------------------<<.. PROCEDIMIENTOS PARA [EDITAR] DATOS ..>>------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub editar_canton()
        ' sonido2()
        If txtcodigo_c.Text = "" Or txtnombre_c.Text = "" Then
            Exit Sub
        End If
        Try
            Dim cmd As New SqlCommand("UPDATE tb_canton SET canton='" & UCase(txtnombre_c.Text) & "' WHERE codigo=" & txtcodigo_c.Text & "", conexion)
            cmd.ExecuteNonQuery()
            MsgBox("Datos Actualizados correctamente...", MsgBoxStyle.Information, "Actulizar")

            limpiar_canton()
            generar_nuevo()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '--------------------------------------------<<.. PROCEDIMIENTOS PARA [ELIMINAR] DATOS ..>>-----------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub eliminar_canton()
        ' sonido2()
        If txtcodigo_c.Text = "" Or txtnombre_c.Text = "" Then
            Exit Sub
        End If
        respuesta = MsgBox("¿Esta seguro que desea eliminar el registro?", vbYesNo, "Eliminar")
        If respuesta = vbYes Then
            Try
                'eliminar()'Utilizado para optener el Nº elimnado para luego utilizarlo...
                Dim cmd As New SqlCommand("DELETE  FROM tb_canton WHERE codigo=" & txtcodigo_c.Text & "", conexion)
                cmd.ExecuteNonQuery()
                MsgBox("Datos Eliminados con Exito...", MsgBoxStyle.Information, "Eliminado")
                limpiar_canton()
                generar_nuevo()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '---------------------------------------------<<.. PROCEDIMIENTOS PARA [BUSACAR] DATOS ..>>-----------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub buscar_canton()
        'If txtnombre_c.Text = "" Then
        '    Exit Sub
        ' End If
        'sonido2()
        Dim buscar As String
        Dim consulta As String
        Dim lista As Byte
        buscar = InputBox("Ingrese el Cantón")

        If buscar <> "" Then
            consulta = "SELECT * FROM tb_canton WHERE canton like '" & buscar & "%'"
            adaptador = New SqlDataAdapter(consulta, conexion)
            registro = New DataSet
            adaptador.Fill(registro, "tb_canton")

            lista = registro.Tables("tb_canton").Rows.Count
            DataGridView1.Visible = True
        Else
            MsgBox("Ingrese un dato a buscar", , "Error")
            'btnsalirc.Visible = True
        End If
        If lista <> 0 Then
            DataGridView1.DataSource = registro
            DataGridView1.DataBind()
        Else
            ' btnsalirc.Visible = True
        End If
        'GroupBox4.Visible = True
    End Sub

    
    Protected Sub btnguadar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguadar.Click
        guardar_canton()
    End Sub

    Protected Sub btneditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btneditar.Click
        editar_canton()
    End Sub

    Protected Sub btneliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btneliminar.Click
        eliminar_canton()
    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btncancelar.Click
        limpiar_canton()
    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        buscar_canton()
    End Sub

    Protected Sub DataGridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.SelectedIndexChanged
        Dim row As GridViewRow
        row = DataGridView1.SelectedRow
        txtcodigo_c.Text = row.Cells(1).Text
        txtnombre_c.Text = row.Cells(2).Text
        DataGridView1.Visible = False
    End Sub
End Class