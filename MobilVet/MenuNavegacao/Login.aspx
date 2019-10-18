<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="MenuNavegacao_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1></h1>
    <h2><asp:Label ID="Label1" runat="server" Text="Por favor insira o username e a palavra-passe."></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MenuNavegacao/Registo.aspx">Registe-se</asp:HyperLink>
    <asp:Label ID="Label2" runat="server" Text=" se não tiver registado."></asp:Label><br />
    </h2>
     <h2><asp:Label ID="Label3" runat="server" Text="Não tem permissoes para aceder a esta pagina"></asp:Label>
    </h2> 
   <br />
    <asp:LoginView ID="LoginView1" runat="server">
    <AnonymousTemplate>
        <asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" Height="170px" Width="277px" DestinationPageUrl="~/MenuNavegacao/Home.aspx">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
    </AnonymousTemplate>
</asp:LoginView>
</asp:Content>

