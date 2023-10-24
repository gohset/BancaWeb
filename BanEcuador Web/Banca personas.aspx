<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Banca personas.aspx.vb" Inherits="BanEcuador_Web.Banca_personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 619px;
            height: 553px;
        }
        .style3
        {
            height: 553px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table border="1" width="100%" height="60%">
<tr>
<td class="style2">
<asp:Panel ID="Panel1" runat="server" Font-Size="Large" Height="489px" 
            Width="649px" BackImageUrl="Imagenes/bancapersonas.png" 
            BorderStyle="None" Font-Bold="False">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Realice transacciones de rorma más ágil y segura."></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Por favor digite su Usuario y clave de este servicio."></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Font-Size="X-Large" Text="Usuario" 
                ForeColor="White"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtusuario" runat="server" Width="181px"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
                ID="Label3" runat="server" 
                Font-Size="X-Large" Text="Clave" ForeColor="White"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtpass" runat="server" 
                Width="178px"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="True" 
                Font-Italic="True" ForeColor="White" NavigateUrl="~/Consolidada.aspx">Continuar Click Aqui</asp:HyperLink>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="ImageButton4" runat="server" Height="43px" 
                ImageUrl="Imagenes/boton entrar.png" Width="114px" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </asp:Panel>
    <br />
    <asp:Panel ID="Panel4" runat="server" BackColor="#E693D5" Width="647px">
        <asp:Label ID="Label10" runat="server" Text="Consejos de seguridad" 
            Font-Bold="True" Font-Size="Large"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label11" runat="server" Font-Bold="False" Font-Size="Medium" 
            Text="El Banco NO solicita el ingreso de contraseñas por ningún medio electronico ya sea correo electrónico, chats o teléfono celular."></asp:Label>
    </asp:Panel>
</td>
<td class="style3">
 <!-- ------------------------------------------------------------------------------------------------------------ -->
    <asp:Panel ID="Panel2" runat="server" Width="181px" Height="131px" 
        BackColor="White" BorderColor="#6600CC" BorderStyle="Solid">
        &nbsp;<center>
            <img src="Imagenes/Boton_seguridad.png" align="middle" style="width: 150px; height: 92px" />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Index.aspx">Olvidaste tu contraseña</asp:HyperLink>
        </center>
        </asp:Panel>

    <asp:Panel ID="Panel3" runat="server" Height="131px"  Width="181px" 
        BorderStyle="Solid">
       <center> 
           <img src="Imagenes/nuevo.png" align="middle" style="width: 110px; height: 92px" />
           <br />
           <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Autenticar.aspx">No tienes usario? Click aqui</asp:HyperLink>
        </center>
    </asp:Panel>  

</td>
</tr>
</table>

</asp:Content>
