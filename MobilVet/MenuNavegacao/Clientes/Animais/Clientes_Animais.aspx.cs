using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class MenuNavegacao_Clientes_Clientes_ListarAnimais : System.Web.UI.Page
{
    //ATRIBUTOS
    //private DropDownList dropDownPanel = new DropDownList();
    //String pesquisa;
    //private string message = " ";

    /*Construtor da Pagina*/
    protected void Page_Load(object sender, EventArgs e){

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

        this.SqlDataSource2.SelectParameters["BI_DONO"].DefaultValue = bi;
    
    }
}
