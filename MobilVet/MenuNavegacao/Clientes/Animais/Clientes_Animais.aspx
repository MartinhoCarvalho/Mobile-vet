<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeFile="Clientes_Animais.aspx.cs" Inherits="MenuNavegacao_Clientes_Clientes_ListarAnimais" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <br />
    &nbsp;Tabela dos seus animais<br />

    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID_ANIMAL" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="None" Width="242px">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:BoundField DataField="ID_ANIMAL" HeaderText="ID_ANIMAL" ReadOnly="True" SortExpression="ID_ANIMAL" />
            <asp:BoundField DataField="ID_ESPECIE" HeaderText="ID_ESPECIE" SortExpression="ID_ESPECIE" />
            <asp:BoundField DataField="BI_DONO" HeaderText="BI_DONO" SortExpression="BI_DONO" />
            <asp:BoundField DataField="CHIP" HeaderText="CHIP" SortExpression="CHIP" />
            <asp:BoundField DataField="IDADE" HeaderText="IDADE" SortExpression="IDADE" />
            <asp:BoundField DataField="SEXO" HeaderText="SEXO" SortExpression="SEXO" />
            <asp:BoundField DataField="NOME" HeaderText="NOME" SortExpression="NOME" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle ForeColor="DarkSlateBlue" HorizontalAlign="Center" BackColor="PaleGoldenrod" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" DeleteCommand="DELETE FROM [ANIMAL] WHERE [ID_ANIMAL] = @ID_ANIMAL" InsertCommand="INSERT INTO [ANIMAL] ([ID_ANIMAL], [ID_ESPECIE], [BI_DONO], [CHIP], [IDADE], [SEXO], [NOME]) VALUES (@ID_ANIMAL, @ID_ESPECIE, @BI_DONO, @CHIP, @IDADE, @SEXO, @NOME)" SelectCommand="SELECT * FROM [ANIMAL] WHERE ([BI_DONO] = @BI_DONO)" UpdateCommand="UPDATE [ANIMAL] SET [ID_ESPECIE] = @ID_ESPECIE, [BI_DONO] = @BI_DONO, [CHIP] = @CHIP, [IDADE] = @IDADE, [SEXO] = @SEXO, [NOME] = @NOME WHERE [ID_ANIMAL] = @ID_ANIMAL">
        <DeleteParameters>
            <asp:Parameter Name="ID_ANIMAL" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ID_ANIMAL" Type="Decimal" />
            <asp:Parameter Name="ID_ESPECIE" Type="Decimal" />
            <asp:Parameter Name="BI_DONO" Type="Decimal" />
            <asp:Parameter Name="CHIP" Type="Decimal" />
            <asp:Parameter Name="IDADE" Type="Int32" />
            <asp:Parameter Name="SEXO" Type="String" />
            <asp:Parameter Name="NOME" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter Name="BI_DONO" Type="Int32" DefaultValue="Anonymous" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="ID_ESPECIE" Type="Decimal" />
            <asp:Parameter Name="BI_DONO" Type="Decimal" />
            <asp:Parameter Name="CHIP" Type="Decimal" />
            <asp:Parameter Name="IDADE" Type="Int32" />
            <asp:Parameter Name="SEXO" Type="String" />
            <asp:Parameter Name="NOME" Type="String" />
            <asp:Parameter Name="ID_ANIMAL" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <asp:HyperLink ID="HyperLinkAnimais" runat="server"  NavigateUrl="PesquisaAvancadaAnimais.aspx" >Pesquisa avançada</asp:HyperLink>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:HyperLink ID="HyperLinkEditarAnimais" runat="server" NavigateUrl="~/MenuNavegacao/Clientes/Animais/Editar.aspx">Editar</asp:HyperLink>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:HyperLink ID="HyperLinkNovo" runat="server"  NavigateUrl="~/MenuNavegacao/Clientes/Animais/NovoAninal.aspx">Novo</asp:HyperLink>
     &nbsp;&nbsp;<br />
    <br />
    </asp:Content>

