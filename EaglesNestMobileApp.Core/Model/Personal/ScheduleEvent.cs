using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Model.Personal
{
    public class ScheduleEvent : ObservableObject
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public string Day { get; set; }
    }
}
