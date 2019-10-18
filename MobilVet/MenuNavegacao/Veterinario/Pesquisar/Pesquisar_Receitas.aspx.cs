using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuNavegacao_Veterinario_Pesquisar_Pesquisar_Receitas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.DropDownList1.SelectedItem.Text == "Especíe")
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM ANIMAL, ESPECIE, RACA WHERE ANIMAL.ID_ESPECIE = ESPECIE.ID_ESPECIE AND ANIMAL.ID_RACA = RACA.ID_RACA AND ESPECIE.NOME = '"+ this.TextBox1.Text+"'";
        }
        if (this.DropDownList1.SelectedItem.Text == "Raça")
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM ANIMAL, ESPECIE, RACA WHERE ANIMAL.ID_ESPECIE = ESPECIE.ID_ESPECIE AND ANIMAL.ID_RACA = RACA.ID_RACA AND RACA.NOME = '" + this.TextBox1.Text + "' ";
        }
        if (this.DropDownList1.SelectedItem.Text == "Idade")
        {
            Boolean flag = true;
            try
            {
                int numero = Convert.ToInt32(TextBox1.Text.ToString());
            }
            catch (Exception ob) {
                flag = false;
            }

            if (flag == true)
            {
                SqlDataSource1.SelectCommand = "SELECT * FROM ANIMAL, ESPECIE, RACA WHERE ANIMAL.ID_ESPECIE = ESPECIE.ID_ESPECIE AND ANIMAL.ID_RACA = RACA.ID_RACA AND ANIMAL.IDADE = '" + this.TextBox1.Text + "' ";
            }
        }
        if (this.DropDownList1.SelectedItem.Text == "Nome")
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM ANIMAL, ESPECIE, RACA WHERE ANIMAL.ID_ESPECIE = ESPECIE.ID_ESPECIE AND ANIMAL.ID_RACA = RACA.ID_RACA AND ANIMAL.NOME = '" + this.TextBox1.Text + "' ";
        }

    }
}