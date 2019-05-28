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
	public partial class PageMedicamentPourIncompatibilite : ContentPage
	{
		public PageMedicamentPourIncompatibilite ()
		{
			InitializeComponent ();
            AfficherLesMedicaments();
		}

        public async void AfficherLesMedicaments()
        {
            lvMedicamentsPourIncompatibilite.ItemsSource = await App.GstWS.GetListMedicamentsPourIncompatibilite();
        }

        private async void LvMedicamentsPourIncompatibilite_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvMedicamentsPourIncompatibilite.SelectedItem != null)
            {
                Medicament leMedicamentSelectionne = (lvMedicamentsPourIncompatibilite.SelectedItem as Medicament);
                Pages.PageListeDesIncompatibilites page = new Pages.PageListeDesIncompatibilites(leMedicamentSelectionne);
                await Navigation.PushModalAsync(page);
            }
        }
    }
}