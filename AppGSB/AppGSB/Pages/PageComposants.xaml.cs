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
	public partial class PageComposants : ContentPage
	{
		public PageComposants ()
		{
			InitializeComponent ();
            AfficherLesComposants();
		}

        public async void AfficherLesComposants()
        {
            lvComposants.ItemsSource = await App.GstWS.GetAllComposants();
        }

        private async void LvComposants_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(lvComposants.SelectedItem != null)
            {
                Composant leComposantSelectionner = (lvComposants.SelectedItem as Composant);
                Pages.PageModifierComposant page = new Pages.PageModifierComposant(leComposantSelectionner);
                await Navigation.PushModalAsync(page);
            }
        }

        private async void BtnAjouterComposant_Clicked(object sender, EventArgs e)
        {
            Pages.PageAjouterComposant page = new Pages.PageAjouterComposant((lvComposants.ItemsSource as List<Composant>).Count);
            await Navigation.PushModalAsync(page);
        }

        private void BtnRetourAcceuil_Clicked(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            Navigation.PushModalAsync(page);
        }
    }
}