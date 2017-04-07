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

        /* This command handles the login event                                */
        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand => _loginCommand ??
            (_loginCommand = new RelayCommand(
                async () => await AttemptLoginAsync(), () => EnableLoginButton));

        /* This could be stored in the database and be used for determining    */
        /* whether the user logged out on startup.                             */
        public LocalToken CurrentUser { get; set; } = new LocalToken();


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

        /*********************************************************************/
        /* This function allows the user to login providing he has the       */
        /* correct credentials                                               */
        /*********************************************************************/
        private async Task AttemptLoginAsync()
        {
            /* Disable the login button                                      */
            EnableLoginButton = false;

            /* REMEMBER TO REMOVE BACKDOOR                                   */
            if (CurrentUser.Id == "123")
            {
                CurrentUser.Id = "118965";
                await Database.InsertLocalTokenAsync(CurrentUser);
                await Database.SyncAsync(pullData: true);
                NavigateToMainPage();
            }
            else
            {
                /* This will take a while depending on the connection speed. */
                /* Consider giving the user some indication.                 */
                try
                {
                    Remote = await Database.GetAzureTokenAsync(CurrentUser);

                    Debug.WriteLine(Remote.Id);
                    /* Compare the given credentials with the one gotten     */
                    /* from Azure and navigate to the mainpage. The plan is  */
                    /* to save CurrentUser in the database as a TOKEN so     */
                    /* that we can query using the id number whenever we     */
                    /* need to get information related to that student.      */
                    if (Authenticator.VerifyPassword(CurrentUser.Password,
                           Remote.HashedPassword, Remote.Salt))
                    {
                        /* Set the password to empty so that no sensitive    */
                        /* information is actually stored on the phone. Then */
                        /* add the token to the database.                    */
                        CurrentUser.Password = string.Empty;

                        /* Add the user to the database for future use and   */
                        /* also add a reference to the user for the          */
                        /* application lifecycle                             */
                        await Database.InsertLocalTokenAsync(CurrentUser);
                        await Database.SyncAsync(pullData: true);

                        /* Allow access to the application main page         */
                        NavigateToMainPage();

                    }
                }
                /* How are we going to signal to the user the  errors?       */
                /* NO INTERNET ACCESS, BAD CREDENTIALS!                      */
                /* Should we check for Internet access once the app loads    */
                /* loads and warn them there?                                */
                catch (Exception NoConnection)
                {
                    Debug.WriteLine($"{CurrentUser.Id}, " +
                        $"{CurrentUser.Password}, " +
                        $" {NoConnection.ToString()}");
                    CurrentUser.LoggedIn = true;
                }
                finally
                {
                    EnableLoginButton = true;
                }
            }
        }

        /*********************************************************************/
        /*               Check if the user is still logged in                */
        /*********************************************************************/
        public async Task CheckUserAsync()
        {
            /* Disable the login button                                      */
            EnableLoginButton = false;

            /* Initialize the database                                       */
            await Database.InitLocalStore();

            /* Navigate to main page if the user is still logged ing         */
            LocalToken _temporaryToken = await Database.GetLocalTokenAsync();
            if (_temporaryToken != null)
            {
                /* Allow access to the application main page                 */
                App.Locator.User = _temporaryToken;

                await Database.SyncAsync(pullData:true);

                NavigateToMainPage();
            }
            else
                EnableLoginButton = true;
        }

        /*********************************************************************/
        /*                      Starts the main activity                     */
        /*********************************************************************/
        private void NavigateToMainPage()
        {
            App.Locator.Navigator.NavigateTo(App.PageKeys.MainPageKey);
        }
    }
}