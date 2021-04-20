
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace PhysioCam.Model
{
    public class Exercise : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public ImageSource ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; OnPropertyChanged("ImageSource"); }
        }

        private ImageSource _imageSource;
        public int Id { get; set; }
        public string ETitle { get; set; }
        public string Description { get; set; }
        public string ExerciseType { get; set; }
        public string Reps { get; set; }
    }

    public class Images
    {
        public string ImagePath { get; set; }
    }
}