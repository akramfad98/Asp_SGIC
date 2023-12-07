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
        static string numcours;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                entity = new sgicuEntities();
                btnModifier.Visible = false;
                btnSupprimer.Visible = false;

                lstcoursPreq.Visible = false;
                RemplirAllcours();


            }
        }

        private void RemplirAllcours()
        {
            var lesCours = from Cour unCours in entity.Cours
                           select new
                           {
                               Numero = unCours.numcours,
                               Titre = unCours.titre,
                           };

            ListBox1.DataSource = lesCours.ToList();
            ListBox1.DataTextField = "Titre";
            ListBox1.DataValueField = "Numero";
            ListBox1.DataBind();
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {



            string numero = txtNumero.Text.ToString();
            string titre = txtTitre.Text.ToString();
            Int32 idProf = Convert.ToInt32(listenseignant.SelectedValue);
            string prerequis = "";
            if (radList.SelectedValue == "Oui")
            {
                prerequis = lstcoursPreq.SelectedValue.ToString();

            }
            else if (radList.SelectedValue == "Non") { prerequis = null; }
            Int32 session = Convert.ToInt32(listSession.SelectedValue);
            Int32 programme = Convert.ToInt32(lstProgrammes.SelectedValue);
            Int32 nbrHeures = Convert.ToInt32(txtHeures.Text.ToString());
            string description = txtDesc.Text.ToString();
            bool exist = false;
            foreach (Cour cours_existant in entity.Cours)
            {
                if (cours_existant.numcours.ToString() == numero)
                {
                    exist = true;
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
                txtNumero.Text = "";
                txtTitre.Text = "";
                txtDesc.Text = "";
                txtHeures.Text = "";
                lblErreur.Text = "Cours ajouté avec succés";

            }
            else
            {
                lblErreur.Text = "Cours déja ajouté";
            }

            RemplirAllcours();

        }

        protected void radList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radList.SelectedValue == "Oui")
            {

                lstcoursPreq.Visible = true;
            }
            else { lstcoursPreq.Visible = false; }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numcours = ListBox1.SelectedValue.ToString();
            btnModifier.Visible = true;
            btnSupprimer.Visible = true;



            var lescours = from Cour cours in entity.Cours
                           where cours.numcours == numcours
                           select cours;

            var myCourse = lescours.First();

            if (myCourse == null) { lblErreur.Text = "vide"; }
            else
            {
                txtNumero.Text = myCourse.numcours.ToString();
                txtTitre.Text = myCourse.titre.ToString();

                txtDesc.Text = myCourse.description?.ToString() ?? "";
                txtHeures.Text = myCourse.heures?.ToString() ?? "";
                if (myCourse.prerequis != null)
                {

                    lstcoursPreq.SelectedValue = myCourse.prerequis.ToString();
                }


                if (myCourse.programme != null)
                {
                    lstProgrammes.SelectedValue = myCourse.programme.ToString();
                }



            }




        }

        protected void btnSupprimer_Click(object sender, EventArgs e)
        {
            numcours = ListBox1.SelectedValue.ToString();

            var lescours = from Cour cours in entity.Cours
                           where cours.numcours == numcours
                           select cours;

            var myCourse = lescours.First();

            entity.Cours.Remove(myCourse);
            entity.SaveChanges();
            lblErreur.Text = "Cours supprimé avec succés";
            RemplirAllcours();

        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {

            Cour unCour = entity.Cours.Find(numcours);
            unCour.numcours = txtNumero.Text;
            unCour.titre = txtTitre.Text;
            unCour.heures = Convert.ToInt32(txtHeures.Text);
            unCour.description = txtDesc.Text;
            unCour.prerequis = lstcoursPreq.SelectedValue.ToString();
            unCour.session = Convert.ToInt32(listSession.SelectedValue);
            unCour.programme = Convert.ToInt32(lstProgrammes.SelectedValue);

            entity.SaveChanges();
            lblErreur.Text = "Cours modifié avec succés";
            RemplirAllcours();
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            btnModifier.Visible = false;
            btnSupprimer.Visible = false;
            txtNumero.Text = "";
            txtTitre.Text = "";
            txtDesc.Text = "";
            txtHeures.Text = "";

        }
    }
}