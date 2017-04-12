using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Model.Home;
using GalaSoft.MvvmLight;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class EventsFragmentViewModel : ViewModelBase
    {
        /* The ObservableCollection of the events */
        private ObservableCollection<Events> _events = new ObservableCollection<Events>();
        public ObservableCollection<Events> Events
        {
            get { return _events; }
            private set { Set(() => Events, ref _events, value); }
        }

        private List<EventSlot> _eventSignup = new List<EventSlot>();
        private List<Events> _tempEvents = new List<Events>();
        private LocalToken _currentStudent;

        /* Singleton instance of the database                    */
        private readonly IAzureService Database;

        public EventsFragmentViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task InitializeAsync()
        {
            _currentStudent = await Database.GetLocalTokenAsync();
            _eventSignup    = await Database.GetEventSignupAsync();
            _tempEvents    = await Database.GetEventsAsync();

            AnalyzeEvents();
        }

        public async Task Signup(Events eventSignup)
        {
            await Database.InsertEventAsync
            (
                new EventSlot
                {
                    EventId = eventSignup.Id,
                    StudentId = _currentStudent.Id,
                    UpdatedAt = System.DateTimeOffset.Now
                }
            );

            await Refresh();
        }

        public void AnalyzeEvents()
        {
            foreach (var item in _tempEvents)
                foreach (var inner in _eventSignup)
                    if(inner.EventId == item.Id)
                        item.IsSignedUp = true;

            Events.Clear();
            foreach (var item in _tempEvents)
                Events.Add(item);
        }

        public void Initialize()
        {
        }


        public async Task Refresh()
        {
            await Database.SyncAsync(pullData: true);
            await InitializeAsync();
            AnalyzeEvents();
        }
    }
}