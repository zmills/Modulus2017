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

        public void StartProgressDialog(string title, string message, bool cancellable)
        {
            _dialog = new ProgressDialog(_context);
            _dialog.SetTitle(title);
            _dialog.SetMessage(message);
            _dialog.SetCancelable(cancellable);
            _dialog.Show();
        }

        public void DismissProgressDialog()
        {
            _dialog.Dismiss();
        }

        public void StartToast(string message, ToastLength length)
        {
            Toast.MakeText(_context, message, length).Show();
        }
    }
}