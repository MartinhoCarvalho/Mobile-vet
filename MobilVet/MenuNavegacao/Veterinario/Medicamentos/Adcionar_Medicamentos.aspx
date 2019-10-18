<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Adcionar_Medicamentos.aspx.cs" Inherits="MenuNavegacao_Veterinario_Medicamentos_Adcionar_Medicamentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 137px;
        }
        .auto-style3 {
            width: 47px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Adcionar Medicamento"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label2" runat="server" Text="Nome: "></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Confirmar" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

