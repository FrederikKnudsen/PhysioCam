using PhysioCam.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDescriptionPage : ContentPage
    {
        public ObservableCollection<Exercise> Exercises { get; set; }
        private Exercise _selectedExercise { get; set; }
        private Frame _lastFrame;
        public AddDescriptionPage(ObservableCollection<Exercise> Exercises)
        {
            InitializeComponent();

            _selectedExercise = Exercises.FirstOrDefault();
            EditorTextInput.Text = _selectedExercise.Description;

            this.Exercises = Exercises;
            BindingContext = this;
        }

        private void OnFrameTapped(object sender, EventArgs e)
        {
            HighlightFrames(sender);

            var parameters = ((TappedEventArgs)e).Parameter;
            var imageSource = (ImageSource)parameters;

            _selectedExercise.Description = EditorTextInput.Text;

            _selectedExercise = Exercises.FirstOrDefault(i => i.ImageSource == imageSource);

            EditorTextInput.Text = _selectedExercise.Description;
        }

        void HighlightFrames(object sender)
        {
            if (_lastFrame == null)
                _lastFrame = ((Frame)sender);

            _lastFrame.BackgroundColor = Color.White;

            ((Frame)sender).BackgroundColor = Color.Red;

            _lastFrame = ((Frame)sender);
        }

        private void DoneButton_Clicked(object sender, EventArgs e)
        {
            Exercises.FirstOrDefault(i => i.ImageSource == _selectedExercise.ImageSource).Description = EditorTextInput.Text;

            Navigation.PopAsync();
        }
    }
}