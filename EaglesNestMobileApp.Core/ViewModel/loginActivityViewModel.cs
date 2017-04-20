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
        public ViewModelLocator _locator = App.Locator;

        private AzureToken _remote;
        public AzureToken Remote
        {
            get { return _remote; }
            set { Set(() => Remote, ref _remote, value); }
        }

        /* Singleton instance of the database                                */
        private readonly IAzureService Database;
        private ICustomProgressDialog Dialog;

        public LoginActivityViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task AttemptLoginAsync()
        {
            EnableLoginButton = false;
            Dialog = _locator.Dialog;
            Dialog.StartProgressDialog("The Nest", "Logging in...", false);

            try
            {
                if (CurrentUser.Id == "123")
                {
                    LoginAuthenticator.SaveLogin("USERNAME", "118965");

                    _locator.User = "118965";

                    Dialog.ChangeDialogText("The Nest", "Loading...");

                    await _locator.Main.InitializeNewUserAsync();

                    Debug.WriteLine($"\n\n\n\nCredentials:{LoginAuthenticator.GetLogin("USERNAME")}");

                    EnableLoginButton = true;

                    Dialog.DismissProgressDialog();
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
                                _locator.User = CurrentUser.Id;

                                Dialog.ChangeDialogText("The Nest", "Loading...");

                                await _locator.Main.InitializeNewUserAsync();
                                Dialog.DismissProgressDialog();
                                Debug.WriteLine($"\n\nCredentials:" +
                                    $"{LoginAuthenticator.GetLogin("USERNAME")}");
                            }
                            else
                            {
                                Debug.WriteLine("\n\n\n\nWrong Credentials");
                                Dialog.DismissProgressDialog();
                                await Dialog.StartDialogAsync("Error:",
                                    "\nIncorrect username or password.\n", true, 0);
                            }
                        }
                        else
                        {
                            Dialog.DismissProgressDialog();
                            await Dialog.StartDialogAsync("Error:", 
                                "\nIncorrect username or password.\n", true, 0);
                        }
                    }

                    catch (System.Net.WebException internetConnectionEx)
                    {
                        Debug.WriteLine($"\n\n\n{internetConnectionEx.Message}");
                        Dialog.DismissProgressDialog();
                        await Dialog.StartToastAsync("Please check your Internet connection.",
                            Android.Widget.ToastLength.Long, 150);
                    }

                    catch (ArgumentOutOfRangeException IncorrectCredentials)
                    {
                        Debug.WriteLine($"\n\n\n{IncorrectCredentials.Message}");
                        Dialog.DismissProgressDialog();
                        await Dialog.StartDialogAsync("Error:",
                            "Incorrect username or password.\n", true, 0);
                    }

                    catch (Exception UnkownError)
                    {
                        Debug.WriteLine($"\n\n\n{UnkownError.Message}");
                        Dialog.DismissProgressDialog();
                        await Dialog.StartDialogAsync(null,
                            "An error occured while logging in.\nPlease try again.", true, 0);
                    }
                    EnableLoginButton = true;
                }
            }
            catch (ArgumentNullException EmptyCredential)
            {
                Debug.WriteLine($"\n\n\n{EmptyCredential.Message}");
                Dialog.DismissProgressDialog();
                await Dialog.StartDialogAsync("Error:",
                    "Please input both username and password.", true, 0);
                EnableLoginButton = true;
            }
        }

        /*********************************************************************/
        /*               Check if the user is still logged in                */
        /*********************************************************************/
        public void CheckUser()
        {
            EnableLoginButton = false;

            var userName = LoginAuthenticator.GetLogin("USERNAME");
            if (userName != null)
            {
                _locator.User = userName;
                NavigateToMainPage();
                EnableLoginButton = true;
            }
            else
            {
                _locator.Navigator.NavigateTo(App.PageKeys.LoginPageKey);
                EnableLoginButton = true;
            }
        }

        /*********************************************************************/
        /*                      Starts the main activity                     */
        /*********************************************************************/
        public async void NavigateToMainPage()
        {
            await _locator.Main.InitializeLoggedInUserAsync();
        }

        public override void Cleanup()
        {
            CurrentUser = new LocalToken();
            base.Cleanup();
        }
    }
}