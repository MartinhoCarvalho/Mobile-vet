using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuNavegacao_Veterinario_Receitas_Passar_Receitas : System.Web.UI.Page
{
    //Atributos
    private string idAnimal;
    private ArrayList arrayMedicamentos = new ArrayList();//array dos medicamentos
    private ArrayList descricoes = new ArrayList();
    //Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtNotes.Text = " ";
        this.idAnimal = Request.QueryString["id"];

    }

    /*########################################################################*/
    /*#                         METODOS ADD MEDICAMENTO                      #*/
    /*########################################################################*/

    //verifica se ja existe o medicamento
    private Boolean verificaMedicamento(int medicamento, int receita)
    {
        Boolean flag = false;

        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select ID_MEDICAMENTO from TOMA where ID_RECEITA ='" + receita + "'";
        SqlCommand cmd = new SqlCommand(seleccao, cnn);

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try
        {
            while (DR.Read())
            {
                info = string.Format("{0} ", DR.GetValue(0));
                int numero;
                try
                {
                    numero = Convert.ToInt32(info);
                }
                catch (Exception ob)
                {
                    DR.Close();
                    cnn.Close();
                    return false;
                }

                if (numero == medicamento)
                {
                    DR.Close();
                    cnn.Close();
                    return true;
                }

            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex)
        {// apanhar exccoes exemplo seleciona um id e escreve o nome

        }
        return flag;
    }

    //Adcionar medicamento
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        int medicamento = Convert.ToInt32(DropDownListMedicamentos.SelectedValue.ToString());

        string descricao = this.txtNotes.Text.ToString();
      
        int idReceita = this.getIDReceita();

        //Preencher a tabela toma
        if (this.verificaMedicamento(medicamento, idReceita) == false)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO TOMA VALUES ('" + medicamento + "','" + idReceita + "','" + descricao + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            cmd.ExecuteNonQuery();//Data is accessible through the DataReader object here.

            sqlConnection1.Close();
        }
    }

    //getIDaConsulta
    private int getIdConsulta()
    {
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

        try
        {
            numero = Convert.ToInt32(info);
        }
        catch (Exception ob)
        {
            numero = 0;
        }
        return numero;
    }

    //get ID Veterinario
    private int getIdVeterinario()
    {
        int numero = 0;

        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select ID_VETERINARIO from VETERINARIO where USERNAME ='" + User.Identity.Name + "'";
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
        return numero;
    }

    //get id Receita
    private int getIDReceita()
    {
        int numero = 0;

        string cnnString = string.Format(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);

        string seleccao = "select max(ID_RECEITA) from RECEITAS";
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
        numero++;
        return numero;
    }

    /*########################################################################*/
    /*#                 METODOS DOS BOTOES FINALIZAR OU CANCELAR             #*/
    /*########################################################################*/

    //Cancelar
    protected void ButtonCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MenuNavegacao/Home.aspx");
    }

    //Finalizar receita
    protected void ButtonConfirmar_Click(object sender, EventArgs e)
    {
        int medicamento = Convert.ToInt32(DropDownListMedicamentos.SelectedValue.ToString());

        string descricao = this.txtNotes.Text.ToString();
        int idAnimal = Convert.ToInt32(this.idAnimal);
        int idVeterinario = this.getIdVeterinario();
        int idReceita = this.getIDReceita();

        //Preencher a tabela toma

        SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "INSERT INTO RECEITAS VALUES ('" + idReceita + "','" + idAnimal + "','" + idVeterinario + "')";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConnection1;

        sqlConnection1.Open();

        cmd.ExecuteNonQuery();//Data is accessible through the DataReader object here.

        sqlConnection1.Close();
        Response.Redirect("~/MenuNavegacao/Home.aspx");
    }
}