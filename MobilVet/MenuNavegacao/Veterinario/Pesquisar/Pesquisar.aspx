<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Pesquisar.aspx.cs" Inherits="MenuNavegacao_Veterinario_Pesquisar_Pesquisar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 70px;
        }
        .auto-style3 {
            width: 120px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">&nbsp;Escolha:</td>
            <td class="auto-style3">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Text="Idade" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Raca" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Preencher:</td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:Button ID="Button1" runat="server" Text="Pesquisar" Width="204px" />
    <br />
</asp:Content>

