<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site2.Master" CodeBehind="Corte_estado.aspx.vb" Inherits="BanEcuador_Web.Corte_estado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Large" 
    ForeColor="Black" Text="ID"></asp:Label>
<asp:TextBox ID="txtid" runat="server"></asp:TextBox>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table style="height: 321px; width: 97%;">
<tr>
<td background="imagenes/formulario1.png" whidth="100%">
<center>
    <br />
    <br />
    <br />
    <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                Text="Corte de Estado de cuenta" ForeColor="White"></asp:Label>
            <br />
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
        ForeColor="White" Text="Nº cuenta"></asp:Label>
&nbsp;&nbsp;
    <asp:TextBox ID="txtncuenta" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" 
        ForeColor="White" Text="Fecha"></asp:Label>
&nbsp;&nbsp;
    <asp:TextBox ID="txtfecha" runat="server"></asp:TextBox>
        <asp:ImageButton ID="btnbuscar" runat="server" Height="39px" 
            ImageUrl="Imagenes/btnbuscar.png" Width="105px" BorderStyle="None" 
        ImageAlign="Middle" />
            <br />
    <asp:GridView ID="DataGridView1" runat="server" BackColor="#DEBA84" 
        BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        CellSpacing="2" Width="565px">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    </center>
</td>
</tr>
</table>
</asp:Content>
