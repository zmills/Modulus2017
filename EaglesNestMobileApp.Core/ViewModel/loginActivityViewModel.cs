using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class LoginActivityViewModel : ViewModelBase
    {
        // This command handles the login event
        private RelayCommand _loginCommand;

        private LocalToken _currentUser = new LocalToken();

        public LocalToken CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public RelayCommand LoginCommand => _loginCommand ??
            (_loginCommand = new RelayCommand(() => AttemptLoginAsync()));

        // This function allows the user to login providing he has the correct credentials
        private async void AttemptLoginAsync()
        {
            // REMEMBER TO REMOVE BACKDOOR
            if (CurrentUser.Id == "123")
                NavigateToMainPage();
            else
            {
                // This will take a while depending on the Internet connection speed. Consider giving the
                // user some indication. 
                try
                {
                    AzureToken remote = await GetLogin();

                    // Compare the given credentials with the one gotten from Azure and navigate to the mainpage
                    // The plan is to save CurrentUser in the database as a TOKEN so that we can query using
                    // the id number whenever we need to get information related to that student
                    if (Authenticator.VerifyPassword(CurrentUser.Password, remote.Passwordhash, remote.Salt))
                    {
                        CurrentUser.LoggedIn = true;
                        NavigateToMainPage();
                    }
                }
                // How are we going to signal to the user the different errors? NO INTERNET ACCESS, BAD CREDENTIALS
                // Should we check for Internet access once the application loads and warn them there?
                catch (Exception NoConnection)
                {
                    Debug.WriteLine(NoConnection.ToString());
                    CurrentUser.LoggedIn = false;
                }
            }
        }

        // Get the login table based off of the id number inserted; the Azure querying should use
        // a function from the Azure class/library. THIS MUST BE REFACTORED
        private async Task<AzureToken> GetLogin()
        {
            MobileServiceClient client = new MobileServiceClient("http://modulus.azurewebsites.net");

            IMobileServiceTable<AzureToken> LoginTable = client.GetTable<AzureToken>();

            List<AzureToken> Tokens = 
                await LoginTable.Where(current => current.Id == CurrentUser.Id).ToListAsync();

            return Tokens.ToArray()[0];
        }

        private void NavigateToMainPage()
        {
            App.Locator.Navigator.NavigateTo(App.PageKeys.MainPageKey);
        }

    }
}