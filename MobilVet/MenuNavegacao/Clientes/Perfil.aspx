<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeFile="Perfil.aspx.cs" Inherits="MenuNavegacao_Clientes_Perfil" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
    <br />
    &nbsp;<h4>PERFIL DO CLIENTE</h4>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="BI" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" Height="50px" Width="125px" OnItemUpdating="DetailsView1_ItemUpdating">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <Fields>
            <asp:BoundField DataField="BI" HeaderText="BI" SortExpression="BI" />
            <asp:BoundField DataField="NIF" HeaderText="NIF" SortExpression="NIF" />
            <asp:BoundField DataField="NOME" HeaderText="NOME" SortExpression="NOME" />
            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL" Visible="False" />
            <asp:BoundField DataField="MORADA" HeaderText="MORADA" SortExpression="MORADA" />
            <asp:BoundField DataField="TELEFONE" HeaderText="TELEFONE" SortExpression="TELEFONE" />
            <asp:BoundField DataField="IDADE" HeaderText="IDADE" SortExpression="IDADE"/>
            <asp:BoundField DataField="USERNAME" HeaderText="USERNAME" SortExpression="USERNAME" Visible="False" />
            <asp:BoundField DataField="PASSWORD" HeaderText="PASSWORD" SortExpression="PASSWORD" Visible="False" />

            <asp:CommandField ShowEditButton="True" />

        </Fields>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" SelectCommand="SELECT * FROM [CLIENTE] WHERE ([USERNAME] = @USERNAME)" OldValuesParameterFormatString="original_{0}" DeleteCommand="DELETE FROM [CLIENTE] WHERE [BI] = @original_BI" InsertCommand="INSERT INTO [CLIENTE] ([BI], [NIF], [NOME], [EMAIL], [MORADA], [TELEFONE], [IDADE], [USERNAME], [PASSWORD]) VALUES (@BI, @NIF, @NOME, @EMAIL, @MORADA, @TELEFONE, @IDADE, @USERNAME, @PASSWORD)" UpdateCommand="UPDATE [CLIENTE] SET [NIF] = @NIF, [NOME] = @NOME, [MORADA] = @MORADA, [TELEFONE] = @TELEFONE, [IDADE] = @IDADE WHERE [BI] = @original_BI">
        <DeleteParameters>
            <asp:Parameter Name="original_BI" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="BI" Type="Decimal" />
            <asp:Parameter Name="NIF" Type="Decimal" />
            <asp:Parameter Name="NOME" Type="String" />
            <asp:Parameter Name="EMAIL" Type="String" />
            <asp:Parameter Name="MORADA" Type="String" />
            <asp:Parameter Name="TELEFONE" Type="Decimal" />
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
            <asp:Parameter Name="EMAIL" Type="String" />
            <asp:Parameter Name="MORADA" Type="String" />
            <asp:Parameter Name="TELEFONE" Type="Decimal" />
            <asp:Parameter Name="IDADE" Type="Int32" />
            <asp:Parameter Name="USERNAME" Type="String" />
            <asp:Parameter Name="PASSWORD" Type="String" />
            <asp:Parameter Name="original_BI" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />

    <asp:Label ID="LabelDetailsViewNoNulls" runat="server" Text="Nao nulos"></asp:Label>

    <br />
    <br />
    <br />
    </asp:Content>


