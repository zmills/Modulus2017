using System;

namespace EaglesNestMobileApp.Core.Model.Home
{
    public class EventSlot
    {
        public string Id { get; set; }
        public string Version { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string StudentId { get; set; }
        public string EventId { get; set; }
    }
}
