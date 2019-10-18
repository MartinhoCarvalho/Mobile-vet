using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuNavegacao_Clientes_Perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LabelDetailsViewNoNulls.Visible = false;
        if (IsPostBack)
        {
            this.SqlDataSource1.SelectParameters["username"].DefaultValue = User.Identity.Name;
        }
        this.SqlDataSource1.SelectParameters["username"].DefaultValue = User.Identity.Name;
    }

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        if (e.NewValues["BI"] == null)
        {
            this.LabelDetailsViewNoNulls.Visible = true;

            this.LabelDetailsViewNoNulls.Text = "BI com valor nulo";
            e.Cancel = true;
        }
        else
        {
            this.checkCampos("BI", e);
        }

        if (e.NewValues["NIF"] == null)
        {
            this.LabelDetailsViewNoNulls.Visible = true;

            this.LabelDetailsViewNoNulls.Text = "NIF com valor nulo";
            e.Cancel = true;
        }
        else
        {
            this.checkCampos("NIF", e);
        }

        if (!checkString(e.NewValues["NOME"].ToString()))
        {
            this.LabelDetailsViewNoNulls.Visible = true;

            this.LabelDetailsViewNoNulls.Text = "NOME com valor nulo";
            e.Cancel = true;
        }

        if (!checkString(e.NewValues["MORADA"].ToString()))
        {
            this.LabelDetailsViewNoNulls.Visible = true;

            this.LabelDetailsViewNoNulls.Text = "MORADA com valor nulo";
            e.Cancel = true;
        }

        //if (!checkString(e.NewValues["EMAIL"].ToString()))
        //{
        //    this.LabelDetailsViewNoNulls.Visible = true;

        //    this.LabelDetailsViewNoNulls.Text = "EMAIL com valor nulo";
        //    e.Cancel = true;
        //}

        if (e.NewValues["TELEFONE"] == null)
        {
            this.LabelDetailsViewNoNulls.Visible = true;

            this.LabelDetailsViewNoNulls.Text = "TELEFONE com valor nulo";
            e.Cancel = true;
        }
        else
        {
            this.checkCampos("TELEFONE", e);
        }

        if (e.NewValues["IDADE"] == null)
        {
            this.LabelDetailsViewNoNulls.Visible = true;

            this.LabelDetailsViewNoNulls.Text = "IDADE com valor nulo";
            e.Cancel = true;
        }
        else
        {
            this.checkCampos("IDADE", e);
        }

        //if (!checkString(e.NewValues["USERNAME"].ToString()))
        //{
        //    this.LabelDetailsViewNoNulls.Visible = true;

        //    this.LabelDetailsViewNoNulls.Text = "USERNAME com valor nulo";
        //    e.Cancel = true;
        //}

        //if (!checkString(e.NewValues["PASSWORD"].ToString()))
        //{
        //    this.LabelDetailsViewNoNulls.Visible = true;

        //    this.LabelDetailsViewNoNulls.Text = "PASSWORD com valor nulo";
        //    e.Cancel = true;
        //}

    }

    //check campos
    private void checkCampos(String campo, DetailsViewUpdateEventArgs e)
    {
        try
        {//verificar se um numero ou uma palavra 
            int numero = Convert.ToInt32(e.NewValues[campo].ToString());
        }
        catch (Exception ob)
        {
            this.LabelDetailsViewNoNulls.Visible = true;
            this.LabelDetailsViewNoNulls.Text = campo + " com valores incorretos";
            e.Cancel = true;
        }
    }

    public bool checkString(string s)
    {
        if (s.Trim().Equals(""))
            return false;
        else
            return true;
    }
}