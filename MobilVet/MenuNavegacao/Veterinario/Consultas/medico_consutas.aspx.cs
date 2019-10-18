using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuNavegacao_Veterinario_Consultas_medico_consutas : System.Web.UI.Page
{
    //Atributos
    private string data, date, teste;

    //Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        this.verificaDataAnteriores();//verificar se tem datas anteriores

        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        string user = User.Identity.Name;
        string id = "";

        cmd.CommandText = "SELECT ID_VETERINARIO FROM VETERINARIO WHERE [USERNAME] = '" + user + "'";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try
        {
            while (DR.Read())
            {
                id = string.Format("{0} ", DR.GetValue(0));

            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex)
        {// apanhar exccoes exemplo seleciona um id e escreve o nome

        }

        this.SqlDataSource1.SelectParameters["ID_VETERINARIO"].DefaultValue = id;
        this.SqlDataSource1.SelectParameters["DATA_CONSULTA"].DefaultValue = this.Calendar1.SelectedDate.ToShortDateString();
        this.Calendar1.Visible = true;
    }

    public void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        // If multiple ButtonField column fields are used, use the
        // CommandName property to determine which button was clicked.
        if (e.CommandName == "btnTerminar")
        {
            // Convert the row index stored in the CommandArgument
            // property to an Integer.
            int index = Convert.ToInt32(e.CommandArgument);

            // Get the last name of the selected author from the appropriate
            // cell in the GridView control.
            GridViewRow selectedRow = GridView1.Rows[index];
            TableCell idCondulta = selectedRow.Cells[0];

            string id = idCondulta.Text;

            // Display the selected author.


            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE [CONSULTA] SET [ESTADO] = '" + " Concluída" + "' WHERE [ID_CONSULTA] = '" + id + "' ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            GridView1.DataBind();
        }
        if (e.CommandName == "btnReceita")
        {
            // Convert the row index stored in the CommandArgument
            // property to an Integer.
            int index = Convert.ToInt32(e.CommandArgument);

            // Get the last name of the selected author from the appropriate
            // cell in the GridView control.
            GridViewRow selectedRow = GridView1.Rows[index];
            TableCell idCondulta = selectedRow.Cells[1];

            string id = idCondulta.Text;


            Response.Redirect("~/MenuNavegacao/Veterinario/Receitas/Passar_Receitas.aspx?id=" + id);
        }

    }

    /*########################################################################*/
    /*#                METODO DE VERIFICAR DATAS DAS CONSULTAS               #*/
    /*########################################################################*/
    //verifica datas anterirores
    private void verificaDataAnteriores()
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        int idVet = this.getIdVeterinario();

        string user = User.Identity.Name;

        cmd.CommandText = "SELECT DATA FROM CONSULTA where ID_VETERINARIO = '" + idVet + "'";
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

                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                //cortar as horas da data
                for (int i = 0; i < 10; i++)
                {
                    sb.Append(info[i]);
                }

                this.date = DateTime.Today.ToShortDateString();
                this.data = sb.ToString();

                DateTime myDate = DateTime.ParseExact(data, "dd/MM/yyyy", null);

                if (myDate < DateTime.Today)
                {
                    this.mudarEstadoDaConsulta(info);
                }
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex)
        {// apanhar exccoes exemplo seleciona um id e escreve o nome

        }
    }

    //get id do veterinario
    private int getIdVeterinario()
    {
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
            idVet = Convert.ToInt32(info);
        }
        catch (Exception e)
        {
            idVet = 0;
        }



        return idVet;
    }

    //mudar o estado da consulta
    private int getIdConsulta(string data)
    {
        int id = 0;
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        int idVet = this.getIdVeterinario();

        string user = User.Identity.Name;

        cmd.CommandText = "SELECT ID_CONSULTA FROM CONSULTA where ID_VETERINARIO = '" + idVet + "' AND DATA = '" + data + "'";
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
            id = Convert.ToInt32(info);

        }
        catch (Exception e)
        {
            id = 0;
        }
        return id;
    }

    //private void mudar estdo
    private void mudarEstadoDaConsulta(string data)
    {
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