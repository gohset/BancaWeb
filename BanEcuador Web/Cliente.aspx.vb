Imports System.Data.SqlClient
Public Class Cliente
    Inherits System.Web.UI.Page

    Dim adaptador As New SqlDataAdapter
    Dim registro As New DataSet
    Dim tabla As New DataTable
    Dim comand As New SqlCommand
    Dim cmd As SqlCommand
    Dim consulta, consulta1 As String
    Dim lista As Byte

    Dim a = 1949, m = 0, d = 0, cont = 0
    Dim n As Integer
    Dim seta As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        desconectar()
        conectar()
        n = New Date().Year
        cmbsexo.Items.Add("Masculino")
        cmbsexo.Items.Add("Femenino")

        cmbestado.Items.Add("Soltero")
        cmbestado.Items.Add("Casado")
        cmbestado.Items.Add("Diborciado")
        cmbestado.Items.Add("Viudo")

        btncalendario2.Visible = False

        cmbaño.Visible = False
        cmbmes.Visible = False
        cmbdias.Visible = False

        lblaño.Visible = False
        lblmes.Visible = False
        lbldias.Visible = False

        While (a <= 2020)
            a = a + 1
            cmbaño.Items.Add(a)
        End While

        While (m < 12)

            m = m + 1
            cmbmes.Items.Add(m)
        End While

        While (d < 31)
            d = d + 1
            cmbdias.Items.Add(d)
        End While

        '  n = Request.Params("parametro")
        'txt1.Text = n
    End Sub

    Sub limpiar()

        txtcedula.Text = ""

        txtnombre.Text = ""
        txtapellido.Text = ""
        txtfechan.Text = ""
        cmbsexo.SelectedIndex = 0
        cmbestado.SelectedIndex = 0
        txtdireccion.Text = ""
        cmbpais.SelectedIndex = 0
        cmbprovincia.SelectedIndex = 0
        cmbcanton.SelectedIndex = 0
        txtcorreo.Text = ""
        txtcelular.Text = ""
        txttelefono.Text = ""

        txtcedula.Focus()

    End Sub
    '---------------------------------- NUEVO NO UTILIZADO -------------------------------------------
    Sub nuevo()
        Dim otabla As New DataTable

        Try
            consulta1 = "SELECT MAX(cedula) FROM tb_cliente"
            adaptador = New SqlDataAdapter(consulta1, conexion)
            registro = New DataSet
            adaptador.Fill(registro, "tb_cliente")
            'txtcedula.Text = registro.Tables(0).Rows(0).Item(0) + 1
            txtnombre.Focus()
        Catch ex As Exception
            If otabla.Rows.Count = 0 Then
                'txtcedula.Text = 1
                txtnombre.Focus()
            End If
        End Try

    End Sub
    '-------------------------------------------------------------------------------------------------
    Sub guardar_cliente()
        If txtcedula.Text = "" Or txtnombre.Text = "" Or txtapellido.Text = "" Or txtcelular.Text = "" Then
            Exit Sub
        End If
        Dim comando As New SqlCommand("SELECT * FROM tb_CLIENTE WHERE cedula='" & txtcedula.Text & "' ", conexion)
        Dim dr As SqlDataReader
        dr = comando.ExecuteReader

        If dr.Read Then
            MsgBox("Datos duplicados...", MsgBoxStyle.Information, "Error")
            txtcedula.Text = ""
            dr.Close()
        Else
            dr.Close()
            Try

                cmd = New SqlCommand("INSERT INTO TB_CLIENTE  VALUES(@cedula,@nombre,@apellido,@sexo,@civil,@edad,@direccion,@correo,@celular,@telefono,@pais,@provincia,@canton)", conexion)

                cmd.Parameters.AddWithValue("@cedula", SqlDbType.Int).Value = txtcedula.Text
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = txtnombre.Text
                cmd.Parameters.AddWithValue("@apellido", SqlDbType.VarChar).Value = txtapellido.Text
                cmd.Parameters.AddWithValue("@sexo", SqlDbType.Int).Value = cmbsexo.Text
                cmd.Parameters.AddWithValue("@civil", SqlDbType.Int).Value = cmbestado.Text
                cmd.Parameters.AddWithValue("@edad", SqlDbType.VarChar).Value = txtfechan.Text
                cmd.Parameters.AddWithValue("@direccion", SqlDbType.VarChar).Value = txtdireccion.Text
                cmd.Parameters.AddWithValue("@correo", SqlDbType.VarChar).Value = txtcorreo.Text
                cmd.Parameters.AddWithValue("@celular", SqlDbType.VarChar).Value = txtcelular.Text
                cmd.Parameters.AddWithValue("@telefono", SqlDbType.VarChar).Value = txttelefono.Text
                cmd.Parameters.AddWithValue("@pais", SqlDbType.Int).Value = cmbpais.Text
                cmd.Parameters.AddWithValue("@provincia", SqlDbType.Int).Value = cmbprovincia.Text
                cmd.Parameters.AddWithValue("@canton", SqlDbType.Int).Value = cmbcanton.Text

                cmd.ExecuteNonQuery()
                MsgBox("Datos Guadados")

                limpiar()
                'nuevo()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub
    Sub editar_cliente()
        If txtcedula.Text = "" Or txtnombre.Text = "" Or txtapellido.Text = "" Or txtcelular.Text = "" Then
            Exit Sub
        End If
        Try

            cmd = New SqlCommand("UPDATE TB_CLIENTE SET nombre='" & UCase(txtnombre.Text) & "', apellido='" & UCase(txtapellido.Text) & "',  sexo=" & cmbsexo.Text & ",civil=" & cmbestado.Text & ",edad= '" & txtfechan.Text & "', direccion= '" & txtdireccion.Text & "', correo='" & txtcorreo.Text & "', celular='" & txtcelular.Text & "', telefono='" & txttelefono.Text & "' pais=" & cmbpais.Text & ", provincia=" & cmbprovincia.Text & ", canton=" & cmbcanton.Text & "  WHERE cedula=" & txtcedula.Text & " ", conexion)
            cmd.ExecuteNonQuery()

            MsgBox("Datos Actualizados")
            limpiar()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub eliminar_cliente()
        If txtcedula.Text = "" Or txtnombre.Text = "" Or txtapellido.Text = "" Or txtcelular.Text = "" Then
            Exit Sub
        End If
        Dim respuesta As Byte
        respuesta = MsgBox("¿Esta seguro que desea eliminar el registro?", vbYesNo, "Eliminar")
        If respuesta = vbYes Then
            cmd = New SqlCommand("DELETE  FROM tb_cliente WHERE cedula=" & txtcedula.Text & "", conexion)
            cmd.ExecuteNonQuery()

            MsgBox("Registro Eliminado")
            limpiar()
        End If
    End Sub
    Sub buscar_cliente()
        Dim buscar As String
        Dim consulta As String
        Dim lista As Byte
        buscar = InputBox("Ingrese la Cedula(Id)")

        If buscar <> "" Then
            consulta = "SELECT * FROM tb_cliente WHERE cedula='" & buscar & "'"
            adaptador = New SqlDataAdapter(consulta, conexion)
            registro = New DataSet
            adaptador.Fill(registro, "tb_cliente")

            DataGridView1.Visible = True
            lista = registro.Tables("tb_cliente").Rows.Count

        Else
            MsgBox("Ingrese un dato a buscar", , "Error")
            ' btnsalir.Visible = True
        End If
        If lista <> 0 Then
            DataGridView1.DataSource = registro
            DataGridView1.DataBind()
        Else
            ' btnsalir.Visible = True
        End If
        ' GroupBox1.Visible = True
    End Sub

    
    Protected Sub btnguardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnguardar.Click
        guardar_cliente()
    End Sub

    Protected Sub btneditar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btneditar.Click
        editar_cliente()
    End Sub

    Protected Sub btneliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btneliminar.Click
        eliminar_cliente()
    End Sub

    Protected Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btncancelar.Click
        limpiar()
    End Sub

    Protected Sub cmbaño_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbaño.SelectedIndexChanged
        txtfechan.Text = Date.Now.Year - Val(cmbaño.Text)
    End Sub

    Protected Sub DataGridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.SelectedIndexChanged
        Dim row As GridViewRow
        row = DataGridView1.SelectedRow

        txtcedula.Text = row.Cells(1).Text
        txtnombre.Text = row.Cells(2).Text
        txtapellido.Text = row.Cells(3).Text
        cmbsexo.Text = row.Cells(4).Text
        cmbestado.Text = row.Cells(5).Text
        txtfechan.Text = row.Cells(6).Text
        txtdireccion.Text = row.Cells(7).Text
        txtcorreo.Text = row.Cells(8).Text
        txtcelular.Text = row.Cells(9).Text
        txttelefono.Text = row.Cells(10).Text
        cmbpais.Text = row.Cells(11).Text
        cmbprovincia.Text = row.Cells(12).Text
        cmbcanton.Text = row.Cells(13).Text


        'cmbtipo_licencia.SelectedIndex = Val(txt_tlicencia.Text) - 1
        'cmbgenero.SelectedIndex = Val(txtgenero.Text) - 1
        'cmbpais.SelectedIndex = Val(txtpais.Text) - 1
        'cmbcanton.SelectedIndex = Val(txtcanton.Text) - 1
        'cmbprovincia.SelectedIndex = Val(txtprovincia.Text) - 1

        DataGridView1.Visible = False
    End Sub

    Protected Sub txtfechan_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtfechan.TextChanged
        txtfechan.Text = Date.Now.Year - Val(cmbaño.Text)
    End Sub


    Protected Sub btncalendario2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btncalendario2.Click
        txtfechan.Text = Date.Now.Year - Val(cmbaño.Text)
        cmbaño.Visible = False
        cmbmes.Visible = False
        cmbdias.Visible = False

        lblaño.Visible = False
        lblmes.Visible = False
        lbldias.Visible = False

        btncalendario1.Visible = True
        btncalendario2.Visible = False
    End Sub

    Protected Sub btncalendario1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btncalendario1.Click
        cmbaño.Visible = True
        cmbmes.Visible = True
        cmbdias.Visible = True

        lblaño.Visible = True
        lblmes.Visible = True
        lbldias.Visible = True

        btncalendario2.Visible = True
        btncalendario1.Visible = False
    End Sub

   
    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnbuscar.Click
        buscar_cliente()
    End Sub
End Class