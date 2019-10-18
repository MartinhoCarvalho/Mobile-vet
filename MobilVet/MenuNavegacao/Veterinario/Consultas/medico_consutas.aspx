<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="medico_consutas.aspx.cs" Inherits="MenuNavegacao_Veterinario_Consultas_medico_consutas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <h1>Minhas Consultas</h1>

    <asp:Calendar OnSelectionChanged="Page_Load" ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399"   Visible="false"      Height="200px" ShowGridLines="True" Width="220px" >
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <OtherMonthDayStyle ForeColor="#CC9966" />
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <SelectorStyle BackColor="#FFCC66" />
        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
    </asp:Calendar>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID_CONSULTA" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" onrowcommand="GridView1_RowCommand">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:BoundField DataField="ID_CONSULTA" HeaderText="Nº CONSULTA" ReadOnly="True" SortExpression="ID_CONSULTA" />
            <asp:BoundField DataField="ID_ANIMAL" HeaderText="ANIMAL" SortExpression="ID_ANIMAL" />
            <asp:BoundField DataField="BI" HeaderText="BI" SortExpression="BI" />
            <asp:BoundField DataField="ID_VETERINARIO" HeaderText="VETERINARIO" SortExpression="ID_VETERINARIO" />
            <asp:BoundField DataField="ID_SERVICO" HeaderText="SERVICO" SortExpression="ID_SERVICO" />
            <asp:BoundField DataField="DATA" HeaderText="DATA" SortExpression="DATA" />
            <asp:BoundField DataField="HORA" HeaderText="HORA" SortExpression="HORA" />
            <asp:BoundField DataField="LOCAL" HeaderText="LOCAL" SortExpression="LOCAL" />
            <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" SortExpression="ESTADO" />
            <asp:BoundField DataField="SINTOMA" HeaderText="SINTOMA" SortExpression="SINTOMA" />
            <asp:BoundField DataField="MARCACAO" HeaderText="MARCACAO" SortExpression="MARCACAO" Visible="False" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:ButtonField ButtonType="Button" Text="Receita" CommandName="btnReceita" />
            <asp:ButtonField ButtonType="Button" Text="Terminar Consulta" CommandName="btnTerminar" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" DeleteCommand="DELETE FROM [CONSULTA] WHERE [ID_CONSULTA] = @ID_CONSULTA" InsertCommand="INSERT INTO [CONSULTA] ([ID_CONSULTA], [ID_ANIMAL], [BI], [ID_VETERINARIO], [ID_SERVICO], [DATA], [HORA], [LOCAL], [ESTADO], [SINTOMA], [MARCACAO]) VALUES (@ID_CONSULTA, @ID_ANIMAL, @BI, @ID_VETERINARIO, @ID_SERVICO, @DATA, @HORA, @LOCAL, @ESTADO, @SINTOMA, @MARCACAO)" SelectCommand="SELECT * FROM [CONSULTA] WHERE ([ID_VETERINARIO] = @ID_VETERINARIO AND [DATA] = @DATA_CONSULTA)" UpdateCommand="UPDATE [CONSULTA] SET [DATA] = @DATA, [HORA] = @HORA, [LOCAL] = @LOCAL, [ESTADO] = @ESTADO, [SINTOMA] = @SINTOMA WHERE [ID_CONSULTA] = @ID_CONSULTA">
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
            <asp:Parameter Name="ID_VETERINARIO" Type="Int32" DefaultValue="Anonymous" />
            <asp:Parameter Name="DATA_CONSULTA" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="DATA" Type="String" />
            <asp:Parameter Name="HORA" Type="String" />
            <asp:Parameter Name="LOCAL" Type="String" />
            <asp:Parameter Name="ESTADO" Type="String" />
            <asp:Parameter Name="SINTOMA" Type="String" />
            <asp:Parameter Name="ID_CONSULTA" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />

   

</asp:Content>

