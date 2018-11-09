using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.RestClient;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.RestClient;

namespace Pt_Hippo_Mobile.LoggedException
{
    public class ExceptionModel
    {
        public string Message;
        public string StackTrace;
    }
    public class LoggedException : Exception
    {
        public bool TimeOutExceptionMethod(Exception ex)
        {
            if (ex is TaskCanceledException)
            {
                LoadingIndicatorHelper.HideIndicator();
                App.Current.MainPage.DisplayAlert("Slow Connection", "Slow connection detected between your device and PTHippo servers", "Cancel");
                return true;
            }
            return false;
        }

        string refrence = null;
        private Exception originalException;
        private ExceptionModel model;
        private bool _isTimeout = false;
        public LoggedException(string message, Exception ex)
        {
            _isTimeout = TimeOutExceptionMethod(ex);
            if (!_isTimeout)
            {
                refrence = Guid.NewGuid().ToString();
                originalException = ex;
                model = new ExceptionModel();
                model.Message = refrence + ": " + message;
                while (ex != null)
                {
                    if (ex.Message != null)
                    {
                        model.Message += " " + ex.Message;

                    }

                    if (ex.StackTrace != null)
                    {
                        model.StackTrace += " " + ex.StackTrace;
                    }

                    ex = ex.InnerException;
                }
            }
        }

        public async Task LoggAPI()
        {
            try
            {
                if (_isTimeout)
                {
                    return;
                }
               
                if (CrossConnectivity.Current.IsConnected)
                {
                    RestClient<object> api = new RestClient<object>();
                    if (model.StackTrace == null)
                    {
                        model.StackTrace = "";
                    }
                    else
                    {
                        model.StackTrace = Regex.Replace(model.StackTrace, @"[^0-9a-zA-Z]+", "_");
                        if (model.StackTrace.Length >= 2048)
                        {
                            model.StackTrace = model.StackTrace.Substring(0, 2023);
                        }

                    }

                    if (model.Message == null)
                    {
                        model.Message = refrence + ": ";
                    }
                    else
                    {

                        if (model.Message.Length >= 2048)
                        {
                            model.Message = model.Message.Substring(0, 2023);
                        }
                    }

                    await api.Post(URLConfig.MobileLogging, model);
                    //throw originalException;
                    //instead of throwing the expetion we will show error message;
                    await InternetOrServeHelper.ShowErrorMessage(refrence);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
