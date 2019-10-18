<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="MenuNavegacao_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div id="home_page">

        <div id="item_destaques1">
            <img src="../Imagens/clinica.jpg" / style="width:218px; height:168px;"/>

            <div class="destaques_texto">
            <h2>Clínica</h2>
                <p>Conheça a nossa clínica.</p>
            </div>

            <div class="botao_destaques">
                <a href="Clinica.aspx" title="Clinica">
                <img src="../Imagens/bt_more.png" />
                </a>
            </div>
        </div>

        <div id="item_destaques2">
            <img src="../Imagens/registo.jpg" / style="width:218px; height:168px;"/>

            <div class="destaques_texto">
            <h2>Junte-se a nós</h2>
                <p>Faça o seu registo e disponha dos nossos variados serviços.</p>
            </div>

            <div class="botao_destaques">
                <a href="Registo.aspx" title="Registo">
                <img src="../Imagens/bt_registo.png" />
                </a>
            </div>
        </div>
        
        <div id="item_destaques3">
            
            <img src="../Imagens/consultas.jpg" / style="width:218px; height:168px;"/>
            
            <div class="destaques_texto">
            <h2>Consultas</h2>
			<p>Agende a sua consulta/exame para a especialidade e médico pretendido.</p>
            </div>

            <div class="botao_destaques">
                <a href="Clientes/Consultas/MarcarConsulta.aspx" title="Registo">
                <img src="../Imagens/bt_marca_home.png" />
                </a>
            </div>
        </div>

    </div>

 


<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BaseDadosMobilVet %>" SelectCommand="SELECT * FROM [CLIENTE]"></asp:SqlDataSource>
</asp:Content>

