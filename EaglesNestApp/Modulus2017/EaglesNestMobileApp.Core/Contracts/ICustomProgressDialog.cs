using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Contracts
{
    public interface ICustomProgressDialog
    {
        Task StartDialogAsync(string title, string message, bool cancellable, int delay);
        void StartProgressDialog(string title, string message, bool cancellable);
        void DismissProgressDialog();
        void DismissDialog();
        void ChangeDialogText(string title, string message);
        Task StartToastAsync(string message, ToastLength length, int delay);
    }
}
