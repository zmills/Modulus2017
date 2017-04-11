using EaglesNestMobileApp.Core.Model.Home;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class EventsFragmentViewModel : ViewModelBase
    {
        public ObservableCollection<EventsSignUp> Events { get; set; }

        public void Initialize()
        {
            Events = new ObservableCollection<EventsSignUp>();

            ///* Loop through inserting cards in the announcements list after  */
            ///* titling them and providing an image                           */
            //for (int counter = 0; counter < 20; counter++)
            //{
            //    EventsSignUp current = new EventsSignUp("Event " + counter,
            //                                "Event Description", "SIGNUP");
            //    Events.Add(current);
            //}
        }

        public void Refresh()
        {
            Events.Clear();

            //for (int counter = 0; counter < 10; counter++)
            //{
            //    EventsSignUp current = new EventsSignUp("NEW CARD" + counter,
            //                                "Event Description", "SIGNUP");
            //    Events.Add(current);
            //}
        }
    }
}
