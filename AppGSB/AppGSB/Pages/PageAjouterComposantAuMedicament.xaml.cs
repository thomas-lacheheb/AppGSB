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
	public partial class PageAjouterComposantAuMedicament : ContentPage
	{
        public Medicament ContexteMedicament { get; set; }

        public PageAjouterComposantAuMedicament (Medicament leMedicamentSelectionne)
		{
			InitializeComponent ();
            ContexteMedicament = leMedicamentSelectionne;
            AfficherToutesLesInformations();
		}

        public async void AfficherToutesLesInformations()
        {
            pickerComposant.ItemsSource = await App.GstWS.GetAllComposantsPasDansLeMedicament(ContexteMedicament.IdMedicament);
        }

        public async void RetourPageComposantsDuMedicament()
        {
            Pages.PageListeComposantsDuMedicament page = new Pages.PageListeComposantsDuMedicament(ContexteMedicament);
            await Navigation.PushModalAsync(page);
        }

        private void BtnAjouterComposantAuMedicament_Clicked(object sender, EventArgs e)
        {
            if(txtQuantiteComposant.Text == null)
            {
                DisplayAlert("Veuillez saisir une quantité", "Saisissez une quantité pour valider les modifications", "Valider");
            }
            else
            {
                App.GstWS.InsertComposantDuMedicament(ContexteMedicament.IdMedicament, (pickerComposant.SelectedItem as Composant).IdComposant.ToString(), txtQuantiteComposant.Text);
                DisplayAlert("L'insertion s'est bien passée", "Le composant à été ajouté au médicament", "Ok");
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