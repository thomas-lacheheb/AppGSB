using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppGSB.ClassesMetier
{
    public class GstWebServices
    {
        // Membres privés de la classe
        private HttpClient ws;
        private string reponse;

        // Constructeur de la classe
        public GstWebServices()
        {
            ws = new HttpClient();
        }

        // Permet de récupérer la liste des composants
        public async Task<List<Composant>> GetAllComposants()
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "GetLesComposants.php");
            List<Composant> lesComposants = JsonConvert.DeserializeObject<List<Composant>>(reponse);
            return lesComposants;
        }

        // Permet de modifier un composant dans la BDD
        public async void UpdateComposant(string IdComposant, string LibelleComposant)
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "UpdateComposant.php?IdComposant=" + IdComposant + "&LibelleComposant=" + LibelleComposant);
        }

        // Permet d'insérer un nouveau composant
        public async void InsertComposant(string IdComposant, string LibelleComposant)
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "InsertComposant.php?IdComposant=" + IdComposant + "&LibelleComposant=" + LibelleComposant);
        }

        // Permet de récupérer la liste de médicaments
        public async Task<List<Medicament>> GetAllMedicaments()
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "GetLesMedicaments.php");
            List<Medicament> lesMedicaments = JsonConvert.DeserializeObject<List<Medicament>>(reponse);
            return lesMedicaments;
        }

        // Permet de récupérer la composition du médicament
        public async Task<List<QteComposantParMedicament>> GetCompositionMedicament(string idMedicament)
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "GetCompositionMedicament.php?IdMedicament=" + idMedicament);
            List<QteComposantParMedicament> qteComposantDuMedicament = JsonConvert.DeserializeObject<List<QteComposantParMedicament>>(reponse);
            return qteComposantDuMedicament;
        }

        // Permet de récupérer la liste des composants QUI NE COMPOSE PAS le médicament
        public async Task<List<Composant>> GetAllComposantsPasDansLeMedicament(string IdMedicament)
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "GetLesComposantsPasDansLeMedicament.php?IdMedicament=" + IdMedicament);
            List<Composant> lesComposantsPasDansLeMedicament = JsonConvert.DeserializeObject<List<Composant>>(reponse);
            return lesComposantsPasDansLeMedicament;
        }

        // Permet d'insérer un nouveau composant pour un médicament
        public async void InsertComposantDuMedicament(string IdMedicament, string IdComposant, string QuantiteComposant)
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "InsertComposantDuMedicament.php?IdMedicament=" + IdMedicament + "&IdComposant=" + IdComposant + "&Quantite=" + QuantiteComposant);
        }

        // Permet de modifier un composant d'un médicament
        public async void UpdateComposantDuMedicament(string IdMedicament, string IdComposant, string QuantiteComposant)
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "UpdateComposantDuMedicament.php?IdMedicament=" + IdMedicament + "&IdComposant=" + IdComposant + "&Quantite=" + QuantiteComposant);
        }

        // Permet d'avoir la formulation du médicament passsé en paramètre
        public async Task<List<PresentationMedicament>> GetAllFormulationDuMedicament(string IdMedicament)
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "GetFormulationDuMedicament.php?IdMedicament=" + IdMedicament);
            List<PresentationMedicament> lesPresentationsDuMedicament = JsonConvert.DeserializeObject<List<PresentationMedicament>>(reponse);
            return lesPresentationsDuMedicament;
        }

        // Permet d'avoir la liste des formulations qui ne formule pas le médicament
        public async Task<List<Presentation>> GetAllFormulationAutreDuMedicament(string IdMedicament)
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "GetAllFormulationAutreDuMedicament.php?IdMedicament=" + IdMedicament);
            List<Presentation> lesPresentations = JsonConvert.DeserializeObject<List<Presentation>>(reponse);
            return lesPresentations;
        }

        // Permet d'insérer une nouvelle formulation pour un médicament
        public async void InsertFormulationDuMedicament(string IdMedicament, string IdPresentaion)
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "InsertFormulationDuMedicament.php?IdMedicament=" + IdMedicament + "&IdPresentation=" + IdPresentaion);
        }

        // API Statistiques
        public async Task<List<NombreComposantParMedicament>> NbComposantParMedicament()
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "GetNbComposantsParMedicament.php");
            List<NombreComposantParMedicament> lesNbComposantsParMedicament = JsonConvert.DeserializeObject<List<NombreComposantParMedicament>>(reponse);
            return lesNbComposantsParMedicament;
        }

        public async Task<List<MinimumComposantsDesMedicaments>> GetMedicamentMinimumComposant()
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "GetMedicamentMinimumComposant.php");
            List<MinimumComposantsDesMedicaments> leMedicamentAvecMinimumComposant = JsonConvert.DeserializeObject<List<MinimumComposantsDesMedicaments>>(reponse);
            return leMedicamentAvecMinimumComposant;
        }

        public async Task<List<MaximumComposantsDesMedicaments>> GetMedicamentMaximumComposant()
        {
            reponse = await ws.GetStringAsync(App.LocalHost + "GetMedicamentMaximumComposant.php");
            List<MaximumComposantsDesMedicaments> leMedicamentAvecMaximumComposant = JsonConvert.DeserializeObject<List<MaximumComposantsDesMedicaments>>(reponse);
            return leMedicamentAvecMaximumComposant;
        }
    }
}
