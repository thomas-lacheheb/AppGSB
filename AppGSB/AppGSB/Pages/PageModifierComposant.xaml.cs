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
	public partial class PageModifierComposant : ContentPage
	{
		public PageModifierComposant(Composant unComposant)
		{
			InitializeComponent ();
            AfficherLesInformations(unComposant);
		}

        public void AfficherLesInformations(Composant unComposant)
        {
            txtIdComposant.Text = unComposant.IdComposant.ToString();
            txtLibelleComposant.Text = unComposant.LibelleComposant;
        }

        public async void RetourPageComposants()
        {
            Pages.PageComposants page = new Pages.PageComposants();
            await Navigation.PushModalAsync(page);
        }

        private void BtnModifierComposant_Clicked(object sender, EventArgs e)
        {
            string IdComposant = txtIdComposant.Text;
            string LibelleComposant = txtLibelleComposant.Text;

            App.GstWS.UpdateComposant(IdComposant, LibelleComposant);

            DisplayAlert("Modification effectué", "La modification à bien été effectué", "Ok");

            RetourPageComposants();
        }

        private void BtnRetourAcceuil_Clicked(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            Navigation.PushModalAsync(page);
        }
    }
}