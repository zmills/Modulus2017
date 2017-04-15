using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Contracts
{
    public interface ICustomProgressDialog
    {
        void StartProgressDialog(string title, string message);
        void DismissProgressDialog();
    }
}
