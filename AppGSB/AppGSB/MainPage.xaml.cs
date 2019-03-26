using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppGSB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnGestionComposants_Clicked(object sender, EventArgs e)
        {
            Pages.PageComposants page = new Pages.PageComposants();
            await Navigation.PushModalAsync(page);
        }

        private async void BtnGestionMedicaments_Clicked(object sender, EventArgs e)
        {
            Pages.PageMedicaments page = new Pages.PageMedicaments();
            await Navigation.PushModalAsync(page);
        }

        private async void BtnGestionFormulation_Clicked(object sender, EventArgs e)
        {
            Pages.PageFormulationMedicaments page = new Pages.PageFormulationMedicaments();
            await Navigation.PushModalAsync(page);
        }

        private async void BtnStatistiques_Clicked(object sender, EventArgs e)
        {
            Pages.PageStatistiques page = new Pages.PageStatistiques();
            await Navigation.PushModalAsync(page);
        }
    }
}
