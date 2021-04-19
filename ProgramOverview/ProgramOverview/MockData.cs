using ProgramOverview.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;
using Xamarin.Forms;

namespace ProgramOverview
{
    public class MockData
    {
        private ObservableCollection<Exercise> exercises;
        private Patient patient;

        public MockData()
        {
            CreateData();
        }

        public void CreateData()
        {
            exercises = new ObservableCollection<Exercise>()
            {
                new Exercise
                {
                    Id = 1,
                    ETitle = "Exercise 1",
                    Description = "This is a exercise",
                    Reps = "3 x 10",
                    ExerciseType = "Shoulder",
                    Images = new ObservableCollection<Image>()
                    {
                        new Image {Source = "exercise.jpg"},
                        new Image {Source = "exercise.jpg"}
                    }
                },
                new Exercise
                {
                    Id = 2,
                    ETitle = "Exercise 2",
                    Description = "This is a exercise",
                    Reps = "3 x 12",
                    ExerciseType = "Knee",
                    Images = new ObservableCollection<Image>()
                    {
                        new Image {Source = "exercise.jpg"}
                    }
                }
            };

            patient = new Patient
            {
                Name = "Lotte Hansen",
                Birthdate = new DateTime(1985, 6, 12)
            };

        }

        public ObservableCollection<Exercise> GetExercises()
        {
            return exercises;
        }

        public Patient GetPatient()
        {
            return patient;
        }
    }
}
