using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////this.jQuery();//METODO que eu criei

        //SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDadosMobilVet"].ConnectionString);
        //SqlCommand cmd = new SqlCommand();
        //SqlDataReader reader;


        //String nome = "ze";

        //cmd.CommandText = "INSERT INTO ESPECIE VALUES (4,'" + nome + "')";
        //cmd.CommandType = CommandType.Text;
        //cmd.Connection = sqlConnection1;

        //sqlConnection1.Open();

        //cmd.ExecuteNonQuery();
        ////Data is accessible through the DataReader object here.

        //sqlConnection1.Close();

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {

    }


    protected void headerMenuNavigation_MenuItemClick(object sender, EventArgs e)
    {

    }

    protected bool AuthenticateAD()
    {
        return false;
    }


    protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
    {


    }


    protected void OnLoggedIn(object sender, EventArgs e)
    {
        // LoginUser.VisibleWhenLoggedIn = false;
    }


    protected void OnLogout(object sender, EventArgs e)
    {
        Session["NUMERO_USER"] = "Não existe";
        Session["USER_LOGADO"] = "Não existe";
        Session["USER_ROLE"] = "Não existe";
    }

    protected void headerMenuNavigation_MenuItemClick(object sender, MenuEventArgs e)
    {

    }

    private void jQuery()
    {
        ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
        myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
        myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
        myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
        myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);
    }




}
