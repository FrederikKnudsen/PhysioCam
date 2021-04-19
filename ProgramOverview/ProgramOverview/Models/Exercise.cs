using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ProgramOverview.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string ETitle { get; set; }
        public ObservableCollection<Image> Images { get; set; }
        public string Description { get; set; }
        public string ExerciseType { get; set; }
        public string Reps { get; set; }
    }
}
