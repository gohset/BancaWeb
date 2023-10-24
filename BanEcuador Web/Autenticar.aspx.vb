Imports System.Data.SqlClient
Public Class Autenticar
    Inherits System.Web.UI.Page
    Dim clave As String
    Dim seguir As Byte

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
        btnsigiente.Visible = False
        btnsigiente1.Visible = False
        txtcodigo.Visible = False
        Label5.Visible = False
        Label4.Visible = False
    End Sub

    Protected Sub btnenviar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnenviar1.Click

        If txtcedula.Text = "" Or txtcorreo.Text = "" Then
            Exit Sub
        End If
        Dim comando As New SqlCommand("SELECT * FROM tb_cuenta WHERE id_cliente='" & txtcedula.Text & "' ", conexion)
        Dim dr As SqlDataReader
        dr = comando.ExecuteReader

        If dr.Read Then
            btnsigiente.Visible = True
            txtcodigo.Visible = True
            Label4.Visible = True
            Label5.Visible = True
            MsgBox("Se le a enviado a su correo un codigo de confimación <<< CÓDIGO : [seta77]", MsgBoxStyle.Information, "Ingresar código")
            dr.Close()
        Else
            MsgBox("No tiene una cuenta bancaria para crear Usuario para gestionar una aserquese a uno de nuestros locales mas sercanos", MsgBoxStyle.Information, "Ingresar código")
            dr.Close()

        End If
    End Sub

    Protected Sub btnsigiente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnsigiente.Click
        clave = "seta77"
        If (txtcodigo.Text = clave) Then

            seguir = CByte(MsgBox("Desea continuar", vbYesNo, "Error"))
            If (seguir = vbYes) Then
                btnsigiente.Visible = False
                btnsigiente1.Visible = True
            Else

            End If
            'btnsigiente.PostBackUrl = "~/Cliente.aspx"
            'Response.Redirect("cliente.aspx?parametro=" + txtcodigo.Text)
        Else
            MsgBox("El codigo ingresado es incorrecto", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub

   

End Class