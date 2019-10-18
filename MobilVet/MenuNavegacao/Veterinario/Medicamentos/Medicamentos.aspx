<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Medicamentos.aspx.cs" Inherits="MenuNavegacao_Veterinario_Medicamentos_Medicamentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>&nbsp;<asp:Label ID="Label1" runat="server" Text="Medicamentos "></asp:Label></h2>
    <p>&nbsp;</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" DataKeyNames="ID_MEDICAMENTO" Width="215px">
            <AlternatingRowStyle BackColor="PaleGoldenrod" Wrap="True" />
            <Columns>
                <asp:BoundField DataField="ID_MEDICAMENTO" HeaderText="ID" SortExpression="ID_MEDICAMENTO" ReadOnly="True" />
                <asp:BoundField DataField="NOME" HeaderText="NOME" SortExpression="NOME" />
                <asp:CommandField ShowDeleteButton="True" />
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
        <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" Width="215px" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" SelectCommand="SELECT * FROM [MEDICAMENTOS]" DeleteCommand="DELETE FROM [MEDICAMENTOS] WHERE [ID_MEDICAMENTO] = @ID_MEDICAMENTO" InsertCommand="INSERT INTO [MEDICAMENTOS] ([ID_MEDICAMENTO], [NOME]) VALUES (@ID_MEDICAMENTO, @NOME)" UpdateCommand="UPDATE [MEDICAMENTOS] SET [NOME] = @NOME WHERE [ID_MEDICAMENTO] = @ID_MEDICAMENTO">
            <DeleteParameters>
                <asp:Parameter Name="ID_MEDICAMENTO" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID_MEDICAMENTO" Type="Decimal" />
                <asp:Parameter Name="NOME" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="NOME" Type="String" />
                <asp:Parameter Name="ID_MEDICAMENTO" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:Label ID="LabelMedicamentos" runat="server" Text="Nao nulos"></asp:Label>
    </p>
    <p>
        <br />
    </p>
    <p>
    &nbsp;</p>
    <p>&nbsp;</p>
</asp:Content>