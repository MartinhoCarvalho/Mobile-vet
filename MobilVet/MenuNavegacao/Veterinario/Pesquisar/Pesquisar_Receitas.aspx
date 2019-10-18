<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pesquisar_Receitas.aspx.cs" Inherits="MenuNavegacao_Veterinario_Pesquisar_Pesquisar_Receitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Pesquisar Animais</h1>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:TextBox ID="TextBox1" runat="server" Width="293px"></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Especíe</asp:ListItem>
                    <asp:ListItem>Raça</asp:ListItem>
                    <asp:ListItem>Idade</asp:ListItem>
                    <asp:ListItem>Nome</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style4">
                <asp:Button ID="Button1" runat="server" Text="Pesquisar" OnClick="Button1_Click" />
            </td>
            <td class="auto-style4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Por favor insira um termo a pesquisar." ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID_ANIMAL,ID_ESPECIE1,ID_RACA" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:BoundField DataField="ID_ANIMAL" HeaderText="ID ANIMAL" ReadOnly="True" SortExpression="ID_ANIMAL" />
            <asp:BoundField DataField="NOME" HeaderText="NOME" SortExpression="NOME" />
            <asp:BoundField DataField="IDADE" HeaderText="IDADE" SortExpression="IDADE" />
            <asp:BoundField DataField="CHIP" HeaderText="CHIP" SortExpression="CHIP" />
            <asp:BoundField DataField="BI_DONO" HeaderText="BI DONO" SortExpression="BI_DONO" />
            <asp:BoundField DataField="ID_ESPECIE" HeaderText="ID ESPECIE" SortExpression="ID_ESPECIE" />
            <asp:BoundField DataField="NOME1" HeaderText="NOME ESPECIE" SortExpression="NOME1" />
            <asp:BoundField DataField="SEXO" HeaderText="SEXO" SortExpression="SEXO" />
            <asp:BoundField DataField="ID_RACA" HeaderText="ID RACA" ReadOnly="True" SortExpression="ID_RACA" />
            <asp:BoundField DataField="NOME2" HeaderText="NOME RAÇA" SortExpression="NOME2" />
            <asp:BoundField DataField="PERIGOSO" HeaderText="PERIGOSO" SortExpression="PERIGOSO" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <RowStyle HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" ></asp:SqlDataSource>
</asp:Content>

