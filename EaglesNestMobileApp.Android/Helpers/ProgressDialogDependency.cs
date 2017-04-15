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
    public class CustomProgressDialog : ICustomProgressDialog
    {
        ProgressDialog _dialog;
        Context _context;

        public CustomProgressDialog(Context context)
        {
            this._context = context;
        }

        public void StartProgressDialog(string title, string message)
        {
            _dialog = new ProgressDialog(_context);
            _dialog.SetTitle(title);
            _dialog.SetMessage(message);
            _dialog.SetCancelable(false);
            _dialog.Show();
        }

        public void DismissProgressDialog()
        {
            _dialog.Dismiss();
        }
    }
}