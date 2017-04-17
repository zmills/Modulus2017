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
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Android.Helpers
{
    public class CustomProgressDialog : ICustomProgressDialog
    {
        ProgressDialog _dialog;
        AlertDialog _normalDialog;
        AlertDialog _appDialog;
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


        public async Task StartDialogAsync(string title, string message, bool cancellable, int delay)
        {
            AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(_context);
            _normalDialog = dialogBuilder.Create();
            _normalDialog.SetTitle(title);
            _normalDialog.SetMessage(message);
            _normalDialog.SetCancelable(cancellable);
            _normalDialog.Window.SetWindowAnimations(Resource.Style.Base_Animation_AppCompat_DropDownUp);
            await Task.Delay(delay);
            _normalDialog.Show();
        }

        public void DismissProgressDialog()
        {
            _dialog.Dismiss();
        }

        public void ChangeDialogText(string title, string message)
        {
            (_context as Activity).RunOnUiThread(()=> 
                {
                    _dialog.SetTitle(title);
                    _dialog.SetMessage(message);
                });
        }

        public void DismissDialog()
        {
            _normalDialog.Dismiss();
        }

        public async Task StartToastAsync(string message, ToastLength length, int delay)
        {
            await Task.Delay(delay);
            Toast.MakeText(_context, message, length).Show();
        }
    }
}