<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pesquisar_Medicamentos.aspx.cs" Inherits="MenuNavegacao_Veterinario_Pesquisar_Pesquisar_Medicamentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Histórico de Medicação</h1>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:TextBox ID="TextBox1" runat="server" Width="293px" ></asp:TextBox>
            </td>
            <td class="auto-style5">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>ID</asp:ListItem>
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
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_ANIMAL,ID_RECEITA,ID_MEDICAMENTO,ID_RECEITA1,ID_MEDICAMENTO1" DataSourceID="SqlDataSource1" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:BoundField DataField="ID_ANIMAL" HeaderText="ANIMAL" ReadOnly="True" SortExpression="ID_ANIMAL" />
            <asp:BoundField DataField="ID_ESPECIE" HeaderText="ESPECIE" SortExpression="ID_ESPECIE" />
            <asp:BoundField DataField="BI_DONO" HeaderText="DONO" SortExpression="BI_DONO" />
            <asp:BoundField DataField="CHIP" HeaderText="CHIP" SortExpression="CHIP" />
            <asp:BoundField DataField="IDADE" HeaderText="IDADE" SortExpression="IDADE" />
            <asp:BoundField DataField="SEXO" HeaderText="SEXO" SortExpression="SEXO" />
            <asp:BoundField DataField="NOME" HeaderText="NOME" SortExpression="NOME" />
            <asp:BoundField DataField="ID_RECEITA" HeaderText="RECEITA" ReadOnly="True" SortExpression="ID_RECEITA" />
            <asp:BoundField DataField="ID_VETERINARIO" HeaderText="VETERINARIO" SortExpression="ID_VETERINARIO" />
            <asp:BoundField DataField="ID_MEDICAMENTO" HeaderText="MEDICAMENTO" ReadOnly="True" SortExpression="ID_MEDICAMENTO" />
            <asp:BoundField DataField="NOME1" HeaderText="NOME MEDICAMENTO" SortExpression="NOME1" />
            <asp:BoundField DataField="Descricao" HeaderText="Descricao" SortExpression="Descricao" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" SelectCommand="SELECT *
        FROM ANIMAL, RECEITAS, TOMA, MEDICAMENTOS
        WHERE ANIMAL.ID_ANIMAL = RECEITAS.ID_ANIMAL
        AND RECEITAS.ID_RECEITA = TOMA.ID_RECEITA
        AND TOMA.ID_MEDICAMENTO = MEDICAMENTOS.ID_MEDICAMENTO
        AND MEDICAMENTOS.ID_MEDICAMENTO = @ID_MED">
        <selectparameters>
              <asp:Parameter name="ID_MED"/>
        </selectparameters>

    </asp:SqlDataSource>
</asp:Content>

