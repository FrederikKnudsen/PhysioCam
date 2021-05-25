
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

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Small
    {
        public string ext { get; set; }
        public string url { get; set; }
        public string hash { get; set; }
        public string mime { get; set; }
        public string name { get; set; }
        public object path { get; set; }
        public double size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Thumbnail
    {
        public string ext { get; set; }
        public string url { get; set; }
        public string hash { get; set; }
        public string mime { get; set; }
        public string name { get; set; }
        public object path { get; set; }
        public double size { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Formats
    {
        public Small small { get; set; }
        public Thumbnail thumbnail { get; set; }
    }

    public class Image
    {
        public int id { get; set; }
        public string name { get; set; }
        public string alternativeText { get; set; }
        public string caption { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Formats formats { get; set; }
        public string hash { get; set; }
        public string ext { get; set; }
        public string mime { get; set; }
        public double size { get; set; }
        public string url { get; set; }
        public object previewUrl { get; set; }
        public string provider { get; set; }
        public object provider_metadata { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string ImageUrl => new Uri(ExerciseManager.URL, url).AbsoluteUri;
    }

    public class AppUser
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string DateOfBirth { get; set; }
        public DateTime published_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class ExercisePlan
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime published_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class ExerciseItem
    {
        public int id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime published_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Image> Image { get; set; }
        public List<AppUser> app_users { get; set; }
        public List<ExercisePlan> exercise_plans { get; set; }
    }
}