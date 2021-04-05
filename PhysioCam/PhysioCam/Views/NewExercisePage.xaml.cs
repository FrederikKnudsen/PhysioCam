using PhysioCam.Models;
using PhysioCam.Views;
using Plugin.Media;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExercisePage : ContentPage
    {
        public ObservableCollection<Exercise> Exercises { get; set; }

        public ImageSource SelectedImage { get; set; }
        public NewExercisePage()
        {
            InitializeComponent();
            Exercises = new ObservableCollection<Exercise>();
            BindingContext = this;

            NewPhoto.Clicked += CameraButton_Clicked;
            RetakePhoto.Clicked += RetakePhoto_Clicked;
            DeletePhoto.Clicked += DeletePhoto_Clicked;
            AddDescriptionButton.Clicked += AddDescriptionButton_Clicked;
        }

        private void OnFrameTapped(object sender, EventArgs e)
        {
            var imageSource = ((TappedEventArgs)e).Parameter;
            PhotoImage.Source = (ImageSource)imageSource;
            SelectedImage = PhotoImage.Source;
        }

        private void AddDescriptionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddDescriptionPage(Exercises));
        }

        private async void DeletePhoto_Clicked(object sender, EventArgs e)
        {

            bool remove = await DisplayAlert("Delete", "Are you sure you want to delete image?", "Yes", "No");

            if (!remove)
                return;

            var imageToRemove = Exercises.FirstOrDefault(i => i.ImageSource == SelectedImage);
            Exercises.Remove(imageToRemove);

            if (Exercises?.Count == 0)
            {
                AddDescriptionButton.IsVisible = false;
                RetakePhoto.IsVisible = false;
                DeletePhoto.IsVisible = false;

                PhotoImage.Source = null;
            }
            else
            {
                PhotoImage.Source = Exercises.LastOrDefault(i => i.ImageSource != null).ImageSource;
                SelectedImage = PhotoImage.Source;
            }
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            var photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            {
                Directory = "Images",
                Name = DateTime.Now + "Image.jpg"
            });

            if (photo != null)
            {
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

                Exercises.Add(new Exercise() { ImageSource = PhotoImage.Source });

                SelectedImage = PhotoImage.Source;
                AddDescriptionButton.IsVisible = true;
                RetakePhoto.IsVisible = true;
                DeletePhoto.IsVisible = true;
            }

        }

        private async void RetakePhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            var photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            {
                Directory = "Images",
                Name = DateTime.Now + "Image.jpg"
            });

            if (photo != null)
            {
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

                Exercises.FirstOrDefault(i => i.ImageSource == SelectedImage).ImageSource = PhotoImage.Source;

                SelectedImage = PhotoImage.Source;
                AddDescriptionButton.IsVisible = true;
                RetakePhoto.IsVisible = true;
                DeletePhoto.IsVisible = true;
            }
        }
    }
}