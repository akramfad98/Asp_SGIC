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
                                   join Programme prog in entity.Programmes
                                   on et.programme equals prog.IdProgramme
                                   where et.codepermanent == num && et.mdp == mdp
                                   select new
                                   {
                                       Numero = et.codepermanent,
                                       Mdp = et.mdp,
                                       Sess = et.session,
                                       ProgName = prog.nom
                                   };


            if (!lesetudiants.Any()) 
                {

                    lblError.Text = "Code Permanent or Mot de Passe is incorrect.";

                }
                
                else
                {
                    string codepermanent = lesetudiants.First().Numero;
                    string prog = lesetudiants.First().ProgName;
                    Int32 session = Convert.ToInt32(lesetudiants.First().Sess);
                    

                    
                    Session["codepermanent"] = codepermanent;
                    Session["programme"] = prog;
                    Session["session"] = session;
                    Response.Redirect("etudiant.aspx");
                }


            

        }
    }
}