using GalaSoft.MvvmLight;
using System;

namespace EaglesNestMobileApp.Core.Model.Personal
{
    public class StudentEvent : ObservableObject
    {
        public string Version { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string Id { get; set; }
        public string StudentId { get; set; }
        public string Title { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public string Location { get; set; }
        public string Day { get; set; }
    }
}
