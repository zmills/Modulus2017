using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Contracts
{
    public interface ICheckLogin
    {
        void SaveLogin(string key, string value);
        string GetLogin(string key);
        void Logout(string key);
    }
}
