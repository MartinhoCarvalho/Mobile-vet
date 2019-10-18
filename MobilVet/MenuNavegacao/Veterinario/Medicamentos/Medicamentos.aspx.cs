using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuNavegacao_Veterinario_Medicamentos_Medicamentos : System.Web.UI.Page{
    private int contador = 0;
    
    protected void Page_Load(object sender, EventArgs e){
        this.LabelMedicamentos.Visible = false;
        this.verificaTabela();
    }
    /*#########################################################*/
    /*#                METODOS MEDICAMENTOS                   #*/
    /*#########################################################*/
    private void verificaTabela(){

        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        string user = User.Identity.Name;
        string bi = "";

        cmd.CommandText = "SELECT * FROM MEDICAMENTOS ";
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
                this.contador++;
            }
            DR.Close();
            cnn.Close();
        }
        catch (SqlException ex){// apanhar exccoes exemplo seleciona um id e escreve o nome

        }

        if (this.contador == 0){
            this.LabelMedicamentos.Text = "Tabela vazia dos medicamentos";
            this.LabelMedicamentos.Visible = true;
            this.GridView1.Visible = false;
        }
    }
    protected void btnAdicionar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MenuNavegacao/Veterinario/Medicamentos/Adcionar_Medicamentos.aspx");
    }
}