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
        private ExerciseItem _selectedExercise;
        private MockData mockData;
        private ObservableCollection<Exercise> _exercises;
        private Patient patient;
        private ExerciseManager exManager = new ExerciseManager();

        public ExerciseListPage(ObservableCollection<Exercise> Exercises)
        {
            InitializeComponent();

            _exercises = Exercises;

            mockData = new MockData();

            patient = mockData.GetPatient();

            AddPatientInfo();
            AddListViewItems();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            AddListViewItems();

        }

        public async void AddListViewItems()
        {
            List<ExerciseItem> exercises = await exManager.GetAllExercises();
            exerciseListView.ItemsSource = exercises;
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
            _selectedExercise = (ExerciseItem)exerciseListView.SelectedItem;
            var detailPage = new ExerciseDetailPage(_selectedExercise);
            Navigation.PushAsync(detailPage);
        }
    }
}