<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/MasterPage.Master" CodeFile="Horarios.aspx.cs" Inherits="MenuNavegacao_Horarios" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 860px;
        }
        .auto-style3 {
            height: 37px;
            width: 286px;
        }
        .auto-style5 {
            width: 286px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="item_page">
        <h1>Horários</h1>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3"><strong>Segunda a Sexta-feira:</strong></td>
                <td class="auto-style3"><strong>Sábado:</strong></td>
                <td class="auto-style3"><strong>Urgências:</strong></td>
            </tr>
            <tr>
                <td class="auto-style5">das 09h00 às 13h00<br />
                    das 14h00 às 18h00</td>
                <td class="auto-style5">das 09h00 às 13h00</td>
                <td class="auto-style5">24H</td>
            </tr>
        </table>
    </div>
</asp:Content>
