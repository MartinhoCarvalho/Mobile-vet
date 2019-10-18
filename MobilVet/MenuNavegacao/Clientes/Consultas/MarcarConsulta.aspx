<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MarcarConsulta.aspx.cs" MasterPageFile="~/MasterPage.Master" Inherits="MenuNavegacao_Clientes_Consultas_MarcarConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    Selecionar animal
        <asp:DropDownList ID="DropDownListAnimal" runat="server" DataSourceID="SqlDataSource3" DataTextField="NOME" DataValueField="ID_ANIMAL">
        </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" SelectCommand="SELECT [NOME], [ID_ANIMAL] FROM [ANIMAL] WHERE ([BI_DONO] = @BI_DONO)">
        <SelectParameters>
            <asp:Parameter Name="BI_DONO" Type="Int32" DefaultValue="Anonymous" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <br />
    Escolher veterinario
        <asp:DropDownList ID="DropDownListVeterinario" runat="server" DataSourceID="SqlDataSource2" DataTextField="NOME" DataValueField="ID_VETERINARIO">
            <asp:ListItem Selected="True" Value="101">Selecionar</asp:ListItem>
        </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" SelectCommand="SELECT [NOME], [ID_VETERINARIO] FROM [VETERINARIO]"></asp:SqlDataSource>
    <br />
    <br />
    <%-- ############################################### --%>
    <%-- #                Marcar Consulta              # --%>
    <%-- ############################################### --%>
    <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <OtherMonthDayStyle ForeColor="#CC9966" />
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <SelectorStyle BackColor="#FFCC66" />
        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
    </asp:Calendar>
    <br />
    <asp:Button ID="ButtonMarcaConsulta" runat="server" Text="Mostrar Horarios" OnClick="ButtonMarcaConsulta_Click" />
    <br />
    <br />
    <asp:Label ID="LabelHorarioDisponivel" runat="server" Text="Nao existe horas diponiveis para esse dia"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LabelServico" runat="server" Text="Servicos"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownListServico" runat="server" DataSourceID="SqlDataSource7" DataTextField="NOME" DataValueField="ID_SERVICO">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" SelectCommand="SELECT [NOME], [ID_SERVICO] FROM [SERVICO]"></asp:SqlDataSource>
    <br />
    <br />
    <asp:Label ID="LabelSintoma" runat="server" Text="Escreva o sintoma"></asp:Label>
    <asp:TextBox ID="TextBoxSintoma" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="LabelLocal" runat="server" Text="Local"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBoxLocal" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="LabelHorarios" runat="server" Text="Horarios disponiveis:"></asp:Label>&nbsp;<asp:DropDownList ID="DropDownListHorario" runat="server"></asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="ButtonConfirmarConsulta" runat="server" Text="Confirmar Consulta" OnClick="confirmarConsulta"/>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Cancelar" OnClick="Button1_Click" style="margin-bottom: 0px" />
</asp:Content>
