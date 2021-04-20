using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramOverview.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgramOverview
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseDetailPage : ContentPage
    {
        private MockData mockData;
        private ObservableCollection<Exercise> exercises;
        private Exercise _currentExercise;
        public ExerciseDetailPage(Exercise currentExercise)
        {
            InitializeComponent();
            _currentExercise = currentExercise;
            mockData = new MockData();
            exercises = mockData.GetExercises();
            TitleLabel.Text = _currentExercise.ETitle;
            TitleLabel.FontSize = 20;
            DescriptionLabel.Text = _currentExercise.Description;
            DescriptionLabel.FontSize = 20;
            TypeLabel.Text = _currentExercise.ExerciseType;
            TypeLabel.FontSize = 20;
            RepLabel.Text = _currentExercise.Reps;
            RepLabel.FontSize = 20;

            SendMailButton.Text = "Send as email";
            SendMailButton.WidthRequest = 150;
            ExportButton.Text = "Export as pdf";
            ExportButton.WidthRequest = 150;

            SaveButton.Text = "Save Program";
            SaveButton.WidthRequest = 300;

        }

        private async void SendMailButton_OnClicked(object sender, EventArgs e)
        {
            var modal = new EmailModal();
            await Navigation.PushModalAsync(modal);

        }

        private async void SaveButton_OnClicked(object sender, EventArgs e)
        {
            _currentExercise.ETitle = TitleLabel.Text;
            _currentExercise.Description = DescriptionLabel.Text;
            _currentExercise.ExerciseType = TypeLabel.Text;
            _currentExercise.Reps = RepLabel.Text;
            await Navigation.PopAsync(true);
        }
    }
}