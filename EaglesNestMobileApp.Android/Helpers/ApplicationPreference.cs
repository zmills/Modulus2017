using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EaglesNestMobileApp.Core.Contracts;

namespace EaglesNestMobileApp.Android.Helpers
{
    public class ApplicationPreference : ICheckLogin
    {
        ISharedPreferences _preferences =
               Application.Context.GetSharedPreferences("PREF_NAME", 
                   FileCreationMode.Private);

        ISharedPreferencesEditor _preferencesEditor;

        public void SaveLogin(string key, string value)
        {
             _preferencesEditor = _preferences.Edit();

            _preferencesEditor.PutString(key, value);
            _preferencesEditor.Apply();
        }

        public string GetLogin(string key)
        {
            return _preferences.GetString(key, null);
        }

        public void Logout(string key)
        {
            _preferences.Edit().Remove(key).Apply();
        }

        public void SaveTheme(string key, string value)
        {
            _preferencesEditor = _preferences.Edit();

            _preferencesEditor.PutString(key, value);
            _preferencesEditor.Apply();
        }

        public string GetTheme(string key)
        {
            return _preferences.GetString(key, null);
        }

        public void DeleteTheme(string key)
        {
            _preferences.Edit().Remove(key).Apply();
        }
    }
}