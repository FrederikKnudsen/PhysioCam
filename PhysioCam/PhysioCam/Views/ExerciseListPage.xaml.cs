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
    public partial class ExerciseListPage : ContentPage
    {
        private Exercise _selectedExercise;
        private MockData mockData;
        private ObservableCollection<Exercise> _exercises;
        private Patient patient;

        public ExerciseListPage(ObservableCollection<Exercise> Exercises)
        {
            InitializeComponent();

            _exercises = Exercises;

            mockData = new MockData();

            patient = mockData.GetPatient();

            AddPatientInfo();
            AddListViewItems();
        }

        public void AddListViewItems()
        {
            exerciseListView.ItemsSource = _exercises;
        }

        public void AddPatientInfo()
        {
            NameLabel.Text = patient.Name;
            NameLabel.FontSize = 20;
            BirthLabel.Text = patient.Birthdate.Date.ToString("d");
            BirthLabel.FontSize = 20;
        }


        private void OnItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedExercise = (Exercise)exerciseListView.SelectedItem;
            var detailPage = new ExerciseDetailPage(_selectedExercise);
            Navigation.PushAsync(detailPage);
        }
    }
}