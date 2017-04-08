using System;

namespace EaglesNestMobileApp.Core.Model.Home
{
    public class EventsSignUp
    {
        public string Id { get; set; }
        public string Version { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ButtonText { get; set; }
        public EventsSignUp(string title, string description, string buttonText)
        {
            Title = title;
            Description = description;
            ButtonText = buttonText;
        }


    }
}
