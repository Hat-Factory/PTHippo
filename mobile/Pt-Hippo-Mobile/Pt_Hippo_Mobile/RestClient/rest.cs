using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.licensesModel;
using System.IO;
using System.Collections.ObjectModel;
using Plugin.Media.Abstractions;
using System.Diagnostics;
using System.Text;
using Pt_Hippo_Mobile.Model;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Plugin.Connectivity;
using Pt_Hippo_Mobile;

namespace Plugin.RestClient
{

    public class RestClient<T>
    {
        private const string WebServiceUrl = "http://13.94.204.175";
        

        //Get List 
        public async Task<List<T>> GetListAsync(string api)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return null;
            }
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
            var json = await httpClient.GetStringAsync($"{WebServiceUrl}/{api}");
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }
        //Get List 



        public async Task<T> GetSearch(string api , string searchtext , int  pagesize , int pagenumber, string zipcode , DateTime startdate, DateTime enddate, double minhourrate, double maxhourate)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return default(T);
            }
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
             //string json = "";
            var json = await httpClient.GetStringAsync($"{WebServiceUrl}/{api}/{pagesize}/{pagenumber}/{zipcode}/null/null/null/null");
            /// 1000 / 1 / 704 / null / null / null / null
            //if (searchtext  == null || string.IsNullOrWhiteSpace(searchtext) || string.IsNullOrEmpty(searchtext) || searchtext == "")
            //{
            //  json = await httpClient.GetStringAsync($"{WebServiceUrl}/{api}/{pagesize}/{pagenumber}/{searchtext}");
            //}
            //else if   (searchtext != null)
            //{
            //   json = await httpClient.GetStringAsync($"{WebServiceUrl}/{api}/{pagesize}/{pagenumber}?searchText={searchtext}");
            //}

            var taskModels = JsonConvert.DeserializeObject<T>(json);

            return taskModels;
        }

        //anonymous GET
        public async Task<List<T>> GetListanonymousAsync(string api)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return null;
            }
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"{WebServiceUrl}/{api}");
            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }

        public async Task<ObservableCollection<T>> GetObservableCollectionAsync(string api)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return null;
            }
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
            var json = await httpClient.GetStringAsync($"{WebServiceUrl}/{api}");
            var Model = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);

            return Model;
        }
         

        public async Task<T> GetAsync(string api)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return default(T);
            }
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
            
            var json = await httpClient.GetStringAsync($"{WebServiceUrl}/{api}");
            
            var taskModels = JsonConvert.DeserializeObject<T>(json);

            return taskModels;
        }
		public async Task<List<T>> GetAsyncRating(string api,int ratingemployee)
		{
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);

            var json = await httpClient.GetStringAsync($"{WebServiceUrl}/{api}"+ratingemployee);

			var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

			return taskModels;
		}
        public async Task<List<T>> Getlistbyjobid(string api, string id)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);

            var json = await httpClient.GetStringAsync($"{WebServiceUrl}/{api}" + id);

            var taskModels = JsonConvert.DeserializeObject<List<T>>(json);

            return taskModels;
        }

        
        public async Task<T> GetbyIdAsync(string api , string id )
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return default(T);
            }

            try
            {
                var httpClient = new HttpClient();
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);

                var json = await httpClient.GetStringAsync($"{WebServiceUrl}/{api}/{id}");

                var taskModels = JsonConvert.DeserializeObject<T>(json);

                return taskModels;
            }
            catch (Exception ex)
            {

                
            }

            return default(T);





        }

		public async Task<bool> PostAsync(string api , object data)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return false;
            }
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
            var json = JsonConvert.SerializeObject(data);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync($"{WebServiceUrl}/{api}", httpContent);

            return result.IsSuccessStatusCode;
        }
        public async Task<bool> Post(string api, object data)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return false;
            }
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);

            var json = JsonConvert.SerializeObject(data);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application / json");

            var result = await httpClient.PostAsync($"{ WebServiceUrl}/{ api}", httpContent);

            return result.IsSuccessStatusCode;
        }
		//public async Task<bool> Post(string api, object data)
		//{
		//	var httpClient = new HttpClient();

		//	httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);

		//	var json = JsonConvert.SerializeObject(data);

		//	HttpContent httpContent = new StringContent(json);

		//	httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

		//	var result = await httpClient.PostAsync($"{WebServiceUrl}/{api}", httpContent);

		//	return result.IsSuccessStatusCode;
		//}
        //update by spesfic id 
        public async Task<bool> PutAsync(string api, string  ID, object data)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return false;
            }
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);

            var json = JsonConvert.SerializeObject(data);
            
            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

           
            var result = await httpClient.PutAsync($"{WebServiceUrl}/{api}" + ID, httpContent);
            

            return result.IsSuccessStatusCode;
        }

        //update without spesfic id 
        public async Task<bool> PutwithoutidAsync(string api, object data)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return false;
            }
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);

            var json = JsonConvert.SerializeObject(data);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            var result = await httpClient.PutAsync($"{WebServiceUrl}/{api}", httpContent); 

            return result.IsSuccessStatusCode;
        }

        //update without spesfic id and anonymous
        public async Task<bool> PutwithoutidanonymousAsync(string api, object data)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return false;
            }
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(data);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            var result = await httpClient.PutAsync($"{WebServiceUrl}/{api}", httpContent);


            return result.IsSuccessStatusCode;
        }
        //update List Async
        public async Task<bool> PutListAsync( List<T> data , string api)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return false;
            }
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
            var json = JsonConvert.SerializeObject(data);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await httpClient.PutAsync($"{WebServiceUrl}/{api}", httpContent);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id, string url)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return false;
            }
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
            var response = await httpClient.DeleteAsync($"{WebServiceUrl}/{url}/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<T>> Uploadfile(List<Plugin.FilePicker.Abstractions.FileData> filedata , bool IsProfilePic , string DocumentType , bool IsEmployee , string url)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return null;
            }
            var client = new HttpClient();
            using (var content = new MultipartFormDataContent())
            {
                foreach (var item in filedata)
                {
                    content.Add(new StreamContent(new MemoryStream(item.DataArray)), "C:UsersashrafDesktopPTHPT-HippomobilePt-Hippo-Mobile", item.FileName);
                }

                content.Add(new StringContent(IsProfilePic.ToString()), "false");
                content.Add(new StringContent(IsEmployee.ToString()), "true");
                content.Add(new StringContent(DocumentType), "1");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
                var httpResponseMessage = await client.PostAsync($"{WebServiceUrl}/{url}", content);
                var json = await httpResponseMessage.Content.ReadAsStringAsync();
                var basicinfo = JsonConvert.DeserializeObject<List<T>>(json);
                return basicinfo;


            }

        }
        public async Task<bool> UploadMediafile(MediaFile _mediaFile, bool IsProfilePic, string DocumentType, bool IsEmployee, byte[]  bytearray, string fileName, string url )
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return false;
            }
            var client = new HttpClient();
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(new MemoryStream(bytearray)), Path.GetDirectoryName(_mediaFile.Path), fileName);
                content.Add(new StringContent("IsEmployee"), "true");
                content.Add(new StringContent("IsProfilePic"), "true");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
                var httpResponseMessage = await client.PostAsync($"{WebServiceUrl}/{url}", content);
                await httpResponseMessage.Content.ReadAsStringAsync();
                return httpResponseMessage.IsSuccessStatusCode;
            }

        }

        public async Task<T> GetClientId(string url)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                 await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return default(T);
            }
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{WebServiceUrl}/{url}");
            var stream = await response.Content.ReadAsStreamAsync();
            StreamReader readStream = new StreamReader(stream, Encoding.UTF8);
            var json = readStream.ReadToEnd();
            var account = JsonConvert.DeserializeObject<T>(json);
            return account;
        }

        public async Task<string> LoginAsync(string userName, string password , AccountIdApi account , string url , List<KeyValuePair<string, string>> KeyValues)
        {

			if (!CrossConnectivity.Current.IsConnected)
			{
				await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", "Check your Internet Connection", "OK");
                return "not connected";
			}

          
                var request = new HttpRequestMessage(HttpMethod.Post, $"{WebServiceUrl}/{url}");

                request.Content = new FormUrlEncodedContent(KeyValues);
                var client = new HttpClient();
                var respons = await client.SendAsync(request);
                var jwt = await respons.Content.ReadAsStringAsync();
                JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);
                var accessToken = jwtDynamic.Value<string>("access_token");
				

				Debug.WriteLine(jwt);

                return accessToken;

           


        }


    }
}
