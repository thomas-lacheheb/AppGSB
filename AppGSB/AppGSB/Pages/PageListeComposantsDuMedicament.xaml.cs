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
	public partial class PageListeComposantsDuMedicament : ContentPage
	{
        public Medicament leMedicamentSelectionne { get; set; }

        public PageListeComposantsDuMedicament(Medicament leMedicament)
        {
            InitializeComponent();
            leMedicamentSelectionne = leMedicament;
            AfficherLesComposantsDuMedicament();
        }

        private async void AfficherLesComposantsDuMedicament()
        {
            lvCompositionMedicament.ItemsSource = await App.GstWS.GetCompositionMedicament(leMedicamentSelectionne.IdMedicament);
        }

        private async void BtnAjouterComposant_Clicked(object sender, EventArgs e)
        {
            Pages.PageAjouterComposantAuMedicament page = new Pages.PageAjouterComposantAuMedicament(leMedicamentSelectionne);
            await Navigation.PushModalAsync(page);
        }

        private async void LvCompositionMedicament_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(lvCompositionMedicament.SelectedItem != null)
            {
                Composant leComposantAModifer = new Composant();
                leComposantAModifer.IdComposant = (lvCompositionMedicament.SelectedItem as QteComposantParMedicament).IdComposant;
                leComposantAModifer.LibelleComposant = (lvCompositionMedicament.SelectedItem as QteComposantParMedicament).LibelleComposant;

                int laQuantite = (lvCompositionMedicament.SelectedItem as QteComposantParMedicament).QteComposant;
                Pages.PageModifierQuantiteComposantDuMedicament page = new Pages.PageModifierQuantiteComposantDuMedicament(leComposantAModifer, leMedicamentSelectionne, laQuantite);
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