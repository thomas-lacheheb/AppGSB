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
	public partial class PageAjouterFormulationAuMedicament : ContentPage
	{
        public Medicament ContexteMedicament { get; set; }

        public PageAjouterFormulationAuMedicament (Medicament leMedicamentAModifier)
		{
			InitializeComponent ();
            ContexteMedicament = leMedicamentAModifier;
            AfficherLesFormulations();
		}

        public async void AfficherLesFormulations()
        {
            pickerPresentation.ItemsSource = await App.GstWS.GetAllFormulationAutreDuMedicament(ContexteMedicament.IdMedicament);
        }

        private void BtnRetourAcceuil_Clicked(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            Navigation.PushModalAsync(page);
        }

        public async void RetourPageFormulationDuMedicament()
        {
            Pages.PageFormulationDuMedicament page = new Pages.PageFormulationDuMedicament(ContexteMedicament);
            await Navigation.PushModalAsync(page);
        }

        private void BtnAjouterLaFormulationAuMedicament_Clicked(object sender, EventArgs e)
        {
            if(pickerPresentation.SelectedItem == null)
            {
                DisplayAlert("Veuillez sélectionner une formulation", "Veuillez sélectionner une formulation avant de valider", "Valider");
            }
            else
            {
                string CodePresentation = (pickerPresentation.SelectedItem as Presentation).IdPresentation;
                App.GstWS.InsertFormulationDuMedicament(ContexteMedicament.IdMedicament, CodePresentation);
                DisplayAlert("L'insertion s'est bien passé", "La formulation à été ajouté au médicament", "Ok");
                RetourPageFormulationDuMedicament();
            }
        }
    }
}