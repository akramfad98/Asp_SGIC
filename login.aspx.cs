using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGICUwebApp
{
    public partial class login : System.Web.UI.Page
    {
        static sgicuEntities entity;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                entity= new sgicuEntities();
            }


        }

       

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
                string num= txtCode.Text.ToString();
                string mdp= txtPassword.Text.ToString();

                var lesetudiants = from Etudiant et in entity.Etudiants
                                   where et.codepermanent == num && et.mdp == mdp
                                   select new
                                   {
                                       Numero = et.codepermanent,
                                       Mdp = et.mdp,
                                   };

                if (!lesetudiants.Any()) 
                {

                    lblError.Text = "Code Permanent or Mot de Passe is incorrect.";

                }
                
                else
                {
                    string codepermanent = lesetudiants.First().Numero;

                    
                    Session["codepermanent"] = codepermanent;
                    Response.Redirect("etudiant.aspx");
                }


            

        }
    }
}