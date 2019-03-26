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
	public partial class PageStatistiques : ContentPage
	{
		public PageStatistiques ()
		{
			InitializeComponent ();
            AfficherLesStatistiques();
		}

        public async void AfficherLesStatistiques()
        {
            lvNbComposantParMedicament.ItemsSource = await App.GstWS.NbComposantParMedicament();
            lvMedicamentMinimumComposant.ItemsSource = await App.GstWS.GetMedicamentMinimumComposant();
            lvMedicamentMaximumComposant.ItemsSource = await App.GstWS.GetMedicamentMaximumComposant();
        }

        private void BtnRetourAcceuil_Clicked(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            Navigation.PushModalAsync(page);
        }
    }
}