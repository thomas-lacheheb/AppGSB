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
	public partial class PageListeDesIncompatibilites : ContentPage
	{
        public Medicament leMedicamentSelectionne { get; set; }

        public PageListeDesIncompatibilites (Medicament m)
		{
			InitializeComponent ();
            leMedicamentSelectionne = m;
            AfficherLesIncompatibilitesDuMedicament();
		}

        private async void AfficherLesIncompatibilitesDuMedicament()
        {
            lvIncompatibilite.ItemsSource = await App.GstWS.GetIncompatibiliteMedicament(leMedicamentSelectionne.IdMedicament);
        }

        private async void BtnRetour_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}