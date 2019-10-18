<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Perfil.aspx.cs" Inherits="MenuNavegacao_Veterinario_Perfil_Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h2><asp:Label ID="Label1" runat="server" Text="Perfil do Veterinario"></asp:Label></h2>
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ID_VETERINARIO" DataSourceID="SqlDataSource1" Height="50px" Width="125px" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" OnItemUpdating="DetailsView1_ItemUpdating">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <Fields>
            <asp:BoundField DataField="ID_VETERINARIO" HeaderText="ID_VETERINARIO"  SortExpression="ID_VETERINARIO" Visible="False" />
            <asp:BoundField DataField="NIF" HeaderText="NIF" SortExpression="NIF" />
            <asp:BoundField DataField="NOME" HeaderText="NOME" SortExpression="NOME" />
            <asp:BoundField DataField="MORADA" HeaderText="MORADA" SortExpression="MORADA" />
            <asp:BoundField DataField="TELEFONE" HeaderText="TELEFONE" SortExpression="TELEFONE" />
            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL" />
            <asp:BoundField DataField="IDADE" HeaderText="IDADE" SortExpression="IDADE" />
            <asp:BoundField DataField="USERNAME" HeaderText="USERNAME" SortExpression="USERNAME" Visible="False" />
            <asp:BoundField DataField="PASSWORD" HeaderText="PASSWORD" SortExpression="PASSWORD" Visible="False" />
            <asp:CommandField ShowEditButton="True" />
        </Fields>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" DeleteCommand="DELETE FROM [VETERINARIO] WHERE [ID_VETERINARIO] = @ID_VETERINARIO" InsertCommand="INSERT INTO [VETERINARIO] ([ID_VETERINARIO], [NIF], [NOME], [MORADA], [TELEFONE], [EMAIL], [IDADE], [USERNAME], [PASSWORD]) VALUES (@ID_VETERINARIO, @NIF, @NOME, @MORADA, @TELEFONE, @EMAIL, @IDADE, @USERNAME, @PASSWORD)" SelectCommand="SELECT * FROM [VETERINARIO] WHERE ([USERNAME] = @USERNAME)" UpdateCommand="UPDATE [VETERINARIO] SET [NIF] = @NIF, [NOME] = @NOME, [MORADA] = @MORADA, [TELEFONE] = @TELEFONE, [EMAIL] = @EMAIL, [IDADE] = @IDADE  WHERE [ID_VETERINARIO] = @ID_VETERINARIO">
        <DeleteParameters>
            <asp:Parameter Name="ID_VETERINARIO" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ID_VETERINARIO" Type="Decimal" />
            <asp:Parameter Name="NIF" Type="Decimal" />
            <asp:Parameter Name="NOME" Type="String" />
            <asp:Parameter Name="MORADA" Type="String" />
            <asp:Parameter Name="TELEFONE" Type="Decimal" />
            <asp:Parameter Name="EMAIL" Type="String" />
            <asp:Parameter Name="IDADE" Type="Int32" />
            <asp:Parameter Name="USERNAME" Type="String" />
            <asp:Parameter Name="PASSWORD" Type="String" />
        </InsertParameters>

          <SelectParameters>
              <asp:Parameter Name="username" Type="String" DefaultValue="Anonymous" />
        </SelectParameters>

        <UpdateParameters>
            <asp:Parameter Name="NIF" Type="Decimal" />
            <asp:Parameter Name="NOME" Type="String" />
            <asp:Parameter Name="MORADA" Type="String" />
            <asp:Parameter Name="TELEFONE" Type="Decimal" />
            <asp:Parameter Name="EMAIL" Type="String" />
            <asp:Parameter Name="IDADE" Type="Int32" />
            <asp:Parameter Name="USERNAME" Type="String" />
            <asp:Parameter Name="PASSWORD" Type="String" />
            <asp:Parameter Name="ID_VETERINARIO" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />

    <asp:Label ID="LabelDetailsViewNoNulls" runat="server" Text="Nao nulos"></asp:Label>

    <br />
    <br />
</asp:Content>

