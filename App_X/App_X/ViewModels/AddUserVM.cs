using App_X.Models;
using App_X.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace App_X.ViewModels
{
   public class AddUserVM : INotifyPropertyChanged
    {
        public User User { get; set; } = new User();
        private MediaFile _mediaFile;
        private Image _fileImage = new Image();
        private ApiServices ApiServices = new ApiServices();

        public Image FileImage
        {
            get => _fileImage;
            set
            {
                _fileImage = value;
                OnPropertyChanged();
            }
        }

        public Command ImageCommand => new Command(async () =>
        {

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("No PickPhoto", ":( No PickPhoto available.", "OK");
                return;
            }

            _mediaFile = await CrossMedia.Current.PickPhotoAsync();

            if (_mediaFile == null) return;

            FileImage.Source = ImageSource.FromStream(() => _mediaFile.GetStream());

        });

      



        public Command AddCommand => new Command(async () =>
        {

            var content = new MultipartFormDataContent();

            content.Add(new StringContent(User.ID_User), "ID_User");
            content.Add(new StringContent(User.User_Height.ToString()), "User_Height");
            content.Add(new StringContent(User.User_Name), "User_Name");
            content.Add(new StringContent(User.User_Pass), "User_Pass");
            content.Add(new StringContent(User.User_Tell), "User_Tell");           
            content.Add(new StringContent(User.User_Weight.ToString()), "User_Weight");
            content.Add(new StringContent(User.User_Type.ToString()), "User_Type");






            ////if (_mediaFile != null)
            ////    content.Add(new StreamContent(_mediaFile.GetStream()),
            ////        "\"files\"",
            ////        $"\"{_mediaFile.Path}\"");



            var result = await ApiServices.PostUserAsync(content);


            if (result)
            {
                await App.Current.MainPage.DisplayAlert("", "สำเร็จ", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("", "ไม่สำเร็จ", "Close");
            }

        });



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

    
