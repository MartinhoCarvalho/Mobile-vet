<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeFile="PesquisaAvancadaAnimais.aspx.cs" Inherits="MenuNavegacao_Clientes_Animais_PesquisaAvancadaAnimais" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 182px;
        }
        .auto-style3 {
            width: 99px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <br />
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Escolha o campo a pesquisar
    </td>
            <td class="auto-style3">
    <asp:DropDownList ID="DropDownListPesquisar" runat="server" Width="100px">
        <asp:ListItem Text="ID_ANIMAL" Value="0"></asp:ListItem>
        <asp:ListItem Text="CONSULTA" Value="1"></asp:ListItem>
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
            <td class="auto-style2">Introduza o nome:</td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:Button ID="ButtonPesquisar" runat="server" Text="Pesquisar" OnClick="ButtonPesquisar_Click"  Width="291px" />
    <br />
    <br />
    <asp:Label ID="LabelEspecie" runat="server" Text="Label"></asp:Label>
    <br />
    <%-- ################################################ --%>
    <%-- #                      LISTBOX                 # --%>
    <%-- ################################################ --%>
    <asp:ListBox ID="ListBoxPEsquisar" runat="server" Height="35%" Width="90%" >

    </asp:ListBox>
    <br />
    <br />
    <br />
</asp:Content>
