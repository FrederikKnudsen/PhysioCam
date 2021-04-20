using PhysioCam.Model;
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
        public IList<string> AreaOfExercise = new List<string>() { "Shoulders", "Neck", "Back", "Legs" };
        public IList<string> Repetitions = new List<string>() { "2 x 10", "3 x 10", "2 x 15", "3 x 15" };

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

            ((Frame)sender).BackgroundColor = Color.FromHex("#0c94cc");

            _lastFrame = ((Frame)sender);
        }

        private void DoneButton_Clicked(object sender, EventArgs e)
        {
            Exercises.FirstOrDefault(i => i.ImageSource == _selectedExercise.ImageSource).Description = EditorTextInput.Text;

            Navigation.PopAsync();
        }
    }
}