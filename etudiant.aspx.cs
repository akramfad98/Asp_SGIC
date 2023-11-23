using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGICUwebApp
{
    public partial class etudiant : System.Web.UI.Page
    {
        static sgicuEntities entity;
        static string code;
        static string progname;
        static string sess;
        static Etudiant etud;
        static string numCours;
        static string numcoursAabondonner;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (Session["codepermanent"] != null)
                {
                    code = Session["codepermanent"].ToString();
                    progname = Session["programme"].ToString();
                    sess= Session["session"].ToString();


                }
                else
                {

                    Response.Redirect("login.aspx");
                }

                entity = new sgicuEntities();

                var lesetudiants = from Etudiant et in entity.Etudiants
                                   where et.codepermanent == code
                                   select et;
                etud = lesetudiants.First();

                lblWlcm.Text = etud.nom.ToString();
                lblInfo.Text = "<b>Programme :</b> " + progname + "<br/><b>Session :</b> " + sess;
                




                RemplirListCours();
                RemplirValidation();
                RemplirMesCours();
                btnAbandonner.Visible = false;





            }

        }

        private void RemplirMesCours()
        {
            var lesinscriptions = (from Inscription ins in entity.Inscriptions
                                   join name in entity.Cours on ins.numcours equals name.numcours
                                   where ins.codepermanent == code
                                   select new
                                   {
                                       NumCours = ins.numcours,
                                       Titre = name.titre,
                                       DateInsc = ins.dateInsription
                                       //FullInfo = $"{ins.numcours} - {name.titre} ({ins.dateInsription})"

                                   }).ToList();

            lstMesCours.DataSource = lesinscriptions.ToList();
            lstMesCours.DataValueField = "NumCours";
            lstMesCours.DataTextField = "Titre";
            lstMesCours.DataBind();

            foreach (ListItem item in lstMesCours.Items)
            {
                var courseInfo = lesinscriptions
                    .Where(info => info.NumCours == item.Value)
                    .Select(info => $"{info.NumCours} - {info.Titre} ({info.DateInsc})")
                    .FirstOrDefault();

                item.Text = courseInfo;
            }





        }

        private void RemplirValidation()
        {
            var lesnumcoursValide = from Validation val in entity.Validations
                                    where val.etudiant == code
                                    select val.numcours;

            List<dynamic> tousLesCoursValides = new List<dynamic>();


            foreach (String numcours in lesnumcoursValide)
            {
                var lescoursValide = from cours in entity.Cours
                                     join prog in entity.Programmes on cours.programme equals prog.IdProgramme
                                     join prereq in entity.Cours on cours.prerequis equals prereq.numcours into prereqs
                                     from prereq in prereqs.DefaultIfEmpty()
                                     where cours.numcours == numcours
                                     select new
                                     {
                                         NumCours = cours.numcours,
                                         Titre = cours.titre,
                                         ProgrammeName = prog.nom,
                                         Prerequis = prereq != null ? prereq.titre : "None",
                                         Heures = cours.heures,
                                         Session = cours.session,
                                         Desc = cours.description

                                     };

                tousLesCoursValides.AddRange(lescoursValide);
            }

            coursValide.DataSource = tousLesCoursValides;
            coursValide.DataBind();
        }

        private void RemplirListCours()
        {
            Int32 programme = Convert.ToInt32(etud.programme);

            var inscribedCourses = entity.Inscriptions
                                        .Where(ins => ins.codepermanent == etud.codepermanent)
                                        .Select(ins => ins.numcours)
                                        .ToList();

            var validatedCourses = entity.Validations
                                       .Where(val => val.etudiant == etud.codepermanent)
                                       .Select(val => val.numcours)
                                       .ToList();

            var coursduprogramme = from cours in entity.Cours
                                   where cours.programme == programme && !inscribedCourses.Contains(cours.numcours) && !validatedCourses.Contains(cours.numcours)
                                   select cours;

            lstCours.DataSource = coursduprogramme.ToList();
            lstCours.DataBind();

        }

        protected void lstCours_SelectedIndexChanged(object sender, EventArgs e)
        {
            numCours = lstCours.SelectedValue.ToString();

            var lescours = from cours in entity.Cours
                           join prog in entity.Programmes on cours.programme equals prog.IdProgramme
                           join prereq in entity.Cours on cours.prerequis equals prereq.numcours into prereqs
                           from prereq in prereqs.DefaultIfEmpty()
                           where cours.numcours == numCours
                           select new
                           {
                               NumCours = cours.numcours,
                               Titre = cours.titre,
                               ProgrammeName = prog.nom,
                               Prerequis = prereq != null ? prereq.titre : "None",
                               Session = cours.session,
                               Heures = cours.heures,
                               Description = cours.description
                           };

            var chosenCourse = lescours.FirstOrDefault();
            if (chosenCourse != null)
            {
                infoCours.DataSource = new List<dynamic> { chosenCourse };
                infoCours.DataBind();
            }





        }

        protected void btnAbandonner_Click(object sender, EventArgs e)
        {
            var mesinscriptions = from Inscription ins in entity.Inscriptions
                                  where ins.numcours == numcoursAabondonner && ins.codepermanent == code
                                  select ins;


            var monInscription = mesinscriptions.FirstOrDefault();
            var maDateInscription = mesinscriptions.FirstOrDefault().dateInsription;


            if (maDateInscription != null) {
                
                    TimeSpan duration = DateTime.Today - maDateInscription.Value;

                    if (duration.Days > 30)
                    {
                        lblError.Text = "Délai passé! Vous ne pouvez plus abondonner ce cours, veuillez contacter ladministration";
                    }
                    else
                    {
                        entity.Inscriptions.Remove(monInscription);
                        entity.SaveChanges();
                        RemplirMesCours();
                        lblError.Text = "Vous avez abbondonné ce cours";
                    }
            }








            }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            var lescoursAjout = from Cour courschoisi in entity.Cours
                                where courschoisi.numcours == numCours
                                select courschoisi;

            var chosenAjout = lescoursAjout.FirstOrDefault();

            var lesValidations = from Validation val in entity.Validations
                                 where val.etudiant == code
                                 select val;

            var lesInscriptions = from Inscription insi in entity.Inscriptions
                                  where insi.codepermanent == code
                                  select insi;

            bool preqDone = true;

            if (chosenAjout.session > etud.session)
            {
                lblError.Text = "Vous ne pouvez pas ajouter un cours d'une session supérieure!";
                return;  
            }

            if (chosenAjout.prerequis != null)
            {
                // Check if the prerequisite course has been validated by the student
                preqDone = lesValidations.Any(val => val.numcours == chosenAjout.prerequis);
            }

            if (!preqDone)
            {
                lblError.Text = "Vous ne pouvez pas ajouter ce cours, il faut valider son prérequis!";
                return;  
            }

            Inscription ins = new Inscription();
            ins.numcours = chosenAjout.numcours;
            ins.codepermanent = etud.codepermanent;
            ins.dateInsription = DateTime.Today.Date;

            if (lesInscriptions.Any(inscription => inscription.numcours == ins.numcours))
            {
                lblError.Text = "Vous avez déjà ajouté ce cours";
            }
            else
            {
                entity.Inscriptions.Add(ins);
                entity.SaveChanges();
                lblError.Text = "Vous avez été inscrit à ce cours avec succès";
                RemplirMesCours();
            }
        }

        protected void lstMesCours_SelectedIndexChanged(object sender, EventArgs e)
            {

                numcoursAabondonner = lstMesCours.SelectedValue.ToString();
                btnAbandonner.Visible = true;

            }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
            Session.Clear();

            
            Response.Redirect("login.aspx");
        }
    }
    }
