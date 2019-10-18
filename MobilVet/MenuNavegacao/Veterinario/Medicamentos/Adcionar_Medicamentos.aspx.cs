using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuNavegacao_Veterinario_Medicamentos_Adcionar_Medicamentos : System.Web.UI.Page{
    //Atributos
    private int contador = 0;

    //Page load
    protected void Page_Load(object sender, EventArgs e){ }

    /*#####################################################################*/
    /*#                         METODOS                                   #*/
    /*#####################################################################*/
    //Adicionar medicamento
    protected void Button1_Click(object sender, EventArgs e){
        //inserir valor na tabela de medicamentos
        string nome = this.TextBox1.Text.ToString();

        int numeroId = this.getNumeroIdMedicamento();

        SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = "INSERT INTO MEDICAMENTOS VALUES ('" + numeroId + "','" + nome + "')";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConnection1;

        sqlConnection1.Open();

        cmd.ExecuteNonQuery();//Data is accessible through the DataReader object here.

        sqlConnection1.Close();
        Response.Redirect("~/MenuNavegacao/Veterinario/Medicamentos/Medicamentos.aspx");
    }

    //get o numero do medicamento ID
    private int getNumeroIdMedicamento(){
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        string user = User.Identity.Name;

        cmd.CommandText = "SELECT MAX(ID_MEDICAMENTO) FROM MEDICAMENTOS ";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = cnn;

        cnn.Open();

        SqlDataReader DR = cmd.ExecuteReader();
        string info = " ";

        try{
            while (DR.Read()){
                info = string.Format("{0} ", DR.GetValue(0));
                this.contador++;
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex){// apanhar exccoes exemplo seleciona um id e escreve o nome

        }
        try
        {
            contador = Convert.ToInt32(info);
        }
        catch ( Exception e){
            contador = 0;
        
        }
        this.contador++;//incrementar mais um numero
        return contador;
    }
}