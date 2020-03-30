using App_X.Models;
using App_X.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace App_X.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        public User User { get; set; } = new User();

        private ApiServices ApiServices = new ApiServices();




        public Command LoginCommand => new Command(async () =>
        {

            var content = new MultipartFormDataContent();

            content.Add(new StringContent(User.ID_User), "ID_User");
            
            content.Add(new StringContent(User.User_Pass), "User_Pass");
              


        var result = await ApiServices.LoginUserAsync(content);


            if (result)
            {
                await App.Current.MainPage.DisplayAlert("", "สำเร็จ", "OK");
                
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("", "ไม่มีผู้ใช้นี้", "Close");
            }

        });



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}