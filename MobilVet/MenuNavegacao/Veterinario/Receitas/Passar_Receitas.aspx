<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Passar_Receitas.aspx.cs" Inherits="MenuNavegacao_Veterinario_Receitas_Passar_Receitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        #TextArea1 {
            height: 48px;
        }
        #Text1 {
            width: 177px;
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Descricao "></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="txtNotes"
       TextMode="Multiline"
       Columns="25"
       Rows="4"
       Wrap="False"
       runat="server"></asp:TextBox><br />
    <br />
    <br />
    <asp:Label ID="LabelMedicamentos"       runat="server" Text="Medicamentos"></asp:Label>
    &nbsp;&nbsp;
    <asp:DropDownList ID="DropDownListMedicamentos"    runat ="server" DataSourceID="SqlDataSource1" DataTextField="NOME" DataValueField="ID_MEDICAMENTO">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1"  runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" SelectCommand="SELECT * FROM [MEDICAMENTOS]"></asp:SqlDataSource>
    <br />
    <asp:Button ID="ButtonAdd" runat="server" Text="Adicionar medicamento" Width="181px" OnClick="ButtonAdd_Click"/>
    <br />
    <br />
    <br />
    <br />
    <asp:Button ID="ButtonConfirmar" runat="server" Text="Finalizar Receita" OnClick="ButtonConfirmar_Click" />
    &nbsp;&nbsp;
    <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" OnClick="ButtonCancelar_Click" />
    <br />
</asp:Content>

