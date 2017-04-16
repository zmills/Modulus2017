using GalaSoft.MvvmLight;
using System;

namespace EaglesNestMobileApp.Core.Model.Campus
{
    public class Offense : ObservableObject
    {
        public string Id { get; set; }
        public string StudentId { get; set; }
        public string OffenseDescription { get; set; }
        public string OffenseDate { get; set; }
        public string OffenseName { get; set; }
        public float  Demerits { get; set; }
        public string OffenseTime { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string Version { get; set; }
        public string OffenseTitle
        {
            get
            {
                if (OffenseName == "Write Up")
                    return OffenseDescription;
                else
                    return OffenseName;
            }
        }
    }
}
