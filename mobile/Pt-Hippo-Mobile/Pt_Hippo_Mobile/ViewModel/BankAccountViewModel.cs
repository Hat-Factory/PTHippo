using Pt_Hippo_Mobile.Helpers;
using Pt_Hippo_Mobile.Model;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using Pt_Hippo_Mobile.RestClient;
using Pt_Hippo_Mobile.RestClient.BankAccountrest;
using Pt_Hippo_Mobile.RestClient.BasicinformationRest;
using Pt_Hippo_Mobile.RestClient.BasicInfosUpdate;
using Pt_Hippo_Mobile.RestClient.ZipCode;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pt_Hippo_Mobile.ViewModel
{
    class BankAccountViewModel : BaseViewModel
    {
        private BankAccount _bankinfo;
        public BankAccount Bankinfo
        {
            get { return _bankinfo; }
            set
            {
                _bankinfo = value;
                OnPropertyChangedEventhander();
            }
        }


        public ObservableCollection<BankAccount> BankAccount;

        public ObservableCollection<BankAccount> bankAccount
        {
            get { return BankAccount; }
            set
            {
                BankAccount = value;
                OnPropertyChangedEventhander();
            }
        }

        private EmployeeCurrentProfile employee;

        public EmployeeCurrentProfile Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChangedEventhander();
            }
        }
        private bool _isenable;

        public bool isenabel
        {
            get { return _isenable; }
            set { _isenable = value; OnPropertyChangedEventhander(); }
        }

        UpdateBankAccount UB = new UpdateBankAccount();
        Zipcode zc = new Zipcode();


        private string bname;

        public string bankName
        {
            get { return bname; }
            set
            {
                bname = value;
                OnPropertyChangedEventhander();
            }
        }

        private string acnamber;

        public string accountNumber
        {
            get { return acnamber; }
            set
            {
                acnamber = value;
                OnPropertyChangedEventhander();
            }
        }

        private string rnumber;

        public string routingNumber
        {
            get { return rnumber; }
            set
            {
                rnumber = value;
                OnPropertyChangedEventhander();
            }
        }

        private string empid;

        public string employeeProfileId
        {
            get { return empid; }
            set
            {
                empid = value;
                OnPropertyChangedEventhander();
            }
        }

        private string zcode;

        public string zipCode
        {
            get { return zcode; }
            set
            {
                zcode = value;
                OnPropertyChangedEventhander();
            }
        }
        private string statename;
        public string SateName
        {
            get { return statename; }
            set
            {
                statename = value;
                OnPropertyChangedEventhander();
            }
        }
        List<statemodel> states;
        public List<statemodel> StatesList
        {
            get
            {
                return states;

            }
            set
            {
                states = value;

                OnPropertyChangedEventhander();
            }
        }
        statemodel selecteditem;
        public statemodel SelectedItem
        {
            get { return selecteditem; }
            set
            {
                selecteditem = value;
                OnPropertyChangedEventhander();

            }
        }


        private string citylocal;

        public string city
        {
            get { return citylocal; }
            set
            {
                citylocal = value;
                OnPropertyChangedEventhander();
            }
        }

        private string streetlocal;

        public string street
        {
            get { return streetlocal; }
            set
            {
                streetlocal = value;
                OnPropertyChangedEventhander();
            }
        }




        public BankAccountViewModel()
        {
            StatesList = Pt_Hippo_Mobile.Helpers.LicenseHelper.StatesList;
            isenabel = true;
            get();
        }
        public async void get()
        {



            try
            {
                // Bankinfo = new Model.BankAccount();
                //selecteditem = new statemodel();  

                Employee = EmployeeProfileHelper.EmployeeCurrentProfile;
                if (Employee == null)
                {
                    return;
                }
                if (Employee.BankAccount == null)
                {
                    return;
                }

                Bankinfo = Employee.BankAccount;
                bankName = Bankinfo.bankName;
                accountNumber = Bankinfo.accountNumber.ToString();
                routingNumber = Bankinfo.routingNumber;
                zipCode = Bankinfo.zipCode;
                SateName = Bankinfo.state;
                city = Bankinfo.city;
                street = Bankinfo.street;
                /*  SelectedItem.stateAbb = banckinfo.state;
                  SelectedItem.state = banckinfo.state;*/

            }
            catch (Exception ex)
            {

                var logged = new LoggedException.LoggedException("Error in banckaccountviewmodel", ex);
                await logged.LoggAPI();
            }

        }


        public ICommand Accountinfo
        {
            get
            {
                return new Command(async () =>
                {


                    try
                    {
                        long number = 0;
                        isenabel = false;

                        if (String.IsNullOrEmpty(SateName) || String.IsNullOrWhiteSpace(SateName))
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Statenull, AlertMessages.OkayTitle);
                            return;
                        }
                        else
                        {
                            var tempstatename = StatesList.Where(x => x.stateAbb == SateName);
                            if (tempstatename != null)
                            {
                                var tempsecond = tempstatename.FirstOrDefault(s => s.stateAbb == statename);
                                if (tempsecond != null)
                                {
                                    if (!string.IsNullOrEmpty(tempsecond.stateAbb))
                                    {
                                        SateName = tempsecond.stateAbb;
                                    }
                                    else
                                    {
                                        await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.StateNameMatching, AlertMessages.OkayTitle);
                                        return;
                                    }
                                }
                                else
                                {
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.StateNameMatching, AlertMessages.OkayTitle);
                                    return;
                                }

                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.StateNameMatching, AlertMessages.OkayTitle);
                                return; 
                            }
                        }
                        if ((string.IsNullOrEmpty(zipCode)))

                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Zipcode, AlertMessages.OkayTitle);
                            return;
                        }
                        else
                        {
                            int.TryParse(zipCode, out int zipcode);
                            if (zipcode == 0)
                            {
                                await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.Zipcode, AlertMessages.OkayTitle);
                                return;
                            }
                        }


                        if (zipCode.Length < 3)
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.zipcodelength, AlertMessages.OkayTitle);
                            return;
                        }
                        if (zipCode.Length > 9)

                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Maximum length for Zipcode is 9", AlertMessages.OkayTitle);
                            return;
                        }

                        var zipcodevr = await zc.GetZipCode(URLConfig.ZipcodeUrl, zipCode);
                        if (zipcodevr == null || zipcodevr.city == null || zipcodevr.locationLat == null)
                        {
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Please enter a valid Zipcode", AlertMessages.OkayTitle);

                            return;

                        }

                        if (string.IsNullOrEmpty(bankName) || string.IsNullOrWhiteSpace(bankName) || string.IsNullOrWhiteSpace(accountNumber.ToString()) || string.IsNullOrEmpty(accountNumber.ToString()) || string.IsNullOrEmpty(routingNumber) || string.IsNullOrWhiteSpace(routingNumber) || string.IsNullOrEmpty(SateName) || string.IsNullOrWhiteSpace(SateName) || string.IsNullOrWhiteSpace(city) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(street) || String.IsNullOrWhiteSpace(street))
                        {
                            // there is missing fields 
                            await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, AlertMessages.AllFieldsAreRequired, AlertMessages.OkayTitle);
                        }
                        else
                        {

                            // isenabel = false;
                            if (string.IsNullOrEmpty(accountNumber) == false)
                            {
                                long.TryParse(accountNumber, out number);

                                if (number == 0)
                                {
                                    await App.Current.MainPage.DisplayAlert(AlertMessages.ErrorTitle, "Invalid bank account number", AlertMessages.OkayTitle);
                                    return;
                                }
                            }
                            BankAccount data = new BankAccount
                            {
                                bankName = bankName,
                                accountNumber = number,
                                routingNumber = routingNumber,
                                zipCode = zipCode,
                                state = SateName,

                                city = city,
                                street = street
                            };
                            var succeed = await UB.UpdateBankAccountAsync(URLConfig.UpdateBankAccountAsync, data);

                            if (succeed)
                            {
                                await EmployeeProfileHelper.RefreshEmployeeCurrentProfile(true);
                                await App.Current.MainPage.DisplayAlert(AlertMessages.Success, AlertMessages.EditedMessage, AlertMessages.OkayTitle);
                            }

                        }




                    }

                    catch (Exception e)
                    {
                        var logged = new LoggedException.LoggedException("banckaccountviewmodel", e);
                        await logged.LoggAPI();

                    }
                    finally
                    {
                        isenabel = true;
                    }
                });
            }
        }


    }
}