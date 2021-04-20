using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgramOverview
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmailModal : ContentPage
    {
        public EmailModal()
        {
            InitializeComponent();
            CloseButton.Text = "Close";
            SendButton.Text = "Send Email";
            ToEntry.Text = "To";
            FromEntry.Text = "From";
            TitleEntry.Text = "Topic";
            MessageEntry.Text = "Message";
        }

        private async void CloseButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}