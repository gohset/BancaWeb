<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site2.Master" CodeBehind="Consolidada.aspx.vb" Inherits="BanEcuador_Web.Consolidada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                Text="Posición Consolidado(a)" ForeColor="White"></asp:Label>
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
<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <asp:Label ID="Label1" runat="server" Text="Nº Cuenta"></asp:Label>
&nbsp;
<asp:TextBox ID="txtncuanta" runat="server"></asp:TextBox>
</asp:Content>

