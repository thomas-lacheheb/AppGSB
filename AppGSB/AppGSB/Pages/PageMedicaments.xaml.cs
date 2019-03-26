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
	public partial class PageMedicaments : ContentPage
	{
		public PageMedicaments ()
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
            if(lvMedicaments.SelectedItem != null)
            {
                Medicament leMedicamentSelectionne = (lvMedicaments.SelectedItem as Medicament);
                Pages.PageListeComposantsDuMedicament page = new Pages.PageListeComposantsDuMedicament(leMedicamentSelectionne);
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