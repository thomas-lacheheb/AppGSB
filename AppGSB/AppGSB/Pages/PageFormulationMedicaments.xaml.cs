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
	public partial class PageFormulationMedicaments : ContentPage
	{
		public PageFormulationMedicaments ()
		{
			InitializeComponent ();
            AfficherLesMedicaments();
		}

        public async void AfficherLesMedicaments()
        {
            lvMedicaments.ItemsSource = await App.GstWS.GetAllMedicaments();
        }

        private async void LvMedicaments_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvMedicaments.SelectedItem != null)
            {
                Medicament leMedicamentSelectionne = (lvMedicaments.SelectedItem as Medicament);
                Pages.PageFormulationDuMedicament page = new Pages.PageFormulationDuMedicament(leMedicamentSelectionne);
                await Navigation.PushModalAsync(page);
            }
        }

        private void BtnRetourAcceuil_Clicked(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            Navigation.PushModalAsync(page);
        }
    }
}