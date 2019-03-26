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
	public partial class PageFormulationDuMedicament : ContentPage
	{
        public Medicament ContexteMedicament { get; set; }

        public PageFormulationDuMedicament (Medicament leMedicamentSelectionne)
		{
			InitializeComponent ();
            ContexteMedicament = leMedicamentSelectionne;
            AfficherFormulationDuMedicament();
		}

        public async void AfficherFormulationDuMedicament()
        {
            lvFormulationDuMedicament.ItemsSource = await App.GstWS.GetAllFormulationDuMedicament(ContexteMedicament.IdMedicament);
        }

        private async void BtnAjouterFormulation_Clicked(object sender, EventArgs e)
        {
            Pages.PageAjouterFormulationAuMedicament page = new Pages.PageAjouterFormulationAuMedicament(ContexteMedicament);
            await Navigation.PushModalAsync(page);
        }

        private void BtnRetourAcceuil_Clicked(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            Navigation.PushModalAsync(page);
        }
    }
}