using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuNavegacao_Clientes_Consultas_MarcarConsulta : System.Web.UI.Page{
    //Atributos
    private string[] horarios = { "09.00", "11.00", "14.00", "16.00" };
    private string date, teste, data, local, idVeterinario, sintoma, hora;
    private Boolean flagData = true;
    private int idConsulta, biCliente, marcacao = 1, idAnimal = 0,contador = 0,idServico;
    private string estado = "Pendente";

    //Construtor
    protected void Page_Load(object sender, EventArgs e){

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

        this.SqlDataSource3.SelectParameters["BI_DONO"].DefaultValue = bi;

        this.DropDownListHorario.Visible = false;
        this.ButtonConfirmarConsulta.Visible = false;
        this.LabelHorarios.Visible  = false;
        this.LabelSintoma.Visible   = false;
        this.TextBoxSintoma.Visible = false;
        this.LabelLocal.Visible     = false;
        this.TextBoxLocal.Visible   = false;
        this.LabelServico.Visible   = false;
        this.DropDownListServico.Visible = false;
        this.contador = 0;
        this.LabelHorarioDisponivel.Visible = false;
        this.Button1.Visible = false;





    }

    /*#############################################################*/
    /*#                 Metodos para marcar consulta              #*/
    /*#############################################################*/

    private string getData(){

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        this.teste = this.Calendar1.SelectedDate.ToString();
        //cortar as horas da data
        for (int i = 0; i < 10; i++)
        {
            sb.Append(teste[i]);
        }

        this.date = DateTime.Today.ToShortDateString();
        this.data = sb.ToString();

        return this.data;
    }
    
    
    //Mostrar horarios
    protected void ButtonMarcaConsulta_Click(object sender, EventArgs e){
        this.data = this.getData();
        this.verificaData();

        if (this.flagData == true){// se a data estiver bem mostra a dropDownList
            this.DropDownListHorario.Items.Clear();//limpar os dados
            for (int i = 0; i < horarios.Length; i++){
                if (this.verificHoraDaConsulta(sender, e, horarios[i]) == false){// se for true ja existe uma consulta com essa hora
                   this.DropDownListHorario.Items.Add(new ListItem(this.horarios[i], this.horarios[i]));
                   this.contador++;
                }
            }
            if (this.contador > 0){
                this.DropDownListHorario.Visible = true;
                this.ButtonConfirmarConsulta.Visible = true;
                this.LabelHorarios.Visible = true;
                this.LabelSintoma.Visible = true;
                this.TextBoxSintoma.Visible = true;
                this.LabelLocal.Visible = true;
                this.TextBoxLocal.Visible = true;
                this.LabelServico.Visible = true;
                this.DropDownListServico.Visible = true;
                this.Button1.Visible = true;
              
            }
            else {
                this.LabelHorarioDisponivel.Visible = true;
            }
        }
    }

    //Confirmar a consulta na tabela
    protected void confirmarConsulta(object sender, EventArgs e) {
        this.insertConsultaBaseDeDados(sender, e);
        Response.Redirect("~/MenuNavegacao/Clientes/Consultas/Clientes_Consulta.aspx");
    }

    /*#############################################################*/
    /*#                 Metodo para ver a data                    #*/
    /*#############################################################*/
    //verifica data dos sistema
    private void verificaData(){
        DateTime myDate = DateTime.ParseExact(this.data, "dd/MM/yyyy", null);

        if (myDate > DateTime.Today)
        {
            //verificar as horas

            this.flagData = true;
        }
        else
        {
            this.flagData = false;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Data anterior a data atual. Forma correta dia atual + 1 dia" + "');", true);
        }
    }

    /*#############################################################*/
    /*#                    CONEXAO a base de dados                #*/
    /*#############################################################*/

    // return idConsulta o ultimo id
    private int getMaiorIdAnimal(object sender, EventArgs e){
        int numero = 0;

        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select max(ID_CONSULTA) from CONSULTA";
        SqlCommand cmd = new SqlCommand(seleccao, cnn);

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

        numero = Convert.ToInt32(info);
        return numero;
    }

    //pesquisar a data da consulta
    private Boolean verificHoraDaConsulta(object sender, EventArgs e, string hora){
        this.idVeterinario = this.DropDownListVeterinario.SelectedValue.ToString();

        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select HORA from CONSULTA where ID_VETERINARIO = '" + this.idVeterinario + "' and DATA ='"+this.data+"'";
        //   and DATA ='"+this.hora+'"
        SqlCommand cmd = new SqlCommand(seleccao, cnn);

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try{
            while (DR.Read()){
                info = string.Format("{0} ", DR.GetValue(0));
               
                info = this.concatenarStringDoSelect(info);

                if (info.Equals(hora) == true){
                    DR.Close();
                    cnn.Close();
                    return true;
                }
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex){// apanhar exccoes exemplo seleciona um id e escreve o nome

        }
    
        return false;
    }

    //concatenar a string pelo select
    private string concatenarStringDoSelect(string info){
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        for (int i = 0; i < info.Length; i++){
            if (i < 5){
                sb.Append(info[i]);
            }
        }
            return sb.ToString();
    }

    /*#############################################################*/
    /*#                   Insert Base Dados                       #*/
    /*#############################################################*/
    //inserir consulta na tabela
    private void insertConsultaBaseDeDados(object sender, EventArgs e){

        this.idConsulta = this.getLastConsultaId(sender, e);
        this.idConsulta++;//inc o ultimo id da consulta
        this.idVeterinario = getIdVeterinario();//ID VETERINARIO
        this.idAnimal = this.getIdAnimal();//id animal
        this.biCliente = this.getBiCliente();
        this.hora = this.getHora();//hora da consulta
        this.hora = this.getHora();
        this.data = this.getData();
        this.idServico = Convert.ToInt32(this.getIdServico());
        this.local = this.getLocal();
        this.sintoma = this.getSintoma();

        this.OnLoad(e);
        SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "INSERT INTO CONSULTA VALUES ('" + this.idConsulta + "','" + this.idAnimal + "','" + this.biCliente + "','" + this.idVeterinario + "','"+this.idServico+"','"+this.data+"','" + this.hora + "','" + this.local + "','" + this.estado + "','" + this.sintoma + "','" + this.marcacao + "')";
        //cmd.CommandText = "INSERT INTO CONSULTA VALUES (2,1,123,1,26,9,"sfs","sds","sfsd",1)";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConnection1;

        sqlConnection1.Open();

        cmd.ExecuteNonQuery();//Data is accessible through the DataReader object here.

        sqlConnection1.Close();
    }

    //numero maximo de consultas
    private int getLastConsultaId(Object sender, EventArgs e){
        int numero = 0;

        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select max(ID_CONSULTA) from CONSULTA";
        SqlCommand cmd = new SqlCommand(seleccao, cnn);

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
        catch (SqlException ex) { }// apanhar exccoes exemplo seleciona um id e escreve o nome  

        try
        {
            numero = Convert.ToInt32(info);
        }
        catch (Exception ox) {
            numero = 0;
        }

        return numero;
    }

    //get IdVeterinario
    private string getIdVeterinario(){     
        return this.DropDownListVeterinario.SelectedValue.ToString();
    }

    //bi do cliente
    private int getBiCliente(){
        int numero = 0;

        
        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string user = User.Identity.Name;

        string seleccao = "SELECT BI FROM CLIENTE WHERE [USERNAME] = '" + user + "'";//falta login para ir buscar o bi correcto nesta fase check 2 vai assim :(
        SqlCommand cmd = new SqlCommand(seleccao, cnn);

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try
        {
            while (DR.Read()){
                info = string.Format("{0} ", DR.GetValue(0));
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex) { }// apanhar excoes exemplo seleciona um id e escreve o nome  


        numero = Convert.ToInt32(info);
        return numero;
    }

    //id Animal 
    private int getIdAnimal(){
        int numero = Convert.ToInt32(this.DropDownListAnimal.SelectedValue.ToString());
    
            return numero;
    }
    
    //get hora
    private string getHora() {
        return this.DropDownListHorario.SelectedValue.ToString();
    }

    //getLocal
    private string getLocal(){
        return this.TextBoxLocal.Text;
    }

    //sintoma
    private string getSintoma(){
        return this.TextBoxSintoma.Text;
    }

    //id Servico
    private string getIdServico(){
        return this.DropDownListServico.SelectedValue.ToString();
    }


    /*MARCACAO
         Cliente = 1
         Veterinario = 2
         Admin = 3
     */

    //Cancelar consulta
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MenuNavegacao/Clientes/Consultas/Clientes_Consulta.aspx");
    }
}