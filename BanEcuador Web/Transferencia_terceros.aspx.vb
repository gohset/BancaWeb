Imports System.Data.SqlClient
Public Class Transferencia_terceros
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
        txtid.Visible = False
        'cmbtipo.Items.Add("Ahorro")
        'cmbtipo.Items.Add("Corriente")
    End Sub

    Sub buscar_cliente1()
        Try
            If txtcuenta_devito.Text <> "" Then
                Dim comando As New SqlCommand("SELECT * FROM tb_cuenta WHERE ncuenta='" & txtcuenta_devito.Text & "' ", conexion)
                Dim dr As SqlDataReader
                dr = comando.ExecuteReader

                If dr.Read Then

                    ' z = dr(2)
                    txtid.Text = dr(2)
                    resto1.Text = dr(4)
                    con1 = dr(4)

                    dr.Close()
                    buscar_cliente1_1()
                    buscar_cliente2()
                    nuevo()
                Else
                    MsgBox("Nº Cuenta invalida", MsgBoxStyle.Exclamation, "Error")
                    dr.Close()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub buscar_cliente1_1()
        Try
            If txtcuenta_devito.Text <> "" Then
                Dim comando As New SqlCommand("SELECT * FROM tb_cuenta WHERE ncuenta='" & txtcuenta_acreditar.Text & "' ", conexion)
                Dim dr As SqlDataReader
                dr = comando.ExecuteReader

                If dr.Read Then

                    z = dr(2)
                    'txtid.Text = dr(2)
                    resto2.Text = dr(4)
                    con2 = dr(4)

                    dr.Close()

                    buscar_cliente2()
                Else
                    MsgBox("Nº Cuenta invalida", MsgBoxStyle.Exclamation, "Error")
                    dr.Close()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub buscar_cliente2()
        Try
            If txtcuenta_acreditar.Text <> "" Then
                Dim comando As New SqlCommand("SELECT * FROM tb_cliente WHERE cedula='" & z & "' ", conexion)
                Dim dr As SqlDataReader
                dr = comando.ExecuteReader

                If dr.Read Then


                    txtnombre.Text = dr(1)
                    txtemail_cre.Text = dr(7)


                    dr.Close()

                Else
                    MsgBox("Nº Cedula invalidad", MsgBoxStyle.Exclamation, "Error")
                    dr.Close()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub nuevo()
        Dim otabla As New DataTable

        Try
            consulta1 = "SELECT MAX(codigo) FROM tb_transferencia"
            adaptador = New SqlDataAdapter(consulta1, conexion)
            registro = New DataSet
            adaptador.Fill(registro, "tb_transferencia")
            txtcodigo0.Text = registro.Tables(0).Rows(0).Item(0) + 1
            txtnombre.Focus()
        Catch ex As Exception
            If otabla.Rows.Count = 0 Then
                txtcodigo0.Text = 1
                txtnombre.Focus()
            End If
        End Try

    End Sub

    Sub limpiar()
        txtcodigo0.Text = ""
        txtconsepto.Text = ""
        txtcuenta_acreditar.Text = ""
        txtcuenta_devito.Text = ""
        txtemail_cre.Text = ""
        txtemail_dev.Text = ""
        txtid.Text = ""
        txtnombre.Text = ""
        txtvalor.Text = ""
        cmbtipo.SelectedIndex = 0


    End Sub
    Sub guardar_transferencia()
        If txtcuenta_acreditar.Text = "" Or txtcuenta_devito.Text = "" Or txtvalor.Text = "" Then
            Exit Sub
        End If


        If Val(txtvalor.Text) > Val(resto1.Text) Then
            MsgBox("No cuenta con saldo suficiente para realizar la transacción", MsgBoxStyle.Information, "Atención")
        Else
            total = Val(resto1.Text) - Val(txtvalor.Text)
            total2 = Val(resto2.Text) + Val(txtvalor.Text)
            txttotal.Text = total

            Try

                cmd = New SqlCommand("INSERT INTO tb_transferencia  VALUES(@codigo,@cuenta_d,@cuenta_a,@concepto,@tipo_cuenta,@nombre_a,@email_a,@email_d,@valor)", conexion)

                cmd.Parameters.AddWithValue("@codigo", SqlDbType.Int).Value = txtcodigo0.Text
                cmd.Parameters.AddWithValue("@cuenta_d", SqlDbType.VarChar).Value = txtcuenta_devito.Text
                cmd.Parameters.AddWithValue("@cuenta_a", SqlDbType.VarChar).Value = txtcuenta_acreditar.Text
                cmd.Parameters.AddWithValue("@concepto", SqlDbType.VarChar).Value = txtconsepto.Text
                cmd.Parameters.AddWithValue("@tipo_cuenta", SqlDbType.VarChar).Value = cmbtipo.Text
                cmd.Parameters.AddWithValue("@nombre_a", SqlDbType.VarChar).Value = txtnombre.Text
                cmd.Parameters.AddWithValue("@email_a", SqlDbType.VarChar).Value = txtemail_cre.Text
                cmd.Parameters.AddWithValue("@email_d", SqlDbType.VarChar).Value = txtemail_dev.Text
                cmd.Parameters.AddWithValue("@valor", SqlDbType.VarChar).Value = txtvalor.Text

                cmd.ExecuteNonQuery()
                MsgBox("Transacción realizada exitosamente", MsgBoxStyle.Information, "Correcto")
                editar_cuenta()
                ' editar_cuenta_d()
                limpiar()
                nuevo()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub
    Sub editar_cuenta()
        If txtcuenta_acreditar.Text = "" Or txtcuenta_devito.Text = "" Then
            Exit Sub
        End If
        Try

            cmd = New SqlCommand("UPDATE tb_cuenta SET saldo='" & total & "'  WHERE ncuenta=" & txtcuenta_devito.Text & " ", conexion)
            cmd.ExecuteNonQuery()

            ' MsgBox("Datos Actualizados")
            editar_cuenta_d()
            limpiar()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub editar_cuenta_d()
        If txtcuenta_acreditar.Text = "" Or txtcuenta_devito.Text = "" Then
            Exit Sub
        End If
        Try

            cmd = New SqlCommand("UPDATE tb_cuenta SET saldo='" & total2 & "'  WHERE ncuenta=" & txtcuenta_acreditar.Text & " ", conexion)
            cmd.ExecuteNonQuery()

            ' MsgBox("Datos  Acreditado")
            limpiar()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        buscar_cliente1()
        buscar_cliente1_1()
        buscar_cliente2()
    End Sub

    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click
        guardar_transferencia()
    End Sub
End Class