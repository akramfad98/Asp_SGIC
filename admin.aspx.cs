using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGICUwebApp
{
    public partial class admin : System.Web.UI.Page
    {
        static sgicuEntities entity;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                lstcoursPreq.Visible= false;
                entity = new sgicuEntities();

            }
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {



            string numero = txtNumero.Text.ToString();
            string titre = txtTitre.Text.ToString();
            Int32 idProf = Convert.ToInt32(listenseignant.SelectedValue);
            string prerequis = "";
            if (radList.SelectedValue== "Oui")
            {
                prerequis= lstcoursPreq.SelectedValue.ToString();

            }
            else if (radList.SelectedValue == "Non") { prerequis = null; }
            Int32 session= Convert.ToInt32(listSession.SelectedValue);
            Int32 programme = Convert.ToInt32(lstProgrammes.SelectedValue);
            Int32 nbrHeures= Convert.ToInt32(txtHeures.Text.ToString());
            string description = txtDesc.Text.ToString();
            bool exist = false;
            foreach ( Cour cours_existant in entity.Cours)
            {
                if (cours_existant.numcours.ToString()== numero)
                {
                    exist= true;
                }

            }


            if (exist == false)
            {



                Cour cours = new Cour();
                cours.numcours = numero;
                cours.titre = titre;
                cours.session = session;
                cours.programme = programme;
                cours.prerequis = prerequis;
                cours.heures = nbrHeures;
                cours.description = description;

                Enseignement enseignement = new Enseignement();
                enseignement.numcours = numero;
                enseignement.idEnseignant = idProf;

                entity.Cours.Add(cours);
                entity.Enseignements.Add(enseignement);
                entity.SaveChanges();
            }
            else
            {
                lblErreur.Text = "Cours déja ajouté";
            }
            

        }

        protected void radList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radList.SelectedValue== "Oui")
            {

                lstcoursPreq.Visible = true;
            }
            else { lstcoursPreq.Visible = false;}
        }
    }
}