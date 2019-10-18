using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Security;

public partial class MenuNavegacao_Clientes_Consultas_Clientes_CancelarConsulta : System.Web.UI.Page{
    //Atributos
    private string data, date, teste;

    //Construtor
    protected void Page_Load(object sender, EventArgs e){
        this.biDono();//Verifica se tens datas anteriores

        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        string user = User.Identity.Name;
        string bi = "";

        cmd.CommandText = "SELECT BI FROM CLIENTE WHERE [USERNAME] = '" + user + "'";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try
        {
            while (DR.Read())
            {
                bi = string.Format("{0} ", DR.GetValue(0));

            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex)
        {// apanhar exccoes exemplo seleciona um id e escreve o nome

        }

        this.SqlDataSource1.SelectParameters["BI"].DefaultValue = bi;
    
    }

    /*#########################################################################*/
    /*#                       Metodos dos botoes                              #*/
    /*#########################################################################*/
    //botao Add nova consulta
    protected void ButtonNovaConsulta_Click(object sender, EventArgs e){
        Response.Redirect("~/MenuNavegacao/Clientes/Consultas/MarcarConsulta.aspx");
    }

    /*########################################################################*/
    /*#                METODO DE VERIFICAR DATAS DAS CONSULTAS               #*/
    /*########################################################################*/
    //getBi DONO
    private void biDono(){
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        string user = User.Identity.Name;

        cmd.CommandText = "SELECT BI FROM CLIENTE where USERNAME = '" + user + "'";
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
                int numero = Convert.ToInt32(info);
                this.mudaDataConsulta(numero);
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex)
        {// apanhar exccoes exemplo seleciona um id e escreve o nome

        }
    
    
    }


    //mudar data consulta
    private void mudaDataConsulta(int biDono){
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        int idVet = this.getIdVeterinario();

        string user = User.Identity.Name;

        cmd.CommandText = "SELECT ID_ANIMAL FROM ANIMAL where BI_DONO = '" + biDono + "'";
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
                int numero = Convert.ToInt32(info);
                this.verificaDataAnteriores(numero);


            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex)
        {// apanhar exccoes exemplo seleciona um id e escreve o nome

        }
    }
      
    //verifica datas anterirores
    private void verificaDataAnteriores(int idAnimal){
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        int idVet = this.getIdVeterinario();

        string user = User.Identity.Name;

        cmd.CommandText = "SELECT DATA FROM CONSULTA where ID_ANIMAL = '"+idAnimal+"'";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try{
            while (DR.Read()){
                info= string.Format("{0} ", DR.GetValue(0));

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
               
                //cortar as horas da data
                for (int i = 0; i < 10; i++){
                    sb.Append(info[i]);
                }

                this.date = DateTime.Today.ToShortDateString();
                this.data = sb.ToString();

                DateTime myDate = DateTime.ParseExact(data, "dd/MM/yyyy", null);

                if (myDate < DateTime.Today){
                    this.mudarEstadoDaConsulta(info);
                }
            }
            DR.Close();
            cnn.Close();
        }catch (SqlException ex){// apanhar exccoes exemplo seleciona um id e escreve o nome

        }
    }

    //get id do veterinario
    private int getIdVeterinario(){
        int idVet = 0;
        string user = User.Identity.Name;


        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "SELECT ID_VETERINARIO FROM VETERINARIO WHERE [USERNAME] = '" + user + "'";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try{
            while (DR.Read()){
                info = string.Format("{0} ", DR.GetValue(0));
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex){// apanhar exccoes exemplo seleciona um id e escreve o nome
        }

        try{
            idVet = Convert.ToInt32(info);
        }
        catch (Exception e){
            idVet = 0;
        }
        return idVet;
    }

    //mudar o estado da consulta
    private int getIdConsulta(string data){
        int id = 0;
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

  
        string user = User.Identity.Name;

        cmd.CommandText = "SELECT ID_CONSULTA FROM CONSULTA where DATA = '"+data+"'";
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

        try {
            id = Convert.ToInt32(info);
        
        }catch(Exception e){
            id = 0;
        }
        return id;
    }

    //private void mudar estdo
    private void mudarEstadoDaConsulta(string data){
        int id = this.getIdConsulta(data);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "UPDATE [CONSULTA] SET [ESTADO] = '" + " ANULADA" + "' WHERE [ID_CONSULTA] = '" + id + "' ";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();
        cmd.ExecuteNonQuery();
        cnn.Close();
    }
}