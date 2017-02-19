using EaglesNestMobileApp.Core.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class LoginActivityViewModel : ViewModelBase
    {
        private RelayCommand _loginCommand;
        public LocalToken CurrentUser { get; set; }

        public RelayCommand LoginCommand => _loginCommand ??
            (_loginCommand = new RelayCommand(() => NavigateToMainPage()));

        private void AttemptLogin()
        {
            if (CurrentUser.Id == "12345" && CurrentUser.Password == "12345")
                NavigateToMainPage();
        }

        private void NavigateToMainPage()
        {
            App.Locator.Navigator.NavigateTo(App.PageKeys.MainPageKey);
        }

        //private async void AttemptLoginAsync()
        //{
        //    try
        //    {
        //        // Azure Token needs to be gotten here
        //        // if(Authenticator.VerifyPassword(CurrentUser.Password, AZURETOKEN.PASSWORD, AZURETOKEN.SALT))
        //        {
        //            CurrentUser.LoggedIn = true;
        //            // INSERT USER TOKEN IN LOCAL DATABASE
                    
        //        }

        //    }
        //    catch (Exception NoConnection)
        //    {
        //        NoConnection.ToString();
        //        CurrentUser.LoggedIn = false;
        //    }
        //}
    }
}