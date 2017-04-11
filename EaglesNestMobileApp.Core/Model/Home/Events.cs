using GalaSoft.MvvmLight;
using System;

namespace EaglesNestMobileApp.Core.Model.Home
{
    public class Events : ObservableObject
    {
        public string Id { get; set; }
        public string Version { get; set; }
        public string EventName { get; set; }
        public string EventTime { get; set; }
        public string EventDescription { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }


    }
}
