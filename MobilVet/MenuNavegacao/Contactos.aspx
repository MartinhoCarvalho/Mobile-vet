<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"  CodeFile="Contactos.aspx.cs" Inherits="MenuNavegacao_Contactos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 860px;
        }
        .auto-style2 {
            width: 286px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="item_page">
        <h2>Localização e Contatos</h2>
        <p><strong>Morada:</strong><br />
        Rua Pedro Nunes - Quinta da Nora <br />
        3030-199 COIMBRA <br />
        Portugal<br />
        </p>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2"><strong>Telefone:</strong></td>
                <td class="auto-style2"><strong>E-Mail:</strong></td>
                <td class="auto-style2"><strong>Mapa:</strong></td>
            </tr>
            <tr>
                <td class="auto-style2">239-000-000</td>
                <td class="auto-style2">mobilvet@mail.pt</td>
                <td class="auto-style2"><b>GPS</b>: N 40 11.575 W 8 24.698</td>
            </tr>
        </table>



    </div>
</asp:Content>
