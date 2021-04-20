using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysioCam.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseDetailPage : ContentPage
    {
        public Exercise _currentExercise { get; set; }
        public ExerciseDetailPage(Exercise exercises)
        {
            InitializeComponent();
            _currentExercise = exercises;
            BindingContext = this;
        }

        private async void SendMailButton_OnClicked(object sender, EventArgs e)
        {
            var modal = new EmailModal();
            await Navigation.PushModalAsync(modal);

        }

        private async void SaveButton_OnClicked(object sender, EventArgs e)
        {
            //_currentExercise.ETitle = TitleLabel.Text;
            //_currentExercise.Description = DescriptionLabel.Text;
            //_currentExercise.ExerciseType = TypeLabel.Text;
            //_currentExercise.Reps = RepLabel.Text;
            await Navigation.PopAsync(true);
        }
    }
}