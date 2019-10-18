using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class MenuNavegacao_Clientes_Animais_PesquisaAvancadaAnimais : System.Web.UI.Page
{
    //ATRIBUTOS
    private int opacaoDaPesquisaAvancada;
    private string idEspecie;
    private static int totalColunas = 0;
    private string dados;
    private Boolean flag = false;

    //Page load
    protected void Page_Load(object sender, EventArgs e)
    {

        this.LabelEspecie.Visible = false;
        MenuNavegacao_Clientes_Animais_PesquisaAvancadaAnimais.totalColunas = 0;
        this.ListBoxPEsquisar.Visible = true;
        //SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        //SqlCommand cmd = new SqlCommand();
      
       // this.setDropDown();
    }

    /*Devolve o resultado da escolha*/
    private void getReturnEscolhaDaPesquisa(EventArgs e)
    {
        base.OnLoad(e);
        this.ListBoxPEsquisar.Items.Clear();
        string valor = this.DropDownListPesquisar.SelectedValue.ToString();

        int valorDaOpcao = Convert.ToInt32(valor);

        if (valorDaOpcao == 0)
        {//ID_ANIMAL
            this.preencherDadosDoAnimal();
        }
        else if (valorDaOpcao == 1)
        {//chip
            this.pesquisarConsultasDoAnimal();
        }
    }

    protected void ButtonPesquisar_Click(object sender, EventArgs e)
    {
        this.ListBoxPEsquisar.Visible = true;
        this.getReturnEscolhaDaPesquisa(e);
    }

    /*##############################################*/
    /*#             METODOS CORRETOS               #*/
    /*##############################################*/
    //bi user
    private int getBiDono()
    {
        int bi = 0;
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        string user = User.Identity.Name;

        cmd.CommandText = "SELECT BI from CLIENTE where USERNAME = '" + user + "'";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try
        {
            while (DR.Read())
            {
                info = string.Format("{0} ", DR.GetValue(0));
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex)
        {// apanhar exccoes exemplo seleciona um id e escreve o nome
        }

        try
        {
            bi = Convert.ToInt32(info);
        }
        catch (Exception e)
        {
            bi = 0;
        }
        return bi;
    }

    //get Nome
    private void setDropDown()
    {
        int bi = this.getBiDono();
        string nome;

        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "SELECT ID_ANIMAL, NOME FROM ANIMAL WHERE BI_DONO = '" + bi + "'";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try
        {
            while (DR.Read())
            {
                info = string.Format("{0} ", DR.GetValue(0));
                nome = string.Format("{1}", DR.GetValue(0), DR.GetValue(1));
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex)
        {// apanhar exccoes exemplo seleciona um id e escreve o nome

        }
    }

    //id vet
    private string nomeVeterinario(int id)
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "SELECT NOME FROM VETERINARIO  WHERE ID_VETERINARIO = '" + id + "'";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try
        {
            while (DR.Read())
            {
                info = string.Format(" com o veterinario {0} ", DR.GetValue(0));
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex)
        {// apanhar exccoes exemplo seleciona um id e escreve o nome
        }

        return info;
    }

    //get idAnimal
    private int getIDAnimal(string nome){
        int id = this.getBiDono();
        int numero = 0;
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "SELECT ID_ANIMAL FROM ANIMAL  WHERE BI_DONO = '" + id + "'and NOME='"+nome+"'";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try{
            while (DR.Read()){
                info = string.Format("{0} ", DR.GetValue(0));

                try {
                    numero = Convert.ToInt32(info);
                }catch(Exception e){
                    numero = 0;
                }
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex)
        {// apanhar exccoes exemplo seleciona um id e escreve o nome
        }

        return numero;
    }

    //Pesquisar Consultas do Animal
    private void pesquisarConsultasDoAnimal()
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        int ID = this.getIDAnimal(this.TextBox1.Text.ToString());

        string nome;
        string informacao = " ";
        cmd.CommandText = "SELECT ID_VETERINARIO, DATA,HORA,LOCAL,ESTADO FROM CONSULTA  WHERE ID_ANIMAL = '" + ID + "'";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try
        {
            while (DR.Read())
            {
                info = string.Format("{0} ", DR.GetValue(0));
                int id;
                try
                {
                    id = Convert.ToInt32(info);

                }
                catch (Exception e)
                {
                    id = 0;
                }

                nome = this.nomeVeterinario(id);

                informacao = string.Format("Consulta no dia {1} hora {2} local {3} estado {4} ", DR.GetValue(0), DR.GetValue(1), DR.GetValue(2), DR.GetValue(3), DR.GetValue(4));
                informacao += nome;

                this.ListBoxPEsquisar.Items.Add(informacao);
                this.ListBoxPEsquisar.Items.Add("\n");
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex) {/* apanhar exccoes exemplo ,, DR.GetValue(1)seleciona um id e escreve o nome*/ }
    }

    /*#############################################*/
    /*#      INFORMACAO DETALHADA DO ANIMAL       #*/
    /*#############################################*/
    //Pesquisar Ispecie
    private string getEspecie(int especie)
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        int ID = Convert.ToInt32(especie); ;

        string nome = " ";

        string informacao = " ";
        cmd.CommandText = "SELECT NOME  FROM ESPECIE  WHERE ID_ESPECIE = '" + ID + "'";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try
        {
            while (DR.Read())
            {
                nome = string.Format("{0} ", DR.GetValue(0));
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex) {/* apanhar exccoes exemplo ,, DR.GetValue(1)seleciona um id e escreve o nome*/ }
        return nome;
    }

    //get nomeRaca
    private string getNomeRaca(int idRaca)
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        int ID = Convert.ToInt32(idRaca); ;

        string nome = " ";

        string informacao = " ";
        cmd.CommandText = "SELECT NOME  FROM RACA  WHERE ID_RACA = '" + ID + "'";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try
        {
            while (DR.Read())
            {
                nome = string.Format(" da raca {0} ", DR.GetValue(0));
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex) {/* apanhar exccoes exemplo ,, DR.GetValue(1)seleciona um id e escreve o nome*/ }
        return nome;
    }

    //preencher informcao dos animais
    private void preencherDadosDoAnimal()
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        int ID = this.getIDAnimal(this.TextBox1.Text.ToString());

        string nome;
        int id;

        string informacao = " ";
        cmd.CommandText = "SELECT NOME, ID_ESPECIE,ID_RACA,SEXO,IDADE FROM ANIMAL  WHERE ID_ANIMAL = '" + ID + "'";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try
        {
            while (DR.Read())
            {
                nome = string.Format("{0} é um ", DR.GetValue(0));

                informacao += nome;

                string especie = string.Format("{1}", DR.GetValue(0), DR.GetValue(1));

                int idEspecie = Convert.ToInt32(especie);
                string tipo = this.getEspecie(idEspecie);
                informacao += tipo;

                string raca = string.Format("{2}", DR.GetValue(0), DR.GetValue(1), DR.GetValue(2));
                int idRaca = Convert.ToInt32(raca);
                string nomeRaca = this.getNomeRaca(idRaca);
                informacao += nomeRaca;

                this.ListBoxPEsquisar.Items.Add(informacao);
                this.ListBoxPEsquisar.Items.Add("\n");
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex) {/* apanhar exccoes exemplo ,, DR.GetValue(1)seleciona um id e escreve o nome*/ }

    }
}