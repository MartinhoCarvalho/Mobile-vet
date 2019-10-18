<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeFile="Editar.aspx.cs" Inherits="MenuNavegacao_Clientes_Animais_Editar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    &nbsp;<br />
    <asp:Label ID="Label7" runat="server" Text="Selecionr Animal"></asp:Label>&nbsp;&nbsp;&nbsp;     
    <asp:DropDownList ID="DropDownListEditar" runat="server" DataSourceID="SqlDataSource3" DataTextField="NOME" DataValueField="ID_ANIMAL">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" SelectCommand="SELECT [ID_ANIMAL], [NOME] FROM [ANIMAL] WHERE ([BI_DONO] = @BI_DONO)">
        <SelectParameters>
            <asp:Parameter Name="BI_DONO" Type="String" DefaultValue="Anonymous" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <br />
    <br />
    <asp:Button ID="ButtonEdtitar" runat="server" Text="Editar" OnClick="ButtonEdtitar_Click" />
    
    <br />
    
    <br />
    <asp:Label ID="LabelNome" runat="server" Text="Nome"></asp:Label>
    <asp:TextBox ID="TextBoxNome" runat="server" ></asp:TextBox>
    
    <br />
    
    <br />
    <asp:Label ID="LabelSexo" runat="server" Text="Sexo"></asp:Label>
    <asp:DropDownList ID="DropDownListSexo" runat="server" >
        <asp:ListItem Value="M">Masculino</asp:ListItem>
        <asp:ListItem Value="F">Feminino</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="LabelChip" runat="server" Text="Chip"></asp:Label>
    <asp:TextBox ID="TextBoxChip" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="LabelIdade" runat="server" Text="Idade"></asp:Label>
    <asp:TextBox ID="TextBoxIdade" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="LabelEspecie" runat="server" Text="Especie"></asp:Label>
    <asp:DropDownList ID="DropDownListEspecie" runat="server" DataSourceID="SqlDataSource2" DataTextField="NOME" DataValueField="ID_ESPECIE">
    </asp:DropDownList>
  
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" SelectCommand="SELECT [NOME], [ID_ESPECIE] FROM [ESPECIE]"></asp:SqlDataSource>
    <br />
    <asp:Label ID="LabelNovaEspecie" runat="server" Text="Nova Especie"></asp:Label>
&nbsp;
    <asp:CheckBox ID="CheckBoxNovaEspecie" runat="server" />
    <br />
    <br />
    <asp:Label ID="LabelEspNova" runat="server" Text="Nova"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxNovaEspecie" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="LabelRaca" runat="server" Text="Raca"></asp:Label>
    <asp:DropDownList ID="DropDownLisRaca" runat="server" DataSourceID="SqlDataSource1" DataTextField="NOME" DataValueField="ID_RACA">
        <asp:ListItem></asp:ListItem>
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" SelectCommand="SELECT [NOME], [ID_RACA] FROM [RACA]"></asp:SqlDataSource>
    <br />
    <br />
    <asp:Label ID="LabelNovaRaca" runat="server" Text="Nova Raça"></asp:Label>
&nbsp;
    <asp:CheckBox ID="CheckBoxNovaRaca" runat="server"  />
    <br />
    <br />
    <asp:Label ID="LabelRacaNova" runat="server" Text="Raça"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxNovaRaca" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="LabelPerigosa" runat="server" Text="Perigosa"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxPerigosa" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="ButtonConfirmar" runat="server" OnClick="Button1_Click" Text="Confirmar" /> 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" />
</asp:Content>
