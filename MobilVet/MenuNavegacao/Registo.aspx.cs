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

public partial class MenuNavegacao_Registo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        Roles.AddUserToRole(this.CreateUserWizard1.UserName, "Cliente");

        SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        String bi = ((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Bi")).Text;

        cmd.CommandText = "INSERT INTO CLIENTE (BI, EMAIL, USERNAME, PASSWORD) VALUES ('" + bi + "', '" + this.CreateUserWizard1.Email + "','" + this.CreateUserWizard1.UserName + "','" + this.CreateUserWizard1.Password + "')";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConnection1;

        sqlConnection1.Open();

        cmd.ExecuteNonQuery();//Data is accessible through the DataReader object here.

        sqlConnection1.Close();

    }
}