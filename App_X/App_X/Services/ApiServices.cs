using App_X.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App_X.Services
{
    public class ApiServices
    {

        private string uri = Setting.Uri;
        private HttpClient httpClient = new HttpClient();

        public async Task<bool> PostUserAsync(MultipartFormDataContent content)
        {
            var uriAddress = uri + "Table_User";

            try
            {
                var httpResponseMessage = await httpClient.PostAsync(uriAddress, content);
                return httpResponseMessage.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                return false;
            }



        }

        public async Task<bool> LoginUserAsync(MultipartFormDataContent content)
        {
            var uriAddress = uri + "Table_User/Login";

            try
            {
                var httpResponseMessage = await httpClient.PostAsync(uriAddress, content);
                return httpResponseMessage.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                return false;
            }



        }

        internal async Task<ObservableCollection<User>> GetUserAsync()
        {
            var uriAddress = uri + "Table_User";

            try
            {
                var json = await httpClient.GetStringAsync(uriAddress);
                var people = JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
                return people;
            }
            catch (Exception e)
            {
                return new ObservableCollection<User>();
            }
        }


        internal async Task<ObservableCollection<Programe>> GetProgrameAsync()

        {
            var uriAddress = uri + "Table_ProGrame";

            try
            {
                var json = await httpClient.GetStringAsync(uriAddress);
                var pro = JsonConvert.DeserializeObject<ObservableCollection<Programe>>(json);
                return pro;
            }
            catch (Exception e)
            {
                return new ObservableCollection<Programe>();
            }
        }




        //internal async Task<ObservableCollection<programe>> SearchPersonAsync(string keyword)
        //{
        //    var uriAddress = uri + "PersonApi/SearchPerson/" + keyword;

        //    try
        //    {
        //        var json = await httpClient.GetStringAsync(uriAddress);
        //        var people = JsonConvert.DeserializeObject<ObservableCollection<Person>>(json);
        //        return people;
        //    }
        //    catch (Exception e)
        //    {
        //        return new ObservableCollection<Person>();
        //    }
        //}



    }
}


