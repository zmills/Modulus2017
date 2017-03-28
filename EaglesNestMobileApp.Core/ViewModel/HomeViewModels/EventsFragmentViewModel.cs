using EaglesNestMobileApp.Core.Model.Home;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class EventsFragmentViewModel : ViewModelBase
    {
        public ObservableCollection<EventsSignUpCard> Events { get; set; }

        public void InitializeVm()
        {
            Events = new ObservableCollection<EventsSignUpCard>();

            /* Loop through inserting cards in the announcements list after  */
            /* titling them and providing an image                           */
            for (int counter = 0; counter < 20; counter++)
            {
                EventsSignUpCard current = new EventsSignUpCard("Event " + counter,
                                            "Event Description", "SIGNUP");
                Events.Add(current);
            }
        }

        public void Refresh()
        {
            Events.Clear();

            for (int counter = 0; counter < 10; counter++)
            {
                EventsSignUpCard current = new EventsSignUpCard("NEW CARD" + counter,
                                            "Event Description", "SIGNUP");
                Events.Add(current);
            }
        }
    }
}
