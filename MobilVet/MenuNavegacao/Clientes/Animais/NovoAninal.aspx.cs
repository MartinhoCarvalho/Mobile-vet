using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class MenuNavegacao_Clientes_Animais_NovoAninal : System.Web.UI.Page{
    //Atributos
    private string nome   =" ";
    private string biDono =" ";
    private string idade  =" ";
    private string sexo   =" ";
    private string chip   =" ";
    private int idEspecie = 0;
    private int idAnimal  = 0;
    private int idRaca    = 0;
    private Boolean flag = true, flag2 = true, flag3 = true;
    
    //Construtor
    protected void Page_Load(object sender, EventArgs e){ }

    //cancelar dados
    protected void ButtonCancelar_Click(object sender, EventArgs e){
        Response.Redirect("~/MenuNavegacao/Clientes/Animais/Clientes_Animais.aspx");
    }

    //Novo animal
    protected void ButtonNovo_Click(object sender, EventArgs e){
        this.addicionarNovoAnimal(sender,e);
    }

    /*###############################################*/
    /*#            Adicionar Novo Animal            #*/
    /*###############################################*/
    private void addicionarNovoAnimal(object sender, EventArgs e){
        this.insertAnimal(sender,e);
    }

    //inserir animal
    private void insertAnimal(object sender, EventArgs e){

        // Verificar se o nome e idade e o numero de chip estao prenchidos 
        flag = true; flag2 = true; flag3 = true;

        this.getNome();//verificar nome
        this.getIdade();//verificar idade
        this.getChip();//verificar Chip
        this.idAnimal  = this.getMaiorIdAnimal(sender,e);// return idAnimal
        this.idAnimal++;// inc idAnimal
        this.idEspecie = this.getIdEspecie(sender, e);// return idEspecie
        this.sexo = this.getSexo(); // return sexo
        this.biDono = getBiDono();
        if (this.flag == true && this.flag2 == true && this.flag3 == true){
            this.idRaca = Convert.ToInt32(this.DropDownLisRaca.SelectedValue.ToString());
            this.verificaUmaNovaEspecie();
            this.verificaNovaRaca();

            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO ANIMAL VALUES ('" + this.idAnimal + "','" + this.idEspecie + "', '" + Convert.ToInt32(this.biDono) + "','" + this.chip + "','" + this.idade + "','" + this.sexo + "','" + this.nome + "','"+this.idRaca+"')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            cmd.ExecuteNonQuery();//Data is accessible through the DataReader object here.

            sqlConnection1.Close();
            Response.Redirect("~/MenuNavegacao/Home.aspx");
        }
    }

    private string getBiDono()
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        string user = User.Identity.Name;
        string bi ="";

        cmd.CommandText = "SELECT BI FROM CLIENTE WHERE [USERNAME] = '"+ user +"'";
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

        return bi;
    }

    /*###############################################*/
    /*#            Testar condicoes                 #*/
    /*###############################################*/
    //verifica nome
    private void getNome(){
        this.nome = this.TextBoxNome.Text;

        if (this.nome.Length <= 0)
        {
            this.flag = false;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "TextBox nome vazio" + "');", true);
        }
    }

    //verifica Idade
    private void getIdade(){
        this.idade = this.TextBoxIdade.Text;

        if (this.idade.Length <= 0){
            this.flag2 = false;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "TextBox nome vazio" + "');", true);
        }
        else{
            try
            {//verificar se um numero ou uma palavra 
                int numero = Convert.ToInt32(this.idade);
            }
            catch (Exception ob)
            {
                flag2 = false;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "TextBox idade com dados incorretos" + "');", true);
            }
        }
    }

    //verifica Chip
    private void getChip(){
        this.chip = this.TextBoxChip.Text;

        if (this.chip.Length <= 0){
            this.flag3 = false;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "TextBox Chip está vazia" + "');", true);
        }
        else{
            try{//verificar se um numero ou uma palavra 
                int numero = Convert.ToInt32(this.chip);
            }
            catch (Exception ob){
                flag3 = false;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "TextBox Chip com dados incorretos" + "');", true);
            }
        }
    }

    //get Sexo
    private string getSexo(){
        string sexo = this.DropDownListSexo.SelectedValue.ToString();
        
        return sexo;
    } 

    /*###############################################*/
    /*#            get Max Id_Animal                #*/
    /*###############################################*/
    // return idAnimal
    private int getMaiorIdAnimal(object sender, EventArgs e){
        int numero = 0;

        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select max(ID_ANIMAL) from ANIMAL";
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
        catch (SqlException ex){// apanhar exccoes exemplo seleciona um id e escreve o nome

        }

        try
        {
            numero = Convert.ToInt32(info);
        }
        catch (Exception ob) {
            numero = 0;
        }
        return numero;
    }
    //return idEspecie
    private int getIdEspecie(object sender, EventArgs e){
        int numero = 0;
        string idAnimal = this.DropDownLisRaca.SelectedValue.ToString();

        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select ID_ESPECIE from RACA where ID_RACA ='"+Convert.ToInt32(idAnimal)+"'";
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
        catch (SqlException ex){// apanhar exccoes exemplo seleciona um id e escreve o nome

        }
        try
        {
            numero = Convert.ToInt32(info);
        }
        catch (Exception ob) {
            numero = 0;
        }

        this.idRaca = numero;
        return numero;
    }


    private int getIdEspecie()
    {
        int numero = 0;
        string idAnimal = this.DropDownLisRaca.SelectedValue.ToString();

        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select ID_ESPECIE from RACA where ID_RACA ='" + idAnimal + "'";
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
        try
        {
            numero = Convert.ToInt32(info);
        }
        catch (Exception ob)
        {
            numero = 0;
        }

        this.idRaca = numero;
        return numero;
    }
    protected void ButtonCancelar_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/MenuNavegacao/Clientes/Animais/Clientes_Animais.aspx");
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.insertAnimal(sender,e);
    }

    /*##################################################*/
    /*#             Insert NovaRaca Especie            #*/
    /*##################################################*/
    //verica se uma nova Especie
    private void verificaUmaNovaEspecie()
    {
        if (this.CheckBoxNovaEspecie.Checked)
        {
            int numero = this.getLastIDEspecie();
            numero++;
            insertDados(numero);
        }
    }

    //verifica se Uma novaRaca
    private void verificaNovaRaca()
    {
        if (this.CheckBoxNovaRaca.Checked)
        {
            this.TextBoxNovaRaca.Enabled = true;
            int numero = this.getLastIDRaca();
            numero++;
            insertDadosRaca(numero);
        }
    }

    //getLastIdRaca
    private int getLastIDRaca()
    {
        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select MAX(ID_RACA) from RACA";
        SqlCommand cmd = new SqlCommand(seleccao, cnn);

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();

        string info = " ";

        try
        {
            int i = 0;
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
        int numero = 1;
        try
        {
            numero = Convert.ToInt32(info);
        }
        catch (Exception e)
        {
            numero = 1;
        } 
        return numero;
    }

    //getLastId
    private int getLastIDEspecie()
    {
        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select MAX(ID_ESPECIE) from ESPECIE";
        SqlCommand cmd = new SqlCommand(seleccao, cnn);

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();

        string info = " ";

        try
        {
            int i = 0;
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
        int numero = 0;
        try
        {
            numero = Convert.ToInt32(info);
        }
        catch (Exception e) {
            numero = 1; 
        } 
       return numero;
    }

    //insert dados Especie
    private void insertDados(int numero)
    {
        SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();


        string nome = this.TextBoxNovaEspecie.Text;

        cmd.CommandText = "INSERT INTO ESPECIE VALUES ('" + numero + "','" + nome + "')";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConnection1;

        sqlConnection1.Open();

        cmd.ExecuteNonQuery();//Data is accessible through the DataReader object here.

        sqlConnection1.Close();
    }

    //insertRaca
    private void insertDadosRaca(int numero)
    {
        SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();


        string nomeInsert = this.TextBoxNovaRaca.Text;
        string perigosa = this.TextBoxPerigosa.Text;
        this.idEspecie = this.getIdEspecie();// return idEspecie

        cmd.CommandText = "INSERT INTO RACA VALUES ('" + numero + "','" + this.idEspecie + "','" + perigosa + "','" + nomeInsert + "')";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConnection1;

        sqlConnection1.Open();

        cmd.ExecuteNonQuery();//Data is accessible through the DataReader object here.

        sqlConnection1.Close();
    }

    private void textExemplo_TextChanged(object sender, EventArgs e)
    {
        TextBoxNovaEspecie.Text = Regex.Replace(TextBoxNovaEspecie.Text, "[^0-9]", "");
    }

}