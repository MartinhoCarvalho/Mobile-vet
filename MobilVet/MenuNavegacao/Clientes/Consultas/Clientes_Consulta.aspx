<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeFile="Clientes_Consulta.aspx.cs" Inherits="MenuNavegacao_Clientes_Consultas_Clientes_CancelarConsulta" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <p>
        Tabela Consultas</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_CONSULTA" DataSourceID="SqlDataSource1" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID_CONSULTA" HeaderText="ID_CONSULTA" ReadOnly="True" SortExpression="ID_CONSULTA" />
                <asp:BoundField DataField="ID_ANIMAL" HeaderText="ID_ANIMAL" SortExpression="ID_ANIMAL" />
                <asp:BoundField DataField="BI" HeaderText="BI" SortExpression="BI" />
                <asp:BoundField DataField="ID_VETERINARIO" HeaderText="ID_VETERINARIO" SortExpression="ID_VETERINARIO" />
                <asp:BoundField DataField="ID_SERVICO" HeaderText="ID_SERVICO" SortExpression="ID_SERVICO" />
                <asp:BoundField DataField="DATA" HeaderText="DATA" SortExpression="DATA" />
                <asp:BoundField DataField="HORA" HeaderText="HORA" SortExpression="HORA" />
                <asp:BoundField DataField="LOCAL" HeaderText="LOCAL" SortExpression="LOCAL" />
                <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" SortExpression="ESTADO" />
                <asp:BoundField DataField="SINTOMA" HeaderText="SINTOMA" SortExpression="SINTOMA" />
                <asp:BoundField DataField="MARCACAO" HeaderText="MARCACAO" SortExpression="MARCACAO" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" SelectCommand="SELECT * FROM [CONSULTA] WHERE ([BI] = @BI)" DeleteCommand="DELETE FROM [CONSULTA] WHERE [ID_CONSULTA] = @ID_CONSULTA" InsertCommand="INSERT INTO [CONSULTA] ([ID_CONSULTA], [ID_ANIMAL], [BI], [ID_VETERINARIO], [ID_SERVICO], [DATA], [HORA], [LOCAL], [ESTADO], [SINTOMA], [MARCACAO]) VALUES (@ID_CONSULTA, @ID_ANIMAL, @BI, @ID_VETERINARIO, @ID_SERVICO, @DATA, @HORA, @LOCAL, @ESTADO, @SINTOMA, @MARCACAO)" UpdateCommand="UPDATE [CONSULTA] SET [ID_ANIMAL] = @ID_ANIMAL, [BI] = @BI, [ID_VETERINARIO] = @ID_VETERINARIO, [ID_SERVICO] = @ID_SERVICO, [DATA] = @DATA, [HORA] = @HORA, [LOCAL] = @LOCAL, [ESTADO] = @ESTADO, [SINTOMA] = @SINTOMA, [MARCACAO] = @MARCACAO WHERE [ID_CONSULTA] = @ID_CONSULTA">
            <DeleteParameters>
                <asp:Parameter Name="ID_CONSULTA" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID_CONSULTA" Type="Decimal" />
                <asp:Parameter Name="ID_ANIMAL" Type="Decimal" />
                <asp:Parameter Name="BI" Type="Decimal" />
                <asp:Parameter Name="ID_VETERINARIO" Type="Decimal" />
                <asp:Parameter Name="ID_SERVICO" Type="Decimal" />
                <asp:Parameter Name="DATA" Type="String" />
                <asp:Parameter Name="HORA" Type="String" />
                <asp:Parameter Name="LOCAL" Type="String" />
                <asp:Parameter Name="ESTADO" Type="String" />
                <asp:Parameter Name="SINTOMA" Type="String" />
                <asp:Parameter Name="MARCACAO" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter Name="BI" Type="Int32" DefaultValue="Anonymous" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="ID_ANIMAL" Type="Decimal" />
                <asp:Parameter Name="BI" Type="Decimal" />
                <asp:Parameter Name="ID_VETERINARIO" Type="Decimal" />
                <asp:Parameter Name="ID_SERVICO" Type="Decimal" />
                <asp:Parameter Name="DATA" Type="String" />
                <asp:Parameter Name="HORA" Type="String" />
                <asp:Parameter Name="LOCAL" Type="String" />
                <asp:Parameter Name="ESTADO" Type="String" />
                <asp:Parameter Name="SINTOMA" Type="String" />
                <asp:Parameter Name="MARCACAO" Type="Int32" />
                <asp:Parameter Name="ID_CONSULTA" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <br />
    <br />
    <asp:Button ID="ButtonNovaConsulta" runat="server" Text="NovaConsulta" OnClick="ButtonNovaConsulta_Click" /> &nbsp;&nbsp; 
    </asp:Content>

