using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramOverview.Models;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace ProgramOverview
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Image> images;
        private Exercise _selectedExercise;
        private MockData mockData;
        private ObservableCollection<Exercise> exercises;
        private Patient patient;

        public MainPage()
        {
            InitializeComponent();
            mockData = new MockData();
            exercises = mockData.GetExercises();
            patient = mockData.GetPatient();

            images = new ObservableCollection<Image>();
            images = exercises[0].Images;


            AddPatientInfo();
            AddListViewItems();



        }

        public void AddListViewItems()
        {

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
            _selectedExercise = (Exercise)exerciseListView.SelectedItem;
            var detailPage = new ExerciseDetailPage(_selectedExercise);
            Navigation.PushAsync(detailPage);
        }
    }
}
