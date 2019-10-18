using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuNavegacao_Veterinario_Pesquisar_Pesquisar_Medicamentos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.DropDownList1.SelectedItem.Text == "ID")
        {
            Boolean flag = true;
            try
            {
                int numero = Convert.ToInt32(TextBox1.Text.ToString());
            }
            catch (Exception ob)
            {
                flag = false;
            }

            if (flag == true)
            {
                SqlDataSource1.SelectParameters["ID_MED"].DefaultValue = this.TextBox1.Text;
            }
        }
        if (this.DropDownList1.SelectedItem.Text == "Nome")
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT ID_MEDICAMENTO FROM MEDICAMENTOS WHERE [NOME] = '" + this.TextBox1.Text + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cnn.Open();

            SqlDataReader DR = cmd.ExecuteReader();
            string id = " ";

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

            SqlDataSource1.SelectParameters["ID_MED"].DefaultValue = id;
        }
    }
    
}