Imports System.Data.SqlClient
Public Class Cuenta_ahorro
    Inherits System.Web.UI.Page

    Dim adaptador As New SqlDataAdapter
    Dim registro As New DataSet
    Dim tabla As New DataTable
    Dim comand As New SqlCommand
    Dim cmd As SqlCommand
    Dim consulta, consulta1 As String
    Dim lista As Byte

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        desconectar()
        conectar()

        txtcufecha.Text = Date.Today
        txtcuapellido_cli.ReadOnly = True
        txtcunombre_cli.ReadOnly = True

        cmbcutipo_cuenta.Items.Add("Ahorro")
        cmbcutipo_cuenta.Items.Add("Corriente")
    End Sub

    Sub limpiar()
        txtcucodigo.Text = ""
        ' txtcucod_cliente.Text = ""
        txtcuid_cliente.Text = ""
        txtcunombre_cli.Text = ""
        txtcuapellido_cli.Text = ""
        txtcuncuenta.Text = ""
        txtcusaldo.Text = ""
        'cmbcutipo_cuenta.Text = cmbcutipo_cuenta.Text = ""
        nuevo()
    End Sub

    '---------------------------------- NUEVO NO UTILIZADO -------------------------------------------
    Sub nuevo()
        Dim otabla As New DataTable

        Try
            consulta1 = "SELECT MAX(codigo) FROM tb_cuenta"
            adaptador = New SqlDataAdapter(consulta1, conexion)
            registro = New DataSet
            adaptador.Fill(registro, "tb_cuenta")
            txtcucodigo.Text = registro.Tables(0).Rows(0).Item(0) + 1
            'txtnombre.Focus()
        Catch ex As Exception
            If otabla.Rows.Count = 0 Then
                txtcucodigo.Text = 1
                ' txtnombre.Focus()
            End If
        End Try

    End Sub
    '-------------------------------------------------------------------------------------------------
    Sub guardar_cuenta()
        If txtcuid_cliente.Text = "" Or txtcuncuenta.Text = "" Or txtcusaldo.Text = "" Then
            Exit Sub
        End If
        If Val(txtcusaldo.Text) >= 50 Then


            Dim comando As New SqlCommand("SELECT * FROM tb_cuenta WHERE ncuenta='" & txtcuncuenta.Text & "' ", conexion)
            Dim dr As SqlDataReader
            dr = comando.ExecuteReader

            If dr.Read Then
                MsgBox("Datos duplicados...", MsgBoxStyle.Information, "Error")
                txtcuid_cliente.Text = ""
                dr.Close()
            Else
                dr.Close()
                Try

                    cmd = New SqlCommand("INSERT INTO tb_cuenta  VALUES(@codigo,@ncuenta,@id_cliente,@tipo,@saldo,@fecha)", conexion)

                    cmd.Parameters.AddWithValue("@codigo", SqlDbType.Int).Value = txtcucodigo.Text
                    cmd.Parameters.AddWithValue("@ncuenta", SqlDbType.VarChar).Value = txtcuncuenta.Text
                    cmd.Parameters.AddWithValue("@id_cliente", SqlDbType.VarChar).Value = txtcuid_cliente.Text
                    cmd.Parameters.AddWithValue("@tipo", SqlDbType.VarChar).Value = cmbcutipo_cuenta.Text
                    cmd.Parameters.AddWithValue("@saldo", SqlDbType.VarChar).Value = txtcusaldo.Text
                    cmd.Parameters.AddWithValue("@fecha", SqlDbType.VarChar).Value = txtcufecha.Text


                    cmd.ExecuteNonQuery()
                    MsgBox("Datos Guadados")

                    limpiar()
                    nuevo()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            End If

        Else
            MsgBox("El bono inicial debe de ser mayor o igual a $ 50")
        End If
    End Sub
    Sub editar_cuenta()
        If txtcuid_cliente.Text = "" Or txtcuncuenta.Text = "" Or txtcusaldo.Text = "" Then
            Exit Sub
        End If
        Try

            cmd = New SqlCommand("UPDATE tb_cuenta SET tipo=" & cmbcutipo_cuenta.Text & ",  saldo=" & txtcusaldo.Text & "  WHERE ncuenta=" & txtcuncuenta.Text & " ", conexion)
            cmd.ExecuteNonQuery()

            MsgBox("Datos Actualizados")
            limpiar()
            nuevo()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub eliminar_cuenta()
        If txtcuid_cliente.Text = "" Or txtcuncuenta.Text = "" Or txtcusaldo.Text = "" Then
            Exit Sub
        End If
        Dim respuesta As Byte
        respuesta = MsgBox("¿Esta seguro que desea eliminar el registro?", vbYesNo, "Eliminar")
        If respuesta = vbYes Then
            cmd = New SqlCommand("DELETE  FROM tb_cuenta WHERE ncuenta=" & txtcuncuenta.Text & "", conexion)
            cmd.ExecuteNonQuery()

            MsgBox("Registro Eliminado")
            limpiar()
            nuevo()
        End If
    End Sub
    Sub buscar_cuenta()
        Try
            Dim buscar As String
            buscar = InputBox("Ingrese el Nº de cuenta completo")
            If buscar <> "" Then
                Dim comando As New SqlCommand("SELECT * FROM tb_cuenta WHERE ncuenta='" & buscar & "' ", conexion)
                Dim dr As SqlDataReader
                dr = comando.ExecuteReader

                If dr.Read Then

                    txtcucodigo.Text = dr(0)
                    txtcuncuenta.Text = dr(1)
                    txtcuid_cliente.Text = dr(2)
                    cmbcutipo_cuenta.Text = dr(3)
                    txtcusaldo.Text = dr(4)
                    txtcufecha.Text = dr(5)

                    dr.Close()
                Else
                    MsgBox("Nº de cuenta invalido", MsgBoxStyle.Exclamation, "Error")
                    dr.Close()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub buscar_cliente()
        Try
            If txtcuid_cliente.Text <> "" Then
                Dim comando As New SqlCommand("SELECT * FROM tb_cliente WHERE cedula='" & txtcuid_cliente.Text & "' ", conexion)
                Dim dr As SqlDataReader
                dr = comando.ExecuteReader

                If dr.Read Then
                    txtcunombre_cli.Text = dr(1)
                    txtcuapellido_cli.Text = dr(2)

                    dr.Close()
                    nuevo()
                Else
                    MsgBox("Nº Cedula invalidad", MsgBoxStyle.Exclamation, "Error")
                    dr.Close()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnguadar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguadar.Click
        guardar_cuenta()
    End Sub

    Protected Sub btneditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btneditar.Click
        editar_cuenta()
    End Sub

    Protected Sub btneliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btneliminar.Click
        eliminar_cuenta()
    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btncancelar.Click
        limpiar()
    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        buscar_cuenta()
    End Sub

    Protected Sub btnbuscar_cliente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar_cliente.Click
        buscar_cliente()
        ' nuevo()
    End Sub

    Protected Sub cmbcutipo_cuenta_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbcutipo_cuenta.SelectedIndexChanged
        If cmbcutipo_cuenta.SelectedIndex = 0 Then
            'txttipo.Text = "Ahorro"
        ElseIf cmbcutipo_cuenta.SelectedIndex = 1 Then
            'txttipo.Text = "Corrient"
        End If

        'If txttipo.Text = "Ahrro" Then
        '    cmbcutipo_cuenta.SelectedIndex = 0
        'ElseIf txttipo.Text = "Corriente" Then
        '    cmbcutipo_cuenta.SelectedIndex = 1
        'End If
    End Sub

    'Protected Sub txttipo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txttipo.TextChanged
    '    If cmbcutipo_cuenta.SelectedIndex = 0 Then
    '        ' txttipo.Text = "Ahorro"
    '    ElseIf cmbcutipo_cuenta.SelectedIndex = 1 Then
    '        ' txttipo.Text = "Corrient"
    '    End If

    '    'If txttipo.Text = "Ahrro" Then
    '    '    cmbcutipo_cuenta.SelectedIndex = 0
    '    'ElseIf txttipo.Text = "Corriente" Then
    '    '    cmbcutipo_cuenta.SelectedIndex = 1
    '    'End If
    'End Sub
End Class