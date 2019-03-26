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
	public partial class PageAjouterComposant : ContentPage
	{
		public PageAjouterComposant (int nbComposants)
		{
			InitializeComponent ();
            InitialiserLesInformations(nbComposants);
        }

        public void InitialiserLesInformations(int nbComposants)
        {
            txtIdComposant.Text = (nbComposants + 1).ToString();
        }

        public async void RetourPageComposants()
        {
            Pages.PageComposants page = new Pages.PageComposants();
            await Navigation.PushModalAsync(page);
        }

        private void BtnAjouterLeComposant_Clicked(object sender, EventArgs e)
        {
            if(txtLibelleComposant.Text == null)
            {
                DisplayAlert("Saisir un nom de composant", "Veuillez saisir un nom de composant avant de valider", "Valider");
            }
            else
            {
                App.GstWS.InsertComposant(txtIdComposant.Text, txtLibelleComposant.Text);
                DisplayAlert("L'insertion s'est bien passé", "Le composant à été ajouté", "Ok");
                RetourPageComposants();
            }
        }
    }
}