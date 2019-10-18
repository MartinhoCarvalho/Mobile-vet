using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class MenuNavegacao_Clientes_Animais_Editar : System.Web.UI.Page{
    private int contador = 0;
    private Boolean flag = false;
    private  static Boolean flagCheckBoxEspecie;
    private Boolean flagcheckBoxRaca = false;
    private string chip,idade,idEspecie,idRaca;
    private String idAnimal, nome;
    private string[] Racas;
    

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

        //label = false
        this.LabelNome.Visible    =  false;
        this.TextBoxNome.Visible  =  false;
        this.LabelSexo.Visible    =  false;
        this.LabelChip.Visible    =  false;
        this.LabelIdade.Visible   =  false;
        this.LabelEspecie.Visible =  false;
        this.LabelRaca.Visible    =  false;

        //dropDwonList  = false
        this.DropDownListSexo.Visible     = false;
        this.DropDownListEspecie.Visible  = false;
        this.DropDownLisRaca.Visible      = false;

        //testBox  = false
        this.TextBoxChip.Visible  = false;
        this.TextBoxIdade.Visible = false;

        //botoes
        this.ButtonConfirmar.Visible = false;
        this.ButtonCancelar.Visible  = false;

        //Nova Especie
        this.CheckBoxNovaEspecie.Visible = false;
        this.LabelEspNova.Visible = false;
        this.LabelNovaEspecie.Visible = false;
        this.TextBoxNovaEspecie.Visible = false;

        //Nova Raca
        this.CheckBoxNovaRaca.Visible = false;
        this.LabelNovaRaca.Visible    = false;
        this.TextBoxNovaRaca.Visible  = false;
        this.LabelPerigosa.Visible    = false;
        this.TextBoxPerigosa.Visible  = false;
        this.LabelRacaNova.Visible    = false;

   
       
    }

    /*##################################################*/
    /*#                 Metodos                        #*/
    /*##################################################*/
    //getIDade
    private string getIDade(string id)
    {
   

        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select IDADE from ANIMAL WHERE ID_ANIMAL ='" + id + "'";
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

        return info;
    }
    //getChip
    private string getChip(string id)
    {
  

        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select CHIP from ANIMAL WHERE ID_ANIMAL ='" + id + "'";
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
        return info;
    }

    //get Nonme
    private string getNome(string id)
    {
        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select NOME from ANIMAL WHERE ID_ANIMAL ='" + id + "'";
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
        return info;
    }

    //getIDEspecie
    private string getEspecie(string id){

        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select ID_ESPECIE from ANIMAL WHERE ID_ANIMAL ='"+id+"'";
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
        return info;
    }

    //getRaca
    private string getRaca(string id){
        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select ID_RACA from RACA WHERE ID_ESPECIE ='" + id + "'";
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
        return info;
    
    
    
    }

 
    //botao editar
    protected void ButtonEdtitar_Click(object sender, EventArgs e){
        //label = false
        this.LabelNome.Visible = true;
        this.TextBoxNome.Visible = true;
        this.LabelSexo.Visible = true;
        this.LabelChip.Visible = true;
        this.LabelIdade.Visible = true;
        this.LabelEspecie.Visible = true;
        this.LabelRaca.Visible = true;

        //dropDwonList  = false
        this.DropDownListSexo.Visible = true;
        this.DropDownListEspecie.Visible = true;
        this.DropDownLisRaca.Visible = true;

        //testBox  = false
        this.TextBoxChip.Visible = true;
        this.TextBoxIdade.Visible = true;

        //botoes
        this.ButtonConfirmar.Visible = true;
        this.ButtonCancelar.Visible = true;

        //Nova Especie
        this.CheckBoxNovaEspecie.Visible = true;
        this.LabelEspNova.Visible = true;
        this.TextBoxNovaEspecie.Visible = true;

        //Nova Raca
        this.CheckBoxNovaRaca.Visible = true;
        this.LabelNovaRaca.Visible = true;
        this.TextBoxNovaRaca.Visible = true;
        this.LabelPerigosa.Visible = true;
        this.TextBoxPerigosa.Visible = true;
        this.LabelNovaEspecie.Visible = true;
        this.LabelRacaNova.Visible  = true;

        this.insertDadosNaTextBoxDropDownList();
    }

    /*##################################################*/
    /*#                 Conexoes                       #*/
    /*##################################################*/
    //mudar os valores no formulario
    private void insertDadosNaTextBoxDropDownList()
    {
        //nome
        this.idAnimal = DropDownListEditar.SelectedValue.ToString();
        this.nome = this.getNome(this.idAnimal);
        this.TextBoxNome.Text = this.nome;


        //chip
        this.chip = this.getChip(this.idAnimal);
        this.TextBoxChip.Text = this.chip;

        //idade
        this.idade = this.getIDade(this.idAnimal);
        this.TextBoxIdade.Text = this.idade;

        //idEspecie mudar o selected
        this.idEspecie = this.getEspecie(this.idAnimal);
        int numero = Convert.ToInt32(this.idEspecie);
        this.DropDownListEspecie.ClearSelection();
        this.DropDownListEspecie.SelectedValue = "" + numero;


        //idRaca mudar o selected
        this.idRaca = this.getRaca(this.idEspecie);

    }

    //inserir dados nas tabelas
    protected void Button1_Click(object sender, EventArgs e){
        //verificar se e uma nova especie ou raca
        this.verificaNovaRaca();
        this.verificaUmaNovaEspecie();

  
        
        SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        String nome, sexo, chip, idade;


        sexo = this.DropDownListSexo.SelectedValue.ToString();
        //idade = this.TextBoxIdade.Text;
        chip = this.TextBoxChip.Text;
      
        string valor = this.DropDownListEditar.SelectedValue.ToString();
        string valor3;
        string valor2;
        if (MenuNavegacao_Clientes_Animais_Editar.flagCheckBoxEspecie == true)
        {
            valor2 = ""+this.getLastIDEspecie();
            valor3 = "" + this.getLastIDRaca();
        }
        else{
            valor2 = this.DropDownListEspecie.SelectedValue.ToString();
            valor3 = this.DropDownLisRaca.SelectedValue.ToString();
        }
        
       

        Boolean flag = true, flag2 = true;

        if (this.TextBoxNome.Text.Length <= 0)
        {
            nome = this.getNome(valor);
        }
        else
        {
            nome = this.TextBoxNome.Text;
        }


        if (this.TextBoxIdade.Text.Length <= 0)
        {
            idade = this.getIDade(valor);
        }
        else
        {
            idade = this.TextBoxIdade.Text;
            try
            {
                int numero = Convert.ToInt32(idade);
            }
            catch (Exception ob)
            {
                flag = false;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Idade incorreta" + "');", true);
            }
        }

        if (this.TextBoxChip.Text.Length <= 0)
        {
            chip = this.getChip(valor);
        }
        else
        {
            chip = this.TextBoxChip.Text;

            int numero;
            try
            {
                numero = Convert.ToInt32(chip);
            }
            catch (Exception ob)
            {
                flag2 = false;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "CHIP incorreto" + "');", true);
            }
        }

        if (flag == true && flag2 == true)
        {
            //cmd.CommandText = "INSERT INTO ESPECIE VALUES (4,'" + nome + "')";
            cmd.CommandText = "update ANIMAL set NOME = '" + nome + "',SEXO = '" + sexo + "',CHIP = '" + chip + "',ID_ESPECIE = '" + valor2 + "', IDADE  = '" + idade + "'  where ID_ANIMAL = '" + valor + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            cmd.ExecuteNonQuery();
            //Data is accessible through the DataReader object here.

            sqlConnection1.Close();

            cmd.CommandText = "update RACA set ID_ESPECIE ='" + valor2+ "' where ID_RACA = '" +valor3+ "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            cmd.ExecuteNonQuery();
            //Data is accessible through the DataReader object here.

            sqlConnection1.Close();

            Response.Redirect("~/MenuNavegacao/Clientes/Animais/Clientes_Animais.aspx");
        }
    }

    /*##################################################*/
    /*#             Insert NovaRaca Especie            #*/
    /*##################################################*/
    //verica se uma nova Especie
    private void verificaUmaNovaEspecie(){
        if (this.CheckBoxNovaEspecie.Checked){
            int numero = this.getLastIDEspecie();
            numero++;
            insertDados(numero);
            MenuNavegacao_Clientes_Animais_Editar.flagCheckBoxEspecie = true;
        }    
    }

    //verifica se Uma novaRaca
    private void verificaNovaRaca(){
        if (this.CheckBoxNovaRaca.Checked){
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
        int numero = Convert.ToInt32(info);
        return numero;
    }

    //getLastId
    private int getLastIDEspecie(){
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
        int numero = Convert.ToInt32(info);
        return numero;
    }

    //insert dados Especie
    private void insertDados(int numero){
        SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();


        string nome = this.TextBoxNovaEspecie.Text;

        cmd.CommandText = "INSERT INTO ESPECIE VALUES ('"+numero+"','"+nome+"')";
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
        int idEsp = this.getLastIDEspecie();

        cmd.CommandText = "INSERT INTO RACA VALUES ('" + numero + "','" + idEsp + "','" + perigosa + "','" + nomeInsert + "')";
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