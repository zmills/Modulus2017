using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model.Personal;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel.AccountViewModels
{
    public class ScheduleFragmentViewModel : ViewModelBase
    {
        private List<StudentEvent> Events = new List<StudentEvent>();

        /* This list starts on SUNDAY                                          */
        public ObservableCollection<ObservableCollection<StudentEvent>> Schedule
            = new ObservableCollection<ObservableCollection<StudentEvent>>
            {
                new ObservableCollection<StudentEvent>(),
                new ObservableCollection<StudentEvent>(),
                new ObservableCollection<StudentEvent>(),
                new ObservableCollection<StudentEvent>(),
                new ObservableCollection<StudentEvent>(),
                new ObservableCollection<StudentEvent>(),
                new ObservableCollection<StudentEvent>(),
                new ObservableCollection<StudentEvent>(),
            };

        readonly IAzureService Database;

        public ScheduleFragmentViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task InitializeAsync()
        {
            Events = await Database.GetScheduleEventsAsync();
            SortEvents();
        }

        public void InitializeStatic()
        {
            for (int count = 0; count < 7; count++)
            {
                var studentEvent = new StudentEvent
                {
                    Title = $"My Sunday Event {count}",
                    BeginTime = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Sunday"
                };
                Events.Add(studentEvent);

                var student2Event = new StudentEvent
                {
                    Title = $"My Monday Event {count}",
                    BeginTime = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Monday"
                };
                Events.Add(student2Event);

                var student3Event = new StudentEvent
                {
                    Title = $"My Tuesday Event {count}",
                    BeginTime = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Tuesday"
                };
                Events.Add(student3Event);

                var student4Event = new StudentEvent
                {
                    Title = $"My Wednesday Event {count}",
                    BeginTime = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Wednesday"
                };
                Events.Add(student4Event);

                var student5Event = new StudentEvent
                {
                    Title = $"My Thursday Event {count}",
                    BeginTime = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Thursday"
                };
                Events.Add(student5Event);

                var student6Event = new StudentEvent
                {
                    Title = $"My Friday Event {count}",
                    BeginTime = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Friday"
                };
                Events.Add(student6Event);

                var student7Event = new StudentEvent
                {
                    Title = $"My Saturday Event {count}",
                    BeginTime = $"{count}:00 - {count + 1}:00",
                    Location = "Field House",
                    Day = "Saturday"
                };
                Events.Add(student7Event);
            }

            SortEvents();
        }

        private void SortEvents()
        {
            foreach (var current in Events)
            {
                switch (current.Day)
                {
                    case App.Days.Sunday:
                        Schedule[0].Add(current);
                        break;
                    case App.Days.Monday:
                        Schedule[1].Add(current);
                        break;
                    case App.Days.Tuesday:
                        Schedule[2].Add(current);
                        break;
                    case App.Days.Wednesday:
                        Schedule[3].Add(current);
                        break;
                    case App.Days.Thursday:
                        Schedule[4].Add(current);
                        break;
                    case App.Days.Friday:
                        Schedule[5].Add(current);
                        break;
                    case App.Days.Saturday:
                        Schedule[6].Add(current);
                        break;
                }
            }
        }

        private void ClearSchedule()
        {
            foreach (var item in Schedule)
                item.Clear();
        }

        public override void Cleanup()
        {
            Events.Clear();
            ClearSchedule();
            base.Cleanup();
        }
    }
}
