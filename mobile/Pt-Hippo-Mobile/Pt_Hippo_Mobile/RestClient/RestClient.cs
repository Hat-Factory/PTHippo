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
using System.Linq;
using Pt_Hippo_Mobile.Enums;
using Pt_Hippo_Mobile.LoggedException;
using System.Net;
using Pt_Hippo_Mobile.RestClient;
using System.Threading;

namespace Plugin.RestClient
{

    public class RestClient<T>
    {
        private const int _numberOfSecondsForTimeOut = 30 * 1000;
        private HttpClient httpClient = null;

        public RestClient()
        {
            httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMilliseconds(_numberOfSecondsForTimeOut);
        }
        private async Task PreAPICall()
        {
            LoadingIndicatorHelper.AddProgressDisplay();

            //Check Internet Connection
            if (!CrossConnectivity.Current.IsConnected)
            {
                await InternetOrServeHelper.ShowCheckInternet();
            }
            else
            {
                InternetOrServeHelper.ShowNoInternetMessage = false;
            }
        }


        private void AfterAPICall()
        {
            LoadingIndicatorHelper.HideIndicator();
        }

        private async Task<string> HandleGetStringAsync(HttpClient httpClient, string url)
        {
            try
            {
                return await httpClient.GetStringAsync(url);
            }
            catch (Exception ex)
            {

                throw new LoggedException("Server error Please contact PT Hippo Admin", ex);
            }
        }


        public async Task<T> GetSearch(string api, string searchtext, int pagesize, int pagenumber, string zipcode, DateTime startdate, DateTime enddate, double minhourrate, double maxhourate)
        {
            try
            {
                await PreAPICall();

                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
                //string json = "";
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
                //string json = "";
                //GET /api/job/getBasicSearchForJobs/{pageSize}/{pageNumber}/{zipCode}/{startDate}/{endDate}/{minHourRate}/{maxHourRate}
                string startDateText = "null";
                string endDateText = "null";
                if (startdate != DateTime.MinValue)
                {
                    startDateText = startdate.Date.ToString("MM-dd-yyyy");
                }

                if (enddate != DateTime.MinValue)
                {
                    endDateText = enddate.Date.ToString("MM-dd-yyyy");
                }

                string url =
                    $"{constants.serverUrl}/{api}/{pagesize}/{pagenumber}/{zipcode}/{startDateText}/{endDateText}/{minhourrate}/{maxhourate}";
                var json = await httpClient.GetStringAsync(url);

                var taskModels = JsonConvert.DeserializeObject<T>(json);
                AfterAPICall();
                return taskModels;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException($"Error while trying to call getsearchapi api {api}", ex);
                await logged.LoggAPI();
            }

            return default(T);
        }


        public async Task<T> GetAsync(string api, string id)
        {
            try
            {
                await PreAPICall();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);

                string url = id == null ? $"{constants.serverUrl}/{api}" : $"{constants.serverUrl}/{api}/" + id;

                var result = await httpClient.GetAsync(url);
                if (result.IsSuccessStatusCode == false)
                {
                    AfterAPICall();
                    await ValidateErrors(result);
                    return default(T);
                }

                var json = await result.Content.ReadAsStringAsync();
                var taskModels = JsonConvert.DeserializeObject<T>(json);

                AfterAPICall();
                return taskModels;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException($"Error while trying to call getasync api {api}", ex);
                await logged.LoggAPI();
            }
            return default(T);
        }


        public async Task<List<T>> GetListOptionalId(string api, string id, bool authorize = true)
        {
            try
            {
                await PreAPICall();
                if (authorize)
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
                }
                string url = id == null ? $"{constants.serverUrl}/{api}" : $"{constants.serverUrl}/{api}/" + id;

                var json = await httpClient.GetStringAsync(url);

                var taskModels = JsonConvert.DeserializeObject<List<T>>(json);
                AfterAPICall();
                return taskModels;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException($"Error while trying to call  api {api}", ex);
                await logged.LoggAPI();
            }
            return null;
        }



        //PostAuth
        public async Task<bool> Post(string api, string id, bool authorize = true)
        {
            try
            {
                await PreAPICall();
                if (authorize)
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
                }
                var json = JsonConvert.SerializeObject(id);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PostAsync($"{constants.serverUrl}/{api}/{id}", httpContent);
                AfterAPICall();
                if (result.IsSuccessStatusCode == false)
                {
                    await ValidateErrors(result);
                    return false;
                }
                return result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException($"Error while trying to call postauth api {api}", ex);
                await logged.LoggAPI();
            }
            return false;
        }


        public async Task<T> Post(string api, object data)
        {
            try
            {
                await PreAPICall();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);

                var json = JsonConvert.SerializeObject(data);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                string url = $"{constants.serverUrl}/{api}";
                var result = await httpClient.PostAsync(url, httpContent);
                var Data = await result.Content.ReadAsStringAsync();
                if (api == URLConfig.MobileLogging)
                {
                    AfterAPICall();
                    return default(T);
                }

                if (result.IsSuccessStatusCode == false)
                {
                    AfterAPICall();
                    await ValidateErrors(result);
                    return default(T);
                }

                var taskModels = JsonConvert.DeserializeObject<T>(Data);
                AfterAPICall();
                return taskModels;

            }
            catch (Exception ex)
            {
                var logged = new LoggedException($"Error while trying to call postdata api {api}", ex);
                await logged.LoggAPI();
            }
            return default(T);

        }


        public async Task<bool> PostApi(string api, object data)
        {
            try
            {
                await PreAPICall();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);

                var json = JsonConvert.SerializeObject(data);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                string url = $"{constants.serverUrl}/{api}";
                var result = await httpClient.PostAsync(url, httpContent);
                var Data = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode == false)
                {
                    AfterAPICall();
                    await ValidateErrors(result);
                    return false;
                }
                AfterAPICall();
                return result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException($"Error while trying to call postdata api {api}", ex);
                await logged.LoggAPI();
            }
            return false;

        }

        private async Task<bool> ValidateErrors(HttpResponseMessage message)
        {
            if (message != null)
            {
                if (message.StatusCode == System.Net.HttpStatusCode.BadRequest || message.StatusCode == HttpStatusCode.InternalServerError)
                {
                    string allErrors = GetErrorsFromResponseErrors(message);
                    if (allErrors != null && allErrors.Contains("second operation") == false)
                    {
                        await App.Current.MainPage.DisplayAlert("PT Hippo Error !", $"{allErrors}", AlertMessages.OkayTitle);
                    }
                    return false;
                }
            }
            return true;
        }

        public static string GetErrorsFromResponseErrors(HttpResponseMessage response)
        {
            var httpErrorObject = response.Content.ReadAsStringAsync().Result;

            // Create an anonymous object to use as the template for deserialization:
            var anonymousErrorObject =
                new { message = "", ModelState = new Dictionary<string, string[]>() };

            // Deserialize:
            var deserializedErrorObject =
                JsonConvert.DeserializeAnonymousType(httpErrorObject, anonymousErrorObject);

            // Now wrap into an exception which best fullfills the needs of your application:
            var allErrors = string.Empty;

            // Sometimes, there may be Model Errors:
            if (deserializedErrorObject.ModelState != null)
            {
                var errors =
                    deserializedErrorObject.ModelState
                                            .Select(kvp => string.Join(". ", kvp.Value));
                for (int i = 0; i < errors.Count(); i++)
                {
                    // Wrap the errors up into the base Exception.Data Dictionary:
                    if (allErrors != string.Empty)
                    {
                        allErrors += "," + errors.ElementAt(i);
                    }
                    else
                    {
                        allErrors += errors.ElementAt(i);
                    }
                }
            }
            // Othertimes, there may not be Model Errors:
            else
            {
                var error =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(httpErrorObject);
                foreach (var kvp in error)
                {
                    // Wrap the errors up into the base Exception.Data Dictionary:
                    if (allErrors != string.Empty)
                    {
                        allErrors += "," + kvp.Value;
                    }
                    else
                    {
                        allErrors += kvp.Value;
                    }

                }
            }
            return allErrors;
        }

        public async Task<bool> PutAsync(string api, string id, object data, bool authorize = true)
        {
            try
            {
                await PreAPICall();
                if (authorize)
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
                }

                var json = JsonConvert.SerializeObject(data);

                HttpContent httpContent = new StringContent(json);

                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                string url = string.IsNullOrEmpty(id) == true ? $"{constants.serverUrl}/{api}" : $"{constants.serverUrl}/{api}/" + id;

                var result = await httpClient.PutAsync(url, httpContent);
                AfterAPICall();
                if (result.IsSuccessStatusCode == false)
                {
                    await ValidateErrors(result);
                    return false;
                }
                return result.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                var logged = new LoggedException($"Error while trying to call putasync api {api}", ex);
                await logged.LoggAPI();
            }
            return false;
        }


        //update List Async
        public async Task<bool> PutListAsync(List<T> data, string api)
        {
            try
            {
                await PreAPICall();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
                var json = JsonConvert.SerializeObject(data);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PutAsync($"{constants.serverUrl}/{api}", httpContent);
                AfterAPICall();
                if (result.IsSuccessStatusCode == false)
                {
                    await ValidateErrors(result);
                    return false;
                }
                return result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException($"Error while trying to call putlist api {api}", ex);
                await logged.LoggAPI();
            }
            return false;
        }


        public async Task<bool> DeleteAsync(string id, string url)
        {
            try
            {
                await PreAPICall();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
                var response = await httpClient.DeleteAsync($"{constants.serverUrl}/{url}/{id}");
                AfterAPICall();
                if (response.IsSuccessStatusCode == false)
                {
                    await ValidateErrors(response);
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException($"Error while trying to call deleteasync api {url}", ex);
                await logged.LoggAPI();
            }
            return false;
        }


        public async Task<List<T>> UploadMediafile(string path, string docuemntId, bool IsProfilePic, DocumentType documentType, bool IsEmployee, byte[] bytearray, string fileName, string url, string Title = null)
        {

            string response = string.Empty;

            try
            {
                await PreAPICall();
                if (!CrossConnectivity.Current.IsConnected)
                {
                    await App.Current.MainPage.DisplayAlert("you have trouble connecting the internet", AlertMessages.internetconnection, AlertMessages.OkayTitle);
                    return null;
                }
                var client = new HttpClient();
                using (var content = new MultipartFormDataContent())
                {
                    if (path != null && bytearray != null)
                    {
                        content.Add(new StreamContent(new MemoryStream(bytearray)), Path.GetDirectoryName(path), fileName);

                        // content.Add(new StreamContent(new MemoryStream(bytearray)), fileName, fileName);
                    }

                    content.Add(new StringContent("true"), "IsEmployee");
                    if (string.IsNullOrEmpty(Title) == false)
                    {
                        content.Add(new StringContent(Title), "Title");
                    }
                    content.Add(new StringContent(IsProfilePic == true ? "true" : "false"), "IsProfilePic");
                    if (string.IsNullOrEmpty(docuemntId) == false)
                    {
                        content.Add(new StringContent(docuemntId), "DocumentId");
                    }
                    content.Add(new StringContent(((int)documentType).ToString()), "DocumentType");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Pt_Hippo_Mobile.Helpers.Settings.AccessToken);
                    var httpResponseMessage = await client.PostAsync($"{constants.serverUrl}/{url}", content);
                    response = await httpResponseMessage.Content.ReadAsStringAsync();
                    var imageinfo = JsonConvert.DeserializeObject<List<T>>(response);
                    AfterAPICall();
                    await ValidateErrors(httpResponseMessage);
                    if (httpResponseMessage.IsSuccessStatusCode == false)
                    {
                        await ValidateErrors(httpResponseMessage);
                        return null;
                    }
                    return imageinfo;

                }
            }

            catch (Exception ex)
            {
                var logged = new LoggedException($"Error while trying to call uploadfiledata api {url} with response {response}", ex);
                await logged.LoggAPI();
            }
            return null;
        }


        public async Task<T> GetClientId(string url)
        {
            try
            {
                await PreAPICall();
                HttpResponseMessage response = await httpClient.GetAsync($"{constants.serverUrl}/{url}");
                var stream = await response.Content.ReadAsStreamAsync();
                StreamReader readStream = new StreamReader(stream, Encoding.UTF8);
                var json = readStream.ReadToEnd();
                var account = JsonConvert.DeserializeObject<T>(json);
                AfterAPICall();
                if (response.IsSuccessStatusCode == false)
                {
                    await ValidateErrors(response);
                    return default(T);
                }
                return account;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException($"Error while trying to call getclientid api {url}", ex);
                await logged.LoggAPI();
            }
            return default(T);
        }

        public async Task<string> LoginAsync(string userName, string password, AccountIdApi account, string url, List<KeyValuePair<string, string>> KeyValues)
        {
            try
            {

                await PreAPICall();
                var request = new HttpRequestMessage(HttpMethod.Post, $"{constants.serverUrl}/{url}");

                request.Content = new FormUrlEncodedContent(KeyValues);
                var respons = await httpClient.SendAsync(request);
                var jwt = await respons.Content.ReadAsStringAsync();
                JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);
                var accessToken = jwtDynamic.Value<string>("access_token");
                Debug.WriteLine(jwt);
                AfterAPICall();
                return accessToken;
            }
            catch (Exception ex)
            {
                var logged = new LoggedException($"Error while trying to call login api {url}", ex);
                await logged.LoggAPI();
            }
            return null;
        }


        //public async Task<T> GetStripeClientId(string url)
        //{
        //    try
        //    {
        //        await PreAPICall();
        //        HttpResponseMessage response = await httpClient.GetAsync($"{constants.serverUrl}/{url}");
        //        var stream = await response.Content.ReadAsStreamAsync();
        //        StreamReader readStream = new StreamReader(stream, Encoding.UTF8);
        //        var json = readStream.ReadToEnd();
        //        var account = JsonConvert.DeserializeObject<T>(json);
        //        AfterAPICall();
        //        if (response.IsSuccessStatusCode == false)
        //        {
        //            await ValidateErrors(response);
        //            return default(T);
        //        }
        //        return account;
        //    }
        //    catch (Exception ex)
        //    {
        //        var logged = new LoggedException($"Error while trying to call getstripeclientid api {url}", ex);
        //        await logged.LoggAPI();
        //    }
        //    return default(T);
        //}
    }
}

