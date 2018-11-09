using System;
using System.Windows.Input;
using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.contactus;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.ViewModel
{
    public class contactusviewmodel :BaseViewModel
    {

        public static bool ReCenterViewToContactUs = false;
        string subject;
        public string Subject
        {
            get { return subject; }
            set { subject = value;OnPropertyChangedEventhander(); }
        }
        public string Email { get; set; }
        public string FullName { get; set; }
        string message;
        public string MessageBody
        {
            get { return message; }
            set
            {
                message = value;OnPropertyChangedEventhander();
            }
        }
        public DateTime? MessageTime { get; set; }
        private bool busy = false;

        public bool IsBusy
        {
            get { return busy; }
            set
            {
                if (busy == value)
                    return;

                busy = value;
                OnPropertyChanged("IsBusy");
            }
        }
        contactusmodel contactusmodel;

        ContactUsRest contactus = new ContactUsRest();
        public contactusviewmodel()
        {
          
        }
        public ICommand send
        {
            get
            {
                return new Command(async () =>
                {
                 
                        try
                        {

                        if (string.IsNullOrEmpty(Subject) && string.IsNullOrEmpty(MessageBody))
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.AllFieldsAreRequired, AlertMessages.OkayTitle);
                            return;
                        }
                        if(string.IsNullOrEmpty(Subject) || string.IsNullOrWhiteSpace(Subject))
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle,"Subject is required", AlertMessages.OkayTitle);
                            return;
                        }
                        if (string.IsNullOrEmpty(MessageBody)||string.IsNullOrWhiteSpace(MessageBody))
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please write your message/comments", AlertMessages.OkayTitle);
                            return;
                        }




                            contactusmodel = new contactusmodel()
                            {
                                Subject = Subject,
                                Email = Settings.Username,
                                FullName = Settings.FirstName + Settings.LastName,
                                MessageBody = MessageBody,
                                MessageTime = DateTime.Now

                            };
                            ReCenterViewToContactUs = true;
                            var succed = await contactus.Postcontacts(URLConfig.Getapicontactus, contactusmodel);
                            if (succed)
                            {

                                MessageBody = string.Empty;
                                Subject = string.Empty;
                                await Application.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.Contact, AlertMessages.OkayTitle);
                            }
                            else
                            {
                            await Application.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Message failed to send", AlertMessages.OkayTitle);
                            }

                        
                 
                }
                    catch (Exception ex)
                    {
                        var logged = new LoggedException.LoggedException("Error in contactusviewmodel", ex);
                        await logged.LoggAPI();
                    }
                   
                   // System.Diagnostics.Debug.WriteLine("done");
                    //Toast.ShortMessage("Thank you for contact us");

                });
            }
        }
    }
}
