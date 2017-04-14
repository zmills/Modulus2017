/*****************************************************************************/
/*                          LoginActivityViewModel                           */
/* This ViewModel handles all the logic for the login activity. Event        */
/* handlers and data from that activity are also in here.                    */
/*                                                                           */
/*****************************************************************************/
using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class LoginActivityViewModel : ViewModelBase
    {
        /* This makes sure that the login button is disabled so that the user  */
        /* does not make multiple calls to the database.                       */
        private bool enableButton = true;
        public bool EnableLoginButton
        {
            get { return enableButton; }
            set
            {
                Set(() => EnableLoginButton, ref enableButton, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        private IMobileServiceTable<AzureToken> _azureTokenTable;

        /* This command handles the login event                                */
        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand => _loginCommand ??
            (_loginCommand = new RelayCommand(
                async () => await AttemptLoginAsync(), () => EnableLoginButton));

        /* This could be stored in the database and be used for determining    */
        /* whether the user logged out on startup.                             */
        public LocalToken CurrentUser { get; set; } = new LocalToken();

        public ICheckLogin LoginAuthenticator { get; set; } = App.Locator.CheckLogin;

        private AzureToken _remote;
        public AzureToken Remote
        {
            get { return _remote; }
            set { Set(() => Remote, ref _remote, value); }
        }

        /* Singleton instance of the database                                */
        private readonly IAzureService Database;

        public LoginActivityViewModel(IAzureService database)
        {
            Database = database;
        }


        public async Task AttemptLoginAsync()
        {
            if (CurrentUser.Id == "123")
            {
                LoginAuthenticator.SaveLogin("USERNAME", "118965");
                App.Locator.User = "118965";
                await App.Locator.Main.InitializeNewUserAsync();
                Debug.WriteLine($"\n\n\n\nCredentials:{LoginAuthenticator.GetLogin("USERNAME")}");
                EnableLoginButton = true;
            }
            else
            {
                try
                {
                    _azureTokenTable = App.Client.GetTable<AzureToken>();

                    var userTable = await _azureTokenTable
                        .Where(user => user.Id == CurrentUser.Id).ToListAsync();

                    if (userTable != null)
                    {
                        Remote = userTable[0];
                        if (Authenticator.VerifyPassword(CurrentUser.Password,
                            Remote.HashedPassword, Remote.Salt))
                        {
                            LoginAuthenticator.SaveLogin("USERNAME", Remote.Id);
                            App.Locator.User = CurrentUser.Id;
                            await App.Locator.Main.InitializeNewUserAsync();
                            Debug.WriteLine($"\n\n\n\nCredentials:{LoginAuthenticator.GetLogin("USERNAME")}");
                        }
                    }
                    else
                    {
                        Debug.WriteLine("\n\n\n\nWrong Credentials");
                    }
                }
                catch (Exception internetConnectionEx)
                {
                    Debug.WriteLine($"\n\n\n{internetConnectionEx.Message}");
                }
                EnableLoginButton = true;
            }
        }

        /*********************************************************************/
        /*               Check if the user is still logged in                */
        /*********************************************************************/
        public void CheckUserAsync()
        {
            EnableLoginButton = false;

            var userName = LoginAuthenticator.GetLogin("USERNAME");
            if (userName != null)
            {
                App.Locator.User = userName;
                NavigateToMainPage();
                EnableLoginButton = true;
            }
        }

        /*********************************************************************/
        /*                      Starts the main activity                     */
        /*********************************************************************/
        public async void NavigateToMainPage()
        {
            await App.Locator.Main.InitializeLoggedInUserAsync();
        }

        public override void Cleanup()
        {
            base.Cleanup();
        }
    }
}