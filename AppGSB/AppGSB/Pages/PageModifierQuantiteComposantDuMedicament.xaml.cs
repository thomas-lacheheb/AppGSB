using AppGSB.ClassesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGSB.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageModifierQuantiteComposantDuMedicament : ContentPage
	{
        public Composant ContexteComposant { get; set; }
        public Medicament ContexteMedicament { get; set; }
        public int ContexteQuantite { get; set; }

        public PageModifierQuantiteComposantDuMedicament (Composant leComposant, Medicament leMedicament, int laQte)
		{
			InitializeComponent ();
            ContexteComposant = leComposant;
            ContexteMedicament = leMedicament;
            ContexteQuantite = laQte;
            AfficherLesInformationsNecessaires();
		}

        public void AfficherLesInformationsNecessaires()
        {
            txtLibelleComposant.Text = ContexteComposant.LibelleComposant;
            txtQteComposant.Text = ContexteQuantite.ToString();
        }

        public async void RetourPageComposantsDuMedicament()
        {
            Pages.PageListeComposantsDuMedicament page = new Pages.PageListeComposantsDuMedicament(ContexteMedicament);
            await Navigation.PushModalAsync(page);
        }

        private void BtnValiderModificationQteComposant_Clicked(object sender, EventArgs e)
        {
            if(txtQteComposant.Text == null)
            {
                DisplayAlert("Veuillez saisir une valeur", "Veuillez saisir une quantité pour valider la modification", "Ok");
            }
            else
            {
                App.GstWS.UpdateComposantDuMedicament(ContexteMedicament.IdMedicament, ContexteComposant.IdComposant.ToString(), txtQteComposant.Text);
                DisplayAlert("Modification effectué", "La modification à bien été effectué", "Ok");
                RetourPageComposantsDuMedicament();
            }
        }

        private void BtnRetourAcceuil_Clicked(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            Navigation.PushModalAsync(page);
        }
    }
}