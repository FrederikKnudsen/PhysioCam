using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        // Skal nok ikke føre tilbage til LoginPage, men det kan vi altid lave om
        private async void OnCompleteRegistrationButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        // Mangler at tilføje nogle options til filepicker...Eksempelvis hvilken slags filer der er tilladt osv!
        // Skal også ændre hvad der skal ske med den file man vælger, men ved det virker nu!
        private async void OnAddLogoButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var chosenLogo = await FilePicker.PickAsync();

                if (chosenLogo != null)
                {
                    fullnameEntry.Text = chosenLogo.FileName;
                }
            }
            catch (Exception)
            {
                // Skal implementere en løsning hvis noget går galt!
            }
        }
    }
}