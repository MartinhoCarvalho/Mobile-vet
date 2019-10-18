using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuNavegacao_Login : System.Web.UI.Page{

    protected void Page_Load(object sender, EventArgs e){
        this.Label3.Visible = false;
        this.esconderLabels();
    }

    /*##################################################*/
    /*#                 ESCONDER LABELS                #*/
    /*##################################################*/
    private void esconderLabels(){
        if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated){
            this.Label1.Visible     = false;
            this.Label2.Visible     = false;
            this.HyperLink1.Visible = false;
            this.Label3.Visible     = true;
        }
    }
}